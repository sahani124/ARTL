#region
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
#endregion

namespace INSCL
{
    public partial class SearchUnitRank : Base
    {
        #region DECLARATIONS
        Hashtable htable = new Hashtable();
        private multilingualManager olng;
        private string strUserLang;
        string strUnitRank, strXML = "";
        XmlDocument doc = new XmlDocument();
        string ErrMsg, AuditType;
        DataSet dsResult = new DataSet();
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        string chnnl;
        ErrLog objErr = new ErrLog();
        #endregion

        #region PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["CarrierCode"] = '2';
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                if (!IsPostBack)
                {
                    olng = new multilingualManager("DefaultConn", "SearchUnitRank.aspx", strUserLang);
                    divcmpsrchhdrcollapse.Style.Add("display", "none");
                    EnableDisableButton();
                    InitializeControl();
                    if (Request.QueryString["Flag"] != null)
                    {
                        string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                        string strFlag = strFlagArr[0].Trim().ToString();
                        if (strFlag == "All")
                        {
                            FillChannelName();
                            RefreshGrid();
                        }
                        else
                        {
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.SelectedValue = strFlag;
                            FillChannelName();
                            //RefreshGrid();
                            Refresh();
                        }
                    }
                    else if (Request.QueryString["Code"] != null)
                    {
                        string strFlag = Request.QueryString["Code"].ToString();
                        if (strFlag == "All")
                        {
                            FillChannelName();
                            RefreshGrid();
                        }
                        else
                        {
                            FillChannelName();
                            RefreshGrid();
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        }
                    }
                    else
                    {
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                    }
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnAddnew.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "Page_Load", ex);
            }

        }
        #endregion

        #region EnableDisableButton
        private void EnableDisableButton()
        {
            try
            {
                dsResult = null;
                strDesc01 = "Enable Modification of Channel Maintenance";
                strModule = "CHMS";
                dsResult = objCommonU.GetConfigSettings(strDesc01, strModule);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    strValue = dsResult.Tables[0].Rows[0]["Value"].ToString().Trim();
                    HttpContext.Current.Session["StrValue"] = strValue;
                }
                if (strValue == "YES")
                {
                    btnAddnew.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    btnAddnew.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            try
            {
                lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
                lblhdr.Text = (olng.GetItemDesc("lblChannelUnitRankSetup"));
                lblUnitRankSearchResult.Text = (olng.GetItemDesc("lblUnitRankSearchResult"));
                lblChnlType.Text = (olng.GetItemDesc("lblChnlType.text"));
                lblhdr.Text = "UNIT RANK SETUP";
                lblUnitRankSearchResult.Text = "UNIT RANK SEARCH RESULTS";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "InitializeControl", ex);
            }
        }
        #endregion

        #region Get Value
        private void getValue(string strChnCls)
        {
            try
            {
                DataSet dsResult = new DataSet();
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@ChnlDesc", strChnCls);
                dsResult.Clear();
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetBizSrValue", htParam);
                chnnl = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "getValue", ex);
            }
        }
        #endregion

        #region SEARCH
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddnew.Visible = true;
                divcmpsrchhdrcollapse.Style.Add("display", "block");
                DataSet dsdataset = new DataSet();
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                Session["grid"] = "";
                this.RefreshGrid();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "btnSearch_Click", ex);
            }

        }
        #endregion

        #region REFRESHGRID
        private void RefreshGrid()
        {
            try
            {
                if (rdbChnlTyp.SelectedValue == "0")
                {
                    htable.Add("@Flag", 1);
                }
                else
                {
                    htable.Add("@Flag", 2);
                }
                string BizSrc;
                if (this.ddlSalesChannel.SelectedIndex == 0)
                {
                    BizSrc = "";
                }
                else
                {
                    BizSrc = this.ddlSalesChannel.SelectedValue;
                }
                DataSet dsdataset = new DataSet();
                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", BizSrc);
                FillGridView(htable, dgDetails, "prc_UnitRankSearch", "INSCCommonConnectionString");
                if (dgDetails.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                    txtPage.Text = "1";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "RefreshGrid", ex);
            }
        }

        #endregion

        private void Refresh()
        {
            try
            {
                if (rdbChnlTyp.SelectedValue == "0")
                {
                    htable.Add("@Flag", 1);
                }
                else
                {
                    htable.Add("@Flag", 2);
                }
                string BizSrc;
                if (this.ddlSalesChannel.SelectedIndex == 0)
                {
                    BizSrc = "";
                }
                else
                {
                    BizSrc = this.ddlSalesChannel.SelectedValue;
                }
                DataSet dsdataset = new DataSet();
                string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                string strFlag = strFlagArr[0].Trim().ToString();
                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", strFlag);
                FillGridView(htable, dgDetails, "prc_UnitRankSearch", "INSCCommonConnectionString");
                if (dgDetails.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                    txtPage.Text = "1";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "RefreshGrid", ex);
            }
        }

        #region GetDisplay
        public DataTable GetDisplay(string BizSrc)
        {
            DataSet dsdataset = new DataSet();
            htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
            htable.Add("@BizSrc", BizSrc);
            dsdataset = objDAL.GetDataSetForPrc("prc_UnitRankSearch", htable);
            htable.Clear();
            return dsdataset.Tables[0];
        }
        #endregion

        #region RowDataBound
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var strChnCls1 = string.Empty;
                    if (e.Row.Cells[0].Text != "&nbsp;")
                    {
                        strChnCls1 = e.Row.Cells[0].Text.ToString();
                        var strChnCls = strChnCls1.Replace("amp;", "");
                        getValue(strChnCls);
                        e.Row.Cells[1].Text = "<i class=\"fa fa-list-ol\"></i>&nbsp;<a href=\"UnitRank.aspx?untRnk=" + e.Row.Cells[1].Text + "&SalesChannel=" + e.Row.Cells[0].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&flag=E" + "&BizSrc=" + chnnl + "\">" + e.Row.Cells[1].Text + "</a>";
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                    Label lblUntRank = (Label)e.Row.FindControl("lbluntRnk");
                    if (HttpContext.Current.Session["StrValue"].ToString() == "YES")
                    {
                        l.Enabled = true;
                    }
                    else if (HttpContext.Current.Session["StrValue"].ToString() == "NO")
                    {
                        l.Enabled = false;
                    }
                    l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete unit for the rank " + lblUntRank.Text.ToString().Trim() + "?')");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "EnableDisableButton", ex);
            }
        }


        #endregion

        #region Button 'btnAddnew' Click Event
        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("UnitRank.aspx?slsChn=" + ddlSalesChannel.SelectedValue.ToString().Trim() + "&flag=N");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "btnAddnew_Click", ex);
            }
        }
        #endregion

        #region SORTING
        protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridView dgSource = (GridView)sender;
                string strSort = string.Empty;
                string strASC = string.Empty;
                if (dgSource.Attributes["SortExpression"] != null)
                {
                    strSort = dgSource.Attributes["SortExpression"].ToString();
                }
                if (dgSource.Attributes["SortASC"] != null)
                {
                    strASC = dgSource.Attributes["SortASC"].ToString();
                }
                dgSource.Attributes["SortExpression"] = e.SortExpression;
                dgSource.Attributes["SortASC"] = "Yes";
                if (e.SortExpression == strSort)
                {
                    if (strASC == "Yes")
                    {
                        dgSource.Attributes["SortASC"] = "No";
                    }
                    else
                    {
                        dgSource.Attributes["SortASC"] = "Yes";
                    }
                }
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                if (BizSrc == "All")
                {
                    BizSrc = "";
                }
                DataTable dt = GetDisplay(BizSrc);
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region PAGEINDEX
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                if (BizSrc == "All")
                {
                    BizSrc = "";
                }
                DataSet ds = ViewState["Dataset"] as DataSet;
                DataView dv = new DataView(ds.Tables[0]);
                GridView dgSource = (GridView)sender;
                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "dgDetails_PageIndexChanging", ex);
            }
        }
        #endregion

        #region PAGEINFORMATION
        private void ShowPageInformation()
        {
            try
            {
                int intPageIndex = dgDetails.PageIndex + 1;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "ShowPageInformation", ex);
            }
        }
        #endregion

        #region Button 'btnClear' Click Event
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SearchUnitRank.aspx");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region dgDetails RowDeleting Event
        protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "dgDetails_RowDeleting", ex);
            }
        }
        #endregion

        #region Channel Type OnClick Event
        protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbChnlTyp.SelectedValue == "0")
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "0");
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
                    Hashtable ht = new Hashtable();
                    ht.Clear();
                    //ht.Add("@ChannelType", "O"); FillDropDowns
                    //public void FillDropDown(DropDownList ddl, string ProcedureName, Hashtable ht, string connString, string srtDefault, string DataTextField, string DataValueField)
                    //FillDropDown(ddlSalesChannel, "Prc_FillCompnyName", ht, "INSCCommonConnectionString", "ALL", "ParamDesc", "ParamValue");
                }
                else
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "rdbChnlTyp_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region btnOldHier_Click
        protected void btnOldHier_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funpopup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "btnOldHier_Click", ex);
            }
        }
        #endregion

        #region Paging next button
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                RefreshGrid();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnnext.Enabled = false;
                }
                int page = dgDetails.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "btnnext_Click", ex);
            }
        }
        #endregion

        #region Paging previous button
        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                RefreshGrid();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnnext.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnprevious.Enabled = false;
                }
                int page = dgDetails.PageCount;
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }
                else
                {
                    btnprevious.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "btnprevious_Click", ex);
            }
        }
        #endregion

        #region Fill Channel Name
        protected void FillChannelName()
        {
            try
            {
                Hashtable ht = new Hashtable();
                if (rdbChnlTyp.SelectedValue == "0")
                {
                    ht.Clear();
                    ht.Add("@ChannelType", "O");
                    FillDropDowns(ddlSalesChannel, "PRC_FILLDDL_CMPSU", ht, "INSCCommonConnectionString", "", true, "flagN");
                }
                else
                {
                    ht.Clear();
                    ht.Add("@carriercode", "2");
                    ht.Add("@strIncMasterCmp", "1");
                    FillDropDowns(ddlSalesChannel, "Prc_GetSalesChannel", ht, "INSCCommonConnectionString", "", true, "flagN");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitRank.aspx", "FillChannelName", ex);
            }
        }
        #endregion
    }
}
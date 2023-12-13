using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using INSCL.DAL;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;

    public partial class Application_ISys_ChannelMgmt_PopSearchUnitRank : BaseClass
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
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {

                    Response.Redirect("~/ErrorSession.aspx");
                }
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "SearchUnitRank.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                //EnableDisableButton();
                if (!IsPostBack)
                {
                    bindDdlFincYear();
                    InitializeControl();
                    if (Request.QueryString["Flag"] != null)
                    {
                        string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                        string strFlag = strFlagArr[0].Trim().ToString();
                        if (strFlag == "All")
                        {
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            this.RefreshGrid();
                        }
                        else
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            this.RefreshGrid();
                        }

                    }
                    else if (Request.QueryString["Code"] != null)
                    {
                        string strFlag = Request.QueryString["Code"].ToString();
                        if (strFlag == "All")
                        {
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            this.RefreshGrid();
                        }
                        else
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            this.RefreshGrid();
                        }
                    }
                    else
                    {
                        //objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        //ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        tbldgDtls.Visible = false;
                        trDetails.Visible = false;
                        trDgDetails.Visible = false;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

        }
        #endregion
        #region InitializeControl
        private void InitializeControl()
        {
            lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
            lblChannelUnitRankSetup.Text = (olng.GetItemDesc("lblChannelUnitRankSetup"));
            lblUnitRankSearchResult.Text = (olng.GetItemDesc("lblUnitRankSearchResult"));
            lblChnlType.Text = (olng.GetItemDesc("lblChnlType.text"));//added by akshay on 13/12/13
        }
        #endregion
        private void getValue(string strChnCls)
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@ChnlDesc", strChnCls);
            dsResult.Clear();
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetBizSrValue", htParam);
            chnnl = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
        }
        #region SEARCH
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsdataset = new DataSet();
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                this.RefreshGrid();
            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

        }
        #endregion
        #region REFRESHGRID
        private void RefreshGrid()
        {
            //Added by Kalyani on 16-12-2013 to display Company or Channel selection start
            if (rdbChnlTyp.SelectedValue == "0")
            {
                htable.Add("@Flag", 1);
            }
            else
            {
                htable.Add("@Flag", 2);
            }
            //Added by Kalyani on 16-12-2013 to display Company or Channel selection end
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
            htable.Add("@Period", ddlFincYear.SelectedValue);
            htable.Add("@BaseVersion", ddlBaseVersion.SelectedValue);
            dsdataset = objDAL.GetDataSetForPrc("prc_UnitRankSearch", htable);
            ViewState["Dataset"] = dsdataset;
            htable.Clear();

            if (dsdataset.Tables.Count > 0)
            {
                if (dsdataset.Tables[0].Rows.Count > 0)
                {
                    dgDetails.DataSource = dsdataset.Tables[0];
                    dgDetails.DataBind();
                    ShowPageInformation();
                    tbldgDtls.Visible = true;
                    trDetails.Visible = true;
                    trDgDetails.Visible = true;
                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    tbldgDtls.Visible = false;
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                }
            }
            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblPageInfo.Text = "";
                tbldgDtls.Visible = false;
                trDetails.Visible = false;
                trDgDetails.Visible = false;
            }

            ShowPageInformation();
        }
        #endregion
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
        #region SORTING
        protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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
        #endregion
        #region PAGEINDEX
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string BizSrc = this.ddlSalesChannel.SelectedValue;
            if (BizSrc == "All")
            {
                BizSrc = "";
            }

            //DataTable dt = GetDisplay(BizSrc);
            //DataView dv = new DataView(dt);
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
        #endregion
        #region PAGEINFORMATION
        private void ShowPageInformation()
        {
            int intPageIndex = dgDetails.PageIndex + 1;
            lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        }
        #endregion
        #region Button 'btnClear' Click Event
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("PopSearchUnitRank.aspx");
        }
        #endregion
        protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbChnlTyp.SelectedValue == "0")
            {
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "0");
                ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
            }
            else
            {
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
            }
        }

        private void bindDdlFincYear()
        {
            htable.Clear();
            dsResult = null;
            htable.Clear();
            htable.Add("@Flag", "UnitRank");
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetFincYears", htable);
            if (dsResult != null)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ddlFincYear.DataSource = dsResult.Tables[0];
                    ddlFincYear.DataTextField = "Period";
                    ddlFincYear.DataValueField = "Period";
                    ddlFincYear.DataBind();
                }
            }
            ddlFincYear.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        protected void ddlFincYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDdlBaseVersion();

        }

        private void bindDdlBaseVersion()
        {
            htable.Clear();
            dsResult = null;
            htable.Add("@Period", ddlFincYear.SelectedValue);
            htable.Add("@Flag", "UnitRank");
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetVersionDtls", htable);
            if (dsResult != null)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ddlBaseVersion.DataSource = dsResult.Tables[0];
                    ddlBaseVersion.DataTextField = "BaseVersion";
                    ddlBaseVersion.DataValueField = "BaseVersion";
                    ddlBaseVersion.DataBind();
                }
                ddlBaseVersion.Items.Insert(0, new ListItem("-- Select --", ""));
            }
           
        }
    }

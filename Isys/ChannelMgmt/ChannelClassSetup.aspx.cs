using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
using System.Web.UI;

namespace INSCL
{
    public partial class ChannelClassSetup : Base
    {
        #region DECLARATION
        string ErrMsg;
        string AuditType;
        XmlDocument doc = new XmlDocument();
        SqlDataReader dtRead;
        string saleschannel;
        string SubChnlType;
        string Flag;
        string ChnCls;
        Hashtable htable = new Hashtable();
        DataSet dsResult = new DataSet();
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;
        private multilingualManager olng;
        private string strUserLang;
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        string chnnl;
        ErrLog objErr = new ErrLog();
        string ChnTyp = string.Empty;
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                FunCheckSession();
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "ChannelClassSetup.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                if (Request.QueryString["Flag"] != "/N")
                {
                    hdnBizSrc.Value = Request.QueryString["BizSrc"].ToString();
                    hdnchncls.Value = Request.QueryString["Chncls"].ToString();
                    hdnChnlNm.Value = Request.QueryString["BizSrcNM"].ToString();
                }
                if (!IsPostBack)
                {
                    SetSessionObjectValue("OldProductDetails", null);
                    SetSessionObjectValue("ProductDetails", null);
                    EnableDisable();
                    InitializeControl();
                    LoadData();
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnUpdate.Enabled = false;
                    }
                    fillFinyr();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "Page_Load", ex);
            }
        }
        #endregion
        private void EnableDisable()
        {
            try
            {
                if (Request.QueryString["Flag"] != null)
                {
                    string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                    string strFlag = strFlagArr[1].Trim().ToString();
                    hdnProdcodeEdit.Value = strFlag;//AddEdit Flag
                    if (strFlag == "N")
                    {
                        ddlSalesChannel.Visible = true;
                        ddlSubChnlType.Visible = true;
                        txtChnCls.Visible = true;
                        lblChannel.Visible = false;
                        FillChannelName();
                        divModification.Attributes.Add("style", "display:none;margin-left:2%;margin-right:2%;");
                        btnshowHist.Visible = false;
                        ddlParentSubChnl.Enabled = true;
                        btnUpdate.Visible = false;
                        txtVer.Enabled = false;
                        txtVer.Text = "1.00";
                        txtSortorder.Enabled = false;
                    }
                    else
                    {
                        lblChannel.Visible = true;
                        lblSubChnl.Visible = true;
                        string code = Request.QueryString["ChnCls"].ToString();
                        lblChannel.Text = Request.QueryString["BizSrcNM"].ToString();
                        ddlSalesChannel.Visible = false;
                        ddlSubChnlType.Visible = true;
                    }
                }
                else
                {
                    lblChannel.Visible = true;
                    lblSubChnl.Visible = true;
                    lblChannel.Text = Request.QueryString["BizSrcNM"].ToString();
                    ddlSalesChannel.Visible = false;
                    ddlSubChnlType.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    GetDataTable();
                    ControlEnableddesable();
                    hdnProdcodeEdit.Value = "E";
                }
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "EnableDisable", ex);
            }
        }

        #region InitializeControl
        private void InitializeControl()
        {
            try
            {
                lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
                lblClass.Text = (olng.GetItemDesc("lblClass.Text"));
                lblDesc1.Text = (olng.GetItemDesc("lblDesc1.Text"));
                lblDesc2.Text = (olng.GetItemDesc("lblDesc2.Text"));
                lblDesc3.Text = (olng.GetItemDesc("lblDesc3.Text"));
                lblSortOrder.Text = (olng.GetItemDesc("lblSortOrder.Text"));
                lblPer.Text = (olng.GetItemDesc("lblPeriod"));
                lblVer.Text = (olng.GetItemDesc("lblVersion"));
                lblEffDate.Text = (olng.GetItemDesc("lblEff"));
                lblCseDt.Text = (olng.GetItemDesc("lblCease"));
                lblhdr.Text = (olng.GetItemDesc("lblhdrOth"));
                lblSaleschannel.Text = "Channel Name";
                lblClass.Text = "Sub Class Code";
                lblhdr.Text = "OTHER DETAILS";
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "InitializeControl", ex);
            }
        }
        #endregion
        #region BUTTON Cancel Click
        protected void Cancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Flag"] != null)
            {
                Response.Redirect("ChannelClassMas.aspx?flag=" + Request.QueryString["Flag"].ToString() + "");
            }
            else
            {
                Response.Redirect("ChannelClassMas.aspx?Code=" + Request.QueryString["Cancel"].ToString() + "");
            }
        }
        #endregion
        #region start Code added by bhau added on 07/04/2018

        #region lnkbtnaddprod_Click
        protected void lnkbtnaddprod_Click(object sender, EventArgs e)
        {
            try
            {
                MdlPopExtndrLOB.Show();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "lnkbtnaddprod_Click", ex);
            }

        }
        #endregion

        #region btnProductDtls_Click
        protected void btnProductDtls_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["flag"] == null)
                {
                    DataTable dt1 = new DataTable();
                    dt1 = (DataTable)Session["ProductDetails"];
                }
                GetDataTable();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "btnProductDtls_Click", ex);
            }
            finally
            {
                dsResult = null;
                htable.Clear();
            }
        }
        #endregion

        #region btnprevious_Click
        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex - 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }
                else
                {
                    btnprevious.Enabled = true;
                }
                btnnext.Enabled = true;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "btnprevious_Click", ex);
            }
        }
        #endregion

        #region btnnext_Click
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex + 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                int page = GridProdDtls.PageCount;
                if (txtPage.Text == Convert.ToString(GridProdDtls.PageCount))
                {
                    btnnext.Enabled = false;
                }
                else
                {
                    int intPageIndex = GridProdDtls.PageIndex + 1;
                    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "btnnext_Click", ex);
            }
        }
        #endregion

        #region GrdStateDtls_PageIndexChanging
        protected void GrdStateDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dt = GetDataTable();
                DataView dv = new DataView(dt);
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
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "GrdStateDtls_PageIndexChanging", ex);
            }
        }
        #endregion

        #region GetDataTable
        protected DataTable GetDataTable()
        {
            try
            {
                string strProdcode, strProdName, LOBList, strOldProdcode;
                DataTable dt = new DataTable();
                DataTable dtold = new DataTable();
                dt = (DataTable)Session["ProductDetails"];
                if (dt != null)/*&& Request.QueryString["flag"] == null*/
                {
                    strProdcode = dt.Rows[0]["ProdCode"].ToString();
                    strProdName = dt.Rows[0]["ProdName"].ToString();
                    LOBList = dt.Rows[0]["LOBList"].ToString();
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = strProdcode;

                    if (Session["OldProductDetails"] != null)
                    {
                        dtold = (DataTable)Session["OldProductDetails"];
                        strOldProdcode = dtold.Rows[0]["ProdCode"].ToString();
                        //strProdcode = strProdcode + "','" + strOldProdcode;
                        strProdcode = strProdcode + "," + strOldProdcode;
                    }
                    htable.Clear();
                    dsResult = null;
                    htable.Add("@ProdCode", strProdcode.ToString());
                    htable.Add("@LOBList", LOBList.ToString());
                    /* dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);*/
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtlsSubClass", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {

                            //bind old and new value to grid
                            Session["OldProductDetails"] = dt;
                            GridProdDtls.DataSource = dsResult.Tables[0];
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();
                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            divProducrGridDtls.Visible = false;
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            //divProducrGridDtls.Attributes.Add("style", "display:none");
                        }
                    }
                }
                else
                {
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = "";
                    htable.Clear();
                    dsResult = null;
                    if (Request.QueryString["flag"] == null)
                    {
                        htable.Add("@bizsrc", Request.QueryString["BizSrc"].ToString());//ViewState["bizsrc"].ToString()
                    }
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            divProducrGridDtls.Visible = true;
                            GridProdDtls.DataSource = dsResult;
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();

                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            divProducrGridDtls.Visible = false;
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "GetDataTable", ex);
            }
            return dsResult.Tables[0];
        }
        #endregion

        #region ShowPageInformation
        private void ShowPageInformation()
        {
            try
            {
                tblpagination.Visible = true;
                int intPageIndex = GridProdDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "ShowPageInformation", ex);
            }
        }
        #endregion

        #region GridProdDtls_RowDataBound
        protected void GridProdDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Request.QueryString["flag"] == "/N")
                    {
                        Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                        lnkdelete.Enabled = false;
                    }
                    else
                    {
                        string StrStatus = ((Label)e.Row.FindControl("lblStatus")).Text;

                        if (StrStatus == "Deactive")
                        {
                            Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                            lnkdelete.Enabled = false;
                        }
                        else
                        {
                            Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                            lnkdelete.Enabled = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "GridProdDtls_RowDataBound", ex);
            }
        }
        #endregion GridProdDtls_RowDataBound

        #region lnkdelete_Click
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btndetails = sender as Button;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                string strProdcode = ((Label)gvrow.FindControl("lblProdCode")).Text;
                string strProdName = ((Label)gvrow.FindControl("lblProdName")).Text;
                string strEffDate = ((Label)gvrow.FindControl("lblEffFromDate")).Text;
                hdn1.Value = strProdcode;
                hdn2.Value = strProdName;
                hdn3.Value = strEffDate;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "lnkdelete_Click", ex);
            }
        }
        #endregion lnkdelete_Click

        #region InsertProductDtls
        public void InsertProductDtls()
        {
            try
            {

                foreach (GridViewRow grdtls in GridProdDtls.Rows)
                {
                    string StrProdCode = ((Label)grdtls.FindControl("lblProdCode")).Text;
                    string StrEffdtim = ((Label)grdtls.FindControl("lblEffFromDate")).Text;
                    string StrLobCode = ((Label)grdtls.FindControl("lblLobCode")).Text;
                    string StrStatus = ((Label)grdtls.FindControl("lblStatus")).Text;
                    string StrCeasedate = ((Label)grdtls.FindControl("lblCeaseDtim")).Text;
                    htable = new Hashtable();
                    htable.Clear();
                    htable.Add("@Bizsrc", ddlSalesChannel.SelectedValue.ToString());
                    htable.Add("@Chncls", txtChnCls.Text.ToString());
                    htable.Add("@Flag", "S");
                    htable.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                    htable.Add("@ProdCode", StrProdCode);
                    htable.Add("@EffDate", StrEffdtim);
                    htable.Add("@LOBCode", StrLobCode);
                    htable.Add("@Status", StrStatus);
                    htable.Add("@Ceasedate", StrCeasedate);
                    objDAL.execute_sprcIsysTemp("Prc_InsertProductDtls", htable);
                }


            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "InsertProductDtls", ex);
            }
        }
        #endregion
        #endregion end Code added by bhau added on 07/04/2018 

        private void Get_ParenSubChnl()
        {
            try
            {
                if (Request.QueryString["Flag"] != null)
                {
                    string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                    string strFlag = strFlagArr[1].Trim().ToString();
                    hdnProdcodeEdit.Value = strFlag;//AddEdit Flag
                    if (strFlag == "N")
                    {
                        Hashtable ht1 = new Hashtable();
                        DataSet ds1 = new DataSet();
                        ht1.Add("@bizsrc", ddlSalesChannel.SelectedValue.ToString().Trim());
                        FillDropDown(ddlParentSubChnl, "pre_getPrntSubChn", ht1, "INSCCommonConnectionString", "select", true, "flagN");
                        ddlParentSubChnl.SelectedValue = "";
                    }
                }
                else
                {
                    hdnBizSrc.Value = Request.QueryString["BizSrc"].ToString();
                    Hashtable ht1 = new Hashtable();
                    ht1.Clear();
                    DataSet ds1 = new DataSet();
                    ht1.Add("@ChnCls", lblChncls.Text);
                    ht1.Add("@bizsrc", Request.QueryString["BizSrc"].ToString().Trim());
                    FillDropDown(ddlParentSubChnl, "pre_getPrntSubChn_EditMode", ht1, "INSCCommonConnectionString", "select", true, "flagN");
                    //FillDDL(ddlParentSubChnl, "pre_getPrntSubChn_EditMode", ht1, "INSCCommonConnectionString", "Select", "ParamDesc", "ParamValue");
                    ddlParentSubChnl.SelectedValue = "";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "Get_ParenSubChnl", ex);
            }
        }

        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_ParenSubChnl();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAndUpdateValues(htable);
                InsertData("Prc_Upt_chnClsSu", htable, "INSCCommonConnectionString");
                RBHIDE();
                htable.Clear();
                btnUpdate.Enabled = false;
                if (Request.QueryString["ChnCls"] != null)
                {
                    lbl_popup.Text = "Sub Class Setup Updated successfully<br /><br />Channel: " + lblChannel.Text.ToString() + "<br /><br /> Sub Class: " + lblChncls.Text;
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "btnUpdate_Click", ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["flag"] != null)
                {
                    string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                    Flag = strFlagArr[1].Trim().ToString();
                }
                else
                {
                    Flag = "Y";
                }
                if (Request.QueryString["ChnTyp"] != null)
                {
                    ChnTyp = Request.QueryString["ChnTyp"].ToString().Trim();
                }
                InsertAndUpdateValues(htable);
                if (Flag == "N" && ChnTyp == "")
                {
                    InsertData("Prc_Ins_chnClsSu", htable, "INSCCommonConnectionString");
                    htable.Clear();
                    btnSave.Enabled = false;
                }
                if (Request.QueryString["ChnCls"] == null)
                {
                    lbl_popup.Text = "Sub Class Setup added successfully for<br /><br />Channel:" + ddlSalesChannel.SelectedItem.Text.ToString() + "<br /><br /> Sub Class:" + txtChnCls.Text;
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "btnSave_Click", ex);
            }
        }
        private void InsertAndUpdateValues(Hashtable htable)
        {
            try
            {
                if (this.ddlSalesChannel.Visible == true)
                {
                    saleschannel = this.ddlSalesChannel.SelectedValue.ToString();
                }
                else
                {
                    if (Request.QueryString["BizSrc"] != null)
                    {
                        saleschannel = Request.QueryString["BizSrc"].ToString();
                    }

                }
                if (txtVer.Text.Trim() == "")
                {
                    txtVer.Text = "1.00";
                }

                if (txtChnCls.Visible == true)
                {
                    ChnCls = txtChnCls.Text.ToUpper();
                }
                else
                {
                    ChnCls = lblChncls.Text;
                }
                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", saleschannel);
                htable.Add("@ChnCls", ChnCls);
                htable.Add("@ChnClsDesc01", txtDesc1.Text.ToString());
                htable.Add("@ChnClsDesc02", txtDesc2.Text.ToString());
                htable.Add("@ChnClsDesc03", txtDesc3.Text.ToString());
                htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                htable.Add("@Period", ddlFinancialYr.SelectedValue);
                htable.Add("@Version", txtVer.Text.ToString());
                htable.Add("@SubChnlType", ddlSubChnlType.SelectedItem.Text.ToString());
                FillTextboxDatetm(htable, "@EffDate", txtEffDate.Text.Trim().ToString());
                FillTextboxDatetm(htable, "@CeaseDate", txtCseDt.Text.Trim().ToString());
                FillddlcheckNull(ddlParentSubChnl, htable, "@SubChnlId", ddlParentSubChnl.SelectedValue.ToString().Trim());
                FillrbcheckNull(rbCorrection, htable, "@ModMode", rbCorrection.SelectedValue);
                htable.Add("@Status", DropDownList1.SelectedItem.Text);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "InsertAndUpdateValues", ex);
            }
        }
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "hideRadioSymbol()", true);
            ControlEnableddesable();
        }
        private void ControlEnableddesable()
        {
            try
            {
                if (rbCorrection.SelectedValue == "CR")
                {
                    txtDesc1.Enabled = true;
                    txtDesc2.Enabled = true;
                    txtDesc3.Enabled = true;
                    ddlParentSubChnl.Enabled = true;
                    txtFinYr.Enabled = false;
                    ddlFinancialYr.Enabled = false;
                    txtSortorder.Enabled = false;
                    txtEffDate.Enabled = true;
                    txtVer.Enabled = false;
                    //txtCseDt.Enabled = false;
                    lblChannel.Enabled = false;
                    lblChncls.Enabled = false;
                    ddlSubChnlType.Enabled = false;
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");


                }
                else
                {
                    txtDesc1.Enabled = false;
                    txtDesc2.Enabled = false;
                    txtDesc3.Enabled = false;
                    txtFinYr.Enabled = true;
                    txtVer.Enabled = false;
                    lblChncls.Enabled = false;
                    txtCseDt.Enabled = false;
                    ddlParentSubChnl.Enabled = false;
                    ddlSubChnlType.Enabled = true;
                    txtSortorder.Enabled = false;
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "ControlEnableddesable", ex);
            }
        }

        private void LoadData()
        {
            try
            {
                if (Request.QueryString["ChnCls"] != null)
                {
                    lblChncls.Visible = true;
                    lblChncls.Text = Request.QueryString["ChnCls"];
                    string ChnClass = Request.QueryString["ChnCls"];
                    clsChannelSetup channelcode = new clsChannelSetup();
                    dtRead = channelcode.SelectChannelClass(ChnClass, Session["CarrierCode"].ToString());
                    if (dtRead.Read())
                    {
                        txtDesc1.Text = dtRead[0].ToString();
                        txtDesc2.Text = dtRead[1].ToString();
                        txtDesc3.Text = dtRead[2].ToString();
                        txtSortorder.Text = dtRead[3].ToString();
                        lblChannel.Text = Request.QueryString["BizSrcNM"].ToString();
                        txtFinYr.Text = dtRead[4].ToString();
                        txtVer.Text = dtRead[5].ToString();
                        txtEffDate.Text = dtRead[6].ToString();
                        txtCseDt.Text = dtRead[7].ToString();
                        ddlSubChnlType.SelectedValue = dtRead[8].ToString();
                        Get_ParenSubChnl();
                        ddlParentSubChnl.SelectedValue = dtRead[10].ToString();
                    }
                    dtRead.Close();
                    GetDataTable();
                    fillFinyr();
                }
                else
                {
                    Get_ParenSubChnl();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "LoadData", ex);
            }
        }

        protected void fillFinyr()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Clear();
                ht.Add("@flag", "N");
                FillDropDowns(ddlFinancialYr, "Prc_get_Current_FinYear", ht, "INSCCommonConnectionString", "", true, "flagN");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "fillFinyr", ex);
            }
        }
        protected void FillChannelName()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Clear();
                ht.Add("@carriercode", "2");
                ht.Add("@strIncMasterCmp", "1");
                FillDropDowns(ddlSalesChannel, "Prc_GetSales_FillChannel", ht, "INSCCommonConnectionString", "", true, "flagN");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassSetup.aspx", "FillChannelName", ex);
            }
        }

        //Validation before data insertion for records if already exists. 
        public void ValidateInsertionData()
        {
            try
            {
                if (this.txtChnCls.Text.Trim().Length != 4)// Added by sanoj for Validation sahani 10-12-2021
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Minimum Four Character');</script>", false);
                    this.txtChnCls.Text = "";
                    this.txtChnCls.Focus();
                    return;
                }
                else
                {
                    DataSet dsreturn = new DataSet();
                    htable.Add("@ChnCls", this.txtChnCls.Text.Trim());
                    dsreturn = ValidationIfDataAlreadyExists("Prc_CheckifRecordExists_chnClsSu", htable, "INSCCommonConnectionString");
                    if (dsreturn.Tables.Count != 0)
                    {
                        string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                        if (comnm == "Sub Channel code already exists")
                        {
                            txtChnCls.Text = "";
                            txtChnCls.Focus();
                        }
                        return;
                    }
                }
            
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "CompanySetup.aspx", "btnSave_Click", ex);
            }
        }

        protected void txtChnCls_TextChanged(object sender, EventArgs e)
        {
            ValidateInsertionData();
        }
        #region after update rb hide
        public void RBHIDE()
        {
            if (rbCorrection.SelectedValue == "CH")
            {
                rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
            }
            if (rbCorrection.SelectedValue == "CR")
            {
                rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
            }
        }
        #endregion
    }
}

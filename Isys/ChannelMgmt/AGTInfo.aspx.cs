#region Namespaces
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataAccessClassDAL;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.Export.Pdf;
using DataDynamics.ActiveReports.Export.Xls;
using Insc.Common.Multilingual;
using INSCL.DAL;
using System.Text;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
#endregion

namespace INSCL
{
    /// <summary>
    /// Page Name:  AGTInfo.aspx
    /// Purpose:    To Show & Edit Agent Details
    /// Modified by :ajay yadav
    /// </summary>

    public partial class AGTInfo : BaseClass
    {
        #region DECLARATION
        CommonFunc oCommon = new CommonFunc();
        INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
        DataAccessClass objDAL = new DataAccessClass();
        private DataAccessClass dataAccessRecruit = new DataAccessClass();
        clsChannelSetup objChnSetup = new clsChannelSetup();
        string ErrMsg, AuditType;
        SqlDataReader dtRead;
        SqlDataReader dtRead1;
        SqlDataReader dataread;
        public string Code { get; set; }
        string strMemType = string.Empty;
        DataSet ds_documentName = new DataSet();
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        public int image_height;
        public int image_width;
        public int max_height;
        public int max_width;
        public byte[] data;
        public byte[] imgres;
        private string strFileName = string.Empty;
        private const string c_strBlank = "-- Select --";
        string str_BizSrc = "", str_CarrierCode = "", str_AgentType = "", str_AgnCode = "", str_ChnClass = "";
        int intCode;
        string StrFlag = "";
        string strRemark = "";
        XmlDocument doc = new XmlDocument();
        string strAgntStatus = "", strXML = "";
        private multilingualManager olng;
        private string strUserLang;
        string strErrMsg = "";
        private DataAccessClass dataAccess = new DataAccessClass();
        private DataAccessClass objRecruit = new DataAccessClass();
        private clsAgent agentObject = new clsAgent();
        string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
        Hashtable htnew = new Hashtable();
        ErrLog objErr = new ErrLog();
        string strSapCode = string.Empty;
        SqlConnection objSQLConForTran = new SqlConnection();
        SqlTransaction objSQLTran = null;
        string agtcode = string.Empty;
        int BMaxImgSize1;//added by sanoj
        string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
        string strPhotoExt = string.Empty;
        private string strFileName1 = string.Empty;
        int BMaxImgSize;
        string strDocName = string.Empty;
        int intValue;
        string strProcessType;
        string DocStatusCount;
        private string strDestPath = string.Empty;
        string UnqRefNo = string.Empty;
        //Added by usha on 17.01.2021 for welcome letter 
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        Warning[] warnings;
        string[] streamIds;
        string strRpt = System.Configuration.ConfigurationManager.AppSettings["Report"].ToString();

        #endregion

        #region PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }
                #region Initialise values
                if (HttpContext.Current.Session["UserLangNum"] != "")
                {
                    strUserLang = Convert.ToString(HttpContext.Current.Session["UserLangNum"]).Trim();
                }
                olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", strUserLang);
                    }
                    else if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        olng = new multilingualManager("DefaultConn", "VendorInfo.aspx", strUserLang);
                    }
                }
                else
                {
                    olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
                }
                Session["CarrierCode"] = '2';
                string currdate;
                currdate = DateTime.Today.Date.ToShortDateString();
                #endregion
                #region IsPostBack
                if (!IsPostBack)
                {
txtDOB.Attributes.Add("Onblur", "Datedob();");
txtNomDob.Attributes.Add("Onblur", "DateNomDob();");
                    ViewState["Pan"] = "HOXPS132"; //added by sanoj 08072022
                    ViewState["Gst"] = "gst";
                    ViewState["Sig"] = "sig";
                    txtDOB.Attributes.Add("style", "background-color:white !important;");
                    PopulateRecruiterCode();
                    PopualtEducation();
                    ddlNomnRel.Items.Insert(0, new ListItem("-- Select --", ""));//ADDED BY AJAY 24-05-2022
                    oCommon.getDropDown(ddlNomnRel, "NBRelation", 1, "", 1, c_strBlank);// added by sanoj populate to Nominee relation
                    if (Request.QueryString["SapCode"] != null)
                    {
                        strSapCode = Request.QueryString["SapCode"].ToString().Trim();
                    }
                    InitializeControl();
                    ChkPARes.Attributes.Add("onclick", "funchkpaclick(this,'" + ChkPARes.Text.Trim() + "')");
                    ChkPABusns.Attributes.Add("onclick", "funchkpaclick(this,'" + ChkPABusns.Text + "')");
                    oCommon.getDropDown(cboQualCode, "NBEduQua", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    cboQualCode.Items.Insert(0, new ListItem("-- Select --", ""));
                    oCommon.getDropDown(cboOtherIDType, "NBSIDKey", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    cboOtherIDType.Items.Insert(0, new ListItem("-- Select --", ""));
                    //ddllvlagttype.Items.Insert(0, new ListItem("Independent", ""));

                    GridImage.Visible = true;
                    Sector();
                    ExpectedmonthlyBusiness();
                    if (Request.QueryString["AgnCd"] != null)
                    {
                        ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString();
                    }
                    else
                    {
                        ViewState["vwsAgntCode"] = "";
                        if (Request.QueryString["Type"].ToString() != "E")
                        {
                            txtRecruitDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                        }
                    }
                    if (Request.QueryString["Msg"] != null)
                    {
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                            {
                                if (Request.QueryString["Msg"] == "Employee created successfully." || Request.QueryString["Msg"] == "Record updated successfully.")
                                {
                                    lbl3.Text = "Employee created successfully.";
                                    lblMessage.Text = "Employee created successfully.";
                                    lbl4.Text = "Employee Name:-" + Request.QueryString["AgnName"].ToString().Trim();
                                    lbl5.Text = "Employee Code:-" + Request.QueryString["Agncd"].ToString().Trim();
                                    DataSet ds = new DataSet();
                                    ds.Clear();
                                    ds = GetPopDtls(Request.QueryString["Agncd"].ToString().Trim());
                                    if (ds.Tables.Count > 0)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            lbl6.Text = "Emp Code:-" + ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                                        }
                                    }
                                    mdlpopup.Show();
                                    lblMessage.ForeColor = Color.Red;
                                    btnUpdate.Enabled = false;
                                }
                            }
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                            {
                                if (Request.QueryString["Msg"] == "Vendor created successfully." || Request.QueryString["Msg"] == "Record updated successfully.")
                                {
                                    lbl3.Text = "Vendor created successfully.";
                                    lblMessage.Text = "Vendor created successfully.";
                                    lbl4.Text = "Vendor Name:-" + Request.QueryString["AgnName"].ToString().Trim();
                                    lbl5.Text = "Vendor Code:-" + Request.QueryString["Agncd"].ToString().Trim();
                                    mdlpopup.Show();
                                    lblMessage.ForeColor = Color.Red;
                                    btnUpdate.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (Request.QueryString["Msg"] == "Agent created successfully." || Request.QueryString["Msg"] == "Record updated successfully.")
                            {
                                lbl3.Text = "Agent created successfully.";
                                lblMessage.Text = "Agent created successfully.";
                                lbl4.Text = "Agent Name:-" + Request.QueryString["AgnName"].ToString().Trim();
                                lbl5.Text = "Agent Code:-" + Request.QueryString["Agncd"].ToString().Trim();
                                #region GetVenBrkDtls
                                DataSet ds = new DataSet();
                                ds.Clear();
                                ds = GetPopDtls(Request.QueryString["Agncd"].ToString().Trim());
                                if (ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        lbl6.Text = "Agent Broker Code:-" + ds.Tables[0].Rows[0]["InsMemCode"].ToString().Trim();
                                        if (Session["VenType"] != null)
                                        {
                                            if (Session["VenType"].ToString().Trim() == "DV")
                                            {
                                                ds.Clear();
                                                ds = GetPopDtls(Session["hdnVenCode"].ToString().Trim());
                                                if (ds.Tables.Count > 0)
                                                {
                                                    if (ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        lbl7.Text = "Vendor Code:-" + Session["hdnVenCode"].ToString().Trim() + "<br /><br />Vendor Name:-" + ds.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                mdlpopup.Show();
                                lblMessage.ForeColor = Color.Red;
                                btnUpdate.Enabled = false;
                                btnCreatIRC.Visible = true;
                            }
                        }

                        #region Gen Welcome Letter
                        string str_OrLdrCreateRul = "";
                        Hashtable htparam = new Hashtable();
                        htparam.Clear();
                        htparam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString());
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GenWelcomeLetter", htparam);
                        if (dtRead.Read())
                        {
                            str_OrLdrCreateRul = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        if (str_OrLdrCreateRul.Equals("1"))
                        {
                            if (ddlSlsChannel.SelectedValue == "CD")
                            {
                                btn_CDAWelcomeLetter.Enabled = true;
                            }
                            txtDTJoinFrom.Visible = true;
                            txtTemp.Visible = false;
                            txt_AppNo.Enabled = true;
                            txtTemp.Enabled = false;
                        }
                        else
                        {
                            txtDTJoinFrom.Visible = false;
                            txtTemp.Visible = true;
                            txt_AppNo.Enabled = false;
                            txtTemp.Enabled = false;
                        }
                        #endregion

                    }

                    #region FillDropDownLists
                    oCommon.getRadio(rdlExclusive, "cboyesno", Session["UserLangNum"].ToString(), "", 1);
                    oCommon.getDropDown(ddlPaymentMode, "PymtMode", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    oCommon.getDropDown(ddlAgntStatus, "AgtSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    oCommon.getDropDown(ddlCurrency, "Currency", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    oCommon.getDropDown(ddlPayFrequency, "PayFreq", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    oCommon.getDropDown(ddlCommCls, "CommCls", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    oCommon.getDropDown(ddlBlkLstStatus, "BlkLstSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    subPopulateGender();//To fill Gender dropdownlist
                    oCommon.getDropDown(cboTitle, "NBTitle", 1, "", 1, c_strBlank);//To fill Title dropdownlist
                    oCommon.getDropDown(ddlEcon, "Econ", 1, "", 1, c_strBlank);//To fill Economic Activity dropdownlist
                    oCommon.getDropDown(ddlSpecInd, "LFSpecInd", 1, "", 1, c_strBlank);//To fill Special Indicator dropdownlist
                    oCommon.getDropDown(ddlSOE, "SOE", 1, "", 1, c_strBlank);//To fill Special Indicator dropdownlist
                    oCommon.getDropDown(ddlCategory, "CasteCat", 1, "", 1);
                    ddlCategory.Items.Insert(0, "--Select--");//To fill Category dropdownlist
                    oCommon.getDropDown(cboMaritalStatus, "MarrySts", 1, "", 1);
                    cboMaritalStatus.Items.Insert(0, "--Select--");//To fill marital status dropdownlist
                    PopulateVendorTyp();//To fill Vendor Type dropdownlist
                    CnctType(true);
                    subPopulateAgnTitle();
                    ddlDeductTax.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlTaxCode.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlBlkLstStatus.Items.Insert(0, new ListItem("-- Select --", ""));
                    PopulateState(ddlState);
                    PopulateState(ddlState0);
                    PopulateState(ddlState1);
                    #endregion
                    #region Page_Load without postback for Agent modification
                    if (Request.QueryString["Type"].ToString() == "E")
                    {
                        if ((ddlSlsChannel.SelectedValue == "DA") && (ddlAgntType.SelectedValue == "CS"))
                        {
                            ddlCommCls.SelectedValue = "NOCM";
                        }
                        else if ((ddlSlsChannel.SelectedValue == "OL") && (ddlAgntType.SelectedValue == "OL"))
                        {
                            ddlCommCls.SelectedValue = "NOCM";
                        }
                        else if (ddlAgntType.SelectedValue == "TR" || ddlAgntType.SelectedValue == "ST" || ddlAgntType.SelectedValue == "TS")
                        {
                            ddlCommCls.SelectedValue = "NOCM";
                        }
                        else
                        {
                            ddlCommCls.SelectedValue = "0002";
                        }
                        trOldLic.Visible = true;
                        trOldStrtDt.Visible = true;

                        FillRequiredDataForPage1();
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                            {
                                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
                            }
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                            {
                                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other1.png";
                            }
                        }
                        else
                        {
                            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent1.png";
                        }
                        lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                        lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                        lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                        lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";
                        txtCusmId.ReadOnly = true;
                        ddlAgntStatus.Enabled = false;
                        lblCSCPrefix.Enabled = false;
                        txtMngrCode.Enabled = false;
                        btnMngrCodeSearch.Enabled = false;

                        #region Gen Welcome Letter
                        string str_OrLdrCreateRul = "";
                        Hashtable htparam = new Hashtable();
                        htparam.Clear();
                        htparam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString());
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GenWelcomeLetter", htparam);
                        if (dtRead.IsClosed)
                        {
                        }
                        if (dtRead.Read())
                        {
                            str_OrLdrCreateRul = dtRead[0].ToString();
                        }
                        if (str_OrLdrCreateRul.Equals("1"))
                        {
                            if (ddlSlsChannel.SelectedValue == "CD")
                            {
                                btn_CDAWelcomeLetter.Enabled = true;
                            }
                            txtDTJoinFrom.Visible = true;
                            txtTemp.Visible = false;
                            txtTemp.Enabled = false;
                            txt_AppNo.Enabled = true;
                        }
                        else
                        {
                            txtDTJoinFrom.Visible = false;
                            txtTemp.Visible = true;
                            txtTemp.Enabled = false;
                            txt_AppNo.Enabled = false;
                        }
                        if (ddlAgntType.SelectedValue == "RF")
                        {
                            lnkbtn_parentchild.Enabled = false;
                            tblUnitCodeDetails.Visible = false;
                        }
                        else
                        {
                            lnkbtn_parentchild.Enabled = true;
                        }
                        if (hdnCreateRule.Value == "BM" && ddlAgntType.SelectedValue == "AM")
                        {
                            btnAMLetter.Visible = true;
                            btn_CDAWelcomeLetter.Visible = false;
                            btnPDLetter.Visible = false;
                        }
                        else if (ddlAgntType.SelectedValue == "PD")
                        {
                            htparam.Clear();
                            htparam.Add("@AgentCode", txtAgtCode.Text.Trim());
                            htparam.Add("@AgentStatus", "IF");
                            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetCSCCode", htparam);
                            if (dtRead.Read())
                            {
                                htparam = new Hashtable();
                                htparam.Clear();
                                htparam.Add("@BizSrc", "PR");
                                htparam.Add("@AgentType", "ST");
                                htparam.Add("@CSCCode", dtRead["CSCCode"].ToString());
                                dtRead1 = dataAccess.Common_exec_reader_prc("Prc_GenPDWelcomeLetter", htparam);
                                if (dtRead1.Read())
                                {
                                    btnAMLetter.Visible = false;
                                    btn_CDAWelcomeLetter.Visible = false;
                                    btnPDLetter.Visible = true;
                                }
                            }
                            dtRead = null;
                            dtRead1 = null;
                        }
                        else
                        {
                            btnAMLetter.Visible = false;
                            btnPDLetter.Visible = false;
                            if (ddlSlsChannel.SelectedValue == "CD")
                            {
                                btn_CDAWelcomeLetter.Visible = true;
                            }
                        }

                        #endregion

                        ShowClient();
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                        lnkUploadPhoto.Visible = true;
                        ddlAgntType.Enabled = false;
                    }
                    #endregion
                    FillHiddenValues();
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnUpdate.Enabled = false;
                    }

                    foreach (ListItem lstItem in rdlExclusive.Items)
                    {
                        if (lstItem.Value == "Y")
                        {
                            rdlExclusive.SelectedValue = lstItem.Value;
                            break;
                        }
                    }

                    #region Page_Load without postback for Agent creation
                    if (Request.QueryString["Type"].ToString() == "N")
                    {
                        getWiz(); 
                        trcltcode.Visible = false;
                        tr2.Visible = false;
                        tr1.Visible = false;
                        btnUpdate.Text = "SUBMIT";
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                            {
                                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
                            }
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                            {
                                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other1.png";
                            }
                        }
                        else
                        {
                            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent1.png";
                        }
                        lnkPage2.Enabled = false;
                        lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                        lnkPage3.Enabled = false;
                        lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                        lnkPage4.Enabled = false;
                        lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                        lnkPage5.Enabled = false;
                        lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";
                        foreach (ListItem lstItem in ddlPaymentMode.Items)
                        {
                            if (lstItem.Value == "CH" || lstItem.Value == "CQ")
                            {
                                ddlPaymentMode.SelectedValue = lstItem.Value;
                                break;
                            }
                        }
                        ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                        foreach (ListItem lstItem in ddlAgntStatus.Items)
                        {
                            if (lstItem.Value == "PN")
                            {
                                ddlAgntStatus.SelectedValue = "IF";
                                break;
                            }
                        }

                        ddlAgntStatus.Enabled = false;
                        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                        btnCusmId.Enabled = true;
                        lblCSCPrefix.Enabled = false;

                        lnkbtn_parentchild.Visible = false;
                        lnkbtn_childparent.Visible = false;
                        ddlAgntType.Enabled = false;
                        ddlChnCls.Enabled = false;
                        ddlSlsChannel.Enabled = false;
                        tblReportingMngrDtls.Visible = false;
                        tblUnitCodeDetails.Visible = true;
                        lnkUploadPhoto.Visible = false;
                        cboagnTitle.Focus();

                        #region CndAgtMapping
                        if (Request.QueryString["lic"] != null)
                        {
                            if (Request.QueryString["lic"].ToString().Trim() == "LicCnd")
                            {
                                FillCndDtlsForAgent();
                            }
                        }
                        #endregion

                        #region CndAgtMappingAftrLicensing
                        if (Request.QueryString["cnd"] != null)
                        {
                            if (Request.QueryString["cnd"].ToString().Trim() == "CndCon")
                            {
                                GridCndImage.Visible = true;
                                GridImage.Visible = false;
                                Img.Visible = false;
                                FillCndDtlsTrfCase();
                            }
                        }
                        #endregion

                    }
                    #endregion

                    #region Page_Load without postback for Agent creation with map client
                    if (Request.QueryString["Type"].ToString() == "Clt")
                    {
                        txtCusmId.Text = Request.QueryString["CustID"].ToString().Trim();
                        txtCltCode.Text = Request.QueryString["CustID"].ToString().Trim();
                        ddlSlsChannel.Enabled = false;
                        tblReportingMngrDtls.Visible = false;
                        tblUnitCodeDetails.Visible = false;
                    }
                    else if (Request.QueryString["Type"].ToString() == "E")
                    {
                        //trcltcode.Visible = true;
                    }
                    else
                    {
                        //trcltcode.Visible = false;
                    }
                    #endregion

                    FillClientDtls();
                    if (Request.QueryString["Ctgry"] != null)
                    {
                        if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" || Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                        {
                            divlicdtls.Visible = false;
                        }
                    }
                    ddlLicTyp.Enabled = false;
                    cboagnTitle.Focus();
                    ///txtAgntName.Focus();
                    if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString().Trim() == "E")
                    {
                        //FillRequiredDataForPage1();//Comented by usha 28.12.2022
                        AutopopulatHierarchyDtls();     // Added by Rajkapoor Yadav on 20/01/22
                        tblReportingMngrDtls.Visible = true;
                        tblUnitCodeDetails.Visible = true;
                        //comented by sanoj
                        //lnkPage1.Visible = true;
                        //lnkPage2.Visible = true;
                        //lnkPage3.Visible = true;
                        //lnkPage4.Visible = true;
                        //lnkPage5.Visible = true;
                    }
                    if (Request.QueryString["Type"].ToString() == "N")
                    {
                        btnNextPannel3.Attributes.Add("OnClick", "javascript: return funValidate();");
                       // Bindgridview();//bind Document

                        Guid obj = Guid.NewGuid();
                        //Session["UnqRefNo"] = obj.ToString();
                        ViewState["UnqRefNo"] = obj.ToString();
                        //UnqRefNo = Code.ToString();
                        txtAgtCode.Text = ViewState["UnqRefNo"].ToString();
                        AutopopulatHierarchyDtls();     // Added by Rajkapoor Yadav on 20/01/22

                    }
                    if (Request.QueryString["Type"] == "CndStat") //added by sanoj aj 20-01-2022
                    {


                        GetDataMemBckgrndExp();
                        FillRequiredDataForPage1();
                        PreviewData();
                        DisabledContrl();
                        Bindgridview();
                       // AutopopulatHierarchyDtls();     // Added by Rajkapoor Yadav on 20/01/22
                        //Added by usha on 21.01.2021
                        tblReportingMngrDtls.Visible = true;
                        tblUnitCodeDetails.Visible = true;
                        //GetDataMemBckgrndExp();
                        _checkbox();
                        //FillRequiredDataForPage1();
                        //PreviewData();
                        //DisabledContrl();
                        //Bindgridview();
                        //AutopopulatHierarchyDtls();     // Added by Rajkapoor Yadav on 20/01/22
                        ////Added by usha on 21.01.2021
                        //tblReportingMngrDtls.Visible = true;
                        //tblUnitCodeDetails.Visible = true;
                        //GetDataMemBckgrndExp();
                        //Added by usha on 13_04_2023
                        btnUpdate.Visible = false;
                        btnPreviewBack.Visible = false;
                        divAnnivrsryDt.Visible = true;//added by usha on 20_04_2023
                        imageContent.Visible = false; //added by sanoj 18052023
                    }
                  //  FillAgentType(ddlSlsChannel.SelectedValue.ToString(), ddlChnCls.SelectedValue.ToString());
                }
                #endregion

                lblUntAddr.Text = hdnutadr.Value.ToString();

                #region Page_Load with postback for Agent creation
                if (Request.QueryString["Type"].ToString() == "N")
                {
                    txtBranchCode.Enabled = false;
                    txtBranchCode.Text = "10";
                    txtAreCode.Enabled = false;
                    txtAreCode.Text = "10";
                    txtUserId.Text = Convert.ToString(Session["UserId"].ToString());
                    //  AutopopulatHierarchyDtls();     // Added by Rajkapoor Yadav on 20/01/22

                }
                #endregion

                #region Page_Load with postback for Agent modification
                if (Request.QueryString["Type"].ToString() == "E")
                {
                    Img.Visible = false;
                    txtPanNo.Enabled = true;
                   // btnVerifyPAN.Enabled = false;  //commented by sanoj 16052023
                    ddlventype.Enabled = false;
                    //GetDataMemBckgrndExp();

                    //ddlventype1.Enabled = false;
                    //ddlventype2.Enabled = false;
                    //ddlventype3.Enabled = false;
                    //Added by usha on 21.01.2021

                    btnNextPannel3.Attributes.Add("OnClick", "javascript: return funValidate();");
                    //Comented by usha on 28.01.22

                    //FillClientDtls();

                    //ShowClient();

                    if (Request.QueryString["Ctgry"] != null)
                    {
                        //Comented by usha on 28.01.22
                        //if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                        //{
                        //    tblReportingMngrDtls.Visible = false;
                        //}
                        //else
                        //{
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                        // }
                    }
                    else
                    {
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                        FillDDlAgnVenRelMap();
                    }
                    // Added by sanoj sahani on 20/01/22
                    // AutopopulatHierarchyDtls();     // Added by sanoj sahani on 20/01/22
                    tblReportingMngrDtls.Visible = true;
                    tblUnitCodeDetails.Visible = true;

                }
                #endregion
                #region Popup button code
                btnImmLeaderCode.Attributes.Add("onclick", "funcShowPopup('ImmLeaderCode');return false;");//Added By Ibrahim on click of customer id Button New Pop Up will be Displayed on May 28, 2013 
                if (Request.QueryString["Ctgry"] != null)
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Emp','');return false;");
                }
                else
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Agent','');return false;");
                }
                btnCusmId.Attributes.Add("onclick", "funcShowPopup('custid');return false;");//Added By Ibrahim on click of customer id Button New Pop Up will be Displayed on May 28, 2013 
                lnkbtn_childparent.Attributes.Add("onclick", "funcShowPopupBAS('Agtcode1');return false;");// Added by Pranjali on 29/10/2013 for displaying popup on childparent link
                lnkbtn_parentchild.Attributes.Add("onclick", "funcShowPopupBAS('Agtcode');return false;");
                btnRecAgnCode.Attributes.Add("onclick", "funcShowPopup('ragtcode');return false;");
                btnAccPayee.Attributes.Add("onclick", "funcShowPopup('accntpay');return false;");

                //Added by swapnesh on 23/12/2013 to Add popup start

                btnCountryP.Attributes.Add("onclick", "funcShowPopup('country');return false;");
                btnCountryB.Attributes.Add("onclick", "funcShowPopup('countryB');return false;");
                btnPermCountry.Attributes.Add("onclick", "funcShowPopup('countryO');return false;");
                btnCountry.Attributes.Add("onclick", "funcShowPopup('country');return false;");
                btnNational.Attributes.Add("onclick", "funcShowPopup('national');return false;");
                btnOccupation.Attributes.Add("onclick", "funcShowPopup('occup');return false;");
                if (Request.QueryString["Ctgry"] != null)
                {
                    lnkUploadPhoto.Attributes.Add("onclick", "funcShowImgPopup('upimage','" + Request.QueryString["Ctgry"].ToString().Trim() + "');return false;");
                }
                else
                {
                    lnkUploadPhoto.Attributes.Add("onclick", "funcShowImgPopup('upimage','Agt');return false;");
                }
                //Added by swapnesh on 23/12/2013 to Add popup end

                btnStateSrch.Attributes.Add("onclick", "funcShowPopup('statedemo');return false;");//Present
                btnStateSrch0.Attributes.Add("onclick", "funcShowPopup('statedemo1');return false;");//permanent
                btnStateSrch1.Attributes.Add("onclick", "funcShowPopup('statedemo2');return false;");//business
                #endregion

                #region Adding attributes to controls
                //Added by swapnesh on 02/01/2014 to fill description on tab start
                txtStateCodeP.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                txtStateCodeP.ClientID + "').value, '" +
                txtStateDescP.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                txtStateCodeB.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                txtStateCodeB.ClientID + "').value, '" +
                txtStateDescB.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                txtStateCode.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                txtStateCode.ClientID + "').value, '" +
                txtStateDesc.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                //Added by swapnesh on 02/01/2014 to fill description on tab end

                //Added by swapnesh on 31/12/2013 for Pan Verification start
                btnVerifyPAN.Attributes.Add("onclick", "Javascript:return ValidationPAN();");
                //Added by swapnesh on 31/12/2013 for Pan Verification end

                lnbViewCntDetails.Attributes.Add("onclick", "funcShowPopup('contact');return false;");

                LnkMaptoVendor.Attributes.Add("onclick", "funcShowPopupMaptoVendor();return false;");

                lbtnAgnOrDetails.Attributes.Add("onClick", "javascript: return doEstimateOR();");
                btnNextPannel3.Attributes.Add("OnClick", "javascript: return funValidate();");

                btnTerminationLetter.Attributes.Add("onClick", "javascript: return Termination_Validate();");
                btn_CDAWelcomeLetter.Attributes.Add("onClick", "javascript: return funValidate_WelcomeLetter();");
                ClientScript.RegisterStartupScript(GetType(), "ReadonlyControls", "<Script Language=\"JavaScript\">funShowReadonly();</Script>");
                txtMngrCode.Attributes.Add("readonly", "readonly");
                txtRecruitAgntCode.Attributes.Add("readonly", "readonly");
                txtImmLeaderCode.Attributes.Add("readonly", "readonly");
                txtRecruitDate.Attributes.Add("readonly", "readonly");
                txtdoj.Attributes.Add("readonly", "readonly");
                //txtBankName.Attributes.Add("readonly", "readonly"); //Comnted by sanoj
                txtBnkBrnchName.Attributes.Add("readonly", "readonly");
                #endregion
                if (lbladditionalreportingrule.Text.Trim() != "")
                {
                    if (Request.QueryString["Ctgry"] != null)
                    {
                        if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                        {
                            funShowCrntMgr("empty");
                        }
                        else
                        {
                            funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                        }
                    }
                    else
                    {
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    }
                }

                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" || Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        divlicdtls.Visible = false;
                    }
                }
                btnAccPayee.Enabled = false;
                //txtRptMngr.Enabled = false;

                if (Request.QueryString["Type"].ToString() == "E")
                {
                    _checkbox();
                }
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

        #region InitializeControl
        private void InitializeControl()
        {
            try
            {
                lblPersonalPart.Text = "Personal Details";
                lvlVw1AgntCode.Text = "Member Code";
                lblVw1AgntStatus.Text = "Member Status";
                lblClCode.Text = "Emp Code";
                lblExclusive.Text = olng.GetItemDesc("lblExclusive.Text");
                lblPanNo.Text = olng.GetItemDesc("lblPanNo.Text");
                lblAgntName.Text = "Name";
                lblBusinessSrc.Text = "Channel";
                lblCntDetails.Text = olng.GetItemDesc("lblCntDetails.Text");
                lblChnCls.Text = olng.GetItemDesc("lblChnCls.Text");
                lblLicNo.Text = olng.GetItemDesc("lblLicNo.Text");
                lblVw1AgntType.Text = "Member Type"; 
                lblLicEexpDate.Text = olng.GetItemDesc("lblLicEexpDate.Text");
                lblAgntClass.Text = "Member Category";
                lblPayMethod.Text = olng.GetItemDesc("lblPayMethod.Text");
                Label2.Text = olng.GetItemDesc("Label2.Text");
                lblBankAccNo.Text = olng.GetItemDesc("lblBankAccNo.Text");
                lblBankAccHolderName.Text = "Account Holder Name";
                lblDeductTax.Text = olng.GetItemDesc("lblDeductTax.Text");
                lblTaxCode.Text = olng.GetItemDesc("lblTaxCode.Text");
                lblCommCls.Text = olng.GetItemDesc("lblCommCls.Text");
                lblPayFreq.Text = olng.GetItemDesc("lblPayFreq.Text");
                lblAccPayee.Text = olng.GetItemDesc("lblAccPayee.Text");
                lblMinAmt.Text = olng.GetItemDesc("lblMinAmt.Text");
                Label1.Text = olng.GetItemDesc("Label1.Text");
                lblRecruitDate.Text = olng.GetItemDesc("lblRecruitDate.Text");
                lblBranchCode.Text = olng.GetItemDesc("lblBranchCode.Text");
                Label3.Text = olng.GetItemDesc("Label3.Text");
                lblAraCde.Text = olng.GetItemDesc("lblAraCde.Text");
                lblMngrCode.Text = olng.GetItemDesc("lblMngrCode.Text");
                lblImmLeader.Text = olng.GetItemDesc("lblImmLeader.Text");
                lblCscCode.Text = olng.GetItemDesc("lblCscCode.Text");
                Label5.Text = olng.GetItemDesc("Label5.Text");
                lblEmpCode.Text = olng.GetItemDesc("lblEmpCode.Text");
                lblUntCde.Text = olng.GetItemDesc("lblUntCde.Text");
                lblDtTerminated.Text = olng.GetItemDesc("lblDtTerminated.Text");
                lblCompUntCde.Text = olng.GetItemDesc("lblCompUntCde.Text");
                lblBlkLstStatus.Text = olng.GetItemDesc("lblBlkLstStatus.Text");
                lblAgntPrefix.Text = olng.GetItemDesc("lblAgntPrefix.Text");
                lblHomeTel.Text = olng.GetItemDesc("lblHomeTel.Text");
                lblEmail.Text = olng.GetItemDesc("lblEmail.Text");
                lblPager.Text = olng.GetItemDesc("lblPager.Text");
                lblOfficeTel.Text = olng.GetItemDesc("lblOfficeTel.Text");
                lblMobileNo.Text = "Mobile No.1";
                lblFax.Text = olng.GetItemDesc("lblFax.Text");
                lblpfAddrP1.Text = "Address1";
                lblpfStateP.Text = olng.GetItemDesc("lblpfStateP.Text");
                lblDistP.Text = olng.GetItemDesc("lblDistP.Text");
                lblpfPinP.Text = olng.GetItemDesc("lblpfPinP.Text");
                lblVillage.Text = olng.GetItemDesc("lblVillage.Text");
                lblpfCountryP.Text = olng.GetItemDesc("lblpfCountryP.Text");
                lblpfAddrB1.Text = "Address1"; 
                lblpfStateB.Text = olng.GetItemDesc("lblpfStateP.Text");
                lblDistB.Text = olng.GetItemDesc("lblDistP.Text");
                lblpfPinB.Text = olng.GetItemDesc("lblpfPinP.Text");
                lblBvillage.Text = olng.GetItemDesc("lblVillage.Text");
                lblpfCountryB.Text = olng.GetItemDesc("lblpfCountryP.Text");
                lblpfPrmAddTitle.Text = olng.GetItemDesc("lblpfPrmAddTitle.Text");
                lblpfprmAdd1.Text = "Address1";
                lblpfprmstatecode.Text = olng.GetItemDesc("lblpfprmstatecode.Text");
                lblpfprmpostcode.Text = olng.GetItemDesc("lblpfprmpostcode.Text");
                lblpfprmcountry.Text = olng.GetItemDesc("lblpfprmcountry.Text");
                lblCode.Text = "SAP Code";
                lblCltChnl.Text = olng.GetItemDesc("lblCltChnl.Text");
                lbldob.Text = olng.GetItemDesc("lbldob.Text");
                lblspIndicator.Text = olng.GetItemDesc("lblspIndicator.Text");
                lblAltIDType.Text = olng.GetItemDesc("lblAltIDType.Text");
                lblMstatus.Text = olng.GetItemDesc("lblMstatus.Text");
                lblAltIDNo.Text = olng.GetItemDesc("lblAltIDNo.Text");
                lblSOE.Text = olng.GetItemDesc("lblSOE.Text");
                lblNationality.Text = olng.GetItemDesc("lblNationality.Text");
                lblCategory.Text = olng.GetItemDesc("lblCategory.Text");
                lblHigestQul.Text = olng.GetItemDesc("lblHigestQul.Text");
                lblSAPcode.Text = olng.GetItemDesc("lblSAPCode.Text");
                lblHeight.Text = olng.GetItemDesc("lblHeight.Text");
                lblOccup.Text = olng.GetItemDesc("lblOccup.Text");
                lblWeight.Text = olng.GetItemDesc("lblWeight.Text");
                lblAnnualIncome.Text = olng.GetItemDesc("lblAnnualIncome.Text");
                lblPreferedClient.Text = olng.GetItemDesc("lblPreferedClient.Text");
                lblStaff.Text = olng.GetItemDesc("lblStaff.Text");
                lblServiceTax.Text = olng.GetItemDesc("lblServiceTax.Text");
                lblRemark.Text = olng.GetItemDesc("lblRemark.Text");
                Label9.Text = olng.GetItemDesc("Label9.Text");
                Label10.Text = olng.GetItemDesc("Label10.Text");
                lblCapital.Text = olng.GetItemDesc("lblCapital.Text");
                lblStaffSz.Text = olng.GetItemDesc("lblStaffSz.Text");
                lblEmail2.Text = olng.GetItemDesc("lblEmail2.Text");
                lblMobile2.Text = olng.GetItemDesc("lblMobile2.Text");
                lblchnltype.Text = olng.GetItemDesc("lblchnltype.Text");
                lblchannel.Text = olng.GetItemDesc("lblchannel.Text");
                lblsubchannel.Text = olng.GetItemDesc("lblsubchannel.Text");
                lbllevelagttype.Text = "Reporting To";
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

        #region FillClientDtls
        public void FillClientDtls()
        {
            try
            {
                if (Request.QueryString["CustID"] != null)
                {
                    var cltid = Request.QueryString["CustID"].ToString().Trim();
                    dsResult.Clear();
                    htParam.Clear();
                    htParam.Add("@GCN", cltid);
                    htParam.Add("@Agtcode", txtAgtCode.Text.Trim());
                    dsResult = objDAL.GetDataSetForPrc("prc_GetClientDtlsforAgt", htParam);

                    var clttype = dsResult.Tables[0].Rows[0]["CltType"].ToString().Trim();

                    if (clttype == "A")
                    {
                        #region Personal Client
                        txtCusmId.Text = dsResult.Tables[0].Rows[0]["GCN"].ToString().Trim();
                        txtCltCode.Text = dsResult.Tables[0].Rows[0]["GCN"].ToString().Trim();
                        txtDOB.Text = dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString().Trim();
                        cboMaritalStatus.SelectedValue = dsResult.Tables[0].Rows[0]["MaritalStat"].ToString().Trim();
                        ddlSOE.SelectedValue = dsResult.Tables[0].Rows[0]["SOE"].ToString().Trim();
                        txtNationalCode.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString().Trim();
                        txtNationalDesc.Text = dsResult.Tables[0].Rows[0]["NationalityDesc"].ToString().Trim();
                        ddlCategory.SelectedValue = dsResult.Tables[0].Rows[0]["Category1"].ToString().Trim();
                        cboQualCode.SelectedValue = dsResult.Tables[0].Rows[0]["QualCode"].ToString().Trim();
                        txtSAPcode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                        txtOccupationCode.Text = dsResult.Tables[0].Rows[0]["OcpnCode01"].ToString().Trim();
                        txtOccupationDesc.Text = dsResult.Tables[0].Rows[0]["OcpnDesc"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["Staff"].ToString().Trim() == "N")
                        {
                            chkStaff.Checked = false;
                        }
                        else
                        {
                            chkStaff.Checked = true;
                        }
                        Menu1.Text = dsResult.Tables[0].Rows[0]["Remark"].ToString().Trim();
                        #endregion
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ShowCltDtls('P');", true);
                    }
                    else
                    {
                        #region Corporate Client
                        cboTitle.SelectedValue = dsResult.Tables[0].Rows[0]["AgnTitle"].ToString().Trim();
                        txtSurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString().Trim();
                        ddlEcon.SelectedValue = dsResult.Tables[0].Rows[0]["Econ"].ToString().Trim();
                        txtDOB1.Text = dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString().Trim();
                        txtBirthPlace.Text = dsResult.Tables[0].Rows[0]["BirthRegPlace"].ToString().Trim();
                        txtCountryCode.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString().Trim();
                        txtCountryDesc.Text = dsResult.Tables[0].Rows[0]["NationalityDesc"].ToString().Trim();

                        #endregion
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ShowCltDtls('C');", true);
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

            }
        }
        #endregion

        #region FUNCTION subPopulateGender
        private void subPopulateGender()
        {
            try
            {
                oCommon.getDropDown(ddlGender, "NBGender", 1, "", 1, c_strBlank);
                ddlGender.Items.Remove(ddlGender.Items.FindByValue("C"));
                ddlGender.Items.Remove(ddlGender.Items.FindByValue("U"));
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

        #region FUNCTION PopulateVendorTyp
        private void PopulateVendorTyp()
        {
            try
            {
                oCommon.getDropDown(ddlventype, "ventype", 1, "", 1, c_strBlank);
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

        #region subPopulateAgnTitle
        private void subPopulateAgnTitle()
        {
            try
            {
                cboagnTitle.Items.Clear();
                dscbotitle.SelectCommand = "Prc_GetMemTitle";
                cboagnTitle.DataBind();
                cboagnTitle.Items.Insert(0, new ListItem("Select", "none"));
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

        #region FUNCTION CnctType
        private void CnctType(Boolean blnNew)
        {
            try
            {
                ListItem[] items = new ListItem[1];
                string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();
                ddlCnctType.Items.Clear();
                // Added by Pranjali on 28-06-2013 for Candidate Address Type
                dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper() + "'";  // Added by Pranjali on 28-06-2013 for Candidate Address Type of B1 and P1
                // Added by Pranjali on 28-06-2013 for Candidate Address Type end
                ddlCnctType.DataBind();
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

        #region METHOD 'FillHiddenValues()' DEFINITION
        protected void FillHiddenValues()
        {
            try
            {

                hdnID210.Value = "Please enter Recruit Agent Code.";
                hdnID220.Value = "Recruit Agent Code is 8 characters length.";
                hdnID240.Value = "Please select Agent Type.";
                hdnID250.Value = "Please select Business Source.";
                hdnID260.Value = "Please select Channel Sub Class.";
                hdnID280.Value = "Recruit Agent Code cannot same as Agent Code.";
                hdnID290.Value = "Please enter valid Recruit Agent Code.";
                hdnID360.Value = "Graduation Date cannot be greater than today's date.";
                hdnID480.Value = "Please enter Unit Code.";
                hdnID490.Value = "Please enter Branch Office Code.";
                hdnID500.Value = "Please enter valid GA Office/Branch Office Code.";

                hdnID600.Value = "Please enter Direct Agent Leader Code!";
                hdnID270.Value = "Please enter Unit Code.";
                hdnID300.Value = "Please enter Branch Office Code.";
                hdnID310.Value = "Please enter valid GA Office/Branch Office Code.";
                hdnID320.Value = "Direct Agent Code cannot same as Agent Code";
                hdnID530.Value = "Please enter valid Direct Agent Code";
                hdnID650.Value = "Please enter Manager Code!";
                hdnID660.Value = "Please select CSC Prefix";

                ///added by akshay on 03/01/2014 start
                hdnHomeTel.Value = "Please Enter Home Tel No.";
                hdnMobTel.Value = "Please Enter Mobile Tel No.";
                hdnmarsts.Value = "Please enter Marital Status";
                hdnemail1.Value = "Please enter Email Address";
                hdnCltDOB.Value = "Please enter Date of Birth";
                hdnTitle.Value = "Please Enter Company Title";
                hdnName.Value = "Please Enter Company Name";
                hdnCapital.Value = "Please Enter Capital";

                hdnResAddr.Value = "Please Enter Present Address1";
                hdnStateP.Value = "Please Enter Present State";
                hdnDistrP.Value = "Please Enter Present District";
                hdnPinP.Value = "Please Enter Present PinCode";
                hdnCntryCP.Value = "Please Enter Present Country";

                hdnPermAddr.Value = "Please Enter Permanent Address";
                hdnStatePrm.Value = "Please Enter Permanent State";
                hdnPinPrm.Value = "Please Enter Permanent PinCode";
                hdnCntryCPrm.Value = "Please Enter Permanent Country";

                ///added by akshay on 03/01/2014 end

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

        #region METHOD 'FillRequiredDataForPage1()' DEFINITION
        protected void FillRequiredDataForPage1()
        {
            btnReGenerateLetter.Visible = false;
            dsResult = new DataSet();
            htParam.Clear();
            oCommon.getDropDown(ddlAgntStatus, "AgtSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommonU.GetSalesChannel(ddlSlsChannel, "", 0);
            ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddllvlagttype.Items.Insert(0, new ListItem("Independent", ""));
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].ToString() == "N")
                {
                    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlSlsChannel.Enabled = true;
                    ddlAgntType.Enabled = true;
                    ddlChnCls.Enabled = true;

                }
                else if (Request.QueryString["Type"].ToString() == "E")
                {
                    ddlSlsChannel.Enabled = false;
                    ddlAgntType.Enabled = false;
                    ddlChnCls.Enabled = false;
                    btnCusmId.Enabled = false;
                    txtPartnerName.ReadOnly = true;
                    txtPartnerCode.ReadOnly = true;
                }
            }
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            try
            {
                dsResult = dataAccess.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows[0]["ChnlType"].ToString().Trim() == "True")
                        {
                            rdbChnlTyp.SelectedValue = "1";
                        }
                        else
                        {
                            rdbChnlTyp.SelectedValue = "0";
                        }
                        oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
                        ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                        txtAgtCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"].ToString().Trim());

                        txtempcode1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim());//added by sanoj 27-01-2022
                        txtCusmId.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GCN"].ToString().Trim());//added by sanoj 27-01-2022
                        txtCltCode.Enabled = false;
                        txtCltCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SAPCODE"].ToString().Trim());
                        txtSapCode1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SAPCODE"].ToString().Trim()); //added by sanoj 27-01-2022
                        
                        
                        var gender = dsResult.Tables[0].Rows[0]["Gender"].ToString().Trim();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "setGender('"+gender+"');", true);

                      
                        txtPanNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PANNo"].ToString().Trim());
                        txtBankAccNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankAccountCode"].ToString().Trim());
                        txtBankHolderName.Text = oCommonU.ReadStr1(Convert.ToString(dsResult.Tables[0].Rows[0]["BankAcntName"]).Trim());
                        txtNeftCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NeftCode"].ToString().Trim());
                        txtBankName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankCode"].ToString().Trim());
                        txtBnkBrnchName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankBranchCode"].ToString().Trim());

                        hdnBrkCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["InsMemCode"].ToString().Trim());
                        txtBankAccNo.Enabled = true;
                        txtBankHolderName.Enabled = true;
                        //added by sanoj 19-01-2022
                        txtFbId.Text = dsResult.Tables[0].Rows[0]["FacebookId"].ToString().Trim();
                        txtTwt.Text = dsResult.Tables[0].Rows[0]["TwiterId"].ToString().Trim();
                        txtInstId.Text = dsResult.Tables[0].Rows[0]["InstagramId"].ToString().Trim();
                        TxtAnnivrsryDt.Text = dsResult.Tables[0].Rows[0]["AnniversaryDate"].ToString().Trim();
                        ddlEducutn.SelectedValue = dsResult.Tables[0].Rows[0]["EducationLevel"].ToString().Trim();
                       // txtExpt.Text = dsResult.Tables[0].Rows[0]["ExpMonBusnsHealth"].ToString().Trim();
                        txtExpt1.SelectedValue = dsResult.Tables[0].Rows[0]["ExpMonBusnsHealth"].ToString().Trim();//Added by ajay 18-04-2023
                        txtExpectTm.Text = dsResult.Tables[0].Rows[0]["ExpTeamStrgt"].ToString().Trim();
                        txtAgntMonth.Text = dsResult.Tables[0].Rows[0]["ExpAgntInSixMnth"].ToString().Trim();
                        txtAgntMonth12.Text = dsResult.Tables[0].Rows[0]["ExpAgntInTwelveMnth"].ToString().Trim();
                        txtPosp6.Text = dsResult.Tables[0].Rows[0]["ExpPOSPInSixMnth"].ToString().Trim();
                        txtPosp12.Text = dsResult.Tables[0].Rows[0]["ExpPOSPInTwelveMnth"].ToString().Trim();
                        txtDtlsExtBus.Text = dsResult.Tables[0].Rows[0]["DtlsOfOthrbusiness"].ToString().Trim();
                        txtmrktBus.Text = dsResult.Tables[0].Rows[0]["MrktingInFinservicebusiness"].ToString().Trim();
                        txtSrcProvd.Text = dsResult.Tables[0].Rows[0]["DtlsOfLawSuit"].ToString().Trim();
                        txtAsnmnet.Text = dsResult.Tables[0].Rows[0]["DtlsOfOthrAssignmt"].ToString().Trim();
                        txtRemark.Text = dsResult.Tables[0].Rows[0]["Remark"].ToString().Trim();
                        txtBnkAddress.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Branch Name"].ToString().Trim());
                        txtNeftCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IFSC Code"].ToString().Trim());
                        txtmcrcode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MICR Code"].ToString().Trim());
                        ddlactype.SelectedValue = dsResult.Tables[0].Rows[0]["BankAcntType"].ToString().Trim();
                        txtNomNme.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NomineeName"].ToString().Trim());
                        txtNomDob.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NomineeDOB"].ToString().Trim());
                        txtNomMob.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NomineeMobileTel"].ToString().Trim());
                        txtNomEmail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NomineeEmailID"].ToString().Trim());
                        ddlNomnRel.SelectedValue = dsResult.Tables[0].Rows[0]["NomineeRel"].ToString().Trim();
                        //Added by ajay 18-01-2022
                        if (Request.QueryString["Type"] == "CndStat")
                        {
                            txtBankAccNo.Enabled = false;
                        }
                        else
                        {
                            txtBankAccNo.Enabled = true;
                        }
                        if (Request.QueryString["Type"] == "CndStat")
                        {
                            txtBankHolderName.Enabled = false;
                        }
                        else
                        {
                            txtBankHolderName.Enabled = true;
                        }

                        //ended by sanoj



                        if (dsResult.Tables[0].Rows[0]["DateOfJoining"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["DateOfJoining"]).Trim() != "")
                            {
                                txtdoj.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["DateOfJoining"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldLicenseStrtDate"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseStrtDate"]).Trim() != "")
                            {
                                txtBizOldLicStrtDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseStrtDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldLicenseEndDate"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseEndDate"]).Trim() != "")
                            {
                                txtBizOldLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseEndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldLicenseNo"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseNo"]).Trim() != "")
                            {
                                txtBizOldLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldLicenseNo"]).Trim();
                            }
                        }

                        if (dsResult.Tables[0].Rows[0]["MemStatus"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemStatus"]).Trim() != "")
                            {
                                ddlAgntStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MemStatus"]).Trim();
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {
                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            }
                        }
                        ddlChnCls.Items.Clear();
                        SqlDataReader dtRead;
                        //Added by Pranjali on 01-07-2013 for Channel sub class dropdown start
                        Hashtable htparam = new Hashtable();
                        htparam.Clear();
                        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
                        //Added by Pranjali on 01-07-2013 for Channel sub class dropdown end
                        if (dtRead.HasRows)
                        {
                            ddlChnCls.DataSource = dtRead;
                            ddlChnCls.DataTextField = "ChnlDesc";
                            ddlChnCls.DataValueField = "ChnCls";
                            ddlChnCls.DataBind();
                        }
                        dtRead = null;
                        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                foreach (ListItem lstItem in ddlChnCls.Items)
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() == lstItem.Value)
                                    {
                                        ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                                        break;
                                    }
                                }
                            }
                        }


                        //Added by Pranjali on 02-07-2013 for getting agent Type on Channel sub class dropdownlist start

                        htparam.Clear();
                        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                        htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetAgnTypedesc", htparam);
                        //Added by Pranjali on 02-07-2013 for getting agent Type on Channel sub class dropdownlist end
                        if (dtRead.HasRows)
                        {
                            ddlAgntType.DataSource = dtRead;
                            ddlAgntType.DataTextField = "AgnDesc";
                            ddlAgntType.DataValueField = "MemType";
                            ddlAgntType.DataBind();
                        }
                        dtRead = null;
                        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                        if (dsResult.Tables[0].Rows[0]["MemType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim() != "")
                            {
                                foreach (ListItem lstItem in ddlAgntType.Items)
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim() == lstItem.Value)
                                    {
                                        //To allow change in agenttype
                                        if (ddlAgntStatus.SelectedValue == "IF")
                                        {

                                            //To allow change in all agenttype

                                            DataSet dsAgentType;
                                            ddlAgntType.Items.Clear();
                                            //Added by Pranjali on 02-07-2013 for getting agent Type on Channel sub class dropdownlist start
                                            htparam = new Hashtable();
                                            htparam.Clear();
                                            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                            htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                                            htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
                                            dsAgentType = dataAccess.GetDataSetForPrc("Prc_GetAgnTypedesc", htparam);
                                            //Added by Pranjali on 02-07-2013 for getting agent Type on Channel sub class dropdownlist end
                                            if (dsAgentType.Tables.Count > 0)
                                            {
                                                if (dsAgentType.Tables[0].Rows.Count > 0)
                                                {
                                                    ddlAgntType.DataSource = dsAgentType.Tables[0];
                                                    ddlAgntType.DataTextField = "AgnDesc";//Chenges by usha on 13_04_2023
                                                    ddlAgntType.DataValueField = "MemType";
                                                    ddlAgntType.DataBind();
                                                    ddlAgntType.Enabled = true;
                                                }
                                                dsAgentType = null;
                                            }
                                        }
                                        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                                        ddlAgntType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim();
                                        break;
                                    }
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["MemClass"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemClass"]).Trim() != "")
                            {
                                //ddlAgntClass.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["AgtClass"]).Trim();
                            }
                        }
                        txtAgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                        cboagnTitle.SelectedValue = dsResult.Tables[0].Rows[0]["AgnTitle"].ToString().Trim();
                        txtBizLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LicenseNo"]);
                        if (dsResult.Tables[0].Rows[0]["LicenseEndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["LicenseEndDate"].ToString().Trim() != "")
                            {
                                txtBizLicEndDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LicenseEndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtBizLicEndDt.Text = "";
                        }
                        string strParamNote = "";
                        //Added by Pranjali on 02-07-2013 for Retrieving paramNote start
                        htparam = new Hashtable();
                        htparam.Add("@LookupCode", "taxcode");
                        htparam.Add("@ParamValue", ddlAgntType.SelectedValue.Trim());
                        dtRead = dataAccess.exec_reader_prc_inscdirect("Prc_GetParamNote", htparam);
                        //Added by Pranjali on 02-07-2013 for Retrieving paramNote for matched account name end
                        if (dtRead.Read())
                        {
                            strParamNote = dtRead["ParamNote"].ToString();
                        }
                        dtRead = null;
                        ddlDeductTax.Items.Clear();
                        //Added by Pranjali on 02-07-2013 for Getting filled dropdown of Deduct Tax start 
                        htparam = new Hashtable();
                        htparam.Add("@LookupCode", "DeductTax");
                        htparam.Add("@ParamValue", strParamNote);
                        htparam.Add("@flag", 1);
                        dtRead = dataAccess.exec_reader_prc_inscdirect("Prc_Getparamvalueanddesc", htparam);
                        //Added by Pranjali on 02-07-2013 for Getting filled dropdown of Deduct Tax end
                        if (dtRead.HasRows)
                        {
                            ddlDeductTax.DataSource = dtRead;
                            ddlDeductTax.DataTextField = "ParamDesc";
                            ddlDeductTax.DataValueField = "ParamValue";
                            ddlDeductTax.DataBind();
                        }
                        else
                        {
                            ddlDeductTax.Items.Insert(0, new ListItem("-- Select --", ""));
                        }
                        dtRead = null;
                        ddlTaxCode.Items.Clear();
                        //Added by Pranjali on 02-07-2013 for Getting filled dropdown of Tax Code start 
                        htparam = new Hashtable();
                        htparam.Add("@LookupCode", "TaxCode");
                        htparam.Add("@ParamValue", ddlAgntType.SelectedValue.Trim());
                        htparam.Add("@flag", 1);
                        dtRead = dataAccess.exec_reader_prc_inscdirect("Prc_Getparamvalueanddesc", htparam);
                        //Added by Pranjali on 02-07-2013 for Getting filled dropdown of Tax Code end
                        if (dtRead.HasRows)
                        {
                            ddlTaxCode.DataSource = dtRead;
                            ddlTaxCode.DataTextField = "ParamDesc";
                            ddlTaxCode.DataValueField = "ParamValue";
                            ddlTaxCode.DataBind();
                        }
                        else
                        {
                            ddlTaxCode.Items.Insert(0, new ListItem("-- Select --", ""));
                        }
                        dtRead = null;
                        //Added by Pranjali on 02-07-2013 for fetching data from chnAgnSu start
                        htparam.Clear();
                        htparam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                        htparam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                        htparam.Add("@flag", 3);
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", htparam);
                        //Added by Pranjali on 02-07-2013 for fetching data from chnAgnSu end
                        if (dtRead.Read())
                        {
                            hdnCreateRule.Value = dtRead["MemCreateRul"].ToString();
                        }
                        dtRead.Close();

                    }

                    PopulateConstityp();
                    ddlLicTyp.SelectedValue = dsResult.Tables[0].Rows[0]["ConstCode"].ToString().Trim();
                    //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details start 
                    FillReportingMngrDtls();
                    //txtRptMgr.Text = dsResult.Tables[0].Rows[0]["MgrName"].ToString().Trim() + "(" + dsResult.Tables[0].Rows[0]["MgrSapCode"].ToString().Trim() + ")";
                    //hdnRptMgr.Value = dsResult.Tables[0].Rows[0]["MgrCode"].ToString().Trim();
                    //lblrptmgr.Text = dsResult.Tables[0].Rows[0]["MgrCode"].ToString().Trim();

                    //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details end

                    //Added by swapnesh on 01/02/2014 to fill Reporting/Manager Details start
                    //lblUnitDesc.Text = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    //string unt = dsResult.Tables[0].Rows[0]["Unt"].ToString().Trim();
                    //string untcms = dsResult.Tables[0].Rows[0]["UntCms"].ToString().Trim();
                    //txtUntCode.Text = untcms.ToString().Trim() + "(" + unt.ToString().Trim() + ")";
                    //hdnUntCode.Value = lblUnitDesc.Text.Trim();
                    //Modified: Parag
                    //lblUntAddr.Text = dsResult.Tables[0].Rows[0]["untadr"].ToString().Trim().Replace("~", "");
                    //hdnutadr.Value = lblUntAddr.Text;
                    DataSet ds = new DataSet();
                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@MemCode", txtAgtCode.Text);
                    ds = objDAL.GetDataSetForPrcCLP("Prc_GetUntCodes", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = ds.Tables[0];
                        gvUntLst.DataBind();
                        Session["unt"] = ds;
                    }

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@MemCode", txtAgtCode.Text);
                    ds = objDAL.GetDataSetForPrcCLP("Prc_GetRptMemCodes", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds.Tables[0];
                        gv.DataBind();
                        Session["mem"] = ds;
                    }

                    for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
                    {

                        GridView gvAddlMgr = gv_RptMngr.Rows[i].FindControl("gvAddlMgr") as GridView;

                        htParam.Clear();
                        ds.Clear();
                        int I = 1;
                        htParam.Add("@MemCode", txtAgtCode.Text);
                        //htParam.Add("@RelOrder", i + 1);
                        htParam.Add("@RelOrder", Convert.ToString(I + 1));
                        ds = objDAL.GetDataSetForPrcCLP("Prc_GetAddlRptMemCodes", htParam);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            gvAddlMgr.DataSource = ds.Tables[0];
                            gvAddlMgr.DataBind();
                            Session["addlmem"] = ds;
                        }
                    }
                    txtUntCode.Enabled = false;///080714
                    btnUnitCode.Enabled = false;
                    //Added by swapnesh on 01/02/2014 to fill Reporting/Manager Details end

                    //Added by swapnesh on 26/12/2013 to fill Address and Client Details start

                    #region Fill Address Details
                    ddlCnctType.SelectedValue = dsResult.Tables[0].Rows[0]["DefCnctType"].ToString().Trim();
                    if (ddlCnctType.SelectedValue == "P1")
                    {
                        ChkPARes.Checked = true;
                        ChkPABusns.Checked = false;
                    }
                    txtAddrP1.Text = dsResult.Tables[0].Rows[0]["crAddressLine1"].ToString().Trim();
                    txtAddrP2.Text = dsResult.Tables[0].Rows[0]["crAddressLine2"].ToString().Trim();
                    txtAddrP3.Text = dsResult.Tables[0].Rows[0]["crAddressLine3"].ToString().Trim();
                    ddlState.SelectedValue = dsResult.Tables[0].Rows[0]["crStateCode"].ToString().Trim();
                    txtVillage.Text = dsResult.Tables[0].Rows[0]["crVillage"].ToString().Trim();
                    txtarea.Text = dsResult.Tables[0].Rows[0]["crArea"].ToString().Trim();
                    txtcity.Text = dsResult.Tables[0].Rows[0]["crCity"].ToString().Trim();
                    txtDistP.Text = dsResult.Tables[0].Rows[0]["crDistrict"].ToString().Trim();
                    txtPinP.Text = dsResult.Tables[0].Rows[0]["crPostCode"].ToString().Trim();
                    txtCountryCodeP.Text = dsResult.Tables[0].Rows[0]["crCntryCode"].ToString().Trim();
                    txtCountryDescP.Text = dsResult.Tables[0].Rows[0]["crCountry"].ToString().Trim();

                    if (ddlCnctType.SelectedValue == "B1")
                    {
                        ChkPARes.Checked = false;
                        ChkPABusns.Checked = true;
                    }

                    txtAddrB1.Text = dsResult.Tables[0].Rows[0]["BAddressLine1"].ToString().Trim();
                    txtAddrB2.Text = dsResult.Tables[0].Rows[0]["BAddressLine2"].ToString().Trim();
                    txtAddrB3.Text = dsResult.Tables[0].Rows[0]["BAddressLine3"].ToString().Trim();
                    ddlState0.SelectedValue = dsResult.Tables[0].Rows[0]["BStateCode"].ToString().Trim();
                    txtBvillage.Text = dsResult.Tables[0].Rows[0]["BVillage"].ToString().Trim();
                    txtarea0.Text = dsResult.Tables[0].Rows[0]["BArea"].ToString().Trim();
                    txtcity0.Text = dsResult.Tables[0].Rows[0]["BArea"].ToString().Trim();
                    txtDistB.Text = dsResult.Tables[0].Rows[0]["BDistrict"].ToString().Trim();
                    txtPinB.Text = dsResult.Tables[0].Rows[0]["BPostCode"].ToString().Trim();
                    txtCountryCodeB.Text = dsResult.Tables[0].Rows[0]["BCntryCode"].ToString().Trim();
                    txtCountryDescB.Text = dsResult.Tables[0].Rows[0]["BCountry"].ToString().Trim();

                    txtPermAdd1.Text = dsResult.Tables[0].Rows[0]["idAddressLine1"].ToString().Trim();
                    txtPermAdd2.Text = dsResult.Tables[0].Rows[0]["idAddressLine2"].ToString().Trim();
                    txtPermAdd3.Text = dsResult.Tables[0].Rows[0]["idAddressLine3"].ToString().Trim();
                    ddlState1.SelectedValue = dsResult.Tables[0].Rows[0]["idStateCode"].ToString().Trim();
                    txtPermVillage.Text = dsResult.Tables[0].Rows[0]["idVillage"].ToString().Trim();
                    txtarea1.Text = dsResult.Tables[0].Rows[0]["idArea"].ToString().Trim();
                    txtcity1.Text = dsResult.Tables[0].Rows[0]["idCity"].ToString().Trim();
                    txtDistric.Text = dsResult.Tables[0].Rows[0]["idDistrict"].ToString().Trim();
                    txtPermPostcode.Text = dsResult.Tables[0].Rows[0]["idPostCode"].ToString().Trim();
                    txtPermCountryCode.Text = dsResult.Tables[0].Rows[0]["idCntryCode"].ToString().Trim();
                    txtPermCountryDesc.Text = dsResult.Tables[0].Rows[0]["idCountry"].ToString().Trim();
                    #endregion
                    #region Personal Client Details
                    txtDOB.Text = dsResult.Tables[0].Rows[0]["BirthDate"].ToString().Trim();
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStatus"]).Trim() != "")
                    {
                        cboMaritalStatus.SelectedValue = dsResult.Tables[0].Rows[0]["MaritalStatus"].ToString().Trim();
                        // Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim();
                    }
                    //cboMaritalStatus.SelectedValue = dsResult.Tables[0].Rows[0]["MaritalStatus"].ToString().Trim();//Comented by usha on 28.01.2022
                    ddlSOE.SelectedValue = dsResult.Tables[0].Rows[0]["SOE"].ToString().Trim();
                    txtNationalCode.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString().Trim();
                    txtNationalDesc.Text = dsResult.Tables[0].Rows[0]["NationalityDsc"].ToString().Trim();
                    cboQualCode.SelectedValue = dsResult.Tables[0].Rows[0]["QualCode"].ToString().Trim();
                    txtSAPcode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                    txtHeight1.Text = dsResult.Tables[0].Rows[0]["Height"].ToString().Trim();
                    txtWeight.Text = dsResult.Tables[0].Rows[0]["Weight"].ToString().Trim();
                    txtALIncome.Text = dsResult.Tables[0].Rows[0]["Income"].ToString().Trim();
                    cboOtherIDType.SelectedValue = dsResult.Tables[0].Rows[0]["CurrentIDType"].ToString().Trim();
                    txtOthersID.Text = dsResult.Tables[0].Rows[0]["CurrentID"].ToString().Trim();
                    Menu1.Text = dsResult.Tables[0].Rows[0]["Remarks"].ToString().Trim();
                    txtOccupationCode.Text = dsResult.Tables[0].Rows[0]["OccupationCode"].ToString().Trim();
                    txtOccupationDesc.Text = dsResult.Tables[0].Rows[0]["OccupationDesc"].ToString().Trim();
                    //ddlCategory.SelectedValue = dsResult.Tables[0].Rows[0]["Category"].ToString().Trim();//Comented by usha on 28.01.2022

                    if (Request.QueryString["Type"] == "E")
                    {
                        cboMaritalStatus_SelectedIndexChanged(null, null);
                        cboagnTitle_SelectedIndexChanged(null, null);
                        ViewState["Pan"] = txtPanNo.Text.ToString().Trim();
                        btnVerifyPAN_Click(null, null);
                        ddlAgntType.Enabled = false;
                        ddlLicTyp.Enabled = false;
                    }
                    //added by ajay for pan 17042023 end
                    if (dsResult.Tables[0].Rows[0]["PrfStat"].ToString().Trim() == "0")
                    {
                        chkprefclt.Checked = false;
                    }
                    else
                    {
                        chkprefclt.Checked = true;
                    }
                    if (dsResult.Tables[0].Rows[0]["Staff"].ToString().Trim() == "N")
                    {
                        chkStaff.Checked = false;
                    }
                    else
                    {
                        chkStaff.Checked = true;
                    }
                    if (dsResult.Tables[0].Rows[0]["TaxStat"].ToString().Trim() == "N")
                    {
                        CheckBox2.Checked = false;
                    }
                    else
                    {
                        CheckBox2.Checked = true;
                    }
                    #endregion
                    #region Corporate Client Details
                    cboTitle.SelectedValue = dsResult.Tables[0].Rows[0]["AgnTitle"].ToString().Trim();
                    txtSurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString().Trim();
                    txtCurrentID.Text = dsResult.Tables[0].Rows[0]["CurrentId"].ToString().Trim();
                    ddlEcon.SelectedValue = dsResult.Tables[0].Rows[0]["Econ"].ToString().Trim();
                    txtDOB1.Text = dsResult.Tables[0].Rows[0]["BirthDate"].ToString().Trim();
                    txtBirthPlace.Text = dsResult.Tables[0].Rows[0]["BirthPlace"].ToString().Trim();
                    txtCapital.Text = dsResult.Tables[0].Rows[0]["FinYrDayMn"].ToString().Trim();
                    txtStaffSz.Text = dsResult.Tables[0].Rows[0]["StaffSize"].ToString().Trim();
                    txtAnnTurnover.Text = dsResult.Tables[0].Rows[0]["AnnTurnover"].ToString().Trim();
                    if (dsResult.Tables[0].Rows[0]["PrfStat"].ToString().Trim() == "0")
                    {
                        chkVip.Checked = false;
                    }
                    else
                    {
                        chkVip.Checked = true;
                    }
                    if (dsResult.Tables[0].Rows[0]["TaxStat"].ToString().Trim() == "N")
                    {
                        chkSalesTax.Checked = false;
                    }
                    else
                    {
                        chkSalesTax.Checked = true;
                    }

                    #endregion
                    #region Client Contact Details
                    txtHomeTel.Text = dsResult.Tables[0].Rows[0]["Tel1"].ToString().Trim();
                    txtWorkTel.Text = dsResult.Tables[0].Rows[0]["Tel4"].ToString().Trim();
                    txtEmail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                    txtMobileTel.Text = dsResult.Tables[0].Rows[0]["Tel2"].ToString().Trim();
                    txtPager.Text = dsResult.Tables[0].Rows[0]["Tel5"].ToString().Trim();
                    txtFax.Text = dsResult.Tables[0].Rows[0]["Tel3"].ToString().Trim();
                    txtEmail2.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString().Trim();
                    txtMobileTel2.Text = dsResult.Tables[0].Rows[0]["MobileTel2"].ToString().Trim();

                    #endregion

                    //Added by swapnesh on 26/12/2013 to fill Address and Client Details end

                    DataSet dsImg = BindGrid();
                    GridImage.DataSource = dsImg;
                    GridImage.DataBind();

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            dsResult.Clear();
            dsResult = null;
            htParam.Clear();
            htParam = null;
        }
        #endregion

        #region LINKBUTTON 'lnkPage1' ONCLICK EVENT
        protected void lnkPage1_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.LightYellow;
                lnkPage2.BackColor = Color.Transparent;
                lnkPage3.BackColor = Color.Transparent;
                lnkPage4.BackColor = Color.Transparent;
                lnkPage5.BackColor = Color.Transparent;
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other1.png";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent1.png";
                }
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";



                FillHiddenValues();
                btnUpdate.Visible = true;
                //For PRVFlag
                btnUpdate.Text = "Update";
                btnTerminationLetter.Visible = false;
                btnReGenerateLetter.Visible = false;
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details start 
                FillReportingMngrDtls();
                ////ChkMandMgr();
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details end
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" || Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        FillClientDtls();
                        divlicdtls.Visible = false;
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region LINKBUTTON 'lnkPage2' ONCLICK EVENT
        protected void lnkPage2_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.Transparent;
                lnkPage2.BackColor = Color.LightYellow;
                lnkPage3.BackColor = Color.Transparent;
                lnkPage4.BackColor = Color.Transparent;
                lnkPage5.BackColor = Color.Transparent;
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                }
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education1.png";
                lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";
                btnUpdate.Enabled = false;
                FillHiddenValues();
                if (Request.QueryString["Ctgry"] != null)
                {
                    Response.Redirect("AgtInfoEducation.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
                }
                else
                {
                    Response.Redirect("AgtInfoEducation.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=''" + "&ID=" + Request.QueryString["ID"].ToString());
                }
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

        #region LINKBUTTON 'lnkPage3' ONCLICK EVENT
        protected void lnkPage3_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.Transparent;
                lnkPage2.BackColor = Color.Transparent;
                lnkPage3.BackColor = Color.LightYellow;
                lnkPage4.BackColor = Color.Transparent;
                lnkPage5.BackColor = Color.Transparent;
                btnUpdate.Enabled = false;
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                }
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst1.png";
                lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";

                FillHiddenValues();
                if (Request.QueryString["Ctgry"] != null)
                {
                    Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
                }
                else
                {
                    Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=''" + "&ID=" + Request.QueryString["ID"].ToString());
                }
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

        #region LINKBUTTON 'lnkPage4' ONCLICK EVENT
        protected void lnkPage4_Click(object sender, EventArgs e)
        {

            try
            {
                btnReGenerateLetter.Enabled = false;//satish
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.Transparent;
                lnkPage2.BackColor = Color.Transparent;
                lnkPage3.BackColor = Color.Transparent;
                lnkPage4.BackColor = Color.LightYellow;
                lnkPage5.BackColor = Color.Transparent;
                btnTerminationLetter.Visible = true;
                btnTerminationLetter.Enabled = true;
                btnUpdate.Enabled = false;
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                }
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp1.png";
                lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo2.png";


                FillHiddenValues();
                LetterInfo();
                btnCDAPromotionLetter.Visible = false;
                if (Request.QueryString["Ctgry"] != null)
                {
                    Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
                }
                else
                {
                    Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=''" + "&ID=" + Request.QueryString["ID"].ToString());
                }
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

        #region LINKBUTTON 'lnkPage5' ONCLICK EVENT
        protected void lnkPage5_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.Transparent;
                lnkPage2.BackColor = Color.Transparent;
                lnkPage3.BackColor = Color.Transparent;
                lnkPage4.BackColor = Color.Transparent;
                lnkPage5.BackColor = Color.LightYellow;
                btnUpdate.Enabled = false;
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                }
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/Education2.png";
                lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
                lnkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
                lnkPage5.ImageUrl = "~/theme/iflow/tabs/PaymentInfo1.png";

                FillHiddenValues();
                if (Request.QueryString["Ctgry"] != null)
                {
                    Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
                }
                else
                {
                    Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + txtAgtCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=''" + "&ID=" + Request.QueryString["ID"].ToString());
                }
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

        #region LINKBUTTON 'lnkPage6' ONCLICK EVENT
        protected void lnkPage6_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                lnkPage1.BackColor = Color.Transparent;
                lnkPage2.BackColor = Color.Transparent;
                lnkPage3.BackColor = Color.Transparent;
                lnkPage4.BackColor = Color.Transparent;
                lnkPage5.BackColor = Color.Transparent;
                btnUpdate.Enabled = false;
                FillHiddenValues();
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

        #region RADIOBUTTONLIST rdbChnlTyp_SelectedIndexChanged
        //Added by swapnesh on 5/12/2013 to fetch sales channel ddl value base on channel type start
        protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reset the ddl Enabling Sequence
            ddlSlsChannel.Enabled = true;
            ddlChnCls.Enabled = false;
            ddlAgntType.Enabled = false;
            ddlLicTyp.Enabled = false;

            try
            {
                if (rdbChnlTyp.SelectedValue == "0")
                {
                    oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "0");
                    ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                }
                else
                {
                    oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "1");
                    ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                }
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlAgntType.Items.Clear();
                ddlAgntType.DataSource = null;
                ddlAgntType.DataBind();
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                tblReportingMngrDtls.Visible = false;
                tblUnitCodeDetails.Visible = false;
                ddlLicTyp.Items.Clear();
                ddlLicTyp.DataSource = null;
                ddlLicTyp.DataBind();
                ddlLicTyp.Items.Insert(0, new ListItem("-- Select --", ""));
                txtRptMgr.Text = "";
                txtUntCode.Text = "";
                rdbChnlTyp.Focus();
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
        //Added by swapnesh on 5/12/2013 to fetch sales channel ddl value base on channel type end
        #endregion

        #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
        protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlChnCls.Enabled = true;
            try
            {
                ddlChnCls.Items.Clear();
                SqlDataReader dtRead;
                //Added by Pranjali on 02-07-2013 for Channel sub class dropdown start
                Hashtable htparam = new Hashtable();
                htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
                //Added by Pranjali on 02-07-2013 for Channel sub class dropdown end
                if (dtRead.HasRows)
                {
                    ddlChnCls.DataSource = dtRead;
                    ddlChnCls.DataTextField = "ChnlDesc";
                    ddlChnCls.DataValueField = "ChnCls";
                    ddlChnCls.DataBind();
                }
                dtRead = null;
                ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlChnCls.Enabled = true;
                if (ddlSlsChannel.SelectedIndex == 0)
                {
                    oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                    ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlAgntType.Items.Clear();
                    ddlAgntType.DataSource = null;
                    ddlAgntType.DataBind();
                    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    tblReportingMngrDtls.Visible = false;
                    tblUnitCodeDetails.Visible = false;
                }

                ddlAgntType.Items.Clear();
                ddlAgntType.Items.Insert(0, new ListItem("--Select--", ""));
                ddlLicTyp.Items.Clear();
                ddlLicTyp.Items.Insert(0, new ListItem("-- Select --", ""));

                ClrMgrText();
                ddlSlsChannel.Focus();
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

            #region Clear Primary Manager Details
            //txtRptMgr.Text = "";
            //hdnRptMgr.Value = null;
            //lblrptmgr.Text = "";
            //txtUntCode.Text = "";
            //lblUnitDesc.Text = "";
            //hdnUntCode.Value = null;
            #endregion
        }
        #endregion

        #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
        protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAgntType.Enabled = true;
            try
            {
                if (ddlSlsChannel.SelectedValue == "")
                {
                    oCommonU.GetAgentType(ddlAgntType, "ALL", "");
                }
                else
                {
                    //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString());
                    if (Request.QueryString["Ctgry"] != null)
                    {
                        if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                        {
                            oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "E");
                        }
                        if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                        {
                            oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "V");
                        }
                    }
                    else
                    {
                        oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "A");
                    }
                }
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                if (ddlChnCls.SelectedIndex == 0)
                {
                    ddlAgntType.Items.Clear();
                    ddlAgntType.DataSource = null;
                    ddlAgntType.DataBind();
                    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    tblReportingMngrDtls.Visible = false;
                    tblUnitCodeDetails.Visible = false;
                    ClrMgrText();
                }
                tblReportingMngrDtls.Visible = false;
                tblUnitCodeDetails.Visible = false;
                ClrMgrText();
                ddlChnCls.Focus();
                ddlAgntType.Enabled = true;
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

            #region Clear Primary Manager Details
            //txtRptMgr.Text = "";
            //hdnRptMgr.Value = null;
            //lblrptmgr.Text = "";
            //txtUntCode.Text = "";
            //lblUnitDesc.Text = "";
            //hdnUntCode.Value = null;
            #endregion
        }
        #endregion
        public void BindUnitcode()
        {
            try
            {

                DataSet ds = new DataSet();

                Hashtable htParam = new Hashtable();
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@AgentType", ddlAgntType.SelectedValue.ToString().Trim());
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue.ToString().Trim());
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
                htParam.Add("@MgrCode", ViewState["RecruitMemCode"].ToString().Trim());
                htParam.Add("@MgrAgtType", ViewState["RecruitType"].ToString().Trim());
                htParam.Add("@flag", 5);
                if (Request.QueryString["Ctgry"] != null)
                {
                    htParam.Add("@flagIsAgt", "Emp");
                }
                else
                {
                    htParam.Add("@flagIsAgt", "Agent");
                }

                ds = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr", htParam);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = ds.Tables[0];
                        gvUntLst.DataBind();
                        Session["unt"] = ds;
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

        }
        #region DROPDOWNLIST 'ddlAgntType' SELECTEDINDEXCHANGED EVENT
        protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Session["unt"] = null;
                gvUntLst.DataSource = null;
                gvUntLst.DataBind();
                Session["mem"] = null;
                gv.DataSource = null;
                gv.DataBind();//Added by usha or unitcode auto binding 0n 05.02.2022
                BindUnitcode();
                if (Request.QueryString["Ctgry"] == null)
                {
                    FillDDlAgnVenRelMap();

                }
                tblReportingMngrDtls.Visible = true;
                tblUnitCodeDetails.Visible = true;
                //change of int strUnitRank  to decimal strUnitRank due to state in tied
                decimal strUnitRank = 0;
                SqlDataReader dtRead;
                SqlDataReader dtRead1;
                //Added by Pranjali on 01-07-2013 for fetching data from chnAgnSu Start
                Hashtable htparam = new Hashtable();
                htparam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                htparam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                htparam.Add("@flag", 1);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", htparam);
                //Added by Pranjali on 01-07-2013 for fetching data from chnAgnSu end
                if (dtRead.Read())
                {
                    //change of Convert.ToInt32 to Convert.ToDecimal due to state in tied
                    strUnitRank = Convert.ToDecimal(dtRead["UnitRank"].ToString());
                    hdnCreateRule.Value = dtRead["MemCreateRul"].ToString();
                    hdnEMPCode.Value = dtRead["IsCmpStaff"].ToString();
                    if (Convert.ToString(dtRead["ORLdrCreateRul"]) == "1")
                    {
                        txtImmLeaderCode.Enabled = true;
                        btnImmLeaderCode.Enabled = true;
                        lblImmCDA.Visible = true;
                    }
                    else
                    {
                    }
                    hdnAppRule.Value = dtRead["AppRule"].ToString();
                    hdnUntRule.Value = Convert.ToString(dtRead["UntRule"]);
                }
                dtRead = null;


                ddlTaxCode.Items.Clear();
                htparam.Clear();
                //Added by Pranjali on 03-07-2013 for Retrieving param value and param description start
                htparam = new Hashtable();
                htparam.Add("@LookupCode", "taxcode");
                htparam.Add("@ParamValue", ddlAgntType.SelectedValue.Trim());
                htparam.Add("@flag", 2);
                dtRead1 = dataAccess.exec_reader_prc_inscdirect("Prc_Getparamvalueanddesc", htparam);
                //Added by Pranjali on 03-07-2013 for Retrieving param value and param description end
                if (dtRead1.HasRows)
                {
                    ddlTaxCode.DataSource = dtRead1;
                    ddlTaxCode.DataTextField = "ParamDesc";
                    ddlTaxCode.DataValueField = "ParamValue";
                    ddlTaxCode.DataBind();
                    ddlTaxCode.SelectedValue = ddlAgntType.SelectedValue;
                }
                else
                {
                    ddlTaxCode.Items.Insert(0, new ListItem("-- Select --", ""));
                }
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details start 
                FillReportingMngrDtls();
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details end
                //rachana 30-11-2013 end
                txtRptMgr.Text = "";
                hdnRptMgr.Value = null;
                lblrptmgr.Text = "";
                txtUntCode.Text = "";
                lblUnitDesc.Text = "";
                hdnUntCode.Value = null;
                ddlLicTyp.Items.Clear();
                ddlLicTyp.Items.Insert(0, new ListItem("-- Select --", ""));
                ClrMgrText();
                ddlAgntType.Focus();
                PopulateConstityp();

                #region Clear Primary Manager Details

                // added by sandeep garg start
                if (Request.QueryString["Source"] != null)
                {
                    if (Request.QueryString["Source"].ToString() == "MomEmp")
                    {
                        txtRptMgr.Text = "";
                        hdnRptMgr.Value = null;
                        lblrptmgr.Text = "";
                        txtUntCode.Text = "";
                        lblUnitDesc.Text = "";
                        hdnUntCode.Value = null;
                        if (HttpContext.Current.Session["UnitCode"] != null)
                        {
                            lblUnitDesc.Text = HttpContext.Current.Session["UnitCode"].ToString().Trim();
                            hdnUntCode.Value = HttpContext.Current.Session["UnitCode"].ToString().Trim();
                            txtUntCode.Text = HttpContext.Current.Session["UnitDesc"].ToString().Trim();
                        }
                    }
                }
                // added by sandeep garg start
                #endregion

                #region patch for validation of RF to Unit Code
                if (ddlAgntType.SelectedValue == "RF")
                {
                    txtUntCode.BackColor = System.Drawing.Color.White;
                    tblUnitCodeDetails.Visible = false;
                }
                #endregion

                if (ddlAgntType.SelectedValue == "")
                {
                    tblUnitCodeDetails.Visible = false;
                }

                BindPrimaryReportingCode();//Added by sanoj on 08.02.2022
                BindAdditionalReportingCode();//Added by usha on 02.03.2022
                btndisabled();//Added by ajay on 22.06.2022
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
            #region Patch to Make UnitCode Not Mandatory for Vendors
            //Added: Parag
            if (lblVw1AgntType.Text == "Vendor Type")
            {
               
            }
            #endregion
        }
        #endregion

        
        public void BindPrimaryReportingCode()
        {
            try
            {

                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                //if (rdbPosn.SelectedIndex != -1)
                //{
                //    htParam.Add("@FlagPosn", rdbPosn.SelectedValue);
                //}
                //else        //Add:Parag @ 04032014 - Condition for reinstatement Purposes
                //{
                htParam.Add("@FlagPosn", String.Empty);
                //}            //Add: End
                htParam.Add("@MgrName", "");
                htParam.Add("@SAPCode", ViewState["RecruitMemCode"].ToString().Trim());
                //commented by ajay
                //if (ViewState["MemberRole"].ToString().Trim() == "V" && ddllvlagttype.SelectedValue.ToString().Trim() == "")
                //{
                //    htParam.Add("@AgentType", ViewState["RecruitType"].ToString().Trim());

                //}
                //else
                //commented by ajay
                {
                    htParam.Add("@AgentType", ddllvlagttype.SelectedValue.ToString().Trim());
                }
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue.ToString().Trim());
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
                //Added: Parag
                htParam.Add("@UnitCode", "");
                htParam.Add("@flag", Request.QueryString["Ctgry"].ToString());
                htParam.Add("@chkflag", "1");
                htParam.Add("@BsdOn", ddlambasedondesc.SelectedValue.ToString().Trim());
                htParam.Add("@MemType", ddlAgntType.SelectedValue.ToString().Trim());
                htParam.Add("@RptStp", "");
                htParam.Add("@RptSetup", hdnRptSetup.Value.ToString().Trim());
                htParam.Add("@Chnl", ddlSlsChannel.SelectedValue.ToString().Trim());
                htParam.Add("@SChnl", ddlChnCls.SelectedValue.ToString().Trim());
                htParam.Add("@MemCode", "");
                //if (Request.QueryString["chkflag"] != null)
                //{
                //if (Request.QueryString["untcd"].ToString() != "")
                //{
                //    if (Request.QueryString["agttyp"] != "")
                //    {
                //        dsmgr = objDAL.GetDataSetForPrc("Prc_GetUntDtls", htParam);
                //    }
                //    else if (Request.QueryString["agttyp"] == "")
                //    {
                //        dsmgr = objDAL.GetDataSetForPrc("Prc_GetUntDtlsUntRnk", htParam);
                //    }
                //}
                //else
                //{
                dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforRptManager", htParam);
                //}
                // }

                if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
                {
                    d1.Attributes.Add("style", "display:block");
                    gv.DataSource = dsmgr;
                    gv.DataBind();
                    Session["mem"] = dsmgr;
                }


                dsmgr = null;
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

        #region ddlLicTyp SelectedIndexChanged
        protected void ddlLicTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Added by swapnesh on 21/12/2013 to set visibility of client Details start 
                dsResult = new DataSet();
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                htParam.Add("@AgtType", ddlAgntType.SelectedValue);
                htParam.Add("@LicType", ddlLicTyp.SelectedValue);
                dsResult = objDAL.GetDataSetForPrc("prc_GetClientFlagforAgt", htParam);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["ConstType"].ToString() != "")
                    {
                        var lictype = dsResult.Tables[0].Rows[0]["ConstType"].ToString().Trim();
                        hdnConstiRole.Value = dsResult.Tables[0].Rows[0]["Role"].ToString().Trim();
                        Session["ConstiRole"] = hdnConstiRole.Value;
                        Session["lictype"] = lictype;
                        //added by sandeep garg start
                        string strDate = string.Empty;
                        if (HttpContext.Current.Session["DOB"] != null)
                        {
                            strDate = HttpContext.Current.Session["DOB"].ToString().Trim();
                        }
                        //added by sandeep garg start
                        //Comeneted by sanoj
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ShowCltDtls('" + lictype + "');", true);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "filldob('" + strDate + "');", true);
                    }
                }
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        funShowCrntMgr("empty");
                    }
                    else
                    {
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    }
                }
                else
                {
                    funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                }
                //Added by swapnesh on 21/12/2013 to set visibility of client Details end 
                if (ddlLicTyp.SelectedValue.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ShowCltDtls('');", true);
                }
                ddlLicTyp.Focus();
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

        #region PopulateConstityp
        public void PopulateConstityp()
        {
            try
            {
                ddlLicTyp.Enabled = true;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                htparam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                htparam.Add("@AgtTyp", ddlAgntType.SelectedValue.Trim());
                dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlConstitype", htparam);
                //Added by Pranjali on 02-07-2013 for Channel sub class dropdown end
                if (dtRead.HasRows)
                {
                    ddlLicTyp.DataSource = dtRead;
                    ddlLicTyp.DataTextField = "ConstDesc";
                    ddlLicTyp.DataValueField = "ConstCode";
                    ddlLicTyp.DataBind();
                }
                dtRead = null;
                ddlLicTyp.Items.Insert(0, new ListItem("-- Select --", ""));
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

        #region ShowClient
        protected void ShowClient()
        {
            try
            {
                dsResult = new DataSet();
                htParam = new Hashtable();
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                htParam.Add("@AgtType", ddlAgntType.SelectedValue);
                htParam.Add("@LicType", ddlLicTyp.SelectedValue);
                dsResult = objDAL.GetDataSetForPrc("prc_GetClientFlagforAgt", htParam);

                var lictype = dsResult.Tables[0].Rows[0]["ConstType"].ToString().Trim();
                Session["lictype"] = lictype;
                ////added by akshay on 25/02/14 to set constitution role in session start
                if (Request.QueryString["cnd"] != null)
                {
                    if (Request.QueryString["cnd"].ToString().Trim() == "CndCon")
                    {
                        hdnConstiRole.Value = dsResult.Tables[0].Rows[0]["Role"].ToString().Trim();
                        Session["ConstiRole"] = hdnConstiRole.Value;
                    }
                }
                ////added by akshay on 25/02/14 to set constirole in session end
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "ShowCltDtls('" + lictype + "');", true);
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

        #region FillReportingMngrDtls
        protected void FillReportingMngrDtls()
        {

            if (Request.QueryString["Type"] != null)
            {
                try
                {
                    Hashtable htParam = new Hashtable();
                    DataSet dsRpt = new DataSet();
                    htParam.Clear();
                    dsRpt.Clear();
                    if (Request.QueryString["Type"] != "E")
                    {

                        htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                        htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                        htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                        dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);
                    }
                    else
                    {
                        htParam.Add("@AgentCode", txtAgtCode.Text.Trim());
                        htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                        htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                        htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                        dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforRptmgr", htParam);
                    }
                    //Assign values to labels
                    #region fetch values
                    if (dsRpt.Tables.Count > 0)
                    {
                        if (dsRpt.Tables[0].Rows.Count > 0)
                        {
                            FillReportingMngrddl();
                            string PrmyRptType = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                            ////setAgtType(PrmyRptType, ddllvlagttype);
                            hdnRptSetup.Value = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                            ddllvlagttype.Enabled = true;
                            ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString().Trim();
                            //modified by akshay on 140214 start
                            ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString().Trim();
                            if (dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == "" || dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == null)
                            {
                                trprirep.Visible = false;
                            }
                            else
                            {
                                trprirep.Visible = true;
                            }
                            //modified by akshay on 140214 end

                            ddlambasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString().Trim();

                            FillReportingMngrchnl();

                            ddlamchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString().Trim();

                            FillReportingMngrsubchnl();

                            ddlamsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString().Trim();

                            FillReportingMngrAgttype();
                            #region fetch member type

                            if (Request.QueryString["Type"] != null)
                            {
                                if (Request.QueryString["Type"].ToString().Trim() == "E")
                                {
                                    ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["RelMemType"].ToString().Trim();
                                    ddllvlagttype.Enabled = true;
                                    txtRptMgr.Enabled = false;
                                    btnRptMgr.Enabled = true;
                                }
                                else if (PrmyRptType == "E" && ddlambasedondesc.SelectedValue == "1")
                                {
                                    ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                                    ddllvlagttype.Enabled = true;
                                }
                                else if (PrmyRptType == "E" && ddlambasedondesc.SelectedValue == "0")
                                {
                                    // Commented by usha
                                    //ddllvlagttype.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim(),
                                    //    ddlamchnldesc.SelectedValue.ToString().Trim(), ddlamsubchnldesc.SelectedValue.ToString().Trim());
                                    ddllvlagttype.Enabled = true;

                                }
                                else
                                {
                                    hdnMemType.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                                }
                            }
                            if (ddllvlagttype.SelectedValue.Trim() != "")
                            {
                                if (ddllvlagttype.SelectedValue.ToString().Trim() == "RF")
                                {
                                    trventype.Visible = true;
                                }
                                else
                                {
                                    trventype.Visible = false;
                                }
                            }
                            else
                            {
                                trventype.Visible = false;
                            }
                            #endregion
                            hdnchn.Value = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString().Trim();
                            hdnsubchn.Value = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString().Trim();

                            hdnEMPCode.Value = dsRpt.Tables[0].Rows[0]["IsCmpStaff"].ToString().Trim();
                            if (hdnEMPCode.Value.Trim() == "Y")
                            {
                                txtSAPcode.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                            }

                            string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();
                            //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable start

                            GetManagers();
                            GetAddlManagers();

                            //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable end

                            //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection start

                            funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                            //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection end
                        }
                        else
                        {
                            funShowCrntMgr("empty");
                        }
                    }
                    else
                    {
                        funShowCrntMgr("empty");
                    }
                    #endregion

                    #region Mandatory Managers
                    if (dsRpt.Tables.Count > 0)
                    {
                        if (dsRpt.Tables[0].Rows.Count > 0)
                        {
                            hdnPriMandatory.Value = dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString();
                            if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                            {
                                //txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                                txtRptMgr.Attributes.Add("class", "mandatory");
                            }
                        }
                    }
                    #endregion

                    fillAddlRptMngrDtls();

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
        }
        #endregion

        #region fillAddlRptMngrDtls
        public void fillAddlRptMngrDtls()
        {

            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            if (Request.QueryString["Type"].ToString().Trim() != "E")
            {
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                dsRpt = objDAL.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls", htParam);
            }
            else
            {
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                htParam.Add("@MgrCode", txtAgtCode.Text.Trim());
                dsRpt = objDAL.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls_Approve", htParam);
            }

            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                gv_RptMngr.DataSource = dsRpt.Tables[0];

                gv_RptMngr.DataBind();
                bindGridDdl(dsRpt);
                //ddlAddlventype_SelectedIndexChanged(sender, e);
                traddlrep.Visible = true;
            }
            else
            {
                gv_RptMngr.DataSource = null;
                gv_RptMngr.DataBind();
                bindGridDdl(dsRpt);//Added by usha 
                traddlrep.Visible = true; //True by usha 28.01.2022
            }
        }

        //private void bindGridDdl(DataSet dsRpt)
        //{
        //    gv_RptMngr.HeaderRow.Visible = false;
        //    for (int i = 0; gv_RptMngr.Rows.Count-1 >i; i++)
        //    {
        //        DropDownList ddlAdlRptTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlRptTyp");
        //        ddlAdlRptTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

        //        DropDownList ddlAdlBsdOn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlBsdOn");
        //        ddlAdlBsdOn.SelectedValue = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

        //        DropDownList ddlAdlChn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlChn");
        //        ddlAdlChn.SelectedValue = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

        //        DropDownList ddlAdlSChn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlSChn");
        //        ddlAdlSChn.SelectedValue = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

        //        HiddenField hdnAdMemType = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnAdMemType");

        //        HiddenField hdnAddlStp = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnAddlStp");
        //        hdnAddlStp.Value = dsRpt.Tables[0].Rows[i]["AddlStp"].ToString();
        //        DropDownList ddlRelModel = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlRelModel");
        //        DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp");
        //        ddlAdlAgtTyp.Enabled = true;
        //        if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
        //        {
        //            lblRptMngrErr.Visible = false;
        //            lblRptMngrErr.Text = "";
        //            lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
        //            funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
        //            lbladditionalreportingrule.Visible = true;
        //        }
        //        else
        //        {
        //            lblRptMngrErr.Visible = true;
        //            lblRptMngrErr.Text = "No Records Exists";
        //            lbladditionalreportingrule.Text = "";
        //        }
        //        if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "1")
        //        {
        //            ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
        //            ddlAdlAgtTyp.Enabled = true;//true by usha  on 28.01.2022
        //        }
        //        else if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "0")
        //        {
        //            //ddlAdlAgtTyp.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim(), 
        //            //ddlAdlChn.SelectedValue.ToString().Trim(), ddlAdlSChn.SelectedValue.ToString().Trim());

        //            hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
        //        }
        //        else
        //        {
        //            hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();///////for inclusive only
        //        }
        //        if (ddlAdlAgtTyp.SelectedValue != null)
        //        {
        //            if (ddlAdlAgtTyp.SelectedValue != "RF")
        //            {
        //                HtmlTableRow trVenType = (HtmlTableRow)gv_RptMngr.Rows[i].FindControl("trVenType");
        //                trVenType.Visible = false;
        //            }
        //        }
        //        TextBox txtRptMngr = (TextBox)gv_RptMngr.Rows[i].FindControl("txtRptMngr");
        //        Label lblmndtry = (Label)gv_RptMngr.Rows[i].FindControl("lblmndtry");
        //        HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnRptMgrMandatory");
        //        hdnRptMgrMandatory.Value = dsRpt.Tables[0].Rows[i]["IsMandatory"].ToString();
        //        LinkButton lnkViewMDtls = (LinkButton)gv_RptMngr.Rows[i].FindControl("lnkViewMDtls");
        //        Button btnRptAdMgr = (Button)gv_RptMngr.Rows[i].FindControl("lnkRptMngr");
        //        if (hdnRptMgrMandatory.Value == "True")
        //        {
        //            txtRptMngr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
        //            lblmndtry.Visible = true;
        //        }
        //        if (Request.QueryString["Type"].ToString().Trim() == "E")
        //        {
        //            if (dsRpt.Tables[0].Rows[i]["ReportingType"].ToString().Trim() != null)
        //            {
        //                if (dsRpt.Tables[0].Rows[i]["MemTypDsc"].ToString().Trim() == "RF")
        //                {
        //                    lnkViewMDtls.Visible = true;
        //                    lnkViewMDtls.Attributes.Add("onclick", "funcShowPopup('VendorIRC');return false;");
        //                    pnlMdl.Width = 800;
        //                    ifrmMdlPopup.Attributes.Add("width", "100%");
        //                }
        //            }
        //            DropDownList ddlAddlventype = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAddlventype");
        //            ddlAddlventype.SelectedValue = dsRpt.Tables[0].Rows[i]["VenType"].ToString();
        //            Session["AdlVentyp"] = ddlAddlventype.SelectedValue;
        //            ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemTypDsc"].ToString().Trim();

        //            //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString();
        //            //Label lblRptMngr = (Label)gv_RptMngr.Rows[i].FindControl("lblRptMngr");
        //            //lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
        //            //Session["vencode"] = lblRptMngr.Text.Trim();
        //            //Session["venname"] = txtRptMngr.Text.Trim();
        //            //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString() + "(" + dsRpt.Tables[0].Rows[i]["RptSapCode"].ToString() + ")";

        //            ddlRelModel.SelectedValue = dsRpt.Tables[0].Rows[i]["RelModel"].ToString();

        //            ddlAddlventype.Enabled = false;///080714
        //            ddlRelModel.Enabled = false;
        //            ddlAdlAgtTyp.Enabled = true; //true by usha on 28.01.2022
        //            txtRptMngr.Enabled = false;
        //            btnRptAdMgr.Enabled = true;//true by usha on 28.01.2022
        //            //ddlAdlAgtTyp.Enabled = false;
        //        }
        //    }
        //}

        private void bindGridDdl(DataSet dsRpt)
        {
            gv_RptMngr.HeaderRow.Visible = false;
            for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
            {
                DropDownList ddlAdlRptTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlRptTyp");
                ddlAdlRptTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

                DropDownList ddlAdlBsdOn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlBsdOn");
                ddlAdlBsdOn.SelectedValue = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

                DropDownList ddlAdlChn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlChn");
                ddlAdlChn.SelectedValue = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

                DropDownList ddlAdlSChn = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlSChn");
                ddlAdlSChn.SelectedValue = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

                HiddenField hdnAdMemType = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnAdMemType");

                HiddenField hdnAddlStp = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnAddlStp");
                hdnAddlStp.Value = dsRpt.Tables[0].Rows[i]["AddlStp"].ToString();
                DropDownList ddlRelModel = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlRelModel");

                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp");
                ddlAdlAgtTyp.Enabled = true;
                if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
                {
                    lblRptMngrErr.Visible = false;
                    lblRptMngrErr.Text = "";
                    lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
                    funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
                    lbladditionalreportingrule.Visible = true;
                }
                else
                {
                    lblRptMngrErr.Visible = true;
                    lblRptMngrErr.Text = "No Records Exists";
                    lbladditionalreportingrule.Text = "";
                }

                if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "1")
                {
                    //ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                    ddlAdlAgtTyp.Enabled = true;//true by usha  on 28.01.2022
                }
                else if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "0")
                {
                    //ddlAdlAgtTyp.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim(), 
                    //ddlAdlChn.SelectedValue.ToString().Trim(), ddlAdlSChn.SelectedValue.ToString().Trim());

                    hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                }
                //Added by usha 17/06/2022
                else if (hdnAddlStp.Value == "I" && ddlAdlBsdOn.SelectedValue == "0")
                {

                    ddlAdlAgtTyp.SelectedValue = ViewState["RecruitType"].ToString().Trim();
                    ddlAdlAgtTyp.Enabled = false;//true by usha  on 28.01.2022
                }
                else
                {
                    hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();///////for inclusive only
                }
                if (ddlAdlAgtTyp.SelectedValue != null)
                {
                    if (ddlAdlAgtTyp.SelectedValue != "RF")
                    {
                        HtmlTableRow trVenType = (HtmlTableRow)gv_RptMngr.Rows[i].FindControl("trVenType");
                        trVenType.Visible = false;
                    }
                }


                TextBox txtRptMngr = (TextBox)gv_RptMngr.Rows[i].FindControl("txtRptMngr");
                Label lblmndtry = (Label)gv_RptMngr.Rows[i].FindControl("lblmndtry");
                HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr.Rows[i].FindControl("hdnRptMgrMandatory");
                hdnRptMgrMandatory.Value = dsRpt.Tables[0].Rows[i]["IsMandatory"].ToString();
                LinkButton lnkViewMDtls = (LinkButton)gv_RptMngr.Rows[i].FindControl("lnkViewMDtls");
                Button btnRptAdMgr = (Button)gv_RptMngr.Rows[i].FindControl("lnkRptMngr");

                if (hdnRptMgrMandatory.Value == "True")
                {
                    txtRptMngr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                    lblmndtry.Visible = true;
                }
                /////setAgtType(hdnAddlStp.Value.Trim(), ddlAdlAgtTyp);

                if (Request.QueryString["Type"].ToString().Trim() == "E")
                {
                    if (dsRpt.Tables[0].Rows[i]["ReportingType"].ToString().Trim() != null)
                    {
                        if (dsRpt.Tables[0].Rows[i]["MemTypDsc"].ToString().Trim() == "RF")
                        {
                            lnkViewMDtls.Visible = true;
                            lnkViewMDtls.Attributes.Add("onclick", "funcShowPopup('VendorIRC');return false;");
                            pnlMdl.Width = 800;
                            ifrmMdlPopup.Attributes.Add("width", "100%");
                        }
                    }
                    DropDownList ddlAddlventype = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAddlventype");
                    ddlAddlventype.SelectedValue = dsRpt.Tables[0].Rows[i]["VenType"].ToString();
                    Session["AdlVentyp"] = ddlAddlventype.SelectedValue;
                    ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemTypDsc"].ToString().Trim();

                    //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString();
                    //Label lblRptMngr = (Label)gv_RptMngr.Rows[i].FindControl("lblRptMngr");
                    //lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
                    //Session["vencode"] = lblRptMngr.Text.Trim();
                    //Session["venname"] = txtRptMngr.Text.Trim();
                    //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString() + "(" + dsRpt.Tables[0].Rows[i]["RptSapCode"].ToString() + ")";

                    ddlRelModel.SelectedValue = dsRpt.Tables[0].Rows[i]["RelModel"].ToString();

                    ddlAddlventype.Enabled = false;///080714
                    ddlRelModel.Enabled = false;
                    ddlAdlAgtTyp.Enabled = true; //true by usha on 28.01.2022
                    txtRptMngr.Enabled = false;
                    btnRptAdMgr.Enabled = true;//true by usha on 28.01.2022
                    //ddlAdlAgtTyp.Enabled = false;
                    ddlAddlventype.Visible = false;///080714
                    ddlRelModel.Enabled = false;
                    ddlAdlAgtTyp.Enabled = true; //true by usha on 28.01.2022
                    txtRptMngr.Enabled = false;
                    btnRptAdMgr.Enabled = true;//true by usha on 28.01.2022
                }
            }
        }
        #endregion

        #region ddlventype_SelectedIndexChanged
        protected void ddlventype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region ddlAddlventype_SelectedIndexChanged
        protected void ddlAddlventype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
                DropDownList ddlAddlventype = (DropDownList)grd.FindControl("ddlAddlventype");
                DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
                DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
                TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
                Button lnkRptMngr = (Button)grd.FindControl("lnkRptMngr");

                if (ddlAddlventype.SelectedValue == "DV")
                {
                    ddlAdlRptTyp.Enabled = false;
                    ddlAdlBsdOn.Enabled = false;
                    ddlAdlChn.Enabled = false;
                    ddlAdlSChn.Enabled = false;
                    ddlAdlAgtTyp.Enabled = false;
                    txtRptMngr.Enabled = false;
                    lnkRptMngr.Enabled = false;
                }
                else if (ddlAddlventype.SelectedValue == "EVS")
                {
                    ddlAdlRptTyp.Enabled = false;
                    ddlAdlBsdOn.Enabled = false;
                    ddlAdlChn.Enabled = false;
                    ddlAdlSChn.Enabled = false;
                    ddlAdlAgtTyp.Enabled = false;
                    txtRptMngr.Enabled = true;
                    lnkRptMngr.Enabled = true;
                    ////080714
                    ddlAdlChn.SelectedValue = ddlSlsChannel.SelectedValue;
                    Hashtable htParam = new Hashtable();
                    DataSet dsVend = new DataSet();
                    htParam.Clear();
                    dsVend.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlAdlChn.SelectedValue.ToString().Trim());
                    htParam.Add("@MemType", ddlAdlAgtTyp.SelectedValue.ToString().Trim());
                    dsVend = objDAL.GetDataSetForPrcCLP("Prc_GetVendorClass", htParam);
                    if (dsVend != null)
                    {
                        if (dsVend.Tables[0].Rows.Count > 0)
                        {
                            ddlAdlSChn.SelectedValue = dsVend.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                        }
                    }

                }
                else if (ddlAddlventype.SelectedValue == "EVD")
                {
                    ddlAdlRptTyp.Enabled = false;
                    ddlAdlBsdOn.Enabled = true;
                    ddlAdlChn.Enabled = true;
                    ddlAdlSChn.Enabled = true;
                    ddlAdlAgtTyp.Enabled = false;
                    txtRptMngr.Enabled = true;
                    lnkRptMngr.Enabled = true;
                }

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

        #region setAgtType
        public void setAgtType(string PrmyRptType, DropDownList ddl)
        {
            if (PrmyRptType == "I")
            {
                ddl.Enabled = true;
            }
        }
        #endregion

        #region FillReportingMngrddl
        protected void FillReportingMngrddl()
        {
            try
            {
                oCommon.getDropDown(ddlamrptdesc, "Rpttype", 1, "", 1, c_strBlank);

                oCommon.getDropDown(ddlambasedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

                ddlambasedondesc.Items.Insert(0, new ListItem("-- Select --", ""));

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

        #region FillReportingMngrchnl
        protected void FillReportingMngrchnl()
        {
            try
            {
                funchnlpopup(ddlamchnldesc);
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

        #region funchnlpopup
        protected void funchnlpopup(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtRead;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
                if (dtRead.HasRows)
                {
                    ddl.DataSource = dtRead;
                    ddl.DataTextField = "ChannelDesc01";
                    ddl.DataValueField = "BizSrc";
                    ddl.DataBind();
                }
                dtRead = null;
                ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

        #region FillReportingMngrsubchnl
        protected void FillReportingMngrsubchnl()
        {
            try
            {
                funsubchnlpopup(ddlamsubchnldesc, ddlamchnldesc.SelectedItem.Text);

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

        #region funsubchnlpopup
        protected void funsubchnlpopup(DropDownList ddl, string txt)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtRead;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@chnl", txt.Trim());
                dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlmgrsubchnnl", htparam);
                if (dtRead.HasRows)
                {
                    ddl.DataSource = dtRead;
                    ddl.DataTextField = "ChnClsDesc01";
                    ddl.DataValueField = "ChnCls";
                    ddl.DataBind();
                }
                dtRead = null;
                ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

        #region FillReportingMngrAgttype
        protected void FillReportingMngrAgttype()
        {
            try
            {
                funagttyppopup(ddllvlagttype, ddlambasedondesc.SelectedValue, "0");
                //ddllvlagttype.Items.Insert(0, new ListItem("Independent", ""));

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

        #region funagttyppopup
        protected void funagttyppopup(DropDownList ddl, string BasedOn, string order)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtRead;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
                htparam.Add("@MemType", ddlAgntType.SelectedValue);
                htparam.Add("@RelOrder", order);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
                if (dtRead.HasRows)
                {
                    ddl.DataSource = dtRead;
                    ddl.DataTextField = "MemTypeDesc01";
                    ddl.DataValueField = "MemType";
                    ddl.DataBind();
                }
                dtRead = null;
				ddl.Items.Insert(0, new ListItem("Independent", ""));
				//ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

        #region GetManagers
        protected void GetManagers()
        {
            try
            {
                if (Request.QueryString["Ctgry"] != null)
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','');return false;");

                }
                else
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','');return false;");

                }
                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                htParam.Add("@AgentType", ddllvlagttype.SelectedValue);
                htParam.Add("@BizSrc", hdnchn.Value.Trim());
                htParam.Add("@ChnCls", hdnsubchn.Value.Trim());
                dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforManager", htParam);
                if (dsmgr.Tables.Count > 0)
                {
                    if (dsmgr.Tables[0].Rows.Count > 0)
                    {
                        #region commented
                        //ddlRptMgr.DataSource = dsmgr;
                        //ddlRptMgr.DataTextField = "LegalName";
                        //ddlRptMgr.DataValueField = "AgentCode";
                        //ddlRptMgr.DataBind();
                        #endregion
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region GetAddlManagers
        protected void GetAddlManagers()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                htParam.Add("@AgentType", ddllvlagttype.SelectedValue);
                htParam.Add("@BizSrc", hdnchn.Value.Trim());
                htParam.Add("@ChnCls", hdnsubchn.Value.Trim());
                dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforManager", htParam);
                if (dsmgr.Tables.Count > 0)
                {
                    if (dsmgr.Tables[0].Rows.Count > 0)
                    {
                        #region commented
                        //txtRptMgr1.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                        //hdnRptMgr1.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                        //lblrptmgr1.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();

                        //txtRptMgr2.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                        //hdnRptMgr2.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                        //lblrptmgr2.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();

                        //txtRptMgr3.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                        //hdnRptMgr3.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                        //lblrptmgr3.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                        #endregion
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region METHOD 'LetterInfo()' DEFINITION
        protected void LetterInfo()
        {
            string strCauLtr = "";
            string strWrnLtr = "";
            string strTermLtr = "";
            string strShwCauLtr = "";
            try
            {
                //Added by Pranjali on 03-07-2013 for filling the data into Miscellaneous Notes start 
                htParam.Clear();
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
                dtRead = objDAL.Common_exec_reader_prc_common("Prc_GetDataForMiscellaneousNotes", htParam);
                //Added by Pranjali on 03-07-2013 for filling the data into Miscellaneous Notes end
                if (dtRead.Read())
                {
                    strCauLtr = dtRead[0].ToString();
                    strWrnLtr = dtRead[1].ToString();
                    strTermLtr = dtRead[2].ToString();
                    strShwCauLtr = dtRead[6].ToString();

                    if (strShwCauLtr != "0")
                    {
                        btnTerminationLetter.Visible = true;
                        btnTerminationLetter.Enabled = true;
                        btnReGenerateLetter.Visible = true;
                        btnReGenerateLetter.Enabled = true;
                    }
                    if (strCauLtr != "0")
                    {
                        btnTerminationLetter.Visible = true;
                        btnTerminationLetter.Enabled = true;
                        btnReGenerateLetter.Visible = true;
                        btnReGenerateLetter.Enabled = true;
                    }
                    if (strWrnLtr != "0")
                    {

                        btnTerminationLetter.Visible = true;
                        btnTerminationLetter.Enabled = true;
                        btnReGenerateLetter.Visible = true;
                        btnReGenerateLetter.Enabled = true;
                    }
                    if (strTermLtr != "0")
                    {

                        btnTerminationLetter.Visible = false;
                        btnTerminationLetter.Visible = true;
                        btnReGenerateLetter.Visible = true;
                        btnReGenerateLetter.Enabled = true;
                    }
                }
                else
                {
                    Hashtable ht3 = new Hashtable();
                    ht3.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    ht3.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
                    objDAL.execute_sprc("Prc_InsertAgtLtrInfo", ht3);
                }
                dtRead = null;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region DROPDOWNLIST 'ddlPaymentMode' SELECTEDINDEXCHANGED EVENT
        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlPaymentMode.SelectedValue != "DC")
            {
                txtBankHolderName.Enabled = false;
                txtBankAccNo.Enabled = false;
                txtBnkBrnchName.Enabled = false;
                txtNeftCode.Enabled = false;
                btnVerifyNeft.Enabled = false;
                txtBankHolderName.Text = "";
                txtBankAccNo.Text = "";
                txtBnkBrnchName.Text = "";
                txtNeftCode.Text = "";
                txtBankName.Text = "";
                lblBranchName.Text = "";
            }
            else
            {
                txtBankHolderName.Enabled = true;
                txtBankAccNo.Enabled = true;
                txtBankName.Enabled = true;
                txtBnkBrnchName.Enabled = true;
                txtNeftCode.Enabled = true;
                btnVerifyNeft.Enabled = true;
            }
        }
        #endregion

        #region ONCLICK 'btnUpdate' BUTTON
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
                {
                    TextBox txtRptMngr = gv_RptMngr.Rows[i].FindControl("txtRptMngr") as TextBox;

                    HiddenField hdnAddlRptMgr = gv_RptMngr.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;
                    HiddenField hdnRptMgrMandatory = gv_RptMngr.Rows[i].FindControl("hdnRptMgrMandatory") as HiddenField;

                    if (hdnRptMgrMandatory.Value == "True")
                    {
                        if (txtRptMngr.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Additional Manager.');</script>", false);
                            return;
                        }
                    }
                }
                if (txtDOB.Text.ToString().Trim() != "" && txtBizOldLicStrtDt.Text.ToString().Trim() != "")
                {
                    var birthY = Convert.ToDateTime(txtDOB.Text.ToString().Trim()).Year;
                    var licY = Convert.ToDateTime(txtBizOldLicStrtDt.Text.ToString().Trim()).Year;
                    if ((licY - birthY) <= 18)
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Old License Start Date & Date of Birth should have difference of atleast 18 years.');</script>", false);
                        return;
                    }
                }
                if (txtBizOldLicExpDt.Text.ToString().Trim() != "" && txtBizOldLicStrtDt.Text.ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(txtBizOldLicExpDt.Text) < Convert.ToDateTime(txtBizOldLicStrtDt.Text))
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Old License Expiry Date should not be less than Old License Start Date.');</script>", false);
                        return;
                    }
                }
                if (txtBizLicEndDt.Text.ToString().Trim() != "" && txtBizOldLicExpDt.Text.ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(txtBizLicEndDt.Text.ToString().Trim()) < Convert.ToDateTime(txtBizOldLicExpDt.Text.ToString().Trim()))
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Old License Expiry Date should be less than Biz License Expiry Date.');</script>", false);
                        return;
                    }
                }
                if (txtBizLicEndDt.Text.ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(txtBizLicEndDt.Text.ToString().Trim()) < DateTime.Now)
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Biz License Expiry Date');</script>", false);
                        return;
                    }
                }
                if (txtEmail.Text.ToString().Trim() != "" && txtEmail2.Text.ToString().Trim() != "")
                {
                    if (txtEmail.Text.ToString().Trim() == txtEmail2.Text.ToString().Trim())
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Email 1 and Email 2 should not be same.');</script>", false);
                        return;
                    }
                }
                if (txtDOB.Text.ToString().Trim() != "" && txtBizOldLicStrtDt.Text.ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(txtDOB.Text.ToString().Trim()) >= Convert.ToDateTime(txtBizOldLicStrtDt.Text.ToString().Trim()))
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Old License Start Date should be greater than Date of Birth.');</script>", false);
                        return;
                    }
                }

                if (txtDOB.Text.ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(txtDOB.Text.ToString().Trim()) >= DateTime.Now)
                    {
                        lblMessage.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date of Birth should not exceed Todays Date.');</script>", false);
                        return;
                    }
                }
                htParam = new Hashtable();
                ArrayList arrResult = new ArrayList();
                Hashtable htable = new Hashtable();
                Hashtable htable1 = new Hashtable();
                SqlDataReader dtRead;

                if (txtMinAmt.Text.Trim() == "")
                {
                    txtMinAmt.Text = "0.00";
                }

                txtdt.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                if (txtdoj.Text != "")
                {
                    if (Convert.ToDateTime(txtdoj.Text) > Convert.ToDateTime(txtdt.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Incorrect Joining Date');</script>", false);
                        return;
                    }
                }
                //Added by Pranjali on 03-07-2013 for fetching data from chnAgnSu Start
                Hashtable htparam = new Hashtable();
                htparam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                htparam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                htparam.Add("@flag", 7);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", htparam);
                //Added by Pranjali on 03-07-2013 for fetching data from chnAgnSu end
                if (dtRead.Read())
                {
                    hdnCreateRule.Value = dtRead[0].ToString();
                }
                dtRead.Close();
                #region "Request.QueryString["Type"].ToString() == N"
                if (Request.QueryString["Type"].ToString() == "N" || Request.QueryString["Type"].ToString() == "Clt")
                {
                    try
                    {
                        #region getMemberCode
                        htParam.Clear();
                        htParam.Add("@AgtType", ddlAgntType.SelectedValue.ToString());
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            htParam.Add("@Ctgry", Request.QueryString["Ctgry"].ToString().Trim());
                        }
                        else
                        {
                            htParam.Add("@Ctgry", "Member");
                        }
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetMAXAgtCode", htParam);

                        //Added by Pranjali on 03-07-2013 for agent code and csc code selection and updation end
                        if (dtRead.Read())
                        {
                            txtAgtCode.Text = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        #endregion

                        try
                        {
                            //Added by swapnesh on 24/12/2013 to get max GCN start
                            if (Request.QueryString["Type"].ToString().Trim() != "Clt")
                            {
                                dsResult = new DataSet();
                                htParam.Clear();
                                dsResult.Clear();
                                dsResult = dataAccess.GetDataSetForPrc("Prc_GetMaxGCN", htParam);
                                txtCusmId.Text = dsResult.Tables[0].Rows[0]["ClientCode"].ToString().Trim();
                            }
                            //Added by swapnesh on 24/12/2013 to get max GCN end

                            objSQLConForTran = objDAL.GetSQLConnection_Common();

                            if (objSQLConForTran.State != ConnectionState.Open)
                            {
                                objSQLConForTran.Open();
                            }
                            objSQLTran = objSQLConForTran.BeginTransaction();

                            htable.Add("@Mapping", "abc");//changed by pranjali for agent creation on 26-11-2013
                            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htable.Add("@AgentCode ", txtAgtCode.Text);
                            htable.Add("@AgentStatus ", ddlAgntStatus.SelectedValue);
                            htable.Add("@AgnTitle", cboagnTitle.SelectedValue);
                            htable.Add("@AgentName ", txtAgntName.Text);
                            htable.Add("@PANNo ", txtPanNo.Text.Trim());//Added by swapnesh on 02/01/2014 to insert Pan No
                            htable.Add("@Gender", ddlGender.SelectedValue);
                            htable.Add("@Education", ddlEducutn.SelectedValue);//added by sanoj

                            if (TxtAnnivrsryDt.Text.Trim() != "")
                            {
                                htable.Add("@AnniversaryDate", TxtAnnivrsryDt.Text);//added by sanoj
                            }
                            else
                            {
                                htable.Add("@AnniversaryDate ", System.DBNull.Value);
                            }

                            htable.Add("@UniqRefNo", ViewState["UnqRefNo"].ToString());//added by sanoj
                                                                                       // htable.Add("@UniqRefNo", "57293376");//added by sanoj

                            htable.Add("@CustomerId", txtCusmId.Text);
                            htable.Add("@Exclusive ", rdlExclusive.SelectedValue);
                            htable.Add("@BizSrc ", ddlSlsChannel.SelectedValue.ToString());
                            htable.Add("@ChnSubCls", ddlChnCls.SelectedValue);
                            htable.Add("@BizLicsNo", txtBizLicNo.Text);
                            htable.Add("@AgentType", ddlAgntType.SelectedValue);
                            htable.Add("@ConstCode", ddlLicTyp.SelectedValue);
                            htable.Add("@ConstRole", Session["ConstiRole"].ToString().Trim()); //commented by sanoj
                            htable.Add("@OldLicno", txtBizOldLicNo.Text);
                            if (txtBizOldLicStrtDt.Text.Trim() != "")
                            {
                                htable.Add("@OldLicnoStrtDt", DateTime.Parse(txtBizOldLicStrtDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@OldLicnoStrtDt", System.DBNull.Value);
                            }
                            if (txtBizOldLicExpDt.Text.Trim() != "")
                            {
                                htable.Add("@OldLicnoExpDt", DateTime.Parse(txtBizOldLicExpDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@OldLicnoExpDt", System.DBNull.Value);
                            }
                            if (txtBizLicEndDt.Text.Trim() != "")
                            {
                                htable.Add("@BizLicsExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@BizLicsExpDate ", System.DBNull.Value);
                            }
                            htable.Add("@AgentClass", ddlAgntClass.SelectedValue);
                            htable.Add("@PayMethod", ddlPaymentMode.SelectedValue);
                            htable.Add("@Currency ", ddlCurrency.SelectedValue);
                            htable.Add("@CommCls", ddlCommCls.SelectedValue);
                            htable.Add("@PayFreq ", ddlPayFrequency.SelectedValue);
                            htable.Add("@AccPayCode", txtAccPayee.Text);
                            if (txtMinAmt.Text.Trim() == "0.00")
                            {
                                htable.Add("@MinAmt", 0);
                            }
                            else
                            {
                                htable.Add("@MinAmt", Decimal.Parse(txtMinAmt.Text).ToString("0.00"));
                            }
                            htable.Add("@UserId", txtUserId.Text);
                            if (txtRecruitDate.Text.Trim() != "")
                            {
                                htable.Add("@RecruitDate ", DateTime.Parse(txtRecruitDate.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@RecruitDate ", System.DBNull.Value);
                            }
                            htable.Add("@BEBranchCode", txtBranchCode.Text);
                            htable.Add("@RecruitAgntCode", txtRecruitAgntCode.Text);
                            htable.Add("@BEAreaCode ", txtAreCode.Text);
                            htable.Add("@ImmLeader ", txtImmLeaderCode.Text);
                            htable.Add("@BESMCode ", txtSmCode.Text);
                            if (hdnUntCode.Value != null && hdnUntCode.Value != "")
                            {
                                //added by sandeep start
                                if (Request.QueryString["Source"] != null)
                                {
                                    if (Request.QueryString["Source"].ToString() == "MomEmp")
                                    {
                                        if (HttpContext.Current.Session["UnitCode"] != null)
                                        {
                                            hdnUntCode.Value = HttpContext.Current.Session["UnitCode"].ToString().Trim();
                                            HttpContext.Current.Session["UnitCode"] = null;
                                        }
                                    }
                                }
                                //added by sandeep end
                                htable.Add("@UnitCode ", hdnUntCode.Value);
                            }
                            else
                            {
                                htable.Add("@UnitCode ", System.DBNull.Value);//comented by sanoj
                            }
                            if (txtCeaseDate.Text.Trim() != "")
                            {
                                htable.Add("@DateTerminated", DateTime.Parse(txtCeaseDate.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@DateTerminated", System.DBNull.Value);
                            }
                            htable.Add("@BlackListStatus", ddlBlkLstStatus.SelectedValue);
                            htable.Add("@EmployeeCode", txtEmpCode.Text);
                            if (txtBankAccNo.Text != "")
                            {
                                htable.Add("@BnkAccNo", txtBankAccNo.Text);
                            }
                            else
                            {
                                htable.Add("@BnkAccNo", System.DBNull.Value);
                            }
                            if (ddlactype.SelectedIndex == 0)
                            {
                                htable.Add("@BankAcType", System.DBNull.Value);
                            }
                            else
                            {
                                htable.Add("@BankAcType", ddlactype.SelectedValue);
                            }
                            if (txtBankHolderName.Text != "")
                            {
                                htable.Add("@AccHolderName", txtBankHolderName.Text);
                            }
                            else
                            {
                                htable.Add("@AccHolderName", System.DBNull.Value);
                            }
                            if (txtNeftCode.Text != "")
                            {
                                htable.Add("@IFSCCode", txtNeftCode.Text);
                            }
                            else
                            {
                                htable.Add("@IFSCCode", System.DBNull.Value);
                            }
                            if (txtNeftCode.Text != "")
                            {
                                htable.Add("@NEFTCode", txtNeftCode.Text);
                            }
                            else
                            {
                                htable.Add("@NEFTCode", System.DBNull.Value);
                            }
                            if (txtmcrcode.Text != "")
                            {
                                htable.Add("@MICRCode", txtmcrcode.Text);
                            }
                            else
                            {
                                htable.Add("@MICRCode", System.DBNull.Value);
                            }
                            if (txtBankName.Text != "")
                            {
                                htable.Add("@BankName", txtBankName.Text);
                            }
                            else
                            {
                                htable.Add("@BankName", System.DBNull.Value);
                            }

                            if (txtBnkAddress.Text != "")
                            {
                                htable.Add("@BranchName", txtBnkAddress.Text);
                            }
                            else
                            {
                                htable.Add("@BranchName", System.DBNull.Value);
                            }
                            if (txtBankName.Text != "")
                            {
                                htable.Add("@BnkDesc", txtBankName.Text);
                            }
                            else
                            {
                                htable.Add("@BnkDesc", System.DBNull.Value);
                            }
                            if (txtBnkBrnchName.Text != "")
                            {
                                htable.Add("@BnkBrnDesc", txtBnkBrnchName.Text);
                            }
                            else
                            {
                                htable.Add("@BnkBrnDesc", System.DBNull.Value);
                            }
                            htable.Add("@DeductTax", ddlDeductTax.SelectedValue);
                            htable.Add("@TaxCode", ddlTaxCode.SelectedValue);
                            htable.Add("@MgrCode", hdnRptMgr.Value);

                            #region Add 2 new Felds
                            htable.Add("@AppVideNo", txt_AppNo.Text.Trim());
                            if (txtDTJoinFrom.Text.Trim() != "")
                            {
                                htable.Add("@AppDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));

                            }
                            else
                            {
                                htable.Add("@AppDate", System.DBNull.Value);
                            }
                            #endregion

                            htable.Add("@EAgrmntDTim", System.DBNull.Value);
                            htable.Add("@ServProvdInfo", txtServProvInfo.Text.Trim());
                            if (txtdoj.Text.Trim() != "")
                            {
                                htable.Add("@DateOfJoin", DateTime.Parse(txtdoj.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htable.Add("@DateOfJoin", System.DBNull.Value);
                            }
                            //For TPBR 
                            if (txtPartnerName.Text.Trim() != "")
                            {
                                htable.Add("@PartnerName", txtPartnerName.Text);
                            }
                            else
                            {
                                htable.Add("@PartnerName", System.DBNull.Value);
                            }
                            if (txtPartnerCode.Text.Trim() != "")
                            {
                                htable.Add("@PartnerCode", txtPartnerCode.Text);
                            }
                            else
                            {
                                htable.Add("@PartnerCode", System.DBNull.Value);
                            }

                            //InsertMapVenorInfo();
                            //Added by swapnesh on 9/12/2013 to save Manager & Reporting Info in Agent table start
                            htable.Add("@ChnlType", rdbChnlTyp.SelectedValue);

                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-1")
                            {
                                //htable.Add("@Mgrcode1", ddam1lMgr.SelectedValue);
                                htable.Add("@Mgrcode1", System.DBNull.Value);
                                htable.Add("@Mgrcode2", System.DBNull.Value);
                                htable.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-2")
                            {
                                htable.Add("@Mgrcode1", System.DBNull.Value);
                                htable.Add("@Mgrcode2", System.DBNull.Value);
                                htable.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-3")
                            {
                                htable.Add("@Mgrcode1", System.DBNull.Value);
                                htable.Add("@Mgrcode2", System.DBNull.Value);
                                htable.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            if (txtRptMgr.Text == "")
                            {
                                htable.Add("@IsRptMgr", "1");
                            }
                            else
                            {
                                htable.Add("@IsRptMgr", "0");
                            }
                            ///added by akshay on 17/01/14 start
                            if (Request.QueryString["CndNum"] != null)
                            {
                                byte[] imgres = InsertCndImg();
                                htable.Add("@Img", imgres);
                            }
                            else
                            {
                                byte[] imgres = InsertImg();
                                htable.Add("@Img", imgres);
                            }
                            ///added by akshay on 17/01/14 end
                            //Added by swapnesh on 9/12/2013 to save Manager & Reporting Info in Agent table end

                            #region Client Creation
                            //Added by swapnesh on 23/12/2013 to save Client details start
                            if (Session["lictype"] != null)
                            {
                                htable.Add("@Licflag", Session["lictype"].ToString().Trim());

                                #region Insert Client Contact Details
                                Hashtable htcnct = new Hashtable();
                                htcnct.Clear();
                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "P1");
                                htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                htcnct.Add("@StateCode", ddlState.SelectedValue);
                                htcnct.Add("@Area", txtarea.Text);
                                htcnct.Add("@City", txtcity.Text);
                                htcnct.Add("@Village", txtVillage.Text.Trim());
                                htcnct.Add("@District", txtDistP.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                if (Request.QueryString["Type"] != null)
                                {
                                    if (Request.QueryString["Type"].ToString() == "Clt")
                                    {
                                        htcnct.Add("@flagclt", "MapClt");
                                    }
                                    else
                                    {
                                        htcnct.Add("@flagclt", "NewClt");
                                    }
                                }
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                htcnct.Clear();
                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "B1");
                                htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                htcnct.Add("@Area", txtarea0.Text);
                                htcnct.Add("@City", txtcity0.Text);
                                htcnct.Add("@Village", txtBvillage.Text.Trim());
                                htcnct.Add("@District", txtDistB.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                if (Request.QueryString["Type"] != null)
                                {
                                    if (Request.QueryString["Type"].ToString() == "Clt")
                                    {
                                        htcnct.Add("@flagclt", "MapClt");
                                    }
                                    else
                                    {
                                        htcnct.Add("@flagclt", "NewClt");
                                    }
                                }
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                //}
                                if (ChkPABusns.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                    htcnct.Add("@Area", txtarea0.Text);
                                    htcnct.Add("@City", txtcity0.Text);
                                    htcnct.Add("@Village", txtBvillage.Text.Trim());
                                    htcnct.Add("@District", txtDistB.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                if (ChkPARes.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState.SelectedValue);
                                    htcnct.Add("@Area", txtarea.Text);
                                    htcnct.Add("@City", txtcity.Text);
                                    htcnct.Add("@Village", txtVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistP.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                //AddedControl by usha

                                else
                                {

                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtPermAdd1.Text.Trim());
                                    htcnct.Add("@Adr2", txtPermAdd2.Text.Trim());
                                    htcnct.Add("@Adr3", txtPermAdd3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPermPostcode.Text.Trim());
                                    //htcnct.Add("@StateCode", txtStateCodeP.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState1.SelectedValue);
                                    htcnct.Add("@Area", txtarea1.Text);
                                    htcnct.Add("@City", txtcity1.Text);
                                    htcnct.Add("@Village", txtPermVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistric.Text.Trim());
                                    htcnct.Add("@CntryCode", txtPermCountryCode.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                #endregion

                                int chkpref;
                                string chkstf;
                                string chktax;

                                if (Session["lictype"].ToString().Trim() == "C")
                                {
                                    if (chkVip.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    if (chkStaff.Checked == true)
                                    {
                                        chkstf = "Y";
                                    }
                                    else
                                    {
                                        chkstf = "N";
                                    }
                                    if (chkSalesTax.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    htable.Add("@GCN", txtCusmId.Text.Trim());
                                    htable.Add("@SName", txtSurname.Text.Trim());
                                    htable.Add("@Econ", ddlEcon.SelectedValue);
                                    //htable.Add("@DOB", txtDOB1.Text);
                                    htable.Add("@DOB", txtDOB.Text);

                                    if (cboMaritalStatus.SelectedIndex != 0)
                                    {
                                        htable.Add("@MStat", cboMaritalStatus.SelectedValue);//
                                    }
                                    else
                                    {
                                        htable.Add("@MStat", System.DBNull.Value);
                                    }
                                    htable.Add("@BrthPl", txtBirthPlace.Text.Trim());
                                    htable.Add("@AnnTrn", txtAnnTurnover.Text.Trim());
                                    htable.Add("@Capital", txtCapital.Text.Trim());
                                    htable.Add("@StfSize", txtStaffSz.Text.Trim());
                                    htable.Add("@PrfClt", Convert.ToString(chkpref));
                                    htable.Add("@Staff", chkstf);
                                    htable.Add("@TaxStat", chktax);
                                    htable.Add("@Title", cboTitle.SelectedValue);
                                }
                                else
                                {
                                    if (chkprefclt.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    if (chkStaff.Checked == true)
                                    {
                                        chkstf = "Y";
                                    }
                                    else
                                    {
                                        chkstf = "N";
                                    }
                                    if (CheckBox2.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    htable.Add("@GCN", txtCusmId.Text.Trim());
                                    if (txtDOB.Text != "")
                                    {
                                        htable.Add("@DOB", txtDOB.Text.Trim());
                                    }
                                    else
                                    {
                                        htable.Add("@DOB", DBNull.Value);
                                    }
                                    htable.Add("@SpInd", DBNull.Value);
                                    if (cboMaritalStatus.SelectedIndex != 0) //added by sanoj28-01-2022
                                    {
                                        htable.Add("@MStat", cboMaritalStatus.SelectedValue);//
                                    }
                                    else
                                    {
                                        htable.Add("@MStat", System.DBNull.Value);
                                    }
                                    htable.Add("@SOE", ddlSOE.SelectedValue);
                                    htable.Add("@Ntnlty", txtNationalCode.Text.Trim());
                                    htable.Add("@Catgry", ddlCategory.SelectedValue);
                                    if (txtSAPcode.Text != "")
                                    {
                                        htable.Add("@SAPcode", txtSAPcode.Text.Trim());
                                    }
                                    else
                                    {
                                        htable.Add("@SAPcode", DBNull.Value);
                                    }
                                    htable.Add("@QualC", cboQualCode.SelectedValue);
                                    htable.Add("@QualD", cboQualCode.SelectedValue);
                                    htable.Add("@OcpnCode01", txtOccupationCode.Text.Trim());
                                    htable.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
                                    htable.Add("@Height", txtHeight1.Text.Trim());
                                    htable.Add("@Weight", txtWeight.Text.Trim());
                                    htable.Add("@AltIdTyp", cboOtherIDType.SelectedValue);
                                    htable.Add("@AltId", txtOthersID.Text.Trim());
                                    htable.Add("@remark", Menu1.Text.Trim());
                                    htable.Add("@Income", txtALIncome.Text.Trim());
                                    htable.Add("@PrfClt", Convert.ToString(chkpref));
                                    htable.Add("@Staff", chkstf);
                                    htable.Add("@TaxStat", chktax);
                                }

                                htable.Add("@HTelno", txtHomeTel.Text.Trim());
                                htable.Add("@OTelno", txtWorkTel.Text.Trim());
                                htable.Add("@DIDTelno", "");
                                htable.Add("@mobno", txtMobileTel.Text.Trim());
                                htable.Add("@email", txtEmail.Text.Trim());
                                htable.Add("@mobno2", txtMobileTel2.Text.Trim());
                                htable.Add("@email2", txtEmail2.Text.Trim());
                                htable.Add("@Pager", txtPager.Text.Trim());
                                htable.Add("@Fax", txtFax.Text.Trim());
                                //added by sanoj
                                htable.Add("@Aadhaar", "9988778876");
                                htable.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));
                                htable.Add("@FacebookId", txtFbId.Text.Trim());
                                htable.Add("@TwiterId", txtTwt.Text.Trim());
                                htable.Add("@InstagramId", txtInstId.Text.Trim());
                                //end
                                htable.Add("@CnctType", ddlCnctType.SelectedValue);

                                AddAddress(); //add Adderess
                                //Add Nomine Dtails by sanoj
                                htable.Add("@NomineeName", txtNomNme.Text.Trim());
                                if (ddlNomnRel.SelectedIndex == 0)
                                {
                                    htable.Add("@NomineeRel", DBNull.Value);
                                }
                                else
                                {
                                    htable.Add("@NomineeRel", ddlNomnRel.Text.Trim());
                                }
                                htable.Add("@NomineeDOB", txtNomDob.Text.Trim());//txtNomDob.Text.Trim()
                                htable.Add("@NomineeMobileTel", txtNomMob.Text.Trim());
                                htable.Add("@NomineeEmailID", txtNomEmail.Text.Trim());
                                htable.Add("@flag", "BE");

                                //htable.Add("@ExpMonBusnsHealth", txtExpt.Text.Trim());commented by ajay 20-05-2022
                                htable.Add("@ExpMonBusnsHealth", txtExpt1.SelectedValue);//Added by ajay 20-05-2022
                                htable.Add("@ExpTeamStrgt", txtExpectTm.Text.Trim());
                                htable.Add("@ExpAgntInSixMnth", txtAgntMonth.Text.Trim());
                                htable.Add("@ExpAgntInTwelveMnth", txtAgntMonth12.Text.Trim());
                                htable.Add("@ExpPOSPInSixMnth", txtPosp6.Text.Trim());
                                htable.Add("@ExpPOSPInTwelveMnth", txtPosp12.Text.Trim());
                                htable.Add("@DtlsOfOthrbusiness", txtDtlsExtBus.Text.Trim());
                                htable.Add("@MrktingInFinservicebusiness", txtmrktBus.Text.Trim());
                                htable.Add("@DtlsOfLawSuit", txtSrcProvd.Text.Trim());
                                htable.Add("@DtlsOfOthrAssignmt", txtAsnmnet.Text.Trim());
                                htable.Add("@BussinessRemark", txtRemark.Text.Trim());
                                //Bussiness Evaluation end
                                //start Background / Experince
                                //Hashtable htComp = new Hashtable();
                                htcnct.Clear();
                                htcnct.Add("@Agentode", txtAgtCode.Text);
                                htcnct.Add("@BckgrndExp", "");
                                htcnct.Add("@ExpTime", "");
                                htcnct.Add("@Organization", "");
                                htcnct.Add("@TenureFrm", "");
                                htcnct.Add("@TenureTo", "");
                                htcnct.Add("@CreatedBy", "");
                                htcnct.Add("@OtherSector", "");
                                htcnct.Add("@Flag", "0");
                                dataAccess.exec_comm_command("Prc_MemBckgrndExp_Ins", htcnct);
                                for (int i = 0; gvComposite.Rows.Count > i; i++)
                                {
                                    Label lblExperience = gvComposite.Rows[i].FindControl("lblExperience") as Label;
                                    Label lblExpTime = gvComposite.Rows[i].FindControl("lblExpTime") as Label;//remain
                                    Label lblOrganization = gvComposite.Rows[i].FindControl("lblOrganization") as Label;
                                    Label lblotherssectors = gvComposite.Rows[i].FindControl("lblotherssectors") as Label;
                                    //Label lblTenureFrom = gvComposite.Rows[i].FindControl("lblTenureFrom") as Label;//commented by ajay 20-05-2022
                                    //Label lblTenureTo = gvComposite.Rows[i].FindControl("lblTenureTo") as Label;//commented by ajay 20-05-2022

                                    htcnct.Clear();
                                    htcnct.Add("@Agentode", txtAgtCode.Text);
                                    htcnct.Add("@BckgrndExp", lblExperience.Text.Trim());
                                    htcnct.Add("@ExpTime", lblExpTime.Text.Trim());
                                    htcnct.Add("@Organization", lblOrganization.Text.Trim());
                                    htcnct.Add("@OtherSector", lblotherssectors.Text.Trim());
                                    htcnct.Add("@TenureFrm", "");
                                    htcnct.Add("@TenureTo", "");
                                    htcnct.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                                    dataAccess.exec_comm_command("Prc_MemBckgrndExp_Ins", htcnct);
                                }
                                //End Background / Experince



                            }
                            if (Request.QueryString["Type"] != null)
                            {
                                if (Request.QueryString["Type"].ToString() == "Clt")
                                {
                                    htable.Add("@flagclt", "MapClt");
                                }
                                else
                                {
                                    htable.Add("@flagclt", "NewClt");
                                }
                            }
                            //Added by swapnesh on 23/12/2013 to save Client details end
                            #endregion

                            if (Request.QueryString["Ctgry"] != null)
                            {
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                                {
                                    htable.Add("@AgtRole", 0);
                                }
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                {
                                    htable.Add("@AgtRole", 2);
                                }
                            }
                            else
                            {
                                htable.Add("@AgtRole", 1);
                            }
                            InsertUntRelDtls();
                            //Added by swapnesh on 27/01/2014 to save reporting manager details start
                            var vencode = InsertRptMngrDtls();
                            //Added by swapnesh on 27/01/2014 to save reporting manager details end
                            MemVenMap(vencode);

                            //End For TPBR 
                            if (Request.QueryString["CndNum"] != null)
                            {
                                htable.Add("@artlflag", "1");
                                htable.Add("@cndno", Request.QueryString["CndNum"].ToString().Trim());
                            }
                            ArrayList arrLst = new ArrayList();
                            arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                            arrLst.Add(new prjXml.Collection("AgentCode", txtAgtCode.Text));
                            arrLst.Add(new prjXml.Collection("AgentStatus", ddlAgntStatus.SelectedValue));
                            arrLst.Add(new prjXml.Collection("CustomerId", txtCusmId.Text));
                            arrLst.Add(new prjXml.Collection("Exclusive", rdlExclusive.SelectedValue));
                            arrLst.Add(new prjXml.Collection("AgentName", txtAgntName.Text));
                            arrLst.Add(new prjXml.Collection("BizSrc", ddlSlsChannel.SelectedValue.ToString()));
                            arrLst.Add(new prjXml.Collection("ChnSubCls", ddlChnCls.SelectedValue));
                            arrLst.Add(new prjXml.Collection("BizLicsNo", txtBizLicNo.Text));
                            arrLst.Add(new prjXml.Collection("AgentType", ddlAgntType.SelectedValue));
                            if (txtBizLicEndDt.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("BizLicsExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("BizLicsExpDate", ""));
                            }
                            arrLst.Add(new prjXml.Collection("AgentClass", ddlAgntClass.SelectedValue));
                            arrLst.Add(new prjXml.Collection("PayMethod", ddlPaymentMode.SelectedValue));
                            arrLst.Add(new prjXml.Collection("Currency", ddlCurrency.SelectedValue));
                            arrLst.Add(new prjXml.Collection("CommCls", ddlCommCls.SelectedValue));
                            arrLst.Add(new prjXml.Collection("PayFreq", ddlPayFrequency.SelectedValue));
                            arrLst.Add(new prjXml.Collection("AccPayCode", txtAccPayee.Text));
                            if (txtMinAmt.Text.Trim() == "")
                            {
                                arrLst.Add(new prjXml.Collection("MinAmt", "0"));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("MinAmt", Decimal.Parse(txtMinAmt.Text).ToString("0.00")));
                            }
                            arrLst.Add(new prjXml.Collection("UserId", txtUserId.Text));
                            if (txtRecruitDate.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("RecruitDate", DateTime.Parse(txtRecruitDate.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("RecruitDate", ""));
                            }
                            arrLst.Add(new prjXml.Collection("BEBranchCode", txtBranchCode.Text));
                            arrLst.Add(new prjXml.Collection("RecruitAgntCode", txtRecruitAgntCode.Text));
                            arrLst.Add(new prjXml.Collection("BEAreaCode", txtAreCode.Text));
                            arrLst.Add(new prjXml.Collection("ImmLeader", txtImmLeaderCode.Text));
                            arrLst.Add(new prjXml.Collection("BESMCode", txtSmCode.Text));
                            arrLst.Add(new prjXml.Collection("UnitCode", hdnUntCode.Value));
                            if (txtCeaseDate.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("DateTerminated", DateTime.Parse(txtCeaseDate.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("DateTerminated", ""));
                            }
                            arrLst.Add(new prjXml.Collection("BlackListStatus", ddlBlkLstStatus.SelectedValue));
                            arrLst.Add(new prjXml.Collection("EmployeeCode", txtEmpCode.Text));
                            arrLst.Add(new prjXml.Collection("NEFTCode", txtNeftCode.Text));
                            arrLst.Add(new prjXml.Collection("BnkAccNo", txtBankAccNo.Text));
                            arrLst.Add(new prjXml.Collection("AccHolderName", txtBankHolderName.Text));
                            arrLst.Add(new prjXml.Collection("BnkDesc", txtBankName.Text));
                            arrLst.Add(new prjXml.Collection("BnkBrnDesc", txtBnkBrnchName.Text));
                            arrLst.Add(new prjXml.Collection("DeductTax", ddlDeductTax.SelectedValue));
                            arrLst.Add(new prjXml.Collection("TaxCode", ddlTaxCode.SelectedValue));

                            //Modified by swapnesh on 11/12/2013 to fetch MgrCode from ddlRptMgr instead of txtMngrCode start
                            arrLst.Add(new prjXml.Collection("MgrCode", hdnRptMgr.Value));
                            //Modified by swapnesh on 11/12/2013 to fetch MgrCode from ddlRptMgr instead of txtMngrCode end
                            prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                            XmlDocument xDoc = new XmlDocument();
                            xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                            strXML = xDoc.OuterXml;

                            arrLst.Clear();
                            //Added by usha for recruiter details on 18.01.2022
                            htable.Add("@RecruitMemCode", ViewState["RecruitMemCode"].ToString().Trim());
                            htable.Add("@RecruitMemName", ViewState["RecruitEmpName"].ToString().Trim());
                            htable.Add("@RecruitUnitCode", ViewState["RecruitunitCode"].ToString().Trim());
                            htable.Add("@RecruitType", ViewState["RecruitType"].ToString().Trim());
                            htable.Add("@chkgstFlag", chkgst.Checked == true ? "Y" : "N");
                            htable.Add("@chkagreeFlag", chkagree.Checked == true ? "Y" : "N");

                            arrResult = agentObject.InsertAgentDetails(htable, "pri_AgyAdmin_InsAgent");

                            if (arrResult.Count > 0)
                            {
                                if (arrResult[0].ToString() != "F")
                                {
                                    if (arrResult.Count > 0)
                                    {
                                        if (arrResult[0].ToString().Equals("0"))
                                        {
                                            //Added by swapnesh for showing messagebox on 16/5/2013 start
                                            if (Request.QueryString["Ctgry"] != null)
                                            {
                                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                                                {
                                                    lbl3.Text = "Employee created successfully.";
                                                    lblMessage.Text = "Employee created successfully.";
                                                    lbl4.Text = "Employee Name:-" + txtAgntName.Text.Trim();
                                                    lbl5.Text = "Employee Code:-" + txtAgtCode.Text.Trim();
                                                    
                                                    DataSet ds = new DataSet();
                                                    ds.Clear();
                                                    ds = GetPopDtls(txtAgtCode.Text.ToString().Trim());
                                                    if (ds.Tables.Count > 0)
                                                    {
                                                        if (ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            lbl6.Text = "SAP Code:-" + ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                                                        }
                                                    }
                                                }
                                                //if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                                //{
                                                //    mdlpopup.Show();
                                                //    lbl3.Text = "Code created successfully.";
                                                //    lblMessage.Text = "Code created successfully.";
                                                //    lbl4.Text = "Name:-" + txtAgntName.Text.Trim();
                                                //    lbl5.Text = "Code:-" + txtAgtCode.Text.Trim();
                                                //    lbl6.Visible = false;
                                                //    DataSet ds = new DataSet();
                                                //    ds.Clear();
                                                //    ds = GetPopDtls(txtAgtCode.Text.ToString().Trim());
                                                //    if (ds.Tables.Count > 0)
                                                //    {
                                                //        if (ds.Tables[0].Rows.Count > 0)
                                                //        {
                                                //            lbl6.Text = "Emp Code:-" + ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                                                //        }
                                                //    }
                                                //    mdlpopup.Show();
                                                //    //Added by usha for Welcome letter //on 17.01.2021
                                                //    ConvertRDLCToPDF(txtAgtCode.Text.Trim());
                                                //}
                                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                                {
                                                    //mdlpopup.Show();
                                                    lbl3.Text = "Code created successfully.";
                                                    lblMessage.Text = "Code created successfully.";
                                                    lbl4.Text = "Name:-" + txtAgntName.Text.Trim();
                                                    lbl6.Text = "Code:-" + txtAgtCode.Text.Trim();
                                                    lbl6.Visible = false;
                                                    DataSet ds = new DataSet();
                                                    ds.Clear();
                                                    ds = GetPopDtls(txtAgtCode.Text.ToString().Trim());
                                                    if (ds.Tables.Count > 0)
                                                    {
                                                        if (ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            if (ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim() != "")
                                                            {
                                                                lbl5.Text = "Code:-" + ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                                                                lblMessage.Text = "Code created successfully <br/>" + lbl5.Text;
                                                                //Added by usha on 31.05.2022
                                                                mdlpopup.Show();

                                                                ConvertRDLCToPDF(txtAgtCode.Text.Trim());
                                                            }
                                                            else
                                                            {
                                                                lbl5.Text = "Code:-" + txtAgtCode.Text.ToString().Trim();
                                                                lblMessage.Text = "Member Code created successfully Please procced for Document upload <br/>" + lbl5.Text;
                                                                mdlpopup.Show();
                                                            }
                                                        }
                                                    }
                                                    //mdlpopup.Show();
                                                    ////Added by usha for Welcome letter //on 17.01.2021
                                                    //ConvertRDLCToPDF(txtAgtCode.Text.Trim());
                                                }

                                            }
                                            else
                                            {
                                                lbl3.Text = "Agent created successfully.";
                                                lblMessage.Text = "Agent created successfully.";
                                                lbl4.Text = "Agent Name:-" + txtAgntName.Text.Trim();
                                                lbl5.Text = "Agent Code:-" + txtAgtCode.Text.Trim();

                                                #region GetVenBrkDtls
                                                DataSet ds = new DataSet();
                                                ds.Clear();
                                                ds = GetPopDtls(txtAgtCode.Text.ToString().Trim());
                                                if (ds.Tables.Count > 0)
                                                {
                                                    if (ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        lbl6.Text = "Agent Broker Code:-" + ds.Tables[0].Rows[0]["InsMemCode"].ToString().Trim();
                                                        if (Session["VenType"] != null)
                                                        {
                                                            if (Session["VenType"].ToString().Trim() == "DV")
                                                            {
                                                                ds.Clear();
                                                                ds = GetPopDtls(hdnVenCode.Value.ToString().Trim());
                                                                if (ds.Tables.Count > 0)
                                                                {
                                                                    if (ds.Tables[0].Rows.Count > 0)
                                                                    {
                                                                        lbl7.Text = "Vendor Code:-" + hdnVenCode.Value.ToString().Trim() + "<br /><br />Vendor Name:-" + ds.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            mdlpopup.Show();
                                            //Added by swapnesh for showing messagebox on 16/5/2013 End
                                        }
                                        else
                                        {
                                            switch (arrResult[0].ToString())
                                            {
                                                case "-1":
                                                    lblMessage.Text = "Agent Type cannot higher than Recruit Agent Type!";
                                                    txtImmLeaderCode.Focus();
                                                    break;
                                                case "-2":
                                                    lblMessage.Text = "Immediate Agent Level Should Be Valid!";
                                                    break;
                                                case "-3":
                                                    lblMessage.Text = "Agent Type cannot higher than Manager Type!";
                                                    txtMngrCode.Focus();
                                                    break;
                                                case "-4":
                                                    lblMessage.Text = "Manager status should be InForce!";
                                                    txtMngrCode.Focus();
                                                    break;
                                                case "-5":
                                                    lblMessage.Text = "Emp Code Already Exist!";
                                                    break;
                                                default:
                                                    lblMessage.Text = "Error Updating Record";
                                                    break;
                                            }
                                            lblMessage.ForeColor = Color.Red;
                                            lblMessage.Visible = true;
                                            //btnUpdate.Enabled = false;
                                        }
                                    }
                                }
                                else
                                {
                                    lblMessage.Text = arrResult[1].ToString();
                                    lblMessage.ForeColor = Color.Red;
                                    btnUpdate.Enabled = true;
                                }
                            }
                            htable.Clear();
                            btnUpdate.Enabled = true;
                            objSQLTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            objSQLTran.Rollback();
                            lblMessage.Visible = true;
                            lblMessage.Text = ex.Message;
                            btnUpdate.Enabled = false;
                            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                            string sRet = oInfo.Name;
                            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                            String LogClassName = method.ReflectedType.Name;
                            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                        }
                        finally
                        {
                            hdnCreateRule.Value = "";
                            if (Request.QueryString["Ctgry"] != null)
                            {
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                                {
                                    if (lblMessage.Text == "Employee created successfully." || lblMessage.Text == "Employee created successfully.")
                                    {
                                        ErrMsg = "S";
                                        btnUpdate.Enabled = false;
                                    }
                                    else
                                    {
                                        ErrMsg = "E";
                                    }
                                }
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                {
                                    if (lblMessage.Text == "Vendor created successfully." || lblMessage.Text == "Vendor created successfully.")
                                    {
                                        ErrMsg = "S";
                                        btnUpdate.Enabled = false;
                                    }
                                    else
                                    {
                                        ErrMsg = "E";
                                    }
                                }
                            }
                            else
                            {
                                if (lblMessage.Text == "Agent created successfully." || lblMessage.Text == "Agent created successfully.")
                                {
                                    ErrMsg = "S";
                                    btnUpdate.Enabled = false;
                                }
                                else
                                {
                                    ErrMsg = "E";
                                }
                            }

                            if (Request.QueryString["ID"] == "IN")
                            {
                                AuditType = "IN";
                            }
                            else
                            {
                                AuditType = "UP";
                            }
                            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";
                            if (intCode == 0)
                            {
                                ErrSrc = "SQ";
                            }
                            else
                            {
                                ErrSrc = "BO";
                            }
                            objChnSetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + txtAgtCode.Text, "Agn", "AgentInfo,clsAgent.cs", "pri_AgyAdmin_InsAgent", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);

                            if (Request.QueryString["Ctgry"] != null)
                            {
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                                {
                                    if (lblMessage.Text == "Employee created successfully." || lblMessage.Text == "Employee created successfully.")
                                    {
                                        if (intCode == 0)
                                        {
                                            Response.Redirect("AGTInfo.aspx?AgnCd=" + txtAgtCode.Text + "&Type=" + "E" + "&ID=" + Convert.ToString(Request.QueryString["ID"]) + "&Msg=" + lblMessage.Text + "&AgnName=" + txtAgntName.Text + "&Ctgry=Emp", false);
                                        }
                                        else
                                        {
                                            lblMessage.ForeColor = Color.Red;
                                            //lblMessage.Visible = true;
                                            lblMessage.Text = strErrMsg;
                                            lblMessage.Text = ViewState["ErrorMsg"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        lblMessage.ForeColor = Color.Red;
                                        //lblMessage.Visible = true;
                                    }
                                }
                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                {
                                    if (lblMessage.Text == "Vendor created successfully." || lblMessage.Text == "Vendor created successfully.")
                                    {
                                        if (intCode == 0)
                                        {
                                            Response.Redirect("AGTInfo.aspx?Ctgry=Ven&AgnCd=" + txtAgtCode.Text + "&Type=" + "E" + "&ID=" + Convert.ToString(Request.QueryString["ID"]) + "&Msg=" + lblMessage.Text + "&AgnName=" + txtAgntName.Text, false);
                                        }
                                        else
                                        {
                                            lblMessage.ForeColor = Color.Red;
                                            lblMessage.Text = strErrMsg;
                                            lblMessage.Text = ViewState["ErrorMsg"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        lblMessage.ForeColor = Color.Red;
                                    }
                                }
                            }
                            else
                            {
                                if (lblMessage.Text == "Agent created successfully." || lblMessage.Text == "Agent created successfully.")
                                {
                                    if (intCode == 0)
                                    {
                                        Response.Redirect("AGTInfo.aspx?AgnCd=" + txtAgtCode.Text + "&Type=" + "E" + "&ID=" + Convert.ToString(Request.QueryString["ID"]) + "&Msg=" + lblMessage.Text + "&AgnName=" + txtAgntName.Text, false);
                                    }
                                    else
                                    {
                                        lblMessage.ForeColor = Color.Red;
                                        lblMessage.Text = strErrMsg;
                                        lblMessage.Text = ViewState["ErrorMsg"].ToString();
                                    }
                                }
                                else
                                {
                                    lblMessage.ForeColor = Color.Red;
                                }
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
                        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    }
                }
                #endregion
                else
                {
                    try
                    {
                        #region "MultiView1.ActiveViewIndex == 0"

                        try
                        {
                            htParam.Clear();
                            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htParam.Add("@agentCode", txtAgtCode.Text);
                            htParam.Add("@AgentStatus", ddlAgntStatus.SelectedValue);
                            htParam.Add("@PANNo ", txtPanNo.Text.Trim());
                            htParam.Add("@Gender", ddlGender.SelectedValue);
                            htParam.Add("@ClientCode", txtCusmId.Text);
                            htParam.Add("@ExclAgmt", rdlExclusive.SelectedValue);
                            htParam.Add("@Name", txtAgntName.Text);
                            htParam.Add("@AgnTitle", cboagnTitle.SelectedValue);

                            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                            htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                            htParam.Add("@LicenseNo", txtBizLicNo.Text);
                            htParam.Add("@OldLicno", txtBizOldLicNo.Text);
                            if (txtBizOldLicStrtDt.Text.Trim() != "")
                            {
                                htParam.Add("@OldLicnoStrtDt", DateTime.Parse(txtBizOldLicStrtDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@OldLicnoStrtDt", System.DBNull.Value);
                            }
                            if (txtBizOldLicExpDt.Text.Trim() != "")
                            {
                                htParam.Add("@OldLicnoExpDt", DateTime.Parse(txtBizOldLicExpDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@OldLicnoExpDt", System.DBNull.Value);
                            }
                            if (ddlAgntType.Visible == true)
                            {
                                htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                            }
                            else
                            {
                                htParam.Add("@AgentType", hdnAgntType.Value);
                            }
                            if (txtBizLicEndDt.Text.Trim() != "")
                            {
                                htParam.Add("@LicenseEndDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@LicenseEndDate", System.DBNull.Value);
                            }
                            htParam.Add("@AgtClass", ddlAgntClass.SelectedValue);
                            htParam.Add("@PymtMode", ddlPaymentMode.SelectedValue);
                            htParam.Add("@CurrCode", ddlCurrency.SelectedValue);
                            htParam.Add("@AgnCommClass", ddlCommCls.SelectedValue);
                            htParam.Add("@PayFreq", ddlPayFrequency.SelectedValue);
                            htParam.Add("@AccPayeeGCN", txtAccPayee.Text);
                            if (txtMinAmt.Text.Trim() == "")
                            {
                                htParam.Add("@MinAmount", 0);
                            }
                            else
                            {
                                htParam.Add("@MinAmount", Decimal.Parse(txtMinAmt.Text).ToString("0.00"));
                            }
                            htParam.Add("@UserName", txtUserId.Text);
                            if (txtRecruitDate.Text.Trim() != "")
                            {
                                htParam.Add("@RecruitDate", DateTime.Parse(txtRecruitDate.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@RecruitDate", System.DBNull.Value);
                            }
                            htParam.Add("@BranchCode", txtBranchCode.Text);
                            htParam.Add("@RecruitAgentCode", txtRecruitAgntCode.Text);
                            htParam.Add("@AreaCode", txtAreCode.Text);
                            htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text);

                            if (hdnCreateRule.Value == "BM")
                            {
                                htParam.Add("@CSCCode", lblVw1SMCode.Text);
                            }
                            else
                            {
                                htParam.Add("@CSCCode", txtSmCode.Text);
                            }

                            htParam.Add("@EmpCode", txtEmpCode.Text);
                            if (txtCeaseDate.Text.Trim() != "")
                            {
                                htParam.Add("@CeaseDate", DateTime.Parse(txtCeaseDate.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@CeaseDate", System.DBNull.Value);
                            }

                            htParam.Add("@BlkLstStat", ddlBlkLstStatus.SelectedValue);
                            htParam.Add("@Type", Request.QueryString["Type"].ToString());

                            htParam.Add("@OfficeCode", "");
                            htParam.Add("@RecruitAgtCode", txtRecruitAgntCode.Text);
                            htParam.Add("@LanguageCode", Convert.ToString(Session["LanguageCode"]));
                            htParam.Add("@RptUnitCode", hdnUntCode.Value);
                            htParam.Add("@StdOVRate", "1");
                            if (txtBankAccNo.Text != "")
                            {
                                htParam.Add("@BnkAccNo", txtBankAccNo.Text);
                            }
                            else
                            {
                                htParam.Add("@BnkAccNo", System.DBNull.Value);
                            }
                            if (ddlactype.SelectedIndex == 0)
                            {
                                htParam.Add("@BankAcType", System.DBNull.Value);
                            }
                            else
                            {
                                htParam.Add("@BankAcType", ddlactype.SelectedValue);
                            }
                            if (txtBankHolderName.Text != "")
                            {
                                htParam.Add("@AccHolderName", txtBankHolderName.Text);
                            }
                            else
                            {
                                htParam.Add("@AccHolderName", System.DBNull.Value);
                            }
                            //added by sanoj
                            if (txtNeftCode.Text != "")
                            {
                                htParam.Add("@IFSCCode", txtNeftCode.Text);
                            }
                            else
                            {
                                htParam.Add("@IFSCCode", System.DBNull.Value);
                            }
                            if (txtBnkAddress.Text != "")
                            {
                                htParam.Add("@BranchName", txtBnkAddress.Text);
                            }
                            else
                            {
                                htParam.Add("@BranchName", System.DBNull.Value);
                            }
                            if (txtmcrcode.Text != "")
                            {
                                htParam.Add("@MICRCode", txtmcrcode.Text);
                            }
                            else
                            {
                                htParam.Add("@MICRCode", System.DBNull.Value);
                            }
                            //Add Nomine Dtails by sanoj
                            htParam.Add("@NomineeName", txtNomNme.Text.Trim());
                            if (ddlNomnRel.SelectedIndex == 0)
                            {
                                htParam.Add("@NomineeRel", DBNull.Value);
                            }
                            else
                            {
                                htParam.Add("@NomineeRel", ddlNomnRel.Text.Trim());
                            }
                            htParam.Add("@NomineeDOB", txtNomDob.Text.Trim());//txtNomDob.Text.Trim()
                            htParam.Add("@NomineeMobileTel", txtNomMob.Text.Trim());
                            htParam.Add("@NomineeEmailID", txtNomEmail.Text.Trim());


                            //End Nomine Dtails by sanoj
                            //end
                            if (TxtAnnivrsryDt.Text.Trim() != "")
                            {
                                htParam.Add("@AnniversaryDate", TxtAnnivrsryDt.Text);//added by sanoj
                            }
                            else
                            {
                                htParam.Add("@AnniversaryDate ", System.DBNull.Value);
                            }
                            if (txtNeftCode.Text != "")
                            {
                                htParam.Add("@NEFTCode", txtNeftCode.Text);
                            }
                            else
                            {
                                htParam.Add("@NEFTCode", System.DBNull.Value);
                            }

                            if (txtBankName.Text != "")
                            {
                                htParam.Add("@BankName", txtBankName.Text);
                            }
                            else
                            {
                                htParam.Add("@BankName", System.DBNull.Value);
                            }
                            if (txtBankName.Text != "")
                            {
                                htParam.Add("@BnkDesc", txtBankName.Text);
                            }
                            else
                            {
                                htParam.Add("@BnkDesc", System.DBNull.Value);
                            }
                            if (txtBnkBrnchName.Text != "")
                            {
                                htParam.Add("@BnkBrnDesc", txtBnkBrnchName.Text);
                            }
                            else
                            {
                                htParam.Add("@BnkBrnDesc", System.DBNull.Value);
                            }
                            htParam.Add("@DeductTax", ddlDeductTax.SelectedValue);
                            htParam.Add("@TaxCode", ddlTaxCode.SelectedValue);
                            htParam.Add("@MgrCode", hdnRptMgr.Value);



                            #region Add 2 new Fields
                            // Added by Mustafa 14 April 08
                            htParam.Add("@AppVideNo", txt_AppNo.Text.Trim());
                            if (txtDTJoinFrom.Text.Trim() != "")
                            {
                                htParam.Add("@AppDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));

                            }
                            else
                            {
                                htParam.Add("@AppDate", "");
                            }
                            htParam.Add("@ServProvdInfo", txtServProvInfo.Text.Trim());
                            if (txtdoj.Text.Trim() != "")
                            {
                                htParam.Add("@DateOfJoin", DateTime.Parse(txtdoj.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htParam.Add("@DateOfJoin", System.DBNull.Value);
                            }
                            //Add by Darshik for update TPBR 23 Nov 2012 
                            if (txtPartnerName.Text.Trim() != "")
                            {
                                htParam.Add("@PartnerName", txtPartnerName.Text);
                            }
                            else
                            {
                                htParam.Add("@PartnerName", System.DBNull.Value);
                            }
                            if (txtPartnerCode.Text.Trim() != "")
                            {
                                htParam.Add("@PartnerCode", txtPartnerCode.Text);
                            }
                            else
                            {
                                htParam.Add("@PartnerCode", System.DBNull.Value);
                            }
                            //Ended code by Darshik for update 23 NOV 2012
                            #endregion

                            //Added by sanoj
                            //htParam.Add("@ExpMonBusnsHealth", txtExpt.Text);
                            htParam.Add("@ExpMonBusnsHealth", txtExpt1.SelectedValue);//Added by sanoj 15052023
                            htParam.Add("@ExpTeamStrgt", txtExpectTm.Text.Trim());
                            htParam.Add("@ExpAgntInSixMnth", txtAgntMonth.Text);
                            htParam.Add("@ExpAgntInTwelveMnth", txtAgntMonth12.Text);
                            htParam.Add("@ExpPOSPInSixMnth", txtPosp6.Text);
                            htParam.Add("@ExpPOSPInTwelveMnth", txtPosp12.Text);
                            htParam.Add("@DtlsOfOthrbusiness", txtDtlsExtBus.Text);
                            htParam.Add("@MrktingInFinservicebusiness", txtmrktBus.Text);
                            htParam.Add("@DtlsOfLawSuit", txtSrcProvd.Text);
                            htParam.Add("@DtlsOfOthrAssignmt", txtAsnmnet.Text);
                            htParam.Add("@BussinessRemark", txtRemark.Text);



                            htParam.Add("@FacebookId", txtFbId.Text.Trim());
                            htParam.Add("@TwiterId", txtTwt.Text.Trim());
                            htParam.Add("@InstagramId", txtInstId.Text.Trim());
                            htParam.Add("@Education", ddlEducutn.SelectedValue);

                            //ended by sanoj
                            //start update Background / Experince
                            Hashtable htcnct = new Hashtable();
                            htcnct.Clear();
                            htcnct.Add("@Agentode", txtAgtCode.Text);
                            htcnct.Add("@BckgrndExp", "");
                            htcnct.Add("@ExpTime", "");
                            htcnct.Add("@Organization", "");
                            htcnct.Add("@TenureFrm", "");
                            htcnct.Add("@TenureTo", "");
                            htcnct.Add("@CreatedBy", "");
                            htcnct.Add("@Flag", "0");
                            dataAccess.exec_comm_command("Prc_MemBckgrndExp_Ins", htcnct);
                            for (int i = 0; gvComposite.Rows.Count > i; i++)
                            {
                                Label lblExperience = gvComposite.Rows[i].FindControl("lblExperience") as Label;
                                Label lblExpTime = gvComposite.Rows[i].FindControl("lblExpTime") as Label;//remain
                                Label lblOrganization = gvComposite.Rows[i].FindControl("lblOrganization") as Label;
                                Label lblTenureFrom = gvComposite.Rows[i].FindControl("lblTenureFrom") as Label;
                                Label lblTenureTo = gvComposite.Rows[i].FindControl("lblTenureTo") as Label;

                                htcnct.Clear();
                                htcnct.Add("@Agentode", txtAgtCode.Text);
                                htcnct.Add("@BckgrndExp", lblExperience.Text.Trim());
                                htcnct.Add("@ExpTime", lblExpTime.Text.Trim());
                                htcnct.Add("@Organization", lblOrganization.Text.Trim());
                                htcnct.Add("@TenureFrm", "");//null by ajay 18-042023
                                htcnct.Add("@TenureTo", "");//null by ajay 18-042023
                                htcnct.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                                dataAccess.exec_comm_command("Prc_MemBckgrndExp_Ins", htcnct);
                            }
                            //End Background / Experince

                            //ended by sanoj

                            //Added by swapnesh on 11/12/2013 to save Manager & Reporting Info in Agent table start
                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-1")
                            {
                                htParam.Add("@Mgrcode1", System.DBNull.Value);
                                htParam.Add("@Mgrcode2", System.DBNull.Value);
                                htParam.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-2")
                            {
                                htParam.Add("@Mgrcode1", System.DBNull.Value);
                                htParam.Add("@Mgrcode2", System.DBNull.Value);
                                htParam.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            if (lbladditionalreportingrule.Text.Trim() == "Multiple-3")
                            {
                                htParam.Add("@Mgrcode1", System.DBNull.Value);
                                htParam.Add("@Mgrcode2", System.DBNull.Value);
                                htParam.Add("@Mgrcode3", System.DBNull.Value);
                            }
                            //Added by swapnesh on 11/12/2013 to save Manager & Reporting Info in Agent table end

                            //Added by Akshay on 27/12/2013 to update Client details start
                            htParam.Add("@ChnlType", rdbChnlTyp.SelectedValue);
                            if (Session["lictype"] != null)
                            {
                                htParam.Add("@Licflag", Session["lictype"].ToString().Trim());

                                #region Insert Client Contact Details


                                //Hashtable htcnct = new Hashtable();
                                htcnct.Clear();

                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "P1");
                                htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                htcnct.Add("@StateCode", ddlState.SelectedValue);
                                htcnct.Add("@District", txtDistP.Text.Trim());
                                htcnct.Add("@Area", txtarea.Text);
                                htcnct.Add("@City", txtcity.Text);
                                htcnct.Add("@Village", txtVillage.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                htcnct.Add("@flagclt", "MapClt");
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                htcnct.Clear();
                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "B1");
                                htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                htcnct.Add("@Area", txtarea0.Text);
                                htcnct.Add("@City", txtcity0.Text);
                                htcnct.Add("@Village", txtBvillage.Text.Trim());
                                htcnct.Add("@District", txtDistB.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                htcnct.Add("@flagclt", "MapClt");
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                if (ChkPABusns.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                    htcnct.Add("@Area", txtarea0.Text);
                                    htcnct.Add("@City", txtcity0.Text);
                                    htcnct.Add("@Village", txtPermVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistB.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                    htcnct.Add("@flagclt", "MapClt");
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                if (ChkPARes.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState.SelectedValue);
                                    htcnct.Add("@Area", txtarea.Text);
                                    htcnct.Add("@City", txtcity.Text);
                                    htcnct.Add("@Village", txtVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistP.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                    htcnct.Add("@flagclt", "MapClt");
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                //end uncommented by sanoj
                                #endregion

                                int chkpref;
                                string chkstf;
                                string chktax;
                                if (Session["lictype"].ToString().Trim() == "C")
                                {
                                    if (chkSalesTax.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    if (chkVip.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    //added  by sanoj 16052023
                                    if (cboMaritalStatus.SelectedIndex != 0)
                                    {
                                        htParam.Add("@MStat", cboMaritalStatus.SelectedValue);//
                                    }
                                    else
                                    {
                                        htParam.Add("@MStat", System.DBNull.Value);
                                    }
                                    //ended  by sanoj 16052023
                                    htParam.Add("@GCN", txtCusmId.Text.Trim());
                                    htParam.Add("@SName", txtSurname.Text.Trim());
                                    htParam.Add("@Econ", ddlEcon.SelectedValue);
                                    htParam.Add("@DOB", txtDOB.Text);
                                    htParam.Add("@BrthPl", txtBirthPlace.Text.Trim());
                                    htParam.Add("@AnnTrn", txtAnnTurnover.Text.Trim());
                                    htParam.Add("@Capital", txtCapital.Text.Trim());
                                    htParam.Add("@StfSize", txtStaffSz.Text.Trim());
                                    htParam.Add("@Title", cboTitle.SelectedValue);
                                    htParam.Add("@PrfClt", chkpref.ToString());
                                    htParam.Add("@TaxStat", chktax);
                                }
                                else
                                {
                                    if (CheckBox2.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    if (chkStaff.Checked == true)
                                    {
                                        chkstf = "Y";
                                    }
                                    else
                                    {
                                        chkstf = "N";
                                    }
                                    if (chkprefclt.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    htParam.Add("@GCN", txtCusmId.Text.Trim());
                                    if (txtDOB.Text != "")
                                    {
                                        htParam.Add("@DOB", txtDOB.Text.Trim());
                                    }
                                    else
                                    {
                                        htParam.Add("@DOB", DBNull.Value);
                                    }
                                    htParam.Add("@SpInd", DBNull.Value);

                                    if (cboMaritalStatus.SelectedIndex != 0)
                                    {
                                        htParam.Add("@MStat", cboMaritalStatus.SelectedValue);//
                                    }
                                    else
                                    {
                                        htParam.Add("@MStat", System.DBNull.Value);
                                    }
                                    htParam.Add("@SOE", ddlSOE.SelectedValue);
                                    htParam.Add("@Ntnlty", txtNationalCode.Text.Trim());
                                    htParam.Add("@Catgry", ddlCategory.SelectedValue);
                                    if (txtSAPcode.Text != "")
                                    {
                                        htParam.Add("@SAPcode", txtSAPcode.Text.Trim());
                                    }
                                    else
                                    {
                                        htParam.Add("@SAPcode", DBNull.Value);
                                    }
                                    htParam.Add("@QualC", cboQualCode.SelectedValue);
                                    htParam.Add("@QualD", cboQualCode.SelectedValue);
                                    htParam.Add("@OcpnCode01", txtOccupationCode.Text.Trim());
                                    htParam.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
                                    htParam.Add("@Height", txtHeight1.Text.Trim());
                                    htParam.Add("@Weight", txtWeight.Text.Trim());
                                    htParam.Add("@AltIdTyp", cboOtherIDType.SelectedValue);
                                    htParam.Add("@AltId", txtOthersID.Text.Trim());
                                    htParam.Add("@remark", Menu1.Text.Trim());
                                    htParam.Add("@Income", txtALIncome.Text.Trim());
                                    htParam.Add("@PrfClt", chkpref.ToString());
                                    htParam.Add("@Staff", chkstf);
                                    htParam.Add("@TaxStat", chktax);
                                }
                                htParam.Add("@HTelno", txtHomeTel.Text.Trim());
                                htParam.Add("@OTelno", txtWorkTel.Text.Trim());
                                htParam.Add("@DIDTelno", "");
                                htParam.Add("@mobno", txtMobileTel.Text.Trim());
                                htParam.Add("@email", txtEmail.Text.Trim());
                                htParam.Add("@mobno2", txtMobileTel2.Text.Trim());
                                htParam.Add("@email2", txtEmail2.Text.Trim());
                                htParam.Add("@Pager", txtPager.Text.Trim());
                                htParam.Add("@Fax", txtFax.Text.Trim());
                                htParam.Add("@CnctType", ddlCnctType.SelectedValue);
                            }
                            //Added by Akshay on 27/12/2013 to update Client details end

                            #region "prjXml"
                            ArrayList arrLst = new ArrayList();
                            arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                            arrLst.Add(new prjXml.Collection("AgentCode", txtAgtCode.Text));
                            arrLst.Add(new prjXml.Collection("AgentStatus", ddlAgntStatus.SelectedValue));
                            arrLst.Add(new prjXml.Collection("CustomerId", txtCusmId.Text));
                            arrLst.Add(new prjXml.Collection("Exclusive", rdlExclusive.SelectedValue));
                            arrLst.Add(new prjXml.Collection("AgentName", txtAgntName.Text));
                            arrLst.Add(new prjXml.Collection("BizSrc", ddlSlsChannel.SelectedValue.ToString()));
                            arrLst.Add(new prjXml.Collection("ChnSubCls", ddlChnCls.SelectedValue));
                            arrLst.Add(new prjXml.Collection("BizLicsNo", txtBizLicNo.Text));
                            if (ddlAgntType.Visible == true)
                            {
                                arrLst.Add(new prjXml.Collection("AgentType", ddlAgntType.SelectedValue));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("AgentType", hdnAgntType.Value));
                            }
                            if (txtBizLicEndDt.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("BizLicsExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("BizLicsExpDate", ""));
                            }
                            arrLst.Add(new prjXml.Collection("AgentClass", ddlAgntClass.SelectedValue));
                            arrLst.Add(new prjXml.Collection("PayMethod", ddlPaymentMode.SelectedValue));
                            arrLst.Add(new prjXml.Collection("Currency", ddlCurrency.SelectedValue));
                            arrLst.Add(new prjXml.Collection("CommCls", ddlCommCls.SelectedValue));
                            arrLst.Add(new prjXml.Collection("PayFreq", ddlPayFrequency.SelectedValue));
                            arrLst.Add(new prjXml.Collection("AccPayCode", txtAccPayee.Text));
                            if (txtMinAmt.Text.Trim() == "")
                            {
                                arrLst.Add(new prjXml.Collection("MinAmt", "0"));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("MinAmt", Decimal.Parse(txtMinAmt.Text).ToString("0.00")));
                            }
                            arrLst.Add(new prjXml.Collection("UserId", txtUserId.Text));
                            if (txtRecruitDate.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("RecruitDate", DateTime.Parse(txtRecruitDate.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("RecruitDate", ""));
                            }
                            arrLst.Add(new prjXml.Collection("BEBranchCode", txtBranchCode.Text));
                            arrLst.Add(new prjXml.Collection("RecruitAgntCode", txtRecruitAgntCode.Text));
                            arrLst.Add(new prjXml.Collection("BEAreaCode", txtAreCode.Text));
                            arrLst.Add(new prjXml.Collection("ImmLeader", txtImmLeaderCode.Text));
                            if (hdnCreateRule.Value == "BM")
                            {
                                arrLst.Add(new prjXml.Collection("BESMCode", lblVw1SMCode.Text));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("BESMCode", txtSmCode.Text));
                            }

                            arrLst.Add(new prjXml.Collection("UnitCode", hdnUntCode.Value));
                            if (txtCeaseDate.Text.Trim() != "")
                            {
                                arrLst.Add(new prjXml.Collection("DateTerminated", DateTime.Parse(txtCeaseDate.Text).ToString("yyyyMMdd")));
                            }
                            else
                            {
                                arrLst.Add(new prjXml.Collection("DateTerminated", ""));
                            }
                            arrLst.Add(new prjXml.Collection("BlackListStatus", ddlBlkLstStatus.SelectedValue));
                            arrLst.Add(new prjXml.Collection("EmployeeCode", txtEmpCode.Text));
                            arrLst.Add(new prjXml.Collection("NEFTCode", txtNeftCode.Text));
                            arrLst.Add(new prjXml.Collection("BnkAccNo", txtBankAccNo.Text));
                            arrLst.Add(new prjXml.Collection("AccHolderName", txtBankHolderName.Text));
                            arrLst.Add(new prjXml.Collection("BnkDesc", txtBankName.Text));
                            arrLst.Add(new prjXml.Collection("BnkBrnDesc", txtBnkBrnchName.Text));
                            arrLst.Add(new prjXml.Collection("DeductTax", ddlDeductTax.SelectedValue));
                            arrLst.Add(new prjXml.Collection("TaxCode", ddlTaxCode.SelectedValue));
                            arrLst.Add(new prjXml.Collection("MgrCode", txtRptMgr.Text.Trim()));
                            arrLst.Add(new prjXml.Collection("RptUnitCode", hdnUntCode.Value.Trim()));
                            prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                            XmlDocument xDoc = new XmlDocument();
                            xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                            strXML = xDoc.OuterXml;
                            arrLst.Clear();
                            //Ended code by venkat
                            arrResult = agentObject.UpdateAgentDetailsPage1(htParam, "prc_AgyAdmin_updAgtDt");
                            #endregion
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

                        #endregion

                        if (arrResult.Count > 0)
                        {
                            if (arrResult[0].ToString() != "F")
                            {
                                if (arrResult.Count > 0)
                                {
                                    if (arrResult[0].ToString().Equals("0"))
                                    {
                                        if (arrResult[1].ToString().Equals("0"))
                                        {
                                            //Added by swapnesh for showing messagebox on 16/5/2013 start
                                            if (Request.QueryString["Ctgry"] != null)
                                            {
                                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                                                {
                                                    lbl3.Text = "Employee updated successfully.";
                                                    lblMessage.Text = "Employee updated successfully.";
                                                    lbl4.Text = "Employee Name:-" + txtAgntName.Text;
                                                    lbl5.Text = "Employee Code:-" + txtAgtCode.Text;
                                                    lbl6.Text = "SAP Code:-" + txtSAPcode.Text.Trim();
                                                }
                                                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                                                {
                                                    lbl3.Text = "Data updated successfully.";
                                                    lblMessage.Text = "Data updated successfully.";
                                                   
                                                    DataSet ds = new DataSet();
                                                    ds.Clear();
                                                    ds = GetPopDtls(txtAgtCode.Text.ToString().Trim());
                                                    if (ds.Tables.Count > 0)
                                                    {

                                                        //added by sanoj 17052023
                                                        if (ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            if (ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim() == "" || ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim() == null)
                                                            {
                                                                lbl4.Text = "Name:-" + txtAgntName.Text;
                                                                lbl5.Text = "Code:-" + txtAgtCode.Text;
                                                                lbl6.Visible = false;
                                                            }
                                                            else
                                                            {
                                                                lbl6.Visible = false;
                                                                lbl4.Text = "Franchisee Name:-" + txtAgntName.Text;
                                                                lbl5.Text = "Franchisee Code:-" + ds.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                                                            }
                                                            
                                                        }
                                                        //endded by sanoj 17052023
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lbl3.Text = "Agent updated successfully.";
                                                lblMessage.Text = "Agent updated successfully.";
                                                lbl4.Text = "Agent Name:-" + txtAgntName.Text;
                                                lbl5.Text = "Agent Code:-" + txtAgtCode.Text;
                                                lbl6.Text = "Agent Broker Code:-" + hdnBrkCode.Value.ToString().Trim();
                                                if (Session["AdlVentyp"] != null)
                                                {
                                                    if (Session["AdlVentyp"].ToString().Trim() == "DV")
                                                    {
                                                        if (Session["vencode"] != null)
                                                        {
                                                            if (Session["venname"] != null)
                                                            {
                                                                lbl7.Text = "Vendor Code:-" + Session["vencode"].ToString().Trim() + "<br /><br />Vendor Name:-" + Session["venname"].ToString().Trim() + " " + txtAgntName.Text.Trim();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            mdlpopup.Show();

                                            //Added by swapnesh for showing messagebox on 16/5/2013 End

                                            lblMessage.ForeColor = Color.Red;
                                            btnUpdate.Enabled = true;

                                        }
                                        else
                                        {
                                            switch (arrResult[1].ToString())
                                            {
                                                case "-1":
                                                    lblMessage.Text = "Agent Record Not Found!";
                                                    break;
                                                case "-2":
                                                    lblMessage.Text = "Recruit Agent Record not found";
                                                    break;
                                                case "-3":
                                                    lblMessage.Text = "Recruit Agent Not an Inforce Agent";
                                                    break;
                                                case "-4":
                                                    lblMessage.Text = "Recruit Agent Type must higher than Agent";
                                                    break;
                                                case "-5":
                                                    lblMessage.Text = "Recruit Agent Unit Info Not Set";
                                                    break;
                                                case "-6":
                                                    lblMessage.Text = "Recruit Leader Reporting Unit is not Valid/Active";
                                                    break;
                                                case "7":
                                                    lblMessage.Text = "Please setup Recruit Agent OR Master Commission first";
                                                    break;
                                                case "-8":
                                                    lblMessage.Text = "Agent Previous Joined Record Exists. Agent not allow to have finance scheme compensation.";
                                                    break;
                                                case "-9":
                                                    lblMessage.Text = "Agent Commission Statement Found, not allow to change Agent Recruiter And OR Comm. Setup.";
                                                    break;
                                                case "-10":
                                                    lblMessage.Text = "Branch Office Code not exists";
                                                    break;
                                                case "-11":
                                                    lblMessage.Text = "Agent Unit info not set";
                                                    break;
                                                case "-12":
                                                    lblMessage.Text = "Unit Code must be a valid sales unit code of the channel";
                                                    break;
                                                case "-13":
                                                    lblMessage.Text = "Unit Code must be valid Master Company Unit Code or Channel Unit Code";
                                                    break;
                                                case "-14":
                                                    lblMessage.Text = "Unit Code Not Found!";
                                                    break;
                                                case "-15":
                                                    lblMessage.Text = "Unit Code must be same rank with the Agent Code";
                                                    break;
                                                case "-16":
                                                    lblMessage.Text = "Agent and Immediate Leader must report to the same Unit Code";
                                                    break;
                                                case "-17":
                                                    lblMessage.Text = "Direct Agent Type must be PU and above";
                                                    break;
                                                case "-18":
                                                    lblMessage.Text = "Please setup Direct Agent OR Master Commission first";
                                                    break;
                                                default:
                                                    lblMessage.Text = "-" + arrResult[1].ToString();
                                                    break;
                                            }
                                            lblMessage.ForeColor = Color.Red;
                                            lblMessage.Visible = true;
                                            //btnUpdate.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        switch (arrResult[0].ToString())
                                        {
                                            case "-1":
                                                lblMessage.Text = "Terminate Agent";
                                                break;
                                            case "-2":
                                                lblMessage.Text = "Agent is black listed client";
                                                break;
                                            case "-3":
                                                lblMessage.Text = "Duplicate Surname & Given name!";
                                                break;
                                            case "-4":
                                                lblMessage.Text = "Agent Type cannot higher than Recruit Agent Type!";
                                                break;
                                            case "-5":
                                                lblMessage.Text = "Emp Code Already Exist!";
                                                break;
                                            default:
                                                lblMessage.Text = "";
                                                break;
                                        }
                                        lblMessage.ForeColor = Color.Red;
                                        lblMessage.Visible = true;
                                        btnUpdate.Enabled = true;
                                    }
                                    if (Request.QueryString["Type"].ToString() == "N")
                                    {
                                        switch (arrResult[1].ToString())
                                        {
                                            case "1":
                                                lblMessage.Text = lblMessage.Text + "<br />" + "Current Id exists/Re-Joint Agent Detected";
                                                break;
                                            case "2":
                                                lblMessage.Text = lblMessage.Text + "<br />" + "Re-Joint Agent Detected";
                                                break;
                                        }
                                    }
                                }
                                //Added code by venkat on 16/02/2008								
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = true;
                                //Ended code
                            }
                            else
                            {
                                lblMessage.Text = arrResult[1].ToString();
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = true;
                                btnUpdate.Enabled = true;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Error Updating Agent Details.";
                            lblMessage.ForeColor = Color.Red;
                            lblMessage.Visible = true;
                            btnUpdate.Enabled = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                        string sRet = oInfo.Name;
                        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                        String LogClassName = method.ReflectedType.Name;
                        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    }

                    if (lblMessage.Text == "Agent created successfully.")
                    {
                        ErrMsg = "S";
                        hdnAgnCreateRul.Value = "";
                    }
                    else
                    {
                        ErrMsg = "E";
                        hdnAgnCreateRul.Value = "";
                    }
                    if (Request.QueryString["ID"] == "IN" && Request.QueryString["Type"] == "E")
                    {
                        AuditType = "UP";
                    }
                    else
                    {
                        AuditType = "";
                    }
                    string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";
                    if (intCode == 0)
                    {
                        ErrSrc = "SQ";
                    }
                    else
                    {
                        ErrSrc = "BO";
                    }
                    objChnSetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + txtAgtCode.Text, "Agn", "AgtInfo,clsAgent.cs", "prc_AgyAdmin_updAgtDt", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);


                    htParam.Clear();
                    htParam = null;
                    arrResult.Clear();
                    arrResult = null;
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.Red;
                }
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

        public void InsertUntRelDtls()
        {
            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Clear();
            ds.Clear();
            for (int i = 0; gvUntLst.Rows.Count > i; i++)
            {
                Label lblUntCode = (Label)gvUntLst.Rows[i].FindControl("lblUntCode");
                ht.Clear();
                ht.Add("@CarrierCode", "2");
                ht.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                ht.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                ht.Add("@MemType", ddlAgntType.SelectedValue.Trim());
                ht.Add("@UnitCode", lblUntCode.Text);
                ht.Add("@MgrCode", txtAgtCode.Text);
                ht.Add("@DirectMgrCode", "");
                ht.Add("@CreateBy", txtUserId.Text);
                ht.Add("@RecruitDate", "");
                ht.Add("@EMPCode", txtEmpCode.Text);
                ds = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_InsertUntMgr_Create", ht);
            }
        }

        #region InsertRptMngrDtls
        public string InsertRptMngrDtls()
        {
            #region Insert reporting manager
            Hashtable htmgrprm = new Hashtable();
            DataSet dsrptmgr = new DataSet();
            DataSet dsprrptmgr = new DataSet();
            htmgrprm.Clear();
            dsrptmgr.Clear();

            for (int i = 0; gv.Rows.Count > i; i++)
            {
                Label MemCode = (Label)gv.Rows[i].FindControl("lblMemCode");
                htmgrprm.Clear();
                htmgrprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htmgrprm.Add("@BizSrc ", ddlSlsChannel.SelectedValue.ToString());
                htmgrprm.Add("@ChnSubCls", ddlChnCls.SelectedValue);
                htmgrprm.Add("@AgentType", ddlAgntType.SelectedValue);
                htmgrprm.Add("@ConstCode", ddlLicTyp.SelectedValue);
                htmgrprm.Add("@ConstRole", Session["ConstiRole"].ToString().Trim());
                htmgrprm.Add("@AgentCode ", txtAgtCode.Text);
                htmgrprm.Add("@UserId", txtUserId.Text);
                htmgrprm.Add("@relorder", 0);
                htmgrprm.Add("@reltyp", ddlamrptdesc.SelectedValue);
                htmgrprm.Add("@RelBizsrc", ddlamchnldesc.SelectedValue);
                htmgrprm.Add("@RelChnCls", ddlamsubchnldesc.SelectedValue);
                htmgrprm.Add("@RelAgenttype", ddllvlagttype.SelectedValue);
                htmgrprm.Add("@RelAgentcode", MemCode.Text);
                htmgrprm.Add("@IsVendor", "N");
                htmgrprm.Add("@PrimaryFlag", "0");
                htmgrprm.Add("@UnitCode ", "");
                htmgrprm.Add("@AgentStatus ", ddlAgntStatus.SelectedValue);
                dsprrptmgr = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_InsRptMgrDtls", htmgrprm);
            }
            for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
            {
                CheckBox chkisprimry = gv_RptMngr.Rows[i].FindControl("chkisprimry") as CheckBox;

                DropDownList ddlventype = gv_RptMngr.Rows[i].FindControl("ddlAddlventype") as DropDownList;
                DropDownList ddlRelModel = gv_RptMngr.Rows[i].FindControl("ddlRelModel") as DropDownList;

                DropDownList ddlAdlRptTyp = gv_RptMngr.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                DropDownList ddlAdlChn = gv_RptMngr.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                DropDownList ddlAdlSChn = gv_RptMngr.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                DropDownList ddlAdlBsdOn = gv_RptMngr.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                DropDownList ddlAdlAgtTyp = gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
                Label lblord = (Label)gv_RptMngr.Rows[i].FindControl("lblord");

                TextBox txtRptMngr = gv_RptMngr.Rows[i].FindControl("txtRptMngr") as TextBox;

                HiddenField hdnAddlRptMgr = gv_RptMngr.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;
                HiddenField hdnRptMgrMandatory = gv_RptMngr.Rows[i].FindControl("hdnRptMgrMandatory") as HiddenField;

                DropDownList ddladlRptLvl = gv_RptMngr.Rows[i].FindControl("ddlRptLvl") as DropDownList;
                //////oCommon.getDropDown(ddlventype, "ventype", 1, "", 1, c_strBlank);
                GridView gvAddlMgr = gv_RptMngr.Rows[i].FindControl("gvAddlMgr") as GridView;

                #region AddlManager
                for (int ig = 0; gvAddlMgr.Rows.Count > ig; ig++)
                {
                    Label RptMemCode = (Label)gvAddlMgr.Rows[ig].FindControl("lblMemCode");

                    htmgrprm.Clear();
                    htmgrprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htmgrprm.Add("@BizSrc ", ddlSlsChannel.SelectedValue.ToString());
                    htmgrprm.Add("@ChnSubCls", ddlChnCls.SelectedValue);
                    htmgrprm.Add("@AgentType", ddlAgntType.SelectedValue);
                    htmgrprm.Add("@ConstCode", ddlLicTyp.SelectedValue);
                    htmgrprm.Add("@ConstRole", Session["ConstiRole"].ToString().Trim());
                    htmgrprm.Add("@AgentCode ", txtAgtCode.Text);
                    htmgrprm.Add("@UserId", txtUserId.Text);
                    htmgrprm.Add("@relorder", lblord.Text.Trim());
                    htmgrprm.Add("@reltyp", ddlAdlRptTyp.SelectedValue);
                    htmgrprm.Add("@RelBizsrc", ddlAdlChn.SelectedValue);
                    htmgrprm.Add("@RelChnCls", ddlAdlSChn.SelectedValue);
                    htmgrprm.Add("@RelAgentcode", RptMemCode.Text);
                    htmgrprm.Add("@UnitCode ", "");
                    htmgrprm.Add("@AgentStatus ", ddlAgntStatus.SelectedValue);
                    htmgrprm.Add("@RelAgenttype", ddlAdlAgtTyp.SelectedValue);
                    htmgrprm.Add("@AgnVenRelType", ddlRelModel.SelectedValue);
                    if (ddlAdlAgtTyp.SelectedValue == "RF")
                    {
                        if (ddlventype.SelectedValue == "DV")
                        {
                            htmgrprm.Add("@AgentName", txtAgntName.Text.Trim() + " " + "DEFAULT");
                            Session["VenType"] = ddlventype.SelectedValue.ToString().Trim();
                            htmgrprm.Add("@IsVendor", "Y");

                            #region inser default vendor details
                            if (chkisprimry.Checked == true)
                            {
                                htmgrprm.Add("@PrimaryFlag", "1");
                            }
                            else
                            {
                                htmgrprm.Add("@PrimaryFlag", "0");
                            }

                            #region Client Creation
                            //Added by swapnesh on 23/12/2013 to save Client details start
                            if (Session["lictype"] != null)
                            {
                                if (Request.QueryString["Type"].ToString().Trim() != "Clt")
                                {
                                    htParam.Clear();
                                    dsResult.Clear();
                                    dsResult = dataAccess.GetDataSetForPrc("Prc_GetMaxGCN", htParam);
                                    txtCusmId.Text = dsResult.Tables[0].Rows[0]["ClientCode"].ToString().Trim();
                                }

                                htmgrprm.Add("@Licflag", Session["lictype"].ToString().Trim());

                                #region Insert Client Contact Details
                                Hashtable htcnct = new Hashtable();
                                htcnct.Clear();
                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "P1");
                                htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                htcnct.Add("@StateCode", ddlState.SelectedValue);
                                htcnct.Add("@Area", txtarea.Text);
                                htcnct.Add("@City", txtcity.Text);
                                htcnct.Add("@Village", txtVillage.Text.Trim());
                                htcnct.Add("@District", txtDistP.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                if (Request.QueryString["Type"] != null)
                                {
                                    if (Request.QueryString["Type"].ToString() == "Clt")
                                    {
                                        htcnct.Add("@flagclt", "MapClt");
                                    }
                                    else
                                    {
                                        htcnct.Add("@flagclt", "NewClt");
                                    }
                                }
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);

                                htcnct.Clear();
                                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                htcnct.Add("@CnctType", "B1");
                                htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                //htcnct.Add("@StateCode", txtStateCodeB.Text.Trim());
                                htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                htcnct.Add("@Area", txtarea0.Text);
                                htcnct.Add("@City", txtcity0.Text);
                                htcnct.Add("@Village", txtBvillage.Text.Trim());
                                htcnct.Add("@District", txtDistB.Text.Trim());
                                htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                if (Request.QueryString["Type"] != null)
                                {
                                    if (Request.QueryString["Type"].ToString() == "Clt")
                                    {
                                        htcnct.Add("@flagclt", "MapClt");
                                    }
                                    else
                                    {
                                        htcnct.Add("@flagclt", "NewClt");
                                    }
                                }
                                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);

                                if (ChkPABusns.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrB1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrB2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrB3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinB.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState0.SelectedValue);
                                    htcnct.Add("@Area", txtarea0.Text);
                                    htcnct.Add("@City", txtcity0.Text);
                                    htcnct.Add("@Village", txtBvillage.Text.Trim());
                                    htcnct.Add("@District", txtDistB.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeB.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                if (ChkPARes.Checked == true)
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtAddrP1.Text.Trim());
                                    htcnct.Add("@Adr2", txtAddrP2.Text.Trim());
                                    htcnct.Add("@Adr3", txtAddrP3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPinP.Text.Trim());
                                    //htcnct.Add("@StateCode", txtStateCodeP.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState.SelectedValue);
                                    htcnct.Add("@Area", txtarea.Text);
                                    htcnct.Add("@City", txtcity.Text);
                                    htcnct.Add("@Village", txtVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistP.Text.Trim());
                                    htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                //AddedControl by usha

                                else
                                {
                                    htcnct.Clear();
                                    htcnct.Add("@GCN", txtCusmId.Text.Trim());
                                    htcnct.Add("@CnctType", "M1");
                                    htcnct.Add("@Adr1", txtPermAdd1.Text.Trim());
                                    htcnct.Add("@Adr2", txtPermAdd2.Text.Trim());
                                    htcnct.Add("@Adr3", txtPermAdd3.Text.Trim());
                                    htcnct.Add("@PostCode", txtPermPostcode.Text.Trim());
                                    //htcnct.Add("@StateCode", txtStateCodeP.Text.Trim());
                                    htcnct.Add("@StateCode", ddlState1.SelectedValue);
                                    htcnct.Add("@Area", txtarea1.Text);
                                    htcnct.Add("@City", txtcity1.Text);
                                    htcnct.Add("@Village", txtPermVillage.Text.Trim());
                                    htcnct.Add("@District", txtDistric.Text.Trim());
                                    htcnct.Add("@CntryCode", txtPermCountryCode.Text.Trim());
                                    if (Request.QueryString["Type"] != null)
                                    {
                                        if (Request.QueryString["Type"].ToString() == "Clt")
                                        {
                                            htcnct.Add("@flagclt", "MapClt");
                                        }
                                        else
                                        {
                                            htcnct.Add("@flagclt", "NewClt");
                                        }
                                    }
                                    dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
                                }
                                #endregion

                                int chkpref;
                                string chkstf, chktax;

                                if (Session["lictype"].ToString().Trim() == "C")
                                {
                                    if (chkVip.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    if (chkStaff.Checked == true)
                                    {
                                        chkstf = "Y";
                                    }
                                    else
                                    {
                                        chkstf = "N";
                                    }
                                    if (chkSalesTax.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    htmgrprm.Add("@GCN", txtCusmId.Text.Trim());
                                    htmgrprm.Add("@SName", txtSurname.Text.Trim());
                                    htmgrprm.Add("@Econ", ddlEcon.SelectedValue);
                                    htmgrprm.Add("@DOB", txtDOB1.Text);
                                    htmgrprm.Add("@BrthPl", txtBirthPlace.Text.Trim());
                                    htmgrprm.Add("@AnnTrn", txtAnnTurnover.Text.Trim());
                                    htmgrprm.Add("@Capital", txtCapital.Text.Trim());
                                    htmgrprm.Add("@StfSize", txtStaffSz.Text.Trim());
                                    htmgrprm.Add("@PrfClt", Convert.ToString(chkpref));
                                    htmgrprm.Add("@Staff", chkstf);
                                    htmgrprm.Add("@TaxStat", chktax);
                                    htmgrprm.Add("@Title", cboTitle.SelectedValue);
                                }
                                else
                                {
                                    if (chkprefclt.Checked == true)
                                    {
                                        chkpref = 1;
                                    }
                                    else
                                    {
                                        chkpref = 0;
                                    }
                                    if (chkStaff.Checked == true)
                                    {
                                        chkstf = "Y";
                                    }
                                    else
                                    {
                                        chkstf = "N";
                                    }
                                    if (CheckBox2.Checked == true)
                                    {
                                        chktax = "Y";
                                    }
                                    else
                                    {
                                        chktax = "N";
                                    }
                                    htmgrprm.Add("@GCN", txtCusmId.Text.Trim());
                                    if (txtDOB.Text != "")
                                    {
                                        htmgrprm.Add("@DOB", txtDOB.Text.Trim());
                                    }
                                    else
                                    {
                                        htmgrprm.Add("@DOB", DBNull.Value);
                                    }
                                    htmgrprm.Add("@SpInd", DBNull.Value);
                                    htmgrprm.Add("@MStat", cboMaritalStatus.SelectedValue);
                                    htmgrprm.Add("@SOE", ddlSOE.SelectedValue);
                                    htmgrprm.Add("@Ntnlty", txtNationalCode.Text.Trim());
                                    htmgrprm.Add("@Catgry", ddlCategory.SelectedValue);
                                    if (txtSAPcode.Text != "")
                                    {
                                        htmgrprm.Add("@SAPcode", txtSAPcode.Text.Trim());
                                    }
                                    else
                                    {
                                        htmgrprm.Add("@SAPcode", DBNull.Value);
                                    }
                                    htmgrprm.Add("@QualC", cboQualCode.SelectedValue);
                                    htmgrprm.Add("@QualD", cboQualCode.SelectedValue);
                                    htmgrprm.Add("@OcpnCode01", txtOccupationCode.Text.Trim());
                                    htmgrprm.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
                                    htmgrprm.Add("@Height", txtHeight1.Text.Trim());
                                    htmgrprm.Add("@Weight", txtWeight.Text.Trim());
                                    htmgrprm.Add("@AltIdTyp", cboOtherIDType.SelectedValue);
                                    htmgrprm.Add("@AltId", txtOthersID.Text.Trim());
                                    htmgrprm.Add("@remark", Menu1.Text.Trim());
                                    htmgrprm.Add("@Income", txtALIncome.Text.Trim());
                                    htmgrprm.Add("@PrfClt", Convert.ToString(chkpref));
                                    htmgrprm.Add("@Staff", chkstf);
                                    htmgrprm.Add("@TaxStat", chktax);
                                }

                                htmgrprm.Add("@HTelno", txtHomeTel.Text.Trim());
                                htmgrprm.Add("@OTelno", txtWorkTel.Text.Trim());
                                htmgrprm.Add("@DIDTelno", "");
                                htmgrprm.Add("@mobno", txtMobileTel.Text.Trim());
                                htmgrprm.Add("@email", txtEmail.Text.Trim());
                                htmgrprm.Add("@mobno2", txtMobileTel2.Text.Trim());
                                htmgrprm.Add("@email2", txtEmail2.Text.Trim());
                                htmgrprm.Add("@Pager", txtPager.Text.Trim());
                                htmgrprm.Add("@Fax", txtFax.Text.Trim());
                                htmgrprm.Add("@CnctType", ddlCnctType.SelectedValue);
                            }
                            if (Request.QueryString["Type"] != null)
                            {
                                if (Request.QueryString["Type"].ToString() == "Clt")
                                {
                                    htmgrprm.Add("@flagclt", "MapClt");
                                }
                                else
                                {
                                    htmgrprm.Add("@flagclt", "NewClt");
                                }
                            }
                            //Added by swapnesh on 23/12/2013 to save Client details end
                            #endregion

                            htmgrprm.Add("@BizLicsNo", txtBizLicNo.Text);
                            if (txtBizLicEndDt.Text.Trim() != "")
                            {
                                htmgrprm.Add("@BizLicsExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
                            }
                            else
                            {
                                htmgrprm.Add("@BizLicsExpDate ", System.DBNull.Value);
                            }
                            htmgrprm.Add("@MgrCode", hdnRptMgr.Value);
                            htmgrprm.Add("@ChnlType", rdbChnlTyp.SelectedValue);

                            htmgrprm.Add("@Mgrcode1", hdnAddlRptMgr.Value);
                            htmgrprm.Add("@PANNo ", txtPanNo.Text.Trim());

                            htmgrprm.Add("@Gender", ddlGender.SelectedValue);
                            ///added by akshay on 17/01/14 start
                            byte[] imgres1 = InsertImg();
                            htmgrprm.Add("@Img", imgres1);
                            ///added by akshay on 17/01/14 end
                            if (ddlventype.SelectedValue != null)
                            {
                                htmgrprm.Add("@VenTyp", ddlventype.SelectedValue);
                            }
                            else
                            {
                                htmgrprm.Add("@VenTyp", DBNull.Value);
                            }
                            #endregion
                        }
                        else
                        {
                            htmgrprm.Add("@IsVendor", "N");
                            if (chkisprimry.Checked == true)
                            {
                                htmgrprm.Add("@PrimaryFlag", "1");
                            }
                            else
                            {
                                htmgrprm.Add("@PrimaryFlag", "0");
                            }
                        }
                    }
                    else
                    {
                        htmgrprm.Add("@IsVendor", "N");
                        htmgrprm.Add("@PrimaryFlag", "0");
                    }
                    dsrptmgr = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_InsRptMgrDtls", htmgrprm);
                }
                #endregion
            }

            var vencode = "";
            if (dsrptmgr.Tables.Count > 0 && dsrptmgr.Tables[0].Rows.Count > 0)
            {
                vencode = dsrptmgr.Tables[0].Rows[0]["vendorcode"].ToString();
                hdnVenCode.Value = vencode.ToString().Trim();
                Session["hdnVenCode"] = vencode.ToString().Trim();
            }

            return vencode;

            #endregion
        }
        #endregion

        #region InsAgtSMVenMappDtls
        public void InsAgtSMVenMappDtls(string SMChnl, string SMSubChnl, string SMCode, string VenChnl, string VenSubChnl, string VenCode, bool Primflag, string strAgnVenRelType)
        {
            Hashtable htmapp = new Hashtable();
            DataSet dsmapp = new DataSet();
            try
            {
                dsmapp.Clear();
                htmapp.Clear();
                htmapp.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htmapp.Add("@CreatedBy", txtUserId.Text);
                htmapp.Add("@AgentBizsrc", ddlSlsChannel.SelectedValue);
                htmapp.Add("@AgentChnCls", ddlChnCls.SelectedValue);
                htmapp.Add("@AgentCode", txtAgtCode.Text);
                htmapp.Add("@AgentName", txtAgntName.Text);
                htmapp.Add("@VendorName", txtAgntName.Text + "DEFAULT");
                htmapp.Add("@UnitCode", hdnUntCode.Value);

                htmapp.Add("@DerivedBizSrc", SMChnl);
                htmapp.Add("@DerivedChnCls", SMSubChnl);
                htmapp.Add("@SMCode", SMCode);
                htmapp.Add("@RelBizSrc", VenChnl);
                htmapp.Add("@RelChnCls", VenSubChnl);
                htmapp.Add("@RelAgentCode", VenCode);
                if (Primflag == true)
                {
                    htmapp.Add("@PrmyFlg", "Vendor");
                }
                else
                {
                    htmapp.Add("@PrmyFlg", "Agent");
                }
                htmapp.Add("@LocationName", "Default " + txtAgntName.Text);
                htmapp.Add("@flag", "1");
                htmapp.Add("@AgnVenRelType", strAgnVenRelType);
                dsmapp = dataAccess.GetDataSetForPrc("Prc_InsDataToGenIRC", htmapp);
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

        #region ONCLICK 'btnCancel' BUTTON
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    if (Request.QueryString["Type"].ToString() == "N" || Request.QueryString["Type"].ToString() == "Clt")
        //    {
        //        if (Request.QueryString["Ctgry"] != null)
        //        {
        //            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" && Request.QueryString["Type"].ToString() == "N")
        //            {
        //                Response.Redirect("~/Application/Common/CltEnquiry.aspx?Type=Emp");
        //            }
        //            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven" && Request.QueryString["Type"].ToString() == "N")
        //            {
        //                Response.Redirect("~/Application/Common/CltEnquiry.aspx?Type=Ven");
        //            }
        //        }
        //        else
        //        {
        //            Response.Redirect("~/Application/Common/CltEnquiry.aspx?Type=Agn");
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
        //    }
        //}
        #endregion

        #region ONCLICK 'btn_GoalSheetRpt' BUTTON
        protected void btn_GoalSheetRpt_Click(object sender, EventArgs e)
        {
            #region Comment GS
            lblMessage.Visible = false;

            string str_KPI_Temp1 = "";
            string str_KPI_Temp2 = "";
            string str_KPI_Temp3 = "";
            string str_KPI_Temp4 = "";
            string str_KPI_Temp5 = "";
            string str_KPI_Temp6 = "";
            string str_KPI_Temp7 = "";
            string str_KPI_Temp8 = "";

            str_BizSrc = "";
            str_CarrierCode = "";
            str_AgentType = "";
            str_AgnCode = "";
            str_ChnClass = "";
            DataSet ds_KPI = new DataSet();

            str_AgnCode = txtAgtCode.Text.Trim();
            str_CarrierCode = "2";
            str_AgentType = ddlAgntType.SelectedValue.ToString();
            str_ChnClass = ddlChnCls.SelectedValue.ToString();
            str_BizSrc = ddlSlsChannel.SelectedValue.ToString();

            Hashtable htParam = new Hashtable();
            DataSet ds_recs = new DataSet();
            htParam.Add("@BizSrc", str_BizSrc);
            htParam.Add("@CarrierCode", str_CarrierCode);
            htParam.Add("@AgentType", str_AgentType);
            htParam.Add("@AgentCode", str_AgnCode);
            htParam.Add("@ChnClass", str_ChnClass);

            ds_recs = dataAccess.GetDataSetForPrc("prc_Rpt_ChkRecsKPI", htParam);

            if (ds_recs.Tables[0].Rows.Count.Equals(0))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No KPI Recs found for the AgentCode";
            }
            else
            {
                try
                {
                    if (ds_recs.Tables[0].Rows.Count.Equals(1))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(2))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(3))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(4))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                        str_KPI_Temp4 = ds_recs.Tables[0].Rows[3][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(5))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                        str_KPI_Temp4 = ds_recs.Tables[0].Rows[3][0].ToString();
                        str_KPI_Temp5 = ds_recs.Tables[0].Rows[4][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(6))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                        str_KPI_Temp4 = ds_recs.Tables[0].Rows[3][0].ToString();
                        str_KPI_Temp5 = ds_recs.Tables[0].Rows[4][0].ToString();
                        str_KPI_Temp6 = ds_recs.Tables[0].Rows[5][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(7))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                        str_KPI_Temp4 = ds_recs.Tables[0].Rows[3][0].ToString();
                        str_KPI_Temp5 = ds_recs.Tables[0].Rows[4][0].ToString();
                        str_KPI_Temp6 = ds_recs.Tables[0].Rows[5][0].ToString();
                        str_KPI_Temp7 = ds_recs.Tables[0].Rows[6][0].ToString();
                    }
                    if (ds_recs.Tables[0].Rows.Count.Equals(8))
                    {
                        str_KPI_Temp1 = ds_recs.Tables[0].Rows[0][0].ToString();
                        str_KPI_Temp2 = ds_recs.Tables[0].Rows[1][0].ToString();
                        str_KPI_Temp3 = ds_recs.Tables[0].Rows[2][0].ToString();
                        str_KPI_Temp4 = ds_recs.Tables[0].Rows[3][0].ToString();
                        str_KPI_Temp5 = ds_recs.Tables[0].Rows[4][0].ToString();
                        str_KPI_Temp6 = ds_recs.Tables[0].Rows[5][0].ToString();
                        str_KPI_Temp7 = ds_recs.Tables[0].Rows[6][0].ToString();
                        str_KPI_Temp8 = ds_recs.Tables[0].Rows[7][0].ToString();
                    }

                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ReportConnection"].ToString());
                    SqlCommand cmd = new SqlCommand("prc_rpt_KPIGoalSheet_InsertIntoTemp_Dynamic", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BizSrc", SqlDbType.VarChar, 10).Value = str_BizSrc;
                    cmd.Parameters.Add("@CarrierCode", SqlDbType.VarChar, 5).Value = str_CarrierCode;
                    cmd.Parameters.Add("@AgentType", SqlDbType.VarChar, 10).Value = str_AgentType;
                    cmd.Parameters.Add("@AgentCode", SqlDbType.VarChar, 20).Value = str_AgnCode;
                    cmd.Parameters.Add("@ChnClass", SqlDbType.VarChar, 10).Value = str_ChnClass;
                    cmd.Parameters.Add("@KPITemp1", SqlDbType.VarChar, 10).Value = str_KPI_Temp1;
                    cmd.Parameters.Add("@KPITemp2", SqlDbType.VarChar, 10).Value = str_KPI_Temp2;
                    cmd.Parameters.Add("@KPITemp3", SqlDbType.VarChar, 10).Value = str_KPI_Temp3;
                    cmd.Parameters.Add("@KPITemp4", SqlDbType.VarChar, 10).Value = str_KPI_Temp4;
                    cmd.Parameters.Add("@KPITemp5", SqlDbType.VarChar, 10).Value = str_KPI_Temp5;
                    cmd.Parameters.Add("@KPITemp6", SqlDbType.VarChar, 10).Value = str_KPI_Temp6;
                    cmd.Parameters.Add("@KPITemp7", SqlDbType.VarChar, 10).Value = str_KPI_Temp7;
                    cmd.Parameters.Add("@KPITemp8", SqlDbType.VarChar, 10).Value = str_KPI_Temp8;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    AgntgtGoalSheet obj_rpt = new AgntgtGoalSheet();
                    obj_rpt.ShowParameterUI = false;
                    obj_rpt.Parameters["AgentCode"].Value = str_AgnCode;
                    obj_rpt.Run();

                    System.Web.HttpContext.Current.Response.ContentType = "application/xls";
                    System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" + str_AgnCode + "_AgnTgtGlSht.xls");
                    XlsExport xls = new XlsExport();
                    System.IO.MemoryStream memStream = new System.IO.MemoryStream();
                    xls.Export(obj_rpt.Document, memStream);
                    xls.UseCellMerging = true;
                    xls.DisplayGridLines = true;
                    xls.AutoRowHeight = true;
                    xls.MultiSheet = true;

                    System.Web.HttpContext.Current.Response.BinaryWrite(memStream.ToArray());
                    System.Web.HttpContext.Current.Response.End();
                }
                catch (Exception ex)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ReportConnection"].ToString());
                    SqlCommand cmd = new SqlCommand("prc_rpt_GoalSheet_DropTempTables", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write(ex.Message.ToString());
                }
            }
            #endregion
        }
        #endregion

        #region ONCLICK 'btn_CDAWelcomeLetter' BUTTON
        protected void btn_CDAWelcomeLetter_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo objConn = new ConnectionInfo();
                objConn.ServerName = "10.126.143.56,1981";
                objConn.DatabaseName = "INSCCOMMON";
                objConn.UserID = "iconnect";
                objConn.Password = "123$insure123$";

                CrystalDecisions.Shared.ParameterValues objParamField = new CrystalDecisions.Shared.ParameterValues();
                CrystalDecisions.Shared.ParameterDiscreteValue objParamDescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                objParamDescValue.Value = txtAgtCode.Text;
                objParamField.Add(objParamDescValue);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/CDAWelcomeLetter.rpt"));
                Tables objTables = rpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
                {
                    TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
                    objTblLogInfo.ConnectionInfo = objConn;
                    objtable.ApplyLogOnInfo(objTblLogInfo);
                    objtable.Location = objConn.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
                    objtable.LogOnInfo.ConnectionInfo.ServerName = objConn.ServerName;
                }

                rpt.DataDefinition.ParameterFields["@AgnCode"].ApplyCurrentValues(objParamField);
                rpt.DataDefinition.ParameterFields["@RefNo"].ApplyCurrentValues(objParamField);
                rpt.DataDefinition.ParameterFields["@AppVideNo"].ApplyCurrentValues(objParamField);
                rpt.DataDefinition.ParameterFields["@Date"].ApplyCurrentValues(objParamField);
                rpt.DataDefinition.ParameterFields["@Selection"].ApplyCurrentValues(objParamField);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "CDAWelcomeLetter_" + txtAgtCode.Text);

                rpt.Close();
                rpt.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
            finally
            {

            }
        }
        #endregion

        #region AMLetter
        protected void btnAMLetter_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo objConn = new ConnectionInfo();
                objConn.ServerName = "10.126.143.56,1981";
                objConn.DatabaseName = "INSCCOMMON";
                objConn.UserID = "IConnect";
                objConn.Password = "123$insure123$";

                CrystalDecisions.Shared.ParameterValues objParamField = new CrystalDecisions.Shared.ParameterValues();
                CrystalDecisions.Shared.ParameterDiscreteValue objParamDescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                objParamDescValue.Value = txtAgtCode.Text;
                objParamField.Add(objParamDescValue);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/AMWelcomeLetter.rpt"));

                Tables objTables = rpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
                {
                    TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
                    objTblLogInfo.ConnectionInfo = objConn;
                    objtable.ApplyLogOnInfo(objTblLogInfo);
                    objtable.Location = objConn.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
                    objtable.LogOnInfo.ConnectionInfo.ServerName = objConn.ServerName;
                }

                rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objParamField);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "AMWelcomeLetter_" + txtAgtCode.Text);

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region BUTTON btnAMGoalLetter Click
        protected void btnAMGoalLetter_Click(object sender, EventArgs e)
        {
            try
            {

                GoalSheet obj_AMRpt = new GoalSheet();
                obj_AMRpt.ShowParameterUI = false;
                obj_AMRpt.Parameters["AgentCode"].Value = txtAgtCode.Text;
                obj_AMRpt.Run();

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=GoalLetter.pdf");
                PdfExport pdf = new PdfExport();
                System.IO.MemoryStream memStream = new System.IO.MemoryStream();
                pdf.Export(obj_AMRpt.Document, memStream);
                pdf.Export(obj_AMRpt.Document, DateTime.Now.ToString("ddMMyyyy") + ".pdf");
                HttpContext.Current.Response.BinaryWrite(memStream.ToArray());
                HttpContext.Current.Application.Clear();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream("C:\\ErrLog_CDAWelcome.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Date : " + DateTime.Now);
                sw.WriteLine("Error : " + ex.Message);
                sw.WriteLine("-------------------------------------------------------------------------");

                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        #endregion

        #region BUTTON btnCDAPromotionLetter Click
        protected void btnCDAPromotionLetter_Click(object sender, EventArgs e)
        {
            try
            {
                CDAPromotion obj_CDRpt = new CDAPromotion();
                obj_CDRpt.ShowParameterUI = false;
                obj_CDRpt.Parameters["AgentCode"].Value = txtAgtCode.Text;
                obj_CDRpt.Run();

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=CDAPromotionLetter.pdf");
                PdfExport pdf = new PdfExport();
                System.IO.MemoryStream memStream = new System.IO.MemoryStream();
                pdf.Export(obj_CDRpt.Document, memStream);
                pdf.Export(obj_CDRpt.Document, DateTime.Now.ToString("ddMMyyyy") + ".pdf");
                HttpContext.Current.Response.BinaryWrite(memStream.ToArray());
                HttpContext.Current.Application.Clear();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream("C:\\ErrLog_CDAWelcome.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Date : " + DateTime.Now);
                sw.WriteLine("Error : " + ex.Message);
                sw.WriteLine("-------------------------------------------------------------------------");

                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        #endregion

        #region BUTTON btnTerminationLetter Click
        protected void btnTerminationLetter_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region FUNCTION ShowLetterInfo
        protected void ShowLetterInfo()
        {
            //    string strAgentCode = txtAgtCode.Text.ToString().Trim();
            //    htParam.Clear();
            //    htParam.Add("@AgentCode", strAgentCode);
            //    dsResult = dataAccess.GetDataSetForPrcDBConn("dbo.Proc_GetAgnDetail_CautLtr", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            //    if (dsResult.Tables.Count > 0)
            //    {
            //        if (dsResult.Tables[0].Rows.Count > 0)
            //        {
            //            if ((chkcautionltr.Enabled == true) && (chkcautionltr.Checked == true))
            //            {
            //                try
            //                {
            //                    ConnectionInfo obj = new ConnectionInfo();
            //                    obj.ServerName = "10.126.143.56,1981";
            //                    obj.DatabaseName = "INSCCommon";
            //                    obj.UserID = "iconnect";
            //                    obj.Password = "123$insure123$";

            //                    CrystalDecisions.Shared.ParameterValues objparamfeild = new CrystalDecisions.Shared.ParameterValues();
            //                    CrystalDecisions.Shared.ParameterDiscreteValue objparamdescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //                    objparamdescValue.Value = txtAgtCode.Text;
            //                    objparamfeild.Add(objparamdescValue);

            //                    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                    rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/CautionLetter.rpt"));
            //                    Tables objTables = rpt.Database.Tables;
            //                    foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
            //                    {
            //                        TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
            //                        objTblLogInfo.ConnectionInfo = obj;
            //                        objtable.ApplyLogOnInfo(objTblLogInfo);
            //                        objtable.Location = obj.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
            //                        objtable.LogOnInfo.ConnectionInfo.ServerName = obj.ServerName;
            //                    }

            //                    rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objparamfeild);
            //                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "CautionLetter_" + txtAgtCode.Text);

            //                    rpt.Close();
            //                    rpt.Dispose();
            //                    GC.Collect();
            //                }
            //                catch (Exception ex)
            //                {
            //                    lblMessage.Text = ex.Message.ToString();
            //                }
            //                finally
            //                {
            //                }
            //            }
            //            if ((chkShwCauseLtr.Enabled == true) && (chkShwCauseLtr.Checked == true))
            //            {
            //                try
            //                {
            //                    ConnectionInfo obj = new ConnectionInfo();
            //                    obj.ServerName = "10.126.143.56,1981";
            //                    obj.DatabaseName = "INSCCommon";
            //                    obj.UserID = "iconnect";
            //                    obj.Password = "123$insure123$";

            //                    CrystalDecisions.Shared.ParameterValues objparamfeild = new CrystalDecisions.Shared.ParameterValues();
            //                    CrystalDecisions.Shared.ParameterDiscreteValue objparamdescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //                    objparamdescValue.Value = txtAgtCode.Text;
            //                    objparamfeild.Add(objparamdescValue);

            //                    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                    rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/ShowCauseLetter.rpt"));
            //                    Tables objTables = rpt.Database.Tables;
            //                    foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
            //                    {
            //                        TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
            //                        objTblLogInfo.ConnectionInfo = obj;
            //                        objtable.ApplyLogOnInfo(objTblLogInfo);
            //                        objtable.Location = obj.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
            //                        objtable.LogOnInfo.ConnectionInfo.ServerName = obj.ServerName;
            //                    }

            //                    rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objparamfeild);
            //                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "ShowCauseLetter_" + txtAgtCode.Text);

            //                    rpt.Close();
            //                    rpt.Dispose();
            //                    GC.Collect();
            //                }
            //                catch (Exception ex)
            //                {
            //                    lblMessage.Text = ex.Message.ToString();
            //                }
            //                finally
            //                {

            //                }
            //            }
            //            else if ((chkwarningltr.Enabled == true) && (chkwarningltr.Checked == true))
            //            {
            //                try
            //                {
            //                    ConnectionInfo obj = new ConnectionInfo();
            //                    obj.ServerName = "10.126.143.56,1981";
            //                    obj.DatabaseName = "INSCCommon";
            //                    obj.UserID = "Iconnect";
            //                    obj.Password = "123$insure123$";

            //                    CrystalDecisions.Shared.ParameterValues objparamfeild = new CrystalDecisions.Shared.ParameterValues();
            //                    CrystalDecisions.Shared.ParameterDiscreteValue objparamdescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //                    objparamdescValue.Value = txtAgtCode.Text;
            //                    objparamfeild.Add(objparamdescValue);

            //                    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                    rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/WarningLetter.rpt"));
            //                    Tables objTables = rpt.Database.Tables;
            //                    foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
            //                    {
            //                        TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
            //                        objTblLogInfo.ConnectionInfo = obj;
            //                        objtable.ApplyLogOnInfo(objTblLogInfo);
            //                        objtable.Location = obj.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
            //                        objtable.LogOnInfo.ConnectionInfo.ServerName = obj.ServerName;
            //                    }

            //                    rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objparamfeild);
            //                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "WarningLetter_" + txtAgtCode.Text);

            //                    rpt.Close();
            //                    rpt.Dispose();
            //                    GC.Collect();
            //                }
            //                catch (Exception ex)
            //                {
            //                    lblMessage.Text = ex.Message.ToString();
            //                }
            //                finally
            //                {

            //                }
            //            }
            //            else if ((chkterminationltr.Enabled == true) && (chkterminationltr.Checked == true))
            //            {
            //                try
            //                {
            //                    ConnectionInfo obj = new ConnectionInfo();
            //                    obj.ServerName = "10.126.143.56,1981";
            //                    obj.DatabaseName = "INSCCommon";
            //                    obj.UserID = "Iconnect";
            //                    obj.Password = "123$insure123$";

            //                    CrystalDecisions.Shared.ParameterValues objparamfeild = new CrystalDecisions.Shared.ParameterValues();
            //                    CrystalDecisions.Shared.ParameterDiscreteValue objparamdescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //                    objparamdescValue.Value = txtAgtCode.Text;
            //                    objparamfeild.Add(objparamdescValue);

            //                    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                    rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/TerminationLetter.rpt"));
            //                    Tables objTables = rpt.Database.Tables;
            //                    foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
            //                    {
            //                        TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
            //                        objTblLogInfo.ConnectionInfo = obj;
            //                        objtable.ApplyLogOnInfo(objTblLogInfo);
            //                        objtable.Location = obj.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
            //                        objtable.LogOnInfo.ConnectionInfo.ServerName = obj.ServerName;
            //                    }

            //                    rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objparamfeild);
            //                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "TerminationLetter_" + txtAgtCode.Text);

            //                    rpt.Close();
            //                    rpt.Dispose();
            //                    GC.Collect();
            //                }
            //                catch (Exception ex)
            //                {
            //                    lblMessage.Text = ex.Message.ToString();
            //                }
            //                finally
            //                {

            //                }

            //            }
            //        }
            //    }
        }
        #endregion

        #region BUTTON btndelete Click
        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["AgnCd"] != null)
            {
                ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString();
            }

            SqlDataReader dtRead;
            //Added by Pranjali on 05-07-2013 for deleting agent code from agnletterinfo table start
            Hashtable htparam = new Hashtable();
            htparam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            dtRead = dataAccess.Common_exec_reader_prc("Prc_Del_agnletterinfo", htparam);
            //Added by Pranjali on 05-07-2013 for deleting agent code from agnletterinfo table end
            btnReGenerateLetter.Enabled = false;
            Hashtable ht3 = new Hashtable();
            ht3.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            ht3.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            objDAL.execute_sprc("Prc_InsertAgtLtrInfo", ht3);
        }
        #endregion

        #region BUTTON btnPDLetter Click
        protected void btnPDLetter_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo objConn = new ConnectionInfo();
                objConn.ServerName = "10.126.239.186,1983";
                objConn.DatabaseName = "INSCCOMMON";
                objConn.UserID = "INSCAPP3";
                objConn.Password = "$insc@@p321";

                CrystalDecisions.Shared.ParameterValues objParamField = new CrystalDecisions.Shared.ParameterValues();
                CrystalDecisions.Shared.ParameterDiscreteValue objParamDescValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                objParamDescValue.Value = txtAgtCode.Text;
                objParamField.Add(objParamDescValue);

                CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(Server.MapPath("~/Application/ISys/CrystalReport/PDWelcomeLetter.rpt"));

                Tables objTables = rpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table objtable in objTables)
                {
                    TableLogOnInfo objTblLogInfo = objtable.LogOnInfo;
                    objTblLogInfo.ConnectionInfo = objConn;
                    objtable.ApplyLogOnInfo(objTblLogInfo);
                    objtable.Location = objConn.DatabaseName + ".dbo." + objtable.Location.Substring(objtable.Location.LastIndexOf(".") + 1);
                    objtable.LogOnInfo.ConnectionInfo.ServerName = objConn.ServerName;
                }

                rpt.DataDefinition.ParameterFields["@AgentCode"].ApplyCurrentValues(objParamField);
                rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "PDWelcomeLetter_" + txtAgtCode.Text);

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        #endregion

        #region DROPDOWNLIST ddlChannels SelectedIndexChanged event
        protected void ddlChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChannels.SelectedValue == "CD")
            {
                lbldob.Text = "Date Of Birth/Date of Incorporation";
                lblmandatory.Visible = true;
            }
            else
            {
                lbldob.Text = "Date Of Birth";
                lblmandatory.Visible = false;
            }
        }
        #endregion

        #region btnVerifyPAN_Click
        protected void btnVerifyPAN_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Pan"].ToString().Trim() == txtPanNo.Text.ToString().Trim())
                {
                    hdnPan.Value = "1";
                    return;
                }
                else
                {
                bool isFound = false;
                DataSet dsRes = new DataSet();
                lblPANMsg.Text = "";
                htParam.Clear();
                htParam.Add("@PAN", txtPanNo.Text.Trim());
                if (txtPanNo.Text.ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pan No')", true);
                    //txtPanNo.Focus();
                    return;
                }
                dsRes = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetChkPANExist", htParam);

                for (int i = 0; i < dsRes.Tables.Count; i++)
                {
                    if (dsRes.Tables[i].Rows.Count > 0)
                    {
                        isFound = true;
                        hdnAgnCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][0]).Trim();
                    }
                }
                if (isFound == true)
                {
                    if (dsRes.Tables[0].Rows.Count > 0)
                    {
                        lblPANMsg.Text = "Duplicate Match Found";
                        lblPANMsg.ForeColor = Color.Red;
                        btnUpdate.Enabled = false;
                    }
                    else if (dsRes.Tables[1].Rows.Count > 0)
                    {
                        lblPANMsg.Text = "Duplicate Match Found";
                        lblPANMsg.ForeColor = Color.Red;
                        btnUpdate.Enabled = false;
                    }
                }

                else
                {
                    lblPANMsg.Text = "PAN NO. Verified";
                    lblPANMsg.ForeColor = Color.Green;
                    hdnPan.Value = "1";
                    btnUpdate.Enabled = true;
                    txtPanNo.Enabled = false;
                    btnVerifyPAN.Enabled = false;
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

            }
            ddlGender.Focus();
        }
        #endregion

        #region BUTTON btnVerifyNeft Click
        protected void btnVerifyNeft_Click(object sender, EventArgs e)
        {
            try
            {
                //Added by pranjali on 05-07-2013 for selecting data from AgnBnkBrnNEFTSU start
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@BankNtfeCode", txtNeftCode.Text.Trim());
                htparam.Add("@flag", 3);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetNeftCode", htparam);
                //Added by pranjali on 05-07-2013 for selecting data from AgnBnkBrnNEFTSU end
                if (dtRead.Read())
                {
                    hdnMicr.Value = dtRead["BnkCode"].ToString();
                    txtBankName.Text = dtRead["BnkDesc"].ToString();
                    txtBnkBrnchName.Text = dtRead["BnkBrnDesc"].ToString();
                    lblBranchName.Text = "";
                }
                else
                {
                    txtBankName.Text = "";
                    txtBnkBrnchName.Text = "";
                    lblBranchName.Text = "Bank details do not exist for this NEFT Code";
                    lblBranchName.ForeColor = Color.Red;
                }
                dtRead.Close();
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

        #region BindGrid()
        ///added by akshay on 14/01/2014 to show profile image start
        private DataSet BindGrid()
        {
            try
            {
                dsResult.Clear();
                htParam.Clear();

                Hashtable httable = new Hashtable();
                httable.Add("@AgtCode", txtAgtCode.Text);
                dsResult.Clear();
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetImageForAgents", httable);
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message);
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            finally
            {
            }
            return dsResult;
        }
        #endregion

        #region GridImage_RowDataBound
        protected void GridImage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnid = (HiddenField)e.Row.FindControl("hdnid");
            }
        }
        ///added by akshay on 14/01/2014 to show profile image end
        #endregion

        #region InsertImg
        ///added by akshay on 17/01/14 start to convert image url to binary data
        public byte[] InsertImg()
        {
            Hashtable ht = new Hashtable();
            strFileName = @"~\theme\iflow\prof_pic_blank.jpg";
            try
            {
                string strFileName1 = (Server.MapPath(strFileName));

                FileStream fs2 = new FileStream(strFileName1, FileMode.Open, FileAccess.Read);
                System.Drawing.Image image_file = System.Drawing.Image.FromStream(fs2);
                image_height = image_file.Height;
                image_width = image_file.Width;
                Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                data = new byte[stream.Length + 1];
                stream.Read(data, 0, data.Length);
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
            return data;
        }
        #endregion

        #region InsertCndImg
        ///added by akshay on 18/04/14 start to convert image url to binary data
        public byte[] InsertCndImg()
        {
            DataSet dsInsImg = new DataSet();
            try
            {
                dsInsImg = BindGridCnd();
                if (dsInsImg != null)
                {
                    if (dsInsImg.Tables[0].Rows.Count > 0)
                    {
                        data = (byte[])dsInsImg.Tables[0].Rows[0]["Images"];
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            return data;
        }
        #endregion

        #region BUTTON CREATEIRC
        protected void btnCreatIRC_Click(object sender, EventArgs e)
        {
            Response.Redirect("MultiBranchAssignment.aspx?agncd=" + txtAgtCode.Text.Trim(), false);
        }
        #endregion

        #region FillCndDtlsForAgent method
        ////added by akshay on 30/01/14 for candidate agent mapping
        protected void FillCndDtlsForAgent()
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            agtcode = Request.QueryString["CndNo"].ToString().Trim();
            if (Request.QueryString["lic"].ToString().Trim() == "LicCnd" && Request.QueryString["CndNo"] != null)
            {
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            }
            htParam.Add("@flag", "1");
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_GetPAN", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                txtPanNo.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString();
            }
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            if (Request.QueryString["lic"] == "LicCnd" && Request.QueryString["CndNo"] != null)
            {
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            }
            try
            {
                if (Request.QueryString["lic"].ToString().Trim() != null)
                {
                    if (Request.QueryString["lic"].ToString().Trim() == "LicCnd")
                    {
                        dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_GetCndDtlsForAgent", htParam, "INSCRecruitConnectionString");
                    }
                }
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        txtAgtCode.Text = agtcode;
                        txtAgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GivenName"]);
                        txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                        txtNationalDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["cndND"]);
                        subPopulateAgnTitle();
                        if (dsResult.Tables[0].Rows[0]["Title"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]).Trim() != "")
                            {
                                cboagnTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["Gender"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]).Trim() != "")
                            {
                                if (ddlGender.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"])) != null)
                                {
                                    ddlGender.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]);
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["BirthRegDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString().Trim() != "")
                            {
                                txtDOB.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtDOB.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["MaritalStat"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim() != "")
                            {
                                cboMaritalStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim();
                            }
                        }

                        txtHomeTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HomeTel"]);
                        txtWorkTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                        txtMobileTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MobileTel"]);
                        txtMobileTel2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Mobile2"]);
                        txtEmail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                        txtEmail2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email2"]);
                        txtFax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                        //txtdidtel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DidTel"]);
                        txtPager.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["pager"]);
                        txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                        txtVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Village"]);

                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {

                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() != "XX")
                                {
                                    rdbChnlTyp.SelectedValue = "1";
                                }
                                else
                                    rdbChnlTyp.SelectedValue = "0";

                                oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            }
                        }

                        ddlChnCls.Items.Clear();
                        SqlDataReader dtRead;
                        //Added by Pranjali on 01-07-2013 for Channel sub class dropdown start
                        Hashtable htparam = new Hashtable();
                        htparam.Clear();
                        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);

                        if (dtRead.HasRows)
                        {
                            ddlChnCls.DataSource = dtRead;
                            ddlChnCls.DataTextField = "ChnlDesc";
                            ddlChnCls.DataValueField = "ChnCls";
                            ddlChnCls.DataBind();
                        }
                        dtRead = null;
                        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));

                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"])) != null)
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                                }
                            }
                        }
                        htparam.Clear();
                        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                        htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
                        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetAgnTypedesc", htparam);
                        if (dtRead.HasRows)
                        {
                            ddlAgntType.DataSource = dtRead;
                            ddlAgntType.DataTextField = "AgnDesc";
                            ddlAgntType.DataValueField = "AgentType";
                            ddlAgntType.DataBind();
                        }
                        dtRead = null;
                        if (dsResult.Tables[0].Rows[0]["AgentType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim() != "")
                            {
                                ddlAgntType.SelectedValue = "IS";
                                tblReportingMngrDtls.Visible = true;
                                tblUnitCodeDetails.Visible = true;
                                FillReportingMngrDtlsForIS();
                            }
                        }
                        ddlamchnldesc.SelectedValue = dsResult.Tables[0].Rows[0]["BizSrc"].ToString();
                        ddlamsubchnldesc.SelectedValue = dsResult.Tables[0].Rows[0]["ChnCls"].ToString();
                        ddllvlagttype.SelectedValue = dsResult.Tables[0].Rows[0]["AgentType"].ToString();
                        htParam.Clear();
                        htParam.Add("@cndno", txtAgtCode.Text);
                        DataSet dsRecruit = new DataSet();
                        dsRecruit = dataAccess.GetDataSetForPrcRecruit("PrcGetUnitForCndAgn", htParam);
                        if (dsRecruit.Tables[0].Rows[0]["RecruitUnitCode"] != null)
                        {
                            Hashtable htcode = new Hashtable();
                            DataSet dsBranchCode = new DataSet();
                            htcode.Add("@UNitcode", Convert.ToString(dsRecruit.Tables[0].Rows[0]["RecruitUnitCode"]).Trim());
                            htcode.Add("@BizSrc", Convert.ToString(dsRecruit.Tables[0].Rows[0]["BizSrc"]).Trim());
                            htcode.Add("@chncls", Convert.ToString(dsRecruit.Tables[0].Rows[0]["ChnCls"]).Trim());
                            dsBranchCode = dataAccess.GetDataSetForPrcRecruit("PrcGetBranchCodeForCndAgn", htcode);
                            string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                            string cmsunitcode = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                            txtUntCode.Text = branch + "(" + cmsunitcode + ")";
                            lblUnitDesc.Text = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UNitcode"]);
                        }
                        ///txtRptMgr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]);
                        ////lblrptmgr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DirectAgtCode"]);
                        if (dsResult.Tables[0].Rows[0]["LcnNo"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["LcnNo"]).Trim() != "")
                            {
                                txtBizLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LcnNo"]).Trim();
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["LcnExpDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim() != "")
                            {
                                txtBizLicEndDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtBizLicEndDt.Text = "";
                        }

                        if (dsResult.Tables[0].Rows[0]["OldTccLcnno"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim() != "")
                            {
                                txtBizOldLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim();
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"].ToString().Trim() != "")
                            {
                                txtBizOldLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtBizOldLicExpDt.Text = "";//txtOldTccLcnExpDate
                        }

                        if (dsResult.Tables[0].Rows[0]["BasicQual"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim() != "")
                            {
                                cboQualCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim();
                            }
                        }
                        ddlCnctType.SelectedValue = dsResult.Tables[0].Rows[0]["CnctType"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["CnctType"].ToString().Trim() == "P1")
                        {
                            ChkPARes.Checked = true;
                            ChkPABusns.Checked = false;
                        }
                        txtAddrP1.Text = dsResult.Tables[0].Rows[0]["rAdr1"].ToString().Trim();
                        txtAddrP2.Text = dsResult.Tables[0].Rows[0]["rAdr2"].ToString().Trim();
                        txtAddrP3.Text = dsResult.Tables[0].Rows[0]["rAdr3"].ToString().Trim();
                        ddlState.SelectedValue = dsResult.Tables[0].Rows[0]["rAdrSC"].ToString().Trim();
                        txtPinP.Text = dsResult.Tables[0].Rows[0]["rAdrPC"].ToString().Trim();
                        txtCountryCodeP.Text = dsResult.Tables[0].Rows[0]["rAdrCC"].ToString().Trim();
                        txtCountryDescP.Text = dsResult.Tables[0].Rows[0]["rAdrND"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["CnctType"].ToString().Trim() == "P1")
                        {
                            txtVillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                            txtDistP.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        }
                        else if (dsResult.Tables[0].Rows[0]["CnctType"].ToString().Trim() == "B1")
                        {
                            txtBvillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                            txtDistB.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        }
                        if (dsResult.Tables[0].Rows[0]["CnctType"].ToString().Trim() == "B1")
                        {
                            ChkPARes.Checked = false;
                            ChkPABusns.Checked = true;
                        }
                        txtAddrB1.Text = dsResult.Tables[0].Rows[0]["bAdr1"].ToString().Trim();
                        txtAddrB2.Text = dsResult.Tables[0].Rows[0]["bAdr2"].ToString().Trim();
                        txtAddrB3.Text = dsResult.Tables[0].Rows[0]["bAdr3"].ToString().Trim();
                        ddlState0.SelectedValue = dsResult.Tables[0].Rows[0]["bAdrSC"].ToString().Trim();
                        txtPinB.Text = dsResult.Tables[0].Rows[0]["bAdrPC"].ToString().Trim();
                        txtCountryCodeB.Text = dsResult.Tables[0].Rows[0]["bAdrCC"].ToString().Trim();
                        txtCountryDescB.Text = dsResult.Tables[0].Rows[0]["bAdrCD"].ToString().Trim();
                        txtPermAdd1.Text = dsResult.Tables[0].Rows[0]["mAdr1"].ToString().Trim();
                        txtPermAdd2.Text = dsResult.Tables[0].Rows[0]["mAdr2"].ToString().Trim();
                        txtPermAdd3.Text = dsResult.Tables[0].Rows[0]["mAdr3"].ToString().Trim();
                        ddlState1.SelectedValue = dsResult.Tables[0].Rows[0]["mAdrSC"].ToString().Trim();
                        txtPermVillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                        txtDistric.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        txtPermPostcode.Text = dsResult.Tables[0].Rows[0]["mAdrPC"].ToString().Trim();
                        txtPermCountryCode.Text = dsResult.Tables[0].Rows[0]["mAdrCC"].ToString().Trim();
                        txtPermCountryDesc.Text = dsResult.Tables[0].Rows[0]["mAdrCD"].ToString().Trim();

                        if (dsResult.Tables[0].Rows[0]["CasteCat"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim() != "")
                            {
                                ddlCategory.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim();
                            }
                        }
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
            }
            dsResult.Clear();
            dsResult = null;
            htParam.Clear();
            htParam = null;
        }
        #endregion

        #region FillReportingMngrDtlsForIS method
        ////added by akshay on 31/01/14 for fetching reporting details for IA
        protected void FillReportingMngrDtlsForIS()
        {
            try
            {
                //rachana 30-11-2013 start
                Hashtable htParam = new Hashtable();
                DataSet dsRpt = new DataSet();
                htParam.Clear();
                dsRpt.Clear();
                htParam.Add("@AgentType", "IS");
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

                //Assign values to labels
                if (dsRpt.Tables.Count > 0)
                {
                    if (dsRpt.Tables[0].Rows.Count > 0)
                    {
                        FillReportingMngrddl();
                        ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        ddlambasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString();
                        FillReportingMngrchnl();
                        ddlamchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        FillReportingMngrsubchnl();
                        ddlamsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                        FillReportingMngrAgttype();
                        ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["AgentType"].ToString();
                        if (ddllvlagttype.SelectedValue != "")
                        {
                            if (dsRpt.Tables[0].Rows[0]["AgentType"].ToString() == "RF")
                            {
                                trventype.Visible = true;
                            }
                            else
                            {
                                trventype.Visible = false;
                            }
                        }

                        hdnchn.Value = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        hdnsubchn.Value = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                        string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                        //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable start
                        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                        {
                            lblRptMngrErr.Visible = false;
                            lblRptMngrErr.Text = "";
                            if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "0")
                            {
                                lbladditionalreportingrule.Text = "Multiple-1";
                            }
                            else
                                if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "1")
                            {
                                lbladditionalreportingrule.Text = "Multiple-2";
                            }
                            else
                                    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "2")
                            {
                                lbladditionalreportingrule.Text = "Multiple-3";
                            }
                            GetManagers();
                            GetAddlManagers();
                        }
                        else
                        {
                            lblRptMngrErr.Visible = true;
                            lblRptMngrErr.Text = "No Record(s) Exists";
                            lbladditionalreportingrule.Text = "";
                            GetManagers();
                        }
                        //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable end

                        //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection start
                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                        //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection end
                    }
                    else
                    {
                        funShowCrntMgr("empty");
                    }
                }
                else
                {
                    funShowCrntMgr("empty");
                }
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

        #region PopulateState
        private void PopulateState(DropDownList ddlst)
        {
            try
            {
                string strSql = string.Empty;
                SqlDataReader dtRead;
                DataSet dsResult = new DataSet();
                Hashtable ht = new Hashtable();
                ht.Clear();
                dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetddlState", ht);
                if (dtRead.HasRows)
                {
                    ddlst.DataSource = dtRead;
                    ddlst.DataTextField = "StateName";
                    ddlst.DataValueField = "StateID";
                    ddlst.DataBind();
                }
                dsResult = null;
                dtRead = null;
                strSql = null;
                //ddlst.Items.Insert(0, "--Select--");
                ddlst.Items.Insert(0, new ListItem("--Select--", ""));
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

        // Added By Sandeep Garg Start
        #region Populate Data from sap Code

        //protected void FetchDataFromMom()
        //{
        //    try
        //    {
        //        htnew.Clear();
        //        dsResult = null;
        //        htnew.Add("@SapCode", strSapCode);
        //        dsResult = dataAccess.GetDataSetForPrcCLP("Prc_GetDataFromEmpMaster", htnew);
        //        if (dsResult.Tables[0].Rows.Count > 0)
        //        {
        //            ddlGender.SelectedValue = dsResult.Tables[0].Rows[0]["Gender"].ToString().Trim();
        //            txtSAPcode.Text = dsResult.Tables[0].Rows[0]["SapCode"].ToString().Trim();
        //            txtMobileTel.Text = dsResult.Tables[0].Rows[0]["MobileNo"].ToString().Trim();
        //            txtAgntName.Text = dsResult.Tables[0].Rows[0]["EmpName"].ToString().Trim();
        //            txtEmail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
        //            lblUnitDesc.Text = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
        //            HttpContext.Current.Session["UnitCode"] = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
        //            txtUntCode.Text = dsResult.Tables[0].Rows[0]["UnitDesc"].ToString().Trim();
        //            HttpContext.Current.Session["UnitDesc"] = dsResult.Tables[0].Rows[0]["UnitDesc"].ToString().Trim();
        //            cboagnTitle.SelectedItem.Text = dsResult.Tables[0].Rows[0]["Title"].ToString().Trim();
        //            txtDOB.Text = dsResult.Tables[0].Rows[0]["DOB"].ToString().Trim();
        //            HttpContext.Current.Session["DOB"] = dsResult.Tables[0].Rows[0]["DOB"].ToString().Trim();
        //            if (dsResult.Tables[0].Rows[0]["Bizsrc"].ToString().Trim() != "XX")
        //            {
        //                rdbChnlTyp.SelectedValue = "1";
        //            }
        //            else
        //                rdbChnlTyp.SelectedValue = "0";

        //            oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
        //            ddlSlsChannel.SelectedValue = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString().Trim();
        //            GetChnlCls(ddlSlsChannel.SelectedValue.ToString());
        //            ddlChnCls.SelectedValue = dsResult.Tables[0].Rows[0]["chncls"].ToString().Trim();
        //            FillAgentType(ddlSlsChannel.SelectedValue.ToString(), ddlChnCls.SelectedValue.ToString());
        //            ddlAgntType.SelectedValue = dsResult.Tables[0].Rows[0]["Agenttype"].ToString().Trim();
        //            tblReportingMngrDtls.Visible = true;
        //            tblUnitCodeDetails.Visible = true;
        //            FillReportingMngrDtls();
        //            lblrptmgr.Text = dsResult.Tables[0].Rows[0]["PrmRptAgtCode"].ToString().Trim();
        //            hdnRptMgr.Value = dsResult.Tables[0].Rows[0]["PrmRptAgtCode"].ToString().Trim();
        //            txtRptMgr.Text = dsResult.Tables[0].Rows[0]["PrmRptAgtName"].ToString().Trim();

        //            PopulateConstityp();
        //            ddlLicTyp.SelectedIndex = 1;
        //            ddlLicTyp_SelectedIndexChanged(this, EventArgs.Empty);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //        string sRet = oInfo.Name;
        //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //        String LogClassName = method.ReflectedType.Name;
        //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //    }


        //}

        #endregion
        // Added By Sandeep Garg End

        ///added by akshay on 24/02/14 for candidate converting into agent start
        #region FillCndDtlsTrfCase method
        ////added by akshay on 24/02/14 for candidate agent mapping
        protected void FillCndDtlsTrfCase()
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            if (Request.QueryString["CndNum"] != null)
            {
                agtcode = Request.QueryString["CndNum"].ToString().Trim();
            }
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            if (Request.QueryString["cnd"] == "CndCon" && Request.QueryString["CndNum"] != null)
            {
                htParam.Add("@CndNo", Request.QueryString["CndNum"].ToString().Trim());
            }
            try
            {
                if (Request.QueryString["cnd"].ToString().Trim() != null)
                {
                    if (Request.QueryString["cnd"].ToString().Trim() == "CndCon")
                    {
                        dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_GetCndDtlsForAgent", htParam, "INSCRecruitConnectionString");
                    }
                }
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        txtAgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GivenName"]);
                        txtPanNo.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString() != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["PAN"]).Trim() != "")
                            {
                                hdnPan.Value = "1";
                                txtPanNo.Enabled = false;
                                btnVerifyPAN.Enabled = false;
                            }
                        }
                        txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                        txtNationalDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["cndND"]);
                        subPopulateAgnTitle();
                        if (dsResult.Tables[0].Rows[0]["Title"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]).Trim() != "")
                            {
                                cboagnTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                            }
                        }

                        if (dsResult.Tables[0].Rows[0]["Gender"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]).Trim() != "")
                            {
                                if (ddlGender.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"])) != null)
                                {
                                    ddlGender.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]);
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["BirthRegDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString().Trim() != "")
                            {
                                txtDOB.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtDOB.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["MaritalStat"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim() != "")
                            {
                                cboMaritalStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim();
                            }
                        }

                        #region FillContactDetails
                        txtHomeTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HomeTel"].ToString().Trim());
                        txtWorkTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"].ToString().Trim());
                        txtMobileTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim());
                        txtMobileTel2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Mobile2"].ToString().Trim());
                        txtEmail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"].ToString().Trim());
                        txtEmail2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email2"].ToString().Trim());
                        txtFax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"].ToString().Trim());
                        //txtdidtel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DidTel"]);
                        txtPager.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["pager"].ToString().Trim());
                        txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"].ToString().Trim());
                        /////txtVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Village"].ToString().Trim());
                        #endregion

                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {

                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() != "XX")
                                {
                                    rdbChnlTyp.SelectedValue = "1";
                                }
                                else
                                    rdbChnlTyp.SelectedValue = "0";
                                oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            }
                        }

                        GetChnlCls(ddlSlsChannel.SelectedValue.ToString());

                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"])) != null)
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                                }
                            }
                        }

                        if (dsResult.Tables[0].Rows[0]["CandType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CandType"]).Trim() != "")
                            {
                                Hashtable httype = new Hashtable();
                                DataSet dstype = new DataSet();
                                httype.Clear();
                                httype.Add("@CandType", dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim());
                                httype.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim());
                                httype.Add("@Chncls", dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim());
                                dstype = dataAccess.GetDataSetForPrcDBConn("PrcCandMemType", httype, "INSCRecruitConnectionString");
                                if (dstype.Tables.Count > 0)
                                {
                                    if (dstype.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(dstype.Tables[0].Rows[0]["MemType"]).Trim() != "")
                                        {
                                            Hashtable htparam = new Hashtable();
                                            htparam.Clear();
                                            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                            htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                                            htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
                                            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetAgnTypedesc", htparam);
                                            if (dtRead.HasRows)
                                            {
                                                ddlAgntType.DataSource = dtRead;
                                                ddlAgntType.DataTextField = "AgnDesc";
                                                ddlAgntType.DataValueField = "MemType";
                                                ddlAgntType.DataBind();
                                            }
                                            dtRead = null;
                                            ddlAgntType.SelectedValue = dstype.Tables[0].Rows[0]["MemType"].ToString();
                                        }
                                    }
                                }
                                tblReportingMngrDtls.Visible = true;
                                tblUnitCodeDetails.Visible = true;
                            }
                        }

                        FillReportingMngrDtlsTrf();
                        FillDDlAgnVenRelMap();

                        #region ReportingManager and UnitCode
                        htParam.Clear();
                        htParam.Add("@cndno", agtcode.ToString());
                        DataSet dsRecruit = new DataSet();
                        dsRecruit = dataAccess.GetDataSetForPrcRecruit("PrcGetUnitForCndAgn", htParam);
                        if (dsRecruit.Tables[0].Rows[0]["RecruitUnitCode"] != null)
                        {
                            Hashtable htcode = new Hashtable();
                            DataSet dsBranchCode = new DataSet();
                            htcode.Add("@UNitcode", Convert.ToString(dsRecruit.Tables[0].Rows[0]["RecruitUnitCode"]).Trim());
                            htcode.Add("@BizSrc", Convert.ToString(dsRecruit.Tables[0].Rows[0]["BizSrc"]).Trim());
                            htcode.Add("@chncls", Convert.ToString(dsRecruit.Tables[0].Rows[0]["ChnCls"]).Trim());
                            dsBranchCode = dataAccess.GetDataSetForPrcRecruit("PrcGetBranchCodeForCndAgn", htcode);
                            string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                            string cmsunitcode = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                            txtUntCode.Text = branch + "(" + cmsunitcode + ")";
                            lblUnitDesc.Text = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UNitcode"]);
                            hdnUntCode.Value = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UNitcode"]);
                        }

                        ///txtRptMgr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]);
                        ////lblrptmgr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]);
                        ////hdnRptMgr.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]);
                        #endregion

                        if (dsResult.Tables[0].Rows[0]["CandType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CandType"]).Trim() != "")
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["CandType"]) == "T" || Convert.ToString(dsResult.Tables[0].Rows[0]["CandType"]) == "C")
                                {
                                    if (dsResult.Tables[0].Rows[0]["LcnNo"] != null)
                                    {
                                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["LcnNo"]).Trim() != "")
                                        {
                                            txtBizLicNo.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                                        }
                                    }
                                    if (dsResult.Tables[0].Rows[0]["LcnExpDate"] != null)
                                    {
                                        if (dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim() != "")
                                        {
                                            txtBizLicEndDt.Text = dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim();
                                        }
                                    }
                                    else
                                    {
                                        txtBizLicEndDt.Text = "";
                                    }
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldTccLcnno"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim() != "")
                            {
                                txtBizOldLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim();
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"].ToString().Trim() != "")
                            {
                                txtBizOldLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        else
                        {
                            txtBizOldLicExpDt.Text = "";
                        }

                        if (dsResult.Tables[0].Rows[0]["BasicQual"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim() != "")
                            {
                                cboQualCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim();
                            }
                        }

                        #region FillAddressDetails
                        if (dsResult.Tables[0].Rows[0]["ResType"].ToString().Trim() != "")
                        {
                            ddlCnctType.SelectedValue = dsResult.Tables[0].Rows[0]["ResType"].ToString().Trim();
                            ChkPARes.Checked = true;
                            ChkPABusns.Checked = false;
                            txtVillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                            txtDistP.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        }
                        else if (dsResult.Tables[0].Rows[0]["BusiType"].ToString().Trim() != "")
                        {
                            ddlCnctType.SelectedValue = dsResult.Tables[0].Rows[0]["BusiType"].ToString().Trim();
                            ChkPARes.Checked = false;
                            ChkPABusns.Checked = true;
                            txtBvillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                            txtDistB.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        }
                        else if (dsResult.Tables[0].Rows[0]["PermType"].ToString().Trim() != "")
                        {
                            ddlCnctType.SelectedValue = dsResult.Tables[0].Rows[0]["PermType"].ToString().Trim();
                        }
                        txtAddrP1.Text = dsResult.Tables[0].Rows[0]["rAdr1"].ToString().Trim();
                        txtAddrP2.Text = dsResult.Tables[0].Rows[0]["rAdr2"].ToString().Trim();
                        txtAddrP3.Text = dsResult.Tables[0].Rows[0]["rAdr3"].ToString().Trim();
                        ddlState.SelectedValue = dsResult.Tables[0].Rows[0]["rAdrSC"].ToString().Trim();
                        txtPinP.Text = dsResult.Tables[0].Rows[0]["rAdrPC"].ToString().Trim();
                        txtCountryCodeP.Text = dsResult.Tables[0].Rows[0]["rAdrCC"].ToString().Trim();
                        txtCountryDescP.Text = dsResult.Tables[0].Rows[0]["rAdrND"].ToString().Trim();
                        txtcity.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["rAdrCity"]);
                        txtarea.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["rAdrArea"]);

                        txtAddrB1.Text = dsResult.Tables[0].Rows[0]["bAdr1"].ToString().Trim();
                        txtAddrB2.Text = dsResult.Tables[0].Rows[0]["bAdr2"].ToString().Trim();
                        txtAddrB3.Text = dsResult.Tables[0].Rows[0]["bAdr3"].ToString().Trim();
                        ddlState0.SelectedValue = dsResult.Tables[0].Rows[0]["bAdrSC"].ToString().Trim();
                        txtPinB.Text = dsResult.Tables[0].Rows[0]["bAdrPC"].ToString().Trim();
                        txtCountryCodeB.Text = dsResult.Tables[0].Rows[0]["bAdrCC"].ToString().Trim();
                        txtCountryDescB.Text = dsResult.Tables[0].Rows[0]["bAdrCD"].ToString().Trim();
                        txtarea0.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["bAdrArea"]);
                        txtcity0.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["bAdrCity"]);
                        txtPermAdd1.Text = dsResult.Tables[0].Rows[0]["mAdr1"].ToString().Trim();
                        txtPermAdd2.Text = dsResult.Tables[0].Rows[0]["mAdr2"].ToString().Trim();
                        txtPermAdd3.Text = dsResult.Tables[0].Rows[0]["mAdr3"].ToString().Trim();
                        ddlState1.SelectedValue = dsResult.Tables[0].Rows[0]["mAdrSC"].ToString().Trim();
                        txtPermVillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString().Trim();
                        txtDistric.Text = dsResult.Tables[0].Rows[0]["District"].ToString().Trim();
                        txtPermPostcode.Text = dsResult.Tables[0].Rows[0]["mAdrPC"].ToString().Trim();
                        txtPermCountryCode.Text = dsResult.Tables[0].Rows[0]["mAdrCC"].ToString().Trim();
                        txtPermCountryDesc.Text = dsResult.Tables[0].Rows[0]["mAdrCD"].ToString().Trim();
                        txtcity1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["mAdrCity"].ToString().Trim());
                        txtarea1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["mAdrArea"].ToString().Trim());
                        #endregion

                        if (dsResult.Tables[0].Rows[0]["CasteCat"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim() != "")
                            {
                                ddlCategory.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim();
                            }
                        }
                    }
                }
                GridCndImage.DataSource = BindGridCnd();
                GridCndImage.DataBind();
            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
            }
            dsResult.Clear();
            dsResult = null;
            htParam.Clear();
            htParam = null;
        }
        #endregion

        #region BindGridCnd()
        ///added by akshay on 18/04/2014 to show candidate profile image start
        private DataSet BindGridCnd()
        {
            try
            {
                dsResult.Clear();
                htParam.Clear();
                Hashtable httable = new Hashtable();
                if (Request.QueryString["cnd"] == "CndCon" && Request.QueryString["CndNum"] != null)
                {
                    httable.Add("@CndNo", Request.QueryString["CndNum"].ToString().Trim());
                }
                httable.Add("@DocType", "Photo");
                dsResult = objDAL.GetDataSetForPrc("Prc_GetImageForCnd", httable);
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message);
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

            finally
            {
            }
            return dsResult;
        }
        #endregion

        #region FillReportingMngrDtlsTrf method
        protected void FillReportingMngrDtlsTrf()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsRpt = new DataSet();
                htParam.Clear();
                dsRpt.Clear();
                if (Request.QueryString["Type"] != "E")
                {

                    htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                    htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                    htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                    dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);
                }
                else
                {
                    htParam.Add("@AgentCode", agtcode);
                    htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                    htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                    htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                    dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforRptmgr", htParam);
                }

                #region fetch values
                if (dsRpt.Tables.Count > 0)
                {
                    if (dsRpt.Tables[0].Rows.Count > 0)
                    {
                        FillReportingMngrddl();

                        ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        string PrmyRptCnd = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                        ////setAgtType(PrmyRptCnd, ddllvlagttype);
                        hdnRptSetup.Value = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                        ddllvlagttype.Enabled = true;
                        ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        if (dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == "" || dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == null)
                        {
                            trprirep.Visible = false;
                        }
                        else
                        {
                            trprirep.Visible = true;
                        }

                        ddlambasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString();

                        FillReportingMngrchnl();

                        ddlamchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();

                        FillReportingMngrsubchnl();

                        ddlamsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                        FillReportingMngrAgttype();

                        #region fetch member type
                        if (Request.QueryString["Type"] != null)
                        {
                            if (Request.QueryString["Type"].ToString().Trim() == "E")
                            {
                                ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["RelMemType"].ToString().Trim();
                                ddllvlagttype.Enabled = false;
                                txtRptMgr.Enabled = false;
                                btnRptMgr.Enabled = false;
                            }
                        }
                        if (PrmyRptCnd == "E" && ddlambasedondesc.SelectedValue == "1")
                        {
                            ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                            ddllvlagttype.Enabled = false;
                        }
                        else if (PrmyRptCnd == "E" && ddlambasedondesc.SelectedValue == "0")
                        {
                            ddllvlagttype.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim(),
                                 ddlamchnldesc.SelectedValue.ToString().Trim(), ddlamsubchnldesc.SelectedValue.ToString().Trim());
                        }
                        else
                        {
                            hdnMemType.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                        }
                        if (ddllvlagttype.SelectedValue.Trim() != "")
                        {
                            if (dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString() == "RF")
                            {
                                trventype.Visible = true;
                            }
                            else
                            {
                                trventype.Visible = false;
                            }
                        }
                        else
                        {
                            trventype.Visible = false;
                        }
                        #endregion

                        hdnchn.Value = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        hdnsubchn.Value = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                        PopulateConstityp();
                        ddlLicTyp.SelectedIndex = 1;
                        ShowClient();

                        string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                        GetManagers();
                        GetAddlManagers();

                        funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    }
                    else
                    {
                        funShowCrntMgr("empty");
                    }
                }
                else
                {
                    funShowCrntMgr("empty");
                }
                #endregion

                #region Mandatory Managers
                if (dsRpt.Tables.Count > 0)
                {
                    if (dsRpt.Tables[0].Rows.Count > 0)
                    {
                        hdnPriMandatory.Value = dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString();
                        if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                        {
                            txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                            //lbpri.Visible = true;
                            txtRptMgr.Attributes.Add("class", "mandatory");
                        }
                    }
                }
                #endregion

                fillAddlRptMngrDtls();
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

        #region GridCndImage_RowDataBound
        protected void GridCndImage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnid = (HiddenField)e.Row.FindControl("hdnid");
                }
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

        ///added by akshay on 24/02/14 for candidate converting into agent end

        #region GetChnlCls
        protected void GetChnlCls(string BizSrc)
        {
            ddlChnCls.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htparam.Add("@BizSrc", BizSrc);
            dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);

            if (dtRead.HasRows)
            {
                ddlChnCls.DataSource = dtRead;
                ddlChnCls.DataTextField = "ChnlDesc";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            dtRead = null;
            ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        #endregion

        #region FillAgentType
        protected void FillAgentType(string strBizSrc, string strChnCls)
        {
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htparam.Add("@BizSrc", strBizSrc);
            htparam.Add("@ChnCls", strChnCls);
            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetAgnTypedesc", htparam);


            if (dtRead.HasRows)
            {
                ddlAgntType.DataSource = dtRead;
                ddlAgntType.DataTextField = "AgnDesc";
                ddlAgntType.DataValueField = "MemType";
                ddlAgntType.DataBind();
            }
            dtRead = null;
        }
        #endregion

        #region Patch Title-Gender Synchronization

        protected void setGenderForTitle()
        {
            if (cboagnTitle.SelectedValue == "MR" || cboagnTitle.SelectedValue == "MAST" || cboagnTitle.SelectedValue == "SHRI")
            {
                ddlGender.SelectedValue = "M";
            }
            else if (cboagnTitle.SelectedValue == "MRS" || cboagnTitle.SelectedValue == "MISS" || cboagnTitle.SelectedValue == "SMT")
            {
                ddlGender.SelectedValue = "F";
            }
            else if (cboagnTitle.SelectedValue == "M/S")
            {
                ddlGender.Enabled = false;
                txtDOB.Enabled = false;
                cboMaritalStatus.Enabled = false;
                ddlEducutn.Enabled = false;

                ddlGender.SelectedItem.Text = "Select";
                txtDOB.Text = "";
                cboMaritalStatus.SelectedItem.Text = "Select";
                ddlEducutn.SelectedItem.Text = "Select";
            }
            else
            {
				ddlGender.SelectedIndex = 0;
                ddlGender.Enabled = true;
                ddlGender.Focus();
            }
        }

        //protected void cboagnTitle_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    setGenderForTitle();
        //    cboagnTitle.Focus();

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "showBasicInfo();", true);

        //}

        protected void cboagnTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboagnTitle.SelectedValue == "M/S")
            {

                ddlGender.SelectedIndex = 0;
                cboMaritalStatus.Enabled = false;
                TxtAnnivrsryDt.Enabled = false;
                ddlEducutn.Enabled = false;
                txtDOB.Enabled = false;
                txtDOB.Text = "";
                ddlGender.Enabled = false;
				txtDOB.Attributes.Add("style", "border-color:lightgray !important");
            }
            else
            {
                cboMaritalStatus.Enabled = true;
                TxtAnnivrsryDt.Enabled = true;
                ddlEducutn.Enabled = true;
                txtDOB.Enabled = true;
				txtDOB.Attributes.Add("style", "border-color:red !important");
				//ddlGender.Enabled = true; commented by ajay
				//added by ajay for mr/ms disabled start
				if (cboagnTitle.SelectedValue == "MR" || cboagnTitle.SelectedValue == "MRS" || cboagnTitle.SelectedValue == "MISS")
                {
                    ddlGender.Enabled = false;
                }
                else
                {
                    ddlGender.Enabled = true;
                }
                //added by ajay for mr/ms disabled end
            }
            setGenderForTitle();
            cboagnTitle.Focus();
        }
        #endregion

        #region FillDDlAgnVenRelMap
        protected void FillDDlAgnVenRelMap()
        {

        }
        #endregion

        #region Patch for Date of Birth Validation
        ///Added: Parag
        ///To set the Range exactly 18 years before the current date.
        protected void rngval_DOB_init(object sender, EventArgs e)
        {
            DateTime tmpDateTime = new DateTime();
            tmpDateTime = DateTime.Now.Date.AddYears(-18);
            ((RangeValidator)sender).MaximumValue = tmpDateTime.ToString("yyyy-MM-dd");
        }
        #endregion

        #region Patch for Account Payee Number button

        #endregion

        #region ddlGender_SelectedIndexChanged
        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGender.SelectedValue == "")
            {
                cboagnTitle.SelectedIndex = 0;
            }
            ddlGender.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "showBasicInfo();", true);
        }
        #endregion

        #region funShowCrntMgr
        ///method to show reporting manager sections of current details and new details tab
        public void funShowCrntMgr(string str)
        {
            try
            {
                if (str == "empty")
                {
                    // trprirep.Visible = false;  //Comented by usha for FP on 14.01.2021 
                }
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

        #region ClrMgrText
        /// <summary>
        /// clearing textboxes and labels of reporting managers and unitcodes on changing heirarchy details
        /// </summary>
        protected void ClrMgrText()
        {
            txtRptMgr.Text = "";
            lblrptmgr.Text = "";
            hdnRptMgr.Value = null;


            txtUntCode.Text = "";
            lblUnitDesc.Text = "";
            lblUntAddr.Text = "";
            ///hdnutadr.Value = null;
            hdnUntCode.Value = null;
        }
        #endregion

        #region DisableRpt
        protected void DisableRpt()
        {
            txtRptMgr.Enabled = false;
            btnRptMgr.Enabled = false;
        }
        #endregion

        #region gv_RptMngr_RowDataBound
        protected void gv_RptMngr_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Mngrno = (Label)e.Row.FindControl("lblNo");
                DropDownList ddlAddlventype = (DropDownList)e.Row.FindControl("ddlAddlventype");
                DropDownList ddlRelModel = (DropDownList)e.Row.FindControl("ddlRelModel");
                DropDownList ddlAdlRptTyp = (DropDownList)e.Row.FindControl("ddlAdlRptTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)e.Row.FindControl("ddlAdlBsdOn");

                DropDownList ddlAdlChn = (DropDownList)e.Row.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)e.Row.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)e.Row.FindControl("ddlAdlAgtTyp");
                HiddenField hdnAddlStp = (HiddenField)e.Row.FindControl("hdnAddlStp");
                Label lblord = (Label)e.Row.FindControl("lblord");

                oCommon.getDropDown(ddlAddlventype, "ventype", 1, "", 1, c_strBlank);
                oCommon.getDropDown(ddlRelModel, "AgVenMapTyp", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlBsdOn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlRelModel.Items.Insert(0, new ListItem("--Select--", ""));


                funchnlpopup(ddlAdlChn);
                funsubchnlpopup(ddlAdlSChn, ddlAdlChn.SelectedValue.Trim());
                funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, lblord.Text);
                oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptTyp.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlSChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("--Select--", ""));

                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                ddlAdlAgtTyp.Enabled = true;//true by usha on 28.01.2022

            }
        }
        #endregion

        #region lnkRptMngr_Click
        protected void lnkRptMngr_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
            Button lnkRptMngr = (Button)grd.FindControl("lnkRptMngr");
            DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
            DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
            DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
            DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
            DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
            TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
            string strRowID = ((System.Web.UI.Control)(grd)).ClientID.ToString();
            string rowid = grd.RowIndex.ToString().Trim();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvUntLst.Rows.Count - 1; intRowCount++)
            {
                Label UntCode = (Label)gvUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                str = str + UntCode.Text;
                str += (intRowCount < gvUntLst.Rows.Count - 1) ? "," : string.Empty;
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "','" + str + "','" + rowid + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "','" + str + "','" + rowid + "');", true);
            }
        }
        #endregion

        #region MemVenMap
        protected void MemVenMap(string vcode)
        {
            //Added by swapnesh on 17/2/2014 for Agent-SM-vendor mapping start
            #region Agent-SM-vendor mapping
            if (vcode != "")
            {
                var vendorcode = vcode;
                for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
                {
                    CheckBox chkisprimry = gv_RptMngr.Rows[i].FindControl("chkisprimry") as CheckBox;

                    DropDownList ddlventype = gv_RptMngr.Rows[i].FindControl("ddlventype") as DropDownList;
                    DropDownList ddlRelModel = gv_RptMngr.Rows[i].FindControl("ddlRelModel") as DropDownList;

                    DropDownList ddlAdlRptTyp = gv_RptMngr.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                    DropDownList ddlAdlChn = gv_RptMngr.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                    DropDownList ddlAdlSChn = gv_RptMngr.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                    DropDownList ddlAdlBsdOn = gv_RptMngr.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                    DropDownList ddlAdlAgtTyp = gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;

                    TextBox txtRptMngr = gv_RptMngr.Rows[i].FindControl("txtRptMngr") as TextBox;

                    HiddenField hdnAddlRptMgr = gv_RptMngr.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;
                    HiddenField hdnRptMgrMandatory = gv_RptMngr.Rows[i].FindControl("hdnRptMgrMandatory") as HiddenField;

                    DropDownList ddladlRptLvl = gv_RptMngr.Rows[i].FindControl("ddlRptLvl") as DropDownList;

                    if (ddllvlagttype.SelectedValue == "SM" && ddlAdlAgtTyp.SelectedValue == "RF")
                    {
                        InsAgtSMVenMappDtls(ddlamchnldesc.SelectedValue, ddlamsubchnldesc.SelectedValue, hdnRptMgr.Value, ddlAdlChn.SelectedValue,
                                            ddlAdlSChn.SelectedValue, vendorcode, chkisprimry.Checked, ddlRelModel.SelectedValue);
                    }
                }

            }
            #endregion
            //Added by swapnesh on 17/2/2014 for Agent-SM-vendor mapping end
        }
        #endregion

        #region ddllvlagttype_SelectedIndexChanged
        protected void ddllvlagttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetManagers();
            txtRptMgr.Text = "";////080714
            lblrptmgr.Text = "";
            hdnRptMgr.Value = null;
            btndisabled();
            if (ddllvlagttype.SelectedItem.ToString().Trim() == "Independent")
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        #endregion

        #region RetMemType
        protected string RetMemType(string Urnk, string bizsrc, string chncls)
        {
            Hashtable htunt = new Hashtable();
            DataSet dsunt = new DataSet();
            string member = String.Empty;
            htunt.Clear();
            htunt.Add("@BizSrc", bizsrc.ToString().Trim());
            htunt.Add("@ChnCls", chncls.ToString().Trim());
            htunt.Add("@UnitRank", Urnk.ToString().Trim());
            dsunt = objDAL.GetDataSetForPrcCLP("PrcGetMemUnitRnk", htunt);
            if (dsunt != null)
            {
                if (dsunt.Tables[0].Rows.Count > 0)
                {
                    member = dsunt.Tables[0].Rows[0]["MemType"].ToString().Trim();
                }
            }
            else
            {
                dsunt = null;
                member = String.Empty;
            }
            return member;
        }
        #endregion

        #region ddlAdlAgtTyp_SelectedIndexChanged
        protected void ddlAdlAgtTyp_SelectedIndexChanged(object sender, EventArgs e)
        {///080714
            GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
            TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
            HiddenField hdnAddlRptMgr = grd.FindControl("hdnAddlRptMgr") as HiddenField;
            Label lblRptMngr = (Label)grd.FindControl("lblRptMngr");

            txtRptMngr.Text = "";
            hdnAddlRptMgr.Value = null;
            lblRptMngr.Text = "";
        }
        #endregion

        #region ddlAdlChn_SelectedIndexChanged
        protected void ddlAdlChn_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
            DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");

            DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
            DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
            DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");

            ddlAdlSChn.Enabled = true;
            try
            {
                ddlAdlSChn.Items.Clear();
                SqlDataReader dtRead;
                //Added by Pranjali on 02-07-2013 for Channel sub class dropdown start
                Hashtable htparam = new Hashtable();
                htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htparam.Add("@BizSrc", ddlAdlChn.SelectedValue.Trim());
                dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
                //Added by Pranjali on 02-07-2013 for Channel sub class dropdown end
                if (dtRead.HasRows)
                {
                    ddlAdlSChn.DataSource = dtRead;
                    ddlAdlSChn.DataTextField = "ChnlDesc";
                    ddlAdlSChn.DataValueField = "ChnCls";
                    ddlAdlSChn.DataBind();
                }
                dtRead = null;
                ddlAdlSChn.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlAdlSChn.SelectedValue = "";
                ddlAdlSChn.Enabled = true;
                if (ddlAdlChn.SelectedValue == "")
                {
                    ddlAdlSChn.Items.Clear();
                    ddlAdlSChn.Items.Insert(0, new ListItem("--Select--", ""));
                }

                Hashtable htParam = new Hashtable();
                DataSet dsVend = new DataSet();
                htParam.Clear();
                dsVend.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@BizSrc", ddlAdlChn.SelectedValue.ToString().Trim());
                htParam.Add("@MemType", ddlAdlAgtTyp.SelectedValue.ToString().Trim());
                dsVend = objDAL.GetDataSetForPrcCLP("Prc_GetVendorClass", htParam);
                if (dsVend != null)
                {
                    if (dsVend.Tables[0].Rows.Count > 0)
                    {
                        ddlAdlSChn.SelectedValue = dsVend.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region ddlAdlSChn_SelectedIndexChanged
        protected void ddlAdlSChn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region GetPopDtls
        protected DataSet GetPopDtls(string memcode)
        {
            #region GetBrkCode
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString().Trim()));
            htParam.Add("@AgentCode", memcode.ToString().Trim());
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString().Trim());

            dsResult = dataAccess.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            return dsResult;

            #endregion
        }
        #endregion

        #region btnunitgrid_Click
        protected void btnunitgrid_Click(object sender, EventArgs e)
        {
            if (Session["unt"] != null)
            {
                gvUntLst.DataSource = Session["unt"];
                gvUntLst.DataBind();

                string str = string.Empty;
                for (int intRowCount = 0; intRowCount <= gvUntLst.Rows.Count - 1; intRowCount++)
                {
                    Label UntCode = (Label)gvUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                    str = str + UntCode.Text;
                    str += (intRowCount < gvUntLst.Rows.Count - 1) ? "," : string.Empty;
                }

                if (Request.QueryString["Ctgry"] != null)
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

                }
                else
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

                }

            }
        }
        #endregion

        #region btnmemgrid_Click
        protected void btnmemgrid_Click(object sender, EventArgs e)
        {
            if (Session["mem"] != null)
            {
                gv.DataSource = Session["mem"];
                gv.DataBind();

                string str = string.Empty;
                for (int intRowCount = 0; intRowCount <= gv.Rows.Count - 1; intRowCount++)
                {
                    Label MemCode = (Label)gv.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
                    str = str + MemCode.Text;
                    str += (intRowCount < gv.Rows.Count - 1) ? "," : string.Empty;
                }

                if (Request.QueryString["Ctgry"] != null)
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Emp','" + str + "');return false;");
                }
                else
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Agent','" + str + "');return false;");
                }
            }
        }
        #endregion

        #region btnRptmemgrid_Click
        protected void btnRptmemgrid_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
            GridView gvAddlMgr = (GridView)grd.FindControl("gvAddlMgr");
            if (Session["addlmem"] != null)
            {
                gvAddlMgr.DataSource = Session["addlmem"];
                gvAddlMgr.DataBind();
            }


        }
        #endregion


        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                //Added by pranjali on 27-12-2013 start
                GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
                FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
                Label lbldocname = (Label)row.FindControl("lbldocName");
                Label lblimgsize = (Label)row.FindControl("lblimgsize");
                Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
                Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
                Label lblimgheight = (Label)row.FindControl("lblimgheight");
                Label lbldoccode = (Label)row.FindControl("lbldoccode");
                Button btnreupd = (Button)row.FindControl("btn_ReUpload");
                Button btn_Upload = (Button)row.FindControl("btn_Upload");
                LinkButton lnkPreview = (LinkButton)row.FindControl("lnkPreview");
                BMaxImgSize = Convert.ToInt32(lblimgsize.Text);
                string strFilePath = string.Empty;

                //if (Directory.Exists(strPath) == false)
                //{
                //    strPath = strPath + txtAgtCode.Text.ToString().Trim();
                //    Directory.CreateDirectory(strPath);
                //}
                //else
                //{
                //    strFilePath = strPath + txtAgtCode.Text.ToString().Trim();
                //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
                //    if (!Directory.Exists(strFilePath))
                //    {
                //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
                //        Directory.CreateDirectory(strFilePath);
                //    }
                //    else
                //    {
                //        strFilePath = strPath + txtAgtCode.Text.ToString().Trim();
                //    }
                //}

                #region Upload

                if (fuData.HasFile)
                {
                    if (fuData.HasFile)
                    {
                        strDocName = fuData.PostedFile.FileName;
                        strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
                    }
                }
                else
                {
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocname.Text + " File for Upload');</script>");
                    return;
                }
                if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
                {
                    strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                    strFileName = strFilePath + "\\" + strFileName1;
                }
                else if (strPhotoExt == "PNG" || strPhotoExt == "png")
                {
                    strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                    strFileName = strFilePath + "\\" + strFileName1;
                }
                else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
                {
                    strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                    strFileName = strFilePath + "\\" + strFileName1;
                }
                else if (strPhotoExt == "PDF")
                {
                    strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                    strFileName = strFilePath + "\\" + strFileName1;
                }
                else
                {
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Invalid File Format');</script>");
                    return;
                }
                if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
                {
                    //pranj
                    System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
                    if (fuData.PostedFile.ContentLength <= BMaxImgSize)
                    {
                        if (strPhotoExt != string.Empty)
                        {
                            image_height = image_file.Height;
                            image_width = image_file.Width;
                            //Set image height and width to panel height and width iff the image is greater than panel dimensions start
                            if ((image_height > Convert.ToInt32(lblimgheight.Text) && image_width > Convert.ToInt32(lblimgwidth.Text))
                                || (image_height > Convert.ToInt32(lblimgheight.Text) || image_width > Convert.ToInt32(lblimgwidth.Text)))
                            {
                                max_height = Convert.ToInt32(lblimgheight.Text);
                                max_width = Convert.ToInt32(lblimgwidth.Text);
                            }
                            else
                            {
                                max_height = image_height;
                                max_width = image_width;
                            }
                            //Set image height and width to panel height and width iff the image is greater than panel dimensions end


                            image_height = (image_height * max_width) / image_width;
                            image_width = max_width;

                            if (image_height > max_height)
                            {
                                image_width = (image_width * max_height) / image_height;
                                image_height = max_height;
                            }
                            else
                            {
                            }
                            Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
                            System.IO.MemoryStream stream = new System.IO.MemoryStream();
                            bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            stream.Position = 0;

                            data = new byte[stream.Length + 1];
                            stream.Read(data, 0, data.Length);

                        }

                        else
                        {
                            var message = new JavaScriptSerializer().Serialize("Please Upload an image");
                            var script = string.Format("alert({0});", message);
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                            return;

                        }
                    }
                    else
                    {
                        int SIZE = BMaxImgSize / 1024;
                        RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
                        return;
                    }
                }
                else
                {
                    if (strPhotoExt == "PDF")
                    {
                        if (lbldoccode.Text.Trim() == "11" || lbldoccode.Text.Trim() == "12")
                        {
                            var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
                            var script = string.Format("alert({0});", message);
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                            return;
                        }
                        else
                        {
                            if (fuData.PostedFile.ContentLength > 2048)
                            {
                                using (Stream fs = fuData.PostedFile.InputStream)
                                {
                                    using (BinaryReader br = new BinaryReader(fs))
                                    {
                                        data = br.ReadBytes((Int32)fs.Length);
                                    }
                                }
                            }
                            else
                            {
                                var message = new JavaScriptSerializer().Serialize("Max File size is 2MB.");
                                var script = string.Format("alert({0});", message);
                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                                return;
                            }
                        }
                    }
                    else
                    {
                        var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
                        var script = string.Format("alert({0});", message);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                        return;

                    }
                }
                //pranj
                //FileInfo fi = new FileInfo(Server.MapPath(strFileName));
                FileInfo fi = new FileInfo(strFileName);
                //commented by sanoj 02012022
                //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)) //Commented for overwritting of image instead of creating new image with same name
                //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                //{
                byte[] byteData = fuData.FileBytes;
                //byte[] byteData = data;
                //    fileStream.Write(byteData, 0, byteData.Length);
                //}


                //else
                //{
                //    int SIZE = BMaxImgSize / 1024;
                //    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
                //    return;
                //}
                //}
                #endregion


                string str1 = strFileName.Replace(@"\", @"/");
                string[] actualpath = str1.Split('/');
                strFileName = actualpath[0] + "\\" + actualpath[1]; //+ "\\" + actualpath[3];

                Hashtable htdata = new Hashtable();
                htdata.Clear();
                htdata.Add("@Memcode", txtAgtCode.Text.ToString().Trim());// txtMemberCode.Text.Trim()
                htdata.Add("@UserFileName", strFileName);
                htdata.Add("@ServerFileName", strFileName1);
                htdata.Add("@DocType", lbldocname.Text.Trim());
                htdata.Add("@UserID", Session["UserID"].ToString().Trim());
                htdata.Add("@DctmFlag", 'N');
                htdata.Add("@DocStatus", "0"); //Added by pranjali on 27-12-2013
                htdata.Add("@Imagebin", data);
                htdata.Add("@DocCode", lbldoccode.Text.Trim());
                htdata.Add("@FileType", strPhotoExt);
                try
                {

                    //GetCandidateDtls();
                    if (strProcessType == "NC")
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);

                    }
                    else
                    {
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                        {
                            // intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
                            //aded by sanoj
                            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
                        }

                        else if (Request.QueryString["Type"].ToString().Trim() == "R") //shreela 26-03-2014
                        {
                            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
                        }

                        else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                        {
                            //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                        }
                        //shreela 26-03-2014 start
                        else if (Request.QueryString["Type"].ToString().Trim() == "Renwl") //shreela 26-03-2014
                        {
                            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                            //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela on 09/06/2014
                            //mdlViewRen.Show();
                            //pnlMdlRen.Visible = true;
                        }
                        //shreela 26-03-2014 end
                        //added by shreela on 21042014---start
                        else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                        {
                            //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                            //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela 
                            //mdlViewRen.Show();
                            //pnlMdlRen.Visible = true;

                        }
                    }
                    //added by shreela on 21042014---end
                }
                catch (Exception ex)
                {
                    //trmsg.Visible = true;
                    lblMessage.Text = ex.Message.ToString();
                    lblMessage.Visible = true;


                    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                    string sRet = oInfo.Name;
                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    String LogClassName = method.ReflectedType.Name;
                    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                }

                fuData.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                string Docname = lbldocname.Text;
                //hdnDocName.Value = lbldocname.Text.Trim();
                btnreupd.Enabled = true;
                btnreupd.Visible = true;
                btn_Upload.Enabled = false;
                btn_Upload.Visible = false;
                lnkPreview.Visible = true;
                //txtExmCentre.Text = hdnExmCentreCode.Value;
                //Filluploadedfile();//Docname
                //added by ajay 06-05-2022 start
                if (lbldocname.Text.Trim() == "GST Certificate")
                {
                    chkgst.Enabled = false;
                    chkagree.Enabled = false;
                    btngst.Enabled = false;
                    btnView.Enabled = false;
                    ViewState["Gst"] = lbldocname.Text.Trim();
                }
                if (lbldocname.Text.Trim() == "Signature")
                {
                    if (ViewState["Gst"].ToString() == "GST Certificate")
                    {
                        chkgst.Enabled = false;
                        chkagree.Enabled = true;
                        btngst.Enabled = false;
                        btnView.Enabled = true;
                    }
                    else
                    {
                        chkgst.Enabled = true; //added by sanoj 22062022
                        chkagree.Enabled = true; //added by sanoj 22062022
                        btngst.Enabled = true;
                        btnView.Enabled = true;
                    }
                }
                //added by ajay 06-05-2022 end
            }
            catch (Exception ex)
            {
                //trmsg.Visible = true;
                lblMessage.Text = ex.Message.ToString().Trim();
                lblMessage.Visible = true;

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

        }
        protected void btn_ReUpload_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
            FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
            Label lbldocName = (Label)row.FindControl("lbldocName");
            Label lblUpldBy = (Label)row.FindControl("lblUpldBy");
            Label lblUpdDtTm = (Label)row.FindControl("lblUpdDtTm");
            Label lblFileName = (Label)row.FindControl("lblFileName");
            Label lblimgsize1 = (Label)row.FindControl("lblimgsize");
            Label lblimgshrt1 = (Label)row.FindControl("lblimgshrt");
            Label lblimgwidth1 = (Label)row.FindControl("lblimgwidth");
            Label lblimgheight1 = (Label)row.FindControl("lblimgheight");
            Label lbldoccode1 = (Label)row.FindControl("lbldoccode");
            Button btnreupd = (Button)row.FindControl("btn_ReUpload");
            Button btn_Upload = (Button)row.FindControl("btn_Upload");
            BMaxImgSize1 = Convert.ToInt32(lblimgsize1.Text);
            string strFileRePath = string.Empty;
            //Added BY Nikhil

            //int Memcode = 21018407;
            //if (Directory.Exists(strPath) == false)
            //{
            //    strPath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
            //    Directory.CreateDirectory(strPath);
            //}
            //else
            //{
            //    strFileRePath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
            //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
            //    if (!Directory.Exists(strFileRePath))
            //    {
            //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
            //        Directory.CreateDirectory(strFileRePath);
            //    }
            //    else
            //    {
            //        strFileRePath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
            //    }
            //}
            //Ended By Nikhil


            #region ReUpload

            if (fuData.HasFile)
            {
                if (fuData.HasFile)
                {
                    strDocName = fuData.PostedFile.FileName;
                    strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
                }
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocName.Text + " File for ReUpload');</script>");
                return;
            }
            if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
            {
                strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
                strFileName = strFileRePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PNG" || strPhotoExt == "png")
            {

                strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
                strFileName = strFileRePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
            {
                strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
                strFileName = strFileRePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PDF")
            {
                strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
                strFileName = strFileRePath + "\\" + strFileName1;
            }


            if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
            {
                //pranj
                System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
                if (strPhotoExt != string.Empty)
                {

                    image_height = image_file.Height;
                    image_width = image_file.Width;
                    //Set image height and width to panel height and width iff the image is greater than panel dimensions start
                    if ((image_height > Convert.ToInt32(lblimgheight1.Text) && image_width > Convert.ToInt32(lblimgwidth1.Text))
                                || (image_height > Convert.ToInt32(lblimgheight1.Text) || image_width > Convert.ToInt32(lblimgwidth1.Text)))
                    {
                        max_height = Convert.ToInt32(lblimgheight1.Text);
                        max_width = Convert.ToInt32(lblimgwidth1.Text);
                    }
                    else
                    {
                        max_height = image_height;
                        max_width = image_width;
                    }
                    //Set image height and width to panel height and width iff the image is greater than panel dimensions end

                    image_height = (image_height * max_width) / image_width;
                    image_width = max_width;

                    if (image_height > max_height)
                    {
                        image_width = (image_width * max_height) / image_height;
                        image_height = max_height;
                    }
                    else
                    {
                    }
                    Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Position = 0;

                    data = new byte[stream.Length + 1];
                    stream.Read(data, 0, data.Length);

                }

                else
                {
                    var message = new JavaScriptSerializer().Serialize("Please Upload an image");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                    return;

                }
            }
            else
            {
                if (strPhotoExt == "PDF")
                {
                    if (lbldoccode1.Text.Trim() == "11" || lbldoccode1.Text.Trim() == "12")
                    {
                        var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
                        var script = string.Format("alert({0});", message);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                        return;
                    }
                    else
                    {
                        if (fuData.PostedFile.ContentLength > 2048)
                        {
                            using (Stream fs = fuData.PostedFile.InputStream)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    data = br.ReadBytes((Int32)fs.Length);
                                }
                            }
                        }
                        else
                        {
                            var message = new JavaScriptSerializer().Serialize("Max File Size is 2MB.");
                            var script = string.Format("alert({0});", message);
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                            return;
                        }
                    }
                }
                else
                {
                    var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                    return;

                }
            }
            Hashtable htdata = new Hashtable();
            FileInfo fi = new FileInfo(strPath);
            {
                if (fuData.PostedFile.ContentLength <= BMaxImgSize1)
                {
                    if (File.Exists(strFileName))
                    {
                        string stroldpath = strFileRePath + "\\" + strFileName1;
                        string[] strfile = strFileName1.Split('.');
                        htdata.Clear();
                        string ImageNamenew = strfile[0];
                        htdata.Clear();
                        htdata.Add("@MemCode", txtAgtCode.Text.ToString().Trim());//Request.QueryString["MemCode"].ToString().Trim());
                        htdata.Add("@doctype", lbldocName.Text.Trim());
                        //dsResult.Clear();
                        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDocStatusMem", htdata);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DocStatusCount = dsResult.Tables[0].Rows[0]["DocStatusCount"].ToString().Trim();
                            }
                        }
                        string strnewpath = strFileRePath + "\\" + ImageNamenew + "_R" + DocStatusCount + "." + strPhotoExt;
                        //System.IO.File.Move(Server.MapPath(stroldpath), Server.MapPath(strnewpath));
                        //System.IO.File.Move(stroldpath, strnewpath); //Commented as not allowing duplicate entry to overwride
                        System.IO.File.Copy(stroldpath, strnewpath, true);
                    }
                }
                else
                {
                    int SIZE1 = BMaxImgSize1 / 1024;
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE1 + "Kb');</script>");
                    return;
                }
            }

            #endregion

            strDestPath = System.IO.Path.Combine(strFileRePath, strFileName);

            //fuData.PostedFile.SaveAs(Server.MapPath(strFileName));
            fuData.PostedFile.SaveAs((strFileName));
            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1];// + "\\" + actualpath[3];
            //strFileName = actualpath[4] + "\\" + actualpath[5] + "\\" + actualpath[6];
            htdata.Clear();
            htdata.Add("@Memcode", txtAgtCode.Text.ToString().Trim());
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocName.Text.Trim());
            htdata.Add("@UserID", Session["UserID"].ToString().Trim());
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "1"); //Added by pranjali on 27-12-2013
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode1.Text.Trim());
            htdata.Add("@FileType", strPhotoExt);
            try
            {
                //GetCandidateDtls();
                if (strProcessType == "NC")
                {
                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
                }
                else
                {
                    if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                    {
                        // intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
                        //aded by sanoj
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }

                    if (Request.QueryString["Type"].ToString().Trim() == "R")
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }
                    //Added By pranjali on 02-01-2014 start
                    else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                    {
                        //intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }
                    //Added By pranjali on 02-01-2014 end
                    //added by shreela
                    else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }
                    else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }
                }
                //added by shreela
            }
            catch (Exception ex)
            {
                //trmsg.Visible = true;
                lblMessage.Text = ex.Message.ToString();
                lblMessage.Visible = true;

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

            fuData.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            string Docname = lbldocName.Text;
            //FillReuploadedfile(Docname);//Docname
            //Filluploadedfile();
        }

        //protected void btn_Upload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
        //        FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
        //        Label lbldocname = (Label)row.FindControl("lbldocName");
        //        Label lblimgsize = (Label)row.FindControl("lblimgsize");
        //        Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
        //        Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
        //        Label lblimgheight = (Label)row.FindControl("lblimgheight");
        //        Label lbldoccode = (Label)row.FindControl("lbldoccode");
        //        Button btnreupd = (Button)row.FindControl("btn_ReUpload");
        //        Button btn_Upload = (Button)row.FindControl("btn_Upload");
        //        LinkButton lnkPreview = (LinkButton)row.FindControl("lnkPreview");
        //        BMaxImgSize = Convert.ToInt32(lblimgsize.Text);
        //        string strFilePath = string.Empty;


        //        //if (Directory.Exists(strPath) == false)
        //        //{
        //        //    strPath = strPath + txtAgtCode.Text.ToString().Trim();
        //        //    Directory.CreateDirectory(strPath);
        //        //}
        //        //else
        //        //{
        //        //    strFilePath = strPath + txtAgtCode.Text.ToString().Trim();
        //        //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
        //        //    if (!Directory.Exists(strFilePath))
        //        //    {
        //        //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
        //        //        Directory.CreateDirectory(strFilePath);
        //        //    }
        //        //    else
        //        //    {
        //        //        strFilePath = strPath + txtAgtCode.Text.ToString().Trim();
        //        //    }
        //        //}

        //        #region Upload

        //        if (fuData.HasFile)
        //        {
        //            if (fuData.HasFile)
        //            {
        //                strDocName = fuData.PostedFile.FileName;
        //                strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
        //            }
        //        }
        //        else
        //        {
        //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showalert (alert('Please Select " + lbldocname.Text + " File for Upload'));", true);
        //            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocname.Text + " File for Upload');</script>");
        //            return;
        //        }
        //        if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
        //        {
        //            strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
        //            strFileName = strFilePath + "\\" + strFileName1;
        //        }
        //        else if (strPhotoExt == "PNG" || strPhotoExt == "png")
        //        {
        //            strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
        //            strFileName = strFilePath + "\\" + strFileName1;
        //        }
        //        else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        //        {
        //            strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
        //            strFileName = strFilePath + "\\" + strFileName1;
        //        }
        //        else if (strPhotoExt == "PDF")
        //        {
        //            strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
        //            strFileName = strFilePath + "\\" + strFileName1;
        //        }
        //        else
        //        {
        //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showalert (alert('Invalid File Format'));", true);
        //            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Invalid File Format');</script>");
        //            return;
        //        }
        //        if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
        //        {
        //            //pranj
        //            System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
        //            if (fuData.PostedFile.ContentLength <= BMaxImgSize)
        //            {
        //                if (strPhotoExt != string.Empty)
        //                {
        //                    image_height = image_file.Height;
        //                    image_width = image_file.Width;
        //                    //Set image height and width to panel height and width iff the image is greater than panel dimensions start
        //                    if ((image_height > Convert.ToInt32(lblimgheight.Text) && image_width > Convert.ToInt32(lblimgwidth.Text))
        //                        || (image_height > Convert.ToInt32(lblimgheight.Text) || image_width > Convert.ToInt32(lblimgwidth.Text)))
        //                    {
        //                        max_height = Convert.ToInt32(lblimgheight.Text);
        //                        max_width = Convert.ToInt32(lblimgwidth.Text);
        //                    }
        //                    else
        //                    {
        //                        max_height = image_height;
        //                        max_width = image_width;
        //                    }
        //                    //Set image height and width to panel height and width iff the image is greater than panel dimensions end


        //                    image_height = (image_height * max_width) / image_width;
        //                    image_width = max_width;

        //                    if (image_height > max_height)
        //                    {
        //                        image_width = (image_width * max_height) / image_height;
        //                        image_height = max_height;
        //                    }
        //                    else
        //                    {
        //                    }
        //                    Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
        //                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
        //                    bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                    stream.Position = 0;

        //                    data = new byte[stream.Length + 1];
        //                    stream.Read(data, 0, data.Length);

        //                }

        //                else
        //                {
        //                    var message = new JavaScriptSerializer().Serialize("Please Upload an image");
        //                    var script = string.Format("alert({0});", message);
        //                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                    return;

        //                }
        //            }
        //            else
        //            {
        //                int SIZE = BMaxImgSize / 1024;
        //                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (strPhotoExt == "PDF")
        //            {
        //                if (lbldoccode.Text.Trim() == "11" || lbldoccode.Text.Trim() == "12")
        //                {
        //                    var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
        //                    var script = string.Format("alert({0});", message);
        //                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                    return;
        //                }
        //                else
        //                {
        //                    if (fuData.PostedFile.ContentLength > 2048)
        //                    {
        //                        using (Stream fs = fuData.PostedFile.InputStream)
        //                        {
        //                            using (BinaryReader br = new BinaryReader(fs))
        //                            {
        //                                data = br.ReadBytes((Int32)fs.Length);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        var message = new JavaScriptSerializer().Serialize("Max File size is 2MB.");
        //                        var script = string.Format("alert({0});", message);
        //                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                        return;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
        //                var script = string.Format("alert({0});", message);
        //                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                return;

        //            }
        //        }
        //        //pranj
        //        //FileInfo fi = new FileInfo(Server.MapPath(strFileName));
        //        FileInfo fi = new FileInfo(strFileName);
        //        //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)) //Commented for overwritting of image instead of creating new image with same name
        //        using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
        //        {
        //            byte[] byteData = fuData.FileBytes;
        //            //byte[] byteData = data;
        //            fileStream.Write(byteData, 0, byteData.Length);
        //        }


        //        //else
        //        //{
        //        //    int SIZE = BMaxImgSize / 1024;
        //        //    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
        //        //    return;
        //        //}
        //        //}
        //        #endregion


        //        string str1 = strFileName.Replace(@"\", @"/");
        //        string[] actualpath = str1.Split('/');
        //        strFileName = actualpath[0] + "\\" + actualpath[1]; //+ "\\" + actualpath[3];

        //        Hashtable htdata = new Hashtable();
        //        htdata.Clear();
        //        htdata.Add("@Memcode", txtAgtCode.Text.ToString().Trim());// txtMemberCode.Text.Trim()
        //        htdata.Add("@UserFileName", strFileName);
        //        htdata.Add("@ServerFileName", strFileName1);
        //        htdata.Add("@DocType", lbldocname.Text.Trim());
        //        htdata.Add("@UserID", Session["UserID"].ToString().Trim());
        //        htdata.Add("@DctmFlag", 'N');
        //        htdata.Add("@DocStatus", "0"); //Added by pranjali on 27-12-2013
        //        htdata.Add("@Imagebin", data);
        //        htdata.Add("@DocCode", lbldoccode.Text.Trim());
        //        htdata.Add("@FileType", strPhotoExt);
        //        try
        //        {

        //            //GetCandidateDtls();
        //            if (strProcessType == "NC")
        //            {
        //                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);

        //            }
        //            else
        //            {
        //                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
        //                {
        //                    // intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
        //                    //aded by sanoj
        //                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
        //                }

        //                else if (Request.QueryString["Type"].ToString().Trim() == "R") //shreela 26-03-2014
        //                {
        //                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
        //                }

        //                else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
        //                {
        //                    //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
        //                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //                }
        //                //shreela 26-03-2014 start
        //                else if (Request.QueryString["Type"].ToString().Trim() == "Renwl") //shreela 26-03-2014
        //                {
        //                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //                    //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela on 09/06/2014
        //                    //mdlViewRen.Show();
        //                    //pnlMdlRen.Visible = true;
        //                }
        //                //shreela 26-03-2014 end
        //                //added by shreela on 21042014---start
        //                else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
        //                {
        //                    //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
        //                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //                    //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela 
        //                    //mdlViewRen.Show();
        //                    //pnlMdlRen.Visible = true;

        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            //trmsg.Visible = true;
        //            lblMessage.Text = ex.Message.ToString();
        //            lblMessage.Visible = true;


        //            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //            string sRet = oInfo.Name;
        //            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //            String LogClassName = method.ReflectedType.Name;
        //            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //        }

        //        fuData.Dispose();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();

        //        string Docname = lbldocname.Text;
        //        //hdnDocName.Value = lbldocname.Text.Trim();
        //        btnreupd.Enabled = true;
        //        btnreupd.Visible = true;
        //        btn_Upload.Enabled = false;
        //        btn_Upload.Visible = false;
        //        lnkPreview.Visible = true;
        //        //txtExmCentre.Text = hdnExmCentreCode.Value;
        //        //Filluploadedfile();//Docname
        //    }
        //    catch (Exception ex)
        //    {
        //        //trmsg.Visible = true;
        //        lblMessage.Text = ex.Message.ToString().Trim();
        //        lblMessage.Visible = true;

        //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //        string sRet = oInfo.Name;
        //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //        String LogClassName = method.ReflectedType.Name;
        //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //    }

        //}
        //protected void btn_ReUpload_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
        //    FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
        //    Label lbldocName = (Label)row.FindControl("lbldocName");
        //    Label lblUpldBy = (Label)row.FindControl("lblUpldBy");
        //    Label lblUpdDtTm = (Label)row.FindControl("lblUpdDtTm");
        //    Label lblFileName = (Label)row.FindControl("lblFileName");
        //    Label lblimgsize1 = (Label)row.FindControl("lblimgsize");
        //    Label lblimgshrt1 = (Label)row.FindControl("lblimgshrt");
        //    Label lblimgwidth1 = (Label)row.FindControl("lblimgwidth");
        //    Label lblimgheight1 = (Label)row.FindControl("lblimgheight");
        //    Label lbldoccode1 = (Label)row.FindControl("lbldoccode");
        //    Button btnreupd = (Button)row.FindControl("btn_ReUpload");
        //    Button btn_Upload = (Button)row.FindControl("btn_Upload");
        //    BMaxImgSize1 = Convert.ToInt32(lblimgsize1.Text);
        //    string strFileRePath = string.Empty;
        //    //Added BY Nikhil

        //    //int Memcode = 21018407;
        //    //if (Directory.Exists(strPath) == false)
        //    //{
        //    //    strPath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
        //    //    Directory.CreateDirectory(strPath);
        //    //}
        //    //else
        //    //{
        //    //    strFileRePath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
        //    //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
        //    //    if (!Directory.Exists(strFileRePath))
        //    //    {
        //    //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
        //    //        Directory.CreateDirectory(strFileRePath);
        //    //    }
        //    //    else
        //    //    {
        //    //        strFileRePath = strPath + txtAgtCode.Text.ToString().Trim(); //lblCndNoValue.Text.Trim();
        //    //    }
        //    //}
        //    //Ended By Nikhil

        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showDocupld();", true);
        //    #region ReUpload

        //    if (fuData.HasFile)
        //    {
        //        if (fuData.HasFile)
        //        {
        //            strDocName = fuData.PostedFile.FileName;
        //            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
        //        }
        //    }
        //    else
        //    {
        //        RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocName.Text + " File for ReUpload');</script>");
        //        return;
        //    }
        //    if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
        //    {
        //        strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
        //        strFileName = strFileRePath + "\\" + strFileName1;
        //    }
        //    else if (strPhotoExt == "PNG" || strPhotoExt == "png")
        //    {

        //        strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
        //        strFileName = strFileRePath + "\\" + strFileName1;
        //    }
        //    else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        //    {
        //        strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
        //        strFileName = strFileRePath + "\\" + strFileName1;
        //    }
        //    else if (strPhotoExt == "PDF")
        //    {
        //        strFileName1 = txtAgtCode.Text.ToString().Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
        //        strFileName = strFileRePath + "\\" + strFileName1;
        //    }


        //    if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
        //    {
        //        //pranj
        //        System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
        //        if (strPhotoExt != string.Empty)
        //        {

        //            image_height = image_file.Height;
        //            image_width = image_file.Width;
        //            //Set image height and width to panel height and width iff the image is greater than panel dimensions start
        //            if ((image_height > Convert.ToInt32(lblimgheight1.Text) && image_width > Convert.ToInt32(lblimgwidth1.Text))
        //                        || (image_height > Convert.ToInt32(lblimgheight1.Text) || image_width > Convert.ToInt32(lblimgwidth1.Text)))
        //            {
        //                max_height = Convert.ToInt32(lblimgheight1.Text);
        //                max_width = Convert.ToInt32(lblimgwidth1.Text);
        //            }
        //            else
        //            {
        //                max_height = image_height;
        //                max_width = image_width;
        //            }
        //            //Set image height and width to panel height and width iff the image is greater than panel dimensions end

        //            image_height = (image_height * max_width) / image_width;
        //            image_width = max_width;

        //            if (image_height > max_height)
        //            {
        //                image_width = (image_width * max_height) / image_height;
        //                image_height = max_height;
        //            }
        //            else
        //            {
        //            }
        //            Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
        //            System.IO.MemoryStream stream = new System.IO.MemoryStream();
        //            bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            stream.Position = 0;

        //            data = new byte[stream.Length + 1];
        //            stream.Read(data, 0, data.Length);

        //        }

        //        else
        //        {
        //            var message = new JavaScriptSerializer().Serialize("Please Upload an image");
        //            var script = string.Format("alert({0});", message);
        //            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //            return;

        //        }
        //    }
        //    else
        //    {
        //        if (strPhotoExt == "PDF")
        //        {
        //            if (lbldoccode1.Text.Trim() == "11" || lbldoccode1.Text.Trim() == "12")
        //            {
        //                var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
        //                var script = string.Format("alert({0});", message);
        //                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                return;
        //            }
        //            else
        //            {
        //                if (fuData.PostedFile.ContentLength > 2048)
        //                {
        //                    using (Stream fs = fuData.PostedFile.InputStream)
        //                    {
        //                        using (BinaryReader br = new BinaryReader(fs))
        //                        {
        //                            data = br.ReadBytes((Int32)fs.Length);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    var message = new JavaScriptSerializer().Serialize("Max File Size is 2MB.");
        //                    var script = string.Format("alert({0});", message);
        //                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
        //            var script = string.Format("alert({0});", message);
        //            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
        //            return;

        //        }
        //    }
        //    Hashtable htdata = new Hashtable();
        //    FileInfo fi = new FileInfo(strPath);
        //    {
        //        if (fuData.PostedFile.ContentLength <= BMaxImgSize1)
        //        {
        //            if (File.Exists(strFileName))
        //            {
        //                string stroldpath = strFileRePath + "\\" + strFileName1;
        //                string[] strfile = strFileName1.Split('.');
        //                htdata.Clear();
        //                string ImageNamenew = strfile[0];
        //                htdata.Clear();
        //                htdata.Add("@MemCode", txtAgtCode.Text.ToString().Trim());//Request.QueryString["MemCode"].ToString().Trim());
        //                htdata.Add("@doctype", lbldocName.Text.Trim());
        //                //dsResult.Clear();
        //                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDocStatusMem", htdata);
        //                if (dsResult.Tables.Count > 0)
        //                {
        //                    if (dsResult.Tables[0].Rows.Count > 0)
        //                    {
        //                        DocStatusCount = dsResult.Tables[0].Rows[0]["DocStatusCount"].ToString().Trim();
        //                    }
        //                }
        //                string strnewpath = strFileRePath + "\\" + ImageNamenew + "_R" + DocStatusCount + "." + strPhotoExt;
        //                //System.IO.File.Move(Server.MapPath(stroldpath), Server.MapPath(strnewpath));
        //                //System.IO.File.Move(stroldpath, strnewpath); //Commented as not allowing duplicate entry to overwride
        //                System.IO.File.Copy(stroldpath, strnewpath, true);
        //            }
        //        }
        //        else
        //        {
        //            int SIZE1 = BMaxImgSize1 / 1024;
        //            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE1 + "Kb');</script>");
        //            return;
        //        }
        //    }

        //    #endregion

        //    strDestPath = System.IO.Path.Combine(strFileRePath, strFileName);

        //    //fuData.PostedFile.SaveAs(Server.MapPath(strFileName));
        //    fuData.PostedFile.SaveAs((strFileName));
        //    string str1 = strFileName.Replace(@"\", @"/");
        //    string[] actualpath = str1.Split('/');
        //    strFileName = actualpath[0] + "\\" + actualpath[1];// + "\\" + actualpath[3];
        //    //strFileName = actualpath[4] + "\\" + actualpath[5] + "\\" + actualpath[6];
        //    htdata.Clear();
        //    htdata.Add("@Memcode", txtAgtCode.Text.ToString().Trim());
        //    htdata.Add("@UserFileName", strFileName);
        //    htdata.Add("@ServerFileName", strFileName1);
        //    htdata.Add("@DocType", lbldocName.Text.Trim());
        //    htdata.Add("@UserID", Session["UserID"].ToString().Trim());
        //    htdata.Add("@DctmFlag", 'N');
        //    htdata.Add("@DocStatus", "1"); //Added by pranjali on 27-12-2013
        //    htdata.Add("@Imagebin", data);
        //    htdata.Add("@DocCode", lbldoccode1.Text.Trim());
        //    htdata.Add("@FileType", strPhotoExt);
        //    try
        //    {
        //        //GetCandidateDtls();
        //        if (strProcessType == "NC")
        //        {
        //            intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
        //        }
        //        else
        //        {
        //            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
        //            {
        //                // intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload   ", htdata);
        //                //aded by sanoj
        //                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //            }

        //            if (Request.QueryString["Type"].ToString().Trim() == "R")
        //            {
        //                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //            }
        //            //Added By pranjali on 02-01-2014 start
        //            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
        //            {
        //                //intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
        //                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //            }
        //            //Added By pranjali on 02-01-2014 end
        //            //added by shreela
        //            else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
        //            {
        //                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //            }
        //            else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
        //            {
        //                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        //            }
        //        }
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showDocupld();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        //trmsg.Visible = true;
        //        lblMessage.Text = ex.Message.ToString();
        //        lblMessage.Visible = true;

        //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //        string sRet = oInfo.Name;
        //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //        String LogClassName = method.ReflectedType.Name;
        //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //    }

        //    fuData.Dispose();
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    string Docname = lbldocName.Text;
        //    //FillReuploadedfile(Docname);//Docname
        //    //Filluploadedfile();
        //}


        protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblupdSize = (Label)e.Row.FindControl("lblupdSize");
                Label lblManDoc = (Label)e.Row.FindControl("lblManDoc");
                Button btn_Upload = (Button)e.Row.FindControl("btn_Upload");
                Button btn_ReUpload = (Button)e.Row.FindControl("btn_ReUpload");
                Label lbldoccode = (Label)e.Row.FindControl("lbldoccode");
                LinkButton lnkPreview = (LinkButton)e.Row.FindControl("lnkPreview");
                if (Request.QueryString["Type"] == "CndStat") 	// Added by sanoj aj 20-01-2022  
                {
                    //e.Row.Cells[3].Enabled = false;
                    e.Row.Cells[4].Enabled = false;
                    FileUpload.Enabled = false;
                }
                if (Request.QueryString["Type"] == "E") 	// Added by sanoj 17052023 
                {
                    btn_ReUpload.Enabled = false;
                }
                if (lblupdSize != null && lblupdSize.Text != "")
                {
                    int updsize = Convert.ToInt32(lblupdSize.Text);
                    int sizeupd = updsize / 1024;
                    lblupdSize.Text = Convert.ToString(sizeupd);
                }
                if (lblManDoc.Text == "Y")
                {
                    //e.Row.BackColor = Color.LightPink;

                }
                else if (lblManDoc.Text == "C" && lbldoccode.Text == "15")
                {
                    Hashtable htPanchayat = new Hashtable();
                    DataSet ds_panchayat = new DataSet();
                    htPanchayat.Add("@CndNo", Request.QueryString["MemCode"].ToString().Trim());
                    ds_panchayat = dataAccessRecruit.GetDataSetForPrcCLP("Prc_CheckForPanchayat", htPanchayat);
                    if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                    {
                        e.Row.BackColor = Color.LightPink;
                    }

                }

                Hashtable htparam = new Hashtable();
                //Random rnd = new Random();
                // string Memcode = ViewState["UnqRefNo"].ToString();
                string Memcode;
                if (txtAgtCode.Text.Trim() == "")
                {
                    Memcode = ViewState["UnqRefNo"].ToString();
                }
                else
                {
                    Memcode = txtAgtCode.Text.Trim();
                }

                htparam.Add("@MemCode", Memcode.ToString().Trim());//; "21018407"
                htparam.Add("@MemType", ddlAgntType.SelectedValue.ToString().Trim());//heircyse  added by usha for doc bind
                htparam.Add("@ModuleCode", "Spon");
                htparam.Add("@TypeofDoc", "UPLD");
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "NR");
                htparam.Add("@doccode", lbldoccode.Text);
                htparam.Add("@EntityType", ddlLicTyp.SelectedValue.ToString().Trim());// added by sanoj 03062022
                DataSet dsUpldImg = new DataSet();
                dsUpldImg = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMEMUpldDocCode", htparam);
                //ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUpldDocNames", htparam);
                if (dsUpldImg.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsUpldImg.Tables[0].Rows.Count; i++)
                    {
                        if (lbldoccode.Text == dsUpldImg.Tables[0].Rows[i]["DocCode"].ToString().Trim())
                        {
                            btn_Upload.Enabled = true;
                            btn_ReUpload.Enabled = false;
                            btn_Upload.Visible = true;
                            btn_ReUpload.Visible = false;
                            lnkPreview.Visible = false;
                        }
                    }
                }
            }
        }
        protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName == "Preview")
                //{
                //    string Preview = e.CommandArgument.ToString().Trim();
                //    string Memcode = Request.QueryString["Memcode"].ToString().Trim();
                //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                //    Label lbldocName = (Label)row.FindControl("lbldocName");
                //    string strWindow = "window.open('FrmAgentDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&Memcode=" + Memcode.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                //}
                if (e.CommandName == "Preview")
                {
                    string Preview = e.CommandArgument.ToString().Trim();
                    string Memcode = txtAgtCode.Text; //Request.QueryString["MemCode"].ToString().Trim();
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lbldocName = (Label)row.FindControl("lbldocName");
                    string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&Memcode=" + Memcode.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", strWindow, true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&CndNo=" + CndNo.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview');", true);
                }

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


        protected void dgView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
            //    //For Pagination of Search Grid
            //    DataTable dt = GetDataTableForUplds();
            //    DataView dv = new DataView(dt);
            //    GridView dgSource = (GridView)sender;
            //    dgSource.PageIndex = e.NewPageIndex;
            //    dv.Sort = dgSource.Attributes["SortExpression"];
            //    if (dgSource.Attributes["SortASC"] == "No")
            //    {
            //        dv.Sort += " DESC";
            //    }
            //    dgSource.DataSource = dv;
            //    dgSource.DataBind();
            //    //ShowPageInformation();
            //}
            //catch (Exception ex)
            //{

            //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //    string sRet = oInfo.Name;
            //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //    String LogClassName = method.ReflectedType.Name;
            //    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            //}
        }
        //start Added by sanoj

        protected void btnNextPannel1_Click(object sender, EventArgs e)
        {
            divPannel1.Visible = false;
            divPannel1.Visible = false;
            divpn1.Visible = false;
            divpn2.Visible = false;
            divpn3.Visible = false;
            divpn4.Visible = false;
            divpn5.Visible = false;
            btnNextPannel1.Visible = false;
            divPannel2.Visible = true;
            ImgBasicInfo.Visible = false;
            ImgBusiness.Visible = true;
            if (Request.QueryString["Type"].ToString() == "E")
            {
                GetDataMemBckgrndExp();
            }
            txtExpt1.Focus();
        }

        protected void btnPervPnnel2_Click(object sender, EventArgs e)
        {
            txtPanNo.Enabled = false; //added by sanoj 16052023
            //divPannel2.Visible = false;
            ////1st tab start
            //divPannel1.Visible = true;
            //divpn1.Visible = true;
            //divpn2.Visible = true;
            //divpn3.Visible = true;
            //divpn4.Visible = true;
            //divpn5.Visible = true;
            //btnNextPannel1.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideProfiling();", true);
            divPannel1.Visible = true;
            divPannel2.Visible = false;
            ImgBusiness.Visible = false;
            ImgBasicInfo.Visible = true;
            //1st tab start
            divPannel1.Visible = true;
            divpn1.Visible = true;
            divpn2.Visible = true;
            divpn3.Visible = true;
            divpn4.Visible = true;
            divpn5.Visible = true;
            btnNextPannel1.Visible = true;
			cboagnTitle.Focus();
             ImgBasicInfo.Attributes.Add("style", "display:block");//added by sanoj 18052023

		}

        protected void btnNextPnnel2_Click(object sender, EventArgs e)
        {
            if (gvComposite.Rows == null || gvComposite.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Add Background/Experience')", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Divhide();", true);
                txtExpernc.Focus();
                return;
            }
            //divPannel3.Visible = true;
            //divPannel2.Visible = false;
            ////ImgBusiness.Attributes.Add("style", "display:none");
            ////ImgHierarchy.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showSalHie();", true);


            divPannel3.Visible = true;
            divPannel2.Visible = false;
            ImgBusiness.Visible = false;
            ImgHierarchy.Visible = true;
        }

        protected void bntBack_Click(object sender, EventArgs e)
        {
            //divPannel2.Visible = true;
            //divPannel3.Visible = false;
            //btnBackExp.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideSalHie();", true);
            divPannel2.Visible = true;
            divPannel3.Visible = false;
            btnBackExp.Visible = true;
            ImgBusiness.Visible = true;
            ImgHierarchy.Visible = false;
			txtExpt1.Focus();

		}
        //protected void btnNextPannel3_Click(object sender, EventArgs e)
        //{
        //    //if (gvUntLst.Rows == null || gvUntLst.Rows.Count == 0)
        //    //{
        //    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select  Unit Code')", true);
        //    //    txtUntCode.Focus();
        //    //    return;
        //    //}
        //    ////if (gv.Rows == null || gv.Rows.Count == 0)
        //    ////{
        //    ////    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Reporting Manager')", true);
        //    ////    txtRptMgr.Focus();
        //    ////    return;
        //    ////}
        //    //divPannel5.Visible = true;
        //    //divPannel3.Visible = false;
        //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showBnkNme();", true);

        //    divPannel5.Visible = true;
        //    divPannel3.Visible = false;

        //    ImgBank.Visible = true;
        //    ImgHierarchy.Visible = false;
        //}

        protected void btnNextPannel3_Click(object sender, EventArgs e)
        {
            if (gvUntLst.Rows == null || gvUntLst.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select  Unit Code')", true);
                txtUntCode.Focus();
                return;
            }

            if (ddllvlagttype.SelectedItem.ToString().Trim() != "Independent")
            {

                if (gv.Rows == null || gv.Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Parental Reporting Manager')", true);
                    txtRptMgr.Focus();
                    return;
                }
            }
            for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
            {
                GridView gvAddlMgr = gv_RptMngr.Rows[i].FindControl("gvAddlMgr") as GridView;
                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp");

                if (ddlAdlAgtTyp.SelectedItem.ToString().Trim() != "Independent")
                {

                    if (gvAddlMgr.Rows == null || gvAddlMgr.Rows.Count == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Please Select Additional Reporting Manager')", true);
                        txtRptMgr.Focus();
                        return;
                    }
                }
            }
            Image8.Attributes.Add("style", "border-width:0px;");
            divPannel5.Visible = true;
            divPannel3.Visible = false;
            ImgBank.Visible = true;
            ImgHierarchy.Visible = false;
            txtNomNme.Enabled = false;
            txtNomDob.Enabled = false;
            txtNomMob.Enabled = false;
            txtNomEmail.Enabled = false;
            ddlNomnRel.Enabled = false;
            EnabledNominee();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "Divhide2();", true);
        }

        protected void EnabledNominee()
        {
            txtBankHolderName.Enabled = true;
            ddlactype.Enabled = true;
            txtBankAccNo.Enabled = true;
            txtBankName.Enabled = true;
            txtNeftCode.Enabled = true;
            txtBnkAddress.Enabled = true;
            txtmcrcode.Enabled = true;
            btnPrevPannel5.Visible = true;
            btnNextPannel5.Visible = true;
            divNominee.Visible = true;
        }

        protected void btnBackPannel4_Click(object sender, EventArgs e)
        {
            //divPannel5.Visible = true;
            //divPannel4.Visible = false;
            //btnNextPannel1.Visible = true;
            //btnPervPnnel2.Visible = true;
            //btnNextPnnel2.Visible = true;
            //bntBack.Visible = true;
            //btnNextPannel3.Visible = true;
            //btnPrevPannel5.Visible = true;
            //btnNextPannel5.Visible = true;
            //btnNextPannel1.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideDocupld();", true);
            divPannel5.Visible = true;
            divPannel4.Visible = false;

            btnNextPannel1.Visible = false;
            btnPervPnnel2.Visible = true;
            btnNextPnnel2.Visible = true;
            bntBack.Visible = true;
            btnNextPannel3.Visible = true;
            btnPrevPannel5.Visible = true;
            btnNextPannel5.Visible = true;
            //for image

            ImgBank.Visible = true;
            ImgDocumentUpload.Visible = false;
			txtBankHolderName.Focus();
           


        }

        protected void btnPrevPannel5_Click(object sender, EventArgs e)
        {
            //divPannel5.Visible = false;
            //divPannel3.Visible = true;
            ////ImgBank.Visible = false;
            ////ImgHierarchy.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideBnkNme();", true);
            divPannel5.Visible = false;
            divPannel3.Visible = true;

            ImgBank.Visible = false;
            ImgHierarchy.Visible = true;
			ddlAgntType.Focus();

		}

        protected void btnNextPannel5_Click(object sender, EventArgs e)
        {
            //divPannel5.Visible = false;
            //divPannel4.Visible = true;
            //btnPreviewBack.Visible = false;
            //BtnPreView.Visible = true;
            //btnUpdate.Visible = false;
            //btnCncl.Visible = false;
            //Bindgridview();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showDocupld();", true);

            divPannel5.Visible = false;
            divPannel4.Visible = true;
            btnPreviewBack.Visible = false;// previvisback button
            BtnPreView.Visible = true;
            btnUpdate.Visible = false;
            btnCncl.Visible = false;
            //btnUpdate.Visible = false;
            ImgBank.Visible = false;
	 //added by sanoj 19052023
          if(Request.QueryString["Type"].ToString() == "E")
           {
                chkgst.Enabled = true;
                chkagree.Enabled = true;
                btngst.Enabled = true;
                btnView.Enabled = true;
           }
            
            //Endded by sanoj 19052023
            ImgDocumentUpload.Visible = true;
            Bindgridview();
        }
        protected void BtnPreView_Click(object sender, EventArgs e)
        {
            ////1st tab start
             DisabledContrl();
            divPannel1.Visible = true;
            divpn1.Visible = true;
            divpn2.Visible = true;
            divpn3.Visible = true;
            divpn4.Visible = true;
            divpn5.Visible = true;
            btnNextPannel1.Visible = true;
            btnPreviewBack.Visible = true;// previvisback button
            divPannel1.Visible = true;
            divPannel2.Visible = true;
            divPannel3.Visible = true;
            divPannel4.Visible = true;
            divPannel5.Visible = true;
            btnNextPannel1.Visible = false;
            btnPervPnnel2.Visible = false;
            btnNextPnnel2.Visible = false;
            bntBack.Visible = false;
            btnNextPannel3.Visible = false;
            btnPrevPannel5.Visible = false;
            btnNextPannel5.Visible = false;
            btnBackPannel4.Visible = true;
            BtnPreView.Visible = false;
            btnUpdate.Visible = true;
            btnBackPannel4.Visible = false;
            btnAddrAdd.Visible = false;
            btnBackExp.Visible = false;
            //image
            ImgSummary.Visible = true;
            ImgDocumentUpload.Visible = false;
        }
        //protected void BtnPreView_Click(object sender, EventArgs e)
        //{
        //    btnPreviewBack.Visible = true;
        //    divPannel1.Visible = true;
        //    divpn1.Visible = true;
        //    divpn2.Visible = true;
        //    divpn3.Visible = true;
        //    divpn4.Visible = true;
        //    divpn5.Visible = true;
        //    btnNextPannel1.Visible = true;
        //    //  Updatepanel9.Visible = true;
        //    divPannel2.Visible = true;
        //    divPannel3.Visible //}= true;
        //    divPannel4.Visible = true;
        //    divPannel5.Visible = true;
        //    btnNextPannel1.Visible = false;
        //    btnPervPnnel2.Visible = false;
        //    btnNextPnnel2.Visible = false;
        //    bntBack.Visible = false;
        //    btnNextPannel3.Visible = false;
        //    btnPrevPannel5.Visible = false;
        //    btnNextPannel5.Visible = false;
        //    btnBackPannel4.Visible = true;
        //    BtnPreView.Visible = false;
        //    btnUpdate.Visible = true;
        //    btnBackPannel4.Visible = false;
        //    btnAddrAdd.Visible = false;
        //    btnBackExp.Visible = false;
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "showSummary();", true);


        protected void btnPreviewBack_Click(object sender, EventArgs e)
        {
            ////1st tab start
            //divPannel1.Visible = false;
            //divpn1.Visible = false;
            //divpn2.Visible = false;
            //divpn3.Visible = false;
            //divpn4.Visible = false;
            //divpn5.Visible = false;
            //btnNextPannel1.Visible = false;
            //// Updatepanel9.Visible = false;
            ////1st tab end
            //btnPreviewBack.Visible = false;
            //divPannel4.Visible = true;
            //btnBackPannel4.Visible = true;
            //divPannel3.Visible = false;
            //divPannel2.Visible = false;
            //divPannel4.Visible = true;
            //divPannel5.Visible = false;
            //btnBackPannel4.Visible = true;
            //btnUpdate.Visible = false;
            //BtnPreView.Visible = true;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideSummary();", true);
            //1st tab start
            divPannel1.Visible = false;
            divpn1.Visible = false;
            divpn2.Visible = false;
            divpn3.Visible = false;
            divpn4.Visible = false;
            divpn5.Visible = false;
            btnNextPannel1.Visible = false;
            //1st tab end
            btnPreviewBack.Visible = false;// previvisback button
            divPannel4.Visible = true;
            btnBackPannel4.Visible = true;
            divPannel1.Visible = false;
            divPannel2.Visible = false;
            divPannel3.Visible = false;
            divPannel4.Visible = true;
            divPannel5.Visible = false;
            btnBackPannel4.Visible = true;
            btnUpdate.Visible = false;
            BtnPreView.Visible = true;
            //image
            ImgSummary.Visible = false;
            ImgDocumentUpload.Visible = true;
        }



        protected void cboMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMaritalStatus.SelectedValue.ToString() == "M")
                {
                    Td7.Visible = true;
                    Td6.Visible = true;
                   // TxtAnnivrsryDt.Text = "";//Comented by usha on 20_04_2023
                    divAnnivrsryDt.Visible = true;
                    TxtAnnivrsryDt.Attributes.Add("style", "background-color:white !important;");
                }
                else
                {
                    TxtAnnivrsryDt.Text = "";
                    divAnnivrsryDt.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "showBasicInfo();", true);
            }
            catch (Exception ex)
            {

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            }
        }
        DataTable dt_composite = new DataTable();
        protected void btnBackExp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpernc.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exprience is Mandatory')", true);
                    txtExpernc.Focus();
                    return;

                }
                if (txtOrdInc1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Sector')", true);
                    txtOrdInc1.Focus();
                    return;
                }

                if (txtOrdInc1.SelectedValue == "10")
                {
                    if (txtotherSec.Text == "")
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Other Sector')", true);
                        txtotherSec.Focus();
                        return;
                    }
                }
                dt_composite.Columns.Add("Experience");
                dt_composite.Columns.Add("ExpTime");
                dt_composite.Columns.Add("Organization");
                dt_composite.Columns.Add("OtherSector");
                dt_composite.Columns.Add("OthSectDesc");
                DataRow dr;
                foreach (GridViewRow row in gvComposite.Rows)
                {
                    dr = dt_composite.NewRow();
                    Label lblExperience = (Label)row.FindControl("lblExperience");
                    Label lblExpTime = (Label)row.FindControl("lblExpTime");
                    Label lblOrganization = (Label)row.FindControl("lblOrganization");
                    Label lblotherssectors = (Label)row.FindControl("lblotherssectors");
                    Label lblOthSectDesc = (Label)row.FindControl("lblOthSectDesc");
                    dr[0] = lblExperience.Text;
                    dr[1] = lblExpTime.Text;
                    dr[2] = lblOrganization.Text;
                    dr[3] = lblotherssectors.Text;
                    dr[4] = lblOthSectDesc.Text;
                    dt_composite.Rows.Add(dr);
                }
                if (gvComposite.Rows.Count <= 10)
                {
                    dr = dt_composite.NewRow();
                    dr["Experience"] = txtExpernc.Text;
                    dr["ExpTime"] = ddlBackgrndYear.SelectedValue.ToString();
                    dr["Organization"] = txtOrdInc1.SelectedValue;
                    dr["OtherSector"] = txtotherSec.Text;
                    dr["OthSectDesc"] = txtOrdInc1.SelectedItem.Text.ToString();
                    dt_composite.Rows.Add(dr);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);
                }
                gvComposite.DataSource = dt_composite;
                gvComposite.DataBind();
                Session["datatable"] = dt_composite;
                txtExpernc.Text = "";
                txtotherSec.Text = "";
                ddlBackgrndYear.SelectedIndex = 0;
                txtOrdInc1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            }

        }

        protected void gvComposite_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt_composite = (DataTable)Session["datatable"];
            if (dt_composite.Rows.Count >= 0)
            {

                dt_composite.Rows.RemoveAt(Convert.ToInt16(e.RowIndex));

                gvComposite.DataSource = dt_composite;
                gvComposite.DataBind();


            }


        }

        public void GetDataMemBckgrndExp()
        {

            Hashtable htparam = new Hashtable();
            ds_documentName.Clear();
            htparam.Add("@MemCode", Request.QueryString["AgnCd"].ToString());
            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_MemBckgrndExp", htparam); //added by pranjali on 19-05-2014

            gvComposite.DataSource = ds_documentName;
            gvComposite.DataBind();
            DataTable dt = ds_documentName.Tables[0];
            Session["datatable"] = dt;
        }


        protected void btnAddrAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPermAdd1.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Address')", true);
                    txtPermAdd1.Focus();
                    return;

                }
                if (ddlState1.SelectedIndex == 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select State')", true);
                    ddlState1.Focus();
                    return;
                }
                if (txtDistric.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter District')", true);
                    txtDistric.Focus();
                    return;

                }
                if (txtarea1.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Area')", true);
                    txtarea1.Focus();
                    return;
                }
                if (txtPermPostcode.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pin Code')", true);
                    txtPermPostcode.Focus();
                    return;
                }
                if (txtcity1.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter City')", true);
                    txtcity1.Focus();
                    return;
                }
                dt_composite.Columns.Add("AddressType");
                dt_composite.Columns.Add("Address");
                dt_composite.Columns.Add("State");
                dt_composite.Columns.Add("District");
                dt_composite.Columns.Add("Area");
                dt_composite.Columns.Add("Village");
                dt_composite.Columns.Add("city");
                dt_composite.Columns.Add("PinCode");

                DataRow dr;
                foreach (GridViewRow row in GridViewAddress.Rows)
                {
                    dr = dt_composite.NewRow();
                    Label lblAddressType = (Label)row.FindControl("lblAddressType");
                    Label lblAddress = (Label)row.FindControl("lblAddress");
                    Label lblState = (Label)row.FindControl("lblState");
                    Label lblDistrict = (Label)row.FindControl("lblDistrict");
                    Label lblArea = (Label)row.FindControl("lblArea");
                    Label lblVillage = (Label)row.FindControl("lblVillage");
                    Label lblcity = (Label)row.FindControl("lblcity");
                    Label lblPinCode = (Label)row.FindControl("lblPinCode");
                    dr[0] = lblAddressType.Text;
                    dr[1] = lblAddress.Text;
                    dr[2] = lblState.Text;
                    dr[3] = lblDistrict.Text;
                    dr[4] = lblArea.Text;
                    dr[5] = lblVillage.Text;
                    dr[6] = lblcity.Text;
                    dr[7] = lblPinCode.Text;

                    dt_composite.Rows.Add(dr);
                }
                if (GridViewAddress.Rows.Count <= 4)
                {
                    dr = dt_composite.NewRow();
                    dr["AddressType"] = ddlCnctType.SelectedValue.ToString().Trim();
                    dr["Address"] = txtPermAdd1.Text + txtPermAdd2.Text + txtPermAdd3.Text;
                    dr["State"] = ddlState1.SelectedValue.ToString().Trim();
                    dr["District"] = txtDistric.Text;
                    dr["Area"] = txtarea1.Text;
                    dr["Village"] = txtPermVillage.Text;
                    dr["city"] = txtcity1.Text;
                    dr["PinCode"] = txtPermPostcode.Text;
                    dt_composite.Rows.Add(dr);
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);

                }
                // hdnCount.Value = dt_composite.Rows.Count.ToString();
                GridViewAddress.DataSource = dt_composite;
                GridViewAddress.DataBind();
                Session["datatable"] = dt_composite;
                ddlCnctType.SelectedIndex = 0;
                txtPermAdd1.Text = "";
                txtPermAdd2.Text = "";
                txtPermAdd3.Text = "";
                ddlState1.SelectedIndex = 0;
                txtDistric.Text = "";
                txtarea1.Text = "";
                txtPermVillage.Text = "";
                txtcity1.Text = "";
                txtPermPostcode.Text = "";

            }

            catch (Exception ex)
            {

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            }

        }


        protected void GridViewAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt_composite = (DataTable)Session["datatable"];
            if (dt_composite.Rows.Count >= 0)
            {

                dt_composite.Rows.RemoveAt(Convert.ToInt16(e.RowIndex));

                GridViewAddress.DataSource = dt_composite;
                GridViewAddress.DataBind();


            }

        }


        private void Bindgridview()
        {

            try
            {
                Hashtable htparam = new Hashtable();
                string Memcode;
                if (txtAgtCode.Text.Trim() == "")
                {
                    Memcode = ViewState["UnqRefNo"].ToString();
                }
                else
                {
                    Memcode = txtAgtCode.Text.Trim();
                }

                //string Memcode = ViewState["UnqRefNo"].ToString();
                htparam.Add("@MemCode", Memcode.ToString().Trim());
                htparam.Add("@MemType", ddlAgntType.SelectedValue.ToString().Trim());//heircyse  added by usha for doc bind
                htparam.Add("@ModuleCode", "Spon");
                htparam.Add("@TypeofDoc", "UPLD");
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "NR");
                htparam.Add("@EntityType", ddlLicTyp.SelectedValue);
                ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", htparam); //added by pranjali on 19-05-2014
                if (ds_documentName.Tables.Count > 0)
                {
                    if (ds_documentName.Tables[0].Rows.Count > 0)
                    {
                        dgView.DataSource = ds_documentName.Tables[0];
                        dgView.DataBind();
                    }
                    else
                    {
                        dgView.DataSource = null;
                        dgView.DataBind();

                    }
                }
                else
                {
                    dgView.DataSource = null;
                    dgView.DataBind();

                }
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
        public void AddAddress()
        {

            for (int i = 0; GridViewAddress.Rows.Count > i; i++)
            {
                Label lblAddressType = GridViewAddress.Rows[i].FindControl("lblAddressType") as Label;
                Label lblAddress = GridViewAddress.Rows[i].FindControl("lblAddress") as Label;
                Label lblState = GridViewAddress.Rows[i].FindControl("lblState") as Label;
                Label lblDistrict = GridViewAddress.Rows[i].FindControl("lblDistrict") as Label;
                Label lblArea = GridViewAddress.Rows[i].FindControl("lblArea") as Label;
                Label lblVillage = GridViewAddress.Rows[i].FindControl("lblVillage") as Label;
                Label lblcity = GridViewAddress.Rows[i].FindControl("lblcity") as Label;
                Label lblPinCode = GridViewAddress.Rows[i].FindControl("lblPinCode") as Label;
                string[] Address_list = lblAddress.Text.Split(',');

                Hashtable htcnct = new Hashtable();
                htcnct.Clear();
                htcnct.Add("@GCN", txtCusmId.Text.Trim());
                htcnct.Add("@CnctType", "P1");
                htcnct.Add("@Adr1", Address_list[0].ToString().Trim());
                htcnct.Add("@Adr2", Address_list[1].ToString().Trim());
                htcnct.Add("@Adr3", Address_list[2].ToString().Trim());
                htcnct.Add("@PostCode", lblPinCode.Text.Trim());
                htcnct.Add("@StateCode", lblState.Text);
                htcnct.Add("@Area", lblArea.Text);
                htcnct.Add("@City", lblcity.Text);
                htcnct.Add("@Village", lblVillage.Text.Trim());
                htcnct.Add("@District", lblDistrict.Text.Trim());
                htcnct.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                if (Request.QueryString["Type"] != null)
                {
                    if (Request.QueryString["Type"].ToString() == "Clt")
                    {
                        htcnct.Add("@flagclt", "MapClt");
                    }
                    else
                    {
                        htcnct.Add("@flagclt", "NewClt");
                    }
                }
                dataAccess.exec_comm_command("Prc_AgyAdmin_InsCltCnctDtls", htcnct);
            }


        }

        public void PopualtEducation()
        {

            oCommon.getDropDown(ddlEducutn, "BASICD", 1, "", 1);
            ddlEducutn.Items.Insert(0, "--Select--");
            //dseducationproof.SelectCommand = "Prc_GetEducationProof '" + ddlBasicQual.SelectedValue.ToString().Trim().ToUpper() + "'";
            //ddlEducutn.SelectCommand = "Prc_GetEducationProof '" + "" + "'";
            ////Added By Asrar on 27-06-2013 for converting Inline query into procedure To Fill Education Proof in Dropdown End
            //ddlEducutn.DataBind();
            //ddleducationproof.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void ConvertRDLCToPDF(String Memcode)
        {

            string strAppoint = string.Empty;
            strAppoint = "WelcomeLetter";
            string strFileRePath = string.Empty;
            if (Directory.Exists(strPath) == false)
            {
                strPath = strPath + Memcode + "\\";
                Directory.CreateDirectory(strPath);
            }
            else
            {
                strFileRePath = strPath + Memcode + "\\";
                if (!Directory.Exists(strFileRePath))
                {
                    Directory.CreateDirectory(strFileRePath);
                }
                else
                {
                    strFileRePath = strPath + Memcode + "\\";
                }
            }
            Hashtable htCRP = new Hashtable();
            htCRP.Add("@MemCode", Memcode);
            DataSet dsCRP = new DataSet();
            if (strAppoint == "WelcomeLetter")
            {
                dsCRP = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetFPWelcomeLetter", htCRP);
                ReportDataSource rdsAct = new ReportDataSource("FPWelcomeLetter", dsCRP.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = strRpt + "FPWelcomeLetter.rdlc"; //This is your rdlc name.
                                                                                 // viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                using (FileStream fs = new FileStream(strFileRePath + "FPWelcomeLetter.pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                Hashtable htApp = new Hashtable();
                DataSet dsApp = new DataSet();
                htApp.Add("@MemCode", Memcode);
                htApp.Add("@UserFilename", strFileRePath);
                htApp.Add("@ServerFilename", "FPWelcomeLetter.pdf");
                htApp.Add("@PDFByte", bytes);
                htApp.Add("@CreateBy", Session["UserID"].ToString().Trim());

                dsApp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsFPConRDLCToPDF", htApp);
            }
        }

        protected void PopulateRecruiterCode()
        {
            try
            {
                DataSet DsRecruit = new DataSet();
                Hashtable Ht = new Hashtable();
                Ht.Add("@EmpCode", Convert.ToString(Session["UserId"].ToString()));
                DsRecruit = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRecruiterDtls", Ht);
                if (DsRecruit.Tables.Count > 0)
                {
                    if (DsRecruit.Tables[0].Rows.Count > 0)
                    {
                        ViewState["RecruitMemCode"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["MemCode"]).Trim();//usa
                        Session["RecruitMemCode"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["MemCode"]).Trim();//usa on 29.01.2022 for unit code asper recruiter.
                        ViewState["RecruitEmpCode"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["EmpCode"]).Trim();
                        ViewState["RecruitEmpName"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["LegalName"]).Trim();
                        ViewState["RecruitChnl"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["BizSrc"]).Trim();
                        ViewState["RecruitunitCode"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["UnitCode"]).Trim();
                        ViewState["RecruitSubchnl"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["ChnCls"]).Trim();
                        ViewState["RecruitType"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["MemType"]).Trim();
                        ViewState["ChannelType"] = Convert.ToString(DsRecruit.Tables[0].Rows[0]["ChannelType"]).Trim();
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
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }

        }

        public void PreviewData()
        {
            divPannel1.Attributes.Add("style", "display:block");
            divPannel2.Visible = true;
            divPannel3.Visible = true;
            divPannel4.Visible = true;
            divPannel5.Visible = true;
            btnNextPannel1.Visible = false;
            btnPervPnnel2.Visible = false;
            btnNextPnnel2.Visible = false;
            bntBack.Visible = false;
            btnNextPannel3.Visible = false;
            btnPrevPannel5.Visible = false;
            btnNextPannel5.Visible = false;
            btnBackPannel4.Visible = true;
            BtnPreView.Visible = false;
            btnUpdate.Visible = true;
            btnBackPannel4.Visible = false;
            btnAddrAdd.Visible = false;
            //btnBackExp.Visible = false;
        }

        public void DisabledContrl()
        {
            btnBackExp.Visible = false;
            lblNote.Attributes.Add("style", "display:none");
            ImgBasicInfo.Attributes.Add("style", "display:none");
            ddlAgntType.Enabled = false;
            rdbChnlTyp.Enabled = false;
            //btnUpdate.Attributes.Add("style", "display:none");
            //btnPreviewBack.Attributes.Add("style", "display:none");
            btnRptMgr.Attributes.Add("style", "display:none");
            Image9.Attributes.Add("style", "display:none");
            btnUnitCode.Attributes.Add("style", "display:none");
            lnkUploadPhoto.Attributes.Add("style", "display:none");
            Img.Attributes.Add("style", "display:none");
            //Image7.Attributes.Add("style", "display:none");
            Image8.Attributes.Add("style", "display:none");
            ddlBackgrndYear.Attributes.Add("style", "display:none");
            Image10.Attributes.Add("style", "display:none");
            Image11.Attributes.Add("style", "display:none");
            btnStateSrch1.Attributes.Add("style", "display:none");
            btnPermCountry.Attributes.Add("style", "display:none");
            btnVerifyPAN.Attributes.Add("style", "display:none");
            ddlSlsChannel.Enabled = false;
            txtPosp6.Enabled = false;
            txtDtlsExtBus.Enabled = false;
            ddlChnCls.Enabled = false;
            ddlNomnRel.Enabled = false;
            txtNomEmail.Enabled = false;
            txtNomDob.Enabled = false;
            txtNomNme.Enabled = false;
            ddlactype.Enabled = false;
            txtmcrcode.Enabled = false;
            txtBnkAddress.Enabled = false;
            txtAgntMonth.Enabled = false;
            txtExpectTm.Enabled = false;
            txtExpt.Enabled = false;
            txtSrcProvd.Enabled = false;
            txtRemark.Enabled = false;
            txtAgntMonth12.Enabled = false;
            txtPosp12.Enabled = false;
            txtmrktBus.Enabled = false;
            txtAsnmnet.Enabled = false;
            txtExpernc.Enabled = false;
            ddlBackgrndYear.Enabled = false;
            txtTenurFrom.Enabled = false;
            txtOrdInc.Enabled = false;
            txttenur2.Enabled = false;
            txtPermCountryDesc.Enabled = false;
            txtPermCountryCode.Enabled = false;
            txtPermPostcode.Enabled = false;
            txtarea1.Enabled = false;
            txtDistric.Enabled = false;
            ddlState1.Enabled = false;
            txtcity1.Enabled = false;
            txtPermVillage.Enabled = false;
            txtPermAdd3.Enabled = false;
            txtPermAdd2.Enabled = false;
            txtPermAdd1.Enabled = false;
            txtTwt.Enabled = false;
            txtFax.Enabled = false;
            txtEmail2.Enabled = false;
            txtWorkTel.Enabled = false;
            txtMobileTel.Enabled = false;
            txtInstId.Enabled = false;
            txtFbId.Enabled = false;
            txtEmail.Enabled = false;
            ddlCnctType.Enabled = false;
            txtHomeTel.Enabled = false;
            ddlEducutn.Enabled = false;
            txtAgntName.Enabled = false;
            cboagnTitle.Enabled = false;
            txtDOB.Enabled = false;
            cboMaritalStatus.Enabled = false;
            txtAgtCode.Enabled = false;
            txtCusmId.Enabled = false;
            txtCltCode.Enabled = false;
            ddlGender.Enabled = false;
            txtPanNo.Enabled = false;
            txtNeftCode.Enabled = false;
            txtBankName.Enabled = false;
            txtBnkBrnchName.Enabled = false;
            txtNomMob.Enabled = false;
            txtMobileTel2.Enabled = false;
            ddlLicTyp.Enabled = false;
            txtRptMgr.Enabled = false;
            txtAddrP1.Enabled = false;
            txtAddrP2.Enabled = false;
            txtAddrP3.Enabled = false;
            txtVillage.Enabled = false;
            txtcity.Enabled = false;
            ddlState.Enabled = false;
            txtDistP.Enabled = false;
            txtarea.Enabled = false;
            txtPinP.Enabled = false;
            txtCountryCodeP.Enabled = false;
            txtCountryDescP.Enabled = false;
            txtAddrB1.Enabled = false;
            txtAddrB2.Enabled = false;
            txtAddrB3.Enabled = false;
            txtBvillage.Enabled = false;
            txtcity0.Enabled = false;
            txtCountryCodeB.Enabled = false;
            ddlState0.Enabled = false;
            txtDistB.Enabled = false;
            txtarea0.Enabled = false;
            txtPinB.Enabled = false;
            txtCountryCodeB.Enabled = false;
            ddllvlagttype.Enabled = false;
            ddlAgntStatus.Enabled = false;
            btnStateSrch0.Attributes.Add("style", "display:none");
            btnCountryB.Attributes.Add("style", "display:none");
            btnStateSrch.Attributes.Add("style", "display:none");
            btnCountryP.Attributes.Add("style", "display:none");
            TxtAnnivrsryDt.Enabled = false;//added by usha on 20_04_2023
            txtExpt1.Enabled = false;//added by usha on 20_04_2023
			ChkPARes.Enabled = false;
			txtOrdInc1.Enabled = false;
			txtBankHolderName.Enabled = false;
			txtBankAccNo.Enabled = false;
			Chknominee.Enabled = false;
		}
        public void getWiz()
        {
            DataSet ds = new DataSet();
            ds = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_Get_iconfigsu");
            string Value = ds.Tables[0].Rows[0]["Value"].ToString().Trim();
            if (Value == "SP")
            {
                BtnPreView_Click(null, null);
                EnabledContrl();
            }
        }
        public void EnabledContrl()
        {
            ChkPARes.Visible = false;
            ChkPARes.Enabled = false;
            ddlAgntType.Enabled = true;
            rdbChnlTyp.Enabled = true;
            btnUpdate.Attributes.Add("style", "display:block");
            btnRptMgr.Attributes.Add("style", "display:block");
            Image9.Attributes.Add("style", "display:block");
            btnUnitCode.Attributes.Add("style", "display:block");
            lnkUploadPhoto.Attributes.Add("style", "display:block");
            Img.Attributes.Add("style", "display:block");
            //Image7.Attributes.Add("style", "display:block");
            Image8.Attributes.Add("style", "display:block");
            ddlBackgrndYear.Attributes.Add("style", "display:block");
            Image10.Attributes.Add("style", "display:block");
            Image11.Attributes.Add("style", "display:block");
            btnStateSrch1.Attributes.Add("style", "display:block");
            btnPermCountry.Attributes.Add("style", "display:block");
            btnVerifyPAN.Attributes.Add("style", "display:block");
            ddlSlsChannel.Enabled = true;
            txtPosp6.Enabled = true;
            txtDtlsExtBus.Enabled = true;
            ddlChnCls.Enabled = true;
            ddlNomnRel.Enabled = true;
            txtNomEmail.Enabled = true;
            txtNomDob.Enabled = true;
            txtNomNme.Enabled = true;
            ddlactype.Enabled = true;
            txtmcrcode.Enabled = true;
            txtBnkAddress.Enabled = true;
            txtAgntMonth.Enabled = true;
            txtExpectTm.Enabled = true;
            txtExpt.Enabled = true;
            txtSrcProvd.Enabled = true;
            txtRemark.Enabled = true;
            txtAgntMonth12.Enabled = true;
            txtPosp12.Enabled = true;
            txtmrktBus.Enabled = true;
            txtAsnmnet.Enabled = true;
            txtExpernc.Enabled = true;
            ddlBackgrndYear.Enabled = true;
            txtTenurFrom.Enabled = true;
            txtOrdInc.Enabled = true;
            txttenur2.Enabled = true;
            txtPermCountryDesc.Enabled = true;
            txtPermCountryCode.Enabled = true;
            txtPermPostcode.Enabled = true;
            txtarea1.Enabled = true;
            txtDistric.Enabled = true;
            ddlState1.Enabled = true;
            txtcity1.Enabled = true;
            txtPermVillage.Enabled = true;
            txtPermAdd3.Enabled = true;
            txtPermAdd2.Enabled = true;
            txtPermAdd1.Enabled = true;
            txtTwt.Enabled = true;
            txtFax.Enabled = true;
            txtEmail2.Enabled = true;
            txtWorkTel.Enabled = true;
            txtMobileTel.Enabled = true;
            txtInstId.Enabled = true;
            txtFbId.Enabled = true;
            txtEmail.Enabled = true;
            ddlCnctType.Enabled = true;
            txtHomeTel.Enabled = true;
            ddlEducutn.Enabled = true;
            txtAgntName.Enabled = true;
            cboagnTitle.Enabled = true;
            txtDOB.Enabled = true;
            cboMaritalStatus.Enabled = true;
            txtAgtCode.Enabled = true;
            txtCusmId.Enabled = true;
            txtCltCode.Enabled = true;
            ddlGender.Enabled = true;
            txtPanNo.Enabled = true;
            txtNeftCode.Enabled = true;
            txtBankName.Enabled = true;
            txtBnkBrnchName.Enabled = true;
            txtNomMob.Enabled = true;
            txtMobileTel2.Enabled = true;
            ddlLicTyp.Enabled = true;
            txtRptMgr.Enabled = true;
            txtAddrP1.Enabled = true;
            txtAddrP2.Enabled = true;
            txtAddrP3.Enabled = true;
            txtVillage.Enabled = true;
            txtcity.Enabled = true;
            ddlState.Enabled = true;
            txtDistP.Enabled = true;
            txtarea.Enabled = true;
            txtPinP.Enabled = true;
            txtCountryCodeP.Enabled = true;
            txtCountryDescP.Enabled = true;
            txtAddrB1.Enabled = true;
            txtAddrB2.Enabled = true;
            txtAddrB3.Enabled = true;
            txtBvillage.Enabled = true;
            txtcity0.Enabled = true;
            txtCountryCodeB.Enabled = true;
            ddlState0.Enabled = true;
            txtDistB.Enabled = true;
            txtarea0.Enabled = true;
            txtPinB.Enabled = true;
            txtCountryCodeB.Enabled = true;
            ddllvlagttype.Enabled = true;
            btnStateSrch0.Attributes.Add("style", "display:block");
            btnCountryB.Attributes.Add("style", "display:block");
            btnStateSrch.Attributes.Add("style", "display:block");
            btnCountryP.Attributes.Add("style", "display:block");
			ChkPARes.Enabled = true;
			txtOrdInc1.Enabled = true;
			txtBankHolderName.Enabled = true;
			txtBankAccNo.Enabled = true;
			Chknominee.Enabled = true;
		}
        protected void btnCncl_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "window.close()", true);
        }
        public void Sector()
        {
            oCommon.getDropDown(txtOrdInc1, "Sector", 1, "", 1);
            txtOrdInc1.Items.Insert(0, "--Select--");
        }
        public void ExpectedmonthlyBusiness()
        {
            oCommon.getDropDown(txtExpt1, "ExpMonthBasis", 1, "", 1);
            txtExpt1.Items.Insert(0, "--Select--");
        }

        public void AutopopulatHierarchyDtls()
        {
            string RecruitType = ViewState["RecruitType"].ToString().Trim();    // added by Rajkapoor on 19-01-2022
            string ChannelType = ViewState["ChannelType"].ToString().Trim();
            if (ChannelType == "C")
            {
                rdbChnlTyp.SelectedValue = "1";
                rdbChnlTyp.Enabled = false;
                ddlSlsChannel.Enabled = true;
                oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "1");
                //ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlSlsChannel.SelectedValue = ViewState["RecruitChnl"].ToString();

                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.SelectedValue = ViewState["RecruitSubchnl"].ToString();
                ddlSlsChannel.Enabled = false;

                ddlAgntType.Enabled = true;
                //added by sanoj aj 20-01-2022
                if (Request.QueryString["Type"] == "CndStat")
                {
                    ddlAgntType.Enabled = false;
                }

                try
                {
                    if (ddlSlsChannel.SelectedValue == "")
                    {
                        oCommonU.GetAgentType(ddlAgntType, "ALL", "");
                    }
                    else
                    {
                        //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString());
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                            {
                                GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "E", RecruitType);
                            }
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                            {
                                GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "V", RecruitType);
                            }
                        }
                        else
                        {
                            GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "A", RecruitType);
                        }
                    }
                    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    // Comented by usha  on 11 .04.2022
                    //if (ddlChnCls.SelectedIndex == 0)
                    //{
                    //    ddlAgntType.Items.Clear();
                    //    ddlAgntType.DataSource = null;
                    //    ddlAgntType.DataBind();
                    //    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    //    tblReportingMngrDtls.Visible = false;
                    //    tblUnitCodeDetails.Visible = false;
                    //    ClrMgrText();
                    //}
                    // Comented by usha  on 21 .01.2021
                    tblReportingMngrDtls.Visible = false;
                    tblUnitCodeDetails.Visible = false;
                    ClrMgrText();
                    ddlChnCls.Focus();
                    ddlAgntType.Enabled = true;
                    if (Request.QueryString["Type"] == "CndStat")
                    {
                        ddlAgntType.Enabled = false;
                    }
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
            else
            {
                rdbChnlTyp.SelectedValue = "0";
                rdbChnlTyp.Enabled = false;
                ddlSlsChannel.Enabled = true;
                oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "0");
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.SelectedValue = ViewState["RecruitSubchnl"].ToString();
                ddlSlsChannel.Enabled = false;

                ddlAgntType.Enabled = true;
                try
                {
                    if (ddlSlsChannel.SelectedValue == "")
                    {
                        oCommonU.GetAgentType(ddlAgntType, "ALL", "");
                    }
                    else
                    {
                        if (Request.QueryString["Ctgry"] != null)
                        {
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                            {
                                GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "E", RecruitType);
                            }
                            if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                            {
                                GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "V", RecruitType);
                            }
                        }
                        else
                        {
                            GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "A", RecruitType);
                        }
                    }
                    ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                    if (ddlChnCls.SelectedIndex == 0)
                    {
                        //ddlAgntType.Items.Clear();
                        //ddlAgntType.DataSource = null;
                        //ddlAgntType.DataBind();
                        //ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                        //tblReportingMngrDtls.Visible = false;
                        //tblUnitCodeDetails.Visible = false;
                        //ClrMgrText();
                    }
                    tblReportingMngrDtls.Visible = false;
                    tblUnitCodeDetails.Visible = false;
                    ClrMgrText();
                    ddlChnCls.Focus();
                    ddlAgntType.Enabled = true;
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
        }

        #region METHOD 'GetAgentTypeforSearch' DEFINITION
        public void GetAgentTypeforSearch(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string UserID, string agtrole, string recruitType)
        {
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            string carriercode = "2";
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@carriercode", carriercode);
            htparam.Add("@BizSrc", strBizSrc);
            htparam.Add("@strChnCls", strChnCls);
            htparam.Add("@UserID", UserID);
            htparam.Add("@AgtRole", agtrole);
            htparam.Add("@recruitType", recruitType);
            dsResult = dataAccess.GetDataSetForPrc("Prc_GetUserAgentTypeSlsChnnl", htparam);
            if (dsResult.Tables.Count > 0)
            {
                FillDropDown(ddl, dsResult.Tables[0], "AgentType", "AgentTypeDesc01");

            }
            dsResult = null;
            strSql = null;
        }
        #endregion

        #region GENERIC METHOD TO FILL DROPDOWN ('SELECT' AS FIRST VALUE)
        /// <summary>
        /// Method Name: FillDropDown
        /// Created Date: 06 August 2007
        /// Created By: Saurabh Nayar
        /// Purpose: To Fill The DropDown
        /// </summary>
        /// <param name="drpList">DropDownList Object</param>
        /// <param name="dtTable">DataTable</param>
        /// <param name="strValue">DataValueField</param>
        /// <param name="strText">DataTextField</param>
        public void FillDropDownForSelect(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();

            System.Web.UI.WebControls.ListItem oItem = new System.Web.UI.WebControls.ListItem("- Select -", "-1");
            drpList.Items.Insert(0, oItem);
        }


        #endregion

        #region GENERIC METHOD TO FILL DROPDOWN ('ALL' AS FIRST VALUE)
        /// <summary>

        public void FillDropDownForAll(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();

            System.Web.UI.WebControls.ListItem oItem = new System.Web.UI.WebControls.ListItem("All", "All");
            drpList.Items.Insert(0, oItem);
        }
























        #endregion

        #region GENERIC METHOD TO FILL DROPDOWN
        /// <summary>
        /// Method Name: FillDropDown
        /// Created Date: 06 August 2007
        /// Created By: Saurabh Nayar
        /// Purpose: To Fill The DropDown
        /// </summary>
        /// <param name="drpList">DropDownList Object</param>
        /// <param name="dtTable">DataTable</param>
        /// <param name="strValue">DataValueField</param>
        /// <param name="strText">DataTextField</param>
        public void FillDropDown(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();
        }




        #endregion

        #region METHOD TO FILL NO OF RECORDS DROPDOWN
        public void FillNoOfRecDropDown(System.Web.UI.WebControls.DropDownList drpList)
        {
            drpList.Items.Insert(0, new ListItem("10", "10"));
            drpList.Items.Insert(1, new ListItem("25", "25"));
            drpList.Items.Insert(2, new ListItem("40", "40"));
        }
        #endregion

        public void BindAdditionalReportingCode()
        {
            try
            {


                for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
                {

                    GridView gvAddlMgr = gv_RptMngr.Rows[i].FindControl("gvAddlMgr") as GridView;
                    DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr.Rows[i].FindControl("ddlAdlAgtTyp");
                    Hashtable htParam = new Hashtable();
                    DataSet dsAddmgr = new DataSet();
                    htParam.Add("@MemCode", ViewState["RecruitMemCode"].ToString().Trim());
                    htParam.Add("@RelOrder", 0);
                    htParam.Add("@MvmtType", "MemAddCode");

                    dsAddmgr = objDAL.GetDataSetForPrcCLP("Prc_GetAddlRptMemCodes", htParam);
                    if (dsAddmgr.Tables.Count > 0 && dsAddmgr.Tables[0].Rows.Count > 0)
                    {
                        gvAddlMgr.DataSource = dsAddmgr.Tables[0];
                        gvAddlMgr.DataBind();
                        Session["addlmem"] = dsAddmgr;
                        ddlAdlAgtTyp.SelectedValue = dsAddmgr.Tables[0].Rows[0]["MemType"].ToString().Trim();
                    }
                }


                //if (dsAddmgr.Tables.Count > 0 && dsAddmgr.Tables[0].Rows.Count > 0)
                //{
                //    //GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
                //    //GridView gvAddlMgr = (GridView)grd.FindControl("gvAddlMgr");

                //    gvAddlMgr.DataSource = dsAddmgr.Tables[0];
                //    gvAddlMgr.DataBind();
                //     Session["addlmem"] = dsAddmgr;
                //}


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

        protected void txtOrdInc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtOrdInc1.SelectedValue == "10")
            {
                userinput.Visible = true;
                divtxtotherSeclbl.Visible = true;
            }
            else
            {
                userinput.Visible = false;
                divtxtotherSeclbl.Visible = false;
            }
        }

        protected void Chknominee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chknominee.Checked == true)
            {
                txtNomNme.Enabled = true;
                txtNomDob.Enabled = true;
                txtNomMob.Enabled = true;
                txtNomEmail.Enabled = true;
                ddlNomnRel.Enabled = true;
            }
            else
            {
                txtNomNme.Enabled = false;
                txtNomDob.Enabled = false;
                txtNomMob.Enabled = false;
                txtNomEmail.Enabled = false;
                ddlNomnRel.Enabled = false;
                txtNomNme.Text = "";
                txtNomDob.Text = "";
                txtNomMob.Text = "";
                txtNomEmail.Text = "";
                ddlNomnRel.SelectedIndex = 0;

            }
        }

        protected void btngst_Click(object sender, EventArgs e)
        {

            string Prefix = cboagnTitle.SelectedValue.ToString().Trim();
            string fp_name = Prefix + " " + txtAgntName.Text;
            string fp_pan = txtPanNo.Text;
            string fp_address = txtAddrP1.Text.ToString().Trim() + "," + txtAddrP2.Text.ToString().Trim() + "," + txtAddrP3.Text.ToString().Trim() + "," +
                txtarea.Text.ToString().Trim() + "," + txtDistP.Text.ToString().Trim() + "," + ddlState.SelectedItem.ToString().Trim() + "," + txtPinP.Text.ToString().Trim();
            DataSet Ds = getbytes();
            if (Ds.Tables.Count > 0)
            {
                strPath = strPath + txtAgtCode.Text.Trim();// "40086634";

                Directory.CreateDirectory(strPath);

                //  added   by sanoj sahani for  byte to image convert and store in folder  01062022
                byte[] bytes = (byte[])Ds.Tables[0].Rows[0]["Images"];
                strFileName = strPath + "\\" + Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();

                FileInfo fi = new FileInfo(strFileName);
                using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    FileStream.Write(bytes, 0, bytes.Length);

                }
                string folderName = txtAgtCode.Text.Trim();// "40086634";
                string imgName = Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                string strWindow = "window.open('HTML/GstView.html?fp_name=" + fp_name + "&fp_pan=" + fp_pan + "&fp_address=" + fp_address + "&folderName=" + folderName + "&imgName=" + imgName + " &Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", strWindow, true);
                //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }

            chkgst.Enabled = true;
            btngst.Enabled = true;

        }

        protected void btnView_Click(object sender, EventArgs e)
        {

            DataSet Ds = getbytes();
            if (Ds.Tables.Count > 0)
            {
                strPath = strPath + txtAgtCode.Text.Trim();// "40086634";

                Directory.CreateDirectory(strPath);

                //  added   by sanoj sahani for  byte to image convert and store in folder  01062022
                byte[] bytes = (byte[])Ds.Tables[0].Rows[0]["Images"];
                strFileName = strPath + "\\" + Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();

                FileInfo fi = new FileInfo(strFileName);
                using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    FileStream.Write(bytes, 0, bytes.Length);

                }
                string folderName = txtAgtCode.Text.Trim();// "40086634";
                string imgName = Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                string strWindow = "window.open('HTML/TermsAndCon.html?folderName=" + folderName + "&imgName=" + imgName + " &Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", strWindow, true);

                //string TCtab = "window.open('HTML/TermsAndCon.html?','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", TCtab, true);

                chkagree.Enabled = true;
                btnView.Enabled = true;
                //chkgst.Enabled = true;

            }

            //string TCtab = "window.open('HTML/TermsAndCon.html?','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
            //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", TCtab, true);
            //chkagree.Enabled = true;
            //btnView.Enabled = true;
            //chkgst.Enabled = true;
            //btngst.Enabled = true;
        }

        public DataSet getbytes()
        {
            DataSet dsimg = new DataSet();
            Hashtable htimg = new Hashtable();
            htimg.Add("@Memcode", txtAgtCode.Text.Trim());
            dsimg = objDAL.GetDataSetForPrcCLP("Prc_get_PALDCTMFileUploadMem", htimg);
            if (dsimg.Tables[0].Rows.Count > 0)
            {
                byte[] Array = (Byte[])dsimg.Tables[0].Rows[0]["images"];
            }
            return dsimg;
        }
        //added by ajay 22.06.2022 start
        public void btndisabled()
        {
            if (ddllvlagttype.SelectedItem.ToString().Trim() == "Independent")
            {
                btnRptMgr.Enabled = false;
            }
            else
            {
                btnRptMgr.Enabled = true;
            }
        }
        //added by ajay 22.06.2022 end
      
        protected void _checkbox()
        {

            if (txtAddrP1.Text.ToString().Trim() == txtPermAdd1.Text.ToString().Trim() && ddlState.SelectedValue.ToString().Trim() == ddlState1.SelectedValue.ToString().Trim() && txtAddrP2.ToString().Trim() == txtPermAdd2.ToString().Trim() && txtDistP.ToString().Trim() == txtDistric.ToString().Trim() && txtAddrP3.ToString().Trim() == txtPermAdd3.ToString().Trim() && txtarea.ToString().Trim() == txtarea1.ToString().Trim() && txtcity.ToString().Trim() == txtcity1.ToString().Trim() && txtPinP.ToString().Trim() == txtPermPostcode.ToString().Trim() && txtVillage.ToString().Trim() == txtPermVillage.ToString().Trim() && txtCountryCodeP.ToString().Trim() == txtPermCountryCode.ToString().Trim() && txtCountryDescP.ToString().Trim() == txtPermCountryDesc.ToString().Trim())
            {
                ChkPARes.Checked = true;
            }
            else
            {
                ChkPARes.Checked = false;
            }
        }

        protected void txtNeftCode_TextChanged(object sender, EventArgs e)
        {
            Hashtable httable = new Hashtable();
            DataSet dsResult = new DataSet();

            httable.Add("@IFSCCode", txtNeftCode.Text);
            dsResult = dataAccess.GetDataSetForPrcRecruit("PrcGetBankDetails", httable);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                txtBnkAddress.Text = dsResult.Tables[0].Rows[0]["BRANCH"].ToString().Trim();
                txtBankName.Text = dsResult.Tables[0].Rows[0]["BANK"].ToString().Trim();
            }
            else
            {
                txtBnkAddress.Text = "";
                txtBankName.Text = "";
            }
        }

       
    }
}

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
using System.Web.SessionState;
using System.Text;
using Insc.Common.Data;
using System.ComponentModel;
using System.IO;
using MQSMQMgr;
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using System.Xml;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_Common_Clt : BaseClass
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
        DataAccessClass dataAccess = new DataAccessClass();
        //For cda pan updation start
        DataAccessClass dataAccessRecruit = new DataAccessClass();
        private const string Conn_Direct = "DefaultConn";
        private multilingualManager olng;
        //For cda pan updation End
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
        private Provider oDP = new Insc.Common.Data.Provider();
        string ErrMsg, AuditType;
        DataSet dsClt = new DataSet();
        DataTable dtClt = new DataTable("Clt");
        DataTable dtCltCnct = new DataTable("CltCnct");
        DataTable dtCltPer = new DataTable("CltPer");
        Hashtable htable = new Hashtable();
        Hashtable htParam = new Hashtable();
        DataSet dsResult = new DataSet();
        XmlDocument doc = new XmlDocument();
        string strXML = "";
        const string cSessionQryState = "ClientDetail";
        protected CommonFunc oCommon = new CommonFunc();
        protected string strEnq = string.Empty;
        protected string strGCNA = string.Empty;
        protected string strCnctType = string.Empty;
        protected string strFlagFind = string.Empty;

        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

        string strCarrierCode = string.Empty;
        string strUserGCN = string.Empty;
        string strCltType = "A";
        string strSrc = "1";
        string strErrMsg = string.Empty;
        string strStatusMsg = string.Empty;
        string strGCN = string.Empty;
        int intStatusCode = 0;

        private const string c_strLogPath = "/Log";
        private const string c_strBlank = "-- Select --";
        EncodeDecode ObjDec = new EncodeDecode();
        //Added by rachana on 10-07-2013 for MQ code start
        string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
        //Added by rachana on 10-07-2013 for MQ code end
    #endregion

    #region PAGELOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        olng = new multilingualManager("DefaultConn", "Clt.aspx", Session["UserLangNum"].ToString());
        if (!IsPostBack)
        {
            InitializeControl();
            if (Request.QueryString["CNDID"] != null)
            {
                ViewState["CNDID"] = Request.QueryString["CNDID"].ToString();
            }
            txtAddrB1.Attributes.Add("onchange", "doFormat('" + txtAddrB1.ClientID + "');");
            txtAddrB2.Attributes.Add("onchange", "doFormat('" + txtAddrB2.ClientID + "');");
            txtAddrB3.Attributes.Add("onchange", "doFormat('" + txtAddrB3.ClientID + "');");
            txtAddrB4.Attributes.Add("onchange", "doFormat('" + txtAddrB4.ClientID + "');");

            txtAddrP1.Attributes.Add("onchange", "doFormat('" + txtAddrP1.ClientID + "');");
            txtAddrP2.Attributes.Add("onchange", "doFormat('" + txtAddrP2.ClientID + "');");
            txtAddrP3.Attributes.Add("onchange", "doFormat('" + txtAddrP3.ClientID + "');");
            txtAddrP4.Attributes.Add("onchange", "doFormat('" + txtAddrP4.ClientID + "');");

            subPopulateTitle();
            subPopulateGender();
            subPopulateCategory();
            subPopulateSpecInd();
            
            oCommon.getDropDown(ddlSOE, "SOE", 1, "", 1, c_strBlank);

            txtIndate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            if (Session["dtRecords"] != null)
            {
                Session["dtRecords"] = null;
            }
            hdnDupFlag.Value = "CLNCRTO";
            txtDupBtnFlag.Text = "1";

            txtDOB.MaxDate = DateTime.Today;
            btnDupCltRecords.Enabled = false;
            
            oCommon.getDropDown(ddlCltCreateRule, "CltCrRul", 1, "", 1);    
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "ToggleValidators", "<Script Language=\"JavaScript\">funToggleValidators();</Script>");
        }
        
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();     

        this.lblAPHeadear.Text = "Residential Address ( 1 )";
        this.lblABHeadear.Text = "Business Address ( 1 )";

        lblHeader.Text = Convert.ToString("Personal Client - New");

        this.btnSearchClt.Visible = true;
        this.btnCancel.Visible = true;

        btnDupCltRecords.Attributes.Add("onClick", "javascript: return funOpenPopWin('DuplicateCltRecords.aspx', '','1','0');");
        
        cboCnctType.Attributes.Add("style", "display: visible");
        cboGender.Attributes.Add("style", "display: visible");
        cboMaritalStatus.Attributes.Add("style", "display: visible");
        cboOtherIDType.Attributes.Add("style", "display: visible");
        cboTitle.Attributes.Add("style", "display: visible");

        strFlagFind = this.txtFlagFind.Text;

        // ************************ Define button loops for multiple address ************************
        // ******************************* P - Residential Address ****************************
        hdnCnctType.Value = String.Empty;
        for (int i = 0; i < 9; i++)
        {
            Application_Common_ClientAddress oAddrR = (Application_Common_ClientAddress)Page.LoadControl("ClientAddress.ascx");
            int intAddCnt = i + 2;
            plcAddressP.Controls.Add(oAddrR);
            oAddrR.Text = "Residential " + intAddCnt.ToString();
            oAddrR.CssClass = "standardbutton";
            oAddrR.Width = Unit.Pixel(100);
            oAddrR.Title = "Residential " + intAddCnt.ToString();

            if (hdnCnctType.Value == string.Empty)
                hdnCnctType.Value += oAddrR.ClientID;
            else
                hdnCnctType.Value += "," + oAddrR.ClientID;
            oAddrR = null;
        }

        // ******************************* B - Business Address ****************************
        for (int i = 0; i < 9; i++)
        {
            Application_Common_ClientAddress oAddrB = (Application_Common_ClientAddress)Page.LoadControl("ClientAddress.ascx");
            int intAddCnt = i + 2;
            plcAddressB.Controls.Add(oAddrB);
            oAddrB.Text = "Business " + intAddCnt.ToString();
            oAddrB.CssClass = "standardbutton";
            oAddrB.Width = Unit.Pixel(100);
            oAddrB.Title = "Business " + intAddCnt.ToString();
            if (hdnCnctType.Value == string.Empty)
                hdnCnctType.Value += oAddrB.ClientID;
            else
                hdnCnctType.Value += "," + oAddrB.ClientID;
            oAddrB = null;
        }

        // ************************ Define redirect from New page or Enquiry page ************************
        
        if (Request.QueryString["ENQ"] != null)
        {
            strEnq = Request.QueryString["ENQ"].ToString();
        }
        if (Request.QueryString["GCN"] != null)
        {
            strGCNA = Request.QueryString["GCN"].ToString();
		    ClientScript.RegisterStartupScript(GetType(), "DisableDOB", "<Script Language=\"JavaScript\">funDisableDOB();</Script>");
        }
        if (Request.QueryString["FLAGFIND"] != null)
        {
            strFlagFind = Request.QueryString["FLAGFIND"].ToString();
        }
        
        strCnctType = this.cboCnctType.SelectedValue;

        if (!Page.IsPostBack)
        {
            // ************************ Define buttons and textbox properties ************************
            this.Session.Remove("dtCltCnct");
            ViewState["GCN"] = String.Empty;

            txtSurname.Attributes.Add("onchange", "doFormat('" + txtSurname.ClientID + "');");
            txtGivenName.Attributes.Add("onchange", "doFormat('" + txtGivenName.ClientID + "');");
            txtname.Attributes.Add("onchange", "doFormat('" + txtname.ClientID + "');");

            txtNationalCode.Attributes.Add("onblur", "lookupNational(document.getElementById('" + txtNationalCode.ClientID + "').value, '" + txtNationalDesc.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");

            txtOccupationCode.Attributes.Add("onblur", "lookupOccupation(document.getElementById('" + txtOccupationCode.ClientID + "').value, '" +
                txtOccupationDesc.ClientID + "', '" + Session["UserLangNum"].ToString() + "');");

            btnOccupation.Attributes.Add("onclick", "popOccupation('" + txtOccupationCode.ClientID + "','" + txtOccupationDesc.ClientID + "'," +
                "document.getElementById('" + txtOccupationCode.ClientID + "').value," + "document.getElementById('" + txtOccupationDesc.ClientID + "').value,'" + "');return false;");

            string strCurrentIdNo = string.Empty;
            string strCurrentIdType = string.Empty;

            strCurrentIdNo = txtCurrentID.ClientID;
            strCurrentIdType = "txtCurrentIDType";
            
            txtStateCodeP.Attributes.Add("onblur", "lookupState(document.getElementById('" + txtStateCodeP.ClientID + "').value, '" + txtStateDescP.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
            //Added by swapnesh on 14/5/2013 For showing popup start

            #region commented previous popups code
            //btnSearchClt.Attributes.Add("onclick", "popSearchClt('" + txtGCN.ClientID + "','" + txtSurname.ClientID + "','" + txtGivenName.ClientID + "','" +
            //    cboGender.ClientID + "','" + txtDOB.ClientID + "_txtDate','" + strCurrentIdNo + "','" + strCurrentIdType + "'," +
            //    "document.getElementById('" + txtGCN.ClientID + "').value," + "document.getElementById('" + txtname.ClientID + "').value," +
            //    "document.getElementById('" + txtGivenName.ClientID + "').value," + "document.getElementById('" + cboGender.ClientID + "').value," +
            //    "document.getElementById('" + txtDOB.ClientID + "_txtDate').value," + "document.getElementById('" + strCurrentIdNo + "').value," +
            //    "document.getElementById('" + strCurrentIdType + "').value" + ",'');return false;");
            //btnSearchClt.Attributes.Add("onclick", "popSearchClt('Find');return false;");

            //btnStateP.Attributes.Add("onclick", "popStateP('" + txtStateCodeP.ClientID + "','" + txtStateDescP.ClientID + "'," +
            //    "document.getElementById('" + txtStateCodeP.ClientID + "').value," + "document.getElementById('" + txtStateDescP.ClientID + "').value,'" + "');return false;");
            //btnStateB.Attributes.Add("onclick", "popStateP('" + txtStateCodeB.ClientID + "','" + txtStateDescB.ClientID + "'," +
            //    "document.getElementById('" + txtStateCodeB.ClientID + "').value," + "document.getElementById('" + txtStateDescB.ClientID + "').value,'" + "');return false;");
            //btnState.Attributes.Add("onclick", "popStateP('" + txtStateCode.ClientID + "','" + txtStateDesc.ClientID + "'," +
            //    "document.getElementById('" + txtStateCode.ClientID + "').value," + "document.getElementById('" + txtStateDesc.ClientID + "').value,'" + "');return false;");
            //btnDistP.Attributes.Add("onclick", "ResPopDistrict('" + hdnDistP.ClientID + "','" + txtDistricP.ClientID + "',document.getElementById('" +
            //    txtStateCodeP.ClientID + "').value,document.getElementById('" + txtDistricP.ClientID + "').value,'" + hdnPinFromP.ClientID + "','" + hdnPinToP.ClientID + "');return false;"); 
            //btnDistric.Attributes.Add("onclick", "PersPopDistrict('" + hdnDist.ClientID + "','" + txtDistric.ClientID + "',document.getElementById('" +
            //    txtStateCode.ClientID + "').value,document.getElementById('" + txtDistric.ClientID + "').value,'" + hdnPinFrom.ClientID + "','" + hdnPinTo.ClientID + "');return false;");
            //btnDistrictB.Attributes.Add("onclick", "PopDistrict('" + hdnDistB.ClientID + "','" + txtDistrictB.ClientID + "',document.getElementById('" +
            //    txtStateCodeB.ClientID + "').value,document.getElementById('" + txtDistrictB.ClientID + "').value,'" + hdnPinFromB.ClientID + "','" + hdnPinToB.ClientID + "');return false;");
            //btnCountryP.Attributes.Add("onclick", "popCountryP('" + txtCountryCodeP.ClientID + "','" + txtCountryDescP.ClientID + "'," +
            //    "document.getElementById('" + txtCountryCodeP.ClientID + "').value," + "document.getElementById('" + txtCountryDescP.ClientID + "').value,'" + "');return false;");
            //btnCountryB.Attributes.Add("onclick", "popCountryP('" + txtCountryCodeB.ClientID + "','" + txtCountryDescB.ClientID + "'," +
            //    "document.getElementById('" + txtCountryCodeB.ClientID + "').value," + "document.getElementById('" + txtCountryDescB.ClientID + "').value,'" + "');return false;");
            //btnCountry.Attributes.Add("onclick", "popCountryP('" + txtCountryCode.ClientID + "','" + txtCountryDesc.ClientID + "'," +
            //    "document.getElementById('" + txtCountryCode.ClientID + "').value," + "document.getElementById('" + txtCountryDesc.ClientID + "').value,'" + "');return false;");
            //btnNational.Attributes.Add("onclick", "popNational('" + txtNationalCode.ClientID + "','" + txtNationalDesc.ClientID + "'," +
            //    "document.getElementById('" + txtNationalCode.ClientID + "').value," + "document.getElementById('" + txtNationalDesc.ClientID + "').value,'" + "');return false;");
            #endregion

            btnNational.Attributes.Add("onclick", "funcShowPopup('National');return false;");
            btnCountry.Attributes.Add("onclick", "funcShowPopup('country');return false;");
            btnState.Attributes.Add("onclick", "funcShowPopup('state');return false;");
            btnStateP.Attributes.Add("onclick", "funcShowPopup('stateP');return false;");
            btnStateB.Attributes.Add("onclick", "funcShowPopup('stateB');return false;");
            btnSearchClt.Attributes.Add("onclick", "funcShowPopup('Find');return false;");
            btnDistP.Attributes.Add("onclick", "funcShowPopup('District');return false;");
            btnDistrictB.Attributes.Add("onclick", "funcShowPopup('District1');return false;");
            btnDistric.Attributes.Add("onclick", "funcShowPopup('District2');return false;");
            btnCountryP.Attributes.Add("onclick", "funcShowPopup('country');return false;");
            btnCountryB.Attributes.Add("onclick", "funcShowPopup('countryB');return false;");

            //Added by swapnesh on 14/5/2013 For showing popup end
            txtCountryCodeP.Attributes.Add("onblur", "lookupCountry(document.getElementById('" + txtCountryCodeP.ClientID + "').value, '" + txtCountryDescP.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
            
            txtCountryCodeB.Attributes.Add("onblur", "lookupCountry(document.getElementById('" + txtCountryCodeB.ClientID + "').value, '" +
                txtCountryDescB.ClientID + "', '" + Session["UserLangNum"].ToString() + "');");
            
            txtAdd1.Attributes.Add("onchange", "doFormat('" + txtAdd1.ClientID + "');");
            txtAdd2.Attributes.Add("onchange", "doFormat('" + txtAdd2.ClientID + "');");
            txtAdd3.Attributes.Add("onchange", "doFormat('" + txtAdd3.ClientID + "');");

            txtStateCode.Attributes.Add("onblur", "lookupState(document.getElementById('" + txtStateCode.ClientID + "').value, '" +
                txtStateDesc.ClientID + "', '" + Session["UserLangNum"].ToString() + "');");
            
            txtCountryCode.Attributes.Add("onblur", "lookupCountry(document.getElementById('" + txtCountryCode.ClientID + "').value, '" + 
                txtCountryDesc.ClientID + "', '" + Session["UserLangNum"].ToString() + "');");
            
            if (strGCNA.Length > 0)
            {
			    //For Pan no Not update  in life asia start
                txtCurrentID.ReadOnly = true;
                //For Pan no Not update  in life asia End
                ViewEntry();
                string strGCN = string.Empty;
                strGCN = strGCNA.ToString();

                if (strEnq == "1")
                {
                    this.btnSearchClt.Visible = false;
                    this.btnCancel.Visible = true;
                }

                RetrieveClt(strGCN, strCarrierCode);
                RetrieveCltCnct(strGCN, strCarrierCode);
                RetrieveCltPer(strGCN);

                lblHeader.Text = Convert.ToString("Personal Client - View");
                //For CDA channel
                ddlChannels.SelectedValue = "CD";
                ddlChannels.Enabled = false;
            }
            else
            {
                NewEntry();
            }

            string strUserGroupCode = AdminUser.AdminDAL.GetUserGroup(); 

            // ************************ Define authority for read only and read write ***********************
            if (strUserGroupCode.ToUpper() == "AGENT")
                ReadEntry();
            else
                WriteEntry();
            if (HttpContext.Current.Session["SaveFlag"] == "1")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
            HttpContext.Current.Session["SaveFlag"] = "";

            Response.Write(Convert.ToString(Session["AMLFlag"]));
            if (txtGCN.Text == "")
            {
                txtAMLFlag.Text = "1";
            }
            else
            {
                txtAMLFlag.Text = "1";
            }
            HttpContext.Current.Session["AMLFlag"] = "";

            this.LoadControls();
            
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "TogglePermAddrValidators", "<Script Language=\"JavaScript\">funTogglePermAdd();</Script>");
        }

        txtGCN.Enabled = false;
        txtCltCode.Enabled = false;
        txtGivenName.Focus();

        ChkPA.Attributes.Add("onClick", "javascript: funTogglePermAdd();");
        if (Request.QueryString["Type"] == "N")
        {
            ClientScript.RegisterStartupScript(GetType(), "DisableRecruitingInfoControls", "<Script Language=\"JavaScript\">funDisableRecruitInfoDate();</Script>");
        }
        
        ddlSOE.SelectedValue = "SI";
        ddlCategory.SelectedValue = "99";

        ddlCategory.Enabled = false;
        ddlSOE.Enabled = false;

        txtOccupationCode.Text = "OTHR";
        txtOccupationDesc.Text = "Other";

        txtOccupationCode.Enabled = false;
        txtOccupationDesc.Enabled = false;

        SetDefaultAmlValue();

        btnAML.Attributes.Add("disabled", "disabled");
        ddlSOE.Attributes.Add("disabled", "disabled");
        ddlCategory.Attributes.Add("disabled", "disabled");
        btnOccupation.Attributes.Add("disabled", "disabled");
        //For CDA Pan Updation start
        btnVerifyPAN.Enabled = false;
	    lblmandatory.Visible = false;
        //For CDA Pan Updation End
    }
    #endregion

    #region InitializeControl Method
    private void InitializeControl()
    {
        lblHeader.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeader"));
        lblCusID.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCusID"));
        lblCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCode"));
        lblName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblName"));
        lblSurName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSurName"));
        lblChannel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblChannel"));
        lbldob.Text = ObjDec.GetDecData(olng.GetItemDesc("lbldob"));
        lblFname.Text = ObjDec.GetDecData(olng.GetItemDesc("lblFname"));
        lblPAN.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPAN"));
        lblGender.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGender"));
        lblspIndicator.Text = ObjDec.GetDecData(olng.GetItemDesc("lblspIndicator"));
        lblAltIDType.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAltIDType"));
        lblMstatus.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMstatus"));
        lblAltIDNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAltIDNo"));
        lblSOE.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSOE"));
        lblNationality.Text = ObjDec.GetDecData(olng.GetItemDesc("lblNationality"));
        lblCategory.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCategory"));
        lblHigestQul.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHigestQul"));
        lblCorrAdd.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCorrAdd"));
        lblInceptiondate.Text = ObjDec.GetDecData(olng.GetItemDesc("lblInceptiondate"));
        lblAPHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAPHeadear"));
        lblAddrP1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddrP1"));
        lblStateP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateP"));
        Label2.Text = ObjDec.GetDecData(olng.GetItemDesc("Label2"));
        lblPinP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPinP"));
        lblCountryP.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountryP"));
        lblABHeadear.Text = ObjDec.GetDecData(olng.GetItemDesc("lblABHeadear"));
        lblAddrB1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAddrB1"));
        lblStateB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateB"));
        Label3.Text = ObjDec.GetDecData(olng.GetItemDesc("Label3"));
        lblPinB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPinB"));
        lblCountryB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCountryB"));
        lblPA.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPA"));
        Label4.Text = ObjDec.GetDecData(olng.GetItemDesc("Label4"));
        lblHomeTel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHomeTel"));
        lblOfficeTel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblOfficeTel"));
        lblDIdNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDIdNo"));
        lblMobileNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblMobileNo"));
        lblEmail.Text = ObjDec.GetDecData(olng.GetItemDesc("lblEmail"));
        lblPager.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPager"));
        lblFax.Text = ObjDec.GetDecData(olng.GetItemDesc("lblFax"));
        lblHeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblHeight"));
        lblWeight.Text = ObjDec.GetDecData(olng.GetItemDesc("lblWeight"));
        lblOccup.Text = ObjDec.GetDecData(olng.GetItemDesc("lblOccup"));
        lblAnnualIncome.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAnnualIncome"));
        lblPreferedClient.Text = ObjDec.GetDecData(olng.GetItemDesc("lblPreferedClient"));
        lblStaff.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStaff"));
        lblServiceTax.Text = ObjDec.GetDecData(olng.GetItemDesc("lblServiceTax"));
        lblRemark.Text = ObjDec.GetDecData(olng.GetItemDesc("lblRemark"));
        lblComfirmHeader.Text = ObjDec.GetDecData(olng.GetItemDesc("lblComfirmHeader"));
        Label1.Text = ObjDec.GetDecData(olng.GetItemDesc("Label1"));
    }
    #endregion

    #region LOADCONTROLS
    private void LoadControls()
    {
        if (Request.QueryString["CNDID"] != null)
        {
            strFlagFind = "0";
            CnctType(true);
            dsResult = new DataSet();
            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htable.Add("@CNDNO", Request.QueryString["CNDID"].ToString());

            dsResult = dataAccess.GetDataSetForPrcDBConn("prc_SelectCNDFromCltDetails", htable, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA_Recruit);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["Title"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Title"].ToString() != "")
                        {
                            cboTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                            cboTitle.Enabled = false;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["GivenName"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["GivenName"].ToString() != "")
                        {
                            this.txtGivenName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GivenName"]);
                            this.txtGivenName.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["SurName"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["SurName"].ToString() != "")
                        {
                            this.txtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SurName"]);
                            this.txtname.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["FatherName"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["FatherName"].ToString() != "")
                        {
                            this.txtSurname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["FatherName"]);
                            this.txtSurname.ReadOnly = true;
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["BirthRegDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString() != "")
                        {
                            txtDOB.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                            this.txtDOB.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["PAN"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString() != "")
                        {
                            this.txtCurrentID.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAN"]);
                            this.txtCurrentID.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["Gender"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Gender"].ToString().Trim() != "")
                        {
                            cboGender.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]);
                            cboGender.Enabled = false;
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["PAddress1"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PAddress1"].ToString() != "")
                        {
                            this.txtAdd1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress1"]);
                            this.txtAdd1.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["PAddress2"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PAddress2"].ToString() != "")
                        {
                            this.txtAdd2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress2"]);
                            this.txtAdd2.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["PAddress3"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PAddress3"].ToString() != "")
                        {
                            this.txtAdd3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress3"]);
                            this.txtAdd3.ReadOnly = true;
                        }
                    }
                    
                    if (dsResult.Tables[0].Rows[0]["Maritalstat"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Maritalstat"].ToString().Trim() != "")
                        {
                            this.cboMaritalStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Maritalstat"].ToString().Trim());

                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["QualCode"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["QualCode"].ToString().Trim() != "")
                        {
                            this.cboQualCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"].ToString().Trim());

                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["HomeTel"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["HomeTel"].ToString() != "")
                        {
                            this.txtHomeTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HomeTel"]);
                            this.txtHomeTel.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["WorkTel"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["WorkTel"].ToString() != "")
                        {
                            this.txtWorkTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                            this.txtWorkTel.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["DidTel"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["DidTel"].ToString() != "")
                        {
                            this.txtDidtel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DidTel"]);
                            this.txtDidtel.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["WorkFax"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["WorkFax"].ToString() != "")
                        {
                            this.txtFax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                            this.txtFax.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["Pager"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Pager"].ToString() != "")
                        {
                            this.txtPager.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Pager"]);
                            this.txtPager.ReadOnly = true;
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["Email"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["Email"].ToString() != "")
                        {
                            this.txtEmail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                            this.txtEmail.ReadOnly = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["MobileTel"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["MobileTel"].ToString() != "")
                        {
                            this.txtMobileTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MobileTel"]);
                            this.txtMobileTel.ReadOnly = true;
                        }
                    }

                    if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["DrMailId"]) == false)
                    {
                        ChkDrml.Checked = false;
                        ChkDrml.Enabled = false;
                    }
                    else if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["DrMailId"]) == true)
                    {
                        ChkDrml.Checked = true;
                        ChkDrml.Enabled = false;
                    }
                    
                    if (dsResult.Tables[0].Rows[0]["PermAdrInd"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PermAdrInd"].ToString() != "")
                        {
                            ChkPA.Checked = true;
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["DefCnctType"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["DefCnctType"].ToString() != "")
                        {
                            cboCnctType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["DefCnctType"]);
                            cboCnctType.Enabled = false;
                        }
                    }
                    txtOccupationCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OcpnCode"]);
                    txtOccupationDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OcpnDesc"]);
                    txtNationalCode.ReadOnly = true;
                    txtNationalDesc.ReadOnly = true;
                    ddlCltCreateRule.Enabled = false;
                    if (dsResult.Tables[0].Rows[0]["DefCnctType"].ToString() == "P1")
                    {
                        txtAddrP1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress1"]);
                        txtAddrP2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress2"]);
                        txtAddrP3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress3"]);
                        txtAddrP1.Enabled = false;
                        txtAddrP2.Enabled = false;
                        txtAddrP3.Enabled = false;

                        this.txtStateCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RStateCode"]);
                        this.txtStateDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RStateDesc"]);
                        this.txtPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RPostCode"]);
                        this.txtCountryCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RCntryCode"]);
                        this.txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RCntryDesc"]);
                        this.txtDistricP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                        this.txtDistricP.ReadOnly = true;
                        btnDistP.Enabled = false;
                        this.txtStateCodeP.ReadOnly = true;
                        this.txtStateDescP.ReadOnly = true;
                        this.txtPinP.ReadOnly = true;
                        this.txtCountryCodeP.ReadOnly = true;
                        this.txtCountryDescP.ReadOnly = true;

                    }
                    if (dsResult.Tables[0].Rows[0]["DefCnctType"].ToString() == "B1")
                    {
                        txtAddrB1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress1"]);
                        txtAddrB2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress2"]);
                        txtAddrB3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RAddress3"]);
                        txtAddrB1.Enabled = false;
                        txtAddrB2.Enabled = false;
                        txtAddrB3.Enabled = false;

                        this.txtStateCodeB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RStateCode"]);
                        this.txtStateDescB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RStateDesc"]);
                        this.txtPinB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RPostCode"]);
                        this.txtCountryCodeB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RCntryCode"]);
                        this.txtCountryDescB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RCntryDesc"]);
                        this.txtDistrictB.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                        this.txtDistrictB.ReadOnly = true;
                        btnDistrictB.Enabled = false;
                        this.txtStateCodeB.ReadOnly = true;
                        this.txtStateDescB.ReadOnly = true;
                        this.txtPinB.ReadOnly = true;
                        this.txtCountryCodeB.ReadOnly = true;
                        this.txtCountryDescB.ReadOnly = true;
                    }
                    if (dsResult.Tables[0].Rows[0]["PAddress1"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["PAddress1"].ToString().Trim() != "")
                        {
                            txtAdd1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress1"]);
                            txtAdd2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress2"]);
                            txtAdd3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PAddress3"]);
                            txtAdd1.Enabled = false;
                            txtAdd2.Enabled = false;
                            txtAdd3.Enabled = false;

                            txtStateCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PStateCode"]);
                            txtStateCode.ReadOnly = true;
                            txtStateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PStateDesc"]);
                            txtStateDesc.ReadOnly = true;
                            txtPostcode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PPostCode"]);
                            txtPostcode.ReadOnly = true;
                            this.txtCountryCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PCntryCode"]);
                            this.txtCountryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PCntryDesc"]);
                            this.txtCountryCode.ReadOnly = true;
                            this.txtCountryDesc.ReadOnly = true;
                            this.txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                            this.txtDistric.ReadOnly = true;
                            btnDistric.Enabled = false;
                        }
                    }
                }
            }
            htable.Clear();
        }
    }
    #endregion

    #region FUNCTION subPopulateCategory
    private void subPopulateCategory()
    {
        switch (Session["CarrierCode"].ToString())
        {
            case "1":
                oCommon.getDropDown(ddlCategory, "NLCategory", 1, "", 1, c_strBlank);
                break;

            case "2":
                
                DataSet dsCatg = new DataSet();
                //Added by Pranjali on 28-06-2013 for populating category start
                Hashtable htparam = new Hashtable();
                htparam.Add("@ResNo", "2000003");
                dsCatg = dataAccessRecruit.GetDataSetForPrcINSCLIFENewBiz("Prc_populatesubcategory",htparam);
                //Added by Pranjali on 28-06-2013 for populating category end
               
                if (dsCatg.Tables.Count > 0)
                {
                    if (dsCatg.Tables[0].Rows.Count > 0)
                    {
                        objCommonU.FillDropDown(ddlCategory, dsCatg.Tables[0], "ResCode", "CodeName");
                        ddlCategory.Items.Insert(0, new ListItem("-- Select --", ""));
                    }
                    else
                    {
                        ddlCategory.Items.Insert(0, new ListItem("-- Select --", ""));
                    }
                }
                dsCatg = null;
                //strSQL = null;
                break;
        }
    }
    #endregion

    #region FUNCTION subPopulateSpecInd
    private void subPopulateSpecInd()
    {
        switch (Session["CarrierCode"].ToString())
        {
            case "1":
                oCommon.getDropDown(ddlSpecInd, "NLSpecInd", 1, "", 1, c_strBlank);
                break;

            case "2":
                oCommon.getDropDown(ddlSpecInd, "LFSpecInd", 1, "", 1, c_strBlank);
                break;
        }
    }
    #endregion

    #region FUNCTION subPopulateGender
    private void subPopulateGender()
    {
        oCommon.getDropDown(cboGender, "NBGender", 1, "", 1, c_strBlank);
        cboGender.Items.Remove(cboGender.Items.FindByValue("C"));
        cboGender.Items.Remove(cboGender.Items.FindByValue("U"));
        subGenerateGenderValidation();
    }
    #endregion

    #region FUNCTION subGenerateGenderValidation
    private void subGenerateGenderValidation()
    {
        DataTable dtGenderTitle = oDP.ReadData("INSCDirectConnectionString", "prc_GenderTitle_sel").Tables[0];
        foreach (DataRow row in dtGenderTitle.Rows)
        {
            hdnGenderTitle1.Value += row[0].ToString() + ",";
            hdnGenderTitle2.Value += row[1].ToString() + ",";
        }
        hdnGenderTitle1.Value = hdnGenderTitle1.Value.Trim(',');
        hdnGenderTitle2.Value = hdnGenderTitle2.Value.Trim(',');
    }
    #endregion

    #region FUNCTION ReadEntry
    private void ReadEntry()
    {
        lblHeader.Text = lblHeader.Text + " (Read only)";
        this.txtALIncome.Enabled = false;
        ddlSOE.Enabled = false;
        this.txtCltStat.Enabled = false;
        this.txtCurrentID.Enabled = false;
        this.txtDOB.ReadOnly = true;
        this.txtEmail.Enabled = false;
        this.txtGivenName.Enabled = false;
        this.txtHomeTel.Enabled = false;
        this.txtMobileTel.Enabled = false;
        this.txtNationalCode.Enabled = false;
        this.txtNationalDesc.Enabled = false;
        this.txtOccupationCode.Enabled = false;
        this.txtOccupationDesc.Enabled = false;
        this.txtOthersID.Enabled = false;
        this.txtSurname.Enabled = false;
        this.txtWorkTel.Enabled = false;
        this.ddlDstbnMethod.ddliSysLParamEnabled = false;
        this.cboCnctType.Enabled = false;
        this.cboGender.Enabled = false;
        this.cboMaritalStatus.ddliSysLParamEnabled = false;
        this.cboOtherIDType.ddliSysLParamEnabled = false;
        this.cboQualCode.ddliSysLParamEnabled = false;
        ddlCategory.Enabled = false;
        this.cboTitle.Enabled = false;
        this.btnSave.Enabled = false;
        this.Menu1.Enabled = false;
        this.btnNational.Enabled = false;
        this.btnOccupation.Enabled = false;
    }
    #endregion

    #region FUNCTION WriteEntry
    private void WriteEntry()
    {
        this.txtALIncome.Enabled = true;
        ddlSOE.Enabled = true;
        this.txtCltStat.Enabled = true;
        this.txtCurrentID.Enabled = true;
        this.txtDOB.ReadOnly = false;
        this.txtEmail.Enabled = true;
        this.txtGivenName.Enabled = true;
        this.txtHomeTel.Enabled = true;
        this.txtMobileTel.Enabled = true;
        this.txtNationalCode.Enabled = true;
        this.txtNationalDesc.Enabled = true;
        this.txtOccupationCode.Enabled = true;
        this.txtOccupationDesc.Enabled = true;
        this.txtOthersID.Enabled = true;
        ddlCategory.Enabled = true;
        this.txtSurname.Enabled = true;
        this.txtWorkTel.Enabled = true;
        this.ddlDstbnMethod.ddliSysLParamEnabled = true;
        this.cboCnctType.Enabled = true;
        this.cboGender.Enabled = true;
        this.cboMaritalStatus.ddliSysLParamEnabled = true;
        this.cboOtherIDType.ddliSysLParamEnabled = true;
        this.cboQualCode.ddliSysLParamEnabled = true;
        this.cboTitle.Enabled = true;
        this.btnNational.Enabled = true;
        this.btnOccupation.Enabled = true;
        this.txtDidtel.Enabled = true;
    }
    #endregion

    #region FUNCTION NewEntry
    private void NewEntry()
    {
        lblHeader.Text = Convert.ToString("Personal Client - New");

        plcAddressP.Visible = false;
        plcAddressB.Visible = false;
        this.btnSave.Text = "Save";
        this.btnSave.Enabled = true;
        this.txtFlagFind.Text = string.Empty;

        this.lblEstB1.Text = "";
        this.lblEstB3.Text = "";
        this.lblEstB4.Text = "";
        this.lblEstB5.Text = "";
        this.lblEstB6.Text = "";

        this.lblEstP3.Text = "*";
        this.lblEstP4.Text = "*";
        this.lblEstP5.Text = "*";
        this.lblEstP6.Text = "*";

        this.txtCountryCodeP.Text = "IND";
        this.txtCountryDescP.Text = "INDIA";
        this.txtNationalCode.Text = "IND";
        this.txtNationalDesc.Text = "INDIA";
        CnctType(true);
    }
    #endregion

    #region FUNCTION ViewEntry
    private void ViewEntry()
    {
        lblHeader.Text = Convert.ToString("Personal Client - View");

        plcAddressP.Visible = true;
        plcAddressB.Visible = true;
        this.btnSave.Text = "Update";
        if (HttpContext.Current.Session["SaveFlag"] == "1")
        {
            btnSave.Enabled = false;
        }
        else
        {
            btnSave.Enabled = true;
        }
        CnctType(false);
    }
    #endregion

    #region FUNCTION CnctType
    private void CnctType(Boolean blnNew)
    {
        ListItem[] items = new ListItem[1];

        string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();

        cboCnctType.Items.Clear();
        // Added by Pranjali on 28-06-2013 for Candidate Address Type

        //if (blnNew)
        //{

            dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper() +"'";  // Added by Pranjali on 28-06-2013 for Candidate Address Type of B1 and P1
        // Added by Pranjali on 28-06-2013 for Candidate Address Type end

        // }
       // else
        //{

          //  dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper()+ "'";// Added by Pranjali on 28-06-2013 for all Candidate Address Type-- Business and Residential 
        //}
        
        cboCnctType.DataBind();
    }
    #endregion

    #region FUNCTION GetAddHeader
    private string GetAddHeader(string strCnctType)
    {
        string strType = strCnctType.Substring(0, 1);
        string strNo = strCnctType.Substring(1, 1);
        string strDesc = string.Empty;

        switch (strType)
        {
            case "P":
                strDesc = "Residential Address " + strNo;
                break;
            case "B":
                strDesc = "Business Address " + strNo;
                break;
        }
        return strDesc;
    }
    #endregion

    #region FUNCTION txtGCN_OnTextChanged
    protected void txtGCN_OnTextChanged(object sender, EventArgs e)
    {
        string strGCN = txtGCN.ToString();

        ViewState["GCN"] = strGCN;
        if (strGCN.Length == 0)
            NewEntry();
        else
            ViewEntry();
    }
    #endregion

    #region FUNCTION SetCltCnct
    private void SetCltCnct(DataRow drCltCnct, Application_Common_ClientAddress oClientAddress)
    {
        oClientAddress.Value_Address1 = drCltCnct["Adr1"].ToString();
        oClientAddress.Value_Address2 = drCltCnct["Adr2"].ToString();
        oClientAddress.Value_Address3 = drCltCnct["Adr3"].ToString();
        oClientAddress.Value_Address4 = drCltCnct["Adr4"].ToString();
        oClientAddress.Value_City = drCltCnct["City"].ToString();
        oClientAddress.Value_Postcode = drCltCnct["PostCode"].ToString();
        oClientAddress.Value_State = drCltCnct["StateCode"].ToString();
        oClientAddress.Value_Country = drCltCnct["CntryCode"].ToString();
        oClientAddress.Value_District = drCltCnct["District"].ToString();
    }
    #endregion 

    #region FUNCTION SetCltCnctP
    private void SetCltCnctP(DataRow drCltCnct)
    {
        this.txtAddrP1.Text = drCltCnct["Adr1"].ToString();
        this.txtAddrP2.Text = drCltCnct["Adr2"].ToString();
        this.txtAddrP3.Text = drCltCnct["Adr3"].ToString();
        this.txtAddrP4.Text = drCltCnct["Adr4"].ToString();
        this.txtPinP.Text = drCltCnct["PostCode"].ToString();
        this.txtStateCodeP.Text = drCltCnct["StateCode"].ToString();
        this.txtStateDescP.Text = drCltCnct["StateCodeDesc"].ToString();
        this.txtCountryCodeP.Text = drCltCnct["CntryCode"].ToString();
        this.txtCountryDescP.Text = drCltCnct["CntryCodeDesc"].ToString();
        this.txtDistricP.Text = drCltCnct["District"].ToString();
    }
    #endregion

    #region FUNCTION SetCltCnct
    private void SetCltCnct(DataRow drCltCnct)
    {
        this.txtAdd1.Text = drCltCnct["Adr1"].ToString();
        this.txtAdd2.Text = drCltCnct["Adr2"].ToString();
        this.txtAdd3.Text = drCltCnct["Adr3"].ToString();
        this.txtPostcode.Text = drCltCnct["PostCode"].ToString();
        this.txtStateCode.Text = drCltCnct["StateCode"].ToString();
        this.txtStateDesc.Text = drCltCnct["StateCodeDesc"].ToString();
        this.txtCountryCode.Text = drCltCnct["CntryCode"].ToString();
        this.txtCountryDesc.Text = drCltCnct["CntryCodeDesc"].ToString();
        this.txtDistric.Text = drCltCnct["District"].ToString();
    }
    #endregion

    #region FUNCTION SetCltCnctB
    private void SetCltCnctB(DataRow drCltCnct)
    {
        this.txtAddrB1.Text = drCltCnct["Adr1"].ToString();
        this.txtAddrB2.Text = drCltCnct["Adr2"].ToString();
        this.txtAddrB3.Text = drCltCnct["Adr3"].ToString();
        this.txtAddrB4.Text = drCltCnct["Adr4"].ToString();
        this.txtPinB.Text = drCltCnct["PostCode"].ToString();
        this.txtStateCodeB.Text = drCltCnct["StateCode"].ToString();
        this.txtStateDescB.Text = drCltCnct["StateCodeDesc"].ToString();
        this.txtCountryCodeB.Text = drCltCnct["CntryCode"].ToString();
        this.txtCountryDescB.Text = drCltCnct["CntryCodeDesc"].ToString();
        this.txtDistrictB.Text = drCltCnct["District"].ToString();
    }
    #endregion

    #region FUNCTION SetCltPer
    private void SetCltPer(DataRow drCltPer, Application_Common_ClientAML oClientAML)
    {
        txtHeight1.Text = drCltPer["Height"].ToString();
        txtWeight.Text = drCltPer["Weight"].ToString();
        oClientAML.Value_ChgWghtReason = drCltPer["ChgWghtReason"].ToString();
        
        oClientAML.Value_ProofAddr = drCltPer["ProofAddrDoc"].ToString();
        oClientAML.Value_PermProofAddr = drCltPer["PermProofAddrDoc"].ToString();	
        oClientAML.Value_ProofIncome = drCltPer["ProofIncomeDoc"].ToString();
        oClientAML.Value_ProofID = drCltPer["ProofIDDoc"].ToString();
        oClientAML.Value_IDNo = drCltPer["IDNo"].ToString();
        oClientAML.Value_IdIssueAuth = drCltPer["IdIssueAuth"].ToString();
        
        oClientAML.Value_RiskInd = drCltPer["CltRiskInd"].ToString();
        oClientAML.strGCN = drCltPer["GCN"].ToString();
        if (drCltPer["IdIssueDate"] != DBNull.Value)
            oClientAML.Value_IdIssueDate = DateTime.Parse(drCltPer["IdIssueDate"].ToString()).ToString("dd/MM/yyyy");

        if (drCltPer["HasPhoto"].ToString() != string.Empty)
            if (drCltPer["HasPhoto"].ToString() == "T")
                oClientAML.Value_chkPhoto = true.ToString();
    }
    #endregion

    #region FUNCTION RetrieveClt
    private void RetrieveClt(string strGCN, string strCarrierCode)
    {
        dtClt = oMQCltMgr.GetClt(strGCN, strCarrierCode);
        txtFlagFind.Text = strFlagFind.ToString();
        CnctType(false);

        if (dtClt.Rows.Count > 0)
        {
            HttpContext.Current.Session["GCN"] = dtClt.Rows[0]["GCN"].ToString();

            this.txtGCN.Text = dtClt.Rows[0]["GCN"].ToString().Trim();
            this.txtCltCode.Text = dtClt.Rows[0]["ClientCode"].ToString().Trim();
            this.cboTitle.SelectedValue = dtClt.Rows[0]["Title"].ToString().Trim();
            this.txtGivenName.Text = dtClt.Rows[0]["GivenName"].ToString().Trim();
            this.txtname.Text = dtClt.Rows[0]["Surname"].ToString().Trim();
            this.txtSurname.Text = dtClt.Rows[0]["ParentName"].ToString().Trim();
            
            if (dtClt.Rows[0]["BirthRegDate"] != DBNull.Value)
                this.txtDOB.Text = DateTime.Parse(dtClt.Rows[0]["BirthRegDate"].ToString()).ToString("dd/MM/yyyy");
            this.cboGender.SelectedValue = dtClt.Rows[0]["Gender"].ToString().Trim();
            this.txtCurrentID.Text = dtClt.Rows[0]["CurrentID"].ToString().Trim();
            this.txtOthersID.Text = dtClt.Rows[0]["AltId"].ToString().Trim();
            this.cboOtherIDType.SelectedValue = dtClt.Rows[0]["AltIDType"].ToString().Trim().Trim();
            this.cboMaritalStatus.SelectedValue = dtClt.Rows[0]["MaritalStat"].ToString();
            this.txtNationalCode.Text = dtClt.Rows[0]["Nationality"].ToString().Trim();
            this.txtNationalDesc.Text = dtClt.Rows[0]["NationalityDesc"].ToString().Trim();
            
            this.cboQualCode.SelectedValue = dtClt.Rows[0]["QualCode"].ToString().Trim();
            this.cboCnctType.SelectedValue = dtClt.Rows[0]["DefCnctType"].ToString();
            this.txtHomeTel.Text = dtClt.Rows[0]["HomeTel"].ToString().Trim();
            this.txtMobileTel.Text = dtClt.Rows[0]["MobileTel"].ToString().Trim();
            this.txtWorkTel.Text = dtClt.Rows[0]["WorkTel"].ToString().Trim();
            this.txtEmail.Text = dtClt.Rows[0]["Email"].ToString().Trim();
            this.txtOccupationCode.Text = dtClt.Rows[0]["OcpnCode01"].ToString().Trim();
            this.txtOccupationDesc.Text = dtClt.Rows[0]["OcpnCode01Desc"].ToString().Trim();
            this.ddlPrivacy.SelectedValue = dtClt.Rows[0]["PrivacyStat"].ToString().Trim();
            this.ddlDstbnMethod.SelectedValue = dtClt.Rows[0]["DstbnMethod"].ToString().Trim();
            chkVip.Checked = (dtClt.Rows[0]["PrfStat"].ToString() == "90");
            chkSalesTax.Checked = (dtClt.Rows[0]["TaxStat"].ToString() == "T") ? true : false;
            foreach (ListItem lstItem in ddlCltCreateRule.Items)
            {
                if (lstItem.Value == Convert.ToString(dtClt.Rows[0]["CltCrRul"]).Trim())
                {
                    ddlCltCreateRule.SelectedValue = lstItem.Value;
                    break;
                }
            }
            
            ChkPA.Checked = (dtClt.Rows[0]["PermAdrInd"].ToString() == "T") ? true : false;
            foreach (ListItem lstItem in ddlSOE.Items)
            {
                if (lstItem.Value == Convert.ToString(dtClt.Rows[0]["SOE"]).Trim())
                {
                    ddlSOE.SelectedValue = lstItem.Value;
                    break;
                }
            }
            foreach (ListItem lstItem in ddlSpecInd.Items)
            {
                if (lstItem.Value == Convert.ToString(dtClt.Rows[0]["SpecInd2"]).Trim())
                {
                    ddlSpecInd.SelectedValue = lstItem.Value;
                    break;
                }
            }
            foreach (ListItem lstItem in ddlCategory.Items)
            {
                if (lstItem.Value == Convert.ToString(dtClt.Rows[0]["Category2"]).Trim())
                {
                    ddlCategory.SelectedValue = lstItem.Value;
                    break;
                }
            }
            Menu1.Text = Convert.ToString(dtClt.Rows[0]["Remark"]).Trim();
            
            if (dtClt.Rows[0]["Inceptiondate"].ToString() != null && dtClt.Rows[0]["Inceptiondate"].ToString().Trim() != "")
            {
                this.txtIndate.Text = DateTime.Parse(dtClt.Rows[0]["Inceptiondate"].ToString().Trim()).ToString("dd/MM/yyyy");
            }
            else
            {
                this.txtIndate.Text = "";
            }
        }
    }
    #endregion

    #region FUNCTION RetrieveCltCnct
    private void RetrieveCltCnct(string strGCN, string strCarrierCode)
    {
        dtCltCnct = oMQCltMgr.GetCltCnct(strGCN, strCarrierCode);

        for (int i = 0; i < dtCltCnct.Rows.Count; i++)
        {
            string strCnctType = dtCltCnct.Rows[i]["CnctType"].ToString();
            switch (strCnctType)
            {
                case "P1":
                    SetCltCnctP(dtCltCnct.Rows[i]);
                    break;
                case "P2":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[0]);
                    break;
                case "P3":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[1]);
                    break;
                case "P4":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[2]);
                    break;
                case "P5":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[3]);
                    break;
                case "P6":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[4]);
                    break;
                case "P7":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[5]);
                    break;
                case "P8":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[6]);
                    break;
                case "P9":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[7]);
                    break;
                case "P0":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressP.Controls[8]);
                    break;
                case "B1":
                    SetCltCnctB(dtCltCnct.Rows[i]);
                    break;
                case "B2":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[0]);
                    break;
                case "B3":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[1]);
                    break;
                case "B4":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[2]);
                    break;
                case "B5":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[3]);
                    break;
                case "B6":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[4]);
                    break;
                case "B7":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[5]);
                    break;
                case "B8":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[6]);
                    break;
                case "B9":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[7]);
                    break;
                case "B0":
                    SetCltCnct(dtCltCnct.Rows[i], (Application_Common_ClientAddress)plcAddressB.Controls[8]);
                    break;
                case "M1":
                    SetCltCnct(dtCltCnct.Rows[i]);
                    break;
            }
        }
    }
    #endregion

    #region FUNCTION RetrieveCltPer
    private void RetrieveCltPer(string strGCN)
    {
        dtCltPer = oMQCltMgr.GetCltPer(strGCN);

        if (dtCltPer.Rows.Count > 0)
        {
            SetCltPer(dtCltPer.Rows[0], btnAML);
        }

    }
    #endregion

    #region FUNCTION RetrieveCltSrc
    protected void RetrieveCltSrc(object sender, EventArgs e)
    {
        string strGCN = ((System.Web.UI.WebControls.Button)(sender)).Text;
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();

        RetrieveClt(strGCN, strCarrierCode);
        RetrieveCltCnct(strGCN, strCarrierCode);
        RetrieveCltPer(strGCN);
        txtGCN_OnTextChanged(sender, e);
    }
    #endregion

    #region FUNCTION RetrievePopClt
    protected void RetrievePopClt(object sender, EventArgs e)
    {
        Response.Redirect("Clt.aspx?ENQ=0&FLAGFIND=1&GCN=" + txtGCN.Text);
    }
    #endregion

    #region DATASET RetrieveCltDtl
    private DataSet RetrieveCltDtl(string strGCN)
    {
        /*  StoreProcedureName: prc_CSS_AgentEnquiry_AgtHistoryEnq
         *  Columns:
         *  @GCN varchar(12) 
        */
        StringBuilder strSQL = new StringBuilder();

        Provider o = new Provider();
        string strDBName = "INSCCommonConnectionString";
        string strSQL2 = string.Empty;
        DataSet ds = new DataSet();

        strSQL.Append("EXEC prc_Clt_Search_CltDtl ");
        strSQL.Append("'" + strGCN + "'");

        strSQL2 = strSQL.ToString();

        ds = o.ReadData(strDBName, strSQL2);
        return ds;
    }
    #endregion

    #region DATASET CltDataSet
    private DataSet CltDataSet()
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        // ********* Reset Dataset, Datatable and Datarow *********
        dsClt = new DataSet();
        dtClt = new DataTable("Clt");
        dtCltCnct = new DataTable("CltCnct");
        dtCltPer = new DataTable("CltPer");

        DataRow drClt = dtClt.NewRow();
        DataRow drCltAddr = dtCltCnct.NewRow();
        DataRow drCltPer = dtCltPer.NewRow();

        // *********************************** Table Clt ***********************************
        if (dtClt.Columns.Count == 0)
        {
            dtClt.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Title", System.Type.GetType("System.String"));
            dtClt.Columns.Add("GivenName", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Surname", System.Type.GetType("System.String"));
            dtClt.Columns.Add("BirthRegDate", System.Type.GetType("System.DateTime"));
            dtClt.Columns.Add("Gender", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CurrentID", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CurrentIDType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AltID", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AltIDType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("MaritalStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("AnniversaryDate", System.Type.GetType("System.DateTime"));
            dtClt.Columns.Add("Nationality", System.Type.GetType("System.String"));
            dtClt.Columns.Add("NationalityDesc", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Category1", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Category2", System.Type.GetType("System.String"));
            dtClt.Columns.Add("SpecInd1", System.Type.GetType("System.String"));
            dtClt.Columns.Add("SpecInd2", System.Type.GetType("System.String"));
            dtClt.Columns.Add("QualCode", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DefCnctType", System.Type.GetType("System.String"));
            dtClt.Columns.Add("HomeTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("MobileTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("WorkTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Email", System.Type.GetType("System.String"));
            dtClt.Columns.Add("OcpnCode01", System.Type.GetType("System.String"));
            dtClt.Columns.Add("PrivacyStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DstbnMethod", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Income", System.Type.GetType("System.Double"));
            dtClt.Columns.Add("CreateBy", System.Type.GetType("System.String"));
            dtClt.Columns.Add("PrfStat", System.Type.GetType("System.Int32"));
            dtClt.Columns.Add("TaxStat", System.Type.GetType("System.String"));
            dtClt.Columns.Add("WorkFax", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Remark", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Staff", System.Type.GetType("System.Boolean"));
            dtClt.Columns.Add("ParentName", System.Type.GetType("System.String"));
            dtClt.Columns.Add("SOE", System.Type.GetType("System.String"));
            dtClt.Columns.Add("InceptionDate", System.Type.GetType("System.DateTime"));
            dtClt.Columns.Add("PermAdrInd", System.Type.GetType("System.String"));
            dtClt.Columns.Add("Pager", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DidTel", System.Type.GetType("System.String"));
            dtClt.Columns.Add("DrMailInd", System.Type.GetType("System.String"));
            dtClt.Columns.Add("CltCrRul", System.Type.GetType("System.String"));
			//For Gender and DOB
            dtClt.Columns.Add("IncorpDate", System.Type.GetType("System.DateTime"));
            //For Gender and DOB End
        }
        if (hdnDupFlag.Value == "DUPCLT")
        {
            drClt["GCN"] = hdnTempClientCode.Value;
        }
        else
        {
            drClt["GCN"] = this.txtGCN.Text;
        }
        drClt["Title"] = this.cboTitle.SelectedValue;
        drClt["GivenName"] = this.txtGivenName.Text;
        drClt["Surname"] = this.txtname.Text;
        drClt["ParentName"] = this.txtSurname.Text;
        drClt["SOE"] = ddlSOE.SelectedValue;
        if (this.txtIndate.Text != String.Empty)
        {
            drClt["Inceptiondate"] = this.txtIndate.Text;
        }
        drClt["PermAdrInd"] = this.ChkPA.Checked.ToString();
        drClt["Pager"] = this.txtPager.Text;
        drClt["DidTel"] = this.txtDidtel.Text;
        drClt["DrMailInd"] = this.ChkDrml.Checked.ToString();
        if (this.txtDOB.Text != String.Empty)
            drClt["BirthRegDate"] = this.txtDOB.Text;
        if (this.cboGender.SelectedValue != string.Empty)
            drClt["Gender"] = this.cboGender.SelectedValue;
        else
            drClt["Gender"] = "U";
        if (this.txtCurrentID.Text != string.Empty)
            //For not updating PAN
            //drClt["CurrentID"] = this.txtCurrentID.Text;
            drClt["CurrentID"] = null;
            //For inserting PAN into EasyCRM Table
        else
            drClt["CurrentID"] = null;
        drClt["CurrentIDType"] = "P";
        drClt["AltID"] = this.txtOthersID.Text;
        drClt["AltIDType"] = this.cboOtherIDType.SelectedValue;
        drClt["MaritalStat"] = this.cboMaritalStatus.SelectedValue;
        
        drClt["AnniversaryDate"] = System.DBNull.Value;
        
        drClt["Nationality"] = this.txtNationalCode.Text;
        drClt["NationalityDesc"] = this.txtNationalDesc.Text;
        drClt["Category" + Session["CarrierCode"].ToString()] = ddlCategory.SelectedValue;
        drClt["SpecInd" + Session["CarrierCode"].ToString()] = ddlSpecInd.SelectedValue;
        drClt["QualCode"] = this.cboQualCode.SelectedValue;
        drClt["DefCnctType"] = strCnctType.ToString();
        drClt["HomeTel"] = this.txtHomeTel.Text;
        drClt["MobileTel"] = this.txtMobileTel.Text;
        drClt["WorkTel"] = this.txtWorkTel.Text;
        drClt["Email"] = this.txtEmail.Text;
        drClt["OcpnCode01"] = this.txtOccupationCode.Text;
        drClt["PrivacyStat"] = this.ddlPrivacy.SelectedValue;
        drClt["DstbnMethod"] = this.ddlDstbnMethod.SelectedValue;
        if (this.txtALIncome.Text != String.Empty)
            drClt["Income"] = Double.Parse(this.txtALIncome.Text).ToString();
        drClt["CreateBy"] = strUserGCN;
        drClt["PrfStat"] = (chkVip.Checked ? 90 : 50);
        drClt["TaxStat"] = chkSalesTax.Checked.ToString();
        drClt["Remark"] = Menu1.Text.Trim();
        drClt["Staff"] = chkStaff.Checked;
        drClt["CltCrRul"] = ddlCltCreateRule.SelectedValue;
		drClt["IncorpDate"] = System.DBNull.Value;
        dtClt.Rows.Add(drClt);

        // *********************************** Table CltCnct ***********************************
        if (dtCltCnct.Columns.Count == 0)
        {
            dtCltCnct.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CnctType", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr1", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr2", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr3", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Adr4", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("City", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Postcode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Statecode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("Cntrycode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("CreateBy", System.Type.GetType("System.String"));

            dtCltCnct.Columns.Add("PermAddrCnctType", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrAdr1", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrAdr2", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrAdr3", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrPostcode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrStatecode", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermAddrCntrycode", System.Type.GetType("System.String"));
            
            dtCltCnct.Columns.Add("District", System.Type.GetType("System.String"));
            dtCltCnct.Columns.Add("PermDistrict", System.Type.GetType("System.String"));
        }

        if (cboCnctType.SelectedValue.Equals("P1"))
        {
            drCltAddr = dtCltCnct.NewRow();
            drCltAddr["GCN"] = txtGCN.Text.Trim();
            drCltAddr["CnctType"] = "P1";
            drCltAddr["Adr1"] = this.txtAddrP1.Text.Trim();
            drCltAddr["Adr2"] = this.txtAddrP2.Text.Trim();
            drCltAddr["Adr3"] = this.txtAddrP3.Text.Trim();
            drCltAddr["Adr4"] = this.txtAddrP4.Text.Trim();
            drCltAddr["City"] = "";
            drCltAddr["Postcode"] = this.txtPinP.Text.Trim();
            drCltAddr["Statecode"] = this.txtStateCodeP.Text.Trim();
            drCltAddr["Cntrycode"] = this.txtCountryCodeP.Text.Trim();
            drCltAddr["CreateBy"] = strUserGCN.Trim();
            drCltAddr["District"] = txtDistricP.Text;
            if (ChkPA.Checked)
            {
                drCltAddr["PermAddrCnctType"] = "M1";
                drCltAddr["PermAddrAdr1"] = this.txtAddrP1.Text.Trim();
                drCltAddr["PermAddrAdr2"] = this.txtAddrP2.Text.Trim();
                drCltAddr["PermAddrAdr3"] = this.txtAddrP3.Text.Trim();
                drCltAddr["PermAddrPostcode"] = this.txtPinP.Text.Trim();
                drCltAddr["PermAddrStatecode"] = this.txtStateCodeP.Text.Trim();
                drCltAddr["PermAddrCntrycode"] = this.txtCountryCodeP.Text.Trim();
                drCltAddr["PermDistrict"] = txtDistricP.Text;
            }
            else
            {
                drCltAddr["PermAddrCnctType"] = "M1";
                drCltAddr["PermAddrAdr1"] = this.txtAdd1.Text.Trim();
                drCltAddr["PermAddrAdr2"] = this.txtAdd2.Text.Trim();
                drCltAddr["PermAddrAdr3"] = this.txtAdd3.Text.Trim();
                drCltAddr["PermAddrPostcode"] = this.txtPostcode.Text.Trim();
                drCltAddr["PermAddrStatecode"] = this.txtStateCode.Text.Trim();
                drCltAddr["PermAddrCntrycode"] = this.txtCountryCode.Text.Trim();
                drCltAddr["PermDistrict"] = txtDistric.Text;
            }
            
            dtCltCnct.Rows.Add(drCltAddr);
        }

        if (cboCnctType.SelectedValue.Equals("B1"))
        {
            drCltAddr = dtCltCnct.NewRow();
            drCltAddr["GCN"] = txtGCN.Text.Trim();
            drCltAddr["CnctType"] = "B1";
            drCltAddr["Adr1"] = this.txtAddrB1.Text.Trim();
            drCltAddr["Adr2"] = this.txtAddrB2.Text.Trim();
            drCltAddr["Adr3"] = this.txtAddrB3.Text.Trim();
            drCltAddr["Adr4"] = this.txtAddrB4.Text.Trim();
            drCltAddr["City"] = "";

            drCltAddr["Postcode"] = this.txtPinB.Text.Trim();
            drCltAddr["Statecode"] = this.txtStateCodeB.Text.Trim();
            drCltAddr["Cntrycode"] = this.txtCountryCodeB.Text.Trim();
            drCltAddr["CreateBy"] = strUserGCN.Trim();
            if (ChkPA.Checked)
            {
                drCltAddr["PermAddrCnctType"] = "M1";
                drCltAddr["PermAddrAdr1"] = this.txtAddrB1.Text.Trim();
                drCltAddr["PermAddrAdr2"] = this.txtAddrB2.Text.Trim();
                drCltAddr["PermAddrAdr3"] = this.txtAddrB3.Text.Trim();
                drCltAddr["PermAddrPostcode"] = this.txtPinB.Text.Trim();
                drCltAddr["PermAddrStatecode"] = this.txtStateCodeB.Text.Trim();
                drCltAddr["PermAddrCntrycode"] = this.txtCountryCodeB.Text.Trim();
                drCltAddr["PermDistrict"] = txtDistrictB.Text;
            }
            else
            {
                drCltAddr["PermAddrCnctType"] = "M1";
                drCltAddr["PermAddrAdr1"] = this.txtAdd1.Text.Trim();
                drCltAddr["PermAddrAdr2"] = this.txtAdd2.Text.Trim();
                drCltAddr["PermAddrAdr3"] = this.txtAdd3.Text.Trim();
                drCltAddr["PermAddrPostcode"] = this.txtPostcode.Text.Trim();
                drCltAddr["PermAddrStatecode"] = this.txtStateCode.Text.Trim();
                drCltAddr["PermAddrCntrycode"] = this.txtCountryCode.Text.Trim();
                drCltAddr["PermDistrict"] = txtDistric.Text;
            }
           
            dtCltCnct.Rows.Add(drCltAddr);
        }

        // *********************************** Multiple Address ***********************************
        int intContactType = 0;
        intContactType = 2;
        // *********************************** P - Residential Address ***********************************

        foreach (Control oControl in plcAddressP.Controls)
        {
            Application_Common_ClientAddress oAddrR = (Application_Common_ClientAddress)oControl;
            if (oAddrR.Value_Address1 != String.Empty)
            {
                DataRow drCltCnct = dtCltCnct.NewRow();
                drCltCnct["GCN"] = txtGCN.Text.Trim();
                if (intContactType == 10)
                    drCltCnct["CnctType"] = "P0";
                else
                    drCltCnct["CnctType"] = "P" + intContactType.ToString();
                drCltCnct["Adr1"] = fncFormatAddress(oAddrR.Value_Address1.Trim());
                drCltCnct["Adr2"] = fncFormatAddress(oAddrR.Value_Address2.Trim());
                drCltCnct["Adr3"] = fncFormatAddress(oAddrR.Value_Address3.Trim());
                drCltCnct["Adr4"] = fncFormatAddress(oAddrR.Value_Address4.Trim());
                drCltCnct["City"] = oAddrR.Value_City.Trim();
                drCltCnct["Postcode"] = oAddrR.Value_Postcode.Trim();
                drCltCnct["Statecode"] = oAddrR.Value_State.Trim();
                drCltCnct["Cntrycode"] = oAddrR.Value_Country.Trim();
                drCltCnct["CreateBy"] = strUserGCN.Trim();
                drCltCnct["District"] = oAddrR.Value_District.Trim();
                dtCltCnct.Rows.Add(drCltCnct);
                drCltCnct = null;
            }
            intContactType++;
            oAddrR = null;
        }

        // *********************************** B - Business Address ***********************************
        intContactType = 2;
        foreach (Control oControl in plcAddressB.Controls)
        {
            Application_Common_ClientAddress oAddrB = (Application_Common_ClientAddress)oControl;
            if (oAddrB.Value_Address1 != String.Empty)
            {
                DataRow drCltCnct = dtCltCnct.NewRow();
                drCltCnct["GCN"] = txtGCN.Text.Trim();
                if (intContactType == 10)
                    drCltCnct["CnctType"] = "B0";
                else
                    drCltCnct["CnctType"] = "B" + intContactType.ToString();
                drCltCnct["Adr1"] = fncFormatAddress(oAddrB.Value_Address1.Trim());
                drCltCnct["Adr2"] = fncFormatAddress(oAddrB.Value_Address2.Trim());
                drCltCnct["Adr3"] = fncFormatAddress(oAddrB.Value_Address3.Trim());
                drCltCnct["Adr4"] = fncFormatAddress(oAddrB.Value_Address4.Trim());
                drCltCnct["City"] = oAddrB.Value_City.Trim();
                drCltCnct["Postcode"] = oAddrB.Value_Postcode.Trim();
                drCltCnct["Statecode"] = oAddrB.Value_State.Trim();
                drCltCnct["Cntrycode"] = oAddrB.Value_Country.Trim();
                drCltCnct["CreateBy"] = strUserGCN.Trim();
                drCltCnct["District"] = oAddrB.Value_District.Trim();
                dtCltCnct.Rows.Add(drCltCnct);
                drCltCnct = null;
            }
            intContactType++;
            oAddrB = null;
        }

        // *********************************** Table CltPer ***********************************
        Application_Common_ClientAML oAML = btnAML; 

        if (dtCltPer.Columns.Count == 0)
        {
            dtCltPer.Columns.Add("GCN", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("Height", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("Weight", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ChgWghtReason", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofAgeDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofAddrDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("PermProofAddrDoc", System.Type.GetType("System.String"));	
            dtCltPer.Columns.Add("ProofIncomeDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("ProofIDDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdIssueAuth", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdNo", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("IdIssueDate", System.Type.GetType("System.DateTime"));
            dtCltPer.Columns.Add("HasPhoto", System.Type.GetType("System.Boolean"));
            dtCltPer.Columns.Add("ProofPhotoDoc", System.Type.GetType("System.String"));
            dtCltPer.Columns.Add("RiskIndicator", System.Type.GetType("System.String"));
        }

        drCltPer = dtCltPer.NewRow();
        drCltPer["GCN"] = txtGCN.Text.Trim();
        drCltPer["Height"] = txtHeight1.Text.Trim();
        drCltPer["Weight"] = txtWeight.Text.Trim();
        drCltPer["ChgWghtReason"] = oAML.Value_ChgWghtReason.Trim();
        drCltPer["ProofAgeDoc"] = "";
        drCltPer["ProofAddrDoc"] = oAML.Value_ProofAddr.Trim();
        drCltPer["PermProofAddrDoc"] = oAML.Value_PermProofAddr.Trim();	
        drCltPer["ProofIncomeDoc"] = oAML.Value_ProofIncome.Trim();
        drCltPer["ProofIDDoc"] = oAML.Value_ProofID.Trim();
        drCltPer["IdIssueAuth"] = oAML.Value_IdIssueAuth.Trim();
        drCltPer["IdNo"] = oAML.Value_IDNo.Trim();
        drCltPer["RiskIndicator"] = oAML.Value_RiskInd.Trim();
        if (oAML.Value_IdIssueDate.Trim() != string.Empty)
            drCltPer["IdIssueDate"] = Convert.ToDateTime(oAML.Value_IdIssueDate.Trim()).ToString("dd/MM/yyyy");
        if (oAML.Value_chkPhoto.Trim() != string.Empty)
        {
            if (oAML.Value_chkPhoto.Trim() == "true")
                drCltPer["HasPhoto"] = Convert.ToBoolean(true);
            else
                drCltPer["HasPhoto"] = Convert.ToBoolean(false);

        }
        drCltPer["ProofPhotoDoc"] = "";
        dtCltPer.Rows.Add(drCltPer);

        HttpContext.Current.Session["dtCltCnct"] = dtCltCnct;

        // *********************************** Update DataSet ***********************************
        dsClt.Tables.Add(dtClt.Copy());
        dsClt.Tables.Add(dtCltCnct.Copy());
        dsClt.Tables.Add(dtCltPer.Copy());

        return dsClt;
    }
    #endregion

    #region BUTTON btnCancel click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to cancel ?", "AA", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
        if (result == System.Windows.Forms.DialogResult.Yes)
        {
            Response.Redirect("Clt.aspx");
        }
    }
    #endregion

    #region BUTTON btnSave Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["SaveFlag"] = "1";
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();
        string strPan = txtCurrentID.Text;
        clsChannelSetup objChnSetup = new clsChannelSetup();
        dsClt = new DataSet();
        dsClt = CltDataSet();
		if (txtGCN.Text == string.Empty)
        {
        if (ddlChannels.SelectedValue == "CD")
        {
            if (txtCurrentID.Text == "")
            {
				//commented For PAN updation

                //lblErrMsg.Text = "Please enter PAN number";
                //lblErrMsg.Visible = true;
                //return;

                //commented For PAN updation end
            }
            else
            {
                if (txtCurrentID.Text != "" && btnVerifyPAN.Enabled==true)
                {
                    if (hdnPan.Value != "1")
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "Please verify PAN";
                        return;
                    }
                }
            }
		
            //For making qualification detail mandatory for cda
            if (cboQualCode.SelectedValue == "")
            {
                lblErrMsg.Text = "Please fill Qualification Detail";
                lblErrMsg.Visible = true;
                return;
            }
            
        }
		}
        //For making home tele details mandatory for cda 
        if (ddlChannels.SelectedValue != "CD" && txtHomeTel.Text == "")
        {
            lblErrMsg.Text = "Please provide home phone No.";
            lblErrMsg.Visible = true;
            return;
        }
        
        // *********************************** Call MQ ***********************************
        if (txtGCN.Text != string.Empty)
        {
            try
            {
                #region "CltCreateRule = BC"
                if (ddlCltCreateRule.SelectedValue == "BC")
                {
                    #region Validate GCN whether exist or not as a client?
                    //For Checking Cnd, it exists or not as a Client
                    DataSet dsRes = new DataSet();
                    Hashtable newhtParam = new Hashtable();
                    newhtParam.Add("@GCN", txtGCN.Text.Trim());
                    newhtParam.Add("@GivenName", txtGivenName.Text.Trim());
                    newhtParam.Add("@Surname", txtname.Text.Trim());
                    newhtParam.Add("@Gender", cboGender.SelectedValue.Trim());
                    newhtParam.Add("@BirthRegDate", DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyy/MM/dd"));

                    dsRes = objDAL.GetDataSetForPrc("Prc_CheckGCNExistorNot", newhtParam);
                    if (dsRes.Tables.Count > 0)
                    {
                        if (dsRes.Tables[0].Rows.Count > 0)
                        {
                            lblErrMsg.Text = dsRes.Tables[0].Rows[0]["Message"].ToString().Trim();
                            lblErrMsg.Visible = true;
                            btnSave.Enabled = false;
                            return;
                        }
                    }
                    #endregion

                    this.CreateXML();
                    intStatusCode = oMQCltMgr.SaveClient(2, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
                    #region "intStatusCode=0"
                    if (intStatusCode == 0)
                    {
                        Application_Common_ClientAML oAML = btnAML;

                        string strStatus = "";
                        DataTable dtClt = dsClt.Tables["Clt"];
                        string strClientCode = string.Empty;
                        Insc.MQ.Life.CltMd.MQCltMd objClientMd = new Insc.MQ.Life.CltMd.MQCltMd();
                        Insc.MQ.Life.CltMd.MQCltMdMgr objClientMdMgr = new Insc.MQ.Life.CltMd.MQCltMdMgr();

                        Insc.MQ.Common.Client.MQClient oClient = new Insc.MQ.Common.Client.MQClient();
                        Insc.MQ.Common.Client.MQClientMgr oClientMgr = new Insc.MQ.Common.Client.MQClientMgr();

                        string Name = "";
                        if (txtGivenName.Text != "")
                        {
                            Name = txtGivenName.Text + " " + txtname.Text;
                        }
                        else
                        {
                            Name = txtname.Text;
                        }
                        string strPerDOB = txtDOB.Text;
                        DataSet dsClient = new DataSet();
                        dsClient = oClientMgr.GetPersonalCltStatus(Name, txtGCN.Text, strCltType, cboGender.SelectedValue.ToString(), strPerDOB);
                        #region "personalClientCount>0"
                        if (dsClient.Tables.Count > 0)
                        {
                            strStatus = dsClient.Tables[0].Rows[0][0].ToString();

                            char[] splitter = { '/' };
                            string[] strDOB = txtDOB.Text.Split(splitter);
                            string[] str_IssueDate = oAML.Value_IdIssueDate.ToString().Split(splitter);

                            if (hdnDupFlag.Value == "DUPCLT" || strStatus == "A")
                            {
                                string[] strArrParam = new string[65];
                                if (hdnDupFlag.Value == "DUPCLT")
                                {
                                    strArrParam[0] = hdnClientCode.Value;
                                }
                                else
                                {
                                    strArrParam[0] = txtCltCode.Text;
                                }
                                strArrParam[1] = "";
                                if (cboCnctType.SelectedValue.Equals("P1"))
                                {
                                    strArrParam[2] = "Y";
                                }
                                else
                                {
                                    strArrParam[2] = "N";
                                }
                                strArrParam[3] = cboCnctType.SelectedValue;
                                if (strArrParam[2] == "Y")
                                {
                                    if (ChkPA.Checked)
                                    {
                                        strArrParam[4] = txtAddrP1.Text;
                                        strArrParam[5] = txtAddrP2.Text;
                                        strArrParam[6] = txtAddrP3.Text;
                                        strArrParam[7] = txtStateDescP.Text;
                                        strArrParam[14] = txtPinP.Text;
                                        strArrParam[18] = txtCountryCodeP.Text;
                                        strArrParam[26] = txtCountryCodeP.Text;

                                        strArrParam[58] = txtAddrP1.Text;
                                        strArrParam[59] = txtAddrP2.Text;
                                        strArrParam[60] = txtAddrP3.Text;
                                        strArrParam[61] = txtStateDescP.Text;
                                        strArrParam[62] = txtPinP.Text;
                                        strArrParam[63] = txtCountryCodeP.Text;
                                    }
                                    else
                                    {
                                        strArrParam[4] = txtAdd1.Text;
                                        strArrParam[5] = txtAdd2.Text;
                                        strArrParam[6] = txtAdd3.Text;
                                        strArrParam[7] = txtStateDescP.Text;
                                        strArrParam[14] = txtPinP.Text;
                                        strArrParam[18] = txtCountryCodeP.Text;
                                        strArrParam[26] = txtCountryCodeP.Text;

                                        strArrParam[58] = txtAdd1.Text;
                                        strArrParam[59] = txtAdd2.Text;
                                        strArrParam[60] = txtAdd3.Text;
                                        strArrParam[61] = txtStateDesc.Text.ToUpper();
                                        strArrParam[62] = txtPostcode.Text;
                                        strArrParam[63] = txtCountryCode.Text;
                                    }
                                }
                                else
                                {
                                    if (ChkPA.Checked)
                                    {
                                        strArrParam[4] = txtAddrB1.Text;
                                        strArrParam[5] = txtAddrB2.Text;
                                        strArrParam[6] = txtAddrB3.Text;
                                        strArrParam[7] = txtStateDescB.Text;
                                        strArrParam[14] = txtPinB.Text;
                                        strArrParam[18] = txtCountryCodeB.Text;
                                        strArrParam[26] = txtCountryCodeB.Text;

                                        strArrParam[58] = txtAddrB1.Text;
                                        strArrParam[59] = txtAddrB2.Text;
                                        strArrParam[60] = txtAddrB3.Text;
                                        strArrParam[61] = txtStateDescB.Text;
                                        strArrParam[62] = txtPinB.Text;
                                        strArrParam[63] = txtCountryCodeB.Text;
                                    }
                                    else
                                    {
                                        strArrParam[4] = txtAddrB1.Text;
                                        strArrParam[5] = txtAddrB2.Text;
                                        strArrParam[6] = txtAddrB3.Text;
                                        strArrParam[7] = txtStateDescB.Text;
                                        strArrParam[14] = txtPinB.Text;
                                        strArrParam[18] = txtCountryCodeB.Text;
                                        strArrParam[26] = txtCountryCodeB.Text;

                                        strArrParam[58] = txtAdd1.Text;
                                        strArrParam[59] = txtAdd2.Text;
                                        strArrParam[60] = txtAdd3.Text;
                                        strArrParam[61] = txtStateDesc.Text.ToUpper();
                                        strArrParam[62] = txtPostcode.Text;
                                        strArrParam[63] = txtCountryCode.Text;
                                    }
                                }
                                strArrParam[8] = strDOB[2];     //Date Of Birth - Year
                                strArrParam[9] = strDOB[1];     //Date Of Birth - Month
                                strArrParam[10] = strDOB[0];    //Date Of Birth - Day

                                strArrParam[11] = "";   //Date Of Death - Year
                                strArrParam[12] = "";   //Date Of Death - Month
                                strArrParam[13] = "";   //Date Of Death - Day
                                strArrParam[15] = txtHomeTel.Text;
                                strArrParam[16] = txtWorkTel.Text;
                                strArrParam[17] = cboGender.SelectedValue;
                                if (ChkDrml.Checked)
                                {
                                    strArrParam[19] = "Y";
                                }
                                else
                                {
                                    strArrParam[19] = "N";
                                }
                                strArrParam[20] = "";   //@DOCNUM
                                strArrParam[21] = txtSurname.Text;
                                strArrParam[22] = "";   //@CLTGIVENNAME
                                if (txtGivenName.Text.Trim() != "")
                                {
                                    strArrParam[23] = txtGivenName.Text + " " + txtname.Text;
                                }
                                else
                                {
                                    strArrParam[23] = txtname.Text;
                                }
                                strArrParam[24] = "";   //@MAILIND
                                strArrParam[25] = cboMaritalStatus.SelectedValue;
                                strArrParam[27] = "1";  //@NAMEFORMAT
                                strArrParam[28] = txtOccupationCode.Text;
                                strArrParam[29] = cboTitle.SelectedValue;
                                strArrParam[30] = "";   //@CLTSECIDNO
                                strArrParam[31] = "10"; //@CLTSERBRANCH
                                strArrParam[32] = ddlSOE.SelectedValue;
                                if (ddlCategory.SelectedIndex == 0)
                                {
                                    strArrParam[33] = "";
                                }
                                else
                                {
                                    strArrParam[33] = ddlCategory.SelectedValue;   //@CLTSTATCODE
                                }

                                strArrParam[34] = (chkVip.Checked == true) ? "Y" : "N";   //@VIPIND
                                strArrParam[35] = "N";  //@CMPNYDOCIND
                                strArrParam[36] = cboQualCode.SelectedValue;   //@EDUCODE

                                strArrParam[37] = "";   //@FAXNO
                                strArrParam[38] = "";   //@OLDIDNO
                                strArrParam[39] = "";   //@DIDTELNO
                                strArrParam[40] = txtEmail.Text.Trim();   //@INTERNETADD
                                strArrParam[41] = txtMobileTel.Text;
                                strArrParam[42] = "";   //@PAGERNO
                                strArrParam[43] = (chkStaff.Checked == true) ? "Y" : "N";   //@STAFFFLAG
                                ////added & commented For ECRM Pan Updation
                                //strArrParam[44] = ""; 
                                //Added For PAN Updation 3.3.2012
                                strArrParam[44] = txtCurrentID.Text;
                                //strArrParam[44] = "";
                                //Added For PAN Updation 3.3.2012 end
                                strArrParam[45] = "";
                                strArrParam[46] = oAML.Value_ProofAddr.ToString();
                                strArrParam[47] = oAML.Value_RiskInd.ToString();
                                strArrParam[48] = oAML.Value_ProofID.ToString();

                                if (str_IssueDate[0].Equals(""))
                                {
                                    strArrParam[49] = "";
                                    strArrParam[50] = "";
                                    strArrParam[51] = "";
                                }
                                else
                                {
                                    strArrParam[49] = str_IssueDate[2].ToString();
                                    strArrParam[50] = str_IssueDate[1].ToString();
                                    strArrParam[51] = str_IssueDate[0].ToString();
                                }
                                strArrParam[52] = oAML.Value_IDNo.ToString();
                                strArrParam[53] = oAML.Value_ProofIncome.ToString();
                                strArrParam[54] = oAML.Value_IdIssueAuth.ToString();
                                strArrParam[55] = Convert.ToString(oAML.Value_PermProofAddr);	//@CLTPERMADDPROOF

                                if (oAML.Value_chkPhoto.ToString().ToLower() == "true")
                                {
                                    strArrParam[56] = "Y";
                                }
                                else
                                {
                                    strArrParam[56] = "N";
                                }
                                //strArrParam[56] = "Y";
                                strArrParam[57] = oAML.Value_ChgWghtReason.ToString();   //@CHANGEREASONCODE
                                strArrParam[64] = Convert.ToString(Session["CarrierCode"]);

                                string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
                                //added by swapnesh on 13/05/2013 For getting intStatusCode value start
                                //to be uncommented
                                //intStatusCode = objClientMdMgr.FetchClientModificationDetailsFromLA(strArrParam, strCarrierCode, ref objClientMd, ref strErrMsg);
                                //Added by rachana on 10-07-2013 to enable MQ related code start
                                if (strCallType == "1")
                                {

                                    intStatusCode = objClientMdMgr.FetchClientModificationDetailsFromLA(strArrParam, strCarrierCode, ref objClientMd, ref strErrMsg);
                                }
                                else
                                {
                                    intStatusCode = 0;
                                }
                                //Added by rachana on 10-07-2013 to enable MQ related code start
                                //added by swapnesh on 13/05/2013 For getting intStatusCode value end

                                if (intStatusCode == 0)
                                {
                                    strClientCode = objClientMd.strCLTMDNUM;
                                    int intRowsAffected = 0;

                                    intRowsAffected = oClientMgr.UpdateClientCode(strGCN, strCarrierCode, strGCN);
                                    intRowsAffected = oClientMgr.UpdateClientCode(strGCN, strCarrierCode, strDefCnctType, strGCN);

                                    if (hdnDupFlag.Value == "DUPCLT")
                                    {
                                        //For updating duplicate client code to temp client code in INSC
                                        oClientMgr.UpdateDupCltDtls(hdnClientCode.Value, hdnTempClientCode.Value, Session["CarrierCode"].ToString(), "A");
                                        oClientMgr.UpdateCltStatus(hdnClientCode.Value);
                                        oClientMgr.UpdateCltGCNINAGN(hdnClientCode.Value, Name, hdnClientCode.Value);
                                    }
                                    oClientMgr.UpdateCltNameInAgn(Name, strClientCode);
                                    lblErrMsg.Text = "Client Updated Sucessfully.";
                                    lblErrMsg.Visible = true;
                                    btnSave.Enabled = false;
                                    //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                    //to be uncommented
                                    //changed by rachana on 10-07-2013 to enable MQ code start
                                    if (strCallType == "1")
                                    {
                                        Session["GCN"] = objClientMd.strCLTMDNUM;
                                        txtGCN.Text = objClientMd.strCLTMDNUM;
                                        txtCltCode.Text = objClientMd.strCLTMDNUM;
                                    }
                                    else
                                    {
                                        txtGCN.Text = strGCN;
                                        txtCltCode.Text = strGCN;
                                    }//changed by rachana on 10-07-2013 to enable MQ code end
                                    //added by swapnesh on 13/05/2013 For setting txtGCN value end
                                    if (ViewState["CNDID"] != null)
                                    {
                                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htParam.Add("@GCN", txtGCN.Text);
                                        htParam.Add("@CNDID", ViewState["CNDID"].ToString());
                                        htParam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));

                                        dataAccess.execute_sprcrecruit("dbo.Prc_InsertGCN_CND", htParam);
                                        htParam.Clear();
                                        btnSave.Enabled = false;
                                    }
                                    if (strErrMsg.Length > 0)
                                    {
                                        lblError2.Text = strErrMsg.ToString();
                                        MPEError.Show();
                                    }
                                    else
                                    {
                                        if (strGCN.Length > 0)
                                        {
                                            if (txtGCN.Text.Length > 0)
                                            {
                                                //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start 
                                                lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                                lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                                lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                                mdlpopup.Show();
                                                //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End
                                                btnSave.Enabled = false;
                                            }
                                            else
                                            {
                                                lblError1.Text = "Message";
                                                lblError2.Text = "Client created successfully.";
                                                //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start 
                                                lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                                lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                                lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                                mdlpopup.Show();
                                                //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                                MPEError.Show();
                                                btnSave.Enabled = false;
                                            }
                                        }
                                    }
                                    //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                    //to be uncommented
                                    //Changed by rachana 0n 10-07-2013 to enable MQ related code start
                                    if (strCallType == "1")
                                    {
                                        txtGCN.Text = objClientMd.strCLTMDNUM;
                                    }
                                    else
                                    {
                                        txtGCN.Text = strGCN;
                                        txtCltCode.Text = strGCN;
                                    }
                                    //Changed by rachana 0n 10-07-2013 to enable MQ related code end
                                    //added by swapnesh on 13/05/2013 For setting txtGCN value end
                                }
                                else
                                {
                                    lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
                                    lblErrMsg.Visible = true;
                                    HttpContext.Current.Session["SaveFlag"] = "";
                                    btnSave.Enabled = false;
                                }
                                objClientMd = null;
                                objClientMdMgr = null;
                            }
                            else if (strStatus == "P")
                            {
                                try
                                {

                                    Insc.MQ.Life.CltCr.MQCltCr oClientCr = new Insc.MQ.Life.CltCr.MQCltCr();
                                    Insc.MQ.Life.CltCr.MQCltCrMgr oClientCrMgr = new Insc.MQ.Life.CltCr.MQCltCrMgr();

                                    char[] splitterNew = { '/' };
                                    string[] strDOBNew = txtDOB.Text.Split(splitterNew);
                                    string[] str_IssueDateNew = oAML.Value_IdIssueDate.ToString().Split(splitterNew);

                                    string[] strArrParam = new string[63];
                                    strArrParam[0] = strDOBNew[2];
                                    strArrParam[1] = strDOBNew[1];
                                    strArrParam[2] = strDOBNew[0];
                                    strArrParam[3] = cboGender.SelectedValue.ToString();
                                    if (txtGivenName.Text.Trim() != "")
                                    {
                                        strArrParam[4] = txtGivenName.Text + " " + txtname.Text;    //@CLTNAME
                                    }
                                    else
                                    {
                                        strArrParam[4] = txtname.Text;    //@CLTNAME
                                    }
                                    strArrParam[6] = cboCnctType.SelectedValue.ToString();

                                    if (strArrParam[6].Equals("P1"))
                                    {
                                        if (ChkPA.Checked.Equals(true))
                                        {
                                            strArrParam[5] = "Y";
                                            strArrParam[7] = txtAddrP1.Text;
                                            strArrParam[8] = txtAddrP2.Text;
                                            strArrParam[9] = txtAddrP3.Text;
                                            strArrParam[10] = txtStateDescP.Text;    //@CLTADDLINE4
                                            strArrParam[14] = txtPinP.Text;

                                            strArrParam[56] = txtAddrP1.Text.ToString();
                                            strArrParam[57] = txtAddrP2.Text.ToString();
                                            strArrParam[58] = txtAddrP3.Text.ToString();
                                            strArrParam[59] = txtStateDescP.Text;
                                            strArrParam[60] = txtPinP.Text;
                                            strArrParam[61] = txtCountryCodeP.Text;

                                        }
                                        else
                                        {
                                            strArrParam[5] = "N";

                                            strArrParam[7] = txtAddrP1.Text;
                                            strArrParam[8] = txtAddrP2.Text;
                                            strArrParam[9] = txtAddrP3.Text;
                                            strArrParam[10] = txtStateDescP.Text;    //@CLTADDLINE4
                                            strArrParam[14] = txtPinP.Text;

                                            strArrParam[56] = txtAdd1.Text;
                                            strArrParam[57] = txtAdd2.Text;
                                            strArrParam[58] = txtAdd3.Text;
                                            strArrParam[59] = txtStateDesc.Text.ToUpper();
                                            strArrParam[60] = txtPostcode.Text;
                                            strArrParam[61] = txtCountryCode.Text;
                                        }
                                    }
                                    else
                                    {
                                        if (ChkPA.Checked.Equals(true))
                                        {
                                            strArrParam[5] = "Y";
                                            strArrParam[7] = txtAddrB1.Text;
                                            strArrParam[8] = txtAddrB2.Text;
                                            strArrParam[9] = txtAddrB3.Text;
                                            strArrParam[10] = txtStateDescB.Text;    //@CLTADDLINE4
                                            strArrParam[14] = txtPinB.Text;

                                            strArrParam[56] = txtAddrB1.Text;
                                            strArrParam[57] = txtAddrB2.Text;
                                            strArrParam[58] = txtAddrB3.Text;
                                            strArrParam[59] = txtStateDescB.Text;
                                            strArrParam[60] = txtPinB.Text;
                                            strArrParam[61] = txtCountryCodeB.Text;

                                        }
                                        else
                                        {
                                            strArrParam[5] = "N";
                                            strArrParam[7] = txtAddrB1.Text;
                                            strArrParam[8] = txtAddrB2.Text;
                                            strArrParam[9] = txtAddrB3.Text;
                                            strArrParam[10] = txtStateDescB.Text;    //@CLTADDLINE4
                                            strArrParam[14] = txtPinB.Text;

                                            strArrParam[56] = txtAdd1.Text;
                                            strArrParam[57] = txtAdd2.Text;
                                            strArrParam[58] = txtAdd3.Text;
                                            strArrParam[59] = txtStateDesc.Text.ToUpper();
                                            strArrParam[60] = txtPostcode.Text;
                                            strArrParam[61] = txtCountryCode.Text;

                                        }
                                    }


                                    strArrParam[11] = "";   //@CLTDODYEAR
                                    strArrParam[12] = "";   //@CLTDODMONTH
                                    strArrParam[13] = "";   //@CLTDODDATE

                                    strArrParam[15] = txtHomeTel.Text;
                                    strArrParam[16] = txtWorkTel.Text;
                                    strArrParam[17] = "IND";    //@COUNTRYCODE
                                    strArrParam[18] = "";   //@DIRECTMAININD
                                    strArrParam[19] = "";   //@DOCNUM
                                    strArrParam[20] = txtSurname.Text;      //@CLTFATHERNAME
                                    strArrParam[21] = "";   //@CLTGIVENNAME
                                    strArrParam[22] = "";   //@MAILIND
                                    strArrParam[23] = cboMaritalStatus.SelectedValue;
                                    strArrParam[24] = txtNationalCode.Text;
                                    strArrParam[25] = "1";  //@NAMEFORMAT
                                    strArrParam[26] = txtOccupationCode.Text;
                                    strArrParam[27] = cboTitle.SelectedValue;
                                    strArrParam[28] = "";   //@CLTSECIDNO
                                    strArrParam[29] = "10"; //@CLTSERBRANCH
                                    strArrParam[30] = ddlSOE.SelectedValue;
                                    if (ddlCategory.SelectedIndex == 0)
                                    {
                                        strArrParam[31] = "";   //@CLTSTATCODE
                                    }
                                    else
                                    {
                                        strArrParam[31] = ddlCategory.SelectedValue;
                                    }
                                    strArrParam[32] = (chkVip.Checked == true) ? "Y" : "N";   //@VIPIND
                                    strArrParam[33] = "N";  //Company Doctor
                                    strArrParam[34] = cboQualCode.SelectedValue;   //@EDUCODE
                                    strArrParam[35] = "";   //@FAXNO
                                    strArrParam[36] = "";   //@OLDIDNO
                                    strArrParam[37] = "";   //@DIDTELNO
                                    strArrParam[38] = txtEmail.Text.Trim();   //@INTERNETADD
                                    strArrParam[39] = txtMobileTel.Text;
                                    strArrParam[40] = "";   //@PAGERNO
                                    strArrParam[41] = (chkStaff.Checked == true) ? "Y" : "N";   //@STAFFFLAG
                                    //For PAN No
                                    //strArrParam[42] = txtCurrentID.Text;   //@CLTTAXIDNO
                                    //For PAN No end
                                    strArrParam[42] = "";
                                    strArrParam[43] = "";
                                    strArrParam[44] = oAML.Value_ProofAddr.ToString();
                                    strArrParam[45] = oAML.Value_RiskInd.ToString();
                                    strArrParam[46] = oAML.Value_ProofID.ToString();
                                    if (str_IssueDateNew[0].Equals(""))
                                    {
                                        strArrParam[47] = "2007";
                                        strArrParam[48] = "10";
                                        strArrParam[49] = "01";
                                    }
                                    else
                                    {
                                        strArrParam[47] = str_IssueDateNew[2].ToString();
                                        strArrParam[48] = str_IssueDateNew[1].ToString();
                                        strArrParam[49] = str_IssueDateNew[0].ToString();
                                    }

                                    strArrParam[50] = oAML.Value_IDNo.ToString();   //@IDPROOFNO
                                    strArrParam[51] = oAML.Value_ProofIncome.ToString();
                                    strArrParam[52] = oAML.Value_IdIssueAuth.ToString();
                                    strArrParam[53] = Convert.ToString(oAML.Value_PermProofAddr);	//@CLTPERMADDPROOF
                                    if (oAML.Value_chkPhoto.ToString().ToLower() == "true")
                                    {
                                        strArrParam[54] = "Y";
                                    }
                                    else
                                    {
                                        strArrParam[54] = "N";
                                    }
                                    strArrParam[55] = oAML.Value_ChgWghtReason.ToString();       //@CHANGEREASONCODE
                                    strArrParam[62] = Convert.ToString(Session["CarrierCode"]);

                                    string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
                                    //Added by rachana on 12-07-2013 to enable MQ code start
                                    if (strCallType == "1")
                                    {

                                    }
                                    else
                                    {

                                        intStatusCode = objClientMdMgr.FetchClientModificationDetailsFromLA(strArrParam, strCarrierCode, ref objClientMd, ref strErrMsg);
                                    }
                                    //Added by rachana on 12-07-2013 to enable MQ code end
                                    if (oClientCr.dtClt != null)
                                    {
                                        if (oClientCr.dtClt.Rows.Count > 0)
                                        {
                                            DataTable dtRecords = oClientCr.dtClt;
                                            HttpContext.Current.Session["dtRecords"] = dtRecords;
                                            lblErrMsg.Text = "Duplicate Client Records Found.";
                                            lblErrMsg.Visible = true;
                                            txtGCN.Text = strGCN;
                                            txtCltCode.Text = strGCN;
                                            hdnTempClientCode.Value = strGCN;
                                            hdnDupFlag.Value = "DUPCLT";
                                            txtDupBtnFlag.Text = "";
                                            btnDupCltRecords.Enabled = true;
                                            btnSave.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        if (intStatusCode == 0)
                                        {
                                            strClientCode = oClientCr.strCLTCRNUM;
                                            int intRowsAffected = 0;

                                            intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strClientCode);
                                            intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strDefCnctType, strClientCode, "M1");
                                            oClientMgr.UpdateCltStatus(strClientCode);
                                            oClientMgr.UpdateCltGCNINAGN(strGCN, Name, strClientCode);
                                            lblErrMsg.Text = "Client Updated Sucessfully.";
                                            lblErrMsg.Visible = true;
                                            //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                            //Session["GCN"] = oClientCr.strCLTCRNUM;
                                            //txtGCN.Text = oClientCr.strCLTCRNUM;
                                            txtGCN.Text = strGCN;
                                            //added by swapnesh on 13/05/2013 For setting txtGCN value end
                                            if (hdnDupFlag.Value != "DUPCLT")
                                            {
                                                if (ViewState["CNDID"] != null)
                                                {
                                                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                                    htParam.Add("@GCN", txtGCN.Text);
                                                    htParam.Add("@CNDID", ViewState["CNDID"].ToString());
                                                    htParam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));

                                                    dataAccess.execute_sprcrecruit("dbo.Prc_InsertGCN_CND", htParam);
                                                    htParam.Clear();
                                                    btnSave.Enabled = false;
                                                }
                                            }
                                            if (strErrMsg.Length > 0)
                                            {
                                                lblError2.Text = strErrMsg.ToString();
                                                MPEError.Show();
                                            }
                                            else
                                            {
                                                if (strGCN.Length > 0)
                                                {
                                                    if (txtGCN.Text.Length > 0)
                                                    {
                                                        lblError1.Text = "Message";
                                                        lblError2.Text = "Client updated successfully.";
                                                        //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start 
                                                        lblmsg.Text = "Client updated successfully." + Environment.NewLine;
                                                        lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                                        lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                                        mdlpopup.Show();
                                                        //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                                        MPEError.Show();
                                                        btnSave.Enabled = false;
                                                    }
                                                    else
                                                    {
                                                        lblError1.Text = "Message";
                                                        lblError2.Text = "Client created successfully.";
                                                        //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
                                                        lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                                        lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                                        lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                                        mdlpopup.Show();
                                                        //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                                        MPEError.Show();
                                                        btnSave.Enabled = false;
                                                    }
                                                }
                                            }
                                            //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                            //txtGCN.Text = oClientCr.strCLTCRNUM;
                                            txtGCN.Text = strGCN;
                                            txtCltCode.Text = strGCN;
                                            //added by swapnesh on 13/05/2013 For setting txtGCN value end
                                        }
                                        else
                                        {
                                            lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
                                            lblErrMsg.Visible = true;
                                            HttpContext.Current.Session["SaveFlag"] = "";
                                            btnSave.Enabled = false;
                                        }
                                    }
                                    oClientCr = null;
                                    oClientCr = null;
                                    oClientCrMgr = null;
                                }
                                catch (Exception ex)
                                {
                                    lblErrMsg.Text = "Error Updating Record- " + ex.Message;
                                    lblErrMsg.Visible = true;
                                    HttpContext.Current.Session["SaveFlag"] = "";
                                    btnSave.Enabled = false;
                                }
                                oMQCltMgr = null;
                            }

                        }
                        #endregion
                        else
                        {
                            lblErrMsg.Text = "Error Updating Record In Frontend!";
                            lblErrMsg.Visible = true;
                            HttpContext.Current.Session["SaveFlag"] = "";
                            btnSave.Enabled = false;
                        }
                    }
                    #endregion
                }
                #endregion
                else
                {
                    this.CreateXML();
                    intStatusCode = oMQCltMgr.SaveClient(2, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);

                    if (intStatusCode == 0)
                    {
                        Session["GCN"] = strGCN;
                        txtGCN.Text = strGCN;
                        txtCltCode.Text = strGCN;
                        txtGCN.Text = strGCN;
                        if (strErrMsg.Length > 0)
                        {
                            lblError2.Text = strErrMsg.ToString();
                            MPEError.Show();
                        }
                        else
                        {
                            if (strGCN.Length > 0)
                            {
                                if (txtGCN.Text.Length > 0)
                                {
                                    lblError1.Text = "Message";
                                    lblError2.Text = "Client updated successfully.";
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
                                    lblmsg.Text = "Client updated successfully." + Environment.NewLine;
                                    lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                    lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                    mdlpopup.Show();
                                    // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                    MPEError.Show();
                                    btnSave.Enabled = false;
                                }
                                else
                                {
                                    lblError1.Text = "Message";
                                    lblError2.Text = "Client created successfully.";
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
                                    lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                    lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                    lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                    mdlpopup.Show();
                                    // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                    MPEError.Show();
                                    btnSave.Enabled = false;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Error Updating Record- " + ex.Message;
                lblErrMsg.Visible = true;
                HttpContext.Current.Session["SaveFlag"] = "";
                btnSave.Enabled = false;
            }
            if (lblError2.Text == "Client updated successfully." || lblError2.Text == "Client created successfully.")
            {
                ErrMsg = "S";
            }
            else
            {
                ErrMsg = "E";
            }
            if (txtGCN.Text != string.Empty)
            {
                AuditType = "UP";
            }
            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "", ErrCode = "", ErrDsc = lblErrMsg.Text, ErrDtl = "";
            if (intStatusCode == 0)
            {
                ErrSrc = "SQ";
            }
            else
            {
                ErrSrc = "BO";
            }
            
                objChnSetup.iAuditLog(ErrMsg, AuditType, txtGCN.Text, "Clt", "Clt,MQClientMgr.cs", "prc_Clt_InsUpdDel_Clt", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
                //added start
                if (strCallType == "0")
                {
                    SqlConnection conn = new SqlConnection(sConnStr);
                    string strsql = "insert into clt (GCN,GivenName,Surname,Gender,Title,CltType,CltStat,BirthRegDate,MAritalDesc,HomeTel,MobileTel,Email,Nationality,NationalityDesc,OcpnCode01,OcpnDesc,Name) values('" + txtGCN.Text + "','" + txtGivenName.Text + "','" + txtSurname.Text + "','" + cboGender.SelectedValue + "','" + cboTitle.SelectedValue + "','" + strCltType + "','A','" + DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyy/MM/dd") + "','" + cboMaritalStatus.SelectedValue + "','" + txtHomeTel.Text + "','" + txtMobileTel.Text + "','" + txtEmail.Text + "','" + txtNationalCode.Text + "','" + txtNationalDesc.Text + "','" + txtOccupationCode.Text + "','" + txtOccupationDesc.Text + "','" + txtname.Text + "')";
                    SqlCommand cmdclt = new SqlCommand(strsql, conn);


                    conn.Open();
                    cmdclt.ExecuteNonQuery();
                    conn.Close();

                    string strsql1 = "insert into cltcnct (GCN,CnctType,Adr1,Adr2,Adr3,Adr4,Statecode,PostCode,City) values('" + txtGCN.Text + "','P1','" + txtAddrP1.Text + "','" + txtAddrP2.Text + "','" + txtAddrP3.Text + "','" + txtAddrP4.Text + "','" + txtStateCodeP.Text + "','" + txtPinP.Text + "','" + txtDistricP.Text + "')";
                    SqlCommand cmdcnct = new SqlCommand(strsql1, conn);
                    conn.Open();
                    cmdcnct.ExecuteNonQuery();
                    conn.Close();

                    char[] splitterNew1 = { '/' };
                    string[] strDOBNew1 = txtDOB.Text.Split(splitterNew1);
                    string strdateb = strDOBNew1[2] + strDOBNew1[1] + strDOBNew1[0];
                    string strsql2 = "insert into CltSrch (GCN,SurnameKey,CltType,Gender,HomeTel,WorkTel,DateKey)values ('" + txtGCN.Text + "','" + txtname.Text + "','"
                           + strCltType + "','" + cboGender.SelectedValue + "','" + txtHomeTel.Text + "','" + txtMobileTel.Text + "','" + strDOBNew1.ToString() + "')";
                    SqlCommand cmdcltsrch = new SqlCommand(strsql2, conn);
                    conn.Open();
                    cmdcltsrch.ExecuteNonQuery();
                    conn.Close();


                    string strsql3 = "insert into CltMapExt (GCN,ExtSrc,ExtClientCode,ExtClientStat)values ('" + txtGCN.Text + "','2','" + txtGCN.Text + "','" + strCltType + "')";
                    SqlCommand cmdcltext = new SqlCommand(strsql3, conn);
                    conn.Open();
                    cmdcltext.ExecuteNonQuery();
                    conn.Close();
                    //end

                    //Added by Pranjali on 22-07-2013 for Non-MQ call start
                    string strsql4 = "insert into CltId (id,IdType,IdStat,GCN )values ('" + txtCurrentID.Text + "','P','P','" + txtGCN.Text + "')";
                    //SqlConnection conn = new SqlConnection(sConnStr);
                    SqlCommand cmdcltid = new SqlCommand(strsql4, conn);
                    conn.Open();
                    cmdcltid.ExecuteNonQuery();
                    conn.Close();
                    //txtCltCode.Text = txtGCN.Text;
                    //Added by Pranjali on 22-07-2013 for Non-MQ call End
            }
        }
        else
        {
            try
            {
                if (ddlCltCreateRule.SelectedValue == "BC")
                {
                    htParam.Clear();
                    htParam.Add("@GivenName", txtGivenName.Text);
                    htParam.Add("@Surname", txtname.Text);
                    htParam.Add("@Gender", cboGender.SelectedValue);
                    htParam.Add("@BirthRegDate", txtDOB.Text);
                    objDAL.execute_sprc("Prc_Clt_Match_Client_Delete", htParam);
                    htParam.Clear();
                    //Added by rachana on 28-07-2013 to enable MQ code start
                    if (strCallType == "0")
                    {
                        intStatusCode = oMQCltMgr.SaveClient(0, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
                    }
                    else
                    {

                    }
                    this.CreateXML();
                    if (intStatusCode > 0)
                    {
                        if (intStatusCode == 1)
                        {
                            lblComfirm1.Text = "One MATCH record found.";
                            lblComfirm2.Text = "Do you want to create New or Update?";
                            lblComfirm3.Text = "Click 'Yes' for create New and click 'No' for update Client.";
                            MPEComfirm.Show();
                        }
                        else if (intStatusCode == 2)
                        {
                            lblComfirmM1.Text = "Multiple/Partial MATCH records found.";
                            lblComfirmM2.Text = "Do You want to create New? ";
                            lblComfirmM3.Text = "Click 'Yes' for create New.";
                            MPEComfirmM.Show();
                        }

                        if ((intStatusCode == 1) || (intStatusCode == 2))
                        {
                            ErrMsg_SetFocus();
                        }
                    }
                    if (intStatusCode == 0)
                    {
                        Application_Common_ClientAML oAML = btnAML;
                        DataTable dtClt = dsClt.Tables["Clt"];
                        string strClientCode = string.Empty;

                        Insc.MQ.Common.Client.MQClient oClient = new Insc.MQ.Common.Client.MQClient();
                        Insc.MQ.Common.Client.MQClientMgr oClientMgr = new Insc.MQ.Common.Client.MQClientMgr();
                        Insc.MQ.Life.CltCr.MQCltCr oClientCr = new Insc.MQ.Life.CltCr.MQCltCr();
                        Insc.MQ.Life.CltCr.MQCltCrMgr oClientCrMgr = new Insc.MQ.Life.CltCr.MQCltCrMgr();
                        char[] splitter = { '/' };
                        string[] strDOB = txtDOB.Text.Split(splitter);
                        string[] str_IssueDate = oAML.Value_IdIssueDate.ToString().Split(splitter);
                        string[] strArrParam = new string[63];
                        strArrParam[0] = strDOB[2];
                        strArrParam[1] = strDOB[1];
                        strArrParam[2] = strDOB[0];
                        strArrParam[3] = cboGender.SelectedValue.ToString();
                        if (txtGivenName.Text.Trim() != "")
                        {
                            strArrParam[4] = txtGivenName.Text + " " + txtname.Text;    //@CLTNAME
                        }
                        else
                        {
                            strArrParam[4] = txtname.Text;    //@CLTNAME
                        }
                        strArrParam[6] = cboCnctType.SelectedValue.ToString();

                        if (strArrParam[6].Equals("P1"))
                        {
                            if (ChkPA.Checked.Equals(true))
                            {
                                strArrParam[5] = "Y";
                                strArrParam[7] = txtAddrP1.Text;
                                strArrParam[8] = txtAddrP2.Text;
                                strArrParam[9] = txtAddrP3.Text;
                                strArrParam[10] = txtStateDescP.Text;    //@CLTADDLINE4
                                strArrParam[14] = txtPinP.Text;

                                strArrParam[56] = txtAddrP1.Text.ToString();
                                strArrParam[57] = txtAddrP2.Text.ToString();
                                strArrParam[58] = txtAddrP3.Text.ToString();
                                strArrParam[59] = txtStateDescP.Text;
                                strArrParam[60] = txtPinP.Text;
                                strArrParam[61] = txtCountryCodeP.Text;

                            }
                            else
                            {
                                strArrParam[5] = "N";

                                strArrParam[7] = txtAddrP1.Text;
                                strArrParam[8] = txtAddrP2.Text;
                                strArrParam[9] = txtAddrP3.Text;
                                strArrParam[10] = txtStateDescP.Text;    //@CLTADDLINE4
                                strArrParam[14] = txtPinP.Text;

                                strArrParam[56] = txtAdd1.Text;
                                strArrParam[57] = txtAdd2.Text;
                                strArrParam[58] = txtAdd3.Text;
                                strArrParam[59] = txtStateDesc.Text.ToUpper();
                                strArrParam[60] = txtPostcode.Text;
                                strArrParam[61] = txtCountryCode.Text;
                            }
                        }
                        else
                        {
                            if (ChkPA.Checked.Equals(true))
                            {
                                strArrParam[5] = "Y";
                                strArrParam[7] = txtAddrB1.Text;
                                strArrParam[8] = txtAddrB2.Text;
                                strArrParam[9] = txtAddrB3.Text;
                                strArrParam[10] = txtStateDescB.Text;    //@CLTADDLINE4
                                strArrParam[14] = txtPinB.Text;

                                strArrParam[56] = txtAddrB1.Text;
                                strArrParam[57] = txtAddrB2.Text;
                                strArrParam[58] = txtAddrB3.Text;
                                strArrParam[59] = txtStateDescB.Text;
                                strArrParam[60] = txtPinB.Text;
                                strArrParam[61] = txtCountryCodeB.Text;

                            }
                            else
                            {
                                strArrParam[5] = "N";
                                strArrParam[7] = txtAddrB1.Text;
                                strArrParam[8] = txtAddrB2.Text;
                                strArrParam[9] = txtAddrB3.Text;
                                strArrParam[10] = txtStateDescB.Text;    //@CLTADDLINE4
                                strArrParam[14] = txtPinB.Text;

                                strArrParam[56] = txtAdd1.Text;
                                strArrParam[57] = txtAdd2.Text;
                                strArrParam[58] = txtAdd3.Text;
                                strArrParam[59] = txtStateDesc.Text.ToUpper();
                                strArrParam[60] = txtPostcode.Text;
                                strArrParam[61] = txtCountryCode.Text;

                            }
                        }


                        strArrParam[11] = "";   //@CLTDODYEAR
                        strArrParam[12] = "";   //@CLTDODMONTH
                        strArrParam[13] = "";   //@CLTDODDATE

                        strArrParam[15] = txtHomeTel.Text;
                        strArrParam[16] = txtWorkTel.Text;
                        strArrParam[17] = "IND";    //@COUNTRYCODE
                        strArrParam[18] = "";   //@DIRECTMAININD
                        strArrParam[19] = "";   //@DOCNUM
                        strArrParam[20] = txtSurname.Text;      //@CLTFATHERNAME
                        strArrParam[21] = "";   //@CLTGIVENNAME
                        strArrParam[22] = "";   //@MAILIND
                        strArrParam[23] = cboMaritalStatus.SelectedValue;
                        strArrParam[24] = txtNationalCode.Text;
                        strArrParam[25] = "1";  //@NAMEFORMAT
                        strArrParam[26] = txtOccupationCode.Text;
                        strArrParam[27] = cboTitle.SelectedValue;
                        strArrParam[28] = "";   //@CLTSECIDNO
                        strArrParam[29] = "10"; //@CLTSERBRANCH
                        strArrParam[30] = ddlSOE.SelectedValue;
                        if (ddlCategory.SelectedIndex == 0)
                        {
                            strArrParam[31] = "";   //@CLTSTATCODE
                        }
                        else
                        {
                            strArrParam[31] = ddlCategory.SelectedValue;
                        }
                        strArrParam[32] = (chkVip.Checked == true) ? "Y" : "N";   //@VIPIND
                        strArrParam[33] = "N";  //Company Doctor
                        strArrParam[34] = cboQualCode.SelectedValue;   //@EDUCODE
                        strArrParam[35] = "";   //@FAXNO
                        strArrParam[36] = "";   //@OLDIDNO
                        strArrParam[37] = "";   //@DIDTELNO
                        strArrParam[38] = txtEmail.Text.Trim();   //@INTERNETADD
                        strArrParam[39] = txtMobileTel.Text;
                        strArrParam[40] = "";   //@PAGERNO
                        strArrParam[41] = (chkStaff.Checked == true) ? "Y" : "N";   //@STAFFFLAG
                        //For PAN No
                        //strArrParam[42] = txtCurrentID.Text;   //@CLTTAXIDNO
                        //For PAN No end
                        strArrParam[42] = "";   //@CLTTAXIDNO
                        strArrParam[43] = "";	//ddlSpecInd.SelectedValue.ToString();
                        strArrParam[44] = oAML.Value_ProofAddr.ToString();
                        strArrParam[45] = oAML.Value_RiskInd.ToString();
                        strArrParam[46] = oAML.Value_ProofID.ToString();
                        if (str_IssueDate[0].Equals(""))
                        {
                            strArrParam[47] = "2007";
                            strArrParam[48] = "10";
                            strArrParam[49] = "01";
                        }
                        else
                        {
                            strArrParam[47] = str_IssueDate[2].ToString();
                            strArrParam[48] = str_IssueDate[1].ToString();
                            strArrParam[49] = str_IssueDate[0].ToString();
                        }

                        strArrParam[50] = oAML.Value_IDNo.ToString();   //@IDPROOFNO
                        strArrParam[51] = oAML.Value_ProofIncome.ToString();
                        strArrParam[52] = oAML.Value_IdIssueAuth.ToString();
                        strArrParam[53] = Convert.ToString(oAML.Value_PermProofAddr);	//@CLTPERMADDPROOF
                        if (oAML.Value_chkPhoto.ToString().ToLower() == "true")
                        {
                            strArrParam[54] = "Y";
                        }
                        else
                        {
                            strArrParam[54] = "N";
                        }
                        strArrParam[55] = oAML.Value_ChgWghtReason.ToString();       //@CHANGEREASONCODE
                        strArrParam[62] = Convert.ToString(Session["CarrierCode"]);

                        string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
                        //intStatusCode = oClientMgr.BOCrtCltPer(strGCN, strCarrierCode, ref oClient, ref strErrMsg);        
                        //added by swapnesh on 13/05/2013 For getting intStatusCode value start
                        //to be uncommented
                        //Changed by rachana on10-07-2013 to enable MQ code start
                        if (strCallType == "1")
                        {

                            intStatusCode = oClientCrMgr.FetchClientCreationDetailsFromLA(strArrParam, strCarrierCode, ref oClientCr, ref strErrMsg);

                        }
                        else
                        {
                            intStatusCode = 0;
                        }
                        //Changed by rachana on10-07-2013 to enable MQ code end
                        //added by swapnesh on 13/05/2013 For getting intStatusCode value end

                        if (oClientCr.dtClt != null)
                        {
                            if (oClientCr.dtClt.Rows.Count > 0)
                            {
                                DataTable dtRecords = oClientCr.dtClt;
                                HttpContext.Current.Session["dtRecords"] = dtRecords;
                                lblErrMsg.Text = "Duplicate Client Records Found.";
                                lblErrMsg.Visible = true;
                                txtGCN.Text = strGCN;
                                txtCltCode.Text = strGCN;
                                hdnTempClientCode.Value = strGCN;
                                hdnDupFlag.Value = "DUPCLT";
                                txtDupBtnFlag.Text = "";
                                btnDupCltRecords.Enabled = true;
                                btnSave.Enabled = true;
                            }
                        }
                        else
                        {
                            if (intStatusCode == 0)
                            {
                                //added by swapnesh on 13/05/2013 For setting strClientCode value start
                                //changed by rachana 0n 11-07-2013 to enable MQ code start
                                if (strCallType == "1")
                                {
                                    strClientCode = oClientCr.strCLTCRNUM;
                                }
                                else
                                {
                                    strClientCode = strGCN;
                                }
                                //changed by rachana 0n 11-07-2013 to enable MQ code start
                                //added by swapnesh on 13/05/2013 For setting strClientCode value  end
                                int intRowsAffected = 0;
                                if (strCallType == "0")
                                {
                                    intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strClientCode);
                                }
                                else
                                {
                                }
                                //added by swapnesh on 13/05/2013 for getting intRowsAffected value start
                                //intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strDefCnctType, strClientCode, "M1");
                                //added by swapnesh on 13/05/2013 for getting intRowsAffected value end
                                //For CDA PAN UPDATION- movement from Corporate to personal clt 
                                if (ddlChannels.SelectedValue == "CD")
                                {
                                    htParam.Clear();
                                    htParam.Add("@GCN", strClientCode);
                                    htParam.Add("@Pan", strPan);
                                    htParam.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));
                                    objDAL.GetDataSetForPrc("dbo.proc_adv_panupdation", htParam);
                                    htParam.Clear();
                                }
                                //For CDA PAN UPDATION- movement from Corporate to personal clt end
                                oClientMgr.UpdateCltStatus(strClientCode);
                                lblErrMsg.Text = "Client Updated Sucessfully.";
                                lblErrMsg.Visible = true;
                                btnSave.Enabled = false;
                                //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                //Session["GCN"] = oClientCr.strCLTCRNUM;
                                //txtGCN.Text = oClientCr.strCLTCRNUM;
                                txtGCN.Text = strGCN;
                                txtCltCode.Text = strGCN;
                                //added by swapnesh on 13/05/2013 For setting txtGCN value end
                                if (hdnDupFlag.Value != "DUPCLT")
                                {
                                    if (ViewState["CNDID"] != null)
                                    {
                                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htParam.Add("@GCN", txtGCN.Text);
                                        htParam.Add("@CNDID", ViewState["CNDID"].ToString());
                                        htParam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));

                                        dataAccess.execute_sprcrecruit("dbo.Prc_InsertGCN_CND", htParam);
                                        htParam.Clear();
                                        btnSave.Enabled = false;
                                    }
                                }
                                if (strErrMsg.Length > 0)
                                {
                                    lblError2.Text = strErrMsg.ToString();
                                    MPEError.Show();
                                }
                                else
                                {
                                    if (strGCN.Length > 0)
                                    {
                                        if (txtGCN.Text.Length > 0)
                                        {
                                            lblError1.Text = "Message";
                                            lblError2.Text = "Client created successfully.";
                                            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start 
                                            lblmsg.Text = "Client created successfully." + Environment.NewLine;
                                            lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                            lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                            mdlpopup.Show();
                                            // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                            //MPEError.Show(); commented by rachana 0n 11-07-2013
                                        }
                                        else
                                        {
                                            lblError1.Text = "Message";
                                            lblError2.Text = "Client created successfully.";
                                            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End 
                                            lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                            lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                            lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                            mdlpopup.Show();
                                            // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                            //MPEError.Show();commented by rachana on 11-07-2013
                                            btnSave.Enabled = false;
                                        }
                                    }
                                }
                                //added by swapnesh on 13/05/2013 For setting txtGCN value start
                                //txtGCN.Text = oClientCr.strCLTCRNUM;
                                txtGCN.Text = strGCN;
                                txtCltCode.Text = strGCN;
                                //added by swapnesh on 13/05/2013 For setting txtGCN value end
                            }
                            else
                            {
                                lblErrMsg.Text = "Error Updating Record In Backend- " + strErrMsg;
                                lblErrMsg.Visible = true;
                                HttpContext.Current.Session["SaveFlag"] = "";
                                btnSave.Enabled = false;
                                //Added by Pranjali on 28-06-2013 for Deleting GCN on Error Updating Record In Backend start
                                Hashtable htparam = new Hashtable();
                                htparam.Add("@GCN", txtGCN);
                                objDAL.exec_comm_command("Prc_deletegcn", htparam);
                                //Added by Pranjali on 28-06-2013 for Deleting GCN on Error Updating Record In Backend end

                                txtGCN.Text = "";
                                txtCltCode.Text = "";
                            }
                        }
                        oClientCr = null;
                        oClientCr = null;
                        oClientCrMgr = null;
                    }
                    else
                    {
                        lblErrMsg.Text = "Error Updating Record In Frontend!";
                        lblErrMsg.Visible = true;
                        HttpContext.Current.Session["SaveFlag"] = "";
                        btnSave.Enabled = false;
                    }
                }
                else if (ddlCltCreateRule.SelectedValue == "FC")
                {
                    intStatusCode = oMQCltMgr.SaveClient(0, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
                    this.CreateXML();
                    if (intStatusCode > 0)
                    {
                        if (intStatusCode == 1)
                        {
                            lblComfirm1.Text = "One MATCH record found.";
                            lblComfirm2.Text = "Do you want to create New or Update?";
                            lblComfirm3.Text = "Click 'Yes' for create New and click 'No' for update Client.";

                            MPEComfirm.Show();
                        }
                        else if (intStatusCode == 2)
                        {
                            lblComfirmM1.Text = "Multiple/Partial MATCH records found.";
                            lblComfirmM2.Text = "Do You want to create New? ";
                            lblComfirmM3.Text = "Click 'Yes' for create New.";

                            MPEComfirmM.Show();
                        }

                        if ((intStatusCode == 1) || (intStatusCode == 2))
                        {
                            ErrMsg_SetFocus();
                        }
                    }
                    if (intStatusCode == 0)
                    {
                        Insc.MQ.Common.Client.MQClient oClient = new Insc.MQ.Common.Client.MQClient();
                        Insc.MQ.Common.Client.MQClientMgr oClientMgr = new Insc.MQ.Common.Client.MQClientMgr();
                        string strDefCnctType = oClientMgr.GetColValFromDT(dtClt, "DefCnctType", 0);
                        int intRowsAffected = 0;

                        intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strGCN);
                        intRowsAffected = oClientMgr.AddClientCode(strGCN, strCarrierCode, strDefCnctType, strGCN, "M1");
                        oClientMgr.UpdateCltStatus(strGCN);
                        lblErrMsg.Text = "Client Updated Sucessfully.";
                        lblErrMsg.Visible = true;
                        btnSave.Enabled = false;
                        Session["GCN"] = strGCN;
                        if (strErrMsg.Length > 0)
                        {
                            lblError2.Text = strErrMsg.ToString();
                            MPEError.Show();
                        }
                        else
                        {
                            if (strGCN.Length > 0)
                            {
                                if (txtGCN.Text.Length > 0)
                                {
                                    lblError1.Text = "Message";
                                    lblError2.Text = "Client updated successfully.";
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
                                    lblmsg.Text = "Client updated successfully." + Environment.NewLine;
                                    lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                    lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                    mdlpopup.Show();
                                    // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                    MPEError.Show();
                                    btnSave.Enabled = false;
                                }
                                else
                                {
                                    lblError1.Text = "Message";
                                    lblError2.Text = "Client created successfully.";
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start 
                                    lblmsg.Text = "Client Created successfully." + Environment.NewLine;
                                    lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
                                    lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
                                    mdlpopup.Show();
                                    // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
                                    //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End

                                    MPEError.Show();
                                    btnSave.Enabled = false;
                                }
                            }
                        }
                        txtGCN.Text = strGCN;
                        //added by swapnesh on 13/05/2013 For setting txtCltCode value start
                        txtCltCode.Text = strGCN;
                        //added by swapnesh on 13/05/2013 For setting txtCltCode value end
                        oClient = null;
                        oClientMgr = null;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Error Updating Record- " + ex.Message;
                lblErrMsg.Visible = true;
                HttpContext.Current.Session["SaveFlag"] = "";
                btnSave.Enabled = false;
            }
            oMQCltMgr = null;
            if (lblError2.Text == "Client updated successfully." || lblError2.Text == "Client created successfully.")
            {
                ErrMsg = "S";
            }
            else
            {
                ErrMsg = "E";
            }

            AuditType = "IN";
            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "", ErrCode = "", ErrDsc = lblErrMsg.Text, ErrDtl = "";
            if (intStatusCode == 0)
            {
                ErrSrc = "SQ";
            }
            else
            {
                ErrSrc = "BO";
            }
            objChnSetup.iAuditLog(ErrMsg, AuditType, txtGCN.Text, "Clt", "Clt,MQClientMgr.cs", "prc_Clt_InsUpdDel_Clt", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
            //Added by Pranjali on 22-07-2013 for Non-MQ call start
            if (strCallType == "0")
            {
                SqlConnection conn = new SqlConnection(sConnStr);
                string strsql4 = "insert into CltId (id,IdType,IdStat,GCN )values ('" + txtCurrentID.Text + "','P','P','" + txtGCN.Text + "')";
                //SqlConnection conn = new SqlConnection(sConnStr);
                SqlCommand cmdcltid = new SqlCommand(strsql4, conn);
                conn.Open();
                cmdcltid.ExecuteNonQuery();
                conn.Close();
                //Added by Pranjali on 22-07-2013 for Non-MQ call End
            }
        }
    }
    #endregion

    #region BUTTON btnVerifyPAN Click
    //For cda pan updation
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {
        bool isFound = false;
        DataSet dsRes = new DataSet();
        lblPANMsg.Text = "";
        hdnPan.Value = "0";
        htParam.Clear();
        htParam.Add("@PAN", txtCurrentID.Text.Trim());
        dsRes = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkPANExist", htParam);

        if (dsRes.Tables.Count > 0)
        {
            if (dsRes.Tables[0].Rows.Count > 0)
            {
                isFound = true;
                hdnAgnCode.Value = Convert.ToString(dsRes.Tables[0].Rows[0]["AgentCode"]).Trim();
            }
            else
            {
                hdnPan.Value = "1";
            }
        }
        else
        {
            hdnPan.Value = "1";
        }

        if (isFound == true)
        {
            lblPANMsg.Text = "Duplicate Match Found <br/>" + hdnAgnCode.Value;
        }
    }
    #endregion

    #region FUNCTION CreateXML
    private void CreateXML()
    {
        ArrayList arrLst = new ArrayList();

        arrLst.Add(new prjXml.Collection("Action", "2"));
        arrLst.Add(new prjXml.Collection("CltType", strCltType));
        arrLst.Add(new prjXml.Collection("UserGCN", strGCN));
        arrLst.Add(new prjXml.Collection("CltCode", txtCltCode.Text));
        arrLst.Add(new prjXml.Collection("Src", strSrc));
        arrLst.Add(new prjXml.Collection("GCN", txtGCN.Text));
        arrLst.Add(new prjXml.Collection("SurName", txtname.Text));
        arrLst.Add(new prjXml.Collection("GivenName", txtGivenName.Text));
        arrLst.Add(new prjXml.Collection("Title", cboTitle.SelectedValue));
        arrLst.Add(new prjXml.Collection("DOB", txtDOB.Text));
        arrLst.Add(new prjXml.Collection("FatherName", txtSurname.Text));
        arrLst.Add(new prjXml.Collection("PAN", txtCurrentID.Text));
        arrLst.Add(new prjXml.Collection("ClientCretRul", ddlCltCreateRule.SelectedValue));
        arrLst.Add(new prjXml.Collection("Gender", cboGender.SelectedValue));
        arrLst.Add(new prjXml.Collection("ErrMsg", strErrMsg));
        arrLst.Add(new prjXml.Collection("SpecInd", ddlSpecInd.SelectedValue));
        arrLst.Add(new prjXml.Collection("AlterIDType", cboOtherIDType.SelectedValue));
        arrLst.Add(new prjXml.Collection("MartalStat", cboMaritalStatus.SelectedValue));
        arrLst.Add(new prjXml.Collection("AlterIDNo", txtOthersID.Text));
        arrLst.Add(new prjXml.Collection("SOE", ddlSOE.SelectedValue));
        arrLst.Add(new prjXml.Collection("NationID", txtNationalCode.Text));
        arrLst.Add(new prjXml.Collection("NationDesc", txtNationalDesc.Text));
        arrLst.Add(new prjXml.Collection("Category", ddlCategory.SelectedValue));
        arrLst.Add(new prjXml.Collection("HighQual", cboQualCode.SelectedValue));
        arrLst.Add(new prjXml.Collection("ResAddr1", txtAddrP1.Text));
        arrLst.Add(new prjXml.Collection("ResAddr2", txtAddrP2.Text));
        arrLst.Add(new prjXml.Collection("ResAddr3", txtAddrP3.Text));
        arrLst.Add(new prjXml.Collection("PStateId", txtStateCodeP.Text));
        arrLst.Add(new prjXml.Collection("PStateDesc", txtStateDescP.Text));
        arrLst.Add(new prjXml.Collection("PPinCode", txtPinP.Text));
        arrLst.Add(new prjXml.Collection("PCountryID", txtCountryCodeP.Text));
        arrLst.Add(new prjXml.Collection("PCountryDes", txtCountryDescP.Text));
        arrLst.Add(new prjXml.Collection("BAddr1", txtAddrB1.Text));
        arrLst.Add(new prjXml.Collection("BAddr2", txtAddrB2.Text));
        arrLst.Add(new prjXml.Collection("BAddr3", txtAddrB3.Text));
        arrLst.Add(new prjXml.Collection("BStateID", txtStateCodeB.Text));
        arrLst.Add(new prjXml.Collection("BStateDesc", txtStateDescB.Text));
        arrLst.Add(new prjXml.Collection("BPinCode", txtPinB.Text));
        arrLst.Add(new prjXml.Collection("BCountryID", txtCountryCodeB.Text));
        arrLst.Add(new prjXml.Collection("BCountryDesc", txtCountryDescB.Text));
        arrLst.Add(new prjXml.Collection("PrAddr1", txtAdd1.Text));
        arrLst.Add(new prjXml.Collection("PrAddr2", txtAdd2.Text));
        arrLst.Add(new prjXml.Collection("PrAddr3", txtAdd3.Text));
        arrLst.Add(new prjXml.Collection("PrStateId", txtStateCode.Text));
        arrLst.Add(new prjXml.Collection("PrStateCode", txtStateDesc.Text));
        arrLst.Add(new prjXml.Collection("PrCountryID", txtCountryCode.Text));
        arrLst.Add(new prjXml.Collection("PrCountryCode", txtCountryDesc.Text));
        arrLst.Add(new prjXml.Collection("HomeTel", txtHomeTel.Text));
        arrLst.Add(new prjXml.Collection("OffTel", txtWorkTel.Text));
        arrLst.Add(new prjXml.Collection("DidTelNo", txtDidtel.Text));
        arrLst.Add(new prjXml.Collection("MobileTel", txtMobileTel.Text));
        if (ChkDrml.Checked == true)
        {
            arrLst.Add(new prjXml.Collection("DirectMail", "Y"));
        }
        else
        {
            arrLst.Add(new prjXml.Collection("DirectMail", "N"));
        }
        arrLst.Add(new prjXml.Collection("Pager", txtPager.Text));
        arrLst.Add(new prjXml.Collection("Fax", txtFax.Text));
        arrLst.Add(new prjXml.Collection("Height", txtHeight.Text));
        arrLst.Add(new prjXml.Collection("weight", txtWeight.Text));
        arrLst.Add(new prjXml.Collection("OccId", txtOccupationCode.Text));
        arrLst.Add(new prjXml.Collection("OccDesc", txtOccupationDesc.Text));
        arrLst.Add(new prjXml.Collection("AnnIncome", txtALIncome.Text));
        if (chkVip.Checked == true)
        {
            arrLst.Add(new prjXml.Collection("PrfClt", "Y"));
        }
        else
        {
            arrLst.Add(new prjXml.Collection("PrfClt", "N"));
        }
        if (chkStaff.Checked == true)
        {
            arrLst.Add(new prjXml.Collection("Staff", "Y"));
        }
        else
        {
            arrLst.Add(new prjXml.Collection("Staff", "N"));
        }
        if (chkSalesTax.Checked == true)
        {
            arrLst.Add(new prjXml.Collection("DerviceTax", "Y"));
        }
        else
        {
            arrLst.Add(new prjXml.Collection("DerviceTax", "N"));
        }
        arrLst.Add(new prjXml.Collection("Remark", Menu1.Text));

        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
        
        XmlDocument xDoc = new XmlDocument();
        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
        strXML = xDoc.OuterXml;

        arrLst.Clear();
    }
    #endregion

    #region FUNCTION CheckAddress
    public void CheckAddress(object source, ServerValidateEventArgs args)
    {
        bool blnResult = true;

        if (this.txtGCN.Text.Length > 0)
        {
            for (int i = 0; i < plcAddressP.Controls.Count; i++)
            {
                Application_Common_ClientAddress oAddrP = (Application_Common_ClientAddress)plcAddressP.Controls[i];

                if (cboCnctType.SelectedIndex == i)
                {
                    if (!oAddrP.HasValue)
                    {
                        blnResult = false;
                    }
                }

                args.IsValid = blnResult;
            }

            for (int i = 0; i < plcAddressB.Controls.Count; i++)
            {
                Application_Common_ClientAddress oAddrB = (Application_Common_ClientAddress)plcAddressB.Controls[i];

                if (cboCnctType.SelectedIndex == i)
                {
                    if (!oAddrB.HasValue)
                    {
                        blnResult = false;
                    }
                }

                args.IsValid = blnResult;
            }
        }
    }
    #endregion

    #region FUNCTION cmdYes Click
    protected void cmdYes_Click(object sender, EventArgs e)
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        dsClt = new DataSet();
        dsClt = CltDataSet();
        MPEComfirm.Hide();
        MPEComfirmM.Hide();
        
        intStatusCode = oMQCltMgr.SaveClient(1, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
        txtGCN.Text = strGCN;
        Session["GCN"] = strGCN;

        if (strErrMsg.Length > 0)
        {
            string strLog = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "|" + Session["UserId"].ToString() + "|" + Session["CarrierCode"].ToString() + "|" + strErrMsg;
            subCreateLog(strLog);

            lblError1.Text = "Message.";
            lblError2.Text = strErrMsg.ToString();
            lblError2.Visible = true;
            lblError3.Visible = false;
            lblError3.Text = "";
            ErrMsg_SetFocus();
            MPEError.Show();
        }
        else
        {
            if (ViewState["CNDID"] != null)
            {
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@GCN", txtGCN.Text);
                htParam.Add("@CNDID", ViewState["CNDID"].ToString());
                htParam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));

                dataAccess.execute_sprcrecruit("dbo.Prc_InsertGCN_CND", htParam);
                htParam.Clear();
            }
            lblError1.Text = "Message";
            lblError2.Text = "";
            lblError2.Visible = false;
            lblError3.Visible = true;
            lblError3.Text = "Client updated successfully.";
            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
            lblmsg.Text = "Client updated successfully." + Environment.NewLine;
            lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
            lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
            mdlpopup.Show();
            // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End
                                              
            ErrMsg_SetFocus();
            MPEError.Show();
            subRenderPage();
        }
    }
    #endregion

    #region FUNCTION subRenderPage
    private void subRenderPage()
    {
        if (strGCNA.Length > 0)
        {
            string strGCN = string.Empty;
            strGCN = strGCNA.ToString();

            ViewEntry();
            if (strEnq == "1")
            {
                this.btnSearchClt.Visible = false;
                this.btnCancel.Visible = false;
            }

            lblHeader.Text = Convert.ToString("Personal Client - View");
        }
        else
            NewEntry();
    }
    #endregion

    #region FUNCTION cmdNo Click
    protected void cmdNo_Click(object sender, EventArgs e)
    {
        strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        MPEComfirm.Hide();
        MPEComfirmM.Hide();
        dsClt = new DataSet();
        dsClt = CltDataSet();
        
        intStatusCode = oMQCltMgr.SaveClient(2, dsClt, strCarrierCode, strCltType, strUserGCN, strSrc, ref strGCN, ref strErrMsg);
        txtGCN.Text = strGCN;
        Session["GCN"] = strGCN;

        if (strErrMsg.Length > 0)
        {
            lblError1.Text = "Message.";
            lblError2.Text = strErrMsg.ToString();
            lblError2.Visible = true;
            lblError3.Text = "";
            lblError3.Visible = false;
            ErrMsg_ReSetFocus();
            MPEError.Show();
        }
        else
        {
            if (ViewState["CNDID"] != null)
            {
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@GCN", txtGCN.Text);
                htParam.Add("@CNDID", ViewState["CNDID"].ToString());
                htParam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));

                dataAccess.execute_sprcrecruit("dbo.Prc_InsertGCN_CND", htParam);
                htParam.Clear();
            }
            lblError1.Text = "Message";
            lblError2.Text = "";
            lblError2.Visible = false;
            lblError3.Visible = true;
            lblError3.Text = "Client updated successfully.";
            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box Start  
            lblmsg.Text = "Client updated successfully." + Environment.NewLine;
            lblmsg4.Text = "GCN NO.:-" + txtGCN.Text;
            lblmsg5.Text = "Client name:-" + txtGivenName.Text + "  " + txtname.Text;
            mdlpopup.Show();
            // MPEError.Show(); Commneted By Ibrahim on 17-06-2013 for blocking the previously used message box 
            //Added by Ibrahim on 17-06-2013  for adding modal popup to display message box End
                                              
            ErrMsg_ReSetFocus();
            MPEError.Show();
        }
    }
    #endregion

    #region FUNCTION cmdCancel Click
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        MPEComfirm.Hide();
        MPEComfirmM.Hide();
        MPEError.Hide();

        cboCnctType.Attributes.Add("style", "display: visible");
        cboGender.Attributes.Add("style", "display: visible");
        cboMaritalStatus.Attributes.Add("style", "display: visible");
        cboOtherIDType.Attributes.Add("style", "display: visible");
        ddlCategory.Attributes.Add("style", "display: visible");
        cboTitle.Attributes.Add("style", "display: visible");
    }
    #endregion

    #region FUNCTION cmdOk_ClsMsg
    protected void cmdOk_ClsMsg(object sender, EventArgs e)
    {
        MPEError.Hide();

        cboCnctType.Attributes.Add("style", "display: visible");
        cboGender.Attributes.Add("style", "display: visible");
        cboMaritalStatus.Attributes.Add("style", "display: visible");
        cboOtherIDType.Attributes.Add("style", "display: visible");
        ddlCategory.Attributes.Add("style", "display: visible");
        cboTitle.Attributes.Add("style", "display: visible");

        //added by swapnesh on 13/05/2013 For setting txtGCN value start
        //txtGCN.Text = Session["GCN"].ToString();
        txtGCN.Text = strGCN;
        txtCltCode.Text = strGCN;
        //added by swapnesh on 13/05/2013 For setting txtGCN value end
        if (txtGCN.Text != string.Empty)
            Response.Redirect("Clt.aspx?ENQ=" + strEnq + "&GCN=" + txtGCN.Text + "&FLAGFIND=" + txtFlagFind.Text);
    }
    #endregion

    #region FUNCTION ErrMsg_SetFocus
    protected void ErrMsg_SetFocus()
    {
        cboCnctType.Attributes.Add("style", "display: hidden");
        cboGender.Attributes.Add("style", "display: hidden");
        cboMaritalStatus.Attributes.Add("style", "display: hidden");
        cboOtherIDType.Attributes.Add("style", "display: hidden");
        ddlCategory.Attributes.Add("style", "display: hidden");
        cboTitle.Attributes.Add("style", "display: hidden");
    }
    #endregion

    #region FUNCTION ErrMsg_ReSetFocus
    protected void ErrMsg_ReSetFocus()
    {

        cboCnctType.Attributes.Add("style", "display: visible");
        cboGender.Attributes.Add("style", "display: visible");
        cboMaritalStatus.Attributes.Add("style", "display: visible");
        cboOtherIDType.Attributes.Add("style", "display: visible");
        ddlCategory.Attributes.Add("style", "display: visible");
        cboTitle.Attributes.Add("style", "display: visible");

    }
    #endregion

    #region BUTTON hdnComfirmbtn OnClick
    protected void hdnComfirmbtn_OnClick(object sender, EventArgs e)
    {
        cboCnctType.Attributes.Add("style", "display: hidden");
        cboGender.Attributes.Add("style", "display: hidden");
        cboMaritalStatus.Attributes.Add("style", "display: hidden");
        cboOtherIDType.Attributes.Add("style", "display: hidden");
        ddlCategory.Attributes.Add("style", "display: hidden");
        cboTitle.Attributes.Add("style", "display: hidden");

    }
    #endregion

    #region BUTTON hdnbtn OnClick
    protected void hdnbtn_OnClick(object sender, EventArgs e)
    {
        this.cboCnctType.Enabled = false;
        this.cboGender.Enabled = false;
        this.cboMaritalStatus.ddliSysLParamEnabled = false;
        this.cboOtherIDType.ddliSysLParamEnabled = false;
        this.cboQualCode.ddliSysLParamEnabled = false;
        ddlCategory.Enabled = false;
        this.cboTitle.Enabled = false;
    }
    #endregion

    #region FUNCTION MPE_Onload
    protected void MPE_Onload(object sender, EventArgs e)
    {
        cboCnctType.Attributes.Add("style", "display: visible");
        cboGender.Attributes.Add("style", "display: visible");
        cboMaritalStatus.Attributes.Add("style", "display: visible");
        cboOtherIDType.Attributes.Add("style", "display: visible");
        ddlCategory.Attributes.Add("style", "display: visible");
        cboTitle.Attributes.Add("style", "display: visible");
    }
    #endregion

    protected void MPE_OnClick(object sender, EventArgs e)
    {
    }

    #region FUNCTION fncFormatAddress
    private string fncFormatAddress(string v_strAddress)
    {
        v_strAddress = v_strAddress.Replace(",", ", ");
        v_strAddress = v_strAddress.Replace(",  ", ", ");

        return v_strAddress;
    }
    #endregion

    #region FUNCTION subCreateLog
    private void subCreateLog(string v_strLog)
    {
        if (!Directory.Exists(Server.MapPath(".") + c_strLogPath))
        {
            Directory.CreateDirectory(Server.MapPath(".") + c_strLogPath);
        }

        string strFolder = c_strLogPath + "/" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0');
        string strFile = strFolder + "/" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".log";

        if (!Directory.Exists(Server.MapPath(".") + strFolder))
        {
            Directory.CreateDirectory(Server.MapPath(".") + strFolder);
        }

        StreamWriter sw = new StreamWriter(Server.MapPath(".") + strFile, true);
        sw.WriteLine(v_strLog);
        sw.Flush();
        sw.Close();
    }
    #endregion

    #region FUNCTION subPopulateTitle
    private void subPopulateTitle()
    {
        oCommon.getDropDown(cboTitle, "NBTitle", 1, "", 1, c_strBlank);
    }
    #endregion

    protected void btnAML_Load(object sender, EventArgs e)
    {

    }
    protected void btnNational_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearchClt_Click(object sender, EventArgs e)
    {

    }
    protected void btnOccupation_Click(object sender, EventArgs e)
    {

    }

    #region FUNCTION SetDefaultAmlValue
    private void SetDefaultAmlValue()
    {
        Application_Common_ClientAML oAMLDF = btnAML;
        oAMLDF.Value_RiskInd = "1";
        oAMLDF.Value_ProofAddr = "OTHERS";
        oAMLDF.Value_PermProofAddr = "OTHERS";
        oAMLDF.Value_ProofID = "OTHERS";
        oAMLDF.Value_IDNo = "12345";
        oAMLDF.Value_IdIssueAuth = "abcdefg";
        oAMLDF.Value_IdIssueDate = "01/01/2000";
        oAMLDF.Value_chkPhoto = true.ToString();
		oAMLDF.Value_ChgWghtReason = "AML3";
    }
    #endregion

    #region DROPDOWNLIST ddlChannels SelectedIndexChanged event
    protected void ddlChannels_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChannels.SelectedValue == "CD")
        {
            lblFname.Text = "Father Name/Representative Name";
            lbldob.Text = "Date Of Birth/Date of Incorporation";
            btnVerifyPAN.Enabled = true;
			lblmandatory.Visible = true;
        }
        else
        {
            lblFname.Text = "Father Name";
            lbldob.Text = "Date Of Birth";
			lblmandatory.Visible = false;
        }
    }
    #endregion

}
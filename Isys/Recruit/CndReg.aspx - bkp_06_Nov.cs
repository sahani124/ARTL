#region
//Modified by  Ajay Yadav
//Changes :UI
#endregion

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
using System.Drawing;
using System.Text;
using Insc.Common.Data;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using MQSMQMgr;
using INSCL;
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.MQ.Life.AgnCr;
using Insc.Common.Multilingual;
using Insc.MQ.Life.AgnInwMd;
using Insc.MQ.Life.AgnInwCr;
using System.Text.RegularExpressions;
using DataAccessClassDAL;
using AadharNo;
using KMI.FRMWRK.DAL;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml;
using Microsoft.Reporting.WebForms;

public partial class Application_Common_CndReg : BaseClass
{

    #region Declare Veriables
    string Pan = null;
    public string Code { get; set; }
    int intValue;
    private Hashtable htdata = new Hashtable();
    static byte[] data;
    private string strDestDir = string.Empty;
    private string strFileName = string.Empty;
    private string strDestPath = string.Empty;
    string strCandtype;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    int BMaxImgSize; //= Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxImgSize"]);
    int BMaxImgSize1;
    string strPhotoExt = string.Empty;
    string strDocName = string.Empty;
    private string strFileName1 = string.Empty;
    string DocStatusCount;
    static int image_height;
    static int image_width;
    static int max_height;
    static int max_width;
    static string filename;
    static string contenttype;
    string strProcessType;
    string str;
    string doctype;
    string strAdvWaiverExt = string.Empty;
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
    string inscdireconn = System.Configuration.ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ToString();
    private Provider oDP = new Insc.Common.Data.Provider();
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    const string cSessionQryState = "ClientDetail";
    protected CommonFunc oCommon = new CommonFunc();
    string candtype;
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    public const string CONN_INSCCOMMON = "INSCCommonConnectionString";
    string strXML = "";
    Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
    public multilingualManager olng;

    private const string c_strLogPath = "/Log";
    private const string c_strBlank = "Select";
    Hashtable htParam = new Hashtable();
    Hashtable httable = new Hashtable();
    Hashtable htparams = new Hashtable();
    private DataAccessClass dataAccessclass = new DataAccessClass();
    private clsCndReg clsCndReg = new clsCndReg();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    bool IsFoundRefBy = false;
    string strpanno = "";
    DataSet dsResult1 = new DataSet();
    string strAgentType = string.Empty;
    bool IsFound = false;
    ErrLog objErr = new ErrLog();
    DataSet dsResult = new DataSet();
    Aadhar objAadhar = new Aadhar();
    DataSet dsSMrecruitcode = new DataSet();
    string MemberCode;
    string MemberType = string.Empty;
    string BizSrc;
    string ChnCls;
    string UserType;
    string strUser = string.Empty;
    private DataAccessClass dataAccessRecruit = new DataAccessClass();

    SqlDataReader drResult;
    string strProspectID = string.Empty;
    DataSet dsPanResult = new DataSet();
    int StrMsg;
    IsysMailComm.IsysMailComm objmail = new IsysMailComm.IsysMailComm();
    Hashtable htPan = new Hashtable();

    AadharVault AadharVault = new AadharVault();
    DataSet ds_documentName = new DataSet();
    string mimeType = string.Empty;
    string encoding = string.Empty;
    string extension = string.Empty;
    Warning[] warnings;
    string[] streamIds;
    string strRpt = System.Configuration.ConfigurationManager.AppSettings["Report"].ToString();
    #endregion

    #region PAGELOADEVENTS
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            strUser = HttpContext.Current.Session["UserID"].ToString();
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            //txtYrPass.Attributes.Add("style", "background-color: white");

            #region "!IsPostBack"
            if (!IsPostBack)
            {
                txtDateOfAppointmentTrnsfr.Attributes.Add("readonly", "readonly");
                txtDateOfCessationTrnsfr.Attributes.Add("readonly", "readonly");
                txtTagApp.Attributes.Add("readonly", "readonly");
                txtDateOfAppointment.Attributes.Add("readonly", "readonly");
                txtDateOfCessation.Attributes.Add("readonly", "readonly");
                txtYrPass.Attributes.Add("readonly", "readonly");
                txtDOB.Attributes.Add("readonly", "readonly");
                txtregdate.Attributes.Add("readonly", "readonly");
                txtIC.Attributes.Add("readonly", "readonly");

                txtDOB.Attributes.Add("style", "background-color: white");
                txtregdate.Attributes.Add("style", "background-color: white");
                txtIC.Attributes.Add("style", "background-color: white");
                txtDateOfAppointmentTrnsfr.Attributes.Add("style", "background-color: white");
                txtDateOfCessationTrnsfr.Attributes.Add("style", "background-color: white");
                txtTagApp.Attributes.Add("style", "background-color: white");
                txtDateOfAppointment.Attributes.Add("style", "background-color: white");
                txtDateOfCessation.Attributes.Add("style", "background-color: white");
                txtYrPass.Attributes.Add("style", "background-color: white");
                span1.Attributes.Add("style", "background-color: #8c8c8c !important");
                span2.Attributes.Add("style", "background-color: #8c8c8c !important");
                span4.Attributes.Add("style", "background-color: #8c8c8c !important");
                span5.Attributes.Add("style", "background-color: #8c8c8c !important");
                span6.Attributes.Add("style", "background-color: #8c8c8c !important");
                span7.Attributes.Add("style", "background-color: #8c8c8c !important");
                span8.Attributes.Add("style", "background-color: #8c8c8c !important");
                span9.Attributes.Add("style", "background-color: #8c8c8c !important");
                lblFessWav.Visible = true;
                ddlFessWav.Visible = true;
                anniversryrow.Visible = false;
                LblAnnivrsryDt.Visible = false;
                calrow.Visible = false;
                divRDH.Attributes.Add("style", "color:#00cccc !important;");
                span3.Attributes.Add("style", "background-color: #00cccc !important");
                span3.Attributes.Add("style", "background-color: #00cccc !important");
                #region "Tab Index"
                txthometel.Attributes.Add("onblur", "javascript:document.getElementById('" + txtWorkTel.ClientID + "').focus();");
                ChkPA.Attributes.Add("onclick", "funchkpaclick(this)");
                #endregion
                DataSet dsIsSpPrsn = new DataSet();
                dsIsSpPrsn = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
                ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();
                if (dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim() == "YES")
                {
                    divIsSpecified.Attributes.Add("style", "display:block");
                }
                else
                {
                    divIsSpecified.Attributes.Add("style", "display:none");
                }
                subPopulateRelation();
                ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
                olng = new multilingualManager("DefaultConn", "CndReg.aspx", Session["UserLangNum"].ToString());
                ddlAgntType.Items.Insert(0, new ListItem("Select", ""));
                ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
                txtCountryCodeP.Text = "IND";
                txtCountryCodeP.Enabled = false; ;
                txtCountryDescP.Text = "INDIAN";
                txtCountryCodeP.Enabled = false;

                btnCountryP.Visible = false;
                txtPermCountryCode.Text = "IND";
                txtPermCountryCode.Enabled = false;
                txtPermCountryDesc.Text = "INDIAN";
                txtPermCountryDesc.Enabled = false;
                tr2.Visible = false;
                tr3.Visible = false;
                trTCCase.Visible = false;
                trTCCase1.Visible = false;
                tr4.Visible = false;
                trAckRcv.Visible = false;
                btnPermCountry.Visible = false;
                btnExmCentre.Attributes.Add("onclick", "funcShowPopup2('ExmCentre');return false;");
                txtCountryCodeR1.Text = "IND";
                txtCountryDescR1.Text = "INDIAN";
                txtCountryCodeR2.Text = "IND";
                txtCountryDescR2.Text = "INDIAN";
                txtNationalCode.Text = "IND";
                txtNationalDesc.Text = "INDIAN";
                btnCountryR1.Enabled = false;
                btnCountryR2.Enabled = false;
                txtReferredBy.Attributes.Add("onchange", "doClearRefAdvInfo();");
                txtRef1Add1.Attributes.Add("onchange", "doFormat('" + txtRef1Add1.ClientID + "');");
                txtRef1Add2.Attributes.Add("onchange", "doFormat('" + txtRef1Add2.ClientID + "');");
                txtRef1Add3.Attributes.Add("onchange", "doFormat('" + txtRef1Add3.ClientID + "');");
                txtRef2Add1.Attributes.Add("onchange", "doFormat('" + txtRef2Add1.ClientID + "');");
                txtRef2Add2.Attributes.Add("onchange", "doFormat('" + txtRef2Add2.ClientID + "');");
                txtRef2Add3.Attributes.Add("onchange", "doFormat('" + txtRef2Add3.ClientID + "');");
                FillRequiredDataForPage3();
                txtNationalCode.Attributes.Add("onblur", "lookupNational(document.getElementById('" +
                    txtNationalCode.ClientID + "').value, '" +
                    txtNationalDesc.ClientID + "', '" +
                    Session["UserLangNum"].ToString() + "');");
                txtStateCodeP.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                txtStateCodeP.ClientID + "').value, '" +
                txtStateDescP.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                txtStateCodeR1.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                 txtStateCodeR1.ClientID + "').value, '" +
                txtStateDescR1.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                btnStateR1.Attributes.Add("onclick", "funcShowPopup('state1');return false;");
                txtStateCodeR2.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                    txtStateCodeR2.ClientID + "').value, '" + txtStateDescR2.ClientID + "','" +
                   Session["UserLangNum"].ToString() + "');");
                btnStateR2.Attributes.Add("onclick", "funcShowPopup('state2');return false;");
                txtCountryCodeP.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                    txtCountryCodeP.ClientID + "').value, '" +
                    txtCountryDescP.ClientID + "', '" +
                    Session["UserLangNum"].ToString() + "');");
                btnCountryP.Attributes.Add("onclick", "funcShowPopup('country');return false;"); //Added by pranjali on 14-01-2014 for nationality popup
                txtCountryCodeR1.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                txtCountryCodeR1.ClientID + "').value, '" +
                txtCountryDescR1.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                btnCountryR1.Attributes.Add("onclick", "popCountryP('" +
                    txtCountryCodeR1.ClientID + "','" +
                    txtCountryDescR1.ClientID + "'," +
                    "document.getElementById('" +
                    txtCountryCodeR1.ClientID + "').value," +
                    "document.getElementById('" +
                    txtCountryDescR1.ClientID + "').value,'" +
                    "');return false;");
                txtCountryCodeR2.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                txtCountryCodeR2.ClientID + "').value, '" +
                txtCountryDescR2.ClientID + "', '" +
                Session["UserLangNum"].ToString() + "');");
                btnCountryR2.Attributes.Add("onclick", "popCountryP('" +
                  txtCountryCodeR2.ClientID + "','" +
                  txtCountryDescR2.ClientID + "'," +
                  "document.getElementById('" +
                  txtCountryCodeR2.ClientID + "').value," +
                  "document.getElementById('" +
                  txtCountryDescR2.ClientID + "').value,'" +
                  "');return false;");
                txtOccupationCode.Attributes.Add("onblur", "lookupOccupation(document.getElementById('" +
                 txtOccupationCode.ClientID + "').value, '" +
                 txtOccupationDesc.ClientID + "', '" +
                 Session["UserLangNum"].ToString() + "');");
                btnOccupation.Attributes.Add("onclick", "funcShowPopup('occup');return false;");
                txtNationalCode.Attributes.Add("onblur", "lookupNational(document.getElementById('" +
                   txtNationalCode.ClientID + "').value, '" +
                   txtNationalDesc.ClientID + "', '" +
                   Session["UserLangNum"].ToString() + "');");
                txtPermStateCode.Attributes.Add("onblur", "lookupState(document.getElementById('" +
                    txtPermStateCode.ClientID + "').value, '" +
                    txtPermStateDesc.ClientID + "', 1);");
                txtpermDistrict.Attributes.Add("onchange", "doFormat('" + txtpermDistrict.ClientID + "');"); //Added by kalyani on 31-12-2013 for Permanent District field
                btnpermDistrict.Attributes.Add("onclick", "funcShowPopup('permDistrict');return false;"); //Added by kalyani on 31-12-2013 for Permanent District field
                btnPermState.Attributes.Add("onclick", "funcShowPopup('permstate');return false;");
                txtPermCountryCode.Attributes.Add("onblur", "lookupCountry(document.getElementById('" +
                      txtPermCountryCode.ClientID + "').value, '" +
                      txtPermCountryDesc.ClientID + "', 1);");
                btnPermCountry.Attributes.Add("onclick", "popCountryP('" +
                    txtPermCountryCode.ClientID + "','" +
                    txtPermCountryDesc.ClientID + "'," +
                    "document.getElementById('" +
                    txtPermCountryCode.ClientID + "').value," +
                    "document.getElementById('" +
                    txtPermCountryDesc.ClientID + "').value);return false;");
                cboGender.Attributes.Add("style", "display: visible");
                cboMaritalStatus.Attributes.Add("style", "display: visible");
                ddlCnctType.Attributes.Add("style", "display: visible");
                btnagent.Attributes.Add("onClick", "javascript: return funOpenPopWinForAccntPayee('AccntPayPopUpPros.aspx', document.getElementById('" + txtrecagent.ClientID + "').value,'" + txtrecagtname.ClientID + "','" + txtrecagent.ClientID + "','" + hdSmCode.ClientID + "', document.getElementById('" + ddlSlsChannel.ClientID + "').value, document.getElementById('" + ddlChnCls.ClientID + "').value, document.getElementById('" + ddlAgntType.ClientID + "').value,'4');");
                lnkPage1.BackColor = Color.LightYellow;
                lnkPage2.BackColor = Color.Transparent;
                subPopulateTitle();
                subRelation();
                subPopulateGender();
                PopulateCandidateType();
                subPopulateKnownLanguage();
                PopulateCategory();
                PopulateProofIDDoc();
                PopulateRecruiterCode();
                PopulateExamMode();
                PopulateCasteCat();
                PopulateBasicQual();
                CnctType(true);
                InitializeControl();
                PopulateMaritalStatus();
                PopulatePrimProof();
                PopulateContactPreferred();
                PopulateQualCode();
                PopulateChecbox();
                FillAgentProfile(ddlProfQual, "AgntProfsnlQual");
                FillAgentProfile(DdlInsQual, "AgntInslQual");
                PopulateState1();
                PopulateState();
                txtchqamt.Text = "825";
                PopulateCompInsurerName();
                PopulateTrnsfrInsurerName();
                PopulateCasteCat();
                PopulateBasicQual();
                PopulateProofIDDoc();
                PopulateCompInsurerName();
                PopulateTrnsfrInsurerName();
                PopulateQualCode();
                subPopulateKnownLanguage();
                PopulateAgentType();
                YearsInInsurance();
                YearsInReliance();
                VechicleManufacturer();
                VechicleType();
                ddlAvgMonthlyIncm.Enabled = false;
                AverageMonthlyIncome();
                ComptCompyMonthlyVolum();
                ComptCompyMonthlyVolum2();
                BusinessMonthlyVol();
                CompetitorCompanyName2();
                CompetitorCompanyName1();
                TotalBusiness();
                FillProspectInfo();
                #region "Request.QueryString["Type"] == "N""
                if (Request.QueryString["Type"] == "N")
                {
                    ddlCandidatetype.SelectedValue = "F";
                    txtapplicationno.ReadOnly = true;
                    txtregdate.Text = DateTime.Now.ToString(CommonUtility.DATE_FORMAT);
                    lblqregdate.Text = txtregdate.Text;
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 1.png";
                    lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";
                    btnUpdate.Text = olng.GetItemDesc("btnSave");
                    lnkPage2.Enabled = true;
                    trNote.Visible = false;
                    trNoteTr.Visible = true;
                    cbFrshFlag.Checked = true;
                    ChkPA.Checked = false;
                    if (Request.QueryString["PAN"].ToString().Trim() != null)
                    {
                        txtCurrentID.Text = Request.QueryString["PAN"].ToString().Trim();
                    }
                }
                #endregion
                htParam.Clear();
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrc("Prc_GetInsuranceType", htParam);
                if (dsResult.Tables[0].Rows[0][0].ToString() == "1")
                {
                    cbTagLcn.Enabled = true;
                }
                else
                {
                    cbTagLcn.Enabled = false;
                }
                CatComp(ddlCaTrnsfr, dsResult.Tables[0]);
                CatComp(ddlCatComp, dsResult.Tables[0]);
                NameInsurance(ddlNameIns);
                NameInsurance(ddlNameInTrnsfr);
                CatComp(ddlTagCat, dsResult.Tables[0]);
                CatComp(ddlCatFlag, dsResult.Tables[0]);
                #region Bank Info Details Part1
                btnUpdate.Attributes.Add("onClick", "javascript: return funValidate()");
                btnAddComposite.Attributes.Add("onClick", "javascript: return funValidateComp()");
                btnAddTrnsfr.Attributes.Add("onClick", "javascript: return funValidateTrn()");
                #endregion Bank Info Details Part1
                #region Prospect Details
                if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                {
                    ddlCandidatetype.SelectedValue = "F";
                    strProspectID = Request.QueryString["ProspectId"].ToString();
                    lblqffromreliance.Text = "From Any Company";
                    PopulateProofIDDoc();
                    cbFrshFlag.Checked = true;
                    txtCurrentID.Enabled = false;
                    btnVerifyPAN.Enabled = false;
                    trNote.Visible = false;
                    ModeEdit();
                    Hashtable httable = new Hashtable();
                    DataSet dscandtype = new DataSet();
                    httable.Add("@CndNo", Request.QueryString["ProspectId"].ToString());
                    dscandtype = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                    string strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString().Trim();
                    candtype = dscandtype.Tables[0].Rows[0]["CandType"].ToString().Trim();
                    string autowavier = dscandtype.Tables[0].Rows[0]["AutoWavierflag"].ToString().Trim();
                    ddlFessWav.SelectedValue = autowavier;
                    ddlCandidatetype.SelectedValue = strCndType;
                    BindCompositeGrid(Request.QueryString["ProspectId"].ToString());
                }
                #endregion
                #region Candidate Details
                if (Request.QueryString["Type"] == "E")
                {
                    btndocsave.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdate.Enabled = false;
                    string txtcndid1;
                    if (Request.QueryString["CndNo"] != null)
                    {
                        txtcndid1 = Request.QueryString["CndNo"].ToString();
                        txtcndid.Text = Request.QueryString["CndNo"].ToString();
                    }
                    else
                    {
                        txtcndid1 = Request.QueryString["ProspectId"].ToString();
                    }
                    Hashtable httable = new Hashtable();
                    DataSet dscandtype = new DataSet();
                    httable.Add("@CndNo", txtcndid1);
                    dscandtype = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                    string strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString().Trim();
                    candtype = dscandtype.Tables[0].Rows[0]["CandType"].ToString().Trim();
                    string autowavier = dscandtype.Tables[0].Rows[0]["AutoWavierflag"].ToString().Trim();
                    trNote.Visible = false;
                    ddlFessWav.SelectedValue = autowavier;
                    ddlCandidatetype.SelectedValue = strCndType;
                    if (strCndType == "C")
                    {
                        trFreshTitle.Visible = false;
                        cbTccCompLcn.Checked = true;
                        trNote.Visible = true;
                        cbTccCompLcn.Enabled = false;
                        NameInsurance(ddlNameIns);
                        if (Request.QueryString["CndNo"] != null)
                        {
                            BindCompositeGrid(Request.QueryString["CndNo"].ToString());
                        }
                        else
                        {
                            BindCompositeGrid(Request.QueryString["ProspectId"].ToString());
                        }
                    }
                    else if (strCndType == "G")
                    {
                        trFreshTitle.Visible = true;
                        trCompTitle.Visible = false;
                        trNote.Visible = true;
                        trTagTitle.Visible = true;
                        cbTagLcn.Enabled = false;
                        cbTagLcn.Checked = true;
                        NameInsurance(ddlNameIns);
                        if (Request.QueryString["CndNo"] != null)
                        {
                            BindCompositeGrid(Request.QueryString["CndNo"].ToString());
                        }
                        else
                        {
                            BindCompositeGrid(Request.QueryString["ProspectId"].ToString());
                        }
                    }
                    else if (strCndType == "T")
                    {
                        trFreshTitle.Visible = false;
                        trFreshTitle.Visible = true;
                        trCompTitle.Visible = false;
                        cbTrfrFlag.Enabled = false;
                        cbTrfrFlag.Checked = true;
                        NameInsurance(ddlNameInTrnsfr);
                        if (gvTrnsfr.Rows.Count == 0)
                        {
                            tdNoteIc.Visible = false;
                        }
                        else
                        {
                            tdNoteIc.Visible = true;
                        }

                        if (Request.QueryString["CndNo"] != null)
                        {
                            BindCompositeGrid(Request.QueryString["CndNo"].ToString());
                        }
                        else
                        {
                            BindCompositeGrid(Request.QueryString["ProspectId"].ToString());
                        }
                    }
                    else if (strCndType == "F")
                    {
                        cbFrshFlag.Checked = true;
                        trCompTitle.Visible = false;
                        trFreshTitle.Visible = true;
                    }
                    PopulateProofIDDoc();
                    ModeEdit();
                    GetProfilingDtls();
                    GetRCAPcompany();
                    GetNoofyearsinInsurance();
                    if (ddlagntype.SelectedIndex == 2)
                    {
                        ddlTypeOfVehicle.Enabled = true;
                        GetDealerTypeOfVehicleDeal();
                    }
                    else
                    {
                        ddlTypeOfVehicle.Enabled = false;
                        GetDealerTypeOfVehicleDeal();
                    }
                    if (ddlagntype.SelectedIndex == 2)
                    {
                        txtDlrCompName.Enabled = true;
                        GetCompanyName();
                    }
                    else
                    {
                        txtDlrCompName.Enabled = false;
                        GetCompanyName();
                    }
                    if (ddlIsWrkng.SelectedValue == "Y")
                    {
                        ddlcompName.Enabled = true;
                        GetComapnynNameIfYes();
                    }
                    else
                    {
                        ddlcompName.Enabled = false;
                        GetComapnynNameIfYes();
                    }
                    if (ddlagntype.SelectedIndex == 5)
                    {
                        txtOthers.Enabled = true;
                        GetFromOthersSpecify1();
                    }
                    else
                    {
                        txtOthers.Enabled = false;
                        GetFromOthersSpecify1();
                    }
                    if (ddlagntype.SelectedIndex == 2)
                    {
                        txtDlrOth.Enabled = true;
                        GetFromOthersSpecify2();
                    }
                    else
                    {
                        txtDlrOth.Enabled = false;
                        GetFromOthersSpecify2();
                    }
                    GetNoOfYearsWithReliance();
                    if (ddlagntype.SelectedIndex == 2)
                    {
                        ddlVechManuf.Enabled = true;
                        GetDealerVehicleManufacturerdealing();
                    }
                    else
                    {
                        ddlVechManuf.Enabled = false;
                        GetDealerVehicleManufacturerdealing();
                    }
                    ddlAvgMonthlyIncm.Enabled = true;
                    GetAvgMonthlyVolumeinLacs();
                    GetCompany1name();
                    GetCompany2name();
                    GetMonthlyVolumeInLacsCompany1();
                    GetMonthlyVolumeInLacsCompany2();
                    GetMonthlyVolumeInLacsRGI();
                    GetTotalBuisnessMotor();
                    GetTotalBuisnessHealth();
                    GetTotalBuisnessComercialLine();
                    GetBusinessWithRGIMotor();
                    GetBusinessWithRGIHealth();
                    GetBusinessWithRGIComercialLine();
                    if (Request.QueryString["Flag"] == "App")
                    {
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnUpdate.Enabled = true;
                    }
                }
                #endregion
                if (ddlSlsChannel.SelectedValue.ToString().Trim() == "" || ddlChnCls.SelectedValue.ToString().Trim() == "" || ddlAgntType.SelectedValue.ToString().Trim() == "")
                {
                    btnagent.Enabled = false;
                }
                else
                {
                    btnImmLeaderCode.Enabled = true;
                    btnagent.Enabled = true;
                }
                FillHiddenValues();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup1", "window.setTimeout('focus()',50);", true);
                if (ddlcategory.SelectedValue == "U")
                {
                    txtVillage.Text = string.Empty;
                    txtVillage.Enabled = false;
                    txtpermvillage.Text = string.Empty;
                    txtpermvillage.Enabled = false;
                    PopulateProofIDDoc();
                }
                else
                {
                    txtVillage.Enabled = true;
                    txtpermvillage.Enabled = true;
                }
                ddlcategory.Focus();
                ViewState["Pan"] = txtCurrentID.Text;

            }
            #endregion
            if (ChkPA.Checked)
            {
                txtPermAdd1.Text = txtAddrP1.Text;
                txtPermAdd2.Text = txtAddrP2.Text;
                txtPermAdd3.Text = txtAddrP3.Text;
                txtpermvillage.Text = txtVillage.Text;
                txtPermCountryCode.Text = txtCountryCodeP.Text;
                txtPermCountryDesc.Text = txtCountryDescP.Text;
                ddlstate1.Text = ddlState.Text;
                txtpermDistrict.Text = txtDistric.Text;
                txtcity1.Text = txtcity.Text;
                txtarea1.Text = txtarea.Text;
                txtPermPostcode.Text = txtPinP.Text;
                txtPermAdd1.Enabled = false;
                txtPermAdd2.Enabled = false;
                txtPermAdd3.Enabled = false;
                txtpermvillage.Enabled = false;
                ddlstate1.Enabled = false;
            }
            txtmobcode.Enabled = false;
            hdnBtnDis.Value = "";
            btnUpdate.Attributes.Add("OnClick", "javascript: return funValidate();");
            btnVerifyPAN.Attributes.Add("onclick", "Javascript:return ValidationPAN();");
            btnLUnitCode.Attributes.Add("onclick", "funOpenPopWinLUnit('PopLUnit.aspx'," +
                "'" + txtUnitName.ClientID + "'," +
                "'" + txtUnitName.ClientID + "','" + txtUnitCode.ClientID + "');return false;");
            btnVerifyRefBy.Attributes.Add("onclick", "Javascript:return ValidationRefBy();");
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

    #region subPopulateMaritalStatus
    private void subPopulateRelation()
    {
        try
        {
            //To get the relation type in the dropdown from IsysLookupParam 
            oCommon.getDropDown(Ddlrelation, "NBRelation", 1, "", 1, c_strBlank);
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


    //Added by pranjali to populate state information start
    #region PopulateState
    private void PopulateState()
    {
        try
        {
            string strSql = string.Empty;
            SqlDataReader dtRead;
            DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();



            dsResult = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetddlState");


            if (dsResult != null && dsResult.Tables.Count > 0)
            {

                ddlState.DataSource = dsResult;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select");


            }
            //dtRead = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");
            //dtRead.Read();
            //if (dtRead.HasRows)
            //{
            //    ddlState.DataSource = dtRead;
            //    ddlState.DataTextField = "StateName";
            //    ddlState.DataValueField = "StateID";
            //    ddlState.DataBind();
            //    ddlState.Items.Insert(0, "Select");
            //}
            dsResult = null;
            dtRead = null;
            strSql = null;
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

    private void PopulateState1()
    {
        try
        {
            string strSql = string.Empty;
            SqlDataReader dtRead1;
            DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            dtRead1 = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");

            if (dtRead1.HasRows)
            {
                ddlstate1.DataSource = dtRead1;
                ddlstate1.DataTextField = "StateName";
                ddlstate1.DataValueField = "StateID";
                ddlstate1.DataBind();
                ddlstate1.Items.Insert(0, "Select");
            }
            dsResult = null;
            dtRead1 = null;
            strSql = null;
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

    //Added by pranjali on 03/02/2014 to populate state information end 


    //added by pranjali on 13-03-2014 for binding dropdown of transfer insurer name start
    #region PopulateTrnsfrInsurerName
    private void PopulateTrnsfrInsurerName()
    {
        try
        {

            DataSet dtReadTrnsfr = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            //dtReadTrnsfr = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetTransferInsurerName");
            dtReadTrnsfr = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetTransferInsurerName");
            //dtReadTrnsfr.Read();
            //if (dtReadTrnsfr.HasRows)
            //{
            ddlTrnsfrInsurName.DataSource = dtReadTrnsfr;
            ddlTrnsfrInsurName.DataTextField = "InsurerDesc";
            ddlTrnsfrInsurName.DataValueField = "InsurerValue";
            ddlTrnsfrInsurName.DataBind();
            ddlTrnsfrInsurName.Items.Insert(0, "Select");

            //}
            dtReadTrnsfr = null;
            //strSql = null;
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
    //added by pranjali on 13-03-2014 for binding dropdown of transfer insurer name end
    //added by pranjali on 13-03-2014 for binding dropdown of Composite insurer name start
    #region PopulateCompInsurerName
    private void PopulateCompInsurerName()
    {
        try
        {
            //string strSql = string.Empty;
            //SqlDataReader dtReadComp;
            DataSet dtReadComp = new DataSet();
            //DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();

            dtReadComp = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetCompositeInsurerName");

            ddlCompInsurerName.DataSource = dtReadComp;
            ddlCompInsurerName.DataTextField = "InsurerDesc";
            ddlCompInsurerName.DataValueField = "InsurerValue";
            ddlCompInsurerName.DataBind();
            ddlCompInsurerName.Items.Insert(0, "Select");

            //}

            dtReadComp = null;
            //strSql = null;
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

    #region GetRecruiterDetails
    public DataSet GetRecruiterDetail(string RecruiterCode)
    {
        DataSet dsResult = new DataSet();
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@RecruiterCode", RecruiterCode);
        dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetRecruiterCodeDtls", htparam);
        return dsResult;
    }
    #endregion
    //added by pranjali on 03-04-2014 end

    #region PopulateExamMode
    private void PopulateExamMode()
    {
        try
        {
            //Added By Asrar on 26-06-2013 for converting Inline query into procedure Exam Mode start
            ddlExam.Items.Clear();

            DSddlExam.SelectCommand = "Prc_GetExamMode";
            ddlExam.DataBind();
            ddlExam.Items.Insert(0, "Select");
            //Added By Asrar on 26-06-2013 for converting Inline query into procedure Exam Mode End
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
    //Added by kalyani on 30-12-2013 to remove user control start 
    private void PopulateCasteCat()
    {
        try
        {
            oCommon.getDropDown(ddlCasteCat, "CasteCat", 1, "", 1);
            ddlCasteCat.Items.Insert(0, "Select");
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

    private void PopulateBasicQual()
    {
        try
        {
            oCommon.getDropDown(ddlBasicQual, "BasicQual", 1, "", 1);
            ddlBasicQual.Items.Insert(0, "Select");
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

    private void PopulateMaritalStatus()
    {
        try
        {
            oCommon.getDropDown(cboMaritalStatus, "MarrySts", 1, "", 1);
            cboMaritalStatus.Items.Insert(0, "Select");
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

    private void PopulateQualCode()
    {
        try
        {

            oCommon.getDropDown(cboQualCode, "NBEduQua", 1, "", 1);
            cboQualCode.Items.Insert(0, "Select");
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

    private void PopulateChecbox()
    {

        if (ddllanknow1.SelectedIndex != 0)
        {
            lblqfread1.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfspeak1.Visible = true;
            //tdlanknow1.Visible = true;
            //tdlanknow1.Attributes.Add("Style", "visibility:visible");
            cbpread.Visible = true;
            cbpwrite.Visible = true;
            cbpspeak.Visible = true;
        }
        if (ddllanknow2.SelectedIndex != 0)
        {
            lblqfread1.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfspeak1.Visible = true;
            cbpread2.Visible = true;
            cbpwrite2.Visible = true;
            cbpspeak2.Visible = true;
        }

        if (ddllanknow3.SelectedIndex != 0)
        {
            lblqfread2.Visible = true;
            lblqfwrite2.Visible = true;
            lblqfspeak2.Visible = true;
            cbpread3.Visible = true;
            cbpwrite3.Visible = true;
            cbpspeak3.Visible = true;
        }
        if (ddllanknow4.SelectedIndex != 0)
        {
            lblqfread2.Visible = true;
            lblqfwrite2.Visible = true;
            lblqfspeak2.Visible = true;
            cbpread4.Visible = true;
            cbpwrite4.Visible = true;
            cbpspeak4.Visible = true;

        }

    }
    //Added by kalyani on 30-12-2013 to remove user control end 
    #endregion

    #region METHOD "InitializeControl()"
    private void InitializeControl()
    {
        try
        {
            lblcategory.Text = olng.GetItemDesc("lblcategory");
            lblpfPersonal.Text = "Address Details";
            lblpfcndid.Text = olng.GetItemDesc("lblpfcndid");
            lblpfappno.Text = olng.GetItemDesc("lblpfappno");
            lblpfregdate.Text = olng.GetItemDesc("lblpfregdate");
            lblpfgivenName.Text = "First Name";
            lblpfSurName.Text = "Middle Name";
            lblpffathername.Text = olng.GetItemDesc("lblpffathername");
            lblRelation.Text = "Relationship with agent";
            lblpfGender.Text = olng.GetItemDesc("lblpfGender");
            lblpfdob.Text = olng.GetItemDesc("lblpfdob");
            lblpfmaritalstatus.Text = olng.GetItemDesc("lblpfmaritalstatus");
            lblpfNationality.Text = olng.GetItemDesc("lblpfNationality");
            lblpfpan.Text = olng.GetItemDesc("lblpfpan");
            lblpfrecinfotitle.Text = "Recruiter Details";
            lblpfsalchannel.Text = olng.GetItemDesc("lblpfsalchannel");
            lblpfchasubclass.Text = olng.GetItemDesc("lblpfchasubclass");
            lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
            lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
            lblpfsmname.Text = olng.GetItemDesc("lblpfsmname");
            lblpfrecagent.Text = olng.GetItemDesc("lblpfrecagent");
            lblpfrecagtname.Text = olng.GetItemDesc("lblpfrecagtname");
            lblpfpresentadd.Text = olng.GetItemDesc("lblpfpresentadd");
            lblpfaddresstype.Text = olng.GetItemDesc("lblpfaddresstype");
            lblpfAddrP1.Text = olng.GetItemDesc("lblpfAddrP1");
            lblpfAddrP2.Text = olng.GetItemDesc("lblpfAddrP2");
            lblpfAddrP3.Text = olng.GetItemDesc("lblpfAddrP3");
            lblpfStateP.Text = olng.GetItemDesc("lblpfStateP");
            lblpfPinP.Text = olng.GetItemDesc("lblpfPinP");
            lblpfCountryP.Text = "Nationality";
            lblpfPrmAddTitle.Text = olng.GetItemDesc("lblpfPrmAddTitle");
            lblpfprmAdd.Text = olng.GetItemDesc("lblpfprmAdd");
            lblpfprmAdd2.Text = olng.GetItemDesc("lblpfprmAdd2");
            lblpfprmAdd3.Text = olng.GetItemDesc("lblpfprmAdd3");
            lblpfprmstatecode.Text = olng.GetItemDesc("lblpfprmstatecode");
            lblpfprmpostcode.Text = olng.GetItemDesc("lblpfprmpostcode");
            lblpfprmcountry.Text = olng.GetItemDesc("lblpfprmcountry");
            lblpfconpreferred.Text = olng.GetItemDesc("lblpfconpreferred");
            lblpfhometel.Text = olng.GetItemDesc("lblpfhometel");
            lblpfofftel.Text = olng.GetItemDesc("lblpfofftel");
            lblpfdidtel.Text = olng.GetItemDesc("lblpfdidtel");
            //lblpfmobtel.Text = olng.GetItemDesc("lblpfmobtel");
            lblpfdirmail.Text = olng.GetItemDesc("lblpfdirmail");
            lblpfpager.Text = olng.GetItemDesc("lblpfpager");
            lblpffax.Text = olng.GetItemDesc("lblpffax");
            LblWhatsaap.Text = olng.GetItemDesc("LblWhatsaap");
            lblpfprodoctitle.Text = olng.GetItemDesc("lblpfprodoctitle");
            lblpfageproof.Text = olng.GetItemDesc("lblpfageproof");
            lblpfaddproof.Text = olng.GetItemDesc("lblpfaddproof");
            lblpfeduproof.Text = olng.GetItemDesc("lblpfeduproof");
            lblpfphoto.Text = olng.GetItemDesc("lblpfphoto");
            lblpfmarksheet.Text = olng.GetItemDesc("lblpfmarksheet");
            lblpfcertificate.Text = olng.GetItemDesc("lblpfcertificate");
            lblpreexamlng.Text = olng.GetItemDesc("lblpreexamlng");
            lblAckrcv.Text = olng.GetItemDesc("lblAckrcv.Text");
            LblProfQual.Text = olng.GetItemDesc("LblProfQual");
            LblInsQual.Text = olng.GetItemDesc("LblInsQual");
            lblExam.Text = olng.GetItemDesc("lblExam");
            lblCandAgntType.Text = "Agent Type";
            lblOldLcnexpDate.Text = olng.GetItemDesc("lblOldLcnexpDate.Text");
            lblYrPass.Text = olng.GetItemDesc("lblYrPass.Text");
            lblComplicnseExpDt.Text = olng.GetItemDesc("lblComplicnseExpDt");
            lblIsSPFlag.Text = olng.GetItemDesc("lblIsSPFlag");
            lblCACode.Text = olng.GetItemDesc("lblCACode");
            lblCAName.Text = olng.GetItemDesc("lblCAName");
            lblqfpersonalinformation.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lblqfcndnotitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lblqfappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lblqfregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lblqfgivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lblqfsurname.Text = olng.GetItemDesc("lblqfsurname");
            lblqfknolanguagestitle.Text = olng.GetItemDesc("lblqfknolanguagestitle");
            lblqflanguagesKnown1.Text = olng.GetItemDesc("lblqflanguagesKnown1");
            lblqflanguage1.Text = olng.GetItemDesc("lblqflanguage1");
            lblqfread1.Text = olng.GetItemDesc("lblqfread1");
            lblqfwrite1.Text = olng.GetItemDesc("lblqfwrite1");
            lblqfspeak1.Text = olng.GetItemDesc("lblqfspeak1");
            lblqflanguagesKnown2.Text = olng.GetItemDesc("lblqflanguagesKnown1");
            lblqflanguage2.Text = olng.GetItemDesc("lblqflanguage1");
            lblqfread2.Text = olng.GetItemDesc("lblqfread1");
            lblqfwrite2.Text = olng.GetItemDesc("lblqfwrite1");
            lblqfspeak2.Text = olng.GetItemDesc("lblqfspeak1");
            lbqfloccqualification.Text = olng.GetItemDesc("lbqfloccqualification");
            lblqfHigestQul.Text = olng.GetItemDesc("lblqfHigestQul");
            lblqfinsqualification.Text = olng.GetItemDesc("lblqfinsqualification");
            lblqfoccupation.Text = olng.GetItemDesc("lblqfoccupation");
            lblqfempaddress.Text = olng.GetItemDesc("lblqfempaddress");
            lblqfdoyouhave.Text = olng.GetItemDesc("lblqfdoyouhave");
            lblqffromreliance.Text = olng.GetItemDesc("lblqffromreliance");
            lblqffromothers.Text = olng.GetItemDesc("lblqffromothers");
            cbMutFund.Text = olng.GetItemDesc("cbMutFund");
            cbLifeIns.Text = olng.GetItemDesc("cbLifeIns");
            cbGenIns.Text = olng.GetItemDesc("cbGenIns");
            cbCreCard.Text = olng.GetItemDesc("cbCreCard");
            lblehtpersonalinformation.Text = olng.GetItemDesc("lblehtpersonalinformation");
            lblehcndnotitle.Text = olng.GetItemDesc("lblehcndnotitle");
            lblehappnotitle.Text = olng.GetItemDesc("lblehappnotitle");
            lblehregdatetitle.Text = olng.GetItemDesc("lblehregdatetitle");
            lblehgivennametitle.Text = olng.GetItemDesc("lblehgivennametitle");
            lblehsurnametitle.Text = olng.GetItemDesc("lblehsurnametitle");
            lblehEmpHistory.Text = olng.GetItemDesc("lblehEmpHistory");
            lblehbeginning.Text = olng.GetItemDesc("lblehbeginning");
            lblehfrom.Text = olng.GetItemDesc("lblehfrom");
            lblehto.Text = olng.GetItemDesc("lblehto");
            lblehname.Text = olng.GetItemDesc("lblehname");
            lblehaddofemp.Text = olng.GetItemDesc("lblehaddofemp");
            lbllehastposition.Text = olng.GetItemDesc("lbllehastposition");
            lblehannincome.Text = olng.GetItemDesc("lblehannincome");
            lblehresforleave.Text = olng.GetItemDesc("lblehresforleave");
            lblehexperience.Text = olng.GetItemDesc("lblehexperience");
            lblehhaveyou.Text = olng.GetItemDesc("lblehhaveyou");
            lblehcompanyname.Text = olng.GetItemDesc("lblehcompanyname");
            lblehcnfrom.Text = olng.GetItemDesc("lblehcnfrom");
            lblehcnto.Text = olng.GetItemDesc("lblehcnto");
            lblehcnjobnature.Text = olng.GetItemDesc("lblehcnjobnature");
            lblehcnfield.Text = olng.GetItemDesc("lblehcnfield");
            lblehdetofinsagcy.Text = olng.GetItemDesc("lblehdetofinsagcy");
            lblehgerlifeinscompy.Text = olng.GetItemDesc("lblehgerlifeinscompy");
            lblehnameofcomp.Text = olng.GetItemDesc("lblehnameofcomp");
            lblehlicno.Text = olng.GetItemDesc("lblehlicno");
            lblehdateofissue.Text = olng.GetItemDesc("lblehdateofissue");
            lblehvaliddate.Text = olng.GetItemDesc("lblehvaliddate");
            lblehagencycode.Text = olng.GetItemDesc("lblehagencycode");
            lblehterminationdate.Text = olng.GetItemDesc("lblehterminationdate");
            lblehterreason.Text = olng.GetItemDesc("lblehterreason");
            lblpersonalinformation.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lbldicndidtitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lbldiappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lbldiregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lbldigivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lbldisurnametitle.Text = olng.GetItemDesc("lblqfsurname");
            lbldidisinformation.Text = olng.GetItemDesc("lbldidisinformation");
            lbldihybconvicted.Text = olng.GetItemDesc("lbldihybconvicted");
            lbldihybsubject.Text = olng.GetItemDesc("lbldihybsubject");
            lbldihybjudgement.Text = olng.GetItemDesc("lbldihybjudgement");
            lbldihybinsolv.Text = olng.GetItemDesc("lbldihybinsolv");
            lbldireference.Text = olng.GetItemDesc("lbldireference");
            lblditrefname1.Text = olng.GetItemDesc("lblditrefname1");
            lbldiref1address.Text = olng.GetItemDesc("lbldiref1address");
            lbldiRef1state.Text = olng.GetItemDesc("lbldiRef1state");
            lbldiRef1Pincode.Text = olng.GetItemDesc("lbldiRef1Pincode");
            lbldiRef1country.Text = olng.GetItemDesc("lbldiRef1country");
            lbldiRefname2.Text = olng.GetItemDesc("lbldiRefname2");
            lbldiRef2Add.Text = olng.GetItemDesc("lbldiRef2Add");
            lbldiRef2State.Text = olng.GetItemDesc("lbldiRef2State");
            lbldiRef2Pincode.Text = olng.GetItemDesc("lbldiRef2Pincode");
            lbldiRef2Country.Text = olng.GetItemDesc("lbldiRef2Country");
            lblbppersinftitle.Text = olng.GetItemDesc("lblbppersinftitle");
            lblbpEmpHistory1.Text = olng.GetItemDesc("lblbpEmpHistory1");
            lblbppersinftitle.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lblbpcndnotitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lblbpappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lblbpregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lblbpgivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lblbpsurnametitle.Text = olng.GetItemDesc("lblqfsurname");
            lblbptyear.Text = olng.GetItemDesc("lblbptyear");
            lbltnooflives.Text = olng.GetItemDesc("lbltnooflives");
            lbltsumassured.Text = olng.GetItemDesc("lbltsumassured");
            lbltfirstyearpremium.Text = olng.GetItemDesc("lbltfirstyearpremium");
            lblbpyear1.Text = olng.GetItemDesc("lblbpyear1");
            lblbpyear2.Text = olng.GetItemDesc("lblbpyear2");
            lblbpyear3.Text = olng.GetItemDesc("lblbpyear3");
            lblbpwillingtowork.Text = olng.GetItemDesc("lblbpwillingtowork");
            lblbpanyotherinformation.Text = olng.GetItemDesc("lblbpanyotherinformation");
            lblbnkdtls.Text = olng.GetItemDesc("lblbnkdtls");
            lblbnkhldname.Text = olng.GetItemDesc("lblbnkhldname");
            lblbnkacno.Text = olng.GetItemDesc("lblbnkacno");
            lblbnkname.Text = olng.GetItemDesc("lblbnkname");
            lblbrnchname.Text = olng.GetItemDesc("lblbrnchname");
            lblactype.Text = olng.GetItemDesc("lblactype");
            lblifsccode.Text = olng.GetItemDesc("lblifsccode");
            lblmicrcode.Text = olng.GetItemDesc("lblmicrcode");
            lblGstcode.Text = olng.GetItemDesc("lblGstcode");
            SqlDataReader dtRead;
            httable.Clear();
            httable.Add("@UserLang", Convert.ToInt32(Session["UserLangNum"].ToString()));
            dtRead = dataAccessclass.Common_exec_reader_prc("prc_GetChannelDesc", httable);
            if (dtRead.HasRows)
            {
                dtRead.Read();
                lblbpareyourelated.Text = "Are you related to any employee of " + dtRead[0].ToString() + "?";
            }
            lblbpifyes.Text = (olng.GetItemDesc("lblbpifyes").Replace("','", ","));
            btnUpdate.Text = "UPDATE";/*olng.GetItemDesc("btnUpdate");*/
            btnCancel.Text = "CLEAR";
            hdnIsDateValid.Value = olng.GetItemDesc("hdnIsDateValid");
            hdnDOB.Value = olng.GetItemDesc("hdnDOB");
            hdnSave.Value = olng.GetItemDesc("hdnSave");
            hdnUpdate.Value = olng.GetItemDesc("hdnUpdate");
            hdnAppno.Value = olng.GetItemDesc("hdnAppno");
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

    #region METHOD "checkApplicationNo()"
    public int checkApplicationNo(string sSql)
    {

        string iCount = String.Empty;
        SqlDataReader dtRead;
        //dtRead = dataAccessRecruit.Common_exec_reader(sSql);
        dtRead = dataAccessclass.Common_exec_reader(sSql);
        if (dtRead.Read())
        {
            iCount = dtRead[0].ToString();
        }
        dtRead.Close();

        if (iCount == "1")
            return 1;
        else
            return 0;

    }
    #endregion

    #region METHOD "checkDate of Birth()"
    public int checkDOB(DateTime DOBdate, DateTime cnddate)
    {

        DateTime CDate = cnddate.AddYears(-18);
        if (CDate > DOBdate)
            return 1;
        else
            return 0;

    }
    #endregion

    #region METHOD "Populate subPopulateAge / subPopulateAddress /CnctType"

    private void PopulateCategory()
    {
        try
        {
            oCommon.getDropDown(ddlcategory, "CndCat", 1, "", 1);
            ddlcategory.Items.Insert(0, "Select");
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

    private void PopulatePreExmLanguages()
    {
        try
        {
            ddlpreeamlng.Items.Clear();
            DSddlpreeamlng.SelectCommand = "Prc_GetExamLanguage '" + "0" + "'";
            ddlpreeamlng.DataBind();
            ddlpreeamlng.Items.Insert(0, "Select");
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

    private void PopulateAgentTypes(string slschn, string chncls, string stragntyp)
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htpara = new Hashtable();
            htpara.Add("@Bizsrc", slschn);
            htpara.Add("@Chncls", chncls);
            htpara.Add("@AgentType", stragntyp);
            dsresult = dataAccessclass.GetDataSetForPrc("Prc_GetAgentTypeforCndReg", htpara);
            ddlAgnTypes.DataSource = dsresult;
            ddlAgnTypes.DataTextField = "MemType";
            ddlAgnTypes.DataValueField = "MemTypeDesc01";
            ddlAgnTypes.DataBind();
            ddlAgnTypes.SelectedItem.Text = dsresult.Tables[0].Rows[0]["MemTypeDesc01"].ToString().Trim();
            dsresult = null;
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

    protected void PopulateRecruiterCode()
    {
        try
        {
            if (Request.QueryString["Type"].ToString() == "N" || Request.QueryString["ACT"].ToString() == "Edit")
            {
                htParam.Clear();
                dsSMrecruitcode.Clear();
                dsSMrecruitcode = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
                MemberCode = dsSMrecruitcode.Tables[0].Rows[0]["MemberCode"].ToString();
                MemberType = dsSMrecruitcode.Tables[0].Rows[0]["MemberType"].ToString();
                BizSrc = dsSMrecruitcode.Tables[0].Rows[0]["BizSrc"].ToString();
                ChnCls = dsSMrecruitcode.Tables[0].Rows[0]["ChnCls"].ToString();
                UserType = dsSMrecruitcode.Tables[0].Rows[0]["UserType"].ToString();
                ViewState["UserTypeHO"] = UserType;
                FillddlAddRptMgrCode();
                if (UserType == "I")
                {
                    htParam.Clear();
                    htParam.Add("@MemberCode", MemberCode);
                    htParam.Add("@MemberType", MemberType);
                    htParam.Add("@BizSrc", BizSrc);
                    htParam.Add("@ChnCls", ChnCls);
                    dsResult.Clear();
                    dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetRecruiterDtls", htParam);
                    if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                    {
                        ddlSlsChannel.Enabled = true;
                    }
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            IsFound = true;
                            txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]).Trim();//added by pranjali on 30-04-2014
                            txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                            txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();
                            txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                            hdnBizSrc.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                            string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                            string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                            ViewState["cmsunitcode"] = cmsunitcode;
                            txtImmLeader.Text = branch + " " + "(" + cmsunitcode + ")";
                            GetRecruitSalesChannel(ddlSlsChannel, BizSrc, 0, ChnCls);
                            #region recuiter Details
                            ViewState["Bizsrc"] = hdnBizSrc.Value;
                            ViewState["ChnCls"] = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                            ViewState["UnitCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                            ViewState["AgentType"] = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim();
                            ViewState["MemberCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();
                            ViewState["AgentName"] = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                            #endregion
                            if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                                {
                                    if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                                    {
                                        ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                        FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                                {
                                    if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                                    {
                                        ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                                    }
                                }
                            }
                            strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString();
                            PopulateAgentTypes(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, strAgentType);
                            ddlAgnTypes.SelectedItem.Value = strAgentType;//dsResult.Tables[0].Rows[0]["AgentTypeDesc01"].ToString().Trim();
                            ddlAgntType.Visible = false;
                            ddlAgnTypes.Visible = true;
                            if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                            {
                                ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
                                ddlSlsChannel.SelectedIndex = 0;
                                ddlChnCls.SelectedIndex = 0;
                            }
                            FillCndAgntType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue);
                        }
                    }
                }
                else
                {
                    htParam.Clear();
                    htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                    DataSet dsrecExt = new DataSet();
                    dsrecExt = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetRecruiterDtlsExternal", htParam);
                    if (dsrecExt.Tables[0].Rows[0]["BizSrc"] != null)
                    {
                        if (Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                        {
                            if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"])) != null)
                            {
                                ddlSlsChannel.SelectedValue = Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]).Trim();
                                FillddlSlsChannel(Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]).Trim());
                            }
                        }
                    }
                    if (dsrecExt.Tables[0].Rows[0]["ChnCls"] != null)
                    {
                        if (Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                        {
                            if (ddlChnCls.Items.FindByValue(Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"])) != null)
                            {
                                ddlChnCls.SelectedValue = Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"]);
                                FillddlChnCls(Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"]));
                            }
                        }
                    }

                    if (dsrecExt.Tables[0].Rows[0]["AgentType"] != null)
                    {
                        if (Convert.ToString(dsrecExt.Tables[0].Rows[0]["AgentType"]).Trim() != "")
                        {

                            if (ddlAgntType.Items.FindByValue(Convert.ToString(dsrecExt.Tables[0].Rows[0]["AgentType"])) != null)
                            {
                                ddlAgntType.Visible = true;
                                ddlAgnTypes.Visible = false;
                                ddlAgntType.SelectedValue = Convert.ToString(dsrecExt.Tables[0].Rows[0]["AgentType"]).Trim();
                                ddlAgntType.Enabled = false;
                            }

                        }
                    }

                    if (dsrecExt.Tables[0].Rows[0]["RecruitUnitCode"].ToString() != "")
                    {
                        Hashtable htcodeext = new Hashtable();
                        DataSet dsBranchCode = new DataSet();
                        htcodeext.Add("@UNitcode", Convert.ToString(dsrecExt.Tables[0].Rows[0]["RecruitUnitCode"]).Trim());
                        htcodeext.Add("@BizSrc", Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]).Trim());
                        htcodeext.Add("@Chncls", Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"]).Trim());
                        dsBranchCode.Clear();
                        dsBranchCode = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetBranchName", htcodeext);
                        string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                        string cmsunitcode = Convert.ToString(dsrecExt.Tables[0].Rows[0]["RecruitUnitCode"]).Trim();
                        MemberType = dsResult.Tables[0].Rows[0]["MemType"].ToString();
                        if (txtcndid.Text != "" || (!MemberType.ToUpper().Equals("EP") && !MemberType.ToUpper().Equals("LP")))
                            txtImmLeader.Text = branch + " " + "(" + cmsunitcode + ")";
                    }
                    FillCndAgntType(Convert.ToString(dsrecExt.Tables[0].Rows[0]["BizSrc"]), Convert.ToString(dsrecExt.Tables[0].Rows[0]["ChnCls"]));
                    ddlCandType.SelectedValue = Convert.ToString(dsrecExt.Tables[0].Rows[0]["CndAgtType"]);
                    ddlCandType.SelectedItem.Text = Convert.ToString(dsrecExt.Tables[0].Rows[0]["AgenCandTtype"]);
                    if (dsrecExt.Tables[0].Rows[0]["RecruitEmpCode"].ToString() != "")
                    {
                        txtEmpCode.Text = dsrecExt.Tables[0].Rows[0]["RecruitEmpCode"].ToString();
                    }
                    btnEmpCode.Enabled = false;
                }
            }
            else
            {
                htParam.Clear();
                htParam.Add("@ProspectId", Request.QueryString["ProspectId"].ToString().Trim());
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetRecruitDetails", htParam);
                if (dsResult.Tables[0].Rows[0]["RecruitBizSrc"].ToString().Trim() == "XX")
                {
                    ddlSlsChannel.Enabled = true;
                }
                txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitEmpCode"]).Trim();//added by pranjali on 30-04-2014
                if (dsResult.Tables[0].Rows[0]["RecruitUnitCode"] != null)
                {
                    Hashtable htcode = new Hashtable();
                    DataSet dsBranchCode = new DataSet();
                    htcode.Add("@UNitcode", Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).Trim());
                    htcode.Add("@BizSrc", Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                    htcode.Add("@Chncls", Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                    dsBranchCode = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                    string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                    string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).Trim();
                    string UnitCode = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).ToString().Trim();
                    ViewState["cmsunitcode"] = cmsunitcode;//added by usa 
                    txtImmLeader.Text = branch + "(" + cmsunitcode + ")";
                    #region recuiter Details
                    ViewState["Bizsrc"] = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                    ViewState["ChnCls"] = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                    ViewState["UnitCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).Trim();
                    ViewState["AgentType"] = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim();
                    ViewState["MemberCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]).Trim();
                    ViewState["AgentName"] = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]).Trim();
                    #endregion
                    DataSet dsUserType = new DataSet();
                    dsUserType = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
                    UserType = dsUserType.Tables[0].Rows[0]["UserType"].ToString();
                    ViewState["UserTypeHO"] = UserType;
                    dsSMrecruitcode.Clear();
                    dsSMrecruitcode = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
                    MemberCode = dsSMrecruitcode.Tables[0].Rows[0]["MemberCode"].ToString();
                    MemberType = dsSMrecruitcode.Tables[0].Rows[0]["MemberType"].ToString();
                    FillddlAddRptMgrCode();
                    GetRecruitSalesChannel(ddlSlsChannel, Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitBizSrc"]).Trim(), 0, Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitChnCls"]).Trim());
                }
                txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]).Trim();
                txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]).Trim();
                txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]).Trim();
                if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                    {
                        if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                        {
                            ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                        }
                    }
                }
                if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                    {
                        if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                        {
                            ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                        }
                    }
                }
                strAgentType = dsResult.Tables[0].Rows[0]["AgentType"].ToString();
                PopulateAgentTypes(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim(), strAgentType);
                ddlAgnTypes.SelectedItem.Value = strAgentType;
                ddlAgntType.Visible = false;
                ddlAgnTypes.Visible = true;
                FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                txtEmpCode.Enabled = false;
                btnEmpCode.Enabled = false;
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




    private void PopulateProofIDDoc()
    {
        try
        {
            string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();
            ddleducationproof.Items.Clear();
            if (ddlcategory.SelectedValue == "U")
            {
                dseducationproof.SelectCommand = "Prc_GetEducationProof '" + ddlBasicQual.SelectedValue.ToString().Trim().ToUpper() + "'";
                ddleducationproof.DataBind();
                ddleducationproof.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                dseducationproof.SelectCommand = "Prc_GetEducationProof '" + ddlBasicQual.SelectedValue.ToString().Trim().ToUpper() + "'";
                ddleducationproof.DataBind();
                ddleducationproof.Items.Insert(0, new ListItem("Select", ""));
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

    private void subPopulateAge()
    {
        try
        {
            oCommon.getDropDown(ddlProofAge, "SOE", 1, "", 0, c_strBlank);
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

    #region fill candidate type
    private void FillCndAgntType(string strbiz, string strChn)
    {
        try
        {
            htParam.Clear();
            SqlDataReader dragnt;
            htParam.Add("@BizSrc", strbiz);
            htParam.Add("@Chncls", strChn);
            dsResult.Clear();
            dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetAgntTypeforCnd", htParam);
            dragnt = dataAccessclass.exec_reader_prc_rec("Prc_GetAgntTypeforCnd", htParam);
            if (dsResult != null && dsResult.Tables.Count > 0)
            {
                ddlCandType.DataSource = dsResult;
                ddlCandType.DataTextField = "MemTypeDesc01";
                ddlCandType.DataValueField = "MemType";
                ddlCandType.DataBind();
                ddlCandType.SelectedValue = Request.QueryString["AgtType"].ToString();
            }
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
    #endregion
    #region fill candidate type
    private void FillCndAgntTypeOnCndType(string strbiz, string strChn, string strcndtype)
    {
        try
        {
            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@BizSrc", strbiz);
            htParam.Add("@Chncls", strChn);
            htParam.Add("@CandType", strcndtype);
            dsresult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndAgnTypeOnCndType", htParam);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlCandType.DataSource = dsresult;
                ddlCandType.DataTextField = "MemTypeDesc01";
                ddlCandType.DataValueField = "IS";
                ddlCandType.DataBind();
                dsresult = null;
            }
            else
            {
            }
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
    #endregion

    private void subPopulateAddress()
    {
        try
        {
            oCommon.getDropDown(ddlProofAddr, "NBAddProof", 1, "", 0, c_strBlank);
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

    private void subPopulateKnownLanguage()
    {
        try
        {
            oCommon.getDropDown(ddllanknow1, "KnownLng", 1, "", 1, c_strBlank);
            oCommon.getDropDown(ddllanknow2, "KnownLng", 1, "", 1, c_strBlank);
            oCommon.getDropDown(ddllanknow3, "KnownLng", 1, "", 1, c_strBlank);
            oCommon.getDropDown(ddllanknow4, "KnownLng", 1, "", 1, c_strBlank);
            PopulatePreExmLanguages();
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

    private void CnctType(Boolean blnNew)
    {
        try
        {
            ListItem[] items = new ListItem[1];

            string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();

            ddlCnctType.Items.Clear();
            if (blnNew)
                dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper() + "'";
            ddlCnctType.DataBind();
            ddlCnctType.Items.Insert(0, new ListItem("Select", ""));
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

    #region ddlagntype_SelectedIndexChanged
    protected void ddlagntype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlagntype.SelectedIndex == 0)
        {
            ddlAvgMonthlyIncm.Items.Clear();
            ddlAvgMonthlyIncm.Items.Insert(0, "Select");
            ddlAvgMonthlyIncm.Enabled = false;
        }
        else
        {
            ddlAvgMonthlyIncm.Enabled = true;
        }
        if (ddlagntype.SelectedValue == "2")
        {
            oCommon.getDropDown(ddlTypeOfVehicle, "Vec_Typ", 1, "", 1);
            VechicleManufacturer();
            ddlTypeOfVehicle.Items.Insert(0, "Select");
            txtDlrCompName.Enabled = true;
            txtDlrOth.Enabled = true;
            ddlTypeOfVehicle.Enabled = true;
            ddlVechManuf.Enabled = true;
        }
        else
        {
            ddlTypeOfVehicle.Items.Clear();
            ddlVechManuf.Items.Clear();
            ddlTypeOfVehicle.Items.Insert(0, "Select");
            ddlVechManuf.Items.Insert(0, "Select");
            txtDlrCompName.Text = "";
            txtDlrCompName.Enabled = false;
            txtDlrOth.Text = "";
            txtDlrOth.Enabled = false;
            ddlTypeOfVehicle.Enabled = false;
            ddlVechManuf.Enabled = false;
        }
        if (ddlagntype.SelectedIndex != 0)
        {
            AverageMonthlyIncome();
        }
        else
        {
        }
        if (ddlagntype.SelectedValue == "5")
        {
            txtOthers.Enabled = true;
        }
        else
        {
            txtOthers.Text = "";
            txtOthers.Enabled = false;
        }
    }
    #endregion

    #region AverageMonthlyIncome()
    private void AverageMonthlyIncome()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", ddlagntype.SelectedValue.Trim());
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlAvgMonthlyIncm.DataSource = dsresult;
                ddlAvgMonthlyIncm.DataTextField = "MnthVolVal";
                ddlAvgMonthlyIncm.DataValueField = "MnthVolCode";
                ddlAvgMonthlyIncm.DataBind();
            }
            else
            {
                ddlAvgMonthlyIncm.DataSource = null;
            }
            ddlAvgMonthlyIncm.Items.Insert(0, "Select");
            dsresult = null;
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

    #region YearsInInsurance()
    private void YearsInInsurance()
    {

        try
        {
            oCommon.getDropDown(ddlNoOfYrsIns, "YEARS", 1, "", 1);
            ddlNoOfYrsIns.Items.Insert(0, "Select");
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

    #region VechicleType()
    private void VechicleType()
    {
        try
        {
            if (ddlagntype.SelectedValue == "2")
            {
                oCommon.getDropDown(ddlTypeOfVehicle, "Vec_Typ", 1, "", 1);
            }
            else
            {
                ddlTypeOfVehicle.Enabled = false;
            }
            ddlTypeOfVehicle.Items.Insert(0, "Select");
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

    #region VechicleManufacturer()
    private void VechicleManufacturer()
    {
        try
        {
            if (ddlagntype.SelectedValue == "2")
            {
                DataSet dsresult = new DataSet();
                dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetddlVchlManf");
                ddlVechManuf.Items.Clear();
                ddlVechManuf.DataSource = dsresult;
                ddlVechManuf.DataTextField = "Make_Name";
                ddlVechManuf.DataValueField = "Make_ID_PK";
                ddlVechManuf.DataBind();
                ddlVechManuf.Items.Insert(0, "Select");
                dsresult = null;
            }
            else
            {
                ddlVechManuf.Enabled = false;
                ddlVechManuf.Items.Insert(0, "Select");
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

    #region PopulateAgentType()
    private void PopulateAgentType()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetddlAgnTyp");
            ddlagntype.DataSource = dsresult;
            ddlagntype.DataTextField = "AgnTypName";
            ddlagntype.DataValueField = "AgnTypCode";
            ddlagntype.DataBind();
            ddlagntype.Items.Insert(0, "Select");
            dsresult = null;
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

    #region Competitor Company volume()
    private void ComptCompyMonthlyVolum()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "ComptCmpny");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlMnthVol1.DataSource = dsresult;
                ddlMnthVol1.DataTextField = "MnthVolVal";
                ddlMnthVol1.DataValueField = "MnthVolCode";
                ddlMnthVol1.DataBind();
            }
            else
            {
                ddlMnthVol1.DataSource = null;
            }
            ddlMnthVol1.Items.Insert(0, "Select");
            dsresult = null;
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

    #region Competitor Company volume 2()
    private void ComptCompyMonthlyVolum2()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "ComptCmpny");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlMnthVol2.DataSource = dsresult;
                ddlMnthVol2.DataTextField = "MnthVolVal";
                ddlMnthVol2.DataValueField = "MnthVolCode";
                ddlMnthVol2.DataBind();
            }
            else
            {
                ddlMnthVol2.DataSource = null;
            }
            ddlMnthVol2.Items.Insert(0, "Select");
            dsresult = null;
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

    #region Business Monthly volume()
    private void BusinessMonthlyVol()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "BusiVol");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlRGIMnthVol.DataSource = dsresult;
                ddlRGIMnthVol.DataTextField = "MnthVolVal";
                ddlRGIMnthVol.DataValueField = "MnthVolCode";
                ddlRGIMnthVol.DataBind();
            }
            else
            {
                ddlRGIMnthVol.DataSource = null;
            }
            ddlRGIMnthVol.Items.Insert(0, "Select");
            dsresult = null;
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
    #endregion ddlRGIMnthVol

    #region CompetitorCompanyName1()
    //To display list of caste category from IsysLookupParam table
    private void CompetitorCompanyName1()
    {
        try
        {
            oCommon.getDropDown(ddlComp1Name, "ComptCompName", 1, "", 1);
            ddlComp1Name.Items.Insert(0, "Select");
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

    #region CompetitorCompanyName2()
    //To display list of caste category from IsysLookupParam table
    private void CompetitorCompanyName2()
    {
        try
        {
            oCommon.getDropDown(ddlComp2Name, "ComptCompName", 1, "", 1);
            ddlComp2Name.Items.Insert(0, "Select");
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

    #region TotalBusiness()
    private void TotalBusiness()
    {
        try
        {
            oCommon.getDropDown(ddlTotBsnMtr, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlTotBsnHlth, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnMtr, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnHlth, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlTotBsnComm, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnComm, "Tot_Busi", 1, "", 1);
            ddlTotBsnHlth.Items.Insert(0, "Select");
            ddlTotBsnMtr.Items.Insert(0, "Select");
            ddlRGIBsnMtr.Items.Insert(0, "Select");
            ddlRGIBsnHlth.Items.Insert(0, "Select");
            ddlTotBsnComm.Items.Insert(0, "Select");
            ddlRGIBsnComm.Items.Insert(0, "Select");
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

    #region YearsInReliance()
    //To display list of caste category from IsysLookupParam table
    private void YearsInReliance()
    {
        try
        {
            oCommon.getDropDown(ddlNoOfYrs, "YEARS", 1, "", 1);
            ddlNoOfYrs.Items.Insert(0, "Select");
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
    //Added by Prathamesh 8-6-15 end
    #endregion

    #region ddlIsWrkng_SelectedIndexChanged
    protected void ddlIsWrkng_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsWrkng.SelectedValue == "Y")
        {
            oCommon.getDropDown(ddlcompName, "CompyName", 1, "", 1);
            ddlcompName.Items.Insert(0, "Select");
            ddlcompName.Enabled = true;
        }
        else
        {
            ddlcompName.Items.Clear();
            ddlcompName.Items.Insert(0, "Select");
            ddlcompName.Enabled = false;
        }
    }
    //Added by Prathamesh from frmsub page end



    #endregion
    private void MailResponse(string AppCndNo)
    {
        try
        {
            //TO GET CANDIDATE TYPE
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@CndNo", ViewState["CandNo"]);
            dscandtype = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
            string strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();
            //Email Integration
            string strUserID = Session["UserID"].ToString();
            Hashtable htData = new Hashtable();
            DataSet ds = new DataSet();
            ds.Clear();
            htData.Add("@Param1", "CND");
            htData.Add("@Param2", strCndType);
            htData.Add("@Param3", "20");
            htData.Add("@Param4", "NR");
            ds = dataAccessclass.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                        objmail.SendNoticationMailSMS("ARTL", "CND", strCndType, "20", "NR", "", NotifyTo, AppCndNo, strUserID);
                    }
                }
            }
        }
        catch (Exception ex)
        {
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
    #region 'btnUpdate_Click' Event
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        #region Validation
        lblPANMsg.Text = "";
        FillProspectInfo();
        btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");
        //tab 2 validation
        if (cboTitle.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Title')", true);
            cboTitle.Focus();
            return;
        }
        if (txtGivenName.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Surname')", true);
            txtGivenName.Focus();
            return;
        }
        if (txtsurname.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter GivenName')", true);
            txtsurname.Focus();
            return;

        }
        if (txtCurrentID.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pan No')", true);
            txtCurrentID.Focus();
            return;

        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (txtDOB.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date Of Birth')", true);
                txtDOB.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (cboGender.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Gender')", true);
                cboGender.Focus();
                return;
            }

            if ((cboGender.SelectedIndex == 1 && cboTitle.SelectedIndex == 1) ||
                (cboGender.SelectedIndex == 2 && cboTitle.SelectedIndex == 2) ||
                (cboGender.SelectedIndex == 2 && cboTitle.SelectedIndex == 3))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert( 'Plese Select Valid Gender')", true);
                cboGender.Focus();
                return;
            }

        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (txtFathername.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Father/Spouse Name')", true);
                txtFathername.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (ddlRelwithFather.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Relationship with Agent')", true);
                ddlRelwithFather.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (ddlCasteCat.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Category')", true);
                ddlCasteCat.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (ddlCasteCat.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Category')", true);
                ddlCasteCat.Focus();
                return;
            }
        }
        if (ddlPrimProf.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Current Occupation')", true);
            ddlPrimProf.Focus();
            return;

        }
        if (ddlcategory.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Candidate Classification');</script>", false);
            ddlcategory.Focus();
            return;
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (cboMaritalStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Marital Status')", true);
                cboMaritalStatus.Focus();
                return;
            }
        }
        if (ddlCandidatetype.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Candidate Type')", true);
            ddlCandidatetype.Focus();
            return;
        }

        //tab 3
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "tab3Vali()", true);
        if (txtemail.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Email1')", true);
            ProgressBarModalPopupExtender.Hide();
            txtemail.Focus();
            return;
        }
        if (txtemail.Text != "")
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MultiView1.ActiveViewIndex = 0;

                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Email1');</script>", false);
                ProgressBarModalPopupExtender.Hide();
                txtemail.Focus();
                return;
            }


        }
        if (txtEmail2.Text != "")
        {
            string email = txtEmail2.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MultiView1.ActiveViewIndex = 0;

                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Email2');</script>", false);
                ProgressBarModalPopupExtender.Hide();
                txtEmail2.Focus();
                return;
            }
        }

        //tab 4
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "AddValid()", true);
        //tab 5
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "BankValid()", true);

        //tab 6
        if (txtNomneeEmail.Text != "")
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Nominee Email');</script>", false);
                txtNomneeEmail.Focus();
                return;
            }
        }
        if (txtNominMob.Text != "")
        {
            if ((txtNominMob.Text.Length != 10) || (txtNominMob.Text.Substring(0, 1) == "0")) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Nominee Mobile No.')", true);
                txtNominMob.Focus();
                return;
            }
            if ((txtNominMob.Text.Substring(0, 1) == "1") || (txtNominMob.Text.Substring(0, 1) == "2") || (txtNominMob.Text.Substring(0, 1) == "3")
                || (txtNominMob.Text.Substring(0, 1) == "4") || (txtNominMob.Text.Substring(0, 1) == "5")) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Nominee Mobile No Should Start With (6,7,8,9)')", true);
                txtNominMob.Focus();
                return;
            }
        }
        if (txtNomnPan.Text != "")
        {
            string pan = txtNomnPan.Text;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CheckPANFormat(" + pan + "');", true);
        }
        //Table 7
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "DocsExam()", true);

        #endregion end validation
        if (cbTrfrFlag.Checked == true)
            {
                if (gvTrnsfr.Rows.Count == 0)
                {

                    ProgressBarModalPopupExtender.Hide();
                    MultiView1.ActiveViewIndex = 0;
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                    lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Transfer details')", true);
                    ProgressBarModalPopupExtender.Hide();
                    cbTrfrFlag.Focus();
                    return;
                }
                if (txtIC.Text != "")
                {
                    if ((Convert.ToDateTime(txtIC.Text)) <= (Convert.ToDateTime(txtDOB.Text.Trim())))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date should not be less than or equal to birth date')", true);
                        txtIC.Focus();
                        return;
                    }
                }
                if (txtDateOfAppointmentTrnsfr.Text != "")
                {
                    if ((Convert.ToDateTime(txtDateOfAppointmentTrnsfr.Text)) <= (Convert.ToDateTime(txtDOB.Text.Trim())))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment as agent date should not be less than or equal to birth date')", true);
                        txtDateOfAppointmentTrnsfr.Focus();
                        return;
                    }
                }
            }
            
            if (cbTrfrFlag.Checked == true || cbTccCompLcn.Checked == true)
            {
                if (cbTrfrFlag.Checked == true)
                    txtOldTccLcnNo_TextChanged(this, EventArgs.Empty);
                if (cbTccCompLcn.Checked == true)
                    txtCompLicNo_TextChanged(this, EventArgs.Empty);
            }

            if (ViewState["UserTypeHO"].ToString() == "I")
            {
                btnVerifyEmpCode_Click(this, EventArgs.Empty);
                if (StrMsg == 1)
                {
                    lblEmpMsg.Visible = true;
                    lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                    lblEmpMsg.Text = "Employee is not allowed to recruit";//"No Match Found";
                    return;
                }
            }

            if (Request.QueryString["ACT"] != "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {

                string pan2 = ViewState["Pan"].ToString();
                if (txtCurrentID.Text != pan2)
                {
                    //btnVerifyPAN_Click(this, EventArgs.Empty);

                    if (hdnPan.Value != "1")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        lblMessage.Text = "Please Validate PAN No.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Validate PAN No.')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }

                }
            }

            if (Request.QueryString["Type"].ToString() == "N")
            {
                string pan2 = ViewState["Pan"].ToString();
                if (txtCurrentID.Text != pan2)
                {
                    //btnVerifyPAN_Click(this, EventArgs.Empty);

                    if (hdnPan.Value != "1")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        lblMessage.Text = "Please Validate PAN No.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Validate PAN No.')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }
            }
            ArrayList arrResult = new ArrayList();
            string sessionuser = string.Empty;
            int iAppno;
            DateTime DOBdate;
            DateTime CntDate;
            bool bIsValidDate;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }

            try
            {
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    if (txtOldTccLcnNo.Text != txtCompLicNo.Text)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License No and Life License No must be same')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }

                if (txtDate.Text.ToString().Trim() != "")//txtOldTccLcnExpDate
                {
                    if ((Convert.ToDateTime(txtDate.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {

                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Transfer should not be past date')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }

                if (txtCompLicExpDt.Text.ToString().Trim() != "")//txtOldTccLcnExpDate
                {
                    if ((Convert.ToDateTime(txtCompLicExpDt.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {

                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Composite should not be past date')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                    if ((Convert.ToDateTime(txtCompLicExpDt.Text)) < (Convert.ToDateTime(DateTime.Now.AddMonths(+6))))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please ask candidate to renew life license first.')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }

                if (txtYrPass.Text.ToString().Trim() != "")
                {
                    if ((Convert.ToDateTime(txtYrPass.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        MultiView1.ActiveViewIndex = 0;
                        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of passing should not be greater than current date')", true);
                        txtYrPass.Focus();
                        return;
                    }
                    if (ChkPA.Checked)
                    {
                        txtPermAdd1.Text = txtAddrP1.Text;
                        txtPermAdd2.Text = txtAddrP2.Text;
                        txtPermAdd3.Text = txtAddrP3.Text;
                        txtpermvillage.Text = txtVillage.Text;
                        txtPermCountryCode.Text = txtCountryCodeP.Text;
                        txtPermCountryDesc.Text = txtCountryDescP.Text;
                        ddlstate1.Text = ddlState.Text;
                        txtpermDistrict.Text = txtDistric.Text;
                        txtcity1.Text = txtcity.Text;
                        txtarea1.Text = txtarea.Text;
                        txtPermPostcode.Text = txtPinP.Text;
                    }
                    //return;
                }

                if (txtYrPass.Text.ToString().Trim() != "")
                {
                    if ((Convert.ToDateTime(txtYrPass.Text)) < (Convert.ToDateTime(txtDOB.Text.Trim())))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of passing should not be less than birth date')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;

                    }
                }

                if (ViewState["IsSpPrsnValue"].ToString().Trim() == "YES")
                {
                    if (rbtIsSP.SelectedValue == "")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Is Specified Person')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;


                    }

                    if (rbtIsSP.SelectedValue == "Y")
                    {
                        if (txtCACode.Text == "")
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Corporate Agent Code is Mandatory')", true);
                            if (ChkPA.Checked)
                            {
                                txtPermAdd1.Text = txtAddrP1.Text;
                                txtPermAdd2.Text = txtAddrP2.Text;
                                txtPermAdd3.Text = txtAddrP3.Text;
                                txtpermvillage.Text = txtVillage.Text;
                                txtPermCountryCode.Text = txtCountryCodeP.Text;
                                txtPermCountryDesc.Text = txtCountryDescP.Text;
                                ddlstate1.Text = ddlState.Text;
                                txtpermDistrict.Text = txtDistric.Text;
                                txtcity1.Text = txtcity.Text;
                                txtarea1.Text = txtarea.Text;
                                txtPermPostcode.Text = txtPinP.Text;
                            }
                            return;
                        }
                        if (txtCAName.Text == "")
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Corporate Agent Name  is Mandatory')", true);
                            if (ChkPA.Checked)
                            {
                                txtPermAdd1.Text = txtAddrP1.Text;
                                txtPermAdd2.Text = txtAddrP2.Text;
                                txtPermAdd3.Text = txtAddrP3.Text;
                                txtpermvillage.Text = txtVillage.Text;
                                txtPermCountryCode.Text = txtCountryCodeP.Text;
                                txtPermCountryDesc.Text = txtCountryDescP.Text;
                                ddlstate1.Text = ddlState.Text;
                                txtpermDistrict.Text = txtDistric.Text;
                                txtcity1.Text = txtcity.Text;
                                txtarea1.Text = txtarea.Text;
                                txtPermPostcode.Text = txtPinP.Text;
                            }
                            return;
                        }
                    }
                    if (rbtIsSP.SelectedValue == "Y" && cbTrfrFlag.Checked == true)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Is Specified Person cannot be of Transfer Case')", true);
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }

                }

                if (txtReferredBy.Text != "")
                {
                    if (hdnRefBy.Value != "1")
                    {
                        lblMessage.Text = "Please validate Referred By Advisor";
                        txtReferredBy.Focus();
                        return;
                    }
                }

                if (Request.QueryString["ACT"] != "PR" && Request.QueryString["Type"] != "E" && Request.QueryString["ProspectId"] != null)
                {
                    if (hdnPan.Value != "1")
                    {
                        lblMessage.Text = "Please Validate PAN No.";
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }

                if (Request.QueryString["Type"] == "N")
                {
                    if (hdnPan.Value != "1")
                    {
                        lblMessage.Text = "Please validate PAN No.";
                        if (ChkPA.Checked)
                        {
                            txtPermAdd1.Text = txtAddrP1.Text;
                            txtPermAdd2.Text = txtAddrP2.Text;
                            txtPermAdd3.Text = txtAddrP3.Text;
                            txtpermvillage.Text = txtVillage.Text;
                            txtPermCountryCode.Text = txtCountryCodeP.Text;
                            txtPermCountryDesc.Text = txtCountryDescP.Text;
                            ddlstate1.Text = ddlState.Text;
                            txtpermDistrict.Text = txtDistric.Text;
                            txtcity1.Text = txtcity.Text;
                            txtarea1.Text = txtarea.Text;
                            txtPermPostcode.Text = txtPinP.Text;
                        }
                        return;
                    }
                }
                
                bIsValidDate = IsValidDate(txtDOB.Text.Trim(), txtDOB.Text.Trim());

                if (!(bIsValidDate))
                {
                    return;
                }
                else
                {
                    DOBdate = DateTime.Parse(txtDOB.Text.Trim());
                    CntDate = DateTime.Parse(DateTime.Now.ToString(CommonUtility.DATE_FORMAT));

                    if (checkDOB(DOBdate, CntDate) == 0)
                    {
                        lblMessage.Text = hdnDOB.Value;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        #region "htParam.Add"

                        htParam.Clear();
                        htParam.Clear();
                        lblMessage.Text = "";
                        if (txtcndid.Text.Trim() != null)
                        {
                            //Added by rachana on 07-12-2013 to pass parameter at the time of update only start
                            if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "Rev")
                            {
                                htParam.Add("@CndNo", txtcndid.Text.Trim());

                            }
                            //Added by rachana on 07-12-2013 to pass parameter at the time of update only end
                        }
                        htParam.Add("@CndCat", ddlcategory.SelectedValue.Trim());

                        #region Invisible Controls
                        //Invisible below controls
                        htParam.Add("@PrefExmLng", System.DBNull.Value);

                        htParam.Add("@Exam", System.DBNull.Value);

                        htParam.Add("@ECCode", System.DBNull.Value);
                        //htParam.Add("@YFrmNo", System.DBNull.Value);
                        htParam.Add("@TrnMode", System.DBNull.Value);
                        htParam.Add("@TrnLoc", System.DBNull.Value);
                        htParam.Add("@ExmBody", System.DBNull.Value);

                        #endregion

                        htParam.Add("@AppNo", txtapplicationno.Text.Trim());
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        if (txtregdate.Text.Trim() != "")
                        {
                            htParam.Add("@EntryDate", DateTime.Parse(txtregdate.Text.Trim()).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            htParam.Add("@EntryDate ", System.DBNull.Value);
                        }
                        htParam.Add("@Title", cboTitle.SelectedValue.ToString());
                        htParam.Add("@GivenName", txtGivenName.Text.Trim());
                        htParam.Add("@Surname", txtsurname.Text.Trim());
                        htParam.Add("@FatherName", txtFathername.Text.Trim());
                        htParam.Add("@Relation", ddlRelwithFather.SelectedValue.Trim());//added by rachana on 20-04-2015 for relation
                        htParam.Add("@Gender", cboGender.SelectedValue.Trim());
                        if (txtDOB.Text.Trim() != "")
                        {
                            htParam.Add("@BirthRegDate", DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            htParam.Add("@BirthRegDate ", System.DBNull.Value);
                        }
                        htParam.Add("@BirthRegPlace", txtplaceofbirthpersonal.Text.Trim());
                        htParam.Add("@MaritalStat", cboMaritalStatus.SelectedValue.Trim());
                        htParam.Add("@Nationality", txtNationalCode.Text.Trim());
                        htParam.Add("@CnctType", ddlCnctType.SelectedValue.Trim());
                        htParam.Add("@Adr2", txtAddrP2.Text.Trim());
                        htParam.Add("@Adr3", txtAddrP3.Text.Trim());
                        htParam.Add("@Adr1", txtAddrP1.Text.Trim());
                        htParam.Add("@StateCode", ddlState.SelectedValue.Trim());
                        htParam.Add("@CntryCode", txtCountryCodeP.Text.Trim());
                        htParam.Add("@City", txtcity.Text.Trim());
                        htParam.Add("@Area", txtarea.Text.Trim());
                        htParam.Add("@District", txtDistric.Text.Trim());
                        htParam.Add("@PostCode", txtPinP.Text.Trim());
                        htParam.Add("@HomeTel", txthometel.Text.Trim());
                        htParam.Add("@WorkTel", txtWorkTel.Text.Trim());
                        htParam.Add("@MobileCode", txtmobcode.Text.Trim());
                        htParam.Add("@MobileTel", txtMobileTel.Text.Trim());
                        htParam.Add("@Email", txtemail.Text.Trim().ToLower());
                        htParam.Add("@MobileCode2", txtmobcode2.Text.Trim());
                        htParam.Add("@Mobile2", txtMobile2.Text.Trim());
                        htParam.Add("@Email2", txtEmail2.Text.Trim());
                        htParam.Add("@WorkFax", txtfax.Text.Trim());
                        htParam.Add("@DidTel", txtdidtel.Text.Trim());
                        htParam.Add("@pager", txtpager.Text.Trim());
                        htParam.Add("@DrMailID", cbdirectmail.Checked == true ? "1" : "0");
                        if (this.ddlDstbnMethod.SelectedValue.Trim() != "Select")
                        {
                            htParam.Add("@DstbnMethod", this.ddlDstbnMethod.SelectedValue.Trim());
                        }
                        else
                        {
                            htParam.Add("@DstbnMethod", System.DBNull.Value);
                        }


                        htParam.Add("@Pan", System.DBNull.Value);
                        htParam.Add("@PayableAt", "");
                        //if (Request.QueryString["Type"] == "N")
                        if (ViewState["UserTypeHO"].ToString() == "E")
                        {

                            //chk
                            htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue.Trim());
                            htParam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                            htParam.Add("@AgentType", Convert.ToString(ddlAgntType.SelectedValue).Trim());
                            htParam.Add("@DirectAgtCode", txtrecagent.Text.Trim());
                            htParam.Add("@RecruitAgtName", txtrecagtname.Text.Trim());
                            htParam.Add("@RecruitAgtCode", txtrecagent.Text.Trim());
                            ddlCandType.SelectedValue = null;
                            htParam.Add("@CndAgntType", ddlCandType.SelectedValue);//Added by rachana
                        }
                        else
                        {
                            //commended by usha  for emerzing 

                            // htParam.Add("@Bizsrc", ViewState["Bizsrc"]);
                            // htParam.Add("@ChnCls", ViewState["ChnCls"]);
                            //AddedC by usha 
                            htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue.Trim());
                            htParam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                            //ended by usha
                            htParam.Add("@AgentType", ViewState["AgentType"].ToString());
                            htParam.Add("@DirectAgtCode", ViewState["MemberCode"].ToString());
                            htParam.Add("@empcode", txtEmpCode.Text.Trim());//usa

                            //by meena prospect branchcode
                            var dt = (DataTable)Session["unt"];
                            string strUnitCode = string.Empty;
                            if (dt != null)
                            {

                                strUnitCode = dt.Rows[0]["UnitCode"].ToString();
                                htParam.Add("@cmsunitcode", strUnitCode);

                            }
                            else
                            {
                                // htParam.Add("@RecUntCode", strUnitCode);

                                htParam.Add("@cmsunitcode", ViewState["cmsunitcode"]);

                            }
                            //by meena prospect branchcode
                            htParam.Add("@RecruitAgtName", ViewState["AgentName"]);
                            htParam.Add("@RecruitAgtCode", ViewState["MemberCode"].ToString());
                            htParam.Add("@CndAgntType", ddlCandType.SelectedValue);//Added by rachana
                        }
                        //end chk

                        if (ddleducationproof.SelectedIndex != 0)
                        {
                            htParam.Add("@ProofIDDoc", ddleducationproof.SelectedValue.Trim());
                        }
                        else
                        {
                            htParam.Add("@ProofIDDoc", System.DBNull.Value);
                        }
                        
                        htParam.Add("@HasPhoto", "Y");
                        htParam.Add("@HasMarkSheet", cbmarksheet.Checked == true ? "Y" : "F");
                        htParam.Add("@HasCertificate", cbcertificate.Checked == true ? "Y" : "F");
                        htParam.Add("@HasPanchayat", cbPanachayat.Checked == true ? "Y" : "F");
                        htParam.Add("@HasNocAck", chkNOCAck.Checked == true ? "Y" : "F");
                        htParam.Add("@TrfrFlag", cbTrfrFlag.Checked == true ? "1" : "0");
                        if (cbTrfrFlag.Checked == true)
                        {
                            htParam.Add("@NOCFlag", RbtNoc.SelectedValue == "Y" ? "1" : "0");
                            if (RbtNoc.SelectedValue == "Y")
                            {
                                htParam.Add("@RbAckFlag", System.DBNull.Value);
                            }
                            else
                            {
                                //added by pranjali on 20-03-2014 start
                                htParam.Add("@RbAckFlag", RbAckRev.SelectedValue == "Y" ? "1" : "0");
                                //added by pranjali on 20-03-2014 end
                            }
                        }
                        else
                        {
                            htParam.Add("@NOCFlag", System.DBNull.Value);
                            htParam.Add("@RbAckFlag", System.DBNull.Value);
                        }
                        htParam.Add("@LUnitCode", txtUnitCode.Value.Trim());
                        htParam.Add("@OldTccLcnNo", txtOldTccLcnNo.Text.Trim());
                        if (txtDate.Text.Trim() != "")//txtOldTccLcnExpDate
                        {
                            htParam.Add("@OldTccLcnExpDate", DateTime.Parse(txtDate.Text.Trim()).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            htParam.Add("@OldTccLcnExpDate ", System.DBNull.Value);
                        }
                        if (ddlTrnsfrInsurName.SelectedIndex != 0)
                        {
                            htParam.Add("@OldTccPrevInsrName", ddlTrnsfrInsurName.SelectedValue.Trim());//added by pranjali on 13-03-2014
                        }
                        else
                        {
                            htParam.Add("@OldTccPrevInsrName", System.DBNull.Value);
                        }
                        if (txtLicIssueDt.Text.Trim() != "")//txtOldTccLcnExpDate
                        {
                            htParam.Add("@LicIssueDt", DateTime.Parse(txtLicIssueDt.Text.Trim()).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            htParam.Add("@LicIssueDt", System.DBNull.Value);
                        }
                        htParam.Add("@TccCompLcn", cbTccCompLcn.Checked == true ? "1" : "0");
                        htParam.Add("@CompLicNo", txtCompLicNo.Text.Trim());
                        if (txtCompLicExpDt.Text.Trim() != "")//txtOldTccLcnExpDate
                        {
                            htParam.Add("@CompLicExpDt", DateTime.Parse(txtCompLicExpDt.Text.Trim()).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            htParam.Add("@CompLicExpDt", System.DBNull.Value);
                        }
                        if (ddlCompInsurerName.SelectedIndex != 0)
                        {
                            htParam.Add("@CompInsrName", ddlCompInsurerName.SelectedValue.Trim());
                        }
                        else
                        {
                            htParam.Add("@CompInsrName", System.DBNull.Value);
                        }
                        htParam.Add("@Village", txtVillage.Text.Trim());
                        htParam.Add("@PhotoSignFlag", "N");
                        htParam.Add("@CasteCat", ddlCasteCat.SelectedValue.ToString().Trim());
                        htParam.Add("@PrimProf", ddlPrimProf.SelectedValue.ToString().Trim());
                        htParam.Add("@BasicQual", ddlBasicQual.SelectedValue.ToString().Trim());
                        if (txtBoardName.Text.Trim() != "")
                        {
                            if (IsAlphaNumeric(txtBoardName.Text) == false)
                            {
                                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Board Name: Special Characters are not Allowed');</script>");
                                lblMessage.Text = "Board Name: Special Characters are not Allowed";
                                lblMessage.Visible = true;
                                return;
                            }

                            htParam.Add("@BasicBoardName", txtBoardName.Text.Trim().ToUpper());
                        }
                        else
                        {
                            htParam.Add("@BasicBoardName", System.DBNull.Value);
                        }

                        htParam.Add("@BasicRNo", txtBasicRNo.Text.Trim());
                        if (txtYrPass.Text.Trim() != "")
                        {
                            htParam.Add("@BasicYrPass", DateTime.Parse(txtYrPass.Text.Trim()).ToString("yyyyMMdd"));
                        }

                        else
                        {
                            htParam.Add("@BasicYrPass", System.DBNull.Value);
                        }

                        htParam.Add("@ReferredBy", txtReferredBy.Text);
                        htParam.Add("@ReferredEmpBy", txtReferredEmpBy.Text);
                        htParam.Add("@ReferredName", txtRefByadvEmpName.Text.ToString().Trim());
                        htParam.Add("@RegRemark", "");
                        htParam.Add("@ModuleID", "");
                    //--
                    Hashtable htC = new Hashtable();
                    ArrayList arrResultC = new ArrayList();
                    htC.Add("@ProspectId", txtcndid.Text.Trim());
                    htC.Add("@AccholdrName", txtbnkhldname.Text.Trim().ToUpper());
                    htC.Add("@AccntNo", txtbnkacno.Text.Trim().ToUpper());
                    htC.Add("@BnkName", txtbnkname.SelectedValue);
                    htC.Add("@BrnchName", txtbrnchname.Text.ToString().Trim());
                    htC.Add("@AccType", ddlactype.Text.Trim());
                    htC.Add("@IFSC", txtifsccode.Text.Trim());
                    htC.Add("@MCR", txtmicrcode.Text.Trim());
                    htC.Add("@GSTNO", txtGSTNO.Text.Trim());
                    htC.Add("@CreateBy", sessionuser);
                    htC.Add("@Bdfor", "C");
                    arrResultC = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htC, "Prc_Ins_TblBankDtls");
                    //---Nominee
                    Hashtable htN = new Hashtable();
                    ArrayList arrResultN = new ArrayList();
                    htN.Add("@ProspectId", txtcndid.Text.Trim());
                    htN.Add("@NomineeName", txtNominee.Text);
                    htN.Add("@AdvRelation", Ddlrelation.SelectedValue.Trim());
                    htN.Add("@NomineeAge", txtNomineeAge.Text);
                    htN.Add("@NomineeEmailID", txtNomneeEmail.Text);
                    htN.Add("@NomineeMobileTel", txtNominMob.Text);
                    htN.Add("@NomineePAN", txtNomnPan.Text);
                    htN.Add("@AccntNo", txtnmbnkacno.Text.Trim().ToUpper());
                    htN.Add("@AccType", ddlactype.Text.Trim());
                    htN.Add("@BrnchName", ddlnmBrnchname.SelectedValue.ToString().Trim());
                    htN.Add("@IFSC", ddlnmifscode.Text.Trim());
                    htN.Add("@MCR", txtnmmicr.Text.Trim());
                    htN.Add("@AcHolderName", ddlnmbnkhldname.Text.Trim());
                    htN.Add("@CreateBy", sessionuser);
                    htN.Add("@BankName", ddlnmBnkname.SelectedValue.ToString().Trim());
                    arrResultN = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htN, "Prc_Ins_NomineeDetails");
                    //--

                    //htParam.Add("@NomineeName", txtNominee.Text);
                    //htParam.Add("@AdvRelation", Ddlrelation.SelectedValue.Trim());
                    //htParam.Add("@NomineeAge", txtNomineeAge.Text);
                    //htParam.Add("@NomineeEmailID", txtNomneeEmail.Text);
                    //htParam.Add("@NomineeMobileTel", txtNominMob.Text);
                    //htParam.Add("@NomineePAN", txtNomnPan.Text);//added by ajay 26-10-2022
                    //htParam.Add("@AccholdrName", txtbnkhldname.Text.Trim().ToUpper());
                    //htParam.Add("@AccntNo", txtbnkacno.Text.Trim().ToUpper());
                    //htParam.Add("@BnkName", txtbnkname.Text.Trim());
                    //htParam.Add("@BrnchName", txtbrnchname.Text.Trim().ToUpper());
                    //htParam.Add("@AccType", ddlactype.Text.Trim());
                    //htParam.Add("@IFSC", txtifsccode.Text.Trim());
                    //htParam.Add("@MCR", txtmicrcode.Text.Trim());//
                    if (ddlAddRptMgrCode.SelectedValue != "--Select--")
                        {
                            htParam.Add("@AddMgrCode", ddlAddRptMgrCode.SelectedValue.ToString());
                        }
                        else
                        {
                            htParam.Add("@AddMgrCode", System.DBNull.Value);
                        }
                        if (ViewState["IsSpPrsnValue"].ToString().Trim() == "YES")
                        {
                            if (rbtIsSP.SelectedValue.Trim() != "")
                            {
                                htParam.Add("@IsSPFlag", rbtIsSP.SelectedValue == "Y" ? "Y" : "N");
                            }
                            else
                            {
                                htParam.Add("@IsSPFlag", System.DBNull.Value);
                            }
                            if (rbtIsSP.SelectedValue == "Y")
                            {
                                htParam.Add("@CACode", txtCACode.Text.ToString().Trim());
                                htParam.Add("@CAName", txtCAName.Text.ToString().Trim());
                            }
                            else
                            {
                                htParam.Add("@CACode", System.DBNull.Value);
                                htParam.Add("@CAName", System.DBNull.Value);
                            }
                        }
                        else
                        {
                            htParam.Add("@IsSPFlag", System.DBNull.Value);
                            htParam.Add("@CACode", System.DBNull.Value);
                            htParam.Add("@CAName", System.DBNull.Value);
                        }
                        #endregion

                        #region Validate Cnd whether exist or not as a client?

                        #endregion



                        if (Request.QueryString["Type"] == "N")
                        {
                            #region "Add mode for Candidate"
                            httable.Clear();
                            htParam.Add("@CreateBy", sessionuser);
                            httable.Add("@CndNo", txtcndid.Text);
                            httable.Add("@AppNo", txtapplicationno.Text.Trim());
                            iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));
                            if (iAppno == 0)
                            {
                                htParam.Add("@PANNo", txtCurrentID.Text.Trim());
                                var dt = (DataTable)Session["unt"];
                                htParam.Add("@RecUntCode", ViewState["cmsunitcode"]);

                                //arrResult = clsCndReg.InsertAgentDetailsFirst(htParam, "prc_CndAdmin_InsCnd1");
                                arrResult = clsCndReg.InsertAgentDetailsFirst(htParam, "Prc_Ins_CndAdmin");
                                if (arrResult[0].ToString() == "0")
                                {
                                    string appno = arrResult[2].ToString().Trim();
                                    txtcndid.Text = arrResult[1].ToString();
                                    hdnSave.Value = "Candidate registered successfully";
                                    lblMessage.Text = hdnSave.Value;
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + hdnSave.Value + "' + '\nNote :- Please proceed to candidate approval after candidate registration.')", true); //Added by kalyni on 2-1-2014 to show message pupup 
                                    lblMessage.Visible = true;
                                    if (Request.QueryString["Type"] == "N")
                                    {
                                        txtapplicationno.Text = arrResult[2].ToString();
                                    }
                                    BindGrid(txtcndid.Text, txtapplicationno.Text);
                                    lbl.Text = hdnSave.Value + "</br></br>Candidate Name:" + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "</br>Recruiter code: " + txtEmpCode.Text + "</br> Application No:" + arrResult[2].ToString() +
                                       "<br/>Note :- Please proceed to sponsorship request after candidate registration";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                    lblMessage.Text = hdnSave.Value;
                                    lblMessage.Visible = true;
                                    ProgressBarModalPopupExtender.Hide();
                                    if (ChkPA.Checked)
                                    {
                                        txtPermAdd1.Text = txtAddrP1.Text;
                                        txtPermAdd2.Text = txtAddrP2.Text;
                                        txtPermAdd3.Text = txtAddrP3.Text;
                                        txtpermvillage.Text = txtVillage.Text;
                                        txtPermCountryCode.Text = txtCountryCodeP.Text;
                                        txtPermCountryDesc.Text = txtCountryDescP.Text;
                                        ddlstate1.Text = ddlState.Text;
                                        txtpermDistrict.Text = txtDistric.Text;
                                        txtcity1.Text = txtcity.Text;
                                        txtarea1.Text = txtarea.Text;
                                        txtPermPostcode.Text = txtPinP.Text;
                                    }

                                    if (lblMessage.Text.ToString() != "Candidate registered successfully")
                                    {
                                        btnUpdate.Enabled = true;
                                    }

                                    ModeEdit();
                                }
                                else
                                {
                                    if (arrResult[0].ToString() == "-2")
                                    {
                                        lblMessage.Text = "Category is mandatory.";
                                        lblMessage.ForeColor = Color.Red;
                                        lblMessage.Visible = true;
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Proc. mandatory parameters are missing";
                                        lblMessage.ForeColor = Color.Red;
                                        lblMessage.Visible = true;
                                    }
                                }

                            }
                            else
                            {
                                lblMessage.Text = hdnAppno.Value;
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = true;
                            }
                            #endregion
                        }
                        else
                        {
                            #region "Edit Mode (through Prospect Registration)for Condidate"
                            htParam.Add("@UpdateBy", sessionuser);
                            httable.Clear();
                            httable.Add("@AppNo", txtapplicationno.Text.Trim());
                            httable.Add("@CndNo", txtcndid.Text.Trim());

                            iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));

                            if (iAppno == 0)
                            {
                                //htParam.Clear();
                                //Added by Darshik for Pan updation 2.3.2012


                                htParam.Add("@PANNo", txtCurrentID.Text.Trim());
                                //htParam.Add("@AdharNo", txtaadhr.Text.Trim());//added by amruta on 22/9/16
                                //Added by AshishP 07-04-2018 AadharEncrypt
                                //if (txtaadhr.Text != "")
                                //{

                                // COmmented BY Daksh cause aadhar is NON Mandate on 26-11-2019

                                //string strAadharReponse = AadharVault.AadharEncrypt(txtaadhr.Text);
                                //AadharVault.AadharResponse AadharResponse = new AadharVault.AadharResponse();
                                //AadharVault.AadharResponse deserializedAadharResponse = JsonConvert.DeserializeObject<AadharVault.AadharResponse>(strAadharReponse);

                                //if (deserializedAadharResponse.Errorcode == "" && deserializedAadharResponse.Response != "")
                                //{
                                //    htParam.Add("@AdharNo", deserializedAadharResponse.Response.ToString().Trim());
                                //}

                                //END COmmented BY Daksh cause aadhar is NON Mandate on 26-11-2019
                                //}
                                //Added by AshishP 07-04-2018 AadharEncrypt

                                htParam.Add("@ProspectId", Request.QueryString["ProspectId"].ToString());
                                //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from registration BY prospect id START 

                                //comment by Prathamesh 6-7-15 
                                arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_CndAdmin_UpdCnd_ProspectArtl");

                                //////Added by Prathamesh 6-7-15 for save the Profiling data'
                                //arrResult = clsCndReg.UpdateAgentDetails(htparams, "prc_UpdCndProfiling");

                                //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from registration BY prospect id START 
                                if (arrResult[0].ToString() == "0")
                                {

                                    //string appno = arrResult[1].ToString().Trim();
                                    string appno = txtapplicationno.Text.Trim();
                                    ViewState["CandNo"] = arrResult[1].ToString().Trim();
                                    strProspectID = arrResult[1].ToString().Trim();
                                    //MailResponse(appno);

                                    hdnUpdate.Value = "Candidate registered successfully";
                                    btnUpdate.Enabled = false;// usa
                                    // btnUpdate.Enabled = true;
                                    lblMessage.Text = hdnUpdate.Value;
                                    lblMessage.ForeColor = Color.Red;
                                    lblMessage.Visible = true;
                                    txtcndid.Text = arrResult[1].ToString();
                                    BindGrid(txtcndid.Text, txtapplicationno.Text);//added by amruta
                                    lbl.Text = hdnUpdate.Value + "</br></br>Candidate No: " + txtcndid.Text.Trim() + "<br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Recruiter code: " + txtEmpCode.Text
                                        + "</br> Application No:" + Request.QueryString["ProspectId"].ToString() +
                                        "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration";//Added by kalyni on 2-1-2014 to show note on message pupup
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                    ModeEdit();//Added by rachana on 10/04/2014 to enable other 4 tabs for edit
                                    //ProgressBarModalPopupExtender.Hide();
                                }
                                else
                                {

                                    switch (arrResult[0].ToString())
                                    {
                                        case "-1":
                                            lblMessage.Text = "Education Proof is Mandatory!";
                                            lblMessage.ForeColor = Color.Red;
                                            lblMessage.Visible = true;
                                            break;
                                    }
                                }

                            }
                            else
                            {
                                lblMessage.Text = hdnAppno.Value;
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = false; 
                            }
                            #endregion
                            #region for normal update for candidate
                            if (iAppno == 1)
                            {
                                if (Request.QueryString["CndNo"] != null && Request.QueryString["ACT"] == "Rev")
                                {
                                    arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_CndAdmin_UpdCnd1_Rev");
                                    BindGrid(txtcndid.Text, txtapplicationno.Text);//added by nikhil 9.8.15
                                }
                                else
                                {
                                    htParam.Add("@PANNo", txtCurrentID.Text);

                                    arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_CndAdmin_UpdCnd1");

                                    BindGrid(txtcndid.Text, txtapplicationno.Text);
                                }

                                if (arrResult[0].ToString() == "0")
                                {
                                    if (Request.QueryString["type"] == "E")
                                    {
                                        htParam.Clear();
                                        DataSet dsOTP = new DataSet();
                                        htParam.Add("@CndNo", txtcndid.Text);
                                        dsOTP = dataAccessclass.GetDataSetForPrcRecruit("prc_UPDCndModifyFlag", htParam);
                                    }

                                }
                            }
                            #endregion
                        }
                    }
                }
                if (Request.QueryString["Type"] == "N")
                {
                    #region "Add mode for Candidate"
                    httable.Clear();
                    httable.Add("@CndNo", txtcndid.Text);
                    httable.Add("@AppNo", txtapplicationno.Text.Trim());
                    iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));
                    if (iAppno == 0)
                    {
                        arrResult = clsCndReg.InsertAgentDetailsFirst(htParam, "prc_CndAdmin_InsCnd1");
                        if (arrResult[0].ToString() == "0")
                        {
                            string appno = arrResult[2].ToString().Trim();
                            txtcndid.Text = arrResult[1].ToString();
                            hdnSave.Value = "successfully.";
                            lblMessage.Text = hdnSave.Value;
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + hdnSave.Value + "' + '\nNote :- Please proceed to candidate approval after candidate registration.')", true); //Added by kalyni on 2-1-2014 to show message pupup 
                            lblMessage.Visible = true;
                            if (Request.QueryString["Type"] == "N")
                            {
                                txtapplicationno.Text = arrResult[2].ToString();
                            }
                            lbl.Text = hdnSave.Value + "</br></br>Candidate ID: " + arrResult[1].ToString() + "</br>Candidate Name:" + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "</br>Recruiter code: " + txtEmpCode.Text + "</br> Application No:" + arrResult[2].ToString() +
                                "<br/>Note :- Please proceed to sponsorship request after candidate registration.";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                            lblMessage.Text = hdnSave.Value;
                            lblMessage.Visible = true;
                            if (ChkPA.Checked)
                            {
                                txtPermAdd1.Text = txtAddrP1.Text;
                                txtPermAdd2.Text = txtAddrP2.Text;
                                txtPermAdd3.Text = txtAddrP3.Text;
                                txtpermvillage.Text = txtVillage.Text;
                                txtPermCountryCode.Text = txtCountryCodeP.Text;
                                txtPermCountryDesc.Text = txtCountryDescP.Text;
                                ddlstate1.Text = ddlState.Text;
                                txtpermDistrict.Text = txtDistric.Text;
                                txtcity1.Text = txtcity.Text;
                                txtarea1.Text = txtarea.Text;
                                txtPermPostcode.Text = txtPinP.Text;
                            }

                            if (lblMessage.Text.ToString() != "Candidate registered successfully")
                            {
                                btnUpdate.Enabled = true;
                            }

                            ModeEdit();
                        }
                        else
                        {
                            if (arrResult[0].ToString() == "-2")
                            {
                                lblMessage.Text = "Category is mandatory.";
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = true;
                            }
                            else
                            {
                                lblMessage.Text = "Proc. mandatory parameters are missing";
                                lblMessage.ForeColor = Color.Red;
                                lblMessage.Visible = true;
                            }
                        }

                    }
                    else
                    {
                        lblMessage.Text = hdnAppno.Value;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                    #endregion
                }
                else
                {
                    #region "Edit Mode (through Prospect Registration)for Condidate"
                    httable.Clear();
                    httable.Add("@AppNo", txtapplicationno.Text.Trim());
                    httable.Add("@CndNo", txtcndid.Text.Trim());
                    htparams.Add("@CndNo", txtcndid.Text.Trim());
                    htparams.Add("@agntype ", ddlagntype.SelectedValue);
                    htparams.Add("@othragntype", txtOthers.Text.Trim());
                    htparams.Add("@IsWrkng", ddlIsWrkng.SelectedValue);
                    htparams.Add("@TypOfVchl", ddlTypeOfVehicle.SelectedValue);
                    htparams.Add("@VechManf", ddlVechManuf.SelectedValue);
                    htparams.Add("@DlrCompName", txtDlrCompName.Text.Trim());
                    htparams.Add("@DlrOthr", txtDlrOth.Text.Trim());
                    htparams.Add("@CompName", txtDlrCompName.Text.Trim());
                    htparams.Add("@NoOfYrsIns", ddlNoOfYrsIns.SelectedValue);
                    htparams.Add("@NoOfYrs", ddlNoOfYrs.SelectedValue);
                    htparams.Add("@AvgMnthlyIncm", ddlAvgMonthlyIncm.SelectedValue);
                    htparams.Add("@Comp1Name", ddlComp1Name.SelectedValue);
                    htparams.Add("@Comp2Name", ddlComp2Name.SelectedValue);
                    htparams.Add("@MnthVol1", ddlMnthVol1.SelectedValue);
                    htparams.Add("@MnthVol2", ddlMnthVol2.SelectedValue);
                    htparams.Add("@RGIMnthVol", ddlRGIMnthVol.SelectedValue);
                    htparams.Add("@TotBsnMtr", ddlTotBsnMtr.SelectedValue);
                    htparams.Add("@TotBsnHlth", ddlTotBsnHlth.SelectedValue);
                    htparams.Add("@TotBsnCmrclLine", ddlTotBsnComm.SelectedValue);
                    htparams.Add("@RGIBsnMtr", ddlRGIBsnMtr.SelectedValue);
                    htparams.Add("@RGIBsnHlth", ddlRGIBsnHlth.SelectedValue);
                    htparams.Add("@RGIBsnCmrclLine", ddlRGIBsnComm.SelectedValue);
                    htparams.Add("@UpdateBy", sessionuser);


                    iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));

                    //Added By Asrar on 26-06-2013 for converting Inline query into procedure to check Candidate exist or not End

                    if (iAppno == 0)
                    {

                        //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from registration BY prospect id START 
                        arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_CndAdmin_UpdCnd_ProspectArtl");


                        ////Added by Prathamesh 6-7-15 for save the Profiling data'
                        //arrResult = clsCndReg.UpdateAgentDetails(htparams, "prc_UpdCndProfiling");


                        //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from registration BY prospect id START 
                        if (arrResult[0].ToString() == "0")
                        {

                            //string appno = arrResult[1].ToString().Trim();
                            string appno = txtapplicationno.Text.Trim();
                            ViewState["CandNo"] = arrResult[1].ToString().Trim();
                            //MailResponse(appno);

                            hdnUpdate.Value = "Candidate registered successfully";
                            btnUpdate.Enabled = true;//usa
                            // btnUpdate.Enabled = false;//usa
                            lblMessage.Text = hdnUpdate.Value;
                            lblMessage.ForeColor = Color.Red;
                            lblMessage.Visible = true;
                            txtcndid.Text = arrResult[1].ToString();
                            //Added by usha to remove candidate id From  on 07.12.2017
                            lbl.Text = hdnUpdate.Value + "</br></br>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Recruiter code: " + txtEmpCode.Text
                               + "</br> Application No:" + Request.QueryString["ProspectId"].ToString() +
                               "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration";
                            //comended  by usha to remove candidate id From  on 07.12.2017
                            //lbl.Text = hdnUpdate.Value + "</br></br>Candidate No: " + txtcndid.Text.Trim() + "<br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Recruiter code: " + txtEmpCode.Text
                            //    + "</br> Application No:" + Request.QueryString["ProspectId"].ToString() +
                            //    "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration";//Added by kalyni on 2-1-2014 to show note on message pupup
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);


                            Logger.LogInfo("after agent update for status Candidate Reg");
                            ModeEdit();//Added by rachana on 10/04/2014 to enable other 4 tabs for edit
                            //ProgressBarModalPopupExtender.Hide();
                        }
                        else
                        {

                            switch (arrResult[0].ToString())
                            {
                                case "-1":
                                    lblMessage.Text = "Education Proof is Mandatory!";
                                    lblMessage.ForeColor = Color.Red;
                                    lblMessage.Visible = true;
                                    break;
                            }
                        }

                    }
                    else
                    {
                        lblMessage.Text = hdnAppno.Value;
                        lblMessage.ForeColor = Color.Red;
                        //lblMessage.Visible = true;
                        lblMessage.Visible = false; //commented as app no not exist at the time of update
                    }
                    #endregion
                    #region for normal update for candidate
                    if (iAppno == 1)
                    {
                        //comment by Prathamesh 3-8-15 
                        //htParam.Add("@PANNo", txtCurrentID.Text.Trim());

                        //arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_CndAdmin_UpdCnd1");
                        if (Request.QueryString["CndNo"] != null && Request.QueryString["ACT"] == "Rev")
                        {
                            arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_CndAdmin_UpdCnd1_Rev");
                        }
                        else
                        {
                            arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_CndAdmin_UpdCnd1");

                            //DataSet ds = new DataSet();
                            //ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_UpdateProfileDetails", htparams);


                        }


                        if (arrResult[0].ToString() == "0")
                        {

                            hdnUpdate.Value = "Candidate updated successfully";
                            lblMessage.Text = hdnUpdate.Value;
                            lblMessage.ForeColor = Color.Red;
                            lblMessage.Visible = true;

                            lbl.Text = hdnUpdate.Value + "</br><br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Recruiter code: " + txtEmpCode.Text +
                                 "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);

                            //ProgressBarModalPopupExtender.Hide();
                        }
                    }
                    #endregion
                }

                htParam.Clear();
                if (Request.QueryString["ACT"] != null)
                {
                    if (Request.QueryString["ACT"] == "PR")
                    {
                        //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        htParam.Add("@CndNo", hdnCndNo.Value);
                    }
                    else
                    {
                        htParam.Add("@CndNo", txtcndid.Text.ToString().Trim());
                    }
                }
                else
                {
                    htParam.Add("@CndNo", txtcndid.Text.Trim());
                }
                
                htParam.Add("@KnownLang", System.DBNull.Value);//chnaged by rachana on 22082014
                htParam.Add("@QualCode", cboQualCode.SelectedValue.ToString());
                htParam.Add("@InsQualDesc", txtinsurancequalification.Text.Trim());
                htParam.Add("@OcpnCode", txtOccupationCode.Text.Trim());
                htParam.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
                htParam.Add("@MutualFund", System.DBNull.Value);
                htParam.Add("@LifeInsurance", System.DBNull.Value);
                htParam.Add("@GeneralInsurance", System.DBNull.Value);
                htParam.Add("@CreditCard", System.DBNull.Value);
                htParam.Add("@OtherProducts", txtOtherProduct.Text.Trim());
                htParam.Add("@EmpAdd", txtempaddress.Text.Trim());
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@UpdateBy", sessionuser);
                arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd2");
                if (arrResult[0].ToString() == "0")
                {
                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"] == "PR")
                        {
                            hdnUpdate.Value = "Candidate registered successfully";//rk changed text 27/05/2013
                            btnUpdate.Enabled = false;//usa
                        }
                        else
                        {
                            hdnUpdate.Value = "Candidate updated successfully";
                        }
                    }
                    else
                    {
                        hdnUpdate.Value = "Candidate registered successfully";
                        btnUpdate.Enabled = false;//usa
                    }
                    lblMessage.Text = hdnUpdate.Value;
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Visible = true;
                    FillRequiredDataForCndQualification();
                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"] == "PR")
                        {
                            lbl.Text = hdnUpdate.Value + "</br></br>Application No: " + txtapplicationno.Text +//lbleappno.Text +
                                "</br>Prospect Name: " + lblbgivenname.Text + " " + lblqsurname.Text +
                                 "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration.";
                        }
                        else
                        {
                            lbl.Text = hdnUpdate.Value + "</br><br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Recruiter code: " + txtEmpCode.Text +
                                         "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration.";
                        }
                    }
                    else
                    {
                        lbl.Text = hdnUpdate.Value + "</br></br>Application No: " + txtapplicationno.Text +//lbleappno.Text +
                                "</br>Prospect Name: " + lblbgivenname.Text + " " + lblqsurname.Text +
                                 "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration.";
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                }
                else
                {
                    lblMessage.Text = arrResult[1].ToString();
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Visible = true;
                }
                if (MultiView1.ActiveViewIndex == 2)
                {
                    #region
                    if (txtto1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto4.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto5.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto6.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto6.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in Employment history To: end
                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in Employment history From: start
                    if (txtfrom1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom4.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom5.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    //Commented by rachana on 22-08-2014 start
                    //if (txtfrom6.Text.ToString().Trim() != "")
                    //{
                    //    if ((Convert.ToDateTime(txtfrom6.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    //    {
                    //        ProgressBarModalPopupExtender.Hide();
                    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    //        return;
                    //    }
                    //}
                    //Commented by rachana on 22-08-2014 end
                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in Employment history From: end

                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service start
                    if (txtotherexpfrom1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtotherexpfrom2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtotherexpfrom3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service end

                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service To: start
                    if (txtotherexpTo1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtotherexpTo2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtotherexpTo3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    #endregion
                    //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service To: end
                    htParam.Clear();
                    //Added by swapnesh for inserting Emp History data on 20_5_2013 start

                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"] == "PR")
                        {
                            //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            htParam.Add("@CndNo", hdnCndNo.Value);
                        }
                        else
                        {
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        }
                    }
                    else
                    {
                        htParam.Add("@CndNo", txtcndid.Text.Trim());
                    }
                    //Added by swapnesh for inserting Emp History data on 20_5_2013 end
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));

                    if (DateChecking() == 0)
                        return;

                    //Previous Experience One
                    htParam.Add("@CompName1", txtPrevEmpName1.Text.Trim());
                    if (txtfrom1.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate1", DateTime.Parse(txtfrom1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate1 ", System.DBNull.Value);
                    }
                    if (txtto1.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate1", DateTime.Parse(txtto1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate1 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer1", txtaddofemp1.Text.Trim());
                    htParam.Add("@LastPositionHeld1", txtEmpLvl1.Text.Trim());
                    htParam.Add("@AnnIncome1", txtLastIncome1.Text.Trim());
                    htParam.Add("@ReasonLeave1", txtreasforleave1.Text.Trim());


                    //Previous Experience Two
                    htParam.Add("@CompName2", txtPrevEmpName2.Text.Trim());
                    if (txtfrom2.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate2", DateTime.Parse(txtfrom2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate2 ", System.DBNull.Value);
                    }
                    if (txtto2.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate2", DateTime.Parse(txtto2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate2 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer2", txtaddofemp2.Text.Trim());
                    htParam.Add("@LastPositionHeld2", txtEmpLvl2.Text.Trim());
                    htParam.Add("@AnnIncome2", txtLastIncome2.Text.Trim());
                    htParam.Add("@ReasonLeave2", txtreasforleave2.Text.Trim());

                    //Previous Experience Three
                    htParam.Add("@CompName3", txtPrevEmpName3.Text.Trim());
                    if (txtfrom3.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate3", DateTime.Parse(txtfrom3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate3 ", System.DBNull.Value);
                    }
                    if (txtto3.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate3", DateTime.Parse(txtto3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate3 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer3", txtaddofemp3.Text.Trim());
                    htParam.Add("@LastPositionHeld3", txtEmpLvl3.Text.Trim());
                    htParam.Add("@AnnIncome3", txtLastIncome3.Text.Trim());
                    htParam.Add("@ReasonLeave3", txtreasforleave3.Text.Trim());

                    //Previous Experience Four
                    htParam.Add("@CompName4", txtPrevEmpName4.Text.Trim());
                    if (txtfrom4.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate4", DateTime.Parse(txtfrom4.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate4 ", System.DBNull.Value);
                    }
                    if (txtto4.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate4", DateTime.Parse(txtto4.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate4 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer4", txtaddofemp4.Text.Trim());
                    htParam.Add("@LastPositionHeld4", txtEmpLvl4.Text.Trim());
                    htParam.Add("@AnnIncome4", txtLastIncome4.Text.Trim());
                    htParam.Add("@ReasonLeave4", txtreasforleave4.Text.Trim());

                    //Previous Experience Five
                    htParam.Add("@CompName5", txtPrevEmpName5.Text.Trim());
                    if (txtfrom5.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate5", DateTime.Parse(txtfrom5.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate5 ", System.DBNull.Value);
                    }
                    if (txtto5.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate5", DateTime.Parse(txtto5.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate5 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer5", txtaddofemp5.Text.Trim());
                    htParam.Add("@LastPositionHeld5", txtEmpLvl5.Text.Trim());
                    htParam.Add("@AnnIncome5", txtLastIncome5.Text.Trim());
                    htParam.Add("@ReasonLeave5", txtreasforleave5.Text.Trim());




                    htParam.Add("@CompName6", System.DBNull.Value);
                    htParam.Add("@StartDate6 ", System.DBNull.Value);
                    htParam.Add("@EndDate6", System.DBNull.Value);


                    htParam.Add("@AddofEmployer6", System.DBNull.Value);
                    htParam.Add("@LastPositionHeld6", System.DBNull.Value);
                    htParam.Add("@AnnIncome6", System.DBNull.Value);
                    htParam.Add("@ReasonLeave6", System.DBNull.Value);
                    //Changed by rachana on 22-08-2014 end

                    //Details Insurance Agency
                    htParam.Add("@AcompName", txtInsCompName.Text.Trim());
                    htParam.Add("@IsInsExp", rbinsagency.SelectedValue.Trim());
                    htParam.Add("@LcnNo", txtLcnNo.Text.Trim());
                    htParam.Add("@CseReasonDesc", txtTerminationReason.Text.Trim());
                    htParam.Add("@AgentCode", txtInsAgencyCode.Text.Trim());

                    if (txtdateofissue.Text.Trim() != "")
                    {
                        htParam.Add("@LcnIssDate", DateTime.Parse(txtdateofissue.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@LcnIssDate ", System.DBNull.Value);
                    }

                    if (txtvaliddate.Text.Trim() != "")
                    {
                        htParam.Add("@LcnExpDate", DateTime.Parse(txtvaliddate.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@LcnExpDate ", System.DBNull.Value);
                    }

                    if (txtterminatedate.Text.Trim() != "")
                    {
                        htParam.Add("@CseDate", DateTime.Parse(txtterminatedate.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CseDate ", System.DBNull.Value);
                    }


                    //Any other work experience 1
                    htParam.Add("@CECompName1", txtemprecordname1.Text.Trim());
                    if (txtotherexpfrom1.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate1", DateTime.Parse(txtotherexpfrom1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate1 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo1.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate1", DateTime.Parse(txtotherexpTo1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate1 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType1", txtemprecordjobnature1.Text.Trim());
                    htParam.Add("@CEWorkCls1", txtemprecordfield1.Text.Trim());

                    //Any other work experience 2
                    htParam.Add("@CECompName2", txtemprecordname2.Text.Trim());
                    if (txtotherexpfrom2.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate2", DateTime.Parse(txtotherexpfrom2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate2 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo2.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate2", DateTime.Parse(txtotherexpTo2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate2 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType2", txtemprecordjobnature2.Text.Trim());
                    htParam.Add("@CEWorkCls2", txtemprecordfield2.Text.Trim());


                    //Any other work experience 3
                    htParam.Add("@CECompName3", txtemprecordname3.Text.Trim());
                    if (txtotherexpfrom3.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate3", DateTime.Parse(txtotherexpfrom3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate3 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo3.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate3", DateTime.Parse(txtotherexpTo3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate3 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType3", txtemprecordjobnature3.Text.Trim());
                    htParam.Add("@CEWorkCls3", txtemprecordfield3.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);

                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd3");
                    if (arrResult[0].ToString() == "0")
                    {
                        //Added by swapnesh for inserting Employment history data on 20_5_2013 start

                        if (Request.QueryString["ACT"] != null)
                        {
                            if (Request.QueryString["ACT"] == "PR")
                            {
                                hdnUpdate.Value = "Employment history updated successfully.";//changed message by rachana on 27/052013  
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message start
                            else
                            {
                                hdnUpdate.Value = "Employment history updated successfully.";
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message end
                        }
                        else
                        {
                            hdnUpdate.Value = "Employment history updated successfully.";
                        }
                        //Added by swapnesh for inserting Employment history data on 20_5_2013 end
                        lblMessage.Text = hdnUpdate.Value;
                        lblMessage.ForeColor = Color.Red;
                        // lblMessage.Visible = true;
                        //Added by swapnesh for inserting Employment history data on 20_5_2013 start

                        if (Request.QueryString["ACT"] != null)
                        {
                            if (Request.QueryString["ACT"] == "PR")
                            {
                                //Added by Rachana on 27/05/2013 to show message box on candidate edit details start
                                lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + hdnCndNo.Value

                                    + "</br>Application No: " + txtapplicationno.Text
                                    + "</br>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + lblesurname.Text +
                                     "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration.";
                                //Added by Rachana on 27/05/2013 to show message box on candidate edit details End
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box start
                            else
                            {
                                lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + Request.QueryString["CndNo"].ToString().Trim()

                                 + "</br>Application No: " + txtapplicationno.Text
                                 + "</br>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + lblesurname.Text +
                                  "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration.";
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box end
                        }
                        else
                        {
                            //added by Rachana on 28/05/2013 to show msgbox on editing candidate details in candidate enquiry start

                            lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + txtcndid.Text.Trim()//+ Request.QueryString["CndNo"].ToString().Trim()

                                   + "</br>Application No: " + txtapplicationno.Text
                                   + "</br>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + lblesurname.Text +
                                    "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration.";
                            //added by Rachana on 28/05/2013 to show msgbox on editing candidate details in candidate enquiry end
                        }
                        //Added by swapnesh for inserting Employment history data on 20_5_2013 end
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        // ProgressBarModalPopupExtender.Hide();
                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        // lblMessage.Visible = true;
                    }

                }
                if (MultiView1.ActiveViewIndex == 3)
                {
                    htParam.Clear();
                    //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 start

                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"] == "PR")
                        {
                            //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            htParam.Add("@CndNo", hdnCndNo.Value);
                        }
                        //Added by pranjali on 29-07-2013 for getting candno start
                        else
                        {
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        }
                        //Added by pranjali on 29-07-2013 for getting candno end
                    }
                    else
                    {
                        htParam.Add("@CndNo", txtcndid.Text.Trim());
                    }
                    //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 end                
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    //Comented by rachana on 22-08-2014 start
                    //htParam.Add("@Qstn01", rbQstn01.SelectedValue.Trim());
                    //htParam.Add("@Qstn02", rbQstn02.SelectedValue.Trim());
                    //htParam.Add("@Qstn03", rbQstn03.SelectedValue.Trim());
                    //htParam.Add("@Qstn04", rbQstn04.SelectedValue.Trim());
                    htParam.Add("@Qstn01", System.DBNull.Value);
                    htParam.Add("@Qstn02", System.DBNull.Value);
                    htParam.Add("@Qstn03", System.DBNull.Value);
                    htParam.Add("@Qstn04", System.DBNull.Value);
                    //Comented by rachana on 22-08-2014 end
                    htParam.Add("@RefName01", txtRef1Name.Text.Trim());
                    htParam.Add("@Ref1Add1", txtRef1Add1.Text.Trim());
                    htParam.Add("@Ref1Add2", txtRef1Add2.Text.Trim());
                    htParam.Add("@Ref1Add3", txtRef1Add3.Text.Trim());
                    htParam.Add("@Ref1city", "");
                    htParam.Add("@Ref1PostCode", txtRef1Pin.Text.Trim());
                    if (txtStateCodeR1.Text.Trim() == "")
                    {
                        htParam.Add("@Ref1StateCode", System.DBNull.Value);
                    }
                    else
                    {
                        htParam.Add("@Ref1StateCode", txtStateCodeR1.Text.Trim());
                    }
                    htParam.Add("@Ref1CntryCode", txtCountryCodeR1.Text.Trim());

                    htParam.Add("@RefName02", txtRef2Name.Text.Trim());
                    htParam.Add("@Ref2Add1", txtRef2Add1.Text.Trim());
                    htParam.Add("@Ref2Add2", txtRef2Add2.Text.Trim());
                    htParam.Add("@Ref2Add3", txtRef2Add3.Text.Trim());
                    htParam.Add("@Ref2City", "");
                    htParam.Add("@Ref2PostCode", txtRef2Pin.Text.Trim());
                    if (txtStateCodeR2.Text.Trim() == "")
                    {
                        htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
                    }

                    htParam.Add("@Ref2CntryCode", txtCountryCodeR2.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);
                    //Added by swapnesh
                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"].ToString().Trim() == "PR")
                        {
                            arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_edit_UpdCnd4");
                        }
                        //Added by pranjali on 29-07-2013 for inserting data into cnd,CndCnct and CndHst for Candidate Details start
                        else
                        {
                            arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd4");
                        }
                        //Added by pranjali on 29-07-2013 for inserting data into cnd,CndCnct and CndHst for Candidate Details end
                    }
                    else
                    {
                        arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd4");
                    }
                    //Added by swapnesh end
                    if (arrResult[0].ToString() == "0")
                    {
                        //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 start

                        if (Request.QueryString["ACT"] != null)
                        {
                            if (Request.QueryString["ACT"] == "PR")
                            {
                                hdnUpdate.Value = "Disciplinary info upadted successfully.";//changed text by rachana on 27052013 for msg box
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box start
                            else
                            {
                                hdnUpdate.Value = "Disciplinary info updated successfully.";
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box end
                        }
                        else
                        {
                            hdnUpdate.Value = "Disciplinary info updated successfully.";
                        }
                        //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 end
                        lblMessage.Text = hdnUpdate.Value;
                        lblMessage.ForeColor = Color.Red;
                        // lblMessage.Visible = true;
                        //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 start

                        if (Request.QueryString["ACT"] != null)
                        {
                            if (Request.QueryString["ACT"] == "PR")
                            {

                                lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + hdnCndNo.Value
                                    + "</br>Application No: " + txtapplicationno.Text
                                    + "</br>Candidate Name: " + lblpgivenname.Text + " " + lblpSurname.Text +
                                     "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";

                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box start
                            else
                            {
                                lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + Request.QueryString["CndNo"].ToString().Trim()
                                   + "</br>Application No: " + txtapplicationno.Text
                                   + "</br>Candidate Name: " + lblpgivenname.Text + " " + lblpSurname.Text +
                                    "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";
                            }
                            //Added by pranjali on 29-07-2013 for displaying proper message in message box end
                        }
                        else
                        {
                            //Added by Rachana on 28/05/2013 for showing candidate details tab 4 msgbox start

                            lbl.Text = hdnUpdate.Value + "</br></br>Candidate ID: " + txtcndid.Text.Trim()//+ Request.QueryString["CndNo"].ToString().Trim()
                                   + "</br>Application No: " + txtapplicationno.Text
                                   + "</br>Candidate Name: " + lblpgivenname.Text + " " + lblpSurname.Text +
                                    "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";
                            //Added by Rachana on 28/05/2013 for showing candidate details tab 4 msgbox end

                        }
                        //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 end
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        // ProgressBarModalPopupExtender.Hide();
                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        //  lblMessage.Visible = true;
                    }
                }
                if (MultiView1.ActiveViewIndex == 4)
                {
                    htParam.Clear();
                    htParam.Add("@CndNo", txtcndid.Text.Trim());
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@TgtYrProspect01", txtbusinessplannooflives11.Text.Trim());
                    htParam.Add("@TgtYrProspect02", txtbusinessplannooflives21.Text.Trim());
                    htParam.Add("@TgtYrProspect03", txtbusinessplannooflives31.Text.Trim());
                    htParam.Add("@TgtYrInc01", txtbusinessplansumassured11.Text.Trim());
                    htParam.Add("@TgtYrInc02", txtbusinessplannsumassured21.Text.Trim());
                    htParam.Add("@TgtYrInc03", txtbusinessplannsumassured31.Text.Trim());
                    htParam.Add("@TgtFYC01", txtbusinessplannfirstyearpremium11.Text.Trim());
                    htParam.Add("@TgtFYC02", txtbusinessplannfirstyearpremium21.Text.Trim());
                    htParam.Add("@TgtFYC03", txtbusinessplannfirstyearpremium31.Text.Trim());
                    htParam.Add("@IsFullTime", rbtimework.SelectedValue == "0" ? "0" : "1");
                    htParam.Add("@PastAchievement", txtpastachievement.Text.Trim());
                    htParam.Add("@RelativeAtWork", rbrelatedemp.SelectedValue == "Y" ? "Y" : "N");
                    htParam.Add("@RelativeAtWorkDesc", txtrelativeworkdesc.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);

                    //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from InterView module BY prospect id START

                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd5");
                    //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from InterView module BY prospect id END

                    if (arrResult[0].ToString() == "0")
                    {
                        hdnUpdate.Value = "Business plan updated successfully.";//Changed by rachana on 27052013 to change msg box message
                        lblMessage.Text = hdnUpdate.Value;
                        lblMessage.ForeColor = Color.Red;
                        //lblMessage.Visible = true;

                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        // lblMessage.Visible = true;
                    }

                    if (Request.QueryString["ACT"] != null)
                    {
                        if (Request.QueryString["ACT"] == "PR")
                        {

                            lbl.Text = "Business plan updated successfully." + "</br></br>Candidate ID: " + hdnCndNo.Value + "<br/>Application No: " + lbleappno.Text + "<br/>Candidate Name: " + lblbgivenname.Text + " " + lblbSurname.Text +
                         "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        }
                        else
                        {
                            lbl.Text = "Business plan updated successfully." + "</br></br>Candidate ID: " + txtcndid.Text.Trim() + "<br/>Application No: " + lbleappno.Text + "<br/>Candidate Name: " + lblbgivenname.Text + " " + lblbSurname.Text +
                         "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        }
                    }
                    else
                    {
                        lbl.Text = "Business plan updated successfully." + "</br></br>Candidate ID: " + txtcndid.Text.Trim() + "<br/>Application No: " + lbleappno.Text + "<br/>Candidate Name: " + lblbgivenname.Text + " " + lblbSurname.Text +
                             "<br/><br/>Note :- Please proceed to Sponsorship Request after Candidate Registration";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                    }



                }

                #region SAVING DATA FOR REGISTRATION PROFILING 2nd TAB
                #region New Business Plan Detail
                htparams.Clear();
                htparams.Add("@CndNo", txtcndid.Text.ToString());
                htparams.Add("@AppNo", txtapplicationno.Text.ToString());
                htparams.Add("@agntype", ddlagntype.SelectedValue.ToString());
                if (txtOthers.Text.Trim() != "")
                {
                    htparams.Add("@othragntype", txtOthers.Text.Trim());
                }
                else
                {
                    htparams.Add("@othragntype", System.DBNull.Value);
                }
                htparams.Add("@IsWrkng", ddlIsWrkng.SelectedValue.ToString());
                if (ddlIsWrkng.SelectedValue == "Y")
                {
                    if (ddlcompName.SelectedValue.ToString() != "Select")
                    {
                        htparams.Add("@compName", ddlcompName.SelectedValue.ToString());
                    }
                    else
                    {
                        htparams.Add("@compName", System.DBNull.Value);
                    }
                }
                else
                {
                    htparams.Add("@compName", System.DBNull.Value);
                }

                htparams.Add("@NoOfYrsIns", ddlNoOfYrsIns.SelectedValue.ToString());
                htparams.Add("@NoOfYrs", ddlNoOfYrs.SelectedValue.ToString());
                if (ddlTypeOfVehicle.Enabled == true)
                {
                    htparams.Add("@TypOfVchl", System.DBNull.Value);
                }
                else
                {
                    htparams.Add("@TypOfVchl", System.DBNull.Value);
                }
                if (ddlVechManuf.Enabled == true)
                {
                    htparams.Add("@VechManf", System.DBNull.Value);
                }
                else
                {
                    htparams.Add("@VechManf", System.DBNull.Value);
                }
                if (txtDlrCompName.Enabled == true)
                {
                    if (txtDlrCompName.Text.Trim() != "")
                    {
                        htparams.Add("@DlrCompName", txtDlrCompName.Text.Trim());
                    }
                    else
                    {
                        htparams.Add("@DlrCompName", System.DBNull.Value);
                    }
                }
                else
                {
                    htparams.Add("@DlrCompName", System.DBNull.Value);
                }
                if (txtDlrOth.Text.Trim() != "")
                {
                    htparams.Add("@DlrOthr", txtDlrOth.Text.Trim());
                }
                else
                {
                    htparams.Add("@DlrOthr", System.DBNull.Value);
                }

                htparams.Add("@AvgMnthlyIncm", ddlAvgMonthlyIncm.SelectedValue.ToString());
                htparams.Add("@Comp1Name", ddlComp1Name.SelectedValue.ToString());
                htparams.Add("@MnthVol1", ddlMnthVol1.SelectedValue.ToString());
                if (ddlComp2Name.SelectedIndex != 0)
                {
                    htparams.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
                }
                else
                {
                    htparams.Add("@Comp2Name", System.DBNull.Value);
                }

                if (ddlMnthVol2.SelectedIndex != 0)
                {
                    htparams.Add("@MnthVol2", ddlMnthVol2.SelectedValue.ToString());
                }
                else
                {
                    htparams.Add("@MnthVol2", System.DBNull.Value);
                }

                htparams.Add("@RGIMnthVol", ddlRGIMnthVol.SelectedValue.ToString());
                htparams.Add("@TotBsnMtr", ddlTotBsnMtr.SelectedValue.ToString());
                htparams.Add("@TotBsnHlth", ddlTotBsnHlth.SelectedValue.ToString());
                htparams.Add("@RGIBsnMtr", ddlRGIBsnMtr.SelectedValue.ToString());
                htparams.Add("@RGIBsnHlth", ddlRGIBsnHlth.SelectedValue.ToString());
                htparams.Add("@RGIBsnCmrclLine", ddlRGIBsnComm.SelectedValue.ToString());
                htparams.Add("@TotBsnCmrclLine", ddlTotBsnComm.SelectedValue.ToString());
                htparams.Add("@CreateBy", sessionuser);
                if (Request.QueryString["CndNo"] == null)
                {
                    //Added By Prathamesh 8-6-15 
                    arrResult = clsCndReg.UpdateAgentDetails(htparams, "prc_UpdCndProfiling");
                }
                else
                {
                    httable.Clear();
                    httable.Add("@AppNo", txtapplicationno.Text.Trim());
                    httable.Add("@CndNo", txtcndid.Text.Trim());
                    iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));
                    if (iAppno == 1)
                    {
                        htparams.Clear();
                        htparams.Add("@CndNo", txtcndid.Text.ToString());
                        htparams.Add("@agntype", ddlagntype.SelectedValue.ToString());
                        if (txtOthers.Text.Trim() != "")
                        {
                            htparams.Add("@othragntype", txtOthers.Text.Trim());
                        }
                        else
                        {
                            htparams.Add("@othragntype", System.DBNull.Value);
                        }
                        htparams.Add("@IsWrkng", ddlIsWrkng.SelectedValue.ToString());
                        if (ddlIsWrkng.SelectedValue == "Y")
                        {
                            if (ddlcompName.SelectedValue.ToString() != "Select")
                            {
                                htparams.Add("@compName", ddlcompName.SelectedValue.ToString());
                            }
                            else
                            {
                                htparams.Add("@compName", System.DBNull.Value);
                            }
                        }
                        else
                        {
                            htparams.Add("@compName", System.DBNull.Value);
                        }

                        htparams.Add("@NoOfYrsIns", ddlNoOfYrsIns.SelectedValue.ToString());
                        htparams.Add("@NoOfYrs", ddlNoOfYrs.SelectedValue.ToString());
                        if (ddlTypeOfVehicle.Enabled == true)
                        {
                            htparams.Add("@TypOfVchl", ddlTypeOfVehicle.SelectedValue.ToString());
                        }
                        else
                        {
                            htparams.Add("@TypOfVchl", System.DBNull.Value);
                        }
                        if (ddlVechManuf.Enabled == true)
                        {
                            htparams.Add("@VechManf", ddlVechManuf.SelectedValue.ToString());
                        }
                        else
                        {
                            htparams.Add("@VechManf", System.DBNull.Value);
                        }
                        if (txtDlrCompName.Enabled == true)
                        {
                            if (txtDlrCompName.Text.Trim() != "")
                            {
                                htparams.Add("@DlrCompName", txtDlrCompName.Text.Trim());
                            }
                            else
                            {
                                htparams.Add("@DlrCompName", System.DBNull.Value);
                            }
                        }
                        else
                        {
                            htparams.Add("@DlrCompName", System.DBNull.Value);
                        }
                        if (txtDlrOth.Text.Trim() != "")
                        {
                            htparams.Add("@DlrOthr", txtDlrOth.Text.Trim());
                        }
                        else
                        {
                            htparams.Add("@DlrOthr", System.DBNull.Value);
                        }

                        htparams.Add("@AvgMnthlyIncm", ddlAvgMonthlyIncm.SelectedValue.ToString());
                        htparams.Add("@Comp1Name", ddlComp1Name.SelectedValue.ToString());
                        htparams.Add("@MnthVol1", ddlMnthVol1.SelectedValue.ToString());
                        if (ddlComp2Name.SelectedIndex != 0)
                        {
                            htparams.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
                        }
                        else
                        {
                            htparams.Add("@Comp2Name", System.DBNull.Value);
                        }

                        if (ddlMnthVol2.SelectedIndex != 0)
                        {
                            htparams.Add("@MnthVol2", ddlMnthVol2.SelectedValue.ToString());
                        }
                        else
                        {
                            htparams.Add("@MnthVol2", System.DBNull.Value);
                        }

                        htparams.Add("@RGIMnthVol", ddlRGIMnthVol.SelectedValue.ToString());
                        htparams.Add("@TotBsnMtr", ddlTotBsnMtr.SelectedValue.ToString());
                        htparams.Add("@TotBsnHlth", ddlTotBsnHlth.SelectedValue.ToString());
                        htparams.Add("@RGIBsnMtr", ddlRGIBsnMtr.SelectedValue.ToString());
                        htparams.Add("@RGIBsnHlth", ddlRGIBsnHlth.SelectedValue.ToString());
                        htparams.Add("@RGIBsnCmrclLine", ddlRGIBsnComm.SelectedValue.ToString());
                        htparams.Add("@TotBsnCmrclLine", ddlTotBsnComm.SelectedValue.ToString());
                        htparams.Add("@UpdateBy", sessionuser);


                        arrResult = clsCndReg.UpdateAgentDetails(htparams, "Prc_UpdateProfileDetails");


                        hdnUpdate.Value = "Candidate updated successfully";
                    }
                }

                if (arrResult[0].ToString() == "0")
                {
                    //Save(); //Method to update cndstatus and entry in licrentccsu
                    // lblpopup.Text = "Profiling updated successfully." + "</br></br>Candidate ID: " + lblqcndno.Text.Trim() + "<br/>Application No: " + lblqappno.Text.Trim() + "<br/>Candidate name: " + lblqgivenname.Text.Trim() + " " + lblqsurname.Text.Trim()   "";
                    //mdlpopup.Show();
                    //ProgressBarModalPopupExtender.Hide();
                }
                else
                {
                    lblMessage.Text = arrResult[1].ToString();
                    lblMessage.ForeColor = Color.Red;
                }
                #endregion
                #region SAVING QUALIFICATION DETAIL
                if (MultiView1.ActiveViewIndex == 1)
                {
                    htParam.Clear();
                    htParam.Add("@CndNo", txtcndid.Text.ToString().Trim());
                    htParam.Add("@KnownLang", System.DBNull.Value);
                    htParam.Add("@QualCode", cboQualCode.SelectedValue.ToString());
                    htParam.Add("@InsQualDesc", txtinsurancequalification.Text.Trim());
                    htParam.Add("@OcpnCode", txtOccupationCode.Text.Trim());
                    htParam.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
                    htParam.Add("@MutualFund", System.DBNull.Value);
                    htParam.Add("@LifeInsurance", System.DBNull.Value);
                    htParam.Add("@GeneralInsurance", System.DBNull.Value);
                    htParam.Add("@CreditCard", System.DBNull.Value);
                    htParam.Add("@OtherProducts", txtOtherProduct.Text.Trim());
                    htParam.Add("@EmpAdd", txtempaddress.Text.Trim());
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@UpdateBy", sessionuser);

                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd2");

                    if (arrResult[0].ToString() == "0")
                    {

                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                }
                #endregion
                #region SAVING EMPLOYMENT HISTORY DETAIL
                if (MultiView1.ActiveViewIndex == 1)
                {
                    #region
                    if (txtto1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto4.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto5.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtto6.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtto6.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                   
                    if (txtfrom1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom4.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtfrom5.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtfrom5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }

                    if (txtotherexpfrom1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtotherexpfrom2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    if (txtotherexpfrom3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                            return;
                        }
                    }
                    
                    if (txtotherexpTo1.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtotherexpTo2.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    if (txtotherexpTo3.Text.ToString().Trim() != "")
                    {
                        if ((Convert.ToDateTime(txtotherexpTo3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                            return;
                        }
                    }
                    #endregion
                    htParam.Clear();
                    htParam.Add("@CndNo", txtcndid.Text.ToString().Trim());
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    if (DateChecking() == 0)
                        return;

                    htParam.Add("@CompName1", txtPrevEmpName1.Text.Trim());
                    if (txtfrom1.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate1", DateTime.Parse(txtfrom1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate1 ", System.DBNull.Value);
                    }
                    if (txtto1.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate1", DateTime.Parse(txtto1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate1 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer1", txtaddofemp1.Text.Trim());
                    htParam.Add("@LastPositionHeld1", txtEmpLvl1.Text.Trim());
                    htParam.Add("@AnnIncome1", txtLastIncome1.Text.Trim());
                    htParam.Add("@ReasonLeave1", txtreasforleave1.Text.Trim());
                    htParam.Add("@CompName2", txtPrevEmpName2.Text.Trim());
                    if (txtfrom2.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate2", DateTime.Parse(txtfrom2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate2 ", System.DBNull.Value);
                    }
                    if (txtto2.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate2", DateTime.Parse(txtto2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate2 ", System.DBNull.Value);
                    }
                    htParam.Add("@AddofEmployer2", txtaddofemp2.Text.Trim());
                    htParam.Add("@LastPositionHeld2", txtEmpLvl2.Text.Trim());
                    htParam.Add("@AnnIncome2", txtLastIncome2.Text.Trim());
                    htParam.Add("@ReasonLeave2", txtreasforleave2.Text.Trim());
                    htParam.Add("@CompName3", txtPrevEmpName3.Text.Trim());
                    if (txtfrom3.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate3", DateTime.Parse(txtfrom3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate3 ", System.DBNull.Value);
                    }
                    if (txtto3.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate3", DateTime.Parse(txtto3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate3 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer3", txtaddofemp3.Text.Trim());
                    htParam.Add("@LastPositionHeld3", txtEmpLvl3.Text.Trim());
                    htParam.Add("@AnnIncome3", txtLastIncome3.Text.Trim());
                    htParam.Add("@ReasonLeave3", txtreasforleave3.Text.Trim());

                    htParam.Add("@CompName4", txtPrevEmpName4.Text.Trim());
                    if (txtfrom4.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate4", DateTime.Parse(txtfrom4.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate4 ", System.DBNull.Value);
                    }
                    if (txtto4.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate4", DateTime.Parse(txtto4.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate4 ", System.DBNull.Value);
                    }

                    htParam.Add("@AddofEmployer4", txtaddofemp4.Text.Trim());
                    htParam.Add("@LastPositionHeld4", txtEmpLvl4.Text.Trim());
                    htParam.Add("@AnnIncome4", txtLastIncome4.Text.Trim());
                    htParam.Add("@ReasonLeave4", txtreasforleave4.Text.Trim());

                    htParam.Add("@CompName5", txtPrevEmpName5.Text.Trim());
                    if (txtfrom5.Text.Trim() != "")
                    {
                        htParam.Add("@StartDate5", DateTime.Parse(txtfrom5.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@StartDate5 ", System.DBNull.Value);
                    }
                    if (txtto5.Text.Trim() != "")
                    {
                        htParam.Add("@EndDate5", DateTime.Parse(txtto5.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@EndDate5 ", System.DBNull.Value);
                    }
                    htParam.Add("@AddofEmployer5", txtaddofemp5.Text.Trim());
                    htParam.Add("@LastPositionHeld5", txtEmpLvl5.Text.Trim());
                    htParam.Add("@AnnIncome5", txtLastIncome5.Text.Trim());
                    htParam.Add("@ReasonLeave5", txtreasforleave5.Text.Trim());
                    htParam.Add("@CompName6", System.DBNull.Value);
                    htParam.Add("@StartDate6 ", System.DBNull.Value);
                    htParam.Add("@EndDate6", System.DBNull.Value);
                    htParam.Add("@AddofEmployer6", System.DBNull.Value);
                    htParam.Add("@LastPositionHeld6", System.DBNull.Value);
                    htParam.Add("@AnnIncome6", System.DBNull.Value);
                    htParam.Add("@ReasonLeave6", System.DBNull.Value);
                    htParam.Add("@AcompName", txtInsCompName.Text.Trim());
                    htParam.Add("@IsInsExp", rbinsagency.SelectedValue.Trim());
                    htParam.Add("@LcnNo", txtLcnNo.Text.Trim());
                    htParam.Add("@CseReasonDesc", txtTerminationReason.Text.Trim());
                    htParam.Add("@AgentCode", txtInsAgencyCode.Text.Trim());

                    if (txtdateofissue.Text.Trim() != "")
                    {
                        htParam.Add("@LcnIssDate", DateTime.Parse(txtdateofissue.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@LcnIssDate ", System.DBNull.Value);
                    }

                    if (txtvaliddate.Text.Trim() != "")
                    {
                        htParam.Add("@LcnExpDate", DateTime.Parse(txtvaliddate.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@LcnExpDate ", System.DBNull.Value);
                    }

                    if (txtterminatedate.Text.Trim() != "")
                    {
                        htParam.Add("@CseDate", DateTime.Parse(txtterminatedate.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CseDate ", System.DBNull.Value);
                    }


                    //Any other work experience 1
                    htParam.Add("@CECompName1", txtemprecordname1.Text.Trim());
                    if (txtotherexpfrom1.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate1", DateTime.Parse(txtotherexpfrom1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate1 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo1.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate1", DateTime.Parse(txtotherexpTo1.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate1 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType1", txtemprecordjobnature1.Text.Trim());
                    htParam.Add("@CEWorkCls1", txtemprecordfield1.Text.Trim());

                    //Any other work experience 2
                    htParam.Add("@CECompName2", txtemprecordname2.Text.Trim());
                    if (txtotherexpfrom2.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate2", DateTime.Parse(txtotherexpfrom2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate2 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo2.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate2", DateTime.Parse(txtotherexpTo2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate2 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType2", txtemprecordjobnature2.Text.Trim());
                    htParam.Add("@CEWorkCls2", txtemprecordfield2.Text.Trim());


                    //Any other work experience 3
                    htParam.Add("@CECompName3", txtemprecordname3.Text.Trim());
                    if (txtotherexpfrom3.Text.Trim() != "")
                    {
                        htParam.Add("@CEStartDate3", DateTime.Parse(txtotherexpfrom3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEStartDate3 ", System.DBNull.Value);
                    }
                    if (txtotherexpTo3.Text.Trim() != "")
                    {
                        htParam.Add("@CEEndDate3", DateTime.Parse(txtotherexpTo3.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@CEEndDate3 ", System.DBNull.Value);
                    }
                    htParam.Add("@CEWorkType3", txtemprecordjobnature3.Text.Trim());
                    htParam.Add("@CEWorkCls3", txtemprecordfield3.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);

                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd3");
                    if (arrResult[0].ToString() == "0")
                    {

                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                }
                #endregion
                #region SAVING DISCIPLINARY INFORMATION DETAIL
                if (MultiView1.ActiveViewIndex == 1)
                {
                    htParam.Clear();
                    //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 start

                    //comment by Prathamesh 9-6-15
                    htParam.Add("@CndNo", txtcndid.Text.ToString().Trim());
                    //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 end                
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@Qstn01", System.DBNull.Value);
                    htParam.Add("@Qstn02", System.DBNull.Value);
                    htParam.Add("@Qstn03", System.DBNull.Value);
                    htParam.Add("@Qstn04", System.DBNull.Value);
                    //Comented by rachana on 22-08-2014 end
                    htParam.Add("@RefName01", txtRef1Name.Text.Trim());
                    htParam.Add("@Ref1Add1", txtRef1Add1.Text.Trim());
                    htParam.Add("@Ref1Add2", txtRef1Add2.Text.Trim());
                    htParam.Add("@Ref1Add3", txtRef1Add3.Text.Trim());
                    htParam.Add("@Ref1city", "");
                    htParam.Add("@Ref1PostCode", txtRef1Pin.Text.Trim());
                    if (txtStateCodeR1.Text.Trim() == "")
                    {
                        htParam.Add("@Ref1StateCode", System.DBNull.Value);
                    }
                    else
                    {
                        htParam.Add("@Ref1StateCode", txtStateCodeR1.Text.Trim());
                    }
                    htParam.Add("@Ref1CntryCode", txtCountryCodeR1.Text.Trim());

                    htParam.Add("@RefName02", txtRef2Name.Text.Trim());
                    htParam.Add("@Ref2Add1", txtRef2Add1.Text.Trim());
                    htParam.Add("@Ref2Add2", txtRef2Add2.Text.Trim());
                    htParam.Add("@Ref2Add3", txtRef2Add3.Text.Trim());
                    htParam.Add("@Ref2City", "");
                    htParam.Add("@Ref2PostCode", txtRef2Pin.Text.Trim());
                    if (txtStateCodeR2.Text.Trim() == "")
                    {
                        htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
                    }

                    htParam.Add("@Ref2CntryCode", txtCountryCodeR2.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);
                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd4");
                    //Added by swapnesh end
                    if (arrResult[0].ToString() == "0")
                    {
                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                }
                #endregion
                #region SAVING BUSINESS PLAN DETAIL
                if (MultiView1.ActiveViewIndex == 1)
                {
                    htParam.Clear();
                    //COMMENT by Prathamesh 9-6-15
                    htParam.Add("@CndNo", txtcndid.Text.ToString().Trim());
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@TgtYrProspect01", txtbusinessplannooflives11.Text.Trim());
                    htParam.Add("@TgtYrProspect02", txtbusinessplannooflives21.Text.Trim());
                    htParam.Add("@TgtYrProspect03", txtbusinessplannooflives31.Text.Trim());
                    htParam.Add("@TgtYrInc01", txtbusinessplansumassured11.Text.Trim());
                    htParam.Add("@TgtYrInc02", txtbusinessplannsumassured21.Text.Trim());
                    htParam.Add("@TgtYrInc03", txtbusinessplannsumassured31.Text.Trim());
                    htParam.Add("@TgtFYC01", txtbusinessplannfirstyearpremium11.Text.Trim());
                    htParam.Add("@TgtFYC02", txtbusinessplannfirstyearpremium21.Text.Trim());
                    htParam.Add("@TgtFYC03", txtbusinessplannfirstyearpremium31.Text.Trim());
                    htParam.Add("@IsFullTime", rbtimework.SelectedValue == "0" ? "0" : "1");
                    htParam.Add("@PastAchievement", txtpastachievement.Text.Trim());
                    htParam.Add("@RelativeAtWork", rbrelatedemp.SelectedValue == "Y" ? "Y" : "N");
                    htParam.Add("@RelativeAtWorkDesc", txtrelativeworkdesc.Text.Trim());
                    htParam.Add("@CreateBy", sessionuser);

                    arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd5");

                    if (arrResult[0].ToString() == "0")
                    {
                        //lblpopup.Text = "Profiling updated successfully." + "</br></br>Candidate ID: " + lblqcndno.Text.Trim() + "<br/>Application No: " + lblqappno.Text.Trim() + "<br/>Candidate name: " + lblqgivenname.Text.Trim() + " " + lblqsurname.Text.Trim() +
                        //    "";
                        //mdlpopup.Show();
                        //ProgressBarModalPopupExtender.Hide();
                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Visible = true;
                    }
                }


                ViewState["Pan"] = txtCurrentID.Text;
                #endregion

                if (cbTagLcn.Checked == true)
                {
                    BindGrid(txtcndid.Text, txtapplicationno.Text);
                }
                #endregion

                string mess = "Candidate updation done successfully.";
            c2.Attributes.Add("style", "display:block");
            lbl2.Text = mess + "</br><br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Candidate No: " + Request.QueryString["CndNo"].ToString() + "<br/>Application No: " + txtapplicationno.Text;
                    
                mdlpopup.Show();
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;

                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        
    }

    private void BindGrid(string strCndNo, string strApplicationNo)
    {
        Hashtable htComp = new Hashtable();
        DataSet dsComp = new DataSet();
        if (ddlCandidatetype.SelectedValue == "C")
        {
            Session["datatable"] = gvComposite;
            foreach (GridViewRow row in gvComposite.Rows)
            {
                Label lblCategory = (Label)row.FindControl("lblCategory");
                Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
                Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
                Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
                Label lblDateCessation = (Label)row.FindControl("lblDateCessation");
                Label lblReasonCessation = (Label)row.FindControl("lblReasonCessation");
                htComp.Clear();
                if (txtcndid.Text == null)
                {
                    htComp.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htComp.Add("@CndNo", txtcndid.Text);
                }
                if (txtapplicationno.Text == null)
                {
                    htComp.Add("@ApplicationNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htComp.Add("@ApplicationNo", txtapplicationno.Text.Trim());
                }

                htComp.Add("@Category", lblCategory.Text.Trim());
                htComp.Add("@NameofInsurer", lblNameInsurer.Text.Trim());
                htComp.Add("@AgencyCodeNumber", lblAgencyCode.Text.Trim());
                htComp.Add("@DateOfAppointmentAsAgent", lblDateAppointment.Text.Trim());
                htComp.Add("@DateOfCessationOfAgency", lblDateCessation.Text.Trim());
                htComp.Add("@ReasonForCessationOfAgency", lblReasonCessation.Text.Trim());
                htComp.Add("@CreateBy", Session["UserId"].ToString());
                htComp.Add("@RecruitAgtCode", txtrecagent.Text);
                htComp.Add("@DirectAgtCode", txtrecagent.Text);
                htComp.Add("@Flag", "1");
                htComp.Add("@UpdateBy", Session["UserId"].ToString());
                if (ddlCandidatetype.SelectedValue != "Select")//added by usha ma'am 19-10-2022
                {
                    htComp.Add("@CandidateType", ddlCandidatetype.SelectedValue);
                }
                else
                {
                    htParam.Add("@CandidateType", System.DBNull.Value);
                }
                //if (ViewState["ProspectId"] == null)
                //{
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("prc_compositedetailsIns", htComp);
                //}
                if (dsComp != null)
                {
                    if (dsComp.Tables.Count > 0 && dsComp.Tables[0].Rows.Count > 0) { }
                }
            }
        }
        else if (ddlCandidatetype.SelectedValue == "T")
        {
            Session["datatable"] = gvTrnsfr;
            //htComp.Add("@CndNo", txtcndid.Text);
            if (ViewState["ProspectId"] == null)
            {
                htComp.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            }
            else
            {
                htComp.Add("@CndNo", txtcndid.Text);
            }
            htComp.Add("@Flag", "0");
            dsComp = dataAccessclass.GetDataSetForPrcRecruit("prc_compositedetailsIns", htComp);
            foreach (GridViewRow row in gvTrnsfr.Rows)
            {
                Label lblDate = (Label)row.FindControl("lblDate");
                Label lblCategory = (Label)row.FindControl("lblCategory");
                Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
                Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
                Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
                Label lblDateCessation = (Label)row.FindControl("lblDateCessation");
                Label lblReasonCessation = (Label)row.FindControl("lblReasonCessation");

                htComp.Clear();

                if (ViewState["ProspectId"] == null)
                {
                    htComp.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htComp.Add("@CndNo", txtcndid.Text);
                }
                if (ViewState["ProspectId"] == null)
                {
                    htComp.Add("@ApplicationNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htComp.Add("@ApplicationNo", txtapplicationno.Text.Trim());
                }
                htComp.Add("@ICDate", lblDate.Text.Trim());
                htComp.Add("@Category", lblCategory.Text.Trim());
                htComp.Add("@NameofInsurer", lblNameInsurer.Text.Trim());
                htComp.Add("@AgencyCodeNumber", lblAgencyCode.Text.Trim());
                htComp.Add("@DateOfAppointmentAsAgent", lblDateAppointment.Text.Trim());
                htComp.Add("@DateOfCessationOfAgency", lblDateCessation.Text.Trim());
                htComp.Add("@ReasonForCessationOfAgency", lblReasonCessation.Text.Trim());
                htComp.Add("@CreateBy", Session["UserId"].ToString());
                htComp.Add("@RecruitAgtCode", txtrecagent.Text);
                htComp.Add("@DirectAgtCode", txtrecagent.Text);
                //if (ViewState["ProspectId"] == null)
                //{
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("prc_compositedetailsIns", htComp);
                //}
                if (dsComp != null)
                {
                    if (dsComp.Tables.Count > 0 && dsComp.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
        }
        ViewState["Pan"] = txtCurrentID.Text;
    }
    #endregion
    #region IsAlphaNumeric method
    public bool IsAlphaNumeric(String strToCheck)
    {
        Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9 ]");
        return !objAlphaNumericPattern.IsMatch(strToCheck);
    }
    #endregion

    #region 'btnCancel_Click' Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ViewState["strClear"] != null)
        {
            if (ViewState["strClear"].ToString() == "1")
            {
                cboTitle.SelectedIndex = 0;
                txtGivenName.Text = "";
                txtDOB.Text = "";
                txtsurname.Text = "";
                TxtAnnivrsryDt.Text = "";
                txtFathername.Text = "";
                cboGender.SelectedIndex = 0;
                ddlRelwithFather.SelectedIndex = 0;
                ddlCasteCat.SelectedIndex = 0;
                ddlPrimProf.SelectedIndex = 0;
                ddlcategory.SelectedIndex = 0;
                cboMaritalStatus.SelectedIndex = 0;
                ddlCandidatetype.SelectedIndex = 0;
                ddlFessWav.SelectedIndex = 0;
                if (ddlCandidatetype.SelectedValue == "T")
                {

                    txtIC.Text = "";
                    ddlCaTrnsfr.SelectedIndex = 0;
                    ddlNameInTrnsfr.SelectedIndex = 0;
                    ddlStsTrnsfr.SelectedIndex = 0;
                    txtAgencyCodeTrnsfr.Text = "";
                    txtDateOfAppointmentTrnsfr.Text = "";
                    txtDateOfCessationTrnsfr.Text = "";
                    txtReasonForCessationTrnsfr.Text = "";
                }
                if (ddlCandidatetype.SelectedValue == "C")
                {
                    ddlCatComp.SelectedIndex = 0;
                    ddlNameIns.SelectedIndex = 0;
                    ddlSts.SelectedIndex = 0;
                    txtAgencyCode.Text = "";
                    txtDateOfAppointment.Text = "";
                    txtDateOfCessation.Text = "";
                    txtReasonForCessation.Text = "";
                }
            }

            if (ViewState["strClear"].ToString() == "2")
            {
                ddlDstbnMethod.SelectedIndex = 0;
                txthometel.Text = "";
                txtMobile2.Text = "";
                txtMobileTel.Text = "";
                txtWorkTel.Text = "";
                txtemail.Text = "";
                txtEmail2.Text = "";
            }

            if (ViewState["strClear"].ToString() == "3")
            {
                ddlCnctType.SelectedIndex = 0;
                txtAddrP1.Text = "";
                txtAddrP2.Text = "";
                txtAddrP3.Text = "";
                ddlState.SelectedIndex = 0;
                txtVillage.Text = "";
                txtcity.Text = "";
                txtarea.Text = "";
                txtDistric.Text = "";
                txtPinP.Text = "";
                txtPermAdd1.Text = "";
                txtPermAdd2.Text = "";
                txtPermAdd3.Text = "";
                ddlstate1.SelectedIndex = 0;
                txtpermDistrict.Text = "";
                txtcity1.Text = "";
                txtarea1.Text = "";
                txtpermvillage.Text = "";
                txtPermPostcode.Text = "";
            }

            if (ViewState["strClear"].ToString() == "4")
            {
                txtbnkhldname.Text = "";
                txtbnkacno.Text = "";
                txtbnkname.SelectedIndex = 0;
                txtbrnchname.Text = "";
                ddlactype.SelectedIndex = 0;
                txtifsccode.Text = "";
                txtmicrcode.Text = "";
            }

            if (ViewState["strClear"].ToString() == "5")
            {
                txtNominee.Text = "";
                Ddlrelation.SelectedIndex = 0;
                txtNomineeAge.Text = "";
                txtNomneeEmail.Text = "";
                txtNominMob.Text = "";
                txtNomnPan.Text = "";
                ddlnmbnkhldname.Text = "";
                ddlnmBrnchname.SelectedIndex = 0;
                ddlnmifscode.Text = "";
                txtnmmicr.Text = "";
                txtnmbnkacno.Text = "";
                ddlnmBnkname.SelectedIndex = 0;
                ddlnmddlactype.SelectedIndex = 0;
            }

            if (ViewState["strClear"].ToString() == "6")
            {
                ddlBasicQual.SelectedIndex = 0;
                txtBoardName.Text = "";
                txtBasicRNo.Text = "";
                txtYrPass.Text = "";
                ddleducationproof.SelectedIndex = 0;
                ddlExam.SelectedIndex = 0;
                ddlpreeamlng.SelectedIndex = 0;
                txtExmCentre.Text = "";
                ddlExmBody.SelectedIndex = 0;
            }

            if (ViewState["strClear"].ToString() == "7")
            {
                ddlagntype.SelectedIndex = 0;
                txtOthers.Text = "";
                ddlIsWrkng.SelectedIndex = 0;
                ddlcompName.SelectedIndex = 0;
                ddlNoOfYrsIns.SelectedIndex = 0;
                ddlNoOfYrs.SelectedIndex = 0;
                ddlTypeOfVehicle.SelectedIndex = 0;
                ddlVechManuf.SelectedIndex = 0;
                txtDlrCompName.Text = "";
                txtDlrOth.Text = "";
                ddlAvgMonthlyIncm.SelectedIndex = 0;
                ddlComp1Name.SelectedIndex = 0;
                ddlMnthVol1.SelectedIndex = 0;
                ddlComp2Name.SelectedIndex = 0;
                ddlMnthVol2.SelectedIndex = 0;
                ddlRGIMnthVol.SelectedIndex = 0;
            }
        }
    }

    #endregion
    //added by pranjali on 30-04-2014 start
    #region GetEmployeeCodeDetails
    public DataSet GetEmployeeDetail(string EmployeeCode)
    {
        DataSet dsResult = new DataSet();
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@EmpCode", EmployeeCode);
        dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetEmpCodeDtls", htparam);
        //dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetEmployeeCodeDtls", htparam);
        return dsResult;
    }
    #endregion
    //added by pranjali on 30-04-2014 end

    #region Referral Employee Validation
    protected void btnVerifyRefEmpBy_Click(object sender, EventArgs e)
    {
        try
        {
            drResult = null;
            bool IsFound = false;
            hdnRefEmpBy.Value = "0";
            lblErrRefEmpBy.Text = "";
            txtRefByadvEmpName.Text = string.Empty;

            if (txtReferredEmpBy.Text.ToString() == "")
            {
                lblErrRefEmpBy.Text = "Please Enter Referral Code";
                txtReferredEmpBy.Focus();
                return;
            }

            //Added By Asrar on 27-06-2013 for converting Inline query into procedure to Get legal Name start

            httable.Clear();
            httable.Add("@EmpCode", txtReferredEmpBy.Text.Trim());
            httable.Add("@AgentCode", txtReferredEmpBy.Text.Trim());
            //drResult = dataAccessRecruit.exec_reader_prc_rec("prc_GetAgnName", httable);
            drResult = dataAccessclass.exec_reader_prc_rec("prc_GetAgnName", httable);

            //Added By Asrar on 27-06-2013 for converting Inline query into procedure to Get legal Name End

            if (drResult.HasRows)
            {
                while (drResult.Read())
                {
                    hdnRefEmpBy.Value = "1";
                    IsFound = true;
                    txtRefByadvEmpName.Text = drResult[0].ToString();
                    txtRefByadvEmpName.Enabled = false;
                }

            }
            drResult = null;

            if (IsFound == false)
            {

                drResult = null;
                txtRefByadvEmpName.Enabled = true;
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



    //Added by Praathamesh 6-8-15 start
    #region btnVerifyPAN_Click method
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {
        try
        {
            lblPANMsg.Text = "";
            hdnPan.Value = "0";
            string pan1 = ViewState["Pan"].ToString();
            if (txtCurrentID.Text != pan1)
            {

                //added by pranjali on 10-04-2014 start
                if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                {
                    strProspectID = Request.QueryString["ProspectId"].ToString();
                }
                else
                {
                    strProspectID = txtapplicationno.Text.ToString().Trim();
                }
                //added by pranjali on 10-04-2014 end
                bool isFound = false;
                DataSet dsRes = new DataSet();
                //lblPANMsg.Text = "";

                htParam.Clear();
                htParam.Add("@PAN", txtCurrentID.Text.Trim());
                dsRes = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetChkPANExist", htParam);
                //// added by usha for for composite 

                for (int i = 0; i < dsRes.Tables.Count; i++)
                {
                    if (dsRes.Tables[i].Rows.Count > 0)
                    {

                        if (dsRes.Tables[0].Rows.Count > 0)
                        {

                            if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "180" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "C")// added by usha for  
                            {
                                isFound = true;
                            }//ended  by usha 
                        }


                        if (dsRes.Tables.Count > 1)
                        {
                            if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")//Added by rachana to show empcode in duplicate PAN
                            {
                                hdnAgnCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][3]).Trim();
                            }
                        }
                        else
                        {
                            hdnAgnCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][0]).Trim();
                        }
                    }

                }
                if ((isFound == true))//&& (strProspectID != hdnAgnCode.Value))
                {
                    if (dsRes.Tables[0].Rows.Count > 0 || dsRes.Tables[1].Rows.Count > 0)
                    {
                        if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "")// added by usha  
                        {
                            if (Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim() != "")
                            {
                                hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim();
                                lblPANMsg.Text = "Duplicate Match Found For <br/>Agent Broker Code :- " + hdnAgentBrokerCode.Value;
                            }
                            else if (Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim() != "")
                            {
                                hdnUrn.Value = Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim();
                                lblPANMsg.Text = "Duplicate Match Found For <br/>URN NO :- " + hdnUrn.Value;
                            }
                            else
                            {
                                lblPANMsg.Text = "Duplicate Match Found For <br/>ApplicationNo :- " + hdnAgnCode.Value;

                            }
                            lblPANMsg.ForeColor = Color.Red;
                            hdnPan.Value = "0";
                            htPan.Add("@DupAppNo", Convert.ToString(dsRes.Tables[0].Rows[0][0]).Trim());
                            if (dsRes.Tables[0].Rows[0][5].ToString().Trim() != "")
                            {
                                htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim());
                            }
                            else
                            {
                                htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                            }
                            if (dsRes.Tables[0].Rows[0][2].ToString().Trim() != "")
                            {
                                htPan.Add("@DupURNNo", Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim());
                            }
                            else
                            {
                                htPan.Add("@DupURNNo", System.DBNull.Value);
                            }
                            if (dsRes.Tables[0].Rows[0][7].ToString().Trim() != "")
                            {
                                htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[0].Rows[0][7]).Trim());
                            }
                            else
                            {
                                htPan.Add("@DupSAPCode", System.DBNull.Value);
                            }
                            if (dsRes.Tables[0].Rows[0][6].ToString().Trim() != "")
                            {
                                htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[0].Rows[0][6]).Trim());
                            }
                            else
                            {
                                htPan.Add("@DupAgentCode", System.DBNull.Value);
                            }
                        }
                    }
                }

                else if (dsRes.Tables.Count > 1 && dsRes.Tables[1].Rows.Count > 0)
                {
                    if (Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim() != "")
                    {
                        hdnEmpCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>Employee Code :- " + hdnEmpCode.Value;
                    }
                    else if (Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim() != "")
                    {
                        hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>Agent Broker Code :- " + hdnAgentBrokerCode.Value;
                    }
                    else
                    {
                        lblPANMsg.Text = "Duplicate Match Found For <br/>AgentCode :- " + hdnAgnCode.Value;
                    }
                    lblPANMsg.ForeColor = Color.Red;
                    hdnPan.Value = "0";
                    htPan.Clear();
                    //htPan.Add("@DupAppNo", Convert.ToString(dsRes.Tables[0].Rows[0][0]).Trim());
                    if (dsRes.Tables[1].Rows[0][2].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[1].Rows[0][0].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[1].Rows[0][0]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgentCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")
                    {
                        htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupSAPCode", System.DBNull.Value);
                    }

                    htPan.Add("@DupPAN", txtCurrentID.Text.Trim());
                    htPan.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    int x = dataAccessclass.execute_sprcrecruit("Prc_InsDupPANDtls", htPan);
                }
                else//added by usha 
                {
                    lblPANMsg.Text = "PAN NO. Verified";
                    lblPANMsg.ForeColor = Color.Green;
                    hdnPan.Value = "1";

                }
            }
            else//added by usha 
            {
                lblPANMsg.Text = "PAN NO. Verified";
                lblPANMsg.ForeColor = Color.Green;
                hdnPan.Value = "1";

            }



            //Added by pranjali
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
    //added by ank on 24 May 2011 for adding Field Refferred By
    #endregion

    //Added by Praathamesh 6-8-15 end

    #region btnVerifyRefBy_Click method



    protected void btnVerifyRefBy_Click(object sender, EventArgs e)
    {
        try
        {
            drResult = null;
            bool IsFound = false;
            hdnRefBy.Value = "0";
            //IsFoundRefBy = false;
            lblErrRefBy.Text = "";
            txtRefByadvName.Text = string.Empty;

            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Legal Name Reffered By start
            httable.Clear();
            httable.Add("@EmpCode", 0);
            httable.Add("@AgentCode", txtReferredBy.Text.Trim());
            //drResult = dataAccessRecruit.exec_reader_prc_rec("prc_GetAgnName", httable);
            drResult = dataAccessclass.exec_reader_prc_rec("prc_GetAgnName", httable);
            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Legal Name Reffered By End
            //drResult = dataAccessRecruit.exec_reader("Select legalname from InscCommon..Agn with(nolock) Where bizsrc='AG' and agenttype in('AG','VA') and AgentCode='" + txtReferredBy.Text.Trim() + "'", CONN_Recruit);

            if (drResult.HasRows)
            {
                while (drResult.Read())
                {
                    hdnRefBy.Value = "1";
                    IsFound = true;
                    txtRefByadvName.Text = drResult[0].ToString();
                }

            }
            drResult = null;
            if (IsFound == false)
            {
                //Added By Asrar on 27-06-2013 for converting Inline query into procedure Agent Details on the bases of Agent Code start
                httable.Clear();
                httable.Add("@AgentCode", txtReferredBy.Text.Trim());
                //drResult = dataAccessRecruit.exec_reader_prc_rec("prc_AgentDtlAgnCode", httable);
                drResult = dataAccessclass.exec_reader_prc_rec("prc_AgentDtlAgnCode", httable);
                //Added By Asrar on 27-06-2013 for converting Inline query into procedure Agent Details on the bases of Agent Code End

                //drResult = dataAccessRecruit.exec_reader("Select * from InscCommon..Agn with(nolock) Where  agentCode='" + txtReferredBy.Text.Trim() + "'", CONN_Recruit);
                if (drResult.HasRows)
                {
                    lblErrRefBy.Text = "Applicable only for Agency Licensed Advisors";
                }
                else
                {
                    lblErrRefBy.Text = "No Match Found";
                }
                drResult = null;
                txtReferredBy.Text = string.Empty;
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

    #region 'btnVerifyCSC_Click' Event to fetch recruit info

    #endregion

    #region "LinkPages"
    protected void lnkPage1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        lnkPage1.BackColor = Color.LightYellow;
        lnkPage2.BackColor = Color.Transparent;
        //lnkPage3.BackColor = Color.Transparent;
        //LinkPage5.BackColor = Color.Transparent;
        //LinkPage4.BackColor = Color.Transparent;
        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 1.png";
        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";
        //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
        //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
        //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
        lblMessage.Text = "";
        //FillRequiredDataForCndPersonal();
        FillHiddenValues();
        //btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm1();");
        btnUpdate.Attributes.Add("onClick", "javascript: return  funValidate();");
        //btnUpdate.Attributes.Add("onClick", "javascript: return funProfiling();");
        // txtapplicationno.Text = lblqappno.Text;
        // txtGivenName.Text=lblqgivenname.Text;
        //txtname.Text= lblqsurname.Text;



    }

    //comment by Prathamesh 5-6-15 start

    //protected void lnkPage2_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 1;
    //    lnkPage1.BackColor = Color.Transparent;
    //    lnkPage2.BackColor = Color.LightYellow;
    //    //lnkPage3.BackColor = Color.Transparent;
    //    //LinkPage5.BackColor = Color.Transparent;
    //    //LinkPage4.BackColor = Color.Transparent;
    //    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //    lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 1.png";
    //    //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
    //    //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
    //    //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
    //    lblMessage.Text = "";
    //    //Response.Redirect("FrmSubmitRetrievalRqst.aspx",true);
    //    GetPersonalInformation();
    //    //FillRequiredDataForCndPersonal();
    //    FillRequiredDataForCndQualification();
    //    FillHiddenValues();
    //    btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm2();");
    //}
    //protected void lnkPage3_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 2;
    //    lnkPage1.BackColor = Color.Transparent;
    //    lnkPage2.BackColor = Color.Transparent;
    //    //lnkPage3.BackColor = Color.LightYellow;
    //    //LinkPage5.BackColor = Color.Transparent;
    //    //LinkPage4.BackColor = Color.Transparent;
    //    lblMessage.Text = "";
    //    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //    lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //    //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst1.png";
    //    //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
    //    //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
    //    GetPersonalInformation();
    //    FillRequiredDataForCndEmpHistory();//added by pranjali on 02-04-2014
    //    //FillRequiredDataForCndPersonal();//commented by pranjali on 02-04-2014
    //    FillHiddenValues();
    //    btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm3();");

    //}
    //protected void LinkPage4_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 3;
    //    lnkPage1.BackColor = Color.Transparent;
    //    lnkPage2.BackColor = Color.Transparent;
    //    //lnkPage3.BackColor = Color.Transparent;
    //    //LinkPage4.BackColor = Color.LightYellow;
    //    //LinkPage5.BackColor = Color.Transparent;
    //    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //    lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //    //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
    //    //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp1.png";
    //    //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
    //    lblMessage.Text = "";
    //    GetPersonalInformation();
    //    FillRequiredDataForCndPsnlhistory();//added by pranjali on 02-04-2014
    //    //FillRequiredDataForCndPersonal();//commented by pranjali on 02-04-2014
    //    FillHiddenValues();
    //    btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm4();");

    //}
    //protected void LinkPage5_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 4;
    //    lnkPage1.BackColor = Color.Transparent;
    //    lnkPage2.BackColor = Color.Transparent;
    //    //lnkPage3.BackColor = Color.Transparent;
    //    //LinkPage4.BackColor = Color.Transparent;
    //    //LinkPage5.BackColor = Color.LightYellow;
    //    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //    lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //    //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
    //    //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
    //    //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 1.png";
    //    lblMessage.Text = "";
    //    GetPersonalInformation();
    //    FillRequiredDataForCndBizPlan();
    //    FillHiddenValues();
    //    btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm5();");

    //}

    //comment by Prathamesh 5-6-15 end
    #endregion


    //This button added by Prathamesh for Profiling
    protected void lnkPage2_Click(object sender, ImageClickEventArgs e)
    {
        //Mrunal changes
        olng = new multilingualManager("DefaultConn", "CndReg.aspx?&CndNo" + txtcndid.Text + "", Session["UserLangNum"].ToString());
        //olng = new multilingualManager("DefaultConn", "FrmSubmitRetrievalRqst.aspx?&CndNo" + txtcndid.Text + "", Session["UserLangNum"].ToString());
        ////InitializeControlProfiling();
        // GetProfilingDtls();
        MultiView1.ActiveViewIndex = 1;
        lnkPage1.BackColor = Color.Transparent;
        lnkPage2.BackColor = Color.LightYellow;
        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
        lblMessage.Text = "";
        GetPersonalInformation();
        FillRequiredDataForCndQualification();
        FillRequiredDataForCndEmpHistory();
        FillRequiredDataForCndPsnlhistory();
        FillRequiredDataForCndBizPlan();
        FillHiddenValues();
        FillProspectInfo();
        // btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");
        //btnUpdate.Attributes.Add("onClick", "javascript: return funValidateForm2();");//Uncomment by Prathamesh 16-7-15
        btnUpdate.Attributes.Add("onClick", "javascript: return  funProfiling();");// added by np on 24.6
        //btnUpdate.Attributes.Add("onClick", "javascript: return  funValidatePro();");// added by np on 24.6
    }
    //#endregion


    //Added by Prathamesh 7-7-15 for display appNo and Name through Prospect Reg start
    protected void FillProspectInfo()
    {
        lblqappno.Text = txtapplicationno.Text;
        lblqgivenname.Text = txtGivenName.Text;
        lblqsurname.Text = txtsurname.Text;
    }
    //Added by Prathamesh 7-7-15 END

    # region METHOD "FillRequiredDataForCndPersonal"
    protected void FillRequiredDataForCndPersonal()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            htParam.Add("@CndNo", strProspectID);
        }
        else
        {
            htParam.Add("@CndNo", txtcndid.Text.Trim());
        }
        dsPanResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetPAN", htParam);
        if (dsPanResult.Tables[0].Rows.Count > 0)
        {
            txtCurrentID.Text = dsPanResult.Tables[0].Rows[0]["PAN"].ToString();
        }
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            DataSet ds = new DataSet();
            Hashtable htnominee = new Hashtable();
            if (Request.QueryString["CndNo"] != null && Request.QueryString["Type"] == "E")
            {
                htnominee.Clear();
                htnominee.Add("@CndNo", txtcndid.Text.Trim());
                htnominee.Add("@ProspectID", "");
                htnominee.Add("@Flag", "1");
            }
            else
            {
                htnominee.Clear();
                htnominee.Add("@CndNo", "");
                htnominee.Add("@ProspectID", strProspectID);
                htnominee.Add("@Flag", "2");
            }
            ds = dataAccessclass.GetDataSetForPrcDBConn("Prc_GetCanDetails", htnominee, "INSCRecruitConnectionString");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["prreg"] = ds.Tables[0].Rows[0]["NomineeName"].ToString();
            }
            if (Request.QueryString["ACT"] != null)
            {
                if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] == null)
                {
                    htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd1", htParam, "INSCRecruitConnectionString");
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_Cnd_Edit_getCndByProspectID", htParam, "INSCRecruitConnectionString");//commented by ajay yadav 27.10.2022 to get same data pro 
                }
                else if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                {
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_Edit_getCnd1", htParam, "INSCRecruitConnectionString");
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_Edit_getCnd1", htParam, "INSCRecruitConnectionString");
                    if (dsResult.Tables.Count > 0)
                    {
                        //if (dsResult.Tables[0].Rows.Count > 0)
                        //{
                        //    if (dsResult.Tables[0].Rows[0]["AutoWavierflag"].ToString() == "Y")
                        //    {
                        //        ChkFeesWavier.Checked = true;
                        //    }
                        //    else
                        //    {
                        //        ChkFeesWavier.Checked = false;
                        //    }
                        //}
                    }
                }
                else
                {
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd1", htParam, "INSCRecruitConnectionString");
                    htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd1", htParam, "INSCRecruitConnectionString");
                    if (dsResult.Tables.Count > 0)
                    {
                        //if (dsResult.Tables[0].Rows.Count > 0)
                        //{
                        //    if (dsResult.Tables[0].Rows[0]["AutoWavierflag"].ToString() == "Y")
                        //    {
                        //        ChkFeesWavier.Checked = true;
                        //    }
                        //    else
                        //    {
                        //        ChkFeesWavier.Checked = false;
                        //    }
                        //}
                    }
                }
            }
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    txtcndid.Text = txtcndid.Text;
                    //------------------Change made to avoid agent updation after status 130-16/07/2008-----------
                    if (dsResult.Tables[0].Rows[0]["CndStatus"] != null)
                    {
                        if (Convert.ToInt32(dsResult.Tables[0].Rows[0]["CndStatus"]) >= 130)
                        {
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            btnUpdate.Enabled = true;
                        }
                        if (Convert.ToInt32(dsResult.Tables[0].Rows[0]["CndStatus"]) >= 110)
                        {

                        }
                    }
                    //------------------Change End Here to avoid agent updation after status 130--16/07/2008-----------
                    if (dsResult.Tables[0].Rows[0]["CndCat"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]).Trim() != "")
                        {
                            if (ddlcategory.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"])) != null)
                            {
                                ddlcategory.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]);
                            }
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["CndCat"].ToString() == "U")
                    {
                        ddlBasicQual.SelectedIndex = 0;
                        ddlBasicQual.Enabled = true;
                    }
                    if (dsResult.Tables[0].Rows[0]["CndCat"].ToString() == "P")
                    {
                        txtVillage.BackColor = ColorTranslator.FromHtml("#ffffb2");
                        txtpermvillage.BackColor = ColorTranslator.FromHtml("#ffffb2");

                    }
                    if (dsResult.Tables[0].Rows[0]["Title"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]).Trim() != "")
                        {
                            cboTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["EntryDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EntryDate"].ToString().Trim() != "")
                        {
                            txtregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                            lblqregdate.Text = txtregdate.Text;
                        }
                    }
                    else
                    {
                        txtregdate.Text = "";
                    }

                    if (dsResult.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() != "")
                    {
                        divIsSpecified.Attributes.Add("style", "display:block");
                        rbtIsSP.SelectedValue = dsResult.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "N")
                        {
                            tr_IsSPDtls.Visible = false;
                        }
                        else
                        {
                            tr_IsSPDtls.Visible = true;
                        }
                    }
                    else
                    {
                        divIsSpecified.Attributes.Add("style", "display:none");
                        rbtIsSP.ClearSelection();
                        tr_IsSPDtls.Visible = false;
                    }

                    if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] == null)
                    {
                        DataSet dsIsSpPrsn = new DataSet();
                        dsIsSpPrsn = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
                        ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();
                        if (dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim() == "YES")
                        {
                            divIsSpecified.Attributes.Add("style", "display:block");
                        }
                        else
                        {
                            divIsSpecified.Attributes.Add("style", "display:none");
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["CACode"].ToString().Trim() != "")
                    {
                        txtCACode.Text = dsResult.Tables[0].Rows[0]["CACode"].ToString().Trim();
                        tr_IsSPDtls.Visible = true;
                    }
                    else
                    {
                        tr_IsSPDtls.Visible = false;
                    }
                    if (dsResult.Tables[0].Rows[0]["CAName"].ToString().Trim() != "")
                    {
                        txtCAName.Text = dsResult.Tables[0].Rows[0]["CAName"].ToString().Trim();
                        tr_IsSPDtls.Visible = true;
                    }
                    else
                    {
                        tr_IsSPDtls.Visible = false;
                    }
                    if (ViewState["prreg"] != null)
                    {
                        txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                        if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "Rev" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                        {
                            if (dsResult.Tables[0].Rows[0]["StateCode"].ToString() == "" || dsResult.Tables[0].Rows[0]["StateCode"].ToString() == null) { }
                            else
                            {
                                ddlState.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["StateCode"]);
                            }
                            txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CountryDesc"]);
                        }
                    }
                    txtapplicationno.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ProspectID"]);
                    txtGivenName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GivenName"]);
                    txtsurname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Surname"]);
                    txtFathername.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["FatherName"]);
                    if (dsResult.Tables[0].Rows[0]["Relation"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Relation"]).Trim() != "")
                        {
                            if (ddlRelwithFather.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Relation"])) != null)
                            {
                                ddlRelwithFather.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Relation"]);
                            }
                        }
                    }
                    FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]));
                    ddlCandType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CndAgtType"]);
                    ddlCandType.SelectedItem.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgenCandTtype"]);
                    if (dsResult.Tables[0].Rows[0]["Gender"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]).Trim() != "")
                        {
                            if (cboGender.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"])) != null)
                            {
                                cboGender.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]);
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
                    if (cboMaritalStatus.SelectedValue == "M")
                    {
                        cboMaritalStatus_SelectedIndexChanged(null, null);
                    }
                    if (dsResult.Tables[0].Rows[0]["CndAnniversaryDt"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CndAnniversaryDt"]).Trim() != "")
                        {
                            TxtAnnivrsryDt.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CndAnniversaryDt"]).Trim();
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["ExamLanguage"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ExamLanguage"]).Trim() != "")
                        {
                            if (ddlpreeamlng.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ExamLanguage"])) != null)
                            {
                                ddlpreeamlng.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExamLanguage"]);
                            }
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["CasteCat"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim() != "")
                        {
                            if (ddlCasteCat.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"])) != null)
                            {
                                ddlCasteCat.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]);
                            }
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["Exam"].ToString() != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim() != "")
                        {
                            if (ddlExam.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim()) != null)
                            {
                                ddlExam.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim();
                            }
                        }
                    }
                    txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                    if (ViewState["prreg"] != null)//added by pranjali on 03-04-2014
                    {
                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                        {
                            if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                            //if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                            {
                                if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "B1" || dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "P1")
                                {
                                    if (dsResult.Tables[0].Rows[i]["CnctType"] != null)
                                    {
                                        if (Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]).Trim() != "")
                                        {
                                            ddlCnctType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]);
                                        }
                                    }

                                    txtAddrP1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                                    txtAddrP2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                                    txtAddrP3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);
                                    txtVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Village"]);
                                    //Added by pranjali as per proc modification start
                                    //ddlState.SelectedItem.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["StateName"]);
                                    ddlState.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                                    //txtStateCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                                    //txtStateDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateDesc"]);
                                    //Added by pranjali as per proc modification end
                                    txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["District"]);
                                    txtcity.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["City"]);
                                    txtarea.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Area"]);
                                    txtPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                    txtCountryCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                                    txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDesc"]);

                                    //Added by rachana on 21-04-2015 to fill hidden fields at modification menu start
                                    if (Request.QueryString["CndNo"] != null && Request.QueryString["Type"] == "E")
                                    {
                                        txtPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                        txtcity.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["City"]);
                                        txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["District"]);
                                        txtarea.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Area"]);
                                    }
                                    //Added by rachana on 21-04-2015 to fill hidden fields at modification menu end
                                    //ChkPA.Focus();

                                }
                                if (dsResult.Tables[0].Rows[0]["PermAdrInd"] != null)
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PermAdrInd"]).Trim() != "")
                                    {
                                        if (dsResult.Tables[0].Rows[0]["PermAdrInd"].ToString() == "Y")
                                        {
                                            ChkPA.Checked = true;
                                            txtPermAdd1.Enabled = false;
                                            txtPermAdd2.Enabled = false;
                                            txtPermAdd3.Enabled = false;
                                            txtpermvillage.Enabled = false;
                                            txtPermPostcode.Enabled = false;
                                            ddlstate1.Enabled = false;
                                            txtpermDistrict.Enabled = false;
                                            txtcity1.Enabled = false;
                                            txtarea1.Enabled = false;
                                            txtPermCountryCode.Enabled = false;
                                            txtPermCountryDesc.Enabled = false;
                                            btnstate1search.Enabled = false;
                                        }
                                        else
                                        {
                                            ChkPA.Checked = false;
                                        }
                                    }
                                }

                                if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "M1")
                                {
                                    //txtPermAdd1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                                    //txtPermAdd2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                                    //txtPermAdd3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);
                                    //txtpermvillage.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Village"]);
                                    //ddlstate1.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                                    //txtpermDistrict.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["District"]);
                                    //txtcity1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["City"]);
                                    //txtarea1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Area"]);
                                    //txtPermPostcode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                    //txtPermCountryCode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                                    //txtPermCountryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDescPm"]);
                                    if (Request.QueryString["CndNo"] != null && Request.QueryString["Type"] == "E")
                                    {
                                        hdnPin1.Value = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                        hdnCity1.Value = Convert.ToString(dsResult.Tables[0].Rows[i]["City"]);
                                        hdnpermDist.Value = Convert.ToString(dsResult.Tables[0].Rows[i]["District"]);
                                        hdnArea1.Value = Convert.ToString(dsResult.Tables[0].Rows[i]["Area"]);
                                    }
                                }

                               
                            }
                        }
                    }
                    DataSet DsC = new DataSet();
                    Hashtable htC = new Hashtable();
                    if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                    {
                        htC.Add("@AppNo", strProspectID);
                    }
                    else
                    {
                        htC.Add("@AppNo", txtcndid.Text.Trim());
                    }
                    DsC = dataAccessclass.GetDataSetForPrcDBConn("Prc_Get_TblBankDtlsC", htC, "INSCRecruitConnectionString");
                    if (DsC.Tables[0].Rows.Count > 0)
                    {
                        if (DsC.Tables[0].Rows[0]["Bdfor"].ToString().Trim() == "C")
                        {
                            txtbnkhldname.Text = Convert.ToString(DsC.Tables[0].Rows[0]["AcHolderName"]);
                            txtbnkacno.Text = Convert.ToString(DsC.Tables[0].Rows[0]["AccNo"]);
                            txtbnkname.SelectedValue = DsC.Tables[0].Rows[0]["BankName"].ToString().ToUpper();
                            txtbrnchname.Text = Convert.ToString(DsC.Tables[0].Rows[0]["BranchName"]);
                            ddlactype.SelectedValue = DsC.Tables[0].Rows[0]["ACType"].ToString();
                            txtifsccode.Text = Convert.ToString(DsC.Tables[0].Rows[0]["IFSC Code"]);
                            txtmicrcode.Text = Convert.ToString(DsC.Tables[0].Rows[0]["MICR Code"]);
                            txtGSTNO.Text = Convert.ToString(DsC.Tables[0].Rows[0]["GSTNO"]);
                        }
                    }

                    DataSet DsN = new DataSet();
                    Hashtable htN = new Hashtable();
                    if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                    {
                        htN.Add("@AppNo", strProspectID);
                    }
                    else
                    {
                        htN.Add("@AppNo", txtcndid.Text.Trim());
                    }
                    DsN = dataAccessclass.GetDataSetForPrcDBConn("Prc_Get_TblBankDtlsN", htN, "INSCRecruitConnectionString");
                    if (DsN.Tables[0].Rows.Count > 0)
                    {
                        if (DsN.Tables[0].Rows[0]["Bdfor"].ToString().Trim() == "N")
                        {
                            if (DsN.Tables[0].Rows[0]["NomineeName"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineeName"].ToString().Trim() != "")
                                {
                                    txtNominee.Text = DsN.Tables[0].Rows[0]["NomineeName"].ToString();
                                }
                            }
                            else
                            {
                                txtNominee.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["NomineAdvRel"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineAdvRel"].ToString().Trim() != "")
                                {
                                    Ddlrelation.SelectedValue = DsN.Tables[0].Rows[0]["NomineAdvRel"].ToString();
                                }
                            }
                            else
                            {
                                //03...07/09/2012...Miti
                                Ddlrelation.SelectedValue = "";
                                //03...07/09/2012...Miti
                            }
                            if (DsN.Tables[0].Rows[0]["NomineAge"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineAge"].ToString().Trim() != "")
                                {
                                    txtNomineeAge.Text = DsN.Tables[0].Rows[0]["NomineAge"].ToString();
                                }
                            }
                            else
                            {
                                txtNomineeAge.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["NomineeEmailID"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineeEmailID"].ToString().Trim() != "")
                                {
                                    txtNomneeEmail.Text = DsN.Tables[0].Rows[0]["NomineeEmailID"].ToString();
                                }
                            }
                            else
                            {
                                txtNomneeEmail.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["NomineeMobileTel"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineeMobileTel"].ToString().Trim() != "")
                                {
                                    txtNominMob.Text = DsN.Tables[0].Rows[0]["NomineeMobileTel"].ToString();
                                }
                            }
                            else
                            {
                                txtNominMob.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["NomineePAN"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["NomineePAN"].ToString().Trim() != "")
                                {
                                    txtNomnPan.Text = DsN.Tables[0].Rows[0]["NomineePAN"].ToString();
                                }
                            }
                            else
                            {
                                txtNomnPan.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["AcHolderName"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["AcHolderName"].ToString().Trim() != "")
                                {
                                    ddlnmbnkhldname.Text = DsN.Tables[0].Rows[0]["AcHolderName"].ToString();
                                }
                            }
                            else
                            {
                                ddlnmbnkhldname.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["AccNo"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["AccNo"].ToString().Trim() != "")
                                {
                                    txtnmbnkacno.Text = DsN.Tables[0].Rows[0]["AccNo"].ToString();
                                }
                            }
                            else
                            {
                                txtnmbnkacno.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["BankName"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["BankName"].ToString().Trim() != "")
                                {
                                    ddlnmBnkname.SelectedValue = DsN.Tables[0].Rows[0]["BankName"].ToString();
                                }
                            }
                            else
                            {
                                ddlnmBnkname.SelectedValue = "0";
                            }
                            if (DsN.Tables[0].Rows[0]["ACType"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["ACType"].ToString().Trim() != "")
                                {
                                    ddlnmddlactype.SelectedValue = DsN.Tables[0].Rows[0]["ACType"].ToString();
                                }
                            }
                            else
                            {
                                ddlnmddlactype.SelectedValue = "0";
                            }
                            if (DsN.Tables[0].Rows[0]["BranchName"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["BranchName"].ToString().Trim() != "")
                                {
                                    ddlnmBrnchname.SelectedValue = DsN.Tables[0].Rows[0]["BranchName"].ToString();
                                }
                            }
                            else
                            {
                                ddlnmBrnchname.SelectedValue = "0";
                            }
                            if (DsN.Tables[0].Rows[0]["IFSC Code"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["IFSC Code"].ToString().Trim() != "")
                                {
                                    ddlnmifscode.Text = DsN.Tables[0].Rows[0]["IFSC Code"].ToString();
                                }
                            }
                            else
                            {
                                ddlnmifscode.Text = "";
                            }
                            if (DsN.Tables[0].Rows[0]["MICR Code"] != null)
                            {
                                if (DsN.Tables[0].Rows[0]["MICR Code"].ToString().Trim() != "")
                                {
                                    txtnmmicr.Text = DsN.Tables[0].Rows[0]["MICR Code"].ToString();
                                }
                            }
                            else
                            {
                                txtnmmicr.Text = "";
                            }
                        }
                    }
                    if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                    {
                        TxtWhatsaap.Text = "";
                    }
                    else
                    {
                    }
                    txthometel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HomeTel"]);
                    txtWorkTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                    txtMobileTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MobileTel"]);
                    txtMobile2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Mobile2"]);
                    txtemail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                    txtEmail2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email2"]);
                    txtfax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                    txtdidtel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DidTel"]);
                    txtpager.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["pager"]);
                    oCommon.getDropDown(ddlPrimProf, "PrimProof", 1, "", 1);
                    ddlPrimProf.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryProf"]).Trim();
                    ddlPrimProf.Items.Insert(0, "Select");
                    //txtVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Village"]);
                    if (dsResult.Tables[0].Rows[0]["DistrbMethod"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["DistrbMethod"]).Trim() != "")
                        {

                            ddlDstbnMethod.SelectedValue = dsResult.Tables[0].Rows[0]["DistrbMethod"].ToString();
                        }
                    }
                    if (ViewState["prreg"] != null)
                    {

                        if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "Rev" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                        {
                            txtCurrentID.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Pan"]);
                            //txtaadhr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AadharNo"]);
                            //Added by AshishP 07-04-2018 DecryptAadhar
                            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
                            {
                                //txtaadhr.Enabled = true;
                                //if (dsResult.Tables[0].Rows[0]["AadharNo"].ToString() != "")
                                //{
                                //    string strAadharReponse = AadharVault.DecryptAadhar(dsResult.Tables[0].Rows[0]["AadharNo"].ToString());
                                //    AadharVault.AadharResponse AadharResponse = new AadharVault.AadharResponse();
                                //    AadharVault.AadharResponse deserializedAadharResponse = JsonConvert.DeserializeObject<AadharVault.AadharResponse>(strAadharReponse);

                                //    if (deserializedAadharResponse.Errorcode == "" && deserializedAadharResponse.Response != "")
                                //    {
                                //        txtaadhr.Text = AadharVault.AadharNumberMask(deserializedAadharResponse.Response.ToString());

                                //    }
                                //    txtaadhr.Enabled = false;
                                //}
                                //Added by AshishP 07-04-2018 DecryptAadhar
                            }
                            else
                            {

                                //if (dsResult.Tables[0].Rows[0]["AadharNo"].ToString() != "")
                                //{
                                //    string strAadharReponse = AadharVault.DecryptAadhar(dsResult.Tables[0].Rows[0]["AadharNo"].ToString());
                                //    AadharVault.AadharResponse AadharResponse = new AadharVault.AadharResponse();
                                //    AadharVault.AadharResponse deserializedAadharResponse = JsonConvert.DeserializeObject<AadharVault.AadharResponse>(strAadharReponse);

                                //    if (deserializedAadharResponse.Errorcode == "" && deserializedAadharResponse.Response != "")
                                //    {
                                //        txtaadhr.Text = AadharVault.AadharNumberMask(deserializedAadharResponse.Response.ToString());

                                //    }
                                //    txtaadhr.Enabled = false;
                                //}
                                //Added by AshishP 07-04-2018 DecryptAadhar
                            }
                            //04...07/09/2012...Miti
                            hdnpanedit.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Pan"]);
                            //04...07/09/2012...Miti
                        }
                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {
                                ////if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                                ////{
                                // FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                //}
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                //if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"])) != null)
                                //{
                                //  FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]));
                                ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                                FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]));
                                // }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["AgentType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim() != "")
                            {

                                if (ddlAgntType.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"])) != null)
                                {
                                    ddlAgntType.Visible = true;
                                    ddlAgnTypes.Visible = false;
                                    ddlAgntType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim();
                                    ddlAgntType.Enabled = false;
                                }

                            }
                        }
                        if (Request.QueryString["ACT"] == "Edit" || Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)/* && Request.QueryString["CndNo"] != null)*/
                        {
                            if (dsResult.Tables[0].Rows[0]["UnitcodeIL"].ToString().Trim() != null)
                            {
                                Hashtable htcode = new Hashtable();
                                DataSet dsBranchCode = new DataSet();
                                htcode.Add("@UNitcode", Convert.ToString(dsResult.Tables[0].Rows[0]["UnitcodeIL"]).Trim());
                                htcode.Add("@BizSrc", Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                htcode.Add("@Chncls", Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                                dsBranchCode = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                                if (dsBranchCode != null && dsBranchCode.Tables.Count > 0 && dsBranchCode.Tables[0].Rows.Count > 0)
                                {
                                    string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                                    string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitcodeIL"]).Trim();
                                    ViewState["cmsunitcode"] = cmsunitcode;//added by usa 09.01.2015
                                    txtImmLeader.Text = branch + "(" + cmsunitcode + ")";
                                }
                            }

                            txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalNameIL"]);
                            txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalNameRC"]);
                            if (dsResult.Tables[0].Rows[0]["ProofIDDoc"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim() != "")
                                {
                                    ddleducationproof.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim();
                                }
                            }
                            //commented by ajay yadav start 21-10-2022 start
                            //if (dsResult.Tables[0].Rows[0]["ProfQual"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProfQual"]).Trim() != "")
                            //    {

                            //        ddlProfQual.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProfQual"]).Trim();
                            //        //Response.Write(ddleducationproof.SelectedValue.ToString().Trim());
                            //        //Response.End();
                            //    }
                            //}
                            //if (dsResult.Tables[0].Rows[0]["InsQual"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["InsQual"]).Trim() != "")
                            //    {

                            //        DdlInsQual.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["InsQual"]).Trim();
                            //        //Response.Write(ddleducationproof.SelectedValue.ToString().Trim());
                            //        //Response.End();
                            //    }
                            //}
                            //commented by ajay yadav start 21-10-2022 end
                            //endded by meena 4_4_18



                            if (dsResult.Tables[0].Rows[0]["HasPhoto"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasPhoto"]).Trim() != "")
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasPhoto"]).Trim() == "Y")
                                        cbphoto.Checked = true;
                                    else
                                        cbphoto.Checked = false;
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["HasMarkSheet"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasMarkSheet"]).Trim() != "")
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasMarkSheet"]).Trim() == "Y")
                                        cbmarksheet.Checked = true;
                                    else
                                        cbmarksheet.Checked = false;
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["HasCertificate"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasCertificate"]).Trim() != "")
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasCertificate"]).Trim() == "Y")
                                        cbcertificate.Checked = true;
                                    else
                                        cbcertificate.Checked = false;
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["PanchayatFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["PanchayatFlag"]).Trim() != "")
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PanchayatFlag"]).Trim() == "Y")
                                    {
                                        trPanchayat.Visible = false;
                                        cbPanachayat.Checked = false;//Modify by Nikhil on 23.4.15
                                    }
                                    else
                                    {
                                        if (ddlBasicQual.SelectedValue == "SSC" && ddlcategory.SelectedValue == "P")
                                        {
                                            trPanchayat.Visible = false;
                                        }

                                        cbPanachayat.Checked = false;//Modify by Nikhil on 23.4.15
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["NocAckFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["NocAckFlag"]).Trim() != "")
                                {
                                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["NocAckFlag"]).Trim() == "Y")
                                    {
                                        trNOCAck.Visible = true;
                                        chkNOCAck.Checked = true;
                                    }
                                    else
                                    {
                                        if (cbTrfrFlag.Checked == true && RbtNoc.SelectedValue == "1")
                                        {
                                            trNOCAck.Visible = true;
                                        }
                                        chkNOCAck.Checked = false;
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["NOCFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["NOCFlag"]).Trim() != "")
                                {



                                    if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() == "1")
                                    {
                                        RbtNoc.SelectedIndex = 0;
                                        //RbAckRev.SelectedIndex = 1;
                                        RbAckRev.Visible = false;
                                        lblAckrcv.Visible = false;
                                        RbtNoc.Enabled = false;
                                        trNOCAck.Visible = false;
                                    }

                                    else
                                    {
                                        RbtNoc.SelectedIndex = 1;
                                        RbAckRev.Visible = true;
                                        //RbAckRev.SelectedIndex = 0;
                                        lblAckrcv.Visible = true;
                                        RbtNoc.Enabled = true;
                                        trNOCAck.Visible = true;
                                    }
                                    // 01...06/09/2012...Miti


                                }
                            }
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["RbAckFlag"]).Trim() != "")
                            {
                                if (dsResult.Tables[0].Rows[0]["RbAckFlag"].ToString() == "1")
                                {
                                    RbAckRev.SelectedIndex = 0;
                                    RbAckRev.Visible = true;
                                    lblAckrcv.Visible = true;
                                    trNOCAck.Visible = true;
                                }
                                else
                                {
                                    RbAckRev.SelectedIndex = 1;
                                    RbAckRev.Visible = true;
                                    lblAckrcv.Visible = true;
                                    trNOCAck.Visible = true;
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnsfrFlag"]).Trim() != "")
                                {
                                    if ((dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "1") || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True")
                                    {

                                        txtOldTccLcnNo.Enabled = false;
                                        lbloldLcnNo.Enabled = false;
                                        ddlTrnsfrInsurName.Enabled = true;
                                        lblPrevInsurerName.Enabled = true;
                                        lblNOCFlag.Enabled = true;
                                        RbtNoc.Enabled = true;
                                        lblOldLcnexpDate.Enabled = true;
                                        txtOldTccLcnNo.Focus();
                                        cbTrfrFlag.Checked = true;
                                        divTrnsferDetails.Visible = true;
                                        if (dsResult.Tables[0].Rows[0]["OldTccLcnno"] != null)
                                        {
                                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim() != "")
                                            {
                                                txtOldTccLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim();
                                            }
                                        }
                                        if (dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"] != null)
                                        {
                                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim() != "")
                                            {

                                                ddlTrnsfrInsurName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim(); //Added by pranjali on 13-03-2014
                                            }
                                        }
                                        if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"] != null)
                                        {
                                            if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"].ToString().Trim() != "")
                                            {
                                                //txtOldTccLcnExpDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                                txtDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                            }
                                        }
                                        if (dsResult.Tables[0].Rows[0]["LcnIssDate"] != null)
                                        {
                                            if (dsResult.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim() != "")
                                            {
                                                txtLicIssueDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
                                            }
                                        }
                                    }

                                    else
                                    {
                                        cbTrfrFlag.Checked = false;
                                        txtReferredBy.Focus();
                                        divTrnsferDetails.Visible = false;
                                    }
                                }
                            }

                            //For Composite Flag
                            if (dsResult.Tables[0].Rows[0]["TccCompLcn"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["TccCompLcn"]).Trim() != "")
                                {
                                    if ((dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString().Trim() == "True") || (dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString().Trim() == "1"))
                                    {
                                        cbTccCompLcn.Checked = true;
                                        divCompDtls.Visible = true;
                                        divCompositeDetails.Visible = true;
                                        txtCompLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicNo"]).Trim();
                                        //added by pranjali on 11-04-2014 start
                                        if (dsResult.Tables[0].Rows[0]["CompLicExpDt"] != null)
                                        {
                                            if (dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString().Trim() != "")
                                            {
                                                txtCompLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"])).ToString(CommonUtility.DATE_FORMAT);
                                            }
                                        }
                                        //added by pranjali on 11-04-2014 end
                                        ddlCompInsurerName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CompInsrName"]).Trim();

                                    }
                                    else
                                    {
                                        cbTccCompLcn.Checked = false;
                                        divCompDtls.Visible = false;
                                        divCompositeDetails.Visible = false;
                                    }
                                }
                            }
                            //changed by rachana on 11-06-2014 start
                            if (dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                            {

                            }
                            else
                            {
                                //chkCompAgnt.Checked = false;
                            }
                            txtUnitCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["LUnitCode"]).Trim();
                            hdnExmCentreCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["ECCode"]).Trim();
                            if (dsResult.Tables[0].Rows[0]["PhotoSignFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["PhotoSignFlag"]).Trim() == "Y")
                                {
                                    chkPhotoSign.Checked = true;
                                }
                                else
                                {
                                    chkPhotoSign.Checked = false;
                                }
                            }
                            ddlPrimProf.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryProf"]).Trim();//Added by kalyani on 20-12-2013 as textbox of primary profession is change to dropdown
                            if (dsResult.Tables[0].Rows[0]["CasteCat"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim() != "")
                                {
                                    if (ddlCasteCat.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"])) != null)
                                    {
                                        ddlCasteCat.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]);
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["ExmBody"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody1"]).Trim() != "")
                                {
                                    if (ddlExmBody.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody1"])) != null)
                                    {
                                        ddlExmBody.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody1"]);
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["TrnMode"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"]).Trim() != "")
                                {
                                    if (ddlTrnMode.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"])) != null)
                                    {
                                        ddlTrnMode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"]);
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["TrnLoc"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]).Trim() != "")
                                {
                                    if (ddlTrnLoc.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"])) != null)
                                    {
                                        ddlTrnLoc.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]);
                                    }
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["BasicQual"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim() != "")
                                {
                                    if (ddlBasicQual.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"])) != null)
                                    {
                                        ddlBasicQual.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]);
                                    }
                                }
                            }
                            txtBoardName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicBoardName"]).Trim();
                            txtBasicRNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicRollNo"]).Trim();
                            if (dsResult.Tables[0].Rows[0]["BasicYrPass"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["BasicYrPass"].ToString().Trim() != "")
                                {
                                    txtYrPass.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BasicYrPass"])).ToString(CommonUtility.DATE_FORMAT);
                                }
                            }
                            else
                            {
                                txtYrPass.Text = "";
                            }
                            if (dsResult.Tables[0].Rows[0]["DrMailID"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["DrMailID"]).Trim() != "")
                                {
                                    if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["DrMailID"]) == true)
                                        cbdirectmail.Checked = true;
                                    else
                                        cbdirectmail.Checked = false;
                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["ExmCentre"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim() != "")
                                {
                                    txtExmCentre.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString();
                                }
                            }
                            else
                            {
                                txtExmCentre.Text = "";
                            }
                            if (dsResult.Tables[0].Rows[0]["ExmMode"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim() != "")
                                {
                                    ddlExam.SelectedValue = dsResult.Tables[0].Rows[0]["ExmMode"].ToString();
                                }
                            }
                            else
                            {
                                ddlExam.SelectedValue = "0";
                            }
                            if (dsResult.Tables[0].Rows[0]["ExamLanguage"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim() != "")
                                {
                                    ddlpreeamlng.SelectedValue = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString();
                                }
                            }
                            else
                            {
                                ddlpreeamlng.SelectedValue = "0";
                            }
                            if (dsResult.Tables[0].Rows[0]["ExmBody"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim() != "")
                                {
                                    ddlExmBody.SelectedValue = dsResult.Tables[0].Rows[0]["ExmBody"].ToString();
                                }
                            }
                            else
                            {
                                ddlExmBody.SelectedValue = "0";
                            }
                            if (dsResult.Tables[0].Rows[0]["PreffExmDt1"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["PreffExmDt1"].ToString().Trim() != "")
                                {
                                    txtPreDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["PreffExmDt1"])).ToString(CommonUtility.DATE_FORMAT);
                                }
                            }
                            else
                            {
                                txtPreDate.Text = "";
                            }
                        }
                        txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]);
                    }
                }
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
        //txtcndid.Text = null;

    }

    #endregion

    # region Method "FillRequiredDataForCndQualification"
    protected void FillRequiredDataForCndQualification()
    {

        DataSet dsResult = new DataSet();


        Hashtable htParam = new Hashtable();

        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page start
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            htParam.Add("@CndNo", strProspectID);
            //htParam.Add("@CndNo", hdnCndNo.Value);//commented by ajay yadav 27.10.2022
        }
        else
        {
            htParam.Add("@CndNo", txtcndid.Text.Trim());
        }
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page end
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd2", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd2", htParam, "INSCRecruitConnectionString");

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]).Trim() != "")
                        {
                            string[] sLang = Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]).Trim().Split(new char[] { '-' });
                            FillLanguage(ddllanknow1, cbpread, cbpwrite, cbpspeak, sLang[1].ToString());
                            FillLanguage(ddllanknow2, cbpread2, cbpwrite2, cbpspeak2, sLang[2].ToString());
                            FillLanguage(ddllanknow3, cbpread3, cbpwrite3, cbpspeak3, sLang[3].ToString());
                            FillLanguage(ddllanknow4, cbpread4, cbpwrite4, cbpspeak4, sLang[4].ToString());

                        }

                    }

                    //...gaurav..15/10/2012

                    //if (Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]) != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]).Trim() != "")
                    //    {
                    //        cboQualCode.SelectedValue= Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]).Trim();
                    //    }

                    //}
                    //...gaurav..15/10/12
                    //Added by pranjali on 10-03-2014 for filling the highest qualification start
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim() != "")
                        {
                            cboQualCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim();
                            cboQualCode.Enabled = false;
                        }

                    }
                    //Added by pranjali on 10-03-2014 for filling the highest qualification end

                    txtinsurancequalification.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["InsQualDesc"]).Trim();
                    txtOccupationCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OccpnCode"]).Trim();
                    txtOccupationDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Occupdesc"]).Trim();
                    txtempaddress.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpAddress"]).Trim();
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]).Trim() == "Y")
                            {
                                cbCreCard.Checked = true;
                            }
                            else
                            {
                                cbCreCard.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]).Trim() == "Y")
                            {
                                cbGenIns.Checked = true;
                            }
                            else
                            {
                                cbGenIns.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]).Trim() == "Y")
                            {
                                cbMutFund.Checked = true;
                            }
                            else
                            {
                                cbMutFund.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]).Trim() == "Y")
                            {
                                cbLifeIns.Checked = true;
                            }
                            else
                            {
                                cbLifeIns.Checked = false;

                            }
                        }

                    }

                    txtOtherProduct.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["otherproducts"]).Trim();

                }
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

    # region METHOD "FillRequiredDataForCndEmpHistory"

    protected void FillRequiredDataForCndEmpHistory()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        //Added by swapnesh for inserting Emp history data on 20_5_2013 start

        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page start
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            htParam.Add("@CndNo", strProspectID);
        }
        else
        {
            htParam.Add("@CndNo", txtcndid.Text.Trim());
        }
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page end


        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnds03", htParam, "INSCRecruitConnectionString");
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString() == "Y")
                    {
                        rbinsagency.SelectedValue = "Y";
                        txtInsCompName.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["LcnNo"]);
                        txtInsAgencyCode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAgentCode"]);
                        txtTerminationReason.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        if (dsResult.Tables[0].Rows[i]["IsInsExp"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString().Trim() != "")
                            {
                                rbinsagency.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["IsInsExp"]);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["LcnIssDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["LcnIssDate"].ToString().Trim() != "")
                            {
                                txtdateofissue.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["LcnExpDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["LcnExpDate"].ToString().Trim() != "")
                            {
                                txtvaliddate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["CseDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["CseDate"].ToString().Trim() != "")
                            {
                                txtterminatedate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["CseDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        SetEnabledtrue();
                    }

                    else
                    {

                        SetEnabledfalse();
                    }
                }

            }
            else
            {
                rbinsagency.SelectedValue = "N";
                SetEnabledfalse();
            }


            dsResult.Dispose();
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("[prc_CndAdmin_getCnds3]", htParam, "INSCRecruitConnectionString");
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 1)
                    {
                        txtPrevEmpName1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome1.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 2)
                    {
                        txtPrevEmpName2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome2.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }


                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 3)
                    {
                        txtPrevEmpName3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome3.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["AnnIncome"]);
                        txtreasforleave3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 4)
                    {
                        txtPrevEmpName4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome4.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]); //Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }


                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 5)
                    {
                        txtPrevEmpName5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome5.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);// Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 6)
                    {
                        txtPrevEmpName6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome6.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);// Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                }

            }
            dsResult.Dispose();
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("[prc_CndAdmin_getCnd3]", htParam, "INSCRecruitConnectionString");
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                rbotherexp.SelectedValue = "Y";
                for (int j = 0; j < dsResult.Tables[0].Rows.Count; j++)
                {

                    txtemprecordname1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CompName"]);
                    txtemprecordjobnature1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTypeDesc"]);
                    txtemprecordfield1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkField"]);

                    if (dsResult.Tables[0].Rows[0]["StartDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["StartDate"].ToString().Trim() != "")
                        {
                            txtotherexpfrom1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["EndDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EndDate"].ToString().Trim() != "")
                        {
                            txtotherexpTo1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }

                    if (j == 1)
                    {
                        txtemprecordname2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["CompName"]);
                        txtemprecordjobnature2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["WorkTypeDesc"]);
                        txtemprecordfield2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["WorkField"]);

                        if (dsResult.Tables[0].Rows[1]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[1]["StartDate"].ToString().Trim() != "")
                            {
                                txtotherexpfrom2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[1]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[1]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[1]["EndDate"].ToString().Trim() != "")
                            {
                                txtotherexpTo2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[1]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                    }

                    if (j == 2)
                    {
                        txtemprecordname3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["CompName"]);
                        txtemprecordjobnature3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["WorkTypeDesc"]);
                        txtemprecordfield3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["WorkField"]);

                        if (dsResult.Tables[0].Rows[2]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[2]["StartDate"].ToString().Trim() != "")
                            {
                                txtotherexpfrom3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[2]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[2]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[2]["EndDate"].ToString().Trim() != "")
                            {
                                txtotherexpTo3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[2]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                    }
                }
            }
            else
            {
                rbotherexp.SelectedValue = "N";
                SetEnabledfalseOtherexp();
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

    # region METHOD "FillRequiredDataForCndPsnlhistory"
    protected void FillRequiredDataForCndPsnlhistory()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            //Added by swapnesh for inserting Disciplinary info data on 20_5_2013 start

            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                htParam.Add("@CndNo", strProspectID);
            }
            else
            {
                htParam.Add("@CndNo", txtcndid.Text.Trim());
            }

            //Added by swapnesh for inserting Disciplinary info data on 20_5_2013 end
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd4", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd4", htParam, "INSCRecruitConnectionString");
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]).Trim() != "")
                        {
                            rbQstn01.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn01"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]).Trim() != "")
                        {
                            rbQstn02.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn02"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]).Trim() != "")
                        {
                            rbQstn03.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn03"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]).Trim() != "")
                        {
                            rbQstn04.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn04"].ToString();
                        }

                    }
                    txtRef1Name.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName01"]).Trim();
                    txtRef2Name.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName02"]).Trim();

                    for (int a = 0; a < dsResult.Tables[0].Rows.Count; a++)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C1")
                        {
                            txtRef1Add1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
                            txtRef1Add2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
                            txtRef1Add3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
                            txtRef1Pin.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
                            txtStateCodeR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateCode"]).Trim();
                            txtCountryCodeR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CntryCode"]).Trim();
                            txtStateDescR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc"]).Trim();
                            txtCountryDescR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc"]).Trim();

                        }

                        if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C2")
                        {
                            txtRef2Add1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
                            txtRef2Add2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
                            txtRef2Add3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
                            txtRef2Pin.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
                            txtStateCodeR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateCode"]).Trim();
                            txtCountryCodeR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CntryCode"]).Trim();
                            txtStateDescR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc2"]).Trim();
                            txtCountryDescR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc2"]).Trim();
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

        }
    }
    #endregion

    # region METHOD "FillRequiredDataForCndBizPlan"

    protected void FillRequiredDataForCndBizPlan()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();

        htParam.Add("@CndNo", txtcndid.Text.Trim());
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            //Added by Rachana for interview page 22/05/2013 start
            //Commented by rachana as interview module not required start
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd_interview5", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd_interview5", htParam, "INSCRecruitConnectionString");
            //if (dsResult.Tables[0].Rows.Count > 0)
            //{
            //    txtInterviewerName.Text = dsResult.Tables[0].Rows[0]["InterviewerName"].ToString();
            //    txtInterviewerComment.Text = dsResult.Tables[0].Rows[0]["InterviewerComment"].ToString();
            //    txtDTRegFrom.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["DateofInt"])).ToString(CommonUtility.DATE_FORMAT);
            //}
            //Commented by rachana as interview module not required end
            //Added by Rachana for interview page 22/05/2013 end
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "1")
                    {
                        txtbusinessplannooflives11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]);// Convert.ToString(dsResult.Tables[0].Rows[0]["NoofLives"]).Trim();
                        txtbusinessplansumassured11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]); //Convert.ToString(dsResult.Tables[0].Rows[0]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[0]["FYP"]).Trim();
                    }

                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "2")
                    {
                        txtbusinessplannooflives21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["NoofLives"]).Trim();
                        txtbusinessplannsumassured21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["FYP"]).Trim();
                    }

                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "3")
                    {
                        txtbusinessplannooflives31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["NoofLives"]).Trim();
                        txtbusinessplannsumassured31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]);// Convert.ToString(dsResult.Tables[0].Rows[2]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["FYP"]).Trim();
                    }
                }
                txtrelativeworkdesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWorkDesc"]).Trim();
                txtpastachievement.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PastAchievement"]).Trim();

                if (Convert.ToString(dsResult.Tables[0].Rows[0]["IsFullTime"]) != null)
                {
                    if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["IsFullTime"]) == false)
                    {
                        rbtimework.SelectedValue = "0";
                    }
                    else
                        rbtimework.SelectedValue = "1";
                }


                if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]) != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]).Trim() != "")
                    {
                        rbrelatedemp.SelectedValue = dsResult.Tables[0].Rows[0]["RelativeAtWork"].ToString();
                    }

                }
                //Added by Rachana on 21/05/2013 for interview page start
                //Commented by rachana as interview module not required start
                //if (Request.QueryString["Type"] != null)
                //{
                //    if (Request.QueryString["Type"].ToString().Trim() == "IV")
                //    {

                //        txtInterviewerName.Text = dsResult.Tables[0].Rows[0]["InterviewerName"].ToString();
                //        txtInterviewerComment.Text = dsResult.Tables[0].Rows[0]["InterviewerComment"].ToString();
                //        //Added By Ibrahim Start , to substring time from date time on May 24, 2013 Start
                //        txtDTRegFrom.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["DateofInt"])).ToString(CommonUtility.DATE_FORMAT).Substring(0, 10);
                //        //txtDTRegFrom.Text = dsResult.Tables[0].Rows[0]["DateofInt"].ToString();
                //        //Added By Ibrahim Start , to substring time from date time on May 24, 2013 End
                //    }
                //}
                //Commented by rachana as interview module not required start
                //Added by Rachana on 21/05/2013 for interview page end
            }
        }

        catch (Exception ex)
        {
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

    # region METHOD "FillLanguage Checking"
    public void FillLanguage(DropDownList ddl, CheckBox cb1, CheckBox cb2, CheckBox cb3, string slanguage)
    {
        string[] sSplit = slanguage.Split(new char[] { '|' });
        ddl.SelectedValue = sSplit[1].ToString();
        if (sSplit[2].ToString() == "Y")
        {
            cb1.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb1.Visible = true;
            lblqfread1.Visible = true;
            lblqfread2.Visible = true;
        }
        else
        {
            cb1.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb1.Visible = true;
            lblqfread1.Visible = true;
            lblqfread2.Visible = true;
        }
        if (sSplit[3].ToString() == "Y")
        {
            cb2.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb2.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfwrite2.Visible = true;
        }
        else
        {
            cb2.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb2.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfwrite2.Visible = true;
        }
        if (sSplit[4].ToString() == "Y")
        {
            cb3.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb3.Visible = true;
            lblqfspeak1.Visible = true;
            lblqfspeak2.Visible = true;
        }
        else
        {
            cb3.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb3.Visible = true;
            lblqfspeak1.Visible = true;
            lblqfspeak2.Visible = true;
        }

    }
    #endregion

    # region METHOD 'POPULATE DROPDOWNLIST'

    private void subPopulateTitle()
    {
        try
        {
            //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language start			

            cboTitle.Items.Clear();
            dscbotitle.SelectCommand = "Prc_GetCndTitle";
            // cboTitle.DataSource = dscbotitle;

            //Added By Prathamesh 22-6-15
            cboTitle.DataTextField = "ParamDesc";
            cboTitle.DataValueField = "ParamValue";
            cboTitle.DataBind();
            //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language End		

            cboTitle.Items.Insert(0, new ListItem("Select", ""));
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

    //Added by rachana on 20-04-2015 to save relation with entry in Father name textbox start
    private void subRelation()
    {
        try
        {
            ddlRelwithFather.Items.Clear();
            DsRelation.SelectCommand = "Prc_GetRelation";
            ddlRelwithFather.DataBind();
            ddlRelwithFather.Items.Insert(0, new ListItem("Select", ""));
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

    //Added by rachana on 20-04-2015 to save relation with entry in Father name textbox end

    private void subPopulateGender()
    {
        try
        {
            oCommon.getDropDown(cboGender, "NBGender", 1, "", 1, c_strBlank);
            cboGender.Items.Remove(cboGender.Items.FindByValue("C"));
            cboGender.Items.Remove(cboGender.Items.FindByValue("U"));
            subGenerateGenderValidation();
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
    private void PopulatePrimProof()
    {
        try
        {
            oCommon.getDropDown(ddlPrimProf, "PrimProof", 1, "", 1);
            ddlPrimProf.Items.Insert(0, "Select");
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
    private void PopulateContactPreferred()
    {
        try
        {
            oCommon.getDropDown(ddlDstbnMethod, "DstbnMtd", 1, "", 1);
            ddlDstbnMethod.Items.Insert(0, "Select");
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

    protected void PopulateCandidateType()
    {
        try
        {
            oCommon.getDropDown(ddlCandidatetype, "CandidateType", 1, "", 1, c_strBlank);
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

    #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT


    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string bizsrc = ddlSlsChannel.SelectedValue.ToString().Trim();

        try
        {
            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@BizSrc", bizsrc);
            htParam.Add("@carrierCode", "2");
            htParam.Add("@flag", "3");
            //added by  usa 
            if (bizsrc != "XX")
            {

                dsresult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString");
                if (dsresult.Tables[0].Rows.Count > 0)
                {

                    // ddlChnCls.SelectedItem.Text = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnlDesc"]).Trim();

                    ViewState["cndChnCls"] = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim();

                    FillddlSlsChannel(bizsrc);
                    ddlChnCls.SelectedValue = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim();
                }
                FillCndAgntType(bizsrc, Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim());
            }
            else
            {
                ddlChnCls.SelectedItem.Text = "Select";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter candiadte channel in Hierarchy Name')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlSlsChannel.Focus();
                return;
            }

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




    #endregion

    #region METHOD 'FillddlSlsChannel' DEFINITION
    private void FillddlSlsChannel(string sddlSlsChannel)
    {
        try
        {
            // ddlAgntType.Items.Clear();
            ddlChnCls.Items.Clear();
            SqlDataReader dtRead;

            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel with Carrier code and BizSrc start
            httable.Clear();
            int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
            httable.Add("@CarrierCode", CarrierCode);
            httable.Add("@BizSrc", sddlSlsChannel);
            dtRead = dataAccessclass.exec_reader_prc_conn("Prc_Getddlslschannel", httable, CONN_Recruit);
            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel with Carrier code and BizSrc End

            if (dtRead.HasRows)
            {
                ddlChnCls.DataSource = dtRead;
                ddlChnCls.DataTextField = "ChnlDesc";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            dtRead = null;
            ddlChnCls.Items.Insert(0, new ListItem("Select", ""));


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

    #region METHOD 'GetSalesChannel' DEFINITION
    private void GetRecruitSalesChannel(DropDownList ddl, string strBizSrc, int strIncMasterCmp, string Chncls)
    {

        ddlChnCls.Items.Clear();
        ddlAgntType.Items.Clear();

        string strSql = string.Empty;
        DataSet dsResult = new DataSet();


        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start
        int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
        httable.Clear();
        httable.Add("@CarrierCode", CarrierCode);
        //added by usha for channel

        httable.Add("@MemType", MemberType);
        httable.Add("@Chncls", Chncls);
        httable.Add("@Bizsrc", strBizSrc);
        dsResult = dataAccessclass.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", httable, CONN_Recruit);
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure  Get Sales Channel End

        if (dsResult.Tables.Count > 0)
        {
            oCommonUtility.FillDropDown(ddl, dsResult.Tables[0], "BizSrc", "ChannelDesc01");
            if (strBizSrc.Trim() != "")
            {
                ddl.SelectedValue = strBizSrc.Trim();
            }
        }
        dsResult = null;
        strSql = null;


    }
    #endregion

    #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlChnCls(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue);
    }

    private void FillddlChnCls(string sddlSlsChannel, string sddlChnCls)
    {
        ddlAgntType.Items.Clear();
        SqlDataReader dtRead;
        httable.Clear();
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start
        int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
        httable.Add("@CarrierCode", CarrierCode);
        httable.Add("@BizSrc", sddlSlsChannel);
        httable.Add("@ChnCls", sddlChnCls);

        dtRead = dataAccessclass.exec_reader_prc_conn("Prc_getchannelcls", httable, CONN_Recruit);
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start

        if (dtRead.HasRows)
        {
            ddlAgntType.DataSource = dtRead;
            ddlAgntType.DataTextField = "AgentTypeDesc";
            ddlAgntType.DataValueField = "MemType";
            ddlAgntType.DataBind();
        }
        dtRead = null;
        ddlAgntType.Items.Insert(0, new ListItem("Select", ""));


    }
    private void DisActImmLeaSelection()
    {
        txtDirectAgtName.Text = "";
        //txtImmLeader.Text = "";
        //txtSmCode.Text = "";//Commented by rachana on 22-08-2014

        if (ddlSlsChannel.SelectedValue.ToString().Trim() == "" || ddlChnCls.SelectedValue.ToString().Trim() == "" || ddlAgntType.SelectedValue.ToString().Trim() == "")
        {
            //kk
            //btnImmLeaderCode.Enabled = false;
            btnagent.Enabled = false;
        }
        else
        {
            btnImmLeaderCode.Enabled = true;
            btnagent.Enabled = true;
        }
    }

    # endregion

    #region DROPDOWN 'ddlAgntType' SELECTEDINDEXCHANGED EVENT
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisActImmLeaSelection();
    }
    # endregion

    #region DROPDOWN 'ddlcategory' SELECTEDINDEXCHANGED EVENT
    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateProofIDDoc();
        if (ddlcategory.SelectedValue == "U")
        {
            txtVillage.Text = string.Empty;
            txtVillage.Enabled = false;
            txtpermvillage.Enabled = false;

            txtVillage.BackColor = Color.White;
            txtpermvillage.BackColor = Color.White;

        }
        else
        {
            txtVillage.Enabled = true;
            txtpermvillage.Enabled = true;

            txtVillage.BackColor = ColorTranslator.FromHtml("#ffffb2");
            txtpermvillage.BackColor = ColorTranslator.FromHtml("#ffffb2");

        }

        if (ddlcategory.SelectedValue == "U")
        {
            ///Commented by rachana to enable basic Qual upto QC stge
            //ddlBasicQual.SelectedValue = "Select";
            ddlBasicQual.Enabled = true;//Chnage the value by Nikhil on 23.4.15
            //btnVerifyCSC_Click(this, EventArgs.Empty);
            ddlBasicQual_SelectedIndexChanged(this, EventArgs.Empty);
        }
        else
        {
            PopulateBasicQual();
            ddlBasicQual.Enabled = true;
        }
        ddlcategory.Focus();
    }
    # endregion

    #region METHOD 'FillRequiredDataForPage3()' DEFINITION
    protected void FillRequiredDataForPage3()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();

            //oCommon.getDropDown(ddlPaymentMode, "PymtMode", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);//Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field
            //ddlPaymentMode.Items.Insert(0, new ListItem("Select", ""));//Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field

            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AgentCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());

            dsResult.Clear();
            dsResult = null;
            htParam.Clear();
            htParam = null;
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



    #region DROPDOWNLIST 'ddlBankCode' SELECTEDINDEXCHANGED EVENT
    protected void ddlBankCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlDataReader dr;
        //if (ddlBankCode.SelectedValue.Trim() != "")
        //{
        //    //Added By Asrar on 28-06-2013 for converting Inline query into procedure to Get Bank Branch start
        //    //dr = dataAccess.exec_reader("SELECT BnkBrnCode, BnkBrnCode + ' - ' + BnkBrnDsc AS BnkBrnDsc FROM AgnBnkBrn WHERE BankCode = " + ddlBankCode.SelectedValue.Trim() + " ORDER BY BnkBrnCode", CommonUtility.CONN_LIFE_DATA);
        //    httable.Clear();
        //    httable.Add("@flag", "");
        //    httable.Add("@ddlvalue", ddlBankCode.SelectedValue.Trim());
        //    dr = dataAccessclass.exec_reader_prc_conn("Prc_GetBankBranch", httable, "INSCCommonConnectionString");
        //    //Added By Asrar on 28-06-2013 for converting Inline query into procedure to Get Bank Branch End
        //}
        //else
        //{
        //    //Added By Asrar on 28-06-2013 for converting Inline query into procedure to Get Bank Branch start
        //    //dr = dataAccess.exec_reader("SELECT BnkBrnCode, BnkBrnCode + ' - ' + BnkBrnDsc AS BnkBrnDsc FROM AgnBnkBrn" + " ORDER BY BnkBrnCode", CommonUtility.CONN_LIFE_DATA);
        //    httable.Clear();
        //    httable.Add("@flag", "");
        //    httable.Add("@ddlvalue", "");
        //    dr = dataAccessclass.exec_reader_prc_conn("Prc_GetBankBranch", httable, "INSCCommonConnectionString");
        //    //Added By Asrar on 28-06-2013 for converting Inline query into procedure to Get Bank Branch end
        //}
        //ddlBankBranch.DataTextField = "BnkBrnDsc";
        //ddlBankBranch.DataValueField = "BnkBrnCode";
        //ddlBankBranch.DataSource = dr;
        //ddlBankBranch.DataBind();
        //ddlBankBranch.Items.Insert(0, new ListItem("Select", ""));
    }
    #endregion

    #region METHOD 'FillHiddenValues()' DEFINITION
    protected void FillHiddenValues()
    {
        olng = new multilingualManager("DefaultConn", "CndReg.aspx", Session["UserLangNum"].ToString());
        if (MultiView1.ActiveViewIndex == 0)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2601");
            hdnID270.Value = olng.GetItemDesc("hdnID2701");
            hdnID280.Value = olng.GetItemDesc("hdnID2801");
            hdnID290.Value = olng.GetItemDesc("hdnID2901");
            hdnID300.Value = olng.GetItemDesc("hdnID3001");
            hdnID310.Value = olng.GetItemDesc("hdnID3101");
            hdnID320.Value = olng.GetItemDesc("hdnID3201");
            hdnID330.Value = olng.GetItemDesc("hdnID3301");
            hdnID340.Value = olng.GetItemDesc("hdnID3401");
            hdnID350.Value = olng.GetItemDesc("hdnID3501");
            hdnID360.Value = olng.GetItemDesc("hdnID3601");
            hdnID370.Value = olng.GetItemDesc("hdnID3701");
            hdnID380.Value = olng.GetItemDesc("hdnID3801");
            hdnID390.Value = olng.GetItemDesc("hdnID3901");
            hdnID400.Value = olng.GetItemDesc("hdnID4001");
            hdnID410.Value = olng.GetItemDesc("hdnID4101");
            hdnID420.Value = olng.GetItemDesc("hdnID4201");
            hdnID430.Value = olng.GetItemDesc("hdnID4301");
            hdnID440.Value = olng.GetItemDesc("hdnID4401");
            hdnID450.Value = olng.GetItemDesc("hdnID4501");
            hdnID460.Value = olng.GetItemDesc("hdnID4601");
            hdnID470.Value = olng.GetItemDesc("hdnID4701");
            hdnID480.Value = olng.GetItemDesc("hdnID4801");
            hdnID490.Value = olng.GetItemDesc("hdnID4901");
            hdnID500.Value = olng.GetItemDesc("hdnID5001");
            hdnID510.Value = olng.GetItemDesc("hdnID5101");
            hdnID520.Value = olng.GetItemDesc("hdnID5201");
            hdnID530.Value = olng.GetItemDesc("hdnID5301");
            hdnID540.Value = olng.GetItemDesc("hdnID5401");
            hdnID550.Value = olng.GetItemDesc("hdnID5501");
            hdnID560.Value = olng.GetItemDesc("hdnID5601");
            hdnID570.Value = olng.GetItemDesc("hdnID5701");
            hdnID580.Value = olng.GetItemDesc("hdnID5801");
            hdnID590.Value = olng.GetItemDesc("hdnID5901");
            hdnID600.Value = olng.GetItemDesc("hdnID6001");
            hdnID610.Value = olng.GetItemDesc("hdnID6101");
            hdnID620.Value = olng.GetItemDesc("hdnID6201");
            hdnID630.Value = olng.GetItemDesc("hdnID6301");
            hdnID640.Value = olng.GetItemDesc("hdnID6401");
            hdnID650.Value = olng.GetItemDesc("hdnID6501");
            hdnID660.Value = olng.GetItemDesc("hdnID6601");
            hdnID670.Value = olng.GetItemDesc("hdnID6701");

        }
        else if (MultiView1.ActiveViewIndex == 1)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2602");
            hdnID270.Value = olng.GetItemDesc("hdnID2702");
            hdnID280.Value = olng.GetItemDesc("hdnID2802");
            hdnID290.Value = olng.GetItemDesc("hdnID2902");

            //Open Newly added on 21-01-08
            hdnID300.Value = olng.GetItemDesc("hdnID3002");
            //End Newly added on 21-01-08

        }
        else if (MultiView1.ActiveViewIndex == 2)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2603");
            hdnID270.Value = olng.GetItemDesc("hdnID2703");
            hdnID280.Value = olng.GetItemDesc("hdnID2803");
            hdnID290.Value = olng.GetItemDesc("hdnID2903");
            hdnID300.Value = olng.GetItemDesc("hdnID3003");
            hdnID310.Value = olng.GetItemDesc("hdnID3103");
            hdnID320.Value = olng.GetItemDesc("hdnID3203");
            hdnID330.Value = olng.GetItemDesc("hdnID3303");
            hdnID340.Value = olng.GetItemDesc("hdnID3403");
            hdnID350.Value = olng.GetItemDesc("hdnID3503");
            hdnID360.Value = olng.GetItemDesc("hdnID3603");
            hdnID370.Value = olng.GetItemDesc("hdnID3703");
            hdnID380.Value = olng.GetItemDesc("hdnID5103");
            hdnID390.Value = olng.GetItemDesc("hdnID3903");
            hdnID400.Value = olng.GetItemDesc("hdnID4003");
            hdnID410.Value = olng.GetItemDesc("hdnID4103");
            hdnID420.Value = olng.GetItemDesc("hdnID4203");
            hdnID430.Value = olng.GetItemDesc("hdnID4303");
            hdnID440.Value = olng.GetItemDesc("hdnID4403");
            hdnID450.Value = olng.GetItemDesc("hdnID4503");
            hdnID460.Value = olng.GetItemDesc("hdnID4603");
            hdnID470.Value = olng.GetItemDesc("hdnID4703");
            hdnID480.Value = olng.GetItemDesc("hdnID4803");

        }
        else if (MultiView1.ActiveViewIndex == 3)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2604");
            hdnID270.Value = olng.GetItemDesc("hdnID2704");
            hdnID280.Value = olng.GetItemDesc("hdnID2804");
            hdnID290.Value = olng.GetItemDesc("hdnID2904");
            hdnID300.Value = olng.GetItemDesc("hdnID3004");
            hdnID310.Value = olng.GetItemDesc("hdnID3104");
            hdnID320.Value = olng.GetItemDesc("hdnID3204");
            hdnID330.Value = olng.GetItemDesc("hdnID3304");


        }
        else if (MultiView1.ActiveViewIndex == 4)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2605");
            hdnID270.Value = olng.GetItemDesc("hdnID2705");
            hdnID280.Value = olng.GetItemDesc("hdnID2805");
            hdnID290.Value = olng.GetItemDesc("hdnID2905");
            hdnID300.Value = olng.GetItemDesc("hdnID3005");
            hdnID310.Value = olng.GetItemDesc("hdnID3105");

        }
    }
    #endregion

    #region METHOD 'GetPersonalInformation()' DEFINITION
    protected void GetPersonalInformation()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();

        htParam.Add("@CndNo", txtcndid.Text.Trim());
        //}
        //Added by swapnesh for getting record acording to prospect id on 20_5_2013 end

        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));

        try
        {
            //Changed by rachana on 25-11-2013 for candidate details at the time of candidate enquiry and approval cndno link start
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnddetails", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnddetails", htParam, "INSCRecruitConnectionString");
            //Changed by rachana on 25-11-2013 for candidate details at the time of candidate enquiry and approval cndno link end

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                txtregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblqcndno.Text = txtcndid.Text.Trim();
                lblqregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblqgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblqsurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblqappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblecndno.Text = txtcndid.Text.Trim();
                lbleregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblegivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblesurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lbleappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblpcndno.Text = txtcndid.Text.Trim();
                lblpregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblpgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblpSurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblpappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblbcndno.Text = txtcndid.Text.Trim();
                lblbregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblbgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblbSurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblbappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();
                hdnCndNo.Value = txtcndid.Text;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;

        }

    }
    #endregion

    #region METHOD 'rdagnexp_SelectedIndexChanged' DEFINITION
    protected void rdagnexp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbinsagency.SelectedValue == "N")
        {
            SetEnabledfalse();
        }
        else
        {
            SetEnabledtrue();
        }
    }

    #endregion

    protected void rbotherexp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbotherexp.SelectedValue == "N")
        {
            SetEnabledfalseOtherexp();
        }
        else
        {
            SetEnabledOtherexp();
        }
    }

    protected void SetEnabledfalseOtherexp()
    {
        txtemprecordname1.Enabled = false;
        txtemprecordname1.Text = "";
        txtotherexpfrom1.Text = "";
        txtotherexpTo1.Text = "";
        txtotherexpfrom1.Enabled = false;
        txtotherexpTo1.Enabled = false;
        txtemprecordjobnature1.Text = "";
        txtemprecordfield1.Text = "";
        txtemprecordjobnature1.Enabled = false;
        txtemprecordfield1.Enabled = false;

        txtemprecordname2.Enabled = false;
        txtemprecordname2.Text = "";
        txtotherexpfrom2.Text = "";
        txtotherexpTo2.Text = "";
        txtotherexpfrom2.Enabled = false;
        txtotherexpTo2.Enabled = false;
        txtemprecordjobnature2.Text = "";
        txtemprecordfield2.Text = "";
        txtemprecordjobnature2.Enabled = false;
        txtemprecordfield2.Enabled = false;

        txtemprecordname3.Enabled = false;
        txtemprecordname3.Text = "";
        txtotherexpfrom3.Text = "";
        txtotherexpTo3.Text = "";
        txtotherexpfrom3.Enabled = false;
        txtotherexpTo3.Enabled = false;
        txtemprecordjobnature3.Text = "";
        txtemprecordfield3.Text = "";
        txtemprecordjobnature3.Enabled = false;
        txtemprecordfield3.Enabled = false;

    }
    protected void SetEnabledOtherexp()
    {
        txtemprecordname1.Enabled = true;

        txtotherexpfrom1.Enabled = true;
        txtotherexpTo1.Enabled = true;

        txtemprecordjobnature1.Enabled = true;
        txtemprecordfield1.Enabled = true;

        txtemprecordname2.Enabled = true;

        txtotherexpfrom2.Enabled = true;
        txtotherexpTo2.Enabled = true;

        txtemprecordjobnature2.Enabled = true;
        txtemprecordfield2.Enabled = true;

        txtemprecordname3.Enabled = true;

        txtotherexpfrom3.Enabled = true;
        txtotherexpTo3.Enabled = true;

        txtemprecordjobnature3.Enabled = true;
        txtemprecordfield3.Enabled = true;

    }

    #region ddlExam SelectedIndexChanged
    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnExmCentreCode.Value = "";
            txtExmCentre.Text = string.Empty;

            ddlpreeamlng.Items.Clear();
            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Exam Language start
            //DSddlpreeamlng.SelectCommand = "Select ParamValue,ParamDesc1 from InscDirect..ISysLookupParam where LookupCode = 'KnownLng' and ParamUsage = 1 and ParamValue in ('ENG','GUJ','HIN','MRA','TAM','TEL','MLM','BNG','KDA')";
            DSddlpreeamlng.SelectCommand = "Prc_GetExamLanguage '" + ddlExam.SelectedValue.ToString().Trim() + "'";
            //Added By Asrar on 27-06-2013 for converting Inline query into procedure Exam Language end
            ddlpreeamlng.DataBind();
            ddlpreeamlng.Items.Insert(0, "Select");
                if (ddlExam.SelectedValue.ToString().Trim() == "1")
            {


                ddlExmBody.SelectedValue = "Select";
                ddlExmBody.AppendDataBoundItems = false;
                ddlExmBody.Enabled = true;
            }
            else
            {

                ddlExmBody.SelectedValue = "Select";
                //ddlExmBody.Enabled = false;
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


    #region METHOD 'SetEnabledtruefalse()' DEFINITION
    protected void SetEnabledfalse()
    {
        txtInsCompName.Enabled = false;
        txtTerminationReason.Enabled = false;
        txtInsAgencyCode.Enabled = false;
        txtLcnNo.Enabled = false;
        txtdateofissue.Enabled = false;
        txtvaliddate.Enabled = false;
        txtterminatedate.Enabled = false;

        txtdateofissue.Text = "";
        txtvaliddate.Text = "";
        txtterminatedate.Text = "";
        txtInsCompName.Text = "";
        txtTerminationReason.Text = "";
        txtInsAgencyCode.Text = "";
        txtLcnNo.Text = "";
    }
    protected void SetEnabledtrue()
    {
        txtInsCompName.Enabled = true;
        txtTerminationReason.Enabled = true;
        txtInsAgencyCode.Enabled = true;
        txtLcnNo.Enabled = true;

        txtdateofissue.Enabled = true;
        txtvaliddate.Enabled = true;
        txtterminatedate.Enabled = true;

    }

    #endregion

    #region METHOD 'ModeEdit()' DEFINITION
    protected void ModeEdit()
    {
        try
        {
            olng = new multilingualManager("DefaultConn", "CndReg.aspx", Session["UserLangNum"].ToString());
            FillProspectInfo();
            FillRequiredDataForCndPersonal();
            FillRequiredDataForCndQualification();

            FillRequiredDataForCndEmpHistory();
            FillRequiredDataForCndPsnlhistory();
            FillRequiredDataForCndBizPlan();
            btnImmLeaderCode.Enabled = true;
            btnagent.Enabled = true;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 1.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";

            GetPersonalInformation();

            //Added by Prathamesh make all ImageButton true start
            lnkPage2.Enabled = true;


            btnUpdate.Text = olng.GetItemDesc("btnUpdate");

            //Added by Vadivel on Feb 14, 2008
            txtapplicationno.Enabled = false;

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

    #region METHOD 'DateChecking()' DEFINITION
    protected int DateChecking()
    {
        bool bIsValidDate = true;

        if (txtfrom1.Text.Trim() != null && txtto1.Text.Trim() != null)
        {
            if (txtfrom1.Text.Trim() != "" && txtto1.Text.Trim() != "")
            {

                if (ValidateDate(txtfrom1.Text.Trim(), txtto1.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto1.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom1.Text.Trim(), txtto1.Text.Trim(), 1) == 0)
                    return 0;

            }
        }

        if (txtfrom2.Text.Trim() != null && txtto2.Text.Trim() != null)
        {
            if (txtfrom2.Text.Trim() != "" && txtto2.Text.Trim() != "")
            {
                if (ValidateDate(txtfrom2.Text.Trim(), txtto2.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto2.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom2.Text.Trim(), txtto2.Text.Trim(), 2) == 0)
                    return 0;
            }
        }

        if (txtfrom3.Text.Trim() != null && txtto3.Text.Trim() != null)
        {
            if (txtfrom3.Text.Trim() != "" && txtto3.Text.Trim() != "")
            {
                if (ValidateDate(txtfrom3.Text.Trim(), txtto3.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto3.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom3.Text.Trim(), txtto3.Text.Trim(), 3) == 0)
                    return 0;
            }
        }

        if (txtfrom4.Text.Trim() != null && txtto4.Text.Trim() != null)
        {
            if (txtfrom4.Text.Trim() != "" && txtto4.Text.Trim() != "")
            {
                if (ValidateDate(txtfrom4.Text.Trim(), txtto4.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto4.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom4.Text.Trim(), txtto4.Text.Trim(), 4) == 0)
                    return 0;
            }
        }

        if (txtfrom5.Text.Trim() != null && txtto5.Text.Trim() != null)
        {
            if (txtfrom5.Text.Trim() != "" && txtto5.Text.Trim() != "")
            {
                if (ValidateDate(txtfrom5.Text.Trim(), txtto5.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto5.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom5.Text.Trim(), txtto5.Text.Trim(), 5) == 0)
                    return 0;
            }
        }

        if (txtfrom6.Text.Trim() != null && txtto6.Text.Trim() != null)
        {
            if (txtfrom6.Text.Trim() != "" && txtto6.Text.Trim() != "")
            {
                if (ValidateDate(txtfrom6.Text.Trim(), txtto6.Text.Trim(), 1) == 0)
                {
                    divEmploymentHist.Attributes.Add("Style", "display:block");
                    txtto6.Focus();
                    return 0;
                }

                if (CheckUniqDate(txtfrom6.Text.Trim(), txtto6.Text.Trim(), 6) == 0)
                    return 0;
            }
        }

        if (txtotherexpfrom1.Text.Trim() != null && txtotherexpTo1.Text.Trim() != null)
        {
            if (txtotherexpfrom1.Text.Trim() != "" && txtotherexpTo1.Text.Trim() != "")
            {
                if (ValidateDate(txtotherexpfrom1.Text.Trim(), txtotherexpTo1.Text.Trim(), 2) == 0)
                {

                    txtotherexpTo1.Focus();
                    return 0;
                }

                if (CheckUniqDateForExperience(txtotherexpfrom1.Text.Trim(), txtotherexpTo1.Text.Trim(), 1) == 0)
                    return 0;
            }
        }

        if (txtotherexpfrom2.Text.Trim() != null && txtotherexpTo2.Text.Trim() != null)
        {
            if (txtotherexpfrom2.Text.Trim() != "" && txtotherexpTo2.Text.Trim() != "")
            {
                if (ValidateDate(txtotherexpfrom2.Text.Trim(), txtotherexpTo2.Text.Trim(), 2) == 0)
                {

                    txtotherexpTo2.Focus();
                    return 0;
                }

                if (CheckUniqDateForExperience(txtotherexpfrom2.Text.Trim(), txtotherexpTo2.Text.Trim(), 2) == 0)
                    return 0;
            }
        }

        if (txtotherexpfrom3.Text.Trim() != null && txtotherexpTo3.Text.Trim() != null)
        {
            if (txtotherexpfrom3.Text.Trim() != "" && txtotherexpTo3.Text.Trim() != "")
            {
                if (ValidateDate(txtotherexpfrom3.Text.Trim(), txtotherexpTo3.Text.Trim(), 2) == 0)
                {

                    txtotherexpTo3.Focus();
                    return 0;
                }

                if (CheckUniqDateForExperience(txtotherexpfrom3.Text.Trim(), txtotherexpTo3.Text.Trim(), 3) == 0)
                    return 0;
            }
        }


        if (txtdateofissue.Text.Trim() != null && txtvaliddate.Text.Trim() != null)
        {
            if (txtdateofissue.Text.Trim() != "" && txtvaliddate.Text.Trim() != "")
            {
                if (!(bIsValidDate = IsValidDate(txtdateofissue.Text.Trim(), txtvaliddate.Text.Trim())))
                    return 0;

                if (ValidateDate(txtdateofissue.Text.Trim(), txtvaliddate.Text.Trim(), 3) == 0)
                    return 0;
            }
        }

        if (txtterminatedate.Text.Trim() != null)
        {
            if (txtterminatedate.Text.Trim() != "")
            {
                if (!(bIsValidDate = IsValidDate(txtterminatedate.Text.Trim(), txtterminatedate.Text.Trim())))
                    return 0;
            }
        }
        return 1;
    }
    protected int ValidateDate(string FrmDate, string ToDate, int iValue)
    {
        DateTime FmDates = Convert.ToDateTime(FrmDate);
        DateTime ToDates = Convert.ToDateTime(ToDate);
        if (FmDates >= ToDates)
        {
            if (iValue == 1)
            {
                lblMessage.Text = "Employment History From Date should be less than To Date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

            }
            else if (iValue == 2)
            {
                lblMessage.Text = "Experience From Date should be less than To Date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

            }
            else if (iValue == 3)
            {
                lblMessage.Text = "Valid Date should be less than Date of Issue Date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);


            }
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
            return 0;
        }
        return 1;
    }
    #endregion

    #region METHOD 'CheckUniqDate()' For Employement History
    protected int CheckUniqDate(string FrmDate, string ToDate, int iValue)
    {
        bool bIsValidDate = true;
        if (iValue != 1)
        {
            if (txtfrom1.Text.Trim() != "" && txtto1.Text.Trim() != null)
            {
                if (txtfrom1.Text.Trim() != "" && txtto1.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtfrom1.Text.Trim(), txtto1.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom1.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto1.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);


                        return 0;
                    }
                }
            }
        }
        if (iValue != 2)
        {
            if (txtfrom2.Text.Trim() != "" && txtto2.Text.Trim() != null)
            {
                if (txtfrom2.Text.Trim() != "" && txtto2.Text.Trim() != "")
                {

                    if (!(bIsValidDate = IsValidDate(txtfrom2.Text.Trim(), txtto2.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom2.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto2.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);
                        return 0;
                    }
                }
            }
        }
        if (iValue != 3)
        {
            if (txtfrom3.Text.Trim() != "" && txtto3.Text.Trim() != null)
            {
                if (txtfrom3.Text.Trim() != "" && txtto3.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtfrom3.Text.Trim(), txtto3.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom3.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto3.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

                        return 0;
                    }
                }
            }
        }
        if (iValue != 4)
        {
            if (txtfrom4.Text.Trim() != "" && txtto4.Text.Trim() != null)
            {
                if (txtfrom4.Text.Trim() != "" && txtto4.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtfrom4.Text.Trim(), txtto4.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom4.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto4.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

                        return 0;
                    }
                }
            }
        }
        if (iValue != 5)
        {
            if (txtfrom5.Text.Trim() != "" && txtto5.Text.Trim() != null)
            {
                if (txtfrom5.Text.Trim() != "" && txtto5.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtfrom5.Text.Trim(), txtto5.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom5.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto5.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

                        return 0;
                    }
                }
            }
        }
        if (iValue != 6)
        {
            if (txtfrom6.Text.Trim() != "" && txtto6.Text.Trim() != null)
            {
                if (txtfrom6.Text.Trim() != "" && txtto6.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtfrom6.Text.Trim(), txtto6.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtfrom6.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtto6.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Employment History From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "funShowAlertForDate('" + lblMessage.Text + "')", true);

                        return 0;
                    }
                }
            }
        }

        return 1;
    }
    #endregion

    #region METHOD 'CheckUniqDate()' For Sales/Marketing/Financial Services Experience
    protected int CheckUniqDateForExperience(string FrmDate, string ToDate, int iValue)
    {
        bool bIsValidDate = true;
        if (iValue != 1)
        {
            if (txtotherexpfrom1.Text.Trim() != null && txtotherexpTo1.Text.Trim() != null)
            {
                if (txtotherexpfrom1.Text.Trim() != "" && txtotherexpTo1.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtotherexpfrom1.Text.Trim(), txtotherexpTo1.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtotherexpfrom1.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtotherexpTo1.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Sales Experience From - " + FrmDate + " and To - " + ToDate + " Date alreday exist";
                        return 0;
                    }
                }
            }
        }
        if (iValue != 2)
        {
            if (txtotherexpfrom2.Text.Trim() != null && txtotherexpTo2.Text.Trim() != null)
            {
                if (txtotherexpfrom2.Text.Trim() != "" && txtotherexpTo2.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtotherexpfrom2.Text.Trim(), txtotherexpTo2.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtotherexpfrom2.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtotherexpTo2.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Sales Experience From - " + FrmDate + " and To - " + ToDate + " Date alreday exit";
                        return 0;
                    }
                }
            }
        }
        if (iValue != 3)
        {
            if (txtotherexpfrom3.Text.Trim() != null && txtotherexpTo3.Text.Trim() != null)
            {
                if (txtotherexpfrom3.Text.Trim() != "" && txtotherexpTo3.Text.Trim() != "")
                {
                    if (!(bIsValidDate = IsValidDate(txtotherexpfrom3.Text.Trim(), txtotherexpTo3.Text.Trim())))
                        return 0;

                    if (Convert.ToDateTime(txtotherexpfrom3.Text.Trim()) == Convert.ToDateTime(FrmDate) && Convert.ToDateTime(txtotherexpTo3.Text.Trim()) == Convert.ToDateTime(ToDate))
                    {
                        lblMessage.Text = "Sales Experience From - " + FrmDate + " and To - " + ToDate + " Date alreday exit";
                        return 0;
                    }
                }
            }
        }
        return 1;
    }
    #endregion

    #region METHOD 'CboxChecked()' DEFINITION
    private string CboxChecked(bool sValue)
    {
        if (sValue == true)
            return "Y";
        else
            return "N";
    }
    # endregion

    #region METHOD 'CboxChecked()' DEFINITION
    protected bool IsValidDate(string Date1, string Date2)
    {
        DateTime dtDate1;
        DateTime dtDate2;
        bool isDate = true;
        try
        {
            dtDate1 = DateTime.Parse(Date1);
            dtDate2 = DateTime.Parse(Date2);
        }
        catch (Exception ex)
        {
            lblMessage.Text = hdnIsDateValid.Value;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
            isDate = false;
        }

        return isDate;
    }
    #endregion

    #region METHOD 'ddlPaymentMode_SelectedIndexChanged()' DEFINITION
    //Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field start
    //protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlPaymentMode.SelectedValue == "CQ")
    //    {
    //        txtBankAccntNo.Enabled = false;
    //        txtBankAccntNo.Text = "";
    //        txtBankAccHoldName.Enabled = false;
    //        txtBankAccHoldName.Text = "";
    //        ddlBankBranch.Enabled = false;
    //        ddlBankBranch.SelectedIndex = 0;
    //        ddlBankCode.Enabled = false;
    //        ddlBankCode.SelectedIndex = 0;
    //        //txtDctmIndexNo.Enabled = false;
    //    }
    //    else
    //    {
    //        txtBankAccntNo.Enabled = true;
    //        UpBkaccno.Update();
    //        txtBankAccHoldName.Enabled = true;
    //        UpBkholdname.Update();
    //        ddlBankBranch.Enabled = true;
    //        UpBkNtfeCode.Update();
    //        ddlBankCode.Enabled = true;
    //        UpBkCode.Update();
    //        //txtDctmIndexNo.Enabled = true;
    //        UPBkbranch.Update();
    //    }
    //}
    //Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field end
    #endregion

    #region 'Inward Agent Creation'
    private int InwardAgentCreationBO(string cndNo, string AppNo, string CreateBy)
    {
        string strErrMsg = "";
        string[] strBOReqSPParam = new string[3];
        strBOReqSPParam[0] = AppNo;
        strBOReqSPParam[1] = "Y";
        strBOReqSPParam[2] = Session["CarrierCode"].ToString().Trim();

        //create agent inward
        MQAgnInwCrMgr PPMgr = new MQAgnInwCrMgr();
        MQAgnInwCr oPP = new MQAgnInwCr();
        int intBOStatus = PPMgr.FetchAgentInwardCreationDetailsFromLA(strBOReqSPParam, Session["CarrierCode"].ToString().Trim(), ref oPP, ref strErrMsg);



        ArrayList arrResultLog = new ArrayList();
        if (intBOStatus != 0)
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AppNo", AppNo);
            htParam.Add("@CndNo", cndNo);
            htParam.Add("@BOName", "CRT");

            if (intBOStatus == 1 || intBOStatus == 9 || intBOStatus == 11 || intBOStatus == 19)
            {
                if (oPP.ERRORCODE == null || oPP.ERRORDESCRIPTION == null)
                {
                    htParam.Add("@MsgNo", intBOStatus);
                    htParam.Add("@MsgDesc", DBNull.Value);
                }
                else
                {
                    htParam.Add("@MsgNo", oPP.ERRORCODE.ToString());
                    htParam.Add("@MsgDesc", oPP.ERRORDESCRIPTION.ToString());

                    if (oPP.ERRORCODE.Trim() == "E766")
                        intBOStatus = 0;
                }
            }
            else
            {
                htParam.Add("@MsgNo", intBOStatus);
                htParam.Add("@MsgDesc", DBNull.Value);
            }
            htParam.Add("@CreateBy", CreateBy);

            arrResultLog = clsCndReg.InsertAgentDetails(htParam, "prc_InwardAgentBOLog");

        }
        arrResultLog = null;

        if (intBOStatus == 0)
        {
            CreatePALInwardAgent(cndNo, CreateBy);
        }

        return intBOStatus;
    }
    #endregion

    #region 'Inward Agent Updation'
    private int InwardAgentUpdationBO(string cndNo, string AppNo, string UpdateBy)
    {
        string strErrMsg = "";
        string[] strBOReqSPParam = new string[3];
        strBOReqSPParam[0] = AppNo;
        strBOReqSPParam[1] = "Y";
        strBOReqSPParam[2] = Session["CarrierCode"].ToString().Trim();

        //create agent inward
        //MQAgnInwCrMgr PPMgr = new MQAgnInwCrMgr();
        //MQAgnInwCr oPP = new MQAgnInwCr();
        //int intBOStatus = PPMgr.FetchAgentInwardCreationDetailsFromLA(strBOReqSPParam, Session["CarrierCode"].ToString().Trim(), ref oPP, ref strErrMsg);

        //update agent inward
        MQAgnInwMdMgr PPMgr = new MQAgnInwMdMgr();
        MQAgnInwMd oPP = new MQAgnInwMd();
        int intBOStatus = PPMgr.FetchAgentInwardModificationDetailsFromLA(strBOReqSPParam, Session["CarrierCode"].ToString().Trim(), ref oPP, ref strErrMsg);
        ArrayList arrResult = new ArrayList();
        if (intBOStatus == 0)
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CndNo", cndNo);
            htParam.Add("@UpdateBy", UpdateBy);

            arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_InwardAgentUpdation");
            //if (arrResult[0].ToString() == "0")
            //{				
            //}
        }
        else
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AppNo", AppNo);
            htParam.Add("@CndNo", cndNo);
            htParam.Add("@BOName", "UPD");

            //if (intBOStatus == 1 || intBOStatus == 9 || intBOStatus == 11 || intBOStatus == 19)
            if (oPP.ERRORCODE == null || oPP.ERRORDESCRIPTION == null)
            {
                htParam.Add("@MsgNo", intBOStatus);
                htParam.Add("@MsgDesc", DBNull.Value);
            }
            else
            {
                htParam.Add("@MsgNo", oPP.ERRORCODE);
                htParam.Add("@MsgDesc", oPP.ERRORDESCRIPTION);
            }

            htParam.Add("@CreateBy", UpdateBy);

            arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_InwardAgentBOLog");
            //if (arrResult[0].ToString() == "0")
            //{				
            //}
        }
        arrResult = null;

        return intBOStatus;
    }
    #endregion

    #region 'Dummy Client & Agent Creation'
    private void CreateDummyClientandAgent(string cndNo, string CreateBy)
    {
        ArrayList arrResult = new ArrayList();

        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@CndNo", cndNo);
        htParam.Add("@CreateBy", CreateBy);

        arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_DummyCltandAgtCreation");

        arrResult = null;
    }
    #endregion

    #region 'PAL Inward Agent Creation'
    private void CreatePALInwardAgent(string cndNo, string CreateBy)
    {
        ArrayList arrResult = new ArrayList();

        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@CndNo", cndNo);
        htParam.Add("@CreateBy", CreateBy);

        arrResult = clsCndReg.InsertAgentDetails(htParam, "prc_InwardAgentCreation");

        arrResult = null;

    }
    #endregion

    #region 'Activity log'
    private void activitylog()
    {
        // 01...06/09/2012...Miti
        //Added radiobutton instead of checkbox for NOC recieved
        // 01...06/09/2012...Miti

        //02...06/09/2012...Miti
        //added a message box
        //02...06/09/2012...Miti

        //03...07/09/2012...Miti
        //Added dropdown list for relationship to advisor instead of textbox
        //03...07/09/2012...Miti

        //04...07/09/2012...Miti
        //MAde changes in PAN verification, in edit mode if PAN is not changed then it will not throw error of PAN verrification.
        //04...07/09/2012...Miti

        //05...12/09/2012...Miti
        //Added ajax popup
        //05...12/09/2012...Miti

        //06...13/09/2012...Miti
        //added verification label for CSC code
        //06...13/09/2012...Miti

        //07...26092012...Miti
        //Made changes in PAN Verification, Added NSDL URL to display the name of the respective PAN Number.
        //07...26092012...Miti
    }

    #endregion

    #region RbtNoc SelectedIndexChanged
    //Added by rachana on 09122013 to enable disable radio button RbAck on selection of radio button RbtNoc start
    protected void RbtNoc_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (RbtNoc.SelectedValue == "N") //added by pranjali on 24-03=-2014 for selected value start
        {
            //trAckRcv.Visible = true;
            RbAckRev.Visible = true;
            lblAckrcv.Visible = true;
            RbtNoc.Enabled = true;
            trNOCAck.Visible = true;
        }
        else
        {
            trNOCAck.Visible = false;
            RbAckRev.Visible = false;
            lblAckrcv.Visible = false;
            RbAckRev.ClearSelection();
        }
    }
    #endregion

    #region rbtIsSP SelectedIndexChanged
    protected void rbtIsSP_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rbtIsSP.SelectedValue == "Y")
        {
            tr_IsSPDtls.Visible = true;
        }
        else
        {
            tr_IsSPDtls.Visible = false;
        }
    }
    #endregion

    #region basic qualification ddl SelectedIndexChanged
    //Added by kalyani on 27-12-2013 to enable panchayat proof checkbox when basic qualification is ssc and classification is rural   
    protected void ddlBasicQual_SelectedIndexChanged(object sender, EventArgs e)
    {

        if ((ddlBasicQual.SelectedValue == "SSC") && (ddlcategory.SelectedValue == "P"))
        {
            trPanchayat.Visible = false;

        }
        else
        {
            trPanchayat.Visible = false;

        }

        PopulateProofIDDoc();
        ddlBasicQual.Focus();
    }
    #endregion

    #region cbTrfrFlag CheckedChanged
    //Added by kalyani on 30-12-2013 to disabale composite license checkbox on selection of transfer case
    protected void cbTrfrFlag_CheckedChanged(object sender, EventArgs e)
    {

        // cbTccCompLcn.Enabled = false;
        if (cbTrfrFlag.Checked == true)
        {
            trCompTitle.Visible = false;
            trNote.Visible = false;
            //divPrior.Visible = false;
            trNoteTr.Visible = true;
            lblIC.Visible = true;
            txtIC.Visible = true;
            txtIC.Enabled = true;
            //added  by usha for calander enable  
            // CalendarExtender28.Enabled = true;
            ddlCaTrnsfr.Enabled = true;
            ddlNameInTrnsfr.Enabled = true;

            txtAgencyCodeTrnsfr.Enabled = true;
            txtDateOfAppointmentTrnsfr.Enabled = true;
            ddlStsTrnsfr.Enabled = true;
            txtDateOfCessationTrnsfr.Enabled = true;
            txtReasonForCessationTrnsfr.Enabled = true;
            divTrnsferDetails.Visible = true;
            divTagged.Visible = false;
            // trTagTitle.Visible = false;
            NameInsurance(ddlNameInTrnsfr);
            //  CatComp(ddlCaTrnsfr);
            cbFrshFlag.Checked = false;
            //trFreshTitle.Visible = false;
        }
        else if (cbTrfrFlag.Checked == false)
        {
            //added by pranjali on 25-04-2014 start
            if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "F");
                cbFrshFlag.Checked = true;
                trFreshTitle.Visible = true;
            }
            else
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "C");
            }
            //added by pranjali on 25-04-2014 end
            divTrnsferDetails.Visible = false;//added by pranjali on 13-03-2014 
            txtOldTccLcnNo.Text = "";
            txtDate.Text = "";
            ddlTrnsfrInsurName.SelectedIndex = 0;
            RbtNoc.ClearSelection();
            RbAckRev.ClearSelection();
            txtLicIssueDt.Text = "";
            lbllcnerr2.Text = "";
            trCompTitle.Visible = true;//added by amruta on 15.6.15
            trTagTitle.Visible = true;
            //Added by Prathamesh 12-8-15 start
            txtIC.Text = "";//added by amruta on 16.6.15
            ddlCaTrnsfr.SelectedIndex = 0;
            ddlStsTrnsfr.SelectedValue = "0";
            ddlNameInTrnsfr.SelectedIndex = 0;
            txtAgencyCodeTrnsfr.Text = "";
            txtDateOfAppointmentTrnsfr.Text = "";
            txtReasonForCessationTrnsfr.Text = "";
            txtDateOfCessationTrnsfr.Text = "";
            //Added by Prathamesh 12-8-15 end
            cbTrfrFlag.Focus();
        }
    }
    #endregion

    #region cbTagFlag CheckedChanged
    //Added by kalyani on 30-12-2013 to disabale composite license checkbox on selection of transfer case

    #region DROPDOWN 'ddlTagCat' SELECTEDINDEXCHANGED EVENT
    protected void ddlTagcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTagCat.SelectedValue != "Select")
        {
            DataSet dtTag = new DataSet();
            htParam.Clear();
            dtTag.Clear();
            htParam.Add("@Flag", "2");
            htParam.Add("@category", ddlTagCat.SelectedValue);
            dtTag = dataAccessclass.GetDataSetForPrcRecruit("Prc_ddlmstinsName", htParam);

            if (dtTag.Tables[0].Rows.Count > 0)
            {
                ddlTagIns.DataSource = dtTag;
                ddlTagIns.DataTextField = "Name";
                ddlTagIns.DataValueField = "Name";
                ddlTagIns.DataBind();
                ddlTagIns.Items.Insert(0, "Select");
            }
        }
        else
        {
            ddlTagIns.Items.Clear();
            ddlTagIns.Items.Insert(0, "Select");
        }
    }
    # endregion

    protected void cbTagFlag_CheckedChanged(object sender, EventArgs e)
    {

        if (cbTagLcn.Checked == true)
        {
            trCompTitle.Visible = false;

            ddlTagCat.Enabled = true;
            ddlTagIns.Enabled = true;
            txtTagAgn.Enabled = true;
            txtTagApp.Enabled = true;
            ddlTagStatus.Enabled = true;
            divTagged.Visible = true;
            divTrnsferDetails.Visible = false;
            //trTrnTitle.Visible = false;
            txtTagURN.Enabled = true;
            // CatComp(ddlTagCat);
            //CatComp(ddlCatFlag);
            // CatComp(ddlTagCat, dsResult.Tables[3]);
            cbFrshFlag.Checked = false;
            //trFreshTitle.Visible = false;
        }
        else if (cbTagLcn.Checked == false)
        {
            //added by pranjali on 25-04-2014 start
            if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false || cbTagLcn.Checked == false)
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "F");
                cbFrshFlag.Checked = true;
                trFreshTitle.Visible = true;
            }
            else
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "C");
            }
            //added by pranjali on 25-04-2014 end
            divTagged.Visible = false;//added by pranjali on 13-03-2014 
            trTrnTitle.Visible = true;
            trCompTitle.Visible = true;//added by amruta on 15.6.15

            ddlTagCat.SelectedIndex = 0;
            ddlTagStatus.SelectedValue = "1";
            ddlTagIns.SelectedIndex = 0;
            txtTagAgn.Text = "";
            txtTagApp.Text = "";
            txtTagURN.Text = "";
        }
    }
    #endregion

    #region Language checkbox visibility
    //Added by kalyani on 3-1-2014 to make visible languages checkbox on dropdown selection start
    protected void ddllanknow1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread1.Visible = true;
        lblqfwrite1.Visible = true;
        lblqfspeak1.Visible = true;
        //tdlanknow1.Attributes.Add("Style", "visibility:visible");
        cbpread.Visible = true;
        cbpwrite.Visible = true;
        cbpspeak.Visible = true;
    }
    protected void ddllanknow2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread1.Visible = true;
        lblqfwrite1.Visible = true;
        lblqfspeak1.Visible = true;
        cbpread2.Visible = true;
        cbpwrite2.Visible = true;
        cbpspeak2.Visible = true;
    }
    protected void ddllanknow3_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread2.Visible = true;
        lblqfwrite2.Visible = true;
        lblqfspeak2.Visible = true;
        cbpread3.Visible = true;
        cbpwrite3.Visible = true;
        cbpspeak3.Visible = true;
    }
    protected void ddllanknow4_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread2.Visible = true;
        lblqfwrite2.Visible = true;
        lblqfspeak2.Visible = true;
        cbpread4.Visible = true;
        cbpwrite4.Visible = true;
        cbpspeak4.Visible = true;
    }
    //Added by kalyani on 3-1-2014 to make visible languages checkbox on dropdown selection end
    #endregion

    #region composite license checkedchanged
    //Added by kalyani on 6-1-2014 to disabale NOC received on selection of composite license
    protected void cbTccCompLcn_CheckedChanged(object sender, EventArgs e)
    {
        //added by amruta for composite on 5/6/15 start 
        if (cbTccCompLcn.Checked == true)
        {

            divCompDtls.Visible = true;
            trTrnTitle.Visible = false;//added by amruta on 15.6.15
            trNote.Visible = true;

            radioComposite.Enabled = true;
            ddlCatComp.Enabled = false;
            ddlNameIns.Enabled = false;//amruta 8.6.15
            // txtInsurer.Enabled = false;
            txtAgencyCode.Enabled = false;
            txtDateOfAppointment.Enabled = false;
            ddlSts.Enabled = false;
            txtDateOfCessation.Enabled = false;
            txtReasonForCessation.Enabled = false;
            divCompositeDetails.Visible = true;
            NameInsurance(ddlNameIns);//Comented by usha on 05.01.2018
            //CatComp(ddlCatComp);
            cbFrshFlag.Checked = false;
            trFreshTitle.Visible = false;
            trTagTitle.Visible = false;
        }

        //added by amruta for composite on 5/6/15 end
        else
        {
            //added by amruta for composite on 5/6/15 start 
            divCompDtls.Visible = false;
            radioComposite.ClearSelection();
            radioComposite.Enabled = false;
            //added by amruta for composite on 5/6/15 end
            //added by pranjali on 25-04-2014 start
            if (cbTccCompLcn.Checked == false && cbTrfrFlag.Checked == false)
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "F");
                cbFrshFlag.Checked = true;
                trFreshTitle.Visible = true;
            }
            else
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "T");
            }
            //added by pranjali on 25-04-2014 end
            divCompositeDetails.Visible = false;//added by pranjali on 13-03-2014 
            txtCompLicNo.Text = "";
            txtCompLicExpDt.Text = "";
            ddlCompInsurerName.SelectedIndex = 0;
            //chkCompAgnt.Checked = false;//added by pranjali on 28-03-2014
            lbllcnerr.Text = "";
            trNote.Visible = false;
            trTrnTitle.Visible = true;//addded by amruta on 15.6.15
            trTagTitle.Visible = true;
            //Added by Prathamesh 12-8-15 start
            ddlCatComp.SelectedIndex = 0;
            ddlSts.SelectedValue = "0";
            ddlNameIns.SelectedIndex = 0;//amruta 8.6.15
            txtAgencyCode.Text = "";
            txtDateOfAppointment.Text = "";
            txtDateOfCessation.Text = "";
            txtReasonForCessation.Text = "";
            //Added by Prathamesh 12-8-15 end


        }
    }
    #endregion

    //added by pranjali on 30-04-2014 start
    #region BUTTON 'Verify EmpCode Click' DEFINITION
    protected void btnVerifyEmpCode_Click(object sender, EventArgs e)
    {
        try
        {
            bool IsFound = false;



            //added by pranjali on 01-04-2014 start
            DataSet dscode = new DataSet();
            dscode = oCommonUtility.GetUserDtls(Session["UserID"].ToString().Trim());
            string strMemberCode = dscode.Tables[0].Rows[0]["MemberCode"].ToString();
            string strMemberType = dscode.Tables[0].Rows[0]["MemberType"].ToString();
            string strBizSrc = dscode.Tables[0].Rows[0]["BizSrc"].ToString();
            string strChnCls = dscode.Tables[0].Rows[0]["ChnCls"].ToString();
            //pranjali 30-04-2014
            string UserTypeEmp = dscode.Tables[0].Rows[0]["UserType"].ToString();
            string UnitCodeEmp = dscode.Tables[0].Rows[0]["UnitCode"].ToString();//pranjali on 05-04-2014
            if (UserTypeEmp == "I")
            {
                Hashtable htalwEmp = new Hashtable();
                DataSet dsallwrecruitEmp = new DataSet();
                htalwEmp.Add("@MemberCode", strMemberCode);
                htalwEmp.Add("@MemberType", strMemberType);
                dsallwrecruitEmp = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetAllowRecruitDtl", htalwEmp);
                if ((dsallwrecruitEmp.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "1") || (dsallwrecruitEmp.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "True"))
                {
                    if (dsallwrecruitEmp.Tables[0].Rows[0]["EmpCode"].ToString() == txtEmpCode.Text)
                    {

                    }
                    else
                    {
                        lblEmpMsg.Visible = true;
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                        lblEmpMsg.Text = "Employee is not allowed to recruit";
                        return;
                    }
                }
                //pranjali
                DataSet dsRecruiterCode = new DataSet();
                dsRecruiterCode = GetEmployeeDetail(txtEmpCode.Text.Trim());
                if (dsRecruiterCode.Tables.Count > 0)
                {
                    if (dsRecruiterCode.Tables[0].Rows.Count > 0)
                    {
                        string strEmpCode = dsRecruiterCode.Tables[0].Rows[0]["EmpCode"].ToString();
                        string strRecruiterCode = dsRecruiterCode.Tables[0].Rows[0]["MemberCode"].ToString();
                        string strRecruiterType = dsRecruiterCode.Tables[0].Rows[0]["MemberType"].ToString();
                        string strRecruiterBizSrc = dsRecruiterCode.Tables[0].Rows[0]["BizSrc"].ToString();
                        string strRecruiterChnCls = dsRecruiterCode.Tables[0].Rows[0]["ChnCls"].ToString();

                        htParam.Clear();
                        htParam.Add("@MemberCode", strMemberCode);
                        htParam.Add("@RecruiterCode", strRecruiterCode);
                        htParam.Add("@EmpCode", strEmpCode);
                        htParam.Add("@RecruiterType", strRecruiterType);
                        htParam.Add("@RecruiterBizSrc", strRecruiterBizSrc);
                        htParam.Add("@RecruiterChnCls", strRecruiterChnCls);
                        dsResult.Clear();
                        dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetVerifyEmpDtls", htParam);

                    }
                    else
                    {
                        lblEmpMsg.Visible = true;
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                        lblEmpMsg.Text = "Employee is not allowed to recruit";//"No Match Found";
                        StrMsg = 1;
                    }
                }
            }
            else if (UserTypeEmp == "E")
            {
                DataSet dsEmpCode = new DataSet();
                dsEmpCode = GetEmployeeDetail(txtEmpCode.Text.Trim());
                string strrecruiterCode1 = dsEmpCode.Tables[0].Rows[0]["MemberCode"].ToString();
                string strEmpCode1 = dsEmpCode.Tables[0].Rows[0]["EmpCode"].ToString();
                string strEmpType1 = dsEmpCode.Tables[0].Rows[0]["MemberType"].ToString();
                string strEmpBizSrc1 = dsEmpCode.Tables[0].Rows[0]["BizSrc"].ToString();
                string strEmpChnCls1 = dsEmpCode.Tables[0].Rows[0]["ChnCls"].ToString();
                string strEmpUnitCode1 = dsEmpCode.Tables[0].Rows[0]["UnitCode"].ToString();
                htParam.Clear();
                htParam.Add("@RecruiterCode", strrecruiterCode1);
                htParam.Add("@RecruiterType", strEmpType1);
                htParam.Add("@RecruiterBizSrc", strEmpBizSrc1);
                htParam.Add("@RecruiterChnCls", strEmpChnCls1);
                htParam.Add("@UnitCode", UnitCodeEmp);
                dsResult = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetRecruiterDtlsForExtrnl", htParam);
            }
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    IsFound = true;

                    txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]).Trim();

                    //Added by pranjali on 27-12-2013 start
                    ViewState["UnitCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                    //hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                    string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                    string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                    hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                    //txtImmLeader.Text = branch + " " + "(" + cmsunitcode + ")"; commented by mrunala as not required
                    //Added by pranjali on 27-12-2013 end
                    txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                    hdnBizSrc.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                    //Set the Sales Channel 
                    if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                        {
                            //GetRecruitSalesChannel(ddlSlsChannel, "", 0);


                            if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                            {
                                //added by usha for emerzing market  on 06.01.2016
                                if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                                {
                                    ddlSlsChannel.SelectedItem.Text = ddlSlsChannel.SelectedItem.Text; //Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                }
                                //  ended by usha
                                else
                                {
                                    ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();

                                    FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]));
                                }
                            }

                        }
                    }

                    //Set the Channel sub Class
                    if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                        {
                            //added by usha for emerzing market  on 06.01.2016

                            if (dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim() == "XXXX")
                            {
                                ddlChnCls.SelectedItem.Text = ddlChnCls.SelectedItem.Text;//Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();

                            }
                            //  ended by usha
                            //if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                            //{
                            else
                            {
                                FillddlSlsChannel(ddlSlsChannel.SelectedValue);

                                ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                            }
                        }
                    }

                    strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
                    PopulateAgentTypes(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, strAgentType);
                    ddlAgnTypes.SelectedItem.Text = dsResult.Tables[0].Rows[0]["AgentTypeDesc01"].ToString().Trim();
                    ddlAgnTypes.SelectedItem.Value = strAgentType;//dsResult.Tables[0].Rows[0]["AgentTypeDesc01"].ToString().Trim();
                    ddlAgntType.Visible = false;
                    ddlAgnTypes.Visible = true;
                    FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());//01

                }
            }




            dsResult = null;
            SqlDataReader drResult;
            Hashtable httable = new Hashtable();
            if (IsFound == false)
            {
                lblEmpMsg.Visible = true;
                lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                lblEmpMsg.Text = "Employee is not allowed to recruit";//"No Match Found";
            }
            else
            {
                lblEmpMsg.Visible = true;
                lblEmpMsg.ForeColor = System.Drawing.Color.Green;
                lblEmpMsg.Text = "Employee Code verified.";
                //btnVerifyCSC.Enabled = false;//Commented by rachana on 22-08-2014
                //txtSmCode.Enabled = false;//Commented by rachana on 22-08-2014
                ddlAgnTypes.Focus();
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
    //added by pranjali on 30-04-2014 end

    protected void txtCompLicNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtOldTccLcnNo_TextChanged(object sender, EventArgs e)
    {

    }



    //added by amruta on 27/05/2015 start
    // DataTable dt = new DataTable();
    DataTable dt_composite = new DataTable();
    protected void btnAddComposite_Click(object sender, EventArgs e)
    {
        DateTime DOB;
        if (txtDOB.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Date of Birth.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDOB.Focus();
            return;
        }
        try
        {
            DOB = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter date in dd/mm/yyyy format.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDOB.Focus();
            return;
        }

        bool b = DateDiff(txtDOB.Text, txtDateOfAppointment.Text);
        if (b == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment as agent should be more than 18')", true);
            return;
        }
        if (cbTccCompLcn.Checked == true)
        {
            if (gvComposite.Rows.Count <= 3)
            {
                cbTccCompLcn.Enabled = false;
                cbTrfrFlag.Enabled = false;

            }


        }


        //comment by Prathamesh 20-7-15 start
        if (ddlCatComp.SelectedIndex == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is Mandatory for Composite')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlCatComp.Focus();
            return;
        }
        //amruta 8.6.15
        if (ddlNameIns.SelectedIndex == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of Insurer is Mandatory for Composite')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlNameIns.Focus();
            return;
        }
        if (txtAgencyCode.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency Code is Mandatory for Composite')", true);
            ProgressBarModalPopupExtender.Hide();
            txtAgencyCode.Focus();
            return;

        }
        if (txtDateOfAppointment.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Appointment as agent is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDateOfAppointment.Focus();
            return;
        }

        if (ddlSts.SelectedIndex == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Status is Mandatory for Composite')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlSts.Focus();
            return;
        }

        if (ddlSts.SelectedValue == "2")
        {
            if (txtDateOfCessation.Text == "")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Cessation of Agency for Composite is Mandatory')", true);
                txtDateOfCessation.Focus();
                ProgressBarModalPopupExtender.Hide();
                return;
            }
            //if (txtReasonForCessation.Text == "")
            //{

            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reason for Cessation of Agency for Composite is Mandatory')", true);
            //    ProgressBarModalPopupExtender.Hide();
            //    txtReasonForCessation.Focus();
            //    return;

            //}
        }


        dt_composite.Columns.Add("Category");
        dt_composite.Columns.Add("Name_of_Insurer");
        dt_composite.Columns.Add("Agency_code_Number");
        dt_composite.Columns.Add("Date_of_appointment_as_agent");
        dt_composite.Columns.Add("Date_of_cessation_of_agency");
        dt_composite.Columns.Add("Reason_for_cessation_of_agency");
        dt_composite.Columns.Add("AutoWavier");//added by amruta on 11.7.15
        DataRow dr;

        foreach (GridViewRow row in gvComposite.Rows)
        {
            dr = dt_composite.NewRow();
            Label lblCategory = (Label)row.FindControl("lblCategory");
            Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
            Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
            Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
            Label lblDateCessation = (Label)row.FindControl("lblDateCessation");
            Label lblReasonCessation = (Label)row.FindControl("lblReasonCessation");
            Label lblAutoWavier = (Label)row.FindControl("lblAutoWavier");
            dr[0] = lblCategory.Text;
            dr[1] = lblNameInsurer.Text;
            dr[2] = lblAgencyCode.Text;
            dr[3] = lblDateAppointment.Text;
            dr[4] = lblDateCessation.Text;
            dr[5] = lblReasonCessation.Text;
            dr[6] = lblAutoWavier.Text;
            dt_composite.Rows.Add(dr);
        }
        foreach (GridViewRow row in gvComposite.Rows)
        {
            Label lblCatry = (Label)row.FindControl("lblCategory");
            if (ddlCatComp.SelectedItem.Text.ToUpper() == "LIFE")
            {
                if (lblCatry.Text.ToUpper() == "LIFE")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can not add more then one Life Company details')", true);
                    ProgressBarModalPopupExtender.Hide();
                    return;
                }
            }
            if (ddlCatComp.SelectedItem.Text.ToUpper() == "HEALTH")
            {
                if (lblCatry.Text.ToUpper() == "HEALTH")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can not add more then one Health Company details')", true);
                    ProgressBarModalPopupExtender.Hide();

                    return;
                }
            }
        }

        if (gvComposite.Rows.Count <= 3)
        {
            //dt.Rows.Add(dr);
            dr = dt_composite.NewRow();
            dr["Category"] = ddlCatComp.Text;
            dr["Name_of_Insurer"] = ddlNameIns.Text;//amruta 8.6.15
            dr["Agency_code_Number"] = txtAgencyCode.Text;
            dr["Date_of_appointment_as_agent"] = txtDateOfAppointment.Text;
            dr["Date_of_cessation_of_agency"] = txtDateOfCessation.Text;
            dr["Reason_for_cessation_of_agency"] = txtReasonForCessation.Text;
            //added by amruta on 11.7.15 start
            if (ddlCatComp.Text == "Life" && ddlNameIns.Text == "Reliance Life Insurance Company Limited." && ddlSts.Text == "1")
            {
                dr["AutoWavier"] = "Y";
            }
            else
            {
                dr["AutoWavier"] = "N";
            }
            //added by amruta on 11.7.15 end
            dt_composite.Rows.Add(dr);
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);

        }
        hdnCount.Value = dt_composite.Rows.Count.ToString();
        gvComposite.DataSource = dt_composite;
        gvComposite.DataBind();
        Session["datatable"] = dt_composite;
        ddlCatComp.SelectedIndex = 0;
        ddlSts.SelectedValue = "0";
        ddlNameIns.SelectedIndex = 0;//amruta 8.6.15
        txtAgencyCode.Text = "";
        txtDateOfAppointment.Text = "";
        txtDateOfCessation.Text = "";
        txtReasonForCessation.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funAddTr();", true);

    }



    protected void gvComposite_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt_composite = (DataTable)Session["datatable"];
        if (dt_composite.Rows.Count >= 0)
        {

            dt_composite.Rows.RemoveAt(Convert.ToInt16(e.RowIndex));

            gvComposite.DataSource = dt_composite;
            gvComposite.DataBind();

            //added by meena 8_5_18 start
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
            ProgressBarModalPopupExtender.Hide();
            return;
            //added by meena 8_5_18 End

        }

        if (gvComposite.Rows.Count == 0)
        {
            cbTccCompLcn.Enabled = true;
            cbTrfrFlag.Enabled = false;

        }





    }
    protected void gvTrnsfr_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt_trnsfr = (DataTable)Session["datatable"];
        if (dt_trnsfr.Rows.Count >= 0)
        {

            dt_trnsfr.Rows.RemoveAt(Convert.ToInt16(e.RowIndex));
            gvTrnsfr.DataSource = dt_trnsfr;
            gvTrnsfr.DataBind();
            hdnTransfer.Value = dt_trnsfr.Rows.Count.ToString();

            if (gvTrnsfr.Rows.Count == 0)
            {
                lblNoteIc.Visible = true;
            }

        }




        //aded by amruta on 18.6.15 start
        if (dt_trnsfr.Rows.Count == 0)
        {
            tdNoteIc.Visible = true;
            cbTccCompLcn.Enabled = false;
            cbTrfrFlag.Enabled = true;
        }
        //aded by amruta on 18.6.15 end




    }

    //added by amruta on 27/05/2015 end



    //added by amruta for composite on 5/6/15 start 
    protected void radioComposite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioComposite.SelectedValue == "0")
        {
            ddlCatComp.Enabled = true;
            ddlNameIns.Enabled = true;//amruta 8.6.15
            txtAgencyCode.Enabled = true;
            txtDateOfAppointment.Enabled = true;
            ddlSts.Enabled = true;
            txtDateOfCessation.Enabled = true;
            txtReasonForCessation.Enabled = true;
            txtDateOfAppointment.Enabled = true;
            // divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014 

            //added by pranjali on 27-03-2014 for life license and general license no to be same start
            if (cbTccCompLcn.Checked == true && cbTrfrFlag.Checked == true)
            {
                txtCompLicNo.Text = txtOldTccLcnNo.Text;
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "T");
            }
            else
            {
                FillCndAgntTypeOnCndType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "C");
            }
        }
        else
        {
            ddlCatComp.Enabled = false;
            ddlNameIns.Enabled = false;//amruta 8.6.15
            txtAgencyCode.Enabled = false;
            txtDateOfAppointment.Enabled = false;
            ddlSts.Enabled = false;
            txtDateOfCessation.Enabled = false;
            txtReasonForCessation.Enabled = false;
            txtDateOfAppointment.Enabled = false;
        }
    }
    //added by amruta for composite on 5/6/15 end
    //added by amruta for composite on 8/6/15 start
    private void NameInsurance(DropDownList ddl, string Catagory)
    {
        try
        {


            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();

            if (cbTccCompLcn.Checked == false)
            {
                htParam.Add("@Flag", "1");
                htParam.Add("@category", Catagory.ToString());
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("Prc_ddlmstinsName", htParam);
            }

            else
            {
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("Prc_ddlmstinsName");
            }

            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsComp;
                ddl.DataTextField = "Name";
                ddl.DataValueField = "Name";
                ddl.DataBind();
                ddl.Items.Insert(0, "Select");
            }
            //added by amruta for composite on 9/6/15 End



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

    private void NameInsurance(DropDownList ddl)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();
            if (cbTccCompLcn.Checked == false)
            {
                htParam.Add("@Flag", "1");
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("Prc_ddlmstinsName", htParam);
            }
            else
            {
                dsComp = dataAccessclass.GetDataSetForPrcRecruit("Prc_ddlmstinsName");
            }
            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsComp;
                ddl.DataTextField = "Name";
                ddl.DataValueField = "Name";
                ddl.DataBind();
                ddl.Items.Insert(0, "--Select--");
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

    private void CatComp(DropDownList ddl, DataTable dsData)
    {
        try
        {
            ddl.Items.Clear();
            ddl.DataSource = dsData;
            if (cbTccCompLcn.Checked == true)
            {
                ddl.DataSource = dsData;
            }
            else if (cbTagLcn.Checked == true)
            {
                ddl.DataSource = dsData;
            }
            else
            {
                ddl.DataSource = dsData;

            }
            ddl.DataTextField = "InsType";
            ddl.DataValueField = "InsType";
            ddl.DataBind();
            ddl.Items.Insert(0, "Select");
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
    //Added By NIKHIL
    private void BindTagGrid(string strCndNo)
    {
        Hashtable htCompGrd = new Hashtable();
        DataSet dsCompGrd = new DataSet();
        htCompGrd.Add("@CndNo", strCndNo.Trim());
        dsCompGrd = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetTagsDtls", htCompGrd);
        string strCndType = candtype;
        if (dsCompGrd != null)
        {
            if (dsCompGrd.Tables.Count > 0 && dsCompGrd.Tables[0].Rows.Count > 0)
            {
                grdTag.DataSource = dsCompGrd.Tables[0];
                grdTag.DataBind();
                DataTable dt = dsCompGrd.Tables[0];
                Session["datatable"] = dt;
                cbTagFlag_CheckedChanged(this, EventArgs.Empty);
                divTagged.Visible = true;
                divCatFlag.Visible = true;
                txtTagURN.Text = dsCompGrd.Tables[0].Rows[0]["CndUrn"].ToString().Trim();
                for (int i = 0; i < dsCompGrd.Tables[0].Rows.Count; i++)
                {
                    if (dsCompGrd.Tables[0].Rows[i]["CatFlag"].ToString().Trim() != "")
                    {
                        ddlCatFlag.SelectedValue = dsCompGrd.Tables[0].Rows[i]["CatFlag"].ToString().Trim();
                    }
                }
            }
        }
    }

    //Ended by Nikhil

    //added by amruta for composite on 8/6/15 end

    private void BindCompositeGrid(string strCndNo)
    {
        Hashtable htCompGrd = new Hashtable();
        DataSet dsCompGrd = new DataSet();
        htCompGrd.Add("@CndNo", strCndNo.Trim());
        dsCompGrd = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCompDtls", htCompGrd);
        //added by usha 

        string strCndType = candtype;
        if (dsCompGrd != null)
        {
            if (dsCompGrd.Tables.Count > 0 && dsCompGrd.Tables[0].Rows.Count > 0)



                //  Added by usha for bind grid in candidate modification on 13/06/2015
                if (strCndType == "C")
                {
                    gvComposite.DataSource = dsCompGrd.Tables[0];
                    gvComposite.DataBind();
                    DataTable dt = dsCompGrd.Tables[0];
                    Session["datatable"] = dt;
                }

                else
                {
                    gvTrnsfr.DataSource = dsCompGrd.Tables[0];
                    gvTrnsfr.DataBind();
                    DataTable dt = dsCompGrd.Tables[0];
                    Session["datatable"] = dt;
                }
            //Ended by usha on 13/06/2015
        }
    }

    //added by amruta for transfer on 11/6/15 start


    DataTable dt_trnsfr = new DataTable();

    protected void btnAddTrnsfr_Click(object sender, EventArgs e)
    {

        if (cbTrfrFlag.Checked == true)
        {
            if (gvComposite.Rows.Count <= 3)
            {
                cbTrfrFlag.Enabled = false;
                cbTccCompLcn.Enabled = false;

            }
        }


        DateTime Today = System.DateTime.Now;

        //Added by Prathamesh 20-7-15
        DateTime DOB;
        if (txtDOB.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Date of Birth.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDOB.Focus();
            return;
        }
        try
        {
            DOB = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter date in dd/mm/yyyy format.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDOB.Focus();
            return;
        }
        bool b = DateDiff(txtDOB.Text, txtDateOfAppointmentTrnsfr.Text);
        if (b == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment as agent should be more than 18')", true);
            return;
        }
        DateTime ICDt;
        if (txtIC.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            txtIC.Focus();
            return;
        }
        if (ddlCaTrnsfr.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlCaTrnsfr.Focus();
            return;
        }
        try
        {
            ICDt = DateTime.ParseExact(txtIC.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date in dd/mm/yyyy format.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtIC.Focus();
            return;
        }
        if (ICDt > Today)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date can not be Greater than Today Date')", true);
            ProgressBarModalPopupExtender.Hide();
            txtIC.Focus();
            return;
        }
        if (ICDt.Year < 1900)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid I-C Date')", true);
            ProgressBarModalPopupExtender.Hide();
            txtIC.Focus();
            return;
        }
        if (ddlNameInTrnsfr.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of Insurer is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlNameInTrnsfr.Focus();
            return;
        }
        if (txtAgencyCodeTrnsfr.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency Code is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            txtAgencyCodeTrnsfr.Focus();
            return;
        }
        if (txtDateOfAppointmentTrnsfr.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Appointment as agent is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDateOfAppointmentTrnsfr.Focus();
            return;
        }
        DateTime DateOfAppointmentTrnsfr;
        try
        {
            DateOfAppointmentTrnsfr = DateTime.ParseExact(txtDateOfAppointmentTrnsfr.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date in dd/mm/yyyy format.')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDateOfAppointmentTrnsfr.Focus();
            return;
        }
        if (DateOfAppointmentTrnsfr.Year < 1900)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Date of appointment as agent ')", true);
            ProgressBarModalPopupExtender.Hide();
            txtDateOfAppointmentTrnsfr.Focus();
            return;
        };
        if (ddlStsTrnsfr.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Status is Mandatory for Transfer')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlStsTrnsfr.Focus();
            return;
        }
        if (ddlStsTrnsfr.SelectedValue == "2")
        {
            if (txtDateOfCessationTrnsfr.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Cessation is Mandatory for Transfer')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDateOfCessationTrnsfr.Focus();
                return;
            }
            DateTime DateOfCessation;
            try
            {
                DateOfCessation = DateTime.ParseExact(txtDateOfCessationTrnsfr.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date in dd/mm/yyyy format.')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDateOfCessationTrnsfr.Focus();
                return;
            }

            if (DateOfCessation.Year < 1900)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Date of Cessation.')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDateOfCessationTrnsfr.Focus();
                return;
            }

            if (DateOfCessation > Today)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Cessation Cannot be Greater Than Todays Date.')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDateOfCessationTrnsfr.Focus();
                return;
            }

            if (txtReasonForCessationTrnsfr.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reason of Cessation is Mandatory for Transfer')", true);
                ProgressBarModalPopupExtender.Hide();
                txtReasonForCessationTrnsfr.Focus();
                return;
            }

        }
        htParam.Clear();
        dsResult = null;
        htParam.Add("@ICDate", txtIC.Text);
        htParam.Add("@DateAppoinment", txtDateOfAppointmentTrnsfr.Text);
        htParam.Add("@Datecessation", txtDateOfCessationTrnsfr.Text);
        dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_CheckICDateVal", htParam);
        if (txtIC.Text != "")
        {
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    string strIsValid = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();
                    if (strIsValid == "Invalid")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('AS per the Guidelines on Appointment of Insurance Agents 2015 vide circular IRDA/AGTS/CIR/GLD/046/03/2015 dtd 16/03/2015 An Insurer will consider the agency application of the agent only after a period of 90 days from the date of issue of the cessation certificate issued by the previous insurer')", true);
                        ProgressBarModalPopupExtender.Hide();
                        txtIC.Focus();
                        return;
                    }
                }
            }
        }
        if (txtDateOfAppointmentTrnsfr.Text != "")
        {

            if (dsResult != null)
            {
                if (txtIC.Text != "")
                {
                    if ((Convert.ToDateTime(txtIC.Text)) <= (Convert.ToDateTime(txtDOB.Text.Trim())))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date should not be less than or equal to birth date')", true);
                        txtIC.Focus();
                        return;
                    }
                }
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    string strIsValid = dsResult.Tables[0].Rows[0]["Flag1"].ToString().Trim();
                    if (strIsValid == "Invalid")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment as agent should be less than I-C Date ')", true);
                        ProgressBarModalPopupExtender.Hide();
                        txtDateOfAppointmentTrnsfr.Focus();
                        return;
                    }
                }

                if (txtDateOfAppointmentTrnsfr.Text != "")
                {
                    if ((Convert.ToDateTime(txtDateOfAppointmentTrnsfr.Text)) <= (Convert.ToDateTime(txtDOB.Text.Trim())))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment as agent date should not be less than or equal to birth date')", true);
                        txtDateOfAppointmentTrnsfr.Focus();
                        return;
                    }
                }
            }
        }
        if (txtDateOfCessationTrnsfr.Text != "")
        {

            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    string strIsValid = dsResult.Tables[0].Rows[0]["Flag2"].ToString().Trim();
                    if (strIsValid == "Invalid")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of cessation should be greater than I-C Date')", true);
                        ProgressBarModalPopupExtender.Hide();
                        txtDateOfCessationTrnsfr.Focus();
                        return;
                    }
                }
            }
        }
        dt_trnsfr.Columns.Add("Date");
        dt_trnsfr.Columns.Add("Category");
        dt_trnsfr.Columns.Add("Name_of_Insurer");
        dt_trnsfr.Columns.Add("Agency_code_Number");
        dt_trnsfr.Columns.Add("Date_of_appointment_as_agent");
        dt_trnsfr.Columns.Add("Date_of_cessation_of_agency");
        dt_trnsfr.Columns.Add("Reason_for_cessation_of_agency");
        DataRow dr;
        foreach (GridViewRow row in gvTrnsfr.Rows)
        {
            dr = dt_trnsfr.NewRow();
            Label lblDate = (Label)row.FindControl("lblDate");
            Label lblCategory = (Label)row.FindControl("lblCategory");
            Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
            Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
            Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
            Label lblDateCessation = (Label)row.FindControl("lblDateCessation");
            Label lblReasonCessation = (Label)row.FindControl("lblReasonCessation");
            dr[0] = lblDate.Text;
            dr[1] = lblCategory.Text;
            dr[2] = lblNameInsurer.Text;
            dr[3] = lblAgencyCode.Text;
            dr[4] = lblDateAppointment.Text;
            dr[5] = lblDateCessation.Text;
            dr[6] = lblReasonCessation.Text;
            dt_trnsfr.Rows.Add(dr);
        }

        if (gvTrnsfr.Rows.Count <= 3)
        {
            dr = dt_trnsfr.NewRow();
            dr["Date"] = txtIC.Text;
            dr["Category"] = ddlCaTrnsfr.Text;
            dr["Name_of_Insurer"] = ddlNameInTrnsfr.Text;
            dr["Agency_code_Number"] = txtAgencyCodeTrnsfr.Text;
            dr["Date_of_appointment_as_agent"] = txtDateOfAppointmentTrnsfr.Text;
            dr["Date_of_cessation_of_agency"] = txtDateOfCessationTrnsfr.Text;
            dr["Reason_for_cessation_of_agency"] = txtReasonForCessationTrnsfr.Text;
            dt_trnsfr.Rows.Add(dr);
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);
        }

        hdnTransfer.Value = dt_trnsfr.Rows.Count.ToString();
        gvTrnsfr.DataSource = dt_trnsfr;
        gvTrnsfr.DataBind();
        Session["datatable"] = dt_trnsfr;
        string txt;
        ddlCaTrnsfr.SelectedIndex = 0;
        ddlStsTrnsfr.SelectedValue = "0";
        ddlNameInTrnsfr.SelectedIndex = 0;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funAddTr();", true);
        txtAgencyCodeTrnsfr.Text = "";
        txtDateOfAppointmentTrnsfr.Text = "";
        txtReasonForCessationTrnsfr.Text = "";
        txtDateOfCessationTrnsfr.Text = "";
        if (gvTrnsfr.Rows.Count > 0)
        {
            lblNoteIc.Visible = false;
        }
        else
        {
            tdNoteIc.Visible = true;
        }
    }
    DataTable dt_tag = new DataTable();
    protected void btnAddTag_Click(object sender, EventArgs e)
    {
        if (ddlTagCat.SelectedIndex == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlTagCat.Focus();
            return;
        }
        if (ddlTagIns.SelectedIndex == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of Insurer is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlTagIns.Focus();
            return;
        }
        if (txtTagAgn.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency Code is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            txtTagAgn.Focus();
            return;
        }
        if (txtTagURN.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('URN No. is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            txtTagURN.Focus();
            return;
        }
        if (txtTagApp.Text == "")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Appointment as agent is Mandatory for Tagged')", true);
            ProgressBarModalPopupExtender.Hide();
            txtTagApp.Focus();
            return;
        }





        dt_tag.Columns.Add("Category");
        dt_tag.Columns.Add("Name_of_Insurer");
        dt_tag.Columns.Add("Agency_code_Number");
        dt_tag.Columns.Add("URNNo");
        dt_tag.Columns.Add("Date_of_appointment_as_agent");
        dt_tag.Columns.Add("Status");
        DataRow dr;
        // int StatusFlag = 0;
        foreach (GridViewRow row in grdTag.Rows)
        {
            Label lblCategory = (Label)row.FindControl("lblCategory");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            if (ddlTagStatus.SelectedItem.Text == "Active" && lblStatus.Text == "Active" && ddlTagCat.SelectedItem.Text == lblCategory.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There can be only one Active record for each category.')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlTagStatus.Focus();
                return;

            }

        }

        foreach (GridViewRow row in grdTag.Rows)
        {
            dr = dt_tag.NewRow();
            Label lblCategory = (Label)row.FindControl("lblCategory");
            Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
            Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
            Label lblURNNo = (Label)row.FindControl("lblURNNo");
            Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            //if (ddlTagStatus.SelectedItem.Text == lblStatus.Text && ddlTagCat.SelectedItem.Text == lblCategory.Text)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not Repeat Same Active Status for Tagged')", true);
            //    ProgressBarModalPopupExtender.Hide();
            //    ddlTagStatus.Focus();
            //    return;
            //}
            dr[0] = lblCategory.Text;
            dr[1] = lblNameInsurer.Text;
            dr[2] = lblAgencyCode.Text;
            dr[3] = lblURNNo.Text;
            dr[4] = lblDateAppointment.Text;
            dr[5] = lblStatus.Text;


            dt_tag.Rows.Add(dr);

        }

        if (grdTag.Rows.Count <= 3)
        {
            //dt.Rows.Add(dr);
            dr = dt_tag.NewRow();
            dr["Category"] = ddlTagCat.SelectedItem.Text.ToString();
            dr["Name_of_Insurer"] = ddlTagIns.SelectedItem.Text.ToString();
            dr["Agency_code_Number"] = txtTagAgn.Text;
            dr["URNNo"] = txtTagURN.Text;
            dr["Date_of_appointment_as_agent"] = txtTagApp.Text;
            dr["Status"] = ddlTagStatus.SelectedItem.Text.ToString();
            dt_tag.Rows.Add(dr);
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);

        }

        hdnTag.Value = dt_tag.Rows.Count.ToString();
        grdTag.DataSource = dt_tag;
        grdTag.DataBind();
        //added by usha for calc
        //txtIC.Enabled = false;//added by amruta on 16.6.15
        //CalendarExtender28.Enabled = false;//added by amruta on 16.6.15
        Session["datatable"] = dt_tag;
        ddlTagIns.SelectedIndex = 0;
        ddlTagStatus.SelectedValue = "A";
        ddlTagCat.SelectedIndex = 0;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funAddTag();", true);
        txtTagURN.Text = "";
        txtTagAgn.Text = "";
        txtTagApp.Text = "";
        divCatFlag.Visible = true;
    }

    protected void grdTag_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt_tag = (DataTable)Session["datatable"];
        if (dt_tag.Rows.Count >= 0)
        {

            dt_tag.Rows.RemoveAt(Convert.ToInt16(e.RowIndex));
            grdTag.DataSource = dt_tag;
            grdTag.DataBind();
            hdnTag.Value = dt_tag.Rows.Count.ToString();

            //added by meena 8_5_18 start
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully')", true);
            ProgressBarModalPopupExtender.Hide();
            return;
            //added by meena 8_5_18 End
        }


        if (dt_tag.Rows.Count == 0)
        {
            divCatFlag.Visible = false;
            cbTccCompLcn.Enabled = false;
            cbTrfrFlag.Enabled = false;
            cbTagLcn.Enabled = true;
        }


    }
    //Ended By Nikhil 05..11.16

    //Added by Prathamesh Profiling function 2-7-15 start


    //Added By Prathamesh for Profiling data bind to the modification page 12-6-15
    protected void GetProfilingDtls()
    {
        PopulateAgentType();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        //ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for AgentType ddl 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlagntype.SelectedValue = ds.Tables[0].Rows[0]["AgntType"].ToString().Trim();

        }
    }

    //Remaining
    protected void GetRCAPcompany()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for RCAP company
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlIsWrkng.SelectedValue = ds.Tables[0].Rows[0]["IsWrkngInOthrRelnce"].ToString().Trim();

        }
    }

    protected void GetNoofyearsinInsurance()
    {
        YearsInInsurance();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added No of Years in insurance 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNoOfYrsIns.SelectedValue = ds.Tables[0].Rows[0]["YrsInInsrnce"].ToString().Trim();


        }
    }

    protected void GetDealerTypeOfVehicleDeal()
    {
        VechicleType();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        ////Added for If Dealer, type of vehicle dealing in
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeOfVehicle.SelectedValue = ds.Tables[0].Rows[0]["VhclType"].ToString().Trim();

        }
    }

    //Remaining
    protected void GetCompanyName()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Company Name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtDlrCompName.Text = ds.Tables[0].Rows[0]["DlrCompName"].ToString().Trim();

        }
    }

    protected void GetComapnynNameIfYes()
    {
        oCommon.getDropDown(ddlcompName, "CompyName", 1, "", 1);
        ddlcompName.Items.Insert(0, "Select");
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Company Name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlcompName.SelectedValue = ds.Tables[0].Rows[0]["CompName"].ToString().Trim();

        }

    }


    protected void GetFromOthersSpecify1()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for From Others Specify2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtOthers.Text = ds.Tables[0].Rows[0]["OthrAgnType"].ToString().Trim();

        }
    }

    protected void GetNoOfYearsWithReliance()
    {
        YearsInReliance();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for No. of years with reliance 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNoOfYrs.SelectedValue = ds.Tables[0].Rows[0]["YrsInRelnce"].ToString().Trim();

        }

    }

    protected void GetDealerVehicleManufacturerdealing()
    {
        VechicleManufacturer();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Dealer Vehicle Manufacturer dealing 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlVechManuf.SelectedValue = ds.Tables[0].Rows[0]["VhclManf"].ToString().Trim();

        }
    }


    protected void GetFromOthersSpecify2()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for From Others Specify2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtDlrOth.Text = ds.Tables[0].Rows[0]["DlrOthrCompName"].ToString().Trim();
        }
    }

    protected void GetAvgMonthlyVolumeinLacs()
    {
        AverageMonthlyIncome();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Avg Monthly Volume in Lacs
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAvgMonthlyIncm.SelectedValue = ds.Tables[0].Rows[0]["AvgMnthVol"].ToString().Trim();

        }
    }

    protected void GetCompany1name()
    {
        CompetitorCompanyName1();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Get Company1 name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlComp1Name.SelectedValue = ds.Tables[0].Rows[0]["Comp1Name"].ToString().Trim();

        }
    }

    protected void GetCompany2name()
    {
        CompetitorCompanyName2();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Get Company2  name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlComp2Name.SelectedValue = ds.Tables[0].Rows[0]["Comp2Name"].ToString().Trim();

        }
    }

    protected void GetMonthlyVolumeInLacsCompany1()
    {
        ComptCompyMonthlyVolum();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Monthly Volume In Lacs Company1
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMnthVol1.SelectedValue = ds.Tables[0].Rows[0]["MnthVolFrComp1"].ToString().Trim();

        }
    }

    protected void GetMonthlyVolumeInLacsCompany2()
    {
        ComptCompyMonthlyVolum2();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Monthly Volume In Lacs Company2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMnthVol2.SelectedValue = ds.Tables[0].Rows[0]["MnthVolFrComp2"].ToString().Trim();

        }
    }

    protected void GetMonthlyVolumeInLacsRGI()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            ht.Add("@CndNo", strProspectID);
        }
        else
        {
            ht.Add("@CndNo", txtcndid.Text.Trim());
        }
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIMnthVol.SelectedValue = ds.Tables[0].Rows[0]["RGIMnthVol"].ToString().Trim();

        }

    }

    protected void GetTotalBuisnessMotor()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnMtr.SelectedValue = ds.Tables[0].Rows[0]["TotBsnMtr"].ToString().Trim();
        }
    }

    protected void GetTotalBuisnessHealth()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnHlth.SelectedValue = ds.Tables[0].Rows[0]["TotBsnHlth"].ToString().Trim();

        }
    }

    protected void GetTotalBuisnessComercialLine()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnComm.SelectedValue = ds.Tables[0].Rows[0]["TotBsnCmrclLine"].ToString().Trim();

        }
    }

    protected void GetBusinessWithRGIMotor()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnMtr.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnMtr"].ToString().Trim();

        }
    }

    protected void GetBusinessWithRGIHealth()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Business With RGI Health
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnHlth.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnHlth"].ToString().Trim();

        }
    }

    protected void GetBusinessWithRGIComercialLine()
    {

        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", txtcndid.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Business With RGI Health
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnComm.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnCmrclLine"].ToString().Trim();

        }
    }
    //Added by Prathamesh Profiling function 2-7-15 end


    //#region verify aadhar no
    ////added by amruta on 23.9.16 for aadhar no verification start
    //protected void btnVerifyaadhar_Click(object sender, EventArgs e)
    //{
    //    string a = txtaadhr.Text;
    //    bool b = AadharNo.Aadhar.Check(a);
    //    if (b == true)
    //    {
    //        lblAadharMsg.Text = "Aadhaar No. is verified.";
    //        lblAadharMsg.ForeColor = Color.Green;
    //    }

    //    else
    //    {
    //        lblAadharMsg.Text = "Aadhaar No. is not valid.";
    //        lblAadharMsg.ForeColor = Color.Red;
    //    }

    //}
    ////added by amruta on 23.9.16  for aadhar no verification end
    //#endregion

    protected void btnmemgrid_Click(object sender, EventArgs e)
    {
        var htbl = new Hashtable();
        htbl.Add("@EmpCode", strUser);
        var ds = dataAccessRecruit.GetDataSetForPrcDBConn("prc_GetMember", htbl, "INSCCommonConnectionString");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmsg", "openBranchList('" + ds.Tables[0].Rows[0]["BizSrc"].ToString() + "','" + ds.Tables[0].Rows[0]["ChnCls"].ToString() + "','" + ds.Tables[0].Rows[0]["AgentType"].ToString() + "','" + ds.Tables[0].Rows[0]["MgrCode"].ToString() + "','" + ds.Tables[0].Rows[0]["Type"].ToString() + "','" + ds.Tables[0].Rows[0]["IsAgt"].ToString() + "','" + ds.Tables[0].Rows[0]["agttype"].ToString() + "');", true);
        }
    }

    protected void btnunitgrid_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)Session["unt"];
        txtImmLeader.Text = dt.Rows[0]["UnitDesc01"].ToString() + " (" + dt.Rows[0]["UnitCode"].ToString() + ") ";
        ViewState["BranchCodeD"] = dt.Rows[0]["UnitDesc01"].ToString() + " (" + dt.Rows[0]["UnitCode"].ToString() + ") ";

    }

    #region ddlCaTrnsfr_OnSelectedIndexChanged
    protected void ddlCaTrnsfr_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //htparams.Clear();
        //htparams.Add("", ddlCaTrnsfr.SelectedValue.ToString());

        NameInsurance(ddlNameInTrnsfr, ddlCaTrnsfr.SelectedValue.ToString());



    }
    #endregion
    //meena 29_1_18 start
    protected void btnstatesearch_Click(object sender, EventArgs e)
    {
        string popuptyp = "statedemo";
        string btnid = "btnstatesearch";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcShowPopup('" + popuptyp + "','" + btnid + "');", true);


    }
    protected void btnstate1search_Click(object sender, EventArgs e)
    {
        string popuptyp = "statedemo1";
        string btnid = "btnstate1search";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcShowPopup('" + popuptyp + "','" + btnid + "');", true);


    }
    protected void BtnPermanentPincode_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)Session["Address"];
        txtpermDistrict.Text = dt.Rows[0]["District"].ToString();
        txtcity1.Text = dt.Rows[0]["City"].ToString();
        txtarea1.Text = dt.Rows[0]["Area"].ToString();
        txtPermPostcode.Text = dt.Rows[0]["Pincode"].ToString();
        txtPermCountryCode.Text = "IND";
        txtPermCountryCode.Enabled = false;
        txtPermCountryDesc.Text = "INDIAN";
        txtPermCountryDesc.Enabled = false;
    }

    protected void Btnpincode_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)Session["Address"];
        txtDistric.Text = dt.Rows[0]["District"].ToString();
        txtcity.Text = dt.Rows[0]["City"].ToString();
        txtarea.Text = dt.Rows[0]["Area"].ToString();
        txtPinP.Text = dt.Rows[0]["Pincode"].ToString();
    }

    //meena 29_1_18 End

    protected void ChkPA_CheckedChanged(object sender, EventArgs e)
    {

        if (ChkPA.Checked == true)
        {
            if (ddlCnctType.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Address Type')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlCnctType.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtAddrP1.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter AddressLine-1')", true);
                ProgressBarModalPopupExtender.Hide();
                txtAddrP1.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtAddrP2.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter AddressLine-2')", true);
                ProgressBarModalPopupExtender.Hide();
                txtAddrP2.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtAddrP3.Text == "")
            {
                txtPermAdd1.Text = "";
                txtPermAdd3.Text = "";
                txtPermAdd2.Text = "";
                ddlstate1.SelectedIndex = 0;
                txtpermvillage.Text = "";
                txtpermDistrict.Text = "";
                txtcity1.Text = "";
                txtarea1.Text = "";
                txtPermPostcode.Text = "";
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter AddressLine-3')", true);
                ProgressBarModalPopupExtender.Hide();
                txtAddrP3.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (ddlcategory.SelectedIndex == 2)
            {
                if (txtVillage.Text == "")
                {
                    txtPermAdd1.Text = "";
                    txtPermAdd3.Text = "";
                    txtPermAdd2.Text = "";
                    ddlstate1.SelectedIndex = 0;
                    txtpermvillage.Text = "";
                    txtpermDistrict.Text = "";
                    txtcity1.Text = "";
                    txtarea1.Text = "";
                    txtPermPostcode.Text = "";
                    MultiView1.ActiveViewIndex = 0;
                    lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                    lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Village')", true);
                    ProgressBarModalPopupExtender.Hide();
                    txtVillage.Focus();
                    ChkPA.Checked = false;
                    return;
                }
            }

            if (ddlState.SelectedIndex == 0)
            {
                txtPermAdd1.Text = "";
                txtPermAdd3.Text = "";
                txtPermAdd2.Text = "";
                ddlstate1.SelectedIndex = 0;
                txtpermvillage.Text = "";
                txtpermDistrict.Text = "";
                txtcity1.Text = "";
                txtarea1.Text = "";
                txtPermPostcode.Text = "";
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Address State')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlState.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtDistric.Text == "")
            {
                txtPermAdd1.Text = "";
                txtPermAdd3.Text = "";
                txtPermAdd2.Text = "";
                ddlstate1.SelectedIndex = 0;
                txtpermvillage.Text = "";
                txtpermDistrict.Text = "";
                txtcity1.Text = "";
                txtarea1.Text = "";
                txtPermPostcode.Text = "";
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Address District')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDistric.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtcity.Text == "")
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Address City')", true);
                ProgressBarModalPopupExtender.Hide();
                txtcity.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtarea.Text == "")
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Address Area')", true);
                ProgressBarModalPopupExtender.Hide();
                txtarea.Focus();
                ChkPA.Checked = false;
                return;
            }

            if (txtPinP.Text == "")
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Present Address PinNo')", true);
                ProgressBarModalPopupExtender.Hide();
                txtPinP.Focus();
                ChkPA.Checked = false;
                return;
            }
            txtPermAdd1.Text = txtAddrP1.Text;
            txtPermAdd2.Text = txtAddrP2.Text;
            txtPermAdd3.Text = txtAddrP3.Text;
            txtpermvillage.Text = txtVillage.Text;
            txtPermCountryCode.Text = txtCountryCodeP.Text;
            txtPermCountryDesc.Text = txtCountryDescP.Text;
            ddlstate1.Text = ddlState.Text;
            txtpermDistrict.Text = txtDistric.Text;
            txtcity1.Text = txtcity.Text;
            txtarea1.Text = txtarea.Text;
            txtPermPostcode.Text = txtPinP.Text;
            txtPermAdd1.Enabled = false;
            txtPermAdd2.Enabled = false;
            txtPermAdd3.Enabled = false;
            txtpermvillage.Enabled = false;
            txtpermDistrict.Enabled = false;
            ddlstate1.Enabled = false;
            txtcity1.Enabled = false;
            txtarea1.Enabled = false;
            txtPermPostcode.Enabled = false;
            btnstate1search.Enabled = false;

        }
        else
        {
            txtPermAdd1.Text = "";
            txtPermAdd2.Text = "";
            txtPermAdd3.Text = "";
            txtpermvillage.Text = "";
            txtPermCountryCode.Text = "";
            txtPermCountryDesc.Text = "";
            ddlstate1.SelectedIndex = 0;
            txtpermDistrict.Text = "";
            txtcity1.Text = "";
            txtarea1.Text = "";
            txtPermPostcode.Text = "";
            txtPermAdd1.Enabled = true;
            txtPermAdd2.Enabled = true;
            txtPermAdd3.Enabled = true;
            txtpermvillage.Enabled = true;
            txtpermDistrict.Enabled = true;
            ddlstate1.Enabled = true;
            txtcity1.Enabled = true;
            txtarea1.Enabled = true;
            txtPermPostcode.Enabled = true;
            btnstate1search.Enabled = true;


        }

    }
    protected void cbFrshFlag_CheckedChanged(object sender, EventArgs e)
    {
        if (cbFrshFlag.Checked == true)
        {
            cbTrfrFlag.Checked = false;
            cbTagLcn.Checked = false;
            divTrnsferDetails.Visible = false;
            divTagDtls.Visible = false;
            divTagged.Visible = false;
        }
    }
    private void FillAgentProfile(DropDownList DropDownname, String AgnTypCode)
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@AgnTypCode", AgnTypCode.ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAgentMasterValue", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                DropDownname.DataSource = dsResult;
                DropDownname.DataTextField = "AgntDesc01";
                DropDownname.DataValueField = "value";
                DropDownname.DataBind();
                DropDownname.Items.Insert(0, "Select");
                //DropDownname.Items.Add(new ListItem("Select", "0", true));
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Branch not available on master')", true);
            return;
        }




    }

    #region 'FillddlAddRptMgrCode'
    private void FillddlAddRptMgrCode()
    {
        try
        {
            ddlAddRptMgrCode.Items.Clear();

            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@MemberCode", MemberCode);
            htParam.Add("@MemberType", MemberType);

            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAddRptMgrCodeDtls", htParam);
            LblRptMgrCode.Text = Convert.ToString(dsresult.Tables[0].Rows[0]["col"]).Trim();
            if (MemberType == "FP")
            {
                LblRptMgrCode.Text = LblRptMgrCode.Text + "<span style=' color:#ff0000'>*</span>";
            }
            if (dsresult.Tables[1].Rows.Count > 0)
            {

                ddlAddRptMgrCode.DataSource = dsresult.Tables[1];
                ddlAddRptMgrCode.DataTextField = "Desc01";
                ddlAddRptMgrCode.DataValueField = "value";
                ddlAddRptMgrCode.DataBind();
                ddlAddRptMgrCode.Items.Insert(0, new ListItem("--Select--", ""));

                //if (dsresult.Tables[1].Rows.Count == 1)
                //{ 
                //// ddlAddRptMgrCode.SelectedValue=dsresult.Tables[1].Rows[0]["value"].ToString().Trim();
                //// ddlAddRptMgrCode.Enabled=false;
                //}
                dsresult = null;

            }
            else
            {
                ddlAddRptMgrCode.Items.Insert(0, new ListItem("--Select--", ""));
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

    //added by ajay yadav next and previous button events START

    protected void btnNextPannel1_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["strClear"] = "1";
            //ConvertRDLCToPDF("20001208");
            #region visibility
            divpanel3.Visible = false;
            btnNextPannel1.Visible = false;
            divPannel1.Visible = true;
            btnNextPannel2.Visible = true;
            btnPrev1.Visible = true;
            divRDH.Attributes.Add("style", "color:#8c8c8c !important;");
            span3.Attributes.Add("style", "background-color: #8c8c8c !important");
            span3.Attributes.Add("style", "background-color: #8c8c8c !important");
            divPDH.Attributes.Add("style", "color:#00cccc !important;");
            span1.Attributes.Add("style", "background-color: #00cccc !important");
            span1.Attributes.Add("style", "background-color: #00cccc !important");
            #endregion

            #region visibilty of composite or transfer
            if (ddlCandidatetype.SelectedValue == "C")
            {
                #region composite segment show start 03-10-2022
                divComp.Visible = true;
                divCompDtls.Visible = true;
                divCompositeDetails.Visible = true;
                #endregion composite segment show end 03-10-2022

                #region Transfer segment hide start 03-10-2022
                divTrans.Visible = false;
                trCompTitle.Visible = false;
                trNote.Visible = true;
                trNoteTr.Visible = false;
                lblIC.Visible = false;
                txtIC.Visible = false;
                txtIC.Enabled = false;
                ddlCaTrnsfr.Enabled = false;
                ddlNameInTrnsfr.Enabled = false;
                txtAgencyCodeTrnsfr.Enabled = false;
                txtDateOfAppointmentTrnsfr.Enabled = false;
                ddlStsTrnsfr.Enabled = false;
                txtDateOfCessationTrnsfr.Enabled = false;
                txtReasonForCessationTrnsfr.Enabled = false;
                divTrnsferDetails.Visible = false;
                #endregion composite segment hide end 03-10-2022
            }
            else if (ddlCandidatetype.SelectedValue == "T")
            {
                #region Transfer segment show start 03-10-2022
                divTrans.Visible = true;
                trCompTitle.Visible = false;
                trNote.Visible = false;
                trNoteTr.Visible = true;
                lblIC.Visible = true;
                txtIC.Visible = true;
                txtIC.Enabled = true;
                ddlCaTrnsfr.Enabled = true;
                ddlNameInTrnsfr.Enabled = true;
                txtAgencyCodeTrnsfr.Enabled = true;
                txtDateOfAppointmentTrnsfr.Enabled = true;
                ddlStsTrnsfr.Enabled = true;
                txtDateOfCessationTrnsfr.Enabled = true;
                txtReasonForCessationTrnsfr.Enabled = true;
                divTrnsferDetails.Visible = true;
                #endregion composite segment hide end 03-10-2022

                #region composite segment hide start 03-10-2022
                divComp.Visible = false;
                divCompDtls.Visible = false;
                divCompositeDetails.Visible = false;
                #endregion Transfer segment show start 03-10-2022
            }
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

    protected void btnNextPannel2_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "2";
        #region Validation
        if (cboTitle.SelectedIndex == 0)
        {

            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Prefix')", true);
            ProgressBarModalPopupExtender.Hide();
            cboTitle.Focus();
            return;
        }

        if (txtGivenName.Text == "")
        {

            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter First Name')", true);
            ProgressBarModalPopupExtender.Hide();
            txtGivenName.Focus();
            return;

        }
        if (txtsurname.Text == "")
        {

            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Surname')", true);
            ProgressBarModalPopupExtender.Hide();
            txtsurname.Focus();
            return;

        }
        if (txtCurrentID.Text == "")
        {
            lblPANMsg.Text = "";
            hdnPan.Value = "0";
            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Pan No')", true);
            //ProgressBarModalPopupExtender.Hide();
            txtCurrentID.Focus();
            return;
        }


        if (cboTitle.SelectedValue != "M/S")
        {
            if (txtDOB.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Date Of Birth')", true);
                ProgressBarModalPopupExtender.Hide();
                txtDOB.Focus();
                return;
            }
        }




        if (cboTitle.SelectedValue != "M/S")
        {
            if (cboGender.SelectedIndex == 0)
            {
                ProgressBarModalPopupExtender.Hide();
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Gender')", true);
                cboGender.Focus();
                return;
            }

            if ((cboGender.SelectedIndex == 1 && cboTitle.SelectedIndex == 1) ||
                (cboGender.SelectedIndex == 2 && cboTitle.SelectedIndex == 2) ||
                (cboGender.SelectedIndex == 2 && cboTitle.SelectedIndex == 3))
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert( 'Plese Select Valid Gender')", true);
                ProgressBarModalPopupExtender.Hide();
                txtFathername.Focus();
                return;
            }

        }


        if (cboTitle.SelectedValue != "M/S")
        {
            if (txtFathername.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Father/Spouse Name')", true);
                ProgressBarModalPopupExtender.Hide();
                txtFathername.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (ddlRelwithFather.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Relationship with Agent')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlRelwithFather.Focus();
                return;
            }
        }

        if (cboTitle.SelectedValue != "M/S")
        {
            if (ddlCasteCat.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Category')", true);
                ddlCasteCat.Focus();
                return;
            }
        }


        if (ddlPrimProf.SelectedIndex == 0)
        {
            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Current Occupation')", true);
            ddlPrimProf.Focus();
            return;
        }

        if (ddlcategory.SelectedIndex == 0)
        {
            if (txtVillage.Text == "")
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Candidate Classification')", true);
                ProgressBarModalPopupExtender.Hide();
                txtVillage.Focus();
                return;
            }
        }
        if (cboTitle.SelectedValue != "M/S")
        {
            if (cboMaritalStatus.SelectedIndex == 0)
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Marital Status')", true);
                ProgressBarModalPopupExtender.Hide();
                cboMaritalStatus.Focus();
                return;
            }
        }

        if (ddlCandidatetype.SelectedIndex == 0)
        {

            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Candidate Type')", true);
            ProgressBarModalPopupExtender.Hide();
            ddlCandidatetype.Focus();
            return;
        }
        #endregion

        #region saving functionality
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            ArrayList arrResult = new ArrayList();
            string sessionuser = "";
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@Appno", strProspectID);
            }
            else
            {
                if (ViewState["ProspectId"] == null)
                {
                    htParam.Add("@Appno", System.DBNull.Value);
                }
                else
                {
                    htParam.Add("@Appno", ViewState["ProspectId"].ToString().Trim());
                }
            }
            htParam.Add("@CndCat", ddlcategory.SelectedValue.Trim());
            htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
            if (txtregdate.Text.Trim() != "")
            {
                htParam.Add("@EntryDate", DateTime.Parse(txtregdate.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EntryDate ", System.DBNull.Value);
            }
            htParam.Add("@CreateBy", sessionuser);
            htParam.Add("@PANNo", txtCurrentID.Text.Trim());
            htParam.Add("@Title", cboTitle.SelectedValue.ToString());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtsurname.Text.Trim());
            htParam.Add("@FatherName", txtFathername.Text.Trim());
            htParam.Add("@Relation", ddlRelwithFather.SelectedValue.Trim());
            htParam.Add("@Gender", cboGender.SelectedValue.Trim());
            if (txtDOB.Text.Trim() != "")
            {
                htParam.Add("@BirthRegDate", DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@BirthRegDate ", System.DBNull.Value);
            }
            htParam.Add("@MaritalStat", cboMaritalStatus.SelectedValue.Trim());
            htParam.Add("@Nationality", txtNationalCode.Text.Trim());
            htParam.Add("@CasteCat", ddlCasteCat.SelectedValue.ToString().Trim());
            htParam.Add("@PrimProf", ddlPrimProf.SelectedValue.ToString().Trim());
            if (ddlFessWav.SelectedValue == "Y")
            {
                htParam.Add("@AutoWavierFlag", "Y");
                htParam.Add("@AutoWavierFlagBy", "System");
            }
            else
            {
                htParam.Add("@AutoWavierFlag", "NA");
            }
            if (ddlCandidatetype.SelectedValue != "Select")
            {
                htParam.Add("@CandType", ddlCandidatetype.SelectedValue);
            }
            else
            {
                htParam.Add("@CandType", System.DBNull.Value);
            }
            if (TxtAnnivrsryDt.Text.Trim() != "")
            {
                htParam.Add("@AnnivrsryDt", DateTime.Parse(TxtAnnivrsryDt.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            else
            {
                htParam.Add("@AnnivrsryDt", System.DBNull.Value);
            }
            htParam.Add("@RecruitEmpCode", txtEmpCode.Text);
            htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue.Trim());
            htParam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
            htParam.Add("@RecruitUnitCode", ViewState["cmsunitcode"].ToString().Trim());
            htParam.Add("@RecruitAgtName", txtDirectAgtName.Text.Trim());
            htParam.Add("@AgentType", ddlAgnTypes.Text.Trim());
            htParam.Add("@RecruitAgtCode", txtrecagent.Text.Trim());
            htParam.Add("@CndAgtType", Convert.ToString(ddlCandType.SelectedValue).Trim());
            htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
            if (ViewState["ProspectId"] == null || Request.QueryString["ACT"] == "PR")
            {
                arrResult = clsCndReg.InsertAgentDetailsFirst(htParam, "Prc_Ins_CndAdmin");
                ViewState["ProspectId"] = arrResult[2];
                txtapplicationno.Text = ViewState["ProspectId"].ToString().Trim();
                htParam.Clear();
                #region
                if (ddlCandidatetype.SelectedValue == "C" || ddlCandidatetype.SelectedValue == "T")
                {
                    BindGrid("", txtapplicationno.Text);
                }
                #endregion
            }
        }
        #endregion

        if (Request.QueryString["Type"] == "N")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Application Number : " + txtapplicationno.Text + "')", true);
        }

        #region visibility
        divPannel1.Visible = false;
        btnNextPannel2.Visible = false;
        btnPrev1.Visible = false;
        divTrnsferDetails.Visible = false;
        divComp.Visible = false;
        divPannel2.Visible = true;
        btnNextPannel3.Visible = true;
        btnPrev2.Visible = true;
        divPDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span1.Attributes.Add("style", "background-color: #8c8c8c !important");
        span1.Attributes.Add("style", "background-color: #8c8c8c !important");
        divCDH.Attributes.Add("style", "color:#00cccc !important;");
        span2.Attributes.Add("style", "background-color: #00cccc !important");
        span2.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion

        FillProspectInfo();
    }

    protected void btnNextPannel3_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "3";
        if (txtemail.Text == "")
        {

            MultiView1.ActiveViewIndex = 0;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Email1')", true);
            ProgressBarModalPopupExtender.Hide();
            txtemail.Focus();
            return;
        }


        if (txtemail.Text != "")
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MultiView1.ActiveViewIndex = 0;

                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Email1');</script>", false);
                ProgressBarModalPopupExtender.Hide();
                txtemail.Focus();
                return;
            }


        }

        if (txtEmail2.Text != "")
        {
            string email = txtEmail2.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MultiView1.ActiveViewIndex = 0;

                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Email2');</script>", false);
                ProgressBarModalPopupExtender.Hide();
                txtEmail2.Focus();
                return;
            }


        }
        #region Contact Details Saving
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            ArrayList arrResult = new ArrayList();
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@ProspectId", strProspectID);
            }
            else
            {
                htParam.Add("@ProspectId", ViewState["ProspectId"].ToString().Trim());
            }
            htParam.Add("@DstbnMethod", ddlDstbnMethod.SelectedValue);
            htParam.Add("@HomeTel", txthometel.Text.Trim());
            htParam.Add("@MobileTel", txtMobileTel.Text.Trim());
            htParam.Add("@mobile2", txtMobile2.Text.Trim());
            htParam.Add("@Email2", txtEmail2.Text.Trim());
            htParam.Add("@Email", txtemail.Text.Trim());
            htParam.Add("@WorkTel", txtWorkTel.Text.Trim());
            arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_Upd_CndAdmin");
            htParam.Clear();
        }
        #endregion

        #region visibility
        divPannel2.Visible = false;
        btnNextPannel3.Visible = false;
        btnPrev2.Visible = false;
        divpanel4.Visible = true;
        btnNextPannel4.Visible = true;
        btnPrev3.Visible = true;
        divCDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span2.Attributes.Add("style", "background-color: #8c8c8c !important");
        span2.Attributes.Add("style", "background-color: #8c8c8c !important");
        divPAH.Attributes.Add("style", "color:#00cccc !important;");
        span4.Attributes.Add("style", "background-color: #00cccc !important");
        span4.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion
    }

    protected void btnNextPannel4_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "4";

        #region Saving functionality
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            ArrayList arrResult = new ArrayList();
            string sessionuser = "";
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@ProspectId", strProspectID);
            }
            else
            {
                htParam.Add("@ProspectId", ViewState["ProspectId"].ToString().Trim());
            }
            htParam.Add("@CnctType", ddlCnctType.SelectedValue.Trim());
            htParam.Add("@Adr2", txtAddrP2.Text.Trim());
            htParam.Add("@Adr3", txtAddrP3.Text.Trim());
            htParam.Add("@Adr1", txtAddrP1.Text.Trim());
            htParam.Add("@StateCode", ddlState.SelectedValue.Trim());
            htParam.Add("@CntryCode", txtCountryCodeP.Text.Trim());
            htParam.Add("@City", txtcity.Text.Trim());
            htParam.Add("@Area", txtarea.Text.Trim());
            htParam.Add("@District", txtDistric.Text.Trim());
            htParam.Add("@PostCode", txtPinP.Text.Trim());
            htParam.Add("@Village", txtVillage.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);
            #region permanent
            if (ChkPA.Checked == true)
            {
                //htParam.Add("@PermAdrInd", "Y");
                //htParam.Add("@PermAdr1", txtPermAdd1.Text.Trim());
                //htParam.Add("@PermAdr2", txtPermAdd2.Text.Trim());
                //htParam.Add("@PermAdr3", txtPermAdd3.Text.Trim());
                //htParam.Add("@PermVillage", txtpermvillage.Text.Trim());
                //htParam.Add("@PermStateCode", ddlstate1.SelectedValue.Trim());
                //htParam.Add("@PermCntryCode", txtPermCountryCode.Text.Trim());
                //htParam.Add("@PermCity", txtcity1.Text.Trim());
                //htParam.Add("@PermArea", txtarea1.Text.Trim());
                //htParam.Add("@PermDistrict", txtpermDistrict.Text.Trim());
                //htParam.Add("@PermPostCode", txtPermPostcode.Text.Trim());
                //htParam.Add("@PermAdrInd", System.DBNull.Value);
                //htParam.Add("@PermAdr1", System.DBNull.Value);
                //htParam.Add("@PermAdr2", System.DBNull.Value);
                //htParam.Add("@PermAdr3", System. DBNull.Value);
                //htParam.Add("@PermVillage", System.DBNull.Value);
                //htParam.Add("@PermStateCode", System.DBNull.Value);
                //htParam.Add("@PermCntryCode", System.DBNull.Value);
                //htParam.Add("@PermCity", System.DBNull.Value);
                //htParam.Add("@PermArea", System.DBNull.Value);
                //htParam.Add("@PermDistrict", System.DBNull.Value);
                //htParam.Add("@PermPostCode", System.DBNull.Value);
            }
            else
            {
                //htParam.Add("@PermAdrInd", "N");
                //htParam.Add("@PermAdr1", txtPermAdd1.Text.Trim());
                //htParam.Add("@PermAdr2", txtPermAdd2.Text.Trim());
                //htParam.Add("@PermAdr3", txtPermAdd3.Text.Trim());
                //htParam.Add("@PermVillage", txtpermvillage.Text.Trim());
                //htParam.Add("@PermStateCode", ddlstate1.SelectedValue.Trim());
                //htParam.Add("@PermCntryCode", txtPermCountryCode.Text.Trim());
                //htParam.Add("@PermCity", txtcity1.Text.Trim());
                //htParam.Add("@PermArea", txtarea1.Text.Trim());
                //htParam.Add("@PermDistrict", txtpermDistrict.Text.Trim());
                //htParam.Add("@PermPostCode", txtPermPostcode.Text.Trim());
            }
            #endregion
            arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_Ins_Permanentadd");
            htParam.Clear();
        }
        #endregion

        #region Visibility
        divpanel4.Visible = false;
        btnNextPannel4.Visible = false;
        btnPrev3.Visible = false;
        divpanel5.Visible = true;
        btnNextPannel5.Visible = true;
        btnPrev4.Visible = true;
        divPAH.Attributes.Add("style", "color:#8c8c8c !important;");
        span4.Attributes.Add("style", "background-color: #8c8c8c !important");
        span4.Attributes.Add("style", "background-color: #8c8c8c !important");
        divBDH.Attributes.Add("style", "color:#00cccc !important;");
        span5.Attributes.Add("style", "background-color: #00cccc !important");
        span5.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion
    }

    protected void btnNextPannel5_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "5";
        #region Saving
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            string sessionuser = "";
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            ArrayList arrResult = new ArrayList();
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@ProspectId", strProspectID);
            }
            else
            {
                htParam.Add("@ProspectId", ViewState["ProspectId"].ToString().Trim());
            }
            htParam.Add("@AccholdrName", txtbnkhldname.Text.Trim().ToUpper());
            htParam.Add("@AccntNo", txtbnkacno.Text.Trim().ToUpper());
            htParam.Add("@BnkName", txtbnkname.SelectedValue);
            htParam.Add("@BrnchName", txtbrnchname.Text.ToString().Trim());
            htParam.Add("@AccType", ddlactype.Text.Trim());
            htParam.Add("@IFSC", txtifsccode.Text.Trim());
            htParam.Add("@MCR", txtmicrcode.Text.Trim());
            htParam.Add("@GSTNO", txtGSTNO.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);
            htParam.Add("@Bdfor", "C");
            arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_Ins_TblBankDtls");
            htParam.Clear();
        }
        #endregion

        #region Visibility
        divpanel5.Visible = false;
        btnNextPannel5.Visible = false;
        divpanel6.Visible = true;
        btnNextPannel6.Visible = true;
        btnPrev5.Visible = true;
        btnPrev4.Visible = false;
        divNDH.Attributes.Add("style", "color:#00cccc !important;");
        span6.Attributes.Add("style", "background-color: #00cccc !important");
        span6.Attributes.Add("style", "background-color: #00cccc !important");
        divBDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span5.Attributes.Add("style", "background-color: #8c8c8c !important");
        span5.Attributes.Add("style", "background-color: #8c8c8c !important");
        #endregion
    }

    protected void btnNextPannel6_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "6";

        if (txtNomneeEmail.Text != "")
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MultiView1.ActiveViewIndex = 0;

                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Valid Nominee Email');</script>", false);
                ProgressBarModalPopupExtender.Hide();
                txtNomneeEmail.Focus();
                return;
            }


        }

        if (txtNominMob.Text != "")
        {
            if ((txtNominMob.Text.Length != 10) || (txtNominMob.Text.Substring(0, 1) == "0")) //|| ((txtNominMob.Text.Substring(0, 1) != "9") && (txtNominMob.Text.Substring(0, 1) != "8") && (txtNominMob.Text.Substring(0, 1) != "7")))
            {

                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Nominee Mobile No.')", true);
                ProgressBarModalPopupExtender.Hide();
                txtNominMob.Focus();
                return;
            }
            if ((txtNominMob.Text.Substring(0, 1) == "1") || (txtNominMob.Text.Substring(0, 1) == "2") || (txtNominMob.Text.Substring(0, 1) == "3")
                || (txtNominMob.Text.Substring(0, 1) == "4") || (txtNominMob.Text.Substring(0, 1) == "5")) //|| ((txtNominMob.Text.Substring(0, 1) != "9") && (txtNominMob.Text.Substring(0, 1) != "8") && (txtNominMob.Text.Substring(0, 1) != "7")))
            {
                MultiView1.ActiveViewIndex = 0;
                lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
                lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Nominee Mobile No Should Start With (6,7,8,9)')", true);
                ProgressBarModalPopupExtender.Hide();
                txtNominMob.Focus();
                return;
            }
        }
        if (txtNomnPan.Text != "")
        {
            string pan = txtNomnPan.Text;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CheckPANFormat(" + pan + "');", true);
        }

        #region Nominee Details Saving
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            ArrayList arrResult = new ArrayList();
            string sessionuser = "";
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@CndNo1", strProspectID);
            }
            else
            {
                htParam.Add("@CndNo1", ViewState["ProspectId"].ToString().Trim());
            }
            htParam.Add("@NomineeName", txtNominee.Text);
            htParam.Add("@AdvRelation", Ddlrelation.SelectedValue.Trim());
            htParam.Add("@NomineeAge", txtNomineeAge.Text);
            htParam.Add("@NomineeEmailID", txtNomneeEmail.Text);
            htParam.Add("@NomineeMobileTel", txtNominMob.Text);
            htParam.Add("@NomineePAN", txtNomnPan.Text);
            htParam.Add("@AccntNo", txtnmbnkacno.Text.Trim().ToUpper());
            htParam.Add("@AccType", ddlactype.Text.Trim());
            htParam.Add("@BrnchName", ddlnmBrnchname.SelectedValue.ToString().Trim());
            htParam.Add("@IFSC", ddlnmifscode.Text.Trim());
            htParam.Add("@MCR", txtnmmicr.Text.Trim());
            htParam.Add("@AcHolderName", ddlnmbnkhldname.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);
            htParam.Add("@BankName", ddlnmBnkname.SelectedValue.ToString().Trim());
            arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_Ins_NomineeDetails");
            htParam.Clear();
            btnExmCentre.Attributes.Add("onclick", "funcShowPopup2('ExmCentre');return false;");
        }
        #endregion

        #region visiblility
        if(  ddlCandidatetype.SelectedValue == "T")
        {
            ddlExam.Enabled = false;
                ddlpreeamlng.Enabled = false;
                btnExmCentre.Enabled = false;
            ddlExmBody.Enabled = false;
            txtPreDate.Enabled = false;
        }
        else
        {
            ddlExam.Enabled = true;
            ddlpreeamlng.Enabled = true;
            btnExmCentre.Enabled = true;
            ddlExmBody.Enabled = true;
            txtPreDate.Enabled = true;
        }
        divpanel6.Visible = false;
        btnNextPannel6.Visible = false;
        divpanel7.Visible = true;
        btnNextPannel7.Visible = true;
        btnPrev6.Visible = true;
        btnPrev5.Visible = false;
        btnPrev6.Enabled = true;
        divNDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span6.Attributes.Add("style", "background-color: #8c8c8c !important");
        span6.Attributes.Add("style", "background-color: #8c8c8c !important");
        divEEDH.Attributes.Add("style", "color:#00cccc !important;");
        span7.Attributes.Add("style", "background-color: #00cccc !important");
        span7.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion
    }

    protected void btnNextPannel7_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "7";
        if (ddlCandidatetype.SelectedValue != "T")
        {
            if (ddlExam.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Mode')", true);
                ddlExam.Focus();
                return;
            }

            if (ddlpreeamlng.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Prefer Exam Language')", true);
                ddlpreeamlng.Focus();
                return;
            }

            if (txtExmCentre.Text == "")
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Center')", true);
                txtExmCentre.Focus();
                return;

            }

            if (ddlExmBody.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Examination body')", true);
                ddlExmBody.Focus();
                return;
            }

            if (txtPreDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Preferred Date')", true);
                txtPreDate.Focus();
                return;
            }
        }
        #region Education and exam details save
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            ArrayList arrResult = new ArrayList();
            string sessionuser = "";
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                strProspectID = Request.QueryString["ProspectId"].ToString();
                htParam.Add("@CndNo1", strProspectID);
            }
            else
            {
                htParam.Add("@CndNo1", ViewState["ProspectId"].ToString().Trim());
            }
            htParam.Add("@BasicQual", ddlBasicQual.SelectedValue.ToString().Trim());
            htParam.Add("@BasicBoardName", txtBoardName.Text);
            htParam.Add("@BasicRNo", txtBasicRNo.Text);
            htParam.Add("@BasicYrPass", Convert.ToDateTime(txtYrPass.Text));
            htParam.Add("@ProofIDDoc", ddleducationproof.SelectedValue.ToString().Trim());
            if (ddlExam.SelectedIndex !=0)
            {
                htParam.Add("@ExamMode", ddlExam.SelectedValue.ToString().Trim());
            }
            else
            {
                htParam.Add("@ExamMode", System.DBNull.Value);
            }

            if (ddlpreeamlng.SelectedIndex != 0)
            {
                htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue.ToString().Trim());
            }
            else
            {
                htParam.Add("@ExmLang", System.DBNull.Value);
            }

            if (txtExmCentre.Text!="")
            {
                htParam.Add("@ExmCentre", txtExmCentre.Text);
            }
            else
            {
                htParam.Add("@ExmCentre", System.DBNull.Value);
            }

            if (ddlExmBody.SelectedIndex !=0)
            {
                htParam.Add("@ExmBody", ddlExmBody.SelectedValue.ToString().Trim());
            }
            else
            {
                htParam.Add("@ExmBody", System.DBNull.Value);
            }

            if (txtPreDate.Text != "")
            {
                htParam.Add("@PreffExmDt1", Convert.ToDateTime(txtPreDate.Text));
            }
            else
            {
                htParam.Add("@PreffExmDt1", System.DBNull.Value);
            }
        
            
            
            
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CreateBy", sessionuser);
            arrResult = clsCndReg.InsertAgentDetails_UpdateprospectDetails(htParam, "Prc_Ins_PodEd");
            htParam.Clear();
        }
        #endregion

        #region Visibility 
        divpanel7.Visible = false;
        btnNextPannel7.Visible = false;
        btnPrev6.Visible = false;
        divEEDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span7.Attributes.Add("style", "background-color: #8c8c8c !important");
        span7.Attributes.Add("style", "background-color: #8c8c8c !important");
        divPH.Attributes.Add("style", "color:#00cccc !important;");
        span8.Attributes.Add("style", "background-color: #00cccc !important");
        span8.Attributes.Add("style", "background-color: #00cccc !important");
        btnPrev7.Enabled = true;
        divpanel8.Visible = true;
        btnPrev7.Visible = true;
        btnNextPannel8.Visible = true;
        #endregion

        #region docupload

        //divpanel9.Visible = true;
        //btnPrev7.Enabled = false;
        //btnNextPannel8.Visible = false;
        //divpanel8.Visible = false;
        //divPH.Attributes.Add("style", "color:#8c8c8c !important;");
        //span8.Attributes.Add("style", "background-color: #8c8c8c !important");
        //span8.Attributes.Add("style", "background-color: #8c8c8c !important");
        //divDUH.Attributes.Add("style", "color:#00cccc !important;");
        //span9.Attributes.Add("style", "background-color: #00cccc !important");
        //span9.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        btnPrev6.Visible = false;
        divpanel9.Visible = false;
        btnPrev7.Visible = false;
        divpanel3.Visible = true;
        btnNextPannel1.Visible = true;
        //btnPreview.Visible = false;
        btnPrev1.Visible = true;
        btnPrev1.Visible = false;
        divDUH.Attributes.Add("style", "color:#8c8c8c !important;");
        span7.Attributes.Add("style", "background-color: #8c8c8c !important");
        span9.Attributes.Add("style", "background-color: #8c8c8c !important");
        divRDH.Attributes.Add("style", "color:#00cccc !important;");
        span3.Attributes.Add("style", "background-color: #00cccc !important");
        span3.Attributes.Add("style", "background-color: #00cccc !important");
        divComp.Visible = false;
        divTrnsferDetails.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void btnPrev1_Click(object sender, EventArgs e)
    {
        btnPrev1.Visible = false;
        divTrnsferDetails.Visible = false;
        divComp.Visible = false;
        divPannel1.Visible = false;
        btnNextPannel2.Visible = false;
        divpanel3.Visible = true;
        btnNextPannel1.Visible = true;
        divRDH.Attributes.Add("style", "color:#00cccc !important;");
        span3.Attributes.Add("style", "background-color: #00cccc !important");
        span3.Attributes.Add("style", "background-color: #00cccc !important");
        divPDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span1.Attributes.Add("style", "background-color: #8c8c8c !important");
        span1.Attributes.Add("style", "background-color: #8c8c8c !important");
    }

    protected void btnPrev2_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "1";
        divPannel1.Visible = true;
        btnNextPannel2.Visible = true;
        btnPrev1.Visible = true;

        btnPrev2.Visible = false;
        divPannel2.Visible = false;
        btnNextPannel3.Visible = false;

        divPDH.Attributes.Add("style", "color:#00cccc !important;");
        span1.Attributes.Add("style", "background-color: #00cccc !important");
        span1.Attributes.Add("style", "background-color: #00cccc !important");
        divCDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span2.Attributes.Add("style", "background-color: #8c8c8c !important");
        span2.Attributes.Add("style", "background-color: #8c8c8c !important");

        if (ddlCandidatetype.SelectedValue == "T")
        {
            divTrnsferDetails.Visible = true;
            divComp.Visible = false;
        }
        if (ddlCandidatetype.SelectedValue == "C")
        {
            divComp.Visible = true;
            divTrnsferDetails.Visible = false;
        }
    }

    protected void btnPrev3_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "2";
        divPannel2.Visible = true;
        btnPrev2.Visible = true;
        btnNextPannel3.Visible = true;
        btnNextPannel4.Visible = false;
        btnPrev3.Visible = false;
        divpanel4.Visible = false;
        divPAH.Attributes.Add("style", "color:#8c8c8c !important;");
        span4.Attributes.Add("style", "background-color: #8c8c8c !important");
        span4.Attributes.Add("style", "background-color: #8c8c8c !important");
        divCDH.Attributes.Add("style", "color:#00cccc !important;");
        span2.Attributes.Add("style", "background-color: #00cccc !important");
        span2.Attributes.Add("style", "background-color: #00cccc !important");
    }

    protected void btnPrev4_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "3";
        divpanel4.Visible = true;
        btnPrev3.Visible = true;
        btnNextPannel4.Visible = true;
        divpanel5.Visible = false;
        btnPrev4.Visible = false;
        btnNextPannel5.Visible = false;
        divBDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span5.Attributes.Add("style", "background-color: #8c8c8c !important");
        span5.Attributes.Add("style", "background-color: #8c8c8c !important");
        divPAH.Attributes.Add("style", "color:#00cccc !important;");
        span4.Attributes.Add("style", "background-color: #00cccc !important");
        span4.Attributes.Add("style", "background-color: #00cccc !important");
    }

    protected void btnPrev5_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "4";
        divpanel5.Visible = true;
        btnPrev4.Visible = true;
        btnNextPannel5.Visible = true;
        divpanel6.Visible = false;
        btnPrev5.Visible = false;
        btnNextPannel6.Visible = false;
        divNDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span6.Attributes.Add("style", "background-color: #8c8c8c !important");
        span6.Attributes.Add("style", "background-color: #8c8c8c !important");
        divBDH.Attributes.Add("style", "color:#00cccc !important;");
        span5.Attributes.Add("style", "background-color: #00cccc !important");
        span5.Attributes.Add("style", "background-color: #00cccc !important");
    }

    protected void btnPrev6_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "5";
        divpanel6.Visible = true;
        btnPrev5.Visible = true;
        btnNextPannel6.Visible = true;
        divpanel7.Visible = false;
        btnPrev6.Visible = false;
        btnNextPannel7.Visible = false;
        divEEDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span7.Attributes.Add("style", "background-color: #8c8c8c !important");
        span7.Attributes.Add("style", "background-color: #8c8c8c !important");
        divNDH.Attributes.Add("style", "color:#00cccc !important;");
        span6.Attributes.Add("style", "background-color: #00cccc !important");
        span6.Attributes.Add("style", "background-color: #00cccc !important");
    }

    #region Profiling button prev event start
    protected void btnPrev7_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "6";
        btnPrev6.Visible = true;
        btnNextPannel7.Visible = true;
        divpanel7.Visible = true;
        divpanel8.Visible = false;
        btnNextPannel8.Visible = false;
        btnPrev7.Visible = false;
        divEEDH.Attributes.Add("style", "color:#00cccc  !important;");
        span7.Attributes.Add("style", "background-color: #00cccc  !important");
        span7.Attributes.Add("style", "background-color: #00cccc  !important");
        divPH.Attributes.Add("style", "color:#8c8c8c !important;");
        span8.Attributes.Add("style", "background-color: #8c8c8c !important");
        span8.Attributes.Add("style", "background-color: #8c8c8c !important");
    }
    #endregion Profiling button prev event end

    #region save profiling
    protected void btnNextPannel8_Click(object sender, EventArgs e)
    {
        ViewState["strClear"] = "8";

        #region Saving
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            #region New Business Plan Detail
            ArrayList arrResult = new ArrayList();
            string sessionuser = "";
            int iAppno;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            htparams.Clear();
            htparams.Add("@AppNo", txtapplicationno.Text.ToString());
            htparams.Add("@agntype", ddlagntype.SelectedValue.ToString());
            if (txtOthers.Text.Trim() != "")
            {
                htparams.Add("@othragntype", txtOthers.Text.Trim());
            }
            else
            {
                htparams.Add("@othragntype", System.DBNull.Value);
            }
            htparams.Add("@IsWrkng", ddlIsWrkng.SelectedValue.ToString());
            if (ddlIsWrkng.SelectedValue == "Y")
            {
                if (ddlcompName.SelectedValue.ToString() != "--Select--")
                {
                    htparams.Add("@compName", ddlcompName.SelectedValue.ToString());
                }
                else
                {
                    htparams.Add("@compName", System.DBNull.Value);
                }
            }
            else
            {
                htparams.Add("@compName", System.DBNull.Value);
            }
            htparams.Add("@NoOfYrsIns", ddlNoOfYrsIns.SelectedValue.ToString());
            htparams.Add("@NoOfYrs", ddlNoOfYrs.SelectedValue.ToString());
            if (ddlTypeOfVehicle.Enabled == true)
            {
                htparams.Add("@TypOfVchl", ddlTypeOfVehicle.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@TypOfVchl", System.DBNull.Value);
            }
            if (ddlVechManuf.Enabled == true)
            {
                htparams.Add("@VechManf", ddlVechManuf.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@VechManf", System.DBNull.Value);
            }
            if (txtDlrCompName.Enabled == true)
            {
                if (txtDlrCompName.Text.Trim() != "")
                {
                    htparams.Add("@DlrCompName", txtDlrCompName.Text.Trim());
                }
                else
                {
                    htparams.Add("@DlrCompName", System.DBNull.Value);
                }
            }
            else
            {
                htparams.Add("@DlrCompName", System.DBNull.Value);
            }
            if (txtDlrOth.Text.Trim() != "")
            {
                htparams.Add("@DlrOthr", txtDlrOth.Text.Trim());
            }
            else
            {
                htparams.Add("@DlrOthr", System.DBNull.Value);
            }

            htparams.Add("@AvgMnthlyIncm", ddlAvgMonthlyIncm.SelectedValue.ToString());
            htparams.Add("@Comp1Name", ddlComp1Name.SelectedValue.ToString());
            htparams.Add("@MnthVol1", ddlMnthVol1.SelectedValue.ToString());
            htParam.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
            if (ddlComp2Name.SelectedIndex != 0)
            {
                htparams.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@Comp2Name", System.DBNull.Value);
            }

            if (ddlMnthVol2.SelectedIndex != 0)
            {
                htparams.Add("@MnthVol2", ddlMnthVol2.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@MnthVol2", System.DBNull.Value);
            }

            if (ddlRGIMnthVol.SelectedValue != "Select")
            {
                htparams.Add("@RGIMnthVol", ddlRGIMnthVol.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@RGIMnthVol", System.DBNull.Value);
            }

            if (ddlTotBsnMtr.SelectedValue != "Select")
            {
                htparams.Add("@TotBsnMtr", ddlTotBsnMtr.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@TotBsnMtr", System.DBNull.Value);
            }

            if (ddlTotBsnHlth.SelectedValue != "Select")
            {
                htparams.Add("@TotBsnHlth", ddlTotBsnHlth.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@TotBsnHlth", System.DBNull.Value);
            }

            if (ddlRGIBsnMtr.SelectedValue != "Select")
            {
                htparams.Add("@RGIBsnMtr", ddlRGIBsnMtr.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@RGIBsnMtr", System.DBNull.Value);
            }

            if (ddlRGIBsnHlth.SelectedValue != "Select")
            {
                htparams.Add("@RGIBsnHlth", ddlRGIBsnHlth.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@RGIBsnHlth", System.DBNull.Value);
            }

            if (ddlRGIBsnComm.SelectedValue != "Select")
            {
                htparams.Add("@RGIBsnCmrclLine", ddlRGIBsnComm.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@RGIBsnCmrclLine", System.DBNull.Value);
            }

            if (ddlTotBsnComm.SelectedValue != "Select")
            {
                htparams.Add("@TotBsnCmrclLine", ddlTotBsnComm.SelectedValue.ToString());
            }
            else
            {
                htparams.Add("@TotBsnCmrclLine", System.DBNull.Value);
            }

            htparams.Add("@CreateBy", sessionuser);


            if (Request.QueryString["CndNo"] == null)
            {
                arrResult = clsCndReg.UpdateAgentDetails(htparams, "prc_UpdCndProfiling");
            }



            else
            {
                //Added By Prathamesh 8-6-15 
                httable.Clear();
                httable.Add("@AppNo", txtapplicationno.Text.Trim());
                httable.Add("@CndNo", txtcndid.Text.Trim());

                iAppno = Convert.ToInt16(dataAccessclass.execute_sprc_with_output("prc_GetCheckCndExist", httable, "@iAppcount", "INSCRecruitConnectionString"));

                //Added by Prathamesh 3-7-15 start for update profiling start
                if (iAppno == 1)
                {
                    htparams.Clear();
                    htparams.Add("@CndNo", txtcndid.Text.ToString());
                    //comment by Prathamesh bcoz This parameter is not add in below procedure 31-7-15
                    //htparams.Add("@AppNo", txtapplicationno.Text.ToString());
                    htparams.Add("@agntype", ddlagntype.SelectedValue.ToString());
                    if (txtOthers.Text.Trim() != "")
                    {
                        htparams.Add("@othragntype", txtOthers.Text.Trim());
                    }
                    else
                    {
                        htparams.Add("@othragntype", System.DBNull.Value);
                    }
                    htparams.Add("@IsWrkng", ddlIsWrkng.SelectedValue.ToString());
                    if (ddlIsWrkng.SelectedValue == "Y")
                    {
                        if (ddlcompName.SelectedValue.ToString() != "--Select--")
                        {
                            htparams.Add("@compName", ddlcompName.SelectedValue.ToString());
                        }
                        else
                        {
                            htparams.Add("@compName", System.DBNull.Value);
                        }
                    }
                    else
                    {
                        htparams.Add("@compName", System.DBNull.Value);
                    }

                    htparams.Add("@NoOfYrsIns", ddlNoOfYrsIns.SelectedValue.ToString());
                    htparams.Add("@NoOfYrs", ddlNoOfYrs.SelectedValue.ToString());
                    if (ddlTypeOfVehicle.Enabled == true)
                    {
                        htparams.Add("@TypOfVchl", ddlTypeOfVehicle.SelectedValue.ToString());
                    }
                    else
                    {
                        htparams.Add("@TypOfVchl", System.DBNull.Value);
                    }
                    if (ddlVechManuf.Enabled == true)
                    {
                        htparams.Add("@VechManf", ddlVechManuf.SelectedValue.ToString());
                    }
                    else
                    {
                        htparams.Add("@VechManf", System.DBNull.Value);
                    }
                    if (txtDlrCompName.Enabled == true)
                    {
                        if (txtDlrCompName.Text.Trim() != "")
                        {
                            htparams.Add("@DlrCompName", txtDlrCompName.Text.Trim());
                        }
                        else
                        {
                            htparams.Add("@DlrCompName", System.DBNull.Value);
                        }
                    }
                    else
                    {
                        htparams.Add("@DlrCompName", System.DBNull.Value);
                    }
                    if (txtDlrOth.Text.Trim() != "")
                    {
                        htparams.Add("@DlrOthr", txtDlrOth.Text.Trim());
                    }
                    else
                    {
                        htparams.Add("@DlrOthr", System.DBNull.Value);
                    }

                    htparams.Add("@AvgMnthlyIncm", ddlAvgMonthlyIncm.SelectedValue.ToString());
                    htparams.Add("@Comp1Name", ddlComp1Name.SelectedValue.ToString());
                    htparams.Add("@MnthVol1", ddlMnthVol1.SelectedValue.ToString());
                    //htParam.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
                    if (ddlComp2Name.SelectedIndex != 0)
                    {
                        htparams.Add("@Comp2Name", ddlComp2Name.SelectedValue.ToString());
                    }
                    else
                    {
                        htparams.Add("@Comp2Name", System.DBNull.Value);
                    }

                    if (ddlMnthVol2.SelectedIndex != 0)
                    {
                        htparams.Add("@MnthVol2", ddlMnthVol2.SelectedValue.ToString());
                    }
                    else
                    {
                        htparams.Add("@MnthVol2", System.DBNull.Value);
                    }

                    htparams.Add("@RGIMnthVol", ddlRGIMnthVol.SelectedValue.ToString());
                    htparams.Add("@TotBsnMtr", ddlTotBsnMtr.SelectedValue.ToString());
                    htparams.Add("@TotBsnHlth", ddlTotBsnHlth.SelectedValue.ToString());
                    htparams.Add("@RGIBsnMtr", ddlRGIBsnMtr.SelectedValue.ToString());
                    htparams.Add("@RGIBsnHlth", ddlRGIBsnHlth.SelectedValue.ToString());
                    htparams.Add("@RGIBsnCmrclLine", ddlRGIBsnComm.SelectedValue.ToString());
                    htparams.Add("@TotBsnCmrclLine", ddlTotBsnComm.SelectedValue.ToString());
                    htparams.Add("@UpdateBy", sessionuser);
                    if (ViewState["ProspectId"] == null)
                    {
                        arrResult = clsCndReg.UpdateAgentDetails(htparams, "Prc_UpdateProfileDetails");
                    }

                    hdnUpdate.Value = "Candidate Updated Successfully";//rk changed text 27/05/2013
                }
            }
            //Added by Prathamesh 3-7-15 start for update profiling end


            //if (arrResult[0].ToString() == "0")
            //{
            //Save(); //Method to update cndstatus and entry in licrentccsu
            // lblpopup.Text = "Profiling updated successfully." + "</br></br>Candidate ID: " + lblqcndno.Text.Trim() + "<br/>Application No: " + lblqappno.Text.Trim() + "<br/>Candidate name: " + lblqgivenname.Text.Trim() + " " + lblqsurname.Text.Trim()   "";
            //mdlpopup.Show();
            //ProgressBarModalPopupExtender.Hide();
            //}
            //else
            //{
            //    lblMessage.Text = arrResult[1].ToString();
            //    lblMessage.ForeColor = Color.Red;
            //    lblMessage.Visible = true;
            //}

            #endregion
            #region SAVING QUALIFICATION DETAIL
            //if (MultiView1.ActiveViewIndex == 1)
            //{
            //string sLangKnown;
            htParam.Clear();
            //comment by Prathamesh 9-6-15
            //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@CndNo", txtapplicationno.Text.ToString().Trim());/* txtcndid.Text.ToString().Trim());*/
            htParam.Add("@KnownLang", System.DBNull.Value);//chnaged by rachana on 22082014
            htParam.Add("@QualCode", cboQualCode.SelectedValue.ToString());
            htParam.Add("@InsQualDesc", txtinsurancequalification.Text.Trim());
            htParam.Add("@OcpnCode", txtOccupationCode.Text.Trim());
            htParam.Add("@OcpnDesc", txtOccupationDesc.Text.Trim());
            htParam.Add("@MutualFund", System.DBNull.Value);
            htParam.Add("@LifeInsurance", System.DBNull.Value);
            htParam.Add("@GeneralInsurance", System.DBNull.Value);
            htParam.Add("@CreditCard", System.DBNull.Value);
            htParam.Add("@OtherProducts", txtOtherProduct.Text.Trim());
            htParam.Add("@EmpAdd", txtempaddress.Text.Trim());
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@UpdateBy", sessionuser);
            arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd2");
            //if (arrResult[0].ToString() == "0")
            //{

            //}
            //else
            //{
            //    //lblMessage.Text = arrResult[1].ToString();
            //    lblMessage.Text = arrResult[2].ToString();
            //    lblMessage.ForeColor = Color.Red;
            //    lblMessage.Visible = true;
            //}
            ////}
            #endregion
            #region SAVING EMPLOYMENT HISTORY DETAIL
            #region
            if (txtto1.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtto2.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtto3.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtto4.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtto5.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtto6.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtto6.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            //Added by pranjali on 10-03-2014 for not allowing future date to be entered in Employment history To: end
            //Added by pranjali on 10-03-2014 for not allowing future date to be entered in Employment history From: start
            if (txtfrom1.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtfrom2.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtfrom3.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtfrom4.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtfrom4.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtfrom5.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtfrom5.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }

            if (txtotherexpfrom1.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpfrom1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtotherexpfrom2.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpfrom2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            if (txtotherexpfrom3.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpfrom3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in From:')", true);
                    return;
                }
            }
            //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service end

            //Added by pranjali on 10-03-2014 for not allowing future date to be entered in sales/marketing/financial service To: start
            if (txtotherexpTo1.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpTo1.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtotherexpTo2.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpTo2.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            if (txtotherexpTo3.Text.ToString().Trim() != "")
            {
                if ((Convert.ToDateTime(txtotherexpTo3.Text)) > (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Future Date cannot be entered in To:')", true);
                    return;
                }
            }
            #endregion
            htParam.Clear();
            htParam.Add("@CndNo", txtapplicationno.Text.ToString().Trim());/*txtcndid.Text.ToString().Trim());*/
            htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
            if (DateChecking() == 0)
                return;
            htParam.Add("@CompName1", txtPrevEmpName1.Text.Trim());
            if (txtfrom1.Text.Trim() != "")
            {
                htParam.Add("@StartDate1", DateTime.Parse(txtfrom1.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@StartDate1 ", System.DBNull.Value);
            }
            if (txtto1.Text.Trim() != "")
            {
                htParam.Add("@EndDate1", DateTime.Parse(txtto1.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EndDate1 ", System.DBNull.Value);
            }
            htParam.Add("@AddofEmployer1", txtaddofemp1.Text.Trim());
            htParam.Add("@LastPositionHeld1", txtEmpLvl1.Text.Trim());
            htParam.Add("@AnnIncome1", txtLastIncome1.Text.Trim());
            htParam.Add("@ReasonLeave1", txtreasforleave1.Text.Trim());
            htParam.Add("@CompName2", txtPrevEmpName2.Text.Trim());
            if (txtfrom2.Text.Trim() != "")
            {
                htParam.Add("@StartDate2", DateTime.Parse(txtfrom2.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@StartDate2 ", System.DBNull.Value);
            }
            if (txtto2.Text.Trim() != "")
            {
                htParam.Add("@EndDate2", DateTime.Parse(txtto2.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EndDate2 ", System.DBNull.Value);
            }
            htParam.Add("@AddofEmployer2", txtaddofemp2.Text.Trim());
            htParam.Add("@LastPositionHeld2", txtEmpLvl2.Text.Trim());
            htParam.Add("@AnnIncome2", txtLastIncome2.Text.Trim());
            htParam.Add("@ReasonLeave2", txtreasforleave2.Text.Trim());
            htParam.Add("@CompName3", txtPrevEmpName3.Text.Trim());
            if (txtfrom3.Text.Trim() != "")
            {
                htParam.Add("@StartDate3", DateTime.Parse(txtfrom3.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@StartDate3 ", System.DBNull.Value);
            }
            if (txtto3.Text.Trim() != "")
            {
                htParam.Add("@EndDate3", DateTime.Parse(txtto3.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EndDate3 ", System.DBNull.Value);
            }
            htParam.Add("@AddofEmployer3", txtaddofemp3.Text.Trim());
            htParam.Add("@LastPositionHeld3", txtEmpLvl3.Text.Trim());
            htParam.Add("@AnnIncome3", txtLastIncome3.Text.Trim());
            htParam.Add("@ReasonLeave3", txtreasforleave3.Text.Trim());
            htParam.Add("@CompName4", txtPrevEmpName4.Text.Trim());
            if (txtfrom4.Text.Trim() != "")
            {
                htParam.Add("@StartDate4", DateTime.Parse(txtfrom4.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@StartDate4 ", System.DBNull.Value);
            }
            if (txtto4.Text.Trim() != "")
            {
                htParam.Add("@EndDate4", DateTime.Parse(txtto4.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EndDate4 ", System.DBNull.Value);
            }
            htParam.Add("@AddofEmployer4", txtaddofemp4.Text.Trim());
            htParam.Add("@LastPositionHeld4", txtEmpLvl4.Text.Trim());
            htParam.Add("@AnnIncome4", txtLastIncome4.Text.Trim());
            htParam.Add("@ReasonLeave4", txtreasforleave4.Text.Trim());
            htParam.Add("@CompName5", txtPrevEmpName5.Text.Trim());
            if (txtfrom5.Text.Trim() != "")
            {
                htParam.Add("@StartDate5", DateTime.Parse(txtfrom5.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@StartDate5 ", System.DBNull.Value);
            }
            if (txtto5.Text.Trim() != "")
            {
                htParam.Add("@EndDate5", DateTime.Parse(txtto5.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@EndDate5 ", System.DBNull.Value);
            }

            htParam.Add("@AddofEmployer5", txtaddofemp5.Text.Trim());
            htParam.Add("@LastPositionHeld5", txtEmpLvl5.Text.Trim());
            htParam.Add("@AnnIncome5", txtLastIncome5.Text.Trim());
            htParam.Add("@ReasonLeave5", txtreasforleave5.Text.Trim());
            htParam.Add("@CompName6", System.DBNull.Value);
            htParam.Add("@StartDate6 ", System.DBNull.Value);
            htParam.Add("@EndDate6", System.DBNull.Value);
            htParam.Add("@AddofEmployer6", System.DBNull.Value);
            htParam.Add("@LastPositionHeld6", System.DBNull.Value);
            htParam.Add("@AnnIncome6", System.DBNull.Value);
            htParam.Add("@ReasonLeave6", System.DBNull.Value);
            htParam.Add("@AcompName", txtInsCompName.Text.Trim());
            htParam.Add("@IsInsExp", rbinsagency.SelectedValue.Trim());
            htParam.Add("@LcnNo", txtLcnNo.Text.Trim());
            htParam.Add("@CseReasonDesc", txtTerminationReason.Text.Trim());
            htParam.Add("@AgentCode", txtInsAgencyCode.Text.Trim());

            if (txtdateofissue.Text.Trim() != "")
            {
                htParam.Add("@LcnIssDate", DateTime.Parse(txtdateofissue.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@LcnIssDate ", System.DBNull.Value);
            }

            if (txtvaliddate.Text.Trim() != "")
            {
                htParam.Add("@LcnExpDate", DateTime.Parse(txtvaliddate.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@LcnExpDate ", System.DBNull.Value);
            }

            if (txtterminatedate.Text.Trim() != "")
            {
                htParam.Add("@CseDate", DateTime.Parse(txtterminatedate.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CseDate ", System.DBNull.Value);
            }
            htParam.Add("@CECompName1", txtemprecordname1.Text.Trim());
            if (txtotherexpfrom1.Text.Trim() != "")
            {
                htParam.Add("@CEStartDate1", DateTime.Parse(txtotherexpfrom1.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEStartDate1 ", System.DBNull.Value);
            }
            if (txtotherexpTo1.Text.Trim() != "")
            {
                htParam.Add("@CEEndDate1", DateTime.Parse(txtotherexpTo1.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEEndDate1 ", System.DBNull.Value);
            }
            htParam.Add("@CEWorkType1", txtemprecordjobnature1.Text.Trim());
            htParam.Add("@CEWorkCls1", txtemprecordfield1.Text.Trim());
            htParam.Add("@CECompName2", txtemprecordname2.Text.Trim());
            if (txtotherexpfrom2.Text.Trim() != "")
            {
                htParam.Add("@CEStartDate2", DateTime.Parse(txtotherexpfrom2.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEStartDate2 ", System.DBNull.Value);
            }
            if (txtotherexpTo2.Text.Trim() != "")
            {
                htParam.Add("@CEEndDate2", DateTime.Parse(txtotherexpTo2.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEEndDate2 ", System.DBNull.Value);
            }
            htParam.Add("@CEWorkType2", txtemprecordjobnature2.Text.Trim());
            htParam.Add("@CEWorkCls2", txtemprecordfield2.Text.Trim());


            //Any other work experience 3
            htParam.Add("@CECompName3", txtemprecordname3.Text.Trim());
            if (txtotherexpfrom3.Text.Trim() != "")
            {
                htParam.Add("@CEStartDate3", DateTime.Parse(txtotherexpfrom3.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEStartDate3 ", System.DBNull.Value);
            }
            if (txtotherexpTo3.Text.Trim() != "")
            {
                htParam.Add("@CEEndDate3", DateTime.Parse(txtotherexpTo3.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CEEndDate3 ", System.DBNull.Value);
            }
            htParam.Add("@CEWorkType3", txtemprecordjobnature3.Text.Trim());
            htParam.Add("@CEWorkCls3", txtemprecordfield3.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);
            if (ViewState["ProspectId"] != null)
            {
                arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd3");
            }
            //if (arrResult[0].ToString() == "0")
            //{

            //}
            //else
            //{
            //    //lblMessage.Text = arrResult[1].ToString();
            //    lblMessage.Text = arrResult[2].ToString();
            //    lblMessage.ForeColor = Color.Red;
            //    lblMessage.Visible = true;
            //}
            //}
            #endregion
            #region SAVING DISCIPLINARY INFORMATION DETAIL
            //if (MultiView1.ActiveViewIndex == 1)
            //{
            htParam.Clear();
            //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 start

            //comment by Prathamesh 9-6-15
            htParam.Add("@CndNo", "");/* txtcndid.Text.ToString().Trim());*/
                                      //Added by swapnesh for inserting Disciplinary Info data on 20_5_2013 end                
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@Qstn01", System.DBNull.Value);
            htParam.Add("@Qstn02", System.DBNull.Value);
            htParam.Add("@Qstn03", System.DBNull.Value);
            htParam.Add("@Qstn04", System.DBNull.Value);
            //Comented by rachana on 22-08-2014 end
            htParam.Add("@RefName01", txtRef1Name.Text.Trim());
            htParam.Add("@Ref1Add1", txtRef1Add1.Text.Trim());
            htParam.Add("@Ref1Add2", txtRef1Add2.Text.Trim());
            htParam.Add("@Ref1Add3", txtRef1Add3.Text.Trim());
            htParam.Add("@Ref1city", "");
            htParam.Add("@Ref1PostCode", txtRef1Pin.Text.Trim());
            if (txtStateCodeR1.Text.Trim() == "")
            {
                htParam.Add("@Ref1StateCode", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@Ref1StateCode", txtStateCodeR1.Text.Trim());
            }
            htParam.Add("@Ref1CntryCode", txtCountryCodeR1.Text.Trim());

            htParam.Add("@RefName02", txtRef2Name.Text.Trim());
            htParam.Add("@Ref2Add1", txtRef2Add1.Text.Trim());
            htParam.Add("@Ref2Add2", txtRef2Add2.Text.Trim());
            htParam.Add("@Ref2Add3", txtRef2Add3.Text.Trim());
            htParam.Add("@Ref2City", "");
            htParam.Add("@Ref2PostCode", txtRef2Pin.Text.Trim());
            if (txtStateCodeR2.Text.Trim() == "")
            {
                htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
            }
            else
            {
                htParam.Add("@Ref2StateCode", txtStateCodeR2.Text.Trim());
            }

            htParam.Add("@Ref2CntryCode", txtCountryCodeR2.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);

            arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd4");

            //Added by swapnesh end
            //if (arrResult[0].ToString() == "0")
            //{
            //}
            //else
            //{
            //    lblMessage.Text = arrResult[1].ToString();
            //    lblMessage.ForeColor = Color.Red;
            //    lblMessage.Visible = true;
            //}
            //}
            #endregion
            #region SAVING BUSINESS PLAN DETAIL
            //if (MultiView1.ActiveViewIndex == 1)
            //{
            htParam.Clear();
            //COMMENT by Prathamesh 9-6-15
            htParam.Add("@CndNo", txtapplicationno.Text.ToString().Trim());/*txtcndid.Text.ToString().Trim());*/
            htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
            htParam.Add("@TgtYrProspect01", txtbusinessplannooflives11.Text.Trim());
            htParam.Add("@TgtYrProspect02", txtbusinessplannooflives21.Text.Trim());
            htParam.Add("@TgtYrProspect03", txtbusinessplannooflives31.Text.Trim());
            htParam.Add("@TgtYrInc01", txtbusinessplansumassured11.Text.Trim());
            htParam.Add("@TgtYrInc02", txtbusinessplannsumassured21.Text.Trim());
            htParam.Add("@TgtYrInc03", txtbusinessplannsumassured31.Text.Trim());
            htParam.Add("@TgtFYC01", txtbusinessplannfirstyearpremium11.Text.Trim());
            htParam.Add("@TgtFYC02", txtbusinessplannfirstyearpremium21.Text.Trim());
            htParam.Add("@TgtFYC03", txtbusinessplannfirstyearpremium31.Text.Trim());
            htParam.Add("@IsFullTime", rbtimework.SelectedValue == "0" ? "0" : "1");
            htParam.Add("@PastAchievement", txtpastachievement.Text.Trim());
            htParam.Add("@RelativeAtWork", rbrelatedemp.SelectedValue == "Y" ? "Y" : "N");
            htParam.Add("@RelativeAtWorkDesc", txtrelativeworkdesc.Text.Trim());
            htParam.Add("@CreateBy", sessionuser);

            arrResult = clsCndReg.UpdateAgentDetails(htParam, "prc_CndAdmin_UpdCnd5");
            //Modify By sandeep on 15 NOV 2013 to update cnd table when data enter from InterView module BY prospect id END

            //if (arrResult[0].ToString() == "0")
            //{
            //    //lblpopup.Text = "Profiling updated successfully." + "</br></br>Candidate ID: " + lblqcndno.Text.Trim() + "<br/>Application No: " + lblqappno.Text.Trim() + "<br/>Candidate name: " + lblqgivenname.Text.Trim() + " " + lblqsurname.Text.Trim() +
            //    //    "";
            //    //mdlpopup.Show();
            //    //ProgressBarModalPopupExtender.Hide();
            //}
            //else
            //{
            //    lblMessage.Text = arrResult[1].ToString();
            //    lblMessage.ForeColor = Color.Red;
            //    lblMessage.Visible = true;
            //}
            //}


            ViewState["Pan"] = txtCurrentID.Text;//Added By Prathamesh 24-8-15 



            //Added ByPrathamesh tab of Profiling for saving end---
            #endregion
        }
        #endregion


        htParam.Clear();
        #region docupload grid
        GetCandidateDtls();
        Bindgridview();
        #endregion
        #region visibility
        btnPrev8.Visible = true;
        btndocsave.Enabled = true;
        //btnPreview.Visible = true;
        divpanel9.Visible = true;
        btnPrev7.Visible = false;
        btnNextPannel8.Visible = false;
        divpanel8.Visible = false;
        divPH.Attributes.Add("style", "color:#8c8c8c !important;");
        span8.Attributes.Add("style", "background-color: #8c8c8c !important");
        span8.Attributes.Add("style", "background-color: #8c8c8c !important");
        divDUH.Attributes.Add("style", "color:#00cccc !important;");
        span9.Attributes.Add("style", "background-color: #00cccc !important");
        span9.Attributes.Add("style", "background-color: #00cccc !important");
        #endregion

        if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["Type"] == "E")
        {
            btnUpdate.Visible = true;
        }
        else
        {
            btndocsave.Visible = true;
        }
    }
    #endregion Profiling button next event end

    protected void ddlCandidatetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCandidatetype.SelectedValue == "F")
        {
            #region composite & Transfer segment hide start 03-10-2022
            lblFessWav.Visible = true;
            ddlFessWav.Visible = true;
            divComp.Visible = false;
            divCompDtls.Visible = false;
            divCompositeDetails.Visible = false;
            divTrans.Visible = false;
            trCompTitle.Visible = false;
            trNote.Visible = false;
            trNoteTr.Visible = false;
            lblIC.Visible = false;
            txtIC.Visible = false;
            txtIC.Enabled = false;
            ddlCaTrnsfr.Enabled = false;
            ddlNameInTrnsfr.Enabled = false;
            txtAgencyCodeTrnsfr.Enabled = false;
            txtDateOfAppointmentTrnsfr.Enabled = false;
            ddlStsTrnsfr.Enabled = false;
            txtDateOfCessationTrnsfr.Enabled = false;
            txtReasonForCessationTrnsfr.Enabled = false;
            divTrnsferDetails.Visible = false;
            #endregion composite & Transfer segment hide end 03-10-2022
        }
        else if (ddlCandidatetype.SelectedValue == "C")
        {
            #region composite segment show start 03-10-2022
            lblFessWav.Visible = true;
            ddlFessWav.Visible = true;
            divComp.Visible = true;
            divCompDtls.Visible = true;
            divCompositeDetails.Visible = true;
            #endregion composite segment show end 03-10-2022

            #region Transfer segment hide start 03-10-2022
            divTrans.Visible = false;
            trCompTitle.Visible = false;
            trNote.Visible = true;
            trNoteTr.Visible = false;
            lblIC.Visible = false;
            txtIC.Visible = false;
            txtIC.Enabled = false;
            ddlCaTrnsfr.Enabled = false;
            ddlNameInTrnsfr.Enabled = false;
            txtAgencyCodeTrnsfr.Enabled = false;
            txtDateOfAppointmentTrnsfr.Enabled = false;
            ddlStsTrnsfr.Enabled = false;
            txtDateOfCessationTrnsfr.Enabled = false;
            txtReasonForCessationTrnsfr.Enabled = false;
            divTrnsferDetails.Visible = false;
            #endregion composite segment hide end 03-10-2022
        }
        else if (ddlCandidatetype.SelectedValue == "T")
        {
            ddlFessWav.Visible = false;
            lblFessWav.Visible = false;
            #region Transfer segment show start 03-10-2022
            divTrans.Visible = true;
            trCompTitle.Visible = false;
            trNote.Visible = false;
            trNoteTr.Visible = true;
            lblIC.Visible = true;
            txtIC.Visible = true;
            txtIC.Enabled = true;
            ddlCaTrnsfr.Enabled = true;
            ddlNameInTrnsfr.Enabled = true;
            txtAgencyCodeTrnsfr.Enabled = true;
            txtDateOfAppointmentTrnsfr.Enabled = true;
            ddlStsTrnsfr.Enabled = true;
            txtDateOfCessationTrnsfr.Enabled = true;
            txtReasonForCessationTrnsfr.Enabled = true;
            divTrnsferDetails.Visible = true;
            #endregion composite segment hide end 03-10-2022

            #region composite segment hide start 03-10-2022
            divComp.Visible = false;
            divCompDtls.Visible = false;
            divCompositeDetails.Visible = false;
            #endregion Transfer segment show start 03-10-2022
        }
    }

    #region anniversry visibilty
    protected void cboMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboMaritalStatus.SelectedValue.ToString() == "M")
            {
                anniversryrow.Visible = true;
                LblAnnivrsryDt.Visible = true;
                TxtAnnivrsryDt.Text = "";
                calrow.Visible = true;
            }
            else
            {
                calrow.Visible = false;
                anniversryrow.Visible = false;
                LblAnnivrsryDt.Visible = false;
                TxtAnnivrsryDt.Text = "";
            }
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
    #endregion

    private void Bindgridview()
    {
        try
        {
            string Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            if (txtcndid.Text == "")
            {
                if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
                {
                    httable1.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
                }
                else if (Request.QueryString["type"] == "N")
                {
                    httable1.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
            }
            else
            {
                httable1.Add("@CndNo", txtcndid.Text);
            }
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
            Hashtable htparam = new Hashtable();
            if (txtcndid.Text == "")
            {
                if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
                {
                    htparam.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
                }
                else if (Request.QueryString["type"] == "N")
                {
                    htparam.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
            }
            else
            {
                htparam.Add("@CndNo", txtcndid.Text);
            }
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim());
            htparam.Add("@TypeofDoc", "UPLD");
            if (ViewState["ProcessType"].ToString() != "NC")
            {
                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                {
                    htparam.Add("@InsurerType", "");
                    if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htparam.Add("@ProcessType", "NR");
                    }
                }
                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                {
                    htparam.Add("@InsurerType", "");
                    if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htparam.Add("@ProcessType", "NR");
                    }
                }
                else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "ReTrn")
                {
                    htparam.Add("@InsurerType", "");
                    htparam.Add("@ProcessType", "RE");
                }
                else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "Renwl")
                {
                    htparam.Add("@InsurerType", "");
                    htparam.Add("@ProcessType", "RW");
                    #region shree07
                    //if (Comp.Visible == false)
                    //{
                    //    htparam.Add("@RenwlFlag", "Y");
                    //    htparam.Add("@InsurerType", "");
                    //    htparam.Add("@ReExmFlag", "N");
                    //}
                    //else
                    //{
                    //    htparam.Add("@RenwlFlag", "Y");
                    //    htparam.Add("@InsurerType", ddlRenewType.SelectedValue);
                    //    htparam.Add("@ReExmFlag", "N");
                    //}
                    #endregion
                }
            }
            if (ViewState["ProcessType"].ToString() != "NC")
            {
                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam); //added by pranjali on 19-05-2014
            }
            else
            {

                if (lblsnlve.Text == "Death")
                {
                    htparam.Add("@Flag", "2");
                }
                else if (lblsnlve.Text == "Cancellation")
                {
                    htparam.Add("@Flag", "1");
                }
                else
                {


                }
                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetQCNOCDocNames", htparam);
            }

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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        int pageIndex = dgView.PageIndex;
        dgView.PageIndex = pageIndex - 1;
        Bindgridview();
        txtPage1.Text = Convert.ToString(Convert.ToInt32(txtPage1.Text) - 1);
        if (txtPage1.Text == "1")
        {
            btnprevious.Enabled = false;
        }
        else
        {
            btnprevious.Enabled = true;
        }
        btnnext2.Enabled = true;
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        int pageIndex = dgView.PageIndex;
        dgView.PageIndex = pageIndex + 1;
        Bindgridview();
        txtPage1.Text = Convert.ToString(Convert.ToInt32(txtPage1.Text) + 1);
        btnprevious.Enabled = true;
        int page = dgView.PageCount;
        if (txtPage1.Text == Convert.ToString(dgView.PageCount))
        {
            btnnext2.Enabled = false;
        }
        //BindgridChkboxChnge();//added by meena 7_4_18
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
            {
                lblCndNoValue.Text = Request.QueryString["ProspectId"];
            }
            else if (Request.QueryString["type"] == "N")
            {
                lblCndNoValue.Text = ViewState["ProspectId"].ToString();
            }
            else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
            {
                lblCndNoValue.Text = txtcndid.Text;
            }
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
            if (Directory.Exists(strPath) == false)
            {
                strPath = strPath + lblCndNoValue.Text.Trim();
                Directory.CreateDirectory(strPath);
            }
            else
            {
                strFilePath = strPath + lblCndNoValue.Text.Trim();
                //if (!Directory.Exists(Server.MapPath(strFilePath)))
                if (!Directory.Exists(strFilePath))
                {
                    // Directory.CreateDirectory(Server.MapPath(strFilePath));
                    Directory.CreateDirectory(strFilePath);
                }
                else
                {
                    strFilePath = strPath + lblCndNoValue.Text.Trim();
                }
            }

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
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PNG" || strPhotoExt == "png")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PDF")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
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
            FileInfo fi = new FileInfo(strFileName);
            using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] byteData = fuData.FileBytes;
                //byte[] byteData = data;
                fileStream.Write(byteData, 0, byteData.Length);
            }
            #endregion
            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];
            htdata.Clear();
            //if (ViewState["ProspectId"] == null)
            //{
            //    htdata.Add("@CndNo", txtcndid.Text);
            //}
            //else
            //{
            //    htdata.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            //}
            if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
            {
                htdata.Add("@CndNo", Request.QueryString["ProspectId"].ToString());
            }
            else if (Request.QueryString["type"] == "N")
            {
                htdata.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            }
            else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
            {
                htdata.Add("@CndNo", txtcndid.Text);
            }
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocname.Text.Trim());
            htdata.Add("@UserID", "");
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "0");
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
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    }

                    else if (Request.QueryString["Type"].ToString().Trim() == "R") //shreela 26-03-2014
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    }

                    else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    }
                    else if (Request.QueryString["Type"].ToString().Trim() == "Renwl") //shreela 26-03-2014
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    }
                    else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    }
                }
            }
            catch (Exception ex)
            {
                trmsg.Visible = true;
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
            hdnDocName.Value = lbldocname.Text.Trim();
            btnreupd.Enabled = true;
            btnreupd.Visible = true;
            btn_Upload.Enabled = false;
            btn_Upload.Visible = false;
            //btn_ReUpload.Visible = true;
            //btn_ReUpload.Enabled = true;
            lnkPreview.Visible = true;
            txtExmCentre.Text = hdnExmCentreCode.Value;
        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
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
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
        {
            lblCndNoValue.Text = Request.QueryString["ProspectId"];
        }
        else if (Request.QueryString["type"] == "N")
        {
            lblCndNoValue.Text = ViewState["ProspectId"].ToString();
        }
        else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
        {
            lblCndNoValue.Text = txtcndid.Text;
        }
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
        if (Directory.Exists(strPath) == false)
        {
            strPath = strPath + lblCndNoValue.Text.Trim();
            Directory.CreateDirectory(strPath);
        }
        else
        {
            strFileRePath = strPath + lblCndNoValue.Text.Trim();
            if (!Directory.Exists(strFileRePath))
            {
                Directory.CreateDirectory(strFileRePath);
            }
            else
            {
                strFileRePath = strPath + lblCndNoValue.Text.Trim();
            }
        }
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
            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PNG" || strPhotoExt == "png")
        {

            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        {
            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PDF")
        {
            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }


        if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
        {
            System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
            if (strPhotoExt != string.Empty)
            {

                image_height = image_file.Height;
                image_width = image_file.Width;
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

        FileInfo fi = new FileInfo(strPath);
        {
            if (fuData.PostedFile.ContentLength <= BMaxImgSize1)
            {
                if (File.Exists(strFileName))
                {
                    string stroldpath = strFileRePath + "\\" + strFileName1;
                    string[] strfile = strFileName1.Split('.');
                    string ImageNamenew = strfile[0];
                    htdata.Clear();
                    if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
                    {
                        htdata.Add("@CndNo", Request.QueryString["ProspectId"].ToString());
                    }
                    else if (Request.QueryString["type"] == "N")
                    {
                        htdata.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                    }
                    else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
                    {
                        htdata.Add("@CndNo", txtcndid.Text);
                    }
                    htdata.Add("@doctype", lbldocName.Text.Trim());
                    dsResult.Clear();
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocStatus", htdata);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            DocStatusCount = dsResult.Tables[0].Rows[0]["DocStatusCount"].ToString().Trim();
                        }
                    }
                    string strnewpath = strFileRePath + "\\" + ImageNamenew + "_R" + DocStatusCount + "." + strPhotoExt;
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
        fuData.PostedFile.SaveAs((strFileName));
        string str1 = strFileName.Replace(@"\", @"/");
        string[] actualpath = str1.Split('/');
        strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];
        htdata.Clear();
        //if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
        //{
        //    if (ViewState["ProspectId"] == null)
        //    {
        //        htdata.Add("@CndNo", txtcndid.Text);
        //    }
        //    else
        //    {
        //        htdata.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
        //    }
        //}
        //else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
        //{
        //    htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        //}
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
        {
            htdata.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "N")
        {
            htdata.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
        }
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
        {
            htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        }
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName1);
        htdata.Add("@DocType", lbldocName.Text.Trim());
        htdata.Add("@UserID", "");
        htdata.Add("@DctmFlag", 'N');
        htdata.Add("@DocStatus", "1");
        htdata.Add("@Imagebin", data);
        htdata.Add("@DocCode", lbldoccode1.Text.Trim());
        htdata.Add("@FileType", strPhotoExt);
        try
        {
            GetCandidateDtls();
            if (strProcessType == "NC")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
            }
            else
            {
                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }

                if (Request.QueryString["Type"].ToString().Trim() == "R")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }
                else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }
                else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }
                else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }
            }
        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
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
    }

    private void GetCandidateDtls()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        if (txtcndid.Text == "")
        {
            if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
            {
                htDtls.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
            }
            else if (Request.QueryString["type"] == "N")
            {
                htDtls.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            }
        }
        else
        {
            htDtls.Add("@CndNo", txtcndid.Text);
        }
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString().Trim();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim();
        strProcessType = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
        strCandtype = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString().Trim(); //Added by Nikhil
        ViewState["SMChanel"] = dsDtls.Tables[0].Rows[0]["SMChanel"].ToString().Trim();
    }

    protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Preview")
            {
                string Preview = e.CommandArgument.ToString().Trim();
                string CndNo = "";
                if (Request.QueryString["Type"] == "N")
                {
                    CndNo = ViewState["ProspectId"].ToString().Trim();
                }
                else if (Request.QueryString["Type"] == "E")
                {
                    //CndNo = Request.QueryString["CndNo"].ToString().Trim();
                    CndNo = Request.QueryString["ProspectId"].ToString().Trim();
                }
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lbldocName = (Label)row.FindControl("lbldocName");
                string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&CndNo=" + CndNo.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
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

    protected void btndocsave_Click(object sender, EventArgs e)
    {
        #region Document upload validation
        string Code = "Spon";
        DataSet ds_candtype = new DataSet();
        Hashtable httable1 = new Hashtable();
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
        {
            httable1.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "N")
        {
            httable1.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
        {
            httable1.Add("@CndNo", txtcndid.Text);
        }
        ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
        Hashtable htparam = new Hashtable();
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
        {
            htparam.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "N")
        {
            htparam.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
        {
            htparam.Add("@CndNo", txtcndid.Text);
        }
        htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
        htparam.Add("@ModuleCode", Code.Trim());
        htparam.Add("@TypeofDoc", "UPLD");
        if (ViewState["ProcessType"].ToString() != "NC")
        {
            if (Request.QueryString["type"].ToString().Trim() == "N" || Request.QueryString["ACT"].ToString().Trim() == "PR")
            {
                htparam.Add("@InsurerType", "");
                if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "SP");
                }
                else
                {
                    htparam.Add("@ProcessType", "NR");
                }
            }
            else if (Request.QueryString["type"].ToString().Trim() == "ReTrn")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "RE");
            }
            else if (Request.QueryString["type"].ToString().Trim() == "Renwl")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "RW");
            }
        }
        if (ViewState["ProcessType"].ToString() != "NC")
        {
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam); //added by pranjali on 19-05-2014
        }
        else
        {
            if (lblsnlve.Text == "Death")
            {
                htparam.Add("@Flag", "2");
            }
            else if (lblsnlve.Text == "Cancellation")
            {
                htparam.Add("@Flag", "1");
            }
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetQCNOCDocNames", htparam);
        }
        if (ds_documentName.Tables.Count > 0)
        {
            if (ds_documentName.Tables[0].Rows.Count > 0)
            {
                int i;
                for (i = 0; i < ds_documentName.Tables[0].Rows.Count; i++)
                {
                    string mandtry = ds_documentName.Tables[0].Rows[i]["IsMandatory"].ToString().Trim();

                    if (mandtry == "Y")
                    {
                        string ImgDesc = ds_documentName.Tables[0].Rows[i]["ImgDesc01"].ToString().Trim();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                        return;
                    }
                }
                int j;
                for (j = 0; j < ds_documentName.Tables[0].Rows.Count; j++)
                {
                    string mandtry = ds_documentName.Tables[0].Rows[j]["IsMandatory"].ToString().Trim();
                    string imgshrt = ds_documentName.Tables[0].Rows[j]["DocCode"].ToString().Trim();
                    int imgshrtcode = Convert.ToInt32(imgshrt);
                    if (mandtry == "C" && imgshrt == "14")
                    {

                    }
                    else if (mandtry == "C" && imgshrt == "15")
                    {
                        Hashtable httable = new Hashtable();
                        DataSet ds_panchayat = new DataSet();
                        httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                        ds_panchayat = dataAccessRecruit.GetDataSetForPrcCLP("Prc_CheckForPanchayat", httable);
                        if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                        {
                            ProgressBarModalPopupExtender.Hide();
                            string ImgDesc = ds_documentName.Tables[0].Rows[j]["ImgDesc01"].ToString().Trim();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                            return;
                        }
                    }
                }

            }//end of main for 
        }
        
        #endregion

        Save();

        DataSet dscandtype = new DataSet();
        Hashtable htcndtyp = new Hashtable();
        if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
        {
            htcndtyp.Add("@AppNo", Request.QueryString["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "N")
        {
            htcndtyp.Add("@AppNo", ViewState["ProspectId"].ToString().Trim());
        }
        else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
        {
            htcndtyp.Add("@AppNo", txtcndid.Text);
        }
        dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Get_Cndno", htcndtyp);
        string Cndno = dscandtype.Tables[0].Rows[0]["CndNo"].ToString().Trim();
        #region Save Popup 
        if (Request.QueryString["Type"] == "N" || Request.QueryString["ACT"] == "PR")
        {
            string mess = "Candidate registration done successfully.";
            c1.Attributes.Add("style", "display:block");
            lbl3.Text = mess + "</br><br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Candidate No: " + Cndno + "<br/>Application No: " + txtapplicationno.Text +
                 "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration.";
            mdlpopup.Show();
            btndocsave.Enabled = false;
        }
        #endregion
        btnCancel.Enabled = false;
        btnexit.Enabled = false;
        btnPrev8.Enabled = false;
    }

    private void Save()
    {
        #region new request submit
        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N" || Request.QueryString["ACT"] == "PR")
        {
            GetCandidateDtls();
            #region  AuditLog
            ArrayList arrLst = new ArrayList();
            arrLst.Add(new prjXml.Collection("WaiverFlag", ""));
            if (strAdvWaiverExt.ToUpper().Trim() == "doc" || strAdvWaiverExt.ToUpper().Trim() == "DOC")
            {
                arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
            }
            else if (strAdvWaiverExt.ToUpper().Trim() == "GIF" || strAdvWaiverExt.ToUpper().Trim() == "gif")
            {
                arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
            }
            else if (strAdvWaiverExt.ToUpper().Trim() == "JPG" || strAdvWaiverExt.ToUpper().Trim() == "jpg")
            {
                arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
            }
            else if (strAdvWaiverExt.ToString().Trim() == "" || strAdvWaiverExt.ToString().Trim() == null)
            {
                arrLst.Add(new prjXml.Collection("AdvWaiverForm", "0"));
            }
            prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
            XmlDocument xDoc = new XmlDocument();
            xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
            strXML = xDoc.OuterXml;
            arrLst.Clear();
            #endregion Auditlog
            DataSet dsFees = new DataSet();
            htParam.Clear();
            if (txtcndid.Text != "")
            {
                htParam.Add("@CndNo", txtcndid.Text);
            }
            else
            {
                if (ViewState["ProspectId"] != null)
                {
                    htParam.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htParam.Add("@CndNo", System.DBNull.Value);
                }

            }
            if (txtapplicationno.Text != "")
            {
                htParam.Add("@AppNo", txtapplicationno.Text);
            }
            else
            {
                if (ViewState["ProspectId"] != null)
                {
                    htParam.Add("@AppNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htParam.Add("@AppNo", System.DBNull.Value);
                }
            }

            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            DataSet dscandtype = new DataSet();
            Hashtable htcndtyp = new Hashtable();
            if (txtcndid.Text != "")
            {
                htcndtyp.Add("@CndNo", txtcndid.Text);
            }
            else
            {
                if (ViewState["ProspectId"] != null)
                {
                    htcndtyp.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    htcndtyp.Add("@CndNo", System.DBNull.Value);
                }
            }
            dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htcndtyp);
            if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
            {
                htParam.Add("@ReqType", "Rnwl");
            }
            else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
            {
                htParam.Add("@ReqType", "ReExam");
            }
            else
            {
                htParam.Add("@ReqType", "HrTrn");
            }
            htParam.Add("@PAN", txtCurrentID.Text.Trim());
            if (ddlFessWav.SelectedValue == "Y")
            {
                htParam.Add("@WaiverFlag", "1");
            }
            else
            {
                htParam.Add("@WaiverFlag", "0");
            }
            if (strAdvWaiverExt.ToUpper().Trim() == "doc" || strAdvWaiverExt.ToUpper().Trim() == "DOC")
            {
                htParam.Add("@AdvWaiverForm", lblCndNoValue.Text.Trim() + "_AdvWaiver.DOC");
            }
            else if (strAdvWaiverExt.ToUpper().Trim() == "GIF" || strAdvWaiverExt.ToUpper().Trim() == "gif")
            {
                htParam.Add("@AdvWaiverForm", lblCndNoValue.Text.Trim() + "_AdvWaiver.GIF");
            }
            else if (strAdvWaiverExt.ToUpper().Trim() == "JPG" || strAdvWaiverExt.ToUpper().Trim() == "jpg")
            {
                htParam.Add("@AdvWaiverForm", lblCndNoValue.Text.Trim() + "_AdvWaiver.JPG");
            }
            else if (strAdvWaiverExt.ToString().Trim() == "" || strAdvWaiverExt.ToString().Trim() == null)
            {
                htParam.Add("@AdvWaiverForm", System.DBNull.Value);
            }
            htParam.Add("@PanFlag", "");
            if (ddlFessWav.SelectedValue == "Y" && ChkFeesWavier.Enabled == false)
            {
                htParam.Add("@AutoWavierFlag", "Y");
                htParam.Add("@AutoWavierFlagBy", "System");
            }
            else if (ddlFessWav.SelectedValue == "Y" && ChkFeesWavier.Enabled == true)
            {
                htParam.Add("@AutoWavierFlag", "Y");
                htParam.Add("@AutoWavierFlagBy", HttpContext.Current.Session["UserID"].ToString());
            }
            dsFees.Clear();
            dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsertTrnReqDtl", htParam);
        }
        #endregion

        DataSet dscno = new DataSet();
        Hashtable htcndno = new Hashtable();
        htcndno.Add("@Appno", ViewState["ProspectId"].ToString().Trim());
        dscno = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_upd_Cndo", htcndno);
    }

    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblupdSize = (Label)e.Row.FindControl("lblupdSize");
            Label lbldocName = (Label)e.Row.FindControl("lbldocName");// by meena
            Label lblManDoc = (Label)e.Row.FindControl("lblManDoc");
            Button btn_Upload = (Button)e.Row.FindControl("btn_Upload");
            Button btn_ReUpload = (Button)e.Row.FindControl("btn_ReUpload");
            Label lbldoccode = (Label)e.Row.FindControl("lbldoccode");
            LinkButton lnkPreview = (LinkButton)e.Row.FindControl("lnkPreview");
            if (lblupdSize != null && lblupdSize.Text != "")
            {
                int updsize = Convert.ToInt32(lblupdSize.Text);
                int sizeupd = updsize / 1024;
                lblupdSize.Text = Convert.ToString(sizeupd);
            }
            if (lbldocName.Text == "Code of Conduct-Page 2" || lbldocName.Text == "Name change document - Marriage Certificate / Affidavit"
                || lbldocName.Text == "Form IRDA-Agent-IA-Page 2" || lbldocName.Text == "ECS payment - Mandate Form") { }
            if (lblManDoc.Text == "Y")
            {
                Label lblMandate = (Label)e.Row.FindControl("lblManDoc");
                Label MandocName = (Label)e.Row.FindControl("MandocName");
                lblMandate.Visible = true;
                MandocName.ForeColor = System.Drawing.Color.Red;
                MandocName.Visible = true;
            }
            else if (lblManDoc.Text == "C" && lbldoccode.Text == "15")
            {
                Hashtable htPanchayat = new Hashtable();
                DataSet ds_panchayat = new DataSet();
                htPanchayat.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_CheckForPanchayat", htPanchayat);
                if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                {
                    Label lblMandate = (Label)e.Row.FindControl("lblManDoc");
                    lblMandate.Visible = true;
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
            }
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            if (Request.QueryString["CndNo"] != null)
            {
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            }
            else
            {
                if (Request.QueryString["ProspectId"] == null)
                {
                    httable1.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
                }
                else
                {
                    httable1.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
                }
            }

            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            DataSet dsdtl = new DataSet();
            dsdtl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            Hashtable htparam = new Hashtable();
            //if (Request.QueryString["CndNo"] != null)
            //{
            //    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            //}
            //else
            //{
            //    htparam.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            //}
            if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "PR")
            {
                htparam.Add("@CndNo", Request.QueryString["ProspectId"].ToString().Trim());
            }
            else if (Request.QueryString["type"] == "N")
            {
                htparam.Add("@CndNo", ViewState["ProspectId"].ToString().Trim());
            }
            else if (Request.QueryString["type"] == "E" && Request.QueryString["ACT"] == "Edit")
            {
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            }
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                if (ddlCandidatetype.SelectedValue == "T")
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (ddlCandidatetype.SelectedValue == "C")
                {
                    htparam.Add("@CandType", 'C');
                }
                else if (ddlCandidatetype.SelectedValue == "F")
                {
                    htparam.Add("@CandType", 'F');
                }
            }
            else
            {
                htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            }
            htparam.Add("@ModuleCode", Code.Trim());
            htparam.Add("@TypeofDoc", "UPLD");
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                htparam.Add("@InsurerType", "");
                if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "SP");
                }
                else
                {
                    htparam.Add("@ProcessType", "NR");
                }
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "RE");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "RenTrn")
            {
                htparam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                htparam.Add("@ProcessType", "RW");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "ReExam")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "RE");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "RW");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "E")
            {
                htparam.Add("@InsurerType", "");
                htparam.Add("@ProcessType", "NR");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "R")
            {
                if (Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).ToString().Trim() != "")
                {
                    htparam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                }
                else
                {
                    htparam.Add("@InsurerType", "");
                }
                htparam.Add("@ProcessType", Convert.ToString(dsdtl.Tables[0].Rows[0]["ProcessType"]).Trim());

            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "QC")
            {
                htparam.Add("@ProcessType", Convert.ToString(dsdtl.Tables[0].Rows[0]["ProcessType"]).Trim());
            }
            htparam.Add("@doccode", lbldoccode.Text);
            DataSet dsUpldImg = new DataSet();
            dsUpldImg = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocCode", htparam);
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

    protected void btnexit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["ACT"] == "Rev")
            {
                Response.Redirect("CndEnq.aspx?Type=CndRev");
            }

            else if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["type"] == "E")
            {
                Response.Redirect("~/Application/ISys/Recruit/CndEnq.aspx?ACT=Edit&type=E");
            }

            else if (Request.QueryString["ACT"] == "PR" && Request.QueryString["type"] == "E")
            {

                Response.Redirect("~/Application/ISys/Recruit/CndEnq.aspx?ACT=PR&type=E");
            }
        }
        if (Request.QueryString["Type"] == "M")
        {
            Response.Redirect("CndEnq.aspx?Type=M");
        }

        if (Request.QueryString["Type"] == "N")
        {
            string ModuleID1 = Request.QueryString["ModuleID"].ToString().Trim();
            string AgtType = Request.QueryString["AgtType"].ToString();
            string ACT = Request.QueryString["ACT"].ToString();
            Response.Redirect("CndEnq.aspx?Type=N&ModuleID=" + ModuleID1 + "&AgtType=" + AgtType + "&Code=" + "Spon" + "&ACT=" + ACT);
        }
    }

    protected void ddlSts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSts.SelectedIndex == 2)
        {
            lblDateOfCessation.Visible = true;
            txtDateOfCessation.Visible = true;
        }
        else
        {
            lblDateOfCessation.Visible = false;
            txtDateOfCessation.Visible = false;
        }
    }

    protected void btnPrev8_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btndocsave.Visible = false;
        btnPrev8.Visible = false;
        divpanel9.Visible = false;
        btnPrev7.Visible = true;
        btnNextPannel8.Visible = true;
        divpanel8.Visible = true;
        divPH.Attributes.Add("style", "color:#00cccc !important;");
        span8.Attributes.Add("style", "background-color: #00cccc !important");
        span8.Attributes.Add("style", "background-color: #00cccc !important");
        divDUH.Attributes.Add("style", "color:#c8c8c !important;");
        span9.Attributes.Add("style", "background-color: #c8c8c !important");
        span9.Attributes.Add("style", "background-color: #c8c8c !important");
    }


    protected void gvComposite_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlSts.SelectedIndex == 1)
        {
            e.Row.Cells[4].Visible = false;
        }
        else
        {
            e.Row.Cells[4].Visible = true;
        }
    }

    protected void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboTitle.SelectedValue == "MR" || cboTitle.SelectedValue == "MAST" || cboTitle.SelectedValue == "SHRI")
        {
            cboGender.SelectedValue = "M";
            cboGender.Enabled = false;
            txtDOB.Enabled = true;
            cboMaritalStatus.Enabled = true;
            txtFathername.Enabled = true;
            ddlCasteCat.Enabled = true;
            ddlRelwithFather.Enabled = true;
        }
        else if (cboTitle.SelectedValue == "MRS" || cboTitle.SelectedValue == "MISS" || cboTitle.SelectedValue == "SMT")
        {
            cboGender.SelectedValue = "F";
            cboGender.Enabled = false;
            txtDOB.Enabled = true;
            cboMaritalStatus.Enabled = true;
            txtFathername.Enabled = true;
            ddlCasteCat.Enabled = true;
            ddlRelwithFather.Enabled = true;
        }
        else if (cboTitle.SelectedValue == "M/S")
        {
            cboGender.SelectedIndex = 0;
            cboGender.Enabled = false;
            txtDOB.Enabled = false;
            cboMaritalStatus.Enabled = false;
            txtFathername.Enabled = false;
            ddlCasteCat.Enabled = false;
            ddlRelwithFather.Enabled = false;
            cboGender.SelectedIndex = 0;
            txtDOB.Text = "";
            cboMaritalStatus.SelectedIndex = 0;
            txtFathername.Text = "";
            ddlCasteCat.SelectedIndex = 0;
            ddlRelwithFather.SelectedIndex = 0;
        }
        else
        {
            cboGender.Enabled = true;
            cboGender.Focus();
            txtDOB.Enabled = true;
            cboMaritalStatus.Enabled = true;
            txtFathername.Enabled = true;
            ddlCasteCat.Enabled = true;
            ddlRelwithFather.Enabled = true;
        }
    }

    protected bool DateDiff(string txtbox1, string txtbox2)
    {
        DateTime StartDate = Convert.ToDateTime(txtbox1);
        DateTime EndDate = Convert.ToDateTime(txtbox2);
        TimeSpan Span = EndDate - StartDate;
        DateTime Age = DateTime.MinValue + Span;
        int Years = Age.Year - 1;
        int Months = Age.Month - 1;
        int Days = Age.Day - 1;
        if (Years < 18)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}


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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Insc.MQ.Life.AgnMd;
using INSCL.App_Code;
using INSCL.DAL;
using Insc.Common.Multilingual;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using SD = System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using DataAccessClassDAL;
using System.Web.Script.Serialization;
//Added by rachana for fees details Webservice start
using SysInrgConsum;
using System.ServiceModel;
using Microsoft.Reporting.WebForms;
//Added by rachana for fees details Webservice end
public partial class Application_ISys_ChannelMgmt_FranchiesEnrollment_FPAdvTrnHrsReqSubmit : BaseClass
{

    protected System.Web.UI.HtmlControls.HtmlInputFile FileInput;

    #region Global declaration
    

    DataSet dsImage = new DataSet();



    ErrLog objErr = new ErrLog();//Added by rachana on 10-12-2013 for error log
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    private DataAccessClass dataAccessRecruit = new DataAccessClass();

    private multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    DataTable dtResult = new DataTable();
    DataSet dsResult = new DataSet();
    SqlDataReader drResult;
    Hashtable htParam = new Hashtable();
    Hashtable htParam1 = new Hashtable();
    string strSQL = string.Empty;
    StringBuilder sbSQL = new StringBuilder();
    char[] chrFileSplt;
    string strFileType = string.Empty;
    int intValue;
    string imgpaths = string.Empty;
    string strProcessType;
    string strCandtype;
    string[] strArrFilSplt;
    public static string UpLdFSize = "10";
    public static string UpLdFSize_Photo = "50";
    private string strDestDir = string.Empty;
    private string strFileName = string.Empty;
    private string strDestPath = string.Empty;
    private Hashtable htdata = new Hashtable();
    int ECRMFlag;
    string strXML = "";
    string ErrMsg, AuditType;
    string strSourcePath = string.Empty;
    string destFile = string.Empty;
    string strPhotoName = string.Empty;
    string strSignName = string.Empty;
    string strPhotoExt = string.Empty;
    string strSignExt = string.Empty;
    string strAdvWaiverExt = string.Empty;
    string strAdvWaiverName = string.Empty;
    string strPANName = string.Empty;
    string strPANExt = string.Empty;
    string strCat = string.Empty;
    string strArf1 = string.Empty;
    string strArf1Ext = string.Empty;
    string strArf2 = string.Empty;
    string strArf2Ext = string.Empty;
    string strEduProof1 = string.Empty;
    string strEduProof1Ext = string.Empty;
    string strEduProof2 = string.Empty;
    string strEduProof2Ext = string.Empty;
    //Added by rachana 16/12/2013 for Transfer case check start
    string strNocDocName = string.Empty;
    string strNocDocExt = string.Empty;
    string strPanchayatDocExt = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    int BMaxImgSize; //= Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxImgSize"]);
    int BMaxImgSize1;
    //string strPath = @"..\Application\INSC\Recruit\UploadedFiles\";
    string imagePath;
    byte[] imgBytes;
    //Added by pranjali start
    string strDocName = string.Empty;
    private string strFileName1 = string.Empty;
    string DocStatusCount;
    DataSet ds_documentName = new DataSet();
    //Added by pranjali end
    DataSet ds_image = new DataSet();
    int intcount;
    string strimgage = string.Empty;
    string strdocno = string.Empty;
    string strimgdesc = string.Empty;
    //Added by rachana 16/12/2013 for Transfer case check end

    private clsAgent agentObject = new clsAgent();
    //Added for File Upload/reupload binary conversion part start
    static int image_height;
    static int image_width;
    static int max_height;
    static int max_width;
    static byte[] data;
    static string filename;
    static string contenttype;
    string str;
    string doctype;
    //Added for File Upload/reupload binary conversion part end
    string usertype = string.Empty;
    DataAccessClass objDAL = new DataAccessClass(); //added by pranjali on 03-03-2014
    string strCndType = string.Empty;//added by rachana to store cand type

    string candtype; //added by pranjali on 25-03-2014
    string strcallerSystem = System.Configuration.ConfigurationManager.AppSettings["CallerSystem"].ToString();
    public string Code { get; set; } //added by pranjali on 15042014
    string IsPriorAgt = string.Empty;
    string ProcessType = string.Empty;
    string IsRenewal = string.Empty;////19052015
    string strProspectID = string.Empty;
    //added by rachana for sysfreezedate start 
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    DateTime Lcndt;
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    string CandidateType;
    //added by rachana for sysfreezedate end
    Hashtable htPan = new Hashtable();

    String ModuleID = string.Empty;//Added by usha on 25.06.2021
    string strMemType = string.Empty;//added by sanoj 27-12-2021
    string strRpt = System.Configuration.ConfigurationManager.AppSettings["Report"].ToString();
    #endregion

    #region Page_Load Events events
    protected void Page_Load(object sender, EventArgs e)
   {
        try
        {
            RbtNoc.AutoPostBack = true;
            RbtNoc.SelectedIndexChanged += new EventHandler(RbtNoc_SelectedIndexChanged);

            if (!IsPostBack)
            {
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }

                Session["CarrierCode"] = '2';
                olng = new multilingualManager("DefaultConn", "AdvTrnHrsReqSubmit.aspx", Session["UserLangNum"].ToString());
                
           

                if (!IsPostBack)
                {
                    ViewState["Gst"] = "gst";
                    ViewState["Sig"] = "sig";
                    //added by daksh on 28082020
                   GetCandidateDtls();
                    // added by daksh 

                    DataSet dsIsSpPrsn = new DataSet();
                    dsIsSpPrsn = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
                    ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();
                    hdnRotateValue.Value = "0"; //added by amruta 1/8/16 for rotation of image 
                    if (dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim() == "YES")
                    {
                        divIsSpecified.Attributes.Add("style", "display:block");
                    }
                    else
                    {
                        divIsSpecified.Attributes.Add("style", "display:none");
                    }
                    hdnUserId.Value = Session["UserID"].ToString().Trim();
                    InitializeControl();
                    //Comneted by sanoj 27-12-2021
                    //PopulateExamMode();//added by pranjali on 10-04-2014 for binding exam mode
                    //PopulatePreExmLanguages(); //added by pranjali on 10-04-2014 for exam languages
                    // PopulateExmBodyName(); //added by pranjali on 10-04-2014 for binding exambody name

                    //PopulateNewExamMode();//added by pranjali on 28-04-2014 for binding new exam mode



                    ///PopulateExamCode();//added by amruta on 16.6.2015 for binding examcode for trnsfer
                    //PopulateCasteCat();
                    //PopulateBasicQual();
                    //PopulateProofIDDoc();
                    //PopulateCompInsurerName();//added by pranjali on 13-03-2014 for binding composite insurername dropdwn
                    //PopulateTrnsfrInsurerName();//added by pranjali on 13-03-2014 for binding trnsfr insurername dropdwn
                    //PopulateTrainingMode();

                    //GetRenewalDtls();
                    //GetReExamDtls();
                    //GetCandidateDtls();
                    //Comneted Ended by sanoj 27-12-2021

                    tr2.Visible = false;//Nikhil
                    tr3.Visible = false;
                    trmsg.Visible = false;
                   
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
                        {
                            lblhead.Visible = false;
                            btnnectcfr.Visible = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //chkURNExistorNot();
                            //Method for exam type
                            //FreezTrnInstLoc();
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExmCentre');return false;");//added by amruta on 16.6.15
                            //Added by rachana on 29-07-2013 for Quality check 29-07-2013                        
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tblexam.Visible = true;//added by amruta on 15.6.15
                            btnSave.Attributes.Add("Style", "display:none");
                            BtnApprove.Attributes.Add("Style", "display:none");
                            btnReject.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            Table1.Attributes.Add("Style", "display:none");
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            tr5.Visible = false;
                            trNoteTr.Visible = false;//Nikhil
                            //tr2.Visible = false;
                            btnAddComposite.Visible = false;
                            lblCompositeDtl.Visible = false;
                            divTrnsferDetails.Visible = false;
                            trTrnsfr1.Visible = false;
                            trTrnsfr2.Visible = false;
                            trTrnsfr3.Visible = false;
                            trTrnsfr4.Visible = false;
                            trTrnsfr5.Visible = false;
                            tr5.Visible = false;
                            //tblFeesWavier.Visible = true;//added by amruta on 25.7.15
                            ChkFeesWavier.Enabled = false;
                           
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                            //CompositeTitle.Visible = true;
                            //trnsfrtitle.Visible = true;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            divCompositeDetails.Visible = false;
                          
                        }

                        #region VIEW section
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "V")
                        {
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            viewData(Request.QueryString["MemCode"].ToString().Trim());
                            Filluploadedfile();//Added by pranjali on 02-01-2013 to fill document type grid
                            btnSubmit.Visible = false;
                            AdvWaiverUpload.Visible = false;
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tbltrn.Visible = false;
                            //tblAdv.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse cfr section
                            lblCndView.Visible = false; //Added by rachana on 07032014
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                        }
                        #endregion

                        #region EDIT section
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                        {
                            trTokenwithFees.Visible = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            //txtFeesRcvd.Attributes.Add("Style", "display:none"); btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            if (Session["UserID"].ToString().Trim() != "admin")
                            {
                                //string strcfr = Request.QueryString["CfrFor"].ToString().Trim(); //Added by rachana on 02-01-2014
                                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('please upload " + strcfr + "')", true);//Added by rachana on 02-01-2014
                            }
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            Filluploadedfile();//Added by pranjali on 02-01-2013        
                            ChkPhotoNotExist_Repeater();
                            btnSubmit.Visible = true;
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            btnSubmit.Text = "Update";
                            //divApprove.Visible = false; 
                            BtnApprove.Visible = false;//Visibility changed by rachana on 19122013
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //commented by pranjali on 02-01-2014 start
                            //AgnPhotoUpload.Enabled = true;
                            //AgnSignUpload.Enabled = true;
                            //PANUpload.Enabled = true;
                            //commented by pranjali on 02-01-2014 end
                            //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start                 
                            //lblTitle.Text = "Sponsorship Request Submit";
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            divAgnPhotoTrnExmDtl.Visible = true;
                            tblexam.Visible = true;
                            //Added by rachana on 29-07-2013 for Quality check 29-07-2013 end

                            if (Request.QueryString["PANFlag"] != null)
                            {
                                if (Request.QueryString["PANFlag"].ToString().Trim() == "Y")
                                {
                                    //commented by pranjali on 02-01-2014 start
                                    //AgnPhotoUpload.Enabled = false;
                                    //AgnSignUpload.Enabled = false;
                                    //commented by pranjali on 02-01-2014 end
                                }
                            }

                            tbltrn.Visible = false;
                            //tblAdv.Visible = false;
                            //tblexam.Visible = false; //commented by pranjali on 10-04-2014
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse cfr section
                            lblCndView.Visible = false; //Added by rachana on 07032014
                          
                            lblExamTitle.Text = "Exam Details";//added by pranjali on 28-04-2014
                        }
                        #endregion
                        #region QC NOC
                        //comented by usha on 27/12/2021
                        //if (Request.QueryString["TrnRequest"].ToString().Trim() == "NOCQc")
                        //{

                        //    hdnModuleId.Value = Request.QueryString["ModuleID"].ToString().Trim();
                        //    trGivenName.Attributes.Add("Style", "display:none");
                        //    trFatherName.Attributes.Add("Style", "display:none");
                        //    div1.Attributes.Add("Style", "display:none");
                        //    div2.Attributes.Add("Style", "display:none");
                        //    pnlcfrdtls.Attributes.Add("Style", "display:none");
                        //    tblPrefExm.Visible = false;
                        //    ViewState["feescount"] = "";
                        //    SetInitialRow();
                        //    tbltrn.Visible = false;
                        //    divCFRInbox.Visible = true;
                        //    tblPrefExm.Visible = false;
                        //    Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                        //    btnSave.Visible = true;
                        //    lblNote.Visible = false;//added by pranjali on 04-03-2014
                        //    lblCndView.Visible = true;
                        //    //trtran.Visible = true;
                        //    divTrnsferDetails.Attributes.Add("Style", "display:none");
                        //    divCompositeDetails.Attributes.Add("Style", "display:none");
                        //    tblreasonnoc.Visible = true;
                        //    tblreasonNOC1.Visible = true;
                        //    tblremarkinsurer.Visible = true;
                        //    trAgency.Visible = true;
                        //    trMob.Visible = true;
                        //    trdos.Visible = true;
                        //    trEmail.Visible = false;
                        //    tblEmsdtls.Attributes.Add("style", "display:none");
                        //    trMobile.Visible = false;
                        //    trRequest.Visible = false;
                        //    trBranch.Visible = false;
                        //    tbltrn.Visible = false;
                        //    Divtrndtls.Attributes.Add("Style", "display:none");
                        //    tblResonInsurer.Visible = true;
                        //    trnsfrtitle.Visible = false;
                        //    CompositeTitle.Visible = false;
                        //    divCndTrnsDtls.Attributes.Add("Style", "display:none");
                        //    tblCFRInboxCollapse.Visible = true;
                        //    tblIcmColl.Visible = false;
                        //    tblICMManual.Visible = false;
                        //    divICM.Visible = false;
                        //    DivICMDtls.Visible = false;
                        //    //btnprev.Enabled = false;
                        //    // BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                        //    #region photo shuffle start added by rachana on 01-07-2013
                        //    dsResult.Clear();
                        //    htParam.Clear();
                        //    htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                        //    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetDocType", htParam);
                        //    if (dsResult.Tables.Count > 0)
                        //    {
                        //        if (dsResult.Tables[0].Rows.Count > 0)
                        //        {
                        //            ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                        //            ViewState["DocNo"] = dsResult.Tables[0].Rows[0]["DocCode"].ToString(); //added by pranjali on 21-05-2014 for getting doccode in raise cfr
                        //            hdnDocCode.Value = ViewState["DocNo"].ToString();//added by pranjali on 21-05-2014
                        //            ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                        //        }
                        //    }
                        //    #endregion
                        //    //  PopulateTrainingMode();//added by pranjali on 03-03-2014
                        //    this.Page.Title = "Online Candidate Verification";

                        //    trReject.Visible = true;
                        //    CatApp(ddlcatapp);
                        //    hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                        //    txtReInsurer.Text = "";
                        //    FillData1(Request.QueryString["MemCode"].ToString().Trim());
                        //    lblTitle.Text = "Online Candidate Verification";
                        //    lblCndName.Text = "Candidate Name";

                        //    btnSubmit.Visible = false;
                        //    btnSubmit.Text = "Submit";
                        //    //divApprove.Visible = true; 
                        //    BtnApprove.Visible = true;
                        //    btnedit.Visible = true;
                        //    //divReject.Visible = true; 
                        //    btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        //    divnavigate.Visible = true;
                        //    tblphoto.Visible = true;
                        //    imgCrop.ImageUrl = strimgage;

                        //    if (dsResult.Tables[0].Rows.Count > 0)
                        //    {
                        //        lblpanelheader.Text = ViewState["docType"].ToString();
                        //        hdnDocId.Value = ViewState["docCode"].ToString();//01
                        //    }


                        //    divAgnPhotoTrnExmDtl.Visible = false;//added by pranjali on 11-04-2014
                        //    BtnCFR.Visible = true;
                        //    //divCFR.Visible = true;
                        //    EnableDisableControls();//to enable and disabled Approve button and Training details                        
                        //    //PopulateTrnType();
                        //    tblupload.Visible = false;



                        //    BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");

                        //    //}
                        //    //Added by pranjali on 25-03-2014 for transfer case training details part non-mandatory end
                        //    //btnprev.Enabled = false;
                        //    BindGrid();

                        //    //Added by rachana on 02-01-2014 for confirmation of approval start
                        //    tblCFRInbox.Visible = false;
                        //    divCFRInbox.Attributes.Add("Style", "display:none");
                        //    tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls

                        //    Chkpan.Enabled = false;//disabled only on QC page
                        //    btnReject.Visible = true;
                        //    if (txtReInsurer.Text == "")
                        //    {
                        //        txtReInsurer.Enabled = true;
                        //    }


                        //}
                        //comented end  by usha on 27 / 12 / 2021
                        #endregion
                        #region QC section
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start 
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            hdnModuleId.Value = Request.QueryString["ModuleID"].ToString().Trim();
                            //#region ICM related
                            //trTokenwithFees.Visible = true;
                            //PopulateICMStatus();
                            //PopulateICMPaymentMode();
                            //#endregion
                            lblhead.Visible = false;
                            btnnectcfr.Visible = false;
                            #region QC Normal
                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");
                            ChkFeesWavier.Enabled = false;
                            ViewState["feescount"] = "";
                            //SetInitialRow();
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            btnSave.Visible = false;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblNote1.Visible = false;//added by usha on 16-06-2022
                            lblCndView.Visible = true;
                         
                            //tblcomp.Attributes.Add("Style", "display:none");
                            //CompositeTitle.Visible = true;
                            //btnAddTrnsfr.Visible = false;
                            //tblFeesWavier.Visible = true;//added by amruta on 25.7.15 for fees wavier
                            
                            //btnAddComposite.Visible = false;
                            //gvComposite.Columns[6].Visible = false;
                            //gvTrnsfr.Columns[7].Visible = false;
                            Tr1.Visible = false;
                            tr2.Visible = false;
                            tr3.Visible = false;
                            trNoteTr.Visible = false;
                            //tbcomp.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                            divCompositeDetails.Visible = false;
                            divTrnsferDetails.Visible = false;
                            trTrnsfr1.Visible = false;
                            trTrnsfr2.Visible = false;
                            trTrnsfr3.Visible = false;
                            trTrnsfr4.Visible = false;
                            trTrnsfr5.Visible = false;
                            tr5.Visible = false;
                           // GetCandidateType();
                            //Added new code bhau 13/06/2017
                            tblbnkdtls.Visible = false;
                            divbnkdtls.Visible = false;
                            TrRptMgr.Visible = false;

                            

                            //if (strCndType == "T")
                            //{

                            //    trNoteTr.Visible = false;
                            //    btnAddTrnsfr.Visible = false;
                            //    if (gvTrnsfr.Rows.Count != 0)
                            //    {
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //    }
                            //}
                           
                            //else if (strCndType == "C")
                            //{
                            //    tdExmmode1.Visible = true;
                            //    tdExmmode2.Visible = true;
                            //    tdExmBody1.Visible = true;
                            //    tdExmBody2.Visible = true;
                            //    tdPreExm.Visible = true;
                            //    tdPreExmlng.Visible = true;
                            //    tdExmCenter1.Visible = true;
                            //    tdExmCenter2.Visible = true;
                            //    tdExmCode1.Visible = false;
                            //    tdExmCode2.Visible = false;
                            //    tdExmDt1.Visible = false;
                            //    tdExmDt2.Visible = false;
                            //    trCndExm.Visible = false;
                            //    btnAddComposite.Visible = false;
                            //    trNoteTr.Visible = false;
                            //    tr5.Visible = false;
                            //    txtCndURNNo.Visible = false;
                            //    lblcndURNVal.Visible = false;
                            //    lblcndURNNo.Visible = false;
                            //    tdCndURNNo.Visible = false;

                            //    if (gvComposite.Rows.Count != 0)
                            //    {
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //    }
                            //}
                            //else
                            //{
                                 
                                tdExmmode1.Visible = true;
                                tdExmmode2.Visible = true;
                                tdExmBody1.Visible = true;
                                tdExmBody2.Visible = true;
                                tdPreExm.Visible = true;
                                tdPreExmlng.Visible = true;
                                tdExmCenter1.Visible = true;
                                tdExmCenter2.Visible = true;
                                tdExmCode1.Visible = false;
                                tdExmCode2.Visible = false;
                                tdExmDt1.Visible = false;
                                tdExmDt2.Visible = false;
                                trCndExm.Visible = false;
                                btnAddComposite.Visible = false;
                                trNoteTr.Visible = false;
                                tr5.Visible = false;
                                txtCndURNNo.Visible = false;
                                lblcndURNVal.Visible = false;
                                lblcndURNNo.Visible = false;
                                tdCndURNNo.Visible = false;

                                //Added new code bhau 13/06/2017
                                tblbnkdtls.Visible = false;
                                divbnkdtls.Visible = false;

                                //End Added new code bhau 13/06/2017

                           // }


                            // BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            #region photo shuffle start added by rachana on 01-07-2013
                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                    ViewState["DocNo"] = dsResult.Tables[0].Rows[0]["DocCode"].ToString(); //added by pranjali on 21-05-2014 for getting doccode in raise cfr
                                    hdnDocCode.Value = ViewState["DocNo"].ToString();//added by pranjali on 21-05-2014
                                    ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                                }
                            }
                            #endregion
                           // PopulateTrainingMode();//added by pranjali on 03-03-2014
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";

                            btnSubmit.Visible = false;
                            btnSubmit.Text = "Submit";
                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
                            btnReject.Visible = false;
                            btnedit.Visible = true;
                            //divReject.Visible = true; 
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;

                            ////added by usha for hide the repeter document on 11.08.2016
                            //if (ProcessType == "RE")
                            //{

                            //    Panelphoto2.Visible = false;
                            //    divnavigate.Visible = false;
                            //    tblCFRInboxCollapse.Visible = false;
                            //    divCFRInbox.Visible = false;
                            //    tblupload.Visible = false;
                            //    btnSave.Visible = false;
                            //    btnedit.Visible = false;
                            //    //Added new code bhau 13/06/2017
                            //    tblbnkdtls.Visible = false;
                            //    divbnkdtls.Visible = false;

                            //    //End Added new code bhau 13/06/2017
                            //}
                            //ended  by usha for hide the repeter document on 11.08.2016
                            //if (ProcessType != "RE")
                            //{

                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    lblpanelheader.Text = ViewState["docType"].ToString();
                                    hdnDocId.Value = ViewState["docCode"].ToString();//01
                                }
                          //  }

                          //  GetCandidateType();
                            //if ((IsPriorAgt == "1") || (strCndType == "T") || (ProcessType == "RW") || (strCndType == "P"))//Added by usha on 09.03.2020
                            //{
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                Divtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;
                                btnAddComposite.Visible = false;
                                //if (strCndType == "P")
                                //{
                                    trnsfrtitle.Visible = false;
                                    CompositeTitle.Visible = false;
                                    divTrnsferDetails.Attributes.Add("Style", "display:none");
                                    divCompositeDetails.Attributes.Add("Style", "display:none");
                            //    }

                            //}

                            //else
                            //{
                            //    tblEmsdtls.Visible = true;
                            //    tblexam.Visible = true;
                            //    tbltrn.Visible = true;
                            //}
                            if (strCndType == "T")
                            {





                                lblTrnsfrReqNo.Visible = true;
                                TxtTrnsfrReqNo.Visible = true;
                                btnAddComposite.Visible = false;
                            }
                            divAgnPhotoTrnExmDtl.Visible = true;//added by pranjali on 11-04-2014
                            BtnCFR.Visible = true;
                            //divCFR.Visible = true;
                            EnableDisableControls();//to enable and disabled Approve button and Training details                        
                           // PopulateTrnType();
                            tblupload.Visible = false;

                            if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                            {
                                candtype = "T";
                            }
                            else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                            {
                                candtype = "T";
                            }
                            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                            {
                                candtype = "C";
                                //divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014
                                //BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            }
                            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                            {
                                candtype = "F";
                            }
                            //if (candtype != "T")
                            //{

                            BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");

                            //}
                            //Added by pranjali on 25-03-2014 for transfer case training details part non-mandatory end
                            //BindGrid();
                            //btnprev.Enabled = false;
                            //Added by rachana on 02-01-2014 for confirmation of approval start
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls

                         
                            //added by pranjali on 26-03-2014 start
                            //Hashtable httable = new Hashtable();
                            //DataSet dscandtype = new DataSet();
                            //httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
                            //strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();
                            //lblExamTitle.Text = "Exam Details";//added by pranjali on 28-04-2014
                            //if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                            //{

                            //}
                            //else
                            //{
                            //    GetTokenNoforDisplay();
                            //}
                            //if (ViewState["RenewalFlag"].ToString() == "" && ViewState["RnwlQCFlag"] == "" && ViewState["ReExamFlag"] == "")
                            //{
                            //    //BindFeesDetails();
                            //    PopulateFees();//added by rachana on 22082014
                            //}
                            #endregion

                             #region Renewal QC
                            //Hashtable htren = new Hashtable();
                            //htren.Clear();
                            //DataSet dsren = new DataSet();
                            //dsren.Clear();
                            //htren.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dsren = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htren);
                            //hdnrenwlflag.Value = dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                            ////viewstate for inserting fees details
                            //ViewState["RenewalFlag"] = dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                            //if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")//Renewal QC
                            //{
                            //    btnReject.Visible = false; //added by amruta on 4/8/2016 to hide reject button
                              
                           
                            //    tblRenewalCollapse.Visible = true;
                            //    divRenewal.Visible = true;
                            //    Comp.Attributes.Add("Style", "display:none");
                            //    trTokenwithFees.Visible = false;
                            //    tblIcmColl.Visible = false;
                            //    DivICMDtls.Attributes.Add("Style", "display:none");
                            
                            //    txtPAN.Enabled = false;
                            //    //Added new code bhau 13/06/2017
                            //    tblbnkdtls.Visible = false;
                            //    divbnkdtls.Visible = false;

                            //    //End Added new code bhau 13/06/2017
                            //    htParam.Clear();
                            //    dsResult.Clear();
                            //    htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                            //    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRenewalRecrd", htParam);
                            //    string strcnd = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString();
                            //    //2nd time QC
                            //    if (dsren.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
                            //    {
                            //        FeesRow.Visible = true;
                            //        trTokenwithFees.Attributes.Add("Style", "display:block");
                            //        PopulateFees();
                                     
                            //        tblIcmColl.Visible = true;
                                    
                            //        if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                            //        {

                            //        }
                            //        else
                            //        {
                            //            GetTokenNoforDisplay();
                            //            GetTotalFeesBasedOnLcnExpDate();
                            //        }
                            //        if (dsResult.Tables.Count > 0)
                            //        {
                            //            if (dsResult.Tables[0].Rows.Count > 0)
                            //            {
                            //                lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                            //                lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                            //                lbltxtQCRenewType.Text = dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                            //                lbltxtQClyfTraining.Text = dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                            //            }
                            //        }
                            //        if (strcnd.ToString().Trim() == "Fresh")
                            //        {
                            //            cbTccCompLcn.Enabled = false;
                            //            trCompQC.Visible = false;
                            //            Comp.Attributes.Add("Style", "display:none");
                            //            hdnCandTypeRen.Value = strcnd;
                            //            lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                            //            lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                            //        }
                            //        else if (strcnd.ToString().Trim() == "Transfer")
                            //        {
                            //            tbltrndtls.Visible = false;
                            //            cbTccCompLcn.Enabled = false;
                            //            trCompQC.Visible = false;
                            //            Comp.Attributes.Add("Style", "display:none");
                            //            hdnCandTypeRen.Value = strcnd;
                            //            lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                            //            lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                            //        }
                            //        else
                            //        {
                            //            trCompQC.Visible = true;
                            //            if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "Follower")
                            //            {
                            //                lblQClyfTraining.Visible = false;
                            //                lbltxtQClyfTraining.Visible = false;
                            //            }
                            //        }
                            //        tbloldlic.Visible = true;
                            //        divoldlic.Visible = true;
                            //        Hashtable htrnwlQc = new Hashtable();
                            //        DataSet dsrnwlQC = new DataSet();
                            //        htrnwlQc.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //        htrnwlQc.Add("@flag", "1");//fill data 
                            //        dsrnwlQC = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetLicDtls", htrnwlQc);
                            //        lbloldlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                            //        lbloldexpdateval.Text = dsrnwlQC.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                            //        //hdnoldlicexpdate.Value = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();//shree
                            //        lbloldlicissuval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();
                            //        tblnewlic.Visible = true;
                            //        divnewlic.Visible = true;
                            //        lblnewlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                            //        htdata.Clear();
                            //        ds_documentName.Clear();
                            //        htdata.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //        htdata.Add("@flag", "2");//fill new licnexpdate
                            //        ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetLicDtls", htdata);
                            //        if (ds_documentName != null)
                            //        {
                            //            if (ds_documentName.Tables.Count > 0)
                            //            {
                            //                if (ds_documentName.Tables[0].Rows.Count > 0)
                            //                {
                            //                    txtnewexpdate.Text = ds_documentName.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                            //                    txtnewexpdate.Enabled = false;
                            //                }
                            //            }
                            //        }
                                    
                            //        BtnApprove.Visible = true;
                            //        btnedit.Visible = true;
                            //        btnSave.Visible = false;
                            //        btnReject.Visible = false;
                                    
                            //    }
                            //    else
                            //    {
                            //        if (dsResult.Tables.Count > 0)
                            //        {
                            //            if (dsResult.Tables[0].Rows.Count > 0)
                            //            {
                            //                if (strcnd.ToString().Trim() == "Fresh" || strcnd.ToString().Trim() == "Transfer")
                            //                {

                            //                    Comp.Attributes.Add("Style", "display:none");
                            //                    hdnCandTypeRen.Value = strcnd;
                            //                    lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                            //                    lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                            //                    trlicn.Visible = true;
                            //                    lblLicnno.Visible = true;
                            //                    lbllicnoval.Visible = true;
                            //                    lblLicExpDt.Visible = false;
                            //                    txtlicno.Visible = false;
                            //                    txtLicExpDt.Visible = false;
                            //                    tbltrndtls.Visible = true;
                            //                    Divoldtrndtls.Attributes.Add("style", "display:block");
                            //                }
                            //                else
                            //                {
                            //                    Comp.Attributes.Add("Style", "display:block");
                            //                    hdnCandTypeRen.Value = strcnd;
                            //                    PopulateRenewalType();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                            //                    PopulateLifeTraining();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                            //                }
                            //            }
                            //        }
                            //        if (dsren.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                            //        {
                            //            tbltrndtls.Visible = false;
                            //            tbloldlic.Visible = true;
                            //            divoldlic.Visible = true;
                            //            Hashtable htrnwlQc = new Hashtable();
                            //            DataSet dsrnwlQC = new DataSet();
                            //            htrnwlQc.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //            htrnwlQc.Add("@flag", "1");//fill data 
                            //            dsrnwlQC = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetLicDtls", htrnwlQc);
                            //            lbloldlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                            //            lbloldexpdateval.Text = dsrnwlQC.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                            //            //hdnoldlicexpdate.Value = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();//shree
                            //            lbloldlicissuval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();
                            //            tblnewlic.Visible = true;
                            //            divnewlic.Visible = true;
                            //            lblnewlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                            //            htdata.Clear();
                            //            ds_documentName.Clear();
                            //            htdata.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //            htdata.Add("@flag", "2");//fill new licnexpdate
                            //            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetLicDtls", htdata);
                            //            if (ds_documentName != null)
                            //            {
                            //                if (ds_documentName.Tables.Count > 0)
                            //                {
                            //                    if (ds_documentName.Tables[0].Rows.Count > 0)
                            //                    {
                            //                        txtnewexpdate.Text = ds_documentName.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                            //                        txtnewexpdate.Enabled = false;
                            //                    }
                            //                }
                            //            }
                            //        }
                            //    }

                            //    tblEmsdtls.Visible = false;
                            //    tblexam.Visible = false;
                            //    divAgnPhotoTrnExmDtl.Visible = false;
                            //    //tbltrndtls.Visible = true;
                            //    tbloldexm.Visible = false;
                            //    if (dsren.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                            //    {
                            //        tbltrn.Visible = false;
                            //    }
                            //    else
                            //    {
                            //        tbltrn.Visible = true;
                            //    }
                            //    //trnsfrtitle.Visible = false;
                            //    divTrnsferDetails.Visible = false;//shreela 02/06/2014
                            //    lblpandetail.Visible = false;
                              
                            //    chkCompAgnt.Enabled = false;
                            //    tbltrn.Visible = false;//added by pranjali on 06.04.2015
                            //    tblRenewalCollapse.Visible = false;//added by pranjali on 06.04.2015
                            //    CompositeTitle.Visible = false;//added by pranjali on 06.04.2015
                                
                            //    trIsPriorAgt.Visible = false;//added by pranjali on 06.04.2015
                            //    Divtrndtls.Attributes.Add("style", "display:none");//added by pranjali on 06.04.2015
                            //    divTrnsferDetails.Attributes.Add("style", "display:none");//added by pranjali on 06.04.2015
                            //    divCompositeDetails.Attributes.Add("style", "display:none");//added by pranjali on 06.04.2015
                            //    tbltrndtls.Visible = false;
                            //    Divoldtrndtls.Attributes.Add("style", "display:none");
                            //    tblCndURN.Visible = false;
                            //    tbloldlic.Visible = false;
                            //    tblnewlic.Visible = false;
                            //    tblIcmColl.Visible = false;
                            //    tblICMManual.Visible = false;
                            //    TblFees.Visible = false;
                            //    trnsfrtitle.Visible = false;//Added by Nikhil on 28.11.16

                            //}
                            #endregion
                            //Added by kalyani to fetch Renewal record on QC module end
                            #region RE-Exam QC
                            //if (ChkFeesWavier.Checked == true)
                            //{
                            //    TblFees.Attributes.Add("Style", "display:none");
                            //    divFees.Attributes.Add("Style", "display:none");
                            //}
                            //Hashtable htrexm = new Hashtable();
                            //htrexm.Clear();
                            //DataSet dsReExm = new DataSet();
                            //dsReExm.Clear();
                            //htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dsReExm = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm);
                            //ViewState["ReExmType"] = dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
                            //ViewState["ReExamFlag"] = dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
                            ////added by pranjali on 29-04-2014
                            //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")     //Reexam QC //added by pranjali on 28-04-2014
                            //{
                            //    btnReject.Visible = false;  //added by amruta on 4/8/2016 to hide reject button
                            //    PopulateFees();//added by by rachana
                            //    tblNexam.Visible = false;//added by pranjali on 28-04-2014
                            //    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button start
                            //    //txtMobileNo.Enabled = false;//added by pranjali on 28-04-2014
                            //    //btnverifymobile.Enabled = false;//added by pranjali on 28-04-2014
                            //    //txtEMail.Enabled = false;//added by pranjali on 28-04-2014
                            //    //btnverifyemail.Enabled = false;//added by pranjali on 28-04-2014
                            //    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button end
                            //    tbltrn.Visible = false;
                            //    tbltrndtls.Visible = true;
                            //    tblExmSchedule.Visible = true;
                            //    tblPrefExm.Visible = false;
                            //    //BindFeesDetails();
                               
                            //    //trnsfrtitle.Visible = false;
                            //    divTrnsferDetails.Visible = false;
                            //    CompositeTitle.Visible = false;
                            //    divCompositeDetails.Visible = false;
                            //    trIsPriorAgt.Visible = false;
                            //    if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                            //    {

                            //    }
                            //    else
                            //    {
                            //        GetTokenNoforDisplay();
                            //    }
                            //    Divtrndtls.Attributes.Add("Style", "display:none");
                            //}
                            //else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")   //Reexam QC //added by pranjali on 28-04-2014
                            //{
                            //    PopulateFees();
                            //    tbltrn.Visible = true;//added by pranjali on 28-04-2014
                            //    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button start
                            //    //txtMobileNo.Enabled = false;//added by pranjali on 28-04-2014
                            //    //btnverifymobile.Enabled = false;//added by pranjali on 28-04-2014
                            //    //txtEMail.Enabled = false;//added by pranjali on 28-04-2014
                            //    //btnverifyemail.Enabled = false;//added by pranjali on 28-04-2014
                            //    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button end
                            //    tblNexam.Visible = false;//added by pranjali on 28-04-2014
                            //    tblNExmTitle.Visible = false;
                            //    tblEmsdtls.Visible = true;
                            //    tblexam.Visible = true;
                            //    tbltrndtls.Visible = false;
                            //    lblExamTitle.Text = "Exam Details";
                            //    // trnsfrtitle.Visible = false;
                            //    divTrnsferDetails.Visible = false;
                            //    CompositeTitle.Visible = false;
                            //    divCompositeDetails.Visible = false;
                            //    trIsPriorAgt.Visible = false;
                            //    if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                            //    {

                            //    }
                            #endregion
                            //}
                            //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                            //{

                            //    htParam.Clear();
                            //    dsResult.Clear();
                            //    htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                            //    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetReExmRecrd", htParam);
                            //    if (dsResult.Tables.Count > 0)
                            //    {
                            //        if (dsResult.Tables[0].Rows.Count > 0)
                            //        {
                            //            TblRptrTitle.Visible = true;
                            //            lblRptrCndTypVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                            //            lblRptrCountVal.Text = dsResult.Tables[0].Rows[0]["ReExamCount"].ToString().Trim();
                            //            lblRptrTypVal.Text = dsResult.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
                            //        }
                            //    }
                            //}
                            BindLabelsForCfr();//Added by pranjali on 25022014 for displaying the cfrs raised 
                            //added by pranjali on 29-04-2014
                            //trnsfrtitle.Visible = false;
                            //divTrnsferDetails.Visible = false;
                            //CompositeTitle.Visible = false;
                            //divCompositeDetails.Visible = false;
                            //trIsPriorAgt.Visible = false;
                            btnCancel.Visible = true;//added by shreela on 14/07/2014
                            btnClear.Visible = false;//added by shreela on 14/07/2014
                            Btncrop.Visible = true;//added by shreela on 08/05/2014
                            // }
                            //Btncrop.Visible = false;
                            TblTandC.Visible = false;
                        }
                        #endregion
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond1" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            tblPrefExm.Visible = false;
                            ViewState["feescount"] = "";
                            SetInitialRow();
                            tbltrn.Visible = false;
                            // divCFRInbox.Visible = true;
                            tblPrefExm.Visible = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            btnSave.Visible = false;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblNote1.Visible = false;//added by usha on 16-06-2022
                            lblCndView.Visible = true;
                            //trtran.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:none");
                            divCompositeDetails.Attributes.Add("Style", "display:none");
                            tblreasonnoc.Visible = true;
                            tblreasonNOC1.Visible = true;
                            tblremarkinsurer.Visible = true;
                            trAgency.Visible = true;
                            trMob.Visible = true;
                            trdos.Visible = true;
                            trEmail.Visible = false;
                            trMobile.Visible = false;
                            trRequest.Visible = false;
                            trBranch.Visible = false;
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            tblResonInsurer.Visible = true;
                            trnsfrtitle.Visible = false;
                            CompositeTitle.Visible = false;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            // tblCFRInboxCollapse.Visible = false;
                            //tblIcmColl.Visible = false;
                            tblICMManual.Visible = false;
                            divICM.Visible = false;
                            DivICMDtls.Visible = false;
                           
                            FillData1(Request.QueryString["MemCode"].ToString().Trim());
                            TblTandC.Visible = false;
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";

                            btnSubmit.Visible = false;
                            btnSubmit.Text = "Submit";
                           

                            divAgnPhotoTrnExmDtl.Visible = true;//added by pranjali on 11-04-2014
                            BtnCFR.Visible = false;
                            //divCFR.Visible = true;
                            EnableDisableControls();//to enable and disabled Approve button and Training details                        
                            //PopulateTrnType();
                            tblupload.Visible = true;



                            BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");

                            tblCFRInboxCollapse.Visible = true; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            BindgridChkboxChnge();
                           
                            BtnApprove.Visible = false;//Visibility changed by rachana on 19122013
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");

                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            divAgnPhotoTrnExmDtl.Visible = true;
                            Bindgridview();
                            BindInboxGrid();//Added by rachana on 13022014
                            BindLabels();
                            BindRemarks();
                            btnCloseCfr.Visible = false;
                            lblCndView.Visible = false; //Added by rachana on 07032014
                            btnRespond.Visible = true;
                            trRespond.Visible = true;
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;

                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;
                          
                        }
                        #region EDIT Raise CFR for branched USER
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 end
                        //added by usha  for exam details edit
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "R")
                        {
                            btnSubmit.Visible = false;//added by sanoj 18042023
                            trTokenwithFees.Visible = false;
                           // tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                     
                      
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;
                            Table1.Visible = false;//added by amruta on 4.9.15
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            tblFeesWavier.Visible = false;//added by amruta on 25.7.15 for fees wavier
                            ChkFeesWavier.Enabled = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = true;
                            //tblcol.Visible = true;
                           // trnsfrtitle.Visible = true;
                            // divTrnsferDetails.Visible = true;
                            //CompositeTitle.Visible = true;
                            //cbTccCompLcn.Checked = true;
                            //divCompositeDetails.Visible = false; ;
                            // tr5.Visible = true;

                            // radioComposite.Enabled = true;
                            // ddlCatComp.Enabled = false;
                            // ddlNameIns.Enabled = false;//Nikhil 8.6.15
                            // // txtInsurer.Enabled = false;
                            // txtAgencyCode.Enabled = false;
                            // txtDateOfAppointment.Enabled = false;
                            // ddlSts.Enabled = false;
                            // txtDateOfCessation.Enabled = false;
                            // txtReasonForCessation.Enabled = false;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            //Hashtable httable1 = new Hashtable();

                            //DataSet dscandtype = new DataSet();
                            //httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1);
                            //string strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();
                            //if (strCndType == "T")
                            //{
                            //    trIsPriorAgt.Visible = false;
                            //    trnsfrtitle.Visible = true;
                            //    CompositeTitle.Visible = false;
                            //    if (gvTrnsfr.Rows.Count == 0)
                            //    {

                            //        tdNoteIc.Visible = true;
                            //        txtIC.Enabled = true;
                            //        CalendarExtender28.Enabled = true;
                            //        trNoteTr.Visible = true;
                            //        divTrnsferDetails.Visible = true;
                            //        trTrnsfr1.Visible = true;
                            //        trTrnsfr2.Visible = true;
                            //        trTrnsfr3.Visible = true;
                            //        trTrnsfr4.Visible = true;
                            //        trTrnsfr5.Visible = true;
                                     
                            //        tr5.Visible = false;
                            //        //tbltrn.Visible = true;
                            //        btnAddComposite.Visible = false;

                            //        Tr1.Visible = false;
                            //        trAppointment.Visible = false;
                            //        trSts.Visible = false;
                            //        trCessation.Visible = false;
                            //        trInsurer.Visible = false;
                            //        divCompositeDetails.Visible = false;
                            //        NameInsurance(ddlNameInTrnsfr);
                            //        CatComp(ddlCaTrnsfr);
                            //    }
                            //    else//Nikhil pathari
                            //    {
                            //        trIsPriorAgt.Visible = false;
                            //        tdNoteIc.Visible = false; ;
                            //        gvComposite.Columns[6].Visible = false;
                            //        gvTrnsfr.Columns[7].Visible = false;
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //        txtIC.Enabled = false;
                            //        CalendarExtender28.Enabled = false;
                            //        trNoteTr.Visible = false;
                            //        divTrnsferDetails.Visible = false;
                            //        trTrnsfr1.Visible = false;
                            //        trTrnsfr2.Visible = false;
                            //        trTrnsfr3.Visible = false;
                            //        trTrnsfr4.Visible = false;
                            //        trTrnsfr5.Visible = false;
                            //        btnAddTrnsfr.Visible = false;
                            //        tr5.Visible = false;
                            //        //tbltrn.Visible = true;
                            //        btnAddComposite.Visible = false;

                            //        Tr1.Visible = false;
                            //        trAppointment.Visible = false;
                            //        trSts.Visible = false;
                            //        trCessation.Visible = false;
                            //        trInsurer.Visible = false;
                            //        divCompositeDetails.Visible = false;
                            //    }


                            //}
                            ////tr2.Visible = false;
                            //else if (strCndType == "C")
                            //{
                            //    trIsPriorAgt.Visible = false;
                            //    trnsfrtitle.Visible = false;
                            //    CompositeTitle.Visible = true;
                            //    tdExmmode1.Visible = true;
                            //    tdExmmode2.Visible = true;
                            //    tdExmBody1.Visible = true;
                            //    tdExmBody2.Visible = true;
                            //    tdPreExm.Visible = true;
                            //    tdPreExmlng.Visible = true;
                            //    tdExmCenter1.Visible = true;
                            //    tdExmCenter2.Visible = true;
                            //    //
                            //    tdExmCode1.Visible = false;
                            //    tdExmCode2.Visible = false;
                            //    trCndExm.Visible = false;
                            //    tdExmDt1.Visible = false;
                            //    tdExmDt2.Visible = false;
                            //    if (gvComposite.Rows.Count == 0)
                            //    {


                            //        tdNoteIc.Visible = false;
                            //        trNoteTr.Visible = false;
                            //        tr5.Visible = true;
                            //        divTrnsferDetails.Visible = false;
                            //        trTrnsfr1.Visible = false;
                            //        trTrnsfr2.Visible = false;
                            //        trTrnsfr3.Visible = false;
                            //        trTrnsfr4.Visible = false;
                            //        trTrnsfr5.Visible = false;
                            //        btnAddComposite.Visible = true;
                            //        //tbltrn.Visible = true;
                            //        Tr1.Visible = true;
                            //        trAppointment.Visible = true;
                            //        trSts.Visible = true;
                            //        trCessation.Visible = true;
                            //        trInsurer.Visible = true;
                            //        divCompositeDetails.Visible = true;
                            //        NameInsurance(ddlNameIns);
                            //        CatComp(ddlCatComp);
                            //    }
                            //    else
                            //    {

                            //        tdExmmode1.Visible = true;
                            //        tdExmmode2.Visible = true;
                            //        tdExmBody1.Visible = true;
                            //        tdExmBody2.Visible = true;
                            //        tdPreExm.Visible = true;
                            //        tdPreExmlng.Visible = true;
                            //        tdExmCenter1.Visible = true;
                            //        tdExmCenter2.Visible = true;
                            //        //
                            //        tdExmCode1.Visible = false;
                            //        tdExmCode2.Visible = false;
                            //        trCndExm.Visible = false;
                            //        tdExmDt1.Visible = false;
                            //        tdExmDt2.Visible = false;
                            //        trnsfrtitle.Visible = false;
                            //        tdNoteIc.Visible = false;
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //        gvComposite.Columns[6].Visible = false;
                            //        gvTrnsfr.Columns[7].Visible = false;
                            //        btnAddTrnsfr.Visible = false;
                            //        txtIC.Enabled = false;
                            //        CalendarExtender28.Enabled = false;
                            //        trNoteTr.Visible = false;
                            //        divTrnsferDetails.Visible = false;
                            //        trTrnsfr1.Visible = false;
                            //        trTrnsfr2.Visible = false;
                            //        trTrnsfr3.Visible = false;
                            //        trTrnsfr4.Visible = false;
                            //        trTrnsfr5.Visible = false;

                            //        trIsPriorAgt.Visible = false;

                            //        tr5.Visible = false;
                            //        //tbltrn.Visible = true;
                            //        btnAddComposite.Visible = false;

                            //        Tr1.Visible = false;
                            //        trAppointment.Visible = false;
                            //        trSts.Visible = false;
                            //        trCessation.Visible = false;
                            //        trInsurer.Visible = false;
                            //        divCompositeDetails.Visible = false;
                            //    }
                            //}
                            //else
                            //{
                                trIsPriorAgt.Visible = false;
                                trnsfrtitle.Visible = false;
                               // CompositeTitle.Visible = true;
                                //tdExmmode1.Visible = true;
                                //tdExmmode2.Visible = true;
                                //tdExmBody1.Visible = true;
                                //tdExmBody2.Visible = true;
                                //tdPreExm.Visible = true;
                                //tdPreExmlng.Visible = true;
                                //tdExmCenter1.Visible = true;
                                //tdExmCenter2.Visible = true;
                                //
                                tdExmCode1.Visible = false;
                                tdExmCode2.Visible = false;
                                trCndExm.Visible = false;
                                tdExmDt1.Visible = false;
                                tdExmDt2.Visible = false;

                                trnsfrtitle.Visible = false;
                                CompositeTitle.Visible = false;
                                txtIC.Enabled = false;
                                CalendarExtender28.Enabled = false;
                                trNoteTr.Visible = false;
                                divTrnsferDetails.Visible = false;
                                trTrnsfr1.Visible = false;
                                trTrnsfr2.Visible = false;
                                trTrnsfr3.Visible = false;
                                trTrnsfr4.Visible = false;
                                trTrnsfr5.Visible = false;
                                tdNoteIc.Visible = false;
                                tr5.Visible = false;
                                //tbltrn.Visible = true;
                                btnAddComposite.Visible = false;

                                trIsPriorAgt.Visible = true;
                                //Added by usha for exam  center and exam language change  
                                //ddlpreeamlng.Enabled = true;
                                //ddlExmCentre.Enabled = true;
                                //ended by usha 
                                btnAddTrnsfr.Visible = false;
                                Tr1.Visible = false;
                                trAppointment.Visible = false;
                                trSts.Visible = false;
                                trCessation.Visible = false;
                                trInsurer.Visible = false;
                                divCompositeDetails.Visible = false;
                          //  }

 
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            TblTandC.Visible = false;
                            BindgridChkboxChnge();
                            //Filluploadedfile();//Added by pranjali on 02-01-2013  
                            //ChkPhotoNotExist_Repeater();
                            btnSubmit.Visible = true;
                            btnSubmit.Text = "Update";
                            //divApprove.Visible = false; 
                            BtnApprove.Visible = false;//Visibility changed by rachana on 19122013
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");

                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            divAgnPhotoTrnExmDtl.Visible = true;
                           // GetCandidateType();
                            //if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T") || (strCndType == "P")) //Addded by usha on 09.03.2020
                            //{
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                //tbltrn.Visible = true;
                                Divtrndtls.Visible = false;
                            //}
                            //else
                            //{
                            //    tblEmsdtls.Visible = true;
                            //    tblexam.Visible = true;
                            //    // tbltrn.Visible = true;
                            //    Divtrndtls.Visible = false;
                            //}
                            //if (IsRenewal == "Y")////19052015
                            //{
                            //    tbltrndtls.Visible = false;
                            //    Divoldtrndtls.Attributes.Add("Style", "display:none");
                            //    tbltrn.Visible = false;
                            //    Divtrndtls.Attributes.Add("Style", "display:none");
                            //    txtPAN.Enabled = false;
                              
                            //}
                            // tblAdv.Visible = false;
                            //Show Exam DEtails

                            //lblExamTitle.Text = "Exam Details";

                            //GetRenewalDtls();
                            //GetReExamDtls();
                            BindInboxGrid();//Added by rachana on 13022014
                            BindLabels();
                            BindRemarks();
                            btnCloseCfr.Visible = false;
                            lblCndView.Visible = false; //Added by rachana on 07032014
                            btnRespond.Visible = true;
                            trRespond.Visible = true;
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            //if (ViewState["RenewalFlag"].ToString().Trim() == "Y")
                            //{
                            //    tblEmsdtls.Visible = false;
                            //    tblexam.Visible = false;
                            //    trnsfrtitle.Visible = false;
                            //    divTrnsferDetails.Visible = false;
                            //    chkCompAgnt.Enabled = false;
                            //    txtPAN.Enabled = false;//19052015
                                
                            //}
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                            if (Request.QueryString["user"].ToString().Trim() == "Brn")
                            {
                                lbldocupld.Visible = true;
                            }
                            divCFRInbox.Visible = false;
                            div1.Visible = false;
                            tblupload.Visible = false;
                        }
                        #endregion
                        #region QC with Raise CFR for Licensed User
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            trTokenwithFees.Visible = false;
                            

                            //tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                      
                   
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");
                            tdExmmode1.Visible = false;
                            tdExmmode2.Visible = false;
                            tdExmBody1.Visible = false; ;
                            tdExmBody2.Visible = false; ;
                            tdPreExm.Visible = false; ;
                            tdPreExmlng.Visible = false; ;
                            tdExmCenter1.Visible = false; ;
                            tdExmCenter2.Visible = false;
                            //
                            tdExmCode1.Visible = false;
                            tdExmCode2.Visible = false;
                            trCndExm.Visible = false;
                            tdExmDt1.Visible = false;
                            tdExmDt2.Visible = false;

                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = false;
                            //tblcol.Visible = false;
                            //trnsfrtitle.Visible = fals;

                            //CompositeTitle.Visible = true;


                            //radioComposite.Visible = true;
                            //ddlCatComp.Visible = false;
                            //ddlNameIns.Visible = false;//Nikhil 8.6.15
                            //txtInsurer.Enabled = false;

                            divTrnsferDetails.Visible = false;
                            trTrnsfr1.Visible = false;
                            trTrnsfr2.Visible = false;
                            trTrnsfr3.Visible = false;
                            trTrnsfr4.Visible = false;
                            trTrnsfr5.Visible = false;
                            tr5.Visible = false;
                            gvComposite.Columns[6].Visible = false;
                            gvTrnsfr.Columns[7].Visible = false;
                            if (cbTrfrFlag.Checked == true)
                            {
                                trNoteTr.Visible = true;
                            }
                            //tr2.Visible = false;
                            else
                            {
                                trNoteTr.Visible = false;
                                tr5.Visible = false;
                            }
                            txtCndURNNo.Visible = false;
                            lblcndURNNo.Visible = false;
                            lblcndURNVal.Visible = false;
                            tdCndURNNo.Visible = false;
                            btnAddComposite.Visible = false;
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                            divCompositeDetails.Visible = false;
                            if (gvComposite.Rows.Count != 0 || gvTrnsfr.Rows.Count != 0)
                            {
                                BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            }

                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }
                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";
                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
                            btnedit.Visible = true;
                            btnReject.Visible = true;
                            //divReject.Visible = true; 
                            //btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                            divAgnPhotoTrnExmDtl.Visible = true;
                            //Show Exam DEtails


                            lblExamTitle.Text = "Exam Details";
                            BtnCFR.Visible = true;
                            //divCFR.Visible = true;
                            EnableDisableControls();
                            //tblAdv.Visible = false;

                            GetCandidateType();
                            if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T"))
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;


                            }
                            else
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;
                            }

                            tblupload.Visible = false;
                            //chkconfirmation();
                            //Session["flag"] = intcount;
                            //BtnApprove.Attributes.Add("onclick", "Javascript:return funChkOpnCfr('" + Session["flag"] + "')");
                            BindGrid();
                            //btnprev.Enabled = false;
                            btnRespond.Visible = true;
                            trRespond.Visible = true;
                            BindInboxGrid();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = true;
                            btnSubmit.Text = "Update";
                            //Added by rachana on 02-01-2014 for confirmation of approval start
                            btnCloseCfr.Visible = false;
                       
                            //btnRespond.Visible = true;
                            //trRespond.Visible = true;
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            //For IRDA EDITING
                            tblEmsdtls.Visible = true;
                            tblexam.Visible = true;
                            tbltrn.Visible = true;
                            //Divoldtrndtls.Attributes.Add("Style", "display:block");
                            txtMobileNo.Enabled = false;//disabled by sanoj 06062023
                    
                            txtEMail.Enabled = false;//disabled by sanoj 06062023

                            txtPAN.Enabled = false;//disabled by sanoj 06062023

                            //  trnsfrtitle.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:block");
                           // CompositeTitle.Visible = true;
                            divCompositeDetails.Attributes.Add("Style", "display:block");
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                            //Panelphoto2.Visible = false;//added by ajay yadav
                            btnnectcfr.Visible = true;
                            div3.Visible = false;
                            TblTandC.Visible = false;
                            BtnApprove.Visible = false;
                            btnReject.Visible = false;
                            btnSubmit.Visible = false;
                        }
                        #endregion
                        #region QC with Responded CFR for Licensed User
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            divCFRInbox.Visible = false;
                            hdnModuleId.Value = Request.QueryString["ModuleID"].ToString().Trim();
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");

                            trTokenwithFees.Visible = false;
                            //tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                       
                  
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;

                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = false;
                            //tblcol.Visible = false;
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            tr5.Visible = false;
                            //tr2.Visible = false;
                            btnAddComposite.Visible = false;

                            //radioComposite.Visible = true;
                            //ddlCatComp.Visible = false;
                            //ddlNameIns.Visible = false;//Nikhil 8.6.15
                            //txtInsurer.Enabled = false;
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                           // GetCandidateType();
                            //if (strCndType == "T")
                            //{

                            //    trnsfrtitle.Visible = true;
                            //    tdExmmode1.Visible = false;
                            //    tdExmmode2.Visible = false;
                            //    tdExmBody1.Visible = false;
                            //    tdExmBody2.Visible = false;
                            //    tdPreExm.Visible = false;
                            //    tdPreExmlng.Visible = false;
                            //    tdExmCenter1.Visible = false;
                            //    tdExmCenter2.Visible = false;
                            //    tdExmCode1.Visible = false;
                            //    tdExmCode2.Visible = false;
                            //    tdExmDt1.Visible = false;
                            //    tdExmDt2.Visible = false;
                            //    trCndExm.Visible = false;
                            //    trNoteTr.Visible = false;
                            //    btnAddTrnsfr.Visible = false;
                            //    if (gvTrnsfr.Rows.Count != 0)
                            //    {
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //    }
                            //}
                            //tr2.Visible = false;
                            //else if (strCndType == "C")
                            //{
                            //    tdExmmode1.Visible = true;
                            //    tdExmmode2.Visible = true;
                            //    tdExmBody1.Visible = true;
                            //    tdExmBody2.Visible = true;
                            //    tdPreExm.Visible = true;
                            //    tdPreExmlng.Visible = true;
                            //    tdExmCenter1.Visible = true;
                            //    tdExmCenter2.Visible = true;
                            //    tdExmCode1.Visible = false;
                            //    tdExmCode2.Visible = false;
                            //    tdExmDt1.Visible = false;
                            //    tdExmDt2.Visible = false;
                            //    trCndExm.Visible = false;
                            //    btnAddComposite.Visible = false;
                            //    trNoteTr.Visible = false;
                            //    tr5.Visible = false;
                            //    txtCndURNNo.Visible = false;
                            //    lblcndURNVal.Visible = false;
                            //    lblcndURNNo.Visible = false;
                            //    CompositeTitle.Visible = true;
                            //    btnAddComposite.Visible = false;
                            //    trNoteTr.Visible = false;
                            //    tr5.Visible = false;

                            //    if (gvComposite.Rows.Count != 0)
                            //    {
                            //        BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                            //    }
                            //}
                            //else if (strCndType == "P")
                            //{
                                txtCndURNNo.Visible = false;
                                lblcndURNVal.Visible = false;
                                lblcndURNNo.Visible = false;
                                tdExmmode1.Visible = false;
                                tdExmmode2.Visible = false;
                                tdExmBody1.Visible = false;
                                tdExmBody2.Visible = false;
                                tdPreExm.Visible = false;
                                tdPreExmlng.Visible = false;
                                tdExmCenter1.Visible = false;
                                tdExmCenter2.Visible = false;
                                tdExmCode1.Visible = false;
                                tdExmCode2.Visible = false;
                                tdExmDt1.Visible = false;
                                tdExmDt2.Visible = false;
                                trCndExm.Visible = false;
                            //}
                            //else
                            //{
                            //    txtCndURNNo.Visible = false;
                            //    lblcndURNVal.Visible = false;
                            //    lblcndURNNo.Visible = false;
                            //    tdExmmode1.Visible = true;
                            //    tdExmmode2.Visible = true;
                            //    tdExmBody1.Visible = true;
                            //    tdExmBody2.Visible = true;
                            //    tdPreExm.Visible = true;
                            //    tdPreExmlng.Visible = true;
                            //    tdExmCenter1.Visible = true;
                            //    tdExmCenter2.Visible = true;
                            //    tdExmCode1.Visible = false;
                            //    tdExmCode2.Visible = false;
                            //    tdExmDt1.Visible = false;
                            //    tdExmDt2.Visible = false;
                            //    trCndExm.Visible = false;
                            //}

                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }

                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";


                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
                            btnedit.Visible = true;
                            btnReject.Visible = true;
                            //divReject.Visible = true; 
                            //btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //btnCloseCfr.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                            divAgnPhotoTrnExmDtl.Visible = true;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            BtnCFR.Visible = true;
                            //divCFR.Visible = true;
                            EnableDisableControls();
                            tblEmsdtls.Visible = true;
                            tblexam.Visible = true;
                            lblExamTitle.Text = "Exam Details";
                            tblupload.Visible = false;

                            //chkconfirmation();
                            //Session["flag"] = intcount;
                            //BtnApprove.Attributes.Add("onclick", "Javascript:return funChkOpnCfr('" + Session["flag"] + "')");

                            BindGrid();
                            //btnprev.Enabled = false;
                            BindInboxGrid();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = false;
                          
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            //btnCloseCfr.Visible = true;//Comented by usha on 24_04_2023
                            //trRespond.Visible = true;//Comented by usha on 24_04_2023
                            BindLabelsForCfr();
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            //GetRenewalDtls();
                            //if (ViewState["RenewalFlag"].ToString().Trim() == "Y")
                            //{
                            //    tblexam.Visible = false;
                            //    tblEmsdtls.Visible = false;
                            //    chkCompAgnt.Enabled = false;
                            //    tbltrndtls.Visible = false;
                            //    Divoldtrndtls.Attributes.Add("Style", "display:none");
                            //    tbltrn.Visible = false;
                            //    Divtrndtls.Attributes.Add("Style", "display:none");

                            //    txtPAN.Enabled = false;//19052015
                      
                            //}
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                            //GetCandidateType();
                            //if (strCndType == "T")
                            //{
                            //    tblexam.Visible = false;
                            //    tblEmsdtls.Visible = false;
                            //}

                            //if (strCndType == "P")
                            //{
                                tblexam.Visible = false;
                                tblEmsdtls.Visible = false;
                            // }
                            btnSubmit.Visible = false;
                            btnReject.Visible = false;//added by sanoj 06062023
                        }
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespondNOC" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");

                            // trCatApp.Visible = true;
                            //ddlcat.Enabled = false;
                            // trIns.Visible = true;
                            //ddlIns.Enabled = false;
                            trReject.Visible = true;
                            tblPrefExm.Visible = false;
                            ViewState["feescount"] = "";
                            SetInitialRow();
                            Td14.Visible = true;
                            GridRemarks.Visible = true;
                            tbltrn.Visible = false;
                            divCFRInbox.Visible = true;
                            tblPrefExm.Visible = false;
                            CatApp(ddlcatapp);
                            //CatCompNOC(ddlcatapp);
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            // btnSave.Visible = true;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblNote1.Visible = false;//added by usha on 16-06-2022
                            lblCndView.Visible = true;
                            //trtran.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:none");
                            divCompositeDetails.Attributes.Add("Style", "display:none");
                            tblreasonnoc.Visible = true;
                            tblreasonNOC1.Visible = true;
                            tblremarkinsurer.Visible = true;
                            trAgency.Visible = true;
                            trMob.Visible = true;
                            trdos.Visible = true;
                            trEmail.Visible = false;
                            trMobile.Visible = false;
                            trRequest.Visible = false;
                            trBranch.Visible = false;
                            GetRemarkdtl();
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            tblResonInsurer.Visible = true;
                            trnsfrtitle.Visible = false;
                            CompositeTitle.Visible = false;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            trTokenwithFees.Visible = false;
                            //tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                
                     
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;
                            //trCatApp.Visible = true;
                            //ddlcat.Enabled = false;
                            //trIns.Visible = true;
                            //ddlIns.Enabled = false;
                            //trReject.Visible = true;
                            FillData1(Request.QueryString["MemCode"].ToString().Trim());
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            if (Request.QueryString["Mode"].ToString() == "NOC") //added by usha on 16.09.2015
                            {
                                divCat.Visible = false;
                                tblCategory.Visible = false;
                            }
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = false;
                            //tblcol.Visible = false;
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            tr5.Visible = false;
                            //tr2.Visible = false;
                            btnAddComposite.Visible = false;

                            //radioComposite.Visible = true;
                            //ddlCatComp.Visible = false;
                            //ddlNameIns.Visible = false;//Nikhil 8.6.15
                            //txtInsurer.Enabled = false;
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;


                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }

                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";


                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
                            btnedit.Visible = true;
                            btnReject.Visible = true;
                            //divReject.Visible = true; 
                            //btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //btnCloseCfr.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                            divAgnPhotoTrnExmDtl.Visible = true;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            BtnCFR.Visible = true;
                            //divCFR.Visible = true;
                            EnableDisableControls();

                            tblupload.Visible = false;

                            //chkconfirmation();
                            //Session["flag"] = intcount;
                            //BtnApprove.Attributes.Add("onclick", "Javascript:return funChkOpnCfr('" + Session["flag"] + "')");

                            BindGrid();
                            //btnprev.Enabled = false;
                            BindInboxGrid();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = false;
                       
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            // btnCloseCfr.Visible = false;
                            trRespond.Visible = true;
                            BindLabelsForCfr();
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;


                            tblexam.Visible = false;
                            tblEmsdtls.Visible = false;
                            chkCompAgnt.Enabled = false;
                            tbltrndtls.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");

                            txtPAN.Enabled = false;//19052015
                     
                            BtnCFR.Enabled = false;
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                            dgDetailsInbox.Columns[9].Visible = true;
                            if (Request.QueryString["Mode"].ToString().Trim() == "NOC")
                            {
                                btnCloseCfr.Visible = false;

                            }
                            else
                            {
                                btnCloseCfr.Visible = true;
                            }



                        }
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespondSM" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            // div1.Attributes.Add("Style", "display:none");
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");
                            tblPrefExm.Visible = false;
                            ViewState["feescount"] = "";
                            SetInitialRow();
                            Td14.Visible = true;
                            GridRemarks.Visible = true;
                            tbltrn.Visible = false;
                            divCFRInbox.Visible = true;
                            tblPrefExm.Visible = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            // btnSave.Visible = true;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblNote1.Visible = false;//added by usha on 16-06-2022
                            lblCndView.Visible = true;
                            //trtran.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:none");
                            divCompositeDetails.Attributes.Add("Style", "display:none");
                            tblreasonnoc.Visible = true;
                            tblreasonNOC1.Visible = true;
                            tblremarkinsurer.Visible = true;
                            trAgency.Visible = true;
                            trMob.Visible = true;
                            trdos.Visible = true;
                            trEmail.Visible = false;
                            trMobile.Visible = false;
                            trRequest.Visible = false;
                            trBranch.Visible = false;
                            GetRemarkdtl();


                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            tblResonInsurer.Visible = true;
                            trnsfrtitle.Visible = false;
                            CompositeTitle.Visible = false;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            trTokenwithFees.Visible = false;
                           // tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                         
                        
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;
                            FillData1(Request.QueryString["MemCode"].ToString().Trim());
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = false;
                            //tblcol.Visible = false;
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            tr5.Visible = false;
                            //tr2.Visible = false;
                            btnAddComposite.Visible = false;

                            //radioComposite.Visible = true;
                            //ddlCatComp.Visible = false;
                            //ddlNameIns.Visible = false;//Nikhil 8.6.15
                            //txtInsurer.Enabled = false;
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                            //Added by usha 
                            //if (ViewState["MemberType"].ToString() == "SM ")
                            //{
                            tblCategory.Visible = false;
                            divCat.Visible = false;
                            //}
                            //ended by usha 


                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }

                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";


                            //divApprove.Visible = true; 
                            BtnApprove.Visible = false;
                            btnReject.Visible = false;
                            //divReject.Visible = true; 
                            //btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //btnCloseCfr.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = false;
                            tblphoto.Visible = false;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                            divAgnPhotoTrnExmDtl.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            BtnCFR.Visible = false;
                            //divCFR.Visible = true;
                            EnableDisableControls();

                            tblupload.Visible = true;

                            //chkconfirmation();
                            //Session["flag"] = intcount;
                            //BtnApprove.Attributes.Add("onclick", "Javascript:return funChkOpnCfr('" + Session["flag"] + "')");

                            Bindgridview();
                            //btnprev.Enabled = false;
                            BindInboxGrid();
                            GetChkRespond();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = false;
                           
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            btnCloseCfr.Visible = false;
                            trRespond.Visible = true;
                            BindLabelsForCfr();
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            Panelphoto2.Visible = false;

                            tblexam.Visible = false;
                            tblEmsdtls.Visible = false;
                            chkCompAgnt.Enabled = false;
                            tbltrndtls.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");

                            txtPAN.Enabled = false;//19052015
                        

                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014


                            btnRespond.Visible = true;

                        }
                        #endregion
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespondFSM" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            // div1.Attributes.Add("Style", "display:none");
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");
                            tblPrefExm.Visible = false;
                            ViewState["feescount"] = "";
                            SetInitialRow();
                            Td14.Visible = true;
                            GridRemarks.Visible = true;
                            tbltrn.Visible = false;
                            divCFRInbox.Visible = true;
                            tblPrefExm.Visible = false;
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            // btnSave.Visible = true;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblNote1.Visible = false;//added by usha on 16-06-2022
                            lblCndView.Visible = true;
                            //trtran.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:none");
                            divCompositeDetails.Attributes.Add("Style", "display:none");
                            tblreasonnoc.Visible = true;
                            tblreasonNOC1.Visible = true;
                            tblremarkinsurer.Visible = true;
                            trAgency.Visible = true;
                            trMob.Visible = true;
                            trdos.Visible = true;
                            trEmail.Visible = false;
                            trMobile.Visible = false;
                            trRequest.Visible = false;
                            trBranch.Visible = false;
                            GetRemarkdtl();
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            tblResonInsurer.Visible = true;
                            trnsfrtitle.Visible = false;
                            CompositeTitle.Visible = false;
                            divCndTrnsDtls.Attributes.Add("Style", "display:none");
                            trTokenwithFees.Visible = false;
                           // tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                          
                       
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;
                            FillData1(Request.QueryString["MemCode"].ToString().Trim());
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;                         
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            tr5.Visible = false;
                            //tr2.Visible = false;
                            btnAddComposite.Visible = false;
                           
                            Tr1.Visible = false;
                            trAppointment.Visible = false;
                            trSts.Visible = false;
                            trCessation.Visible = false;
                            trInsurer.Visible = false;
                            divCat.Visible = false;
                            tblCategory.Visible = false;

                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }

                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Member Verification";
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            //lblTitle.Text = "Online Member Verification";
                            lblCndName.Text = "Candidate Name";


                            //divApprove.Visible = true; 
                            BtnApprove.Visible = false;
                            btnReject.Visible = false;
                            //divReject.Visible = true; 
                            //btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //btnCloseCfr.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = false;
                            tblphoto.Visible = false;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                            divAgnPhotoTrnExmDtl.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            BtnCFR.Visible = false;
                            //divCFR.Visible = true;
                            EnableDisableControls();

                            tblupload.Visible = true;

                           

                            Bindgridview();
                            //btnprev.Enabled = false;
                            BindInboxGrid();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = false;
                         
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            btnCloseCfr.Visible = false;
                            trRespond.Visible = true;
                            BindLabelsForCfr();
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            Panelphoto2.Visible = false;

                            tblexam.Visible = false;
                            tblEmsdtls.Visible = false;
                            chkCompAgnt.Enabled = false;
                            tbltrndtls.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            tbltrn.Visible = false;
                            Divtrndtls.Attributes.Add("Style", "display:none");

                            txtPAN.Enabled = false;//19052015
                     

                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014


                            btnRespond.Visible = false;

                        }
                        //added by pranjali -----start
                        #region Renewal section
                        //added by shreela for renewal start
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")//&& Request.QueryString["Type"].ToString().Trim() == "N")
                        {
                            #region ICM related
                            PopulateICMStatus();
                            PopulateICMPaymentMode();
                            #endregion
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            trTokenwithFees.Visible = false;
                           // tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            Code = Request.QueryString["Code"].ToString();
                            tblRenewalCollapse.Visible = true;
                            divRenewal.Visible = true;
                            trIsPriorAgt.Visible = false;
                            btnSubmit.Visible = true;
                            Comp.Visible = true;

                           
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            FreezTrnInstLoc();

                            ddlExam.SelectedValue = "1";
                            ddlExam.Enabled = false;
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tblEmsdtls.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trTCCase.Visible = true;
                            //added by pranjali ------
                            //Added by rachana on 07032014
                            //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section start
                            //lblTitle.Text = "Renewal Request";
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            Bindgridview();
                            //Filluploadedfile();
                            //tbloldexm.Visible = true;
                            //tbltrndtls.Visible = true;

                            //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section end
                            ddlExmBody.Enabled = true;
                            ddlpreeamlng.Enabled = true;
                            lblSponsorDt.Text = "Requested Date";
                            drResult = null;
                            //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' Start


                            #region shree07
                            //htdata.Clear();
                            //htdata.Add("@MemCode", hdnCndNo.Value);
                            //drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htdata);
                            //string strcnd = dsResult.Tables[0].Rows[0]["CandType"].ToString();
                            //if (strcnd.ToString().Trim() == "F" || strcnd.ToString().Trim() == "T")
                            //{

                            //    Comp.Attributes.Add("Style", "display:none");
                            //    hdnCandTypeRen.Value = strcnd;
                            //}
                            //else
                            //{

                            //    Comp.Attributes.Add("Style", "display:block");
                            //    hdnCandTypeRen.Value = strcnd;
                            //    PopulateRenewalType();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                            //    PopulateLifeTraining();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                            //}




                            //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' End
                            //if (drResult.HasRows)
                            //{
                            //    //PANUpload.Enabled = true;
                            //}
                            #endregion
                            tbltrn.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                            btnCloseCfr.Visible = false;
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            SetInitialRow();
                            //BindFeesDetails();
                            lblpandetail.Visible = false;
                         
                            //GetTokenNoforDisplay();
                            FeesRow.Visible = false;
                            trIsPriorAgt.Visible = false;
                            tblCndURN.Visible = false;
                            btnCancel.Visible = true;//added by shreela on 14/07/2014
                            btnClear.Visible = false;//added by shreela on 14/07/2014
                        }
                        //added by shreela for renewal end
                        #endregion

                        //added by pranjali -----end
                        //Added by shreela on 20-03-14 for ReExam start
                        #region ReExam section
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam" && Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                        {
                            #region ICM related
                            PopulateICMStatus();
                            PopulateICMPaymentMode();
                            trTokenwithFees.Visible = false;
                           // tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            #endregion
                            trGivenName.Attributes.Add("Style", "display:none");
                            trFatherName.Attributes.Add("Style", "display:none");
                            Code = Request.QueryString["Code"].ToString();
                            hdnCndNo.Value = Request.QueryString["MemCode"].ToString().Trim();
                            FillData(Request.QueryString["MemCode"].ToString().Trim());
                            FreezTrnInstLoc();
                            
                            lblpandetail.Visible = false;//added by pranjali on 29-04-2014
                         
                            ddlExam.SelectedValue = "1";
                            //ddlExam.Enabled = false;
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trTCCase.Visible = true;

                            //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section start
                            //lblTitle.Text = "Re-Exam Request";
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            tblEmsdtls.Visible = true;//added by pranjali on 28-04-2014
                            divAgnPhotoTrnExmDtl.Visible = true;//added by pranjali on 28-04-2014
                            tblNexam.Visible = true;//added by pranjali on 28-04-2014
                            tblexam.Visible = true;//added by pranjali on 28-04-2014
                            tblNExmTitle.Visible = true;//added by pranjali on 28-04-2014
                            //ddlExmBody.Enabled = true;//commented by pranjali on 28-04-2014
                            //ddlpreeamlng.Enabled = true;//commented by pranjali on 28-04-2014
                            lblSponsorDt.Text = "Requested Date";
                            drResult = null;
                            htdata.Clear();
                            htdata.Add("@MemCode", hdnCndNo.Value);
                            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                            lblCndView.Visible = true;
                            //lblTitle.Text = "Sponsorship Request";
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            Bindgridview();
                            //Filluploadedfile();
                            //ddlExmBody.Enabled = true;
                            //ddlpreeamlng.Enabled = true;
                            lblSponsorDt.Text = "Requested Date";
                            drResult = null;
                            //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' Start
                            htdata.Clear();
                            htdata.Add("@MemCode", hdnCndNo.Value);
                            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                            ddlTrnMode.Enabled = true;
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                            btnCloseCfr.Visible = false;
                            //btnGetFeeDetails.Attributes.Add("onClick", "Javascript: return funFeesCheck();");
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            SetInitialRow();
                            // BindFeesDetails();
                            txtMobileNo.Enabled = false;
                          
                            txtEMail.Enabled = false;
                           
                            lblExamTitle.Text = "Old Exam Details";//added by pranjali on 28-04-2014
                            chkWebTknRecd.Enabled = true; //to be enabled for reexam invalid case
                            // GetTokenNoforDisplay();
                            FeesRow.Visible = false;
                            trIsPriorAgt.Visible = false;
                            tblCndURN.Visible = true;
                            txtCndURNNo.Visible = false;
                            lblcndURNVal.Visible = true;
                            btnCancel.Visible = true;//added by shreela on 14/07/2014
                            btnClear.Visible = false;//added by shreela on 14/07/2014
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            tbltrn.Visible = false;
                        }
                        #endregion
                        //Ad//ded by shreela on 20-03-14 for ReExam end



                        //btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExamCentre');return false;");
                        BtnCFR.Attributes.Add("onclick", "funcShowPopup('RaiseCFR');return false;");
                   
                      
                        btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExmCentre');return false;");
                        btnNExmCenter.Attributes.Add("onclick", "funcShowPopup('NExmCentre');return false;");
                        Btncrop.Attributes.Add("onclick", "funcopencrop1();return false");//added by shreela on 08/05/2014 fro croping
                    }

                    #region NEW REQUEST
                    if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                    {
                       // hdnModuleId.Value = Request.QueryString["ModuleID"].ToString().Trim();
                        Img2.Visible = false;
                        trGivenName.Attributes.Add("Style", "display:none");
                        trFatherName.Attributes.Add("Style", "display:none");
                        trTokenwithFees.Visible = false;
                        //tblIcmColl.Visible = false;
                        DivICMDtls.Attributes.Add("Style", "display:none");
                        Divtrndtls.Attributes.Add("Style", "display:none");
                        Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                        lblCndView.Visible = false; //Added by rachana on 07032014
                        //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section start
                        //lblTitle.Text = "Sponsorship Request";
                        tblcomp.Attributes.Add("Style", "display:none");
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        CompositeTitle.Visible = false;
                        
                        Bindgridview();
                        

                        //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section end
                        ddlExmBody.Enabled = true;
                        ddlpreeamlng.Enabled = true;
                        lblSponsorDt.Text = "Requested Date";
                        drResult = null;
                        //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' Start
                        htdata.Clear();
                        htdata.Add("@MemCode", hdnCndNo.Value);

                        drResult = dataAccessRecruit.Common_exec_reader_prc_common("Prc_GetFP50HrsNewReqSubmit", htdata);
                        //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' End
                        if (drResult.HasRows)
                        {
                            //PANUpload.Enabled = true;
                        }

                        tbltrn.Visible = false;
                        //tblAdv.Visible = false;
                        //added by rachan on 04062014
                        //GetCandidateType();

                        //if (strCndType == "C")
                        //{
                        //    tdExmmode1.Visible = true;
                        //    tdExmmode2.Visible = true;
                        //    tdExmBody1.Visible = true;
                        //    tdExmBody2.Visible = true;
                        //    tdPreExm.Visible = true;
                        //    tdPreExmlng.Visible = true;
                        //    tdExmCenter1.Visible = true;
                        //    tdExmCenter2.Visible = true;
                        //    //
                        //    tdExmCode1.Visible = false;
                        //    tdExmCode2.Visible = false;
                        //    trCndExm.Visible = false;
                        //    tdExmDt1.Visible = false;
                        //    tdExmDt2.Visible = false;
                        //    //
                        //    divCompositeDetails.Attributes.Add("Style", "display:none");
                        //    trnsfrtitle.Visible = false;
                        //    // divTrnsferDetails.Visible = false;
                        //    CompositeTitle.Visible = false;
                        //    btnAddComposite.Visible = false;
                        //    trNoteTr.Visible = false;
                        //    tr5.Visible = false;
                        //    //BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                        //}
                        //else
                        //{
                        //    tdExmmode1.Visible = true;
                        //    tdExmmode2.Visible = true;
                        //    tdExmBody1.Visible = true;
                        //    tdExmBody2.Visible = true;
                        //    tdPreExm.Visible = true;
                        //    tdPreExmlng.Visible = true;
                        //    tdExmCenter1.Visible = true;
                        //    tdExmCenter2.Visible = true;
                        //    //
                        //    tdExmCode1.Visible = false;
                        //    tdExmCode2.Visible = false;
                        //    trCndExm.Visible = false;
                        //    tdExmDt1.Visible = false;
                        //    tdExmDt2.Visible = false;
                        //    trnsfrtitle.Visible = false;
                        //    //divTrnsferDetails.Visible = false;
                        //    CompositeTitle.Visible = false;
                        //    ChkFeesWavier.Enabled = false;
                        //}
                        //if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T") || (strCndType == "P")) //Added by usha for POSP on 04.03.2020
                        //{
                        //    tblEmsdtls.Visible = true;
                        //    tblexam.Visible = true; //added by pranjali on 10-04-2014
                        //    Divoldtrndtls.Attributes.Add("Style", "display:none");
                        //    trIsPriorAgt.Visible = false;
                        //    tr5.Visible = false;
                        //    //tr2.Visible = false;
                        //    btnAddComposite.Visible = false;
                        //    lblCompositeDtl.Visible = false;

                        //    Tr1.Visible = false;
                        //    trAppointment.Visible = false;
                        //    trSts.Visible = false;
                        //    trCessation.Visible = false;
                        //    trInsurer.Visible = false;
                        //    divCompositeDetails.Visible = false;
                        //    trnsfrtitle.Visible = false;
                        //    divTrnsferDetails.Visible = false;
                        //    CompositeTitle.Visible = false;
                        //    GetCandidateType();
                            //if (strCndType == "T" || (strCndType == "P"))  //Added by usha for POSP on 04.03.2020
                            //{
                                tblEmsdtls.Attributes.Add("Style", "display:none");
                                tblexam.Attributes.Add("Style", "display:none");
                                tdExmCode1.Visible = false;
                                tdExmCode2.Visible = false;
                                tdExmBody1.Visible = false;
                                tdExmBody2.Visible = false;
                                trCndExm.Visible = false;
                                tdExmCenter1.Visible = false;
                                tdExmCenter2.Visible = false;
                                tdExmDt1.Visible = false;
                                tdExmDt2.Visible = false;
                                //
                                tdExmmode1.Visible = false;
                                tdExmmode2.Visible = false;
                                tdPreExm.Visible = false;
                                tdPreExmlng.Visible = false;
                                //
                                trNoteTr.Visible = false;
                                btnAddTrnsfr.Visible = false;
                                trnsfrtitle.Visible = false;
                                // divTrnsferDetails.Visible = false;
                                CompositeTitle.Visible = false;
                                //BindCompositeGrid(Request.QueryString["MemCode"].ToString());
                                ChkFeesWavier.Enabled = false;
                           // }

                       // }
                        //else if (IsPriorAgt == "1")
                        //{
                        //    tblEmsdtls.Visible = false;
                        //    tblexam.Visible = false; //added by pranjali on 10-04-2014
                        //    Divoldtrndtls.Attributes.Add("Style", "display:none");
                        //    trIsPriorAgt.Visible = false;
                        //}
                        //else
                        //{
                        //    tblexam.Visible = true;
                        //}
                        //added by rachan on 04062014
                        divAgnPhotoTrnExmDtl.Visible = true;//Added by pranjali on 10-04-2014
                        tblCFRInbox.Visible = false;
                        divCFRInbox.Attributes.Add("Style", "display:none");
                        tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                        btnCloseCfr.Visible = false;
                        //Added by Rachana on 20032014 Fees Details Entry start
                        //btnGetFeeDetails.Attributes.Add("onClick", "Javascript: return funFeesCheck();");
                        //SetInitialRow();
                        lblExamTitle.Text = "Exam Details";//added by pranjali on 28-04-2014
                        //BindFeesDetails();
                        //hide all fees related details on NEWREQUEST page start
                        tblICMManual.Visible = false;
                        divICM.Attributes.Add("Style", "display:none");
                        FeesRow.Visible = false;
                        trIsPriorAgt.Visible = false;
                        tblCndURN.Visible = false;

                        //hide all fees related details on NEWREQUEST page end 
                    }
                    #endregion
                }
                GetCandidateDtls();
                // checks whether btnApprove and Training Details are enabeled without CFR raised
                #region checks whether btnApprove and Training Details are enabeled without CFR raised
                if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "Qc")
                {
                    //Added by pranjali on 25-03-2014 for transfer case training details part non-mandatory start

                    if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                    {
                        candtype = "T";
                    }
                    else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                    {
                        candtype = "T";
                    }
                    else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                    {
                        candtype = "C";
                    }
                    else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                    {
                        candtype = "F";
                    }
                    //if (candtype != "T")
                    //{
                    BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");

                    //}

                }
                ViewState["Pan"] = txtPAN.Text; //ADDED BY PRATHMESH ON 05/08/2015
                #endregion
                //added bya ajay
                if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise")
                {
                    btnSubmit.Visible = false;
                }
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["MemCode"].ToString().Trim() != null)
                {

                    if (dsImage.Tables.Count == 0)
                    {
                        ImageRendering(Request.QueryString["MemCode"].ToString().Trim());
                    }
                }
            }
            //added by Nikhil for composite on 5.6.15 start
            divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014
            // BindCompositeGrid(Request.QueryString["MemCode"].ToString());
            //added by Nikhil for composite on 5.6.15 end
            btnRespond.Visible = false;
        }
        catch (Exception ex)
        {

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    private void FillData1(string strCndNo)
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        //htDtls.Add("@Flag", "1");
        dsDtls = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNOCAppCandidateDetails", htDtls);
        lblFrenchiseeCode.Text = dsDtls.Tables[0].Rows[0]["AppNo"].ToString();
        lblAdvNameValue.Text = dsDtls.Tables[0].Rows[0]["Givenname"].ToString();
        lblCndNoValue.Text = dsDtls.Tables[0].Rows[0]["CndNo"].ToString();
        lblmobile.Text = dsDtls.Tables[0].Rows[0]["MobileTel"].ToString();
        lblpanno.Text = dsDtls.Tables[0].Rows[0]["PAN"].ToString();
        lblagencycodeValue.Text = dsDtls.Tables[0].Rows[0]["Agent_Broker_Code"].ToString();
        lbldateissuevalue.Text = dsDtls.Tables[0].Rows[0]["IssueDate"].ToString();
        lblsnlve.Text = dsDtls.Tables[0].Rows[0]["Leave_Type"].ToString();
        lbldoar.Text = dsDtls.Tables[0].Rows[0]["AcceptDate"].ToString();
        lbldate.Text = dsDtls.Tables[0].Rows[0]["submitDate"].ToString();
        if (txtReInsurer.Text == "")
        {
            txtReInsurer.Text = dsDtls.Tables[0].Rows[0]["RemarkforInsurer"].ToString();
        }
        txtreasonleave.Text = dsDtls.Tables[0].Rows[0]["RemarksForLeave"].ToString();
        strCat = dsDtls.Tables[0].Rows[0]["Category_Appointment"].ToString();
        // || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespondNOC" && Request.QueryString["Mode"].ToString().Trim() == "NOC" || Request.QueryString["Mode"].ToString().Trim() == "NOCCLOSED")
        //  {
        if (strCat == "Fresh")
        {
            btncat.Visible = false;
            tblCategory.Visible = true;
            tblcat.Visible = false;
            ddlcatapp.Enabled = false;
            divCat.Visible = false;
            tblcat.Visible = false;
            trLife.Visible = false;
            trHealth.Visible = false;
            trCatbind.Visible = true;
            trNameInsurance.Attributes.Add("style", "display:none");
            lblCatAppBind.Text = dsDtls.Tables[0].Rows[0]["Category_Appointment"].ToString();
            lblcategorybind.Text = dsDtls.Tables[0].Rows[0]["Category"].ToString();
            //tblCategory.Visible = true;



        }
        else if (strCat == "Composite")
        {
            btncat.Visible = false;
            tblCategory.Visible = true;
            tblcat.Visible = false;
            ddlcatapp.Enabled = false;
            divCat.Visible = false;
            tblcat.Visible = false;
            trLife.Visible = false;
            trHealth.Visible = false;
            trCatbind.Visible = true;
            trNameInsurance.Visible = true;
            lblCatAppBind.Text = dsDtls.Tables[0].Rows[0]["Category_Appointment"].ToString();
            lblcategorybind.Text = dsDtls.Tables[0].Rows[0]["Category"].ToString();
            lblNameBind.Text = dsDtls.Tables[0].Rows[0]["Name_Insurance"].ToString();
            // tblCategory.Visible = true;



        }
        else
        {
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "NOCQc")
            {
                tblCategory.Visible = true;
                divCat.Visible = true;
                tblcat.Visible = true;
                trLife.Visible = false;
                trHealth.Visible = false;
            }
        }


        //  }
    }
    //added by rachana on 30-04-2013 for getting ICM enable start
    private void PopulateICMStatus()
    {

        DataSet dsICMStat = new DataSet();

        dsICMStat = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetICMEnableStatus");
        ViewState["strICMEnable"] = dsICMStat.Tables[0].Rows[0]["value"].ToString();

        if (ViewState["strICMEnable"].ToString() == "YES")
        {

            divICM.Attributes.Add("style", "display:none");
            tblICMManual.Attributes.Add("style", "display:none");
            //txtFeesRcvd.Visible = true;
        }
        else if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
        {

            divICM.Attributes.Add("style", "display:none");
            tblICMManual.Attributes.Add("style", "display:none");
            FeesRow.Visible = false;
            trTokenwithFees.Visible = false;
          //  tblIcmColl.Visible = false;
            DivICMDtls.Attributes.Add("Style", "display:none");
        }
        else
        {

            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
            {

                divICM.Attributes.Add("style", "display:block");
                tblICMManual.Attributes.Add("style", "display:block");
                lnkGetFees.Visible = false;
                //txtFeesRcvd.Visible = false;
            }
            else
            {
                divICM.Attributes.Add("style", "display:none");
                tblICMManual.Attributes.Add("style", "display:none");
                //txtFeesRcvd.Visible = false;
                //txtFeesRcvd.Attributes.Add("style", "display:none");
                //btnGetFeeDetails.Attributes.Add("style", "display:none");
            }
        }
    }

    private void GetTokenNoforDisplay()
    {
        int iTokenD;
        DataSet dsToken = new DataSet();
        Hashtable htToken = new Hashtable();
        htToken.Add("@AppNo", lblFrenchiseeCode.Text);
        htToken.Add("@MemCode", lblCndNoValue.Text);
        htToken.Add("@candType", hdnPanDtls.Value);
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc" && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
        {
            htToken.Add("@Flag", "QC");
        }
        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc" && ViewState["RenewalFlag"].ToString() == "Y" && ViewState["RnwlQCFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
        {
            htToken.Add("@Flag", "QC");
        }
        else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
        {
            htToken.Add("@Flag", "RW");
        }
        else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
        {
            htToken.Add("@Flag", "RE");
        }

        if (ChkFeesWavier.Checked == true)
        {
            htToken.Add("@AutoWavierFlag", "Y");
        }

        dsToken = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetTokenNoForSync", htToken);

        if (dsToken.Tables.Count > 0)
        {
            if (dsToken.Tables[0].Rows.Count > 0)
            {
                trTokenwithFees.Visible = true;
                iTokenD = Convert.ToInt32(dsToken.Tables[0].Rows[0]["FeesTokenNo"]);
                lblTknNoValue.Text = Convert.ToString(iTokenD);
                lblTknNoLstDesc.Text = Convert.ToString(iTokenD);
                lblTotfeesValue.Text = dsToken.Tables[0].Rows[0]["TotalFees"].ToString();

            }
            else
            {
                iTokenD = 0;
                //lblTknNoValue.Visible = false;
                //lblTknNo.Visible = false;
                trTokenwithFees.Visible = false;
            }
        }
    }

    private void GetTotalFeesBasedOnLcnExpDate()
    {
        string strRulecode = string.Empty;
        Hashtable htRuleCode = new Hashtable();
        htRuleCode.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        strRulecode = dataAccessRecruit.execute_sprc_with_output("Prc_GetFeesForRNWLCnd", htRuleCode, "@Strout");

        Hashtable htLatestFees = new Hashtable();
        htLatestFees.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        htLatestFees.Add("@RuleCode", strRulecode);
        htLatestFees.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        string strnewfees = dataAccessRecruit.execute_sprc_with_output("prc_GetLatestFeesbasedOnLcnDt", htLatestFees, "@Strout");

        if (strnewfees != "")
        {
            decimal DLatestFees = Convert.ToDecimal(strnewfees);
            trTokenwithLatestFees.Attributes.Add("Style", "display:block");
            lblTotfeesLstDesc.Text = Convert.ToString(DLatestFees);

            if (Convert.ToDecimal(lblTotfeesValue.Text) == Convert.ToDecimal(lblTotfeesLstDesc.Text))
            {
                lblTotfeesLstDesc.ForeColor = Color.Green;
                lblTotfeesValue.ForeColor = Color.Green;
                lblTknNoValue.ForeColor = Color.Green;
                lblTknNoLstDesc.ForeColor = Color.Green;
            }
            else if (Convert.ToDouble(lblTotfeesValue.Text) != Convert.ToDouble(lblTotfeesLstDesc.Text))
            {

                lblTknNoValue.ForeColor = Color.Orange;
                lblTotfeesValue.ForeColor = Color.Orange;


                lblTknNoLstDesc.ForeColor = Color.Green;
                lblTotfeesLstDesc.ForeColor = Color.Green;
            }
        }
    }

    #region set ReExamFlag,ExamType,RenewalFlag,Count
    private void GetRenewalDtls()
    {
        Hashtable htRe = new Hashtable();
        DataSet dsRe = new DataSet();
        htRe.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsRe = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htRe);
        //viewstate for inserting fees details
        ViewState["RenewalFlag"] = dsRe.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
        ViewState["RnwlQCFlag"] = dsRe.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim();
    }

    private void GetReExamDtls()
    {
        Hashtable htReExam = new Hashtable();
        DataSet dsReExam = new DataSet();
        htReExam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsReExam = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htReExam);
        //viewstate for inserting fees details
        ViewState["ReExmType"] = dsReExam.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
        ViewState["ReExamFlag"] = dsReExam.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();

    }
    #endregion


    #region Patment Mode
    private void PopulateICMPaymentMode()
    {
        try
        {

            oCommon.getDropDown(DDlPymtMode, "DDlPymtMode", 1, "", 1);
            DDlPymtMode.Items.Insert(0, "--Select--");
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
    //added by rachana on 30-04-2013 for getting ICM enable end

    #region CandidateType
    private void GetCandidateType()
    {
        Hashtable httable = new Hashtable();
        DataSet dscandtype = new DataSet();
        httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
        //strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString().Trim();
        //IsPriorAgt = dscandtype.Tables[0].Rows[0]["IsPriorAgt"].ToString();
        //ProcessType = dscandtype.Tables[0].Rows[0]["ProcessType"].ToString();
        //IsRenewal = dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();////19052015
    }
    #endregion
    //added by pranjali on 13-03-2014 for binding dropdown of transfer insurer name start
    #region PopulateTrnsfrInsurerName
    private void PopulateTrnsfrInsurerName()
    {
        try
        {
            //string strSql = string.Empty;
            //SqlDataReader dtReadTrnsfr;
            DataSet dtReadTrnsfr = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            //dtReadTrnsfr = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetTransferInsurerName");
            dtReadTrnsfr = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetTransferInsurerName");
            //dtReadTrnsfr.Read();
            //if (dtReadTrnsfr.HasRows)
            //{
            ddlTrnsfrInsurName.DataSource = dtReadTrnsfr;
            ddlTrnsfrInsurName.DataTextField = "InsurerDesc";
            ddlTrnsfrInsurName.DataValueField = "InsurerValue";
            ddlTrnsfrInsurName.DataBind();
            ddlTrnsfrInsurName.Items.Insert(0, "--Select--");

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
            //dtReadComp = .exec_reader_prc_inscdirect("Prc_GetCompositeInsurerName");
            dtReadComp = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetCompositeInsurerName");
            //dtReadComp.Read();

            //if (dtReadComp.HasRows)
            //{
            ddlCompInsurerName.DataSource = dtReadComp;
            ddlCompInsurerName.DataTextField = "InsurerDesc";
            ddlCompInsurerName.DataValueField = "InsurerValue";
            ddlCompInsurerName.DataBind();
            ddlCompInsurerName.Items.Insert(0, "--Select--");

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
    //added by pranjali on 13-03-2014 for binding dropdown of Composite insurer name end

    //Added by pranjali on 03-03-2014 for binding the dropdown for training mode start
    #region Training Mode
    private void PopulateTrainingMode()
    {
        try
        {

            oCommon.getDropDown(ddlTrnMode, "TrnMode", 1, "", 1);
            ddlTrnMode.Items.Insert(0, "--Select--");
            ddlTrnLoc.Items.Insert(0, "--Select--");
            ddlTrnInstitute.Items.Insert(0, "--Select--");
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
    private void PopulateTrainingLoc(string ddlLoc)
    {
        try
        {
            htdata.Clear();
            htdata.Add("@TrnType", ddlLoc);
            SqlDataReader dtRead;
            dtRead = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnLoc", htdata);
            htdata.Clear();
            if (dtRead.HasRows)
            {
                ddlTrnLoc.DataSource = dtRead;
                ddlTrnLoc.DataTextField = "TrnLocDesc";
                //ddlTrnLoc.DataValueField = "TrnCode";
                ddlTrnLoc.DataValueField = "TrnType";
                ddlTrnLoc.DataBind();
                ddlTrnLoc.Items.Insert(0, "--Select--");
            }
            dtRead = null;
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
    private void PopulateTrainingInst(string ddlLoc, string ddlMode)
    {
        try
        {
            htdata.Clear();
            htdata.Add("@TrnCode", ddlLoc);
            htdata.Add("@TrnType", ddlMode);
            SqlDataReader dtRead1;
            dtRead1 = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnInst", htdata);
            htdata.Clear();

            if (dtRead1.HasRows)
            {

                ddlTrnInstitute.DataSource = dtRead1;
                ddlTrnInstitute.DataTextField = "TrnInstDesc01";
                ddlTrnInstitute.DataValueField = "TrnCode";
                ddlTrnInstitute.DataBind();

            }
            dtRead1 = null;
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
    //Added by pranjali on 03-03-2014 for binding the dropdown for training mode end

    private void Bindgridview()
    {
         

        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                         Hashtable htparam = new Hashtable();
            htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            htparam.Add("@EntityType", Convert.ToString(ViewState["EntityType"]).Trim());//added by usha on 31052022
            htparam.Add("@MemType", strMemType);
                    htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                                                
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                {
                    
                    htparam.Add("@InsurerType", "");
                    htparam.Add("@ProcessType", "NR");
                     
                }   ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", htparam); //added by pranjali on 19-05-2014
            

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
                    tblupload.Visible = false;

                }
            }
            else
            {
                dgView.DataSource = null;
                dgView.DataBind();
                tblupload.Visible = false;

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
        //Added by pranjali to fill File upload grid end
    }

    #region Error Log
    public void ErrorLog(string Message)
    {
        StreamWriter sw = null;

        try
        {
            string CurCndNo = Request.QueryString["MemCode"].ToString().Trim();
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "  For Candidate No : " + CurCndNo + " ==> ";
            string sPathName = @"C:\INSCECRMErrlog\";

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();

            string sErrorTime = sDay + "-" + sMonth + "-" + sYear;

            string SLogFileName = sPathName + "INSCECRM_ErrorLog_" + sErrorTime + ".txt";

            if (!(File.Exists(SLogFileName)))
            {
                sw = new StreamWriter(SLogFileName, true);
                sw.WriteLine(sLogFormat + Message + Environment.NewLine);
            }
            else
            {
                string AppendContent = sLogFormat + Message + Environment.NewLine;
                File.AppendAllText(SLogFileName, AppendContent);
            }

            sw.Flush();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (sw != null)
            {
                sw.Dispose();
                sw.Close();
            }
        }


    }
    #endregion
    #endregion

    #region Fees Details
    private void BindFeesDetails()
    {
        try
        {
            Hashtable htfeesDtls = new Hashtable();
            DataSet dsfeesDtls = new DataSet();
            htfeesDtls.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htfeesDtls.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htfeesDtls.Add("@Flag", "RE");
            }
            else
            {
                htfeesDtls.Add("@Flag", "NR");
            }
            dsfeesDtls = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFeesDetailsforCnd", htfeesDtls);

            if (dsfeesDtls.Tables.Count > 0)
            {
                if (dsfeesDtls.Tables[0].Rows.Count > 0)
                {
                    //divFees.Attributes.Add("Style", "display:block");
                    //TblFees.Visible = true;
                    //if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
                    //{
                    //    chkWebTknRecd.Enabled = true;
                    //    txtFeesRcvd.Text = dsfeesDtls.Tables[0].Rows[0]["Receiptid"].ToString();
                    //}
                    //else if (Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam" && Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                    //{
                    //    chkWebTknRecd.Enabled = true;
                    //    txtFeesRcvd.Text = dsfeesDtls.Tables[0].Rows[0]["Receiptid"].ToString();

                    //}
                    //eslse//QC only view
                    //{
                    //    txtFeesRcvd.Attributes.Add("Style", "display:none");
                    //    btnGetFeeDetails.Visible = false;
                    //}
                    divFees.Attributes.Add("Style", "display:block");
                    TblFees.Visible = true;
                    chkWebTknRecd.Checked = true;
                    chkWebTknRecd.Enabled = false;

                    dgPaymentdtls.DataSource = dsfeesDtls.Tables[0];
                    dgPaymentdtls.DataBind();
                    ViewState["dsfeesDtls"] = dsfeesDtls.Tables[0];
                }
                else
                {


                    dgPaymentdtls.DataSource = null;
                    dgPaymentdtls.DataBind();
                    //chkWebTknRecd.Checked = false;
                    chkWebTknRecd.Checked = false;
                    chkWebTknRecd.Enabled = true;
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

    #region EnableDisableControls() to enable/disable controls
    private void EnableDisableControls()
    {
        dsResult.Clear();
        htParam.Clear();
        htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkMemCFRDocCFRRemark", htParam); //added by pranjali to check open cfr
       
        //added by pranjali on 12-02-2014 for enable disable of approve button start
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                int i;
                for (i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    string CFRRaised = dsResult.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                    string CFRClosed = dsResult.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();

                    if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1"))
                    {
                        //added by rachana on 04062014 start
                       // GetCandidateType();
                        //if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T"))
                        //{
                        //    tbltrn.Visible = false;
                        //}
                        //else
                        //{
                        //    tbltrn.Visible = true;
                        //}
                        //added by rachana on 04062014 end

                        BtnApprove.Enabled = false;
                        btnReject.Enabled = false;

                    }

                }
            }
        }
        //added by pranjali on 12-02-2014 for enable disable of approve button end

        //commented by pranjali on 12-02-2014 for enable disable of approve button start
        //if(dsResult.Tables[0].Rows.Count > 0)
        //{
        //    string strcfr= dsResult.Tables[0].Rows[0]["CFRFlag"].ToString();
        //    string srfcfrclose= dsResult.Tables[0].Rows[0]["CFRClose"].ToString();
        //    if ((strcfr == "" || strcfr == null && srfcfrclose == "" || srfcfrclose==null) || (strcfr == "1" && srfcfrclose == "1"))//condition changed by rachana on 19122013
        //    {
        //        BtnApprove.Enabled = true;
        //        btnReject.Enabled = true;
        //        //divtbltrn.Visible = true;
        //        tbltrn.Visible = true;
        //    }
        //    else
        //    {
        //        BtnApprove.Enabled = false;
        //        btnReject.Enabled = false;
        //        //divtbltrn.Visible = false;
        //        tbltrn.Visible = false;
        //    }

        //}
        //commented by pranjali on 12-02-2014 for enable disable of approve button end
    }
    #endregion

    #region ChkPhotoNotExist_Repeater()
    //To Chk Photo Not Exist
    private void ChkPhotoNotExist_Repeater()
    {
        drResult = null;
        //Added By Ibrahim on 05-07-2013  To Chk Photo Not Exist_Repeater Start
        htdata.Clear();
        htdata.Add("@TccID", Convert.ToString(hdnTccID.Value).Trim());
        drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_GetPopulateProofIDDoc", htdata);
        //Added By Ibrahim on 05-07-2013  To Chk Photo Not Exist_Repeater End
        if (drResult.HasRows)
        {

            if (drResult.Read())
            {
                if (drResult["AdvPhoto"].ToString() == null || drResult["AdvPhoto"].ToString() != "")// && drResult["AdvPAN"].ToString() == null && drResult["AdvPAN"].ToString() == "" && drResult["AdvSignature"].ToString() == null && drResult["AdvSignature"].ToString() == "")
                {
                    trmsg.Visible = true;
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Images are uploaded earlier, You can not uploaded images.');</script>");
                    lblMessage.Text = "Images are uploaded earlier, You can not uploaded images.";
                    lblMessage.Visible = true;
                    //commented by pranjali on 02-01-2014 start
                    //AgnPhotoUpload.Enabled = false;
                    //AgnSignUpload.Enabled = false;
                    //PANUpload.Enabled = false;
                    //commented by pranjali on 02-01-2014 end
                    btnSubmit.Enabled = false;
                    return;
                }
            }
        }
    }
    #endregion

    #region ChkURNExist
    public bool ChkURNExist(string strCndNo)
    {

        bool ExistFlag = false;
        try
        {

            htParam.Clear();
            dsResult = null;
            htParam.Add("@MemCode", strCndNo);
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetURNExistorExist", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ExistFlag = true;
                }
                if (dsResult.Tables[1].Rows.Count > 0)
                {
                    hdnSDate.Value = Convert.ToString(dsResult.Tables[1].Rows[0]["TrnStartDate"]).Trim();
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

        return ExistFlag;
    }
    #endregion

    #region chkExmResult()
    //To Chk Exam Result Exsist or Not  
    private bool chkExmResult()
    {
        bool PassFlag = false;
        try
        {

            drResult = null;
            //Added By Ibrahim on 05-07-2013  To Chk Exam result Exist or not Start
            htdata.Clear();
            htdata.Add("@MemCode", Convert.ToString(hdnCndNo.Value).Trim());
            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_chkExmResult", htdata);
            //Added By Ibrahim on 05-07-2013  To Chk Exam result Exist or not End

            if (drResult.HasRows)
            {
                PassFlag = true;
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
        return PassFlag;
    }
    #endregion

    #region chkURNExistorNot()
    private void chkURNExistorNot()
    {
        try
        {
            if (ChkURNExist(Convert.ToString(hdnCndNo.Value).Trim()) == true)
            {
                if (SpnsorshipDtExist() == true)
                {
                    drResult = null;
                    //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' Start
                    htdata.Clear();
                    htdata.Add("@MemCode", Convert.ToString(hdnCndNo.Value).Trim());
                    drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_chkURNExistorNot", htdata);
                    //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' End

                    while (drResult.Read())
                    {
                        if (Convert.ToString(drResult["IRDASponsorDt"]).Trim() != "")
                        {
                            if ((DateTime.Parse(Convert.ToString(drResult["IRDASponsorDt"]).Trim()).AddDays(305) <= System.DateTime.Now.Date) && (DateTime.Parse(Convert.ToString(drResult["IRDASponsorDt"]).Trim()).AddDays(365) >= System.DateTime.Now.Date))
                            {
                                trmsg.Visible = true;
                                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Currently not allowed to raise New 50 hrs Training request . Raise request after Expiry of Sponsorship Date');</script>");
                                lblMessage.Text = "Currently not allowed to raise New 50 hrs Training request . Raise request after Expiry of Sponsorship Date";
                                lblMessage.Visible = true;
                                btnSubmit.Visible = false;
                                return;
                            }
                            else if (DateTime.Parse(Convert.ToString(drResult["IRDASponsorDt"]).Trim()).AddDays(305) <= System.DateTime.Now.Date)
                            {

                                ddlExmTpe.Items[1].Enabled = true;
                                ddlExmTpe.Items[2].Enabled = false;
                                ddlExmTpe.SelectedValue = "NADV";
                                ddlTrnMode.Enabled = true;
                                EnabledCtrlforRepeater();
                                //PANUpload.Enabled = false;
                                btnSubmit.Visible = true;
                                return;
                            }
                        }
                    }
                }
            }

            else if (ChkURNExist(Convert.ToString(hdnCndNo.Value).Trim()) == false)
            {
                ddlExmTpe.SelectedValue = "--Select--";
                ddlExmTpe.Enabled = true;
                ddlExmTpe.Items[1].Enabled = true;
                ddlExmTpe.Items[2].Enabled = false;

                return;
            }
         
            if (chkExmResult() == true)
            {
                trmsg.Visible = true;
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Advisor is already passed in the Examination.');</script>");
                lblMessage.Text = "Advisor is already passed in the Examination.";
                lblMessage.Visible = true;
                btnSubmit.Enabled = false;
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }
    #endregion

    #region DisabledCtrl()
    //Disable controls on edit option
    private void DisabledCtrl()
    {
        ddlExmTpe.Enabled = false;
        ddlHrsTrn.Enabled = false;
        ddlTrnMode.Enabled = false;
        ddlExam.Enabled = false;
        ddlExmBody.Enabled = false;
        ddlpreeamlng.Enabled = false;
        //txtExmCentre.Enabled = false;
        btnExmCentre.Enabled = false;
        AdvWaiverUpload.Enabled = false;
        //btnTrnInstitute.Enabled = false;
        //btnTrnLocation.Enabled = false;
    }
    #endregion

    #region PopulateTrnType()
    private void PopulateTrnType()
    {
        try
        {
            oCommon.getDropDown(ddlHrsTrn, "TrnType", 1, "", 1);
            ddlHrsTrn.Items.Insert(0, "--Select--");

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

    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            #region ICM EDIT labels added by rachana on 30042014
            lblEFT.Text = olng.GetItemDesc("lblEFT");
            lblBankName.Text = olng.GetItemDesc("lblBankName");
            lblChequeDate.Text = olng.GetItemDesc("lblChequeDate");
            lblChequeNo.Text = olng.GetItemDesc("lblChequeNo");
            lblPymtAmt.Text = olng.GetItemDesc("lblPymtAmt");
            lblPymtMode.Text = olng.GetItemDesc("lblPymtMode");
            #endregion

            //lblTitle.Text = olng.GetItemDesc("lblTitle");
           

            //lblCscCode.Text = olng.GetItemDesc("lblCscCode");
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            //lblBranchCode.Text = olng.GetItemDesc("lblBranchCode"); commented by pranjali on 27-12-2013
            lblBranch.Text = olng.GetItemDesc("lblBranch");
            //lblSalesUnitCode.Text = olng.GetItemDesc("lblSalesUnitCode");commented by pranjali on 27-12-2013
            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblCnddtls.Text = "Franchisee Details";//olng.GetItemDesc("lblCnddtls");//Added by shreela on 10/03/14
            lblcndupload.Text = olng.GetItemDesc("lblcndupload");//Added by shreela on 11/03/14
            //lblExmType.Text = olng.GetItemDesc("lblExmType");
            //lblTitle_AdvDtl.Text = olng.GetItemDesc("lblTitle_AdvDtl");//Added for training Type
            lblHrnTrn.Text = olng.GetItemDesc("lblHrnTrn");
           
            lblAckrcv.Text = olng.GetItemDesc("lblAckrcv");//Added for label display on 17022014
            lblComplicnseExpDt.Text = olng.GetItemDesc("lblComplicnseExpDt");
            lblOldLcnexpDate.Text = olng.GetItemDesc("lblOldLcnexpDate");
            chkCompAgnt.Text = olng.GetItemDesc("chkCompAgnt");
            lblExam.Text = olng.GetItemDesc("lblExam"); //added by pranjali on 11-04-2014
            lblExmBody.Text = olng.GetItemDesc("lblExmBody"); //added by pranjali on 11-04-2014
            lblpreexamlng.Text = olng.GetItemDesc("lblpreexamlng"); //added by pranjali on 11-04-2014
            lblCentre.Text = olng.GetItemDesc("lblCentre"); //added by pranjali on 11-04-2014
            lblNExam.Text = olng.GetItemDesc("lblNExam"); //added by pranjali on 28-04-2014
            lblNExmBody.Text = olng.GetItemDesc("lblNExmBody"); //added by pranjali on 28-04-2014
            lblNpreexamlng.Text = olng.GetItemDesc("lblNpreexamlng"); //added by pranjali on 28-04-2014
            lblNCentre.Text = olng.GetItemDesc("lblNCentre"); //added by pranjali on 28-04-2014
            //Added by shreela on 18042014 start
            lblCndType.Text = olng.GetItemDesc("lblCndType");
            lblCount.Text = olng.GetItemDesc("lblCount");
            lblRenewType.Text = olng.GetItemDesc("lblRenewType");
            lbllyfTraining.Text = olng.GetItemDesc("lbllyfTraining");

            lblQCRenewType.Text = olng.GetItemDesc("lblQCRenewType");
            lblQClyfTraining.Text = olng.GetItemDesc("lblQClyfTraining");
            //Added by shreela on 18042014 end

            //shree07
            //lblinsrentype.Text = olng.GetItemDesc("lblQCRenewType");
            //lbllyftrngcmpltd.Text = olng.GetItemDesc("lblQClyfTraining");
            lblNWExmdt.Text = olng.GetItemDesc("lblNWExmdt");
            lblIsSPFlag.Text = olng.GetItemDesc("lblIsSPFlag");
            lblCACode.Text = olng.GetItemDesc("lblCACode");
            lblCAName.Text = olng.GetItemDesc("lblCAName");


            // new added code 08/06/2017  for bank detals
            lblbnkdtls.Text = olng.GetItemDesc("lblbnkdtls");
            lblbnkhldname.Text = olng.GetItemDesc("lblbnkhldname");
            lblbnkacno.Text = olng.GetItemDesc("lblbnkacno");
            lblbnkname.Text = olng.GetItemDesc("lblbnkname");
            lblbrnchname.Text = olng.GetItemDesc("lblbrnchname");
            lblactype.Text = olng.GetItemDesc("lblactype");
            lblifsccode.Text = olng.GetItemDesc("lblifsccode");
            lblmicrcode.Text = olng.GetItemDesc("lblmicrcode");
            //end new code 08/06/2017
            LblAadharId.Text = olng.GetItemDesc("LblAadharId");// Added by usha for Aadhar card  on 11.07.017
            LblAadharVerfy.Text = olng.GetItemDesc("LblAadharVerfy");

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

    #region viewData()
    //Method to view data on click of cndno link
    protected void viewData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@MemCode", strCndNo);
        htParam.Add("@AppNo", System.DBNull.Value);
        htParam.Add("@ReqDate", System.DBNull.Value);
        htParam.Add("@BranchCode", System.DBNull.Value);
        htParam.Add("@AdvName", System.DBNull.Value);
        htParam.Add("@Type", Request.QueryString["Type"].ToString().Trim());

        try
        {
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvForHrsTrn", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        hdnBizSrc.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        lblFrenchiseeCode.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                        //lblCscCodeValue.Text = dsResult.Tables[0].Rows[0]["CSCCode"].ToString().Trim();
                        //hdnCsccode.Value = dsResult.Tables[0].Rows[0]["CSCCode"].ToString().Trim();
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                        lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        //lblBranchCodeValue.Text = dsResult.Tables[0].Rows[0]["BranchCode"].ToString().Trim();//commented by pranjali on 27-12-2013
                        lblBranchValue.Text = dsResult.Tables[0].Rows[0]["Branch"].ToString().Trim();
                        //lblSalesUnitCodeValue.Text = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim(); //commented by pranjali on 27-12-2013
                        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["SMName"].ToString().Trim();
                        //lblTrnStartDateValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnStartDate"]).Trim();
                        //lblTrnEndDateValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnEndDate"].ToString()).Trim();
                      
                        ddlExmTpe.SelectedValue = dsResult.Tables[0].Rows[0]["ExamType"].ToString().Trim();
                        lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString()).Trim();
                        //Added by pranjali on 07-02-2014 for pan check checkbox start
                       
                        //Added by pranjali on 07-02-2014 for pan check checkbox end
                        //#region checking For waiver  
                        //hdnEntryDate.Value = dsResult.Tables[0].Rows[0]["EntryDate"].ToString().Trim();
                        //if (hdnBizSrc.Value == "AG" || hdnBizSrc.Value == "CN")
                        //{
                        //    if (DateTime.Now <= DateTime.Parse("31/03/2013"))
                        //    {
                        //        if (lblSponsorDt.Text == "")
                        //          {
                        //            if (DateTime.Parse(hdnEntryDate.Value) >= DateTime.Parse("04/02/2013") && DateTime.Parse(hdnEntryDate.Value) <= DateTime.Parse("15/02/2013"))
                        //            {
                        //                chkWebTknRecd.Checked = false;
                        //                chkWebTknRecd.Enabled = false;
                        //            }
                        //            else
                        //            {
                        //                chkWebTknRecd.Checked = true;
                        //            }
                        //        }
                        //        else if (DateTime.Parse(hdnEntryDate.Value) < DateTime.Parse("21/02/2013")) 
                        //        {
                        //             chkWebTknRecd.Checked = false;
                        //             chkWebTknRecd.Enabled = false;
                        //         }
                        //         else 
                        //            {
                        //                chkWebTknRecd.Checked = true;
                        //                 chkWebTknRecd.Enabled = true;
                        //            }
                        //    }
                        //    else
                        //    {
                        //        chkWebTknRecd.Checked = true;
                        //    }
                        //}

                        //#region for Fee Waiver
                        //else if (hdnBizSrc.Value == "CD")
                        //{
                        //    if (DateTime.Now <= DateTime.Parse("30/06/2013"))
                        //    {

                        //        if (lblSponsorDt.Text == "")
                        //        {
                        //            if (DateTime.Parse(hdnEntryDate.Value) >= DateTime.Parse("18/02/2013") && DateTime.Parse(hdnEntryDate.Value) <= DateTime.Parse("25/02/2013"))
                        //            {
                        //                chkWebTknRecd.Checked = false;
                        //                chkWebTknRecd.Enabled = false;
                        //            }
                        //            else
                        //            {
                        //                chkWebTknRecd.Checked = true;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            chkWebTknRecd.Checked = false;
                        //            chkWebTknRecd.Enabled = false;
                        //        }

                        //    }
                        //    else
                        //    {
                        //        chkWebTknRecd.Checked = true;
                        //    }
                        //}
                        //#endregion


                        //else
                        //{
                        //    chkWebTknRecd.Checked = true;
                        //}
                        //#endregion

                        txtMobileNo.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();
                        txtEMail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim() != "")
                        {
                            txtPAN.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                            txtPAN.Enabled = false;
                        }
                        else
                        {
                            txtPAN.Enabled = true;
                        }
                        //ddlExam.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExamMode"]).Trim();
                        //hdnExmCentreCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["ExamCenter"]).Trim();
                        //txtExmCentre.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ExamCenterName"]).Trim();
                        //ddlpreeamlng.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExamLanguage"]).Trim();

                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody"]).Trim() == "IIIOf")
                        {
                            ddlExmBody.Items[3].Enabled = true;
                        }
                        //ddlExmBody.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody"]).Trim();

                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]).Trim() == "P")
                        {
                            ddlBasicQual.SelectedValue = "SSC";
                            ddlBasicQual.Enabled = false;
                        }
                        else
                        {
                            ddlBasicQual.SelectedValue = "HSC";
                            ddlBasicQual.Enabled = false;
                        }
                        //added by pranjali on 04-03-2014 for training details start
                        ddlTrnMode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"]).Trim();
                        lblAccrdtnValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AccrdNo"]).Trim();
                        PopulateTrainingLoc(ddlTrnMode.SelectedValue);
                        ddlTrnLoc.SelectedItem.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TrainingLoc"]).Trim();
                        hdnTrnInstitute.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnInstitute"]).Trim();
                        PopulateTrainingInst(hdnTrnInstitute.Value, ddlTrnMode.SelectedValue);
                        ddlTrnInstitute.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnInstitute"]).Trim();
                        hdnTrnLocation.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]).Trim();
                        // ddlHrsTrn.SelectedValue = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                        //added by pranjali on 04-03-2014 for training details end

                        //hdnStartDate.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnStartDate"]);
                        hdnTccID.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TccID"]);
                        //lblPhotoPath.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AdvPhoto"]);
                        //lblPhotoPath.Visible = true;
                        //lblSignPath.Text = strDestDir + Convert.ToString(dsResult.Tables[0].Rows[0]["AdvSignature"]);
                        //lblSignPath.Visible = true;
                        //lblAdvWaiverUpl.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AdvWaiver"]);
                        //lblAdvWaiverUpl.Visible = true;
                        //lblPANPath.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AdvPAN"]);
                        //lblPANPath.Visible = true;
                        ////Added by rachana on 18122013 for showing uploaded NOC document start
                        //lblNoc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CndNOCDoc"]);
                        //lblNoc.Visible = true;
                        //Added by rachana on 18122013 for showing uploaded NOC document end
                    }
                }
            }
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
    #endregion

    #region FillData
    //To fill data on new request button 
    protected void FillData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@MemCode", strCndNo);
        //htParam.Add("@MemType", strCndNo);
        
        //Comneted by sanoj 27-12-2021
        //htParam.Add("@AppNo", System.DBNull.Value);
        //htParam.Add("@ReqDate", System.DBNull.Value);
        //htParam.Add("@BranchCode", System.DBNull.Value);
        //htParam.Add("@AdvName", System.DBNull.Value);
        //Comneted ended by sanoj 27-12-2021
        #region for Edit PAN Details
        //if (Request.QueryString["PANFlag"] != null)
        //{
        //    if (Request.QueryString["PANFlag"].ToString().Trim() == "Y")
        //    {
        //        htParam.Add("@Type", "P");
        //    }
        //}

        //else
        //{
        //    htParam.Add("@Type", Request.QueryString["Type"].ToString().Trim());
        //}
        #endregion for Edit PAN Details

        try
        {
            


            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvForHrsTrn", htParam);
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFrainchiseeSearchDtls", htParam);

            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsIsSpPrsn = new DataSet();

                        dsIsSpPrsn = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
                        ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();
                        if (dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim() == "YES")
                        {
                            if (dsResult.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                            {
                                divIsSpecified.Attributes.Add("style", "display:block");
                                rbtIsSP.SelectedValue = "Y";
                                tr_IsSPDtls.Visible = true;
                                txtCACode.Text = dsResult.Tables[0].Rows[0]["CACode"].ToString().Trim();
                                txtCAName.Text = dsResult.Tables[0].Rows[0]["CAName"].ToString().Trim();
                            }
                            else
                            {
                                divIsSpecified.Attributes.Add("style", "display:none");
                            }
                        }
                        else
                        {
                            divIsSpecified.Attributes.Add("style", "display:none");
                        }

                        
                        //ViewState["ReExamFlag"] = dsResult.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
                        //ViewState["TCCFlag"] = dsResult.Tables[0].Rows[0]["TCCFlag"].ToString().Trim();
                     
                        //ViewState["RenewalType"] = dsResult.Tables[0].Rows[0]["RenewalType"].ToString().Trim();
                        //hdnPanDtls.Value = dsResult.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();//Added by pranjali on 14-03-2014
                        hdnBizSrc.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        txtMemberCode.Text = dsResult.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                        txtFrenchCode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                        lblFrenchiseeCode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
                        lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["Title"].ToString().Trim()+ "  " + dsResult.Tables[0].Rows[0]["legalName"].ToString().Trim();//Added by ajay 20-06-2022
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                        //Added by pranjali on 27-12-2013 start
                        //cboTitle.Text = dsResult.Tables[0].Rows[0]["Title"].ToString().Trim();
                        txtGivenName.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString().Trim();
                       // txtname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString().Trim();
                        //txtFathername.Text = dsResult.Tables[0].Rows[0]["FatherName"].ToString().Trim();
                        ViewState["Address"] = dsResult.Tables[0].Rows[0]["Address"].ToString().Trim();
                        String GSTNAFlag = dsResult.Tables[0].Rows[0]["GSTNAFlag"].ToString().Trim();
                        String TNCFlag = dsResult.Tables[0].Rows[0]["TNCFlag"].ToString().Trim();
                        
                        if  (GSTNAFlag=="Y")
                        {
                            chkgst.Checked = true;
                            chkgst.Enabled = false;
                        }
                        if (TNCFlag == "Y")
                        {
                         chkagree.Checked = true;
                         chkagree.Enabled = false;
                        }
                        if (GSTNAFlag == "Y" && TNCFlag == "Y")
                        {
                            TblTandC.Visible = false;

                        }
                        else
                        {
                            TblTandC.Visible = true;
                        }
                        if (dsResult.Tables[0].Rows[0]["memtype"].ToString().Trim() == "RF")//added by sanoj 05062023
                        {
                            memberBnkDtls.Visible = true;
                            TblTandC.Visible = false;
                            btnReject.Visible = false;
                            lblFrechiseeName.Text = "Name";
                            lblFrnchcode.Text = "Code";
                            lblCnddtls.Text = "Member Details";
                            getdetails();
                            disableControls();
                            lblCndView.Visible = false;//added  byu sanoj 12062023
                            btnnectcfr.Attributes.Add("onClick", "Javascript:return validatiion();");

                        }

                        //added new code bhau 13/06/2017

                        txtbnkhldname.Enabled = false;
                        txtbnkacno.Enabled = false;
                        txtbnkname.Enabled = false;
                        txtbrnchname.Enabled = false;
                        ddlactype.Enabled = false;
                        txtifsccode.Enabled = false;
                        txtmicrcode.Enabled = false;

                        //txtbnkhldname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AcHolderName"]);
                        //txtbnkacno.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AccNo"]);
                        //txtbnkname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["bnkname"]);
                        //txtbrnchname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BranchName"]);
                        //ddlactype.SelectedValue = dsResult.Tables[0].Rows[0]["ACType"].ToString();
                        //txtifsccode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IFSC Code"]);
                        //txtmicrcode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MICR Code"]);
                        ////end added new code bhau 13/06/2017
                        ////Added by usha  for Aadhar no on 20.07.29017
                        //TxtAadharId.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AadharNo"]);
                        //TxtAadharVerfy.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TypeofAadharVerify"]);
                        ////Added by usha  for cr 4 and 5 on 01.06.2021
                        //lblRptMgr.Text = dsResult.Tables[0].Rows[0]["AddlRptMgrCode"].ToString();
                        //if (dsResult.Tables[0].Rows[0]["CndAnniversaryDt"].ToString ()!= "")
                        //{
                        //    LblAnnivrsry.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CndAnniversaryDt"])).ToString(CommonUtility.DATE_FORMAT);

                        //} if (TxtAadharVerfy.Text == "")
                        //{
                        //    LblAadharVerfy.Visible = false;
                        //    TxtAadharVerfy.Visible = false;


                        //}
                        //ended by usha  for Aadhar no on 20.07.29017

                       // cboGender.Text = dsResult.Tables[0].Rows[0]["Gender"].ToString().Trim();
                        string branchname;
                        branchname = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();
                        string cmsunitcode;
                        cmsunitcode = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString().Trim();
                        string branch = branchname + "(" + cmsunitcode + ")";
                        lblBranchValue.Text = branch;
                        hdnBranchCode.Value = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim(); //added by pranjali on 31-12-2013
                        //Added by pranjali on 27-12-2013 end                        
                      //  lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["SMName"].ToString().Trim();
                       // lblReqStatusValue.Text = dsResult.Tables[0].Rows[0]["Status"].ToString().Trim();
                       
                       // lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim(); //Added by kalyani on 23-04-14 for cand_type description
                        //added by shreela on 22/05/2014 start

                       // lblcndURNVal.Text = dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim();//added by shreela on 3/07/2014
                     
                        if (Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                        }
                        //else
                        //{
                        //    hdnRenwlCnt.Value = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                        //    hdnRenwl.Value = (Convert.ToInt32(hdnRenwlCnt.Value) + 1).ToString().Trim();
                        //    lblCountVal.Text = hdnRenwl.Value;
                        //}
                        
                        //if (dsResult.Tables[0].Rows[0]["IsPanFlag"].ToString() == "1")
                        //{
                        //    Chkpan.Checked = true;
                        //    Chkpan.Enabled = false;
                        //}
                        //else
                        //{
                        //    Chkpan.Checked = false;

                        //}
                        //Added by rachana on 11/04/2014 for fees details start
                        //if (dsResult.Tables[0].Rows[0]["WaiverFlag"].ToString().Trim() != null)
                        //{
                        //    hdnWebTknCon.Value = dsResult.Tables[0].Rows[0]["WaiverFlag"].ToString().Trim();
                        //}
                        //else
                        //{
                        //    hdnWebTknCon.Value = "";
                        //}
                         
                        //if (dsResult.Tables[0].Rows[0]["AutoWavierflag"].ToString().Trim() == "Y")
                        //{
                        //    ChkFeesWavier.Checked = true;
                        //    ChkFeesWavier.Enabled = false;
                        //}
                        //else
                        //{
                        //    ChkFeesWavier.Checked = false;
                        //}
                        //Comented by usha on 30.12.2021
                        //if (Request.QueryString["Type"].ToString().Trim().ToUpper() != "N")
                        //{
                        //    //Comented by usha 
                        //   // lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString()).Trim();
                        //    lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"].ToString()).Trim();
                        //}
                        //else
                        //{
                            lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"].ToString()).Trim();
                       // }
                        txtMobileNo.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();

                        txtEMail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();

                         
                        #region transfer/composite details fill
                        //Added by rachana for showing Candidate transfer/composite details start
                        //if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"] != null)
                        //{
                        //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnsfrFlag"]).Trim() != "")
                        //    {
                        //        if ((dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "1") || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True")
                        //        {
                        //            trnsfrtitle.Visible = true;
                        //            cbTrfrFlag.Checked = true;
                        //            divTrnsferDetails.Visible = true;
                        //            if (dsResult.Tables[0].Rows[0]["OldTccLcnno"] != null)
                        //            {
                        //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim() != "")
                        //                {
                        //                    txtOldTccLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim();
                        //                }
                        //            }

                        //            if (dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"] != null)
                        //            {
                        //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim() != "")
                        //                {

                        //                    ddlTrnsfrInsurName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim(); //Added by pranjali on 13-03-2014
                        //                }
                        //            }

                        //            if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"] != null)
                        //            {
                        //                if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"].ToString().Trim() != "")
                        //                {
                        //                    //txtOldTccLcnExpDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //                    txtDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //                }
                        //            }
                        //            if (dsResult.Tables[0].Rows[0]["LcnIssDate"] != null)
                        //            {
                        //                if (dsResult.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim() != "")
                        //                {
                        //                    //txtOldTccLcnExpDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //                    txtissudate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //                }
                        //            }
                        //        }

                        //        else
                        //        {
                        //            cbTrfrFlag.Checked = false;
                        //            divTrnsferDetails.Visible = false;
                        //            //trnsfrtitle.Visible = false;
                        //        }
                        //    }
                        //}

                        //if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True" || dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString() == "True")
                        //{
                        //    if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                        //    {
                        //        tblCndURN.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        if (dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim() != "")
                        //        {
                        //            tblCndURN.Visible = true;
                        //            txtCndURNNo.Text = dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim();
                        //        }
                        //        else
                        //        {
                        //            tblCndURN.Visible = true;
                        //            lblcndURNNo.Visible = true;
                        //            txtCndURNNo.Visible = true;
                        //        }
                        //    }
                        //}
                        //if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True")
                        //{
                        //    if (dsResult.Tables[0].Rows[0]["IRDATrnsfrReqNo"].ToString().Trim() != "")
                        //    {
                        //        tblCndURN.Visible = true;
                        //        TxtTrnsfrReqNo.Text = dsResult.Tables[0].Rows[0]["IRDATrnsfrReqNo"].ToString().Trim();
                        //        TxtTrnsfrReqNo.Visible = true;
                        //        lblTrnsfrReqNo.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        TxtTrnsfrReqNo.Visible = false;
                        //        lblTrnsfrReqNo.Visible = false;
                        //    }
                        //}
                        ////For Composite Flag
                        //if (dsResult.Tables[0].Rows[0]["TccCompLcn"] != null)
                        //{
                        //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["TccCompLcn"]).Trim() != "")
                        //    {
                        //        if ((dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString().Trim() == "True") || (dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString().Trim() == "1"))
                        //        {
                        //            cbTccCompLcn.Checked = true;
                        //            divCompositeDetails.Visible = true;
                        //            CompositeTitle.Visible = true;
                        //            txtCompLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicNo"]).Trim();
                        //            //added by pranjali on 11-04-2014 start
                        //            if (dsResult.Tables[0].Rows[0]["CompLicExpDt"] != null)
                        //            {
                        //                if (dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString().Trim() != "")
                        //                {
                        //                    txtCompLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"])).ToString(CommonUtility.DATE_FORMAT);
                        //                }
                        //            }
                        //            //added by pranjali on 11-04-2014 end
                        //            ddlCompInsurerName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CompInsrName"]).Trim();

                        //        }
                        //        else
                        //        {
                        //            //CompositeTitle.Visible = false;
                        //            cbTccCompLcn.Checked = false;
                        //            divCompositeDetails.Visible = false;
                        //        }
                        //    }
                        //}
                        ////txtTccPrevInsurerName.Text = dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"].ToString().Trim();
                        ////added by pranjali on 28-03-2014 start
                        //if (dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                        //{
                        //    trIsPriorAgt.Visible = true;
                        //    chkCompAgnt.Checked = true;
                        //    tblEmsdtls.Visible = false;
                        //    tblexam.Visible = false;
                        //}
                        //else
                        //{
                        //    trIsPriorAgt.Visible = true;
                        //    chkCompAgnt.Checked = false;
                        //}
                        ////added by pranjali on 28-03-2014 end
                        //if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() == "1")
                        //{
                        //    RbtNoc.SelectedIndex = 0;
                        //}
                        //else
                        //{
                        //    RbtNoc.SelectedIndex = 1;
                        //}
                        //if (dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() == "F")
                        //{
                        //    RbAckRev.SelectedIndex = 0;
                        //}
                        //else
                        //{
                        //    RbAckRev.SelectedIndex = 1;
                        //}
                        //Added by rachana for showing Candidate transfer/composite details end
                        #endregion
                         if (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "QcRes" || Request.QueryString["Type"].ToString().Trim() == "R" || Request.QueryString["Type"].ToString().Trim() == "E" || Request.QueryString["Type"].ToString().Trim() == "ReTrn")//added by pranjali on 28-04-2014
                        {
                            //ddlExam.SelectedValue = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();

                            //ddlExmBody.SelectedValue = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();

                            //ddlpreeamlng.SelectedValue = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                            //txtExmCentre.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                            //hdnExmCentreCode.Value = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                             
                            //Added by rachana on 04-06-2014 start
                            //GetCandidateType();
                            //if ((IsPriorAgt == "1") || (strCndType == "T") || (IsPriorAgt == "0") || (strCndType == "P"))// added by usha on 09.03.2020
                            //{
                            //tblEmsdtls.Visible = false;
                            // tblexam.Visible = false;
                            // Divoldtrndtls.Attributes.Add("Style", "display:none");
                            // tbltrn.Visible = false;
                            //  ddlExam.Enabled = false;
                            //  ddlExmBody.Enabled = false;
                            //  ddlpreeamlng.Enabled = false;
                            //ddlExmCentre.Enabled = false;
                            //txtExmCentre.Enabled = false;
                            // }
                           // {
                                //Added by usha  for exam center and languahe enable for inbox tan on 20.10.2015
                                if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "R")
                                {
                                    ddlpreeamlng.Enabled = true;
                                    ddlExmCentre.Enabled = true;
                                    tblEmsdtls.Visible = false;
                                    tblexam.Visible = false;
                                    Divoldtrndtls.Attributes.Add("Style", "display:none");
                                    tbltrn.Visible = false;
                                    ddlExam.Enabled = false;
                                    ddlExmBody.Enabled = false;
                                    enableBankDetails();//added by sanoj19062023
                                    lblNote1.Visible = false;//added by sanoj19062023
                                                         //ddlpreeamlng.Enabled = false;

                            }
                                //ended by usha 
                                else
                                {
                                    tblEmsdtls.Visible = false;
                                    tblexam.Visible = false;
                                    Divoldtrndtls.Attributes.Add("Style", "display:none");
                                    tbltrn.Visible = false;
                                    ddlExam.Enabled = false;
                                    ddlExmBody.Enabled = false;
                                    ddlpreeamlng.Enabled = false;
                                    //ddlExmCentre.Enabled = false;
                                    //txtExmCentre.Enabled = false;
                                }
                           // }


                            //else
                            //{
                            //    tblEmsdtls.Visible = true;
                            //    tblexam.Visible = true;
                            //    tbltrn.Visible = true;
                            //    ddlNExam.Enabled = true;
                            //    ddlNExmBody.Enabled = true;
                            //    ddlNpreeamlng.Enabled = true;
                                 
                            //}
                            //Added by rachana on 04-06-2014 end
                            Hashtable htren = new Hashtable();
                            //htren.Clear();
                            //DataSet dsren = new DataSet();
                            //dsren.Clear();
                            //htren.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dsren = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htren);
                            //if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")//Renewal QC
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                            //    {
                            //        txtExm.Text = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();
                            //    }
                            //    if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                            //    {
                            //        txtBody.Text = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();
                            //    }
                            //    if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                            //    {
                            //        txtLang.Text = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                            //    }
                            //    if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                            //    {
                            //        textoldexmcenter.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                            //    }
                            //    htdata.Clear();
                            //    ds_documentName.Clear();
                            //    htdata.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //    ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetTrnDtls", htdata);
                            //    if (ds_documentName.Tables[0].Rows.Count > 0)
                            //    {
                            //        if (ds_documentName.Tables[0].Rows[0]["TrnInstDesc01"].ToString() != "")
                            //        {
                            //            lblTrnInstituteValue.Text = ds_documentName.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                            //        }
                            //        if (ds_documentName.Tables[0].Rows[0]["TrainingLoc"].ToString() != "")
                            //        {
                            //            lblTrnLocValue.Text = ds_documentName.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                            //        }
                            //        if (ds_documentName.Tables[0].Rows[0]["TrnMode"].ToString() != "")
                            //        {
                            //            lblTrnModeValue.Text = ds_documentName.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                            //        }
                            //        if (ds_documentName.Tables[0].Rows[0]["AccrdNo"].ToString() != "")
                            //        {
                            //            lblAccvalue1.Text = ds_documentName.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                            //        }
                            //        if (ds_documentName.Tables[0].Rows[0]["HrsTrn"].ToString() != "")
                            //        {
                            //            lblTrnHrsValue1.Text = ds_documentName.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                            //        }
                            //    }
                            //}
                        }
                        //Hashtable htrexm = new Hashtable();
                        //htrexm.Clear();
                        //DataSet dsReExm = new DataSet();
                        //dsReExm.Clear();
                        //htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                        //dsReExm = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm);
                        //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                        //{
                        //    lblTrnInstituteValue.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                        //    lblTrnLocValue.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                        //    lblTrnModeValue.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                        //    lblAccvalue1.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                        //    lblTrnHrsValue1.Text = dsResult.Tables[0].Rows[0]["ParamDesc01"].ToString().Trim();
                        //    if (dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")
                        //    {
                        //        lblNWExmdtValue.Text = dsResult.Tables[0].Rows[0]["SystemExmDt"].ToString().Trim();
                        //        lblpref1value.Text = dsResult.Tables[0].Rows[0]["PrefferedExmDt1"].ToString().Trim();
                                 
                        //    }
                        //    ddlNExmBody.Items.Insert(0, "--Select--");
                        //    ddlNpreeamlng.Items.Insert(0, "--Select--");
                            
                        //}
                        //added by pranjali on 11-04-2014 end
                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim() != "")
                        {
                            txtPAN.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                          
                            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                            {

                            }
                        }
                        else
                        {
                                                      
                        }


                        //if (Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]).Trim() == "P")
                        //{
                        //    ddlBasicQual.SelectedValue = "SSC";
                        //    ddlBasicQual.Enabled = false;
                        //}
                        //else
                        //{
                        //    ddlBasicQual.SelectedValue = "HSC";
                        //    ddlBasicQual.Enabled = false;
                        //}
                        //hdnTrnLocation.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]).Trim();
                        //hdnTccID.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TccID"]);

                        //shreela 26-03-2014 start 
                        //if (Request.QueryString["TrnRequest"] != "Renewal" && Request.QueryString["Type"].ToString().Trim() != "Renwl")
                        //{
                        //    //added by shreela on 21042014--start
                        //    if (Request.QueryString["TrnRequest"].ToString().Trim() != "ReExam" && Request.QueryString["Type"].ToString().Trim() != "ReTrn")
                        //    {
                        //        if (dsResult.Tables[0].Rows[0]["RLRS"].ToString().Trim() == "1" && dsResult.Tables[0].Rows[0]["RenFlag"].ToString().Trim() == "")
                        //        {
                        //            btnSubmit.Visible = false;
                        //        }
                        //    }
                        //}
                         //shreela 26-03-2014 end 
                        //added by pranjali on 03-05-2014 start
                        if (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "R")
                        {
                            //added by shreela on 03052014 to not fill dropdown in renewals
                            //Hashtable htren = new Hashtable();//shree03
                            //htren.Clear();
                            //DataSet dsren = new DataSet();
                            //dsren.Clear();
                            //htren.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                            //dsren = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htren);
                            //if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                            //{
                            //    ddlTrnMode.SelectedValue = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                            //    PopulateTrainingInst(dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim(), dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                            //    PopulateTrainingLoc(dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                            //    if (dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim() == "")
                            //    {
                            //        ddlTrnLoc.SelectedIndex = 0;
                            //    }
                            //    else
                            //    {
                            //        ddlTrnLoc.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                            //    }
                            //    if (dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim() == "")
                            //    {
                            //        ddlTrnInstitute.SelectedIndex = 0;
                            //    }
                            //    else
                            //    {
                            //        ddlTrnInstitute.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                            //        ddlTrnInstitute.SelectedItem.Value = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim();
                            //    }
                            //    lblAccrdtnValue.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                            //    PopulateTrnType();
                            //    if (dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim() == "")
                            //    {
                            //        //ddlHrsTrn.SelectedIndex = 0;
                            //        ddlHrsTrn.ClearSelection();
                            //        ddlHrsTrn.Items.Insert(0, "--Select--");
                            //    }
                            //    else
                            //    {
                            //        ddlHrsTrn.SelectedValue = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                            //    }
                            //    if (dsren.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "")
                            //    {
                            //        ddlRenewType.ClearSelection();
                            //        ddlRenewType.Items.Insert(0, "---Select---");
                            //        //ddlRenewType.SelectedIndex = -1;
                            //    }
                            //    else
                            //    {
                            //        PopulateRenewalType();
                            //        ddlRenewType.SelectedValue = dsren.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                            //    }

                            //    if (dsren.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim() == "")
                            //    {
                            //        ddlRenewType.ClearSelection();
                            //    }
                            //    else
                            //    {
                            //        PopulateLifeTraining();
                            //        ddllyfTraining.SelectedValue = dsren.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                            //    }
                            //}
                            //else
                            //{
                            //    ddlTrnMode.SelectedValue = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                            //    PopulateTrainingInst(dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim(), dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                            //    PopulateTrainingLoc(dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                            //    if (dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim() == "")
                            //    {
                            //        ddlTrnLoc.SelectedIndex = 0;
                            //    }
                            //    else
                            //    {
                            //        ddlTrnLoc.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                            //    }
                            //    if (dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim() == "")
                            //    {
                            //        ddlTrnInstitute.SelectedIndex = 0;
                            //    }
                            //    else
                            //    {
                            //        ddlTrnInstitute.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                            //        ddlTrnInstitute.SelectedItem.Value = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim();
                            //    }
                            //    lblAccrdtnValue.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                            //    PopulateTrnType();
                            //    if (dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim() == "")
                            //    {
                            //        //ddlHrsTrn.SelectedIndex = 0;
                            //        ddlHrsTrn.Items.Insert(0, "--Select--");
                            //    }
                            //    else
                            //    {
                            //        ddlHrsTrn.SelectedValue = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                            //    }
                            //}

                        }
                        //added by pranjali on 03-05-2014 end
                        //added by rachana on 11/04/2014 for enable / disable fees chk box chkWebTknRecd start
                        #region enable / disable fees chk box chkWebTknRecd
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                        {
                            //chkWebTknRecd.Checked = true;
                            //chkWebTknRecd.Enabled = true;
                        }

                        else
                        {
                            if (hdnWebTknCon.Value == "1")
                            {
                                chkWebTknRecd.Checked = true;
                                chkWebTknRecd.Enabled = false;
                                // BindFeesDetails();
                            }
                            else
                            {
                                if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")//&& Request.QueryString["Type"].ToString().Trim() == "N")
                                {
                                    chkWebTknRecd.Checked = false;
                                    //chkWebTknRecd.Enabled = true;
                                }
                                else if (Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam" && Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                                {
                                    chkWebTknRecd.Checked = false;
                                    //chkWebTknRecd.Enabled = true;
                                }
                                else
                                {
                                    chkWebTknRecd.Checked = false;
                                    //chkWebTknRecd.Enabled = true;
                                }
                            }

                        #endregion
                            //added by rachana on 11/04/2014 for enable / disable fees chk box chkWebTknRecd end
                        }
                    }
                }
            }
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
    #endregion


    protected void InsertfeesDetails()
    {
        //Added by rachana on 20032014 to Save fees dtls [CndFeesDtls] start
        #region Fees Details Save
        string strDel;

        Hashtable htfeesDtls1 = new Hashtable();
        DataSet dsfeesDtls1 = new DataSet();
        htfeesDtls1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
        {
            htfeesDtls1.Add("@Flag", "RW");
        }
        else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
        {
            htfeesDtls1.Add("@Flag", "RE");
        }
        else
        {
            htfeesDtls1.Add("@Flag", "NR");
        }
        dsfeesDtls1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFeesDetailsforCnd", htfeesDtls1);

        if (dsfeesDtls1.Tables.Count > 0)
        {

            if (dsfeesDtls1.Tables[0].Rows.Count > 0)//if already exist moves to history table and again insert
            {

                Hashtable htDel = new Hashtable();
                htDel.Add("@AppNo", lblFrenchiseeCode.Text);
                htDel.Add("@MemCode", lblCndNoValue.Text);
                if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                {
                    htDel.Add("@Processtype", "RW");
                }
                else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                {
                    htDel.Add("@Processtype", "RE");
                }
                else
                {
                    htDel.Add("@Processtype", "NR");
                }


                strDel = dataAccessRecruit.execute_sprc_with_output("Prc_DeleteFeesDtls_new", htDel, "@strOut");

                #region if already exist moves to history table and again insert
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {
                    Hashtable Htfees = new Hashtable();
                    Label lblTokenNo = (Label)row.FindControl("lblTokenNo");
                    Label lblPymtMode = (Label)row.FindControl("lblPymtMode");
                    Label lblPymtDt = (Label)row.FindControl("lblPymtDt");
                    Label lblPymtAmt = (Label)row.FindControl("lblPymtAmt");
                    Label lblBankName = (Label)row.FindControl("lblBankName");
                    Label lblInstrumentNo = (Label)row.FindControl("lblInstrumentNo");
                    Label lblInstrumentDt = (Label)row.FindControl("lblInstrumentDt");
                    Label lblTrxNo = (Label)row.FindControl("lblTrxNo");
                    Label lblRcptId = (Label)row.FindControl("lblRcptId");

                    Htfees.Add("@AppNo", lblFrenchiseeCode.Text.ToString().Trim());
                    Htfees.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                    Htfees.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    Htfees.Add("@candType", hdnPanDtls.Value);
                    Htfees.Add("@PayMode", lblPymtMode.Text);


                    if (lblPymtMode.Text == "Cheque")
                    {
                        Htfees.Add("@InstrumentNo", lblInstrumentNo.Text);
                        Htfees.Add("@InstrumentDate", DateTime.Parse(lblInstrumentDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    }
                    else if (lblPymtMode.Text == "Draft")
                    {
                        Htfees.Add("@InstrumentNo", lblInstrumentNo.Text);
                        Htfees.Add("@InstrumentDate", DateTime.Parse(lblInstrumentDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    }
                    else
                    {
                        Htfees.Add("@InstrumentNo", System.DBNull.Value);
                        Htfees.Add("@InstrumentDate", System.DBNull.Value);
                    }
                    if (lblPymtAmt.Text == "")
                    {

                        Htfees.Add("@Amt", 0.00);
                    }
                    else
                    {
                        Htfees.Add("@Amt", Convert.ToDecimal(lblPymtAmt.Text));

                    }
                    Htfees.Add("@BnkName", lblBankName.Text);

                    Htfees.Add("@ReceiptNo", lblRcptId.Text);
                    if (lblTrxNo.Text != "")
                    {
                        Htfees.Add("@TrxNo", lblTrxNo.Text);
                    }
                    else
                    {
                        Htfees.Add("@TrxNo", System.DBNull.Value);
                    }
                    //Htfees.Add("@TrxidFK", lblTrxid.Text);
                    Htfees.Add("@PymtDt", DateTime.Parse(lblPymtDt.Text.Trim()).ToString("yyyyMMdd"));//lblPymtDt.Text);
                    Htfees.Add("@CreatDtime", System.DateTime.Now);
                    Htfees.Add("@UpdatedBy", System.DBNull.Value);
                    Htfees.Add("@UpdatedDtime", System.DBNull.Value);
                    if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                    {
                        Htfees.Add("@Flag", "RW");
                    }
                    else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                    {
                        Htfees.Add("@Flag", "RE");
                    }
                    else
                    {
                        Htfees.Add("@Flag", "NR");
                    }
                    string strvalue = dataAccessRecruit.execute_sprc_with_output("Prc_InsertFeesDtls_new", Htfees, "@strOut");
                    Htfees.Clear();
                }
                #endregion
            }
            else
            {
                Hashtable htDel = new Hashtable();
                htDel.Add("@AppNo", lblFrenchiseeCode.Text);
                htDel.Add("@MemCode", lblCndNoValue.Text);
                if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                {
                    htDel.Add("@Processtype", "RW");
                }
                else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                {
                    htDel.Add("@Processtype", "RE");
                }
                else
                {
                    htDel.Add("@Processtype", "NR");
                }


                strDel = dataAccessRecruit.execute_sprc_with_output("Prc_DeleteFeesDtls_new", htDel, "@strOut");

                #region if already not exist then insert newly
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {
                    Hashtable Htfees = new Hashtable();
                    Label lblTokenNo = (Label)row.FindControl("lblTokenNo");
                    Label lblPymtMode = (Label)row.FindControl("lblPymtMode");
                    Label lblPymtDt = (Label)row.FindControl("lblPymtDt");
                    Label lblPymtAmt = (Label)row.FindControl("lblPymtAmt");
                    Label lblBankName = (Label)row.FindControl("lblBankName");
                    Label lblInstrumentNo = (Label)row.FindControl("lblInstrumentNo");
                    Label lblInstrumentDt = (Label)row.FindControl("lblInstrumentDt");
                    Label lblTrxNo = (Label)row.FindControl("lblTrxNo");
                    Label lblRcptId = (Label)row.FindControl("lblRcptId");

                    Htfees.Add("@AppNo", lblFrenchiseeCode.Text.ToString().Trim());
                    Htfees.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                    Htfees.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    Htfees.Add("@candType", hdnPanDtls.Value);
                    Htfees.Add("@PayMode", lblPymtMode.Text);


                    if (lblPymtMode.Text == "Cheque")
                    {
                        Htfees.Add("@InstrumentNo", lblInstrumentNo.Text);
                        Htfees.Add("@InstrumentDate", DateTime.Parse(lblInstrumentDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    }
                    else if (lblPymtMode.Text == "Draft")
                    {
                        Htfees.Add("@InstrumentNo", lblInstrumentNo.Text);
                        Htfees.Add("@InstrumentDate", DateTime.Parse(lblInstrumentDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    }
                    else
                    {
                        Htfees.Add("@InstrumentNo", System.DBNull.Value);
                        Htfees.Add("@InstrumentDate", System.DBNull.Value);
                    }
                    if (lblPymtAmt.Text == "")
                    {

                        Htfees.Add("@Amt", 0.00);
                    }
                    else
                    {
                        Htfees.Add("@Amt", Convert.ToDecimal(lblPymtAmt.Text));

                    }
                    Htfees.Add("@BnkName", lblBankName.Text);

                    Htfees.Add("@ReceiptNo", lblRcptId.Text);
                    if (lblTrxNo.Text != "")
                    {
                        Htfees.Add("@TrxNo", lblTrxNo.Text);
                    }
                    else
                    {
                        Htfees.Add("@TrxNo", System.DBNull.Value);
                    }
                    //Htfees.Add("@TrxidFK", lblTrxid.Text);
                    Htfees.Add("@PymtDt", DateTime.Parse(lblPymtDt.Text.Trim()).ToString("yyyyMMdd"));//lblPymtDt.Text);
                    Htfees.Add("@CreatDtime", System.DateTime.Now);
                    Htfees.Add("@UpdatedBy", System.DBNull.Value);
                    Htfees.Add("@UpdatedDtime", System.DBNull.Value);
                    if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                    {
                        Htfees.Add("@Flag", "RW");
                    }
                    else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                    {
                        Htfees.Add("@Flag", "RE");
                    }
                    else
                    {
                        Htfees.Add("@Flag", "NR");
                    }
                    string strvalue = dataAccessRecruit.execute_sprc_with_output("Prc_InsertFeesDtls_new", Htfees, "@strOut");
                    Htfees.Clear();
                }
                #endregion
            }
        }



        #endregion
        //Added by rachana on 20032014 to Save fees dtls [CndFeesDtls] end
    }

    #region CVAdvWaiverValidator ServerValidate
    protected void CVAdvWaiverValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        #region commented
        //bool VFlag = false;
        //string UploadFileName = AdvWaiverUpload.PostedFile.FileName;

        //if (AdvWaiverUpload.PostedFile.ContentLength == 0)
        //{
        //    args.IsValid = false;
        //    lblMessage.Visible = false;
        //    CVAdvWaiverValidator.ErrorMessage = "Please Upload the Waiver form";
        //    VFlag = true;
        //}
        //else
        //{
        //    string Extension = UploadFileName.Substring(UploadFileName.LastIndexOf('.') + 1).ToLower();

        //    if (Extension == "doc" || Extension == "DOC" || Extension == "gif" || Extension == "GIF" || Extension == "jpg" || Extension == "JPG")
        //    {
        //        args.IsValid = true;
        //        CVAdvWaiverValidator.ErrorMessage = "";
        //    }
        //    else
        //    {
        //        VFlag = true;
        //        args.IsValid = false;
        //        CVAdvWaiverValidator.ErrorMessage = "It allows only Word/JPG/GIF Format.";
        //        lblMessage.Text = "It allows only Word/JPG/GIF Format.";
        //        lblMessage.Visible = true;
        //    }
        //    if (VFlag == false)
        //    {
        //        if (AdvWaiverUpload.PostedFile.ContentLength == 0)
        //        {
        //            args.IsValid = false;
        //            CVAdvWaiverValidator.ErrorMessage = "File size should be greater than 0 KB.";
        //            lblMessage.Text = "File size should be greater than 0 KB.";
        //            lblMessage.Visible = true;
        //        }
        //        else
        //        {
        //            args.IsValid = true;
        //            CVAdvWaiverValidator.ErrorMessage = "";
        //        }
        //        if (AdvWaiverUpload.PostedFile.ContentLength > 51200)
        //        {
        //            args.IsValid = false;
        //            CVAdvWaiverValidator.ErrorMessage = "File size should be upto 50 KB.";
        //            lblMessage.Text = "File size should be upto 50 KB.";
        //            lblMessage.Visible = true;
        //        }
        //        else
        //        {
        //            args.IsValid = true;
        //            CVAdvWaiverValidator.ErrorMessage = "";
        //        }
        //    }
        //}
        #endregion
    }
    #endregion

    #region checkPOINotExist()
    private bool checkPOINotExist()
    {
        bool POIFlag = false;
        try
        {

            drResult = null;
            //Added by ibrahim on 05-07-2013 To ChkPOI No. List Exist or Not  Start                                       
            htdata.Clear();
            htdata.Add("@AppNo", lblFrenchiseeCode.Text.Trim());
            htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_GetcheckPOINotExist", htdata);
            //Added by ibrahim on 05-07-2013 To ChkPOI No. List Exist or Not  End
            if (drResult.HasRows)
            {
                POIFlag = true;
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
        return POIFlag;
    }
    #endregion

    #region checkAdvPhotoNotExist()
    private bool checkAdvPhotoNotExist()
    {
        bool PhotoFlag = false;
        try
        {

            drResult = null;
            htdata.Clear();
            htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_GetAdvPhotoNotExist", htdata);
            if (drResult.HasRows)
            {
                PhotoFlag = true;
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
        return PhotoFlag;
    }
    #endregion

    #region EnabledCtrlforRepeater()
    private void EnabledCtrlforRepeater()
    {
        //Commented by pranjali on 02-01-2014 start
        //AgnPhotoUpload.Enabled = true;
        //AgnSignUpload.Enabled = true;
        //Commented by pranjali on 02-01-2014 end
        ddlExam.SelectedIndex = 0;
        ddlExmBody.SelectedIndex = 0;
        ddlpreeamlng.SelectedIndex = 0;
        txtExmCentre.Text = string.Empty;
        hdnExmCentreCode.Value = string.Empty;

        ddlExam.Enabled = true;
        ddlExmBody.Enabled = true;
        ddlpreeamlng.Enabled = true;
        //txtExmCentre.Enabled = true;
        btnExmCentre.Enabled = true;

        if (ddlExmTpe.SelectedValue != "REXM")
        {
            //PANUpload.Enabled = true; //Commented by pranjali on 02-01-2014 
        }

    }
    #endregion

    #region SpnsorshipDtExist()
    protected bool SpnsorshipDtExist()
    {
        bool IRDAFlag = false;
        try
        {

            drResult = null;
            //Added by ibrahim on 05-07-2013 To Chk Spnsorship Date Exist Start
            htdata.Clear();
            htdata.Add("@MemCode", Convert.ToString(hdnCndNo.Value).Trim());
            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_GetSpnsorshipDtExist", htdata);
            //Added by ibrahim on 05-07-2013 To Chk Spnsorship Date Exist End
            if (drResult.HasRows)
            {
                IRDAFlag = true;

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

        return IRDAFlag;

    }
    #endregion

    #region btnSubmit_Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            //added by shreela on 21042014
            if (Request.QueryString["Type"].ToString().Trim() != "ReTrn" && Request.QueryString["Type"].ToString().Trim() != "Renwl")
            {
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                
            }
            //Added by pranjali on 14-03-2014 for validation of composite case end
            Hashtable htparam = new Hashtable();
            if ((Request.QueryString["Type"].ToString().Trim().ToUpper() == "E") || (Request.QueryString["Type"].ToString().Trim().ToUpper() == "R"))
            {
                htparam.Clear();
                htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam);
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);

                if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "RE");
                    //htparam.Add("@InsurerType", "");
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                }
                else if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "RW");
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                }
                else
                {
                    if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htparam.Add("@ProcessType", "NR");
                    }
                    //htparam.Add("@ProcessType", "NR");
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                }

                htparam.Add("@CandType", strMemType);


            }
            else
            {
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                //httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1); //added by pranjali on 14-03-2014 start               
                htparam.Clear();
                htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htparam.Add("@MemType", ViewState["MemType"].ToString().Trim());
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                htparam.Add("@EntityType", Convert.ToString(ViewState["EntityType"]).Trim());//added by usha on 31052022
                //htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                
                ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemUpldDocNames", htparam); //added by pranjali on 11-04-2014  start
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
                             
                                if (mandtry == "C" && imgshrt == "3")
                            {
                                if (chkgst.Checked != true)
                                {
                                    btngst.Enabled = true;
                                    chkgst.Enabled = true;
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please upload Gst Certificate OR View the non GST Certificate   and  checked the checkbox for confirmation')", true);
                                    return;
                                }
                                
                            }
                        }

                    }//end of main for 
                }
                //Addded b uysha forTerms and condition

                //Added by ajay start

                //Added by ajay end
                htparam.Add("@flag", "1");// added by sanoj 03062022

                ds_documentName.Clear();
                ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemUpldDocNames", htparam); //added by pranjali on 11-04-2014  start
                if (ds_documentName.Tables.Count > 0)
                {
                    if (ds_documentName.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < ds_documentName.Tables[0].Rows.Count; i++)
                        {
                            string mandtry = ds_documentName.Tables[0].Rows[i]["DocCode"].ToString().Trim();

                            if (mandtry == "11" && chkagree.Checked != true)
                            {
                                btngst.Enabled = true;
                                btnView.Enabled = true;
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please view the term and condition document and checked the checkbox for confirmation.')", true);
                                return;
                            }
                        }
                    }
                }
                //Ended by usha 
                 
            }

            Save();
            //added by ajay 20-04-2023 start
            dgView.Columns[3].Visible = false;
            dgView.Columns[4].Visible = false;
            dgView.Columns[11].Visible = false;
            //added by ajay 20-04-2023 start
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

    #region system freez date updation integration
    //added by rachana on 17042014 for updating Freeze date start
    public void GetNoofDays()
    {

        DataSet dsetdays = new DataSet();
        dsetdays = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetNoofdays");

        if (dsetdays.Tables.Count > 0)
        {
            if (dsetdays.Tables[0].Rows.Count > 0)
            {
                iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["ParamDesc01"]);
            }
        }
    }
    public int GetNoofDaysForReexm()
    {

        DataSet dsetdays = new DataSet();
        Hashtable htdays = new Hashtable();
        htdays.Add("@CndType", hdnPanDtls.Value);
        htdays.Add("@REexmFlag", ViewState["ReExamFlag"].ToString());
        htdays.Add("@ValidTcc", ViewState["TCCFlag"].ToString());
        dsetdays = dataAccessRecruit.GetDataSetForPrcCLP("Prc_NoofDaysbasedonCndType", htdays);
        //dsetdays = dataAccessRecruit.GetDataSetForPrcCLP("Prc_NoofDaysbasedonCndType");

        if (dsetdays.Tables.Count > 0)
        {
            if (dsetdays.Tables[0].Rows.Count > 0)
            {
                iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["noofdays"]);
            }
        }
        return iNoOfDays;
    }
    //private void SetSysFreezeDate()
    //{
    //    DateTime date;
    //    DateTime SysFreezedate;
    //    string strbranchcode = string.Empty;
    //    string strCndNo = string.Empty;
    //    Hashtable htSubmitDt = new Hashtable();
    //    DataSet dset = new DataSet();
    //    // dset = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploadedDates");
    //    if (ViewState["ReExmType"].ToString() == "I")
    //    {
    //        htSubmitDt.Add("@Flag", 3);
    //    }
    //    else
    //    {
    //        htSubmitDt.Add("@Flag", 2);
    //    }


    //    //QS
    // //   dset = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploadedDates", htSubmitDt);


    //    //if (dset.Tables.Count > 0)
    //    //{
    //    //    if (dset.Tables[0].Rows.Count > 0)
    //    //    {
    //    //        for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
    //    //        {
    //    //            int iday = GetNoofDaysForReexm();
    //    //            #region to be uncommented on UAT start
    //    //            SysInrgConsum.GetHolidayConsume objhol = new SysInrgConsum.GetHolidayConsume();

    //    //            lstworkdays = objhol.GetWorkingdays(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), iNoOfDays);
    //    //            //DateTime DtUpld = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
    //    //            //DtUpld = DtUpld.AddDays(iNoOfDays);
    //    //            #endregion to be uncommented on UAT end
    //    //            strbranchcode = dset.Tables[0].Rows[i]["Branch"].ToString();
    //    //            strCndNo = dset.Tables[0].Rows[i]["CndNo"].ToString();

    //    //            #region synclogentry


    //    //            string strAppno = dset.Tables[0].Rows[i]["AppNo"].ToString();
    //    //            #region to be uncommented on UAT start
    //    //            string strInput = "<WorkingDaysInput><Branch>" + dset.Tables[0].Rows[i]["Branch"].ToString() + "</Branch><UpdatedDt>" + Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]) + "</UpdatedDt><NoOfdays>" + iNoOfDays + "</NoOfdays></WorkingDays>";
    //    //            string strOutput = "<WorkingDaysOutput>" + lstworkdays[0] + "</WorkingDaysOutput>";
                     
    //    //            #endregion to be uncommented on UAT end
    //    //            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //    //            date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);

    //    //            //sync Log entry


    //    //            int g;

    //    //            Hashtable htSync = new Hashtable();
    //    //            htSync.Add("@RefNo", strCndNo);
    //    //            htSync.Add("@AppNo", strAppno);
    //    //            htSync.Add("@XmlInput", strInput);
    //    //            htSync.Add("@CreatedBy", strcallerSystem);
    //    //            htSync.Add("@Xmloutput", strOutput);
    //    //            htSync.Add("@Resdate", System.DateTime.Now);
    //    //            htSync.Add("@Errdesc", "");
    //    //            htSync.Add("@MethodName", method.Name.ToString());
    //    //            g = dataAccessRecruit.execute_sprcMemrecruit("Prc_InsertSysFreezeDateSyncLog", htSync);

    //    //            #endregion

    //    //            date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
    //    //            #region to be uncommented on UAT start
    //    //            #region to be uncommented on UAT start
    //    //            //SysFreezedate = Convert.ToDateTime(lstworkdays[0]);
    //    //            string strDate = lstworkdays[0].ToString();
    //    //            //SysFreezedate = Convert.ToDateTime(dateString[2].Substring(0, 5) + "-" + dateString[0] + "-" + dateString[1]);
    //    //            //string strDate = DtUpld.ToString();
    //    //            //string[] dateString = strDate.Split('/');
    //    //            //string strdate1 = dateString[2].Substring(0, 5) + "-" + dateString[0] + "-" + dateString[1];
    //    //            //SysFreezedate = Convert.ToDateTime(strDate);
    //    //            #endregion
    //    //            #region to be uncommented on UAT start
    //    //            //UpdteDt(strbranchcode, strdate1, strCndNo);
    //    //            UpdteDt(strbranchcode, strDate, strCndNo);
    //    //            #endregion

    //    //            #endregion


    //    //        }
    //    //    }
    //    //}
    //}

    protected void UpdteDt(string BrnCode, string FreezeDt, string CndNo)
    {
        int f;
        Hashtable htsysemdate = new Hashtable();
        htsysemdate.Clear();
        htsysemdate.Add("@BranchCode", BrnCode);
        htsysemdate.Add("@MemCode", CndNo);
        htsysemdate.Add("@SysFreezeDate", FreezeDt);
        htsysemdate.Add("@Flag", 1);
        f = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdSysFreezeDates", htsysemdate);

    }
    //added by rachana on 17042014 for updating Freeze date end



    #endregion

    #region Save()
    private void Save()
    {
        try
        {
            string strvalue = string.Empty;
            string[] temp;
            string strT = string.Empty;
            string strF = string.Empty;
            DataSet dsFees = new DataSet();

            clsChannelSetup objChnSetup = new clsChannelSetup();
            ECRMFlag = 0;

            if (chkAdvWaiver.Checked == true)
            {
                if (AdvWaiverUpload.HasFile)
                {
                    strAdvWaiverName = AdvWaiverUpload.PostedFile.FileName;
                    strAdvWaiverExt = strAdvWaiverName.Substring(strAdvWaiverName.LastIndexOf('.') + 1).ToUpper();
                }
                hdnAdvWaiver.Value = "1";
            }
            else
            {
                hdnAdvWaiver.Value = "0";
            }
            //commented by pranjali on 31-12-2013 end
            htParam.Clear();
           // htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
            htParam.Add("@MemCode", txtMemberCode.Text.ToString().Trim());
            //htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
            
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
             htParam.Add("@ReqType", "HrTrn");
            
            

            int x = 0;
            //pranjali
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise") //&& Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                if (tblCndURN.Visible == true)
                {
                    if (txtCndURNNo.Text != "")
                    {
                        if (txtCndURNNo.Text.Length >= 12 && txtCndURNNo.Text.Length < 20)
                        {
                            Regex reg = new Regex("[a-zA-Z]");
                            bool a;
                            a = reg.IsMatch(txtCndURNNo.Text);
                            if (Convert.ToString(a) == "True")
                            {
                            }
                            else
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. should contain atleast one alphabet .')", true);
                                return;
                            }
                        }
                        else
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. length should be greater than 11 and less than 20.')", true);
                            return;
                        }
                    }
                    if (txtCndURNNo.Text != "")
                    {
                        Hashtable htUrnChk = new Hashtable();
                        DataSet dsUrnChk = new DataSet();
                        htUrnChk.Add("@CndURN", txtCndURNNo.Text);
                        htUrnChk.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                        dsUrnChk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetChkCndURNNo", htUrnChk);
                        if (dsUrnChk.Tables[0].Rows.Count > 0)
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is not a Unique No.')", true);
                            return;
                        }
                    }
                }
                //added by pranjali on 27-03-2014 start
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    if (txtOldTccLcnNo.Text != txtCompLicNo.Text)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License No and Life License No must be same')", true);
                        return;
                    }
                }
                //added by pranjali on 27-03-2014 end
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                htParam.Add("@TccID", Convert.ToString(hdnTccID.Value));

                //added by pranjali on 24022014 for adding details of transfer from inbox details start
                htParam.Add("@TrfrFlag", cbTrfrFlag.Checked == true ? "1" : "0");
                htParam.Add("@NOCFlag", RbtNoc.SelectedValue == "Y" ? "1" : "0");
                htParam.Add("@OldTccLcnNo", txtOldTccLcnNo.Text.Trim());
                if (txtDate.Text.Trim() != "")
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
                //if (txtCndURNNo.Text.Trim() != "")
                //{
                //    htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                //}
                //else
                //{
                //    htParam.Add("@CndURNNo", System.DBNull.Value);
                //}
                htParam.Add("@TccCompLcn", cbTccCompLcn.Checked == true ? "1" : "0");
                //added by pranjali on 24022014 for adding details of transfer from inbox details start

                //added by pranjali on 14-03-2014 for inserting composite information start
                htParam.Add("@CompLicNo", txtCompLicNo.Text.Trim());
                if (txtCompLicExpDt.Text.Trim() != "")
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
                htParam.Add("@IsPriorAgt", chkCompAgnt.Checked == true ? "1" : "0");//added by pranjali on 27-03-2014 
                if (tblCndURN.Visible == true)
                {
                    if (txtCndURNNo.Text.Trim() != "")
                    {
                        htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@CndURNNo", System.DBNull.Value);
                    }
                    if (TxtTrnsfrReqNo.Text.Trim() != "")
                    {
                        htParam.Add("@TxtTrnsfrReqNo", TxtTrnsfrReqNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@TxtTrnsfrReqNo", System.DBNull.Value);
                    }
                }
                if (Request.QueryString["Type"].ToString().Trim() == "R")
                {
                    DataSet dsloc = new DataSet();
                    dsloc.Clear();
                    Hashtable httable = new Hashtable();
                    httable.Add("@TrnCode", ddlTrnLoc.SelectedItem.Text);
                    dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetLocCODEQC", httable);
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        string trnloccode = dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString();
                    }
                    if (ddlTrnMode.SelectedIndex != 0)
                    {
                        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    }
                    else
                    {
                        htParam.Add("@TrnMode", System.DBNull.Value);
                    }
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                    }
                    else
                    {
                        htParam.Add("@TrnLoc ", System.DBNull.Value);
                    }
                    if (ddlTrnLoc.SelectedValue != "" && ddlTrnLoc.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnInstitute", System.DBNull.Value);
                    }
                    if (lblAccrdtnValue.Text != "")
                    {
                        htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                    }
                    else
                    {
                        htParam.Add("@AccrdNo", System.DBNull.Value);
                    }
                    if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    if (ddlExam.SelectedValue != "")
                    {
                        htParam.Add("@ExamMode", ddlExam.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExamMode", System.DBNull.Value);
                    }
                    if (ddlExmBody.SelectedValue != "")
                    {
                        htParam.Add("@ExmBody", ddlExmBody.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmBody", System.DBNull.Value);
                    }
                    if (ddlpreeamlng.SelectedValue != "")
                    {
                        htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmLang", System.DBNull.Value);
                    }
                    //if (txtExmCentre.Text != "")
                    //{
                    //    //htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                    //    htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    //}
                    if (hdnExmCentreCode.ToString() != "")
                    {

                        htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                    }
                    else if (txtExmCentre.Text != "")
                    {
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@ExmCentre", System.DBNull.Value);
                    }
                    DataSet dtstcndtyp = new DataSet();
                    Hashtable hscndtyp = new Hashtable();
                    hscndtyp.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                    dtstcndtyp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMemberType", hscndtyp);
                    //htParam.Add("@AutoWavierFlag", dtstcndtyp.Tables[0].Rows[0]["AutoWavierflag"].ToString().Trim());
                    //htParam.Add("@AutoWavierFlagBy", dtstcndtyp.Tables[0].Rows[0]["AutoWavierflagBy"].ToString().Trim());

                }

                if (Request.QueryString["Type"].ToString().Trim() == "Qc")
                {
                    DataSet dsloc = new DataSet();
                    dsloc.Clear();
                    Hashtable httable = new Hashtable();
                    httable.Add("@TrnCode", ddlTrnLoc.SelectedItem.Text);
                    dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetLocCODEQC", httable);
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        string trnloccode = dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString();
                    }
                    if (ddlTrnMode.SelectedIndex != 0)
                    {
                        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    }
                    else
                    {
                        htParam.Add("@TrnMode", System.DBNull.Value);
                    }
                    //Added by pranjali on 07-03-2014 for null value for location code start
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                    }
                    else
                    {
                        htParam.Add("@TrnLoc ", System.DBNull.Value);
                    }
                    //Added by pranjali on 07-03-2014 for null value for location code end
                    //htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString())); 
                    if (ddlTrnLoc.SelectedValue != "" && ddlTrnLoc.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    //htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnInstitute", System.DBNull.Value);
                    }
                    //htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    if (lblAccrdtnValue.Text != "")
                    {
                        htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                    }
                    else
                    {
                        htParam.Add("@AccrdNo", System.DBNull.Value);
                    }
                    //added by rachana on 01/04/2014 to save Trntype start
                    if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    if (ddlExam.SelectedValue != "")
                    {
                        htParam.Add("@ExamMode", ddlExam.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExamMode", System.DBNull.Value);
                    }
                    if (ddlExmBody.SelectedValue != "")
                    {
                        htParam.Add("@ExmBody", ddlExmBody.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmBody", System.DBNull.Value);
                    }
                    if (ddlpreeamlng.SelectedValue != "")
                    {
                        htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmLang", System.DBNull.Value);
                    }
                     

                    if (hdnExmCentreCode.ToString() != "")
                    {

                        htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                    }
                    else if (txtExmCentre.Text != "")
                    {
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@ExmCentre", System.DBNull.Value);
                    }
                    // BindGridCom(lblCndNoValue.Text, lblFrenchiseeCode.Text);//added by Nikhil
                    DataSet dtstcndtyp = new DataSet();
                    Hashtable hscndtyp = new Hashtable();
                    hscndtyp.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());

                    dtstcndtyp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMemberType", hscndtyp);
                    if (dtstcndtyp.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y" && dtstcndtyp.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                    {
                        DataSet dsDoc = new DataSet();
                        Hashtable htdoc = new Hashtable();
                        dsDoc.Clear();
                        htdoc.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                        htdoc.Add("@DocCode", "28");
                        dsDoc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_ChkIRDACloseCFR", htdoc);
                        //if (dsDoc.Tables.Count > 0)
                        //{
                        //FOR LICENSE USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND -- IRDA CFR RAISED
                        if (dsDoc.Tables[0].Rows.Count > 0)
                        {
                            htParam.Add("@MvmtDesc", "QC-IRDA Error");
                            x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdTrnReqForLicUser", htParam);
                        }
                        //FOR LICENSE USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND -- Normal CFR RAISED
                        else
                        {
                            htParam.Add("@MvmtDesc", "QC-LicUserCase");
                            x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdTrnReqForLicUser", htParam);
                        }
                        //}

                    }
                }
                //FOR BRANCH USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND 
                else
                {
                    x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateTrnReqDtl", htParam); //Added by pranjali on 02-01-2014 to update details
                    BindGridCom(lblCndNoValue.Text, lblFrenchiseeCode.Text);//added by Nikhil
                }
                
            }

            //added by pranjali -----start

            #region Renewal submit
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                #region Fresh/Transfer
                htParam.Clear();
                htParam.Add("@AppNo", lblFrenchiseeCode.Text.ToString().Trim());
                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                htParam.Add("@CountVal", hdnRenwlCnt.Value);
                if (chkWebTknRecd.Checked == true)
                {
                    htParam.Add("@WaiverFlag", "1");
                }
                else
                {
                    htParam.Add("@WaiverFlag", "0");
                }
                htParam.Add("@ReqType", "Rnwl");
               
                htParam.Add("@PAN", Convert.ToString(txtPAN.Text).Trim());
                htParam.Add("@InsRenewalType", "");
                htParam.Add("@OthrTrnComp", "");


                htParam.Add("@Updatedby", Session["UserID"].ToString().Trim());
                strvalue = dataAccessRecruit.execute_sprc_with_output("Prc_InsRenwlDtls", htParam, "@strOut");

                //MailResponse();
                //MAIL
                #endregion
            }
            #endregion
            //added by pranjali -----end
            //added by shreela on 27032014--start
            #region ReExam submit
            if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            {

                if (chkWebTknRecd.Checked == true)
                {
                    htParam.Add("@WaiverFlag", "1");
                    hdnWebTknCon.Value = "1";
                }
                else
                {
                    htParam.Add("@WaiverFlag", "0");
                    hdnWebTknCon.Value = "0";
                }
                htParam.Add("@Updatedby", Session["UserID"].ToString().Trim());
                #region  AuditLog
                //arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                //arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                ////arrLst.Add(new prjXml.Collection("WaiverFlag", hdnAdvWaiver.Value));
                //arrLst.Add(new prjXml.Collection("WaiverFlag", hdnWebTknCon.Value));
                //if (strAdvWaiverExt.ToUpper().Trim() == "doc" || strAdvWaiverExt.ToUpper().Trim() == "DOC")
                //{
                //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                //}
                //else if (strAdvWaiverExt.ToUpper().Trim() == "GIF" || strAdvWaiverExt.ToUpper().Trim() == "gif")
                //{
                //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                //}
                //else if (strAdvWaiverExt.ToUpper().Trim() == "JPG" || strAdvWaiverExt.ToUpper().Trim() == "jpg")
                //{
                //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                //}
                //else if (strAdvWaiverExt.ToString().Trim() == "" || strAdvWaiverExt.ToString().Trim() == null)
                //{
                //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "0"));
                //}
                //prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                //XmlDocument xDoc = new XmlDocument();
                //xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                //strXML = xDoc.OuterXml;
                //arrLst.Clear();
                #endregion Auditlog
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                string ReExm = Request.QueryString["ReExm"].ToString();
                htParam.Add("@ReExmcntValue", ReExm);
                //added by pranjali on 29-04-2014 start for sponsorship link ie. Invalid TCC
                Hashtable htrexm = new Hashtable();
                htrexm.Clear();
                DataSet dsReExm = new DataSet();
                dsReExm.Clear();
                htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
                if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC //added by pranjali on 28-04-2014
                {
                    if (hdnNExmCenter.Value == "")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Centre')", true);
                        return;
                    }
                    htParam.Add("@ExamMode", ddlNExam.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmBody", ddlNExmBody.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmLang", ddlNpreeamlng.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmCentre", hdnNExmCenter.Value);


                    dsFees.Clear();
                    dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsReExmDtls", htParam);
                    // MailResponse();

                    //added by pranjali on 29-04-2014 start for sponsorship link ie. Invalid TCC
                }
                Hashtable htCB = new Hashtable();
                DataSet dsgetSponsorshipDtl = new DataSet();

                if (ECRMFlag == 1)
                {
                    htParam1.Clear();
                }

                btnSubmit.Enabled = false;
                if (x != 0)
                {
                    if (chkAdvWaiver.Checked == true)
                    {
                        InsertUploadFile_AdvWaiverForm();
                    }
                }
            }
            #endregion
            //added by shreela on 27032014--end
            #region new request submit
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                //Added by usha for recruiter details on 01.06.2022
                htParam.Add("@chkgstFlag", chkgst.Checked == true ? "Y" : "N");
                htParam.Add("@chkagreeFlag", chkagree.Checked == true ? "Y" : "N");
                dsFees.Clear();
                dsFees = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsertMemTrnReqDtl", htParam);
                ConvertRDLCToPDF(Request.QueryString["MemCode"].ToString().Trim());//Added by usha on 31052022
                lblFrenchiseeCode.Text = dsFees.Tables[0].Rows[0]["Empcode"].ToString();
                
                btnSubmit.Enabled = true;
                
            }
            #endregion
            #region edit submit
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {

                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                htParam.Add("@TccID", Convert.ToString(hdnTccID.Value));
                //added by rachana on 14022014 start
                htParam.Add("@TrfrFlag", cbTrfrFlag.Checked == true ? "1" : "0");
                htParam.Add("@NOCFlag", RbtNoc.SelectedValue == "Y" ? "1" : "0");
                htParam.Add("@OldTccLcnNo", txtOldTccLcnNo.Text.Trim());
                if (txtDate.Text.Trim() != "")
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

                htParam.Add("@TccCompLcn", cbTccCompLcn.Checked == true ? "1" : "0");

                //added by pranjali on 14-03-2014 for inserting composite information start
                htParam.Add("@CompLicNo", txtCompLicNo.Text.Trim());
                if (txtCompLicExpDt.Text.Trim() != "")
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
                htParam.Add("@IsPriorAgt", chkCompAgnt.Checked == true ? "1" : "0");//added by pranjali on 27-03-2014 
                if (tblCndURN.Visible == true)
                {
                    if (txtCndURNNo.Text.Trim() != "")
                    {
                        htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@CndURNNo", System.DBNull.Value);
                    }
                    if (TxtTrnsfrReqNo.Text.Trim() != "")
                    {
                        htParam.Add("@TxtTrnsfrReqNo", TxtTrnsfrReqNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@TxtTrnsfrReqNo", System.DBNull.Value);
                    }
                }

                #region for AuditLog
                //arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                //arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                //arrLst.Add(new prjXml.Collection("TccID", Convert.ToString(hdnTccID.Value)));
                //prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                //XmlDocument xDoc = new XmlDocument();
                //xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                //strXML = xDoc.OuterXml;
                //arrLst.Clear();
                #endregion Auditlog

                //x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateTrnHrsDtls", htParam);
                x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateTrnReqDtl", htParam); //Added by pranjali on 02-01-2014 to update details 
                btnSubmit.Enabled = false;

                #region Pan Updation 12.3.2012
                drResult = null;
                #endregion
            }
            #endregion
            #region reexm not used
            else if (ddlExmTpe.SelectedValue == "REXM")
            {
                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                {
                    htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                    htParam.Add("@Email", txtEMail.Text.Trim());
                    if (hdnBizSrc.Value == "AG" || hdnBizSrc.Value.ToString() == "CN")
                    {
                        if (DateTime.Now <= DateTime.Parse("31/03/2013"))
                        {
                            if (lblSponsorDt.Text == "")
                            {
                                htParam.Add("@WaiverFlag", "1");
                            }
                            else if (DateTime.Parse(hdnEntryDate.Value) < DateTime.Parse("21/02/2013"))
                            {
                                htParam.Add("@WaiverFlag", "1");
                            }
                            else
                            { htParam.Add("@WaiverFlag", "0"); }


                        }
                        else
                        {
                            htParam.Add("@WaiverFlag", hdnAdvWaiver.Value);
                        }
                    }


                    if (hdnBizSrc.Value == "CD")
                    {
                        if (DateTime.Now <= DateTime.Parse("30/06/2013"))
                        {

                            if (lblSponsorDt.Text == "")
                            {
                                htParam.Add("@WaiverFlag", "1");
                            }
                            else
                            { htParam.Add("@WaiverFlag", "0"); }

                        }
                        else
                        {
                            htParam.Add("@WaiverFlag", hdnAdvWaiver.Value);
                        }
                    }


                    else
                    {
                        htParam.Add("@WaiverFlag", hdnAdvWaiver.Value);
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

                    #region for AuditLog
                    //arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                    //arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                    //arrLst.Add(new prjXml.Collection("WaiverFlag", hdnAdvWaiver.Value));
                    //if (strAdvWaiverExt.ToUpper().Trim() == "doc" || strAdvWaiverExt.ToUpper().Trim() == "DOC")
                    //{
                    //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                    //}
                    //else if (strAdvWaiverExt.ToUpper().Trim() == "GIF" || strAdvWaiverExt.ToUpper().Trim() == "gif")
                    //{
                    //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                    //}
                    //else if (strAdvWaiverExt.ToUpper().Trim() == "JPG" || strAdvWaiverExt.ToUpper().Trim() == "jpg")
                    //{
                    //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "1"));
                    //}
                    //else if (strAdvWaiverExt.ToString().Trim() == "" || strAdvWaiverExt.ToString().Trim() == null)
                    //{
                    //    arrLst.Add(new prjXml.Collection("AdvWaiverForm", "0"));
                    //}
                    //prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    //XmlDocument xDoc = new XmlDocument();
                    //xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    //strXML = xDoc.OuterXml;
                    //arrLst.Clear();
                    #endregion Auditlog

                    if (ECRMFlag == 0)
                    {
                        Hashtable htparam = new Hashtable();
                        DataSet dsPANverify = new DataSet();
                        //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  start
                        htdata.Clear();
                        htdata.Add("@MemCode", hdnCndNo.Value);
                        dsPANverify = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPANverify", htdata);
                        //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  End
                        if (dsPANverify.Tables[0].Rows.Count > 0)
                        {
                            htParam1.Clear();
                            htParam1.Add("@MemCode", dsPANverify.Tables[0].Rows[0]["cndno"].ToString());
                            htParam1.Add("@GCN", dsPANverify.Tables[0].Rows[0]["GCN"].ToString());
                            htParam1.Add("@PAN", txtPAN.Text);
                            htParam1.Add("@Createdby", Session["UserID"].ToString().Trim());
                            dataAccessRecruit.execute_sprc("Proc_adv_panupdation", htParam1);
                            htParam1.Clear();
                            htParam1.Add("@LGAGCode", dsPANverify.Tables[0].Rows[0]["CndNo"].ToString().Trim());
                            htParam1.Add("@ClientCode", dsPANverify.Tables[0].Rows[0]["GCN"].ToString());
                            htParam1.Add("@PaNNo", txtPAN.Text);
                            htParam1.Add("@GroupFlag", "ADV");
                            ECRMFlag = 1;
                        }
                    }
                    x = dataAccessRecruit.execute_sprcMemrecruit("Prc_InsertTrnHrsDtls", htParam);

                    if (ECRMFlag == 1)
                    {
                        dataAccessRecruit.exec_crmcommand("Prc_InsertIntoInscPANUpd", htParam1);
                        htParam1.Clear();
                    }

                    btnSubmit.Enabled = false;

                    if (x != 0)
                    {
                        if (chkAdvWaiver.Checked == true)
                        {
                            InsertUploadFile_AdvWaiverForm();
                        }
                    }
                }
                else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                {
                    htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                    htParam.Add("@Email", txtEMail.Text.Trim());
                    htParam.Add("@TccID", Convert.ToString(hdnTccID.Value));
                    #region for AuditLog
                    //arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                    //arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                    //arrLst.Add(new prjXml.Collection("TccID", Convert.ToString(hdnTccID.Value)));
                    //prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    //XmlDocument xDoc = new XmlDocument();
                    //xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    //strXML = xDoc.OuterXml;
                    //arrLst.Clear();
                    #endregion for Auditlog
                    x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateTrnHrsDtls", htParam);
                    btnSubmit.Enabled = false;
                }
            }
            #endregion
            
            #region not used
            if (ddlExmTpe.SelectedValue == "NADV")
            {
            }
            if (ddlExmTpe.SelectedValue == "REXM")
            {
            }
            #endregion
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise")// && Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                trmsg.Visible = true;
                lblMessage.Text = "Updated Successfully";
                lblSub.Text = "Updated Successfully<br/><br/>"  + "<br/>Code: " + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text;
                mdlpopupSub.Show();
                lblMessage.Visible = true;
            }
            //added by pranjali -----start
            else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                //added by shreela on 8/04/2014 start
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetIncRenewalCnt", htParam);
                //added by shreela on 8/04/2014 end
                trmsg.Visible = true;
                lblMessage.Text = "License Renewal Request Submitted Successfully";
                lblSub.Text = "License Renewal Request Submitted Successfully<br/><br/>" +  "<br/>Code: " + lblFrenchiseeCode.Text
                                + "<br/>Name: " + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;//added by shreela on 09/06/2014
                mdlpopupSub.Show();
                lblMessage.Visible = true;
            }
            //added by pranjali -----end
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start 
                trmsg.Visible = true;
                lblMessage.Text = "Document uploaded Successfully";
                lblSub.Text = "Sponsorship Request Raised Successfully<br/>" + "<br/>Code: "
                    + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;//added by shreela on 09/06/2014

                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {
                        //lblpopup.Text = lblpopup.Text + "<br/>Token No: " + dsFees.Tables[0].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[0].Rows[0]["TotalFees"].ToString();
                    }
                }
                else
                {
                   // lblpopup.Text = lblpopup.Text + "<br/>Total Fees: 0.00";
                }
                //if (ViewState["SMChanel"].ToString() == "XXSO")
                //{
                //    mdlpopup.Show();
                //    trmsg.Visible = true;
                //    lblMessage.Visible = true;
                //    btnSubmit.Enabled = false;

                //}
                //else
                //{

                    // Lblagentmsz.Visible = true;
                    //lblpopup.Text = lblpopup.Text;// +Lblagentmsz.Text; comented by usha on 19.11.2021
                //lblpopup.Text = lblpopup.Text; //commented by ajay 23.06.2022
                //    mdlpopup.Show();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true); 
                    trmsg.Visible = true;
                    lblMessage.Visible = true;
                    btnSubmit.Enabled = false;
                //}
            }
            //added by shreela on 21042014---start
            else if (Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam" && Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdReExmCnt", htParam);
                x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdReExmCnt", htParam);
                trmsg.Visible = true;
                lblMessage.Text = "ReTraining Request Raised Successfully";
                lblSub.Text = "ReTraining Request Raised Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text
                    + "<br/>Application No: " + lblFrenchiseeCode.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                //+ "<br/>Token No: " + strT + "<br/>Total Fees: " + strF;
                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {
                        lblSub.Text = lblSub.Text + "<br/>Token No: " + dsFees.Tables[0].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[0].Rows[0]["TotalFees"].ToString();
                    }
                }
                else
                {
                    lblSub.Text = lblSub.Text + "<br/>Total Fees: 0.00";
                }
                mdlpopupSub.Show();
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end
                trmsg.Visible = true;
                lblMessage.Visible = true;
                btnSubmit.Enabled = false;
            }
            //added by shreela on 21042014---end
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start
                trmsg.Visible = true;
                lblMessage.Text = "Document Updated Successfully";
                lblpopup.Text = "Document Updated Successfully<br/><br/>"  + "<br/>Code: "
                    + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text;
                mdlpopup.Show();
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end
                lblMessage.Visible = true;
            }
            btnSubmit.Enabled = false;

            //}
            htParam.Clear();
            ProgressBarModalPopupExtender.Hide();//for hiding progressbar

            #region for Audit Log
            string procname = "";
            string strAgntCode = "";
            strAgntCode = lblCndNoValue.Text;
            trmsg.Visible = true;
            if (lblMessage.Text == "Sponsorship Request Raised Successfully" || lblMessage.Text == "Sponsorship Request Updated Successfully")
            {
                ErrMsg = "S";
            }
            else
            {
                ErrMsg = "E";
            }
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                AuditType = "IN";
                //procname = "Prc_InsertTrnHrsDtls"; //commented by pranjali on 02-01-2014
                procname = "Prc_InsertTrnReqDtl";

            }
            else
            {
                AuditType = "UP";
                procname = "Prc_UpdateTrnHrsDtls";
            }


            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";

            ErrSrc = "SQ";
            objChnSetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + strAgntCode, "AdvTrnHrsReqSubmit", "50Hrs Submit,DataAccessLayer.cs", procname, Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
            #endregion  for AuditLog

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
    #endregion

    private void GetCandidateDtls()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsDtls = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberDetails", htDtls);
        ViewState["MemType"] = dsDtls.Tables[0].Rows[0]["MemType"].ToString().Trim();
        ViewState["EntityType"] = dsDtls.Tables[0].Rows[0]["EntityType"].ToString();
        //ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        //ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
        ViewState["ProcessType"] = "NR";//dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        strMemType = dsDtls.Tables[0].Rows[0]["MemType"].ToString().Trim(); //Added by Nikhil
        
        ViewState["SMChanel"] = dsDtls.Tables[0].Rows[0]["SMChanel"].ToString().Trim();


    }

    private void GetUserSAPCode()
    {
        Hashtable htSAP = new Hashtable();
        DataSet dsSAP = new DataSet();
        htSAP.Add("@AppNo", lblFrenchiseeCode.Text);
        dsSAP = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUserSAPCode", htSAP);
        ViewState["SAP"] = dsSAP.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
    }
    private void MailResponse()
    {
        GetUserSAPCode();
        Hashtable htParam = new Hashtable();
        DataSet dsres = new DataSet();
        htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsres = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam);
        if (dsres.Tables[0].Rows.Count > 0)
        {
            ViewState["InsRenewalType"] = dsres.Tables[0].Rows[0]["InsRenewalType"].ToString();
        }
        Hashtable htrexm = new Hashtable();
        htrexm.Clear();
        DataSet dsReExm = new DataSet();
        dsReExm.Clear();
        htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        dsReExm = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm);
        ViewState["ReExmType"] = dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
        ViewState["ReExamFlag"] = dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
        //getCandidateDetails();
        try
        {
            string strUserID = Session["UserID"].ToString();
            Hashtable htData = new Hashtable();
            DataSet ds = new DataSet();
            ds.Clear();
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                //New Request
                htData.Add("@Param1", "Spon");
                htData.Add("@Param3", "30");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param2", ViewState["CandType"].ToString());
            }
            else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                //Renewal request
                htData.Add("@Param1", "Spon");
                htData.Add("@Param3", "30");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param2", ViewState["CandType"].ToString());
            }
            //else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            //{

            //    //Re-exam Details Invalid
            //    htData.Add("@Param1", "ReTrn");
            //    htData.Add("@Param3", "30");
            //    htData.Add("@Param4", ViewState["ProcessType"].ToString());
            //    //htData.Add("@Param5", ViewState["ReExmType"].ToString());//"I");
            //    htData.Add("@Param2", ViewState["CandType"].ToString());
            //}
            else if (ViewState["RenewalFlag"].ToString() != "Y" && ViewState["ReExamFlag"].ToString() != "Y")
            {
                //Normal QC
                htData.Add("@Param1", "QC");
                htData.Add("@Param3", "60");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "T");
                    CandidateType = "T";
                }
                else if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "T");
                    CandidateType = "T";
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "C");
                    CandidateType = "C";
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "F");
                    CandidateType = "F";
                }

                //htData.Add("@Param2", ViewState["CandType"].ToString());
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y" && ViewState["CandType"].ToString() == "F")
            {
                //Reneawl QC
                htData.Add("@Param1", "QC");
                htData.Add("@Param3", "60");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "T");
                }
                else if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "T");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "C");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "F");
                }
                //htData.Add("@Param2", ViewState["CandType"].ToString());
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y" && ViewState["CandType"].ToString() == "C")
            {
                htData.Add("@Param1", "QC");
                htData.Add("@Param3", "90");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param5", ViewState["InsRenewalType"].ToString());
                if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "T");
                }
                else if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "T");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == true))
                {
                    htData.Add("@Param2", "C");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == false))
                {
                    htData.Add("@Param2", "F");
                }
            }
            else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "V")
            {
                //Reexam QC
                htData.Add("@Param1", "QC");
                htData.Add("@Param3", "60");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param5", ViewState["ReExmType"].ToString());
                htData.Add("@Param2", "F");
            }
            else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "I")
            {
                htData.Add("@Param1", "ITraining");
                htData.Add("@Param3", "90");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param5", ViewState["ReExmType"].ToString());
                htData.Add("@Param2", "F");
            }
            else if (ViewState["RnwlQCFlag"].ToString().Trim() == "Y")
            {
                //Second QC Renewal
                htData.Add("@Param1", "QC");
                htData.Add("@Param3", "60");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param2", ViewState["CandType"].ToString());
            }
            ds = dataAccessRecruit.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                        //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());


                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                        {
                            //New Request
                            objmailcomm.SendNoticationMailSMS("ARTL", "Spon", "F", "30", "NR", "", NotifyTo, lblCndNoValue.Text, ViewState["SAP"].ToString().Trim());

                        }
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
                        {
                            //Renewal request
                            objmailcomm.SendNoticationMailSMS("ARTL", "Spon", "F", "30", "RW", "", "CR", lblCndNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        //else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                        //{

                        //    //Re-exam Details Invalid
                        //    objmailcomm.SendNoticationMailSMS("ARTL", "ReTrn", "F", "30", "RE", "", "CR", lblCndNoValue.Text, Session["UserID"].ToString().Trim());
                        //}
                        else if (ViewState["RenewalFlag"].ToString() != "Y" && ViewState["ReExamFlag"].ToString() != "Y")
                        {
                            //Normal QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", CandidateType, "60", "NR", "", NotifyTo, lblFrenchiseeCode.Text, ViewState["SAP"].ToString().Trim());

                        }
                        else if (ViewState["RenewalFlag"].ToString() == "Y" && ViewState["CandType"].ToString() == "C")
                        {
                            //Reneawl QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", ViewState["CandType"].ToString(), "90", "RW", ViewState["InsRenewalType"].ToString(), NotifyTo, lblFrenchiseeCode.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "V")
                        {
                            //Reexam QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", "F", "60", "RE", ViewState["ReExmType"].ToString(), NotifyTo, lblFrenchiseeCode.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "I")
                        {
                            //Reexam QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "ITraining", "F", "90", "RE", ViewState["ReExmType"].ToString(), NotifyTo, lblFrenchiseeCode.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (ViewState["RnwlQCFlag"].ToString().Trim() == "Y")
                        {
                            //Second QC Renewal
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", "F", "60", "RW", "", NotifyTo, lblCndNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString().Trim();
            trmsg.Visible = true;
            lblMessage.Visible = true;

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        //MAIL
    }

    #region Button 'Clear Click Event'
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Changed and added new code to close window start
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "Qc")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        //added by shreela on 18042014
        else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        //added by ajay for back functionality start 20-04-2023
        else if (Request.QueryString["Pg"] != null)
        {
            if (Request.QueryString["Pg"].ToString().Trim() == "50hrs")
            {
                string ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                Response.Redirect("FranchiesSerach.aspx?Pg=50hrs&Status=NW&Code=Spon" + "&ModuleID=" + ModuleID);
            }
        }
        //added by ajay for back functionality end 20-04-2023
        else
        {
            Response.Redirect("FPAdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NW&Code=Spon");
        }
        //Changed and added new code to close window end
    }
    #endregion

    #region IsAlphaNumeric
    public bool IsAlphaNumeric(String strToCheck)
    {
        Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9 ]");
        return !objAlphaNumericPattern.IsMatch(strToCheck);
    }
    #endregion

    #region InsertUploadFile_Photo()
    protected void InsertUploadFile_Photo()
    {
        //string sDirPath = Server.MapPath(strPath);
        //sDirPath = sDirPath + "/" + DateTime.Now.AddYears + DateTime.Now.AddMonths + DateTime.Now.AddDays;

        //DirectoryInfo ObjSearchDir = new DirectoryInfo(sDirPath);

        //if (!ObjSearchDir.Exists)
        //{
        //    ObjSearchDir.Create();
        //}


        //strDestDir = @"D:\PALDCTMFiles";//commented
        //strDestDir = @"~UploadedFiles\\";// +DateTime.Today.Date + "\\" + lblCndNoValue.Text;
        // DirectoryInfo objDir = new DirectoryInfo(@"~UploadedFiles\\" + DateTime.Today.Date + "\\" + lblCndNoValue.Text.Trim());
        if (Directory.Exists(strPath) == false)
        {
            strPath = strPath + lblCndNoValue.Text.Trim();
            Directory.CreateDirectory(strPath);
        }
        if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_Photo.JPG";
            strFileName = strPath + "\\" + strFileName;
        }
        else if (strPhotoExt == "GIF" || strPhotoExt == "gif")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_Photo.GIF";
            strFileName = strPath + strFileName;
        }

        strDestPath = System.IO.Path.Combine(strPath, strFileName);
        //AgnPhotoUpload.PostedFile.SaveAs(strDestPath); //Commented by pranjali on 02-01-2014 

        htdata.Clear();
        htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Photo");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@MemCode", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's Photo");
                ds = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDataPALDCTMFileUpload", ht);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
            lblMessage.Text = ex.Message.ToString();
            lblMessage.Visible = true;
        }

        //AgnPhotoUpload.Dispose(); //Commented by pranjali on 02-01-2014
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    #endregion

    #region InsertUploadFile_Sign()
    protected void InsertUploadFile_Sign()
    {
        strDestDir = @"D:\PALDCTMFiles";
        if (Directory.Exists(strDestDir) == false)
        {
            Directory.CreateDirectory(strDestDir);
        }

        if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_Signature.JPG";
        }
        else if (strPhotoExt == "GIF" || strPhotoExt == "gif")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_Signature.GIF";
        }

        strDestPath = System.IO.Path.Combine(strDestDir, strFileName);
        // AgnSignUpload.PostedFile.SaveAs(strDestPath); //Commented by pranjali on 02-01-2014 
        htdata.Clear();
        htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Signature");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@MemCode", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's Signature");
                ds = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDataPALDCTMFileUpload", ht);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
            lblMessage.Text = ex.Message.ToString();
            lblMessage.Visible = true;
        }

        //AgnSignUpload.Dispose(); //Commented by pranjali on 02-01-2014
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    #endregion

    #region InsertUploadFile_PAN()
    protected void InsertUploadFile_PAN()
    {
        strDestDir = @"D:\PALDCTMFiles";
        if (Directory.Exists(strDestDir) == false)
        {
            Directory.CreateDirectory(strDestDir);
        }

        if (strPANExt == "PDF" || strPANExt == "pdf")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_PANProof.PDF";//"_ARFPANEDUProof.PDF";//Extension changed by rachana on 20122013
        }
        strDestPath = System.IO.Path.Combine(strDestDir, strFileName);
        //PANUpload.PostedFile.SaveAs(strDestPath); //Commented by pranjali on 02-01-2014

        htdata.Clear();
        htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's PAN");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);

            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@MemCode", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's PAN");
                ds = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDataPALDCTMFileUpload", ht);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
            lblMessage.Text = ex.Message.ToString();
            lblMessage.Visible = true;
        }

        //PANUpload.Dispose(); //Commented by pranjali on 02-01-2014
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    #endregion

    #region InsertUploadFile_AdvWaiverForm()
    protected void InsertUploadFile_AdvWaiverForm()
    {
        strDestDir = @"D:\PALDCTMFiles";
        if (Directory.Exists(strDestDir) == false)
        {
            Directory.CreateDirectory(strDestDir);
        }
        if (strAdvWaiverExt == "DOC" || strAdvWaiverExt == "DOC")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_AdvWaiver.DOC";
        }
        else if (strAdvWaiverExt == "GIF" || strAdvWaiverExt == "gif")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_AdvWaiver.GIF";
        }
        else if (strAdvWaiverExt == "JPG" || strAdvWaiverExt == "jpg")
        {
            strFileName = lblCndNoValue.Text.Trim() + "_AdvWaiver.JPG";
        }

        strDestPath = System.IO.Path.Combine(strDestDir, strFileName);
        AdvWaiverUpload.PostedFile.SaveAs(strDestPath);

        htdata.Clear();
        htdata.Add("@MemCode", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Waiver Form");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
            }

        }
        catch (Exception ex)
        {
            trmsg.Visible = true;
            lblMessage.Text = ex.Message.ToString();
            lblMessage.Visible = true;
        }

        AdvWaiverUpload.Dispose();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    #endregion

    //added by pranjali on 10-04-2014 for exam mode for old exam details start
    #region Exam Mode
    private void PopulateExamMode()
    {
        try
        {

            oCommon.getDropDown(ddlExam, "ExmMode", 1, "", 1);
            ddlExam.Items.Insert(0, "--Select--");
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
    //added by amruta for transfer spon exam code start on 16.6.15
    private void PopulateExamCode()
    {
        try
        {

            oCommon.getDropDown(ddlExamCode, "ExmCode", 1, "", 1);
            ddlExamCode.Items.Insert(0, "--Select--");
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
    //added by amruta for transfer spon exam code end on 16.6.15
    #endregion
    //added by pranjali on 10-04-2014 for exam mode for old exam details end

    //added by pranjali on 28-04-2014 for exam mode for new exam details start
    #region New Exam Mode
    private void PopulateNewExamMode()
    {
        try
        {

            oCommon.getDropDown(ddlNExam, "ExmMode", 1, "", 1);
            ddlNExam.Items.Insert(0, "--Select--");
            //ddlTrnLoc.Items.Insert(0, "--Select--");
            //ddlTrnInstitute.Items.Insert(0, "--Select--");
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
    //added by pranjali on 28-04-2014 for exam mode for new exam details end

    //added by pranjali on 10-04-2014 for ExmLanguages for old exam details start
    #region PopulatePreExmLanguages()
    private void PopulatePreExmLanguages()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmLang");
            ddlpreeamlng.DataSource = dsresult;
            ddlpreeamlng.DataTextField = "Language";
            ddlpreeamlng.DataValueField = "Language";
            ddlpreeamlng.DataBind();
            ddlpreeamlng.Items.Insert(0, "--Select--");
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
    //added by pranjali on 10-04-2014 for ExmLanguages for old exam details end

    //added by pranjali on 28-04-2014 for ExmLanguages for new exam details start
    #region PopulateNewPreExmLanguages()
    private void PopulateNewPreExmLanguages()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmLang");
            ddlNpreeamlng.DataSource = dsresult;
            ddlNpreeamlng.DataTextField = "Language";
            ddlNpreeamlng.DataValueField = "Language";
            ddlNpreeamlng.DataBind();
            ddlNpreeamlng.Items.Insert(0, "--Select--");
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
    //added by pranjali on 28-04-2014 for ExmLanguages for new exam details end

    //added by pranjali on 10-04-2014 for ExmBodyName for old exam details start
    #region PopulateExmBodyName()
    private void PopulateExmBodyName()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmBody");
            ddlExmBody.DataSource = dsresult;
            ddlExmBody.DataTextField = "ExmBody";
            ddlExmBody.DataValueField = "ExmBodyCode";
            ddlExmBody.DataBind();
            ddlExmBody.Items.Insert(0, "--Select--");
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
    //added by pranjali on 10-04-2014 for ExmBodyName for old exam details end

    //added by pranjali on 28-04-2014 for ExmBodyName for new exam details start
    #region PopulateNewExmBodyName()
    private void PopulateNewExmBodyName()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmBody");
            ddlNExmBody.DataSource = dsresult;
            ddlNExmBody.DataTextField = "ExmBody";
            ddlNExmBody.DataValueField = "ExmBody";
            ddlNExmBody.DataBind();
            ddlNExmBody.Items.Insert(0, "--Select--");
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
    //added by pranjali on 28-04-2014 for ExmBodyName for new exam details end

    //added by pranjali on 10-04-2014 for ExmBodyName for old exam details start
    #region PopulateExmCentre()
    private void PopulateExmCentre()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmCenter");
            ddlExmCentre.DataSource = dsresult;
            ddlExmCentre.DataTextField = "ExmCenter";
            ddlExmCentre.DataValueField = "ExmCenter";
            ddlExmCentre.DataBind();
            ddlExmCentre.Items.Insert(0, "--Select--");
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
    //added by pranjali on 10-04-2014 for ExmBodyName for old exam details end

    //added by pranjali on 28-04-2014 for ExmBodyName for new exam details start
    #region PopulateNewExmCentre()
    private void PopulateNewExmCentre()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmCenter");
            ddlNExmCenter.DataSource = dsresult;
            ddlNExmCenter.DataTextField = "ExmCenter";
            ddlNExmCenter.DataValueField = "ExmCenter";
            ddlNExmCenter.DataBind();
            ddlNExmCenter.Items.Insert(0, "--Select--");
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
    //added by pranjali on 28-04-2014 for ExmBodyName for new exam details end


    #region FreezTrnInstLoc()
    // Method for exam type
    private void FreezTrnInstLoc()
    {
        ddlTrnMode.SelectedValue = "Online";
        ddlTrnMode.Enabled = false;
        //txtTrnLocation.Text = "Online";
        hdnTrnLocation.Value = "Online";
        //btnTrnLocation.Enabled = false;
    }
    #endregion
    //added by pranjali on 04-03-2014 for selected index change start
    #region ddlTrnMode SelectedIndexChanged Event
    protected void ddlTrnMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        htdata.Clear();
        htdata.Add("@TrnType", ddlTrnMode.SelectedValue);
        if (ddlTrnMode.SelectedValue == "OFFLINE")
        {
            SqlDataReader dtRead;
            dtRead = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnLoc", htdata);
            htdata.Clear();
            if (dtRead.HasRows)
            {
                ddlTrnLoc.DataSource = dtRead;
                ddlTrnLoc.DataTextField = "TrnLocDesc";
                ddlTrnLoc.DataValueField = "TrnType";
                ddlTrnLoc.DataBind();
                ddlTrnLoc.Items.Insert(0, "--Select--");
                ddlTrnInstitute.Items.Insert(0, "--Select--");
                ddlTrnInstitute.SelectedIndex = 0;
                lblAccrdtnValue.Text = "";
            }
            dtRead = null;
        }
        //added by pranjali on 11-03-2014 for selected index change start
        else
        {
            SqlDataReader dtRead;
            dtRead = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnLoc", htdata);
            htdata.Clear();
            if (dtRead.HasRows)
            {
                ddlTrnLoc.DataSource = dtRead;
                ddlTrnLoc.DataTextField = "TrnLocDesc";
                ddlTrnLoc.DataValueField = "TrnType";
                ddlTrnLoc.DataBind();
                ddlTrnLoc.Items.Insert(0, "--Select--");
                ddlTrnInstitute.Items.Insert(0, "--Select--");
                ddlTrnInstitute.SelectedIndex = 0;
                lblAccrdtnValue.Text = "";
            }
            dtRead = null;
        }
        //added by pranjali on 11-03-2014 for selected index change end
    }
    #endregion

    #region ddlTrnLoc SelectedIndexChanged Event
    protected void ddlTrnLoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        htdata.Clear();
        htdata.Add("@TrnCode", ddlTrnLoc.SelectedValue);
        htdata.Add("@TrnType", ddlTrnMode.SelectedValue);
        if (ddlTrnMode.SelectedValue == "OFFLINE")
        {
            SqlDataReader dtRead1;
            dtRead1 = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnInst", htdata);
            htdata.Clear();

            if (dtRead1.HasRows)
            {

                ddlTrnInstitute.DataSource = dtRead1;
                ddlTrnInstitute.DataTextField = "TrnInstDesc01";
                ddlTrnInstitute.DataValueField = "TrnCode";
                ddlTrnInstitute.DataBind();
                ddlTrnInstitute.Items.Insert(0, "--Select--");
                lblAccrdtnValue.Text = "";
            }
            dtRead1 = null;
        }
        //added by pranjali on 11-03-2014 for selected index change start
        else
        {
            SqlDataReader dtRead1;
            dtRead1 = objDAL.Recruit_exec_reader_prc("Prc_GetddlTrnInst", htdata);
            htdata.Clear();

            if (dtRead1.HasRows)
            {
                ddlTrnInstitute.Items.Clear();
                ddlTrnInstitute.DataSource = dtRead1;
                ddlTrnInstitute.DataTextField = "TrnInstDesc01";
                ddlTrnInstitute.DataValueField = "TrnCode";
                ddlTrnInstitute.DataBind();
                ddlTrnInstitute.Items.Insert(0, "--Select--");
            }
            dtRead1 = null;
        }
        //added by pranjali on 11-03-2014 for selected index change end
    }
    #endregion
    //added by pranjali on 04-03-2014 for selected index change end
    //added by pranjali on 11-03-2014 for selected index change start
    protected void ddlTrnInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsAccrdtn = new DataSet();
        htdata.Clear();
        htdata.Add("@TrnCode", ddlTrnInstitute.SelectedValue);
        dsAccrdtn = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAccrdtnNo", htdata);
        lblAccrdtnValue.Text = dsAccrdtn.Tables[0].Rows[0]["AccLocCode"].ToString();
        PopulateTrnType();

    }
    //added by pranjali on 11-03-2014 for selected index change end
    #region ddlcatapp SelectedIndexChanged Event
    protected void ddlcatapp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcatapp.Text == "FR")
        {

            lblCategory.Visible = true;
            ddlcat.Visible = true;

            trLife.Visible = false;
            trHealth.Visible = false;
            trHealthIns.Visible = false;
            trIns.Visible = false;
        }
        else if (ddlcatapp.SelectedItem.Text == "--Select--")
        {
            ddlcat.Visible = false;
            lblCategory.Visible = false;
            trLife.Visible = false;
            trHealth.Visible = false;
            cbLife.Checked = false;
            cbHealth.Checked = false;
            ddlIns.SelectedItem.Text = "--Select--";
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
            ddlInsname.SelectedItem.Text = "--Select--";
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
            txtOther.Text = "";
            txtOtherH.Text = "";
            trHealthIns.Visible = false;
            trIns.Visible = false;

        }
        else
        {
            // CatCompNOC(ddlcat);
            ddlcat.Visible = false;
            lblCategory.Visible = false;
            trLife.Visible = true;
            trHealth.Visible = true;
            cbLife.Checked = false;
            cbHealth.Checked = false;
            ddlIns.SelectedItem.Text = "--Select--";
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
            ddlInsname.SelectedItem.Text = "--Select--";
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
            txtOther.Text = "";
            txtOtherH.Text = "";

        }
        // tdCat.Visible = true;
        //tdddlCat.Visible = true;
    }
    #endregion
    #region cbLife CheckedChanged
    protected void cbLife_CheckedChanged(object sender, EventArgs e)
    {
        if (cbLife.Checked == true)
        {
            trIns.Visible = true;
            NameInsuranceNOCLife();
            ddlIns.SelectedItem.Text = "--Select--";
            txtOther.Text = "";
            txtOther.Enabled = false;

        }
        else
        {
            trIns.Visible = false;
        }
    }
    #endregion
    #region cbHealth CheckedChanged
    protected void cbHealth_CheckedChanged(object sender, EventArgs e)
    {
        if (cbHealth.Checked == true)
        {
            trHealthIns.Visible = true;
            NameInsuranceNOCHealth();
            ddlInsname.SelectedItem.Text = "--Select--";
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
        }
        else
        {
            trHealthIns.Visible = false;
        }

    }
    #endregion

    #region ddlIns SelectedIndexChanged Event
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedItem.Text == "Others")
        {
            txtOther.Enabled = true;
        }
        else
        {
            txtOther.Text = "";
            txtOther.Enabled = false;
        }

    }
    #endregion
    #region ddlInsName SelectedIndexChanged Event
    protected void ddlInsname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInsname.SelectedItem.Text == "Others")
        {
            txtOtherH.Enabled = true;
        }
        else
        {
            txtOtherH.Text = "";
            txtOtherH.Enabled = false;
        }

    }
    #endregion
    //added by pranjali on 11-03-2014 for selected index change end
    #region ddlExmTpe SelectedIndexChanged Event
    protected void ddlExmTpe_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    #endregion

    #region PopulateCasteCat()
    //To display list of caste category from IsysLookupParam table
    private void PopulateCasteCat()
    {
        try
        {
            oCommon.getDropDown(ddlCasteCat, "CasteCat", 1, "", 1);
            ddlCasteCat.Items.Insert(0, "--Select--");
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

    #region PopulateBasicQual()
    //To display list of basic qualification from IsysLookupParam table
    private void PopulateBasicQual()
    {
        try
        {
            oCommon.getDropDown(ddlBasicQual, "BasicQual", 1, "", 1);
            ddlBasicQual.Items.Insert(0, "--Select--");
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

    #region PopulateProofIDDoc()
    //To education qualification list from IsysLookupParam table
    private void PopulateProofIDDoc()
    {
        try
        {
            string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();
            ddleducationproof.Items.Clear();
            //Added By Ibrahim on 07-05-2013 to convert inline query to procedure Start
            htdata.Clear();
            dseducationproof.SelectCommand = "Prc_GetParamBindFORNBEduQua";
            //Added By Ibrahim on 07-05-2013 to convert inline query to procedure End
            ddleducationproof.DataBind();
            ddleducationproof.Items.Insert(0, new ListItem("--Select--", ""));
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

   


   

    #region chkAdvWaiver CheckedChanged Events
    protected void chkAdvWaiver_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAdvWaiver.Checked == true)
        {
            hdnWebTkn.Value = "1";
            chkWebTknRecd.Visible = false;
            lblWebTknReceived.Visible = false;
            spwebtoken.Visible = false;
            lbladvWaiverbtn.Visible = true;
            AdvWaiverUpload.Visible = true;
            spwaiver.Visible = true;
        }
        else
        {
            hdnWebTkn.Value = "0";
            chkWebTknRecd.Visible = true;
            lblWebTknReceived.Visible = true;
            spwebtoken.Visible = true;
            lbladvWaiverbtn.Visible = false;
            AdvWaiverUpload.Visible = false;
            spwaiver.Visible = false;
        }
    }
    #endregion
    private void GetChkRespond()
    {
        try
        {

            foreach (GridViewRow row in dgDetailsInbox.Rows)
            {




                Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");

                DataSet dsFlag1 = new DataSet();
                Hashtable htParam2 = new Hashtable();
                htParam2.Add("@DocCode", lblCFRDocCode.Text.Trim());
                htParam2.Add("@MemCode", Request.QueryString["MemCode"].ToString());
                dsFlag1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_MemRespondFlag", htParam2);
                string strFlag1 = dsFlag1.Tables[0].Rows[0]["Flag"].ToString();
                string strResponded = dsFlag1.Tables[0].Rows[0]["Responded"].ToString();
                string strClosed = dsFlag1.Tables[0].Rows[0]["Closed"].ToString();
                string DoCode = dsFlag1.Tables[0].Rows[0]["DocCode"].ToString();
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");

                if (strFlag1 == "1" && strResponded == "1" && DoCode == lblCFRDocCode.Text)
                {

                    //CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    chkassign.Checked = false;

                    chkassign.Enabled = false;
                    //chkassign.BackColor = Color.LightGray;
                    //row.BackColor = Color.LightGray;

                }

                else if (strFlag1 == "2" && strResponded == "1" && strClosed == "1" && DoCode == lblCFRDocCode.Text)
                {
                    // CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    chkassign.Checked = false;
                    chkassign.Enabled = false;
                    //chkassign.BackColor = Color.LightGray;
                    //row.BackColor = Color.LightGray;


                }
                else
                {
                    row.BackColor = Color.White;
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
    protected void btnCFR_Click(object sender, EventArgs e)
    {
        lblSuccessMsg.Visible = true;//added by rachana 27052013
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetCandidateDtls();
            //FillData1(Request.QueryString["MemCode"].ToString().Trim());
            if (strProcessType == "NC")
            {
                FillData1(Request.QueryString["MemCode"].ToString().Trim());
                if (strCat == "")
                {
                    if (ddlcatapp.SelectedItem.Text == "--Select--")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Category of Appointment')", true);
                        ProgressBarModalPopupExtender.Hide();
                        ddlcatapp.Focus();
                        return;
                    }
                    else
                    {
                        if (ddlcatapp.SelectedItem.Text == "Composite")
                        {
                            if (cbHealth.Checked == false && cbLife.Checked == false)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Life or Health or Both')", true);
                                ProgressBarModalPopupExtender.Hide();
                                cbLife.Focus();
                                cbHealth.Focus();
                                return;

                            }

                            if (cbLife.Checked == true)
                            {
                                if (ddlIns.SelectedItem.Text == "--Select--")
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Name of Insurance for Life')", true);
                                    ProgressBarModalPopupExtender.Hide();
                                    ddlIns.Focus();
                                    return;

                                }
                                else if (ddlIns.SelectedItem.Text == "Others")
                                {
                                    if (txtOther.Text == "")
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Name of Insurance in case of selecting others for Life')", true);
                                        ProgressBarModalPopupExtender.Hide();
                                        txtOther.Focus();
                                        return;
                                    }
                                }

                            }
                            if (cbHealth.Checked == true)
                            {
                                if (ddlInsname.SelectedItem.Text == "--Select--")
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Name of Insurance for Health')", true);
                                    ProgressBarModalPopupExtender.Hide();
                                    ddlIns.Focus();
                                    return;

                                }
                                else if (ddlInsname.SelectedItem.Text == "Others")
                                {
                                    if (txtOtherH.Text == "")
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Name of Insurance in case of selecting others for Health')", true);
                                        ProgressBarModalPopupExtender.Hide();
                                        txtOtherH.Focus();
                                        return;
                                    }
                                }


                            }

                        }

                    }
                }

                Hashtable htParam1 = new Hashtable();
                if (strCat == "")
                {
                    htParam1.Add("@CatApp", ddlcatapp.SelectedItem.ToString());

                    if (ddlcatapp.SelectedItem.Text == "Fresh")
                    {
                        htParam1.Add("@Cat", "Non-Life");
                    }
                    else
                    {
                        if (cbLife.Checked == true && cbHealth.Checked == true)
                        {
                            htParam1.Add("@Cat", "Life / Health");


                            if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text != "Others")
                            {
                                htParam1.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + ddlInsname.SelectedItem.ToString());
                                htParam1.Add("@Other", "Others(Life)");
                            }
                            else if (ddlInsname.SelectedItem.Text == "Others" && ddlIns.SelectedItem.Text != "Others")
                            {
                                htParam1.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + txtOtherH.Text.ToString().Trim());
                                htParam1.Add("@Other", "Others(Health)");
                            }
                            else if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text == "Others")
                            {
                                htParam1.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + txtOtherH.Text.ToString().Trim());
                                htParam1.Add("@Other", "Others(Life/Health)");
                            }
                            else if (ddlIns.SelectedItem.Text != "Others" && ddlInsname.SelectedItem.Text != "Others")
                            {
                                htParam1.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + ddlInsname.SelectedItem.ToString());
                                htParam1.Add("@Other", "");
                            }
                        }
                        else if (cbLife.Checked == true)
                        {
                            htParam1.Add("@Cat", "Life");
                            htParam1.Add("@Other", txtOther.Text.ToString().Trim());
                            htParam1.Add("@NameInsurance", ddlIns.SelectedItem.ToString());
                        }
                        else if (cbHealth.Checked == true)
                        {
                            htParam1.Add("@Cat", "Health");
                            htParam1.Add("@Other", txtOtherH.Text.ToString().Trim());
                            htParam1.Add("@NameInsurance", ddlInsname.SelectedItem.ToString());
                        }
                    }
                }
                htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                htParam1.Add("@Updatedby", Session["UserId"].ToString().Trim());

                htParam1.Add("@RemarkInsurer", txtReInsurer.Text.ToString().Trim());
                ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("[Prc_UpdateQCDtls]", htParam1);


            }
            else
            {
                if (tblCndURN.Visible == true)
                {
                    if (txtCndURNNo.Text != "")
                    {
                        if (txtCndURNNo.Text.Length >= 12 && txtCndURNNo.Text.Length < 20)
                        {
                            Regex reg = new Regex("[a-zA-Z]");
                            bool a;
                            a = reg.IsMatch(txtCndURNNo.Text);
                            if (Convert.ToString(a) == "True")
                            {
                            }
                            else
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. should contain atleast one alphabet .')", true);
                                return;
                            }
                        }
                        else
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. length should be greater than 11 and less than 20.')", true);
                            return;
                        }
                    }
                    if (txtCndURNNo.Text != "")
                    {
                        Hashtable htUrnChk = new Hashtable();
                        DataSet dsUrnChk = new DataSet();
                        htUrnChk.Add("@CndURN", txtCndURNNo.Text);
                        htUrnChk.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                        dsUrnChk = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetChkCndURNNo", htUrnChk);
                        if (dsUrnChk.Tables[0].Rows.Count > 0)
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is not a Unique No.')", true);
                            return;
                        }
                    }
                }
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    if (txtOldTccLcnNo.Text != txtCompLicNo.Text)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License No and Life License No must be same')", true);
                        return;
                    }
                }

                int x;
                DataSet dsloc = new DataSet();
                dsloc.Clear();
                Hashtable httable = new Hashtable();
                httable.Add("@TrnCode", ddlTrnLoc.SelectedItem.Text);
                dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetLocCODEQC", httable);
                if (dsloc.Tables[0].Rows.Count != 0)
                {
                    string trnloccode = dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString();
                }
                #region transfer/composite detail insertion start
                htParam.Clear();
                htParam.Add("@TrfrFlag", cbTrfrFlag.Checked == true ? "1" : "0");
                htParam.Add("@NOCFlag", RbtNoc.SelectedValue == "Y" ? "1" : "0");
                htParam.Add("@OldTccLcnNo", txtOldTccLcnNo.Text.Trim());
                if (txtDate.Text.Trim() != "")
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

                if (txtissudate.Text.Trim() != "")
                {
                    htParam.Add("@LcnIssDate", DateTime.Parse(txtissudate.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@LcnIssDate", System.DBNull.Value);
                }
                //if (txtCndURNNo.Text.Trim() != "")
                //{
                //    htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                //}
                //else
                //{
                //    htParam.Add("@CndURNNo", System.DBNull.Value);
                //}
                htParam.Add("@TccCompLcn", cbTccCompLcn.Checked == true ? "1" : "0");
                htParam.Add("@CompLicNo", txtCompLicNo.Text.Trim());
                if (txtCompLicExpDt.Text.Trim() != "")
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
                htParam.Add("@IsPriorAgt", chkCompAgnt.Checked == true ? "1" : "0");
                if (tblCndURN.Visible == true)
                {
                    if (txtCndURNNo.Text.Trim() != "")
                    {
                        htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@CndURNNo", System.DBNull.Value);
                    }
                    if (TxtTrnsfrReqNo.Text.Trim() != "")
                    {
                        htParam.Add("@TxtTrnsfrReqNo", TxtTrnsfrReqNo.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@TxtTrnsfrReqNo", System.DBNull.Value);
                    }
                }
                #endregion
                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                //For Reexam start
                Hashtable htrexm = new Hashtable();
                htrexm.Clear();
                DataSet dsReExm = new DataSet();
                dsReExm.Clear();
                htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dsReExm = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm);
                //For Reexam end
                Hashtable htable = new Hashtable();
                htable.Clear();
                DataSet dsCndtype = new DataSet();
                dsCndtype.Clear();
                htable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dsCndtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htable);
                if (dsCndtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y" && dsCndtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                //if (dsCndtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                {
                    if (ddlTrnMode.SelectedIndex != 0)
                    {
                        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    }
                    else
                    {
                        htParam.Add("@TrnMode", System.DBNull.Value);
                    }
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                    }
                    else
                    {
                        htParam.Add("@TrnLoc ", System.DBNull.Value);
                    }
                    //if (ddlTrnLoc.SelectedIndex != 0)
                    //{
                    if (ddlTrnLoc.SelectedValue != "" && ddlTrnLoc.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    //if (ddlTrnInstitute.SelectedIndex != 0)
                    //{
                    if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnInstitute", System.DBNull.Value);
                    }
                    if (lblAccrdtnValue.Text != "")
                    {
                        htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                    }
                    else
                    {
                        htParam.Add("@AccrdNo", System.DBNull.Value);
                    }
                    if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                    htParam.Add("@Email", txtEMail.Text.Trim());
                    htParam.Add("@PAN", txtPAN.Text.Trim());
                    htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                    //Added by rachana to save Exam details at the time of SAVE start
                    if (ddlExam.SelectedValue != "" && ddlExam.SelectedValue != "--Select--")
                    {
                        htParam.Add("@ExamMode", ddlExam.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExamMode", System.DBNull.Value);
                    }
                    if (ddlExmBody.SelectedValue != "" && ddlExmBody.SelectedValue != "--Select--")
                    {
                        htParam.Add("@ExmBody", ddlExmBody.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmBody", System.DBNull.Value);
                    }
                    if (ddlpreeamlng.SelectedValue != "" && ddlpreeamlng.SelectedValue != "--Select--")
                    {
                        htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@ExmLang", System.DBNull.Value);
                    }
                    htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                    {
                        htParam.Add("@Givenname", txtGivenName.Text.Trim());
                        htParam.Add("@Fathername", txtFathername.Text.Trim());
                        htParam.Add("@Surname", txtname.Text.Trim());
                        htParam.Add("@AadharQcConfrmFlag", QCConfirmAadhar.SelectedValue);// addd by usha on 21.07.017 for aadhar 
                    }

                    //Added by rachana to save Exam details at the time of SAVE end
                    x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateQCDtls", htParam);
                    //InsertfeesDetails();
                }
                else if (dsCndtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")
                    {
                        if (ddlTrnMode.SelectedIndex != 0)
                        {
                            htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                        }
                        else
                        {
                            htParam.Add("@TrnMode", System.DBNull.Value);
                        }
                        if (dsloc.Tables[0].Rows.Count != 0)
                        {
                            htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                        }
                        else
                        {
                            htParam.Add("@TrnLoc ", System.DBNull.Value);
                        }
                        if (ddlTrnLoc.SelectedValue != "" && ddlTrnLoc.SelectedValue != "--Select--")
                        {
                            htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                        }
                        else
                        {
                            htParam.Add("@TrnLocDesc", System.DBNull.Value);
                        }
                        if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select--")
                        {
                            htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@TrnInstitute", System.DBNull.Value);
                        }
                        if (lblAccrdtnValue.Text != "")
                        {
                            htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                        }
                        else
                        {
                            htParam.Add("@AccrdNo", System.DBNull.Value);
                        }
                        if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "--Select--")
                        {
                            htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@TrnHrs", System.DBNull.Value);
                        }
                        htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                        htParam.Add("@Email", txtEMail.Text.Trim());
                        htParam.Add("@PAN", txtPAN.Text.Trim());
                        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                        //Added by rachana to save Exam details at the time of SAVE start
                        if (ddlExam.SelectedValue != "" && ddlExam.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExamMode", ddlExam.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExamMode", System.DBNull.Value);
                        }
                        if (ddlExmBody.SelectedValue != "" && ddlExmBody.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExmBody", ddlExmBody.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExmBody", System.DBNull.Value);
                        }
                        if (ddlpreeamlng.SelectedValue != "" && ddlpreeamlng.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExmLang", System.DBNull.Value);
                        }
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                        //Added by rachana to save Exam details at the time of SAVE end
                        x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateQCDtls", htParam);
                        //InsertfeesDetails();
                    }
                    else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")
                    {
                        htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                        htParam.Add("@Email", txtEMail.Text.Trim());
                        htParam.Add("@PAN", txtPAN.Text.Trim());
                        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                        //Added by rachana to save Exam details at the time of SAVE start
                        if (ddlExam.SelectedValue != "" && ddlExam.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExamMode", ddlExam.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExamMode", System.DBNull.Value);
                        }
                        if (ddlExmBody.SelectedValue != "" && ddlExmBody.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExmBody", ddlExmBody.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExmBody", System.DBNull.Value);
                        }
                        if (ddlpreeamlng.SelectedValue != "" && ddlpreeamlng.SelectedValue != "--Select--")
                        {
                            htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue);
                        }
                        else
                        {
                            htParam.Add("@ExmLang", System.DBNull.Value);
                        }
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                        //Added by rachana to save Exam details at the time of SAVE end

                        x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdQCDtlsValidReExm", htParam);
                        //InsertfeesDetails();
                    }
                }

                else if (dsCndtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")//added by shreela on 03052014
                {
                    if (ddlTrnMode.SelectedIndex != 0)
                    {
                        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    }
                    else
                    {
                        htParam.Add("@TrnMode", System.DBNull.Value);
                    }
                    if (dsloc.Tables[0].Rows.Count != 0)
                    {
                        htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                    }
                    else
                    {
                        htParam.Add("@TrnLoc ", System.DBNull.Value);
                    }
                    if (ddlTrnLoc.SelectedValue != "" && ddlTrnLoc.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnInstitute", System.DBNull.Value);
                    }
                    if (lblAccrdtnValue.Text != "")
                    {
                        htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                    }
                    else
                    {
                        htParam.Add("@AccrdNo", System.DBNull.Value);
                    }
                    if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "--Select--")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                    htParam.Add("@Email", txtEMail.Text.Trim());
                    htParam.Add("@PAN", txtPAN.Text.Trim());
                    htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                    if (dsCndtype.Tables[0].Rows[0]["CandType"].ToString().Trim() == "F")
                    {
                        if (cbTccCompLcn.Checked == true)
                        {

                            ds_documentName.Clear();
                            htdata.Add("@cndNo", Request.QueryString["MemCode"].ToString().Trim());

                            //shree07
                            if (ViewState["InsRenType"] != "")
                            {
                                if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "---Select---")
                                {
                                    htParam.Add("@InsRenewalType", System.DBNull.Value);
                                    htParam.Add("@OthrTrnComp", System.DBNull.Value);
                                }
                                else
                                {
                                    htParam.Add("@InsRenewalType", ddlRenewType.SelectedItem.Value.ToString().Trim());
                                    if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "L")
                                    {
                                        htParam.Add("@OthrTrnComp", ddllyfTraining.SelectedItem.Value.ToString().Trim());
                                    }
                                    else
                                    {
                                        htParam.Add("@OthrTrnComp", System.DBNull.Value);
                                        //htParam1.Clear();
                                        //dsResult.Clear();
                                        //htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                                        //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam1);
                                        //htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());

                                    }

                                }
                            }
                            else
                            {
                                htParam.Add("@InsRenewalType", System.DBNull.Value);
                                htParam.Add("@OthrTrnComp", System.DBNull.Value);
                            }

                            //htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                            htParam.Add("@flag", "1");
                            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdQCRenwlDtls", htParam);
                        }
                        else
                        {
                            //htParam1.Clear();
                            //dsResult.Clear();
                            //htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam1);
                            htParam.Add("@InsRenewalType", System.DBNull.Value);
                            htParam.Add("@OthrTrnComp", System.DBNull.Value);
                            //htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                            htParam.Add("@flag", "2");
                            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdQCRenwlDtls", htParam);
                        }
                    }
                    else if (Request.QueryString["TrnRequest"].ToString().Trim() == "NOCQc")
                    {
                        htParam1.Clear();
                        dsResult.Clear();
                        htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam1);
                        //htParam.Add("@InsRenewalType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                        //htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());
                        htParam.Add("@InsRenewalType", System.DBNull.Value);
                        htParam.Add("@OthrTrnComp", System.DBNull.Value);
                    }
                    else
                    {
                        htParam1.Clear();
                        dsResult.Clear();
                        htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam1);
                        //htParam.Add("@InsRenewalType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                        //htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());
                        //htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                        //if (hdnInsRenType.Value != "")
                        if (ViewState["InsRenType"] != "")
                        {
                            if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "---Select---")
                            {
                                htParam.Add("@InsRenewalType", System.DBNull.Value);
                                htParam.Add("@OthrTrnComp", System.DBNull.Value);
                            }
                            else
                            {
                                htParam.Add("@InsRenewalType", ddlRenewType.SelectedItem.Value.ToString().Trim());
                                if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "L")
                                {
                                    htParam.Add("@OthrTrnComp", ddllyfTraining.SelectedItem.Value.ToString().Trim());
                                }
                                else
                                {
                                    htParam.Add("@OthrTrnComp", System.DBNull.Value);
                                    //htParam1.Clear();
                                    //dsResult.Clear();
                                    //htParam1.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                                    //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam1);
                                    //htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());

                                }

                            }
                        }
                        else
                        {
                            htParam.Add("@InsRenewalType", System.DBNull.Value);
                            htParam.Add("@OthrTrnComp", System.DBNull.Value);
                        }
                        htParam.Add("@flag", "2");


                        ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdQCRenwlDtls", htParam);

                    }


                }
            }
            if (strProcessType == "NC")
            {
                lblsave.Text = "Candidate Details Saved Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Application No : " + lblFrenchiseeCode.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;
            }
            else
            {

                lblsave.Text = "Candidate Details Saved Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Application No : " + lblFrenchiseeCode.Text + "<br/><br/>Candidate Name: " + txtGivenName.Text;
            }
            mdlpopupSave.Show();
            ProgressBarModalPopupExtender.Hide();
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
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GetCandidateDtls();
            //Added by usha  for CR 17 08.08.2017
            if (strProcessType == "NR")
            {
                if (QCConfirmAadhar.SelectedValue == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select aadhar manual confirmation')", true);
                    //ProgressBarModalPopupExtender.Hide();
                    //QCConfirmAadhar.Focus();
                    //return;
                }

            }

            //if (strProcessType == "NC")
            //{
            //    FillData1(Request.QueryString["MemCode"].ToString().Trim());
            //    if (strCat == "")
            //    {
            //        if (ddlcatapp.SelectedItem.Text == "--Select--")
            //        {
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Category of Appointment')", true);
            //            ProgressBarModalPopupExtender.Hide();
            //            ddlcatapp.Focus();
            //            return;
            //        }
            //        else
            //        {
            //            if (ddlcatapp.SelectedItem.Text == "Composite")
            //            {
            //                if (cbHealth.Checked == false && cbLife.Checked == false)
            //                {
            //                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Life or Health or Both')", true);
            //                    ProgressBarModalPopupExtender.Hide();
            //                    cbLife.Focus();
            //                    cbHealth.Focus();
            //                    return;

            //                }
            //                if (cbLife.Checked == true)
            //                {


            //                    if (ddlIns.SelectedItem.Text == "--Select--")
            //                    {
            //                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Name of Insurance for Life')", true);
            //                        ProgressBarModalPopupExtender.Hide();
            //                        ddlIns.Focus();
            //                        return;

            //                    }
            //                    else if (ddlIns.SelectedItem.Text == "Others")
            //                    {
            //                        if (txtOther.Text == "")
            //                        {
            //                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Name of Insurance in case of selecting others for Life')", true);
            //                            ProgressBarModalPopupExtender.Hide();
            //                            txtOther.Focus();
            //                            return;
            //                        }
            //                    }

            //                }
            //                if (cbHealth.Checked == true)
            //                {
            //                    if (ddlInsname.SelectedItem.Text == "--Select--")
            //                    {
            //                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Name of Insurance for Health')", true);
            //                        ProgressBarModalPopupExtender.Hide();
            //                        ddlIns.Focus();
            //                        return;

            //                    }
            //                    else if (ddlInsname.SelectedItem.Text == "Others")
            //                    {
            //                        if (txtOtherH.Text == "")
            //                        {
            //                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Name of Insurance in case of selecting others for Health')", true);
            //                            ProgressBarModalPopupExtender.Hide();
            //                            txtOtherH.Focus();
            //                            return;
            //                        }
            //                    }


            //                }

            //            }
            //        }
            //    }
            //}
            //if (tblCndURN.Visible == true)
            //{
            //    if (txtCndURNNo.Text != "")
            //    {
            //        if (txtCndURNNo.Text.Length >= 12 && txtCndURNNo.Text.Length < 20)
            //        {
            //            Regex reg = new Regex("[a-zA-Z]");
            //            bool a;
            //            a = reg.IsMatch(txtCndURNNo.Text);
            //            if (Convert.ToString(a) == "True")
            //            {
            //            }
            //            else
            //            {
            //                ProgressBarModalPopupExtender.Hide();
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. should contain atleast one alphabet .')", true);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ProgressBarModalPopupExtender.Hide();
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. length should be greater than 11 and less than 20.')", true);
            //            return;
            //        }
            //    }
            //    if (txtCndURNNo.Text != "")
            //    {
            //        Hashtable htUrnChk = new Hashtable();
            //        DataSet dsUrnChk = new DataSet();
            //        htUrnChk.Add("@CndURN", txtCndURNNo.Text);
            //        htUrnChk.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //        dsUrnChk = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetChkCndURNNo", htUrnChk);
            //        if (dsUrnChk.Tables[0].Rows.Count > 0)
            //        {
            //            ProgressBarModalPopupExtender.Hide();
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is not a Unique No.')", true);
            //            return;
            //        }
            //    }
            //}
            //if (cbTrfrFlag.Checked == true)
            //{
            //    if (txtCndURNNo.Text == "")
            //    {
            //        ProgressBarModalPopupExtender.Hide();
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is Mandatory.')", true);
            //        return;
            //    }
            //    //if (TxtTrnsfrReqNo.Text == "" && ViewState["RenewalFlag"].ToString()!="Y")
            //    //{
            //    //    ProgressBarModalPopupExtender.Hide();
            //    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('IRDA Transfer Request No. is Mandatory.')", true);
            //    //    return;
            //    //}
            //}
            //if (chkCompAgnt.Checked == true)
            //{
            //    if (txtCndURNNo.Text == "")
            //    {
            //        ProgressBarModalPopupExtender.Hide();
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is Mandatory.')", true);
            //        return;
            //    }
            //}

            //Hashtable htRWQCFlag = new Hashtable();
            //DataSet dsRWQCFlag = new DataSet();
            //htRWQCFlag.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //dsRWQCFlag = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htRWQCFlag);
            //if (dsRWQCFlag.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() != "Y")
            //{
             
            //added by pranjali on 27-03-2014 start
            //if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            //{
            //    if (txtOldTccLcnNo.Visible == true && txtCompLicNo.Visible == true)
            //    {
            //        if (txtOldTccLcnNo.Text != txtCompLicNo.Text)
            //        {
            //            ProgressBarModalPopupExtender.Hide();
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License No and Life License No must be same')", true);
            //            return;
            //        }
            //    }
            //}
            //added by pranjali on 27-03-2014 end
            //added by pranjali for validation on approve button to restrict approval bfore closing of all CFR's start
            Hashtable htparam = new Hashtable();
            DataSet dsapprovechk = new DataSet();
            htparam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
            dsapprovechk = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkMemCFRDocCFRRemark", htparam);

            if (dsapprovechk.Tables.Count > 0)
            {
                if (dsapprovechk.Tables[0].Rows.Count > 0)
                {
                    int i;
                    for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                    {
                        string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                        string CFRClosed = dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();

                        if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1"))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CFR still raised for " + CFRFor + " Please Close the CFR first ')", true);
                            return;
                        }
                    }
                }
            }


            ////added by pranjali for validation on approve button to ristrict approval bfore closing of all CFR's end

            //if (hdnflag.Value == "1")
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "NOCQc")
            {
                Hashtable htParam2 = new Hashtable();
                DataSet dsApp = new DataSet();
                if (strCat == "")
                {
                    htParam2.Add("@CatApp", ddlcatapp.SelectedItem.ToString());
                    if (ddlcatapp.SelectedItem.Text == "Fresh")
                    {
                        htParam2.Add("@Cat", "Non-Life");
                    }
                    else
                    {
                        if (cbLife.Checked == true && cbHealth.Checked == true)
                        {
                            htParam2.Add("@Cat", "Life / Health");


                            if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text != "Others")
                            {
                                htParam2.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + ddlInsname.SelectedItem.ToString());
                                htParam2.Add("@Other", "Others(Life)");
                            }
                            else if (ddlInsname.SelectedItem.Text == "Others" && ddlIns.SelectedItem.Text != "Others")
                            {
                                htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + txtOtherH.Text.ToString().Trim());
                                htParam2.Add("@Other", "Others(Health)");
                            }
                            else if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text == "Others")
                            {
                                htParam2.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + txtOtherH.Text.ToString().Trim());
                                htParam2.Add("@Other", "Others(Life/Health)");
                            }
                            else if (ddlIns.SelectedItem.Text != "Others" && ddlInsname.SelectedItem.Text != "Others")
                            {
                                htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + ddlInsname.SelectedItem.ToString());
                                htParam2.Add("@Other", "");
                            }
                        }
                        else if (cbLife.Checked == true)
                        {
                            htParam2.Add("@Cat", "Life");
                            htParam2.Add("@Other", txtOther.Text.ToString().Trim());
                            htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString());
                        }
                        else if (cbHealth.Checked == true)
                        {
                            htParam2.Add("@Cat", "Health");
                            htParam2.Add("@Other", txtOtherH.Text.ToString().Trim());
                            htParam2.Add("@NameInsurance", ddlInsname.SelectedItem.ToString());
                        }
                    }
                }
                htParam2.Add("@cndno", lblCndNoValue.Text.ToString().Trim());
                htParam2.Add("@Flag", "1");
                htParam2.Add("@RemarkInsurer", txtReInsurer.Text.ToString().Trim());
                htParam2.Add("@CreateBy", Session["UserId"].ToString().Trim());
               htParam2.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
                dsApp = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_UpdNocDetails", htParam2);
                lblSub.Text = "Candidate NOC QC Approved Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Application No: " + lblFrenchiseeCode.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                mdlpopupSub.Show();
            }
            else
            {
                int x = 0;
                DataSet dsloc = new DataSet();
                dsloc.Clear();
                Hashtable httable = new Hashtable();
                //httable.Add("@TrnCode", ddlTrnLoc.SelectedItem.Text);
                //dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetLocCODEQC", httable);
                //if (dsloc.Tables[0].Rows.Count != 0)
                //{
                //    string trnloccode = dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString();
                //}
                #region transfer/composite detail insertion start

                //added by pranjali on 24022014 for adding details of transfer from inbox details start
                htParam.Clear();
                htParam.Add("@ModuleID",Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
                //htParam.Add("@TrfrFlag", cbTrfrFlag.Checked == true ? "1" : "0");
                //htParam.Add("@NOCFlag", RbtNoc.SelectedValue == "Y" ? "1" : "0");
                //htParam.Add("@OldTccLcnNo", txtOldTccLcnNo.Text.Trim());
                //if (txtDate.Text.Trim() != "")
                //{
                //    htParam.Add("@OldTccLcnExpDate", DateTime.Parse(txtDate.Text.Trim()).ToString("yyyyMMdd"));
                //}
                //else
                //{
                //    htParam.Add("@OldTccLcnExpDate ", System.DBNull.Value);
                //}
                //if (ddlTrnsfrInsurName.SelectedIndex != 0)
                //{
                //    htParam.Add("@OldTccPrevInsrName", ddlTrnsfrInsurName.SelectedValue.Trim());//added by pranjali on 13-03-2014
                //}
                //else
                //{
                //    htParam.Add("@OldTccPrevInsrName", System.DBNull.Value);
                //}

                //if (txtissudate.Text.Trim() != "")
                //{
                //    htParam.Add("@LcnIssDate", DateTime.Parse(txtissudate.Text.Trim()).ToString("yyyyMMdd"));
                //}
                //else
                //{
                //    htparam.Add("@LcnIssDate", System.DBNull.Value);
                //}

                
                //tParam.Add("@TccCompLcn", cbTccCompLcn.Checked == true ? "1" : "0");
                //added by pranjali on 24022014 for adding details of transfer from inbox details start

                //added by pranjali on 14-03-2014 for inserting composite information start
                //htParam.Add("@CompLicNo", txtCompLicNo.Text.Trim());
                //if (txtCompLicExpDt.Text.Trim() != "")
                //{
                //    htParam.Add("@CompLicExpDt", DateTime.Parse(txtCompLicExpDt.Text.Trim()).ToString("yyyyMMdd"));
                //}
                //else
                //{
                //    htParam.Add("@CompLicExpDt", System.DBNull.Value);
                //}
                //if (ddlCompInsurerName.SelectedIndex != 0)
                //{
                //    htParam.Add("@CompInsrName", ddlCompInsurerName.SelectedValue.Trim());
                //}
                //else
                //{
                //    htParam.Add("@CompInsrName", System.DBNull.Value);
                //}
                //htParam.Add("@IsPriorAgt", chkCompAgnt.Checked == true ? "1" : "0");//added by pranjali on 27-03-2014 
                //if (tblCndURN.Visible == true)
                //{
                //    if (txtCndURNNo.Text.Trim() != "")
                //    {
                //        htParam.Add("@CndURNNo", txtCndURNNo.Text.Trim());
                //    }
                //    else
                //    {
                //        htParam.Add("@CndURNNo", System.DBNull.Value);
                //    }
                //    if (TxtTrnsfrReqNo.Text.Trim() != "")
                //    {
                //        htParam.Add("@TxtTrnsfrReqNo", TxtTrnsfrReqNo.Text.Trim());
                //    }
                //    else
                //    {
                //        htParam.Add("@TxtTrnsfrReqNo", System.DBNull.Value);
                //    }

                //}
                #endregion

                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());

                //added by pranjali on 29-04-2014 start
                //Hashtable htrexm = new Hashtable();
                //htrexm.Clear();
                //DataSet dsReExm = new DataSet();
                //dsReExm.Clear();
                //htrexm.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //dsReExm = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm);
                //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")//Reexam QC //added by pranjali on 28-04-2014
                //{
                    //if (ddlTrnMode.SelectedIndex != 0)
                    //{
                    //    htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    //}
                    //else
                    //{
                    //    htParam.Add("@TrnMode", System.DBNull.Value);
                    //}
                    //Added by pranjali on 07-03-2014 for null value for location code start
                    //if (dsloc.Tables[0].Rows.Count != 0)
                    //{
                    //    htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                    //}
                    //else
                    //{
                    //    htParam.Add("@TrnLoc ", System.DBNull.Value);
                    //}
                    //Added by pranjali on 07-03-2014 for null value for location code end
                    //htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString())); 
                    //if (ddlTrnLoc.SelectedValue != "")
                    //{
                    //    htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    //}
                    //else
                    //{
                    //    htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    //}
                    //htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    //if (ddlTrnInstitute.SelectedValue != "")
                    //{
                    //    htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    //}
                    //else
                    //{
                    //    htParam.Add("@TrnInstitute", System.DBNull.Value);
                    //}
                    //htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                    //if (lblAccrdtnValue.Text != "")
                    //{
                    //    htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                    //}
                    //else
                    //{
                    //    htParam.Add("@AccrdNo", System.DBNull.Value);
                    //}
                    //added by rachana on 01/04/2014 to save Trntype start
                    //if (ddlHrsTrn.SelectedValue != "")
                    //{
                    //    htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    //}
                    //else
                    //{
                    //    htParam.Add("@TrnHrs", System.DBNull.Value);
                    //}
                    ////Update WaiverFlag in LicRenTCCSu chkWebTknRecd
                    //if (chkWebTknRecd.Checked == true)
                    //{
                    //    htParam.Add("@Waiverflag", "1");
                    //}
                    //else
                    //{
                    //    htParam.Add("@Waiverflag", "0");
                    //}
                    //added by pranjali on 11-04-2014 for exam details insertion start     
                    //}
               // }
                //else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC //added by pranjali on 28-04-2014)
                //{
                //    //added for Appling validation
                //    if (ddlTrnMode.SelectedValue == "" || ddlTrnMode.SelectedValue == "--Select--")
                //    {
                //        ProgressBarModalPopupExtender.Hide();
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Mode')", true);
                //        return;
                //    }
                //    if (ddlTrnLoc.SelectedValue == "" || ddlTrnLoc.SelectedValue == "--Select--")
                //    {
                //        ProgressBarModalPopupExtender.Hide();
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Training Location')", true);
                //        return;
                //    }
                //    if (ddlTrnInstitute.SelectedValue == "" || ddlTrnInstitute.SelectedValue == "--Select--")
                //    {
                //        ProgressBarModalPopupExtender.Hide();
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Institute')", true);
                //        return;
                //    }
                //    if (ddlHrsTrn.SelectedValue == "" || ddlHrsTrn.SelectedValue == "--Select--")
                //    {
                //        ProgressBarModalPopupExtender.Hide();
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Hrs')", true);
                //        return;
                //    }
                //    if (ddlTrnMode.SelectedIndex != 0)
                //    {
                //        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                //    }
                //    else
                //    {
                //        htParam.Add("@TrnMode", System.DBNull.Value);
                //    }
                //    //htParam.Add("@TrnMode", ddlTrnMode.SelectedValue);
                //    //Added by pranjali on 07-03-2014 for null value for location code start
                //    if (dsloc.Tables[0].Rows.Count != 0)
                //    {
                //        htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString()));
                //    }
                //    else
                //    {
                //        htParam.Add("@TrnLoc ", System.DBNull.Value);
                //    }
                //    //Added by pranjali on 07-03-2014 for null value for location code end
                //    //htParam.Add("@TrnLoc", (dsloc.Tables[0].Rows[0]["TrnLocCode"].ToString())); 
                //    if (ddlTrnLoc.SelectedValue != "")
                //    {
                //        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                //    }
                //    else
                //    {
                //        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                //    }
                //    //htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                //    if (ddlTrnInstitute.SelectedValue != "")
                //    {
                //        htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                //    }
                //    else
                //    {
                //        htParam.Add("@TrnInstitute", System.DBNull.Value);
                //    }
                //    //htParam.Add("@TrnInstitute", ddlTrnInstitute.SelectedValue);
                //    if (lblAccrdtnValue.Text != "")
                //    {
                //        htParam.Add("@AccrdNo", lblAccrdtnValue.Text);
                //    }
                //    else
                //    {
                //        htParam.Add("@AccrdNo", System.DBNull.Value);
                //    }
                //    //added by rachana on 01/04/2014 to save Trntype start
                //    if (ddlHrsTrn.SelectedValue != "")
                //    {
                //        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                //    }
                //    else
                //    {
                //        htParam.Add("@TrnHrs", System.DBNull.Value);
                //    }
                //    //Update WaiverFlag in LicRenTCCSu chkWebTknRecd
                //    if (chkWebTknRecd.Checked == true)
                //    {
                //        htParam.Add("@Waiverflag", "1");
                //    }
                //    else
                //    {
                //        htParam.Add("@Waiverflag", "0");
                //    }
                //}
                //else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")//Reexam QC //added by pranjali on 28-04-2014)
                //{
                //    if (chkWebTknRecd.Checked == true)
                //    {
                //        htParam.Add("@Waiverflag", "1");
                //    }
                //    else
                //    {
                //        htParam.Add("@Waiverflag", "0");
                //    }
                //    //added by pranjali on 11-04-2014 for exam details inse
                //}
                //added by shreela on 29/04/2014 start
                //Hashtable htrenwl = new Hashtable();
                //htrenwl.Clear();
                //dsResult.Clear();
                //htrenwl.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htrenwl);
                //if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                //{
                //    htParam.Add("@ExamMode", ddlExam.SelectedValue.ToString().Trim());
                //    htParam.Add("@ExmBody", ddlExmBody.SelectedValue.ToString().Trim());
                //    htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue.ToString().Trim());
                //    //htParam.Add("@ExmCentre", ddlExmCentre.SelectedValue.ToString().Trim());
                //    //htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                //    htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                //}
                htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                //added by shreela on 29/04/2014 end

                //added by pranjali on 11-04-2014 for exam details insertion end

                //#region RE-Exam QC
                ////added by pranjali on 29-04-2014 start
                //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                //{
                //    //Added by rachana
                //    if (ViewState["strICMEnable"].ToString() != "NO")//no ICM
                //    {
                //        //if (chkWebTknRecd.Checked == false)
                //        //if (dgPaymentdtls.Rows.Count == 0)
                //        //{
                //        //    ProgressBarModalPopupExtender.Hide();
                //        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Fees Details.')", true);
                //        //    return;
                //        //}
                //        //else
                //        //{
                //        //    if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count==0)
                //        //    {
                //        //       ProgressBarModalPopupExtender.Hide();
                //        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Proceed with Get Fees.')", true);
                //        //        return;
                //        //    }
                //        //}
                //        if (ChkFeesWavier.Checked != true)
                //        {
                //            if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count == 0)
                //            {
                //                ProgressBarModalPopupExtender.Hide();
                //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate fees details are not saved.')", true);
                //                return;
                //            }
                //        }

                //    }

                //    Hashtable htrexm1 = new Hashtable();
                //    htrexm1.Clear();
                //    DataSet dsReExm1 = new DataSet();
                //    dsReExm1.Clear();
                //    htrexm1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //    dsReExm1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndReExmDtls", htrexm1);
                //    //added for getting reexam type to get no of days based on valid/invalid flag by rachana
                //    ViewState["ReExmType"] = dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
                //    if (dsReExm1.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")//Reexam QC
                //    {
                //        GetNoofDaysForReexm();
                //        //SetSysFreezeDate();
                //        InsertfeesDetails();

                //        htParam.Add("@Email", txtEMail.Text.Trim());
                //        htParam.Add("@PAN", txtPAN.Text.Trim());
                //        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                //        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                //        {
                //            htParam.Add("@Givenname", txtGivenName.Text.Trim());
                //            htParam.Add("@Fathername", txtFathername.Text.Trim());
                //            htParam.Add("@Surname", txtname.Text.Trim());
                //        }

                //        x = dataAccessRecruit.execute_sprcMemrecruit("Prc_ApprLictrnccsuForReExm", htParam);//added by pranjali on 29-04-2014 end
                //        //MailResponse();

                //    }
                //    else if (dsReExm1.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC)
                //    {
                //        GetNoofDaysForReexm();
                //       // SetSysFreezeDate();
                //        InsertfeesDetails();
                //        htParam.Add("@Email", txtEMail.Text.Trim());
                //        htParam.Add("@PAN", txtPAN.Text.Trim());
                //        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                //        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                //        {
                //            htParam.Add("@Givenname", txtGivenName.Text.Trim());
                //            htParam.Add("@Fathername", txtFathername.Text.Trim());
                //            htParam.Add("@Surname", txtname.Text.Trim());
                //            htparam.Add("@AadharQcConfrmFlag", QCConfirmAadhar.SelectedValue);// addd by usha on 21.07.017 for aadhar 
                //        }

                //        x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateAppr_Lictrnccsu", htParam);
                //        //MailResponse();

                //    }
                //}
                //#endregion
                ////added by pranjali on 29-04-2014 end
                ////added by shreela on 29/04/2014 start
                //#region Renewl Qc
                //htrenwl.Clear();
                //dsResult.Clear();
                //htrenwl.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htrenwl);
                //if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                //{
                //    htrenwl.Add("@Updatedby", Session["UserId"].ToString().Trim());
                //    x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdRtrvlLcnNo", htrenwl);
                //    #region to be commented for retreival




                //    #endregion


                //}
                //#endregion
                //added by shreela on 29/04/2014 end
                #region Normal QC
                if (ChkFeesWavier.Checked != true)
                {

                    //if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                    //{
                        //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                        //{
                            //if (chkWebTknRecd.Checked == false && dgPaymentdtls.Rows.Count==0)
                            //if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count == 0
                            //        && strMemType != "T")//Added By Nikhil
                            //{
                            //    //ProgressBarModalPopupExtender.Hide();
                            //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate fees details are not saved')", true);
                            //    //return;

                            //}
                            htParam.Add("@Email", txtEMail.Text.Trim());
                            htParam.Add("@PAN", txtPAN.Text.Trim());
                            htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                            {
                                htParam.Add("@Givenname", txtGivenName.Text.Trim());
                                htParam.Add("@Fathername", txtFathername.Text.Trim());
                                htParam.Add("@Surname", txtname.Text.Trim());
                            }
                            x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateMemAppr_Lictrnccsu", htParam);
                           // InsertfeesDetails();//fees details saved only at the time of QC
                            //MailResponse();
                            //MAIL


                      //  }
                   // }
                }
                else
                {
                    //if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                    //{
                    //    //if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                    //    //{
                    //        //if (chkWebTknRecd.Checked == false && dgPaymentdtls.Rows.Count==0)
                    //        //if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count == 0)
                    //        //{
                    //        //    ProgressBarModalPopupExtender.Hide();
                    //        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate fees details are not saved')", true);
                    //        //    return;

                    //        //}
                    //        htParam.Add("@Email", txtEMail.Text.Trim());
                    //        htParam.Add("@PAN", txtPAN.Text.Trim());
                    //        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                    //        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                    //        {
                    //            htParam.Add("@Givenname", txtGivenName.Text.Trim());
                    //            htParam.Add("@Fathername", txtFathername.Text.Trim());
                    //            htParam.Add("@Surname", txtname.Text.Trim());
                    //            htParam.Add("@AadharQcConfrmFlag", QCConfirmAadhar.SelectedValue);// addd by usha on 21.07.017 for aadhar 
                    //        }
                    //        x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdateAppr_Lictrnccsu", htParam);
                    //        InsertfeesDetails();//fees details saved only at the time of QC
                    //        //MailResponse();
                    //        //MAIL


                    //   // }
                    //}
                }
                #endregion
                //if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                //{
                //    Hashtable htQc = new Hashtable();
                //    DataSet dsQc = new DataSet();
                //    htQc.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //    dsQc = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDataQcDtls", htQc);
                //    lblSub.Text = "Candidate QC Approved Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Agent Broker Code: " + dsQc.Tables[0].Rows[0]["Agent_Broker_Code"].ToString().Trim() + "<br/>License No.: " + dsQc.Tables[0].Rows[0]["LcnNo"].ToString().Trim() + "<br/>License Issue Date: " + dsQc.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();//added by shreela on 25042014
                //    mdlpopupSub.Show();
                //}
                //else
                //{
                    lblSub.Text = "QC Approved Successfully"  + "<br/>Code : " + lblFrenchiseeCode.Text + "<br/>Name: " + txtGivenName.Text;//added by shreela on 25042014
                   // mdlpopupSub.Show();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                // }
                //Popup added by rachana to show msgbox end
                BtnApprove.Enabled = false;
                BtnCFR.Enabled = false;
                //Added for opening Agent Details for Transfer case candidate after approval start
                //dsloc.Clear();
                //httable.Clear();
                //httable.Add("@MemCode", lblCndNoValue.Text.Trim());
                //dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetMemberType", httable);
                //if (dsloc.Tables.Count > 0)
                //{
                //    if (dsloc.Tables[0].Rows.Count > 0)
                //    {
                //        string strtrn = dsloc.Tables[0].Rows[0]["CandType"].ToString().Trim();
                //        string IsPriorAgt = dsloc.Tables[0].Rows[0]["IsPriorAgt"].ToString();
                //        if (strtrn == "T")
                //        {
                //            if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")//added by shreela on 26/05/2014
                //            {
                //                //Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTInfo.aspx?cnd=CndCon&Type=N&CndNum=" + lblCndNoValue.Text, false);
                //                Hashtable htTrnsfrLic = new Hashtable();
                //                htTrnsfrLic.Add("@MemCode", lblCndNoValue.Text.Trim());
                //                int z = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdTrnsfrLicDtls", htTrnsfrLic);
                //            }
                //        }
                //        //added by pranjali on 27-03-2014 start
                //        if (IsPriorAgt == "1" || dsloc.Tables[0].Rows[0]["IsPriorAgt"].ToString() == "True")
                //        {
                //            if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")//added by shreela on 26/05/2014
                //            {
                //                //Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTInfo.aspx?cnd=CndCon&Type=N&CndNum=" + lblCndNoValue.Text, false);
                //                Hashtable htTrnsfrLic = new Hashtable();
                //                htTrnsfrLic.Add("@MemCode", lblCndNoValue.Text.Trim());
                //                int z = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdTrnsfrLicDtls", htTrnsfrLic);
                //            }
                //            else if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                //            {
                //                htdata.Clear();
                //                ds_documentName.Clear();
                //                htdata.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                //                htdata.Add("@licExpDate", DateTime.Parse(txtnewexpdate.Text.Trim()).ToString("yyyyMMdd"));
                //                if (txtnewlicissu.Text.Trim() != "")
                //                {
                //                    htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                //                }
                //                else
                //                {
                //                    htdata.Add("@licissudate", System.DBNull.Value);
                //                }
                //                htdata.Add("@Email", txtEMail.Text.Trim());
                //                htdata.Add("@PAN", txtPAN.Text.Trim());
                //                htdata.Add("@Mobile", txtMobileNo.Text.Trim());
                //                htdata.Add("@Updatedby", Session["UserID"].ToString().Trim());
                //                x = dataAccessRecruit.execute_sprcMemrecruit("Prc_updcndlicdtls", htdata);
                //            }
                //        }
                //        //added by pranjali on 27-03-2014 end
                //        //added by pranjali on 11-04-2014 start
                //        if (strtrn == "C")
                //        {
                //            if (IsPriorAgt == "1")
                //            {
                //                //added by shreela on 25042014
                //                if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString() != "Y")
                //                {
                //                    if (dsloc.Tables[0].Rows[0]["ReExamFlag"].ToString() != "Y")
                //                    {
                //                        int y;
                //                        y = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdForCompCand", httable); //Added by pranjali on 02-01-2014 to update details
                //                    }
                //                }
                //            }
                //        }
                //        //added by pranjali on 11-04-2014 end


                //    }
                //}

                ProgressBarModalPopupExtender.Hide();





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

    protected void Click_Arf(object sender, EventArgs e)
    {
        Image_Photo.ImageUrl = "~//UploadedFiles//90114156_ARFPANEDUProof-page-001.jpg";
        lblAdvisor.Text = "Advisor Arf";
        mdlpopup_photo.Show();
    }

    protected void Click_Educationproof(object sender, EventArgs e)
    {
        Image_Photo.ImageUrl = "~//UploadedFiles//90114156_ARFPANEDUProof-page-003.jpg";
        lblAdvisor.Text = "Advisor Education Proof";
        mdlpopup_photo.Show();
    }

    //added by rachana for performance QC module start
    

    #region Crop and open image in new page
    protected void Btncrop_Click(object sender, EventArgs e)
    {
        // added by usha on 25.08.016  for image cropping 
        //string strpath;
        //string strimage = string.Empty;
        //string[] strpathcount;
        //string strimageno;
        //string[] strcount;
        //string strimagenonew;
        //dsResult.Clear();
        //htParam.Clear();
        //htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
        //htParam.Add("@DocType", lblpanelheader.Text.Trim());
        //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforQC", htParam);

        //if (dsResult.Tables.Count > 0)
        //{
        //    if (dsResult.Tables[0].Rows.Count > 0)
        //    {
        //        strpath = hdnpath.Value;

        //        for (int i = 0; i <= dsResult.Tables[0].Rows.Count; i++)
        //        {
        //            if (dsResult.Tables.Count > 0)
        //            {

        //                strimage = dsResult.Tables[0].Rows[0]["ID"].ToString();
        //            }
        //Response.Redirect("CropImage1.aspx?CndNo= " + lblCndNoValue.Text + "&mdlpopup=" + MdlPopRaiseSub.ID);

        Response.Redirect("FPCropImage.aspx?CndNo= " + lblCndNoValue.Text + "");

        //        }
        //    }
        //}
    }
    //opens crop image based on imageno end
    #endregion
    //added by rachana for performance QC module end
    protected void cbRejectFlag_CheckedChanged(object sender, EventArgs e)
    {

        // cbTccCompLcn.Enabled = false;
        if (cbRejectFlag.Checked == true)
        {
            lblReject.Visible = true;
            txtReject.Visible = true;
            divRejectDetails.Visible = true;
        }
        else
        {
            lblReject.Visible = false;
            txtReject.Visible = false;
            //divRejectDetails.Attributes.Add("style","display:none");
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "NOCQc")
            {
                if (cbRejectFlag.Checked == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Reason for Reject')", true);
                    ProgressBarModalPopupExtender.Hide();
                    cbRejectFlag.Focus();
                    return;
                }
                else
                {
                    if (txtReject.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Reason for Reject')", true);
                        ProgressBarModalPopupExtender.Hide();
                        txtReject.Focus();
                        return;
                    }
                    else
                    {
                        Hashtable htParam2 = new Hashtable();
                        DataSet dsApp = new DataSet();
                        htParam2.Add("@CatApp", ddlcatapp.SelectedItem.ToString());
                        if (ddlcatapp.SelectedItem.Text == "Fresh")
                        {
                            htParam2.Add("@Cat", "Non-Life");
                        }
                        else
                        {
                            if (cbLife.Checked == true && cbHealth.Checked == true)
                            {
                                htParam2.Add("@Cat", "Life / Health");


                                if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text != "Others")
                                {
                                    htParam2.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + ddlInsname.SelectedItem.ToString());
                                    htParam2.Add("@Other", "Others(Life)");
                                }
                                else if (ddlInsname.SelectedItem.Text == "Others" && ddlIns.SelectedItem.Text != "Others")
                                {
                                    htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + txtOtherH.Text.ToString().Trim());
                                    htParam2.Add("@Other", "Others(Health)");
                                }
                                else if (ddlIns.SelectedItem.Text == "Others" && ddlInsname.SelectedItem.Text == "Others")
                                {
                                    htParam2.Add("@NameInsurance", txtOther.Text.ToString().Trim() + " / " + txtOtherH.Text.ToString().Trim());
                                    htParam2.Add("@Other", "Others(Life/Health)");
                                }
                                else if (ddlIns.SelectedItem.Text != "Others" && ddlInsname.SelectedItem.Text != "Others")
                                {
                                    htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString() + " / " + ddlInsname.SelectedItem.ToString());
                                    htParam2.Add("@Other", "");
                                }
                            }
                            else if (cbLife.Checked == true)
                            {
                                htParam2.Add("@Cat", "Life");
                                htParam2.Add("@Other", txtOther.Text.ToString().Trim());
                                htParam2.Add("@NameInsurance", ddlIns.SelectedItem.ToString());
                            }
                            else if (cbHealth.Checked == true)
                            {
                                htParam2.Add("@Cat", "Health");
                                htParam2.Add("@Other", txtOtherH.Text.ToString().Trim());
                                htParam2.Add("@NameInsurance", ddlInsname.SelectedItem.ToString());
                            }
                        }
                        htParam2.Add("@cndno", lblCndNoValue.Text.ToString().Trim());
                        htParam2.Add("@Flag", "2");
                        htParam2.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
                        dsApp = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_UpdNocDetails", htParam2);
                        lblSub.Text = "Candidate NOC QC Rejected Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Application No: " + lblFrenchiseeCode.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                        mdlpopupSub.Show();
                    }
                }

            }
            else
            {
                int x = 0;
                htParam.Clear();
                htParam.Add("@MemCode", lblCndNoValue.Text.ToString().Trim());
                htParam.Add("@UpdatedBy", Session["UserID"].ToString().Trim());
                htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
                x = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdCndStatonRejApp", htParam);

                //MAIL Communication integration
                //getCandidateDetails();
                string strUserID = Session["UserID"].ToString();
                Hashtable htData = new Hashtable();
                DataSet ds = new DataSet();
                ds.Clear();
                htData.Add("@Param1", "QC");
                htData.Add("@Param2", "F");//"F");
                htData.Add("@Param3", "180");//ViewState["CandStatus"].ToString());//
                htData.Add("@Param4", "F");
                ds = dataAccessRecruit.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                            //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", "F", "180", "NR", "", NotifyTo, lblCndNoValue.Text, Session["UserID"].ToString().Trim());
                        }
                    }
                }

                lblSub.Text = "CFR Rejected Successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;
                mdlpopupSub.Show();
                //end
                BtnApprove.Enabled = false;
                BtnCFR.Enabled = false;
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

    protected void CVDocUpload_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }


    //Added by rachana on 20122013 for ARF form and Edu Marksheets start
    protected void CVArf1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    protected void CVArf2_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    protected void CVEduProof1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    protected void CVEduProof2_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    //Added by rachana on 20122013 for ARF form and Edu Marksheets end

    //Added by Pranjali on 30-12-2013 start
    protected void Filluploadedfile() //string lbldocname
    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                FilluploadedfileChkboxChnge();
            }
            else
            {
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1); //added by pranjali on 14-03-2014 start
                htParam.Clear();
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                //added by pranjali on 11-04-2014 start
                if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                {
                    htParam.Add("@InsurerType", "");
                    if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htParam.Add("@ProcessType", "NR");
                    }
                    //htParam.Add("@ProcessType", "NR");
                }
                else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                {
                    //htParam.Add("@RenwlFlag", "N");
                    htParam.Add("@InsurerType", "");
                    //htParam.Add("@ReExmFlag", "Y");
                    htParam.Add("@ProcessType", "RE");
                }
                else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
                {
                    //htParam.Add("@RenwlFlag", "Y");
                    htParam.Add("@InsurerType", "");
                    //htParam.Add("@ReExmFlag", "N");
                    htParam.Add("@ProcessType", "RW");
                }
                //htParam.Add("@RenwlFlag", "N");
                //htParam.Add("@InsurerType", "");

                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);
                //added by pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsResult.Tables[0];
                        GridView1.DataBind();
                        tr_DocumentReuploadTitle.Visible = true;
                        tr_reupload.Visible = true;
                        Bindgridview();
                    }
                    else
                    {
                        Bindgridview();
                    }
                }
            }

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


            if (Directory.Exists(strPath) == false)
            {
                strPath = strPath + txtMemberCode.Text.Trim();
                Directory.CreateDirectory(strPath);
            }
            else
            {
                strFilePath = strPath + txtMemberCode.Text.Trim();
                //if (!Directory.Exists(Server.MapPath(strFilePath)))
                if (!Directory.Exists(strFilePath))
                {
                    // Directory.CreateDirectory(Server.MapPath(strFilePath));
                    Directory.CreateDirectory(strFilePath);
                }
                else
                {
                    strFilePath = strPath + txtMemberCode.Text.Trim();
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
                strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PNG" || strPhotoExt == "png")
            {
                strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
            {
                strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PDF")
            {
                strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
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
            //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)) //Commented for overwritting of image instead of creating new image with same name
            using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] byteData = fuData.FileBytes;
                //byte[] byteData = data;
                fileStream.Write(byteData, 0, byteData.Length);
            }


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
            strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];


            htdata.Clear();
            htdata.Add("@Memcode", txtMemberCode.Text.Trim());
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocname.Text.Trim());
            htdata.Add("@UserID", hdnUserId.Value);
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "0"); //Added by pranjali on 27-12-2013
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode.Text.Trim());
            htdata.Add("@FileType", strPhotoExt);
            try
            {

                GetCandidateDtls();
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

                    else if (Request.QueryString["Type"].ToString().Trim() == "R") //shreela 26-03-2014
                    {
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                    }

                    else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                    {
                        //intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
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
                        //intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertDCTMFileUpload", htdata);
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
            lnkPreview.Visible = true;
            txtExmCentre.Text = hdnExmCentreCode.Value;
            //Filluploadedfile();//Docname
            //added by ajay 06-05-2022 start
            if (lbldoccode.Text.Trim() == "3")
            {
                chkgst.Enabled = false;
                chkagree.Enabled = false;
                btngst.Enabled = false;
                btnView.Enabled = false;
                ViewState["Gst"] = lbldoccode.Text.Trim();
            }
            if (lbldoccode.Text.Trim() == "11")
            {
                if (ViewState["Gst"].ToString() == "3")
                {
                    chkgst.Enabled = false;
                    chkagree.Enabled = true;
                    btngst.Enabled = false;
                    btnView.Enabled = true;
                }
                else
                {
                    chkgst.Enabled = true;//added by sanoj 22062022
                    chkagree.Enabled = true; //added by sanoj 22062022
                    btngst.Enabled = true;
                    btnView.Enabled = true;
                }
            }
            //added by ajay 06-05-2022 end
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
        if (Directory.Exists(strPath) == false)
        {
            strPath = strPath + lblCndNoValue.Text.Trim();
            Directory.CreateDirectory(strPath);
        }
        else
        {
            strFileRePath = strPath + lblCndNoValue.Text.Trim();
            //if (!Directory.Exists(Server.MapPath(strFilePath)))
            if (!Directory.Exists(strFileRePath))
            {
                // Directory.CreateDirectory(Server.MapPath(strFilePath));
                Directory.CreateDirectory(strFileRePath);
            }
            else
            {
                strFileRePath = strPath + lblCndNoValue.Text.Trim();
            }
        }
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
            strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PNG" || strPhotoExt == "png")
        {

            strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        {
            strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PDF")
        {
            strFileName1 = txtMemberCode.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
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
                    htdata.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                    htdata.Add("@doctype", lbldocName.Text.Trim());
                    dsResult.Clear();
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
        strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];
        //strFileName = actualpath[4] + "\\" + actualpath[5] + "\\" + actualpath[6];
        htdata.Clear();
        htdata.Add("@Memcode", txtMemberCode.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName1);
        htdata.Add("@DocType", lbldocName.Text.Trim());
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');
        htdata.Add("@DocStatus", "1"); //Added by pranjali on 27-12-2013
        htdata.Add("@Imagebin", data);
        htdata.Add("@DocCode", lbldoccode1.Text.Trim());
        htdata.Add("@FileType", strPhotoExt);
        try
        {
            GetCandidateDtls();
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
        //FillReuploadedfile(Docname);//Docname
        //Filluploadedfile();
        //added by ajay 06-05-2022 start
       // if (lbldocName.Text.Trim() == "GST Certificate")
        if (lbldoccode1.Text.Trim() == "3")
        {
            chkgst.Enabled = false;
            chkagree.Enabled = false;
            btngst.Enabled = false;
            btnView.Enabled = false;
            //ViewState["Gst"] = lbldocName.Text.Trim();
            ViewState["Gst"] = lbldoccode1.Text.Trim();
        }
      //  if (lbldocName.Text.Trim() == "Signature")
        if (lbldoccode1.Text.Trim() == "11")
        {
            //if (ViewState["Gst"].ToString() == "GST Certificate")
            if (ViewState["Gst"].ToString() == "3")
            {
                chkgst.Enabled = false;
                chkagree.Enabled = false;
                btngst.Enabled = false;
                btnView.Enabled = true;
            }
            else
            {
                //chkgst.Enabled = true;
                //chkagree.Enabled = true;
                btngst.Enabled = true;
                btnView.Enabled = true;
            }
        }
         btnRespond.Visible = true;//added by sanoj 16052023
        //added by ajay 06-05-2022 end
    }
    protected void FillReuploadedfile(string Docname) //string lbldocname
    {
        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                htParam.Clear();
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    htParam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                {
                    htParam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                {
                    htParam.Add("@CandType", 'C');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                {
                    htParam.Add("@CandType", 'F');
                }
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htParam.Add("@doctype", Docname.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetReUploadedDetails", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsResult.Tables[0];
                        GridView1.DataBind();
                        tr_DocumentReuploadTitle.Visible = true;
                        tr_reupload.Visible = true;
                        BindgridChkboxChnge();
                    }
                }
            }
            else
            {
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1);
                htParam.Clear();
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htParam.Add("@doctype", Docname.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetReUploadedDetails", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsResult.Tables[0];
                        GridView1.DataBind();
                        tr_DocumentReuploadTitle.Visible = true;
                        tr_reupload.Visible = true;
                        Bindgridview();
                    }
                }
            }
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
    //Added by Pranjali on 30-12-2013 end
    private void BindGrid()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();
            Hashtable httable = new Hashtable();
            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            httable.Add("@DocType", ViewState["docType"]);
            ds_image = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", httable);
            GridImage.DataSource = ds_image;
            GridImage.DataBind();
            ViewState["Img"] = ds_image;
            ViewState["Img1"] = ds_image;
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
            //con.Close();
        }

    }

    #region dgView PageIndexChanging
    protected void dgView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForUplds();
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
            //ShowPageInformation();
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
    protected DataTable GetDataTableForUplds()
    {
        DataSet dsUpdDocPgIndxng = new DataSet();
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            Hashtable htparam = new Hashtable();
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());

                Hashtable htDtls = new Hashtable();
                DataSet dsDtls = new DataSet();
                htDtls.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dsDtls = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCandidateDetails", htDtls);
                ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
                ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
                ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
                ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
                strProcessType = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
                
                htparam.Add("@CandType", dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString());

                //Commented BY daksh on 28-08-2020 for viewCFR error on Page indexer changing
                //if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                //{
                //    htparam.Add("@CandType", 'T');
                //}
                //else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                //{
                //    htparam.Add("@CandType", 'T');
                //}
                //else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                //{
                //    htparam.Add("@CandType", 'C');
                //}
                //else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                //{
                //    htparam.Add("@CandType", 'F');
                //}
                //added by pranjali on 11-04-2014 start
                //htparam.Add("@RenwlFlag", "N");//shree07

                //Commented BY daksh on 28-08-2020 for viewCFR error on Page indexer changing
                htparam.Add("@InsurerType", "");
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
                if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "RE");
                }
                else if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    htparam.Add("@ProcessType", "RW");
                }
                else
                {
                    htparam.Add("@ProcessType", "NR");
                }
                //added by pranjali on 11-04-2014 end
            }
            else
            {
                htparam.Clear();
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1); //added by pranjali on 14-03-2014 start
                htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                //adde by shree07
                if (ViewState["ProcessType"].ToString() != "NC")
                {
                    if (ds_candtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "RW");
                    }
                    else if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "RE");
                    }
                    else
                    {
                        if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                        {
                            htparam.Add("@ProcessType", "SP");
                        }
                        else
                        {
                            htparam.Add("@ProcessType", "NR");
                        }
                    }
                }
                else
                {
                    htparam.Add("@ProcessType", "NC");
                }
                htparam.Add("@InsurerType", "");
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            }
            if (ViewState["ProcessType"].ToString() != "NC")
            {
                dsUpdDocPgIndxng = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemUpldDocNames", htparam); //added by pranjali on 11-04-2014 
            }
            else
            {
                dsUpdDocPgIndxng = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNOCDocNames", htparam);
            }

            if (dsUpdDocPgIndxng.Tables.Count > 0)
            {
                if (dsUpdDocPgIndxng.Tables[0].Rows.Count > 0)
                {
                    dgView.DataSource = dsUpdDocPgIndxng.Tables[0];
                    dgView.DataBind();
                }
                else
                {
                    dgView.DataSource = null;
                    dgView.DataBind();
                    tblupload.Visible = false;

                }
            }
            else
            {
                dgView.DataSource = null;
                dgView.DataBind();
                tblupload.Visible = false;

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
        return dsUpdDocPgIndxng.Tables[0];
    }

    #region GridView1 PageIndexChanging
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForReUplds();
            DataView dv = new DataView(dt);
            GridView dgSource1 = (GridView)sender;
            dgSource1.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource1.Attributes["SortExpression"];
            if (dgSource1.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }
            dgSource1.DataSource = dv;
            dgSource1.DataBind();
            //ShowPageInformation();
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

    protected DataTable GetDataTableForReUplds()
    {
        try
        {

            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                htParam.Clear();
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    htParam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                {
                    htParam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                {
                    htParam.Add("@CandType", 'C');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                {
                    htParam.Add("@CandType", 'F');
                }
                //ADDED BY Pranjali on 11-04-2014 start

                htParam.Add("@InsurerType", "");
                htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                //htParam.Add("@ReExmFlag", "N");
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
                if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    htParam.Add("@ProcessType", "RE");
                }
                else if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    htParam.Add("@ProcessType", "RW");
                }
                else
                {
                    if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htParam.Add("@ProcessType", "NR");
                    }
                }
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);
                //ADDED BY Pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsResult.Tables[0];
                        GridView1.DataBind();
                        tr_DocumentReuploadTitle.Visible = true;
                        tr_reupload.Visible = true;
                        BindgridChkboxChnge();
                    }
                    else
                    {
                        BindgridChkboxChnge();
                    }
                }
            }
            else
            {
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1); //added by pranjali on 14-03-2014 start
                htParam.Clear();
                htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                //ADDED BY Pranjali on 11-04-2014 start
                //htParam.Add("@RenwlFlag", "N");
                htParam.Add("@InsurerType", "");
                htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                //adde by shree07
                if (ViewState["ProcessType"].ToString() != "NC")
                {
                    if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "RE");
                    }
                    else if (ds_candtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "RW");
                    }
                    else
                    {
                        if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                        {
                            htParam.Add("@ProcessType", "SP");
                        }
                        else
                        {
                            htParam.Add("@ProcessType", "NR");
                        }
                    }
                }
                else
                {
                    htParam.Add("@ProcessType", "NC");
                }
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);
                //ADDED BY Pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsResult.Tables[0];
                        GridView1.DataBind();
                        tr_DocumentReuploadTitle.Visible = true;
                        tr_reupload.Visible = true;
                        Bindgridview();
                    }
                    else
                    {
                        Bindgridview();
                    }
                }
            }
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
        return dsResult.Tables[0];
    }

    #region GridImage PageIndexChanging
    protected void GridImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
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
            //ShowPageInformation();
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

    protected DataTable GetDataTable()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();

            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            htParam.Add("@DocType", "PHOTO");
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", htParam);

            //htParam.Add("@ID", Request.QueryString["ImageID"]);
            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesbinary", htParam);

            if (dsResult != null)
            {
                BindGrid();
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
        return dsResult.Tables[0];
    }

    protected void GridImage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnid = (HiddenField)e.Row.FindControl("hdnid");
                //Session["imageID"] = hdnid.Value;
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

    protected void btnnext_Click(object sender, EventArgs e)
    {


        try
        {
            int intcode = Convert.ToInt32(ViewState["docCode"]);

            intcode = intcode + 1;
            if (intcode > 1)
            {
                // btnprev.Enabled = true;
            }



            dsResult.Clear();
            htParam.Clear();

            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);

            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
            {
                str = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();
                if (intcode == Convert.ToInt32(str))
                {
                    doctype = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    lblpanelheader.Text = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    hdnDocId.Value = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();//01
                }
            }


            htParam.Clear();
            DataSet dsResult1 = new DataSet();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            htParam.Add("@DocType", doctype);
            dsResult1 = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", htParam);
            if (intcode < dsResult.Tables[0].Rows.Count)
            {
                //btnnext.Enabled = true;
            }

            else
            {
                // btnnext.Enabled = false;
            }

            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                GridImage.Visible = false;
                string strImgPath = string.Empty;
                string strFilePath = string.Empty;
                strFilePath = strPath + lblCndNoValue.Text.Trim();
                strFileName1 = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014
                strFileName = strFilePath + "\\" + strFileName1;
                string strroute = "UploadedFiles" + "/" + Request.QueryString["MemCode"].ToString().Trim() + '/' + strFileName1;
                FrmImg.Visible = true;
                //FrmImg.Attributes["src"] = "UploadedFiles/30012465/30012465_26CDAWelcomeLetter_50000004.pdf";//strFileName;

                FrmImg.Attributes["src"] = strroute;
                ViewState["docCode"] = intcode;
            }
            else
            {
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["docCode"] = intcode;
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
    protected void btnprev_Click(object sender, EventArgs e)
    {
        try
        {
            int intcode = Convert.ToInt32(ViewState["docCode"]);
            intcode = intcode - 1;



            dsResult.Clear();
            htParam.Clear();

            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetDocType", htParam);
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
            if (intcode < dsResult.Tables[0].Rows.Count)
            {
                // btnnext.Enabled = true;
            }
            else
            {
                // btnnext.Enabled = false;
            }
            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
            {
                str = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();
                if (intcode == Convert.ToInt32(str))
                {
                    doctype = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    lblpanelheader.Text = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    hdnDocId.Value = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();//01
                }
            }
            htParam.Clear();
            DataSet dsResult1 = new DataSet();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            htParam.Add("@DocType", doctype);
            dsResult1 = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", htParam);
            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                GridImage.Visible = false;
                string strImgPath = string.Empty;
                string strFilePath = string.Empty;
                strFilePath = strPath + lblCndNoValue.Text.Trim();
                strFileName1 = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014
                strFileName = strFilePath + "\\" + strFileName1;
                FrmImg.Visible = true;
                string strroute = "UploadedFiles" + "/" + Request.QueryString["MemCode"].ToString().Trim() + '/' + strFileName1;
                //FrmImg.Attributes["src"] = "UploadedFiles/30012465/30012465_26CDAWelcomeLetter_50000004.pdf";//strFileName;
                FrmImg.Attributes["src"] = strroute;
                ViewState["docCode"] = intcode;
            }
            else
            {
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["docCode"] = intcode;
            }
            if (intcode == 1)
            {
                //btnprev.Enabled = false;
            }

            else
            {
                //   btnprev.Enabled = true;
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

    //Added by rachana on 13022014 for inbox cfr and transfer details start

    private void BindRemarks()
    {
        try
        {
            GridRemarks.DataBind();
            DataTable dtRemark = GetRemarkdtl();

            if (dtRemark != null)
            {
                if (dtRemark.Rows.Count > 0)
                {
                    GridRemarks.DataSource = dtRemark;
                    if (dtRemark.Rows.Count == 0)
                    {
                        GridRemarks.Visible = false;
                        lblTitleRemarks.Visible = false;
                        Td14.Visible = false;
                    }
                    else
                    {
                        GridRemarks.DataBind();
                        lblTitleRemarks.Visible = true;
                        Td14.Visible = true;
                    }
                }
                else
                {
                    GridRemarks.DataSource = null;
                    GridRemarks.DataBind();
                    lblTitleRemarks.Visible = false;
                    Td14.Visible = false;
                }
            }
            else
            {
                GridRemarks.DataSource = null;
                GridRemarks.DataBind();
                lblTitleRemarks.Visible = false;
                Td14.Visible = false;
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
    protected DataTable GetRemarkdtl()
    {
        DataSet dsRemark = new DataSet();
        try
        {
            Hashtable htRemark = new Hashtable();
            htRemark.Clear();
            htRemark.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //if (ViewState["ProcessType"].ToString() != "NC")
            //{
            //    if (ViewState["RenewalFlag"].ToString() == "Y")
            //    {
            //        htRemark.Add("@Flag", "RW");
            //    }
            //    else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            //    {
            //        htRemark.Add("@Flag", "RE");
            //    }
            //    else
            //    {
                    htRemark.Add("@Flag", "NR");
            //    }
            //}
            //else
            //{
            //    htRemark.Add("@Flag", "NC");
            //}
                    dsRemark = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRemarksDtls", htRemark);
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
        return dsRemark.Tables[0];
    }
    protected void GridRemarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetRemarkdtl();
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
    protected void dgDetailsInbox_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTableInbox();
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
    private void BindInboxGrid()
    {
        try
        {
            dgDetailsInbox.DataBind();
            DataTable dsdgDetailsInbox = GetDataTableInbox();

            if (dsdgDetailsInbox != null)
            {
                if (dsdgDetailsInbox.Rows.Count > 0)
                {
                    dgDetailsInbox.DataSource = dsdgDetailsInbox;
                    //Added for showing grid of responded CFR start
                    if (dsdgDetailsInbox.Rows.Count == 0)
                    {
                        //divCFRInbox.Visible = false;
                        tblCFRInboxCollapse.Visible = false;
                        divCFRInbox.Attributes.Add("Style", "display:none");
                    }
                    else
                    {
                        divCFRInbox.Attributes.Add("Style", "display:block");
                        dgDetailsInbox.DataBind(); //dgDetailsInbox.Rows[0].Visible = true;
                    }
                    //Added for showing grid of responded CFR end
                }
                else
                {
                    dgDetailsInbox.DataSource = null;
                    dgDetailsInbox.DataBind();
                    btnCloseCfr.Visible = false;//added by sanoj 13062023
                }
            }
            else
            {
                dgDetailsInbox.DataSource = null;

                dgDetailsInbox.DataBind();
                btnCloseCfr.Visible = false;//added by sanoj 13062023
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

    protected DataTable GetDataTableInbox()
    {
        try
        {
            htParam.Clear();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //if (ViewState["ProcessType"].ToString() != "NC")
            //{
                //if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
                //{
                //    htParam.Add("@Flag", "RW");
                //}
                //else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                //{
                //    htParam.Add("@Flag", "RE");
                //}
                //else
                //{
                    htParam.Add("@Flag", "NR");
            //    }
            //}
            //else
            //{
            //    htParam.Add("@Flag", "NC");
            //}
            //changed by rachana on 20022014 for filtering data fore grid respond start
            //htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_AssignedCFR_bracheduser", htParam);
            if (Request.QueryString["TrnRequest"].ToString() == "CFRRaise" && Request.QueryString["Type"].ToString() == "Qc" && Request.QueryString["user"].ToString() == "Lic")
            {
                htParam.Add("@UserId", Session["UserID"].ToString().Trim());// added by amruta on 4.9.15
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_AssignedMemCFR_bracheduser", htParam);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    // added by amruta on 4.9.15
                    if (Request.QueryString["user"].ToString() == "Lic")
                    {
                        btnRespond.Visible = false;
                    }
                }
                else
                {
                    btnRespond.Visible = false;
                }
            }
            else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
            {
                htParam.Add("@UserId", Request.QueryString["user"].ToString());
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_AssignedMemCFR_Licenseduser", htParam);
            }
            else
            {

                if (Request.QueryString["TrnRequest"].ToString() == "CFRRespondNOC" && Request.QueryString["Mode"].ToString() != "NOC")
                {
                    htParam.Add("@Flag1", "CLOSED");
                }
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_RespondedMemCFR_bracheduser", htParam);

                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["CFRRemarkID"].ToString() == "22" || dsResult.Tables[0].Rows[i]["CFRRemarkID"].ToString() == "32" || dsResult.Tables[0].Rows[i]["CFRRemarkID"].ToString() == "35")
                    {
                        ChkFeesWavier.Checked = false;
                        ChkFeesWavier.Enabled = false;

                    }
                }
            }
            //changed by rachana on 20022014 for filtering data fore grid respond end

            //return dsResult.Tables[0];
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
        return dsResult.Tables[0];
    }

    protected void BindLabels()
    {
        try
        {
            DataSet dscount = new DataSet();
            Hashtable htcount = new Hashtable();
            htcount.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //if (ViewState["ProcessType"].ToString() != "NC")
            //{
            //    if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            //    {
            //        htcount.Add("@Flag", "RW");///CFR for REnewal
            //    }
            //    else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")///CFR for Reexam
            //    {
            //        htcount.Add("@Flag", "RE");
            //    }
            //    else
            //    {
                   // htcount.Add("@Flag", "NR");///CFR for Normal
            //    }
            //}
            //else
            //{
            //    htcount.Add("@Flag", "NC");
            //}

                    dscount = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemcountFor_bracheduser", htcount);


            lblcfrraisedcount.Text = dscount.Tables[0].Rows[0]["Raised"].ToString();
            lblcfrrespondedcount.Text = dscount.Tables[1].Rows[0]["Responded"].ToString();
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
    //Added by pranjali on 25022014 for displaying the cfrs raised start
    protected void BindLabelsForCfr()
    {
        try
        {
            DataSet dscount = new DataSet();
            Hashtable htcount = new Hashtable();
            htcount.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //if (ViewState["ProcessType"].ToString() != "NC")
            //{
            //    if ((Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond") && (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "QcRes") && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
            //    {
            //        htcount.Add("@Flag", "NR");
            //    }
            //    else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            //    {
            //        htcount.Add("@Flag", "RW");
            //    }
            //    else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            //    {
            //        htcount.Add("@Flag", "RE");
            //    }
            //}
            //else
            //{
            //    htcount.Add("@Flag", "NC");
            //}


            dscount = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemcountFor_bracheduser", htcount);


            lblcfrrais1count.Text = dscount.Tables[0].Rows[0]["Raised"].ToString();
            lblcfrrespondcount.Text = dscount.Tables[1].Rows[0]["Responded"].ToString();
            lblcfrclosed.Text = dscount.Tables[2].Rows[0]["Closed"].ToString();
           // approvedoc.Text = ViewState["approve"].ToString();
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
    //Added by pranjali on 25022014 for displaying the cfrs raised end

    private void BindgridChkboxChnge()
    {
        //Added by pranjali to fill File upload grid start

        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            Hashtable ht = new Hashtable();
            DataSet dscand = new DataSet();
            // comented by  usha on 09.03.2020
            ///ht.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            //{
            //    ht.Add("@CandType", 'T');
            //}
            //else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
            //{
            //    ht.Add("@CandType", 'T');
            //}
            //else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
            //{
            //    ht.Add("@CandType", 'C');
            //}
            //else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            //{
            //    ht.Add("@CandType", 'F');
            //}
            //added by shreela 
            //htParam.Clear();
            //DataSet dsResultren = new DataSet();
            //htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //dsResultren = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htParam);
            //Hashtable htren = new Hashtable();
            //htren.Clear();
            //DataSet dsren = new DataSet();
            //dsren.Clear();
            //htren.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //dsren = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htren);
            ////added by shreela
            //if (ViewState["ProcessType"].ToString() != "NC")
            //{
            //    if (dsResultren.Tables[0].Rows[0]["RenewalFlag"].ToString() == "Y")
            //    {
            //        //ht.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
            //        ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            //        //ht.Add("@ReExmFlag", "N");
            //        ht.Add("@ProcessType", "RW");
            //    }
            //    else if (dsResultren.Tables[0].Rows[0]["ReExamFlag"].ToString() == "Y")
            //    {
            //        //ht.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
            //        ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            //        //ht.Add("@ReExmFlag", "N");
            //        ht.Add("@ProcessType", "RE");
            //    }
            //    //else
            //    //{
            //        ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            //        //if (dsResultren.Tables[0].Rows[0]["IsSPFlag"].ToString() == "Y")
            //        //{
            //        //    ht.Add("@ProcessType", "SP");
            //        //}
            //        //else
            //        //{
            //        //    ht.Add("@ProcessType", "NR");
            //        //}
            //   // }
            //}
            //else
            //{
                ht.Add("@ProcessType", "NR");
            //}
            ht.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            ht.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            ht.Add("@MemType", strMemType);//added by usha on 09.03.2020
            ht.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            ht.Add("@EntityType", Convert.ToString(ViewState["EntityType"]).Trim());//added by usha on 31052022
            dscand = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", ht);
            //added by pranjali on 11-04-2014 end
            //dscand = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDocNames", ht); //commented by pranjali on 11-04-2014
            if (dscand.Tables.Count > 0)
            {
                if (dscand.Tables[0].Rows.Count > 0)
                {
                    dgView.DataSource = null;
                    dgView.DataBind();
                    dgView.DataSource = dscand.Tables[0];
                    dgView.DataBind();
                }
                else
                {
                    dgView.DataSource = null;
                    dgView.DataBind();
                    tblupload.Visible = false;

                }
            }
            else
            {
                dgView.DataSource = null;
                dgView.DataBind();
                tblupload.Visible = false;
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
        //Added by pranjali to fill File upload grid end
    }

    protected void FilluploadedfileChkboxChnge() //string lbldocname
    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            DataSet ds_candtype1 = new DataSet();
            Hashtable httable2 = new Hashtable();
            httable2.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            {
                httable2.Add("@CandType", 'T');
            }
            else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
            {
                httable2.Add("@CandType", 'T');
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
            {
                httable2.Add("@CandType", 'C');
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            {
                httable2.Add("@CandType", 'F');
            }
            //added by pranjali on 11-04-2014 start
            //added by shreela 
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam);
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
            //added by shreela
            if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
            {
                httable2.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                httable2.Add("@ProcessType", "RW");
            }
            else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
            {
                //httable2.Add("@RenwlFlag",Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                httable2.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                //httable2.Add("@ReExmFlag", "N");
                httable2.Add("@ProcessType", "RE");
            }
            else
            {
                httable2.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                {
                    httable2.Add("@ProcessType", "SP");
                }
                else
                {
                    httable2.Add("@ProcessType", "NR");
                }
            }
            httable2.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            httable2.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            ds_candtype1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", httable2);
            //added by pranjali on 11-04-2014 end
            //ds_candtype1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetUploaded_Images", httable2);//commented by pranjali on 11-04-2014 start
            if (ds_candtype1.Tables.Count > 0)
            {
                if (ds_candtype1.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds_candtype1.Tables[0];
                    GridView1.DataBind();
                    tr_DocumentReuploadTitle.Visible = true;
                    tr_reupload.Visible = true;
                    BindgridChkboxChnge();
                }
                else
                {
                    BindgridChkboxChnge();
                }
            }

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



    //#region cbTrfrFlag CheckedChanged
    //protected void cbTrfrFlag_CheckedChanged(object sender, EventArgs e)
    //{


    //    // cbTccCompLcn.Enabled = false;
    //    if (cbTrfrFlag.Checked == true)
    //    {
    //        divTrnsferDetails.Visible = true;//added by pranjali on 13-03-2014 
    //        //added by pranjali on 27-03-2014 for life license and general license no to be same start 
    //        if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
    //        {
    //            txtOldTccLcnNo.Text = txtCompLicNo.Text;
    //        }
    //        //added by pranjali on 27-03-2014 for life license and general license no to be same end
    //        //BindgridChkboxChnge();
    //        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
    //        {
    //            //Based on type of candidate fills the documents to be uploaded in grid 
    //            FilluploadedfileChkboxChnge();
    //        }

    //    }
    //    else if (cbTrfrFlag.Checked == false)
    //    {
    //        divTrnsferDetails.Visible = false;//added by pranjali on 13-03-2014
    //        txtOldTccLcnNo.Text = "";
    //        txtDate.Text = "";
    //        ddlTrnsfrInsurName.SelectedIndex = 0;
    //        RbtNoc.ClearSelection();
    //        RbAckRev.ClearSelection();
    //        txtCndURNNo.Text = "";
    //        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
    //        {
    //            //Based on type of candidate fills the documents to be uploaded in grid 
    //            FilluploadedfileChkboxChnge();
    //        }

    //    }
    //}
    //#endregion 

    #region cbTrfrFlag CheckedChanged
    protected void cbTrfrFlag_CheckedChanged(object sender, EventArgs e)
    {


        // cbTccCompLcn.Enabled = false;
        if (cbTrfrFlag.Checked == true)
        {
            divTrnsferDetails.Visible = true;//added by pranjali on 13-03-2014 
            tblCndURN.Visible = true;//pranjali 23-05-2014
            txtCndURNNo.Visible = true;//pranjali 23-05-2014
            lblcndURNNo.Visible = true;//pranjali 23-05-2014
            lblTrnsfrReqNo.Visible = true;
            TxtTrnsfrReqNo.Visible = true;
            //added by pranjali on 27-03-2014 for life license and general license no to be same start 
            if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            {
                txtOldTccLcnNo.Text = txtCompLicNo.Text;
            }
            //added by pranjali on 27-03-2014 for life license and general license no to be same end
            //BindgridChkboxChnge();
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                //Based on type of candidate fills the documents to be uploaded in grid 
                //FilluploadedfileChkboxChnge();
                BindgridChkboxChnge();
            }

            //Added by rachana on 04-06-2014 start
            //GetCandidateType();
            //if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T"))
            //{
            //    tblEmsdtls.Visible = false;
            //    tblexam.Visible = false;
            //    tbltrn.Visible = false;
            //    ddlExam.Enabled = false;
            //    ddlExmBody.Enabled = false;
            //    ddlpreeamlng.Enabled = false;
            //    ddlExmCentre.Enabled = false;
            //}
            //else
            //{
            if (cbTccCompLcn.Checked == true && chkCompAgnt.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                Divoldtrndtls.Attributes.Add("Style", "display:none");
                tbltrn.Visible = false;
                ddlExam.Enabled = false;
                ddlExmBody.Enabled = false;
                ddlpreeamlng.Enabled = false;
                //ddlExmCentre.Enabled = false;
                //txtExmCentre.Enabled = false;
            }
            else if (cbTccCompLcn.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                Divoldtrndtls.Attributes.Add("Style", "display:none");
                tbltrn.Visible = false;
                ddlExam.Enabled = false;
                ddlExmBody.Enabled = false;
                ddlpreeamlng.Enabled = false;
                //ddlExmCentre.Enabled = false;
                //txtExmCentre.Enabled = false;
            }
            else
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                tbltrn.Visible = false;
                ddlExam.Enabled = false;
                ddlExmBody.Enabled = false;
                ddlpreeamlng.Enabled = false;
                //ddlExmCentre.Enabled = false;
                //txtExmCentre.Enabled = false;
            }
            //}
            //Added by rachana on 04-06-2014 end

        }
        else if (cbTrfrFlag.Checked == false)
        {
            if (chkCompAgnt.Checked == true)
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                tbltrn.Visible = false;
                ddlExam.Enabled = false;
                ddlExmBody.Enabled = false;
                ddlpreeamlng.Enabled = false;
                //ddlExmCentre.Enabled = false;
                tblCndURN.Visible = true;
                lblcndURNNo.Visible = true;
                txtCndURNNo.Visible = true;
                //txtExmCentre.Enabled = false;
            }
            else
            {
                tblEmsdtls.Visible = true;
                tblexam.Visible = true;
                tbltrn.Visible = true;
                ddlExam.Enabled = true;
                ddlExmBody.Enabled = true;
                ddlpreeamlng.Enabled = true;
                //ddlExmCentre.Enabled = true;
                tblCndURN.Visible = false;
                lblcndURNNo.Visible = false;
                txtCndURNNo.Visible = false;
                //txtExmCentre.Enabled = true;
                Divoldtrndtls.Attributes.Add("Style", "display:block");
            }
            divTrnsferDetails.Visible = false;//added by pranjali on 13-03-2014
            txtOldTccLcnNo.Text = "";
            txtDate.Text = "";
            ddlTrnsfrInsurName.SelectedIndex = 0;
            RbtNoc.ClearSelection();
            RbAckRev.ClearSelection();
            lblTrnsfrReqNo.Visible = false;
            TxtTrnsfrReqNo.Visible = false;
            //tblCndURN.Visible = false;
            //txtCndURNNo.Text = "";//pranjali 23-05-2014
            //txtCndURNNo.Visible = false;//pranjali 23-05-2014
            //lblcndURNNo.Visible = false;//pranjali 23-05-2014
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                //Based on type of candidate fills the documents to be uploaded in grid 
                //FilluploadedfileChkboxChnge();
                BindgridChkboxChnge();
            }

        }
    }
    #endregion
    #region composite license checkedchanged
    //Added by kalyani on 6-1-2014 to disabale NOC received on selection of composite license
    protected void cbTccCompLcn_CheckedChanged(object sender, EventArgs e)
    {
        if (cbTccCompLcn.Checked == true)
        {
            divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014
            //added by pranjali on 27-03-2014 for life license and general license no to be same start
            if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            {
                txtCompLicNo.Text = txtOldTccLcnNo.Text;
            }
            //added by pranjali on 27-03-2014 for life license and general license no to be same end
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                //Based on type of candidate fills the documents to be uploaded in grid 
                //FilluploadedfileChkboxChnge();
                BindgridChkboxChnge();
            }

            //shree
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam);
            if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString() == "Y")
            {
                divRenewal.Visible = true;
                Comp.Attributes.Add("Style", "display:block");
                //Comp.Attributes.Add("Style", "display:block");
                hdnCandTypeRen.Value = dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim();
                PopulateRenewalType();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                PopulateLifeTraining();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                //shree07
                //PopulateInsRenewalType();
                //PopulateOthrLifeTraining();
                //trrenwl.Visible = true;
            }
            else
            {
                if (cbTrfrFlag.Checked == true && chkCompAgnt.Checked == true)//TRansfer case
                {
                    tblEmsdtls.Visible = false;
                    tblexam.Visible = false;
                    Divoldtrndtls.Attributes.Add("Style", "display:none");
                    tbltrn.Visible = false;
                    ddlExam.Enabled = false;
                    ddlExmBody.Enabled = false;
                    ddlpreeamlng.Enabled = false;
                    //ddlExmCentre.Enabled = false;
                    //txtExmCentre.Enabled = false;

                }
                else if (cbTrfrFlag.Checked == true && chkCompAgnt.Checked == false)//TRansfer case
                {
                    tblEmsdtls.Visible = false;
                    tblexam.Visible = false;
                    Divoldtrndtls.Attributes.Add("Style", "display:none");
                    tbltrn.Visible = false;
                    ddlExam.Enabled = false;
                    ddlExmBody.Enabled = false;
                    ddlpreeamlng.Enabled = false;
                    //ddlExmCentre.Enabled = false;
                    //txtExmCentre.Enabled = false;
                }
                else if (cbTrfrFlag.Checked == false && chkCompAgnt.Checked == false)
                {
                    tblEmsdtls.Visible = true;
                    tblexam.Visible = true;
                    Divoldtrndtls.Attributes.Add("Style", "display:block");
                    tbltrn.Visible = true;
                    ddlExam.Enabled = true;
                    ddlExmBody.Enabled = true;
                    ddlpreeamlng.Enabled = true;
                    //ddlExmCentre.Enabled = true;
                    //txtExmCentre.Enabled = true;
                }
                else if (cbTrfrFlag.Checked == false && chkCompAgnt.Checked == true)
                {
                    tblEmsdtls.Visible = false;
                    tblexam.Visible = false;
                    Divoldtrndtls.Attributes.Add("Style", "display:none");
                    tbltrn.Visible = false;
                    ddlExam.Enabled = false;
                    ddlExmBody.Enabled = false;
                    ddlpreeamlng.Enabled = false;
                    //ddlExmCentre.Enabled = false;
                    //txtExmCentre.Enabled = false;
                }
            }
        }
        else if (cbTccCompLcn.Checked == false)
        {

            divCompositeDetails.Visible = false;//added by pranjali on 13-03-2014 
            txtCompLicNo.Text = "";
            txtCompLicExpDt.Text = "";
            ddlCompInsurerName.SelectedIndex = 0;
            //chkCompAgnt.Checked = false;//added by pranjali on 28-03-2014 
            //tblCndURN.Visible = false;//pranjali 23-05-2014
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                //Based on type of candidate fills the documents to be uploaded in grid 
                //FilluploadedfileChkboxChnge();
                BindgridChkboxChnge();
            }

            //shree
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htParam);
            if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString() == "Y")
            {
                divRenewal.Visible = true;
                Comp.Attributes.Add("Style", "display:none");
            }
            if (chkCompAgnt.Checked == true)
            {
                tblCndURN.Visible = true;
                lblcndURNNo.Visible = true;
                txtCndURNNo.Visible = true;
            }
        }
        else
        {
            divCompositeDetails.Visible = true;
            NameInsurance(ddlNameIns);
            CatComp(ddlCatComp);
        }
    }

    //added by Nikhil for composite on 5.6.15 start
    private void BindCompositeGrid(string strCndNo)
    {
        Hashtable htCompGrd = new Hashtable();
        DataSet dsCompGrd = new DataSet();
        htCompGrd.Add("@MemCode", strCndNo.Trim());
        dsCompGrd = objDAL.GetDataSetForPrcCLP("Prc_GetCompDtls", htCompGrd);
        string strCndType = dsCompGrd.Tables[0].Rows[0]["Candidate_Type"].ToString();
        if (dsCompGrd != null)
        {
            if (dsCompGrd.Tables.Count > 0 && dsCompGrd.Tables[0].Rows.Count > 0)
            {
                {
                    if (strCndType == "C")
                    {
                        gvComposite.DataSource = dsCompGrd.Tables[0];
                        gvComposite.DataBind();
                    }

                    else
                    {
                        gvTrnsfr.DataSource = dsCompGrd.Tables[0];
                        gvTrnsfr.DataBind();
                    }
                }
            }
        }
    }
    //added by Nikhil for composite on 5.6.15 end
    #endregion




    protected void chkCompAgnt_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCompAgnt.Checked)
        {
            tblCndURN.Visible = true;//pranjali 23-05-2014
            txtCndURNNo.Visible = true;//pranjali 23-05-2014
            lblcndURNNo.Visible = true;//pranjali 23-05-2014
            //lblcndCompUrn.Visible = true;
            //txtcndCompUrn.Visible = true;
            //added by rachana 0n 04062014 start
            if (cbTccCompLcn.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                Divoldtrndtls.Attributes.Add("Style", "display:none");
                tbltrn.Visible = false;
                ddlExam.Enabled = true;
                ddlExmBody.Enabled = true;
                ddlpreeamlng.Enabled = true;
                //ddlExmCentre.Enabled = true;
                tblCndURN.Visible = true;
                //txtExmCentre.Enabled = true;
            }
            else if (cbTrfrFlag.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                Divoldtrndtls.Attributes.Add("Style", "display:none");
                tbltrn.Visible = false;
                ddlExam.Enabled = true;
                ddlExmBody.Enabled = true;
                ddlpreeamlng.Enabled = true;
                //ddlExmCentre.Enabled = true;
                tblCndURN.Visible = true;
                //txtExmCentre.Enabled = true;
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                tbltrn.Visible = false;
                ddlNExam.Enabled = false;
                ddlNExmBody.Enabled = false;
                ddlNpreeamlng.Enabled = false;
                //ddlNExmCenter.Enabled = false;
                //txtExmCentre.Enabled = false;
            }
            //Added by rachna on 04062014 end

        }
        else
        {
            txtCndURNNo.Text = "";//pranjali 23-05-2014
            txtCndURNNo.Visible = false;//pranjali 23-05-2014
            lblcndURNNo.Visible = false;//pranjali 23-05-2014
            tblCndURN.Visible = false;
            //lblcndCompUrn.Visible = false;
            //txtcndCompUrn.Visible = false;
            //added by rachana 0n 04062014 start
            if (cbTrfrFlag.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = false;
                tblexam.Visible = false;
                Divoldtrndtls.Attributes.Add("Style", "display:none");
                tbltrn.Visible = false;
                ddlExam.Enabled = false;
                ddlExmBody.Enabled = false;
                ddlpreeamlng.Enabled = false;
                //ddlExmCentre.Enabled = false;
                tblCndURN.Visible = true;
                lblcndURNNo.Visible = true;
                txtCndURNNo.Visible = true;
                //txtExmCentre.Enabled = false;
            }
            else if (cbTccCompLcn.Checked == true)//Transfer Case
            {
                tblEmsdtls.Visible = true;
                tblexam.Visible = true;
                Divoldtrndtls.Attributes.Add("Style", "display:block");
                tbltrn.Visible = true;
                ddlExam.Enabled = true;
                ddlExmBody.Enabled = true;
                ddlpreeamlng.Enabled = true;
                //ddlExmCentre.Enabled = true;
                //txtExmCentre.Enabled = true;
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            {
                tblEmsdtls.Visible = true;
                tblexam.Visible = true;
                Divoldtrndtls.Attributes.Add("Style", "display:block");
                tbltrn.Visible = true;
                ddlExam.Enabled = true;
                ddlExmBody.Enabled = true;
                ddlpreeamlng.Enabled = true;
                //ddlExmCentre.Enabled = true;
                //txtExmCentre.Enabled = true;
            }
        }
    }

    #region RbtNoc SelectedIndexChanged
    protected void RbtNoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RbtNoc.SelectedValue == "1")
            {
                //trAckRcv.Visible = true;
                RbAckRev.Visible = true;
                lblAckrcv.Visible = true;
                RbtNoc.Enabled = true;
                //trNOCAck.Visible = true;
            }
            else
            {
                //trNOCAck.Visible = false;
                RbAckRev.Visible = false;
                lblAckrcv.Visible = false;
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

    protected void dgDetailsInbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond"|| Request.QueryString["TrnRequest"].ToString() == "CFRRespondNOC" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
                if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" || Request.QueryString["TrnRequest"].ToString() == "CFRRespondNOC" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
                {
                    LinkButton LinkReopen = (LinkButton)e.Row.FindControl("LinkReopen");
                    Label LblRemark = (Label)e.Row.FindControl("LblRemark");
                    Label lblcfr = (Label)e.Row.FindControl("lblcfr");
                    Label lblCFRDocCode = (Label)e.Row.FindControl("lblCFRDocCode");
                    Label lblRemarkidValue = (Label)e.Row.FindControl("lblRemarkid");
                    LinkReopen.Visible = true;

                }
                else if (Request.QueryString["TrnRequest"].ToString() == "CFRRaise" && Request.QueryString["Type"].ToString() == "R" && Request.QueryString["user"].ToString() == "Brn")
                {
                    CheckBox ChkAssigned = (CheckBox)e.Row.FindControl("ChkAssigned");
                    Label lblCFRRemarkID = (Label)e.Row.FindControl("lblCFRRemarkID");
                    Label lblRaisedFlag = (Label)e.Row.FindControl("lblRaisedFlag");
                    Label lblresponded = (Label)e.Row.FindControl("Responded");
                    //if (lblCFRRemarkID.Text == "29" || lblCFRRemarkID.Text == "36" || lblCFRRemarkID.Text == "39")
                    if (lblRaisedFlag.Text == "L")
                    {
                        ChkAssigned.Enabled = false;
                    }
                    else
                    {
                        ChkAssigned.Enabled = true;
                    }
                    if (lblresponded.Text == "Yes")
                    {
                        ChkAssigned.Checked = true;
                        ChkAssigned.Enabled = false;
                    }
                    else
                    {
                        ChkAssigned.Checked = false;
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
    protected void dgDetailsInbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ReopenCFR")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            // Label lblCndno = (Label)row.FindControl("lblCndNo");
            LinkButton LinkReopen = (LinkButton)row.FindControl("LinkReopen");
            Label LblRemark = (Label)row.FindControl("LblRemark");
            Label lblcfr = (Label)row.FindControl("lblcfr");
            Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
            Label lblRemarkidValue = (Label)row.FindControl("lblRemarkid");
            Label lblAddnlRemark = (Label)row.FindControl("lblAddnlRemark");
             // ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
            hdnModuleId.Value = Request.QueryString["ModuleID"].ToString().Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "FuncReOpen('" + lblRemarkidValue.Text + "','" + lblAddnlRemark.Text + "','" + hdnModuleId.Value + "');", true);
           // MdlPopReOpenCFR.Show();

        }
    }
    protected void lnkmandtry_click(object sender, EventArgs e)
    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            //Added by pranjali on 10-03-2014 for filtering mandatory documents start
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dscandtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable);
            Hashtable ht = new Hashtable();
            DataSet ds_panchayat = new DataSet();
            ht.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            ds_panchayat = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetPanchayatCheck", ht);
            //Added by pranjali on 10-03-2014 for filtering mandatory documents end
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
           
            htParam.Add("@Panchayat", ds_panchayat.Tables[0].Rows[0]["Panchayat"].ToString());
            //added by pranjali on 11-04-2014 start
            //shree07
            if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
            {
                //htParam.Add("@RenwlFlag", "Y");
                htParam.Add("@ProcessType", "RW");
            }
            else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
            {
                //htParam.Add("@RenwlFlag", "N");
                htParam.Add("@ProcessType", "RE");
            }
            else
            {
                if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                {
                    htParam.Add("@ProcessType", "SP");
                }
                else
                {
                    htParam.Add("@ProcessType", "NR");
                }
            }
            htParam.Add("@InsurerType", "");
            htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014          
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim().ToUpper() == "R")
            {
                htParam.Clear();
                if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == true))
                {
                    htParam.Add("@CandType", "T");
                }
                else if ((cbTrfrFlag.Checked == true) && (cbTccCompLcn.Checked == false))
                {
                    htParam.Add("@CandType", "T");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == true))
                {
                    htParam.Add("@CandType", "C");
                }
                else if ((cbTrfrFlag.Checked == false) && (cbTccCompLcn.Checked == false))
                {
                    htParam.Add("@CandType", "F");
                }
              
                htParam.Add("@Panchayat", ds_panchayat.Tables[0].Rows[0]["Panchayat"].ToString());
                //added by pranjali on 11-04-2014 start
                //shree07
                if (dscandtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    htParam.Add("@ProcessType", "RW");
                }
                else if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //htParam.Add("@RenwlFlag", "N");
                    htParam.Add("@ProcessType", "RE");
                }
                else
                {
                    if (dscandtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htParam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htParam.Add("@ProcessType", "NR");
                    }
                }
                htParam.Add("@InsurerType", "");
                htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                //if (dscandtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                //{
                //    htParam.Add("@ReExmFlag", "Y");
                //}
                //else
                //{
                //    htParam.Add("@ReExmFlag", "N");
                //}
                //added by pranjali on 11-04-2014 end
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMandatoryDocEdit", htParam);
            }
            else
            {
                dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMandatoryDoc", htParam);
            }
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgDetails1.DataSource = dsResult.Tables[0];
                dgDetails1.DataBind();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "window.setTimeout('PopupModal()',50);", true);
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
    //Added by rachana on 13022014 for inbox cfr and transfer details end

    //Added by rachana on 20022014 for closing cfr start
    protected void btnCloseCfr_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;//added by amruta on 7.9.15
            GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
            dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
            foreach (GridViewRow row in Assignedcfr)
            {
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                Label lblRemarkid = (Label)row.FindControl("lblRemarkid");
                Label lblcfr = (Label)row.FindControl("lblcfr");
                if (chkassign.Checked == true)
                {
                    Hashtable htCFR = new Hashtable();
                    htCFR.Clear();
                    dsResult.Clear();
                    htCFR.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                    htCFR.Add("@CFRfor", lblcfr.Text.Trim());
                    htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                    htCFR.Add("@CFRClosedBy", Session["UserID"].ToString().Trim());

                    //Hashtable htClose = new Hashtable();
                    //DataSet dsclose = new DataSet();
                    //htClose.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                    //dsclose = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htClose);
                    //if (ViewState["ProcessType"].ToString() != "NC")
                    //{
                    //    if (dsclose.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                    //    {
                    //        htCFR.Add("@Flag", "RW");
                    //    }
                    //    else if (dsclose.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    //    {
                    //        htCFR.Add("@Flag", "RE");
                    //    }
                    //    else
                    //    {
                    //        htCFR.Add("@Flag", "NR");
                    //    }
                    //}

                    dataAccessRecruit.execute_sprcMemrecruit("Prc_Submit_MemAssignedCFR_admin", htCFR);
                    btnSubmit.Enabled = false;
                    BindInboxGrid();
                    count = count + 1;

                }

            }
            //added by amruta on 7.9.15 start
            if (count > 0)
            {

                if (dgDetailsInbox.Rows == null || dgDetailsInbox.Rows.Count == 0) //added by sanoj 08062023
                {
                    btnCloseCfr.Visible = false;
                }
                    trmsg.Visible = true;
                lblMessage.Text = "CFR Closed Successfully";
                lblSub.Text = "CFR Closed Successfully<br/><br/>" +  "Code: " + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text;
                //mdlpopupSub.Show();
                //lblMessage.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                lblMessage.Visible = false;
                BtnApprove.Enabled = true;
                btnReject.Enabled = true;

            }
            else
            {
                ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the CheckBox.')", true);
                return;
            }
            //added by amruta on 7.9.15 end
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
    //Added by rachana on 20022014 for closing cfr end

    //Added by pranjali on 03-03-2014 start
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
            if (lblupdSize != null && lblupdSize.Text != "")
            {
                int updsize = Convert.ToInt32(lblupdSize.Text);
                int sizeupd = updsize / 1024;
                lblupdSize.Text = Convert.ToString(sizeupd);
            }
            if (lblManDoc.Text == "Y")
            {
                //e.Row.BackColor = Color.LightPink;
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
                htPanchayat.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcCLP("Prc_CheckForPanchayat", htPanchayat);
                if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                {
                    e.Row.BackColor = Color.LightPink;
                }

            }
            Code = Request.QueryString["Code"].ToString();
            //DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            httable1.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //ds_candtype = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", httable1);
            //DataSet dsdtl = new DataSet();
            //dsdtl = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", httable1);
            Hashtable htparam = new Hashtable();
            htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                //Comented by usha on 09.03.2020
                
                //Added by usha on 09.03.2020  for  POSP
                htparam.Add("@MemType", strMemType);
            }
            else
            {
                htparam.Add("@MemType", strMemType);
            }
            htparam.Add("@ModuleCode", Code.Trim());
            htparam.Add("@TypeofDoc", "UPLD");
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                htparam.Add("@InsurerType", "");
                //if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                //{
                //    htparam.Add("@ProcessType", "SP");
                //}
                //else
                //{
                    htparam.Add("@ProcessType", "NR");
                //}
            }
            //else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            //{
            //    htparam.Add("@InsurerType", "");
            //    htparam.Add("@ProcessType", "RE");
            //}
            //else if (Request.QueryString["Type"].ToString().Trim() == "RenTrn")
            //{
            //    htparam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            //    htparam.Add("@ProcessType", "RW");
            //}
            //else if (Request.QueryString["Type"].ToString().Trim() == "ReExam")
            //{
            //    htparam.Add("@InsurerType", "");
            //    htparam.Add("@ProcessType", "RE");
            //}
            //else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
            //{
            //    htparam.Add("@InsurerType", "");
            //    htparam.Add("@ProcessType", "RW");
            //}
            //else if (Request.QueryString["Type"].ToString().Trim() == "R")
            //{
            //    if (Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).ToString().Trim() != "")
            //    {
            //        htparam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            //    }
            //    else
            //    {
            //        htparam.Add("@InsurerType", "");
            //    }
            //    htparam.Add("@ProcessType", Convert.ToString(dsdtl.Tables[0].Rows[0]["ProcessType"]).Trim());

            //}
            htparam.Add("@doccode", lbldoccode.Text);
            htparam.Add("@EntityType", Convert.ToString(ViewState["EntityType"]).Trim());//added by usha on 31052022
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
                string Memcode = Request.QueryString["MemCode"].ToString().Trim();
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lbldocName = (Label)row.FindControl("lbldocName");
                string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&Memcode=" + Memcode.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReupdSize = (Label)e.Row.FindControl("lblReupdSize");
            if (lblReupdSize != null && lblReupdSize.Text != "")
            {
                int reupdsize = Convert.ToInt32(lblReupdSize.Text);
                int sizereupd = reupdsize / 1024;
                lblReupdSize.Text = Convert.ToString(sizereupd);
            }
        }
    }
    //Added by pranjali on 03-03-2014 end


    protected void lblCndView_Click(object sender, EventArgs e)
    {
        //if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" || Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam")
        {
            string strWindow = "window.open('AGTInfo.aspx?AgnCd=" + txtMemberCode.Text + "&Type=" + "CndStat" + "&Ctgry=" + "Ven" + "&UnitCode=" + "" + "&ID=" + ID + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";

            //string strWindow = "window.open('CndView.aspx?Type=Other&Act=Edit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc")
        {
            string strWindow = "window.open('AGTInfo.aspx?AgnCd=" + txtMemberCode.Text + "&Type=" + "CndStat" + "&Ctgry=" + "Ven" + "&UnitCode=" + "" + "&ID=" + ID + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";

           // string strWindow = "window.open('CndView.aspx?Type=Other&Act=Edit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
        else
        {
            string strWindow = "window.open('AGTInfo.aspx?AgnCd=" + txtMemberCode.Text + "&Type=" + "CndStat" + "&Ctgry=" + "Ven" + "&UnitCode=" + "" + "&ID=" + ID + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";

            //string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("TokenNo", typeof(string)));
        dt.Columns.Add(new DataColumn("PaymentMode", typeof(string)));
        dt.Columns.Add(new DataColumn("PaymentDate", typeof(string)));
        dt.Columns.Add(new DataColumn("BankName", typeof(string)));
        dt.Columns.Add(new DataColumn("InstrumentNo", typeof(string)));
        dt.Columns.Add(new DataColumn("InstrumentDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("TrxNo", typeof(string)));
        dt.Columns.Add(new DataColumn("RcptNo", typeof(string)));

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

    }

    private void AddRowToFeesGrid()
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;


        }
    }

    protected void dgPaymentdtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
            l.Attributes.Add("onclick", "javascript:return confirm('Are You Sure You Want To Delete This Record?')");

            //Label lblPymtMode = (Label)e.Row.FindControl("lblPymtMode");

            //Label lblChqNo = (Label)e.Row.FindControl("lblChqNo");
            //Label lblChqDt = (Label)e.Row.FindControl("lblChqDt");
            //Label lblDDNo = (Label)e.Row.FindControl("lblDDNo");
            //Label lblDDDt = (Label)e.Row.FindControl("lblDDDt");

            //if (lblPymtMode.Text == "Cheque")
            //{
            //    lblDDNo.Text = "";
            //    lblDDDt.Text = "";
            //}
            //else if (lblPymtMode.Text == "Draft")
            //{
            //    lblChqNo.Text = "";
            //    lblChqDt.Text = "";
            //}
            //else
            //{
            //    lblDDNo.Text = "";
            //    lblDDDt.Text = "";

            //    lblChqNo.Text = "";
            //    lblChqDt.Text = "";
            //}

        }

    }
    protected void dgPaymentdtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string EmpID;
            EmpID = row.RowIndex.ToString();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt1 = new DataTable();
                dt1.Clear();
                dt1 = ViewState["CurrentTable"] as DataTable;
                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    DataRow dr;
                    if (i.ToString() == EmpID)
                    {
                        dr = dt1.Rows[i];
                        dt1.Rows[i].Delete();
                        //dt1.Rows.Remove(dr);
                    }
                }
                ViewState.Remove("CurrentTable");
                ViewState["CurrentTable"] = dt1;

                dgPaymentdtls.DataSource = ViewState["CurrentTable"];
                dgPaymentdtls.DataBind();
            }

        }
    }
    protected void dgPaymentdtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    //Added by rachana for fees details end
    protected void chkWebTknRecd_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkWebTknRecd.Checked)
        {
            //txtFeesRcvd.Text = "";
        }
    }
    //Added by shreela on 8/04/2014 start
    #region PopulateRenewalType
    private void PopulateRenewalType()
    {
        oCommon.getDropDown(ddlRenewType, "RenewalType", 1, "", 1);
        ddlRenewType.Items.Insert(0, "---Select---");
    }
    #endregion

    #region PopulateLifeTraining()
    private void PopulateLifeTraining()
    {
        oCommon.getDropDown(ddllyfTraining, "LifeTrng", 1, "", 1);
        ddllyfTraining.Items.Insert(0, "---Select---");
    }
    #endregion

    #region ddlRenewType_SelectedIndexChanged
    protected void ddlRenewType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "L")
        {

            ViewState["InsRenType"] = ddlRenewType.SelectedItem.Value.ToString().Trim();
            hdnInsRenType.Value = ViewState["InsRenType"].ToString();
            ddllyfTraining.Enabled = true;
            tblupload.Visible = true;
            //shree07
            //ssLinkButton1.Visible = false;
            //Bindgridview();
            //Filluploadedfile();

        }
        else
        {
            //hdnInsRenType.Value = ddlRenewType.SelectedItem.Value.ToString().Trim();//shree
            ViewState["InsRenType"] = ddlRenewType.SelectedItem.Value.ToString().Trim();
            hdnInsRenType.Value = ViewState["InsRenType"].ToString();
            ddllyfTraining.ClearSelection();//shree
            //ddllyfTraining.Items.Insert(0, "---Select---");//shree
            ddllyfTraining.Enabled = false;
            tblupload.Visible = true;
            //shree07
           // LinkButton1.Visible = false;
            //Bindgridview();
            //Filluploadedfile();
        }
    }
    #endregion

    //Added by rachana on 30/04/2014 start
    protected void DDlPymtMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDlPymtMode.SelectedValue == "EFT")
        {
            txtPymtAmt.Enabled = false;
            txtChequeNo.Enabled = false;
            txtChequedate.Enabled = false;
            TextEFT.Enabled = true;
            txtPymtAmt.Text = "";
            txtChequeNo.Text = "";
            txtChequedate.Text = "";
            TextEFT.Text = "";
            txtChequedate.Text = "";
            txtBankName.Text = "";

        }
        else if (DDlPymtMode.SelectedValue == "DDP")
        {
            TextEFT.Enabled = false;
            txtPymtAmt.Text = "";
            txtChequeNo.Text = "";
            txtChequedate.Text = "";
            TextEFT.Text = "";
            txtChequedate.Text = "";
            txtBankName.Text = "";

            lblChequeDate.Text = "Draft Date";
            lblChequeNo.Text = "Draft No.";
        }
        else
        {
            TextEFT.Enabled = false;
            txtPymtAmt.Text = "";
            txtChequeNo.Text = "";
            txtChequedate.Text = "";
            TextEFT.Text = "";
            txtChequedate.Text = "";
            txtBankName.Text = "";
        }

    }
    //Added by rachana on 30/04/2014 end
    //added by amruta on 7.9.15 start   
    protected void btnRespond_Click(object sender, EventArgs e)
    {
        int count = 0;
        string docCodeNo = string.Empty;
        string docCodeYes = string.Empty;
        GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
        dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
        //Hashtable htParam = new Hashtable();
        DataSet dsFlag = new DataSet();

        //added by sanoj 19062023
        #region update nomnee details 
        DataSet dsNomnee = new DataSet(); 
        htParam.Clear();
        htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
        htParam.Add("@BankAcntName", ddlnmbnkhldname.Text);
        htParam.Add("@BankAccountCode", txtnmbnkacno.Text);
        htParam.Add("@NeftCode", ddlnmifscode.Text);
        htParam.Add("@BankAcntType", ddlnmddlactype.SelectedValue);
        htParam.Add("@BranchName", ddlnmBrnchname.Text);
        htParam.Add("@BankCode", ddlnmBnkname.Text);
        htParam.Add("@MICRCode", txtnmmicr.Text);
        dsNomnee = dataAccessRecruit.GetDataSetForPrcDBConn("Prc_UpdNm_HNIN", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
        #endregion


        foreach (GridViewRow row in Assignedcfr)
        {
            CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
            Label lblRemarkid = (Label)row.FindControl("lblCFRRemarkID");
            Label lblcfr = (Label)row.FindControl("lblcfr");
            Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
            Label lblCFRFlagType = (Label)row.FindControl("lblCFRFlagType");
            Label lblcfrraise = (Label)row.FindControl("lblcfr");
            //  if(chkassign.Checked==)
            if (chkassign.Checked == true)
            {
                Hashtable htCFR = new Hashtable();
                htCFR.Clear();
                dsResult.Clear();
                htCFR.Add("@UserId", Session["UserID"].ToString().Trim());
               
                htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                htCFR.Add("@DocCode", lblCFRDocCode.Text.Trim());
                htCFR.Add("@Flag", "S");
                //dsFlag = dataAccessRecruit.GetDataSetForPrcCLP("prc_getcfr", htCFR);
                //string strFlag = dsFlag.Tables[0].Rows[0]["Flag"].ToString();
                //if (strFlag == "0")
                //{
                //    // string ImgDesc = ds_documentName.Tables[0].Rows[i]["ImgDesc01"].ToString().Trim();
                //    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                //    //return;
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not authorized to respond cfr for " + lblcfrraise.Text.Trim() + " ')", true);
                //    return;
                //}
                //if (lblCFRDocCode.Text.Trim() == "28")
                //{
                htCFR.Remove("@DocCode");
                htCFR.Remove("@Flag");
                htCFR.Remove("@UserId");
                htCFR.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
                htCFR.Add("@CFRfor", lblcfr.Text.Trim());
                htCFR.Add("@RespondedBy", Session["UserID"].ToString().Trim());
                if (lblCFRFlagType.Text.Trim() == "1")
                {
                    dataAccessRecruit.execute_sprcMemrecruit("Prc_CFRRespondForIRDA", htCFR);
                    BindInboxGrid();
                    //lblcfrrespnd.Text = "Responded successfully";
                    lblcfrrespnd.Text = "Closed Successfully<br/>" + "<br/>Code: " + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text +
                    "<br/>Note :- Please proceed with Update.";
                    //mdlCFRRespond.Show();
                    //pnlMdl1.Visible = true;
                }
                else if (lblCFRFlagType.Text.Trim() == "2")
                {
                    htCFR.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                    dataAccessRecruit.execute_sprcMemrecruit("Prc_Submit_MemAssignedNOCCFR_bracheduser", htCFR);
                    //CheckBox chkassign1 = (CheckBox)row.FindControl("ChkAssigned");
                    BindInboxGrid();

                    lblSub.Text = "CFR Responded Successfully<br/>" +  "<br/>Code: " + lblFrenchiseeCode.Text + "<br/>Name: " + lblAdvNameValue.Text;


                }
                count = count + 1;
                GetChkRespond();

            }
        }

        if (count > 0)
        {
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            //mdlCFRRespond.Show();
            //pnlMdl1.Visible = true;
            //addded by ajay 21042023
            DisableLinkButton(btnprevdoc);
            dgView.Columns[3].Visible = false;
            dgView.Columns[4].Visible = false;
            dgView.Columns[11].Visible = false;
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox')", true);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select valid confermation.')", true);
            return;
        }
    }


    //added by amruta on 7.9.15 end

    protected void lnkGetFees_Click(object sender, EventArgs e)
    {
        string strequal = string.Empty;
        string strnotequal = string.Empty;
        hdnVerifyFees.Value = ""; //first clear the hdnVerifyFees
        string strOutput = string.Empty;
        XmlDocument objOutPut = new XmlDocument();
        try
        {
            #region MANUAL MODE
            if (ViewState["strICMEnable"].ToString() == "MA")
            {

                if (divICM.Visible == true)
                {
                    if (DDlPymtMode.SelectedValue != "EFT")
                    {

                        if (DDlPymtMode.SelectedValue == "" || txtChequedate.Text == "" || txtChequeNo.Text == "" || txtBankName.Text == "" || txtPymtAmt.Text == "")
                        {

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter transaction details')", true);
                            DDlPymtMode.Focus();
                            return;

                        }
                    }
                    else
                    {
                        if (TextEFT.Text == "")
                        {

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter transaction details')", true);
                            DDlPymtMode.Focus();
                            return;

                        }
                    }
                }
            }
            else
            {

            }
            #endregion


            string strdate = string.Empty;
            string strOutput1 = string.Empty;
            int iToken;
            double DTotFees = 0.00;
            string strFeesinput = string.Empty;
            string strxmlDS = string.Empty;
            #region Fees Details
            DataSet dsToken = new DataSet();
            Hashtable htToken = new Hashtable();
            htToken.Add("@AppNo", lblFrenchiseeCode.Text);
            htToken.Add("@MemCode", lblCndNoValue.Text);
            htToken.Add("@candType", hdnPanDtls.Value);
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc" && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
            {
                htToken.Add("@Flag", "QC");
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htToken.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htToken.Add("@Flag", "RE");
            }

            dsToken = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetTokenNoForSync", htToken);

            if (dsToken.Tables.Count > 0)
            {
                if (dsToken.Tables[0].Rows.Count > 0)
                {

                    iToken = Convert.ToInt32(dsToken.Tables[0].Rows[0]["FeesTokenNo"]);
                    DTotFees = Convert.ToDouble(dsToken.Tables[0].Rows[0]["TotalFees"]);
                    if (iToken != 0)
                    {

                        //strFeesinput = "<Input><CHMSId>" + iToken + "</CHMSId></Input>";//uncomment on UAT
                        strFeesinput = "<Input><CHMSId>10000121</CHMSId></Input>";

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Token No. not generated')", true);
                        return;
                    }
                }
            }
            #region to be uncommented on UAT
            //Web service fees dtls start 
            //XmlElement xleml;
            //SysInrgConsum.GetCDBalanceCHMSConsume objPymt = new SysInrgConsum.GetCDBalanceCHMSConsume();
            //strOutput = objPymt.GetCDBalanceDetails(strFeesinput);
            ////Convert Webservice output to dataset
            //xleml = GetElement(strOutput);
            //StringReader stream = null;
            //XmlTextReader reader = null;
            //string strXmlRed = xleml.InnerText;
            //DataSet dsoutput = new DataSet();
            //stream = new StringReader(strXmlRed);
            //// Load the XmlTextReader from the stream
            //reader = new XmlTextReader(stream);
            //dsoutput.ReadXml(reader);
            #endregion
            if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
            {
                //Region to be uncommented on 100 server start
                XmlDocument objfee = new XmlDocument();
                objfee.LoadXml(strFeesinput);
                objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));
                strOutput1 = objOutPut.InnerXml.ToString();
                //Region to be uncommented on 100 server end

            }
            else
            {
                if (DDlPymtMode.SelectedValue != "EFT")
                {
                    decimal decamt = Convert.ToDecimal(txtPymtAmt.Text);
                    if (decamt == Convert.ToDecimal(DTotFees))
                    {
                        strOutput1 = "<OutPut><ChequeDate>" + txtChequedate.Text.Trim() + "</ChequeDate><ChequeNo>" + txtChequeNo.Text.Trim() + "</ChequeNo><ChequeAmount>" +
                           decamt + "</ChequeAmount><BankName>" + txtBankName.Text.Trim() + "</BankName><PaymentMode>" + DDlPymtMode.SelectedItem.Text.Trim()
                            + "</PaymentMode><TransID_fk>" + lblTknNoValue.Text + "</TransID_fk></OutPut>";
                        objOutPut.LoadXml(strOutput1);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees amount Not matched')", true);
                        return;
                    }
                }
                else
                {
                    strOutput1 = "<OutPut><TransID_fk>" + lblTknNoValue.Text + "</TransID_fk><EFTNo>" + TextEFT.Text.Trim() + "</EFTNo></OutPut>";
                    objOutPut.LoadXml(strOutput1);
                }
            }


            //Sync log entry of input output xml 
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();

            int f;
            Hashtable htLog = new Hashtable();
            htLog.Add("@RefNo", lblCndNoValue.Text);
            htLog.Add("@AppNo", lblFrenchiseeCode.Text);
            htLog.Add("@XmlInput", strFeesinput);
            htLog.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            #region To be uncommented on UAT
            //htLog.Add("@Xmloutput", strOutput);
            htLog.Add("@Xmloutput", strOutput1);
            #endregion
            htLog.Add("@Resdate", System.DateTime.Now);
            //if (strOutput1 == "")
            if (strOutput == "")//uncommented on Uat
            {
                htLog.Add("@Errdesc", "ICM provided no output");
            }
            else
            {
                htLog.Add("@Errdesc", "ICM successfully returns value");
            }
            htLog.Add("@MethodName", method.Name.ToString());


            f = dataAccessRecruit.execute_sprcMemrecruit("Prc_InsertSyncLogFees", htLog);

            //Binding output xml to gridview 
            DataSet dsinput = new DataSet();
            DataSet dsoutput = new DataSet();
            dsoutput = dataAccessRecruit.FuncConvertToDataset(objOutPut);
            //divFees.Attributes.Add("Style", "visibility:visible");
            DataTable dtCurrentTable1 = (DataTable)ViewState["dsfeesDtls"];//added prev data to viewstate
            //To avoid multiple entries with same Receipt NO
            if (dgPaymentdtls.Rows.Count > 0)
            {
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {

                    Label lblRcptId = (Label)row.FindControl("lblRcptId");

                    if (dsoutput.Tables.Count > 0)
                    {
                        if (dsoutput.Tables[0].Rows.Count > 0)
                        {
                            string strIsAsme = string.Empty;
                            for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                            {

                                if (lblRcptId.Text == dsoutput.Tables[0].Rows[i]["RcptNo"].ToString())
                                {
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees already entered, please proceed with Approval')", true);
                                    //return;
                                    strequal = "1";
                                }
                                else if (lblRcptId.Text != dsoutput.Tables[0].Rows[i]["RcptNo"].ToString())
                                {

                                    #region Bind payment details
                                    if (dsoutput.Tables.Count > 0)
                                    {
                                        if (dsoutput.Tables[0].Rows.Count > 0)
                                        {

                                            int rowIndex = 0;
                                            if (ViewState["CurrentTable"] != null)
                                            {
                                                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                                                DataRow drCurrentRow = null;

                                                #region MAnual entry
                                                if (DDlPymtMode.SelectedValue == "CHP" || DDlPymtMode.SelectedValue == "DDP")
                                                {

                                                }
                                                else if (DDlPymtMode.SelectedValue == "EFT")
                                                {



                                                }
                                                #endregion
                                                else if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                                {
                                                    rowIndex = dtCurrentTable.Rows.Count;
                                                    drCurrentRow = dtCurrentTable.NewRow();
                                                    drCurrentRow["TokenNo"] = dsoutput.Tables[0].Rows[i]["TokenNo"].ToString();//lblTknNoValue.Text;
                                                    drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString();
                                                    drCurrentRow["PaymentDate"] = dsoutput.Tables[0].Rows[i]["PaymentDate"].ToString();
                                                    if (dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "CD Account")
                                                    {
                                                        drCurrentRow["BankName"] = System.DBNull.Value;
                                                        drCurrentRow["InstrumentNo"] = System.DBNull.Value;
                                                        drCurrentRow["InstrumentDate"] = System.DBNull.Value;
                                                    }
                                                    else
                                                    {


                                                        drCurrentRow["BankName"] = dsoutput.Tables[0].Rows[i]["BankName"].ToString();
                                                        drCurrentRow["InstrumentNo"] = dsoutput.Tables[0].Rows[i]["InstrumentNo"].ToString();
                                                        drCurrentRow["InstrumentDate"] = dsoutput.Tables[0].Rows[i]["InstrumentDate"].ToString();
                                                    }
                                                    if (ViewState["RnwlQCFlag"].ToString() == "")
                                                    {
                                                        if (lblTotfeesValue.Text == "")
                                                        {
                                                            drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                                        }
                                                        else
                                                        {
                                                            drCurrentRow["Amount"] = lblTotfeesValue.Text;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (lblTotfeesLstDesc.Text == "")
                                                        {
                                                            drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                                        }
                                                        else
                                                        {
                                                            drCurrentRow["Amount"] = lblTotfeesLstDesc.Text;
                                                        }
                                                    }
                                                    //drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[i]["Amount"].ToString();
                                                    if (dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "CD Account")
                                                    {
                                                        drCurrentRow["TrxNo"] = dsoutput.Tables[0].Rows[i]["TrxNo"].ToString();
                                                    }
                                                    else
                                                    {
                                                        drCurrentRow["TrxNo"] = System.DBNull.Value;
                                                    }
                                                    drCurrentRow["RcptNo"] = dsoutput.Tables[0].Rows[i]["RcptNo"].ToString();//unique for all transaction

                                                }

                                                dtCurrentTable.Rows.Add(drCurrentRow);
                                                ViewState["CurrentTable"] = dtCurrentTable;

                                                TblFees.Visible = true;
                                                divFees.Attributes.Add("Style", "display: block");

                                                if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                                {
                                                    DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                                    dgPaymentdtls.DataSource = distinctTable;

                                                    dgPaymentdtls.DataBind();
                                                    hdnVerifyFees.Value = "1";
                                                }
                                                else
                                                {
                                                    if (dtCurrentTable1 != null)
                                                    {
                                                        dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);
                                                        DataTable distinctTable = dtCurrentTable1.DefaultView.ToTable( /*distinct*/ true);
                                                        dgPaymentdtls.DataSource = distinctTable;
                                                        dgPaymentdtls.DataBind();
                                                        hdnVerifyFees.Value = "1";
                                                    }
                                                    else
                                                    {
                                                        DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                                        dgPaymentdtls.DataSource = distinctTable;

                                                        dgPaymentdtls.DataBind();
                                                        hdnVerifyFees.Value = "1";
                                                    }

                                                }
                                            }

                                        }
                                        strnotequal = "0";
                                    }

                                    else
                                    {
                                        //divFees.Attributes.Add("Style", "visibility:hidden");
                                        //trfees.Visible = false;
                                    }
                                    #endregion
            #endregion

                                }

                            }



                        }
                    }


                }
                if ((strequal == "1" && strnotequal == "0") || (strequal == "1"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees entered, please proceed with Approval')", true);
                    //return;
                }
            }

            else if (dgPaymentdtls.Rows.Count == 0)
            {

                if (dsoutput.Tables.Count > 0)
                {
                    if (dsoutput.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                        {

                            int rowIndex = 0;
                            if (ViewState["CurrentTable"] != null)
                            {
                                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                                DataRow drCurrentRow = null;

                                #region MAnual entry
                                if (DDlPymtMode.SelectedValue == "CHP" || DDlPymtMode.SelectedValue == "DDP")
                                {

                                }
                                else if (DDlPymtMode.SelectedValue == "EFT")
                                {



                                }
                                #endregion
                                else if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                {
                                    rowIndex = dtCurrentTable.Rows.Count;
                                    drCurrentRow = dtCurrentTable.NewRow();
                                    drCurrentRow["TokenNo"] = dsoutput.Tables[0].Rows[i]["TokenNo"].ToString();//lblTknNoValue.Text;
                                    drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString();
                                    drCurrentRow["PaymentDate"] = dsoutput.Tables[0].Rows[i]["PaymentDate"].ToString();
                                    if (dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "CD Account")
                                    {
                                        drCurrentRow["BankName"] = System.DBNull.Value;
                                        drCurrentRow["InstrumentNo"] = System.DBNull.Value;
                                        drCurrentRow["InstrumentDate"] = System.DBNull.Value;
                                    }
                                    else
                                    {


                                        drCurrentRow["BankName"] = dsoutput.Tables[0].Rows[i]["BankName"].ToString();
                                        drCurrentRow["InstrumentNo"] = dsoutput.Tables[0].Rows[i]["InstrumentNo"].ToString();
                                        drCurrentRow["InstrumentDate"] = dsoutput.Tables[0].Rows[i]["InstrumentDate"].ToString();
                                    }
                                    if (ViewState["RnwlQCFlag"] == "")
                                    {
                                        if (lblTotfeesValue.Text == "")
                                        {
                                            drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                        }
                                        else
                                        {
                                            drCurrentRow["Amount"] = lblTotfeesValue.Text;
                                        }
                                    }
                                    else
                                    {
                                        if (lblTotfeesLstDesc.Text == "")
                                        {
                                            drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                        }
                                        else
                                        {
                                            drCurrentRow["Amount"] = lblTotfeesLstDesc.Text;
                                        }
                                    }
                                    //drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[i]["Amount"].ToString();
                                    if (dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PaymentMode"].ToString() == "CD Account")
                                    {
                                        drCurrentRow["TrxNo"] = dsoutput.Tables[0].Rows[i]["TrxNo"].ToString();
                                    }
                                    else
                                    {
                                        drCurrentRow["TrxNo"] = System.DBNull.Value;
                                    }
                                    drCurrentRow["RcptNo"] = dsoutput.Tables[0].Rows[i]["RcptNo"].ToString();//unique for all transaction

                                }

                                dtCurrentTable.Rows.Add(drCurrentRow);
                                ViewState["CurrentTable"] = dtCurrentTable;

                                TblFees.Visible = true;
                                divFees.Attributes.Add("Style", "display: block");

                                if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                {
                                    DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                    dgPaymentdtls.DataSource = distinctTable;
                                    dgPaymentdtls.DataBind();
                                    hdnVerifyFees.Value = "1";
                                }
                                else
                                {
                                    if (dtCurrentTable1 != null)
                                    {
                                        dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);
                                        DataTable distinctTable = dtCurrentTable1.DefaultView.ToTable( /*distinct*/ true);
                                        dgPaymentdtls.DataSource = distinctTable;
                                        dgPaymentdtls.DataBind();
                                        hdnVerifyFees.Value = "1";
                                    }
                                    else
                                    {
                                        DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                        dgPaymentdtls.DataSource = distinctTable;

                                        dgPaymentdtls.DataBind();
                                        hdnVerifyFees.Value = "1";
                                    }

                                }
                            }
                        }
                    }

                }

                else
                {
                    //divFees.Attributes.Add("Style", "visibility:hidden");
                    //trfees.Visible = false;
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

    //Added for Getting proper xml
    private static XmlElement GetElement(string xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        return doc.DocumentElement;
    }
    //Added by rachana on 22-08-2014 for populating fees at page load start
    private void PopulateFees()
    {
        string strequal = string.Empty;
        string strnotequal = string.Empty;
        hdnVerifyFees.Value = ""; //first clear the hdnVerifyFees
        string strOutput = string.Empty;
        XmlDocument objOutPut = new XmlDocument();
        DataSet dsSeqNo = new DataSet(); //Added by rachana on 02/02/2015 to insert log before response from web service
        try
        {
            string strdate = string.Empty;
            string strOutput1 = string.Empty;
            int iToken;
            double DTotFees = 0.00;
            string strFeesinput = string.Empty;
            string strxmlDS = string.Empty;

            DataSet dsToken = new DataSet();
            Hashtable htToken = new Hashtable();
            htToken.Add("@AppNo", lblFrenchiseeCode.Text);
            htToken.Add("@MemCode", lblCndNoValue.Text);
            htToken.Add("@candType", hdnPanDtls.Value);
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc" && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
            {
                htToken.Add("@Flag", "QC");
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htToken.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htToken.Add("@Flag", "RE");
            }

            dsToken = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetTokenNoForSync", htToken);

            if (dsToken.Tables.Count > 0)
            {
                if (dsToken.Tables[0].Rows.Count > 0)
                {

                    iToken = Convert.ToInt32(dsToken.Tables[0].Rows[0]["FeesTokenNo"]);
                    DTotFees = Convert.ToDouble(dsToken.Tables[0].Rows[0]["TotalFees"]);
                    if (iToken != 0)
                    {

                        strFeesinput = "<Input><CHMSId>" + iToken + "</CHMSId></Input>";//uncomment on UAT
                        //strFeesinput = "<Input><CHMSId>10000121</CHMSId></Input>";

                        //Added by rachana to insert log before response from web service start
                        //Sync log entry of input output xml 
                        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();

                        int f;
                        Hashtable htLog = new Hashtable();
                        htLog.Add("@RefNo", lblCndNoValue.Text);
                        htLog.Add("@AppNo", lblFrenchiseeCode.Text);
                        htLog.Add("@XmlInput", strFeesinput);
                        htLog.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                        #region To be uncommented on UAT
                        //htLog.Add("@Xmloutput", strOutput);
                        htLog.Add("@Xmloutput", System.DBNull.Value);
                        #endregion
                        htLog.Add("@Errdesc", System.DBNull.Value);
                        htLog.Add("@MethodName", method.Name.ToString());


                        //f = dataAccessRecruit.execute_sprcMemrecruit("Prc_InsertSyncLogFees", htLog);
                        dsSeqNo = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsertSyncLogFees", htLog);
                        if (dsSeqNo.Tables.Count > 0)
                        {
                            ViewState["Seqno"] = Convert.ToInt32(dsSeqNo.Tables[0].Rows[0]["SeqNo"].ToString());
                        }
                        else
                        {
                            ViewState["Seqno"] = System.DBNull.Value;
                        }
                        //Added by rachana to insert log before response from web service end

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Token No. not generated')", true);
                        return;
                    }
                }
            }
            #region to be uncommented on UAT
            //Web service fees dtls start 
            // XmlElement xleml;
            //SysInrgConsum.GetCDBalanceCHMSConsume objPymt = new SysInrgConsum.GetCDBalanceCHMSConsume();
            // strOutput = objPymt.GetCDBalanceDetails(strFeesinput);
            //Convert Webservice output to dataset
            // xleml = GetElement(strOutput);
            // StringReader stream = null;
            // XmlTextReader reader = null;
            // string strXmlRed = xleml.InnerText;
            //DataSet dsoutput = new DataSet();
            // stream = new StringReader(strXmlRed);
            // Load the XmlTextReader from the stream
            // reader = new XmlTextReader(stream);


            //dsoutput.ReadXml(reader);
            #endregion

            #region to Added by Amruta on 20/11/2015 on UAT
            Hashtable htfees = new Hashtable();
            DataSet dsoutput = new DataSet();
            htfees.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dsoutput = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFeesDtlsICM", htfees);
            #endregion
            if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
            {
                #region to be uncommented on 100 server start
                //XmlDocument objfee = new XmlDocument();
                //objfee.LoadXml(strFeesinput);
                //objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));
                //strOutput1 = objOutPut.InnerXml.ToString();
                #endregion to be uncommented on 100 server end

            }
            else
            {

            }

            //Added by rachana to Update log after response from web service start
            int f1;

            Hashtable htLogRes = new Hashtable();
            htLogRes.Add("@RefNo", lblCndNoValue.Text);
            htLogRes.Add("@AppNo", lblFrenchiseeCode.Text);
            htLogRes.Add("@SeqNo", ViewState["Seqno"]);
            htLogRes.Add("@UpdatedBy", Session["UserID"].ToString().Trim());

            #region To be uncommented on UAT
            htLogRes.Add("@Xmloutput", strOutput);
            //htLogRes.Add("@Xmloutput", strOutput1);
            #endregion
            //if (strOutput1 == "")
            if (strOutput == "")//uncommented on Uat
            {
                htLogRes.Add("@Resdate", System.DBNull.Value);
            }
            else
            {

                htLogRes.Add("@Resdate", System.DateTime.Now);
            }
            //if (strOutput1 == "")
            if (strOutput == "")//uncommented on Uat
            {
                htLogRes.Add("@Errdesc", "ICM provided no output");
            }
            else
            {
                htLogRes.Add("@Errdesc", "ICM successfully returns value");
            }

            f1 = dataAccessRecruit.execute_sprcMemrecruit("Prc_UpdSyncLogFees", htLogRes);
            //Added by rachana to Update log after response from web service end


            //Binding output xml to gridview 
            DataSet dsinput = new DataSet();
            //DataSet dsoutput = new DataSet();
            //dsoutput = dataAccessRecruit.FuncConvertToDataset(objOutPut);
            //divFees.Attributes.Add("Style", "visibility:visible");
            DataTable dtCurrentTable1 = (DataTable)ViewState["dsfeesDtls"];//added prev data to viewstate
            //To avoid multiple entries with same Receipt NO
            if (dgPaymentdtls.Rows.Count > 0)
            {
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {

                    Label lblRcptId = (Label)row.FindControl("lblRcptId");

                    if (dsoutput.Tables.Count > 0)
                    {
                        if (dsoutput.Tables[0].Rows.Count > 0)
                        {
                            string strIsAsme = string.Empty;
                            for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                            {

                                if (lblRcptId.Text == dsoutput.Tables[0].Rows[i]["RcptNo"].ToString())
                                {
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees already entered, please proceed with Approval')", true);
                                    //return;
                                    strequal = "1";
                                }
                                else if (lblRcptId.Text != dsoutput.Tables[0].Rows[i]["RcptNo"].ToString())
                                {

                                    #region Bind payment details
                                    if (dsoutput.Tables.Count > 0)
                                    {
                                        if (dsoutput.Tables[0].Rows.Count > 0)
                                        {

                                            int rowIndex = 0;
                                            if (ViewState["CurrentTable"] != null)
                                            {
                                                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                                                DataRow drCurrentRow = null;

                                                #region MAnual entry
                                                if (DDlPymtMode.SelectedValue == "CHP" || DDlPymtMode.SelectedValue == "DDP")
                                                {

                                                }
                                                else if (DDlPymtMode.SelectedValue == "EFT")
                                                {



                                                }
                                                #endregion
                                                else if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                                {
                                                    rowIndex = dtCurrentTable.Rows.Count;
                                                    drCurrentRow = dtCurrentTable.NewRow();
                                                    drCurrentRow["TokenNo"] = dsoutput.Tables[0].Rows[i]["TokenNo"].ToString();//lblTknNoValue.Text;
                                                    drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[i]["PymtMode"].ToString();
                                                    drCurrentRow["PaymentDate"] = dsoutput.Tables[0].Rows[i]["TrxDate"].ToString();
                                                    if (dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "CD Account")
                                                    {
                                                        drCurrentRow["BankName"] = System.DBNull.Value;
                                                        drCurrentRow["InstrumentNo"] = System.DBNull.Value;
                                                        drCurrentRow["InstrumentDate"] = System.DBNull.Value;
                                                    }
                                                    else
                                                    {


                                                        drCurrentRow["BankName"] = dsoutput.Tables[0].Rows[i]["BankName"].ToString();
                                                        drCurrentRow["InstrumentNo"] = dsoutput.Tables[0].Rows[i]["ChqDDNo"].ToString();
                                                        drCurrentRow["InstrumentDate"] = dsoutput.Tables[0].Rows[i]["ChqDDDate"].ToString();
                                                    }
                                                    //if (ViewState["RnwlQCFlag"].ToString() == "")
                                                    //{
                                                    //    if (lblTotfeesValue.Text == "")
                                                    //    {
                                                    //        drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        drCurrentRow["Amount"] = lblTotfeesValue.Text;
                                                    //    }
                                                    //}
                                                    //else
                                                    //{
                                                    //    if (lblTotfeesLstDesc.Text == "")
                                                    //    {
                                                    //        drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        drCurrentRow["Amount"] = lblTotfeesLstDesc.Text;
                                                    //    }
                                                    //}
                                                    drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[i]["Amount"].ToString();
                                                    if (dsoutput.Tables[0].Rows[0]["PymtMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "CD Account")
                                                    {
                                                        drCurrentRow["TrxNo"] = dsoutput.Tables[0].Rows[i]["TrxId"].ToString();
                                                    }
                                                    else
                                                    {
                                                        drCurrentRow["TrxNo"] = System.DBNull.Value;
                                                    }
                                                    drCurrentRow["RcptNo"] = dsoutput.Tables[0].Rows[i]["TrxidFK"].ToString();//unique for all transaction

                                                }

                                                dtCurrentTable.Rows.Add(drCurrentRow);
                                                ViewState["CurrentTable"] = dtCurrentTable;

                                                TblFees.Visible = true;
                                                //divFees.Attributes.Add("Style", "display: block");

                                                if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                                {
                                                    DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                                    dgPaymentdtls.DataSource = distinctTable;

                                                    dgPaymentdtls.DataBind();
                                                    hdnVerifyFees.Value = "1";
                                                }
                                                else
                                                {
                                                    if (dtCurrentTable1 != null)
                                                    {
                                                        dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);
                                                        DataTable distinctTable = dtCurrentTable1.DefaultView.ToTable( /*distinct*/ true);
                                                        dgPaymentdtls.DataSource = distinctTable;
                                                        dgPaymentdtls.DataBind();
                                                        hdnVerifyFees.Value = "1";
                                                    }
                                                    else
                                                    {
                                                        DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                                        dgPaymentdtls.DataSource = distinctTable;

                                                        dgPaymentdtls.DataBind();
                                                        hdnVerifyFees.Value = "1";
                                                    }

                                                }
                                            }

                                        }
                                        strnotequal = "0";
                                    }

                                    else
                                    {
                                        //divFees.Attributes.Add("Style", "visibility:hidden");
                                        //trfees.Visible = false;
                                    }
                                    #endregion


                                }

                            }



                        }
                    }


                }
                if ((strequal == "1" && strnotequal == "0") || (strequal == "1"))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees entered, please proceed with Approval')", true);
                    //return;
                }
            }

            else if (dgPaymentdtls.Rows.Count == 0)
            {

                if (dsoutput.Tables.Count > 0)
                {
                    if (dsoutput.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                        {

                            int rowIndex = 0;
                            if (ViewState["CurrentTable"] != null)
                            {
                                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                                DataRow drCurrentRow = null;

                                #region MAnual entry
                                if (DDlPymtMode.SelectedValue == "CHP" || DDlPymtMode.SelectedValue == "DDP")
                                {

                                }
                                else if (DDlPymtMode.SelectedValue == "EFT")
                                {



                                }
                                #endregion
                                else if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                {
                                    rowIndex = dtCurrentTable.Rows.Count;
                                    drCurrentRow = dtCurrentTable.NewRow();
                                    drCurrentRow["TokenNo"] = dsoutput.Tables[0].Rows[i]["TokenNo"].ToString();//lblTknNoValue.Text;
                                    drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[i]["PymtMode"].ToString();
                                    drCurrentRow["PaymentDate"] = dsoutput.Tables[0].Rows[i]["TrxDate"].ToString();
                                    if (dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "CD Account")
                                    {
                                        drCurrentRow["BankName"] = System.DBNull.Value;
                                        drCurrentRow["InstrumentNo"] = System.DBNull.Value;
                                        drCurrentRow["InstrumentDate"] = System.DBNull.Value;
                                    }
                                    else
                                    {


                                        drCurrentRow["BankName"] = dsoutput.Tables[0].Rows[i]["BankName"].ToString();
                                        drCurrentRow["InstrumentNo"] = dsoutput.Tables[0].Rows[i]["ChqDDNo"].ToString();
                                        drCurrentRow["InstrumentDate"] = dsoutput.Tables[0].Rows[i]["ChqDDDate"].ToString();
                                    }
                                    //if (ViewState["RnwlQCFlag"] == "")
                                    //{
                                    //    if (lblTotfeesValue.Text == "")
                                    //    {
                                    //        drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        drCurrentRow["Amount"] = lblTotfeesValue.Text;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (lblTotfeesLstDesc.Text == "")
                                    //    {
                                    //        drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[0]["Amount"].ToString();
                                    //    }
                                    //    else
                                    //    {
                                    //        drCurrentRow["Amount"] = lblTotfeesLstDesc.Text;
                                    //    }
                                    //}
                                    drCurrentRow["Amount"] = dsoutput.Tables[0].Rows[i]["Amount"].ToString();
                                    if (dsoutput.Tables[0].Rows[0]["PymtMode"].ToString() == "Cash" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "EFT/NEFT" || dsoutput.Tables[0].Rows[i]["PymtMode"].ToString() == "CD Account")
                                    {
                                        drCurrentRow["TrxNo"] = dsoutput.Tables[0].Rows[i]["TrxId"].ToString();
                                    }
                                    else
                                    {
                                        drCurrentRow["TrxNo"] = System.DBNull.Value;
                                    }
                                    drCurrentRow["RcptNo"] = dsoutput.Tables[0].Rows[i]["TrxidFK"].ToString();//unique for all transaction

                                }

                                dtCurrentTable.Rows.Add(drCurrentRow);
                                ViewState["CurrentTable"] = dtCurrentTable;

                                TblFees.Visible = true;
                                //divFees.Attributes.Add("Style", "display: block");

                                if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
                                {
                                    DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                    dgPaymentdtls.DataSource = distinctTable;
                                    dgPaymentdtls.DataBind();
                                    hdnVerifyFees.Value = "1";
                                }
                                else
                                {
                                    if (dtCurrentTable1 != null)
                                    {
                                        dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);
                                        DataTable distinctTable = dtCurrentTable1.DefaultView.ToTable( /*distinct*/ true);
                                        dgPaymentdtls.DataSource = distinctTable;
                                        dgPaymentdtls.DataBind();
                                        hdnVerifyFees.Value = "1";
                                    }
                                    else
                                    {
                                        DataTable distinctTable = dtCurrentTable.DefaultView.ToTable( /*distinct*/ true);
                                        dgPaymentdtls.DataSource = distinctTable;

                                        dgPaymentdtls.DataBind();
                                        hdnVerifyFees.Value = "1";
                                    }

                                }
                            }
                        }
                    }

                }

                else
                {
                    //divFees.Attributes.Add("Style", "visibility:hidden");
                    //trfees.Visible = false;
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
    //Added by rachana on 22-08-2014 for populating fees at page load end
    #region
    protected void ddlNExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateNewExmBodyName();
    }
    #endregion

    #region
    protected void ddlNExmBody_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateNewPreExmLanguages();
    }
    #endregion

    #region
    protected void ddlNpreeamlng_SelectedIndexChanged(object sender, EventArgs e)
    {
        //PopulateNewExmCentre();
    }
    #endregion


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        hdnVerifyFees.Value = ""; //first clear the hdnVerifyFees
        try
        {
            if (ViewState["strICMEnable"].ToString() == "MA")
            {

                if (divICM.Visible == true)
                {
                    if (DDlPymtMode.SelectedValue != "EFT")
                    {

                        if (DDlPymtMode.SelectedValue == "" || txtChequedate.Text == "" || txtChequeNo.Text == "" || txtBankName.Text == "" || txtPymtAmt.Text == "")
                        {

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter transaction details')", true);
                            DDlPymtMode.Focus();
                            return;

                        }
                    }
                    else
                    {
                        if (TextEFT.Text == "")
                        {

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter transaction details')", true);
                            DDlPymtMode.Focus();
                            return;

                        }
                    }
                }
            }
            else
            {

            }
            string strdate = string.Empty;
            string strOutput1 = string.Empty;
            int iToken;
            double DTotFees = 0.00;
            string strFeesinput = string.Empty;
            #region Fees Details
            DataSet dsToken = new DataSet();
            Hashtable htToken = new Hashtable();
            htToken.Add("@AppNo", lblFrenchiseeCode.Text);
            htToken.Add("@MemCode", lblCndNoValue.Text);
            htToken.Add("@candType", hdnPanDtls.Value);
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc" && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
            {
                htToken.Add("@Flag", "QC");
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htToken.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htToken.Add("@Flag", "RE");
            }

            dsToken = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetTokenNoForSync", htToken);

            if (dsToken.Tables.Count > 0)
            {
                if (dsToken.Tables[0].Rows.Count > 0)
                {

                    iToken = Convert.ToInt32(dsToken.Tables[0].Rows[0]["FeesTokenNo"]);
                    DTotFees = Convert.ToDouble(dsToken.Tables[0].Rows[0]["TotalFees"]);
                    if (iToken != 0)
                    {
                        //string strFeesinput = "<Input><TransID>" + txtFeesRcvd.Text + "</TransID><SAPCode>" + hdnRecruitAgntCode.Value + "</SAPCode><RequestingSystem>ICM</RequestingSystem></Input>";
                        //if (ViewState["strICMEnable"].ToString() == "NO")//manual fees entry
                        //{
                        strFeesinput = "<Input><TransID>" + iToken + "</TransID><SAPCode>" + strcallerSystem + "</SAPCode><RequestingSystem>iSys</RequestingSystem></Input>";
                        //}
                        //else
                        //{

                        //    strFeesinput = "<Input><TransID>" + txtFeesRcvd.Text + "</TransID><SAPCode>" + strcallerSystem + "</SAPCode><RequestingSystem>iSys</RequestingSystem></Input>";
                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Token No. not generated')", true);

                        return;
                    }
                }
            }

            #region to be uncommented on UAT
            //Web service fees dtls start 
            //SysInrgConsum.GetPaymentDtlsConsum objPymt = new SysInrgConsum.GetPaymentDtlsConsum();
            //string strOutput = objPymt.GetPaymentDtls(strFeesinput);
            #endregion


            //Web service fees dtls end

            XmlDocument objfee = new XmlDocument();
            objfee.LoadXml(strFeesinput);

            XmlDocument objOutPut = new XmlDocument();


            //objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));
            if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
            {
                objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));

                #region to be uncommented on UAT
                //objOutPut.LoadXml(strOutput);
                //string xmloutput=
                XmlNode node = objOutPut.DocumentElement;

                #endregion


                strOutput1 = objOutPut.InnerXml.ToString();

            }
            else
            {
                if (DDlPymtMode.SelectedValue != "EFT")
                {
                    decimal decamt = Convert.ToDecimal(txtPymtAmt.Text);
                    if (decamt == Convert.ToDecimal(DTotFees))
                    {
                        strOutput1 = "<OutPut><ChequeDate>" + txtChequedate.Text.Trim() + "</ChequeDate><ChequeNo>" + txtChequeNo.Text.Trim() + "</ChequeNo><ChequeAmount>" +
                           decamt + "</ChequeAmount><BankName>" + txtBankName.Text.Trim() + "</BankName><PaymentMode>" + DDlPymtMode.SelectedItem.Text.Trim()
                            + "</PaymentMode><TransID_fk>" + lblTknNoValue.Text + "</TransID_fk></OutPut>";
                        objOutPut.LoadXml(strOutput1);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees amount Not matched')", true);
                        return;
                    }
                }
                else
                {
                    strOutput1 = "<OutPut><TransID_fk>" + lblTknNoValue.Text + "</TransID_fk><EFTNo>" + TextEFT.Text.Trim() + "</EFTNo></OutPut>";
                    objOutPut.LoadXml(strOutput1);
                }
            }

            #region to be uncommented on UAT
            //objOutPut.LoadXml(strOutput);
            #endregion

            //string strOutput1 = objOutPut.InnerXml.ToString();

            //Sync log entry of input output xml 
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();

            int f;
            Hashtable htLog = new Hashtable();
            htLog.Add("@RefNo", lblCndNoValue.Text);
            htLog.Add("@AppNo", lblFrenchiseeCode.Text);
            htLog.Add("@XmlInput", strFeesinput);
            htLog.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            #region To be uncommented on UAT
            //htLog.Add("@Xmloutput", strOutput);
            htLog.Add("@Xmloutput", strOutput1);
            #endregion
            htLog.Add("@Resdate", System.DateTime.Now);
            htLog.Add("@Errdesc", "err");
            htLog.Add("@MethodName", method.Name.ToString());


            f = dataAccessRecruit.execute_sprcMemrecruit("Prc_InsertSyncLogFees", htLog);

            //Binding output xml to gridview
            DataSet dsinput = new DataSet();
            DataSet dsoutput = new DataSet();

            dsoutput = dataAccessRecruit.FuncConvertToDataset(objOutPut);

            //To be uncommented on UAT
            //if (dsoutput.Tables.Count > 0)
            //{
            //    if (dsoutput.Tables[0].Rows.Count > 0)
            //    {
            //        if (ViewState["strICMEnable"].ToString() == "YES")//When ICM configuration in Enabled in system
            //        {
            //            double z = Convert.ToDouble(dsoutput.Tables[0].Rows[0]["ChequeAmount"].ToString());
            //            if (z == DTotFees)
            //            {

            //            }
            //            else
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fees amount Not matched. Total fees " + DTotFees + "')", true);
            //                txtFeesRcvd.Focus();
            //                return;
            //            }
            //        }
            //    }
            //}


            divFees.Attributes.Add("Style", "visibility:visible");
            //trfees.Visible = true;

            //Binding value to data table

            DataTable dtCurrentTable1 = (DataTable)ViewState["dsfeesDtls"];//added prev data to viewstate

            if (dsoutput.Tables.Count > 0)
            {
                if (dsoutput.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                    {
                        if (DDlPymtMode.SelectedValue != "EFT")
                        {
                            if (dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString() != "Cash")
                            {
                                strdate = DateTime.Parse(Convert.ToString(dsoutput.Tables[0].Rows[0]["ChequeDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        int rowIndex = 0;
                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            DataRow drCurrentRow = null;

                            if (DDlPymtMode.SelectedValue == "CHP" || DDlPymtMode.SelectedValue == "DDP")
                            {
                                //dgPaymentdtls.Columns[7].Visible = false;
                                //dgPaymentdtls.Columns[8].Visible = false;

                                rowIndex = dtCurrentTable.Rows.Count;
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["TransID_fk"] = dsoutput.Tables[0].Rows[0]["TransID_fk"].ToString();
                                drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString();
                                drCurrentRow["Receiptid"] = "";//txtFeesRcvd.Text;
                                drCurrentRow["ChequeAmount"] = dsoutput.Tables[0].Rows[0]["ChequeAmount"].ToString();
                                if (dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString() == "Cash")
                                {
                                    drCurrentRow["EFT/NEFT"] = System.DBNull.Value;
                                    drCurrentRow["ChequeNo"] = System.DBNull.Value;
                                    drCurrentRow["ChequeDate"] = System.DBNull.Value;
                                    drCurrentRow["BankName"] = System.DBNull.Value;
                                }
                                else
                                {
                                    drCurrentRow["EFT/NEFT"] = System.DBNull.Value;
                                    drCurrentRow["ChequeNo"] = dsoutput.Tables[0].Rows[0]["ChequeNo"].ToString();
                                    drCurrentRow["ChequeDate"] = strdate;
                                    drCurrentRow["BankName"] = dsoutput.Tables[0].Rows[0]["BankName"].ToString();
                                }
                            }
                            else if (DDlPymtMode.SelectedValue == "EFT")
                            {
                                //dgPaymentdtls.Columns[5].Visible = false;
                                //dgPaymentdtls.Columns[6].Visible = false;

                                //dgPaymentdtls.Columns[7].Visible = false;
                                //dgPaymentdtls.Columns[8].Visible = false;

                                rowIndex = dtCurrentTable.Rows.Count;
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["TransID_fk"] = dsoutput.Tables[0].Rows[0]["TransID_fk"].ToString();
                                drCurrentRow["PaymentMode"] = System.DBNull.Value; ;
                                drCurrentRow["Receiptid"] = System.DBNull.Value;
                                drCurrentRow["ChequeAmount"] = System.DBNull.Value; ;

                                drCurrentRow["EFT/NEFT"] = TextEFT.Text.Trim();
                                drCurrentRow["ChequeNo"] = System.DBNull.Value;
                                drCurrentRow["ChequeDate"] = System.DBNull.Value;
                                drCurrentRow["BankName"] = System.DBNull.Value;

                            }



                            dtCurrentTable.Rows.Add(drCurrentRow);
                            ViewState["CurrentTable"] = dtCurrentTable;

                            TblFees.Visible = true;
                            divFees.Attributes.Add("Style", "display: block");

                            if (ViewState["strICMEnable"].ToString() == "NO")//When ICM configuration in Enabled in system
                            {

                                dgPaymentdtls.DataSource = dtCurrentTable;
                                dgPaymentdtls.DataBind();
                                hdnVerifyFees.Value = "1";
                            }
                            else
                            {
                                if (dtCurrentTable1 != null)
                                {
                                    dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);
                                    dgPaymentdtls.DataSource = dtCurrentTable1;
                                    dgPaymentdtls.DataBind();
                                    hdnVerifyFees.Value = "1";
                                }
                                else
                                {
                                    dgPaymentdtls.DataSource = dtCurrentTable;
                                    dgPaymentdtls.DataBind();
                                    hdnVerifyFees.Value = "1";
                                }

                            }
                            //dgPaymentdtls.DataSource = dtCurrentTable;
                            //dgPaymentdtls.DataBind();

                        }
                    }
                }
            }
            else
            {
                //divFees.Attributes.Add("Style", "visibility:hidden");
                //trfees.Visible = false;
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

    //added by shreela start
    protected void btnopen_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "OpenPOP();", true);
    }
    //added by shreela end

    //added by shreela on 08/05/2014 for croping start
    protected void btnCroprefresh_Click(object sender, EventArgs e)
    {
        lblpanelheader.Text = ViewState["docType"].ToString();
        BindGrid();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "CloseSub();", true);
    }
    //added by shreela end
    protected void btnReOpenReFresh_Click(object sender, EventArgs e)
    {
        BindInboxGrid();
        BindLabelsForCfr();
    }
    protected void txtCompLicNo_TextChanged(object sender, EventArgs e)
    {
        //DataSet DsLcnNo = new DataSet();
        //Hashtable HtLcnNo = new Hashtable();
        //if (txtCompLicNo.Text.Trim() == "")
        //{
        //   // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter license no.')", true);
        //  //  return;
        //}
        //else
        //{
        //    HtLcnNo.Add("@LicNo", txtCompLicNo.Text.Trim());
        //}
        //DsLcnNo = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetChkLICNOExist", HtLcnNo);

        //if (DsLcnNo.Tables.Count > 0)
        //{
        //    if (DsLcnNo.Tables[0].Rows.Count > 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License No already exists.')", true);
        //        return;
        //    }
        //}
        //else
        //{
        //    lbllcnerr.Visible = true;
        //    lbllcnerr.Text = "License No. verified";
        //}
    }

    //added by Nikhil on 27/05/2015 start

    // DataTable dt = new DataTable();
    DataTable dt_composite = new DataTable();
    protected void btnAddComposite_Click(object sender, EventArgs e)
    {

        if (ddlCatComp.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is mandatory for composite')", true);
            return;
        }
        //Nikhil 8.6.15
        if (ddlNameIns.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of insurer is mandatory for composite')", true);
            return;
        }
        if (txtAgencyCode.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency code is mandatory for composite')", true);
            return;
        }
        if (txtDateOfAppointment.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment is mandatory for composite')", true);
            return;
        }
        if (ddlSts.SelectedValue == "2")
        {
            if (txtDateOfCessation.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of cessation is mandatory for composite')", true);
                return;
            }
            if (txtReasonForCessation.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reason of cessation is mandatory for composite')", true);
                return;
            }
        }

        // DataTable dt_composite = new DataTable();
        dt_composite.Columns.Add("Category");
        dt_composite.Columns.Add("Name_of_Insurer");
        dt_composite.Columns.Add("Agency_code_Number");
        dt_composite.Columns.Add("Date_of_appointment_as_agent");
        dt_composite.Columns.Add("Date_of_cessation_of_agency");
        dt_composite.Columns.Add("Reason_for_cessation_of_agency");
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



            //if (ddlCatComp.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is mandatory for composite')", true);
            //    return;
            //}
            //if (txtInsurer.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of insurer is mandatory for composite')", true);
            //    return;
            //}
            //if (txtAgencyCode.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency code is mandatory for composite')", true);
            //    return;
            //}
            //if (txtDateOfAppointment.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment is mandatory for composite')", true);
            //    return;
            //}
            //if (ddlSts.SelectedValue == "2")
            //{
            //    if (txtDateOfCessation.Text == "")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of cessation is mandatory for composite')", true);
            //        return;
            //    }
            //    if (txtReasonForCessation.Text == "")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reason of cessation is mandatory for composite')", true);
            //        return;
            //    }

            //}

            dr[0] = lblCategory.Text;
            dr[1] = lblNameInsurer.Text;
            dr[2] = lblAgencyCode.Text;
            dr[3] = lblDateAppointment.Text;
            dr[4] = lblDateCessation.Text;
            dr[5] = lblReasonCessation.Text;


            dt_composite.Rows.Add(dr);

        }

        if (gvComposite.Rows.Count <= 3)
        {
            //dt.Rows.Add(dr);
            dr = dt_composite.NewRow();
            dr["Category"] = ddlCatComp.Text;
            dr["Name_of_Insurer"] = ddlNameIns.Text;//Nikhil 8.6.15
            dr["Agency_code_Number"] = txtAgencyCode.Text;
            dr["Date_of_appointment_as_agent"] = txtDateOfAppointment.Text;
            dr["Date_of_cessation_of_agency"] = txtDateOfCessation.Text;
            dr["Reason_for_cessation_of_agency"] = txtReasonForCessation.Text;
            dt_composite.Rows.Add(dr);
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);

        }
        gvComposite.DataSource = dt_composite;
        gvComposite.DataBind();
        Session["datatable"] = dt_composite;
        ddlCatComp.SelectedIndex = 0;
        ddlSts.SelectedValue = "0";
        ddlNameIns.SelectedIndex = 0;//Nikhil 8.6.15
        txtAgencyCode.Text = "";
        txtDateOfAppointment.Text = "";
        txtDateOfCessation.Text = "";
        txtReasonForCessation.Text = "";

    }



    protected void gvComposite_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt_composite = (DataTable)Session["datatable"];
        if (dt_composite.Rows.Count >= 0)
        {

            dt_composite.Rows.RemoveAt(Convert.ToInt16(gvComposite.SelectedRow));
            gvComposite.DataSource = dt_composite;
            gvComposite.DataBind();

        }

    }
    protected void gvTrnsfr_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dt_trnsfr = (DataTable)Session["datatable"];
        if (dt_trnsfr.Rows.Count >= 0)
        {

            dt_trnsfr.Rows.RemoveAt(Convert.ToInt16(gvTrnsfr.SelectedRow));
            gvTrnsfr.DataSource = dt_trnsfr;
            gvTrnsfr.DataBind();

        }
        if (dt_trnsfr.Rows.Count == 0)
        {
            tdNoteIc.Visible = true;
        }

    }
    //added by Nikhil on 27/05/2015 end

    //added by Nikhil for composite on 5/6/15 start 
    protected void radioComposite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioComposite.SelectedValue == "0")
        {
            ddlCatComp.Enabled = true;
            ddlNameIns.Enabled = true;//Nikhil 8.6.15
            txtAgencyCode.Enabled = true;
            txtDateOfAppointment.Enabled = true;
            ddlSts.Enabled = true;
            txtDateOfCessation.Enabled = true;
            txtReasonForCessation.Enabled = true;
            divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014 
            NameInsurance(ddlNameIns);
            CatComp(ddlCatComp);
            ////added by pranjali on 27-03-2014 for life license and general license no to be same start
            //if (cbTccCompLcn.Checked == true && cbTrfrFlag.Checked == true)
            //{
            //    txtCompLicNo.Text = txtOldTccLcnNo.Text;
            //    FillCndAgntType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "T");
            //}
            //else
            //{
            //    FillCndAgntType0(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue, "C");
            //}
        }
        else
        {
            //ddlCatComp.Enabled = false;
            //ddlNameIns.Enabled = false;//Nikhil 8.6.15
            //txtAgencyCode.Enabled = false;
            //txtDateOfAppointment.Enabled = false;
            //ddlSts.Enabled = false;
            //txtDateOfCessation.Enabled = false;
            //txtReasonForCessation.Enabled = false;
            divCompositeDetails.Visible = false;
        }
    }
    //added by Nikhil for composite on 5/6/15 end
    //added by Nikhil for composite on 8/6/15 start
    private void NameInsurance(DropDownList ddl)
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParams = new Hashtable();
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();
            //oCommon.getDropDown(ddlNameIns, "ComptCompName", 1, "", 1);
            //ddlNameIns.Items.Insert(0, "--Select--")

            htParams.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htParams);
            strCndType = dsComp.Tables[0].Rows[0]["CandType"].ToString();
            if (strCndType == "T")
            {
                htParam.Add("@Flag", "1");
                dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ddlmstinsName", htParam);
            }
            else
            {
              //  dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ddlmstinsName");
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
    private void CatComp(DropDownList ddl)
    {
        try
        {
            
            if (cbTccCompLcn.Checked == true)
            {
                oCommon.getDropDown(ddl, "CatComp", 1, "", 1);
                ddl.Items.Insert(0, "--Select--");
            }
            else
            {
                oCommon.getDropDown(ddl, "CatTran", 1, "", 1);
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
    //added by Nikhil for composite on 8/6/15 end
    //Added by Nikhil start
    private void NameInsuranceNOCLife()
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParams = new Hashtable();
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();

            htParam.Add("@Flag", "2");

            htParam.Add("@category", "Life");
            dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ddlmstinsName", htParam);

            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddlIns.DataSource = dsComp;
                ddlIns.DataTextField = "Name";
                ddlIns.DataValueField = "Name";
                ddlIns.DataBind();
                ddlIns.Items.Insert(0, "--Select--");//amruta 25.1


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
    private void NameInsuranceNOCHealth()
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParams = new Hashtable();
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();

            htParam.Add("@Flag", "2");
            htParam.Add("@category", "Health");
            dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ddlmstinsName", htParam);

            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddlInsname.DataSource = dsComp;
                ddlInsname.DataTextField = "Name";
                ddlInsname.DataValueField = "Name";
                ddlInsname.DataBind();
                ddlInsname.Items.Insert(0, "--Select--");
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
    private void CatCompNOC(DropDownList ddl)
    {
        try
        {
            //Hashtable htParam = new Hashtable();
            //DataSet dsComp = new DataSet();
            ////oCommon.getDropDown(ddlNameIns, "ComptCompName", 1, "", 1);
            ////ddlNameIns.Items.Insert(0, "--Select--")

            //htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            //dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemberType", htParam);
            //strCndType = dsComp.Tables[0].Rows[0]["CandType"].ToString();
            //if (strCndType == "C")

            oCommon.getDropDown(ddl, "CatComp", 1, "", 1);
            ddl.Items.Insert(0, "--Select--");


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
    private void CatApp(DropDownList ddl)
    {
        try
        {

            oCommon.getDropDown(ddl, "CatApp", 1, "", 1);
            ddl.Items.Insert(0, "--Select--");

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
    //Added by Nikhil start
    private void BindGridCom(string strCndNo, string strApplicationNo)
    {
        Hashtable htComp = new Hashtable();
        DataSet dsComp = new DataSet();
        if (cbTccCompLcn.Checked == true)
        {
            foreach (GridViewRow row in gvComposite.Rows)
            {
                Label lblCategory = (Label)row.FindControl("lblCategory");
                Label lblNameInsurer = (Label)row.FindControl("lblNameInsurer");
                Label lblAgencyCode = (Label)row.FindControl("lblAgencyCode");
                Label lblDateAppointment = (Label)row.FindControl("lblDateAppointment");
                Label lblDateCessation = (Label)row.FindControl("lblDateCessation");
                Label lblReasonCessation = (Label)row.FindControl("lblReasonCessation");

                htComp.Clear();
                htComp.Add("@MemCode", lblCndNoValue.Text);
                htComp.Add("@ApplicationNo", lblFrenchiseeCode.Text.Trim());
                htComp.Add("@Category", lblCategory.Text.Trim());
                htComp.Add("@NameofInsurer", lblNameInsurer.Text.Trim());
                htComp.Add("@AgencyCodeNumber", lblAgencyCode.Text.Trim());
                htComp.Add("@DateOfAppointmentAsAgent", lblDateAppointment.Text.Trim());
                htComp.Add("@DateOfCessationOfAgency", lblDateCessation.Text.Trim());
                htComp.Add("@ReasonForCessationOfAgency", lblReasonCessation.Text.Trim());
                htComp.Add("@CreateBy", Session["UserId"].ToString());
                // htComp.Add("@RecruitAgtCode", txtrecagent.Text);
                //htComp.Add("@DirectAgtCode", txtrecagent.Text);
                //////if (Flag == 1)
                //////{
                //////    htComp.Add("@Flag", "1");
                //////    dsComp = dataAccessclass.GetDataSetForPrcCLP("prc_compositedetailsUpd", htComp);

                //////}
                ////else
                //{
                dsComp = objDAL.GetDataSetForPrcCLP("prc_compositedetailsIns", htComp);
                //}
                if (dsComp != null)
                {
                    if (dsComp.Tables.Count > 0 && dsComp.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }

        }
        else
        {
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
                htComp.Add("@MemCode", lblCndNoValue.Text);
                htComp.Add("@ApplicationNo", lblFrenchiseeCode.Text.Trim());
                htComp.Add("@ICDate", lblDate.Text.Trim());
                htComp.Add("@Category", lblCategory.Text.Trim());
                htComp.Add("@NameofInsurer", lblNameInsurer.Text.Trim());
                htComp.Add("@AgencyCodeNumber", lblAgencyCode.Text.Trim());
                htComp.Add("@DateOfAppointmentAsAgent", lblDateAppointment.Text.Trim());
                htComp.Add("@DateOfCessationOfAgency", lblDateCessation.Text.Trim());
                htComp.Add("@ReasonForCessationOfAgency", lblReasonCessation.Text.Trim());
                htComp.Add("@CreateBy", Session["UserId"].ToString());
                // htComp.Add("@RecruitAgtCode", txtrecagent.Text);
                // htComp.Add("@DirectAgtCode", txtrecagent.Text);
                //////if (Flag == 1)
                //////{
                //////    htComp.Add("@Flag", "1");
                //////    dsComp = dataAccessclass.GetDataSetForPrcCLP("prc_compositedetailsUpd", htComp);

                //////}
                ////else
                //{
                dsComp = objDAL.GetDataSetForPrcCLP("prc_compositedetailsIns", htComp);
                //}
                if (dsComp != null)
                {
                    if (dsComp.Tables.Count > 0 && dsComp.Tables[0].Rows.Count > 0)
                    {

                    }
                }
            }
        }
    }
    //Added by Nikhil end
    DataTable dt_trnsfr = new DataTable();

    protected void btnAddTrnsfr_Click(object sender, EventArgs e)
    {
        DateTime ICDt = DateTime.ParseExact(txtIC.Text, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime Today = System.DateTime.Now;


        if (txtIC.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date is mandatory for transfer')", true);
            return;
        }
        if (ICDt > Today)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('I-C Date can not be greater than today date')", true);
            return;
        }
        if (ddlCaTrnsfr.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Category is mandatory for transfer')", true);
            return;
        }
        //Nikhil 8.6.15
        if (ddlNameInTrnsfr.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name of insurer is mandatory for transfer')", true);
            return;
        }
        if (txtAgencyCodeTrnsfr.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Agency code is mandatory for transfer')", true);
            return;
        }
        if (txtDateOfAppointmentTrnsfr.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of appointment is mandatory for transfer')", true);
            return;
        }
        if (ddlStsTrnsfr.SelectedValue == "2")
        {
            if (txtDateOfCessationTrnsfr.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of cessation is mandatory for transfer')", true);
                return;
            }
            if (txtReasonForCessationTrnsfr.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reason of cessation is mandatory for transfer')", true);
                return;
            }

        }

        if (txtIC.Text != "")
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@ICDate", txtIC.Text);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_CheckICDateVal", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    string strIsValid = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();
                    if (strIsValid == "Invalid")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('AS per the Guidelines on Appointment of Insurance Agents 2015 vide circular IRDA/AGTS/CIR/GLD/046/03/2015 dtd 16/03/2015 An Insurer will consider the agency application of the agent only after a period of 90 days from the date of issue of the cessation certificate issued by the previous insurer')", true);
                        return;
                    }
                }
            }
        }
        dt_trnsfr.Columns.Add("Date");
        dt_trnsfr.Columns.Add("Category");
        dt_trnsfr.Columns.Add("Name_of_Insurer");
        dt_trnsfr.Columns.Add("Agency_code_Number");
        dt_trnsfr.Columns.Add("Date_of_Appointment_as_Agent");
        dt_trnsfr.Columns.Add("Date_of_cessation_of_Agency");
        dt_trnsfr.Columns.Add("Reason_for_cessation_of_Agency");
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
            //dt.Rows.Add(dr);
            dr = dt_trnsfr.NewRow();
            dr["Date"] = txtIC.Text;
            dr["Category"] = ddlCaTrnsfr.Text;
            dr["Name_of_Insurer"] = ddlNameInTrnsfr.Text;
            dr["Agency_code_Number"] = txtAgencyCodeTrnsfr.Text;
            dr["Date_of_Appointment_as_Agent"] = txtDateOfAppointmentTrnsfr.Text;
            dr["Date_of_cessation_of_Agency"] = txtDateOfCessationTrnsfr.Text;
            dr["Reason_for_cessation_of_Agency"] = txtReasonForCessationTrnsfr.Text;
            dt_trnsfr.Rows.Add(dr);
        }
        else
        {
            ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "funalert();", true);

        }
        gvTrnsfr.DataSource = dt_trnsfr;
        gvTrnsfr.DataBind();
        //txtIC.Enabled = false;
        //CalendarExtender28.Enabled = false;
        Session["datatable"] = dt_trnsfr;
        ddlCaTrnsfr.SelectedIndex = 0;
        ddlStsTrnsfr.SelectedValue = "0";
        ddlNameInTrnsfr.SelectedIndex = 0;
        txtAgencyCodeTrnsfr.Text = "";
        txtDateOfAppointmentTrnsfr.Text = "";
        txtReasonForCessationTrnsfr.Text = "";
        txtReasonForCessation.Text = "";
        if (gvTrnsfr.Rows.Count > 0)
        {
            tdNoteIc.Visible = false;
        }
        else
        {
            tdNoteIc.Visible = true;
        }

    }

    #region ChkFeesWavier_CheckedChanged event
    protected void ChkFeesWavier_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkFeesWavier.Checked == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The said request will be sent to Corporate DP for approval of fees waiver.')", true);
            return;
        }
    }

    #endregion
    //rotatebutton
    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsimageshow = ViewState["Img1"] as DataSet;
            string strpath = dsimageshow.Tables[0].Rows[0][2].ToString();
            string imgname = dsimageshow.Tables[0].Rows[0][3].ToString();

            imgpaths = strpath + "\\" + imgname;
            ViewState["paths"] = imgpaths.ToString();
            string imgnm = imgname.Substring(0, 11);
            lbltitle1.Text = imgnm.ToString() + " - " + "Web Image Preview";
            //imgbnd.ImageUrl = strpath + "\\" + imgname;
            //imgbnd.DataBind();

            //convert into bite
            byte[] bytes = (byte[])dsimageshow.Tables[0].Rows[0][8];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            ViewState["vpath"] = base64String;
            imgbnd.ImageUrl = "FPImageCSharp.aspx?ImageID=" + dsimageshow.Tables[0].Rows[0]["ID"].ToString();
            mdlpopupzoom.X = 163;
            mdlpopupzoom.Y = 1;
            mdlpopupzoom.Show();

            hdnRotateValue.Value = "0"; //added by amruta 1/8/16 for rotation of image 
            btnRotateSave.Enabled = false; //added by amruta 1/8/16 for rotation of image 
            // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('please upload " + hdnRotateValue.Value + "')", true);
        }
        catch (Exception ex)
        {

        }
    }

    //rotatebutton
    protected void btnrotate_Click(object sender, EventArgs e)
    {
        DataSet dsimageshow = ViewState["Img1"] as DataSet;
        string strpath = dsimageshow.Tables[0].Rows[0][2].ToString();
        string imgname = dsimageshow.Tables[0].Rows[0][3].ToString();

        imgpaths = strpath + "\\" + imgname;

        byte[] bytes = (byte[])dsimageshow.Tables[0].Rows[0][8];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

        byte[] byteBuffer = Convert.FromBase64String(base64String);
        string str1 = Convert.ToString(byteBuffer) as string;

        string strpath1 = imgpaths.Replace("F:\\", "~\\");
        //   imgbnd.ImageUrl = imgbnd.ResolveUrl(~+"/"+imgpaths);

        string path = Server.MapPath(strpath1);
        string path1 = imgpaths.Replace("E:\\Bhaurao_bck_all\\Bhaurao\\ARTL_New_Application\\I-SysSuite\\I-SysSuite", "~\\");

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path1);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file

        img.Save(path1);//imgpaths

        //release image file
        img.Dispose();

        imgbnd.Attributes.Add("ImageUrl", path1);

        mdlpopup.Show();
    }
    //added by amruta 29/7/16 for rotation of image start
    public void lblRotate_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds_image = new DataSet();
            Hashtable httable = new Hashtable();
            ds_image.Clear();
            httable.Clear();

            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            // httable.Add("@DocType", ViewState["docType"]);
            httable.Add("@DocType", lblpanelheader.Text.ToString());
            ds_image = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", httable);

            string strpath = ds_image.Tables[0].Rows[0][2].ToString();
            string imgname = ds_image.Tables[0].Rows[0][3].ToString();

            //convert into bite
            byte[] bytes = (byte[])ds_image.Tables[0].Rows[0][8];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            ViewState["vpath"] = base64String;
            imgbnd.ImageUrl = "FPImageCSharp.aspx?ImageID=" + ds_image.Tables[0].Rows[0]["ID"].ToString();
            mdlpopupzoom.X = 163;
            mdlpopupzoom.Y = 1;
            mdlpopupzoom.Show();

            System.Drawing.Image resim = new Bitmap(ToImage(bytes));

            int degree = Convert.ToInt32(hdnRotateValue.Value);
            resim = cevir((Bitmap)resim, degree);

            bytes = imageToByteArray(resim);

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@ID", ds_image.Tables[0].Rows[0]["ID"].ToString());
            htParam.Add("@ImgByte", bytes);

            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdateMemImg", htParam);
            mdlpopupzoom.Hide();
        }
        catch (Exception ex)
        {

        }
    }
    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }
    public static Bitmap cevir(Bitmap b, float angle)
    {

        // The original bitmap needs to be drawn onto a new bitmap which will probably be bigger 
        // because the corners of the original will move outside the original rectangle.
        // An easy way (OK slightly 'brute force') is to calculate the new bounding box is to calculate the positions of the 
        // corners after rotation and get the difference between the maximum and minimum x and y coordinates.
        float wOver2 = b.Width / 2.0f;
        float hOver2 = b.Height / 2.0f;
        float radians = -(float)(angle / 180.0 * Math.PI);
        // Get the coordinates of the corners, taking the origin to be the centre of the bitmap.
        PointF[] corners = new PointF[]{
            new PointF(-wOver2, -hOver2),
            new PointF(+wOver2, -hOver2),
            new PointF(+wOver2, +hOver2),
            new PointF(-wOver2, +hOver2)
        };

        for (int i = 0; i < 4; i++)
        {
            PointF p = corners[i];
            PointF newP = new PointF((float)(p.X * Math.Cos(radians) - p.Y * Math.Sin(radians)), (float)(p.X * Math.Sin(radians) + p.Y * Math.Cos(radians)));
            corners[i] = newP;
        }

        // Find the min and max x and y coordinates.
        float minX = corners[0].X;
        float maxX = minX;
        float minY = corners[0].Y;
        float maxY = minY;
        for (int i = 1; i < 4; i++)
        {
            PointF p = corners[i];
            minX = Math.Min(minX, p.X);
            maxX = Math.Max(maxX, p.X);
            minY = Math.Min(minY, p.Y);
            maxY = Math.Max(maxY, p.Y);
        }

        // Get the size of the new bitmap.
        SizeF newSize = new SizeF(maxX - minX, maxY - minY);
        // ...and create it.
        Bitmap returnBitmap = new Bitmap((int)Math.Ceiling(newSize.Width), (int)Math.Ceiling(newSize.Height));
        // Now draw the old bitmap on it.
        using (Graphics g = Graphics.FromImage(returnBitmap))
        {
            g.TranslateTransform(newSize.Width / 2.0f, newSize.Height / 2.0f);
            g.RotateTransform(angle);
            g.TranslateTransform(-b.Width / 2.0f, -b.Height / 2.0f);

            g.DrawImage(b, 0, 0);
        }

        return returnBitmap;

        //  return returnBitmap;
    }
    public System.Drawing.Image ToImage(byte[] array)
    {
        System.Drawing.Image returnImage = null;
        MemoryStream ms = new MemoryStream(array);
        returnImage = System.Drawing.Image.FromStream(ms);
        return returnImage;
    }
    //added by amruta 29/7/16 for rotation of image end

    public void btnApp_click(object sender, EventArgs e)
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@ID", hdnId.Value);
        htParam.Add("@Flag", "4");

        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdateMemImg", htParam);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image approved successfully')", true);//added by sanoj 08062023

        divPhoto.Controls.Clear();
        ImageRendering(Request.QueryString["MemCode"].ToString());

    }

    #region PDFApprove

    public void lnkbtnPDFApprv_click(object sender, EventArgs e)
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@ID", hdnId.Value);
        htParam.Add("@Flag", "4");

        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdateMemImg", htParam);
        divPhoto.Controls.Clear();
        ImageRendering(Request.QueryString["MemCode"].ToString());
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PDF approved successfully')", true);//added by Ajay 09062023

    }
    #endregion PDFApprove


    public void btnSaveImage_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds_image = new DataSet();
            Hashtable httable = new Hashtable();
            ds_image.Clear();
            httable.Clear();
            // httable.Add("@ID", ViewState["DocNo"].ToString());//ViewState["hdndoccode"].ToString());
            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //httable.Add("@DocType", ViewState["docType"]);
            httable.Add("@DocType", Convert.ToString(hdnImgId.Value));
            ds_image = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", httable);

            string strpath = ds_image.Tables[0].Rows[0][2].ToString();
            string imgname = ds_image.Tables[0].Rows[0][3].ToString();

            //convert into bite
            byte[] bytes = (byte[])ds_image.Tables[0].Rows[0][8];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            ViewState["vpath"] = base64String;
            img3.ImageUrl = "FPImageCSharp.aspx?ImageID=" + ds_image.Tables[0].Rows[0]["ID"].ToString();

            System.Drawing.Image resim = new Bitmap(ToImage(bytes));

            int degree = Convert.ToInt32(hdnRotateValue.Value);
            int w = Convert.ToInt32(hdnHt.Value);
            // w=Convert.ToInt32(w*2*0.1);
            int h = Convert.ToInt32(hdnWt.Value);
            //h = Convert.ToInt32(h * 2 * 0.1);
            if (degree != 0)
            {
                resim = cevir((Bitmap)resim, degree);
            }


            //            resim = img((Bitmap)resim, w, h);
            bytes = imageToByteArray(resim, w, h);

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@ID", ds_image.Tables[0].Rows[0]["ID"].ToString());
            htParam.Add("@ImgByte", bytes);
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdateMemImg", htParam);
            mdlpopupzoom.Hide();
            // ImageRendering(Request.QueryString["MemCode"].ToString());
            //lblpopup.Text = "Image saved successfully for <br/>" + Convert.ToString(hdnImgId.Value);

            Label15.Text = "Image saved successfully for <br/>" + Convert.ToString(hdnImgId.Value);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "msgpopup('"+ Label15.Text+"'); ", true);

            //mdlpopup.Show();
            //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        }
        catch (Exception ex)
        {

        }
    }

    #region PDFSAVE
    public void btnSavePDF_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds_image = new DataSet();
            Hashtable httable = new Hashtable();
            ds_image.Clear();
            httable.Clear();
            // httable.Add("@ID", ViewState["DocNo"].ToString());//ViewState["hdndoccode"].ToString());
            httable.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            //httable.Add("@DocType", ViewState["docType"]);
            httable.Add("@DocType", Convert.ToString(hdnImgId.Value));
            ds_image = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetImagesforMember", httable);

            string strpath = ds_image.Tables[0].Rows[0][2].ToString();
            string imgname = ds_image.Tables[0].Rows[0][3].ToString();

            //convert into bite
            byte[] bytes = (byte[])ds_image.Tables[0].Rows[0][8];
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            ViewState["vpath"] = base64String;
            img3.ImageUrl = "FPImageCSharp.aspx?ImageID=" + ds_image.Tables[0].Rows[0]["ID"].ToString();

            System.Drawing.Image resim = new Bitmap(ToImage(bytes));

            int degree = Convert.ToInt32(hdnRotateValue.Value);
            int w = Convert.ToInt32(hdnHt.Value);
            // w=Convert.ToInt32(w*2*0.1);
            int h = Convert.ToInt32(hdnWt.Value);
            //h = Convert.ToInt32(h * 2 * 0.1);
            if (degree != 0)
            {
                resim = cevir((Bitmap)resim, degree);
            }


            //            resim = img((Bitmap)resim, w, h);
            bytes = imageToByteArray(resim, w, h);

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@ID", ds_image.Tables[0].Rows[0]["ID"].ToString());
            htParam.Add("@ImgByte", bytes);
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UpdateMemImg", htParam);
            mdlpopupzoom.Hide();
            // ImageRendering(Request.QueryString["MemCode"].ToString());
            lblpopup.Text = "Image saved successfully for <br/>" + Convert.ToString(hdnImgId.Value);
            mdlpopup.Show();
            //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        }
        catch (Exception ex)
        {

        }
    }
    #endregion PDFSAVE

    public byte[] imageToByteArray(System.Drawing.Image imageIn, int w, int h)
    {
        imageIn = new Bitmap(imageIn, w, h);
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }

    public void ImageRendering(string strCndNo)
    {
        try
        {
            BindLabelsForCfr();

            //BindLabels();
            string ShowImage = string.Empty;
            int count = 0;
            int m = 0;
            int n = 6;
            int approve = 0;
            Hashtable htImage = new Hashtable();

            DataSet dsImageDoc = new DataSet();
            htImage.Add("@MemCode", strCndNo);
            //Added by usha  for CFR documnet on 30.11.2018
            if ((Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc") || (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"))
            {
                htImage.Add("@FlagQC", "QC2");
            }
            else
            {
                htImage.Add("@FlagQC", "2");
            }
            //ended by usha  for CFR documnet on 30.11.2018
            dsImage = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htImage);
            if (dsImage.Tables.Count > 0)
            {
                int num = dsImage.Tables[0].Rows.Count;
                if (num < 6)
                {
                    n = num;
                }
                int divide = num / 6;
                int num1 = num % 6;
                if (num1 != 0)
                {
                    divide = divide + 1;
                }
                int idoc = 0;
                for (int i = 0; i < divide; i++)
                {
                    ShowImage = ShowImage + "<div class='row' style='background-color:WhiteSmoke;padding: 1%;'>";

                    //  m = n;
                    // count = count + 1;
                    if (i != 0)
                    {
                        count = ((num - 6) / 6);
                        if (count != 0)
                        {
                            num = num - 6;
                            n = 6;
                            // idoc = idoc ;
                        }
                        else
                        {
                            n = num % 6;
                            //  idoc = idoc -1;
                        }
                    }
                    for (int j = m; j < n; j++)
                    {
                        htImage.Clear();
                        dsImageDoc.Clear();
                        htImage.Add("@MemCode", strCndNo);
                        htImage.Add("@FlagQC", "3");
                        htImage.Add("@Doccode", dsImage.Tables[0].Rows[idoc]["DocCode"].ToString());
                        dsImageDoc = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htImage);

                        Byte[] bytes = (Byte[])dsImageDoc.Tables[0].Rows[0]["Images"];
                        string Flag = dsImageDoc.Tables[0].Rows[0]["Flag"].ToString().Trim();
                        string Flag1 = string.Empty;
                        if (Flag == "")
                        {
                            Flag1 = "1";
                        }
                        else if (Flag == "C" || Flag == "R")
                        {
                            Flag1 = "2";
                        }
                        else
                        {
                            Flag1 = "3";
                        }

                        //added by Daksh for CR Image and PDF Uppload START
                        string FileType = dsImageDoc.Tables[0].Rows[0]["FileType"].ToString().Trim();



                        #region FOR JPEG FORMAT ONLY
                        if (FileType == "" || FileType == "JPEG" || FileType == "JPG" || FileType == "jpg" || FileType == "jpeg" || FileType == "PNG" || FileType == "png")
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(bytes));
                            int height = image.Height;
                            int width = image.Width;
                            int total = height * width;
                            string MstWidth = dsImageDoc.Tables[0].Rows[0]["width"].ToString().Trim();
                            string MstHeight = dsImageDoc.Tables[0].Rows[0]["height"].ToString().Trim();
                            ZinSize.Value = total.ToString();
                            ZoutSize.Value = dsImageDoc.Tables[0].Rows[0]["ImgSize"].ToString().Trim();

                            string serverfilename = dsImageDoc.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                            string id = dsImageDoc.Tables[0].Rows[0]["ID"].ToString().Trim();
                            string Doccode = dsImageDoc.Tables[0].Rows[0]["DocCode"].ToString().Trim();
                            string Imgsrc = "FPImageCSharp.aspx?ImageID=" + id;
                            string Doctype = dsImageDoc.Tables[0].Rows[0]["DocType"].ToString().Trim();
                            ShowImage = ShowImage + "  <div class='col-md-2 portfolio-item' >";

                            // ShowImage = ShowImage + "  <div class='row' style='background-color:WhiteSmoke;padding: 2%;'>";
                            //  ShowImage = ShowImage + "     <a class=thumbnail href=# data-image-id='' data-toggle=modal data-title='This is my title' data-caption=Some lovely red flowers" data-image="http://onelive.us/wp-content/uploads/2014/08/flower-delivery-online.jpg" >";
                            ShowImage = ShowImage + " <img id=" + id + " class='imgheight' height='50px' alt width=32 height=32  src=" + Imgsrc + ">";
                            // ShowImage = ShowImage + "  </a>";
                            //ShowImage = ShowImage + "  <div class='col-md-6' >";
                            ShowImage = ShowImage + " <ul class=list-inline><li>  ";
                            string PopDesc = string.Empty;
                            //    ShowImage = ShowImage + "<a href=# onClientclick='return popup();' data-toggle=tooltip data-placement=bottom";

                            //Added by usha  for CFR documnet on 30.11.2018
                            if ((Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc") || (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"))
                            {
                                PopDesc = "CFR";
                                ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showimage(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "','" + PopDesc + "');\"   class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                            }
                            else
                            {

                                ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showimage(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "'," + PopDesc + ");\"   class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                            }
                            if (Flag != "")
                            {
                                if (Flag == "A")
                                {
                                    Flag = "green";
                                    approve = approve + 1;
                                }
                                else if (Flag == "R")
                                {
                                    Flag = "red";
                                }
                                else if (Flag == "C")
                                {
                                    Flag = "mediumpurple";
                                }

                                ShowImage = ShowImage + " title='" + Doctype + "'><font color=" + Flag + ">" + serverfilename + "</font></button></li> </ul>";
                            }
                            else
                            {
                                ShowImage = ShowImage + " title='" + Doctype + "'>" + serverfilename + "</button></li> </ul>";
                            }
                            //ended  by usha  for CFR documnet on 30.11.2018
                        }
                        #endregion FOR JPEG FORMAT ONLY

                        #region FOR PDF FORMAT ONLY

                        else if (FileType == "PDF")
                        {
                            string serverfilename = dsImageDoc.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                            string id = dsImageDoc.Tables[0].Rows[0]["ID"].ToString().Trim();
                            string Doccode = dsImageDoc.Tables[0].Rows[0]["DocCode"].ToString().Trim();
                            string Imgsrc = "FPImageCSharp.aspx?ImageID=" + id;
                            string Doctype = dsImageDoc.Tables[0].Rows[0]["DocType"].ToString().Trim();
                            ShowImage = ShowImage + "  <div class='col-md-2 portfolio-item' >";
                            ShowImage = ShowImage + " <img id=" + id + " class='imgheight' height='50px' alt width=32 height=32  src='../../../images/download.png'>";
                            ShowImage = ShowImage + " <ul class=list-inline><li>  ";
                            string PopDesc = string.Empty;

                            //Added by usha  for CFR documnet on 30.11.2018
                            if ((Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc") || (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"))
                            {
                                PopDesc = "CFR";
                                ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showPDF(" + id + "," + Doccode + ",' ',' ',' ',' ',' ',' '," + Flag1 + ",'" + Doctype + "','" + PopDesc + "');\" class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                                // OnClick=\"return showPDF(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "','" + PopDesc + "');\"  
                            }
                            else
                            {
                                ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showPDF(" + id + "," + Doccode + ",' ',' ','','','',''," + Flag1 + ",'" + Doctype + "'," + PopDesc + ");\"    class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                                //OnClick=\"return showimage(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "'," + PopDesc + ");\"   
                            }

                            //ended  by usha  for CFR documnet on 30.11.2018

                            if (Flag != "")
                            {
                                if (Flag == "A")
                                {
                                    Flag = "green";
                                    approve = approve + 1;
                                }
                                else if (Flag == "R")
                                {
                                    Flag = "red";
                                }
                                else if (Flag == "C")
                                {
                                    Flag = "mediumpurple";
                                }

                                ShowImage = ShowImage + " title='" + Doctype + "'><font color=" + Flag + ">" + serverfilename + "</font></button></li> </ul>";
                            }
                            else
                            {
                                ShowImage = ShowImage + " title='" + Doctype + "'>" + serverfilename + "</button></li> </ul>";
                            }
                        }

                        #endregion FOR PDF FORMAT ONLY


                        //added by Daksh for CR Image and PDF Uppload END

                        ShowImage = ShowImage + " </div>";
                        idoc = idoc + 1;

                    }
                    ShowImage = ShowImage + "</div>";

                }
                approvedoc.Text = Convert.ToString(approve);
                ViewState["approve"] = Convert.ToString(approve);
                divPhoto.Controls.Add(new LiteralControl(ShowImage));
                //chkOtherCFR.Checked = false;
                tblphoto.Visible = true;
                //hdnCFR.Value = "N";
                //divPhoto.InnerHtml = ShowImage;
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

    //Added by usha for Welcome letter //on 17.01.2021
    private void ConvertRDLCToPDF(String Memcode)
    {
        try
        {
            Hashtable htCRP = new Hashtable();
            htCRP.Add("@MemCode", Memcode);
            DataSet dsCRP = new DataSet();
            dsCRP = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDetailsForDocCreation", htCRP);
            foreach (DataRow dr in dsCRP.Tables[0].Rows)
            {
                //try
                //{
                if (dr["RDLC_PROC"].ToString() != String.Empty)
                {
                    DataSet ds = new DataSet();
                    ds = dataAccessRecruit.GetDataSetForPrcCLP(dr["RDLC_PROC"].ToString(), htCRP);

                    ReportDataSource rdsAct = new ReportDataSource(dr["RDLC_DS"].ToString(), ds.Tables[0]);
                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.Refresh();
                    //viewer.LocalReport.ReportPath = Server.MapPath(dr["WRDLC_PATH"].ToString()); //This is your rdlc name.
                   // viewer.LocalReport.ReportPath = dr["WRDLC_PATH"].ToString(); //This is your rdlc name.
                    viewer.LocalReport.ReportPath = strRpt + dr["WRDLC_PATH"].ToString() ; //This is your rdlc name.
                    viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty; 
                    string encoding = string.Empty; 
                    string extension = string.Empty; 

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                   // byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    Hashtable htApp = new Hashtable();
                    htApp.Add("@MemCode", Memcode.ToString().Trim());
                    htApp.Add("@UserFilename", Memcode.ToString().Trim() + "_" + dr["DocCode"].ToString() + ".pdf");
                    htApp.Add("@ServerFilename", Memcode.ToString().Trim() + "_" + dr["DocCode"].ToString() + ".pdf");
                    htApp.Add("@PDFByte", bytes);
                    htApp.Add("@DocCode", dr["DocCode"].ToString());
                    htApp.Add("@DocType", dr["ImgDesc01"].ToString());
                    htApp.Add("@CreateBy", Session["UserID"].ToString().Trim());


                    ds = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsFPDocFromRDLCToPDF", htApp);
                }
            }
        }
        // }
        //    catch (Exception e)
        //    {
        //        e.ToString();
        //    }

//}

//Comented by usha on 31.05.2022
        //    string strAppoint = string.Empty;
        //    strAppoint = "WelcomeLetter";

        //    string strFileRePath = string.Empty;

        //    if (Directory.Exists(strPath) == false)
        //    {
        //        strPath = strPath + Memcode + "\\";
        //        Directory.CreateDirectory(strPath);
        //    }
        //    else
        //    {
        //        strFileRePath = strPath + Memcode + "\\";

        //        if (!Directory.Exists(strFileRePath))
        //        {

        //            Directory.CreateDirectory(strFileRePath);
        //        }
        //        else
        //        {
        //            strFileRePath = strPath + Memcode + "\\";
        //        }
        //    }

        //    Hashtable htCRP = new Hashtable();
        //    htCRP.Add("@MemCode", Memcode);
        //    DataSet dsCRP = new DataSet();
        //    if (strAppoint == "WelcomeLetter")
        //    {
        //        dsCRP = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetFPWelcomeLetter", htCRP);
        //        ReportDataSource rdsAct = new ReportDataSource("FPWelcomeLetter", dsCRP.Tables[0]);
        //        ReportViewer viewer = new ReportViewer();
        //        viewer.LocalReport.Refresh();
        //        viewer.LocalReport.ReportPath = strRpt + "FPWelcomeLetter.rdlc"; //This is your rdlc name.

        //        viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
        //        byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        //        using (FileStream fs = new FileStream(strFileRePath + "FPWelcomeLetter.pdf", FileMode.Create))
        //        {
        //            fs.Write(bytes, 0, bytes.Length);
        //        }
        //        Hashtable htApp = new Hashtable();
        //        DataSet dsApp = new DataSet();
        //        htApp.Add("@MemCode", Memcode);
        //        htApp.Add("@UserFilename", strFileRePath);
        //        htApp.Add("@ServerFilename", "FPWelcomeLetter.pdf");
        //        htApp.Add("@PDFByte", bytes);
        //        htApp.Add("@CreateBy", Session["UserID"].ToString().Trim());

        //        dsApp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_InsFPConRDLCToPDF", htApp);
        //    }




        //}
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
    //Added by usha for Recruiter Info
    protected void btngst_Click(object sender, EventArgs e)
    {
        string fp_name = lblAdvNameValue.Text;//txtAgntName.Text;
        string fp_pan = txtPAN.Text;
        string fp_address = ViewState["Address"].ToString(); //"";//txtAddrP1.Text;
       DataSet Ds= getbytes();
        if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' Please upload Signature.');</script>", false);
                    return;
                }
                strPath = strPath + txtMemberCode.Text.Trim();// "40086634";
               
                Directory.CreateDirectory(strPath);

                //  added   by sanoj sahani for  byte to image convert and store in folder  01062022
                byte[] bytes = (byte[])Ds.Tables[0].Rows[0]["Images"];
                strFileName = strPath +"\\"+ Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
              
                FileInfo fi = new FileInfo(strFileName);
                using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    FileStream.Write(bytes, 0, bytes.Length);

                }
             string folderName =txtMemberCode.Text.Trim();// "40086634";
            string imgName = Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            string strWindow = "window.open('HTML/GstView.html?fp_name=" + fp_name + "&fp_pan=" + fp_pan + "&fp_address=" + fp_address + "&folderName=" + folderName + "&imgName=" + imgName + " &Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", strWindow, true);
            //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
        //string gsttab = "window.open('HTML/GstView.html?fp_name=" + fp_name + "&fp_pan=" + fp_pan + "&fp_address=" + fp_address + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
        //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", gsttab, true);
        chkgst.Enabled = true;
        btngst.Enabled = true;
        //chkagree.Enabled = true;
        btnView.Enabled = true;
    }

    protected void btnView_Click(object sender, EventArgs e)
    {

        DataSet Ds = getbytes();
        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' Please upload Signature.');</script>", false);
                return;
            }
            strPath = strPath + txtMemberCode.Text.Trim();// "40086634";

            Directory.CreateDirectory(strPath);

            //  added   by sanoj sahani for  byte to image convert and store in folder  01062022
            byte[] bytes = (byte[])Ds.Tables[0].Rows[0]["Images"];
            strFileName = strPath + "\\" + Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();

            FileInfo fi = new FileInfo(strFileName);
            using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                FileStream.Write(bytes, 0, bytes.Length);

            }
            string folderName = txtMemberCode.Text.Trim();// "40086634";
            string imgName = Ds.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            string strWindow = "window.open('HTML/TermsAndCon.html?folderName=" + folderName + "&imgName=" + imgName + " &Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", strWindow, true);

            //string TCtab = "window.open('HTML/TermsAndCon.html?','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
            //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "OpenWindow", TCtab, true);
            chkagree.Enabled = true;
            btnView.Enabled = true;
           // chkgst.Enabled = true;
            btngst.Enabled = true;
        }
    }

    public DataSet   getbytes()
    {
        DataSet dsimg = new DataSet();
        Hashtable htimg = new Hashtable();
        htimg.Add("@Memcode", txtMemberCode.Text.Trim());
        dsimg = objDAL.GetDataSetForPrcCLP("Prc_get_PALDCTMFileUploadMem", htimg);
        if (dsimg.Tables[0].Rows.Count > 0)
        {
            

            byte[] Array = (Byte[])dsimg.Tables[0].Rows[0]["images"];
        }

        return dsimg;
    }


    protected void btnnectcfr_Click(object sender, EventArgs e)
    {
        btnnectcfr.Visible = false;
        Tremcode.Visible = false;

        btnnextDetails.Visible = true;
        div3.Visible = true;
        lblCnddtls.Attributes.Add("style", "color:#9c9c9a;font-size:19px;");
        lblhead.Attributes.Add("style", "color:#00cccc;font-size:19px;");
        divCFRInbox.Visible = true;

        if(Request.QueryString["TrnRequest"] == "CFRRaise" && Request.QueryString["Type"] == "R"&& Request.QueryString["user"] == "Brn")
        {
            btnnextdoc.Visible = true;
            if (ViewState["MemType"].ToString().Trim()=="RF")//added by sanoj 05062023
            {
                memberBnkDtls.Visible = false;
            }
        }
        if (Request.QueryString["TrnRequest"] == "CFRRaise" && Request.QueryString["Type"] == "Qc" && Request.QueryString["user"] == "Lic")
        {
            btnnextdoc.Visible = true;
            if (ViewState["MemType"].ToString().Trim() == "RF")//added by sanoj 05062023
            {
                memberBnkDtls.Visible = false;
                btnnextdoc.Visible = false;
            }
        }
        //Added by usha on 24_04_2023
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
        {
            btnCloseCfr.Visible = true;
            if (ViewState["MemType"].ToString().Trim() == "RF")//added by sanoj 05062023
            {
                memberBnkDtls.Visible = false;
            }
            if (dgDetailsInbox.Rows == null || dgDetailsInbox.Rows.Count == 0) //added by sanoj 15062023
            {
                btnCloseCfr.Visible = false;
            }
        }
    }

    protected void btnnextDetails_Click(object sender, EventArgs e)
    {
        btnnectcfr.Visible = true;
        Tremcode.Visible = true;

        btnnextDetails.Visible = false;
        div3.Visible = false;
        lblhead.Attributes.Add("style", "color:#9c9c9a;font-size:19px;");
        lblCnddtls.Attributes.Add("style", "color:#00cccc;font-size:19px;");
        divCFRInbox.Visible = false;
        btnnextdoc.Visible = false;
        if (ViewState["MemType"].ToString().Trim() == "RF")//added by sanoj 05062023
        {
            memberBnkDtls.Visible = true;
            btnCloseCfr.Visible = false;


        }
    }

    protected void btnnextdoc_Click(object sender, EventArgs e)
    {
        //added by sanoj 14062023
        int count = 0;
        GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
        dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
        foreach (GridViewRow row in Assignedcfr)
        {
            CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");

            if (chkassign.Checked == true)
            {
                count = count + 1;
            }
        }
        if (count > 0)
        {

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox')", true);
            return;
        }
        //Endde by sanoj 14062023
        lblhead.Attributes.Add("style", "color:#9c9c9a;font-size:19px;");
        lbldocupld.Attributes.Add("style", "color:#00cccc;font-size:19px;");
        div1.Visible = true;
        tblupload.Visible = true;
        divCFRInbox.Visible = false;
        btnnextDetails.Visible = false;
        btnprevdoc.Visible = true;
        btnnextdoc.Visible = false;
        btnRespond.Visible = true;
        //added  by ajay 09062023
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["User"].ToString().Trim() == "Brn")
        {
            Bindhninview();
        }
       


    }

    protected void btnprevdoc_Click(object sender, EventArgs e)
    {
        lbldocupld.Attributes.Add("style", "color:#9c9c9a;font-size:19px;");
        lblhead.Attributes.Add("style", "color:#00cccc;font-size:19px;");
        div1.Visible = false;
        btnprevdoc.Visible = false;
        tblupload.Visible = false;
        divCFRInbox.Visible = true;
        btnnextDetails.Visible = true;
        btnnextdoc.Visible = true;
    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["TrnRequest"].ToString().Trim()== "CFRRaise" && Request.QueryString["User"].ToString().Trim() == "Brn")
        {
            string lblCndno = Request.QueryString["MemCode"];
            string  ModuleID= Request.QueryString["ModuleID"];
            string Code = Request.QueryString["Code"];
            Response.Redirect("FranchiesSerach.aspx?TrnRequest=CFRRaise&MemCode=" + lblCndno+ "&Code=" + Code.Trim() + "&ModuleID=" + ModuleID.Trim() + "&Pg=viewcfr&userrollcode=SMUSER&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub");

            
        }
       if(Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["user"].ToString().Trim() == "Lic")//added by sanoj 16052023
        {

          
            //string lblCndno = Request.QueryString["MemCode"];
            string Code = Request.QueryString["Code"];
            Response.Redirect("HNINQCSearch.aspx?ModuleID=11350&Status=QC&Code=" + Code.Trim() + "&Pg=50hrs&MemType=RF");
        }
        //added by sanoj 06062023
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["user"].ToString().Trim() == "Lic")//added by sanoj 16052023
        {

            if (ViewState["MemType"].ToString().Trim() == "RF")
            {
                string Code = Request.QueryString["Code"];
                Response.Redirect("HNINQCSearch.aspx?ModuleID=11350&Status=QC&Code=" + Code.Trim() + "&Pg=50hrs&MemType=RF");
            }
            else
            {
                string lblCndno = Request.QueryString["MemCode"];
                string ModuleID = Request.QueryString["ModuleID"];
                string Code = Request.QueryString["Code"];
                Response.Redirect("FranchiesSerach.aspx?TrnRequest=CFRRaise&MemCode=" + lblCndno + "&ModuleID=" + ModuleID.Trim() + "&Code=" + Code.Trim() + "&Pg=viewcfr&User=Lic");
            }


        }//Ennded by sanoj 06062023
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["user"].ToString().Trim() == "Lic")
        {
            string lblCndno = Request.QueryString["MemCode"];
            string ModuleID = Request.QueryString["ModuleID"];
            string Code = Request.QueryString["Code"];
            if (ViewState["MemType"].ToString().Trim() == "RF")//added by sanoj 06062023
            {
                Response.Redirect("HNINQCSearch.aspx?ModuleID=11350&Status=QC&Code=" + Code.Trim() + "&Pg=50hrs&MemType=RF");
            }
            else
            {
                Response.Redirect("FranchiesSerach.aspx?TrnRequest=CFRRaise&MemCode=" + lblCndno + "&ModuleID=" + ModuleID.Trim() + "&Code=" + Code.Trim() + "&Pg=viewcfr&User=Lic");
           }
        }

    }
    
    public static void DisableLinkButton(LinkButton linkButton)
    {
        linkButton.Enabled = false;
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.BackgroundColor] = "#b1e6e6 !important";
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "no-drop";

    }
    //added by sanoj 05062023 
    protected void btnifsc2_Click(object sender, EventArgs e)
    {

    }
    protected void getdetails()
    {
        try
        {
            Hashtable htParam1 = new Hashtable();
            DataSet dsResult1 = new DataSet();
            htParam1.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam1.Add("@AgentCode", Request.QueryString["MemCode"].ToString().Trim());
            htParam1.Add("@LanguageCode", "2");//dataAccess.GetDataSetForPrcDBConn
            dsResult1 = dataAccessRecruit.GetDataSetForPrcCLP("prc_AgyAdmin_getAgtDt1", htParam1);
          


            if (dsResult1.Tables.Count > 0)
            {
                if (dsResult1.Tables[0].Rows.Count > 0)
                {
                    //txtNominee.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["LegalName"].ToString().Trim());
                    //txtNominMob.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["Tel2"].ToString().Trim());
                    //txtNomneeEmail.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["Email"].ToString().Trim());
                    //Ddlrelation.SelectedValue = dsResult1.Tables[0].Rows[0]["NomineeRel"].ToString().Trim();
                    //txtNomDob.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["BirthDate"].ToString().Trim());
                    ddlnmbnkhldname.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["BankAcntName"]);
                    txtnmbnkacno.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["BankAccountCode"].ToString().Trim());
                    ddlnmifscode.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["ifsccode"].ToString().Trim());
                    ddlnmBnkname.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["BankCode"].ToString().Trim());
                    ddlnmBrnchname.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["Branch Name"].ToString().Trim());
                    ddlnmddlactype.SelectedValue = dsResult1.Tables[0].Rows[0]["BankAcntType"].ToString().Trim();
                    txtnmmicr.Text = Convert.ToString(dsResult1.Tables[0].Rows[0]["MICR Code"].ToString().Trim());
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
    public void disableControls()
    {
       
        ddlnmbnkhldname.Enabled = false;

        txtnmbnkacno.Enabled = false;
        ddlnmifscode.Enabled = false;

        ddlnmddlactype.Enabled = false;
        ddlnmBrnchname.Enabled = false;

        ddlnmBnkname.Enabled = false;
        txtnmmicr.Enabled = false;
    }
    public void enableBankDetails()
    {
        //added by sanoj 19062023
        ddlnmbnkhldname.Enabled = true;
        txtnmbnkacno.Enabled = true;

        ddlnmifscode.Enabled = true;
        ddlnmddlactype.Enabled = true;

        ddlnmBrnchname.Enabled = true;
        ddlnmBnkname.Enabled = true;

        txtnmmicr.Enabled = true;
        //Endded by sanoj 19062023
    }
    private void Bindhninview()
    {
        try
        {
            Hashtable htparam = new Hashtable();
            htparam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            htparam.Add("@MemType", "RF");
            htparam.Add("@ModuleCode", "Spon");
            htparam.Add("@TypeofDoc", "UPLD");
            htparam.Add("@InsurerType", "");
            htparam.Add("@ProcessType", "NR");
            htparam.Add("@EntityType", "HNIN");
            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", htparam);
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
            //LogException("ISYS-CHMS", "HNINEnq.aspx", "Bindgridview", ex);
        }
    }

}

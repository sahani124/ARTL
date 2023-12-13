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
//using SysInrgConsum;
//using System.ServiceModel;
//Added by rachana for fees details Webservice end
public partial class Application_ISys_Recruit_FrmSponDocPreview : BaseClass
{

    protected System.Web.UI.HtmlControls.HtmlInputFile FileInput;

    #region Global declaration
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
    string strPath = @"D:\CommbridgeCMS2.0\Images";//System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
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
    //added by rachana for sysfreezedate start 
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    DateTime Lcndt;
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    string CandidateType;
    //added by rachana for sysfreezedate end
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
                    DataSet dsIsSpPrsn = new DataSet();
                    dsIsSpPrsn = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
                    ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();
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
                    PopulateExamMode();//added by pranjali on 10-04-2014 for binding exam mode
                    PopulatePreExmLanguages(); //added by pranjali on 10-04-2014 for exam languages
                    PopulateExmBodyName(); //added by pranjali on 10-04-2014 for binding exambody name
                    //PopulateExmCentre();//added by pranjali on 10-04-2014 for binding examcentre
                    PopulateNewExamMode();//added by pranjali on 28-04-2014 for binding new exam mode
                    // PopulateNewPreExmLanguages();//added by pranjali on 28-04-2014 for new exam languages
                    //PopulateNewExmBodyName();//added by pranjali on 28-04-2014 for binding new exambody name
                    // PopulateNewExmCentre();//added by pranjali on 28-04-2014 for binding new examcentre
                    PopulateCasteCat();
                    PopulateBasicQual();
                    PopulateProofIDDoc();
                    PopulateCompInsurerName();//added by pranjali on 13-03-2014 for binding composite insurername dropdwn
                    PopulateTrnsfrInsurerName();//added by pranjali on 13-03-2014 for binding trnsfr insurername dropdwn
                    PopulateTrainingMode();
                    GetRenewalDtls();
                    GetReExamDtls();
                    GetCandidateDtls();
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
                        {
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            chkURNExistorNot();
                            //Method for exam type
                            FreezTrnInstLoc();
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            //Added by rachana on 29-07-2013 for Quality check 29-07-2013                        
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            //Added by rachana on 29-07-2013 for Quality check 29-07-2013
                        }

                        #region VIEW section
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "V")
                        {
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            viewData(Request.QueryString["CndNo"].ToString().Trim());
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
                            tblCFRInboxCollapse.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse cfr section
                            lblCndView.Visible = false; //Added by rachana on 07032014
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
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            Filluploadedfile();//Added by pranjali on 02-01-2013        
                            ChkPhotoNotExist_Repeater();
                            btnSubmit.Visible = true;
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
                            lblTitle.Text = "Sponsorship Request Submit";
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
                            tblCFRInboxCollapse.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse cfr section
                            lblCndView.Visible = false; //Added by rachana on 07032014
                            Chkpan.Enabled = false;//disabled only on QC page
                            lblExamTitle.Text = "Exam Details";//added by pranjali on 28-04-2014
                        }
                        #endregion
                        #region Preview section
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start 
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Preview" && Request.QueryString["Type"].ToString().Trim() == "Preview")
                        {
                            #region QC Normal
                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            divSearchDetails.Visible = false;
                            tblIcmColl.Visible=false;
                            tbltrn.Visible = false;
                            tblICMManual.Visible = false;
                            tblEmsdtls.Visible = false;
                            trnsfrtitle.Visible = false;
                            CompositeTitle.Visible = false;
                            trIsPriorAgt.Visible = false;
                            tblexam.Visible = false;
                            ViewState["feescount"] = "";
                            tbltrn.Visible = false;
                            SetInitialRow();
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            divTrnsferDetails.Visible = false;
                            #region photo shuffle start added by rachana on 01-07-2013
                            ViewState["docType"] = Request.QueryString["docName"].ToString().Trim();
                            ViewState["DocNo"] = Request.QueryString["DocCode"].ToString().Trim();
                            #endregion
                            this.Page.Title = "Online Candidate Verification";
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            lblTitle.Text = "Online Candidate Verification";
                            lblCndName.Text = "Candidate Name";
                            btnSubmit.Visible = false;
                            btnSubmit.Text = "Submit";
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = false;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;
                            lblpanelheader.Text = ViewState["docType"].ToString();
                            lblid.Text = ViewState["docType"].ToString();
                            GetCandidateType();
                            if ((IsPriorAgt == "1") || (strCndType == "T"))
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                Divtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;
                            }
                            else
                            {
                            }
                            if (strCndType == "T")
                            {
                            }
                            EnableDisableControls();//to enable and disabled Approve button and Training details                        
                            //PopulateTrnType();
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
                            }
                            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                            {
                                candtype = "F";
                            }
                            BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");
                            BindGrid();
                            btnprev.Enabled = false;
                            tblCFRInbox.Visible = false;
                            tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            Chkpan.Enabled = false;//disabled only on QC page
                            tbltrn.Visible = false;
                            Img2.Visible = false;
                            Table1.Visible = false;
                            #endregion
                        }
                        #endregion
                        #region QC section
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start 
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            #region ICM related
                            trTokenwithFees.Visible = true;
                            PopulateICMStatus();
                            PopulateICMPaymentMode();
                            #endregion

                            #region QC Normal
                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");

                            ViewState["feescount"] = "";
                            SetInitialRow();
                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            btnSave.Visible = true;
                            lblNote.Visible = false;//added by pranjali on 04-03-2014
                            lblCndView.Visible = true;
                            trnsfrtitle.Visible = true;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = true;
                            divCompositeDetails.Visible = false;
                            #region photo shuffle start added by rachana on 01-07-2013
                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
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
                            PopulateTrainingMode();//added by pranjali on 03-03-2014
                            this.Page.Title = "Online Candidate Verification";
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            lblTitle.Text = "Online Candidate Verification";
                            lblCndName.Text = "Candidate Name";

                            btnSubmit.Visible = false;
                            btnSubmit.Text = "Submit";
                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
                            btnReject.Visible = true;
                            //divReject.Visible = true; 
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;

                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }

                            GetCandidateType();
                            if ((IsPriorAgt == "1") || (strCndType == "T"))
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                Divtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;
                            }
                            else
                            {
                                tblEmsdtls.Visible = true;
                                tblexam.Visible = true;
                                tbltrn.Visible = true;
                            }
                            if (strCndType == "T")
                            {
                                lblTrnsfrReqNo.Visible = true;
                                TxtTrnsfrReqNo.Visible = true;
                            }
                            divAgnPhotoTrnExmDtl.Visible = true;//added by pranjali on 11-04-2014
                            BtnCFR.Visible = true;
                            //divCFR.Visible = true;
                            EnableDisableControls();//to enable and disabled Approve button and Training details                        
                            PopulateTrnType();
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
                            BindGrid();
                            btnprev.Enabled = false;
                            //Added by rachana on 02-01-2014 for confirmation of approval start
                            tblCFRInbox.Visible = false;
                            tblCFRInboxCollapse.Visible = false; btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            Chkpan.Enabled = false;//disabled only on QC page
                            //added by pranjali on 26-03-2014 start
                            Hashtable httable = new Hashtable();
                            DataSet dscandtype = new DataSet();
                            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                            strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();
                            lblExamTitle.Text = "Exam Details";//added by pranjali on 28-04-2014
                            if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                            {

                            }
                            else
                            {
                                GetTokenNoforDisplay();
                            }
                            if (ViewState["RenewalFlag"].ToString() == "" && ViewState["RnwlQCFlag"] == "" && ViewState["ReExamFlag"] == "")
                            {
                                //BindFeesDetails();
                                PopulateFees();//added by rachana on 22082014
                            }
                            #endregion

                            #region Renewal QC
                            Hashtable htren = new Hashtable();
                            htren.Clear();
                            DataSet dsren = new DataSet();
                            dsren.Clear();
                            htren.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htren);
                            hdnrenwlflag.Value = dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                            //viewstate for inserting fees details
                            ViewState["RenewalFlag"] = dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
                            if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")//Renewal QC
                            {
                                lblReqStatus.Visible = false;//Added by kalyani on 16-05-14 to hide RequsetStatus
                                lblReqStatusValue.Visible = false;//Added by kalyani on 16-05-14 to hide RequsetStatus
                                tblRenewalCollapse.Visible = true;
                                divRenewal.Visible = true;
                                Comp.Attributes.Add("Style", "display:none");
                                trTokenwithFees.Visible = false;
                                tblIcmColl.Visible = false;
                                DivICMDtls.Attributes.Add("Style", "display:none");

                                htParam.Clear();
                                dsResult.Clear();
                                htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRenewalRecrd", htParam);
                                string strcnd = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString();
                                //2nd time QC
                                if (dsren.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() == "Y")
                                {
                                    FeesRow.Visible = true;
                                    trTokenwithFees.Attributes.Add("Style", "display:block");
                                    PopulateFees();
                                    //BindFeesDetails();
                                    //tblICMManual.Visible = true;
                                    //divICM.Visible = true;

                                    tblIcmColl.Visible = true;
                                    //DivICMDtls.Attributes.Add("Style", "display:block");
                                    if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                                    {

                                    }
                                    else
                                    {
                                        GetTokenNoforDisplay();
                                        GetTotalFeesBasedOnLcnExpDate();
                                    }
                                    if (dsResult.Tables.Count > 0)
                                    {
                                        if (dsResult.Tables[0].Rows.Count > 0)
                                        {
                                            lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                                            lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                                            lbltxtQCRenewType.Text = dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                                            lbltxtQClyfTraining.Text = dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                                        }
                                    }
                                    if (strcnd.ToString().Trim() == "Fresh")
                                    {
                                        cbTccCompLcn.Enabled = false;
                                        trCompQC.Visible = false;
                                        Comp.Attributes.Add("Style", "display:none");
                                        hdnCandTypeRen.Value = strcnd;
                                        lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                                        lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                                    }
                                    else if (strcnd.ToString().Trim() == "Transfer")
                                    {
                                        tbltrndtls.Visible = false;
                                        cbTccCompLcn.Enabled = false;
                                        trCompQC.Visible = false;
                                        Comp.Attributes.Add("Style", "display:none");
                                        hdnCandTypeRen.Value = strcnd;
                                        lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                                        lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                                    }
                                    else
                                    {
                                        trCompQC.Visible = true;
                                        if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "Follower")
                                        {
                                            lblQClyfTraining.Visible = false;
                                            lbltxtQClyfTraining.Visible = false;
                                        }
                                    }
                                    tbloldlic.Visible = true;
                                    divoldlic.Visible = true;
                                    Hashtable htrnwlQc = new Hashtable();
                                    DataSet dsrnwlQC = new DataSet();
                                    htrnwlQc.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                    htrnwlQc.Add("@flag", "1");//fill data 
                                    dsrnwlQC = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htrnwlQc);
                                    lbloldlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                                    lbloldexpdateval.Text = dsrnwlQC.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                                    //hdnoldlicexpdate.Value = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();//shree
                                    lbloldlicissuval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();
                                    tblnewlic.Visible = true;
                                    divnewlic.Visible = true;
                                    lblnewlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                                    htdata.Clear();
                                    ds_documentName.Clear();
                                    htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                    htdata.Add("@flag", "2");//fill new licnexpdate
                                    ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htdata);
                                    if (ds_documentName != null)
                                    {
                                        if (ds_documentName.Tables.Count > 0)
                                        {
                                            if (ds_documentName.Tables[0].Rows.Count > 0)
                                            {
                                                txtnewexpdate.Text = ds_documentName.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                                                txtnewexpdate.Enabled = false;
                                            }
                                        }
                                    }
                                    //btnRnwlSbmit.Visible = true;
                                    //divApprove.Visible = true; 
                                    BtnApprove.Visible = true;
                                    btnSave.Visible = false;
                                    btnReject.Visible = false;
                                    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button start
                                    //btnverifyemail.Enabled = false;
                                    //btnverifyemail.Enabled = false;
                                    //txtMobileNo.Enabled = false;
                                    //txtEMail.Enabled = false;
                                    //Commented by rachana to enable and change mobile,PAN,email and save it on approve button end
                                }
                                else
                                {
                                    if (dsResult.Tables.Count > 0)
                                    {
                                        if (dsResult.Tables[0].Rows.Count > 0)
                                        {
                                            if (strcnd.ToString().Trim() == "Fresh" || strcnd.ToString().Trim() == "Transfer")
                                            {

                                                Comp.Attributes.Add("Style", "display:none");
                                                hdnCandTypeRen.Value = strcnd;
                                                lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                                                lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                                                trlicn.Visible = true;
                                                lblLicnno.Visible = true;
                                                lbllicnoval.Visible = true;
                                                lblLicExpDt.Visible = false;
                                                txtlicno.Visible = false;
                                                txtLicExpDt.Visible = false;
                                                tbltrndtls.Visible = true;
                                                Divoldtrndtls.Attributes.Add("style", "display:block");
                                            }
                                            else
                                            {
                                                Comp.Attributes.Add("Style", "display:block");
                                                hdnCandTypeRen.Value = strcnd;
                                                PopulateRenewalType();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                                                PopulateLifeTraining();//added by shreela on 18/04/2014 for binding RenewalType dropdown
                                            }
                                        }
                                    }
                                    if (dsren.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                                    {
                                        tbltrndtls.Visible = false;
                                        tbloldlic.Visible = true;
                                        divoldlic.Visible = true;
                                        Hashtable htrnwlQc = new Hashtable();
                                        DataSet dsrnwlQC = new DataSet();
                                        htrnwlQc.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                        htrnwlQc.Add("@flag", "1");//fill data 
                                        dsrnwlQC = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htrnwlQc);
                                        lbloldlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                                        lbloldexpdateval.Text = dsrnwlQC.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                                        //hdnoldlicexpdate.Value = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();//shree
                                        lbloldlicissuval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();
                                        tblnewlic.Visible = true;
                                        divnewlic.Visible = true;
                                        lblnewlicnoval.Text = dsrnwlQC.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                                        htdata.Clear();
                                        ds_documentName.Clear();
                                        htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                        htdata.Add("@flag", "2");//fill new licnexpdate
                                        ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htdata);
                                        if (ds_documentName != null)
                                        {
                                            if (ds_documentName.Tables.Count > 0)
                                            {
                                                if (ds_documentName.Tables[0].Rows.Count > 0)
                                                {
                                                    txtnewexpdate.Text = ds_documentName.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                                                    txtnewexpdate.Enabled = false;
                                                }
                                            }
                                        }
                                    }
                                }

                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                divAgnPhotoTrnExmDtl.Visible = false;
                                //tbltrndtls.Visible = true;
                                tbloldexm.Visible = false;
                                if (dsren.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                                {
                                    tbltrn.Visible = false;
                                }
                                else
                                {
                                    tbltrn.Visible = true;
                                }
                                trnsfrtitle.Visible = false;
                                divTrnsferDetails.Visible = false;//shreela 02/06/2014
                                lblpandetail.Visible = false;
                                Chkpan.Visible = false;
                                chkCompAgnt.Enabled = false;

                            }
                            #endregion
                            //Added by kalyani to fetch Renewal record on QC module end
                            #region RE-Exam QC
                            Hashtable htrexm = new Hashtable();
                            htrexm.Clear();
                            DataSet dsReExm = new DataSet();
                            dsReExm.Clear();
                            htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
                            ViewState["ReExmType"] = dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
                            ViewState["ReExamFlag"] = dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
                            //added by pranjali on 29-04-2014
                            if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")     //Reexam QC //added by pranjali on 28-04-2014
                            {
                                PopulateFees();//added by by rachana
                                tblNexam.Visible = false;//added by pranjali on 28-04-2014
                                //Commented by rachana to enable and change mobile,PAN,email and save it on approve button start
                                //txtMobileNo.Enabled = false;//added by pranjali on 28-04-2014
                                //btnverifymobile.Enabled = false;//added by pranjali on 28-04-2014
                                //txtEMail.Enabled = false;//added by pranjali on 28-04-2014
                                //btnverifyemail.Enabled = false;//added by pranjali on 28-04-2014
                                //Commented by rachana to enable and change mobile,PAN,email and save it on approve button end
                                tbltrn.Visible = false;
                                tbltrndtls.Visible = true;
                                tblExmSchedule.Visible = true;
                                tblPrefExm.Visible = false;
                                //BindFeesDetails();
                                lblReqStatus.Visible = false;//Added by kalyani on 16-05-14 to hide RequsetStatus
                                lblReqStatusValue.Visible = false;//Added by kalyani on 16-05-14 to hide RequsetStatus
                                trnsfrtitle.Visible = false;
                                divTrnsferDetails.Visible = false;
                                CompositeTitle.Visible = false;
                                divCompositeDetails.Visible = false;
                                trIsPriorAgt.Visible = false;
                                if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                                {

                                }
                                else
                                {
                                    GetTokenNoforDisplay();
                                }
                                Divtrndtls.Attributes.Add("Style", "display:none");
                            }
                            else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")   //Reexam QC //added by pranjali on 28-04-2014
                            {
                                PopulateFees();
                                tbltrn.Visible = true;//added by pranjali on 28-04-2014
                                //Commented by rachana to enable and change mobile,PAN,email and save it on approve button start
                                //txtMobileNo.Enabled = false;//added by pranjali on 28-04-2014
                                //btnverifymobile.Enabled = false;//added by pranjali on 28-04-2014
                                //txtEMail.Enabled = false;//added by pranjali on 28-04-2014
                                //btnverifyemail.Enabled = false;//added by pranjali on 28-04-2014
                                //Commented by rachana to enable and change mobile,PAN,email and save it on approve button end
                                tblNexam.Visible = false;//added by pranjali on 28-04-2014
                                tblNExmTitle.Visible = false;
                                tblEmsdtls.Visible = true;
                                tblexam.Visible = true;
                                tbltrndtls.Visible = false;
                                lblExamTitle.Text = "Exam Details";
                                trnsfrtitle.Visible = false;
                                divTrnsferDetails.Visible = false;
                                CompositeTitle.Visible = false;
                                divCompositeDetails.Visible = false;
                                trIsPriorAgt.Visible = false;
                                if (ViewState["strICMEnable"].ToString() == "NO")//no ICM
                                {

                                }
                            #endregion
                            }
                            BindLabelsForCfr();//Added by pranjali on 25022014 for displaying the cfrs raised 
                            //added by pranjali on 29-04-2014
                            //trnsfrtitle.Visible = false;
                            //divTrnsferDetails.Visible = false;
                            //CompositeTitle.Visible = false;
                            //divCompositeDetails.Visible = false;
                            //trIsPriorAgt.Visible = false;
                            btnCancel.Visible = true;//added by shreela on 14/07/2014
                            btnClear.Visible = false;//added by shreela on 14/07/2014
                            //Btncrop.Visible = true;//added by shreela on 08/05/2014
                            // }
                            Btncrop.Visible = false;
                        }
                        #endregion
                        #region EDIT Raise CFR for branched USER
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 end
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "R")
                        {
                            trTokenwithFees.Visible = false;
                            tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            btnverifymobile.Enabled = false;
                            btnverifyemail.Enabled = false;
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;


                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = true;
                            //tblcol.Visible = true;
                            trnsfrtitle.Visible = true;
                            divTrnsferDetails.Visible = true;
                            CompositeTitle.Visible = true;
                            divCompositeDetails.Visible = true;
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
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
                                tblEmsdtls.Visible = true;
                                tblexam.Visible = true;
                                tbltrn.Visible = true;
                            }
                            // tblAdv.Visible = false;
                            //Show Exam DEtails

                            lblExamTitle.Text = "Exam Details";

                            GetRenewalDtls();
                            GetReExamDtls();
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
                            if (ViewState["RenewalFlag"].ToString().Trim() == "Y")
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                trnsfrtitle.Visible = false;
                                divTrnsferDetails.Visible = false;
                                chkCompAgnt.Enabled = false;
                            }
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014

                        }
                        #endregion
                        #region QC with Raise CFR for Licensed User
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            trTokenwithFees.Visible = false;
                            tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            btnverifymobile.Enabled = false;
                            btnverifyemail.Enabled = false;
                            txtMobileNo.Enabled = false;
                            txtEMail.Enabled = false;

                            div1.Attributes.Add("Style", "display:none");
                            div2.Attributes.Add("Style", "display:none");
                            pnlcfrdtls.Attributes.Add("Style", "display:none");


                            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                            tblEmsdtls.Visible = false;
                            //txtFeesRcvd.Attributes.Add("Style", "display:none");
                            //btnGetFeeDetails.Visible = false;//hide for edit, QC part
                            //divtransfer.Visible = false;
                            //tblcol.Visible = false;
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }
                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Candidate Verification";
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            lblTitle.Text = "Online Candidate Verification";
                            lblCndName.Text = "Candidate Name";
                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;

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
                            btnprev.Enabled = false;
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
                            Chkpan.Enabled = false;//disabled only on QC page
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
                            txtMobileNo.Enabled = true;
                            btnverifymobile.Enabled = true;
                            txtEMail.Enabled = true;
                            btnverifyemail.Enabled = true;
                            txtPAN.Enabled = true;
                            btnVerifyPAN.Enabled = true;
                            trnsfrtitle.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:block");
                            CompositeTitle.Visible = true;
                            divCompositeDetails.Attributes.Add("Style", "display:block");
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                        }
                        #endregion
                        #region QC with Responded CFR for Licensed User
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes")
                        {
                            trTokenwithFees.Visible = false;
                            tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            btnverifymobile.Enabled = false;
                            btnverifyemail.Enabled = false;
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
                            divCompositeDetails.Visible = false;
                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }

                            //ddlTrnMode.Items.Insert(0, "Online");
                            //ddlTrnMode.Enabled = false;
                            this.Page.Title = "Online Candidate Verification";
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            lblTitle.Text = "Online Candidate Verification";
                            lblCndName.Text = "Candidate Name";


                            //divApprove.Visible = true; 
                            BtnApprove.Visible = true;
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
                            btnprev.Enabled = false;
                            BindInboxGrid();
                            BindLabels();
                            BindRemarks();
                            tblCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            btnSubmit.Visible = false;
                            Chkpan.Enabled = false;//disabled only on QC page
                            trnsfrtitle.Visible = false;
                            divTrnsferDetails.Visible = false;
                            CompositeTitle.Visible = false;
                            divCompositeDetails.Visible = false;
                            btnCloseCfr.Visible = true;
                            trRespond.Visible = true;
                            BindLabelsForCfr();
                            //manual fees details entry not needed while raise cfr
                            tblICMManual.Visible = false;
                            divICM.Attributes.Add("Style", "display:none");
                            FeesRow.Visible = false;
                            GetRenewalDtls();
                            if (ViewState["RenewalFlag"].ToString().Trim() == "Y")
                            {
                                tblexam.Visible = false;
                                tblEmsdtls.Visible = false;
                                chkCompAgnt.Enabled = false;
                            }
                            btnCancel.Visible = true;//added by shreela on 15/07/2014
                            btnClear.Visible = false;//added by shreela on 15/07/2014
                            GetCandidateType();
                            if (strCndType == "T")
                            {
                                tblexam.Visible = false;
                                tblEmsdtls.Visible = false;
                            }
                        }
                        #endregion

                        //added by pranjali -----start
                        #region Renewal section
                        //added by shreela for renewal start
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")//&& Request.QueryString["Type"].ToString().Trim() == "N")
                        {
                            #region ICM related
                            PopulateICMStatus();
                            PopulateICMPaymentMode();
                            #endregion
                            trTokenwithFees.Visible = false;
                            tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            Divtrndtls.Attributes.Add("Style", "display:none");
                            Code = Request.QueryString["Code"].ToString();
                            tblRenewalCollapse.Visible = true;
                            divRenewal.Visible = true;
                            trIsPriorAgt.Visible = false;
                            btnSubmit.Visible = true;
                            Comp.Visible = true;

                            lblReqStatus.Visible = false;
                            lblReqStatusValue.Visible = false;
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
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
                            lblTitle.Text = "Renewal Request";
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
                            //htdata.Add("@CndNo", hdnCndNo.Value);
                            //drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htdata);
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
                            tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            btnCloseCfr.Visible = false;
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            SetInitialRow();
                            //BindFeesDetails();
                            lblpandetail.Visible = false;
                            Chkpan.Visible = false;//added by shreela 
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
                            tblIcmColl.Visible = false;
                            DivICMDtls.Attributes.Add("Style", "display:none");
                            #endregion
                            Code = Request.QueryString["Code"].ToString();
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            FreezTrnInstLoc();
                            lblReqStatus.Visible = false;
                            lblReqStatusValue.Visible = false;
                            lblpandetail.Visible = false;//added by pranjali on 29-04-2014
                            Chkpan.Visible = false;//added by pranjali on 29-04-2014
                            ddlExam.SelectedValue = "1";
                            //ddlExam.Enabled = false;
                            Panelphoto2.Visible = false;
                            divnavigate.Visible = false;
                            tblexam.Visible = false;
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trTCCase.Visible = true;

                            //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section start
                            lblTitle.Text = "Re-Exam Request";
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
                            htdata.Add("@CndNo", hdnCndNo.Value);
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
                            htdata.Add("@CndNo", hdnCndNo.Value);
                            drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                            tbltrn.Visible = true;
                            ddlTrnMode.Enabled = true;
                            tblCFRInbox.Visible = false;
                            tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            btnCloseCfr.Visible = false;
                            //btnGetFeeDetails.Attributes.Add("onClick", "Javascript: return funFeesCheck();");
                            btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                            SetInitialRow();
                            // BindFeesDetails();
                            txtMobileNo.Enabled = false;
                            btnverifymobile.Enabled = false;
                            txtEMail.Enabled = false;
                            btnverifyemail.Enabled = false;//added by pranjali on 28-04-2014
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
                        }
                        #endregion
                        //Ad//ded by shreela on 20-03-14 for ReExam end



                        //btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExamCentre');return false;");
                        BtnCFR.Attributes.Add("onclick", "funcShowPopup('RaiseCFR');return false;");

                        btnVerifyPAN.Attributes.Add("onclick", "Javascript:return ValidationPAN();");
                        btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExmCentre');return false;");
                        btnNExmCenter.Attributes.Add("onclick", "funcShowPopup('NExmCentre');return false;");
                        Btncrop.Attributes.Add("onclick", "funcopencrop1();return false");//added by shreela on 08/05/2014 fro croping
                    }

                    #region NEW REQUEST
                    if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                    {

                        trTokenwithFees.Visible = false;
                        tblIcmColl.Visible = false;
                        DivICMDtls.Attributes.Add("Style", "display:none");
                        Divtrndtls.Attributes.Add("Style", "display:none");
                        Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                        lblCndView.Visible = false; //Added by rachana on 07032014
                        //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section start
                        lblTitle.Text = "Sponsorship Request";

                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        CompositeTitle.Visible = false;
                        divCompositeDetails.Visible = false;
                        Bindgridview();
                        //Filluploadedfile();

                        //Added by pranjali on 11/01/2014 for UPLOAD/REUPLOAD Section end
                        ddlExmBody.Enabled = true;
                        ddlpreeamlng.Enabled = true;
                        lblSponsorDt.Text = "Requested Date";
                        drResult = null;
                        //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' Start
                        htdata.Clear();
                        htdata.Add("@CndNo", hdnCndNo.Value);
                        drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_Get50HrsNewReqSubmit", htdata);
                        //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' End
                        if (drResult.HasRows)
                        {
                            //PANUpload.Enabled = true;
                        }

                        tbltrn.Visible = false;
                        //tblAdv.Visible = false;
                        //added by rachan on 04062014
                        GetCandidateType();
                        if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T"))
                        {
                            tblEmsdtls.Visible = false;
                            tblexam.Visible = false; //added by pranjali on 10-04-2014
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trIsPriorAgt.Visible = false;
                        }
                        else if (IsPriorAgt == "1")
                        {
                            tblEmsdtls.Visible = false;
                            tblexam.Visible = false; //added by pranjali on 10-04-2014
                            Divoldtrndtls.Attributes.Add("Style", "display:none");
                            trIsPriorAgt.Visible = false;
                        }
                        else
                        {
                            tblexam.Visible = true;
                        }
                        //added by rachan on 04062014
                        divAgnPhotoTrnExmDtl.Visible = true;//Added by pranjali on 10-04-2014
                        tblCFRInbox.Visible = false;
                        tblCFRInboxCollapse.Visible = false;//Added by rachana on 1302014
                        divCFRInbox.Attributes.Add("Style", "display:none");
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
                #endregion
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
            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
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
            tblIcmColl.Visible = false;
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
        htToken.Add("@AppNo", lblAppNoValue.Text);
        htToken.Add("@CndNo", lblCndNoValue.Text);
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


        dsToken = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTokenNoForSync", htToken);

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
        htRuleCode.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        strRulecode = dataAccessRecruit.execute_sprc_with_output("Prc_GetFeesForRNWLCnd", htRuleCode, "@Strout");

        Hashtable htLatestFees = new Hashtable();
        htLatestFees.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
        htRe.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsRe = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htRe);
        //viewstate for inserting fees details
        ViewState["RenewalFlag"] = dsRe.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
        ViewState["RnwlQCFlag"] = dsRe.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim();
    }

    private void GetReExamDtls()
    {
        Hashtable htReExam = new Hashtable();
        DataSet dsReExam = new DataSet();
        htReExam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsReExam = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htReExam);
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
        httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
        strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();
        IsPriorAgt = dscandtype.Tables[0].Rows[0]["IsPriorAgt"].ToString();
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
            //dtReadComp = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetCompositeInsurerName");
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
        //Added by pranjali to fill File upload grid start

        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
            Hashtable htparam = new Hashtable();
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            //added by pranjali on 11-04-2014 start
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                //htparam.Add("@RenwlFlag", "N");
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
                //htparam.Add("@RenwlFlag", "N");
                htparam.Add("@InsurerType", "");
                //htparam.Add("@ReExmFlag", "Y");
                htparam.Add("@ProcessType", "RE");
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                //htparam.Add("@RenwlFlag", "Y");
                htparam.Add("@InsurerType", "");
                //htparam.Add("@ReExmFlag", "N");
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
            //added by pranjali on 11-04-2014 end
            //ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam);//commented by pranjali on 11-04-2014 
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam); //added by pranjali on 19-05-2014
            //added by pranjali on 14-03-2014 start

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
            string CurCndNo = Request.QueryString["CndNo"].ToString().Trim();
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
            htfeesDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
            dsfeesDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetFeesDetailsforCnd", htfeesDtls);

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
                    //else//QC only view
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
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htParam); //added by pranjali to check open cfr
        //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("Prc_GetCFRDetailsQualCheck", htParam, "INSCRecruitConnectionString");
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
                        GetCandidateType();
                        if ((IsPriorAgt == "1" && strCndType == "C") || (strCndType == "T"))
                        {
                            tbltrn.Visible = false;
                        }
                        else
                        {
                            tbltrn.Visible = true;
                        }
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
            htParam.Add("@CndNo", strCndNo);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetURNExistorExist", htParam);

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
            htdata.Add("@CndNo", Convert.ToString(hdnCndNo.Value).Trim());
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
                    htdata.Add("@CndNo", Convert.ToString(hdnCndNo.Value).Trim());
                    drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_chkURNExistorNot", htdata);
                    //Added by Ibrahim on 05-07-2013 ,  To Get 50 Hrs Req Submit for Candidate who's QueryString ["Type"]= 'N' End

                    while (drResult.Read())
                    {
                        if (Convert.ToString(drResult["IRDASponsorDt"]).Trim() != "")
                        {
                            if ((DateTime.Parse(Convert.ToString(drResult["IRDASponsorDt"]).Trim()).AddDays(305) <= System.DateTime.Now.Date) && (DateTime.Parse(Convert.ToString(drResult["IRDASponsorDt"]).Trim()).AddDays(365) >= System.DateTime.Now.Date))
                            {
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
            if (lblReqStatusValue.Text.Trim().ToUpper() == "COMPLETED")
            {

                if (hdnSDate.Value != null && hdnSDate.Value != "")
                {
                    if (DateTime.Parse(hdnSDate.Value) < DateTime.Parse("01/10/2011"))
                    {
                        ddlExmTpe.SelectedValue = "REXM";
                        ddlExmTpe.Enabled = false;
                        //commented by pranjali on 02-01-2014 start
                        //AgnPhotoUpload.Enabled = false;
                        //AgnSignUpload.Enabled = false;
                        //PANUpload.Enabled = false;
                        //commented by pranjali on 02-01-2014 end
                        return;
                    }

                    if (DateTime.Parse(hdnSDate.Value).AddDays(180) >= System.DateTime.Now)
                    {
                        RegisterStartupScript("startupScript", "<script language=JavaScript>alert('TCC valid for 180 days.Raise New training request after 180 days From Training Start Date.');</script>");
                        lblMessage.Text = "TCC valid for 180 days.Raise New training request after 180 days From Training Start Date.";
                        lblMessage.Visible = true;
                        btnSubmit.Enabled = false;
                        return;
                    }
                }
            }
            if (chkExmResult() == true)
            {
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
        txtExmCentre.Enabled = false;
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

            lblTitle.Text = olng.GetItemDesc("lblTitle");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            //lblCscCode.Text = olng.GetItemDesc("lblCscCode");
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            //lblBranchCode.Text = olng.GetItemDesc("lblBranchCode"); commented by pranjali on 27-12-2013
            lblBranch.Text = olng.GetItemDesc("lblBranch");
            //lblSalesUnitCode.Text = olng.GetItemDesc("lblSalesUnitCode");commented by pranjali on 27-12-2013
            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblCnddtls.Text = olng.GetItemDesc("lblCnddtls");//Added by shreela on 10/03/14
            lblcndupload.Text = olng.GetItemDesc("lblcndupload");//Added by shreela on 11/03/14
            //lblExmType.Text = olng.GetItemDesc("lblExmType");
            //lblTitle_AdvDtl.Text = olng.GetItemDesc("lblTitle_AdvDtl");//Added for training Type
            lblHrnTrn.Text = olng.GetItemDesc("lblHrnTrn");
            lblReqStatus.Text = olng.GetItemDesc("lblReqStatus");
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
        htParam.Add("@CndNo", strCndNo);
        htParam.Add("@AppNo", System.DBNull.Value);
        htParam.Add("@ReqDate", System.DBNull.Value);
        htParam.Add("@BranchCode", System.DBNull.Value);
        htParam.Add("@AdvName", System.DBNull.Value);
        htParam.Add("@Type", Request.QueryString["Type"].ToString().Trim());

        try
        {
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvForHrsTrn", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        hdnBizSrc.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
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
                        lblReqStatusValue.Text = dsResult.Tables[0].Rows[0]["Status"].ToString().Trim();
                        ddlExmTpe.SelectedValue = dsResult.Tables[0].Rows[0]["ExamType"].ToString().Trim();
                        lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString()).Trim();
                        //Added by pranjali on 07-02-2014 for pan check checkbox start
                        if (dsResult.Tables[0].Rows[0]["IsPanFlag"].ToString() == "1")
                        {
                            Chkpan.Checked = true;
                            Chkpan.Enabled = false;
                        }
                        else
                        {
                            Chkpan.Checked = false;
                            //Chkpan.Enabled = false;
                        }
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
        htParam.Add("@CndNo", strCndNo);
        htParam.Add("@AppNo", System.DBNull.Value);
        htParam.Add("@ReqDate", System.DBNull.Value);
        htParam.Add("@BranchCode", System.DBNull.Value);
        htParam.Add("@AdvName", System.DBNull.Value);

        #region for Edit PAN Details
        if (Request.QueryString["PANFlag"] != null)
        {
            if (Request.QueryString["PANFlag"].ToString().Trim() == "Y")
            {
                htParam.Add("@Type", "P");
            }
        }

        else
        {
            htParam.Add("@Type", Request.QueryString["Type"].ToString().Trim());
        }
        #endregion for Edit PAN Details

        try
        {

            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvForHrsTrn", htParam);

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
                        ViewState["ReExamFlag"] = dsResult.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
                        ViewState["TCCFlag"] = dsResult.Tables[0].Rows[0]["TCCFlag"].ToString().Trim();
                        //For Leader and RenewalType=Yes
                        ViewState["RenewalType"] = dsResult.Tables[0].Rows[0]["RenewalType"].ToString().Trim();
                        hdnPanDtls.Value = dsResult.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();//Added by pranjali on 14-03-2014
                        hdnBizSrc.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                        lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        //Added by pranjali on 27-12-2013 start
                        string branchname;
                        branchname = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();
                        string cmsunitcode;
                        cmsunitcode = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString().Trim();
                        string branch = branchname + "(" + cmsunitcode + ")";
                        lblBranchValue.Text = branch;
                        hdnBranchCode.Value = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim(); //added by pranjali on 31-12-2013
                        //Added by pranjali on 27-12-2013 end                        
                        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["SMName"].ToString().Trim();
                        lblReqStatusValue.Text = dsResult.Tables[0].Rows[0]["Status"].ToString().Trim();
                        //Added by pranjali on 07-02-2014 for pan check checkbox start
                        //Added by shreela on 8/04/2014 start
                        lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim(); //Added by kalyani on 23-04-14 for cand_type description
                        //added by shreela on 22/05/2014 start

                        lblcndURNVal.Text = dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim();//added by shreela on 3/07/2014
                        //Lcndt = Convert.ToDateTime(dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim());

                        //if (Convert.ToString(Lcndt) != "")
                        //{
                        //    int dateLcnExp = Lcndt.Year;
                        //    int todaysdate = DateTime.Now.Year;
                        //    if (dateLcnExp < todaysdate)
                        //    {

                        //       GetTotalFeesBasedOnLcnExpDate();
                        //    }
                        //    else if (dateLcnExp == todaysdate)
                        //    {
                        //        int lcnexpdayemonth = Lcndt.Month;
                        //        int todaysdatemonth = DateTime.Now.Month;
                        //        if (lcnexpdayemonth <= todaysdatemonth)
                        //        {

                        //            int lcnexpdayeDay1 = Lcndt.Day;
                        //            int todaysdateDay1 = DateTime.Now.Day;
                        //            if (lcnexpdayeDay1 < todaysdateDay1)
                        //            {
                        //                GetTotalFeesBasedOnLcnExpDate();
                        //                BindFeesDetails();
                        //            }


                        //        }
                        //        else if (lcnexpdayemonth > todaysdatemonth)
                        //        {
                        //           // GetTotalFeesBasedOnLcnExpDate();
                        //            int lcnexpdayeDay = Lcndt.Day;
                        //            int todaysdateDay = DateTime.Now.Day;
                        //            if (lcnexpdayeDay < todaysdateDay)
                        //            {
                        //                GetTotalFeesBasedOnLcnExpDate();

                        //            }

                        //        }
                        //        else //if (lcnexpdayemonth == todaysdatemonth)
                        //        {
                        //            GetTotalFeesBasedOnLcnExpDate();
                        //        } 
                        //    }
                        //}
                        if (Request.QueryString["Type"].ToString().Trim() == "Qc")
                        {
                            lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                        }
                        else
                        {
                            hdnRenwlCnt.Value = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                            hdnRenwl.Value = (Convert.ToInt32(hdnRenwlCnt.Value) + 1).ToString().Trim();
                            lblCountVal.Text = hdnRenwl.Value;
                        }
                        //added by shreela on 22/05/2014 end
                        //added by shreela on 8/04/2014 end
                        if (dsResult.Tables[0].Rows[0]["IsPanFlag"].ToString() == "1")
                        {
                            Chkpan.Checked = true;
                            Chkpan.Enabled = false;
                        }
                        else
                        {
                            Chkpan.Checked = false;

                        }
                        //Added by rachana on 11/04/2014 for fees details start
                        if (dsResult.Tables[0].Rows[0]["WaiverFlag"].ToString().Trim() != null)
                        {
                            hdnWebTknCon.Value = dsResult.Tables[0].Rows[0]["WaiverFlag"].ToString().Trim();
                        }
                        else
                        {
                            hdnWebTknCon.Value = "";
                        }
                        //Added by rachana on 11/04/2014 for fees details end
                        //Added by pranjali on 07-02-2014 for pan check checkbox end
                        if (Request.QueryString["Type"].ToString().Trim().ToUpper() != "N")
                        {
                            lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString()).Trim();
                        }
                        else
                        {
                            lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"].ToString()).Trim();
                        }
                        txtMobileNo.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();

                        txtEMail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();

                        #region shree07
                        //if (Request.QueryString["Type"].Trim() == "Renwl")
                        //{
                        //    txtMobileNo.Enabled = false;
                        //    btnverifymobile.Enabled = false;
                        //    txtEMail.Enabled = false;
                        //    btnverifyemail.Enabled = false;

                        //}
                        #endregion

                        //added by shreela
                        txtlicno.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                        txtLicExpDt.Text = dsResult.Tables[0].Rows[0]["LicExpDate"].ToString().Trim();
                        lbllicnoval.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                        //added by shreela
                        #region transfer/composite details fill
                        //Added by rachana for showing Candidate transfer/composite details start
                        if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnsfrFlag"]).Trim() != "")
                            {
                                if ((dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "1") || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True")
                                {
                                    trnsfrtitle.Visible = true;
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
                                            //txtOldTccLcnExpDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                            txtissudate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
                                        }
                                    }
                                }

                                else
                                {
                                    cbTrfrFlag.Checked = false;
                                    divTrnsferDetails.Visible = false;
                                    //trnsfrtitle.Visible = false;
                                }
                            }
                        }

                        if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True" || dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString() == "True")
                        {
                            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                            {
                                tblCndURN.Visible = false;
                            }
                            else
                            {
                                if (dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim() != "")
                                {
                                    tblCndURN.Visible = true;
                                    txtCndURNNo.Text = dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim();
                                }
                                else
                                {
                                    tblCndURN.Visible = true;
                                    lblcndURNNo.Visible = true;
                                    txtCndURNNo.Visible = true;
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString().Trim() == "1" || dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "True")
                        {
                            if (dsResult.Tables[0].Rows[0]["IRDATrnsfrReqNo"].ToString().Trim() != "")
                            {
                                tblCndURN.Visible = true;
                                TxtTrnsfrReqNo.Text = dsResult.Tables[0].Rows[0]["IRDATrnsfrReqNo"].ToString().Trim();
                                TxtTrnsfrReqNo.Visible = true;
                                lblTrnsfrReqNo.Visible = true;
                            }
                            else
                            {
                                TxtTrnsfrReqNo.Visible = false;
                                lblTrnsfrReqNo.Visible = false;
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
                                    divCompositeDetails.Visible = true;
                                    CompositeTitle.Visible = true;
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
                                    //CompositeTitle.Visible = false;
                                    cbTccCompLcn.Checked = false;
                                    divCompositeDetails.Visible = false;
                                }
                            }
                        }
                        //txtTccPrevInsurerName.Text = dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"].ToString().Trim();
                        //added by pranjali on 28-03-2014 start
                        if (dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                        {
                            trIsPriorAgt.Visible = true;
                            chkCompAgnt.Checked = true;
                            tblEmsdtls.Visible = false;
                            tblexam.Visible = false;
                        }
                        else
                        {
                            trIsPriorAgt.Visible = true;
                            chkCompAgnt.Checked = false;
                        }
                        //added by pranjali on 28-03-2014 end
                        if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() == "1")
                        {
                            RbtNoc.SelectedIndex = 0;
                        }
                        else
                        {
                            RbtNoc.SelectedIndex = 1;
                        }
                        if (dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() == "F")
                        {
                            RbAckRev.SelectedIndex = 0;
                        }
                        else
                        {
                            RbAckRev.SelectedIndex = 1;
                        }
                        //Added by rachana for showing Candidate transfer/composite details end
                        #endregion
                        //added by pranjali on 11-04-2014 start
                        //if (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "E" || Request.QueryString["Type"].ToString().Trim() == "ReTrn")//added by pranjali on 28-04-2014
                        if (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "QcRes" || Request.QueryString["Type"].ToString().Trim() == "R" || Request.QueryString["Type"].ToString().Trim() == "E" || Request.QueryString["Type"].ToString().Trim() == "ReTrn")//added by pranjali on 28-04-2014
                        {
                            ddlExam.SelectedValue = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();

                            ddlExmBody.SelectedValue = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();

                            ddlpreeamlng.SelectedValue = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                            txtExmCentre.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                            //ddlExmCentre.SelectedValue = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();

                            //Added by rachana on 04-06-2014 start
                            GetCandidateType();
                            if ((IsPriorAgt == "1") || (strCndType == "T"))
                            {
                                tblEmsdtls.Visible = false;
                                tblexam.Visible = false;
                                Divoldtrndtls.Attributes.Add("Style", "display:none");
                                tbltrn.Visible = false;
                                ddlExam.Enabled = false;
                                ddlExmBody.Enabled = false;
                                ddlpreeamlng.Enabled = false;
                                //ddlExmCentre.Enabled = false;
                                txtExmCentre.Enabled = false;
                            }
                            else
                            {
                                tblEmsdtls.Visible = true;
                                tblexam.Visible = true;
                                tbltrn.Visible = true;
                                ddlNExam.Enabled = true;
                                ddlNExmBody.Enabled = true;
                                ddlNpreeamlng.Enabled = true;
                                //ddlNExmCenter.Enabled = true;
                                txtNExmCenter.Enabled = true;
                            }
                            //Added by rachana on 04-06-2014 end
                            Hashtable htren = new Hashtable();
                            htren.Clear();
                            DataSet dsren = new DataSet();
                            dsren.Clear();
                            htren.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htren);
                            if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")//Renewal QC
                            {
                                if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                                {
                                    txtExm.Text = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();
                                }
                                if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                                {
                                    txtBody.Text = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();
                                }
                                if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                                {
                                    txtLang.Text = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                                }
                                if (dsResult.Tables[0].Rows[0]["ExmMode"].ToString() != "")
                                {
                                    textoldexmcenter.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                                }
                                htdata.Clear();
                                ds_documentName.Clear();
                                htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTrnDtls", htdata);
                                if (ds_documentName.Tables[0].Rows.Count > 0)
                                {
                                    if (ds_documentName.Tables[0].Rows[0]["TrnInstDesc01"].ToString() != "")
                                    {
                                        lblTrnInstituteValue.Text = ds_documentName.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                                    }
                                    if (ds_documentName.Tables[0].Rows[0]["TrainingLoc"].ToString() != "")
                                    {
                                        lblTrnLocValue.Text = ds_documentName.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                                    }
                                    if (ds_documentName.Tables[0].Rows[0]["TrnMode"].ToString() != "")
                                    {
                                        lblTrnModeValue.Text = ds_documentName.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                                    }
                                    if (ds_documentName.Tables[0].Rows[0]["AccrdNo"].ToString() != "")
                                    {
                                        lblAccvalue1.Text = ds_documentName.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                                    }
                                    if (ds_documentName.Tables[0].Rows[0]["HrsTrn"].ToString() != "")
                                    {
                                        lblTrnHrsValue1.Text = ds_documentName.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                                    }
                                }
                            }
                        }
                        Hashtable htrexm = new Hashtable();
                        htrexm.Clear();
                        DataSet dsReExm = new DataSet();
                        dsReExm.Clear();
                        htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
                        if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                        {
                            lblTrnInstituteValue.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                            lblTrnLocValue.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                            lblTrnModeValue.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                            lblAccvalue1.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                            lblTrnHrsValue1.Text = dsResult.Tables[0].Rows[0]["ParamDesc01"].ToString().Trim();
                            if (dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")
                            {
                                lblNWExmdtValue.Text = dsResult.Tables[0].Rows[0]["SystemExmDt"].ToString().Trim();
                                lblpref1value.Text = dsResult.Tables[0].Rows[0]["PrefferedExmDt1"].ToString().Trim();
                                //if (dsResult.Tables[0].Rows[0]["PrefferedExmDt2"].ToString().Trim() == "")
                                //{
                                //}
                                //else
                                //{
                                //    lblpref2value.Text = dsResult.Tables[0].Rows[0]["PrefferedExmDt2"].ToString().Trim();
                                //    lblprefformat2.Visible = true;
                                //}
                            }
                            ddlNExmBody.Items.Insert(0, "--Select--");
                            ddlNpreeamlng.Items.Insert(0, "--Select--");
                            //ddlNExmCenter.Items.Insert(0, "--Select--");
                        }
                        //added by pranjali on 11-04-2014 end
                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim() != "")
                        {
                            txtPAN.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                            //txtPAN.Enabled = false;
                            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                            {

                            }
                        }
                        else
                        {
                            //htParam.Clear();
                            //DataSet dsPanUpdate = new DataSet();
                            //DataAccessClass objDAL = new DataAccessClass();
                            //htParam.Add("@CndNo", dsResult.Tables[0].Rows[0]["cndno"].ToString());
                            //dsPanUpdate = objDAL.GetDataSetForPrc ("prc_GetRejectPanUpdate", htParam);

                            //if (dsPanUpdate.Tables[0].Rows.Count > 0)
                            //{
                            //    if (Convert.ToString(dsPanUpdate.Tables[0].Rows[0]["Flag"]) == "Y")
                            //    {
                            //        txtPAN.Enabled = true;
                            //        if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                            //        {

                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (dsPanUpdate.Tables[0].Rows.Count > 0)
                            //        {
                            //            txtPAN.Text = dsPanUpdate.Tables[0].Rows[0]["PAN"].ToString().Trim();
                            //            txtPAN.Enabled = false;

                            //        }
                            //    }
                            //}
                            //if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
                            //{

                            //}                           
                        }


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
                        hdnTrnLocation.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]).Trim();
                        hdnTccID.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["TccID"]);

                        //shreela 26-03-2014 start 
                        if (Request.QueryString["TrnRequest"] != "Renewal" && Request.QueryString["Type"].ToString().Trim() != "Renwl")
                        {
                            //added by shreela on 21042014--start
                            if (Request.QueryString["TrnRequest"].ToString().Trim() != "ReExam" && Request.QueryString["Type"].ToString().Trim() != "ReTrn")
                            {
                                if (dsResult.Tables[0].Rows[0]["RLRS"].ToString().Trim() == "1" && dsResult.Tables[0].Rows[0]["RenFlag"].ToString().Trim() == "")
                                {
                                    btnSubmit.Visible = false;
                                }
                            }
                        }
                        //shreela 26-03-2014 end 
                        //added by pranjali on 03-05-2014 start
                        if (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "R")
                        {
                            //added by shreela on 03052014 to not fill dropdown in renewals
                            Hashtable htren = new Hashtable();//shree03
                            htren.Clear();
                            DataSet dsren = new DataSet();
                            dsren.Clear();
                            htren.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htren);
                            if (dsren.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                            {
                                ddlTrnMode.SelectedValue = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                                PopulateTrainingInst(dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim(), dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                                PopulateTrainingLoc(dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                                if (dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim() == "")
                                {
                                    ddlTrnLoc.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlTrnLoc.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                                }
                                if (dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim() == "")
                                {
                                    ddlTrnInstitute.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlTrnInstitute.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                                    ddlTrnInstitute.SelectedItem.Value = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim();
                                }
                                lblAccrdtnValue.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                                PopulateTrnType();
                                if (dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim() == "")
                                {
                                    //ddlHrsTrn.SelectedIndex = 0;
                                    ddlHrsTrn.ClearSelection();
                                    ddlHrsTrn.Items.Insert(0, "--Select--");
                                }
                                else
                                {
                                    ddlHrsTrn.SelectedValue = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                                }
                                if (dsren.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "")
                                {
                                    ddlRenewType.ClearSelection();
                                    ddlRenewType.Items.Insert(0, "---Select---");
                                    //ddlRenewType.SelectedIndex = -1;
                                }
                                else
                                {
                                    PopulateRenewalType();
                                    ddlRenewType.SelectedValue = dsren.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim();
                                }

                                if (dsren.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim() == "")
                                {
                                    ddlRenewType.ClearSelection();
                                }
                                else
                                {
                                    PopulateLifeTraining();
                                    ddllyfTraining.SelectedValue = dsren.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim();
                                }
                            }
                            else
                            {
                                ddlTrnMode.SelectedValue = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                                PopulateTrainingInst(dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim(), dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                                PopulateTrainingLoc(dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim());
                                if (dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim() == "")
                                {
                                    ddlTrnLoc.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlTrnLoc.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                                }
                                if (dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim() == "")
                                {
                                    ddlTrnInstitute.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlTrnInstitute.SelectedItem.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                                    ddlTrnInstitute.SelectedItem.Value = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString().Trim();
                                }
                                lblAccrdtnValue.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                                PopulateTrnType();
                                if (dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim() == "")
                                {
                                    //ddlHrsTrn.SelectedIndex = 0;
                                    ddlHrsTrn.Items.Insert(0, "--Select--");
                                }
                                else
                                {
                                    ddlHrsTrn.SelectedValue = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                                }
                            }

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
        htfeesDtls1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
        dsfeesDtls1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetFeesDetailsforCnd", htfeesDtls1);

        if (dsfeesDtls1.Tables.Count > 0)
        {

            if (dsfeesDtls1.Tables[0].Rows.Count > 0)//if already exist moves to history table and again insert
            {

                Hashtable htDel = new Hashtable();
                htDel.Add("@AppNo", lblAppNoValue.Text);
                htDel.Add("@CndNo", lblCndNoValue.Text);
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

                    Htfees.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
                    Htfees.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
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
                htDel.Add("@AppNo", lblAppNoValue.Text);
                htDel.Add("@CndNo", lblCndNoValue.Text);
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

                    Htfees.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
                    Htfees.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
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
            htdata.Add("@AppNo", lblAppNoValue.Text.Trim());
            htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
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
            htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
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
        txtExmCentre.Enabled = true;
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
            htdata.Add("@CndNo", Convert.ToString(hdnCndNo.Value).Trim());
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
                if (txtDate.Text.ToString().Trim() != "")//txtOldTccLcnExpDate
                {
                    if ((Convert.ToDateTime(txtDate.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {

                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Transfer should not be past date')", true);
                        return;
                    }
                }
                //Added by pranjali for validation of transfer case end
                //Added by pranjali on 14-03-2014 for validation of composite case start
                if (txtCompLicExpDt.Text.ToString().Trim() != "")//txtOldTccLcnExpDate
                {
                    if ((Convert.ToDateTime(txtCompLicExpDt.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Composite should not be past date')", true);
                        return;
                    }
                }
            }
            //Added by pranjali on 14-03-2014 for validation of composite case end
            Hashtable htparam = new Hashtable();
            if ((Request.QueryString["Type"].ToString().Trim().ToUpper() == "E") || (Request.QueryString["Type"].ToString().Trim().ToUpper() == "R"))
            {
                htparam.Clear();
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
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
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'C');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                {
                    htparam.Add("@CandType", 'F');
                }

            }
            else
            {
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start               
                htparam.Clear();
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                //added by shreela
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
                //added by shreela
                if (ds_candtype.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    htparam.Add("@ProcessType", "RW");
                }
                else if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //htparam.Add("@RenwlFlag", "N");
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    htparam.Add("@ProcessType", "RE");
                }
                //added by shreela on 21042014
                else
                {
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    if (ds_candtype.Tables[0].Rows[0]["IsSPFlag"].ToString().Trim() == "Y")
                    {
                        htparam.Add("@ProcessType", "SP");
                    }
                    else
                    {
                        htparam.Add("@ProcessType", "NR");
                    }
                    //htparam.Add("@ProcessType", "NR");
                }
            }
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam); //added by pranjali on 11-04-2014  start
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
                            if (Chkpan.Checked == true)
                            {
                                string ImgDesc = ds_documentName.Tables[0].Rows[j]["ImgDesc01"].ToString().Trim();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                                return;
                            }
                        }
                        else if (mandtry == "C" && imgshrt == "15")
                        {
                            Hashtable httable = new Hashtable();
                            DataSet ds_panchayat = new DataSet();
                            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_CheckForPanchayat", httable);
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
            Save();
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
        dsetdays = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NoofDaysbasedonCndType", htdays);
        //dsetdays = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NoofDaysbasedonCndType");

        if (dsetdays.Tables.Count > 0)
        {
            if (dsetdays.Tables[0].Rows.Count > 0)
            {
                iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["noofdays"]);
            }
        }
        return iNoOfDays;
    }
    private void SetSysFreezeDate()
    {
        DateTime date;
        DateTime SysFreezedate;
        string strbranchcode = string.Empty;
        string strCndNo = string.Empty;
        Hashtable htSubmitDt = new Hashtable();
        DataSet dset = new DataSet();
        // dset = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploadedDates");
        if (ViewState["ReExmType"].ToString() == "I")
        {
            htSubmitDt.Add("@Flag", 3);
        }
        else
        {
            htSubmitDt.Add("@Flag", 2);
        }


        //QS
        dset = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploadedDates", htSubmitDt);


        if (dset.Tables.Count > 0)
        {
            if (dset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    int iday = GetNoofDaysForReexm();
                    #region to be uncommented on UAT start
                    //SysInrgConsum.GetHolidayConsume objhol = new SysInrgConsum.GetHolidayConsume();

                    //lstworkdays = objhol.GetWorkingdays(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), iNoOfDays);
                    DateTime DtUpld = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                    DtUpld = DtUpld.AddDays(iNoOfDays);
                    #endregion to be uncommented on UAT end
                    strbranchcode = dset.Tables[0].Rows[i]["Branch"].ToString();
                    strCndNo = dset.Tables[0].Rows[i]["CndNo"].ToString();

                    #region synclogentry


                    string strAppno = dset.Tables[0].Rows[i]["AppNo"].ToString();
                    #region to be uncommented on UAT start
                    //string strInput = "<WorkingDaysInput><Branch>" + dset.Tables[0].Rows[i]["Branch"].ToString() + "</Branch><UpdatedDt>" + Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]) + "</UpdatedDt><NoOfdays>" + iNoOfDays + "</NoOfdays></WorkingDays>";
                    //string strOutput = "<WorkingDaysOutput>" + lstworkdays[0] + "</WorkingDaysOutput>";
                    string strInput = "<WorkingDaysInput><Branch>" + dset.Tables[0].Rows[i]["Branch"].ToString() + "</Branch><UpdatedDt>" + Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]) + "</UpdatedDt><NoOfdays>" + iNoOfDays + "</NoOfdays></WorkingDays>";
                    string strOutput = "<WorkingDaysOutput>" + DtUpld + "</WorkingDaysOutput>";
                    #endregion to be uncommented on UAT end
                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);

                    //sync Log entry


                    int g;

                    Hashtable htSync = new Hashtable();
                    htSync.Add("@RefNo", strCndNo);
                    htSync.Add("@AppNo", strAppno);
                    htSync.Add("@XmlInput", strInput);
                    htSync.Add("@CreatedBy", strcallerSystem);
                    htSync.Add("@Xmloutput", strOutput);
                    htSync.Add("@Resdate", System.DateTime.Now);
                    htSync.Add("@Errdesc", "");
                    htSync.Add("@MethodName", method.Name.ToString());
                    g = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSysFreezeDateSyncLog", htSync);

                    #endregion

                    date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                    #region to be uncommented on UAT start
                    #region to be uncommented on UAT start
                    //SysFreezedate = Convert.ToDateTime(lstworkdays[0]);
                    //string strDate = lstworkdays[0].ToString();
                    //SysFreezedate = Convert.ToDateTime(dateString[2].Substring(0, 5) + "-" + dateString[0] + "-" + dateString[1]);
                    string strDate = DtUpld.ToString();
                    string[] dateString = strDate.Split('/');
                    string strdate1 = dateString[2].Substring(0, 5) + "-" + dateString[0] + "-" + dateString[1];
                    //SysFreezedate = Convert.ToDateTime(strDate);
                    #endregion
                    #region to be uncommented on UAT start
                    UpdteDt(strbranchcode, strdate1, strCndNo);
                    //UpdteDt(strbranchcode, strDate, strCndNo);
                    #endregion

                    #endregion


                }
            }
        }
    }

    protected void UpdteDt(string BrnCode, string FreezeDt, string CndNo)
    {
        int f;
        Hashtable htsysemdate = new Hashtable();
        htsysemdate.Clear();
        htsysemdate.Add("@BranchCode", BrnCode);
        htsysemdate.Add("@CndNo", CndNo);
        htsysemdate.Add("@SysFreezeDate", FreezeDt);
        htsysemdate.Add("@Flag", 1);
        f = dataAccessRecruit.execute_sprcrecruit("Prc_UpdSysFreezeDates", htsysemdate);

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
            htParam.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
            htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
            //htParam.Add("@CndName", lblAdvNameValue.Text.ToString().Trim()); //added by pranjali on 31-12-2013
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            //added by pranjali -----start
            DataSet dscandtype = new DataSet();
            Hashtable htcndtyp = new Hashtable();
            htcndtyp.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
            //added by pranjali -----end
            htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
            htParam.Add("@PAN", Convert.ToString(txtPAN.Text).Trim());

            #region audit log
            ArrayList arrLst = new ArrayList();
            arrLst.Add(new prjXml.Collection("NewAppNo", lblAppNoValue.Text.ToString().Trim()));
            arrLst.Add(new prjXml.Collection("CndNo", lblCndNoValue.Text.ToString().Trim()));
            arrLst.Add(new prjXml.Collection("CreatedBy", Session["UserID"].ToString().Trim()));
            //arrLst.Add(new prjXml.Collection("UnitCode", lblBranchCodeValue.Text.ToString().Trim())); //commented by pranjali on 27-12-2013
            arrLst.Add(new prjXml.Collection("ReqType", "HrTrn"));
            arrLst.Add(new prjXml.Collection("PAN", Convert.ToString(txtPAN.Text).Trim()));
            #endregion


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
                        htUrnChk.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
                    if (txtExmCentre.Text != "")
                    {
                        //htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@ExmCentre", System.DBNull.Value);
                    }
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
                    //if (ddlExmCentre.SelectedValue != "")
                    //{
                    //    htParam.Add("@ExmCentre", ddlExmCentre.SelectedValue);
                    //}
                    //else
                    //{
                    //    htParam.Add("@ExmCentre", System.DBNull.Value);
                    //}
                    if (txtExmCentre.Text != "")
                    {
                        //htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                        htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                    }
                    else
                    {
                        htParam.Add("@ExmCentre", System.DBNull.Value);
                    }
                    DataSet dtstcndtyp = new DataSet();
                    Hashtable hscndtyp = new Hashtable();
                    hscndtyp.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dtstcndtyp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", hscndtyp);
                    if (dtstcndtyp.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y" && dtstcndtyp.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                    {
                        DataSet dsDoc = new DataSet();
                        Hashtable htdoc = new Hashtable();
                        dsDoc.Clear();
                        htdoc.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        htdoc.Add("@DocCode", "28");
                        dsDoc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_ChkIRDACloseCFR", htdoc);
                        //if (dsDoc.Tables.Count > 0)
                        //{
                        //FOR LICENSE USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND -- IRDA CFR RAISED
                        if (dsDoc.Tables[0].Rows.Count > 0)
                        {
                            htParam.Add("@MvmtDesc", "QC-IRDA Error");
                            x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdTrnReqForLicUser", htParam);
                        }
                        //FOR LICENSE USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND -- Normal CFR RAISED
                        else
                        {
                            htParam.Add("@MvmtDesc", "QC-LicUserCase");
                            x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdTrnReqForLicUser", htParam);
                        }
                        //}

                    }
                }
                //FOR BRANCH USER UPDATION ON CLICK OF RESPOND BUTTON FOR CFR RESPOND 
                else
                {
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateTrnReqDtl", htParam); //Added by pranjali on 02-01-2014 to update details
                }
                #region for AuditLog
                arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                arrLst.Add(new prjXml.Collection("TccID", Convert.ToString(hdnTccID.Value)));
                prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                XmlDocument xDoc = new XmlDocument();
                xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                strXML = xDoc.OuterXml;
                arrLst.Clear();
                #endregion Auditlog
            }

            //added by pranjali -----start

            #region Renewal submit
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                #region Fresh/Transfer
                htParam.Clear();
                htParam.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
                htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
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
                htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
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
                arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                //arrLst.Add(new prjXml.Collection("WaiverFlag", hdnAdvWaiver.Value));
                arrLst.Add(new prjXml.Collection("WaiverFlag", hdnWebTknCon.Value));
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
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                string ReExm = Request.QueryString["ReExm"].ToString();
                htParam.Add("@ReExmcntValue", ReExm);
                //added by pranjali on 29-04-2014 start for sponsorship link ie. Invalid TCC
                Hashtable htrexm = new Hashtable();
                htrexm.Clear();
                DataSet dsReExm = new DataSet();
                dsReExm.Clear();
                htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
                if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC //added by pranjali on 28-04-2014
                {
                    htParam.Add("@ExamMode", ddlNExam.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmBody", ddlNExmBody.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmLang", ddlNpreeamlng.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmCentre", hdnNExmCenter.Value);


                    dsFees.Clear();
                    dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsReExmDtls", htParam);
                    //MailResponse();

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
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                //added by pranjali on 10-04-2014 for exam details insertion start     

                htParam.Add("@ExamMode", ddlExam.SelectedValue.ToString().Trim());
                htParam.Add("@ExmBody", ddlExmBody.SelectedValue.ToString().Trim());
                htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue.ToString().Trim());
                htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                //htParam.Add("@ExmCentre", ddlExmCentre.SelectedValue.ToString().Trim());

                //added by pranjali on 10-04-2014 for exam details insertion end 
                //Added by rachana on 10/04/2014 for saving fees checked start
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
                //Added by rachana on 10/04/2014 for saving fees checked end



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
                //Inserts fees details for first time sponsorship request
                // InsertfeesDetails();

                #region  AuditLog
                arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                //arrLst.Add(new prjXml.Collection("WaiverFlag", hdnAdvWaiver.Value));
                arrLst.Add(new prjXml.Collection("WaiverFlag", hdnWebTknCon.Value));
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

                //for ECRM pan Updation
                drResult = null;
                //Added By  Ibrahim on 05-07-2013 To Get ECRM pan Updation Start
                htdata.Clear();
                htdata.Add("@CndNo", Convert.ToString(hdnCndNo.Value).Trim());
                drResult = dataAccessRecruit.exec_reader_prc_rec("Prc_GetECRMpanUpdation", htdata);
                //Added By  Ibrahim on 05-07-2013 To Get ECRM pan Updation End

                if (drResult.HasRows)
                {
                    if (drResult.Read())
                    {
                        htParam1.Add("@LGAGCode", drResult["CndNo"].ToString().Trim());
                        htParam1.Add("@ClientCode", drResult["GCN"].ToString().Trim());
                        htParam1.Add("@PaNNo", txtPAN.Text);
                        htParam1.Add("@GroupFlag", "ADV");
                        ECRMFlag = 1;
                    }
                }

                if (ECRMFlag == 0)
                {
                    Hashtable htparam = new Hashtable();
                    DataSet dsPANverify = new DataSet();
                    //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  start                        
                    htdata.Clear();
                    htdata.Add("@CndNo", hdnCndNo.Value);

                    dsPANverify = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPANverify", htdata);
                    //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  End
                    if (dsPANverify.Tables[0].Rows.Count > 0)
                    {
                        htParam1.Clear();
                        htParam1.Add("@CndNo", dsPANverify.Tables[0].Rows[0]["CndNo"].ToString());
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
                dsFees.Clear();
                dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsertTrnReqDtl", htParam);
                //MailResponse();//MAIL


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
                arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                arrLst.Add(new prjXml.Collection("TccID", Convert.ToString(hdnTccID.Value)));
                prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                XmlDocument xDoc = new XmlDocument();
                xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                strXML = xDoc.OuterXml;
                arrLst.Clear();
                #endregion Auditlog

                //x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateTrnHrsDtls", htParam);
                x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateTrnReqDtl", htParam); //Added by pranjali on 02-01-2014 to update details 
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
                    arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                    arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                    arrLst.Add(new prjXml.Collection("WaiverFlag", hdnAdvWaiver.Value));
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

                    if (ECRMFlag == 0)
                    {
                        Hashtable htparam = new Hashtable();
                        DataSet dsPANverify = new DataSet();
                        //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  start
                        htdata.Clear();
                        htdata.Add("@CndNo", hdnCndNo.Value);
                        dsPANverify = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPANverify", htdata);
                        //Added By ibrahim on 05-07-2013 To Get Pan Verification  Records  End
                        if (dsPANverify.Tables[0].Rows.Count > 0)
                        {
                            htParam1.Clear();
                            htParam1.Add("@CndNo", dsPANverify.Tables[0].Rows[0]["cndno"].ToString());
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
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_InsertTrnHrsDtls", htParam);

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
                    arrLst.Add(new prjXml.Collection("MobileNo", txtMobileNo.Text.Trim()));
                    arrLst.Add(new prjXml.Collection("Email", txtEMail.Text.Trim()));
                    arrLst.Add(new prjXml.Collection("TccID", Convert.ToString(hdnTccID.Value)));
                    prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    strXML = xDoc.OuterXml;
                    arrLst.Clear();
                    #endregion for Auditlog
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateTrnHrsDtls", htParam);
                    btnSubmit.Enabled = false;
                }
            }
            #endregion
            //if (x != 0)
            //if (strvalue != "" || x != 0)
            //{
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
                lblMessage.Text = "Updated successfully";
                lblSub.Text = "Updated successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                mdlpopupSub.Show();
                lblMessage.Visible = true;
            }
            //added by pranjali -----start
            else if (Request.QueryString["TrnRequest"].ToString().Trim() == "Renewal" && Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                //added by shreela on 8/04/2014 start
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetIncRenewalCnt", htParam);
                //added by shreela on 8/04/2014 end
                lblMessage.Text = "License Renewal Request submitted successfully";
                lblSub.Text = "License Renewal request submitted successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text
                                + "<br/>Candidate Name: " + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;//added by shreela on 09/06/2014
                mdlpopupSub.Show();
                lblMessage.Visible = true;
            }
            //added by pranjali -----end
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start 
                lblMessage.Text = "Sponsorship Request raised successfully";
                lblpopup.Text = "Sponsorship request raised successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:"
                    + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;//added by shreela on 09/06/2014

                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {
                        lblpopup.Text = lblpopup.Text + "<br/>Token No: " + dsFees.Tables[0].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[0].Rows[0]["TotalFees"].ToString();
                    }
                }
                else
                {
                    lblpopup.Text = lblpopup.Text + "<br/>Total Fees: 0.00";
                }

                mdlpopup.Show();
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end
                lblMessage.Visible = true;
                btnSubmit.Enabled = false;
            }
            //added by shreela on 21042014---start
            else if (Request.QueryString["TrnRequest"].ToString().Trim() == "ReExam" && Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start
                dsResult.Clear();
                htParam.Clear();
                htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdReExmCnt", htParam);
                x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdReExmCnt", htParam);
                lblMessage.Text = "ReTraining Request raised successfully";
                lblSub.Text = "ReTraining request raised successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text
                    + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                //+ "<br/>Token No: " + strT + "<br/>Total Fees: " + strF;
                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[3].Rows.Count > 0)
                    {
                        lblSub.Text = lblSub.Text + "<br/>Token No: " + dsFees.Tables[3].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[3].Rows[0]["TotalFees"].ToString();
                    }
                }
                else
                {
                    lblSub.Text = lblSub.Text + "<br/>Total Fees: 0.00";
                }
                mdlpopupSub.Show();
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text end
                lblMessage.Visible = true;
                btnSubmit.Enabled = false;
            }
            //added by shreela on 21042014---end
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                //Added by Rachana on 16/05/2013 for showing messagebox on btnSubmit_Click and change in lblMessage text start
                lblMessage.Text = "Sponsorship Request updated successfully";
                lblpopup.Text = "Sponsorship request updated successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:"
                    + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
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
            if (lblMessage.Text == "Sponsorship request raised successfully" || lblMessage.Text == "Sponsorship request updated successfully")
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
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
    }

    private void GetUserSAPCode()
    {
        Hashtable htSAP = new Hashtable();
        DataSet dsSAP = new DataSet();
        htSAP.Add("@AppNo", lblAppNoValue.Text);
        dsSAP = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUserSAPCode", htSAP);
        ViewState["SAP"] = dsSAP.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
    }
    private void MailResponse()
    {
        GetUserSAPCode();
        Hashtable htParam = new Hashtable();
        DataSet dsres = new DataSet();
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsres = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
        if (dsres.Tables[0].Rows.Count > 0)
        {
            ViewState["InsRenewalType"] = dsres.Tables[0].Rows[0]["InsRenewalType"].ToString();
        }
        Hashtable htrexm = new Hashtable();
        htrexm.Clear();
        DataSet dsReExm = new DataSet();
        dsReExm.Clear();
        htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
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
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", CandidateType, "60", "NR", "", NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());

                        }
                        else if (ViewState["RenewalFlag"].ToString() == "Y" && ViewState["CandType"].ToString() == "C")
                        {
                            //Reneawl QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", ViewState["CandType"].ToString(), "90", "RW", ViewState["InsRenewalType"].ToString(), NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "V")
                        {
                            //Reexam QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "QC", "F", "60", "RE", ViewState["ReExmType"].ToString(), NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (ViewState["ReExamFlag"].ToString() == "Y" && ViewState["ReExmType"].ToString() == "I")
                        {
                            //Reexam QC
                            objmailcomm.SendNoticationMailSMS("ARTL", "ITraining", "F", "90", "RE", ViewState["ReExmType"].ToString(), NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
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
        else if (Request.QueryString["Type"].ToString().Trim() == "Preview")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        else
        {
            Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NW&Code=Spon");
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Photo");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@CndNo", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's Photo");
                ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDataPALDCTMFileUpload", ht);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }
            }
        }
        catch (Exception ex)
        {
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Signature");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@CndNo", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's Signature");
                ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDataPALDCTMFileUpload", ht);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }

            }
        }
        catch (Exception ex)
        {
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's PAN");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);

            }
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                DataSet ds = new DataSet();
                Hashtable ht = new Hashtable();
                ds = null;
                ht.Clear();
                ht.Add("@CndNo", lblCndNoValue.Text.Trim());
                ht.Add("@DocType", "Advisor's PAN");
                ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDataPALDCTMFileUpload", ht);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                    }
                    else
                    {
                        intValue = dataAccessRecruit.execute_sprcrecruit("Proc_UpdateDCTMFileUpload", htdata);
                    }
                }
            }
        }
        catch (Exception ex)
        {
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName);
        htdata.Add("@DocType", "Advisor's Waiver Form");
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');

        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
            }

        }
        catch (Exception ex)
        {
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
            ddlExmBody.DataValueField = "ExmBody";
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
    #region ddlExmTpe SelectedIndexChanged Event
    protected void ddlExmTpe_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExmTpe.SelectedValue == "REXM" && lblReqStatusValue.Text.Trim() == "Completed")
        {
            //commented by pranjali on 02-01-2014 start
            //AgnSignUpload.Enabled = false;
            //AgnPhotoUpload.Enabled = false;
            //PANUpload.Enabled = false;
            //commented by pranjali on 02-01-2014 end
            ddlExam.Enabled = false;
            ddlExmBody.Enabled = false;
            ddlpreeamlng.Enabled = false;
            txtExmCentre.Enabled = false;
            btnExmCentre.Enabled = false;
        }

        if (ddlExmTpe.SelectedValue.Trim() == "NADV")
        {
            ddlExam.SelectedValue = "1";
            ddlExam.Enabled = false;
        }
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

    #region btnVerifyPAN Click Events
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPAN.Text.Trim() != "ZZZPZ9999Z")
            {
                bool isFound = false;
                DataSet dsRes = new DataSet();
                lblPANMsg.Text = "";
                hdnbtnVerify.Value = "1";
                hdnPan.Value = "0";
                htParam.Clear();
                htParam.Add("@PAN", txtPAN.Text.Trim());
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());

                dsRes = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetChkPANExist", htParam);

                if (dsRes.Tables.Count > 0)
                {
                    if (dsRes.Tables[0].Rows.Count > 0)
                    {
                        isFound = true;
                        hdnAgnCode.Value = Convert.ToString(dsRes.Tables[0].Rows[0]["CndNo"]).Trim();
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

                if ((isFound == true) && (lblAppNoValue.Text.Trim() != hdnAgnCode.Value))//if (isFound == true)
                {
                    lblPANMsg.Text = "Duplicate Match Found <br/> " + hdnAgnCode.Value;
                    lblPANMsg.ForeColor = Color.Red;
                    //Added by rachana on 17122013 for raising CFR for mobile start
                    //if (lblmobileverify.Text == "Mobile number exist for other candidate")
                    //{
                    Hashtable httable = new Hashtable();
                    DataSet dscandtype = new DataSet();
                    httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                    htParam.Clear();
                    htParam.Add("@CndNo", lblCndNoValue.Text.Trim());
                    htParam.Add("@CFRDesc", lblPANMsg.Text.Trim());
                    htParam.Add("@CFRFOR", "Email");
                    htParam.Add("@Createdby", Session["UserID"].ToString().Trim());
                    string strCandType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();

                    if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "F")
                    {
                        htParam.Add("@DocCode", "20");
                    }
                    else if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "T")
                    {
                        htParam.Add("@DocCode", "21");
                    }
                    else
                    {
                        htParam.Add("@DocCode", "22");
                    }
                    htParam.Add("@Flag", 3);
                    dataAccessRecruit.execute_sprcrecruit("Prc_InsCfrRemarkMobEmailPan", htParam);

                    //}
                    //Added by rachana on 17122013 for raising CFR for mobile end


                }
                else
                {
                    lblPANMsg.Text = "PAN No. Verified";
                    lblPANMsg.ForeColor = Color.Green;
                }
            }
            else
            {
                hdnPan.Value = "1";
                lblPANMsg.Text = "";
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

    protected void btnCFR_Click(object sender, EventArgs e)
    {
        lblSuccessMsg.Visible = true;//added by rachana 27052013
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
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
                    htUrnChk.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsUrnChk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetChkCndURNNo", htUrnChk);
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
            htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
            //For Reexam start
            Hashtable htrexm = new Hashtable();
            htrexm.Clear();
            DataSet dsReExm = new DataSet();
            dsReExm.Clear();
            htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
            //For Reexam end
            Hashtable htable = new Hashtable();
            htable.Clear();
            DataSet dsCndtype = new DataSet();
            dsCndtype.Clear();
            htable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsCndtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htable);
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
                //Added by rachana to save Exam details at the time of SAVE end
                x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateQCDtls", htParam);
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
                    if (ddlHrsTrn.SelectedValue != "" && ddlHrsTrn.SelectedValue != "-Select--")
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
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateQCDtls", htParam);
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
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdQCDtlsValidReExm", htParam);
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
                if (ddlTrnInstitute.SelectedValue != "" && ddlTrnInstitute.SelectedValue != "--Select")
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
                        htdata.Add("@cndNo", Request.QueryString["CndNo"].ToString().Trim());

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
                                    //htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                                    //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
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
                        ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdQCRenwlDtls", htParam);
                    }
                    else
                    {
                        //htParam1.Clear();
                        //dsResult.Clear();
                        //htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
                        htParam.Add("@InsRenewalType", System.DBNull.Value);
                        htParam.Add("@OthrTrnComp", System.DBNull.Value);
                        //htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                        htParam.Add("@flag", "2");
                        ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdQCRenwlDtls", htParam);
                    }
                }
                else
                {
                    htParam1.Clear();
                    dsResult.Clear();
                    htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
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
                                //htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
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
                    ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdQCRenwlDtls", htParam);
                }


            }

            lblsave.Text = "Candidate Details saved successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Application No:" + lblAppNoValue.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;
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
                    htUrnChk.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsUrnChk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetChkCndURNNo", htUrnChk);
                    if (dsUrnChk.Tables[0].Rows.Count > 0)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is not a Unique No.')", true);
                        return;
                    }
                }
            }
            if (cbTrfrFlag.Checked == true)
            {
                if (txtCndURNNo.Text == "")
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is Mandatory.')", true);
                    return;
                }
                if (TxtTrnsfrReqNo.Text == "" && ViewState["RenewalFlag"].ToString() != "Y")
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('IRDA Transfer Request No. is Mandatory.')", true);
                    return;
                }
            }
            if (chkCompAgnt.Checked == true)
            {
                if (txtCndURNNo.Text == "")
                {
                    ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate URN No. is Mandatory.')", true);
                    return;
                }
            }

            Hashtable htRWQCFlag = new Hashtable();
            DataSet dsRWQCFlag = new DataSet();
            htRWQCFlag.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsRWQCFlag = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htRWQCFlag);
            if (dsRWQCFlag.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim() != "Y")
            {
                if (dsRWQCFlag.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    if (dsRWQCFlag.Tables[0].Rows[0]["CandType"].ToString().Trim() != "T")
                    {
                        if (dsRWQCFlag.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() != "1")
                        {
                            if (ddlTrnMode.SelectedValue == "" || ddlTrnMode.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Mode')", true);
                                return;
                            }
                            if (ddlTrnLoc.SelectedValue == "" || ddlTrnLoc.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Training Location')", true);
                                return;
                            }
                            if (ddlTrnInstitute.SelectedValue == "" && ddlTrnInstitute.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Institute')", true);
                                return;
                            }
                            if (ddlHrsTrn.SelectedValue == "" && ddlHrsTrn.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Hrs')", true);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (cbTccCompLcn.Checked == true)
                        {
                            if (ddlTrnMode.SelectedValue == "" || ddlTrnMode.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Mode')", true);
                                return;
                            }
                            if (ddlTrnLoc.SelectedValue == "" || ddlTrnLoc.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Training Location')", true);
                                return;
                            }
                            if (ddlTrnInstitute.SelectedValue == "" && ddlTrnInstitute.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Institute')", true);
                                return;
                            }
                            if (ddlHrsTrn.SelectedValue == "" && ddlHrsTrn.SelectedValue == "--Select--")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Hrs')", true);
                                return;
                            }
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
                //added by pranjali for validation on approve button to restrict approval bfore closing of all CFR's start
                Hashtable htparam = new Hashtable();
                DataSet dsapprovechk = new DataSet();
                htparam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam);

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
                //{
                int x = 0;
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

                //added by pranjali on 24022014 for adding details of transfer from inbox details start
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
                    htparam.Add("@LcnIssDate", System.DBNull.Value);
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
                #endregion

                htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                //added by pranjali on 29-04-2014 start
                Hashtable htrexm = new Hashtable();
                htrexm.Clear();
                DataSet dsReExm = new DataSet();
                dsReExm.Clear();
                htrexm.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsReExm = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm);
                if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")//Reexam QC //added by pranjali on 28-04-2014
                {
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
                    if (ddlTrnLoc.SelectedValue != "")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    //htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    if (ddlTrnInstitute.SelectedValue != "")
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
                    if (ddlHrsTrn.SelectedValue != "")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    //Update WaiverFlag in LicRenTCCSu chkWebTknRecd
                    if (chkWebTknRecd.Checked == true)
                    {
                        htParam.Add("@Waiverflag", "1");
                    }
                    else
                    {
                        htParam.Add("@Waiverflag", "0");
                    }
                    //added by pranjali on 11-04-2014 for exam details insertion start     
                    //}
                }
                else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC //added by pranjali on 28-04-2014)
                {
                    //added for Appling validation
                    if (ddlTrnMode.SelectedValue == "" || ddlTrnMode.SelectedValue == "--Select--")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Mode')", true);
                        return;
                    }
                    if (ddlTrnLoc.SelectedValue == "" || ddlTrnLoc.SelectedValue == "--Select--")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Training Location')", true);
                        return;
                    }
                    if (ddlTrnInstitute.SelectedValue == "" && ddlTrnInstitute.SelectedValue == "--Select--")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Institute')", true);
                        return;
                    }
                    if (ddlHrsTrn.SelectedValue == "" && ddlHrsTrn.SelectedValue == "--Select--")
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Training Hrs')", true);
                        return;
                    }
                    if (ddlTrnMode.SelectedIndex != 0)
                    {
                        htParam.Add("@TrnMode", ddlTrnMode.SelectedValue.Trim());
                    }
                    else
                    {
                        htParam.Add("@TrnMode", System.DBNull.Value);
                    }
                    //htParam.Add("@TrnMode", ddlTrnMode.SelectedValue);
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
                    if (ddlTrnLoc.SelectedValue != "")
                    {
                        htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    }
                    else
                    {
                        htParam.Add("@TrnLocDesc", System.DBNull.Value);
                    }
                    //htParam.Add("@TrnLocDesc", ddlTrnLoc.SelectedItem.Text);
                    if (ddlTrnInstitute.SelectedValue != "")
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
                    if (ddlHrsTrn.SelectedValue != "")
                    {
                        htParam.Add("@TrnHrs", ddlHrsTrn.SelectedValue);
                    }
                    else
                    {
                        htParam.Add("@TrnHrs", System.DBNull.Value);
                    }
                    //Update WaiverFlag in LicRenTCCSu chkWebTknRecd
                    if (chkWebTknRecd.Checked == true)
                    {
                        htParam.Add("@Waiverflag", "1");
                    }
                    else
                    {
                        htParam.Add("@Waiverflag", "0");
                    }
                }
                else if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")//Reexam QC //added by pranjali on 28-04-2014)
                {
                    if (chkWebTknRecd.Checked == true)
                    {
                        htParam.Add("@Waiverflag", "1");
                    }
                    else
                    {
                        htParam.Add("@Waiverflag", "0");
                    }
                    //added by pranjali on 11-04-2014 for exam details inse
                }
                //added by shreela on 29/04/2014 start
                Hashtable htrenwl = new Hashtable();
                htrenwl.Clear();
                dsResult.Clear();
                htrenwl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htrenwl);
                if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                {
                    htParam.Add("@ExamMode", ddlExam.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmBody", ddlExmBody.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue.ToString().Trim());
                    //htParam.Add("@ExmCentre", ddlExmCentre.SelectedValue.ToString().Trim());
                    //htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                    htParam.Add("@ExmCentre", txtExmCentre.Text.Trim());
                }
                htParam.Add("@Updatedby", Session["UserId"].ToString().Trim());
                //added by shreela on 29/04/2014 end

                //added by pranjali on 11-04-2014 for exam details insertion end

                #region RE-Exam QC
                //added by pranjali on 29-04-2014 start
                if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                {
                    //Added by rachana
                    if (ViewState["strICMEnable"].ToString() != "NO")//no ICM
                    {
                        //if (chkWebTknRecd.Checked == false)
                        //if (dgPaymentdtls.Rows.Count == 0)
                        //{
                        //    ProgressBarModalPopupExtender.Hide();
                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Fees Details.')", true);
                        //    return;
                        //}
                        //else
                        //{
                        //    if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count==0)
                        //    {
                        //        ProgressBarModalPopupExtender.Hide();
                        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Proceed with Get Fees.')", true);
                        //        return;
                        //    }
                        //}
                        if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count == 0)
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate fees details are not saved.')", true);

                        }
                    }

                    Hashtable htrexm1 = new Hashtable();
                    htrexm1.Clear();
                    DataSet dsReExm1 = new DataSet();
                    dsReExm1.Clear();
                    htrexm1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsReExm1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htrexm1);
                    //added for getting reexam type to get no of days based on valid/invalid flag by rachana
                    ViewState["ReExmType"] = dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
                    if (dsReExm1.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")//Reexam QC
                    {
                        GetNoofDaysForReexm();
                        SetSysFreezeDate();
                        InsertfeesDetails();
                        htParam.Add("@Email", txtEMail.Text.Trim());
                        htParam.Add("@PAN", txtPAN.Text.Trim());
                        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                        x = dataAccessRecruit.execute_sprcrecruit("Prc_ApprLictrnccsuForReExm", htParam);//added by pranjali on 29-04-2014 end
                        //MailResponse();

                    }
                    else if (dsReExm1.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y" && dsReExm1.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "I")//Reexam QC)
                    {
                        GetNoofDaysForReexm();
                        SetSysFreezeDate();
                        InsertfeesDetails();
                        htParam.Add("@Email", txtEMail.Text.Trim());
                        htParam.Add("@PAN", txtPAN.Text.Trim());
                        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                        x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_Lictrnccsu", htParam);
                        //MailResponse();

                    }
                }
                #endregion
                //added by pranjali on 29-04-2014 end
                //added by shreela on 29/04/2014 start
                #region Renewl Qc
                htrenwl.Clear();
                dsResult.Clear();
                htrenwl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htrenwl);
                if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                {
                    if (dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim() == "F" || dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim() == "T")
                    {
                        if (cbTccCompLcn.Checked == true)
                        {

                            ds_documentName.Clear();
                            htdata.Add("@cndNo", Request.QueryString["CndNo"].ToString().Trim());

                            //shree07
                            htParam.Add("@InsRenewalType", ddlRenewType.SelectedItem.Value.ToString().Trim());
                            if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "L")
                            {
                                //composite Leader
                                if (ddllyfTraining.SelectedItem.Value.ToString().Trim() == "N")
                                {
                                    ProgressBarModalPopupExtender.Hide();
                                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please Complete Life Training then Proceed Further');</script>");
                                    return;
                                    //    lblRen.Text = "Please complete Life Training first then proceed further<br/><br/>";
                                    //    mdlViewRen.Show();
                                    //    pnlMdlRen.Visible = true;
                                }
                                else if (ddllyfTraining.SelectedItem.Value.ToString().Trim() == "---Select---" || ddllyfTraining.SelectedItem.Value.ToString().Trim() == " ")
                                {
                                    ProgressBarModalPopupExtender.Hide();
                                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Life Training Completed is Mandatory');</script>");
                                    return;
                                }
                                else
                                {
                                    htParam.Add("@OthrTrnComp", ddllyfTraining.SelectedItem.Value.ToString().Trim());
                                }
                            }
                            else
                            {
                                //Composite Follower
                                htParam1.Clear();
                                dsResult.Clear();
                                htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
                                htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());

                            }
                            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_updcndcompdtls", htdata);
                            //x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_LicRenTccsuRen", htParam);
                            //InsertfeesDetails();

                        }
                        else
                        {
                            htParam.Add("@InsRenewalType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                            htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());
                            //x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_LicRenTccsuRen", htParam);
                            //InsertfeesDetails();//frsh case fes insert
                        }
                    }
                    else
                    {
                        //shree07
                        htParam.Add("@InsRenewalType", ddlRenewType.SelectedItem.Value.ToString().Trim());
                        if (ddlRenewType.SelectedItem.Value.ToString().Trim() == "L")
                        {
                            if (ddllyfTraining.SelectedItem.Value.ToString().Trim() == "N")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please Complete Life Training then Proceed Further');</script>");
                                return;
                                //lblRen.Text = "Please complete Life Training first then proceed further<br/><br/>";
                                //mdlViewRen.Show();
                                //pnlMdlRen.Visible = true;
                            }
                            else
                            {
                                htParam.Add("@OthrTrnComp", ddllyfTraining.SelectedItem.Value.ToString().Trim());
                            }
                        }
                        else
                        {
                            htParam1.Clear();
                            dsResult.Clear();
                            htParam1.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam1);
                            htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());

                        }
                        //htParam.Add("@InsRenewalType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                        //htParam.Add("@OthrTrnComp", dsResult.Tables[0].Rows[0]["OthrTrnComp"].ToString().Trim());
                        //x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_LicRenTccsuRen", htParam);
                        //InsertfeesDetails();
                    }
                    dsloc.Clear();
                    httable.Clear();
                    httable.Add("@CndNo", lblCndNoValue.Text.Trim());
                    dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetCandType", httable);
                    if (dsloc.Tables.Count > 0)
                    {
                        if (dsloc.Tables[0].Rows.Count > 0)
                        {
                            string IsPriorAgt = dsloc.Tables[0].Rows[0]["IsPriorAgt"].ToString();
                            if (IsPriorAgt == "1")
                            {
                                htdata.Clear();
                                ds_documentName.Clear();
                                htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                htdata.Add("@licExpDate", DateTime.Parse(txtnewexpdate.Text.Trim()).ToString("yyyyMMdd"));
                                if (txtnewlicissu.Text.Trim() != "")
                                {
                                    //htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                                    DateTime dtissdate = Convert.ToDateTime(txtnewlicissu.Text);
                                    DateTime dtlicdate = Convert.ToDateTime(lbloldexpdateval.Text);

                                    int idateissy = dtissdate.Year;
                                    int idatelicy = dtlicdate.Year;

                                    if (idateissy < idatelicy)
                                    {
                                        ProgressBarModalPopupExtender.Hide();
                                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                                        return;
                                    }
                                    else if (idateissy == idatelicy)
                                    {
                                        int idateissm = dtissdate.Month;
                                        int idatelicm = dtlicdate.Month;
                                        if (idateissm < idatelicm)
                                        {
                                            ProgressBarModalPopupExtender.Hide();
                                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                                            return;
                                        }
                                        else if (idateissm == idatelicm)
                                        {
                                            //DateTime dt= new DateTime();
                                            //dt=dtissdate.Date;
                                            int idateissd = dtissdate.Day;
                                            int idatelicd = dtlicdate.Day;
                                            if (idateissd <= idatelicd)
                                            {
                                                ProgressBarModalPopupExtender.Hide();
                                                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                                                return;
                                            }
                                            else
                                            {
                                            }

                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                    htParam.Add("@Email", txtEMail.Text.Trim());
                    htParam.Add("@PAN", txtPAN.Text.Trim());
                    htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_LicRenTccsuRen", htParam);
                    InsertfeesDetails();
                    //MailResponse();

                }
                #endregion
                //added by shreela on 29/04/2014 end
                #region Normal QC
                if (dsResult.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")
                {
                    if (dsReExm.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() != "Y")
                    {
                        //if (chkWebTknRecd.Checked == false && dgPaymentdtls.Rows.Count==0)
                        if (hdnVerifyFees.Value != "1" && dgPaymentdtls.Rows.Count == 0)
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Candidate fees details are not saved.')", true);

                        }
                        htParam.Add("@Email", txtEMail.Text.Trim());
                        htParam.Add("@PAN", txtPAN.Text.Trim());
                        htParam.Add("@Mobile", txtMobileNo.Text.Trim());
                        x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdateAppr_Lictrnccsu", htParam);
                        InsertfeesDetails();//fees details saved only at the time of QC
                        //MailResponse();
                        //MAIL
                    }
                }
                #endregion
                lblSub.Text = "Candidate QC approved successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                mdlpopupSub.Show();
                //Popup added by rachana to show msgbox end
                BtnApprove.Enabled = false;
                BtnCFR.Enabled = false;
                //Added for opening Agent Details for Transfer case candidate after approval start
                dsloc.Clear();
                httable.Clear();
                httable.Add("@CndNo", lblCndNoValue.Text.Trim());
                dsloc = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetCandType", httable);
                if (dsloc.Tables.Count > 0)
                {
                    if (dsloc.Tables[0].Rows.Count > 0)
                    {
                        string strtrn = dsloc.Tables[0].Rows[0]["CandType"].ToString();
                        string IsPriorAgt = dsloc.Tables[0].Rows[0]["IsPriorAgt"].ToString();
                        if (strtrn == "T")
                        {
                            if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")//added by shreela on 26/05/2014
                            {
                                //Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTInfo.aspx?cnd=CndCon&Type=N&CndNum=" + lblCndNoValue.Text, false);
                                Hashtable htTrnsfrLic = new Hashtable();
                                htTrnsfrLic.Add("@CndNo", lblCndNoValue.Text.Trim());
                                int z = dataAccessRecruit.execute_sprcrecruit("Prc_UpdTrnsfrLicDtls", htTrnsfrLic);
                            }
                        }
                        //added by pranjali on 27-03-2014 start
                        if (IsPriorAgt == "1")
                        {
                            if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() != "Y")//added by shreela on 26/05/2014
                            {
                                //Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTInfo.aspx?cnd=CndCon&Type=N&CndNum=" + lblCndNoValue.Text, false);
                                Hashtable htTrnsfrLic = new Hashtable();
                                htTrnsfrLic.Add("@CndNo", lblCndNoValue.Text.Trim());
                                int z = dataAccessRecruit.execute_sprcrecruit("Prc_UpdTrnsfrLicDtls", htTrnsfrLic);
                            }
                            else if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                            {
                                htdata.Clear();
                                ds_documentName.Clear();
                                htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                                htdata.Add("@licExpDate", DateTime.Parse(txtnewexpdate.Text.Trim()).ToString("yyyyMMdd"));
                                if (txtnewlicissu.Text.Trim() != "")
                                {
                                    htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                                }
                                else
                                {
                                    htdata.Add("@licissudate", System.DBNull.Value);
                                }
                                htdata.Add("@Email", txtEMail.Text.Trim());
                                htdata.Add("@PAN", txtPAN.Text.Trim());
                                htdata.Add("@Mobile", txtMobileNo.Text.Trim());
                                htdata.Add("@Updatedby", Session["UserID"].ToString().Trim());
                                x = dataAccessRecruit.execute_sprcrecruit("Prc_updcndlicdtls", htdata);
                            }
                        }
                        //added by pranjali on 27-03-2014 end
                        //added by pranjali on 11-04-2014 start
                        if (strtrn == "C")
                        {
                            //added by shreela on 25042014
                            if (dsloc.Tables[0].Rows[0]["RenewalFlag"].ToString() != "Y")
                            {
                                if (dsloc.Tables[0].Rows[0]["ReExamFlag"].ToString() != "Y")
                                {
                                    int y;
                                    y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdForCompCand", httable); //Added by pranjali on 02-01-2014 to update details
                                }
                            }
                        }
                        //added by pranjali on 11-04-2014 end


                    }
                }
                //lblpopup.Text = "Candidate QC approved successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                //mdlpopup.Show();
                //Popup added by rachana to show msgbox end
                //BtnApprove.Enabled = false;
                //BtnCFR.Enabled = false;
                ProgressBarModalPopupExtender.Hide();
            }
            else
            {
                #region QCApproval For Renewal after TCC Upload/Download
                int x;
                htdata.Clear();
                ds_documentName.Clear();
                htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                //htdata.Add("@licExpDate", txtnewexpdate.Text.Trim());
                htdata.Add("@licExpDate", DateTime.Parse(txtnewexpdate.Text.Trim()).ToString("yyyyMMdd"));
                if (txtnewlicissu.Text.Trim() != "")
                {
                    //htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                    //htdata.Add("@licissudate", txtnewlicissu.Text.Trim());
                    DateTime dtissdate = Convert.ToDateTime(txtnewlicissu.Text);
                    DateTime dtlicdate = Convert.ToDateTime(lbloldexpdateval.Text);

                    int idateissy = dtissdate.Year;
                    int idatelicy = dtlicdate.Year;

                    if (idateissy < idatelicy)
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                        return;
                    }
                    else if (idateissy == idatelicy)
                    {
                        int idateissm = dtissdate.Month;
                        int idatelicm = dtlicdate.Month;
                        if (idateissm < idatelicm)
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                            return;
                        }
                        else if (idateissm == idatelicm)
                        {
                            //DateTime dt= new DateTime();
                            //dt=dtissdate.Date;
                            int idateissd = dtissdate.Day;
                            int idatelicd = dtlicdate.Day;
                            if (idateissd <= idatelicd)
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Invalid Issue Date');</script>");
                                return;
                            }
                            else
                            {
                                htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                            }

                        }
                        else
                        {
                            htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                        }
                    }
                    else
                    {
                        htdata.Add("@licissudate", DateTime.Parse(txtnewlicissu.Text.Trim()).ToString("yyyyMMdd"));
                    }
                }
                else
                {
                    //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select License Issue Date');</script>");
                    //return;
                    htdata.Add("@licissudate", System.DBNull.Value);
                }
                htdata.Add("@Email", txtEMail.Text.Trim());
                htdata.Add("@PAN", txtPAN.Text.Trim());
                htdata.Add("@Mobile", txtMobileNo.Text.Trim());
                htdata.Add("@Updatedby", Session["UserID"].ToString().Trim());
                x = dataAccessRecruit.execute_sprcrecruit("Prc_updcndlicdtls", htdata);
                InsertfeesDetails();//inserts fees after 2nd QC
                //MailResponse();
                //btnRnwlSbmit.Enabled = false;
                // lblpopup.Text = "Candidate License Details Submited successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Application No:" + lblAppNoValue.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                lblSub.Text = "Candidate License Details Submited successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Application No:" + lblAppNoValue.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
                mdlpopupSub.Show();
                // mdlpopup.Show();
                ProgressBarModalPopupExtender.Hide();
                BtnApprove.Enabled = false;
                BtnCFR.Enabled = false;
                #endregion
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
    #region verify Mobile,Email
    protected void btnverifyemail_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEMail.Text != "")
            {
                bool bemailfound = false;
                lblEmailMsg.Visible = false;
                dsResult.Clear();
                htParam.Clear();
                hdnbtnemailVerify.Value = "1";
                hdnEmail.Value = "0";

                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@Email", txtEMail.Text.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetQualCheckverifyEmail", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)// && dsResult.Tables[0].Rows.Count == 1)
                    {
                        //shree07
                        Hashtable htrenwl = new Hashtable();
                        DataSet dsrenwl = new DataSet();
                        htrenwl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        dsrenwl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htrenwl);
                        if (dsrenwl.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                        {
                            lblEmailMsg.Visible = true;
                            lblEmailMsg.Text = "Duplicate Email id found for ";
                            lblEmailMsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            bemailfound = true;
                            hdnCanid.Value = dsResult.Tables[0].Rows[0]["cndno"].ToString();
                        }
                    }
                    else //if (dsResult.Tables[0].Rows.Count == 0)
                    {

                        hdnEmail.Value = "1";
                    }
                }
                if (bemailfound == true)
                {
                    lblEmailMsg.Visible = true;
                    lblEmailMsg.Text = "Duplicate Email id found for " + hdnCanid.Value;// +hdnCanid.Value;
                    lblEmailMsg.ForeColor = Color.Red;
                    //Added by rachana on 17122013 for raising CFR for mobile start
                    //if (lblmobileverify.Text == "Mobile number exist for other candidate")
                    #region Auto Raise CFR for email
                    //Hashtable httable = new Hashtable();
                    //DataSet dscandtype = new DataSet();
                    //httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    //dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                    //htParam.Clear();
                    //htParam.Add("@CndNo", lblCndNoValue.Text.Trim());
                    //htParam.Add("@CFRDesc", lblEmailMsg.Text.Trim());
                    //htParam.Add("@CFRFOR", "Email");
                    //htParam.Add("@Createdby", Session["UserID"].ToString().Trim());
                    //string strCandType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();

                    //if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "F")
                    //{
                    //    htParam.Add("@DocCode", "20");
                    //}
                    //else if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "T")
                    //{
                    //    htParam.Add("@DocCode", "21");
                    //}
                    //else
                    //{
                    //    htParam.Add("@DocCode", "22");
                    //}
                    //htParam.Add("@Flag", 1);
                    //dataAccessRecruit.execute_sprcrecruit("Prc_InsCfrRemarkMobEmailPan", htParam);
                    #endregion

                    //Added by rachana on 17122013 for raising CFR for mobile end


                }
                else
                {
                    lblEmailMsg.Visible = true;
                    lblEmailMsg.Text = "Email id verified.";
                    lblEmailMsg.ForeColor = Color.Green;
                }
            }
            else
            {
                hdnEmail.Value = "1";
                lblEmailMsg.Text = "";
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

        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "show", "<script type='text/javascript'>funshowdiv();</script>", false);
        //return;
    }

    protected void btnverifymobile_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMobileNo.Text != "")
            {
                bool bmobile = false;
                lblmobileverify.Visible = false;
                dsResult.Clear();
                htParam.Clear();

                hdnMobileVerify.Value = "1";
                hdnMobile.Value = "0";

                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@MobileNo", txtMobileNo.Text.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetQualCheckverifyMobile", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)// && dsResult.Tables[0].Rows.Count ==1)
                    {
                        //shree07
                        Hashtable htrenwl = new Hashtable();
                        DataSet dsrenwl = new DataSet();
                        htrenwl.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        dsrenwl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htrenwl);
                        if (dsrenwl.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                        {
                            lblmobileverify.Visible = true;
                            lblmobileverify.Text = "Duplicate match found for ";
                            lblmobileverify.ForeColor = Color.Red;

                        }
                        else
                        {
                            bmobile = true;
                            hdnCanid.Value = dsResult.Tables[0].Rows[0]["cndno"].ToString();
                        }
                    }
                    else //if (dsResult.Tables[0].Rows.Count == 0)
                    {

                        hdnMobile.Value = "1";
                    }
                }
                else
                {
                    bmobile = false;
                    hdnMobile.Value = "1";
                }
                if (bmobile == true)
                {
                    lblmobileverify.Visible = true;
                    lblmobileverify.Text = "Duplicate match found for " + hdnCanid.Value;//

                    //Added by rachana on 17122013 for raising CFR for mobile start
                    //if (lblmobileverify.Text == "Mobile number exist for other candidate")
                    lblmobileverify.ForeColor = Color.Red;

                    Hashtable httable = new Hashtable();
                    DataSet dscandtype = new DataSet();
                    httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                    htParam.Clear();
                    htParam.Add("@CndNo", lblCndNoValue.Text.Trim());
                    htParam.Add("@CFRDesc", lblmobileverify.Text.Trim());
                    htParam.Add("@CFRFOR", "Email");
                    htParam.Add("@Createdby", Session["UserID"].ToString().Trim());
                    string strCandType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();

                    if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "F")
                    {
                        htParam.Add("@DocCode", "20");
                    }
                    else if (dscandtype.Tables[0].Rows[0]["CandType"].ToString() == "T")
                    {
                        htParam.Add("@DocCode", "21");
                    }
                    else
                    {
                        htParam.Add("@DocCode", "22");
                    }
                    htParam.Add("@Flag", 2);
                    dataAccessRecruit.execute_sprcrecruit("Prc_InsCfrRemarkMobEmailPan", htParam);


                    //Added by rachana on 17122013 for raising CFR for mobile end

                }
                else
                {
                    lblmobileverify.Visible = true;
                    lblmobileverify.Text = "Mobile No. verified";
                    lblmobileverify.ForeColor = Color.Green;
                }
            }
            else
            {
                hdnMobile.Value = "1";
                lblmobileverify.Visible = true;
                lblmobileverify.Text = "";
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
        //Added by rachana on 17122013 for raising CFR for mobile start
        //if (lblmobileverify.Text == "Mobile number exist for other candidate")
        //{
        //    htParam.Clear();         
        //    htParam.Add("@CndNo",lblCndNoValue.Text.Trim());
        //    htParam.Add("@CFRDesc", lblmobileverify.Text.Trim());
        //    htParam.Add("@CFRFOR", "Mobile");
        //    htParam.Add("@Createdby", Session["UserID"].ToString().Trim());
        //    htParam.Add("@DocCode", "9");
        //    dataAccessRecruit.execute_sprcrecruit("Prc_InsCfrRemarkMobEmailPan", htParam);

        //}
        //Added by rachana on 17122013 for raising CFR for mobile end
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "show", "<script type='text/javascript'>funshowdiv();</script>", false);
        //return;
    }
    #endregion

    #region Crop and open image in new page
    protected void Btncrop_Click(object sender, EventArgs e)
    {

        string strpath;
        string strimage = string.Empty;
        string[] strpathcount;
        string strimageno;
        string[] strcount;
        string strimagenonew;
        dsResult.Clear();
        htParam.Clear();
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        htParam.Add("@DocType", lblpanelheader.Text.Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
        //string strimgseq = dsResult.Tables[0].Rows[0]["ImgSequence"].ToString();
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                strpath = hdnpath.Value;

                for (int i = 0; i <= dsResult.Tables[0].Rows.Count; i++)
                {
                    //set path based on image no
                    //strpathcount = strpath.Split('_');
                    //strimageno = strpathcount[1].ToString();
                    //strcount = strimageno.Split('.');
                    //strimagenonew = strcount[0] + ".JPG";
                    //i = Convert.ToInt32(strcount[0]);

                    //if (strimageno == strimagenonew)
                    //{
                    if (dsResult.Tables.Count > 0)
                    {

                        strimage = dsResult.Tables[0].Rows[0]["ID"].ToString();
                    }

                    Response.Redirect("CropImage.aspx?image= " + strimage + "");
                    // }
                }
            }
        }
    }
    //opens crop image based on imageno end
    #endregion
    //added by rachana for performance QC module end
    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            int x = 0;
            htParam.Clear();
            htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
            htParam.Add("@UpdatedBy", Session["UserID"].ToString().Trim());
            x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdCndStatonRejApp", htParam);

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
            //MAIL

            lblSub.Text = "CFR rejected successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/><br/>Candidate Name: " + lblAdvNameValue.Text;
            mdlpopupSub.Show();
            //end
            BtnApprove.Enabled = false;
            BtnCFR.Enabled = false;
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
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
                htParam.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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

                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);
                //added by pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
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
            else if (strPhotoExt == "GIF" || strPhotoExt == "gif")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Invalid File Format');</script>");
                return;
            }
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
                //pranj
                //FileInfo fi = new FileInfo(Server.MapPath(strFileName));
                FileInfo fi = new FileInfo(strFileName);
                using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    byte[] byteData = fuData.FileBytes;
                    //byte[] byteData = data;
                    fileStream.Write(byteData, 0, byteData.Length);
                }

            }
            else
            {
                int SIZE = BMaxImgSize / 1024;
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
                return;
            }
            //}
            #endregion


            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];


            htdata.Clear();
            htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocname.Text.Trim());
            htdata.Add("@UserID", hdnUserId.Value);
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "0"); //Added by pranjali on 27-12-2013
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode.Text.Trim());
            try
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
                    //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                }
                //shreela 26-03-2014 start
                else if (Request.QueryString["Type"].ToString().Trim() == "Renwl") //shreela 26-03-2014
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela on 09/06/2014
                    //mdlViewRen.Show();
                    //pnlMdlRen.Visible = true;
                }
                //shreela 26-03-2014 end
                //added by shreela on 21042014---start
                else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
                {
                    //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lblRen.Text = lbldocname.Text + " File Uploaded successfully.";//added by shreela 
                    //mdlViewRen.Show();
                    //pnlMdlRen.Visible = true;

                }
                //added by shreela on 21042014---end
            }
            catch (Exception ex)
            {
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
            btnreupd.Enabled = true;
            btnreupd.Visible = true;
            btn_Upload.Enabled = false;
            btn_Upload.Visible = false;
            //Filluploadedfile();//Docname
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

        strFileRePath = strPath + lblCndNoValue.Text.Trim();

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
        else if (strPhotoExt == "GIF" || strPhotoExt == "gif")
        {

            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        {
            strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }

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
                    htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
                    //System.IO.File.Move(Server.MapPath(stroldpath), Server.MapPath(strnewpath));
                    System.IO.File.Move(stroldpath, strnewpath);
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName1);
        htdata.Add("@DocType", lbldocName.Text.Trim());
        htdata.Add("@UserID", hdnUserId.Value);
        htdata.Add("@DctmFlag", 'N');
        htdata.Add("@DocStatus", "1"); //Added by pranjali on 27-12-2013
        htdata.Add("@Imagebin", data);
        htdata.Add("@DocCode", lbldoccode1.Text.Trim());
        try
        {
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }

            if (Request.QueryString["Type"].ToString().Trim() == "R")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }
            //Added By pranjali on 02-01-2014 start
            else if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }
            //Added By pranjali on 02-01-2014 end
            //added by shreela
            else if (Request.QueryString["Type"].ToString().Trim() == "Renwl")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }
            //added by shreela
        }
        catch (Exception ex)
        {
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
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@doctype", Docname.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetReUploadedDetails", htParam);
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
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
                htParam.Clear();
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@doctype", Docname.Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetReUploadedDetails", htParam);
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
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            httable.Add("@DocType", ViewState["docType"]);
            ds_image = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", httable);
            if (ds_image.Tables.Count > 0)
            {
                if (ds_image.Tables[0].Rows.Count > 0)
                {
		    strDocName = ds_image.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                    strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
                    if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
                    {
                        //GridImage.Visible = false;
                        //string strImgPath = string.Empty;
                        //string strFilePath = string.Empty;
                        //strFilePath = strPath + lblCndNoValue.Text.Trim();
                        //strFileName1 = ds_image.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014
                        //strFileName = strFilePath + "\\" + strFileName1;
                        
                        //FrmImg.Visible = true;
                        //string strroute = "UploadedFiles" + "/" + Request.QueryString["CndNo"].ToString().Trim() + '/' + strFileName1;
                        //FrmImg.Attributes["src"] = strroute;
                        GridImage.Visible = false;
                        string strImgPath = string.Empty;
                        string strFilePath = string.Empty;
                        strFilePath = strPath + lblCndNoValue.Text.Trim();
                        strFileName1 = ds_image.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014

                        Byte[] FileBuffer = (byte[])ds_image.Tables[0].Rows[0]["Images"]; 
                        if (FileBuffer != null)
                        {
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", FileBuffer.Length.ToString());
                            Response.BinaryWrite(FileBuffer);
                        }  
                    }
                    else
                    {
                    GridImage.DataSource = ds_image;
                    GridImage.DataBind();
		    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Preview Available.')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Preview Available.')", true);
                return;
            }
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
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'C');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
                {
                    htparam.Add("@CandType", 'F');
                }
                //added by pranjali on 11-04-2014 start
                //htparam.Add("@RenwlFlag", "N");//shree07
                htparam.Add("@InsurerType", "");
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
                Hashtable httable = new Hashtable();
                DataSet dscandtype = new DataSet();
                httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
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
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                //adde by shree07
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

                htparam.Add("@InsurerType", "");
                htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            }
            dsUpdDocPgIndxng = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam); //added by pranjali on 11-04-2014 

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
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
                httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
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
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);
                //ADDED BY Pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
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
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
                htParam.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                //ADDED BY Pranjali on 11-04-2014 start
                //htParam.Add("@RenwlFlag", "N");
                htParam.Add("@InsurerType", "");
                htParam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
                htParam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
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
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);
                //ADDED BY Pranjali on 11-04-2014 end
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);//commented by pranjali on 11-04-2014 start
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

            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", "PHOTO");
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);

            //htParam.Add("@ID", Request.QueryString["ImageID"]);
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesbinary", htParam);

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
                btnprev.Enabled = true;
            }



            dsResult.Clear();
            htParam.Clear();

            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);

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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", doctype);
            dsResult1 = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
            if (intcode < dsResult.Tables[0].Rows.Count)
            {
                btnnext.Enabled = true;
            }

            else
            {
                btnnext.Enabled = false;
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
                string strroute = "UploadedFiles" + "/" + Request.QueryString["CndNo"].ToString().Trim() + '/' + strFileName1;
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

            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
            if (intcode < dsResult.Tables[0].Rows.Count)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", doctype);
            dsResult1 = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
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
                string strroute = "UploadedFiles" + "/" + Request.QueryString["CndNo"].ToString().Trim() + '/' + strFileName1;
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
                ViewState["docCode"] = intcode;
            }
            if (intcode == 1)
            {
                btnprev.Enabled = false;
            }

            else
            {
                btnprev.Enabled = true;
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
            htRemark.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (ViewState["RenewalFlag"].ToString() == "Y")
            {
                htRemark.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htRemark.Add("@Flag", "RE");
            }
            else
            {
                htRemark.Add("@Flag", "NR");
            }
            dsRemark = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRemarksDtls", htRemark);
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
                        dgDetailsInbox.DataBind(); //dgDetailsInbox.Rows[0].Visible = true;
                    }
                    //Added for showing grid of responded CFR end
                }
                else
                {
                    dgDetailsInbox.DataSource = null;
                    dgDetailsInbox.DataBind();
                }
            }
            else
            {
                dgDetailsInbox.DataSource = null;

                dgDetailsInbox.DataBind();
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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htParam.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htParam.Add("@Flag", "RE");
            }
            else
            {
                htParam.Add("@Flag", "NR");
            }


            //changed by rachana on 20022014 for filtering data fore grid respond start
            //htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_AssignedCFR_bracheduser", htParam);
            if (Request.QueryString["TrnRequest"].ToString() == "CFRRaise" && Request.QueryString["Type"].ToString() == "Qc" && Request.QueryString["user"].ToString() == "Lic")
            {
                htParam.Add("@UserId", Request.QueryString["user"].ToString());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_AssignedCFR_bracheduser", htParam);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    btnRespond.Visible = false;
                }
            }
            else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
            {
                htParam.Add("@UserId", Request.QueryString["user"].ToString());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_AssignedCFR_Licenseduser", htParam);
            }
            else
            {
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htParam);
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
            htcount.Add("@CndNo", Request.QueryString["CndNo"].ToString());

            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htcount.Add("@Flag", "RW");///CFR for REnewal
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")///CFR for Reexam
            {
                htcount.Add("@Flag", "RE");
            }
            else
            {
                htcount.Add("@Flag", "NR");///CFR for Normal
            }
            dscount = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetcountFor_bracheduser", htcount);


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
            htcount.Add("@CndNo", Request.QueryString["CndNo"].ToString());

            if ((Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond")
                && (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "QcRes")
                && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
            {
                htcount.Add("@Flag", "NR");
            }
            else if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htcount.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htcount.Add("@Flag", "RE");
            }



            dscount = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetcountFor_bracheduser", htcount);


            lblcfrrais1count.Text = dscount.Tables[0].Rows[0]["Raised"].ToString();
            lblcfrrespondcount.Text = dscount.Tables[1].Rows[0]["Responded"].ToString();
            lblcfrclosed.Text = dscount.Tables[2].Rows[0]["Closed"].ToString();
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
            ht.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
            {
                ht.Add("@CandType", 'T');
            }
            else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
            {
                ht.Add("@CandType", 'T');
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
            {
                ht.Add("@CandType", 'C');
            }
            else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
            {
                ht.Add("@CandType", 'F');
            }
            //added by shreela 
            htParam.Clear();
            DataSet dsResultren = new DataSet();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsResultren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htParam);
            Hashtable htren = new Hashtable();
            htren.Clear();
            DataSet dsren = new DataSet();
            dsren.Clear();
            htren.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htren);
            //added by shreela
            if (dsResultren.Tables[0].Rows[0]["RenewalFlag"].ToString() == "Y")
            {
                //ht.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                //ht.Add("@ReExmFlag", "N");
                ht.Add("@ProcessType", "RW");
            }
            else if (dsResultren.Tables[0].Rows[0]["ReExamFlag"].ToString() == "Y")
            {
                //ht.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                //ht.Add("@ReExmFlag", "N");
                ht.Add("@ProcessType", "RE");
            }
            else
            {
                ht.Add("@InsurerType", Convert.ToString(dsren.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                if (dsResultren.Tables[0].Rows[0]["IsSPFlag"].ToString() == "Y")
                {
                    ht.Add("@ProcessType", "SP");
                }
                else
                {
                    ht.Add("@ProcessType", "NR");
                }
            }
            ht.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            ht.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            dscand = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", ht);
            //added by pranjali on 11-04-2014 end
            //dscand = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", ht); //commented by pranjali on 11-04-2014
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
            httable2.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
            Hashtable httable = new Hashtable();
            DataSet dscandtype = new DataSet();
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
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
            ds_candtype1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", httable2);
            //added by pranjali on 11-04-2014 end
            //ds_candtype1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", httable2);//commented by pranjali on 11-04-2014 start
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = true;
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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
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
                    txtExmCentre.Enabled = false;

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
                    txtExmCentre.Enabled = false;
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
                    txtExmCentre.Enabled = true;
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
                    txtExmCentre.Enabled = false;
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
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htParam);
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
    }
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
                txtExmCentre.Enabled = true;
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
                txtExmCentre.Enabled = true;
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = false;
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
                txtExmCentre.Enabled = true;
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
                txtExmCentre.Enabled = true;
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
                //else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
                if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "FuncReOpen('" + lblRemarkidValue.Text + "');", true);
            MdlPopReOpenCFR.Show();

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
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
            Hashtable ht = new Hashtable();
            DataSet ds_panchayat = new DataSet();
            ht.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPanchayatCheck", ht);
            //Added by pranjali on 10-03-2014 for filtering mandatory documents end
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
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
                htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
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
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMandatoryDocEdit", htParam);
            }
            else
            {
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMandatoryDoc", htParam);
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
                    htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htCFR.Add("@CFRfor", lblcfr.Text.Trim());
                    htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                    htCFR.Add("@CFRClosedBy", Session["UserID"].ToString().Trim());
                    Hashtable htClose = new Hashtable();
                    DataSet dsclose = new DataSet();
                    htClose.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsclose = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htClose);

                    if (dsclose.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim() == "Y")
                    {
                        htCFR.Add("@Flag", "RW");
                    }
                    else if (dsclose.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    {
                        htCFR.Add("@Flag", "RE");
                    }
                    else
                    {
                        htCFR.Add("@Flag", "NR");
                    }
                    dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedCFR_admin", htCFR);
                    btnSubmit.Enabled = false;
                    BindInboxGrid();


                }
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please check the CheckBox to Close')", true);
                //    return;
                //}
            }

            lblMessage.Text = "CFR Closed successfully";
            lblSub.Text = "CFR Closed successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
            mdlpopupSub.Show();
            lblMessage.Visible = true;
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

            if (lblupdSize != null && lblupdSize.Text != "")
            {
                int updsize = Convert.ToInt32(lblupdSize.Text);
                int sizeupd = updsize / 1024;
                lblupdSize.Text = Convert.ToString(sizeupd);
            }
            if (lblManDoc.Text == "Y")
            {
                e.Row.BackColor = Color.LightPink;
            }
            else if (lblManDoc.Text == "C" && lbldoccode.Text == "15")
            {
                Hashtable htPanchayat = new Hashtable();
                DataSet ds_panchayat = new DataSet();
                htPanchayat.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_CheckForPanchayat", htPanchayat);
                if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                {
                    e.Row.BackColor = Color.LightPink;
                }

            }
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            DataSet dsdtl = new DataSet();
            dsdtl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            Hashtable htparam = new Hashtable();
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E" || Request.QueryString["Type"].ToString().Trim() == "R")
            {
                if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == true && cbTccCompLcn.Checked == false)
                {
                    htparam.Add("@CandType", 'T');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == true)
                {
                    htparam.Add("@CandType", 'C');
                }
                else if (cbTrfrFlag.Checked == false && cbTccCompLcn.Checked == false)
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
            htparam.Add("@doccode", lbldoccode.Text);
            DataSet dsUpldImg = new DataSet();
            dsUpldImg = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocCode", htparam);
            //ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam);
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
                    }
                }
            }
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

            string strWindow = "window.open('CndView.aspx?Type=Other&Act=Edit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc")
        {
            string strWindow = "window.open('CndView.aspx?Type=Other&Act=Edit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
        else
        {
            string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
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
            LinkButton1.Visible = false;
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
            LinkButton1.Visible = false;
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
    protected void btnRespond_Click(object sender, EventArgs e)
    {
        string docCodeNo = string.Empty;
        string docCodeYes = string.Empty;
        GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
        dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
        foreach (GridViewRow row in Assignedcfr)
        {
            CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
            Label lblRemarkid = (Label)row.FindControl("lblRemarkid");
            Label lblcfr = (Label)row.FindControl("lblcfr");
            Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
            Label lblCFRFlagType = (Label)row.FindControl("lblCFRFlagType");
            if (chkassign.Checked == true)
            {
                Hashtable htCFR = new Hashtable();
                htCFR.Clear();
                dsResult.Clear();
                htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htCFR.Add("@CFRfor", lblcfr.Text.Trim());
                htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                htCFR.Add("@RespondedBy", Session["UserID"].ToString().Trim());
                //if (lblCFRDocCode.Text.Trim() == "28")
                //{
                if (lblCFRFlagType.Text.Trim() == "1")
                {
                    dataAccessRecruit.execute_sprcrecruit("Prc_CFRRespondForIRDA", htCFR);
                    BindInboxGrid();
                    //lblcfrrespnd.Text = "Responded successfully";
                    lblcfrrespnd.Text = "Closed successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text +
                    "<br/>Note :- Please proceed with Update.";
                    mdlCFRRespond.Show();
                    pnlMdl1.Visible = true;
                }
                else if (lblCFRFlagType.Text.Trim() == "2")
                {
                    dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedCFR_bracheduser", htCFR);
                    BindInboxGrid();
                    //lblcfrrespnd.Text = "Responded successfully";
                    lblcfrrespnd.Text = "Responded successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text +
                    "<br/>Note :- Please proceed with Update.";
                    mdlCFRRespond.Show();
                    pnlMdl1.Visible = true;
                }
            }
        }

        //Hashtable htdoc = new Hashtable();
        //dsResult.Clear();
        //htdoc.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        //htdoc.Add("@DocCode", "28");
        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_ChkIRDACloseCFR", htdoc);

        //if (dsResult.Tables.Count > 0)
        //{
        //    if (dsResult.Tables[0].Rows.Count > 0)
        //    {
        //        int i;
        //        for (i = 0; i < dsResult.Tables[0].Rows.Count; i++)
        //        {
        //            string CFRClosed = dsResult.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();

        //            if (CFRClosed == "1")
        //            {
        //                docCodeYes = "Y";
        //            }
        //            else
        //            {
        //                docCodeNo = "N";
        //            }
        //        }
        //        if (docCodeNo != "N")
        //        {
        //            htdoc.Clear();
        //            htdoc.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        //            dataAccessRecruit.execute_sprcrecruit("Prc_UpdCFRStatusforIRDA", htdoc);
        //        }
        //    }
        //}        
    }
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
            htToken.Add("@AppNo", lblAppNoValue.Text);
            htToken.Add("@CndNo", lblCndNoValue.Text);
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

            dsToken = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTokenNoForSync", htToken);

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
            htLog.Add("@AppNo", lblAppNoValue.Text);
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


            f = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSyncLogFees", htLog);

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
            htToken.Add("@AppNo", lblAppNoValue.Text);
            htToken.Add("@CndNo", lblCndNoValue.Text);
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

            dsToken = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTokenNoForSync", htToken);

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
                #region to be uncommented on 100 server start
                XmlDocument objfee = new XmlDocument();
                objfee.LoadXml(strFeesinput);
                objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));
                strOutput1 = objOutPut.InnerXml.ToString();
                #endregion to be uncommented on 100 server end

            }
            else
            {

            }


            //Sync log entry of input output xml 
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();

            int f;
            Hashtable htLog = new Hashtable();
            htLog.Add("@RefNo", lblCndNoValue.Text);
            htLog.Add("@AppNo", lblAppNoValue.Text);
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


            f = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSyncLogFees", htLog);

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
            htToken.Add("@AppNo", lblAppNoValue.Text);
            htToken.Add("@CndNo", lblCndNoValue.Text);
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

            dsToken = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTokenNoForSync", htToken);

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
            htLog.Add("@AppNo", lblAppNoValue.Text);
            htLog.Add("@XmlInput", strFeesinput);
            htLog.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            #region To be uncommented on UAT
            //htLog.Add("@Xmloutput", strOutput);
            htLog.Add("@Xmloutput", strOutput1);
            #endregion
            htLog.Add("@Resdate", System.DateTime.Now);
            htLog.Add("@Errdesc", "err");
            htLog.Add("@MethodName", method.Name.ToString());


            f = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSyncLogFees", htLog);

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
}

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
using MCPG.ASP.net.ENC;

//using PGBitLyURL;
////Added by rachana for fees details Webservice start
//using SysInrgConsum;
//using System.ServiceModel;
//Added by rachana for fees details Webservice end


public partial class Application_ISys_Recruit_FrmSubmitTCC : BaseClass
{
    #region Global declaration
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    RCFEncryption Encript = new RCFEncryption();
    ErrLog objErr = new ErrLog();//Added by rachana on 10-12-2013 for error log
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    Hashtable htdata = new Hashtable();
    DataSet ds_documentName = new DataSet();
    string strAdvWaiverName = string.Empty;
    string strAdvWaiverExt = string.Empty;
    int ECRMFlag;
    string strDocName = string.Empty;
    int BMaxImgSize;
    private string strFileName1 = string.Empty;
    string strPhotoExt = string.Empty;
    private string strFileName = string.Empty;
    static int image_height;
    static int image_width;
    static int max_height;
    static int max_width;
    int BMaxImgSize1;
    static byte[] data;
    string DocStatusCount;
    private string strDestPath = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    int intValue;
    int x;
    string strcallerSystem = System.Configuration.ConfigurationManager.AppSettings["CallerSystem"].ToString();
    public string Code { get; set; }
    string strOutput = string.Empty;
    //added by rachana for sysfreezedate start 
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    //added by rachana for sysfreezedate end
    //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 start
    string strCndType = string.Empty;
    string IsPriorAgt = string.Empty;
    //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 end
    string PGURL = System.Configuration.ConfigurationManager.AppSettings["PGURL"].ToString();
    #endregion

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            olng = new multilingualManager("DefaultConn", "FrmSubmitTCC.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "FrmSubmitTCC.aspx", Session["UserLangNum"].ToString());

                
                hdnUserId.Value = Session["UserID"].ToString().Trim();
                InitializeControl();
                PopulateExamMode(); //added by pranjali on 25-04-2014
                //PopulateExmBodyName();//added by pranjali on 25-04-2014
                //PopulatePreExmLanguages();//added by pranjali on 25-04-2014
                //PopulateExmCentre();//added by pranjali on 25-04-2014
                PopulateCompInsurerName();//added by pranjali on 13-03-2014 for binding composite insurername dropdwn
                PopulateTrnsfrInsurerName();
                GetCandidateDtls();
                #region ICM related
                //PopulateICMStatus();
                //PopulateICMPaymentMode();
                #endregion

                #region TCC Upload
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ACT"] == "Upload")
                    {
                        tblICMManual.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        Code = Request.QueryString["Code"].ToString();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        trTCCase.Visible = true;
                        tblupload.Visible = true;
                        divUpload.Visible = true;
                        dgView.Visible = true;
                        //divbtnfinish.Visible = false;
                        btnFinish.Visible = false;
                        //added by shreela on 25042014
                        tbltrn.Visible = true;
                        tblRenewalCollapse.Visible = true;
                        divRenewal.Visible = true;
                        //added by shreela on 25042014
                        //divbtnsbmit.Visible = true;
                        btnSubmit.Visible = true;
                        tblExmsdtls.Visible = false;//added  by shreela on 25042014
                        divAgnPhotoTrnExmDtl.Visible = false;//added  by shreela on 25042014
                        //FillOldExmDtls(Request.QueryString["CndNo"].ToString().Trim());//added  by shreela on 25042014
                        //viewData(Request.QueryString["CndNo"].ToString().Trim());//added  by shreela on 25042014
                       // lblpandetail.Visible = false;//shree
                        Chkpan.Enabled = false;//shree
			//trReq.Visible = false;
                        Bindgridview();
                        //Filluploadedfile();
                        SetInitialRow();//fees details
                        //BindFeesDetails();//shree07
                        trReq.Visible = false;
                        LinkButton1.Visible = false;//shree07
                        //tblupload.Visible = true;
                        trdownld.Visible = false;
                        lblCndView.Visible = true;
                        trnsfrtitle.Visible = false;//shreela 02/06/2014
                        divTrnsferDetails.Visible = false;//shreela 02/06/2014
                      
                       
                    }
                #endregion

                    #region TCC Download
                    else if(Request.QueryString["ACT"]=="Download")
                    {
                        tblICMManual.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        Code = Request.QueryString["Code"].ToString();
                        //btnFinish.Visible = true;
                        //divbtnClear.Visible = false;
                        btnClear.Visible = false;
                        tr_DocumentDownload.Visible = true;
                        trTCCase.Visible = true;
                        tblDwnld.Visible = true;
                        divDwnld.Visible = true;
                        //added by shreela on 25042014
                        //shree07

                        Hashtable htdtls = new Hashtable();
                        htdtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        DataSet dsdtls = new DataSet();
                        dsdtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htdtls);
                        if (dsdtls.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "F")
                        {

                            tblupload.Visible = false;
                            divUpload.Visible = false;
                            Table2.Visible = false;
                            divReUpload.Visible = false;
			    //Bindgridview();

                        }
                        else
                        {
                            tblupload.Visible = true;
                            divUpload.Visible = true;
                            Bindgridview();
                            //Filluploadedfile();
                        }
                        tbltrn.Visible = true;
                        tblRenewalCollapse.Visible = true;
                        divRenewal.Visible = true;
                        tblExmsdtls.Visible = false;
                        divAgnPhotoTrnExmDtl.Visible = false;
                        //FillOldExmDtls(Request.QueryString["CndNo"].ToString().Trim());//added  by shreela on 25042014
                        //viewData(Request.QueryString["CndNo"].ToString().Trim());//added  by shreela on 25042014
                        //added by shreela on 25042014
                        //lblpandetail.Visible = false;//shree
                        Chkpan.Enabled = false;//shree
                        BindgridviewDwnld();
                        //Filluploadedfile();
                        SetInitialRow();//fees details
                        //BindFeesDetails();//shree07
                        //divbtnsbmit.Visible = false;
                        btnSubmit.Visible = false;
                        //divbtnfinish.Visible = false;
                        btnFinish.Visible = false;
                        tblCheck.Visible = true;
                        chckDwnld.Visible = true;
                        chckDwnld.Enabled = true;
                        trReq.Visible = false;
                        LinkButton1.Visible = false;//shree07
                        lblCndView.Visible = true;
                        trnsfrtitle.Visible = false;//shreela 02/06/2014
                        divTrnsferDetails.Visible = false;//shreela 02/06/2014
			//Bindgridview();
                    }
                    #endregion

                    #region TCC ReDownload
                    else if (Request.QueryString["ACT"] == "Dwnld")
                    {
                        tblICMManual.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        Code = Request.QueryString["Code"].ToString();
                        tr_DocumentDownload.Visible = true;
                        trTCCase.Visible = true;
                        tblDwnld.Visible = true;
                        divDwnld.Visible = true;
                        tblupload.Visible = false;
                        divUpload.Visible = false;
                        Table2.Visible = false;
                        divReUpload.Visible = false;
                        tbltrn.Visible = true;
                        tblRenewalCollapse.Visible = true;
                        divRenewal.Visible = true;
                        tblExmsdtls.Visible = false;
                        divAgnPhotoTrnExmDtl.Visible = false;
                        Chkpan.Enabled = false;//shree
                        BindgridviewDwnld();
                        //Filluploadedfile();
                        btnSubmit.Visible = false;
                        btnFinish.Visible = false;
                        tblCheck.Visible = true;
                        trReq.Visible = false;
                        LinkButton1.Visible = false;
                        lblCndView.Visible = false;
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        cbTccCompLcn.Enabled = false;
                        txtCompLicNo.Enabled = false;
                        txtCompLicExpDt.Enabled = false;
                        ddlCompInsurerName.Enabled = false;
                        CalendarExtender1.Enabled = false;
                        chckDwnld.Visible = false;
                        btnClear.Visible = true;

                    }
                    #endregion

                    #region Preferred Exam Details
                    //Added by kalyani  on 21/04/2014 for Preffered exam details start
                    else if (Request.QueryString["Type"] == "E")
                    {
                        tblICMManual.Visible = false;
                        trReq.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                      
                            //Code = Request.QueryString["Code"].ToString();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        trTCCase.Visible = false;
                        divUpload.Visible = false;
                        dgView.Visible = false;
                        //divbtnfinish.Visible = false;
                        btnFinish.Visible = false;
                        //divbtnsbmit.Visible = true;
                        btnSubmit.Visible = true;
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        CompositeTitle.Visible = false;
                        divCompositeDetails.Visible = false;
                        //tbltrn.Visible = true;
                        //Commit by pallavi on 07102022
                        tblExmSchedule.Visible = true;
                        //tblPrefExm.Visible = true;
                    //Commit by pallavi on 11102022

                    txtMobileNo.Enabled = false;
                        //btnverifymobile.CssClass = "btn btn-xs btn-primary disabled";
                        btnverifymobile.Enabled = false;
                        txtEMail.Enabled = false;
                        //btnverifyemail.CssClass = "btn btn-xs btn-primary disabled";
                        btnverifyemail.Enabled = false;
                        viewData(Request.QueryString["CndNo"].ToString().Trim());
                        GetSystemFreezeDate();
                        lblTitle.Text = "Preferred Exam Details";//shreela 30052014
                       // TblFeesWaiver.Visible = true;//added by amruta on 21.8.15 for fees wavier
                   // changes by pallavi for fees waiver on 15122022

                        lblTitle.Visible = false; // added by pallavi on 07102022
                        lblCndView.Visible = false; // added by pallavi on 07102022
                    //btnPrev1.Visible = false;

                    }
                    #endregion 

                    #region Re-Exam
                    else if (Request.QueryString["Type"].Trim() == "ReExam")
                    {
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        Code = Request.QueryString["Code"].ToString();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        trReq.Visible = false;
                        lblReqStatus.Visible = false; //Added by kalyani on 16-05-2014 to hide requested status
                        lblReqStatusValue.Visible = false;//Added by kalyani on 16-05-2014 to hide requested status
                        tblICMManual.Visible = false;
                        chkWebTknRecd.Checked = true;
                        trTCCase.Visible = true;
                        divUpload.Visible = true;
                        dgView.Visible = true;
                        //divbtnfinish.Visible = false;
                        btnFinish.Visible = false;
                        //divbtnsbmit.Visible = true;
                        btnSubmit.Visible = true;
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        CompositeTitle.Visible = false;
                        divCompositeDetails.Visible = false;
                        tbltrn.Visible = false;
                    // changes done  by pallavi for training details tabing on 10102022
                       tblExmSchedule.Visible = true;
                        lblCndView.Visible = true; //Added by pranjali  on 26/04/2014

                        //tblCndURN.Visible = true;//added by shreela on 03/07/2014
                        // commit by pallavi on 10102022


                        btnClear.Visible = false;//added by shreela on 14/07/2014
                        btnCancel.Visible = true;//added by shreela on 14/07/2014

                    //tblPrefExm.Visible = true;
                    //Commit by pallavi on 11102022
                       tblexam.Visible = true;
                       tblNexam.Visible = true;
                        //viewData(Request.QueryString["CndNo"].ToString().Trim());
                        FillOldExmDtls(Request.QueryString["CndNo"].ToString().Trim());
                        lblTitle.Text = "ReExamination Details";
                        tblupload.Visible = true;
                        divUpload.Visible = true;
                        lblTitle.Visible = false;
                   
                    // added by pallavi on 07102022
                    Bindgridview();
                        //Filluploadedfile();
                        //SetInitialRow();//fees details
                        //BindFeesDetails();
                        Chkpan.Visible = false;//added by pranjali on 29-04-2014 for hiding is pan registered name dtls
                        lblpandetail.Visible = false;//added by pranjali on 29-04-2014 for hiding is pan registered name dtls
                        DataSet ds_candtype = new DataSet();
                        ds_candtype.Clear();
                        htParam.Clear();
                        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", htParam);
                        htParam.Clear();
                        if (ds_candtype.Tables[0].Rows[0]["ReExmType"].ToString().Trim() == "V")
                        {
                            DataSet dsSysDt = new DataSet();
                            htParam.Add("@ReExmFlag", "Y");
                            htParam.Add("@IsTCCvalid", "Y");
                            htParam.Add("@CndType", ds_candtype.Tables[0].Rows[0]["CandType"].ToString().Trim());
                            dsSysDt = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetSystemExmDt", htParam);
                            if (dsSysDt.Tables[0].Rows.Count > 0)
                            {
                                lblNWExmdtValue.Text = dsSysDt.Tables[0].Rows[0]["SysExmDt"].ToString().Trim();
                            }
                        }
                        //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 Start
                         //GetCandidateType();
                        //if (strCndType == "F" || strCndType == "C")
                        //{
                        //    ChkFeesWavier.Enabled = true;// added by usha for disable checkbox on 22.12.2015
                        //}
                        //if (IsPriorAgt == "1")
                        //{
                        //    ChkFeesWavier.Enabled = false;
                        //}
                        //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 End
                        //added by amruta for feeswaiver on 18.12.15 start
                        DataSet ds_feesDt = new DataSet();
                        Hashtable htfeesdt = new Hashtable();
                        htfeesdt.Add("@ReExmFlag", "Y");
                        ds_feesDt = dataAccessRecruit.GetDataSetForPrcRecruit("prc_chkFeesDt", htfeesdt);

                        //if (ds_feesDt.Tables[0].Rows.Count > 0)
                        //{
                        //    if (ds_feesDt.Tables[0].Rows[0]["Flag"].ToString() == "1")
                        //    {
                        //        ChkFeesWavier.Enabled = true;
                        //    }
                        //    else
                        //    {
                        //        ChkFeesWavier.Enabled = false;
                        //    }
                        //} commit by pallavi fees wavier is remove as ask by usha.
                        //added by amruta for feeswaiver on 18.12.15 end
                    }
                    #endregion
 //Added by pranjali on 18-10-2014 for license upload download start
                    #region Agent lic & ID Upload
                    if (Request.QueryString["ACT"] == "LicUpload")
                    {
                        tblICMManual.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        Code = Request.QueryString["Code"].ToString();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        trTCCase.Visible = true;
                        tblupload.Visible = true;
                        divUpload.Visible = true;
                        dgView.Visible = true;
                        btnFinish.Visible = false;
                        tbltrn.Visible = false;
                        tblRenewalCollapse.Visible = false;
                        divRenewal.Visible = false;
                        btnSubmit.Visible = true;
                        tblExmsdtls.Visible = false;
                        divAgnPhotoTrnExmDtl.Visible = false;
                        Chkpan.Enabled = false;
                        Bindgridview();
                        SetInitialRow();
                        trReq.Visible = false;
                        LinkButton1.Visible = false;
                        trdownld.Visible = false;
                        lblCndView.Visible = true;
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        lblTitle.Text = "Candidate Details";
                        CompositeTitle.Visible = false;
                    }
                    #endregion

                    #region Agent Lic & ID Download
                    else if (Request.QueryString["ACT"] == "LicDownload")
                    {
                        tblICMManual.Visible = false;
                        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                        btnSubmit.Attributes.Add("onClick", "Javascript:return Validation();");
                        Code = Request.QueryString["Code"].ToString();
                        btnClear.Visible = false;
                        tr_DocumentDownload.Visible = true;
                        trTCCase.Visible = true;
                        tblDwnld.Visible = true;
                        divDwnld.Visible = true;
                        CompositeTitle.Visible = false;
                        //Hashtable htdtls = new Hashtable();
                        //htdtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        //DataSet dsdtls = new DataSet();
                        //dsdtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htdtls);
                        //if (dsdtls.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() == "F")
                        //{
                        //    tblupload.Visible = false;
                        //    divUpload.Visible = false;
                        //    Table2.Visible = false;
                        //    divReUpload.Visible = false;
                        //}
                        //else
                        //{
                        //    tblupload.Visible = true;
                        //    divUpload.Visible = true;
                        //    Bindgridview();
                        //}
                        tbltrn.Visible = false;
                        tblRenewalCollapse.Visible = false;
                        divRenewal.Visible = false;
                        tblExmsdtls.Visible = false;
                        divAgnPhotoTrnExmDtl.Visible = false;
                        Chkpan.Enabled = false;
                        BindgridviewDwnld();
                        SetInitialRow();
                        btnSubmit.Visible = false;
                        btnFinish.Visible = false;
                        tblCheck.Visible = false;
                        chckDwnld.Visible = true;
                        chckDwnld.Enabled = true;
                        trReq.Visible = false;
                        LinkButton1.Visible = false;
                        lblCndView.Visible = true;
                        trnsfrtitle.Visible = false;
                        divTrnsferDetails.Visible = false;
                        lblTitle.Text = "Candidate Details";
                    }
                    #endregion
                    //Added by kalyani  on 21/04/2014 for Preffered exam details end
                }
                //btn_Upload.Attributes.Add("onclick", "javascript:return StartProgressBar()");  //added by pranjali on 26-04-2014
                //BtnReUpload.Attributes.Add("onclick", "javascript:return StartProgressBar()");  //added by pranjali on 26-04-2014
                btnExmCentre.Attributes.Add("onclick", "funcShowPopup('ExmCentre');return false;");
                txtExmdt1.Attributes.Add("readonly", "readonly");
                txtExmdt1.Attributes.Add("style", "background-color: white");

            divPDH.Attributes.Add("style", "color:#00cccc !important;");
            span2.Attributes.Add("style", "background-color: #00cccc !important");
            span9.Attributes.Add("style", "background-color: #8c8c8c !important");

        }
        FillData(Request.QueryString["CndNo"].ToString().Trim());//added by meena 9_5_18
        
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

            lblTitle.Text = olng.GetItemDesc("lblTitle.text");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");

            //lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblCndNo.Text = "Candidate No";
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            lblBranch.Text = olng.GetItemDesc("lblBranch");
            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblMobileNo.Text = olng.GetItemDesc("lblMobileNo");
            lblEmail.Text = olng.GetItemDesc("lblEmail");
            lblPAN.Text = olng.GetItemDesc("lblPAN");
            lblCnddtls.Text = olng.GetItemDesc("lblCnddtls");
            lblcndupload.Text = olng.GetItemDesc("lblcndupload");
            lblReqStatus.Text = olng.GetItemDesc("lblReqStatus");
            lblWebTknReceived.Text = olng.GetItemDesc("lblWebTknReceived");
            lblLicnno.Text = olng.GetItemDesc("lblLicnno");
            lblLicExpDt.Text = olng.GetItemDesc("lblLicExpDt");
            lblcndDnwld.Text = olng.GetItemDesc("lblcndDnwld");
            lblOldLcnexpDate.Text = olng.GetItemDesc("lblOldLcnexpDate");
            lblComplicnseExpDt.Text = olng.GetItemDesc("lblComplicnseExpDt");
            lblAckrcv.Text = olng.GetItemDesc("lblAckrcv");
            lblpreexamlng.Text = olng.GetItemDesc("lblpreexamlng");//added by pranjali on 25-04-2014
            lblNpreexamlng.Text = olng.GetItemDesc("lblNpreexamlng");//added by pranjali on 25-04-2014
            lblOExam.Text = olng.GetItemDesc("lblOExam");//added by pranjali on 25-04-2014
            lblNExam.Text = olng.GetItemDesc("lblNExam");//added by pranjali on 25-04-2014
            lblExmBody.Text = olng.GetItemDesc("lblExmBody");//added by pranjali on 25-04-2014
            lblNExmBody.Text = olng.GetItemDesc("lblNExmBody");//added by pranjali on 25-04-2014
            lblCentre.Text = olng.GetItemDesc("lblCentre");//added by pranjali on 25-04-2014
            lblNCentre.Text = olng.GetItemDesc("lblNCentre");//added by pranjali on 25-04-2014
            lblNWExmdt.Text = olng.GetItemDesc("lblExmDt");//added by pranjali on 25-04-2014
            //Added by kalyani  on 21/04/2014 for Preffered exam details start
            //if ((Request.QueryString["Type"] == "E")||(Request.QueryString["Type"] == "ReExam"))
            //{
                lblTrnInstitute.Text = olng.GetItemDesc("lblTrnInstitute");
                lblTrnLoc.Text = olng.GetItemDesc("lblTrnLoc");
                lblTrnMode.Text = olng.GetItemDesc("lblTrnMode");
                lblExmDt.Text = olng.GetItemDesc("lblExmDt");
            //}
            //Added by kalyani  on 21/04/2014 for Preffered exam details end
            //added  by shreela on 25042014 start
            //renewal details
            lblCndType.Text = olng.GetItemDesc("lblCndType");
            lblQCRenewType.Text = olng.GetItemDesc("lblQCRenewType");
            lblCount.Text = olng.GetItemDesc("lblCount");
            lblQClyfTraining.Text = olng.GetItemDesc("lblQClyfTraining");
            //Exam details
            lblExamrenew.Text = olng.GetItemDesc("lblExamrenew");
            lblExmBodyrenew.Text = olng.GetItemDesc("lblExmBodyrenew");
            lblpreexamlngrenew.Text = olng.GetItemDesc("lblpreexamlngrenew");
            lblCentrerenew.Text = olng.GetItemDesc("lblCentrerenew");
            //added  by shreela on 25042014 end
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


    //added by pranjali on 25-04-2014 for exam mode start
    #region Exam Mode
    private void PopulateExamMode()
    {
        try
        {

            oCommon.getDropDown(ddlNExam, "ExmMode", 1, "", 1);
            ddlNExam.Items.Insert(0, "Select");
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
    //added by pranjali on 25-04-2014 for exam mode end

    //added by pranjali on 25-04-2014 for ExmBodyName start

    #region PopulateExmBodyName()
    private void PopulateExmBodyName()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmBody");
            ddlNExmBody.DataSource = dsresult;
            ddlNExmBody.DataTextField = "ExmBody";
            ddlNExmBody.DataValueField = "ExmBodyCode";
            ddlNExmBody.DataBind();
            ddlNExmBody.Items.Insert(0, "Select");
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

    //added by pranjali on 25-04-2014 for ExmBodyName end

    //added by pranjali on 25-04-2014 for ExmLanguages start

    #region PopulatePreExmLanguages()
    private void PopulatePreExmLanguages()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetExmLang");
            ddlNpreeamlng.DataSource = dsresult;
            ddlNpreeamlng.DataTextField = "Language";
            ddlNpreeamlng.DataValueField = "Language";
            ddlNpreeamlng.DataBind();
            ddlNpreeamlng.Items.Insert(0, "Select");
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

    //added by pranjali on 25-04-2014 for ExmLanguages end

    //added by pranjali on 25-04-2014 for exam centre start
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
            ddlExmCentre.Items.Insert(0, "Select");
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
    //added by pranjali on 25-04-2014 for exam centre end
    //#region FillData
    protected void FillData(string strCndNo)
    {//Method to fill data on click of renewal or renewals
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

                        HdnTccDate.Value = dsResult.Tables[0].Rows[0]["TccDate"].ToString().Trim();//Added by kalyani for Preffered Exam Date 1 
                        ViewState["waiverflag"] = dsResult.Tables[0].Rows[0]["WaiverFlag"].ToString().Trim();
                        HdnLicTccDate.Value = dsResult.Tables[0].Rows[0]["LicTccDate"].ToString().Trim();
                        
                        hdnCndName.Value = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        ViewState["TCC"]=dsResult.Tables[0].Rows[0]["TCCflag"].ToString().Trim();//Addedd by kalyani
                        lblExmDtValue.Text = dsResult.Tables[0].Rows[0]["SystemExmDt"].ToString().Trim();//Addedd by kalyani
                        hdnRecruitAgntCode.Value = dsResult.Tables[0].Rows[0]["RecruitAgtCode"].ToString().Trim();
                        lblTrnInstituteValue.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                        lblTrnLocValue.Text = dsResult.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                        lblTrnModeValue.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                        hdnPanDtls.Value = dsResult.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();
                        hdnBizSrc.Value = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                        lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        string branchname;
                        branchname = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();
                        string cmsunitcode;
                        cmsunitcode = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim();
                        string branch = branchname + "(" + cmsunitcode + ")";
                        lblBranchValue.Text = branch;
                        //hdnBranchCode.Value = dsResult.Tables[0].Rows[0]["RecruitUnitCode"].ToString().Trim(); 
                        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["SMName"].ToString().Trim();  
                        lblReqStatusValue.Text = dsResult.Tables[0].Rows[0]["Status"].ToString().Trim();
                        //added by shreela on 25042014
                        lblCndVal.Text = dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim();
                        lblCountVal.Text = dsResult.Tables[0].Rows[0]["RenewalCnt"].ToString().Trim();
                        lblAccvalue1.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                        lblTrnHrsValue1.Text = dsResult.Tables[0].Rows[0]["ParamDesc01"].ToString().Trim();
                        if (dsResult.Tables[0].Rows[0]["Cand_TypeDesc"].ToString().Trim() == "Composite")
                        {
                            trCompQC.Visible = true;
                            lbltxtQCRenewType.Text = dsResult.Tables[0].Rows[0]["RenewalType"].ToString().Trim();
                            if (lbltxtQCRenewType.Text == "Leader")//shree
                            {
                                lbltxtQClyfTraining.Text = dsResult.Tables[0].Rows[0]["LifeTrainingCompleted"].ToString().Trim();
                            }
                            else
                            {
                                lblQClyfTraining.Visible = false;//shree
                                lbltxtQClyfTraining.Visible = false;//shree
                            }
                        }
                        //added by shreela on 25042014

                        ddlNExmBody.Items.Insert(0, "Select");
                        ddlNpreeamlng.Items.Insert(0, "Select");
                        ddlExmCentre.Items.Insert(0, "Select");

                        //added by shreela 
                        //if (Request.QueryString["Type"].ToString().Trim() == "RenTrn")
                        //{
                        //    Hashtable htupdw = new Hashtable();
                        //    DataSet dsupdw = new DataSet();
                        //    //htupdw.Add("@CndNo", strCndNo);
                        //    htupdw.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        //    dsupdw = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetTrnDtls", htupdw);
                        //    if (dsupdw != null)
                        //    {
                        //        if (dsupdw.Tables.Count > 0)
                        //        {
                        //            if (dsupdw.Tables[0].Rows.Count > 0)
                        //            {
                        //                lblTrnModeValue.Text = dsupdw.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                        //                lblTrnInstituteValue.Text = dsupdw.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                        //                lblTrnLocValue.Text = dsupdw.Tables[0].Rows[0]["TrainingLoc"].ToString().Trim();
                        //                lblAccvalue1.Text = dsupdw.Tables[0].Rows[0]["AccrdNo"].ToString().Trim();
                        //                lblTrnHrsValue1.Text = dsupdw.Tables[0].Rows[0]["HrsTrn"].ToString().Trim();
                        //            }
                        //        }
                        //    }

                        //}
                        if (dsResult.Tables[0].Rows[0]["IsPanFlag"].ToString() == "1")
                        {
                            Chkpan.Checked = true;
                            Chkpan.Enabled = false;
                        }
                        else
                        {
                            Chkpan.Checked = false;
                        }
                       if (Request.QueryString["Type"].ToString().Trim().ToUpper() != "N")
                        {
                            lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString()).Trim();
                        }
                        else
                        {
                            lblSponsorDtValue.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"].ToString()).Trim();
                        }
                        txtMobileNo.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();
                        txtMobileNo.Enabled = false;
                        //btnverifymobile.CssClass = "btn btn-xs btn-primary disabled";
                        btnverifymobile.Enabled = false;
                        txtEMail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                        txtEMail.Enabled = false;
                        //btnverifyemail.CssClass = "btn btn-xs btn-primary disabled";
                        btnverifyemail.Enabled = false;
                        txtlicno.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                        //txtlicno.Enabled = false;
                        txtLicExpDt.Text = dsResult.Tables[0].Rows[0]["LicExpDate"].ToString().Trim();
                        //txtLicExpDt.Enabled = false;

                        lblCndURNVal.Text = dsResult.Tables[0].Rows[0]["CndURN"].ToString().Trim();//added by shreela on 03/07/2014

                        #region transfer/composite details fill
                        if
                         (dsResult.Tables[0].Rows[0]["TrnsfrFlag"] != null)
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
                                           txtDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                        }
                                    }
                                }

                                else
                                {
                                    cbTrfrFlag.Checked = false;
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
                                    divCompositeDetails.Visible = true;
                                    CompositeTitle.Visible = true;
                                    txtCompLicNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicNo"]).Trim();
                                   
                                    if (dsResult.Tables[0].Rows[0]["CompLicExpDt"] != null)
                                    {
                                        if (dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString().Trim() != "")
                                        {
                                            txtCompLicExpDt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"])).ToString(CommonUtility.DATE_FORMAT);
                                        }
                                    }
                                 
                                    ddlCompInsurerName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CompInsrName"]).Trim();
                                 
                                    if (dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                                    {
                                        chkCompAgnt.Checked = true;
                                    }
                                    else
                                    {
                                        chkCompAgnt.Checked = false;
                                    }
                                  
                                }
                                else
                                {
                                   
                                    cbTccCompLcn.Checked = false;
                                    divCompositeDetails.Visible = false;
                                }
                            }
                        }
                       

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
                        #endregion

                        if (dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim() != "")
                        {
                            txtPAN.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                            txtPAN.Enabled = false;
                        }
                        else
                        {
                            htParam.Clear();
                            DataSet dsPanUpdate = new DataSet();
                            DataAccessClass objDAL = new DataAccessClass();
                            htParam.Add("@CndNo", dsResult.Tables[0].Rows[0]["cndno"].ToString());
                            dsPanUpdate = objDAL.GetDataSetForPrc("prc_GetRejectPanUpdate", htParam);
                            if (dsPanUpdate.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(dsPanUpdate.Tables[0].Rows[0]["Flag"]) == "Y")
                                {
                                    txtPAN.Enabled = true;
                                }
                                else
                                {
                                    if (dsPanUpdate.Tables[0].Rows.Count > 0)
                                    {
                                        txtPAN.Text = dsPanUpdate.Tables[0].Rows[0]["PAN"].ToString().Trim();
                                        txtPAN.Enabled = false;

                                    }
                                }
                            }
                         }
                        //added by rachana on 11/04/2014 for enable / disable fees chk box chkWebTknRecd start
                        #region enable / disable fees chk box chkWebTknRecd
                        //if (Request.QueryString["Type"].ToString().Trim() == "RenTrn")
                        //{
                            
                           
                           
                        //}
                           
                            
                        
                        //added by rachana on 11/04/2014 for enable / disable fees chk box chkWebTknRecd end
                        #endregion
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
    //#endregion
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
            //AdvWaiverUpload.Visible = true; //commented by pranjali on 26-04-2014
            spwaiver.Visible = true;
        }
        else
        {
            hdnWebTkn.Value = "0";
            chkWebTknRecd.Visible = true;
            lblWebTknReceived.Visible = true;
            spwebtoken.Visible = true;
            lbladvWaiverbtn.Visible = false;
            //AdvWaiverUpload.Visible = false; //commented by pranjali on 26-04-2014
            spwaiver.Visible = false;
        }
    }
    #endregion

    //added by pranjali on 25-04-2014 
    #region
    protected void lnkmandtry_click(object sender, EventArgs e)
    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            if (Request.QueryString["Type"].ToString().Trim() == "RenTrn")
            {
                Hashtable ht = new Hashtable();
                DataSet ds_panchayat = new DataSet();
                ht.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPanchayatCheck", ht);
                DataSet dsdtl = new DataSet();
                //httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsdtl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", ht);
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@RenwlFlag", Convert.ToString(dsdtl.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                htParam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
                htParam.Add("@Panchayat", ds_panchayat.Tables[0].Rows[0]["Panchayat"].ToString());
                htParam.Add("@ModuleCode", Code.Trim());
                htParam.Add("@TypeofDoc", "UPLD");
                htParam.Add("@ReExmFlag", "N");
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMandatoryDoc", htParam);
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "ReExam")
            {
                Hashtable ht = new Hashtable();
                DataSet ds_panchayat = new DataSet();
                ht.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPanchayatCheck", ht);
                DataSet dsdtl = new DataSet();
                //httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                dsdtl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", ht);
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@RenwlFlag", "N");
                htParam.Add("@InsurerType", Convert.ToString(dsdtl.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@PanFlag", Chkpan.Checked == true ? "1" : "0");
                htParam.Add("@Panchayat", ds_panchayat.Tables[0].Rows[0]["Panchayat"].ToString());
                htParam.Add("@ModuleCode", Code.Trim());
                htParam.Add("@TypeofDoc", "UPLD");
                htParam.Add("@ReExmFlag", "Y");
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMandatoryDoc", htParam);
            }
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgDetails1.DataSource = dsResult.Tables[0];
                dgDetails1.DataBind();
            }
            else
            {
                lblmsg.Text = "No Mandatory Documents";
                lblmsg.Visible = true;
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
    #endregion
    //added by pranjali on 26-04-2014 
    protected void lblCndView_Click(object sender, EventArgs e)
    {
        string strWindow = "window.open('CndView.aspx?Type=Other&Act=Edit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
    }
    //added by pranjali on 26-04-2014 
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

    #region GetDataTableForUplds
    protected DataTable GetDataTableForUplds()
    {
        DataSet dsUpdDocPgIndxng = new DataSet();
        try
        {
            dsResult.Clear();
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            Hashtable htparam = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);

            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim());
            if (Request.QueryString["Type"].Trim() == "ReExam")
            {
                htparam.Add("@TypeofDoc", "UPLD");
                //htparam.Add("@RenwlFlag","N");
                htparam.Add("@InsurerType", "");
                //htparam.Add("@ReExmFlag", "Y");
                htparam.Add("@ProcessType", "RE");
            }
            else
            {
                if (Request.QueryString["ACT"].Trim() == "Upload")
                {
                    htparam.Add("@TypeofDoc", "UPLD");
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    //htparam.Add("@ReExmFlag", "N");
                    htparam.Add("@ProcessType", "RW");
                }
                else
                {
                    htparam.Add("@TypeofDoc", "UPLD");//shree07
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    //htparam.Add("@ReExmFlag", "N");
                    htparam.Add("@ProcessType", "RW");
                }
            }
            dsUpdDocPgIndxng = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam);
            //if (Request.QueryString["Type"].Trim() == "ReExam")
            //{
            if (dsUpdDocPgIndxng.Tables.Count > 0)
            {
                if (dsUpdDocPgIndxng.Tables[0].Rows.Count > 0)
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
        return dsUpdDocPgIndxng.Tables[0];

    }
    #endregion

    #region dgView RowDataBound
    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblupdSize = (Label)e.Row.FindControl("lblupdSize");
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
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            DataSet dsdtl = new DataSet();
            dsdtl = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            Hashtable htparam = new Hashtable();
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
           // htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
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
                htparam.Add("@InsurerType","");
                htparam.Add("@ProcessType", "RE");
            }
	//Added by pranjali on 18-10-2014 for license upload download start
            else if (Request.QueryString["Type"].ToString().Trim() == "License")
            {
                if (dsdtl.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() != "")
                {
                    htparam.Add("@InsurerType", dsdtl.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                }
                else
                {
                    htparam.Add("@InsurerType", "");
                }
                htparam.Add("@ProcessType", dsdtl.Tables[0].Rows[0]["ProcessType"].ToString().Trim());
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
			lnkPreview.Visible = false;
                    }
                }
            }
        }
    }
    #endregion

	protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Preview")
            {
                string Preview = e.CommandArgument.ToString().Trim();
                string CndNo = Request.QueryString["CndNo"].ToString().Trim();
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lbldocName = (Label)row.FindControl("lbldocName");
                string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&CndNo=" + CndNo.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
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

    #region GetDataTableForReUplds
    protected DataTable GetDataTableForReUplds()
    {
        try
        {

            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            dsResult.Clear();
            ds_documentName.Clear();//shree07
            Code = Request.QueryString["Code"].ToString();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);//shree07
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            if (ds_candtype.Tables[0].Rows[0]["CandType"].ToString().Trim() == "F")
            {
                trnsfrtitle.Visible = false;
                divTrnsferDetails.Visible = false;
                CompositeTitle.Visible = false;
                divCompositeDetails.Visible = false;
            }
            else if (ds_candtype.Tables[0].Rows[0]["CandType"].ToString().Trim() == "T")
            {
                CompositeTitle.Visible = false;
                divCompositeDetails.Visible = false;
            }
            else
            {
                trnsfrtitle.Visible = false;
                divTrnsferDetails.Visible = false;
            }

            Code = Request.QueryString["Code"].ToString();
            htParam.Add("@ModuleCode", Code.Trim());
            if (Request.QueryString["Type"].Trim() == "ReExam")
            {
                htParam.Add("@TypeofDoc", "UPLD");
                //htParam.Add("@RenwlFlag","N");
                htParam.Add("@InsurerType", "");
                //htParam.Add("@ReExmFlag", "Y");
                htParam.Add("@ProcessType", "RE");
            }
            else
            {
                if (Request.QueryString["ACT"].Trim() == "Upload")
                {
                    htParam.Add("@TypeofDoc", "UPLD");
                    //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                    htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                    //htParam.Add("@ReExmFlag", "N");
                    htParam.Add("@ProcessType", "RW");
                }
                else
                {
                    Hashtable htren = new Hashtable();
                    DataSet dsren = new DataSet();
                    htren.Add("@Code", Request.QueryString["Code"].ToString().Trim());
                    dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImgShrtCode", htren);
                    if (dsren.Tables[0].Rows[0]["ShrtCode"].ToString().Trim() == "24")
                    {
                        htParam.Add("@TypeofDoc", "UPLD");
                        //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                        htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                        //htParam.Add("@ReExmFlag", "N");
                        htParam.Add("@ProcessType", "RW");
                    }
                    else
                    {
                        htParam.Add("@TypeofDoc", "DWNLD");
                        //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                        htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                        //htParam.Add("@ReExmFlag", "N");
                        htParam.Add("@ProcessType", "RW");
                    }


                }
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);
            if (Request.QueryString["Type"].Trim() == "ReExam")
            {
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
            else
            {
                if (Request.QueryString["ACT"].Trim() == "Upload")
                {
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
                else
                {
                    Hashtable htren = new Hashtable();
                    DataSet dsren = new DataSet();
                    htren.Add("@Code", Request.QueryString["Code"].ToString().Trim());
                    dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImgShrtCode", htren);
                    if (dsren.Tables[0].Rows[0]["ShrtCode"].ToString().Trim() == "24")
                    {
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
                    else
                    {
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                dgDwnld.DataSource = dsResult.Tables[0];
                                dgDwnld.DataBind();
                                BindgridviewDwnld();
                            }
                            else
                            {
                                BindgridviewDwnld();
                            }
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
        return dsResult.Tables[0];
    }
    #endregion

    #region GridView1 RowDataBound
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
    #endregion

    #region dgDwnld PageIndexChanging
    protected void dgDwnld_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForDwnld();
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

    #region GetDataTableForDwnld
    protected DataTable GetDataTableForDwnld()
    {
        try
        {
            dsResult.Clear();
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            Hashtable htparam = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
            htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim());
            if (Request.QueryString["ACT"].Trim() == "Upload")
            {
                htparam.Add("@TypeofDoc", "UPLD");
            }
            else
            {
                htparam.Add("@TypeofDoc", "DWNLD");
            }
            //htparam.Add("@ReExmFlag", "N");
            htparam.Add("@ProcessType", "RW");
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htparam);
            if (Request.QueryString["ACT"].Trim() == "Upload")
            {
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
            else
            {
                if (ds_documentName.Tables.Count > 0)
                {
                    if (ds_documentName.Tables[0].Rows.Count > 0)
                    {
                        dgDwnld.DataSource = ds_documentName.Tables[0];
                        dgDwnld.DataBind();
                    }
                    else
                    {
                        dgDwnld.DataSource = null;
                        dgDwnld.DataBind();
                        tblDwnld.Visible = false;
                    }
                }
                else
                {
                    dgDwnld.DataSource = null;
                    dgDwnld.DataBind();
                    tblDwnld.Visible = false;
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
        return ds_documentName.Tables[0];
    }
    #endregion

   

    #region Button Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] == "E")
        {
            String ModuleID = string.Empty;
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();

            Response.Redirect("CndEnq.aspx?Type=PREFFEXM&ModuleID="+ ModuleID);
            //Added by pallavi on 13.12.2022


        }
        else if (Request.QueryString["ACT"] == "Upload")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        else if (Request.QueryString["ACT"] == "Download")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
            //Response.Redirect("CndEnq.aspx?ACT=Upload&Type=RenTrn"); 
        }
        else if (Request.QueryString["ACT"] == "Dwnld")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
            //Response.Redirect("CndEnq.aspx?ACT=Upload&Type=RenTrn"); 
        }
        else if (Request.QueryString["Type"] == "ReExam")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
    }
    #endregion

    #region Bindgridview
    private void Bindgridview()
    {
        try
        {
            dsResult.Clear();
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            Hashtable htparam = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim());
            if (Request.QueryString["Type"].Trim() == "ReExam")
            {
                htparam.Add("@TypeofDoc", "UPLD");
                //htparam.Add("@RenwlFlag","N");
                htparam.Add("@InsurerType","");
                //htparam.Add("@ReExmFlag", "Y");
                htparam.Add("@ProcessType", "RE");
            }
	//Added by pranjali on 18-10-2014 for license upload download start
            else if (Request.QueryString["Type"].ToString().Trim() == "License")
            {
                htparam.Add("@ProcessType", dsResult.Tables[0].Rows[0]["ProcessType"].ToString().Trim());
                if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() != "")
                {
                    htparam.Add("@InsurerType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                }
                else
                {
                    htparam.Add("@InsurerType", "");
                }


                if (Request.QueryString["ACT"].Trim() == "LicUpload")
                {
                    htparam.Add("@TypeofDoc", "UPLD");
                }
                else
                {
                    htparam.Add("@TypeofDoc", "DWNLD");
                }
            }
            else
            {
                if (Request.QueryString["ACT"].Trim() == "Upload")
                {
                    htparam.Add("@TypeofDoc", "UPLD");
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    //htparam.Add("@ReExmFlag", "N");
                    htparam.Add("@ProcessType", "RW");
                }
                else
                {
                    htparam.Add("@TypeofDoc", "UPLD");//shree07
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    //htparam.Add("@ReExmFlag", "N");
                    htparam.Add("@ProcessType", "RW");
                }
            }
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam);
            //if (Request.QueryString["Type"].Trim() == "ReExam")
            //{
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
			//trReq.Visible = true;
                    }
                }
                else
                {
                    dgView.DataSource = null;
                    dgView.DataBind();
                    tblupload.Visible = false;
		    //trReq.Visible = true;
                }
            //}
            //else
            //{
            //if (Request.QueryString["ACT"].Trim() == "Upload")
            //{
            //    if (ds_documentName.Tables.Count > 0)
            //    {
            //        if (ds_documentName.Tables[0].Rows.Count > 0)
            //        {
            //            dgView.DataSource = ds_documentName.Tables[0];
            //            dgView.DataBind();
            //        }
            //        else
            //        {
            //            dgView.DataSource = null;
            //            dgView.DataBind();
            //            tblupload.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        dgView.DataSource = null;
            //        dgView.DataBind();
            //        tblupload.Visible = false;
            //    }
            //}
            //else
            //{
            //    if (ds_documentName.Tables.Count > 0)
            //    {
            //        if (ds_documentName.Tables[0].Rows.Count > 0)
            //        {
            //            dgView.DataSource = ds_documentName.Tables[0];
            //            dgView.DataBind();
            //        }
            //        else
            //        {
            //            dgView.DataSource = null;
            //            dgView.DataBind();
            //            tblupload.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        dgView.DataSource = null;
            //        dgView.DataBind();
            //        tblupload.Visible = false;
            //    }

            //}
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
    #endregion

    #region BindgridviewDwnld
    private void BindgridviewDwnld()
    {
        try
        {
            dsResult.Clear();
            Code = Request.QueryString["Code"].ToString();
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            Hashtable htparam = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
            //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
            htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim());
           
            if (Request.QueryString["ACT"].Trim() == "Upload" || Request.QueryString["ACT"].ToString().Trim() == "LicUpload")
            {
                htparam.Add("@TypeofDoc", "UPLD");
            }
            else
            {
                htparam.Add("@TypeofDoc", "DWNLD");
            }
            //htparam.Add("@ReExmFlag", "N");
            htparam.Add("@ProcessType", Convert.ToString(dsResult.Tables[0].Rows[0]["ProcessType"]).ToString().Trim());
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htparam);
            if (Request.QueryString["ACT"].Trim() == "Upload")
            {
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
            else
            {
                if (ds_documentName.Tables.Count > 0)
                {
                    if (ds_documentName.Tables[0].Rows.Count > 0)
                    {
                        dgDwnld.DataSource = ds_documentName.Tables[0];
                        dgDwnld.DataBind();
                    }
                    else
                    {
                        dgDwnld.DataSource = null;
                        dgDwnld.DataBind();
                        tblDwnld.Visible = false;
                    }
                }
                else
                {
                    dgDwnld.DataSource = null;
                    dgDwnld.DataBind();
                    tblDwnld.Visible = false;
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

    #region Button Download
    protected void btn_Dwnld_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
        FileUpload fuData = (FileUpload)row.FindControl("FileDwnld");
        Label lbldocName = (Label)row.FindControl("lbldocName");
        Label lblUpldBy = (Label)row.FindControl("lblUpldBy");
        Label lblUpdDtTm = (Label)row.FindControl("lblUpdDtTm");
        Label lblFileName = (Label)row.FindControl("lblFileName");
        Label lblimgshrt1 = (Label)row.FindControl("lblimgshrt1");
        //String strDocName=(String)row.FindControl("lbldocName");
        htParam.Clear();
        htParam.Add("@DocType",lbldocName.Text.ToString().Trim());
        dsResult.Clear();
        ds_documentName.Clear();
        string strCndPath = string.Empty;
        string strFilePath=string.Empty;
       // ds_documentName=dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetCndNoRenwl",htParam);//shree07
        // htParam.Add("@Cndno", Convert.ToString(ds_documentName.Tables[0].Rows[0]["CndNo"]).Trim());//shree07
        htParam.Add("@Cndno", Request.QueryString["CndNo"].ToString().Trim());//shree07
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetRenewlImage", htParam);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                string strImgPath = string.Empty;
                string strImg = string.Empty;
                strPath = strPath + "\\";
                strImgPath = strPath + dsResult.Tables[0].Rows[0]["ServerFileName"];
                strFileName = dsResult.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                Response.ContentType = "image/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName + "");
                Byte[] bytes1 = (Byte[])dsResult.Tables[0].Rows[0]["Images"];
                Response.ContentType = "image/pdf";
                Response.OutputStream.Write(bytes1, 0, bytes1.Length);

                htParam.Clear();
                htParam.Add("@Cndno", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@ServerFileName", dsResult.Tables[0].Rows[0]["ServerFileName"].ToString().Trim());
                htParam.Add("@DocType", lbldocName.Text.ToString().Trim());
                htParam.Add("@DownloadedBy", Session["UserID"].ToString().Trim());
		//Added by pranjali on 18-10-2014 for license upload download start
                htParam.Add("@DocCode", lblimgshrt1.Text.ToString().Trim());
                ds_documentName.Clear();
                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("prc_InsTccDwnldDtls", htParam);

                Response.Flush();
                Response.End();
             }
        }
     }
    #endregion

    //shree07
    #region Filluploadedfile
    protected void Filluploadedfile() //string lbldocname
    {
        try
        {
           
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                dsResult.Clear();
                ds_documentName.Clear();//shree07
                Code = Request.QueryString["Code"].ToString(); 
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);//shree07
                htParam.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                if (ds_candtype.Tables[0].Rows[0]["CandType"].ToString().Trim() == "F")
                {
                    trnsfrtitle.Visible = false;
                    divTrnsferDetails.Visible = false;
                    CompositeTitle.Visible = false;
                    divCompositeDetails.Visible = false;
                }
                else if (ds_candtype.Tables[0].Rows[0]["CandType"].ToString().Trim() == "T")
                {
                    CompositeTitle.Visible = false;
                    divCompositeDetails.Visible = false;
                }
                else
                {
                    trnsfrtitle.Visible = false;
                    divTrnsferDetails.Visible = false;
                }
               
                Code = Request.QueryString["Code"].ToString();
                htParam.Add("@ModuleCode", Code.Trim());
                if (Request.QueryString["Type"].Trim() == "ReExam")
                {
                    htParam.Add("@TypeofDoc", "UPLD");
                    //htParam.Add("@RenwlFlag","N");
                    htParam.Add("@InsurerType", "");
                    //htParam.Add("@ReExmFlag", "Y");
                    htParam.Add("@ProcessType", "RE");
                }
                else
                {
                    if (Request.QueryString["ACT"].Trim() == "Upload")
                    {
                        htParam.Add("@TypeofDoc", "UPLD");
                        //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                        htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                        //htParam.Add("@ReExmFlag", "N");
                        htParam.Add("@ProcessType", "RW");
                    }
                    else 
                    {
                        Hashtable htren = new Hashtable();
                        DataSet dsren = new DataSet();
                        htren.Add("@Code", Request.QueryString["Code"].ToString().Trim());
                        dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImgShrtCode", htren);
                        if (dsren.Tables[0].Rows[0]["ShrtCode"].ToString().Trim() == "24")
                        {
                            htParam.Add("@TypeofDoc", "UPLD");
                            //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                            htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                            //htParam.Add("@ReExmFlag", "N");
                            htParam.Add("@ProcessType", "RW");
                        }
                        else
                        {
                            htParam.Add("@TypeofDoc", "DWNLD");
                            //htParam.Add("@RenwlFlag", Convert.ToString(ds_documentName.Tables[0].Rows[0]["RenewalFlag"]).Trim());//shree07
                            htParam.Add("@InsurerType", Convert.ToString(ds_documentName.Tables[0].Rows[0]["InsRenewalType"]).Trim());//shree07
                            //htParam.Add("@ReExmFlag", "N");
                            htParam.Add("@ProcessType", "RW");
                        }

                     
                    }
                }
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploaded_Images", htParam);
                if (Request.QueryString["Type"].Trim() == "ReExam")
                {
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
                else
                {
                    if (Request.QueryString["ACT"].Trim() == "Upload")
                    {
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
                    else
                    {
                        Hashtable htren = new Hashtable();
                        DataSet dsren = new DataSet();
                        htren.Add("@Code", Request.QueryString["Code"].ToString().Trim());
                        dsren = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImgShrtCode", htren);
                        if (dsren.Tables[0].Rows[0]["ShrtCode"].ToString().Trim() == "24")
                        {
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
                        else
                        {
                            if (dsResult.Tables.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    dgDwnld.DataSource = dsResult.Tables[0];
                                    dgDwnld.DataBind();
                                    BindgridviewDwnld();
                                }
                                else
                                {
                                    BindgridviewDwnld();
                                }
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
            chkWebTknRecd.Visible = false;  

        }
        else
        {

            divICM.Attributes.Add("style", "display:block");
            tblICMManual.Attributes.Add("style", "display:block");
         
        }
    }



    #region Patment Mode
    private void PopulateICMPaymentMode()
    {
        try
        {

            oCommon.getDropDown(DDlPymtMode, "DDlPymtMode", 1, "", 1);
            DDlPymtMode.Items.Insert(0, "Select");
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


    #region BindFeesDetails
    private void BindFeesDetails()
    {
        try
        {
            Hashtable htfeesDtls = new Hashtable();
            DataSet dsfeesDtls = new DataSet();
            htfeesDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            dsfeesDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetFeesDetailsforCnd", htfeesDtls);

            if (dsfeesDtls.Tables.Count > 0)
            {
                if (dsfeesDtls.Tables[0].Rows.Count > 0)
                {
                    divFees.Attributes.Add("Style", "display:block");
                    txtFeesRcvd.Text = dsfeesDtls.Tables[0].Rows[0]["Receiptid"].ToString();
                    dgPaymentdtls.DataSource = dsfeesDtls.Tables[0];
                    dgPaymentdtls.DataBind();
                    ViewState["dsfeesDtls"] = dsfeesDtls.Tables[0];
                }
                else
                {


                    dgPaymentdtls.DataSource = null;
                    dgPaymentdtls.DataBind();
                    chkWebTknRecd.Checked = false;
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

    protected void InsertfeesDetails()
    {
        //Added by rachana on 20032014 to Save fees dtls [CndFeesDtls] start
        #region Fees Details Save
        Hashtable htfeesDtls1 = new Hashtable();
        DataSet dsfeesDtls1 = new DataSet();
        htfeesDtls1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
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
                #region if already exist moves to history table and again insert
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {
                    Hashtable Htfees = new Hashtable();
                    Label lblTrxid = (Label)row.FindControl("lblTrxid");
                    Label lblPymtMode = (Label)row.FindControl("lblPymtMode");
                    Label lblRcptId = (Label)row.FindControl("lblRcptId");
                    Label lblPymtAmt = (Label)row.FindControl("lblPymtAmt");
                    Label lblEFTNEFTTrxNo = (Label)row.FindControl("lblEFTNEFTTrxNo");
                    Label lblChqNo = (Label)row.FindControl("lblChqNo");
                    Label lblChqDt = (Label)row.FindControl("lblChqDt");
                    Label lblBankName = (Label)row.FindControl("lblBankName");


                    Htfees.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
                    Htfees.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                    Htfees.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    Htfees.Add("@candType", hdnPanDtls.Value);
                    Htfees.Add("@PayMode", lblPymtMode.Text);
                    Htfees.Add("@ChqDDNo", lblChqNo.Text);
                    Htfees.Add("@ChqDDDate", DateTime.Parse(lblChqDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    Htfees.Add("@Amt", lblPymtAmt.Text);
                    Htfees.Add("@BnkName", lblBankName.Text);
                    Htfees.Add("@TrxId", lblRcptId.Text);
                    if (lblEFTNEFTTrxNo.Text != "")
                    {
                        Htfees.Add("@EFTTrxNo", lblEFTNEFTTrxNo.Text);
                    }
                    else
                    {
                        Htfees.Add("@EFTTrxNo", System.DBNull.Value);
                    }
                    Htfees.Add("@TrxidFK", lblTrxid.Text);
                    Htfees.Add("@TrxDate", System.DateTime.Now);
                    Htfees.Add("@CreatDtime", System.DateTime.Now);
                    Htfees.Add("@UpdatedBy", System.DBNull.Value);
                    Htfees.Add("@UpdatedDtime", System.DBNull.Value);
                    if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                    {
                        Htfees.Add("@Flag", "RE");
                    }
                    else
                    {
                        Htfees.Add("@Flag", "NR");
                    }
                    //x = dataAccessRecruit.execute_sprcrecruit("Prc_InsertFeesDtls", Htfees);
                    string strvalue = dataAccessRecruit.execute_sprc_with_output("Prc_InsertFeesDtls", Htfees, "@strOut");
                    Htfees.Clear();
                }
                #endregion
            }
            else
            {
                #region if already not exist then insert newly
                foreach (GridViewRow row in dgPaymentdtls.Rows)
                {
                    Hashtable Htfees = new Hashtable();
                    Label lblTrxid = (Label)row.FindControl("lblTrxid");
                    Label lblPymtMode = (Label)row.FindControl("lblPymtMode");
                    Label lblRcptId = (Label)row.FindControl("lblRcptId");
                    Label lblPymtAmt = (Label)row.FindControl("lblPymtAmt");
                    Label lblEFTNEFTTrxNo = (Label)row.FindControl("lblEFTNEFTTrxNo");
                    Label lblChqNo = (Label)row.FindControl("lblChqNo");
                    Label lblChqDt = (Label)row.FindControl("lblChqDt");
                    Label lblBankName = (Label)row.FindControl("lblBankName");


                    Htfees.Add("@AppNo", lblAppNoValue.Text.ToString().Trim());
                    Htfees.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                    Htfees.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                    Htfees.Add("@candType", hdnPanDtls.Value);
                    Htfees.Add("@PayMode", lblPymtMode.Text);
                    Htfees.Add("@ChqDDNo", lblChqNo.Text);
                    Htfees.Add("@ChqDDDate", DateTime.Parse(lblChqDt.Text.Trim()).ToString("yyyyMMdd")); //DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd")
                    Htfees.Add("@Amt", lblPymtAmt.Text);
                    Htfees.Add("@BnkName", lblBankName.Text);
                    Htfees.Add("@TrxId", lblRcptId.Text);
                    if (lblEFTNEFTTrxNo.Text != "")
                    {
                        Htfees.Add("@EFTTrxNo", lblEFTNEFTTrxNo.Text);
                    }
                    else
                    {
                        Htfees.Add("@EFTTrxNo", System.DBNull.Value);
                    }
                    Htfees.Add("@TrxidFK", lblTrxid.Text);
                    Htfees.Add("@TrxDate", System.DateTime.Now);
                    Htfees.Add("@CreatDtime", System.DateTime.Now);
                    Htfees.Add("@UpdatedBy", System.DBNull.Value);
                    Htfees.Add("@UpdatedDtime", System.DBNull.Value);
                    if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
                    {
                        Htfees.Add("@Flag", "RE");
                    }
                    else
                    {
                        Htfees.Add("@Flag", "NR");
                    }


                    string strvalue = dataAccessRecruit.execute_sprc_with_output("Prc_InsertFeesDtls", Htfees, "@strOut");
                    Htfees.Clear();
                }
                #endregion
            }
        }



        #endregion
        //Added by rachana on 20032014 to Save fees dtls [CndFeesDtls] end
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
        //getCandidateDetails();
        try
        {
            string strUserID = Session["UserID"].ToString();
            Hashtable htData = new Hashtable();
            DataSet ds = new DataSet();
            ds.Clear();
            if (Request.QueryString["Type"] == "E")
            {
                //Preffed exam request
                htData.Add("@Param1", "PreffExm");
                htData.Add("@Param3", "120");
                if (ViewState["ProcessType"].ToString() == "NR")
                {
                    htData.Add("@Param4", "NR");
                }
                else
                {
                    htData.Add("@Param4", ViewState["ProcessType"].ToString());
                }
            }
            else if (Request.QueryString["Type"].Trim() == "ReExam")
            {
                //Reexam Request Valid
                htData.Add("@Param1", "ReExm");
                htData.Add("@Param3", "50");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
            }
            else if (Request.QueryString["ACT"] == "Upload")
            {
                //TCC Upload
                htData.Add("@Param1", "TccUpld");
                htData.Add("@Param3", "110");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
                htData.Add("@Param5", ViewState["InsRenewalType"].ToString());
            }
            else
            {
                //Tcc Download
                htData.Add("@Param1", "TccDwnld");
                htData.Add("@Param3", "110");
                htData.Add("@Param4", ViewState["ProcessType"].ToString());
            }
            htData.Add("@Param2", ViewState["CandType"].ToString());

            ds = dataAccessRecruit.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                        //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                        if (Request.QueryString["Type"] == "E")
                        {
                            objmailcomm.SendNoticationMailSMS("ARTL", "PreffExm", ViewState["CandType"].ToString(), "120", "RE", "", NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (Request.QueryString["Type"].Trim() == "ReExam")
                        {
                            objmailcomm.SendNoticationMailSMS("ARTL", "ReExm", ViewState["CandType"].ToString(), "50", "RE", "", NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else if (Request.QueryString["ACT"] == "Upload")
                        {
                            objmailcomm.SendNoticationMailSMS("ARTL", "TccUpld", ViewState["CandType"].ToString(), "110", "RW", ViewState["InsRenewalType"].ToString(), NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
                        }
                        else
                        {
                            objmailcomm.SendNoticationMailSMS("ARTL", "TccDwnld", ViewState["CandType"].ToString(), "110", "RW", "", NotifyTo, lblAppNoValue.Text, ViewState["SAP"].ToString().Trim());
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

    #region btnSubmit_Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      try
      {
          DataSet dsFees = new DataSet();
          #region Re-Exam and PreferredExmDate
          if ((Request.QueryString["Type"] == "E") || (Request.QueryString["Type"].Trim() == "ReExam"))
            {
                //Added by pranjali on 26-04-2014 for preffered date validation start
                //if (txtExmdt1.Text.ToString().Trim() != "" && txtExmdt2.Text.ToString().Trim() != "")
                //{
                //    if (Convert.ToDateTime(txtExmdt2.Text) < Convert.ToDateTime(txtExmdt1.Text))
                //    {
                //        lblerrmsg.Visible = true;
                //        lblerrmsg.Text = "Preffered Exam Date 2 should be greater than Preffered Exam Date 1";
                //        trmsg.Visible = true;
                //        return;
                //    }
                //}
                //Added by pranjali on 26-04-2014 for preffered date validation end
                

                string sessionuser = string.Empty;
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    sessionuser = HttpContext.Current.Session["UserID"].ToString();
                }
                int x = 0;
                //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Clear();//added by meena 9_5_18
                htParam.Add("@AppNo", lblAppNoValue.Text);
                if (txtExmdt1.Text.Trim() != "")
                {
                    htParam.Add("@PreffExmDt1", DateTime.Parse(txtExmdt1.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@PreffExmDt1 ", System.DBNull.Value);
                }
                if (txtExmdt2.Visible == true)
                {
                    if (txtExmdt2.Text.Trim() != "")
                    {
                        htParam.Add("@PreffExmDt2", DateTime.Parse(txtExmdt2.Text.Trim()).ToString("yyyyMMdd"));
                    }
                    else
                    {
                        htParam.Add("@PreffExmDt2 ", System.DBNull.Value);
                    }
                }
                else
                {
                    htParam.Add("@PreffExmDt2 ", System.DBNull.Value);
                }
                htParam.Add("@ExmDtApprvr", sessionuser);


                if (Request.QueryString["Type"] == "E")
                {
                     if (txtExmdt1.Text == "") //Preffered exam date 1 is blank
                        {
                            //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Preffered Exam Date 1')</Script>");
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Preferred Exam Date 1')", true);
                            return;
                        }
                    if (tblPrefExm.Visible == true)
                    {
                        if (txtExmdt1.Text == "") //Preffered exam date 1 is blank
                        {
                            //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Preffered Exam Date 1')</Script>");
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Preferred Exam Date 1')", true);
                            return;
                        }
                        else
                        {
                            if (Convert.ToDateTime(lblNWExmdtValue.Text) >= Convert.ToDateTime(txtExmdt1.Text))
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should be greater than System Exam Date')", true);
                                return;
                            }
                            else if (Convert.ToDateTime(txtExmdt1.Text) >= Convert.ToDateTime(lblNWExmdtValue.Text).AddDays(03))
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should be within 3 days from System Exam Date.')", true);
                                return;
                            }
                            else if (Convert.ToDateTime(txtExmdt1.Text).DayOfWeek.ToString() == "Sunday")
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should not be Sunday.')", true);
                               return;
                            }

                             //else if (Convert.ToDateTime(txtExmdt1.Text) > Convert.ToDateTime(HdnTccDate.Value))//shreela 02/06/2014
                            //{
                            //    ProgressBarModalPopupExtender.Hide();
                            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Preffered Exam Date.Preffered Exam date should be within 6 months from training completion date')", true);
                            //    return;
                            //}

                            else if (Convert.ToDateTime(txtExmdt1.Text) < Convert.ToDateTime(HdnLicTccDate.Value))
                            {
                                ProgressBarModalPopupExtender.Hide();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Preferred Exam Date.Preferred Exam date should be greater than training completion date')", true);
                                return;
                            }
                        }
                    }
                    htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                    x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdPreffExmDtls", htParam);
                        //MAIL Communication integration
                        MailResponse();
                        //MAIL        

                        lbl_popup.Text = "Preferred exam date updated successfully." + "<br/><br/>Application No:" + lblAppNoValue.Text + "</br>Candidate No: " + hdnCndNo.Value + "</br>Candidate Name: " + hdnCndName.Value;
                       // mdlpopup.Show();
                        //pnl.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        btnSubmit.Enabled = false;//added by meena 8_5_18
                        ObjTask.UpdateCndTask(lblAppNoValue.Text);//To create task in CRM  in 18.12.2017
                    }
                
                //Added by kalyani  on 21/04/2014 for Preffered exam details start
                else if (Request.QueryString["Type"].Trim() == "ReExam")
                {
		
                    if (txtExmdt1.Text.ToString().Trim() != "")
                    {
                        //Added and commented by kalyani on 15-05-2014 for preferred exam date validation check start
                        if (Convert.ToDateTime(lblNWExmdtValue.Text) > Convert.ToDateTime(txtExmdt1.Text))
                        {
                            //lblerrmsg.Visible = true;
                            //lblerrmsg.Text = "Preffered Exam Date 1 should be greater than System Exam Date";
                            //trmsg.Visible = true;
                            //return;
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should be greater than System Exam Date')", true);
                            return;
                        }
                        else if (Convert.ToDateTime(txtExmdt1.Text) >= Convert.ToDateTime(lblNWExmdtValue.Text).AddDays(03))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should be within 3 days from System Exam Date.')", true);
                            return;
                       }
                        else if (Convert.ToDateTime(txtExmdt1.Text).DayOfWeek.ToString() == "Sunday")
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Preferred Exam Date should not be Sunday.')", true);
                            return;
                        }
                         //else if (Convert.ToDateTime(txtExmdt1.Text) > Convert.ToDateTime(HdnTccDate.Value))//shreela 02/06/2014
                        //{
                        //    ProgressBarModalPopupExtender.Hide();
                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Preffered Exam Date.Preffered Exam date should be within 6 months from training completion date')", true);
                        //    return;
                        //}

                        else if (Convert.ToDateTime(txtExmdt1.Text) < Convert.ToDateTime(HdnLicTccDate.Value))
                        {
                            ProgressBarModalPopupExtender.Hide();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Preferred Exam Date.Preferred Exam date should be greater than training completion date')", true);
                            return;
                        }
                        //else if (Convert.ToDateTime(txtExmdt1.Text) > Convert.ToDateTime(HdnTccDate.Value))
                        //{
                        //    //lblerrmsg.Visible = true;
                        //    //lblerrmsg.Text = "Invalid Preffered Exam Date";
                        //    //trmsg.Visible = true;
                        //    //return;
                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Preffered Exam Date')", true);
                        //    return;
                        //}
                    }
                        //Added and commented by kalyani on 15-05-2014 for preferred exam date validation check end
                    //if (txtExmdt2.Text.ToString().Trim() != "")
                    //{
                    //    if (Convert.ToDateTime(lblNWExmdtValue.Text) > Convert.ToDateTime(txtExmdt2.Text))
                    //    {
                    //        lblerrmsg.Visible = true;
                    //        lblerrmsg.Text = "Preffered Exam Date 2 should be greater than System Exam Date";
                    //        trmsg.Visible = true;
                    //        return;
                    //    }
                    //}
			
                    //Added by pranjali on 26-04-2014 for mandatory documents validation start
                    Code = Request.QueryString["Code"].ToString();
                    Hashtable htparam = new Hashtable();
                    DataSet ds_candtype = new DataSet();
                    Hashtable httable1 = new Hashtable();
                    httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
                    htparam.Clear();
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                    htparam.Add("@ModuleCode", Code.Trim());
                    htparam.Add("@TypeofDoc", "UPLD");
                    //htparam.Add("@RenwlFlag", "N");
                    htparam.Add("@InsurerType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
                    //if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    //{
                    //    htparam.Add("@ReExmFlag", "Y");
                    //}
                    //else
                    //{
                    //    htparam.Add("@ReExmFlag", "N");
                    //}
                    htparam.Add("@ProcessType", "RE");
                    ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam);
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
                                    ProgressBarModalPopupExtender.Hide();
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
                                        ProgressBarModalPopupExtender.Hide();
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
                        }
                    }
                    //Added by pranjali on 26-04-2014 for mandatory documents validation start
			
                    htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htParam.Add("@ExamMode", ddlNExam.SelectedItem.Text.ToString().Trim());
                    htParam.Add("@ExmBody", ddlNExmBody.SelectedValue.ToString().Trim());
                    htParam.Add("@ExmLang", ddlNpreeamlng.SelectedItem.Text.ToString().Trim());
                    //htParam.Add("@ExmCentre", ddlExmCentre.SelectedItem.Text.ToString().Trim());
                    htParam.Add("@ExmCentre", hdnExmCentreCode.Value);
                    htParam.Add("@SysExmDt", DateTime.Parse(lblNWExmdtValue.Text.Trim()).ToString("yyyyMMdd")); 
                    if (chkWebTknRecd.Checked == true)
                    {

                        htParam.Add("@WaiverFlag", "1");
                    }
                    else
                    {

                        htParam.Add("@WaiverFlag", "0");
                    }

                    string ReExm = Request.QueryString["ReExm"].ToString();
                    htParam.Add("@ReExmcntValue", ReExm);
                    htParam.Add("@CreatedBy", sessionuser);//added by pranjali on 26-04-2014
                    if (ddlNExam.SelectedItem.Value == "Select")
                    {
                        //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Exam Mode')</Script>");
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Mode')", true);
                        return;
                    }
                    else if (ddlNExmBody.SelectedItem.Value == "Select")
                    {
                        //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Examination Body')</Script>");
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Examination Body')", true);
                        return;
                    }
                    else if (ddlNpreeamlng.SelectedItem.Value == "Select")
                    {
                        //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Prefer Exam Language')</Script>");
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Preferred Exam Language')", true);
                        return;
                    }
                    else if (hdnExmCentreCode.Value == "")
                    {
                        //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Exam Centre')</Script>");
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Centre')", true);
                        return;
                    }
                    //else if (ddlExmCentre.SelectedItem.Value == "--Select--")
                    //{
                    //    //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Exam Centre')</Script>");
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Exam Centre')", true);
                    //    return;
                    //}
                    else if (txtExmdt1.Text == "")
                    {
                        //ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Preffered Exam Date 1')</Script>");
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Preferred Exam Date 1')", true);
                        return;
                    }
                    //else if (txtExmdt2.Text == "")
                    //{
                    //    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<Script Language=javascript>AlertMsgs('Please Select Preffered Exam Date 2')</Script>");
                    //}
                    else
                    {
                        //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 Start
                        //if (chkFeesWaivr.Enabled == true)
                        //{
                        //    htParam.Add("@FeesWaiverFlag", chkFeesWaivr.Checked == true ? "Y" : "N");
                        //    if (chkFeesWaivr.Checked == true)
                        //    {
                        //        htParam.Add("@Remarks", txtRemrk.Text.ToString().Trim());
                        //    }
                        //    else
                        //    {
                        //        htParam.Add("@Remarks", System.DBNull.Value);
                        //    }
                        //}
                        //else
                        //{
                        //    htParam.Add("@FeesWaiverFlag", System.DBNull.Value);
                        //}
                        //Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 End
                        //if (ChkFeesWavier.Checked == true)
                        //{
                        //    htParam.Add("@FeesWaiverFlag", "Y");
                        //}
                        //else
                        //{
                        //    htParam.Add("@FeesWaiverFlag", System.DBNull.Value);
                        //} commit by pallavi fees wavier remove as ask by usha
                        //Inserts fees details for Valid  TCC
                        //InsertfeesDetails();

                        // GetNoofDaysForReexm();
                        //  SetSysFreezeDate();
                        htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                        dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdValidTCCDtls", htParam);
                        //MAIL Communication integration
                      //  MailResponse();
                        //MAIL
                        txtExmCntr.Text = hdnExmCentreCode.Value;
                        dsResult.Clear();
                        htParam.Clear();
                        htParam.Add("@CndNo", lblCndNoValue.Text.ToString().Trim());
                        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdReExmCnt", htParam);
                        x = dataAccessRecruit.execute_sprcrecruit("Prc_UpdReExmCnt", htParam);
                        lbl_popup.Text = "Re-Examination request submitted successfully." + "</br></br>Application No.: " + lblAppNoValue.Text + "</br>Candidate Name: " + hdnCndName.Value;
                           // + "<br/>Token No: " + strT + "<br/>Total Fees: " + strF;
                        btnSubmit.Enabled = false;//added by meena 8_5_18
                          //htParam.Clear();
                        //htParam.Add("@TokenNo", dsFees.Tables[0].Rows[0]["TokenNo"].ToString());
                        //htParam.Add("@Appno", lblAppNoValue.Text);
                        //htParam.Add("@URL", URL.ToString());
                        //dsFees.Clear();
                        //dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdCndTokenPaymentLink", htParam);
                        if (dsFees.Tables.Count > 0)
                        {
                            if (dsFees.Tables[0].Rows.Count > 0)
                            {
                                lbl_popup.Text = lbl_popup.Text + "<br/>Token No: " + dsFees.Tables[0].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[0].Rows[0]["TotalFees"].ToString();
                                string Tokenno = Encript.Encrypt(dsFees.Tables[0].Rows[0]["TokenNo"].ToString().Trim());
                                string Fees = Encript.Encrypt(dsFees.Tables[0].Rows[0]["TotalFees"].ToString().Trim());
                                string Appno = Encript.Encrypt(lblAppNoValue.Text.Trim());
                                string URL = PGURL + System.Web.HttpUtility.UrlEncode(Tokenno) + "&Fees=" + System.Web.HttpUtility.UrlEncode(Fees) + "&Appno=" + System.Web.HttpUtility.UrlEncode(Appno);

                                //PGBitLyURL.BitlyURLClient a = new BitlyURLClient();
                                //string bitlyURL = a.GetShortURL(URL, "ProposalNo", "12345", txtMobileNo.Text);//Changed by usha  on 06.02.2018
                                htParam.Clear();
                                htParam.Add("@TokenNo", dsFees.Tables[0].Rows[0]["TokenNo"].ToString());
                                htParam.Add("@Appno", lblAppNoValue.Text);
                                htParam.Add("@URL", URL.ToString());
                               // htParam.Add("@BitlyURL", bitlyURL.ToString());
                                htParam.Add("@MailTempFlag", "ReExam");//added by ashishp
                                dsFees.Clear();
                                dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdCndTokenPaymentLink", htParam);
                            }
                        }
                        else
                        {
                            lbl_popup.Text = lbl_popup.Text + "<br/>Total Fees: 0.00";
                        }
                        //mdlpopupSub.Show();
                        //pnlSub.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        ObjTask.UpdateCndTask(lblAppNoValue.Text);//To create task in CRM  in 18.12.2017
                    }
                } //Added by kalyani  on 21/04/2014 for Preffered exam details end
            }
          #endregion
#region Agent license and ID certificate
          else if ((Request.QueryString["TYPE"].ToString().Trim() == "License"))
          {
              Hashtable htparam = new Hashtable();
              DataSet ds_candtype = new DataSet();
              Hashtable httable1 = new Hashtable();
              httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
              ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
              dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
              htparam.Clear();
              htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
              htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
              htparam.Add("@ModuleCode", Request.QueryString["Code"].ToString().Trim());
              if (Request.QueryString["ACT"] == "LicUpload")
              {
                  htparam.Add("@TypeofDoc", "UPLD");
              }
              else
              {
                  htparam.Add("@TypeofDoc", "DWNLD");
              }
              if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() != "")
              {
                  htparam.Add("@InsurerType", dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim());
              }
              else
              {
                  htparam.Add("@InsurerType", "");
              }
              htparam.Add("@ProcessType", dsResult.Tables[0].Rows[0]["ProcessType"].ToString().Trim());
              ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam);
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
                              ProgressBarModalPopupExtender.Hide();
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
                                  ProgressBarModalPopupExtender.Hide();
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
                  }
              }
              lbl.Text = "Agent ID and License Certificate submited Successfully" + "</br></br>Application No: " + lblAppNoValue.Text + "<br/>Candidate No:" + lblCndNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;

              mdlpopup.Show();
              pnl.Visible = true;
              ProgressBarModalPopupExtender.Hide();
          }



          #endregion
          #region TCC/Upload download
          else
            {
                Code = Request.QueryString["Code"].ToString();
                if (txtDate.Text.ToString().Trim() != "")
                {
                    if ((Convert.ToDateTime(txtDate.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                    {
                        ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Transfer should not be past date')", true);
                        return;
                    }
                }
                //if (txtCompLicExpDt.Text.ToString().Trim() != "")
                //{
                    //if ((Convert.ToDateTime(txtCompLicExpDt.Text)) < (Convert.ToDateTime(DateTime.Now.ToString(CommonUtility.DATE_FORMAT))))
                   //{
                        //ProgressBarModalPopupExtender.Hide();
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('License Exp Date for Composite should not be //past date')", true);
                        //return;
                    //}
                //}
                

                Hashtable htparam = new Hashtable();
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
                htparam.Clear();
                htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                htparam.Add("@ModuleCode", Code.Trim());
                if (Request.QueryString["ACT"] == "Upload")
                {
                    htparam.Add("@TypeofDoc", "UPLD");
                }
                else
                {
                    htparam.Add("@TypeofDoc", "DWNLD");
                }
                //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                //if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                //{
                //    htparam.Add("@ReExmFlag", "Y");
                //}
                //else
                //{
                //    htparam.Add("@ReExmFlag", "N");
                //}
                htparam.Add("@ProcessType", "RW");
                ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam);
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
                                ProgressBarModalPopupExtender.Hide();
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
                                    ProgressBarModalPopupExtender.Hide();
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
                    }
                }

                
                        

                htParam.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@IsUpld", "U");
                htParam.Add("@flag", "1");//1 for upload
                dsFees.Clear();
                dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("prc_InsCndRenewalTcc", htParam);

                //MAIL Communication integration
                //getCandidateDetails();
                MailResponse();
                //MAIL
                //added by shreela on 28042014
                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {

                        lbl.Text = "Training Completion Certificate submited Successfully" + "</br></br>Application No: " + lblAppNoValue.Text + "<br/>Candidate No:" + lblCndNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;

                    }
                }

                mdlpopup.Show();
                pnl.Visible = true;
                ProgressBarModalPopupExtender.Hide();
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
    #endregion

    #region Button Upload
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
if (Request.QueryString["ACT"] == null)
        {

            //added by pranjali on 26-04-2014 start
            // ProgressBarModalPopupExtender.Show();
            // System.Threading.Thread.Sleep(2000);
            //added by pranjali on 26-04-2014 end
            //Added by pranjali on 27-12-2013 start
            GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
            FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
            Label lbldocname = (Label)row.FindControl("lbldocName");
            Label lblimgsize = (Label)row.FindControl("lblimgsize");
            Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
            Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
            Label lblimgheight = (Label)row.FindControl("lblimgheight");
            Button btnreupd = (Button)row.FindControl("btn_ReUpload");
            Button btn_Upload = (Button)row.FindControl("btn_Upload");
	    LinkButton lnkPreview = (LinkButton)row.FindControl("lnkPreview");
	    Label lbldoccode = (Label)row.FindControl("lbldoccode");
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
                if (!Directory.Exists(strFilePath))
                {
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
                //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)) //Commented for overwritting of image instead of creating new image with same name
                using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
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
                if ((Request.QueryString["Type"].ToString().Trim() == "RenTrn") || (Request.QueryString["Type"].ToString().Trim() == "ReExam"))
                {
                    //added by pranjali on 26-04-2014
                    ProgressBarModalPopupExtender.Hide();
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lbl1.Text = lbldocname.Text + "uploaded successfully.";
                    //mdlView.Show();
                    //pnlMdl1.Visible = true;
                    //added by pranjali on 26-04-2014
                }
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
            //Filluploadedfile();
            btnreupd.Enabled = true;
            btn_Upload.Enabled = false;
            btnreupd.Visible = true;
            btn_Upload.Visible = false;
	    lnkPreview.Visible = true;
        }
	else
	{
        if (Request.QueryString["ACT"] == "Upload" || Request.QueryString["ACT"].ToString().Trim() == "LicUpload")
        {

            //ProgressBarModalPopupExtender.Show();
            //System.Threading.Thread.Sleep(2000);
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
                if (!Directory.Exists(strFilePath))
                {
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
                    strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
                }
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocname.Text + " File for Upload');</script>");
                return;
            }
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Invalid File Format');</script>");
                return;
            }
            FileInfo fi = new FileInfo(strFileName);
            string filename = fuData.FileName;
            fuData.SaveAs(strFileName);

            #endregion

            byte[] data = File.ReadAllBytes(strFileName);

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
            htdata.Add("@DocStatus", "0");
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode.Text.Trim());
            try
            {
                if ((Request.QueryString["Type"].ToString().Trim() == "RenTrn") || (Request.QueryString["Type"].ToString().Trim() == "ReExam") || (Request.QueryString["Type"].ToString().Trim() == "License"))
                {
                    //added by pranjali on 26-04-2014
                    ProgressBarModalPopupExtender.Hide();
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lbl1.Text = lbldocname.Text + "uploaded successfully.";// <br/><br/> Please proceed with submit";
                    //mdlView.Show();
                    //pnlMdl1.Visible = true;
                    //added by pranjali on 26-04-2014
                }
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
            //Filluploadedfile();
            btnreupd.Enabled = true;
            btn_Upload.Enabled = false;
            btnreupd.Visible = true;
            btn_Upload.Visible = false;
	    lnkPreview.Visible = true;
        }

        else
        {


            //added by pranjali on 26-04-2014 start
            // ProgressBarModalPopupExtender.Show();
            // System.Threading.Thread.Sleep(2000);
            //added by pranjali on 26-04-2014 end
            //Added by pranjali on 27-12-2013 start
            GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
            FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
            Label lbldocname = (Label)row.FindControl("lbldocName");
            Label lblimgsize = (Label)row.FindControl("lblimgsize");
            Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
            Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
            Label lblimgheight = (Label)row.FindControl("lblimgheight");
            Button btnreupd = (Button)row.FindControl("btn_ReUpload");
            Button btn_Upload = (Button)row.FindControl("btn_Upload");
	    LinkButton lnkPreview = (LinkButton)row.FindControl("lnkPreview");
	    Label lbldoccode = (Label)row.FindControl("lbldoccode");
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
                if (!Directory.Exists(strFilePath))
                {
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
                if ((Request.QueryString["Type"].ToString().Trim() == "RenTrn") || (Request.QueryString["Type"].ToString().Trim() == "ReExam"))
                {
                    //added by pranjali on 26-04-2014
                    ProgressBarModalPopupExtender.Hide();
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lbl1.Text = lbldocname.Text + "uploaded successfully.";
                    //mdlView.Show();
                    //pnlMdl1.Visible = true;
                    //added by pranjali on 26-04-2014
                }
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
            //Filluploadedfile();
            btnreupd.Enabled = true;
            btn_Upload.Enabled = false;
            btnreupd.Visible = true;
            btn_Upload.Visible = false;
	    lnkPreview.Visible = true;
        }
       }
    }
    #endregion

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
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        bemailfound = true;
                        hdnCanid.Value = dsResult.Tables[0].Rows[0]["cndno"].ToString();
                    }
                    else 
                    {

                        hdnEmail.Value = "1";
                    }
                }
                if (bemailfound == true)
                {
                    lblEmailMsg.Visible = true;
                    lblEmailMsg.Text = "Duplicate Email id found for " + hdnCanid.Value;// +hdnCanid.Value;
                    lblEmailMsg.ForeColor = Color.Red;
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
                        bmobile = true;
                        hdnCanid.Value = dsResult.Tables[0].Rows[0]["cndno"].ToString();
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
    }
    #endregion

    #region Button Reupload
    protected void btn_ReUpload_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ACT"].ToString().Trim() == "Upload" || Request.QueryString["ACT"].ToString().Trim() == "LicUpload")
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
                    strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
                }
            }
            else
            {
                ProgressBarModalPopupExtender.Hide();
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocName.Text + " File for ReUpload');</script>");
                return;
            }
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
                strFileName = strFileRePath + "\\" + strFileName1;
            }
            string filename = fuData.FileName;
            //string strname = strFileName + filename;


            FileInfo fi = new FileInfo(strPath);
            {
                if (fuData.PostedFile.ContentLength <= BMaxImgSize1)
                {
                    if (File.Exists(strFileName))
                    {
                        string stroldpath = strFileRePath + "\\" + strFileName1;
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
                        string strnewpath = strFileRePath + "\\" + lblCndNoValue.Text.Trim() + "_" + lblimgshrt1.Text + "_R" + DocStatusCount + "." + strPhotoExt;
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
            fuData.PostedFile.SaveAs((strFileName));

            byte[] data = File.ReadAllBytes(strFileName);

            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];
            htdata.Clear();
            htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocName.Text.Trim());
            htdata.Add("@UserID", hdnUserId.Value);
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "1");
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode1.Text.Trim());
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "RenTrn" || (Request.QueryString["Type"].ToString().Trim() == "ReExam"))
                {
                    //added by pranjali on 26-04-2014
                    ProgressBarModalPopupExtender.Hide();
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lbl1.Text = lbldocName.Text + " reuploaded successfully.";
                    //mdlView.Show();
                    //pnlMdl1.Visible = true;
                    //added by pranjali on 26-04-2014
                }
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
        else
        {
            //added by pranjali on 26-04-2014 start
            //ProgressBarModalPopupExtender.Show();
            //System.Threading.Thread.Sleep(2000);
            //added by pranjali on 26-04-2014 end

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
                ProgressBarModalPopupExtender.Hide();
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


            fuData.PostedFile.SaveAs((strFileName));
            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1] + "\\" + actualpath[3];
            htdata.Clear();
            htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocName.Text.Trim());
            htdata.Add("@UserID", hdnUserId.Value);
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "1");
            htdata.Add("@Imagebin", data);
	    htdata.Add("@DocCode", lbldoccode1.Text.Trim());
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "RenTrn" || (Request.QueryString["Type"].ToString().Trim() == "ReExam"))
                {
                    //added by pranjali on 26-04-2014
                    ProgressBarModalPopupExtender.Hide();
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
                    //lbl1.Text = lbldocName.Text + " reuploaded successfully. <br/><br/> Please proceed with submit";
                    //mdlView.Show();
                    //pnlMdl1.Visible = true;
                    //added by pranjali on 26-04-2014
                }
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
    }
    #endregion

    #region
    protected void FillReuploadedfile(string Docname) 
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
                        //BindgridChkboxChnge();
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
    #endregion

    #region TCC download submit
    protected void btnfinish_Click(object sender, EventArgs e)
    {
        //added by rachana on 19062014 start
        DataSet dsFees = new DataSet();
        //added by rachana on 19062014 end

        #region for VA-Renewal form upload
                Hashtable htparam = new Hashtable();
                DataSet ds_candtype = new DataSet();
                Hashtable httable1 = new Hashtable();
                httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1);
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", httable1);
                if (dsResult.Tables[0].Rows[0]["InsRenewalType"].ToString().Trim() != "F")
                {
                    htparam.Clear();
                    htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
                    htparam.Add("@ModuleCode", Request.QueryString["Code"].ToString().Trim());
                    if (Request.QueryString["ACT"] == "Upload")
                    {
                        htparam.Add("@TypeofDoc", "UPLD");
                    }
                    else
                    {
                        htparam.Add("@TypeofDoc", "UPLD");
                    }
                    //htparam.Add("@RenwlFlag", Convert.ToString(dsResult.Tables[0].Rows[0]["RenewalFlag"]).Trim());
                    htparam.Add("@InsurerType", Convert.ToString(dsResult.Tables[0].Rows[0]["InsRenewalType"]).Trim());
                    //if (ds_candtype.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim() == "Y")
                    //{
                    //    htparam.Add("@ReExmFlag", "Y");
                    //}
                    //else
                    //{
                    //    htparam.Add("@ReExmFlag", "N");
                    //}
                    htparam.Add("@ProcessType", "RW");
                    ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUpldDocNames", htparam);
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
                                    ProgressBarModalPopupExtender.Hide();
                                    string ImgDesc = ds_documentName.Tables[0].Rows[i]["ImgDesc01"].ToString().Trim();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                                    return;
                                }
                            }
                        }
                    }
                }
        #endregion

                htParam.Clear();
                htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htParam.Add("@IsUpld", System.DBNull.Value);
                htParam.Add("@flag", "2");//2 for dwnload
                htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                ///Fees setup for Renewal  added by rachana for generating fess at TCC Download
                string strRulecode = string.Empty;
                Hashtable htRuleCode = new Hashtable();
                htRuleCode.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                strRulecode = dataAccessRecruit.execute_sprc_with_output("Prc_GetFeesForRNWLCnd", htRuleCode, "@Strout");
                if (strRulecode != "")
                {
                    htParam.Add("@RuleCode", strRulecode);
                }
                else
                {
                    htParam.Add("@RuleCode", System.DBNull.Value);
                }

                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_InsCndRenewalTcc", htParam);
                dsFees.Clear();
                dsFees = dataAccessRecruit.GetDataSetForPrcRecruit("prc_InsCndRenewalTcc", htParam);

                
                MailResponse();//Mail comm
                ProgressBarModalPopupExtender.Hide();
                if (dsFees.Tables.Count > 0)
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {
                        if (dsFees.Tables[0].Rows[0]["InsRenewalType"].ToString() == "F")
                        {
                            lbl.Text = "Training Completion Certificate Downloaded Successfully" + "<br/>Application No." + lblAppNoValue.Text + "<br/>Candidate No:"
                               + lblCndNoValue.Text + "<br/>Candidate Name:" + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;
                            mdlpopup.Show();
                            pnl.Visible = true;
			    btnFinish.Enabled = false;
                        }
                        else
                        {
                            lbl.Text = "Training Completion Certificate Downloaded Successfully" + "<br/>Application No." + lblAppNoValue.Text + "<br/>Candidate No:"
                            + lblCndNoValue.Text + "<br/>Candidate Name:" + lblAdvNameValue.Text;// +"<br/>Token No: " + strT + "<br/>Total Fees: " + strF;

                            lbl.Text = lbl.Text + "<br/>Token No: " + dsFees.Tables[0].Rows[0]["TokenNo"].ToString() + "<br/>Total Fees: " + dsFees.Tables[0].Rows[0]["TotalFees"].ToString();
                            mdlpopup.Show();
                            pnl.Visible = true;
			    btnFinish.Enabled = false;
                        }
                    }
                }
    }
    #endregion
    //Added by rachana for fees details start
    protected void btnGetFeeDetails_Click(object sender, EventArgs e)
    {
        try
        {
            string strdate = string.Empty;
            string strOutput1 = string.Empty;
            #region Fees Details
            //DataSet dsEmp = new DataSet();
            //Hashtable htemp = new Hashtable();
            //htemp.Add("@AgentCode", hdnRecruitAgntCode.Value);
            //dsEmp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetEmpCodeForFees", htemp);
            //string strEmpcode = dsEmp.Tables[0].Rows[0]["Empcode"].ToString();
            //string strFeesinput = "<Input><TransID>" + txtFeesRcvd.Text + "</TransID><SAPCode>" + hdnRecruitAgntCode.Value + "</SAPCode><RequestingSystem>ICM</RequestingSystem></Input>";
            string strFeesinput = "<Input><TransID>" + txtFeesRcvd.Text + "</TransID><SAPCode>" + strcallerSystem + "</SAPCode><RequestingSystem>iSys</RequestingSystem></Input>";

            #region to be uncommented on UAT
            //Web service fees dtls start 
            //SysInrgConsum.GetPaymentDtlsConsum objPymt = new SysInrgConsum.GetPaymentDtlsConsum();
            //string strOutput = objPymt.GetPaymentDtls(strFeesinput);
            #endregion
            //70250573

            //Web service fees dtls end

            XmlDocument objfee = new XmlDocument();
            objfee.LoadXml(strFeesinput);

            XmlDocument objOutPut = new XmlDocument();


            //objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));

            if (ViewState["strICMEnable"].ToString() != "YES")//When ICM configuration in Enabled in system
            {
                objOutPut.Load(Server.MapPath("~\\Application\\Isys\\Recruit\\Fees.xml"));

                #region to be uncommented on UAT
                //objOutPut.LoadXml(strOutput);
                #endregion


                strOutput1 = objOutPut.InnerXml.ToString();
            }
            else
            {
                decimal decamt = Convert.ToDecimal(txtPymtAmt.Text);
                strOutput1 = "<OutPut><ChequeDate>" + txtChequedate.Text.Trim() + "</ChequeDate><ChequeNo>" + txtChequeNo.Text.Trim() + "</ChequeNo><ChequeAmount>" +
                   decamt + "</ChequeAmount><BankName>" + txtBankName.Text.Trim() + "</BankName><PaymentMode>" + DDlPymtMode.SelectedItem.Text.Trim()
                    + "</PaymentMode><TransID_fk>" + txtFeesRcvd.Text.Trim() + "</TransID_fk></OutPut>";
                objOutPut.LoadXml(strOutput1);
            }

            //Sync log entry of input output xml 
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();

            int f;
            Hashtable htLog = new Hashtable();
            htLog.Add("@RefNo", txtFeesRcvd.Text);
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


            //divFees.Attributes.Add("Style", "visibility:visible");
            //trfees.Visible = true;

            //Binding value to data table
            DataTable dtCurrentTable1 = (DataTable)ViewState["dsfeesDtls"];//added prev data to viewstate


            if (dsoutput.Tables.Count > 0)
            {
                if (dsoutput.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsoutput.Tables[0].Rows.Count; i++)
                    {
                        if (dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString() != "Cash")
                        {
                            strdate = DateTime.Parse(Convert.ToString(dsoutput.Tables[0].Rows[0]["ChequeDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                        int rowIndex = 0;
                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            DataRow drCurrentRow = null;

                            rowIndex = dtCurrentTable.Rows.Count;
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["TransID_fk"] = dsoutput.Tables[0].Rows[0]["TransID_fk"].ToString();
                            drCurrentRow["PaymentMode"] = dsoutput.Tables[0].Rows[0]["PaymentMode"].ToString();
                            drCurrentRow["Receiptid"] = txtFeesRcvd.Text;
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

                            dtCurrentTable.Rows.Add(drCurrentRow);
                            ViewState["CurrentTable"] = dtCurrentTable;

                            Table2.Visible = true;
                            divFees.Attributes.Add("Style", "display: block");


                            if (ViewState["strICMEnable"].ToString() != "YES")//When ICM configuration in Enabled in system
                            {

                                dgPaymentdtls.DataSource = dtCurrentTable;
                                dgPaymentdtls.DataBind();
                            }
                            else
                            {

                                dtCurrentTable1.Merge(dtCurrentTable, true, MissingSchemaAction.Ignore);//Merges two datasets
                                dgPaymentdtls.DataSource = dtCurrentTable1;
                                dgPaymentdtls.DataBind();
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

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("TransID_fk", typeof(string)));
        dt.Columns.Add(new DataColumn("PaymentMode", typeof(string)));
        dt.Columns.Add(new DataColumn("Receiptid", typeof(string)));
        dt.Columns.Add(new DataColumn("ChequeAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("EFT/NEFT", typeof(string)));
        dt.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
        dt.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
        dt.Columns.Add(new DataColumn("BankName", typeof(string)));

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
            txtFeesRcvd.Text = "";
        }
    }
    //Added by kalyani on 21/04/2014 for Preferred exam details start
    #region viewData
    protected void viewData(string strCndNo)
    {

        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", strCndNo);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPreffExmDtls", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        hdnCndName.Value = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        lblTrnInstituteValue.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                        lblTrnLocValue.Text = dsResult.Tables[0].Rows[0]["TrnLocDesc"].ToString().Trim();
                        lblTrnModeValue.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                        lblNWExmdtValue.Text = dsResult.Tables[0].Rows[0]["ExmDate"].ToString().Trim();
                        lblpref1dt.Visible = true;
                        lblpref1value.Visible = true;
                        lblprefformat1.Visible = false;
                        if (dsResult.Tables[0].Rows[0]["PreffExmDt1"].ToString().Trim() == "")
                        {
                            lblpref1value.Text = dsResult.Tables[0].Rows[0]["ExmDate"].ToString().Trim();
                        }
                        else
                        {
                            lblpref1value.Text = dsResult.Tables[0].Rows[0]["PreffExmDt1"].ToString().Trim();
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

    #region GetSystemFreezeDate
    protected void GetSystemFreezeDate()
    {
        try
        {
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            strOutput = dataAccessRecruit.execute_sprc_with_output("PRC_GetSystemFreezeDate", htParam, "@Output", CONN_Recruit);
            if (strOutput == "1")
            {
                tblPrefExm.Visible = true;
            }
            else if (strOutput == "2")
            {
                tblPrefExm.Visible = false;
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
    //Added by kalyani on 21/04/2014 for Preferred exam details end


    //Reexam
    #region PopulateExamMode
    //To Populate Exam Mode from ISysLookupParam      
    //private void PopulateExamMode()
    //{
    //    try
    //    {
    //        ddlExam.Items.Clear();
    //        //Added By Ibrahim on 05-07-2013 to Get Exam Mode (Online/ OffLine) Start
    //        DSddlExam.SelectCommand = "PRC_GET_PopulateExamMode";
    //        //Added By Ibrahim on 05-07-2013 to Get Exam Mod (Online/ OffLine) End
    //        ddlExam.DataBind();
    //        ddlExam.Items.Insert(0, "--Select--");
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

    #region PopulateNExamMode commented by pranjali on 25-04-2014
    //To Populate Exam Mode from ISysLookupParam      
    //private void PopulateNExamMode()
    //{
    //    try
    //    {
    //        ddlNExam.Items.Clear();
    //        //Added By Ibrahim on 05-07-2013 to Get Exam Mode (Online/ OffLine) Start
    //        DSNddlExam.SelectCommand = "PRC_GET_PopulateExamMode";
    //        //Added By Ibrahim on 05-07-2013 to Get Exam Mod (Online/ OffLine) End
    //        ddlNExam.DataBind();
    //        ddlNExam.Items.Insert(0, "--Select--");
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

    //#region PopulatePreExmLanguages()
    ////To Populate Pre Exam Language from ISysLookupParam table 
    //private void PopulatePreExmLanguages()
    //{
    //    ddlpreeamlng.Items.Clear();
    //    //Added By Ibrahim on 05-07-2013 to Get Pre Exam Language Select Start
    //    DSddlpreeamlng.SelectCommand = "PRC_GET_PopulatePreExmLanguages";
    //    //Added By Ibrahim on 05-07-2013 to Get Pre Exam Language Select End
    //    ddlpreeamlng.DataBind();
    //    ddlpreeamlng.Items.Insert(0, "--Select--");
    //}
    //#endregion

    #region PopulateNPreExmLanguages() commented by pranjali on 25-04-2014
    //To Populate Pre Exam Language from ISysLookupParam table 
    //private void PopulateNPreExmLanguages()
    //{
    //    ddlNpreeamlng.Items.Clear();
    //    //Added By Ibrahim on 05-07-2013 to Get Pre Exam Language Select Start
    //    DSNddlpreeamlng.SelectCommand = "PRC_GET_PopulatePreExmLanguages";
    //    //Added By Ibrahim on 05-07-2013 to Get Pre Exam Language Select End
    //    ddlNpreeamlng.DataBind();
    //    ddlNpreeamlng.Items.Insert(0, "--Select--");
    //}
    #endregion

    //#region ddlExam SelectedIndexChanged Events
    ////To Get Exam Body and Pre Language ddl selected Index
    //protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        hdnExmCentreCode.Value = "";
    //        txtExmCentre.Text = string.Empty;

    //        if (ddlExam.SelectedValue.ToString().Trim() == "1")
    //        {
    //            ddlpreeamlng.Items.Clear();
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index Start
    //            htdata.Clear();
    //            htdata.Add("@flag", 1);
    //            DSddlpreeamlng.SelectCommand = "PRC_GETExam_Bodyandpreeamlng";
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index End
    //            ddlpreeamlng.DataBind();
    //            ddlpreeamlng.Items.Insert(0, "--Select--");
    //            ddlExmBody.SelectedValue = "--Select--";
    //            ddlExmBody.AppendDataBoundItems = false;
    //            ddlExmBody.Items[3].Enabled = false;
    //            ddlExmBody.Enabled = true;
    //        }
    //        else
    //        {
    //            ddlpreeamlng.Items.Clear();
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index Start
    //            htdata.Clear();
    //            htdata.Add("@flag", 0);
    //            DSddlpreeamlng.SelectCommand = "PRC_GETExam_Bodyandpreeamlng";
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index End
    //            ddlpreeamlng.DataBind();
    //            ddlpreeamlng.Items.Insert(0, "--Select--");
    //            ddlExmBody.Items[3].Enabled = true;
    //            ddlExmBody.SelectedValue = "IIIOf";
    //            ddlExmBody.Enabled = false;
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
    //#endregion

    //#region ddlNExam SelectedIndexChanged Events
    ////To Get Exam Body and Pre Language ddl selected Index
    //protected void ddlNExam_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        hdnNExmCentreCode.Value = "";
    //        txtNExmCentre.Text = string.Empty;

    //        if (ddlNExam.SelectedValue.ToString().Trim() == "1")
    //        {
    //            ddlNpreeamlng.Items.Clear();
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index Start
    //            htdata.Clear();
    //            htdata.Add("@flag", 1);
    //            DSNddlpreeamlng.SelectCommand = "PRC_GETExam_Bodyandpreeamlng";
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index End
    //            ddlNpreeamlng.DataBind();
    //            ddlNpreeamlng.Items.Insert(0, "--Select--");
    //            ddlNExmBody.SelectedValue = "--Select--";
    //            ddlNExmBody.AppendDataBoundItems = false;
    //            ddlNExmBody.Items[3].Enabled = false;
    //            ddlNExmBody.Enabled = true;
    //        }
    //        else
    //        {
    //            ddlNpreeamlng.Items.Clear();
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index Start
    //            htdata.Clear();
    //            htdata.Add("@flag", 0);
    //            DSNddlpreeamlng.SelectCommand = "PRC_GETExam_Bodyandpreeamlng";
    //            //Added by ibrahim on 08-07-2013 to Get Exam Body and Pre Language ddl selected Index End
    //            ddlNpreeamlng.DataBind();
    //            ddlNpreeamlng.Items.Insert(0, "--Select--");
    //            ddlNExmBody.Items[3].Enabled = true;
    //            ddlNExmBody.SelectedValue = "IIIOf";
    //            ddlNExmBody.Enabled = false;
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
    //#endregion


    #region FillOldExmDtls
    protected void FillOldExmDtls(string strCndNo)
    {

        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", strCndNo);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("PRC_GetExamDetails", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        txtExm.Text= dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();
                        txtBody.Text= dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();
                        txtLang.Text= dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                        txtExmCentre.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();

                        //added by shreela
                        txtexmdrenew.Text = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();
                        txtexmdrenew.Enabled = false;
                        txtexmbodyrenew.Text = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();
                        txtexmbodyrenew.Enabled = false;
                        txtpreexamlngrenew.Text = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                        txtpreexamlngrenew.Enabled = false;
                        txtcenterrenew.Text = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                        txtcenterrenew.Enabled = false;

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

    public void GetNoofDaysForReexm()
    {

        DataSet dsetdays = new DataSet();
        Hashtable htdays = new Hashtable();
        htdays.Add("@CndType", hdnPanDtls.Value);
        htdays.Add("@REexmFlag", ViewState["ReExamFlag"].ToString());
        htdays.Add("@ValidTcc", ViewState["TCC"].ToString());
        dsetdays = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NoofDaysbasedonCndType", htdays);
        //dsetdays = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NoofDaysbasedonCndType");

        if (dsetdays.Tables.Count > 0)
        {
            if (dsetdays.Tables[0].Rows.Count > 0)
            {
                iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["noofdays"]);
            }
        }
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
        if (Request.QueryString["Type"].ToString().Trim() == "ReTrn")
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
                    #region to be uncommented on UAT start
                    //SysInrgConsum.GetHolidayConsume objhol = new SysInrgConsum.GetHolidayConsume();
                    //lstholidays = objhol.GetHolidayDtls(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), 2);
                    //lstworkdays = objhol.GetWorkingdays(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), iNoOfDays);
                    DateTime DtUpld = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                    //DtUpld = DtUpld.AddDays(3);
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
                    htParam.Clear();
                    htParam.Add("@RefNo", strCndNo);
                    htParam.Add("@AppNo", strAppno);
                    htParam.Add("@XmlInput", strInput);
                    htParam.Add("@CreatedBy", strcallerSystem);
                    htParam.Add("@Xmloutput", strOutput);
                    htParam.Add("@Resdate", System.DateTime.Now);
                    htParam.Add("@Errdesc", "");
                    htParam.Add("@MethodName", method.Name.ToString());
                    g = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSysFreezeDateSyncLog", htParam);

                    #endregion

                    date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                    #region to be uncommented on UAT start
                    //SysFreezedate = Convert.ToDateTime(lstworkdays[0]);
                    //string strDate = lstworkdays[0].ToString();
                    // SysFreezedate = Convert.ToDateTime(dateString[2].Substring(0,5) + "-" + dateString[0] + "-" + dateString[1]);
                    string strDate = DtUpld.ToString();
                    string[] dateString = strDate.Split('/');
                    SysFreezedate = Convert.ToDateTime(strDate);
                    #endregion

                    UpdteDt(strbranchcode, SysFreezedate, strCndNo);


                }
            }
        }
    }

    protected void UpdteDt(string BrnCode, DateTime FreezeDt, string CndNo)
    {
        int f;
        htParam.Clear();
        htParam.Add("@BranchCode", BrnCode);
        htParam.Add("@CndNo", CndNo);
        htParam.Add("@SysFreezeDate", FreezeDt);
        f = dataAccessRecruit.execute_sprcrecruit("Prc_UpdSysFreezeDates", htParam);

    }
    //added by rachana on 17042014 for updating Freeze date end


    //ReExam


    //added by shreela on 25042014
    #region
    protected void chckDwnld_CheckedChanged(object sender, EventArgs e)
    {

        if (chckDwnld.Checked == true)
        {

            htdata.Clear();
            htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htdata.Add("@flag", "3");
            x = dataAccessRecruit.execute_sprcrecruit("Prc_GetLicDtls", htdata);
            chckDwnld.Enabled = false;
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@flag", "1");//fill data 
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        #region shree07
                        //tbloldlic.Visible = true;
                        //divoldlic.Visible = true;
                        //lbloldlicnoval.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                        //lbloldexpdateval.Text = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                        //hdnoldlicexpdate.Value = dsResult.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();//shree
                        //lbloldlicissuval.Text = dsResult.Tables[0].Rows[0]["LcnIssDate"].ToString().Trim();
                        //tblnewlic.Visible = true;
                        //divnewlic.Visible = true;
                        //lblnewlicnoval.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                        //htdata.Clear();
                        //ds_documentName.Clear();
                        //htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                        //htdata.Add("@flag", "2");//fill new licnexpdate
                        //ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetLicDtls", htdata);
                        //if (ds_documentName != null)
                        //{
                        //    if (ds_documentName.Tables.Count > 0)
                        //    {
                        //        if (ds_documentName.Tables[0].Rows.Count > 0)
                        //        {
                        //            txtnewexpdate.Text = ds_documentName.Tables[0].Rows[0]["LicnExpDate"].ToString().Trim();
                        //            txtnewexpdate.Enabled = false;
                        //        }
                        //    }
                        //}
                        #endregion
                        //divbtnfinish.Visible = true;
                        btnFinish.Visible = true;
                        //divbtnClear.Visible = true;
                        btnClear.Visible = true;
                    }
                }
            }
            else
            {
                //divbtnClear.Visible = true;
                btnClear.Visible = true;
            }
        }
        else
        {
            htdata.Clear();
            htdata.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htdata.Add("@flag", "4");
            x = dataAccessRecruit.execute_sprcrecruit("Prc_GetLicDtls", htdata);
            tbloldlic.Visible = false;
            divoldlic.Visible = false;
            tblnewlic.Visible = false;
            divnewlic.Visible = false;
            //divbtnfinish.Visible = false;
            btnFinish.Visible = false;
            //divbtnClear.Visible = false;
            btnClear.Visible = false;
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
        }
        else if (DDlPymtMode.SelectedValue == "DDP")
        {
            TextEFT.Enabled = false;
        }
        else
        {
            TextEFT.Enabled = false;
        }

    }
    //Added by rachana on 30/04/2014 end

    #region
    protected void ddlNExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateExmBodyName();
    }
    #endregion

    #region
    protected void ddlNExmBody_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulatePreExmLanguages();
    }
    #endregion

    #region
    protected void ddlNpreeamlng_SelectedIndexChanged(object sender, EventArgs e)
    {
        //PopulateExmCentre();
    }
    #endregion

    protected void btnopen_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "OpenPOP();", true);
    }
    protected void dgDwnld_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString["ACT"] == "LicDownload")
            {
                string cndno = Request.QueryString["CndNo"].ToString().Trim();
                Label lblimgshrt1 = (Label)e.Row.FindControl("lblimgshrt1");
                Button btn_Dwnld = (Button)e.Row.FindControl("btn_Dwnld");
                DataSet dsCount = new DataSet();
                Hashtable htCount = new Hashtable();
                htCount.Add("@CndNo", cndno);
                htCount.Add("@DocCode", lblimgshrt1.Text);
                dsCount = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMaxDocCount", htCount);
                if (dsCount.Tables[0].Rows.Count > 0)
                {
                    string Doc = dsCount.Tables[0].Rows[0]["DocCount"].ToString().Trim();
                    //if (int.Parse(Doc) >= 2)
                    //{
                       // btn_Dwnld.Enabled = false;
                    //}
                          //added by usha for id and lcn dwnload
		    if (Doc == "Null")
                    {
                        btn_Dwnld.Enabled =true;
                    }
                }
            }
        }
    }
    //Added by Pranjali on 18-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 start
    #region Added by Pranjali on 13-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004
    //protected void chkFeesWaivr_CheckedChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (chkFeesWaivr.Checked == true)
    //        {
    //            divRmrk.Attributes.Add("style", "display:block");
    //        }
    //        else
    //        {
    //            divRmrk.Attributes.Add("style", "display:none");
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
    //Added by Pranjali on 18-03-2015 for Fees Waiver for CR KMI-2014-ARTL-004 End

    #region ChkFeesWavier_CheckedChanged event
    //protected void ChkFeesWavier_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkFeesWavier.Checked == true)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The said request will be sent to Corporate DP for approval of fees waiver.')", true);
    //        return;
    //    }
    //}
    // commit by pallavi fees wavier remove
    #endregion

    protected void btnPrev1_Click(object sender, EventArgs e)
    {
        divCndtls.Visible = true;
        tbltrn.Visible = false;
        btnPrev1.Visible = false;
        btnSubmit.Enabled = true;
        btnNextPannel1.Visible = true;
        divExm.Visible = true;
        divPannel1.Visible = true;


        divPDH.Attributes.Add("style", "color:#00cccc !important;");
        divCDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span2.Attributes.Add("style", "background-color: #00cccc !important");
        span9.Attributes.Add("style", "background-color: #8c8c8c !important");
    }
    protected void btnNextPannel1_Click(object sender, EventArgs e)
    {
       divCndtls.Visible = false;
        tbltrn.Visible = true;
        btnPrev1.Visible = true;
        //divPannel2.Visible = true;
        btnNextPannel1.Visible = false;
        //btnPrev1.Enabled = true;
        divExm.Visible = true;
        btnSubmit.Visible = true;
       divPannel1.Visible = false;

        divCDH.Attributes.Add("style", "color:#00cccc !important;");
        divPDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span2.Attributes.Add("style", "background-color: #8c8c8c  !important");
        span9.Attributes.Add("style", "background-color: #00cccc !important");
    }




    protected void btnok1_Click(object sender, EventArgs e)
    {
        
        String ModuleID = string.Empty;
        ModuleID = Request.QueryString["ModuleID"].ToString().Trim();

        Response.Redirect("CndEnq.aspx?Type=PREFFEXM&ModuleID=" + ModuleID);
    }
}
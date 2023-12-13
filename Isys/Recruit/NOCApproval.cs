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

using SysInrgConsum;
using System.ServiceModel;

public partial class Application_INSC_Recruit_NOCApproval : BaseClass
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
    string ModuleID = string.Empty;
    // string strRespond = string.Empty;
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
    string IsRenewal = string.Empty;////19052015
    //added by rachana for sysfreezedate start 
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    DateTime Lcndt;
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    string CandidateType;
    string Flag3;
    int RowCount = 0;
    //added by rachana for sysfreezedate end
    #endregion

    protected void Page_Load(object sender, EventArgs e)
        {

        try
        {

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
                    GetCandidateDtls();
                    InitializeControl();
                    GetAgentandUserDtls();
                    dgDetailsInbox.Columns[8].Visible = false;
                    //Added by usha for noc (userrolcode) on 1.07.2015
                    GetAgentandUserDtls_lic();

                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
                        {
                            btnSave.Visible = true;
                            BtnApprove.Visible = true;
                            btnReject.Visible = true;
                            //btnSubmit.Visible = true;
                            divCFRInbox.Visible = true;
                            trdos.Visible = true;
                            divCFRInbox.Attributes.Add("style", "display:none");
                            lblTitle1.Text = "NOC Approval Request";
                            txtreasonleave.Enabled = false;
                            txtReInsurer.Enabled = false;
                            //txtreasonleave.Visible = false;
                            //// }
                            btnClear.Visible = false;
                            btnCancel1.Visible = true;
                            //tdreasontext.Visible = false;
                            c1.Visible = false;
                            C2.Visible = false;
                            C3.Visible = false;
                            tblButton.Attributes.Add("style", "display:none");
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            if (txtReInsurer.Text == "")
                            {
                                tblResonInsurer.Attributes.Add("style", "display:none");
                                txtReInsurer.Visible = false;
                                lblremark.Visible = false;
                                tblremarkinsurer.Visible = false;
                                lblremarkinsurer.Visible = false;
                            }


                        }
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRCVR")
                        {

                            if (Request.QueryString["Cfr"].ToString().Trim() == "Res")
                            {

                                btnRespond.Visible = false;
                                dgDetailsInbox.Columns[9].Visible = false;
                            }
                            else
                            {
                                dgDetailsInbox.Columns[9].Visible = false;
                                btnRespond.Visible = true;
                            }
                            // tblreasonNOC1.Visible = false;
                            divNOCdetails.Visible = true;
                            //tblResonInsurer.Visible = false;
                            //tblremarkinsurer.Visible = false;

							// Added by Abuzar on 05-01-2023
                            //tblconfirm.Visible = false;
                            //tblconfirm2.Visible = false;
							tblconfirm.Visible = true;
							tblconfirm2.Visible = true;
							// Added by Abuzar on 05-01-2023

							txtreasonleave.Enabled = false;
                            txtReInsurer.Enabled = false;
                            //txtreasonleave.Visible = false;
                            //// }
                            btnClear.Visible = false;
                            btnCancel1.Visible = true;
                            //tdreasontext.Visible = false;
                            Div2.Visible = false;

							// Added by Abuzar on 05-01-2023
							//tblconfirm.Visible = false;
							tblconfirm.Visible = true;
							Confirm1.Enabled = false;
							Confirm2.Enabled = false;
							Confirm3.Enabled = false;
							// Added by Abuzar on 05-01-2023

							trReject.Attributes.Add("style", "display:none");
                            divRejectDetails.Attributes.Add("style", "display:none");
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            if (txtReInsurer.Text == "")
                            {
                                tblResonInsurer.Attributes.Add("style", "display:none");
                                txtReInsurer.Visible = false;
                                lblremark.Visible = false;
                                tblremarkinsurer.Visible = false;
                                lblremarkinsurer.Visible = false;
                            }
                            c1.Visible = false;
                            C2.Visible = false;
                            C3.Visible = false;
                            // FillData(Request.QueryString["CndNo"].ToString().Trim());
                            buttons.Visible = false;
                            tblCFRInboxCollapse.Visible = true;
                            divCFRInbox.Visible = true;
                            tblCFRInbox.Visible = true;
                            lblTitle1.Text = "NOC Approval Request";
                            lblcfrraised.Visible = false;
                            BindInboxGrid();
                            btnCancel.Visible = true;

                            btnCancel.Visible = true;
                            trCfrInbox.Visible = true;
                        }
                        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond1")
                        {
                            //tblreasonNOC1.Visible = false;
                            divNOCdetails.Visible = true;
                            // tblResonInsurer.Visible = false;
                            //tblremarkinsurer.Visible = false;
                            tblconfirm.Visible = true; // chnages by pallavi on 01032023
                            //tblconfirm2.Visible = true;// chnages by pallavi on 01032023
                            txtreasonleave.Enabled = true;// chnages by pallavi on 01032023
                            txtReInsurer.Enabled = true;// chnages by pallavi on 01032023
                            //txtreasonleave.Visible = false;
                            //// }
                            btnClear.Visible = false;
                            btnCancel1.Visible = true;
                            //tdreasontext.Visible = false;
                            c1.Visible = false;
                            C2.Visible = false;
                            C3.Visible = false;
                            trReject.Attributes.Add("style", "display:none");
                            divRejectDetails.Attributes.Add("style", "display:none");
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            if (txtReInsurer.Text == "")
                            {
                                tblResonInsurer.Attributes.Add("style", "display:none");
                                txtReInsurer.Visible = false;
                                lblremark.Visible = false;
                                tblremarkinsurer.Visible = false;
                                lblremarkinsurer.Visible = false;
                            }
                            //FillData(Request.QueryString["CndNo"].ToString().Trim());
                            buttons.Visible = false; 
                            tblCFRInboxCollapse.Visible = true;
                            divCFRInbox.Visible = true;
                            tblCFRInbox.Visible = true;
                            lblTitle1.Text = "NOC Approval Request";
                            lblcfrraised.Visible = true;
                            BindInboxGrid();
                            btnCancel.Visible = false;
                            btnCloseCfr.Visible = true;
                            // btnCancel.Visible = true;
                            btncancel12.Visible = true;
                            BtnApprove.Visible = false;
                            btnReject.Visible = false;
                            trCfrInbox.Visible = true;
                            Div2.Visible = true; // changes by pallavi on 01032023
                        }
                        //else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond")
                        //{
                        //    tblreasonNOC1.Visible = true;
                        //    divNOCdetails.Visible = true;
                        //    tblResonInsurer.Visible = true;
                        //    tblremarkinsurer.Visible = true;
                        //    tblconfirm.Visible = true;
                        //    tblconfirm2.Visible = true;
                        //    FillData(Request.QueryString["CndNo"].ToString().Trim());
                        //    buttons.Visible = false;
                        //    tblCFRInboxCollapse.Visible = true;
                        //    divCFRInbox.Visible = true;
                        //    tblCFRInbox.Visible = true;
                        //    lblTitle1.Text = "NOC Approval Request";
                        //    lblcfrraised.Visible = true;
                        //    BindInboxGrid();
                        //    btnCancel.Visible = true;
                        //    btnCloseCfr.Visible = false;
                        //    btnCancel.Visible = true;

                        //}
                        else
                        // adde by usha for CFR Respond for BM  
                        {


                            btnSave.Visible = false;
                            btnRespond.Visible = true;
                            btnCloseCfr.Visible = false;
                            BtnApprove.Visible = false;
                            btnReject.Visible = false;
                            btnClear.Visible = false;
                            dgDetailsInbox.Visible = true;
                            divCFRInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            tblCFRInbox.Visible = true;
                            //btnSubmit.Visible = true;
                            Confirm1.Enabled = false;
                            Confirm2.Enabled = false;
                            Confirm3.Enabled = false;
                            trdos.Visible = true;
                            trCfrInbox.Visible = true;
                            tblCFRInboxCollapse.Visible = true;
                            //  divInsurer.Attributes.Add("style", "display:none");
                            //  divInsurer.Visible = false;
                            lblTitle1.Text = "NOC Approval Request";
                            txtreasonleave.Enabled = false;
                            txtReInsurer.Enabled = false;
                            //txtreasonleave.Visible = false;
                            //// }
                            //tdreasontext.Visible = false;
                            btnCancel.Visible = true;
                            lblcfrraised.Visible = true;
                            BindInboxGrid();
                            // GetChkRespond();
                            FillData(Request.QueryString["CndNo"].ToString().Trim());
                            if (txtReInsurer.Text == "")
                            {
                                tblResonInsurer.Attributes.Add("style", "display:none");
                                txtReInsurer.Visible = false;
                                lblremark.Visible = false;
                                tblremarkinsurer.Visible = false;
                                lblremarkinsurer.Visible = false;
                            }
                            if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Cfr"].ToString().Trim() == "IN")
                            {
                                dgDetailsInbox.Columns[9].Visible = false;
                                Div2.Visible = false;
                                trReject.Attributes.Add("style", "display:none");
                                divRejectDetails.Attributes.Add("style", "display:none");
                            }
                            /////pnlMdlCnd.Attributes.Add("Style", "display:none");
                        }
                    }
                }


            }
            //usa 
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Cfr"].ToString().Trim() == "Res" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond1")
            {
                //comended by usha for si user on 25.01.2016
                // if (ViewState["MemberType"].ToString() .Trim()!= "SM")
                if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    // btnCloseCfr.Visible = true;
                    dgDetailsInbox.Columns[8].Visible = true;
                    btnRespond.Visible = false;
                }
                else
                {

                    Div2.Attributes.Add("style", "display:none");
                    divRejectDetails.Attributes.Add("style", "display:none");


                    btnRespond.Visible = false;
                }
				btnCloseCfr.Visible = true;
            }
            //Added by Nikhil to view NOC Details to Salesteam
            if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Code"].ToString().Trim() == "Spon" && Request.QueryString["Cfr"].ToString().Trim() == "IN")
            {
                if (Request.QueryString["Type"].ToString().Trim() == "NOCPage")
                {

                    trdos.Visible = true;
                    divCFRInbox.Attributes.Add("style", "display:none");
                    lblTitle1.Text = "NOC Approval Request";
                    txtreasonleave.Enabled = false;
                    txtReInsurer.Enabled = false;
                    //txtreasonleave.Visible = false;
                    //// }
                    btnClear.Visible = true;
                    btnCancel1.Visible = false;
                    //tdreasontext.Visible = false;
                    c1.Visible = false;
                    C2.Visible = false;
                    C3.Visible = false;
                    tblButton.Attributes.Add("style", "display:none");
                    FillData(Request.QueryString["CndNo"].ToString().Trim());
                    if (txtReInsurer.Text == "")
                    {
                        tblResonInsurer.Attributes.Add("style", "display:none");
                        txtReInsurer.Visible = false;
                        lblremark.Visible = false;
                        tblremarkinsurer.Visible = false;
                        lblremarkinsurer.Visible = false;
                    }
                    trReject.Attributes.Add("style", "display:none");
                    tblCFRInboxCollapse.Attributes.Add("style", "display:none");
                    tblconfirm.Attributes.Add("style", "display:none");
                    tblconfirm2.Attributes.Add("style", "display:none");
                    lblCndView.Visible = false;
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

            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

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
                htParam2.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                dsFlag1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondFlag", htParam2);
                string strFlag1 = dsFlag1.Tables[0].Rows[0]["Flag"].ToString();
                string strResponded = dsFlag1.Tables[0].Rows[0]["Responded"].ToString();
                string strClosed = dsFlag1.Tables[0].Rows[0]["Closed"].ToString();
                string DoCode = dsFlag1.Tables[0].Rows[0]["DocCode"].ToString();
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                LinkButton Reopen = (LinkButton)row.FindControl("LinkReopen");
                //commended by usha on 25.01.2016 for SI user 
              //  if (strFlag1 == "1" && strResponded == "1" && DoCode == lblCFRDocCode.Text && ViewState["MemberType"].ToString() == "SM ")
                if (strFlag1 == "1" && strResponded == "1" && DoCode == lblCFRDocCode.Text && ViewState["userrollcode"].ToString().Trim() == "SMUSER")
                {

                    //CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    chkassign.Checked = false;

                    chkassign.Enabled = false;
                    chkassign.BackColor = Color.LightGray;
                    row.BackColor = Color.LightGray;
                    //else{}
                    if (ViewState["Count"] != null)
                    {
                        RowCount = (int)ViewState["Count"];
                        RowCount = RowCount + 1;
                        ViewState["Count"] = RowCount;
                    }
                    else
                    {
                        RowCount = RowCount + 1;
                        ViewState["Count"] = RowCount;
                    }
                }

                else if (strFlag1 == "2" && strResponded == "1" && strClosed == "1" && DoCode == lblCFRDocCode.Text)
                {
                   // CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                    chkassign.Checked = false;
                    chkassign.Enabled = false;
                    dgDetailsInbox.Columns[3].Visible = false;
                    chkassign.BackColor = Color.LightGray;
                    row.BackColor = Color.LightGray;
                    Reopen.Enabled = false;
                    if (ViewState["Count"] != null)
                    {
                        RowCount = (int)ViewState["Count"];
                        RowCount = RowCount + 1;
                        ViewState["Count"] = RowCount;
                    }
                    else
                    {
                        RowCount = RowCount + 1;
                        ViewState["Count"] = RowCount;
                    }

                }
                else
                {
                    row.BackColor = Color.White;
                }
 if (ViewState["Count"] != null)
 {
               int i= (int)ViewState["Count"];
               i = i / 2;
               if (i == 0)
               {
                   i = 1;
               }
               else if (ViewState["Count"].ToString() == "3")
               {
                   i = i + 1;
               }
                          
                   if (dgDetailsInbox.Rows.Count == i)
                   {
                       btnCloseCfr.Visible = false;
                       btnRespond.Visible = false;
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
    private void GetAgentandUserDtls()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
                    ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
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
    private void GetAgentandUserDtlsNotSm()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls_lic(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                   // ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
                  //  ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
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

    private void FillData(string strCndNo)
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        //htDtls.Add("@Flag", "1");
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCAppCandidateDetails", htDtls);
        lblAppNoValue.Text = dsDtls.Tables[0].Rows[0]["AppNo"].ToString();
        lblAdvNameValue.Text = dsDtls.Tables[0].Rows[0]["Givenname"].ToString();
        lblCndNoValue.Text = dsDtls.Tables[0].Rows[0]["CndNo"].ToString();
        lblmobile.Text = dsDtls.Tables[0].Rows[0]["MobileTel"].ToString();
        lblpanno.Text = dsDtls.Tables[0].Rows[0]["PAN"].ToString();
        lblagencycodeValue.Text = dsDtls.Tables[0].Rows[0]["Agent_Broker_Code"].ToString();
        lbldateissuevalue.Text = dsDtls.Tables[0].Rows[0]["IssueDate"].ToString();
        lblsnlve.Text = dsDtls.Tables[0].Rows[0]["Leave_Type"].ToString();
        lbldoar.Text = dsDtls.Tables[0].Rows[0]["AcceptDate"].ToString();
        lbldate.Text = dsDtls.Tables[0].Rows[0]["submitDate"].ToString();
        txtReInsurer.Text = dsDtls.Tables[0].Rows[0]["RemarkforInsurer"].ToString();
        txtreasonleave.Text = dsDtls.Tables[0].Rows[0]["RemarksForLeave"].ToString();
        Confirm1.SelectedValue = dsDtls.Tables[0].Rows[0]["C1"].ToString();
        Confirm2.SelectedValue = dsDtls.Tables[0].Rows[0]["C2"].ToString(); 
        Confirm3.SelectedValue = dsDtls.Tables[0].Rows[0]["C3"].ToString();
        //if (Confirm1.SelectedValue == "1" || Confirm2.SelectedValue == "1" || Confirm3.SelectedValue == "1")
        //{
        //    Confirm1.Enabled = false;
        //    Confirm2.Enabled = false;
        //    Confirm3.Enabled = false;
        //}
    }
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
    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {


            lblTitle1.Text = olng.GetItemDesc("lblTitle");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            //lblCscCode.Text = olng.GetItemDesc("lblCscCode");
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");

            lblCnddtls.Text = olng.GetItemDesc("lblCnddtls");//Added by shreela on 10/03/14
            //  lblcndupload.Text = olng.GetItemDesc("lblcndupload");//Added by shreela on 11/03/14
            //lbldos.Text = olng.GetItemDesc("lbldos");



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
    // protected void Confirm1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Confirm1.SelectedValue == "0") //yes 
    //    {
    //        btnSave.Enabled = false;
    //        btnReject.Enabled = true;
    //        BtnApprove.Enabled = true;

    //    }

    //    else
    //    {
    //        btnSave.Enabled = true;
    //        btnReject.Enabled = false;
    //        BtnApprove.Enabled = false;
    //    }
    // }

    // protected void Confirm2_SelectedIndexChanged(object sender, EventArgs e)
    // {
    //    if (Confirm2.SelectedValue == "0") //yes 
    //    {
    //        btnSave.Enabled = false;
    //        btnReject.Enabled = true;
    //       BtnApprove.Enabled = true;

    //    }
    //    //if (Confirm2.SelectedValue == "1")
    //    //{
    //    //}
    //    else
    //    {
    //        btnSave.Enabled = true;
    //        btnReject.Enabled = false;
    //        BtnApprove.Enabled = false;
    //    }

    // }
    // protected void Confirm3_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Confirm3.SelectedValue == "0") //yes 
    //    {
    //        btnSave.Enabled = false;
    //        btnReject.Enabled = true;
    //        BtnApprove.Enabled = true;

    //    }

    //    else
    //    {
    //        btnSave.Enabled = true;
    //        btnReject.Enabled = false;
    //        BtnApprove.Enabled = false;
    //    }
    // }


    //#endregion

    //if (Confirm1.SelectedValue == "1" && Confirm2.SelectedValue == "1" && Confirm3.SelectedValue == "1")
    //     {
    //         btnSave.Enabled = true;
    //         btnReject.Enabled = false;
    //         BtnApprove.Enabled = false;
    //     }
    #region Button 'Cancel Click Event'
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NOCApp&Code=Spon&ModuleID=11140&AgtType=IS");
        //added by pallavi  on 01012023

        //    if (Request.QueryString["Status"].ToString().Trim() == "NOCCFR")
        //{
        //    if (Request.QueryString["Pg"].ToString().Trim() == "viewcfr")
        //    {
        //        Response.Redirect("NOCApprovalTeam.aspx?Pg=viewcfr&Status=NOCCFR&Code=Spon");
        //    }

        //}
        //else{
        //    Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NOCApp&Code=Spon&ModuleID=11140&AgtType=IS");
        //}

    }
    #endregion
    //#region Button 'Cancel Click Event'
    //protected void
    //    btnCancel_Click(object sender, EventArgs e)
    //{
    //    //Changed and added new code to close window start
    //    if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond")
    //    {
    //        Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=viewcfr&Status=NOCCFR&Code=Spon");
    //    }

    //    else
    //    {
    //        Response.Redirect("NOCApprovalTeam.aspx?Pg=viewcfr&Status=CVR&Code=Spon");
    //    }
    //    //Changed and added new code to close window end
    //}
    //#endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (lblresponded.Text == "Yes" && Confirm1.SelectedValue == "1")
            //{

            //    //ProgressBarModalPopupExtender.Hide();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select valid CheckBox ')", true);
            //    return;
            //}

            if (Confirm1.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Whether any amount is outstanding OR due to accounts ?')", true);
                return;
            }
            else if (Confirm2.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Whether any  Covernotes, Blank Forms, Commission receivable, Cheque Bounce recoverable pending from agent?')", true);
                return;
            }
            else if (Confirm3.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Return of appointment letter, ID card & POS keys if any')", true);
                return;
            }
            //else if (Confirm1.SelectedValue == "0" || Confirm2.SelectedValue == "0" || Confirm3.SelectedValue == "0")
            //{
            //    btnSave.Enabled = true;
            //    BtnApprove.Enabled = true;
            //    //ProgressBarModalPopupExtender.Hide();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please click on approve button otherwise select NO for cfr raise.')", true);
            //    return;


            //}
            string c1="", c2="", c3="";
           if (Confirm1.SelectedValue == "1" || Confirm2.SelectedValue == "1" || Confirm3.SelectedValue == "1")
            {

                btnReject.Enabled = true;
                BtnApprove.Enabled = false;
                Hashtable htparam1 = new Hashtable();
                DataSet dsapprovechk = new DataSet();
                htparam1.Add("@CndNo", lblCndNoValue.Text);
                //Label lblcfrraise = (Label)row.FindControl("lblcfr");
                dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam1);

                if (dsapprovechk.Tables.Count > 0)
                {
                    if (dsapprovechk.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt = dsapprovechk.Tables[0];
                        int i;
                        int flag = 0;
                        for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                        {
                            string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                            string CFRClosed = dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();
                            string CFRResponded = dsapprovechk.Tables[0].Rows[i]["CFRResponded"].ToString().Trim();
                            string remarkdescription = dsapprovechk.Tables[0].Rows[i]["RemarkDesc01"].ToString().Trim();
                          
                           
                          

                            // if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1") || (CFRResponded == "1" && CFRClosed == ""))
                            if (remarkdescription == "Whether any amount is outstanding OR due to accounts is pending")//"Premium receivable/Cheque bounces pending")
                            {
                                if (Confirm1.SelectedValue != "1")
                                {
                                    
                                   c1 = dsapprovechk.Tables[1].Rows[0]["c1"].ToString().Trim();
                                   if (c1 == "1")
                                   {
                                       flag = 1;
                                   }
                                }
                            }
                            if (remarkdescription == "Whether any Covernotes,Blank Forms,Commission receivable,Cheque Bounce recoverable pending")// "Cover note is Pending")
                            {
                                if (Confirm2.SelectedValue != "1")
                                {
                                    
                                    c2 = dsapprovechk.Tables[1].Rows[0]["c2"].ToString().Trim();
                                    if (c2 == "1")
                                    {
                                        flag = 1;
                                    }
                                }
                            }
                            if (remarkdescription == "Return of appointment letter, ID card & POS keys pending") //"Return of appointment letter, ID card & POS keys pending")
                            {
                                if (Confirm3.SelectedValue != "1")
                                {
                                    
                                    c3 = dsapprovechk.Tables[1].Rows[0]["c3"].ToString().Trim();
                                    if (c3 == "1")
                                    {
                                        flag = 1;
                                    }
                                }
                            }
                            if (flag == 1)
                            {
                                if ((CFRRaised == "1" && CFRClosed == "") || (CFRResponded == "1" && CFRClosed == ""))
                                {
                                    btnReject.Enabled = true;
                                    //ProgressBarModalPopupExtender.Hide();
                                    string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();

                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                    return;

                                    
                                }
                                else if ((CFRRaised == "1" && CFRResponded == "1" && CFRClosed == "1"))
                                {
                                    if (dsapprovechk.Tables[0].Rows.Count == 2)
                                    {
                                        if (dsapprovechk.Tables[0].Rows[0]["RemarkDesc01"].ToString() == "Whether any amount is outstanding OR due to accounts is pending")
                                        {
                                             if (Confirm2.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString() != "1" )//|| dsapprovechk.Tables[0].Rows[i + 2]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm2.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm3.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i + 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        if (dsapprovechk.Tables[0].Rows[0]["RemarkDesc01"].ToString() == "Whether any Covernotes,Blank Forms,Commission receivable,Cheque Bounce recoverable pending")
                                        {
                                            if (Confirm1.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString() != "1")//|| dsapprovechk.Tables[0].Rows[i + 2]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm1.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm3.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i + 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }


                                        if (dsapprovechk.Tables[0].Rows[0]["RemarkDesc01"].ToString() == "Return of appointment letter, ID card & POS keys pending")
                                        {
                                            if (Confirm1.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i - 1]["CFRClosed"].ToString() != "1")//|| dsapprovechk.Tables[0].Rows[i + 2]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm1.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i - 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm2.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i - 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    if (dsapprovechk.Tables[0].Rows.Count == 3)
                                    {
                                        if (i == 0)
                                        {
                                            if (Confirm2.SelectedValue == "0" || Confirm3.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i + 1]["CFRClosed"].ToString() != "1" || dsapprovechk.Tables[0].Rows[i + 2]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm2.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i + 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm3.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i + 2]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        if (i == 1)
                                        {
                                            if (Confirm1.SelectedValue == "0" || Confirm3.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i - 1]["CFRClosed"].ToString() != "1" && dsapprovechk.Tables[0].Rows[i + 1]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm1.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i - 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm3.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i + 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        if (i == 2)
                                        {
                                            if (Confirm1.SelectedValue == "0" || Confirm2.SelectedValue == "0")
                                            {
                                                if (dsapprovechk.Tables[0].Rows[i - 2]["CFRClosed"].ToString() != "1" && dsapprovechk.Tables[0].Rows[i - 1]["CFRClosed"].ToString() != "1")
                                                {
                                                    if (Confirm1.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i - 2]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    else if (Confirm2.SelectedValue == "0")
                                                    {
                                                        //ProgressBarModalPopupExtender.Hide();
                                                        string CFRFor = dsapprovechk.Tables[0].Rows[i - 1]["CFRFor"].ToString().Trim();

                                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                                        return;

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    htparam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
                                    htparam1.Add("@ApproveBy", Session["UserID"].ToString().Trim());
                                    htparam1.Add("@AppNo", lblAppNoValue.Text);
                                    htparam1.Add("@C1", Confirm1.SelectedValue);
                                    htparam1.Add("@C2", Confirm2.SelectedValue);
                                    htparam1.Add("@C3", Confirm3.SelectedValue);
                                    DataSet Dssave = new DataSet();
                                    Dssave = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCAppDtlsSave", htparam1);
                                    btnSave.Enabled = false;
                                    lblus.Text = "Saved Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                                  //  mdlpopupSub.Show();
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                }

                                flag = 0;
                            }
                            
                               
                            }
                        }
                    else
                    {
                        Hashtable htParam1 = new Hashtable();
                        DataSet dsIns = new DataSet();



                        htParam1.Add("@CndNo", lblCndNoValue.Text);

                        htParam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
                        htParam1.Add("@AppNo", lblAppNoValue.Text);
                        htParam1.Add("@C1", Confirm1.SelectedValue);
                        htParam1.Add("@C2", Confirm2.SelectedValue);
                        htParam1.Add("@C3", Confirm3.SelectedValue);
                        dsIns = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCAppDtls", htParam1);

                       // lblMessage.Text = "Save Successfully";

                        lblus.Text = "Saved Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        // mdlpopupSub.Show();

                        tdPopUp.Visible = true;
                        lblMessage.Visible = true;
                        btnSave.Enabled = false;
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


    protected void btnCFROk_Click(object sender, EventArgs e)
    {
          //GetChkRespond();
        
          GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
          dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
          DataSet dsFlag = new DataSet();
          string id = "";
          foreach (GridViewRow row in Assignedcfr)
          {
              CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
              Label lblRemarkid = (Label)row.FindControl("lblRemarkid");
              Label lblcfr = (Label)row.FindControl("lblcfr");
              Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
              Label lblcfrraise = (Label)row.FindControl("lblcfr");
              Label lblresponded = (Label)row.FindControl("Responded");
              Hashtable htPram2 = new Hashtable();
              htPram2.Add("@DocCode", lblCFRDocCode.Text);
              dsFlag = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_getclosecfr", htPram2);
              string CFRDesc = dsFlag.Tables[0].Rows[0]["Flag"].ToString();
              if (row.BackColor == Color.LightGray)
              { 
                 // commended by usha for si user on 25.01.2015
                 // if (ViewState["MemberType"].ToString() .Trim()!= "SM")
                  if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                  {
                      //id="lblHasAgent67";
                      //string doccode = id.Substring(11, 12);
                     
                      if (CFRDesc=="1")
                      {
                          if (lblresponded.Text == "Yes" && Confirm1.SelectedValue == "1")
                          {
                              Confirm1.Enabled = true;
                              BtnApprove.Enabled = true;
                              //ProgressBarModalPopupExtender.Hide();
                              //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Yes confermation. " + lblHasAgent.Text.Trim() + " ')", true);
                              //// ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select valid confermation.')", true);
                              //return;
                          }
                          // count = 0 + 1;

                      }
                      else if (CFRDesc == "3")
                      {
                          if (lblresponded.Text == "Yes" && Confirm2.SelectedValue == "1")
                          {
                              Confirm2.Enabled = true;
                              BtnApprove.Enabled = true;
                              ////ProgressBarModalPopupExtender.Hide();
                              //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Yes confermation. " + Label3.Text.Trim() + " ')", true);
                              //return;
                          }
                          // count = 1 + 1;

                      }
                      else if (CFRDesc == "2")
                      {
                          if (lblresponded.Text == "Yes" && Confirm3.SelectedValue == "1")
                          {
                              Confirm3.Enabled = true;
                              BtnApprove.Enabled = true;
                              ////ProgressBarModalPopupExtender.Hide();
                              //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Yes confermation. " + Label5.Text.Trim() + " ')", true);
                              //return;
                          }
                          //count = 2 + 1;
                      }



                  }

              }

          }
        //if(dgDetailsInbox.Rows.Count>=3 && dgDetailsInbox.)
          
        //  {

        //          btnCloseCfr.Visible = false;
             
        //  }

      
    }
    //protected void btnnoksub_click(object sender, EventArgs e)
    //{
    //    DataSet dsFlag1 = new DataSet();
    //    Hashtable htParam2 = new Hashtable();
    //    htParam2.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //    dsFlag1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondFlag", htParam2);
    //    string strFlag1 = dsFlag1.Tables[0].Rows[0]["Flag"].ToString();

    //    if (strFlag1 == "1")
    //    {
    //        foreach (GridViewRow row in dgDetailsInbox.Rows)
    //        {
    //            CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
    //            chkassign.Checked = true;
    //            chkassign.Enabled = false;
    //        }
    //    }
    //    else { }
    //}


    private void GetAgentandUserDtls_lic()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls_lic(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["userrollcode"] = dsAgent.Tables[0].Rows[0]["UserRoleCode"].ToString();

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
    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        try
        {  int count = 0;
            btnRespond.Visible = false;
            GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
            dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
            DataSet dsFlag = new DataSet();
            foreach (GridViewRow row in Assignedcfr)
            {
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                Label lblRemarkid = (Label)row.FindControl("lblCFRRemarkid");
                Label lblRemarkDid = (Label)row.FindControl("lblRemarkid");
                Label lblcfr = (Label)row.FindControl("lblcfr");
                Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
                Label lblcfrraise = (Label)row.FindControl("lblcfr");
                Label lblresponded = (Label)row.FindControl("Responded");


                if (row.BackColor == Color.LightGray)
                {


                    DataSet dsApp = new DataSet();
                    DataSet dsFinalApp = new DataSet();
                    Hashtable htParam2 = new Hashtable();
                    htParam2.Clear();
                    htParam.Clear();
                    htParam2.Add("@RemarkId", lblRemarkid.Text.Trim());
                    htParam2.Add("@DocCode", lblCFRDocCode.Text.Trim());
                    htParam2.Add("@CndNo", lblCndNoValue.Text);
                    htParam2.Add("@UserId", Session["UserID"].ToString());
                    dsApp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRaise", htParam2);
                    string strFlag3 = dsApp.Tables[0].Rows[0]["Flag"].ToString();
                    string strUserId = dsApp.Tables[0].Rows[0]["UserType"].ToString();
                   
                    if (strFlag3 == "1" || strFlag3 == "2")
                    {


                        if (strUserId == "covernote")
                        {
                            htParam.Add("@Flag", "1");
                        }
                        else if (strUserId == "Receivable")
                        {
                            htParam.Add("@Flag", "2");
                        }
                        else if (strUserId == "ChqBounce")
                        {
                            htParam.Add("@Flag", "3");
                        }
                        else if (strUserId == "CmmRcvable")
                        {
                            htParam.Add("@Flag", "4");
                        }
                        else if (strUserId == "Account")
                        {
                            htParam.Add("@Flag", "5");
                        }
                        else
                        {
                            htParam.Add("@Flag", "");
                        }

                        htParam.Add("@CndNo", lblCndNoValue.Text);
                        htParam.Add("@AppNo", lblAppNoValue.Text);
                        htParam.Add("@CreateBy", Session["UserID"].ToString());
                        htParam.Add("@Role", Request.QueryString["type"].ToString().Trim());

                        htParam.Add("@Approve", "1");
                        dsFinalApp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCTeamApp", htParam);

                    }

                }
            }

            lblMessage.Text = "Approved Successfully";

            lblus.Text = " NOC Approved Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
           // mdlpopupSub.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            //tdPopUp.Visible = true;
            btn_Approve.Visible = false;

        }
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
    protected void BtnApprove_Click(object sender, EventArgs e)
    {
        try
        {
             
            GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
            dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
            DataSet dsFlag = new DataSet();
            foreach (GridViewRow row in Assignedcfr)
            {
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                Label lblRemarkid = (Label)row.FindControl("lblRemarkid");
                Label lblcfr = (Label)row.FindControl("lblcfr");
                Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
                Label lblcfrraise = (Label)row.FindControl("lblcfr");
                Label lblresponded = (Label)row.FindControl("Responded");



                if (lblcfr.Text == lblHasAgent79.Text)
                {
                    if (lblresponded.Text == "Yes" && Confirm1.SelectedValue == "1")
                    {
                        Confirm1.Enabled = true;
                        //ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select No Confirmation " + lblHasAgent79.Text.Trim() + " ')", true);
                       // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select valid confermation.')", true);
                        return;
                    }

                }
                if (lblcfr.Text == Label380.Text)
                {
                    if (lblresponded.Text == "Yes" && Confirm2.SelectedValue == "1")
                    {
                        Confirm2.Enabled = true;
                        //ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select No Confirmation " + Label380.Text.Trim() + " ')", true);
                        return;
                    }
                    
                }
                if (lblcfr.Text == Label581.Text)
                {
                    if (lblresponded.Text == "Yes" && Confirm3.SelectedValue == "1")
                    {
                        Confirm3.Enabled = true;
                        //ProgressBarModalPopupExtender.Hide();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select No Confirmation " + Label581.Text.Trim() + " ')", true);
                        return;
                    }
                   
                }
              
               
            }
            if (Confirm1.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Whether any amount is outstanding OR due to accounts')", true);
                return;
            }
            else if (Confirm2.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Whether any cover notes are pending')", true);
                return;
            }
            else if (Confirm3.SelectedValue == "")
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Return of appointment letter, ID card & POS keys if any')", true);
                return;
            }

            else if (Confirm1.SelectedValue == "0" && Confirm2.SelectedValue == "0" && Confirm3.SelectedValue == "0")
            {

                btnReject.Enabled = false;
                btnSave.Enabled = false;
                Hashtable htParam1 = new Hashtable();
                DataSet dsIns = new DataSet();
                //

                Hashtable htparam1 = new Hashtable();
                DataSet dsapprovechk = new DataSet();
                htparam1.Add("@CndNo", lblCndNoValue.Text);
                dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam1);

                if (dsapprovechk.Tables.Count > 0)
                {
                    if (dsapprovechk.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                        {
                            string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                            string CFRClosed = dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();
                            string CFRResponded = dsapprovechk.Tables[0].Rows[i]["CFRResponded"].ToString().Trim();
                            if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1")|| (CFRResponded == "1" && CFRClosed == ""))
                            {
                                btnReject.Enabled = true;
                                //ProgressBarModalPopupExtender.Hide();
                                string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR  for " + CFRFor + " ')", true);
                                return;

                            }
                        }
                    }
                }



                htParam1.Add("@CndNo", lblCndNoValue.Text);
                htParam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
                htParam1.Add("@ApproveBy", Session["UserID"].ToString().Trim());
                htParam1.Add("@AppNo", lblAppNoValue.Text);
                htParam1.Add("@C1", Confirm1.SelectedValue);
                htParam1.Add("@C2", Confirm2.SelectedValue);
                htParam1.Add("@C3", Confirm3.SelectedValue);
                htParam1.Add("@Flag", "1");
                
                htParam1.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                dsIns = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCAppDtls", htParam1);

                //lblMessage.Text = "Approved Successfully";

                lblus.Text = "NOC Approved Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                // mdlpopupSub.Show();
                //tdPopUp.Attributes.Add("style","display:none");
                Confirm1.Enabled = false;
                Confirm2.Enabled = false;
                Confirm3.Enabled = false;
                lblMessage.Visible = true;
                BtnApprove.Visible = false;
                btnReject.Visible = false;


            }
            else if (Confirm1.SelectedValue == "1" || Confirm2.SelectedValue == "1" || Confirm3.SelectedValue == "1")
            {
                btnSave.Enabled = true;
                BtnApprove.Enabled = true;
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please click on save button for cfr raise otherwise select all No for approve.')", true);
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
            if (cbRejectFlag.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Reason for Reject')", true);
                //ProgressBarModalPopupExtender.Hide();
                cbRejectFlag.Focus();
                return;
            }
            else
            {
                if (txtReject.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Reason for Reject')", true);
                    //ProgressBarModalPopupExtender.Hide();
                    txtReject.Focus();
                    return;
                }
                else
                {

                    //        htParam1.Add("@C1", Confirm1.SelectedValue);
                    //        htParam1.Add("@C2", Confirm2.SelectedValue);
                    //        htParam1.Add("@C3", Confirm3.SelectedValue);
                    //        htParam1.Add("@Flag", "2");

    //        dsIns = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCAppDtls", htParam1);

    //        lblMessage.Text = "Reject successfully";

    //        lblSub.Text = "Reject successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
    //        mdlpopupSub.Show();
    //        lblMessage.Visible = true;
    //        BtnApprove.Enabled = false;
    //        btnSave.Enabled = false;
    //        btnReject.Enabled = false;
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
   // }
        
   

             Hashtable htParam = new Hashtable();
            DataSet dsIns = new DataSet();
            htParam.Add("@CndNo", lblCndNoValue.Text);
            htParam.Add("@CreateBy", Session["UserID"].ToString().Trim());
            htParam.Add("@Reasonreject", txtReject.Text.ToString().Trim());;
            htParam.Add("@AppNo", lblAppNoValue.Text);
                        htParam.Add("@Reject", "1");
                       
                        dsIns = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCTeamApp", htParam);
                        dsIns.Clear();
                        lblMessage.Visible = true;
                        lblMessage.Text = "NOC Rejected Successfully";
                        lblus.Text = " NOC Rejected Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        tdPopUp.Visible = true;
                        lblMessage.Visible = true;
                        BtnApprove.Enabled = false;
                        btnSave.Enabled = false;
                        btnReject.Enabled = false;
                        Confirm1.Enabled = false;
                        Confirm2.Enabled = false;
                        Confirm3.Enabled = false;

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
    protected void lblCndView_Click(object sender, EventArgs e)
    {


        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

    }


    protected void btnRespond_Click(object sender, EventArgs e)
    {
        int count = 0;
        string docCodeNo = string.Empty;
        string docCodeYes = string.Empty;
        GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
        dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
        //Hashtable htParam = new Hashtable();
        DataSet dsFlag = new DataSet();
        //            htParam.Add("@UserId",Session["UserID"].ToString());
        //            htParam.Add("@UserId", Session["DocCode"].ToString());
        //            htParam.Add("@RemarkId", Session["RemarkId"].ToString());
        //            htParam.Add("@Flag", "R");

        //else 
        //{ }

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
                // Label lblCFRRemarkID = (Label)e.Row.FindControl("lblCFRRemarkID");
                //htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                htCFR.Add("@DocCode", lblCFRDocCode.Text.Trim());
                htCFR.Add("@Flag", "S");
                dsFlag = dataAccessRecruit.GetDataSetForPrcRecruit("prc_getcfr", htCFR);
                string strFlag = dsFlag.Tables[0].Rows[0]["Flag"].ToString();
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
                htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                htCFR.Add("@CFRfor", lblcfr.Text.Trim());
                htCFR.Add("@RespondedBy", Session["UserID"].ToString().Trim());

                if (lblCFRFlagType.Text.Trim() == "1")
                {
                    dataAccessRecruit.execute_sprcrecruit("Prc_CFRRespondForIRDA", htCFR);
                    BindInboxGrid();
                    //lblcfrrespnd.Text = "Responded successfully";
                    lblus.Text = "Closed Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text +
                    "<br/>Note :- Please proceed with Update.";
                    //mdlCFRRespond.Show();
                    //pnlMdl1.Visible = true;
                }
                else if (lblCFRFlagType.Text.Trim() == "2")
                {
                    dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedNOCCFR_bracheduser", htCFR);
                    //CheckBox chkassign1 = (CheckBox)row.FindControl("ChkAssigned");
                    BindInboxGrid();
                    //lblcfrrespnd.Text = "Responded successfully";
                    lblus.Text = "CFR Responded Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
                    //added by pallavi on 20022023
                    //+lblAdvNameValue.Text +
                    // "<br/>Note :- Please proceed with Update.";
                    //  mdlCFRRespond.Show();
                    // pnlMdl1.Visible = true;
                    // chkassign.Enabled = false;


                    //chkassign.Enabled = false;

                    //chkassign.Enabled = true;

                    //Hashtable htParam1 = new Hashtable();
                    //DataSet dsIns = new DataSet();



                    // htParam1.Add("@CndNo", lblCndNoValue.Text);

                    //htParam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
                    //htParam1.Add("@AppNo", lblAppNoValue.Text);
                    //htParam1.Add("@C1", Confirm1.SelectedValue);
                    //htParam1.Add("@C2", Confirm2.SelectedValue);
                    //htParam1.Add("@C3", Confirm3.SelectedValue);
                }
                count = count + 1;
                GetChkRespond();

            }
            
        }

        if (count > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
           
           // mdlCFRRespond.Show();
           // pnlMdl1.Visible = true;
            
        }
        else
        {
            //ProgressBarModalPopupExtender.Hide();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox')", true);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select valid confermation.')", true);
            return;
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
    protected void dgDetailsInbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
                //if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Lic")
                //comended by usha for si user on 25.01.2016
                //if (ViewState["MemberType"].ToString() .Trim()!= "SM")
             if   (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                   // if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Status"].ToString() == "NOCCFR")

                    if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["user"].ToString() == "Brn" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond1S")
                    //{
                    {
                        LinkButton LinkReopen = (LinkButton)e.Row.FindControl("LinkReopen");
                        Label LblRemark = (Label)e.Row.FindControl("LblRemark");
                        Label lblcfr = (Label)e.Row.FindControl("lblcfr");
                        Label lblCFRDocCode = (Label)e.Row.FindControl("lblCFRDocCode");
                        Label lblRemarkidValue = (Label)e.Row.FindControl("lblRemarkid");
                        //Label lblresponded = (Label)e.Row.FindControl("Responded");
                        dgDetailsInbox.Columns[9].Visible = true;
                        LinkReopen.Visible = true;

                    }
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
            //comended by usha for si user on 25.01.2016
            //if (ViewState["MemberType"].ToString() .Trim()!= "SM")
           if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            // Label lblCndno = (Label)row.FindControl("lblCndNo");
            LinkButton LinkReopen = (LinkButton)row.FindControl("LinkReopen");
            Label LblRemark = (Label)row.FindControl("LblRemark");
            Label lblcfr = (Label)row.FindControl("lblcfr");
            Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
            Label lblRemarkidValue = (Label)row.FindControl("lblRemarkid");
            Label lblAddnlRemark = (Label)row.FindControl("lblAddnlRemark");
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();              
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "FuncReOpen('" + lblRemarkidValue.Text + "','" + ModuleID + "','" + lblAddnlRemark.Text + "');", true);
            MdlPopReOpenCFR.Show();

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
                        //tblCFRInboxCollapse.Visible = false;
                        //divCFRInbox.Attributes.Add("Style", "display:none");
                    }
                    else
                    {
                       
                        dgDetailsInbox.DataBind();
                         //comended by usha for si user on 25.01.2016
                       // if (ViewState["MemberType"].ToString() == "SM ")// || ViewState["MemberType"].ToString() .Trim()!= "SM")
                       if (ViewState["userrollcode"].ToString().Trim() =="SMUSER")

                        {
                            //foreach (GridViewRow row in dgDetailsInbox.Rows)
                            //{
                                GetChkRespond();
                            //}//dgDetailsInbox.Rows[0].Visible = true;
                        }
                        else
                        {
                            //foreach (GridViewRow row in dgDetailsInbox.Rows)
                            //{
                                GetChkRespond();
                            //}
                        }
                      
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
            //htParam.Clear();
            //htParam.Add("@MemberCode", MemberCode);
            //htParam.Add("@MemberType", MemberType);
            //htParam.Add("@CndNo", "");
            //htParam.Add("@AppNo", "");
            //htParam.Add("@CndName", "");
            //htParam.Add("@Flag", "1");
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@Flag", "NC");
           

           // GetAgentandUserDtlsNotSm();
             //comended by usha for si user on 25.01.2016

            //if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond1" && Request.QueryString["Type"].ToString() == "Res" && ViewState["MemberType"].ToString() == "SM ")
            if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond1" && Request.QueryString["Type"].ToString() == "Res" && ViewState["userrollcode"].ToString().Trim() == "SMUSER")
            {
                   
             //   htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    htParam.Add("@UserId", Request.QueryString["UserId"].ToString());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htParam);
                    ViewState["Responded"] = dsResult.Tables[0].Rows[0]["Responded"].ToString().Trim();
                    if (dsResult == null)
                    {
                        tblCFRInboxCollapse.Visible = false;
                    }
                   
                }
            //comended by usha for si user on 25.01.2016
            //else if (ViewState["MemberType"].ToString() .Trim()!= "SM")
            //else if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
            //Added by Rajkapoor Yadav on 01/04/2022

            //else if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") && (ViewState["userrollcode"].ToString().Trim() != "RMUser") || 
            //(ViewState["userrollcode"].ToString().Trim() == "SMUSER" ))  /*&& Request.QueryString["userrollcode"].ToString() == "RptMgr"*/  /*Commit by pallavi on 21022023 for SMuser view cfr*/
            

            else if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
           (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
            {
                // if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["status"].ToString() == "Brn")
                if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Type"].ToString() == "QcRes" && Request.QueryString["user"].ToString() == "Brn")
                {
                    //   htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htParam);//added bu usha 

                }
                else if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond1")
                {
                    htParam.Add("@UserId", Request.QueryString["UserId"].ToString());
                    htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString()); // added by pallavi on 01032023
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htParam);
                }
                else
                {
                    //Hashtable htparam = new Hashtable();
                    htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    //  htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                    htParam.Add("@UserId", Session["UserID"].ToString().Trim());
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR", htParam);
                    // ViewState["Responded"] = dsResult.Tables[0].Rows[0]["Responded"].ToString().Trim();


                }
                if (dsResult.Tables[0].Rows.Count > 0 && ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    btnRespond.Visible = false; 
                }
            

            }
           
            //For SM user 
            else
            {
              //  htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                //htParam.Add("@UserId", Request.QueryString["CreatedBy"].ToString());


                //htParam.Add("@Flag1", Request.QueryString["Cfr"].ToString());
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RespondedCFR_bracheduser", htParam);
                //btnCloseCfr.Visible = false;
                //ViewState["Responded"] = dsResult.Tables[0].Rows[0]["Responded"].ToString().Trim();
                

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


    protected void btnCloseCfr_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            btnRespond.Visible = false;
            GridViewRow[] Assignedcfr = new GridViewRow[dgDetailsInbox.Rows.Count];
            dgDetailsInbox.Rows.CopyTo(Assignedcfr, 0);
            DataSet dsFlag = new DataSet();
            foreach (GridViewRow row in Assignedcfr)
            {
                CheckBox chkassign = (CheckBox)row.FindControl("ChkAssigned");
                Label lblRemarkid = (Label)row.FindControl("lblCFRRemarkid");
                Label lblRemarkDid = (Label)row.FindControl("lblRemarkid");
                Label lblcfr = (Label)row.FindControl("lblcfr");
                Label lblCFRDocCode = (Label)row.FindControl("lblCFRDocCode");
                Label lblcfrraise = (Label)row.FindControl("lblcfr");
                Label lblresponded = (Label)row.FindControl("Responded");
               
                
                if (chkassign.Checked == true)
                {
                    Hashtable htCFR = new Hashtable();
                    htCFR.Clear();
                    dsResult.Clear();
                    htCFR.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htCFR.Add("@UserId", Session["UserID"].ToString().Trim());
                    htCFR.Add("@RemarkId", lblRemarkid.Text.Trim());
                    htCFR.Add("@DocCode", lblCFRDocCode.Text.Trim());
                    htCFR.Add("@Flag", "c");
                  //  htParam.Add("@UserType1", Request.QueryString["type".ToString().Trim()]);
                    dsFlag = dataAccessRecruit.GetDataSetForPrcRecruit("prc_getcfr", htCFR);
                    string strFlag = dsFlag.Tables[0].Rows[0]["Flag"].ToString();
                    //if (strFlag == "0")
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not authorized to close cfr for " + lblcfrraise.Text.Trim() + " ')", true);
                    //    return;
                    //}
                    Hashtable htparam5 = new Hashtable();
                    DataSet dsapprovechk = new DataSet();
                    htparam5.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    htparam5.Add("@RemarkId", lblRemarkDid.Text.Trim());
                    htparam5.Add("@Flag", "1");
                    htparam5.Add("@UserId", Session["UserID"].ToString());
                    dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam5);

                    if (dsapprovechk.Tables.Count > 0)
                    {
                        if (dsapprovechk.Tables[0].Rows.Count > 0)
                        {
                            int i;
                            for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                            {
                                string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                                string CFRResponded = dsapprovechk.Tables[0].Rows[i]["CFRResponded"].ToString().Trim();

                                if ((CFRRaised == "1" && CFRResponded == "") )
                                {

                                    //ProgressBarModalPopupExtender.Hide();
                                    string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CFR still raised for " + CFRFor + " Please Close the CFR first ')", true);
                                    return;
                                }
                            }
                        }
                    }
                    htCFR.Remove("@DocCode");
                    htCFR.Remove("@Flag");
                    //htCFR.Remove("@UserId");
                    //if (lblresponded.Text == "Yes")
                    //{
                       
                    //    Confirm1.Enabled = true;
                    //    Confirm2.Enabled = true;
                    //    Confirm3.Enabled = true;
                       // Hashtable htCFR = new Hashtable();
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

                        if (dsclose.Tables[0].Rows[0]["ProcessType"].ToString().Trim() == "NC")
                        {
                            htCFR.Add("@Flag", "NC");
                        }
                     
                        {
                            dataAccessRecruit.execute_sprcrecruit("Prc_Submit_AssignedCFR_admin", htCFR);
                        }
                       
                        
                        BindInboxGrid();

                        count = count + 1;
                }
               
            }
            if (count > 0)
            {
                lblus.Text = "Closed Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No.:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;

              //  mdlCFRRespond.Show();
                //GetChkRespond();
              //  pnlMdl1.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                //btnCloseCfr.Visible = true;
                BtnApprove.Visible = true;
                BtnApprove.Enabled = true;
                btnSave.Visible = false;
                btnClear.Visible = true;
                btnReject.Visible = true;
                btnCancel.Visible = false;
                btnCloseCfr.Visible = false;
                Confirm1.Enabled = true;
                Confirm2.Enabled = true;
                Confirm3.Enabled=true;
                // added by pallavi on 25022023

                if (Request.QueryString["TrnRequest"].Trim() == "CFRRespond1")
                {
                    btn_Approve.Visible = true;
                }
                
            }
            else
            {
                //ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox')", true);
              
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

    protected void ChkAssigned_CheckedChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["TrnRequest"].ToString() == "CFRRespond" && Request.QueryString["Cfr"].ToString() == "Res")
        {
            btnRespond.Visible = false;
            btnCloseCfr.Visible = true;
        }
        //comended by usha for si user on 25.01.2016
        //else if (ViewState["MemberType"].ToString() .Trim()!= "SM")
        else if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
       (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))


        {
            if (Request.QueryString["Cfr"].ToString().ToUpper() == "IN")
            {
                //if (Confirm1.SelectedValue == "1" || Confirm2.SelectedValue == "1" || Confirm3.SelectedValue == "1")
                // Confirm1.Enabled = true;
                //Confirm2.Enabled = true;
                //Confirm3.Enabled=true;
                btnRespond.Visible = true;
                btnCloseCfr.Visible = false; // changes by pallavi in 24022023

            }
            else
            {
                btnRespond.Visible = false;
                btnCloseCfr.Visible = true;
            }
        }
        else
        {
            if (Request.QueryString["Cfr"].ToString().ToUpper() == "IN")
            {


                btnRespond.Visible = true; ; // changes on 28022023
                btnCloseCfr.Visible = false;

            }
            else
            {
                btnRespond.Visible = false;
                btnCloseCfr.Visible = true;

            }

        }
    }
    protected void Confirm1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Confirm1.SelectedValue == "0" && Confirm2.SelectedValue == "0" && Confirm3.SelectedValue == "0" )
        {
            BtnApprove.Enabled = true;
            btnSave.Enabled = false;
        }
        //else {
            
        //    btnSave.Enabled = true;
        //    BtnApprove.Enabled = false;
        //}
    }
    protected void Confirm2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Confirm1.SelectedValue == "0" && Confirm2.SelectedValue == "0" && Confirm3.SelectedValue == "0")
        {
            BtnApprove.Enabled = true;
            btnSave.Enabled = false;
        }
        //else
        //{
            
        //    btnSave.Enabled = true;
        //    BtnApprove.Enabled = false;
        //}
    }
    protected void Confirm3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Confirm1.SelectedValue == "0" && Confirm2.SelectedValue == "0" && Confirm3.SelectedValue == "0")
        {
            BtnApprove.Enabled = true;
            btnSave.Enabled = false;
        }
        //else
        //{
          
        //    btnSave.Enabled = true;
        //    BtnApprove.Enabled = false;

        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //if (Request.QueryString["Cfr"] == "IN")

        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" &&  Request.QueryString["Type"].ToString().Trim() == "QcRes" 
            && Request.QueryString["Cfr"].ToString().Trim().ToUpper() == "IN" )
        {
            Response.Redirect("BrnAdvTrn50HrsSearch.aspx?Pg=viewcfr&User=Brn&Code=Spon&ModuleID=11062&AgtType=IS");
       //dded by pallavi on 20022023
        }
        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Cfr"].ToString().Trim().ToUpper() == "IN")
        {
            Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=viewcfr&User=Brn&Code=Spon");
        }
        else if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRCVR" && Request.QueryString["Cfr"].ToString().Trim().ToUpper() == "IN")
        {
            Response.Redirect("NOCApprovalTeam.aspx?Pg=viewcfr&Status=NOCCFR&Code=Spon");
         
        }
        else
        {
            Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=viewcfr&User=Brn&Code=Spon");
        }
    }


    protected void BindLabels()
    {
        try
        {
            DataSet dscount = new DataSet();
            Hashtable htcount = new Hashtable();
            htcount.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (ViewState["ProcessType"].ToString() != "NC")
            {
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
            }
            else
            {
                htcount.Add("@Flag", "NC");
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

    protected void btnok_Click(object sender, EventArgs e)
    {

    }

    protected void btnClear1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] == "N")
        {
            String ModuleID = string.Empty;
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();

            //Response.Redirect("CndEnq.aspx?Type=PREFFEXM&ModuleID="+ ModuleID);
            //Added by pallavi on 13.12.2022
            Response.Redirect("AdvTrn50HrsSearch.aspx?Type=N&ModuleID=" + ModuleID + "&Pg=50hrs&Status=NOCApp&Code=Spon&AgtType=IS"); //Added by pallavi on 21.02.2023
            // Response.Redirect("CndEnq.aspx?ModuleId=" + Request.QueryString["ModuleID"].ToString().Trim() + "&Type=PREFFEXM" + "&AgtType=" + Request.QueryString["AgtType"].ToString().Trim());

            // Type = PREFFEXM & ModuleID = 11060 & AgtType = IS


        }
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"
             && Request.QueryString["Cfr"].ToString().Trim().ToUpper() == "IN")
        {
            Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=viewcfr&Status=NOCCFR&Code=Spon&ModuleID=11141&userrollcode=RptMgr");
            //dded by pallavi on 21022023 for BM/RM view CFR
        }

      

        //if (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"
        // && Request.QueryString["Cfr"].ToString().Trim().ToUpper() == "IN")
        //{
        //    Response.Redirect("BrnAdvTrn50HrsSearch.aspx?Pg=viewcfr&User=Brn&Code=Spon&ModuleID=11062&AgtType=IS");
        //    //dded by pallavi on 20022023
        //}


    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("BrnAdvTrn50HrsSearch.aspx?Pg=viewcfr&User=Brn&Code=Spon&ModuleID=11062&AgtType=IS");

    }
}

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
//Added by rachana for fees details Webservice end
public partial class Application_INSC_Recruit_NOC : BaseClass
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
    string CandidateType;
    //added by rachana for sysfreezedate end
    #endregion

    #region Page_Load Events events
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
                    if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
                    {
                       // txtdos.Focus();
                        btnReject.Visible = false;
                        btnSave.Visible = false;
                        trupload.Visible = false;
                        tblupload.Visible = false;
                        btnSubmit.Visible = false;
                        btnClear.Visible = false;
                        dgView.Visible = false;
                        trdos.Visible = true;
                        tblCFRInboxCollapse.Visible = false;
                        tblCFRInbox.Visible = false;
                        lblTitle1.Text = "NOC Request Search"; //changes by pallavi
                        tblphoto.Visible = false;
                        txtreasonleave.Visible = true;
                        trunder.Visible = false;
                        tdreasontext.Visible = true;
                        lblreasontext.Visible = true;
                        Panelphoto2.Visible = false;
                        divnavigate.Visible = false;
                        tblupload.Visible = false;
                        radioReason.Enabled = true;
                        txtreasonleave.Enabled = true;
                        txtdos.Enabled = false;
                        txtdoa.Enabled = false;
                        //btnSubmit.Visible = true;
                        // btnClear.Visible = true; //comment by pallavi
                       //btnNextPannel1.visible = true;
                       lblTitle1.Visible = false;
                      // Added by pallavi
                       divPDH.Attributes.Add("style", "color:#00cccc !important;");
                       span5.Attributes.Add("style", "background-color: #00cccc !important");
                       span9.Attributes.Add("style", "background-color: #8c8c8c !important");
                       GetCandidateDtls();
                        FillData(Request.QueryString["CndNo"].ToString().Trim());
                    }
                        #region QC section
                        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start 
                    if (Request.QueryString["TrnRequest"].ToString().Trim() == "QCNoc" && Request.QueryString["Type"].ToString().Trim() == "QCNoc")
                        {
                            lblTitle1.Text = "NOC QC Request";
                            hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                            BindGrid();
                            // BindCompositeGrid(Request.QueryString["CndNo"].ToString());
                            txtdos.Enabled = false;
                            txtdoa.Enabled = false;
                            radioReason.Enabled = false;
                            txtreasonleave.Enabled = false;
                            btnupd.Visible = false;
                            btnSubmit.Visible=false;
                            BtnApprove.Visible=true;
                            btnReject.Visible=true;
                            btnSave.Visible = true;
                        //    BtnCFR.Attributes.Add("onclick", "funcShowPopup('RaiseCFR');return false;");
                           #region photo shuffle start added by rachana on 01-07-2013
                           GetCandidateDtls();
                           FillDataQC(Request.QueryString["CndNo"].ToString().Trim());
                      
                            dsResult.Clear();
                            htParam.Clear();
                            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
                            //if (dsResult.Tables.Count > 0)
                            //{
                            //    if (dsResult.Tables[0].Rows.Count > 0)
                            //    {
                            //        ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                            //        ViewState["DocNo"] = dsResult.Tables[0].Rows[0]["DocCode"].ToString(); //added by pranjali on 21-05-2014 for getting doccode in raise cfr
                            //        hdnDocCode.Value = ViewState["DocNo"].ToString();//added by pranjali on 21-05-2014
                            //        ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            //    }

                            //}
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                                ViewState["docCode"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                            }
                            #endregion
                            BtnCFR.Visible = true;
                            BtnApprove.Attributes.Add("onClick", "Javascript: return funvalidateApprove();");
                           
                            BindGrid();
                            btnprev.Enabled = false;
                            //Added by rachana on 02-01-2014 for confirmation of approval start
                            tblCFRInbox.Visible = false;
                            divCFRInbox.Attributes.Add("Style", "display:none");
                            tblCFRInboxCollapse.Visible = false; 
                            btnCloseCfr.Visible = false;//Added by rachana on 1302014 to collapse CFR Dtls

                            Hashtable httable = new Hashtable();
                            DataSet dscandtype = new DataSet();
                            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                            dscandtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
                            strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();

                            divnavigate.Visible = true;
                            tblphoto.Visible = true;
                            imgCrop.ImageUrl = strimgage;
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                lblpanelheader.Text = ViewState["docType"].ToString();
                                hdnDocId.Value = ViewState["docCode"].ToString();//01
                            }
                           // divAgnPhotoTrnExmDtl.Visible = true;  //comemded by usha for bootstrap   
                                    //BtnApprove.Visible = true;
                                    //btnSave.Visible = false;
                                    //btnReject.Visible = false;
                            }
                        #endregion
                    }
          //  btnSubmit.Visible = true;
            btnPrev1.Visible = false;
            btnClear.Visible = true;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "") Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            lblTitle1.Text = olng.GetItemDesc("lblTitle");
            //Comment by pallavi
            //  lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            //lblCscCode.Text = olng.GetItemDesc("lblCscCode");
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            
            lblCnddtls.Text = olng.GetItemDesc("lblCnddtls");//Added by shreela on 10/03/14
            lblcndupload.Text = olng.GetItemDesc("lblcndupload");//Added by shreela on 11/03/14
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
            Label lblAddnlRemark = (Label)row.FindControl("lblAddnlRemark");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "FuncReOpen('" + lblRemarkidValue.Text + "','" + lblAddnlRemark.Text + "');", true);
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
            }

            lblMessage.Text = "CFR Closed successfully";
            lblSub.Text = "CFR Closed successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
           // mdlpopupSub.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
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

    //Added by pranjali on 03-03-2014 start
    
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
    protected void btnCFR_Click(object sender, EventArgs e)
    {
        lblSuccessMsg.Visible = true;//added by rachana 27052013
        // BtnCFR.Attributes.Add("onclick", "funcShowPopup('RaiseCFR');return false;");


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

            if ((Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" || Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond") && (Request.QueryString["Type"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "QcRes") && ViewState["RenewalFlag"].ToString() == "" && ViewState["ReExamFlag"].ToString() == "")
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
    //Added by pranjali on 03-03-2014 end
    protected void lblCndView_Click(object sender, EventArgs e)
    {
        
       
            string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        
        }
     protected void btnupddoc(object sender, EventArgs e)
    {
        if (txtdoa.Text == "" || txtdos.Text == "" || radioReason.SelectedValue == "")
        {
            if (txtdoa.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Date of Acceptance')", true);
                return;
            }

            if (txtdos.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Date of Submission')", true);
                return;
            }
            if (radioReason.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the type of reason')", true);
                return;
            }
            else
            {
                if (txtreasonleave.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason of leaving')", true);
                    return;
                }
            }

        }

        else
        {
            htParam.Add("@DateAppoinment", txtdoa.Text);

            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NOCAppointmentDateVal", htParam);

            if (txtdoa.Text != "")
            {
                //htParam.Clear();
                //dsResult = null;
                // htParam.Add("@ICDate", txtIC.Text);
                //  dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_CheckICDateVal", htParam);
                if (dsResult != null)
                {
                    if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                    {
                        string strIsValid = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();
                        string strIsValid1 = dsResult.Tables[0].Rows[0]["Flag1"].ToString().Trim();
                        if (strIsValid == "Invalid")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot select future date in Date Of Acceptance')", true);
                            return;
                        }
                        else
                        {
                            if (strIsValid1 == "Invalid")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Three days backdating are allowed in Date Of Acceptance')", true);
                                return;
                            }
                            else
                            {
                                tblupload.Visible = true;
                                radioReason.Enabled = true;
                                txtreasonleave.Enabled = true;
                                txtdos.Enabled = false;
                                txtdoa.Enabled = false;
                                btnSubmit.Visible = true;
                                btnClear.Visible = true;
                                dgView.Visible = true;
                                Bindgridview();
                            }

                        }
                    }
                }
            }
        }

    }
    #region Button 'Clear Click Event'
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Changed and added new code to close window start
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Qc" || Request.QueryString["Type"].ToString().Trim() == "Qc")
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        
        else
        {
            string URL= "BrnAdvTrn50HrsSearch.aspx?ModuleId=" + Request.QueryString["ModuleID"].ToString().Trim() + "&Pg=50hrs&Status=NOC&Code=Spon&AgtType=IS";
            Response.Redirect(URL);
            // +"&AgtType=" + Request.QueryString["AgtType"].ToString().Trim()
            //        Response.Redirect("AdvTrn50HrsSearch?ModuleID=" + ModuleID + "&AgtType=" + Request.QueryString["AgtType"].ToString().Trim()+ "&Pg=50hrs&Code=Spon");

        }
        //Changed and added new code to close window end
    }
    #endregion

             private void FillData(string strCndNo)
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        htDtls.Add("@UserID", Session["UserID"].ToString().Trim()); //added by ajay 12.07.2022 VAPT
        //htDtls.Add("@Flag", "1");
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCCandidateDetails", htDtls);
        lblAppNoValue.Text = dsDtls.Tables[0].Rows[0]["AppNo"].ToString();
        lblAdvNameValue.Text = dsDtls.Tables[0].Rows[0]["Givenname"].ToString();
        lblCndNoValue.Text = dsDtls.Tables[0].Rows[0]["CndNo"].ToString();
        lblmobile.Text = dsDtls.Tables[0].Rows[0]["MobileTel"].ToString();
        lblpanno.Text = dsDtls.Tables[0].Rows[0]["PAN"].ToString();
        lblagencycodeValue.Text = dsDtls.Tables[0].Rows[0]["Agent_Broker_Code"].ToString();
        lbldateissuevalue.Text = dsDtls.Tables[0].Rows[0]["DateIssue"].ToString();
        txtdos.Text = dsDtls.Tables[0].Rows[0]["Date"].ToString();
        lblDate1.Text = dsDtls.Tables[0].Rows[0]["Date1"].ToString();
    }
    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblupdSize = (Label)e.Row.FindControl("lblupdSize");
            Label lblManDoc = (Label)e.Row.FindControl("lblManDoc");
            LinkButton btn_Upload = (LinkButton)e.Row.FindControl("btn_Upload");
            LinkButton btn_ReUpload = (LinkButton)e.Row.FindControl("btn_ReUpload");
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
                Label lbldocName = (Label)e.Row.FindControl("lblManDoc");
                Label MandocName = (Label)e.Row.FindControl("MandocName");
                lbldocName.Visible = true;
                MandocName.ForeColor = System.Drawing.Color.Red;
                MandocName.Visible = true;
            }

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
            //if (radioReason.SelectedValue == "3")
            //{
            //    htparam.Add("@Flag", "1");
            //}
            //else 
                if (radioReason.SelectedValue == "2")
            {
                htparam.Add("@Flag", "2");
            }
            else
            {
            }
           
            DataSet dsUpldImg = new DataSet();
            dsUpldImg = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCUpldDocCode", htparam);
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
  
    protected DataTable GetDataTableForUplds()
    {
        DataSet dsUpdDocPgIndxng = new DataSet();
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            DataSet ds_candtype = new DataSet();
            Hashtable httable1 = new Hashtable();
            httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); 
            Hashtable htparam = new Hashtable();
            htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htparam.Add("@CandType", Convert.ToString(ds_candtype.Tables[0].Rows[0]["CandType"]).Trim());
            htparam.Add("@ModuleCode", Code.Trim()); //added by pranjali on 15042014
            htparam.Add("@TypeofDoc", "UPLD");//added by pranjali on 15042014
            //if (radioReason.SelectedValue == "3")
            //{
            //    htparam.Add("@Flag", "1");
            //}
            //else 
                if (radioReason.SelectedValue == "2")
            {
                htparam.Add("@Flag", "2");
            }
            else
            { 
            }
            dsUpdDocPgIndxng = dataAccessRecruit.GetDataSetForPrcRecruit("[Prc_GetNOCDocNames]", htparam); //added by pranjali on 11-04-2014 

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
   

    protected DataTable GetDataTableForReUplds()
    {
        try
        {

            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            
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
            //if (radioReason.SelectedValue == "3")
            //{
            //    htparam.Add("@Flag", "1");
            //}
            //else 
                if (radioReason.SelectedValue == "2")
            {
                htparam.Add("@Flag", "2");
            }
            else
            {
            }
            //added by pranjali on 11-04-2014 end
            //ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam);//commented by pranjali on 11-04-2014 
            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCDocNames", htparam); //added by pranjali on 19-05-2014
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
    protected void radioReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioReason.SelectedValue == "1" || radioReason.SelectedValue == "2" )
        {
           
            if (radioReason.SelectedValue == "1")
            {
        //    added by usha 
               trNote.Visible = true;
                trupload.Visible = false;
                tblupload.Visible = false;
                tdreasontext.Visible = true;
                lblreasontext.Visible = true;
                trdgview.Visible = false;
                txtreasonleave.Visible = true;
                dgView.Visible = false;
                trunder.Visible = false;
                //tbltrn.visible = true;

               radioConfrm.SelectedIndex = -1;
                //mdlconfirm.Show();
                //ended by usha
               
            }
            else if(radioReason.SelectedValue == "2")
            {
                trNote.Visible = false;
                trupload.Visible = true;
                tblupload.Visible = true;
                tdreasontext.Visible = true;
                lblreasontext.Visible = true;
                //trdgview.Visible = true;
                txtreasonleave.Visible = true;
                dgView.Visible = true;
                trunder.Visible = false;
                Bindgridview();
                txtreasonleave.Text = "";
            }
        }
        else
        {
            tblupload.Visible = false;
            tdreasontext.Visible = false;
            lblreasontext.Visible = false;
            txtreasonleave.Visible = false;
            dgView.Visible = false;
           
        }
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
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            //Added by pranjali on 27-12-2013 start
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
            Label lbldocname = (Label)row.FindControl("lbldocName");
            Label lblimgsize = (Label)row.FindControl("lblimgsize");
            Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
            Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
            Label lblimgheight = (Label)row.FindControl("lblimgheight");
            Label lbldoccode = (Label)row.FindControl("lbldoccode");
            LinkButton btnreupd = (LinkButton)row.FindControl("btn_ReUpload");
            LinkButton btn_Upload = (LinkButton)row.FindControl("btn_Upload");
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
            } // added by pallavi on 28022023
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
            else if (strPhotoExt == "PDF")
            {
                strFileName1 = lblCndNoValue.Text.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }// added by pallavi on 28022023
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
            htdata.Add("@FileType", strPhotoExt);
            try
            {
                
                    //if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
                    //{
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
                   // }


                  
                
              
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
            lnkPreview.Visible = true;
            //Filluploadedfile();//Docname
            btnPrev1.Visible = true;
            //Added by pallavi 25012023
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
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
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
        LinkButton btnreupd = (LinkButton)row.FindControl("btn_ReUpload");
        LinkButton btn_Upload = (LinkButton)row.FindControl("btn_Upload");
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
            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select "+lbldocName.Text+" File for ReUpload');</script>");
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
                    string strnewpath = strFileRePath + "\\" + ImageNamenew + "_R" + DocStatusCount +"." + strPhotoExt;
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
        htdata.Add("@CndNo", lblCndNoValue.Text.Trim());
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
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "N")
            {
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
            }

         
            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {
                //intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload", htdata);
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);
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

       protected void btnokSub_Click(object sender, EventArgs e)
       {
           if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
           {
               Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NOC&Code=Spon");
           }
       }
      // added by usha 
       //protected void btnyes_click(object sender, EventArgs e)
       protected void radioConfrm_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (radioConfrm.SelectedValue == "3")
           {
               trupload.Visible = true;
               tblupload.Visible = true;
               tdreasontext.Visible = true;
               //lblreasontext.Visible = true;
              // trdgview.Visible = true; // changes by pallavi
               txtreasonleave.Visible = true;
               dgView.Visible = true;
               trunder.Visible = true;
               txtreasonleave.Text = "";
            
               //radioConfrm.SelectedIndex = -1;
               Bindgridview();
           }
           else if (radioConfrm.SelectedValue == "4")
           // protected void btnno_click(object sender, EventArgs e)
           {
               trNote.Visible = false;
               trupload.Visible = false;
               tblupload.Visible = false;
               tdreasontext.Visible = false;
               //lblreasontext.Visible = true;
               trdgview.Visible = false;
               txtreasonleave.Visible = false;
               dgView.Visible = false;
               trunder.Visible = false;
               radioReason.SelectedIndex = -1;
               radioConfrm.SelectedIndex = -1;
               //btnSubmit.Visible = false;
               //Bindgridview();
           }
       }
      // ended by usha 
       
    #region btnSubmit_Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        


        try
        {
            

            //if (Convert.ToDateTime(lbldateissuevalue.Text) > Convert.ToDateTime(txtdos.Text))
            //{
            //    ProgressBarModalPopupExtender.Hide();
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Date of Submission should be greater than Date of Issue of Appointment')", true);
            //    return;
            //}
            if (radioReason.SelectedValue == "")
            {
               // ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select the Reason for NOC')", true);
                //ProgressBarModalPopupExtender.Hide();
                radioReason.Focus();
                return;
            }
            else{
           // added by usha
                if (radioReason.SelectedValue == "1" && radioConfrm.SelectedValue == "")
                {
                    // ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select the Confirmation')", true);
                    //ProgressBarModalPopupExtender.Hide();
                    radioReason.Focus();
                    return;
                }

                else{ 
                    if (txtreasonleave.Text == "")
                {
                    // ProgressBarModalPopupExtender.Hide();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the Reason for NOC')", true);
                   // ProgressBarModalPopupExtender.Hide();
                    txtreasonleave.Focus();
                    return;
                }

                //if (txtdoa.Text != "")
                //{
                    
                //    if (Convert.ToDateTime(lblDate.Text) < Convert.ToDateTime(txtdoa.Text))
                //            {
                                
                //                ProgressBarModalPopupExtender.Hide();
                //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot select future date in Date of Acceptance of Resignation')", true);
                               
                //                return;
                //            }
                //            //else
                           // {
                                //if (Convert.ToDateTime(txtdoa.Text) < Convert.ToDateTime(lblDate1.Text))
                                
                                //{
                                //    ProgressBarModalPopupExtender.Hide();
                                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Three days backdating are allowed in Date of Acceptance of Resignation')", true);

                                //    return;
                                //}

                                else
                                {
                                    tblupload.Visible = true;
                                    radioReason.Enabled = true;
                                    txtreasonleave.Enabled = true;
                                    txtdos.Enabled = false;
                                    txtdoa.Enabled = false;
                                    btnSubmit.Visible = true;
                                    btnClear.Visible = true;
                                    dgView.Visible = true;
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
                                    //if (radioReason.SelectedValue == "3")
                                    //{
                                    //    htparam.Add("@Flag", "1");
                                    //}
                                    //else 
                                    if (radioReason.SelectedValue == "2")
                                    {
                                        htparam.Add("@Flag", "2");
                                    }
                                    else
                                    {
                                    }
                                    //added by pranjali on 11-04-2014 end
                                    //ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetDocNames", htparam);//commented by pranjali on 11-04-2014 
                                    ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNOCDocNamesChk", htparam); //added by pranjali on 19-05-2014
                                    //added by pranjali on 14-03-2014 start



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
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " '); ", true);
                                                    btnNextPannel1_Click(null,null);
                                                    return;
                                                }
                                            }
                                        }
                                    }


                                    for (int j = 0; j < ds_documentName.Tables[0].Rows.Count; j++)
                                    {
                                        string mandtry = ds_documentName.Tables[0].Rows[j]["IsMandatory"].ToString().Trim();
                                        string imgshrt = ds_documentName.Tables[0].Rows[j]["ImgDesc01"].ToString().Trim();

                                        //int imgshrtcode = Convert.ToInt32(imgshrt);
                                        if (mandtry == "C" && imgshrt == "Declaration cum affidavit(NOC)")
                                        {
                                            int p;
                                            for (p = 0; p < ds_documentName.Tables[0].Rows.Count; p++)
                                            {
                                                string mandtry1 = ds_documentName.Tables[0].Rows[p]["IsMandatory"].ToString().Trim();
                                                string imgshrt1 = ds_documentName.Tables[0].Rows[p]["ImgDesc01"].ToString().Trim();
                                                if (imgshrt1 == "Appointment Letter")
                                                {
                                                    //appointment = "1";
                                                    string ImgDesc = ds_documentName.Tables[0].Rows[p]["ImgDesc01"].ToString().Trim();
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);

                                                    return;
                                                }
                                                if (imgshrt1 == "ID Card")
                                                {
                                                    //license = "1";
                                                    string ImgDesc = ds_documentName.Tables[0].Rows[p]["ImgDesc01"].ToString().Trim();
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);

                                                    return;
                                                }
                                            }
                                        }
                                    }
                                  }
                                 }
                              }
                                     Save();

            btnSubmit.Visible = false;
            btnPrev1.Visible = false;
            btnNextPannel1.Visible = false;


            // mdlpopup.Show();
            //pnl.Visible = true;




        }
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
    #region Save()
    private void Save()
    {
        try
        {
          
              Hashtable htParam1 = new Hashtable();
                        DataSet dsIns= new DataSet();



                        htParam1.Add("@CndNo", lblCndNoValue.Text);
                           
                            htParam1.Add("@CreateBy", Session["UserID"].ToString().Trim());
                            htParam1.Add("@AppNo", lblAppNoValue.Text);
                            if (radioReason.SelectedValue == "1")
                            {
                                htParam1.Add("@LeaveType", "Surrender/Resignation");
                            }
                            else if (radioReason.SelectedValue == "2")
                            {
                                htParam1.Add("@LeaveType", "Death");
                            }
                            //else 
                            //{
                            //    htParam1.Add("@LeaveType", "Cancellation");
                            //}
                            htParam1.Add("@RemarksForLeave", txtreasonleave.Text);
                            htParam1.Add("@RemarkforInsurer", txtInsurer.Text);
                            htParam1.Add("@IssueDate", lbldateissuevalue.Text);
                            htParam1.Add("@submitdate", txtdos.Text);
                            htParam1.Add("@Acceptdate", txtdoa.Text);
            htParam1.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
            htParam1.Add("@UserType", Request.QueryString["Type"].ToString().Trim()); 
            dsIns = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCDtls", htParam1);

            //lblMessage.Text = "NOC Submitted Successfully";
            //lblSub.Text = "NOC Submitted Successfully<br/><br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;
            //   // mdlpopupSub.Show();
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);

            //string mess = "Candidate registration done successfully.";
            //lbl3.Text = mess + "</br><br/>Candidate Name: " + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/>Candidate No: " + Cndno + "<br/>Application No: " + txtapplicationno.Text +
            //     "<br/><br/>Note :- Please proceed to sponsorship request after candidate registration";


            string HTML = "NOC Submitted Successfully<br/>" + "Candidate Name: " + lblAdvNameValue.Text + "<br/>Application No:" + lblAppNoValue.Text + "<br/>Candidate No: " + lblCndNoValue.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup('" + HTML + "');", true);


                radioReason.Enabled = false;
                txtreasonleave.Enabled = false;
                txtdoa.Enabled = false;
                txtdos.Enabled = false;
                txtInsurer.Enabled = false;
                tdPop.Attributes.Add("style", "display:none");
                //lblMessage.Visible = true;
                btnSubmit.Enabled = false;
                radioConfrm.Enabled = false;
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
            GridImage.DataSource = ds_image;
            GridImage.DataBind();
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
    private void FillDataQC(string strCndNo)
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
        radioReason.Text = dsDtls.Tables[0].Rows[0]["Leave_Type"].ToString();
        txtdoa.Text = dsDtls.Tables[0].Rows[0]["AcceptDate"].ToString();
        txtdos.Text = dsDtls.Tables[0].Rows[0]["submitDate"].ToString();
        txtInsurer.Text = dsDtls.Tables[0].Rows[0]["RemarkforInsurer"].ToString();
        txtreasonleave.Text = dsDtls.Tables[0].Rows[0]["RemarksForLeave"].ToString();
    }


    protected void btnPrev1_Click(object sender, EventArgs e)
    {
        divSrvcReqReport.Attributes.Add("Style", "display:block");
        //divNOCdetails.Attributes.Add("Style", "display:none");
        divNocrsn.Attributes.Add("Style", "display:block");
        trdgview.Visible = false;
        btnPrev1.Visible = false;
        btnNextPannel1.Visible = true;
        btnSubmit.Visible = false;
        divPDH.Attributes.Add("style", "color:#00cccc !important;");
        divCDH.Attributes.Add("style", "color:#8c8c8c !important;");
        span5.Attributes.Add("style", "background-color: #00cccc !important");
        span9.Attributes.Add("style", "background-color: #8c8c8c !important");
        //divCDH.Attributes.Add("style", "color:#00cccc !important;");
        //span5.Attributes.Add("style", "background-color: #8c8c8c  !important");
        //span9.Attributes.Add("style", "background-color: #00cccc !important");
    }
    protected void btnNextPannel1_Click(object sender, EventArgs e)
    {
        if (radioReason.SelectedValue == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the reason for NOC')", true);
            txtreasonleave.Focus();
            return;
        }

        if (radioReason.SelectedValue == "1" || radioReason.SelectedValue == "2")
        {
            if (txtreasonleave.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter remark of reason for NOC')", true);
                txtreasonleave.Focus();
                return;
            }

        }


        if (radioReason.SelectedValue == "1" && radioConfrm.SelectedValue == "")
            {
                // ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select the Confirmation')", true);
                //ProgressBarModalPopupExtender.Hide();
                radioReason.Focus();
                return;
            }

            else
            {
                lblTitle1.Visible = false;
                trdgview.Visible = true;
                divSrvcReqReport.Attributes.Add("Style", "display:none");
                //divNOCdetails.Attributes.Add("Style", "display:none");
                divNocrsn.Attributes.Add("Style", "display:none");
                btnPrev1.Visible = true;
                btnNextPannel1.Visible = false;
                trNote.Visible = false;
                btnSubmit.Visible = true;
                btnClear.Visible = true;

                divCDH.Attributes.Add("style", "color:#00cccc !important;");
                divPDH.Attributes.Add("style", "color:#8c8c8c !important;");
                span5.Attributes.Add("style", "background-color: #8c8c8c  !important");
                span9.Attributes.Add("style", "background-color: #00cccc !important");
            }
        }
    }


    //protected void btnCancel_Click(object sender, EventArgs e)
    //{

    //    if (Request.QueryString["Status"] =="NOC")
    //    {
    //        string ModuleID = string.Empty;
    //        ModuleID = Request.QueryString["ModuleID"].ToString().Trim();

    //        Response.Redirect("AdvTrn50HrsSearch?ModuleID=" + ModuleID + "&AgtType=" + Request.QueryString["AgtType"].ToString().Trim()+ "&Pg=50hrs&Code=Spon");
    //    }
  
    //}





    #endregion
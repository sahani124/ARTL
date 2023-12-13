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

public partial class Application_ISys_Recruit_CompositeApproval : BaseClass
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
    string MailTo, MailCC, MailBCC, MailSubject, MailBody;
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

                hdnUserId.Value = Session["UserID"].ToString().Trim();
                InitializeControl();
                GetCandidateDtls();
                BindataGrid();
                BindData();


                #region Ducument upload
                //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start 
                if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit" && Request.QueryString["Code"].ToString().Trim() == "CompApp")
                {
                    // btnSubmit.Visible = true;
                    //  btnClear.Visible = true;


                    lblTitle.Text = "Candidate Details";

                    hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                    Bindgridview();
                    divMail.Attributes.Add("style", "display:block;");
                    //trBtn.Visible = false;
                    // trMail.Visible = true;

                    // BindMailData();

                    //trdgview.Visible = false;


                }
                #endregion

                //Added By Nikhil
                //#region Composite Mail View section

                //if (Request.QueryString["Code"].ToString().Trim() == "CompositeMail")
                //{
                //    divMail.Attributes.Add("style","display:block;");
                //    trBtn.Visible = false;
                //    trMail.Visible = true;

                //    lblTitle.Text = "Candidate Details";
                //    BindMailData();
                //    hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
                //    trdgview.Visible = false;
                //    //trMailBody.visible=true;


                //}
                //#endregion
                //Ended




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

    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {


            lblTitle.Text = olng.GetItemDesc("lblTitle");

            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");

            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblBranch.Text = olng.GetItemDesc("lblBranch");



        }
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

    protected void lblCndView_Click(object sender, EventArgs e)
    {


        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

    }

    //Added By Nikhil
    //private void BindMailData()
    //{
    //    try
    //    {

    //        htParam.Clear();
    //        dsResult.Clear();
    //        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
    //        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMailData", htParam);
    //        lblMailToVal.Text = dsResult.Tables[0].Rows[0]["MailTo"].ToString().Trim();
    //        lblMailCCVal.Text = dsResult.Tables[0].Rows[0]["MailCC"].ToString().Trim();
    //        lblMailBCCVal.Text = dsResult.Tables[0].Rows[0]["MailBCC"].ToString().Trim();
    //        lblCndNoValue.Text = Request.QueryString["CndNo"].ToString().Trim();
    //        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
    //        lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString().Trim();
    //        lblpanno.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
    //        lblmobile.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();
    //        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString().Trim();
    //        if (!lblMailCCVal.Text.Equals(string.Empty))
    //        {
    //            trMailCC.Visible = true;
    //        }
    //        if (!lblMailBCCVal.Text.Equals(string.Empty))
    //        {
    //            trMailBCC.Visible = true;
    //        }
    //        lblSubjectVal.Text = dsResult.Tables[0].Rows[0]["MailSubject"].ToString().Trim();
    //        lblBodyVal.Text = dsResult.Tables[0].Rows[0]["MailBody"].ToString().Trim();
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
    //Ended

    //protected void btnupddoc(object sender, EventArgs e)
    //{

    //    if (txtdoa.Text == "" || txtdos.Text == "" || radioReason.SelectedValue == "")
    //    {
    //        if (txtdoa.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Date of Acceptance')", true);
    //            return;
    //        }

    //        if (txtdos.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Date of Submission')", true);
    //            return;
    //        }
    //        if (radioReason.SelectedValue == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the type of reason')", true);
    //            return;
    //        }
    //        else
    //        {
    //            if (txtreasonleave.Text == "")
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter reason of leaving')", true);
    //                return;
    //            }
    //        }

    //    }





    //    else
    //    {
    //        htParam.Add("@DateAppoinment", txtdoa.Text);

    //        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NOCAppointmentDateVal", htParam);

    //        if (txtdoa.Text != "")
    //        {
    //            //htParam.Clear();
    //            //dsResult = null;
    //            // htParam.Add("@ICDate", txtIC.Text);
    //            //  dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_CheckICDateVal", htParam);
    //            if (dsResult != null)
    //            {
    //                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
    //                {
    //                    string strIsValid = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();
    //                    string strIsValid1 = dsResult.Tables[0].Rows[0]["Flag1"].ToString().Trim();
    //                    if (strIsValid == "Invalid")
    //                    {
    //                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot select future date in Date Of Acceptance')", true);
    //                        return;
    //                    }
    //                    else
    //                    {
    //                        if (strIsValid1 == "Invalid")
    //                        {
    //                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Three days backdating are allowed in Date Of Acceptance')", true);
    //                            return;
    //                        }
    //                        else
    //                        {
    //                            tblupload.Visible = true;
    //                            radioReason.Enabled = true;
    //                            txtreasonleave.Enabled = true;
    //                            txtdos.Enabled = false;
    //                            txtdoa.Enabled = false;
    //                            btnSubmit.Visible = true;
    //                            btnClear.Visible = true;
    //                            dgView.Visible = true;
    //                            Bindgridview();
    //                        }

    //                    }
    //                }
    //            }
    //        }
    //    }

    //}
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
            if (Request.QueryString["Code"].ToString().Trim() != null)
            {
                if (Request.QueryString["Code"].ToString().Trim() == "CompApp")
                {
                    //Response.Redirect("ViewInsuranceCompany.aspx?Pg=Request&Status=CompDoc&Code=Spon&type=CompositeMail");
                    Response.Redirect("ViewInsuranceCompany.aspx?Pg=Request&Code=CompApp&type=CompApp");
                }
            }
            else
            {
                Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NOC&Code=Spon");
            }
        }
        //Changed and added new code to close window end
    }
    #endregion


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
                e.Row.BackColor = Color.LightPink;

            }


            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());

            htParam.Add("@CandType", ViewState["CandType"]);
            htParam.Add("@ProcessType", ViewState["ProcessType"]);
            htParam.Add("@ModuleCode", "Spon");
            htParam.Add("@TypeofDoc", "UPLD");//
            htParam.Add("@Flag", "1");

            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompMailDocNames", htParam);

            htParam.Add("@doccode", lbldoccode.Text);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (lbldoccode.Text == dsResult.Tables[0].Rows[i]["DocCode"].ToString().Trim())
                    {
                        btn_Upload.Enabled = true;
                        btn_ReUpload.Enabled = false;
                        btn_Upload.Visible = true;
                        btn_ReUpload.Visible = false;
                        lnkPreview.Visible = false;
                    }
                }
            }

            //Hashtable htflag = new Hashtable();
            //DataSet dsflag = new DataSet();

            //htflag.Add("@CndNo", lblCndNoValue.Text.Trim());

            //htflag.Add("@DocCode", lbldoccode.Text.Trim());

            //htflag.Add("@processtype", ViewState["ProcessType"]);
            //htflag.Add("@flag", "2");

            //dsflag = dataAccessRecruit.GetDataSetForPrcRecruit("Proc_InsertDCTMFileUploadFlag", htflag);
            //if (dsflag.Tables[0].Rows.Count > 0)
            //{
            //    for (int i = 0; i < dsflag.Tables[0].Rows.Count; i++)
            //    {
            //        if (dsflag.Tables[0].Rows[i]["flag"].ToString().Trim() == "F")
            //        {
            //            //  chk.Checked = true;
            //        }
            //    }
            //}

            //11.02.2016 for check box check for document upload ended  by usha 


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
                    //tblupload.Visible = false;

                }
            }
            else
            {
                dgView.DataSource = null;
                dgView.DataBind();
                //tblupload.Visible = false;

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



    private void Bindgridview()
    {


        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            //DataSet ds_candtype = new DataSet();
            //Hashtable httable1 = new Hashtable();
            //httable1.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            //ds_candtype = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandType", httable1); //added by pranjali on 14-03-2014 start
            //Hashtable htparam = new Hashtable();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@CandType", ViewState["CandType"]);
            htParam.Add("@ProcessType", ViewState["ProcessType"]);
            htParam.Add("@ModuleCode", "Spon");
            htParam.Add("@TypeofDoc", "UPLD");


            ds_documentName = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompMailDocNames", htParam);


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
        //Added by pranjali to fill File upload grid end
    }





    private void GetCandidateDtls()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());

        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString().Trim();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim();


    }
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {

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
            //pranj
            if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
            {

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
                        using (Stream fs = fuData.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                data = br.ReadBytes((Int32)fs.Length);
                            }
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
            htdata.Add("@DocStatus", "0");
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode.Text.Trim());
            htdata.Add("@FileType", strPhotoExt);
            try
            {


                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);






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

        //pranj
        if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
        {

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
                    using (Stream fs = fuData.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            data = br.ReadBytes((Int32)fs.Length);
                        }
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
                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
            }


            if (Request.QueryString["Type"].ToString().Trim().ToUpper() == "E")
            {

                intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUpload1", htdata);
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

    }


    protected void btnokSub_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["TrnRequest"].ToString().Trim() == "Submit")
        {
            Response.Redirect("AdvTrn50HrsSearch.aspx?Pg=50hrs&Status=NOC&Code=Spon");
        }
    }

    #region btnSend_Click
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@AppNo", lblAppNoValue.Text.Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsMailForComposite", htParam);
            string Flag = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();
            if (Flag.Equals("1"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Send to Mail are already pending.')", true);
                return;
            }
            else
            {
                btnSend.Enabled = false;
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

    #region btnSubmit_Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {



        try
        {


            btnSubmit.Visible = true;
            // btnClear.Visible = true;
            dgView.Visible = true;
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());

            htParam.Add("@CandType", ViewState["CandType"]);
            htParam.Add("@ProcessType", ViewState["ProcessType"]);
            htParam.Add("@ModuleCode", "Spon");
            htParam.Add("@TypeofDoc", "UPLD");//
            htParam.Add("@Flag", "2");

            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompMailDocNames", htParam);


            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    int i;
                    for (i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                    {
                        string mandtry = dsResult.Tables[0].Rows[i]["IsMandatory"].ToString().Trim();

                        if (mandtry == "Y")
                        {
                            string ImgDesc = dsResult.Tables[0].Rows[i]["ImgDesc01"].ToString().Trim();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                            return;
                        }
                    }
                }
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
    #region Save()
    private void Save()
    {
        try
        {

            htParam.Clear();
            htParam.Add("@CndNo", lblCndNoValue.Text);

            htParam.Add("@CreateBy", Session["UserID"].ToString().Trim());
            htParam.Add("@AppNo", lblAppNoValue.Text);
            htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());//Added by usha on 29.06.2021
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCompMailDtls", htParam);

            lblMessage.Text = "Document Submitted Successfully";
            lblMessage.Visible = true;
            tdPop.Attributes.Add("style", "display:none");
            //trmsg.Visible = true;
            lblMessage.Text = "Document Submitted Successfully";
            lblSub.Text = "Composite candidate approved successfully" + "<br/><br/>Candidate Code: " + lblCndNoValue.Text + "<br/>Application No: " + lblAppNoValue.Text + "<br/>Candidate Name: " + lblAdvNameValue.Text;//added by shreela on 25042014
            pnlSub.Visible = true;
            mdlpopupSub.Show();

            btnSubmit.Enabled = false;


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


    public void BindataGrid()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMailDetails", htDtls);
        gvMail.DataSource = dsDtls.Tables[0];
        gvMail.DataBind();
    }

    private void BindData()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompositeCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        lblAppNoValue.Text = dsDtls.Tables[0].Rows[0]["AppNo"].ToString();
        lblAdvNameValue.Text = dsDtls.Tables[0].Rows[0]["Givenname"].ToString();
        lblCndNoValue.Text = dsDtls.Tables[0].Rows[0]["CndNo"].ToString();
        lblmobile.Text = dsDtls.Tables[0].Rows[0]["MobileTel"].ToString();
        lblpanno.Text = dsDtls.Tables[0].Rows[0]["PAN"].ToString();
        lblSMNameValue.Text = dsDtls.Tables[0].Rows[0]["RecruitAgtName"].ToString().Trim();
        lblBranchValue.Text = dsDtls.Tables[0].Rows[0]["branch"].ToString().Trim();
    }

    private void FillDataComp(string InsId, string MailRefNo)
    {
        try
        {
            Hashtable htDtls = new Hashtable();
            DataSet dsDtls = new DataSet();
            htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htDtls.Add("@InsId", InsId);
            htDtls.Add("@MailRefNo", MailRefNo);
            dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompositeCandidateDetails", htDtls);
            lblMailToVal.Text = dsDtls.Tables[0].Rows[0]["MailTo"].ToString().Trim();
            lblMailCCVal.Text = dsDtls.Tables[0].Rows[0]["MailCC"].ToString().Trim();
            lblMailBCCVal.Text = dsDtls.Tables[0].Rows[0]["MailBCC"].ToString().Trim();

            if (!lblMailCCVal.Text.Equals(string.Empty))
            {
                trMailCC.Visible = true;
            }
            if (!lblMailBCCVal.Text.Equals(string.Empty))
            {
                trMailBCC.Visible = true;
            }
            lblSubjectVal.Text = dsDtls.Tables[0].Rows[0]["MailSubject"].ToString().Trim();
            //lblBodyVal.Text = dsDtls.Tables[0].Rows[0]["MailBody"].ToString().Trim();
            diviframeContent.InnerHtml = diviframeContent.InnerHtml + dsDtls.Tables[0].Rows[0]["MailBody"].ToString().Trim() + "</br><hr>";

        }


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




    protected void gvMail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Document")
            {
                string CndNo = Request.QueryString["CndNo"].ToString().Trim();
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string[] arguments = e.CommandArgument.ToString().Split(',');
                string Doccode = arguments[0];
                string DocType = arguments[1];


                string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + Doccode + "&CndNo=" + CndNo.Trim() + "&docName=" + DocType + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&CndNo=" + CndNo.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview');", true);
            }
            else if (e.CommandName == "Email")
            {
                diviframeContent.InnerHtml = string.Empty;
                lblMailToVal.Text = string.Empty;
                lblSubjectVal.Text = string.Empty;
                lblMailCCVal.Text = string.Empty;
                lblMailBCCVal.Text = string.Empty;
                string[] arguments = e.CommandArgument.ToString().Split(',');
                string MailRefNo = arguments[0];
                string InsId = arguments[1];
                mdlpopup.Show();

                FillDataComp(InsId, MailRefNo);

                pnl.Visible = true;
                // pnlSub.Visible = false;

            }
            else if (e.CommandName == "ReSend")
            {
                string[] arguments = e.CommandArgument.ToString().Split(',');
                string MailRefNo = arguments[0];
                string InsId = arguments[1];
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@AppNo", lblAppNoValue.Text.Trim());
                htParam.Add("@InsId", InsId);
                htParam.Add("@MailRefNo", MailRefNo);
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsMailForComposite", htParam);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mail Sent Successfully.')", true);
                BindataGrid();
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


    protected void gvMail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblMailStatus = (Label)e.Row.FindControl("lblMailStatus");
                Button btnResend = (Button)e.Row.FindControl("lnkResendmail");
                if (lblMailStatus.Text == "Pending")
                {
                    btnResend.Enabled = false;
                }
                else
                {
                    btnResend.Enabled = true;
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
    }

    protected void gvMail_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

}
    #endregion
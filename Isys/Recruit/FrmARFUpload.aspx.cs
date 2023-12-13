using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Data.Odbc;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.OleDb;
using CLTMGR;
using DataAccessClassDAL;
using Microsoft.VisualBasic.FileIO;
using System.Text;
//Added by rachana for fees details Webservice start
using SysInrgConsum;
using System.ServiceModel;
 using Microsoft.Reporting.WebForms;
   
//Added by rachana for fees details Webservice end

public partial class Application_INSC_Recruit_FrmARFUpload : BaseClass
{
    #region "Declare Variable"
  //  CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    GSTCalculation objCredit = new GSTCalculation(); 
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private string destDir = string.Empty;
    private string fileName = string.Empty;
    private string destPath = string.Empty;
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    Hashtable htFlag = new Hashtable();
    DataSet dsResult = new DataSet();
    DataSet dsTable = new DataSet();
    DataSet dsLogEntry = new DataSet();
    DataSet dsUpload = new DataSet();
    DataSet dsUpldData = new DataSet();
    string strcndno;
string strAppNo;
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    IsysMailComAttach.IsysMailAttach objmailcommAttach = new IsysMailComAttach.IsysMailAttach();
    OdbcConnection dbo;
    Warning[] warnings;
    string[] streamIds;
    string mimeType = string.Empty;
    string encoding = string.Empty;
    string extension = string.Empty;
    OdbcCommand com;
    OdbcCommand comVal;
    ArrayList arrList = new ArrayList();
    OdbcDataAdapter odaResult;
    long retvalue;
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private DataAccessLayer dataAccess = new DataAccessLayer();
    DataSet dserror = new DataSet();
    string batchid = string.Empty;
    string strHtml = string.Empty;
    string strProcessFlag = string.Empty;
    string strColumnError = string.Empty;
    string strError = string.Empty;
    string strTblName = string.Empty;
    string strUploadFile = string.Empty;
    string strColError = string.Empty;
    string strValue = string.Empty;
    string strCheck = string.Empty;
    DataSet dsMastrColm = new DataSet();
    DataSet dsTempColm = new DataSet();
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    string strRpt = System.Configuration.ConfigurationManager.AppSettings["Report"].ToString();
   
    //added by rachana for sysfreezedate start 
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    string strcallerSystem = System.Configuration.ConfigurationManager.AppSettings["CallerSystem"].ToString();
    string strCSv = string.Empty;
    string strSize = string.Empty;
    //added by rachana for sysfreezedate end
    StringBuilder sbSMAppNo = new StringBuilder();
    StringBuilder sbSMIRDAError = new StringBuilder();
    StringBuilder sbLicAppno = new StringBuilder();
    StringBuilder sbLicIRDAError = new StringBuilder();
    string strNo;
    string strSMAppNo;
    string strSMAppNoDesc;
    string strIRDAErr;
    string strIRDAErrDesc;
    string strLicAppno;
    string strlicIRADErrr;
    DataTable dtCurrentTable;

    String  ModuleID = string.Empty;//Added by usha on 25.06.2021

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
          
            if (!IsPostBack)
            {
             
                hdnModuleID.Value = Request.QueryString["ModuleID"].ToString().Trim();
                btnUpldFrmt.Enabled = false;
                //btnUpldFrmt.Enabled = false;
                InitializeControl();
                PopulateCasteCat();
                btn_Process.Enabled = false;
                btn_Validate.Enabled = false;
            }
            btn_Upload.Attributes.Add("onclick", "javascript:return StartProgressBar1()");
            btn_Process.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            btn_Validate.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            ViewState["DocType"] = ddlUpload.SelectedItem.Text.ToString().Trim();
            btn_Upload.Enabled = true;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region InitializeControl Method
    private void InitializeControl()
    {
        lblTitle.Text = "ARF Upload";
        lblUpload.Text = "Document Type";
        lblFileUpload.Text = "Upload file";
        lbl_Error.Text = "";
    }
    #endregion

    #region PopulateCasteCat 
    private void PopulateCasteCat()
    {
    //    getUploadDoc(ddlUpload, "");
    //    ddlUpload.Items.Insert(0, "Select");
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@UserId", Session["UserID"].ToString());
        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDocName", htParam);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlUpload.DataSource = dsResult.Tables[0];
                ddlUpload.DataTextField = "DocDesc";
                ddlUpload.DataValueField = "DocType";
                ddlUpload.DataBind();
                ddlUpload.Items.Insert(0, "Select");
            }
        }
    }
    #endregion

    private void ConvertRDLCToPDF(String cndno)
    {
        try
        {

            string strAppoint = string.Empty;
            strAppoint = "AppLtr";
            string strID = string.Empty;
            strID = "ID";
            string strFileRePath = string.Empty;
            strcndno = cndno;
            strFileRePath = strPath + cndno + "\\";
            //"C:/CHMS/I-SysSuite/Application/ISys/Recruit/UploadedFiles/"  +cndno + "/";
            //"D:/Hosted Application/I-SysSuite/Application/ISys/Recruit/UploadedFiles/" + cndno;// +"/";

            Hashtable htCRP = new Hashtable();
            htCRP.Add("@CndNo", cndno);
            DataSet dsCRP = new DataSet();
            if (strAppoint == "AppLtr")
            {
                dsCRP = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAppltr", htCRP);
                ReportDataSource rdsAct = new ReportDataSource("DirectAppointment", dsCRP.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = strRpt + "DirectAppointment.rdlc"; //This is your rdlc name.
                // viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                using (FileStream fs = File.Create(strFileRePath + "AppointmentLetter.pdf")) // using (FileStream fs = new FileStream(strFileRePath + "AppointmentLetter.pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                Hashtable htApp = new Hashtable();
                DataSet dsApp = new DataSet();
                htApp.Add("@CndNo", cndno);
                htApp.Add("@UserFilename", strFileRePath);
                htApp.Add("@ServerFilename", "AppointmentLetter.pdf");
                htApp.Add("@PDFByte", bytes);
                htApp.Add("@CreateBy", Session["UserID"].ToString().Trim());
                dsApp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsConRDLCToPDF", htApp);
            }
            if (strID == "ID")
            {
                dsCRP = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAgtId", htCRP);
                ReportDataSource rdsAct = new ReportDataSource("AgentID", dsCRP.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = strRpt + "AgentID.rdlc"; //This is your rdlc name.
                // viewer.LocalReport.SetParameters(param);
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                using (FileStream fs = new FileStream(strFileRePath + "IDCard.pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                Hashtable htID = new Hashtable();
                DataSet dsID = new DataSet();
                htID.Add("@CndNo", cndno);
                htID.Add("@UserFilename", strFileRePath);
                htID.Add("@ServerFilename", "IDCard.pdf");
                htID.Add("@PDFByte", bytes);
                htID.Add("@CreateBy", Session["UserID"].ToString().Trim());
                dsID = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsConRDLCToPDF", htID);

            }
            GetRecordofAPPId();

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }
    private void GetRecordofAPPId()
    {

        Hashtable htSend = new Hashtable();
        DataSet dssend = new DataSet();
        htSend.Add("@AppNo", strAppNo);
         htSend.Add("@Flag", "1");
        dssend = dataAccessRecruit.GetDataSetForPrcDBConn("Prc_GetRCRDRDLCToPDF", htSend,"Communication");
        //ViewState["IsAttach"] = dssend.Tables[0].Rows[0]["IsAttach"].ToString();
       
        //if (ViewState["IsAttach"].ToString().Trim() == "Y")
        //{
        //   // MailAppIDRespone();
        //}
 


    }
    //Added by Nikhil
    private void GetUserSAPCode()
    {
        Hashtable htSAP = new Hashtable();
        DataSet dsSAP = new DataSet();
        htSAP.Add("@AppNo",strcndno);
        htSAP.Add("@Flag", "1");
        dsSAP = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUserSAPCode", htSAP);
        ViewState["SAP"] = dsSAP.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
        ViewState["AppNo"] = dsSAP.Tables[0].Rows[0]["AppNo"].ToString().Trim();
        ViewState["ProcessType"] = dsSAP.Tables[0].Rows[0]["ProcessType"].ToString().Trim();
        ViewState["CandType"] = dsSAP.Tables[0].Rows[0]["CandType"].ToString().Trim();
    }
    //Ended By Nikhil
    private void MailAppIDRespone()
    {

        GetUserSAPCode();
        Hashtable htAppID = new Hashtable();

        DataSet dsAppId = new DataSet();
        htAppID.Add("@Param1", "Licensed");
        htAppID.Add("@Param3", "170");
        htAppID.Add("@Param4", ViewState["ProcessType"].ToString());
        htAppID.Add("@Param2", ViewState["CandType"].ToString());
        htAppID.Add("@Param5", "");

        dsAppId = dataAccessRecruit.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htAppID);
        if (dsAppId != null)
        {
            if (dsAppId.Tables.Count > 0 && dsAppId.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAppId.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = dsAppId.Tables[0].Rows[i]["NotificationTo"].ToString();
                    objmailcommAttach.SendNoticationMail("ARTL", "Licensed", ViewState["CandType"].ToString().Trim(), "170", ViewState["ProcessType"].ToString().Trim(), "AppId", NotifyTo, ViewState["AppNo"].ToString().Trim(), ViewState["SAP"].ToString().Trim());
                }
            }
        }
    }
    #region ddlUpload_SelectedIndexChanged
    protected void ddlUpload_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlUpload.SelectedItem.Value.ToString() == "Select")
        {
            btnUpldFrmt.Enabled = false;
            //btnUpldFrmt.Enabled = false;
        }

        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
        htParam.Add("@Flag", "2");
        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDocDetails", htParam);

        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                btn_Upload.Enabled = true;
                //btn_Upload.Enabled = true;
            }
            else
            {
                //btn_Upload.CssClass="btn btn-xs btn-primary disabled";
                btn_Upload.Enabled = false;
            }
        }
        else
        {
            btn_Upload.Enabled = false;
            //btn_Upload.Enabled = false;
        }
        btnUpldFrmt.Enabled = true;
        //btnUpldFrmt.Enabled = true;
        tblErrorLog.Visible = false;
        griderror.Visible = false;
        btn_Validate.Enabled = false;
        //btn_Validate.Enabled = false;
       // btn_Process.Enabled = false;
        //btn_Cancel.Enabled = true;
        btn_Process.Enabled = false;
        btn_Cancel.Enabled = true;
        //tblIRDA.Visible = false;

        //lbl_Message.Text = "";
        //try
        //{
        //    griderror.Visible = false;
        //    tblErrorLog.Visible = false;
           
        //    lbl_Message.Visible = false;
        //    tbl_grid.Attributes.Add("Style", "visibility:visible");
        //    trViewLog.Visible = false;

        //    DataSet dsNotes = new DataSet();
        //    string ddlup = ddlUpload.SelectedValue.ToString();
        //    htParam.Clear();
        //    htParam.Add("@DocType", ddlup);
        //    //dsNotes = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetNotes", htParam);
        //    if (dsNotes.Tables.Count > 0)
        //    {
        //        if (dsNotes.Tables[0].Rows.Count > 0)
        //        {
        //            GridNotes.Visible = true;
        //            GridNotes.DataSource = dsNotes;
        //            GridNotes.DataBind();
        //        }
        //        else
        //        {
        //            GridNotes.Visible = false;
        //            tbl_grid.Attributes.Add("Style", "visibility:hidden");
        //        }
        //    }
        //    else
        //    {
        //        GridNotes.Visible = false;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //trMessage.Visible = true;
        //    //lbl_Message.Text = "";
        //    //lbl_Message.Text = ex.Message.ToString();
        //    //lbl_Message.Visible = true;
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
        //    objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //    throw (ex);
        //}
    }
    #endregion

    #region UploadConnection
    public void UploadConnection()
    {
        _SetODBCConnectionString();
    }
    #endregion

    #region button process
    protected void btn_Process_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
         try
         {
             tblErrorLog.Visible = false;
             griderror.Visible = false;
             btnFailCase.Visible = false;
             btnExport.Visible = false;
             btn_Process.Enabled = false;
             int a;

                 //MOVE TEMP DATA TO HIST TABEL 1ST TIME
                 dsResult.Clear();
                 htFlag.Clear();
                 htFlag.Add("@Flag", "1");
                 htFlag.Add("@batchid", hdnBatchid.Value.ToString());
                 htFlag.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                 dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetValidRecordUpd", htFlag);

                 if (dsResult.Tables.Count > 0)
                 {
                     if (dsResult.Tables[0].Rows.Count > 0)
                     {
                         //Get history table name
                         htParam.Clear();
                         htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                         htParam.Add("@Flag", '2');
                         strTblName = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetTempHistTbl", htParam, "@TblName");
                        //Added by Anand on 25/12/2015
                         if (dsResult.Tables.Count > 0)
                         {
                             using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                             {
                                 bulkCopy.DestinationTableName = strTblName;
                                 bulkCopy.WriteToServer(dsResult.Tables[0]);
                                 htParam.Clear();
                             }
                         }

                             htParam.Clear();
                             dsUpldData.Clear();
                             htParam.Add("@batchid", hdnBatchid.Value.ToString());
                             htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                             dsUpldData = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_UpdateUpload", htParam);
                        
                             //Assign CFR to SM
                             //if (ddlUpload.SelectedValue.ToString().Trim() == "UIRDAER")
                             //{
                             //    ViewState["IRDAError"] = dsUpldData.Tables[0];
                             //    AddErrorTable();
                             //}

                         //AFTER RELATIVE TABLE MOVE TEMP TABLE TO HIST TABLE 2ND TIME 
                             DataSet ds = new DataSet();//added by usha
                       //  dsResult.Clear();
                         htFlag.Clear();
                         htFlag.Add("@Flag", "2");
                         htFlag.Add("@batchid", hdnBatchid.Value.ToString());
                         htFlag.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                         ds = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetValidRecordUpd", htFlag);

                        

                         //Update status
                         htParam.Clear();
                    // dsResult.Clear();
                        
                         htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                         htParam.Add("@BatchID", hdnBatchid.Value.ToString());
                         htParam.Add("@CreatedBy", Session["UserID"].ToString());
                         htParam.Add("@Flag","2");
                        htParam.Add("@ModuleID", hdnModuleID.Value);
                    String strStatus = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_UpdateCndStatus", htParam, "@CndStatus");

                        
                         ///For crm update agent task on 19/12/2017 Start
                         for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                         {

                             //Added by usha  for Payment  Reconciliation
                             if (ddlUpload.SelectedValue.ToString().Trim() == "UPYMTRECNCL")
                             {
                                 Hashtable htCnd = new Hashtable();
                                 DataSet dsCnd = new DataSet();
                                 htCnd.Add("@BatchID", hdnBatchid.Value.ToString());
                                 dsCnd = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetCreditNoteCndNo", htCnd);
                                 if (dsCnd.Tables[0].Rows.Count > 0)
                                 {

                                     for (int j = 0; j < dsCnd.Tables[0].Rows.Count; j++)
                                     {
                                         strAppNo = dsCnd.Tables[0].Rows[i]["AppNo"].ToString().Trim();
                                         int TokenNo = Convert.ToInt32(dsCnd.Tables[0].Rows[i]["TokenNo"].ToString().Trim());
                                         objCredit.ConvertRDLCToPDF(strAppNo, TokenNo, "CreditNote");
                                       //  ObjTask.UpdateCndTask(strAppNo);  
                                        
                                     }

                                 }
                                 if (dsCnd.Tables[1].Rows.Count > 0) /// for licensed generation 
                                 {

                                     for (int k = 0; k < dsCnd.Tables[1].Rows.Count; k++)
                                     {
                                         strAppNo = dsCnd.Tables[1].Rows[i]["AppNo"].ToString().Trim();
                                         Hashtable htTrnsfrLic = new Hashtable();
                                           DataSet Ds = new DataSet();
                                         htTrnsfrLic.Add("@CndNo", dsCnd.Tables[1].Rows[i]["AppNo"].ToString().Trim()); 
                                         htTrnsfrLic.Add("@flag", "S"); // added by usha 
                                         htTrnsfrLic.Add("@Createdby", Session["UserID"].ToString().Trim());
                                         Ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdTrnsfrLicDtls", htTrnsfrLic);
                                          ConvertRDLCToPDF(strAppNo);
                                      //    ObjTask.UpdateCndTask(strAppNo);  //by usha


                                     }

                                 }

                             }
                             // ended  by usha 
                             else if (ddlUpload.SelectedValue.ToString().Trim() == "USAPUPD")
                             { 
                             
                             }
                             else
                             {
                                 //added by meena start on 28/12/17
                                 if ((dsResult.Tables[0].Columns.Contains("LoginID")))
                                 {

                                   //  ObjTask.UpdateCndTask("", dsResult.Tables[0].Rows[i]["LoginID"].ToString());  //by meena
                                 }
                                 else if ((!dsResult.Tables[0].Columns.Contains("IRDA URN")))
                                 {

                                    // ObjTask.UpdateCndTask("", dsResult.Tables[0].Rows[i]["CndURN"].ToString());  //by meena
                                 }

                                 else
                                 {
                                   //  ObjTask.UpdateCndTask("", dsResult.Tables[0].Rows[i]["IRDA URN"].ToString());//by meena
                                 }
                                 //end by meena 28/12/17 end
                             }
                         }
                         ///For crm update agent task on 19/12/2017 End
                          
                         if (ddlUpload.SelectedValue.ToString().Trim() == "UEXMRSLT")
                         {
                             Hashtable htCnd = new Hashtable();
                             DataSet dsCnd = new DataSet();
                             htCnd.Add("@BatchID", hdnBatchid.Value.ToString());
                             dsCnd = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetCndNo", htCnd);
                             if (dsCnd.Tables[0].Rows.Count > 0)
                             {

                                 for (int i = 0; i < dsCnd.Tables[0].Rows.Count; i++)
                                 {
				                   strAppNo=dsCnd.Tables[0].Rows[i]["AppNo"].ToString().Trim();

                                    // ConvertRDLCToPDF(dsCnd.Tables[0].Rows[i]["Cndno"].ToString().Trim());

                                 }

                             }

                         }
                         if (strStatus == "110")
                         {
                             //Call for schedular after training upload
                             if (ddlUpload.SelectedValue.ToString().Trim() == "UTRNATI")
                             {
                                 //dsResult.Clear();
                                 //dsResult = dataAccessRecruit.GetDataSetForPrc1("Prc_UpdPrefferedExmDt");
                                 //sets sysstemfreezeDate into CndExmAssign start
                                 //GetNoofDays();
                                 SetSysFreezeDate();
                                 //sets sysstemfreezeDate into CndExmAssign end
                             }
                         }

                         //htParam.Clear();
                         //htParam.Add("@CndStatus", strStatus);
                         //htParam.Add("@CreatedBy", Session["UserID"].ToString());
                         //dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_InsCndStatusMvmt", htParam);

                         //ddlUpload.Enabled = true;
                         //fileuploading.Enabled = true;
                     }
                     else
                     {
                         strProcessFlag = "1";
                     }
                 }
                 else
                 {
                     strProcessFlag = "1";
                 }

             ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>funAlertprocess('" + strProcessFlag + "')</script>");
             if (strProcessFlag == "1")
             {
                 lbl.Text = " No record processed.";
                 lbl2.Text = "";
                 ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                 //btn_Process.Enabled = false;
             }
             else
             {
                 lbl.Text = " File processed successfully.";
                 lbl2.Text="";

                 ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                // btn_Process.Enabled = true;
             }

             //Delete Temp teble record
             htParam.Clear();
             htParam.Add("@batchid", hdnBatchid.Value);
             htParam.Add("@Doctype", ddlUpload.SelectedItem.Value.ToString());
             htParam.Add("@UserId", Session["UserID"].ToString().Trim());
             a = dataAccessRecruit.execute_sprcUpdDwnld("prc_DeleteTmpTbl1", htParam);
         }
         catch (Exception ex)
         {
             string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
             System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
             string sRet = oInfo.Name;
             System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
             String LogClassName = method.ReflectedType.Name;
             objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
             //ProgressBarModalPopupExtender.Hide();

         }
    }
    #endregion

    #region SetFreezaDate
    //added by rachana on 17042014 for updating Freeze date start
    //public int GetNoofDays(string cndtype, string ReExmFlag, string TccFlag)
    //{

    //    DataSet dsetdays = new DataSet();
    //    Hashtable htdays = new Hashtable();
    //    //dsetdays = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetNoofdays");
    //    htdays.Add("@CndType", cndtype);
    //    htdays.Add("@ReExmFlag", ReExmFlag);
    //    htdays.Add("@TCCFlag", TccFlag);

    //    dsetdays = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetNoofDays", htdays);

    //    if (dsetdays.Tables.Count > 0)
    //    {
    //        if (dsetdays.Tables[0].Rows.Count > 0)
    //        {
    //            iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["NoofDays"]);
    //        }
    //    }
    //    return iNoOfDays;
    //}

    public int GetNoofDays()
    {

        DataSet dsetdays = new DataSet();
        Hashtable htdays = new Hashtable();
        dsetdays = dataAccessRecruit.GetDataSetForPrc_DIRECT("Prc_GetNoofdays");
       

        if (dsetdays.Tables.Count > 0)
        {
            if (dsetdays.Tables[0].Rows.Count > 0)
            {
                iNoOfDays = Convert.ToInt32(dsetdays.Tables[0].Rows[0]["NoofDays"]);
            }
        }
        return iNoOfDays;
    }

    private void SetSysFreezeDate()
    {
        try
        {
            DateTime date;
            DateTime SysFreezedate;
            string strbranchcode = string.Empty;
            string strCndNo = string.Empty;
            string strCndType = string.Empty;
            string strReExmFlag = string.Empty;
            string strTccFlag = string.Empty;

            Hashtable htSubmitDt = new Hashtable();
            DataSet dset = new DataSet();
            //dset = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploadedDates");
            htSubmitDt.Add("@Flag", 1);
            dset = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetUploadedDates", htSubmitDt);


            if (dset.Tables.Count > 0)
            {
                if (dset.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                    {
                        GetNoofDays();
                        #region to be uncommented on UAT start
                        //Comented by usha on 29.01.2019  
                        //SysInrgConsum.GetHolidayConsume objhol = new SysInrgConsum.GetHolidayConsume();//Comented by usha on 29.01.2019  
                        ////lstholidays = objhol.GetHolidayDtls(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), 2);
                        //lstworkdays = objhol.GetWorkingdays(dset.Tables[0].Rows[i]["Branch"].ToString(), Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]), iNoOfDays);
                        //Comented end usha on 29.01.2019  
                        #endregion to be uncommented on UAT end
                        strbranchcode = dset.Tables[0].Rows[i]["Branch"].ToString();
                        strCndNo = dset.Tables[0].Rows[i]["CndNo"].ToString();
                        strCndType = dset.Tables[0].Rows[i]["Cand_Type"].ToString();
                        strReExmFlag = dset.Tables[0].Rows[i]["ReExamFlag"].ToString();
                        strTccFlag = dset.Tables[0].Rows[i]["TCCFlag"].ToString();

                        //int idays = GetNoofDays(strCndType, strReExmFlag, strTccFlag);
                        int idays = GetNoofDays();

                        DateTime DtUpld = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                        //DtUpld = DtUpld.AddDays(idays);

                        #region synclogentry


                        string strAppno = dset.Tables[0].Rows[i]["Appno"].ToString();

                        //Comented by usha on 29.01.2019  
                        //#region to be uncommented on UAT start
                        //string strInput = "<WorkingDaysInput><Branch>" + dset.Tables[0].Rows[i]["Branch"].ToString() + "</Branch><UpdatedDt>" + Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]) + "</UpdatedDt><NoOfdays>" + iNoOfDays + "</NoOfdays></WorkingDays>";
                        //string strOutput = "<WorkingDaysOutput>" + lstworkdays[0] + "</WorkingDaysOutput>";
                        ////string strInput = "<WorkingDaysInput><Branch>" + dset.Tables[0].Rows[i]["Branch"].ToString() + "</Branch><UpdatedDt>" + Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]) + "</UpdatedDt><NoOfdays>" + iNoOfDays + "</NoOfdays></WorkingDays>";
                        ////string strOutput = "<WorkingDaysOutput>" + DtUpld + "</WorkingDaysOutput>";
                        //#endregion to be uncommented on UAT end
 
                       // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                       // date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                       
                       

                        //sync Log entry

                       
                        //int g;
                        //htParam.Clear();
                        //htParam.Add("@RefNo", strCndNo);
                        //htParam.Add("@AppNo", strAppno);
                        //htParam.Add("@XmlInput", strInput);
                        //htParam.Add("@CreatedBy", strcallerSystem);
                        //htParam.Add("@Xmloutput", strOutput);
                        //htParam.Add("@Resdate", System.DateTime.Now);
                        //htParam.Add("@Errdesc", "");
                        //htParam.Add("@MethodName", method.Name.ToString());
                        //g = dataAccessRecruit.execute_sprcrecruit("Prc_InsertSysFreezeDateSyncLog", htParam);
                        //Comented end usha on 29.01.2019 
                        #endregion

                        date = Convert.ToDateTime(dset.Tables[0].Rows[i]["UpdateDtim"]);
                        #region to be uncommented on UAT start

                      //  string strDate = lstworkdays[0].ToString();    //Comented end usha on 29.01.2019 
                        string strDate = dset.Tables[0].Rows[i]["UpdateDtim"].ToString();   
                      
                        #endregion
                        #region to be uncommented on UAT start
                        //UpdteDt(strbranchcode, strdate, strCndNo); //Comented end usha on 29.01.2019 
                        UpdteDt(strbranchcode, strDate, strCndNo);
                        #endregion

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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void UpdteDt(string BrnCode, string FreezeDt, string CndNo)
    {
        try
        {
            int f;
            htParam.Clear();
            htParam.Add("@BranchCode", BrnCode);
            htParam.Add("@CndNo", CndNo);
            htParam.Add("@SysFreezeDate", FreezeDt);
            htParam.Add("@Flag", 2);
            f = dataAccessRecruit.execute_sprcrecruit("Prc_UpdSysFreezeDates", htParam);
        }
        catch (Exception ex)
        {
            
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    //added by rachana on 17042014 for updating Freeze date end
    #endregion

    #region button validate
    protected void btn_Validate_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            DataSet ds = new DataSet();

            htParam.Clear();
            htParam.Add("@BatchId", hdnBatchid.Value.ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            strError = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_ValidateBulkUpload", htParam, "@ReturnError");

            //ERROR COUNT
            if (strError == "")
            {
                dsResult.Clear();
                htFlag.Clear();
                htFlag.Add("@BatchId", hdnBatchid.Value.ToString());
                htFlag.Add("@DocType", ddlUpload.SelectedItem.Value);
                dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetErrorCount", htFlag);
                lbl_Error.Text = "<strong>Batch Id :" + hdnBatchid.Value.ToString() + "</strong>";
                // lblErrorRecord.Text = "Application Error Count : <strong>" + dsResult.Tables[0].Rows[0]["StatusCount"].ToString().Trim() + "</strong>";
                lbltCountDesc.Text = dsResult.Tables[0].Rows[0]["TotalCount"].ToString().Trim();
                lblSuccessCountDesc.Text = dsResult.Tables[0].Rows[0]["SuccessCount"].ToString().Trim();
                lblErrorCountDesc.Text = dsResult.Tables[0].Rows[0]["ErrorCount"].ToString().Trim();
                //if (dsResult.Tables[0].Rows[0]["StatusCount"].ToString().Trim() != "0")
                //{
                //btn_view.Visible = true;
                //}
                //trViewLog.Visible = true;
                tblErrorLog.Visible = true;
                //ProgressBarModalPopupExtender.Hide();

                if (dsResult.Tables[0].Rows[0]["TotalCount"].ToString().Trim() == dsResult.Tables[0].Rows[0]["ErrorCount"].ToString().Trim())
                {
                    //btn_Process.Attributes.Add("style", "disabled:true");
                    btn_Validate.Enabled = false;
                    btn_Process.Enabled = true;
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>funAlertvalidate()</script>");
                    lbl.Text = " File validated successfully.";
                    lbl2.Text = "Note: No record to process, please view process log.";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                }
                else
                {
                    //btn_Process.Attributes.Add("style", "disabled:false");
                    btn_Validate.Enabled = false;
                    btn_Process.Enabled = true;
                    //  ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>funAlertvalidate()</script>");
                    lbl.Text = " File validated successfully.";
                    lbl2.Text = "Note: please proceed for process.  ";
                    //mdlpopup.Show();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Validation error')</script>");
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            //ProgressBarModalPopupExtender.Hide();
        }
    }
    #endregion

    #region button upload
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        if (ddlUpload.SelectedItem.Value.ToString() != "Select")
        {
            lbl_Message.Text = "";
            try
            {

                btnUpldFrmt.Enabled = false;
                //btnUpldFrmt.Enabled = false;
                if (fileuploading.HasFile)
                {
                  //  ProgressBarModalPopupExtender.Show();
                    System.Threading.Thread.Sleep(2000);
                    string excelExtention = string.Empty;
                    excelExtention = System.IO.Path.GetExtension(fileuploading.PostedFile.FileName).ToLower();

                    if ((excelExtention != ".csv") && (excelExtention != ".xls") && (excelExtention != ".xlsx"))
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please upload correct file format.')</script>");
                        //ProgressBarModalPopupExtender.Hide();
                    }
                    else if ((ddlUpload.SelectedItem.Value.ToString() != "UIRDAER") && (excelExtention == ".xlsx"))
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please upload correct file format.')</script>");
                        //ProgressBarModalPopupExtender.Hide();
                    }
                    else
                    {
                        htFlag.Clear();
                        htFlag.Add("@DocType", ddlUpload.SelectedItem.Value);
                        strSize = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetFileSize", htFlag, "@Size");

                        if (fileuploading.PostedFile.ContentLength > Convert.ToInt32(strSize))
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('The size of the file is bigger than 2MB')</script>");
                            //ProgressBarModalPopupExtender.Hide();
                        }
                        else
                        {

                        strUploadFile = System.IO.Path.GetFileName(fileuploading.PostedFile.FileName + "_" + System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".xls");
                        htFlag.Clear();
                        dsMastrColm.Clear();
                        dsTempColm.Clear();
                        htFlag.Add("@DocType", ddlUpload.SelectedItem.Value);
                        dsMastrColm = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetMstrColumnName", htFlag);
                        dsTempColm = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetTempColumnName", htFlag);

                        //Master and temp table column check
                        if (dsMastrColm.Tables[0].Rows.Count.Equals(dsTempColm.Tables[0].Rows.Count))
                        {
                            for (int i = 0; i < dsTempColm.Tables[0].Rows.Count; i++)
                            {
                                if (!dsMastrColm.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim().Equals(dsTempColm.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim()))
                                {
                                   // KMI.FRMWRK.DAL.Logger.LogInfo(dsMastrColm.Tables[0].Rows[i]["name"].ToString());
                                   // KMI.FRMWRK.DAL.Logger.LogInfo(dsTempColm.Tables[0].Rows[i]["name"].ToString());
                                    strColumnError = "1";
                                }
                            }
                        }
                        else
                        {
                            strColumnError = "1";
                        }
                        if (strColumnError == "")
                        {
                            destDir = @Server.MapPath("./AgnUpload");
                            fileName = System.IO.Path.GetFileName(fileuploading.PostedFile.FileName + " " + System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
                            destPath = System.IO.Path.Combine(destDir, fileName);
                            fileuploading.PostedFile.SaveAs(destPath);

                            dsTable.Clear();
                            htParam.Clear();
                            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                            htParam.Add("@Flag", "1");
                            strTblName = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetTempHistTbl", htParam, "@TblName");

                            //EXCEL FORMAT CHECK
                            if (ddlUpload.SelectedItem.Value.ToString() == "UIRDAER")
                            {
                                if (excelExtention == ".xls")
                                {
                                    UploadConnection();
                                }
                                else if (excelExtention == ".xlsx")
                                {
                                    xlsxFormat();
                                }
                            }
                            else
                            {
                                if (excelExtention == ".xls")
                                {
                                    UploadConnection();
                                }
                                else if (excelExtention == ".csv")
                                {
                                    dsResult.Tables.Add(GetDataTableFromCSVFile(destPath));
                                }
                            }

                            if (strCSv != "1")
                            {

                                //Master and excel column check
                                if (dsResult.Tables.Count > 0)
                                {
                                    if (dsResult.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsResult.Tables[0].Columns.Count.Equals(dsMastrColm.Tables[0].Rows.Count))
                                        {
                                            for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
                                            {
                                                if (!dsResult.Tables[0].Columns[i].ColumnName.ToString().ToUpper().Equals(dsMastrColm.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim()))
                                                {
                                                    strColumnError = "1";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            strColumnError = "1";
                                        }
                                        if (strColumnError == "")
                                        {
                                            htParam.Clear();
                                            htParam.Add("@TblName", strTblName);
                                            htParam.Add("@UserId", Session["UserID"].ToString());
                                            batchid = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_UpdateBatchid", htParam, "@OutBatchid");
                                            //Session["batchid"] = batchid;
                                            hdnBatchid.Value = batchid;
                                            dsResult.Tables[0].Columns.Add("BatchID", typeof(string));
                                            dsResult.Tables[0].Columns.Add("UserId", typeof(string));
                                            dsResult.Tables[0].Columns.Add("Status", typeof(string));
                                            dsResult.Tables[0].Columns.Add("SeqNo", typeof(string));
                                            dsResult.Tables[0].Columns.Add("Createby", typeof(string));
                                            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                                            {
                                                dsResult.Tables[0].Rows[i]["BatchID"] = batchid;
                                                dsResult.Tables[0].Rows[i]["UserId"] = Session["UserID"].ToString();
                                                dsResult.Tables[0].Rows[i]["Createby"] = Session["UserID"].ToString();
                                              
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please upload correct file format.')</script>");
                                        //ProgressBarModalPopupExtender.Hide();
                                        strColError = "1";
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please browse file to upload.')</script>");
                                    //ProgressBarModalPopupExtender.Hide();
                                    strColError = "1";
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please upload correct file format.')</script>");
                                //ProgressBarModalPopupExtender.Hide();
                                strColError = "1";
                            }
                        }
                        if (strColumnError == "1")
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please upload correct file format.')</script>");
                            //ProgressBarModalPopupExtender.Hide();
                        }
                        else
                        {
                            if (strColError != "1")
                            {
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                                {
                                    bulkCopy.DestinationTableName = strTblName;
                                    //foreach (DataRow dr in dsResult.Tables[0].Rows)
                                    //{
                                    //    dr["Sponsorship Date"] = DateTime.Parse(String.Format("{0}:MM.dd.yyyy", dr["Sponsorship Date"]));

                                    //}
                                    bulkCopy.WriteToServer(dsResult.Tables[0]);
                                }
                                //LOG ENTRY
                                htParam.Clear();
                                dsLogEntry.Clear();
                                htParam.Add("@UserId", Session["UserId"].ToString().Trim());
                                htParam.Add("@RecrdCnt", dsResult.Tables[0].Rows.Count.ToString());
                                htParam.Add("@BatchID", hdnBatchid.Value.ToString());
                                htParam.Add("@Action", "Upd");
                                htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                                dsLogEntry = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_InsUpldDwnldLog", htParam);

                                //ddlUpload.Enabled = false;
                                //fileuploading.Enabled = false;
                                ddlUpload.Enabled = false;
                                fileuploading.Enabled = false;


                                    // //ProgressBarModalPopupExtender.Hide();
                                    // ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>funAlertupload()</script>");
                                    //lbl.Text = ".<br/> <";
                                    //lbl.Text = "File uploaded successfully.<br/> Note: please proceed for validation.";
                                    lbl.Text = "File uploaded successfully.";
                                    lbl2.Text = "Note: Please proceed for validation.";
                                   //  mdlpopup.Show();
                                   ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);

                                btn_Upload.Enabled = false;
                                btn_Validate.Enabled = true;
                            }
                          }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please browse valid file to upload.')</script>");
                    //ProgressBarModalPopupExtender.Hide();
                }

            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                //ProgressBarModalPopupExtender.Hide();
            }
        }
    }
    #endregion

    #region xlsxFormat
    public void xlsxFormat()
    {
        try
        {
            OleDbConnection connOD;
            OleDbCommand command;
            string strConnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + destPath + ";Extended Properties=\"Excel 12.0;Persist Security Info=False;HDR=NO;IMEX=0;Importmixedtypes=text;typeguessrows=0;FMT=Delimited;\"";
            // string strConnectionstring = "Driver={Driver do Microsoft Excel(*.xlsx)};dbq=" + destPath + ";defaultdir=" + destDir + ";driverid=790;fil=excel 8.0;filedsn=C:\\Program Files\\Common Files\\ODBC\\Data Sources\\Excel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid='" + Session["UserID"].ToString() + "';usercommitsync=Yes";// use to connect to excel for reading data
            connOD = new OleDbConnection(strConnectionstring);
            connOD.Open();
            DataTable objDt = new DataTable();
            OdbcDataAdapter oleda = new OdbcDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = connOD.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            String[] excelSheets = new String[dt.Rows.Count];
            string sheetName = string.Empty;
            if (dt != null)
            {
                excelSheets[0] = dt.Rows[0]["TABLE_NAME"].ToString();

            }
            sheetName = "SELECT * FROM [" + excelSheets[0] + "]";
            command = new OleDbCommand(sheetName, connOD);
            OleDbDataAdapter Da = new OleDbDataAdapter(command);
            Da.Fill(dsResult);

        }
        catch (Exception Ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            //ProgressBarModalPopupExtender.Hide();
        }

    }
    #endregion


    #region  Set ODBC Connection String
    public void _SetODBCConnectionString()
    {
        try
        {
            string strConnectionstring = "Driver={Driver do Microsoft Excel(*.xls)};dbq=" + destPath + ";defaultdir=" + destDir + ";driverid=790;fil=excel 8.0;filedsn=C:\\Program Files\\Common Files\\ODBC\\Data Sources\\Excel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid='" + Session["UserID"].ToString() + "';usercommitsync=Yes";// use to connect to excel for reading data
             dbo = new OdbcConnection(strConnectionstring);
            //com = new OdbcCommand("SELECT * FROM `Sheet1$`", dbo);
            dbo.Open();
            DataTable objDt = new DataTable();
            OdbcDataAdapter oleda = new OdbcDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = dbo.GetSchema("Tables");
            string sheetName = string.Empty;
            if (dt != null)
            {
                sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
            }

            comVal = new OdbcCommand("SELECT * FROM [" + sheetName + "]", dbo);
            odaResult = new OdbcDataAdapter(comVal);
            odaResult.Fill(dsResult);

            if (dsResult.Tables[0].Columns.Contains("Application Status").ToString() == "True")
            {
                if (ddlUpload.SelectedItem.Value == "UURNSPN")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Sponsored'", dbo);
                }
                else if (ddlUpload.SelectedItem.Value == "UTRNATI")
                {
                    //com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Training Slot Allocated' ", dbo);
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ' ", dbo);//Changed by rahul for new TSA File
                }
                //else if (ddlUpload.SelectedItem.Value == "UTCCCOM")
                //{
                //    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Trained'", dbo);
                //}
                else if (ddlUpload.SelectedItem.Value == "UEXMCNFM")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Confirmed For Examination'", dbo);
                }
                else if (ddlUpload.SelectedItem.Value == "UEXMNSE")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Examination Slot Allocated'", dbo);
                }

                else if (ddlUpload.SelectedItem.Value == "UEXMRSLT")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status] in ('Examined','Trained')", dbo);
                }
                else if (ddlUpload.SelectedItem.Value == "URENTRN")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status] in ('Sponsored','Training Slot Allocated','Trained') ", dbo);
                }
                else
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "]", dbo);
                }
                dsResult.Clear();
                odaResult = new OdbcDataAdapter(com);
                odaResult.Fill(dsResult);
                com.ExecuteNonQuery();
                com.Dispose();
                dbo.Dispose();
                dbo.Close();
            }
            else
            {
                if (ddlUpload.SelectedItem.Value == "UIRDAER" || ddlUpload.SelectedItem.Value == "UMOMCRT" || ddlUpload.SelectedItem.Value == "USMZNCRT")//Added by usha for MomCreation
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
                    dsResult.Clear();
                    odaResult = new OdbcDataAdapter(com);
                    odaResult.Fill(dsResult);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    dbo.Dispose();
                    dbo.Close();
                }
                else if (ddlUpload.SelectedItem.Value == "ULICUPD")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
                    dsResult.Clear();
                    odaResult = new OdbcDataAdapter(com);
                    odaResult.Fill(dsResult);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    dbo.Dispose();
                    dbo.Close();

                    for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
                    {
                        if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
                        {
                            string s2 = dsResult.Tables[0].Columns[i].ToString();
                            s2 = s2.Replace("#", ".");

                            dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
                        }
                    }
                    dsResult.Tables[0].Columns[21].ColumnName=dsResult.Tables[0].Columns[21].ToString().Replace("Status", "License Status").ToString().Trim();

                }
                //added by Shubham for excel on 06/03/2020
                else if (ddlUpload.SelectedItem.Value == "IIBUTRNATI")
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
                    dsResult.Clear();
                    odaResult = new OdbcDataAdapter(com);
                    odaResult.Fill(dsResult);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    dbo.Dispose();
                    dbo.Close();

                    for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
                    {
                        if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
                        {
                            string s2 = dsResult.Tables[0].Columns[i].ToString();
                            s2 = s2.Replace("#", ".");

                            dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
                        }
                    }
                    // dsResult.Tables[0].Columns[21].ColumnName = dsResult.Tables[0].Columns[21].ToString().Replace("Status", "License Status").ToString().Trim();

                }

                else if ((ddlUpload.SelectedItem.Value == "IIBUEXMRSLT") || (ddlUpload.SelectedItem.Value == "UIIBEXMNSE"))
                {
                    com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);
                    dsResult.Clear();
                    odaResult = new OdbcDataAdapter(com);
                    odaResult.Fill(dsResult);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    dbo.Dispose();
                    dbo.Close();

                    for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
                    {
                        if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
                        {
                            string s2 = dsResult.Tables[0].Columns[i].ToString();
                            s2 = s2.Replace("#", ".");

                            dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
                        }
                    }

                }
                //Ended by Shubham 

                else
                {
                    strValue = "1";
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please browse volid file to upload.')</script>");
                    ProgressBarModalPopupExtender.Hide();
                }
            }
        }


        catch (Exception Ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            ProgressBarModalPopupExtender.Hide();
        }
    }
    #endregion


    //   #region  Set ODBC Connection String
    //   public void _SetODBCConnectionString()
    //   {
    //       try
    //       {
    //           string strConnectionstring = "Driver={Driver do Microsoft Excel(*.xls)};dbq=" + destPath + ";defaultdir=" + destDir + ";driverid=790;fil=excel 8.0;filedsn=C:\\Program Files\\Common Files\\ODBC\\Data Sources\\Excel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid='" + Session["UserID"].ToString() + "';usercommitsync=Yes";// use to connect to excel for reading data
    //           dbo = new OdbcConnection(strConnectionstring);
    //           //com = new OdbcCommand("SELECT * FROM `Sheet1$`", dbo);
    //           dbo.Open();
    //           DataTable objDt = new DataTable();
    //           OdbcDataAdapter oleda = new OdbcDataAdapter();
    //           DataSet ds = new DataSet();
    //           DataTable dt = dbo.GetSchema("Tables");
    //           string sheetName = string.Empty;
    //           if (dt != null)
    //           {
    //               sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
    //           }

    //           comVal = new OdbcCommand("SELECT * FROM [" + sheetName + "]", dbo);
    //           odaResult = new OdbcDataAdapter(comVal);
    //           odaResult.Fill(dsResult);

    //           if (dsResult.Tables[0].Columns.Contains("Application Status").ToString() == "True")
    //           {
    //               if (ddlUpload.SelectedItem.Value == "UURNSPN")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Sponsored'", dbo);
    //               }
    //               else if (ddlUpload.SelectedItem.Value == "UTRNATI")
    //               {
    //                   //com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Training Slot Allocated' ", dbo);
    //				 com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ' ", dbo);//Changed by rahul for new TSA File
    //               }
    //               //uncomented by usha  for training file on 22.01.2018 
    //               else if (ddlUpload.SelectedItem.Value == "UTCCCOM")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Trained'", dbo);
    //               }
    //               //uncomented by usha  for training file on 22.01.2018 
    //               else if (ddlUpload.SelectedItem.Value == "UEXMCNFM")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Confirmed For Examination'", dbo);
    //               }
    //               else if (ddlUpload.SelectedItem.Value == "UEXMNSE")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status]='Examination Slot Allocated'", dbo);
    //               }

    //               else if (ddlUpload.SelectedItem.Value == "UEXMRSLT")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status] in ('Examined','Trained')", dbo);
    //               }
    //	       else if (ddlUpload.SelectedItem.Value == "URENTRN")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] where [Application Status] in ('Sponsored','Training Slot Allocated','Trained') ", dbo);
    //               }
    //               else
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "]", dbo);
    //               }
    //               dsResult.Clear();
    //               odaResult = new OdbcDataAdapter(com);
    //               odaResult.Fill(dsResult);
    //               com.ExecuteNonQuery();
    //               com.Dispose();
    //               dbo.Dispose();
    //               dbo.Close();
    //           }
    //           else
    //           {
    //               if (ddlUpload.SelectedItem.Value == "UIRDAER"|| ddlUpload.SelectedItem.Value == "UMOMCRT" || ddlUpload.SelectedItem.Value == "USMZNCRT")//Added by usha for MomCreation)
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();
    //               }
    //               else if (ddlUpload.SelectedItem.Value == "ULICUPD")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }
    //	    dsResult.Tables[0].Columns[21].ColumnName=dsResult.Tables[0].Columns[21].ToString().Replace("Status", "License Status").ToString().Trim();

    //               }
    //                   //Added by  usha  on 
    //               else if (ddlUpload.SelectedItem.Value == "UPYMTRECNCL")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }
    //               }
    //                   //added by meena 30_3_18

    //               else if (ddlUpload.SelectedItem.Value == "USAPUPD")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }
    //               }
    //               //End by meena 30_3_18

    ////added by usha on 11.02.2019
    //               else if (ddlUpload.SelectedItem.Value == "IIBUTRNATI")
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);  //where UPPER[Application Status]='Licensed'
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }
    //                   // dsResult.Tables[0].Columns[21].ColumnName = dsResult.Tables[0].Columns[21].ToString().Replace("Status", "License Status").ToString().Trim();

    //               }

    //               else if ((ddlUpload.SelectedItem.Value == "IIBUEXMRSLT") ||(ddlUpload.SelectedItem.Value == "UIIBEXMNSE"))
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }

    //               }
    //               //Ended by usha 

    //               else if ((ddlUpload.SelectedItem.Value == "UBNKMEMCrt") || (ddlUpload.SelectedItem.Value == "UBNKMEMTrm")
    //                || (ddlUpload.SelectedItem.Value == "UBNKUntCrt") || (ddlUpload.SelectedItem.Value == "UBNKMEMSup")
    //                || (ddlUpload.SelectedItem.Value == "UBNKUntSup"))
    //               {
    //                   com = new OdbcCommand("SELECT * FROM [" + sheetName + "] ", dbo);
    //                   dsResult.Clear();
    //                   odaResult = new OdbcDataAdapter(com);
    //                   odaResult.Fill(dsResult);
    //                   com.ExecuteNonQuery();
    //                   com.Dispose();
    //                   dbo.Dispose();
    //                   dbo.Close();

    //                   for (int i = 0; i < dsResult.Tables[0].Columns.Count; i++)
    //                   {
    //                       if (dsResult.Tables[0].Columns[i].ColumnName.Contains("#"))
    //                       {
    //                           string s2 = dsResult.Tables[0].Columns[i].ToString();
    //                           s2 = s2.Replace("#", ".");

    //                           dsResult.Tables[0].Columns[i].ColumnName = s2.ToString().Trim();
    //                       }
    //                   }

    //               }
    //               // ended by usha 
    //               else
    //               {
    //                   strValue = "1";
    //                   ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please browse valid file to upload.')</script>");
    //                   //ProgressBarModalPopupExtender.Hide();
    //               }
    //           }
    //       }


    //       catch (Exception Ex)
    //       {
    //           string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //           System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //           string sRet = oInfo.Name;
    //           System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //           String LogClassName = method.ReflectedType.Name;
    //           objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //           //ProgressBarModalPopupExtender.Hide();
    //       }
    //   }
    //   #endregion

    //#region button view process log
    //protected void btn_view_Click(object sender, EventArgs e)
    //{
    //    lbl_Message.Text = "";
    //    try
    //    {
    //        griderror.Visible = true;
    //        tblErrorLog.Visible = true;
    //        btnFailCase.Visible = true;
    //        btnFailCase.Visible = true;
    //        htParam.Clear();
    //        htParam.Add("@Batchid", hdnBatchid.Value);
    //        htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
    //        if (ddl_Error.SelectedItem.ToString() == "Error")
    //        {
    //            htParam.Add("@Flag", "1");
    //            dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);
    //            lblGridError.Text = "Error List";
    //        }
    //        else if (ddl_Error.SelectedItem.ToString() == "Success")
    //        {
    //            htParam.Add("@Flag", "2");
    //            dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);
    //            lblGridError.Text = "Success List";
    //        }
    //        if (dserror != null)
    //        {
    //            if (dserror.Tables.Count > 0)
    //            {
    //                if (dserror.Tables[0].Rows.Count > 0)
    //                {
    //                    ErrorGrid.DataSource = dserror;
    //                    ErrorGrid.DataBind();
    //                    ShowPageInformation();
    //                    ErrorGrid.Visible = true;
    //                    btnExport.Visible = true;
    //                }
    //                else
    //                {

    //                }
    //                {
    //                    lblErrMsg.Text = "0 Record found";
    //                    lblErrMsg.Visible = true;
    //                    btnFailCase.Visible = false;
    //                }
    //            }
    //            else
    //            {
    //                lblErrMsg.Text = "0 Record found";
    //                lblErrMsg.Visible = true;
    //                btnFailCase.Visible = false;
    //            }
    //        }
    //        else
    //        {
    //            lblErrMsg.Text = "0 Record found";
    //            lblErrMsg.Visible = true;
    //            btnFailCase.Visible = false;
    //        }
    //        btn_Upload.Enabled = false;
    //        btn_Validate.Enabled = false;
    //        btn_Process.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //        throw (ex);
    //    }
    //}
    //#endregion

    #region csv format
    public DataTable GetDataTableFromCSVFile(string csvfilePath)
    {
        DataTable csvData = new DataTable();
        using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
        {
            csvReader.SetDelimiters(new string[] { "\t" });
            csvReader.HasFieldsEnclosedInQuotes = true;

            //Read columns from CSV file, remove this line if columns not exits  
            string[] colFields = csvReader.ReadFields();
            if (colFields.Length < dsMastrColm.Tables[0].Rows.Count)
            {
                strCSv = "1";
            }
            else
            {
                if (colFields.Length > dsMastrColm.Tables[0].Rows.Count)
                {
                    Array.Resize(ref colFields, colFields.Length - 1);
                }

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    if (fieldData.Length > dsMastrColm.Tables[0].Rows.Count)
                    {
                        Array.Resize(ref fieldData, fieldData.Length - 1);
                    }
                    //Making empty value as null

                    if (ddlUpload.SelectedItem.Value == "UURNSPN")
                    {
                        //if (fieldData[15].ToString().Trim().ToUpper() == "SPONSORED")//Condition changed by rachana 06-05-2014 for Accepting Records of Sponsored/Trained at the time of Sponsorship Upload
                        if (fieldData[15].ToString().Trim().ToUpper() == "SPONSORED" || fieldData[15].ToString().Trim().ToUpper() == "TRAINED")
                        {
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }
                    else if (ddlUpload.SelectedItem.Value == "UTRNATI")
                    {
                        //Commented by Rahul on 29-04-2015 due to table structre change as per instructed by Anand Sir start
                        //if (fieldData[15].ToString().Trim().ToUpper() == "TRAINING SLOT ALLOCATED")
                        //{
                        //Commented by Rahul on 29-04-2015 due to table structre change as per instructed by Anand Sir end

                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        //}
                    }
                   else if (ddlUpload.SelectedItem.Value == "UTCCCOM")
                   {
                    //    if (fieldData[15].ToString().Trim().ToUpper() == "TRAINED")
                    //    {
                    //        for (int i = 0; i < fieldData.Length; i++)
                    //        {
                    //            if (fieldData[i] == "")
                    //            {
                    //                fieldData[i] = null;
                    //            }
                    //        }

                          csvData.Rows.Add(fieldData);
                    //    }
                    }
                    else if (ddlUpload.SelectedItem.Value == "UEXMCNFM")
                    {
                        if (fieldData[15].ToString().Trim().ToUpper() == "CONFIRMED FOR EXAMINATION")
                        {
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }
                    else if (ddlUpload.SelectedItem.Value == "UEXMNSE")
                    {
                        if (fieldData[15].ToString().Trim().ToUpper() == "EXAMINATION SLOT ALLOCATED")
                        {
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }
                    else if (ddlUpload.SelectedItem.Value == "UEXMRSLT")
                    {
                        if (fieldData[15].ToString().Trim().ToUpper() == "EXAMINED" || fieldData[15].ToString().Trim().ToUpper() == "TRAINED")
                        {
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }
                    else if (ddlUpload.SelectedItem.Value == "ULICUPD")
                    {
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }

                        csvData.Rows.Add(fieldData);
                    }
                    else if (ddlUpload.SelectedItem.Value == "URENTRN")
                    {
                        if (fieldData[15].ToString().Trim().ToUpper() == "SPONSORED" || fieldData[15].ToString().Trim().ToUpper() == "TRAINING SLOT ALLOCATED" || fieldData[15].ToString().Trim().ToUpper() == "TRAINED")
                        {
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }

                            csvData.Rows.Add(fieldData);
                        }
                    }

                     //Added by usha   for IIB Upload 
                    else if (ddlUpload.SelectedItem.Value == "IIBUSPNSHP")
                    {
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }

                        csvData.Rows.Add(fieldData);
                    }
                }
            }
        }

        return csvData;
    }
    #endregion 

    #region button export error log
    protected void btnExport_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsExport = new DataSet();

            htParam.Clear();
            htParam.Add("@Batchid", hdnBatchid.Value);
            htParam.Add("@Flag", "1");
            dsExport = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);

            if (dsExport.Tables.Count > 0)
            {
                if (dsExport.Tables[0].Rows.Count > 0)
                {
                    SetExcelFile();
                    string strData;
                    strHtml = "BatchID" + "\t" + "UniqueRef No." + "\t" + "ErrorDescription" +
                                     "\t" + "ErrorCode" + "\n";

                    for (int i = 0; i < dsExport.Tables[0].Rows.Count; i++)
                    {

                        strData = dsExport.Tables[0].Rows[i]["Batchid"].ToString()
                        + "\t" + dsExport.Tables[0].Rows[i]["UniqueRefNo"].ToString()
                        + "\t" + dsExport.Tables[0].Rows[i]["ErrorDesc"].ToString()
                        + "\t" + dsExport.Tables[0].Rows[i]["ErrorCode"].ToString();

                        strHtml = strHtml + strData + "\n";
                    }
                    byte[] byteData = System.Text.Encoding.ASCII.GetBytes(strHtml.ToString());
                    char[] charData = System.Text.Encoding.ASCII.GetChars(byteData);
                    Response.Write(charData, 0, charData.Length);
                    Response.Flush();
                    Response.Close();
                    dsExport = null;


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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region Set Excel File
    //xls file format
    protected void SetExcelFile()
    {
        string attachment = "attachment; filename="+ViewState["DocType"]+".xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/Microsoft Excel 97- Excel 2008 & 5.0/95 Workbook";
    }

    //csv file format
    protected void setSCVFile()
    {
        string attachment = "attachment; filename=" + ViewState["DocType"] + ".csv";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/Microsoft Excel 97-2003 Workbook";
    }
    #endregion

    #region button cancel
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            if (hdnBatchid.Value != null)
            {
                dsResult.Clear();
                htFlag.Clear();
                htFlag.Add("@BatchId", hdnBatchid.Value.ToString());
                htFlag.Add("@DocType", ddlUpload.SelectedItem.Value);

                string count = dataAccessRecruit.execute_sprc_UpdDwnld_with_output_connKey("Prc_GetStatus", htFlag, "@Count", "UpdDwnldConnectionString");
                hdnFileStsFlag.Value = count;
                if (count != "")
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "popup", "<Script type='text/javascript' language='Javascript'>Confirm()</script>");
                }
                else
                {
                    Response.Redirect("FrmARFUpload.aspx?ModuleID="+ hdnModuleID.Value);
                }
            }
            else
            {
                Response.Redirect("FrmARFUpload.aspx?ModuleID=" + hdnModuleID.Value);
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion

    #region button Fail cases
    protected void btnFailCase_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            string strHtml = string.Empty;
            string strExcel = string.Empty;

            string strData = string.Empty;
            string strExcelData = string.Empty;
            string strExcelColumnData = string.Empty;

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
            htParam.Add("@BatchId", hdnBatchid.Value.ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetFailCases", htParam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                //string filename = "DownloadExcel.xls";
                string filename = ddlUpload.SelectedItem.Text.ToString().Trim() + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dsResult.Tables[0];
                dgGrid.DataBind();

                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    #endregion

    #region button submit 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            string strBatchID = hdnBatchid.Value.ToString();
            dsResult.Clear();
            htFlag.Clear();
            htFlag.Add("@BatchId", hdnBatchid.Value.ToString());
            htFlag.Add("@DocType", ddlUpload.SelectedItem.Value);
            htFlag.Add("@UserId", Session["UserID"].ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_ClearRecord", htFlag);
            Response.Redirect("FrmARFUpload.aspx?ModuleID="+ hdnModuleID.Value);
            
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion

    #region upload format
    protected void btnUpldFrmt_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            if (ddlUpload.SelectedItem.Value.ToString().Trim() == "Select")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=JavaScript>AlertMsgs('Please select document type to download blank file format.');</Script>");
                strCheck = "0";
            }
            else
            {
                strCheck = "1";
            }

            if (strCheck == "1")
            {
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
                dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetBlankFormat", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        if (ddlUpload.SelectedItem.Value.ToString().Trim() == "ULICUPD")
                        {
                            SetExcelFile();
                        }
                        //added by meena 25/4_18 start
                        else if (ddlUpload.SelectedItem.Value.ToString().Trim() == "UPYMTRECNCL")
                        {
                            SetExcelFile();
                        }
                        //added by meena 25/4_18 end
                        else
                        {
                            setSCVFile();
                        }
                        string strHtml = string.Empty;
                        string strExcel = string.Empty;

                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                        {

                            strHtml = dsResult.Tables[0].Rows[i]["name"].ToString();

                            strExcel = strExcel + strHtml + "\t";

                        }

                        byte[] byteData = System.Text.Encoding.ASCII.GetBytes(strExcel.ToString());
                        char[] charData = System.Text.Encoding.ASCII.GetChars(byteData);
                        Response.Write(charData, 0, charData.Length);
                        Response.Flush();
                        Response.Close();
                        dsResult = null;
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
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region FillDropDown
    public void getUploadDoc(DropDownList cbo, string LookupParamValue)
    {
        try
        {
            SqlConnection sqlCon;
            SqlCommand cmd;
            string strSQL = "";

            sqlCon = new SqlConnection(strconn);
            sqlCon.Open();


            //Retrieve data from database
            strSQL = "exec Prc_GetDocName ";
            cbo.DataTextField = "DocDesc";
            cbo.DataValueField = "Doctype";

            cmd = new SqlCommand(strSQL, sqlCon);
            cmd.CommandTimeout = 0;
            //Insert data to dropdownlist
            cbo.DataSource = cmd.ExecuteReader();
            cbo.DataBind();

            if (cbo.Items.FindByValue(LookupParamValue.ToString()) != null)
            {
                cbo.SelectedValue = LookupParamValue.ToString();
            }

            sqlCon.Close();
            sqlCon = null;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region ErrorGrid_PageIndexChanging
    protected void ErrorGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dserror.Clear();
        htParam.Clear();
        htParam.Add("@Batchid", hdnBatchid.Value);
        //if (hdnFlagCheck.Value == "Error")
        //{
            htParam.Add("@Flag", "1");
        //}
        //else if (hdnFlagCheck.Value == "Success")
        //{
        //    htParam.Add("@Flag", "2");
        //}
        dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);

        DataTable dt = dserror.Tables[0];
        DataView dv = new DataView(dt);
        GridView dgSource = (GridView)sender;

        dgSource.PageIndex = e.NewPageIndex;


        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowPageInformation();
        btnExport.Visible = true;
    }
    #endregion

    #region SuccessGrid_PageIndexChanging
    protected void SuccessGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dserror.Clear();
        htParam.Clear();
        htParam.Add("@Batchid", hdnBatchid.Value);
        //if (hdnFlagCheck.Value == "Error")
        //{
        htParam.Add("@Flag", "2");
        htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
        //}
        //else if (hdnFlagCheck.Value == "Success")
        //{
        //    htParam.Add("@Flag", "2");
        //}
        dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);

        DataTable dt = dserror.Tables[0];
        DataView dv = new DataView(dt);
        GridView dgSource = (GridView)sender;

        dgSource.PageIndex = e.NewPageIndex;


        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowSuccessPageInformation();
        btnExport.Visible = true;
    }
    #endregion
    //added by meena
    #region sapSuccessGrid_PageIndexChanging
    protected void sapSuccessGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dserror.Clear();
        htParam.Clear();
        htParam.Add("@Batchid", hdnBatchid.Value);
        //if (hdnFlagCheck.Value == "Error")
        //{
        htParam.Add("@Flag", "2");
        htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
        //}
        //else if (hdnFlagCheck.Value == "Success")
        //{
        //    htParam.Add("@Flag", "2");
        //}
        dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);

        DataTable dt = dserror.Tables[0];
        DataView dv = new DataView(dt);
        GridView dgSource = (GridView)sender;

        dgSource.PageIndex = e.NewPageIndex;


        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowSuccessPageInformation();
        btnExport.Visible = true;
    }
    #endregion
    //added by meena
    #region grdSap Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = ErrorGrid.PageIndex + 1;
        lblPageInfo.Visible = true;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + ErrorGrid.PageCount;
    }
    #endregion

    #region grdSap Show Page Information for GridView
    private void ShowSuccessPageInformation()
    {
        int intPageIndex = SuccessGrid.PageIndex + 1;
        lblSPageInfo.Visible = true;
        lblSPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + SuccessGrid.PageCount;
    }
    #endregion

    #region IRDA Show Page Information for GridView
    //private void ShowIRDAPageInformation()
    //{
    //    int intPageIndex = dgIRDA.PageIndex + 1;
    //    lblIRDAInfo.Visible = true;
    //    lblIRDAInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgIRDA.PageCount;
    //}
    #endregion

    #region Success
    protected void lnkSuccess_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            griderror.Visible = false;
            hdnFlagCheck.Value = "";
            htParam.Clear();
            htParam.Add("@Batchid", hdnBatchid.Value);
            htParam.Add("@DocType", ddlUpload.SelectedItem.Value);
            htParam.Add("@Flag", "2");
            dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);
            lblGridSuccess.Text = "Success Log Details";

            if (ddlUpload.SelectedValue.ToString().Trim()=="USAPUPD")
            {
                if (dserror != null)
                {
                    if (dserror.Tables.Count > 0)
                    {
                        if (dserror.Tables[0].Rows.Count > 0)
                        {
                            hdnFlagCheck.Value = "Success";
                            sapSuccessGrid.DataSource = dserror;
                            sapSuccessGrid.DataBind();
                            sapSuccessGrid.Visible = true;
                            // griderror.Visible = true; //Success grid
                            //trSuccess.Visible = true;

                            trErrorTitle.Visible = false;
                            trsapsuccess.Attributes.Add("style", "display:block;margin:1%");
                            trError.Attributes.Add("style", "display:none;");
                            //     trError.Visible = false;
                            trSuccessTitle.Visible = true;
                            tblErrorLog.Visible = true; //Error Log
                            btnFailCase.Visible = false;
                            btnExport.Visible = false;
                            lblErrMsg.Visible = false;
                            ShowSuccessPageInformation();
                        }
                        else
                        {
                            lblErrMsg.Text = "0 Record found";
                            lblErrMsg.Visible = true;
                            // griderror.Visible = true; //Success grid
                            //trSuccess.Visible = false;
                            trErrorTitle.Visible = false;
                            // trError.Visible = false;
                            trsapsuccess.Attributes.Add("style", "display:none");
                            trError.Attributes.Add("style", "display:none");
                            trSuccessTitle.Visible = false;
                            tblErrorLog.Visible = true; //Error log
                            ErrorGrid.Visible = false;
                            btnFailCase.Visible = false;
                            btnExport.Visible = false;
                            lblPageInfo.Visible = false;
                        }
                    }
                    else
                    {
                        lblErrMsg.Text = "0 Record found";
                        lblErrMsg.Visible = true;
                        // griderror.Visible = true; //Success grid
                        // trSuccess.Visible = false;
                        trErrorTitle.Visible = false;
                        // trError.Visible = false;
                        trSuccessTitle.Visible = false;
                        tblErrorLog.Visible = true; //Error log
                        ErrorGrid.Visible = false;
                        btnFailCase.Visible = false;
                        btnExport.Visible = false;
                        lblPageInfo.Visible = false;
                        trsapsuccess.Attributes.Add("style", "display:none");
                        trError.Attributes.Add("style", "display:none");
                    }
                }
                else
                {
                    lblErrMsg.Text = "0 Record found";
                    lblErrMsg.Visible = true;
                    griderror.Visible = true; //Success grid
                    //trSuccess.Visible = false;
                    trErrorTitle.Visible = false;
                    //trError.Visible = false;
                    trSuccessTitle.Visible = false;
                    tblErrorLog.Visible = true; //Error log
                    ErrorGrid.Visible = false;
                    btnFailCase.Visible = false;
                    btnExport.Visible = false;
                    lblPageInfo.Visible = false;
                    trsapsuccess.Attributes.Add("style", "display:none");
                    trError.Attributes.Add("style", "display:none");
                }
            }
            else
            {
                if (dserror != null)
                {
                    if (dserror.Tables.Count > 0)
                    {
                        if (dserror.Tables[0].Rows.Count > 0)
                        {
                            hdnFlagCheck.Value = "Success";
                            SuccessGrid.DataSource = dserror;
                            SuccessGrid.DataBind();
                            SuccessGrid.Visible = true;
                            // griderror.Visible = true; //Success grid
                            //trSuccess.Visible = true;

                            trErrorTitle.Visible = false;
                            trSuccess.Attributes.Add("style", "display:block;margin:1%");
                            trError.Attributes.Add("style", "display:none;");
                            //     trError.Visible = false;
                            trSuccessTitle.Visible = true;
                            tblErrorLog.Visible = true; //Error Log
                            btnFailCase.Visible = false;
                            btnExport.Visible = false;
                            lblErrMsg.Visible = false;
                            ShowSuccessPageInformation();
                        }
                        else
                        {
                            lblErrMsg.Text = "0 Record found";
                            lblErrMsg.Visible = true;
                            // griderror.Visible = true; //Success grid
                            //trSuccess.Visible = false;
                            trErrorTitle.Visible = false;
                            // trError.Visible = false;
                            trSuccess.Attributes.Add("style", "display:none");
                            trError.Attributes.Add("style", "display:none");
                            trSuccessTitle.Visible = false;
                            tblErrorLog.Visible = true; //Error log
                            ErrorGrid.Visible = false;
                            btnFailCase.Visible = false;
                            btnExport.Visible = false;
                            lblPageInfo.Visible = false;
                        }
                    }
                    else
                    {
                        lblErrMsg.Text = "0 Record found";
                        lblErrMsg.Visible = true;
                        // griderror.Visible = true; //Success grid
                        // trSuccess.Visible = false;
                        trErrorTitle.Visible = false;
                        // trError.Visible = false;
                        trSuccessTitle.Visible = false;
                        tblErrorLog.Visible = true; //Error log
                        ErrorGrid.Visible = false;
                        btnFailCase.Visible = false;
                        btnExport.Visible = false;
                        lblPageInfo.Visible = false;
                        trSuccess.Attributes.Add("style", "display:none");
                        trError.Attributes.Add("style", "display:none");
                    }
                }
                else
                {
                    lblErrMsg.Text = "0 Record found";
                    lblErrMsg.Visible = true;
                   // griderror.Visible = true; //Success grid
                   // trSuccess.Visible = false;
                    trErrorTitle.Visible = false;
                   // trError.Visible = false;
                    trSuccessTitle.Visible = false;
                    tblErrorLog.Visible = true; //Error log
                    ErrorGrid.Visible = false;
                    btnFailCase.Visible = false;
                    btnExport.Visible = false;
                    lblPageInfo.Visible = false;
                    trSuccess.Attributes.Add("style", "display:none");
                    trError.Attributes.Add("style", "display:none");
                }
            }
            
            btn_Upload.Enabled = false;
            //btn_Upload.Enabled = false;
            btn_Validate.Enabled = false;
            //btn_Validate.Enabled = false;
            btn_Process.Enabled = true;
            //btn_Process.Enabled = true;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region Error Link
    protected void lnkFail_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        try
        {
            trSuccessTitle.Visible = false;
            hdnFlagCheck.Value = "";
            htParam.Clear();
            htParam.Add("@Batchid", hdnBatchid.Value);
            htParam.Add("@Flag", "1");
            dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);
            lblGridError.Text = "Error Log Details";

            if (dserror != null)
            {
                if (dserror.Tables.Count > 0)
                {
                    if (dserror.Tables[0].Rows.Count > 0)
                    {
                        ErrorGrid.DataSource = dserror;
                        ErrorGrid.DataBind();
                        ErrorGrid.Visible = true;
                        griderror.Visible = true; //Error grid
                        trErrorTitle.Visible = true;
                       // trError.Visible = true;
                        trSuccessTitle.Visible = false;
                       // trSuccess.Visible = false;
                        tblErrorLog.Visible = true; //Error log
                        btnFailCase.Visible = true;
                        btnExport.Visible = true;
                        lblErrMsg.Visible = false;
                        ShowPageInformation();
                        hdnFlagCheck.Value = "Error";
                        trSuccess.Attributes.Add("style", "display:none");
                        trError.Attributes.Add("style", "display:block;margin:1%");
                    }
                    else
                    {
                        lblErrMsg.Text = "0 Record found";
                        lblErrMsg.Visible = true;
                        griderror.Visible = false; //Error grid
                        trErrorTitle.Visible = false;
                       // trError.Visible = false;
                        trSuccessTitle.Visible = false;
                        //trSuccess.Visible = false;
                        tblErrorLog.Visible = true; //Error log
                        ErrorGrid.Visible = false;
                        SuccessGrid.Visible = false;
                        btnFailCase.Visible = false;
                        btnExport.Visible = false;
                        lblPageInfo.Visible = false;
                        trSuccess.Attributes.Add("style", "display:none");
                        trError.Attributes.Add("style", "display:none");
                    }
                }
                else
                {
                    lblErrMsg.Text = "0 Record found";
                    lblErrMsg.Visible = true;
                    griderror.Visible = false; //Error grid
                    trErrorTitle.Visible = false;
                  //  trError.Visible = false;
                    trSuccessTitle.Visible = false;
                   // trSuccess.Visible = false;
                    tblErrorLog.Visible = true; //Error log
                    ErrorGrid.Visible = false;
                    SuccessGrid.Visible = false;
                    btnFailCase.Visible = false;
                    btnExport.Visible = false;
                    lblPageInfo.Visible = false;
                    trSuccess.Attributes.Add("style", "display:none");
                    trError.Attributes.Add("style", "display:none");
                }
            }
            else
            {
                lblErrMsg.Text = "0 Record found";
                lblErrMsg.Visible = true;
                griderror.Visible = false; //Error grid
                trErrorTitle.Visible = false;
                //trError.Visible = false;
                trSuccessTitle.Visible = false;
               // trSuccess.Visible = false;
                tblErrorLog.Visible = true; //Error log
                ErrorGrid.Visible = false;
                SuccessGrid.Visible = false;
                btnFailCase.Visible = false;
                btnExport.Visible = false;
                lblPageInfo.Visible = false;
                trSuccess.Attributes.Add("style", "display:none");
                trError.Attributes.Add("style", "display:none");
            }
            btn_Upload.Enabled = false;
            //btn_Upload.Enabled = false;
            btn_Validate.Enabled = false;
            //btn_Validate.Enabled = false;
            btn_Process.Enabled = true;
            //btn_Process.Enabled = true;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region AddErrorTable assign to SM
    //private void AddErrorTable()
    //{

    //    if (dsUpldData.Tables.Count > 0)
    //    {
    //        if (dsUpldData.Tables[0].Rows.Count > 0)
    //        {
    //            tblIRDA.Visible = true;
    //            dgIRDA.DataSource = dsUpldData.Tables[0];
    //            dgIRDA.DataBind();
    //            ShowIRDAPageInformation();
    //        }
    //    }

    //}
    #endregion

    #region btnApprove_Click
    //protected void btnApprove_Click(object sender, EventArgs e)
    //{
    //    dtCurrentTable = (DataTable)ViewState["IRDAError"];

    //    foreach (GridViewRow rw in dgIRDA.Rows)
    //    {
    //        CheckBox chkIRAD = (CheckBox)rw.FindControl("chkError");
    //        if (chkIRAD != null && chkIRAD.Checked)
    //        {

    //            strNo = ((Label)rw.FindControl("lblNo")).Text;
    //            dtCurrentTable.Rows[Convert.ToInt32(strNo) - 1].Delete();

    //            strSMAppNo = ((Label)rw.FindControl("lblInsurerRefNo")).Text;

    //            sbSMAppNo.Append(strSMAppNo);
    //            sbSMAppNo.Append(",");

    //            strIRDAErr = ((Label)rw.FindControl("lblErrorDesc")).Text;
    //            sbSMIRDAError.Append(strIRDAErr);
    //            sbSMIRDAError.Append(",");
    //        }
    //    }
    //    sbSMAppNo.Append(",");
    //    sbSMIRDAError.Append(",");

    //    strSMAppNoDesc = sbSMAppNo.ToString();
    //    strIRDAErrDesc = sbSMIRDAError.ToString();

    //    strSMAppNoDesc = strSMAppNoDesc.Replace(",,", "");
    //    strIRDAErrDesc = strIRDAErrDesc.Replace(",,", "");

    //    dgIRDA.DataSource = dtCurrentTable;
    //    dgIRDA.DataBind();

    //    htParam.Clear();
    //    dsResult.Clear();
    //    htParam.Add("@Appno", strSMAppNoDesc);
    //    htParam.Add("@ErrorDesc", strIRDAErrDesc);
    //    dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_UpdateAutoCFR", htParam);

    //}
    #endregion
}
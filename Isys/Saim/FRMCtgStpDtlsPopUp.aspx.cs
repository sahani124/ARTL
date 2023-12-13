using System.Linq;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using DataAccessClassDAL;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;
using System.Reflection;

public partial class Application_Isys_Saim_Customisation_FRMCtgStpDtlsPopUp : BaseClass
{
    #region "Declare Variable"
    DataAccessClass objDAL = new DataAccessClass();
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
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
    List<String> lstholidays = new List<string>();
    List<String> lstworkdays = new List<string>();
    int iNoOfDays;
    string strcallerSystem = System.Configuration.ConfigurationManager.AppSettings["CallerSystem"].ToString();
    string strCSv = string.Empty;
    string strSize = string.Empty;
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
    #endregion
    public string ActSchNo = string.Empty;


    public void Page_Load(object sender, EventArgs e)
   {
        try
        {
            if (Session["UserID"].ToString() == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"].ToString().Trim() != null && Request.QueryString["Mode"].ToString().Trim() == "S")
                {
                    if (Request.QueryString["ActSchNo"].ToString().Trim() != null)
                    {
                        PopulateUpdddl(Request.QueryString["ActSchNo"].ToString().Trim());
                        ActSchNo = Request.QueryString["ActSchNo"].ToString().Trim();
                        ViewState["ActSchNo"] = ActSchNo;
                        ViewState["ActNo"] = ActSchNo;
                    }
                }
                if (Request.QueryString["Mode"].ToString().Trim() != null && Request.QueryString["Mode"].ToString().Trim() == "B")
                {
                    if (Request.QueryString["ActSchKey"].ToString().Trim() != null)
                    {
                        htParam.Clear();
                        dsTable.Clear();
                        htParam.Add("@ActNo", "");
                        htParam.Add("@ActSchKey", Request.QueryString["ActSchKey"].ToString().Trim());
                        dsTable = objDAL.GetDataSetForPrc_SAIM("Prc_GetMstActCtgSudtls", htParam);
                        if (dsTable.Tables[0].Rows.Count > 0)
                        {
                            PopulateUpdddl(dsTable.Tables[0].Rows[0]["ACT_SCHM_NO"].ToString().Trim());
                            ActSchNo = dsTable.Tables[0].Rows[0]["ACT_SCHM_NO"].ToString().Trim();
                            ViewState["ActSchNo"] = ActSchNo;
                            ViewState["ActNo"] = dsTable.Tables[0].Rows[0]["ACT_NO"].ToString().Trim();
                        }
                    }
                }
            }
            //ActSchNo = Request.QueryString["ActSchNo"].ToString().Trim();
            btn_Upload.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            btn_Process.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            btn_Validate.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            ViewState["DocType"] = ddlUpload.SelectedItem.Text.ToString().Trim();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    #region PopulateUpdddl
    private void PopulateUpdddl(string ActSchNo)
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@UserId", Session["UserID"].ToString());
            htParam.Add("@Flag", "CtgSchUpload" + ActSchNo);
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
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM","FRMCtgStpDtlsPopUp", "PopulateUpdddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btnUpldFrmt_Click(object sender, EventArgs e)
    {
        try
        {
            string fixfactor = string.Empty;
            string rangefactor = string.Empty;
            string[] fixfactorArr;
            string[] rangefactorArr;
            DataSet dsExcel = new DataSet();
            DataTable dtExcel = new DataTable();

            if (ViewState["ActNo"].ToString().Trim() != "")
            {
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@ActNo", ViewState["ActNo"].ToString().Trim());
                htParam.Add("@ActSchKey", System.DBNull.Value);
                dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_GetMstActCtgSudtls", htParam);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    fixfactor = dsResult.Tables[0].Rows[0]["FIX_FCTR"].ToString().Trim();
                    fixfactorArr = fixfactor.Split('|');
                    rangefactor = dsResult.Tables[0].Rows[0]["RNG_FCTR"].ToString().Trim();
                    rangefactorArr = rangefactor.Split('|');

                    dsExcel.Tables.Add(dtExcel);
                    dsExcel.Tables[0].Columns.Add("SEQ_NO", typeof(string));
                    dsExcel.Tables[0].Columns.Add("ACT_SCHM_KEY", typeof(string));
                    foreach (string val in fixfactorArr)
                    {
                        dsExcel.Tables[0].Columns.Add(val, typeof(string));
                    }
                    foreach (string value in rangefactorArr)
                    {
                        dsExcel.Tables[0].Columns.Add(value + "_From", typeof(string));
                        dsExcel.Tables[0].Columns.Add(value + "_To", typeof(string));
                    }
                    ExportCSV(dsExcel.Tables[0], "SampleCategorySchemeFile");
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
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "btnUpldFrmt_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsExcelFinal = new DataSet();
            DataTable dtExcelFinal = new DataTable();
            if (ddlUpload.SelectedIndex != 0)
            {
                if (FileUpload1.HasFile)
                {
                    string excelExtention = string.Empty;
                    excelExtention = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                    if (excelExtention == ".xlsx" || excelExtention == ".xls")
                    {
                        if (!Convert.IsDBNull(FileUpload1.PostedFile) & FileUpload1.PostedFile.ContentLength > 0)
                        {
                            string strfile = Server.MapPath(".") + "\\" + FileUpload1.FileName.ToString();
                            FileUpload1.SaveAs(Server.MapPath(".") + "\\" + FileUpload1.FileName);
                            SqlBulkCopy oSqlBulk = null;
                            OleDbConnection myExcelConn;

                            string strConnectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strfile + ";Extended Properties=\"Excel 8.0;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;FMT=Delimited;\"";

                         //  string strConnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strfile + ";Extended Properties=\"Excel 8.0;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;FMT=Delimited;\"";
                            myExcelConn = new OleDbConnection(strConnectionstring);
                            if (myExcelConn.State == ConnectionState.Open)
                            {
                                myExcelConn.Close();
                            }
                            myExcelConn.Open();
                            DataTable objDt = new DataTable();
                            OdbcDataAdapter oleda = new OdbcDataAdapter();
                            DataSet ds = new DataSet();
                            OleDbCommand objOleDB;
                            DataTable dt = myExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            String[] excelSheets = new String[dt.Rows.Count];
                            string sheetName = string.Empty;
                            if (dt != null)
                            {
                                excelSheets[0] = dt.Rows[0]["TABLE_NAME"].ToString();
                            }
                            sheetName = "SELECT * FROM [" + excelSheets[0] + "]";
                            objOleDB = new OleDbCommand(sheetName, myExcelConn);

                            DataSet dsresult = new DataSet();
                            OleDbDataAdapter Da = new OleDbDataAdapter(objOleDB);
                            Da.Fill(dsresult);

                            #region get fixfactor and rangeFactor

                            string fixfactor = string.Empty;
                            string rangefactor = string.Empty;
                            string[] fixfactorArr;
                            string[] rangefactorArr;
                            DataSet dsExcel = new DataSet();
                            DataTable dtExcel = new DataTable();
                            htParam.Clear();
                            htParam.Add("@ActNo", ViewState["ActNo"].ToString().Trim());
                            htParam.Add("@ActSchKey", Request.QueryString["ActSchKey"].ToString().Trim());
                            DataSet dsResult1 = objDAL.GetDataSetForPrc_SAIM("Prc_GetMstActCtgSudtls", htParam);
                            fixfactor = dsResult1.Tables[0].Rows[0]["FIX_FCTR"].ToString().Trim();
                            fixfactorArr = fixfactor.Split('|');
                            rangefactor = dsResult1.Tables[0].Rows[0]["RNG_FCTR"].ToString().Trim();
                            rangefactorArr = rangefactor.Split('|');

                            #endregion get fixfactor and rangeFactor

                            bool isValid = isValidExcel(rangefactorArr.Length, dsresult, rangefactorArr);
                            if (isValid)
                            {

                                DataTable Exceldt = dsresult.Tables[0];
                                Exceldt.AcceptChanges();
                                int ds1 = Exceldt.Columns.Count;


                                dsresult.Tables[0].MergeColumns("ACT_SCHM_CODE", fixfactorArr);
                                dsExcelFinal.Tables.Add(dtExcelFinal);
                                dsExcelFinal.Tables[0].Columns.Add("SEQ_NO", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("ACT_SCHM_KEY", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("ACT_SCHM_CODE", typeof(string));

                                for (int i = 0; i < rangefactorArr.Length; i++)
                                {
                                    dsExcelFinal.Tables[0].Columns.Add("MIN" + (i + 1), typeof(string));
                                    dsExcelFinal.Tables[0].Columns.Add("MAX" + (i + 1), typeof(string));
                                }
                                dsExcelFinal.Tables[0].Columns.Add("RATE1", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("RATE2", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("RATE3", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("RATE4", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("STATUS", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("VID", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("CREATEDBY", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("CREATE_DTIM", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("UPDATEDBY", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("UPDATE_DTIM", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("BatchId", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("PStatus", typeof(string));
                                dsExcelFinal.Tables[0].Columns.Add("UserId", typeof(string));



                                htParam.Clear();
                                htParam.Add("@DocType", "CtgSchUpload");
                                batchid = objDAL.execute_sprc_UpdDwnld_with_output("Prc_UpdtBatchId", htParam, "@Batch");
                                hdnBatchid.Value = batchid;
                                for (int i = 0; i < dsresult.Tables[0].Rows.Count; i++)
                                {
                                    DataRow row = dtExcelFinal.NewRow();
                                    dtExcelFinal.Rows.Add(row);

                                    dsExcelFinal.Tables[0].Rows[i]["SEQ_NO"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["ACT_SCHM_KEY"] = dsResult1.Tables[0].Rows[0]["ACT_SCHM_KEY"];
                                    dsExcelFinal.Tables[0].Rows[i]["ACT_SCHM_CODE"] = dsresult.Tables[0].Rows[i]["ACT_SCHM_CODE"].ToString().Trim();
                                    for (int j = 0; j < rangefactorArr.Length; j++)
                                    {
                                        if (rangefactorArr[j].ToString().Trim() == "LD" || rangefactorArr[j].ToString().Trim() == "TD")
                                        {
                                            //string frmdt = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");
                                            dsExcelFinal.Tables[0].Rows[i]["MIN" + (j + 1)] = Convert.ToDateTime(dsresult.Tables[0].Rows[i][rangefactorArr[j] + "_From"].ToString().Trim()).ToString("dd-MM-yyyy");
                                            dsExcelFinal.Tables[0].Rows[i]["MAX" + (j + 1)] = Convert.ToDateTime(dsresult.Tables[0].Rows[i][rangefactorArr[j] + "_To"].ToString().Trim()).ToString("dd-MM-yyyy");
                                        }
                                        else
                                        {
                                            dsExcelFinal.Tables[0].Rows[i]["MIN" + (j + 1)] = dsresult.Tables[0].Rows[i][rangefactorArr[j] + "_From"].ToString().Trim();
                                            dsExcelFinal.Tables[0].Rows[i]["MAX" + (j + 1)] = dsresult.Tables[0].Rows[i][rangefactorArr[j] + "_To"].ToString().Trim();
                                        }
                                    }

                                    dsExcelFinal.Tables[0].Rows[i]["RATE1"] = dsresult.Tables[0].Rows[i]["Rate"].ToString().Trim();
                                    dsExcelFinal.Tables[0].Rows[i]["RATE2"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["RATE3"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["RATE4"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["STATUS"] = 1;
                                    dsExcelFinal.Tables[0].Rows[i]["VID"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["CREATEDBY"] = HttpContext.Current.Session["UserID"].ToString().Trim();
                                    DateTime myDateTime = DateTime.Now;
                                    dsExcelFinal.Tables[0].Rows[i]["CREATE_DTIM"] = myDateTime;
                                    dsExcelFinal.Tables[0].Rows[i]["UPDATEDBY"] = System.DBNull.Value; ;
                                    dsExcelFinal.Tables[0].Rows[i]["UPDATE_DTIM"] = System.DBNull.Value; ;
                                    dsExcelFinal.Tables[0].Rows[i]["BatchId"] = batchid;
                                    dsExcelFinal.Tables[0].Rows[i]["PStatus"] = System.DBNull.Value;
                                    dsExcelFinal.Tables[0].Rows[i]["UserId"] = HttpContext.Current.Session["UserID"].ToString().Trim();
                                }

                                #region Add to Tmp
                                try
                                {
                                    OleDbDataReader objBulkReader = null;
                                    objBulkReader = objOleDB.ExecuteReader();
                                    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ToString()))
                                    {
                                        con.Open();
                                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                                        {
                                            bulkCopy.DestinationTableName = "Tx_TblTmp_MST_ACT_CATG_SCHM_" + ViewState["ActSchNo"].ToString().Trim();
                                            bulkCopy.WriteToServer(dsExcelFinal.Tables[0]);
                                        }
                                        htParam.Clear();
                                        ProgressBarModalPopupExtender1.Hide();
                                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Excel Uploaded successfully')</script>");
                                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                        myExcelConn.Close();
                                        con.Close();
                                        btn_Upload.Enabled = false;
                                        btn_Validate.Enabled = true;
                                    }
                                }

                                catch (Exception ex)
                                {
                                    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                                    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                                    string sRet = oInfo.Name;
                                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                                    String LogClassName = method.ReflectedType.Name;
                                    objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", " Add to Tmp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                                    if (ex.Message.ToString() == "The given value of type String from the data source cannot be converted to type decimal of the specified target column.")
                                    {
                                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Please enter Rate for all the fields and try again.')</script>");
                                    }
                                }
                                finally
                                {
                                    oSqlBulk.Close();
                                    oSqlBulk = null;
                                    myExcelConn.Close();
                                    myExcelConn = null;
                                }
                                #endregion Add to Tmp
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('You trying to upload wrong file.')</script>");
                            }
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Incorrect file format.Upload file with .xls or .xlsx extention')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Please select file and try again.')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Please select document type.')</script>");
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM","FRMCtgStpDtlsPopUp", "btn_Upload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            if (ex.Message.ToString() == "The string was not recognized as a valid DateTime. There is an unknown word starting at index 0." || ex.Message.ToString() == "String was not recognized as a valid DateTime.")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Please enter valid dates for LD or TD.')</script>");
            }
        }
    }

    public void btn_Validate_Click(object sender, EventArgs e)
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
                htFlag.Add("@DocType", ddlUpload.SelectedItem.Value.ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetErrorCount", htFlag);
                lbl_Error.Text = "<strong>Batch Id :" + hdnBatchid.Value.ToString() + "</strong>";
                lbltCountDesc.Text = dsResult.Tables[0].Rows[0]["TotalCount"].ToString().Trim();
                lblSuccessCountDesc.Text = dsResult.Tables[0].Rows[0]["SuccessCount"].ToString().Trim();
                lblErrorCountDesc.Text = dsResult.Tables[0].Rows[0]["ErrorCount"].ToString().Trim();
                tblErrorLog.Visible = true;
                ProgressBarModalPopupExtender1.Hide();
                if (dsResult.Tables[0].Rows[0]["TotalCount"].ToString().Trim() == dsResult.Tables[0].Rows[0]["ErrorCount"].ToString().Trim())
                {
                    btn_Validate.Enabled = false;
                    btn_Process.Enabled = true;
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>funAlertvalidate()</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('File validated successfully.No record to process, please view process log.');", true);
                }
                else
                {
                    btn_Validate.Enabled = false;
                    btn_Process.Enabled = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('File validated successfully, please proceed for process.');", true);
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
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "btn_Validate_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void btn_Process_Click(object sender, EventArgs e)
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
                    htParam.Clear();
                    htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                    htParam.Add("@Flag", '2');
                    strTblName = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetTempHistTbl", htParam, "@TblName");
                    if (dsResult.Tables.Count > 0)
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                        {
                            bulkCopy.DestinationTableName = strTblName;
                            bulkCopy.WriteToServer(dsResult.Tables[0]);
                            htParam.Clear();
                        }
                    }
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
                ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('No record processed.');", true);
            }
            else
            {
                htParam.Clear();
                htParam.Add("@batchid", hdnBatchid.Value);
                htParam.Add("@Doctype", ddlUpload.SelectedItem.Value.ToString());
                htParam.Add("@UserId", Session["UserID"].ToString().Trim());
                a = dataAccessRecruit.execute_sprcUpdDwnld("prc_DeleteTmpTbl", htParam);

                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@tmpTbl", strTblName);
                htParam.Add("@batchid", hdnBatchid.Value.ToString());
                dsResult = objDAL.GetDataSetForPrc_SAIM("prc_InsBulkCtgSchDtls", htParam);
                if (dsResult.Tables[0].Rows[0]["Status"].ToString().Trim() == "0")
                {
                    ProgressBarModalPopupExtender1.Hide();
                    ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('File processed successfully.');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('Something went wrong.');", true);
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
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "btn_Process_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {

    }

    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        string sRet = oInfo.Name;
        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        String LogClassName = method.ReflectedType.Name;
        objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
 
}
        return Rest;


    }

    #region Success
    public void lnkSuccess_Click(object sender, EventArgs e)
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

            if (ddlUpload.SelectedValue.ToString().Trim() == "USAPUPD")
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
            objErr.LogErr("ISYS-SAIM","FRMCtgStpDtlsPopUp", "lnkSuccess_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region Error Link
    public void lnkFail_Click(object sender, EventArgs e)
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
                        btnFailCase.Visible = true; //Commmented by daksh for UAT purpose only
                        btnExport.Visible = true; //Commmented by daksh for UAT purpose only
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
                        griderror.Visible = true; //Error grid
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
                    griderror.Visible = true; //Error grid
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
                griderror.Visible = true; //Error grid
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
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "lnkFail_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

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

    public bool isValidExcel(int len, DataSet dsres, string[] rangefactorArr)
    {
        bool isExists = false;
        int excelRangeCount = 0;
        try
        {

            for (int i = 0; i < rangefactorArr.Length; i++)
            {
                if ((dsres.Tables[0].Columns.Contains(rangefactorArr[i] + "_From")) && (dsres.Tables[0].Columns.Contains(rangefactorArr[i] + "_To")))
                {
                    excelRangeCount += 1;
                }
            }
            isExists = rangefactorArr.Length == excelRangeCount;

            //List<string> ar = new List<string>();
            //for (int i = 1; i <= len; i++)
            //{
            //    ar.Add("MIN" + i.ToString());
            //    ar.Add("MAX" + i.ToString());
            //}
            //string[] arr = ar.ToArray<string>();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!dsres.Tables[0].Columns.Contains(arr[i]))
            //    {
            //        isExists = false;
            //        break;
            //    }
            //}
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "isValidExcel", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return isExists;
    }


    public DataTable testDataType()
    {
        DataTable table = new DataTable();
        try
        {
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("company", typeof(string));

            // Step 3: here we add 5 rows.
            table.Rows.Add(1, "Indocin", "David");
            table.Rows.Add(2, "Enebrel", "Sam");
            table.Rows.Add(3, "Hydralazine", "Christoff");
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    public DataTable testDataType1()
    {
        DataTable table = new DataTable();
        try
        {
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("company", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Step 3: here we add 5 rows.
            table.Rows.Add(4, "Indocin", "David", DateTime.Now);
            table.Rows.Add(5, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(6, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(7, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(8, "Dilantin", "Melanie", DateTime.Now);
        }
        catch(Exception ex)
        {
       
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FRMCtgStpDtlsPopUp", "DataTable testDataType1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
      
    }
        return table;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        dserror.Clear();
        htParam.Add("@Batchid", hdnBatchid.Value);
        htParam.Add("@Flag", "1");
        dserror = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_BindErrorGrid", htParam);
        ExportCSV(dserror.Tables[0], "ErrorDescription_" + hdnBatchid.Value);
    }
    protected void btnFailCase_Click(object sender, EventArgs e)
    {
        DataSet dsFailedcases = new DataSet();
        htParam.Clear();
        dserror.Clear();
        htParam.Add("@Batchid", hdnBatchid.Value);
        htParam.Add("@ACT_SCHM_KEY", Request.QueryString["ActSchKey"].ToString().Trim());
        dsFailedcases = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetErrorGRID", htParam);
        ExportCSV(dsFailedcases.Tables[0], "FailedCases_" + hdnBatchid.Value);
    }

    
}

public static class Helper
{
    public static void MergeColumns(this DataTable t, string newColumn, params string[] columnsToMerge)
    {
        t.Columns.Add(newColumn, typeof(string));
        foreach (DataRow r in t.Rows)
            r[newColumn] = string.Format("{0}", String.Join("|", columnsToMerge.Select(col => r[col].ToString().Trim()).ToArray()));
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using INSCL.DAL;
using INSCL.App_Code;
using Insc.Common.Multilingual;
using DataAccessClassDAL;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Drawing;


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

public partial class Application_Isys_Saim_PopBatchHybrid : BaseClass
{
    #region DECLARE VARIABLES

    string CMPNSTN_CODE = string.Empty;

    string CNTSTNT_CODE = string.Empty;

    string RuleSet = string.Empty;

    string AccCycle = string.Empty;
    string table_name = null;
    string strColumnError = string.Empty;
    DataSet dsResult=new DataSet();
    Hashtable htParam = new Hashtable();
    private multilingualManager olng;
    private DataAccessClass dataAccess = new DataAccessClass();
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';

            if (Request.QueryString["CmpCode"] != null)
            {
                CMPNSTN_CODE = Request.QueryString["CmpCode"].ToString().Trim();

            }

            if (Request.QueryString["cnstCode"] != null)
            {
                CNTSTNT_CODE = Request.QueryString["cnstCode"].ToString().Trim();

            }


            if (Request.QueryString["RuleSet"] != null)
            {
                RuleSet = Request.QueryString["RuleSet"].ToString().Trim();

            }

            if (Request.QueryString["AccCycle"] != null)
            {
                AccCycle = Request.QueryString["AccCycle"].ToString().Trim();

            }

            if (!IsPostBack)
            {
                BindDataGrid();




            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void BindDataGrid()
    {

        try
        {

            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", CMPNSTN_CODE);
            htParam.Add("@CNTSTNT_CODE",CNTSTNT_CODE);
            htParam.Add("@RULE_SET_KEY", RuleSet);
            htParam.Add("@ACCR_CYCLE", AccCycle);

                 

            dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_CheckHybridKPI", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    try
                    {

                        dgHybridKPI.DataSource = dsResult.Tables[0];
                        dgHybridKPI.DataBind();

                    }
                    catch (Exception ex)
                    {

                        ex.Message.ToString();
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Not Found')", true);  
                }
            }


        }

        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "BindDataGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
    }



    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;

            LinkButton lnkup = (LinkButton)gvRow.FindControl("btn_Upload");
            FileUpload FileUpload1 = (FileUpload)gvRow.FindControl("FileUpload");
            Label lblCNTSTNT_CODE = (Label)gvRow.FindControl("lblCNTSTNT_CODE");
            HiddenField hdf_kpiCode = (HiddenField)gvRow.FindControl("hdnKPI_CODE");


            if (FileUpload1.HasFile)
            {


                string excelExtention = string.Empty;
                excelExtention = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                if (excelExtention == ".xlt")
                {
                    UPLOAD_EXCEL(sender, e);
                 }
                else if (excelExtention == ".xls")
                {
                    UPLOAD_EXCEL(sender, e);
            }
            else
            {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Incorrect file format.Upload file with .xlt/.xls extention');", true);
                }
                


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Please browse valid file to upload.')", true);


            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "btn_Upload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        //exportfile();
    }

    private void exportfile(string table_name)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView2.AllowPaging = false;

                BindGrid(table_name);

                GridView2.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "exportfile", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }
    protected void btn_Download_Click(object sender, EventArgs e)
    {

        try
        {
            //GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;

            //LinkButton lnkup = (LinkButton)gvRow.FindControl("btn_Download");

            //HiddenField hdf_kpiCode = (HiddenField)gvRow.FindControl("hdnKPI_CODE");
            htParam.Clear();
            dsResult.Clear();


            htParam.Add("@CMPNSTN_CODE", CMPNSTN_CODE);
            htParam.Add("@CNTSTNT_CODE", CNTSTNT_CODE);
            htParam.Add("@RULE_SET_KEY", RuleSet);
            htParam.Add("@ACCR_CYCLE", AccCycle);
            htParam.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            dsResult.Clear();
            // string table_name = null;
            dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_GetImportdataFile", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                   // table_name = dsResult.Tables[0].Rows[0];




                    ExportCSV(dsResult.Tables[0], "SampledataFile");
                    //BindGrid(table_name);
                    //exportfile(table_name);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Table name not found')", true);
            }


        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "btn_Download_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return Rest;


    }
    private void BindGrid(string table_name)
    {
        try
        {

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM " + table_name))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Dispose();
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        //cmd.Dispose();
                        using (DataTable dt = new DataTable())
                        {
                            dt.Clear();
                            sda.Fill(dt);

                            GridView2.DataSource = dt;
                            GridView2.DataBind();

                            //dvexport.Visible = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    #region UPLOAD_EXCEL
    protected void UPLOAD_EXCEL(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;

            LinkButton lnkup = (LinkButton)gvRow.FindControl("btn_Upload");
            FileUpload FileUpload1 = (FileUpload)gvRow.FindControl("FileUpload");
            Label lblCNTSTNT_CODE = (Label)gvRow.FindControl("lblCNTSTNT_CODE");
            HiddenField hdf_kpiCode = (HiddenField)gvRow.FindControl("hdnKPI_CODE");


            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", CNTSTNT_CODE);
            htParam.Add("@KPI_CODE", Convert.ToString(hdf_kpiCode.Value));
            dsResult.Clear();

            dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_HybridKPIImport", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    //string value=dsResult.Tables[0]["DB_TBL_FINAL"];
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('" + dsResult.Tables[0] + "');", true); 


                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Table name not found')", true);
            }

            if (FileUpload1.HasFile)
            {


                string excelExtention = string.Empty;
                excelExtention = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Incorrect file format.Upload file with .xlt extention');", true);


                    if (!Convert.IsDBNull(FileUpload1.PostedFile) & FileUpload1.PostedFile.ContentLength > 0)
                    {



                        //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.

                        string strfile = Server.MapPath(".") + "\\" + FileUpload1.FileName.ToString();
                        FileUpload1.SaveAs(Server.MapPath(".") + "\\" + FileUpload1.FileName);
                        //FileUpload.SaveAs("E:\ajay\practice\importExcel\\" + FileUpload.FileName);  
                        SqlBulkCopy oSqlBulk = null;


                        OleDbConnection myExcelConn;
                        string strConnectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strfile + ";Extended Properties=\"Excel 8.0;IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;FMT=Delimited;\"";

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

                        OleDbDataAdapter Da = new OleDbDataAdapter(objOleDB);
                        DataSet dsTempColm = new DataSet();
                        Da.Fill(dsTempColm);
                        DataSet dsMastrColm = new DataSet();
                        Hashtable HT = new Hashtable();
                        HT.Clear();
                        dsMastrColm = objDAL.GetDataSetForPrc_SAIM("prc_GetBulkUploadExcelColumn", HT);
                        if (dsTempColm.Tables[0].Rows.Count < 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No record in the file to upload.');", true);
                            strColumnError = "1";
                        }
                        else if (!dsTempColm.Tables[0].Columns.Count.Equals(dsMastrColm.Tables[0].Rows.Count))
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Excel columns are not valid');", true);
                            strColumnError = "1";
                        }
                        else if (dsTempColm.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsTempColm.Tables[0].Rows.Count; i++)
                            {
                                for (int j = 0; j < dsMastrColm.Tables[0].Rows.Count; j++)
                                {
                                    if (dsTempColm.Tables[0].Rows[i][dsMastrColm.Tables[0].Rows[j]["EXCEL_COL"].ToString()].Equals(DBNull.Value))
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('All fields are mandaory');", true);
                                        strColumnError = "1";
                                    }
                                }
                            }


                        }
                        if (strColumnError == "")
                        {
                            try
                            {  // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                                OleDbDataReader objBulkReader = null;
                                objBulkReader = objOleDB.ExecuteReader();
                                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString()))
                                {

                                    con.Open();

                                    // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                    oSqlBulk = new SqlBulkCopy(con);
                                    oSqlBulk.ColumnMappings.Add("CYCLE_CODE", "CYCLE_CODE");
                                    oSqlBulk.ColumnMappings.Add("CMPNSTN_CODE", "CMPNSTN_CODE");
                                    oSqlBulk.ColumnMappings.Add("CNTSTN_CODE", "CNTSTN_CODE");
                                    oSqlBulk.ColumnMappings.Add("MEM_CODE", "MEM_CODE");
                                    oSqlBulk.ColumnMappings.Add("HEALTH_CNT", "HEALTH_CNT");
                                    oSqlBulk.ColumnMappings.Add("RULE_SET_KEY", "RULE_SET_KEY");
                                    oSqlBulk.ColumnMappings.Add("TRANSACTION_DATE", "TRANSACTION_DATE");
                                    oSqlBulk.ColumnMappings.Add("CREATED_BY", "CREATED_BY");
                                    oSqlBulk.DestinationTableName = "UPLOAD_SHEALTH_CHK"; //dsResult.Tables[0].Rows[0]["DB_TBL_FINAL"].ToString(); //table name
                                    oSqlBulk.WriteToServer(objBulkReader);

                                    DataSet dsValidate = new DataSet();
                                    Hashtable htValidate = new Hashtable();
                                    htValidate.Clear();
                                    dsValidate.Clear();
                                    dsValidate = objDAL.GetDataSetForPrc_SAIM("Prc_ValidateDataType", htValidate);
                                    if (dsValidate.Tables.Count > 0)
                                    {
                                        if (dsValidate.Tables[0].Rows.Count > 0 || dsValidate.Tables[0].Rows.Count == 0 || dsValidate.Tables.Count == 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", string.Format("alert('Excel is not valid, {0}.');", dsValidate.Tables[0].Rows[0]["ErrMsg"].ToString()), true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('DATA IMPORTED SUCCESSFULLY.');", true);
                                    }
                                }
                            }


                            catch (Exception ex)
                            {

                                // lblConfirm.Text = ex.Message;
                                //lblConfirm.Attributes.Add("style", "color:red");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('DATA NOT IMPORTED.  '" + ex.Message + ");", true);
                            }
                            finally
                            {
                                // CLEAR.
                                oSqlBulk.Close();
                                oSqlBulk = null;
                                myExcelConn.Close();
                                myExcelConn = null;
                            }
                        }

                    }
                
                



            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Please browse valid file to upload.')", true);


            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatchHybrid", "UPLOAD_EXCEL", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    #endregion


}
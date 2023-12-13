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

public partial class Application_Isys_Saim_PopBulkCatgUpd : BaseClass
{
    #region DECLARE VARIABLES

    string CMPNSTN_CODE = string.Empty;

    string CNTSTNT_CODE = string.Empty;

    string RuleSet = string.Empty;

    string AccCycle = string.Empty;
    string table_name = null;
    string strColumnError = string.Empty;
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    private multilingualManager olng;
    private DataAccessClass dataAccess = new DataAccessClass();
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
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

            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE",  Request.QueryString["cnstCode"].ToString().Trim());
            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSet"].ToString().Trim());
           // htParam.Add("@CategoryCode", Request.QueryString["RuleSet"].ToString().Trim());

           // htParam.Add("@ACCR_CYCLE", AccCycle);
            htParam.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            dsResult.Clear();
            // string table_name = null;
            dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_GetSampleCatgFile", htParam);
            if (dsResult.Tables.Count > 0)
            {
                //if (dsResult.Tables[0].Rows.Count > 0)
                //{

                    // table_name = dsResult.Tables[0].Rows[0];




                    ExportCSV(dsResult.Tables[0], "SampledataFile");
                    //BindGrid(table_name);
                    //exportfile(table_name);

               // }
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
            objErr.LogErr("ISYS-SAIM", "PopBulkCatgUpd", "btn_Download_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

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
            objErr.LogErr("ISYS-SAIM", "PopBulkCatgUpd", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return Rest;


    }



    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
           // GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;

          // FileUpload FileUpload1 = (FileUpload)gvRow.FindControl("FileUpload");
           // Label lblCNTSTNT_CODE = (Label)gvRow.FindControl("lblCNTSTNT_CODE");
            //HiddenField hdf_kpiCode = (HiddenField)gvRow.FindControl("hdnKPI_CODE");


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
            objErr.LogErr("ISYS-SAIM", "PopBulkCatgUpd", "btn_Upload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }


    #region UPLOAD_EXCEL
    protected void UPLOAD_EXCEL(object sender, EventArgs e)
    {
        try
        {
          

            //htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            //htParam.Add("@CNTSTNT_CODE", Request.QueryString["cnstCode"].ToString().Trim());
            //htParam.Add("@RuleSet", Request.QueryString["RuleSet"].ToString().Trim());
           


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

                    //OleDbDataAdapter Da = new OleDbDataAdapter(objOleDB);
                    //DataSet dsTempColm = new DataSet();
                    //Da.Fill(dsTempColm);
                    //DataSet dsMastrColm = new DataSet();
                    //Hashtable HT = new Hashtable();
                    //HT.Clear();
                    //dsMastrColm = objDAL.GetDataSetForPrc_SAIM("prc_GetBulkUploadExcelColumn", HT);
                    //if (dsTempColm.Tables[0].Rows.Count < 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('No record in the file to upload.');", true);
                    //    strColumnError = "1";
                    //}
                    //else if (!dsTempColm.Tables[0].Columns.Count.Equals(dsMastrColm.Tables[0].Rows.Count))
                    //{

                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Excel columns are not valid');", true);
                    //    strColumnError = "1";
                    //}
                    //else if (dsTempColm.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dsTempColm.Tables[0].Rows.Count; i++)
                    //    {
                    //        for (int j = 0; j < dsMastrColm.Tables[0].Rows.Count; j++)
                    //        {
                    //            if (dsTempColm.Tables[0].Rows[i][dsMastrColm.Tables[0].Rows[j]["EXCEL_COL"].ToString()].Equals(DBNull.Value))
                    //            {
                    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('All fields are mandaory');", true);
                    //                strColumnError = "1";
                    //            }
                    //        }
                    //    }


                    //}
                    //if (strColumnError == "")
                    //{
                        try
                        {  // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                            OleDbDataReader objBulkReader = null;
                            objBulkReader = objOleDB.ExecuteReader();
                            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAIMConnectionString"].ToString()))
                            {

                                con.Open();

                                // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                                oSqlBulk = new SqlBulkCopy(con);
                                oSqlBulk.ColumnMappings.Add("SeqNo", "SeqNo");
                                oSqlBulk.ColumnMappings.Add("CmstnCode", "CmstnCode");
                                oSqlBulk.ColumnMappings.Add("CntstCode", "CntstCode");
                                oSqlBulk.ColumnMappings.Add("RulSetCode", "RulSetCode");
                                oSqlBulk.ColumnMappings.Add("CategoryDesc", "CategoryDesc");
                                oSqlBulk.ColumnMappings.Add("RuleCode", "RuleCode");
                                oSqlBulk.ColumnMappings.Add("ACC_CYCLE", "ACC_CYCLE");
                                oSqlBulk.ColumnMappings.Add("WScore_From", "WScore_From");
                                oSqlBulk.ColumnMappings.Add("WScore_To", "WScore_To");


                                
                                //oSqlBulk.ColumnMappings.Add("RuleType", "RuleType");
                               
                                //oSqlBulk.ColumnMappings.Add("ParentCategoryCode", "ParentCategoryCode");
                             
                                //oSqlBulk.ColumnMappings.Add("IsParent", "IsParent");
                                //

                                 oSqlBulk.DestinationTableName = "Mst_RwdCatgCodeTemp"; //dsResult.Tables[0].Rows[0]["DB_TBL_FINAL"].ToString(); //table name
                                oSqlBulk.WriteToServer(objBulkReader);

                                //DataSet dsValidate = new DataSet();
                                //Hashtable htValidate = new Hashtable();
                                //htValidate.Clear();
                                //dsValidate.Clear();
                                //dsValidate = objDAL.GetDataSetForPrc_SAIM("Prc_ValidateDataType", htValidate);
                                //if (dsValidate.Tables.Count > 0)
                                //{
                                //    if (dsValidate.Tables[0].Rows.Count > 0 || dsValidate.Tables[0].Rows.Count == 0 || dsValidate.Tables.Count == 0)
                                //    {
                                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", string.Format("alert('Excel is not valid, {0}.');", dsValidate.Tables[0].Rows[0]["ErrMsg"].ToString()), true);
                                //    }
                                //}
                                //else
                                //{
                                    
                                //}
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


            htParam.Clear();

            dsResult.Clear();

            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CNTSTN_CODE", Request.QueryString["cnstCode"].ToString().Trim());
            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSet"].ToString().Trim());
            htParam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());

            dsResult = objDAL.GetDataSetForPrc_SAIM("Prc_BlkUploadCatg", htParam);
        
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('DATA IMPORTED SUCCESSFULLY.');", true);
            
         //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Please browse valid file to upload.')", true);
     

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBulkCatgUpd", "UPLOAD_EXCEL", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    #endregion


}
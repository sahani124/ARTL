using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

public partial class Application_Isys_Saim_Customisation_DownloadCSV : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    Hashtable htparam = new Hashtable();
    DataSet dsfill = new DataSet();
    DataSet dsResult = new DataSet();
    DataAccessClass objDAL = new DataAccessClass();
    StringBuilder sb = new StringBuilder();
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    StringBuilder sb3 = new StringBuilder();
    StringBuilder sb4 = new StringBuilder();
    Microsoft.Office.Interop.Excel.Application excel;
    Microsoft.Office.Interop.Excel.Workbook worKbooK;
    Microsoft.Office.Interop.Excel.Worksheet worksheet;
    Microsoft.Office.Interop.Excel.Range celLrangE;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["ACTSCHKEY"] != null && Request.QueryString["FLAG"] != null && Request.QueryString["FLAG"] == "PEN" && Request.QueryString["RANGE"] != null)
                {
                    fillPenData(Request.QueryString["ACTSCHKEY"].Trim().ToString(), Request.QueryString["RANGE"].Trim().ToString());
                }
                if (Request.QueryString["ACTSCHKEY"] != null && Request.QueryString["FLAG"] != null && Request.QueryString["FLAG"] == "UPD" && Request.QueryString["RANGE"] != null)
                {
                    fillUPDData(Request.QueryString["ACTSCHKEY"].Trim().ToString(), Request.QueryString["RANGE"].Trim().ToString());
                }
            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
    }

    public void fillPenData(string ACT_SCH_KEY,string RANGE)
    {
        DataAccessClass objDal = new DataAccessClass();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Clear();
        ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
        if (RANGE == "N")
        {
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GETPenMPLData_BKP", ht);
        }
        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GETWORNGPenMPLData", ht);
        }
        //ds = objDal.GetDataSetForPrc_SAIM("PRC_GETPenMPLData_BKP", ht);
        ExportCSV(ds.Tables[0], "PendingData");
    }

    public void fillUPDData(string ACT_SCH_KEY, string RANGE)
    {
        DataAccessClass objDal = new DataAccessClass();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Clear();
        ht.Add("@ACT_SCHM_KEY", ACT_SCH_KEY);
        if (RANGE == "N")
        {
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_DATA_BKP2", ht);
        }
        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GETWORNGUpdMPLData", ht);
        }
        //ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_DATA_BKP2", ht);
        ExportCSV(ds.Tables[1], "UpdatedData");
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
            throw ex;
        }

        return Rest;
    }
}
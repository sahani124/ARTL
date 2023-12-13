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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Drawing;
using System.Text;
using CLTMGR;
using DataAccessClassDAL;
using System.IO;
using System.IO.Compression;
using Ionic.Zlib;
using Ionic.Zip;
using Microsoft.SqlServer;
using System.Reflection;

 
public partial class Application_INSC_Recruit_TestEnabling : BaseClass
{
    
    private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
    private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
    private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
    private static Microsoft.Office.Interop.Excel.Application oXL;

    #region Page Declaration
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    SqlConnection sqlCon;
    string ConnectionString;
    SqlCommand cmd;
    string strSQL = "";
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    DataSet dsExport = new DataSet();
    DataTable dtResult = new DataTable();
    DataSet dsResult = new DataSet();
    DataSet dsRes = new DataSet();
    string strBatchId = string.Empty;
    string strDwnld = string.Empty;
    String strTblName = string.Empty;
    string strTblHstName = string.Empty;
    Hashtable htFlag = new Hashtable();
    string strValue = string.Empty;
    string strTrn = "1";
    string strdata = string.Empty;
    string strFilePath = string.Empty;
    string strPhoto = string.Empty;
    string strCndNo = string.Empty;
    string strSign = string.Empty;
    string strBatchPath = string.Empty;
    StringBuilder sbCndNo = new StringBuilder();
    StringBuilder sbPhoto = new StringBuilder();
    StringBuilder sbSign = new StringBuilder();
    string strPhotos = string.Empty;
    string strCndNos = string.Empty;
    string strSigns = string.Empty;
    string strPhotoPath = string.Empty;
    string strPhotoPath1 = string.Empty;
    string strSignPath = string.Empty;
    string strSignPath1 = string.Empty;
    string strFormat = string.Empty;

    string strPath = System.Configuration.ConfigurationManager.AppSettings["DownloadExcel"].ToString();
    String ModuleID = string.Empty;//Added by usha on 25.06.2021
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)    
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
            hdnModuleId.Value = ModuleID;
            if (!IsPostBack)
            {
               // txtPage.Text = "1";
                PopulateDRFType();
                //BindDataGrid();
                chkfiledwnld.Visible = false;
                //divbtnExport.Visible = false;
                //divBtnConfirm.Visible = false;
                //divBtnFail.Visible = false;

                btnExport.Visible = false;
                btncnfrm.Visible = false;
                btnfail.Visible = false;
            }
            btndwnld.Attributes.Add("onclick", "javascript:return StartProgressBar()");
            //lblMessage.Text = "";
            //chkfiledwnld.Visible = false;
            //btnExport.Visible = false;
            //btncnfrm.Visible = false;
            //btnfail.Visible = false;
            

            if (hdnEnbl.Value == "1")
            {
                if (chkfiledwnld.Checked == true)
                {
                    btncnfrm.Visible = true;
                    btnfail.Visible = true;


                    //divBtnConfirm.Visible = true;
                    //divBtnFail.Visible = true;
                }
                else
                {
                    btncnfrm.Visible = false;
                    btnfail.Visible = false;
                    //divBtnConfirm.Visible = false;
                    //divBtnFail.Visible = false;
                }
                hdnEnbl.Value = "0";
                btnExport.Visible = true;
                //divbtnExport.Visible = true;

                chkfiledwnld.Visible = true;
                chkfiledwnld.Enabled = true;
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

            throw (ex);
        }
    }
    #endregion

    #region PopulateDRFType
    private void PopulateDRFType()
    {
        //getDRFDoc(ddlUpload, "");
        //ddlUpload.Items.Insert(0, "Select");
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@UserId", Session["UserID"].ToString());
        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDRFDocName", htParam);
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

    #region Set Excel File
    protected void SetExcelFile()
    {
        string attachment = "attachment; filename=Sheet1.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/Microsoft Excel 97- Excel 2008 & 5.0/95 Workbook";      
    }
    #endregion

    #region button Export
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH323')", true);
            chkfiledwnld.Visible = true;
            btncnfrm.Visible = true;
            btnfail.Visible = true;
            btncnfrm.Enabled = false;
            //btncnfrm.CssClass = "btn btn-xs btn-primary disabled";
            btnfail.Enabled = false;

            htParam.Clear();
            dsExport.Clear();
            dsRes.Clear();
            if ((ddlUpload.SelectedItem.Value == "DTRNATI") || (ddlUpload.SelectedItem.Value == "DTRNTCC"))
            {
                htParam.Add("@TrnInst", ddlTrnInst.SelectedItem.Value.ToString().Trim());
            }
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            //dsExport = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetSAPCode", htParam);
            dsExport = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDwnldRecord", htParam);
            DataSet dsPS = new DataSet();
            Hashtable htps = new Hashtable();
            if ((ddlUpload.SelectedItem.Value == "DPRFL") || (ddlUpload.SelectedItem.Value == "DRETPRFL"))
            {
                if (dsExport.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsExport.Tables[0].Rows.Count; i++)
                    {
                        sbCndNo.Append(dsExport.Tables[0].Rows[i]["Candidate No"].ToString().Trim());
                        sbCndNo.Append(",");

                    }

                    strCndNos = sbCndNo.ToString().Trim();


                    strCndNos = strCndNos.Substring(0, strCndNos.Length - 1);

                }
                // string strCndno = dsExport.Tables[0].Rows[i]["Candidate No"].ToString().Trim();
                if (ddlUpload.SelectedItem.Value == "DPRFL")
                {

                    htps.Add("@Flag", "1");
                    htps.Add("@CndNo", strCndNos);
                }
                else
                {
                    htps.Add("@CndNo", strCndNos);
                }
                dsPS = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetPhotoSignature", htps);

            }
            if (dsExport.Tables[0].Rows.Count > 0)
            {
                // string filename = "DownloadExcel.xls";
                htParam.Clear();
                htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                htParam.Add("@Flag", "1");
                String name = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetDownDocName", htParam, "@TblName");
                string filename;
                    //Added by usha  for IIB 
                   if (ddlUpload.SelectedValue.ToString().Trim() == "IIBDSPNSHP")
                {
                    filename = name + "_Form_Bulk_Upload";
                }
                else
                {
                    filename = name + "_Form_Bulk_Upload.xls";
                }
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                if (ddlUpload.SelectedValue.ToString().Trim() == "DSPNSHP")
                {
                    dgGrid.DataSource = dsExport.Tables[1];
                }
                else
                {
                    dgGrid.DataSource = dsExport.Tables[0];
                }
                //dgGrid.DataSource = dsExport.Tables[0];
                dgGrid.DataBind();

                dgGrid.RenderControl(hw);
                string renderedGridView = tw.ToString();

                htFlag.Clear();
                dsRes.Clear();
                htFlag.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                strFormat = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("prc_GetDwnldFormat", htFlag, "@Format");
                Hashtable htParamDwnld = new Hashtable();
                DataSet dsDwnld = new DataSet();
                htParamDwnld.Add("@BatchId", hdnBatchId.Value);


                htParamDwnld.Add("@ExprtBy", Session["UserID"].ToString());
                htParamDwnld.Add("@Flag", "2");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH765111')", true);
                dsDwnld = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_DECLog", htParamDwnld);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH99923')", true);
                if (strFormat == "Zip Format")
                {
                    if (Directory.Exists(strPath) == false)
                    {
                        strBatchPath = strPath + hdnBatchId.Value.Trim();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH1')", true);
                        Directory.CreateDirectory(strBatchPath);


                        //strPhoto = strPath + "Photo";
                        //Directory.CreateDirectory(strPhoto);

                        //strSign = strPath + "Signature";
                        //Directory.CreateDirectory(strSign);
                    }
                    else
                    {
                        strFilePath = strPath + hdnBatchId.Value.Trim();
                        //if (!Directory.Exists(Server.MapPath(strFilePath)))
                        if (!Directory.Exists(strFilePath))
                        {
                            // Directory.CreateDirectory(Server.MapPath(strFilePath));
                            Directory.CreateDirectory(strFilePath);

                            if (Directory.Exists(strFilePath))
                            {
                                strPhoto = strFilePath + "\\" + "Photo";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH2')", true);
                                Directory.CreateDirectory(strPhoto);

                                strSign = strFilePath + "\\" + "Signature";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH3')", true);
                                Directory.CreateDirectory(strSign);
                            }
                        }
                        else
                        {
                            strFilePath = strPath + hdnBatchId.Value.Trim();
                            strPhoto = strFilePath + "\\" + "Photo";
                            strSign = strFilePath + "\\" + "Signature";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH4')", true);
                        }
                    }

                    //System.IO.File.WriteAllText(@"D:\DownloadExcelDwnld\ExportedFile.xls", renderedGridView);
                    //Added by pranjali for IRDA Direct Excel upload start
                    if (ddlUpload.SelectedValue.ToString().Trim() == "DSPNSHP")
                    {
                        //uncoment by usha for File comparation on 31.01.2018
                        //    string path = @"D:\IsysSuiteRHIC\Isyssuite\Application\Isys\Recruit\IRDAExcelDownloadFormat\Sponsorship_Form_Bulk_Upload1.xls";
                        //    //  string path = @"D:\RHIC TFS\RHIC with old 09.11.2011\Isyssuite\Application\Isys\Recruit\IRDAExcelDownloadFormat\Sponsorship_Form_Bulk_Upload1.xls";

                        //    oXL = new Microsoft.Office.Interop.Excel.Application();
                        //    //oXL.Visible = true;
                        //    oXL.DisplayAlerts = false;
                        //    mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                        //    //Get all the sheets in the workbook
                        //    mWorkSheets = mWorkBook.Worksheets;
                        //    //Get the allready exists sheet
                        //    mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
                        //    Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
                        //    int colCount = range.Columns.Count;
                        //    int rowCount = range.Rows.Count;
                        //    int Ctr = 0;
                        //    int CtrTblCnt = 2;// 2- From 2nd Row we have to update the record
                        //    //CtrTblCnt = dsExport.Tables[1].Rows.Count;
                        //    while (dsExport.Tables[1].Rows.Count > Ctr)
                        //    {
                        //        mWSheet1.Cells[CtrTblCnt, 1] = dsExport.Tables[1].Rows[Ctr][0].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 2] = dsExport.Tables[1].Rows[Ctr][1].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 3] = dsExport.Tables[1].Rows[Ctr][2].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 4] = dsExport.Tables[1].Rows[Ctr][3].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 5] = dsExport.Tables[1].Rows[Ctr][4].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 6] = dsExport.Tables[1].Rows[Ctr][5].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 7] = dsExport.Tables[1].Rows[Ctr][6].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 8] = dsExport.Tables[1].Rows[Ctr][7].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 9] = dsExport.Tables[1].Rows[Ctr][8].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 10] = dsExport.Tables[1].Rows[Ctr][9].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 11] = dsExport.Tables[1].Rows[Ctr][10].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 12] = dsExport.Tables[1].Rows[Ctr][11].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 13] = dsExport.Tables[1].Rows[Ctr][12].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 14] = dsExport.Tables[1].Rows[Ctr][13].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 15] = dsExport.Tables[1].Rows[Ctr][14].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 16] = dsExport.Tables[1].Rows[Ctr][15].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 17] = dsExport.Tables[1].Rows[Ctr][16].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 18] = dsExport.Tables[1].Rows[Ctr][17].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 19] = dsExport.Tables[1].Rows[Ctr][18].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 20] = dsExport.Tables[1].Rows[Ctr][19].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 21] = dsExport.Tables[1].Rows[Ctr][20].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 22] = dsExport.Tables[1].Rows[Ctr][21].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 23] = dsExport.Tables[1].Rows[Ctr][22].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 24] = dsExport.Tables[1].Rows[Ctr][23].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 25] = dsExport.Tables[1].Rows[Ctr][24].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 26] = dsExport.Tables[1].Rows[Ctr][25].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 27] = dsExport.Tables[1].Rows[Ctr][26].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 28] = dsExport.Tables[1].Rows[Ctr][27].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 29] = dsExport.Tables[1].Rows[Ctr][28].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 30] = dsExport.Tables[1].Rows[Ctr][29].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 31] = dsExport.Tables[1].Rows[Ctr][30].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 32] = dsExport.Tables[1].Rows[Ctr][31].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 33] = dsExport.Tables[1].Rows[Ctr][32].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 34] = dsExport.Tables[1].Rows[Ctr][33].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 35] = dsExport.Tables[1].Rows[Ctr][34].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 36] = dsExport.Tables[1].Rows[Ctr][35].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 37] = dsExport.Tables[1].Rows[Ctr][36].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 38] = dsExport.Tables[1].Rows[Ctr][37].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 39] = dsExport.Tables[1].Rows[Ctr][38].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 40] = dsExport.Tables[1].Rows[Ctr][39].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 41] = dsExport.Tables[1].Rows[Ctr][40].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 42] = dsExport.Tables[1].Rows[Ctr][41].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 43] = dsExport.Tables[1].Rows[Ctr][42].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 44] = dsExport.Tables[1].Rows[Ctr][43].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 45] = dsExport.Tables[1].Rows[Ctr][44].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 46] = dsExport.Tables[1].Rows[Ctr][45].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 47] = dsExport.Tables[1].Rows[Ctr][46].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 48] = dsExport.Tables[1].Rows[Ctr][47].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 49] = dsExport.Tables[1].Rows[Ctr][48].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 50] = dsExport.Tables[1].Rows[Ctr][49].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 51] = dsExport.Tables[1].Rows[Ctr][50].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 52] = dsExport.Tables[1].Rows[Ctr][51].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 53] = dsExport.Tables[1].Rows[Ctr][52].ToString();
                        //        mWSheet1.Cells[CtrTblCnt, 54] = dsExport.Tables[1].Rows[Ctr][53].ToString();
                        //        Ctr = Ctr + 1;
                        //        CtrTblCnt = CtrTblCnt + 1;
                        //    }
                        //    string SaveAsPath = strFilePath + "\\" + filename;
                        //    mWorkBook.SaveAs(SaveAsPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                        //    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                        //    Missing.Value, Missing.Value, Missing.Value,
                        //    Missing.Value, Missing.Value);
                        //    mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
                        //    mWSheet1 = null;
                        //    mWorkBook = null;
                        //    oXL.Quit();
                        //    GC.WaitForPendingFinalizers();
                        //    GC.Collect();
                        //    GC.WaitForPendingFinalizers();
                        //    GC.Collect();
                        System.IO.File.WriteAllText(strFilePath + "\\" + filename, renderedGridView);
                    }
                       
                    else
                        {
                            //uncoment by usha for File comparation on 31.01.2018
                            System.IO.File.WriteAllText(strFilePath + "\\" + filename, renderedGridView);
                    }
                    // System.IO.File.WriteAllText(strFilePath + "\\" + filename, renderedGridView); //Commented by pranjali on 08-10-2014 for IRDA Excel download in Zip
                    //pranjali end
                    if ((ddlUpload.SelectedItem.Value == "DPRFL") || (ddlUpload.SelectedItem.Value == "DRETPRFL"))
                    {
                        if (dsPS.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < dsPS.Tables[0].Rows.Count; i++)
                            {
                                sbPhoto.Append(dsPS.Tables[0].Rows[i]["Photo File Name1"].ToString().Trim());
                                sbPhoto.Append(",");
                                sbSign.Append(dsPS.Tables[0].Rows[i]["Signature File Name1"].ToString().Trim());
                                sbSign.Append(",");
                            }

                            strPhotos = sbPhoto.ToString().Trim();
                            strSigns = sbSign.ToString().Trim();

                            strPhotos = strPhotos.Substring(0, strPhotos.Length - 1);
                            strSigns = strSigns.Substring(0, strSigns.Length - 1);

                        }
                    }
                    else
                    {

                        if (dsExport.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < dsExport.Tables[0].Rows.Count; i++)
                            {
                                sbPhoto.Append(dsExport.Tables[0].Rows[i]["Photo File Name"].ToString().Trim());
                                sbPhoto.Append(",");
                                sbSign.Append(dsExport.Tables[0].Rows[i]["Signature File Name"].ToString().Trim());
                                sbSign.Append(",");
                            }

                            strPhotos = sbPhoto.ToString().Trim();
                            strSigns = sbSign.ToString().Trim();

                            strPhotos = strPhotos.Substring(0, strPhotos.Length - 1);
                            strSigns = strSigns.Substring(0, strSigns.Length - 1);

                        }
                    }

                    strPhoto = strPhoto + "\\";
                    strSign = strSign + "\\";

                    htParam.Clear();
                    dsResult.Clear();
                    htParam.Add("@Photo", strPhotos.ToString());
                    htParam.Add("@Signature", strSigns.ToString());
                    if (ddlUpload.SelectedValue.ToString().Trim() != "DPRFL")
                    {
                        if (ddlUpload.SelectedValue.ToString().Trim() == "DRETPRFL")
                        {
                            htParam.Add("@Flag", "1");
                        }
                        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetImage", htParam);
                    }
                    else
                    {
                        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetImageForPrinter", htParam);
                    }


                    if ((ddlUpload.SelectedItem.Value == "DPRFL") || (ddlUpload.SelectedItem.Value == "DRETPRFL"))
                    {
                        if (dsResult.Tables.Count > 0)
                        {
                            for (int j = 0; j < dsResult.Tables.Count; j++)
                            {
                                if (dsResult.Tables[j].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsResult.Tables[j].Rows.Count; i++)
                                    {
                                        if (dsResult.Tables[j].Rows[i]["DocType"].ToString().Trim() == "Photo")
                                        {

                                            strPhotoPath = string.Empty;
                                            strPhotoPath1 = string.Empty;
                                            // ViewState[strPhotoPath1] = dsResult.Tables[j].Rows[i]["ServerFileName1"];
                                            strPhotoPath1 = dsResult.Tables[j].Rows[i]["UserFilename"] + "\\" + dsResult.Tables[j].Rows[i]["cndno"]
                                                + "\\" + dsResult.Tables[j].Rows[i]["ServerFileName"];
                                            strPhotoPath = strPhoto + dsResult.Tables[j].Rows[i]["ServerFileName1"];
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH323')", true);
                                            //ConvertImageToPdf(Server.MapPath("~/" + strPhotoPath1), Server.MapPath("~/" +strPhotoPath));
                                           //Added by usha for convert byte to image on 31.01.2018
                                          Byte[] bytes = (Byte[])dsResult.Tables[j].Rows[i]["Images"];
                                            ConvertImageToPdf(bytes, strPhotoPath, dsResult.Tables[j].Rows[i]["cndno"].ToString());
                                      
                                         //  ConvertImageToPdf(strPhotoPath1, strPhotoPath);
                                            // ConvertImageToPdf("http:\\localhost\\ISysSuite\\PdfExport\\30000964\\30000964_10.JPG", "http:\\localhost\\ISysSuite\\PdfExport\\30000964_10.pdf");

                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH687687')", true);

                                        }
                                        else if (dsResult.Tables[j].Rows[i]["DocType"].ToString().Trim() == "Signature")
                                        {
                                            strSignPath = string.Empty;

                                            strSignPath1 = string.Empty;

                                            strSignPath1 = dsResult.Tables[j].Rows[i]["UserFilename"] + "\\" + dsResult.Tables[j].Rows[i]["cndno"] 
                                                + "\\" + dsResult.Tables[j].Rows[i]["ServerFileName"];
                                            strSignPath = strSign + dsResult.Tables[j].Rows[i]["ServerFileName1"];
                                            Byte[] bytes = (Byte[])dsResult.Tables[j].Rows[i]["Images"];
                                            ConvertImageToPdf(bytes, strSignPath, dsResult.Tables[j].Rows[i]["cndno"].ToString());
                                         // ConvertImageToPdf(strSignPath1, strSignPath);
                                            //ConvertImageToPdf(Server.MapPath("~/" + strSignPath1), Server.MapPath("~/" + strSignPath));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dsResult.Tables.Count > 0)
                        {
                            for (int j = 0; j < dsResult.Tables.Count; j++)
                            {
                                if (dsResult.Tables[j].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsResult.Tables[j].Rows.Count; i++)
                                    {
                                        if (dsResult.Tables[j].Rows[i]["DocType"].ToString().Trim() == "Photo")
                                        {
                                            strPhotoPath = string.Empty;
                                            strPhotoPath = strPhoto + dsResult.Tables[j].Rows[i]["ServerFileName"];
                                            FileInfo fi = new FileInfo(strPhotoPath);
                                            using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                                            {
                                                Byte[] bytes = (Byte[])dsResult.Tables[j].Rows[i]["Images"];
                                                fileStream.Write(bytes, 0, bytes.Length);
                                            }
                                        }
                                        else if (dsResult.Tables[j].Rows[i]["DocType"].ToString().Trim() == "Signature")
                                        {
                                            strSignPath = string.Empty;
                                            strSignPath = strSign + dsResult.Tables[j].Rows[i]["ServerFileName"];
                                            FileInfo fi = new FileInfo(strSignPath);
                                            using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                                            {
                                                Byte[] bytes = (Byte[])dsResult.Tables[j].Rows[i]["Images"];
                                                fileStream.Write(bytes, 0, bytes.Length);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    using (ZipFile zip = new ZipFile())
                    {
                        //zip.UseUnicodeAsNecessary = true;  // utf-8

                        zip.AddDirectory(strFilePath);

                        zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                        //zip.Save("D:\\DownloadExcelDwnld\\" + hdnBatchId.Value.Trim() + ".zip");
                        zip.Save(strPath + hdnBatchId.Value.Trim() + ".zip");
                    }

                    //using (ZipFile zip = new ZipFile())
                    //{
                    //    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    //    //zip.AddDirectoryByName("Files");
                    //    //zip.AddFile(strPath, "Files");
                    //    zip.AddDirectory(strFilePath);

                    //    Response.Clear();
                    //    Response.BufferOutput = false;
                    //    string zipName = hdnBatchId.Value.Trim() + ".zip";
                    //   // Response.ContentType = "application/zip";
                    //    //Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    //    zip.Save(strPath + hdnBatchId.Value.Trim() + ".zip");
                    //    //Response.Flush();
                    //    //zip.Save(Response.OutputStream);
                    //   // Response.End();
                    //}

                    //string filename1 = Server.MapPath("../Application/Isys/Recruit/UploadedFiles");
                   string filename1 = System.IO.Path.GetFullPath(strPath + hdnBatchId.Value.Trim() + ".zip");
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename1);

                    if (fileInfo.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.Flush();
                        Response.TransmitFile(fileInfo.FullName);
                        // Response.End();
                    }
                }
                else if (strFormat == "Excel Format")
                {

                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.Flush();
                    Response.End();
                }
                    //Added by usha for IIB  on 14.02.2019
                else if (strFormat == "CSV Format")
                {
                    if (ddlUpload.SelectedValue.ToString().Trim() == "IIBDSPNSHP")
                    {
                        ExportCSV(dsExport.Tables[0], filename);
                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FINISH')", true);
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
        finally
        {
 
        }
    }
    public System.Drawing.Image ToImage(byte[] array)
    {
        System.Drawing.Image returnImage=null;
        MemoryStream ms = new MemoryStream(array);
        returnImage = System.Drawing.Image.FromStream(ms);
        return returnImage;
    }
    private void ConvertImageToPdf(byte[] strPhotoPath2, string strPhotoPath3,string cndno)
    {
        iTextSharp.text.Rectangle pageSize = null;
      //  if (Directory.Exists(strPath) == false)
       // {
          //  strPath = strPath + cndno;
          //  Directory.CreateDirectory(strPath);
       // }
        byte[] imagebytes = strPhotoPath2;
        //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagebytes);
      //0  var webclient=new webcl

        using (var srcImage = new Bitmap(ToImage(imagebytes)))
        {
          pageSize = new iTextSharp.text.Rectangle(0,0,srcImage.Width,srcImage.Height);
        }
        using (var ms = new MemoryStream())
        {
            var document = new iTextSharp.text.Document(pageSize, 0,0,0,0);
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms);
            document.Open();
           var image = iTextSharp.text.Image.GetInstance(imagebytes);
//    private void ConvertImageToPdf(string strPhotoPath2, string strPhotoPath3)
//    {
//        iTextSharp.text.Rectangle pageSize = null;
//
//      //0  var webclient=new webcl
//
//        using (var srcImage = new Bitmap(strPhotoPath2))
//        {
//            pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
//        }
//        using (var ms = new MemoryStream())
//        {
//            var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
//            iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
//            document.Open();
//            var image = iTextSharp.text.Image.GetInstance(strPhotoPath2);
            document.Add(image);
            document.Close();

            File.WriteAllBytes(strPhotoPath3, ms.ToArray());
        }
    }
    #endregion

    #region bind grid
    void BindDataGrid()
    {
        try
        {
            dtResult = GetDataTable();
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    trdgHdr.Visible = true;
                    trdg.Visible = true;
                    dgDownload.Visible = true;
                    dgDownload.DataSource = dtResult;
                    dgDownload.DataBind();
                    btnExport.Visible = true;
                   // divbtnExport.Visible = true;

                    chkfiledwnld.Visible = true;
                    lblMessage.Visible = false;
                  //  ShowPageInformation();
                    divSearchDetails.Attributes.Add("style", "display:block");
                }
                else
                {
                    trdgHdr.Visible = false;
                    trdg.Visible = false;
                    dgDownload.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    //trmsg.Visible = true;
                    divSearchDetails.Visible = false;
                    lblMessage.Visible = true;
                    btnExport.Visible = false;
                    btncnfrm.Visible = false;
                    btnfail.Visible = false;
                    //divBtnConfirm.Visible = false;
                    //divBtnFail.Visible = false;
                   // divbtnExport.Visible = false;
                    chkfiledwnld.Visible = false;
                    divSearchDetails.Attributes.Add("style", "display:none");
                }
            }
            else
            {
                trdgHdr.Visible = false;
                trdg.Visible = false;
                dgDownload.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                //trmsg.Visible = true;
                lblMessage.Visible = true;
                btnExport.Visible = false;
                btncnfrm.Visible = false;
                btnfail.Visible = false;
                //divBtnConfirm.Visible = false;
                //divBtnFail.Visible = false;
                //divbtnExport.Visible = false;

                chkfiledwnld.Visible = false;
                divSearchDetails.Attributes.Add("style", "display:none");
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region  dgDownload PageIndexChanging
    protected void dgDownload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;

            dgSource.PageIndex = e.NewPageIndex;


            dgSource.DataSource = dv;
            dgSource.DataBind();
            ShowPageInformation();
            btnExport.Visible = true;
            //divbtnExport.Visible = true;

            chkfiledwnld.Visible = true;
            if (chkfiledwnld.Checked == true)
            {
                btncnfrm.Visible = true;
                btnfail.Visible = true;
                //divBtnConfirm.Visible = true;
                //divBtnFail.Visible = true;

            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region GetDataTable()
    protected DataTable GetDataTable()
    {
        try
        {
            DataTable dtRes = new DataTable();
            DataSet dstable = new DataSet();
            htParam.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htParam.Add("@BatchId", hdnBatchId.Value);
            dstable = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetTmptoHst", htParam);
            if (dstable.Tables.Count > 0)
            {
                if (dstable.Tables[0].Rows.Count > 0)
                {
                    lblSearch.Text = ddlUpload.SelectedItem.Text.ToString();
                    trdgHdr.Visible = true;
                    trdg.Visible = true;
                    dgDownload.Visible = true;
                    dgDownload.DataSource = dstable.Tables[0];
                    dgDownload.DataBind();
                    //ShowPageInformation();
                    btnExport.Visible = true;
                    btncnfrm.Visible = true;
                    btnfail.Visible = true;
                    //trdgDetails.Visible = false;
                    btncan.Visible = false;
                    ViewState["grid"] = dstable.Tables[0];
                    if (dgDownload.PageCount > Convert.ToInt32(txtPage.Text))
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                    }
                    //divbtnExport.Visible = true;
                    btncan.Visible = false;
                    chkfiledwnld.Visible = true;
                    chkfiledwnld.Checked = false;
                    lblMessage.Visible = false;
                }
                else
                {
                    trdgHdr.Visible = false;
                    trdg.Visible = false;
                    dgDownload.Visible = false;
                    btnExport.Visible = false;
                    chkfiledwnld.Visible = false;
                    btncnfrm.Visible = false;
                    btnfail.Visible = false;
                    //divBtnConfirm.Visible = false;
                    //divBtnFail.Visible = false;
                    //divbtnExport.Visible = false;
                    trdgDetails.Visible = false;

                }
            }
            else
            {
                trdgHdr.Visible = false;
                trdg.Visible = false;
                dgDownload.Visible = false;
                btnExport.Visible = false;
                chkfiledwnld.Visible = false;
                btncnfrm.Visible = false;
                btnfail.Visible = false;
                trdgDetails.Visible = false;
                //divBtnConfirm.Visible = false;
                //divBtnFail.Visible = false;
                //divbtnExport.Visible = false;

            }
            return dstable.Tables[0];
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region grdSap Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgDownload.PageIndex + 1;
        lblPageInfo.Visible = true;
       // lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDownload.PageCount;
    }
    #endregion

    #region chkfiledwnld
    protected void chkfiledwnld_CheckedChanged(object sender, EventArgs e)
    {
        if (chkfiledwnld.Checked == true)
        {
            //divBtnConfirm.Visible = true;
            //divBtnFail.Visible = true;
            //divbtnExport.Visible = true;
            btncnfrm.Visible = true;
            btncnfrm.Enabled = true;
           // btncnfrm.CssClass = "btn btn-xs btn-primary";
            btnExport.Visible = true;
            chkfiledwnld.Visible = true;
            btnfail.Visible = true;
            btnfail.Enabled = true;
            //btnfail.CssClass = "btn btn-xs btn-primary";
        }
        else
        {
            btncnfrm.Visible = false;
            btncnfrm.Enabled = false;
            //btncnfrm.CssClass = "btn btn-xs btn-primary disabled";
            btnExport.Visible = true;
            chkfiledwnld.Visible = true;
            btnfail.Visible = false;
            //btnfail.CssClass = "btn btn-xs btn-primary disabled";
            btnfail.Enabled = false;
            //divBtnConfirm.Visible = false;
            //divBtnFail.Visible = false;
            //divbtnExport.Visible = true;
        }
    }
    #endregion

    #region button Fail
    protected void btnFail_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            dsRes = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetTrunctbl ", htParam);
            //ClientScript.RegisterStartupScript(typeof(Page), "popup", "<script type='text/javascript'>alert('Please extract excel again.');</script>", false);
            Response.Redirect("TestEnabling.aspx?ModuleID="+hdnModuleId.Value);
            //?id=" + IdOrHiddenField1.value    
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region button Confirm
    protected void btncnfrm_Click(object sender, EventArgs e)
    {
        try
        {
            //GET HIST TABLE NAME
            htFlag.Clear();
            htFlag.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htFlag.Add("@Flag", "2");
            strTblHstName = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetDwnldTblName", htFlag, "@TblName");

            //UPDATE HIST TABLE NAME TO UPLDQWNLDLOG
            dsRes.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htParam.Add("@BatchID", hdnBatchId.Value);
            dsRes = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_InsHstUpldDwnldLog", htParam);
            Hashtable htParamDwnld = new Hashtable();
            DataSet dsDwnld = new DataSet();
            htParamDwnld.Add("@BatchId", hdnBatchId.Value);

            htParamDwnld.Add("@ConfirmBy", Session["UserID"].ToString());
            htParamDwnld.Add("@Flag", "3");

            dsDwnld = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_DECLog", htParamDwnld);
            //MOVE DATA FROM TEMP TABLE TO HIST TABLE
            dsResult.Clear();
            dsRes.Clear();
            htParam.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
           htParam.Add("@BatchId", hdnBatchId.Value);// added by usha on 03.01.2018
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetHsttoTmp", htParam);

           

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
            {
                bulkCopy.DestinationTableName = strTblHstName;
                bulkCopy.WriteToServer(dsResult.Tables[0]);
            }

            htParam.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            dsRes = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetTrunctbl", htParam);

            string strBatchId = hdnBatchId.Value;
            lbl.Text = "Thank you for your confirmation.";
            lbl2.Text = "Note: Please keep the BatchId for future reference.";
            lbl3.Text= "BatchId: " + Server.HtmlEncode(strBatchId) + ".";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "modalpopup();", true);
            divSearchDetails.Visible = false;
            btnExport.Visible = false;
            chkfiledwnld.Visible = false;
            btncnfrm.Visible = false;
            btnfail.Visible = false;
            //divBtnConfirm.Visible = false;
            //divBtnFail.Visible = false;
            //divbtnExport.Visible = false;

            //UPDATE CND STATUS
            htParam.Clear();
            //dsResult.Clear(); comented by usha on 03.01.2017
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htParam.Add("@BatchID", hdnBatchId.Value);
            htParam.Add("@CreatedBy", Session["UserID"].ToString());
            htParam.Add("@Flag", "1");
            htParam.Add("@ModuleID", ModuleID);
            //dsRes = dataAccessRecruit.GetDataSetForPrcRecruitUpdDwnld("Prc_UpdateCndStatus", htParam);
            String strStatus = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_UpdateCndStatus", htParam, "@CndStatus");

            //added  by usha for syn log entery in CRM  03.01.2018
            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
            {
                if ((!dsResult.Tables[0].Columns.Contains("Insurer Ref No")))
                {

                    ObjTask.UpdateCndTask("", dsResult.Tables[0].Rows[i]["IRDA URN"].ToString());
                }
                else
                {
                    ObjTask.UpdateCndTask(dsResult.Tables[0].Rows[i]["Insurer Ref No"].ToString());
                }
            }
            // added  by usha for syn log entery in CRM 
            //RECORD DATA MOVEMENT
            htParam.Clear();
            htParam.Add("@CndStatus", strStatus);
            htParam.Add("@CreatedBy", Session["UserID"].ToString());
            htParam.Add("@Desc", ddlUpload.SelectedItem.Text.ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_InsCndStatusMvmt", htParam);

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            //throw (ex);
        }
    }
# endregion

    #region button Download
    protected void btndwnld_Click(object sender, EventArgs e)
    {
        try
        {
            divSearchDetails.Visible = true;
            dgDownload.DataSource = null;
            dgDownload.DataBind();

            
            if (ddlUpload.SelectedValue.ToString().Trim() == "Select")
            {
                strDwnld = "1";
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select Document type to download file.');</script>");
                divSearchDetails.Visible = false;
                ProgressBarModalPopupExtender.Hide();
            }

            else
            {
                if (strDwnld != "1")
                {
                    if ((ddlUpload.SelectedItem.Value == "DTRNATI") || (ddlUpload.SelectedItem.Value == "DTRNTCC"))
                    {
                        if (ddlTrnInst.SelectedValue.ToString().Trim() == "Select")
                        {
                            strTrn = "2";
                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select training institute to download file.');</script>");
                            divSearchDetails.Visible = false;
                        } 
                    }
                    if (strTrn == "1")
                    {
                        //GET TEMP TABLE NAME
                        htFlag.Clear();
                        htFlag.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                        htFlag.Add("@Flag", "1");
                        strTblName = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_GetDwnldTblName", htFlag, "@TblName");


                        //MOVE DATA TO TEMP TABLE
                        htParam.Clear();
                        dsResult.Clear();
                        dsRes.Clear();
                        if ((ddlUpload.SelectedItem.Value == "DTRNATI") || (ddlUpload.SelectedItem.Value == "DTRNTCC"))
                        {
                            htParam.Add("@TrnInst", ddlTrnInst.SelectedItem.Value.ToString().Trim());
                        }
                        htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDwnldRecord", htParam);
                        DataSet dsImgToPDF = new DataSet();
                        Hashtable htPDF = new Hashtable();
                        if ((ddlUpload.SelectedItem.Value == "DPRFL") || (ddlUpload.SelectedItem.Value == "DRETPRFL"))
                        {
                            if (dsResult.Tables.Count > 0)
                            {
                                for (int j = 0; j < dsResult.Tables.Count; j++)
                                {
                                    if (dsResult.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                                        {


                                            string strCndno = dsResult.Tables[0].Rows[i]["Candidate No"].ToString().Trim();
                                            string strPhotoPDF = strCndno + "_11.pdf";
                                            string strSignPDF = strCndno + "_12.pdf";
                                            htPDF.Clear();
                                            htPDF.Add("@CndNo", strCndno);//ImgToPDF
                                            htPDF.Add("@Photo", strPhotoPDF);
                                            htPDF.Add("@Signature", strSignPDF);
                                            // dsImgToPDF = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_ImgToPDF", htPDF);
                                            dsImgToPDF = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_ImgToPDF", htPDF);
                                        }
                                    }
                                }
                            }
                        
                        }
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                                {
                                    bulkCopy.DestinationTableName = strTblName;
                                    bulkCopy.WriteToServer(dsResult.Tables[0]);
                                }

                                //GET BATCHID
                                htParam.Clear();
                                htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                                strBatchId = dataAccessRecruit.execute_sprc_UpdDwnld_with_output("Prc_UpdtBatchId", htParam, "@Batch");
                                hdnBatchId.Value = strBatchId.Trim();
                                Hashtable htParamDwnld = new Hashtable();
                                DataSet dsDwnld = new DataSet();
                                htParamDwnld.Add("@BatchId", strBatchId);
                                htParamDwnld.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                                htParamDwnld.Add("@DwnldBy", Session["UserID"].ToString());
                                htParamDwnld.Add("@Flag", "1");

                                dsDwnld = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_DECLog", htParamDwnld);
                                strValue = "1";
                                hdncheck.Value = "1";
                                divSearchDetails.Attributes.Add("style", "display:block");
                            }
                            else
                            {
                                trdgHdr.Visible = false;
                                trdg.Visible = false;
                                lblMessage.Visible = true;
                                lblMessage.Text = "0 Record found";
                                btnExport.Visible = false;
                                btncnfrm.Visible = false;
                                chkfiledwnld.Visible = false;
                                btnfail.Visible = false;

                                //divBtnConfirm.Visible = false;
                                //divBtnFail.Visible = false;
                                //divbtnExport.Visible = false;
                                ProgressBarModalPopupExtender.Hide();
                                divSearchDetails.Attributes.Add("style", "display:none");
                            }
                        }
                        else
                        {
                            trdgHdr.Visible = false;
                            trdg.Visible = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record found";
                            btnExport.Visible = false;
                            btncnfrm.Visible = false;
                            chkfiledwnld.Visible = false;
                            btnfail.Visible = false;
                            //divBtnConfirm.Visible = false;
                            //divBtnFail.Visible = false;
                            //divbtnExport.Visible = false;
                            ProgressBarModalPopupExtender.Hide();
                            divSearchDetails.Attributes.Add("style", "display:none");
                        }


                        //INSERT ENTRY TO UPLDDWNLDLOG
                        if (strValue == "1")
                        {
                            htParam.Clear();
                            dsResult.Clear();

                            htParam.Add("@BatchID", strBatchId.ToString());
                            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                            htParam.Add("@UserId", Session["UserId"].ToString().Trim());
                            htParam.Add("@RecrdCnt", dsResult.Tables[0].Rows.Count.ToString());
                            htParam.Add("@Action", "Dwnld");
                            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_InsUpldDwnldLog", htParam);

                            BindDataGrid();
                            ProgressBarModalPopupExtender.Hide();
                        }
                        btncnfrm.Visible = false;
                       
                        btnfail.Visible = false;
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
            throw (ex);
        }
    }
    #endregion

    #region getDRFDoc
    public void getDRFDoc(DropDownList cbo, string LookupParamValue)
    {
        try
        {
            sqlCon = new SqlConnection(strconn);
            sqlCon.Open();

            //Retrieve data from database
            strSQL = "exec Prc_GetDRFDocName";
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
            throw (ex);
        }
    }
    #endregion

    #region ddlUpload_SelectedIndexChanged
    protected void ddlUpload_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        divSearchDetails.Visible = false;
        chkfiledwnld.Visible = false;
        btnExport.Visible = false;
        dgDownload.PageIndex = 0;
        btncnfrm.Visible = false;
        btnfail.Visible = false;
        //divBtnConfirm.Visible = false;
        //divBtnFail.Visible = false;
        //divbtnExport.Visible = false;



      if ((ddlUpload.SelectedItem.Value == "DTRNATI") || (ddlUpload.SelectedItem.Value == "DTRNTCC"))
      {
          ddlTrnInst.Visible = true;
          trATIDoc.Visible = true;
          lnkView.Visible = true;
          spnView.Visible = true;
          getTrnInst(ddlTrnInst, "");
          //ddlTrnInst.Items.Insert(0, "Select");
          ddlTrnInst.Items.Insert(0, "All");
      }
      else
      {
            ddlTrnInst.Visible = false;
            trATIDoc.Visible = false;
          lnkView.Visible = false;
          spnView.Visible = false;
      }

    }
    #endregion

    #region getATIDoc
    public void getTrnInst(DropDownList cbo, string LookupParamValue) 
    {
        try
        {
            sqlCon = new SqlConnection(strconn);
            sqlCon.Open();

            //Retrieve data from database
            strSQL = "exec Prc_GetTrnInstitude";
            cbo.DataTextField = "ParamDesc";
            cbo.DataValueField = "ParamValue";

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
            throw (ex);
        }
    }
    #endregion
    protected void GetDataTra()
    {
        dsResult.Clear();
      
        dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnldwithoutParam("prc_GetViewTrnDtl");
        if (dsResult.Tables[0].Rows.Count > 0)//table[0] for open status //table[1] for closed status
        {
            divSearchDetails.Attributes.Add("style", "display:block");
            trdg.Visible = false;
            dgDetails1.DataSource = dsResult.Tables[0];
            dgDetails1.DataBind();
            trdgDetails.Visible = true;
            btncan.Visible = true;
           
            if (dgDetails1.PageCount > Convert.ToInt32(txtTran.Text))
            {
                btnNexttran.Enabled = true;
            }
            else
            {
                btnNexttran.Enabled = false;
            }
            trdg.Visible = false;
        }
        else
        {
            divSearchDetails.Attributes.Add("style", "display:none");
            trdg.Visible = false;
            trdgDetails.Visible = false;
            btncan.Visible = false;
        }
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlTrnInst.SelectedValue.ToString().Trim() == "Select")
            {
                strTrn = "2";
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select training institute.');</script>");
                divSearchDetails.Visible = false;
            }
            else
            {
                // htParam.Clear();
                dsResult.Clear();
                //if (ddlTrnInst.SelectedItem.Value.ToString().Trim() == "All")
                //{
                //    htParam.Add("@Flag","1");
                //}
                //else
                //{
                //    htParam.Add("@Flag","2");
                //    htParam.Add("@TrnInst", ddlTrnInst.SelectedItem.Value.ToString().Trim());
                //}
                dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnldwithoutParam("prc_GetViewTrnDtl");
                if (dsResult.Tables[0].Rows.Count > 0)//table[0] for open status //table[1] for closed status
                {
                    dgDetails1.DataSource = dsResult.Tables[0];
                    dgDetails1.DataBind();
                    //trdgDetails.Visible = true;
                    //btncan.Visible = true;
                    ViewState["grid"] = dsResult.Tables[0];
                    if (dgDetails1.PageCount > Convert.ToInt32(txtTran.Text))
                    {
                        btnNexttran.Enabled = true;
                    }
                    else
                    {
                        btnNexttran.Enabled = false;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);

                }
                else {
                    //divSearchDetails.Attributes.Add("style", "display:none");
                    //trdg.Visible = false;
                    //trdgDetails.Visible = false;
                    //btncan.Visible = false;
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
    protected void ddlTrnInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        divSearchDetails.Visible = false;
        trdg.Visible = false;
        chkfiledwnld.Visible = false;
        btnExport.Visible = false;
        btncnfrm.Visible = false;
        btnfail.Visible = false;
        //divBtnConfirm.Visible = false;
        //divBtnFail.Visible = false;
        //divbtnExport.Visible = false;
        lblMessage.Text = "";
    }

    public iTextSharp.text.Rectangle pageSize { get; set; }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDownload.PageIndex;
            dgDownload.PageIndex = pageIndex - 1;
            GetDataTable();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDownload.PageIndex;
            dgDownload.PageIndex = pageIndex + 1;
            
            GetDataTable();
            
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = dgDownload.PageCount;
            if (txtPage.Text == Convert.ToString(dgDownload.PageCount))
            {
                btnnext.Enabled = false;
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
    protected void btnprevioustr_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails1.PageIndex;
            dgDetails1.PageIndex = pageIndex - 1;
            GetDataTra();
            txtTran.Text = Convert.ToString(Convert.ToInt32(txtTran.Text) - 1);
            if (txtTran.Text == "1")
            {
                btnPreTran.Enabled = false;
            }
            else
            {
                btnPreTran.Enabled = true;
            }
            btnNexttran.Enabled = true;
            divSearchDetails.Attributes.Add("style", "display:none");
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

    protected void btnnexttr_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails1.PageIndex;
            dgDetails1.PageIndex = pageIndex + 1;
            GetDataTra();

            txtTran.Text = Convert.ToString(Convert.ToInt32(txtTran.Text) + 1);
            btnPreTran.Enabled = true;
            int page = dgDetails1.PageCount;
            if (txtTran.Text == Convert.ToString(dgDetails1.PageCount))
            {
                btnNexttran.Enabled = false;
            }
            divSearchDetails.Attributes.Add("style", "display:none");
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


    //Added by usha   for CSV download 14.02.2019


    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;

        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.ContentType = "text/csv";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");



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
     
        return Rest;


    }

    protected void dgDownload_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
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
using Ionic.Zip;

public partial class Application_ISys_ChannelMgmt_LicWelcomeLetter : BaseClass
{
    #region declaration
    private multilingualManager olng;
    string Code;
    ErrLog objErr = new ErrLog();//Added by rachana on 10-12-2013 for error log
    public string strPath = "";//System.Configuration.ConfigurationManager.AppSettings["UploadImgPath2"].ToString();
    private string ZipFilePath = string.Empty;
    private string strFileName = string.Empty;
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsResult = new DataSet();
    DataTable dtResult = new DataTable();
    //EncodeDecode ObjDec = new EncodeDecode();
    Hashtable htable = new Hashtable();//Added by rachana on 26-11-2013 
    Hashtable htRprt = new Hashtable();
    DataSet dsRprt = new DataSet();

    #endregion
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "CndEnq.aspx", Session["UserLangNum"].ToString());
     
            if (!IsPostBack)
            {
                InitializeControl();
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds1);
            }

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "Page_Load()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

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
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "GetAgentandUserDtls()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    #region IntializeControl
    private void InitializeControl()
    {
        try
        {
            lbltitle.Text = "Member Search";
           
            
            lblFranName.Text = "Name";

            lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text"));
            lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));

            lblShwRecords1.Text = (olng.GetItemDesc("lblShwRecords.Text"));
            
            if (Request.QueryString["Type"] != null)
            {

                if (Request.QueryString["Type"].Trim() == "LicRnwl")
                {
                    
                }
            }

           
        }
        
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "InitializeControl()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion




    #region Button 'Search Click Event'
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindLICID();

        }

        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "btnNextPannel2_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void BindLICID()
    {
        try
        {
            GrdLicId.PageIndex = 0;
            
            dsRprt.Clear();
            //htRprt.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htRprt.Add("@MemCode", "");
            htRprt.Add("@EmpCode", txtFrenchCode.Text.ToString().Trim());
            htRprt.Add("@GivenName", txtGivenName.Text.ToString().Trim());
            htRprt.Add("@Surname", "");

            if (txtDTRegFrom.Text.Trim() != "")
            {
                htRprt.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htRprt.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htRprt.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htRprt.Add("@CreateToDtim ", System.DBNull.Value);
            }
            //htRprt.Add("@AgentBrokerCode", txtAgntBroker.Text);
            htRprt.Add("@SapCode", "");

            htRprt.Add("@UserId", Session["UserID"].ToString().Trim());

            //     htRprt.Add("@Flag", "1");
            dsRprt = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemWelcomeDownload", htRprt);
            //}
            if (dsRprt.Tables.Count > 0)
            {
                if (dsRprt.Tables[0].Rows.Count > 0)
                {
                    GrdLicId.DataSource = dsRprt.Tables[0];
                    GrdLicId.DataBind();
                    ViewState["grid"] = dsRprt.Tables[0];
                    if (GrdLicId.PageCount > Convert.ToInt32(txtLICId.Text))
                    {
                        btnNextLIC.Enabled = true;
                    }
                    else
                    {
                        btnNextLIC.Enabled = false;
                    }
                    Session["dtRPrt"] = dsRprt.Tables[0];
                    //trnote.Visible =true;
                    trLICId.Visible = true;
                    tr31.Visible = true;
                    // trLICId.Attributes.Add("style", "display:block");
                    
                }
                else
                {
                    GrdLicId.DataSource = null;
                    GrdLicId.DataBind();
                    GrdLicId.Visible = false;
                }
            }
            else
            {
                GrdLicId.DataSource = null;
                GrdLicId.DataBind();
                //trnote.Visible = false;
            }
            dsRprt = null;
            Session["dtRprt"] = null;

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "BindLICID()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void GrdLicId_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            ////For Pagination of Search Grid
            //DataTable dt = GetDatatableForLICCpyandID();
            //DataView dv = new DataView(dt);
            //GridView dgSource = (GridView)sender;
            //dgSource.PageIndex = e.NewPageIndex;
            //dv.Sort = dgSource.Attributes["SortExpression"];
            //if (dgSource.Attributes["SortASC"] == "No")
            //{
            //    dv.Sort += " DESC";
            //}
            //dgSource.DataSource = dv;
            //dgSource.DataBind();
          
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "GrdLicId_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //added by Nikhil for License & ID Download on 18042015---start
    protected void GrdLicId_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FPWelcmLttr")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
        else if (e.CommandName == "ID")
        {
            string ReportType = e.CommandName;
            GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblstatus1 = (Label)row1.FindControl("lblCnd");

            Hashtable htParam = new Hashtable();
            htParam.Add("@CndNo", lblstatus1.Text);
            htParam.Add("@Src", ReportType);
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            dataAccessRecruit.execute_sprcrecruit("Prc_InsTblLicIDLog", htParam);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funReport('" + e.CommandArgument.ToString().Trim() + "','" + ReportType + "');", true);
        }
    }

    protected void GrdLicId_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            //GridView dgSource = (GridView)sender;
            //string strSort = string.Empty;
            //string strASC = string.Empty;
            //if (dgSource.Attributes["SortExpression"] != null)
            //{
            //    strSort = dgSource.Attributes["SortExpression"].ToString();
            //}
            //if (dgSource.Attributes["SortASC"] != null)
            //{
            //    strASC = dgSource.Attributes["SortASC"].ToString();
            //}

            //dgSource.Attributes["SortExpression"] = e.SortExpression;
            //dgSource.Attributes["SortASC"] = "Yes";

            //if (e.SortExpression == strSort)
            //{
            //    if (strASC == "Yes")
            //    {
            //        dgSource.Attributes["SortASC"] = "No";
            //    }
            //    else
            //    {
            //        dgSource.Attributes["SortASC"] = "Yes";
            //    }
            //}

            //DataTable dt = GetDataTable();
            //DataView dv = new DataView(dt);
            //dv.Sort = dgSource.Attributes["SortExpression"];

            //if (dgSource.Attributes["SortASC"] == "No")
            //{
            //    dv.Sort += " DESC";
            //}

            //dgSource.PageIndex = 0;
            //dgSource.DataSource = dv;
            //dgSource.DataBind();
            //ShowPageInformationCndStatus();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-RGIC", "LicWelcomeLetter.aspx.cs", "GrdLicId_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlShwRecrds1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds1.SelectedValue != null)
        {
           // BindDataGrid();
        }
    }


   

    protected void btnPreLIC_Click(object sender, EventArgs e)
    {

    }

    protected void btnNextLIC_Click(object sender, EventArgs e)
    {

    }

    protected void btnDwnld_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GrdLicId.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("ChkAssigned");
            Label lblMemCode = (Label)row.FindControl("lblMemcode");
            string MemCode = lblMemCode.Text.ToString().Trim();
            if (chkSelect.Checked == true)
            {
                if(MemCode != null && MemCode != "")
                {
                    //DownLoadZip(MemCode);
                    //BtnDwnldAll(MemCode);
                    BtnDwnldAll_Click();
                }
                else
                {

                }


            }
        }
    }
    public  void DownLoadZip(string MemCode)
    {
        try
        {

          
            DataSet dsResult = new DataSet();
            Hashtable htAll = new Hashtable();
            ZipFilePath = strPath;
            dsResult.Clear();
            htAll.Clear();

            htAll.Add("@memcode", "40086494"); //Request.QueryString["CndNo"].ToString()
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FrnImgBytes", htAll);
   
            if (dsResult.Tables.Count > 0)
            {
                strPath = strPath + "40086494";
                Directory.CreateDirectory(strPath);
                byte[] bytes = (byte[])dsResult.Tables[0].Rows[0]["Images"];
                strFileName = strPath + "\\" + dsResult.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                FileInfo fi = new FileInfo(strFileName);
                using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    FileStream.Write(bytes, 0, bytes.Length);
                }
                       
                   
                }

                //ZipFilePath = ZipFilePath + String.Format("{0}.zip", "40086494");// DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")
                //if (File.Exists(ZipFilePath))
                //{
                //    File.Delete(ZipFilePath);
                //}

                //System.IO.Compression.ZipFile.CreateFromDirectory(strPath, ZipFilePath);
                

                //Directory.Delete(strPath, true);

   

           // CompressAndDownloadFile(strFileName, ZipFilePath);



        }
        catch (Exception ex)
        {

            throw;
        }
    }

    //public void CompressAndDownloadFile(string sourceFilePath, string destinationFolder)
    //{
    //    // Check if the source file exists
    //    if (!File.Exists(sourceFilePath))
    //    {
    //        Console.WriteLine("Source file not found.");
    //        return;
    //    }

    //    // Create a unique ZIP file name
    //    string zipFileName = Path.GetFileNameWithoutExtension(sourceFilePath) + ".zip";
    //    string zipFilePath = Path.Combine(destinationFolder, zipFileName);

    //    // Create the ZIP file and add the source file to it
    //    using (FileStream zipStream = new FileStream(zipFilePath, FileMode.Create))
    //    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
    //    {
    //        string entryName = Path.GetFileName(sourceFilePath);
    //        archive.CreateEntryFromFile(sourceFilePath, entryName);
    //    }

    //    // Download the ZIP file
    //    HttpContext.Current.Response.ContentType = "application/zip";
    //    HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipFileName);
    //    HttpContext.Current.Response.TransmitFile(zipFilePath);
    //    HttpContext.Current.Response.Flush();
    //    HttpContext.Current.Response.End();

    //    // Optional: Delete the created ZIP file after downloading
    //    File.Delete(zipFilePath);
    //}
    public  void BtnDwnldAll_Click()
    {
        DataSet dsAll = new DataSet();
        Hashtable htAll = new Hashtable();
        string folderPath = @"D:\KMI_APPLICATION\Gitapp\Sanoj_Task\ZipFolder"; // Path where PDFs and ZIP will be stored

        // Clear any previous data
        dsAll.Clear();
        htAll.Clear();

        // Set parameter for database query
        htAll.Add("@memcode", "40086494"); // Replace with your actual parameter value

        // Retrieve data from the database
        dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FrnImgBytes", htAll);

        // Check if data is available
        if (dsAll.Tables.Count > 0)
        {
            // Create a ZIP archive
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                // Add a directory to the ZIP
                zip.AddDirectoryByName("Files");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Loop through the retrieved data
                foreach (DataTable table in dsAll.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        byte[] pdfBytes = (byte[])row["Images"]; // PDF data
                        string serverFileName = row["ServerFileName"].ToString().Trim(); // PDF file name

                        // Save PDF file
                        string pdfPath = Path.Combine(folderPath, serverFileName);
                        File.WriteAllBytes(pdfPath, pdfBytes);

                        // Add PDF to the ZIP archive
                        zip.AddFile(pdfPath, "Files");
                    }
                }

                // Set response headers for downloading ZIP file
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));

                Response.Clear();
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);

                // Save ZIP data to response stream
                zip.Save(Response.OutputStream);

                // Close and end the response
                Response.End();
            }

            // Clean up by deleting the temporary PDF files
            foreach (DataTable table in dsAll.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string serverFileName = row["ServerFileName"].ToString().Trim(); // PDF file name
                    string pdfPath = Path.Combine(folderPath, serverFileName);

                    if (File.Exists(pdfPath))
                    {
                        File.Delete(pdfPath);
                    }
                }
            }
        }


        //DataSet dsAll = new DataSet();
        //Hashtable htAll = new Hashtable();
        //string cnt = string.Empty;
        //string SvrFlnm = string.Empty;
        //string filePath = string.Empty;
        //dsAll.Clear();
        //htAll.Clear();
        //Response.Clear();

        //htAll.Add("@memcode", "40086494"); //Request.QueryString["CndNo"].ToString()
        //dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FrnImgBytes", htAll);
        //if (dsAll.Tables.Count > 0)
        //{
        //    using (ZipFile zip = new ZipFile())
        //    {
        //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //        zip.AddDirectoryByName("Files");

        //        string folderPath = @"D:\KMI_APPLICATION\Gitapp\Sanoj_Task\ZipFolder"; //Server.MapPath(Request.QueryString["CndNo"].ToString());
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);
        //        }
        //        else
        //        {
        //            for (int j = 0; j < dsAll.Tables.Count; j++)
        //            {
        //                if (dsAll.Tables[j].Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
        //                    {
        //                        if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim()))
        //                        {
        //                            File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim());
        //                        }
        //                    }
        //                }
        //            }
        //            //Directory.Delete(folderPath);
        //        }

        //        for (int j = 0; j < dsAll.Tables.Count; j++)
        //        {
        //            if (dsAll.Tables[j].Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
        //                {
        //                    byte[] img = (byte[])dsAll.Tables[j].Rows[i]["Images"];
        //                    string pdfPath = folderPath + "\\" + dsAll.Tables[j].Rows[i]["ServerFileName"];//+ ".pdf";
        //                    File.WriteAllBytes(pdfPath, img);
        //                    zip.AddFile(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), "files");
        //                }

        //            }

        //        }
        //        //zip.AddFile(folderPath, "files");



        //        //   zip.AddFiles(lstFlNm);
        //        // zip.AddFiles(lstFlNm, "Files");
        //        Response.Clear();
        //        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //        Response.ContentType = "application/zip";
        //        zip.Save(Response.OutputStream);
        //        if (Directory.Exists(folderPath))
        //        {
        //            for (int j = 0; j < dsAll.Tables.Count; j++)
        //            {
        //                if (dsAll.Tables[j].Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
        //                    {
        //                        if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim()))
        //                        {
        //                            File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim());
        //                        }
        //                    }
        //                }
        //            }
        //           // Directory.Delete(folderPath);
        //        }
        //        Response.End();
        //    }
        //}








    }








}



using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

using Insc.Common.Multilingual;
using System.IO;

using System.Drawing.Imaging;
using DataAccessClassDAL;

using Ionic.Zip;
using System.IO.Compression;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;

public partial class Application_Isys_ChannelMgmt_LicFPWelcomeLetter : BaseClass
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
                   

                }
                trLICId.Visible = true;
                tr31.Visible = true;

            }
            else
            {
                GrdLicId.DataSource = null;
                GrdLicId.DataBind();
               
            }
           

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
                if (MemCode != null && MemCode != "")
                {
                    //DownLoadZip(MemCode);
                   // BtnDwnldAll(MemCode);
                    DownloadAllFile(MemCode);



                }
                else
                {

                }


            }
        }
    }
    public void DownLoadZip(string MemCode)
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





            ZipFilePath = ZipFilePath + String.Format("{0}.zip", "40086494");// DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")
            if (File.Exists(ZipFilePath))
            {
                File.Delete(ZipFilePath);
            }

            //System.IO.Compression.ZipFile.CreateFromDirectory(strPath, ZipFilePath);


            Directory.Delete(strPath, true);

            //strFileName = "D:\\SANOJ sahani\\ClonProject\\New folder\\40086494.zip";

            //CompressAndDownloadFile(strFileName, ZipFilePath);
            byte[] zipBytes = File.ReadAllBytes(ZipFilePath);

            // Set appropriate HTTP headers for the download
            string downloadFileName = Path.GetFileName(ZipFilePath);
            System.Web.HttpContext.Current.Response.ContentType = "application/zip";
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + downloadFileName);
            System.Web.HttpContext.Current.Response.BinaryWrite(zipBytes);
            //System.Web.HttpContext.Current.Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();









        }
        catch (Exception ex)
        {

            throw;
        }
    }
    //public void DownloadFile()
    //{
    //    string url = "D:\\SANOJ sahani\\ClonProject\\New folder\\40086494.zip"; // Replace with the actual URL of the ZIP file
    //    string destinationPath = @"D:\SANOJ sahani\ClonProject\Mission_Youth\Document\40086494.zip"; // Replace with the desired local destination path

    //    using (WebClient webClient = new WebClient())
    //    {
    //        try
    //        {
    //            webClient.DownloadFile(url, destinationPath);
    //            //Console.WriteLine("File downloaded successfully.");
    //        }
    //        catch (Exception ex)
    //        {
    //            //Console.WriteLine("Error: " + ex.Message);
    //        }
    //    }
    //}





    
    public void CompressAndDownloadFile(string sourceFilePath, string destinationFolder)
    {
        //// Check if the source file exists
        //if (!File.Exists(sourceFilePath))
        //{
        //    Console.WriteLine("Source file not found.");
        //    return;
        //}

        //// Create a unique ZIP file name
        //string zipFileName = Path.GetFileNameWithoutExtension(sourceFilePath) + ".zip";
        //string zipFilePath = Path.Combine(destinationFolder, zipFileName);

        //// Create the ZIP file and add the source file to it
        //using (FileStream zipStream = new FileStream(zipFilePath, FileMode.Create))
        //using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
        //{
        //    string entryName = Path.GetFileName(sourceFilePath);
        //    archive.CreateEntryFromFile(sourceFilePath, entryName);
        //}

        //// Download the ZIP file
        //HttpContext.Current.Response.ContentType = "application/zip";
        //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipFileName);
        //HttpContext.Current.Response.TransmitFile(zipFilePath);
        //HttpContext.Current.Response.Flush();
        //HttpContext.Current.Response.End();

        //// Optional: Delete the created ZIP file after downloading
        //File.Delete(zipFilePath);
    }


    public void BtnDwnldAll(string Memcode)
    {
        DataSet dsAll = new DataSet();
        Hashtable htAll = new Hashtable();
        string cnt = string.Empty;
        string SvrFlnm = string.Empty;
        string filePath = string.Empty;
        dsAll.Clear();
        htAll.Clear();
        Response.Clear();

        htAll.Add("@memcode", "40086494"); //Request.QueryString["CndNo"].ToString()
        dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FrnImgBytes", htAll);
        if (dsAll.Tables.Count > 0)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");

                string folderPath = @"D:\KMI_APPLICATION\Gitapp\Sanoj_Task\ZipFolder";//trPath;// Server.MapPath("40086494");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                else
                {
                    for (int j = 0; j < dsAll.Tables.Count; j++)
                    {
                        if (dsAll.Tables[j].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                            {
                                if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim()))
                                {
                                    File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim());
                                }
                            }
                        }
                    }
                    //Directory.Delete(folderPath);
                }

                for (int j = 0; j < dsAll.Tables.Count; j++)
                {
                    if (dsAll.Tables[j].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                        {
                            //byte[] img = (byte[])dsAll.Tables[j].Rows[i]["Images"];
                            //System.IO.File.WriteAllBytes(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), img);
                            //MemoryStream ms = new MemoryStream(img);
                            //create ms objects of memery stream and write image byte in memory stream

                            //System.Drawing.Image imgdraw = System.Drawing.Image.from(ms);
                            //create imgdraw object of  System.Drawing.Image and use memory stream

                            //imgdraw.Save(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), ImageFormat.Jpeg);
                            //save image in specific path
                            //zip.AddEntry(dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), System.Convert.ToBase64String(img, 0, img.Length));
                            byte[] img = (byte[])dsAll.Tables[j].Rows[i]["Images"];
                            string pdfPath = folderPath  + dsAll.Tables[j].Rows[i]["ServerFileName"];//+ ".pdf";
                            File.WriteAllBytes(pdfPath, img);
                            zip.AddFile(folderPath + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), "files");
                        


                        }

                    }

                }
                //zip.AddFile(folderPath, "files");



                //   zip.AddFiles(lstFlNm);
                // zip.AddFiles(lstFlNm, "Files");

                Response.Clear();
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                if (Directory.Exists(folderPath))
                {
                    for (int j = 0; j < dsAll.Tables.Count; j++)
                    {
                        if (dsAll.Tables[j].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                            {
                                if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim()))
                                {
                                    File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim());
                                }
                            }
                        }
                    }
                    Directory.Delete(folderPath);
                }
                Response.End();
            }
        }








    }


    protected void DownloadAllFile(string Cndno)
    {

        DataSet dsAll = new DataSet();
        Hashtable htAll = new Hashtable();
        string cnt = string.Empty;
        string SvrFlnm = string.Empty;
        string filePath = string.Empty;
        dsAll.Clear();
        htAll.Clear();
        Response.Clear();
        htAll.Add("@CndNo", "30027974");// "30027974");

        dsAll = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Get_ImgBytes1", htAll);
        if (dsAll.Tables.Count > 0)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");

                string folderPath = @"D:\KMI_APPLICATION\Gitapp\Sanoj_Task\ZipFolder";// Server.MapPath(Request.QueryString["CndNo"].ToString());//
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                else
                {
                    for (int j = 0; j < dsAll.Tables.Count; j++)
                    {
                        if (dsAll.Tables[j].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                            {
                                if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["serverfilename"].ToString().Trim()))
                                {
                                    File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["serverfilename"].ToString().Trim());
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < dsAll.Tables.Count; j++)
                {
                    if (dsAll.Tables[j].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                        {
                            byte[] img = (byte[])dsAll.Tables[j].Rows[i]["pdfbyte"];
                            string pdfPath = folderPath + "\\" + dsAll.Tables[j].Rows[i]["serverfilename"];//+ ".pdf";
                            File.WriteAllBytes(pdfPath, img);
                            zip.AddFile(folderPath + "/" + dsAll.Tables[j].Rows[i]["serverfilename"].ToString().Trim(), "files");
                        }
                    }
                }
                Response.Clear();
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                if (Directory.Exists(folderPath))
                {
                    for (int j = 0; j < dsAll.Tables.Count; j++)
                    {
                        if (dsAll.Tables[j].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                            {
                                if (File.Exists(folderPath + "/" + dsAll.Tables[j].Rows[i]["serverfilename"].ToString().Trim()))
                                {
                                    File.Delete(folderPath + "/" + dsAll.Tables[j].Rows[i]["serverfilename"].ToString().Trim());
                                }
                            }
                        }
                    }
                 //   Directory.Delete(folderPath);
                }
                Response.End();
            }
        }
    }

    //public void BtnDwnldAll_Click()
    //{
    //    Hashtable htStatus = new Hashtable();
    //    DataSet dsStatus = new DataSet();
    //    DataSet dsAll = new DataSet();
    //    Hashtable htAll = new Hashtable();
    //    string cnt = string.Empty;
    //    string SvrFlnm = string.Empty;
    //    string filePath = string.Empty;
    //    dsAll.Clear();
    //    htAll.Clear();
    //    Response.Clear();
    //    htAll.Add("@memcode", "40086494"); //Request.QueryString["CndNo"].ToString()
    //    dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Get_FrnImgBytes", htAll);
    //    if (dsAll.Tables.Count > 0)
    //    {
    //        strPath = strPath + "40086494";
    //        Directory.CreateDirectory(strPath);
    //        using (ZipFile zip = new ZipFile())
    //        {
    //            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
    //            zip.AddDirectoryByName("Files");
    //            for (int j = 0; j < dsAll.Tables.Count; j++)
    //            {
    //                if (dsAll.Tables[j].Rows.Count > 0)
    //                {
    //                    for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
    //                    {

    //                        byte[] bytes = (byte[])dsAll.Tables[0].Rows[0]["Images"];
    //                        strFileName = strPath + "\\" + dsAll.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
    //                        FileInfo fi = new FileInfo(strFileName);
    //                        using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
    //                        {
    //                            FileStream.Write(bytes, 0, bytes.Length);
    //                        }
    //                        zip.AddFile(strFileName, "files");
    //                    }
    //                }
    //            }
    //            Response.Clear();
    //            string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
    //            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
    //            Response.ContentType = "application/zip";
    //            zip.Save(Response.OutputStream);
    //            Response.End();
    //        }
    //    }
    //}






}



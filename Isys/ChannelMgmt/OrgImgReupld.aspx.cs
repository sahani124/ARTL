using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections;
using DataAccessClassDAL;
using System.Data.SqlClient;
using System.Data;
using SD = System.Drawing;

public partial class Application_Isys_ChannelMgmt_OrgImgReupld : System.Web.UI.Page
{
    string strFilePath = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["AgentImgPath"].ToString();
    string strDocName = string.Empty;
    string strPhotoExt = string.Empty;
    string imagePath;
    byte[] imgBytes;
    private string strFileName = string.Empty;
    private string strFileName1 = string.Empty;
	string imageExtension = string.Empty;
	string imageUrl = string.Empty;
	static int image_height;
    static int image_width;
    static int max_height;
    static int max_width;
    static byte[] data;
    static string filename;
    static string contenttype;
	int delimiterIndex = 0;
	string path = string.Empty;
	string base64Code = string.Empty;
	Hashtable htdata = new Hashtable();
    ErrLog objErr = new ErrLog();
    DataAccessClass DataAccess = new DataAccessClass();
    DataAccessClass dataAccessRecruit = new DataAccessClass();
    SqlDataReader dtread;
    DataSet dsImage = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        //hdnimg.Value = FileUpload1.FileName;
        txtAgntCode.Text = Request.QueryString["Field1"].ToString().Trim();
        if (!IsPostBack)
        {
            //ImageRendering(txtAgntCode.Text);
        }
    }
	public System.Drawing.Image ToImage(byte[] array)
	{
		System.Drawing.Image returnImage = null;
		MemoryStream ms = new MemoryStream(array);
		returnImage = System.Drawing.Image.FromStream(ms);
		return returnImage;
	}
	public byte[] imageToByteArray(System.Drawing.Image imageIn)
	{
		MemoryStream ms = new MemoryStream();
		imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
		return ms.ToArray();
	}
	//#region btnUpload_Click
	//protected void btnUpload_Click(object sender, EventArgs e)
	//{
	//    strFilePath = strPath + txtAgntCode.Text.ToString().Trim();
	//    strFilePath = strPath;
	//    if (FileUpload1.HasFile)
	//    {
	//        if (FileUpload1.PostedFile.ContentLength < 204801)
	//        {
	//            strDocName = FileUpload1.PostedFile.FileName;
	//            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
	//        }
	//        else
	//        {
	//            ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Size of the selected file must not be greater than 200KB');</script>", false);
	//            return;
	//        }
	//    }
	//    else
	//    {
	//        ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Please Select the PHOTO File for Upload');</script>", false);
	//        return;
	//    }
	//    if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
	//    {
	//        strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
	//        strFileName = strFilePath + strFileName1;
	//    }
	//    else
	//    {
	//        ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('File format not supported');</script>", false);
	//        return;
	//    }
	//    System.Drawing.Image image_file = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
	//    if (strPhotoExt != string.Empty)
	//    {

	//        image_height = image_file.Height;
	//        image_width = image_file.Width;
	//        max_height = 100;
	//        max_width = 100;

	//        Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
	//        System.IO.MemoryStream stream = new System.IO.MemoryStream();
	//        bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
	//        stream.Position = 0;

	//        data = new byte[stream.Length + 1];
	//        stream.Read(data, 0, data.Length);

	//    }
	//    else
	//    {
	//        var message = new JavaScriptSerializer().Serialize("Please Upload an image");
	//        var script = string.Format("alert({0});", message);
	//        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
	//        return;
	//    }
	//    FileInfo fi = new FileInfo(strFileName);
	//    using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
	//    {
	//        byte[] byteData = FileUpload1.FileBytes;
	//        fileStream.Write(byteData, 0, byteData.Length);
	//    }
	//    string str1 = strFileName.Replace(@"\", @"/");
	//    string[] actualpath = str1.Split('/');
	//    strFileName = actualpath[0] + "\\" + actualpath[1];
	//    string strpth = strPath + strFileName1;
	//    string actpth = strpth.Replace(@"\\", @"\");
	//    htdata.Clear();
	//    htdata.Add("@AgtCode", txtAgntCode.Text.Trim());
	//    htdata.Add("@Imagebin", data);
	//    htdata.Add("@ImgPath", strFileName1);
	//    try
	//    {
	//        dtread = DataAccess.Common_exec_reader_prc_common("Proc_InsertAgtImgUpld", htdata);
	//        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
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
	//    FileUpload1.Dispose();
	//    GC.Collect();
	//    GC.WaitForPendingFinalizers();
	//}
	//#endregion

	public void ImageRendering(string Memcode)
    {
        try
        {
            string ShowImage = string.Empty;
            int count = 0;
            int m = 0;
            int n = 6;
            int approve = 0;
            Hashtable htImage = new Hashtable();
            DataSet dsImageDoc = new DataSet();
            htImage.Add("@Memcode", Memcode);
            //if ((Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc") || (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"))
            //{
            //    htImage.Add("@FlagQC", "QC2");
            //}
            //else
            //{
            //    htImage.Add("@FlagQC", "2");
            //}
            dsImage = dataAccessRecruit.GetDataSetForPrcCLP("Proc_GetAgtImgUpld", htImage);
            if (dsImage.Tables.Count > 0)
            {
                int num = dsImage.Tables[0].Rows.Count;
                if (num < 6)
                {
                    n = num;
                }
                int divide = num / 6;
                int num1 = num % 6;
                if (num1 != 0)
                {
                    divide = divide + 1;
                }
                int idoc = 0;
                for (int i = 0; i < divide; i++)
                {
                    ShowImage = ShowImage + "<div class='row' style='background-color:WhiteSmoke;padding: 1%;'>";
                    if (i != 0)
                    {
                        count = ((num - 6) / 6);
                        if (count != 0)
                        {
                            num = num - 6;
                            n = 6;
                        }
                        else
                        {
                            n = num % 6;
                        }
                    }
                    for (int j = m; j < n; j++)
                    {
                        htImage.Clear();
                        dsImageDoc.Clear();
                        htImage.Add("@Memcode", Memcode);
                        dsImageDoc = dataAccessRecruit.GetDataSetForPrcCLP("Proc_GetAgtImgUpld", htImage);
                        Byte[] bytes = (Byte[])dsImageDoc.Tables[0].Rows[0]["Images"];
                        string Flag = ""; //dsImageDoc.Tables[0].Rows[0]["Flag"].ToString().Trim();
                        string Flag1 = string.Empty;
                        if (Flag == "")
                        {
                            Flag1 = "1";
                        }
                        //else if (Flag == "C" || Flag == "R")
                        //{
                        //    Flag1 = "2";
                        //}
                        //else
                        //{
                        //    Flag1 = "3";
                        //}
                        string FileType = "JPEG";//dsImageDoc.Tables[0].Rows[0]["FileType"].ToString().Trim();
                        #region FOR JPEG FORMAT ONLY
                        if (FileType == "" || FileType == "JPEG" || FileType == "JPG" || FileType == "jpg" || FileType == "jpeg" || FileType == "PNG" || FileType == "png")
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(bytes));
                            int height = image.Height;
                            int width = image.Width;
                            int total = height * width;
                            string MstWidth = "273";//dsImageDoc.Tables[0].Rows[0]["width"].ToString().Trim();
                            string MstHeight = "185";//dsImageDoc.Tables[0].Rows[0]["height"].ToString().Trim();
                            ZinSize.Value = total.ToString();
                            ZoutSize.Value = "307200";//dsImageDoc.Tables[0].Rows[0]["ImgSize"].ToString().Trim();

                            string serverfilename = dsImageDoc.Tables[0].Rows[0]["PhotoName"].ToString().Trim();
                            string id = "";//dsImageDoc.Tables[0].Rows[0]["ID"].ToString().Trim();
                            string Doccode = ""; //dsImageDoc.Tables[0].Rows[0]["DocCode"].ToString().Trim();
                            string Imgsrc = "FPImageCSharp.aspx?ImageID=" + Memcode + "&Flag=" + "Hierarchy";
                            string Doctype = "";//dsImageDoc.Tables[0].Rows[0]["DocType"].ToString().Trim();
                            ShowImage = ShowImage + "  <div class='col-md-2 portfolio-item' >";
                            ShowImage = ShowImage + " <img id=" + id + " class='imgheight' height='50px' alt width=32 height=32  src=" + Imgsrc + ">";
                            ShowImage = ShowImage + " <ul class=list-inline><li>  ";
                            string PopDesc = string.Empty;
                            //if ((Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRaise" && Request.QueryString["Type"].ToString().Trim() == "Qc") || (Request.QueryString["TrnRequest"].ToString().Trim() == "CFRRespond" && Request.QueryString["Type"].ToString().Trim() == "QcRes"))
                            //{
                                PopDesc = "CFR";
                                ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showimage(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "','" + PopDesc + "');\"   class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                            //}
                            //else
                            //{
                                //ShowImage = ShowImage + " <button Id=" + Doccode + " type='button' OnClick=\"return showimage(" + id + "," + Doccode + "," + height + "," + width + "," + ZinSize.Value + "," + ZoutSize.Value + "," + MstWidth + "," + MstHeight + "," + Flag1 + ",'" + Doctype + "'," + PopDesc + ");\"   class='btn btn-link' data-toggle=tooltip data-placement=bottom ";
                            //}
                            if (Flag != "")
                            {
                                if (Flag == "A")
                                {
                                    Flag = "green";
                                    approve = approve + 1;
                                }
                                else if (Flag == "R")
                                {
                                    Flag = "red";
                                }
                                else if (Flag == "C")
                                {
                                    Flag = "mediumpurple";
                                }

                                ShowImage = ShowImage + " title='" + Doctype + "'><font color=" + Flag + ">" + serverfilename + "</font></button></li> </ul>";
                            }
                            else
                            {
                                ShowImage = ShowImage + " title='" + Doctype + "'>" + serverfilename + "</button></li> </ul>";
                            }
                        }
                        #endregion FOR JPEG FORMAT ONLY

                        ShowImage = ShowImage + " </div>";
                        idoc = idoc + 1;

                    }
                    ShowImage = ShowImage + "</div>";

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
	protected void btnSave_ServerClick(object sender, EventArgs e)
	{
		ViewState["bytes"] = "";
		if (hfX.Value!= "")
		{
			int x, y, w, h;
			if (!int.TryParse(hfX.Value, out x))
			{
				//Set default x value
				x = 0;
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select image')", true);
				//btnok.Visible = false;//added by sanoj 09022023
				return;
			}

			if (!int.TryParse(hfY.Value, out y))
			{
				//Set default y value
				y = 0;
			}

			if (!int.TryParse(hfHeight.Value, out h))
			{
				//Set default height value
				h = 0;
			}

			if (!int.TryParse(hfWidth.Value, out w))
			{
				//Set default width value
				w = 0;
			}
			if(hdnImageData.Value!="")
			{
				imageUrl = hdnImageData.Value;
				delimiterIndex = imageUrl.IndexOf(';');
				base64Code = imageUrl.Substring(delimiterIndex + 8);
				data = Convert.FromBase64String(base64Code);
				imageExtension = imageUrl.Substring("data:image/".Length, delimiterIndex - "data:image/".Length);
			}
			else
			{
				data = (Byte[])Session["FPImageCSharpImage"];
				imageExtension = Session["FPImageCSharpImageextension"].ToString();
			}
			using (System.Drawing.Image img = new Bitmap(ToImage(data)))
			{
				string ImgName = System.IO.Path.GetFileName(path);
				using (Bitmap bmpCropped = new Bitmap(w, h))
				{
					using (Graphics g = Graphics.FromImage(bmpCropped))
					{
						Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
						//Rectangle rectCropArea = new Rectangle(x, y, w, h);
						Rectangle rectCropArea = new Rectangle(x, y, w, h);
						g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
						//string SaveTo = @"D:\ISysSuite App\ISysSuite Hosted Applications\I-SysSuite\Application\ISys\Recruit\UploadedFiles\30026644\" + ImgName;
						//bmpCropped.Save(SaveTo);
						//string CroppedImg = Request.ApplicationPath + @"/CroppedImages/" + ImgName;
						//  imCropped.ImageUrl = CroppedImg;
						byte[] bytes = imageToByteArray(bmpCropped);
						string base64String = Convert.ToBase64String(bytes);
						//imCropped.ImageUrl = "data:image/jpeg;base64," + base64String;
						//imCropped.ImageUrl = "data:image/" + ViewState["extension"] + ";base64," + base64String;
						img3.ImageUrl = "data:image/" + imageExtension + ";base64," + base64String;
						ViewState["bytes"] = bytes;
						//hdnImageData.Value = base64String;
					}
					//  htParam.Clear();
					//  dsResult.Clear();
					//  htParam.Add("@ID", ID);
					//  htParam.Add("@ImgByte", bytes);
					//  htParam.Add("@flag", 1);
					//dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdateImg", htParam);
					//  ImFullImage.ImageUrl = "ImageCSharp.aspx?ImageID=" + ID;
					//  imCropped.ImageUrl = "ImgCropped.aspx?ImageID=" + ID;
					// ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doCancel();</script>", false);
				}
			}
		}
		strFilePath = strPath + txtAgntCode.Text.ToString().Trim();
		strFilePath = strPath;
		//strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
		strFileName = strFilePath + strFileName1;
		//string imageUrl = img3.ImageUrl;
		imageUrl = hdnImageData.Value;

		if (imageUrl.StartsWith("data:image/"))
		{
			delimiterIndex = imageUrl.IndexOf(';');
			if (delimiterIndex != -1)
			{
				// Extract the image extension
				imageExtension = imageUrl.Substring("data:image/".Length, delimiterIndex - "data:image/".Length);

				// Extract the Base64 code
				base64Code = imageUrl.Substring(delimiterIndex + 8); // Skip the ";base64," part
			}
			strFileName1 = txtAgntCode.Text.Trim() + "." + imageExtension;
			if (ViewState["bytes"].ToString()=="")
			{
				data = Convert.FromBase64String(base64Code);
			}
			else
			{
				data = (Byte[])ViewState["bytes"];
			}
			htdata.Clear();
			htdata.Add("@AgtCode", txtAgntCode.Text.Trim());
			htdata.Add("@Imagebin", data);
			htdata.Add("@ImgPath", strFileName1);
			try
			{
				dtread = DataAccess.Common_exec_reader_prc_common("Proc_InsertAgtImgUpld", htdata);
				ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
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
		else if (ViewState["bytes"].ToString() != "")
		{
			data = (Byte[])ViewState["bytes"];
			htdata.Clear();
			htdata.Add("@AgtCode", txtAgntCode.Text.Trim());
			htdata.Add("@Imagebin", data);
			htdata.Add("@ImgPath", strFileName1);
			dtread = DataAccess.Common_exec_reader_prc_common("Proc_InsertAgtImgUpld", htdata);
			ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
		}
		else
		{
			ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
		}
		//if (FileUpload1.HasFile)
		//{
		//	if (FileUpload1.PostedFile.ContentLength < 204801)
		//	{
		//		strDocName = FileUpload1.PostedFile.FileName;
		//		strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
		//	}
		//	else
		//	{
		//		ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Size of the selected file must not be greater than 200KB');</script>", false);
		//		return;
		//	}
		//}
		//else
		//{
		//	ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Please Select the PHOTO File for Upload');</script>", false);
		//	return;
		//}
		//if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
		//{
		//	strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
		//	strFileName = strFilePath + strFileName1;
		//}
		//else
		//{
		//	ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('File format not supported');</script>", false);
		//	return;
		//}
		//System.Drawing.Image image_file = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
		//if (strPhotoExt != string.Empty)
		//{

		//	image_height = image_file.Height;
		//	image_width = image_file.Width;
		//	max_height = 100;
		//	max_width = 100;

		//	Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
		//	System.IO.MemoryStream stream = new System.IO.MemoryStream();
		//	bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
		//	stream.Position = 0;

		//	data = new byte[stream.Length + 1];
		//	stream.Read(data, 0, data.Length);

		//}
		//else
		//{
		//	var message = new JavaScriptSerializer().Serialize("Please Upload an image");
		//	var script = string.Format("alert({0});", message);
		//	ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
		//	return;
		//}
		//FileInfo fi = new FileInfo(strFileName);
		//using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
		//{
		//	byte[] byteData = FileUpload1.FileBytes;
		//	fileStream.Write(byteData, 0, byteData.Length);
		//}
		//string str1 = strFileName.Replace(@"\", @"/");
		//string[] actualpath = str1.Split('/');
		//strFileName = actualpath[0] + "\\" + actualpath[1];
		//string strpth = strPath + strFileName1;
		//string actpth = strpth.Replace(@"\\", @"\");
	}
	//protected void BtnCrop_ServerClick(object sender, EventArgs e)
	//{
	//	strFilePath = strPath + txtAgntCode.Text.ToString().Trim();
	//	strFilePath = strPath;
	//	//strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
	//	strFileName = strFilePath + strFileName1;
	//	//string imageUrl = img3.ImageUrl;
	//	string imageUrl = hdnImageData.Value;
	//	string imageExtension = string.Empty;
	//	string base64Code = string.Empty;

	//	if (imageUrl.StartsWith("data:image/"))
	//	{
	//		int delimiterIndex = imageUrl.IndexOf(';');
	//		if (delimiterIndex != -1)
	//		{
	//			// Extract the image extension
	//			imageExtension = imageUrl.Substring("data:image/".Length, delimiterIndex - "data:image/".Length);

	//			// Extract the Base64 code
	//			base64Code = imageUrl.Substring(delimiterIndex + 8); // Skip the ";base64," part
	//		}
	//		strFileName1 = txtAgntCode.Text.Trim() + "." + imageExtension;
	//		data = Convert.FromBase64String(base64Code);
	//		htdata.Clear();
	//		htdata.Add("@AgtCode", txtAgntCode.Text.Trim());
	//		htdata.Add("@Imagebin", data);
	//		htdata.Add("@ImgPath", strFileName1);
	//		try
	//		{
	//			dtread = DataAccess.Common_exec_reader_prc_common("Proc_InsertAgtImgUpld", htdata);
	//			//ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
	//			ScriptManager.RegisterStartupScript(this, GetType(), "javascript1", "<script type='text/javascript'>funcopencrop1('" + txtAgntCode.Text.Trim() + "')</script>", false);
	//		}
	//		catch (Exception ex)
	//		{
	//			string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
	//			System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
	//			string sRet = oInfo.Name;
	//			System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
	//			String LogClassName = method.ReflectedType.Name;
	//			objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
	//		}
	//	}
	//	else
	//	{
	//		ScriptManager.RegisterStartupScript(this, GetType(), "javascript1", "<script type='text/javascript'>funcopencrop1('"+ txtAgntCode.Text.Trim() + "')</script>", false);
	//	}
	//	//if (FileUpload1.HasFile)
	//	//{
	//	//	if (FileUpload1.PostedFile.ContentLength < 204801)
	//	//	{
	//	//		strDocName = FileUpload1.PostedFile.FileName;
	//	//		strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
	//	//	}
	//	//	else
	//	//	{
	//	//		ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Size of the selected file must not be greater than 200KB');</script>", false);
	//	//		return;
	//	//	}
	//	//}
	//	//else
	//	//{
	//	//	ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Please Select the PHOTO File for Upload');</script>", false);
	//	//	return;
	//	//}
	//	//if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
	//	//{
	//	//	strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
	//	//	strFileName = strFilePath + strFileName1;
	//	//}
	//	//else
	//	//{
	//	//	ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('File format not supported');</script>", false);
	//	//	return;
	//	//}
	//	//System.Drawing.Image image_file = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
	//	//if (strPhotoExt != string.Empty)
	//	//{

	//	//	image_height = image_file.Height;
	//	//	image_width = image_file.Width;
	//	//	max_height = 100;
	//	//	max_width = 100;

	//	//	Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
	//	//	System.IO.MemoryStream stream = new System.IO.MemoryStream();
	//	//	bitmap_file.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
	//	//	stream.Position = 0;

	//	//	data = new byte[stream.Length + 1];
	//	//	stream.Read(data, 0, data.Length);

	//	//}
	//	//else
	//	//{
	//	//	var message = new JavaScriptSerializer().Serialize("Please Upload an image");
	//	//	var script = string.Format("alert({0});", message);
	//	//	ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
	//	//	return;
	//	//}
	//	//FileInfo fi = new FileInfo(strFileName);
	//	//using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
	//	//{
	//	//	byte[] byteData = FileUpload1.FileBytes;
	//	//	fileStream.Write(byteData, 0, byteData.Length);
	//	//}
	//	//string str1 = strFileName.Replace(@"\", @"/");
	//	//string[] actualpath = str1.Split('/');
	//	//strFileName = actualpath[0] + "\\" + actualpath[1];
	//	//string strpth = strPath + strFileName1;
	//	//string actpth = strpth.Replace(@"\\", @"\");
	//}
}
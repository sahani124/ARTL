using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
using INSCL.App_Code;
using Insc.MQ.Life.AgnCr;
using Insc.MQ.Life.AgnMd;
using Insc.MQ.Life.CSCr;
using Insc.MQ.Life.CSMod;
using Insc.MQ.Life.AgnInwMd;
using DataAccessClassDAL;
using System.Data.SqlClient;
using System.Data;
using INSCL.DAL;
using Insc.Common.Multilingual;
using System.Collections;
using System.Web.Services;

public partial class PopImage : BaseClass
{   
    ///added by akshay on 14/01/2014
    ///Page added to show popup to browse and upload images
    #region Declaration
    //string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    //string strPath = @"..\Application\INSC\Recruit\UploadedFiles\";
    int intValue;
    string strFilePath = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["AgentImgPath"].ToString();
    string strDocName = string.Empty;
    string strPhotoExt = string.Empty;
    string imagePath;
    byte[] imgBytes;
    private string strFileName = string.Empty;
    private string strFileName1 = string.Empty;
    Hashtable htdata = new Hashtable();
    SqlDataReader dtread;
    //binary format
    static int image_height;
    static int image_width;
    static int max_height;
    static int max_width;
    static byte[] data;
    static string filename;
    static string contenttype;
    string str;
    string doctype;
    string SAPCode;
    DataAccessClass dataaccess = new DataAccessClass();
    //binary format
    private multilingualManager olng;
    private string strUserLang;
    ErrLog objErr = new ErrLog();
   
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
       

        try
        {
            if (HttpContext.Current.Session["UserLangNum"] != "")
            {
                strUserLang = Convert.ToString(HttpContext.Current.Session["UserLangNum"]).Trim();
            }
            if (Request.QueryString["AgtRole"] != null)
            {
                if (Request.QueryString["AgtRole"].ToString().Trim() == "Emp")
                {
                    olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", strUserLang);
                }
                else if (Request.QueryString["AgtRole"].ToString().Trim() == "Ven")
                {
                    olng = new multilingualManager("DefaultConn", "VendorInfo.aspx", strUserLang);
                }
                else
                {
                    olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
                }
            }
            else
            {
                olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
            }
            if (!IsPostBack)
            {
                InitializeControl();
            }
            //var r = Request.QueryString["Field1"].ToString().Trim();
            //btnUpload.Attributes.Add("onclick", "doSelect('" + FileUpload1.FileName + "');return false;");

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doSelect('" + hdnimg.Value + "');return false;", true);
            //btnUpload.Attributes.Add("OnClick", "doSelect('" + hdnimg.Value + "');return false;");
            if (Request.QueryString["Flag"] != null)
            {
                if (Request.QueryString["Flag"].ToString().Trim() == "Heirarchy")
                {
                    hdnimg.Value = FileUpload1.FileName;
                    txtAgntCode.Text = Request.QueryString["Field1"].ToString().Trim();
                    //lvlVw1AgntCode.Visible = false;
                    //lblImageFile.Visible= false;
                    //lblImageFile.Visible = false;
                    //lblimgsize.Visible = false;
                    //divimg.Visible = false;
                    //txtAgntCode.Visible = false;
                    //btnCancel.Visible = false;
                }
            }
            else
            {
                //lvlVw1AgntCode.Visible = true;
                //lblImageFile.Visible = true;
                //lblImageFile.Visible = true;
                //lblimgsize.Visible =   true;
                //divimg.Visible = true;
                //txtAgntCode.Visible = false;
                //btnCancel.Visible = false;
            }
            //else
            //{
            hdnimg.Value = FileUpload1.FileName;
                txtAgntCode.Text = Request.QueryString["Field1"].ToString().Trim();
            //}
            ////SAPCode = Request.QueryString["Field2"].ToString().Trim();
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

    #region InitializeControl()
    private void InitializeControl()
    {
        lvlVw1AgntCode.Text = olng.GetItemDesc("lvlVw1AgntCode.Text");
    }
    #endregion

    #region btnUpload_Click
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        strFilePath = strPath + txtAgntCode.Text.ToString().Trim();
        strFilePath = strPath;

            //if (FileUpload1.HasFile)
            //{
               if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 204801)
                    {
                        strDocName = FileUpload1.PostedFile.FileName;
                        strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Size of the selected file must not be greater than 200KB');</script>", false);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('Please Select the PHOTO File for Upload');</script>", false);
                    return;
                }
                if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
                {
                    strFileName1 = txtAgntCode.Text.Trim() + "." + strPhotoExt;
                    strFileName = strFilePath + strFileName1;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "startupScript", "<script language=JavaScript>alert('File format not supported');</script>", false);
                    return;
                }

            System.Drawing.Image image_file = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
            if (strPhotoExt != string.Empty)
            {

                image_height = image_file.Height;
                image_width = image_file.Width;
                max_height = 100;
                max_width = 100;

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
            
            FileInfo fi = new FileInfo(strFileName);
            using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] byteData = FileUpload1.FileBytes;
                fileStream.Write(byteData, 0, byteData.Length);
            }
            string str1 = strFileName.Replace(@"\", @"/");
            
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1];
            string strpth = strPath + strFileName1;
            string actpth = strpth.Replace(@"\\", @"\");
        
            htdata.Clear();
            htdata.Add("@AgtCode", txtAgntCode.Text.Trim());
            htdata.Add("@Imagebin", data);
            htdata.Add("@ImgPath", strFileName1);

            try
            {
                dtread = dataaccess.Common_exec_reader_prc_common("Proc_InsertAgtImgUpld", htdata);
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doUpload()</script>", false);
            }
            catch (Exception ex)
            {
                //lblmessage.Text = ex.Message.ToString();
                //lblmessage.Visible = true;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim()); 
            }
            
            FileUpload1.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        //}


    }
    #endregion

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //  this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        if (Request.QueryString["Flag"]!= null)
        {
            if (Request.QueryString["Flag"].ToString().Trim() == "Heirarchy")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript2", "<script type='text/javascript'>doCancel2()</script>", false);
            }
        }
        else {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doCancel()</script>", false);
        }
    }
    #endregion

    [WebMethod]
    public static string GetBytes(List<ResultMemcode> data)
    {
        DataAccessClass dataAccess = new DataAccessClass();
        Hashtable htTable = new Hashtable();
        DataSet dsbytes = new DataSet();
        htTable.Clear();
        if (data[0].Memcode.ToString().Trim() != "")
        {
            htTable.Add("@Memcode", data[0].Memcode.ToString().Trim());
            dsbytes = dataAccess.GetDataSetForPrcIsysTemp("Prc_GetBytes_Member", htTable);
            if (dsbytes.Tables.Count > 0)
            {
                if (dsbytes.Tables[0].Rows.Count > 0)
                {
                    if (dsbytes != null && dsbytes.Tables[0].Rows[0]["Images"].ToString().Trim() != "")
                    {
                        Byte[] bytes = (Byte[])dsbytes.Tables[0].Rows[0]["Images"];
                        string base64String = Convert.ToBase64String(bytes);
                        //System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(bytes));
                        string imageUrl = "data:image/jpeg;base64," + base64String;
                        return imageUrl;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        else
        {
            htTable.Add("@Memcode", System.DBNull.Value);
        }
        return "";
    }
    public class ResultMemcode
    {
        public string Memcode { get; set; }
    }

}
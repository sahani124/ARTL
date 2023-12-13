using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using SD = System.Drawing;
using System.Drawing.Imaging;
using DataAccessClassDAL;
using System.IO;

public partial class _CropImage : BaseClass 
{
    #region Global Declaration
    string strimage = string.Empty;
    string path = string.Empty;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    private string File = string.Empty;
    private string strFileName1 = string.Empty;
    private string strFileName = string.Empty;
    private byte[] bytes;
    Rectangle rect;
    Point locationx;
    Point locationy;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        hdnCndNo.Value = Request.QueryString["CndNo"].ToString().Trim();
        if (!IsPostBack)
        {
            if (Request.QueryString["Flag"] != null)
            { 
                 GetDocType();
                 ddlDocType.SelectedItem.Text = Request.QueryString["args3"].ToString().Trim();
                 ddlDocType.Enabled = false;
                 ddldocType_SelectedIndexChanged(this,EventArgs.Empty);
            }
            else
            {
                GetDocType();
            }
           
          

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

    private System.Drawing.Image Blur(System.Drawing.Image image, Rectangle rectangle, Int32 blurSize)
    {
        Bitmap blurred = new Bitmap(image);   //image.Width, image.Height);
        using (Graphics graphics = Graphics.FromImage(blurred))
        {
            rect = new Rectangle();
            rect.X = Convert.ToInt32( hfX.Value);
            rect.Y = Convert.ToInt32(hfY.Value);
            rect.Width = Convert.ToInt32(hfWidth.Value);
            rect.Height = Convert.ToInt32(hfHeight.Value);
            // look at every pixel in the blur rectangle
            //  for (Int32 xx = rectangle.Left; xx < rectangle.Right; xx += blurSize)
            for (Int32 xx = rect.Left; xx < rect.Right; xx += blurSize)
            {
                for (Int32 yy = rect.Top; yy < rect.Bottom; yy += blurSize)
                {
                    Int32 avgR = 0, avgG = 0, avgB = 0;
                    Int32 blurPixelCount = 0;
                    Rectangle currentRect = new Rectangle(xx, yy, blurSize, blurSize);

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (Int32 x = currentRect.Left; (x < currentRect.Right && x < image.Width); x++)
                    {
                        for (Int32 y = currentRect.Top; (y < currentRect.Bottom && y < image.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }
                    try
                    {
                        avgR = avgR / blurPixelCount;
                        avgG = avgG / blurPixelCount;
                        avgB = avgB / blurPixelCount;

                    }
                    catch (Exception)
                    {
                    }

                    // now that we know the average for the blur size, set each pixel to that color
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(avgR, avgG, avgB)), currentRect);
                }
            }
            graphics.Flush();
        }
        return blurred;
    }
    public void CropImage( int X, int Y, int Width, int Height, byte[] array,string ID)
    {
        if (X == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select image for cropping')", true);
            
            return;
        
        }

        using (System.Drawing.Image img =new Bitmap(ToImage(array)))
        {
            string ImgName = System.IO.Path.GetFileName(path);
            using (Bitmap bmpCropped = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(bmpCropped))
                {
                    Rectangle FullRect = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                    //  Rectangle FullRect = new Rectangle(rect.Width, rect.Height, picturefirst.Image.Width, picturefirst.Image.Height);
                    System.Drawing.Image i =Blur(img, FullRect, 5);

                    //  Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                    //  Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);
                    //  g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
                    //  //string SaveTo = @"D:\ISysSuite App\ISysSuite Hosted Applications\I-SysSuite\Application\ISys\Recruit\UploadedFiles\30026644\" + ImgName;
                    //  //bmpCropped.Save(SaveTo);
                    //  //string CroppedImg = Request.ApplicationPath + @"/CroppedImages/" + ImgName;
                    ////  imCropped.ImageUrl = CroppedImg;
                    bytes = imageToByteArray(i);
                    ViewState["bytes"] = bytes;
                }
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@ID", ID);
                htParam.Add("@ImgByte", bytes);
                htParam.Add("@flag", 1);
              dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdateImg", htParam);
                ImFullImage.ImageUrl = "ImageCSharp.aspx?ImageID=" + ID;
                imCropped.ImageUrl = "ImgCropped.aspx?ImageID=" + ID;
               // ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>doCancel();</script>", false);
            }
        }
    }
    //protected void ImgCrop(string ID)
    //{

       
    //        htParam.Add("@ID", Request.QueryString["ImageID"]);
    //        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesbinary", htParam);

    //        if (dsResult != null)
    //        {
    //            try
    //            {
    //                if (dsResult.Tables[0].Rows.Count > 0)
    //                {
    //                    Byte[] bytes = (Byte[])dsResult.Tables[0].Rows[0]["ImagesCrop"];
    //                    Response.Buffer = true;
    //                    Response.Charset = "";
    //                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                    Response.ContentType = dsResult.Tables[0].Rows[0]["DocType"].ToString();
    //                    Response.AddHeader("content-disposition", "attachment;filename="
    //                        + dsResult.Tables[0].Rows[0]["Images"].ToString());

    //                    Response.BinaryWrite(bytes);
    //                    Response.Flush();
    //                    Response.End();
    //                }
    //                else
    //                {
    //                }
    //            }
    //            catch (Exception ex)
    //            {

    //                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //                string sRet = oInfo.Name;
    //                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //                String LogClassName = method.ReflectedType.Name;
    //                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //            }
            
    //    }
    //}
    protected void btnCrop_Click(object sender, EventArgs e)
    {
        int x, y, w, h;
        if (!int.TryParse(hfX.Value, out x))
        {
            //Set default x value
            x = 0;
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

        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        htParam.Add("@DocType", ddlDocType.SelectedItem.Text.ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
        bytes = (byte[])dsResult.Tables[0].Rows[0]["Images"];
        CropImage(x, y, w, h, bytes, dsResult.Tables[0].Rows[0]["ID"].ToString().Trim());

    }


    private void GetDocType()
    {
        DataSet dsResult = new DataSet();
        Hashtable htparam = new Hashtable();

        htparam.Clear();
        htparam.Add("@flag", 3);
        htparam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdateImg", htparam);

        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlDocType.DataSource = dsResult;////ddlUnitType
            ddlDocType.DataTextField = "DocType";
            ddlDocType.DataValueField = "DocCode";
            ddlDocType.DataBind();
            ddlDocType.Items.Insert(0, "--Select--");

        }




    }

    #region ddldocType_SelectedIndexChanged

    protected void ddldocType_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@DocType", ddlDocType.SelectedItem.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
            bytes = (byte[])dsResult.Tables[0].Rows[0]["Images"];
            ViewState["Bytes"]=bytes;
            ImFullImage.ImageUrl = "ImageCSharp.aspx?ImageID=" + dsResult.Tables[0].Rows[0]["ID"].ToString().Trim() ;
            ViewState["ID"] = dsResult.Tables[0].Rows[0]["ID"].ToString().Trim();

         
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

    protected void btnok_Click(object sender, EventArgs e)
    {

        if (ViewState["bytes"] ==null)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please click on crop image button')", true);

            return;
        }

        htParam.Clear();
        dsResult.Clear();

        htParam.Add("@ID", ViewState["ID"]);
        htParam.Add("@flag ", 2);
        //htParam.Add("@ImgByte", ViewState["bytes"]);

        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_UpdateImg", htParam);
        //if (Request.QueryString["Flag"] != null)
        //{
        //    Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&CndNo=" + Request.QueryString["CndNo"].ToString().Trim() + "&Status=QC&Code=Spon&Type=Qc");
        //}

    }
   
}

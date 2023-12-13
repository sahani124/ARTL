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

public partial class Application_ISys_ChannelMgmt_FranchiesEnrollment_FPCropImage : BaseClass
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
	#endregion

	protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void btnCrop_Click(object sender, EventArgs e)
	{
		int x, y, w, h;
		if (!int.TryParse(hfX.Value, out x))
		{
			//Set default x value
			x = 0;
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select image')", true);
			btnok.Visible = false;//added by sanoj 09022023
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

		htParam.Clear();
		dsResult.Clear();
		htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
		htParam.Add("@DocType", ddlDocType.SelectedItem.Text.ToString().Trim());
		dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesforQC", htParam);
		bytes = (byte[])dsResult.Tables[0].Rows[0]["Images"];
		CropImage(x, y, w, h, bytes, dsResult.Tables[0].Rows[0]["ID"].ToString().Trim());
		btnok.Visible = true;//added by sanoj 25012023
	}
	public void CropImage(int X, int Y, int Width, int Height, byte[] array, string ID)
	{
		if (X == 0)
		{
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select image for cropping')", true);

			return;

		}

		using (System.Drawing.Image img = new Bitmap(ToImage(array)))
		{
			string ImgName = System.IO.Path.GetFileName(path);
			using (Bitmap bmpCropped = new Bitmap(Width, Height))
			{
				using (Graphics g = Graphics.FromImage(bmpCropped))
				{
					Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
					Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);
					g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
					//string SaveTo = @"D:\ISysSuite App\ISysSuite Hosted Applications\I-SysSuite\Application\ISys\Recruit\UploadedFiles\30026644\" + ImgName;
					//bmpCropped.Save(SaveTo);
					//string CroppedImg = Request.ApplicationPath + @"/CroppedImages/" + ImgName;
					//  imCropped.ImageUrl = CroppedImg;
					bytes = imageToByteArray(bmpCropped);
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

}
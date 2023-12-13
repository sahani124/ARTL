//CREATED BY  :AJAY  YADAV
//PURPOSE     :FOR NEW MEMBER TYPE 'RF'

using DataAccessClassDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Isys_ChannelMgmt_HNINEnq : BaseClass
{
    protected CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();
    DataSet ds_documentName = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private DataAccessClass dataAccess = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    string strDocName = string.Empty;
    string strPhotoExt = string.Empty;
    int BMaxImgSize;
    public int image_height;
    public int image_width;
    public int max_height;
    public int max_width;
    public byte[] data;
    private string strFileName1 = string.Empty;
    private string strFileName = string.Empty;
    string strProcessType;
    int intValue;
    private string strDestPath = string.Empty;
    int BMaxImgSize1;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    string DocStatusCount;
    private DataAccessClass dataAccessclass = new DataAccessClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindgridview();
            getdetails();
        }
    }
    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblupdSize = (Label)e.Row.FindControl("lblupdSize");
            Label lblManDoc = (Label)e.Row.FindControl("lblManDoc");
            Button btn_Upload = (Button)e.Row.FindControl("btn_Upload");
            Button btn_ReUpload = (Button)e.Row.FindControl("btn_ReUpload");
            Label lbldoccode = (Label)e.Row.FindControl("lbldoccode");
            LinkButton lnkPreview = (LinkButton)e.Row.FindControl("lnkPreview");
            if (Request.QueryString["Type"] == "CndStat")   
            {
                e.Row.Cells[4].Enabled = false;
                FileUpload.Enabled = false;
            }
            if (Request.QueryString["Type"] == "E")     
            {
                btn_ReUpload.Enabled = false;
            }
            if (lblupdSize != null && lblupdSize.Text != "")
            {
                int updsize = Convert.ToInt32(lblupdSize.Text);
                int sizeupd = updsize / 1024;
                lblupdSize.Text = Convert.ToString(sizeupd);
            }
            if (lblManDoc.Text == "Y"){            }
            else if (lblManDoc.Text == "C" && lbldoccode.Text == "15")
            {
                Hashtable htPanchayat = new Hashtable();
                DataSet ds_panchayat = new DataSet();
                htPanchayat.Add("@CndNo", Request.QueryString["AgnCd"].ToString().Trim());
                ds_panchayat = dataAccessRecruit.GetDataSetForPrcCLP("Prc_CheckForPanchayat", htPanchayat);
                if (ds_panchayat.Tables[0].Rows[0]["PANCHAYAT"].ToString() == "1")
                {
                    e.Row.BackColor = Color.LightPink;
                }
            }
            Hashtable htparam = new Hashtable();
            htparam.Add("@MemCode", Request.QueryString["AgnCd"].ToString().Trim());
            htparam.Add("@MemType", "RF");
            htparam.Add("@ModuleCode", "Spon");
            htparam.Add("@TypeofDoc", "UPLD");
            htparam.Add("@InsurerType", "");
            htparam.Add("@ProcessType", "NR");
            htparam.Add("@doccode", lbldoccode.Text);
            htparam.Add("@EntityType", "HNIN");
            DataSet dsUpldImg = new DataSet();
            dsUpldImg = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMEMUpldDocCode", htparam);
            if (dsUpldImg.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsUpldImg.Tables[0].Rows.Count; i++)
                {
                    if (lbldoccode.Text == dsUpldImg.Tables[0].Rows[i]["DocCode"].ToString().Trim())
                    {
                        btn_Upload.Enabled = true;
                        btn_ReUpload.Enabled = false;
                        btn_Upload.Visible = true;
                        btn_ReUpload.Visible = false;
                        lnkPreview.Visible = false;
                    }
                }
            }
        }
    }

    protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Preview")
            {
                string Preview = e.CommandArgument.ToString().Trim();
                string Memcode = Request.QueryString["AgnCd"].ToString().Trim();
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lbldocName = (Label)row.FindControl("lbldocName");
                string strWindow = "window.open('FrmSponDocPreview.aspx?TrnRequest=Preview&DocCode=" + e.CommandArgument.ToString().Trim() + "&Memcode=" + Memcode.Trim() + "&docName=" + lbldocName.Text + "&Type=Preview','Preview','width=900px,height=600px,resizable=0,left=190,scrollbars=1');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
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

    protected void dgView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //try
        //{
        //    //For Pagination of Search Grid
        //    DataTable dt = GetDataTableForUplds();
        //    DataView dv = new DataView(dt);
        //    GridView dgSource = (GridView)sender;
        //    dgSource.PageIndex = e.NewPageIndex;
        //    dv.Sort = dgSource.Attributes["SortExpression"];
        //    if (dgSource.Attributes["SortASC"] == "No")
        //    {
        //        dv.Sort += " DESC";
        //    }
        //    dgSource.DataSource = dv;
        //    dgSource.DataBind();
        //    //ShowPageInformation();
        //}
        //catch (Exception ex)
        //{

        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
        //    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //}
    }

    private void Bindgridview()
    {
        try
        {
            Hashtable htparam = new Hashtable();
            htparam.Add("@MemCode", Request.QueryString["AgnCd"].ToString().Trim());
            htparam.Add("@MemType", "RF");
            htparam.Add("@ModuleCode", "Spon");
            htparam.Add("@TypeofDoc", "UPLD");
            htparam.Add("@InsurerType", "");
            htparam.Add("@ProcessType", "NR");
            htparam.Add("@EntityType", "HNIN");
            ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", htparam); 
            if (ds_documentName.Tables.Count > 0)
            {
                if (ds_documentName.Tables[0].Rows.Count > 0)
                {
                    dgView.DataSource = ds_documentName.Tables[0];
                    dgView.DataBind();
                }
                else
                {
                    dgView.DataSource = null;
                    dgView.DataBind();
                }
            }
            else
            {
                dgView.DataSource = null;
                dgView.DataBind();
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

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            string txtAgtCode = "";
            txtAgtCode = Request.QueryString["AgnCd"].ToString();
            //Added by pranjali on 27-12-2013 start
            GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
            FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
            Label lbldocname = (Label)row.FindControl("lbldocName");
            Label lblimgsize = (Label)row.FindControl("lblimgsize");
            Label lblimgshrt = (Label)row.FindControl("lblimgshrt");
            Label lblimgwidth = (Label)row.FindControl("lblimgwidth");
            Label lblimgheight = (Label)row.FindControl("lblimgheight");
            Label lbldoccode = (Label)row.FindControl("lbldoccode");
            Button btnreupd = (Button)row.FindControl("btn_ReUpload");
            Button btn_Upload = (Button)row.FindControl("btn_Upload");
            LinkButton lnkPreview = (LinkButton)row.FindControl("lnkPreview");
            BMaxImgSize = Convert.ToInt32(lblimgsize.Text);
            string strFilePath = string.Empty;

            //if (Directory.Exists(strPath) == false)
            //{
            //    strPath = strPath + txtAgtCode.Trim();
            //    Directory.CreateDirectory(strPath);
            //}
            //else
            //{
            //    strFilePath = strPath + txtAgtCode.Trim();
            //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
            //    if (!Directory.Exists(strFilePath))
            //    {
            //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
            //        Directory.CreateDirectory(strFilePath);
            //    }
            //    else
            //    {
            //        strFilePath = strPath + txtAgtCode.Trim();
            //    }
            //}

            #region Upload

            if (fuData.HasFile)
            {
                if (fuData.HasFile)
                {
                    strDocName = fuData.PostedFile.FileName;
                    strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
                }
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocname.Text + " File for Upload');</script>");
                return;
            }
            if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
            {
                strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PNG" || strPhotoExt == "png")
            {
                strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
            {
                strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else if (strPhotoExt == "PDF")
            {
                strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt.Text + "." + strPhotoExt;
                strFileName = strFilePath + "\\" + strFileName1;
            }
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Invalid File Format');</script>");
                return;
            }
            if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
            {
                //pranj
                System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
                if (fuData.PostedFile.ContentLength <= BMaxImgSize)
                {
                    if (strPhotoExt != string.Empty)
                    {
                        image_height = image_file.Height;
                        image_width = image_file.Width;
                        //Set image height and width to panel height and width iff the image is greater than panel dimensions start
                        if ((image_height > Convert.ToInt32(lblimgheight.Text) && image_width > Convert.ToInt32(lblimgwidth.Text))
                            || (image_height > Convert.ToInt32(lblimgheight.Text) || image_width > Convert.ToInt32(lblimgwidth.Text)))
                        {
                            max_height = Convert.ToInt32(lblimgheight.Text);
                            max_width = Convert.ToInt32(lblimgwidth.Text);
                        }
                        else
                        {
                            max_height = image_height;
                            max_width = image_width;
                        }
                        //Set image height and width to panel height and width iff the image is greater than panel dimensions end


                        image_height = (image_height * max_width) / image_width;
                        image_width = max_width;

                        if (image_height > max_height)
                        {
                            image_width = (image_width * max_height) / image_height;
                            image_height = max_height;
                        }
                        else
                        {
                        }
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
                }
                else
                {
                    int SIZE = BMaxImgSize / 1024;
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
                    return;
                }
            }
            else
            {
                if (strPhotoExt == "PDF")
                {
                    if (lbldoccode.Text.Trim() == "11" || lbldoccode.Text.Trim() == "12")
                    {
                        var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
                        var script = string.Format("alert({0});", message);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                        return;
                    }
                    else
                    {
                        if (fuData.PostedFile.ContentLength > 2048)
                        {
                            using (Stream fs = fuData.PostedFile.InputStream)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    data = br.ReadBytes((Int32)fs.Length);
                                }
                            }
                        }
                        else
                        {
                            var message = new JavaScriptSerializer().Serialize("Max File size is 2MB.");
                            var script = string.Format("alert({0});", message);
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                            return;
                        }
                    }
                }
                else
                {
                    var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                    return;

                }
            }
            //pranj
            //FileInfo fi = new FileInfo(Server.MapPath(strFileName));
            FileInfo fi = new FileInfo(strFileName);
            //commented by sanoj 02012022
            //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)) //Commented for overwritting of image instead of creating new image with same name
            //using (FileStream fileStream = fi.Open(FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            //{
            byte[] byteData = fuData.FileBytes;
            //byte[] byteData = data;
            //    fileStream.Write(byteData, 0, byteData.Length);
            //}


            //else
            //{
            //    int SIZE = BMaxImgSize / 1024;
            //    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE + "Kb');</script>");
            //    return;
            //}
            //}
            #endregion


            string str1 = strFileName.Replace(@"\", @"/");
            string[] actualpath = str1.Split('/');
            strFileName = actualpath[0] + "\\" + actualpath[1]; //+ "\\" + actualpath[3];

            Hashtable htdata = new Hashtable();
            htdata.Clear();
            htdata.Add("@Memcode", txtAgtCode.Trim());// txtMemberCode.Text.Trim()
            htdata.Add("@UserFileName", strFileName);
            htdata.Add("@ServerFileName", strFileName1);
            htdata.Add("@DocType", lbldocname.Text.Trim());
            htdata.Add("@UserID", Session["UserID"].ToString().Trim());
            htdata.Add("@DctmFlag", 'N');
            htdata.Add("@DocStatus", "0"); //Added by pranjali on 27-12-2013
            htdata.Add("@Imagebin", data);
            htdata.Add("@DocCode", lbldoccode.Text.Trim());
            htdata.Add("@FileType", strPhotoExt);
            try
            {

                //GetCandidateDtls();
                if (strProcessType == "NC")
                {
                    intValue = dataAccessRecruit.execute_sprcrecruit("Proc_InsertDCTMFileUploadNOC", htdata);

                }
                else
                {
                    
                        intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
                }
                //added by shreela on 21042014---end
            }
            catch (Exception ex)
            {
                
            }

            fuData.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            string Docname = lbldocname.Text;
            //hdnDocName.Value = lbldocname.Text.Trim();
            btnreupd.Enabled = true;
            btnreupd.Visible = true;
            btn_Upload.Enabled = false;
            btn_Upload.Visible = false;
            lnkPreview.Visible = true;
           
        }
        catch (Exception ex)
        {
           
        }

    }

    protected void btn_ReUpload_Click(object sender, EventArgs e)
    {
        string txtAgtCode = "";
        txtAgtCode = Request.QueryString["AgnCd"].ToString();
        GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
        FileUpload fuData = (FileUpload)row.FindControl("FileUpload");
        Label lbldocName = (Label)row.FindControl("lbldocName");
        Label lblUpldBy = (Label)row.FindControl("lblUpldBy");
        Label lblUpdDtTm = (Label)row.FindControl("lblUpdDtTm");
        Label lblFileName = (Label)row.FindControl("lblFileName");
        Label lblimgsize1 = (Label)row.FindControl("lblimgsize");
        Label lblimgshrt1 = (Label)row.FindControl("lblimgshrt");
        Label lblimgwidth1 = (Label)row.FindControl("lblimgwidth");
        Label lblimgheight1 = (Label)row.FindControl("lblimgheight");
        Label lbldoccode1 = (Label)row.FindControl("lbldoccode");
        Button btnreupd = (Button)row.FindControl("btn_ReUpload");
        Button btn_Upload = (Button)row.FindControl("btn_Upload");
        BMaxImgSize1 = Convert.ToInt32(lblimgsize1.Text);
        string strFileRePath = string.Empty;
        //Added BY Nikhil

        //int Memcode = 21018407;
        //if (Directory.Exists(strPath) == false)
        //{
        //    strPath = strPath + txtAgtCode.Trim(); //lblCndNoValue.Text.Trim();
        //    Directory.CreateDirectory(strPath);
        //}
        //else
        //{
        //    strFileRePath = strPath + txtAgtCode.Trim(); //lblCndNoValue.Text.Trim();
        //    //if (!Directory.Exists(Server.MapPath(strFilePath)))
        //    if (!Directory.Exists(strFileRePath))
        //    {
        //        // Directory.CreateDirectory(Server.MapPath(strFilePath));
        //        Directory.CreateDirectory(strFileRePath);
        //    }
        //    else
        //    {
        //        strFileRePath = strPath + txtAgtCode.Trim(); //lblCndNoValue.Text.Trim();
        //    }
        //}
        //Ended By Nikhil


        #region ReUpload

        if (fuData.HasFile)
        {
            if (fuData.HasFile)
            {
                strDocName = fuData.PostedFile.FileName;
                strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1).ToUpper();
            }
        }
        else
        {
            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Please Select " + lbldocName.Text + " File for ReUpload');</script>");
            return;
        }
        if (strPhotoExt == "JPG" || strPhotoExt == "jpg")
        {
            strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PNG" || strPhotoExt == "png")
        {

            strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg")
        {
            strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }
        else if (strPhotoExt == "PDF")
        {
            strFileName1 = txtAgtCode.Trim() + "_" + lblimgshrt1.Text + "." + strPhotoExt;
            strFileName = strFileRePath + "\\" + strFileName1;
        }


        if (strPhotoExt == "JPEG" || strPhotoExt == "jpeg" || strPhotoExt == "GIF" || strPhotoExt == "gif" || strPhotoExt == "JPG" || strPhotoExt == "jpg" || strPhotoExt == "PNG" || strPhotoExt == "png")
        {
            //pranj
            System.Drawing.Image image_file = System.Drawing.Image.FromStream(fuData.PostedFile.InputStream);
            if (strPhotoExt != string.Empty)
            {

                image_height = image_file.Height;
                image_width = image_file.Width;
                //Set image height and width to panel height and width iff the image is greater than panel dimensions start
                if ((image_height > Convert.ToInt32(lblimgheight1.Text) && image_width > Convert.ToInt32(lblimgwidth1.Text))
                            || (image_height > Convert.ToInt32(lblimgheight1.Text) || image_width > Convert.ToInt32(lblimgwidth1.Text)))
                {
                    max_height = Convert.ToInt32(lblimgheight1.Text);
                    max_width = Convert.ToInt32(lblimgwidth1.Text);
                }
                else
                {
                    max_height = image_height;
                    max_width = image_width;
                }
                //Set image height and width to panel height and width iff the image is greater than panel dimensions end

                image_height = (image_height * max_width) / image_width;
                image_width = max_width;

                if (image_height > max_height)
                {
                    image_width = (image_width * max_height) / image_height;
                    image_height = max_height;
                }
                else
                {
                }
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
        }
        else
        {
            if (strPhotoExt == "PDF")
            {
                if (lbldoccode1.Text.Trim() == "11" || lbldoccode1.Text.Trim() == "12")
                {
                    var message = new JavaScriptSerializer().Serialize("Please Upload JPG or JPEG format only for Photo and Signature.");
                    var script = string.Format("alert({0});", message);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                    return;
                }
                else
                {
                    if (fuData.PostedFile.ContentLength > 2048)
                    {
                        using (Stream fs = fuData.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                data = br.ReadBytes((Int32)fs.Length);
                            }
                        }
                    }
                    else
                    {
                        var message = new JavaScriptSerializer().Serialize("Max File Size is 2MB.");
                        var script = string.Format("alert({0});", message);
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                        return;
                    }
                }
            }
            else
            {
                var message = new JavaScriptSerializer().Serialize("Please Upload an Image or PDF");
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                return;

            }
        }
        Hashtable htdata = new Hashtable();
        FileInfo fi = new FileInfo(strPath);
        {
            if (fuData.PostedFile.ContentLength <= BMaxImgSize1)
            {
                if (File.Exists(strFileName))
                {
                    string stroldpath = strFileRePath + "\\" + strFileName1;
                    string[] strfile = strFileName1.Split('.');
                    htdata.Clear();
                    string ImageNamenew = strfile[0];
                    htdata.Clear();
                    htdata.Add("@MemCode", txtAgtCode.Trim());//Request.QueryString["AgnCd"].ToString().Trim());
                    htdata.Add("@doctype", lbldocName.Text.Trim());
                    //dsResult.Clear();
                    dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetDocStatusMem", htdata);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            DocStatusCount = dsResult.Tables[0].Rows[0]["DocStatusCount"].ToString().Trim();
                        }
                    }
                    string strnewpath = strFileRePath + "\\" + ImageNamenew + "_R" + DocStatusCount + "." + strPhotoExt;
                    System.IO.File.Copy(stroldpath, strnewpath, true);
                }
            }
            else
            {
                int SIZE1 = BMaxImgSize1 / 1024;
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('Max File size should be less than " + SIZE1 + "Kb');</script>");
                return;
            }
        }

        #endregion

        strDestPath = System.IO.Path.Combine(strFileRePath, strFileName);

        //fuData.PostedFile.SaveAs(Server.MapPath(strFileName));
        fuData.PostedFile.SaveAs((strFileName));
        string str1 = strFileName.Replace(@"\", @"/");
        string[] actualpath = str1.Split('/');
        strFileName = actualpath[0] + "\\" + actualpath[1];// + "\\" + actualpath[3];
                                                           //strFileName = actualpath[4] + "\\" + actualpath[5] + "\\" + actualpath[6];
        htdata.Clear();
        htdata.Add("@Memcode", txtAgtCode.Trim());
        htdata.Add("@UserFileName", strFileName);
        htdata.Add("@ServerFileName", strFileName1);
        htdata.Add("@DocType", lbldocName.Text.Trim());
        htdata.Add("@UserID", Session["UserID"].ToString().Trim());
        htdata.Add("@DctmFlag", 'N');
        htdata.Add("@DocStatus", "1"); //Added by pranjali on 27-12-2013
        htdata.Add("@Imagebin", data);
        htdata.Add("@DocCode", lbldoccode1.Text.Trim());
        htdata.Add("@FileType", strPhotoExt);
        try
        {
                    intValue = dataAccessRecruit.execute_sprcMemrecruit("Proc_InsertMemberDCTMFileUpload", htdata);
        }
        catch (Exception ex)
        {
            
        }

        fuData.Dispose();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        string Docname = lbldocName.Text;
      
    }

    protected void getdetails()
    {
        try
        {
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
            htParam.Add("@LanguageCode", "2");
            dsResult = dataAccess.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    txtNominee.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"].ToString().Trim());
                    txtNominMob.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Tel2"].ToString().Trim());
                    txtNomneeEmail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"].ToString().Trim());
                    txtNomDob.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BirthDate"].ToString().Trim());
                    ddlnmbnkhldname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankAcntName"]);
                    txtnmbnkacno.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankAccountCode"].ToString().Trim());
                    ddlnmifscode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ifsccode"].ToString().Trim());
                    ddlnmBnkname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BankCode"].ToString().Trim());
                    ddlnmBrnchname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Branch Name"].ToString().Trim());
                    ddlnmddlactype.SelectedValue= dsResult.Tables[0].Rows[0]["BankAcntType"].ToString().Trim();
                    txtnmmicr.Text= Convert.ToString(dsResult.Tables[0].Rows[0]["MICR Code"].ToString().Trim());
                    txthnin.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim());
                }
            }
        }
        catch
        {

        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        #region Document upload validation
        DataSet ds_candtype = new DataSet();
        Hashtable htparam = new Hashtable();
        htparam.Add("@MemCode", Request.QueryString["AgnCd"].ToString().Trim());
        htparam.Add("@MemType", "RF");
        htparam.Add("@ModuleCode", "Spon");
        htparam.Add("@TypeofDoc", "UPLD");
        htparam.Add("@InsurerType", "");
        htparam.Add("@ProcessType", "NR");
        htparam.Add("@EntityType", "HNIN");

        ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNamesHnin", htparam);
        //ds_documentName = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemDocNames", htparam);
        if (ds_documentName.Tables.Count > 0)
        {
            if (ds_documentName.Tables[0].Rows.Count > 0)
            {
                int i;
                for (i = 0; i < ds_documentName.Tables[0].Rows.Count; i++)
                {
                    string mandtry = ds_documentName.Tables[0].Rows[i]["IsMandatory"].ToString().Trim();

                    if (mandtry == "Y")
                    {
                        string ImgDesc = ds_documentName.Tables[0].Rows[i]["ImgDesc01"].ToString().Trim();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload " + ImgDesc + " ')", true);
                        return;
                    }
                }
            }//end of main for 
        }

        #endregion

        htParam.Clear();
        htParam.Add("@MemCode", Request.QueryString["AgnCd"].ToString().Trim());
        htParam.Add("@BankAcntName", ddlnmbnkhldname.Text);
        htParam.Add("@BankAccountCode", txtnmbnkacno.Text);
        htParam.Add("@NeftCode", ddlnmifscode.Text);
        htParam.Add("@BankAcntType", ddlnmddlactype.SelectedValue);
        htParam.Add("@BranchName", ddlnmBrnchname.Text);
        htParam.Add("@BankCode", ddlnmBnkname.Text);
        htParam.Add("@MICRCode", txtnmmicr.Text);
        dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_UpdNm_HNIN", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
        string mess = "Nominee details updated successfully.";
        lbl2.Text = mess + "<br> Member Code :" + Request.QueryString["AgnCd"].ToString().Trim();
        mdlpopup.Show();
        DisableLinkButton(btnupdate);
        dgView.Columns[4].Visible = false;
        dgView.Columns[11].Visible = false;
    }

    public static void DisableLinkButton(LinkButton linkButton)
    {
        linkButton.Enabled = false;
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.BackgroundColor] = "#b1e6e6 !important";
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "no-drop";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FPCndEnq.aspx?ModuleID=" + Request.QueryString["ModuleID"].ToString().Trim() + "&MemType=" + "RF");
    }

    protected void ddlnmifscode_TextChanged(object sender, EventArgs e)
    {
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@IFSCCode", ddlnmifscode.Text);
        dsResult = dataAccessclass.GetDataSetForPrcRecruit("PrcGetBankDetails", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlnmBrnchname.Text = dsResult.Tables[0].Rows[0]["BRANCH"].ToString().Trim();
            ddlnmBnkname.Text = dsResult.Tables[0].Rows[0]["BANK"].ToString().Trim();
        }
        else
        {
            ddlnmBrnchname.Text = "";
            ddlnmBnkname.Text = "";
        }
    }
}
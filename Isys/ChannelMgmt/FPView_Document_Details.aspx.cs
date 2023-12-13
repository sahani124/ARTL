using System.Net;
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
public partial class Application_INSC_ChannelMgmt_FPView_Document_Details : BaseClass
{

    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    DataSet dsdocType = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string str;
    string doctype;
    string strDocName = string.Empty;
    private string strFileName1 = string.Empty;
    DataSet ds_image = new DataSet();
    string strPhotoExt = string.Empty;
    string strSignExt = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    private string strFileName = string.Empty;
    string cndno = string.Empty;
    string candtype = string.Empty;
    string imgpaths = string.Empty;
    string hdnIDImg;
    public string FileType = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        cndno = Request.QueryString["CndNo"].ToString().Trim();
        if (cndno == null)
        {
            Response.Redirect("~/CndEnq.aspx");
        }
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
            Panelphoto2.Attributes.Add("style", "display:none");
           // FillData(Request.QueryString["CndNo"].ToString().Trim());
            BindGrid();
        }
    }
    protected void FillData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@MemCode", cndno);
        dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFrainchiseeSearchDtls", htParam);
        if (dsResult != null)
        {
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["legalName"].ToString().Trim();
                    lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                    lblBranchValue.Text = dsResult.Tables[0].Rows[0]["Branch"].ToString().Trim();
                }
            }
        }
    }
    public void getdocumenttype()
    {
        FillData(Request.QueryString["CndNo"].ToString().Trim());
        htParam.Clear();
        htParam.Add("@MemCode", cndno);
       dsResult = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);//  prc_GetDocType changed by  ajay
    }
    private void BindGrid()
    {
        try
        {
            getdocumenttype();
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ViewState["docType"] = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                    ViewState["SeqCount"] = dsResult.Tables[0].Rows[0]["SeqCount"].ToString();
                    lblpanelheader.Text = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                    btnprev.Enabled = false;
                    btnnext.Enabled = true;
                }
            }
            dsResult.Clear();
            htParam.Clear();
            Hashtable httable = new Hashtable();
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            httable.Add("@DocType", ViewState["docType"]);
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Reterival")
                {
                    httable.Add("@ProcessType1", "RW");
                }

                else if (ddlProcessType.SelectedValue == "Repeater")
                {
                    httable.Add("@ProcessType1", "RE");
                }
                else if (ddlProcessType.SelectedValue == "Normal")
                {
                    httable.Add("@ProcessType1", "NR");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    httable.Add("@ProcessType1", "NC");
                }
            }
            ds_image = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemImagesforDocument", httable); 
            if (ds_image.Tables.Count > 0)
            {
                if (ds_image.Tables[0].Rows.Count > 0)
                {
                    FileType = ds_image.Tables[0].Rows[0]["FileType"].ToString().Trim();
                    GridImage.DataSource = ds_image.Tables[0];
                    GridImage.DataBind();
                    ViewState["Img"] = ds_image;
                    ViewState["Img1"] = ds_image;
                }
                else
                {
                    GridImage.DataSource = null;
                    GridImage.DataBind();
                }
                divnavigate.Visible = true;
                Panelphoto2.Attributes.Add("style", "display:block");
                lblMessage.Visible = false;
            }
            else
            {
                divnavigate.Visible = false;
                Panelphoto2.Attributes.Add("style", "display:none");
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
            }
        }
        catch (Exception ex)
        {
            var message = new JavaScriptSerializer().Serialize(ex.Message);
            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        finally
        {
            //con.Close();
        }

    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int intcode1;
            int intcode = Convert.ToInt32(ViewState["SeqCount"]);
            intcode = intcode + 1;
            intcode1 = intcode;
            if (intcode > 1)
            {
                btnprev.Enabled = true;
            }
            else
            {
                btnprev.Enabled = false;
            }
            dsResult.Clear();
            htParam.Clear();
            getdocumenttype();
            int i;
            for (i = 1; i < dsResult.Tables[0].Rows.Count; i++)
            {
                str = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();
                if (intcode == Convert.ToInt32(str))
                {
                    doctype = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    lblpanelheader.Text = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    hdnDocId.Value = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();//01
                }
            }
            if (intcode < i)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
            htParam.Clear();
            DataSet dsResult1 = new DataSet();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", doctype);
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Reterival")
                {
                    htParam.Add("@ProcessType1", "RW");
                }
                else if (ddlProcessType.SelectedValue == "Repeater")
                {
                    htParam.Add("@ProcessType1", "RE");
                }
                else if (ddlProcessType.SelectedValue == "Normal")
                {
                    htParam.Add("@ProcessType1", "NR");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    htParam.Add("@ProcessType1", "NC");
                }
            }
            dsResult1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImagesForDocument", htParam);
            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                FileType = dsResult1.Tables[0].Rows[0]["FileType"].ToString().Trim();
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["SeqCount"] = intcode;
            }
            else
            {
                FileType = dsResult1.Tables[0].Rows[0]["FileType"].ToString().Trim();
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["SeqCount"] = intcode;
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
    protected void btnprev_Click(object sender, EventArgs e)
    {
        try
        {
            int intcode = Convert.ToInt32(ViewState["SeqCount"]);
            intcode = intcode - 1;
            dsResult.Clear();
            htParam.Clear();
            getdocumenttype();
            if (intcode < dsResult.Tables[0].Rows.Count)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
            {
                str = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();
                if (intcode == Convert.ToInt32(str))
                {
                    doctype = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    lblpanelheader.Text = dsResult.Tables[0].Rows[i]["DocType"].ToString();
                    hdnDocId.Value = dsResult.Tables[0].Rows[i]["SeqCount"].ToString();//01
                }
            }
            htParam.Clear();
            DataSet dsResult1 = new DataSet();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", doctype);
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Reterival")
                {
                    htParam.Add("@ProcessType1", "RW");
                }
                else if (ddlProcessType.SelectedValue == "Repeater")
                {
                    htParam.Add("@ProcessType1", "RE");
                }
                else if (ddlProcessType.SelectedValue == "Normal")
                {
                    htParam.Add("@ProcessType1", "NR");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    htParam.Add("@ProcessType1", "NC");
                }
            }
            dsResult1 = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImagesForDocument", htParam);
            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                FileType = dsResult1.Tables[0].Rows[0]["FileType"].ToString().Trim();
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["SeqCount"] = intcode;
            }
            else
            {
                FileType = dsResult1.Tables[0].Rows[0]["FileType"].ToString().Trim();
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["Img"] = dsResult1;
                ViewState["Img1"] = dsResult1;
                ViewState["SeqCount"] = intcode;
            }
            if (intcode == 1)
            {
                btnprev.Enabled = false;
            }
            else
            {
                btnprev.Enabled = true;
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
    protected void GridImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;
            dgSource.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];
            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }
            dgSource.DataSource = dv;
            dgSource.DataBind();
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
    protected DataTable GetDataTable()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@DocType", "PHOTO");
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Reterival")
                {
                    htParam.Add("@ProcessType1", "RW");
                }
                else if (ddlProcessType.SelectedValue == "Repeater")
                {
                    htParam.Add("@ProcessType1", "RE");
                }
                else if (ddlProcessType.SelectedValue == "Normal")
                {
                    htParam.Add("@ProcessType1", "NR");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    htParam.Add("@ProcessType1", "NC");
                }
            }
            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImagesForDocument", htParam);
            if (dsResult != null)
            {
                BindGrid();
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
        return dsResult.Tables[0];
    }
    protected void GridImage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnid = (HiddenField)e.Row.FindControl("hdnid");
                HiddenField hdnServerFileName = (HiddenField)e.Row.FindControl("hdnServerFileName");
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
    protected void ddlprocesstype_selectedindexchanged(object sender, EventArgs e)
    {
            BindGrid();
    }
    private void ddlProcessType1()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();
            htParam.Add("@Flag", "3");
            htParam.Add("@Cndno", cndno);
            dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNewProcessType", htParam);
            string FlagPT = dsComp.Tables[0].Rows[0]["FlagPT"].ToString().Trim();
            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddlProcessType.DataSource = dsComp;
                ddlProcessType.DataTextField = "Name";
                ddlProcessType.DataValueField = "Name";
                ddlProcessType.DataBind();
                if (FlagPT == "Y")
                {
                    ddlProcessType.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlProcessType.Enabled = false;
                    ddlProcessType.Items.Insert(1, ddlProcessType.DataValueField);
                    BindGrid();
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
    protected void lblCndView_Click(object sender, EventArgs e)
    {
        string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
    }
    protected void BtnDownload_Click(object sender, EventArgs e)
    {

        string hdnServerFileName = string.Empty;
        string DocType = string.Empty;
        int intcodedwn = Convert.ToInt32(ViewState["docCode"]);
        foreach (Control c in Panelphoto2.Controls)
        {
            Label list = lblpanelheader as Label;
            DocType = list.Text.Trim();
        }
        htParam.Clear();
        DataSet ds = new DataSet();
        foreach (GridViewRow row in GridImage.Rows)
        {
            htParam.Add("@cndno", cndno);
            htParam.Add("@Flag", "5");
            htParam.Add("@DocType", DocType);
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Reterival")
                {
                    htParam.Add("@ProcessType1", "RW");
                }
                else if (ddlProcessType.SelectedValue == "Repeater")
                {
                    htParam.Add("@ProcessType1", "RE");
                }
                else if (ddlProcessType.SelectedValue == "Normal")
                {
                    htParam.Add("@ProcessType1", "NR");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    htParam.Add("@ProcessType1", "NC");
                }
            }
            ds = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImagesForDocument", htParam);
            hdnServerFileName = ds.Tables[0].Rows[0]["ServerFileName"].ToString();
            for (int j = 0; j < ds.Tables.Count; j++)
            {
                if (ds.Tables[j].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[j].Rows.Count; i++)
                    {
                        byte[] Array = (Byte[])ds.Tables[j].Rows[i]["Images"];// get it from ur web service .
                        Response.BinaryWrite(Array);
                    }
                }
            }
        }
        string zipName = hdnServerFileName;
        Response.ContentType = "image/" + ds.Tables[0].Rows[0]["Format"];
        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        Response.Flush();
        Response.End();
    }
    protected void BtnDwnldAll_Click(object sender, EventArgs e)
    {
        Hashtable htStatus = new Hashtable();
        DataSet dsStatus = new DataSet();
        DataSet dsAll = new DataSet();
        Hashtable htAll = new Hashtable();
        string cnt = string.Empty;
        string SvrFlnm = string.Empty;
        string filePath = string.Empty;
        dsAll.Clear();
        htAll.Clear();
        Response.Clear();
        htAll.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        //if (ddlProcessType.SelectedValue != "")
        //{
        //    if (ddlProcessType.SelectedValue == "Reterival")
        //    {
        //        htAll.Add("@ProcessType", "RW");
        //    }
        //    else if (ddlProcessType.SelectedValue == "Repeater")
        //    {
        //        htAll.Add("@ProcessType", "RE");
        //    }
        //    else if (ddlProcessType.SelectedValue == "Normal")
        //    {
                htAll.Add("@ProcessType", "NR");
        //    }
        //    else if (ddlProcessType.SelectedValue == "NOC")
        //    {
        //        htAll.Add("@ProcessType", "NC");
        //    }
        //}
        List<string> lstFlNm = new List<string>();
        dsAll = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImgCnt", htAll);
        if (dsAll.Tables.Count > 0)
        {
            strPath = strPath + lblCndNoValue.Text.Trim();
            Directory.CreateDirectory(strPath);
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                for (int j = 0; j < dsAll.Tables.Count; j++)
                {
                    if (dsAll.Tables[j].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsAll.Tables[j].Rows.Count; i++)
                        {
                            htStatus.Clear();
                            dsStatus.Clear();
                            htStatus.Add("@CndNo", Request.QueryString["CndNo"].ToString());
                            htStatus.Add("@DocType", dsAll.Tables[j].Rows[i]["DocType"]);
                            htStatus.Add("@Flag", "5");
                            dsStatus = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetImagesForDocument", htStatus);
                            byte[] bytes = (byte[])dsStatus.Tables[0].Rows[0]["Images"];
                            strFileName = strPath + "\\" + dsStatus.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
                            FileInfo fi = new FileInfo(strFileName);
                            using (FileStream FileStream = fi.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                FileStream.Write(bytes, 0, bytes.Length);
                            }
                            zip.AddFile(strFileName, "files");
                        }
                    }
                }
                Response.Clear();
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsimageshow = ViewState["Img1"] as DataSet;
            string strpath = dsimageshow.Tables[0].Rows[0][2].ToString();
            string imgname = dsimageshow.Tables[0].Rows[0][3].ToString();
            if (dsimageshow.Tables[0].Rows[0]["FileType"].ToString().Trim() == "PDF")
            {
                var message = new JavaScriptSerializer().Serialize( "PDF can't be edited !");
                var script = string.Format("alert({0});", message);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);
                return;
            }
            else
            {
                imgpaths = strpath + "\\" + imgname;
                ViewState["paths"] = imgpaths.ToString();
                string imgnm = imgname.Substring(0, 11);
                lbltitle1.Text = imgnm.ToString() + " - " + "Web Image Preview";
                byte[] bytes = (byte[])dsimageshow.Tables[0].Rows[0][8];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                ViewState["vpath"] = base64String;
                imgbnd.ImageUrl = "ImageCSharp.aspx?ImageID=" + dsimageshow.Tables[0].Rows[0]["ID"].ToString();
                mdlpopup.X = 163;
                mdlpopup.Y = 1;
                mdlpopup.Show();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnrotate_Click(object sender, EventArgs e)
    {
        DataSet dsimageshow = ViewState["Img1"] as DataSet;
        string strpath = dsimageshow.Tables[0].Rows[0][2].ToString();
        string imgname = dsimageshow.Tables[0].Rows[0][3].ToString();
        imgpaths = strpath + "\\" + imgname;
        byte[] bytes = (byte[])dsimageshow.Tables[0].Rows[0][8];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        byte[] byteBuffer = Convert.FromBase64String(base64String);
        string str1 = Convert.ToString(byteBuffer) as string;
        string strpath1 = imgpaths.Replace("F:\\", "~\\");
        string path = Server.MapPath(strpath1);
        string path1 = imgpaths.Replace("E:\\Bhaurao_bck_all\\Bhaurao\\ARTL_New_Application\\I-SysSuite\\I-SysSuite", "~\\");
        System.Drawing.Image img = System.Drawing.Image.FromFile(path1);
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);
        img.Save(path1);//imgpaths
        img.Dispose();
        imgbnd.Attributes.Add("ImageUrl", path1);
        mdlpopup.Show();
    }
}
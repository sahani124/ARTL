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

public partial class Application_INSC_Recruit_View_Document_Details : BaseClass
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
    string imgpaths = string.Empty;
    string candtype = string.Empty;
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
            
            Panelphoto2.Attributes.Add("style","display:none");
            ddlProcessType1();
            FillData(Request.QueryString["CndNo"].ToString().Trim());
           // candtype = dsResult.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();
           // BindGrid();

        }
//int idoc=
  //      if (BtnSearch.Visible == false && ddlProcessType.AutoPostBack == true)
    //    {
      //      BindGrid();
        //}
    }
    protected void FillData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@CndNo", cndno);
        htParam.Add("@AppNo", System.DBNull.Value);
        htParam.Add("@ReqDate", System.DBNull.Value);
        htParam.Add("@BranchCode", System.DBNull.Value);
        htParam.Add("@AdvName", System.DBNull.Value);
        htParam.Add("@Type", Request.QueryString["Type"].ToString().Trim());
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvForHrsTrn", htParam);
       

        if (dsResult != null)
        {
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                    lblAdvNameValue.Text = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                    lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                    lblBranchValue.Text = dsResult.Tables[0].Rows[0]["Branch"].ToString().Trim();
                    lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["SMName"].ToString().Trim();
                    lblSponsorDtValue.Text = dsResult.Tables[0].Rows[0]["IRDASponsorDt"].ToString().Trim();



                    //For DocType
                    //htParam.Clear();
                    //htParam.Add("@CndNo", cndno);
                    //dsdocType = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
                    //lblpanelheader.Text = dsResult.Tables[0].Rows[0]["DocType"].ToString();
                }
            }
        }
    }
    public void getdocumenttype()
    {
        FillData(Request.QueryString["CndNo"].ToString().Trim());
        candtype = dsResult.Tables[0].Rows[0]["Cand_Type"].ToString().Trim();
        htParam.Clear();
        htParam.Add("@CndNo", cndno);
        htParam.Add("@candtype", candtype);
        htParam.Add("@FlagQC", "1");
        if (ddlProcessType.SelectedValue == "All")
        {
            htParam.Add("@Flag", "");
        }
        else
        {
            htParam.Add("@Flag", "1");

        }
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

        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
        
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

            ds_image = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImagesForDocument", httable);
            if (ds_image.Tables.Count > 0)
            {
                
                    if (ds_image.Tables[0].Rows.Count > 0)
                    {
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
                    //  GridImage.DataSource = ds_image.Tables[0];
                    //GridImage.DataBind();
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
           // int intcode = Convert.ToInt32(ViewState["docCode"]);
           // Added by for image count usha on 20.01.2015 
            int intcode1;
            int intcode = Convert.ToInt32(ViewState["SeqCount"]);
          //  intcode = intcode + 2;
            intcode = intcode + 1;
            intcode1 = intcode;
            // ended  by for image count usha on 20.01.2015 
            if (intcode > 1)
            {
                btnprev.Enabled = true;
            }
            //if (intcode == intcode1)
            //{
            //    btnnext.Enabled = false;
            //}
            else {
                btnprev.Enabled = false;
            }



            dsResult.Clear();
            htParam.Clear();

            getdocumenttype();
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetDocType", htParam);
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
            dsResult1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImagesForDocument", htParam);
           

            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                GridImage.Visible = false;
                string strImgPath = string.Empty;
                string strFilePath = string.Empty;
                //strFilePath = strPath + lblCndNoValue.Text.Trim();
                //strFileName1 = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014
                //strFileName = strFilePath + "\\" + strFileName1;
                //string strroute = "UploadedFiles" + "/" + Request.QueryString["CndNo"].ToString().Trim() + '/' + strFileName1;
                FrmImg.Visible = true;
				//FrmImg.Attributes["src"] = "UploadedFiles/30012465/30012465_26CDAWelcomeLetter_50000004.pdf";//strFileName;
				FrmImg.Attributes.Add("src", "PDFCSharp.aspx?PDFID=" + dsResult1.Tables[0].Rows[0]["ID"]);
				//FrmImg.Attributes["src"] = strroute;

				//byte[] img = (byte[])dsResult1.Tables[0].Rows[0]["Images"];
				//string imreBase64Data = System.Convert.ToBase64String(img, 0, img.Length);
				//string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
				//FrmImg.Attributes["src"] = imgDataURL;
				//Byte[] FileBuffer = (byte[])dsResult1.Tables[0].Rows[0]["Images"];
				//Response.Buffer = true;
				//Response.Charset = "";
				//Response.Cache.SetCacheability(HttpCacheability.NoCache);
				//Response.ContentType = "application/pdf";
				//Response.AddHeader("content-length", FileBuffer.Length.ToString());
				//Response.BinaryWrite(FileBuffer);

				// ViewState["docCode"] = intcode;
				// Added by for image count usha on 20.01.2015 
				ViewState["SeqCount"] = intcode;
                // ended  by for image count usha on 20.01.2015 
            }
            else
            {
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
               // ViewState["docCode"] = intcode;
                // Added by for image count usha on 20.01.2015 
                ViewState["SeqCount"] = intcode;
                // ended  by for image count usha on 20.01.2015 
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
            //int intcode = Convert.ToInt32(ViewState["docCode"]);
            // Added by for image count usha on 20.01.2015 
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
            dsResult1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImagesForDocument", htParam);
            strDocName = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
            strPhotoExt = strDocName.Substring(strDocName.LastIndexOf('.') + 1);
            if (strPhotoExt == "PDF" || strPhotoExt == "pdf")
            {
                GridImage.Visible = false;
                string strImgPath = string.Empty;
                string strFilePath = string.Empty;
                strFilePath = strPath + lblCndNoValue.Text.Trim();
                strFileName1 = dsResult1.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();//added by shreela on 12052014
                strFileName = strFilePath + "\\" + strFileName1;
                FrmImg.Visible = true;
                string strroute = "UploadedFiles" + "/" + Request.QueryString["CndNo"].ToString().Trim() + '/' + strFileName1;
                //FrmImg.Attributes["src"] = "UploadedFiles/30012465/30012465_26CDAWelcomeLetter_50000004.pdf";//strFileName;
                FrmImg.Attributes["src"] = strroute;
               // ViewState["docCode"] = intcode;
                // Added by for image count usha on 20.01.2015 
                ViewState["SeqCount"] = intcode;
                // ended  by for image count usha on 20.01.2015 
            }
            else
            {
                GridImage.Visible = true;
                FrmImg.Visible = false;
                GridImage.DataSource = dsResult1.Tables[0];
                GridImage.DataBind();
                ViewState["SeqCount"] = intcode;
                //ViewState["docCode"] = intcode;
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
            //For Pagination of Search Grid
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
            //ShowPageInformation();
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
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImagesForDocument", htParam);

            //htParam.Add("@ID", Request.QueryString["ImageID"]);
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetImagesbinary", htParam);

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
                //Session["imageID"] = hdnid.Value;
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
    //Added by Nikhil
    private void ddlProcessType1()
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();

            htParam.Add("@Flag", "3");
            htParam.Add("@Cndno", cndno);
            dsComp = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetNewProcessType", htParam);
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
                       // BindGrid();
                        //BtnSearch.Visible = false;
                    
                }
                else {
                    ddlProcessType.Enabled = false;
                    ddlProcessType.Items.Insert(1, ddlProcessType.DataValueField);
                    BindGrid();
                    BtnSearch.Visible = false;
                }
            }

            //ended by nikhil on 9.6.15
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
    //Ended by Nikhil

    //For View link
    protected void lblCndView_Click(object sender, EventArgs e)
    {
        
            string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
        }
   
    //protected void BtnDownload_Click(object sender, EventArgs e)
    //{
    ////    DataSet dsimage=new DataSet();
    ////    Hashtable httablei=new Hashtable();
    ////    Button lnkbtn = sender as Button;
    ////    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

    ////    int fileid = Convert.ToInt32(GridImage.DataKeys[gvrow.RowIndex].Value.ToString());
    ////    string name, type;
    ////     using (SqlCommand cmd = new SqlCommand())
    ////        {
             
    ////                 httablei.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    ////                 httablei.Add("@DocType", ViewState["docType"]);
    ////                 //httablei.Add("@fileid",fileid);
    ////            cmd.CommandType = CommandType.StoredProcedure;

    ////               cmd.Parameters.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    ////              cmd.Parameters.Add("@DocType", ViewState["docType"]);
    ////            dsimage = dataAccessRecruit.GetDataSetForPrcRecruit("prc_DownloadImagesforViewDoc", httablei);
    ////            cmd.Connection = con;
    ////            con.Open();
             
    ////            SqlDataReader dr = cmd.ExecuteReader();
    ////            if (dr.Read())
    ////            {
    ////                Response.ContentType = dr["FileType"].ToString();
    ////                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
    ////                Response.BinaryWrite((byte[])dr["FileData"]);
    ////                Response.End();
    ////            }
    ////        }
    ////    }

    //    //using (ZipFile zip = new ZipFile())
    //    //{
    //    //    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
    //    //    zip.AddDirectoryByName("Files");
    //    //    foreach (GridViewRow row in GridImage.Rows)
    //    //    {
    //    //        //if ((row.FindControl("chkSelect") as CheckBox).Checked)
    //    //        //{
    //    //           // string filePath = (row.FindControl("lblAdvNameValue") as Label).Text;
    //    //            zip.AddFile(filePath, "Files");
    //    //        //}
    //    //    }
    //    //}

    //    //string filename = "filename from Database";
    //    //Response.ContentType = "application/octet-stream";
    //    //Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
    //    //string aaa = Server.MapPath("~/SavedFolder/" + filename);
    //    //Response.TransmitFile(Server.MapPath("~/SavedFolder/" + filename));
    //    //Response.End();

    //    //string filePath = "";
    //    //dsResult.Clear();
    //    //htParam.Clear();
    //    //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //    //htParam.Add("@DocType", ViewState["docType"]);
    //    //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_DownloadImagesforViewDoc", htParam);
    //    //string filetempnm = dsResult.Tables[0].Rows[0]["ServerFileName"].ToString().Trim();
    //    //using (ZipFile zip = new ZipFile())
    //    //{
    //    //    foreach (GridViewRow gvrow in GridImage.Rows)
    //    //    {
    //    //        string fileName = ((LinkButton)gvrow.FindControl("lblCndNo1")).Text;
    //    //        string serverfolder=Server.MapPath("UploadedFiles//");
    //    //        if (System.IO.Directory.Exists(serverfolder))
    //    //        {
    //    //            filePath = "F:\\Bhau_2_activity\\I-SysSuite\\Application\\ISys\\Recruit\\UploadedFiles\\" + cndno + "+\\+" + "filetempnm";
    //    //        }   
             
    //    //            zip.AddFile(filePath, "files");
                

    //    //    }
    //    //    Response.Clear();
    //    //    Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
    //    //    Response.ContentType = "application/zip";
    //    //    ////zip.Save(Response.OutputStream);
    //    //    zip.Save(filePath);
    //    //    Response.End();
    //    //}

    //    using (ZipFile zip = new ZipFile())
    //    {
    //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
    //        zip.AddDirectoryByName("Files");
    //        foreach (GridViewRow row in GridImage.Rows)
    //        {
    //            DataSet ds = new DataSet();
    //            ds = ViewState["Img"] as DataSet;
    //            string hdnServerFileName = ds.Tables[0].Rows[0]["ServerFileName"].ToString();
    //            ///HiddenField hdnServerFileName = (HiddenField)GridImage.Rows[0].FindControl("hdnServerFileName");
    //            ////HiddenField hdnServerFileName = (HiddenField)row.FindControl("hdnServerFileName");
    //            //if ((row.FindControl("chkSelect") as CheckBox).Checked)
    //            //{
    //            //   // string filePath = (row.FindControl("lblFilePath") as Label).Text;

    //            string filePath = strPath + cndno + "\\" + hdnServerFileName;
    //            zip.AddFile(filePath, "Files");
    //            //}
    //        }
    //        Response.Clear();
    //        Response.BufferOutput = false;
    //        string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
    //        Response.ContentType = "application/zip";
    //        Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
    //        zip.Save(Response.OutputStream);
    //        Response.End();
    //    }
       
    //}
    protected void BtnDownload_Click(object sender, EventArgs e)
    {

        string hdnServerFileName = string.Empty;
         string DocType=string.Empty;
        int intcodedwn = Convert.ToInt32(ViewState["docCode"]);
        //using (ZipFile zip = new ZipFile())
        //{
        //    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //    zip.AddDirectoryByName("Files");
        foreach (Control c in Panelphoto2.Controls)
            {
                Label list = lblpanelheader as Label;
                DocType = list.Text.Trim();
        }
        htParam.Clear();
        DataSet ds = new DataSet();

        foreach (GridViewRow row in GridImage.Rows)
        {
            
            // ViewState["Img"] = ds;
            // BindGrid();
            //hdnServerFileName = ds_image.Tables[0].Rows[0]["ServerFileName"].ToString();

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
            ds = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImagesForDocument", htParam);

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
            Response.ContentType = "image/" + ds.Tables[0].Rows[0]["Format"] ;


            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            Response.Flush();
            Response.End();
        
        //Response.Clear();
        //Response.BufferOutput = false;
        //string zipName = hdnServerFileName;
        //Response.ContentType = "application/jpg";
        //Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        ////zip.Save(Response.OutputStream);
        //Response.End();

    }
    protected void BtnDwnldAll_Click(object sender, EventArgs e)
    {
        DataSet dsAll = new DataSet();
        Hashtable htAll = new Hashtable();
        string cnt = string.Empty;
        string SvrFlnm = string.Empty;
        string filePath = string.Empty;
        dsAll.Clear();
        htAll.Clear();
        Response.Clear();

        htAll.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        if (ddlProcessType.SelectedValue != "")
        {
            if (ddlProcessType.SelectedValue == "Reterival")
            {
                htAll.Add("@ProcessType", "RW");
            }

            else if (ddlProcessType.SelectedValue == "Repeater")
            {
                htAll.Add("@ProcessType", "RE");

            }
            else if (ddlProcessType.SelectedValue == "Normal")
            {
                htAll.Add("@ProcessType", "NR");

            }

            else if (ddlProcessType.SelectedValue == "NOC")
            {
                htAll.Add("@ProcessType", "NC");

            }

        }

        List<string> lstFlNm = new List<string>();
        dsAll = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetImgCnt", htAll);
        if (dsAll.Tables.Count > 0)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");

				string folderPath = Server.MapPath(Request.QueryString["CndNo"].ToString());
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
							byte[] img = (byte[])dsAll.Tables[j].Rows[i]["Images"];
							MemoryStream ms = new MemoryStream(img);
							System.Drawing.Image imgdraw = System.Drawing.Image.FromStream(ms);
							imgdraw.Save(folderPath+"/"+ dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), ImageFormat.Jpeg);
							//zip.AddEntry(dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), System.Convert.ToBase64String(img, 0, img.Length));
							zip.AddFile(folderPath + "/" + dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim(), "files");

							//SvrFlnm = dsAll.Tables[j].Rows[i]["ServerFileName"].ToString().Trim();
							//                     //string filePath = strPath + cndno + "\\" + hdnServerFileName;
							//                     filePath = strPath + cndno + "\\" + SvrFlnm;
							//                     //string filePath = "F:\\Bhau_2_activity\\I-SysSuite\\Application\\ISys\\Recruit\\UploadedFiles\\" + cndno + "\\" + SvrFlnm;
							//                     zip.AddFile(filePath, "files");
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
    protected void BtnSearch_click(object sender, EventArgs e)
    {
        if (ddlProcessType.SelectedValue == "--Select--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Process Type')", true);
            return;
        }
        else
        {
           // Panelphoto2.Attributes.Add("style", "display:none");
           // dsResult.Clear();
            BindGrid();
            BtnSearch.Visible = false;
            ddlProcessType.Items.RemoveAt(0);
        }
    }
protected void ddlProcessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (BtnSearch.Visible == false)
        {
            BindGrid();
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
                var message = new JavaScriptSerializer().Serialize("PDF can't be edited !");
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
                //imgbnd.ImageUrl = strpath + "\\" + imgname;
                //imgbnd.DataBind();

                //convert into bite
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
        //   imgbnd.ImageUrl = imgbnd.ResolveUrl(~+"/"+imgpaths);

        string path = Server.MapPath(strpath1);
        string path1 = imgpaths.Replace("E:\\Bhaurao_bck_all\\Bhaurao\\ARTL_New_Application\\I-SysSuite\\I-SysSuite", "~\\");

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path1);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file

        img.Save(path1);//imgpaths

        //release image file
        img.Dispose();

        imgbnd.Attributes.Add("ImageUrl", path1);

        mdlpopup.Show();
    }
}
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

public partial class Application_INSC_Recruit_FrmGetRecord : BaseClass
{
    #region Page Declaration
    string Connect;
    string strSQL = "";
    string strVal = string.Empty;
    SqlCommand cmd;
    SqlConnection sqlConc;
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    DataTable dtResult = new DataTable();
    DataSet dsResult = new DataSet();
    DataSet dsExport = new DataSet();
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            if (!IsPostBack)
            {
                PopulateDRFType();
                PopulateModeType();
            }
            lblMessage.Text = "";
            //btnSearch.Attributes.Add("onClick", "javascript: return funAlertSearch();");
            //btnSearch.Attributes.Add("OnClick", "javascript:return  funAlertSearch()");
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

    #region Mode type
    private void PopulateModeType()
    {
        getModeDoc(ddlDwnld, "");
        ddlDwnld.Items.Insert(0, "--Select--");
    }
    #endregion

    #region DRFType
    private void PopulateDRFType()
    {
        ddlUpload.Items.Insert(0, "--Select--");
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

    #region  dgDownload PageIndexChanging
    protected void dgDownload_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            ShowPageInformation();
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

    #region GetDataTable()
    protected DataTable GetDataTable()
    {
        try
        {
            DataSet dsResult = new DataSet();
            DataTable dtRes = new DataTable();
            dtRes = null;

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Action", ddlDwnld.SelectedValue.ToString().Trim());
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htParam.Add("@BatchId", txtBatch.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetHstTbl", htParam);

            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    int count = dsResult.Tables.Count;
                    if (dsResult.Tables[count - 1].Rows.Count > 0)
                    {
                        dtRes = dsResult.Tables[0];
                    }
                    else
                    {
                        dtRes = null;
                    }
                }
                else
                {
                    dtRes = null;
                }
            }
            else
            {
                dtRes = null;
            }

            return dtRes;
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

    #region ddlDwnld_SelectedIndexChanged
    protected void ddlDwnld_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
             htParam.Clear();
             dsResult.Clear();
             htParam.Add("@Action", ddlDwnld.SelectedValue.ToString().Trim());
             dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDwnldDocName", htParam);
             ddlUpload.DataSource = dsResult;
             ddlUpload.DataValueField = "Doctype";
             ddlUpload.DataTextField = "DocDesc";
             ddlUpload.DataBind();
             ddlUpload.Items.Insert(0, "--Select--");
             divsearch.Visible = false;
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

    #region grdSaphst Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgDownload.PageIndex + 1;
        lblPageInfo.Visible = true;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDownload.PageCount;
    }
    #endregion

    #region button Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string strValue = string.Empty;
            if (ddlDwnld.SelectedItem.Value.ToString().Trim() == "--Select--")
            {
                 ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select Mode');</script>");
                 strValue = "0";
            }
            else if (ddlUpload.SelectedItem.Value.ToString().Trim() == "--Select--")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select Document Type');</script>");
                strValue = "0";
            }
            else if (txtBatch.Text == "")
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please enter batchId');</script>");
                strValue = "0";
            }
            else
            {
                strValue = "1";
            }
            //if (ddlDwnld.SelectedValue.ToString().Trim() != "--Select--")
            //{
            //    if (txtBatch.Text == "")
            //    {
            //        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please enter batchId.');</script>");
            //        strValue = "1";
            //    }
            //    else
            //    {
            //        strValue = "0";
            //    }
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>AlertMsgs('Please select Mode');</script>");
            //    strValue = "1";
            //}

            if (strValue == "1")
            {
                DataSet dstable = new DataSet();
                htParam.Clear();
                htParam.Add("@Action", ddlDwnld.SelectedValue.ToString().Trim());
                htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
                htParam.Add("@BatchId", txtBatch.Text.ToString().Trim());
                dstable = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetHstTbl", htParam);

                if (dstable.Tables.Count > 0)
                {
                    int count = dstable.Tables.Count;
                    if (dstable.Tables[count-1].Rows.Count > 0)
                    {
                        divsearch.Visible = true;
                        lblSearch.Text = ddlUpload.SelectedItem.Text.ToString();
                        trdghdr.Visible = true;
                        trGrid.Visible = true;
                        dgDownload.Visible = true;
                        dgDownload.DataSource = dstable.Tables[count-1];
                        dgDownload.DataBind();
                        ShowPageInformation();
                        btnExport.Visible = true;
                        btnExport.Visible = true;
                        btnExport.Enabled = true;
                    }
                    else
                    {
                        divsearch.Visible = false;
                        trdghdr.Visible = false;
                        trGrid.Visible = false;
                        lblMessage.Visible = true;
                        lblMessage.Text = "0 Record found";
                        btnExport.Visible = false;
                        btnExport.Enabled = false;
                    }
                }
                else
                {
                    divsearch.Visible = false;
                    trdghdr.Visible = false;
                    trGrid.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record found";
                    btnExport.Visible = false;
                    btnExport.Enabled = false;
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

    #region Button Export
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            htParam.Add("@DocType", ddlUpload.SelectedValue.ToString().Trim());
            htParam.Add("@Action", ddlDwnld.SelectedValue.ToString().Trim());
            htParam.Add("@BatchID", txtBatch.Text.Trim());
            dsExport = dataAccessRecruit.GetDataSetForPrcUpdDwnld("prc_GetHstTbl", htParam);

            if (dsExport.Tables.Count > 0)
            {
                int count = dsExport.Tables.Count;
                if (dsExport.Tables[count - 1].Rows.Count > 0)
                {
                    //string filename = "DownloadExcel.xls";
                    string filename = ddlUpload.SelectedItem.Text.ToString() + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dsExport.Tables[0];
                    dgGrid.DataBind();

                    dgGrid.RenderControl(hw);
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
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

    #region BindGrid
    void BindDataGrid()
    {
        try
        {
            dtResult = GetDataTable();
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                    divsearch.Visible = true;
                    trdghdr.Visible = true;
                    trGrid.Visible = true;
                    dgDownload.Visible = true;
                    dgDownload.DataSource = dtResult;
                    dgDownload.DataBind();
                    ShowPageInformation();
                }
                else
                {
                    divsearch.Visible = false;
                    trdghdr.Visible = false;
                    trGrid.Visible = false;
                    dgDownload.Visible = false;
                }
            }
            else
            {
                divsearch.Visible = false;
                trdghdr.Visible = false;
                trGrid.Visible = false;
                dgDownload.Visible = false;
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

    #region getModeDoc
    public void getModeDoc(DropDownList abc, string LookupParamValue)
    {
        try
        {
            //Connect = ConfigurationManager.ConnectionStrings["INSCRecruitConnectionString"].ConnectionString;
            sqlConc = new SqlConnection(strconn);
            sqlConc.Open();
            strSQL = "exec Prc_GetModeName";
            abc.DataTextField = "DocDesc";
            abc.DataValueField = "Action";
            cmd = new SqlCommand(strSQL, sqlConc);
            cmd.CommandTimeout = 0;
            //Insert data to dropdownlist
            abc.DataSource = cmd.ExecuteReader();
            abc.DataBind();

            if (abc.Items.FindByValue(LookupParamValue.ToString()) != null)
            {
                abc.SelectedValue = LookupParamValue.ToString();
            }

            sqlConc.Close();
            sqlConc = null;
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
       divsearch.Visible = false;
       txtBatch.Text = "";
    }
    #endregion

    #region txtBatch_TextChanged
    protected void txtBatch_TextChanged(object sender, EventArgs e)
    {
        divsearch.Visible = false;
    }
    #endregion

    #region btnCancle_Click
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmGetRecord.aspx");
    }
    #endregion
}


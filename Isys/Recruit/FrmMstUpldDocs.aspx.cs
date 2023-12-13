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
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;
using System.Collections.Generic;

public partial class Application_ISys_Recruit_FrmMstUpldDocs : BaseClass
{
    #region Declare Variable
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private multilingualManager olng;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    ErrLog objErr = new ErrLog();
    DataAccessClass objDAL = new DataAccessClass();
    int y;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            olng = new multilingualManager("DefaultConn", "FrmMstUpldDocs.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            PopulateProcessType();
            PopulateCandType();
            PopulateStatus();
            btnAddNew.Attributes.Add("onclick", "funcopen();return false");
        }
      
    }

    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            lblPrcstype.Text = olng.GetItemDesc("lblPrcstype");
            lblCandType.Text = olng.GetItemDesc("lblCandType");
            lblStatus.Text = olng.GetItemDesc("lblStatus");
            lblDesc.Text = olng.GetItemDesc("lblDesc");
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

    #region PopulateProcessType
    private void PopulateProcessType()
    {

        dsResult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetProcessType");
        ddlPrcsType.DataSource = dsResult;
        ddlPrcsType.DataTextField = "ProcessDesc";
        ddlPrcsType.DataValueField = "ProcessType";
        ddlPrcsType.DataBind();
        ddlPrcsType.Items.Insert(0,"--Select--");
        dsResult = null;
    }
    #endregion

    #region PopulateCandType
    private void PopulateCandType()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetMstCandType");
        ddlCndType.DataSource = dsresult;
        ddlCndType.DataTextField = "CandTypeDesc";
        ddlCndType.DataValueField = "Cand_Type";
        ddlCndType.DataBind();
        ddlCndType.Items.Insert(0,"--Select--");
        dsresult = null;
    }
    #endregion

    #region PopulateStatus
    private void PopulateStatus()
    {
        DataSet dsresult = new DataSet();
        dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetStatusType");
        ddlstatus.DataSource = dsresult;
        ddlstatus.DataTextField = "StatusDesc";
        ddlstatus.DataValueField = "Status";
        ddlstatus.DataBind();
        ddlstatus.Items.Insert(0, "--Select--");
        dsresult = null;
    }
    #endregion

    //#region ddlstatus SelectedIndexChanged
    //protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //    SqlDataReader dtRead;
    //    htParam.Add("@Process", ddlPrcsType.SelectedValue);
    //    htParam.Add("@CandType", ddlCndType.SelectedValue);
    //    htParam.Add("@Status", ddlstatus.SelectedValue);
    //    dtRead = objDAL.Recruit_exec_reader_prc("Prc_GetDocDescType", htParam);
    //    if (dtRead.HasRows)
    //    {
    //        ddlDesc.DataSource = dtRead;
    //        ddlDesc.DataTextField = "ImgDesc01";
    //        ddlDesc.DataValueField = "DocCode";
    //        ddlDesc.DataBind();
    //        ddlDesc.Items.Insert(0, "--Select--");
    //    }
    //    dtRead = null;
    //}
    //#endregion

    #region Button Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            trtitle.Visible = true;
            BindMstUpldDocs();
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

    #region Button Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        dgMstUpldDocs.DataSource = null;
        dgMstUpldDocs.DataBind();
        ddlPrcsType.ClearSelection();
        ddlCndType.ClearSelection();
        ddlstatus.ClearSelection();
        trtitle.Visible = false;
        

    }
    #endregion

    #region dgMstUpldDocs RowCommand
    protected void dgMstUpldDocs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Hashtable htSeqNo = new Hashtable();
        if (e.CommandName == "DeActivate")
        {
            string ImgCode = Convert.ToString(e.CommandArgument);
            htSeqNo.Add("@Flag", "1");
            htSeqNo.Add("@ImgCode", ImgCode);
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstUpldDocsStatus", htSeqNo);
            BindMstUpldDocs();
        }
        else
        {
            string ImgCode = Convert.ToString(e.CommandArgument);
            htSeqNo.Add("@Flag", "2");
            htSeqNo.Add("@ImgCode", ImgCode);
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstUpldDocsStatus", htSeqNo);
            BindMstUpldDocs();
        }
    }
    #endregion

    #region dgMstUpldDocs RowDataBound
    protected void dgMstUpldDocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkStatus = new LinkButton();
            lnkStatus = (LinkButton)e.Row.FindControl("lnkStatus");
            if (lnkStatus.Text == "DeActivate")
            {
                lnkStatus.CommandName = "DeActivate";
            }
            else
            {
                lnkStatus.CommandName = "Activate";
            }
        }
    }
    #endregion

    #region BindMstUpldDocs
    private void BindMstUpldDocs()
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            if (ddlPrcsType.SelectedItem.ToString().Trim() == "--Select--")
            {
                htParam.Add("@ProcessType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@ProcessType", ddlPrcsType.SelectedValue.ToString().Trim());
            }
            if (ddlCndType.SelectedItem.ToString().Trim() == "--Select--")
            {
                htParam.Add("@CandType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@CandType", ddlCndType.SelectedItem.ToString().Trim());
            }
            if (ddlstatus.SelectedItem.ToString().Trim() == "--Select--")
            {
                htParam.Add("@Status", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@Status", ddlstatus.SelectedItem.ToString().Trim());
            }

            htParam.Add("@Desc", textDesc.Text.ToString().Trim());
           
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstUpldDocs ", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstUpldDocs.DataSource = dsResult.Tables[0];
                dgMstUpldDocs.DataBind();

            }
            else
            {
                dgMstUpldDocs.DataSource = null;
                dgMstUpldDocs.DataBind();
               

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
    #endregion

    #region PageIndex
    protected void dgMstUpldDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    #endregion

    #region GetDataTable
    protected DataTable GetDataTable()
    {
        try
        {
            BindMstUpldDocs();
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
    #endregion

    #region Button AddNew
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
       
    }
    #endregion

    #region button
    protected void btnrefresh_Click(object sender, EventArgs e)
    {
        BindMstUpldDocs();
    }
    #endregion

}
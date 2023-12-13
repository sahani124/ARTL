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

public partial class Application_ISys_Recruit_FrmMstExmCentre : BaseClass
{
    #region "Declare Variable"
    private multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    private const string c_strBlank = "-- Select --";
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    ArrayList arrResult = new ArrayList();
    private clsCndReg clsCndReg = new clsCndReg();
    DataSet dsDB = new DataSet();
    string strFDocType = string.Empty;
    DataSet dsResult = new DataSet();
    string strDelete = string.Empty;
    string strValue = string.Empty;
    DataTable dtCurrentTable;
    int x;
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
            olng = new multilingualManager("DefaultConn", "FrmMstExmCentre.aspx", Session["UserLangNum"].ToString());
            PopulateExamMode();
            InitializeControl();
            tblExmCntrdtl.Visible = true;
            trMstExmCntre.Visible = false;
            tblExmCntrdtlValue.Visible = false;
            lblTitle.Text = "Exam Centre Search";
        }
    }
    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            lblExmMode.Text = olng.GetItemDesc("lblExmMode");
            lblExmBdy.Text = olng.GetItemDesc("lblExmBdy");
            lblExmCntr.Text = olng.GetItemDesc("lblExmCntr");
            lblExmModeValue.Text = olng.GetItemDesc("lblExmModeValue");
            lblExmBdyValue.Text = olng.GetItemDesc("lblExmBdyValue");
            lblExmCntrValue.Text = olng.GetItemDesc("lblExmCntrValue");
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
    #region Exam Mode
    private void PopulateExamMode()
    {
        try
        {
            oCommon.getDropDown(ddlExam, "ExmMode", 1, "", 1);
            ddlExam.Items.Insert(0, "--Select--");
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        htParam.Add("@ExmMode", ddlExam.SelectedValue);
        htParam.Add("@ExmBody", txtExmBdyValue.Text.ToString().Trim());
        htParam.Add("@ExmCntre", txtExmCntrValue.Text.ToString().Trim());
        htParam.Add("@IsActive", "1");
        htParam.Add("@CreatedBy", Session["UserID"].ToString());
        hdnCrtDtim.Value = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);
        htParam.Add("@CreatedDtim", DateTime.Parse(hdnCrtDtim.Value).ToString("yyyyMMdd"));
        x = dataAccessRecruit.execute_sprcrecruit("Prc_InsMstExmCntre", htParam);
        BindMstExmCntr();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmBody", txtExmBdy.Text.ToString().Trim());
            htParam.Add("@ExmCntre", txtExmCntr.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmCntr", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmCntr.DataSource = dsResult.Tables[0];
                dgMstExmCntr.DataBind();
                trMstExmCntre.Visible = true;
                tblExmCntrdtlValue.Visible = false;
            }
            else
            {
                dgMstExmCntr.DataSource = null;
                dgMstExmCntr.DataBind();
                trMstExmCntre.Visible = false;
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        dgMstExmCntr.DataSource = null;
        dgMstExmCntr.DataBind();
        trMstExmCntre.Visible = false;
        trtitle.Visible = false;
        tblExmCntrdtlValue.Visible = false;
        txtExmMode.Text = "";
        txtExmBdy.Text = "";
        txtExmCntr.Text = "";
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        tblExmCntrdtlValue.Visible = true;
    }
    private void BindMstExmCntr()
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmBody", txtExmBdy.Text.ToString().Trim());
            htParam.Add("@ExmCntre", txtExmCntr.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmCntr", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmCntr.DataSource = dsResult.Tables[0];
                dgMstExmCntr.DataBind();
            }
            else
            {
                dgMstExmCntr.DataSource = null;
                dgMstExmCntr.DataBind();
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
    #region dgMstExmCntr RowCommand
    protected void dgMstExmCntr_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Hashtable htSeqNo = new Hashtable();
        htSeqNo.Add("@SeqNo", e.CommandArgument);
        if (e.CommandName == "DeActivate")
        {
            htSeqNo.Add("@Flag", "1");
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstExmCntrStatus", htSeqNo);
            BindMstExmCntr();
        }
        else
        {
            htSeqNo.Add("@Flag", "2");
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstExmCntrStatus", htSeqNo);
            BindMstExmCntr();
        }
    }
    #endregion

    #region dgMstExmCntr RowDataBound
    protected void dgMstExmCntr_RowDataBound(object sender, GridViewRowEventArgs e)
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

    #region PageIndex
    protected void dgMstExmCntr_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmBody", txtExmBdy.Text.ToString().Trim());
            htParam.Add("@ExmCntre", txtExmCntr.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmCntr", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmCntr.DataSource = dsResult.Tables[0];
                dgMstExmCntr.DataBind();
            }
            else
            {
                dgMstExmCntr.DataSource = null;
                dgMstExmCntr.DataBind();
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
    #endregion
}
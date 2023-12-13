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

public partial class Application_ISys_Recruit_FrmMstExmLng : BaseClass
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
            olng = new multilingualManager("DefaultConn", "FrmMstExmLng.aspx", Session["UserLangNum"].ToString());
            PopulateExamMode();
            InitializeControl();
            tblExmLngdtlValue.Visible = false;
            trMstExmLng.Visible = false;
            lblTitle.Text = "Exam Language Search";
        }
    }
     #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            lblExmMode.Text = olng.GetItemDesc("lblExmMode");
            lblExmLng.Text = olng.GetItemDesc("lblExmLng");
            lblExmLngValue.Text = olng.GetItemDesc("lblExmLngValue");
            lblExmModeValue.Text = olng.GetItemDesc("lblExmModeValue");
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmLng", txtExmLng.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmLng", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmLng.DataSource = dsResult.Tables[0];
                dgMstExmLng.DataBind();
                trMstExmLng.Visible = true;
                tblExmLngdtlValue.Visible = false;
            }
            else
            {
                dgMstExmLng.DataSource = null;
                dgMstExmLng.DataBind();
                trMstExmLng.Visible = false;
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
        dgMstExmLng.DataSource = null;
        dgMstExmLng.DataBind();
        trMstExmLng.Visible = false;
        trtitle.Visible = false;
        tblExmLngdtlValue.Visible = false;
        txtExmMode.Text = "";
        txtExmLng.Text = "";
        
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        tblExmLngdtlValue.Visible = true;
    }
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
        htParam.Add("@ExmLng",txtExmLngValue.Text.ToString().Trim());
        htParam.Add("@IsActive","1");
        htParam.Add("@CreatedBy",Session["UserID"].ToString());
        hdnCrtDtim.Value = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);
        htParam.Add("@CreatedDtim", DateTime.Parse(hdnCrtDtim.Value).ToString("yyyyMMdd"));
        x = dataAccessRecruit.execute_sprcrecruit("Prc_InsMstExmLng", htParam); 
        BindMstExmLng();
    }

    private void BindMstExmLng()
    {
        try
        {
            htParam.Clear();
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmLng", txtExmLng.Text.ToString().Trim());
            dsResult.Clear();
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmLng", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmLng.DataSource = dsResult.Tables[0];
                dgMstExmLng.DataBind();
            }
            else
            {
                dgMstExmLng.DataSource = null;
                dgMstExmLng.DataBind();
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
    #region dgMstExmLng RowCommand
    protected void dgMstExmLng_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Hashtable htSeqNo = new Hashtable();
        htSeqNo.Add("@SeqNo", e.CommandArgument);
       if(e.CommandName == "DeActivate")
       {
           htSeqNo.Add("@Flag","1"); 
           y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstExmLngStatus", htSeqNo);
           BindMstExmLng();
       }
       else
       {
           htSeqNo.Add("@Flag", "2");
           y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstExmLngStatus", htSeqNo);
           BindMstExmLng();
       }
    }
    #endregion

    #region dgMstExmLng RowDataBound
    protected void dgMstExmLng_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void dgMstExmLng_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            htParam.Add("@Exmmode", txtExmMode.Text.ToString().Trim());
            htParam.Add("@ExmLng", txtExmLng.Text.ToString().Trim());
            dsResult.Clear();
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstExmLng", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstExmLng.DataSource = dsResult.Tables[0];
                dgMstExmLng.DataBind();
            }
            else
            {
                dgMstExmLng.DataSource = null;
                dgMstExmLng.DataBind();
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
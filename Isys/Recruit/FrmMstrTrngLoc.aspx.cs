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

public partial class Application_ISys_Recruit_FrmMstrTrngLoc : BaseClass
{
    #region Declare Variable
    protected CommonFunc oCommon = new CommonFunc();
    ErrLog objErr = new ErrLog();
    private multilingualManager olng;
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    int x;
    int y;
    #endregion

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            olng = new multilingualManager("DefaultConn", "FrmMstTrnInst.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            PopulateTrnType();
            tblTrnInstDtl.Visible = true;

        }
    }
    #endregion

    #region InitializeControl Method
    private void InitializeControl()
    {
        try
        {
            lbltrntype.Text = olng.GetItemDesc("lbltrntype");
            lbltrnloc.Text = olng.GetItemDesc("lbltrnloc");
            lblTrnInst.Text = olng.GetItemDesc("lblTrnInst");
            lblAcc.Text = olng.GetItemDesc("lblAcc");
            lblTrnTypeVal.Text = olng.GetItemDesc("lblTrnTypeVal");
            lbltrnlocval.Text = olng.GetItemDesc("lbltrnlocval");
            lblTrnInstVal.Text = olng.GetItemDesc("lblTrnInstVal");
            lblAccVal.Text = olng.GetItemDesc("lblAccVal");
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

    #region Trn Type
    private void PopulateTrnType()
    {
        try
        {
            oCommon.getDropDown(ddltrntype, "TrnMode", 1, "", 1);
            ddltrntype.Items.Insert(0, "--Select--");
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

    private void PopulateTrnTypeVal()
    {
        try
        {
            oCommon.getDropDown(ddlTrnTypeVal, "TrnMode", 1, "", 1);
            ddlTrnTypeVal.Items.Insert(0, "--Select--");
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

    #region Button Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            if (ddltrntype.SelectedItem.ToString().Trim() == "--Select--")
            {
                htParam.Add("@TrnType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@TrnType", ddltrntype.SelectedItem.ToString().Trim());
            }
            htParam.Add("@TrnLoc", txttrnloc.Text.ToString().Trim());
            htParam.Add("@TrnInst", txtTrnInst.Text.ToString().Trim());
            htParam.Add("@Acc", txtAcc.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstTrnInst", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstTrnLoc.DataSource = dsResult.Tables[0];
                dgMstTrnLoc.DataBind();
                trMstTrnInst.Visible = true;
                trtitle.Visible = true;
                //tblExmCntrdtlValue.Visible = false;
            }
            else
            {
                dgMstTrnLoc.DataSource = null;
                dgMstTrnLoc.DataBind();
                trMstTrnInst.Visible = false;
                trtitle.Visible = false;
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

    #region Button ADDNEW
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        tblTrn.Visible = true;
        PopulateTrnTypeVal();
    }
    #endregion

    #region Button Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        dgMstTrnLoc.DataSource = null;
        dgMstTrnLoc.DataBind();
        trMstTrnInst.Visible = false;
        trtitle.Visible = false;
        tblTrn.Visible = false;
    }
    #endregion

    #region Button ADD
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        htParam.Add("@TrnType", ddlTrnTypeVal.SelectedValue);
        htParam.Add("@TrnInstDesc01", txtTrnInstVal.Text.ToString().Trim());
        htParam.Add("@AccLocCode", txtAccVal.Text.ToString().Trim());
        htParam.Add("@IsActive", "1");
        htParam.Add("@TrnCentreType", "TrnInstitute");
        htParam.Add("@CreatedBy", Session["UserID"].ToString());
        htParam.Add("@TrnLocDesc", txttrnlocVal.Text.ToString().Trim());
        hdnCrtDtim.Value = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);
        htParam.Add("@CreatedDtim", DateTime.Parse(hdnCrtDtim.Value).ToString("yyyyMMdd"));
        x = dataAccessRecruit.execute_sprcrecruit("Prc_InsMstTrnLoc", htParam);
        BindMstTrnInst();
    }
    #endregion

    #region BindMstTrnInst
    private void BindMstTrnInst()
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();
            if (ddltrntype.SelectedItem.Text.ToString().Trim() == "--Select--")
            {
                htParam.Add("@TrnType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@TrnType", ddltrntype.SelectedValue.ToString().Trim());
            }
            htParam.Add("@TrnLoc", txttrnloc.Text.ToString().Trim());
            htParam.Add("@TrnInst", txtTrnInst.Text.ToString().Trim());
            htParam.Add("@Acc", txtAcc.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstTrnInst", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstTrnLoc.DataSource = dsResult.Tables[0];
                dgMstTrnLoc.DataBind();
            }
            else
            {
                dgMstTrnLoc.DataSource = null;
                dgMstTrnLoc.DataBind();
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

    #region dgMstTrnLoc RowCommand
    protected void dgMstTrnLoc_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Hashtable htSeqNo = new Hashtable();
        if (e.CommandName == "DeActivate")
        {
            string trncode = Convert.ToString(e.CommandArgument);
            htSeqNo.Add("@Flag", "1");
            htSeqNo.Add("@TrnCode", trncode);
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstTrnInstStatus", htSeqNo);
            BindMstTrnInst();
        }
        else
        {
            string trncode = Convert.ToString(e.CommandArgument);
            htSeqNo.Add("@Flag", "2");
            htSeqNo.Add("@TrnCode", trncode);
            y = dataAccessRecruit.execute_sprcrecruit("Prc_UpdMstTrnInstStatus", htSeqNo);
            BindMstTrnInst();
        }
    }
    #endregion

    #region dgMstTrnLoc RowDataBound
    protected void dgMstTrnLoc_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //Label lbltrncode = new Label();
            //lbltrncode = (Label)e.Row.FindControl("lblTrnCode");
            //hdnTrnCode.Value = lbltrncode.Text;
        }
    }
    #endregion

    #region
    protected void ddltrntype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltrntype.SelectedValue.ToString().Trim() == "ONLINE")
        {
            txttrnloc.Text = "ONLINE";
        }
        else
        {
            txttrnloc.Text = "";
        }
    }
    #endregion

    #region PageIndex
    protected void dgMstTrnLoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            if (ddltrntype.SelectedItem.Text.ToString().Trim() == "--Select--")
            {
                htParam.Add("@TrnType", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@TrnType", ddltrntype.SelectedValue.ToString().Trim());
            }
            htParam.Add("@TrnLoc", txttrnloc.Text.ToString().Trim());
            htParam.Add("@TrnInst", txtTrnInst.Text.ToString().Trim());
            htParam.Add("@Acc", txtAcc.Text.ToString().Trim());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetMstTrnInst", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgMstTrnLoc.DataSource = dsResult.Tables[0];
                dgMstTrnLoc.DataBind();
            }
            else
            {
                dgMstTrnLoc.DataSource = null;
                dgMstTrnLoc.DataBind();
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

    protected void ddlTrnTypeVal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrnTypeVal.SelectedValue.ToString().Trim() == "ONLINE")
        {

            txttrnlocVal.Text = "ONLINE";
            txttrnlocVal.Enabled = false;
        }
        else
        {
            txttrnlocVal.Text = "";
        }
    }
}
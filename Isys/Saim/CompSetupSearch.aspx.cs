#region Namespace
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
#endregion

public partial class Application_ISys_Saim_CompSetupSearch : BaseClass
{
    #region Declaration
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
                
            }

            if (!IsPostBack)
            {
                oCommon.getDropDown(ddlFrequency, "frequency", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlFrequency.Items.Insert(0, new ListItem("-- Select --", ""));
                //txtCmpDesc.Text = "4310.00";
                //txtCmpDesc.Text = Convert.ToString(Convert.ToDecimal(txtCmpDesc.Text) - 110);
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnSearch_Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpTyp", txtCmpTyp.Text.Trim());
            htParam.Add("@CmpDesc", txtCmpDesc.Text.Trim());
            htParam.Add("@Freq", ddlFrequency.SelectedValue.Trim());
            htParam.Add("@EffDt", txtEffDt.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCompSTPSearchDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCompSetup.DataSource = ds.Tables[0];
                gvCompSetup.DataBind();
                ViewState["gv1"] = ds;
                trDetails.Visible = true;
                trDgDetails.Visible = true;
                trrulehdr.Visible = false;
                trrulegrid.Visible = false;
                trruledtlhdr.Visible = false;
                trruledtlsgrid.Visible = false;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvCompSetup.DataSource = ds.Tables[0];
                gvCompSetup.DataBind();
                int columnsCount = gvCompSetup.Columns.Count;
                gvCompSetup.Rows[0].Cells.Clear();
                gvCompSetup.Rows[0].Cells.Add(new TableCell());
                gvCompSetup.Rows[0].Cells[0].ColumnSpan = columnsCount;
                gvCompSetup.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvCompSetup.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gvCompSetup.Rows[0].Cells[0].Font.Bold = true;
                gvCompSetup.Rows[0].Cells[0].Text = "No Records Found!";
                ds.Tables[0].Rows.Clear();
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","btnSearch_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtCmpDesc.Text = "";
            txtCmpTyp.Text = "";
            txtEffDt.Text = "";
            ddlFrequency.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","btnClear_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnAddNew_Click
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CompSetup.aspx?Type=N", false);
        }
        catch (Exception ex)
        {           
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","btnAddNew_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region lnklnkViewRule_Click
    protected void lnklnkViewRule_Click(object sender, EventArgs e)
    {
        try 
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblCompType = (Label)grd.FindControl("lblCompType");
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpType", lblCompType.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("prc_GetCompRuleSTPDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCompRuleSetup.DataSource = ds.Tables[0];
                gvCompRuleSetup.DataBind();
                ViewState["gv2"] = ds;
                trrulehdr.Visible = true;
                trrulegrid.Visible = true;
                trruledtlhdr.Visible = false;
                trruledtlsgrid.Visible = false;
                tr1.Visible = false;
                trkpi.Visible = false;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvCompRuleSetup.DataSource = ds.Tables[0];
                gvCompRuleSetup.DataBind();
                int columnsCount = gvCompRuleSetup.Columns.Count;
                gvCompRuleSetup.Rows[0].Cells.Clear();
                gvCompRuleSetup.Rows[0].Cells.Add(new TableCell());
                gvCompRuleSetup.Rows[0].Cells[0].ColumnSpan = columnsCount;
                gvCompRuleSetup.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvCompRuleSetup.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gvCompRuleSetup.Rows[0].Cells[0].Font.Bold = true;
                gvCompRuleSetup.Rows[0].Cells[0].Text = "No Records Found!";
                ds.Tables[0].Rows.Clear();
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","lnklnkViewRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region lnkViewProduct_Click
    protected void lnkViewProduct_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblCompRuleNo = (Label)grd.FindControl("lblCompRuleNo");
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CompRuleNo", lblCompRuleNo.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("prc_GetCompRuleProdSTPDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCompRuleDtlSetup.DataSource = ds.Tables[0];
                gvCompRuleDtlSetup.DataBind();
                ViewState["gv3"] = ds;
                trruledtlhdr.Visible = true;
                trruledtlsgrid.Visible = true;
                tr1.Visible = false;
                trkpi.Visible = false;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gvCompRuleDtlSetup.DataSource = ds.Tables[0];
                gvCompRuleDtlSetup.DataBind();
                int columnsCount = gvCompRuleDtlSetup.Columns.Count;
                gvCompRuleDtlSetup.Rows[0].Cells.Clear();
                gvCompRuleDtlSetup.Rows[0].Cells.Add(new TableCell());
                gvCompRuleDtlSetup.Rows[0].Cells[0].ColumnSpan = columnsCount;
                gvCompRuleDtlSetup.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                gvCompRuleDtlSetup.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                gvCompRuleDtlSetup.Rows[0].Cells[0].Font.Bold = true;
                gvCompRuleDtlSetup.Rows[0].Cells[0].Text = "No Records Found!";
                ds.Tables[0].Rows.Clear();
                trruledtlhdr.Visible = true;
                trruledtlsgrid.Visible = true;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","lnkViewProduct_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleSetup_RowDataBound
    protected void gvCompRuleSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCompRuleNo = (Label)e.Row.FindControl("lblCompRuleNo");
                e.Row.Cells[9].Text = "<a style=\"color:green;\"  href=\"CompSetup.aspx?Type=E&RuleNo=" + lblCompRuleNo.Text + "\">Edit</a>";
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleSetup_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleDtlSetup_RowDataBound
    protected void gvCompRuleDtlSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblProdCode = (Label)e.Row.FindControl("lblProdCode");
                e.Row.Cells[10].Text = "<a href=\"CompSetup.aspx?Type=E&RuleNo=" + e.Row.Cells[0].Text + "&ProdCode=" + lblProdCode.Text + "\">Edit</a>";
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleDtlSetup_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompSetup_PageIndexChanging
    protected void gvCompSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv1"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvCompSetup.PageIndex = e.NewPageIndex;
            dv.Sort = gvCompSetup.Attributes["SortExpression"];

            if (gvCompSetup.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvCompSetup.DataSource = dv;
            gvCompSetup.DataBind();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompSetup_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion 

    #region gvCompSetup_Sorting
    protected void gvCompSetup_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataSet ds = ViewState["gv1"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompSetup_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleSetup_PageIndexChanging
    protected void gvCompRuleSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv2"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvCompRuleSetup.PageIndex = e.NewPageIndex;
            dv.Sort = gvCompRuleSetup.Attributes["SortExpression"];

            if (gvCompRuleSetup.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvCompRuleSetup.DataSource = dv;
            gvCompRuleSetup.DataBind();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleSetup_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleSetup_Sorting
    protected void gvCompRuleSetup_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataSet ds = ViewState["gv2"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleSetup_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleDtlSetup_PageIndexChanging
    protected void gvCompRuleDtlSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv3"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvCompRuleDtlSetup.PageIndex = e.NewPageIndex;
            dv.Sort = gvCompRuleDtlSetup.Attributes["SortExpression"];

            if (gvCompRuleDtlSetup.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvCompRuleDtlSetup.DataSource = dv;
            gvCompRuleDtlSetup.DataBind();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleDtlSetup_PageIndexChanging", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gvCompRuleDtlSetup_Sorting
    protected void gvCompRuleDtlSetup_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataSet ds = ViewState["gv3"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompSetupSearch","gvCompRuleDtlSetup_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void lnkViewKPI_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lblCompRuleNo = (Label)grd.FindControl("lblCompRuleNo");
        Label lblCompCode = (Label)grd.FindControl("lblCompCode");
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CompRuleNo", lblCompRuleNo.Text.Trim());
        htParam.Add("@CompCode", lblCompCode.Text.Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRulKPIDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgKPI.DataSource = ds;
            dgKPI.DataBind();
            tr1.Visible = true;
            trkpi.Visible = true;
            trruledtlhdr.Visible = false;
            trruledtlsgrid.Visible = false;
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            dgKPI.DataSource = ds.Tables[0];
            dgKPI.DataBind();
            int columnsCount = dgKPI.Columns.Count;
            dgKPI.Rows[0].Cells.Clear();
            dgKPI.Rows[0].Cells.Add(new TableCell());
            dgKPI.Rows[0].Cells[0].ColumnSpan = columnsCount;
            dgKPI.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
            dgKPI.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            dgKPI.Rows[0].Cells[0].Font.Bold = true;
            dgKPI.Rows[0].Cells[0].Text = "No Records Found!";
            ds.Tables[0].Rows.Clear();
            tr1.Visible = true;
            trkpi.Visible = true;
        }

    }
}
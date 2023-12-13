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

public partial class Application_Isys_Saim_MaxRateSearch : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

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
                BindGrid("1", "");
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(string flag, string MRCode)
    {
        try
        {
            htParam = new Hashtable();
            ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@Flag", flag.ToString().Trim());
            htParam.Add("@MrCode", MRCode.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_MaxRateSearch", htParam);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgMaxRate.DataSource = ds;
                        dgMaxRate.DataBind();
                        ViewState["grid"] = ds.Tables[0];
                        if (dgMaxRate.PageCount > 1)
                        {
                            btnnext.Enabled = true;
                        }
                        else
                        {
                            btnnext.Enabled = false;
                        }
                    }
                }
                else
                {
                    ds = null;
                }
            }
            else
            {
                ds = null;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaxRateSetup.aspx?flag=N", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaxRateSearch.aspx", true);
    }
    protected void dgMaxRate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lnkMaxRateCode_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkMaxRateCode = (LinkButton)grd.FindControl("lnkMaxRateCode");
            Response.Redirect("MaxRateSetup.aspx?flag=E&MaxRateCode=" + lnkMaxRateCode.Text.ToString().Trim(), true);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "lnkMaxRateCode_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void lnkSetRule_Click(object sender, EventArgs e)
    //{
    //    GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
    //    LinkButton lnkCmpCode = (LinkButton)grd.FindControl("lnkSetRule");
    //    LinkButton lnkMaxRateCode = (LinkButton)grd.FindControl("lnkMaxRateCode");
    //    //HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
    //    //HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");
    //    //if (hdnKpiOrg.Value == "1002")
    //    //{
    //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
    //    //    return;
    //    //}
    //    //else if (hdnKpiOrg.Value == "1003")
    //    //{
    //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
    //    //    return;
    //    //}

    //    if (lnkMaxRateCode.Text == "1002")
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
    //        return;
    //    }

    //    DataSet ds = new DataSet();
    //    Hashtable htparam = new Hashtable();
    //    htparam.Add("@ROOT_BUSI_CODE", "");
    //    htparam.Add("@BUSI_CODE", "");
    //    htparam.Add("@CMPNSTN_CODE", "");
    //    htparam.Add("@CNTST_CODE", "");
    //    htparam.Add("@KPI_CODE", lnkMaxRateCode.Text);
    //    htparam.Add("@RULE_CODE", "");
    //    htparam.Add("@RULE_SET_KEY", "");

    //    htparam.Add("@CATG_CODE", "");
    //    htparam.Add("@CODE", "");
    //    htparam.Add("@CYCLE_CODE", "");
    //    htparam.Add("@VER_EFF_FROM", "");
    //    htparam.Add("@VER_EFF_TO", "");
    //    htparam.Add("@CREATED_BY", "");


    //    ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTNKPI", htparam, "SAIMConnectionString");

    //    string mapcode = "";
    //    if (ds.Tables.Count > 0)
    //    {
    //        mapcode = ds.Tables[0].Rows[0]["MapCode"].ToString();
    //    }
    //    string flag = string.Empty;
    //    //if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
    //    //{
    //    //    flag = "kpi";
    //    //}
    //    //else
    //    //{
    //    //    flag = "in";
    //    //}
    //    //  Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?&flag=" + flag.Trim() + "&mapcode=" + mapcode + "&KPICOde=" + lnkMaxRateCode.Text + "", true);
    //}

    protected void dgMaxRate_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "dgMaxRate_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgMaxRate.PageIndex;
            dgMaxRate.PageIndex = pageIndex + 1;
            BindGrid("1", "");
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgMaxRate.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgMaxRate.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgMaxRate.PageIndex;
            dgMaxRate.PageIndex = pageIndex - 1;
            BindGrid("1", "");
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkMaxRateCode = (LinkButton)grd.FindControl("lnkMaxRateCode");
            BindGrid("2", lnkMaxRateCode.Text.ToString().Trim());
            BindGrid("1", "");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MaxRateSearch", "lnkDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
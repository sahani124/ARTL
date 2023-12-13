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

public partial class Application_ISys_Saim_BusiYearStp : BaseClass
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
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            Search("S", "FY", dgFinYr);
            Search("S", "CY", dgCalYr);
        }
    }

    protected DataTable SampleTbCrt()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("BUSI_CODE");
        dt.Columns.Add("BUSI_DESC");
        dt.Columns.Add("START_DT");
        dt.Columns.Add("END_DT");

        DataRow dr = dt.NewRow();
        return dt;
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No codes have been defined";
        source.Rows.Clear();
    }
   
    protected void lnkDelFinYr_Click(object sender, EventArgs e)
    {

    }
    protected void lnkDelCalYr_Click(object sender, EventArgs e)
    {

    }
    protected void btnprevfin_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgFinYr.PageIndex;
            dgFinYr.PageIndex = pageIndex - 1;
            Search("S", "FY", dgFinYr);
            txtPageFin.Text = Convert.ToString(Convert.ToInt32(txtPageFin.Text) - 1);
            if (txtPageFin.Text == "1")
            {
                btnprevfin.Enabled = false;
            }
            else
            {
                btnprevfin.Enabled = true;
            }
            btnnextfin.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BusiYearStp", "btnprevfin_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCnclFin_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddFin_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYrCreate.aspx?Type=FY&flag=N", true);
    }
    protected void btnnextcal_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCalYr.PageIndex;
            dgCalYr.PageIndex = pageIndex + 1;
            Search("S", "CY", dgCalYr);
            txtPageCal.Text = Convert.ToString(Convert.ToInt32(txtPageCal.Text) + 1);
            btnprevcal.Enabled = true;
            if (txtPageCal.Text == Convert.ToString(dgCalYr.PageCount))
            {
                btnnextcal.Enabled = false;
            }

            int page = dgCalYr.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BusiYearStp", "btnCnclFin_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevcal_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCalYr.PageIndex;
            dgCalYr.PageIndex = pageIndex - 1;
            Search("S", "CY", dgCalYr);
            txtPageCal.Text = Convert.ToString(Convert.ToInt32(txtPageCal.Text) - 1);
            if (txtPageCal.Text == "1")
            {
                btnprevcal.Enabled = false;
            }
            else
            {
                btnprevcal.Enabled = true;
            }
            btnnextcal.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BusiYearStp", "btnprevcal_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextfin_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgFinYr.PageIndex;
            dgFinYr.PageIndex = pageIndex + 1;
            Search("S", "FY", dgFinYr);
            txtPageFin.Text = Convert.ToString(Convert.ToInt32(txtPageFin.Text) + 1);
            btnprevfin.Enabled = true;
            if (txtPageFin.Text == Convert.ToString(dgFinYr.PageCount))
            {
                btnnextfin.Enabled = false;
            }

            int page = dgFinYr.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BusiYearStp", "btnnextfin_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAddCal_Click(object sender, EventArgs e)
    {
        Response.Redirect("BusiYrCreate.aspx?Type=CY&flag=N", true);
    }
    protected void btnCnclCal_Click(object sender, EventArgs e)
    {

    }

    protected void Search(string flag,string yrtyp, GridView gv)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds;
            gv.DataBind();
            if (yrtyp == "FY")
            {
                if (dgFinYr.PageCount > 1)
                {
                    btnnextfin.Enabled = true;
                }
                else
                {
                    btnnextfin.Enabled = false;
                }
            }
            if (yrtyp == "FY")
            {
                if (dgCalYr.PageCount > 1)
                {
                    btnnextcal.Enabled = true;
                }
                else
                {
                    btnnextcal.Enabled = false;
                }
            }
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], gv);
        }
    }
    
    protected void lnkCalCode_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCalCode = (LinkButton)grd.FindControl("lnkCalCode");
        Response.Redirect("BusiYrCreate.aspx?Type=CY&flag=E&YrCode=" + lnkCalCode.Text.ToString().Trim(), true);

    }
    protected void lnkFyCode_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkFyCode = (LinkButton)grd.FindControl("lnkFyCode");
        Response.Redirect("BusiYrCreate.aspx?Type=FY&flag=E&YrCode=" + lnkFyCode.Text.ToString().Trim(), true);
    }
    protected void lnkStdDefFin_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkFyCode = (LinkButton)grd.FindControl("lnkFyCode");
        HiddenField hdnYrTypFin = (HiddenField)grd.FindControl("hdnYrTypFin");
        Response.Redirect("PopCycStp.aspx?Type=" + hdnYrTypFin.Value.ToString().Trim() + "&flag=V&YrCode=" + lnkFyCode.Text.ToString().Trim(), true);
        ///ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUp('" + hdnYrTypFin.Value.ToString().Trim() + "','" + lnkFyCode.Text.ToString().Trim() + "','" + "V" + "');", true);
    }
    protected void lnkStdDefCal_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCalCode = (LinkButton)grd.FindControl("lnkCalCode");
        HiddenField hdnYrTypCal = (HiddenField)grd.FindControl("hdnYrTypCal");
        Response.Redirect("PopCycStp.aspx?Type=" + hdnYrTypCal.Value.ToString().Trim() + "&flag=V&YrCode=" + lnkCalCode.Text.ToString().Trim(), true);
        ///ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUp('" + hdnYrTypCal.Value.ToString().Trim() + "','" + lnkCalCode.Text.ToString().Trim() + "','" + "V" + "');", true);
    }
}
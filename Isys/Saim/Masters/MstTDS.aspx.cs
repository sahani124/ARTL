using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using DataAccessClassDAL;
using System.Data.SqlClient;

public partial class Application_ISys_Saim_Masters_MstTDS : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string msg = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            txtPage.Text = "1";
            BindGrid();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "funPopup('');", true);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
 
    }

    protected void lnkEditSrvcTax_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCode = (HiddenField)gvRow.FindControl("hdnCode");
        HiddenField hdnIsActive = (HiddenField)gvRow.FindControl("hdnIsActive");
        if (hdnIsActive.Value == "1")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "funPopup('" + hdnCode.Value.ToString().Trim() + "');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Inactive record cannot be edited')", true);
            return;
        }
        
    }
    protected void lnkDelSrvcTax_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        ds.Clear();

        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCode = (HiddenField)gvRow.FindControl("hdnCode");
        HiddenField hdnIsActive = (HiddenField)gvRow.FindControl("hdnIsActive");

        htParam.Add("@Flag", "4");
        htParam.Add("@TaxRulNo", hdnCode.Value.ToString().Trim());
        htParam.Add("@IsActive", hdnIsActive.Value.ToString().Trim());
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMst_cmpTDS", htParam);
        BindGrid();
    }

    protected void gv_SrvcTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive");
                LinkButton lnkDelSrvcTax = (LinkButton)e.Row.FindControl("lnkDelSrvcTax");
                if (hdnIsActive.Value == "1")
                {
                    lnkDelSrvcTax.Text = "InActive";
                    lnkDelSrvcTax.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to deactivate this record?')");
                }
                else if (hdnIsActive.Value == "0")
                {
                    lnkDelSrvcTax.Text = "Active";
                    lnkDelSrvcTax.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to activate this record?')");
                }
            }
        }
    }

    protected void BindGrid()
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@Flag", "1");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMst_cmpTDS", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_SrvcTax.DataSource = ds.Tables[0];
                gv_SrvcTax.DataBind();
                if (gv_SrvcTax.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
            }
            else
            {
                ShowNoResultsFound(ds.Tables[0], gv_SrvcTax);
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }
    }

    protected void ShowNoResultsFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No TDS have been defined";
        source.Rows.Clear();
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv_SrvcTax.PageIndex;
            gv_SrvcTax.PageIndex = pageIndex - 1;
            BindGrid();
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstTDS", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv_SrvcTax.PageIndex;
            gv_SrvcTax.PageIndex = pageIndex + 1;
            BindGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv_SrvcTax.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv_SrvcTax.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstTDS", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btntds_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
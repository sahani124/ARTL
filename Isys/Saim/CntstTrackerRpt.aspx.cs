using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_CntstTrackerRpt : BaseClass
{
    Hashtable htParam = new Hashtable();
    DataSet ds = new DataSet();
    DataAccessClass dtAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPage.Text = "1";
            BindLabelValues();
            BindGrid();
        }
        
    }

    private void BindGrid()
    {
        ds = dtAccess.GetDataSetForPrc_SAIM("Prc_GetCntstTrckrSmmry");
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
                Session["grid"] = ds.Tables[0];
                gvTrckrSmmry.DataSource = ds.Tables[0];
                gvTrckrSmmry.DataBind();
            }
        }
    }

    private void BindLabelValues()
    {
        lblCycleFromVal.Text = "01/02/2015";
        lblCycleToVal.Text = "28/02/2015";
        lblBasedOnVal.Text = "ACCU. CYCLE";
        lblLastCycleRunVal.Text = "13/02/2015";
        lblRepDateVal.Text = "14/02/2015";
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvTrckrSmmry.PageIndex;
            gvTrckrSmmry.PageIndex = pageIndex + 1;
            gvTrckrSmmry.DataSource = (DataTable)Session["grid"];
            gvTrckrSmmry.DataBind();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvTrckrSmmry.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = gvTrckrSmmry.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstTrackerRpt", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvTrckrSmmry.PageIndex;
            gvTrckrSmmry.PageIndex = pageIndex - 1;
            gvTrckrSmmry.DataSource = (DataTable)Session["grid"];
            gvTrckrSmmry.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "CntstTrackerRpt", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
#region Namespaces
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL; 
#endregion

public partial class Application_ISys_Saim_Masters_MstDBFunc : BaseClass
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
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            BindGrid();
        }

    } 
    #endregion

    #region BindGrid
    protected void BindGrid()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetDBFuncDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hdnCnt.Value = ds.Tables[1].Rows[0]["Count"].ToString().Trim();
            //gv_DBFunction.PageSize = Convert.ToInt32(hdnCnt.Value.ToString().Trim());
            gv_DBFunction.DataSource = ds;
            gv_DBFunction.DataBind();
            if (gv_DBFunction.PageCount > 1)
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
            ShowNoRecQualTrg(ds.Tables[0], gv_DBFunction);
        }
        Session["grid"] = ds.Tables[0];
        Session["gridCnt"] = ds.Tables[1];
        Session["TblRowCount"] = 0;
        ViewState["TblRowCount1"] = 0;
    } 
    #endregion

    #region ShowNoRecQualTrg
    private void ShowNoRecQualTrg(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No targets have been defined";
        source.Rows.Clear();
    } 
    #endregion

    #region btnprev_Click
    protected void btnprev_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gv_DBFunction.PageIndex;
            gv_DBFunction.PageIndex = pageIndex - 1;
            //BindGrid();
            //dtTemp = Session["tmpgrid"] as DataTable;
            gv_DBFunction.DataSource = Session["grid"];
            gv_DBFunction.DataBind();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprev.Enabled = false;
            }
            else
            {
                btnprev.Enabled = true;
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
            objErr.LogErr("ISYS-SAIM", "MstDBFunc", "btnprev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnnext_Click
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gv_DBFunction.PageIndex;
            gv_DBFunction.PageIndex = pageIndex + 1;
            //BindGrid();
            gv_DBFunction.DataSource = Session["grid"];
            gv_DBFunction.DataBind();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            btnprev.Enabled = true;
            if (txtpgrwdtrg.Text == Convert.ToString(gv_DBFunction.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv_DBFunction.PageCount;

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstDBFunc", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //////Session["gridTrg"] = null;
        string maxcatgcd = String.Empty;
        DataTable dtV = new DataTable();
        if (Session["grid"] != null)
        {
            dtV = Session["grid"] as DataTable;
            if (dtV.Rows.Count > 0)
            {
                maxcatgcd = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["CODE"].ToString()) + 1).ToString().Trim();
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUp('" + maxcatgcd.ToString().Trim() + "','grid');", true);

    } 
    #endregion

    #region btnBindGrid_Click
    protected void btnBindGrid_Click(object sender, EventArgs e)
    {
        DataTable dtTemp = new DataTable();
        dtTemp = Session["tmpgrid"] as DataTable;
        gv_DBFunction.DataSource = null;
        gv_DBFunction.DataBind();
        gv_DBFunction.DataSource = dtTemp;
        gv_DBFunction.DataBind();
        Session["grid"] = dtTemp;
    }
    #endregion

    #region gv_DBFunction_RowDataBound
    protected void gv_DBFunction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCode = (Label)e.Row.FindControl("lblCode");
            LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
            lnkEditRwdTrg.Attributes.Add("onclick", "funEditPopUp('" + lblCode.Text + "','grid');return false;");
        }
    } 
    #endregion

}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_Masters_PopMstCmpCatg : BaseClass
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
            if (Request.QueryString["code"] != null)
            {
                txtCode.Enabled = false;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                GetFuncDtls();
            }
        }
    }

    public void GetFuncDtls()
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@code", Request.QueryString["code"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMstCmpCatgDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCode.Text = ds.Tables[0].Rows[0]["CODE"].ToString().Trim();
            txtDesc1.Text = ds.Tables[0].Rows[0]["DESC01"].ToString().Trim();
            txtDesc2.Text = ds.Tables[0].Rows[0]["DESC02"].ToString().Trim();
            txtDesc3.Text = ds.Tables[0].Rows[0]["DESC03"].ToString().Trim();
            ddlIsActive.SelectedValue = ds.Tables[0].Rows[0]["ISACTIVE"].ToString().Trim();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //SaveTarget();
        FillGrid();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
    }

    protected void FillGrid()
    {
        try
        {
            //DataTable dt = new DataTable();

            //dt.Columns.Add("CODE");
            //dt.Columns.Add("DB_FUNCNAME");
            //dt.Columns.Add("DESC01");
            //dt.Columns.Add("DESC02");
            //dt.Columns.Add("DESC03");
            //dt.Columns.Add("ISACTIVE");

            //dt = (DataTable)Session["grid"];

            //if (txtCode.Text.Trim() != "")
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["CODE"] = txtCode.Text.Trim();
            //    dr["DB_FUNCNAME"] = txtCode.Text.Trim();
            //    dr["DESC01"] = txtDesc1.Text.Trim();
            //    dr["DESC02"] = txtDesc2.Text.Trim();
            //    dr["DESC03"] = txtDesc3.Text.Trim();
            //    dr["ISACTIVE"] = ddlIsActive.SelectedValue.Trim();
            //    dt.Rows.Add(dr);
            //    Session["tmpgrid"] = dt;
            //}
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopMstCmpCatg", "FillGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
}
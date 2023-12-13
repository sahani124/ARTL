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

public partial class Application_ISys_Saim_ViewReport : BaseClass
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
            ddlCompCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlCycCd.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlCntstCd.Items.Insert(0, new ListItem("-- SELECT --", ""));
            FillDropDowns(ddlCompCode, "30", "");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlCompCode.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Compensation Code')", true);
            return;
        }
        if (ddlCntstCd.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Contestant Code')", true);
            return;
        }
        BindGrid();
    }

    protected void FillDropDowns(DropDownList ddl, string val,string cmpcode)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        ht.Add("@CMPNSTN_CODE", cmpcode.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkView = (LinkButton)grd.FindControl("lnkView");
    }

    protected void BindGrid()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", ddlCompCode.SelectedValue.ToString().Trim());
        htParam.Add("@CYCLE_CODE", ddlCycCd.SelectedValue.ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", ddlCntstCd.SelectedValue.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpCntStmtDtlsRpt", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgCmp.DataSource = ds;
            dgCmp.DataBind();
            ViewState["grid"] = ds.Tables[0];
        }
    }
    protected void ddlCompCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlCntstCd, "32", ddlCompCode.SelectedValue.ToString().Trim());
        FillDropDowns(ddlCycCd, "31", ddlCompCode.SelectedValue.ToString().Trim());
    }

    protected void BindGrid(string cmpcd, string cntstcd)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", cmpcd.ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpCntStmtDtlsRpt", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgCmp.DataSource = ds;
            dgCmp.DataBind();
            ViewState["grid"] = ds.Tables[0];
        }
    }
}
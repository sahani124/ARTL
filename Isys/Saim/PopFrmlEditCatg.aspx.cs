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
using System.Windows.Forms;

public partial class Application_ISys_Saim_PopFrmlEditCatg : BaseClass
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
            FillDropDowns(ddlFunckeyTrg, "7");
            FillddlKPI(ddlKPICode, "Prc_KPISearch", "1", "KPI_DESC_01", "KPI_CODE");
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected void FillddlKPI(DropDownList ddl, string proc, string flag, string text, string value)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@KPICode","10000001");
        htParam.Add("@Flag", "1");
        ddl.Items.Clear();
        drRead = objDal.Common_exec_reader_prc_SAIM(proc.ToString().Trim(), htParam);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected void ddlFunckeyTrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFrmlTrg.Text = "=" + ddlFunckeyTrg.SelectedItem.Text.ToString().Trim() + "(";
    }

    protected void ddlKPICode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFrmlTrg.Text = txtFrmlTrg.Text + ddlKPICode.SelectedItem.Text.ToString().Trim() + ")";
    }
}
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

public partial class Application_ISys_Saim_PopRuleSet : BaseClass
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
            FillddlVal(ddlRulSetKey, "", "", "1", "RULE_SET_KEY", "RULE_SET_KEY");
            ddlRulSetKey.SelectedIndex = 1;
            dgCR.DataSource = CRYFWD_DT();
            dgCR.DataBind();
        }
        lblNote.Text = "Note:Reward Computation Rule:- Accumulation Cycle or Reward Release Cycle";
    }

    protected void FillddlVal(DropDownList ddl, string rulsetky, string catgcd, string flag, string text, string value)
    {
        ds = new DataSet();
        htParam = new Hashtable();
        ds.Clear();
        htParam.Clear();
        ddl.Items.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        if (Request.QueryString["compcode"] != null)///@CatgCode
        {
            htParam.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        }
        if (Request.QueryString["rultyp"] != null)
        {
            htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
        }

        htParam.Add("@RulSetKey", rulsetky.ToString().Trim());
        htParam.Add("@CatgCode", catgcd.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwrdRuleVal", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected DataTable CRYFWD_DT()
    {
        DataTable dtCR = new DataTable();
        dtCR.Clear();
        dtCR.Columns.Add("KPI_CODE");
        dtCR.Columns.Add("KPI_DESC");
        dtCR.Columns.Add("CARRY_FWD");
        dtCR.Columns.Add("RWD_CMP_RULE");
        dtCR.Columns.Add("UNIT_TYPE");
        dtCR.Columns.Add("MAX_LIMIT");

        DataRow dr = dtCR.NewRow();
        dr["KPI_CODE"] = "10000001";
        dr["KPI_DESC"] = "WRP PREMIUM";
        dr["CARRY_FWD"] = "Yes";
        dr["RWD_CMP_RULE"] = "Accumulation Cycle";
        dr["UNIT_TYPE"] = "AMOUNT";
        dr["MAX_LIMIT"] = "100000.00";
        dtCR.Rows.Add(dr);
        return dtCR;
    }
}
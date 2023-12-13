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

public partial class Application_ISys_Saim_Masters_PopMstTDS : BaseClass
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
            ddlTaxType.Items.Insert(0, new ListItem("-- SELECT --", ""));
            FillDropDowns("29", "1", ddlTaxType);
            if (Request.QueryString["code"] != null)
            {
                if (Request.QueryString["code"].ToString().Trim() != "")
                {
                    FillDetails(Request.QueryString["code"].ToString().Trim());
                    ddlTaxType.Enabled = false;
                    txtTaxType.Enabled = false;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ds.Clear();
        if (Request.QueryString["code"] != null)
        {
            if (Request.QueryString["code"].ToString().Trim() != "")
            {
                htParam.Add("@Flag", "3");
                htParam.Add("@TaxRulNo", Request.QueryString["code"].ToString().Trim());
            }
            else
            {
                htParam.Add("@Flag", "2");
            }
        }
        else
        {
            htParam.Add("@Flag", "2");
        }
        htParam.Add("@TaxType", ddlTaxType.SelectedValue.ToString().Trim());
        htParam.Add("@PayeeType", txtPayTyp.Text.ToString().Trim());
        htParam.Add("@TDSRate", txtTaxRate.Text.ToString().Trim());
        htParam.Add("@TDSCode", txtTaxCode.Text.ToString().Trim());
        htParam.Add("@TaxAmtFrm", txtTaxFrm.Text.ToString().Trim());
        htParam.Add("@TaxAmtTo", txtTaxTo.Text.ToString().Trim());
        if (txtEffDate.Text != "")
        {
            htParam.Add("@EffDate", Convert.ToDateTime(txtEffDate.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@EffDate", DBNull.Value);
        }
        if (txtCseDate.Text != "")
        {
            htParam.Add("@CeaseDate", Convert.ToDateTime(txtCseDate.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@CeaseDate", DBNull.Value);
        }
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMst_cmpTDS", htParam);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
    }

    protected void ddlTaxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTaxType.Text = ddlTaxType.SelectedValue.ToString().Trim();
    }

    protected void FillDropDowns(string flag, string typflg, DropDownList ddl)
    {
        ddl.Items.Clear();
        htParam.Add("@Flag", flag.Trim());
        htParam.Add("@TYPFLG", typflg.Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", htParam);
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

    protected void FillDetails(string taxrulno)
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@Flag", "1");
        htParam.Add("@TaxRulNo", taxrulno.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMst_cmpTDS", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTaxType.Text = ds.Tables[0].Rows[0]["TaxTypeDesc"].ToString().Trim();
                ddlTaxType.SelectedValue = ds.Tables[0].Rows[0]["TaxType"].ToString().Trim();
                txtTaxCode.Text = ds.Tables[0].Rows[0]["TDSCode"].ToString().Trim();
                txtPayTyp.Text = ds.Tables[0].Rows[0]["PayeeType"].ToString().Trim();
                txtCseDate.Text = ds.Tables[0].Rows[0]["ExpDate"].ToString().Trim();
                txtEffDate.Text = ds.Tables[0].Rows[0]["EffDate"].ToString().Trim();
                txtTaxFrm.Text = ds.Tables[0].Rows[0]["TAXAMTFRM"].ToString().Trim();
                txtTaxTo.Text = ds.Tables[0].Rows[0]["TAXAMTTO"].ToString().Trim();
                txtTaxRate.Text = ds.Tables[0].Rows[0]["TDSRate"].ToString().Trim();
            }
        }
    }
}
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

public partial class Application_ISys_Saim_Masters_PopMstSrvcTax : BaseClass
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
            ddlChn.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlSubChn.Items.Insert(0, new ListItem("-- SELECT --", ""));
            FillDropDowns("29", "0", ddlTaxType);
            oCommon.getRadio(rblTaxPytoAgt, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            funchnlpopup(ddlChn);
            if (Request.QueryString["code"] != null)
            {
                if (Request.QueryString["code"].ToString().Trim() != "")
                {
                    FillDetails(Request.QueryString["code"].ToString().Trim(), Request.QueryString["bizsrc"].ToString().Trim(), Request.QueryString["chncls"].ToString().Trim());
                    ddlTaxType.Enabled = false;
                    ddlChn.Enabled = false;
                    ddlSubChn.Enabled = false;
                    txtTaxType.Enabled = false;
                }
            }
        }
    }

    protected void FillDropDowns(string flag, string typflg,DropDownList ddl)
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
    protected void ddlTaxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTaxType.Text = ddlTaxType.SelectedValue.ToString().Trim();
    }
    protected void ddlChn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChn.SelectedValue != "")
        {
            GetChnCls();
        }
        else
        {
            ddlSubChn.Items.Clear();
            ddlSubChn.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        ddlChn.Focus();
    }

    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDal.Common_exec_reader_prc_SAIM("Prc_getchannels", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "ChannelDesc01";
                ddl.DataValueField = "BizSrc";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopMstSrvcTax", "funchnlpopup", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetChnCls()
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@BizSrc", ddlChn.SelectedValue.ToString().Trim());

            drRead = objDal.Common_exec_reader_prc("prc_GetChnCls", ht);
            if (drRead.HasRows)
            {
                ddlSubChn.DataSource = drRead;
                ddlSubChn.DataTextField = "ChnClsDesc01";
                ddlSubChn.DataValueField = "ChnCls";
                ddlSubChn.DataBind();
            }
            drRead.Close();
            ddlSubChn.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopMstSrvcTax", "GetChnCls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDetails(string taxrulno, string bizsrc, string chncls)
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@Flag", "1");
        htParam.Add("@TaxRulNo", taxrulno.ToString().Trim());
        htParam.Add("@BizSrc", bizsrc.ToString().Trim());
        htParam.Add("@Chncls", chncls.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsUpdDelSrvcTax", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTaxType.Text = ds.Tables[0].Rows[0]["TAXTYPE"].ToString().Trim();
                /////txtTaxTypDsc.Text = ds.Tables[0].Rows[0]["TAXTYPEDSC"].ToString().Trim();
                ddlChn.SelectedValue = ds.Tables[0].Rows[0]["BIZSRC"].ToString().Trim();
                GetChnCls();
                ddlTaxType.SelectedValue = ds.Tables[0].Rows[0]["TAXTYPE"].ToString().Trim();
                ddlSubChn.SelectedValue = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();
                rblTaxPytoAgt.SelectedValue = ds.Tables[0].Rows[0]["TaxPayToAgent"].ToString().Trim();
                txtEffDate.Text = ds.Tables[0].Rows[0]["EFFDATE"].ToString().Trim();
                txtCseDate.Text = ds.Tables[0].Rows[0]["EXPDATE"].ToString().Trim();
                txtAgtBONRt.Text = ds.Tables[0].Rows[0]["AgentBorneRatio"].ToString().Trim();
                txtCmpBONRt.Text = ds.Tables[0].Rows[0]["CmpBorneRatio"].ToString().Trim();
                txtTaxFrm.Text = ds.Tables[0].Rows[0]["TAXAMTFRM"].ToString().Trim();
                txtTaxTo.Text = ds.Tables[0].Rows[0]["TAXAMTTO"].ToString().Trim();
                txtTaxRate.Text = ds.Tables[0].Rows[0]["TAXRATE"].ToString().Trim();
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
        htParam.Add("@BizSrc", ddlChn.SelectedValue.ToString().Trim());
        htParam.Add("@Chncls", ddlSubChn.SelectedValue.ToString().Trim());

        htParam.Add("@CmpBrnRatio", txtCmpBONRt.Text.ToString().Trim());
        htParam.Add("@AgentBrnRatio", txtAgtBONRt.Text.ToString().Trim());
        htParam.Add("@TaxPayToAgt", rblTaxPytoAgt.SelectedValue.ToString().Trim());
        htParam.Add("@TaxAmtFrm", txtTaxFrm.Text.ToString().Trim());
        htParam.Add("@TaxAmtTo", txtTaxTo.Text.ToString().Trim());
        htParam.Add("@TaxRate", txtTaxRate.Text.ToString().Trim());
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
            htParam.Add("@ExpDate", Convert.ToDateTime(txtCseDate.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@ExpDate", DBNull.Value);
        }
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsUpdDelSrvcTax", htParam);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
    }
}
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

public partial class Application_ISys_Saim_ViewStmtDetails : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    string sUserId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        sUserId = HttpContext.Current.Session["UserID"].ToString();

        if (!IsPostBack)
        {
            FillCmp();
            BindCycleGrid();
        }
    }

    protected void FillCmp()
    {
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_FillCmpCntstDtls", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblCntstCdVal.Text = ds.Tables[0].Rows[0]["CNTSTNT_CODE"].ToString().Trim();
            lblCompCodeVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
            lblCompDesc1Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
            lblCompDesc2Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
            lblAccCycVal.Text = ds.Tables[0].Rows[0]["ACC_CYCLE_DESC"].ToString().Trim();
            lblAccYrVal.Text = ds.Tables[0].Rows[0]["ACC_YEAR_DESC"].ToString().Trim();
            lblCompTypVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString().Trim();
            lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM_CMP"].ToString().Trim();
            lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO_CMP"].ToString().Trim();
            lblSlsChnlVal.Text = ds.Tables[0].Rows[0]["CHN_DESC"].ToString().Trim();
            lblSbClsVal.Text = ds.Tables[0].Rows[0]["CHNCLS_DESC"].ToString().Trim();
            lblMemTypVal.Text = ds.Tables[0].Rows[0]["MEMTYPE_DESC"].ToString().Trim();
            lblEffFrmValCnt.Text = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
            lblEffToValCnt.Text = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
            lblFinYrVal.Text = ds.Tables[0].Rows[0]["FIN_YEAR_CMP"].ToString().Trim();
            lblVerVal.Text = ds.Tables[0].Rows[0]["VER_NO_CNT"].ToString().Trim();
            hdnChn.Value = ds.Tables[0].Rows[0]["CHN"].ToString().Trim();
            hdnSbChn.Value = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();
            hdnMemType.Value = ds.Tables[0].Rows[0]["MEMTYPE"].ToString().Trim();
            lblAccCycleValue.Text = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE_DESC"].ToString().Trim();
            lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["REWARD_ACC_CYCLE_DESC"].ToString().Trim();
            lblBusYr.Text = ds.Tables[0].Rows[0]["BUSI_YEAR"].ToString().Trim();
            lblVersion.Text = ds.Tables[0].Rows[0]["VER_NO"].ToString().Trim();
            hdnVersnFrm1.Value = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
            hdnVrsnTo1.Value = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
            hdnstatusval.Value = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
        }
    }

    protected void BindCycleGrid()
    {
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        }
        ds = objDal.DelDataSetForPrc_SAIM("Prc_GetRwdForCycle", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgCycGrd.DataSource = ds;
                dgCycGrd.DataBind();
            }
            else
            {
                dgCycGrd.DataSource = null;
                dgCycGrd.DataBind();
            }
        }
        else
        {
            dgCycGrd.DataSource = null;
            dgCycGrd.DataBind();
        }
    }
    protected void lnkRwdAmt_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCycCode = (HiddenField)gvRow.FindControl("hdnCycCode");
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        }
        htParam.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        ds = objDal.DelDataSetForPrc_SAIM("Prc_GetAchvment", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgAchv.DataSource = ds;
                dgAchv.DataBind();
            }
            else
            {
                dgAchv.DataSource = null;
                dgAchv.DataBind();
            }
        }
        else
        {
            dgAchv.DataSource = null;
            dgAchv.DataBind();
        }
        mdlView.Show();
    }
}
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

public partial class Application_ISys_Saim_PopRuleSetup : BaseClass
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
            if (Request.QueryString["Type"].ToString().Trim() == "KPIMST")
            {
                divcmphdrcollapse.Visible = false;
                divStdDefPrdtDtls.Visible = true;
                divStdDefLOBDtls.Visible = true;
                divStdDefPrdDtls.Visible = false;
            }
            else
            {
                divcmphdrcollapse.Visible = true;
                divStdDefPrdtDtls.Visible = true;
                divStdDefLOBDtls.Visible = true;
                divStdDefPrdDtls.Visible = true;
                if (Request.QueryString["Type"].ToString().Trim() == "KPI")
                {
                    hdnVerFrm.Value = Request.QueryString["VerFrm"].ToString().Trim();
                    hdnVerTo.Value = Request.QueryString["VerTo"].ToString().Trim();
                    hdnRulCode.Value = Request.QueryString["RulCode"].ToString().Trim();
                }
                hdnRulSetKy.Value = Request.QueryString["CntstCode"].ToString().Trim();
                hdnKPICd.Value = Request.QueryString["KpiCode"].ToString().Trim();
                hdnCompCode.Value = Request.QueryString["CompCode"].ToString().Trim();
                hdnCntstCode.Value = Request.QueryString["CntstCode"].ToString().Trim();
                hdnRulSetKy.Value = Request.QueryString["RulSetKey"].ToString().Trim();
                
                FillCmp();
                ////BindPrdctGrid();
            }
            ////BindLOBGrid();
        }
        btnAddStdPrd.Attributes.Add("onclick", "funPopUpPrdct('divPrdct');return false;");
        btnAddStdLOB.Attributes.Add("onclick", "funPopUpLOB('divLOB');return false;");
        
    }
    protected void FillCmp()
    {
        if (Request.QueryString["CompCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CompCode"].ToString().Trim());
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
            lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
            lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
            lblFinYrVal.Text = ds.Tables[0].Rows[0]["FIN_YEAR_CMP"].ToString().Trim();
            lblVerVal.Text = ds.Tables[0].Rows[0]["VER_NO_CNT"].ToString().Trim();
            //hdnChn.Value = ds.Tables[0].Rows[0]["CHN"].ToString().Trim();
            //hdnSbChn.Value = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();
            //hdnMemType.Value = ds.Tables[0].Rows[0]["MEMTYPE"].ToString().Trim();
            lblAccCycleValue.Text = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE_DESC"].ToString().Trim();
            lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["REWARD_ACC_CYCLE_DESC"].ToString().Trim();
            //hdnVersnFrm1.Value = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
            //hdnVrsnTo1.Value = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
        }
    }
    protected void BindPrdctGrid()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"].ToString().Trim() == "KPI")
        {
            htParam.Add("@CompCode", hdnCompCode.Value);
            htParam.Add("@CntstCode", hdnCntstCode.Value);
            htParam.Add("@KPICode", hdnKPICd.Value);
            htParam.Add("@RuleCode", hdnRulCode.Value);
            htParam.Add("@RuleSetKey", hdnRulSetKy.Value);
            htParam.Add("@VerEffFrom", Convert.ToDateTime(hdnVerFrm.Value.ToString().Trim()));
            htParam.Add("@VerEffTo", Convert.ToDateTime(hdnVerTo.Value.ToString().Trim()));
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "KPITRGT")
        {
            htParam.Add("@MappCode", Request.QueryString["MAPPED_Code"].ToString().Trim());
        }
        htParam.Add("@Flag", Request.QueryString["Type"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetPrdctWghtgDef", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgPrdctGrid.DataSource = ds;
            dgPrdctGrid.DataBind();
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], dgPrdctGrid, "Product");
        }
        Session["PrdctLvlDefBind"] = ds.Tables[0];
    }
    protected void BindLOBGrid()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"].ToString().Trim() == "KPI")
        {
        htParam.Add("@CompCode", hdnCompCode.Value);
        htParam.Add("@CntstCode", hdnCntstCode.Value);
        htParam.Add("@KPICode", hdnKPICd.Value);
        htParam.Add("@RuleCode", hdnRulCode.Value);
        htParam.Add("@RuleSetKey", hdnRulSetKy.Value);
        htParam.Add("@VerEffFrom", Convert.ToDateTime(hdnVerFrm.Value.ToString().Trim()));
        htParam.Add("@VerEffTo", Convert.ToDateTime(hdnVerTo.Value.ToString().Trim()));
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "KPITRGT")
        {
            htParam.Add("@MappCode", Request.QueryString["MAPPED_Code"].ToString().Trim());
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "KPIMST")
        {
            if (Request.QueryString["KpiCode"] != null)
            {
                htParam.Add("@KPICode", Request.QueryString["KpiCode"].ToString().Trim());
            }
        }
        htParam.Add("@Flag", Request.QueryString["Type"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetLOBWghtgDef", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgLOBGrid.DataSource = ds;
            dgLOBGrid.DataBind();
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], dgLOBGrid, "LOB");
        }
        Session["LOBLvlDefBind"] = ds.Tables[0];
    }
    private void ShowNoResultFound(DataTable source, GridView gv,string s)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No "+ s +" Level Weightage have been defined";
        source.Rows.Clear();
    }
    protected void btnprevStdLOB_Click(object sender, EventArgs e)
    {

    }
    protected void btnnextStdLOB_Click(object sender, EventArgs e)
    {

    }   
    protected void btnSaveStdLOB_Click(object sender, EventArgs e)
    {
        HiddenField hdnMappCode = new HiddenField();
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"].ToString().Trim() == "KPI")
        {
            htParam.Add("@CompCode", hdnCompCode.Value.ToString().Trim());
            htParam.Add("@CntstCode", hdnCntstCode.Value.ToString().Trim());
            htParam.Add("@KPICode", hdnKPICd.Value.ToString().Trim());
            htParam.Add("@RuleCode", hdnRulCode.Value.ToString().Trim());
            htParam.Add("@RuleSetKey", hdnRulSetKy.Value.ToString().Trim());
            htParam.Add("@VerEffFrom", Convert.ToDateTime(hdnVerFrm.Value.ToString().Trim()));
            htParam.Add("@VerEffTo", Convert.ToDateTime(hdnVerTo.Value.ToString().Trim()));
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMappedCodeDtls", htParam);

            hdnMappCode.Value = ds.Tables[0].Rows[0]["MAPPED_CODE"].ToString().Trim();
        }
        else
        {
            hdnMappCode.Value = Request.QueryString["MAPPED_Code"].ToString().Trim();
        }
        DataTable dtStdLOB = new DataTable();
        dtStdLOB = Session["LOBLvlDefBind"] as DataTable;
        DataSet dsStdLOB = new DataSet();
        dsStdLOB.Clear();
        Hashtable htStdLOB = new Hashtable();
        htStdLOB.Clear();
        htStdLOB.Add("@Mapped_code", hdnMappCode.Value);
        htStdLOB.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelLOBWghtg", htStdLOB);

        List<string> lstLOBName = new List<string>();
        List<string> lstLOBFreq = new List<string>();
        List<string> lstLOBConsider = new List<string>();
        List<string> lstLOBTyp = new List<string>();
        List<string> lstWtgh = new List<string>();
        List<string> lstLOBCode = new List<string>();

        for (int intRowCount = 0; intRowCount <= dgLOBGrid.Rows.Count - 1; intRowCount++)
        {
            HiddenField hdnLOBName = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBName");
            lstLOBName.Add(hdnLOBName.Value.ToString().Trim());
            HiddenField hdnLOBFreq = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBFreq");
            lstLOBFreq.Add(hdnLOBFreq.Value.ToString().Trim());
            HiddenField hdnLOBConsider = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBConsider");
            lstLOBConsider.Add(hdnLOBConsider.Value.ToString().Trim());
            HiddenField hdnLOBTyp = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBTyp");
            lstLOBTyp.Add(hdnLOBTyp.Value.ToString().Trim());
            HiddenField hdnLOBWghtg = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBWghtg");
            lstWtgh.Add(hdnLOBWghtg.Value.ToString().Trim());
            HiddenField hdnLOBCode = (HiddenField)dgLOBGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBCode");
            lstLOBCode.Add(hdnLOBCode.Value.ToString().Trim());
        }

        for (int intDataCount = 0; intDataCount <= lstLOBName.Count - 1; intDataCount++)
        {
            htStdLOB.Clear();
            htStdLOB.Add("@Mapped_code", hdnMappCode.Value);
            htStdLOB.Add("@LOB_DESC", lstLOBName[intDataCount]);
            htStdLOB.Add("@FREQ", lstLOBFreq[intDataCount]);
            htStdLOB.Add("@CONSIDER", lstLOBConsider[intDataCount]);
            htStdLOB.Add("@TYPE", lstLOBTyp[intDataCount]);
            htStdLOB.Add("@WEIGHTAGE", lstWtgh[intDataCount]);
            htStdLOB.Add("@LOB_CODE", lstLOBCode[intDataCount]);
            //htStdLOB.Add("@PROD_CODE", dtStdLOB.Rows[intRowCount]["PROD_CODE"].ToString().Trim());
            dsStdLOB = objDal.GetDataSetForPrc_SAIM("Prc_InsLOBWghtDef", htStdLOB);
        }

        //hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
        mdlpopup.Show();
        if (Request.QueryString["Type"].ToString().Trim() == "KPIMST")
        {
            lbl3.Text = "LOB level weightage definitions saved successfully";
            if (Request.QueryString["KpiCode"] != null)
            {
                lbl4.Text = "KPI Code:" + Request.QueryString["KpiCode"].ToString().Trim();
            }
            if (Request.QueryString["KpiDesc"] != null)
            {
                lbl5.Text = "KPI Description:" + Request.QueryString["KpiDesc"].ToString().Trim();
            }
        }
        else
        {
            lbl3.Text = "LOB level weightage definitions saved successfully";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
        }
        //btnSaveRwdRul.Enabled = true;
    }
    protected void btnprevStdPrd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtnxtPrdct = new DataTable();
            dtnxtPrdct = Session["PrdctLvlDef"] as DataTable;
            dgPrdctGrid.DataSource = dtnxtPrdct;
            dgPrdctGrid.DataBind();
            int pageIndex = dgPrdctGrid.PageIndex;
            dgPrdctGrid.PageIndex = pageIndex - 1;
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            txtPageStdPrd.Text = Convert.ToString(Convert.ToInt32(txtPageStdPrd.Text) - 1);
            //btnprevStdPrd.Enabled = true;
            int page = dgPrdctGrid.PageCount;
            if (Convert.ToInt32(txtPageStdPrd.Text) >= dgPrdctGrid.PageCount)
            {
                btnnextStdPrd.Enabled = false;
            }
            else
            {
                btnnextStdPrd.Enabled = true;
            }
            if (Convert.ToInt32(txtPageStdPrd.Text) > 1)
            {
                btnprevStdPrd.Enabled = true;
            }
            else
            {
                btnprevStdPrd.Enabled = false;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRuleSetup", "btnprevStdPrd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextStdPrd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtnxtPrdct = new DataTable();
            dtnxtPrdct = Session["PrdctLvlDef"] as DataTable;
            dgPrdctGrid.DataSource = dtnxtPrdct;
            dgPrdctGrid.DataBind();
            int pageIndex = dgPrdctGrid.PageIndex;
            dgPrdctGrid.PageIndex = pageIndex + 1;
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            txtPageStdPrd.Text = Convert.ToString(Convert.ToInt32(txtPageStdPrd.Text) + 1);
            //btnprevStdPrd.Enabled = true;
            int page = dgPrdctGrid.PageCount;
            if (Convert.ToInt32(txtPageStdPrd.Text) >= dgPrdctGrid.PageCount)
            {
                btnnextStdPrd.Enabled = false;
            }
            else
            {
                btnnextStdPrd.Enabled = true;
            }
            if (Convert.ToInt32(txtPageStdPrd.Text) > 1)
            {
                btnprevStdPrd.Enabled = true;
            }
            else
            {
                btnprevStdPrd.Enabled = false;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRuleSetup", "btnnextStdPrd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSaveStdPrd_Click(object sender, EventArgs e)
    {
        HiddenField hdnMappCode = new HiddenField();
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"].ToString().Trim() == "KPI")
        {
        htParam.Add("@CompCode", hdnCompCode.Value);
        htParam.Add("@CntstCode", hdnCntstCode.Value);
        htParam.Add("@KPICode", hdnKPICd.Value);
        htParam.Add("@RuleCode", hdnRulCode.Value);
        htParam.Add("@RuleSetKey", hdnRulSetKy.Value);
        htParam.Add("@VerEffFrom", Convert.ToDateTime(hdnVerFrm.Value.ToString().Trim()));
        htParam.Add("@VerEffTo", Convert.ToDateTime(hdnVerTo.Value.ToString().Trim()));
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMappedCodeDtls", htParam);
        
        hdnMappCode.Value = ds.Tables[0].Rows[0]["MAPPED_CODE"].ToString().Trim();
        }
        else
        {
            hdnMappCode.Value = Request.QueryString["MAPPED_Code"].ToString().Trim();
        }
        DataTable dtPrdctSav = new DataTable();
        dtPrdctSav = Session["PrdctLvlDefBind"] as DataTable;
        DataSet dsPrdctSav = new DataSet();
        dsPrdctSav.Clear();
        Hashtable htPrdctSav = new Hashtable();
        htPrdctSav.Clear();
        htPrdctSav.Add("@Mapped_code", hdnMappCode.Value);
        htPrdctSav.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelPrdctWghtDef", htPrdctSav);

        List<string> lstProdName = new List<string>();
        List<string> lstPrdFreq = new List<string>();
        List<string> lstPrdConsider = new List<string>();
        List<string> lstPrdTyp = new List<string>();
        List<string> lstPrdWtgh = new List<string>();
        List<string> lstPrdCode = new List<string>();
        List<string> lstLOBCode = new List<string>();

        for (int intRowCount = 0; intRowCount <= dgPrdctGrid.Rows.Count - 1; intRowCount++)
        {
            HiddenField hdnProdName = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnPrdName");
            lstProdName.Add(hdnProdName.Value.ToString().Trim());
            HiddenField hdnFreq = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnFreq");
            lstPrdFreq.Add(hdnFreq.Value.ToString().Trim());
            HiddenField hdnConsider = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnConsider");
            lstPrdConsider.Add(hdnConsider.Value.ToString().Trim());
            HiddenField hdnTyp = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnTyp");
            lstPrdTyp.Add(hdnTyp.Value.ToString().Trim());
            HiddenField hdnWghtg = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnWghtg");
            lstPrdWtgh.Add(hdnWghtg.Value.ToString().Trim());
            HiddenField hdnPrdCode = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnPrdCode");
            lstPrdCode.Add(hdnPrdCode.Value.ToString().Trim());
            HiddenField hdnLOBCode = (HiddenField)dgPrdctGrid.Rows[intRowCount].Cells[0].FindControl("hdnLOBCode");
            lstLOBCode.Add(hdnLOBCode.Value.ToString().Trim());
        }

        for (int intDataCount = 0; intDataCount <= dtPrdctSav.Rows.Count - 1; intDataCount++)
        {
            htPrdctSav.Clear();
            htPrdctSav.Add("@Mapped_code", hdnMappCode.Value);
            htPrdctSav.Add("@PROD_DESC", lstProdName[intDataCount]);
            htPrdctSav.Add("@FREQ", lstPrdFreq[intDataCount]);
            htPrdctSav.Add("@CONSIDER",lstPrdConsider[intDataCount]);
            htPrdctSav.Add("@TYPE",lstPrdTyp[intDataCount]);
            htPrdctSav.Add("@WEIGHTAGE",lstPrdWtgh[intDataCount]);
            htPrdctSav.Add("@LOB_CODE", lstLOBCode[intDataCount]);
            htPrdctSav.Add("@PROD_CODE", lstPrdCode[intDataCount]);
            dsPrdctSav = objDal.GetDataSetForPrc_SAIM("Prc_InsPrdctWghtDef", htPrdctSav);
        }
        
        //hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
        mdlpopup.Show();
        lbl3.Text = "Product level weightage definitions saved successfully";
        lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
        lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
        //btnSaveRwdRul.Enabled = true;
    }
    protected void btnqual_Click(object sender, EventArgs e)
    {
        //Session["PrdctLvlDef"] = null;
        //dt and dtR used for showing data while dtBind and dtRBind are used for saving the data
        string maxrulecode = String.Empty;
        string maxrulsetcd = String.Empty;
        DataTable dtR = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtRBind = new DataTable();
        DataTable dtBind = new DataTable();
        if (Session["PrdctLvlDef"] != null)
        {
            
        }
        else
        {
            
        }
        dt.Columns.Add("PROD_DESC");
        dt.Columns.Add("FREQUENCY");
        dt.Columns.Add("CONSIDER");
        dt.Columns.Add("TYPE");
        dt.Columns.Add("WEIGHTAGE");
        dt.Columns.Add("PROD_CODE");
        dt.Columns.Add("LOB_CODE");
        dtR.Columns.Add("PROD_DESC");
        dtR.Columns.Add("FREQUENCY");
        dtR.Columns.Add("CONSIDER");
        dtR.Columns.Add("TYPE");
        dtR.Columns.Add("WEIGHTAGE");

        dtBind.Columns.Add("PROD_DESC");
        dtBind.Columns.Add("FREQUENCY");
        dtBind.Columns.Add("CONSIDER");
        dtBind.Columns.Add("TYPE");
        dtBind.Columns.Add("WEIGHTAGE");
        dtBind.Columns.Add("LOB_CODE");
        dtBind.Columns.Add("PROD_CODE");
        dtRBind.Columns.Add("PROD_DESC");
        dtRBind.Columns.Add("FREQUENCY");
        dtRBind.Columns.Add("CONSIDER");
        dtRBind.Columns.Add("TYPE");
        dtRBind.Columns.Add("WEIGHTAGE");
        dtRBind.Columns.Add("LOB_CODE");
        dtRBind.Columns.Add("PROD_CODE");
        DataRow dr = dt.NewRow();
        DataRow drMerge = dtR.NewRow();
        DataRow drBind = dtBind.NewRow();
        DataRow drMergeBind = dtRBind.NewRow();
        if (Session["PrdctLvlDef"] != null)
        {
            drMerge["PROD_DESC"] = hdnPrdctNameval.Value.ToString().Trim();
            drMerge["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drMerge["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drMerge["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drMerge["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            dtR.Rows.Add(drMerge);
            dt = Session["PrdctLvlDef"] as DataTable;
            if (Session["PrdctLvlDef"] != null)
            {
                dtR.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            Session["PrdctLvlDef"] = dtR;
            //SAVING PURPOSE DATA
            drMergeBind["PROD_DESC"] = hdnPrdctNameval.Value.ToString().Trim();
            drMergeBind["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drMergeBind["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drMergeBind["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drMergeBind["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            drMergeBind["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            drMergeBind["PROD_CODE"] = hdnPrdctName.Value.ToString().Trim();
            dtRBind.Rows.Add(drMergeBind);
            dtBind = Session["PrdctLvlDefBind"] as DataTable;
            //////dtBind = Session["PrdctLvlDef"] as DataTable;
            if (Session["PrdctLvlDefBind"] != null)
            ////if (Session["PrdctLvlDef"] != null)
            {
                dtRBind.Merge(dtBind, true, MissingSchemaAction.Ignore);
            }
            Session["PrdctLvlDefBind"] = dtRBind;
            dgPrdctGrid.DataSource = dtRBind;
            dgPrdctGrid.DataBind();
        }
        else
        {
            dr["PROD_DESC"] = hdnPrdctNameval.Value.ToString().Trim();
            dr["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            dr["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            dr["TYPE"] = hdnTypeval.Value.ToString().Trim();
            dr["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            dt.Rows.Add(dr);
            Session["PrdctLvlDef"] = dt;
            dgPrdctGrid.DataSource = dt;
            dgPrdctGrid.DataBind();
            //SAVING PURPOSE DATA
            drBind["PROD_DESC"] = hdnPrdctNameval.Value.ToString().Trim();
            drBind["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drBind["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drBind["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drBind["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            drBind["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            drBind["PROD_CODE"] = hdnPrdctName.Value.ToString().Trim();
            dtBind.Rows.Add(drBind);
            Session["PrdctLvlDefBind"] = dtBind;
        }
        if (dgPrdctGrid.PageCount > 1)
        {
            btnnextStdPrd.Enabled = true;
        }
        else
        {
            btnnextStdPrd.Enabled = false;
        }
    }
    protected void btnLOB_Click(object sender, EventArgs e)
    {
        //Session["PrdctLvlDef"] = null;
        //dt and dtR used for showing data while dtBind and dtRBind are used for saving the data
        DataTable dtLOBNull = new DataTable();
        DataTable dtLOB = new DataTable();
        DataTable dtLOBNullSav = new DataTable();
        DataTable dtLOBSav = new DataTable();
        if (Session["LOBLvlDef"] != null)
        {

        }
        else
        {

        }
        //FOR SHOWING THE DATA IN GRID
        dtLOB.Columns.Add("LOB_DESC");
        dtLOB.Columns.Add("LOB_CODE");
        dtLOB.Columns.Add("FREQUENCY");
        dtLOB.Columns.Add("CONSIDER");
        dtLOB.Columns.Add("TYPE");
        dtLOB.Columns.Add("WEIGHTAGE");
        dtLOBNull.Columns.Add("LOB_DESC");
        dtLOBNull.Columns.Add("LOB_CODE");
        dtLOBNull.Columns.Add("FREQUENCY");
        dtLOBNull.Columns.Add("CONSIDER");
        dtLOBNull.Columns.Add("TYPE");
        dtLOBNull.Columns.Add("WEIGHTAGE");
        //FOR SAVING THE DATA IN DATABASE  
        dtLOBSav.Columns.Add("LOB_DESC");
        dtLOBSav.Columns.Add("FREQUENCY");
        dtLOBSav.Columns.Add("CONSIDER");
        dtLOBSav.Columns.Add("TYPE");
        dtLOBSav.Columns.Add("WEIGHTAGE");
        dtLOBSav.Columns.Add("LOB_CODE");
        //dtLOBSav.Columns.Add("PROD_CODE");
        dtLOBNullSav.Columns.Add("LOB_DESC");
        dtLOBNullSav.Columns.Add("FREQUENCY");
        dtLOBNullSav.Columns.Add("CONSIDER");
        dtLOBNullSav.Columns.Add("TYPE");
        dtLOBNullSav.Columns.Add("WEIGHTAGE");
        dtLOBNullSav.Columns.Add("LOB_CODE");
        //dtLOBNullSav.Columns.Add("PROD_CODE");

        DataRow drLOB = dtLOB.NewRow();
        DataRow drLOBNull = dtLOBNull.NewRow();
        DataRow drLOBSav = dtLOBSav.NewRow();
        DataRow drLOBNullSav = dtLOBNullSav.NewRow();
        if (Session["LOBLvlDef"] != null)
        {
            drLOBNull["LOB_DESC"] = hdnLOBval.Value.ToString().Trim();
            drLOBNull["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drLOBNull["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drLOBNull["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drLOBNull["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            dtLOBNull.Rows.Add(drLOBNull);
            dtLOB = Session["LOBLvlDef"] as DataTable;
            dtLOBNull.Merge(dtLOB, true, MissingSchemaAction.Ignore);
            Session["LOBLvlDef"] = dtLOBNull;
            //SAVING PURPOSE DATA
            drLOBNullSav["LOB_DESC"] = hdnLOBval.Value.ToString().Trim();
            drLOBNullSav["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drLOBNullSav["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drLOBNullSav["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drLOBNullSav["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            drLOBNullSav["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            //drLOBNullSav["PROD_CODE"] = hdnPrdctName.Value.ToString().Trim();
            dtLOBNullSav.Rows.Add(drLOBNullSav);
            dtLOBSav = Session["LOBLvlDefBind"] as DataTable;
            dtLOBNullSav.Merge(dtLOBSav, true, MissingSchemaAction.Ignore);
            Session["LOBLvlDefBind"] = dtLOBNullSav;
            dgLOBGrid.DataSource = dtLOBNull;
            dgLOBGrid.DataSource = dtLOBNullSav;
            dgLOBGrid.DataBind();
        }
        else
        {
            drLOB["LOB_DESC"] = hdnLOBval.Value.ToString().Trim();
            drLOB["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            drLOB["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drLOB["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drLOB["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drLOB["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            dtLOB.Rows.Add(drLOB);
            Session["LOBLvlDef"] = dtLOB;
            dgLOBGrid.DataSource = dtLOB;
            dgLOBGrid.DataBind();
            //SAVING PURPOSE DATA
            drLOBSav["LOB_DESC"] = hdnLOBval.Value.ToString().Trim();
            drLOBSav["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            drLOBSav["FREQUENCY"] = hdnPrctFreqval.Value.ToString().Trim();
            drLOBSav["CONSIDER"] = hdnConsiderval.Value.ToString().Trim();
            drLOBSav["TYPE"] = hdnTypeval.Value.ToString().Trim();
            drLOBSav["WEIGHTAGE"] = hdnWghtg.Value.ToString().Trim();
            drLOBSav["LOB_CODE"] = hdnLOB.Value.ToString().Trim();
            //drLOBSav["PROD_CODE"] = hdnPrdctName.Value.ToString().Trim();
            dtLOBSav.Rows.Add(drLOBSav);
            Session["LOBLvlDefBind"] = dtLOBSav;
        }
    }
    protected void btnAddStdLOB_Click(object sender, EventArgs e)
    {

    }
    protected void lnkDeleteLOB_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnLOBCode = (HiddenField)row.FindControl("hdnLOBCode");
        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString().Trim() == "KPIMST")
            {
                if (Request.QueryString["KpiCode"] != null)
                {
                    htParam.Add("@KPICode", Request.QueryString["KpiCode"].ToString().Trim());
                }
            }
            else
            {
                htParam.Add("@CmpnstCode", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@KPICode", hdnKPICd.Value.ToString().Trim());
            }
        }
        htParam.Add("@Mapped_code", Request.QueryString["MAPPED_Code"].ToString().Trim());
        htParam.Add("@LOBCode", hdnLOBCode.Value.ToString().Trim());
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelLOBWghtg", htParam);
        ds.Clear();
        htParam.Clear();
        DataTable dt = Session["LOBLvlDefBind"] as DataTable;
        dt.Rows[rowIndex].Delete();
        dt.AcceptChanges();
        if (dt.Rows.Count > 0)
        {
            dgLOBGrid.DataSource = dt;
            dgLOBGrid.DataBind();
        }
        else
        {
            ShowNoResultFound(dt, dgLOBGrid, "LOB");
        }
        Session["LOBLvlDefBind"] = dt;
    }
    protected void lnkDeletePrd_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnPrdCode = (HiddenField)row.FindControl("hdnPrdCode");
        HiddenField hdnLOBCode = (HiddenField)row.FindControl("hdnLOBCode");

        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString().Trim() == "KPIMST") 
            {
                if (Request.QueryString["KpiCode"] != null)
                {
                    htParam.Add("@KPICode", Request.QueryString["KpiCode"].ToString().Trim());
                }
            }
            else
            {
                htParam.Add("@KPICode", hdnKPICd.Value.ToString().Trim());
            }
        }
        htParam.Add("@Mapped_code", Request.QueryString["MAPPED_Code"].ToString().Trim());
        htParam.Add("@PrdCode", hdnPrdCode.Value.ToString().Trim());
        htParam.Add("@LOBCode", hdnLOBCode.Value.ToString().Trim());
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelPrdctWghtDef", htParam);
        ds.Clear();
        htParam.Clear();
        DataTable dt = Session["PrdctLvlDefBind"] as DataTable;
        dt.Rows[rowIndex].Delete();
        dt.AcceptChanges();
        if (dt.Rows.Count > 0)
        {
            dgPrdctGrid.DataSource = dt;
            dgPrdctGrid.DataBind();
        }
        else
        {
            ShowNoResultFound(dt, dgPrdctGrid, "Product");
        }
        Session["PrdctLvlDefBind"] = dt;
    }


}
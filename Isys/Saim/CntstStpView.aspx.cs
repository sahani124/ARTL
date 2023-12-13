#region Namespace
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataAccessClassDAL; 
#endregion

public partial class Application_ISys_Saim_CntstStpView : BaseClass
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
            FillCmp();
            BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            BindAuditGrid(Request.QueryString["CmpCode"].ToString().Trim());
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            ////BindQualRul();
            BindRwdTrg();
            BindRwdRul();
            txtpgrwdtrg.Text = "1";
            lblNote.Text = "Note:Reward Computation Rule:- Accumulation Cycle or Reward Release Cycle";
        }
        //btnAddQual.Attributes.Add("onclick", "funPopUp('divqual','Q');return false;");
        //btnAddRwd.Attributes.Add("onclick", "funPopUp('divRwd','R');return false;");
        chkQual.Attributes.Add("onclick", "ShowReqDiv('divqual','Img2','#Img2','chkQual','div12');");
        chkRwd.Attributes.Add("onclick", "ShowReqDiv('divRwd','Img3','#Img3','chkRwd','divchkRwd');");
        //btnAddRwdRul.Attributes.Add("onclick", "funPopUpRwdRul('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
        //lnkKeyDfn.Attributes.Add("onclick", "funPopUpRulSet('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
    } 
    #endregion

    #region FillCmp
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
        }
    } 
    #endregion

    #region ShowNoResultFound
    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No rules have been defined";
        source.Rows.Clear();
    } 
    #endregion

    #region btnprevious_Click
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQual.PageIndex;
            dgQual.PageIndex = pageIndex - 1;
            BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
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
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnnext_Click
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQual.PageIndex;
            dgQual.PageIndex = pageIndex + 1;
            BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgQual.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgQual.PageCount;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region BindGrid
    protected void BindGrid(GridView gv, Button btnP, Button btnN, CheckBox chk, HtmlGenericControl div, string rultyp, HtmlGenericControl divchk)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@RuleType", rultyp.ToString().Trim());
        htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds;
            gv.DataBind();
            /////hdnKPICnt.Value = ds.Tables[0].Rows.Count.ToString().Trim();
            div.Style.Add("display", "block");
            divchk.Style.Add("display", "block");
            chk.Checked = true;
            if (gv.PageCount > 1)
            {
                btnN.Enabled = true;
            }
            else
            {
                btnN.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound(ds.Tables[0], gv);
            chk.Checked = false;
            div.Style.Add("display", "none");
            divchk.Style.Add("display", "block");
        }
        Session["grid"] = ds.Tables[0];
    } 
    #endregion

    #region btnSaveQual_Click
    protected void btnSaveQual_Click(object sender, EventArgs e)
    {
        try
        {
            #region SAVE QUALIFICATION
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "Q");
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpCntKPI", htParam);
            ds.Clear();
            htParam.Clear();

            List<string> lstRuleCode = new List<string>();
            List<string> lstRulSetKey = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstAccMode = new List<string>();
            List<string> lstVerEffFrm = new List<string>();
            List<string> lstVerEffTo = new List<string>();

            for (int intRowCount = 0; intRowCount <= dgQual.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRulCode = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnRulCode");
                lstRuleCode.Add(hdnRulCode.Value.ToString().Trim());
                HiddenField hdnRulStKy = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnRulStKy");
                lstRulSetKey.Add(hdnRulStKy.Value.ToString().Trim());
                HiddenField hdnKPICode = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnKPICode");
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
                HiddenField hdnAccMode = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnAccMode");
                lstAccMode.Add(hdnAccMode.Value.ToString().Trim());
                HiddenField hdnVerFrm = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnVerFrm");
                lstVerEffFrm.Add(hdnVerFrm.Value.ToString().Trim());
                HiddenField hdnVerTo = (HiddenField)dgQual.Rows[intRowCount].Cells[0].FindControl("hdnVerTo");
                lstVerEffTo.Add(hdnVerTo.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRuleCode.Count - 1; intDataCount++)
            {
                htParam.Clear();
                htParam.Add("@RULE_CODE", lstRuleCode[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@KPI_CODE", lstKPICode[intDataCount]);
                htParam.Add("@RULE_TYPE", "Q");
                htParam.Add("@ACC_MODE", lstAccMode[intDataCount]);
                htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lstVerEffFrm[intDataCount]));
                htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lstVerEffTo[intDataCount]));
                if (lblEffDtFrmVal.Text != "")
                {
                    htParam.Add("@EFF_FROM", Convert.ToDateTime(lblEffFrmValCnt.Text.ToString().Trim()));
                }
                else
                {
                    htParam.Add("@EFF_FROM", System.DBNull.Value);
                }
                if (lblEffDtToVal.Text != "")
                {
                    htParam.Add("@EFF_TO", Convert.ToDateTime(lblEffToValCnt.Text.ToString().Trim()));
                }
                else
                {
                    htParam.Add("@EFF_TO", System.DBNull.Value);
                }
                htParam.Add("@FIN_YEAR", lblFinYrVal.Text.ToString().Trim());
                htParam.Add("@VER_NO", lblVerVal.Text.ToString().Trim());
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpCntstKPI", htParam);
            }
            mdlpopup.Show();
            lbl3.Text = "KPI codes saved successfully for qualification";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            btnSaveQual.Enabled = true;
            #endregion
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnSaveQual_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnqual_Click
    protected void btnqual_Click(object sender, EventArgs e)
    {
        try
        {
            divqual.Style.Add("display", "block");
            int str = 0;
            string maxrulecode = String.Empty;
            string maxrulsetcd = String.Empty;
            DataTable dtR = new DataTable();
            if (Session["grid"] != null)
            {
                dtR = (DataTable)Session["grid"];
                if (dtR.Rows.Count > 0)
                {
                    maxrulecode = (Convert.ToInt32(dtR.Rows[dtR.Rows.Count - 1]["RULE_CODE"].ToString()) + 1).ToString().Trim();
                    maxrulsetcd = dtR.Rows[dtR.Rows.Count - 1]["RULE_SET_KEY"].ToString().Trim();
                }
                else
                {
                    maxrulecode = GetMaxCode("1");
                    maxrulsetcd = hdnRulSetKy.Value.ToString().Trim();
                }
            }
            else
            {
                maxrulecode = GetMaxCode("1");
                maxrulsetcd = hdnRulSetKy.Value.ToString().Trim();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("RULE_CODE");
            dt.Columns.Add("RULE_SET_KEY");
            dt.Columns.Add("KPI_CODE");
            dt.Columns.Add("KPI_DESC");
            dt.Columns.Add("ACC_MODE_DESC");
            dt.Columns.Add("ACC_MODE");
            dt.Columns.Add("VER_FRM");
            dt.Columns.Add("VER_TO");

            DataRow dr = dt.NewRow();
            dr["RULE_CODE"] = maxrulecode.ToString().Trim();
            dr["RULE_SET_KEY"] = maxrulsetcd.ToString().Trim();
            dr["KPI_CODE"] = hdnKPICd.Value.ToString().Trim();
            dr["KPI_DESC"] = hdnKPIDsc.Value.ToString().Trim();
            dr["ACC_MODE"] = hdnAccMd.Value.ToString().Trim();
            dr["ACC_MODE_DESC"] = hdnAccMdDsc.Value.ToString().Trim();
            dr["VER_FRM"] = hdnVerFrm.Value.ToString().Trim();
            dr["VER_TO"] = hdnVerFrm.Value.ToString().Trim();

            dt.Rows.Add(dr);
            if (Session["grid"] != null)
            {
                dtR.Merge(dt, true, MissingSchemaAction.Ignore);
            }
            dgQual.DataSource = null;
            dgQual.DataBind();
            dgQual.DataSource = dtR;
            dgQual.DataBind();
            Session["grid"] = dtR;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnqual_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnnextrwd_Click
    protected void btnnextrwd_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgReward.PageIndex;
            dgReward.PageIndex = pageIndex + 1;
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            txtPageRwd.Text = Convert.ToString(Convert.ToInt32(txtPageRwd.Text) + 1);
            btnprevrwd.Enabled = true;
            if (txtPageRwd.Text == Convert.ToString(dgReward.PageCount))
            {
                btnnextrwd.Enabled = false;
            }
            int page = dgReward.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnnextrwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnprevrwd_Click
    protected void btnprevrwd_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgReward.PageIndex;
            dgReward.PageIndex = pageIndex - 1;
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            txtPageRwd.Text = Convert.ToString(Convert.ToInt32(txtPageRwd.Text) - 1);
            if (txtPageRwd.Text == "1")
            {
                btnprevrwd.Enabled = false;
            }
            else
            {
                btnprevrwd.Enabled = true;
            }
            btnnextrwd.Enabled = true;
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnprevrwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnSaveRwd_Click
    protected void btnSaveRwd_Click(object sender, EventArgs e)
    {
        try
        {
            #region SAVE REWARD
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "R");
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpCntKPI", htParam);
            ds.Clear();
            htParam.Clear();

            List<string> lstRuleCode = new List<string>();
            List<string> lstRulSetKey = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstAccMode = new List<string>();
            List<string> lstVerEffFrm = new List<string>();
            List<string> lstVerEffTo = new List<string>();
            List<string> lstCRYFWD = new List<string>();
            List<string> lstRwdCmpRul = new List<string>();
            List<string> lstUnitType = new List<string>();
            List<string> lstMaxLmt = new List<string>();

            for (int intRowCount = 0; intRowCount <= dgReward.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRulCode = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnRulCode");
                lstRuleCode.Add(hdnRulCode.Value.ToString().Trim());
                HiddenField hdnRulStKy = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnRulStKy");
                lstRulSetKey.Add(hdnRulStKy.Value.ToString().Trim());
                HiddenField hdnKPICode = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnKPICode");
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
                HiddenField hdnAccMode = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnAccMode");
                lstAccMode.Add(hdnAccMode.Value.ToString().Trim());
                HiddenField hdnVerFrm = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnVerFrm");
                lstVerEffFrm.Add(hdnVerFrm.Value.ToString().Trim());
                HiddenField hdnVerTo = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnVerTo");
                lstVerEffTo.Add(hdnVerTo.Value.ToString().Trim());
                HiddenField hdnCRYFWDQ = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnCRYFWD");
                lstCRYFWD.Add(hdnCRYFWDQ.Value.ToString().Trim());
                HiddenField hdnRwdCmpRulQ = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnRwdCmpRul");
                lstRwdCmpRul.Add(hdnRwdCmpRulQ.Value.ToString().Trim());
                HiddenField hdnUnitTypeQ = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnUnitType");
                lstUnitType.Add(hdnUnitTypeQ.Value.ToString().Trim());
                HiddenField hdnMaxLmtQ = (HiddenField)dgReward.Rows[intRowCount].Cells[0].FindControl("hdnMaxLmt");
                lstMaxLmt.Add(hdnMaxLmtQ.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRuleCode.Count - 1; intDataCount++)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@RULE_CODE", lstRuleCode[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@KPI_CODE", lstKPICode[intDataCount]);
                htParam.Add("@RULE_TYPE", "R");
                htParam.Add("@ACC_MODE", lstAccMode[intDataCount]);
                htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lstVerEffFrm[intDataCount]));
                htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lstVerEffTo[intDataCount]));

                htParam.Add("@CRYFWD", lstCRYFWD[intDataCount]);
                htParam.Add("@RwdCmpRul", lstRwdCmpRul[intDataCount]);
                htParam.Add("@UnitType", lstUnitType[intDataCount]);
                if (lstMaxLmt[intDataCount] != "")
                {
                    htParam.Add("@MaxLmt", lstMaxLmt[intDataCount]);
                }
                else
                {
                    htParam.Add("@MaxLmt", "0.00");
                }

                if (lblEffDtFrmVal.Text != "")
                {
                    htParam.Add("@EFF_FROM", Convert.ToDateTime(lblEffFrmValCnt.Text.ToString().Trim()));
                }
                else
                {
                    htParam.Add("@EFF_FROM", System.DBNull.Value);
                }
                if (lblEffDtToVal.Text != "")
                {
                    htParam.Add("@EFF_TO", Convert.ToDateTime(lblEffToValCnt.Text.ToString().Trim()));
                }
                else
                {
                    htParam.Add("@EFF_TO", System.DBNull.Value);
                }
                htParam.Add("@FIN_YEAR", lblFinYrVal.Text.ToString().Trim());
                htParam.Add("@VER_NO", lblVerVal.Text.ToString().Trim());
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpCntstKPI", htParam);
            }
            mdlpopup.Show();
            lbl3.Text = "KPI codes saved successfully for reward";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            btnSaveQual.Enabled = false;
            #endregion
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnSaveRwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnprevkpitrg_Click
    protected void btnprevkpitrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex - 1;
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) - 1);
            if (txtpagetrg.Text == "1")
            {
                btnprevkpitrg.Enabled = false;
            }
            else
            {
                btnprevkpitrg.Enabled = true;
            }
            btnnextkpitrg.Enabled = true;
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnprevkpitrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnnextkpitrg_Click
    protected void btnnextkpitrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex + 1;
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) + 1);
            btnprevkpitrg.Enabled = true;
            if (txtpagetrg.Text == Convert.ToString(dgQualTrg.PageCount))
            {
                btnnextkpitrg.Enabled = false;
            }
            int page = dgQualTrg.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnnextkpitrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnAddQualTrg_Click
    protected void btnAddQualTrg_Click(object sender, EventArgs e)
    {
        //////Session["gridTrg"] = null;
        string ctgqualcd = String.Empty;
        DataTable dtV = new DataTable();
        if (Session["QualTrg"] != null)
        {
            dtV = Session["QualTrg"] as DataTable;
            if (dtV.Rows.Count > 0)
            {
                ctgqualcd = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["CATEGORY"].ToString()) + 1).ToString().Trim();
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','Q','" + ctgqualcd.ToString().Trim() + "','QualTrg');", true);
        ////btnAddRwdTrg.Attributes.Add("onclick", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
        /////Session["gridTrg"] = null;
    } 
    #endregion

    #region btnSaveQualTrg_Click
    protected void btnSaveQualTrg_Click(object sender, EventArgs e)
    {
        SaveTrg("QualTrg", "Q");
    } 
    #endregion

    #region btnqualtrg_Click
    protected void btnqualtrg_Click(object sender, EventArgs e)
    {
        BindQualTrg(hdnFlag.Value.ToString().Trim());
    } 
    #endregion

    #region btnnextrwdtrg_Click
    protected void btnnextrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Session["gridTrg"] as DataTable;

            DataTable dtbind = new DataTable();
            dtbind = dt.Clone();

            if (Session["gridTrg"] != null)
            {
                dgRwdTrg.PageSize = 3;
                Session["gridTrg"] = dtbind;
                dgRwdTrg.DataSource = Session["gridTrg"];
                dgRwdTrg.DataBind();
            }
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprevrwdtrg.Enabled = false;
            }
            else
            {
                btnprevrwdtrg.Enabled = true;
            }
            if (Convert.ToInt32(txtpgrwdtrg.Text) <= 6)
            {
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnnextrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnprevrwdtrg_Click
    protected void btnprevrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Session["gridTrg"] as DataTable;
            DataTable dt1 = new DataTable();
            dt1 = Session["gridTrg1"] as DataTable;
            int rcount1 = Convert.ToInt32(ViewState["TblRowCount1"]);
            int rcount = Convert.ToInt32(Session["TblRowCount"]);
            Session["TblRowCount"] = rcount - 1;
            int a = Convert.ToInt32(Session["TblRowCount"]);
            string cycle = dt1.Rows[a][1].ToString();
            int count = Convert.ToInt32(dt1.Rows[a][0]);
            DataTable dtbind = new DataTable();
            dtbind = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[2].ToString().Trim() == cycle.Trim())
                {
                    DataRow drNew = dtbind.NewRow();
                    drNew.ItemArray = dr.ItemArray;
                    dtbind.Rows.Add(drNew);
                    int a22 = dtbind.Rows.Count;
                    ViewState["a22"] = a22;
                }

            }
            if (Session["gridTrg"] != null)
            {
                dgRwdTrg.PageSize = Convert.ToInt32(ViewState["a22"]);
                Session["dtbind"] = dtbind;
                dgRwdTrg.DataSource = Session["dtbind"];
                dgRwdTrg.DataBind();
            }
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprevrwdtrg.Enabled = false;
            }
            else
            {
                btnprevrwdtrg.Enabled = true;
            }
            if (Convert.ToInt32(txtpgrwdtrg.Text) < dt1.Rows.Count)
            {
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnprevrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnSaveRwdTrg_Click
    protected void btnSaveRwdTrg_Click(object sender, EventArgs e)
    {
        SaveTrg("gridTrg", "R");
    } 
    #endregion

    #region GetMaxCode
    protected string GetMaxCode(string flag)
    {
        string code = String.Empty;
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            code = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
        }
        return code.ToString().Trim();
    } 
    #endregion

    #region BindRwdTrg
    protected void BindRwdTrg()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@RULE_TYPE", "R");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////dgRwdTrg.PageSize = ds.Tables[0].Rows[0]["CATG_CODE"].ToString().Trim();
            ////ViewState["CYCLE"] = ds.Tables[1].Rows[0]["CYCLE"].ToString().Trim();
            hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
            ////hdnCatgCnt.Value = "3";
            ////hdnCatgCnt.Value = "6";
            dgRwdTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
            dgRwdTrg.DataSource = ds;
            dgRwdTrg.DataBind();
            if (dgRwdTrg.PageCount > 1)
            {
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
            }
        }
        else
        {
            ShowNoRecQualTrg(ds.Tables[0], dgRwdTrg);
        }
        Session["gridTrg"] = ds.Tables[0];
        Session["gridTrg1"] = ds.Tables[1];
        Session["TblRowCount"] = 0;
        ViewState["TblRowCount1"] = 0;
        ////Session["grid"] = ds.Tables[0];
    } 
    #endregion

    #region BindQualTrg
    protected void BindQualTrg(string flag)
    {
        #region bindgrid
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@RULE_TYPE", "Q");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls", htParam);
        if (hdnFlag.Value != null)
        {
            if (hdnFlag.Value == "S")
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["QualTrg"];
                ////dtCyc = (DataTable)Session["QualTrg"];
                dgQualTrg.DataSource = dt;
                dgQualTrg.DataBind();
                Session["QualTrg"] = dt;
            }
            else
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgQualTrg.DataSource = ds;
                    dgQualTrg.DataBind();
                    Session["QualTrg"] = ds.Tables[0];
                }
                else
                {
                    ShowNoRecQualTrg(ds.Tables[0], dgQualTrg);
                    Session["QualTrg"] = ds.Tables[0];
                }
            }
        }
        else
        {
            ShowNoRecQualTrg(ds.Tables[0], dgQualTrg);
            Session["QualTrg"] = ds.Tables[0];
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
            if (hdnCatgCnt.Value != "0")
            {
                dgQualTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
            }
        }
        if (dgQualTrg.PageCount > 1)
        {
            btnnextkpitrg.Enabled = true;
        }
        else
        {
            btnnextkpitrg.Enabled = false;
        }
        Session["QualTrg1"] = ds.Tables[1];
        #endregion
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

    #region btnAddRwdTrg_Click
    protected void btnAddRwdTrg_Click(object sender, EventArgs e)
    {
        //////Session["gridTrg"] = null;
        string maxcatgcd = String.Empty;
        string maxsort = String.Empty;
        DataTable dtV = new DataTable();
        if (Session["gridTrg"] != null)
        {
            dtV = Session["gridTrg"] as DataTable;
            if (dtV.Rows.Count > 0)
            {
                maxcatgcd = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["CATEGORY"].ToString())).ToString().Trim();
                maxsort = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["SORT"].ToString())).ToString().Trim();
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + maxsort.ToString().Trim() + "','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + maxcatgcd.ToString().Trim() + "','gridTrg');", true);
        ////btnAddRwdTrg.Attributes.Add("onclick", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
        /////Session["gridTrg"] = null;
    } 
    #endregion

    #region btnprevrwdrul_Click
    protected void btnprevrwdrul_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dtRwrdRul = new DataTable();
            dtRwrdRul = Session["RwdRul"] as DataTable;
            DataTable dtRwrdRul1 = new DataTable();
            dtRwrdRul1 = Session["RwdRul1"] as DataTable;
            int rcount1 = Convert.ToInt32(ViewState["TblRwrdRowCount"]);
            int rcount = Convert.ToInt32(Session["TblRwrdRowCount"]);
            Session["TblRwrdRowCount"] = rcount - 1;
            int a = Convert.ToInt32(Session["TblRwrdRowCount"]);
            string cycle = dtRwrdRul1.Rows[a][1].ToString();
            int count = Convert.ToInt32(dtRwrdRul1.Rows[a][0]);
            DataTable dtRwrdbind = new DataTable();
            dtRwrdbind = dtRwrdRul.Clone();
            foreach (DataRow dr in dtRwrdRul.Rows)
            {
                if (dr["CYCLE"].ToString().Trim() == cycle.Trim())
                {
                    DataRow drNew = dtRwrdbind.NewRow();
                    drNew.ItemArray = dr.ItemArray;
                    dtRwrdbind.Rows.Add(drNew);
                    int a22 = dtRwrdbind.Rows.Count;
                    ViewState["RwrdCount"] = a22;
                }
            }
            if (Session["RwdRul"] != null)
            {
                dgRwdRul.PageSize = Convert.ToInt32(ViewState["RwrdCount"]);
                Session["dtRwrdbind"] = dtRwrdbind;
                dgRwdRul.DataSource = Session["dtRwrdbind"];
                dgRwdRul.DataBind();
            }
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) - 1);
            if (txtPageRwdRul.Text == "1")
            {
                btnprevrwdrul.Enabled = false;
            }
            else
            {
                btnprevrwdrul.Enabled = true;
            }
            if (Convert.ToInt32(txtPageRwdRul.Text) < dtRwrdRul1.Rows.Count)
            {
                btnnextrwdrul.Enabled = true;
            }
            else
            {
                btnnextrwdrul.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnprevrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnnextrwdrul_Click
    protected void btnnextrwdrul_Click(object sender, EventArgs e)
    {
        try
        {

            //int page = dgRwdRul.PageCount;
            DataTable dtRwrdRul = new DataTable();
            dtRwrdRul = Session["RwdRul"] as DataTable;
            DataTable dtRwrdRul1 = new DataTable();
            dtRwrdRul1 = Session["RwdRul1"] as DataTable;
            int rcount1 = Convert.ToInt32(ViewState["TblRwrdRowCount"]);
            int rcount = Convert.ToInt32(Session["TblRwrdRowCount"]);
            Session["TblRwrdRowCount"] = rcount + 1;
            int a = Convert.ToInt32(Session["TblRwrdRowCount"]);
            string cycle = dtRwrdRul1.Rows[a][1].ToString();
            int count = Convert.ToInt32(dtRwrdRul1.Rows[a][0]);
            DataTable dtRwrdbind = new DataTable();
            dtRwrdbind = dtRwrdRul.Clone();
            foreach (DataRow dr in dtRwrdRul.Rows)
            {
                if (dr["CYCLE"].ToString().Trim() == cycle.Trim())
                {
                    DataRow drNew = dtRwrdbind.NewRow();
                    drNew.ItemArray = dr.ItemArray;
                    dtRwrdbind.Rows.Add(drNew);
                    int a22 = dtRwrdbind.Rows.Count;
                    ViewState["RwrdCount"] = a22;
                }
            }
            if (Session["RwdRul"] != null)
            {
                dgRwdRul.PageSize = Convert.ToInt32(ViewState["RwrdCount"]);
                Session["dtRwrdbind"] = dtRwrdbind;
                dgRwdRul.DataSource = Session["dtRwrdbind"];
                dgRwdRul.DataBind();
            }
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) + 1);
            if (txtPageRwdRul.Text == "1")
            {
                btnprevrwdrul.Enabled = false;
            }
            else
            {
                btnprevrwdrul.Enabled = true;
            }
            if (Convert.ToInt32(txtPageRwdRul.Text) < dtRwrdRul1.Rows.Count)
            {
                btnnextrwdrul.Enabled = true;
            }
            else
            {
                btnnextrwdrul.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnnextrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region btnAddRwdRul_Click
    protected void btnAddRwdRul_Click(object sender, EventArgs e)
    {

    } 
    #endregion
    
    #region BindRwdRul
    protected void BindRwdRul()
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@RULE_TYPE", "R");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hdnRwrdCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
            //////hdnRwrdCnt.Value = "3";
            dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
            dgRwdRul.DataSource = ds;
            dgRwdRul.DataBind();
            if (dgRwdRul.PageCount > 1)
            {
                btnnextrwdrul.Enabled = true;
            }
            else
            {
                btnnextrwdrul.Enabled = false;
            }
        }
        else
        {
            ShowNoRecRwdRul(ds.Tables[0], dgRwdRul);
        }
        Session["RwdRul"] = ds.Tables[0];
        ////Session["RwdRul1"] = ds.Tables[1];
        Session["TblRwrdRowCount"] = 0;
        ViewState["TblRwrdRowCount"] = 0;
    } 
    #endregion

    #region ShowNoRecRwdRul
    private void ShowNoRecRwdRul(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No rules have been defined";
        source.Rows.Clear();
    } 
    #endregion

    #region btnSaveRwdRul_Click
    protected void btnSaveRwdRul_Click(object sender, EventArgs e)
    {
        try
        {
            #region SAVE REWARD RULES
            DataTable dtRwdRul = new DataTable();
            dtRwdRul = Session["RwdRul"] as DataTable;
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
            ////htParam.Add("@RULE_TYPE", "R");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdRulDtls", htParam);

            List<string> lstRulSetKey = new List<string>();
            List<string> lstCatgCode = new List<string>();
            List<string> lstCatgDesc = new List<string>();
            List<string> lstRuleCode = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstRewardCode = new List<string>();
            List<string> lstRwrdDesc = new List<string>();
            List<string> lstRwrdDesc02 = new List<string>();
            List<string> lstRwrdDesc03 = new List<string>();
            List<string> lstBusiCo = new List<string>();
            List<string> lstCycle = new List<string>();
            List<string> lstCode = new List<string>();
            List<string> lstRwrdType = new List<string>();
            List<string> lstType = new List<string>();
            List<string> lstValue = new List<string>();
            List<string> lstBrkupRule = new List<string>();
            List<string> lstVrsnEffFrom = new List<string>();
            List<string> lstVrsnEffTo = new List<string>();
            List<string> lstVrsn = new List<string>();
            List<string> lstFinYear = new List<string>();
            List<string> lstRate = new List<string>();

            for (int intRowCount = 0; intRowCount <= dtRwdRul.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRulStKy = new HiddenField();
                HiddenField hdnCode = new HiddenField();
                HiddenField hdnCatgCode = new HiddenField();
                HiddenField hdnCycle = new HiddenField();
                HiddenField hdnCatDsc = new HiddenField();
                HiddenField hdnKPICode = new HiddenField();
                HiddenField hdnRewardCode = new HiddenField();
                HiddenField hdnRwrdDesc = new HiddenField();
                HiddenField hdnRwrdDesc02 = new HiddenField();
                HiddenField hdnRwrdDesc03 = new HiddenField();
                HiddenField hdnBusiCode = new HiddenField();
                HiddenField hdnRwrdType = new HiddenField();
                HiddenField hdnType = new HiddenField();
                HiddenField hdnValue = new HiddenField();
                HiddenField hdnBrkupRule = new HiddenField();
                HiddenField hdnVrsnEffFrom = new HiddenField();
                HiddenField hdnVrsnEffTo = new HiddenField();
                HiddenField hdnVrsn = new HiddenField();
                HiddenField hdnFinYear = new HiddenField();
                HiddenField hdnRate = new HiddenField();

                hdnRulStKy.Value = dtRwdRul.Rows[intRowCount]["RULE_SET_KEY"].ToString().Trim();
                lstRulSetKey.Add(hdnRulStKy.Value.ToString().Trim());
                hdnCode.Value = dtRwdRul.Rows[intRowCount]["CATEGORY"].ToString().Trim();
                lstCode.Add(hdnCode.Value.ToString().Trim());
                hdnCatgCode.Value = dtRwdRul.Rows[intRowCount]["CATG_CODE"].ToString().Trim();
                lstCatgCode.Add(hdnCatgCode.Value.ToString().Trim());
                hdnCycle.Value = dtRwdRul.Rows[intRowCount]["CYCLE_CODE"].ToString().Trim();
                lstCycle.Add(hdnCycle.Value.ToString().Trim());
                hdnKPICode.Value = dtRwdRul.Rows[intRowCount]["KPI_CODE"].ToString().Trim();
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
                hdnRewardCode.Value = dtRwdRul.Rows[intRowCount]["REWARD_CODE"].ToString().Trim();
                lstRewardCode.Add(hdnRewardCode.Value.ToString().Trim());
                hdnRwrdDesc.Value = dtRwdRul.Rows[intRowCount]["RWD_DESC"].ToString().Trim();
                lstRwrdDesc.Add(hdnRwrdDesc.Value.ToString().Trim());
                hdnRwrdDesc02.Value = dtRwdRul.Rows[intRowCount]["RWRD_DESC02"].ToString().Trim();
                lstRwrdDesc02.Add(hdnRwrdDesc02.Value.ToString().Trim());
                hdnRwrdDesc03.Value = dtRwdRul.Rows[intRowCount]["RWRD_DESC03"].ToString().Trim();
                lstRwrdDesc03.Add(hdnRwrdDesc03.Value.ToString().Trim());
                //hdnBusiCode.Value = dtRwdRul.Rows[intRowCount]["BUSI_CODE"].ToString().Trim();
                //lstBusiCo.Add(hdnBusiCode.Value.ToString().Trim());
                hdnRwrdType.Value = dtRwdRul.Rows[intRowCount]["REWARD_TYPE"].ToString().Trim();
                lstRwrdType.Add(hdnRwrdType.Value.ToString().Trim());
                hdnType.Value = dtRwdRul.Rows[intRowCount]["TYPE"].ToString().Trim();
                lstType.Add(hdnType.Value.ToString().Trim());
                hdnValue.Value = dtRwdRul.Rows[intRowCount]["VALUE"].ToString().Trim();
                lstValue.Add(hdnValue.Value.ToString().Trim());
                hdnBrkupRule.Value = dtRwdRul.Rows[intRowCount]["BRK_RULE"].ToString().Trim();
                lstBrkupRule.Add(hdnBrkupRule.Value.ToString().Trim());
                hdnVrsnEffFrom.Value = dtRwdRul.Rows[intRowCount]["VER_EFF_FROM"].ToString().Trim();
                lstVrsnEffFrom.Add(hdnVrsnEffFrom.Value.ToString().Trim());
                hdnVrsnEffTo.Value = dtRwdRul.Rows[intRowCount]["VER_EFF_TO"].ToString().Trim();
                lstVrsnEffTo.Add(hdnVrsnEffTo.Value.ToString().Trim());
                hdnVrsn.Value = dtRwdRul.Rows[intRowCount]["VERSION"].ToString().Trim();
                lstVrsn.Add(hdnVrsn.Value.ToString().Trim());
                hdnFinYear.Value = dtRwdRul.Rows[intRowCount]["FIN_YEAR"].ToString().Trim();
                lstFinYear.Add(hdnFinYear.Value.ToString().Trim());
                hdnRate.Value = dtRwdRul.Rows[intRowCount]["RATE"].ToString().Trim();
                lstRate.Add(hdnRate.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRulSetKey.Count - 1; intDataCount++)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@RWRD_CODE", lstRewardCode[intDataCount]);
                htParam.Add("@RWD_DESC", lstRwrdDesc[intDataCount]);
                htParam.Add("@RWRD_DESC02", lstRwrdDesc02[intDataCount]);
                htParam.Add("@RWRD_DESC03", lstRwrdDesc03[intDataCount]);
                htParam.Add("@CATG_CODE", lstCatgCode[intDataCount]);
                htParam.Add("@CYCLE", lstCycle[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@RWRD_TYPE", lstRwrdType[intDataCount]);
                htParam.Add("@TYPE", lstType[intDataCount]);
                htParam.Add("@BASED_ON_KPI", lstKPICode[intDataCount]);
                htParam.Add("@VALUE", lstValue[intDataCount] == "" ? "0.0" : lstValue[intDataCount]);
                htParam.Add("@BRKUPRULE", lstBrkupRule[intDataCount]);
                htParam.Add("@CATG_DESC01", lstRwrdDesc[intDataCount]);
                htParam.Add("@CATG_DESC02", lstRwrdDesc02[intDataCount]);
                htParam.Add("@CATG_DESC03", lstRwrdDesc03[intDataCount]);
                htParam.Add("@RATE", lstRate[intDataCount] == "" ? "0.0" : lstRate[intDataCount]);
                htParam.Add("@EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                htParam.Add("@EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                htParam.Add("@FIN_YEAR", lstFinYear[intDataCount]);
                htParam.Add("@VER_NO", lstVrsn[intDataCount]);
                htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls", htParam);
            }
            hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
            mdlpopup.Show();
            lbl3.Text = "Rewards Rules saved successfully";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            btnSaveRwdRul.Enabled = true;
            #endregion
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "btnSaveRwdRul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region dgRwdRul_RowDataBound
    protected void dgRwdRul_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                if (Session["RwdRul"] != null)
                {
                    dt = Session["RwdRul"] as DataTable;
                    Label lblBsdKpi = (Label)e.Row.FindControl("lblBsdKpi");
                    Label lblBrkRul = (Label)e.Row.FindControl("lblBrkRul");
                    Label lblRATE = (Label)e.Row.FindControl("lblRATE");
                    HiddenField hdnType = (HiddenField)e.Row.FindControl("hdnKPICode");//////UnitType
                    Label lblValue = (Label)e.Row.FindControl("lblValue");
                    LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnkValue");
                    if (dt.Rows.Count > 0)
                    {
                        if (lblBsdKpi.Text != null)
                        {
                            if (lblBsdKpi.Text == "")
                            {
                                e.Row.Cells[6].Text = "NA";
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                            if (lblBsdKpi.Text == "--SELECT--")
                            {
                                e.Row.Cells[6].Text = "NA";
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (lblBrkRul.Text != null)
                        {
                            if (lblBrkRul.Text == "")
                            {
                                e.Row.Cells[9].Text = "NA";
                                e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (lblRATE.Text != null)
                        {
                            if (lblRATE.Text == "")
                            {
                                e.Row.Cells[10].Text = "NA";
                                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (hdnType.Value == "F")
                        {
                            lnkValue.Visible = true;
                            lblValue.Visible = false;
                        }
                        else
                        {
                            lnkValue.Visible = false;
                            lblValue.Visible = true;
                        }
                    }
                    //dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
                }
            }
        }
        catch (Exception ex)
        { 
        //{
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "dgRwdRul_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion
    
    #region SaveTrg
    protected void SaveTrg(string ID, string rultyp)
    {
        try
        {
            #region SAVE KPI TARGETS
            DataTable dtRwd = new DataTable();
            dtRwd = Session[ID] as DataTable;
            ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
            /////htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdTrgDtls", htParam);

            List<string> lstRulSetKey = new List<string>();
            List<string> lstCatgCode = new List<string>();
            List<string> lstCatgDesc = new List<string>();
            List<string> lstRuleCode = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstTrgFrm = new List<string>();
            List<string> lstTrgTo = new List<string>();
            List<string> lstBusiCo = new List<string>();
            List<string> lstCycle = new List<string>();
            List<string> lstCycleCode = new List<string>();
            List<string> lstCode = new List<string>();
            List<string> lstEffDtFrm = new List<string>();
            List<string> lstEffDtTo = new List<string>();
            List<string> lstSbCtgry = new List<string>();
            List<string> lstPExcl = new List<string>();
            List<string> lstSExcl = new List<string>();
            List<string> lstSort = new List<string>();

            for (int intRowCount = 0; intRowCount <= dtRwd.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRulStKy = new HiddenField();
                HiddenField hdnCode = new HiddenField();
                HiddenField hdnCatgCode = new HiddenField();
                HiddenField hdnCycle = new HiddenField();
                HiddenField hdnCycleCode = new HiddenField();
                HiddenField hdnCatDsc = new HiddenField();
                HiddenField hdnKPICode = new HiddenField();
                HiddenField hdnTrgFrm = new HiddenField();
                HiddenField hdnTrgTo = new HiddenField();
                HiddenField hdnBusiCode = new HiddenField();
                HiddenField hdnEffDtFrm = new HiddenField();
                HiddenField hdnEffDtTo = new HiddenField();
                HiddenField hdnSbCtgry = new HiddenField();
                HiddenField hdnPExcl = new HiddenField();
                HiddenField hdnSExcl = new HiddenField();
                HiddenField hdnSort = new HiddenField();

                hdnRulStKy.Value = dtRwd.Rows[intRowCount]["RULE_SET_KEY"].ToString().Trim();
                lstRulSetKey.Add(hdnRulStKy.Value.ToString().Trim());
                hdnCode.Value = dtRwd.Rows[intRowCount]["CODE"].ToString().Trim();
                lstCode.Add(hdnCode.Value.ToString().Trim());
                hdnCatgCode.Value = dtRwd.Rows[intRowCount]["CATEGORY"].ToString().Trim();
                lstCatgCode.Add(hdnCatgCode.Value.ToString().Trim());
                hdnCycle.Value = dtRwd.Rows[intRowCount]["CYCLE"].ToString().Trim();
                lstCycle.Add(hdnCycle.Value.ToString().Trim());
                hdnCycleCode.Value = dtRwd.Rows[intRowCount]["CYCLE_CODE"].ToString().Trim();
                lstCycleCode.Add(hdnCycleCode.Value.ToString().Trim());
                hdnCatDsc.Value = dtRwd.Rows[intRowCount]["CATG_DESC"].ToString().Trim();
                lstCatgDesc.Add(hdnCatDsc.Value.ToString().Trim());
                hdnKPICode.Value = dtRwd.Rows[intRowCount]["KPI_CODE"].ToString().Trim();
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
                hdnTrgFrm.Value = dtRwd.Rows[intRowCount]["TRG_FRM"].ToString().Trim();
                lstTrgFrm.Add(hdnTrgFrm.Value.ToString().Trim());
                hdnTrgTo.Value = dtRwd.Rows[intRowCount]["TRG_TO"].ToString().Trim();
                lstTrgTo.Add(hdnTrgTo.Value.ToString().Trim());
                hdnEffDtFrm.Value = dtRwd.Rows[intRowCount]["EFFDT_FROM"].ToString().Trim();
                lstEffDtFrm.Add(hdnEffDtFrm.Value.ToString().Trim());
                hdnEffDtTo.Value = dtRwd.Rows[intRowCount]["EFFDT_TO"].ToString().Trim();
                lstEffDtTo.Add(hdnEffDtTo.Value.ToString().Trim());
                hdnBusiCode.Value = dtRwd.Rows[intRowCount]["BUSI_CODE"].ToString().Trim();
                lstBusiCo.Add(hdnBusiCode.Value.ToString().Trim());
                hdnSbCtgry.Value = dtRwd.Rows[intRowCount]["CATSET"].ToString().Trim();
                lstSbCtgry.Add(hdnSbCtgry.Value.ToString().Trim());
                hdnPExcl.Value = dtRwd.Rows[intRowCount]["P_EXCL"].ToString().Trim();
                lstPExcl.Add(hdnPExcl.Value.ToString().Trim());
                hdnSExcl.Value = dtRwd.Rows[intRowCount]["S_EXCL"].ToString().Trim();
                lstSExcl.Add(hdnSExcl.Value.ToString().Trim());
                hdnSort.Value = dtRwd.Rows[intRowCount]["SORT"].ToString().Trim();
                lstSort.Add(hdnSort.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRulSetKey.Count - 1; intDataCount++)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@CODE", lstCode[intDataCount]);
                htParam.Add("@CATG_CODE", lstCatgCode[intDataCount]);
                htParam.Add("@CYCLE", lstCycleCode[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@CATG_DESC01", lstCatgDesc[intDataCount]);
                htParam.Add("@CATG_DESC02", lstCatgDesc[intDataCount]);
                htParam.Add("@CATG_DESC03", lstCatgDesc[intDataCount]);
                htParam.Add("@EFF_FROM", lstEffDtFrm[intDataCount]);
                htParam.Add("@EFF_TO", lstEffDtTo[intDataCount]);
                htParam.Add("@FIN_YEAR", lstBusiCo[intDataCount]);
                htParam.Add("@VER_NO", lblVerVal.Text.ToString().Trim());
                htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                htParam.Add("@KPI_TRGT_FROM", lstTrgFrm[intDataCount]);
                htParam.Add("@KPI_TRGT_TO", lstTrgTo[intDataCount]);
                htParam.Add("@KPI_CODE", lstKPICode[intDataCount]);
                htParam.Add("@CATSET", lstSbCtgry[intDataCount]);
                htParam.Add("@P_EXCL", lstPExcl[intDataCount]);
                htParam.Add("@S_EXCL", lstSExcl[intDataCount]);
                htParam.Add("@SORT", lstSort[intDataCount]);
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ////htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdTrgDtls", htParam);
            }
            hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
            mdlpopup.Show();
            lbl3.Text = "KPI Targets saved successfully for rewards";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            btnSaveRwdTrg.Enabled = true;
            #endregion
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStpView", "SaveTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    } 
    #endregion

    #region lnkValue_Click
    protected void lnkValue_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpFrml();", true);
    } 
    #endregion

    #region BindAuditGrid
    protected void BindAuditGrid(string strCompcode1)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", strCompcode1);
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAuditData", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdAudit.DataSource = ds.Tables[0];
                gdAudit.DataBind();
            }
            else
            {
                divAudit.Visible = false;
            }
        }
        else
        {
            divAudit.Visible = false;
        }
    } 
    #endregion


}
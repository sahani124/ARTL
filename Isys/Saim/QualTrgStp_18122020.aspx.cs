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

public partial class Application_ISys_Saim_QualTrgStp : BaseClass
{

    #region Declaration
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpstd, cntst;
    DataTable dtSession = new DataTable();
    static int num = 0;
    static int incrcnt;
    string cmpcode, cntstcd;
    List<string> lstRsk = new List<string>();
    ListItem lst = new ListItem();
    String strCode = "";
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
            incrcnt = 1;
            InitializeControl();
            hdnSortNo.Value = "0";
            hdnTrgCnt.Value = "0";
            ShowRulStKy();
            ddlKPICode.Items.Insert(0, new ListItem("--SELECT--", ""));
            GetCycles();
            BindGrid();

           
            if (hdnIsValid.Value == "W")
            {
                hdnTargetFrom.Value = txtTrgTo.Text;
            }
            else
            {
            hdnTargetFrom.Value= txtTrgFrm.Text;
            }
            hdnTargetTo.Value = txtTrgTo.Text;

            txtCatgCode.Text = "";
            ShowSubCatg();
            btnAdd.Enabled = true;
            if (Request.QueryString["sort"] != null && Request.QueryString["sort"] != "")
            {
                txtSort.Text = Request.QueryString["sort"].ToString().Trim();
                txtSort.Text = (Convert.ToInt32(txtSort.Text) + 1).ToString().Trim();
                hdnSortNo.Value = txtSort.Text.ToString().Trim();
            }
            else
            {
                txtSort.Text = "1";
            }

            if (Request.QueryString["code"] != null)
            {
                if (Request.QueryString["FlagEnquiry"] == null)
                {

                    FillCatg();
                    ddlCatgDesc.Visible = false;
                }
                if (Request.QueryString["FlagEnquiry"] != null)
                {
                    CheckEquiry();


                    //FillCatg();
                }

            }
            
            else
            {
                rblPExcl.SelectedValue = "1";
                rblSExcl.SelectedValue = "1";
                GetTmpTrg("3");
                DataTable dtTmp = new DataTable();
                dtTmp = FillGrdTmp("7");
                if (dtTmp.Rows.Count > 0)
                {
                    dgQualTrg.DataSource = dtTmp;
                    dgQualTrg.DataBind();
                }
                else
                {
                    ShowNoResultFound(dtTmp, dgQualTrg);
                }
                if (ddlRulSetKy.SelectedValue == "")
                {
                    imgRul.Visible = false;
                    imgCyc.Visible = false;
                    imgCatg.Visible = false;
                    imgKPI.Visible = false;
                    imgRulP.Visible = false;
                    imgCycP.Visible = false;
                    imgCatgP.Visible = false;
                    imgKPIP.Visible = false;
                    ddlRulSetKy.Enabled = true;
                    //btnAdd.Enabled = false;
                }
                else
                {
                    imgRul.Visible = true;
                    imgCyc.Visible = true;
                    imgCatg.Visible = true;
                    imgKPI.Visible = true;
                    imgRulP.Visible = false;
                    imgCycP.Visible = false;
                    imgCatgP.Visible = false;
                    imgKPIP.Visible = false;
                    ddlRulSetKy.Enabled = true;
                    //11
                    //bbtnAdd.Enabled = false;
                }
                ddlCyc_SelectedIndexChanged(sender, e);
                ddlCatgDesc_SelectedIndexChanged(sender, e);
                ddlKPICode_SelectedIndexChanged(sender, e);
                ddlRulSetKy_SelectedIndexChanged(sender, e);
                Session["T"] = null;
                Session["D"] = null;
                Session["tmpTb"] = FillGrdTmp("7");
                GetTrgValue("tmpTb", 16);
            }

           
            
        }
        
      //  btnAdd.Attributes.Add("onclick", "javascript:return validTargets();");
    }
    #endregion

    #region GetCatgMstDtls
    public void GetCatgMstDtls(string rulesetcd)
    {
        DataSet dscatg = new DataSet();
        Hashtable htcatg = new Hashtable();
        htcatg.Clear();
        dscatg.Clear();
        htcatg.Add("@cmpcode", Request.QueryString["compcode"].ToString().Trim());
        htcatg.Add("@cntstcode", Request.QueryString["cntstcd"].ToString().Trim());
        htcatg.Add("@rulesetcd", rulesetcd.ToString().Trim());
        htcatg.Add("@flag", "2");
        htcatg.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
        dscatg = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleMstDtls", htcatg);
        if (dscatg.Tables.Count > 0 && dscatg.Tables[0].Rows.Count > 0)
        {
            ddlCatgDesc.Items.Clear();

            ddlCatgDesc.DataSource = dscatg;
            ddlCatgDesc.DataTextField = dscatg.Tables[0].Columns[4].ToString().Trim();
            ddlCatgDesc.DataValueField = dscatg.Tables[0].Columns[3].ToString().Trim();
            ddlCatgDesc.DataBind();

            ddlCatgDesc.Items.Insert(0, new ListItem("--SELECT--", ""));
            ddlCatgDesc.Visible = true;
            txtCatgDesc.Visible = false;
            ////txtCatgCode.Text = "";
        }
        else
        {
            ddlCatgDesc.Visible = false;
            txtCatgDesc.Visible = true;
        }
    }
    #endregion

    protected void CheckIsWeighted()
    {
        try
        {
            DataSet chkW = new DataSet();
            chkW.Clear();
            hdnIsValid.Value = "";
            //hdnIsValid.Value = "";
            htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
            htParam.Add("@RuleSetCode", ddlRulSetKy.SelectedValue.ToString().Trim());
            chkW = objDal.GetDataSetForPrc_SAIM("Prc_GetRuleMethodFlag", htParam);
            if (chkW.Tables.Count > 0 && chkW.Tables[0].Rows.Count > 0)
            {

                if ((chkW.Tables[0].Rows[0]["RULE_METHOD"].ToString() == "W"))
                {
                   
                       
                        //hdnIsValid.Value = "W";
                        txtTrgFrm.Text = "";
                        txtTrgTo.Text = "0.00";
                        txtTrgTo.Enabled = false;
                        divScore.Visible = true;
                        divWeighted.Visible = true;
                        hdnIsValid.Value = "W";
                    
                    
                    //WScore="Yes;
                }
                else
                {
                    // rblCRYFWD.SelectedIndex = 0;
                    divScore.Visible = false;
                    divWeighted.Visible = false;
                    txtTrgTo.Enabled = true;

                }

            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "CheckIsWeighted", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void CheckEquiry()
    {
        try
        {
           
               DataTable dt = new DataTable();
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["code"] != null)
        {
            htParam.Add("@CODE", Request.QueryString["code"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls_Revised", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //ddlRulSetKy.SelectedItem.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                //txtRskDesc.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY_DESC"].ToString().Trim();
                ddlRulSetKy.SelectedValue = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                txtRskDesc.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();

                txtCatgCode.Text = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();

              //  txtCatgCode.Text = ddlCatgDesc.SelectedValue;
                // ddlMemberCycle.SelectedItem.Text = ddlCatgDesc.SelectedValue;
                string catg = txtCatgCode.Text.ToString();
                FillMemberCycleDdl(catg);

                ddlMemberCycle.SelectedValue = ds.Tables[0].Rows[0]["MEMBER_CYCLE"].ToString().Trim();
                ddlCatgDesc.SelectedValue = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
                txtCatgDesc.Text = ds.Tables[0].Rows[0]["CATG_DESC"].ToString().Trim();
                FillddlKPI(ddlKPICode, "Prc_GetRwrdRuleVal", "5", "KPI_DESC", "KPI_CODE", ddlRulSetKy.SelectedValue.ToString().Trim());
                ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtKpiName.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                // ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtTrgFrm.Text = ds.Tables[0].Rows[0]["TRG_FRM"].ToString().Trim();
                txtTrgTo.Text = ds.Tables[0].Rows[0]["TRG_TO"].ToString().Trim();
                txtSubCtgry.Text = ds.Tables[0].Rows[0]["CATSET"].ToString().Trim();
                rblPExcl.SelectedValue = ds.Tables[0].Rows[0]["P_EXCL"].ToString().Trim();
                rblSExcl.SelectedValue = ds.Tables[0].Rows[0]["S_EXCL"].ToString().Trim();
                txtSort.Text = ds.Tables[0].Rows[0]["SORT"].ToString().Trim();
                ddlCyc.SelectedValue = ds.Tables[0].Rows[0]["CYCLE_CODE"].ToString().Trim();
                txtEffFrom.Text = ds.Tables[0].Rows[0]["EFFDT_FROM"].ToString().Trim();
                txtEffTo.Text = ds.Tables[0].Rows[0]["EFFDT_TO"].ToString().Trim();
                string chkdefn = ds.Tables[0].Rows[0]["STDDEFN"].ToString().Trim();
                if (chkdefn == "1")
                {
                    chkStdTrg.Checked = true;
                }
                else if (chkdefn == "0")
                {
                    chkStdTrg.Checked = false;
                }
                chkStdTrg.Enabled = false;
                chkAllCyc.Enabled = false;

                txtCatgCode.Enabled = false;
                ddlRulSetKy.Enabled = false;
                txtSubCtgry.Enabled = false;
                txtSort.Enabled = false;
                // ddlCatgDesc.Enabled = false;
                txtCatgDesc.Enabled = false;
                lnkNewCatg.Enabled = false;
                txtKpiName.Enabled = false;
                ddlKPICode.Enabled = false;

                dgQualTrg.DataSource = ds.Tables[0];
                dgQualTrg.DataBind();


                div3.Visible = false;
                btnAdd.Visible = false;
                btnAddMaster.Visible = false;
                ddlCatgDesc.Visible = false;
                btnEnqSave.Visible = true;
                btnCncl.Visible = true;
            }


        }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "CheckEquiry", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsTempData();
       // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel('" + Request.QueryString["rultyp"].ToString().Trim() + "','');", true);
    }

     protected void InsTempData()
    {
        DataSet dsTemp = new DataSet();

        Hashtable htTemp = new Hashtable();

      
        htTemp.Add("@code", Request.QueryString["code"].ToString().Trim());

        htTemp.Add("@KPI_TRGT_FROM", txtTrgFrm.Text.ToString());
        htTemp.Add("@KPI_TRGT_TO", txtTrgTo.Text.ToString());
        dsTemp = objDal.GetDataSetForPrc_SAIM("PrcUpdateTarget", htTemp);
       
            
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Data Updated Successfully ');", true);

             ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel('" + Request.QueryString["rultyp"].ToString().Trim() + "','');", true);
               
        
     }



    #region btnCncl_Click
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel('" + Request.QueryString["rultyp"].ToString().Trim() + "','');", true);
    }
    #endregion

    #region btnprevious_Click
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex - 1;
            FillGrid(Convert.ToInt32(hdnCount.Value.ToString().Trim()), hdnSetTrgRul.Value.ToString().Trim(), Request.QueryString["sID"].ToString().Trim());
            if (dgQualTrg.PageCount > 1)
            {
                btnprevious.Enabled = true;
            }
            else
            {
                btnprevious.Enabled = false;
            }
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnnext_Click
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex + 1;
            FillGrid(Convert.ToInt32(hdnCount.Value.ToString().Trim()), hdnSetTrgRul.Value.ToString().Trim(), Request.QueryString["sID"].ToString().Trim());
            if (dgQualTrg.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgQualTrg.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgQualTrg.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region BindGrid
    protected void BindGrid()
    {
        ds = new DataSet();
        DataTable dt = new DataTable();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CATG_CODE", txtCatgCode.Text.ToString().Trim());
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        }
        if (Session["gridTrg"] != null)
        {
            dt = (DataTable)Session["gridTrg"];

            if (dt.Rows.Count > 0)
            {
                ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls", htParam);
                dt = ds.Tables[0];
            }
            else
            {
                dt = (DataTable)Session["gridTrg"];
            }
        }
        if (dt.Rows.Count > 0)
        {
            dgQualTrg.DataSource = dt;
            dgQualTrg.DataBind();
            dt.Rows.Clear();
            ShowNoResultFound(dt, dgQualTrg);
            //if (dgQualTrg.PageCount > 1)
            //{
            //    btnnext.Enabled = true;
            //}
            //else
            //{
            //    btnnext.Enabled = false;
            //}
        }
        else
        {
            ShowNoResultFound(dt, dgQualTrg);
        }
        btnprevious.Enabled = false;
        btnnext.Enabled = false;
        ViewState["grid"] = dt;
        Session["Trg"] = dt;
    } 
    #endregion

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
        gv.Rows[0].Cells[0].Text = "No targets have been defined";
        source.Rows.Clear();
    }

    protected void FillddlKPI(DropDownList ddl, string proc, string flag, string text, string value, string rulsetky)
    {
        htParam.Clear();
        ddl.Items.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        if (Request.QueryString["compcode"] != null)
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

    protected void FillMemberCycleDdl()
    {
        //int index = 1;
        DataSet dsM = new DataSet();
        dsM.Clear();
        Hashtable htParaMem = new Hashtable();
        htParaMem.Clear();
        htParaMem.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        htParaMem.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        htParaMem.Add("@RuleSetKey", ddlRulSetKy.SelectedValue.ToString().Trim());
       // htParaMem.Add("@CategoryCode", catg.ToString().Trim());

        dsM = objDal.GetDataSetForPrc_SAIM("Prc_FillMemberCycle", htParaMem);
        if (dsM.Tables.Count > 0 && dsM.Tables[0].Rows.Count > 0)
        {
            ddlMemberCycle.Items.Clear();

            ddlMemberCycle.DataSource = dsM;
            ddlMemberCycle.DataTextField = dsM.Tables[0].Columns[0].ToString().Trim();
            ddlMemberCycle.DataValueField = dsM.Tables[0].Columns[1].ToString().Trim();
            ddlMemberCycle.DataBind();

           // ddlMemberCycle.SelectedIndex = index;
         


        }
        ddlMemberCycle.Items.Insert(0, new ListItem("--SELECT--", ""));

    }



    
    protected void FillMemberCycleDdl(string catg)
    {
       DataSet dsM = new DataSet();
        dsM.Clear();
        Hashtable htParaMem = new Hashtable();
        htParaMem.Clear();
        htParaMem.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        htParaMem.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        htParaMem.Add("@RuleSetKey", ddlRulSetKy.SelectedValue.ToString().Trim());
        htParaMem.Add("@CategoryCode", catg.ToString().Trim());

        dsM = objDal.GetDataSetForPrc_SAIM("Prc_FillMemberCycle", htParaMem);
        if (dsM.Tables.Count > 0 && dsM.Tables[0].Rows.Count > 0)
        {
            ddlMemberCycle.Items.Clear();

            ddlMemberCycle.DataSource = dsM.Tables[0];
            ddlMemberCycle.DataTextField = dsM.Tables[0].Columns["RuleCode"].ToString().Trim();
                //Rows[0]["RuleCode"].ToString().Trim();
            ddlMemberCycle.DataValueField = dsM.Tables[0].Columns["CategoryCode"].ToString().Trim();
            ddlMemberCycle.DataBind();

            
      
        }
       // ddlMemberCycle.Items.Insert(0, new ListItem("--SELECT--", ""));
      
    }

    #region ShowRulStKy
    protected void ShowRulStKy()
    {
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", "1");
        if (Request.QueryString["compcode"] != null)
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
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRulSetKy.DataSource = ds;
            ddlRulSetKy.DataTextField = "RULE_SET_KEY_DESC";
            ddlRulSetKy.DataValueField = "RULE_SET_KEY";
            ddlRulSetKy.DataBind();
            CheckIsWeighted();
        }
        if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            hdnCount.Value = ds.Tables[1].Rows[0]["COUNT"].ToString().Trim();
            hdnSetTrgRul.Value = ds.Tables[1].Rows[0]["SET_TRG_RULE"].ToString().Trim();
            hdnBusiYear.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnbusicode.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnAccCyc.Value = ds.Tables[1].Rows[0]["CYCLE_TYPE"].ToString().Trim();
        }
        ddlRulSetKy.Items.Insert(0, new ListItem("--SELECT--", ""));
    } 
    #endregion

    #region ShowCatgCode
    protected void ShowCatgCode()
    {
        ds = new DataSet();
        ds.Clear();
        if (Request.QueryString["catgcd"] != null && Request.QueryString["catgcd"] != "")
        {
            txtCatgCode.Text = Request.QueryString["catgcd"].ToString().Trim();
            txtCatgCode.Text = (Convert.ToInt32(txtCatgCode.Text) + 1).ToString().Trim();
        }
        else
        {
            htParam.Clear();
            htParam.Add("@flag", "3");
            if (Request.QueryString["compcode"] != null)
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
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtCatgCode.Text = ds.Tables[0].Rows[0]["CATG_CODE"].ToString().Trim();
                string a = ds.Tables[0].Rows[0]["INCR"].ToString().Trim();
                if (a == "DB")
                {
                    txtCatgCode.Text = (Convert.ToInt32(txtCatgCode.Text) + 1).ToString().Trim();
                }
            }
        }
    }
    #endregion

    protected void txtTrgFrm_TextChanged(object sender, EventArgs e)
    {
        if (hdnIsValid.Value == "W")
        {
            txtTrgTo.Text = txtTrgFrm.Text.ToString();
        }
        else
        {
            
        }
       
    }

    #region ShowSubCatg
    protected void ShowSubCatg()
    {
        ds = new DataSet();
        ds.Clear();
        if (Request.QueryString["catgsbcd"] != null && Request.QueryString["catgsbcd"] != "")
        {
            txtSubCtgry.Text = Request.QueryString["catgsbcd"].ToString().Trim();
        }
        else
        {
            htParam.Clear();
            htParam.Add("@flag", "5");
            if (Request.QueryString["compcode"] != null)
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
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSubCtgry.Text = ds.Tables[0].Rows[0]["CAT_SET"].ToString().Trim();
            }
        }

    }
    #endregion

    #region FillGrid
    protected void FillGrid(int cyc, string trgrule,string sID)
    {
        int cnt = 0;
        decimal trgfrm = 0;
        decimal trgto = 0;
        decimal split = 0;
        DataTable dtPrev = new DataTable();
        DataTable dt = new DataTable();

        dt.Columns.Add("RULE_SET_KEY_DESC");
        dt.Columns.Add("RULE_SET_KEY");
        dt.Columns.Add("CODE");
        dt.Columns.Add("CATEGORY");
        dt.Columns.Add("CYCLE");
        dt.Columns.Add("CYCLE_CODE");
        dt.Columns.Add("CATG_DESC");
        dt.Columns.Add("KPI_CODE");
        dt.Columns.Add("KPI_DESC");
        dt.Columns.Add("BUSI_CODE");
        dt.Columns.Add("TRG_FRM");
        dt.Columns.Add("TRG_TO");
        dt.Columns.Add("EFFDT_FROM");
        dt.Columns.Add("EFFDT_TO");
        dt.Columns.Add("CATSET");
        dt.Columns.Add("P_EXCL_DESC");
        dt.Columns.Add("P_EXCL");
        dt.Columns.Add("S_EXCL");
        dt.Columns.Add("S_EXCL_DESC");
        dt.Columns.Add("SORT");
        dt.Columns.Add("STDDEFN");
        dt.Columns.Add("WEIGHTED");
        dt.Columns.Add("MIN_WEIGHTED");
        dt.Columns.Add("MAX_WEIGHTED");
        dt.Columns.Add("MEMBER_CYCLE");
        dt.Columns.Add("MEM_CODE");
        dt.Columns.Add("MEM_UNT_CODE");
        

        DataTable dtCyc = new DataTable();
        DataTable dtCode = new DataTable();
        DataTable dtTmp = new DataTable();
        dtCyc.Clear();
        int code = 0;
        dtCyc = Search("C", hdnbusicode.Value.ToString().Trim(), hdnAccCyc.Value.ToString().Trim());
        if (ddlKPICode.SelectedValue.ToString().Trim() != "")
        {
            
            //if (Session["D"] != null)
            //{
            //    ////dt = (DataTable)Session["D"];
            //    if (dt.Rows.Count > 0)
            //    {
            //        code = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["CODE"].ToString().Trim()) + 1;
            //    }
            //    else
            //    {
            //        code = Convert.ToInt32(GetMaxCode("3"));
            //    }
            //}
            //else
            //    dt = Session["tmpTb"] as DataTable;
           




            if (Request.QueryString["code"] == null)
            {
                if (dgQualTrg.Rows.Count > 0)
                {
                    if (dgQualTrg.Rows[0].Cells[0].Text != "No targets have been defined")
                    {
                        foreach (GridViewRow gvr in dgQualTrg.Rows)
                        {
                            DataRow dr1 = dt.NewRow();

                            Label lblRulStKy = gvr.FindControl("lblRulStKy") as Label;
                            HiddenField hdnRulStKy = gvr.FindControl("hdnRulStKy") as HiddenField;
                            HiddenField hdnBusiCode = gvr.FindControl("hdnBusiCode") as HiddenField;
                            HiddenField hdnCode = gvr.FindControl("hdnCode") as HiddenField;
                            Label lblCatgCode = gvr.FindControl("lblCatgCode") as Label;
                            HiddenField hdnCycle = gvr.FindControl("hdnCycle") as HiddenField;
                            HiddenField hdnCatDsc = gvr.FindControl("hdnCatDsc") as HiddenField;
                            HiddenField hdnKPICode = gvr.FindControl("hdnKPICode") as HiddenField;
                            HiddenField hdnTrgFrm = gvr.FindControl("hdnTrgFrm") as HiddenField;
                            HiddenField hdnTrgTo = gvr.FindControl("hdnTrgTo") as HiddenField;
                            HiddenField hdnEffFrom = gvr.FindControl("hdnEffFrom") as HiddenField;
                            HiddenField hdnEffTo = gvr.FindControl("hdnEffTo") as HiddenField;
                            HiddenField hdnCATSET = gvr.FindControl("hdnCATSET") as HiddenField;
                            HiddenField hdnP_EXCL = gvr.FindControl("hdnP_EXCL") as HiddenField;
                            HiddenField hdnS_EXCL = gvr.FindControl("hdnS_EXCL") as HiddenField;
                            HiddenField hdnSORT = gvr.FindControl("hdnSORT") as HiddenField;
                            Label lblKPICode = gvr.FindControl("lblKPICode") as Label;
                            Label lblP_EXCL = gvr.FindControl("lblP_EXCL") as Label;
                            Label lblS_EXCL = gvr.FindControl("lblS_EXCL") as Label;
                            Label lblCatDsc = gvr.FindControl("lblCatDsc") as Label;
                            Label lblCycle = gvr.FindControl("lblCycle") as Label;
                            HiddenField hdnStdDefn = gvr.FindControl("hdnStdDefn") as HiddenField;
                            HiddenField hdnMinWeighted = gvr.FindControl("hdnMinWeighted") as HiddenField;
                            HiddenField hdnMaxWeighted = gvr.FindControl("hdnMaxWeighted") as HiddenField;
                            HiddenField hdnWeighted = gvr.FindControl("hdnWeighted") as HiddenField;
                            Label lblMemberCycle = gvr.FindControl("lblMemberCycle") as Label;
                            HiddenField hdnMemCode = gvr.FindControl("hdnMemCode") as HiddenField;

                            HiddenField hdnMemLoc = gvr.FindControl("hdnMemLoc") as HiddenField;

                            dr1["RULE_SET_KEY_DESC"] = lblRulStKy.Text.ToString().Trim();
                            dr1["RULE_SET_KEY"] = hdnRulStKy.Value.ToString().Trim();
                            dr1["CODE"] = hdnCode.Value.ToString().Trim();
                            dr1["CATEGORY"] = lblCatgCode.Text.ToString().Trim();
                            dr1["CATG_DESC"] = lblCatDsc.Text.ToString().Trim();
                            dr1["CYCLE"] = lblCycle.Text.ToString().Trim();
                            dr1["CYCLE_CODE"] = hdnCycle.Value.ToString().Trim();

                            dr1["MEMBER_CYCLE"] = lblMemberCycle.Text.ToString().Trim();
                            dr1["KPI_DESC"] = lblKPICode.Text.ToString().Trim();
                            dr1["KPI_CODE"] = hdnKPICode.Value.ToString().Trim();
                            dr1["BUSI_CODE"] = hdnBusiCode.Value.ToString().Trim();
                            dr1["TRG_FRM"] = hdnTrgFrm.Value.ToString().Trim();
                            dr1["TRG_TO"] = hdnTrgTo.Value.ToString().Trim();
                            dr1["EFFDT_FROM"] = hdnEffFrom.Value.ToString().Trim();
                            dr1["EFFDT_TO"] = hdnEffTo.Value.ToString().Trim();
                            dr1["CATSET"] = hdnCATSET.Value.ToString().Trim();
                            dr1["P_EXCL"] = hdnP_EXCL.Value.ToString().Trim();
                            dr1["S_EXCL"] = hdnS_EXCL.Value.ToString().Trim();
                            dr1["P_EXCL_DESC"] = lblP_EXCL.Text.ToString().Trim();
                            dr1["S_EXCL_DESC"] = lblS_EXCL.Text.ToString().Trim();
                            dr1["SORT"] = hdnSORT.Value.ToString().Trim();
                            dr1["STDDEFN"] = hdnStdDefn.Value.ToString().Trim();
                            dr1["MIN_WEIGHTED"] = hdnMinWeighted.Value.ToString().Trim();
                            dr1["MAX_WEIGHTED"] = hdnMaxWeighted.Value.ToString().Trim();
                            dr1["WEIGHTED"] = hdnWeighted.Value.ToString().Trim();
                            dr1["MEM_CODE"] = hdnMemCode.Value.ToString().Trim();
                            dr1["MEM_UNT_CODE"] = hdnMemLoc.Value.ToString().Trim();
                            dt.Rows.Add(dr1);
                        }
                    }
                }
            }
            if (Request.QueryString["code"] != null)
            {
                code = Convert.ToInt32(Request.QueryString["code"].ToString().Trim());
            }
            else
            {
                code = Convert.ToInt32(GetMaxCode("3"));
            }
            DataRow dr = dt.NewRow();
            dr["RULE_SET_KEY_DESC"] = ddlRulSetKy.SelectedItem.Text.ToString().Trim();
            dr["RULE_SET_KEY"] = ddlRulSetKy.SelectedValue.ToString().Trim();
            dr["CODE"] = code.ToString().Trim();
            dr["CATEGORY"] = txtCatgCode.Text.ToString().Trim();
            if (txtCatgDesc.Text != "")
            {
                dr["CATG_DESC"] = txtCatgDesc.Text.ToString().Trim();
            }
            else
            {
                dr["CATG_DESC"] = ddlCatgDesc.SelectedItem.Text.ToString().Trim();
            }
            dr["CYCLE"] = ddlCyc.SelectedItem.Text.ToString().Trim();
            dr["CYCLE_CODE"] = ddlCyc.SelectedValue.ToString().Trim();

            dr["MEMBER_CYCLE"] = ddlMemberCycle.SelectedItem.Text.ToString().Trim();
            dr["KPI_CODE"] = ddlKPICode.SelectedValue.ToString().Trim();
            dr["KPI_DESC"] = ddlKPICode.SelectedItem.ToString().Trim();
            dr["BUSI_CODE"] = hdnbusicode.Value.ToString().Trim();
            dr["TRG_FRM"] = txtTrgFrm.Text.ToString().Trim();
            //if (trgrule == "1001")
            //{
            //    dr["TRG_TO"] = (Convert.ToDecimal(txtTrgTo.Text.ToString().Trim()) / 2).ToString();
            //}
            //else
            //{
            //    dr["TRG_TO"] = txtTrgTo.Text.ToString().Trim();
            //}

            dr["TRG_TO"] = txtTrgTo.Text.ToString().Trim();
            dr["EFFDT_FROM"] = txtEffFrom.Text.ToString().Trim();
            dr["EFFDT_TO"] = txtEffTo.Text.ToString().Trim();
            dr["CATSET"] = txtSubCtgry.Text.ToString().Trim();
            dr["P_EXCL"] = rblPExcl.SelectedValue.ToString().Trim();
            dr["S_EXCL"] = rblSExcl.SelectedValue.ToString().Trim();
            dr["P_EXCL_DESC"] = rblPExcl.SelectedItem.Text.ToUpper().ToString().Trim();
            dr["S_EXCL_DESC"] = rblSExcl.SelectedItem.Text.ToUpper().ToString().Trim();
            dr["SORT"] = txtSort.Text.ToString().Trim();
            dr["MAX_WEIGHTED"] = txtScoreTo.Text.ToString().Trim();
            dr["WEIGHTED"] = txtWeighted.Text.ToString().Trim();
            dr["MIN_WEIGHTED"] = txtScoreFrom.Text.ToString().Trim();
           
            dr["MEM_CODE"] = hdnAgentCode.Value.ToString().Trim();
           
            dr["MEM_UNT_CODE"] = ddlMemLoc.SelectedValue.ToString().Trim();
           // str_Weigth = Convert.ToInt32(txtWeighted.Text.ToString().Trim());
            //strKpiCode = ddlKPICode.SelectedValue.ToString().Trim();

            if (chkStdTrg.Checked == true)
            {
                dr["STDDEFN"] = "1";
            }
            else
            {
                dr["STDDEFN"] = "0";
            }
            dt.Rows.Add(dr);

            string KPICode = ddlKPICode.SelectedValue.ToString().Trim();
            ddlKPICode.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        
        if (dt.Rows.Count > 0)
        {
            dgQualTrg.DataSource = dt;
            dgQualTrg.DataBind();
            Session["D"] = dt;
            txtTrgFrm.Text = txtTrgTo.Text + 1;
           
        }

      
        string trg;
        if (dt.Rows.Count >= ddlKPICode.Items.Count)
        {
            trg = dt.Rows[dt.Rows.Count - ddlKPICode.Items.Count]["TRG_TO"].ToString().Trim();
            float a = float.Parse(trg.ToString().Trim()) + 1;
            txtTrgFrm.Text = a.ToString();
            //txtTrgFrm.Text = (Convert.ToInt32(trg.ToString().Trim()) + 1).ToString().Trim();
        }
        trg = dgQualTrg.Rows[0].Cells[5].Text.ToString().Trim();
       
        
        int index = ddlKPICode.SelectedIndex;
        txtWeighted.Text = "";
        txtScoreTo.Text = "";
        txtScoreFrom.Text = "";
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (hdnRulClass.Value == "NS")
        {
            if (hdnAgentCode.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Code');", true);
                return;
            }
            if(ddlMemLoc.Visible==true)
            {
                if(ddlMemLoc.SelectedIndex==0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Location');", true);
                    return;
                }
            }
        }
        if(hdnIsValid.Value=="W")
        {
            if(txtScoreFrom.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please enter score from value ');", true);
                return;
            }
            if (txtScoreTo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please enter score to value ');", true);
                return;
            }
            if (txtWeighted.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please enter weighted value ');", true);
                return;
            }

        }else
        {
        if (txtTrgFrm.Text.Contains(".") == true)
        {
            if (Convert.ToDecimal(txtTrgFrm.Text) > Convert.ToDecimal(txtTrgTo.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Target From is greater than Target To');", true);
                return;
            }
        }
        }
        

        int i;
        if (!int.TryParse(txtTrgFrm.Text, out i))
            i = 0;

        float f;
        if (!float.TryParse(txtTrgFrm.Text, out f))
            f = 0;

        if (i > f)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Target From is greater than Target To');", true);
            return;
        }

        
        
        
        if (rblSExcl.Items[0].Selected == false && rblSExcl.Items[1].Selected == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please select Secondary Exclusive');", true);
            return;
        }
        if (Request.QueryString["sID"] != null)
        {
            //Data fill inot
            FillGrid(Convert.ToInt32(hdnCount.Value.ToString().Trim()), hdnSetTrgRul.Value.ToString().Trim(), Request.QueryString["sID"].ToString().Trim());
        }
        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"].ToString().Trim() == "R")
            {
                if (Session["gridTrg"] != null)
                {
                    dtSession = (DataTable)Session["gridTrg"];
                }
            }
            else if (Request.QueryString["rultyp"].ToString().Trim() == "Q")
            {
                if (Session["QualTrg"] != null)
                {
                    dtSession = (DataTable)Session["QualTrg"];
                }
            }
        }

       
        GetTrgCnt(ddlRulSetKy.SelectedValue.ToString().Trim(), "1");


        //Uncomment by Prathamesh on 28_02_2018 start

        //if (dtSession.Rows.Count > 0)
        //{
        //    GetTrgCnt(ddlRulSetKy.SelectedValue.ToString().Trim(), "1");
        //    num = Convert.ToInt32(hdnTrgCnt1.Value);
        //    Session["QualTrg"] = null;
        //}
        //else
        //{
        //    num = Convert.ToInt32(txtSort.Text) + 1;
        //}

        //Uncomment by Prathamesh on 28_02_2018 end


        num = Convert.ToInt32(txtSort.Text);
        txtSort.Text = (Convert.ToInt32(txtSort.Text) + 1).ToString().Trim();
        if (hdnTrgCnt.Value == num.ToString().Trim())
        {
            ddlRulSetKy.Items.RemoveAt(ddlRulSetKy.SelectedIndex);
            //foreach (string val in lstRsk)
            //{
            //    ddlRulSetKy.Items.Remove(val);
            //    /////ddlRulSetKy.Items.FindByValue(val.ToString());
            //}
            imgRulP.Visible = true;
            imgCycP.Visible = true;           
            imgKPIP.Visible = true;
            imgCatgP.Visible = true;
            btnAdd.Enabled = false;
            
            imgRul.Visible = false;
            imgKPI.Visible = false;
            imgCyc.Visible = false;
            imgCatg.Visible = false;

            chkConfTrg.Enabled = true;
            ddlRulSetKy.SelectedValue = "";
            ddlCatgDesc.SelectedValue = "";
            ddlCyc.SelectedValue = "";
            ddlKPICode.SelectedValue = "";
            txtCatgCode.Text = "";
            txtEffFrom.Text = "";
            txtEffTo.Text = "";
            txtRskDesc.Text = "";
            txtKpiName.Text = "";
            txtTrgFrm.Text = "";
            txtTrgTo.Text = "";
            txtWeighted.Text = "";
            txtScoreFrom.Text = "";
            txtScoreTo.Text = "";
            ddlMemLoc.SelectedValue = "";

            //if (txtTrgTo.Text== null)
            //{
            //    btnAdd.Enabled = false;
            //}
            txtSort.Text = "";
            btnAdd.Enabled = false;
          //  btnAdd.Visible = false;

            

            if (ddlRulSetKy.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('You have completed adding records for the Rule Set Keys.Click on Save to proceed ');", true);
                ////ddlRulSetKy.Enabled = false;
                return;
            }
            //else
            //{
            //    ddlRulSetKy.Enabled = true;
            //}
       
            ddlRulSetKy.Enabled = false;
        }
        else if (ddlKPICode.SelectedIndex == ddlKPICode.Items.Count - 1)
        {
            imgRulP.Visible = false;
            imgCycP.Visible = false;
            imgCatgP.Visible = false;
            imgKPIP.Visible = false;
            if (ddlCatgDesc.SelectedIndex == ddlCatgDesc.Items.Count - 1)
            {
                ddlCyc.SelectedIndex = ddlCyc.SelectedIndex == ddlCyc.Items.Count - 1 ? 1 : ddlCyc.SelectedIndex + 1;
                ddlCyc_SelectedIndexChanged(sender, e);
                ddlCatgDesc.SelectedIndex = 1;
            }
            else
            {
                ddlCatgDesc.SelectedIndex = ddlCatgDesc.SelectedIndex + 1;
                //ddlMemberCycle.SelectedIndex = ddlMemberCycle.SelectedIndex + 1;
             
            }
            ddlKPICode.Items.RemoveAt(ddlKPICode.SelectedIndex);
            ddlCatgDesc_SelectedIndexChanged(sender, e);
            FillddlKPI(ddlKPICode, "Prc_GetRwrdRuleVal", "5", "KPI_DESC", "KPI_CODE", ddlRulSetKy.SelectedValue.ToString().Trim());
            
            //comment by Prathamesh on 01_03_2018 start
            ddlKPICode.SelectedIndex = 1;
            ddlKPICode_SelectedIndexChanged(sender, e);
            //comment by Prathamesh on 01_03_2018 end

            //ddlCatgDesc.SelectedIndex = 1;

            btnAdd.Enabled = true;
        }
        else
        {
            imgRulP.Visible = false;
            imgCycP.Visible = false;
            imgCatgP.Visible = false;
            imgKPIP.Visible = false;
            ddlKPICode.SelectedIndex = ddlKPICode.SelectedIndex + 1;
            ddlKPICode_SelectedIndexChanged(sender, e);
            ddlKPICode.Items.RemoveAt(ddlKPICode.SelectedIndex - 1);
            /////btnAdd.Enabled = false;
        }
        num = num + 1;
        if (Request.QueryString["code"] == null)
        {
            GetTrgValue("D", 11);
        }
        else
        {
            btnAdd.Enabled = false;
        }
        ChkTargetVal();
        incrcnt = incrcnt + 1;


        //txtTrgFrm.Text=(hdnTrgTo.Value)+1;

        //float a = float.Parse(txtTrgFrm.Text);
        //float b = float.Parse(txtTrgTo.Text);
        
        float d = float.Parse(hdnTrgTo.Value);

        // a =b+ 1;

        if (hdnIsValid.Value == "W")
        {
            txtTrgTo.Text = txtTrgFrm.Text;
        }
        else
        {
        txtTrgTo.Text=hdnTrgTo.Value;
        }

        //txtTrgFrm.Text = (a + 1).ToString();


        
    }

    protected void ddlKPICode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtKpiName.Text = ddlKPICode.SelectedValue.ToString().Trim();
        txtTrgFrm.Text = hdnTrgFrm.Value.ToString().Trim();
        txtTrgTo.Text = hdnTrgTo.Value.ToString().Trim();
        string kpiorg = string.Empty;
        htParam.Clear();
        ds.Clear();
        if (ddlKPICode.SelectedValue != "")
        {
            htParam.Add("@KPICode", ddlKPICode.SelectedValue.ToString().Trim());
            htParam.Add("@Flag", "1");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_KPISearch", htParam);
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hdnTrgFrm.Value = ds.Tables[0].Rows[0]["STD_MIN"].ToString().Trim();
            hdnTrgTo.Value = ds.Tables[0].Rows[0]["STD_MAX"].ToString().Trim();

            if (hdnIsValid.Value == "W")
            {

            txtTrgFrm.Text = ds.Tables[0].Rows[0]["STD_MIN"].ToString().Trim();
                txtTrgTo.Text = ds.Tables[0].Rows[0]["STD_MIN"].ToString().Trim();
            }
            else
            {

                txtTrgFrm.Text = ds.Tables[0].Rows[0]["STD_MIN"].ToString().Trim();
            txtTrgTo.Text = ds.Tables[0].Rows[0]["STD_MAX"].ToString().Trim();
            }

            kpiorg = ds.Tables[0].Rows[0]["KPI_ORIGIN"].ToString().Trim();
        }
        if (kpiorg == "1002")
        {
            chkStdTrg.Checked = false;
            chkStdTrg.Enabled = false;
        }
        else if (kpiorg == "1003")
        {
            chkStdTrg.Checked = false;
            chkStdTrg.Enabled = false;
        }
        else
        {
            chkStdTrg.Checked = false;
            chkStdTrg.Enabled = true;
        }
    }

    protected void btntrg_Click(object sender, EventArgs e)
    {

    }

    protected void btnSaveTrg_Click(object sender, EventArgs e)
    
    {
        if (chkConfTrg.Enabled == true && chkConfTrg.Checked == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please check to confirm the Targets set');", true);
            //chkConfTrg.Focus();
            Page.SetFocus(chkConfTrg); 
            return;
        }

        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"].ToString().Trim() == "R")
            {
                SaveTarget("gridTrg");
            }
            else if (Request.QueryString["rultyp"].ToString().Trim() == "Q")
            {
                SaveTarget("QualTrg");
            }
        }
        
        Session["D"] = null;
        //InsTmpTarget(Request.QueryString["compcode"].ToString().Trim(), Request.QueryString["cntstcd"].ToString().Trim(), Request.QueryString["rultyp"].ToString().Trim(), ddlRulSetKy.SelectedValue.ToString().Trim(),
        //    ddlCatgDesc.SelectedValue.ToString().Trim(), ddlCyc.SelectedValue.ToString().Trim(), ddlKPICode.SelectedValue.ToString().Trim(), txtSubCtgry.Text.ToString().Trim(),
        //    txtTrgFrm.Text.ToString().Trim(), txtTrgTo.Text.ToString().Trim());
    }

    protected DataTable Search(string flag, string yrcode, string cyc)
    {
        string acc_cycle = "";
        DataTable dt_acc = new DataTable();
        Hashtable ht_acc = new Hashtable();
        ht_acc.Clear();

        dt_acc.Clear();
        


        ht_acc.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        ht_acc.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim().ToString().Trim());
        ht_acc.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString());

        ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            acc_cycle = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString();
            hdnCount.Value = ds.Tables[0].Rows[0]["COUNT"].ToString().Trim();

        }

        if (acc_cycle=="P")
        {

            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMST_BUSI_YR", ht_acc);
             if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
             {

             }
             else
             {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please add Cycle from Rule Set Page');", true);
                 txtRskDesc.Text = "";
                 ddlCyc.SelectedIndex = 0;
                 ddlCyc.Enabled = false;
                 ddlKPICode.Enabled = false;
             }


        }
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@BUSI_CODE", yrcode.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@ACC_CYCLE", acc_cycle.Trim());
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        }
		 htParam.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0];
        }
        return ds.Tables[0];
    }

    #region GetMaxCode
    protected string GetMaxCode(string flag)
    {
        ds = new DataSet();
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

    protected void lnkDelRwdTrg_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CODE", hdnCode.Value.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdTrgDtls", htParam);

        ds.Clear();
        htParam.Clear();
        DataTable dt = (DataTable)Session["gridTrg"];
        dt.Rows[rowIndex].Delete();
        dt.AcceptChanges();
        if (dt.Rows.Count > 0)
        {
            dgQualTrg.DataSource = dt;
            dgQualTrg.DataBind();
        }
        else
        {
            ShowNoResultFound(dt, dgQualTrg);
        }
        Session["gridTrg"] = dt;
        ViewState["grid"] = dt;
    }

    protected void dgQualTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtTrgFrm = (TextBox)e.Row.FindControl("txtTrgFrm");
            TextBox txtTrgTo = (TextBox)e.Row.FindControl("txtTrgTo");
            Label lblTrgFrm = (Label)e.Row.FindControl("lblTrgFrm");
            Label lblTrgTo = (Label)e.Row.FindControl("lblTrgTo");

            if (rblSplit.SelectedValue == "UEQ")
            {
                txtTrgFrm.Text = "";
                txtTrgTo.Text = "";

                txtTrgFrm.Visible = true;
                txtTrgTo.Visible = true;

                lblTrgFrm.Visible = false;
                lblTrgTo.Visible = false;
            }
            else if (rblSplit.SelectedValue == "EQ")
            {
                txtTrgFrm.Visible = false;
                txtTrgTo.Visible = false;

                lblTrgFrm.Visible = true;
                lblTrgTo.Visible = true;
            }
        }
    }

    #region SaveTarget
    protected void SaveTarget(string ID)
    {

        if (Request.QueryString["compcode"] != null)
        {
            cmpstd = Request.QueryString["compcode"].ToString().Trim();
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            cntst = Request.QueryString["cntstcd"].ToString().Trim();
        }
        if (Request.QueryString["code"] != null)
        {
            if (Request.QueryString["FlagEnquiry"] == null)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@CODE", Request.QueryString["code"].ToString().Trim());
                htParam.Add("KPI_TRGT_FROM",txtTrgFrm.Text.ToString().Trim());
                htParam.Add("KPI_TRGT_TO",txtTrgTo.Text.ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdRwdTrgDtls", htParam);
            }
        }
        else
        {
            #region SaveTarget
            try
            {
                #region SAVE KPI TARGETS
                Session[ID] = Session["D"];
                DataTable dtRwd = new DataTable();
                dtRwd = Session[ID] as DataTable;
                ds = new DataSet();
                ds.Clear();
                htParam.Clear();
                string rulesetkey = string.Empty;
                //htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                //htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                ///////htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
                //ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdTrgDtls", htParam);

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
                List<string> lstStdDefn = new List<string>();
                List<string> lstMinWeighted = new List<string>();
                List<string> lstMaxWeighted = new List<string>();
                List<string> lstWeighted = new List<string>();
                List<string> lstMemberCycle = new List<string>();
                List<string> lstAgentCode = new List<string>();
                List<string> lstAgentLocation = new List<string>();

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
                    HiddenField hdnStdDefn = new HiddenField();
                    HiddenField hdnMinWeighted = new HiddenField();
                    HiddenField hdnMaxWeighted = new HiddenField();
                    HiddenField hdnWeighted = new HiddenField();
                    HiddenField hdnMemberCycle = new HiddenField();
                    HiddenField hdnMemLoc = new HiddenField();


                    hdnRulStKy.Value = dtRwd.Rows[intRowCount]["RULE_SET_KEY"].ToString().Trim();
                    rulesetkey = dtRwd.Rows[intRowCount]["RULE_SET_KEY"].ToString().Trim();
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
                    hdnStdDefn.Value = dtRwd.Rows[intRowCount]["STDDEFN"].ToString().Trim();
                    lstStdDefn.Add(hdnStdDefn.Value.ToString().Trim());

                    hdnMinWeighted.Value = dtRwd.Rows[intRowCount]["MIN_WEIGHTED"].ToString().Trim();
                    lstMinWeighted.Add(hdnMinWeighted.Value.ToString().Trim());

                    hdnMaxWeighted.Value = dtRwd.Rows[intRowCount]["MAX_WEIGHTED"].ToString().Trim();
                    lstMaxWeighted.Add(hdnMaxWeighted.Value.ToString().Trim());

                    hdnWeighted.Value = dtRwd.Rows[intRowCount]["WEIGHTED"].ToString().Trim();
                    lstWeighted.Add(hdnWeighted.Value.ToString().Trim());

                    hdnMemberCycle.Value = dtRwd.Rows[intRowCount]["MEMBER_CYCLE"].ToString().Trim();
                    lstMemberCycle.Add(hdnMemberCycle.Value.ToString().Trim());


                    hdnAgentCode.Value = dtRwd.Rows[intRowCount]["MEM_CODE"].ToString().Trim();
                    lstAgentCode.Add(hdnAgentCode.Value.ToString().Trim());

                    hdnMemLoc.Value = dtRwd.Rows[intRowCount]["MEM_UNT_CODE"].ToString().Trim();
                    lstAgentLocation.Add(hdnMemLoc.Value.ToString().Trim());



                }

                for (int intDataCount = 0; intDataCount <= lstRulSetKey.Count - 1; intDataCount++)
                {
                    htParam.Clear();
                    ds.Clear();

                    htParam.Add("@CATG_CODE", lstCatgCode[intDataCount]);
                    htParam.Add("@CYCLE", lstCycleCode[intDataCount]);
                    htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                    htParam.Add("@CNTSTNT_CODE", cntst.ToString().Trim());
                    htParam.Add("@CMPNSTN_CODE", cmpstd.ToString().Trim());
                    htParam.Add("@CATG_DESC01", lstCatgDesc[intDataCount]);
                    htParam.Add("@CATG_DESC02", lstCatgDesc[intDataCount]);
                    htParam.Add("@CATG_DESC03", lstCatgDesc[intDataCount]);
                    htParam.Add("@EFF_FROM", lstEffDtFrm[intDataCount]);
                    htParam.Add("@EFF_TO", lstEffDtTo[intDataCount]);
                    htParam.Add("@FIN_YEAR", lstBusiCo[intDataCount]);
                    htParam.Add("@KPI_TRGT_FROM", lstTrgFrm[intDataCount]);
                    htParam.Add("@KPI_TRGT_TO", lstTrgTo[intDataCount]);
                    htParam.Add("@KPI_CODE", lstKPICode[intDataCount]);
                    htParam.Add("@CATSET", lstSbCtgry[intDataCount]);
                    htParam.Add("@P_EXCL", lstPExcl[intDataCount]);
                    htParam.Add("@S_EXCL", lstSExcl[intDataCount]);
                    htParam.Add("@SORT", lstSort[intDataCount]);
                    htParam.Add("@CHKTRGFLAG", lstStdDefn[intDataCount]);
                    htParam.Add("@MIN_WEIGHTED", lstMinWeighted[intDataCount]);
                    htParam.Add("@MAX_WEIGHTED", lstMaxWeighted[intDataCount]);
                    htParam.Add("@WEIGHTED", lstWeighted[intDataCount]);

                    htParam.Add("@MEMBER_CYCLE", lstMemberCycle[intDataCount]);

                    htParam.Add("@MEM_CODE", lstAgentCode[intDataCount]);

                    htParam.Add("@MEM_UNT_CODE", lstAgentLocation[intDataCount]);

                    htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());


                    if (Request.QueryString["code"] != null)
                    {
                        htParam.Add("@FLAG", "E");
                        htParam.Add("@CODE", Request.QueryString["code"].ToString().Trim());
                    }
                    else
                    {
                        htParam.Add("@FLAG", "N");
                        htParam.Add("@CODE", lstCode[intDataCount]);
                    }
                    //if (chkStdTrg.Checked == true)
                    //{
                    //    htParam.Add("@CHKTRGFLAG", "1");
                    //}
                    //else
                    //{
                    //    htParam.Add("@CHKTRGFLAG", "0");
                    //}

                    if (chkConfTrg.Checked == true)
                    {
                        htParam.Add("@STATFLAG", "1");
                    }
                    else
                    {
                        htParam.Add("@STATFLAG", "0");
                    }
                    if (chkAllCyc.Checked == true)
                    {
                        htParam.Add("@CYCFLAG", "1");
                    }
                    else
                    {
                        htParam.Add("@CYCFLAG", "0");
                    }
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdTrgDtls", htParam);
                }

                if (chkConfTrg.Checked == true)
                {
                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
                    htParam.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim());
                    htParam.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
                    htParam.Add("@RULE_SET_KEY", rulesetkey.ToString().Trim());
                    htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                    htParam.Add("@FLAG", "6");
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
                }

                #endregion
            }
            catch (Exception ex)
            {
                // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                // string sRet = oInfo.Name;
                // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                // String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-SAIM", "QualTrgStp", "SaveTarget", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            #endregion
            if (Request.QueryString["rultyp"] != null)
            {
                if (Request.QueryString["rultyp"].ToString().Trim() == "R")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('" + Request.QueryString["rultyp"].ToString().Trim() + "','');", true);
                }
                else if (Request.QueryString["rultyp"].ToString().Trim() == "Q")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('" + Request.QueryString["rultyp"].ToString().Trim() + "','S');", true);
                }
            }
        }
    }
    #endregion

    protected void InitializeControl()
    {
        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"] == "Q")
            {
                lblhdr.Text = "Qualification Target Setup";
            }
            else if (Request.QueryString["rultyp"] == "R")
            {
                lblhdr.Text = "Rewards Target Setup";
                ddlMemLoc.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
        }
    }

    #region GetCycles
    protected void GetCycles()
    {
        DataTable dt = new DataTable();
        ddlCyc.Items.Clear();
        dt.Clear();
        dt = Search("C", hdnbusicode.Value.ToString().Trim(), hdnAccCyc.Value.ToString().Trim());
        if (dt.Rows.Count > 0)
        {
            ddlCyc.DataSource = dt;
            ddlCyc.DataValueField = "BUSI_CODE";
            ddlCyc.DataTextField = "SHRT_BUSI_DESC";
            ddlCyc.DataBind();
            hdnYrType.Value = dt.Rows[0]["YEAR_TYPE"].ToString().Trim();
        }
        ddlCyc.Items.Insert(0, new ListItem("--SELECT--", ""));
       
    }
    #endregion

    protected void ddlCyc_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDates("P", hdnYrType.Value.ToString().Trim(), ddlCyc.SelectedValue.ToString().Trim());
    }

    #region GetDates
    protected void GetDates(string flag, string yrtyp, string busicode)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        htParam.Add("@BUSI_CODE", busicode.ToString().Trim());
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtEffFrom.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtEffTo.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
        }
    }
    #endregion

    protected void lnkNewCatg_Click(object sender, EventArgs e)
    {
        txtSubCtgry.Text = (Convert.ToInt32(txtSubCtgry.Text.ToString().Trim()) + 1).ToString().Trim();
    }

    #region FillCatg
    protected void FillCatg()
    {
        DataTable dt = new DataTable();
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["code"] != null)
        {
            htParam.Add("@CODE", Request.QueryString["code"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //ddlRulSetKy.SelectedItem.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                //txtRskDesc.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY_DESC"].ToString().Trim();
                ddlRulSetKy.SelectedValue = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                txtRskDesc.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();

                txtCatgCode.Text = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
                ddlCatgDesc.SelectedValue = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
                txtCatgDesc.Text = ds.Tables[0].Rows[0]["CATG_DESC"].ToString().Trim();
                FillddlKPI(ddlKPICode, "Prc_GetRwrdRuleVal", "5", "KPI_DESC", "KPI_CODE", ddlRulSetKy.SelectedValue.ToString().Trim());
                ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtKpiName.Text = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
               // ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtTrgFrm.Text = ds.Tables[0].Rows[0]["TRG_FRM"].ToString().Trim();
                txtTrgTo.Text = ds.Tables[0].Rows[0]["TRG_TO"].ToString().Trim();
                txtSubCtgry.Text = ds.Tables[0].Rows[0]["CATSET"].ToString().Trim();
                rblPExcl.SelectedValue = ds.Tables[0].Rows[0]["P_EXCL"].ToString().Trim();
                rblSExcl.SelectedValue = ds.Tables[0].Rows[0]["S_EXCL"].ToString().Trim();
                txtSort.Text = ds.Tables[0].Rows[0]["SORT"].ToString().Trim();
                ddlCyc.SelectedValue = ds.Tables[0].Rows[0]["CYCLE_CODE"].ToString().Trim();
                txtEffFrom.Text = ds.Tables[0].Rows[0]["EFFDT_FROM"].ToString().Trim();
                txtEffTo.Text = ds.Tables[0].Rows[0]["EFFDT_TO"].ToString().Trim();
                string chkdefn = ds.Tables[0].Rows[0]["STDDEFN"].ToString().Trim();
                if (chkdefn == "1")
                {
                    chkStdTrg.Checked = true;
                }
                else if (chkdefn == "0")
                {
                    chkStdTrg.Checked = false;
                }
                chkStdTrg.Enabled = false;
                chkAllCyc.Enabled = false;

                txtCatgCode.Enabled = false;
                ddlRulSetKy.Enabled = false;
                txtSubCtgry.Enabled = false;
                txtSort.Enabled = false;
               // ddlCatgDesc.Enabled = false;
                txtCatgDesc.Enabled = false;
                lnkNewCatg.Enabled = false;
                txtKpiName.Enabled = false;
                ddlKPICode.Enabled = false;

                dgQualTrg.DataSource = ds.Tables[0];
                dgQualTrg.DataBind();
                ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[0]);
                ShowNoResultFound(ds.Tables[0], dgQualTrg);
                Session["T"] = null;
                Session["D"] = null;
            }
        }
    }
    #endregion

    protected void ddlRulSetKy_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Hashtable htP = new Hashtable();
        DataSet dsP = new DataSet();
        ddlCatgDesc.SelectedIndex = 0;
        GetCatgMstDtls(ddlRulSetKy.SelectedValue.ToString().Trim());
        if (ddlCatgDesc.Items.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please add category from Add Master');", true);
            ddlRulSetKy.SelectedValue = "";
            return;
        }
        FillddlKPI(ddlKPICode, "Prc_GetRwrdRuleVal", "5", "KPI_DESC", "KPI_CODE", ddlRulSetKy.SelectedValue.ToString().Trim());
        if (ddlRulSetKy.SelectedValue != "")
        {
            htP.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            htP.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim().ToString().Trim());
            htP.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString().Trim());
            htP.Add("@FLAG", "4");
            dsP = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htP);
			GetCycles();
            InsTmp();
            GetTmpTrg("2");
            txtRskDesc.Text = ddlRulSetKy.SelectedValue.ToString().Trim();
           // ddlRulSetKy.Enabled = false;
            ddlCyc_SelectedIndexChanged(sender, e);
            ddlCatgDesc_SelectedIndexChanged(sender, e);
            ddlKPICode_SelectedIndexChanged(sender, e);
            imgRul.Visible = true;
            imgCyc.Visible = true;
            imgCatg.Visible = true;
            imgKPI.Visible = true;
            
            imgRulP.Visible = false;
            imgCycP.Visible = false;
            imgCatgP.Visible = false;
            imgKPIP.Visible = false;
            /////btnAdd.Enabled = false;
        }
        CheckIsWeighted();
        
        if (ddlCatgDesc.Items.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please add category from Add Master');", true);
            ddlRulSetKy.SelectedValue = "";
            txtRskDesc.Text = "";
            ddlCyc.SelectedIndex = 0;
            ddlKPICode.SelectedIndex = 0;
            ddlKPICode.Enabled = false;
            ddlCyc.Enabled = false;
            return;
        }
        ddlCyc.Enabled = true;
            
        ddlKPICode.Enabled = true;

        if (ddlRulSetKy.SelectedIndex==0)//.SelectedItem.Text == "--SELECT--"
        {
            if (ddlRulSetKy.Enabled == false)
            {
                btnAdd.Enabled = false;
            }
        
        }


        GetRulSetClass(ddlRulSetKy.SelectedValue.ToString().Trim());



    }


    protected void GetRulSetClass(string rulsetky)
    {
        try
        {
            DataSet ds1 = new DataSet();
            htParam = new Hashtable();
            ds1.Clear();
            htParam.Clear();
            if (Request.QueryString["compcode"] != null)///@CatgCode
            {
                htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
            }
            if (Request.QueryString["rultyp"] != null)
            {
                htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
            }

            htParam.Add("@RULE_SET_KEY", rulsetky.ToString().Trim());
            ds1 = objDal.GetDataSetForPrc_SAIM("Prc_GetRulSetClass", htParam);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                hdnRulClass.Value = ds1.Tables[0].Rows[0]["TRG_CATG_RUL_CLASS"].ToString().Trim();
            }

            if (hdnRulClass.Value == "NS")
            {
                ShowLocDdl();
                LblAgent.Visible = true;
                btnAgtName.Visible = true;
                LblAgentM.Visible = true;
            }
            else
            {
                LblAgent.Visible = false;
                btnAgtName.Visible = false;
                LblAgentM.Visible = false;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "GetRulSetClass", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnAgtName_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["compcode"] != null)
        {
            if (Request.QueryString["compcode"].ToString().Trim() != null)
            {
                cmpcode = Request.QueryString["compcode"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddVarMaster('" + cmpcode.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRule','" + rultyp.ToString().Trim() + "','" + MEMBERCODE.ToString().Trim() + "','" + BRKPRULE_CODE.ToString().Trim() + "','" + ddlReasonforEdit.SelectedValue.ToString().Trim() + "');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "OpenPopupWindow('" + cmpcode.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "');", true);

    }

    protected void BtnAgentToolTip_Click(object sender, EventArgs e)
    {
        LblAgentToolTip.ToolTip = hdnAgentDesc.Value.Replace(',', '\n');
        LblAgentToolTip.Text = HAgent.Value;




        DataSet DsLocation = new DataSet();
        DsLocation.Clear();

        Hashtable HtLocation = new Hashtable();
        HtLocation.Clear();


        // HtLocation.Add("@CompCode", Request.QueryString["cmpcode"].ToString());
        HtLocation.Add("@MemCode", hdnAgentCode.Value.ToString().Trim());

        HtLocation.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        DsLocation = objDal.GetDataSetForPrc_SAIM("Prc_GetMemLocCode", HtLocation);
        if (DsLocation.Tables.Count > 0 && DsLocation.Tables[0].Rows.Count > 0)
        {
            ddlMemLoc.DataSource = DsLocation;
            ddlMemLoc.DataTextField = "UnitLegalName";
            ddlMemLoc.DataValueField = "UNitcode";
            ddlMemLoc.DataBind();
        }
        ddlMemLoc.Items.Insert(0, new ListItem("-- SELECT --", ""));

    }

    protected void ddlCatgDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCatgDesc.SelectedValue == "")
        {
            txtCatgCode.Text = "";
        }
        else
        {
            txtCatgCode.Text = ddlCatgDesc.SelectedValue;
           // ddlMemberCycle.SelectedItem.Text = ddlCatgDesc.SelectedValue;
           string catg = txtCatgCode.Text.ToString();
            FillMemberCycleDdl(catg);
        }
    }

    protected void ShowLocDdl()
    {
       

        DataSet dsLoc = new DataSet();
        dsLoc.Clear();

        Hashtable HtLoc = new Hashtable();
        HtLoc.Clear();


        HtLoc.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        HtLoc.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());


        dsLoc = objDal.GetDataSetForPrc_SAIM("Prc_DisplayLoc", HtLoc);
        if (dsLoc.Tables.Count > 0 && dsLoc.Tables[0].Rows.Count > 0)
        {
            if (dsLoc.Tables[0].Rows[0]["PRTCPTN_BSD_ON"].ToString() == "MC-LC")
            {
                Label11.Visible = true;
                ddlMemLoc.Visible = true;
            }

        }


    }

    #region GetTrgCnt
    protected void GetTrgCnt(string rsk, string flag)
    {
        int cnt = 0, cnt1 = 0;
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htParam.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        }
        if (Request.QueryString["rultyp"] != null)
        {
            htParam.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
        }
        htParam.Add("@RULE_SET_KEY", rsk.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        ////htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetTargetRecCnt", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            cnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TRGRECCNT"].ToString().Trim());
            cnt1 = Convert.ToInt32(ds.Tables[1].Rows[0]["RECCNT"].ToString().Trim());
            hdnTrgCnt.Value = cnt.ToString();
            hdnTrgCnt1.Value = cnt1.ToString();
        }
    }
    #endregion

    #region InsTmpTarget
    protected void InsTmpTarget(string compcode, string cntstcd, string rultyp, string rulsetkey, string catgcode,
        string cycle, string kpicode, string catset, string trgfrm, string trgto)
    {
        DataTable tmpTrg = new DataTable();
        tmpTrg.Columns.Add("CMPNSTN_CODE");
        tmpTrg.Columns.Add("CNTSTN_CODE");
        tmpTrg.Columns.Add("RULE_TYPE");
        tmpTrg.Columns.Add("RULE_SET_KEY");
        tmpTrg.Columns.Add("CATEGORY");
        tmpTrg.Columns.Add("CYCLE_CODE");
        tmpTrg.Columns.Add("KPI_CODE");
        tmpTrg.Columns.Add("TRGFRM");
        tmpTrg.Columns.Add("TRGTO");
        tmpTrg.Columns.Add("CATSET");
        tmpTrg.Columns.Add("SORT");
        DataRow dr = tmpTrg.NewRow();
        dr["CMPNSTN_CODE"] = compcode.ToString().Trim();
        dr["CNTSTN_CODE"] = cntstcd.ToString().Trim();
        dr["RULE_TYPE"] = rultyp.ToString().Trim();
        dr["RULE_SET_KEY"] = rulsetkey.ToString().Trim();
        dr["CATEGORY"] = catgcode.ToString().Trim();
        dr["CYCLE_CODE"] = cycle.ToString().Trim();
        dr["KPI_CODE"] = kpicode.ToString().Trim();
        dr["CATSET"] = catset.ToString().Trim();
        dr["TRGFRM"] = trgfrm.ToString().Trim();
        dr["TRGTO"] = trgto.ToString().Trim();
        if (txtSort.Text != "")
        {
            dr["SORT"] = txtSort.Text.ToString().Trim();
        }
        else
        {
            dr["SORT"] = (Convert.ToInt32(hdnSortNo.Value) + 1).ToString().Trim();
        }
        tmpTrg.Rows.Add(dr);
        List<string> lstCompCode = new List<string>();
        List<string> lstCntstCode = new List<string>();
        List<string> lstRuleType = new List<string>();
        List<string> lstRuleSetKey = new List<string>();
        List<string> lstCatgCode = new List<string>();
        List<string> lstCycCode = new List<string>();
        List<string> lstKPICode = new List<string>();
        List<string> lstCatSet = new List<string>();
        List<string> lstSort = new List<string>();

        for (int intRwCnt = 0; intRwCnt <= tmpTrg.Rows.Count - 1; intRwCnt++)
        {
            HiddenField hdnCompCode = new HiddenField();
            HiddenField hdnCntstCode = new HiddenField();
            HiddenField hdnRuleType = new HiddenField();
            HiddenField hdnRuleSetKey = new HiddenField();
            HiddenField hdnCatgCode = new HiddenField();
            HiddenField hdnCycCode = new HiddenField();
            HiddenField hdnKPICode = new HiddenField();
            HiddenField hdnCatSet = new HiddenField();
            HiddenField hdnSort = new HiddenField();

            hdnCompCode.Value = tmpTrg.Rows[intRwCnt]["CMPNSTN_CODE"].ToString().Trim();
            lstCompCode.Add(hdnCompCode.Value.ToString().Trim());
            hdnCntstCode.Value = tmpTrg.Rows[intRwCnt]["CNTSTN_CODE"].ToString().Trim();
            lstCntstCode.Add(hdnCntstCode.Value.ToString().Trim());
            hdnRuleType.Value = tmpTrg.Rows[intRwCnt]["RULE_TYPE"].ToString().Trim();
            lstRuleType.Add(hdnRuleType.Value.ToString().Trim());
            hdnRuleSetKey.Value = tmpTrg.Rows[intRwCnt]["RULE_SET_KEY"].ToString().Trim();
            lstRuleSetKey.Add(hdnRuleSetKey.Value.ToString().Trim());
            hdnCatgCode.Value = tmpTrg.Rows[intRwCnt]["CATEGORY"].ToString().Trim();
            lstCatgCode.Add(hdnCatgCode.Value.ToString().Trim());
            hdnCycCode.Value = tmpTrg.Rows[intRwCnt]["CYCLE_CODE"].ToString().Trim();
            lstCycCode.Add(hdnCycCode.Value.ToString().Trim());
            hdnKPICode.Value = tmpTrg.Rows[intRwCnt]["KPI_CODE"].ToString().Trim();
            lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
            hdnCatSet.Value = tmpTrg.Rows[intRwCnt]["CATSET"].ToString().Trim();
            lstCatSet.Add(hdnCatSet.Value.ToString().Trim());
            hdnSort.Value = tmpTrg.Rows[intRwCnt]["SORT"].ToString().Trim();
            lstSort.Add(hdnSort.Value.ToString().Trim());
        }

        for (int intDtCnt = 0; intDtCnt <= tmpTrg.Rows.Count - 1; intDtCnt++)
        {
            Hashtable htTrg = new Hashtable();
            DataSet dsTrg = new DataSet();
            htTrg.Add("@CMPNSTN_CODE", lstCompCode[intDtCnt].ToString().Trim());
            htTrg.Add("@CNTSTN_CODE", lstCntstCode[intDtCnt].ToString().Trim());
            htTrg.Add("@RULE_TYPE", lstRuleType[intDtCnt].ToString().Trim());
            htTrg.Add("@RULE_SET_KEY", lstRuleSetKey[intDtCnt].ToString().Trim());
            htTrg.Add("@CATEGORY", lstCatgCode[intDtCnt].ToString().Trim());
            htTrg.Add("@CYCLE_CODE", lstCycCode[intDtCnt].ToString().Trim());
            htTrg.Add("@KPI_CODE", lstKPICode[intDtCnt].ToString().Trim());
            htTrg.Add("@CATSET", lstCatSet[intDtCnt].ToString().Trim());
            htTrg.Add("@SORT", lstSort[intDtCnt].ToString().Trim());
            htTrg.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            htTrg.Add("@FLAG", "1");
            dsTrg = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htTrg);
        }
    }
    #endregion

    #region GetTmpTrg
    protected void GetTmpTrg(string flag)
    {
        ds = new DataSet();
        htParam = new Hashtable();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        htParam.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        htParam.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
        htParam.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRulSetKy.SelectedValue = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            GetCatgMstDtls(ddlRulSetKy.SelectedValue.ToString().Trim());
            txtRskDesc.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlCyc.SelectedValue = ds.Tables[0].Rows[0]["CYCLE_CODE"].ToString().Trim();
            txtCatgCode.Text = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
            ddlCatgDesc.SelectedValue = ds.Tables[0].Rows[0]["CATEGORY"].ToString().Trim();
           // ddlMemberCycle.SelectedValue = ds.Tables[0].Rows[0]["MEMBER_CYCLE"].ToString().Trim();

            FillddlKPI(ddlKPICode, "Prc_GetRwrdRuleVal", "5", "KPI_DESC", "KPI_CODE", ddlRulSetKy.SelectedValue.ToString().Trim());
            ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
            txtSubCtgry.Text = ds.Tables[0].Rows[0]["CATSET"].ToString().Trim();
            txtSort.Text = ds.Tables[0].Rows[0]["SORT"].ToString().Trim();
        }
    }
    #endregion

    protected string ChkRSKey(string compcode, string cntstcode, string rskey)
    {
        htParam.Clear();
        ds.Clear();
        string isExists = string.Empty;
        htParam.Add("@RULE_SET_KEY", rskey.Trim());
        htParam.Add("@CMPNSTN_CODE", compcode.Trim());
        htParam.Add("@CNTSTN_CODE", cntstcode.Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_ChkKPIExists", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            isExists = ds.Tables[0].Rows[0]["ISEXISTS"].ToString().Trim();
        }
        return isExists.ToString().Trim();
    }
    protected void btnCnclTrg_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel('" + Request.QueryString["rultyp"].ToString().Trim() + "','');", true);
    }

    protected void InsTmp()
    {
        Hashtable htTrg = new Hashtable();
        DataSet dsTrg = new DataSet();
        try
        {
            htTrg.Clear();
            dsTrg.Clear();
            htTrg.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            htTrg.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim().ToString().Trim());
            htTrg.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
            htTrg.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString().Trim());
            htTrg.Add("@CATSET", txtSubCtgry.Text.ToString().Trim());
            htTrg.Add("@MEMBER_CYCLE",ddlMemberCycle.SelectedValue.ToString().Trim());
            if (txtTrgFrm.Text != "")
            {
                htTrg.Add("@TRGFRM", txtTrgFrm.Text.ToString().Trim());
            }
            else
            {
                htTrg.Add("@TRGFRM", "0.0");
            }
            if (txtTrgTo.Text != "")
            {
                htTrg.Add("@TRGTO", txtTrgTo.Text.ToString().Trim());
            }
            else
            {
                htTrg.Add("@TRGTO", "0.0");
            }
            htTrg.Add("@STS_FLAG", "P");
            htTrg.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            htTrg.Add("@FLAG", "1");
            dsTrg = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htTrg);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "QualTrgStp", "InsTmp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void chkAllCyc_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllCyc.Checked == true)
        {
            chkConfTrg.Enabled = true;
        }
        else if (chkAllCyc.Checked == false)
        {
            chkConfTrg.Enabled = false;
        }
    }

    protected DataTable FillGrdTmp(string flag)
    { 
        ds = new DataSet();
        htParam = new Hashtable();
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        htParam.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        htParam.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
        htParam.Add("@RULE_SET_KEY", ddlRulSetKy.SelectedValue.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
        Session["tmpTb"] = ds.Tables[0];
        return ds.Tables[0];
    }

    protected void GetTrgValue(string sessionID, int cell)
    {
        DataTable dtF = new DataTable();
        dtF = Session[sessionID] as DataTable;
        string trg = string.Empty;
        string trg1 = string.Empty;
        if (ddlKPICode.SelectedValue != "")
        {
            if (ddlRulSetKy.SelectedValue != "")
            {
                trg = "KPI_CODE = " + ddlKPICode.SelectedValue + " and RULE_SET_KEY=" + ddlRulSetKy.SelectedValue;
            }
        }
        DataRow[] dr2;
        dr2 = dtF.Select(trg, "SORT");
        for (int i = 0; i < dr2.Length; i++)
        {
            trg1 = dr2[i][cell].ToString().Trim();
            if (trg1.Contains("."))
            {
                txtTrgFrm.Text = (Convert.ToDecimal(trg1) + 1).ToString().Trim();
            }
            else
            {
                txtTrgFrm.Text = (Convert.ToInt32(trg1) + 1).ToString().Trim();
            }
        }
    }

    protected void btnAddMaster_Click(object sender, EventArgs e)
    {
        string cmpnstcd = string.Empty, cntstcd = string.Empty, rultyp = string.Empty;
        if (Request.QueryString["compcode"] != null)
        {
            if (Request.QueryString["compcode"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["compcode"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        if (Request.QueryString["rultyp"] != null)
        {
            rultyp = Request.QueryString["rultyp"].ToString().Trim();
        }
        mdlVw.Show();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdTrgt','" + rultyp.ToString().Trim() + "');", true);
    }

    protected void btnKPI_Click(object sender, EventArgs e)
    {
        GetCatgMstDtls(ddlRulSetKy.SelectedValue.ToString().Trim());
    }
    //protected void txtTrgTo_TextChanged(object sender, EventArgs e)
    //{
    //    //if (string.IsNullOrEmpty(sender.ToString()))
    //    //{
    //    //    btnAdd.Visible = false;
    //    //}
    //    //else
    //    //{
    //    //    btnAdd.Visible = true;
    //    //}
    //}

    protected void ChkTargetVal()
    {
        int cntTrg = 0;
        cntTrg = Convert.ToInt32(hdnTrgCnt.Value.Trim());
        if (ddlKPICode.Items.Count > 0)
        {
            cntTrg = (cntTrg / ddlKPICode.Items.Count - 1);
            if ((ddlCatgDesc.Items.Count - 1) > 1)
            {
                if (incrcnt >= (ddlKPICode.Items.Count - 1))
                {
                    if (incrcnt != (ddlKPICode.Items.Count - 1))
                    {
                        if ((incrcnt % ddlKPICode.Items.Count - 1) != 0)
                        {
                            hdntxtfrm.Value = txtTrgFrm.Text.ToString().Trim();
                        }
                        else
                        {
                            hdntxtfrm.Value = "";
                        }
                    }
                    else
                    {
                        hdntxtfrm.Value = "";
                    }
                }
                else
                {
                    hdntxtfrm.Value = "";
                }
            }
            else
            {
                hdntxtfrm.Value = "";
            }
        }
    }
}
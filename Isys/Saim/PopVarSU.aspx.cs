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

public partial class Application_ISys_Saim_PopVarSU : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp;
    string value = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        if (!IsPostBack)
        {
            GetPageDtls();
            FillDropDowns(ddlPrdClsCode, "37");
            FillDropDowns(ddlType, "1");

           // ddlPrdClsCode.SelectedValue = "10";
           // BinddDlProduct();

            //ddlPrdClsCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
           // FillDropDowns(ddlPrdClsCode, "36");
            BindFreqType();
            ShowRulStKy();
            GetCycle();
            if (gvAddMst.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"] == "CntstRwdRuleMdl")
                { 
                
                    DDlBusinessType.Enabled=false;
                    ddlPrdClsCode.Enabled=false;
                    ddlProduct.Enabled=false;
                    ddlfreguency.Enabled=false;
                    ddlType.Enabled=false;
                    ddlKPICode.Enabled=false;
                    chkCyc.Enabled = false;
                    btnSave.Visible = false;
        }
            
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
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
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
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void BinddDlProduct()
    {
        try
        {
        Hashtable ht = new Hashtable();
        ht.Clear();
        ddlProduct.Items.Clear();
        // ht.Add("@ProdClsCd", ddlPrdClsCode.SelectedValue.ToString().Trim());
        ht.Add("@Productvalue", ddlPrdClsCode.SelectedValue.ToString().Trim());
            ht.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
            // ds = obDAL.GetDataSetForPrc_SAIM("Prc_DDLProduct", ht);
            ds = objDal.GetDataSetForPrc_SAIM("prc_GetProductRwdVar", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlProduct.DataSource = ds;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductValue";
            ddlProduct.DataBind();
        }
        ddlProduct.Items.Insert(0, new ListItem("--Select--"));
        //ddlProduct.Items.Insert(1, new ListItem("--Arjun--"));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "BinddDlProduct", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void BindFreqType()
    {
        try
        {
        Hashtable ht = new Hashtable();
        if (Request.QueryString["mapcode"] != null)
        {
            if (Request.QueryString["mapcode"].ToString().Trim() != "")
            {
                ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            }
        }
        ht.Add("@Flag", "1");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DDLFrqBind", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlfreguency.DataSource = ds;
            ddlfreguency.DataTextField = "desc02";
            ddlfreguency.DataValueField = "code";
            ddlfreguency.DataBind();
        }
        ddlfreguency.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));

        ddlPayMode.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
        ddlPremiumType.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "BindFreqType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void ddlfreguency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlfreguency.SelectedValue == "F5")
        //{
        //    TextPayTermFrom.Enabled = false;
        //    TextPayTermTo.Enabled = false;
        //    lblPayTermFrom.Visible = false;
        //    lblPayTermTo.Visible = false;
        //}
        //else
        //{
        //    TextPayTermFrom.Enabled = true;
        //    TextPayTermTo.Enabled = true;
        //    lblPayTermFrom.Visible = true;
        //    lblPayTermTo.Visible = true;
        //}

    }


    protected void ddlPrdClsCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        BinddDlProduct();
        Hashtable ht = new Hashtable();
        ht.Add("@ProdCode", ddlPrdClsCode.SelectedValue.ToString());
        ds = objDal.GetDataSetForPrc_SAIM("GetProdDesc", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
                ddlProduct.DataSource = ds.Tables[1];
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "Product_Code";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));

                ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                //  TextProductName.Text = ds.Tables[0].Rows[0][0].ToString();
                TextPlanCode.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "ddlfreguency_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    public void GetPageDtls()
    {
        //lblCompCodeVal.Text = Request.QueryString["CmpCode"].ToString().Trim();
        //lblCntstCdVal.Text = Request.QueryString["CntstCode"].ToString().Trim();
        //htParam.Clear();
        //ds.Clear();
        //htParam.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        //htParam.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        //if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //{
        //    htParam.Add("@flag", "1");
        //    lnkrwddsc.Visible = false;
        //}
        //else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //{
        //    htParam.Add("@flag", "2");
        //    lblrlSetKy.Text = "Category Code";
        //    lblRuleSetKeyDesc.Text = "Category Description";
        //    txtRuleSetKeyDsc.Attributes.Add("placeholder", "Category Description");
        //    lnkrwddsc.Visible = false;
        //}
        //else
        //{
        //    htParam.Add("@flag", "3");
        //    lblrlSetKy.Text = "Reward Code";
        //    lblRuleSetKeyDesc.Text = "Reward Description";
        //    txtRuleSetKeyDsc.Attributes.Add("placeholder", "Reward Description");
        //    lnkrwddsc.Visible = true;
        //}
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodesForMaster", htParam);
        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    txtRuleSetKey.Text = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
        //}
        try
        {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htParam.Add("@RWRD_CODE", Request.QueryString["RWRD_CODE"].ToString().Trim());      
     
        htParam.Add("@CATG_CODE", Request.QueryString["CATG_CODE"].ToString().Trim());
        
        htParam.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString().Trim());
        if (Request.QueryString["MEMBERCODE"] !=null)
        {
            if(Request.QueryString["MEMBERCODE"].ToString()!="")
            {
                htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString().Trim());

            }
        }

        if (Request.QueryString["BRKPRULE_CODE"] != null)
        {
            if (Request.QueryString["BRKPRULE_CODE"].ToString() != "")
            {
                htParam.Add("@BRKPRULE_CODE", Request.QueryString["BRKPRULE_CODE"].ToString().Trim());

            }
        }

        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMst_Cntstnt_KPI_Rwrd_Var_Rul", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvAddMst.DataSource = ds;
            gvAddMst.DataBind();
            //    divAuditTrail.Visible = true;

            //    if (gvAddMst.PageCount > Convert.ToInt32(txtpage.Text))
            //    {
            //        btnnext.Enabled = true;
            //    }
            //    else
            //    {
            //        btnnext.Enabled = false;
            //    }

            //    if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
            //    {
            //        gvAddMst.Columns[2].Visible = true;
            //        gvAddMst.Columns[3].Visible = false;
            //        gvAddMst.Columns[4].Visible = true;
            //        gvAddMst.Columns[5].Visible = false;
            //        gvAddMst.Columns[6].Visible = false;
            //        gvAddMst.Columns[7].Visible = false;
            //        gvAddMst.Columns[8].Visible = false;
            //        gvAddMst.Columns[9].Visible = false;
            //        divrul.Style.Add("display", "none");
            //    }
            //    else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
            //    {
            //        //gvAddMst.Columns[2].Visible = false;
            //        //gvAddMst.Columns[3].Visible = true;
            //        //gvAddMst.Columns[4].Visible = false;
            //        //gvAddMst.Columns[5].Visible = true;
            //        //gvAddMst.Columns[6].Visible = true;
            //        //gvAddMst.Columns[7].Visible = false;
            //        //gvAddMst.Columns[8].Visible = false;
            //        //gvAddMst.Columns[9].Visible = false;
            //        //divrul.Style.Add("display", "block");
            //    }
            //    else
            //    {
            //        //gvAddMst.Columns[2].Visible = false;
            //        //gvAddMst.Columns[3].Visible = false;
            //        //gvAddMst.Columns[4].Visible = false;
            //        //gvAddMst.Columns[5].Visible = false;
            //        //gvAddMst.Columns[6].Visible = true;
            //        //gvAddMst.Columns[7].Visible = true;
            //        //gvAddMst.Columns[8].Visible = true;
            //        //gvAddMst.Columns[9].Visible = false;
            //        //divrul.Style.Add("display", "none");
            //    }

            //}
            //else
            //{
            //    divAuditTrail.Visible = false;
            //    txtpage.Text = "1";
            //    btnpre.Enabled = false;
            //    btnnext.Enabled = false;
            //}
        }

else
            {
                htParam.Clear();
                ds = objDal.GetDataSetForPrc_SAIM("GetEmptyDataVAR", htParam);
                ShowNoResultFound1(ds.Tables[0], gvAddMst);
               
}
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "GetPageDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        try
        {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;

  gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[0].Text = "No variable commission rate details";
       
        gv.Rows[0].Cells[1].Text = "";
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[2].Text = "";
        gv.Rows[0].Cells[3].Text = "";
        gv.Rows[0].Cells[4].Text = "";
        gv.Rows[0].Cells[5].Text = "";
        gv.Rows[0].Cells[6].Text = "";
        gv.Rows[0].Cells[8].Text = "";
        gv.Rows[0].Cells[9].Text = "";
        gv.Rows[0].Cells[10].Text = "";
        gv.Rows[0].Cells[11].Text = "";
        
        source.Rows.Clear();
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

        Hashtable htPara = new Hashtable();
        htPara.Clear();
        ds.Clear();

        htPara.Add("@RWD_RUL_CODE", hdnRWD_RUL_CODE_p.Value.ToString());
        htPara.Add("@BASED_ON_KPI", ddlKPICode.SelectedValue.ToString());
        htPara.Add("@VALUE", TxtCommissionRate.Text.ToString());
        htPara.Add("@TYPE", ddlType.SelectedValue.ToString());
        htPara.Add("@BusType", DDlBusinessType.SelectedValue.ToString());
        htPara.Add("@ProdCode", ddlProduct.SelectedValue.ToString());
        htPara.Add("@PlanCode",TextPlanCode.Text.ToString());
        htPara.Add("@ProdCategory", ddlPrdClsCode.SelectedValue.ToString());
        htPara.Add("@Frequency ", ddlfreguency.SelectedValue.ToString());
           
        htPara.Add("@PayMode", ddlPayMode.SelectedValue.ToString());
        htPara.Add("@PolicyTermFrom",TxtPolTermFrom.Text.ToString());
        htPara.Add("@PolicyTermTo",TxtPolTermTo.Text.ToString());
        htPara.Add("@PremiumFrom", TxtPremiumFrom.Text.ToString());
        htPara.Add("@PremiumTo", TxtPremiumTo.Text.ToString());
        htPara.Add("@PremiumType", ddlPremiumType.SelectedValue.ToString());
        htPara.Add("@RATE", txtRate.Text);
        htPara.Add("@CREATEDBY", Session["UserID"].ToString().Trim());

        if (Request.QueryString["flag"] != null)
        {//CntstRwdRuleMdl
            if (Request.QueryString["flag"] == "CntstRwdRuleMdl")
            {
                htPara.Add("@FLAG", "CntstRwdRuleMdl");
            }
        }


        ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdVariableCommisionRate", htPara);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Updated Successfully')", true);

        btnSave.Visible = true;
        btnUpdate.Visible = false;
        ddlfreguency.SelectedIndex = 0;
        DDlBusinessType.SelectedIndex = 0;
        ddlPrdClsCode.SelectedIndex = 0;
        ddlProduct.SelectedIndex = 0;
        TxtCommissionRate.Text = "";
        ddlType.SelectedIndex = 0;
        ddlKPICode.SelectedIndex = 0;

        GetPageDtls();
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "btnUpdate_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        btnUpdate.Visible = false;
        //if (txtRuleSetKeyDsc.Text == "")
        //{
        if (ddlPrdClsCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select product category (LOB)')", true);
            return;
        }

        if (DDlBusinessType.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Business Type')", true);
            return;
        }

        if (ddlfreguency.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Frequency')", true);
            return;
        }

        if (TxtCommissionRate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter commission rate')", true);
            return;
        }
        //    else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the Target description')", true);
        //        return;
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the Rule Set Key description')", true);
        //        return;
        //    }
        //}

        //#region savereward
        //ds.Clear();
        //htParam.Clear();
        //if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //{
        //    htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
        //    htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
        //    htParam.Add("@RULE_CODE", txtRuleSetKey.Text.Trim());
        //    htParam.Add("@RuleCodeDesc", txtRuleSetKeyDsc.Text.Trim());
        //    htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
        //    htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        //    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRuleSetCodeMst", htParam);
        //}
        //else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //{
        //    htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
        //    htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
        //    htParam.Add("@RulSetKy", txtRulSetDsc.Text.Trim());
        //    htParam.Add("@Catg_CODE", txtRuleSetKey.Text.Trim());
        //    htParam.Add("@CatgCodeDesc", txtRuleSetKeyDsc.Text.Trim());
        //    htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
        //    htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        //    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCatgryCodeMst", htParam);
        //}
        //else
        //{
        //    htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
        //    htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
        //    htParam.Add("@RWD_CODE", txtRuleSetKey.Text.Trim());
        //    htParam.Add("@RWDCodeDesc", txtRuleSetKeyDsc.Text.Trim());
        //    htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
        //    htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        //    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRWDCodeMst", htParam);
        //}

        //htParam.Clear();
        //ds.Clear();
        //htParam.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        //htParam.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        //htParam.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        //if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //{
        //    htParam.Add("@flag", "1");
        //}
        //else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //{
        //    htParam.Add("@flag", "2");
        //}
        //else
        //{
        //    htParam.Add("@flag", "3");
        //}
        //htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htParam);
        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    gvAddMst.DataSource = ds;
        //    gvAddMst.DataBind();
        //    divAuditTrail.Visible = true;
        //    if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //    {
        //        gvAddMst.Columns[2].Visible = true;
        //        gvAddMst.Columns[3].Visible = true;
        //        gvAddMst.Columns[4].Visible = false;
        //        gvAddMst.Columns[5].Visible = false;
        //        gvAddMst.Columns[6].Visible = false;
        //        gvAddMst.Columns[7].Visible = false;
        //    }
        //    else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //    {
        //        gvAddMst.Columns[2].Visible = false;
        //        gvAddMst.Columns[3].Visible = false;
        //        gvAddMst.Columns[4].Visible = true;
        //        gvAddMst.Columns[5].Visible = true;
        //        gvAddMst.Columns[6].Visible = false;
        //        gvAddMst.Columns[7].Visible = false;
        //    }
        //    else
        //    {
        //        gvAddMst.Columns[2].Visible = false;
        //        gvAddMst.Columns[3].Visible = false;
        //        gvAddMst.Columns[4].Visible = false;
        //        gvAddMst.Columns[5].Visible = false;
        //        gvAddMst.Columns[6].Visible = true;
        //        gvAddMst.Columns[7].Visible = true;
        //    }

        //}
        //else
        //{
        //    divAuditTrail.Visible = false;
        //}

        ////ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('" + value.ToString().Trim() + "');", true);
        //#endregion
        //txtRuleSetKeyDsc.Text = "";
       // GetPageDtls();


        Hashtable htParam = new Hashtable();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@RWD_RUL_CODE", Request.QueryString["RWRD_CODE"].ToString());
        htParam.Add("@RWRD_CODE", Request.QueryString["RWRD_CODE"].ToString());
        htParam.Add("@RWD_DESC", "");
        htParam.Add("@RWRD_DESC02", "");
        htParam.Add("@RWRD_DESC03", "");
        htParam.Add("@CATG_CODE", Request.QueryString["CATG_CODE"].ToString());
       
        htParam.Add("@CYCLE", Request.QueryString["CYCLE"].ToString());
        htParam.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString());
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString());
        htParam.Add("@RWRD_TYPE", Request.QueryString["RWRD_TYPE"].ToString());
        htParam.Add("@TYPE", ddlType.SelectedValue.ToString());
        htParam.Add("@BASED_ON_KPI", ddlKPICode.SelectedValue.ToString());
        htParam.Add("@VALUE", TxtCommissionRate.Text.ToString());
        htParam.Add("@BRKUPRULE", "");
        htParam.Add("@CATG_DESC01", "");
        htParam.Add("@CATG_DESC02", "");
        htParam.Add("@CATG_DESC03", "");       
        htParam.Add("@RATE", "0");

        htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
        htParam.Add("@FLAG", "N");
        htParam.Add("@BusType", DDlBusinessType.SelectedValue.ToString());
        htParam.Add("@ProdCode", ddlProduct.SelectedValue.ToString());
        htParam.Add("@PlanCode", TextPlanCode.Text.ToString());
        htParam.Add("@ProdCategory", ddlPrdClsCode.SelectedValue.ToString());
       // htParam.Add("@ProdName", TextProductName.Text.ToString());
        htParam.Add("@Frequency", ddlfreguency.SelectedValue.ToString());
        htParam.Add("@PolicyTermFrom", TxtPolTermFrom.Text.ToString());
        htParam.Add("@PolicyTermTo", TxtPolTermTo.Text.ToString());
        htParam.Add("@PremiumFrom", TxtPremiumFrom.Text.ToString());
        htParam.Add("@PremiumTo", TxtPremiumTo.Text.ToString());
        htParam.Add("@CommRate", TxtCommissionRate.Text.ToString());
        htParam.Add("@PayMode", ddlPayMode.SelectedValue.ToString());
        htParam.Add("@PremiumType", ddlPremiumType.SelectedValue.ToString());

        htParam.Add("@DEPENDENT_ON_KPI_RWD", Request.QueryString["REWARDDEPENDFLAG"].ToString());
        htParam.Add("@DEPENDENT_RWD_KPI", Request.QueryString["RewardDependKPI"].ToString());
        htParam.Add("@DEPENDENT_RWD_RULESET_KEY", Request.QueryString["RewardDependRuleSet"].ToString());
        htParam.Add("@DEPENDENT_RWD_CMPNSTN_CODE", Request.QueryString["RDCmpCode"].ToString());
        htParam.Add("@DEPENDENT_RWD_CNTSTNT_CODE", Request.QueryString["RDCnstCode"].ToString());

        htParam.Add("@REASONFOREDIT", Request.QueryString["REASONFOREDIT"].ToString());


              


        if (chkCyc.Checked == true)
        {
            htParam.Add("@CHKCYC", "1");
        }


        if (Request.QueryString["MEMBERCODE"] != null)
        {
            if (Request.QueryString["MEMBERCODE"].ToString() != "")
            {
                htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString().Trim());

            }
        }


        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsMst_Cntstnt_KPI_Rwrd_Var_Rul", htParam);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved Successfully')", true);

        ddlfreguency.SelectedIndex = 0;
        DDlBusinessType.SelectedIndex = 0;
        ddlPrdClsCode.SelectedIndex = 0;
        ddlProduct.SelectedIndex = 0;
        TxtCommissionRate.Text = "";
        ddlType.SelectedIndex = 0;
        ddlKPICode.SelectedIndex = 0;

        GetPageDtls();

        //DataTable dt = new DataTable();
        //dt.Clear();
        //dt = Search("C", hdnBusiCode.Value.ToString().Trim(), hdnCycTyp.Value.ToString().Trim());

    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlVal(ddlKPICode, Request.QueryString["RULE_SET_KEY"].ToString().Trim(), Request.QueryString["CATG_CODE"].ToString().Trim(), "3", "KPI_DESC", "KPI_CODE");
        ChkType();
    }

    protected void lnkSetFrml_Click(object sender, EventArgs e)
    {
        //mdlView.Show();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpFrml();", true);
    }

    protected void ChkType()
    {
        try
        {
        lblKPICode_.Text = "";
        if (ddlType.SelectedValue == "1001")
        {
            ddlKPICode.Enabled = false;
            txtValue.Visible = true;
            lblRate.Visible = false;
            txtRate.Visible = false;
            lnkSetFrml.Visible = false;
        }
        if (ddlType.SelectedValue == "1002")
        {
            ddlKPICode.Enabled = false;
            txtValue.Visible = true;
            lblRate.Visible = true;
            txtRate.Visible = true;
            lnkSetFrml.Visible = false;
        }

        if (ddlType.SelectedValue == "1003")
        {
            ddlKPICode.Enabled = true;
            lblKPICode_.Text = "*";
            txtValue.Visible = true;
            lblRate.Visible = false;
            txtRate.Visible = false;
            lnkSetFrml.Visible = false;
        }

        if (ddlType.SelectedValue == "1004")
        {
            ddlKPICode.Enabled = true;
            lblKPICode_.Text = "*";
            lblRate.Visible = true;
            txtRate.Visible = true;
            txtValue.Visible = false;
            lnkSetFrml.Visible = true;
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "ChkType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillddlVal(DropDownList ddl, string rulsetky, string catgcd, string flag, string text, string value)
    {
        try
        {
        DataSet ds1 = new DataSet();
        htParam = new Hashtable();
        ds1.Clear();
        htParam.Clear();
        ddl.Items.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        if (Request.QueryString["CmpCode"] != null)///@CatgCode
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        }
        if (Request.QueryString["rultyp"] != null)
        {
            htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
        }

        htParam.Add("@RulSetKey", rulsetky.ToString().Trim());
        htParam.Add("@CatgCode", catgcd.ToString().Trim());
        ds1 = objDal.GetDataSetForPrc_SAIM("Prc_GetRwrdRuleVal", htParam);
        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds1;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "FillddlVal", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        divqual.Attributes.Add("display","block");
        try
        {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lnkCompCode = (Label)row.FindControl("lnkCompCode");
        Label lblCntstCode = (Label)row.FindControl("lblCntstCode");
        Label lblRuleSetCode = (Label)row.FindControl("lblRuleSetCode");
        Label lblRuleSetDesc = (Label)row.FindControl("lblRuleSetDesc");
        Label lblCategoryCode = (Label)row.FindControl("lblCategoryCode");
        Label lblCategoryDesc = (Label)row.FindControl("lblCategoryDesc");
        Label lblRWRDCode = (Label)row.FindControl("lblRWRDCode");
        Label lblRWRDDesc = (Label)row.FindControl("lblRWRDDesc");

        HiddenField hndRWD_RUL_CODE = (HiddenField)row.FindControl("hdnRWD_RUL_CODE");
        HiddenField hndBusType1 = (HiddenField)row.FindControl("lblBusType1");
        HiddenField hndProdCode11 = (HiddenField)row.FindControl("lblProdCode11");
        HiddenField hndPlanCode11 = (HiddenField)row.FindControl("lblPlanCode11");
        HiddenField hndProdCategory11 = (HiddenField)row.FindControl("lblProdCategory11");
        HiddenField hndFrequency11 = (HiddenField)row.FindControl("lblFrequency11");
        HiddenField hdnTYPE = (HiddenField)row.FindControl("hdnTYPE");
        HiddenField hdnKPICode = (HiddenField)row.FindControl("hdnKPICode");
        HiddenField hdnCommRate11 = (HiddenField)row.FindControl("lblCommRate11");
        Label lblCommRate = (Label)row.FindControl("lblCommRate");

        ddlKPICode.SelectedValue = hdnKPICode.Value;
     //   ddlProduct.SelectedValue = hndProdCode11.Value;

        hdnBusType.Value = hndBusType1.Value;
        hdnKPICode.Value = hdnKPICode.Value;
        hdnType.Value = hdnTYPE.Value;
      
      
        hdnRWD_RUL_CODE_p.Value = hndRWD_RUL_CODE.Value;
        TxtCommissionRate.Text = hdnCommRate11.Value;

        btnUpdate.Visible = true;
        btnSave.Visible = false;

       // HiddenField hndPolicyTermFrom11 = (HiddenField)row.FindControl("lblPolicyTermFrom11");
       // HiddenField hndProdCategory11 = (HiddenField)row.FindControl("lblProdCategory11");
       // lblCompCodeVal.Text = lnkCompCode.Text;
        //lblCntstCdVal.Text = lblCntstCode.Text;

        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            txtRuleSetKey.Text = lblRuleSetCode.Text;
            txtRuleSetKeyDsc.Text = lblRuleSetDesc.Text;
        }
        else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        {
            txtRuleSetKey.Text = lblCategoryCode.Text;
            txtRuleSetKeyDsc.Text = lblCategoryDesc.Text;
        }
        else
        {
            DDlBusinessType.SelectedValue = hndBusType1.Value;
            ddlfreguency.SelectedValue = hndFrequency11.Value;
            ddlPrdClsCode.SelectedValue = hndProdCategory11.Value;
            ddlPrdClsCode_SelectedIndexChanged(null,null);
            ddlType.SelectedValue = hdnTYPE.Value;
            ddlType_SelectedIndexChanged(null,null);
            ddlProduct.SelectedValue = hndProdCode11.Value;
            ddlKPICode.SelectedValue = hdnKPICode.Value;
            TxtCommissionRate.Text = lblCommRate.Text;
           



          //  txtRuleSetKey.Text = lblRWRDCode.Text;
           // txtRuleSetKeyDsc.Text = lblRWRDDesc.Text;
        }
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"] == "CntstRwdRuleMdl")
            {

                DDlBusinessType.Enabled = false;
                ddlPrdClsCode.Enabled = false;
                ddlProduct.Enabled = false;
                ddlfreguency.Enabled = false;
                ddlType.Enabled = false;
                ddlKPICode.Enabled = false;
                chkCyc.Enabled = false;
                btnSave.Visible = false;
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
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "lnkEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

   // added by ajay sawant 6/5/2018
    // protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int deleteR = Convert.ToInt32(gvAddMst.DataKeys[e.RowIndex].Values[0]);
    //   //have a sql statement here that add's the parameter ID for the row you want to delete, something like
    //    SqlCommand com = new SqlCommand("Delete FROM yourdatabase Where yourID = @yourID");
    //        com.Parameters.AddWithValue("@RWDID",RWDID);
    //}

     //public void gvAddMst_RowCommand(Object sender, GridViewCommandEventArgs e)
     //{
     //    if (e.CommandName == "Delete")
     //    {
     //        string userId = e.CommandArgument.ToString();
     //        //do something with the id
     //    }
     //}





    protected void GetCycle()
    {
        try
        {
        ds = new DataSet();
        htParam = new Hashtable();
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            /////hdnCount.Value = ds.Tables[0].Rows[0]["RWDCOUNT"].ToString().Trim();
            hdnCount.Value = "1";
            hdnCycle.Value = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE"].ToString().Trim();
            hdnYrTyp.Value = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE_TYPE"].ToString().Trim();
            hdnBusiCode.Value = ds.Tables[0].Rows[0]["FIN_YEAR"].ToString().Trim();
            hdnCycTyp.Value = ds.Tables[0].Rows[0]["CYCLE_TYPE"].ToString().Trim();
            hdnVEREFFFROM.Value = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
            hdnVEREFFTO.Value = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();
            hdnVERSION.Value = ds.Tables[0].Rows[0]["VERSION"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "GetCycle", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected DataTable Search(string flag, string yrcode, string cyc)
    {
        DataSet dsSrch = new DataSet();
        try
        {
           
        Hashtable htSrch = new Hashtable();
        dsSrch.Clear();
        htSrch.Clear();
        htSrch.Add("@BUSI_CODE", yrcode.ToString().Trim());
        htSrch.Add("@FLAG", flag.ToString().Trim());
        htSrch.Add("@ACC_CYCLE", cyc.ToString().Trim());
        if (Request.QueryString["compcode"] != null)
        {
            htSrch.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        }
        dsSrch = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htSrch);
        if (dsSrch.Tables.Count > 0 && dsSrch.Tables[0].Rows.Count > 0)
        {
            return dsSrch.Tables[0];
            }
           
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "Search", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return dsSrch.Tables[0];
    }


    #region FillCycles
    protected void FillCycles()
    {
        DataTable dt = new DataTable();
        dt.Clear();
        dt = Search("C", hdnBusiCode.Value.ToString().Trim(), hdnCycTyp.Value.ToString().Trim());
        //if (dt.Rows.Count > 0)
        //{
        //    //ddlCycles.DataSource = dt;
        //    //ddlCycles.DataValueField = "BUSI_CODE";
        //    //ddlCycles.DataTextField = "SHRT_BUSI_DESC";
        //    //ddlCycles.DataBind();
        //}
       // ddlCycles.Items.Insert(0, new ListItem("--SELECT--", ""));
    }
    #endregion

    //Bhaurao Added
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        //string msg;
       GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
       //var rulesetkey = gvAddMst.DataKeys[row.RowIndex].Value.ToString();
      //  Label lblRuleSetCode = (Label)row.FindControl("lblRuleSetCode");
        //Label lblCategoryCode = (Label)row.FindControl("lblCategoryCode");
        //Label lblRWRDCode = (Label)row.FindControl("lblRWRDCode");
       
        HiddenField hndRWD_RUL_CODE=(HiddenField)row.FindControl("hdnRWD_RUL_CODE");
        
      // htParam.Add("@cmp_code", lblCompCodeVal.Text.Trim());
       //htParam.Add("@cntst_code", lblCntstCdVal.Text.Trim());
      // htParam.Add("@ruleType", Request.QueryString["ruletype"].ToString().Trim());
       //if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
       //{
       //    htParam.Add("@RuleSetCode", lblRuleSetCode.Text.Trim());
       //    htParam.Add("@flag", 1);
        
       //}
       //else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
       //{
       //    htParam.Add("@catg_code", lblCategoryCode.Text.Trim());
       //    htParam.Add("@flag", 2);
       
       //}
       //else
       //{
          
        htParam.Add("@RWD_RUL_CODE", hndRWD_RUL_CODE.Value);
        htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
           //htParam.Add("@catg_code",Request.QueryString["CntstCode"].ToString());
           //htParam.Add("@rwrd_code", Request.QueryString["RWRD_CODE"].ToString());
           //htParam.Add("@flag", 3);
          
      // }
       ds = objDal.DelDataSetForPrc_SAIM("Prc_DelVariableCommisionRate", htParam);
       if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
       {
           // ds.Tables[0].Rows[0]["Result"].ToString().Trim();
          
               ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Deleted successfully');", true);
          
       }
      // GetPageDtls();
       
        int pageIndex = gvAddMst.PageIndex;
       if (pageIndex == 1)
       {
           txtpage.Text = "2";
           btnpre.Enabled = true;
           btnnext.Enabled = true;

       }
       else
       {
           txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
           btnpre.Enabled = true;
           btnnext.Enabled = true;

       }
       if (pageIndex == 0)
       {
           txtpage.Text = "1";
           btnpre.Enabled = false;
           btnnext.Enabled = false;

       }

       GetPageDtls();
        //gvAddMst.DataSource = ds.Tables[];
        //gvAddMst.DataBind();
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {

            // int pageIndex = gvAddMst.PageIndex;
            // gvAddMst.PageIndex = pageIndex + 1;
            //// BindRevHistGrid(lblCompCodeVal.Text.ToString());

            // txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) + 1);
            // btnpre.Enabled = true;
             GetPageDtls();
            // int page = gvAddMst.PageCount;
            // if (txtpage.Text == Convert.ToString(gvAddMst.PageCount))
            // {
            //     btnnext.Enabled = false;
            //     btnpre.Enabled = false;
            // }
            // else
            // {
            //     btnnext.Enabled = true;
            //     btnpre.Enabled = true;
            // }

            int pageIndex = gvAddMst.PageIndex;
            gvAddMst.PageIndex = pageIndex + 1;
            GetPageDtls();
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) + 1);
            btnpre.Enabled = true;
            if (txtpage.Text == Convert.ToString(gvAddMst.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gvAddMst.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void TxtCommissionRate_TextChanged(object sender, EventArgs e)
    {
        Hashtable htr = new Hashtable();
        DataSet dsr = new DataSet();
        Decimal max_rate;
        htr.Clear();
        dsr.Clear();

        if (ddlProduct.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Product code ');", true);
            TxtCommissionRate.Text = "";
        }

            if (ddlPrdClsCode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Product Category ');", true);
                TxtCommissionRate.Text = "";
            }
            htr.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString());
            htr.Add("@Product", ddlProduct.SelectedValue.ToString());
            htr.Add("@CATEGORY", ddlPrdClsCode.SelectedValue.ToString());

            dsr = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxRate", htr);
            if (dsr.Tables.Count > 0)
            {
                if (dsr.Tables[0].Rows.Count > 0)
                {
                max_rate = Convert.ToDecimal(dsr.Tables[0].Rows[0]["Max_rate"]);
                    if (TxtCommissionRate.Text != "")
                    {
                    if (Convert.ToDecimal(TxtCommissionRate.Text) > max_rate)
                         {

                             ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('You have exceeded max rate : " + max_rate.ToString() + " ');", true);
                        //Response.Write("<script language='javascript'>document.getElementById('dvBreakage').style.display = 'block';');</script>");
                        TxtCommissionRate.Text = "";

                        }

                    }
                    else 
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter Value ');", true);
                    }


            }
        }
    }
    protected void btnpre_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = gvAddMst.PageIndex;
            //gvAddMst.PageIndex = pageIndex - 1;

            ////BindRevHistGrid(lblCompCodeVal.Text.ToString());
            //txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
            //if (txtpage.Text == "1")
            //{
            //    btnpre.Enabled = false;
            //}
            //else
            //{
            //    btnnext.Enabled = true;
            //}
            //btnnext.Enabled = true;
            int pageIndex = gvAddMst.PageIndex;
            gvAddMst.PageIndex = pageIndex - 1;
            GetPageDtls();
            //  BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            //BindRevHistGrid(lblCompCodeVal.Text.ToString());
            txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
            if (txtpage.Text == "1")
            {
                btnpre.Enabled = false;
            }
            else
            {
                btnpre.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopVarSU", "btnpre_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    #region ShowRulStKy
    protected void ShowRulStKy()
    {
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", "6");
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        }
        if (Request.QueryString["ruletype"] != null)
        {
            htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRuleSetKy.DataSource = ds;
            ddlRuleSetKy.DataTextField = "RULE_SET_KEY_DESC";
            ddlRuleSetKy.DataValueField = "RULE_SET_KEY";
            ddlRuleSetKy.DataBind();
        }
        ddlRuleSetKy.Items.Insert(0, new ListItem("Select", ""));
    }
    #endregion

    protected void ddlRuleSetKy_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtRulSetDsc.Text = ddlRuleSetKy.SelectedValue.ToString();
        //txtRulSetDsc.Enabled = false;
     //   GetPageDtls();
    }

}
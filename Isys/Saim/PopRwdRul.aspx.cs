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

public partial class Application_ISys_Saim_PopRwdRul : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpcode, cntstcd;
    string strACC_YEAR="";

    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
           
           

            
            InitializeControl();
            ShowRwdCode();

            txtRwdCode.Enabled = false;
            GetRuleSetKeyDtls();
            FillDropDowns(ddlType, "1");
            FillDropDowns(ddlRwdType, "21");
            if (ddlRwdType.SelectedValue == "1001")
            { LnkVarSetUp.Visible = false; }
            else
            {
                LnkVarSetUp.Visible = true;
            }

            GetCycle();
           // FillCycles();
           // ShowMembecycle();
            ddlCatgCode.Items.Insert(0, new ListItem("--SELECT--", ""));
            ddlKPICode.Items.Insert(0, new ListItem("--SELECT--", ""));
            GetRWDMstDtls();
            if (Session["RwdRul"] != null)
            {
                DataTable dt11 = new DataTable();
                dt11 = Session["RwdRul"] as DataTable;
                if (dt11.Rows.Count > 0)
                {
                    string rwdrcrd = dt11.Rows[0]["REWARD_CODE"].ToString();
                    int minAccountLevel = int.MaxValue;
                    int maxAccountLevel = int.MinValue;
                    foreach (DataRow dr in dt11.Rows)
                    {
                        int accountLevel = Convert.ToInt32(dr.ItemArray[0]);
                        minAccountLevel = Math.Min(minAccountLevel, accountLevel);
                        maxAccountLevel = Math.Max(maxAccountLevel, accountLevel);
                        txtRwdCode.Text = maxAccountLevel.ToString();
                    }
                    int rwrd = maxAccountLevel + 1;
                    txtRwdCode.Text = rwrd.ToString();
                }
            }
           
            if (Request.QueryString["code"] != null)
            {
                FillRwd();
                if (txtBrkRul.Text == "")
                {
                    btnAddRwd.Text = "Edit Reward";
                }
                else
                {

                    btnAddRwd.Visible = false;
                }
            }
            if (Request.QueryString["MdlFlag"] != null)
            {
                ddlDependKPIRewardFlag.Enabled=false;
                ddlRwdDesc.Enabled=false;
                ddlRulSetKey.Enabled=false;
                ddlCycles.Enabled=false;
                ddlCatgCode.Enabled=false;
                ddlRwdType.Enabled=false;
                ddlType.Enabled=false;
                ddlKPICode.Enabled=false;
                txtBrkRul.Enabled = false;

                if (ddlRwdType.SelectedValue == "1001")
                { LnkVarSetUp.Visible = false; }
                else
                {
                    LnkVarSetUp.Visible = true;
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    private string GetSTRACCYEAR()
    {
        DataSet dsCmpCode = new DataSet();
        dsCmpCode.Clear();


        string strACC_YEAR = "";
        Hashtable HTCmpCode = new Hashtable();
        HTCmpCode.Clear();


        HTCmpCode.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString());

        dsCmpCode = objDal.GetDataSetForPrc_SAIM("Prc_CHECKAccYear", HTCmpCode);



        if (dsCmpCode.Tables.Count > 0)
        {
            if (dsCmpCode.Tables[0].Rows.Count > 0)
            {

                strACC_YEAR = dsCmpCode.Tables[0].Rows[0]["ACC_YEAR"].ToString();

            }


        }

        return strACC_YEAR;
    }
    protected void ShowMembecycle()
    {
        strACC_YEAR = GetSTRACCYEAR();
        if (strACC_YEAR == "1003")
        {
            lblmempay.Visible = true;
            ddlmempay.Visible = true;



        DataSet dsNEWCat = new DataSet();
        dsNEWCat.Clear();

        Hashtable HTCat = new Hashtable();
        HTCat.Clear();


        HTCat.Add("@LookupCode", "MemCycle");
        HTCat.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString());
        HTCat.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
        HTCat.Add("@RuleSetCode", ddlRulSetKey.SelectedValue.ToString().Trim());


        dsNEWCat = objDal.GetDataSetForPrc_SAIM("Prc_GetLookUpValue", HTCat);
        if (dsNEWCat.Tables.Count > 0 && dsNEWCat.Tables[0].Rows.Count > 0)
        {
            ddlmempay.DataSource = dsNEWCat;
            ddlmempay.DataTextField = "ParamDesc1";
            ddlmempay.DataValueField = "ParamValue";
            ddlmempay.DataBind();
        }
            ddlmempay.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }

    }

    public void GetRWDMstDtls()
    {
        try { 
        htParam.Clear();
        ds.Clear();
        htParam.Add("@cmpcode", Request.QueryString["compcode"].ToString().Trim());
        htParam.Add("@cntstcode", Request.QueryString["cntstcd"].ToString().Trim());
        htParam.Add("@flag", "3");
	    htParam.Add("@RuleType", "R");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleMstDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRwdDesc.Items.Clear();

            ddlRwdDesc.DataSource = ds;
            ddlRwdDesc.DataTextField = ds.Tables[0].Columns[4].ToString().Trim();
            ddlRwdDesc.DataValueField = ds.Tables[0].Columns[3].ToString().Trim();
            ddlRwdDesc.DataBind();

            ddlRwdDesc.Items.Insert(0, new ListItem("--SELECT--", ""));
            ddlRwdDesc.Visible = true;
            txtRwdDesc1.Visible = false;
            txtRwdCode.Text = "";
        }
        else
        {
            //ddlRwdDesc.Items.Insert(0, new ListItem("--SELECT--", ""));
          
            ddlRwdDesc.Visible = false;
            txtRwdDesc1.Visible = true;
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetRWDMstDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ShowRwdCode()
    {
        try { 
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", "4");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtRwdCode.Text = ds.Tables[0].Rows[0]["RWRD_CODE"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "ShowRwdCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    //added by ajay sawant


    protected void FillRewardDependDDL(DropDownList ddlRD, string Flag)
    {
        try
        {
            ddlRD.Items.Clear();

            Hashtable ht = new Hashtable();
            ds = new DataSet();
            ht.Add("@CompCode", ddlRDCmpCode.SelectedValue.ToString().Trim());


            ht.Add("@CntstCode", ddlRDCnstCode.SelectedValue.ToString().Trim());

            ht.Add("@RuleSetKey", ddlRewardDependRuleSet.SelectedValue.ToString().Trim());
            ht.Add("@flag", Flag);

            ds = objDal.GetDataSetForPrc_SAIM("Prc_FillRewardDependKPI", ht);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ddlRD.DataSource = ds.Tables[0];
                ddlRD.DataTextField = "Descrip";

                ddlRD.DataValueField = "Val";
                ddlRD.DataBind();
            }

            ddlRD.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "FillRewardDependDDL", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void FillddlVal(DropDownList ddl, string rulsetky,string catgcd, string flag, string text, string value)
    {
        try { 
        DataSet ds1 = new DataSet();
        htParam = new Hashtable();
        ds1.Clear();
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "FillddlVal", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    
    
    
    protected void ddlRulSetKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlVal(ddlCatgCode, ddlRulSetKey.SelectedValue.ToString().Trim(), "", "2", "CATG_DESC01", "CATG_CODE");
        GetRulSetClass( ddlRulSetKey.SelectedValue.ToString().Trim());
        FillCycles();
        ShowMembecycle();
        MaxCode("4");
      //  FillRewardDependKPI(ddlRewardDependKPI, ddlRulSetKey.SelectedValue.ToString());

       
    }

    protected void ddlRDCmpCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRewardDependDDL(ddlRDCnstCode,"2");

    }
    
    protected void ddlRDCnstCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRewardDependDDL(ddlRewardDependRuleSet, "3");
        
    }


    protected void VisibleTarget(string val)
    {
        try
        {
            DataSet dsVisi = new DataSet();
            Hashtable htVisi = new Hashtable();
            dsVisi.Clear();
            htVisi.Clear();


            htVisi.Add("@CmpstnCode", Request.QueryString["compcode"].ToString().Trim());


            htVisi.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());

            htVisi.Add("@RuleSetCode", ddlRulSetKey.SelectedValue.ToString().Trim());
            htVisi.Add("@KPI_CODE", val);

            dsVisi = objDal.GetDataSetForPrc_SAIM("Prc_GetComputationtype", htVisi);
            if (dsVisi.Tables.Count > 0 && dsVisi.Tables[0].Rows.Count > 0)
            {
                if (dsVisi.Tables[0].Rows[0]["CMPTTN_FLAG"].ToString().Trim() == "1")
                {
                  //  divTarget.Visible = true;

                }
                else
                {
                    divTarget.Visible = false;
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "VisibleTarget", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
       

    }


    public void MaxCode(string val)
    {
        try
        {
            DataSet dsMax = new DataSet();
            Hashtable htMax = new Hashtable();
            htMax.Clear();
            dsMax.Clear();
            htMax.Add("@cmpcode", "");
            htMax.Add("@cntstcode", "");

            htMax.Add("@flag", val);
            dsMax = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodesForMaster", htMax);
            if (dsMax.Tables.Count > 0 && dsMax.Tables[0].Rows.Count > 0)
            {
                hdnRWDLNK.Value = dsMax.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "MaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {

        DataSet dsdnd = new DataSet();
        Hashtable htdnd = new Hashtable();
        dsdnd.Clear();
        htdnd.Clear();
        string msgs;


        htdnd.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        htdnd.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());


        htdnd.Add("@RULE_SET_KEY", ddlRulSetKey.SelectedValue.ToString().Trim());
        //// htParam.Add("@KPI_CODE", ddlKPICode.SelectedValue.ToString().Trim());

        htdnd.Add("@RWD_DPNDNT_LNK", hdnRWDLNK.Value.ToString().Trim());
        htdnd.Add("@RWRD_CODE", txtRwdCode.Text.ToString());



        if (ddlRDCmpCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select  Dependant  Reward Compensation Code');", true);
            return;
        }
        if (ddlRDCnstCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select  Dependant  Reward Contestant Code');", true);
            return;
        }

        if (ddlRewardDependRuleSet.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select  Dependant  Reward Set Code');", true);
            return;
        }

        if (ddlRewardDependKPI.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Dependant Reward Description');", true);
            return;
        }

        htdnd.Add("@DPNDNT_CMPNSTN_CODE", ddlRDCmpCode.SelectedValue.ToString().Trim());
        htdnd.Add("@DPNDNT_CNTSTNT_CODE", ddlRDCnstCode.SelectedValue.ToString().Trim());
        htdnd.Add("@DPNDNT_RULE_SET_KEY", ddlRewardDependRuleSet.SelectedValue.ToString().Trim());
        htdnd.Add("@DPNDNT_RWD_DESC", ddlRewardDependKPI.SelectedValue.ToString().Trim());

        htdnd.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
        htdnd.Add("@CYCLE", ddlCycles.SelectedValue.ToString().Trim());//Added by Abuzar on 09/07/2020


        dsdnd = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls_DPNDT", htdnd);
        if (dsdnd.Tables.Count > 0 && dsdnd.Tables[0].Rows.Count > 0)
        {
            msgs = dsdnd.Tables[0].Rows[0]["MSG"].ToString().Trim();
            if (msgs == "FAIL")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Reward  description alredy exist');", true);
                //  ddlAccMode.SelectedIndex = 0;
                // rblCRYFWD.SelectedValue = "";
                //txtMaxLmt.Text = "";

                return;
            }
            else
            {

                 BindDpndGrid();
            }
        }

    }





    protected void ddlDependKPIRewardFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDependKPIRewardFlag.SelectedValue.ToString().Trim()=="Y")
        {
            divDependOnKPI.Visible = true;
            lblRewardDependKPI.Visible = true;
            ddlRewardDependKPI.Visible = true;
            divRewardDependCmp.Visible = true;
            FillRewardDependDDL(ddlRDCmpCode, "1");
            divbutton.Visible = true;

            BindDpndGrid();
        }
        else
        {
            lblRewardDependKPI.Visible = false;
            ddlRewardDependKPI.Visible = false;
            divDependOnKPI.Visible = false;
            divRewardDependCmp.Visible = false;
            divbutton.Visible = false;

        }
       
       
    }


    protected void ddlCatgCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlVal(ddlKPICode, ddlRulSetKey.SelectedValue.ToString().Trim(), ddlCatgCode.SelectedValue.ToString().Trim(), "3", "KPI_DESC", "KPI_CODE");
    }
    protected void ddlKPICode_SelectedIndexChanged(object sender, EventArgs e)
    {
            VisibleTarget(ddlKPICode.SelectedValue.ToString().Trim());
    }
        
     
    protected void ddlRewardDependRuleSet_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            FillRewardDependDDL(ddlRewardDependKPI, "4");
            
        //    ddlRewardDependKPI.Items.Clear();
        //    Hashtable ht = new Hashtable();
        //    ds = new DataSet();

        //    ht.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        //    ht.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());

        //    ht.Add("@RuleSetKey", ddlRewardDependRuleSet.SelectedValue.ToString().Trim());
        //    //ht.Add("@KPICode", ddlKPICode.SelectedValue.ToString().Trim());

        //    ds = objDal.GetDataSetForPrc_SAIM("Prc_FillRewardDependKPI", ht);
        //   // ds = objDal.Common_exec_reader_prc_SAIM("Prc_FillRewardDependKPI", ht);
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {

        //        ddlRewardDependKPI.DataSource = ds.Tables[0];
        //        ddlRewardDependKPI.DataTextField = "KPI_DESC_01";
        //        ddlRewardDependKPI.DataValueField = "KPI_CODE";
        //        ddlRewardDependKPI.DataBind();
        //    }
        //   // drRead.Close();
        //    ddlRewardDependKPI.Items.Insert(0, new ListItem("-- SELECT --", ""));
        //
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "ddlRewardDependRuleSet_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
       
    }
    protected void ddlRwdType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { 
        //FillddlVal(ddlKPICode, ddlRulSetKey.SelectedValue.ToString().Trim(), ddlCatgCode.SelectedValue.ToString().Trim(), "3", "KPI_DESC", "KPI_CODE");
        if (ddlRwdType.SelectedValue.ToString() == "1002")
        {
            txtValue.Enabled = false;
            txtRate.Enabled = false;
            txtBrkRul.Enabled = false;
            LnkVarSetUp.Visible = true;
            btnAddRwd.Visible = false;
        }
        else
        {
            txtValue.Enabled = true;
            txtRate.Enabled = true;
            txtBrkRul.Enabled = true;
            LnkVarSetUp.Visible = false;
            btnAddRwd.Visible = true;

        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "ddlRwdType_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlVal(ddlKPICode, ddlRulSetKey.SelectedValue.ToString().Trim(), ddlCatgCode.SelectedValue.ToString().Trim(), "3", "KPI_DESC", "KPI_CODE");
        ChkType();
    }

    protected void BindTable(string sID)
    {
        try { 
        DataTable dtUniqRecords = new DataTable();
        DataTable dtCountRecords = new DataTable();
        DataTable dtBindRecord = new DataTable();
        DataRow drcount = dtBindRecord.NewRow();
        dtBindRecord.Columns.Add("COUNT", typeof(System.Int32));
        dtBindRecord.Columns.Add("CYCLE", typeof(string));
        int count;
        DataTable dtRwdRul = new DataTable();
        DataTable dt = new DataTable();
        dt.Columns.Add("RWD_RUL_CODE");
        dt.Columns.Add("REWARD_CODE");
        dt.Columns.Add("RWD_DESC");
        dt.Columns.Add("CYCLE");
        dt.Columns.Add("CYCLE_CODE");
        dt.Columns.Add("RWRD_DESC02");
        dt.Columns.Add("RWRD_DESC03");
        dt.Columns.Add("CATEGORY");
        dt.Columns.Add("CATG_CODE");
        dt.Columns.Add("RULE_SET_KEY");
        dt.Columns.Add("REWARD_TYPE_DESC");
        dt.Columns.Add("REWARD_TYPE");
        dt.Columns.Add("TYPE");
        dt.Columns.Add("TYPE_DESC");
        dt.Columns.Add("KPI_CODE");
        dt.Columns.Add("KPI_DESC");
        dt.Columns.Add("VALUE");
        dt.Columns.Add("RATE");
        dt.Columns.Add("BRK_RULE");
        dt.Columns.Add("VER_EFF_FROM");
        dt.Columns.Add("VER_EFF_TO");
        dt.Columns.Add("VERSION");
        dt.Columns.Add("FIN_YEAR");
       // dt.Columns.Add("RWRD_RELEASE");
        dtRwdRul.Columns.Add("RWD_RUL_CODE");
        dtRwdRul.Columns.Add("REWARD_CODE");
        dtRwdRul.Columns.Add("RWD_DESC");
        dtRwdRul.Columns.Add("CYCLE");
        dtRwdRul.Columns.Add("CYCLE_CODE");
        dtRwdRul.Columns.Add("RWRD_DESC02");
        dtRwdRul.Columns.Add("RWRD_DESC03");
        dtRwdRul.Columns.Add("CATEGORY");
        dtRwdRul.Columns.Add("CATG_CODE");
        dtRwdRul.Columns.Add("RULE_SET_KEY");
        dtRwdRul.Columns.Add("REWARD_TYPE_DESC");
        dtRwdRul.Columns.Add("REWARD_TYPE");
        dtRwdRul.Columns.Add("TYPE");
        dtRwdRul.Columns.Add("TYPE_DESC");
        dtRwdRul.Columns.Add("KPI_CODE");
        dtRwdRul.Columns.Add("KPI_DESC");
        dtRwdRul.Columns.Add("VALUE");
        dtRwdRul.Columns.Add("RATE");
        dtRwdRul.Columns.Add("BRK_RULE");
        dtRwdRul.Columns.Add("VER_EFF_FROM");
        dtRwdRul.Columns.Add("VER_EFF_TO");
        dtRwdRul.Columns.Add("VERSION");
        dtRwdRul.Columns.Add("FIN_YEAR");
       // dtRwdRul.Columns.Add("RWRD_RELEASE"); 
        DataTable dtCyc = new DataTable();
        dtCyc = GetCycleDesc(ddlCatgCode.SelectedValue.ToString().Trim(), "4", 0);
        if (Session[sID] != null)
        {
            for (int i = 0; i <= Convert.ToInt32(hdnCount.Value.ToString().Trim()) - 1; i++)
            {
                string rwrdrulcode;
                DataRow dr1 = dtRwdRul.NewRow();
                //if (i == 0)
                //{
                //    dr1["REWARD_CODE"] = txtRwdCode.Text.ToString().Trim();
                //}
                //else
                //{
                //    dr1["REWARD_CODE"] = ViewState["rwrdcode"];

                if (Request.QueryString["code"] != null)
                {
                    rwrdrulcode = Request.QueryString["code"].ToString().Trim();
                }
                else
                {
                    rwrdrulcode = GetMaxCode("5");
                }
                dr1["RWD_RUL_CODE"] = rwrdrulcode.ToString().Trim();
                dr1["REWARD_CODE"] = txtRwdCode.Text.ToString().Trim();
                dr1["RWD_DESC"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr1["CYCLE"] = ddlCycles.SelectedItem.Text.ToString().Trim();
                dr1["CYCLE_CODE"] = ddlCycles.SelectedValue.ToString().Trim();
                dr1["RWRD_DESC02"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr1["RWRD_DESC03"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr1["CATEGORY"] = ddlCatgCode.SelectedItem.ToString().Trim();////akshay 
                dr1["CATG_CODE"] = ddlCatgCode.SelectedValue.ToString().Trim();
                dr1["RULE_SET_KEY"] = ddlRulSetKey.SelectedValue.ToString().Trim();
                dr1["REWARD_TYPE_DESC"] = ddlRwdType.SelectedItem.Text.ToString().Trim();
                dr1["REWARD_TYPE"] = ddlRwdType.SelectedValue.ToString().Trim();
                dr1["TYPE_DESC"] = ddlType.SelectedItem.Text.ToString().Trim();
                dr1["TYPE"] = ddlType.SelectedValue.ToString().Trim();
                dr1["KPI_DESC"] = ddlKPICode.SelectedItem.Text.ToString().Trim();
                dr1["KPI_CODE"] = ddlKPICode.SelectedValue.ToString().Trim();
                dr1["VALUE"] = txtValue.Text.ToString().Trim();
                dr1["RATE"] = txtRate.Text.ToString().Trim();
                dr1["BRK_RULE"] = txtBrkRul.Text.ToString().Trim();
                dr1["VER_EFF_FROM"] = hdnVEREFFFROM.Value.ToString().Trim();
                dr1["VER_EFF_TO"] = hdnVEREFFTO.Value.ToString().Trim();
                dr1["VERSION"] = hdnVERSION.Value.ToString().Trim();
                dr1["FIN_YEAR"] = hdnBusiCode.Value.ToString().Trim();
              //  dr1["RWRD_RELEASE"] = ddlmempay.SelectedValue.ToString().Trim();
                dtRwdRul.Rows.Add(dr1);
                ////rwrdcode = Convert.ToInt32(txtRwdCode.Text.ToString().Trim());
                ////rwrdcode = rwrdcode + 1;
                ////ViewState["rwrdcode"] = rwrdcode;
            }
        }
        else
        {
            for (int i = 0; i <= Convert.ToInt32(hdnCount.Value.ToString().Trim()) - 1; i++)
            {
                int rwrdcode;
                DataRow dr = dt.NewRow();
                //if (i == 0)
                //{
                //    dr["REWARD_CODE"] = txtRwdCode.Text.ToString().Trim();
                //}
                //else
                //{
                //    dr["REWARD_CODE"] = ViewState["rwrdcode"];
                //}
                dr["RWD_RUL_CODE"] = txtRwdCode.Text.ToString().Trim();
                dr["REWARD_CODE"] = txtRwdCode.Text.ToString().Trim();
                dr["RWD_DESC"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr["CYCLE"] = ddlCycles.SelectedItem.Text.ToString().Trim();
                dr["CYCLE_CODE"] = ddlCycles.SelectedValue.ToString().Trim();
                dr["RWRD_DESC02"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr["RWRD_DESC03"] = ddlRwdDesc.SelectedItem.Text.ToString().Trim();
                dr["CATEGORY"] = ddlCatgCode.SelectedValue.ToString().Trim();
                dr["CATG_CODE"] = ddlCatgCode.SelectedItem.ToString().Trim();
                dr["RULE_SET_KEY"] = ddlRulSetKey.SelectedValue.ToString().Trim();
                dr["REWARD_TYPE_DESC"] = ddlRwdType.SelectedItem.Text.ToString().Trim();
                dr["REWARD_TYPE"] = ddlRwdType.SelectedValue.ToString().Trim();
                dr["TYPE_DESC"] = ddlType.SelectedItem.Text.ToString().Trim();
                dr["TYPE"] = ddlType.SelectedValue.ToString().Trim();
                dr["KPI_DESC"] = ddlKPICode.SelectedItem.Text.ToString().Trim();
                dr["KPI_CODE"] = ddlKPICode.SelectedValue.ToString().Trim();
                dr["VALUE"] = txtValue.Text.ToString().Trim();
                dr["RATE"] = txtRate.Text.ToString().Trim();
                dr["BRK_RULE"] = txtBrkRul.Text.ToString().Trim();
                dr["VER_EFF_FROM"] = hdnVEREFFFROM.Value.ToString().Trim();
                dr["VER_EFF_TO"] = hdnVEREFFTO.Value.ToString().Trim();
                dr["VERSION"] = hdnVERSION.Value.ToString().Trim();
                dr["FIN_YEAR"] = hdnBusiCode.Value.ToString().Trim();
             //   dr1["RWRD_RELEASE"] = ddlmempay.SelectedValue.ToString().Trim();
                
                dt.Rows.Add(dr);
                ////rwrdcode = Convert.ToInt32(txtRwdCode.Text.ToString().Trim());
                ////rwrdcode = rwrdcode + 1;
                ////ViewState["rwrdcode"] = rwrdcode;dtRwdRul
            }
        }
        //if (Session[sID] != null)
        //{
        //    dt = Session[sID] as DataTable;
        //    dtRwdRul.Merge(dt, true, MissingSchemaAction.Ignore);
        //    Session[sID] = dtRwdRul;
        //}
        //else
        //{
        //    Session[sID] = dt;
        //}
        dtRwdRul.Merge(dt, true, MissingSchemaAction.Ignore);
        Session[sID] = dtRwdRul;
        /////dt = Session[sID] as DataTable;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    dtUniqRecords = dt.DefaultView.ToTable(true, "CYCLE");
        //}

        //dtUniqRecords.Columns.Add("COUNT", typeof(System.Int32));
        //dtCountRecords = dt.Clone();
        //for (int i = 0; i < dtUniqRecords.Rows.Count; i++)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr[2].ToString().Trim() == dtUniqRecords.Rows[i][0].ToString().Trim())
        //        {
        //            DataRow drNew = dtCountRecords.NewRow();
        //            drNew.ItemArray = dr.ItemArray;
        //            dtCountRecords.Rows.Add(drNew);
        //            count = dtCountRecords.Rows.Count;
        //            ViewState["a22"] = count;
        //        }
        //    }
        //    drcount["COUNT"] = ViewState["a22"];
        //    drcount["CYCLE"] = dtUniqRecords.Rows[i][0].ToString().Trim();
        //    dtBindRecord.Rows.Add(drcount.ItemArray);
        //    dtCountRecords.Rows.Clear();
        //}
        ///Session["BindRecord"] = dtBindRecord;
        ///Session["RwdRul1"] = Session["BindRecord"];
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "BindTable", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Added by arjun
    protected void LnkVarSetUp_Click(object sender, EventArgs e)
    {

        try { 
        string cmpnstcd = string.Empty, cntstcd = string.Empty, rultyp = string.Empty, MEMBERCODE = string.Empty, BRKPRULE_CODE=string.Empty;
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
        if (Request.QueryString["MEMBERCODE"] != null)
        {
            MEMBERCODE = Request.QueryString["MEMBERCODE"].ToString().Trim();
        }
        if(txtBrkRul.Text !="")
        {
            BRKPRULE_CODE = txtBrkRul.Text.ToString();

        }
            if(ddlDependKPIRewardFlag.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Dependent Reward Flag');", true);
                return;
                

            }
        
            //UAT bug fixing done by arjun      

        if (MEMBERCODE != "" && ddlReasonforEdit.SelectedValue.ToString().Trim()=="")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Edit Reason');", true);
            return;

        }

        mdlVw1.Show();
        

        if (Request.QueryString["MdlFlag"] != null)
        {
            //funAddVarMasterMdl
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddVarMaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRuleMdl','" + rultyp.ToString().Trim() + "','" + MEMBERCODE.ToString().Trim() + "','" + BRKPRULE_CODE.ToString().Trim() + "','" + ddlReasonforEdit.SelectedValue.ToString().Trim() + "');", true);
        }
        else {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddVarMaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRule','" + rultyp.ToString().Trim() + "','" + MEMBERCODE.ToString().Trim() + "','" + BRKPRULE_CODE.ToString().Trim() + "','" + ddlReasonforEdit.SelectedValue.ToString().Trim() + "');", true);
        }


    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "LnkVarSetUp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //end by arjun
    protected void btnAddRwd_Click(object sender, EventArgs e)
    {
        try { 
        GetCycle();
        if (Request.QueryString["rultyp"] != null) 
        {
            if (Request.QueryString["rultyp"] == "R")
            {
                BindTable("RwdRul");
                SaveRwd();
            }
        }
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doOk('" + Request.QueryString["rultyp"].ToString().Trim() + "');", true);

        int n = 0 + 1;
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "btnAddRwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetCycle()
    {
        try { 
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetCycle", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected DataTable GetCycleDesc(string code, string flag, int i)
    {
        ds = new DataSet();
        try { 
        string value = string.Empty;
      
        htParam = new Hashtable();
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["compcode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["compcode"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        }
        htParam.Add("@RulSetKey", ddlRulSetKey.SelectedValue.ToString().Trim());
        htParam.Add("@CatgCode", code.ToString().Trim());
        htParam.Add("@flag", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwrdRuleVal", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0];
        }
        
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetCycleDesc", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return ds.Tables[0];
    }

    protected void InitializeControl()
    {
        try
        {
        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"] == "Q")
            {
                lblhdr.Text = "Qualification Rule Setup";
                lblRwdCode.Text = "Qualification Code";
                lblRwdDesc1.Text = "Qualification Description ";
                lblRwdDesc2.Text = "Qualification Description 2";
                lblRwdDesc3.Text = "Qualification Description 3";
                lblRwdType.Text = "Qualification Type";
                txtRwdCode.Attributes["placeholder"] = "Qualification Code";
                txtRwdDesc1.Attributes["placeholder"] = "Qualification Description 1";
                txtRwdDesc2.Attributes["placeholder"] = "Qualification Description 2";
                txtRwdDesc3.Attributes["placeholder"] = "Qualification Description 3";
            }
            else if (Request.QueryString["rultyp"] == "R")
            {
                lblhdr.Text = "Reward Rule Setup";
                lblRwdCode.Text = "Reward Code";
                lblRwdDesc1.Text = "Reward Description 1";
                lblRwdDesc2.Text = "Reward Description 2";
                lblRwdDesc3.Text = "Reward Description 3";
                lblRwdType.Text = "Reward Type";
                txtRwdCode.Attributes["placeholder"] = "Reward Code";
                txtRwdDesc1.Attributes["placeholder"] = "Reward Description 1";
                txtRwdDesc2.Attributes["placeholder"] = "Reward Description 2";
                txtRwdDesc3.Attributes["placeholder"] = "Reward Description 3";
                    ddlRewardDependKPI.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    ddlRewardDependRuleSet.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    ddlCycles.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    ddlRDCnstCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
                    ddlMemLoc.Items.Insert(0, new ListItem("-- SELECT --", ""));
                if (Request.QueryString["page"] == "A")
                {
                    ddlReasonforEdit.Visible = true;
                    lblReasonforEdit.Visible = true;
                    FillReasonDDL();

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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "InitializeControl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkSetFrml_Click(object sender, EventArgs e)
    {
        mdlView.Show();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpFrml();", true);
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillReasonDDL()
    {
        DataSet dsReason = new DataSet();
        dsReason.Clear();

        Hashtable HTReason = new Hashtable();
        HTReason.Clear();



        HTReason.Add("@LookupCode", "ReasonForEdit");



        dsReason = objDal.GetDataSetForPrc_SAIM("Prc_GetLookUpValue", HTReason);
        if (dsReason.Tables.Count > 0 && dsReason.Tables[0].Rows.Count > 0)
        {
            ddlReasonforEdit.DataSource = dsReason;
            ddlReasonforEdit.DataTextField = "ParamDesc1";
                ddlReasonforEdit.DataValueField = "ParamValue";

            ddlReasonforEdit.DataBind();
        }
        ddlReasonforEdit.Items.Insert(0, new ListItem("Select", ""));

    }

    protected void SaveRwd()
    {
        try
        {
            #region SAVE REWARD RULES
            string msg = string.Empty;
            if (Request.QueryString["compcode"] != null)///@CatgCode
            {
                cmpcode = Request.QueryString["compcode"].ToString().Trim();
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
            //if (Request.QueryString["rultyp"] != null)
            //{
            //    htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
            //}
            DataTable dtRwdRul = new DataTable();
            dtRwdRul = Session["RwdRul"] as DataTable;
            ds.Clear();
            htParam.Clear();
            //htParam.Add("@CMPNSTN_CODE", cmpcode.ToString().Trim());
            //htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            //////htParam.Add("@RULE_TYPE", "R");
            //ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdRulDtls", htParam);
            List<string> lstRwdRulCode = new List<string>();
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
          // List<string> lstMemberCycle = new List<string>();

            for (int intRowCount = 0; intRowCount <= dtRwdRul.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRwdRulCode = new HiddenField();
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
               // HiddenField hdnMemberCycle = new HiddenField();

                hdnRwdRulCode.Value = dtRwdRul.Rows[intRowCount]["RWD_RUL_CODE"].ToString().Trim();
                lstRwdRulCode.Add(hdnRwdRulCode.Value.ToString().Trim());
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
               // hdnMemberCycle.Value = dtRwdRul.Rows[intRowCount]["RWRD_RELEASE"].ToString().Trim();
               // lstMemberCycle.Add(hdnMemberCycle.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRulSetKey.Count - 1; intDataCount++)
            {


                if (Request.QueryString["MEMBERCODE"] != null && ddlReasonforEdit.SelectedValue.ToString().Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Edit Reason');", true);
                    return;

                }

                
                htParam.Clear();
                ds.Clear();
                htParam.Add("@RWRD_CODE", lstRewardCode[intDataCount]);
                htParam.Add("@RWD_DESC", lstRwrdDesc[intDataCount]);
                htParam.Add("@RWRD_DESC02", lstRwrdDesc02[intDataCount]);
                htParam.Add("@RWRD_DESC03", lstRwrdDesc03[intDataCount]);
                htParam.Add("@CATG_CODE", lstCatgCode[intDataCount]);
                htParam.Add("@CYCLE", lstCycle[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", cmpcode.ToString().Trim());
                htParam.Add("@RWRD_TYPE", lstRwrdType[intDataCount]);
                htParam.Add("@TYPE", lstType[intDataCount]);
                htParam.Add("@BASED_ON_KPI", lstKPICode[intDataCount]);
                htParam.Add("@VALUE", lstValue[intDataCount] == "" ? "0.0" : lstValue[intDataCount]);
                htParam.Add("@BRKUPRULE", lstBrkupRule[intDataCount]);
                htParam.Add("@CATG_DESC01", lstRwrdDesc[intDataCount]);
                htParam.Add("@CATG_DESC02", lstRwrdDesc02[intDataCount]);
                htParam.Add("@CATG_DESC03", lstRwrdDesc03[intDataCount]);
                htParam.Add("@RATE", lstRate[intDataCount] == "" ? "0.0" : lstRate[intDataCount]);
              //  htParam.Add("@RWRD_RELEASE",lstMemberCycle[intDataCount]);
                if (chkCyc.Checked == true)
                {
                    htParam.Add("@CHKCYC", "1");
                }
                else
                {
                    htParam.Add("@CHKCYC", "0");
                }
                //htParam.Add("@EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                //htParam.Add("@EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                //htParam.Add("@FIN_YEAR", lstFinYear[intDataCount]);
                //htParam.Add("@VER_NO", lstVrsn[intDataCount]);
                //htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                //htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                if (Request.QueryString["code"] != null)
                {
                    htParam.Add("@RWD_RUL_CODE", Request.QueryString["code"].ToString().Trim());
                    htParam.Add("@FLAG", "E");
                }
                else
                {
                    htParam.Add("@RWD_RUL_CODE", lstRwdRulCode[intDataCount]);       
                    htParam.Add("@FLAG", "N");
                }
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                if(ddlDependKPIRewardFlag.SelectedValue.ToString().Trim()=="Y")
                {
                    if (ddlRDCmpCode.SelectedIndex==0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Dependent Reward Compensation Code');", true);
                        return;

                    }
                    if (ddlRDCnstCode.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Dependent Reward Contestant Code');", true);
                        return;

                    }
                    if (ddlRewardDependRuleSet.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Dependent Reward Rule Set Code');", true);
                        return;

                    }
                    if (ddlRewardDependKPI.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Dependent Reward KPI Code');", true);
                        return;

                    }
                   
                    htParam.Add("@DEPENDENT_RWD_CMPNSTN_CODE", "");
                    htParam.Add("@DEPENDENT_RWD_CNTSTNT_CODE","");
                    htParam.Add("@DEPENDENT_RWD_KPI", "");
                    htParam.Add("@DEPENDENT_RWD_RULESET_KEY", "");

                }

                htParam.Add("@TRGT_FROM", txtTargetFrom.Text.ToString().Trim());
                htParam.Add("@TRGT_TO", txtTargetTo.Text.ToString().Trim());
                htParam.Add("@RWRD_RELEASE", ddlmempay.SelectedValue.ToString().Trim());
                htParam.Add("@DEPENDENT_ON_KPI_RWD", ddlDependKPIRewardFlag.SelectedValue.ToString().Trim());
            //    htParam.Add("@RWD_DPNDNT_LNK", hdnRWDLNK.Value.ToString().Trim());


                if (Request.QueryString["MEMBERCODE"] != null)
                {
                    htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString().Trim());
                }
                if (Request.QueryString["Page"] == null && hdnRulClass.Value=="NS")
                 {
                     if (hdnAgentCode.Value == "")
                     {
                         ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select member code');", true);
                        return;
                     }
                     else
                     {
                         htParam.Add("@MEMBERCODE", hdnAgentCode.Value);
                         if (ddlMemLoc.Visible==true)
                         {

                             if (ddlMemLoc.SelectedIndex==0)
                             {
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Location');", true);
                                 return;  
                             }

                             else
                             {
                                 htParam.Add("@MEM_UNT_CODE", ddlMemLoc.SelectedValue.ToString().Trim());
                             }
                         }
                         
                     }
                }
                if (Request.QueryString["Page"] != null)
                {
                    htParam.Add("@Page", Request.QueryString["Page"].ToString().Trim());
                    if (ddlReasonforEdit.SelectedIndex==0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Reason For Edit);", true);
                        return;
                }
                    else
                    {
                        htParam.Add("@REASONFOREDIT", ddlReasonforEdit.SelectedValue.ToString().Trim()); 
                    }
                   
               
                }
                if (Request.QueryString["Page"] != null && Request.QueryString["MdlFlag"] == null)
                {
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls_temp", htParam);
                }
                else if (Request.QueryString["Page"] == null && Request.QueryString["MdlFlag"] != null)
                {
                    htParam.Add("@MdlFlag", "MdlFlag");
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls", htParam);
                }
                else if (Request.QueryString["Page"] != null && Request.QueryString["MdlFlag"] != null)
                {
                    htParam.Add("@MdlFlag", "MdlFlag");
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls_temp", htParam);
                }
                else
                {

                    ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdRulesDtls", htParam);

                }


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    msg = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
                }
                if (msg == "FAILED")
                {
                    txtBrkRul.Text = "";
                    txtValue.Text = "";
                    ddlType.SelectedIndex = 0;
                    ddlCatgCode.SelectedIndex = 0;
                    ddlCycles.SelectedIndex = 0;
                    ddlRulSetKey.SelectedIndex = 0;
                    txtRwdDesc3.Text = "";
                    txtRwdDesc2.Text = "";
                    //ddlRwdDesc.SelectedIndex = 0;
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Reward is already assigned to the category for the cycle');", true);
                    return;
                }
            }
            //hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
            //mdlpopup.Show();
            //lbl3.Text = "Rewards Rules saved successfully";
            //lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            //lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            //btnSaveRwdRul.Enabled = true;
            #endregion

            htParam.Clear();
            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
            htParam.Add("@RWD_CODE", txtRwdCode.Text.Trim());
            if (ddlRwdDesc.Visible == true)
            {
                htParam.Add("@RWDCodeDesc", ddlRwdDesc.SelectedItem.Text.Trim());
            }
            else
            {
                htParam.Add("@RWDCodeDesc", txtRwdDesc1.Text.Trim());
            }
            htParam.Add("@RULE_TYPE", "R");


            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRWDCodeMst", htParam);

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "SaveRwd", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BindDpndGrid()
    {
        try
        {
            DataSet dsdpnd = new DataSet();
            Hashtable htdpnd = new Hashtable();
            dsdpnd.Clear();
            htdpnd.Clear();
            if (Request.QueryString["compcode"] != null)
            {
              
                htdpnd.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                htdpnd.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim().ToString().Trim());
            }

            htdpnd.Add("@RULE_SET_KEY", ddlRulSetKey.SelectedValue.ToString());


            htdpnd.Add("@RWRD_CODE", txtRwdCode.Text.ToString().Trim());
            dsdpnd = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_DPNDT", htdpnd);
            if (dsdpnd.Tables.Count > 0 && dsdpnd.Tables[0].Rows.Count > 0)
            {
                dgdpnd.DataSource = dsdpnd;
                dgdpnd.DataBind();
            }
            else
            {
                
            }
           
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "BindDpndGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void FillRwd()
    {
        try { 
        DataTable dt = new DataTable();
        DataSet dsFIllRwd = new DataSet();
        dsFIllRwd.Clear();
        htParam.Clear();
        if (Request.QueryString["code"] != null)
        {
            htParam.Add("@RWRD_RUL_CODE", Request.QueryString["code"].ToString().Trim());
           // htParam.Add("@RWRD_RUL_CODE", Request.QueryString["code"].ToString().Trim());

            if (Request.QueryString["Page"] != null)
            {
                dsFIllRwd = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp", htParam);
            }
            else
            {
                dsFIllRwd = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
            }

            if (dsFIllRwd.Tables.Count > 0 && dsFIllRwd.Tables[0].Rows.Count > 0)
            {
                hdnRwdRulCode.Value = dsFIllRwd.Tables[0].Rows[0]["RWD_RUL_CODE"].ToString().Trim();
                txtRwdCode.Text = dsFIllRwd.Tables[0].Rows[0]["REWARD_CODE"].ToString().Trim();
                ddlRwdDesc.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["REWARD_CODE"].ToString().Trim();
                txtRwdDesc1.Text = dsFIllRwd.Tables[0].Rows[0]["RWD_DESC"].ToString().Trim();
                if (txtRwdDesc1.Text != null)
                {
                    txtRwdDesc1.Enabled = false;
                }
                else
                {
                    txtRwdDesc1.Enabled = true;
                }
                txtRwdDesc2.Text = dsFIllRwd.Tables[0].Rows[0]["RWRD_DESC02"].ToString().Trim();
                txtRwdDesc3.Text = dsFIllRwd.Tables[0].Rows[0]["RWRD_DESC03"].ToString().Trim();
                txtValue.Text = dsFIllRwd.Tables[0].Rows[0]["VALUE"].ToString().Trim();
                ddlRulSetKey.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                //Cycle fill up

                FillCycles();

                FillddlVal(ddlCatgCode, ddlRulSetKey.SelectedValue.ToString().Trim(), "", "2", "CATG_DESC01", "CATG_CODE");
                ddlCatgCode.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["CATG_CODE"].ToString().Trim();
                txtBrkRul.Text = dsFIllRwd.Tables[0].Rows[0]["BRK_RULE"].ToString().Trim();
                ddlRwdType.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["REWARD_TYPE"].ToString().Trim();
                if (ddlRwdType.SelectedValue == "1001")
                { LnkVarSetUp.Visible = false; }
                else
                {
                    LnkVarSetUp.Visible = true;
                }
                ddlType.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["TYPE"].ToString().Trim();
                ChkType();
                FillddlVal(ddlKPICode, ddlRulSetKey.SelectedValue.ToString().Trim(), ddlCatgCode.SelectedValue.ToString().Trim(), "3", "KPI_DESC", "KPI_CODE");
                ddlKPICode.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                txtRate.Text = dsFIllRwd.Tables[0].Rows[0]["RATE"].ToString().Trim();
                ddlCycles.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["CYCLE_CODE"].ToString().Trim();

                VisibleTarget(ddlKPICode.SelectedValue.ToString().Trim());
                ddlmempay.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["RWRD_RELEASE"].ToString().Trim();
                ddlDependKPIRewardFlag.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_ON_KPI_RWD"].ToString().Trim();
                if (dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_ON_KPI_RWD"].ToString().Trim() == "Y")
                {
                    ddlDependKPIRewardFlag_SelectedIndexChanged(null, null);
                   
                  
                   

                    divRewardDependCmp.Visible = true;
                    divDependOnKPI.Visible = true;
                   
                   
                    ddlRDCmpCode.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_RWD_CMPNSTN_CODE"].ToString().Trim();
                    ddlRDCmpCode_SelectedIndexChanged(null, null);
                    ddlRDCnstCode.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_RWD_CNTSTNT_CODE"].ToString().Trim();
                    ddlRDCnstCode_SelectedIndexChanged(null, null);
                    ddlRewardDependRuleSet.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_RWD_RULESET_KEY"].ToString().Trim();
                    ddlRewardDependRuleSet_SelectedIndexChanged(null, null);
                    ddlRewardDependKPI.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["DEPENDENT_RWD_KPI"].ToString().Trim();

                }


                txtTargetFrom.Text = dsFIllRwd.Tables[0].Rows[0]["TRGT_FROM"].ToString().Trim();
                txtTargetTo.Text = dsFIllRwd.Tables[0].Rows[0]["TRGT_TO"].ToString().Trim();
                //ddlReasonforEdit.SelectedValue = dsFIllRwd.Tables[0].Rows[0]["REASONFOREDIT"].ToString().Trim(); commented by Abuzar Siddiqui on 05/08/2020
                ddlRulSetKey_SelectedIndexChanged(null, null);
                


                txtRwdCode.Enabled = false;
                ddlRulSetKey.Enabled = false;
                ddlCatgCode.Enabled = false;
                ddlRwdDesc.Enabled = false;
                ddlCycles.Enabled = false;
                chkCyc.Enabled = false;
                ddlType.Enabled = false; //Added by Abuzar Siddiqui on 05/08/2020
                ddlKPICode.Enabled = false; //Added by Abuzar Siddiqui on 05/08/2020
                ddlRwdType.Enabled = false; //Added by Abuzar Siddiqui on 05/08/2020

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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "FillRwd", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ChkType()
    {
        try { 
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
        if (ddlType.SelectedValue == "1005")
        {
            ddlKPICode.Enabled = true;
            lblKPICode_.Text = "*";
            txtValue.Visible = true;
            lblRate.Visible = false;
            txtRate.Visible = false;
            lnkSetFrml.Visible = false;
        }
        //ended by prity on 1 aug 19 for times unit type

        if (ddlType.SelectedValue == "1006")
        {
            ddlKPICode.Enabled = false;
            txtValue.Visible = true;
            lblRate.Visible = true;
            txtRate.Visible = true;
            lnkSetFrml.Visible = false;
    }

    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "ChkType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlRwdDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRwdDesc.SelectedValue == "")
        {
            txtRwdCode.Text = "";
        }
        else
        {
            txtRwdCode.Text = ddlRwdDesc.SelectedValue;
        }
    }

    #region FillCycles
    protected void FillCycles()
    {
        string acc_cycle = "";
        DataTable dt_acc = new DataTable();
        Hashtable ht_acc = new Hashtable();
        ht_acc.Clear();

        dt_acc.Clear();
      

        ht_acc.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
        ht_acc.Add("@CNTSTN_CODE", Request.QueryString["cntstcd"].ToString().Trim().ToString().Trim());
        ht_acc.Add("@RULE_SET_KEY", ddlRulSetKey.SelectedValue.ToString());

        ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            acc_cycle = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString();
            hdnCount.Value = ds.Tables[0].Rows[0]["COUNT"].ToString().Trim();

        }


        try { 
        DataTable dt = new DataTable();
        dt.Clear();
        dt = Search("C", hdnBusiCode.Value.ToString().Trim(), acc_cycle);
        if (dt.Rows.Count > 0)
        {
            ddlCycles.DataSource = dt;
            ddlCycles.DataValueField = "BUSI_CODE";
            ddlCycles.DataTextField = "SHRT_BUSI_DESC";
            ddlCycles.DataBind();
        }
        ddlCycles.Items.Insert(0, new ListItem("--SELECT--", ""));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "FillCycles", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected DataTable Search(string flag, string yrcode, string cyc)
    {
        DataSet dsSrch = new DataSet();
        try { 
       
        Hashtable htSrch = new Hashtable();
        dsSrch.Clear();
        htSrch.Clear();
        htSrch.Add("@BUSI_CODE", yrcode.ToString().Trim());
        htSrch.Add("@FLAG", flag.ToString().Trim());
        htSrch.Add("@ACC_CYCLE", cyc.ToString().Trim());
        if (Request.QueryString["compcode"] != null)
        {
            htSrch.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
			htSrch.Add("@RULE_SET_KEY", ddlRulSetKey.SelectedValue.ToString());
        }
        dsSrch = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htSrch);
        if (dsSrch.Tables.Count > 0 && dsSrch.Tables[0].Rows.Count > 0)
        {
            return dsSrch.Tables[0];
        }
        }  catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "Search", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    
        return dsSrch.Tables[0];
    }

    public void GetRuleSetKeyDtls()
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            if (Request.QueryString["compcode"] != null)///@CatgCode
            {
                htParam.Add("@cmpcode", Request.QueryString["compcode"].ToString().Trim());
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                htParam.Add("@cntstcode", Request.QueryString["cntstcd"].ToString().Trim());
            }
            if (Request.QueryString["rultyp"] != null)
            {
                htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
            }
            htParam.Add("@flag", "4");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleMstDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlRulSetKey.Items.Clear();

                ddlRulSetKey.DataSource = ds;
                ddlRulSetKey.DataTextField = "RULE_SET_KY_DSC";
                ddlRulSetKey.DataValueField = "RULE_SET_KEY";
                ddlRulSetKey.DataBind();
            }
            ddlRulSetKey.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetRuleSetKeyDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected string GetMaxCode(string flag)
    {
        string code = String.Empty;
        try { 
        
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        htParam.Add("@cmpcode", Request.QueryString["compcode"].ToString().Trim());
        htParam.Add("@cntstcode", Request.QueryString["cntstcd"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            code = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
        }
      

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetMaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        } return code.ToString().Trim();
    }

    protected void btnAddMaster_Click(object sender, EventArgs e)
    {
        try
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
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRule','" + rultyp.ToString().Trim() + "');", true);

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "btnAddMaster_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnKPI_Click(object sender, EventArgs e)
    {
      //  GetRWDMstDtls();
    }
    protected void txtRwdDesc1_TextChanged(object sender, EventArgs e)
    {
        if (txtRwdDesc1.Enabled == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please add reward using add master');", true);
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doOk('" + Request.QueryString["rultyp"].ToString().Trim() + "');", true);

    }
    //Added by prity on 5 nov 2018

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
                hdnRulClass.Value = ds1.Tables[0].Rows[0]["RWD_RUL_CLASS"].ToString().Trim(); 
            }

            if (hdnRulClass.Value == "NS")
            {
                ShowLocDdl();
                LblAgent.Visible = true;
                btnAgtName.Visible = true;
                LblAgentM.Visible = true;
            }
            else {
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
            objErr.LogErr("ISYS-SAIM", "PopRwdRul", "GetRulSetClass", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
  
    //ended on 5 nov 2018
}
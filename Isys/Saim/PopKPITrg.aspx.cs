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

public partial class Application_Isys_Saim_PopKPITrg : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp, chnl, schnl = string.Empty;
    string value = String.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }


            if (!IsPostBack)
            {



                BindGrid();

                ShowRulKPIDtls();
                ShowLocDdl();
                FillCycles();
                ShowMembecycle();
                ShowMemberDdl();
                ShowMember();

                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "strView")
                    {
                        divrwdrulcollapse.Visible = false;
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
            objErr.LogErr("ISYS-SAIM", "PopKPITrg", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            if (Request.QueryString["cmpcode"] != null)
            {
                htSrch.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "PopKPITrg", "DataTable Search", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

        return dsSrch.Tables[0];
    }

    protected void ShowMemberDdl()
    {
        // strACC_YEAR = GetSTRACCYEAR();
       

            //DataSet dsMem = new DataSet();
            //dsMem.Clear();

            //Hashtable HTMem = new Hashtable();
            //HTMem.Clear();


            //HTMem.Add("@CompCode", Request.QueryString["cmpcode"].ToString());
            //HTMem.Add("@CntstCode", Request.QueryString["cntstcode"].ToString().Trim());
            //HTMem.Add("@RuleSetCode", txtRulSetKy.Text.ToString().Trim());
          

            //dsMem = objDal.GetDataSetForPrc_SAIM("Prc_FillMemPerKPI", HTMem);
            //if (dsMem.Tables.Count > 0 && dsMem.Tables[1].Rows.Count > 0)
            //{
        if (Request.QueryString["ruleclass"]!= null)
        {
            if (Request.QueryString["ruleclass"].ToString().Trim() == "NS")
            {
                ShowLocDdl();
                lblMemCode.Visible = true;
                ddlMemCode.Visible = true;

            }
            else
            {

                Label1.Visible = false;
                ddlLocation.Visible = false;


                lblMemCode.Visible = false;
                ddlMemCode.Visible = false;
            }
        }


    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "window.close()", true);
    }



    protected void ddlMemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
            DataSet DsLocation = new DataSet();
            DsLocation.Clear();

            Hashtable HtLocation = new Hashtable();
            HtLocation.Clear();


           // HtLocation.Add("@CompCode", Request.QueryString["cmpcode"].ToString());
            HtLocation.Add("@MemCode", ddlMemCode.SelectedValue.ToString().Trim());
           


            DsLocation = objDal.GetDataSetForPrc_SAIM("Prc_GetMemLocCode", HtLocation);
            if (DsLocation.Tables.Count > 0 && DsLocation.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = DsLocation;
                ddlLocation.DataTextField = "UnitLegalName";
                ddlLocation.DataValueField = "UNitcode";
                ddlLocation.DataBind();
            }
            ddlLocation.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }


    

    protected void ShowRulKPIDtls()
    {
        // strACC_YEAR = GetSTRACCYEAR();



        DataSet dskpi = new DataSet();
        dskpi.Clear();

        Hashtable HTkpi = new Hashtable();
        HTkpi.Clear();


        HTkpi.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());

        HTkpi.Add("@KPI_CODE",  Request.QueryString["kpi"].ToString().Trim());



        dskpi = objDal.GetDataSetForPrc_SAIM("Prc_GetKPITrgDtls", HTkpi);
        if (dskpi.Tables.Count > 0 && dskpi.Tables[0].Rows.Count > 0)
        {
            txtRulSetKy.Text = dskpi.Tables[0].Rows[0]["RuleSetDesc"].ToString();
            
            txtKPICode.Text = dskpi.Tables[1].Rows[0]["KPI_DESC_01"].ToString();

        }

        ddlLocation.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }


    protected void ShowLocDdl()
    {
        // strACC_YEAR = GetSTRACCYEAR();



        DataSet dsLoc = new DataSet();
        dsLoc.Clear();

        Hashtable HtLoc = new Hashtable();
        HtLoc.Clear();


        HtLoc.Add("@CompCode", Request.QueryString["cmpcode"].ToString());
        HtLoc.Add("@CntstCode", Request.QueryString["cntstcode"].ToString().Trim());
          

        dsLoc = objDal.GetDataSetForPrc_SAIM("Prc_DisplayLoc", HtLoc);
        if (dsLoc.Tables.Count > 0 && dsLoc.Tables[0].Rows.Count > 0)
        {
            if (dsLoc.Tables[0].Rows[0]["PRTCPTN_BSD_ON"].ToString() == "MC-LC")
            {
                Label1.Visible = true;
                ddlLocation.Visible = true;
            }

        }

       
    }


    protected void ShowMember()
    {
       // strACC_YEAR = GetSTRACCYEAR();
      
          

            DataSet dsNEWCat = new DataSet();
            dsNEWCat.Clear();

            Hashtable HTCat = new Hashtable();
            HTCat.Clear();


            HTCat.Add("@CompCode", Request.QueryString["cmpcode"].ToString());
            HTCat.Add("@CntstCode", Request.QueryString["cntstcode"].ToString().Trim());
           


            dsNEWCat = objDal.GetDataSetForPrc_SAIM("Prc_FillMemPerKPI", HTCat);
            if (dsNEWCat.Tables.Count > 0 && dsNEWCat.Tables[0].Rows.Count > 0)
            {
                ddlMemCode.DataSource = dsNEWCat;
                ddlMemCode.DataTextField = "MemName";
                ddlMemCode.DataValueField = "MemCode";
                ddlMemCode.DataBind();
            }
            ddlMemCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }

   
protected void ShowMembecycle()
    {
        // strACC_YEAR = GetSTRACCYEAR();
        if (hdnFINYEAR.Value == "1003")
        {
            ddlMemPayCycle.Visible = true;
            lblMemCycle.Visible = true;
            chkCyc.Visible = true;

            DataSet dsNEWCat = new DataSet();
            dsNEWCat.Clear();

            Hashtable HTCat = new Hashtable();
            HTCat.Clear();


          //  HTCat.Add("@LookupCode", "MemCycle");
            HTCat.Add("@CmpstnCode", Request.QueryString["cmpcode"].ToString());
            HTCat.Add("@CntstCode", Request.QueryString["cntstcode"].ToString().Trim());
         //   HTCat.Add("@RuleSetCode", txtRulSetKy.Text.ToString().Trim());

            HTCat.Add("@RuleSetCode", Request.QueryString["ruleset"].ToString().Trim());

            dsNEWCat = objDal.GetDataSetForPrc_SAIM("Prc_GetMemberAccCycle", HTCat);
            if (dsNEWCat.Tables.Count > 0 && dsNEWCat.Tables[0].Rows.Count > 0)
            {
                ddlMemPayCycle.DataSource = dsNEWCat;
                ddlMemPayCycle.DataTextField = "BUSI_DESC";   
                ddlMemPayCycle.DataValueField = "BUSI_CODE";
                ddlMemPayCycle.DataBind();
            }
            ddlMemPayCycle.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }

    }

  
    protected void btnpre_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = KPITrgt.PageIndex;
            KPITrgt.PageIndex = pageIndex - 1;
          //  GetPageDtls();
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
            BindGrid();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKPITrg", "btnpre_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {


            int pageIndex = KPITrgt.PageIndex;
            KPITrgt.PageIndex = pageIndex + 1;
            //GetPageDtls();
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) + 1);
            btnpre.Enabled = true;
            if (txtpage.Text == Convert.ToString(KPITrgt.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = KPITrgt.PageCount;
            BindGrid();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKPITrg", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid()
    {

        ds.Clear();
        htParam.Clear();
        // string msgs;

        htParam.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim().ToString().Trim());

      //  htParam.Add("@CYCLE", ddlCycle.SelectedValue.ToString().Trim());
        htParam.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());

        htParam.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
       // htParam.Add("@MEM_CODE", ddlMemCode.SelectedValue.ToString().Trim());


        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetKPIPerTrg", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            KPITrgt.DataSource = ds;
            KPITrgt.DataBind();
        }
    }


    protected void btnAddTrg_Click(object sender, EventArgs e)
    {

        ds.Clear();
        htParam.Clear();
       // string msgs;

        htParam.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcode"].ToString().Trim().ToString().Trim());

        htParam.Add("@CYCLE", ddlCycle.SelectedValue.ToString().Trim());
        htParam.Add("@RULE_SET_KEY",  Request.QueryString["ruleset"].ToString().Trim());

        htParam.Add("@KPI_CODE", Request.QueryString["kpi"].ToString().Trim());
        htParam.Add("@MEM_CODE", ddlMemCode.SelectedValue.ToString().Trim());
        
        htParam.Add("@MEMBER_CYCLE", ddlMemPayCycle.SelectedValue.ToString().Trim());
        htParam.Add("@KPI_TRGT_FROM", txtTrg.Text.ToString().Trim());
        htParam.Add("@KPI_TRGT_TO", txtTrg.Text.ToString().Trim());
        htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
        htParam.Add("@UPDATEDBY", Session["UserID"].ToString().Trim());
        htParam.Add("@MEM_UNT_CODE", ddlLocation.SelectedValue.ToString().Trim());

      
        if (chkCyc.Checked==true)
        {
            htParam.Add("@chkCyc","1");
        }
        else 
        {
            htParam.Add("@chkCyc", "0");
        }


        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsKPIPerTrg", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["msg"].ToString().Trim()=="success")
            {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved successfully');", true);
			  BindGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Already Exists');", true);
            }
           
        }
    }

    protected void FillCycles()
    {
        string acc_cycle = "";
        DataTable dt_acc = new DataTable();
        Hashtable ht_acc = new Hashtable();
        ht_acc.Clear();

        dt_acc.Clear();
        
        try
        {
            ht_acc.Add("@CMPNSTN_CODE", Request.QueryString["cmpcode"].ToString().Trim());
            ht_acc.Add("@CNTSTN_CODE", Request.QueryString["cntstcode"].ToString().Trim().ToString().Trim());
            ht_acc.Add("@RULE_SET_KEY", Request.QueryString["ruleset"].ToString().Trim());


            ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                acc_cycle = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString();

                hdnCount.Value = ds.Tables[0].Rows[0]["COUNT"].ToString().Trim();
                hdnBusiCode.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
                hdnFINYEAR.Value = ds.Tables[1].Rows[0]["ACC_YEAR"].ToString().Trim();

            }

                  DataTable dt = new DataTable();
                dt.Clear();
                dt = Search("C", hdnBusiCode.Value.ToString().Trim(), acc_cycle);
                if (dt.Rows.Count > 0)
                {
            
                ddlCycle.DataSource = dt;
                ddlCycle.DataValueField = "BUSI_CODE";
                ddlCycle.DataTextField = "SHRT_BUSI_DESC";
                ddlCycle.DataBind();
            }
            ddlCycle.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopKPITrg", "FillCycles", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
	
	
	}
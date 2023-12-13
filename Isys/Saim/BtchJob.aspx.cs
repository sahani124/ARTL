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
using System.IO;
using System.Net;


public partial class Application_ISys_Saim_BtchJob : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    DataTable dtResult = new DataTable();
    ErrLog objErr = new ErrLog();
    string msg = string.Empty;
    string compansation, cycleCode, filename, AccumulationCode;
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

            tmr.Enabled = false;

                InsCycDetails();
                
            FillCmp();

              
               // InsCycDetails();

            FillCycDtls();
            //lbtFinalClose.Enabled = false;
                bindKPIgrid();
            //ChkFinalClose_CheckedChanged(null,null);
            //chkAccumulationClose_CheckedChanged(null,null);

            lnkPR.Attributes.Add("onclick", "javascript:openInWindow(" + hdnCycCode.Value + ",'P'," + Request.QueryString["CmpCode"].ToString() + ")");
            // lnkCommission.Attributes.Add("onclick", "javascript:openInWindow(" + hdnCycCode.Value + ",'R')");
            lnkWeight.Attributes.Add("onclick", "javascript:openInWindow(" + hdnCycCode.Value + ",'W'," + Request.QueryString["CmpCode"].ToString() + ")");
            lnkAchieve.Attributes.Add("onclick", "javascript:openInWindow(" + hdnCycCode.Value + ",'A'," + Request.QueryString["CmpCode"].ToString() + ")");
            lnkCommission.Attributes.Add("onclick", "javascript:openInWindow(" + hdnCycCode.Value + ",'R'," + Request.QueryString["CmpCode"].ToString() + ")");
        }

        CheckRwdCal();
        CheckAccClose();

     

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillCmp()//////Compensation Details
    {
        try
        {
            htParam.Clear();
            ds.Clear();
                

        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
                htParam.Add("@CNTSTNT_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
                htParam.Add("@RuleSetCode", Request.QueryString["RuleSetKy"].ToString().Trim());
        }
            ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch_NEW", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblCompCodeVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
            lblCompDesc1Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
            lblCompDesc2Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
            lblAccCycVal.Text = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString().Trim();
            lblAccYrVal.Text = ds.Tables[0].Rows[0]["ACC_YEAR"].ToString().Trim();
            lblCompTypVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString().Trim();
            lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
            lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
            lblAccCycleValue.Text = ds.Tables[0].Rows[0]["ACCURAL_CYCLE_DESC"].ToString().Trim();
            lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE_DESC"].ToString().Trim();
            lblBusYr.Text = ds.Tables[0].Rows[0]["BUSI_DESC"].ToString().Trim();
            lblVersion.Text = ds.Tables[0].Rows[0]["VERSION"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FillCmp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void InsCycDetails()/////Previous/Current Batch Job Details
    {
        try
        {
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
               htParam.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
                htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
        }
        htParam.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpBtchJbCyc_new", htParam);

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "InsCycDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FilldgBatch(string cyccode, GridView grd, string flag)
    {
        try
        {
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Clear();
        dsBtch.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htBtch.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        htBtch.Add("@CYCLE_CODE", cyccode.ToString().Trim());
        htBtch.Add("@FLAG", flag.Trim());
        dsBtch = objDal.GetDataSetForPrc_SAIM("Prc_GetCMPDtlsBtch", htBtch);
        if (dsBtch.Tables.Count > 0 && dsBtch.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = dsBtch;
            grd.DataBind();
        }
        else
        {
            ShowNoResultFound(dsBtch.Tables[0], grd);
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FilldgBatch", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        try
        {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No sub contests to be processed";
        source.Rows.Clear();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

  protected void lnkComputeReward_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htCom = new Hashtable();
            DataSet dsCom = new DataSet();
            htCom.Clear();
            dsCom.Clear();
            
	
	
            htCom.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                         
            htCom.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htCom.Add("@RULE_SET_KEY ", Request.QueryString["RuleSetKy"].ToString().Trim());
            htCom.Add("@ACCR_CYCLE ", hdnCycCode.Value.ToString().Trim());
            htCom.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            dsCom = objDal.GetDataSetForPrc_SAIM("PRC_PROCESS_CATEGORY", htCom);

            
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Reward Computed Successfully')", true);

             htCom.Clear();
            dsCom.Clear();

            htCom.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());

            htCom.Add("@CNTSTNT_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htCom.Add("@RULE_SET_KEY ", Request.QueryString["RuleSetKy"].ToString().Trim());
            htCom.Add("@ACCR_CYCLE ", hdnCycCode.Value.ToString().Trim());
            htCom.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
           

            dsCom = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGRWD", htCom);
    
            
        }
       catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkComputeReward_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
  }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        try
        {
        btnStart.Enabled = false;

           // InsCmpBtch();
        FillCycDtls();

            Hashtable htstart = new Hashtable();
            DataSet dsStart = new DataSet();
            htstart.Clear();
            dsStart.Clear();

            htstart.Add("@CMPNSTN_CODE",Request.QueryString["CmpCode"].ToString().Trim());

            htstart.Add("@CNTSTN_CODE",Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htstart.Add("@RULE_SET_KEY",Request.QueryString["RuleSetKy"].ToString().Trim());
            htstart.Add("@ACCR_CYCLE", hdnCycCode.Value.ToString().Trim());
            htstart.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString().Trim());
            dsStart = objDal.GetDataSetForPrc_SAIM("Prc_StartBTCHCycle", htstart);
            

           // FillBtchSeq();
         //   FilldgBatch(hdnCycCode.Value.ToString().Trim(), dgBatch, "1");
           // FilldgBatch(hdnCycCode.Value.ToString().Trim(), dgTax, "7");
            //FillSummRprt();

        Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                       + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&CNTSTNT_CODE=" + Request.QueryString["CNTSTNT_CODE"].ToString().Trim()
 + "&RuleSetKy=" + Request.QueryString["RuleSetKy"].ToString().Trim(), true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "btnStart_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompStpSrch.aspx?Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
    }
   




    protected void InsCmpBtch()
    {
        try
        {
        htParam = new Hashtable();
        ds = new DataSet();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        htParam.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        htParam.Add("@CYCLE_DESC", hdnCycDesc.Value.ToString().Trim());
        htParam.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InscmpSBCNTKPI", htParam);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "InsCmpBtch", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCmpCodeDsc = (HiddenField)gvRow.FindControl("hdnCmpCodeDsc");
        HiddenField hdnCntstCode = (HiddenField)gvRow.FindControl("hdnCntstCode");
        HiddenField hdnRlStKy = (HiddenField)gvRow.FindControl("hdnRlStKy");
        HiddenField hdnCmpFlag = (HiddenField)gvRow.FindControl("hdnCmpFlag");
        Label lblRlStKyDsc = (Label)gvRow.FindControl("lblRlStKyDsc");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopup('" + hdnCmpCodeDsc.Value.ToString().Trim() + "','"
                    + hdnCntstCode.Value.ToString().Trim() + "','" + hdnRlStKy.Value.ToString().Trim() + "','"
                    + hdnCycCode.Value.ToString().Trim() + "','" + hdnCycDesc.Value.ToString().Trim() + "','" + lblRlStKyDsc.Text.ToString().Trim() + "','"
                    + hdnCmpFlag.Value.ToString().Trim() + "','R');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkView_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkViewPrev_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCmpCodeDsc = (HiddenField)gvRow.FindControl("hdnCmpCodeDsc");
        HiddenField hdnCntstCode = (HiddenField)gvRow.FindControl("hdnCntstCode");
        HiddenField hdnRlStKy = (HiddenField)gvRow.FindControl("hdnRlStKy");
        HiddenField hdnCmpFlag = (HiddenField)gvRow.FindControl("hdnCmpFlag");
        Label lblRlStKyDsc = (Label)gvRow.FindControl("lblRlStKyDsc");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopup('" + hdnCmpCodeDsc.Value.ToString().Trim() + "','"
                    + hdnCntstCode.Value.ToString().Trim() + "','" + hdnRlStKy.Value.ToString().Trim() + "','"
                    + hdnCycCodePrv.Value.ToString().Trim() + "','" + hdnCycDescPrv.Value.ToString().Trim() + "','" + lblRlStKyDsc.Text.ToString().Trim() + "','" + hdnCmpFlag.Value.ToString().Trim() + "');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkViewPrev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillCycDtls()
    {
        try
        {
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Clear();
        dsBtch.Clear();
        string rnstatus = string.Empty;
        if (Request.QueryString["CmpCode"] != null)
        {
            htBtch.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                htBtch.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
                htBtch.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
        }
        htBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            dsBtch = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpBtchJbCyc_new", htBtch);
        if (dsBtch.Tables.Count > 0)
        {
            if (dsBtch.Tables[0].Rows.Count > 0)//////current cycle batch details
            {
                divCurHdr.Visible = true;
                divBtchHdr.Visible = true;
                txtStrTm.Text = dsBtch.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
                txtEndTm.Text = dsBtch.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
                lbCurRnNoVal.Text = dsBtch.Tables[0].Rows[0]["RUN_NO"].ToString().Trim();
                lbCurRnStVal.Text = dsBtch.Tables[0].Rows[0]["RUN_STATUS"].ToString().Trim();
                rnstatus = dsBtch.Tables[0].Rows[0]["RUN_STAT_CD"].ToString().Trim();
                hdnCycCode.Value = dsBtch.Tables[0].Rows[0]["CYCLE_CODE"].ToString().Trim();
                hdnCycDesc.Value = dsBtch.Tables[0].Rows[0]["CYCLE_DESC"].ToString().Trim();
            }
            else
            {
                divCurHdr.Visible = false;
                divBtchHdr.Visible = false;
            }
            if (dsBtch.Tables[1].Rows.Count > 0)//////previous cycle batch details
            {
                divPrevHdr.Visible = true;
                   // divprevdtlshdr.Visible = true;
                txtPrvCycDt1.Text = dsBtch.Tables[1].Rows[0]["EFF_FROM"].ToString().Trim();
                txtPrvCycDt2.Text = dsBtch.Tables[1].Rows[0]["EFF_TO"].ToString().Trim();
                txtRunNo.Text = dsBtch.Tables[1].Rows[0]["RUN_NO"].ToString().Trim();
                txtRunStat.Text = dsBtch.Tables[1].Rows[0]["RUN_STATUS"].ToString().Trim();
                hdnCycCodePrv.Value = dsBtch.Tables[1].Rows[0]["CYCLE_CODE"].ToString().Trim();
                hdnCycDescPrv.Value = dsBtch.Tables[1].Rows[0]["CYCLE_DESC"].ToString().Trim();
                   // FilldgBatch(hdnCycCodePrv.Value.ToString().Trim(), dgBatchPrev, "1");//rule set changes not done
            }
            else
            {
                divPrevHdr.Visible = false;
                   // divprevdtlshdr.Visible = false;
            }
        }
        if (rnstatus == "P" || rnstatus == "F")/////check cycle in Processing status and Failed Status
        {
               
                btnStart.Visible = false;
               // divBtch.Visible = true;
                //FillSbBtch();  // New PopBatch.aspx
                //FilldgBatch(hdnCycCode.Value.ToString().Trim(), dgBatch, "1");
                //divTax.Visible = true;
                //FilldgBatch(hdnCycCode.Value.ToString().Trim(), dgTax, "7");
                //divSum.Visible = true;
                //FillSummRprt();
                //btnStart.Enabled = false;

        }
        else
        {
            divBtch.Visible = false;
            divTax.Visible = false;
            divSum.Visible = false;
            btnStart.Enabled = true;

                btnStart.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FillCycDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void chkAccumulationClose_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
        if (chkAccumulationClose.Checked)
            lnkAccumulationClose.Enabled = true;
        else
            lnkAccumulationClose.Enabled = false;
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "chkAccumulationClose_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void chkInterim_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkInterim.Checked)
                lnkInterimSet.Enabled = true;
            else
                lnkInterimSet.Enabled = false;        
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "chkInterim_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void bindKPIgrid()
    {

        try
        {
           
            Hashtable htkpi = new Hashtable();
            DataSet dsKpi = new DataSet();
            htkpi.Clear();
            dsKpi.Clear();
           
            if (Request.QueryString["CmpCode"] != null)
            {
                htkpi.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                htkpi.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
                htkpi.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
                htkpi.Add("@ACCR_CYCLE", hdnCycCode.Value.ToString().Trim());

            }
            dsKpi = objDal.GetDataSetForPrc_SAIM("PrcGetKPIDetails", htkpi);
          
            gvKPI.DataSource = dsKpi.Tables[0];

            gvKPI.DataBind();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "bindKPIgrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }



    protected void ChkFinalClose_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
        if (ChkFinalClose.Checked)
            lbtFinalClose.Enabled = true;
        else
            lbtFinalClose.Enabled = false;
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "ChkFinalClose_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkInterimSet_Click(object sender, EventArgs e)
    {
        
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
       
        
        //HiddenField hdnCmpFlag = (HiddenField)gvRow.FindControl("hdnCmpFlag");
        //HiddenField hdnRulType = (HiddenField)gvRow.FindControl("hdnRulType");
        //Label lblRlStKyDsc = (Label)gvRow.FindControl("lblRlStKyDsc");


        //hdnCmpFlag.Value = hdnCmpFlag.Value.Substring(0, 1);
        //hdnRulType.Value = hdnRulType.Value.Substring(0, 1);
        //hdnRSK.Value = hdnRSK.Value.Substring(0, 8);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupInterim('" + lblCompCodeVal.Text.ToString().Trim() + "','"
                 + Request.QueryString["CNTSTNT_CODE"].ToString().Trim() + "','" + Request.QueryString["RuleSetKy"].ToString().Trim() + "','"
                 + hdnCycCode.Value.ToString().Trim() + "');", true);

           //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupInterimtemp();",true );
   
    }

    protected void btnbtch_Click(object sender, EventArgs e)
    {
        FillCycDtls();
        /////InsCmpBtch();
        //FillSbBtch();
        //FilldgBatch(hdnCycCodePrv.Value.ToString().Trim(), dgBatchPrev, "1");
        //FilldgBatch(hdnCycCode.Value.ToString().Trim(), dgBatch, "1");
    }

    //added by ajay sawant -- accrual cycle closed
    protected void lbtFinalClose_Click(object sender, EventArgs e)
    {
        try
        {

        CheckACCCloseArrive();

        Hashtable htFinal = new Hashtable();
        DataSet dsFinal = new DataSet();

        htFinal.Clear();
        dsFinal.Clear();
        
        htFinal.Add("@CMPN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htFinal.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
            htFinal.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htFinal.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());


        dsFinal = objDal.GetDataSetForPrc_SAIM("Prc_UpdateFinalCycleClose", htFinal);
        if (dsFinal.Tables.Count > 0)
        {
            if (dsFinal.Tables[0].Rows.Count > 0)
            {
                    

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Accrual Cycle Closed Successfully')", true);
                Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                      + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim()+ "&CNTSTNT_CODE="+Request.QueryString["CNTSTNT_CODE"].ToString().Trim()+ "&RuleSetKy="+Request.QueryString["RuleSetKy"].ToString().Trim(), true);
                }
            }

        }
        catch (Exception ex)
    {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lbtFinalClose_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    // added by ajay sawant for download acgivement data


    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        try
        {

           

               // LbtVerifyData_Click(sender,e);

        Hashtable htVerify = new Hashtable();
        DataSet dsVerify = new DataSet();
            DataTable dtDownload = new DataTable();

        htVerify.Clear();
        dsVerify.Clear();


            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblkpicode = (Label)gvRow.FindControl("lblKPIcode");
            Label lblKPIDsc = (Label)gvRow.FindControl("lblKPIDsc"); 
        htVerify.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htVerify.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htVerify.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString());
            htVerify.Add("@KPI_CODE", lblkpicode.Text.ToString());
            htVerify.Add("@ACCR_CYCLE ", hdnCycCode.Value.ToString().Trim());

            filename = lblKPIDsc.Text.ToString(); 
            dsVerify = objDal.GetDataSetForPrc_SAIM("Prc_GET_ACCR_ACH_DATA", htVerify);
            dtDownload = dsVerify.Tables[0];//Added by prity
        if (dsVerify.Tables.Count > 0)
        {
            if (dsVerify.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Verified  Successfully')", true);

                 
                   
                    ExportCSV(dtDownload, filename);//Added by prity
                //Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                //  + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
            }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Not Existed')", true);

        }
            }

    }
        catch (Exception ex)
    {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkDownload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //added by ajay sawant--- accrual cycle data verification
    protected void LbtVerifyData_Click(object sender, EventArgs e)
    {
        try
        {

        Hashtable htVerify = new Hashtable();
        DataSet dsVerify = new DataSet();

        htVerify.Clear();
        dsVerify.Clear();
            filename = "";
       
        htVerify.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htVerify.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
            htVerify.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
	 htVerify.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
           
            
       
        compansation = lblCompCodeVal.Text.ToString().Trim();
        cycleCode=hdnCycCode.Value.ToString().Trim();
           filename = compansation + cycleCode;

        dsVerify = objDal.GetDataSetForPrc_SAIM("PRC_GET_verify_accrual_data", htVerify);
            dtResult = dsVerify.Tables[0];//Added by prity
        if (dsVerify.Tables.Count > 0)
            {
                if (dsVerify.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Verified  Successfully')", true);

                 
                    ExportCSV(dtResult, filename);//Added by prity
                    //Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                    //  + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Not Existed')", true);

                }

            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "LbtVerifyData_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    private void BindGrid()
    {
        try
        {
            Hashtable htVerify = new Hashtable();
            DataSet dsVerify = new DataSet();

            htVerify.Clear();
            dsVerify.Clear();

            htVerify.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htVerify.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());

            compansation = lblCompCodeVal.Text.ToString().Trim();
            cycleCode = hdnCycCode.Value.ToString().Trim();
            filename = compansation + cycleCode;

            dsVerify = objDal.GetDataSetForPrc_SAIM("PRC_GET_verify_accrual_data", htVerify);
            if (dsVerify.Tables.Count > 0)
        {
            if (dsVerify.Tables[0].Rows.Count > 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Verified  Successfully')", true);

                dgAccrualExport.DataSource = dsVerify;
                dgAccrualExport.DataBind();
               
            }
        }
        }

        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
       
    }
    private void BindGridAccumulation()
    {
        try
        {
        Hashtable htVerify = new Hashtable();
        DataSet dsVerify = new DataSet();

        htVerify.Clear();
        dsVerify.Clear();
        
        htVerify.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htVerify.Add("@CNTSTNT_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htVerify.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());


        filename = lblCompCodeVal.Text.ToString().Trim();
        filename = filename + AccumulationCode;
       

           dsVerify = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACC_FINAL_DATA", htVerify);
        if (dsVerify.Tables.Count > 0)
        {
        
            if (dsVerify.Tables[0].Rows.Count > 0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Verified  Successfully')", true);

                dgAccumulationExport.DataSource = dsVerify;
                dgAccumulationExport.DataBind();

            }
        }


    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "BindGridAccumulation", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    private void exportfile(GridView grd,string filename)
    {
        try
        {
        Response.Clear();
        Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".csv");
        Response.Charset = "";
           // Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/text"; 
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            grd.AllowPaging = false;

          //  LbtVerifyData_Click(null,null);
           // BindGrid();

            grd.RenderControl(hw);

            //style to format numbers to string
               // string style = @"<style> .textmode { } </style>";
              //  Response.Write();
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "exportfile", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    //Added by prity
    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "BtchJob", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
        return Rest;


    }
    //Ended by prity
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    //added by ajay sawant--- accrual cycle data verification
    protected void LbtAccVerifyData_Click(object sender, EventArgs e)
    {
        try
        {
        filename = "";

        Hashtable htVerify = new Hashtable();
        DataSet dsVerify = new DataSet();

        htVerify.Clear();
        dsVerify.Clear();

        htVerify.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
       // htVerify.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());

            htVerify.Add("@CNTSTNT_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htVerify.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
       
        dsVerify = objDal.GetDataSetForPrc_SAIM("PRC_GET_ACC_FINAL_DATA", htVerify);
            dtResult = dsVerify.Tables[0];//Added by prity
        if (dsVerify.Tables.Count > 0)
        {
            if (dsVerify.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Accumulation Cycle Data Verified  Successfully')", true);
                //Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
            
                //  + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
                   // BindGridAccumulation();
                    //exportfile(dgAccumulationExport, filename);
                    ExportCSV(dtResult, filename);//Added by prity
                }
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", " LbtAccVerifyData_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    private void CheckACCCloseArrive()
    {
        try
        {
        Hashtable htCheck = new Hashtable();
        DataSet dsCheck = new DataSet();

        dsCheck.Clear();
        htCheck.Clear();

        htCheck.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htCheck.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
            htCheck.Add("@CNTSTNT_CODE",Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htCheck.Add("@RULE_SET_KEY",Request.QueryString["RuleSetKy"].ToString().Trim());
       


        dsCheck = objDal.GetDataSetForPrc_SAIM("PRCCheckACCCycleCLose", htCheck);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "CheckACCCloseArrive", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void lnkAccumulationClose_Click(object sender, EventArgs e)
    {

        try
        {
        Hashtable htAccumulation = new Hashtable();
        DataSet dsAccumulation = new DataSet();
        htAccumulation.Clear();
        dsAccumulation.Clear();
        htAccumulation.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
       // htAccumulation.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        htAccumulation.Add("CREATED_BY",Session["UserID"].ToString().Trim());
            htAccumulation.Add("@CNTSTNT_CODE",Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htAccumulation.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
        dsAccumulation = objDal.GetDataSetForPrc_SAIM("PrcInsCMP_MEM_COMM_STT", htAccumulation);
        if (dsAccumulation.Tables.Count > 0)
        {
            if (dsAccumulation.Tables[0].Rows[0]["status"].ToString()=="S")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Cycle Closed Successfully')", true);
                Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                      + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim()+"&CNTSTNT_CODE="+Request.QueryString["CNTSTNT_CODE"].ToString().Trim()+"&RuleSetKy="+Request.QueryString["RuleSetKy"].ToString().Trim(), true);
            
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Contact to SAIM support team')", true);
            }
        }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkAccumulationClose_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgBatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnCmpCodeDsc = (HiddenField)e.Row.FindControl("hdnCmpCodeDsc");
            HiddenField hdnCntstCode = (HiddenField)e.Row.FindControl("hdnCntstCode");
            HiddenField hdnRlStKy = (HiddenField)e.Row.FindControl("hdnRlStKy");
            HiddenField hdnCmpFlag = (HiddenField)e.Row.FindControl("hdnCmpFlag");
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");

            Hashtable ht = new Hashtable();
            DataSet ds = new DataSet();
            ht.Clear();
            ds.Clear();
            ht.Add("@CMPNSTN_CODE", hdnCmpCodeDsc.Value.ToString().Trim());
            ht.Add("@CNTSTN_CODE", hdnCntstCode.Value.ToString().Trim());
            ht.Add("@RULE_SET_KEY", hdnRlStKy.Value.ToString().Trim());
            ht.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
            ht.Add("@COMPUTE_FLAG", hdnCmpFlag.Value.ToString().Trim());
            ht.Add("@FLAG", "4");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCMPDtlsBtch", ht);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgSubRSK.DataSource = ds;
                dgSubRSK.DataBind();
                dgSubRSK.Columns[3].Visible = true;
                lnkView.Enabled = false;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dgSubRSK.DataSource = ds.Tables[0];
                dgSubRSK.DataBind();
                int columnsCount = dgSubRSK.Columns.Count;
                int rowsCount = dgSubRSK.Rows.Count;
                dgSubRSK.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                dgSubRSK.Rows[0].Cells[columnsCount - 1].Text = "";
                dgSubRSK.Rows[0].Cells[columnsCount - 2].Text = "";
                dgSubRSK.Rows[0].Cells[0].Text = "No rule types have been defined";
                ds.Tables[0].Rows.Clear();
                lnkView.Enabled = true;
                dgSubRSK.Columns[3].Visible = false;
                //////ShowNoResultFound(ds.Tables[0], dgSubRSK);
            }
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "dgBatch_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void gvKPI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnHybrid = (HiddenField)e.Row.FindControl("hdnHybrid");
                LinkButton lnkUpload = (LinkButton)e.Row.FindControl("lnkUpload");

                if (hdnStaus.Value.ToString() == "P")
                {
                    if (hdnHybrid.Value.ToString() == "1003")
                    {
                        lnkUpload.Visible = true;
                    }
                   // lnkRunKPI.Text = "RUN";
                }

                if(hdnStaus.Value.ToString()=="C")
                {
                    lnkUpload.Visible = false;
                    
                   
                   // lblStatus.Visible = true;
                    imgStatus.Visible = true ;
                   
                    lnkRunKPI.Visible = true;
                   // lblStatus.Text = "Completed";
                    lnkRunKPI.Text = "RE-RUN";
                }
             
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "gvKPI_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkViewRSK_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCmpCodeDsc = (HiddenField)gvRow.FindControl("hdnCmpCodeDsc");
        HiddenField hdnCntstCode = (HiddenField)gvRow.FindControl("hdnCntstCode");
        HiddenField hdnRSK = (HiddenField)gvRow.FindControl("hdnRSK");
        Label lblRSK = (Label)gvRow.FindControl("lblRSK");
        HiddenField hdnCmpFlag = (HiddenField)gvRow.FindControl("hdnCmpFlag");
        HiddenField hdnRulType = (HiddenField)gvRow.FindControl("hdnRulType");
        Label lblRlStKyDsc = (Label)gvRow.FindControl("lblRlStKyDsc");
        hdnCmpCodeDsc.Value = hdnCmpCodeDsc.Value.Substring(0, 8);
        hdnCntstCode.Value = hdnCntstCode.Value.Substring(0, 8);
        hdnCmpFlag.Value = hdnCmpFlag.Value.Substring(0, 1);
        hdnRulType.Value = hdnRulType.Value.Substring(0, 1);
        hdnRSK.Value = hdnRSK.Value.Substring(0, 8);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopup('" + lblCompCodeVal.Text.ToString().Trim() + "','"
                    + hdnCntstCode.Value.ToString().Trim() + "','" + hdnRSK.Value.ToString().Trim() + "','"
                    + hdnCycCode.Value.ToString().Trim() + "','" + hdnCycDesc.Value.ToString().Trim() + "','" + lblRSK.Text.ToString().Trim()
                    + "','" + hdnCmpFlag.Value.ToString().Trim() + "','" + hdnRulType.Value.ToString().Trim() + "');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkViewRSK_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillSbBtch()
    {
        try
        {
        DataSet dssbBtch = new DataSet();
        Hashtable htsbBtch = new Hashtable();
        htsbBtch.Clear();
        dssbBtch.Clear();
        htsbBtch.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htsbBtch.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        htsbBtch.Add("@COMPUTE_FLAG", "");
        htsbBtch.Add("@FLAG", "6");
        dssbBtch = objDal.GetDataSetForPrc_SAIM("Prc_GetCMPDtlsBtch", htsbBtch);
        if (dssbBtch.Tables.Count > 0 && dssbBtch.Tables[0].Rows.Count > 0)
        {
            div1.Visible = true;
            dgSbBtch.DataSource = dssbBtch;
            dgSbBtch.DataBind();
        }
        else
        {
            div1.Visible = false;
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FillSbBtch", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //protected void dgSbBtch_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
    //        HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
    //        Image imgStatus = (Image)e.Row.FindControl("imgStatus");
    //        LinkButton lnkStart = (LinkButton)e.Row.FindControl("lnkStart");


    //        lnkStart.Visible = true;

    //        //if (tmr.Enabled == true)
    //        //{
    //        if (hdnStatus.Value == "C")
    //        {
    //            lnkStart.Visible = false;
    //            lblStatus.Text = "Completed";
    //            lblStatus.ForeColor = System.Drawing.Color.Green;
    //            imgStatus.ImageUrl = "../../../images/tick_ok.png";
    //            imgStatus.Visible = true;
    //            tmr.Enabled = false;
    //        }
    //        else if (hdnStatus.Value == "F")
    //        {
    //            lnkStart.Visible = false;
    //            lnkStart.Text = "Failed/Rerun";
    //            lnkStart.ForeColor = System.Drawing.Color.Red;
    //            imgStatus.ImageUrl = "../../../images/close.gif";
    //            imgStatus.Visible = true;
    //            lblStatus.Visible = false;
    //            tmr.Enabled = false;
    //        }
    //        else if (hdnStatus.Value == "P")
    //        {
    //            lnkStart.Visible = false;
    //            lblStatus.Text = "Awaiting Execution";
    //            imgStatus.ImageUrl = "../../../images/spinner.gif";
    //        }
    //        else
    //        {
    //            lnkStart.Text = "Start";
    //            lnkStart.Visible = true;
    //            lblStatus.Visible = false;
    //            imgStatus.Visible = false;
    //        }
    //    }
    //}

    protected void dgSbBtch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            LinkButton lnkStart = (LinkButton)e.Row.FindControl("lnkStart");

            lblStatus.ForeColor = System.Drawing.Color.WhiteSmoke;

            lnkStart.Visible = true;

            //if (tmr.Enabled == true)
            //{
            if (hdnStatus.Value == "C")
            {
                lnkStart.Visible = false;
                lblStatus.Text = "Completed";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                imgStatus.ImageUrl = "../../../images/tick_ok.png";
                imgStatus.Visible = true;
                lblStatus.Attributes.Add("display", "block");

                tmr.Enabled = false;
            }
            else if (hdnStatus.Value == "F")
            {
                lnkStart.Visible = false;
                lnkStart.Text = "Failed/Rerun";
                lnkStart.ForeColor = System.Drawing.Color.Red;
                imgStatus.ImageUrl = "../../../images/close.gif";
                imgStatus.Visible = true;
                lblStatus.Visible = false;
                tmr.Enabled = false;
                lblStatus.Attributes.Add("display", "block");
            }
            else if (hdnStatus.Value == "P")
            {
                lnkStart.Visible = false;
                lblStatus.Text = "Awaiting Execution";
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
            else
            {
                lnkStart.Text = "Start";
                lnkStart.Visible = true;
                //lblStatus.Visible = false;
                //imgStatus.Visible = false;
            }
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "dgSbBtch_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void CheckAccClose()
    {
        try
        {
        Hashtable htAcc = new Hashtable();
        DataSet dsAcc = new DataSet();
        htAcc.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htAcc.Add("@CNTSTNT_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htAcc.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
       

        dsAcc = objDal.GetDataSetForPrc_SAIM("Prc_GetCYC_BTJ_ACC_CLOSE", htAcc);

        if (dsAcc.Tables.Count > 0)
        {
            if (dsAcc.Tables[0].Rows.Count > 0)
            {
              if (dsAcc.Tables[0].Rows[0]["STATUS"].ToString()== "")
              {
                    AccumulationCode=dsAcc.Tables[0].Rows[0]["STATUS"].ToString();

                  divAccumulation.Attributes.Add("style","display:block;width:97%");
                  btnStart.Enabled = false;
                  div18.Attributes.Add("style", "display : none");
                 // divAccumulation.Style.Add("display", "none");
              }
              else
              {
                divAccumulation.Attributes.Add("style", "display : none");
                  btnStart.Enabled = true;
                  div18.Attributes.Add("style", "display : block;width:97%");
              }

            }
           // divAccumulation.Attributes.Add("style", "display : none");

        }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "CheckAccClose", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void CheckRwdCal()
    {
        try
        {
            Hashtable htRwd = new Hashtable();
            DataSet dsRwd = new DataSet();

            htRwd.Add("@RuleSetCode", Request.QueryString["RuleSetKy"].ToString().Trim());


            dsRwd = objDal.GetDataSetForPrc_SAIM("Prc_getRwdCal", htRwd);

            if (dsRwd.Tables.Count > 0)
            {
                if (dsRwd.Tables[0].Rows.Count > 0)
                {
                    if (dsRwd.Tables[0].Rows[0]["flag"].ToString() == "success")
                    {

                        lnkComputeReward.Visible = false;
                        lblVerifyData.Visible = false;
                        LbtVerifyData.Visible = false;
                        //divAccumulation.Attributes.Add("style", "display:block;width:97%");
                       
                    }
                    else
                    {
                       
                    }

                }
                // divAccumulation.Attributes.Add("style", "display : none");

            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "CheckRwdCal", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkUpload_Click(object sender, EventArgs e)
    {

        try
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupDataSynchHybrid('" + lblCompCodeVal.Text.ToString().Trim() + "','" + Request.QueryString["CNTSTNT_CODE"].ToString().Trim() + "','" + Request.QueryString["RuleSetKy"].ToString().Trim() + "','" + hdnCycCode.Value.ToString().Trim() + "');", true);
         
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkUpload_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkRunKPI_Click(object sender, EventArgs e)
    {

        try
        {
            
            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkRun = (LinkButton)gvRow.FindControl("lnkRunKPI");
            Image imgStatus = (Image)gvRow.FindControl("imgStatus");
            Label lblStatus = (Label)gvRow.FindControl("lblStatus");
            lnkRun.Visible = false;
            lblStatus.Attributes.Add("display", "block");
            
            imgStatus.Visible = true;
           imgStatus.ImageUrl = "../../../images/spinner.gif";
          //  lblStatus.Visible = true;
          //  lblStatus.Text = "Completed";

            
            Hashtable htRunKpi = new Hashtable();
            DataSet dsRunKpi = new DataSet();
            htRunKpi.Clear();
            dsRunKpi.Clear();

           
            Label lblKPIcode = (Label)gvRow.FindControl("lblKPIcode");

            htRunKpi.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htRunKpi.Add("@CNTSTN_CODE", Request.QueryString["CNTSTNT_CODE"].ToString().Trim());
            htRunKpi.Add("@ACCR_CYCLE", hdnCycCode.Value.ToString().Trim());

            htRunKpi.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKy"].ToString().Trim());
            htRunKpi.Add("@KPI_CODE", lblKPIcode.Text.ToString().Trim());
            htRunKpi.Add("@CREATED_BY", Session["UserID"].ToString().Trim());

            dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_ALL_KPI", htRunKpi);
            // if(dsRunKpi.Tables.Count>0 && dsRunKpi.Tables[0].Rows.Count>0)
            //  {

            imgStatus.Style.Add("display", "none");
            //imgStatus.Visible = false;
                lnkRun.Visible = true;
                lnkRun.Text = "RE-RUN";
           // }
          
           

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funimgStatus('" + lblCompCodeVal.Text.ToString().Trim() + "','"
            //      + hdnCntstCode.Value.ToString().Trim() + "','" + hdnRSK.Value.ToString().Trim() + "','"
            //      + hdnCycCode.Value.ToString().Trim() + "','" + hdnCycDesc.Value.ToString().Trim() + "','" + lblRSK.Text.ToString().Trim()
            //      + "','" + hdnCmpFlag.Value.ToString().Trim() + "','" + hdnRulType.Value.ToString().Trim() + "');", true);
        //    if (lblKPIcode.Text.ToString() == "1000000101")
        //    {
              
        //        dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_NBP", htRunKpi);
        //    }
        //    else if (lblKPIcode.Text.ToString() == "1000000501")
        //    {
                
        //        dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_NPS", htRunKpi);

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('DATA IMPORTED SUCCESSFULLY.');", true);

        //    }
        //    else if (lblKPIcode.Text.ToString() == "1000000601")
        //    {
                
        //        dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_FREELOOK", htRunKpi);
        //    }
        //    else if (lblKPIcode.Text.ToString() == "1000000401")
        //     {

        //            dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_HEALTH_CHK", htRunKpi);
        //            }
        //        else
        //        { }



           
            
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkRunKPI_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
       
    }


    protected void lnkStart_Click(object sender, EventArgs e)
    {

        try
        {
        Hashtable htStrBtch = new Hashtable();
        DataSet dsStrBtch = new DataSet();
        htStrBtch.Clear();
        dsStrBtch.Clear();

        htStrBtch.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htStrBtch.Add("@CNTSTNT_CODE", lblCompCodeVal.Text.ToString().Trim());
        dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_CheckHybridKPI", htStrBtch);
        if (dsStrBtch.Tables.Count > 0)
        {
            if (dsStrBtch.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupDataSynchHybrid('" + lblCompCodeVal.Text.ToString().Trim() + "');", true);

            }

            else
            {
                htStrBtch.Clear();
                dsStrBtch.Clear();

                GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                HiddenField hdnStpCd = (HiddenField)gvRow.FindControl("hdnStpCd");
                LinkButton lnkStart = (LinkButton)gvRow.FindControl("lnkStart");
                Image imgStatus = (Image)gvRow.FindControl("imgStatus");
                Label lblStatus = (Label)gvRow.FindControl("lblStatus");
                lblStatus.Attributes.Add("display", "block");
                //lnkStart.Visible = false;
                //imgStatus.Visible = true;
                //imgStatus.ImageUrl = "../../../images/spinner.gif";
                //lblStatus.Visible = true;
                //lblStatus.Text = "Awaiting Execution";




                //msg = BtchStepValidation(hdnCycCode.Value.Trim(), lblCompCodeVal.Text.Trim(), "", "", "", "", "", hdnStpCd.Value.Trim());
                //if (msg != "")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + msg.Trim() + "');", true);
                //    return;
                //}

                htStrBtch.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
                htStrBtch.Add("@CYCLE_DESC", hdnCycDesc.Value.ToString().Trim());
                htStrBtch.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                //////htStrBtch.Add("@CNTSTNT_CODE", "");
                htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
                htStrBtch.Add("@IS_DPNDT", "0");
                htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());




                if (hdnStpCd.Value == "S001")
                {
                    //////htStrBtch.Add("@COMP_FLAG", "");

                    dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InssPOLDTLS", htStrBtch);

                }
                else if (hdnStpCd.Value == "S002")
                {
                    //lblStatus.Visible = true;
                    //lblStatus.Text = "Awaiting Execution";
                    dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpMEMREL", htStrBtch);

                }
                else if (hdnStpCd.Value == "S003")
                {
                    //lblStatus.Visible = true;
                    //lblStatus.Text = "Awaiting Execution";
                    dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InccmpRULENGN", htStrBtch);

                }

                Response.Redirect("BtchJob.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                                     + "&flag=" + Request.QueryString["flag"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&CNTSTNT_CODE=" + Request.QueryString["CNTSTNT_CODE"].ToString().Trim()
               + "&RuleSetKy=" + Request.QueryString["RuleSetKy"].ToString().Trim(), true);
                //  FillSbBtch();
                //  tmr.Enabled = true;

                //if (lnkStart.Text == "Start")
                //{

                //    lnkStart.Visible = false;
                //    imgStatus.Visible = true;
                //    imgStatus.ImageUrl = "../../../images/spinner.gif";
                //}
            }
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkStart_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillBtchSeq()
    {
        try
        {
        DataSet dsBtchSeq = new DataSet();
        Hashtable htBtchSeq = new Hashtable();
        htBtchSeq.Clear();
        dsBtchSeq.Clear();
        htBtchSeq.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        htBtchSeq.Add("@CYCLE_DESC", hdnCycDesc.Value.ToString().Trim());
        htBtchSeq.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htBtchSeq.Add("@STEP_CODE", "S009");
        htBtchSeq.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
        dsBtchSeq = objDal.GetDataSetForPrc_SAIM("Prc_cmpBTCHSEQ_InBrief", htBtchSeq);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FillBtchSeq", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void tmr_Tick(object sender, EventArgs e)
    {
        try
        {
        System.Threading.Thread.Sleep(2000);
        FillSbBtch();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "tmr_Tick",ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkViewTax_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCmpCodeDsc = (HiddenField)gvRow.FindControl("hdnCmpnstn");
        HiddenField hdnCntstCode = (HiddenField)gvRow.FindControl("hdnCntst");
        HiddenField hdnCmpFlag = (HiddenField)gvRow.FindControl("hdnCmpFlg");
        HiddenField hdnStatus = (HiddenField)gvRow.FindControl("hdnStatus");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopup('" + hdnCmpCodeDsc.Value.ToString().Trim() + "','"
                    + hdnCntstCode.Value.ToString().Trim() + "','','"
                    + hdnCycCode.Value.ToString().Trim() + "','" + hdnCycDesc.Value.ToString().Trim() + "','','"
                    + hdnCmpFlag.Value.ToString().Trim() + "','');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "tmr_Tick", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkViewRpt_Click(object sender, EventArgs e)
    {
        try
        {
        //GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        //HiddenField hdnCmpCodeDsc = (HiddenField)gvRow.FindControl("hdnCmpnstn");
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopRpt('" + hdnCmpCodeDsc.Value.ToString().Trim() + "','"
        //    + hdnCycCode.Value.ToString().Trim() + "');", true);
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnCmpnstn = (HiddenField)gvRow.FindControl("hdnCmpnstn");
        HiddenField hdnCntstn = (HiddenField)gvRow.FindControl("hdnCntstn");
        GridView dgGrid = (GridView)gvRow.FindControl("dgGrid");

        DwnldSumm("", "", dgGrid);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "lnkViewRpt_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillSummRprt()
    {
        try
        {
        DataTable dtRpt = new DataTable();
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htParam.Clear();
        htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls", htParam);
        dtRpt = ds.Tables[0];
        dgSummRpt.DataSource = dtRpt;
        dgSummRpt.DataBind();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "FillSummRprt", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected string BtchStepValidation(string cyccd, string cmpnstncd, string cntstcd, string rulecd, string rulstky, string rultyp, string cmptflg,string stepcd)
    {
        
        string valID = string.Empty;
        string valmsg = string.Empty;
            try
            {
        Hashtable htVal = new Hashtable();
        DataSet dsVal = new DataSet();
        htVal.Add("@CMPNSTN_CODE", cmpnstncd.ToString().Trim());
        htVal.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        htVal.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htVal.Add("@RULE_TYPE", rultyp.ToString().Trim());
        htVal.Add("@COMPUTE_FLAG", cmptflg.ToString().Trim());
        htVal.Add("@RULE_SET_KEY", rulstky.ToString().Trim());
        htVal.Add("@RULE_CODE", rulecd.ToString().Trim());
        htVal.Add("@STEP_CODE", stepcd.ToString().Trim());
        htVal.Add("@BatchID", GetBatchID().ToString().Trim());
        dsVal = objDal.GetDataSetForPrc_SAIM("Prc_GetCNTstepValidation", htVal);
        if (dsVal.Tables.Count > 0)
        {
            if (dsVal.Tables[0].Rows.Count > 0)
            {
                valID = dsVal.Tables[0].Rows[0]["Status"].ToString().Trim();
                if (valID == "F")
                {
                    valmsg = dsVal.Tables[0].Rows[0]["StepDesc"].ToString().Trim();
                }
                else
                {
                    valmsg = "";
                }
            }
        }
           
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "BtchStepValidation", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return valmsg.Trim();
    }

    protected string GetBatchID()
    {
        string btchID = string.Empty;
        try
        {
            
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Add("@Flag", "28");
        htBtch.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htBtch.Add("@CYCLE_CODE", hdnCycCode.Value.ToString().Trim());
        dsBtch = objDal.GetDataSetForPrc_SAIM("Prc_FillMstVals", htBtch);
        if (dsBtch.Tables.Count > 0)
        {
            if (dsBtch.Tables[0].Rows.Count > 0)
            {
                btchID = dsBtch.Tables[0].Rows[0]["BATCHID"].ToString().Trim();
            }
        }
            
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "GetBatchID", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return btchID.Trim();
    }

    protected void DwnldSumm(string cmp, string cnt, GridView gv)
    {
        try
        {
            Hashtable htExcel = new Hashtable();
            DataSet dsExcel = new DataSet();
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            dsExcel.Clear();
            htExcel.Clear();

            string filename = "BM_F2F_KPI_Summary.xls";
            HiddenField hdnCmpnstn = new HiddenField();
            HiddenField hdnCntstn = new HiddenField();

            hdnCmpnstn.Value = "10000022";
            hdnCntstn.Value = "10000076";
            htExcel.Add("@CMPNSTN_CODE", hdnCmpnstn.Value.ToString().Trim());
            htExcel.Add("@CNTNSTN_CODE", hdnCntstn.Value.ToString().Trim());
            htExcel.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            dsExcel = objDal.GetDataSetForPrc_SAIM("Prc_InsBMF2FSummary", htExcel);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dsExcel.Tables[0];
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            string renderedGridView = tw.ToString();

            if (dsExcel.Tables[0].Rows.Count > 0)
            {

                //Response.ClearContent();
                //Response.Buffer = true;
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + "");
                //this.EnableViewState = false;

                //Response.Write(tw.ToString());
                ///////Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //dsExcel = null;

                ////strpathserver = strPathDoc + "\\" + FileName + ".zip";
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=" + filename + "");
                /////byte[] data = req.DownloadData((strpathserver));
                response.Write(tw.ToString());
                Response.Flush();
                Response.SuppressContent = true;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BtchJob", "DwnldSumm", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
 
}
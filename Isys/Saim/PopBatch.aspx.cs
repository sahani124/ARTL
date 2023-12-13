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
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;

public partial class Application_ISys_Saim_PopBatch : BaseClass
{
    #region Declaration
    DataSet ds = new DataSet();
    DataSet dsUpld = new DataSet();
    DataSet dsLogEntry = new DataSet();
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private string destDir = string.Empty;
    private string fileName = string.Empty;
    private string destPath = string.Empty;
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strDocType = string.Empty;
    string strValidate = string.Empty;
    string batchid = string.Empty;
    string msg = string.Empty;
    string cmpnstn, cntstcd, rskey, cyccd, cycdesc, rskeydesc, cmptflag, rultyp, p_rulcd = "";
    string p_cntstcd, p_rskey, p_rskeydesc, p_cmptflag, p_rultyp = "";
    #endregion

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
            GetCmpDetails();
            string s = hdnCntstCode.Value;
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "Rpt")
                {
                    lblhdr.Text = "Summary Report Details";
                    lblRSKCode.Visible = false;
                    lblRSKCodeVal.Visible = false;
                    lblRSKDescVal.Visible = false;
                    lblRSKDesc.Visible = false;
                    Button1.Visible = true;
                }
                else
                {
                    lblRSKCodeVal.Text = rskey.ToString().Trim();
                    lblRSKDescVal.Text = rskeydesc.ToString().Trim();
                    if (cmptflag == "A")
                    {
                        dgBtchRSK.Columns[0].HeaderText = "Achievements";
                        FilldgRSK("2");
                    }
                    else if (cmptflag == "R")
                    {
                        dgBtchRSK.Columns[0].HeaderText = "Rewards";
                        FilldgRSK("5");
                    }
                    else if (cmptflag == "T")
                    {
                        dgBtchRSK.Columns[0].HeaderText = "Taxation";
                        FilldgRSK("7");
                        lblRSKCode.Visible = false;
                        lblRSKCodeVal.Visible = false;
                        lblRSKDescVal.Visible = false;
                        lblRSKDesc.Visible = false;
                    }   
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
           
        }
    }

    protected void FilldgRSK(string flag)
    {
        try { 
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Clear();
        dsBtch.Clear();
        htBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htBtch.Add("@CNTSTN_CODE", cntstcd.ToString().Trim());
        htBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
        htBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htBtch.Add("@COMPUTE_FLAG", cmptflag.ToString().Trim());
        htBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
        htBtch.Add("@FLAG", flag.ToString());
        dsBtch = objDal.GetDataSetForPrc_SAIM("Prc_GetCMPDtlsBtch", htBtch);
        if (dsBtch.Tables.Count > 0 && dsBtch.Tables[0].Rows.Count > 0)
        {
            dgBtchRSK.DataSource = dsBtch;
            dgBtchRSK.DataBind();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "FilldgRSK", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void GetCmpDetails()
    {
        try { 
        if (Request.QueryString["CmpCode"] != null)
        {
            if (Request.QueryString["CmpCode"].ToString().Trim() != "")
            {
                cmpnstn = Request.QueryString["CmpCode"].ToString().Trim();
            }
            else
            {
                cmpnstn = "";
            }
        }
        else
        {
            cmpnstn = "";
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != "")
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
            else
            {
                cntstcd = "";
            }
        }
        else
        {
            cntstcd = "";
        }
        if (Request.QueryString["rskey"] != null)
        {
            if (Request.QueryString["rskey"].ToString().Trim() != "")
            {
                rskey = Request.QueryString["rskey"].ToString().Trim();
            }
            else
            {
                rskey = "";
            }
        }
        else
        {
            rskey = "";
        }
        if (Request.QueryString["cyccd"] != null)
        {
            if (Request.QueryString["cyccd"].ToString().Trim() != "")
            {
                cyccd = Request.QueryString["cyccd"].ToString().Trim();
            }
            else
            {
                cyccd = "";
            }
        }
        else
        {
            cyccd = "";
        }
        if (Request.QueryString["cycdesc"] != null)
        {
            if (Request.QueryString["cycdesc"].ToString().Trim() != "")
            {
                cycdesc = Request.QueryString["cycdesc"].ToString().Trim();
            }
            else
            {
                cycdesc = "";
            }
        }
        else
        {
            cycdesc = "";
        }

        if (Request.QueryString["rskeydesc"] != null)
        {
            if (Request.QueryString["rskeydesc"].ToString().Trim() != "")
            {
                rskeydesc = Request.QueryString["rskeydesc"].ToString().Trim();
            }
            else
            {
                rskeydesc = "";
            }
        }
        else
        {
            rskeydesc = "";
        }
        if (Request.QueryString["cmptflag"] != null)
        {
            if (Request.QueryString["cmptflag"].ToString().Trim() != "")
            {
                cmptflag = Request.QueryString["cmptflag"].ToString().Trim();
            }
            else
            {
                cmptflag = "";
            }
        }
        else
        {
            cmptflag = "";
        }
        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"].ToString().Trim() != "")
            {
                rultyp = Request.QueryString["rultyp"].ToString().Trim();
            }
            else
            {
                rultyp = "";
            }
        }
        else
        {
            rultyp = "";
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "GetCmpDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void FillSbBtch(string rulecode, string kpicode, string kpitype, GridView grd, string idpndt)
    {
        try { 
        DataSet dssbBtch = new DataSet();
        Hashtable htsbBtch = new Hashtable();
        htsbBtch.Clear();
        dssbBtch.Clear();
        htsbBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htsbBtch.Add("@CNTSTN_CODE", cntstcd.ToString().Trim());
        htsbBtch.Add("@RULE_CODE", rulecode.ToString().Trim());
        htsbBtch.Add("@RULE_SET_KEY", lblRSKCodeVal.Text.ToString().Trim());
        htsbBtch.Add("@KPI_CODE", kpicode.ToString().Trim());
        htsbBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htsbBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
        htsbBtch.Add("@KPI_TYPE", kpitype.ToString().Trim());
        htsbBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
        htsbBtch.Add("@FLAG", "1");
        htsbBtch.Add("@IS_DPNDT", idpndt.ToString().Trim());
        dssbBtch = objDal.GetDataSetForPrc_SAIM("PrcGetcmpBTCHSTP", htsbBtch);
        if (dssbBtch.Tables.Count > 0 && dssbBtch.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = dssbBtch;
            grd.DataBind();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "FillSbBtch", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkStart_Click(object sender, EventArgs e)
    {
        try { 
        Hashtable htStrBtch = new Hashtable();
        DataSet dsStrBtch = new DataSet();
        htStrBtch.Clear();
        dsStrBtch.Clear();
        GetCmpDetails();
        hdnCntstCode.Value = cntstcd.Trim();
        hdnRulStKy.Value = rskey.Trim();
        hdnRulStKyDsc.Value = rskeydesc.Trim();
        hdnRulTyp.Value = rultyp.Trim();
        hdncmptflg.Value = cmptflag.Trim();
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnStpCd = (HiddenField)gvRow.FindControl("hdnStpCd");
        HiddenField hdnRlCodeSb = (HiddenField)gvRow.FindControl("hdnRlCodeSb");
        HiddenField hdnKPICodeSb = (HiddenField)gvRow.FindControl("hdnKPICodeSb");
        HiddenField hdnKPIOrgn = (HiddenField)gvRow.FindControl("hdnKPIOrgn");
        LinkButton lnkStart = (LinkButton)gvRow.FindControl("lnkStart");
        Image imgStatus = (Image)gvRow.FindControl("imgStatus");
        Label lblStatus = (Label)gvRow.FindControl("lblStatus");
        FileUpload fUpld = (FileUpload)gvRow.FindControl("fUpld");
        
        if (hdnRlCodeSb.Value != "")
        {
            hdnRlCodeSb.Value = hdnRlCodeSb.Value.Substring(0, 8);
        }
        else
        {
            hdnRlCodeSb.Value = "";
        }

        if (hdnKPICodeSb.Value != "")
        {
            hdnKPICodeSb.Value = hdnKPICodeSb.Value.Substring(0, 8);
        }
        else
        {
            hdnKPICodeSb.Value = "";
        }

        if (hdnStpCd.Value != "")
        {
            hdnStpCd.Value = hdnStpCd.Value.Substring(0, 4);
        }
        else
        {
            hdnStpCd.Value = "";
        }
        msg = BtchStepValidation(cyccd.Trim(), cmpnstn.Trim(), cntstcd.Trim(), hdnRlCodeSb.Value, rskey.Trim(), rultyp.Trim(), cmptflag.Trim(),
            hdnStpCd.Value.Trim(), hdnKPICodeSb.Value.Trim());
        //if (hdnStpCd.Value != "S000")
        //{
        //    if (msg != "")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please execute " + msg.Trim() + "');", true);
        //        return;
        //    }
        //}
        if (hdnStpCd.Value == "S000")
        {
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_GetMapBaseKPI", htStrBtch);
            if (dsStrBtch.Tables.Count > 0)
            {
                if (dsStrBtch.Tables[0].Rows.Count > 0)
                {
                    cntstcd = dsStrBtch.Tables[0].Rows[0]["SUB_CNTST_CODE"].ToString().Trim();
                    rskey = dsStrBtch.Tables[0].Rows[0]["SUB_RULE_SET_KEY"].ToString().Trim();
                    rskeydesc = dsStrBtch.Tables[0].Rows[0]["RULE_SET_KEY_DSC"].ToString().Trim();
                    rultyp = dsStrBtch.Tables[0].Rows[0]["RULE_TYPE"].ToString().Trim();
                    p_rulcd = hdnRlCodeSb.Value.ToString().Trim();
                }
            }

            Response.Redirect("PopBatch.aspx?CmpCode=" + cmpnstn.ToString().Trim()
            + "&cntstcd=" + cntstcd.ToString().Trim() + "&rskey=" + rskey.ToString().Trim() + "&cyccd=" + cyccd.ToString().Trim()
            + "&cycdesc=" + cycdesc.ToString().Trim() + "&rskeydesc=" + rskeydesc.ToString().Trim()
            + "&cmptflag=" + cmptflag.ToString().Trim() + "&rultyp=" + rultyp.ToString().Trim() + "&p_rulcd=" + p_rulcd.ToString().Trim()
            + "&p_cntstcd=" + hdnCntstCode.Value.ToString().Trim() + "&p_rultyp=" + hdnRulTyp.Value.ToString().Trim()
            + "&p_cmptflag=" + hdncmptflg.Value.ToString().Trim() + "&p_rskey=" + hdnRulStKy.Value.ToString().Trim()
            + "&p_rskeydesc=" + hdnRulStKyDsc.Value.ToString().Trim()
            + "&flag=D&mdlpopup=mdlPopBID", true);
        }
        if (hdnStpCd.Value == "S001")/////////KPI Data Synchronization
        {
            if (lnkStart.Text == "Upload" || lnkStart.Text == "Reupload")
            {
                if (fUpld.Visible == false)
                {
                    fUpld.Visible = true;
                }
                else if (fUpld.Visible == true)
                {
                    FileUpload(fUpld, hdnKPICodeSb.Value.ToString().Trim(), hdnStpCd.Value.ToString().Trim(), hdnRlCodeSb.Value.ToString().Trim());
                    lnkStart.Text = "Reupload";
                }
            }
            else
            {
                fUpld.Visible = false;
                htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
                htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
                htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "D")
                    {
                        if (Request.QueryString["cntstcd"].ToString().Trim() != "")
                        {
                            htStrBtch.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().ToString().Trim());
                        }
                        else
                        {
                            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                        }
                        if (Request.QueryString["rultyp"].ToString().Trim() != "")
                        {
                            htStrBtch.Add("@RULE_TYPE", Request.QueryString["rultyp"].ToString().Trim());
                        }
                        else
                        {
                            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
                        }
                        if (Request.QueryString["rskey"].ToString().Trim() != "")
                        {
                            htStrBtch.Add("@RULE_SET_KEY", Request.QueryString["rskey"].ToString().Trim());
                        }
                        else
                        {
                            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
                        }
                    }
                    else
                    {
                        htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                        htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
                        htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
                    }
                }
                else
                {
                    htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                    htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
                }
                htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
                htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
                htStrBtch.Add("@KPI_CODE", hdnKPICodeSb.Value.ToString().Trim());
                htStrBtch.Add("@IS_DPNDT", "0");
                htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
                htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());

                dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpPOLDTLS", htStrBtch);
                tmr.Enabled = true;
            }

        }
        else if (hdnStpCd.Value == "S002")
        {
            if (hdnKPIOrgn.Value == "1003")
            {
                Validate(hdnKPICodeSb.Value.ToString().Trim(), hdnRlCodeSb.Value.ToString().Trim(), hdnStpCd.Value.ToString().Trim());
                ////strValidate = strValidate ? lnkStart.Enabled = false : lnkStart.Enabled = true;
                lnkStart.Enabled = (strValidate == "") ? false : true;
            }
            else
            {
                htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
                htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
                htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
                htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
                htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
                htStrBtch.Add("@IS_DPNDT", "0");
                htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
                htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
                dsStrBtch = objDal.GetDataSetForPrc_SAIM("", htStrBtch);
            }
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S003")
        {
            if (hdnKPIOrgn.Value == "1003")
            {
                Process(cyccd.ToString().Trim(), cycdesc.ToString().Trim(), cmpnstn.ToString().Trim(),
                    cntstcd.ToString().Trim(), rskey.ToString().Trim(), hdnKPICodeSb.Value.ToString().Trim(),
                    hdnRlCodeSb.Value.ToString().Trim(), hdnStpCd.Value.ToString().Trim(), Session["UserID"].ToString().Trim(),
                    cmptflag.ToString().Trim(), rultyp.ToString().Trim());
            }
            else
            {
                htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
                htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
                htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
                htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
                htStrBtch.Add("@KPI_CODE", hdnKPICodeSb.Value.ToString().Trim());
                htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
                htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
                htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
                htStrBtch.Add("@IS_DPNDT", "0");
                htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
                dsStrBtch = objDal.GetDataSetForPrc_SAIM("", htStrBtch);
                tmr.Enabled = true;
            }
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S004")////Compute Target Achievements
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htStrBtch.Add("@KPI_CODE", hdnKPICodeSb.Value.ToString().Trim());
            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            if (hdnKPIOrgn.Value == "1003")/////for hybrid kpi
            {
                htStrBtch.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
                htStrBtch.Add("@FLAG", "2");
                dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htStrBtch);
            }
            else if (hdnKPIOrgn.Value == "1002")
            {
                htStrBtch.Add("@IS_DPNDT", "0");
                dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGACH_DRVD", htStrBtch);
            }
            else if (hdnKPIOrgn.Value == "1001")
            {
                htStrBtch.Add("@IS_DPNDT", "0");
                dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGACH_BASE", htStrBtch);
            }
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S005")
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htStrBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@IS_DPNDT", "0");
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGCATG", htStrBtch);
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S006")
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@IS_DPNDT", "0");
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGRWD", htStrBtch);
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S007")
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@IS_DPNDT", "0");
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_UpdSrvcTax", htStrBtch);
            tmr.Enabled = true;
        }
        else if (hdnStpCd.Value == "S008")
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@IS_DPNDT", "0");
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_UpdTDSCalc", htStrBtch);
            tmr.Enabled = true;
        }
        ////if (lnkStart.Text != "Upload")
        if (fUpld.Visible == false)
        {
            if (lnkStart.Text != "Reupload")
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Awaiting Execution";
                lnkStart.Visible = false;
                imgStatus.Visible = true;
                imgStatus.ImageUrl = "../../../images/spinner.gif";
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "lnkStart_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgBaseCatg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            LinkButton lnkStart = (LinkButton)e.Row.FindControl("lnkBsStart");
            HiddenField hdnKPIOrgn = (HiddenField)e.Row.FindControl("hdnKPIOrgn");
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            if (hdnStatus.Value == "C")
            {
                lnkStart.Visible = false;
                lblStatus.Text = "Completed";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                imgStatus.ImageUrl = "../../../images/tick_ok.png";
                imgStatus.Visible = true;
                tmr.Enabled = false;
            }
            else if (hdnStatus.Value == "F")
            {
                lnkStart.Text = "Failed/Rerun";
                lnkStart.ForeColor = System.Drawing.Color.Red;
                imgStatus.ImageUrl = "../../../images/close.gif";
                imgStatus.Visible = true;
                lblStatus.Visible = false;
                tmr.Enabled = false;
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
                lblStatus.Visible = false;
                imgStatus.Visible = false;
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "dgBaseCatg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void dgBtchRSK_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try { 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView dgBtchRSK = (GridView)e.Row.FindControl("dgBtchRSK");
            HiddenField hdnRulCode = (HiddenField)e.Row.FindControl("hdnRulCode");
            HiddenField hdnKPICode = (HiddenField)e.Row.FindControl("hdnKPICode");
            HiddenField hdnKPIType = (HiddenField)e.Row.FindControl("hdnKPIType");

            Label lblKPICODE = (Label)e.Row.FindControl("lblKPICODE");
            Label lblKPIType = (Label)e.Row.FindControl("lblKPIType");

            Label lblKPICodeDsc = (Label)e.Row.FindControl("lblKPICodeDsc");
            Label lblRwrdCdDsc = (Label)e.Row.FindControl("lblRwrdCdDsc");
            Label lblKPITypeDsc = (Label)e.Row.FindControl("lblKPITypeDsc");
            Label lblRwrdCd = (Label)e.Row.FindControl("lblRwrdCd");

            if (cmptflag == "A")
            {
                /////dgBtchRSK.Columns[0].HeaderText = "Achievements";
                lblKPICODE.Text = "KPI Code";
                lblKPIType.Text = "KPI Type";
                lblKPICodeDsc.Visible = true;
                lblKPITypeDsc.Visible = true;
                lblRwrdCdDsc.Visible = false;
                lblRwrdCd.Visible = false;

            }
            else if (cmptflag == "R")
            {
                /////dgBtchRSK.Columns[0].HeaderText = "Rewards";
                lblKPICODE.Text = "";
                lblKPIType.Text = "";
                lblKPICodeDsc.Visible = false;
                lblKPITypeDsc.Visible = false;
                lblRwrdCdDsc.Visible = true;
                lblRwrdCd.Visible = true;
                hdnKPIType.Visible = false;
            }
            else if (cmptflag == "T")
            {
                /////dgBtchRSK.Columns[0].HeaderText = "Rewards";
                lblKPICODE.Text = "";
                lblKPIType.Text = "";
                lblKPICodeDsc.Visible = false;
                lblKPITypeDsc.Visible = false;
                lblRwrdCdDsc.Visible = true;
                lblRwrdCd.Visible = true;
                hdnKPIType.Visible = false;
            }


            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "D")
                {
                    FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgSbBtch, "0");
                    /////FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgBaseCatg, "1");
                    if (rultyp == "Q")
                    {
                        FillSbBtch("", "", "", dgBaseCatg, "1");
                    }
                }
                else
                {
                    FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgSbBtch, "0");
                    /////FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgBaseCatg, "");
                    if (rultyp == "Q")
                    {
                        FillSbBtch("", "", "", dgBaseCatg, "0");
                    }
                }
            }
            else
            {
                FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgSbBtch, "0");
                /////FillSbBtch(hdnRulCode.Value.ToString().Trim(), hdnKPICode.Value.ToString().Trim(), hdnKPIType.Value.ToString().Trim(), dgBaseCatg, "");
                if (rultyp == "Q")
                {
                    FillSbBtch("", "", "", dgBaseCatg, "0");
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "dgBtchRSK_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void dgSbBtch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try { 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");
            LinkButton lnkStart = (LinkButton)e.Row.FindControl("lnkStart");
            HiddenField hdnKPIOrgn = (HiddenField)e.Row.FindControl("hdnKPIOrgn");
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            HiddenField hdnRlCodeSb = (HiddenField)e.Row.FindControl("hdnRlCodeSb");
            HiddenField hdnStpCd = (HiddenField)e.Row.FindControl("hdnStpCd");
            HiddenField hdnKPICodeSb = (HiddenField)e.Row.FindControl("hdnKPICodeSb");
            FileUpload fUpld = (FileUpload)e.Row.FindControl("fUpld");
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() != "D")
                {
                    hdnKPIOrgn.Visible = false;
                    hdnRlCodeSb.Visible = false;
                    hdnKPICodeSb.Visible = false;
                }
                else
                {
                    hdnKPIOrgn.Visible = true;
                    hdnRlCodeSb.Visible = true;
                    hdnKPICodeSb.Visible = true;
                }
            }
            else
            {
                hdnKPIOrgn.Visible = true;
                hdnRlCodeSb.Visible = true;
                hdnKPICodeSb.Visible = true;
            }
            
            //if (tmr.Enabled == true)
            //{
            if (hdnStatus.Value == "C")
            {
                lnkStart.Visible = false;
                lblStatus.Text = "Completed";
                imgStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                imgStatus.ImageUrl = "../../../images/tick_ok.png";
                tmr.Enabled = false;
            }
            else if (hdnStatus.Value == "F")
            {
                //lnkStart.Visible = false;
                lnkStart.Text = "Failed/Rerun";
                ////lblStatus.Text = "Failed/Rerun";
                ////lblStatus.ForeColor = System.Drawing.Color.Red;
                lnkStart.ForeColor = System.Drawing.Color.Red;
                imgStatus.ImageUrl = "../../../images/close.gif";
                imgStatus.Visible = true;
                lblStatus.Visible = false;
                tmr.Enabled = false;
            }
            else if (hdnStatus.Value == "P")
            {
                lnkStart.Visible = false;
                lblStatus.Text = "Awaiting Execution";
                imgStatus.ImageUrl = "../../../images/spinner.gif";
            }
            else
            {
                if (hdnKPIOrgn.Value == "1003")
                {
                    if (hdnStpCd.Value == "S001")
                    {
                        lnkStart.Text = "Upload";
                    }
                    else if (hdnStpCd.Value == "S002")
                    {
                        lnkStart.Text = "Validate";
                    }
                    else if (hdnStpCd.Value == "S003")
                    {
                        lnkStart.Text = "Process";
                    }
                    else
                    {
                        lnkStart.Text = "Start";
                        tmr.Enabled = false;
                    }
                }
                else
                {
                    lnkStart.Text = "Start";
                    tmr.Enabled = false;
                }
                lnkStart.Visible = true;
                lblStatus.Visible = false;
                imgStatus.Visible = false;
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "dgSbBtch_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void tmr_Tick(object sender, EventArgs e)
    {
        try { 
        System.Threading.Thread.Sleep(2000);
        GetCmpDetails();
        if (cmptflag == "A")
        {
            FilldgRSK("2");
        }
        else if (cmptflag == "R")
        {
            FilldgRSK("5");
        }
        else if (cmptflag == "T")
        {
            FilldgRSK("7");
        }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "tmr_Tick", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void lnkBsStart_Click(object sender, EventArgs e)
    {
        try { 
        Hashtable htStrBtch = new Hashtable();
        DataSet dsStrBtch = new DataSet();
        htStrBtch.Clear();
        dsStrBtch.Clear();
        GetCmpDetails();
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hdnStpCd = (HiddenField)gvRow.FindControl("hdnStpCd");
        HiddenField hdnRlCodeSb = (HiddenField)gvRow.FindControl("hdnRlCodeSb");
        HiddenField hdnKPICodeSb = (HiddenField)gvRow.FindControl("hdnKPICodeSb");
        LinkButton lnkStart = (LinkButton)gvRow.FindControl("lnkBsStart");
        Image imgStatus = (Image)gvRow.FindControl("imgStatus");
        Label lblStatus = (Label)gvRow.FindControl("lblStatus");
        HiddenField hdnStatus = (HiddenField)gvRow.FindControl("hdnStatus");
        if (hdnRlCodeSb.Value != "")
        {
            hdnRlCodeSb.Value = hdnRlCodeSb.Value.Substring(0, 8);
        }
        else
        {
            hdnRlCodeSb.Value = "";
        }

        if (hdnKPICodeSb.Value != "")
        {
            hdnKPICodeSb.Value = hdnKPICodeSb.Value.Substring(0, 8);
        }
        else
        {
            hdnKPICodeSb.Value = "";
        }

        if (hdnStpCd.Value != "")
        {
            hdnStpCd.Value = hdnStpCd.Value.Substring(0, 4);
        }
        else
        {
            hdnStpCd.Value = "";
        }
        msg = BtchStepValidation(cyccd.Trim(), cmpnstn.Trim(), cntstcd.Trim(), hdnRlCodeSb.Value, rskey.Trim(), rultyp.Trim(), cmptflag.Trim(),
            hdnStpCd.Value.Trim(), hdnKPICodeSb.Value.Trim());
        if (msg != "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + msg.Trim() + "')", true);
            return;
        }
        if (hdnStpCd.Value == "S005")
        {
            htStrBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htStrBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htStrBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htStrBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htStrBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
            htStrBtch.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htStrBtch.Add("@RULE_TYPE", rultyp.ToString().Trim());
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "D")
                {
                    if (Request.QueryString["p_rulcd"] != null)
                    {
                        if (Request.QueryString["p_rulcd"].ToString().Trim() != "")
                        {
                            htStrBtch.Add("@PRNT_RULE_CODE", Request.QueryString["p_rulcd"].ToString().Trim());
                            htStrBtch.Add("@IS_DPNDT", "1");
                        }
                        else 
                        {
                            htStrBtch.Add("@IS_DPNDT", "0");
                        }
                    }
                    else
                    {
                        htStrBtch.Add("@IS_DPNDT", "0");
                    }
                }
                else
                {
                    htStrBtch.Add("@IS_DPNDT", "0");
                }
            }
            else
            {
                htStrBtch.Add("@IS_DPNDT", "0");
            }
            htStrBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htStrBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            
            dsStrBtch = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGCATG", htStrBtch);
            tmr.Enabled = true;
        }

        if (hdnStatus.Value == "S")
        {
            lblStatus.Visible = true;
            lblStatus.Text = "Awaiting Execution";
            lnkStart.Visible = false;
            imgStatus.Visible = true;
            imgStatus.ImageUrl = "../../../images/spinner.gif";   
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "lnkBsStart_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void FileUpload(FileUpload fUpl, string kpicode,string stepcd,string rulecd)
    {
         
        string strSize = string.Empty;
        string strColumnError = string.Empty;
        Hashtable htSize = new Hashtable();
        DataSet ds = new DataSet();
        Hashtable htCol = new Hashtable();
        DataSet dsMstCol = new DataSet();
        DataSet dsTmpCol = new DataSet();
        string strTblName = string.Empty;
        DataSet dsfile = new DataSet();

        try
        {
            htParam.Clear();
            dsLogEntry.Clear();
            htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
            htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
            htParam.Add("@RULE_CODE", rulecd.ToString().Trim());
            htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
            htParam.Add("@CREATED_BY", Session["UserId"].ToString().Trim());
            htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            htParam.Add("@PROCNAME", "Prc_cmpHYBKPIUPLD");
            htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htParam.Add("@FLAG", "3");
            dsLogEntry = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);

            ds.Clear();
            htSize.Clear();
            htSize.Add("@KPI_CODE", kpicode);
            htSize.Add("@Flag", "26");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_FillMstVals", htSize);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strDocType = ds.Tables[0].Rows[0]["DESC01"].ToString().Trim();
                    hdnDocType.Value = strDocType.ToString().Trim();
                }
            }
            if (fUpl.HasFile)
            {
                System.Threading.Thread.Sleep(2000);
                string excelExtention = string.Empty;
                excelExtention = System.IO.Path.GetExtension(fUpl.PostedFile.FileName).ToLower();
                if ((excelExtention != ".xls") && (excelExtention != ".xlsx"))
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Incorrect file format');</script>");
                    return;
                }
                else
                {
                    htSize.Clear();
                    htSize.Add("@DocType", strDocType.ToString().Trim());
                    strSize = objDal.execute_sprc_UpdDwnld_with_output("Prc_GetFileSize", htSize, "@Size");
                    if (fUpl.PostedFile.ContentLength > Convert.ToInt32(strSize))
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('The size of the file is bigger than 2MB');</script>");
                        return;
                    }
                    else
                    {
                        ////InsUpldStat(stepcd, rulecd, "1");
                        htCol.Clear();
                        dsMstCol.Clear();
                        dsTmpCol.Clear();
                        htCol.Add("@DocType", strDocType.ToString().Trim());
                        dsMstCol = objDal.GetDataSetForPrcUpdDwnld("Prc_GetMstrColumnName", htCol);
                        dsTmpCol = objDal.GetDataSetForPrcUpdDwnld("Prc_GetTempColumnName", htCol);

                        //Master and temp table column check
                        if (dsMstCol.Tables[0].Rows.Count.Equals(dsTmpCol.Tables[0].Rows.Count))
                        {
                            for (int i = 0; i < dsTmpCol.Tables[0].Rows.Count; i++)
                            {
                                if (!dsMstCol.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim().Equals(dsTmpCol.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim()))
                                {
                                    strColumnError = "1";
                                }
                            }
                        }
                        else
                        {
                            strColumnError = "1";
                        }
                        if (strColumnError == "")
                        {
                            destDir = @Server.MapPath("./UploadFiles");
                            fileName = System.IO.Path.GetFileName(fUpl.PostedFile.FileName + " " + System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
                            destPath = System.IO.Path.Combine(destDir, fileName);
                            fUpl.PostedFile.SaveAs(destPath);

                            if (excelExtention == ".xlsx")
                            {
                                xlsxFormat();
                            }
                            if (dsUpld.Tables.Count > 0)
                            {
                                if (dsUpld.Tables[0].Rows.Count > 0)
                                {
                                    if (dsUpld.Tables[0].Columns.Count.Equals(dsMstCol.Tables[0].Rows.Count))
                                    {
                                        for (int i = 0; i < dsUpld.Tables[0].Columns.Count; i++)
                                        {
                                            if (!dsUpld.Tables[0].Columns[i].ColumnName.ToString().ToUpper().Equals(dsMstCol.Tables[0].Rows[i]["name"].ToString().ToUpper().Trim()))
                                            {
                                                strColumnError = "1";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strColumnError = "1";
                                    }
                                    if (strColumnError == "")
                                    {
                                        htParam.Clear();
                                        htParam.Add("@DocType", strDocType.ToString().Trim());
                                        htParam.Add("@Flag", "1");
                                        strTblName = objDal.execute_sprc_UpdDwnld_with_output("Prc_GetTempHistTbl", htParam, "@TblName");

                                        htParam.Clear();
                                        htParam.Add("@TblName", strTblName);
                                        htParam.Add("@UserId", Session["UserID"].ToString());
                                        batchid = objDal.execute_sprc_UpdDwnld_with_output("Prc_UpdateBatchid", htParam, "@OutBatchid");
                                        //Session["batchid"] = batchid;
                                        hdnBatchID.Value = batchid;
                                        dsUpld.Tables[0].Columns.Add("BatchID", typeof(string));
                                        dsUpld.Tables[0].Columns.Add("UserId", typeof(string));
                                        dsUpld.Tables[0].Columns.Add("Status", typeof(string));
                                        dsUpld.Tables[0].Columns.Add("SeqNo", typeof(string));
                                        dsUpld.Tables[0].Columns.Add("Createby", typeof(string));
                                        dsUpld.Tables[0].Columns.Add("CreatedDTime", typeof(DateTime));
                                        for (int i = 0; i < dsUpld.Tables[0].Rows.Count; i++)
                                        {
                                            dsUpld.Tables[0].Rows[i]["BatchID"] = batchid;
                                            dsUpld.Tables[0].Rows[i]["UserId"] = Session["UserID"].ToString();
                                            dsUpld.Tables[0].Rows[i]["Createby"] = Session["UserID"].ToString();
                                            dsUpld.Tables[0].Rows[i]["CreatedDTime"] = DateTime.Now.ToString();
                                        }
                                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                                        {
                                            bulkCopy.DestinationTableName = strTblName;
                                            bulkCopy.WriteToServer(dsUpld.Tables[0]);
                                        }
                                        //LOG ENTRY
                                        htParam.Clear();
                                        dsLogEntry.Clear();
                                        htParam.Add("@UserId", Session["UserId"].ToString().Trim());
                                        htParam.Add("@RecrdCnt", dsUpld.Tables[0].Rows.Count.ToString());
                                        htParam.Add("@BatchID", batchid.ToString().Trim());
                                        htParam.Add("@Action", "Upd");
                                        htParam.Add("@DocType", strDocType.ToString().Trim());
                                        dsLogEntry = objDal.GetDataSetForPrcUpdDwnld("prc_InsUpldDwnldLog", htParam);

                                        htParam.Clear();
                                        dsLogEntry.Clear();
                                        htParam.Add("@BATCHID", hdnBatchID.Value.ToString());
                                        htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
                                        htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
                                        htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
                                        htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
                                        htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                                        htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
                                        htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
                                        htParam.Add("@RULE_CODE", rulecd.ToString().Trim());
                                        htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
                                        htParam.Add("@CREATED_BY", Session["UserId"].ToString().Trim());
                                        htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
                                        htParam.Add("@PROCNAME", "Prc_cmpHYBKPIUPLD");
                                        htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
                                        htParam.Add("@FLAG", "4");
                                        dsLogEntry = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);

                                        //ddlUpload.Enabled = false;
                                        //fileuploading.Enabled = false;
                                        //ddlUpload.Enabled = false;
                                        //fileuploading.Enabled = false;
                                        fUpl.Visible = false;
                                        ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('File uploaded successfully,please proceed for validation');</script>");
                                    }
                                }
                            }
                        }
                        else if (strColumnError == "1")
                        {
                            /////InsUpldStat(stepcd, rulecd, "3");
                            ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Excel sheet is not valid');</script>");
                            return;
                        }
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('Please choose file to upload');</script>");
                return;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "FileUpload", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    
    #region xlsxFormat
    public void xlsxFormat()
    {
        try
        {
            OleDbConnection connOD;
            OleDbCommand command;
            string strConnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + destPath + ";Extended Properties=\"Excel 12.0;Persist Security Info=False;HDR=NO;IMEX=0;Importmixedtypes=text;typeguessrows=0;FMT=Delimited;\"";
            // string strConnectionstring = "Driver={Driver do Microsoft Excel(*.xlsx)};dbq=" + destPath + ";defaultdir=" + destDir + ";driverid=790;fil=excel 8.0;filedsn=C:\\Program Files\\Common Files\\ODBC\\Data Sources\\Excel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid='" + Session["UserID"].ToString() + "';usercommitsync=Yes";// use to connect to excel for reading data
            connOD = new OleDbConnection(strConnectionstring);
            connOD.Open();
            DataTable objDt = new DataTable();
            OdbcDataAdapter oleda = new OdbcDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = connOD.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            String[] excelSheets = new String[dt.Rows.Count];
            string sheetName = string.Empty;
            if (dt != null)
            {
                excelSheets[0] = dt.Rows[0]["TABLE_NAME"].ToString();
            }
            sheetName = "SELECT * FROM [" + excelSheets[0] + "]";
            command = new OleDbCommand(sheetName, connOD);
            OleDbDataAdapter Da = new OleDbDataAdapter(command);
            Da.Fill(dsUpld);

        }
        catch (Exception Ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "xlsxFormat", Ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion

    protected void Validate(string kpicode, string rulecd, string stepcd)
    {
        try
        {
            htParam.Clear();
            dsLogEntry.Clear();
            htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
            htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
            htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
            htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
            htParam.Add("@RULE_CODE", rulecd.ToString().Trim());
            htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
            htParam.Add("@CREATED_BY", Session["UserId"].ToString().Trim());
            htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
            htParam.Add("@PROCNAME", "Prc_ValidateBulkUpload");
            htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
            htParam.Add("@FLAG", "3");
            dsLogEntry = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);

            DataSet ds = new DataSet();
            htParam.Clear();
            htParam.Add("@BatchId", hdnBatchID.Value.ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            htParam.Add("@DocType", hdnDocType.Value.ToString().Trim());
            strValidate = objDal.execute_sprc_UpdDwnld_with_output("Prc_ValidateBulkUpload", htParam, "@ReturnError");

            if (strValidate == "")
            {
                htParam.Clear();
                dsLogEntry.Clear();
                htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
                htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
                htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
                htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
                htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
                htParam.Add("@RULE_CODE", rulecd.ToString().Trim());
                htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
                htParam.Add("@CREATED_BY", Session["UserId"].ToString().Trim());
                htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
                htParam.Add("@PROCNAME", "Prc_ValidateBulkUpload");
                htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
                htParam.Add("@FLAG", "4");
                dsLogEntry = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);

                ClientScript.RegisterStartupScript(typeof(Page), "Popup", "<script language=javascript>alert('File validated successfully,please proceed for process');</script>");
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
            objErr.LogErr("ISYS-SAIM", "PopBatch", "Validate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void InsUpldStat(string stepcd, string rulecd, string flag)
    {
        try { 
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htBtch.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
        htBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htBtch.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        htBtch.Add("@STEP_CODE", stepcd.ToString().Trim());
        htBtch.Add("@RULE_CODE", rulecd.ToString().Trim());
        //htBtch.Add("@STEP_CODE", hdnStpCd.Value.ToString().Trim());
        //htBtch.Add("@RULE_CODE", hdnRlCodeSb.Value.ToString().Trim());
        htBtch.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
        htBtch.Add("@COMP_FLAG", cmptflag.ToString().Trim());
        dsBtch = objDal.GetDataSetForPrc_SAIM("Prc_InsHybUpload", htBtch);
          }  catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "InsUpldStat", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
           
        }
    
    }

    protected void Process(string cyccd, string cycdesc,string  cmpnstn,string cntstcd, string rskey, 
        string kpicode,string rulcode, string stepcd, string userid, string cmptflag,string rultyp)
    {
        DataSet dsResult = new DataSet();
        Hashtable htFlag = new Hashtable();
        string strTblName = string.Empty;

        try { 
        dsResult.Clear();
        htFlag.Clear();
        htFlag.Add("@Flag", "1");
        htFlag.Add("@batchid", hdnBatchID.Value.ToString());
        htFlag.Add("@DocType", hdnDocType.Value.ToString().Trim());
        dsResult = objDal.GetDataSetForPrcUpdDwnld("Prc_GetValidRecordUpd", htFlag);
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                //Get history table name
                htParam.Clear();
                htParam.Add("@DocType", hdnDocType.Value.ToString().Trim());
                htParam.Add("@Flag", '2');
                strTblName = objDal.execute_sprc_UpdDwnld_with_output("Prc_GetTempHistTbl", htParam, "@TblName");
                if (dsResult.Tables.Count > 0)
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strconn))
                    {
                        bulkCopy.DestinationTableName = strTblName;
                        bulkCopy.WriteToServer(dsResult.Tables[0]);
                    }
                }
            }
        }
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@BATCHID", hdnBatchID.Value.ToString());
        htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
        htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
        htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
        htParam.Add("@RULE_CODE", rulcode.ToString().Trim());
        htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
        htParam.Add("@CREATED_BY", userid.ToString().Trim());
        htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
        htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
        htParam.Add("@PROCNAME", "Prc_cmpHYBKPIUPLD");
        htParam.Add("@FLAG", "1");
        dsResult = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);

        dsResult.Clear();
        htFlag.Clear();
        htFlag.Add("@Flag", "2");
        htFlag.Add("@batchid", hdnBatchID.Value.ToString());
        htFlag.Add("@DocType", hdnDocType.Value.ToString().Trim());
        dsResult = objDal.GetDataSetForPrcUpdDwnld("Prc_GetValidRecordUpd", htFlag);

        //htParam.Clear();
        //dsResult.Clear();
        ////htParam.Add("@BATCHID", hdnBatchID.Value.ToString());
        //htParam.Add("@DOCTYPE", hdnDocType.Value.ToString().Trim());
        //htParam.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        //htParam.Add("@CYCLE_DESC", cycdesc.ToString().Trim());
        //htParam.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        //htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        //htParam.Add("@RULE_SET_KEY", rskey.ToString().Trim());
        //htParam.Add("@KPI_CODE", kpicode.ToString().Trim());
        //htParam.Add("@RULE_CODE", rulcode.ToString().Trim());
        //htParam.Add("@STEP_CODE", stepcd.ToString().Trim());
        //htParam.Add("@CREATED_BY", userid.ToString().Trim());
        //htParam.Add("@COMP_FLAG", cmptflag.ToString().Trim());
        //htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
        //htParam.Add("@FLAG", "2");
        //dsResult = objDal.GetDataSetForPrc_SAIM("Prc_cmpHYBKPIUPLD", htParam);
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "Process", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected string BtchStepValidation(string cyccd, string cmpnstncd, string cntstcd, string rulecd, string rulstky, string rultyp,
        string cmptflg, string stepcd, string kpicode)
    {
        GetCmpDetails();
        string valID = string.Empty;
        string valmsg = string.Empty;
        Hashtable htVal = new Hashtable();
        try { 
        DataSet dsVal = new DataSet();
        htVal.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htVal.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
        htVal.Add("@CYCLE_CODE", cyccd.ToString().Trim());
        htVal.Add("@RULE_TYPE", rultyp.ToString().Trim());
        htVal.Add("@COMPUTE_FLAG", cmptflg.ToString().Trim());
        htVal.Add("@RULE_SET_KEY", rulstky.ToString().Trim());
        htVal.Add("@RULE_CODE", rulecd.ToString().Trim());
        htVal.Add("@STEP_CODE", stepcd.ToString().Trim());
        htVal.Add("@KPI_CODE", kpicode.ToString().Trim());
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "BtchStepValidation", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
        return valmsg.Trim();
    }

    protected string GetBatchID()
    {
        GetCmpDetails();
        string btchID = string.Empty;

        try
        {
        Hashtable htBtch = new Hashtable();
        DataSet dsBtch = new DataSet();
        htBtch.Add("@Flag", "28");
        htBtch.Add("@CMPNSTN_CODE", cmpnstn.ToString().Trim());
        htBtch.Add("@CYCLE_CODE", cyccd.ToString().Trim());
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "GetBatchID", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
        return btchID.Trim();
    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        try
        {
        GetCmpDetails();
        GetCmpDetails(1);
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "D")
            {
                Response.Redirect("PopBatch.aspx?CmpCode=" + cmpnstn.ToString().Trim()
                + "&cntstcd=" + p_cntstcd.ToString().Trim() + "&rskey=" + p_rskey.ToString().Trim() + "&cyccd=" + cyccd.ToString().Trim()
                + "&cycdesc=" + cycdesc.ToString().Trim() + "&rskeydesc=" + p_rskeydesc.ToString().Trim()
                + "&cmptflag=" + p_cmptflag.ToString().Trim() + "&rultyp=" + p_rultyp.ToString().Trim() + "&flag=V&mdlpopup=mdlPopBID", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "doCancel();", true);
        }   
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "btnCncl_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void GetCmpDetails(int val)
    {
        try
        {
        if (Request.QueryString["p_cntstcd"] != null)
        {
            if (Request.QueryString["p_cntstcd"].ToString().Trim() != "")
            {
                p_cntstcd = Request.QueryString["p_cntstcd"].ToString().Trim();
            }
            else
            {
                p_cntstcd = "";
            }
        }
        else
        {
            p_cntstcd = "";
        }

        if (Request.QueryString["p_rskey"] != null)
        {
            if (Request.QueryString["p_rskey"].ToString().Trim() != "")
            {
                p_rskey = Request.QueryString["p_rskey"].ToString().Trim();
            }
            else
            {
                p_rskey = "";
            }
        }
        else
        {
            p_rskey = "";
        }

        if (Request.QueryString["p_rskeydesc"] != null)
        {
            if (Request.QueryString["p_rskeydesc"].ToString().Trim() != "")
            {
                p_rskeydesc = Request.QueryString["p_rskeydesc"].ToString().Trim();
            }
            else
            {
                p_rskeydesc = "";
            }
        }
        else
        {
            p_rskeydesc = "";
        }

        if (Request.QueryString["p_cmptflag"] != null)
        {
            if (Request.QueryString["p_cmptflag"].ToString().Trim() != "")
            {
                p_cmptflag = Request.QueryString["p_cmptflag"].ToString().Trim();
            }
            else
            {
                p_cmptflag = "";
            }
        }
        else
        {
            p_cmptflag = "";
        }

        if (Request.QueryString["p_rultyp"] != null)
        {
            if (Request.QueryString["p_rultyp"].ToString().Trim() != "")
            {
                p_rultyp = Request.QueryString["p_rultyp"].ToString().Trim();
            }
            else
            {
                p_rultyp = "";
            }
        }
        else
        {
            p_rultyp = "";
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "GetCmpDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
    }

    protected void DwnldSumm()
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
                Response.ClearContent();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                /////Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                dsExcel = null;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopBatch", "DwnldSumm", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DwnldSumm();
    }
}
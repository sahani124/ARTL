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

public partial class Application_ISys_Saim_PopSubCntst : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp = string.Empty;
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
                FillCntst(ddlSlsChnl, "CHN", "BizSrc");
                ddlSubCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlContestant.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlSubCnt.Items.Insert(0, new ListItem("-- SELECT --", ""));
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopSubCntst", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dtCnt = new DataTable();
        DataTable dtCntP = new DataTable();
        dtCnt.Columns.Add("SUBCHNDESC");
        dtCnt.Columns.Add("SUB_CHN");
        dtCnt.Columns.Add("SUBCLSDESC");
        dtCnt.Columns.Add("SUB_CHNCLS");
        dtCnt.Columns.Add("MEMTYPE");
        dtCnt.Columns.Add("SUBCNTST");
        dtCnt.Columns.Add("SUBRSKDESC");
        dtCnt.Columns.Add("SUBRSK");

        DataRow dr = dtCnt.NewRow();

        dr["SUBCHNDESC"] = ddlSlsChnl.SelectedItem.Text.ToString().Trim();
        dr["SUB_CHN"] = ddlSlsChnl.SelectedValue.ToString().Trim();
        dr["SUBCLSDESC"] = ddlSubCls.SelectedItem.Text.ToString().Trim();
        dr["SUB_CHNCLS"] = ddlSubCls.SelectedValue.ToString().Trim();
        dr["MEMTYPE"] = ddlContestant.SelectedItem.Text.ToString().Trim();
        dr["SUBCNTST"] = ddlContestant.SelectedValue.ToString().Trim();
        dr["SUBRSKDESC"] = ddlSubCnt.SelectedItem.Text.ToString().Trim();
        dr["SUBRSK"] = ddlSubCnt.SelectedValue.ToString().Trim();

        dtCnt.Rows.Add(dr);
        dtCntP = Session["sbCnt"] as DataTable;
        //if (dtCntP.Rows.Count > 0)
        //{
            dtCntP.Merge(dtCnt, true, MissingSchemaAction.Ignore);
        //}
        Session["sbCnt"] = dtCntP;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('" + value.ToString().Trim() + "');", true);
    }
    protected void ddlContestant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlContestant.SelectedValue != "")
        {
            if (Request.QueryString["cmpnstcd"] != null)
            {
                if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
                }
            }
            if (Request.QueryString["rultyp"] != null)
            {
                value = Request.QueryString["rultyp"].ToString().Trim();
            }
            cntstcd = ddlContestant.SelectedValue.ToString().Trim();
            GetRuleSetKeyDtls(ddlSubCnt, cntstcd);
        }
    }
    protected void ddlSlsChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
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
            value = Request.QueryString["rultyp"].ToString().Trim();
        }

        FillCntst(ddlSubCls, "CHNCLS", "ChnClsVal");
    }
    protected void ddlSubCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
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
            value = Request.QueryString["rultyp"].ToString().Trim();
        }
        FillCntst(ddlContestant, "MEMTYPE", "CNTSTNT_CODE");
    }

    protected void FillCntst(DropDownList ddl, string text, string value)
    {
        DataSet dsCntst = new DataSet();
        Hashtable htCntst = new Hashtable();
        dsCntst.Clear();
        htCntst.Clear();
        ddl.Items.Clear();
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        //if (Request.QueryString["rultyp"] != null)
        //{
        //    value = Request.QueryString["rultyp"].ToString().Trim();
        //}
        htCntst.Add("@PCntstCode", cntstcd.ToString().Trim());
        ////htCntst.Add("@CntstCode", cntstcd.ToString().Trim());
        htCntst.Add("@CmpCode", cmpnstcd.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetSubCntstDtls", htCntst);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }

    public void GetRuleSetKeyDtls(DropDownList ddl,string contestant)
    {
        try
        {
            Hashtable htRsk = new Hashtable();
            DataSet dsRsk = new DataSet();
            htRsk.Clear();
            dsRsk.Clear();
            if (Request.QueryString["cmpnstcd"] != null)
            {
                if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
                }
            }
            //if (Request.QueryString["cntstcd"] != null)
            //{
            //    if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            //    {
            //        cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            //    }
            //}
            cntstcd = contestant.ToString().Trim();

            if (Request.QueryString["rultyp"] != null)
            {
                value = Request.QueryString["rultyp"].ToString().Trim();
            }
            htRsk.Add("@cmpcode", cmpnstcd.Trim());
            htRsk.Add("@cntstcode", cntstcd.Trim());
            htRsk.Add("@flag", "1");
            htRsk.Add("@RuleType", value);
            dsRsk = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleMstDtls", htRsk);
            if (dsRsk.Tables.Count > 0 && dsRsk.Tables[0].Rows.Count > 0)
            {
                ddl.Items.Clear();
                ddl.DataSource = dsRsk;
                ddl.DataTextField = dsRsk.Tables[0].Columns[4].ToString().Trim();
                ddl.DataValueField = dsRsk.Tables[0].Columns[3].ToString().Trim();
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopSubCntst", "GetRuleSetKeyDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
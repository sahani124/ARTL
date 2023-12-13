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

public partial class Application_Isys_Saim_RuleSetPages_FFCntMemFilterDef : BaseClass
{
    DataAccessClass obDAL = new DataAccessClass();
    Hashtable htparam = new Hashtable();
    DataSet ds = new DataSet();
    SqlDataReader drRead;
    DataAccessClass objDal = new DataAccessClass();
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            

            FillDropDowns(ddlISVPSC, "44");
            EditVPSC();
            //FillDropDowns(ddlMapSource, "45");
            //FillRemDropDowns();
        }
    }

    protected void FillRemDropDowns()
    {
        try
        {
            
            
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntMemFilterDef", "FillRemDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            SqlDataReader drRead;
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            drRead = obDAL.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntMemFilterDef", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void EditVPSC()
    {
        Hashtable ht = new Hashtable();
        ds.Clear();
        ht.Clear();

        if (Request.QueryString["RuleId"] != null)
        {
            try
            {
                int strRule = Convert.ToInt16(Request.QueryString["RuleId"]);
                ht.Add("@RuleId", Request.QueryString["RuleId"].ToString());
            }
            catch (Exception ex)
            {
                ht.Add("@RuleId", "0");
            }
        }
        else
        {
            ht.Add("@RecId", "0");
        }

        //PrcGetMST_DateRelatedDef

        ds = objDal.GetDataSetForPrcDBConn("Prc_EditMemFilterDef_WithRecId", ht, "SAIMConnectionString");


        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlISVPSC.SelectedValue = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString();
                ddlISEKYC.SelectedValue = ds.Tables[0].Rows[0]["CNTST_CODE"].ToString();
                ddlRuleSetKey.SelectedValue = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString();
                ddlCycle.SelectedValue = ds.Tables[0].Rows[0]["ACC_CYCLE_CODE"].ToString();
                ddlMapSource.SelectedValue = ds.Tables[0].Rows[0]["MAP_SOURCE"].ToString();
                ddlMapSrcValue.SelectedValue = ds.Tables[0].Rows[0]["MAP_SOURCE_VALUE"].ToString();

                //TextWeightage.Text = ds.Tables[0].Rows[0]["WEIGHTAGE"].ToString();
                //TxtWeg.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        //Policy term To
        //if (TextPolicyTermFrom.Text.Contains(".") == true)
        //{
        //    if (Convert.ToDecimal(TextPolicyTermFrom.Text) > Convert.ToDecimal(TextPolicyTermTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Policy Term From should be less thanPolicy Term To');", true);
        //        return;
        //    }
        //}
        //else if (TextPolicyTermFrom.Text.Contains(".") == false)
        //{
        //    if (Convert.ToInt32(TextPolicyTermFrom.Text) > Convert.ToInt32(TextPolicyTermTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Policy Term From should be less than Policy Term To');", true);
        //        return;
        //    }
        //}

        ////TextPayTermFrom
        //if (ddlfreguency.SelectedValue != "F5")
        //{
        //    if (TextPayTermFrom.Text.Contains(".") == true)
        //    {
        //        if (Convert.ToDecimal(TextPayTermFrom.Text) > Convert.ToDecimal(TextPayTermTo.Text))
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
        //            return;
        //        }
        //    }

        //    //else if (TextPolicyTermFrom.Text.Contains(".") == false)
        //    //{
        //    //    if (Convert.ToInt32(TextPayTermFrom.Text) > Convert.ToInt32(TextPayTermTo.Text))
        //    //    {
        //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
        //    //        return;
        //    //    }
        //    //}
        //}

        ////TextPremiumFrom
        //if (TextPremiumFrom.Text.Contains(".") == true)
        //{
        //    if (Convert.ToDecimal(TextPremiumFrom.Text) > Convert.ToDecimal(TextPremiumTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Premium From Should greater than Pay Premium To');", true);
        //        return;
        //    }
        //}
        //else if (TextPremiumFrom.Text.Contains(".") == false)
        //{
        //    if (Convert.ToInt32(TextPremiumFrom.Text) > Convert.ToInt32(TextPremiumTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Premium From Should greater than Pay Premium To');", true);
        //        return;
        //    }
        //}
        //if (rblSplit.Items[0].Selected == false && rblSplit.Items[1].Selected == false && rblSplit.Items[2].Selected == false)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please select Consider');", true);
        //    return;
        //}
        //---------------End Validation For from and To----------------------



        //htparam.Add("@ProdFreq", ddlfreguency.SelectedValue.ToString().Trim());
        //htparam.Add("@PolFrm", TextPolicyTermFrom.Text.ToString().Trim());
        //htparam.Add("@PolTo", TextPolicyTermTo.Text.ToString().Trim());
        //htparam.Add("@PayFrm", TextPayTermFrom.Text.ToString().Trim());
        //htparam.Add("@PayTo", TextPayTermTo.Text.ToString().Trim());
        //htparam.Add("@PremFrm", TextPremiumFrom.Text.ToString().Trim());
        //htparam.Add("@PremTo", TextPremiumTo.Text.ToString().Trim());
        //htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());

        // ds = obDAL.GetDataSetForPrcDBConn("Prc_ValidateProdStdDefn", htparam, "SAIMConnectionString");
        //if (ds.Tables.Count > 0)
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows[0]["RETURNVALUE"].ToString().Trim() == "1")
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('This rule is already been setup for the product code')", true);
        //            return;
        //        }
        //    }
        //}

        //htparam.Clear();
        //ds.Clear();
        //htparam.Add("@ISVPSC", ddlISVPSC.SelectedValue.Trim());
        //htparam.Add("@ISEKYC", ddlISEKYC.SelectedValue.Trim());

        int strRule;
        string map = Request.QueryString["mapcode"].ToString();
        htparam.Clear();
        if (Request.QueryString["RuleId"] != null && Request.QueryString["RuleId"].ToString() != "undefined")
        {
            try
            {
                if (Request.QueryString["RuleId"] != "")
                {
                    strRule = Convert.ToInt16(Request.QueryString["RuleId"]);
                    htparam.Add("@RecId", Request.QueryString["RuleId"].ToString().Trim());
                }
                else
                {
                    htparam.Add("@RecId", "");
                }
            }
            catch (Exception ex)
            {
                htparam.Add("@RecId", "");

            }
        }
        else
        {
            htparam.Add("@RecId", "");
        }
        //,,,,,,,,,,,)

        // MapCode

        htparam.Add("@MapCode", Request.QueryString["MapCode"].ToString());

        //Selected Data
        htparam.Add("@WHCMPNSTN_CODE", ddlISVPSC.SelectedValue.ToString());
        htparam.Add("@WHCNTST_CODE", ddlISEKYC.SelectedValue.ToString());
        htparam.Add("@WHRULE_SET_KEY", ddlRuleSetKey.SelectedValue.ToString());
        htparam.Add("@WHCYCLE_CODE", ddlCycle.SelectedValue.ToString());
        //Selected Data

        //Original(QueryString) Data
        //htparam.Add("@CMPNSTN_CODE", Request.QueryString["CMPNSTN_CODE"].ToString());
        //htparam.Add("@CNTST_CODE", Request.QueryString["CNTST_CODE"].ToString());

        htparam.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString());
        htparam.Add("@CNTST_CODE", Request.QueryString["cntstcd"].ToString());
        htparam.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString());
        htparam.Add("@CYCLE_CODE", Request.QueryString["CYCLE_CODE"].ToString());
        //Original(QueryString) Data

        htparam.Add("@Consider", RadioButtonList1.SelectedValue.ToString());
        htparam.Add("@MAP_SOURCE", ddlMapSource.SelectedValue.ToString());
        htparam.Add("@MAP_SOURCE_VALUE", ddlMapSrcValue.SelectedValue.ToString());
        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        //htparam.Add("@Weightage", TextWeightage.Text);
        //htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        obDAL.GetDataSetForPrcDBConn("Prc_MEM_FILTERDef_SaveData", htparam, "SAIMConnectionString");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
    }
    protected void ddlISVPSC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlDataReader drRead;
            ddlISEKYC.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", "2");
            ht.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue);
            drRead = obDAL.Common_exec_reader_prc_SAIM("Prc_Fill_Cmp_Cnt_Rule", ht);
            if (drRead.HasRows)
            {
                ddlISEKYC.DataSource = drRead;
                ddlISEKYC.DataTextField = "DESC01";
                ddlISEKYC.DataValueField = "CODE";
                ddlISEKYC.DataBind();
            }
            drRead.Close();
            ddlISEKYC.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillCycles()
    {
        string acc_cycle = "";
        DataTable dt_acc = new DataTable();
        Hashtable ht_acc = new Hashtable();
        ht_acc.Clear();

        dt_acc.Clear();


        ht_acc.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue.ToString());
        ht_acc.Add("@CNTSTN_CODE", ddlISEKYC.ToString().Trim().ToString().Trim());
        ht_acc.Add("@RULE_SET_KEY", ddlRuleSetKey.Text.ToString());

        ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
        if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {

            acc_cycle = ds.Tables[1].Rows[0]["ACC_CYCLE"].ToString();

         //   hdnCount.Value = ds.Tables[0].Rows[0]["COUNT"].ToString().Trim();
            hdnBusiCode.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnFINYEAR.Value = ds.Tables[1].Rows[0]["ACC_YEAR"].ToString().Trim();

        }


        try
        {
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

            FillDropDowns(ddlMapSource, "45");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntMemFilterDef", "FillCycles", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //if (Request.QueryString["compcode"] != null)
            //{
            //    htSrch.Add("@CMPNSTN_CODE", Request.QueryString["compcode"].ToString().Trim());
            //}
            htSrch.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue.ToString().Trim());
            dsSrch = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp_Mem", htSrch);
            if (dsSrch.Tables.Count > 0 && dsSrch.Tables[0].Rows.Count > 0)
            {
                return dsSrch.Tables[0];
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "FFCntMemFilterDef", "Search", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

        return dsSrch.Tables[0];
    }
    protected void ddlISEKYC_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader drReadNew;
        ddlRuleSetKey.Items.Clear();
        Hashtable ht1 = new Hashtable();
        ht1.Add("@Flag", "3");
        ht1.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue);
        ht1.Add("@CNTST_CODE", ddlISEKYC.SelectedValue);
        drReadNew = obDAL.Common_exec_reader_prc_SAIM("Prc_Fill_Cmp_Cnt_Rule", ht1);
        if (drReadNew.HasRows)
        {
            ddlRuleSetKey.DataSource = drReadNew;
            ddlRuleSetKey.DataTextField = "DESC01";
            ddlRuleSetKey.DataValueField = "CODE";
            ddlRuleSetKey.DataBind();
        }
        drReadNew.Close();
        ddlRuleSetKey.Items.Insert(0, new ListItem("-- SELECT --", ""));
    }
    protected void ddlRuleSetKey_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCycles();
    }
    protected void ddlMapSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strMapSrc = ddlMapSource.SelectedValue.ToString().Trim();
        if (strMapSrc == "cmpTRGCATG_ACC_Cycle")
        {
            SqlDataReader drReadNew;
            ddlMapSrcValue.Items.Clear();
            Hashtable ht1 = new Hashtable();
            ht1.Add("@Flag", "1");
            ht1.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue);
            ht1.Add("@CNTSTN_CODE", ddlISEKYC.SelectedValue);
            ht1.Add("@RULE_SET_KEY", ddlRuleSetKey.SelectedValue);
            ht1.Add("@ACC_CYCLE_CODE", ddlCycle.SelectedValue);
            drReadNew = obDAL.Common_exec_reader_prc_SAIM("Prc_GetMapSrcValue", ht1);
            if (drReadNew.HasRows)
            {
                ddlMapSrcValue.DataSource = drReadNew;
                ddlMapSrcValue.DataTextField = "DESC01";
                ddlMapSrcValue.DataValueField = "CODE";
                ddlMapSrcValue.DataBind();
            }
            drReadNew.Close();
            ddlMapSrcValue.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        else if (strMapSrc == "CmpTRGRWD_ACC_Cycle")
        {
            SqlDataReader drReadNew;
            ddlMapSrcValue.Items.Clear();
            Hashtable ht1 = new Hashtable();
            ht1.Add("@Flag", "2");
            ht1.Add("@CMPNSTN_CODE", ddlISVPSC.SelectedValue);
            ht1.Add("@CNTSTN_CODE", ddlISEKYC.SelectedValue);
            ht1.Add("@RULE_SET_KEY", ddlRuleSetKey.SelectedValue);
            ht1.Add("@ACC_CYCLE_CODE", ddlCycle.SelectedValue);
            drReadNew = obDAL.Common_exec_reader_prc_SAIM("Prc_GetMapSrcValue", ht1);
            if (drReadNew.HasRows)
            {
                ddlMapSrcValue.DataSource = drReadNew;
                ddlMapSrcValue.DataTextField = "DESC01";
                ddlMapSrcValue.DataValueField = "CODE";
                ddlMapSrcValue.DataBind();
            }
            drReadNew.Close();
            ddlMapSrcValue.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
    }
}
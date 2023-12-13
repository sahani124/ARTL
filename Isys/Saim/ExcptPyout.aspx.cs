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

public partial class Application_ISys_Saim_ExcptPyout : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string sUserId = string.Empty;

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
                FillDropDowns(ddlChnl, "1", "", "", "");
                ddlSubChnl.Items.Insert(0, new ListItem("Select", ""));
                ddlMemTyp.Items.Insert(0, new ListItem("Select", ""));
                ddlCommRul.Items.Insert(0, new ListItem("Select", ""));
                FillDropDowns(ddlProdCod, "5", "", "", "");
                FillDropDowns(ddlSupCod, "6", "", "", "");
                ddlCommCyc.Items.Insert(0, new ListItem("Select", ""));
            }

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
    protected void FillDropDowns(DropDownList ddl, string val, string firstvalue, string secondvalue, string thirdvalue)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            if (ddl == ddlSubChnl)
            {
                ht.Add("@Channel", firstvalue.ToString().Trim());
            }
            else if (ddl == ddlMemTyp)
            {
                ht.Add("@SubChannel", firstvalue.ToString().Trim());
            }
            else if (ddl == ddlCommRul)
            {
                ht.Add("@Channel", firstvalue.ToString().Trim());
                ht.Add("@SubChannel", secondvalue.ToString().Trim());
                ht.Add("@Memtyp", thirdvalue.ToString().Trim());
            }
            else if (ddl == ddlCommCyc)
            {
                ht.Add("@RulsetCd", firstvalue.ToString().Trim());
            }
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals_Excp", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));
            drRead.Close();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDropDowns(ddlSubChnl, "2", ddlChnl.SelectedValue.ToString().Trim(), "", "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "ddlChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlSubChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDropDowns(ddlMemTyp, "3", ddlSubChnl.SelectedValue.ToString().Trim(), "", "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "ddlSubChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlMemTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDropDowns(ddlCommRul, "4", ddlChnl.SelectedValue.ToString().Trim(), ddlSubChnl.SelectedValue.ToString().Trim(), ddlMemTyp.SelectedValue.ToString().Trim());
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "ddlSubChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlCommRul_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillMulDropDowns(ddlAgentCod, "7", ddlChnl.SelectedValue.ToString().Trim(), ddlSubChnl.SelectedValue.ToString().Trim(), ddlMemTyp.SelectedValue.ToString().Trim(), ddlCommRul.SelectedValue.ToString().Trim());
            FillDropDowns(ddlCommCyc, "9", ddlCommRul.SelectedValue.ToString().Trim(), "", "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "ddlChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlAgentCod_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string AgentCd = string.Empty;
            foreach (ListItem item in this.ddlAgentCod.Items)
            {

                if (item.Selected)
                {
                    AgentCd += item.Value + ",";
                }
            }
            AgentCd = AgentCd.TrimEnd(',');
            FillMulDropDowns(ddlPolicies, "8", AgentCd.ToString().Trim(), "", "", "");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "ddlChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillMulDropDowns(ListBox ddl, string val, string firstvalue, string secondvalue, string thirdvalue, string fourthvalue)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            if (ddl == ddlAgentCod)
            {
                ht.Add("@Channel", firstvalue.ToString().Trim());
                ht.Add("@SubChannel", secondvalue.ToString().Trim());
                ht.Add("@Memtyp", thirdvalue.ToString().Trim());
                ht.Add("@RulsetCd", fourthvalue.ToString().Trim());
            }
            else if (ddl == ddlPolicies)
            {
                ht.Add("@AgentCd", firstvalue.ToString().Trim());
            }

            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals_Excp", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindgvAddMst();
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
    protected void BindgvAddMst()
    {
        try
        {
            string AgentCd = string.Empty;
            //foreach (ListItem item in this.ddlAgentCod.Items)
            //{

            //    if (item.Selected)
            //    {
            //        AgentCd += item.Value + ",";
            //    }
            //}
            //AgentCd = AgentCd.TrimEnd(',');
            AgentCd = hdnMemCode.Value;
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            if (ddlChnl.SelectedIndex > 0)
            { 
            htParam.Add("@Channel", ddlChnl.SelectedValue.ToString().Trim());
            }
            if (ddlSubChnl.SelectedIndex>0)
            {
                htParam.Add("@SubChannel", ddlSubChnl.SelectedValue.ToString().Trim());

            }
            if (ddlMemTyp.SelectedIndex > 0)
            {
                htParam.Add("@Memtyp", ddlMemTyp.SelectedValue.ToString().Trim());

            }
            if (ddlCommRul.SelectedIndex > 0)
            {
                htParam.Add("@RulsetCd", ddlCommRul.SelectedValue.ToString().Trim());

            }
            if (ddlProdCod.SelectedIndex > 0)
            {
                htParam.Add("@ProdCode", ddlProdCod.SelectedValue.ToString().Trim());
            }
            if (hdnMemCode.Value!="")
            {
                htParam.Add("@AgentCd", AgentCd.ToString().Trim());
            }
            if (ddlCommCyc.SelectedIndex > 0)
            {
                htParam.Add("@CommCyc", ddlCommCyc.SelectedValue.ToString().Trim());
            }


            //htParam.Add("@SupCode",ddlSupCod.SelectedValue.ToString().Trim());

           
            ds = objDal.GetDataSetForPrc_SAIM("Prc_BindgvAddMst_Excp", htParam);
            //gvAddMst.DataSource = ds;
            //gvAddMst.DataBind();

            dgCmp.DataSource = ds;
            dgCmp.DataBind();

            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (gvAddMst.PageCount > 1)
                    {
                        gvAddMst.Enabled = true;
                        gvAddMst.Enabled = false;
                    }
                    else
                    {
                        gvAddMst.Enabled = false;
                        gvAddMst.Enabled = false;
                    }

                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "GetSrcTblData", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgReward_RowDataBound(object sender, GridViewRowEventArgs e)
    {

       // CheckBox chk= (CheckBox)e.Row.FindControl("chkOne");

       // Label lbl2 =(Lable)e.Row

             Label lblMEM_CODE = (Label)e.Row.FindControl("lblPolNum");
        //chk.Checked = true;
    }

        protected void gvAddMst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMEM_CODE = (Label)e.Row.FindControl("lblMEM_CODE2");
                Label lblCycCode = (Label)e.Row.FindControl("lblCycCode");
                Label lblRuleSetKey = (Label)e.Row.FindControl("lblRuleSetKey");
                GridView grd = (GridView)e.Row.FindControl("dgReward2");
                BinddgReward(lblMEM_CODE.Text.ToString(), lblCycCode.Text.ToString(), lblRuleSetKey.Text.ToString(),grd);
            }

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

    protected void BinddgReward(string MEM_CODE, string CYCLE_CODE, string RULE_SET_KEY,GridView grd)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@AgentCd", MEM_CODE.ToString().Trim());
            htParam.Add("@CommCyc", CYCLE_CODE.ToString().Trim());
            htParam.Add("@RulsetCd", RULE_SET_KEY.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_BinddgReward_Excp", htParam);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgReward.DataSource = ds;
                    dgReward.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "BinddgReward", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void chkLeftAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < dgReward.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(dgReward.Rows[i].FindControl("chkOne"));
                CheckBox allchk = (CheckBox)sender;
                chk.Checked = allchk.Checked;
            }
            dgReward.HeaderRow.TableSection = TableRowSection.TableHeader;
            dgReward.UseAccessibleHeader = true;

            dgReward.HeaderRow.TableSection = TableRowSection.TableHeader;
            dgReward.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "ExcptPyout", "chkLeftAll_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

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
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {

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
    //End
}



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
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.IO;

public partial class Application_Isys_Saim_RwrdBulkUpd : BaseClass
{
    DataSet ds = new DataSet();
    DataSet dsResult = new DataSet();
    DataSet dsNew1 = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    Microsoft.Office.Interop.Excel.Application excel;
    Microsoft.Office.Interop.Excel.Workbook worKbooK;
    Microsoft.Office.Interop.Excel.Worksheet worksheet;
    Microsoft.Office.Interop.Excel.Range celLrangE;
    public string CmpCode = string.Empty;
    public string CntCode = string.Empty;
    string KPICode = string.Empty;
    string KPICode1 = string.Empty;
    public string RuleSetKey = string.Empty;
    string RULECode = string.Empty;
    string strBatchId = string.Empty;
    string acc_cycle = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //GetRWDMstDtls();
        if (!IsPostBack)
        {
           
            CmpCode = Request.QueryString["CmpCode"].ToString().Trim();
            CntCode = Request.QueryString["CntstCode"].ToString().Trim();
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                RuleSetKey = ddlRuleSetCode.SelectedItem.Text.ToString().Trim();
                ShowRulStKy();//Added by usha 
            }
            FillDropDowns(ddlFrom, "24", "");
            FillDropDowns(ddlTo, "24", "");
            FillDropDowns1(DropDownList1, "24", "");
            FillDropDowns1(DropDownList2, "24", "");
            FillDropDownsRuleSet(ddlRuleSetCode, "24", "");

            //Reward ddl
            FillRwrdRulDropDowns(ddlRwdType, "21");
            ddlRwdType.SelectedIndex = 1;
            ddlRwdType.Enabled = false;

            FillRwrdRulDropDowns(ddlType, "1");
            //txtRwdCode.Enabled = false;
            txtRwdCode.ReadOnly = true;
            ShowRwdCode();
            GetRWDMstDtls();
            ddlKPICode.Items.Insert(0, new ListItem("--SELECT--", ""));
            // BindRwrdDetails();
            //Reward ddl

            //BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            // BindRwdRul("P");
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val, string typflg)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@TYPFLG", typflg.ToString().Trim());
            ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetMemberMonths", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns1(DropDownList ddl, string val, string typflg)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@TYPFLG", typflg.ToString().Trim());
            ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetMemberCycles", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "FillDropDowns1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDownsRuleSet(DropDownList ddl, string val, string typflg)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@TYPFLG", typflg.ToString().Trim());
            ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@cmpcode", Request.QueryString["CmpCode"].ToString().Trim());
            ht.Add("@cntstcode", Request.QueryString["CntstCode"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetRuleSetCodes", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));

            }
            drRead.Close();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "FillDropDownsRuleSet", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(GridView gv, Button btnP, Button btnN, CheckBox chk, HtmlGenericControl div, string rultyp, HtmlGenericControl divchk)
    {

        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();

            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());

            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();

                if (gv == gvAddMst)
                {
                    ViewState["gvAddMst"] = ds.Tables[0];
                }
                //if (gv == dgQual)
                //{
                //    ViewState["dgQual"] = ds.Tables[0];
                //}
                //<Bhau added>



                /////hdnKPICnt.Value = ds.Tables[0].Rows.Count.ToString().Trim();
                div.Style.Add("display", "block");
                divchk.Style.Add("display", "none");
                chk.Checked = true;
                if (gv.PageCount > 1)
                {
                    btnN.Enabled = true;
                }
                else
                {
                    btnN.Enabled = false;
                    btnP.Enabled = false;
                }
            }
            else
            {
                ShowNoResultFound(ds.Tables[0], gv);
                gv.Columns[11].Visible = false;
                gv.Columns[12].Visible = false;


                if (chkRwd.Checked == true)
                {

                    divRwd.Style.Add("display", "block");
                }
                else
                {
                    chk.Checked = false;
                    div.Style.Add("display", "none");
                }
                divchk.Style.Add("display", "none");


            }
            Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid1(GridView gv, Button btnP, Button btnN, CheckBox chk, HtmlGenericControl div, string rultyp, HtmlGenericControl divchk, string ddlValue)
    {
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            if (ddlValue != null)
            {
                htParam.Add("@RuleType", rultyp.ToString().Trim());
                htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
                htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                htParam.Add("@RulStKey", ddlValue);
            }

            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htParam);
            KPICode = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
            KPICode = KPICode.Substring(0, 8);
            Session["KPI_Code"] = KPICode;

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();

                if (gv == dgReward)
                {
                    ViewState["dgReward"] = ds.Tables[0];
                }
                //if (gv == dgQual)
                //{
                //    ViewState["dgQual"] = ds.Tables[0];
                //}
                //<Bhau added>
                gv.Columns[11].Visible = true;
                gv.Columns[12].Visible = true;
                gv.Columns[13].Visible = true;
                gv.Columns[14].Visible = true;
                /////hdnKPICnt.Value = ds.Tables[0].Rows.Count.ToString().Trim();
                //div.Style.Add("display", "block");
                // divchk.Style.Add("display", "block");
                chk.Checked = true;
                if (gv.PageCount > 1)
                {
                    btnN.Enabled = true;
                }
                else
                {
                    btnN.Enabled = false;
                    btnP.Enabled = false;
                }
                //LinkButton1.Enabled = true;
            }
            else
            {
                ShowNoResultFound(ds.Tables[0], gv);
                gv.Columns[11].Visible = false;
                gv.Columns[12].Visible = false;
                gv.Columns[13].Visible = false;
                gv.Columns[14].Visible = true;

                if (chkRwd.Checked == true)
                {

                    divRwd.Style.Add("display", "block");
                }
                else
                {
                    chk.Checked = false;
                    div.Style.Add("display", "none");
                }
                // divchk.Style.Add("display", "block");

                //btnSaveFn.Enabled = false;
            }
            Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindGrid1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            gv.Rows[0].Cells[columnsCount - 3].Text = "";
            gv.Rows[0].Cells[0].Text = "No rules have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgReward_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = (DataTable)ViewState["dgReward"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtPageRwd.Text))
            {
                btnprevrwd.Enabled = false;
                txtPageRwd.Text = "1";
                btnnextrwd.Enabled = true;
            }
            else
            {
                btnnextrwd.Enabled = false;
            }
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgReward_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgReward_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblCode = (LinkButton)e.Row.FindControl("lblRulCode");
                LinkButton lnkEditRwd = (LinkButton)e.Row.FindControl("lnkEditRwd");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                LinkButton lnkKPISetRule = (LinkButton)e.Row.FindControl("lnkKPISetRule");




                Label lblRulSetKey = (Label)e.Row.FindControl("lblRulStKy");
                //hdnRulSetKy.Value = lblRulSetKey.Text.ToString().Trim();
                ////lnkEditRwd.Attributes.Add("onclick", "funEditPopUp('divRwd','R','" + lblCode.Text + "','grid');return false;");
                HiddenField hdnKpiOrg = (HiddenField)e.Row.FindControl("hdnKpiOrg");
                if (hdnKpiOrg.Value == "1002")
                {
                    lblCode.Enabled = true;
                }
                else
                {
                    lblCode.Enabled = false;
                }
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEditRwd.Enabled = false;
                        lnkDelete.Enabled = false;
                        lnkKPISetRule.Enabled = false;
                    }
                }
                lnkEditRwd.Attributes.Add("onclick", "funEditPopUp('divRwd','R','" + lblCode.Text + "','grid');return false;");
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgReward_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnlSearchbyRuleSet_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                //BindGrid(gvAddMst, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
                //BindTrg();
                //BindTrg();
                //BindGrid1(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd, ddlRuleSetCode.SelectedValue.ToString().Trim());
                //BindRwdTrg();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Select Rule Set Dropdown ');", true);
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "lnlSearchbyRuleSet_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsNew = new DataSet();
            string KPICode2 = string.Empty;
            string strMonthFrom = ddlFrom.SelectedItem.Text.ToString().Trim();
            string strMonthTo = ddlTo.SelectedItem.Text.ToString().Trim();
            strMonthFrom = strMonthFrom.Remove(0, 1);
            strMonthTo = strMonthTo.Remove(0, 1);
            int total = (Convert.ToInt32(strMonthTo) - Convert.ToInt32(strMonthFrom)) + 1;
            int count = Convert.ToInt32(txtcount.Text);
            DataSet dsCycle = new DataSet();
            htParam.Clear();
            dsCycle.Clear();
            htParam.Add("@FROM", DropDownList1.SelectedValue.ToString().Trim());
            htParam.Add("@TO", DropDownList2.SelectedValue.ToString().Trim());
            dsCycle = objDal.GetDataSetForPrc_SAIM("Prc_GetCycleDifference", htParam);

            DataSet dsKPICount = new DataSet();
            htParam.Clear();
            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
            dsKPICount = objDal.GetDataSetForPrc_SAIM("Prc_getNoOfKPIagainstRULESET", htParam);

            string strCheckCount = string.Empty;

            //Added for Upd Dwnld Batchid
            htParam.Clear();
            htParam.Add("@DocType", "DNKPITRG");
            strBatchId = objDal.execute_sprc_UpdDwnld_with_output("Prc_UpdtBatchId", htParam, "@Batch");
            hdnBatchId.Value = strBatchId.Trim();

            //Added for Upd Dwnld Batchid


            for (int kpi = 0; kpi < dsKPICount.Tables[0].Rows.Count; kpi++)
            {
                KPICode1 = dsKPICount.Tables[0].Rows[kpi]["KPI_CODE"].ToString().Trim();
                KPICode1 = KPICode1.Replace(@"-", string.Empty);
                Session["KPI_Code1"] = KPICode1;
                RULECode = dsKPICount.Tables[0].Rows[kpi]["RULE_CODE"].ToString().Trim();

                KPICode2 = dsKPICount.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                KPICode2 = KPICode1.Substring(0, 8);
                Session["KPI_Code2"] = KPICode2;

                if (kpi == 1)
                {
                    htParam.Clear();

                    htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
                    htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                    //htParam.Add("@RuleType", "R");
                    htParam.Add("@RulStKey", ddlRuleSetCode.SelectedItem.Text.ToString().Trim());
                    dsNew = objDal.GetDataSetForPrc_SAIM("Prc_GetCATG_CODEForBulUpload", htParam);

                }
                int countdr = 0;
                int counter = 0;
                for (int k = 0; k < dsCycle.Tables[0].Rows.Count; k++)
                {
                    if (CheckBox1.Checked == true)
                    {
                        if (k == 1)
                        {
                            htParam.Clear();

                            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
                            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                            //htParam.Add("@RuleType", "R");
                            htParam.Add("@RulStKey", ddlRuleSetCode.SelectedItem.Text.ToString().Trim());
                            dsNew1 = objDal.GetDataSetForPrc_SAIM("Prc_GetCATG_CODEForBulUpload", htParam);

                        }
                    }
                    string cycleCode = dsCycle.Tables[0].Rows[k]["BUSI_CODE"].ToString().Trim();

                    for (int i = 0; i < count; i++)
                    {


                        for (int j = 0; j < total; j++)
                        {
                            string Slab = ("Slab" + (i + 1));
                            htParam.Clear();
                            string Month = ("M" + (Convert.ToInt32(strMonthFrom) + j));
                            Slab = Slab + " - " + Month;
                            htParam.Add("@Slab", Slab);
                            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
                            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                            htParam.Add("@RuleType", "R");
                            htParam.Add("@RulStKey", ddlRuleSetCode.SelectedItem.Text.ToString().Trim());


                            if (CheckBox1.Checked == true)
                            {

                                if (kpi != 0)
                                {
                                    //for (int p = 0; p < kpi; p++)
                                    //{
                                    htParam.Add("@rdFlag", "2");

                                    htParam.Add("@CATEGORY", dsNew.Tables[0].Rows[countdr]["CATG_CODE"].ToString());
                                    countdr = countdr + 1;
                                    //    break;
                                    //}
                                }

                                else if (k != 0 && kpi == 0)
                                {
                                    htParam.Add("@rdFlag", "2");

                                    htParam.Add("@CATEGORY", dsNew1.Tables[0].Rows[counter]["CATG_CODE"].ToString());
                                    counter = counter + 1;
                                }
                                else
                                {
                                    htParam.Add("@rdFlag", "1");
                                    htParam.Add("@CATEGORY", "");
                                }
                            }
                            else
                            {
                                if (kpi != 0)
                                {
                                    //for (int p = 0; p < kpi; p++)
                                    //{
                                    htParam.Add("@rdFlag", "2");

                                    htParam.Add("@CATEGORY", dsNew.Tables[0].Rows[countdr]["CATG_CODE"].ToString());
                                    countdr = countdr + 1;
                                    //    break;
                                    //}
                                }
                                else
                                {
                                    htParam.Add("@rdFlag", "1");
                                    htParam.Add("@CATEGORY", "");
                                }
                            }
                            htParam.Add("@RuleCode", RULECode);
                            htParam.Add("@CYCLE_CODE", cycleCode);
                            htParam.Add("@KPI_CODE", KPICode1);
                            htParam.Add("@CATSET", "1");
                            htParam.Add("@SORT", "1190");
                            htParam.Add("@EFF_FROM", DropDownList1.SelectedValue);
                            htParam.Add("@EFF_TO", DropDownList2.SelectedValue);
                            htParam.Add("@TRGFRM", "");
                            htParam.Add("@TRGTO", "");
                            htParam.Add("@STATUSFLAG", "P");
                            htParam.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString());
                            //htParam.Add("@CREATEDDTIM", "");
                            htParam.Add("@P_EXCL", "");
                            htParam.Add("@S_EXCL", "");
                            htParam.Add("@IS_STDDFN", "");
                            htParam.Add("@MIN_WEIGHTED", "");
                            htParam.Add("@MAX_WEIGHTED", "");
                            htParam.Add("@WEIGHTED", "");
                            htParam.Add("@MEMBER_CYCLE", Month);
                            htParam.Add("@MEMBER_CODE", "");
                            //Added By daksh for Upd Dwnld BatchId
                            htParam.Add("@BatchId", strBatchId);
                            //Added By daksh for Upd Dwnld BatchId
                            ds.Clear();
                            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTmp_Cmpnstn_Cntstnt_KPI_Trgt", htParam);
                            htParam.Clear();
                            Month = string.Empty;
                            Slab = string.Empty;
                            //if (Session["KPI_Code1"] != Session["KPI_Code2"])
                            //{
                            //    break;
                            //}

                        }

                    }
                }
            }

            BindRwdTrg();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('DATA Generated SUCCESSFULLY.');", true);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "LinkButton1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindRwdTrg()
    {
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
            }
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetTargetsAgnstCode", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgRwdTrg.DataSource = ds;
                dgRwdTrg.DataBind();
                ViewState["dgRwdTrg"] = ds.Tables[0];
                BtnDownloadExcel.Enabled = true;

                //LinkButton1.Visible = false;
                BtnDownloadExcel.Visible = true;

                //LinkButton1.Attributes.Add("style", "display: none;");
                //BtnDownloadExcel.Attributes.Add("style", "display: block;");

                //BtnDownloadExcel.Attributes.Add("enabled", "enabled");
                if (dgRwdTrg.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
                {
                    btnnextrwdtrg.Enabled = true;
                }
                else
                {
                    btnnextrwdtrg.Enabled = false;
                }

                dgRwdTrg.Columns[13].Visible = true;
                dgRwdTrg.Columns[14].Visible = true;
                dgRwdTrg.Columns[15].Visible = true;

            }
            else
            {
                //LinkButton1.Visible = true;
                BtnDownloadExcel.Visible = false;

                //LinkButton1.Attributes.Add("style", "display: block;");
                //BtnDownloadExcel.Attributes.Add("style", "display: none;");

                ShowNoRecQualTrg(ds.Tables[0], dgRwdTrg);
                dgRwdTrg.Columns[13].Visible = false;
                // dgRwdTrg.Columns[14].Visible = false;//Comented by usha
                // dgRwdTrg.Columns[15].Visible = true; //changed by akash //Comented by usha on 27.01.2020

                txtpgrwdtrg.Text = "1";
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;
            }
            Session["gridTrg"] = ds.Tables[0];
            Session["gridTrg1"] = ds.Tables[1];
            Session["TblRowCount"] = 0;
            ViewState["TblRowCount1"] = 0;
            ////Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindRwdTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgRwdTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
                LinkButton lnkDelRwdTrg = (LinkButton)e.Row.FindControl("lnkDelRwdTrg");
                LinkButton lnkKPITrgtSetRule = (LinkButton)e.Row.FindControl("lnkKPITrgtSetRule");
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEditRwdTrg.Enabled = false;
                        lnkDelRwdTrg.Enabled = false;
                        lnkKPITrgtSetRule.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgRwdTrg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgRwdTrg_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = (DataTable)ViewState["dgRwdTrg"];
            //ViewState["gridqualtrg"];
            //ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtpgrwdtrg.Text))
            {
                btnprevrwdtrg.Enabled = false;
                txtpgrwdtrg.Text = "1";
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
            }
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgRwdTrg_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ShowNoRecQualTrg(DataTable source, GridView gv)
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
            gv.Rows[0].Cells[columnsCount - 3].Text = "";
            gv.Rows[0].Cells[0].Text = "No targets have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ShowNoRecQualTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnprevrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdTrg.PageIndex;
            dgRwdTrg.PageIndex = pageIndex - 1;
            BindRwdTrg();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprevrwdtrg.Enabled = false;
            }
            else
            {
                btnprevrwdtrg.Enabled = true;
            }
            btnnextrwdtrg.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "btnprevrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnextrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdTrg.PageIndex;
            dgRwdTrg.PageIndex = pageIndex + 1;
            BindRwdTrg();

            btnprevrwdtrg.Enabled = true;
            if (txtpgrwdtrg.Text == Convert.ToString(dgRwdTrg.PageCount))
            {
                btnnextrwdtrg.Enabled = false;
            }
            else
            {
                txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            }

            int page = dgRwdTrg.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "btnnextrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BtnDownloadExcel_Click(object sender, EventArgs e)
    {
        Hashtable hparam = new Hashtable();
        htParam.Clear();
        dsResult.Clear();


        //if (ddlRuleSetCode.SelectedValue.ToString().Trim() == "")
        //{
           
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select rule set');", true);
        //    return;

        //}

        //else 
        if (ddlRuleSetCode.SelectedIndex > 0)
        {
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
            htParam.Add("@BatchID", hdnBatchId.Value);
            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_Get_GeneratedRwrdDtls", htParam);
            if (dsResult.Tables.Count > 0)
            {
                ExportCSV(dsResult.Tables[0], ddlRuleSetCode.SelectedValue.ToString().Trim() + "_" + "KPI_Rewards");

            }
        }
        
    }

    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");



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
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
            htParam.Add("@BatchID", hdnBatchId.Value);
            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetRwrdBatchagainstRuleSetKey", htParam);
            string RuleSetKey = dsResult.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            string BatchID = dsResult.Tables[0].Rows[0]["BatchId"].ToString().Trim();
            if (dsResult.Tables[0].Rows.Count != 0)
            {
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@RulStKey", RuleSetKey);
                htParam.Add("@BatchId", BatchID);
                dsResult = objDal.GetDataSetForPrc_SAIM("Prc_TX_Tmp_Cntstnt_KPI_Rwrd_Rul_hist", htParam);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return Rest;


    }

    //protected void BtnDownloadExcel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlRuleSetCode.SelectedIndex == 0)
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Code Dropdown')", true);
    //        }
    //        else
    //        {
    //            Hashtable hparam = new Hashtable();
    //            htParam.Clear();
    //            dsResult.Clear();
    //            if (ddlRuleSetCode.SelectedIndex > 0)
    //            {
    //                htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
    //            }
    //            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetTargetsAgnstCode", htParam);
    //            excel = new Microsoft.Office.Interop.Excel.Application();
    //            excel.Visible = false;
    //            excel.DisplayAlerts = false;
    //            worKbooK = excel.Workbooks.Add(Type.Missing);


    //            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
    //            DataSet dsQuestion = new DataSet();
    //            Hashtable hTable = new Hashtable();

    //            dsQuestion = dsResult;

    //            for (int i = 0; i < dsQuestion.Tables[0].Columns.Count; i++)
    //            {
    //                worksheet.Cells[1, i + 1] = dsQuestion.Tables[0].Columns[i].ColumnName;
    //                //worksheet.Cells[1, i + 1].Font.Color = System.Drawing.Color.Black;
    //                //worksheet.Cells[1, i + 1].Font.FontStyle = System.Drawing.FontStyle.Bold;
    //                //worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.Color.Yellow;
    //            }

    //            for (int i = 0; i < dsQuestion.Tables[0].Rows.Count; i++)
    //            {
    //                for (int j = 0; j < dsQuestion.Tables[0].Columns.Count; j++)
    //                {
    //                    worksheet.Cells[2 + i, j + 1] = dsQuestion.Tables[0].Rows[i][j];
    //                }
    //            }


    //            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
    //            celLrangE.EntireColumn.AutoFit();
    //            //celLrangE.EntireColumn[2].Hidden = true;
    //            //worksheet.Columns[2].Hidden = True;
    //            //celLrangE.EntireColumn[3].Locked = true;

    //            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
    //            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
    //            border.Weight = 2d;

    //            celLrangE = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dsQuestion.Tables[0].Rows.Count + 1, dsQuestion.Tables[0].Columns.Count]];
    //            Missing mv = Missing.Value;
    //            worksheet.Columns.Locked = false;
    //            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 1], (object)worksheet.Cells[1, 12])).EntireColumn.Locked = true;
    //            ((Microsoft.Office.Interop.Excel.Range)worksheet.get_Range((object)worksheet.Cells[1, 15], (object)worksheet.Cells[1, 36])).EntireColumn.Locked = true;
    //            worksheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlUnlockedCells;
    //            worksheet.Protect(mv, mv, mv, mv, mv, false, mv, mv, mv, mv, mv, mv, mv, mv, mv, mv);
    //            // btnBlkCatgUpd.Enabled = true;
    //            string tempPath = "E:\\Daksh1.xlsx";

    //            worKbooK.SaveAs(tempPath, worKbooK.FileFormat);//create temporary file from the workbook
    //            tempPath = worKbooK.FullName;

    //            //worKbooK.SaveAs(saveExcel(), Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, mv, mv, mv, mv, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, mv, mv, mv, mv, mv);
    //            //worKbooK.sa("my-workbook.xls");
    //            //worKbooK.SaveAs("E:\\Das.xlsx");
    //            worKbooK.Close();
    //            byte[] result = File.ReadAllBytes(tempPath);//change to byte[]

    //            excel.Quit();

    //            //added by daksh for upd dwnld 
    //            htParam.Clear();
    //            dsResult.Clear();
    //            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
    //            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetBatchagainstRuleSetKey", htParam);
    //            string RuleSetKey = dsResult.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
    //            string BatchID = dsResult.Tables[0].Rows[0]["BatchId"].ToString().Trim();
    //            if (dsResult.Tables[0].Rows.Count != 0)
    //            {
    //                htParam.Clear();
    //                dsResult.Clear();
    //                htParam.Add("@RulStKey", RuleSetKey);
    //                htParam.Add("@BatchId", BatchID);
    //                dsResult = objDal.GetDataSetForPrc_SAIM("Prc_TX_InsTmp_Cmpnstn_Cntstnt_KPI_Trgt_hist", htParam);
    //            }
    //            //added by daksh for upd dwnld 


    //            FileInfo file = new FileInfo(tempPath);
    //            if (file.Exists)
    //            {
    //                try
    //                {
    //                    string FileName = ddlRuleSetCode.SelectedValue.ToString().Trim() + "_" + "KPI_Target";
    //                    //btnBlkCatgUpd.Visible = true;
    //                    Response.Clear();
    //                    Response.ClearHeaders();
    //                    Response.ClearContent();
    //                    Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xlsx");
    //                    Response.AddHeader("Content-Type", "application/Excel");
    //                    Response.ContentType = "application/vnd.xls";
    //                    Response.AddHeader("Content-Length", file.Length.ToString());
    //                    Response.WriteFile(file.FullName);
    //                    Response.End();
    //                }
    //                catch
    //                {

    //                }
    //            }
    //            else
    //            {
    //                Response.Write("This file does not exist.");
    //            }
    //        }
    //        //KMICommon CommObj = new KMICommon();
    //        //HttpContext.Current.Session["popupdataSet"] = dsResult.Tables[0];
    //        //Response.Redirect("../../downloadexl.aspx?popupdataSet=y&reportName=" + FileName.Value);
    //        //int pop = (int)(PopupType)Enum.Parse(typeof(PopupType), popupType.Value);
    //        //CommObj.ExportCSV(ds.Tables[0], FileName.Value + "_" + DateTime.Now);
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    public string saveExcel()
    {
        System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();// Create save the CSV
        sfd.Filter = "Text File|*.xls";// filters for text files only
        sfd.DefaultExt = "xls";
        sfd.AddExtension = true;
        sfd.FileName = "AutodeskScripts.xls";
        sfd.Title = "Save Excel File";
        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            return sfd.FileName;
        }
        else
        {
            return null;
        }
    }

    protected void btnBlkCatgUpd_Click(object sender, EventArgs e)
    {

        try
        {
            //if (ddlRuleSetKy.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Key')", true);
            //    return;
            //}Request.QueryString["CmpCode"].ToString().Trim());

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupDataSynchHybrid('" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "');", true);

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "btnBlkCatgUpd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvAddMst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DataTable dt = new DataTable();
                //if (Session["RwdRul"] != null)
                //{
                //    ////dt = Session["RwdRul"] as DataTable;


                //dt = ViewState["dgRwdRul"] as DataTable;
                Label lblRuleSetCode = (Label)e.Row.FindControl("lblRuleSetCode");
                //Label lblBrkRul = (Label)e.Row.FindControl("lblBrkRul");
                GridView dgReward = (GridView)e.Row.FindControl("dgReward");

                BindGridKPI(lblRuleSetCode.Text.ToString(), dgReward);

                //Label lblRATE = (Label)e.Row.FindControl("lblRATE");
                //HiddenField hdnType = (HiddenField)e.Row.FindControl("hdnKPICode");//////UnitType
                //Label lblValue = (Label)e.Row.FindControl("lblValue");
                //LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnkValue");
                ////added by arjun for the uat bug fixing
                //LinkButton lnkEditRwdRul = (LinkButton)e.Row.FindControl("lnkEditRwdRul");
                //LinkButton lnkDelRwdRul = (LinkButton)e.Row.FindControl("lnkDelRwdRul");



                //Label lblMEMBERCODE = (Label)e.Row.FindControl("lblMEMBERCODE");




            }



        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "gvAddMst_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGridKPI(string lblRuleSetCode, GridView gv)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();

            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
            htParam.Add("@RulStKey", lblRuleSetCode.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htParam);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds;
                    gv.DataBind();
                }
                else
                {

                    gv.DataSource = null;
                    gv.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindGridKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Added by Daksh for KPITrg

    protected void BindTrg()
    {
        try
        {
            DataSet dstrg = new DataSet();
            Hashtable htParatrg = new Hashtable();
            htParatrg.Clear();
            dstrg.Clear();
            htParatrg.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
            htParatrg.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());

            dstrg = objDal.GetDataSetForPrc_SAIM("Prc_GetTrgdtls", htParatrg);
            if (dstrg.Tables.Count > 0 && dstrg.Tables[0].Rows.Count > 0)
            {
                dgTrg.DataSource = dstrg;
                dgTrg.DataBind();
            }
            else
            {
                ShowNoResultFound(dstrg.Tables[0], dgTrg);
            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void dgTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblRuleSetCode = (Label)e.Row.FindControl("lnkRule_SET_KEY");

                GridView dgRwdTrg = (GridView)e.Row.FindControl("dgRwdTrg");
                HiddenField hdnCycle = (HiddenField)e.Row.FindControl("hdnCycle");


                BindRwdTrg(lblRuleSetCode.Text.ToString(), hdnCycle.Value.ToString(), dgRwdTrg);

            }



        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgTrg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindRwdTrg(String RuleSetCode, String hdnCycle, GridView gv)
    {
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CNTSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
            htParam.Add("@RULE_SET_KEY", RuleSetCode.ToString().Trim());
            htParam.Add("@CYCLE_CODE", hdnCycle.ToString().Trim());
            htParam.Add("@RULE_TYPE", "R");
            htParam.Add("@FLAG", "5");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                //hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
                //08_12_2017
                //dgRwdTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
                ViewState["gv"] = ds.Tables[0];

                if (gv.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
                {
                    btnnextrwdtrg.Enabled = true;
                }
                else
                {
                    btnnextrwdtrg.Enabled = false;
                }

                //dgReward.Columns[13].Visible = true;
                //dgRwdTrg.Columns[14].Visible = true;
                //dgRwdTrg.Columns[15].Visible = true;
            }
            else
            {
                ShowNoRecQualTrg(ds.Tables[0], gv);
                //btnSaveFn.Enabled = false;
                //dgRwdTrg.Columns[13].Visible = false;
                //dgRwdTrg.Columns[14].Visible = false;
                //dgRwdTrg.Columns[15].Visible = true; //changed by akash

                txtpgrwdtrg.Text = "1";
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;
            }
            Session["gridTrg"] = ds.Tables[0];
            Session["gridTrg1"] = ds.Tables[1];
            Session["TblRowCount"] = 0;
            ViewState["TblRowCount1"] = 0;
            ////Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindRwdTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgRwdTrg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // dgRwdTrg.PageIndex = e.NewPageIndex;

        GridView dgRwdTrg = (sender as GridView);
        dgRwdTrg.PageIndex = e.NewPageIndex;
        BindRwdTrg(dgRwdTrg.ToolTip, dgRwdTrg.ToolTip, dgRwdTrg);
    }

    //End by Daksh for KPITrg

    //Added by Daksh for KPIReward

    protected void dgRwdRul_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                if (Session["RwdRul"] != null)
                {
                    ////dt = Session["RwdRul"] as DataTable;
                    dt = ViewState["gv"] as DataTable;
                    Label lblBsdKpi = (Label)e.Row.FindControl("lblBsdKpi");
                    Label lblBrkRul = (Label)e.Row.FindControl("lblBrkRul");
                    GridView dgCntst = (GridView)e.Row.FindControl("dgCntst");

                    BindGrid(lblBrkRul.Text.ToString(), dgCntst);

                    Label lblRATE = (Label)e.Row.FindControl("lblRATE");
                    HiddenField hdnType = (HiddenField)e.Row.FindControl("hdnKPICode");//////UnitType
                    Label lblValue = (Label)e.Row.FindControl("lblValue");
                    LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnkValue");
                    //added by arjun for the uat bug fixing
                    LinkButton lnkEditRwdRul = (LinkButton)e.Row.FindControl("lnkEditRwdRul");
                    LinkButton lnkDelRwdRul = (LinkButton)e.Row.FindControl("lnkDelRwdRul");



                    Label lblMEMBERCODE = (Label)e.Row.FindControl("lblMEMBERCODE");
                    //END

                    if (dt.Rows.Count > 0)
                    //added by arjun for the uat bug fixing
                    {
                        if (lblMEMBERCODE.Text != "" && Request.QueryString["Page"] == null)
                        {

                            lnkEditRwdRul.Visible = false;
                            lnkDelRwdRul.Visible = false;
                        }
                        //END
                        //added by ajay sawant

                        //if (lblBsdKpi.Text != null)
                        //{
                        //    if (lblBsdKpi.Text == "")
                        //    {
                        //        e.Row.Cells[7].Text = "NA";
                        //        e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //    if (lblBsdKpi.Text == "--SELECT--")
                        //    {
                        //        e.Row.Cells[7].Text = "NA";
                        //        e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (lblBrkRul.Text != null)
                        //{
                        //    if (lblBrkRul.Text == "")
                        //    {
                        //        e.Row.Cells[10].Text = "NA";
                        //        e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (lblRATE.Text != null)
                        //{
                        //    if (lblRATE.Text == "")
                        //    {
                        //        e.Row.Cells[11].Text = "NA";
                        //        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (hdnType.Value == "F")
                        //{
                        //    lnkValue.Visible = true;
                        //    lblValue.Visible = false;
                        //}
                        //else
                        //{
                        //    lnkValue.Visible = false;
                        //    lblValue.Visible = true;
                        //}

                        // ended by ajay
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgRwdRul_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(string BRKPRULE_CODE, GridView gv)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@BRKPRULE_CODE", BRKPRULE_CODE.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_get_Mst_Cntstnt_KPI_Rwrd_Var_Rul", htParam);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds;
                    gv.DataBind();
                }
                else
                {

                    gv.DataSource = null;
                    gv.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindRwdRul(string flag)
    {
        try
        {

            DataSet dsReward = new DataSet();

            dsReward = GetRewardDtls(flag);
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                // hdnRwrdCnt.Value = dsReward.Tables[1].Rows[dgRwdRul.PageIndex]["CATG_CNT"].ToString().Trim();
                // dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
            }
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                ViewState["dgRwdRul"] = dsReward.Tables[0];
                dgRwdRul.DataSource = dsReward;
                dgRwdRul.DataBind();
                /////ViewState["dgRwdRul"]= ds.Tables[0];

                //btnSaveFn.Enabled = true;
                if (dgRwdRul.PageCount > Convert.ToInt32(txtPageRwdRul.Text.Trim()))
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
                dgRwdRul.AllowSorting = false;
                ShowNoRecRwdRul(dsReward.Tables[0], dgRwdRul);
                // btnSaveFn.Enabled = false;
            }
            Session["RwdRul"] = dsReward.Tables[0];
            ////Session["RwdRul1"] = ds.Tables[1];
            Session["TblRwrdRowCount"] = 0;
            ViewState["TblRwrdRowCount"] = 0;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindRwdRul", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private DataSet GetRewardDtls(string flag)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@RULE_TYPE", "R");
        if (Request.QueryString["Page"] != null)
        {
            htParam.Add("@Page", Request.QueryString["Page"].ToString().Trim());
            htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());
        }


        if (Request.QueryString["Page"] != null && flag == "N")
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }

        else if (Request.QueryString["Page"] != null && flag == "P")
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }

        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
        }

        return ds;
    }

    private void ShowNoRecRwdRul(DataTable source, GridView gv)
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
            gv.Rows[0].Cells[0].Text = "No rules have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ShowNoRecRwdRul", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgRwdRul_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }
            BindRwdRul("N");
            DataTable dt = (DataTable)ViewState["dgRwdRul"];

            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                //dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                if (dgSource.PageCount >= Convert.ToInt32(txtPageRwdRul.Text))
                {
                    btnprevrwdrul.Enabled = false;
                    txtPageRwdRul.Text = "1";
                    btnnextrwdrul.Enabled = true;
                }
                else
                {
                    btnnextrwdrul.Enabled = false;
                }
            }
            else
            {
                DataSet ds = null;
                ShowNoRecRwdRul(ds.Tables[0], dgRwdRul);
            }
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "dgRwdRul_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnprevrwdrul_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridView2.PageIndex;
            GridView2.PageIndex = pageIndex - 1;
            BindGeneratedRwdDetails();
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) - 1);
            if (txtPageRwdRul.Text == "1")
            {
                btnprevrwdrul.Enabled = false;
            }
            else
            {
                btnprevrwdrul.Enabled = true;
            }
            btnnextrwdrul.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "btnprevrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnextrwdrul_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridView2.PageIndex;

            GridView2.PageIndex = pageIndex + 1;
            BindGeneratedRwdDetails();
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) + 1);
            btnprevrwdrul.Enabled = true;
            if (txtPageRwdRul.Text == Convert.ToString(GridView2.PageCount))
            {
                btnnextrwdrul.Enabled = false;
            }

            int page = GridView2.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "btnnextrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillRwrdRulDropDowns(DropDownList ddl, string val)
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "FillRwrdRulDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void GetRWDMstDtls()
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@cmpcode", Request.QueryString["CmpCode"].ToString().Trim());
            htParam.Add("@cntstcode", Request.QueryString["CntstCode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "GetRWDMstDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void txtRwdDesc1_TextChanged(object sender, EventArgs e)
    {
        if (txtRwdDesc1.Enabled == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please add reward using add master');", true);
            return;
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
            //txtRwdCode.ReadOnly = false;
            txtRwdCode.Text = ddlRwdDesc.SelectedValue;

        }
    }

    protected void ShowRwdCode()
    {
        try
        {
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ShowRwdCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //End by Daksh for KPIReward

    protected void ddlDependKPIRewardFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDependKPIRewardFlag.SelectedValue == "N")
        {
            FillRwrdRulDropDowns(ddlType, "1");
            //ddlType.Items.RemoveAt(1);
            //ddlType.Items.RemoveAt(4);
            //ddlType.Items.RemoveAt(5);
            ListItem removeItem = ddlType.Items.FindByValue("1005");
            ddlType.Items.Remove(removeItem);
            ListItem removeItem1 = ddlType.Items.FindByValue("1003");
            ddlType.Items.Remove(removeItem1);
            ListItem removeItem2 = ddlType.Items.FindByValue("1004");
            ddlType.Items.Remove(removeItem2);



        }
        if (ddlDependKPIRewardFlag.SelectedValue == "A")
        {
            FillRwrdRulDropDowns(ddlType, "1");
            //ddlType.Items.RemoveAt(1);
            //ddlType.Items.RemoveAt(4);
            //ddlType.Items.RemoveAt(5);
            ListItem removeItem3 = ddlType.Items.FindByValue("1001");
            ddlType.Items.Remove(removeItem3);
            ListItem removeItem4 = ddlType.Items.FindByValue("1002");
            ddlType.Items.Remove(removeItem4);
            ListItem removeItem5 = ddlType.Items.FindByValue("1004");
            ddlType.Items.Remove(removeItem5);


        }
        if (ddlDependKPIRewardFlag.SelectedIndex == 0)
        {
            FillRwrdRulDropDowns(ddlType, "1");

        }
    }

    protected void BtnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                RuleSetKey = ddlRuleSetCode.SelectedItem.Text.ToString().Trim();
                ShowRulStKy();//Added by usha 
            }

            //Added for Upd Dwnld Batchid
            htParam.Clear();
            htParam.Add("@DocType", "DNKPIRwrd");
            strBatchId = objDal.execute_sprc_UpdDwnld_with_output("Prc_UpdtBatchId", htParam, "@Batch");
            hdnBatchId.Value = strBatchId.Trim();

            //Added for Upd Dwnld Batchid


            DataSet dsCategries = new DataSet();
            Hashtable htParamCat = new Hashtable();
            htParamCat.Clear();
            dsCategries.Clear();
            htParamCat.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htParamCat.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim().ToString().Trim());
            htParamCat.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
            dsCategries = objDal.GetDataSetForPrc_SAIM("Prc_NoOfCategoriesAgnstRulesSet", htParamCat);
            if (dsCategries.Tables.Count == 2)
            {
                for (int j = 0; j < dsCategries.Tables[0].Rows.Count; j++)
                {

                    DataSet dsCycleCount = new DataSet();
                    Hashtable ht_acc = new Hashtable();
                    ht_acc.Clear();
                    dsCycleCount.Clear();
                    ht_acc.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                    ht_acc.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim().ToString().Trim());
                    ht_acc.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
                    dsCycleCount = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
                    int cyclecnt = (Convert.ToInt32(dsCycleCount.Tables[0].Rows[0]["COUNT"].ToString().Trim()));
                    acc_cycle = dsCycleCount.Tables[0].Rows[0]["ACC_CYCLE"].ToString().Trim();
                    DataTable dt = new DataTable();
                    dt.Clear();
                     
                    //dt = Search("C", "10000007", acc_cycle);
                    //Added by usha 24.01.2020
                    dt = Search("C", hdnbusicode.Value.ToString().Trim(), acc_cycle);

                    for (int i = 0; i < dsCategries.Tables[1].Rows.Count; i++)
                    { 

                        DataSet dstrg = new DataSet();
                        Hashtable htParatrg = new Hashtable();
                        htParatrg.Clear();
                        dstrg.Clear();
                        htParatrg.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
                        htParatrg.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                        htParatrg.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
                        dstrg = objDal.GetDataSetForPrc_SAIM("Prc_Get_Tbl_Tmp_BulkAddRwrdDtls", htParatrg);

                        for (int k = 0; k < dstrg.Tables[0].Rows.Count; k++)
                        {
                            htParam.Clear();
                            htParam.Add("@RWD_RUL_CODE", "");
                            htParam.Add("@RWRD_CODE", dstrg.Tables[0].Rows[k]["RewardCode"].ToString().Trim());
                            htParam.Add("@RWD_DESC", dstrg.Tables[0].Rows[k]["RewardDesc"].ToString().Trim());
                            htParam.Add("@RWRD_DESC02", dstrg.Tables[0].Rows[k]["RewardDesc"].ToString().Trim());
                            htParam.Add("@RWRD_DESC03 ", dstrg.Tables[0].Rows[k]["RewardDesc"].ToString().Trim());
                            htParam.Add("@CATG_CODE ", dsCategries.Tables[0].Rows[j]["CATG_CODE"]);
                            htParam.Add("@CYCLE", dsCategries.Tables[1].Rows[i]["CYCLE"]);
                            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
                            htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
                            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                            htParam.Add("@RWRD_TYPE", dstrg.Tables[0].Rows[k]["RwrdTypeCode"].ToString().Trim());
                            htParam.Add("@TYPE", dstrg.Tables[0].Rows[k]["UnitTypeCode"].ToString().Trim());
                            htParam.Add("@BASED_ON_KPI ", dstrg.Tables[0].Rows[k]["KpiCode"].ToString().Trim());
                            htParam.Add("@VALUE", "");
                            htParam.Add("@BRKUPRULE", System.DBNull.Value);
                            htParam.Add("@CATG_DESC01", dsCategries.Tables[0].Rows[j]["CategoryDesc"].ToString().Trim());
                            htParam.Add("@CATG_DESC02", dsCategries.Tables[0].Rows[j]["CategoryDesc"].ToString().Trim());
                            htParam.Add("@CATG_DESC03", dsCategries.Tables[0].Rows[j]["CategoryDesc"].ToString().Trim());
                            htParam.Add("@RATE       ", "");
                            htParam.Add("@CREATEDBY  ", HttpContext.Current.Session["UserID"].ToString());
                            htParam.Add("@FLAG", "N");
                            htParam.Add("@CHKCYC", System.DBNull.Value);
                            htParam.Add("@Page", System.DBNull.Value);
                            htParam.Add("@MEMBERCODE", System.DBNull.Value);
                            htParam.Add("@TRGT_FROM", "");
                            htParam.Add("@TRGT_TO", "");
                            htParam.Add("@RWRD_RELEASE              ", System.DBNull.Value);
                            htParam.Add("@DEPENDENT_ON_KPI_RWD      ", System.DBNull.Value);
                            htParam.Add("@DEPENDENT_RWD_KPI         ", System.DBNull.Value);
                            htParam.Add("@DEPENDENT_RWD_RULESET_KEY ", System.DBNull.Value);
                            htParam.Add("@MdlFlag", System.DBNull.Value);
                            htParam.Add("@DEPENDENT_RWD_CNTSTNT_CODE", System.DBNull.Value);
                            htParam.Add("@DEPENDENT_RWD_CMPNSTN_CODE", System.DBNull.Value);
                            htParam.Add("@BatchId", strBatchId);

                            ds.Clear();
                            ds = objDal.GetDataSetForPrc_SAIM("Prc_Ins_Cntstnt_KPI_Rwrd_Rul", htParam);
                            htParam.Clear();
                            //rwrdrulcode = string.Empty;
                        }
                        //}

                    }
                }
                BindGeneratedRwdDetails();
                BindRwdTrg();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Generated Successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert(Something went wrong !!!');", true);
            }
           
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BtnGenerate_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlVal(ddlKPICode, ddlRuleSetCode.SelectedValue.ToString().Trim(), "", "3", "KPI_DESC", "KPI_CODE");
        ChkType();
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
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                htParam.Add("@RuleType", ddlRuleSetCode.SelectedValue.ToString().Trim());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Select Rule Set Dropdown ');", true);
            }


            htParam.Add("@RulSetKey", rulsetky.ToString().Trim());
            htParam.Add("@CatgCode", catgcd.ToString().Trim());
            htParam.Add("@MEM_CODE", hdnAgentCode.Value.ToString());
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "FillddlVal", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ChkType()
    {
        try
        {
            lblKPICode_.Text = "";
            if (ddlType.SelectedValue == "1001")
            {
                ddlKPICode.Enabled = false;

            }
            if (ddlType.SelectedValue == "1002")
            {
                ddlKPICode.Enabled = false;

            }

            if (ddlType.SelectedValue == "1003")
            {
                ddlKPICode.Enabled = true;
                lblKPICode_.Text = "*";

            }

            if (ddlType.SelectedValue == "1005")
            {
                ddlKPICode.Enabled = true;
                lblKPICode_.Text = "*";

            }

            if (ddlType.SelectedValue == "1004")
            {
                ddlKPICode.Enabled = true;
                lblKPICode_.Text = "*";

            }

            if (ddlType.SelectedValue == "1006")
            {
                ddlKPICode.Enabled = false;

            }


        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ChkType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected string GetMaxCode(string flag)
    {
        string code = String.Empty;
        try
        {

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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "GetMaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return code.ToString().Trim();
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
            if (Request.QueryString["CmpCode"] != null)
            {
                htSrch.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "Search", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

        return dsSrch.Tables[0];
    }


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@RewardCode", ddlRwdDesc.SelectedValue);
        htParam.Add("@RewardType", ddlRwdType.SelectedValue.ToString().Trim());
        htParam.Add("@RewardDesc", ddlRwdDesc.SelectedItem.Text.ToString().Trim());
        htParam.Add("@UnitType", ddlType.SelectedValue.ToString().Trim());
        htParam.Add("@KPICode", ddlKPICode.SelectedValue.ToString().Trim());
        htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString());
        ds.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_Ins_Tbl_Tmp_BulkAddRwrdDtls", htParam);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Details Added Successfully ');", true);
        BindRwrdDetails();
    }

    protected void BindRwrdDetails()
    {
        try
        {
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                DataSet dstrg = new DataSet();
                Hashtable htParatrg = new Hashtable();
                htParatrg.Clear();
                dstrg.Clear();
                htParatrg.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
                htParatrg.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                htParatrg.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());

                dstrg = objDal.GetDataSetForPrc_SAIM("Prc_Get_Tbl_Tmp_BulkAddRwrdDtls", htParatrg);
                if (dstrg.Tables.Count > 0 && dstrg.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dstrg;
                    GridView1.DataBind();
                    BtnGenerate.Visible = true;
                }
                else
                {
                    ShowNoResultFound(dstrg.Tables[0], GridView1);
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindRwrdDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }



    protected void BindGeneratedRwdDetails()
    {
        try
        {
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                DataSet dstrg = new DataSet();
                Hashtable htParatrg = new Hashtable();
                htParatrg.Clear();
                dstrg.Clear();
                htParatrg.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
                htParatrg.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                htParatrg.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
                htParatrg.Add("@BatchID", hdnBatchId.Value);

                dstrg = objDal.GetDataSetForPrc_SAIM("Prc_Get_GeneratedRwrdDtls", htParatrg);
                if (dstrg.Tables.Count > 0 && dstrg.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = dstrg;
                    GridView2.DataBind();
                    //BtnGenerate.Visible = true;
                }
                else
                {
                    ShowNoResultFound(dstrg.Tables[0], GridView2);
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
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "BindGeneratedRwdDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void rwrddbtnprevrwdtrg_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int pageIndex = GridView2.PageIndex;
    //        GridView2.PageIndex = pageIndex - 1;
    //        BindGeneratedRwdDetails();
    //        txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
    //        if (txtpgrwdtrg.Text == "1")
    //        {
    //            Button1.Enabled = false;
    //        }
    //        else
    //        {
    //            Button1.Enabled = true;
    //        }
    //        Button2.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    //protected void rwrddbtnnextrwdtrg_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int pageIndex = GridView2.PageIndex;
    //        GridView2.PageIndex = pageIndex + 1;
    //        BindGeneratedRwdDetails();

    //        btnprevrwdtrg.Enabled = true;
    //        if (txtpgrwdtrg.Text == Convert.ToString(GridView2.PageCount))
    //        {
    //            Button2.Enabled = false;
    //        }
    //        else
    //        {
    //            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
    //        }

    //        int page = GridView2.PageCount;
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}




    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int pageIndex = GridView2.PageIndex;
    //        GridView2.PageIndex = pageIndex + 1;
    //        BindGeneratedRwdDetails();

    //        btnprevrwdtrg.Enabled = true;
    //        if (txtpgrwdtrg.Text == Convert.ToString(GridView2.PageCount))
    //        {
    //            Button2.Enabled = false;
    //        }
    //        else
    //        {
    //            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
    //        }

    //        int page = GridView2.PageCount;
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int pageIndex = GridView2.PageIndex;
    //        GridView2.PageIndex = pageIndex - 1;
    //        BindGeneratedRwdDetails();
    //        txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
    //        if (txtpgrwdtrg.Text == "1")
    //        {
    //            Button1.Enabled = false;
    //        }
    //        else
    //        {
    //            Button1.Enabled = true;
    //        }
    //        Button2.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    #region ShowRulStKy
    protected void ShowRulStKy()
    {
        try
        { 
         ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", "1");
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        }
        if (ddlRuleSetCode.SelectedIndex > 1)
        {
            htParam.Add("@RuleType", ddlRuleSetCode.SelectedValue.ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            //hdnCount.Value = ds.Tables[1].Rows[0]["COUNT"].ToString().Trim();
            //hdnSetTrgRul.Value = ds.Tables[1].Rows[0]["SET_TRG_RULE"].ToString().Trim();
            //hdnBusiYear.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnbusicode.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
           // hdnAccCyc.Value = ds.Tables[1].Rows[0]["CYCLE_TYPE"].ToString().Trim();
        }
        }
      catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "RwrdBulkUpd", "ShowRulStKy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
       }
    }
    #endregion

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CntstStp.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=" + Request.QueryString["CntstCode"].ToString().Trim() + "&CmpTyp=INC&Mode=C");
    }
}
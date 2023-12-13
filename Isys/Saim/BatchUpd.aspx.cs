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



public partial class Application_Isys_Saim_BatchUpd : BaseClass
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

    public string FinYear = string.Empty;
    int total;
    string Month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CmpCode = Request.QueryString["CmpCode"].ToString().Trim();
            CntCode = Request.QueryString["CntstCode"].ToString().Trim();
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                RuleSetKey = ddlRuleSetCode.SelectedItem.Text.ToString().Trim();
            }
            FillDropDowns(ddlFrom, "24", "");
            FillDropDowns(ddlTo, "24", "");
            
            //FillDropDowns1(DropDownList1, "24", "");
            //FillDropDowns1(DropDownList2, "24", "");
            FillDropDownsRuleSet(ddlRuleSetCode, "24", "");
            DropDownList1.Items.Insert(0, new ListItem("Select", ""));
            DropDownList2.Items.Insert(0, new ListItem("Select", ""));

            //BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            if (Request.QueryString["CmpCode"].ToString().Trim() != null)
            {
                Hashtable htParam = new Hashtable();
                DataSet dsFinYearCheck = new DataSet();
                htParam.Clear();
                htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                dsFinYearCheck = objDal.GetDataSetForPrc_SAIM("Prc_GetFinYearOrNot", htParam);
                if (dsFinYearCheck.Tables[0].Rows.Count != 0)
                {

                    FinYear = dsFinYearCheck.Tables[0].Rows[0]["BUSI_YEAR"].ToString().Trim();
                    StrFinyear.Value = FinYear;
                    // if (StrFinyear.Value != "10000010")// comented by usha 
                    if (StrFinyear.Value != "MY")// added by usha on 23/01/2020
                    {
                        memberMonths.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        memberMonths.Attributes.Add("style", "display:block");
                    }
                }
                else
                {
                    FinYear = null;
                }
            }
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "FillDropDowns1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "FillDropDownsRuleSet", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
                divchk.Style.Add("display", "block");
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
                divchk.Style.Add("display", "block");

                
            }
            Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "BindGrid1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "dgReward_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "dgReward_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnlSearchbyRuleSet_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRuleSetCode.SelectedIndex > 0)
            {
                BindGrid(gvAddMst, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
                //BindTrg();
                //BindGrid1(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd, ddlRuleSetCode.SelectedValue.ToString().Trim());
                BindRwdTrg();
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Select Rule Set Dropdown ');", true);
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "lnlSearchbyRuleSet_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            // int total = (Convert.ToInt32(strMonthTo) - Convert.ToInt32(strMonthFrom)) + 1;
            //if (StrFinyear.Value.ToString() != "10000010")// Comented by usha on 24.01.2020
            if (StrFinyear.Value.ToString() != "MY")// Added by usha 
            {
                total = 1;
            }
            else
            {
                total = (Convert.ToInt32(strMonthTo) - Convert.ToInt32(strMonthFrom)) + 1;
            }
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
                    htParam.Add("@RulStKey", ddlRuleSetCode.SelectedValue.ToString().Trim());
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
                            htParam.Add("@RulStKey", ddlRuleSetCode.SelectedValue.ToString().Trim());
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
                            if (StrFinyear.Value.ToString() != "MY")
                            {
                                Month = string.Empty;
                            }
                            else
                            {
                                Month = ("M" + (Convert.ToInt32(strMonthFrom) + j));

                            }
                            //string Month = ("M" + (Convert.ToInt32(strMonthFrom) + j));
                            Slab = Slab + " - " + Month;
                            htParam.Add("@Slab", Slab);
                            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
                            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                            htParam.Add("@RuleType", "R");
                            htParam.Add("@RulStKey", ddlRuleSetCode.SelectedValue.ToString().Trim());


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
                            htParam.Add("@SORT", (i + 1));
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Generated Successfully');", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "LinkButton1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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

                LinkButton1.Visible = false;
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

                //dgRwdTrg.Columns[13].Visible = true;
                //dgRwdTrg.Columns[14].Visible = true;
                //dgRwdTrg.Columns[15].Visible = true;

            }
            else
            {
                LinkButton1.Visible = true;
                BtnDownloadExcel.Visible = false;

                //LinkButton1.Attributes.Add("style", "display: block;");
                //BtnDownloadExcel.Attributes.Add("style", "display: none;");

                ShowNoRecQualTrg(ds.Tables[0], dgRwdTrg);
                //dgRwdTrg.Columns[13].Visible = false;
                //dgRwdTrg.Columns[14].Visible = false;
                //dgRwdTrg.Columns[15].Visible = true; //changed by akash

                txtpgrwdtrg.Text = "1";
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;
            }
            Session["gridTrg"] = ds.Tables[0];
            //Session["gridTrg1"] = ds.Tables[1];
            Session["TblRowCount"] = 0;
            ViewState["TblRowCount1"] = 0;
            ////Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "BindRwdTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "dgRwdTrg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "dgRwdTrg_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "ShowNoRecQualTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "btnprevrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "btnnextrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BtnDownloadExcel_Click(object sender, EventArgs e)
    {
        Hashtable hparam = new Hashtable();
        htParam.Clear();
        dsResult.Clear();
        if (ddlRuleSetCode.SelectedIndex > 0)
        {
            htParam.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString().Trim());
        }
        dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetTargetsAgnstCode", htParam);
        if (dsResult.Tables.Count > 0)
        {
            ExportCSV(dsResult.Tables[0], ddlRuleSetCode.SelectedValue.ToString().Trim() + "_" + "KPI_Target");
            
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
            dsResult = objDal.GetDataSetForPrc_SAIM("Prc_GetBatchagainstRuleSetKey", htParam);
            string RuleSetKey = dsResult.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            string BatchID = dsResult.Tables[0].Rows[0]["BatchId"].ToString().Trim();
            if (dsResult.Tables[0].Rows.Count != 0)
            {
                htParam.Clear();
                dsResult.Clear();
                htParam.Add("@RulStKey", RuleSetKey);
                htParam.Add("@BatchId", BatchID);
                dsResult = objDal.GetDataSetForPrc_SAIM("Prc_TX_InsTmp_Cmpnstn_Cntstnt_KPI_Trgt_hist", htParam);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "btnBlkCatgUpd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd", "gvAddMst_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "BatchUpd.", "BindGridKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void ddlRuleSetCode_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void dgTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {

    //            Label lblRuleSetCode = (Label)e.Row.FindControl("lnkRule_SET_KEY");

    //            GridView dgRwdTrg = (GridView)e.Row.FindControl("dgRwdTrg");
    //            HiddenField hdnCycle = (HiddenField)e.Row.FindControl("hdnCycle");


    //            BindRwdTrg(lblRuleSetCode.Text.ToString(), hdnCycle.Value.ToString(), dgRwdTrg);

    //        }



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

    //protected void BindTrg()
    //{
    //    try
    //    {
    //        DataSet dstrg = new DataSet();
    //        Hashtable htParatrg = new Hashtable();
    //        htParatrg.Clear();
    //        dstrg.Clear();
    //        htParatrg.Add("@CntstCode", Request.QueryString["CmpCode"].ToString().Trim());;
    //        htParatrg.Add("@CmpCode",  Request.QueryString["CntstCode"].ToString().Trim());

    //        dstrg = objDal.GetDataSetForPrc_SAIM("Prc_GetTrgdtls", htParatrg);
    //        if (dstrg.Tables.Count > 0 && dstrg.Tables[0].Rows.Count > 0)
    //        {
    //            dgTrg.DataSource = dstrg;
    //            dgTrg.DataBind();
    //        }
    //        else
    //        {
    //            ShowNoResultFound(dstrg.Tables[0], dgTrg);
    //        }

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


    //protected void BindRwdTrg(String RuleSetCode, String hdnCycle, GridView gv)
    //{
    //    try
    //    {
    //        ds = new DataSet();
    //        htParam.Clear();
    //        ds.Clear();
    //        htParam.Add("@CNTSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
    //        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
    //        htParam.Add("@RULE_SET_KEY", RuleSetCode.ToString().Trim());
    //        htParam.Add("@CYCLE_CODE", hdnCycle.ToString().Trim());
    //        htParam.Add("@RULE_TYPE", "R");
    //        htParam.Add("@FLAG", "5");
    //        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
    //        if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
    //        {
    //            hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
    //            //08_12_2017
    //            //dgRwdTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
    //        }
    //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {
    //            gv.DataSource = ds;
    //            gv.DataBind();
    //            ViewState["gv"] = ds.Tables[0];

    //            if (gv.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
    //            {
    //                btnnextrwdtrg.Enabled = true;
    //            }
    //            else
    //            {
    //                btnnextrwdtrg.Enabled = false;
    //            }

    //            //dgReward.Columns[13].Visible = true;
    //            //dgRwdTrg.Columns[14].Visible = true;
    //            //dgRwdTrg.Columns[15].Visible = true;
    //        }
    //        else
    //        {
    //            ShowNoRecQualTrg(ds.Tables[0], gv);
    //            //btnSaveFn.Enabled = false;
    //            //dgRwdTrg.Columns[13].Visible = false;
    //            //dgRwdTrg.Columns[14].Visible = false;
    //            //dgRwdTrg.Columns[15].Visible = true; //changed by akash

    //            txtpgrwdtrg.Text = "1";
    //            btnprevrwdtrg.Enabled = false;
    //            btnnextrwdtrg.Enabled = false;
    //        }
    //        Session["gridTrg"] = ds.Tables[0];
    //        Session["gridTrg1"] = ds.Tables[1];
    //        Session["TblRowCount"] = 0;
    //        ViewState["TblRowCount1"] = 0;
    //        ////Session["grid"] = ds.Tables[0];
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

    //protected void dgRwdTrg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    // dgRwdTrg.PageIndex = e.NewPageIndex;

    //    GridView dgRwdTrg = (sender as GridView);
    //    dgRwdTrg.PageIndex = e.NewPageIndex;
    //    BindRwdTrg(dgRwdTrg.ToolTip, dgRwdTrg.ToolTip, dgRwdTrg);
    //}

    #region ShowRulStKy
    protected void ShowRulStKy()
    {
        //Request.QueryString["CmpCode"].ToString().Trim();
        //Request.QueryString["CntstCode"].ToString().Trim();
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
            hdnCount.Value = ds.Tables[1].Rows[0]["COUNT"].ToString().Trim();
            hdnSetTrgRul.Value = ds.Tables[1].Rows[0]["SET_TRG_RULE"].ToString().Trim();
            hdnBusiYear.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnbusicode.Value = ds.Tables[1].Rows[0]["BUSI_YEAR"].ToString().Trim();
            hdnAccCyc.Value = ds.Tables[1].Rows[0]["CYCLE_TYPE"].ToString().Trim();
        }
        
    }
    #endregion

    #region GetCycles
    protected void GetCycles()
    {
        DataTable dt = new DataTable();
        DropDownList1.Items.Clear();
        dt.Clear();
        dt = Search("C", hdnbusicode.Value.ToString().Trim(), hdnAccCyc.Value.ToString().Trim());
        if (dt.Rows.Count > 0)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = "BUSI_CODE";
            DropDownList1.DataTextField = "SHRT_BUSI_DESC";
            DropDownList1.DataBind();
            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = "BUSI_CODE";
            DropDownList2.DataTextField = "SHRT_BUSI_DESC";
            DropDownList2.DataBind();
            hdnYrType.Value = dt.Rows[0]["YEAR_TYPE"].ToString().Trim();
        }
        DropDownList1.Items.Insert(0, new ListItem("Select", ""));
        DropDownList2.Items.Insert(0, new ListItem("Select", ""));

    }
    #endregion

    protected DataTable Search(string flag, string yrcode, string cyc)
    {
        string acc_cycle = "";
        DataTable dt_acc = new DataTable();
        Hashtable ht_acc = new Hashtable();
        ht_acc.Clear();

        dt_acc.Clear();



        ht_acc.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        ht_acc.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim().ToString().Trim());
        ht_acc.Add("@RULE_SET_KEY", ddlRuleSetCode.SelectedValue.ToString());

        ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ACC_CYCLE", ht_acc);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            acc_cycle = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString();
            hdnCount.Value = ds.Tables[0].Rows[0]["COUNT"].ToString().Trim();

        }

        if (acc_cycle == "P")
        {

            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMST_BUSI_YR", ht_acc);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please add Cycle from Rule Set Page');", true);
                //txtRskDesc.Text = "";
                //ddlCyc.SelectedIndex = 0;
                //ddlCyc.Enabled = false;
                //ddlKPICode.Enabled = false;
            }


        }
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@BUSI_CODE", yrcode.ToString().Trim());
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@ACC_CYCLE", acc_cycle.Trim());
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0];
        }
        return ds.Tables[0];
    }

    protected void ddlRuleSetCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRuleSetCode.SelectedIndex > 0)
        {
            ShowRulStKy();
            GetCycles();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Select RuleSet Code.');", true);
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CntstStp.aspx?CmpCode="+Request.QueryString["CmpCode"].ToString().Trim()+"&CntstCode="+ Request.QueryString["CntstCode"].ToString().Trim() + "&CmpTyp=INC&Mode=C");
    }
}
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

public partial class Application_Isys_Saim_Cmp_ViewData : BaseClass
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

        if (!IsPostBack)
        {

            if (Request.QueryString["lnkbtn"] == "lnkView")
            {
                BindGridPolicy();
                if (Request.QueryString["kpiCode"].ToString().Trim() == "1000001501")
                {
                    lblCmpSrch.Text = "Participating Members";
                }
                else
                {
                    lblCmpSrch.Text = "Participating Policies";
                }
            }
            else
            {
                BindGridRevisedPolicy();
                if (Request.QueryString["kpiCode"].ToString().Trim() == "1000001501")
                {
                    Label1.Text = "Revised Participating Members";
                }
                else
                {
                    Label1.Text = "Revised Participating Policies";
                }
            }
        }
    }

    protected void BindGridPolicy()
    {
        try
        {
            htParam.Clear();

            ds.Clear();

            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
            htParam.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString());
            htParam.Add("@ACC_CYCLE_CODE ", Request.QueryString["CycleCode"].ToString());
            htParam.Add("@KPI_CODE ", Request.QueryString["kpiCode"].ToString());
            htParam.Add("@Flag", Request.QueryString["flag"].ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_getMemberPolicyData", htParam);

            divPart.Visible = true;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {


                if (Request.QueryString["kpiCode"].ToString() == "1000000101" || Request.QueryString["kpiCode"].ToString() == "1000001401" || Request.QueryString["kpiCode"].ToString() == "1000000701")
                {
                    gvPolicy.Visible = true;
                gvPolicy.DataSource = ds;
                gvPolicy.DataBind();
                    if(gvPolicy.PageCount>1)
                    {
                        btnnext.Enabled = true;
                        btnprevious.Enabled = false;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        btnprevious.Enabled = false;
                    }

                }

                if (Request.QueryString["kpiCode"].ToString() == "1000001501")
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }

                
            }
            else
            {

            }



        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "BindGridPolicy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BindGridRevisedPolicy()
    {
        try
        {
            htParam.Clear();

            ds.Clear();

            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
            htParam.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString());
            htParam.Add("@ACC_CYCLE_CODE ", Request.QueryString["CycleCode"].ToString());
            htParam.Add("@KPI_CODE ", Request.QueryString["kpiCode"].ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_getMemberPolicyData_ADD", htParam);

            divRevised.Visible = true;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                gvRevPolicy.DataSource = ds.Tables[0];
                gvRevPolicy.DataBind();

                //GrdParPolicy.DataSource = ds.Tables[1];
                //GrdParPolicy.DataBind();
                if (gvRevPolicy.PageCount > 1)
                {
                    revbtnnext.Enabled = true;
                    revbtnprevious.Enabled = false;
                }
                else
                {
                    revbtnnext.Enabled = false;
                    revbtnprevious.Enabled = false;
                }

            }
            else
            {
                ShowNoRec(ds.Tables[0], gvRevPolicy);
            }
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {

                //gvRevPolicy.DataSource = ds.Tables[0];
                //gvRevPolicy.DataBind();

                GrdParPolicy.DataSource = ds.Tables[1];
                GrdParPolicy.DataBind();
            }
            else
            {
                ShowNoRec(ds.Tables[1], GrdParPolicy);
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "BindGridRevisedPolicy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GrdParPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                DropDownList ddl = (e.Row.FindControl("ddlRsnFrResdA") as DropDownList);
               


                ddl.Items.Clear();
                Hashtable ht = new Hashtable();
                DataSet dsP = new DataSet();
                dsP.Clear();


                ht.Add("@LookupCode", "POLADD");
                // ht.Add("@Flag", val.ToString());

                drRead = objDal.Common_exec_reader_prc_SAIM("Prc_getReasonForRevised", ht);
                if (drRead.HasRows)
                {
                    ddl.DataSource = drRead;
                    ddl.DataTextField = "DESC01";
                    ddl.DataValueField = "CODE";
                    ddl.DataBind();
                }
                drRead.Close();
                ddl.Items.Insert(0, new ListItem("--SELECT--", ""));

             
                ddl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "RSN_FOR_RVSD").ToString();


            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "GrdParPolicy_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

     protected void gvRevPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //    LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
                //    LinkButton lnkDelRwdTrg = (LinkButton)e.Row.FindControl("lnkDelRwdTrg");
                //    LinkButton lnkKPITrgtSetRule = (LinkButton)e.Row.FindControl("lnkKPITrgtSetRule");

                DropDownList ddl = (e.Row.FindControl("ddlRsnFrResd") as DropDownList);
                // FillAchievementTable(DropDownList1, "");


                ddl.Items.Clear();
                Hashtable ht = new Hashtable();
                DataSet dsP = new DataSet();
                dsP.Clear();


                ht.Add("@LookupCode", "POLADD");
               // ht.Add("@Flag", val.ToString());
               
                drRead = objDal.Common_exec_reader_prc_SAIM("Prc_getReasonForRevised", ht);
                if (drRead.HasRows)
                {
                    ddl.DataSource = drRead;
                    ddl.DataTextField = "DESC01";
                    ddl.DataValueField = "CODE";
                    ddl.DataBind();
                }
                drRead.Close();
                ddl.Items.Insert(0, new ListItem("--SELECT--", ""));


            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "gvRevPolicy_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void FillDropDowns(DropDownList ddl, string val)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Clear();

        ht.Add("@LookupCode", "POLADD");
        ht.Add("@Flag", val.ToString());

        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_getReasonForRevised", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    protected void btnAddPolicy_click(object sender, EventArgs e)
    {
        DataSet dsAcc = new DataSet();
        Hashtable htAcc = new Hashtable();

        string strSuccess = string.Empty;
        string strFail = string.Empty;



        int strCheckSelectLead = 0;

        foreach (GridViewRow rowItem in gvRevPolicy.Rows)
        {
            CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


            if (chBx.Checked == true)
            {
                strCheckSelectLead = strCheckSelectLead + 1;
            }
        }


        if (strCheckSelectLead <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select at least one policy !');</script>", false);

        }

        else
        {

            foreach (GridViewRow rowItem in gvRevPolicy.Rows)
            {
                CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


                if (chBx.Checked == true)
                {
                    //Label lblRevpolicyNo = (Label)rowItem.FindControl("lblRevpolicyNo");

                    DropDownList ddl1 = (DropDownList)rowItem.FindControl("ddlRsnFrResd");
                    HiddenField HdnPremiumRegisterID = (HiddenField)rowItem.FindControl("HdnPremiumRegisterID");
                    HiddenField HdnRevpolicyNo = (HiddenField)rowItem.FindControl("HdnRevpolicyNo");


                    htAcc.Clear();
                    dsAcc.Clear();


                    htAcc.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
                    htAcc.Add("@ACC_CYCLE", Request.QueryString["CycleCode"].ToString());
                    //htAcc.Add("@PremiumRegisterID", HdnPremiumRegisterID.Value.ToString());
                    htAcc.Add("@Policyno", HdnRevpolicyNo.Value.ToString());
                    htAcc.Add("@RSN_FOR_RVSD", ddl1.SelectedValue.ToString());

                    dsAcc = objDal.GetDataSetForPrc_SAIM("Prc_UpdRevisedPolicy", htAcc);

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Data save successfully !');</script>", false);

                   
                }
                else
                {
                    //strFail = "N";
                }


            }


        }


     
       
            BindGridRevisedPolicy();
        
    }
    private void ShowNoRec(DataTable source, GridView gv)
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
            gv.Rows[0].Cells[0].Text = "No Policy is Present";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "ShowNoRec", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvPolicy.PageIndex;
            gvPolicy.PageIndex = pageIndex + 1;
            BindGridPolicy();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvPolicy.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gvPolicy.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = gvPolicy.PageIndex;
            gvPolicy.PageIndex = pageIndex - 1;
            BindGridPolicy();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void revbtnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvRevPolicy.PageIndex;
            gvRevPolicy.PageIndex = pageIndex + 1;
            BindGridRevisedPolicy();
            revtxtPage.Text = Convert.ToString(Convert.ToInt32(revtxtPage.Text) + 1);
            revbtnprevious.Enabled = true;
            if (revtxtPage.Text == Convert.ToString(gvRevPolicy.PageCount))
            {
                revbtnnext.Enabled = false;
            }
            int page = gvRevPolicy.PageCount;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "revbtnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void revbtnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = gvRevPolicy.PageIndex;
            gvRevPolicy.PageIndex = pageIndex - 1;
            BindGridRevisedPolicy();
            revtxtPage.Text = Convert.ToString(Convert.ToInt32(revtxtPage.Text) - 1);
            if (revtxtPage.Text == "1")
            {
                revbtnprevious.Enabled = false;
            }
            else
            {
                revbtnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "revbtnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void chkLeftAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            for (int i = 0; i < gvRevPolicy.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)(gvRevPolicy.Rows[i].FindControl("chkOne"));
                CheckBox allchk = (CheckBox)sender;
                chk.Checked = allchk.Checked;
            }
            gvRevPolicy.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvRevPolicy.UseAccessibleHeader = true;

            gvRevPolicy.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvRevPolicy.UseAccessibleHeader = true;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "chkLeftAll_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

}
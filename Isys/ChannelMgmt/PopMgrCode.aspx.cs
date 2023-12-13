using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_INSC_ChannelMgmt_PopMgrCode : BaseClass
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    Hashtable htParam = new Hashtable();
    DataSet dsmgr = new DataSet();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
   {
        try
        {
            if (HttpContext.Current.Session["SessionId"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            //Add: Parag @ 03032014
            if (Request.QueryString["toggle"] != null)
            {
                if (Request.QueryString["toggle"].ToString().Trim() != null)
                {
                   // trPostitions.Visible = false;
                    rdbPosn.SelectedValue = String.Empty;
                    rdbPosn.Visible = false;
                }
                else
                {
                  // trPostitions.Visible = true;
                    rdbPosn.Visible = true;
                }
            }
            //Add:End

           // txtMgrName.Focus();

            if (!IsPostBack)
            {
                Binddatagrid();
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region Binddatagrid
    protected void Binddatagrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsmgr = new DataSet();
            dsmgr.Clear();
            htParam.Clear();
            if (rdbPosn.SelectedIndex != -1)
            {
                htParam.Add("@FlagPosn", rdbPosn.SelectedValue);
            }
            else        //Add:Parag @ 04032014 - Condition for reinstatement Purposes
            {
                htParam.Add("@FlagPosn", String.Empty);
            }            //Add: End
            htParam.Add("@MgrName", txtMgrName.Text);
            htParam.Add("@SAPCode", txtSAPCode.Text.Trim());
            htParam.Add("@AgentType", Request.QueryString["agttyp"].ToString().Trim());
            htParam.Add("@BizSrc", Request.QueryString["bizsrc"].ToString().Trim());
            htParam.Add("@ChnCls", Request.QueryString["subchnl"].ToString().Trim());
            //Added: Parag
            htParam.Add("@UnitCode", Request.QueryString["untcd"].ToString().Trim());
            htParam.Add("@flag", Request.QueryString["flag"].ToString().Trim());
            htParam.Add("@chkflag", Request.QueryString["chkflag"].ToString().Trim());
            htParam.Add("@BsdOn", Request.QueryString["bsdon"].ToString().Trim());
            htParam.Add("@MemType", Request.QueryString["memtyp"].ToString().Trim());
            htParam.Add("@RptStp", Request.QueryString["rptstp"].ToString().Trim());
            htParam.Add("@RptSetup", Request.QueryString["rptsetup"].ToString().Trim());
            htParam.Add("@Chnl", Request.QueryString["chnl"].ToString().Trim());
            htParam.Add("@SChnl", Request.QueryString["schnl"].ToString().Trim());
            htParam.Add("@MemCode", Request.QueryString["MemCode"].ToString().Trim());
            if (Request.QueryString["chkflag"] != null)
            {
                if (Request.QueryString["untcd"].ToString() != "")
                {
                    if (Request.QueryString["agttyp"] != "")
                    {
                        
                            dsmgr = objDAL.GetDataSetForPrc("Prc_GetUntDtls", htParam);
                       
                    }
                    else if (Request.QueryString["agttyp"] == "")
                    {
                        dsmgr = objDAL.GetDataSetForPrc("Prc_GetUntDtlsUntRnk", htParam);
                    }
                }
                else
                {
                    dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforRptManager", htParam);
                }
            }

            if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dsmgr;
                gv.DataBind();
                ViewState["gv"] = dsmgr;
                gv.Visible = true;
            }
            else
            {
                //trErrorMsg.Visible = true;
                lblErrorMsg.Visible = true;
                gv.Visible = false;
                lblErrorMsg.Text = " No Records Found ! ";
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' No Records Found ! ');</script>", false);
            }

            dsmgr = null;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region BUTTON SEARCH CLICK
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('Could not fetch records as the data you have entered is INVALID. \n\n Please check wether the Manager Code And Employee Name are proper!');");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "Javascript1", sb.ToString(), true);
        }
        else
        {
            try
            {
                Binddatagrid();
            }
            catch (Exception ex)
            {
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            } 
        }
    }
    #endregion

    #region gv_RowDataBound
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkMgrCode = new LinkButton();
            LinkButton lnkUnitCode = new LinkButton();
            LinkButton lnkMemtyp = new LinkButton();

            lnkMgrCode = (LinkButton)e.Row.FindControl("lnk");
            lnkUnitCode = (LinkButton)e.Row.FindControl("lnkUnitCode");
            lnkMemtyp = (LinkButton)e.Row.FindControl("lnkMemtyp");


            /////lnkMgrCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + e.Row.Cells[2].Text.Trim() + "','" + lnkUnitCode.Text.Trim() + "','" + lnkMemtyp.Text.Trim() + "','" + e.Row.Cells[1].Text + "');return false;");
        }
    }
    #endregion

    #region gv_Sorting
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region gv_PageIndexChanging
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv.PageIndex = e.NewPageIndex;
            dv.Sort = gv.Attributes["SortExpression"];

            if (gv.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv.DataSource = dv;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMgrName.Text = "";
        txtSAPCode.Text = "";
        rdbPosn.SelectedIndex = -1;
        lblErrorMsg.Text = "";
        //gv.Visible = false;
    }
    #endregion

    #region ChkSelect_CheckedChanged
    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        #region CHECKBOX validation
        htParam.Clear();
        htParam.Add("@BizSrc", Request.QueryString["bizsrc"].ToString().Trim());
        htParam.Add("@ChnCls", Request.QueryString["schnl"].ToString().Trim());
        htParam.Add("@MemType", Request.QueryString["memtyp"].ToString().Trim());
        dsmgr = objDAL.GetDataSetForPrcCLP("Prc_GetUntLocn", htParam);
        #endregion

        if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
        {
            if (dsmgr.Tables[0].Rows[0]["UnitLocation"].ToString().Trim() == "0")
            {
                var activeCheckBox = sender as CheckBox;
                var count = 0;
                if (activeCheckBox != null)
                {
                    var isChecked = activeCheckBox.Checked;
                    var tempCheckBox = new CheckBox();
                    foreach (GridViewRow gvRow in gv.Rows)
                    {
                        tempCheckBox = gvRow.FindControl("ChkSelect") as CheckBox;
                        if (tempCheckBox != null)
                        {
                            tempCheckBox.Checked = !isChecked;
                        }
                        //if (tempCheckBox.Checked == true)
                        //{
                        //    count = count + 1;
                        //}
                        //if (count > 1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Cannot select more than ont unit');", true);
                        //    tempCheckBox.Checked = false;
                        //}
                    }

                    if (isChecked)
                    {
                        activeCheckBox.Checked = true;
                    }
                }
            }
        }

        //added by ajay 10052023
        CheckBox currentCheckBox = (CheckBox)sender;
        // Uncheck previously selected checkboxes
        foreach (GridViewRow row in gv.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("ChkSelect");

                if (checkBox != currentCheckBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
    }
    #endregion

    #region btnOK_Click
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
         
            DataTable dt = new DataTable();
            dt.Columns.Add("MemCode");
            dt.Columns.Add("Name");
            dt.Columns.Add("MemType");
            dt.Columns.Add("UnitCode");


            for (int intRowCount = 0; intRowCount <= gv.Rows.Count - 1; intRowCount++)
            {
                CheckBox ChkSelect = (CheckBox)gv.Rows[intRowCount].Cells[7].FindControl("ChkSelect");
                LinkButton MemCode = (LinkButton)gv.Rows[intRowCount].Cells[0].FindControl("lnk");
                Label Name = (Label)gv.Rows[intRowCount].Cells[2].FindControl("lblName");
                Label MemType = (Label)gv.Rows[intRowCount].Cells[3].FindControl("lblMemType");
                LinkButton UnitCode = (LinkButton)gv.Rows[intRowCount].Cells[3].FindControl("lnkUnitCode");

                if (ChkSelect.Checked == true)
                {
                    DataRow dr = dt.NewRow();
                    dr["MemCode"] = MemCode.Text;
                    dr["Name"] = Name.Text;
                    dr["MemType"] = MemType.Text;
                    dr["UnitCode"] = UnitCode.Text;
                    dt.Rows.Add(dr);
                }

            }
            string isPrimary = Request.QueryString["isPrimary"].ToString();


            if (isPrimary == "Y")
            {
                Session["mem"] = dt;
            }
            else
            {
                Session["addlmem"] = dt;
            }
            int row = 0;
            if (Request.QueryString["rwid"] != null)
            {
                if (Request.QueryString["rwid"].ToString().Trim() != "")
                {
                    row = Convert.ToInt32(Request.QueryString["rwid"].ToString().Trim());
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('" + isPrimary + "','" + row + "');", true);
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex - 1;
            //BindDataGrid();
            Binddatagrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex + 1;
            Binddatagrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = gv.PageCount;
            if (txtPage.Text == Convert.ToString(gv.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = gv.PageIndex + 1;
                //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gv.PageCount;
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
}
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

public partial class Application_ISys_Saim_CompStpReport : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            txtPage.Text = "1";
            if (Request.QueryString["Mode"] != null)
            {
                FillStatus(Request.QueryString["Mode"].ToString().Trim());
                Session["Mode"] = Request.QueryString["Mode"].ToString().Trim();
            }

            /////FillDropDowns(ddlStatus, "11");
            FillDropDowns(ddlCompType, "10");
            ddlStatus.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlCompType.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCompCode.Text = "";
        txtCompDesc1.Text = "";
        ddlStatus.SelectedValue = "";
        ddlCompType.SelectedValue = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
        divcmpsrchhdrcollapse.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCompCode.Text = "";
        txtCompDesc1.Text = "";
        ddlStatus.SelectedValue = "";
        ddlCompType.SelectedValue = "";
    }

    protected void BindGrid(string code, string desc, string type, string status)
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CompCode", code.ToString().Trim());
        htParam.Add("@CompDesc", desc.ToString().Trim());
        htParam.Add("@CompType", type.ToString().Trim());
        htParam.Add("@CompStat", status.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgCmp.DataSource = ds;
            dgCmp.DataBind();
            ViewState["grid"] = ds.Tables[0];
            if (dgCmp.PageCount > Convert.ToInt32(txtPage.Text))
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound1(ds.Tables[0], dgCmp);
            dgCntst.DataSource = null;
            dgCntst.DataBind();
        }
    }

    protected void dgCmp_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = (DataTable)ViewState["grid"];
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
        /////ShowPageInformation();
    }
    protected void dgCmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView dgCntst = (GridView)e.Row.FindControl("dgCntst");
            string cmpcode = dgCmp.DataKeys[e.Row.RowIndex].Value.ToString();
            BindCnstGrid(cmpcode.ToString().Trim(), dgCntst);
            //dgCntst.DataSource = GetDataRec(cmpcode);
            //dgCntst.DataBind();

            //addded by kalyani start
            Label CompCode = (Label)e.Row.FindControl("lnkCmpCode");
            LinkButton CompCodeValue = (LinkButton)e.Row.FindControl("lnkCnstCode");

            if (Request.QueryString["Mode"].ToString().Trim() == ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[27].ToString())
            {
                CompCode.Enabled = true;
                //CompCodeValue.Enabled = true;
            }
            else
            {
                CompCode.Enabled = false;
                CompCode.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
                // CompCodeValue.Enabled = false;
                //CompCodeValue.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
            }
            //addded by kalyani end
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex - 1;
            BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpReport", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmp.PageIndex;
            dgCmp.PageIndex = pageIndex + 1;
            BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = dgCmp.PageCount;
            if (txtPage.Text == Convert.ToString(dgCmp.PageCount))
            {
                btnnext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CompStpReport", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        txtCompCode.Text = "";
        txtCompDesc1.Text = "";
        ddlStatus.SelectedValue = "";
        ddlCompType.SelectedValue = "";
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CmpSetupReport.aspx?flag=N", true);
    }
    protected void lnkCmpCode_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lnkCmpCode = (Label)grd.FindControl("lnkCmpCode");

        if (Session["Mode"].ToString() == "Summary")
        {
            Response.Redirect("CmpSetupReport.aspx?flag=E&CmpCode=" + lnkCmpCode.Text.ToString().Trim() + "&CntstCode=''", true);    
        }
        else if (Session["Mode"].ToString() == "Tracker")
        {
            Response.Redirect("CntstTrackerRpt.aspx", true);    
        }
        
    }

    protected void FillDropDowns(DropDownList ddl, string val)
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
    }

    protected void dgCntst_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void dgCntst_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lnkCnstCode_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)row.FindControl("lnkCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");

        string strLblcode = lblCmpDsc.Value;
        string[] StrcmpCode = strLblcode.Split(',');
        Response.Redirect("CntstStp.aspx?CmpCode=" + StrcmpCode[row.RowIndex].ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
        ////Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + StrcmpCode[row.RowIndex].ToString().Trim() + "&CntstCode=''", true);
    }

    protected void BindCnstGrid(string cmpcode, GridView grd)
    {
        DataSet ds2 = new DataSet();
        ds2.Clear();
        htParam.Clear();
        htParam.Add("@CmpCode", cmpcode.ToString().Trim());
        ds2 = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls", htParam);
        if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = ds2;
            grd.DataBind();
            if (grd.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound(ds2.Tables[0], dgCntst);
        }
    }

    protected DataTable GetDataRec(string cmpcode)
    {
        DataSet ds2 = new DataSet();
        ds2.Clear();
        htParam.Clear();
        htParam.Add("@CmpCode", cmpcode.ToString().Trim());
        ds2 = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls", htParam);
        if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            return ds2.Tables[0];
        }
        return ds2.Tables[0];
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No contestants have been defined";
        source.Rows.Clear();
    }

    private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[0].Text = "";
        gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[1].Text = "No compensations have been defined";
        source.Rows.Clear();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void FillStatus(string val)
    {
        Hashtable ht = new Hashtable();
        ddlStatus.Items.Clear();
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_BindStatus_DropDown", ht);
        if (drRead.HasRows)
        {
            ddlStatus.DataSource = drRead;
            ddlStatus.DataTextField = "DESC01";
            ddlStatus.DataValueField = "CODE";
            ddlStatus.DataBind();
        }
        drRead.Close();
    }
}
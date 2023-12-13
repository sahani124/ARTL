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

public partial class Application_ISys_Saim_PopKPIDetails : BaseClass
{

    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
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
            BindGrid();
        }
    }
    protected void BindGrid()
    {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", "1");
        ds = objDal.GetDataSetForPrc_SAIM("Prc_KPISearch", htParam);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgKPI.DataSource = ds;
                    dgKPI.DataBind();
                }
            }
            else
            {
                ds = null;
            }
        }
        else
        {
            ds = null;
        }
    }
    protected void dgKPI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkKPICode = (LinkButton)e.Row.FindControl("lnkKPICode");
            Label lblKPIDesc1 = (Label)e.Row.FindControl("lblKPIDesc1");
            lnkKPICode.Attributes.Add("onClick", "doSelect('" + lnkKPICode.Text.Trim() + "'");
        }
    }
    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        var activeCheckBox = sender as CheckBox;
        var count = 0;
        if (activeCheckBox != null)
        {
            var isChecked = activeCheckBox.Checked;
            var tempCheckBox = new CheckBox();
            //foreach (GridViewRow gvRow in dgKPI.Rows)
            //{
            //    tempCheckBox = gvRow.FindControl("ChkSelect") as CheckBox;
            //    if (tempCheckBox != null)
            //    {
            //        tempCheckBox.Checked = !isChecked;
            //    }
            //    //if (tempCheckBox.Checked == true)
            //    //{
            //    //    count = count + 1;
            //    //}
            //    //if (count > 1)
            //    //{
            //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Cannot select more than ont unit');", true);
            //    //    tempCheckBox.Checked = false;
            //    //}
            //}
            if (isChecked)
            {
                activeCheckBox.Checked = true;
            }
        }
        
        }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("RuleNo");
        dt.Columns.Add("CompCode");
        dt.Columns.Add("KPICode");
        dt.Columns.Add("KPIDesc1");
        dt.Columns.Add("KPIType");
        dt.Columns.Add("KPIOrigin");
        dt.Columns.Add("RangeFrm");
        dt.Columns.Add("RangeTo");
        dt.Columns.Add("Version");

        for (int intRowCount = 0; intRowCount <= dgKPI.Rows.Count - 1; intRowCount++)
        {

            LinkButton lnkKPICode = (LinkButton)dgKPI.Rows[intRowCount].Cells[0].FindControl("lnkKPICode");
            Label lblKPIDesc1 = (Label)dgKPI.Rows[intRowCount].Cells[1].FindControl("lblKPIDesc1");
            Label lblKPIType = (Label)dgKPI.Rows[intRowCount].Cells[2].FindControl("lblKPIType");
            Label lblKPIOrigin = (Label)dgKPI.Rows[intRowCount].Cells[3].FindControl("lblKPIOrigin");
            Label lblRangeFrm = (Label)dgKPI.Rows[intRowCount].Cells[4].FindControl("lblRangeFrm");
            Label lblRangeTo = (Label)dgKPI.Rows[intRowCount].Cells[5].FindControl("lblRangeTo");
            Label lblVersion = (Label)dgKPI.Rows[intRowCount].Cells[6].FindControl("lblVersion");

            CheckBox ChkSelect = (CheckBox)dgKPI.Rows[intRowCount].Cells[7].FindControl("ChkSelect");

            if (ChkSelect.Checked == true)
            {
                DataRow dr = dt.NewRow();
                if (Request.QueryString["kpicode"] != null)
                {
                    dr["RuleNo"] = Request.QueryString["kpicode"].ToString().Trim();
                }
                if (Request.QueryString["compcode"] != null)
                {
                    dr["CompCode"] = Request.QueryString["compcode"].ToString().Trim();
                }
                dr["KPICode"] = lnkKPICode.Text;
                dr["KPIDesc1"] = lblKPIDesc1.Text;
                dr["KPIType"] = lblKPIType.Text;
                dr["KPIOrigin"] = lblKPIOrigin.Text;
                dr["RangeFrm"] = lblRangeFrm.Text;
                dr["RangeTo"] = lblRangeTo.Text;
                dr["Version"] = lblVersion.Text;
                dt.Rows.Add(dr);

            }

        }
        Session["KPI"] = dt;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
    }
   
}
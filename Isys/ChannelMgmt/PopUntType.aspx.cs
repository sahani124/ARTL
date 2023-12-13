using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_Isys_ChannelMgmt_PopUntType : Base
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    DataSet dsmgr = new DataSet();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Binddatagrid();
            }
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopUntType.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);
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
            htParam.Add("@CRNT_UNT_TYP_RNK", Convert.ToDecimal(Request.QueryString["untcd"].ToString().Trim()));
            htParam.Add("@BizSrc", Request.QueryString["chnl"].ToString().Trim());
            htParam.Add("@ChnCls", Request.QueryString["schnl"].ToString().Trim());
            htParam.Add("@SET_UP_TO_UNT_TYP_RNK", Convert.ToDecimal(Request.QueryString["stragttyp"].ToString().Trim()));
            htParam.Add("@RPRTNG_SU_FLAG", Request.QueryString["RptSetup"].ToString().Trim());
            htParam.Add("@UNTType", Request.QueryString["MemType01"].ToString().Trim());
            if (Request.QueryString["untcd"].ToString() != "")
            {
                if (Request.QueryString["agttyp"] != "")
                {
                    dsmgr = objDAL.GetDataSetForPrc("Prc_GetUNTMapRptType", htParam);
                    if (gv.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        txtPage.Text = "1";
                    }
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
                lblErrorMsg.Visible = true;
                gv.Visible = false;
                lblErrorMsg.Text = " No Records Found ! ";
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert(' No Records Found ! ');</script>", false);
            }
            dsmgr = null;
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopUntType.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);
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
            LogException("ISYS-CHMS", "PopUntType.aspx", "gv_Sorting", ex);
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
            LogException("ISYS-CHMS", "PopUntType.aspx", "gv_PageIndexChanging", ex);
        }
    }
    #endregion

    #region ChkSelect_CheckedChanged
    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        #region CHECKBOX validation
        htParam.Clear();
        htParam.Add("@BizSrc", Request.QueryString["chnl"].ToString().Trim());
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
                    }
                    if (isChecked)
                    {
                        activeCheckBox.Checked = true;
                    }
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
            dt.Columns.Add("MemType");
            dt.Columns.Add("BizSrc");
            dt.Columns.Add("ChnCls");
            dt.Columns.Add("MemLevel");
            dt.Columns.Add("UntRnk");
            for (int intRowCount = 0; intRowCount <= gv.Rows.Count - 1; intRowCount++)
            {
                CheckBox ChkSelect = (CheckBox)gv.Rows[intRowCount].Cells[0].FindControl("ChkSelect");
                Label MemType = (Label)gv.Rows[intRowCount].Cells[2].FindControl("lblMemType");
                Label BizSrc = (Label)gv.Rows[intRowCount].Cells[5].FindControl("lblBizSrc");
                Label ChnCls = (Label)gv.Rows[intRowCount].Cells[6].FindControl("lblChnCls");
                Label Memlevel = (Label)gv.Rows[intRowCount].Cells[3].FindControl("lblMemLevel");
                Label UntRnk = (Label)gv.Rows[intRowCount].Cells[4].FindControl("lblUntRnk");
                if (ChkSelect.Checked == true)
                {
                    DataRow dr = dt.NewRow();
                    dr["MemType"] = MemType.Text;
                    dr["BizSrc"] = BizSrc.Text;
                    dr["ChnCls"] = ChnCls.Text;
                    dr["UntRnk"] = UntRnk.Text;
                    dt.Rows.Add(dr);
                }
            }
            string isPrimary = "Y";// Request.QueryString["isPrimary"].ToString();
            if (isPrimary == "Y")
            {
                Session["mem"] = dt;
                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dsmgr.Clear();
                    htParam.Clear();
                    htParam.Add("@BizSrc", Request.QueryString["chnl"].ToString().Trim());
                    htParam.Add("@ChnCls", Request.QueryString["schnl"].ToString().Trim());
                    htParam.Add("@UnitType", Request.QueryString["MemType01"].ToString().Trim());
                    htParam.Add("@RptUnitRank", Convert.ToString(dt.Rows[i]["UntRnk"]).Trim());
                    htParam.Add("@RptUnitBizSrc", Convert.ToString(dt.Rows[i]["bizsrc"]).Trim());
                    htParam.Add("@RptUnitChnlCls", Convert.ToString(dt.Rows[i]["ChnCls"]).Trim());
                    htParam.Add("@RptUnitType", Convert.ToString(dt.Rows[i]["MemType"]).Trim());
                    htParam.Add("@CreatedBy", Convert.ToString(Session["UserName"]).Trim());
                    htParam.Add("@RelTyp", Request.QueryString["RelType"].ToString().Trim());
                    //dsmgr = objDAL.GetDataSetForPrc("Prc_InsChnMapRptType", htParam);
                    dsmgr = objDAL.GetDataSetForPrc("Prc_Ins_UnttypeMapRptTypeSu", htParam);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
                }
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('" + isPrimary + "','" + row + "');", true);
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopUntType.aspx", "btnOK_Click", ex);
        }
    }
    #endregion

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex - 1;
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
            LogException("ISYS-CHMS", "PopUntType.aspx", "btnprevious_Click", ex);
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
        }
        catch (Exception ex)
        {
            LogException("ISYS-CHMS", "PopUntType.aspx", "btnnext_Click", ex);
        }
    }
}

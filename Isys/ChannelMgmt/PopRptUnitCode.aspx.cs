using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CLTMGR;
using Insc.Common.Multilingual;
using DataAccessClassDAL;

public partial class Application_INSC_ChannelMgmt_PopRptUnitCode : BaseClass
{
    #region DECLARATION
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            Binddatagrid();
        }

    }
    #endregion

    #region BUTTON SEARCH CLICK
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Binddatagrid();
    }
    #endregion

    #region Binddatagrid
    protected void Binddatagrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsunt = new DataSet();
            dsunt.Clear();
            htParam.Clear();
            htParam.Add("@UntCode", txtUntCode.Text);
            htParam.Add("@UntName", txtUntName.Text.Trim());
            htParam.Add("@BizSrc", Request.QueryString["BizSrc"].ToString().Trim());
            htParam.Add("@ChnCls", Request.QueryString["ChnCls"].ToString().Trim());
            htParam.Add("@RptUnitType", Request.QueryString["UnitType"].ToString().Trim());
            htParam.Add("@RuleType", Request.QueryString["rule"].ToString().Trim());
            htParam.Add("@flag", Request.QueryString["flag"].ToString().Trim());
            htParam.Add("@UntType", Request.QueryString["unttyp"].ToString().Trim());
            htParam.Add("@Class", Request.QueryString["cls"].ToString().Trim());
            htParam.Add("@SubCls", Request.QueryString["scls"].ToString().Trim());
            dsunt = objDAL.GetDataSetForPrc("Prc_GetDataforRptUnt", htParam);
            if (dsunt.Tables.Count > 0)
            {
                if (dsunt.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = dsunt;
                    gv.DataBind();
                    ViewState["gv"] = dsunt;
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('No Records Found');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('No Records Found');</script>", false);
            }

            ShowPageInformation();
            if (gv.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
                txtPage.Text = "1";
            }
            dsunt = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region gv_RowDataBound
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkMgrCode = new LinkButton();
            lnkMgrCode = (LinkButton)e.Row.FindControl("lnk");
            LinkButton lnkunttyp = new LinkButton();
            lnkunttyp = (LinkButton)e.Row.FindControl("lnkunttyp");
            Label lbluntschnl = new Label();
            lbluntschnl = (Label)e.Row.FindControl("lbluntschnl");
            lnkMgrCode.Attributes.Add("onclick", "doSelect('" + lnkMgrCode.Text + "','" + e.Row.Cells[2].Text.Trim() + "','" + lnkunttyp.Text.ToString().Trim() + "','" + lbluntschnl.Text.ToString().Trim() + "');return false;");
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
            throw ex;
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
            throw ex;
        }

    }

    private void ShowPageInformation()
    {
        int intComPageIndex = gv.PageIndex + 1;
        //lblpgcom.Text = "Page " + intComPageIndex.ToString() + " of " + dgComDetails.PageCount;
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
            btnnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv.PageCount))
            {
                btnprevious.Enabled = false;
            }
            int page = gv.PageCount;
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
           // int pageIndex = gv.PageIndex;
           // gv.PageIndex = pageIndex + 1;
           //// GetDataTable();
           // Binddatagrid();
           // txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
           // btnprevious.Enabled = true;
           // int page = gv.PageCount;
           // if (txtPage.Text == Convert.ToString(gv.PageCount))
           // {
           //     btnnext.Enabled = false;
           // }
           // else
           // {
           //     int intPageIndex = gv.PageIndex + 1;
           //     lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gv.PageCount;
           // }


            int pageIndex = gv.PageIndex;
            gv.PageIndex = pageIndex + 1;
            Binddatagrid();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv.PageCount;
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
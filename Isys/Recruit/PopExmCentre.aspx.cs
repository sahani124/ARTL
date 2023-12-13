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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;


public partial class Application_ISys_Recruit_PopExmCentre : BaseClass
{
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccessClass = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
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
                txtExmCntr.Text= Request.QueryString["ExmCentre"].ToString().Trim();
                FillExamCentreDetails();
                trtitle.Visible = false;
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

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htresult = new Hashtable();
            DataSet dsresult = new DataSet();
            if (txtExmCntr.Text != "")
            {
                htresult.Add("@ExmCentre", txtExmCntr.Text.Trim());
                // added by pratik - for pagination issue
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
            }
            else
            {
                htresult.Add("@ExmCentre", System.DBNull.Value);
                // added by pratik - for pagination issue
                btnnext.Enabled = true;
                btnprevious.Enabled = true;
            }
            dsresult = dataAccessClass.GetDataSetForPrcRecruit("Prc_GetExmCntrDtls", htresult);
            if (dsresult.Tables.Count > 0)
            {
                if (dsresult.Tables[0].Rows.Count > 0)
                {
                    GrdExmCntrDtls.DataSource = dsresult.Tables[0]; ;
                    GrdExmCntrDtls.DataBind();
                    ShowPageInformation();
                    lblMessage.Text = "";
                    lblMessage.Visible = false;
                }
                else
                {
                    GrdExmCntrDtls.DataSource = null;
                    GrdExmCntrDtls.DataBind();
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GrdExmCntrDtls.DataSource = null;
                GrdExmCntrDtls.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
    protected void FillExamCentreDetails()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataTable dtExm = new DataTable();
            dtExm = GetDataTableForExmDtls();
            if (dtExm != null)
            {
                if (dtExm.Rows.Count > 0)
                {
                    GrdExmCntrDtls.DataSource = dtExm;
                    GrdExmCntrDtls.DataBind();
                    lblMessage.Text = "";
                    lblMessage.Visible = false;
                    ShowPageInformation();
                }
                else
                {
                    GrdExmCntrDtls.DataSource = null;
                    GrdExmCntrDtls.DataBind();
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GrdExmCntrDtls.DataSource = null;
                GrdExmCntrDtls.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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

    #region GetDataTableForExmDtls()
    protected DataTable GetDataTableForExmDtls()
    {
        DataSet dsExmCntr = new DataSet();
        DataTable dtExmCntr = new DataTable();
        try
        {
            dtExmCntr = null;
            htParam.Clear();
            if (Request.QueryString["ExmCentre"].ToString().Trim() != "")
            {
                htParam.Add("@ExmCentre",txtExmCntr.Text.Trim());
                // added by pratik - for pagination issue
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
            }
            else
            {
                htParam.Add("@ExmCentre",System.DBNull.Value);
                // added by pratik - for pagination issue

                btnnext.Enabled = true;
                btnprevious.Enabled = true;
            }
            dsExmCntr = dataAccessClass.GetDataSetForPrcRecruit("Prc_GetExmCntrDtls", htParam);
            if (dsExmCntr != null)
            {
                if (dsExmCntr.Tables.Count > 0)
                {
                    if (dsExmCntr.Tables[0].Rows.Count > 0)
                    {
                        dtExmCntr = dsExmCntr.Tables[0];
                    }
                    else
                    {
                        dtExmCntr = null;
                    }
                }
                else
                {
                    dtExmCntr = null;
                }
            }
            else
            {
                dtExmCntr = null;
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
        return dtExmCntr;
    }
    #endregion
    protected void GrdExmCntrDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkExmCntre1 = new LinkButton();
            lnkExmCntre1 = (LinkButton)e.Row.FindControl("lnkExmCntre");
            lnkExmCntre1.Attributes.Add("onclick", "doSelect('" + lnkExmCntre1.Text + "');return false;");
        }
    }

    protected void GrdExmCntrDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTableForExmDtls();
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;
            dgSource.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }
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
    private void ShowPageInformation()
    {
        int intPageIndex = GrdExmCntrDtls.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GrdExmCntrDtls.PageCount;
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GrdExmCntrDtls.PageIndex;
            GrdExmCntrDtls.PageIndex = pageIndex - 1;
            //BindDataGrid();
            FillExamCentreDetails();
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
            int pageIndex = GrdExmCntrDtls.PageIndex;
            GrdExmCntrDtls.PageIndex = pageIndex + 1;
            FillExamCentreDetails();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = GrdExmCntrDtls.PageCount;
            if (txtPage.Text == Convert.ToString(GrdExmCntrDtls.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = GrdExmCntrDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GrdExmCntrDtls.PageCount;
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
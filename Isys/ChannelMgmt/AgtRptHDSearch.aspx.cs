#region Namespaces
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
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.MQ.Life.AgnMd;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Net;
using System.Xml;
using DataAccessClassDAL;
using CLTMGR;
#endregion

public partial class Application_INSC_ChannelMgmt_AgtRptHDSearch : BaseClass
{
    #region DECLARATION
    string strNewMgrCode;
    private string strUserLang;
    private multilingualManager olng;
    DataAccessClass objDAL = new DataAccessClass();
    CommonUtility oCommonU = new CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        
        olng = new multilingualManager("DefaultConn", "AgtRptHDSearch.aspx", strUserLang);
        
        if (!IsPostBack)
        {
            txtRptHDCode.Text = Request.QueryString["rpthdcode"];
            BindGridView();
            InitializeControl();
        }
    }
    #endregion

    #region InitializeControl
    private void InitializeControl()
    {
        lblRptHDCode1.Text = ObjDec.GetDecData(olng.GetItemDesc("lblRptHDCode1.Text"));
        lblRptHDName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblRptHDName.Text"));
    }
    #endregion

    #region BindGridView
    private void BindGridView()
    {
        try
        {
            Hashtable ht = new Hashtable();
            DataSet dsResult = new DataSet();
            ht.Add("@AgentCode", txtRptHDCode.Text.ToString().Trim());
            ht.Add("@LegalName", txtRptHDName.Text.ToString().Trim());
            ht.Add("@AgentType", Request.QueryString["sValue"].ToString().Trim());//For new Mgr Type
            //ht.Add("@RptHdCode", Request.QueryString["rpthdcode"].ToString().Trim());// For new MgrCode
            ht.Add("@Bizsrc", Request.QueryString["bizsrc"].ToString().Trim());
            ht.Add("@chncls", Request.QueryString["chncls"].ToString().Trim());
            //dsResult = objDAL.GetDataSetForPrc("Prc_pd_GetAgtForAgtType", ht);
            dsResult = objDAL.GetDataSetForPrc("Prc_pd_SearchRpHead", ht);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = dsResult;
                    gvDetails.DataBind();
                    ViewState["gv"] = dsResult;
                    lblMessage.Text = "";
                    lblMessage.Visible = false;
                    ShowPageInformation();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('No Records Found');</script>", false);
                    lblMessage.Text = "No Records Found";
                    lblMessage.Visible = true;
                    lblPageInfo.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('No Records Found');</script>", false);
                lblMessage.Text = "No Records Found";
                lblMessage.Visible = true;
                lblPageInfo.Text = "";
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

    #region ShowPageInformation
    private void ShowPageInformation()
    {
        int intPageIndex = gvDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gvDetails.PageCount;
        lblPageInfo.Visible = true;
    }
    #endregion

    #region Search Button Click
    protected void btnSearchRp_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridView();
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

    #region gvDetails_PageIndexChanging
    protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gvDetails.PageIndex = e.NewPageIndex;
            dv.Sort = gvDetails.Attributes["SortExpression"];

            if (gvDetails.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gvDetails.DataSource = dv;
            gvDetails.DataBind();
            ShowPageInformation();
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

    #region gvDetails_Sorting
    protected void gvDetails_Sorting(object sender, GridViewSortEventArgs e)
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
            ShowPageInformation();
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
    
    #region gvDetails_RowDataBound
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = new LinkButton();
            lnk = (LinkButton)e.Row.FindControl("lnkRptHDCode");
            lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
    #endregion

}

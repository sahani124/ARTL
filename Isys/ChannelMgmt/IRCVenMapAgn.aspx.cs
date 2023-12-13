using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using INSCL.DAL;
using Insc.Common.Multilingual;
using DataAccessClassDAL;

public partial class Application_INSC_ChannelMgmt_IRCVenMapAgn : BaseClass
{

    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    string strAgnCode = string.Empty;
    private multilingualManager olng;
    ///string VendorBasID;
    string strUserLang;
    ErrLog objErr = new ErrLog();
    #endregion

    #region PageLoad Method
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "AgentVendorMap.aspx", strUserLang);
            InitializeControl();
            if (Request.QueryString["AgentCode"].ToString() != null)
            {
                strAgnCode = Request.QueryString["AgentCode"].ToString();
            }
            BindGridView(strAgnCode);
            ///BindGridView();
            BindIRCGridView(strAgnCode);
            GetIRCCodes(strAgnCode);
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

    #region InitializeControl
    private void InitializeControl()
    {
        gv_IRCCODE.Columns[0].HeaderText = (olng.GetItemDesc("gvHTIRCCode"));
        gv_IRCCODE.Columns[1].HeaderText = (olng.GetItemDesc("gvHTEmpCode"));
        gv_IRCCODE.Columns[2].HeaderText = (olng.GetItemDesc("gvHTEmpName"));
        gv_IRCCODE.Columns[3].HeaderText = (olng.GetItemDesc("gvHTAgnType"));
        gv_IRCCODE.Columns[4].HeaderText = (olng.GetItemDesc("gvHTChnlName"));
        gv_IRCCODE.Columns[5].HeaderText = (olng.GetItemDesc("gvHTSubClass"));
        gv_IRCCODE.Columns[6].HeaderText = (olng.GetItemDesc("gvHTUnit"));
    }
    #endregion

    #region BindGridView(string) Method
    protected void BindGridView(string strAgentCode)
    {
        try
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgentCode", strAgentCode);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetAgentVendorMap", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                gv_AgentVendorMap.DataSource = dsResult.Tables[0];
                gv_AgentVendorMap.DataBind();
                ViewState["AgentSearch"] = dsResult;
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

    #region gv_AgentVendorMap_PageIndexChanging
    protected void gv_AgentVendorMap_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["AgentSearch"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_AgentVendorMap.PageIndex = e.NewPageIndex;
            dv.Sort = gv_AgentVendorMap.Attributes["SortExpression"];

            if (gv_AgentVendorMap.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_AgentVendorMap.DataSource = dv;
            gv_AgentVendorMap.DataBind();
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

    #region gv_AgentVendorMap_Sorting Method
    protected void gv_AgentVendorMap_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["AgentSearch"] as DataSet;
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

    #region BindGridIRC
    protected void BindGridView()
    {
        try
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgentCode", strAgnCode);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetAgentVendorMap", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                gv_AgentVendorMapIRC.DataSource = dsResult.Tables[0];
                gv_AgentVendorMapIRC.DataBind();
                ViewState["AgentSearch"] = dsResult;
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
    protected void BindIRCGridView(string strVendorCode)
    {
        try
        {
            htParam.Clear();
            dsResult.Clear();

            htParam.Add("@VendorBasID", strVendorCode.ToString().Trim());
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetIRCCode", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                gv_IRCCODE.DataSource = dsResult.Tables[0];
                gv_IRCCODE.DataBind();
                ViewState["ViewIrc"] = dsResult;
            }
            trGridIRC.Visible = true;
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

    protected void gv_AgentVendorMapIRC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gv_AgentVendorMapIRC_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    #region gv_IRCCODE_PageIndexChanging Method
    protected void gv_IRCCODE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["IRCCodes"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_IRCCODE.PageIndex = e.NewPageIndex;
            dv.Sort = gv_IRCCODE.Attributes["SortExpression"];

            if (gv_IRCCODE.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_IRCCODE.DataSource = dv;
            gv_IRCCODE.DataBind();
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

    #region gv_IRCCODE_Sorting Method
    protected void gv_IRCCODE_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["IRCCodes"] as DataSet;
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

    #region lbViewIRC_Active_Click Method
    protected void lbViewIRC_Active_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbViewIRC");
        Label lblVendorCode = (Label)row.FindControl("lblVendorBasID");
        BindIRCGridView(lblVendorCode.Text);
    }
    #endregion

    protected void lbAddNew_Click(object sender, EventArgs e)
    {

    }

    #region GetIRCCodes Method
    protected void GetIRCCodes(string strAgentCode)
    {
        try
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgtCode", strAgentCode);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetIRCCodesForAgn", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                gv_IRCCODE.DataSource = dsResult.Tables[0];
                gv_IRCCODE.DataBind();
                ViewState["IRCCodes"] = dsResult;
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
}
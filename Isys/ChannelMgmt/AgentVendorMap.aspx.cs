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

public partial class Application_INSC_ChannelMgmt_AgentVendorMap : BaseClass
{
    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    string strAgnCode = string.Empty;
    private multilingualManager olng;
    string strUserLang = string.Empty;
    ErrLog objErr = new ErrLog();
    #endregion
    #region Page Load Method
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "AgentVendorMap.aspx", strUserLang);
            //if (!IsPostBack)
            //{
            InitializeControl();
            if (Request.QueryString.Count > 0)
            {
                strAgnCode = Request.QueryString["AgentCode"].ToString();
                GetAgentDtls(strAgnCode);
            }
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
        //}
    }
    #endregion
    #region InitializeControl
    private void InitializeControl()
    {
        lblTitle.Text = (olng.GetItemDesc("lblTitle"));
        lblAgentID.Text = (olng.GetItemDesc("lblAgentID"));
        lblAgentName.Text = (olng.GetItemDesc("lblAgentName"));
        lblChannel.Text = (olng.GetItemDesc("lblChannel"));
        lblSubclass.Text = (olng.GetItemDesc("lblSubclass"));
        lbltitle2.Text = (olng.GetItemDesc("lbltitle2"));
        gv_AgentVendorMap.Columns[0].HeaderText = (olng.GetItemDesc("gvHTAgnCode"));
        gv_AgentVendorMap.Columns[1].HeaderText = (olng.GetItemDesc("gvHTVenCode"));
        gv_AgentVendorMap.Columns[2].HeaderText = (olng.GetItemDesc("gvHTVenName"));
        gv_AgentVendorMap.Columns[3].HeaderText = "Agent_Bas_ID";
        gv_AgentVendorMap.Columns[4].HeaderText = (olng.GetItemDesc("gvHTStatus"));
        gv_AgentVendorMap.Columns[5].HeaderText = (olng.GetItemDesc("gvHTPartnerCode"));
        gv_AgentVendorMap.Columns[6].HeaderText = (olng.GetItemDesc("gvHTPrimary"));
        gv_AgentVendorMap.Columns[7].HeaderText = (olng.GetItemDesc("gvHTViewIRC"));
        gv_AgentVendorMap.Columns[8].HeaderText = (olng.GetItemDesc("gvHTCrtIRC"));
        lblTitle3.Text = (olng.GetItemDesc("lblTitle3"));
        gv_IRCCODE.Columns[0].HeaderText = (olng.GetItemDesc("gvHTIRCCode"));
        gv_IRCCODE.Columns[1].HeaderText = "IRC NAME";
        gv_IRCCODE.Columns[2].HeaderText = (olng.GetItemDesc("gvHTEmpCode"));
        gv_IRCCODE.Columns[3].HeaderText = (olng.GetItemDesc("gvHTEmpName"));
        gv_IRCCODE.Columns[4].HeaderText = (olng.GetItemDesc("gvHTAgnType"));
        gv_IRCCODE.Columns[5].HeaderText = (olng.GetItemDesc("gvHTChnlName"));
        gv_IRCCODE.Columns[6].HeaderText = (olng.GetItemDesc("gvHTSubClass"));
        gv_IRCCODE.Columns[7].HeaderText = (olng.GetItemDesc("gvHTUnit"));
       // btnAddNew.Text = (String)(olng.GetItemDesc("btnAddNew")).ToUpper();
        
    }
    #endregion
    #region Bind Grid 
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
                gv_AgentVendorMap.DataSource = dsResult.Tables[0];
                gv_AgentVendorMap.DataBind();
                gv_AgentVendorMap.Visible = true;
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
                trGridIRC.Visible = true;
            }
            else
            {
                gv_IRCCODE.DataSource = null;
                gv_IRCCODE.DataBind();
                trGridIRC.Visible = false;
            }
            //trGridIRC.Visible = true;-----------commented by vijendra on 03-04-2014 to proper refresh the page.
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
    #region Button Click
    protected void lbViewIRC_Active_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbViewIRC");
        Label lblVendorCode = (Label)row.FindControl("lblVendorBasID");
        BindIRCGridView(lblVendorCode.Text);
        

    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbAddNew");
        Label lblAgentCode = (Label)row.FindControl("lblAgentCode");
        Label lblVendorCode = (Label)row.FindControl("lblVendorCode");
        Label lblVendorName = (Label)row.FindControl("lblVendorName");
        Label lblPrimary = (Label)row.FindControl("lblPrimary");

        Response.Redirect("~/Application/ISys/ChannelMgmt/MultiBranchAssignment.aspx?agncd=" + lblAgentCode.Text + "&VendCode=" + lblVendorCode.Text + "&AgnName=" + lblAgentNameDesc.Text + "&AgnChn=" + lblChannelVal.Text + "&AgnChnCls=" + lblSubclassVal.Text + "&VendName=" + lblVendorName.Text + "&Primary=" + lblPrimary.Text + "");
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/ISys/ChannelMgmt/MultiBranchAssignment.aspx");
    }
    #endregion
    #region Bind Text Value
    protected void GetAgentDtls(string strAgentCode)
    {
        try
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgentCode", strAgentCode);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetAgnDtls", htParam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                lblAgentIDDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                lblAgentNameDesc.Text = dsResult.Tables[0].Rows[0]["LegalName"].ToString();
                lblChannelVal.Text = dsResult.Tables[0].Rows[0]["ChannelDesc01"].ToString();
                lblSubclassVal.Text = dsResult.Tables[0].Rows[0]["ChnClsDesc01"].ToString();
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
    protected void gv_IRCCODE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["ViewIrc"] as DataSet;
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

            DataSet ds = ViewState["ViewIrc"] as DataSet;
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
    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
    }
    #endregion
    protected void gv_AgentVendorMap_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            LinkButton lbViewIRC = (LinkButton)e.Row.FindControl("lbViewIRC");
            LinkButton lbAddNew = (LinkButton)e.Row.FindControl("lbAddNew");
            if (lblStatus.Text == "INACTIVE")
            {
                lbViewIRC.Enabled = false;
                lbAddNew.Enabled = false;
            }

        }
    }
}
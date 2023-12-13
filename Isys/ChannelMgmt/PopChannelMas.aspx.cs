using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using INSCL.DAL;
using System.Xml;
using DataAccessClassDAL;
using System.Collections;
using System.Data;


public partial class Application_ISys_ChannelMgmt_PopChannelMas : BaseClass
{
    #region Global Declarations
    DataAccessClass objDAL = new DataAccessClass();
    XmlDocument doc = new XmlDocument();
    //XmlReader objXmlReader;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    string ErrMsg, strXML = "";
    string AuditType;
    string strBizsrc = string.Empty;
    ErrLog objErr = new ErrLog();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        Session["CarrierCode"] ='2';
            //lblMsg.Visible = false;
            if (!IsPostBack)
            {
                bindDdlFincYear();
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["Flag"] != null)
                    {
                        if (Request.QueryString["Flag"].ToString() == "old")
                        {
                            if (Request.QueryString["FincYr"] != null && Request.QueryString["Version"] != null)
                            {
                                string strFincYr = Request.QueryString["FincYr"].ToString().Trim();
                                string Version = Request.QueryString["Version"].ToString().Trim();
                                FillGridDgDetails(strFincYr, Version);
                                fillGridDgComDetails(strFincYr, Version);

                            }
                        }
                    }

                }
            }
    }

    private void fillGridDgComDetails(string strFincYr, string Version)
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@ChannelType", "O");
        htParam.Add("@Period", strFincYr);
        htParam.Add("@BaseVersion", Version);
        dsResult = objDAL.GetDataSetForPrcCLP("prc_ChannelSetup", htParam);
        if (dsResult != null)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ViewState["dgComDetails"] = dsResult.Tables[0];
                dgComDetails.DataSource = dsResult;
                dgComDetails.DataBind();
            }
        }
    }

    private void FillGridDgDetails(string strFincYr, string Version)
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@ChannelType", "C");
        htParam.Add("@Period", strFincYr);
        htParam.Add("@BaseVersion", Version);
        dsResult = objDAL.GetDataSetForPrcCLP("prc_ChannelSetup", htParam);
        if (dsResult != null)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ViewState["dgDetails"] = dsResult.Tables[0];
                dgDetails.DataSource = dsResult;
                dgDetails.DataBind();
            }
        }
    }

    #region ShowPageInformation()
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblpginf.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;

        int intComPageIndex = dgComDetails.PageIndex + 1;
        lblpgcom.Text = "Page " + intComPageIndex.ToString() + " of " + dgComDetails.PageCount;
    }
    #endregion

    #region SORTING
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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

        //DataTable dt = GetDisplay();
        DataTable dt = (DataTable)ViewState["dgDetails"];
        DataView dv = new DataView(dt);
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
    #endregion      
    #region dgComDetails_Sorting
    protected void dgComDetails_Sorting(object sender, GridViewSortEventArgs e)
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

        //DataTable dt = GetComDisplay();
        DataTable dt = (DataTable)ViewState["dgComDetails"]; ;
        DataView dv = new DataView(dt);
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
    #endregion

    #region dgComDetails_PageIndexChanging
    protected void dgComDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //DataTable dt = GetComDisplay();
            DataTable dt = (DataTable)ViewState["dgComDetails"];
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
    #region PAGEINDEX
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //DataTable dt = GetDisplay();
            DataTable dt = (DataTable)ViewState["dgDetails"];
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

    private void bindDdlFincYear()
    {
        htParam.Clear();
        dsResult = null;
        dsResult = objDAL.GetDataSetForPrcCommon("Prc_GetFincYears");
        ddlFincYear.DataSource = dsResult.Tables[0];
        ddlFincYear.DataTextField = "Period";
        ddlFincYear.DataValueField = "Period";
        ddlFincYear.DataBind();
        ddlFincYear.Items.Insert(0, new ListItem("-- Select --", ""));
    }
    protected void ddlFincYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDdlBaseVersion();

    }

    private void bindDdlBaseVersion()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@Period", ddlFincYear.SelectedValue);
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetVersionDtls", htParam);
        ddlBaseVersion.DataSource = dsResult.Tables[0];
        ddlBaseVersion.DataTextField = "BaseVersion";
        ddlBaseVersion.DataValueField = "BaseVersion";
        ddlBaseVersion.DataBind();
        ddlBaseVersion.Items.Insert(0, new ListItem("-- Select --", ""));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strFincYr =ddlFincYear.SelectedValue;
        string Version = ddlBaseVersion.SelectedValue;
        FillGridDgDetails(strFincYr, Version);
        fillGridDgComDetails(strFincYr, Version);
        tblHierDtls.Visible = true;
    }
}
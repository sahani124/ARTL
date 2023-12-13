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
using System.Data.SqlClient;
using INSCL.DAL;
using INSCL.App_Code;
using Insc.Common.Multilingual;
using DataAccessClassDAL;
using CLTMGR;
public partial class Application_INSC_ChannelMgmt_UntLst : BaseClass
{
    #region DECLARE VARIABLES
    string strBizSrc = string.Empty;
    string strChnCls = string.Empty;
    string strType = string.Empty;
    string strMgrCode = string.Empty;
	string strAgentType = string.Empty;
    string strRecruitDate = string.Empty;
    string strPageName = string.Empty;
    DataSet dsResult;
    DataSet dsResult1;
    Hashtable htParam = new Hashtable();
	CheckBox chk;
    private multilingualManager olng;
    string strUser = string.Empty;
    private DataAccessClass dataAccess = new DataAccessClass();

	//nitin 
    DataAccessClass objDAL = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    bool chkflag = false;
    #endregion

    #region PAGE_LOAD EVENT
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            strUser = HttpContext.Current.Session["UserID"].ToString();
            olng = new multilingualManager("DefaultConn", "UntLst.aspx", Session["UserLangNum"].ToString());
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            if (Request.QueryString["BizSrc"] != null)
            {
                strBizSrc = Convert.ToString(Request.QueryString["BizSrc"]);
            }
            if (Request.QueryString["ChnCls"] != null)
            {
                strChnCls = Convert.ToString(Request.QueryString["ChnCls"]);
            }
            if (Request.QueryString["AgentType"] != null)
            {
                strAgentType = Convert.ToString(Request.QueryString["AgentType"]);
            }
            if (Request.QueryString["Type"] != null)
            {
                strType = Convert.ToString(Request.QueryString["Type"]);
            }
            if (Request.QueryString["MgrCode"] != null)
            {
                strMgrCode = Convert.ToString(Request.QueryString["MgrCode"]);
            }
            if (Request.QueryString["RecruitDate"] != null)
            {
                strRecruitDate = Request.QueryString["RecruitDate"];
            }
            if (Request.QueryString["page"] != null)
            {
                strPageName = Request.QueryString["page"];
            }
          //  demo.Attributes.Add("style", "display:none");

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
        #region !IsPostBack Method
        if (!IsPostBack)
        {
            try
            {
                BindDataGrid();
                //SqlDataReader dtRead1;
                InitializeControl();
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
    #endregion

    #region InitializeControl method
    private void InitializeControl()
    {
        lblUnitDetails.Text = ObjDec.GetDecData(olng.GetItemDesc("lblUnitDetails"));
    }
    #endregion

    #region GRIDVIEW 'gvUntLst' ROWDATABOUND EVENT
    protected void gvUntLst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region SET LINK
                if (strType == "E")
                {

                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUntCode");
                    lnk.Enabled = true;
                    ///added by akshay on 17-02-14 added parameter to send unit address
                    Label lblU = new Label();
                    lblU = (Label)e.Row.FindControl("lblUntAddr");
                    string lb = lblU.Text;
                    /////lnk.Attributes.Add("onClick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "") + "','" + e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "") + "','" + lb.ToString().Trim() + "');return false;");

                }
                else if (strType == "N")
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUntCode");
                    lnk.Enabled = true;
                    ///added by akshay on 17-02-14 added parameter to send unit address
                    Label lblU = new Label();
                    lblU = (Label)e.Row.FindControl("lblUntAddr");
                    string lb = lblU.Text;
                    /////lnk.Attributes.Add("onClick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "") + "','" + e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "") + "','" + lb.ToString().Trim() + "');return false;");

                }
                else if (ViewState["strUntRule"].ToString() == "2" && strType == "N")
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUntCode");
                    lnk.Enabled = true;
                    ///added by akshay on 17-02-14 added parameter to send unit address
                    Label lblU = new Label();
                    lblU = (Label)e.Row.FindControl("lblUntAddr");
                    string lb = lblU.Text;
                    /////lnk.Attributes.Add("onClick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "") + "','" + e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "") + "','" + lb.ToString().Trim() + "');return false;");

                }
                else if (ViewState["strUntRule"].ToString() == "4" && strType == "N")
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUntCode");
                    lnk.Enabled = true;
                    ///added by akshay on 17-02-14 added parameter to send unit address
                    Label lblU = new Label();
                    lblU = (Label)e.Row.FindControl("lblUntAddr");
                    string lb = lblU.Text;
                    /////lnk.Attributes.Add("onClick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "") + "','" + e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "") + "','" + lb.ToString().Trim() + "');return false;");

                }
                else if (ViewState["strUntRule"].ToString() == "6" && strType == "N")
                {
                    LinkButton lnk = new LinkButton();
                    lnk = (LinkButton)e.Row.FindControl("lnkUntCode");
                    lnk.Enabled = true;
                    ///added by akshay on 17-02-14 added parameter to send unit address
                    Label lblU = new Label();
                    lblU = (Label)e.Row.FindControl("lblUntAddr");
                    string lb = lblU.Text;
                    /////lnk.Attributes.Add("onClick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim().Replace("&nbsp;", "") + "','" + e.Row.Cells[3].Text.Trim().Replace("&nbsp;", "") + "','" + lb.ToString().Trim() + "');return false;");

                }
                #endregion

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

    #region METHOD 'BindDataGrid()' DEFINITION
    protected void BindDataGrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            
            if (strType == "N")//Modified by swapnesh on 03/01/2014 to remove concept of unitrule
            {
                dsResult = new DataSet();
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr start
                string stragttype = Request.QueryString["agttype"].ToString();
                htParam.Clear();
                htParam.Add("@flagIsAgt", Request.QueryString["IsAgt"].ToString().Trim());
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@ChnCls", strChnCls);
                htParam.Add("@MgrAgtType", strAgentType);
                htParam.Add("@AgentType", stragttype);
                htParam.Add("@UntName", txtUntName.Text.Trim());
                htParam.Add("@UntCode", txtUntCode.Text.Trim());
                htParam.Add("@UntType", txtUntType.Text.Trim());

                if (Request.QueryString["agttype"].ToString() == "EP" || Request.QueryString["agttype"].ToString() == "LP")
                    htParam.Add("@EmpCode", strUser);

                ////modified by akshay on 17-02-14 start
                if (strMgrCode.ToString() != "" && strMgrCode.ToString() != null)
                {
                    htParam.Add("@flag", 5);
                }
                else
                {
                    htParam.Add("@flag", 6);
                }
                ////modified by akshay on 17-02-14 end
                if (strPageName.Equals("REG"))
                    dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr_AGENCY", htParam);
                else
                    dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr", htParam);

                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr end
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        ViewState["gv"] = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
                else
                {
                    gvUntLst.DataSource = null;
                    gvUntLst.DataBind();
                }
            }
            
            else if (strType == "E")//Modified by swapnesh on 03/01/2014 to remove concept of unitrule
            {
                string stragttype = Request.QueryString["agttype"].ToString();
                dsResult = new DataSet();
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr start
                htParam.Clear();
                htParam.Add("@flagIsAgt", Request.QueryString["IsAgt"].ToString().Trim());
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@ChnCls", strChnCls);
                htParam.Add("@MgrAgtType", strAgentType);
                htParam.Add("@AgentType", stragttype);
                htParam.Add("@UntName", txtUntName.Text.Trim());
                htParam.Add("@UntCode", txtUntCode.Text.Trim());
                if (strMgrCode.ToString() != "" && strMgrCode.ToString() != null)
                {
                    htParam.Add("@flag", 5);
                }
                else
                {
                    htParam.Add("@flag", 6);
                }
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr", htParam);
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr end
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        ViewState["gv"] = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
                else
                {
                    gvUntLst.DataSource = null;
                    gvUntLst.DataBind();
                }
            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "2")
            {
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetBranchUnitDetails", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        ViewState["gv"] = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
                else
                {
                    gvUntLst.DataSource = null;
                    gvUntLst.DataBind();
                }
            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "4")
            {
                dsResult = new DataSet();
               
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                htParam.Add("@ChnCls", strChnCls);
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetUnitDetails", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        ViewState["gv"] = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
                else
                {
                    gvUntLst.DataSource = null;
                    gvUntLst.DataBind();
                }
            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "6")
            {
                dsResult = new DataSet();
                
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetUnitDetailsForDA", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        ViewState["gv"] = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
                else
                {
                    gvUntLst.DataSource = null;
                    gvUntLst.DataBind();
                }
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

    #region METHOD 'GetDisplay()' DEFINITION
    public DataTable GetDisplay()
	{
        Hashtable htParam1 = new Hashtable();
        try
        {
            if (strType == "N" && ViewState["strUntRule"].ToString() == "1")
            {
                string stragttype = Request.QueryString["agttype"].ToString();
                dsResult = new DataSet();
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr start
                htParam.Clear();
                htParam.Add("@flagIsAgt", Request.QueryString["IsAgt"].ToString().Trim());
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@ChnCls", strChnCls);
                htParam.Add("@MgrAgtType", strAgentType);
                htParam.Add("@AgentType", stragttype);
                htParam.Add("@flag", 5);
                htParam.Add("@UntName", txtUntName.Text.Trim());
                htParam.Add("@UntCode", txtUntCode.Text.Trim());
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr", htParam);
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr end
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }
            }
            else if (strType == "E" && ViewState["strUntRule"].ToString() == "1")
            {
                string stragttype = Request.QueryString["agttype"].ToString();
                dsResult = new DataSet();
                htParam.Clear();
                htParam.Add("@flagIsAgt", Request.QueryString["IsAgt"].ToString().Trim());
                htParam.Add("@MgrCode", strMgrCode);
                htParam.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam.Add("@BizSrc", strBizSrc);
                htParam.Add("@ChnCls", strChnCls);
                htParam.Add("@MgrAgtType", strAgentType);
                htParam.Add("@AgentType", stragttype);
                htParam.Add("@flag", 5);
                htParam.Add("@UntName", txtUntName.Text.Trim());
                htParam.Add("@UntCode", txtUntCode.Text.Trim());
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntCode_UntMgr", htParam);
                //Added by Pranjali on 10-07-2013 for fetching data from UntMgr end
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                    else
                    {
                        gvUntLst.DataSource = null;
                        gvUntLst.DataBind();
                    }
                }

            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "2")
            {

                htParam1.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam1.Add("@BizSrc", strBizSrc);
                htParam1.Add("@MgrCode", strMgrCode);
                htParam1.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetBranchUnitDetails", htParam1);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                }
            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "4")
            {
                dsResult = new DataSet();

                htParam1.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam1.Add("@BizSrc", strBizSrc);
                htParam1.Add("@MgrCode", strMgrCode);
                htParam1.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetUnitDetails", htParam1);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                }
            }
            else if (strType == "N" && ViewState["strUntRule"].ToString() == "6")
            {
                dsResult = new DataSet();

                htParam1.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htParam1.Add("@BizSrc", strBizSrc);
                htParam1.Add("@MgrCode", strMgrCode);
                htParam1.Add("@RecruitDate", DateTime.Parse(strRecruitDate).ToString("yyyy/MM/dd"));
                dsResult = dataAccess.GetDataSetForPrc("Prc_AgyAdmin_GetUnitDetailsForDA", htParam1);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUntLst.DataSource = dsResult.Tables[0];
                        gvUntLst.DataBind();
                    }
                }
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
        return dsResult.Tables[0];
        htParam = null;
	}
	#endregion
   
	#region PageIndexChanging
	protected void gvUntLst_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
        try
        {
            
            DataTable dt1 = ViewState["gv"] as DataTable;
            DataView dv1 = new DataView(dt1);
            GridView dgSource1 = (GridView)sender;

            dgSource1.PageIndex = e.NewPageIndex;
            dv1.Sort = dgSource1.Attributes["SortExpression"];

            if (dgSource1.Attributes["SortASC"] == "No")
            {
                dv1.Sort += " DESC";
            }

            dgSource1.DataSource = dv1;
            dgSource1.DataBind();
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
   
	#region Sorting
	protected void gvUntLst_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = ViewState["gv"] as DataTable;
            DataView dv = new DataView(dt);
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

    #region btnSearch_Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataGrid();
    }
    #endregion

    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtUntCode.Text = "";
        txtUntName.Text = "";
        gvUntLst.DataSource = null;
        gvUntLst.DataBind();
    }
    #endregion

    #region ChkSelect_CheckedChanged

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        #region CHECKBOX validation
        htParam.Clear();
        htParam.Add("@BizSrc", strBizSrc);
        htParam.Add("@ChnCls", strChnCls);
        htParam.Add("@MemType", Request.QueryString["agttype"].ToString().Trim());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUntLocn", htParam);
        #endregion

        if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
        {
            if (dsResult.Tables[0].Rows[0]["UnitLocation"].ToString().Trim() == "0")
            {
                //var activeCheckBox = sender as CheckBox;
                //if (activeCheckBox != null)
                //{
                //    var isChecked = activeCheckBox.Checked;
                //    var tempCheckBox = new CheckBox();
                //    foreach (GridViewRow gvRow in gvUntLst.Rows)
                //    {
                //        tempCheckBox = gvRow.FindControl("ChkSelect") as CheckBox;
                //        if (tempCheckBox != null)
                //        {
                //            tempCheckBox.Checked = false;
                //        }
                //    }

                //    if (isChecked)
                //    {
                //        activeCheckBox.Checked = true;
                //    }

                //}
                //added by ajay 10052023
                CheckBox currentCheckBox = (CheckBox)sender;
                // Uncheck previously selected checkboxes
                foreach (GridViewRow row in gvUntLst.Rows)
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
            else
            {
                //added by ajay 10052023
                CheckBox currentCheckBox = (CheckBox)sender;
                // Uncheck previously selected checkboxes
                foreach (GridViewRow row in gvUntLst.Rows)
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
        }
    }
    #endregion

    #region btnOK_Click
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UnitCode");
            dt.Columns.Add("UnitDesc01");
            dt.Columns.Add("UnitTypDesc");
            dt.Columns.Add("Adr1");


            for (int intRowCount = 0; intRowCount <= gvUntLst.Rows.Count - 1; intRowCount++)
            {
                CheckBox ChkSelect = (CheckBox)gvUntLst.Rows[intRowCount].Cells[5].FindControl("ChkSelect");
                LinkButton UnitCode = (LinkButton)gvUntLst.Rows[intRowCount].Cells[0].FindControl("lnkUntCode");
                Label UnitDesc = (Label)gvUntLst.Rows[intRowCount].Cells[1].FindControl("lblUnitDesc");
                Label UnitTyp = (Label)gvUntLst.Rows[intRowCount].Cells[2].FindControl("lblUnitType");
                Label Adr = (Label)gvUntLst.Rows[intRowCount].Cells[4].FindControl("lblUntAddr");

                if (ChkSelect.Checked == true)
                {
                    chkflag = true;
                    DataRow dr = dt.NewRow();
                    dr["UnitCode"] = UnitCode.Text;
                    dr["UnitDesc01"] = UnitDesc.Text;
                    dr["UnitTypDesc"] = UnitTyp.Text;
                    dr["Adr1"] = Adr.Text;
                    dt.Rows.Add(dr);
                }                             


            }
            if (chkflag == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select atleast one unit code')", true);
                return;
            }
            Session["unt"] = dt;
            //this.PreviousPage.FindControl("gvUntLst")
            //GridView grv = ((GridView)this.Page.PreviousPage.FindControl("gvUntLst"));
            //grv.DataSource = dt;
            //grv.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
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
    protected void btnClear1_Click(object sender, EventArgs e)
    {
        txtUntCode.Text = "";
        txtUntName.Text = "";
        txtUntType.Text = "";
    }
    #endregion

    public void singlecheck()
    {
       
    }
}

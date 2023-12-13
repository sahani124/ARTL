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
using System.Data.SqlClient;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_ISys_ChannelMgmt_PopAGTSearchLvl : BaseClass
{
    #region DECLARE VARIABLES
    DataSet dsResult;
    private multilingualManager olng;
    private string strUserLang;
    string AgentType, BizSrc, ChnCls, ChnDesc, SubClsDesc, strXML = "";
    XmlDocument doc = new XmlDocument();
    string ErrMsg, AuditType;
    DataAccessClass objDAL = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    string chnnl, chnlcls;
    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    ErrLog objErr = new ErrLog();
    SqlDataReader dtRead;
    Hashtable HtParam = new Hashtable();
    #endregion

    #region PAGE_LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "AGTSearchLvl.aspx", strUserLang);
        lblMessage.Text = "";
        lblMessage.Visible = false;
        if (!IsPostBack)
        {
            bindDdlFincYear();
            InitializeControl();

            if (Request.QueryString["chncls"] != null)
            {
                string strSubFlag = Request.QueryString["SubClass"].ToString();
                string strFlag = Request.QueryString["chncls"].ToString();
                string chnl = Request.QueryString["chnltyp"].ToString();

                if (strFlag == "All" && strSubFlag == "All")
                {
                    GetCmpyChnl();
                    this.BindDataGrid();
                }
                else if (strFlag != "All" && strSubFlag == "All")
                {
                    GetCmpyChnl();
                    ddlSalesChannel.SelectedValue = strFlag;
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader dtRead;
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader drRead;
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    drRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    
                    if (drRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = drRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    drRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                }
                else if (strFlag != "All" && strSubFlag == "All")
                {
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlSalesChannel.SelectedValue = strFlag;
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader dtRead;
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();

                }
                else if (strFlag != "All" && strSubFlag != "All")
                {
                    ddlSalesChannel.SelectedValue = strFlag;
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlChnnlClass.Items.Clear();
                    ddlChnnlClass.SelectedValue = strSubFlag;
                    SqlDataReader dtRead;

                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();

                }
                else
                {
                    ddlSalesChannel.SelectedValue = strFlag;
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));

                    ddlChnnlClass.Items.Clear();
                    ddlChnnlClass.SelectedValue = strSubFlag;
                    SqlDataReader dtRead;
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                }

            }
            else if (Request.QueryString["Code"] != null)
            {
                //string strAgentType = Request.QueryString["AgentType"].ToString();//commented by akshay on 16/12/13
                string strFlag = Request.QueryString["Code"].ToString();
                string strSubFlag = Request.QueryString["SubClass"].ToString();
                string chnl = Request.QueryString["chnltyp"].ToString();
                rdbChnlTyp.SelectedValue = chnl;
                //if (strFlag == "All" && strSubFlag == "All" && strAgentType == "All")//commented by akshay on 16/12/13
                if (strFlag == "All" && strSubFlag == "All")
                {
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    this.BindDataGrid();
                }
                //else if (strFlag != "All" && strSubFlag == "All" && strAgentType == "All")//commented by akshay on 16/12/13
                else if (strFlag != "All" && strSubFlag == "All")
                {

                    ddlSalesChannel.SelectedValue = strFlag;
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlChnnlClass.Items.Clear();
                    //ddlChnnlClass.SelectedValue = strSubFlag;
                    

                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                    ddlChnnlClass.Items.Clear();
                    //ddlChnnlClass.SelectedValue = strSubFlag;
                    SqlDataReader drRead;
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    drRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    //changed by nitin
                    //drRead = objDAL.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSalesChannel.SelectedValue + "'");
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END
                    if (drRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = drRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    drRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                }
                //else if (strFlag != "All" && strSubFlag == "All" && strAgentType != "All")//commented by akshay on 16/12/13
                else if (strFlag != "All" && strSubFlag == "All")
                {
                    ddlSalesChannel.SelectedValue = strFlag;
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader dtRead;

                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();

                }
                else if (strFlag != "All" && strSubFlag != "All")
                {

                    ddlSalesChannel.SelectedValue = strFlag;
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlChnnlClass.Items.Clear();
                    ddlChnnlClass.SelectedValue = strSubFlag;
                    SqlDataReader dtRead;
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    //changed by nitin
                    //dtRead = objDAL.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSalesChannel.SelectedValue + "'");
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();

                }
                else
                {
                    if (strFlag != "All")
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                    }
                    GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                    ddlChnnlClass.Items.Clear();
                    ddlChnnlClass.SelectedValue = strSubFlag;
                    SqlDataReader dtRead;
                    //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;

                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.BindDataGrid();
                }
            }
            else
            {
                ////nitin
                GetCmpyChnl(); //added by akshay on 20/12/13 to get hierarchy names based on company and channel
                tbdgDtls.Visible = false;
                trDetails.Visible = false;
                trDgDetails.Visible = false;
            }

        }

    }
    #endregion

    #region InitializeControl
    private void InitializeControl()
    {
        lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel.Text"));
        lblChnnlClass.Text = (olng.GetItemDesc("lblChnnlClass.Text"));
        lblChnlType.Text = (olng.GetItemDesc("lblChnlType.Text"));
        //lblAgentType.Text = (olng.GetItemDesc("lblAgentType.Text"));
        lblAgtTypeSearch.Text = (olng.GetItemDesc("lblAgtTypeSearch.Text"));
        lblAgtTypSearchRes.Text = (olng.GetItemDesc("lblAgtTypSearchRes.Text"));
    }
    #endregion

    #region Button btnSearch  Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataGrid();
    }
    #endregion


    #region DATAGRID 'dgDetails' SORT EVENT
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = GetDataTable();
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


    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        try
        {
            dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Add("@CarrierCode", "2");
            if (ddlSalesChannel.SelectedIndex == 0)
            {
                htParam.Add("@BizSrc", "");
            }
            else
            {
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
            }
            if (ddlChnnlClass.SelectedIndex == 0)
            {
                htParam.Add("@ChnnlClass", "");
            }
            else
            {
                htParam.Add("@ChnnlClass", ddlChnnlClass.SelectedValue);
            }
            htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
            htParam.Add("@Period", ddlFincYear.SelectedValue);
            htParam.Add("@BaseVersion", ddlBaseVersion.SelectedValue);
            dsResult = objDAL.GetDataSetForPrc("prc_AgtLvl_Search", htParam);
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
    }
    #endregion


    #region METHOD 'ShowPageInformation'
    /// <summary>
    /// This method displays paging information in the appropriate label
    /// </summary>
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion


    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //dgDetails.PageIndex = e.NewPageIndex;
        //BindDataGrid();

        try
        {
            DataTable dt = GetDataTable();
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

    #region BIND DATAGRID 'dgDetails' METHOD
    protected void BindDataGrid()
    {
        try
        {
            dgDetails.PageSize = 10;
            dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Add("@CarrierCode", "2");
            if (ddlSalesChannel.SelectedIndex == 0)
            {
                htParam.Add("@BizSrc", "");
            }
            else
            {
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
            }
            if (ddlChnnlClass.SelectedIndex == 0)
            {
                htParam.Add("@ChnnlClass", "");
            }
            else
            {
                htParam.Add("@ChnnlClass", ddlChnnlClass.SelectedValue);
            }

            htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
            htParam.Add("@Period", ddlFincYear.SelectedValue);
            htParam.Add("@BaseVersion", ddlBaseVersion.SelectedValue);
            //chnaged by nitin
            dsResult = objDAL.GetDataSetForPrc("prc_AgtLvl_Search", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    if (rdbChnlTyp.SelectedValue == "0")
                    {
                        dgDetails.Columns[1].HeaderText = "Hierarchy Name";
                    }
                    else if (rdbChnlTyp.SelectedValue == "1")
                    {
                        dgDetails.Columns[1].HeaderText = "Hierarchy Name";
                    }

                    dgDetails.DataBind();
                    ShowPageInformation();
                    tbdgDtls.Visible = true;
                    trDetails.Visible = true;
                    trDgDetails.Visible = true;
                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    tbdgDtls.Visible = true;
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                }
            }
            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblPageInfo.Text = "";
                tbdgDtls.Visible = false;
                trDetails.Visible = false;
                trDgDetails.Visible = false;
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

    #region DropDown 'ddlSalesChannel' Selected Index Changed Event
    protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           ddlChnnlClass.Items.Clear();
            SqlDataReader dtRead;
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
            dtRead = objDAL.Common_exec_reader_prc_common("Prc_ddlchnnlsubcls", htParam);
            if (dtRead.HasRows)
            {
                ddlChnnlClass.DataSource = dtRead;
                ddlChnnlClass.DataTextField = "ChnlDesc";
                ddlChnnlClass.DataValueField = "ChnCls";
                ddlChnnlClass.DataBind();
            }
            dtRead = null;
            ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
            tbdgDtls.Visible = false;
            trDetails.Visible = false;
            trDgDetails.Visible = false;
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


    #region BUTTON 'btnClear' ONCLCIK EVENT
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("PopAGTSearchLvl.aspx");
    }
    #endregion

    protected void ddlChnnlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    #region rdbChnlTyp_SelectedIndexChanged
    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbChnlTyp.SelectedValue == "0")
        {
            GetCmpyChnl();
        }
        else if (rdbChnlTyp.SelectedValue == "1")
        {
            GetCmpyChnl();
        }
    }
    #endregion

    #region GetCmpyChnl
    //added by akshay on 20/12/13 to get hierarchy names based on complany and channel
    protected void GetCmpyChnl()
    {
        try
        {
            ddlChnnlClass.Items.Clear();
            ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
            //dgDetails.Visible = false;
            objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
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
    //added by akshay on 16/12/13 end
    #endregion

    private void bindDdlFincYear()
    {
        HtParam.Clear();
        dsResult = null;
        HtParam.Clear();
        HtParam.Add("@Flag", "UnitType");
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetFincYears", HtParam);
        if (dsResult != null)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlFincYear.DataSource = dsResult.Tables[0];
                ddlFincYear.DataTextField = "Period";
                ddlFincYear.DataValueField = "Period";
                ddlFincYear.DataBind();
            }
        }
        ddlFincYear.Items.Insert(0, new ListItem("-- Select --", ""));
    }
    protected void ddlFincYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDdlBaseVersion();

    }

    private void bindDdlBaseVersion()
    {
        HtParam.Clear();
        dsResult = null;
        HtParam.Add("@Period", ddlFincYear.SelectedValue);
        HtParam.Add("@Flag", "UnitType");
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetVersionDtls", HtParam);
        if (dsResult != null)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlBaseVersion.DataSource = dsResult.Tables[0];
                ddlBaseVersion.DataTextField = "BaseVersion";
                ddlBaseVersion.DataValueField = "BaseVersion";
                ddlBaseVersion.DataBind();
            }
            ddlBaseVersion.Items.Insert(0, new ListItem("-- Select --", ""));
        }

    }

       
}
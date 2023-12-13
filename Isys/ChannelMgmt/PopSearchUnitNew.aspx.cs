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
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;


public partial class Application_ISys_ChannelMgmt_PopSearchUnitNew : BaseClass
{
    #region DECLARATIONS
    Hashtable htable = new Hashtable();
    private multilingualManager olng;
    private string strUserLang;
    string BizSrc, ChnCls, UnitType;
    string ErrMsg, AuditType, strXML = "";
    XmlDocument doc = new XmlDocument();
    EncodeDecode ObjDec = new EncodeDecode();
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    string chnnl, chnlcls;///added by akshay
    ErrLog objErr = new ErrLog();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            lblMessage.Text = "";
            lblMessage.Visible = false;
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "SearchUnitNew.aspx", strUserLang);
            Session["CarrierCode"] = '2';
            if (!IsPostBack)
            {

                bindDdlFincYear();
                InitializeControl();
                if (Request.QueryString["chncls"] != null)
                {
                    string strSubFlag = Request.QueryString["SubClass"].ToString();

                    //string[] strFlagArr = Request.QueryString["flag"].ToString().Trim().Split('/');
                    string strFlag = Request.QueryString["chncls"].ToString();
                    if (strFlag == "All" && strSubFlag == "All")
                    {
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.Items.Clear();
                        SqlDataReader dtRead;
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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

                        this.RefreshGrid();
                    }
                    else
                    {

                        if (strSubFlag != "All")
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            ddlChnnlClass.SelectedValue = strSubFlag;
                            ddlChnnlClass.Items.Clear();
                            SqlDataReader dtRead;
                            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                            Hashtable htParam = new Hashtable();
                            htParam.Clear();
                            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
                            this.RefreshGrid();
                        }
                        else
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            ddlChnnlClass.Items.Clear();
                            SqlDataReader dtRead;
                            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                            Hashtable htParam = new Hashtable();
                            htParam.Clear();
                            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
                            this.RefreshGrid();

                        }
                    }

                }
                else if (Request.QueryString["Code"] != null)
                {
                    //string[] strFlagArr = Request.QueryString["Code"].ToString().Trim().Split('/');
                    string strFlag = Request.QueryString["Code"].ToString();
                    string strSubFlag = Request.QueryString["SubClass"].ToString();

                    if (strFlag == "All" && strSubFlag == "All")
                    {
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.Items.Clear();
                        SqlDataReader dtRead;
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
                        this.RefreshGrid();
                    }
                    else
                    {
                        if (strSubFlag != "All")
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
                            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
                            this.RefreshGrid();
                        }
                        else
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                            ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                            ddlChnnlClass.Items.Clear();
                            SqlDataReader dtRead;
                            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                            Hashtable htParam = new Hashtable();
                            htParam.Clear();
                            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
                            this.RefreshGrid();

                        }

                    }
                }
                else
                {
                    //objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    tbldgDtls.Visible = false;
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
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
   
    #region InitializeControl
    private void InitializeControl()
    {
        lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
        lblChnnlClass.Text = (olng.GetItemDesc("lblChnnlClass.Text"));
        lblChannelUnitTypesetup.Text = (olng.GetItemDesc("lblChannelUnitTypesetup"));
        lblChannelUnitTypeSearch.Text = (olng.GetItemDesc("lblChannelUnitTypeSearch"));
        lblChnlType.Text = (olng.GetItemDesc("lblChnlType.Text"));//added by akshay on 13/12/13
    }
    #endregion


    #region SEARCH Button
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsdataset = new DataSet();
            string BizSrc = this.ddlSalesChannel.SelectedValue;
            this.RefreshGrid();
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

    #region REFRESHGRID
    private void RefreshGrid()
    {
        //Added by Kalyani on 16-12-2013 to display Company or Channel selection start
        if (rdbChnlTyp.SelectedValue == "0")
        {
            htable.Add("@Flag", "O");
        }
        else
        {
            htable.Add("@Flag", "C");
        }
        //Added by Kalyani on 16-12-2013 to display Company or Channel selection end

        string BizSrc, ChnCls;
        if (this.ddlSalesChannel.SelectedIndex == 0)
        {
            BizSrc = "";
        }
        else
        {
            BizSrc = this.ddlSalesChannel.SelectedValue;
        }
        if (this.ddlChnnlClass.SelectedIndex == 0)
        {
            ChnCls = "";
        }
        else
        {
            ChnCls = this.ddlChnnlClass.SelectedValue;
        }
        lblMessage.Visible = false;
        DataSet dsdataset = new DataSet();

        htable.Add("@BizSrc", BizSrc);
        htable.Add("@ChnCls", ChnCls);
        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htable.Add("@Period", ddlFincYear.SelectedValue);
        htable.Add("@BaseVersion", ddlBaseVersion.SelectedValue);
        dsdataset = objDAL.GetDataSetForPrc("prc_UnitSearch", htable);
        htable.Clear();
        if (dsdataset.Tables.Count > 0)
        {
            if (dsdataset.Tables[0].Rows.Count > 0)
            {
                dgDetails.DataSource = dsdataset.Tables[0];
                //Added by Kalyani on 14-12-2013 to chnage gridview header text on radio button selection start
                if (rdbChnlTyp.SelectedValue == "0")////added by akshay on 020514
                {
                    dgDetails.Columns[0].HeaderText = "Company code";
                }
                else if (rdbChnlTyp.SelectedValue == "1")
                {
                    dgDetails.Columns[0].HeaderText = "Channel code";
                }
                //Added by Kalyani on 14-12-2013 to chnage gridview header text on radio button selection end
                dgDetails.DataBind();
                ShowPageInformation();
                tbldgDtls.Visible = true;
                trDetails.Visible = true;
                trDgDetails.Visible = true;
            }
            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblPageInfo.Text = "";
                tbldgDtls.Visible = false;
                trDetails.Visible = false;
                trDgDetails.Visible = false;
            }
        }
        else
        {
            dgDetails.DataSource = null;
            dgDetails.DataBind();
            lblPageInfo.Text = "";
            tbldgDtls.Visible = false;
            trDetails.Visible = false;
            trDgDetails.Visible = false;
        }
        ShowPageInformation();
    }
    #endregion

    #region GetDisplay
    public DataTable GetDisplay(string BizSrc, string ChnCls)
    {
        DataSet dsdataset = new DataSet();
        if (rdbChnlTyp.SelectedValue == "0")
        {
            htable.Add("@Flag", "O");
        }
        else
        {
            htable.Add("@Flag", "C");
        }
        htable.Add("@BizSrc", BizSrc);
        htable.Add("@ChnCls", ChnCls);
        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htable.Add("@Period", ddlFincYear.SelectedValue);
        htable.Add("@BaseVersion", ddlBaseVersion.SelectedValue);
        dsdataset = objDAL.GetDataSetForPrc("prc_UnitSearch", htable);
        htable.Clear();
        return dsdataset.Tables[0];

    }
    #endregion

    #region SORTING
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
            string BizSrc = this.ddlSalesChannel.SelectedValue;
            string ChnCls = this.ddlChnnlClass.SelectedValue;
            if (BizSrc == "All")
            {
                BizSrc = "";
            }
            if (ChnCls == "All")
            {
                ChnCls = "";
            }
            DataTable dt = GetDisplay(BizSrc, ChnCls);
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

    #region PAGEINDEX
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            string BizSrc = this.ddlSalesChannel.SelectedValue;
            string ChnCls = this.ddlChnnlClass.SelectedValue;
            if (BizSrc == "All")
            {
                BizSrc = "";
            }
            if (ChnCls == "All")
            {
                ChnCls = "";
            }
            DataTable dt = GetDisplay(BizSrc, ChnCls);
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

    #region PAGEINFORMATION
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region CLEAR Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("PopSearchUnitNew.aspx");
    }
    #endregion

    #region SelectedIndex
    protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlChnnlClass.Items.Clear();
            SqlDataReader dtRead;
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
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
            dgDetails.DataSource = null;
            dgDetails.DataBind();
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

    #region rdbChnlTyp_SelectedIndexChanged
    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbChnlTyp.SelectedValue == "0")
        {
            ddlChnnlClass.Items.Clear();
            ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
            //dgDetails.Visible = false;
            objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "0");
            ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
        }
        else
        {
            ddlChnnlClass.Items.Clear();
            ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
            //dgDetails.Visible = false;
            objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
            ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
        }
    }
    #endregion

    private void bindDdlFincYear()
    {
        htable.Clear();
        dsResult = null;
        htable.Clear();
        htable.Add("@Flag", "UnitType");
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetFincYears", htable);
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
        htable.Clear();
        dsResult = null;
        htable.Add("@Period", ddlFincYear.SelectedValue);
        htable.Add("@Flag", "UnitType");
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetVersionDtls", htable);
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
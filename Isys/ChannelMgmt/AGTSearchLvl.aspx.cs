using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
using INSCL.DAL;

namespace INSCL
{
    public partial class AGTSearchLvl : Base
    {
        #region DECLARE VARIABLES
        DataSet dsResult;
        private multilingualManager olng;
        private string strUserLang;
        string AgentType, BizSrc, ChnCls, ChnDesc, SubClsDesc, strXML = "";
        XmlDocument doc = new XmlDocument();
        string ErrMsg, AuditType;
        //changed by nitin
        //DataAccessLayer objDAL = new DataAccessLayer();
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        string chnnl, chnlcls;
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;
        ErrLog objErr = new ErrLog();
        #endregion

        #region PAGE_LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    //added by bhau
                    Session["OldProductDetails"] = null;
                    Session["ProductDetails"] = null;
                    //End

                    divcmpsrchhdrcollapse.Style.Add("display", "none");
                    divCopy.Style.Add("display", "none");
                    EnableDisableButton();

                    InitializeControl();
                    LoadData();




                }

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "Page_Load", ex);
            }
        }
        #endregion
        #region Load Data
        private void LoadData()
        {
            try
            {
                if (Request.QueryString["chncls"] != null)
                {
                    string strSubFlag = Request.QueryString["SubClass"].ToString();
                    string strFlag = Request.QueryString["chncls"].ToString();
                    string chnl = Request.QueryString["chnltyp"].ToString();
                    rdbChnlTyp.SelectedValue = chnl;
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
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();
                        ddlChnnlClass.Items.Clear();
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START

                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");

                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();
                    }
                    else if (strFlag != "All" && strSubFlag == "All")
                    {
                        GetCmpyChnl();//added by akshay on 20/12/13 to get hierarchy names based on complany and channel
                        ddlSalesChannel.SelectedValue = strFlag;
                        ddlChnnlClass.Items.Clear();
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();

                    }
                    //else if (strFlag != "All" && strSubFlag != "All" && strAgentType == "All")//commented by akshay on 16/12/13
                    else if (strFlag != "All" && strSubFlag != "All")
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                        GetCmpyChnl();
                        ddlChnnlClass.Items.Clear();
                        ddlChnnlClass.SelectedValue = strSubFlag;

                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
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
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
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
                        GetCmpyChnl();
                        this.BindDataGrid();
                    }
                    //else if (strFlag != "All" && strSubFlag == "All" && strAgentType == "All")//commented by akshay on 16/12/13
                    else if (strFlag != "All" && strSubFlag == "All")
                    {

                        ddlSalesChannel.SelectedValue = strFlag;
                        GetCmpyChnl();
                        ddlChnnlClass.Items.Clear();
                        //ddlChnnlClass.SelectedValue = strSubFlag;
                        //SqlDataReader dtRead;

                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();
                        ddlChnnlClass.Items.Clear();
                        //ddlChnnlClass.SelectedValue = strSubFlag;
                        //SqlDataReader drRead;
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();
                    }
                    //else if (strFlag != "All" && strSubFlag == "All" && strAgentType != "All")//commented by akshay on 16/12/13
                    else if (strFlag != "All" && strSubFlag == "All")
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                        GetCmpyChnl();
                        ddlChnnlClass.Items.Clear();
                        //SqlDataReader dtRead;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.BindDataGrid();

                    }
                    else if (strFlag != "All" && strSubFlag != "All")
                    {

                        ddlSalesChannel.SelectedValue = strFlag;
                        GetCmpyChnl();
                        ddlChnnlClass.Items.Clear();
                        ddlChnnlClass.SelectedValue = strSubFlag;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        BindDataGrid();

                    }
                    else
                    {
                        if (strFlag != "All")
                        {
                            ddlSalesChannel.SelectedValue = strFlag;
                        }
                        GetCmpyChnl();
                        ddlChnnlClass.Items.Clear();
                        ddlChnnlClass.SelectedValue = strSubFlag;
                        //SqlDataReader dtRead;
                        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        BindDataGrid();
                    }
                }
                else
                {
                    ////nitin
                    GetCmpyChnl();
                }
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "LoadData", ex);
            }
        }
        #endregion

        #region EnableDisableButton Method
        private void EnableDisableButton()
        {
            try
            {
                dsResult = null;

                strDesc01 = "Enable Modification of Channel Maintenance";
                strModule = "CHMS";
                dsResult = objCommonU.GetConfigSettings(strDesc01, strModule);
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    strValue = dsResult.Tables[0].Rows[0]["Value"].ToString().Trim();
                    HttpContext.Current.Session["StrValue"] = strValue;
                }
                if (strValue == "YES")
                {
                    btnAddNew.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    btnAddNew.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "EnableDisableButton", ex);
            }
        }
        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            try
            {
                lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel.Text"));
                lblChnnlClass.Text = (olng.GetItemDesc("lblChnnlClass.Text"));
                lblChnlType.Text = (olng.GetItemDesc("lblChnlType.Text"));
                //lblAgentType.Text = (olng.GetItemDesc("lblAgentType.Text"));
                lblAgtTypeSearch.Text = (olng.GetItemDesc("lblAgtTypeSearch.Text"));
                lblAgtTypSearchRes.Text = (olng.GetItemDesc("lblAgtTypSearchRes.Text"));
                lblAgtTypeSearch.Text = "MEMBER TYPE SEARCH";
                lblAgtTypSearchRes.Text = "MEMBER TYPE SEARCH RESULTS";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "InitializeControl", ex);
            }
        }
        #endregion

        #region Button btnSearch  Click Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            divcmpsrchhdrcollapse.Style.Add("display", "block");
            BindDataGrid();

            Loading_gif.Style.Add("display", "none");
            Div1.Style.Add("display", "block");
            btnCopy.Visible = false;
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

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "dgDetails_Sorting", ex);
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
                FillddlcheckNull(ddlSalesChannel, htParam, "@BizSrc", ddlSalesChannel.SelectedValue.ToString());
                FillddlcheckNull(ddlSalesChannel, htParam, "@ChnnlClass", ddlChnnlClass.SelectedValue.ToString());
                htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
                dsResult = objDAL.GetDataSetForPrc("prc_AgtLvl_Search", htParam);
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "GetDataTable", ex);
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
            //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
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

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "dgDetails_PageIndexChanging", ex);
            }
        }
        #endregion


        #region DATAGRID 'dgDetails' ROWDATABOUND EVENT
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {//updated by akshay to get the querystring values of agent Type and chnlDesc for label values on AGTLevel.aspx page
                ///e.Row.Cells[1].Text = "<a href=\"AGTLevel.aspx?AgtType=" + e.Row.Cells[1].Text + "&SalesChnl=" + e.Row.Cells[0].Text + "&flag=E" + "&ChnlDesc=" + dsResult.Tables[0].Rows[0]["ChnlDesc"].ToString() + "&AgtTypeDesc=" + e.Row.Cells[5].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&SubClass=" + ddlChnnlClass.SelectedValue + "&AgentType=" + ddlAgentType.SelectedValue + "\">" + e.Row.Cells[1].Text + "</a>";
                var strChnCls1 = string.Empty;
                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    string strBiz = e.Row.Cells[1].Text.ToString();
                    strChnCls1 = e.Row.Cells[2].Text.ToString();
                    string unttyp = e.Row.Cells[6].Text.ToString();
                    var strChnCls = strChnCls1.Replace("amp;", "");
                    getValue(strBiz, strChnCls);
                    e.Row.Cells[0].Text = "<i class=\"fa fa-edit\"></i>&nbsp;<a href=\"AGTLevel.aspx?AgtType=" + e.Row.Cells[0].Text + "&SalesChnl=" + chnnl + "&flag=E" + "&ChnlDesc=" + e.Row.Cells[1].Text + "&AgtTypeDesc=" + e.Row.Cells[5].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&SubClass=" + chnlcls + "&UnitRank=" + e.Row.Cells[3].Text + "&chnltyp=" + rdbChnlTyp.SelectedValue + "\">" + e.Row.Cells[0].Text + "</a>";

                }


                //string strChnCls = 


                //e.Row.Cells[0].Text = "<a href=\"AGTLevel.aspx?AgtType=" + e.Row.Cells[0].Text + "&SalesChnl=" + dsResult.Tables[0].Rows[0]["BizSrc"].ToString() + "&flag=E" + "&ChnlDesc=" + e.Row.Cells[1].Text + "&AgtTypeDesc=" + e.Row.Cells[5].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&SubClass=" + dsResult.Tables[0].Rows[0]["ChnCls"].ToString() + "&UnitRank=" + e.Row.Cells[3].Text + "&chnltyp=" + rdbChnlTyp.SelectedValue + "\">" + e.Row.Cells[0].Text + "</a>";


            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                if (HttpContext.Current.Session["StrValue"].ToString() == "YES")
                {
                    l.Enabled = true;
                }
                else if (HttpContext.Current.Session["StrValue"].ToString() == "NO")
                {
                    l.Enabled = false;

                }
                l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record?')");
            }
        }

        private void getValue(string strBiz, string strChnCls)
        {
            try
            {
                dsResult = new DataSet();
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@ChnlDesc", strBiz);
                htParam.Add("@ChnClsDesc", strChnCls);
                dsResult.Clear();
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetBizChnlValue", htParam);
                chnnl = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                chnlcls = dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                //dsResult.Clear();
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
                dgDetails.PageSize = 50;
                dsResult = new DataSet();
                dsResult.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Add("@CarrierCode", "2");
                FillddlcheckNull(ddlSalesChannel, htParam, "@BizSrc", ddlSalesChannel.SelectedValue.ToString());
                FillddlcheckNull(ddlChnnlClass, htParam, "@ChnnlClass", ddlChnnlClass.SelectedValue.ToString());
                htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
                dsResult = objDAL.GetDataSetForPrc("prc_AgtLvl_Search", htParam);


                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        dgDetails.AllowSorting = true;
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
                        btnAddNew.Visible = true;
                        btnCopy.Visible = true;
                    }
                    else
                    {
                        dgDetails.AllowSorting = false;
                        ShowNoResultFound(dsResult.Tables[0], dgDetails);
                        txtPage.Text = "1";
                        btnprevious.Enabled = false;
                        btnnext.Enabled = false;
                        btnAddNew.Visible = true;
                        btnCopy.Visible = true;
                        lblMessage.Text = "0 record found.";
                    }
                }
                else
                {
                    dgDetails.AllowSorting = false;
                    ShowNoResultFound(dsResult.Tables[0], dgDetails);
                    txtPage.Text = "1";
                    btnAddNew.Visible = true;

                    lblMessage.Text = "0 record found.";
                }

                if (dgDetails.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                    btnprevious.Enabled = false;
                    txtPage.Text = "1";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "BindDataGrid", ex);
            }
        }
        #endregion


        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            int rowsCount = gv.Rows.Count;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[columnsCount - 1].Text = "";
            gv.Rows[0].Cells[columnsCount - 2].Text = "";
            gv.Rows[0].Cells[0].Text = "No Member type have been defined";
            source.Rows.Clear();
        }


        #region Button 'btnAddNew' Click Event
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AGTLevel.aspx?chncls=" + ddlSalesChannel.SelectedValue.ToString().Trim() + "&SubClass=" + ddlChnnlClass.SelectedValue + "&flag=N" + "&chnltyp=" + rdbChnlTyp.SelectedValue);
        }
        #endregion


        #region DropDown 'ddlSalesChannel' Selected Index Changed Event
        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChnnlClass.Items.Clear();
                //SqlDataReader dtRead;
                //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                ddlChnnlClass.Items.Remove("Select");
                ddlChnnlClass.Items.Remove("");
                ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
                btnAddNew.Visible = false;
                divcmpsrchhdrcollapse.Style.Add("display", "none");
                divCopy.Style.Add("display", "none");
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);
            }
        }
        #endregion


        #region BUTTON 'btnClear' ONCLCIK EVENT
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("AGTSearchLvl.aspx");
        }
        #endregion

        protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        #region ROWCOMMAND
        //protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //if (e.CommandName == "Delete")
        //    //{
        //    //    clsAgentLevelSetup objAgtType = new clsAgentLevelSetup();
        //    //    clsChannelSetup channelsetup = new clsChannelSetup();
        //    //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
        //    //    try
        //    //    {
        //    //        int intPos = row.Cells[0].Text.IndexOf('>');
        //    //        int intPos2 = row.Cells[0].Text.IndexOf('<', 1);
        //    //        ////AgentType = row.Cells[0].Text.Substring(intPos + 1, intPos2 - intPos - 1);
        //    //        //BizSrc = row.Cells[6].Text.Trim();
        //    //        //ChnCls = row.Cells[7].Text.Trim();
        //    //        ChnDesc = row.Cells[1].Text.Trim();
        //    //        SubClsDesc = row.Cells[2].Text.Trim();
        //    //        GridViewRow row1 = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //    //        Int32 rowind = row1.RowIndex;
        //    //        Label Bizs = (Label)row1.FindControl("lblbizsrc");
        //    //        BizSrc = Bizs.Text.Trim();
        //    //        Label Chncls = (Label)row1.FindControl("lblchncls");
        //    //        ChnCls = Chncls.Text.Trim();
        //    //        Label MemTyp = (Label)row1.FindControl("lblmemtyp");
        //    //        AgentType = MemTyp.Text.Trim();
        //    //        //Added code by venkat on 06/02/08
        //    //        ArrayList arrLst = new ArrayList();
        //    //        arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
        //    //        arrLst.Add(new prjXml.Collection("BizSrc", BizSrc));
        //    //        arrLst.Add(new prjXml.Collection("ChnCls", ChnCls));
        //    //        arrLst.Add(new prjXml.Collection("AgentType", AgentType));
        //    //        arrLst.Add(new prjXml.Collection("UnitRank", row.Cells[3].Text.ToString()));
        //    //        arrLst.Add(new prjXml.Collection("AgentLevel", row.Cells[4].Text.ToString()));
        //    //        arrLst.Add(new prjXml.Collection("AgentTypeDesc", row.Cells[5].Text.ToString()));
        //    //        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
        //    //        //objGetXml.CreateXmlAttribute(arrLst, Server.MapPath("AgtSearchLvl.xml"), 7);
        //    //        //doc.Load(Server.MapPath("AgtSearchLvl.xml"));
        //    //        //strXML = doc.OuterXml;

        //    //        XmlDocument xDoc = new XmlDocument();
        //    //        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
        //    //        strXML = xDoc.OuterXml;

        //    //        arrLst.Clear();
        //    //        //Ended code by venkat
        //    //        objAgtType.AgentTypeDelete(AgentType, BizSrc, "2", ChnCls);
        //    //        this.BindDataGrid();
        //    //        //lblMessage.Visible = true;
        //    //        //Added by Pranjali on 28-05-2013 for modal popup display start
        //    //        lblMessage.Text = "Selected Channel member type deleted successfully ";
        //    //        ///lbl.Text = "Channel member type deleted successfully" + "</br></br> Sales Channel:" + ddlSalesChannel.SelectedValue + "</br></br> Channel Sub Class :" + ddlChnnlClass.SelectedValue;
        //    //        ////chnlcls
        //    //        lbl_popup.Text = "Channel member type deleted successfully" + "</br></br> Sales Channel:" + ChnDesc + "</br></br> Channel Sub Class :" + SubClsDesc;
        //    //        // mdlpopup.Show();
        //    //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        //    //        //Added by Pranjali on 28-05-2013 for modal popup display end
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        lblMessage.Visible = true;
        //    //        lblMessage.Text = ex.Message;
        //    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    //        string sRet = oInfo.Name;
        //    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    //        String LogClassName = method.ReflectedType.Name;
        //    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //    //    }
        //    //    if (lblMessage.Text == "Selected member agent type deleted successfully")
        //    //    {
        //    //        ErrMsg = "S";
        //    //    }
        //    //    else
        //    //    {
        //    //        ErrMsg = "E";
        //    //    }
        //    //    if (ErrMsg == "S")
        //    //    {
        //    //        AuditType = "DE";
        //    //    }
        //    //    else
        //    //    {
        //    //        AuditType = "DE";
        //    //    }
        //    //    string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";
        //    //    channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + BizSrc + ChnCls + AgentType, "chnAgnSu", "Delete,clsAgentLevelSetup.cs", "prc_AgnLevel_Delete", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);


        //    //}
        //}

        //protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "AddMemType")
        //    {
        //        GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
        //        try
        //        {
        //            int intPos = row.Cells[0].Text.IndexOf('>');
        //            int intPos2 = row.Cells[0].Text.IndexOf('<', 1);
        //            ////AgentType = row.Cells[0].Text.Substring(intPos + 1, intPos2 - intPos - 1);
        //            //BizSrc = row.Cells[6].Text.Trim();
        //            //ChnCls = row.Cells[7].Text.Trim();
        //            ChnDesc = row.Cells[1].Text.Trim();
        //            SubClsDesc = row.Cells[2].Text.Trim();
        //            GridViewRow row1 = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //            Int32 rowind = row1.RowIndex;
        //            Label Bizs = (Label)row1.FindControl("lblbizsrc");
        //            BizSrc = Bizs.Text.Trim();
        //            Label Chncls = (Label)row1.FindControl("lblchncls");
        //            ChnCls = Chncls.Text.Trim();
        //            Label MemTyp = (Label)row1.FindControl("lblmemtyp");
        //            AgentType = MemTyp.Text.Trim();

        //            hdngvbizsrc.Value = Bizs.Text.Trim();
        //            hdngvchncls.Value = Chncls.Text.Trim();
        //            hdngvmemtype.Value = AgentType;
        //            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "funPopUp();", true);
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "funPopUpNew();", true);
        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    }

        //}

        #endregion

        protected void ddlChnnlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //commented by akshay on 16/12/13 start
            //ddlAgentType.Items.Clear();
            //SqlDataReader dtRead;
            ////Added By Sandeep Garg on 01-07-2013 To get agent Type on Channel sub class dropdownlist START
            //Hashtable htParam = new Hashtable();
            //htParam.Clear();
            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
            //htParam.Add("@ChnCls", ddlChnnlClass.SelectedValue);
            //dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgntypChnnlClass", htParam);

            ////changed by nitin

            ////dtRead = objDAL.exec_reader("SELECT AgentType,AgentType + ' - ' + AgentTypeDesc01 As AgentTypeDesc01 FROM chnAgnSu where CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' and BizSrc='" + ddlSalesChannel.SelectedValue + "' and ChnCls='" + ddlChnnlClass.SelectedValue + "'");
            ////Added By Sandeep Garg on 01-07-2013 To get agent Type on Channel sub class dropdownlist END

            //if (dtRead.HasRows)
            //{
            //    ddlAgentType.DataSource = dtRead;
            //    ddlAgentType.DataTextField = "AgentTypeDesc01";
            //    ddlAgentType.DataValueField = "AgentType";
            //    ddlAgentType.DataBind();
            //}
            //dtRead = null;
            //ddlAgentType.Items.Insert(0, new ListItem("All", "All"));
            //trDetails.Visible = false;
            //trDgDetails.Visible = false;
            //trBtnNew.Visible = false;
            //btnAddNew.Visible = false;
            //commented by akshay on 16/12/13 end
        }

        #region rdbChnlTyp_SelectedIndexChanged
        //added by akshay on 16/12/13 method used to fetch the channels based on company and channel
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
                ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
                //dgDetails.Visible = false;
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
                ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "GetCmpyChnl", ex);
            }
        }
        //added by akshay on 16/12/13 end
        #endregion

        #region btnCopy_Click
        protected void btnCopy_Click(object sender, EventArgs e)
        {
            //trCopy.Visible = true;
            //trCopyBtn.Visible = true;
            divCopy.Style.Add("display", "block");
            objCommonU.GetSalesChannel(ddlChnl, "", 1);
            ddlChnl_SelectedIndexChanged1(sender, e);
            ddlSubclass.SelectedValue = ddlChnnlClass.SelectedValue;
            // ddlSubclass.Items.Insert(0, new ListItem("All", "All"));
        }
        #endregion

        #region ddlChnl_SelectedIndexChanged
        protected void ddlChnl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnUpdate_Click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable htprm = new Hashtable();
                DataSet dsprm = new DataSet();
                htprm.Clear();
                dsprm.Clear();
                htprm.Add("@BizSrc ", ddlChnl.SelectedValue);
                htprm.Add("@ChnCls", ddlSubclass.SelectedValue);
                htprm.Add("@BizSrcOld", ddlSalesChannel.SelectedValue);
                htprm.Add("@ChnClsOld", ddlChnnlClass.SelectedValue);
                htprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                divCopy.Style.Add("display", "none");
                ddlSalesChannel.SelectedValue = ddlChnl.SelectedValue;
                ddlSalesChannel_SelectedIndexChanged(sender, e);
                ddlChnnlClass.SelectedValue = ddlSubclass.SelectedValue;
                BindDataGrid();
                btnCopy.Enabled = false;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "btnUpdate_Click", ex);
            }
        }
        #endregion

        protected void btnOldHier_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funpopup();", true);
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                BindDataGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnnext.Enabled = false;
                }
                int page = dgDetails.PageCount;
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "fillFinyr", ex);
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                BindDataGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnnext.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnprevious.Enabled = false;
                }
                int page = dgDetails.PageCount;
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }

                else
                {
                    btnprevious.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "btnprevious_Click", ex);
            }
        }

        protected void ddlChnl_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddlSubclass.Items.Clear();
            SqlDataReader dtRead;
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", 2);
            htParam.Add("@BizSrc", ddlChnl.SelectedValue);
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END

            if (dtRead.HasRows)
            {
                ddlSubclass.DataSource = dtRead;
                ddlSubclass.DataTextField = "ChnlDesc";
                ddlSubclass.DataValueField = "ChnCls";
                ddlSubclass.DataBind();
            }
            dtRead = null;
            ddlSubclass.Items.Insert(0, new ListItem("All", "All"));
        }

        //protected void lnkAddMemType_Click(object sender, EventArgs e)
        //{
        //    //clsAgentLevelSetup objAgtType = new clsAgentLevelSetup();
        //    //clsChannelSetup channelsetup = new clsChannelSetup();
        //    //GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

        //    //GridViewRow row1 = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //    //Int32 rowind = row1.RowIndex;
        //    //Label Bizs = (Label)row1.FindControl("lblbizsrc");
        //    //BizSrc = Bizs.Text.Trim();
        //    //Label Chncls = (Label)row1.FindControl("lblchncls");
        //    //ChnCls = Chncls.Text.Trim();
        //    //Label MemTyp = (Label)row1.FindControl("lblmemtyp");
        //    //AgentType = MemTyp.Text.Trim();

        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "funcAddMemberTypePopup()", true);


        //    //string title = "Greetings";
        //    //string body = "Welcome to ASPSnippets.com";
        //    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        //}


        protected void lnkAddMemType_Click(object sender, EventArgs e)
        {



        }

    }
}

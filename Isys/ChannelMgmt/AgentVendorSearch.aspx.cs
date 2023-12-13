using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSCL.App_Code;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using INSCL.DAL;
using Insc.Common.Multilingual;
using DataAccessClassDAL;


public partial class Application_INSC_ChannelMgmt_AgentVendorSearch : BaseClass
{
    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    private INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    string agnType = string.Empty;
    private multilingualManager olng;
    string strUserLang = string.Empty;
    ErrLog objErr = new ErrLog();
    #endregion
    #region Page Load Method
    protected void Page_Load(object sender, EventArgs e)
    {
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "AgentVendorSearch.aspx", strUserLang);
        agnType = Request.QueryString["agnType"];
        if (!IsPostBack)
        {
            InitializeControl();
            fillDropDown();
        }
    }
    #endregion
    #region InitializeControl
    private void InitializeControl()
    {
        lblTitle.Text = (olng.GetItemDesc("lblTitle"));
        lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel"));
        lblChannelSubClass.Text = (olng.GetItemDesc("lblChannelSubClass"));
        lblAgentType.Text = (olng.GetItemDesc("lblAgentType"));
        lblAgentName.Text = (olng.GetItemDesc("lblAgentName"));
       // btnSearch.Text = (String)(olng.GetItemDesc("btnSearch")).ToUpper();
        btnSearch.Text = "<i class='glyphicon glyphicon-search' style='color:White'></i> Search";
        gv_AgentVendorMap.Columns[0].HeaderText = (olng.GetItemDesc("gvHTAgnBrCode"));
        gv_AgentVendorMap.Columns[1].HeaderText = (olng.GetItemDesc("gvHTAgnCode"));
        gv_AgentVendorMap.Columns[2].HeaderText = (olng.GetItemDesc("gvHTAgnName"));
        gv_AgentVendorMap.Columns[3].HeaderText = (olng.GetItemDesc("gvHTChannel"));
        gv_AgentVendorMap.Columns[4].HeaderText = (olng.GetItemDesc("gvHTSubChn"));
    }
    #endregion
    #region Fill DropDown
    protected void fillDropDown()
    {
        try
        {
            objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
            ddlSalesChannel.DataBind();
            ddlSalesChannel.Items.Insert(0, new ListItem("-- Select --", ""));
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
    protected void bindDDLAgent()
    {
        try
        {
            if (agnType == "Agent")
            {
                ddlAgentType.Items.Clear();
                divPage.Visible = true;
                //objCommonU.GetAgentTypeforSearch(ddlAgentType, ddlSalesChannel.SelectedValue.ToString(), agnType, ddlChannelSubClass.SelectedValue.ToString(),Session["UserID"].ToString(),"");
                objCommonU.GetAgentTypeForSlsChnnl(ddlAgentType, ddlSalesChannel.SelectedValue.ToString(), agnType, ddlChannelSubClass.SelectedValue.ToString());
                ddlAgentType.DataBind();
                
                ddlAgentType.Items.Insert(0, new ListItem("-- Select --", ""));
            }
            else
                if (agnType == "Vendor")
                {
                    ddlAgentType.Items.Clear();
                    ddlAgentType.Items.Insert(0, new ListItem("-- Select --", ""));
                    divPage.Visible = true;
                    ddlAgentType.Items.Insert(1, new ListItem("Vendor", "RF"));

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
    #region Selected Index Changed Method
    protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlAgentType.Items.Clear();
        try
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_ddlchnnlsubclsforunitmaint", htParam);
            htParam.Clear();
            if (dsResult.Tables[0].Rows.Count > 0)
            {

                ddlChannelSubClass.DataSource = dsResult;
                ddlChannelSubClass.DataTextField = "ChnlDesc";
                ddlChannelSubClass.DataValueField = "ChnCls";
                ddlChannelSubClass.DataBind();
                ddlChannelSubClass.Items.Insert(0, new ListItem("-- Select --", ""));
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
    protected void ddlChannelSubClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDDLAgent();
       // lblMsg.Visible = false;
    }
    #endregion
    #region Button Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@BizSrc",ddlSalesChannel.SelectedValue.ToString());
        htParam.Add("@ChnCls",ddlChannelSubClass.SelectedValue.ToString());
        htParam.Add("@AgentType",ddlAgentType.SelectedValue.ToString());
        htParam.Add("@AgentName",txtAgentName.Text.ToString());
        dsResult =  objDAL.GetDataSetForPrcCLP("Prc_GetAgnVendDtls", htParam);

        if (dsResult.Tables[0].Rows.Count > 0)
        {
            divPage.Visible = true;
            gv_AgentVendorMap.DataSource = dsResult.Tables[0];
            gv_AgentVendorMap.DataBind();
            gv_AgentVendorMap.Visible = true;
            ViewState["AgentSearch"] = dsResult;
        }
        else
        {
            //lblMsg.Text = "No record found";
            //lblMsg.Visible = true;
           // gv_AgentVendorMap.Visible = false;
            gv_AgentVendorMap.DataSource = null;
            gv_AgentVendorMap.DataBind();
        }

       

    }
    protected void lblAgentCode_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbAGentCode = (LinkButton)row.FindControl("lblAgentCode");
        Label lblAgentName = (Label)row.FindControl("lblAgentName");
        Label lblChannel = (Label)row.FindControl("lblChannelDesc");
        Label lblChnCls = (Label)row.FindControl("lblChnCLsDesc");

        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doSelect('" + lbAGentCode.Text + "','" + lblAgentName.Text + "','" + lblChannel.Text + "','" + lblChnCls.Text + "','" + agnType + "')", true);
    }
    #endregion
    #region Page Index Changing
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
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    gv_AgentVendorMap.DataSource = dv;
                    gv_AgentVendorMap.DataBind();
                    ShowPageInformation();

                    if (gv_AgentVendorMap.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        txtPage.Text = "1";
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
    }
    #endregion
    #region Sorting
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv_AgentVendorMap.PageIndex;
            gv_AgentVendorMap.PageIndex = pageIndex + 1;
            bindDDLAgent();
            BindDataGrid();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv_AgentVendorMap.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv_AgentVendorMap.PageCount;
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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gv_AgentVendorMap.PageIndex;
            gv_AgentVendorMap.PageIndex = pageIndex - 1;
            bindDDLAgent();
            BindDataGrid();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv_AgentVendorMap.PageCount))
            {
                btnprevious.Enabled = false;
            }
            int page = gv_AgentVendorMap.PageCount;
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

    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = gv_AgentVendorMap.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region METHOD 'BindDataGrid'
    private void BindDataGrid()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
        htParam.Add("@ChnCls", ddlChannelSubClass.SelectedValue.ToString());
        htParam.Add("@AgentType", ddlAgentType.SelectedValue.ToString());
        htParam.Add("@AgentName", txtAgentName.Text.ToString());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetAgnVendDtls", htParam);

        if (dsResult.Tables[0].Rows.Count > 0)
        {
            divPage.Visible = true;
            gv_AgentVendorMap.DataSource = dsResult.Tables[0];
            gv_AgentVendorMap.DataBind();
            gv_AgentVendorMap.Visible = true;
            ViewState["AgentSearch"] = dsResult;
        }
        else
        {
            //lblMsg.Text = "No record found";
            //lblMsg.Visible = true;
            // gv_AgentVendorMap.Visible = false;
            gv_AgentVendorMap.DataSource = null;
            gv_AgentVendorMap.DataBind();
        }

        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                // divsearch1.Attributes.Add("display","block");
                //divsearch1.Attributes.Add("style", "display: block");
                gv_AgentVendorMap.DataSource = dsResult.Tables[0];

                gv_AgentVendorMap.DataBind();
                ShowPageInformation();
                if (gv_AgentVendorMap.PageCount > 1)
                {
                    btnnext.Enabled = true;
                    btnprevious.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                    btnprevious.Enabled = false;
                    txtPage.Text = "1";
                }
                //trDetails.Visible = true;
                //trDgDetails.Visible = true;
                lblMessage.Visible = false;
                lblMessage.Text = "";
               

            }
            else
            {
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                //lblPageInfo.Text = "";
                //trDetails.Visible = false;
                //trDgDetails.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "0 RECORD FOUND.";
                gv_AgentVendorMap.AllowPaging = false;
                gv_AgentVendorMap.AllowSorting = false;

                ShowNoResultFound(dsResult.Tables[0], gv_AgentVendorMap);

            }
        }

        else
        {
            ShowNoResultFound(dsResult.Tables[0], gv_AgentVendorMap);
            //dgDetails.DataSource = null;
            //dgDetails.DataBind();
            ////lblPageInfo.Text = "";
            ////trDetails.Visible = false;
            ////trDgDetails.Visible = false;
            //lblMessage.Visible = true;
            //lblMessage.Text = "0 RECORD FOUND.";

        }
        dsResult = null;
        htParam.Clear();
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
        gv.Rows[0].Cells[0].Text = "No Record Found";
        btnnext.Enabled = false;
        btnprevious.Enabled = false;
        txtPage.Enabled = false;
        source.Rows.Clear();
    }
}
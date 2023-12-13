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

public partial class Application_INSC_ChannelMgmt_AgtVenMapping : BaseClass
{
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    string strAgnCode = string.Empty;
    private multilingualManager olng;
    string strUserLang = string.Empty;
    string strPrimary = string.Empty;
    string strCombiCode = string.Empty;
    ErrLog objErr = new ErrLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            strAgnCode = Request.QueryString["AgentCode"].ToString();
            GetAgentDtls(strAgnCode);
        }
        BindGridView(strAgnCode );
        btnVendorSrch.Attributes.Add("onClick", "funpopup('Vendor');return false;");
        //btnAddNew.Attributes.Add("onClick", "funpopup('Vendor');return false;");
    }
    #region Bind Grid
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
                trTitle.Visible = true;
            }
            else
            {
                gv_AgentVendorMap.DataSource = null;
                gv_AgentVendorMap.DataBind();
                trTitle.Visible = false;
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
    #region Button Click
    protected void lbViewIRC_Active_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbViewIRC");
        Label lblVendorCode = (Label)row.FindControl("lblVendorBasID");
        //BindIRCGridView(lblVendorCode.Text);


    }
    protected void lbAddNew_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbData = (LinkButton)row.FindControl("lbAddNew");
        Label lblAgentCode = (Label)row.FindControl("lblAgentCode");
        Label lblVendorCode = (Label)row.FindControl("lblVendorCode");
        Label lblVendorName = (Label)row.FindControl("lblVendorName");

        //Response.Redirect("~/Application/ISys/ChannelMgmt/MultiBranchAssignment.aspx?agncd=" + lblAgentCode.Text + "&VendCode=" + lblVendorCode.Text + "&AgnName=" + lblAgentNameDesc.Text + "&AgnChn=" + lblChannelVal.Text + "&AgnChnCls=" + lblSubclassVal.Text + "&VendName=" + lblVendorName.Text + "");
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

        trVendDtls.Visible = true;
        btnAddNew.Visible = false;
        btnCreateMap.Visible = true;
        //Response.Redirect("~/Application/ISys/ChannelMgmt/MultiBranchAssignment.aspx");
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
                lblAgentIDDesc.Text = dsResult.Tables[0].Rows[0]["MemCode"].ToString();
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
    protected void btnCreateMap_Click(object sender, EventArgs e)
    {

        try
        {
            if (hdnVendBizSrc.Value != "" && hdnVendChnCls.Value != "" && txtVendoreCode.Text != "")
            {


                if (chkPrimary.Checked == true)
                {
                    strPrimary = "1";
                }
                else if (chkPrimary.Checked == false)
                {
                    strPrimary = "0";
                }

                dsResult = null;
                htParam.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@AgentCode", lblAgentIDDesc.Text.ToString().Trim());
                htParam.Add("@AgnBizSrc", lblChannelVal.Text.ToString().Trim());
                htParam.Add("@AgnChnCls", lblSubclassVal.Text.ToString().Trim());
                htParam.Add("@VendorCode", txtVendoreCode.Text.ToString().Trim());
                htParam.Add("@VenBizSrc", hdnVendBizSrc.Value.ToString().Trim());
                htParam.Add("@VenChnCls", hdnVendChnCls.Value.ToString().Trim());
                htParam.Add("@PrimaryFlag", strPrimary);
                htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                dsResult = objDAL.GetDataSetForPrcCLP("Prc_CreateAgnVenMap", htParam);
                htParam.Clear();

                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    strCombiCode = dsResult.Tables[0].Rows[0]["CombiCode"].ToString();
                }
                //mdlpopup.Show();
                lbl_popup.Text = "Agent Vendor Relationship has been set Successfully" + " </br></br>Relationship No.: " + strCombiCode;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                txtVendoreCode.Text = "";
                trVendDtls.Visible = false;
                btnAddNew.Visible = true;
                btnCreateMap.Visible = false;
                BindGridView(lblAgentIDDesc.Text.ToString().Trim());
            }
            else
            {
               // mdlpopup.Show();
                lbl_popup.Text = "Please Enter Vendor Details!";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                //mdlpopup.Hide();
                //ScriptManager.RegisterStartupScript(this.Page, GetType(), "MyScript", "alert('Please Enter Vendor Details!');", true);

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
    #region PAGEINFORMATION
    private void ShowPageInformation()
    {
        int intPageIndex = gv_AgentVendorMap.PageIndex + 1;
        //int pgInfo = Gv_ChannelDetails.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        //lblPageindex.Text = "Page " + pgInfo.ToString() + " of " + Gv_ChannelDetails.PageCount;
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
    #region Button Cancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
    }
    #endregion
}
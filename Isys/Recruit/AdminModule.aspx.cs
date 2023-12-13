using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using Telerik.Web.UI;


public partial class Application_ISys_Recruit_AdminModule : BaseClass
{
    #region Global declaration
    string strInsId = string.Empty;
    string strEdit = string.Empty;

    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private const string Conn_Direct = "DefaultConn";
    private multilingualManager olng;
    DataView dvResult = new DataView();
    Hashtable htParam = new Hashtable();
    string strUnitCode = string.Empty;
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsmulti = new DataSet();
    DataSet ds_UnitType = new DataSet();
    Hashtable htmulti = new Hashtable();
    string user = string.Empty;
    string usertype = string.Empty;
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    ErrLog objErr = new ErrLog();
    DataSet dsCfruser = new DataSet(); //added by pranjali on 02-04-2014
    string Code;//added by pranjali on 15042014
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    string Flag1;
    private string strUserLang;
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    //EncodeDecode ObjDec = new EncodeDecode();
    Hashtable httable = new Hashtable();

    private bool isDrillDown = false;
    string Userid;

    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "AdminModule.aspx", Session["UserLangNum"].ToString());
           
            if (!IsPostBack)
            {
                pnl.Visible = false;
                GetBizsrc();
                GetBranchName();

            }
           // pnl.Visible = true;
            if (Session["UserId"] != null)
            {
                Userid = HttpContext.Current.Session["UserId"].ToString();
            }
             
        }

        catch (Exception ex)
        {

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;

            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlchcnls.SelectedValue == "Select")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select channel')", true);
            return;
        }

        else if (ddlInsuranceType.SelectedValue == "Select")
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select sub channel')", true);
            return;
        }
       
      
       

        Binddatagrid();
    }
    protected  void   Binddatagrid()
    {
       
        try
        {

            DataSet dsmail = new DataSet();
            DataTable dtmail = new DataTable();
            if (ddlBranchName.SelectedValue == "Select")
            {
                htParam.Add("@Branch", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@Branch", ddlBranchName.SelectedValue);
            }
            htParam.Add("@Channel", ddlchcnls.SelectedValue);
            htParam.Add("@SubChannel", ddlInsuranceType.SelectedValue);
            dsmail = dataAccess.GetDataSetForPrc("prc_GetChannelRecord", htParam);
            if (dsmail.Tables.Count > 0)
            {
                Divnote.Visible = true;
                dgAdmin.DataSource = dsmail;
                dgAdmin.DataBind();
                ShowPageInformation();
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

    protected DataTable  Binddatagrid1()
    {
        DataSet dsmail = new DataSet();
        DataTable dtmail = new DataTable();
        try
        {


            if (ddlBranchName.SelectedValue == "Select")
            {
                htParam.Add("@Branch", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@Branch", ddlBranchName.SelectedValue);
            }
            htParam.Add("@Channel", ddlchcnls.SelectedValue);
            htParam.Add("@SubChannel", ddlInsuranceType.SelectedValue);
            dsmail = dataAccess.GetDataSetForPrc("prc_GetChannelRecord", htParam);
            if (dsmail.Tables.Count > 0)
            {
                dtmail = dsmail.Tables[0];
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
        return dtmail;
    }



    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
           // Binddatagrid();
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


    #region ddlChncls_SelectedIndexChanged

    protected void ddlChncls_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            dsResult.Clear();
            htparam.Add("@Bizsrc", ddlchcnls.SelectedValue);
            htparam.Add("@flag", 5);
            dsResult = dataAccess.GetDataSetForPrc ("prc_ChannelType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlInsuranceType.DataSource = dsResult;////ddlUnitType
                ddlInsuranceType.DataTextField = "ChnClsDesc01";
                ddlInsuranceType.DataValueField = "BizSrc";
                ddlInsuranceType.DataBind();
                ddlInsuranceType.Items.Insert(0, "Select");

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

    #region ddlBizsrc_SelectedIndexChanged

    protected void ddlBizsrc_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            htparam.Add("@Chncls", ddlInsuranceType.SelectedValue);
            htparam.Add("@flag", 3);
            dsResult = dataAccess.GetDataSetForPrc("prc_ChannelType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlBranchName.DataSource = dsResult;
                ddlBranchName.DataTextField = "UnitLegalName";
                ddlBranchName.DataValueField = "UNitcode";
                ddlBranchName.DataBind();
                ddlBranchName.Items.Insert(0, "Select");
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

    private void GetBizsrc()
    {
        try
        {

            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            htparam.Add("@flag", 1);
            dsResult = dataAccess.GetDataSetForPrc("prc_ChannelType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlchcnls.DataSource = dsResult;
                ddlchcnls.DataTextField = "ChannelDesc01";
                ddlchcnls.DataValueField = "BizSrc";
                ddlchcnls.DataBind();
                ddlchcnls.Items.Insert(0, "Select");

            }
            htparam.Clear();
            htparam.Add("@flag", 2);
            dsResult = dataAccess.GetDataSetForPrc("prc_ChannelType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlInsuranceType.DataSource = dsResult;
                ddlInsuranceType.DataTextField = "ChnClsDesc01";
                ddlInsuranceType.DataValueField = "ChnClsDesc01";
                ddlInsuranceType.DataBind();
                ddlInsuranceType.Items.Insert(0, "Select");


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

    private void GetBranchName()
    {
        try
        {

            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            // htparam.Add("@flag" );
            dsResult = dataAccess.GetDataSetForPrc ("prc_ChannelType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlBranchName.DataSource = dsResult;////ddlUnitType
                ddlBranchName.DataTextField = "UnitLegalName";
                ddlBranchName.DataValueField = "UnitLegalName";
                ddlBranchName.DataBind();
                ddlBranchName.Items.Insert(0, "Select");
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

    #region dgAdmin_RowCommand
    protected void dgAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        try
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            // Label lblCndno = (Label)row.FindControl("lblCndNo");
            Label lblUnitCode = (Label)row.FindControl("lblUnitCode");
            if (e.CommandName == "EmailClick")
            {
                strEdit = "E";
                Session["StrED"] = strEdit;
                
                string Editclick = e.CommandArgument.ToString().Trim();
                string Branchcode = e.CommandArgument.ToString().Trim();
                DataSet dsResult = new DataSet();
                Hashtable htparam = new Hashtable();
                
                htparam.Clear();
                htparam.Add("@unitcode", lblUnitCode.Text.ToString());
                htparam.Add("@flag", "");

                dsResult = dataAccess.GetDataSetForPrc("prc_ChannelType", htparam);

                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    DDlBranch.Text = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();
                    Ddlchannel.Text = dsResult.Tables[0].Rows[0]["ChannelDesc01"].ToString().Trim();
                    Ddlsubchannel.Text = dsResult.Tables[0].Rows[0]["ChnClsDesc01"].ToString().Trim();
                    txtEmail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                    hdnId.Value = dsResult.Tables[0].Rows[0]["UNitcode"].ToString().Trim();


                }
                /////ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "funpopup();", true);
                //pnl.Visible = true;
                //mdlpopup.Show();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popupPnl();", true);
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


    #region dgView PageIndexChanging
    protected void dgAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {


            //For Pagination of Search Grid
            DataTable dt = Binddatagrid1();
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
    #region dgView Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgAdmin.PageIndex + 1;
       // lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgView.PageCount;
    }
    #endregion

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Hashtable htparam = new Hashtable();

        htparam.Clear();
        htparam.Add("@unitcode", hdnId.Value);

        htparam.Add("@Email", txtEmail.Text.ToString().Trim()); 

        htparam.Add("@flag", "6");
        dsResult = dataAccess.GetDataSetForPrc("prc_ChannelType", htparam);
     // lblMessage.Visible = true;
      lbl3.Text = "Email id changed successfully";
      
        Binddatagrid();
       // mdlpopupSub.Show();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
       
   

    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {


            int pageIndex = dgAdmin.PageIndex;
            dgAdmin.PageIndex = pageIndex - 1;
            
            Binddatagrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
            catchdetails(ex);
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = dgAdmin.PageIndex;
            dgAdmin.PageIndex = pageIndex + 1;
           
            Binddatagrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = dgAdmin.PageCount;
            if (txtPage.Text == Convert.ToString(dgAdmin.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = dgAdmin.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgAdmin.PageCount;
            }
        }
        catch (Exception ex)
        {
            catchdetails(ex);
        }
    }
    protected void catchdetails(Exception ex)
    {
        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        string sRet = oInfo.Name;
        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        String LogClassName = method.ReflectedType.Name;
        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    }
}
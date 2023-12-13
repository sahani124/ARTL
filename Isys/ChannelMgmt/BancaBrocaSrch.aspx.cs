using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;

public partial class Application_Isys_ChannelMgmt_BancaBrocaSrch : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    private DataAccessClass dataAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string sUserId;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            sUserId = HttpContext.Current.Session["UserID"].ToString();

            if (!IsPostBack)
            {
                 oCommonU.GetSalesChannel(ddlChn, "", 2, Session["UserID"].ToString(), "1");
                ddlChn.Items.Insert(0, new ListItem("All", "All"));
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../../Default3.aspx");
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("BancaBrocaSrch.aspx");
        }

        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
    protected void ddlChn_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string UserId = Session["UserID"].ToString();
            oCommonU.GetUserChnclsChannel(ddlChnCls, ddlChn.SelectedValue, 0, UserId.ToString());
            ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
            // ddlMemtype.Items.Insert(0, new ListItem("All", "All"));
            // ddlMemtype.SelectedIndex = 0;
            ddlMemtype.Items.Clear();

            ddlChnCls.Focus();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }
    #endregion

    #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            Get_UsersAgenttype();

            ddlMemtype.Items.Insert(0, new ListItem("All", "All"));
            ddlMemtype.Focus();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion
    protected void btnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
             BindGrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex + 1;
            BindGrid();
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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-CHMS", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

   
    protected void BindGrid()
    {
        try
        {
            ds.Clear();
            DataSet ds2 = new DataSet();
            htParam.Clear();
            htParam.Add("@MemCode", txtMemCode.Text.ToString());
            htParam.Add("@MemName", txtMemName.Text.ToString().Trim());
            htParam.Add("@Chn", ddlChn.SelectedValue.ToString().Trim());

            htParam.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
            htParam.Add("@Memtype", ddlMemtype.SelectedValue.ToString().Trim());
            ds = objDal.GetDataSetForPrc("Prc_BancaBrocaMemberSearch", htParam);
         

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgDetails.DataSource = ds.Tables[0]; ;
                dgDetails.DataBind();

                trDetails.Visible = true;
                trDgDetails.Visible = true;

                txtPage.Text = "1";
                if (dgDetails.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
                lblMessage.Visible = true;

            }
            else
            {
               
                txtPage.Text = "1";
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
            }            
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #region Get_UsersAgenttype()
    public void Get_UsersAgenttype()
    {
        try
        {
            string UserId = Session["UserID"].ToString();

            if (ddlChn.SelectedValue == "")
            {
                oCommonU.GetAgentType(ddlMemtype, "All", "");
            }
            else
            {

                {
                    GetMemtypeForMvmt("1", "CR");

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
    protected DataSet GetMemtypeForMvmt(string flag, string rule)
    {
        Hashtable htMvmt = new Hashtable();
        DataSet dsMvmt = new DataSet();
        try
        {

            htMvmt.Clear();
            dsMvmt.Clear();
            ddlMemtype.Items.Clear();
            htMvmt.Add("@UserID", Session["UserID"].ToString().Trim());
            htMvmt.Add("@Bizsrc", ddlChn.SelectedValue.ToString().Trim());
            htMvmt.Add("@Chncls", ddlChnCls.SelectedValue.ToString().Trim());
            htMvmt.Add("@MvmtRule", rule.Trim());
            htMvmt.Add("@MvmtMode", "0");
            htMvmt.Add("@Flag", flag);
            dsMvmt = dataAccess.GetDataSetForPrcCLP("Prc_GetMemTypeForMvmt", htMvmt);
            if (dsMvmt.Tables.Count != 0)
            {
                if (dsMvmt.Tables[0].Rows.Count != 0)
                {
                    ddlMemtype.DataSource = dsMvmt.Tables[0];
                    ddlMemtype.DataValueField = dsMvmt.Tables[0].Columns["MemType"].ToString().Trim();
                    ddlMemtype.DataTextField = dsMvmt.Tables[0].Columns["MemTypeDesc"].ToString().Trim();
                    ddlMemtype.DataBind();
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
            objErr.LogErr("ISYS-SFTM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return dsMvmt;
    }


    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {              

                string memcode = dgDetails.DataKeys[e.Row.RowIndex].Value.ToString();
                DataSet dt = new DataSet();
            

            }

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ReqClick")
        {
            //Response.Redirect("CHMSFileUpload.aspx");//added by pranjali on 15042014
            Response.Redirect("CHMSDocUpload.aspx?&Memcode=" + e.CommandArgument.ToString().Trim() + "&Type=N&mdlpopup=");//added by pranjali on 15042014
           // Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014

        }

    }

    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

  
}
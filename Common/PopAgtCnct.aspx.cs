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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_INSC_ChannelMgmt_PopAgtCnct : BaseClass
{


    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccessClass = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            if (!IsPostBack)
            {
                int s1 = Convert.ToInt32(Request.QueryString["Code"].ToString());
                htParam.Add("@StateId", s1);
                dsResult = dataAccessClass.GetDataSetForPrc_inscdirect("Prc_GetStateDetails", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {

                        GrdStateDtls.DataSource = dsResult.Tables[0];
                        GrdStateDtls.DataBind();
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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@StateId", System.DBNull.Value);/*Convert.ToInt32(Request.QueryString["Code"].ToString()));*/
            htParam.Add("@District", txtDistrict.Text.Trim());
            htParam.Add("@City", txtCity.Text.Trim());
            htParam.Add("@Pincode", txtPincode.Text.Trim());
            htParam.Add("@Area", txtArea.Text.Trim());
            dsResult = dataAccessClass.GetDataSetForPrc_inscdirect("Prc_GetStateDetails", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    GrdStateDtls.DataSource = dsResult.Tables[0];
                    GrdStateDtls.DataBind();
                    ViewState["grid"] = dsResult.Tables[0];
                    if (GrdStateDtls.PageCount > Convert.ToInt32(txtPage.Text))
                    {
                        btnnext.Enabled = true;
                    }
                    else if (GrdStateDtls.PageCount <= Convert.ToInt32(txtPage.Text))
                    {
                        txtPage.Text = "1";
                        btnnext.Enabled = false;
                        btnprevious.Enabled = false;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                    }
                    tblDtl.Visible = true;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    lblPageInfo.Visible = false;
                    
                }
                else
                {
                    GrdStateDtls.DataSource = null;
                    GrdStateDtls.DataBind();
                    lblPageInfo.Text = "";
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    div2.Attributes.Add("style", "display:none");
                    trtitle.Visible = false;
                }
            }
            else
            {
                GrdStateDtls.DataSource = null;
                GrdStateDtls.DataBind();
                lblPageInfo.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                div2.Attributes.Add("style", "display:none");
                trtitle.Visible = false;
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
        dsResult = null;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
    }

    protected void GrdStateDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
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

    protected DataTable GetDataTable()
    {
        try
        {
            htParam.Clear();
            htParam.Add("@StateId", Convert.ToInt32(Request.QueryString["Code"].ToString()));
            htParam.Add("@District", txtDistrict.Text.Trim());
            htParam.Add("@City", txtCity.Text.Trim());
            htParam.Add("@Pincode", txtPincode.Text.Trim());
            htParam.Add("@Area", txtArea.Text.Trim());
            dsResult = dataAccessClass.GetDataSetForPrc_inscdirect("Prc_GetStateDetails", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    //div2.Attributes.Add("style", "display:block");
                    GrdStateDtls.DataSource = dsResult.Tables[0];
                    GrdStateDtls.DataBind();
                    ViewState["grid"] = dsResult.Tables[0];
                    if (GrdStateDtls.PageCount > Convert.ToInt32(txtPage.Text))
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                    }
                    tblDtl.Visible = true;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                }
                else
                {
                    GrdStateDtls.DataSource = null;
                    GrdStateDtls.DataBind();
                    lblPageInfo.Text = "";
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    div2.Attributes.Add("style", "display:none");
                    trtitle.Visible = false;
                }
            }
            else
            {
                GrdStateDtls.DataSource = null;
                GrdStateDtls.DataBind();
                lblPageInfo.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                div2.Attributes.Add("style", "display:none");
                trtitle.Visible = false;
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
    }
    private void ShowPageInformation()
    {
        int intPageIndex = GrdStateDtls.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GrdStateDtls.PageCount;
    }
    protected void GrdStateDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkPincode = new LinkButton();
            Label lblDistrict = new Label();
            Label lblCity = new Label();
            Label lblArea = new Label();
            lnkPincode = (LinkButton)e.Row.FindControl("lnkPincode");
            lblDistrict = (Label)e.Row.FindControl("lblDistrict");
            lblCity = (Label)e.Row.FindControl("lblCity");
            lblArea = (Label)e.Row.FindControl("lblArea");
            lnkPincode.Attributes.Add("onclick", "doSelect('" + lnkPincode.Text + "','" + lblDistrict.Text + "','" + lblCity.Text + "','" + lblArea.Text + "');return false;");




        }
    }
    //meena 29_1_18 start
    protected void GrdStateDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "pincode")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            LinkButton lnkPincode = new LinkButton();
            Label lblDistrict = new Label();
            Label lblCity = new Label();
            Label lblArea = new Label();
            lnkPincode = (LinkButton)row.FindControl("lnkPincode");
            lblDistrict = (Label)row.FindControl("lblDistrict");
            lblCity = (Label)row.FindControl("lblCity");
            lblArea = (Label)row.FindControl("lblArea");


            DataTable dt = new DataTable();
            dt.Columns.Add("District");
            dt.Columns.Add("City");
            dt.Columns.Add("Area");
            dt.Columns.Add("Pincode");


            DataRow dr = dt.NewRow();
            dr["District"] = lblDistrict.Text;
            dr["City"] = lblCity.Text;
            dr["Area"] = lblArea.Text;
            dr["Pincode"] = lnkPincode.Text;
            dt.Rows.Add(dr);

            Session["Address"] = dt;

            if (Request.QueryString["btnid"] == "btnstatesearch")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
            }
            else if (Request.QueryString["btnid"] == "btnstate1search")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk1();", true);
            }
            else if (Request.QueryString["btnid"] == "btnStateSrch")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk();", true);
            }
            else if (Request.QueryString["btnid"] == "btnStateSrch0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk1();", true);
            }
        }
    }
    //meena 29_1_18 end
    protected void GrdStateDtls_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GrdStateDtls.PageIndex;
            GrdStateDtls.PageIndex = pageIndex - 1;
            //BindDataGrid();
            GetDataTable();
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = GrdStateDtls.PageIndex;
            GrdStateDtls.PageIndex = pageIndex + 1;
            GetDataTable();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = GrdStateDtls.PageCount;
            if (txtPage.Text == Convert.ToString(GrdStateDtls.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = GrdStateDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GrdStateDtls.PageCount;
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
}
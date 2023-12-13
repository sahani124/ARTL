using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class Application_ISys_ChannelMgmt_ViewCompensation : BaseClass
{

    #region DECLARE VARIABLES
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    private multilingualManager olng;
    private string strUserLang;
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass objDAL = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    SqlDataReader dtRead;
    Hashtable httable = new Hashtable();
    ErrLog objErr = new ErrLog();
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCompType(ddlCompType, "prc_GetCompType");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
            ddlChnCls.Items.Insert(0, new ListItem("All", ""));
            ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        }
    }
    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbChnlTyp.SelectedValue == "0")
        {
            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "0");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));

        }
        else
        {
            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "1");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
        }
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, Session["UserID"].ToString());
        ddlChnCls.Items.Insert(0, new ListItem("All", ""));
        ddlAgntType.Items.Clear();
        ddlAgntType.DataSource = null;
        ddlAgntType.DataBind();
        ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        rdbChnlTyp.Focus();
    }
    protected void ddlSlsChnnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        string UserId = Session["UserID"].ToString();
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, UserId.ToString());
        ddlChnCls.Items.Insert(0, new ListItem("All", ""));
        ddlAgntType.Items.Clear();
        ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        ddlSlsChnnl.Focus();
    }
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAgtType(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlChnCls.SelectedValue);
        ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        ddlChnCls.Focus();
    }
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #region GetAgtType
    public void GetAgtType(DropDownList ddl, string txtchn, string txtsubchn)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@chnl", txtchn.Trim());
            htparam.Add("@subchnl", txtsubchn.Trim());
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlAgttypeformvmt", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
            dtRead = null;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ViewCompensation", "GetAgtType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region GetCompType
    public void GetCompType(DropDownList ddl, string proc)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable htParam = new Hashtable();
            dtRead = objDAL.Common_exec_reader_prc_SAIM(proc.ToString().Trim(), htParam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "CompDesc01";
                ddl.DataValueField = "CompType";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("--Select--", ""));
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "ViewCompensation", "GetCompType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void lnkVwDtls_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lbMemCode = (Label)grd.FindControl("lblEmpCode");
        Label lblSapCode = (Label)grd.FindControl("lblSapCode");
        Label lblAgtBrkCd = (Label)grd.FindControl("lblAgtBrkCd");
        Label lblBizSrc = (Label)grd.FindControl("lblBizSrc");
        Label lblChnCls = (Label)grd.FindControl("lblChnCls");
        Label lblMemTyp = (Label)grd.FindControl("lblMemTyp");
        Label lblCompType = (Label)grd.FindControl("lblCompType");
        Label lblProdPrm = (Label)grd.FindControl("lblProdPrm");
        Label lblCommPts = (Label)grd.FindControl("lblCommPts");
        Label lblComm = (Label)grd.FindControl("lblComm");

        mdlVwComp.Show();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CompType", lblCompType.Text.ToString().Trim());
        ht.Add("@MemCode", lbMemCode.Text.ToString().Trim());
        ht.Add("@PrdPrem", lblProdPrm.Text.ToString().Trim());
        ht.Add("@PrdCommPts", lblCommPts.Text.ToString().Trim());
        ht.Add("@PrdComm", lblComm.Text.ToString().Trim());
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_GetMemClub", ht);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdClub.DataSource = ds;
                    grdClub.DataBind();
                }
                else
                {
                    ds = null;
                    grdClub.DataSource = ds;
                    grdClub.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);
                }
            }
            else
            {
                ds = null;
                grdClub.DataSource = ds;
                grdClub.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);

            }
        }
        else
        {
            ds = null;
            grdClub.DataSource = ds;
            grdClub.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchComp();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //txtCycDtFrm.Text = "";
        //txtCycDtTo.Text = "";
        //txtMemCode.Text = "";
        //txtPanNo.Text = "";
        //txtSap.Text = "";
        //txtAgtBrkCd.Text = "";
        //ddlSlsChnnl.Items.Clear();
        //ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
        //ddlChnCls.Items.Clear();
        //ddlChnCls.Items.Insert(0, new ListItem("All", ""));
        //ddlAgntType.Items.Clear();
        //ddlAgntType.Items.Insert(0, new ListItem("All", ""));

        Response.Redirect("FireQuotation.aspx");
    }
    protected void grdClub_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCompType = (Label)e.Row.FindControl("lblCompType");

            if (lblCompType.Text != "FCP")
            {
                grdClub.Columns[2].Visible = false;
            }
            else
            {
                grdClub.Columns[2].Visible = true;
            }
        }
    }

    public void SearchComp()
    {
        Hashtable htComp = new Hashtable();
        DataSet dsComp = new DataSet();
        if (txtCycDtFrm.Text != "")
        {
            htComp.Add("@CycDt1", txtCycDtFrm.Text.Trim());
        }
        else
        {
            htComp.Add("@CycDt1", "");
        }
        if (txtCycDtTo.Text != "")
        {
            htComp.Add("@CycDt2", txtCycDtTo.Text.ToString().Trim());
        }
        else
        {
            htComp.Add("@CycDt2", "");
        }
        htComp.Add("@MemCode", txtMemCode.Text.ToString().Trim());
        htComp.Add("@PanNo", txtPanNo.Text.ToString().Trim());
        htComp.Add("@EmpCode", txtSap.Text.ToString().Trim());
        htComp.Add("@AgtBrkCode", txtAgtBrkCd.Text.ToString().Trim());
        htComp.Add("@CompType", ddlCompType.SelectedValue.ToString().Trim());
        /////htComp.Add("@ChnlType", ddlSlsChnnl.SelectedValue.ToString().Trim());
        htComp.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
        htComp.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
        htComp.Add("@MemType", ddlAgntType.SelectedValue.ToString().Trim());

        dsComp = objDAL.GetDataSetForPrc_SAIM("Prc_CmpnstSrch", htComp);
        if (dsComp != null)
        {
            if (dsComp.Tables.Count > 0)
            {
                if (dsComp.Tables[0].Rows.Count > 0)
                {
                    ViewState["DsGrid"] = dsComp.Tables[0];
                    grdComp.DataSource = dsComp;
                    grdComp.DataBind();
                }
                else
                {
                    dsComp = null;
                    ViewState["DsGrid"] = null;
                    grdComp.DataSource = dsComp;
                    grdComp.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);
                }
            }
            else
            {
                dsComp = null;
                ViewState["DsGrid"] = null;
                grdComp.DataSource = dsComp;
                grdComp.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);

            }
        }
        else
        {
            dsComp = null;
            ViewState["DsGrid"] = null;
            grdComp.DataSource = dsComp;
            grdComp.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "search", "<script type='text/javascript'>alert('No Records Found')</script>", false);
        }
    }


    protected void lnkVwPayOut_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lbMemCode = (Label)grd.FindControl("lblEmpCode");
        Label lblCommPts = (Label)grd.FindControl("lblCommPts");
        Response.Redirect("ViewCmpStatement.aspx?flag=Pay&MemCode=" + lbMemCode.Text.ToString().Trim() + "&CommPts=" + lblCommPts.Text.ToString().Trim(), true);
    }
    protected void grdComp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = ViewState["DsGrid"] as DataTable;
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
    protected void grdComp_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = ViewState["DsGrid"] as DataTable;
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

    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = grdComp.PageIndex + 1;
        /////lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgPol.PageCount;
    }
    #endregion
}
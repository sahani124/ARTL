using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using INSCL.App_Code;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_ISys_ChannelMgmt_MemMvmtAppr : BaseClass
{
    #region DECLARE VARIABLES
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    private multilingualManager olng;
    private string strUserLang;
    private const string c_strBlank = "All";
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    Hashtable httable = new Hashtable();
    ErrLog objErr = new ErrLog();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
        if (!IsPostBack)
        {
            if (Request.QueryString["Role"] != null)
            {
                if (Request.QueryString["Role"].ToString() == "Agt")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=JavaScript>addCssClassByClick(2);</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=JavaScript>addCssClassByClick(1);</script>");
                }
            }


            div3.Style.Add("display", "none");
            InitializeControl();
            oCommonU.GetRptType(ddlRptTyp);
            ddlRptTyp.Items.Insert(0, new ListItem("All", ""));
            oCommonU.FillNoOfRecDropDown(ddlShwRecrds);
            oCommon.getDropDown(ddlMomentType, "mvmttype", 1, "", 1, c_strBlank);
            oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "0");
            ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));


            hdnAgentRole.Value = "E";
            lnkTab1.BackColor = System.Drawing.Color.LightYellow;
            lnkTab2.BackColor = System.Drawing.Color.Transparent;
            lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
            lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
            olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
            InitializeControl();

            if (Request.QueryString["Role"] != null)
            {
                if (Request.QueryString["Role"].ToString() == "Agt")
                {
                    hdnAgentRole.Value = "A";
                    lnkTab1.BackColor = System.Drawing.Color.Transparent;
                    lnkTab2.BackColor = System.Drawing.Color.LightYellow;
                    lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent1.png";
                    olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
                    InitializeControl();
                    hdnAgentRole.Value = "A";
                }
            }
        }
    }
    #endregion

    #region InitializeControl
    private void InitializeControl()
    {
        lblAgntCode.Text = (olng.GetItemDesc("lblAgntCode.Text"));
        lblAgntName.Text = (olng.GetItemDesc("lblAgntName.Text"));
        lblSlsChnnl.Text = (olng.GetItemDesc("lblSlsChnnl.Text"));
        lblChnCls.Text = (olng.GetItemDesc("lblChnCls.Text"));
        lblAgntType.Text = (olng.GetItemDesc("lblAgntType.Text"));
        lblImmLeaderCode.Text = (olng.GetItemDesc("lblImmLeaderCode.Text"));
        lblShwRecords.Text = (olng.GetItemDesc("lblShwRecords.Text"));
        lblSapCode.Text = (olng.GetItemDesc("lblSapCode"));
        lblchnltype.Text = (olng.GetItemDesc("lblchnltype"));
        //Added by swapnesh on 13/12/2013 to fetch lables value from database end

    }
    #endregion

    #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
    protected void ddlSlsChnnl_SelectedIndexChanged(object sender, EventArgs e)
    {

        string UserId = Session["UserID"].ToString();
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, UserId.ToString());
        ddlChnCls.Items.Insert(0, new ListItem("All", ""));
        ddlSlsChnnl.Focus();
    }
    #endregion

    #region DROPDOWNLIST ddlRptTyp_SelectedIndexChanged
    protected void ddlRptTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRptTyp.SelectedIndex == 0)
        {
            txtImmLeaderCode.Enabled = false;
            txtImmLeaderCode.Text = "";
        }
        else
        {
            txtImmLeaderCode.Enabled = true;
        }
        ddlRptTyp.Focus();
    }
    #endregion

    #region DROPDOWNLIST ddlChnCls_SelectedIndexChanged
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAgtType(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlChnCls.SelectedValue);
        ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        ddlChnCls.Focus();
    }
    #endregion

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
            dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlAgttypeformvmt", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "AgentTypeDesc01";
                ddl.DataValueField = "AgentType";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region Get_UsersAgenttype()
    public void Get_UsersAgenttype()
    {
        try
        {
            string UserId = Session["UserID"].ToString();

            if (ddlSlsChnnl.SelectedValue == "")
            {
                oCommonU.GetAgentType(ddlAgntType, "All", "");
            }
            else
            {
                oCommonU.GetAgentTypeForSlsChnnlCT(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId);
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

    #region rdbChnlTyp_SelectedIndexChanged
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
    #endregion

    #region Link lnkTab1_Click
    protected void lnkTab1_Click(object sender, ImageClickEventArgs e)
    {
        //hdnAgentRole.Value = "E";
        //Response.Redirect("MemMvmtappr.aspx");

        hdnAgentRole.Value = "E";
        lnkTab1.BackColor = System.Drawing.Color.LightYellow;
        lnkTab2.BackColor = System.Drawing.Color.Transparent;
        lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
        lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
        olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
        InitializeControl();
        rdbChnlTyp.SelectedValue = "0";
        Response.Redirect("MemMvmtappr.aspx");
    }
    #endregion

    public void BindDataGrid()
    {
        try
        {
            Hashtable htparam = new Hashtable();
            dsResult = new DataSet();
            dsResult.Clear();
            div3.Style.Add("display", "block");
            htparam.Clear();
            htparam.Add("@AgentCode", txtAgntCode.Text);
            htparam.Add("@BizSrc", ddlSlsChnnl.SelectedValue);
            htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
            htparam.Add("@AgentType", ddlAgntType.SelectedValue);
            htparam.Add("@DirectAgtCode", txtImmLeaderCode.Text);
            htparam.Add("@AgtName", txtAgntName.Text);
            htparam.Add("@SAPCode", txtSapCode.Text);
            htparam.Add("@MvmtType", ddlMomentType.SelectedValue);
            htparam.Add("@ChnType", rdbChnlTyp.SelectedValue);
            htparam.Add("@AgentRole", hdnAgentRole.Value);
            dsResult = dataAccess.GetDataSetForPrc("Prc_GetMvmtSearchDtls", htparam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    demo11.Style.Add("display", "block");
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    ViewState["grid"] = dsResult;
                    //trDetails.Visible = true;
                    
                    ShowPageInformation();
                    lblMessage.Visible = false;
                    if (dgDetails.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        txtPage.Text = "1";
                    }
                }
                else
                {
                    //dgDetails.DataSource = null;
                    //dgDetails.DataBind();
                    //trDetails.Visible = false;
                    //div3.Style.Add("display","none");
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    ShowNoResultFound(dsResult.Tables[0], dgDetails);
                    txtPage.Text = "1";
                }
            }
            else
            {
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                ////trDetails.Visible = false;
                //div3.Style.Add("display","none");
                //lblMessage.Visible = true;
                //lblMessage.Text = "0 Record Found";
                ShowNoResultFound(dsResult.Tables[0], dgDetails);
                txtPage.Text = "1";
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
        gv.Rows[0].Cells[0].Text = "No Member Movement for Approval";
        source.Rows.Clear();
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex - 1;
            //dgDetails.DataSource = (DataTable)Session["grid"];
            //dgDetails.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            //if (txtPage.Text == "1")
            //{
            //    btnprevious.Enabled = false;
            //}
            //else
            //{
            //    btnprevious.Enabled = true;
            //}
            //btnnext.Enabled = true;


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
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex + 1;
            //// dgCntst.DataSource = (DataTable)Session["grid"];
            //// dgCntst.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            //btnprevious.Enabled = true;
            //if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            //{
            //    btnnext.Enabled = false;
            //}

            //int page = dgDetails.PageCount;

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
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    #region METHOD btnSearch_Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindDataGrid();
      
    }
    #endregion


    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
       // lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region METHOD dgDetails_PageIndexChanging
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = ViewState["grid"] as DataSet;
        DataView dv = new DataView(ds.Tables[0]);
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
    #endregion

    #region METHOD dgDetails_Sorting
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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
    }
    #endregion


    #region Link lnkTab2_Click
    protected void lnkTab2_Click(object sender, ImageClickEventArgs e)
    {
        rdbChnlTyp.SelectedValue = "0";
        Response.Redirect("MemMvmtappr.aspx?Role=Agt");
    }
    #endregion

    protected void btnClear_Click(object sender, EventArgs e)
    {
       Response.Redirect("MemMvmtAppr.aspx",true);
       
    }

    #region Link Employee_Click
    protected void Employee_Click(object sender, EventArgs e)
    {
        //hdnAgentRole.Value = "E";
        //Response.Redirect("MemMvmtappr.aspx");

        hdnAgentRole.Value = "E";
        lnkTab1.BackColor = System.Drawing.Color.LightYellow;
        lnkTab2.BackColor = System.Drawing.Color.Transparent;
        lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
        lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
        olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
        InitializeControl();
        rdbChnlTyp.SelectedValue = "0";
        Response.Redirect("MemMvmtappr.aspx");
    }
    #endregion


    #region Link Agent_Click
    protected void Agent_Click(object sender, EventArgs e)
    {
        rdbChnlTyp.SelectedValue = "0";
        Response.Redirect("MemMvmtappr.aspx?Role=Agt");
    }
    #endregion


    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblmvmtcode = (Label)e.Row.FindControl("lblmvmtcode");
            if (e.Row.Cells[10].Text == "Termination")
            {
                e.Row.Cells[11].Text = "<a href=\"AGTTermination.aspx?flag=A&Type=E&ID=Trm&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
            }
            if (e.Row.Cells[10].Text == "Promotion")
            {
                e.Row.Cells[11].Text = "<a href=\"AGTPromotion.aspx?flag=A&Type=E&ID=PR&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
            }
            if (e.Row.Cells[10].Text == "Demotion")
            {
                e.Row.Cells[11].Text = "<a href=\"AGTPromotion.aspx?flag=A&Type=E&ID=PR&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
            }
            if (e.Row.Cells[10].Text == "Reinstatement")
            {
                e.Row.Cells[11].Text = "<a href=\"MemberReinstate.aspx?flag=A&Type=E&ID=RIN&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
            }
            if (e.Row.Cells[10].Text == "Transfer")
            {
                if (hdnAgentRole.Value == "E")
                {
                    e.Row.Cells[11].Text = "<a href=\"AGTTransfer.aspx?flag=A&Type=E&ID=Trf&Ctgry=Emp&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
                }
                else
                {
                    e.Row.Cells[11].Text = "<a href=\"AGTTransfer.aspx?flag=A&Type=E&ID=Trf&MvmtCd=" + lblmvmtcode.Text + "&AgnCd=" + e.Row.Cells[1].Text + "\">Proceed</a>";
                }
            }
        }
    }
}
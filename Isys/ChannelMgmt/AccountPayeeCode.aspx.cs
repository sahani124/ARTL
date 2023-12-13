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
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_INSC_ChannelMgmt_AccountPayeeCode : BaseClass
{
    #region DECLARATION
    private multilingualManager olng;
    private string strUserLang;
    EncodeDecode ObjDec = new EncodeDecode();
	private const string Conn_Direct = "DefaultConn";
	DataSet dsResult = new DataSet();
	Hashtable htParam = new Hashtable();
	SqlDataReader dtRead;
    DataAccessClass objDAL = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "AccountPayeeCode.aspx", Session["UserLangNum"].ToString());
        Session["CarrierCode"] ='2';
        if (!IsPostBack)
        {
            InitializeControl();
			trDetails.Visible = false;
			trdgDetails.Visible = false;
            
            oCommonU.GetSalesChannel(ddlSlsChannel, "", 0);
            ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
			ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            txtAgntCode.Text = Request.QueryString["Code"].ToString();
            if (Request.QueryString["Field3"].Trim() != "")
            {
                foreach (ListItem lstItem in ddlSlsChannel.Items)
                {
                    if (lstItem.Value == Request.QueryString["Field3"].Trim())
                    {
                        ddlSlsChannel.SelectedValue = Request.QueryString["Field3"].Trim();
                        ddlSlsChannel.Enabled = false;
                        
                        ddlChnCls.Items.Clear();
                        
						//changed by nitin
                        //Added by pranjali on 05-07-2013 for channel sub class dropdown start 
                        Hashtable htparam = new Hashtable();
                        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls",htparam);
                        //Added by pranjali on 05-07-2013 for channel sub class dropdown end 
                        //dtRead = objDAL.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSlsChannel.SelectedValue + "'");
                        if (dtRead.HasRows)
                        {
                            ddlChnCls.DataSource = dtRead;
                            ddlChnCls.DataTextField = "ChnlDesc";
                            ddlChnCls.DataValueField = "ChnCls";
                            ddlChnCls.DataBind();
                        }
                        dtRead = null;
                        ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
                    }
                }
            }
            if (Request.QueryString["Field4"].Trim() != "")
            {
                foreach (ListItem lstItem in ddlChnCls.Items)
                {
                    if (lstItem.Value == Request.QueryString["Field4"].Trim())
                    {
                        ddlChnCls.SelectedValue = Request.QueryString["Field4"].Trim();
                        ddlChnCls.Enabled = false;
                    }
                }
            }
			SqlDataReader dtRead2;
			SqlDataReader dtRead1;
			string strUnitRank = "";
            //Added by pranjali on 05-07-2013 for getting ChnAgnSu data start
            htParam.Clear();
            htParam.Add("@AgentType", Request.QueryString["Field5"].Trim());
            htParam.Add("@BizSrc", Request.QueryString["Field3"].Trim());
            htParam.Add("@ChnCls", Request.QueryString["Field4"].Trim());
            htParam.Add("@flag",10);
            dtRead2 = objDAL.Common_exec_reader_prc("Prc_GetData_chnAgnSu",htParam);
            //Added by pranjali on 05-07-2013 for getting ChnAgnSu end
            //dtRead2 = objDAL.exec_reader("Select UnitRank,AgentCreateRul,UntRule From chnAgnSu where AgentType='" + Request.QueryString["Field5"].Trim() + "' AND BizSrc='" + Request.QueryString["Field3"].Trim() + "' AND ChnCls='" + Request.QueryString["Field4"].Trim() + "'");
			if (dtRead2.Read())
			{
				strUnitRank = dtRead2[0].ToString();
                ViewState["AgentCreateRul"] = dtRead2[1].ToString();
                ViewState["UntRule"] = dtRead2[2].ToString();
			}
			dtRead2.Close();
            //Added by pranjali on 05-07-2013 for getting top 1 unit rank and agent type start 
            htParam.Clear();
            htParam.Add("@UnitRank", strUnitRank);
            htParam.Add("@BizSrc", Request.QueryString["Field3"].Trim());
            htParam.Add("@flag", 1);
            dtRead1 = objDAL.Common_exec_reader_prc("Prc_GetTop1ChnAgnSu",htParam);
            //Added by pranjali on 05-07-2013 for getting top 1 unit rank and agent type end
            //dtRead1 = objDAL.exec_reader("Select Top 1 UnitRank,AgentType From chnAgnSu where UnitRank < '" + strUnitRank + "' AND BizSrc='" + Request.QueryString["Field3"].Trim() + "' Order by UnitRank Desc");
			if (dtRead1.Read())
			{
				ViewState["strUntRank"] = dtRead1[0].ToString();
				ViewState["strAgnType"] = dtRead1[1].ToString();
			}
			dtRead1.Close();
			if (ViewState["strAgnType"] == "" || ViewState["strAgnType"] == null)
			{
				ddlAgntType.SelectedValue = "";
				ddlAgntType.Enabled = false;
				lblMessage.Visible = true;
				lblMessage.Text = "There is no Manager available for Agent type" + '-' + Request.QueryString["Field5"].Trim();
			
			}
			else
			{
                if (ViewState["AgentCreateRul"].ToString() == "BM" && ViewState["UntRule"].ToString() == "1")
                {
                    //Added by pranjali on 05-07-2013 for getting top 2 agent type and agent type desc start 
                    htParam.Clear();
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@UnitRank", strUnitRank);
                    htParam.Add("@BizSrc", Request.QueryString["Field3"].Trim());
                    htParam.Add("@flag", 2);
                    dtRead = objDAL.Common_exec_reader_prc("Prc_ddlAgentType",htParam);
                    //dtRead = objDAL.exec_reader("SELECT TOP 2 AgentType, (AgentType + '-' + AgentTypeDesc01)AS AgentTypeDesc FROM ChnAgnSu WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND UnitRank < '" + strUnitRank + "' AND BizSrc='" + Request.QueryString["Field3"].Trim() + "' Order by UnitRank Desc");
                    //Added by pranjali on 05-07-2013 for getting top 2 agent type and agent type desc end
                    if (dtRead.HasRows)
                    {
                        ddlAgntType.DataSource = dtRead;
                        ddlAgntType.DataTextField = "AgentTypeDesc";
                        ddlAgntType.DataValueField = "AgentType";
                        ddlAgntType.DataBind();
                    }
                    dtRead = null;

                }
                else
                {
                    //Added by pranjali on 05-07-2013 for getting agent type and agent type desc start 
                    htParam.Clear();
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@UnitRank", ViewState["strUntRank"].ToString());
                    htParam.Add("@BizSrc", Request.QueryString["Field3"].Trim());
                    htParam.Add("@flag", 1);
                    dtRead = objDAL.Common_exec_reader_prc("Prc_ddlAgentType", htParam);
                    //dtRead = objDAL.exec_reader("SELECT AgentType, (AgentType + '-' + AgentTypeDesc01)AS AgentTypeDesc FROM ChnAgnSu WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND UnitRank='" + ViewState["strUntRank"].ToString() + "' AND BizSrc='" + Request.QueryString["Field3"].Trim() + "'");
                    //Added by pranjali on 05-07-2013 for getting agent type and agent type desc end
                    if (dtRead.HasRows)
                    {
                        ddlAgntType.DataSource = dtRead;
                        ddlAgntType.DataTextField = "AgentTypeDesc";
                        ddlAgntType.DataValueField = "AgentType";
                        ddlAgntType.DataBind();
                    }
                    dtRead = null;
                }
				ddlAgntType.Enabled = true;
			}
			
        }
    }
    #endregion

    #region InitializeControl
    private void InitializeControl()
    {
        lblsalesChannel.Text = ObjDec.GetDecData(olng.GetItemDesc("lblsalesChannel.Text"));
        lblChnCls.Text = ObjDec.GetDecData(olng.GetItemDesc("lblChnCls.Text"));
        lblAgentType.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgentType.Text"));
        lblAgntCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgntCode.Text"));
        lblAgntName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgntName.Text"));
        lblCustomerId.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCustomerId.Text"));
        lblSapCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSapCode"));
        
    }
    #endregion

    #region btnSearch Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
		this.BindDataGrid();
    }
    #endregion

    #region METHOD 'BindDatagrid()' DEFINITION
    protected void BindDataGrid()
	{

		htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
		htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
		htParam.Add("@AgentType", ddlAgntType.SelectedValue);
		htParam.Add("@bizSrc", ddlSlsChannel.SelectedValue);
		htParam.Add("@AgentName", txtAgntName.Text);
		htParam.Add("@AgentCode", txtAgntCode.Text);
		htParam.Add("@ClientCode", txtCustomerId.Text);
		htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
        htParam.Add("@EmpCode", txtSapCode.Text);
		dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_AgentListForAccntPay", htParam);
		if (dsResult.Tables.Count > 0)
		{
			if (dsResult.Tables[0].Rows.Count > 0)
			{
				dgDetails.DataSource = dsResult.Tables[0];
				dgDetails.DataBind();
				trDetails.Visible = true;
				trdgDetails.Visible = true;
				lblMessage.Text = "";
				lblMessage.Visible = false;
				ShowPageInformation();
			}
			else
			{
				dgDetails.DataSource = null;
				dgDetails.DataBind();
				trDetails.Visible = false;
				trdgDetails.Visible = false;
				lblPageInfo.Text = "";
				lblMessage.Visible = true;
				lblMessage.Text = "0 RECORD FOUND.";
			}
		}
		else
		{
			dgDetails.DataSource = null;
			dgDetails.DataBind();
			trDetails.Visible = false;
			trdgDetails.Visible = false;
			lblPageInfo.Text = "";
			lblMessage.Visible = true;
			lblMessage.Text = "0 RECORD FOUND.";
		}
		dsResult = null;
		htParam.Clear();
	}
	#endregion

    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {        
        
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        htParam.Add("@AgentType", ddlAgntType.SelectedValue);
        htParam.Add("@bizSrc", ddlSlsChannel.SelectedValue);
        htParam.Add("@AgentName", txtAgntName.Text);
        htParam.Add("@AgentCode", txtAgntCode.Text);
        htParam.Add("@ClientCode", txtCustomerId.Text);
        htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
        htParam.Add("@EmpCode", txtSapCode.Text);
        dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_AgentListForAccntPay", htParam);
		htParam.Clear();
        return dsResult.Tables[0];
    }
    #endregion

    #region GRIDVIEW dgDetails RowDataBound
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = new LinkButton();
            lnk = (LinkButton)e.Row.FindControl("lnkAgntCode");
            string strCompUntCode = ((HiddenField)e.Row.Cells[6].FindControl("hdnCompUntCode")).Value;
            lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[0].Text.Trim() + "','" + e.Row.Cells[1].Text.Trim() + "','" + e.Row.Cells[5].Text.Trim().Replace("&nbsp;", "") + "','" + strCompUntCode + "');return false;");
        }
    }
    #endregion

    #region ddlSlsChannel SelectedIndexChanged
    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
	{
		ddlAgntType.Items.Clear();
        ddlChnCls.Items.Clear();
        SqlDataReader dtRead;
        // Added by pranjali on 05-07-2013 for getting channel sub class dropdown start
        Hashtable htparam = new Hashtable();
        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
        // Added by pranjali on 05-07-2013 for getting channel sub class dropdown end
        //dtRead = objDAL.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSlsChannel.SelectedValue + "'");
        if (dtRead.HasRows)
        {
            ddlChnCls.DataSource = dtRead;
            ddlChnCls.DataTextField = "ChnlDesc";
            ddlChnCls.DataValueField = "ChnCls";
            ddlChnCls.DataBind();
        }
        dtRead = null;
        ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
		ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
    }
    #endregion

    #region dgDetails Sorting
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
    #endregion

    #region dgDetails PageIndexChanging
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    #endregion

    #region FUNCTION ShowPageInformation
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    protected void txtCustomerId_TextChanged(object sender, EventArgs e)
	{

	}

	protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
	{

	}

    #region ddlChnCls SelectedIndexChanged
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlSlsChannel.SelectedIndex == 0)
		{
			oCommonU.GetAgentType(ddlAgntType, "All", "");
		}
		else
		{
			oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, "", ddlChnCls.SelectedValue);
		}
		ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
    }
    #endregion
}

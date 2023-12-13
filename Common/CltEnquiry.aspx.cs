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
using System.ComponentModel;
using System.Drawing;
using INSCL.DAL;
using DataAccessClassDAL;
public partial class Application_Common_CltEnquiry : BaseClass
{
    CommonFunc oCommon = new CommonFunc();
    private const string c_strBlank = "-- Select --";
    DataAccessClass objDAL = new DataAccessClass();//RK
    Hashtable htparam = new Hashtable();
    DataAccessClass dataAccess = new DataAccessClass();
    string strSapCode = string.Empty;
    string strType = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["SapCode"] != null)
                {
                    strSapCode = Request.QueryString["SapCode"].ToString().Trim();
                    strType = Request.QueryString["Type"].ToString().Trim();
                }

            }
            //added by akshay on 20/12/13 start
            if (GetModuleValue("CHMS") == "M")
            {
                btnAddNewAgt.Visible = false;
            }
            else
            {
                btnAddNewAgt.Visible = true;
                btnAddNewAgt_Click(sender, e);
            }
            //added by akshay on 20/12/13 end
            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            subPopulateClientType();
            subPopulateIdType();
            subPopulateGender();
            if (ddlCltType.SelectedValue == "A")
                subShowIndividual();
            else
                subShowCorporate();
            
            if (Request.QueryString["Type"].ToString().Trim() == "Emp")
            {
                btnAddNewAgt.Text = "Add New Employee";
               
            }
            else if (Request.QueryString["Type"].ToString().Trim() == "Ven")
            {
                btnAddNewAgt.Text = "Add New Vendor";
                
            }
            else
            {
                btnAddNewAgt.Text = "Add New Agent";
                
            }
        }
        trRow.Visible = false;
        trRow1.Visible = false;
        trRow2.Visible = false;
    }

    private void subPopulateClientType()
    {
        oCommon.getDropDown(ddlCltType, "CltType", int.Parse(Session["UserLangNum"].ToString()), "", 1);
    }

    private void subPopulateIdType()
    {
        oCommon.getDropDown(ddlIdType, "NBSIDKey", int.Parse(Session["UserLangNum"].ToString()), "", 1, c_strBlank);
    }

    private void subPopulateGender()
    {
        oCommon.getDropDown(ddlGender, "NBGender", int.Parse(Session["UserLangNum"].ToString()), "", 1, c_strBlank);
        ddlGender.Items.Remove(ddlGender.Items.FindByValue("C"));
    }

    public void Search(int intPage, string strSortField, string strSortDirection)
    {
		string strIDType="";
        string strGCN = this.txtGCN.Text.Trim();////
        string strSurname = (ddlCltType.SelectedValue == "A") ? this.txtSurname.Text.Trim() : txtCoName.Text.Trim();////
        string strGivenNm = (ddlCltType.SelectedValue == "A") ? this.txtGivenNm.Text.Trim() : String.Empty;////
        string strDOB = dtpDOB.Text.Trim();////
		//commented by ank on 03.08.2011
        //string strGender = (ddlCltType.SelectedValue == "A") ? ddlGender.SelectedValue : "C";////
		string strGender =  ddlGender.SelectedValue;
		if (ddlCltType.SelectedValue == "A")
		{
			 strIDType = (ddlCltType.SelectedValue == "A") ? ddlIdType.SelectedValue : "P";////
		}
		else if (ddlCltType.SelectedValue == "C")
		{
			 strIDType = (ddlCltType.SelectedValue == "C") ? ddlIdType.SelectedValue : "R";
		}
        string strIDNo = (ddlCltType.SelectedValue == "A") ? this.txtIDNo.Text.Trim() : txtCoRegNo.Text.Trim();////
        string strCltType = ddlCltType.SelectedValue;////
        string strTelNum = (ddlCltType.SelectedValue == "A") ? txtTelNo.Text.Trim() : txtCoTelNo.Text.Trim();
        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        bool blnNoEntry = true;

        if (strGCN.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strSurname.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strDOB.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strIDNo.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strTelNum.Trim().ToString() != string.Empty)
            blnNoEntry = false;

        if (strCltType.ToString() == "A")
        {
            if (strGivenNm.Trim().ToString() != string.Empty)
                blnNoEntry = false;
            if (strGender.Trim().ToString() != string.Empty)
                blnNoEntry = false;
            if (strIDType.Trim().ToString() != string.Empty)
                blnNoEntry = false;
        }

        if (blnNoEntry)
        {
            lblNoRecord.Visible = true;
            lblNoRecord.Text = "Enter search criteria and press search to begin searching.";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.PageSize = int.Parse((ddlCltType.SelectedValue == "A") ? ddlShowRec.SelectedValue : ddlCoShowRec.SelectedValue);
            if (strCltType != "A")
            {
                Insc.MQ.Common.Client.MQClientMgr oMQClnMgr = new Insc.MQ.Common.Client.MQClientMgr();
                DataView dv = (DataView)oMQClnMgr.SearchClient(strGCN, strIDNo, strIDType, String.Empty,
                   String.Empty, strCltType, strGivenNm + ' ' + strSurname,
                   strGivenNm, strSurname, strGender, strDOB, strTelNum, strUserGCN).Tables[0].DefaultView;
                //Added by rachana 0n 08-07-2013 start
                if (strSortField == String.Empty)
                {
                    dv.ApplyDefaultSort = true;
                }
                else
                {
                    dv.Sort = strSortField + " " + strSortDirection;
                }

                GridView1.DataSource = dv;
                GridView1.PageIndex = intPage;
                GridView1.DataBind();
                GridView1.Visible = true;
                lblNoRecord.Visible = false;
                if (GridView1.Rows.Count == 0)
                {
                    lblNoRecord.Visible = true;
                    lblNoRecord.Text = "0 record found.";
                }
                //Added by rachana 0n 08-07-2013 end 
            }
            else
            //Added by rachana on 08-07-2013 for personal client search start
            {
                Hashtable htable = new Hashtable();
                htable.Add("@CltType", strCltType);
                htable.Add("@CltStat", "P");
                htable.Add("@txtGCN", txtGCN.Text.Trim());
                htable.Add("@dtpDOB", dtpDOB.Text.Trim());
                htable.Add("@txtGivenNm", txtGivenNm.Text.Trim());
                htable.Add("@IDType", ddlIdType.SelectedValue);
                htable.Add("@txtidnumber", txtIDNo.Text.Trim());
                htable.Add("@gender", ddlGender.SelectedValue);
                htable.Add("@txttelephno", txtTelNo.Text.Trim());
                DataSet ds = objDAL.GetDataSetForPrcCLP("Prc_GetDataClientSearch", htable);
                DataView dv = new DataView();


                //Added by rachana on 08-07-2013 for personal client search end

                if (strSortField == String.Empty)
                {
                    dv.ApplyDefaultSort = true;
                }
                else
                {
                    dv.Sort = strSortField + " " + strSortDirection;
                }

                //GridView1.DataSource = dv; Commented by rachana 08-07-2013
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.PageIndex = intPage;
                GridView1.DataBind();
                GridView1.Visible = true;
                lblNoRecord.Visible = false;
                if (GridView1.Rows.Count == 0)
                {
                    lblNoRecord.Visible = true;
                    lblNoRecord.Text = "0 record found.";
                }
            }
        }

        if (ddlCltType.SelectedValue == "A")
            subShowIndividual();
        else
            subShowCorporate();

        //lblNoRecord.Text = "Client Listing";
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Search(0, String.Empty, String.Empty);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlGender.ClearSelection();
        //ddlCltType.ClearSelection();
        ddlIdType.ClearSelection();
        ddlShowRec.ClearSelection();
        ddlCoShowRec.ClearSelection();
        this.txtGCN.Text = String.Empty;
        this.txtSurname.Text = String.Empty;
        this.txtGivenNm.Text = String.Empty;
        this.txtIDNo.Text = String.Empty;
        this.dtpDOB.Text = String.Empty;
        this.txtTelNo.Text = String.Empty;
        txtCoTelNo.Text = String.Empty;
        txtCoRegNo.Text = String.Empty;
        txtCoName.Text = String.Empty;

        lblNoRecord.Visible = true;
        lblNoRecord.Text = "Enter search criteria and press search to begin searching.";
        GridView1.Visible = false;
        //Search();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Search(e.NewPageIndex, String.Empty, String.Empty);
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == ViewState["SortField"].ToString())
        {
            switch (ViewState["SortDirection"].ToString())
            {
                case "ASC":
                    ViewState["SortDirection"] = "DESC";
                    break;

                case "DESC":
                    ViewState["SortDirection"] = "ASC";
                    break;
            }
        }
        else
        {
            ViewState["SortField"] = e.SortExpression;
            ViewState["SortDirection"] = "ASC";
        }

        Search(GridView1.PageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());
    }

    protected void EditPage(object sender, CommandEventArgs e)
    {
        string strGCN = e.CommandArgument.ToString();
        string strCltType = e.CommandName.ToString();

        Session.Remove("CorpCltNew_GCN");
        Session.Remove("CltEnquiry");
        if (strCltType == "C")
        {
            this.Session.Add("CorpCltNew_GCN", strGCN);
            this.Session.Add("CltEnquiry", "1");
            Response.Redirect("CorpClt.aspx?Enq=1&FLAGFIND=1&GCN=" + strGCN);
        }
        else
        {
            this.Session.Add("CltNew_GCN", strGCN);
            this.Session.Add("CltEnquiry", "1");
            Response.Redirect("Clt.aspx?Enq=1&FLAGFIND=1&GCN=" + strGCN);
        }
    }

    protected void ddlCltType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlCltType.SelectedValue.ToUpper())
        {
            case "A":
                subShowIndividual();
                GridView1.Visible = false;
                break;

            case "C":
                subShowCorporate();
                GridView1.Visible = false;
                break;
        }
    }

    private void subShowIndividual()
    {
        lblDOB.Text = "Date of Birth";
        tbl.Rows[3].Visible = true;
        tbl.Rows[4].Visible = true;
        tbl.Rows[5].Visible = false;
        tbl.Rows[6].Visible = false;
        tbl.Rows[7].Visible = false;
        tbl.Rows[8].Visible = false;
        trRow.Visible = false;
        trRow1.Visible = false;
        trRow2.Visible = false;
        GridView1.Columns[2].Visible = true;
        GridView1.Columns[3].HeaderText = "Date Of Birth";
        GridView1.Columns[6].HeaderText = "Home Tel";
        GridView1.Columns[7].HeaderText = "Office Tel";
        GridView1.Columns[6].Visible = true;
        GridView1.Columns[7].Visible = true;
        GridView1.Columns[8].Visible = false;
        GridView1.Columns[9].Visible = false;
        GridView1.DataBind();

    }

    private void subShowCorporate()
    {
        lblDOB.Text = "Date Incorporated";
        tbl.Rows[3].Visible = false;
        tbl.Rows[4].Visible = false;
        tbl.Rows[5].Visible = true;
        tbl.Rows[6].Visible = true;
        tbl.Rows[7].Visible = false;
        tbl.Rows[8].Visible = false;
        //trRow.Visible = false;
        //trRow1.Visible = false;
        //trRow2.Visible = false;
        GridView1.Columns[2].Visible = false;
        GridView1.Columns[3].HeaderText = "Date Incorporated";
        GridView1.Columns[8].HeaderText = "Work Tel";
        GridView1.Columns[9].HeaderText = "Alternate Work  Tel";
        GridView1.Columns[6].Visible = false;
        GridView1.Columns[7].Visible = false;
        GridView1.Columns[8].Visible = true;
        GridView1.Columns[9].Visible = true;
        GridView1.DataBind();
    }
    protected void btnAddNewAgt_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString().Trim() == "Agn")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?Type=N&ID=IN");
            }
            if (Request.QueryString["Type"].ToString().Trim() == "Emp")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?Type=N&ID=IN&Ctgry=Emp");
            }
            if (Request.QueryString["Type"].ToString().Trim() == "MomEmp")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?Type=N&ID=IN&Ctgry=Emp&Source=MomEmp&SapCode=" + strSapCode + "");
            }
            if (Request.QueryString["Type"].ToString().Trim() == "Ven")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?Type=N&ID=IN&Ctgry=Ven");
            }
            if (Request.QueryString["Type"].ToString().Trim() == "MC")
            {
               // Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?&Type=N&ID=IN&MvmtMode=M");
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?Type=N&ID=IN&MvmtMode=0");
            }
        }
    }
    protected void lnkMapClt_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton edit = (LinkButton)grd.FindControl("lblEdit");
        string ed = edit.Text;
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString().Trim() == "Agn")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?&Type=Clt&ID=IN&CustID=" + ed);
            }
            if (Request.QueryString["Type"].ToString().Trim() == "Emp")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?&Type=Clt&ID=IN&Ctgry=Emp&CustID=" + ed);
            }
            if (Request.QueryString["Type"].ToString().Trim() == "Ven")
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?&Type=Clt&ID=IN&Ctgry=Ven&CustID=" + ed);
            }
            else
            {
                Response.Redirect("~/Application/ISys/ChannelMgmt/AGTInfo.aspx?&Type=Clt&ID=IN&CustID=" + ed);
            }
        }
    }

    #region GetModuleValue
    //added by akshay on 20/12/13 for fetching the module value
    public string GetModuleValue(string UserID)
    {
        string strSql = string.Empty;
        string strOutput = string.Empty;
        DataSet dsResult = new DataSet();
        
        htparam.Clear();
        htparam.Add("@ModuleName", UserID);
        dsResult = dataAccess.GetDataSetForPrc_inscdirect("Prc_GetModuleNameValue", htparam);

        strOutput = dsResult.Tables[0].Rows[0][0].ToString();
        return strOutput;

    }
    #endregion
}
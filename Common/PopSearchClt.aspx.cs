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
using CLTMGR;
using Insc.Common.Multilingual;//Added by Rachana on 20-04-2013 for requirement of namespace

public partial class Application_Common_PopSearchClt : BaseClass
{
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    protected CommonFunc oCommon = new CommonFunc();
   
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        olng = new multilingualManager("DefaultConn", "PopSearchClt.aspx", Session["UserLangNum"].ToString());
        
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        txtGCN.Focus();

        if (!IsPostBack)
        {
            
            InitializeControl();
            
            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            if ((Request.QueryString["GCN"].ToString() != String.Empty) || (Request.QueryString["Surname"].ToString() != String.Empty))
            {
                txtGCN.Text = Request.QueryString["GCN"].ToString();
                txtSurname.Text = Request.QueryString["Surname"].ToString();
                txtGivenName.Text = Request.QueryString["GivenName"].ToString();
                cboGender.SelectedValue = Request.QueryString["Gender"].ToString();
                if (Request.QueryString["DOB"].Length > 0)
                {
                    txtDOB.Text = DateTime.Parse(Request.QueryString["DOB"].ToString()).ToString("dd/MM/yyyy");
                }
                txtIDNo.Text = Request.QueryString["OthersID"].ToString();
                cboIdType.SelectedValue = Request.QueryString["OtherIDType"].ToString();

                subGetRec(0, String.Empty, String.Empty);
            }
        }
    }

    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        

        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
        

        string strGCN = txtGCN.Text.Trim();
        string strGivenNm = txtGivenName.Text.Trim();
        string strSurname = txtSurname.Text.Trim();
        string strGender = cboGender.SelectedValue;
        string strDOB = string.Empty;
        if (txtDOB.Text.Length > 0)
        {
            strDOB = txtDOB.GetDateValue;
        }
        string strCurrentIDNo = txtIDNo.Text.Trim();
        string strCurrentIDType = cboIdType.SelectedValue;
        string strTelNum = txtTelNo.Text.Trim();
        string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        bool blnNoEntry = true;
        gv.Visible = false;

        if (strGCN.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strSurname.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strGivenNm.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strGender.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strDOB.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strCurrentIDNo.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strCurrentIDType.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strTelNum.Trim().ToString() != string.Empty)
            blnNoEntry = false;

        if (blnNoEntry)
        {
            lblNoRecord.Visible = true;
            lblNoRecord.Text = "Enter search criteria and press search to begin searching.";
        }
        else
        {
            gv.Visible = true;
            gv.DataSource = oMQCltMgr.MatchClient(strGCN, strCarrierCode, strCurrentIDNo, strCurrentIDType,
                           string.Empty, string.Empty, "A", strGivenNm, strSurname, strGender,
                           strDOB, strTelNum, strUserGCN);

            
            gv.PageIndex = intPage;
            gv.DataBind();

            lblNoRecord.Visible = false;
            if (gv.Rows.Count == 0)
            {
                lblNoRecord.Visible = true;
                lblNoRecord.Text = "0 record found.";
            }
            
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        subGetRec(0, String.Empty, String.Empty);
    }

    protected void gv_Sorting(Object sender, GridViewSortEventArgs e)
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

        subGetRec(gv.PageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());
    }

    protected void gv_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        subGetRec(e.NewPageIndex, ViewState["SortField"].ToString(), ViewState["SortDirection"].ToString());
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = new LinkButton();
            lnk = (LinkButton)e.Row.FindControl("lnk");
            lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[2] + "','" + ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[4] + "');return false;");
        }
    }
    
    private void InitializeControl()
    {
        lblGCN.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGCN"));
        lblGender.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGender"));
        lblGivenName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGivenName"));
        lblSurname.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSurname"));
        lblDOB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDOB"));
        lblTelNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTelNo"));
        lblIDType.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIDType"));
        lblIDNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblIDNo"));
    }
    

}

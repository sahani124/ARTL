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
using Insc.Common.Multilingual;
using CLTMGR;
public partial class Application_Common_PopSearchCorpClt : BaseClass
{
    private multilingualManager olng;
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    protected CommonFunc oCommon = new CommonFunc();
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        olng = new multilingualManager("DefaultConn", "PopSearchCorpClt.aspx", Session["UserLangNum"].ToString());
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        this.Title = "Corporate Client Listing";
        this.txtGCN.Focus();
        lblNoRecord.Visible = false;

        if (!IsPostBack)
        {
            InitializeControl();
            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            if ((Request.QueryString["GCN"].ToString() != String.Empty) || (Request.QueryString["Surname"].ToString() != String.Empty))
            {
                txtGCN.Text = Request.QueryString["GCN"].ToString();
                txtSurname.Text = Request.QueryString["Surname"].ToString();
                txtCurrentID.Text = Request.QueryString["CurrentID"].ToString();
                if (Request.QueryString["DOB"].Length > 0)
                {
                    txtDOB.Text = DateTime.Parse(Request.QueryString["DOB"].ToString()).ToString("dd/MM/yyyy");
                }
		txtTelNo.Text = Request.QueryString["Tel"].ToString();
                subGetRec(0, String.Empty, String.Empty);
            }
        }
    }
    //Add By Darshik 16/05/2012
    private void InitializeControl()
    {
        lblGCN.Text = ObjDec.GetDecData(olng.GetItemDesc("lblGCN"));
        lblDOB.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDOB"));
        lblSurname.Text = ObjDec.GetDecData(olng.GetItemDesc("lblSurname"));
        lblCurrentID.Text = ObjDec.GetDecData(olng.GetItemDesc("lblCurrentID"));
        lblTelNo.Text = ObjDec.GetDecData(olng.GetItemDesc("lblTelNo"));

    }

    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {

        Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();

        string strGCN = txtGCN.Text.Trim();
        string strGivenNm = string.Empty;
        string strSurname = txtSurname.Text.Trim();
        string strGender = "C";
        string strDOB = string.Empty;
        if (txtDOB.Text.Length > 0)
        {
            strDOB = txtDOB.GetDateValue;
        }
        string strCurrentIDNo = txtCurrentID.Text.Trim();
        string strCurrentIDType = "R"; // string.Empty;
        string strTelNum = txtTelNo.Text.Trim();
        string strCarrierCode = HttpContext.Current.Session["CarrierCode"].ToString();
        string strUserGCN = HttpContext.Current.Session["UserId"].ToString();

        bool blnNoEntry = true;
        gv.Visible = false;

        if (strGCN.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strSurname.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strDOB.Trim().ToString() != string.Empty)
            blnNoEntry = false;
        if (strCurrentIDNo.Trim().ToString() != string.Empty)
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
                           string.Empty, string.Empty, "C", strGivenNm, strSurname, strGender,
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
}

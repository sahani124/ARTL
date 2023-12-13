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
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;

public partial class Application_Admin_SearchUser1 : BaseClass
{
    private multilingualManager olng;
    private string strUserLang;
    CommonFunc oCommon = new CommonFunc();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "SearchUser.aspx", strUserLang);


        if (!Page.IsPostBack)
        {
            InitializeControl();
            InitCulture();
            SearchUser(0);
        }


    }

    private void InitCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-us");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
    }

    private void InitializeControl()
    {
        lblModVer.Text = olng.GetItemDesc("lblModVer.Text");
        lblTitle.Text = olng.GetItemDesc("lblTitle.Text");
        lblUserID.Text = olng.GetItemDesc("lblUserID.Text");
        lblUserName.Text = olng.GetItemDesc("lblUserName.Text");
        lblStatus.Text = olng.GetItemDesc("lblStatus.Text");
        lblReturnRecord.Text = olng.GetItemDesc("lblReturnRecord.Text").ToString();
        oCommon.getDropDown(cboStatus, "userstat", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
        //btnHClear.Text = olng.GetItemDesc("btnHClear.Value");
        // btnSearchAdv.Text = olng.GetItemDesc("btnSearch.Text");
        lblSearchResult.Text = olng.GetItemDesc("lblSearchResult.Text");
        // lblUserID.Text = olng.GetItemDesc("lblUserID.Text");
        // lblUserName.Text = olng.GetItemDesc("lblUserName.Text");
        // lblStatus.Text = olng.GetItemDesc("lblStatus.Text");
        // lblReturnRecord.Text = olng.GetItemDesc("lblReturnRecord.Text");

    }

    protected void cboStatus_DataBound(object sender, EventArgs e)
    {
        cboStatus.Items.Insert(0, new ListItem(olng.GetItemDesc("lblAll.Text"), "ALL"));
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/Admin/UsrSu.aspx?mode=new");
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/Admin/AdmUsrGrpSettings.aspx");
    }
    public void SearchUser(int intPageIndex)
    {
        //  gvResult.AllowPaging = false;
        // gvResult.Visible = true;
        // gvResult.DataSourceID = "ObjectDataSource1";

        gvResult.PageSize = int.Parse(cboReturnRecord.Text);
        gvResult.PageIndex = intPageIndex;
        ObjectDataSource1.DataBind();
        gvResult.DataBind();

        gvResult.Columns[0].HeaderText = olng.GetItemDesc("Gcol1");
        gvResult.Columns[1].HeaderText = olng.GetItemDesc("Gcol2");
        gvResult.Columns[2].HeaderText = olng.GetItemDesc("Gcol3");
        //   commented By amit
        //lblPageIndex.Text = "";
        //int page = gvResult.PageIndex + 1;

        //if (gvResult.Rows.Count < 1)
        //{
        //    lblPageIndex.Text = "";

        //}
        //else
        //    lblPageIndex.Text = olng.GetItemDesc("Page.Text") + " " + page + " " + olng.GetItemDesc("of.Text") + " " + gvResult.PageCount.ToString();
        //   commented By amit
        /*
                if (gvResult.Rows.Count < 0)
                {
                    lblNoRecord.Visible = true;
                    lblNoRecord.Text = "Enquiry completed. No record found.";
                }
                else
                {
                    lblNoRecord.Visible = true;
                    lblNoRecord.Text = gvResult.Rows.Count + " record(s) found.";
                }
         */
    }

    protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchUser(e.NewPageIndex);
    }

    //protected void lbUserId_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = gvResult.SelectedRow;
    //    LinkButton lbUserId = (LinkButton)row.FindControl("lbUserId");
    //    Response.Redirect("~/Application/Admin/UsrSu.aspx?mode=edit&UserId=" + lbUserId.Text + "");
    //}

}
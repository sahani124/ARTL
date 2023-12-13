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
using Insc.Common.Multilingual;
public partial class Application_Common_PopNational : BaseClass
{
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();

    
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        
        olng = new multilingualManager("DefaultConn", "PopNational.aspx", Session["UserLangNum"].ToString());
        

        txtStateCode.Focus();

        if (!IsPostBack)
        {
            
            InitializeControl();
            

            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            if ((Request.QueryString["Code"].ToString() != String.Empty) || (Request.QueryString["Desc"].ToString() != String.Empty))
            {
                txtStateCode.Text = Request.QueryString["Code"].ToString();
                txtStateDesc.Text = Request.QueryString["Desc"].ToString();

                subGetRec(0, String.Empty, String.Empty);
            }
        }
    }

    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        string strSQL = "prc_Lookup_sel " +
            oCommon.fncFormatSQLParam(Session["UserLangNum"].ToString()) + "," +
            oCommon.fncFormatSQLParam(txtStateCode.Text.Trim()) + "," +
            oCommon.fncFormatSQLParam(txtStateDesc.Text.Trim()) + "," +
            oCommon.fncFormatSQLParam("National");

        DataView dv = new DataView(oDP.ReadData("INSCDirectConnectionString", strSQL).Tables[0]);

        if (strSortField == String.Empty)
        {
            dv.ApplyDefaultSort = true;
        }
        else
        {
            dv.Sort = strSortField + " " + strSortDirection;
        }

        gv.DataSource = dv;
        gv.PageIndex = intPage;
        gv.DataBind();

        lblErrMsg.Visible = (gv.Rows.Count == 0) ? true : false;

        dv = null;
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
            lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
    
    private void InitializeControl()
    {
        lblStateCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateCode.Text"));
        lblStateDesc.Text = ObjDec.GetDecData(olng.GetItemDesc("lblStateDesc.Text"));
        lblErrMsg.Text = ObjDec.GetDecData(olng.GetItemDesc("lblErrMsg"));
    }
    
}

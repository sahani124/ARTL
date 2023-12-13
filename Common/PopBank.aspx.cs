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
public partial class Application_Receipt_PopBank : BaseClass
{
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();

    //Added by Saleem----------Start
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    //Added by Saleem----------End
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        //Added by Saleem----------Start
        olng = new multilingualManager("DefaultConn", "PopBank.aspx", Session["UserLangNum"].ToString());
        //Added by Saleem----------End
        txtBankCode.Focus();

        if (!IsPostBack)
        {
            //Added by Saleem----------Start
            InitializeControl();
            //Added by Saleem----------End
            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            if ((Request.QueryString["BankCode"].ToString() != String.Empty) || (Request.QueryString["BankName"].ToString() != String.Empty))
            {
                txtBankCode.Text = Request.QueryString["BankCode"].ToString();
                txtBankName.Text = Request.QueryString["BankName"].ToString();

                subGetRec(0, String.Empty, String.Empty);
            }
        }
    }

    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        string strSQL = "prc_LookupBank_sel " +
            oCommon.fncFormatSQLParam(Session["UserLangNum"].ToString()) + "," +
            oCommon.fncFormatSQLParam(txtBankCode.Text.Trim()) + "," +
            oCommon.fncFormatSQLParam(txtBankName.Text.Trim());

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
            LinkButton lnkBankCode = new LinkButton();
            lnkBankCode = (LinkButton)e.Row.FindControl("lnk");
            lnkBankCode.Attributes.Add("onclick", "doSelect('" + lnkBankCode.Text + "','" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
    //Added by Saleem---------------Start
    private void InitializeControl()
    {
        lblBankCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblBankCode"));
        lblBankName.Text = ObjDec.GetDecData(olng.GetItemDesc("lblBankName"));
        lblErrMsg.Text = ObjDec.GetDecData(olng.GetItemDesc("lblErrMsg"));
    }
    //Added by Saleem---------------Start
}

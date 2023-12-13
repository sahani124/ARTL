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
using System.Data.SqlClient;
using INSCL.DAL;
using INSCL.App_Code;
using System.Text;
using CLTMGR;
using Insc.Common.Multilingual;
using DataAccessClassDAL;

public partial class Application_Common_PopDistrict : BaseClass
{
    Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessclass = new DataAccessClass();
    public const string CONN_Recruit = "INSCRecruitConnectionString";

    //Added by Saleem----------Start
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    //Added by Saleem----------End
    EncodeDecode ObjDec = new EncodeDecode();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by Saleem----------Start
        olng = new multilingualManager("DefaultConn", "PopDistrict.aspx", Session["UserLangNum"].ToString());
        //Added by Saleem----------End
        if (HttpContext.Current.Session["SessionId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (!IsPostBack)
        {
            //Added by Saleem----------Start
            InitializeControl();
            //Added by Saleem----------End

            ViewState["SortField"] = String.Empty;
            ViewState["SortDirection"] = String.Empty;

            if (Request.QueryString.Count > 0)
            {
                //if (Request.QueryString["DistDesc"].ToString() != String.Empty)
                //{
                //    txtDistDesc.Text = Request.QueryString["DistDesc"].ToString();
                //    subGetRec(0, String.Empty, String.Empty);
                //}
                if (Request.QueryString["txtDisc"].ToString() != String.Empty)
                {
                    txtDistDesc.Text = Request.QueryString["txtDisc"].ToString();
                    subGetRec(0, String.Empty, String.Empty);
                }
                
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        subGetRec(0, String.Empty, String.Empty);
    }
    private void subGetRec(int intPage, string strSortField, string strSortDirection)
    {
        //string strSQL = "Prc_GetDistrict '" + Request.QueryString["StateCode"].ToString() + "'";
        //string strSQL = "Select DistrictSU.District,DistrictSU.PinCode_From,DistrictSU.PinCode_To,IsysLookupParam.ParamValue,IsysLookupParam.ParamDesc1 [ParamDesc]" +
        //" from InscRecruit..DistrictSU inner join InscDirect..IsysLookupParam with (nolock) on DistrictSU.StateCode = IsysLookupParam.ParamValue and IsysLookupParam.LookupCode='NBSTATE'" +
        //" Where DistrictSU.StateCode='" + Request.QueryString["StateCode"].ToString().Trim() + "'";

        //if (txtDistDesc.Text.ToString().Trim() != "")
        //{
        //    strSQL = strSQL + " and isnull(DistrictSU.District,'') like '" + txtDistDesc.Text.Trim() + "%'";
        //}
        //Added By Ibrahim on 15-07-2013 to get Records for districts start
        Hashtable ht = new Hashtable();
        ht.Clear();
        ht.Add("@StateCode", Request.QueryString["StateCode"].ToString().Trim());
        ht.Add("@District", txtDistDesc.Text.Trim());
        DataSet ds = new DataSet();
        ds = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetRcrdforDistrict", ht);
        DataView dv = new DataView(ds.Tables[0]);
        //Added By Ibrahim on 15-07-2013 to get Records for districts End
        //DataView dv = new DataView(oDP.ReadData("INSCRecruitConnectionString", strSQL).Tables[0]);

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
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = new LinkButton();
            lnk = (LinkButton)e.Row.FindControl("lnk");

            HiddenField hdnDist = (HiddenField)e.Row.FindControl("hdnDist");
            HiddenField hdnPinFrom = (HiddenField)e.Row.FindControl("hdnPinFrom");
            HiddenField hdnPinTo = (HiddenField)e.Row.FindControl("hdnPinTo");
           
            lnk.Attributes.Add("onclick", "doSelect('" + lnk.Text + "','" + hdnDist.Value + "','" + hdnPinFrom.Value + "','"+ hdnPinTo.Value  +"');return false;");
        }
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
    //Added by Saleem---------------Start
    private void InitializeControl()
    {

        lblDistDesc.Text = ObjDec.GetDecData(olng.GetItemDesc("lblDistDesc"));
        lblErrMsg.Text = ObjDec.GetDecData(olng.GetItemDesc("lblErrMsg"));
    }
    //Added by Saleem---------------End
}

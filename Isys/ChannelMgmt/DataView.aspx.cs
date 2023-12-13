using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccessClassDAL;
using System.Collections;
using INSCL.DAL;
using System.Data.SqlClient;


public partial class Application_ISys_ChannelMgmt_DataView : BaseClass
{
    INSCL.App_Code.CommonUtility oCommon = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    SqlDataReader dtRead;
    int flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccessClass objDAL = new DataAccessClass();
        DataSet ds = new DataSet();
        Hashtable htParam1 = new Hashtable();
        if (!IsPostBack)
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString() == "1")
                {
                    htParam1.Add("@ChannelType", "C");
                    ds = objDAL.GetDataSetForPrcCLP("prc_ChannelSetup", htParam1);
                    DataList1.DataSource = ds.Tables[0];//.Rows[0]["ChannelDesc01"];
                    DataList1.DataBind();
                    productList.DataSource = ds.Tables[0];
                    productList.DataBind();
                    Session["dsData"] = ds.Tables[0];
                    div1.Attributes.Add("style", "display:block");
                    div2.Attributes.Add("style", "display:block");
                    Session["flag"] = 1;

                }
                if (Request.QueryString["flag"].ToString() == "2")
                {
                    show.Attributes.Add("style", "display:block");
                    oCommon.GetSalesChannel(ddlChannel, "", 1);
                    Session["flag"] = Request.QueryString["flag"].ToString();
                    lblSubChannel.Visible = false;
                    ddlSubChannel.Visible = false;
                }


            }

        }
    }




    protected void lnk1_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string BizSrc = myButton.CommandArgument.ToString();
        showData(BizSrc);
    }


    protected void lnk2_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string BizSrc = myButton.CommandArgument.ToString();
        showData(BizSrc);
    }

    public void showData(string BizSrc)
    {
        clsChannelSetup channelcode = new clsChannelSetup();
        if (Session["flag"].ToString() == "1")
        {
            dtRead = channelcode.Select(BizSrc,"2");


        }
        else
        {
            if (Session["flag"].ToString() == "2")
            {
                Hashtable htParam = new Hashtable();
                htParam.Add("@ChnCls", BizSrc);
                htParam.Add("@CarrierCode","2");
                dtRead = objDAL.Common_exec_reader_prc("prc_SelectChannelClass_initial", htParam);
            }
            else
            {
                Hashtable htParam = new Hashtable();
                htParam.Add("@BizSrc", BizSrc);
                htParam.Add("@CarrierCode", "2");
                dtRead = objDAL.Common_exec_reader_prc("prc_UnitRankSearch", htParam);
            }
        }

        FormView1.DataSource = dtRead;
        FormView1.ChangeMode(FormViewMode.Edit);
        FormView1.DataBind();
        tbList.Attributes.Add("style", "display:none");
        div3.Attributes.Add("style", "display:block");
        Session["Bizsrc"] = BizSrc;

        DataTable dt = (DataTable)Session["dsData"];
        DataRow[] dr = dt.Select("BizSrc='" + BizSrc + "'");
        if (dr != null)
        {
            int i = dt.Rows.IndexOf(dr[0]);
            if (i == 0)
            {
                LinkButton myButton = (LinkButton)FormView1.FindControl("lnkPrevious");
                myButton.Enabled = false;
                return;
            }
            else if (i == dt.Rows.Count - 1)
            {
                LinkButton myButton = (LinkButton)FormView1.FindControl("lnkNext");
                myButton.Enabled = false;
                return;
            }
        }

    }

    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        string bizsrc;
        if (Session["Bizsrc"] != "")
        {
            bizsrc = Session["Bizsrc"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("BizSrc='" + bizsrc + "'");
            if (dr != null)
            {
                int i = dt.Rows.IndexOf(dr[0]);
                if (i == 0)
                {
                    LinkButton myButton = (LinkButton)sender;
                    myButton.Enabled = false;
                    return;
                }
                i = i - 1;
                DataRow dr1 = dt.Rows[i];
                bizsrc = dr1["BizSrc"].ToString();
                showData(bizsrc);
            }
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        string bizsrc;
        if (Session["Bizsrc"] != "")
        {
            bizsrc = Session["Bizsrc"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("BizSrc='" + bizsrc + "'");
            if (dr != null)
            {
                int i = dt.Rows.IndexOf(dr[0]);

                if (i == dt.Rows.Count - 1)
                {
                    LinkButton myButton = (LinkButton)sender;
                    myButton.Enabled = false;
                    return;
                }

                i = i + 1;
                DataRow dr1 = dt.Rows[i];
                bizsrc = dr1["BizSrc"].ToString();
                showData(bizsrc);
            }
        }
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("InitalSetUp.aspx", false);
    }


    #region ddlChannel_SelectedIndexChanged
    protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable htParam = new Hashtable();
        DataSet ds = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@BizSrc", ddlChannel.SelectedValue);
        if (Session["flag"].ToString() == "2")
        {
            ds = objDAL.GetDataSetForPrc("Prc_ddlchnnlsubcls_intial", htParam);
        }
        else
        {
            ds = objDAL.GetDataSetForPrc("prc_UnitRankSearch", htParam);
        }
        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();
            productList.DataSource = ds.Tables[0];
            productList.DataBind();
            div1.Attributes.Add("style", "display:block");
            div2.Attributes.Add("style", "display:block");
            Session["dsData"] = ds.Tables[0];
        }
    }

    #endregion

}
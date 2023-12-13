using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using INSCL.DAL;

public partial class Application_ISys_ChannelMgmt_DataView_TypeSetup : BaseClass
{
    INSCL.App_Code.CommonUtility oCommon = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    SqlDataReader dtRead;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataAccessClass objDAL = new DataAccessClass();
        DataSet ds = new DataSet();
        Hashtable htParam1 = new Hashtable();
        if (!IsPostBack)
        {

            show.Attributes.Add("style", "display:block");
            oCommon.GetSalesChannel(ddlChannel, "", 1);
        }
    }

    protected void lnk1_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string UnitType = myButton.CommandArgument.ToString();
        showData(UnitType);
    }


    protected void lnk2_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string UnitType = myButton.CommandArgument.ToString();
        showData(UnitType);
    }

    public void showData(string UnitType)
    {
        clsChannelSetup code = new clsChannelSetup();
        dtRead = code.UnitTypeSelect(ddlChannel.SelectedValue,UnitType, ddlSubChannel.SelectedValue, Session["CarrierCode"].ToString());
        FormView1.DataSource = dtRead;
        FormView1.ChangeMode(FormViewMode.Edit);
        FormView1.DataBind();
        tbList.Attributes.Add("style", "display:none");
        div3.Attributes.Add("style", "display:block");
        Session["UnitType"] = UnitType;

        DataTable dt = (DataTable)Session["dsData"];
        DataRow[] dr = dt.Select("UnitType='" + UnitType + "'");
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
        string UnitType;
        if (Session["UnitType"] != "")
        {
            UnitType = Session["UnitType"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("UnitType='" + UnitType + "'");
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
                UnitType = dr1["UnitType"].ToString();
                showData(UnitType);
            }
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        string UnitType;
        if (Session["UnitType"] != "")
        {
            UnitType = Session["UnitType"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("UnitType='" + UnitType + "'");
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
                UnitType = dr1["UnitType"].ToString();
                showData(UnitType);
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
        ddlSubChannel.Items.Clear();
        SqlDataReader dtRead;
        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
        Hashtable htParam = new Hashtable();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@BizSrc", ddlChannel.SelectedValue);
        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
        //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END

        if (dtRead.HasRows)
        {
            ddlSubChannel.DataSource = dtRead;
            ddlSubChannel.DataTextField = "ChnlDesc";
            ddlSubChannel.DataValueField = "ChnCls";
            ddlSubChannel.DataBind();
        }
        dtRead = null;
        ddlSubChannel.Items.Insert(0, new ListItem("All", "All"));


    }
    #endregion

    #region ddlSubChannel_SelectedIndexChanged
    protected void ddlSubChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable htParam = new Hashtable();
        DataSet ds = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@Flag", "C");
        htParam.Add("@BizSrc", ddlChannel.SelectedValue);
        htParam.Add("@ChnCls", ddlSubChannel.SelectedValue);
        //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        ds = objDAL.GetDataSetForPrc("prc_UnitSearch", htParam);
        htParam.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            productList.DataSource = ds.Tables[0];
            productList.DataBind();
            div1.Attributes.Add("style", "display:block");
            div2.Attributes.Add("style", "display:block");
            Session["dsData"] = ds.Tables[0];
            TreeView1.Nodes.Clear();
            TreeNode headnode = new TreeNode();
            headnode.Text = "UnitType";
            TreeView1.Nodes.Add(headnode);
            DataTable dt1 = ds.Tables[0];
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = dt1.Rows[j][7].ToString();
                childnode.Value = dt1.Rows[j][4].ToString();
                headnode.ChildNodes.Add(childnode);
            }

        }
    }
    #endregion
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string myButton = TreeView1.SelectedNode.Value;
        string UnitType = myButton.ToString();
        showData(UnitType);
    }
}
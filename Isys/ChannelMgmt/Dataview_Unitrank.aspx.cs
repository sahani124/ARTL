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
using System.Configuration;
using System.Collections.ObjectModel;
using Telerik.Web.UI;
using Microsoft.Vbe.Interop;


public partial class Application_ISys_ChannelMgmt_Dataview_Unitrank : BaseClass
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

            show.Attributes.Add("style", "display:block");
            oCommon.GetSalesChannel(ddlChannel, "", 1);
        }
    }

    protected void lnk1_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string UnitRank = myButton.CommandArgument.ToString();
        showData(UnitRank);
    }


    protected void lnk2_click(object sender, EventArgs e)
    {
        LinkButton myButton = (LinkButton)sender;
        string UnitRank = myButton.CommandArgument.ToString();
        showData(UnitRank);
    }

    public void showData(string UnitRank)
    {
        clsUnitRankSu objUnitRank = new clsUnitRankSu();
        dtRead = objUnitRank.getUnitRankData(Session["CarrierCode"].ToString(), ddlChannel.SelectedValue, Convert.ToDecimal(UnitRank));
        FormView1.DataSource = dtRead;
        FormView1.ChangeMode(FormViewMode.Edit);
        FormView1.DataBind();
        tbList.Attributes.Add("style", "display:none");
        div3.Attributes.Add("style", "display:block");
        Session["UnitRank"] = UnitRank;

        DataTable dt = (DataTable)Session["dsData"];
        DataRow[] dr = dt.Select("UnitRank='" + UnitRank + "'");
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
        string UnitRank;
        if (Session["UnitRank"] != "")
        {
            UnitRank = Session["UnitRank"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("UnitRank='" + UnitRank + "'");
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
                UnitRank = dr1["UnitRank"].ToString();
                showData(UnitRank);
            }
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        string UnitRank;
        if (Session["UnitRank"] != "")
        {
            UnitRank = Session["UnitRank"].ToString();
            DataTable dt = (DataTable)Session["dsData"];
            DataRow[] dr = dt.Select("UnitRank='" + UnitRank + "'");
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
                UnitRank = dr1["UnitRank"].ToString();
                showData(UnitRank);
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
        ds = objDAL.GetDataSetForPrc("prc_UnitRankSearch", htParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //DataList1.DataSource = ds.Tables[0];
            //DataList1.DataBind();
           //this.PopulateTreeView(dt, 1, null);
            productList.DataSource = ds.Tables[0];
            productList.DataBind();
            div1.Attributes.Add("style", "display:block");
            div2.Attributes.Add("style", "display:block");
            Session["dsData"] = ds.Tables[0];
            TreeView1.Nodes.Clear();
            TreeNode headnode = new TreeNode();
            headnode.Text = "UnitRank";
            TreeView1.Nodes.Add(headnode);
            DataTable dt1 = ds.Tables[0];
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = dt1.Rows[j][3].ToString();
                childnode.Value = dt1.Rows[j][2].ToString();
                headnode.ChildNodes.Add(childnode);
            }
              
        }
    }

    #endregion

    public DataTable RootNodes()
    {
        DataTable dt = new DataTable("Root");
        dt.Columns.Add("RootId", typeof(int));
        dt.Columns.Add("RootDesc", typeof(String));
        DataRow dr = dt.NewRow();
        dr[0] = "10";
        dr[1] = "Root Node One";
        dt.Rows.Add(dr);
        DataRow dr1 = dt.NewRow();
        dr1[0] = "20";
        dr1[1] = "Root Node Two";
        dt.Rows.Add(dr1);
        return dt;
    }

public DataTable ChildNodes()
    {
        DataTable dt = new DataTable("Child");
        dt.Columns.Add("ChildId", typeof(int));
        dt.Columns.Add("ChildDesc", typeof(string));
        DataRow dr = dt.NewRow();
        dr[0] = "10";
        dr[1] = "Child Node One";
        dt.Rows.Add(dr);
        DataRow dr1 = dt.NewRow();
        dr1[0] = "20";
        dr1[1] = "Child Node Two";
        dt.Rows.Add(dr1);
        
        return dt;
    }

protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
{
    string myButton = TreeView1.SelectedNode.Value;
    string UnitRank = myButton.ToString();
    showData(UnitRank);
}




}
 

    
 

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
using Insc.Common.Data;
using System.Data.SqlClient;
public partial class Application_Admin_AdmUsrGrpSettings : BaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strmsg = "Update group for all user?";
        btnSetAll.Attributes.Add("onclick", "return confirm('" + strmsg + "');");

        if (!Page.IsPostBack)
        {
            cmbDataBind();
            bindGridView();
        }
    }

    protected void bindGridView()
    {
        SqlCommand sqlCommand;
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConn"].ToString());

        if (cmbSort.SelectedValue == "NA")
        {
            sqlCommand = new SqlCommand("GetUsrGrp", sqlConnection);
        }
        else
        {
            string strsql = "select distinct UserGroupCode as usergroup, (select iuser.username from iuser where iuser.userid = iUserGrpAcs.userid) as username," +
                                    "iUserGrpAcs.userid from iUserGrpAcs where UserGroupCode='" + cmbSort.SelectedValue + "' order by username";
            sqlCommand = new SqlCommand(strsql, sqlConnection);
        }

        sqlConnection.Open();
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        sqlAdapter.Fill(ds);
        UserGrid.DataSource = ds;
        UserGrid.DataBind();
    }

    protected void cmbDataBind()
    {
        SqlDataReader result;
        SqlConnection myconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConn"].ToString());
        SqlCommand command = new SqlCommand("SELECT DISTINCT UserGroupName, UserGroupCode FROM iUsrGrpSu order by usergroupname", myconnection);

        myconnection.Open();
        result = command.ExecuteReader(CommandBehavior.CloseConnection);
        cmbSort.DataSource = result;
        cmbSort.DataTextField = "UserGroupName";
        cmbSort.DataValueField = "UserGroupCode";
        cmbSort.DataBind();
        cmbSort.Items.Insert(0, new ListItem("Select", "NA"));

        myconnection.Open();
        result = command.ExecuteReader(CommandBehavior.CloseConnection);

        lstiUsrGrpAcs.DataSource = result;
        lstiUsrGrpAcs.DataTextField = "UserGroupName";
        lstiUsrGrpAcs.DataValueField = "UserGroupCode";
        lstiUsrGrpAcs.DataBind();
        lstiUsrGrpAcs.SelectedIndex = 0;
    }

    protected void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGridView();
    }

    protected void OpenWindow(object sender, GridViewCommandEventArgs e)
    {
        // Use the RightClickedRow property which is a GridViewRow to know
        // which row was right-clicked

        switch (e.CommandName)
        {
            case "User":
                break;
            case "Group":
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;

                //string UserID = (string)UserGrid.DataKeys[row.DataItemIndex].Value;

                String UserID = (string)UserGrid.DataKeys[row.DataItemIndex].Value;

                string script = "<SCRIPT>window.open" +
                                            "('AdmUsrGrpDetails.aspx?Userid=" + UserID + "','ChildForm','center=yes,status=yes,toolbar=no" +
                                            ",menubar=no,titlebar=yes,location=no,resizable=no,scrollbars=yes,width=300px,height=500px')</SCRIPT>";
                Page.RegisterClientScriptBlock("OpenChild", script);
                return;
        }
    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in UserGrid.Rows)
        {
            bool result = ((CheckBox)row.FindControl("SelectedUser")).Checked;
            if (result)
            {
                InsertGroup((string)UserGrid.DataKeys[row.DataItemIndex].Value, lstiUsrGrpAcs.SelectedValue);
            }
        }
        bindGridView();
    }

    protected void InsertGroup(string userid, string groupid)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConn"].ToString());
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        com.CommandText = "INSERT INTO iusergrpacs (carriercode,userid,moduleid,usergroupcode,usergroupname,server1)" +
                                                "SELECT carriercode,@UsrId,moduleid,usergroupcode,usergroupname,'true' FROM iusrgrpsu WHERE usergroupcode = @UsrGrpCode";
        com.Parameters.AddWithValue("@UsrGrpCode", groupid);
        com.Parameters.AddWithValue("@UsrId", userid);
        com.Connection = con;
        con.Open();
        com.ExecuteNonQuery();
    }

    protected void btnSetAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in UserGrid.Rows)
        {
            InsertGroup((string)UserGrid.DataKeys[row.DataItemIndex].Value, lstiUsrGrpAcs.SelectedValue);
        }
        bindGridView();
    }
    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        string Ltxt = txtSearchUser.Text;
        string strsql;
        SqlCommand sqlCommand;
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConn"].ToString());

        if (cmbSort.SelectedValue == "NA")
        {
            strsql = "SELECT distinct iUser.UserId,iUser.UserName as username, isnull(dbo.AllUsrGrps(iUser.userid),'') as usergroup " +
                    "FROM iUser LEFT OUTER JOIN  iUserGrpAcs ON iUser.UserId = iUserGrpAcs.UserId  where UserName like '" + Ltxt + "%' order by UserName ";
        }
        else
        {
            strsql = "select distinct iUserGrpAcs.UserGroupCode as usergroup, (select iuser.username from iuser where iuser.userid = iUserGrpAcs.userid) as username," +
            "iUserGrpAcs.userid from iUserGrpAcs LEFT OUTER JOIN  iUser ON iUser.UserId = iUserGrpAcs.UserId where iUserGrpAcs.UserGroupCode='" +
            cmbSort.SelectedValue + "' and username like '" + Ltxt + "%' order by username ";
        }

        sqlCommand = new SqlCommand(strsql, sqlConnection);
        sqlConnection.Open();
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
        DataSet ds = new DataSet();
        sqlAdapter.Fill(ds);
        UserGrid.DataSource = ds;
        UserGrid.DataBind();

    }
    protected void btnSearchGroup_Click(object sender, EventArgs e)
    {
        bool lbMatch2 = false;
        string Ltxt = txtSearchGroup.Text;
        string Llst = "";
        int lsSelected;

        Ltxt = Ltxt.ToLower();

        for (int i = 0; i < lstiUsrGrpAcs.Items.Count; i++)
        {
            lstiUsrGrpAcs.SelectedIndex = i;
            Llst = lstiUsrGrpAcs.SelectedValue;
            Llst = Llst.ToLower();
            Llst = Llst.Substring(0, Ltxt.Length);
            lbMatch2 = Ltxt == Llst;
            lsSelected = i;

            if (lbMatch2)
            {
                lstiUsrGrpAcs.SelectedIndex = lsSelected;
                return;
            }
        }
    }
}

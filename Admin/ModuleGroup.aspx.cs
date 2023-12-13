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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Insc.Common.Security;
using DataAccessClassDAL;

using Insc.Common.Multilingual;

public partial class Application_Admin_ModuleGroup : BaseClass
{
    private multilingualManager olng;
    private string strUserLang;
    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    CommonFunc oCommon = new CommonFunc();
    DataAccessClass dtAccess = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "ModuleGroup.aspx", strUserLang);

        InitializeControl();
        if (!Page.IsPostBack)
        {

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToLower())
        {
            //preview the Module Access Matrix for user group
            case "template":

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label UserGroupCode = (Label)row.FindControl("UserGroupCode");
                Label UserGroupName = (Label)row.FindControl("UserGroupName");
                Label UserCarrierCode = (Label)row.FindControl("CarrierCode");
                Label AccessFor = (Label)row.FindControl("AccessFor");
                lblUGID.Text = UserGroupCode.Text;
                lblUGName.Text = UserGroupName.Text;
                lblAccessFor.Text = AccessFor.Text;

                //title.InnerText = "Module Access Matrix for User Group " + lblUGID.Text;
                LoadDataSet(lblUGName.Text, lblUGCC.Text);

                //PopulateTreeView((DataTable)ds.Tables[0]);
                string height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
                string attributes = "display:block;z-index: 1; filter: alpha(opacity=40); left: -1px; width: 100%;posHeight:" + height + ";";
                attributes += "position: absolute; top: 0px;background-color: #cccccc; moz-opacity: .40;opacity: .40";
                PnlBlocker.Attributes["style"] = attributes;

                Panel1.Visible = true;
                break;
        }
    }
    public void LoadDataSet(string UserGroupName, string CarrierCode)
    {
        string sel_cmd;
        DataSet ds = new DataSet();
        Insc.Common.Data.Provider Odj = new Provider();

        string strUserLangNum = HttpContext.Current.Session["UserLangNum"].ToString();
        sel_cmd = "SELECT iModule.ModuleID, iModule.ModuleCode, iModule.ModuleName" + strUserLangNum + " ResDsc, iModule.ParentModuleID, ISNULL ((SELECT  AccessStatus FROM iUsrGrpSu WHERE ";
        sel_cmd += "(UserGroupName = '" + UserGroupName + "') AND (ModuleID = iModule.ModuleID)), 0) AS AccessStatus ";
        sel_cmd += "FROM iModule ";
        sel_cmd += "WHERE ModuleStatus = 0 AND (CarrierCode NOT IN (0,99,98))";
        //sel_cmd += "WHERE CarrierCode = '" + CarrierCode + "' AND ModuleStatus = 0";
        //sel_cmd += "or CarrierCode = '0' ";
        ds = Odj.ReadData("DefaultConn", sel_cmd);
        PopulateTreeView((DataTable)ds.Tables[0]);
    }
    public void PopulateTreeView(DataTable dt)
    {
        int iCount = dt.Rows.Count;
        TreeNode ModuleList = new TreeNode();
        Collection<TreeNode> AllNode = new Collection<TreeNode>();
        TreeNode finalNode = new TreeNode();
        Collection<string> nodeID = new Collection<string>();

        for (int icount = 0; icount < dt.Rows.Count; icount++)
        {
            TreeNode CurNode = new TreeNode(dt.Rows[icount]["ResDsc"].ToString(), dt.Rows[icount]["ModuleID"].ToString());
            CurNode.NavigateUrl = "javascript:void(0)";
            AllNode.Add(CurNode);
            nodeID.Add(dt.Rows[icount]["ModuleID"].ToString());

            if (dt.Rows[icount]["AccessStatus"].ToString() == "1")
            { CurNode.Checked = true; }
            else { CurNode.Checked = false; }
        }

        TrVModule.Nodes.Clear();
        for (int icount = 0; icount < dt.Rows.Count; icount++)
        {
            TreeNode CurNode = AllNode[nodeID.IndexOf(dt.Rows[icount]["ModuleID"].ToString())];
            CurNode.NavigateUrl = "javascript:void(0)";
            if (dt.Rows[icount]["ParentModuleID"].ToString() != "")
                AllNode[nodeID.IndexOf(dt.Rows[icount]["ParentModuleID"].ToString())].ChildNodes.Add(CurNode);
            else
                TrVModule.Nodes.Add(CurNode);
        }
        //TrVModule.CollapseAll();
        TrVModule.ExpandAll();
        TrVModule.Attributes.Add("onclick", "OnTreeClick(event)");

    }
    void DisplayChildNodeText(TreeNode node)
    {
        string strSQL;
        int chkstatus;
        DataSet ds1;
        string strCarrierCode;

        // save the node's value.
        if (node.Checked == true)
        { chkstatus = 1; }
        else { chkstatus = 0; }

        //strCarrierCode = oDP.DLookup("DefaultConn", "CarrierCode", "iModule", "ModuleId=" + node.Value);
        //strSQL = "Select * from iUsrGrpSu where (CarrierCode = " + strCarrierCode + " or CarrierCode = " + lblUGCC.Text + " ) and UserGroupCode='" + lblUGID.Text + "' and ModuleID=" + node.Value;
        strSQL = "Select * from iUsrGrpSu where UserGroupCode='" + lblUGID.Text + "' and ModuleID=" + node.Value;

        ds1 = oDP.ReadData("DefaultConn", strSQL);
        if (ds1.Tables[0].Rows.Count == 0)
        {
            if (chkstatus == 1)
            {   //insert check status
                //strSQL = "INSERT INTO [iUsrGrpSu] (UserGroupCode, UserGroupName, ModuleID, AccessStatus,AccessFor)";
                //strSQL += "VALUES ('" + lblUGID.Text + "','" + lblUGName.Text + "'," + node.Value + "," + chkstatus + ",'"+lblAccessFor.Text+"')";
                //oDP.WriteData("DefaultConn", strSQL);

                htParam.Clear();
                dsResult = null;
                htParam.Add("@UserGroupCode", lblUGID.Text);
                htParam.Add("@UserGroupName", lblUGName.Text);
                htParam.Add("@ModuleID", node.Value);
                htParam.Add("@AccessStatus", chkstatus);
                htParam.Add("@AccessFor", lblAccessFor.Text);
                dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_InsDataforUsrGrpSU", htParam);
            }
        }
        else
        {
            if (chkstatus == 0)
            {
                //delete uncheck status
                strSQL = "delete from iUsrGrpSu where UserGroupCode='" + lblUGID.Text + "' and ModuleID=" + node.Value;
                oDP.WriteData("DefaultConn", strSQL);
            }

        }
        // Iterate through the child nodes of the parent node passed into
        // this method and display their values.
        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            // Recursively call the DisplayChildNodeText method to
            // traverse the tree and display all the child nodes.
            DisplayChildNodeText(node.ChildNodes[i]);
        }
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        mv1.ActiveViewIndex = 1;
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Provider o = new Provider();

        //insert new module template

        TextBox txtNewGrpCode = (TextBox)DetailsView1.FindControl("txtNewGrpCode");
        TextBox txtNewGrpNm = (TextBox)DetailsView1.FindControl("txtNewGrpNm");
        //Added by Ramesh on 15th dec
        DropDownList ddl = (DropDownList)DetailsView1.FindControl("ddlAccessFor");
        if (txtNewGrpCode == null && txtNewGrpNm == null)
        {
            RequiredFieldValidator RFVCarrierCode = (RequiredFieldValidator)DetailsView1.FindControl("RFVCarrierCode");
            RFVCarrierCode.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
            RequiredFieldValidator RFVUserGroupCode = (RequiredFieldValidator)DetailsView1.FindControl("RFVUserGroupCode");
            RFVUserGroupCode.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
            RequiredFieldValidator RFVUserGroupName = (RequiredFieldValidator)DetailsView1.FindControl("RFVUserGroupName");
            RFVUserGroupName.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        }
        else
        {
            string strSQL = "prc_Admin_CheckGroupExist '" + txtNewGrpCode.Text + "'";
            DataSet dsExists = o.ReadData("DefaultConn", strSQL);

            if (dsExists.Tables[0].Rows[0][0].ToString() != "0")
            {
                txtNewGrpCode.Text = "";
                txtNewGrpNm.Text = "";

                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('User Group already exists!');</script>");
                return;
            }

            strSQL = string.Empty;
            strSQL = "INSERT INTO [iUsrGrpSu] (UserGroupCode, UserGroupName, ModuleID, AccessStatus,AccessFor) VALUES ('" + txtNewGrpCode.Text + "','" + txtNewGrpNm.Text + "',0,1,'" + ddl.SelectedItem.Value + "')";
            o.WriteData("DefaultConn", strSQL);

            txtNewGrpCode.Text = "";
            txtNewGrpNm.Text = "";

            mv1.ActiveViewIndex = 0;
            dsExists = null;
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string sSQL = "DELETE FROM iUsrGrpSu where UserGroupCode='" + lblUGID.Text + "'";
        oDP.WriteData("DefaultConn", sSQL);

        for (int icount = 0; icount < TrVModule.Nodes.Count; icount++)
        {
            DisplayChildNodeText(TrVModule.Nodes[icount]);
        }

        //INSERT HOME module
        sSQL = "prc_Adm_CreateUserGroupHome '" + lblUGID.Text + "','" + lblUGName.Text + "','" + lblAccessFor.Text + "'";
        oDP.WriteData("DefaultConn", sSQL);

        string attributes = "display:none;";
        PnlBlocker.Attributes["style"] = attributes;
        //showTemplate.Attributes["style"] = attributes;
        Panel1.Visible = false;

    }
    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
            mv1.ActiveViewIndex = 0;
    }
    private void InitializeControl()
    {
        lblModVer.Text = olng.GetItemDesc("lblModVer.Text");
        lblTitle.Text = olng.GetItemDesc("lblTitle.Text");
        lblTitle2.Text = olng.GetItemDesc("lblTitle2.Text");
        lblModVer2.Text = olng.GetItemDesc("lblModVer2.Text");
        GridView1.Columns[0].HeaderText = olng.GetItemDesc("Gcol1");
        GridView1.Columns[1].HeaderText = olng.GetItemDesc("Gcol2");
        btnUpdate.Text = olng.GetItemDesc("btnUpdate.Text");
        btnClose.Text = olng.GetItemDesc("btnClose.Text");
        btnInsert.Text = olng.GetItemDesc("btnInsert.Text");
        btnClose2.Text = olng.GetItemDesc("btnClose2.Text");
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        GridView gv = sender as GridView;
        if (gv != null)
        {
            if (gv.EditIndex > -1)
            {
                // validation for Grid View

                RequiredFieldValidator RFVCarrierCode2 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RFVCarrierCode2") as RequiredFieldValidator;
                RFVCarrierCode2.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
                RegularExpressionValidator REX1 = gv.Rows[gv.EditIndex].Controls[0].FindControl("RegularExpressionValidator1") as RegularExpressionValidator;
                REX1.ErrorMessage = olng.GetItemDesc("RegularExpressionValidator1.Text");
                LinkButton LinkButton1 = (LinkButton)gv.Rows[gv.EditIndex].Controls[0].FindControl("LinkButton4");
                LinkButton1.Text = olng.GetItemDesc("lblUpdate.Text");
                LinkButton LinkButton2 = (LinkButton)gv.Rows[gv.EditIndex].Controls[0].FindControl("LinkButton5");
                LinkButton2.Text = olng.GetItemDesc("lblCancel.Text");
            }
        }
    }
    protected void DetailsView1_PreRender(object sender, EventArgs e)
    {

        RequiredFieldValidator RFVUserGroupCode = (RequiredFieldValidator)DetailsView1.FindControl("RFVUserGroupCode");
        RFVUserGroupCode.ErrorMessage = olng.GetItemDesc("lblRFV.Text");
        RequiredFieldValidator RFVUserGroupName = (RequiredFieldValidator)DetailsView1.FindControl("RFVUserGroupName");
        RFVUserGroupName.ErrorMessage = olng.GetItemDesc("lblRFV.Text");

        RegularExpressionValidator REX2 = (RegularExpressionValidator)DetailsView1.FindControl("RegularExpressionValidator2");
        REX2.ErrorMessage = olng.GetItemDesc("RegularExpressionValidator1.Text");
        RegularExpressionValidator REX3 = (RegularExpressionValidator)DetailsView1.FindControl("RegularExpressionValidator3");
        REX3.ErrorMessage = olng.GetItemDesc("RegularExpressionValidator1.Text");

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {

        string attributes = "display:none;";
        PnlBlocker.Attributes["style"] = attributes;
        //showTemplate.Attributes["style"] = attributes;
        Panel1.Visible = false;

    }
    protected void btnClose2_Click(object sender, EventArgs e)
    {
        mv1.ActiveViewIndex = 0;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //DropDownList DDL1 = (DropDownList)e.Row.FindControl("DropDownList1");
            //DropDownList DDL2 = (DropDownList)e.Row.FindControl("DropDownList2");
            //oCommon.getDropDown(DDL1, "rulestatus", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
            //oCommon.getDropDown(DDL2, "rulestatus", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
            LinkButton BtnDelete = (LinkButton)e.Row.FindControl("LinkButton5");
            if (BtnDelete != null)
                BtnDelete.Text = olng.GetItemDesc("lblDelete.Text");

            LinkButton BtnEdit = (LinkButton)e.Row.FindControl("LinkButton4");
            if (BtnEdit != null)
            {
                BtnEdit.Text = olng.GetItemDesc("lblEdit.Text");
            }

            LinkButton BtnTemplate = (LinkButton)e.Row.FindControl("LinkButton1");
            if (BtnTemplate != null)
            {
                BtnTemplate.Text = olng.GetItemDesc("lblTemplate.Text");
            }

            Label lblGroupName = (Label)e.Row.FindControl("UserGroupName");

            if (lblGroupName != null)
                BtnDelete.OnClientClick = "return confirm('" + olng.GetItemDesc("alert1").ToString() + " " + lblGroupName.Text + "?');";
        }
    }
    protected void OnRecordDeleting(Object source, SqlDataSourceCommandEventArgs e)
    {
        DataSet ds1 = null;
        string strSQL = "";

        strSQL = "exec prc_Chk_UsrGrpExist '" + e.Command.Parameters[0].Value + "'";
        ds1 = oDP.ReadData("DefaultConn", strSQL);
        if (ds1.Tables[0].Rows.Count != 0)
        {
            // Cancel the delete operation if the checkbox is not checked.
            if (ds1.Tables[0].Rows[0][0].ToString() == "1")
            {
                e.Cancel = true;
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('" + e.Command.Parameters[0].Value + " " + olng.GetItemDesc("alert1") + "');</script>");
            }
        }

        ds1 = null;
    }
    protected void DeleteUserGroup_OnClick()
    {

    }



}
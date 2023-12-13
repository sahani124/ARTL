#region Refrences
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
using Insc.Common.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Insc.Common.Security;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using INSCL.DAL;
using DataAccessClassDAL;
#endregion

public partial class Application_Admin_UsrSu : BaseClass
{
    #region Declaration
    //Object created by Nitin
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    //changed by nitin
    DataAccessClass objDAL = new DataAccessClass();
    CommonFunc oCommon = new CommonFunc();
    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    private Insc.Common.Security.AuthorizationBAL oAut = new Insc.Common.Security.AuthorizationBAL();
    private string mode = string.Empty;
    public string userid = string.Empty;
    public string sUserId;
    private string strUserLangNumNum;
    public const string CONN_LIFE_DATA = "INSCDirectConnectionString";
    private string UserGroupCode;
    public multilingualManager olng;
    SqlDataReader dtRead;
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    DataAccessClass dtAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string strSysType = System.Configuration.ConfigurationManager.AppSettings["SystemType"].ToString();

    #endregion
    #region page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        sUserId = HttpContext.Current.Session["UserID"].ToString();
        strUserLangNumNum = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "UsrSu.aspx", strUserLangNumNum);

        if (txtPwd.Text != "" && txtConfirmPwd.Text != "")
        {
            txtPwd.Attributes.Add("value", txtPwd.Text);
            txtConfirmPwd.Attributes.Add("value", txtConfirmPwd.Text);
        }
        if (!Page.IsPostBack)
        {
            InitateDataTable();
            InitateCustDataTable();
            //btnVerify.Visible = true;
            FillInUserTypeDDL();
            FillExUserTypeDDL();
            FillUserRole();
            InitializeControl();
            //DropDownList2.Items.Insert(0, new ListItem("Select", ""));
            ddlBizSrc.Items.Insert(0, new ListItem("Select", ""));
            ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
            FillDDlBizSrcChnCls();
            oCommon.getDropDown(ddlDept, "usrDept", 1, "", 1);
            ddlDept.Items.Insert(0, new ListItem("Select", "Select"));
            if (Request.QueryString["mode"] != null)
                mode = Request.QueryString["mode"].ToString();
            else
                mode = "new";

            if (Request.QueryString["userid"] != null)
                userid = Request.QueryString["userid"].ToString();

            if (mode.Equals("edit"))
            {
                LoadUserDetails();
                lblPwd.Visible = false;
                //spanpwd.Visible = false;//ADDED BY AMIT
                txtPwd.Visible = false;
                lblConfirmPwd.Visible = false;
                //spanconpwd.Visible = false;//ADDED BY AMIT
                txtConfirmPwd.Visible = false;
                btnResetpw.Visible = true;
                lblTitle.Text = "Edit User";
                lblDplUserId.Text = "User ID = " + userid + "";
                linkSave.Enabled = true;
                linkSave.Visible = true;
            }
            else if (mode.Equals("AddRole"))
            {
                LoadUserDetails();
                lblPwd.Visible = false;
                txtPwd.Visible = false;
                txtUserName.Enabled = false;
                txtUserID.Enabled = false;
                txtEmailID.Enabled = false;
                cboStatus.Enabled = false;
                cboLanguage.Enabled = false;
                ddlDept.Enabled = false;
                cboUserRole.Enabled = false;
                rdbInter.Enabled = false;

                lblConfirmPwd.Visible = false;
                txtConfirmPwd.Visible = false;
                btnResetpw.Visible = true;
                lblTitle.Text = "Add User Role";
                lblDplUserId.Text = "User ID = " + userid + "";
                linkSave.Enabled = true;
                linkSave.Visible = true;
                LblRoles.Visible = true;
                if (rdbInter.SelectedValue == "I")
                {
                    ddlInUserType.SelectedIndex = 0;
                    txtSapCode.Text = string.Empty;
                    txtMemberCode.Text = string.Empty;
                }
                else
                {
                    btnFetch.Visible = false;
                    ddlEXUserType.SelectedIndex = 0;
                    txtSapCode.Text = string.Empty;
                    txtMemberCode.Text = string.Empty;
                    ddlBizSrc.SelectedIndex = 0;
                    ddlChnCls.SelectedIndex = 0;
                    ddlUnit.SelectedIndex = 0;
                    txtPrmyMgr.Text = string.Empty;
                    txtAddlMgr1.Text = string.Empty;
                    txtAddlMgr2.Text = string.Empty;
                }

            }
            else
            {
                btnResetpw.Visible = false;
                lblTitle.Text = "Create New User";
                cboStatus.SelectedValue = "0";
            }

            linkClear.Visible = false;
            linkSave.Visible = true;

        }
    }
    #endregion
    #region Initialize Control
    private void InitializeControl()
    {
        //view1
        lblTitle.Text = olng.GetItemDesc("lblTitle.Text");
        lblModVer.Text = "Admin/New User ver4.0";//olng.GetItemDesc("lblModVer.Text");
        L1.Text = olng.GetItemDesc("L1.Text");   //User Details
        //L2.Text = olng.GetItemDesc("L2.Text");   //User Sanctioning
        lblUserName.Text = olng.GetItemDesc("lblUserName.Text");
        lblUserID.Text = olng.GetItemDesc("lblUserID.Text");
        // btnCheckID.Text = olng.GetItemDesc("btnCheckID.Text");
        lblerror.Text = olng.GetItemDesc("lblerror.Text");
        lblPwd.Text = olng.GetItemDesc("lblPwd.Text");
        lblConfirmPwd.Text = olng.GetItemDesc("lblConfirmPwd.Text");
        lblStatus.Text = olng.GetItemDesc("lblStatus.Text");
        //lblLogonName.Text = olng.GetItemDesc("lblLogonName.Text");
        lblLanguage.Text = olng.GetItemDesc("lblLanguage.Text");
        //lblAuthCode.Text = olng.GetItemDesc("lblAuthCode.Text");
        btnResetpw.Text = olng.GetItemDesc("btnResetpw.Text");
        chkIsSysAdmin.Text = olng.GetItemDesc("chkIsSysAdmin.Text");
        chkTimingRestrict.Text = olng.GetItemDesc("chkTimingRestrict.Text");
        btnEditTime.Text = olng.GetItemDesc("btnEditTime.Text");
        chkIsForumModerator.Text = olng.GetItemDesc("chkIsForumModerator.Text");
        chkDownload.Text = olng.GetItemDesc("chkDownload.Text");
        chkLogonLocally.Text = olng.GetItemDesc("chkLogonLocally.Text");

        //view2
        //L21.Text = olng.GetItemDesc("L1.Text");
        //L22.Text = olng.GetItemDesc("L2.Text");
        lblSelectedModule.Text = olng.GetItemDesc("lblSelectedModule.Text");
        btnClose.Text = olng.GetItemDesc("btnCancel.Text");
        //linkSave.Text = olng.GetItemDesc("linkSave.Text");
        //linkCancel.Text = olng.GetItemDesc("btnCancel.Text");

    }
    #endregion
    //protected void GridView1_DataBound(object sender, EventArgs e)
    //{
    //    for (int i = 0; i < GridView1.Rows.Count; i++)
    //    {
    //        LinkButton linkInsert = (LinkButton)GridView1.Rows[i].Cells[0].FindControl("linkInsert");
    //        linkInsert.Text = olng.GetItemDesc("linkInsert.Text");
    //        LinkButton linkPreview = (LinkButton)GridView1.Rows[i].Cells[5].FindControl("linkPreview");
    //        linkPreview.Text = olng.GetItemDesc("linkPreview.Text");
    //    }
    //    if (GridView1.Rows.Count > 0)
    //    {
    //        GridView1.HeaderRow.Cells[0].Text = olng.GetItemDesc("gvHeader0.Text");
    //        GridView1.HeaderRow.Cells[2].Text = olng.GetItemDesc("gvHeader2.Text");
    //        GridView1.HeaderRow.Cells[5].Text = olng.GetItemDesc("linkPreview.Text");
    //    }
    //}
    #region Load Dataset
    public void LoadDataSet(string Userid, string moduletype, string CarrierCode, string IsSystemAdmin)
    {
        string sel_cmd;
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        Insc.Common.Data.Provider Odj = new Provider();

        string strUserLangNum = HttpContext.Current.Session["UserLangNum"].ToString();

        if (null != IsSystemAdmin && !"".Equals(IsSystemAdmin))
        {
            ds = Odj.ReadData("DefaultConn", "prc_ModuleUsrSu '" + Userid + "','" + CarrierCode + "','" + lblUGID.Text + "','" + strUserLangNum + "','" + moduletype + "','" + IsSystemAdmin + "'");
        }
        else
        {
            ds = Odj.ReadData("DefaultConn", "prc_ModuleUsrSu '" + Userid + "','" + CarrierCode + "','" + lblUGID.Text + "','" + strUserLangNum + "','" + moduletype + "',''");
        }
        //select module where CarrierCode belong 0 and itself
        if (null != lblUGID.Text && !"".Equals(lblUGID.Text))
        {
            //sel_cmd = "SELECT iModule.ModuleID, iModule.ModuleCode, iModule.ModuleName" + strUserLangNum + " ResDsc, iModule.ParentModuleID, ISNULL ((SELECT  AccessStatus FROM iUsrGrpSu WHERE ";
            //sel_cmd += "(UserGroupName = '" + lblUGName.Text + "') AND (ModuleID = iModule.ModuleID) AND (CarrierCode = " + lblUGCC.Text + ")), 0) AS AccessStatus ";
            //sel_cmd += "FROM iModule ";
            ////sel_cmd += "WHERE CarrierCode = " + lblUGCC.Text + " ";
            ////sel_cmd += "or CarrierCode = '0' ";
            //sel_cmd += "WHERE ";
            //sel_cmd += " iModule.ModuleID in ('10001','7000') or ";
            //sel_cmd += " iModule.ParentModuleID in ('10001','10002','10002','10002') ";

            sel_cmd = "pri_ModuleAccessMatrix '" + strUserLangNum + "','" + lblUGName.Text + "','" + lblUGCC.Text + "'";
            dss = Odj.ReadData("DefaultConn", sel_cmd);
        }

        if (moduletype == "Template")
        {
            //preview the tree view
            PopulateModuleTreeView((DataTable)dss.Tables[0]);
        }
        else
        {
            //load the tree view
            PopulateTreeView((DataTable)ds.Tables[0]);
        }
    }
    #endregion
    #region Populate TreeView
    public void PopulateModuleTreeView(DataTable dt)
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

            if (dt.Rows[icount]["AccessStatus"].ToString() != "0")
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

        TrVModule.ExpandAll();
        TrVModule.Attributes.Add("onclick", "OnTreeClick(event)");
        DataTable dtt = null;
        string UserGroupGrp = null;

        //select all the user group have been selected
        if (Request.QueryString["userid"] != null)
        {
            userid = Request.QueryString["userid"].ToString();

            string strSQL = "SELECT Distinct UserGroupCode FROM iUserGrpAcs b left join iModule  on (b.ModuleID = iModule.ModuleID)";
            strSQL += " WHERE (UserId = '" + userid + "')";

            DataSet ds1 = oDP.ReadData("DefaultConn", strSQL);
            dtt = ds1.Tables[0];
        }

        for (int icount = 0; icount < dtt.Rows.Count; icount++)
        {
            UserGroupGrp += dtt.Rows[icount]["UserGroupCode"].ToString() + ";";
        }
        lblUserGroupGrp.Text = UserGroupGrp;
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

            if (dt.Rows[icount]["AccessStatus"].ToString() != "0")
            { CurNode.Checked = true; }
            else { CurNode.Checked = false; }
        }

        TrVUser.Nodes.Clear();
        for (int icount = 0; icount < dt.Rows.Count; icount++)
        {
            TreeNode CurNode = AllNode[nodeID.IndexOf(dt.Rows[icount]["ModuleID"].ToString())];
            CurNode.NavigateUrl = "javascript:void(0)";
            if (dt.Rows[icount]["ParentModuleID"].ToString() != "")
                AllNode[nodeID.IndexOf(dt.Rows[icount]["ParentModuleID"].ToString())].ChildNodes.Add(CurNode);
            else
                TrVUser.Nodes.Add(CurNode);
        }

        TrVUser.ExpandAll();
        TrVUser.Attributes.Add("onclick", "OnTreeClick(event)");

        DataTable dtt = null;
        string UserGroupGrp = null;

        //select all the user group have been selected
        if (Request.QueryString["userid"] != null)
        {
            userid = Request.QueryString["userid"].ToString();
            // Modified By Sandeep Garg to convert inline query to procedure start

            //string strSQL = "SELECT Distinct UserGroupCode FROM iUserGrpAcs b left join iModule  on (b.ModuleID = iModule.ModuleID)";
            //strSQL += " WHERE (UserId = '" + userid + "')";

            string strSQL = "Prc_GetUserGroupCode '" + userid + "'";

            // Modified By Sandeep Garg to convert inline query to procedure End

            DataSet ds1 = oDP.ReadData("DefaultConn", strSQL);
            dtt = ds1.Tables[0];
        }

        for (int icount = 0; icount < dtt.Rows.Count; icount++)
        {
            UserGroupGrp += dtt.Rows[icount]["UserGroupCode"].ToString() + ";";
        }
        lblUserGroupGrp.Text = UserGroupGrp;
    }
    void DisplayChildNodeText(TreeNode node, string userid)
    {
        string strSQL;
        int chkstatus;
        DataSet ds1;

        if (node.Checked == true)
        { chkstatus = 1; }
        else { chkstatus = 0; }
        strSQL = "Prc_GetDtlsfromiUsrGrpAcs '','" + node.Value + "','" + userid + "'";
        //strSQL = "Select * from iUserGrpAcs where ModuleID=" + node.Value + " AND userid='" + userid + "'";

        ds1 = oDP.ReadData("DefaultConn", strSQL);
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables[0].Rows.Count == 0)
            {
                if (chkstatus == 1)
                {
                    //insert checked status
                    string strCarrierCode = oDP.DLookup("DefaultConn", "Carriercode", "iModule", "ModuleId=" + node.Value);
                    //strSQL = "INSERT INTO [iUserGrpAcs] (UserGroupCode, UserGroupName, CarrierCode, ModuleID, server1,Access,userid)";
                    //strSQL += "VALUES ('Home','Home','" + strCarrierCode + "'," + node.Value + ",'True','True', '" + userid + "')";
                    strSQL = "Prc_InsDtlsiUserGrpAcs'Home','Home','" + strCarrierCode + "','" + node.Value + "','" + userid + "'";

                    oDP.WriteData("DefaultConn", strSQL);
                }
            }
            else
            {
                if (chkstatus == 0)
                {
                    //delete unchecked status
                    //strSQL = "delete from iUserGrpAcs where ModuleID=" + node.Value + " AND userid='" + userid + "'";
                    strSQL = "Prc_DelFromIUserGrpAcs '" + userid + "' , '' , '' , '" + node.Value + "'";
                    oDP.WriteData("DefaultConn", strSQL);
                }
            }
        }

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            DisplayChildNodeText(node.ChildNodes[i], userid);
        }
    }
    #endregion
    #region On Click Events
    protected void linkClear_Click(object sender, EventArgs e)
    {
        userid = Request.QueryString["userid"].ToString();

        //remove all the user group template
        if (null != userid && !"".Equals(userid))
        {
            string strSQL = "Prc_DelFromIUserGrpAcs'" + userid + "'";
            oDP.WriteData("DefaultConn", strSQL);
        }

        LoadDataSet("", "", "", "");
        MultiView1.ActiveViewIndex = 1;
    }
    protected void linkSave_Click(object sender, EventArgs e)
    {
        //added by AshishP 06-04-2018
        if (rdbAuthType.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please Select Authentication Type');", true);
            return;
        }
        //added by AshishP 06-04-2018

        if (cboUserRole.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please Select UserType');", true);
            return;
        }
        if (ddlDept.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please Select Deapartment');", true);
            return;
        }
        if (Request.QueryString["mode"] == null)
        {
            DataSet ds1 = oDP.ReadData("DefaultConn", "Prc_GetFromiUser'" + txtUserID.Text + "'");
            if (ds1.Tables[0].Rows.Count == 0)
            {
                if (txtPwd.Text == txtConfirmPwd.Text)
                {
                    string pwlength = oDP.DLookup("DefaultConn", "paramvalue", "iSystemParam", "paramcode='maxPINLength'");
                    if (oAut.IsValidPasswordLength(txtPwd.Text) == 1)
                    {
                        if (oAut.IsValidPasswordComposition(txtPwd.Text) == 0)
                        {
                            AdminUser.User objUser = new AdminUser.User();
                            AdminUser.User objUser1 = new AdminUser.User();
                            AdminUser.User objUser2 = new AdminUser.User();
                            objUser.UserName = txtUserName.Text.Replace("'", "''");
                            objUser.UserPIN = UserSetup.UserSetupBAL.GetEncryptedPwd(txtPwd.Text);
                            objUser.UserStatus = int.Parse(cboStatus.SelectedValue.ToString());
                            objUser.UserId = txtUserID.Text;
                            objUser.LanguageNum = cboLanguage.SelectedValue.ToString();
                            objUser.IsSystemAdmin = chkIsSysAdmin.Checked;
                            objUser.IsDiscussAdmin = chkIsForumModerator.Checked;
                            objUser.RestrictAccess = chkTimingRestrict.Checked;
                            objUser.RestrictDownload = chkDownload.Checked;
                            objUser.UserStatus = int.Parse(cboStatus.SelectedValue.ToString());
                            objUser.UserType = rdbInter.SelectedValue;
                            objUser.MemberRole = ddlMemberRole.SelectedValue;
                            objUser.CreatedBy = HttpContext.Current.Session["UserID"].ToString();
                            objUser.CreateDte = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"); //added by Arjun
                            objUser.ORG_Dept = ddlDept.SelectedItem.ToString();//added by arjun
                            objUser.UserRoleCode = cboUserRole.SelectedValue.ToString();
                            objUser.EmailID = txtEmailID.Text.ToString();
                            objUser.AuthType = rdbAuthType.SelectedValue; //added by AshishP 06-04-2018

                            if (dgDetails.Rows.Count > 0)
                            {
                                Label lblUserIdCode = (Label)dgDetails.Rows[0].FindControl("lblUnitCode");
                                objUser.UserIdCode = lblUserIdCode.Text.ToString();
                            }
                            if (dgDetails.Rows.Count > 0)
                            {
                                for (int RowCount = 0; RowCount < dgDetails.Rows.Count; RowCount++)
                                {
                                    Label lblEmpCode = (Label)dgDetails.Rows[RowCount].FindControl("lblEmpCode");
                                    Label lblMemberCode = (Label)dgDetails.Rows[RowCount].FindControl("lblMemberCode");
                                    Label lblAgentType = (Label)dgDetails.Rows[RowCount].FindControl("lblAgentType");
                                    Label lblUnitType = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitType");
                                    Label lblBizSrc = (Label)dgDetails.Rows[RowCount].FindControl("lblBizSrc");
                                    Label lblChnCls = (Label)dgDetails.Rows[RowCount].FindControl("lblChnCls");
                                    Label lblUnitCode = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitCode");
                                    Label lblPrmyMgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblPrmyMgrCode");
                                    Label lblAddl1MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl1MgrCode");
                                    Label lblAddl2MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl2MgrCode");

                                    objUser1.UserId = txtUserID.Text;
                                    objUser1.MemberRole = ddlMemberRole.SelectedValue;
                                    if (chkInclusive.Checked == true)
                                    {
                                        objUser1.ChkInclusive = "1";
                                    }
                                    else
                                    {
                                        objUser1.ChkInclusive = "0";
                                    }
                                    objUser1.UserType = rdbInter.SelectedValue.ToString().Trim();
                                    objUser1.EmpCode = lblEmpCode.Text.ToString();
                                    objUser1.MemberCode = lblMemberCode.Text.ToString();
                                    objUser1.AgentType = lblAgentType.Text.ToString();
                                    objUser1.UnitType = lblUnitType.Text.ToString();
                                    objUser1.BizSrc = lblBizSrc.Text.ToString();
                                    objUser1.ChnCls = lblChnCls.Text.ToString();
                                    objUser1.UnitCode = lblUnitCode.Text.ToString();
                                    objUser1.PrmyMgrCode = lblPrmyMgrCode.Text.ToString().Trim();
                                    objUser1.Addl1MgrCode = lblAddl1MgrCode.Text.ToString().Trim();
                                    objUser1.Addl2MgrCode = lblAddl2MgrCode.Text.ToString().Trim();
                                    int i1 = AdminUser.AdminBAL.AddUserDtlsInMapExt(objUser1);
                                }
                            }
                            if (gvCustDtls.Rows.Count > 0)
                            {

                                for (int RowCount = 0; RowCount < gvCustDtls.Rows.Count; RowCount++)
                                {
                                    Label lblCustID = (Label)gvCustDtls.Rows[RowCount].FindControl("lblCustID");
                                    Label lblSrvcAgt = (Label)gvCustDtls.Rows[RowCount].FindControl("lblSrvcAgt");
                                    Label lblMobileNo = (Label)gvCustDtls.Rows[RowCount].FindControl("lblMobileNo");

                                    objUser2.UserId = txtUserID.Text;
                                    objUser2.MemberRole = ddlMemberRole.SelectedValue;
                                    objUser2.EmailID = txtEmailID.Text.ToString();
                                    objUser2.UserType = rdbInter.SelectedValue.ToString().Trim();
                                    objUser2.CustomerID = lblCustID.Text.ToString().Trim();
                                    objUser2.ServicingAgent = lblSrvcAgt.Text.ToString().Trim();
                                    objUser2.MobileNo = lblMobileNo.Text.ToString().Trim();
                                    int i1 = AdminUser.AdminBAL.AddUserDtlsInCustMapExt(objUser2);
                                }


                            }
                            int i = AdminUser.AdminBAL.AddNewUser(objUser);
                            string strUpdEmpSQL = "Prc_UpdEmpInIuser'" + txtUserID.Text + "'";
                            oDP.WriteData("DefaultConn", strUpdEmpSQL);
                            Response.Redirect("~/Application/Admin/UsrSu.aspx?mode=edit&userid=" + txtUserID.Text);
                        }
                        //Password must contain numbers and alphabet characters
                        else { ClientScript.RegisterStartupScript(this.GetType(), "startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert1") + "');</script>"); }
                    }
                    //Password must be more than 6 characters and not more than 12 characters
                    else { ClientScript.RegisterStartupScript(this.GetType(), "startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert2") + "');</script>"); }
                }
                //Password does not match
                else { ClientScript.RegisterStartupScript(this.GetType(), "startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert3") + "');</script>"); }
            }
            //User ID exist
            else { ClientScript.RegisterStartupScript(this.GetType(), "startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("lblerror.Text") + "');</script>"); }
        }
        else if (Request.QueryString["mode"] == "AddRole")
        {
            AdminUser.User objUser1 = new AdminUser.User();
            if (dgDetails.Rows.Count > 0)
            {
                for (int RowCount = 0; RowCount < dgDetails.Rows.Count; RowCount++)
                {
                    Label lblEmpCode = (Label)dgDetails.Rows[RowCount].FindControl("lblEmpCode");
                    Label lblMemberCode = (Label)dgDetails.Rows[RowCount].FindControl("lblMemberCode");
                    Label lblAgentType = (Label)dgDetails.Rows[RowCount].FindControl("lblAgentType");
                    Label lblUnitType = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitType");
                    Label lblBizSrc = (Label)dgDetails.Rows[RowCount].FindControl("lblBizSrc");
                    Label lblChnCls = (Label)dgDetails.Rows[RowCount].FindControl("lblChnCls");
                    Label lblUnitCode = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitCode");
                    Label lblPrmyMgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblPrmyMgrCode");
                    Label lblAddl1MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl1MgrCode");
                    Label lblAddl2MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl2MgrCode");

                    objUser1.UserId = txtUserID.Text;

                    objUser1.UserType = rdbInter.SelectedValue.ToString().Trim();
                    objUser1.EmpCode = lblEmpCode.Text.ToString();
                    objUser1.MemberCode = lblMemberCode.Text.ToString().Trim();
                    objUser1.AgentType = lblAgentType.Text.ToString();
                    objUser1.UnitType = lblUnitType.Text.ToString();
                    objUser1.BizSrc = lblBizSrc.Text.ToString();
                    objUser1.ChnCls = lblChnCls.Text.ToString();
                    objUser1.UnitCode = lblUnitCode.Text.ToString();
                    objUser1.PrmyMgrCode = lblPrmyMgrCode.Text.ToString().Trim();
                    objUser1.Addl1MgrCode = lblAddl1MgrCode.Text.ToString().Trim();
                    objUser1.Addl2MgrCode = lblAddl2MgrCode.Text.ToString().Trim();
                    objUser1.MemberRole = ddlMemberRole.SelectedValue;
                    int i1 = AdminUser.AdminBAL.AddUserDtlsInMapExt(objUser1);
                    //linkSave.Enabled = false;
                }
            }
        }
        else
        {
            //Added By sandeep garg start
            htParam.Clear();
            htParam.Add("@UserID", txtUserID.Text);
            htParam.Add("@UserName", txtUserName.Text.Replace("'", "''"));
            htParam.Add("@UserStatus", int.Parse(cboStatus.SelectedValue.ToString()));
            htParam.Add("@UserType", rdbInter.SelectedValue.ToString());
            htParam.Add("@MemberRole", ddlMemberRole.SelectedValue.ToString());
            htParam.Add("@LanguageNum", cboLanguage.SelectedValue.ToString());
            htParam.Add("@IsSystemAdmin", chkIsSysAdmin.Checked);
            htParam.Add("@IsDiscussAdmin", chkIsForumModerator.Checked);
            htParam.Add("@RestrictAccess", chkTimingRestrict.Checked);
            htParam.Add("@RestrictDownload", chkDownload.Checked);
            htParam.Add("@OrgDept", ddlDept.SelectedItem.ToString());
            htParam.Add("@UserRoleCode", cboUserRole.SelectedValue.ToString());
            if (dgDetails.Rows.Count > 0)
            {
                Label lblUserIdCode = (Label)dgDetails.Rows[0].FindControl("lblUnitCode");
                htParam.Add("@UserIdCode", lblUserIdCode.Text);
            }
            else
            {
                htParam.Add("@UserIdCode", "");
            }
            htParam.Add("@UserEmailId", txtEmailID.Text);
            htParam.Add("@AuthType", rdbAuthType.SelectedValue);//Added by AshishP 06-04-2018
            dsResult = null;
            dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_UpdateiUser", htParam);
            //Added By sandeep garg END
            if (Request.QueryString["userid"] != null)
            {
                for (int icount = 0; icount < TrVUser.Nodes.Count; icount++)
                {
                    DisplayChildNodeText(TrVUser.Nodes[icount], Request.QueryString["userid"].ToString());
                }
            }

            AdminUser.User objUser1 = new AdminUser.User();
            AdminUser.User objUser2 = new AdminUser.User();
            if (dgDetails.Rows.Count > 0)
            {
                htParam.Clear();
                dsResult = null;
                htParam.Add("@UserId", txtUserID.Text.ToString().Trim());
                dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_DelFromMapExt", htParam);
                for (int RowCount = 0; RowCount < dgDetails.Rows.Count; RowCount++)
                {
                    Label lblEmpCode = (Label)dgDetails.Rows[RowCount].FindControl("lblEmpCode");
                    Label lblMemberCode = (Label)dgDetails.Rows[RowCount].FindControl("lblMemberCode");
                    Label lblAgentType = (Label)dgDetails.Rows[RowCount].FindControl("lblAgentType");
                    Label lblUnitType = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitType");
                    Label lblBizSrc = (Label)dgDetails.Rows[RowCount].FindControl("lblBizSrc");
                    Label lblChnCls = (Label)dgDetails.Rows[RowCount].FindControl("lblChnCls");
                    Label lblUnitCode = (Label)dgDetails.Rows[RowCount].FindControl("lblUnitCode");
                    Label lblPrmyMgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblPrmyMgrCode");
                    Label lblAddl1MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl1MgrCode");
                    Label lblAddl2MgrCode = (Label)dgDetails.Rows[RowCount].FindControl("lblAddl2MgrCode");

                    objUser1.UserId = txtUserID.Text;
                    objUser1.UserType = rdbInter.SelectedValue.ToString().Trim();
                    objUser1.EmpCode = lblEmpCode.Text.ToString();
                    objUser1.MemberCode = lblMemberCode.Text.ToString().Trim();
                    objUser1.AgentType = lblAgentType.Text.ToString();
                    objUser1.UnitType = lblUnitType.Text.ToString();
                    objUser1.BizSrc = lblBizSrc.Text.ToString();
                    objUser1.ChnCls = lblChnCls.Text.ToString();
                    objUser1.UnitCode = lblUnitCode.Text.ToString();
                    objUser1.PrmyMgrCode = lblPrmyMgrCode.Text.ToString().Trim();
                    objUser1.Addl1MgrCode = lblAddl1MgrCode.Text.ToString().Trim();
                    objUser1.Addl2MgrCode = lblAddl2MgrCode.Text.ToString().Trim();
                    if (chkInclusive.Checked == true)
                    {
                        objUser1.ChkInclusive = "1";
                    }
                    else
                    {
                        objUser1.ChkInclusive = "0";
                    }
                    objUser1.MemberRole = ddlMemberRole.SelectedValue;
                    int i1 = AdminUser.AdminBAL.UpdateUserDtlsInMapExt(objUser1);
                    //linkSave.Enabled = false;
                }
            }
            if (gvCustDtls.Rows.Count > 0)
            {
                htParam.Clear();
                dsResult = null;
                htParam.Add("@UserId", txtUserID.Text.ToString().Trim());
                dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_DelFromCustMapExt", htParam);

                for (int RowCount = 0; RowCount < gvCustDtls.Rows.Count; RowCount++)
                {
                    Label lblCustID = (Label)gvCustDtls.Rows[RowCount].FindControl("lblCustID");
                    Label lblSrvcAgt = (Label)gvCustDtls.Rows[RowCount].FindControl("lblSrvcAgt");
                    Label lblMobileNo = (Label)gvCustDtls.Rows[RowCount].FindControl("lblMobileNo");

                    objUser2.UserId = txtUserID.Text;
                    objUser2.MemberRole = ddlMemberRole.SelectedValue;
                    objUser2.EmailID = txtEmailID.Text.ToString();
                    objUser2.UserType = rdbInter.SelectedValue.ToString().Trim();
                    objUser2.CustomerID = lblCustID.Text.ToString().Trim();
                    objUser2.ServicingAgent = lblSrvcAgt.Text.ToString().Trim();
                    objUser2.MobileNo = lblMobileNo.Text.ToString().Trim();
                    int i1 = AdminUser.AdminBAL.UpdateUserDtlsInCustMapExt(objUser2);
                }
            }
        }
    }
    protected void linkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/Admin/SearchUser.aspx");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        lblUGID.Text = "";
        string attributes = "display:none;";
        PnlBlocker.Attributes["style"] = attributes;
        Panel2.Visible = false;
        //showTemplate1.Attributes["style"] = attributes;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["userid"] != null)
        {
            for (int icount = 0; icount < TrVModule.Nodes.Count; icount++)
            {
                DisplayChildNodeText(TrVModule.Nodes[icount], Request.QueryString["userid"].ToString());
            }
        }
    }
    protected void btnResetpw_Click(object sender, EventArgs e)
    {
        //reset the password
        string ResetPW = oDP.DLookup("DefaultConn", "paramvalue", "iSystemparam", "ParamCode='ResetPW'");
        UserSetup.UserSetupDAL.UpdatePwd(ResetPW, txtUserID.Text);
        UserSetup.UserSetupDAL.UpdatePwdLog(ResetPW, txtUserID.Text);
        //string strSQL = "update iUser set userstatus=1 where userid='" + txtUserID.Text + "'";
        // oDP.WriteData("DefaultConn", strSQL);
        ClientScript.RegisterStartupScript(this.GetType(), "startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert5") + "');</script>");
    }
    protected void btnCheckID_Click(object sender, EventArgs e)
    {
        //check the existing user id
        //string strSQL = "Select * from iUser where userid = '" + txtUserID.Text + "'";
        string strSQL = "Prc_GetFromiUser'" + txtUserID.Text + "'";

        DataSet ds1 = oDP.ReadData("DefaultConn", strSQL);
        if (ds1.Tables[0].Rows.Count != 0)
        {
            lblerror.Text = olng.GetItemDesc("lblerror.Text");
            lblerror.Visible = true;
            lblSuccess.Visible = false;
        }
        else
        {
            lblSuccess.Visible = true;
            lblSuccess.Text = "valid ID";
            lblerror.Visible = false;
        }
    }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        if (txtMemberCode.Text != "" && txtMemberCode.Text != null)
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgentCode", txtMemberCode.Text.ToString().Trim());
            htParam.Add("@Flag", "3");
            dsResult = dtAccess.GetDataSetForPrcCLP("Prc_GetBizSrcChnCls", htParam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                dgDetails.DataSource = dsResult;
                dgDetails.DataBind();
                trGrid.Visible = true;
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member Does not exist');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please enter Member Code');", true);
        }
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        if (txtSapCode.Text != "" && txtSapCode.Text != null)
        {
            htParam.Clear();
            dsResult = null;
            htParam.Add("@AgentCode", txtSapCode.Text.ToString().Trim());
            htParam.Add("@Flag", "2");
            dsResult = dtAccess.GetDataSetForPrcCLP("Prc_GetBizSrcChnCls", htParam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ViewState["GridData"] = dsResult.Tables[0];
                dgDetails.DataSource = dsResult;
                dgDetails.DataBind();
                trGrid.Visible = true;
                trHierarchy.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Employee Does not exist');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please enter Emp Code');", true);
        }
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["GridData"];
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        dt.Rows.RemoveAt(row.RowIndex);
        ViewState["DT"] = dt;
        ViewState["GridData"] = dt;
        dgDetails.DataSource = dt;
        dgDetails.DataBind();
    }
    #endregion
    #region Multi View Click
    protected void v1_click(object sender, EventArgs e)
    {
        //preview the user detail
        linkClear.Visible = false;
        // linkSave.Visible = true;
        MultiView1.ActiveViewIndex = 0;
    }
    protected void v3_click(object sender, EventArgs e)
    {
        //preview the user detail
        //linkClear.Visible = false;
        // linkSave.Visible = true;
        L3.Visible = true; //ADDED BY AMIT
        L1.Visible = false;//ADDED BY AMIT
        if (Request.QueryString["mode"] != null)
        {
            DataSet ds = new DataSet();
            Insc.Common.Data.Provider Odj = new Provider();
            UserGroupCode = cboUserRole.SelectedValue;
            string strUserLangNum = HttpContext.Current.Session["UserLangNum"].ToString();


            if (Request.QueryString["mode"] != null)
            {
                string userid = Request.QueryString["userid"].ToString();

                string strSQL = "Prc_GetFromiUser'" + userid + "'";

                DataSet dss = oDP.ReadData("DefaultConn", strSQL);
                DataTable dtt = dss.Tables[0];
                Boolean isSystemAdmin = Boolean.Parse(dtt.Rows[0]["IsSystemAdmin"].ToString());

                if (isSystemAdmin)
                {
                    //SqlDataSource3.SelectCommand = "SELECT DISTINCT CarrierCode, UserGroupCode, UserGroupName, AccessStatus FROM iUsrGrpSu order by carriercode";
                    LoadDataSet(userid, "", "", "true");
                }
                else
                {
                    //SqlDataSource3.SelectCommand = "SELECT DISTINCT CarrierCode, UserGroupCode, UserGroupName, AccessStatus FROM iUsrGrpSu where CarrierCode <> '99'  order by carriercode";
                    LoadDataSet(userid, "", "", "");
                }

                MultiView1.ActiveViewIndex = 1;
                linkClear.Visible = true;
                // linkSave.Visible = false;
            }
            //Please create new user first.
            else
            {
                RegisterStartupScript("startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert4") + "');</script>");
            }
        }
        else
        {
            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert4") + "');</script>");
        }
    }
    protected void v2_click(object sender, EventArgs e)
    {
        //preview the user sanctioning
        if (Request.QueryString["mode"] != null)
        {
            string userid = Request.QueryString["userid"].ToString();

            string strSQL = "Prc_GetFromiUser'" + userid + "'";

            DataSet dss = oDP.ReadData("DefaultConn", strSQL);
            DataTable dtt = dss.Tables[0];
            Boolean isSystemAdmin = Boolean.Parse(dtt.Rows[0]["IsSystemAdmin"].ToString());

            if (isSystemAdmin)
            {
                //SqlDataSource3.SelectCommand = "SELECT DISTINCT CarrierCode, UserGroupCode, UserGroupName, AccessStatus FROM iUsrGrpSu order by carriercode";
                LoadDataSet(userid, "", "", "true");
            }
            else
            {
                //SqlDataSource3.SelectCommand = "SELECT DISTINCT CarrierCode, UserGroupCode, UserGroupName, AccessStatus FROM iUsrGrpSu where CarrierCode <> '99'  order by carriercode";
                LoadDataSet(userid, "", "", "");
            }

            MultiView1.ActiveViewIndex = 1;
            linkClear.Visible = true;
            // linkSave.Visible = false;
        }
        //Please create new user first.
        else
        {
            RegisterStartupScript("startupScript", "<script language=JavaScript>alert('" + olng.GetItemDesc("Alert4") + "');</script>");
        }
    }
    #endregion
    #region Row Data Bound & Row Command Event
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string moduleGroupList = lblUserGroupGrp.Text;

        switch (e.CommandName.ToLower())
        {
            //preview Module Access Matrix for User Group
            case ("template"):
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label UserGroupCode = (Label)row.FindControl("UserGroupCode");
                Label UserGroupName = (Label)row.FindControl("UserGroupName");
                Label UserCarrierCode = (Label)row.FindControl("CarrierCode");
                lblUGID.Text = UserGroupCode.Text;
                lblUGName.Text = UserGroupName.Text;
                lblUGCC.Text = UserCarrierCode.Text;
                title.InnerText = "Module Access Matrix for User Group " + lblUGID.Text;
                LoadDataSet(UserGroupName.Text, "Template", lblUGCC.Text, "");

                string height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
                string attributes = "z-index: 100; filter: alpha(opacity=40); left: 0px; width: 100%;display:block;";
                attributes += "position: absolute; top: 0px; height: 90%; background-color: #cccccc; moz-opacity: .40;  opacity: .40; font-size: 9pt;";
                PnlBlocker.Attributes["style"] = attributes;

                attributes = "display:block;";
                attributes += " z-index: 101; left: 179pt; width: 350px;  top: 33pt; ";
                attributes += "height: 44px; font-size: 9pt; position: absolute;";
                Panel2.Visible = true;
                //showTemplate1.Attributes["style"] = attributes;
                break;

            //insert User Group into Module Access Matrix
            case ("insert"):
                GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label UserGroupCode1 = (Label)row1.FindControl("UserGroupCode");
                Label UserGroupName1 = (Label)row1.FindControl("UserGroupName");
                Label UserCarrierCode1 = (Label)row1.FindControl("CarrierCode");
                lblUGID.Text = UserGroupCode1.Text;
                lblUGName.Text = UserGroupName1.Text;
                lblUGCC.Text = UserCarrierCode1.Text;

                string userid = Request.QueryString["userid"].ToString();
                string strsql2;
                string CCode;
                //string strSQL = "SELECT UserGroupCode, UserGroupName, CarrierCode, ModuleID, AccessStatus FROM iUsrGrpSu";
                //strSQL += " WHERE (UserGroupCode = '" + UserGroupCode1.Text + "') AND (AccessStatus = 1)";
                string strSQL = "Prc_GetDtlsfromiUsrGrpSu'" + UserGroupCode1.Text + "'";

                DataSet ds1 = oDP.ReadData("DefaultConn", strSQL);
                DataSet ds3;
                DataTable dt = ds1.Tables[0];
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    CCode = oDP.DLookup("DefaultConn", "Carriercode", "iModule", "ModuleId=" + dt.Rows[icount]["moduleid"].ToString());
                    //strsql2 = "Select * from iUserGrpAcs where CarrierCode = " + CCode + " and ModuleID=" + dt.Rows[icount]["moduleid"].ToString() + " AND userid='" + userid + "'";
                    strsql2 = "Prc_GetDtlsfromiUsrGrpAcs '" + CCode + "','" + dt.Rows[icount]["moduleid"].ToString() + "','" + userid + "'";
                    ds3 = oDP.ReadData("DefaultConn", strsql2);
                    if (ds3.Tables[0].Rows.Count == 0)
                    {
                        //strSQL = "INSERT INTO [iUserGrpAcs] (UserGroupCode, UserGroupName, CarrierCode, ModuleID, Server1,Access,userid)";
                        //strSQL += "VALUES ('" + dt.Rows[icount]["UserGroupCode"].ToString() + "','" + dt.Rows[icount]["UserGroupName"].ToString() + "','" + CCode + "'," + dt.Rows[icount]["moduleid"].ToString() + ",'True','True', '" + userid + "')";
                        strSQL = "Prc_InsDtlsiUserGrpAcs'" + dt.Rows[icount]["UserGroupCode"].ToString() + "','" + dt.Rows[icount]["UserGroupName"].ToString() + "','" + CCode + "','" + dt.Rows[icount]["moduleid"].ToString() + "','" + userid + "'";
                        oDP.WriteData("DefaultConn", strSQL);
                    }
                }
                LoadDataSet(userid, "", "", "");
                break;

            //delete seleted User Group
            case ("remove"):
                string temModuleGrp = null;
                string[] moduleGroup = moduleGroupList.Split(';');
                userid = Request.QueryString["userid"].ToString();

                GridViewRow row2 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label UserGroupCode2 = (Label)row2.FindControl("UserGroupCode");
                Label UserGroupName2 = (Label)row2.FindControl("UserGroupName");
                Label UserCarrierCode2 = (Label)row2.FindControl("CarrierCode");
                lblUGID.Text = UserGroupCode2.Text;
                lblUGName.Text = UserGroupName2.Text;
                lblUGCC.Text = UserCarrierCode2.Text;

                if (null != userid && !"".Equals(userid))
                {
                    //strSQL = " DELETE FROM iUserGrpAcs WHERE (UserID = '" + userid + "' AND CarrierCode= '" + UserCarrierCode2 + "' AND UserGroupCode='" + UserGroupCode2 + "')";
                    strSQL = "Prc_DelFromIUserGrpAcs'" + userid + "' ,'" + UserCarrierCode2 + "' ,'" + UserGroupCode2 + "'";
                    oDP.WriteData("DefaultConn", strSQL);
                }

                //insert User Group into Module Access Matrix
                for (int i = 0; i < moduleGroup.Length; i++)
                {
                    if (null != moduleGroup[i] && !"".Equals(moduleGroup[i]) && moduleGroup[i] != UserGroupCode2.Text)
                    {
                        temModuleGrp += moduleGroup[i] + ";";
                        //strSQL = "SELECT UserGroupCode, UserGroupName, CarrierCode, ModuleID, AccessStatus FROM iUsrGrpSu";
                        //strSQL += " WHERE (UserGroupCode = '" + moduleGroup[i] + "') AND (AccessStatus = 1)";
                        strSQL = "Prc_GetDtlsfromiUsrGrpSu'" + moduleGroup[i] + "'";
                        ds1 = oDP.ReadData("DefaultConn", strSQL);

                        dt = ds1.Tables[0];
                        for (int icount = 0; icount < dt.Rows.Count; icount++)
                        {
                            CCode = oDP.DLookup("DefaultConn", "Carriercode", "iModule", "ModuleId=" + dt.Rows[icount]["moduleid"].ToString());
                            //strsql2 = "Select * from iUserGrpAcs where CarrierCode = " + CCode + " and ModuleID=" + dt.Rows[icount]["moduleid"].ToString() + " AND userid='" + userid + "'";
                            strsql2 = "Prc_GetDtlsfromiUsrGrpAcs '" + CCode + "','" + dt.Rows[icount]["moduleid"].ToString() + "','" + userid + "'";

                            ds3 = oDP.ReadData("DefaultConn", strsql2);
                            if (ds3.Tables[0].Rows.Count == 0)
                            {
                                //strSQL = "INSERT INTO [iUserGrpAcs] (UserGroupCode, UserGroupName, CarrierCode, ModuleID, Server1,Access,userid)";
                                //strSQL += "VALUES ('" + dt.Rows[icount]["UserGroupCode"].ToString() + "','" + dt.Rows[icount]["UserGroupName"].ToString() + "','" + CCode + "'," + dt.Rows[icount]["moduleid"].ToString() + ",'True','True', '" + userid + "')";
                                strSQL = "Prc_InsDtlsiUserGrpAcs'" + dt.Rows[icount]["UserGroupCode"].ToString() + "','" + dt.Rows[icount]["UserGroupName"].ToString() + "','" + CCode + "','" + dt.Rows[icount]["moduleid"].ToString() + "','" + userid + "'";
                                oDP.WriteData("DefaultConn", strSQL);
                            }
                        }
                    }
                }
                LoadDataSet(userid, "", "", "");
                lblUserGroupGrp.Text = temModuleGrp;
                break;
        }
    }
    protected void dgSRARights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // HiddenField hf = (HiddenField)e.Row.FindControl("hfValue");
            HtmlInputHidden txtPostTOLA = (HtmlInputHidden)e.Row.FindControl("txtPostTOLA");
            CheckBox chkPostTOLA = (CheckBox)e.Row.FindControl("chkPostTOLA");
            CheckBox chkAccessRight = (CheckBox)e.Row.FindControl("chkAccessRight");
            Label ACC = (Label)e.Row.FindControl("ACC");
            Label AcCPTL = (Label)e.Row.FindControl("AcCPTL");

            if (txtPostTOLA.Value == "False")
            {
                chkPostTOLA.Visible = false;
            }
            if (AcCPTL.Text == "True")
            {
                chkPostTOLA.Checked = true;
            }
            if (ACC.Text == "True")
            {
                chkAccessRight.Checked = true;
            }
        }
    }
    #endregion
    #region Selected Index Changed Events
    protected void rdbInter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbInter.SelectedValue == "E")
        {
            if (strSysType == "BP" || strSysType == "CP")
            {
                FillDllMemberRole(strSysType);
            }
            else
            {
                ddlMemberRole.Items.Clear();
            }
            trHierarchy.Visible = false;
            trGrid.Visible = false;
            ViewState["DT"] = null;
            InitateDataTable();
            txtSapCode.Text = string.Empty;
            txtMemberCode.Text = string.Empty;
        }
        else
        {
            if (strSysType == "BP" || strSysType == "IP")
            {
                FillDllMemberRole(strSysType);
            }
            trHierarchy.Visible = false;
            trCustDtls.Visible = false;
            gvCustDtls = null;
            ViewState["dtCust"] = null;
            InitateCustDataTable();
            txtCustID.Text = string.Empty;
            txtSrvcAgt.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtSapCode.Text = string.Empty;
            txtMemberCode.Text = string.Empty;
            txtPrmyMgr.Text = string.Empty;
            txtAddlMgr1.Text = string.Empty;
            txtAddlMgr2.Text = string.Empty;
            ddlBizSrc.Items.Clear();
            ddlChnCls.Items.Clear();
            ddlUntType.Items.Clear();
            ddlUnit.Items.Clear();
        }
    }
    protected void FillDllMemberRole(string strSysType)
    {
        htParam.Clear();
        htParam.Add("@strSysType", strSysType);
        dsResult = null;
        dsResult = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlMemRole", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlMemberRole.DataSource = dsResult.Tables[0];
            ddlMemberRole.DataTextField = "RoleDesc";
            ddlMemberRole.DataValueField = "RoleCode";
            ddlMemberRole.DataBind();
            ddlMemberRole.Items.Insert(0, new ListItem("Select", ""));

        }

    }
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        objCommonU.GetUnitType(ddlUntType, ddlBizSrc.SelectedValue.ToString(), "UntType", ddlChnCls.SelectedValue.ToString());
        ddlUntType.DataBind();
        ddlUntType.Items.Insert(0, new ListItem("Select", ""));
    }
    protected void ddlBizSrc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@BizSrc", ddlBizSrc.SelectedValue);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_ddlchnnlsubclsforunitmaint", htParam);
            htParam.Clear();
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlChnCls.DataSource = dsResult;
                ddlChnCls.DataTextField = "ChnlDesc";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
                ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
            }
            //lblMsg.Visible = false;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion
    #region Fill Controls Detail
    private void LoadUserDetails()
    {
        AdminUser.User objUser = new AdminUser.User();
        objUser.UserId = userid;
        objUser = AdminUser.AdminBAL.LoadUserDetails(objUser);
        txtUserID.Text = objUser.UserId;
        txtUserName.Text = objUser.UserName;
        rdbAuthType.SelectedValue = objUser.AuthType.ToString();//Added by AshishP 06-04-2018
        //txtLogonName.Text = objUser.UserLoginName;
        rdbInter.SelectedValue = objUser.UserType.ToString();
        if (rdbInter.SelectedValue != null)
        {
            if (rdbInter.SelectedValue == "I")
            {
                FillDllMemberRole(strSysType);
                ddlMemberRole.SelectedValue = objUser.MemberRole.ToString();
                trHierarchy.Visible = true;
                FillUserHierarchyDtls(userid);
                btnFetch_Click(this, EventArgs.Empty);
            }
            else if (rdbInter.SelectedValue == "E")
            {
                FillDllMemberRole(strSysType);
                ddlMemberRole.SelectedValue = objUser.MemberRole.ToString();
                if (ddlMemberRole.SelectedValue == "CONSTF")
                {
                    trGridCustDtls.Visible = true;
                    trHierarchy.Visible = false;
                    FillCustDtls(userid);
                    trCustDtls.Visible = true;
                    InitateCustDataTable();
                    BindAddBtnValue();
                }
                else
                {
                    FillDDlBizSrcChnCls();
                    FillUserHierarchyDtls(userid);
                    trHierarchy.Visible = true;
                    tr1.Visible = true;
                    tr2.Visible = true;
                    tr3.Visible = true;
                    tr4.Visible = true;
                }
            }
        }
        btnVerify.Visible = false;
        btnFetch.Visible = false;
        cboStatus.SelectedValue = objUser.UserStatus.ToString();
        chkIsSysAdmin.Checked = objUser.IsSystemAdmin;
        chkIsForumModerator.Checked = objUser.IsDiscussAdmin;
        chkTimingRestrict.Checked = objUser.RestrictAccess;
        chkDownload.Checked = objUser.RestrictDownload;
        string ORG_Dept = objUser.ORG_Dept.ToString();
        ddlDept.SelectedValue = objUser.ORG_Dept.ToString();
        txtEmailID.Text = objUser.EmailID.ToString();
        cboUserRole.SelectedValue = objUser.UserRoleCode.ToString().Trim();
        UserGroupCode = objUser.UserRoleCode.ToString();
        txtUserID.Enabled = false;
    }
    private void FillUserRole()
    {
        string strSql = string.Empty;
        DataSet dsResult = new DataSet();
        strSql = "select distinct UserGroupCode , UserGroupName from dbo.iUsrGrpSu";

        dsResult = objDAL.GetDataSetWithoutParam(strSql, "DefaultConn");
        if (dsResult.Tables.Count > 0)
        {
            //changed by nitin
            objCommonU.FillDropDown(cboUserRole, dsResult.Tables[0], "UserGroupCode", "UserGroupName");
        }
        dsResult = null;
        strSql = null;
        cboUserRole.Items.Insert(0, new ListItem("Select", ""));
    }
    private void FillDDlBizSrcChnCls()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@ChannelType", "");
        htParam.Add("@Flag", "1");
        dsResult = dtAccess.GetDataSetForPrcCLP("prc_ChnClsSearch", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlBizSrc.DataSource = dsResult;
            ddlBizSrc.DataValueField = "BizSrc";
            ddlBizSrc.DataTextField = "ChannelDesc01";
            ddlBizSrc.DataBind();
            ddlBizSrc.Items.Insert(0, new ListItem("Select", ""));
        }

    }
    private void FillUserHierarchyDtls(string UserID)
    {
        DataSet ds = new DataSet();
        htParam.Clear();
        ds = null;
        htParam.Add("@UserID", UserID);
        ds = dtAccess.GetDataSetForPrc_inscdirect("prc_GetDtlsFrmIuserMapExt", htParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (rdbInter.SelectedValue == "E")
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    txtSapCode.Text = ds.Tables[0].Rows[i]["EmpCode"].ToString();
                    txtMemberCode.Text = ds.Tables[0].Rows[i]["MemberCode"].ToString();
                    FillDDlBizSrcChnCls();
                    ddlBizSrc.SelectedValue = ds.Tables[0].Rows[i]["BizSrc"].ToString();
                    ddlBizSrc_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlChnCls.SelectedValue = ds.Tables[0].Rows[i]["ChnCls"].ToString();
                    ddlChnCls_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlUntType.SelectedValue = ds.Tables[0].Rows[i]["UnitType"].ToString();
                    ddlUntType_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlUnit.SelectedValue = ds.Tables[0].Rows[i]["UnitCode"].ToString();
                    txtPrmyMgr.Text = ds.Tables[0].Rows[i]["PrmyMgrCode"].ToString();
                    txtAddlMgr1.Text = ds.Tables[0].Rows[i]["Addl1MgrCode"].ToString();
                    txtAddlMgr2.Text = ds.Tables[0].Rows[i]["Addl2MgrCode"].ToString();
                    string strInclusive = ds.Tables[0].Rows[i]["isInclusive"].ToString();
                    if (strInclusive == "True")
                    {
                        chkInclusive.Checked = true;
                    }
                    btnAdd_Click(this, EventArgs.Empty);
                }

            }
            else if (rdbInter.SelectedValue == "I")
            {
                txtSapCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                txtMemberCode.Text = ds.Tables[0].Rows[0]["MemberCode"].ToString();
                btnFetch_Click(this, EventArgs.Empty);
            }
        }
    }

    private void FillCustDtls(string UserID)
    {
        DataSet ds = new DataSet();
        htParam.Clear();
        ds = null;
        htParam.Add("@UserID", UserID);
        ds = dtAccess.GetDataSetForPrc_inscdirect("prc_GetDtlsFrmCustMapExt", htParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (rdbInter.SelectedValue == "E")
            {
                txtCustID.Text = ds.Tables[0].Rows[0]["CustomerID"].ToString();
                txtSrvcAgt.Text = ds.Tables[0].Rows[0]["ServiceAgent"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();

                //btnVerify_Click(this, EventArgs.Empty);
            }
            else if (rdbInter.SelectedValue == "I")
            {

            }
        }


    }
    private void FillInUserTypeDDL()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@LookUpCode", "InUserType");
        dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_GetddlUserType", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlInUserType.DataSource = dsResult.Tables[0];
            ddlInUserType.DataTextField = "ParamDesc01";
            ddlInUserType.DataValueField = "ParamValue";
            ddlInUserType.DataBind();
            ddlInUserType.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    private void FillExUserTypeDDL()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@LookUpCode", "ExUserType");
        dsResult = dtAccess.GetDataSetForPrc_inscdirect("Prc_GetddlUserType", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlEXUserType.DataSource = dsResult.Tables[0];
            ddlEXUserType.DataTextField = "ParamDesc01";
            ddlEXUserType.DataValueField = "ParamValue";
            ddlEXUserType.DataBind();
            ddlEXUserType.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    #endregion
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string[] strDataTable;
        strDataTable = new string[12];
        strDataTable[0] = txtUserName.Text.ToString();
        strDataTable[1] = txtSapCode.Text.ToString().Trim();
        strDataTable[2] = txtMemberCode.Text.ToString().Trim();
        strDataTable[3] = ddlUntType.SelectedValue.ToString().Trim();
        strDataTable[4] = ddlBizSrc.SelectedValue.ToString().Trim();
        strDataTable[5] = ddlChnCls.SelectedValue.ToString().Trim();
        strDataTable[6] = ddlUnit.SelectedValue.ToString().Trim();
        strDataTable[7] = ddlUntType.SelectedValue.ToString().Trim();
        strDataTable[8] = ddlUnit.SelectedItem.Text.ToString().Trim();
        strDataTable[9] = txtPrmyMgr.Text.ToString().Trim();
        strDataTable[10] = txtAddlMgr1.Text.ToString().Trim();
        strDataTable[11] = txtAddlMgr2.Text.ToString().Trim();
        DataTable dtAdd = new DataTable();
        dtAdd = (DataTable)ViewState["DT"];
        dtAdd.Rows.Add(strDataTable);
        ViewState["DT"] = dtAdd;
        ViewState["GridData"] = dtAdd;
        dgDetails.DataSource = dtAdd;
        dgDetails.DataBind();
        trGrid.Visible = true;
        linkSave.Enabled = true;

    }
    public void InitateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("LegalName", typeof(string));
        dt.Columns.Add("EmpCode", typeof(string));
        dt.Columns.Add("MemberCode", typeof(string));
        dt.Columns.Add("AgentType", typeof(string));
        dt.Columns.Add("BizSrc", typeof(string));
        dt.Columns.Add("ChnCls", typeof(string));
        dt.Columns.Add("UnitCode", typeof(string));
        dt.Columns.Add("UnitType", typeof(string));
        dt.Columns.Add("UnitName", typeof(string));
        dt.Columns.Add("PrmyMgrCode", typeof(string));
        dt.Columns.Add("Addl1MgrCode", typeof(string));
        dt.Columns.Add("Addl2MgrCode", typeof(string));
        ViewState["DT"] = dt;
    }

    public void InitateCustDataTable()
    {
        DataTable dtCust = new DataTable();
        dtCust.Columns.Add("CustomerID", typeof(string));
        dtCust.Columns.Add("SrvcAgt", typeof(string));
        dtCust.Columns.Add("MobileNo", typeof(string));
        ViewState["dtCust"] = dtCust;
    }

    protected void ddlUntType_SelectedIndexChanged(object sender, EventArgs e)
    {
        dsResult = null;
        htParam.Clear();
        htParam.Add("@UnitType", ddlUntType.SelectedValue.ToString());
        dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUnitDtls", htParam);
        htParam.Clear();
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            ddlUnit.DataSource = dsResult;
            ddlUnit.DataTextField = "UnitDesc01";
            ddlUnit.DataValueField = "UNitcode";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select", ""));
        }
    }
    protected void btnAddCustDtlsToGris_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        if (gvCustDtls.Rows.Count > 0)
        {
            GridViewRow[] ApprovalArray = new GridViewRow[gvCustDtls.Rows.Count];
            gvCustDtls.Rows.CopyTo(ApprovalArray, 0);
            for (int i = 0; i < gvCustDtls.Rows.Count; i++)
            {
                Label lbl1 = (Label)gvCustDtls.Rows[i].Cells[0].FindControl("lblCustID");
                if (txtCustID.Text == lbl1.Text)
                {
                    str = "1";
                    break;


                }
            }
            if (str != "1")
            {
                BindAddBtnValue();
            }
        }
        else
        {
            BindAddBtnValue();

        }

    }
    protected void BindAddBtnValue()
    {

        string[] strDataTable;
        strDataTable = new string[3];
        strDataTable[0] = txtCustID.Text.ToString();
        strDataTable[1] = txtSrvcAgt.Text.ToString().Trim();
        strDataTable[2] = txtMobile.Text.ToString().Trim();
        DataTable dtAdd = new DataTable();
        dtAdd = (DataTable)ViewState["dtCust"];
        dtAdd.Rows.Add(strDataTable);
        ViewState["DT"] = dtAdd;
        ViewState["CustGridData"] = dtAdd;
        gvCustDtls.DataSource = dtAdd;
        gvCustDtls.DataBind();
        gvCustDtls.Visible = true;
        trGridCustDtls.Visible = true;
        linkSave.Enabled = true;
    }
    protected void ddlEXUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEXUserType.SelectedValue == "CS")
        {
            trHierarchy.Visible = true;
            trCustDtls.Visible = false;
            btnAdd.Visible = true;
        }
        else
        {
            trHierarchy.Visible = false;
            trCustDtls.Visible = true;
        }
    }
    protected void lbCustDelete_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["CustGridData"];
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        dt.Rows.RemoveAt(row.RowIndex);
        ViewState["dtCust"] = dt;
        gvCustDtls.DataSource = dt;
        gvCustDtls.DataBind();
    }
    protected void ddlMemberRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMemberRole.SelectedValue == "CONSTF")
        {
            trCustDtls.Visible = true;
            trHierarchy.Visible = false;
            btnAdd.Visible = false;
        }
        else if (ddlMemberRole.SelectedValue == "EMPIND")
        {

            if (rdbInter.SelectedValue == "I")
            {
                trHierarchy.Visible = true;
                btnAdd.Visible = false;
                LblRoles.Visible = true;
                btnVerify.Visible = true;
                btnFetch.Visible = true;
                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = false;
                tr4.Visible = false;
                trCustDtls.Visible = false;
                gvCustDtls = null;
                trGrid.Visible = false;
                ViewState["DT"] = null;
                ViewState["dtCust"] = null;
                InitateDataTable();
                InitateCustDataTable();
                txtCustID.Text = string.Empty;
                txtSrvcAgt.Text = string.Empty;
                txtMobile.Text = string.Empty;
            }
            else if (rdbInter.SelectedValue == "E")
            {
                trHierarchy.Visible = true;
                trCustDtls.Visible = false;
                btnAdd.Visible = true;
                tr1.Visible = true;
                tr2.Visible = true;
                tr3.Visible = true;
                tr4.Visible = true;
                btnVerify.Visible = false;
                btnFetch.Visible = false;
                LblRoles.Visible = true;
                trGrid.Visible = false;
                FillDDlBizSrcChnCls();
            }
        }
        else
        {
            trHierarchy.Visible = true;
            btnAdd.Visible = false;
            LblRoles.Visible = true;
            btnVerify.Visible = true;
            btnFetch.Visible = true;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            trCustDtls.Visible = false;
            gvCustDtls.Visible = false;
            trGrid.Visible = false;
            gvCustDtls = null;
            ViewState["DT"] = null;
            ViewState["dtCust"] = null;
            InitateDataTable();
            InitateCustDataTable();
            txtCustID.Text = string.Empty;
            txtSrvcAgt.Text = string.Empty;
            txtMobile.Text = string.Empty;
        }
    }
}
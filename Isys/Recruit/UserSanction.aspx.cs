using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Insc.Common.Multilingual;
using System.Collections;
using System.Data;
using DataAccessClassDAL;
using System.Collections.ObjectModel;
using AdminUser;


public partial class Application_ISys_Recruit_UserSanction : BaseClass
{
    #region Page declaration
    private multilingualManager olng;
    private string strconn = ConfigurationManager.ConnectionStrings["UpdDwnldConnectionString"].ConnectionString.ToString();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private Insc.Common.Data.Provider oDP = new Insc.Common.Data.Provider();
    Hashtable htParam=new Hashtable();
    DataSet dsResult = new DataSet();
    public string userid = string.Empty;
    string strUserLangNumNum = string.Empty;
     AdminDAL admin = new AdminDAL();
     ErrLog objErr = new ErrLog();
     string strUserId = string.Empty;
     string strUserIDQ = string.Empty;
     string strMode = string.Empty;
    
    #endregion
        
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                strUserIDQ = Request.QueryString["UserID"].ToString().Trim();
                ViewState["UserID"] = strUserIDQ;
                strMode = Request.QueryString["Mode"].ToString().Trim();
                BindTreeView(strMode);
            }
            strUserLangNumNum = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "UsrSu.aspx", strUserLangNumNum);
            
           
            strUserId= HttpContext.Current.Session["UserID"].ToString().Trim();
           
        }
       
    }
     #endregion

    #region BindTreeView
    protected void BindTreeView(string strMode)
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@UserId", ViewState["UserID"]);
            dsResult = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetTRViUserUpd",htParam);

            if (strMode == "File Upload")
            {
                pnlUpload.Visible = true;
                PopulateUpldTreeView((DataTable)dsResult.Tables[0]);
            }
            if (strMode == "File Download")
            {
                pnlDwnld.Visible = true;
                PopulateDwnldTreeView((DataTable)dsResult.Tables[1]);
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region Populate Upload TreeView
    public void PopulateUpldTreeView(DataTable dt)
    {
        try
        {
            tblHeirarchy.Visible = true;
         
            int iCount = dt.Rows.Count;
            TreeNode ModuleList = new TreeNode();
            Collection<TreeNode> AllNode = new Collection<TreeNode>();
            TreeNode finalNode = new TreeNode();
            Collection<string> nodeID = new Collection<string>();

            for (int icount = 0; icount < dt.Rows.Count; icount++)
            {
                TreeNode CurNode = new TreeNode(dt.Rows[icount]["ReportDesc"].ToString(), dt.Rows[icount]["ReportID"].ToString());
                CurNode.NavigateUrl = "javascript:void(0)";
                AllNode.Add(CurNode);
                nodeID.Add(dt.Rows[icount]["ReportID"].ToString());

                if (dt.Rows[icount]["Access"].ToString() != "0")
                { CurNode.Checked = true; }
                else { CurNode.Checked = false; }
            }

            TrVUser.Nodes.Clear();
            for (int icount = 0; icount < dt.Rows.Count; icount++)
            {
                TreeNode CurNode = AllNode[nodeID.IndexOf(dt.Rows[icount]["ReportID"].ToString())];
                CurNode.NavigateUrl = "javascript:void(0)";
                if (dt.Rows[icount]["ReportParentID"].ToString() != "")
                    AllNode[nodeID.IndexOf(dt.Rows[icount]["ReportParentID"].ToString())].ChildNodes.Add(CurNode);
                else
                    TrVUser.Nodes.Add(CurNode);
            }

            TrVUser.ExpandAll();
            TrVUser.Attributes.Add("onclick", "OnTreeClick(event)");
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }

       
        
    }
    void DisplayUChildNodeText(TreeNode node, string userid)
    {
        try
        {
            int chkstatus;
            DataSet ds1;

            if (node.Checked == true)
            { chkstatus = 1; }
            else { chkstatus = 0; }
            htParam.Clear();
            htParam.Add("@ReportID", node.Value);
            htParam.Add("@UserID", userid);
            htParam.Add("@Flag", "1");
            ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDtlsfromiUsrUpdDwnldAcs", htParam);
            if (ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    if (chkstatus == 1)
                    {
                        //insert checked status
                        htParam.Clear();
                        htParam.Add("@ReportID", node.Value);
                        htParam.Add("@UserID", userid);
                        htParam.Add("@Flag", "1");
                        ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_InsDtlsiUserUpdDwnld", htParam);

                    }
                }
                else
                {
                    if (chkstatus == 0)
                    {
                        htParam.Clear();
                        htParam.Add("@ReportID", node.Value);
                        htParam.Add("@UserID", userid);
                        htParam.Add("@Flag", "1");
                        ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_DelFromIUserUpdwnldAcs", htParam);
                    }
                }
            }

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                DisplayUChildNodeText(node.ChildNodes[i], ViewState["UserID"].ToString().Trim());
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region Populate Download TreeView
    public void PopulateDwnldTreeView(DataTable dt)
    {
        try
        {
            tblHeirarchy.Visible = true;
          
            int iCount = dt.Rows.Count;
            TreeNode ModuleList = new TreeNode();
            Collection<TreeNode> AllNode = new Collection<TreeNode>();
            TreeNode finalNode = new TreeNode();
            Collection<string> nodeID = new Collection<string>();

            for (int icount = 0; icount < dt.Rows.Count; icount++)
            {
                TreeNode CurNode = new TreeNode(dt.Rows[icount]["ReportDesc"].ToString(), dt.Rows[icount]["ReportID"].ToString());
                CurNode.NavigateUrl = "javascript:void(0)";
                AllNode.Add(CurNode);
                nodeID.Add(dt.Rows[icount]["ReportID"].ToString());

                if (dt.Rows[icount]["Access"].ToString() != "0")
                { CurNode.Checked = true; }
                else { CurNode.Checked = false; }
            }

            TrDDoc.Nodes.Clear();
            for (int icount = 0; icount < dt.Rows.Count; icount++)
            {
                TreeNode CurNode = AllNode[nodeID.IndexOf(dt.Rows[icount]["ReportID"].ToString())];
                CurNode.NavigateUrl = "javascript:void(0)";
                if (dt.Rows[icount]["ReportParentID"].ToString() != "")
                    AllNode[nodeID.IndexOf(dt.Rows[icount]["ReportParentID"].ToString())].ChildNodes.Add(CurNode);
                else
                    TrDDoc.Nodes.Add(CurNode);
            }

            TrDDoc.ExpandAll();
             TrDDoc.Attributes.Add("onclick", "OnTreeClick(event)");
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }

       
        
    }
    void DisplayDChildNodeText(TreeNode node, string userid)
    {
        try
        {
            int chkstatus;
            DataSet ds1;

            if (node.Checked == true)
            { chkstatus = 1; }
            else { chkstatus = 0; }
            htParam.Clear();
            htParam.Add("@ReportID", node.Value);
            htParam.Add("@UserID", userid);
            htParam.Add("@Flag", "2");
            ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_GetDtlsfromiUsrUpdDwnldAcs", htParam);
            if (ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    if (chkstatus == 1)
                    {
                        //insert checked status
                        htParam.Clear();
                        htParam.Add("@ReportID", node.Value);
                        htParam.Add("@UserID", userid);
                        htParam.Add("@Flag", "2");
                        ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_InsDtlsiUserUpdDwnld", htParam);

                    }
                }
                else
                {
                    if (chkstatus == 0)
                    {
                        htParam.Clear();
                        htParam.Add("@ReportID", node.Value);
                        htParam.Add("@UserID", userid);
                        htParam.Add("@Flag", "2");
                        ds1 = dataAccessRecruit.GetDataSetForPrcUpdDwnld("Prc_DelFromIUserUpdwnldAcs", htParam);
                    }
                }
            }

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                DisplayDChildNodeText(node.ChildNodes[i], ViewState["UserID"].ToString().Trim());
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    #region btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (strUserId!= null)
            {
                for (int icount = 0; icount < TrVUser.Nodes.Count; icount++)
                {
                    DisplayUChildNodeText(TrVUser.Nodes[icount], ViewState["UserID"].ToString().Trim());
                }
                for (int icount = 0; icount < TrDDoc.Nodes.Count; icount++)
                {
                    DisplayDChildNodeText(TrDDoc.Nodes[icount], ViewState["UserID"].ToString().Trim());
                }
            }
            lbl_popup.Text = "Updated Successfully";
            mdlpopup.Show();
            //pnlMdl1.Visible = true;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("I-Sys Suite", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            throw (ex);
        }
    }
    #endregion

    
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserSanction.aspx");
    }
}   
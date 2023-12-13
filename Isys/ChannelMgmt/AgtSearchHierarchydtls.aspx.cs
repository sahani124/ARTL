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
using INSCL.App_Code;
using INSCL.DAL;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using CLTMGR;
using DataAccessClassDAL;
public partial class Application_INSC_ChannelMgmt_AgtSearchHierarchydtls : BaseClass
{

    #region Declaration
    DataAccessClass objDAL = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    string AgntCode = string.Empty;
    string Flag = string.Empty;
    string PrmyMgrCode = string.Empty;
    string AddlMgrCode = string.Empty;
    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
		if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
		{
			Response.Redirect("~/ErrorSession.aspx");
		}
		Session["CarrierCode"] ='2';
        if (!IsPostBack)
        {
           // PopulateRootLevel();
        }
        string strType = "agn";
        AgntCode = Request.QueryString["AgnCd"].ToString().Trim();
        Flag = Request.QueryString["Flag"].ToString().Trim();
        
        Response.Redirect("ChannelHierarchy.aspx?A=" + AgntCode + "&T=" + strType + "&Flag=" + Flag + "");
        
    }

    public void PopulateRootLevel()
    {
        try
        {
            TreeNode tn = new TreeNode();
            tn.Text = string.Format("{0} ({1})", Request.QueryString["AgnName"].ToString().Trim(), Request.QueryString["AgnType"].ToString().Trim()); ;
            tn.Value = Request.QueryString["AgnCd"].ToString().Trim();
            tn.ToolTip = "";
            tn.SelectAction = TreeNodeSelectAction.None;
            tn.PopulateOnDemand = true;
            trMgrHirarchy.Nodes.Add(tn);

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

    public void PopulateSubLevel(string AgnCode, TreeNode ParentNode)
    {
        try
        {
            DataSet dsAgnMgrChild = new DataSet();
            Hashtable ht2 = new Hashtable();
            ht2.Add("@Agentcode", AgnCode);
            ht2.Add("@Flag", Request.QueryString["Flag"].ToString().Trim());
            ht2.Add("@CDAHierechy", Request.QueryString["CDAFlag"].ToString().Trim());

            dsAgnMgrChild = objDAL.GetDataSetForPrc("prc_GetAgnHierarchyDetails", ht2);

            DataTable dt1;
            dt1 = dsAgnMgrChild.Tables[0];

            PopulateNodes(dt1, ParentNode.ChildNodes);
            dsAgnMgrChild = null;
            dt1 = null;
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

    public void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
    {
        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                if (dr["AgentType"].ToString().Trim() == "AG" || dr["AgentType"].ToString().Trim() == "RF" || dr["AgentType"].ToString().Trim() == "LG" || dr["AgentType"].ToString().Trim() == "ST" || dr["AgentType"].ToString().Trim() == "CA" || dr["AgentType"].ToString().Trim() == "CS" || dr["AgentType"].ToString().Trim() == "SA" || dr["AgentType"].ToString().Trim() == "SC" || dr["AgentType"].ToString().Trim() == "VA" || dr["AgentType"].ToString().Trim() == "VL")
                {
                    tn.Text = string.Format("{0} ({1}) ({2})", dr["LegalName"].ToString(), dr["AgentCode"].ToString(), dr["AgentType"].ToString());
                }
                else if (dr["AgentType"].ToString().Trim() == "SB" && dr["BizSrc"].ToString().Trim() == "DA")
                {
                    tn.Text = string.Format("{0} ({1}) ({2})", dr["LegalName"].ToString(), dr["AgentCode"].ToString(), dr["AgentType"].ToString());
                }
                else
                {
                    tn.Text = string.Format("{0} ({1}-{2}) ({3}) ({4})", dr["LegalName"].ToString(), dr["CSCCode"].ToString(), dr["EmpCode"].ToString(), dr["AgentType"].ToString(), dr["AgentCode"].ToString());
                    //tn.Text = string.Format("{0} ({1}-{2}) ({3})", dr["LegalName"].ToString(), dr["CSCCode"].ToString(), dr["AgentCode"].ToString(), dr["AgentType"].ToString());
                }

                tn.Value = dr["AgentCode"].ToString();
                tn.ToolTip = "";
                tn.SelectAction = TreeNodeSelectAction.None;
                nodes.Add(tn);

                if (Convert.ToInt32(dr["childnodecount"].ToString()) > 0)
                {
                    tn.PopulateOnDemand = true;
                }

            }
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

    protected void trMgrHirarchy_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(e.Node.Value.ToString(), e.Node);
    }
}

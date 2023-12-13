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
using Insc.Common.Multilingual;
using System.Text;
using CLTMGR;
using DataAccessClassDAL;
namespace INSCL
{
	public partial class HierarchySearch : BaseClass
	{

        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        string BizSrc = string.Empty;
        //Added by Saleem----------Start
        private const string Conn_Direct = "DefaultConn";
        private multilingualManager olng;
        //Added by Saleem----------End
        EncodeDecode ObjDec = new EncodeDecode();
        ErrLog objErr = new ErrLog();

		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }
                Session["CarrierCode"] = '2';

                //Added by Saleem----------Start
                olng = new multilingualManager("DefaultConn", "HierarchySearch.aspx", Session["UserLangNum"].ToString());
                //Added by Saleem----------End

                if (!IsPostBack)
                {
                    //Added by Saleem----------Start
                    InitializeControl();
                    //Added by Saleem----------End

                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("-- Select --", ""));

                }
                trDetails.Visible = false;
                Trview.Visible = false;
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
        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChnnlSubClass.Items.Clear();
                SqlDataReader dtRead;
                //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 start
                //dtRead = objDAL.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSalesChannel.SelectedValue.ToString().Trim() + "'ORDER BY SortOrder");
                Hashtable htunit = new Hashtable();
                htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htunit.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htunit);
                htunit.Clear();
                //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 end
                if (dtRead.HasRows)
                {
                    ddlChnnlSubClass.DataSource = dtRead;
                    ddlChnnlSubClass.DataTextField = "ChnlDesc";
                    ddlChnnlSubClass.DataValueField = "ChnCls";
                    ddlChnnlSubClass.DataBind();
                }
                dtRead = null;
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

		protected void btnSearch_Click(object sender, EventArgs e)
		{
            try
            {
                Trview.DataSource = null;
                Trview.DataBind();
                Trview.Nodes.Clear();
                PopulateRootLevel();
                string strType = "unt";
                BizSrc = ddlSalesChannel.SelectedValue.ToString().Trim();
                Response.Redirect("ChannelHierarchy.aspx?B=" + BizSrc + "&T=" + strType + "");
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
        public void PopulateRootLevel()
        {
            DataSet dsAgnMgr = new DataSet();
            Hashtable ht1 = new Hashtable();
            ht1.Add("@Bizsrc", ddlSalesChannel.SelectedValue.ToString().Trim());
            ht1.Add("@ChnCls", ddlChnnlSubClass.SelectedValue.ToString().Trim());
            ht1.Add("@UnitCode", DBNull.Value);
            ht1.Add("@ParentORChild", "PARENTNODE");

            dsAgnMgr = objDAL.GetDataSetForPrc("prc_GetUntHirarchy", ht1);

            DataTable dt;
            dt = dsAgnMgr.Tables[0];

            if (dsAgnMgr.Tables[0].Rows.Count > 0)
            {
                PopulateNodes(dt, Trview.Nodes);
                dsAgnMgr = null;
                dt = null;
                trDetails.Visible = true;
                Trview.Visible = true;
				lblMsg.Text = "";
				lblMsg.Visible = false;
            }
            else
            {
                lblMsg.Text = "NO Record Found";
				lblMsg.Visible = true;
                dsAgnMgr = null;
                dt = null;
                trDetails.Visible = false;
                Trview.Visible = false;
            }

        }
        public void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {

            //StringBuilder arr = new StringBuilder();
            
            //string[] str1 = new string[100]; 
           

            foreach (DataRow dr in dt.Rows)
            {
             StringBuilder arr = new StringBuilder();
            
            string[] str1 = new string[100]; 
				
                TreeNode tn = new TreeNode();
                tn.Text = string.Format("{0} ({1}) ({2})", dr["unitcode"].ToString().Trim(), dr["unitdesc01"].ToString().Trim(), dr["unittype"].ToString().Trim());// dr["Title"].ToString();
                tn.Value = dr["unitcode"].ToString().Trim();
                
                //str1 = dr["Descriptions"].ToString().Split(',');

                //for (int i = 1; i < str1.Length ; i++)
                //{
                //    arr.Append(i +") "+ str1[i-1].ToString() + "\n");
                //}
                //tn.ToolTip = string.Format(arr.ToString());
                tn.SelectAction = TreeNodeSelectAction.None;
                nodes.Add(tn);

                if (Convert.ToInt32(dr["childnodecount"].ToString()) > 0)
                {
                    tn.PopulateOnDemand = true;
                }
               // str1 = null;
            }
            
        }
        public void PopulateSubLevel(string Untcode, TreeNode ParentNode)
        {
            DataSet dsAgnMgrChild = new DataSet();
            Hashtable ht2 = new Hashtable();
            ht2.Add("@Bizsrc", ddlSalesChannel.SelectedValue.ToString().Trim());
            ht2.Add("@ChnCls", ddlChnnlSubClass.SelectedValue.ToString().Trim());
            ht2.Add("@UnitCode", Untcode);
            ht2.Add("@ParentORChild", "CHILDNODE");

            dsAgnMgrChild = objDAL.GetDataSetForPrc("prc_GetUntHirarchy", ht2);

            DataTable dt1;
            dt1 = dsAgnMgrChild.Tables[0];

            PopulateNodes(dt1, ParentNode.ChildNodes);
            dsAgnMgrChild = null;
            dt1 = null;
        }

		protected void btnClear_Click(object sender, EventArgs e)
		{
			Response.Redirect("HierarchySearch.aspx");
		}
	
		protected void Trview_SelectedNodeChanged(object sender, EventArgs e)
		{

		}

        protected void Trview_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                PopulateSubLevel(e.Node.Value.ToString(), e.Node);
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
        private void InitializeControl()
        {
            lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel"));
            lblChnnlSubClass.Text = (olng.GetItemDesc("lblChnnlSubClass"));
        }
    }

    
}

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insc.Common.Multilingual;
using System.Xml;
using DataAccessClassDAL;
namespace INSCL
{
    public partial class ChannelClassMas : Base
    {
        #region DECLARATIONS
        string ChnClass, BizSrc, ErrMsg, AuditType, strXML = "";
        XmlDocument doc = new XmlDocument();
        Hashtable htable = new Hashtable();
        private multilingualManager olng;
        private string strUserLang; 
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;    
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        ErrLog objErr = new ErrLog();
        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FunCheckSession();
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "ChannelClassMas.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                if (!IsPostBack)
                {
                    //clear the session
                    SetSessionObjectValue("OldProductDetails", null);
                    SetSessionObjectValue("ProductDetails", null);
                    trMain.Visible = false;
                    RefreshGrid();
                    RefreshGrid1();
                    ShowPageInformation();
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnAddNew.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }
        }
        #endregion

        #region REFRESHGRID
        //Added by vijendra  on 06-12-2013 to call method on page load start    
        private void RefreshGrid()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsdataset = new DataSet();
                htParam.Add("@ChannelType", "O");
                FillGridView(htParam, dgDetails, "prc_ChnCls_Search", "INSCCommonConnectionString");
                if (dgDetails.PageCount > 1)
                {
                    btnCompnext.Enabled = true;
                }
                else
                {
                    btnCompnext.Enabled = false;
                    txtPage.Text = "1";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }
        }
        #endregion

        #region REFRESHGRID
        private void RefreshGrid1()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsdataset = new DataSet();
                htParam.Add("@ChannelType", "C");
                FillGridView(htParam, Gv_ChannelDetails, "prc_ChnClsSearch", "INSCCommonConnectionString");
                if (Gv_ChannelDetails.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                    txtPage1.Text = "1";
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }
        }
        //Added by vijendra  on 06-12-2013 to call method on page load End 
        #endregion

        #region GetDisplay
        public DataTable GetDisplay(string Type)
        {
            DataSet dsdataset = new DataSet();
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet ds = new DataSet();
                htParam.Add("@ChannelType", Type.ToString().Trim());
                dsdataset = objDAL.GetDataSetForPrcCLP("prc_ChnClsSearch", htParam);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }

            return dsdataset.Tables[0];
            
        }
        #endregion

        #region DataBound
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[1].Text = "<a href=\"ChannelClassSetup.aspx?ChnCls=" + e.Row.Cells[1].Text + "&Code=" + e.Row.Cells[0].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "\">" + e.Row.Cells[1].Text + "</a>";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               LinkButton l = (LinkButton)e.Row.FindControl("btnDel");

                if (strValue == "YES")
                {
                    l.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    l.Enabled = false;
                }

                l.Attributes.Add("onclick", "javascript:return confirm('Are You Sure You Want To Delete This Record?')");

            }
        }
        #endregion

        #region AddNew
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChannelClassSetup.aspx?flag=" + ddlSalesChannel.SelectedValue.ToString().Trim() + "/N");
        }
        #endregion

        #region PageIndex
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                DataTable dt = GetDisplay("O");
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;

                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }
        }
        #endregion

        #region PAGEINFORMATION
        private void ShowPageInformation()
        {
            int intPageIndex = dgDetails.PageIndex + 1;
            int pgInfo = Gv_ChannelDetails.PageIndex + 1;
           // lblpgcom.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
           // lblpgchn.Text = "Page " + pgInfo.ToString() + " of " + Gv_ChannelDetails.PageCount;
        }
        #endregion

        #region Sorting
        protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridView dgSource = (GridView)sender;
                string strSort = string.Empty;
                string strASC = string.Empty;
                if (dgSource.Attributes["SortExpression"] != null)
                {
                    strSort = dgSource.Attributes["SortExpression"].ToString();
                }
                if (dgSource.Attributes["SortASC"] != null)
                {
                    strASC = dgSource.Attributes["SortASC"].ToString();
                }

                dgSource.Attributes["SortExpression"] = e.SortExpression;
                dgSource.Attributes["SortASC"] = "Yes";

                if (e.SortExpression == strSort)
                {
                    if (strASC == "Yes")
                    {
                        dgSource.Attributes["SortASC"] = "No";
                    }
                    else
                    {
                        dgSource.Attributes["SortASC"] = "Yes";
                    }
                }
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                DataTable dt = GetDisplay("O");
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "Page_Load", ex);
            }
        }
        #endregion

        #region Clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChannelClassMas.aspx");
        }
        #endregion

        #region lbChnSubCls Click Event
        protected void lbChnSubCls_Click(object sender, EventArgs e)
            
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblChnName = (Label)grd.FindControl("lblCompName");
            LinkButton lbChnCls = (LinkButton)grd.FindControl("lbChnSubCls");
            Label lblChannelDesc01 = (Label)grd.FindControl("lblChnClsDesc");
            Label lblComSortOrder = (Label)grd.FindControl("lblSortOrder");
            Label lblCompBizSrc = (Label)grd.FindControl("lblCompBizSrc");///added by akshay on 020514
            
            Response.Redirect("ChannelClassSetup.aspx?ChnCls=" + lbChnCls.Text + "&Code=" + lblChannelDesc01.Text + "&Cancel=" + lblComSortOrder.Text + "&BizSrc=" + lblCompBizSrc.Text.Trim() + "&BizSrcNM=" + lblChnName.Text.Trim());
        }
        #endregion

        #region lbChnSubCls1 Click event
        protected void lbChnSubCls1_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbChnCls = (LinkButton)grd.FindControl("lbChnSubCls1");
            Label lblChannelDesc01 = (Label)grd.FindControl("lblChnClsDesc1");
            lblChannelDesc01.Text = lblChannelDesc01.Text;
            Label lblComSortOrder = (Label)grd.FindControl("lblSortOrder1");
            Label lblBizSrc = (Label)grd.FindControl("lblBizSrc");///added by akshay on 020514
            Label lblChnName = (Label)grd.FindControl("lblChnName");    //added by raj for channel name in query string 
            Response.Redirect("ChannelClassSetup.aspx?ChnCls=" + lbChnCls.Text + "&Code=" + lblChannelDesc01.Text + "&Cancel=" + lblComSortOrder.Text + "&BizSrc=" + lblBizSrc.Text.Trim() + "&BizSrcNM=" + lblChnName.Text.Trim());
        }
        #endregion

        #region Gv_ChannelDetails PageIndexChanging event
        protected void Gv_ChannelDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                DataTable dt = GetDisplay("C");
                DataView dv = new DataView(dt);
                GridView dgSource = (GridView)sender;
                dgSource.PageIndex = e.NewPageIndex;
                dv.Sort = dgSource.Attributes["SortExpression"];
                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
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

        #region Gv_ChannelDetails RowDataBound event
        protected void Gv_ChannelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[1].Text = "<a href=\"ChannelClassSetup.aspx?ChnCls=" + e.Row.Cells[1].Text + "&Code=" + e.Row.Cells[0].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "\">" + e.Row.Cells[1].Text + "</a>";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");

                if (strValue == "YES")
                {
                    l.Enabled = true;
                }
                else if (strValue == "NO")
                {
                    l.Enabled = false;
                }



                l.Attributes.Add("onclick", "javascript:return confirm('Are You Sure You Want To Delete This Record?')");
            }
        }
        #endregion

        #region Gv_ChannelDetails Sorting Event
        //Added by vijendra on 06-12-2013 to allow sorting on Gv_ChannelDetails gridview Start
        protected void Gv_ChannelDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                GridView dgSource = (GridView)sender;
                string strSort = string.Empty;
                string strASC = string.Empty;
                if (dgSource.Attributes["SortExpression"] != null)
                {
                    strSort = dgSource.Attributes["SortExpression"].ToString();
                }
                if (dgSource.Attributes["SortASC"] != null)
                {
                    strASC = dgSource.Attributes["SortASC"].ToString();
                }

                dgSource.Attributes["SortExpression"] = e.SortExpression;
                dgSource.Attributes["SortASC"] = "Yes";

                if (e.SortExpression == strSort)
                {
                    if (strASC == "Yes")
                    {
                        dgSource.Attributes["SortASC"] = "No";
                    }
                    else
                    {
                        dgSource.Attributes["SortASC"] = "Yes";
                    }
                }
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                DataTable dt = GetDisplay("C");
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                ShowPageInformation();
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
        //Added by vijendra on 06-12-2013 to allow sorting on Gv_ChannelDetails gridview End
        #endregion

        #region Gv_ChannelDetails RowCommand Event
        //Added by vijendra on 06-12-2013 to create Rowcommand event of Gv_ChannelDetails gridview Start
        //protected void Gv_ChannelDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    if (Session["UserGrp"].ToString() != ConfigurationManager.AppSettings["BlockGroupName"].ToString())
        //    {
        //        //if (e.CommandName == "Delete")
        //        //{
        //        //    clsAgentLevelSetup objAgtType = new clsAgentLevelSetup();
        //        //    clsChannelSetup channelsetup = new clsChannelSetup();
        //        //    GridViewRow row1 = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //        //    Int32 rowind = row1.RowIndex;
        //        //    Label lblBizsrc = (Label)row1.FindControl("lblBizSrc");
        //        //    LinkButton lbChnSubCls1 = (LinkButton)row1.FindControl("lbChnSubCls1");
        //        //    Label lblChnClsDesc1 = (Label)row1.FindControl("lblChnClsDesc1");
        //        //    Label lblSortOrder1 = (Label)row1.FindControl("lblSortOrder1");
        //        //    try
        //        //    {
        //        //        ArrayList arrLst = new ArrayList();
        //        //        arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
        //        //        arrLst.Add(new prjXml.Collection("BizSrc", lblBizsrc.Text));
        //        //        arrLst.Add(new prjXml.Collection("ChnCls", lbChnSubCls1.Text));
        //        //        arrLst.Add(new prjXml.Collection("ChnClsDesc", lblChnClsDesc1.Text.ToString()));
        //        //        arrLst.Add(new prjXml.Collection("SortOrder", lblSortOrder1.Text.ToString()));
        //        //        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
        //        //        XmlDocument xDoc = new XmlDocument();
        //        //        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
        //        //        strXML = xDoc.OuterXml;

        //        //        arrLst.Clear();
        //        //        channelsetup.ChannelClassDelete(lbChnSubCls1.Text, Session["CarrierCode"].ToString(), lblBizsrc.Text);
        //        //        this.RefreshGrid1();
        //        //        //lblMsg.Visible = true;
        //        //        lblMsg.Text = "Selected record has been deleted successfully";
        //        //        //Added by Pranjali on 29-05-2013 for modal popup display start
        //        //        lbl.Visible = true;
        //        //        lbl_popup.Text = "Channel sub class deleted successfully<br /><br />Channel:" + lblBizsrc.Text.Trim() + "<br /><br /> Sub Class:" + lblChnClsDesc1.Text.Trim() + "<br /><br />Sort Order:" + lblSortOrder1.Text.Trim();
        //        //      //  mdlpopup.Show();
        //        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        //        //        //Added by Pranjali on 29-05-2013 for modal popup display end

        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ex.Message);
        //        //        ///var script = string.Format("alert({0});", message);
        //        //        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + ex.Message.Trim() + "');</script>", false);
        //        //        ///ClientScript.RegisterStartupScript(Page.GetType(), "", script, true);
        //        //        lblMsg.Visible = true;
        //        //        lblMsg.Text = ex.Message;
        //        //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //        //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //        //        string sRet = oInfo.Name;
        //        //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //        //        String LogClassName = method.ReflectedType.Name;
        //        //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        //        //    }
        //        //    if (lblMsg.Text == "Selected record has been deleted successfully")
        //        //    {
        //        //        ErrMsg = "S";
        //        //    }
        //        //    else
        //        //    {
        //        //        ErrMsg = "E";
        //        //    }
        //        //    if (ErrMsg == "S")
        //        //    {
        //        //        AuditType = "DE";
        //        //    }
        //        //    else
        //        //    {
        //        //        AuditType = "DE";
        //        //    }
        //        //    string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = lblMsg.Text, ErrDtl = "";
        //        //    channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + BizSrc + ChnClass, "ChnClsSu", "Delete,clsChannelSetup.cs", "prc_ChannelClass_Delete", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);

        //        //}
        //    }
        //}
        //Added by vijendra on 06-12-2013 to create Rowcommand event of Gv_ChannelDetails gridview End
        #endregion

        #region hierarchy event 
        #region lbCompHumanHierarchy1 Click Event
        protected void lbCompHumanHierarchy1_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lbChnSubCls = (LinkButton)grd.FindControl("lbChnSubCls");
            hdnselectedBizsrc.Value = lbChnSubCls.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
  "OpenElement('myModalRaise1','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','chncls')", true);

        }
        #endregion
		
		 #region lbCompHumanHierarchy1 Click Event
        protected void lnksubhmncmpact_click(object sender, EventArgs e)
        {

            //Response.Redirect("index.html");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddlCmnt();", true);

        }
        #endregion

        #region lbCompLocationHierarchy1 Click Event
        protected void lbCompLocationHierarchy1_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lbBizSrc = (Label)grd.FindControl("lblCompBizSrc");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "OpenElement('myModalRaise1','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','chnUNT')", true);

            //GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            //LinkButton lbChnCls = (LinkButton)grd.FindControl("lbChnSubCls");
            //Label lblCompBizSrc = (Label)grd.FindControl("lblCompBizSrc");
            //string strChnCls = lbChnCls.Text.ToString().Trim();
            //string strType = "sbchloc";
            //string strBizsrc = lblCompBizSrc.Text.ToString().Trim();
            //Response.Redirect("ChannelHierarchy.aspx?B=" + strBizsrc + "&T=" + strType + "&C=" + strChnCls + "");
        }
        #endregion
        #endregion
     
        protected void btnOldHier_Click(object sender, EventArgs e)
        {
            mdlpopup1.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funpopup();", true);
        }


        #region Paging previous and next button
        protected void btnCompnext_Click(object sender, EventArgs e)
        {
            try
            {

                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                RefreshGrid();

                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnCompprevious.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnCompnext.Enabled = false;
                }
                int page = dgDetails.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "btnCompnext_Click", ex);
            }
        }

        protected void btnCompprevious_Click(object sender, EventArgs e)
        {
            try
            {

                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                RefreshGrid();

                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnCompnext.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnCompprevious.Enabled = false;
                }
                int page = dgDetails.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "btnCompprevious_Click", ex);
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {

                int pageIndex = Gv_ChannelDetails.PageIndex;
                Gv_ChannelDetails.PageIndex = pageIndex - 1;
                RefreshGrid1();

                txtPage1.Text = Convert.ToString(Convert.ToInt32(txtPage1.Text) - 1);
                btnnext.Enabled = true;
                if (txtPage1.Text == Convert.ToString(Gv_ChannelDetails.PageCount))
                {
                    btnprevious.Enabled = false;
                }
                int page = Gv_ChannelDetails.PageCount;
                if (txtPage1.Text == "1")
                {
                    btnprevious.Enabled = false;
                }

                else
                {
                    btnprevious.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "btnprevious_Click", ex);
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {

                int pageIndex = Gv_ChannelDetails.PageIndex;
                Gv_ChannelDetails.PageIndex = pageIndex + 1;
                RefreshGrid1();

                txtPage1.Text = Convert.ToString(Convert.ToInt32(txtPage1.Text) + 1);
                btnprevious.Enabled = true;
                if (txtPage1.Text == Convert.ToString(Gv_ChannelDetails.PageCount))
                {
                    btnnext.Enabled = false;
                }
                int page = Gv_ChannelDetails.PageCount;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelClassMas.aspx", "btnnext_Click", ex);
            }
        }
        #endregion

        //added by sanoj 06112023
        protected void btnchnlmove_Click(object sender, EventArgs e)
        {
            //ADDED BY AJAY 23 MAY 2023
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "openMoveTo()", true);
            GridViewRow Gv_ChannelDetails = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblBizSrc = (Label)Gv_ChannelDetails.FindControl("lblBizSrc");
            LinkButton lbChnSubCls1 = (LinkButton)Gv_ChannelDetails.FindControl("lbChnSubCls1");
            ViewState["CurrentChnl"] = lblBizSrc.Text.ToString().Trim();
            ViewState["CurrentChncls"] = lbChnSubCls1.Text.ToString().Trim();
            objCommonU.moveGetSalesChannel(ddlmovechnl, "", 1, ViewState["CurrentChnl"].ToString().Trim());//comented by sanoj 29052023
            ddlmovechnl.Items.Insert(0, "Select");
            ddlChnnlClass.Items.Insert(0, "Select");
        }

        protected void rdmoveto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdmoveto.SelectedValue == "0")
            {
                ddlmovechnl.Enabled = true;
                ddlChnnlClass.Enabled = false;
                //GridViewRow Gv_ChannelDetails = ((RadioButtonList)sender).NamingContainer as GridViewRow;
                //Label lblBizSrc = (Label)Gv_ChannelDetails.FindControl("lblBizSrc");
                //LinkButton lbChnSubCls1 = (LinkButton)Gv_ChannelDetails.FindControl("lbChnSubCls1");
                //ViewState["CurrentChnl"] = lblBizSrc.Text.ToString().Trim();
                //ViewState["CurrentChncls"] = lbChnSubCls1.Text.ToString().Trim();
                objCommonU.moveGetSalesChannel(ddlmovechnl, "", 1, ViewState["CurrentChnl"].ToString().Trim());//comented by sanoj 29052023
                ddlChnnlClass.ClearSelection();
            }
            else
            {
                ddlmovechnl.Enabled = true;
                ddlChnnlClass.Enabled = true;
                ddlmovechnl.SelectedItem.Text = "Select";
            }
        }

        protected void ddlmovechnl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "openMoveTo()", true);
                //Subchannel
                if (rdmoveto.SelectedValue == "0")
                {

                }
                else
                {
                    ddlChnnlClass.Items.Clear();
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", "2");
                    htParam.Add("@BizSrc", ddlmovechnl.SelectedValue);
                    FillDropDown(ddlChnnlClass, "Prc_Move_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "openMoveTo()", true);
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);
            }
        }

        protected void btnmovechnl_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "openMoveTo()", true);
                Hashtable htParam = new Hashtable();
                DataSet dsdataset = new DataSet();
                htParam.Add("@bizsrc", ddlmovechnl.SelectedValue);
                if (ddlChnnlClass.SelectedItem.Text == "Select")
                {
                    htParam.Add("@chncls", System.DBNull.Value);
                }
                else
                {
                    htParam.Add("@chncls", ddlChnnlClass.SelectedValue);
                }
                htParam.Add("@Currbizsrc", ViewState["CurrentChnl"].ToString().Trim());
                htParam.Add("@Currchncls", ViewState["CurrentChncls"].ToString().Trim());
                htParam.Add("@UpdateBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@EffDate", Convert.ToDateTime(txteffdate.Text.ToString().Trim()));
                htParam.Add("@flag", rdmoveto.SelectedValue);
                dsdataset = objDAL.GetDataSetForPrc("Prc_Upd_Chnl", htParam);
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Channel moved successfully.');</script>", false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "closedMoveto();", true);
            }
            catch (Exception ex)
            {

                LogException("ISYS-CHMS", "AGTSearchLvl.aspx", "btnmovechnl_Click", ex);
            }
        }
        protected void lnkbtnSubchnlCease_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lbBizSrc = (Label)grd.FindControl("lblBizSrc");
            LinkButton lbChnSubCls = (LinkButton)grd.FindControl("lbChnSubCls1");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            hdnChnCls.Value = lbChnSubCls.Text.ToString();

            //ADDED BY AJAY 23 MAY 2023
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "OpenForCease()", true);
            Binddatagrid();
            BindAgentGrid();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {


            if (ViewState["gv"] != null)
            {
                DataSet dataSet = ViewState["gv"] as DataSet;
                DataTable dt = dataSet.Tables[0];
                //dt = (DataTable)ViewState["gv"];
                for (int i = 0; dt.Rows.Count > 0; i++)
                {
                    if (dt.Columns["Active"].ToString().Trim() != "0")
                    {
                        string msg = "You can not cease unit type for this " + hdnChnCls.Value + " Sub Channel";
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "alert('" + msg + "');", true);
                        return;
                    }
                }
            }

            //MEMBER TYPE
            if (ViewState["gvmem"] != null)
            {
                DataSet ds = ViewState["gvmem"] as DataSet;
                DataTable dtmem = ds.Tables[0];
                //dtmem = (DataTable)ViewState["gvmem"];
                for (int i = 0; dtmem.Rows.Count > 0; i++)
                {
                    if (dtmem.Columns["Active"].ToString().Trim() != "0")
                    {
                        string msg = "You can not cease member type for this " + hdnChnCls.Value + " Sub Channel";
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "alert('" + msg + "');", true); return;
                    }
                }
            }
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            htParam.Add("@bizsrc", hdnselectedBizsrc.Value);
            htParam.Add("@Chncls", hdnChnCls.Value);//Request.QueryString["Bizsrc"].ToString());
            dsResult = objDAL.GetDataSetForPrc("Prc_Upd_Ceasedt_SubChannel", htParam);
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "alert('Sub Channel ceased.');", true);
        }

        //Unit TYPE GRIDVIEW START
        #region Binddatagrid
        protected void Binddatagrid()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                htParam.Add("@Bizsrc", hdnselectedBizsrc.Value);// Request.QueryString["bizsrc"].ToString().Trim());
                htParam.Add("@Chncls", hdnChnCls.Value);//Request.QueryString["Bizsrc"].ToString());
                //dsmgr = objDAL.GetDataSetForPrc("Prc_getunittype_count_SubChnl", htParam);
                if (dsmgr.Tables.Count > 0 && dsmgr.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = dsmgr;
                    gv.DataBind();
                    ViewState["gv"] = dsmgr;
                    gv.Visible = true;
                }
                else
                {
                    dsmgr.Tables[0].Rows.Add(dsmgr.Tables[0].NewRow());
                    gv.DataSource = dsmgr.Tables[0];
                    gv.DataBind();
                    int columnsCount = gv.Columns.Count;
                    gv.Rows[0].Cells.Clear();
                    gv.Rows[0].Cells.Add(new TableCell());
                    gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
                    gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gv.Rows[0].Cells[0].Font.Bold = true;
                    gv.Rows[0].Cells[0].Text = "No Records Found!";
                    dsmgr.Tables[0].Rows.Clear();
                    gv.Visible = true;
                    ViewState["gv"] = null; //AddedControl by sanoj 290520243
                }
                dsmgr = null;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "lbLAbc_Click", ex);
            }
        }
        #endregion

        //MEMBER TYPE GRIDVIEW START
        protected void BindAgentGrid()
        {
            try
            {
                string strSql = string.Empty;
                DataSet dsResult = new DataSet();
                dsResult.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Add("@BizSrc", hdnselectedBizsrc.Value);//Request.QueryString["Bizsrc"].ToString());
                htParam.Add("@Chncls", hdnChnCls.Value);//Request.QueryString["Bizsrc"].ToString());
                //dsResult = objDAL.GetDataSetForPrc("Prc_getmemtype_count_SubChnl", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        Label3.Visible = true;
                        gvmem.DataSource = dsResult.Tables[0];
                        ViewState["gvmem"] = dsResult.Tables[0];
                        gvmem.DataBind();
                    }
                    else
                    {
                        dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());
                        gvmem.DataSource = dsResult.Tables[0];
                        gvmem.DataBind();
                        int columnsCount = gvmem.Columns.Count;
                        gvmem.Rows[0].Cells.Clear();
                        gvmem.Rows[0].Cells.Add(new TableCell());
                        gvmem.Rows[0].Cells[0].ColumnSpan = columnsCount;
                        gvmem.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
                        gvmem.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gvmem.Rows[0].Cells[0].Font.Bold = true;
                        gvmem.Rows[0].Cells[0].Text = "No Records Found!";
                        dsResult.Tables[0].Rows.Clear();
                        gvmem.Visible = true;
                        ViewState["gvmem"] = null; //AddedControl by sanoj 290520243
                    }
                }
                else
                {
                    Label3.Visible = false;
                    gvmem.DataSource = null;
                    gvmem.DataBind();   
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "ChannelMas.aspx", "lbLAbc_Click", ex);
            }
        }


        protected void lnkbtnActSub_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddlCmnt();", true);
               GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lbBizSrc = (Label)grd.FindControl("lblCompBizSrc");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
            "OpenElement('myModalRaise1','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','member')", true);
        }

        protected void lnkSubLocCmpAct_Click(object sender, EventArgs e)
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lbBizSrc = (Label)grd.FindControl("lblCompBizSrc");
            hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
            "OpenElement('myModalRaise1','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','Unt')", true);
        }
        protected void rblChnlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshGrid1();commented by ajay 17 june 2023
            lnksearchmastergv_Click(null, null);//added by ajay 17 june 2023
        }
        protected void lnksearchmastergv_Click(object sender, EventArgs e)
        {
            Hashtable htParam = new Hashtable();
            DataSet dsdataset = new DataSet();
            htParam.Add("@ChannelType", "C");
            htParam.Add("@channelstatus", rblChnlStatus.SelectedValue.ToString().Trim());//Added by Ajay 11-12-2023
            htParam.Add("@Descsearch", txtchnlsearch.Text.ToString().Trim());
            dsdataset = objDAL.GetDataSetForPrcCLP("prc_ChnClsSearch", htParam);
            Gv_ChannelDetails.DataSource = dsdataset.Tables[0];
            Gv_ChannelDetails.DataBind();
            txtchnlsearch.Text = "";
        }
    }
}

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
using INSCL.DAL;
using System.Xml;
using DataAccessClassDAL;

public partial class Application_Isys_ChannelMgmt_CompanyMaster : BaseClass
{
    ErrLog objErr = new ErrLog();
    DataAccessClass objDAL = new DataAccessClass();
    string strBizsrc = string.Empty;
    string strValue = string.Empty;
    string ErrMsg, strXML = "";
    string AuditType;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.RefreshComGrid();
    }

    protected void lbComBizSrc_Click1(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbChnCls2 = (LinkButton)grd.FindControl("lbComBizSrc");
        Label lblComChannelDesc01 = (Label)grd.FindControl("lblComChannelDesc01");
        Label lblComSortOrder = (Label)grd.FindControl("lblComSortOrder");
        Response.Redirect("CompanySetup.aspx?ChnTyp=O&flag=''&ChnCls=" + lbChnCls2.Text + "&ComChannelDesc01=" + lblComChannelDesc01.Text + "&ComSortOrder=" + lblComSortOrder.Text + "&mdlpopup=mdlpopup");
    }
    protected void DeleteBtn_Click(object sender, EventArgs e)
    {

    }

    private void RefreshComGrid()
    {
        string msg = "";
        try
        {
            //lblMsg.Visible = false;
            DataTable dt = GetComDisplay();
            DataSet dsResult = objDAL.GetDataSetForPrc_DIRECT("Prc_GetCHMSConfigDtl");
            //int noOfCompanies =  Convert.ToInt32(dsResult.Tables[0].Rows[3]["Value"].ToString());commented by ajay 9052023
            this.dgComDetails.DataSource = dt;
            this.dgComDetails.DataBind(); 
            int count = dt.Rows.Count;
            //if (count >= noOfCompanies)   //need to check ..by @Rajkapoor
            //    btnAddNwCmp.Visible = false; //need to check ..by @Rajkapoor
            ShowPageInformation();
            if (dgComDetails.PageCount > 1)  // neet to set > 1 added for testing purposes ..@Rajkapoor
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
            //lblMsg.Visible = true;
            //lblMsg.Text = ex.Message;
            msg = ex.Message;
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public DataTable GetComDisplay()
    {
        //Edited by Vijendra on 06-1202013 to retrieve Company details for given ChannelType Start
        Hashtable htParam1 = new Hashtable();
        DataSet dsdataset = new DataSet();
        try
        {
            htParam1.Add("@ChannelType", "O"); 
            dsdataset = objDAL.GetDataSetForPrcCLP("prc_CompanySetup", htParam1);
            if (dsdataset != null)
            {
                if (dsdataset.Tables[0].Rows.Count > 0)  //added for testing need to reset > 0 by @rajkapoor 
                {
                    tr3.Visible = true;
                    btnAddNwCmp.Visible = true; //amruta
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
        return dsdataset.Tables[0];
    }

    private void ShowPageInformation()
    {
        int intComPageIndex = dgComDetails.PageIndex + 1;
        //lblpgcom.Text = "Page " + intComPageIndex.ToString() + " of " + dgComDetails.PageCount;
    }

    protected void btnAddNwCmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanySetup.aspx?ChnTyp=O&flag=N&mdlpopup=mdlpopup", false);
    }

    protected void dgComDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void lbCompHumanHierarchy_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbComBizSrc");
        hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
        "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','comp')", true);
        //GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        //LinkButton lbBizSrc2 = (LinkButton)grd.FindControl("lbComBizSrc");
        //strBizsrc = lbBizSrc2.Text.ToString().Trim();

        //string strType = "chhum";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funViewHr('" + strBizsrc + "','','" + strType + "');", true);
    }

    protected void lnkActHmnCmp_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbBizSrc2 = (LinkButton)grd.FindControl("lbComBizSrc");
        strBizsrc = lbBizSrc2.Text.ToString().Trim();

        string strType = "chActhum";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funViewHr('" + strBizsrc + "','','" + strType + "');", true);
    }

    #region lbCompLocationHierarchy click Event
    protected void lbCompLocationHierarchy_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbComBizSrc");
        hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
        "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','compdef')", true);
    }
    #endregion

    protected void lnkActLocCmp_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbBizSrc = (LinkButton)grd.FindControl("lbComBizSrc");
        hdnselectedBizsrc.Value = lbBizSrc.Text.ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
        "OpenElement('myModalRaise','ctl00_ContentPlaceHolder1_hdnselectedBizsrc','iframeElement','compAct')", true);
    }

    #region dgComDetails RowDataBound Event
    //added by vijendra on 10-12-2013 to open DeletePopup start
    protected void dgComDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text == "XX" || e.Row.Cells[0].Text == "AG" || e.Row.Cells[0].Text == "BA")
            {
                Session["stBizsrc"] = e.Row.Cells[0].Text;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
            Label lblComChannelDesc01 = (Label)e.Row.FindControl("lblComChannelDesc01");
            if (strValue == "YES")
            {
                l.Enabled = true;
            }
            else if (strValue == "NO")
            {
                l.Enabled = false;
            }

            l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete Company for " + lblComChannelDesc01.Text.Trim() + "?')");
        }
    }
    //added by vijendra on 10-12-2013 to open DeletePopup end
    #endregion

    #region dgComDetails_Sorting
    protected void dgComDetails_Sorting(object sender, GridViewSortEventArgs e)
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

           DataTable dt = GetComDisplay();
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
       #endregion

    #region dgComDetails RowCommand Event
    //Added by vijendra to Delete records in dgComDetails gridview Start 
    protected void dgComDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Session["UserGrp"].ToString() != ConfigurationManager.AppSettings["BlockGroupName"].ToString())
        {
            if (e.CommandName == "Delete")
            {
                string msg = "";
                clsAgentLevelSetup objAgtType = new clsAgentLevelSetup();
                clsChannelSetup channelsetup = new clsChannelSetup();
                GridViewRow row1 = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                Int32 rowind = row1.RowIndex;
                Label lblComChannelDesc01 = (Label)row1.FindControl("lblComChannelDesc01");
                LinkButton lbComBizSrc = (LinkButton)row1.FindControl("lbComBizSrc");
                string channelcode = lbComBizSrc.Text;
                Label lblComSortOrder = (Label)row1.FindControl("lblComSortOrder");
                XmlDocument xDoc = new XmlDocument();
                try
                {
                    ArrayList arrLst = new ArrayList();
                    arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                    arrLst.Add(new prjXml.Collection("BizSrc", channelcode));
                    arrLst.Add(new prjXml.Collection("BizDesc", lblComChannelDesc01.Text.ToString()));
                    arrLst.Add(new prjXml.Collection("SortOrder", lblComSortOrder.Text.ToString()));

                    prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    strXML = xDoc.OuterXml;

                    arrLst.Clear();

                    channelsetup.RowDelete(channelcode, Session["CarrierCode"].ToString());
                    this.RefreshComGrid();
                    //lblMsg.Visible = true;
                    //lblMsg.Text = "Channel is deleted successfully";
                    //Added by Rachana on 16/05/2013 for message popup start
                    lbl_popup.Text = "Channel is deleted successfully<br/><br/>" + "Channel: " + lbComBizSrc.Text + "<br/><br/>Channel description: " + lblComChannelDesc01.Text.ToString() + "<br/><br/>Sort Order: " + lblComSortOrder.Text.ToString();
                    // mdlpopup.Show();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                    //Added by Rachana on 16/05/2013 for message popup end
                }
                catch (Exception ex)
                {
                    //lblMsg.Visible = true;
                    //lblMsg.Text = ex.Message;
                    msg = ex.Message;
                    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                    string sRet = oInfo.Name;
                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    String LogClassName = method.ReflectedType.Name;
                    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

                }
                if (msg == "Channel is deleted successfully")//Added by rachana on 29-05-2013 for inserting audit log entry in DB
                {
                    ErrMsg = "S";
                }
                else
                {
                    ErrMsg = "E";
                }
                if (ErrMsg == "S")
                {
                    AuditType = "DE";
                }
                else
                {
                    AuditType = "DE";
                }
                string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = "", ErrDtl = msg;   //lblMsg.Text
                channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + channelcode, "ChnSu", "Delete,clsChannelSetup.cs", "prc_Saleschannel_Delete", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);

            }
        }
    }
    //Added by vijendra to Delete records in dgComDetails gridview Start
    #endregion

    protected void btnCompprevious_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = dgComDetails.PageIndex;
            dgComDetails.PageIndex = pageIndex - 1;
            RefreshComGrid();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnCompnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgComDetails.PageCount))
            {
                btnCompprevious.Enabled = false;
            }
            int page = dgComDetails.PageCount;
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

    protected void btnCompnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = dgComDetails.PageIndex;
            dgComDetails.PageIndex = pageIndex + 1;
            RefreshComGrid();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnCompprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgComDetails.PageCount))
            {
                btnCompnext.Enabled = false;
            }
            int page = dgComDetails.PageCount;

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
}
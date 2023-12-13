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
using System.Data.SqlClient;
using INSCL.DAL;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;

namespace INSCL
{
    public partial class SearchUnitNew : Base
    {
        #region DECLARATIONS
        Hashtable htable = new Hashtable();
        private multilingualManager olng;
        private string strUserLang;
		string BizSrc, ChnCls, UnitType;
		string ErrMsg, AuditType,strXML = "";
		XmlDocument doc = new XmlDocument();
        EncodeDecode ObjDec = new EncodeDecode();
        DataAccessClass objDAL = new DataAccessClass();
        DataSet dsResult = new DataSet();
        string strDesc01 = string.Empty;
        string strModule = string.Empty;
        string strValue = string.Empty;
		INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        string chnnl, chnlcls;///added by akshay
        ErrLog objErr = new ErrLog();
         #endregion   
        
        #region PAGE LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "SearchUnitNew.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                btnCopy.Visible = false;
                if (!IsPostBack)
                {
                    divCopy.Style.Add("display", "none");
                    divcmpsrchhdrcollapse.Style.Add("display", "none");
                    EnableDisableButton();
                    InitializeControl();
                    Loaddata();
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnAddnew.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "SearchUnitNew.aspx", "Page Load", ex);
            }
        }
        #endregion

        #region EnableDisableButton
        private void EnableDisableButton()
        {
            dsResult = null;

            strDesc01 = "Enable Modification of Channel Maintenance";
            strModule = "CHMS";
            dsResult = objCommonU.GetConfigSettings(strDesc01, strModule);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                strValue = dsResult.Tables[0].Rows[0]["Value"].ToString().Trim();
                HttpContext.Current.Session["StrValue"] = strValue;
            }
            if (strValue == "YES")
            {
                btnAddnew.Enabled = true;
            }
            else if (strValue == "NO")
            {
                btnAddnew.Enabled = false;

            }

        }
        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            lblSaleschannel.Text = (olng.GetItemDesc("lblSaleschannel.Text"));
            lblChnnlClass.Text = (olng.GetItemDesc("lblChnnlClass.Text"));
            lblChannelUnitTypesetup.Text = (olng.GetItemDesc("lblChannelUnitTypesetup"));
            lblChannelUnitTypeSearch.Text = (olng.GetItemDesc("lblChannelUnitTypeSearch"));
           // lblChnlType.Text = (olng.GetItemDesc("lblChnlType.Text"));
            lblChannelUnitTypesetup.Text = "UNIT TYPE SETUP";
            lblChannelUnitTypeSearch.Text = "UNIT TYPE SEARCH RESULTS";
         }
        #endregion

        #region ROWCOMMAND
        protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["UserGrp"].ToString() != ConfigurationManager.AppSettings["BlockGroupName"].ToString())
            {
				clsChannelSetup channelsetup = new clsChannelSetup();
                if (e.CommandName == "Delete")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    try
                    {
                        int intPos = row.Cells[2].Text.IndexOf('>');
                        int intPos2 = row.Cells[2].Text.IndexOf('<', 1);
                        ////UnitType = row.Cells[2].Text.Substring(intPos + 1, intPos2 - intPos - 1);
                        Label lblunityp = (Label)row.FindControl("lbluntyp");
                        UnitType = lblunityp.Text.Trim();
                        BizSrc = row.Cells[0].Text;
                        ChnCls = row.Cells[1].Text;

                        string UntDesc = row.Cells[6].Text;
                        //Added code by venkat on 06/02/08
                        ArrayList arrLst = new ArrayList();
                        arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                        arrLst.Add(new prjXml.Collection("BizSrc", BizSrc));
                        arrLst.Add(new prjXml.Collection("UnitType", UnitType));
                        arrLst.Add(new prjXml.Collection("ChnCls", ChnCls));
                        arrLst.Add(new prjXml.Collection("UnitRank", row.Cells[3].Text.ToString()));
                        arrLst.Add(new prjXml.Collection("UnitLevel", row.Cells[4].Text.ToString()));
                        arrLst.Add(new prjXml.Collection("UnitTypeDesc", row.Cells[5].Text.ToString()));
                        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                        //objGetXml.CreateXmlAttribute(arrLst, Server.MapPath("SearchUnitNew.xml"), 7);
                        //doc.Load(Server.MapPath("SearchUnitNew.xml"));
                        //strXML = doc.OuterXml;

                        XmlDocument xDoc = new XmlDocument();
                        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                        strXML = xDoc.OuterXml;

                        arrLst.Clear();
                        //Ended code by venkat
                        channelsetup.UnitTypeDelete(UnitType, Session["CarrierCode"].ToString(), BizSrc, ChnCls);
                        this.RefreshGrid();
                        lblMessage.Visible = true;
                        lblMessage.Text = "Channel Unit Type Setup Deleted successfully";
                        //lblpopup.Text = "Channel Unit Type Setup Deleted successfully" + "</br></br> Unit Description : " + UntDesc.ToString().Trim() + "</br></br> Channel :" + BizSrc.ToString().Trim() + "</br></br> Sub Class :" + ChnCls.ToString().Trim();
                        //mdlpopup.Show();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = ex.Message;
                        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                        string sRet = oInfo.Name;
                        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                        String LogClassName = method.ReflectedType.Name;
                        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    }
                    if (lblMessage.Text == "Channel Unit Type Setup Deleted successfully")
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
                    string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";
                    channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + BizSrc + ChnCls + UnitType, "chnUntSu", "Delete,clsChannelSetup.cs", "prc_UnitNew_Delete", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
				}
            }
        }
        #endregion
		
        #region SEARCH Button
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                divDemo.Visible = true;
                divsrch.Attributes.Add("display", "block");
                divcmpsrchhdrcollapse.Style.Add("display", "block");
                DataSet dsdataset = new DataSet();
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                Session["grid1"] = "";
                this.RefreshGrid();
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

        #region REFRESHGRID
       private void RefreshGrid()
        {
           //Added by Kalyani on 16-12-2013 to display Company or Channel selection start
            if (rdbChnlTyp.SelectedValue == "0")
            {
                htable.Add("@Flag", "O");
            }
            else
            {
                htable.Add("@Flag", "C");
            }
            //Added by Kalyani on 16-12-2013 to display Company or Channel selection end

            string BizSrc,ChnCls;
            if (this.ddlSalesChannel.SelectedIndex == 0)
            {
                BizSrc = "";
            }
            else
            {
                BizSrc = this.ddlSalesChannel.SelectedValue;
            }
            if (this.ddlChnnlClass.SelectedIndex == 0)
            {
                ChnCls = "";
            }
            else
            {
                ChnCls = this.ddlChnnlClass.SelectedValue;
            }
            lblMessage.Visible = false;
            DataSet dsdataset = new DataSet();

            htable.Add("@BizSrc", BizSrc);
            htable.Add("@ChnCls", ChnCls);
            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            dsdataset = objDAL.GetDataSetForPrc("prc_UnitSearch",htable);
            htable.Clear();
            if (dsdataset.Tables.Count > 0)
            {
                if (dsdataset.Tables[0].Rows.Count > 0)
                {
                    dgDetails.AllowSorting = true;
                    dgDetails.DataSource = dsdataset.Tables[0];
                    //Added by Kalyani on 14-12-2013 to chnage gridview header text on radio button selection start
                    if (rdbChnlTyp.SelectedValue == "0")////added by akshay on 020514
                    {
                        dgDetails.Columns[0].HeaderText = "Company code";
                    }
                    else if (rdbChnlTyp.SelectedValue == "1")
                    { 
                         dgDetails.Columns[0].HeaderText = "Channel code";
                    }
                    //Added by Kalyani on 14-12-2013 to chnage gridview header text on radio button selection end
                    dgDetails.DataBind();
                    ShowPageInformation();
                    //tbldgDtls.Visible = true;
                    //trDetails.Visible = true;
                   // trDgDetails.Visible = true;
                    //tbldgDtls1.Visible = true;
                    //trBtnNew.Visible = true;
                    btnAddnew.Visible = true;
                    //btnCopy.Visible = true;     commented by Raj on 05-10-21

                    if (dgDetails.PageCount > 1)
                    {
                        btnnext.Enabled = true;
                    }
                    else
                    {
                        btnnext.Enabled = false;
                        txtPage.Text = "1";
                    }
                }
                else
                {
                    dgDetails.AllowSorting = false;
                    ShowNoResultFound(dsdataset.Tables[0], dgDetails);
                    txtPage.Text = "1";
                    btnprevious.Enabled = false;
                    btnnext.Enabled = false;
                    //dgDetails.DataSource = null;
                    //dgDetails.DataBind();
                    //lblPageInfo.Text = "";
                    //tbldgDtls.Visible = false;
                    //trDetails.Visible = false;
                    //trDgDetails.Visible = false;
                    btnAddnew.Visible = true;
                    //btnCopy.Visible = true; commented by Raj on 05 - 10 - 21
                   // trBtnNew.Visible = true;
                   //lblMessage.Visible = true;
                   //lblMessage.Text = "0 record found.";
                   // tbldgDtls1.Visible = true;
                }
            }
            else
            {
                dgDetails.AllowSorting = false;
                ShowNoResultFound(dsdataset.Tables[0], dgDetails);
                txtPage.Text = "1";
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                //lblPageInfo.Text = "";
                //tbldgDtls.Visible = false;
                //trDetails.Visible = false;
                //trDgDetails.Visible = false;
                btnAddnew.Visible = true;
               // trBtnNew.Visible = true;
                //lblMessage.Visible = true;
                //lblMessage.Text = "0 record found.";
            }
            ShowPageInformation();
            Session["grid1"] = dsdataset.Tables[0];
        }
        #endregion

        #region ShowNoResultFound
        private void ShowNoResultFound(DataTable source, GridView gv)
       {
           source.Rows.Add(source.NewRow());
           gv.DataSource = source;
           gv.DataBind();
           int columnsCount = gv.Columns.Count;
           int rowsCount = gv.Rows.Count;
           gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
           gv.Rows[0].Cells[columnsCount - 1].Text = "";
           gv.Rows[0].Cells[columnsCount - 2].Text = "";
           gv.Rows[0].Cells[0].Text = "No unit type have been defined";
           source.Rows.Clear();
       }
        #endregion

        #region GetDisplay
        public DataTable GetDisplay(string BizSrc, string ChnCls)
        {
            DataSet dsdataset = new DataSet();
            if (rdbChnlTyp.SelectedValue == "0")
            {
                htable.Add("@Flag", "O");
            }
            else
            {
                htable.Add("@Flag", "C");
            }
            htable.Add("@BizSrc", BizSrc);
            htable.Add("@ChnCls", ChnCls);
            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            dsdataset = objDAL.GetDataSetForPrc("prc_UnitSearch",htable);
            htable.Clear();
            return dsdataset.Tables[0];          

        }
        #endregion

        #region RowDataBound
        protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    var strChnCls1 = string.Empty;
                    if (e.Row.Cells[0].Text != "&nbsp;")
                    {
                        string strBiz = e.Row.Cells[0].Text.ToString();
                        strChnCls1 = e.Row.Cells[1].Text.ToString();
                        string unttyp = e.Row.Cells[7].Text.ToString();
                        var strChnCls = strChnCls1.Replace("amp;", "");
                        var strchnclscode = e.Row.Cells[9].Text.ToString();
                        //added by meena to store chnclscode 19/3/18
                       
                        getValue(strBiz, strChnCls);
                       // string Flag = "Y";
                        //e.Row.Cells[2].Text = "<i class=\"fa fa-edit\"></i>&nbsp;<a href=\"UnitNew.aspx?Code=" + e.Row.Cells[2].Text + "&SalesChannel=" + e.Row.Cells[0].Text + "&ChannelClass=" + e.Row.Cells[1].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&BizSrc=" + chnnl + "&Chanl=" + chnlcls + "&unttyp=" + unttyp.ToString().Trim() + "&SubClass=" + ddlChnnlClass.SelectedValue + "\">" + e.Row.Cells[2].Text + "</a>";
                       //Comented by usha  
                        // e.Row.Cells[2].Text = "<i class=\"fa fa-edit\"></i>&nbsp;<a href=\"UnitNew.aspx?Code=" + e.Row.Cells[2].Text + "&SalesChannel=" + e.Row.Cells[0].Text + "&ChannelClass=" + e.Row.Cells[1].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&BizSrc=" + chnnl + "&Chanl=" + chnlcls + "&unttyp=" + unttyp.ToString().Trim() + "&SubClass=" + strchnclscode+ "&Flag=" + "Y" + "\">" + e.Row.Cells[2].Text + "</a>"; /*+"&Flag=" + "Y"*/
                        e.Row.Cells[2].Text = "<i class=\"fa fa-edit\"></i>&nbsp;<a href=\"UnitNew.aspx?Code=" + e.Row.Cells[2].Text + "&SalesChannel=" + e.Row.Cells[0].Text + "&ChannelClass=" + e.Row.Cells[1].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&BizSrc=" + chnnl + "&Chanl=" + chnlcls + "&unttyp=" + unttyp.ToString().Trim() + "&SubClass=" + chnlcls + "&Flag=" + "Y" + "\">" + e.Row.Cells[2].Text + "</a>"; /*+"&Flag=" + "Y"*/

                    }

                    //string strChnCls = e.Row.Cells[1].Text.ToString();
                    //////e.Row.Cells[2].Text = "<i class=\"fa fa-edit\"></i>&nbsp;<a href=\"UnitNew.aspx?Code=" + e.Row.Cells[2].Text + "&SalesChannel=" + e.Row.Cells[0].Text + "&ChannelClass=" + e.Row.Cells[1].Text + "&Cancel=" + ddlSalesChannel.SelectedValue + "&BizSrc=" + chnnl + "&Chanl=" + chnlcls + "&SubClass=" + ddlChnnlClass.SelectedValue + "\">" + e.Row.Cells[2].Text + "</a>";

                    //added by sanoj 26052023 for tool tip
                    //if (dgDetails.Rows.Count > 0)
                    //{ 
                    //    for (int i = 0; i < dgDetails.Rows.Count; i++)
                    //    {
                    //        if (i == 0)
                    //        {
                    //            LinkButton lnkAddMemType = (LinkButton)dgDetails.Rows[i].FindControl("lnkAddMemType");
                    //            string tooltipText = "Add new unit type above"; // Replace with your tooltip text
                    //            lnkAddMemType.ToolTip = tooltipText;
                    //        }
                    //        else
                    //        {
                    //            LinkButton lnkAddMemType = (LinkButton)dgDetails.Rows[i].FindControl("lnkAddMemType");
                    //            string tooltipText = "Add new unit type below"; // Replace with your tooltip text
                    //            lnkAddMemType.ToolTip = tooltipText;
                    //        }
                    //    }
                    //}
                    if (dgDetails.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgDetails.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                // Set tooltip for the first row's LinkButton
                                LinkButton lnkbtnabove = (LinkButton)dgDetails.Rows[i].FindControl("lnkbtnabove");
                                lnkbtnabove.Visible = true;
                                string tooltipText = "Add new member type above"; // Replace with your tooltip text
                                lnkbtnabove.ToolTip = tooltipText;
                                Image imgabove = (Image)dgDetails.Rows[i].FindControl("imgabove");
                                imgabove.ImageUrl = "../../../assets/img/Add_member_type.png";
                            }
                        }
                    }
                    //Endded by sanoj 26052023 for tool tip
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                    Label lblUnt = (Label)e.Row.FindControl("lblUntTyp");
                    Label lblChncls = (Label)e.Row.FindControl("lblChncls");

                    //lblChncls.Visible = false;  //comented by sanoj 24052023
                    if (HttpContext.Current.Session["StrValue"].ToString() == "YES")
                    {
                        l.Enabled = true;
                    }
                    else if (HttpContext.Current.Session["StrValue"].ToString() == "NO")
                    {
                        l.Enabled = false;

                    }
                    //l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete Unit Type" + lblUnt.Text.Trim() + "?')");//comented by sanoj 24052023
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
        #endregion

        #region Addnew
        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnitNew.aspx?chncls=" + ddlSalesChannel.SelectedValue.ToString().Trim() + "&SubClass=" + ddlChnnlClass.SelectedValue + "&flag=N");
        }
        #endregion

        #region DeleteUnitType
        protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        #endregion

        #region SORTING
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
                string ChnCls = this.ddlChnnlClass.SelectedValue;
                if (BizSrc == "All")
                {
                    BizSrc = "";
                }
                if (ChnCls == "All")
                {
                    ChnCls = "";
                }
                DataTable dt = GetDisplay(BizSrc, ChnCls);
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
        #endregion

        #region PAGEINDEX
        protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string BizSrc = this.ddlSalesChannel.SelectedValue;
                string ChnCls = this.ddlChnnlClass.SelectedValue;
                if (BizSrc == "All")
                {
                    BizSrc = "";
                }
                if (ChnCls == "All")
                {
                    ChnCls = "";
                }
                DataTable dt = GetDisplay(BizSrc, ChnCls);
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

        #region PAGEINFORMATION
        private void ShowPageInformation()
        {
            int intPageIndex = dgDetails.PageIndex + 1;
            //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        }
        #endregion

        #region CLEAR Button
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchUnitNew.aspx");
        }
        #endregion

        #region SelectedIndex
        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChnnlClass.Items.Clear();
                SqlDataReader dtRead;
                //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END

                if (dtRead.HasRows)
                {
                    ddlChnnlClass.DataSource = dtRead;
                    ddlChnnlClass.DataTextField = "ChnlDesc";
                    ddlChnnlClass.DataValueField = "ChnCls";
                    ddlChnnlClass.DataBind();
                }
                dtRead = null;
                ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                //trDetails.Visible = false;
                //trDgDetails.Visible = false;
                btnAddnew.Visible = false;
                //btnCopy.Visible = false; commented by Raj on 05 - 10 - 21
                //trBtnNew.Visible = false;
                divcmpsrchhdrcollapse.Style.Add("display", "none");
                divDemo.Visible = false;
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

        #region rdbChnlTyp_SelectedIndexChanged
        protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbChnlTyp.SelectedValue == "0")
            {
                ddlChnnlClass.Items.Clear();
                ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
                //dgDetails.Visible = false;
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "0");
                //objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "O");

                ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
            }
            else
            {
                ddlChnnlClass.Items.Clear();
                ddlChnnlClass.Items.Insert(0, new ListItem("All", ""));
                //dgDetails.Visible = false;
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                ddlSalesChannel.Items.Insert(0, new ListItem("All", ""));
            }
        }
        #endregion

        #region getValue method
        /// added by akshay
        private void getValue(string strBiz, string strChnCls)
        {
            dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@ChnlDesc", strBiz);
            htParam.Add("@ChnClsDesc", strChnCls);
            dsResult.Clear();
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetBizChnlValue", htParam);
            chnnl = dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
            chnlcls = dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
            //dsResult.Clear();

        }
        #endregion

        #region btnCopy_Click
        protected void btnCopy_Click(object sender, EventArgs e)
        {
            //trCopy.Visible = true;
            //trCopyBtn.Visible = true;
            divCopy.Style.Add("display", "block");
            objCommonU.GetSalesChannel(ddlChnl, "", 1);
            ddlSubclass.Items.Insert(0, new ListItem("All", "All"));
            ddlChnl.Items.Insert(0, new ListItem("All", "All"));
        }
        #endregion

        #region ddlChnl_SelectedIndexChanged
        protected void ddlChnl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubclass.Items.Clear();
            SqlDataReader dtRead;
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist START
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@BizSrc", ddlChnl.SelectedValue);
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
            //Added By Sandeep Garg on 01-07-2013 To get Channel sub class dropdownlist END

            if (dtRead.HasRows)
            {
                ddlSubclass.DataSource = dtRead;
                ddlSubclass.DataTextField = "ChnlDesc";
                ddlSubclass.DataValueField = "ChnCls";
                ddlSubclass.DataBind();
            }
            dtRead = null;
            ddlSubclass.Items.Insert(0, new ListItem("All", "All"));
        }
        #endregion

        #region btnUpdate_Click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable htprm = new Hashtable();
                DataSet dsprm = new DataSet();
                htprm.Clear();
                dsprm.Clear();
                htprm.Add("@BizSrc ", ddlChnl.SelectedValue);
                htprm.Add("@ChnCls", ddlSubclass.SelectedValue);
                htprm.Add("@BizSrcOld", ddlSalesChannel.SelectedValue);
                htprm.Add("@ChnClsOld", ddlChnnlClass.SelectedValue);
                htprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                dsprm = objDAL.GetDataSetForPrc("prc_CopyUntDtls", htprm);
                divCopy.Style.Add("display", "none");
                ddlSalesChannel.SelectedValue = ddlChnl.SelectedValue;
                ddlSalesChannel_SelectedIndexChanged(sender, e);
                ddlChnnlClass.SelectedValue = ddlSubclass.SelectedValue;
                RefreshGrid();
                //btnCopy.Enabled = false; commented by Raj on 05 - 10 - 21
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

        #region btnOldHier_Click
        protected void btnOldHier_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "funpopup();", true);
        }
        #endregion

        #region btnnext_Click
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex + 1;
                RefreshGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnnext.Enabled = false;
                }
                int page = dgDetails.PageCount;
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

        #region btnprevious_Click
        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = dgDetails.PageIndex;
                dgDetails.PageIndex = pageIndex - 1;
                RefreshGrid();
                //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                btnnext.Enabled = true;
                if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
                {
                    btnprevious.Enabled = false;
                }
                int page = dgDetails.PageCount;
                if (txtPage.Text == "1")
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
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region loaddata 
        private void Loaddata()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            if (Request.QueryString["chncls"] != null)
            {
                string strSubFlag = Request.QueryString["SubClass"].ToString();
                string strFlag = Request.QueryString["chncls"].ToString();
                if (strFlag == "All" && strSubFlag == "All")
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader dtRead;
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));

                    this.RefreshGrid();
                }
                else
                {
                    if (strSubFlag != "All")
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.SelectedValue = strSubFlag;
                        ddlChnnlClass.Items.Clear();
                        SqlDataReader dtRead;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                        if (dtRead.HasRows)
                        {
                            ddlChnnlClass.DataSource = dtRead;
                            ddlChnnlClass.DataTextField = "ChnlDesc";
                            ddlChnnlClass.DataValueField = "ChnCls";
                            ddlChnnlClass.DataBind();
                        }
                        dtRead = null;
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.RefreshGrid();
                    }
                    else
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.Items.Clear();
                        SqlDataReader dtRead;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                        if (dtRead.HasRows)
                        {
                            ddlChnnlClass.DataSource = dtRead;
                            ddlChnnlClass.DataTextField = "ChnlDesc";
                            ddlChnnlClass.DataValueField = "ChnCls";
                            ddlChnnlClass.DataBind();
                        }
                        dtRead = null;
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.RefreshGrid();
                    }
                }

            }
            //QueryString value is not null

            else if (Request.QueryString["Code"] != null)
            {
                string strFlag = Request.QueryString["Code"].ToString();
                string strSubFlag = Request.QueryString["SubClass"].ToString();
                if (strFlag == "All" && strSubFlag == "All")
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                    ddlChnnlClass.Items.Clear();
                    SqlDataReader dtRead;
                    Hashtable htParam = new Hashtable();
                    htParam.Clear();
                    htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                    if (dtRead.HasRows)
                    {
                        ddlChnnlClass.DataSource = dtRead;
                        ddlChnnlClass.DataTextField = "ChnlDesc";
                        ddlChnnlClass.DataValueField = "ChnCls";
                        ddlChnnlClass.DataBind();
                    }
                    dtRead = null;
                    ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                    this.RefreshGrid();
                }
                else
                {
                    if (strSubFlag != "All")
                    {

                        ddlSalesChannel.SelectedValue = strFlag;
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.Items.Clear();
                        ddlChnnlClass.SelectedValue = strSubFlag;
                        SqlDataReader dtRead;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                        if (dtRead.HasRows)
                        {
                            ddlChnnlClass.DataSource = dtRead;
                            ddlChnnlClass.DataTextField = "ChnlDesc";
                            ddlChnnlClass.DataValueField = "ChnCls";
                            ddlChnnlClass.DataBind();
                        }
                        dtRead = null;
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.RefreshGrid();
                    }
                    else
                    {
                        ddlSalesChannel.SelectedValue = strFlag;
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                        ddlChnnlClass.Items.Clear();
                        SqlDataReader dtRead;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htParam);
                        if (dtRead.HasRows)
                        {
                            ddlChnnlClass.DataSource = dtRead;
                            ddlChnnlClass.DataTextField = "ChnlDesc";
                            ddlChnnlClass.DataValueField = "ChnCls";
                            ddlChnnlClass.DataBind();
                        }
                        dtRead = null;
                        ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
                        this.RefreshGrid();
                    }

                }
            }
            else
            {
                objCommonU.GetSalesChannel(ddlSalesChannel, "", 0, Session["UserID"].ToString(), "1");
                ddlSalesChannel.Items.Insert(0, new ListItem("All", "All"));
                ddlChnnlClass.Items.Insert(0, new ListItem("All", "All"));
            }
        }
        #endregion 
    }
}
       
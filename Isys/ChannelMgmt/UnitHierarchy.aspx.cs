using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using INSCL.DAL;

public partial class Application_INSC_ChannelMgmt_BranchUnitHierarchy : BaseClass
{
    #region Variable Declaration
    int ddlItemCount = 0;
    int iMaxUnitLevel = 7;
    
    String strType = "Branch";
    String strLat = String.Empty;
    String strLan = String.Empty;
    String strCount = String.Empty;
    String ErrMsg = String.Empty;
    String AuditType = String.Empty;
    String strXML = String.Empty;
    private String strUserLang = String.Empty;
    String strValue = String.Empty;
    String strUnitName = String.Empty;
    String strAggregatedAddress = String.Empty;
    String strAggregatedPostalAddress = String.Empty;

    XmlDocument doc = new XmlDocument();
    private multilingualManager olng;
    DataAccessClass objDAL = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    clsUnitMaint objclsUM = new clsUnitMaint();
    DataAccessClass dataAccess = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    #endregion
    
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        //divPage.Style.Add("display", "none");
        


        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "UnitMaint.aspx", strUserLang);
        Session["CarrierCode"] = '2';
        lblMsg.Visible = false;
        lblMsg.Text = String.Empty;
        if (!IsPostBack)
        {
            btnSearch.Attributes.Add("onClick", "javascript: return funValidate()");
            div3.Style.Add("display", "none");
            ViewState["NextUnitLevel"] = "1";
            InitializeControl();
            lblMsg.Visible = false;
            //trDetails.Visible = false;
            //trDgDetails.Visible = false;
            //tbDetails.Visible = false;
            try
            {
                if (Request.QueryString["Bizsrc"] == null && Request.QueryString["ChnCls"] == null)
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, String.Empty, 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));//---->Added By Parag @ 05022014

                    //trDetails.Visible = false;
                    //trDgDetails.Visible = false;
                   //// trBtnNew.Visible = false;
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                    if (Request.QueryString["ChannelCode"] != null && Request.QueryString["ULevel"] != null && Request.QueryString["UnitCode"] != null)
                    {
                        objclsUM.GetUnitLevelDDL(ddlUnitLevel, Request.QueryString["ChannelCode"]);
                        ddlChnnlSubClass.Items.Clear();
                        SqlDataReader dtRead;
                        //nitin
                        //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 start
                        Hashtable htunit = new Hashtable();
                        htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htunit.Add("@BizSrc", Request.QueryString["ChannelCode"]);//Changed by rachana on 12-07-2013 to redirect page to same with grid
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
                        if (ddlChnnlSubClass.Items.Count < 1)
                        {
                            ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                        }
                        ddlSalesChannel.SelectedValue = Request.QueryString["ChannelCode"];
                        ddlChnnlSubClass.SelectedValue = Request.QueryString["SubCls"];
                        Hashtable htable = new Hashtable();
                        htable.Clear();
                        htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                        htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);
                        DataSet dsResult = new DataSet();
                        //nitin
                        dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                                foreach (ListItem lstItem in ddlUnitLevel.Items)
                                {
                                    if (lstItem.Text == Request.QueryString["ULevel"])
                                    {
                                        lstItem.Selected = true;
                                    }
                                }
                            }
                        }
                        ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                        ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));//---->Added by Parag @ 05022014

                        dsResult = null;
                        htable.Clear();
                        htable = null;
                        //Change of Convert.ToInt32(Request.QueryString["ULevel"] to Convert.ToDecimal(Request.QueryString["ULevel"] due to Addition of State in Tied 
                        //added by rachana on 07-01-2013 for SELECT Top 1 UnitRank start
                        htunit.Add("@ULevel", Convert.ToString(Convert.ToDecimal(Request.QueryString["ULevel"])));
                        htunit.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankonChnlDesc", htunit); // Proc Chnaged by Kalyani on 13-12-2013 to show AO,BO,CO as sub unit of RO
                        htunit.Clear();
                        //added by rachana on 07-01-2013 for SELECT Top 1 UnitRank end                            

                        if (dtRead.Read())
                        {
                            ViewState["NewUnitRank"] = Decimal.Parse(dtRead[0].ToString());
                            ViewState["NewUnitLevel"] = Decimal.Parse(dtRead[1].ToString());//Added by Kalyani on 13-12-2013
                        }
                        dtRead.Close();
                        Hashtable htParam = new Hashtable();
                        dsResult = new DataSet();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@RptUnitCode", Request.QueryString["RptUntCode"]);
                        htParam.Add("@RptUnitType", Request.QueryString["RptUntType"]);
                        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
                        htParam.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                        htParam.Add("@ChnnlClass", ddlChnnlSubClass.SelectedValue);

                        try
                        {
                            if (ddlUnitLevel.SelectedItem.Text != "Select")
                            {
                                htParam.Add("@UnitCode", String.Empty);
                                ddlItemCount = ddlUnitLevel.Items.Count;
                            }
                            else
                            {
                                htParam.Add("@UnitCode", txtUnitCode.Text);
                            }

                            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_enqUnitList", htParam);
                            if (dsResult.Tables.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    if (Request.QueryString["fgPage"].ToString() == "A")
                                    {
                                        ddlUnitLevel.SelectedValue = ViewState["NewUnitLevel"].ToString();//Added by Kalyani on 13-12-2013
                                    }
                                    else if (Request.QueryString["fgPage"].ToString() == "C")
                                    {
                                        ddlUnitLevel.SelectedValue = Request.QueryString["ULevel"];
                                    }
                                    rdbUnit.Visible = true;
                                    dgDetails.DataSource = dsResult.Tables[0];
                                    dgDetails.DataBind();

                                    //trDetails.Visible = true;
                                    //trDgDetails.Visible = true;
                                    //trBtnNew.Visible = true;
                                    //tbDetails.Visible = true;
                                }
                                else
                                {
                                    dgDetails.DataSource = null;
                                    dgDetails.DataBind();
                                    //trDetails.Visible = true;
                                    //trDgDetails.Visible = true;
                                    //trBtnNew.Visible = true;
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "0 record found.";
                                    //tbDetails.Visible = true;
                                    rdbUnit.Visible = true;
                                    ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                    rdbUnit.SelectedValue = ViewState["NewUnitRank"].ToString();
                                }
                            }
                            else
                            {
                                dgDetails.DataSource = null;
                                dgDetails.DataBind();
                                //trDetails.Visible = true;
                                //trDgDetails.Visible = true;
                                //trBtnNew.Visible = true;
                                lblMsg.Visible = true;
                                lblMsg.Text = "0 record found.";
                                //tbDetails.Visible = true;
                                rdbUnit.Visible = true;
                                ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                rdbUnit.SelectedValue = ViewState["NewUnitRank"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = ex.Message;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Visible = true;
                            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                            string sRet = oInfo.Name;
                            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                            String LogClassName = method.ReflectedType.Name;
                            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                        }
                        dsResult.Clear();
                        dsResult = null;
                        htParam.Clear();
                        htParam = null;
                    }
                }
                else if (Request.QueryString["Bizsrc"] != null && Request.QueryString["ChnCls"] != null)
                {
                    ViewState["TPBizSrc"] = Request.QueryString["BizSrc"].ToString();
                    ViewState["TPChnCls"] = Request.QueryString["ChnCls"].ToString();
                    //trDetails.Visible = false;
                    //trDgDetails.Visible = false;
                    //trBtnNew.Visible = false;
                    SqlDataReader dtRead;
                    //added by rachana on 07-01-2013 for SELECT BizSrc, ChannelDesc01 start
                    Hashtable htunit = new Hashtable();
                    htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htunit.Add("@BizSrc", Request.QueryString["Bizsrc"].ToString());
                    dtRead = objDAL.Common_exec_reader_prc("Prc_ddlSaleschnnunitmaint", htunit);
                    htunit.Clear();
                    //added by rachana End
                    if (dtRead.HasRows)
                    {
                        ddlSalesChannel.DataSource = dtRead;
                        ddlSalesChannel.DataTextField = "ChnlDesc";
                        ddlSalesChannel.DataValueField = "ChnCls";
                        ddlSalesChannel.DataBind();
                    }
                    dtRead = null;
                    ddlSalesChannel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));//---->Added by Parag @ 05022014
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                    if (Request.QueryString["SubCls"] != null)
                    {
                        //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 start
                        htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htunit.Add("@BizSrc", Request.QueryString["Bizsrc"]);
                        htunit.Add("@ChnCls", String.Empty);
                        htunit.Add("@flag", 'N');
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetChnlDescunitmaint", htunit);
                        htunit.Clear();
                        //added by rachana End

                        if (dtRead.HasRows)
                        {
                            ddlChnnlSubClass.DataSource = dtRead;
                            ddlChnnlSubClass.DataTextField = "ChnlDesc";
                            ddlChnnlSubClass.DataValueField = "ChnCls";
                            ddlChnnlSubClass.DataBind();
                        }
                        dtRead = null;

                        if (ddlChnnlSubClass.Items.Count < 1)
                        {
                            ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                        }

                    }
                    if (Request.QueryString["ChannelCode"] != null && Request.QueryString["ULevel"] != null && Request.QueryString["UnitCode"] != null)
                    {

                        ddlSalesChannel.SelectedValue = Request.QueryString["ChannelCode"];
                        ddlChnnlSubClass.SelectedValue = Request.QueryString["SubCls"];
                        Hashtable htable = new Hashtable();
                        htable.Clear();
                        htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                        htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);
                        DataSet dsResult = new DataSet();
                        //nitin
                        dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                                foreach (ListItem lstItem in ddlUnitLevel.Items)
                                {
                                    if (lstItem.Text == Request.QueryString["ULevel"])
                                    {
                                        lstItem.Selected = true;
                                    }
                                }
                            }
                        }
                        ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                        ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));//----->Added by Parag @ 05022014

                        dsResult = null;
                        htable.Clear();
                        htable = null;
                        //added by rachana on 07-01-2013 for SELECT Top 1 UnitRank start
                        htunit.Clear();
                        htunit.Add("@ULevel", Convert.ToString(Convert.ToDecimal(Request.QueryString["ULevel"])));
                        htunit.Add("@BizSrc", Request.QueryString["BizSrc"].ToString());
                        htunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankonChnlDesc", htunit);

                        //added by rachana on 07-01-2013 for SELECT Top 1 UnitRank end   
                        if (dtRead.Read())
                        {
                            ViewState["NewUnitRank"] = Decimal.Parse(dtRead[0].ToString());
                        }
                        dtRead.Close();
                        Hashtable htParam = new Hashtable();
                        dsResult = new DataSet();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        if (Request.QueryString["fgPage"].ToString() == "A")
                        {
                            htParam.Add("@UnitLevel", ViewState["NewUnitRank"].ToString());
                        }
                        else if (Request.QueryString["fgPage"].ToString() == "C")
                        {
                            htParam.Add("@UnitLevel", Convert.ToInt16(Request.QueryString["ULevel"]));
                        }
                        htParam.Add("@RptUnitCode", Request.QueryString["RptUntCode"]);
                        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
                        htParam.Add("@BizSrc", Request.QueryString["BizSrc"]);
                        htParam.Add("@MaxUnitLvl", 7);
                        htParam.Add("@ChnnlClass", ddlChnnlSubClass.SelectedValue);
                        htParam.Add("@UnitCode", txtUnitCode.Text);
                        try
                        {
                        
                            htParam.Add("@UnitLevel", rdbUnit.SelectedValue);//Added by Kalyani on 16-12-2013 to add unitlevel value
                            htParam.Add("@Flag", 2);//Added by Kalyani on 17-12-2013 to display (AO,BO,CO) record on RO click
                            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_enqUnitList", htParam);
                            if (dsResult.Tables.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    if (Request.QueryString["fgPage"].ToString() == "A")
                                    {
                                        ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                        rdbUnit.SelectedValue = ViewState["NewUnitRank"].ToString();
                                    }
                                    else if (Request.QueryString["fgPage"].ToString() == "C")
                                    {
                                        ddlUnitLevel.SelectedValue = Request.QueryString["ULevel"];
                                        rdbUnit.SelectedValue = Request.QueryString["ULevel"];
                                    }
                                    rdbUnit.Visible = true;
                                    dgDetails.DataSource = dsResult.Tables[0];
                                    dgDetails.DataBind();
                                   // trDetails.Visible = true;
                                  //   trDgDetails.Visible = true;
                                   // trBtnNew.Visible = true;
                                   // tbDetails.Visible = true;
                                }
                                else
                                {
                                    dgDetails.DataSource = null;
                                    dgDetails.DataBind();
                                   // trDetails.Visible = true;
                                  //   trDgDetails.Visible = true;
                                   // trBtnNew.Visible = true;
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "0 record found.";
                                   // tbDetails.Visible = true;
                                    ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                }
                            }
                            else
                            {
                                dgDetails.DataSource = null;
                                dgDetails.DataBind();
                               // trDetails.Visible = true;
                              //   trDgDetails.Visible = true;
                               // trBtnNew.Visible = true;
                                lblMsg.Visible = true;
                                lblMsg.Text = "0 record found.";
                               // tbDetails.Visible = true;
                                ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = ex.Message;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Visible = true;
                            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                            string sRet = oInfo.Name;
                            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                            String LogClassName = method.ReflectedType.Name;
                            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                        }
                        dsResult.Clear();
                        dsResult = null;
                        htParam.Clear();
                        htParam = null;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
                lblMsg.Visible = true;
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

    #region InitializeControl
    private void InitializeControl()
    {
        lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel.Text"));
        lblChnnlSubClass.Text = (olng.GetItemDesc("lblChnnlSubClass.Text"));
        lblUnitLevel.Text = (olng.GetItemDesc("lblUnitLevel.Text"));
        //lblUnitMaintanance.Text = (olng.GetItemDesc("lblUnitMaintanance"));
        lblUnitMaintanance.Text = "Unit Hierarchy";
        lblUnitCode.Text = (olng.GetItemDesc("lblUnitCode"));
        //lblTitleUnitMaintanance.Text = (olng.GetItemDesc("lblTitleUnitMaintanance"));
        /*Added By Parag @ 05022014*
         *Added new label controls 
         */
        lblReportingUnit.Text = (olng.GetItemDesc("lblReportingUnit.Text"));
        lblReportingUnitType.Text = (olng.GetItemDesc("lblReportingUnitType.Text"));
        lblReportingUnitCode.Text = (olng.GetItemDesc("lblReportingUnitCode.Text"));
        #region Reset the Popup Title Properties
        lblModalTitle.ForeColor = System.Drawing.Color.Black;
        lblModalTitle.Font.Bold = false;
        #endregion
        /*Parag END*/
    }
    #endregion

    #region FUNCTION ShowErrorMessage
    private void ShowErrorMessage(string str)
    {
        lblMsg.Visible = true;
        lblMsg.Text = str;
    }
    #endregion

    #region GRIDVIEW dgDetails RowCommand
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strUnitId;
        try
        {
            if (e.CommandName.ToUpper().Trim() == "Unit Maintenance Search Results".ToUpper().Trim())
            {
                // Here again bind the grid with new value ... 
                rdbUnit.SelectedIndex = rdbUnit.SelectedIndex + 1;

                // get the Value Of Unit .. 
                int iRowIndex = Convert.ToInt32(e.CommandArgument);

                strUnitId = dgDetails.DataKeys[iRowIndex].Value.ToString();
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message.ToString());
        }

        if (Session["UserGrp"].ToString() != ConfigurationManager.AppSettings["BlockGroupName"].ToString())
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                try
                {
                    string strUnitID = string.Empty;
                    if (rdbUnit.SelectedValue != "40.0")//old 6.0
                    {
                        int intPos = row.Cells[0].Text.IndexOf('>');

                        int intPos2 = row.Cells[0].Text.IndexOf('<', 1);
                        strUnitID = row.Cells[0].Text.Substring(intPos + 1, intPos2 - intPos - 1);
                    }
                    else
                    {
                        strUnitID = row.Cells[0].Text;
                    }

                    ArrayList arrLst = new ArrayList();
                    arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                    arrLst.Add(new prjXml.Collection("BizSrc", ddlSalesChannel.SelectedValue.ToString()));
                    arrLst.Add(new prjXml.Collection("ChnCls", ddlChnnlSubClass.SelectedValue.ToString()));
                    arrLst.Add(new prjXml.Collection("UnitCode", strUnitID));
                    arrLst.Add(new prjXml.Collection("UnitCodeDesc", row.Cells[1].Text.ToString()));
                    arrLst.Add(new prjXml.Collection("ReportingUnit", row.Cells[2].Text.ToString()));
                    arrLst.Add(new prjXml.Collection("UnitMgr", row.Cells[3].Text.ToString()));
                    arrLst.Add(new prjXml.Collection("UnitType", row.Cells[4].Text.ToString()));
                    prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    strXML = xDoc.OuterXml;

                    arrLst.Clear();
                    DeleteUnit(strUnitID);

                    if (ddlUnitLevel.SelectedValue.ToString() != String.Empty)
                        BindDataGrid(String.Empty, String.Empty, Decimal.Zero, Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString()));

                    if (ddlReportingUnitType.SelectedValue.ToString() != String.Empty)
                        BindDataGrid(String.Empty, String.Empty, Decimal.Parse(ddlUnitLevel.SelectedValue.ToString()), Decimal.Zero);

                    lblMsg.Visible = true;
                }
                catch (Exception ex)
                {
                   // trDetails.Visible = true;
                 // trDgDetails.Visible = false;
                   // trBtnNew.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = ex.Message;
                }
            }
        }
    }
    #endregion

    #region DROPDOWNLIST ddlSalesChannel SelectedIndexChanged
    protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
       // trBtnNew.Visible = false;
      //trlblMsg.Visible = false;
       //trDetails.Visible = false;
     // trDgDetails.Visible = false;
        div3.Style.Add("display", "none");

        try
        {
            if (Request.QueryString["Bizsrc"] == null && Request.QueryString["ChnCls"] == null)
            {
                ddlChnnlSubClass.Items.Clear();
                ddlUnitLevel.Items.Clear();
                ddlReportingUnitType.Items.Clear();//-------------Added by Parag @ 05022014

                SqlDataReader dtRead;
                //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 START
                Hashtable htunit = new Hashtable();
                htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htunit.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htunit);           //----------xxxx rgic...
                htunit.Clear();
                //added by rachana on 07-01-2013  END
                if (dtRead.HasRows)
                {
                    ddlChnnlSubClass.DataSource = dtRead;
                    ddlChnnlSubClass.DataTextField = "ChnlDesc";
                    ddlChnnlSubClass.DataValueField = "ChnCls";
                    ddlChnnlSubClass.DataBind();
                }
                dtRead = null;
                if (ddlChnnlSubClass.Items.Count > 0 && ddlChnnlSubClass.SelectedValue != String.Empty)
                {  //Added For adding unit in AD channel
                    if (ddlSalesChannel.SelectedValue != "AD")
                    { ddlChnnlSubClass.SelectedValue = ddlSalesChannel.SelectedValue + ddlSalesChannel.SelectedValue; }
                    else
                    { ddlChnnlSubClass.SelectedValue = "ADFF"; }
                    // End

                    Hashtable htable = new Hashtable();
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);

                    DataSet dsResult = new DataSet();
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);  //--------------------HO-Head Office...
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");     //------Change of 1 to 1.0 due to Addition of State in Tied 
                        }
                    }
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        objCommonU.FillDropDown(ddlReportingUnitType, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                        ddlReportingUnitType.SelectedIndex = ddlUnitLevel.SelectedIndex;
                    }
                    else
                    {
                        ddlReportingUnitType.SelectedValue = ddlUnitLevel.SelectedValue;
                    }
                    /* Parag @ 10022014
                     * To give the manual control to user to SELECT either of the dropdown values. */
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.SelectedIndex = 0;
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.SelectedIndex = 0;
                    /*Parag End*/
                    dsResult = null;
                    htable.Clear();
                }
                else
                {
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                    /*Parag @ 10022014
                     * To give the manual control to user to SELECT either of the dropdown values. */
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.SelectedIndex = 0;
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.SelectedIndex = 0;
                    /*Parag END*/
                }
            }
            /*------------------------------------------A SECTION ENDS---------------------------------------------*/
            else if (Request.QueryString["Bizsrc"] != null && Request.QueryString["ChnCls"] != null)
            {
                ddlChnnlSubClass.Items.Clear();
                ddlUnitLevel.Items.Clear();
                SqlDataReader dtRead;
                //added by rachana on 07-01-2013 for SELECT ChnCls, ChnClsDesc01 start
                Hashtable htunit = new Hashtable();
                htunit.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htunit.Add("@BizSrc", Request.QueryString["Bizsrc"].ToString());
                htunit.Add("@ChnCls", Request.QueryString["ChnCls"].ToString());
                htunit.Add("@flag", 'A');
                dtRead = objDAL.Common_exec_reader_prc("Prc_GetChnlDescunitmaint", htunit);
                htunit.Clear();
                //added by rachana on 07-01-2013  END

                if (dtRead.HasRows)
                {
                    ddlChnnlSubClass.DataSource = dtRead;
                    ddlChnnlSubClass.DataTextField = "ChnlDesc";
                    ddlChnnlSubClass.DataValueField = "ChnCls";
                    ddlChnnlSubClass.DataBind();
                }
                dtRead = null;
                if (ddlChnnlSubClass.Items.Count > 0 && ddlChnnlSubClass.SelectedValue != String.Empty)
                {
                    Hashtable htable = new Hashtable();
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                    htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);

                    DataSet dsResult = new DataSet();
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");         //Change of 1 to 1.0 due to Addition of State in Tied

                            dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                /*Added by Parag @ 07022014
                                 To Fill the Dropdown of Reporting type 
                                 */
                                objCommonU.FillDropDown(ddlReportingUnitType, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                                int itemIndex = ddlUnitLevel.SelectedIndex;
                                if (itemIndex < ddlReportingUnitType.Items.Count - 1 || ddlReportingUnitType.SelectedIndex != 0)
                                {
                                    ddlReportingUnitType.SelectedIndex = itemIndex;
                                }
                                else
                                {
                                    ddlReportingUnitType.SelectedValue = ddlUnitLevel.SelectedValue;
                                }
                                /*Parag End*/
                            }
                        }
                    }
                    /* Parag @ 10022014
                     * To give the manual control to user to SELECT either of the dropdown values. */
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.SelectedIndex = 0;
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.SelectedIndex = 0;
                    /*Parag End*/
                    dsResult = null;
                    htable.Clear();
                }
                else
                {
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", String.Empty));
                    /* Parag @ 10022014
                    * To give the manual control to user to SELECT either of the dropdown values. */
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.SelectedIndex = 0;
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.SelectedIndex = 0;
                    /*Parag End*/
                }
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message.ToString());
        }
        if (Request.QueryString["ChannelCode"] != null && Request.QueryString["ULevel"] != null && Request.QueryString["UnitCode"] != null)
        {
            objclsUM.displayUnitRadio(ddlSalesChannel.SelectedValue, rdbUnit, Request.QueryString["ULevel"], Request.QueryString["SubCls"]);
        }
        ddlSalesChannel.Focus();
        dgDetails.DataSource = null;
        dgDetails.DataBind();
        lblMsg.Text = "0 record found.";
        lblMsg.Visible = true;
    }
    #endregion

    #region RADIOBUTTON rdbUnit SelectedIndexChanged
    protected void rdbUnit_SelectedIndexChanged(object sender, EventArgs e) // Unit Level Search...
    {

    }
    #endregion

    #region BUTTON btnSearch Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        btnSearch.Attributes.Add("onClick", "javascript: return funValidate()");

        #region Check wether the Dropdown boxes have changed or not... and enable view all feature accordingly
        if (ddlUnitLevel.SelectedIndex != 1 || ddlReportingUnitType.SelectedIndex != 1)
        {
           // trBtnNew.Visible = true;
           // btnVwUnitType.Visible = true; commented by pratik
        }
        else
        {
           // trBtnNew.Visible = false;
            // btnVwUnitType.Visible = false; commented by pratik
        }
        #endregion
        
        #region Search
        Decimal ddlUnitTypeValue;
        Decimal ddlRptUnitTypeValue;
        try
        {
          
            if (ddlSalesChannel.SelectedValue.ToString() == String.Empty)
            {

                //   btnVwUnitType.Visible = false; commented by pratik
                 ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "alertMessage", "alert('Please Select Hierarchy Name')", true);
               
                 ddlSalesChannel.Focus();
               
                return;


            }
            else if (ddlReportingUnitType.SelectedValue.ToString() != String.Empty || txtReportingUnitCode.Text != String.Empty || ddlUnitLevel.SelectedValue.ToString() != String.Empty || txtUnitCode.Text != String.Empty)
            {
                if (ddlUnitLevel.SelectedValue == String.Empty && ddlUnitLevel.SelectedIndex < 1)
                    ddlUnitTypeValue = Decimal.Zero;
                else
                    ddlUnitTypeValue = Decimal.Parse(ddlUnitLevel.SelectedValue.ToString());

                if (ddlReportingUnitType.SelectedValue == String.Empty && ddlReportingUnitType.SelectedIndex < 1)
                    ddlRptUnitTypeValue = Decimal.Zero;
                else
                    ddlRptUnitTypeValue = Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString());


                BindDataGrid(txtUnitCode.Text, txtReportingUnitCode.Text, ddlUnitTypeValue, ddlRptUnitTypeValue);
                //divPage.Style.Add("display", "block");
                
                //Added by Prathamesh on 15-6-16
                demo.Style.Add("display", "block");
                div3.Style.Add("display", "block");
                div_UnitContact.Style.Add("display", "block");
                //btnVwUnitType.Visible = true;
            }
            /*Parag END*/
            else
            {
                //lblModalTitle.Text = "INFORMATION";
               // Lbl1.Text = "Please Select Unit Type or Reporting Unit Type";
                //mdlpopup.Show();
                // btnVwUnitType.Visible = false;// commented by pratik
                ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please Select Unit Type or Reporting Unit Type');", true);
                return;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Lbl1.Text + "')", true);
            }
        }
        catch (Exception ex)
        { ShowErrorMessage(ex.Message.ToString()); }
#endregion

      
    }
    #endregion

    #region BUTTON btnClear Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["BizSrc"] != null && Request.QueryString["ChnCls"] != null)
        {
            Response.Redirect("UnitHierarchy.aspx?BizSrc=" + Request.QueryString["BizSrc"].ToString() + "&ChnCls=" + Request.QueryString["ChnCls"].ToString());
        }
        else
        {
            Response.Redirect("UnitHierarchy.aspx");
        }
    }
    #endregion

    #region GRID BIND
    //Change of int iUnitLevel to decimal iUnitLevel  due to Addition of State in Tied
    /*Arguments of BindDataGrid increased from 2 to 4*/
    protected void BindDataGrid(string strUnitCode, string strRPTUnitCode, decimal ddlUnitTypeValue, decimal ddlRptUnitTypeValue)
    {
        ///<summary>
        ///Changed: Parag @ 10022014
        ///</summary>
        try
        {
            if (strRPTUnitCode.Trim().Length == 0)
                strRPTUnitCode = String.Empty;

            if (strUnitCode.Trim().Length == 0)
                strUnitCode = String.Empty;

            //dgDetails.PageSize = 30;

            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();

            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@languageCode", Session["LanguageCode"].ToString());

            /*Parag @ 08022014
             To make a decision on inserting values for arguments wrt Reporting Unit Type.
             */
            if (ddlRptUnitTypeValue != Decimal.Zero)
            {
                htParam.Add("@RptUnitCode", strRPTUnitCode);
                htParam.Add("@RptUnitType", ddlReportingUnitType.SelectedItem.Text.Substring(0, 2));
            }
            else
            {
                if (txtReportingUnitCode.Text != String.Empty)
                    htParam.Add("@RptUnitCode", strRPTUnitCode);
                else
                    htParam.Add("@RptUnitCode", String.Empty);


                htParam.Add("@RptUnitType", String.Empty);
            }
            /*Parag End*/
            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
            htParam.Add("@ChnnlClass", ddlChnnlSubClass.SelectedValue);
            /*Parag @ 08022014
             To make a decision on inserting values for arguments wrt Unit Type.
             */
            if (ddlUnitTypeValue != Decimal.Zero)
            {
                htParam.Add("@UnitCode", strUnitCode);
                htParam.Add("@UnitType", ddlUnitLevel.SelectedItem.Text.Substring(0, 2));
            }
            else
            {
                if (strUnitCode != String.Empty)
                    htParam.Add("@UnitCode", strUnitCode);
                else
                    htParam.Add("@UnitCode", String.Empty);

                htParam.Add("@UnitType", String.Empty);
            }/*Parag End*/
            htParam.Add("@Flag", 1);//Added by Kalyani on 17-12-2013 to display (AO,BO,CO) record on RO click

            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_enqUnitList", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgDetails.AllowSorting = true;
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    ShowPageInformation();
                   
                   // trDetails.Visible = true;
                  //   trDgDetails.Visible = true;
                   // trBtnNew.Visible = true;
                   // tbDetails.Visible = true;
                   // trlblMsg.Visible = true;//---Added by Parag @ 12022014
                    dgDetails.Columns[8].Visible = false;
                    if (dgDetails.PageCount > 1)
                    {
                       // trBtnNew.Visible = true;
                        // btnVwUnitType.Visible = true;  --commented by pratik
                        btnnext.Enabled = true;
                        
                    }
                    else
                    {
                       // trBtnNew.Visible = false;
                        //   btnVwUnitType.Visible = false; --commented by pratik
                        btnnext.Enabled = false;
                        btnprevious.Enabled = false;
                        txtPage.Text = "1";
                    }
              
                    ShowPageInformation();
                    lblMsg.Text = String.Empty;
                    lblMsg.Visible = false;
                }
                else
                {
                    dgDetails.AllowSorting = false;
                    ShowNoResultFound(dsResult.Tables[0], dgDetails);
                    btnprevious.Enabled = false;
                    btnnext.Enabled = false;
                    txtPage.Text = "1";
                    //   btnVwUnitType.Visible = false; commented by pratik
                    //dgDetails.DataSource = null;
                    //dgDetails.DataBind();
                   // trDetails.Visible = true;
                 // trDgDetails.Visible = false;
                   // trBtnNew.Visible = false;
                   // trlblMsg.Visible = true;//---Added by Parag @ 12022014
                    //lblMsg.Visible = true;
                    //lblMsg.Text = "0 record found.";
                   // tbDetails.Visible = true;
                    //lblPageInfo.Text = String.Empty;
                }
            }
            else
            {
                dgDetails.AllowSorting = false;
                ShowNoResultFound(dsResult.Tables[0], dgDetails);
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
                txtPage.Text = "1";
                // btnVwUnitType.Visible = false; commented by pratik
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                //GrdVw_Locations.DataBind();//Added:Parag@ 04042014
               // trDetails.Visible = true;
             // trDgDetails.Visible = false;
                //lblMsg.Visible = true;
               // trlblMsg.Visible = true;//---Added by Parag @ 12022014
                lblMsg.Text = "0 record found.";
               // trBtnNew.Visible = false;
               // tbDetails.Visible = true;
                //lblPageInfo.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
                lblMsg.Text = ex.Message;
                lblMsg.Visible = true;
                lblMsg.Visible = true;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region RowDataBound()
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         LinkButton lnkUnitCode = (LinkButton)e.Row.FindControl("lnkUnitCode");

        if (ddlUnitLevel.SelectedValue != String.Empty)
        {
            strCount = ddlUnitLevel.SelectedValue.ToString();
            strValue = ddlUnitLevel.SelectedItem.Text.ToString().Substring(0, 2);
        }
        else if (ddlReportingUnitType.SelectedValue != String.Empty)
        {
            strCount = ddlReportingUnitType.SelectedValue.ToString();
            strValue = ddlReportingUnitType.SelectedItem.Text.ToString().Substring(0, 2);
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                if (Request.QueryString["BizSrc"] == null)
                    e.Row.Cells[8].Text = "<a href=\"UnitMaintEdit.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[8].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A" + "&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "\">" + "Edit" + "</a>";
                else if (Request.QueryString["BizSrc"] != null)
                    e.Row.Cells[8].Text = "<a href=\"UnitMaintEdit.aspx?ChannelName=" + Request.QueryString["BizSrc"].ToString() + "&ChannelCode=" + Request.QueryString["BizSrc"].ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[8].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A" + "&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&TPBizSrc=" + Request.QueryString["BizSrc"].ToString() + "&TPChnCls=" + Request.QueryString["ChnCls"].ToString() + "\">" + "Edit" + "</a>";
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
                if (strCount != "60.0" && strCount != null && strCount != String.Empty)
                {
                    LinkButton l = (LinkButton)e.Row.FindControl("DeleteBtn");
                    l.Attributes.Add("onclick", "javascript:return confirm('Confirm delete the unit code " + e.Row.Cells[0].Text + "'s Record?')");
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
    }
    #endregion

    #region DeleteUnit() Function
    protected void DeleteUnit(string strUnitID)
    {
        if (strUnitID.Trim().Length == 0)
        {
            return;
        }
        clsChannelSetup channelsetup = new clsChannelSetup();
        try
        {
            Hashtable htParam = new Hashtable();
            ArrayList arrResult = new ArrayList();

            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@UnitCode", strUnitID);
            htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
            htParam.Add("@ChnCls", ddlChnnlSubClass.SelectedValue.ToString());

            arrResult = channelsetup.UnitMaintDelete(htParam, "prc_AgyAdmin_deleteUnit");

            if (arrResult.Count > 0)
            {
                if (arrResult[0].ToString() != "F")
                {

                    if (arrResult.Count > 0)
                    {
                        if (arrResult[0].ToString().Equals("0"))
                        {
                            lblMsg.Text = "Selected record has been deleted successfully.";
                            lblMsg.Visible = true;
                            //Added by Pranjali on 28-05-2013 for modal popup display start
                            lblModalTitle.Text = "INFORMATION";
                            Lbl1.Text = "Unit deleted successfully";
                            mdlpopup.Show();
                            //Added by Pranjali End
                        }
                        else
                        {
                            switch (arrResult[0].ToString())
                            {
                                case "-1": lblMsg.Text = "Unit code does not exist";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Unit code does not exist');", true);
                                    lblMsg.Visible = true;
                                    break;
                                case "-2": lblMsg.Text = "Other units reporting to this unit, record cannot be deleted!";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Other units reporting to this unit, record cannot be deleted!');", true);
                                    lblMsg.Visible = true;
                                    break;
                                case "-3": lblMsg.Text = "Agent record exists for this unit, record cannot be deleted!";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Agent record exists for this unit, record cannot be deleted!');", true);
                                    lblMsg.Visible = true;
                                    break;
                                case "-4": lblMsg.Text = "First Cease the unit and then delete!";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('First Cease the unit and then delete!');", true);
                                    lblMsg.Visible = true;
                                    break;
                                case "-5": lblMsg.Text = "First move the advisors mapped to this unit!";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('First move the advisors mapped to this unit!');", true);
                                    lblMsg.Visible = true;
                                    break;
                                default: lblMsg.Text = "System error";
                                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('System error');", true);
                                    lblMsg.Visible = true;
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    lblMsg.Text = arrResult[1].ToString();
                    lblMsg.Visible = true;
                }
            }
        }
        catch (Exception ert)
        {
            ShowErrorMessage(ert.Message.ToString());
        }

        if (lblMsg.Text == "Selected record has been deleted successfully.")
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
        string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = String.Empty, ErrDsc = lblMsg.Text, ErrDtl = String.Empty;
        channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + ddlSalesChannel.SelectedValue + ddlChnnlSubClass.SelectedValue + strUnitID, "chnAgnSu", "Delete,clsAgentLevelSetup.cs", "prc_AgnLevel_Delete", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, String.Empty, strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);


    }
    #endregion

    #region dgDetails_RowDeleting
    protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion
    
    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    //protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = GetDataTable();
    //        DataView dv = new DataView(dt);
    //        GridView dgSource = (GridView)sender;

    //        dgSource.PageIndex = e.NewPageIndex;
    //        dv.Sort = dgSource.Attributes["SortExpression"];

    //        if (dgSource.Attributes["SortASC"] == "No")
    //        {
    //            dv.Sort += " DESC";
    //        }

    //        dgSource.DataSource = dv;
    //        dgSource.DataBind();
    //        ShowPageInformation();
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}
    #endregion

    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        String UnitCode = String.Empty;
        String RptUnitCode = String.Empty;

        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();

        /*  
         * Parag @ 12022014 Logic to decide the '...Code' arguments for the procedure. 
         */
        if (txtUnitCode.Text == String.Empty)
            UnitCode = String.Empty;
        else
            UnitCode = txtUnitCode.Text;

        if (txtReportingUnitCode.Text == String.Empty)
            RptUnitCode = String.Empty;
        else
            RptUnitCode = txtReportingUnitCode.Text;
        /*End*/

        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@languageCode", Session["LanguageCode"].ToString());
        /*Parag @ 08022014
         To make a decision on inserting values for arguments wrt Reporting Unit Type.
         */
        if (ddlReportingUnitType.SelectedIndex > 0)
        {
            htParam.Add("@RptUnitCode", RptUnitCode);
            htParam.Add("@RptUnitType", ddlReportingUnitType.SelectedItem.Text.Substring(0, 2));
        }
        else
        {
            htParam.Add("@RptUnitCode", RptUnitCode);
            htParam.Add("@RptUnitType", String.Empty);
        }
        /*Parag End*/
        htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
        htParam.Add("@ChnnlClass", ddlChnnlSubClass.SelectedValue);
        /*Parag @ 08022014
         To make a decision on inserting values for arguments wrt Unit Type.
         */
        if (ddlUnitLevel.SelectedIndex > 0)
        {
            htParam.Add("@UnitCode", UnitCode);
            htParam.Add("@UnitType", ddlUnitLevel.SelectedItem.Text.Substring(0, 2));
        }
        else
        {
            htParam.Add("@UnitCode", UnitCode);
            htParam.Add("@UnitType", String.Empty);
        }
        htParam.Add("@Flag", 1);
        /*Parag End*/
        dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_enqUnitList", htParam);
        return dsResult.Tables[0];
    }

    protected DataTable GetDataTableForMarker()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        
        htParam.Clear();
        dsResult.Clear();

        String strBizSrc = ddlSalesChannel.SelectedValue.ToString();
        htParam.Add("@Bizsrc", strBizSrc.Trim());

        if (ddlReportingUnitType.SelectedIndex == 0)
        {
            htParam.Add("@UnitType", ddlUnitLevel.SelectedItem.Text.Substring(0, 2).Trim());    
        }
        else if(ddlUnitLevel.SelectedIndex == 0)
        {
            htParam.Add("@UnitType", ddlReportingUnitType.SelectedItem.Text.Substring(0, 2).Trim());
        }
            
        htParam.Add("@Flag", 2);
        dsResult = objDAL.GetDataSetForPrc("prc_GetLatLangForUnit", htParam);
        
        return dsResult.Tables[0];
    }
    #endregion

    #region dgDetails_Sorting
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

            DataTable dt = GetDataTable();
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

    #region ShowPageInformation()
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region ddlChnnlSubClass_SelectedIndexChanged
    protected void ddlChnnlSubClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       // trBtnNew.Visible = false;
      //trlblMsg.Visible = false;
       //trDetails.Visible = false;
     // trDgDetails.Visible = false;
        div3.Style.Add("display", "none");

        try
        {
            if (Request.QueryString["Bizsrc"] == null && Request.QueryString["ChnCls"] == null)
            {
                ddlUnitLevel.Items.Clear();
                Hashtable htable = new Hashtable();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);

                DataSet dsResult = new DataSet();
                dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                        foreach (ListItem lstItem in ddlUnitLevel.Items)
                        {
                            if (lstItem.Text == "1")
                            {
                                lstItem.Selected = true;
                            }
                        }
                        dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                objCommonU.FillDropDown(ddlReportingUnitType, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                                ddlReportingUnitType.SelectedIndex = ddlUnitLevel.SelectedIndex;
                            }
                        }
                    }
                }
                //Added by Parag @ 05022014
                ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                ddlUnitLevel.SelectedIndex = 0;
                ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                ddlReportingUnitType.SelectedIndex = 0;
                //ADD:END

                dsResult = null;
                htable.Clear();
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblMsg.Text = "0 record found.";
                lblMsg.Visible = true;
            }
            else if (Request.QueryString["Bizsrc"] != null && Request.QueryString["ChnCls"] != null)
            {

                ddlUnitLevel.Items.Clear();
                Hashtable htable = new Hashtable();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);
                DataSet dsResult = new DataSet();
                dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        objCommonU.FillDropDown(ddlUnitLevel, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                        foreach (ListItem lstItem in ddlUnitLevel.Items)
                        {
                            if (lstItem.Text == "1")
                            {
                                lstItem.Selected = true;
                            }
                        }
                        dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            #region Set the reporting unit type drop down
                            objCommonU.FillDropDown(ddlReportingUnitType, dsResult.Tables[0], "UnitRank", "UnitRankHdr01");
                            //Added by Parag @ 07022014
                            int itemIndex = ddlUnitLevel.SelectedIndex;
                            if (itemIndex < ddlReportingUnitType.Items.Count - 1 || ddlReportingUnitType.SelectedIndex != 0)
                            {
                                ddlReportingUnitType.SelectedIndex = itemIndex;
                            }
                            else
                            {
                                ddlReportingUnitType.SelectedValue = ddlUnitLevel.SelectedValue;
                            }
                            //End
                            #endregion
                        }
                    }
                }
                //Added by Parag @ 05022014
                ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                ddlUnitLevel.SelectedIndex = 0;
                ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));
                ddlReportingUnitType.SelectedIndex = 0;
                //Add: END
                ddlChnnlSubClass.Focus();
                dsResult = null;
                htable.Clear();
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblMsg.Text = "0 record found.";
                lblMsg.Visible = true;
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

    #region ddlUnitLevel_SelectedIndexChanged
    protected void ddlUnitLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnitCode.Text = String.Empty;
        txtReportingUnitCode.Text = String.Empty;
        ddlReportingUnitType.SelectedIndex = 0;
       // trBtnNew.Visible = false;
      //trlblMsg.Visible = false;
       //trDetails.Visible = false;
     // trDgDetails.Visible = false;
        div3.Style.Add("display", "none");

        try
        {
            if (Request.QueryString["ChannelCode"] != null && Request.QueryString["ULevel"] != null && Request.QueryString["UnitCode"] != null)
            {
                objclsUM.displayUnitRadio(ddlSalesChannel.SelectedValue, rdbUnit, ddlUnitLevel.SelectedValue, ddlChnnlSubClass.SelectedValue);
            }

            dgDetails.DataSource = null;
            dgDetails.DataBind();
            lblMsg.Text = "0 record found.";
            lblMsg.Visible = true;
            ddlUnitLevel.Focus();
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

    #region ReportingUnitType_SelectedIndexChanged
    protected void ddlReportingUnitType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnitCode.Text = String.Empty;  
        txtReportingUnitCode.Text = String.Empty;
        ddlUnitLevel.SelectedIndex = 0;
      //trlblMsg.Visible = false;
       //trDetails.Visible = false;
     // trDgDetails.Visible = false;
        div3.Style.Add("display", "none");
        ddlReportingUnitType.Focus();
    }
    #endregion

    #region ShowGeoLocation of Unit
    protected void ViewBtn_OnClick(object sender, EventArgs e)
    {
        if (IsInternetConnection())
        {
            StringBuilder sb3 = new StringBuilder();
            sb3.Append(@"<script language='javascript'>");
            sb3.Append("hideTd();");
            sb3.Append(@"</script>");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall5", sb3.ToString(), false);

        //Find Controls With the reference of the View clicked.
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        //LinkButton ViewBtn = (LinkButton)row.FindControl("ViewBtn");  -- Commented by pratik
        LinkButton lnkUnitCode = (LinkButton)row.FindControl("lnkUnitCode");
        Label lblBizSrc = (Label)row.FindControl("lblBizSrc");

        //Set Variables
        String tempUnitCode = String.Empty;
        String tempBizSrc = String.Empty;
        tempUnitCode = lnkUnitCode.Text.ToString();
        tempBizSrc = lblBizSrc.Text.ToString();

        //Fill Parameters
        Hashtable htParam = new Hashtable();
        DataSet dsResult = new DataSet();
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@UnitCode", tempUnitCode.Trim());
        htParam.Add("@Bizsrc", tempBizSrc.Trim());
        htParam.Add("@UnitType", String.Empty);
        htParam.Add("@Flag", 1);

        //Execute Procedure
        try
        {
            dsResult = objDAL.GetDataSetForPrc("prc_GetLatLangForUnit", htParam);
           
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    //Fetch for validations
                    String temp1 = dsResult.Tables[0].Rows[0]["Latitude"].ToString().Trim();
                    String temp2 = dsResult.Tables[0].Rows[0]["Longitude"].ToString().Trim();

                    //Validate
                    if (temp1 != String.Empty && temp1 != null && temp2 != String.Empty && temp2 != null)
                    {
                        //Get Values
                        strLat = dsResult.Tables[0].Rows[0]["Latitude"].ToString().Trim();
                        strLan = dsResult.Tables[0].Rows[0]["Longitude"].ToString().Trim();
                        String temp3 = dsResult.Tables[0].Rows[0]["Adr1"].ToString().Trim();
                        String temp4 = dsResult.Tables[0].Rows[0]["Adr2"].ToString().Trim();
                        String temp5 = dsResult.Tables[0].Rows[0]["Adr3"].ToString().Trim();
                        String temp6 = dsResult.Tables[0].Rows[0]["City"].ToString().Trim();
                        String temp7 = dsResult.Tables[0].Rows[0]["Postcode"].ToString().Trim();
                        String temp8 = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();

                        //Reformat the Address string
                        String strModifiedAdr = temp3.Replace(".", String.Empty);
                        strModifiedAdr = strModifiedAdr.Replace("~", String.Empty);

                        //Bind into sentences
                        strUnitName = temp8;
                        strAggregatedAddress = strModifiedAdr + temp4 + temp5;
                        strAggregatedPostalAddress = temp6 + temp7;

                        //Call Map Renderer
                       // lblTitleGeoMap.Font.Bold = true;
                        //mdlPopupGeoMap.Show();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                                
                        //Call the PutMarker in Javascript
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script language='javascript'>");
                        sb.Append(String.Format("PutMarker('{0}','{1}','{2}','{3}','{4}');", strUnitName, strLat, strLan, strAggregatedAddress, strAggregatedPostalAddress));
                        sb.Append(@"</script>");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", sb.ToString(), false);
                    }
                    else
                    {
                        //Catch Error For Blank values OR null
                        lblModalTitle.Text = "About Coordinates";
                        Lbl1.Text = "Cannot locate this unit in map.";
                        Lbl1.Font.Bold = true;
                        Lbl2.Text = "Coordinate(s) to locate this unit are missing.";
                       // mdlpopup.Show();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cannot locate this unit in map.'+'\\n'+'Coordinate(s) to locate this unit are missing.')", true);
                        return;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + lblModalTitle.Text + "')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Lbl1.Text + "')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Lbl2.Text + "')", true);
                    }
                }
                else
                {
                    //Catch Error For No Data
                    lblModalTitle.Text = "Exception";
                    lblModalTitle.Font.Bold = true;
                    Lbl1.Text = "No such unit present.";
                    Lbl1.Font.Bold = true;
                    Lbl2.Text = "Record you are searching for does not exist. Due to which the Coordinates are missing too.";
                    mdlpopup.Show();
                }
            }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message.ToString());
        }
        }
        else
        {
            //Catch Error For No Connection.
            lblModalTitle.Text = "About Internet Connection";
            Lbl1.Text = "Internet Connection Unavailable.";
            Lbl1.Font.Bold = true;
            Lbl2.Text = "Internet connection is necessary for viewing Maps.";
            Lbl3.Text = "If that is not the case, ensure that your system is allowed to contact to Google.com .";
            mdlpopup.Show();
        }
    }
    #endregion
    
    #region UnitCode Link Click
    protected void lnkUnitCode_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkUnitCode = (LinkButton)row.FindControl("lnkUnitCode");

        if (Request.QueryString["BizSrc"] == null)
                Response.Redirect("~/Application/ISys/ChannelMgmt/ChannelHierarchy.aspx?ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&T=" + strType + "&RptUntCode=" + lnkUnitCode.Text.Trim());
        else
            Response.Redirect("~/Application/ISys/ChannelMgmt/ChannelHierarchy.aspx?ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&T=" + strType + "&RptUntCode=" + lnkUnitCode.Text.Trim());
        }
    #endregion

    #region METHOD Check Internet Connection
    protected static bool IsInternetConnection()
    {
        try
        {
            using (var client = new WebClient() {Proxy = null })
            using (var stream = client.OpenRead("http://www.google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Button View All On Map Click EVENT
    protected void btnVwUnitType_Click(object sender, EventArgs e)
    {
        if (IsInternetConnection())
        {
            StringBuilder sb3 = new StringBuilder();
            sb3.Append(@"<script language='javascript'>");
            sb3.Append("showTd();");
            sb3.Append(@"</script>");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall4", sb3.ToString(), false);

            //Find Controls With the reference of the View clicked.
            String strBizSrc = ddlSalesChannel.SelectedValue.ToString();

            //Fill Parameters
            Hashtable htParam = new Hashtable();
            DataSet dsResult = new DataSet();
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@Bizsrc", strBizSrc.Trim());

            if (ddlReportingUnitType.SelectedIndex == 0)
            {
                htParam.Add("@UnitType", ddlUnitLevel.SelectedItem.Text.Substring(0, 2).Trim());    
            }
            else if(ddlUnitLevel.SelectedIndex == 0)
            {
                switch (ddlReportingUnitType.SelectedItem.Text.Substring(0, 2).Trim())
                {
                    case "HO": htParam.Add("@UnitType", "ZO");
                        break;
                    case "ZO": htParam.Add("@UnitType", "RO");
                        break;
                    case "RO": htParam.Add("@FlagForRptUnt", "1");
                        break;
                }
            }
            
            htParam.Add("@Flag", 2);

            //Execute Procedure
            try
            {
                dsResult = objDAL.GetDataSetForPrc("prc_GetLatLangForUnit", htParam);
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    //GrdVw_Locations.DataSource = dsResult.Tables[0];
                    //GrdVw_Locations.DataBind();
                    int length = dsResult.Tables[0].Rows.Count;

                    String Adr1;
                    String Adr2;
                    String Adr3;
                    String City;
                    String PostCode;
                    String UnitLegalName;
                    String strAggregatedAddress;
                    String strAggregatedPostalAddress;
                    
                    String[] latarr = new String[length];
                    String[] lanarr = new String[length];
                    String[] popMsgarr = new String[length];

                    for (int i = 0; i < length; i++)
                    {
                        Adr1 = dsResult.Tables[0].Rows[i]["Adr1"].ToString().Trim().Replace("~", String.Empty);
                        Adr2 = dsResult.Tables[0].Rows[i]["Adr2"].ToString().Trim().Replace("~", String.Empty);
                        Adr3 = dsResult.Tables[0].Rows[i]["Adr3"].ToString().Trim().Replace("~", String.Empty);
                        City = dsResult.Tables[0].Rows[i]["City"].ToString().Trim();
                        PostCode = dsResult.Tables[0].Rows[i]["Postcode"].ToString().Trim();
                        UnitLegalName = dsResult.Tables[0].Rows[i]["UnitLegalName"].ToString().Trim();
                        strAggregatedAddress= Adr1+" "+ Adr2+" "+Adr3;
                        strAggregatedPostalAddress= City+" - "+ PostCode;

                        latarr.SetValue(dsResult.Tables[0].Rows[i]["Latitude"].ToString().Trim(), i);
                        lanarr.SetValue(dsResult.Tables[0].Rows[i]["Longitude"].ToString().Trim(), i);
                        StringBuilder popmsg = new StringBuilder();
                        popmsg.Append("<div class='MapDiv'>");
                        popmsg.Append("<span style='font-weight:bold; float:left;'>Unit :" + UnitLegalName.ToString() + "</span></br>");
                        popmsg.Append(strAggregatedAddress.ToString() + "</br>");
                        popmsg.Append(strAggregatedPostalAddress.ToString() + "</div><br/>");

                        if (ddlReportingUnitType.SelectedIndex == 0)
                        {
                            popmsg.Append(String.Format(@"<center><a href='javascript:openPopUnitDownlines({0});' onclick=openPopUnitDownlines({0});>View Downlines</a></center>", "2"));
                        }
                        else if (ddlUnitLevel.SelectedIndex == 0)
                        {
                            popmsg.Append(String.Format(@"<center><a href='javascript:openPopUnitDownlines({0});' onclick=openPopUnitDownlines({0});>View Downlines</a></center>", "1"));
                        }

                        popMsgarr.SetValue(popmsg.ToString(),i);
                    }
                        
                        //Call Map Renderer
                        dsResult.Clear();
                        lblTitleGeoMap.Font.Bold = true;
                       // mdlPopupGeoMap.Show();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);

                        //Call the PutMarker in Javascript.
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script language='javascript'>");
                        sb.Append(String.Format("PutMarkers('{0}','{1}','{2}','{3}');", JavaScript.Serialize(latarr), JavaScript.Serialize(lanarr), JavaScript.Serialize(popMsgarr), length));
                        sb.Append(@"</script>");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall2", sb.ToString(), false);
                        dsResult = null;
                    }
                else
                {
                    //Catch Error For No Data
                    lblModalTitle.Text = "INFORMATION";
                    Lbl1.Text = "No such unit present.";
                    Lbl1.Font.Bold = true;
                    Lbl2.Text = "Record you are searching for does not exist. Due to which the Coordinates are missing too.";
                    mdlpopup.Show();
                    dsResult = null;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message.ToString());
            }
        }
        else
        {
            //Catch Error For No Connection.
            lblModalTitle.Text = "INFORMATION";
            Lbl1.Text = "Internet Connection Unavailable.";
            Lbl2.Text = "Internet connection is necessary for viewing Maps.";
            Lbl3.Text = "If that is not the case, ensure that your system is allowed to contact to Google.com .";
            mdlpopup.Show();
        }
    }
    #endregion

    #region <UnitName> linkbutton click EVENT
    protected void lnkLegalName_Click(object sender, EventArgs e)
    {
        //Find Controls With the reference of the View clicked.
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkLegalName = (LinkButton)row.FindControl("lnkLegalName");
        Label lblLat = (Label)row.FindControl("lblLat");
        Label lblLan = (Label)row.FindControl("lblLan");

        if (lblLat.Text.Length == 0 && lblLan.Text.Length == 0)
        {
            //Catch Error For Blank values OR null
            lblModalTitle.Text = "INFORMATION";
            Lbl1.Text = "Cannot locate the selected unit in map.";
            Lbl1.Font.Bold = true;
            Lbl2.Text = "Coordinate(s) to locate this unit are missing.";
            mdlpopup.Show();       
        }
        else
        {
        Hashtable htParam = new Hashtable();
        DataSet dsResult = new DataSet();
        htParam.Clear();
        dsResult.Clear();
        htParam.Add("@Bizsrc", ddlSalesChannel.SelectedValue.Trim());
        htParam.Add("@UnitName", lnkLegalName.Text);
        htParam.Add("@Flag", 3);
        try
        {
            String Adr1, Adr2, Adr3, City, PostCode, UnitLegalName, strAggregatedAddress, strAggregatedPostalAddress;
            dsResult = objDAL.GetDataSetForPrc("prc_GetLatLangForUnit", htParam);
            
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                Adr1 = dsResult.Tables[0].Rows[0]["Adr1"].ToString().Trim().Replace("~", String.Empty);
                Adr2 = dsResult.Tables[0].Rows[0]["Adr2"].ToString().Trim().Replace("~", String.Empty);
                Adr3 = dsResult.Tables[0].Rows[0]["Adr3"].ToString().Trim().Replace("~", String.Empty);
                City = dsResult.Tables[0].Rows[0]["City"].ToString().Trim();
                PostCode = dsResult.Tables[0].Rows[0]["Postcode"].ToString().Trim();
                UnitLegalName = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim();
                strAggregatedAddress = Adr1 + " " + Adr2 + " " + Adr3;
                strAggregatedPostalAddress = City + " - " + PostCode;

                StringBuilder popmsg = new StringBuilder();
                popmsg.Append(@"<div class=""MapDiv"">");
                popmsg.Append(@"<span style=""font-weight:bold; float:left;"">Unit :" + UnitLegalName.ToString() + "</span></br>");
                popmsg.Append(strAggregatedAddress.ToString() + @"</br>");
                popmsg.Append(strAggregatedPostalAddress.ToString() + @"</div><br/>");

                if (ddlReportingUnitType.SelectedIndex == 0)
                {
                    popmsg.Append(String.Format(@"<center><a href=""javascript:openPopUnitDownlines({0});"" onclick=""javascript:openPopUnitDownlines({0});"">View Downlines</a></center>", "2"));
                }
                else if (ddlUnitLevel.SelectedIndex == 0)
                {
                    popmsg.Append(String.Format(@"<center><a href=""javascript:openPopUnitDownlines({0});"" onclick=""javascript:openPopUnitDownlines({0});"">View Downlines</a></center>", "1"));
                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", "<script language='javascript'>SelectMarker('" + lblLat.Text + "','" + lblLan.Text + "','" + popmsg.ToString() + "');</script>", false);
                popmsg.Clear();
            }
            else
            {
                lblModalTitle.Text = "INFORMATION";
                Lbl1.Text = "Cannot locate the selected unit in map.";
                Lbl1.Font.Bold = true;
                Lbl2.Text = "Coordinate(s) to locate this unit are missing.";
                mdlpopup.Show();       
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
    }
    #endregion

    #region GrdVw_Locations PageIndexChanging EVENT
    protected void GrdVw_Locations_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTableForMarker();
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

    #region GrdVw_Locations Sorting EVENT
    protected void GrdVw_Locations_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = GetDataTable();
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

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
            Decimal ddlUnitTypeValue;
            Decimal ddlRptUnitTypeValue;


            if (ddlUnitLevel.SelectedValue == String.Empty && ddlUnitLevel.SelectedIndex < 1)
                ddlUnitTypeValue = Decimal.Zero;
            else
                ddlUnitTypeValue = Decimal.Parse(ddlUnitLevel.SelectedValue.ToString());

            if (ddlReportingUnitType.SelectedValue == String.Empty && ddlReportingUnitType.SelectedIndex < 1)
                ddlRptUnitTypeValue = Decimal.Zero;
            else
                ddlRptUnitTypeValue = Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString());


            BindDataGrid(txtUnitCode.Text, txtReportingUnitCode.Text, ddlUnitTypeValue, ddlRptUnitTypeValue);
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



    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPage.Text == "1")
            {
                txtPage.Enabled = false;
            }

            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex + 1;
            Decimal ddlUnitTypeValue;
            Decimal ddlRptUnitTypeValue;




            if (ddlUnitLevel.SelectedValue == String.Empty && ddlUnitLevel.SelectedIndex < 1)
                ddlUnitTypeValue = Decimal.Zero;
            else
                ddlUnitTypeValue = Decimal.Parse(ddlUnitLevel.SelectedValue.ToString());

            if (ddlReportingUnitType.SelectedValue == String.Empty && ddlReportingUnitType.SelectedIndex < 1)
                ddlRptUnitTypeValue = Decimal.Zero;
            else
                ddlRptUnitTypeValue = Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString());


            BindDataGrid(txtUnitCode.Text, txtReportingUnitCode.Text, ddlUnitTypeValue, ddlRptUnitTypeValue);
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

    //added by amruta for the upgrade chms on 22/6/16 start
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
        gv.Rows[0].Cells[0].Text = "No Member type have been defined";
        source.Rows.Clear();
    }
    //added by amruta for the upgrade chms on 22/6/16 end
}
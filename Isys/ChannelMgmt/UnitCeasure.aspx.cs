using System;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data;
using INSCL.DAL;
using System.Configuration;
using System.Xml;
using Insc.Common.Multilingual;

public partial class Application_ISys_ChannelMgmt_UnitCeasure : BaseClass
{
    /// <summary>
    ///This Page Handles the Unit Ceasure Requests. 
    /// </summary>
    
    #region Global Declarations
    DataAccessClass objDAL = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    ErrLog objErr = new ErrLog();
    clsUnitMaint objclsUM = new clsUnitMaint();
    XmlDocument doc = new XmlDocument();
    private multilingualManager olng, olng2;

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
    #endregion

    #region EVENT Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "UnitMaint.aspx", strUserLang);
        olng2 = new multilingualManager("DefaultConn", "UnitCeasure.aspx", strUserLang);
        
        Session["CarrierCode"] = '2';
        //lblMsg.Visible = false;
       // lblMsg.Text = String.Empty;
        //Inititalize some objects 

        if (!IsPostBack)
        {
           // tbDetails.Visible = false;       
           // trDgDetails.Visible = false;
            divcmphdrcollapse.Style.Add("display", "none");
            InitializeControl();

            #region DataFilling
            try
            {
                if (Request.QueryString["Bizsrc"] == null && Request.QueryString["ChnCls"] == null)
                {
                    objCommonU.GetSalesChannel(ddlSalesChannel, String.Empty, 1);
                    ddlSalesChannel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlUnitLevel.Items.Insert(0, new ListItem("Select", String.Empty));
                    ddlReportingUnitType.Items.Insert(0, new ListItem("Select", String.Empty));//---->Added By Parag @ 05022014

                    //trDetails.Visible = false;
                   // trDgDetails.Visible = false;
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
                        //added by rachana on 07-01-2013 for Select Top 1 UnitRank start
                        htunit.Add("@ULevel", Convert.ToString(Convert.ToDecimal(Request.QueryString["ULevel"])));
                        htunit.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankonChnlDesc", htunit); // Proc Chnaged by Kalyani on 13-12-2013 to show AO,BO,CO as sub unit of RO
                        htunit.Clear();
                        //added by rachana on 07-01-2013 for Select Top 1 UnitRank end                            

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

                                   // trDetails.Visible = true;
                                   // trDgDetails.Visible = true;
                                   //tbDetails.Visible = true;
                                }
                                else
                                {
                                    dgDetails.DataSource = null;
                                    dgDetails.DataBind();
                                   // trDetails.Visible = true;
                                   // trDgDetails.Visible = true;
                                   // lblMsg.Visible = true;
                                  //  lblMsg.Text = "0 record found.";
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
                               // trDetails.Visible = true;
                               // trDgDetails.Visible = true;
                               // lblMsg.Visible = true;
                               // lblMsg.Text = "0 record found.";
                               //tbDetails.Visible = true;
                                rdbUnit.Visible = true;
                                ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                rdbUnit.SelectedValue = ViewState["NewUnitRank"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            //lblMsg.Text = ex.Message;
                           // lblMsg.ForeColor = System.Drawing.Color.Red;
                           // lblMsg.Visible = true;
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
                   // trDgDetails.Visible = false;
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
                        //added by rachana on 07-01-2013 for Select Top 1 UnitRank start
                        htunit.Clear();
                        htunit.Add("@ULevel", Convert.ToString(Convert.ToDecimal(Request.QueryString["ULevel"])));
                        htunit.Add("@BizSrc", Request.QueryString["BizSrc"].ToString());
                        htunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankonChnlDesc", htunit);

                        //added by rachana on 07-01-2013 for Select Top 1 UnitRank end   
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
                                   // trDgDetails.Visible = true;
                                   //tbDetails.Visible = true;
                                }
                                else
                                {
                                    dgDetails.DataSource = null;
                                    dgDetails.DataBind();
                                   // trDetails.Visible = true;
                                   // trDgDetails.Visible = true;
                                    //lblMsg.Visible = true;
                                    //lblMsg.Text = "0 record found.";
                                   //tbDetails.Visible = true;
                                    ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                                }
                            }
                            else
                            {
                                dgDetails.DataSource = null;
                                dgDetails.DataBind();
                               // trDetails.Visible = true;
                               // trDgDetails.Visible = true;
                               // lblMsg.Visible = true;
                               // lblMsg.Text = "0 record found.";
                               ////tbDetails.Visible = true;
                                ddlUnitLevel.SelectedValue = ViewState["NewUnitRank"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            //lblMsg.Text = ex.Message;
                            //lblMsg.ForeColor = System.Drawing.Color.Red;
                            //lblMsg.Visible = true;
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
                //lblMsg.Text = ex.Message;
                //lblMsg.Visible = true;
                //lblMsg.Visible = true;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            #endregion
            }
        }
    #endregion

    #region InitializeControl
    private void InitializeControl()
    {
        lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel.Text"));
        lblChnnlSubClass.Text = (olng.GetItemDesc("lblChnnlSubClass.Text"));
        lblUnitLevel.Text = (olng.GetItemDesc("lblUnitLevel.Text"));
        lblUnitCeasure.Text = (olng2.GetItemDesc("lblUnitCeasure"));
        lblUnitCode.Text = (olng.GetItemDesc("lblUnitCode"));
        //lblTitleUnitCeasure.Text = (olng2.GetItemDesc("lblUnitCeasure"));
        /*Added By Parag @ 05022014*
         *Added new label controls */
        lblReportingUnit.Text = (olng.GetItemDesc("lblReportingUnit.Text"));
        lblReportingUnitType.Text = (olng.GetItemDesc("lblReportingUnitType.Text"));
        lblReportingUnitCode.Text = (olng.GetItemDesc("lblReportingUnitCode.Text"));
        #region Reset the Popup Title Properties
        //lblModalTitle.ForeColor = System.Drawing.Color.Black;
        //lblModalTitle.Font.Bold = false;
        #endregion
        /*Parag END*/
    }
    #endregion

    #region DROPDOWNLIST ddlSalesChannel SelectedIndexChanged
    protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //trBtnNew.Visible = false;
       //trlblMsg.Visible = false;
        //trDetails.Visible = false;
       // trDgDetails.Visible = false;

        txtUnitCode.Text = String.Empty;
        txtReportingUnitCode.Text = String.Empty;
        //ddlReportingUnitType.SelectedIndex = 0;
        //ddlUnitLevel.SelectedIndex = 0;
        divcmphdrcollapse.Style.Add("display", "none");

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
                     * To give the manual control to user to select either of the dropdown values. */
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
                     * To give the manual control to user to select either of the dropdown values. */
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
                     * To give the manual control to user to select either of the dropdown values. */
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
                    * To give the manual control to user to select either of the dropdown values. */
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
        //lblMsg.Text = "0 record found.";
        //lblMsg.Visible = true;
    }
    #endregion

    #region DROPDOWNLIST ddlChnnlSubClass_SelectedIndexChanged
    protected void ddlChnnlSubClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       //trlblMsg.Visible = false;
        //trDetails.Visible = false;
       // trDgDetails.Visible = false;

        txtUnitCode.Text = String.Empty;
        txtReportingUnitCode.Text = String.Empty;
       // ddlReportingUnitType.SelectedIndex = 0;
       // ddlUnitLevel.SelectedIndex = 0;
        divcmphdrcollapse.Style.Add("display", "none");
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
                //lblMsg.Text = "0 record found.";
                //lblMsg.Visible = true;
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

                dsResult = null;
                htable.Clear();
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                //lblMsg.Text = "0 record found.";
                //lblMsg.Visible = true;
            }
            ddlChnnlSubClass.Focus();
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

    #region DROPDOWNLIST ddlUnitLevel_SelectedIndexChanged
    protected void ddlUnitLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnitCode.Text = String.Empty;
        txtReportingUnitCode.Text = String.Empty;
        //ddlReportingUnitType.SelectedIndex = 0;
        //trBtnNew.Visible = false;
       //trlblMsg.Visible = false;
        //trDetails.Visible = false;
       // trDgDetails.Visible = false;
        divcmphdrcollapse.Style.Add("display", "none");

        try
        {
            if (Request.QueryString["ChannelCode"] != null && Request.QueryString["ULevel"] != null && Request.QueryString["UnitCode"] != null)
            {
                objclsUM.displayUnitRadio(ddlSalesChannel.SelectedValue, rdbUnit, ddlUnitLevel.SelectedValue, ddlChnnlSubClass.SelectedValue);
            }
            ddlUnitLevel.Focus();
            dgDetails.DataSource = null;
            dgDetails.DataBind();
            //lblMsg.Text = "0 record found.";
            //lblMsg.Visible = true;
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

    #region DROPDOWNLIST ReportingUnitType_SelectedIndexChanged
    protected void ddlReportingUnitType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnitCode.Text = String.Empty;
        txtReportingUnitCode.Text = String.Empty;
        ddlUnitLevel.SelectedIndex = 0;
        //trBtnNew.Visible = false;
       //trlblMsg.Visible = false;
        //trDetails.Visible = false;
       // trDgDetails.Visible = false;
        divcmphdrcollapse.Style.Add("display", "none");
        ddlReportingUnitType.Focus();
    }
    #endregion
  
    #region BUTTON btnSearch Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //divcmphdrcollapse.Style.Add("display", "block");
        dgDetails.PageIndex = 0;//Reset the page index

        Decimal ddlUnitTypeValue;
        Decimal ddlRptUnitTypeValue;
        try
        {
            //Added by Kalyani on 13-12-2013 to get (HO,ZO,RO,BO) unittype records
            //btnAddNewUnit.Visible = true;
            /*  Parag @ 10022014
             * To Make a decision as to search the Unit Details from which input.
             * New Addition, All the Unit types and Unit codes are diverted to BindDataGrid Function
             */
            //Added by Kalyani on 13-12-2013 for AO,CO unittype 
            if (ddlSalesChannel.SelectedValue.ToString() == String.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Hierarchy Name')", true);
                return;

            }
            else if (ddlChnnlSubClass.SelectedValue.ToString() == String.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Sub Class')", true);
                return;

            }
                  
            else  if (ddlReportingUnitType.SelectedValue.ToString() != String.Empty || txtReportingUnitCode.Text != String.Empty || ddlUnitLevel.SelectedValue.ToString() != String.Empty || txtUnitCode.Text != String.Empty)
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
            }
            /*Parag END*/
            else
            {
                //lblModalTitle.Text = "SEARCH FAILED";
                //lblModalTitle.ForeColor = System.Drawing.Color.Red;
                //lblModalTitle.Font.Bold = true;
                //Lbl.Text = "Please select Unit Type Or Reporting Unit Type.";
                //mdlpopup.Show();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Unit Type Or Reporting Unit Type')", true);
                return;
            }
        }
        catch (Exception ex)
        { ShowErrorMessage(ex.Message.ToString()); }
    }
    #endregion

    #region BUTTON btnClear Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["BizSrc"] != null && Request.QueryString["ChnCls"] != null)
        {
            Response.Redirect("UnitCeasure.aspx?BizSrc=" + Request.QueryString["BizSrc"].ToString() + "&ChnCls=" + Request.QueryString["ChnCls"].ToString());
        }
        else
        {
            Response.Redirect("UnitCeasure.aspx");
        }
    }
    #endregion

    #region EVENT RowDataBound()
    protected void   dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lnkCease = (LinkButton)e.Row.FindControl("lnkCease");

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
                {
                    //Response.Redirect("PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue);// + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
                    //lnkCease.Attributes.Add("onclick", "javascript:funUntDetailsPopup('PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
                }
                else if (Request.QueryString["BizSrc"] != null)
                {
                    //Response.Redirect("PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
                    //lnkCease.Attributes.Add("onclick", "javascript:funUntDetailsPopup('PopUnitDetails.aspx?ChannelName=" + Request.QueryString["BizSrc"].ToString() + "&ChannelCode=" + Request.QueryString["BizSrc"].ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&TPBizSrc=" + Request.QueryString["BizSrc"].ToString() + "&TPChnCls=" + Request.QueryString["ChnCls"].ToString() + "&mdlpopup=mdl_UntDetails');");
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




#region COMMAND dgDetails RowCommand
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
            //if (e.CommandName == "Cease")
            //{
            //    Response.Redirect("PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
            //}

            if (e.CommandName == "Cease")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Response.Redirect("PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + row.Cells[5].Text.Trim() + "&UnitCode=" + row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=");
                    //lnkCease.Attributes.Add("onclick", "javascript:funUntDetailsPopup('PopUnitDetails.aspx?ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
                }
           
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

                    if (ddlUnitLevel.SelectedValue.ToString() != String.Empty)
                        BindDataGrid(String.Empty, String.Empty, Decimal.Zero, Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString()));

                    if (ddlReportingUnitType.SelectedValue.ToString() != String.Empty)
                        BindDataGrid(String.Empty, String.Empty, Decimal.Parse(ddlUnitLevel.SelectedValue.ToString()), Decimal.Zero);

                   // lblMsg.Visible = true;
                }
                catch (Exception ex)
                {
                    //trDetails.Visible = true;
                    //trDgDetails.Visible = false;
                   // lblMsg.Visible = true;
                   // lblMsg.Text = ex.Message;
                }
            }
        }
    }
    #endregion

    //#region COMMAND dgDetails RowCommand
    //protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string strUnitId;
    //    try
    //    {
    //        if (e.CommandName.ToUpper().Trim() == "Unit Maintenance Search Results".ToUpper().Trim())
    //        {
    //            // Here again bind the grid with new value ... 
    //            rdbUnit.SelectedIndex = rdbUnit.SelectedIndex + 1;

    //            // get the Value Of Unit .. 
    //            int iRowIndex = Convert.ToInt32(e.CommandArgument);

    //            strUnitId = dgDetails.DataKeys[iRowIndex].Value.ToString();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowErrorMessage(ex.Message.ToString());
    //    }

    //    if (Session["UserGrp"].ToString() != ConfigurationManager.AppSettings["BlockGroupName"].ToString())
    //    {
    //        if (e.CommandName == "Delete")
    //        {
    //            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
    //            try
    //            {
    //                string strUnitID = string.Empty;
    //                if (rdbUnit.SelectedValue != "40.0")//old 6.0
    //                {
    //                    int intPos = row.Cells[0].Text.IndexOf('>');

    //                    int intPos2 = row.Cells[0].Text.IndexOf('<', 1);
    //                    strUnitID = row.Cells[0].Text.Substring(intPos + 1, intPos2 - intPos - 1);
    //                }
    //                else
    //                {
    //                    strUnitID = row.Cells[0].Text;
    //                }

    //                ArrayList arrLst = new ArrayList();
    //                arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
    //                arrLst.Add(new prjXml.Collection("BizSrc", ddlSalesChannel.SelectedValue.ToString()));
    //                arrLst.Add(new prjXml.Collection("ChnCls", ddlChnnlSubClass.SelectedValue.ToString()));
    //                arrLst.Add(new prjXml.Collection("UnitCode", strUnitID));
    //                arrLst.Add(new prjXml.Collection("UnitCodeDesc", row.Cells[1].Text.ToString()));
    //                arrLst.Add(new prjXml.Collection("ReportingUnit", row.Cells[2].Text.ToString()));
    //                arrLst.Add(new prjXml.Collection("UnitMgr", row.Cells[3].Text.ToString()));
    //                arrLst.Add(new prjXml.Collection("UnitType", row.Cells[4].Text.ToString()));
    //                prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
    //                XmlDocument xDoc = new XmlDocument();
    //                xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
    //                strXML = xDoc.OuterXml;

    //                arrLst.Clear();

    //                if (ddlUnitLevel.SelectedValue.ToString() != String.Empty)
    //                    BindDataGrid(String.Empty, String.Empty, Decimal.Zero, Decimal.Parse(ddlReportingUnitType.SelectedValue.ToString()));

    //                if (ddlReportingUnitType.SelectedValue.ToString() != String.Empty)
    //                    BindDataGrid(String.Empty, String.Empty, Decimal.Parse(ddlUnitLevel.SelectedValue.ToString()), Decimal.Zero);

    //                lblMsg.Visible = true;
    //            }
    //            catch (Exception ex)
    //            {
    //               // trDetails.Visible = true;
    //               // trDgDetails.Visible = false;
    //                lblMsg.Visible = true;
    //                lblMsg.Text = ex.Message;
    //            }
    //        }
    //    }
    //}
    //#endregion

    #region EVENT dgDetails_RowDeleting
    protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region EVENT dgDetails-PAGEINDEXCHANGING
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
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

    #region EVENT dgDetails_Sorting
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

            DataTable ds = ViewState["gv"] as DataTable;
            DataView dv = new DataView(ds);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

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

    #region FUNCTION ShowPageInformation()
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        //lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region FUNCTION ShowErrorMessage
    private void ShowErrorMessage(string str)
    {
        //lblMsg.Visible = true;
        ////lblMsg.Text = str;
    }
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
    #endregion

    #region EVENT GRID BIND
    //Change of int iUnitLevel to decimal iUnitLevel  due to Addition of State in Tied
    /*Arguments of BindDataGrid increased from 2 to 4*/
    protected void BindDataGrid(string strUnitCode, string strRPTUnitCode, decimal ddlUnitTypeValue, decimal ddlRptUnitTypeValue)
    {
        ///<summary>
        ///Changed: Parag @ 10022014
        ///</summary>
        try
        {

            //if (txtPage.Text=="1")
            //{
            //    btnprevious.Enabled = false;
            //}


            if (strRPTUnitCode.Trim().Length == 0)
                strRPTUnitCode = String.Empty;

            if (strUnitCode.Trim().Length == 0)
                strUnitCode = String.Empty;

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
                    divcmphdrcollapse.Style.Add("display", "block");
                    demo.Visible = true;
                    dgDetails.DataSource = dsResult.Tables[0];
                    ViewState["gv"] = dsResult.Tables[0];
                    dgDetails.DataBind();
                    ShowPageInformation();
                   // trDetails.Visible = true;
                   // trDgDetails.Visible = true;
                   //tbDetails.Visible = true;
                  // trlblMsg.Visible = true;            //---Added by Parag @ 12022014
                   //// lblMsg.Text = String.Empty;
                   // lblMsg.Visible = false;


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
                    //dgDetails.DataSource = null;
                    //dgDetails.DataBind();
                    //trDetails.Visible = true;
                    //trDgDetails.Visible = false;
                    //trlblMsg.Visible = true;        //---Added by Parag @ 12022014
                    //lblMsg.Visible = true;
                    //lblMsg.Text = "0 record found.";
                    //tbDetails.Visible = true;
                   // lblPageInfo.Text = String.Empty;
                    //tbDetails.Visible = true;
                    ShowNoResultFound(dsResult.Tables[0], dgDetails);
                    txtPage.Text = "1";
                }
            }
            else
            {
                //dgDetails.DataSource = null;
                //dgDetails.DataBind();
                //trDetails.Visible = true;
                //trDgDetails.Visible = false;
                //lblMsg.Visible = true;
                //trlblMsg.Visible = true;//---Added by Parag @ 12022014
                //lblMsg.Text = "0 record found.";
                //tbDetails.Visible = true;
                //lblPageInfo.Text = String.Empty;
                //btnAddNewUnit.Visible = true;
                //tbDetails.Visible = true;
                ShowNoResultFound(dsResult.Tables[0], dgDetails);
                txtPage.Text = "1";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex - 1;
            //dgDetails.DataSource = (DataTable)Session["grid"];
            //dgDetails.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            //if (txtPage.Text == "1")
            //{
            //    btnprevious.Enabled = false;
            //}
            //else
            //{
            //    btnprevious.Enabled = true;
            //}
            //btnnext.Enabled = true;

         

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




    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        dgDetails.DataSource = source;
        dgDetails.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        dgDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        dgDetails.Rows[0].Cells[columnsCount - 1].Text = "";
        dgDetails.Rows[0].Cells[columnsCount - 2].Text = "";
        dgDetails.Rows[0].Cells[0].Text = "No Unit Type have been defined";
        source.Rows.Clear();
    }



    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex + 1;
            //// dgCntst.DataSource = (DataTable)Session["grid"];
            //// dgCntst.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            //btnprevious.Enabled = true;
            //if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            //{
            //    btnnext.Enabled = false;
            //}

            //int page = dgDetails.PageCount;

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

    //protected void lnkCease_Click(object sender, EventArgs e)
    //{
    //    //Response.Redirect("~/Application/ISys/ChannelMgmt/PopUnitDetails.aspx");

    //    LinkButton lnkCease = (LinkButton)e.Row.FindControl("lnkCease");
    //    Response.Redirect("~/Application/ISys/ChannelMgmt/PopUnitDetails.aspx? ChannelName=" + ddlSalesChannel.SelectedItem.ToString() + "&ChannelCode=" + ddlSalesChannel.SelectedValue.ToString() + "&UnitTypeName=" + strValue + "&UnitTypeCode=" + e.Row.Cells[5].Text.Trim() + "&UnitCode=" + e.Row.Cells[0].Text.Trim() + "&strCount=" + strCount + "&flag=update" + "&ULevel=" + ddlUnitLevel.SelectedValue + "&UName=" + e.Row.Cells[2].Text.Trim() + "&fgPage=A&RptUntCode=" + e.Row.Cells[7].Text.Replace("&nbsp;", String.Empty).Trim() + "&RptUntType=" + ddlReportingUnitType.SelectedItem.Text.Substring(0, 2) + "&SubCls=" + ddlChnnlSubClass.SelectedValue + "&mdlpopup=mdl_UntDetails');");
    //}
}
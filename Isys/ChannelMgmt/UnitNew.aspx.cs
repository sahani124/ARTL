//Modified By:		    <Ajay Yadav> 
//Modificartion  Date:      <17th Sep 2021>
//Description:	    <This page is modified for Code Optimization>

#region namespaces
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
using System.Data.SqlClient;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
#endregion

namespace INSCL
{
    public partial class UnitNew : Base
    {
        #region Variable Declaration
        clsUnitMaint objclsUM = new clsUnitMaint();
        private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
        SqlDataReader dtRead;
        Hashtable htable = new Hashtable();
        CommonFunc oCommon = new CommonFunc();
        XmlDocument doc = new XmlDocument();
        private multilingualManager olng;
        private multilingualManager olng2;///added by akshay to add label values for reporting details part on 07/02/14 
        private string strUserLang;
        string Types, ChnCls, BizSrc;
        string ErrMsg, AuditType, strXML = "";
        DataAccessClass objDAL = new DataAccessClass();
        string Flag = "";
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        EncodeDecode ObjDec = new EncodeDecode();
        DataSet dsResult = new DataSet();
        string strUnitType;
        string strBizSrc;
        string strChnCls;
        ErrLog objErr = new ErrLog();
        string ddlinit = "Select";//added by akshay on 07/02/2014
        int chkPMd;
        int chkAd1Md, chkAd2Md;
        #endregion

        #region PAGELOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnBizsrc1.Value = Request.QueryString["BizSrc"];
                strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
                olng = new multilingualManager("DefaultConn", "UnitNew.aspx", strUserLang);
                olng2 = new multilingualManager("DefaultConn", "AGTLevel.aspx", strUserLang);
                Session["CarrierCode"] = '2';
                lblMsg.Text = "";
                lblMsg.Visible = false;
                if (!IsPostBack)
                {
                    #region Initialize values
                    InitializeControl();
                    int year = DateTime.Now.Year;
                    DateTime firstDay = new DateTime(year, 4, 1);
                    FillAllDll();
                    EnableDisable();
                    txtEffDate.Text = firstDay.ToString("dd/MM/yyyy");
                    txtCseDt.Enabled = true;
                    #endregion
                    EditUnitType();
                    if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                    {
                        btnUpdate.Enabled = false;
                    }
                }

                btnUpdate.Attributes.Add("OnClick", "javascript: return funValidateNew();");//Added by Prathamesh

                if (ChkLinkMst.Checked == true)
                {
                    lblSalesChannelLink.Enabled = true;
                    ddlSalesChannelLink.Enabled = true;
                    lblChnnlSubClass.Enabled = true;
                    ddlChnnlSubClass.Enabled = true;
                    lblUnitDesc.Enabled = true;
                    ddlUnitDesc.Enabled = true;
                }

                if (ChkStaff.Checked == true)
                {
                    lblSalesChannelStaff.Enabled = true;
                    DdlSalesChannelStaff.Enabled = true;
                    lblChannelsubStaff.Enabled = true;
                    DdlChannelsubStaff.Enabled = true;
                    LblAgtType.Enabled = true;
                    DdlAgentType.Enabled = true;
                }
            }
            catch (Exception ex)
            {
               LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region EditUnitType
        protected void EditUnitType()
        {
            try
            {
                
                if (Request.QueryString["Code"] != null)  //Edit
                {
                    strUnitType = Request.QueryString["Code"];
                    strBizSrc = Request.QueryString["BizSrc"];
                    strChnCls = Request.QueryString["SubClass"];
                    lblSalesChannel.Text = Request.QueryString["SalesChannel"];
                    lblChnCls.Text = Request.QueryString["ChannelClass"].ToString().Trim();
                    txtUnitType.Text = Request.QueryString["Code"];
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htable.Add("@BizSrc", strBizSrc);
                    
                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankUnitType", htable);
                    if (dtRead.HasRows)
                    {
                        ddlUnitRank.DataSource = dtRead;
                        ddlUnitRank.DataTextField = "UnitRank";
                        ddlUnitRank.DataValueField = "UnitRank";
                        ddlUnitRank.DataBind();
                    }
                    dtRead = null;
                    ddlUnitRank.Items.Insert(0, new ListItem("Select", "")); //added by meena 16/3/18
                    string BizSrc = Request.QueryString["BizSrc"];
                    string UnitType = Request.QueryString["Code"];
                    string chncls = Request.QueryString["SubClass"];
                    clsChannelSetup code = new clsChannelSetup();

                    dtRead = code.UnitTypeSelect(strBizSrc, UnitType, strChnCls, Session["CarrierCode"].ToString());
                    if (dtRead.Read())
                    {
                        ddlUnitRank.SelectedValue = dtRead["UnitRank"].ToString();
                        txtLevel.Text = dtRead[1].ToString();
                        txtDesc1.Text = dtRead[2].ToString();
                        txtDesc2.Text = dtRead[3].ToString();
                        txtDes3.Text = dtRead[4].ToString();
                        if (dtRead["AlwMultiUntMgr"].ToString() != "")
                        {
                            if (Convert.ToBoolean(dtRead["AlwMultiUntMgr"]) == true)
                            {
                                chkManager.Checked = true;
                            }
                            else if (Convert.ToBoolean(dtRead["AlwMultiUntMgr"]) == false)
                            {
                                chkManager.Checked = false;
                            }
                        }
                        if (dtRead["AlwSls"].ToString() != "")
                        {
                            if (Convert.ToBoolean(dtRead["AlwSls"]) == true)
                            {
                                chkSales.Checked = true;
                            }
                            else if (Convert.ToBoolean(dtRead["AlwSls"]) == false)
                            {
                                chkSales.Checked = false;
                            }
                        }
                        if (dtRead["AlwSvc"].ToString() != "")
                        {
                            if (Convert.ToBoolean(dtRead["AlwSvc"]) == true)
                            {
                                chkServices.Checked = true;
                            }
                            else if (Convert.ToBoolean(dtRead["AlwSvc"]) == false)
                            {
                                chkServices.Checked = false;
                            }
                        }

                        ddlMultiMgr.SelectedValue = dtRead["MultiUnitMgr"].ToString().Trim();
                        #region Primary Reporting Details Data fetching
                        ddlreportingtype.SelectedValue = dtRead["PriRepType"].ToString();
                        GetPrimRpt();
                        #endregion
                        #region Additional Manager 1 Details Data Fetching
                        FillRepoTypeDDL();
                        ddlam1reportingtype.SelectedValue = dtRead["Addl1ReptTyp"].ToString();
                        GetAddlMgr1();
                        #endregion
                        #region Additional Manager Selection based on Reporting rule
                        if (ddlreportingtype.SelectedIndex == null)
                        {
                            FillAddlRelType();
                        }
                        #endregion

                        #region Mandatory Checkboxes
                        chkPriMand.Checked = dtRead["PrimMand"].ToString().Trim() == "True" ? true : false;
                        chkAddl1Mand.Checked = dtRead["IsAddl1Mand"].ToString().Trim() == "1" ? true : false;
                        #endregion
                        #region OtherDetails
                        txtFinYr.Text = dtRead["Period"].ToString().Trim();
                        txtVer.Text = dtRead["Version"].ToString().Trim();
                        txtEffDate.Text = dtRead["EffDate"].ToString().Trim();
                        txtCseDt.Text = dtRead["CeaseDate"].ToString().Trim();
                        #endregion
                        if (dtRead[11].ToString() == "True")
                        {

                        }

                        if (dtRead[15].ToString() == "True")
                        {

                        }
                    }
                    dtRead.Close();
                    btnUpdate.Attributes.Add("onClick", "javascript: return funValidateEdit();");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "EditUnitType", ex);
            }
        }

        #endregion

        #region EnableDisable
        private void EnableDisable()
        {
            try
            {
                if (Request.QueryString["flag"] != null)  //New
                {
                    string strFlag = Request.QueryString["flag"].ToString().Trim();
                    if (strFlag == "N")
                    {
                        txtVer.Text = "1.00";
                        txtUnitType.Visible = true;
                        lblChnCls.Visible = false;
                        ddlChannelClass.Visible = true;
                        lblSalesChannel.Visible = false;
                        ddlSalesChannel.Visible = true;
                        btnUpdate.Visible = false;
                        divModification.Attributes.Add("style", "display:none;margin-left:2%;margin-right:2%;");
                        objCommonU.GetSalesChannel(ddlSalesChannel, "", 1);
                        if (Request.QueryString["chncls"] != null)
                        {
                            ddlSalesChannel.SelectedValue = Request.QueryString["chncls"].ToString().Trim();
                        }
                        ddlChannelClass.Items.Clear();
                        ddlUnitRank.Items.Clear();
                        htable.Clear();
                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htable.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankUnitType", htable);
                        if (dtRead.HasRows)
                        {
                            ddlUnitRank.DataSource = dtRead;
                            ddlUnitRank.DataTextField = "UnitRank";
                            ddlUnitRank.DataValueField = "UnitRank";
                            ddlUnitRank.DataBind();
                        }
                        dtRead = null;
                        ddlUnitRank.Items.Insert(0, new ListItem("Select", "")); //added by meena 16/3/18
                        ddlChannelClass.Visible = true;
                        htable.Clear();
                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htable);
                        if (dtRead.HasRows)
                        {
                            ddlChannelClass.DataSource = dtRead;
                            ddlChannelClass.DataTextField = "ChnlDesc";
                            ddlChannelClass.DataValueField = "ChnCls";
                            ddlChannelClass.DataBind();
                        }
                        dtRead = null;
                        if (Request.QueryString["SubClass"] != null)
                        {
                            ddlChannelClass.SelectedValue = Request.QueryString["SubClass"].ToString().Trim();
                        }
                        btnUpdate.Attributes.Add("onClick", "javascript: return funValidateNew();");
                    }
                    else
                    {
                        txtUnitType.Visible = true;
                        lblSalesChannel.Visible = true;
                        lblChnCls.Visible = true;
                        ddlChannelClass.Visible = false;
                        ddlSalesChannel.Visible = false;
                        ControlEnableddesable();
                        btnSave.Visible = false;
                    }
                }
                else
                {
                    txtUnitType.Visible = true;
                    lblSalesChannel.Visible = true;
                    ddlSalesChannel.Visible = false;
                    lblChnCls.Visible = true;
                    ddlChannelClass.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "EnableDisable", ex);
            }
        }

        #endregion

        #region Filling  the Period (financial year) dropdown based on master business year setup.
        protected void fillFinyr()
        {
            try
            {
                htable.Clear();
                htable.Add("@flag", "N");
                FillDropDowns(ddlFinancialYr, "Prc_get_Current_FinYear", htable, "INSCCommonConnectionString", "", true, "flagN");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "fillFinyr", ex);
            }
        }
        #endregion

        #region
        public void FillAllDll()
        {
            try
            {
                fillFinyr();
                objCommonU.GetSalesChannel(ddlSalesChannelLink, "", 1);
                objCommonU.GetSalesChannel(DdlSalesChannelStaff, "", 1);
                ddlSalesChannelLink.Items.Insert(0, new ListItem("Select", ""));
                DdlSalesChannelStaff.Items.Insert(0, new ListItem("Select", ""));
                ddlUnitDesc.Items.Insert(0, new ListItem("Select", ""));
                ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", ""));
                DdlAgentType.Items.Insert(0, new ListItem("Select", ""));
                DdlChannelsubStaff.Items.Insert(0, new ListItem("Select", ""));
                oCommon.getDropDown(ddlreportingtype, "RptUntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlam1reportingtype, "RptUntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlAM1RptRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlbasedon, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlam1basedon, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlMultiMgr, "MultiMgr", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlam2basedon, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlreportingtype.Items.Insert(0, new ListItem("Select", ""));
                ddlReportingRule.Items.Insert(0, new ListItem("Select", ""));
                ddlam1channel.Items.Insert(0, new ListItem("Select", ""));
                ddlAM1RptRule.Items.Insert(0, new ListItem("Select", ""));
                ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));
                ddlam2reportingtype.Items.Insert(0, new ListItem("Select", ""));
                ddlbasedon.Items.Insert(0, new ListItem("Select", ""));
                ddlam1basedon.Items.Insert(0, new ListItem("Select", ""));
                ddlam2basedon.Items.Insert(0, new ListItem("Select", ""));
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                ddlMultiMgr.Items.Insert(0, new ListItem("Select", ""));
                oCommon.getDropDown(ddlPriRuleType, "untruletype", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlAdlRuleType, "untruletype", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlPriRuleType.Items.Insert(0, new ListItem("Select", ""));///100714
                ddlAdlRuleType.Items.Insert(0, new ListItem("Select", ""));///100714                                                   
                oCommon.getDropDown(ddlPriRptSetup, "RptSetup", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlAdlRptStp, "RptSetup", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlPriRptSetup.Items.Insert(0, new ListItem("Select", ""));///100714
                ddlAdlRptStp.Items.Insert(0, new ListItem("Select", ""));///100714
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "FillAllDll", ex);
            }
        }

        #endregion

        #region InitializeControl
        private void InitializeControl()
        {
            try
            {
                lblChannel.Text = (olng.GetItemDesc("lblChannel.Text"));
                lblUnittype.Text = (olng.GetItemDesc("lblUnittype.Text"));
                lblClass.Text = (olng.GetItemDesc("lblClass.Text"));
                lblRank.Text = (olng.GetItemDesc("lblRank.Text"));
                lblLevel.Text = (olng.GetItemDesc("lblLevel.Text"));
                lblDesc1.Text = (olng.GetItemDesc("lblDesc1.Text"));
                lblDesc2.Text = (olng.GetItemDesc("lblDesc2.Text"));
                lblDesc3.Text = (olng.GetItemDesc("lblDesc3.Text"));
                lblMgr.Text = (olng.GetItemDesc("lblMgr.Text"));
                lblAllowSales.Text = (olng.GetItemDesc("lblAllowSales.Text"));
                lblAllowServices.Text = (olng.GetItemDesc("lblAllowServices.Text"));
                lblChannelUnitTypeSetup.Text = (olng.GetItemDesc("lblChannelUnitTypeSetup"));
                lblPrilevelagttype.Text = (olng.GetItemDesc("lblPrilevelagttype"));
                lblAMLvlAgtTyp.Text = (olng.GetItemDesc("lblPrilevelagttype"));
                lblPrReptDtls.Text = (olng2.GetItemDesc("lblPrReptDtls.Text"));
                lblddlreportingtype.Text = (olng2.GetItemDesc("lblddlreportingtype.Text"));
                lblPrichannel.Text = (olng2.GetItemDesc("lblchannel.Text"));
                lblPrisubchannel.Text = (olng2.GetItemDesc("lblsubchannel.Text"));
                lblPribasedon.Text = (olng2.GetItemDesc("lblbasedon.Text"));
                lblAddlRDtls.Text = (olng2.GetItemDesc("lblAddlRDtls.Text"));
                lblAddlMRptTyp.Text = (olng2.GetItemDesc("lblAddlMRptTyp.Text"));
                lblAddlMChnl.Text = (olng2.GetItemDesc("lblAddlMChnl.Text"));
                lblAddlMSubCls.Text = (olng2.GetItemDesc("lblAddlMSubCls.Text"));
                lblAddlMBsdOn.Text = (olng2.GetItemDesc("lblAddlMBsdOn.Text"));
                lblAMLvlAgtTyp.Text = (olng.GetItemDesc("lblPrilevelagttype"));
                lblAddlMRptTyp1.Text = (olng2.GetItemDesc("lblAddlMRptTyp.Text"));
                lblAddlMChnl1.Text = (olng2.GetItemDesc("lblAddlMChnl.Text"));
                lblAddlMSubCls1.Text = (olng2.GetItemDesc("lblAddlMSubCls.Text"));
                lblAddlMBsdOn1.Text = (olng2.GetItemDesc("lblAddlMBsdOn.Text"));
                lblAMLvlAgtTyp1.Text = (olng.GetItemDesc("lblPrilevelagttype"));
                lblRptRule.Text = (olng2.GetItemDesc("lblRptRule.Text"));
                lblAddlMRptRule.Text = (olng2.GetItemDesc("lblRptRule.Text"));
                lblmandate2.Text = (olng.GetItemDesc("lblMandate"));
                lblPer.Text = (olng.GetItemDesc("lblPeriod"));
                lblVer.Text = (olng.GetItemDesc("lblVersion"));
                lblEffDate.Text = (olng.GetItemDesc("lblEff"));
                lblCseDt.Text = (olng.GetItemDesc("lblCease"));
                lblhdr.Text = (olng.GetItemDesc("lblhdrOth"));
                lblChannelUnitTypeSetup.Text = "UNIT TYPE SETUP";
                lblPrReptDtls.Text = "PRIMARY RELATIONSHIP DETAILS";
                lblAddlRDtls.Text = "ADDTIONAL RELATIONSHIP DETAILS";
                lblhdr.Text = "OTHER DETAILS";
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "InitializeControl", ex);
            }
        }
        #endregion

        #region ChkLinkMst_SelectedIndexChanged
        protected void ChkLinkMst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkLinkMst.Checked == false)
                {
                    lblSalesChannelLink.Enabled = false;
                    ddlSalesChannelLink.Enabled = false;
                    lblChnnlSubClass.Enabled = false;
                    ddlChnnlSubClass.Enabled = false;
                    lblUnitDesc.Enabled = false;
                    ddlUnitDesc.Enabled = false;
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ChkLinkMst_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ChkStaff_SelectedIndexChanged
        protected void ChkStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChkStaff.Checked == false)
            {
                lblSalesChannelStaff.Enabled = false;
                DdlSalesChannelStaff.Enabled = false;
                lblChannelsubStaff.Enabled = false;
                DdlChannelsubStaff.Enabled = false;
                LblAgtType.Enabled = false;
                DdlAgentType.Enabled = false;
            }
        }
        //Added by pranjali on 29-11-2013 for selected checkbox index changed end
        #endregion

        #region InsertAndUpdateValues
        protected void InsertAndUpdateValues(Hashtable htable)
        {
            try
            {
                if (Request.QueryString["Code"] != null)
                {
                    strBizSrc = Request.QueryString["BizSrc"];
                }
                else
                {
                    strBizSrc = Request.QueryString["chncls"];
                }
                strChnCls = Request.QueryString["SubClass"];
                if (ddlSalesChannel.Visible == true)
                {
                    BizSrc = ddlSalesChannel.SelectedValue.Trim();
                }
                else
                {
                    BizSrc = strBizSrc;
                }
                if (this.txtUnitType.Visible == true)
                {
                    Types = txtUnitType.Text.ToUpper();
                }
                else
                {
                    Types = strUnitType;
                }

                if (ddlChannelClass.Visible == true)
                {
                    ChnCls = ddlChannelClass.SelectedValue.Trim();
                }
                else
                {
                    ChnCls = strChnCls;
                }
                if (chkPriMand.Checked == true)
                {
                    chkPMd = 1;
                }
                else
                {
                    chkPMd = 0;
                }
                if (chkAddl1Mand.Checked == true)
                {
                    chkAd1Md = 1;
                }
                else
                {
                    chkAd1Md = 0;
                }
                if (txtVer.Text.Trim() == "")
                {
                    txtVer.Text = "1.00";
                }
                string BizsrcMstrUnit, ChnclsMstrUnit, UnitLevelMstrUnit, lnkMstUnitFlag;
                string BizsrcLnkStaff, ChnclsLnkStaff, TypesLnkStaff, lnkstaffFlag;
                if (ChkLinkMst.Checked == true)
                {
                    BizsrcMstrUnit = ddlSalesChannelLink.SelectedValue;
                    ChnclsMstrUnit = ddlChnnlSubClass.SelectedValue;
                    UnitLevelMstrUnit = ddlUnitDesc.SelectedValue;
                    lnkMstUnitFlag = "1";
                }
                else
                {
                    BizsrcMstrUnit = "";
                    ChnclsMstrUnit = "";
                    UnitLevelMstrUnit = "";
                    lnkMstUnitFlag = "0";
                }
                if (ChkStaff.Checked == true)
                {
                    BizsrcLnkStaff = DdlSalesChannelStaff.SelectedValue;
                    ChnclsLnkStaff = DdlChannelsubStaff.SelectedValue;
                    TypesLnkStaff = DdlAgentType.SelectedValue;
                    lnkstaffFlag = "1";
                }
                else
                {
                    BizsrcLnkStaff = "";
                    ChnclsLnkStaff = "";
                    TypesLnkStaff = "";
                    lnkstaffFlag = "0";
                }

                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htable.Add("@BizSrc", BizSrc);
                htable.Add("@Type", Types);
                htable.Add("@ChnCls", ChnCls);
                htable.Add("@UnitRank", ddlUnitRank.SelectedValue);
                htable.Add("@Level", txtLevel.Text);
                htable.Add("@UnitDesc01", txtDesc1.Text);
                htable.Add("@UnitDesc02", txtDesc2.Text);
                htable.Add("@UnitDesc03", txtDes3.Text);
                htable.Add("@AllowManager", Convert.ToString(chkManager.Checked));
                htable.Add("@AllowSales", Convert.ToString(chkSales.Checked));
                htable.Add("@AllowServices", Convert.ToString(chkServices.Checked));
                htable.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));
                htable.Add("@Flag", Flag);
                htable.Add("@BizsrcLink", ddlSalesChannelLink.SelectedValue);
                htable.Add("@chnclsLink", ddlChnnlSubClass.SelectedValue);
                htable.Add("@UnittypeLink", ddlUnitDesc.SelectedValue);
                htable.Add("@MstrUnitlinkFlag", "1");
                htable.Add("@bizsrcstaff", DdlSalesChannelStaff.SelectedValue);
                htable.Add("@chnclsstaff", DdlAgentType.SelectedValue);
                htable.Add("@agenttypestaff", DdlAgentType.SelectedValue);
                htable.Add("@staffFlag", "0");
                htable.Add("@IsPrimMand", Convert.ToString(chkPMd));
                htable.Add("@PrimaryReportingType", ddlreportingtype.SelectedValue);
                htable.Add("@RptRule", ddlReportingRule.SelectedValue);
                htable.Add("@PrimaryChannel", ddlchannel.SelectedValue);
                htable.Add("@PrimarySubChannel", ddlsubchannel.SelectedValue);
                htable.Add("@PrimaryBsdOn", ddlbasedon.SelectedValue);
                htable.Add("@PrimaryLvlAgtTyp", ddllevelagttype.SelectedValue);
                htable.Add("@MultiUnitMgr", ddlMultiMgr.SelectedValue);
                htable.Add("@Period", ddlFinancialYr.SelectedValue.Trim());
                htable.Add("@Version", txtVer.Text.Trim());
                htable.Add("@EffDate", Convert.ToDateTime(txtEffDate.Text.Trim()));
                if (txtCseDt.Text.Trim() == "")
                {
                    htable.Add("@CeaseDate", System.DBNull.Value);
                }
                else
                {
                    htable.Add("@CeaseDate", Convert.ToDateTime(txtCseDt.Text.Trim().ToString()));
                }
                htable.Add("@PriRule", ddlPriRuleType.SelectedValue.Trim());
                htable.Add("@PriStp", ddlPriRptSetup.SelectedValue.Trim());
                htable.Add("@AdlRule", ddlAdlRuleType.SelectedValue.Trim());
                htable.Add("@AdlStp", ddlAdlRptStp.SelectedValue.Trim());
                htable.Add("@ModMode", rbCorrection.SelectedValue);
                htable.Add("@Status", ddllStatus.SelectedItem.Text);
                AddDetail();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "InsertAndUpdateValues", ex);
            }
        }

        #endregion

        #region AddDetail
        protected void AddDetail()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@CarrierCode", Session["CarrierCode"].ToString().Trim());
                ht.Add("@BizSrc", BizSrc);
                ht.Add("@UnitType", Types);
                ht.Add("@ChnCls", ChnCls);
                ht.Add("@UnitRank", ddlUnitRank.SelectedValue);
                ht.Add("@Level", txtLevel.Text);
                ht.Add("@Flag", Flag);
                ht.Add("@IsAddlMand", chkAd1Md.ToString().Trim());
                ht.Add("@AddlRelRule", "1");
                ht.Add("@ReportTyp", ddlam1reportingtype.SelectedValue.Trim());
                ht.Add("@AddlChannel", ddlam1channel.SelectedValue.Trim());
                ht.Add("@AddlSubChannel", ddlam1subchannel.SelectedValue.Trim());
                ht.Add("@AddlBsdOn", ddlam1basedon.SelectedValue.Trim());
                ht.Add("@AddlUntRnkTyp", ddlam1levelagttype.SelectedValue.Trim());
                ht.Add("@AddlReptRule", ddlAM1RptRule.SelectedValue.Trim());
                ht.Add("@AdlRule", ddlAdlRuleType.SelectedValue.Trim());
                ht.Add("@AdlStp", ddlAdlRptStp.SelectedValue.Trim());
                ht.Add("@Period", txtFinYr.Text.Trim());
                ht.Add("@Version", txtVer.Text.Trim());
                ht.Add("@EffDate", Convert.ToDateTime(txtEffDate.Text.Trim()));
                if (txtCseDt.Text.Trim() == "")
                {
                    ht.Add("@CeaseDate", System.DBNull.Value);
                }
                else
                {
                    ht.Add("@CeaseDate", Convert.ToDateTime(txtCseDt.Text.Trim()));
                }
                ht.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()).Trim());
                ht.Add("@UpdatedBy", Convert.ToString(Session["UserId"].ToString()).Trim());
                objDAL.execute_sprc("dbo.Prc_InsAddlUntType", ht);
                ht.Clear();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "AddDetail", ex);
            }
        }
        #endregion

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Attributes.Add("onClick", "javascript: return funValidateNew();");
                if (ChkLinkMst.Checked)
                {
                    if (ddlSalesChannelLink.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT channel of master unit')", true);
                        return;
                    }

                    if (ddlChnnlSubClass.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT sub class of master unit')", true);
                        return;
                    }

                    if (ddlUnitDesc.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT unit description of master unit')", true);
                        return;
                    }
                }
                if (ChkStaff.Checked)
                {
                    if (DdlSalesChannelStaff.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT channel of Staff')", true);
                        return;
                    }

                    if (DdlChannelsubStaff.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT sub class of Staff')", true);
                        return;
                    }
                    if (DdlAgentType.SelectedItem.Text == "Select")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please SELECT agent type of Staff')", true);
                        return;
                    }
                }
                if (Request.QueryString["flag"] != null)
                {
                    Flag = Request.QueryString["flag"].ToString();
                }
                else
                {
                    Flag = "Y";
                }
                InsertAndUpdateValues(htable);
                if (Flag == "N")
                {
                    InsertData("PRC_INS_CHNUNTSU", htable, "INSCCommonConnectionString");
                    htable.Clear();
                    btnSave.Enabled = false;
                    lbl_popup.Text = "Channel Unit Type Setup Added successfully" + "</br></br> Unit Description : " + txtDesc1.Text.Trim() + "</br></br> Channel : " + ddlSalesChannel.SelectedItem.Text.ToString().Trim() + "</br></br> SubClass : " + ddlChannelClass.SelectedItem.Text.ToString().Trim();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "btnSave_Click", ex);
            }
        }
        #endregion

        #region UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAndUpdateValues(htable);
                InsertData("PRC_UPT_CHNUNTSU", htable, "INSCCommonConnectionString");
                htable.Clear();
                RBHIDE();
                btnUpdate.Enabled = false;
                if (Request.QueryString["Code"] != null) 
                {
                    lbl_popup.Text = "Channel Unit Type Setup Updated successfully" + "</br></br> Unit Description : " + txtDesc1.Text.ToUpper() + "</br></br> Channel : " + lblSalesChannel.Text.Trim() + "</br></br> SubClass : " + lblChnCls.Text.Trim();
                }
                btnUpdate.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            catch (Exception ex)
            {
                 LogException("ISYS-CHMS", "UnitNew.aspx", "btnUpdate_Click", ex);
            }
        }
        #endregion

        #region Validation For Channel  Records If Already Exists. 
        protected void txtUnitType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateInsertionData();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "txtUnitType_TextChanged", ex);
            }
        }
        #endregion

        #region Validation Before Data Insertion For Records If Already Exists. 
        public void ValidateInsertionData()
        {
            try
            {
                if (this.txtUnitType.Text.Trim().Length != 2)// Added by sanoj for Validation sahani 10-12-2021
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Atleast Two Character');</script>", false);
                    this.txtUnitType.Text = "";
                    this.txtUnitType.Focus();
                    return;
                }

                DataSet dsreturn = new DataSet();
                htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                htable.Add("@UnitType", this.txtUnitType.Text.Trim());
                htable.Add("@ChnCls", ddlChannelClass.SelectedValue);

                dsreturn = ValidationIfDataAlreadyExists("PRC_RECORDEXIT_CHNUNTSU", htable, "INSCCommonConnectionString");
                if (dsreturn.Tables.Count != 0)
                {
                    string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                    if (comnm == "Unit type already exists")
                    {
                        txtUnitType.Text = "";
                        txtUnitType.Focus();
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ValidateInsertionData", ex);
            }
        }
        #endregion

        #region btnCancel_Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Cancel"] != null)
                {
                    Response.Redirect("SearchUnitNew.aspx?Code=" + Request.QueryString["Cancel"].ToString() + "&SubClass=" + Request.QueryString["SubClass"].ToString() + "");
                }
                else
                {
                    Response.Redirect("SearchUnitNew.aspx?chncls=" + Request.QueryString["chncls"].ToString() + "&SubClass=" + Request.QueryString["SubClass"].ToString() + "");
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "btnCancel_Click", ex);
            }
            
        }
        #endregion

        #region ClearControls
        private void ClearControls()
        {
            try
            {
                txtUnitType.Text = "";
                txtLevel.Text = "";
                txtDesc2.Text = "";
                txtDesc1.Text = "";
                txtDes3.Text = "";
                chkManager.Checked = false;
                chkSales.Checked = false;
                chkServices.Checked = false;
                ddlUnitRank.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ClearControls", ex);
            }
        }
        #endregion

        #region ddlChnnlSubClass_SelectedIndexChanged
        protected void ddlChnnlSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlChnnlSubClass.Items.Count > 0 && ddlChnnlSubClass.SelectedValue != "")
                {
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", ddlSalesChannelLink.SelectedValue);
                    htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);

                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitDesc, dsResult.Tables[0], "UnitType", "UnitDesc01");
                        }
                    }
                    ddlUnitDesc.Items.Insert(0, new ListItem("Select", ""));
                    dsResult = null;
                    htable.Clear();
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlChnnlSubClass_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region DROPDOWNLIST ddlSalesChannelLink SelectedIndexChanged
        protected void ddlSalesChannelLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChnnlSubClass.Items.Clear();
                ddlUnitDesc.Items.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", ddlSalesChannelLink.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htable);
                htable.Clear();
                if (dtRead.HasRows)
                {
                    ddlChnnlSubClass.DataSource = dtRead;
                    ddlChnnlSubClass.DataTextField = "ChnlDesc";
                    ddlChnnlSubClass.DataValueField = "ChnCls";
                    ddlChnnlSubClass.DataBind();
                }
                dtRead = null;
                if (ddlChnnlSubClass.Items.Count > 0 && ddlChnnlSubClass.SelectedValue != "")
                {
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", ddlSalesChannelLink.SelectedValue);
                    htable.Add("@ChnnlSubCls", ddlChnnlSubClass.SelectedValue);

                    dsResult.Clear();
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);

                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitDesc, dsResult.Tables[0], "UnitType", "UnitDesc01");
                        }
                    }
                    ddlUnitDesc.Items.Insert(0, new ListItem("Select", ""));
                    dsResult = null;
                    htable.Clear();
                }
                else
                {
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", ""));
                    ddlUnitDesc.Items.Insert(0, new ListItem("Select", ""));
                }
            }

            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message.ToString());
            }
        }
        #endregion

        #region FUNCTION ShowErrorMessage
        private void ShowErrorMessage(string str)
        {
            try
            {
                lblMsg.Visible = true;
                lblMsg.Text = str;
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ShowErrorMessage", ex);
            }
        }
        #endregion

        #region DROPDOWNLIST DdlSalesChannelStaff SelectedIndexChanged
        protected void DdlSalesChannelStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DdlChannelsubStaff.Items.Clear();
                DdlAgentType.Items.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", DdlSalesChannelStaff.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htable);
                htable.Clear();
                if (dtRead.HasRows)
                {
                    DdlChannelsubStaff.DataSource = dtRead;
                    DdlChannelsubStaff.DataTextField = "ChnlDesc";
                    DdlChannelsubStaff.DataValueField = "ChnCls";
                    DdlChannelsubStaff.DataBind();
                    Get_UsersAgenttype();
                    DdlAgentType.Items.Insert(0, new ListItem("Select", "")); //added by pranjali on 29-11-2013
                }
                else
                {
                    ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", ""));
                    ddlUnitDesc.Items.Insert(0, new ListItem("Select", ""));
                    DdlAgentType.Items.Insert(0, new ListItem("Select", ""));//added by pranjali on 29-11-2013
                }
                dtRead = null;
            }

            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "DdlSalesChannelStaff_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region DdlChannelsubStaff_SelectedIndexChanged
        protected void DdlChannelsubStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Get_UsersAgenttype();
                DdlAgentType.Items.Insert(0, new ListItem("Select", "Select"));
            }
            catch (Exception ex)
            {
                 LogException("ISYS-CHMS", "UnitNew.aspx", "DdlChannelsubStaff_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region Get_UsersAgenttype()
        public void Get_UsersAgenttype()
        {
            try
            {
                string UserId = Session["UserID"].ToString();
                if (DdlSalesChannelStaff.SelectedValue == "")
                {
                    oCommonU.GetAgentType(DdlAgentType, "Select", "");
                }
                else
                {
                    oCommonU.GetAgentTypeForSlsChnnl(DdlAgentType, DdlSalesChannelStaff.SelectedValue, DdlAgentType.SelectedValue, DdlChannelsubStaff.SelectedValue, UserId);
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }
        }
        #endregion

        #region ddlSalesChannel_SelectedIndexChanged
        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChannelClass.Items.Clear();
                ddlUnitRank.Items.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", ddlSalesChannel.SelectedValue.ToString());
                dtRead = objDAL.Common_exec_reader_prc("Prc_GetUnitRankUnitType", htable);
                if (dtRead.HasRows)
                {
                    ddlUnitRank.DataSource = dtRead;
                    ddlUnitRank.DataTextField = "UnitRank";
                    ddlUnitRank.DataValueField = "UnitRank";
                    ddlUnitRank.DataBind();
                }
                dtRead = null;

                ddlChannelClass.Visible = true;
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htable);
                if (dtRead.HasRows)
                {
                    ddlChannelClass.DataSource = dtRead;
                    ddlChannelClass.DataTextField = "ChnlDesc";
                    ddlChannelClass.DataValueField = "ChnCls";
                    ddlChannelClass.DataBind();
                }
                dtRead = null;
            }
            catch (Exception ex)
            {
                 LogException("ISYS-CHMS", "UnitNew.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region Fill ddlChnnlSubClass
        private void ShowddlChnnlSubClass()
        {
            try
            {
                SqlDataReader dtRead;
                ddlChnnlSubClass.Items.Clear();
                ddlUnitDesc.Items.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", ddlSalesChannelLink.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htable);
                htable.Clear();
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
                LogException("ISYS-CHMS", "UnitNew.aspx", "ShowddlChnnlSubClass", ex);
            }
        }
        #endregion

        #region fill ddlUnitDesc
        private void ShowddlUnitDesc()
        {
            try
            {
                if (ddlChnnlSubClass.Items.Count > 0 && ddlChnnlSubClass.SelectedValue != "")
                {
                    string strBizSrc = dtRead[8].ToString();
                    string strChannlSubCls = dtRead[9].ToString();
                    htable.Clear();
                    dsResult.Clear();
                    htable.Add("@BizSrc", strBizSrc);
                    htable.Add("@Chncls", strChannlSubCls);
                    dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetUnitTypeDesc", htable);
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrc"].ToString());//ddlSalesChannelLink.SelectedValue
                    htable.Add("@ChnnlSubCls", dsResult.Tables[0].Rows[1]["BizSrc"].ToString());//ddlChnnlSubClass.SelectedValue
                    dsResult.Clear();
                    dsResult = objDAL.GetDataSetForPrc("prc_GetUnitTypeForSlsChnnlAndSubCls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitDesc, dsResult.Tables[0], "UnitType", "UnitDesc01");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ShowddlUnitDesc", ex);
            }
        }
        #endregion

        #region fill DdlChannelsubStaff
        private void ShowDdlChannelsubStaff()
        {
            try
            {
                SqlDataReader dtRead;
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", DdlSalesChannelStaff.SelectedValue);
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htable);
                htable.Clear();
                if (dtRead.HasRows)
                {
                    DdlChannelsubStaff.DataSource = dtRead;
                    DdlChannelsubStaff.DataTextField = "ChnlDesc";
                    DdlChannelsubStaff.DataValueField = "ChnCls";
                    DdlChannelsubStaff.DataBind();
                    Get_UsersAgenttype();
                    DdlAgentType.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ShowDdlChannelsubStaff", ex);
            }
        }
        #endregion

        #region ddlreportingtype_SelectedIndexChanged method
        protected void ddlreportingtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region ddlchannel_SelectedIndexChanged method
        protected void ddlchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                funrptsubchnl(ddlchannel.SelectedValue.Trim(), 2, ddlPriRuleType, ddlsubchannel);
                ddlchannel.Focus();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlsubchannel_SelectedIndexChanged Method
        protected void ddlsubchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlbasedon.SelectedIndex = 0;
                ddllevelagttype.Items.Clear();
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                ddlsubchannel.Focus();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlsubchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlbasedon_SelectedIndexChanged Method
        protected void ddlbasedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLevel.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lvl", "<script type='text/javascript'>alert('Please Enter Unit Level');</script>", false);
                    ddlbasedon.SelectedValue = "";
                }

                if (ddlbasedon.SelectedValue == "1")
                {
                    GetUnitLevelPrimary(ddllevelagttype);
                    ddlPriRptSetup.SelectedValue = "E";
                    ddlPriRptSetup.Enabled = false;
                }
                else if (ddlbasedon.SelectedValue == "0")
                {
                    GetUnitRankPrimary(ddllevelagttype);
                    ddlPriRptSetup.SelectedValue = "";
                    ddlPriRptSetup.Enabled = true;
                }
                else if (ddlbasedon.SelectedValue == "")
                {
                    ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddllevelagttype.SelectedValue = "";
                    ddlPriRptSetup.SelectedValue = "";
                    ddlPriRptSetup.Enabled = true;
                }
                ddlbasedon.Focus();
            }
            catch (Exception ex)
            {
                 LogException("ISYS-CHMS", "UnitNew.aspx", "ddlbasedon_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam1reportingtype_SelectedIndexChanged method
        protected void ddlam1reportingtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string userID = Session["UserID"].ToString();
                if (ddlam1reportingtype.SelectedValue == "CF")
                {
                    ddlam1channel.Items.Clear();
                    if (Request.QueryString["Code"] != null)
                    {
                        GetChannel(ddlam1channel, 1, userID, Request.QueryString["BizSrc"].ToString().Trim());
                    }
                    else
                    {
                        GetChannel(ddlam1channel, 1, userID, ddlSalesChannel.SelectedValue);
                    }
                    ddlam1channel.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam1reportingtype.SelectedValue != "CF" && ddlam1reportingtype.SelectedValue != "")
                {
                    ddlam1channel.Items.Clear();
                    GetChannel(ddlam1channel, 2, userID, ddlSalesChannel.SelectedValue);
                    ddlam1channel.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam1reportingtype.SelectedValue == "")
                {
                    ddlam1channel.Items.Clear();
                    ddlam1channel.Items.Insert(0, new ListItem("Select", ""));
                }
                ddlam1subchannel.Items.Clear();
                ddlam1subchannel.Items.Insert(0, new ListItem("Select", ""));
                ddlam1basedon.SelectedIndex = 0;
                ddlam1levelagttype.Items.Clear();
                ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                ddlAM1RptRule.SelectedIndex = 0;
                ddlam1reportingtype.Focus();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam1channel_SelectedIndexChanged Method
        protected void ddlam1channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                funrptsubchnl(ddlam1channel.SelectedValue.Trim(), 2, ddlAdlRuleType, ddlam1subchannel);
                ddlam1channel.Focus();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam1channel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam1subchannel_SelectedIndexChanged Method
        protected void ddlam1subchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlam1subchannel.SelectedValue == ddlinit)
                {
                    ddlam1basedon.SelectedIndex = 0;
                    ddlam1levelagttype.Items.Clear();
                    ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
                ddlam1subchannel.Focus();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam1subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam1basedon_SelectedIndexChanged Method
        protected void ddlam1basedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLevel.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "lvl", "<script type='text/javascript'>alert('Please Enter Unit Level');</script>", false);
                    ddlam1basedon.SelectedValue = "";
                }

                if (ddlam1basedon.SelectedValue == "1")
                {
                    GetUnitLevelAddl(ddlam1levelagttype);
                    ddlAdlRptStp.SelectedValue = "E";
                    ddlAdlRptStp.Enabled = false;
                }
                else if (ddlam1basedon.SelectedValue == "0")
                {
                    GetUnitRankAddl(ddlam1levelagttype);
                    ddlAdlRptStp.SelectedValue = "";
                    ddlAdlRptStp.Enabled = true;
                }
                else if (ddlam1basedon.SelectedValue == "")
                {
                    ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddlam1levelagttype.SelectedValue = "";
                    ddlAdlRptStp.SelectedValue = "";
                    ddlAdlRptStp.Enabled = true;
                }
                ddlam1basedon.Focus();
            }
            catch (Exception ex)
            {
                 LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam1basedon_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region DisableAddlMgr Method
        //added by akshay for setting the drop downs of additional managers indexes to 0
        protected void DisableAddlMgr()
        {
            try
            {
                chkAddl1Mand.Checked = false;
                ddlam1reportingtype.SelectedIndex = 0;
                ddlam1channel.SelectedIndex = 0;
                ddlam1subchannel.SelectedIndex = 0;
                ddlam1basedon.SelectedIndex = 0;
                ddlam1levelagttype.SelectedIndex = 0;
                ddlAM1RptRule.SelectedIndex = 0;
                ddlAdlRptStp.SelectedIndex = 0;
                ddlAdlRuleType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "DisableAddlMgr", ex);
            }
        }
        #endregion

        #region getsubchannel
        //added by akshay for getting sub channel
        public void getsubchannel()
        {
            try
            {
                ddlsubchannel.Items.Clear();
                ddlbasedon.SelectedIndex = 0;
                ddllevelagttype.Items.Clear();
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userid = Session["UserID"].ToString();
                objCommonU.GetUserChnclsChannel(ddlsubchannel, ddlchannel.SelectedValue, 0, userid.ToString());
                ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "getsubchannel", ex);
            }
            
        }
        #endregion

        #region getLevelAgentTypeMethod
        public void getLevelAgentType()
        {
            try
            {
                ddllevelagttype.Items.Clear();
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userID = Session["UserID"].ToString();
                if (ddlbasedon.SelectedValue == "1")
                {
                    GetAgentTypeForSlsChnnlCT(ddllevelagttype, ddlchannel.SelectedValue, ddlbasedon.SelectedValue, ddlsubchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlbasedon.SelectedValue == "0")
                {
                    GetLevelType(ddllevelagttype, ddlchannel.SelectedValue, ddlsubchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "getLevelAgentType", ex);
            }
        }
        #endregion

        #region GetAgentTypeForSlsChnnlCT Method
        public void GetAgentTypeForSlsChnnlCT(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string urank)
        {
            try
            {
                string strSql = string.Empty;
                DataSet dsResult = new DataSet();
                string carriercode = "2";
                htable.Clear();
                htable.Add("@BizSrc", strBizSrc);
                htable.Add("@selectedchannel", strChnCls);
                htable.Add("@UnitRnk", urank);
                dsResult = objDAL.GetDataSetForPrc("Prc_getAgentLvl", htable);
                if (dsResult.Tables.Count > 0)
                {
                    FillDropDown(ddl, dsResult.Tables[0], "AgentType", "AgentTypeDesc01");
                }
                dsResult = null;
                strSql = null;
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetAgentTypeForSlsChnnlCT", ex);
            }
        }
        #endregion

        #region GetLevelType Method
        public void GetLevelType(DropDownList ddl, string strBizSrc, string strChnCls, string UntRnk)
        {
            try
            {
                string strSql = string.Empty;
                DataSet dsResult = new DataSet();
                htable.Clear();
                htable.Add("@BizSrc", strBizSrc);
                htable.Add("@ChnnlClass", strChnCls);
                htable.Add("@UntRnk", UntRnk);
                dsResult = objDAL.GetDataSetForPrc("Prc_AgnLvl", htable);
                if (dsResult.Tables.Count > 0)
                {
                    FillDropDown(ddl, dsResult.Tables[0], "UnitRank", "UnitRank");
                }
                dsResult = null;
                strSql = null;
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetLevelType", ex);
            }
        }
        #endregion

        #region FillDropDownMethod
        public void FillDropDown(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
        {
            try
            {
                drpList.Items.Clear();
                drpList.DataSource = dtTable;
                drpList.DataValueField = dtTable.Columns[strValue].ToString();
                drpList.DataTextField = dtTable.Columns[strText].ToString();
                drpList.DataBind();
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "FillDropDown", ex);
            }
        }
        #endregion

        #region GetChannel Method
        public void GetChannel(DropDownList ddl, int flag, string UserID, string BizSrc)
        {
            try
            {
                string strSql = string.Empty;
                DataSet dsResult = new DataSet();
                htable.Clear();
                htable.Add("@flag", flag.ToString().Trim());
                htable.Add("@BizSrc", BizSrc);
                dsResult = objDAL.GetDataSetForPrc("Prc_AgnRepoType", htable);
                if (dsResult.Tables.Count > 0)
                {
                    FillDropDown(ddl, dsResult.Tables[0], "BizSrc", "ChannelDesc01");
                }
                dsResult = null;
                strSql = null;
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetChannel", ex);
            }
        }
        #endregion

        #region GetRepoType Method
        protected void GetRepoType(DropDownList ddl)
        {
            try
            {
                SqlDataReader drRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@LookupCode", "RptUntTyp");
                htParam.Add("@ParamValue", "CF");
                drRead = objDAL.exec_reader_prc_inscdirect("Prc_GetRepoType", htParam);
                if (drRead.HasRows)
                {
                    ddl.DataSource = drRead;
                    ddl.DataTextField = "ParamDesc01";
                    ddl.DataValueField = "ParamValue";
                    ddl.DataBind();
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetRepoType", ex);
            }
        }
        #endregion

        #region GetUnitLevelPrimary
        protected void GetUnitLevelPrimary(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtddlRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                if (Request.QueryString["Code"] != null)
                {
                    htParam.Add("@BizSrc", ddlchannel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlsubchannel.SelectedValue.ToString().Trim());
                }
                else
                {
                    htParam.Add("@BizSrc", ddlchannel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlsubchannel.SelectedValue.ToString().Trim());
                }
                htParam.Add("@flag", 1);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtLevel.Text.Trim());////added by akshay for Relation Unit Type on 24/03/14
                htParam.Add("@RuleType", ddlPriRuleType.SelectedValue.Trim());
                dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetUnitType", htParam);
                if (dtddlRead.HasRows)
                {
                    ddl.DataSource = dtddlRead;
                    ddl.DataTextField = "UnitDesc01";
                    ddl.DataValueField = "UnitType";
                    ddl.DataBind();
                }
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "GetUnitLevelPrimary", ex);
            }
           
        }
        #endregion

        #region GetUnitRankPrimary
        protected void GetUnitRankPrimary(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtddlRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();

                if (Request.QueryString["Code"] != null)
                {
                    htParam.Add("@BizSrc", ddlchannel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlsubchannel.SelectedValue.ToString().Trim());
                }
                else
                {
                    htParam.Add("@BizSrc", ddlchannel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlsubchannel.SelectedValue.ToString().Trim());
                }

                htParam.Add("@flag", 2);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtLevel.Text.Trim());////added by akshay for Relation Unit Type on 24/03/14
                htParam.Add("@RuleType", ddlPriRuleType.SelectedValue.Trim());
                dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetUnitType", htParam);
                if (dtddlRead.HasRows)
                {
                    ddl.DataSource = dtddlRead;
                    ddl.DataTextField = "UnitRank";
                    ddl.DataValueField = "UnitRank";
                    ddl.DataBind();
                }
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetUnitRankPrimary", ex);
            }
        }
        #endregion

        #region GetUnitLevelAddl
        protected void GetUnitLevelAddl(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtddlRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                if (Request.QueryString["Code"] != null)
                {
                    htParam.Add("@BizSrc", ddlam1channel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlam1subchannel.SelectedValue.ToString().Trim());
                }
                else
                {
                    htParam.Add("@BizSrc", ddlam1channel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlam1subchannel.SelectedValue.ToString().Trim());
                }
                htParam.Add("@flag", 1);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtLevel.Text.Trim());////added by akshay for Relation Unit Type on 24/03/14
                htParam.Add("@RuleType", ddlAdlRuleType.SelectedValue.Trim());
                dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetUnitType", htParam);
                if (dtddlRead.HasRows)
                {
                    ddl.DataSource = dtddlRead;
                    ddl.DataTextField = "UnitDesc01";
                    ddl.DataValueField = "UnitType";
                    ddl.DataBind();
                }
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "GetUnitLevelAddl", ex);
            }
        }
        #endregion

        #region GetUnitRankAddl
        protected void GetUnitRankAddl(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtddlRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                if (Request.QueryString["Code"] != null)
                {
                    htParam.Add("@BizSrc", ddlam1channel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlam1subchannel.SelectedValue.ToString().Trim());
                }
                else
                {
                    htParam.Add("@BizSrc", ddlam1channel.SelectedValue.ToString().Trim());
                    htParam.Add("@Chncls", ddlam1subchannel.SelectedValue.ToString().Trim());
                }

                htParam.Add("@flag", 2);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtLevel.Text.Trim());////added by akshay for Relation Unit Type on 24/03/14
                htParam.Add("@RuleType", ddlAdlRuleType.SelectedValue.Trim());
                dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetUnitType", htParam);
                if (dtddlRead.HasRows)
                {
                    ddl.DataSource = dtddlRead;
                    ddl.DataTextField = "UnitRank";
                    ddl.DataValueField = "UnitRank";
                    ddl.DataBind();
                }
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetUnitRankAddl", ex);
            }
        }
        #endregion

        #region getam1subchannel Method
        public void getam1subchannel()
        {
            try
            {
                ddlam1subchannel.Items.Clear();
                ddlam1basedon.SelectedIndex = 0;
                ddlam1levelagttype.Items.Clear();
                ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userid = Session["UserID"].ToString();
                objCommonU.GetUserChnclsChannel(ddlam1subchannel, ddlam1channel.SelectedValue, 0, userid.ToString());
                ddlam1subchannel.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "getam1subchannel", ex);
            }
        }
        #endregion

        #region getLevelAgentTypeAM1 Method
        public void getLevelAgentTypeAM1()
        {
            try
            {
                ddlam1levelagttype.Items.Clear();
                ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userID = Session["UserID"].ToString();
                if (ddlam1basedon.SelectedValue == "1")
                {
                    GetAgentTypeForSlsChnnlCT(ddlam1levelagttype, ddlam1channel.SelectedValue, ddlam1basedon.SelectedValue, ddlam1subchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam1basedon.SelectedValue == "0")
                {
                    GetLevelType(ddlam1levelagttype, ddlam1channel.SelectedValue, ddlam1subchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "getLevelAgentTypeAM1", ex);
            }
        }
        #endregion

        #region GetAdlRelRule method
        protected void GetAdlRelRule()
        {
            try
            {
                SqlDataReader drRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@LookupCode", "AddlRptRule");
                drRead = objDAL.exec_reader_prc_inscdirect("Prc_GetAdlRepoRuleForUnit", htParam);
                if (drRead.HasRows)
                {
                    ////ddladditionalreportingrule.DataSource = drRead;
                    /////ddladditionalreportingrule.DataTextField = "ParamDescr";
                    /////ddladditionalreportingrule.DataValueField = "ParamVal";
                    /////ddladditionalreportingrule.DataBind();
                }
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "GetAdlRelRule", ex);
            }
        }
        #endregion

        #region ddlam2reportingtype_SelectedIndexChanged method
        protected void ddlam2reportingtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string userID = Session["UserID"].ToString();
                if (ddlam2reportingtype.SelectedValue == "CF")
                {
                    ddlam2channel.Items.Clear();
                    if (Request.QueryString["Code"] != null)
                    {
                        //if (Request.QueryString["flag"].ToString().Trim() == "E")
                        //{
                        GetChannel(ddlam2channel, 1, userID, Request.QueryString["BizSrc"].ToString().Trim());
                    }
                    else
                    {
                        GetChannel(ddlam2channel, 1, userID, ddlSalesChannel.SelectedValue);
                    }
                    //}
                    ddlam2channel.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam2reportingtype.SelectedValue == "CU" || ddlam2reportingtype.SelectedValue == "HW" || ddlam2reportingtype.SelectedValue == "CP")
                {
                    ddlam2channel.Items.Clear();
                    GetChannel(ddlam2channel, 2, userID, "");
                    ddlam2channel.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam2reportingtype.SelectedValue == "")
                {
                    ddlam2channel.Items.Clear();
                    ddlam2channel.Items.Insert(0, new ListItem("Select", ""));
                }
                ddlam2subchannel.Items.Clear();
                ddlam2subchannel.Items.Insert(0, new ListItem("Select", ""));
                ddlam2basedon.SelectedIndex = 0;
                ddlam2levelagttype.Items.Clear();
                ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex)
            {
              LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2reportingtype_SelectedIndexChanged", ex);
            }

        }
        #endregion

        #region ddlam2channel_SelectedIndexChanged method
        protected void ddlam2channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getam2subchannel();
            }
            catch (Exception ex)
            {
               LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam2subchannel_SelectedIndexChanged method
        protected void ddlam2subchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlam2channel.SelectedValue == "")
                {
                    ddlam2basedon.SelectedIndex = 0;
                    ddlam2levelagttype.Items.Clear();
                    ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlam2basedon_SelectedIndexChanged method
        protected void ddlam2basedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getLevelAgentTypeAM2();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2basedon_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region getam2subchannel Method
        public void getam2subchannel()
        {
            try
            {
                ddlam2subchannel.Items.Clear();
                ddlam2basedon.SelectedIndex = 0;
                ddlam2levelagttype.Items.Clear();
                ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userid = Session["UserID"].ToString();
                objCommonU.GetUserChnclsChannel(ddlam2subchannel, ddlam2channel.SelectedValue, 0, userid.ToString());
                ddlam2subchannel.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }
        }
        #endregion

        #region getLevelAgentTypeAM2 Method
        public void getLevelAgentTypeAM2()
        {
            try
            {
                ddlam2levelagttype.Items.Clear();
                ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
                string userID = Session["UserID"].ToString();
                if (ddlam2basedon.SelectedValue == "1")
                {
                    GetAgentTypeForSlsChnnlCT(ddlam2levelagttype, ddlam2channel.SelectedValue, ddlam2basedon.SelectedValue, ddlam2subchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlam2basedon.SelectedValue == "0")
                {
                    GetLevelType(ddlam2levelagttype, ddlam2channel.SelectedValue, ddlam2subchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "getLevelAgentTypeAM2", ex);
            }
        }
        #endregion

        #region FillAddlRelType method
        protected void FillAddlRelType()
        {
            try
            {
                ddlam1reportingtype.Items.Clear();
                oCommon.getDropDown(ddlam1reportingtype, "RptUntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));
                ddlam2reportingtype.Items.Clear();
                oCommon.getDropDown(ddlam2reportingtype, "RptUntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlam2reportingtype.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "FillAddlRelType", ex);
            }
        }
        #endregion

        #region GetPrimRpt method for filling primary reporting details DDLs
        protected void GetPrimRpt()
        {
            try
            {
                string userID = Session["UserID"].ToString();
                ddlReportingRule.SelectedValue = dtRead["RptRule"].ToString();
                ddlPriRuleType.SelectedValue = dtRead["PrimaryRuleTyp"].ToString();
                ddlPriRptSetup.SelectedValue = dtRead["PrmyRptType"].ToString();
                funchnlpopup(ddlchannel);
                funsubchnlpopup(ddlsubchannel, ddlchannel.SelectedItem.Text);
                ddlchannel.SelectedValue = dtRead["PriChnl"].ToString();
                GetRuleType(ddlchannel, ddlsubchannel, ddlreportingtype, ddlbasedon, ddllevelagttype, ddlPriRuleType, ddlPriRptSetup, ddlReportingRule);
                ddlsubchannel.SelectedValue = dtRead["PriSubChnl"].ToString();
                ddlbasedon.SelectedValue = dtRead["PriBsdOn"].ToString();
                if (dtRead["PriBsdOn"].ToString() == "1")
                {
                    GetUnitLevelPrimary(ddllevelagttype);
                    ddllevelagttype.SelectedValue = dtRead["PrimLvlAgttyp"].ToString();
                    ddllevelagttype.Enabled = true;
                }

                else if (dtRead["PriBsdOn"].ToString() == "0")
                {
                    GetUnitRankPrimary(ddllevelagttype);
                    ddllevelagttype.SelectedValue = dtRead["PrimLvlAgttyp"].ToString();
                    ddllevelagttype.Enabled = true;
                }
                ddllevelagttype.SelectedValue = dtRead["PrimLvlAgttyp"].ToString();
                ddlPriRptSetup.SelectedValue = dtRead["PrmyRptType"].ToString();
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetPrimRpt", ex);
            }
        }
        #endregion

        #region FillRepoTypeDDL
        protected void FillRepoTypeDDL()
        {
            try
            {
                ddlam1reportingtype.Items.Clear();
                GetRepoType(ddlam1reportingtype);
                ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));
                ddlam2reportingtype.Items.Clear();
                GetRepoType(ddlam2reportingtype);
                ddlam2reportingtype.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "FillRepoTypeDDL", ex);
            }
        }
        #endregion

        #region GetAddlMgr1 Method for filling addl manager 1 details DDLs
        protected void GetAddlMgr1()
        {
            try
            {
                string userID = Session["UserID"].ToString();
                ddlAM1RptRule.SelectedValue = dtRead["Addl1RptRule"].ToString().Trim();
                ddlAdlRuleType.SelectedValue = dtRead["Addl1RuleTyp"].ToString().Trim();
                ddlAdlRptStp.SelectedValue = dtRead["AddlRptStp"].ToString().Trim();
                funchnlpopup(ddlam1channel);
                funsubchnlpopup(ddlam1subchannel, ddlam1channel.SelectedItem.Text);
                ddlam1channel.SelectedValue = dtRead["Addl1Channel"].ToString().Trim();
                GetRuleType(ddlam1channel, ddlam1subchannel, ddlam1reportingtype, ddlam1basedon, ddlam1levelagttype, ddlAdlRuleType, ddlAdlRptStp, ddlAM1RptRule);
                ddlam1subchannel.SelectedValue = dtRead["Addl1SubChannel"].ToString().Trim();
                ddlam1basedon.SelectedValue = dtRead["Addl1BsdOn"].ToString().Trim();
                if (dtRead["Addl1BsdOn"].ToString() == "1")
                {
                    GetUnitLevelAddl(ddlam1levelagttype);
                    ddlam1levelagttype.SelectedValue = dtRead["Addl1LvlAgtTyp"].ToString().Trim();
                    ddlam1levelagttype.Enabled = true;
                }
                else if (dtRead["Addl1BsdOn"].ToString() == "0")
                {
                    GetUnitRankAddl(ddlam1levelagttype);
                    ddlam1levelagttype.SelectedValue = dtRead["Addl1LvlAgtTyp"].ToString().Trim();
                    ddlam1levelagttype.Enabled = true;
                }
                ddlAdlRptStp.SelectedValue = dtRead["AddlRptStp"].ToString().Trim();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetAddlMgr1", ex);
            }
        }
        #endregion

        #region GetAddlMgr2 for filling addl manager 2 details
        protected void GetAddlMgr2()
        {
            try
            {
                string userID = Session["UserID"].ToString();
                if (dtRead["Addl2ReptTyp"].ToString().Trim() == "CF")
                {
                    ddlam2channel.SelectedValue = dtRead["Addl2Channel"].ToString();
                    ddlam2channel.Items.Insert(0, new ListItem("Select", ""));
                    getam2subchannel();
                    ddlam2subchannel.SelectedValue = dtRead["Addl2SubChannel"].ToString();
                    ddlam2basedon.SelectedValue = dtRead["Addl2BsdOn"].ToString();
                    getLevelAgentTypeAM2();
                    ddlam2levelagttype.SelectedValue = dtRead["Addl2LvlAgtTyp"].ToString();
                    ddlAM2ReptRule.SelectedValue = dtRead["Addl2ReptRule"].ToString();
                }
                else if (dtRead["Addl2ReptTyp"].ToString() == "CU" || dtRead["Addl2ReptTyp"].ToString() == "HW" || dtRead["Addl2ReptTyp"].ToString() == "CP")
                {
                    GetChannel(ddlam2channel, 2, userID, "");
                    ddlam2channel.SelectedValue = dtRead["Addl2Channel"].ToString();
                    getam2subchannel();
                    ddlam2subchannel.SelectedValue = dtRead["Addl2SubChannel"].ToString();
                    ddlam2basedon.SelectedValue = dtRead["Addl2BsdOn"].ToString();
                    getLevelAgentTypeAM2();
                    ddlam2levelagttype.SelectedValue = dtRead["Addl2LvlAgtTyp"].ToString();
                    ddlAM2ReptRule.SelectedValue = dtRead["Addl2ReptRule"].ToString();
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetAddlMgr2", ex);
            }
         
        }
        #endregion

        #region ddllevelagttype_SelectedIndexChanged
        protected void ddllevelagttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddllevelagttype.Focus();
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }
        }
        #endregion

        #region chkAddl1Mand_CheckedChanged
        protected void chkAddl1Mand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkAddl1Mand.Focus();
                if (chkAddl1Mand.Checked == false)
                {
                    ddlAdlRuleType.SelectedIndex = 0;
                    ddlAM1RptRule.SelectedIndex = 0;
                    ddlam1basedon.SelectedIndex = 0;
                    ddlam1levelagttype.SelectedIndex = 0;
                    ddlAdlRptStp.SelectedIndex = 0;
                    ddlam1subchannel.SelectedIndex = 0;
                    ddlam1reportingtype.SelectedIndex = 0;
                    ddlam1channel.SelectedIndex = 0;
                }
            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "chkAddl1Mand_CheckedChanged", ex);
            }
          
        }
        #endregion

        #region ddlam1levelagttype_SelectedIndexChanged
        protected void ddlam1levelagttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlam1levelagttype.Focus();
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam1levelagttype_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region ddlAM1RptRule_SelectedIndexChanged
        protected void ddlAM1RptRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlAM1RptRule.Focus();

            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }
        }
        #endregion

        #region ddlAdlRuleType_SelectedIndexChanged
        protected void ddlAdlRuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetRuleType(ddlam1channel, ddlam1subchannel, ddlam1reportingtype, ddlam1basedon, ddlam1levelagttype, ddlAdlRuleType, ddlAdlRptStp, ddlAM1RptRule);
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }
        }
        #endregion

        #region ddlPriRuleType_SelectedIndexChanged
        protected void ddlPriRuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetRuleType(ddlchannel, ddlsubchannel, ddlreportingtype, ddlbasedon, ddllevelagttype, ddlPriRuleType, ddlPriRptSetup, ddlReportingRule);

            }
            catch (Exception ex) 
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlPriRuleType_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region chkPriMand_CheckedChanged
        protected void chkPriMand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkPriMand.Checked == false)
                {
                    ddlPriRuleType.SelectedIndex = 0;
                    ddlReportingRule.SelectedIndex = 0;
                    ddllevelagttype.SelectedIndex = 0;
                    ddlPriRptSetup.SelectedIndex = 0;
                    ddlbasedon.SelectedIndex = 0;
                }
            }
            catch (Exception ex) 
            {

                LogException("ISYS-CHMS", "UnitNew.aspx", "chkPriMand_CheckedChanged", ex);
            }
        }
        #endregion

        #region funrptsubchnl
        protected void funrptsubchnl(string BizSrc, int flag, DropDownList ddlrule, DropDownList ddlsub)
        {
            try
            {
                ddlsub.Items.Clear();
                SqlDataReader dtRead;
                DataSet ds = new DataSet();
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@BizSrc", BizSrc);
                htparam.Add("@ruletype", ddlrule.SelectedValue.Trim());
                htparam.Add("@flag", flag);
                dtRead = objDAL.Common_exec_reader_prc("Prc_GetRuleTypeSubClass", htparam);
                if (dtRead.HasRows)
                {
                    ddlsub.DataSource = dtRead;
                    ddlsub.DataTextField = "ChnClsDesc01";
                    ddlsub.DataValueField = "ChnCls";
                    ddlsub.DataBind();
                }
                ds = objDAL.GetDataSetForPrcCLP("Prc_GetRuleTypeSubClass", htparam);
                ////lstSChnl.DataSource = ds;
                if (ddlrule == ddlPriRptSetup)
                {
                    ViewState["dsPriRpt"] = ds;
                }
                else if (ddlrule == ddlAdlRuleType)
                {
                    ViewState["dsAdlRpt"] = ds;
                }
                dtRead = null;
                ddlsub.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ddlam2subchannel_SelectedIndexChanged", ex);
            }
        }
        #endregion

        #region funchnlpopup
        protected void funchnlpopup(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtRead;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
                if (dtRead.HasRows)
                {
                    ddl.DataSource = dtRead;
                    ddl.DataTextField = "ChannelDesc01";
                    ddl.DataValueField = "BizSrc";
                    ddl.DataBind();
                }
                dtRead = null;
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "funchnlpopup", ex);
            }
        }
        #endregion

        #region funsubchnlpopup
        protected void funsubchnlpopup(DropDownList ddl, string txt)
        {
            try
            {
                ddl.Items.Clear();
                SqlDataReader dtRead;
                Hashtable htparam = new Hashtable();
                htparam.Clear();
                htparam.Add("@chnl", txt.Trim());
                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlmgrsubchnnl", htparam);
                if (dtRead.HasRows)
                {
                    ddl.DataSource = dtRead;
                    ddl.DataTextField = "ChnClsDesc01";
                    ddl.DataValueField = "ChnCls";
                    ddl.DataBind();
                }
                dtRead = null;
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "funsubchnlpopup", ex);
            }
        }
        #endregion

        #region GetRuleType
        protected void GetRuleType(DropDownList ddlchn, DropDownList ddlsub, DropDownList ddlrep, DropDownList ddlbsdon, DropDownList ddlunittyp,
            DropDownList ddlRuleTyp, DropDownList ddlStp, DropDownList ddlrptrule)
        {
            try
            {
                if (ddlRuleTyp.SelectedValue == "SCSS")
                {
                    funchnlpopup(ddlchn);
                    ddlrep.SelectedValue = "CF";
                    ddlrep.Enabled = false;
                    if (Request.QueryString["Code"] != null)
                    {
                        ddlchn.SelectedValue = Request.QueryString["BizSrc"].ToString().Trim();
                        funrptsubchnl(ddlchn.SelectedValue, 1, ddlRuleTyp, ddlsub);
                        ddlsub.SelectedValue = Request.QueryString["Chanl"].ToString().Trim();
                    }
                    else
                    {
                        ddlchn.SelectedValue = ddlSalesChannel.SelectedValue.Trim();
                        funrptsubchnl(ddlchn.SelectedValue, 2, ddlRuleTyp, ddlsub);
                        ddlsub.SelectedValue = ddlChannelClass.SelectedValue.Trim();
                    }
                    ddlchn.Enabled = false;
                    ddlsub.Enabled = false;
                    ddlbsdon.Enabled = true;
                    ddlunittyp.Enabled = true;
                    ddlStp.Enabled = true;
                    ddlrptrule.Enabled = true;
                }
                else if (ddlRuleTyp.SelectedValue == "SCDSP" || ddlRuleTyp.SelectedValue == "SCDSS")
                {
                    funchnlpopup(ddlchn);
                    ddlrep.SelectedValue = "CU";
                    if (Request.QueryString["Code"] != null)
                    {
                        ddlchn.SelectedValue = Request.QueryString["BizSrc"].ToString().Trim();
                    }
                    else
                    {
                        ddlchn.SelectedValue = ddlSalesChannel.SelectedValue.Trim();
                    }
                    funrptsubchnl(ddlchn.SelectedValue.ToString().Trim(), 1, ddlRuleTyp, ddlsub);
                    ddlchn.Enabled = false;
                    ddlsub.Enabled = true;
                    ddlbsdon.Enabled = true;
                    ddlunittyp.Enabled = true;
                    ddlStp.Enabled = true;
                    ddlrptrule.Enabled = true;
                }
                else if (ddlRuleTyp.SelectedValue == "")
                {
                    ddlrep.SelectedValue = "";
                    ddlchn.SelectedValue = "";
                    ddlsub.SelectedValue = "";
                    ddlbsdon.SelectedValue = "";
                    ddlunittyp.SelectedValue = "";
                    ddlStp.SelectedValue = "";
                    ddlrptrule.SelectedValue = "";
                    ddlrep.Enabled = false;
                    ddlchn.Enabled = false;
                    ddlsub.Enabled = false;
                    ddlbsdon.Enabled = false;
                    ddlunittyp.Enabled = false;
                    ddlStp.Enabled = false;
                }
                else
                {
                    funchnlpopup(ddlchn);
                    ddlrep.SelectedValue = "CU";
                    if (Request.QueryString["Code"] != null)
                    {
                        funrptsubchnl(ddlchn.SelectedValue, 2, ddlRuleTyp, ddlsub);
                    }
                    else
                    {
                        funrptsubchnl(ddlchn.SelectedValue, 2, ddlRuleTyp, ddlsub);
                    }
                    ddlchn.Enabled = true;
                    ddlsub.Enabled = true;
                    ddlbsdon.Enabled = true;
                    ddlunittyp.Enabled = true;
                }
                ddlbsdon.SelectedValue = "";
                ddlunittyp.Items.Clear();
                ddlunittyp.Items.Insert(0, new ListItem("Select", ""));
                ddlStp.SelectedValue = "";
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetRuleType", ex);
            }
        }
        #endregion

        #region rbCorrection_OnSelectedIndexChanged
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ControlEnableddesable();
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "rbCorrection_OnSelectedIndexChanged", ex);
            }
        }
        #endregion

        #region Enable Or Disable Functionality Based On Chage Or Correction Event.
        private void ControlEnableddesable()
        {
            try
            {
                if (rbCorrection.SelectedValue == "CR")
                {
                    ddlUnitRank.Enabled = false;
                    ddlMultiMgr.Enabled = false;
                    ddlPriRuleType.Enabled = false;
                    ddlReportingRule.Enabled = false;
                    ddlAdlRuleType.Enabled = false;
                    ddlAM1RptRule.Enabled = false;
                    ddlsubchannel.Enabled = false;
                    ddllevelagttype.Enabled = false;
                    ddlPriRptSetup.Enabled = false;
                    ddlbasedon.Enabled = false;
                    ddlchannel.Enabled = false;
                    ddlreportingtype.Enabled = false;
                    ddlam1subchannel.Enabled = false;
                    ddlam1levelagttype.Enabled = false;
                    ddlam1basedon.Enabled = false;
                    ddlam1reportingtype.Enabled = false;
                    ddlam1channel.Enabled = false;
                    txtVer.Enabled = false;
                    txtCseDt.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " Chk(0);", true);
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                }
                else
                {
                    ddlUnitRank.Enabled = true;
                    ddlMultiMgr.Enabled = true;
                    ddlPriRuleType.Enabled = true;
                    ddlReportingRule.Enabled = true;
                    ddlAdlRuleType.Enabled = true;
                    ddlAM1RptRule.Enabled = true;
                    ddlsubchannel.Enabled = true;
                    ddllevelagttype.Enabled = true;
                    ddlPriRptSetup.Enabled = true;
                    ddlbasedon.Enabled = true;
                    ddlchannel.Enabled = true;
                    ddlreportingtype.Enabled = true;
                    ddlam1subchannel.Enabled = true;
                    ddlam1levelagttype.Enabled = true;
                    ddlam1basedon.Enabled = true;
                    ddlam1reportingtype.Enabled = true;
                    ddlam1channel.Enabled = true;
                    txtVer.Enabled = false;
                    txtCseDt.Enabled = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " Chk(0);", true);
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "ControlEnableddesable", ex);
            }
        }
        #endregion

        #region after update rb hide
        public void RBHIDE()
        {
            try
            {
                if (rbCorrection.SelectedValue == "CH")
                {
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");
                }
                if (rbCorrection.SelectedValue == "CR")
                {
                    rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                    rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "RBHIDE", ex);
            }

        }
        #endregion

        protected void btnRptMgr_Click(object sender, EventArgs e)
        {
            if (ddlchannel.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Hierarchy Name.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlsubchannel.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Sub Class.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlbasedon.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Based On.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddllevelagttype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Relation Member Type.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlPriRptSetup.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select  Reporting Setup.');</script>", false);
                return;
            }
            if (ddlPriRptSetup.SelectedIndex != 0)
            {
                GetManagers();
            }
        }

        protected void GetManagers()
        {
            try
            {
                if (Request.QueryString["Flag"] != "N")
                {
                    hdnMemCode.Value = Request.QueryString["Code"].ToString().Trim();
                }
                if (hdnMemRole.Value != "")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlchannel.SelectedValue.Trim() + "','" + ddlsubchannel.SelectedValue.Trim() + "','" + ddllevelagttype.SelectedValue + "','" + hdnMemRole.Value.Trim() + "','" + ddlbasedon.SelectedValue.ToString().Trim() + "','" + ddlPriRptSetup.SelectedValue.ToString() + "','" + ddlreportingtype.SelectedValue.ToString() + "','');return false;");
                }
                else
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlchannel.SelectedValue.Trim() + "','" + ddlsubchannel.SelectedValue.Trim() + "','" + ddllevelagttype.SelectedValue + "','','" + txtUnitType.Text + "','" + ddlPriRptSetup.SelectedValue.ToString() + "','" + ddlreportingtype.SelectedValue.ToString() + "','');return false;");
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "UnitNew.aspx", "GetManagers", ex);

            }
        }
    }
}



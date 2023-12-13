using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Xml;
using CLTMGR;
using DataAccessClassDAL;
namespace INSCL
{
    public partial class AGTLevel : Base
    {
        #region Variable Daclaration
        SqlDataReader dtRead;
        XmlDocument doc = new XmlDocument();
        Hashtable htable = new Hashtable();
        CommonFunc oCommon = new CommonFunc();
        DataSet dsResult = new DataSet();
        ErrLog objErr = new ErrLog();
        Hashtable htParam = new Hashtable();
        //changed by nitin
        //DataAccessLayer objDAL = new DataAccessLayer();
        DataAccessClass objDAL = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();

        EncodeDecode ObjDec = new EncodeDecode();
        private const string Conn_Direct = "DefaultConn";
        private multilingualManager olng;
        private string strUserLang;
        string ErrMsg, AuditType, strXML = "";
        string ddlinit = "-- Select --";
        string memtype = "";
        string strFlag;
        string Flag;
        string channel = "";
        string AgtType = "";
        string chkUM;
        string ChnTyp;
        int chkPos;
        int chkPMd;


        #endregion

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "AGTLevel.aspx", strUserLang);
            string userID = Session["UserID"].ToString();
            lnkbtnaddprod.Attributes.Add("onclick", "funcShowPopupLOB();return false;");

            #region !IsPostBack
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["Flag"] != "N")
                    {
                        hdnMemCode.Value = Request.QueryString["AgtType"].ToString().Trim();
                    }
                    Session["OldProductDetails"] = null;
                    Session["ProductDetails"] = null;
                    fillFinyr();
                    //lnkbtnaddprod.Attributes.Add("onclick", "funcShowPopupLOB();return false;");
                    if (Request.QueryString["flag"].ToString() == "E")
                    {
                        if (Request.QueryString["AgtType"].ToString() != "" && Request.QueryString["Saleschnl"].ToString() != "" && Request.QueryString["flag"].ToString() == "E")
                        {
                            hdnChntype.Value = "M";
                        }
                    }
                    InitializeControl();
                    txtEffDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    FillAllDdl();
                    LoadData();
                }
                catch (Exception ex)
                {
                    LogException("ISYS-CHMS", "AGTLevel.aspx", "Page_Load", ex);

                }
            }
            #endregion
        }
        #endregion

        public void FillAllDdl()
        {
            oCommon.getRadio(rdlAlwRecAgt, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rdlAllowSls, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rdlAllowSer, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rdlLicReq, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rdlTDS, "cboyesno", Session["UserLangNum"].ToString(), "", 0);//added by usha for TDS 
            rdlTDS.SelectedValue = "Y"; //added by usa for gst 
            oCommon.getRadio(RadioGstRegion, "cboyesno", Session["UserLangNum"].ToString(), "", 0);//added by usha for TDS  
            RadioGstRegion.SelectedValue = "N"; //added by usa for gst 
            oCommon.getRadio(RadioLblExecption, "cboyesno", Session["UserLangNum"].ToString(), "", 0);//added by usha for TDS RadioGstpayout
            RadioLblExecption.SelectedValue = "Y"; //added by usa for gst 
            oCommon.getRadio(RadioGstpayout, "cboyesno", Session["UserLangNum"].ToString(), "", 0);//added by usha for TDS RadioGstpayout
            RadioGstpayout.SelectedValue = "Y"; //added by usa for gst 
            DdlRegistraction.Items.Insert(0, new ListItem("Select", ""));

            oCommon.getDropDown(ddlAgtCreateRul, "AgtCreatRl", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);   //Added ddlcreaterul by venkat on 17/10/07
            oCommon.getRadio(rdlEmpCode, "cboyesno", Session["UserLangNum"].ToString(), "", 0);   //Added rdlEmpCode by akshay on 06/12/13
            oCommon.getRadio(rdlAllowPrRept, "cboyesno", Session["UserLangNum"].ToString(), "", 0);  //Added ddlcreaterul by akshay on 06/12/13

            oCommon.getDropDown(ddlreportingtype, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlreportingtype.Items.Insert(0, new ListItem("Select", ""));

            oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddladditionalreportingrule, "AddlRptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlbasedon, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlUMBasedOn, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            //added By Ajay start 18-02-2022
            oCommon.getDropDown(ddlUMBasedOn1, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlUnitLoc1, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            //ddlUSubCls.SelectedValue = dtRead["UnitSubClass"].ToString();
            //added By Ajay end 18-02-2022
            PopulateMemRole();
            oCommon.getDropDown(ddlUnitLoc, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlRptSetup, "RptSetup", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlRptSetup.Items.Insert(0, new ListItem("Select", ""));
            ddlRptLevel.Items.Insert(0, new ListItem("Select", ""));
            // ddlCmpStaff.Items.Insert(0, new ListItem("Select", ""));
            ddlAgtCreateRul.Items.Insert(0, new ListItem("-- Select --", ""));

            ddlReportingRule.Items.Insert(0, new ListItem("Select", ""));
            ddladditionalreportingrule.Items.Insert(0, new ListItem("Select", ""));
            ddlbasedon.Items.Insert(0, new ListItem("Select", ""));
            ddlUMBasedOn.Items.Insert(0, new ListItem("Select", ""));
            ddlUMBasedOn1.Items.Insert(0, new ListItem("Select", ""));
            ddlUnitLoc.Items.Insert(0, new ListItem("Select", ""));
            ddlUnitLoc1.Items.Insert(0, new ListItem("Select", ""));
            rdlAlwRecAgt.SelectedValue = "N";
            rdlAllowSls.SelectedValue = "N";
            rdlEmpCode.SelectedValue = "N";
            rdlAllowPrRept.SelectedValue = "N";
            rdlLicReq.SelectedValue = "N";
            rdlAllowSer.SelectedValue = "N";
            DisableDDL();
            oCommon.getRadio(rbltrf, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rblter, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rblrein, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rblpromo, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rbldemo, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rblcreate, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            oCommon.getRadio(rblmodify, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
            rbltrf.SelectedValue = "N";
            rblter.SelectedValue = "N";
            rblrein.SelectedValue = "N";
            rblpromo.SelectedValue = "N";
            rbldemo.SelectedValue = "N";
            rblcreate.SelectedValue = "N";
            rblmodify.SelectedValue = "N";
            ddlAgtCreateRul.SelectedIndex = 2;
            ddlAgtCreateRul.Enabled = false;
        }


        public void LoadData()
        {
            try
            {
                string userID = Session["UserID"].ToString();
                if (Request.QueryString["flag"].ToString() != "")
                {
                    strFlag = Request.QueryString["flag"].ToString();
                    if (strFlag == "N")
                    {
                        Hashtable htParam = new Hashtable();
                        txtVer.Text = "1.00";
                        txtVer.Enabled = false;
                        hdnProdcodeEdit.Value = strFlag;
                        lblAgtTypeVal.Visible = false;
                        txtAgtTypeVal.Visible = true;
                        ddlSalesChannel.Visible = true;
                        lblSalesChannelVal.Visible = false;
                        trAgentTypes.Visible = false;
                        divmvMnHdr.Visible = false;
                        divModification.Attributes.Add("style", "display:none;margin-left:2%;margin-right:2%;");
                        btnUpdate.Visible = false;
                        btnshowHist.Visible = false;
                        htParam.Clear();
                        htParam.Add("@carriercode", "2");
                        htParam.Add("@strIncMasterCmp", "1");
                        FillDropDown(ddlSalesChannel, "Prc_GetSalesChannel", htParam, "INSCCommonConnectionString", "", "ChannelDesc01", "BizSrc");


                        objCommonU.GetSalesChannel(ddlUChnnl, "", 1);
                        ddlUChnnl.Items.Insert(0, new ListItem("Select", ""));
                        //added by ajay start 18 - 02 - 2022
                        objCommonU.GetSalesChannel(ddlUChnnl1, "", 1);
                        ddlUChnnl1.Items.Insert(0, new ListItem("Select", ""));
                        //added by ajay end 18 - 02 - 2022
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", Request.QueryString["chncls"].ToString());
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "Select", "ChnlDesc", "ChnCls");
                        ddlUnitRank.Items.Clear();

                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", Request.QueryString["chncls"].ToString());
                        FillDropDown(ddlUnitRank, "Prc_UnitRnkchnnlsubcls", htParam, "INSCCommonConnectionString", "", "UnitRank", "UnitRank");

                        btnUpdate.Attributes.Add("onClick", "javascript: return funValidateNew();");
                    }
                    else if (strFlag == "E")
                    {

                        hdnProdcodeEdit.Value = strFlag;
                        divmvMnHdr.Visible = true;
                        Hashtable htParam = new Hashtable();
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString());
                        objCommonU.GetSalesChannel(ddlUChnnl, "", 1);
                        ddlUChnnl.Items.Insert(0, new ListItem("Select", ""));
                        //added by ajay start 18 - 02 - 2022
                        objCommonU.GetSalesChannel(ddlUChnnl1, "", 1);
                        ddlUChnnl1.Items.Insert(0, new ListItem("Select", ""));
                        //added by ajay end 18 - 02 - 2022
                        ControlEnableddesable();
                        btnUpdate.Visible = true;
                        btnshowHist.Visible = true;
                        btnSave.Visible = false;//added by ajay
                        FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");

                        ddlChnnlClass.Enabled = false;
                        if (Request.QueryString["SubClass"] != null)
                        {
                            foreach (ListItem lstItem in ddlChnnlClass.Items)
                            {
                                if (Request.QueryString["SubClass"] == lstItem.Value)
                                {
                                    ddlChnnlClass.SelectedValue = Request.QueryString["SubClass"];
                                    break;
                                }
                            }
                        }
                        lblAgtTypeVal.Visible = true;
                        txtAgtTypeVal.Visible = false;
                        lblAgtTypeVal.Text = Request.QueryString["AgtTypeDesc"].ToString();
                        lblSalesChannelVal.Visible = true;
                        ddlSalesChannel.Visible = false;
                        lblSalesChannelVal.Text = Request.QueryString["ChnlDesc"].ToString();
                        SqlDataReader drRead;
                        htParam.Clear();
                        htParam.Add("@CarrierCode", "2");
                        htParam.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString());
                        drRead = objDAL.Common_exec_reader_prc_common("Prc_UnitRnkchnnlsubcls", htParam);
                        if (drRead.HasRows)


                        {
                            ddlUnitRank.DataSource = drRead;
                            ddlUnitRank.DataTextField = "UnitRank";
                            ddlUnitRank.DataValueField = "UnitRank";
                            ddlUnitRank.DataBind();
                        }
                        clsAgentLevelSetup objAgtType = new clsAgentLevelSetup();
                        dtRead = objAgtType.selAgentLvlDet(Request.QueryString["SalesChnl"].ToString(), Request.QueryString["AgtType"].ToString().Trim(), 2, ddlChnnlClass.SelectedValue, Request.QueryString["chnltyp"].ToString().Trim());
                        if (dtRead.Read())
                        {

                            //Added by sanoj 
                            rdlTDS.SelectedValue = dtRead["TdsFlag"].ToString();
                            TxtCommision.Text = dtRead["CommGlCode"].ToString();
                            RadioLblExecption.SelectedValue = dtRead["TdsExeAllwd"].ToString();
                            TextBox1.Text = dtRead["OthPayGlCode"].ToString();
                            TextLimit.Text = dtRead["TdsStdExemLmt"].ToString();
                            RadioGstRegion.SelectedValue = dtRead["GstRegReq"].ToString();
                            RadioGstpayout.SelectedValue = dtRead["GstPayUndrRcm"].ToString();
                            //End by sanoj

                            ddlAgtCreateRul.SelectedValue = dtRead["MemCreateRul"].ToString(); //added by venkat on 17/10/07
                            ddlUnitRank.SelectedValue = Request.QueryString["UnitRank"].ToString();
                            string ur = ddlUnitRank.SelectedValue.ToString();
                            txtAgentLvl.Text = dtRead["MemLevel"].ToString();
                            txtAgtTypeDesc01.Text = dtRead["MemTypeDesc01"].ToString();
                            txtAgtTypeDesc02.Text = dtRead["MemTypeDesc02"].ToString();
                            txtAgtTypeDesc03.Text = dtRead["MemTypeDesc03"].ToString();
                            if (dtRead["AlwRecruitMem"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtRead["AlwRecruitMem"].ToString()) == false)
                                {
                                    rdlAlwRecAgt.SelectedIndex = 0;
                                }
                                else if (Convert.ToBoolean(dtRead["AlwRecruitMem"].ToString()) == true)
                                {
                                    rdlAlwRecAgt.SelectedIndex = 1;
                                }
                            }
                            if (dtRead["MemRoleCode"].ToString() != "")
                            {

                                ddlCmpStaff.SelectedValue = dtRead["MemRoleCode"].ToString().Trim();
                            }
                            if (dtRead["AlwSls"].ToString() != "")
                            {
                                if (Convert.ToBoolean(dtRead["AlwSls"].ToString()) == false)
                                {
                                    rdlAllowSls.SelectedValue = "N";
                                }
                                else if (Convert.ToBoolean(dtRead["AlwSls"].ToString()) == true)
                                {
                                    rdlAllowSls.SelectedValue = "Y";
                                }
                            }

                            if (dtRead["IsCmpStaff"].ToString() != "")
                            {
                                if (dtRead["IsCmpStaff"].ToString().Trim() == "Y")
                                {
                                    rdlEmpCode.SelectedValue = "Y";
                                }
                                else if (dtRead["IsCmpStaff"].ToString().Trim() == "N")
                                {
                                    rdlEmpCode.SelectedValue = "N";
                                }
                            }
                            if (dtRead["AllwPrRept"].ToString().Trim() == "0")
                            {
                                rdlAllowPrRept.SelectedValue = "N";
                                DisableDDL();
                            }
                            else if (dtRead["AllwPrRept"].ToString().Trim() == "1")
                            {
                                rdlAllowPrRept.SelectedValue = "Y";
                                EnableDDL();
                            }
                            #region Movement SubType
                            if (dtRead["IsMvmtTrf"].ToString().Trim() != "")
                            {
                                rbltrf.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtTrf"].ToString().Trim());
                                ShowMvmtValues(rbltrf, lnkTrfAdd, lnkTrfView);
                                if (rbltrf.SelectedValue == "Y")
                                {
                                    lnkTrfAdd.Text = "Edit Rule";
                                    lnkTrfView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtTrm"].ToString().Trim() != "")
                            {
                                rblter.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtTrm"].ToString().Trim());
                                ShowMvmtValues(rblter, lnkTrmAdd, lnkTrmView);
                                if (rblter.SelectedValue == "Y")
                                {
                                    lnkTrmAdd.Text = "Edit Rule";
                                    lnkTrmView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtReInst"].ToString().Trim() != "")
                            {
                                rblrein.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtReInst"].ToString().Trim());
                                ShowMvmtValues(rblrein, lnkReinAdd, lnkReinView);
                                if (rblrein.SelectedValue == "Y")
                                {
                                    lnkReinAdd.Text = "Edit Rule";
                                    lnkReinView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtPromo"].ToString().Trim() != "")
                            {
                                rblpromo.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtPromo"].ToString().Trim());
                                ShowMvmtValues(rblpromo, lnkPrmAdd, lnkPrmView);
                                if (rblpromo.SelectedValue == "Y")
                                {
                                    lnkPrmAdd.Text = "Edit Rule";
                                    lnkPrmView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtDemo"].ToString().Trim() != "")
                            {
                                rbldemo.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtDemo"].ToString().Trim());
                                ShowMvmtValues(rbldemo, lnkDemoAdd, lnkDemoView);
                                if (rbldemo.SelectedValue == "Y")
                                {
                                    lnkDemoAdd.Text = "Edit Rule";
                                    lnkDemoView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtCreate"].ToString().Trim() != "")
                            {
                                rblcreate.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtCreate"].ToString().Trim());
                                ShowMvmtValues(rblcreate, lnkCrtAdd, lnkCrtView);
                                if (rblcreate.SelectedValue == "Y")
                                {
                                    lnkCrtAdd.Text = "Edit Rule";
                                    lnkCrtView.Visible = true;
                                }
                            }
                            if (dtRead["IsMvmtModify"].ToString().Trim() != "")
                            {
                                rblmodify.SelectedIndex = Convert.ToInt32(dtRead["IsMvmtModify"].ToString().Trim());
                                ShowMvmtValues(rblmodify, lnkModAdd, lnkModView);
                                if (rblmodify.SelectedValue == "Y")
                                {
                                    lnkModAdd.Text = "Edit Rule";
                                    lnkModView.Visible = true;
                                }
                            }
                            #endregion
                            #region Primary Reporting Details Data fetching
                            ddlreportingtype.SelectedValue = dtRead["PrimaryReportingType"].ToString();
                            GetPrimRpt();
                            #endregion
                            #region Additional Manager Selection based on Reporting rule
                            ddladditionalreportingrule.SelectedValue = dtRead["AddlReportingRule"].ToString().Trim();
                            FillGrid(ddladditionalreportingrule.SelectedValue.ToString().Trim());
                            MultiSelect();
                            getaddlmgr1();
                            #endregion
                            #region Unit Manager Details Data Fetching
                            if (dtRead["IsUnitManager"].ToString().Trim() == "True")
                            {
                                chkIsUM.Checked = true;
                            }
                            else
                            {
                                chkIsUM.Checked = false;
                            }
                            ddlUChnnl.SelectedValue = dtRead["Unitchannel"].ToString().Trim();
                            ddlUChnnl1.SelectedValue = dtRead["Unitchannel"].ToString().Trim();

                            ddlUChnnl.Enabled = true;
                            objCommonU.GetUserChnclsChannel(ddlUSubCls, ddlUChnnl.SelectedValue, 0, Session["UserId"].ToString());
                            ddlUSubCls.SelectedValue = dtRead["UnitSubClass"].ToString();
                            ddlUSubCls.Items.Insert(0, new ListItem("Select", ""));
                            ddlUSubCls.Enabled = true;
                            ddlUMBasedOn.SelectedValue = dtRead["UnitMgrBasedOn"].ToString();
                            ddlUMBasedOn.Enabled = true;
                            if (dtRead["UnitMgrBasedOn"].ToString() == "1")
                            {
                                GetUnitLevel();
                                ddlUUnitType.SelectedValue = dtRead["UnitType"].ToString();
                                ddlUUnitType.Enabled = true;
                            }

                            else if (dtRead["UnitMgrBasedOn"].ToString() == "0")
                            {
                                GetUnitRank();
                                ddlUUnitType.SelectedValue = dtRead["UnitType"].ToString();
                                ddlUUnitType.Enabled = true;
                            }
                            if (dtRead["UnitLocation"].ToString() != null)
                            {
                                ddlUnitLoc.SelectedValue = dtRead["UnitLocation"].ToString().Trim();
                            }
                            if (dtRead["PositionReq"].ToString().Trim() == "True")
                            {
                                chkPosReq.Checked = true;
                                chkPosReq.Enabled = false;
                            }
                            else
                            {
                                chkPosReq.Checked = false;
                            }
                            #endregion
                            GetAddlUntMngr();
                            #region InForce/Terminated Agents Details
                            BindAgentGrid();
                            #endregion
                            #region Mandatory Checkboxes
                            if (dtRead["IsPriMand"].ToString().Trim() == "True")
                            {
                                chkPriMand.Checked = true;
                            }
                            else
                            {
                                chkPriMand.Checked = false;
                            }

                            #endregion

                            #region OtherDetails
                            txtFinYr.Text = dtRead["Period"].ToString().Trim();
                            txtVer.Text = dtRead["Version"].ToString().Trim();
                            txtEffDate.Text = dtRead["EffDate"].ToString().Trim();
                            txtCseDt.Text = dtRead["CeaseDate"].ToString().Trim();
                            #endregion
                        }
                        dtRead.Close();
                        btnUpdate.Attributes.Add("onClick", "javascript: return funValidateNew();");
                    }
                    string strcarcode = Session["CarrierCode"].ToString();
                }
                else
                {
                    lblAgtTypeVal.Visible = true;
                    txtAgtTypeVal.Visible = false;
                    rfvLevel.Visible = false;
                }

                if (Request.QueryString["chncls"] != null)
                {
                    ddlSalesChannel.SelectedValue = Request.QueryString["chncls"].ToString();
                }
                if (Request.QueryString["SubClass"].ToString() != null)
                {
                    ddlChnnlClass.SelectedValue = Request.QueryString["SubClass"].ToString();
                }

                if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                {
                    btnUpdate.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "LoadData", ex);

            }

        }


        #region InitializeControl
        private void InitializeControl()
        {
            lblSalesChannel.Text = (olng.GetItemDesc("lblSalesChannel.Text"));
            lblChnCls.Text = (olng.GetItemDesc("lblChnCls.Text"));
            lblAgentType.Text = (olng.GetItemDesc("lblAgentType.Text"));
            lblAgtCreateRule.Text = (olng.GetItemDesc("lblAgtCreateRule.Text"));
            lblUnitRank.Text = (olng.GetItemDesc("lblUnitRank.Text"));
            lblAgentLevel.Text = (olng.GetItemDesc("lblAgentLevel.Text"));
            lblAgtTypeDesc01.Text = (olng.GetItemDesc("lblAgtTypeDesc01.Text"));
            lblAgtTypeDesc02.Text = (olng.GetItemDesc("lblAgtTypeDesc02.Text"));
            lblAgtTypeDesc03.Text = (olng.GetItemDesc("lblAgtTypeDesc03.Text"));
            lblAlwSls.Text = (olng.GetItemDesc("lblAlwSls.Text"));
            lblAlwServicing.Text = "Allow Servicing?";
            lblLicReq.Text = "Is License Required?";
            lblAlwRecAgent.Text = "Allow Agent Recruitment?";
            lblIsCmpStaff.Text = (olng.GetItemDesc("lblIsCmpStaff.Text"));
            Label1.Text = "Employee Code Required?";
            lblAgtTypSetup.Text = (olng.GetItemDesc("lblAgtTypSetup.Text"));
            lblAgtDtls.Text = (olng.GetItemDesc("lblAgtDtls.Text"));
            lblAlwPRept.Text = (olng.GetItemDesc("lblAlwPRept.Text"));
            lblPrReptDtls.Text = (olng.GetItemDesc("lblPrReptDtls.Text"));
            lblddlreportingtype.Text = (olng.GetItemDesc("lblddlreportingtype.Text"));
            lblchannel.Text = (olng.GetItemDesc("lblchannel.Text"));
            lblsubchannel.Text = (olng.GetItemDesc("lblsubchannel.Text"));
            lblbasedon.Text = (olng.GetItemDesc("lblbasedon.Text"));
            lbllevelagttype.Text = (olng.GetItemDesc("lbllevelagttype.Text"));
            lbladditionalreporting.Text = (olng.GetItemDesc("lbladditionalreporting.Text"));
            lblAddlRDtls.Text = (olng.GetItemDesc("lblAddlRDtls.Text"));
            //lblAlwSer.Text = (olng.GetItemDesc("lblAddlMBsdOn.Text"));
            lblUMDtls.Text = (olng.GetItemDesc("lblUMDtls.Text"));
            lblIsUM.Text = (olng.GetItemDesc("lblIsUM.Text"));
            lblUChnl.Text = (olng.GetItemDesc("lblUChnl.Text"));
            lblUSubClass.Text = (olng.GetItemDesc("lblUSubClass.Text"));
            lblUMBasedOn.Text = (olng.GetItemDesc("lblUMBasedOn.Text"));
            lblUUnitType.Text = (olng.GetItemDesc("lblUUnitType.Text"));
            lblPosReq.Text = (olng.GetItemDesc("lblPosReq.Text"));
            lblRptRule.Text = (olng.GetItemDesc("lblRptRule.Text"));
            lblCmpyDtls.Text = (olng.GetItemDesc("lblCmpyDtls.Text"));
            lblMvmt.Text = (olng.GetItemDesc("lblMvmt.Text"));
            lblUnitLoc.Text = (olng.GetItemDesc("lblUnitLoc.text"));
            lblPer.Text = (olng.GetItemDesc("lblPeriod"));
            lblVer.Text = (olng.GetItemDesc("lblVersion"));
            lblEffDate.Text = (olng.GetItemDesc("lblEff"));
            lblCseDt.Text = (olng.GetItemDesc("lblCease"));
            lblRptSetup.Text = (olng.GetItemDesc("lblRptSetup.Text"));
            lblRptLvl.Text = (olng.GetItemDesc("lblRptLvl.Text"));
            lblhdrOth.Text = (olng.GetItemDesc("lblhdrOth"));
            lblIsMdty.Text = (olng.GetItemDesc("lblIsMdty"));//added by AshishP on 28-03-2018


            Label21.Text = "CORRECTION OR CHANGES IN MEMBER TYPE SETUP";
            lblAgtTypSetup.Text = "MEMBER TYPE SETUP";
            lblAgtDtls.Text = "MEMBER TYPE SETUP";
            lblCmpyDtls.Text = "COMPANY DETAILS";
            LblTax.Text = "TAX & ACCOUNTING DETAILS";

            lblPrReptDtls.Text = "PRIMARY RELATIONSHIP DETAILS";
            lblAddlRDtls.Text = "ADDITIONAL RELATIONSHIP DETAILS";
            lblMvmt.Text = "MOVEMENTS RULE DETAILS";
            lblUMDtls.Text = "UNIT MANAGER DETAILS";
            lblPosReq.Text = "POSITION REQUIRED";
            lblprodname.Text = "PRODUCT DETAILS";
            lblhdrOth.Text = "OTHER DETAILS";

        }
        #endregion

        #region rdoCmpStaffNo_CheckedChanged
        protected void rdoCmpStaffNo_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion



        protected void btnUpdate_Click(object sender, EventArgs e)        {

            InsertAndUpdateValues(htable);            InsertData("PRC_UPT_CHNMEMSU", htable, "INSCCommonConnectionString");            AddAditional();            AddTax();            htable.Clear();            RBHIDE();            AddlUntMngr();            btnUpdate.Visible = false;            lblmsg.Text = "Channel member type updated successfully";            lbl.Text = "Channel member type updated successfully<br /><br />" + "Member Type:" + txtAgtTypeDesc01.Text.Trim() + "</br></br> Sales Channel:" + lblSalesChannelVal.Text + "</br></br> Sub Class :" + ddlChnnlClass.SelectedItem.Text;            mdlpopup.Show();        }        #region AddlManager
        public void AddAditional()
        {

            Hashtable htAddl = new Hashtable();
            string rpttyp, rptrul, adlchn, adlsubchn, adlbdson, adlagtyp, adlrptst, adlrptlvl, relorder, chkmand;

            for (int i = 0; dgAddlRpt.Rows.Count > i; i++)
            {
                CheckBox chkMand = dgAddlRpt.Rows[i].FindControl("chkAdlMand") as CheckBox;
                DropDownList ddlAdlRptTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                DropDownList ddlAdlRptRul = dgAddlRpt.Rows[i].FindControl("ddlAdlRptRul") as DropDownList;

                DropDownList ddlAdlChn = dgAddlRpt.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                DropDownList ddlAdlSChn = dgAddlRpt.Rows[i].FindControl("ddlAdlSChn") as DropDownList;

                DropDownList ddlAdlBsdOn = dgAddlRpt.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                DropDownList ddlAdlAgtTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;

                DropDownList ddladlRptStp = dgAddlRpt.Rows[i].FindControl("ddlRptStp") as DropDownList;
                DropDownList ddladlRptLvl = dgAddlRpt.Rows[i].FindControl("ddlRptLvl") as DropDownList;//not exist in frontend

                if (ddlAdlRptTyp.SelectedValue != "")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        Flag = Request.QueryString["flag"].ToString();
                    }
                    string level = txtAgentLvl.Text;
                    string rank = ddlUnitRank.SelectedValue;
                    rpttyp = ddlAdlRptTyp.SelectedValue.ToString().Trim();
                    rptrul = ddlAdlRptRul.SelectedValue.ToString().Trim();
                    adlchn = ddlAdlChn.SelectedValue.ToString().Trim();
                    adlsubchn = ddlAdlSChn.SelectedValue.ToString().Trim();
                    adlbdson = ddlAdlBsdOn.SelectedValue.ToString().Trim();
                    adlagtyp = ddlAdlAgtTyp.SelectedValue.ToString().Trim();
                    adlrptst = ddladlRptStp.SelectedValue.ToString().Trim();
                    adlrptlvl = ddladlRptLvl.SelectedValue.ToString().Trim();
                    relorder = (i + 1).ToString();
                    if (!chkMand.Checked)
                    {
                        chkmand = "0";
                    }
                    else
                    {
                        chkmand = "1";
                    }


                    htAddl.Clear();

                    htAddl.Add("@CarrierCode", "2");
                    htAddl.Add("@BizSrc", channel);
                    htAddl.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());
                    htAddl.Add("@MemType", AgtType.ToString().Trim());
                    htAddl.Add("@MemLevel", level.ToString().Trim());
                    htAddl.Add("@MemRole", memtype.ToString().Trim());
                    htAddl.Add("@UnitRank", rank.ToString().Trim());
                    htAddl.Add("@RelOrder", relorder.ToString().Trim());
                    htAddl.Add("@AdlRptRul", ddlAdlRptRul.SelectedValue.ToString().Trim());
                    htAddl.Add("@AdlRptTyp", ddlAdlRptTyp.SelectedValue.ToString().Trim());
                    htAddl.Add("@AdlChnl", ddlAdlChn.SelectedValue.ToString().Trim());
                    htAddl.Add("@AdlSChnl", ddlAdlSChn.SelectedValue.ToString().Trim());
                    htAddl.Add("@AdlBsdOn", ddlAdlBsdOn.SelectedValue.ToString().Trim());
                    htAddl.Add("@AdlMemType", ddlAdlAgtTyp.SelectedValue.ToString().Trim());
                    htAddl.Add("@IsMand", chkmand.ToString().Trim());
                    htAddl.Add("@RptStp", ddladlRptStp.SelectedValue.ToString().Trim());
                    htAddl.Add("@RptLvl", ddladlRptLvl.SelectedValue.ToString().Trim());//reporting level
                    htAddl.Add("@CreateBy", Convert.ToString(Session["UserName"]).Trim());
                    htAddl.Add("@Flag", Flag);
                    htAddl.Add("@Period", ddlFinancialYr.SelectedValue.ToString().Trim());
                    htAddl.Add("@Version", txtVer.Text.Trim());
                    if (txtEffDate.Text == "")
                    {
                        htAddl.Add("@EffDate", System.DBNull.Value);
                    }
                    else
                    {
                        htAddl.Add("@EffDate", Convert.ToDateTime(txtEffDate.Text.ToString().Trim()));
                    }

                    if (txtCseDt.Text == "")
                    {
                        htAddl.Add("@CseDate", System.DBNull.Value);
                    }
                    else
                    {
                        htAddl.Add("@CseDate", Convert.ToDateTime(txtCseDt.Text.ToString().Trim()));
                    }
                    objDAL.execute_sprc("dbo.Prc_InsAddlMgrDtls", htAddl);
                }

            }
        }



        #endregion
        public void MemData()
        {
            if (ddlbasedon.SelectedValue == "1")
            {
                Hashtable ht = new Hashtable();
                DataSet ds = new DataSet();
                ht.Add("@BizSrc", channel);
                ht.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());
                ht.Add("@MemType", AgtType);
                ht.Add("@UnitRank", ddlUnitRank.SelectedValue);
                ht.Add("@PrimaryChannel", ddlchannel.SelectedValue.ToString().Trim());
                ht.Add("@PrimarySubChannel", ddlsubchannel.SelectedValue.ToString().Trim());
                ht.Add("@PrimaryMemOrLevelType", ddllevelagttype.SelectedValue.ToString().Trim());
                ht.Add("@PrimaryReportingType", ddlreportingtype.SelectedValue.ToString().Trim());
                ht.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                InsertData("Prc_Get_InsChnMapRptType", ht, "INSCCommonConnectionString");
            }
        }

        public void btnSave_Click(object sender, EventArgs e)        {            if (Request.QueryString["flag"] != null)            {                Flag = Request.QueryString["flag"].ToString();            }            else            {                Flag = "Y";            }            if (hdnChntype.Value != null)            {                ChnTyp = "M";            }            if (txtVer.Text.Trim() == "")            {                txtVer.Text = "1.00";            }            if (ddlSalesChannel.Visible == true)            {                channel = ddlSalesChannel.SelectedValue;            }            else            {                channel = Request.QueryString["SalesChnl"].ToString();            }            if (txtAgtTypeVal.Visible == true)            {
                if (this.txtAgtTypeVal.Text.Trim().Length < 2)// Added by sanoj for Validation sahani 10-12-2021
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Atleast Two Character Of Member type');</script>", false);
                    this.txtAgtTypeVal.Text = "";
                    this.txtAgtTypeVal.Focus();
                    return;
                }                AgtType = txtAgtTypeVal.Text.ToUpper();            }            else            {                AgtType = Request.QueryString["AgtType"].ToString();            }            if (Convert.ToInt16(txtAgentLvl.Text) > Convert.ToInt32(System.Data.SqlTypes.SqlByte.MaxValue.Value) + 1)            {                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Member Level should not be greater than " + System.Data.SqlTypes.SqlByte.MaxValue.Value + "')", true);                return;            }



            InsertAndUpdateValues(htable);            if (Flag == "N" && ChnTyp == "M")            {

                InsertData("PRC_INS_CHNMEMSU", htable, "INSCCommonConnectionString");
                MemData();
                AddAditional();
                AddTax();
                AddlUntMngr();                htable.Clear();                btnSave.Enabled = false;                lblmsg.Text = "Channel member type created successfully";                lbl.Text = "Channel member type created successfully<br /><br />" + "Member Type:" + txtAgtTypeDesc01.Text.Trim() + "</br></br> Sales Channel:" + ddlSalesChannel.SelectedItem.Text + "</br></br> Sub Class :" + ddlChnnlClass.SelectedItem.Text;                lbl.Text = lbl.Text + "<br /><br />Movement Rules are set to default i.e NO for this Member Type.";                mdlpopup.Show();            }        }        public void AddTax()
        {
            InsAndUpdatTaxValue(htable);
            InsertData("PRC_INS_MstMemAccDtls", htable, "INSCCommonConnectionString");
        }        public void InsAndUpdatTaxValue(Hashtable htable)
        {
            if (Request.QueryString["flag"] != null)            {                Flag = Request.QueryString["flag"].ToString();            }            else            {                Flag = "Y";            }
            htable.Clear();
            htable.Add("@BizSrc", channel);
            htable.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());
            htable.Add("@MemType", AgtType);
            htable.Add("@Flag", Flag);
            htable.Add("@TdsFlag", rdlTDS.SelectedValue);
            htable.Add("@CommGlCode", TxtCommision.Text.ToString());
            htable.Add("@TdsExeAllwd", RadioLblExecption.SelectedValue);
            htable.Add("@OthPayGlCode", TextBox1.Text.ToString());
            htable.Add("@TdsStdExemLmt", TextLimit.Text.ToString());
            htable.Add("@GstRegReq", RadioGstRegion.SelectedValue);
            htable.Add("@GstPayUndrRcm", RadioGstpayout.SelectedValue);
            htable.Add("@CreateBy", Convert.ToString(Session["UserName"]));
            htable.Add("@UpdateBy", Convert.ToString(Session["UserName"]));

        }        public void InsertAndUpdateValues(Hashtable htable)        {            if (chkIsUM.Checked == true)            {                chkUM = "1";            }            else            {                chkUM = "0";            }            int chkPos;            if (chkPosReq.Checked == true)            {                chkPos = 1;            }            else            {                chkPos = 0;            }            if (chkPriMand.Checked == true)            {                chkPMd = 1;            }            else            {                chkPMd = 0;            }            if (ddlSalesChannel.Visible == true)
            {
                channel = ddlSalesChannel.SelectedValue;
            }
            else
            {
                channel = Request.QueryString["SalesChnl"].ToString();
            }
            if (txtAgtTypeVal.Visible == true)
            {
                AgtType = txtAgtTypeVal.Text.ToUpper();
            }
            else
            {
                AgtType = Request.QueryString["AgtType"].ToString();
            }
            #region Member Role Details
            Hashtable htMem = new Hashtable();
            DataSet dsMem = new DataSet();
            string memcode = ddlCmpStaff.SelectedValue.ToString().Trim();
            htMem.Clear();
            htMem.Add("@memcode", memcode);
            dsMem = objDAL.GetDataSetForPrcCLP("Prc_GetMemRoleType", htMem);
            if (dsMem.Tables.Count > 0)
            {
                if (dsMem.Tables[0].Rows.Count > 0)
                {
                    memtype = dsMem.Tables[0].Rows[0]["RoleType"].ToString();
                }
            }
            dsMem.Clear();
            htMem.Clear();










            #endregion            htable.Add("@CarrierCode", "2");            htable.Add("@BizSrc", channel);            htable.Add("@MemType", AgtType);            htable.Add("@UnitRank",  ddlUnitRank.SelectedValue);            htable.Add("@MemLevel", txtAgentLvl.Text);            htable.Add("@MemTypeDesc01", txtAgtTypeDesc01.Text);            htable.Add("@MemTypeDesc02", txtAgtTypeDesc02.Text);            htable.Add("@MemTypeDesc03", txtAgtTypeDesc03.Text);            htable.Add("@AlwRecruitMem", Convert.ToString(rdlAlwRecAgt.SelectedIndex));            htable.Add("@MemRoleCode", ddlCmpStaff.SelectedValue);            htable.Add("@CreateBy", Convert.ToString(Session["UserName"]));            htable.Add("@Flag", "N");            htable.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());            htable.Add("@ModeModify", rbCorrection.SelectedValue.Trim());            if (rdlAllowSls.SelectedValue.ToString().Trim() == "Y")            {                htable.Add("@AlwSls", 1);            }            else            {                htable.Add("@AlwSls", 0);            }            htable.Add("@MemCreateRul", ddlAgtCreateRul.SelectedValue.ToString().Trim());  //@PrimaryMemOrLevelType
            htable.Add("@IsCmpStaff", rdlEmpCode.SelectedValue.ToString().Trim());            htable.Add("@ORLdrCreateRul", "");            htable.Add("@UntRule", "");            htable.Add("@AppRule", "");            htable.Add("@PrimaryReportingType", ddlreportingtype.SelectedValue.ToString().Trim());            htable.Add("@PrimaryChannel", ddlchannel.SelectedValue.ToString().Trim());            htable.Add("@PrimarySubChannel", ddlsubchannel.SelectedValue.ToString().Trim());            htable.Add("@PrimaryBasedOnType", ddlbasedon.SelectedValue.ToString().Trim());            htable.Add("@PrimaryMemOrLevelType", ddllevelagttype.SelectedValue.ToString().Trim());            htable.Add("@AddlReportingRule", ddladditionalreportingrule.SelectedValue.ToString().Trim());            htable.Add("@IsUnitManager", Convert.ToString(chkUM));            htable.Add("@Unitchannel", ddlUChnnl.SelectedValue.ToString().Trim());            htable.Add("@UnitSubClass", ddlUSubCls.SelectedValue.ToString().Trim());            htable.Add("@UnitMgrBasedOn", ddlUMBasedOn.SelectedValue.ToString().Trim());            htable.Add("@UnitType", ddlUUnitType.SelectedValue.ToString().Trim());            htable.Add("@PositionReq", Convert.ToString(chkPos));
            htable.Add("@RptRule", ddlReportingRule.SelectedValue.ToString().Trim());            htable.Add("@AllwPrRpt", Convert.ToString(rdlAllowPrRept.SelectedIndex));            htable.Add("@IsMvmtTrf", Convert.ToString(rbltrf.SelectedIndex));            htable.Add("@IsMvmtTrm", Convert.ToString(rblter.SelectedIndex));            htable.Add("@IsMvmtReInst", Convert.ToString(rblrein.SelectedIndex));            htable.Add("@IsMvmtPromo", Convert.ToString(rblpromo.SelectedIndex));            htable.Add("@IsMvmtDemo", Convert.ToString(rbldemo.SelectedIndex));            htable.Add("@IsMvmtCreate", Convert.ToString(rblcreate.SelectedIndex));            htable.Add("@IsMvmtModify", Convert.ToString(rblmodify.SelectedIndex));            htable.Add("@IsPriMand", Convert.ToString(chkPMd));            htable.Add("@MemRole", memtype.ToString().Trim());            htable.Add("@UntLoc", ddlUnitLoc.SelectedValue.ToString().Trim());            htable.Add("@PrmyRptType", ddlRptSetup.SelectedValue.ToString().Trim());            htable.Add("@PrmyRptLevel", ddlRptLevel.SelectedValue.ToString().Trim());            htable.Add("@Period", ddlFinancialYr.SelectedValue.ToString());// txtFinYr.Text.Trim()
            if(txtVer.Text.Trim() == "")
            {
                htable.Add("@Version","1");
            }
            else
            {
                htable.Add("@Version", txtVer.Text.Trim());
            }
            htable.Add("@EffDate", Convert.ToDateTime(txtEffDate.Text.Trim()));            if (txtCseDt.Text == "")            {                htable.Add("@CeaseDate", System.DBNull.Value);            }            else            {                htable.Add("@CeaseDate", txtCseDt.Text);            }            htable.Add("@Status", ddlDraftStatus.SelectedItem.Text.ToString());            htable.Add("@IsLicenseReq", Convert.ToString(rdlLicReq.SelectedIndex));        }

        #region after update rb hide
        public void RBHIDE()
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
        #endregion

        #region Correction Or Changes Event
        protected void rbCorrection_OnSelectedIndexChanged(object sender, EventArgs e)        {
            ControlEnableddesable();        }
        #endregion
        #region Enable Or Disable Functionality Based On Change Or Correction Event.
        private void ControlEnableddesable()
        {
            if (rbCorrection.SelectedValue == "CR")            {
                ddlUnitRank.Enabled = false;
                ddlCmpStaff.Enabled = false;
                ddladditionalreportingrule.Enabled = false;
                ddlUChnnl.Enabled = false;
                ddlUSubCls.Enabled = false;
                ddlUMBasedOn.Enabled = false;
                ddlUUnitType.Enabled = false;
                ddlUnitLoc.Enabled = true;
                ddlFinancialYr.Enabled = false;
                txtVer.Enabled = false;
                txtEffDate.Enabled = false;
                rbCorrection.Items[0].Attributes.Add("style", "background-color: lightgrey;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: white;");            }            else            {                ddlUnitRank.Enabled = true;
                ddlCmpStaff.Enabled = true;
                ddladditionalreportingrule.Enabled = true;
                ddlUChnnl.Enabled = true;
                ddlUSubCls.Enabled = true;
                ddlUMBasedOn.Enabled = true;
                ddlUUnitType.Enabled = true;
                ddlUnitLoc.Enabled = true;
                ddlFinancialYr.Enabled = false;
                txtVer.Enabled = false;
                txtEffDate.Enabled = true;                txtCseDt.Enabled = false;                rbCorrection.Items[0].Attributes.Add("style", "background-color: white;");
                rbCorrection.Items[1].Attributes.Add("style", "background-color: lightgrey;");            }
        }
        #endregion

        #region btnCancel_Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Cancel"] != null)
            {
                Response.Redirect("AGTSearchLvl.aspx?Code=" + Request.QueryString["Cancel"].ToString() + "&SubClass=" + Request.QueryString["SubClass"].ToString() + "&chnltyp=" + Request.QueryString["chnltyp"].ToString());
            }
            else
            {
                Response.Redirect("AGTSearchLvl.aspx?chncls=" + Request.QueryString["chncls"].ToString() + "&SubClass=" + Request.QueryString["SubClass"].ToString() + "&chnltyp=" + Request.QueryString["chnltyp"].ToString());
            }
        }
        #endregion


        #region ddlSalesChannel_SelectedIndexChanged
        protected void ddlSalesChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlChnnlClass.Items.Clear();
                ddlUnitRank.Items.Clear();
                //SqlDataReader drRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                FillDropDown(ddlUnitRank, "Prc_UnitRnkchnnlsubcls", htParam, "INSCCommonConnectionString", "", "UnitRank", "UnitRank");
                htParam.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@BizSrc", ddlSalesChannel.SelectedValue);
                FillDropDown(ddlChnnlClass, "Prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString", "", "ChnlDesc", "ChnCls");


            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "ddlSalesChannel_SelectedIndexChanged", ex);

            }
        }
        #endregion

        #region PrimaryReporting Details and Manager Details

        #region FillDropDownMethod
        //added by akshay on 27/11/2013 to fill the dropdowns with text and values
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
                LogException("ISYS-CHMS", "AGTLevel.aspx", "FillDropDown", ex);

            }
        }
        #endregion

        #region GetLevelType Method
        //added by akshay for getting channel based on reporting type
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

                FillDropDown(ddl, "Prc_AgnLvl", htable, "INSCCommonConnectionString", "", "UnitRank", "UnitRank");

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetLevelType", ex);

            }
        }
        #endregion

        #region GetChannel Method
        public void GetChannel(DropDownList ddl, string repotype, int flag, string UserID, string BizSrc)
        {
            try
            {
                htable.Clear();
                htable.Add("@flag", flag.ToString().Trim());
                htable.Add("@BizSrc", BizSrc);

                FillDropDown(ddl, "Prc_AgnRepoType", htable, "INSCCommonConnectionString", "", "ChannelDesc01", "BizSrc");

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetChannel", ex);

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
                LogException("ISYS-CHMS", "AGTLevel.aspx", "getsubchannel", ex);

            }
        }
        #endregion

        #region ddlchannel_SelectedIndexChanged
        protected void ddlchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getsubchannel();
        }
        #endregion

        #region getLevelAgentTypeMethod
        //added by akshay for getting level types and agent types
        public void getLevelAgentType()
        {
            try
            {
                ddllevelagttype.Items.Clear();
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                ddlRptSetup.SelectedIndex = 0;
                string userID = Session["UserID"].ToString();
                if (ddlbasedon.SelectedValue == "1")
                {
                    GetAgentTypeForSlsChnnlCT(ddllevelagttype, ddlchannel.SelectedValue, ddlbasedon.SelectedValue, ddlsubchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptSetup.SelectedValue = "E";
                    ddlRptSetup.Enabled = false;
                    // btnRptMgr.Enabled = false;//--by meena-//
                }
                else if (ddlbasedon.SelectedValue == "0")
                {
                    GetLevelType(ddllevelagttype, ddlchannel.SelectedValue, ddlsubchannel.SelectedValue, ddlUnitRank.SelectedValue);
                    //ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptSetup.SelectedIndex = 0;
                    ddlRptSetup.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "getLevelAgentType", ex);

            }
        }
        #endregion

        #region ddlbasedon_SelectedIndexChanged
        protected void ddlbasedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLevelAgentType();
        }
        #endregion

        #region DisableAddlMgr Method
        //added by akshay for setting the drop downs of additional managers indexes to 0
        protected void DisableAddlMgr()
        {
            for (int i = 0; dgAddlRpt.Rows.Count > i; i++)
            {

                DropDownList ddlAdlRptTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                DropDownList ddlAdlRptRul = dgAddlRpt.Rows[i].FindControl("ddlAdlRptRul") as DropDownList;

                DropDownList ddlAdlChn = dgAddlRpt.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                DropDownList ddlAdlSChn = dgAddlRpt.Rows[i].FindControl("ddlAdlSChn") as DropDownList;

                DropDownList ddlAdlBsdOn = dgAddlRpt.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                DropDownList ddlAdlAgtTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;

                DropDownList ddlRptStp = dgAddlRpt.Rows[i].FindControl("ddlRptStp") as DropDownList;
                DropDownList ddlRptLvl = dgAddlRpt.Rows[i].FindControl("ddlRptLvl") as DropDownList;


                ddlAdlRptTyp.Enabled = false;
                ddlAdlRptRul.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlAgtTyp.Enabled = false;
                ddlRptStp.Enabled = false;
                ddlRptLvl.Enabled = false;


                ddlAdlChn.Items.Clear();
                ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlRptTyp.SelectedIndex = 0;
                ddlAdlRptRul.SelectedIndex = 0;
                ddlAdlChn.SelectedIndex = 0;
                ddlAdlSChn.SelectedIndex = 0;
                ddlAdlBsdOn.SelectedIndex = 0;
                ddlAdlAgtTyp.SelectedIndex = 0;
                ddlRptStp.SelectedIndex = 0;
                ddlRptLvl.SelectedIndex = 0;

            }
        }
        #endregion

        #region MultiSelect Method
        //enable/disable dropdowns based on manager reporting rules
        protected void MultiSelect()
        {
            for (int i = 0; dgAddlRpt.Rows.Count > i; i++)
            {

                DropDownList ddlAdlRptTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                DropDownList ddlAdlRptRul = dgAddlRpt.Rows[i].FindControl("ddlAdlRptRul") as DropDownList;

                DropDownList ddlAdlChn = dgAddlRpt.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                DropDownList ddlAdlSChn = dgAddlRpt.Rows[i].FindControl("ddlAdlSChn") as DropDownList;

                DropDownList ddlAdlBsdOn = dgAddlRpt.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                DropDownList ddlAdlAgtTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;

                DropDownList ddlRptStp = dgAddlRpt.Rows[i].FindControl("ddlRptStp") as DropDownList;
                DropDownList ddlRptLvl = dgAddlRpt.Rows[i].FindControl("ddlRptLvl") as DropDownList;

                ddlAdlRptTyp.Enabled = true;
                ddlAdlRptRul.Enabled = true;
                ddlAdlChn.Enabled = true;
                ddlAdlSChn.Enabled = true;
                ddlAdlBsdOn.Enabled = true;
                ddlAdlAgtTyp.Enabled = true;
                ddlRptStp.Enabled = true;
                ddlRptLvl.Enabled = true;


                if (rdlAllowPrRept.SelectedValue == "N")
                {
                    ddlAdlRptTyp.Items.Clear();
                    oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                }
                else
                {
                    ddlAdlRptTyp.Items.Clear();
                    GetRepoType(ddlAdlRptTyp);
                    ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                }



                if (ddlRptStp.Enabled == false)
                    ddlRptStp.Enabled = false;

                if (ddlRptStp.Enabled == false)
                    ddlRptStp.Enabled = false;
            }
        }
        #endregion

        #region ddladditionalreportingrule_SelectedIndexChanged
        protected void ddladditionalreportingrule_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///NoPrRpt();
            FillGrid(ddladditionalreportingrule.SelectedValue.ToString().Trim());
            MultiSelect();
        }
        #endregion

        #region ddlreportingtype_SelectedIndexChanged
        protected void ddlreportingtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string userID = Session["UserID"].ToString();
                ddlchannel.Items.Clear();
                if (ddlreportingtype.SelectedValue == "CF")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString().Trim() == "E")
                        {
                            GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 1, userID, Request.QueryString["SalesChnl"].ToString().Trim());
                        }
                        else
                        {
                            GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 1, userID, ddlSalesChannel.SelectedValue);
                        }
                    }


                    //ddlchannel.Items.Insert(0, new ListItem("Select", ""));

                    foreach (GridViewRow gvrow in dgAddlRpt.Rows)
                    {
                        DropDownList ddlAdlRptTyp = (DropDownList)gvrow.FindControl("ddlAdlRptTyp");
                        ddlAdlRptTyp.Items.Clear();
                        GetRepoType(ddlAdlRptTyp);
                        ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                    }
                    oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    ddlReportingRule.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlreportingtype.SelectedValue == "CU" || ddlreportingtype.SelectedValue == "HW" || ddlreportingtype.SelectedValue == "CP")
                {
                    ddlchannel.Items.Clear();
                    GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 2, userID, "");
                    ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    ddlReportingRule.Items.Insert(0, new ListItem("Select", ""));
                }
                else if (ddlreportingtype.SelectedValue == "")
                {
                    ddlchannel.Items.Clear();
                    ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    foreach (GridViewRow gvrow in dgAddlRpt.Rows)
                    {
                        DropDownList ddlAdlRptTyp = (DropDownList)gvrow.FindControl("ddlAdlRptTyp");
                        ddlAdlRptTyp.Items.Clear();
                        ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                    }
                    ddlReportingRule.SelectedIndex = 0;
                    ddlReportingRule.Items.Clear();
                    ddlReportingRule.Items.Insert(0, new ListItem("Select", ""));

                }
                ddlsubchannel.Items.Clear();
                ddlchannel.SelectedIndex = 0;
                ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
                ddlbasedon.SelectedIndex = 0;
                ddllevelagttype.Items.Clear();
                ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "ddlreportingtype_SelectedIndexChanged", ex);

            }

        }
        #endregion

        protected void ddlsubchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlbasedon.SelectedIndex = 0;
            ddllevelagttype.Items.Clear();
            ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
        }

        #region EnableDDL Method
        protected void EnableDDL()
        {
            ddlreportingtype.Enabled = true;
            ddlchannel.Enabled = true;
            ddlsubchannel.Enabled = true;
            ddlbasedon.Enabled = true;
            ddllevelagttype.Enabled = true;
            ddlReportingRule.Enabled = true;
            ddladditionalreportingrule.Enabled = true;
            chkPriMand.Enabled = true;
            ddlRptSetup.Enabled = true;
            ddlRptLevel.Enabled = true;

            if (Request.QueryString["flag"].ToString() != "E")
            {

            }

        }
        #endregion

        #region DisableDDL Method
        //disable the drop downs and set their indexes to 0
        protected void DisableDDL()
        {

            ddlreportingtype.SelectedIndex = 0;
            ddlreportingtype.Enabled = false;

            ddlchannel.SelectedIndex = 0;
            ddlchannel.Enabled = false;

            ddlsubchannel.SelectedIndex = 0;
            ddlsubchannel.Enabled = false;

            ddlbasedon.SelectedIndex = 0;
            ddlbasedon.Enabled = false;

            ddllevelagttype.SelectedIndex = 0;
            ddllevelagttype.Enabled = false;

            chkPriMand.Enabled = false;
            chkPriMand.Checked = false;

            ddlRptSetup.SelectedIndex = 0;
            ddlRptLevel.SelectedIndex = 0;

            ddlRptSetup.Enabled = false;
            ddlRptLevel.Enabled = false;

            //ddladditionalreportingrule.Enabled = false;
            if (ddladditionalreportingrule.SelectedValue == "")
            {
                ddladditionalreportingrule.SelectedIndex = 0;
            }
            ddlReportingRule.SelectedIndex = 0;
            ddlReportingRule.Enabled = false;

            if (rdlAllowPrRept.SelectedValue != "N")
            {


            }

        }
        #endregion

        #region rdlAllowPrRept_SelectedIndexChanged
        protected void rdlAllowPrRept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            if (rdlAllowPrRept.SelectedValue == "N")
            {
                DisableDDL();
            }
            else
            {
                EnableDDL();
                FillPrimReptDet();
            }
        }
        #endregion

        #region Unit Manager Details

        #region chkIsUM_CheckedChanged
        protected void chkIsUM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUM.Checked == true)
            {
                chkPosReq.Checked = true;
                chkPosReq.Enabled = false;
            }
            else
            {
                chkPosReq.Checked = false;
                chkPosReq.Enabled = false;
            }
        }
        #endregion

        #region ddlUChnnl_SelectedIndexChanged
        protected void ddlUChnnl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUSubCls.Items.Clear();
                ddlUUnitType.SelectedIndex = 0;
                ddlUMBasedOn.SelectedIndex = 0;
                string userid = Session["UserID"].ToString();
                objCommonU.GetUserChnclsChannel(ddlUSubCls, ddlUChnnl.SelectedValue, 0, userid.ToString());
                ddlUSubCls.Items.Insert(0, new ListItem("Select", ""));
                ddlUnitLoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "ddlUChnnl_SelectedIndexChanged", ex);

            }
        }
        #endregion

        #region GetUUnitType
        //getting the unit types based on class and sub class
        protected void GetUUnitType(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string UserID)
        {
            try
            {
                ddlUUnitType.Items.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls.SelectedValue);
                htParam.Add("@flag", 1);
                FillDropDown(ddlChnnlClass, "Prc_GetUnitDesc", htParam, "INSCCommonConnectionString", "", "UnitDesc01", "UnitType");

                string strSql = string.Empty;
                DataSet dsResult = new DataSet();


                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls.SelectedValue);
                htParam.Add("@flag", 1);

                dsResult = objDAL.GetDataSetForPrc("Prc_GetUnitDesc", htParam);


                if (dsResult.Tables.Count > 0)
                {
                    FillDropDown(ddl, dsResult.Tables[0], "AgentType", "AgentTypeDesc01");
                }
                dsResult = null;
                strSql = null;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetUUnitType", ex);

            }
        }
        #endregion

        #region ddlUSubCls_SelectedIndexChanged
        protected void ddlUSubCls_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUMBasedOn.SelectedIndex = 0;
            ddlUnitLoc.SelectedIndex = 0;
            ddlUUnitType.Items.Clear();
            ddlUUnitType.Items.Insert(0, new ListItem("Select", ""));
            ddlUUnitType.SelectedIndex = 0;

        }
        #endregion

        #region ddlUnitRank_SelectedIndexChanged
        protected void ddlUnitRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitRank.SelectedValue != "100.0")
            {
                rdlAllowPrRept.SelectedValue = "Y";
                EnableDDL();
            }
            else
            {
                rdlAllowPrRept.SelectedValue = "N";
                DisableDDL();
            }
        }
        #endregion

        #region GetUnitLevel
        protected void GetUnitLevel()
        {
            try
            {
                ddlUUnitType.Items.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls.SelectedValue);
                htParam.Add("@flag", 3);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtAgentLvl.Text.Trim());
                FillDropDown(ddlUUnitType, "Prc_GetUnitDesc", htParam, "INSCCommonConnectionString", "", "UnitDesc01", "UnitType");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetUnitLevel", ex);

            }
        }
        #endregion

        #region GetUnitRank
        protected void GetUnitRank()
        {
            try
            {
                ddlUUnitType.Items.Clear();
                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls.SelectedValue);
                htParam.Add("@flag", 4);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                FillDropDown(ddlUUnitType, "Prc_GetUnitDesc", htParam, "INSCCommonConnectionString", "", "UnitRank", "UnitRank");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetUnitRank", ex);

            }
        }
        #endregion

        #region ddlUMBasedOn_SelectedIndexChanged
        protected void ddlUMBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlUUnitType.Enabled = true;
                ddlUUnitType.Items.Clear();
                ddlUUnitType.Items.Insert(0, new ListItem("Select", ""));
                ddlUnitLoc.SelectedIndex = 0;
                if (ddlUMBasedOn.SelectedValue == "1")
                {
                    GetUnitLevel();
                }
                else if (ddlUMBasedOn.SelectedValue == "0")
                {
                    GetUnitRank();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "ddlUMBasedOn_SelectedIndexChanged", ex);

            }
        }
        #endregion

        #endregion

        #region BindAgentGrid Method
        protected void BindAgentGrid()
        {

            try
            {
                dsResult.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString());
                htParam.Add("@ChnCls", ddlChnnlClass.SelectedValue);
                htParam.Add("@AgnType", Request.QueryString["AgtType"].ToString());
                dsResult = objDAL.GetDataSetForPrc("Prc_GetActInActAgent", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        trAgentTypes.Visible = true;
                        gv_AgentTypes.DataSource = dsResult.Tables[0];
                        gv_AgentTypes.DataBind();
                    }
                    else
                    {
                        trAgentTypes.Visible = false;
                        gv_AgentTypes.DataSource = null;
                        gv_AgentTypes.DataBind();
                    }
                }
                else
                {
                    trAgentTypes.Visible = false;
                    gv_AgentTypes.DataSource = null;
                    gv_AgentTypes.DataBind();
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

        #region GetRepoType Method
        protected void GetRepoType(DropDownList ddl)
        {
            try
            {
                SqlDataReader drRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@LookupCode", "RptType");
                htParam.Add("@ParamValue", ddlreportingtype.SelectedValue.ToString().Trim());
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
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetRepoType", ex);

            }
        }
        #endregion

        #region NoPrRpt
        protected void NoPrRpt()
        {
            try
            {
                if (rdlAllowPrRept.SelectedValue == "N")
                {
                    foreach (GridViewRow gvrow in dgAddlRpt.Rows)
                    {
                        DropDownList ddlAdlRptTyp = (DropDownList)gvrow.FindControl("ddlAdlRptTyp");
                        ddlAdlRptTyp.Items.Clear();
                        oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                        ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                    }
                }
                else
                {
                    foreach (GridViewRow gvrow in dgAddlRpt.Rows)
                    {
                        DropDownList ddlAdlRptTyp = (DropDownList)gvrow.FindControl("ddlAdlRptTyp");
                        ddlAdlRptTyp.Items.Clear();
                        GetRepoType(ddlAdlRptTyp);
                        ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "NoPrRpt", ex);

            }
        }
        #endregion

        #region FillRepoTypeDDL
        protected void FillRepoTypeDDL()
        {

            try
            {
                //ddlam1reportingtype.Items.Clear();
                //GetRepoType(ddlam1reportingtype);
                //ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));

                //ddlam2reportingtype.Items.Clear();
                //GetRepoType(ddlam2reportingtype);
                //ddlam2reportingtype.Items.Insert(0, new ListItem("Select", ""));

                //ddlam3reportingtype.Items.Clear();
                //GetRepoType(ddlam3reportingtype);
                //ddlam3reportingtype.Items.Insert(0, new ListItem("Select", ""));
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

        #region GetAgentTypeForSlsChnnlCT Method
        public void GetAgentTypeForSlsChnnlCT(DropDownList ddl, string strBizSrc, string strAgntType, string strChnCls, string urank)
        {
            try
            {
                string strSql = string.Empty;
                DataSet dsResult = new DataSet();


                htable.Clear();

                htable.Add("@BizSrc", strBizSrc);
                htable.Add("@selectedchannel", strChnCls);
                htable.Add("@UnitRnk", urank);

                dsResult = objDAL.GetDataSetForPrc("Prc_getAgentLvl", htable);

                if (dsResult.Tables.Count > 0)
                {
                    FillDropDown(ddl, dsResult.Tables[0], "MemType", "MemTypeDesc01");
                }
                dsResult = null;
                strSql = null;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetAgentTypeForSlsChnnlCT", ex);

            }
        }
        #endregion

        #region GetPrimRpt Method
        //method for filling primary reporting details DDLs
        protected void GetPrimRpt()
        {
            try
            {
                string userID = Session["UserID"].ToString();
                if (dtRead["PrimaryReportingType"].ToString() == "CF")
                {
                    GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 1, userID, Request.QueryString["SalesChnl"].ToString());
                    //ddlchannel.SelectedValue = dtRead["PrimaryChannel"].ToString();
                    ddlchannel.SelectedValue = dtRead["PrimaryChannel"].ToString();
                    //ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    getsubchannel();
                    ddlsubchannel.SelectedValue = dtRead["PrimarySubChannel"].ToString();
                    //ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
                    ddlbasedon.SelectedValue = dtRead["PrimaryBasedOnType"].ToString();
                    getLevelAgentType();
                    ddllevelagttype.SelectedValue = dtRead["PrimaryMemOrLevelType"].ToString();
                    hdnMemType.Value = dtRead["PrimaryMemOrLevelType"].ToString(); //--by meena--//
                    // ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddlReportingRule.SelectedValue = dtRead["RptRule"].ToString();
                    ddlRptSetup.SelectedValue = dtRead["PrmyRptType"].ToString().Trim();
                    hdnRptSetup.Value = dtRead["PrmyRptType"].ToString().Trim();//--by meena--//
                    RptSetup(ddlRptSetup, ddlRptLevel, ddlchannel, ddlsubchannel, ddlUnitRank);
                    ddlRptLevel.SelectedValue = dtRead["PrmyRptLevel"].ToString().Trim();
                    Bindgridprimary(ddlchannel, ddlsubchannel, txtAgtTypeDesc01.Text);
                }
                else if (dtRead["PrimaryReportingType"].ToString() == "CU" || dtRead["PrimaryReportingType"].ToString() == "HW" || dtRead["PrimaryReportingType"].ToString() == "CP")
                {
                    GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 2, userID, "");
                    ddlchannel.SelectedValue = dtRead["PrimaryChannel"].ToString().Trim();
                    ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    getsubchannel();
                    ddlsubchannel.SelectedValue = dtRead["PrimarySubChannel"].ToString();
                    //ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
                    ddlbasedon.SelectedValue = dtRead["PrimaryBasedOnType"].ToString();
                    getLevelAgentType();
                    ddllevelagttype.SelectedValue = dtRead["PrimaryMemOrLevelType"].ToString();
                    //ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddlReportingRule.SelectedValue = dtRead["RptRule"].ToString();
                    ddlRptSetup.SelectedValue = dtRead["PrmyRptType"].ToString().Trim();
                    RptSetup(ddlRptSetup, ddlRptLevel, ddlchannel, ddlsubchannel, ddlUnitRank);
                    ddlRptLevel.SelectedValue = dtRead["PrmyRptLevel"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetPrimRpt", ex);

            }
        }
        #endregion

        #region getaddlmgr1 method
        //method for filling addl manager 1 details ddls
        protected void getaddlmgr1()
        {
            string userID = Session["UserID"].ToString();
            Hashtable htRead = new Hashtable();
            DataSet dsAddl = new DataSet();
            try
            {
                for (int i = 0; i < dgAddlRpt.Rows.Count; i++)
                {
                    CheckBox chkMand = dgAddlRpt.Rows[i].FindControl("chkAdlMand") as CheckBox;
                    DropDownList ddlAdlRptTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                    DropDownList ddlAdlRptRul = dgAddlRpt.Rows[i].FindControl("ddlAdlRptRul") as DropDownList;

                    DropDownList ddlAdlChn = dgAddlRpt.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                    DropDownList ddlAdlSChn = dgAddlRpt.Rows[i].FindControl("ddlAdlSChn") as DropDownList;

                    DropDownList ddlAdlBsdOn = dgAddlRpt.Rows[i].FindControl("ddlAdlBsdOn") as DropDownList;
                    DropDownList ddlAdlAgtTyp = dgAddlRpt.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;

                    DropDownList ddladlRptStp = dgAddlRpt.Rows[i].FindControl("ddlRptStp") as DropDownList;
                    DropDownList ddladlRptLvl = dgAddlRpt.Rows[i].FindControl("ddlRptLvl") as DropDownList;

                    #region AddlMgr

                    htRead.Clear();
                    if (Request.QueryString["SalesChnl"] != null)
                    {
                        htRead.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString().Trim());
                    }
                    htRead.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());
                    if (Request.QueryString["AgtType"] != null)
                    {
                        htRead.Add("@MemType", Request.QueryString["AgtType"].ToString().Trim());
                    }
                    htRead.Add("@RelOrder", (i + 1).ToString().Trim());
                    dsAddl = objDAL.GetDataSetForPrcCLP("Prc_GetAddlManagers", htRead);
                    if (dsAddl != null)
                    {
                        if (dsAddl.Tables[0].Rows.Count > 0)
                        {
                            if (dsAddl.Tables[0].Rows[0]["AddlReportingType"] != null)
                            {
                                if (ddlreportingtype.SelectedValue == "CF")
                                {
                                    ddlAdlRptTyp.Items.Clear();
                                    GetRepoType(ddlAdlRptTyp);
                                    ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                                }
                                else
                                {
                                    ddlAdlRptTyp.Items.Clear();
                                    oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                                    ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                                }
                                ddlAdlRptTyp.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlReportingType"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlChannel"] != null)
                            {
                                if (dsAddl.Tables[0].Rows[0]["AddlReportingType"].ToString() == "CF")
                                {
                                    if (Request.QueryString["flag"] != null)
                                    {
                                        if (Request.QueryString["flag"].ToString().Trim() == "E")
                                        {
                                            GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 1, userID, Request.QueryString["SalesChnl"].ToString().Trim());
                                        }
                                        else
                                        {
                                            GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 1, userID, ddlSalesChannel.SelectedValue);
                                        }
                                    }
                                }
                                else
                                {
                                    GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 2, userID, "");
                                }
                                ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));
                                ddlAdlChn.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlChannel"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlSubChannel"] != null)
                            {
                                ddlAdlSChn.Items.Clear();
                                ddlAdlBsdOn.SelectedIndex = 0;
                                ddlAdlAgtTyp.Items.Clear();
                                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                                objCommonU.GetUserChnclsChannel(ddlAdlSChn, ddlAdlChn.SelectedValue, 0, userID.ToString());
                                ddlAdlSChn.Items.Insert(0, new ListItem("Select", ""));

                                ddlAdlSChn.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlSubChannel"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlBasedOnType"] != null)
                            {
                                ddlAdlBsdOn.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlBasedOnType"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlMemOrLevelType"] != null)
                            {
                                ddlAdlAgtTyp.Items.Clear();
                                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));

                                if (ddlAdlBsdOn.SelectedValue == "1")
                                {
                                    GetAgentTypeForSlsChnnlCT(ddlAdlAgtTyp, ddlAdlChn.SelectedValue, ddlAdlBsdOn.SelectedValue, ddlAdlSChn.SelectedValue, ddlUnitRank.SelectedValue);
                                    ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                                    ddladlRptStp.Enabled = dsAddl.Tables[0].Rows[0]["AddlRptStp"].ToString().Trim() == "E" ? false : true;
                                }
                                else if (ddlAdlBsdOn.SelectedValue == "0")
                                {
                                    GetLevelType(ddlAdlAgtTyp, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlUnitRank.SelectedValue);
                                    ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                                    ddladlRptStp.Enabled = true;
                                }

                                ddlAdlAgtTyp.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlMemOrLevelType"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlMRptRule"] != null)
                            {
                                ddlAdlRptRul.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlMRptRule"].ToString().Trim();
                            }
                            if (dsAddl.Tables[0].Rows[0]["AddlRptStp"] != null)
                            {
                                ddladlRptStp.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlRptStp"].ToString().Trim();
                            }
                            RptSetup(ddladlRptStp, ddladlRptLvl, ddlchannel, ddlsubchannel, ddlUnitRank);
                            if (dsAddl.Tables[0].Rows[0]["AddlRptLevel"] != null)
                            {
                                ddladlRptLvl.SelectedValue = dsAddl.Tables[0].Rows[0]["AddlRptLevel"].ToString().Trim();
                            }

                            if (dsAddl.Tables[0].Rows[0]["IsAddlMand"] != null)
                            {
                                if (dsAddl.Tables[0].Rows[0]["IsAddlMand"].ToString().Trim() == "True")
                                {
                                    chkMand.Checked = true;
                                }
                                else
                                {
                                    chkMand.Checked = false;
                                }
                            }
                            #endregion
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "getaddlmgr1", ex);
            }
        }
        #endregion

        #region GetLicType Method
        protected void GetLicType(DropDownList ddl)
        {
            try
            {
                SqlDataReader drRead;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@LookupCode", "LicType");
                htParam.Add("@ParamValue", ddlreportingtype.SelectedValue);
                drRead = objDAL.exec_reader_prc_inscdirect("Prc_GetLicType", htParam);
                if (drRead.HasRows)
                {
                    ddl.DataSource = drRead;
                    ddl.DataTextField = "ParamDesc1";
                    ddl.DataValueField = "ParamValue";
                    ddl.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetLicType", ex);

            }
        }
        #endregion

        #region FillLicTypeDDL method
        //protected void FillLicTypeDDL()
        //{
        //    if (dtRead["LicenseType"].ToString() != "")
        //    {
        //        if (dtRead["LicenseType"].ToString() == "IND")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //        else if (dtRead["LicenseType"].ToString() == "DIND")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //        else if (dtRead["LicenseType"].ToString() == "CORP")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //        else if (dtRead["LicenseType"].ToString() == "DCORP")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //        else if (dtRead["LicenseType"].ToString() == "BRK")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //        else if (dtRead["LicenseType"].ToString() == "DBRK")
        //        {
        //            GetLicType(ddlLicTyp);
        //        }
        //    }
        //}
        #endregion

        #endregion

        #region PopulateMemRole
        private void PopulateMemRole()
        {
            try
            {
                //SqlDataReader drRead;
                Hashtable htParam = new Hashtable();

                FillDropDown(ddlCmpStaff, "Prc_GetMemRole", htParam, "INSCCommonConnectionString", "", "RoleDesc", "RoleCode");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "PopulateMemRole", ex);

            }
        }
        #endregion

        #region ddlChnnlClass_SelectedIndexChanged
        ///added by akshay on 10/02/2014 start
        protected void ddlChnnlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ///added by akshay on 10/02/2014 end
        #endregion

        #region FillPrimReptDet method
        ////Method to show primary rept details and unit mgr details on allow primary reporting
        protected void FillPrimReptDet()
        {
            try
            {
                if (Request.QueryString["flag"].ToString() == "N")
                {
                    string userID = Session["UserID"].ToString();
                    ddlreportingtype.SelectedValue = "CF";
                    GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 1, userID, ddlSalesChannel.SelectedValue);
                    ddlchannel.SelectedValue = ddlSalesChannel.SelectedValue;
                    getsubchannel();
                    ddlsubchannel.SelectedValue = ddlChnnlClass.SelectedValue;
                    //ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    ddlbasedon.SelectedIndex = 1;
                    GetLevelType(ddllevelagttype, ddlchannel.SelectedValue, ddlsubchannel.SelectedValue, ddlUnitRank.SelectedValue);///UnitRank
                    //ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddllevelagttype.SelectedIndex = 1;

                    ddlUChnnl.SelectedIndex = 1;
                    objCommonU.GetUserChnclsChannel(ddlUSubCls, ddlUChnnl.SelectedValue, 0, userID.ToString());
                    ddlUSubCls.Items.Insert(0, new ListItem("Select", ""));
                    ddlUSubCls.SelectedIndex = 1;
                    GetUnitRank();
                    ddlUMBasedOn.SelectedIndex = 1;
                    ddlUUnitType.SelectedIndex = 1;
                }
                if (Request.QueryString["flag"].ToString() == "E")
                {
                    string userID = Session["UserID"].ToString();
                    ddlreportingtype.SelectedValue = "CF";
                    GetChannel(ddlchannel, ddlreportingtype.SelectedValue, 1, userID, Request.QueryString["SalesChnl"].ToString().Trim());
                    ddlchannel.SelectedValue = Request.QueryString["SalesChnl"].ToString().Trim();
                    //getsubchannel();
                    objCommonU.GetUserChnclsChannel(ddlsubchannel, Request.QueryString["SalesChnl"].ToString().Trim(), 0, userID.ToString());
                    ddlsubchannel.SelectedValue = Request.QueryString["SubClass"].ToString().Trim();
                    ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                    ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
                    ddlbasedon.SelectedIndex = 1;
                    GetLevelType(ddllevelagttype, Request.QueryString["SalesChnl"].ToString().Trim(), Request.QueryString["SubClass"].ToString().Trim(), Request.QueryString["UnitRank"].ToString().Trim());
                    ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
                    ddllevelagttype.SelectedIndex = 1;

                    ddlUChnnl.SelectedIndex = 1;
                    objCommonU.GetUserChnclsChannel(ddlUSubCls, ddlUChnnl.SelectedValue, 0, userID.ToString());
                    ddlUSubCls.Items.Insert(0, new ListItem("Select", ""));
                    ddlUSubCls.SelectedIndex = 1;
                    GetUnitRank();
                    ddlUMBasedOn.SelectedIndex = 1;
                    ddlUUnitType.SelectedIndex = 1;
                }

            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "FillPrimReptDet", ex);

            }
        }
        #endregion

        #region MvmtType
        protected void MvmtType(string chnl, string AgtType, string flag, string type1, string type2, string type3)
        {
            Hashtable htable = new Hashtable();
            htable.Clear();
            htable.Add("@BizSrc", chnl.ToString().Trim());
            htable.Add("@ChnnlClass", ddlChnnlClass.SelectedValue.ToString().Trim());
            htable.Add("@MemType", AgtType.ToString().Trim());
            htable.Add("@MvmtType", "T");
            htable.Add("@TrfTyp1", type1.ToString().Trim());
            htable.Add("@TrfTyp2", type2.ToString().Trim());
            htable.Add("@TrfTyp3", type3.ToString().Trim());
            htable.Add("@Flag", flag.ToString().Trim());
            objDAL.execute_sprc("Prc_GetTrfType", htable);
            ////dtRead = objDAL.exec_reader_prc("Prc_GetTrfType", htable);
            htable.Clear();
        }
        #endregion

        #region FillTrfTyp
        protected void FillTrfTyp(string code, CheckBoxList chkbx)
        {
            Hashtable htParam = new Hashtable();
            DataSet dstyp = new DataSet();
            htParam.Add("@LookupCode", code.ToString().Trim());
            //chnaged by nitin
            dstyp = objDAL.GetDataSetForPrc_inscdirect("PrcGetParamVals", htParam);
            if (dstyp.Tables.Count > 0)
            {
                if (dstyp.Tables[0].Rows.Count > 0)
                {
                    chkbx.DataSource = dstyp.Tables[0];
                    chkbx.DataTextField = "ParamDesc";
                    chkbx.DataValueField = "ParamValue";
                    chkbx.DataBind();
                }
            }
        }
        #endregion

        protected void ddlRptSetup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RptSetup(ddlRptSetup, ddlRptLevel, ddlchannel, ddlsubchannel, ddlUnitRank);

            if (ddlRptSetup.SelectedIndex == 1)
            {
                //  btnRptMgr.Enabled = true;
            }
            else
            {
                //btnRptMgr.Enabled = false;
            }


        }

        protected void FillAddlGrid()
        {
            foreach (GridViewRow gvrow in dgAddlRpt.Rows)
            {

                DropDownList ddlAdlBsdOn = (DropDownList)dgAddlRpt.FindControl("ddlAdlBsdOn");
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                DropDownList ddlAdlRptRul = (DropDownList)dgAddlRpt.FindControl("ddlAdlRptRul");
                oCommon.getDropDown(ddlAdlRptRul, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            }
        }

        protected void FillGrid(string rule)
        {
            dsResult.Clear();
            htable.Clear();
            htable.Add("@Rule", rule.ToString());
            dsResult = objDAL.GetDataSetForPrc_inscdirect("Prc_GetParamCount", htable);
            if (dsResult != null)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ViewState["dsAddl"] = dsResult;
                    dgAddlRpt.DataSource = dsResult;
                    dgAddlRpt.DataBind();
                    dgAddlRpt.Visible = true;
                }
                else
                {
                    dsResult = null;
                    dgAddlRpt.DataSource = null;
                    dgAddlRpt.Visible = false;
                }
            }
            else
            {
                dsResult = null;
                dgAddlRpt.DataSource = null;
                dgAddlRpt.Visible = false;
            }
            //dsResult.Clear();
            //htable.Clear();
        }

        protected void dgAddlRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdlRptTyp = (Label)e.Row.FindControl("lblAdlRptTyp");
                lblAdlRptTyp.Text = olng.GetItemDesc("lblddlreportingtype.Text");
                Label lblAdlRptRule = (Label)e.Row.FindControl("lblAdlRptRule");
                lblAdlRptRule.Text = olng.GetItemDesc("lblRptRule.Text");
                Label lblAdlChn = (Label)e.Row.FindControl("lblAdlChn");
                lblAdlChn.Text = olng.GetItemDesc("lblchannel.Text");
                Label lblAdlSChn = (Label)e.Row.FindControl("lblAdlSChn");
                lblAdlSChn.Text = olng.GetItemDesc("lblsubchannel.Text");
                Label lblAdlBsdOn = (Label)e.Row.FindControl("lblAdlBsdOn");
                lblAdlBsdOn.Text = olng.GetItemDesc("lblbasedon.Text");
                Label lblAddlAgt = (Label)e.Row.FindControl("lblAddlAgt");
                lblAddlAgt.Text = olng.GetItemDesc("lbllevelagttype.Text");
                Label lblAdlRptStp = (Label)e.Row.FindControl("lblAdlRptStp");
                lblAdlRptStp.Text = olng.GetItemDesc("lblRptSetup.Text");
                Label lblAdlRptLvl = (Label)e.Row.FindControl("lblAdlRptLvl");
                lblAdlRptLvl.Text = olng.GetItemDesc("lblRptLvl.Text");

                DropDownList ddlRptTyp = (DropDownList)e.Row.FindControl("ddlAdlRptTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)e.Row.FindControl("ddlAdlBsdOn");
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlBsdOn.Items.Insert(0, new ListItem("Select", ""));
                DropDownList ddlRptStp = (DropDownList)e.Row.FindControl("ddlRptStp");
                oCommon.getDropDown(ddlRptStp, "RptSetup", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlRptStp.Items.Insert(0, new ListItem("Select", ""));

                DropDownList ddlAdlRptRul = (DropDownList)e.Row.FindControl("ddlAdlRptRul");
                oCommon.getDropDown(ddlAdlRptRul, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptRul.Items.Insert(0, new ListItem("Select", ""));

                DropDownList ddlRptLvl = (DropDownList)e.Row.FindControl("ddlRptLvl");
                DropDownList ddlAdlChn = (DropDownList)e.Row.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)e.Row.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)e.Row.FindControl("ddlAdlAgtTyp");
                ddlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlSChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));


            }
        }

        protected void ddlAdlRptTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
            DropDownList ddlRptLvl = (DropDownList)grd.FindControl("ddlRptLvl");
            DropDownList ddlRptStp = (DropDownList)grd.FindControl("ddlRptStp");
            DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
            DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
            DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
            DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
            DropDownList ddlAdlRptRul = (DropDownList)grd.FindControl("ddlAdlRptRul");

            if (ddlAdlRptTyp.SelectedValue == "CF")
            {
                ddlAdlChn.Items.Clear();
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "E")
                    {
                        GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 1, userID, Request.QueryString["SalesChnl"].ToString().Trim());
                    }
                    else
                    {
                        GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 1, userID, ddlSalesChannel.SelectedValue);
                    }
                }

            }
            else if (ddlAdlRptTyp.SelectedValue == "CU" || ddlAdlRptTyp.SelectedValue == "HW" || ddlAdlRptTyp.SelectedValue == "CP")
            {
                ddlAdlChn.Items.Clear();
                GetChannel(ddlAdlChn, ddlAdlRptTyp.SelectedValue, 2, userID, ddlSalesChannel.SelectedValue);
                ///ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));
                oCommon.getDropDown(ddlAdlRptRul, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptRul.Items.Insert(0, new ListItem("Select", ""));
            }
            else if (ddlAdlRptTyp.SelectedValue == "")
            {
                ddlAdlChn.Items.Clear();
                ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));

                ddlAdlRptRul.Items.Clear();
                ddlAdlRptRul.Items.Insert(0, new ListItem("Select", ""));
            }
            ddlAdlSChn.Items.Clear();
            ddlAdlSChn.Items.Insert(0, new ListItem("Select", ""));
            ddlAdlBsdOn.SelectedIndex = 0;
            ddlAdlAgtTyp.Items.Clear();
            ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
            ddlRptStp.SelectedIndex = 0;
            ddlRptLvl.Items.Clear();
            ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
            ddlRptLvl.Enabled = true;
        }

        protected void ddlAdlChn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
                DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
                DropDownList ddlRptLvl = (DropDownList)grd.FindControl("ddlRptLvl");
                DropDownList ddlRptStp = (DropDownList)grd.FindControl("ddlRptStp");
                DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
                DropDownList ddlAdlRptRul = (DropDownList)grd.FindControl("ddlAdlRptRul");

                ddlAdlSChn.Items.Clear();
                ddlAdlBsdOn.SelectedIndex = 0;
                ddlAdlAgtTyp.Items.Clear();
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                string userid = Session["UserID"].ToString();
                objCommonU.GetUserChnclsChannel(ddlAdlSChn, ddlAdlChn.SelectedValue, 0, userid.ToString());
                ddlAdlSChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlAgtTyp.SelectedIndex = 0;
                ddlAdlAgtTyp_SelectedIndexChanged(sender, e);
                ddlRptStp.SelectedIndex = 0;
                ddlRptLvl.Items.Clear();
                ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
                ddlRptLvl.Enabled = true;
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "Page_Load", ex);

            }
        }

        protected void ddlAdlSChn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
                DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
                DropDownList ddlRptLvl = (DropDownList)grd.FindControl("ddlRptLvl");
                DropDownList ddlRptStp = (DropDownList)grd.FindControl("ddlRptStp");
                DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
                DropDownList ddlAdlRptRul = (DropDownList)grd.FindControl("ddlAdlRptRul");

                if (ddlAdlSChn.SelectedIndex == 0)
                    if (ddlAdlSChn.SelectedValue == ddlinit)
                    {
                        ddlAdlBsdOn.SelectedIndex = 0;
                        ddlAdlAgtTyp.Items.Clear();
                        ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                        ddlRptStp.SelectedIndex = 0;
                        ddlRptLvl.Items.Clear();
                        ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
                        ddlRptLvl.Enabled = true;
                    }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "Page_Load", ex);

            }
        }

        protected void ddlAdlBsdOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
                DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
                DropDownList ddlRptLvl = (DropDownList)grd.FindControl("ddlRptLvl");
                DropDownList ddlRptStp = (DropDownList)grd.FindControl("ddlRptStp");
                DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
                DropDownList ddlAdlRptRul = (DropDownList)grd.FindControl("ddlAdlRptRul");

                ddlAdlAgtTyp.Items.Clear();
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                ddlRptStp.SelectedIndex = 0;
                string userID = Session["UserID"].ToString();
                if (ddlAdlBsdOn.SelectedValue == "1")
                {
                    GetAgentTypeForSlsChnnlCT(ddlAdlAgtTyp, ddlAdlChn.SelectedValue, ddlAdlBsdOn.SelectedValue, ddlAdlSChn.SelectedValue, ddlUnitRank.SelectedValue);
                    ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptStp.SelectedValue = "E";
                    ddlRptStp.Enabled = false;
                    ddlRptLvl.Items.Clear();
                    ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptLvl.Enabled = true;
                }
                else if (ddlAdlBsdOn.SelectedValue == "0")
                {
                    GetLevelType(ddlAdlAgtTyp, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlUnitRank.SelectedValue);
                    //ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptStp.SelectedIndex = 0;
                    ddlRptStp.Enabled = true;
                    ddlRptLvl.Items.Clear();
                    ddlRptLvl.Items.Insert(0, new ListItem("Select", ""));
                    ddlRptLvl.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "Page_Load", ex);

            }
        }

        protected void ddlAdlAgtTyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRptStp_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
            DropDownList ddlRptLvl = (DropDownList)grd.FindControl("ddlRptLvl");
            DropDownList ddlRptStp = (DropDownList)grd.FindControl("ddlRptStp");
            DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
            DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
            DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
            DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
            DropDownList ddlAdlRptRul = (DropDownList)grd.FindControl("ddlAdlRptRul");
            RptSetup(ddlRptStp, ddlRptLvl, ddlAdlChn, ddlAdlSChn, ddlUnitRank);
        }

        protected void FindGridCntrls()
        {
            foreach (GridViewRow gvrow in dgAddlRpt.Rows)
            {
                DropDownList ddlAdlBsdOn = (DropDownList)dgAddlRpt.FindControl("ddlAdlBsdOn");
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                DropDownList ddlAdlRptRul = (DropDownList)dgAddlRpt.FindControl("ddlAdlRptRul");
                oCommon.getDropDown(ddlAdlRptRul, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                DropDownList lblAdlRptTyp = (DropDownList)dgAddlRpt.FindControl("lblAdlRptTyp");
                DropDownList ddlRptLvl = (DropDownList)gvrow.FindControl("ddlRptLvl");
                DropDownList ddlRptStp = (DropDownList)gvrow.FindControl("ddlRptStp");
                DropDownList ddlAdlChn = (DropDownList)gvrow.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)gvrow.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)gvrow.FindControl("ddlAdlAgtTyp");
            }
        }

        protected void RptSetup(DropDownList ddlRpt, DropDownList ddlLvl, DropDownList ddlchn, DropDownList ddlschn, DropDownList ddluntrnk)
        {
            if (ddlRpt.SelectedValue == "I")
            {
                int cnt = 0;
                htable.Clear();
                dsResult.Clear();
                ddlLvl.Items.Clear();
                ddlLvl.Items.Insert(0, new ListItem("Select", ""));
                htable.Add("@BizSrc", ddlchn.SelectedValue.ToString().Trim());
                htable.Add("@ChnCls", ddlschn.SelectedValue.ToString().Trim());
                htable.Add("@unitRank", ddluntrnk.SelectedValue.ToString().Trim());
                dsResult = objDAL.GetDataSetForPrc("Prc_GetHierarchyCount", htable);
                if (dsResult != null)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        cnt = Convert.ToInt32(dsResult.Tables[0].Rows[0]["HierLvlCnt"].ToString().Trim());
                        for (int i = 1; i <= cnt; i++)
                        {
                            ddlLvl.Items.Insert(i, new ListItem(i.ToString().Trim(), i.ToString().Trim()));
                        }
                    }
                }
                ddlLvl.Items.Insert(cnt + 1, new ListItem("All", "All"));
                ddlLvl.Enabled = true;
            }
            else if (ddlRpt.SelectedValue == "E")
            {
                ddlLvl.Items.Clear();
                ddlLvl.Items.Insert(0, new ListItem("Select", ""));
                ddlLvl.Enabled = false;
            }
            else if (ddlRpt.SelectedValue == "")
            {
                ddlLvl.Items.Clear();
                ddlLvl.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        protected void ShowMvmtValues(RadioButtonList rbl, LinkButton lnkadd, LinkButton lnkview)
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "E")
                {
                    if (rbl.SelectedValue == "Y")
                    {
                        lnkadd.Visible = true;
                        lnkview.Visible = false;
                    }
                    else
                    {
                        lnkadd.Text = "Add Rule";
                        lnkadd.Visible = false;
                        lnkview.Visible = false;
                    }
                }
            }
        }

        #region rbltrf_SelectedIndexChanged
        protected void rbltrf_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rbltrf, lnkTrfAdd, lnkTrfView);
            if (rbltrf.SelectedValue == "N")
            {
                DeleteMvmtDtls("TRF");
            }
        }
        #endregion

        protected void rblter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rblter, lnkTrmAdd, lnkTrmView);
            if (rblter.SelectedValue == "N")
            {
                DeleteMvmtDtls("TR");
            }
        }
        protected void rblrein_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rblrein, lnkReinAdd, lnkReinView);
            if (rblrein.SelectedValue == "N")
            {
                DeleteMvmtDtls("IS");
            }
        }
        protected void rblpromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rblpromo, lnkPrmAdd, lnkPrmView);
            if (rblpromo.SelectedValue == "N")
            {
                DeleteMvmtDtls("PRM");
            }
        }
        protected void rbldemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rbldemo, lnkDemoAdd, lnkDemoView);
            if (rbldemo.SelectedValue == "N")
            {
                DeleteMvmtDtls("DEM");
            }
        }

        protected void ShowAddMvmt(string mvmtrule, string flag, string lnkbtn)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funcShowPopupMvmt('" + mvmtrule.ToString().Trim() + "','"
                                                          + Request.QueryString["SalesChnl"].ToString().Trim() + "','"
                                                          + Request.QueryString["SubClass"].ToString().Trim() + "','"
                                                          + Request.QueryString["AgtType"].ToString().Trim() + "','"
                                                          + ddlUnitRank.SelectedValue.ToString().Trim() + "','"
                                                          + ddlbasedon.SelectedValue.ToString().Trim() + "','"
                                                          + ddllevelagttype.SelectedValue.ToString().Trim() + "','"
                                                          + flag.ToString().Trim() + "','"
                                                          + lnkbtn.ToString().Trim() + "')", true);
        }

        protected void lnkTrfAdd_Click(object sender, EventArgs e)
        {
            if (lnkTrfAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("TRF", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("TRF", "E", "lnkTrfAdd");
            }
        }
        protected void lnkTrfView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("TRF", "V", "lnkTrfView");
        }
        protected void lnkTrmAdd_Click(object sender, EventArgs e)
        {
            if (lnkTrmAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("TR", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("TR", "E", "lnkTrmAdd");
            }
        }
        protected void lnkTrmView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("TR", "V", "lnkTrmView");
        }
        protected void lnkReinAdd_Click(object sender, EventArgs e)
        {
            if (lnkReinAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("IS", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("IS", "E", "lnkReinAdd");
            }
        }
        protected void lnkReinView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("IS", "V", "lnkReinView");
        }
        protected void lnkPrmAdd_Click(object sender, EventArgs e)
        {
            if (lnkPrmAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("PRM", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("PRM", "E", "lnkPrmAdd");
            }
        }
        protected void lnkPrmView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("PRM", "V", "lnkPrmView");
        }
        protected void lnkDemoAdd_Click(object sender, EventArgs e)
        {
            if (lnkDemoAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("DEM", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("DEM", "E", "lnkDemoAdd");
            }
        }
        protected void lnkDemoView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("DEM", "V", "lnkDemoView");
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            if (Session["mvmt"] != null)
            {
                if (Session["mvmt"].ToString() != "")
                {
                    if (Session["mvmt"].ToString() == "TRF")
                    {
                        lnkTrfAdd.Text = "Edit Rule";
                        lnkTrfView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "TR")
                    {
                        lnkTrmAdd.Text = "Edit Rule";
                        lnkTrmView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "IS")
                    {
                        lnkReinAdd.Text = "Edit Rule";
                        lnkReinView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "PRM")
                    {
                        lnkPrmAdd.Text = "Edit Rule";
                        lnkPrmView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "DEM")
                    {
                        lnkDemoAdd.Text = "Edit Rule";
                        lnkDemoView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "CR")
                    {
                        lnkCrtAdd.Text = "Edit Rule";
                        lnkCrtView.Visible = true;
                    }
                    if (Session["mvmt"].ToString() == "MD")
                    {
                        lnkModAdd.Text = "Edit Rule";
                        lnkModView.Visible = true;
                    }
                }
            }
        }

        protected void DeleteMvmtDtls(string MvmtType)
        {
            htable.Clear();
            dsResult.Clear();
            htable.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString());
            htable.Add("@ChnCls", Request.QueryString["SubClass"].ToString());
            htable.Add("@MemType", Request.QueryString["AgtType"].ToString().Trim());
            htable.Add("@Flag", "2");
            htable.Add("@MvmtRule", MvmtType);
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_InsMvmtRptDtls", htable);
        }
        protected void rblcreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rblcreate, lnkCrtAdd, lnkCrtView);
            if (rblcreate.SelectedValue == "N")
            {
                DeleteMvmtDtls("CR");
            }
        }
        protected void rblmodify_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMvmtValues(rblmodify, lnkModAdd, lnkModView);
            if (rblmodify.SelectedValue == "N")
            {
                DeleteMvmtDtls("MD");
            }
        }
        protected void lnkCrtAdd_Click(object sender, EventArgs e)
        {
            if (lnkCrtAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("CR", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("CR", "E", "lnkCrtAdd");
            }
        }
        protected void lnkCrtView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("CR", "V", "lnkCrtView");
        }
        protected void lnkModView_Click(object sender, EventArgs e)
        {
            ShowAddMvmt("MD", "V", "lnkModView");
        }
        protected void lnkModAdd_Click(object sender, EventArgs e)
        {
            if (lnkModAdd.Text == "Edit Rule")
            {
                ShowAddMvmt("MD", "E", "EMV");
            }
            else
            {
                ShowAddMvmt("MD", "E", "lnkModAdd");
            }
        }

        /////--by meena--////
        #region GetManagers
        protected void GetManagers()
        {
            try
            {
                //hdnMemRole.Value = "E"; //---by meena for temporary
                //added  by usha 27.10.21 
                if (Request.QueryString["Flag"] != "N")
                {
                    hdnMemCode.Value = Request.QueryString["AgtType"].ToString().Trim();
                }
                //hdnMemCode.Value = Request.QueryString["AgtType"].ToString().Trim();
                if (hdnMemRole.Value != "")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlchannel.SelectedValue.Trim() + "','" + ddlsubchannel.SelectedValue.Trim() + "','" + ddllevelagttype.SelectedValue + "','" + hdnMemRole.Value.Trim() + "','" + ddlbasedon.SelectedValue.ToString().Trim() + "','" + ddlRptSetup.SelectedValue.ToString() + "','" + ddlreportingtype.SelectedValue.ToString() + "','');return false;");

                }
                else
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlchannel.SelectedValue.Trim() + "','" + ddlsubchannel.SelectedValue.Trim() + "','" + ddllevelagttype.SelectedValue + "','','" + ddlbasedon.SelectedValue.ToString().Trim() + "','" + ddlRptSetup.SelectedValue.ToString() + "','" + ddlreportingtype.SelectedValue.ToString() + "','');return false;");

                }
                Hashtable htParam = new Hashtable();
                DataSet dsmgr = new DataSet();
                dsmgr.Clear();
                htParam.Clear();
                htParam.Add("@AgentType", ddllevelagttype.SelectedValue);
                htParam.Add("@BizSrc", ddlchannel.SelectedValue.Trim());
                htParam.Add("@ChnCls", ddlsubchannel.SelectedValue.Trim());
                dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforManager", htParam);
                if (dsmgr.Tables.Count > 0)
                {
                    if (dsmgr.Tables[0].Rows.Count > 0)
                    {
                        #region commented
                        //ddlRptMgr.DataSource = dsmgr;
                        //ddlRptMgr.DataTextField = "LegalName";
                        //ddlRptMgr.DataValueField = "AgentCode";
                        //ddlRptMgr.DataBind();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "Page_Load", ex);

            }
        }

        #endregion

        #region btnRptMgr
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
            if (ddlRptSetup.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select  Reporting Setup.');</script>", false);
                return;
            }
            if (ddlRptSetup.SelectedIndex != 0)
            {
                GetManagers();
            }
        }
        /////--by meena--////

        #endregion

        #region btnmemgrid_Click
        protected void btnmemgrid_Click(object sender, EventArgs e)
        {
            if (Session["mem"] != null)
            {

            }
        }
        #endregion

        #region Bindgridprimary
        protected void Bindgridprimary(DropDownList ddl, DropDownList ddl1, string memtype)
        {

            try
            {
                dsResult.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Add("@BizSrc", ddl.SelectedValue);
                htParam.Add("@ChnCls", ddl1.SelectedValue);
                htParam.Add("@MemType", memtype.ToString());

                dsResult = objDAL.GetDataSetForPrc("Prc_getchnprimaryMapRptType", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = dsResult.Tables[0];
                        gv.DataBind();
                    }
                    else
                    {
                        gv.DataSource = null;
                        gv.DataBind();
                    }
                }
                else
                {

                    gv.DataSource = null;
                    gv.DataBind();
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

        #region start Code added by bhau 02/04/2018

        #region lnkbtnaddprod_Click
        protected void lnkbtnaddprod_Click(object sender, EventArgs e)
        {
            try
            {
                MdlPopExtndrLOB.Show();
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
            finally
            {
            }
        }
        #endregion

        #region btnProductDtls_Click
        protected void btnProductDtls_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["flag"].ToString() != "V")
                {
                    DataTable dt1 = new DataTable();
                    dt1 = (DataTable)Session["ProductDetails"];
                }
                GetDataTable();
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
            finally
            {
                dsResult = null;
                htable.Clear();
            }
        }
        #endregion

        #region btnprevious_Click
        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex - 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
                if (txtPage.Text == "1")
                {
                    btnprevious.Enabled = false;
                }
                else
                {
                    btnprevious.Enabled = true;
                }
                btnnext.Enabled = true;
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

        #region btnnext_Click
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = GridProdDtls.PageIndex;
                GridProdDtls.PageIndex = pageIndex + 1;
                GetDataTable();
                txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
                btnprevious.Enabled = true;
                int page = GridProdDtls.PageCount;
                if (txtPage.Text == Convert.ToString(GridProdDtls.PageCount))
                {
                    btnnext.Enabled = false;
                }
                else
                {
                    int intPageIndex = GridProdDtls.PageIndex + 1;
                    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
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

        #region GrdStateDtls_PageIndexChanging
        protected void GrdStateDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        #region GetDataTable
        protected DataTable GetDataTable()
        {
            try
            {
                string strProdcode, strProdName, LOBList, strOldProdcode;
                DataTable dt = new DataTable();
                DataTable dtold = new DataTable();
                dt = (DataTable)Session["ProductDetails"];
                if (dt != null) /*&& Request.QueryString["flag"].ToString() == "N"*/
                {
                    strProdcode = dt.Rows[0]["ProdCode"].ToString();
                    strProdName = dt.Rows[0]["ProdName"].ToString();
                    LOBList = dt.Rows[0]["LOBList"].ToString();
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = strProdcode;
                    if (Session["OldProductDetails"] != null)
                    {
                        dtold = (DataTable)Session["OldProductDetails"];
                        strOldProdcode = dtold.Rows[0]["ProdCode"].ToString();
                        strProdcode = strProdcode + "," + strOldProdcode;

                        //strProdcode = strProdcode + "','" + strOldProdcode;
                    }
                    htable.Clear();
                    dsResult = null;
                    htable.Add("@ProdCode", strProdcode.ToString());
                    htable.Add("@LOBList", LOBList.ToString());
                    if (Request.QueryString["flag"].ToString() == "V")
                    {
                        htable.Add("@bizsrc", "NNNN");
                    }
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            //bind old and new value to grid
                            Session["OldProductDetails"] = dt;

                            GridProdDtls.DataSource = dsResult;
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();

                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            div2.Attributes.Add("style", "display:none");
                        }
                    }
                }
                else
                {
                    divProducrGridDtls.Visible = true;
                    hdnprdcode.Value = "";
                    htable.Clear();
                    dsResult = null;
                    if (Request.QueryString["flag"].ToString() == "''")
                    {
                        htable.Add("@bizsrc", "NNNN");
                    }
                    dsResult = objDAL.GetDataSetForPrcIsysTemp("Prc_GetLOBProductDtls", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            GridProdDtls.DataSource = dsResult;
                            GridProdDtls.DataBind();
                            ViewState["grid"] = dsResult.Tables[0];
                            ShowPageInformation();

                            if (GridProdDtls.PageCount > Convert.ToInt32(txtPage.Text))
                            {
                                btnnext.Enabled = true;
                            }
                            else
                            {
                                btnnext.Enabled = false;
                            }
                            lblMessage.Visible = false;
                            lblMessage.Text = "";
                        }
                        else
                        {
                            GridProdDtls.DataSource = null;
                            GridProdDtls.DataBind();
                            lblPageInfo.Text = "";
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                            div2.Attributes.Add("style", "display:none");
                        }
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
            return dsResult.Tables[0];
        }
        #endregion

        #region ShowPageInformation
        private void ShowPageInformation()
        {
            try
            {
                tblpagination.Visible = true;
                int intPageIndex = GridProdDtls.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridProdDtls.PageCount;
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
            finally
            {
            }
        }
        #endregion

        #region GridProdDtls_RowDataBound
        protected void GridProdDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Request.QueryString["flag"].ToString() == "N")
                    {
                        Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                        lnkdelete.Enabled = false;
                    }
                    else
                    {
                        Button lnkdelete = (Button)e.Row.FindControl("lnkdelete");
                        lnkdelete.Enabled = true;
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
            finally
            {
            }
        }
        #endregion GridProdDtls_RowDataBound

        #region lnkdelete_Click
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btndetails = sender as Button;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                string strProdcode = ((Label)gvrow.FindControl("lblProdCode")).Text;
                string strProdName = ((Label)gvrow.FindControl("lblProdName")).Text;
                string strEffDate = ((Label)gvrow.FindControl("lblEffFromDate")).Text;
                hdn1.Value = strProdcode;
                hdn2.Value = strProdName;
                hdn3.Value = strEffDate;
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
            finally
            {
            }
        }
        #endregion lnkdelete_Click

        #endregion end Code added by bhau 03/04/2018

        #region InsertProductDtls
        public void InsertProductDtls()
        {
            try
            {

                foreach (GridViewRow grdtls in GridProdDtls.Rows)
                {
                    string StrProdCode = ((Label)grdtls.FindControl("lblProdCode")).Text;
                    string StrEffdtim = ((Label)grdtls.FindControl("lblEffFromDate")).Text;
                    string StrLobCode = ((Label)grdtls.FindControl("lblLobCode")).Text;
                    string StrStatus = ((Label)grdtls.FindControl("lblStatus")).Text;
                    string StrCeasedate = ((Label)grdtls.FindControl("lblCeaseDtim")).Text;

                    htable = new Hashtable();
                    htable.Clear();
                    htable.Add("@Bizsrc", "AG");// 
                    htable.Add("@Flag", "M");
                    htable.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
                    htable.Add("@ProdCode", StrProdCode);
                    htable.Add("@EffDate", StrEffdtim);
                    htable.Add("@LOBCode", StrLobCode);
                    htable.Add("@Status", "A");
                    htable.Add("@Ceasedate", StrCeasedate);
                    objDAL.execute_sprcIsysTemp("Prc_InsertProductDtls", htable);
                }

                Session["OldProductDetails"] = null;
                Session["ProductDetails"] = null;
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

        protected void lnkBtnModel_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "funcMgrShowPopupView()", true);

        }

        protected void btnRptMgr1_Click(object sender, EventArgs e)
        {
            if (ddlAdlChn.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Hirarchy Name.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlAdlSChn.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Sub Class.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlAdlBsdOn.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Based On.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlAdlAgtTyp.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Relation Member Type.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }
            if (ddlRptStp.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Reporting Setup.');</script>", false);
                ddllevelagttype.Focus();
                return;
            }

            btnRptMgr1.Attributes.Add("onclick", "funcMgrShowPopupForARD('rptmgr','" + ddlchannel.SelectedValue.Trim() + "','" + ddlsubchannel.SelectedValue.Trim() + "','" + ddllevelagttype.SelectedValue + "','" + hdnMemRole.Value.Trim() + "','" + ddlbasedon.SelectedValue.ToString().Trim() + "','" + ddlRptSetup.SelectedValue.ToString() + "','" + ddlreportingtype.SelectedValue.ToString() + "','');return false;");
        }

        protected void lnkBtnADR_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "funcMgrShowPopupView()", true);
        }
        protected void fillFinyr()
        {
            try
            {
                {
                    Hashtable htParam1 = new Hashtable();
                    DataSet dsdataset = new DataSet();
                    htParam1.Add("@flag", "N");
                    dsdataset = objDAL.GetDataSetForPrcCLP("Prc_get_Current_FinYear", htParam1);
                    if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
                    {
                        ddlFinYr.DataSource = dsdataset;
                        ddlFinYr.DataValueField = "ParamValue";
                        ddlFinYr.DataTextField = "ParamDesc";
                        ddlFinYr.DataBind();
                        //fill dropdown for period
                        ddlFinancialYr.DataSource = dsdataset;
                        ddlFinancialYr.DataValueField = "ParamValue";
                        ddlFinancialYr.DataTextField = "ParamDesc";
                        ddlFinancialYr.DataBind();
                    }
                    ddlFinYr.Items.Insert(0, new ListItem("Select", ""));
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popupHist();", true);
                divsrch.Visible = true;
                DivButton.Visible = true;
                grid_Bind();
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

        public void grid_Bind()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                htParam.Add("@Flag", "chnmemsu");
                if (rdMode.SelectedValue != "")
                {
                    htParam.Add("@Mode", rdMode.SelectedItem.Value);
                }
                else
                {
                    htParam.Add("@Mode", System.DBNull.Value);
                }
                if (ddlFinYr.SelectedItem.Value != "")
                {
                    htParam.Add("@FinYr", ddlFinYr.SelectedValue.ToString().Trim());
                }
                else
                {
                    htParam.Add("@FinYr", System.DBNull.Value);
                }

                htParam.Add("@Param1", Request.QueryString["AgtType"].ToString().Trim());
                DataSet dsResult = objDAL.GetDataSetForPrcCLP("Prc_Get_histDetails_Hierarchy", htParam);
                gvhistory.DataSource = dsResult;
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    gvhistory.DataSource = dsResult.Tables[0];
                    gvhistory.DataBind();
                }
                else
                {
                    dsResult.Tables[0].Rows.Add(dsResult.Tables[0].NewRow());
                    gvhistory.DataSource = dsResult.Tables[0];
                    gvhistory.DataBind();
                    int TotalColumns = gvhistory.Rows[0].Cells.Count;
                    gvhistory.Rows[0].Cells.Clear();
                    gvhistory.Rows[0].Cells.Add(new TableCell());
                    gvhistory.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    gvhistory.Rows[0].Cells[0].Text = "No Record Found";
                    gvhistory.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gvhistory.HeaderRow.Visible = false;
                }
                htParam.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Validation Before Data Insertion For Records If Already Exists. 
        public void ValidateInsertionData()
        {
            try
            {
                DataSet dsreturn = new DataSet();
                htable.Add("@MemType", this.txtAgtTypeVal.Text.Trim());
                dsreturn = ValidationIfDataAlreadyExists("PRC_RECORDEXIT_CHNMEMSU", htable, "INSCCommonConnectionString");
                if (dsreturn.Tables.Count != 0)
                {
                    string comnm = dsreturn.Tables[0].Rows[0]["Message"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('" + comnm + "');</script>", false);
                    if (comnm == "Agent Type already exists")
                    {
                        txtAgtTypeVal.Text = "";
                        txtAgtTypeVal.Focus();
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "ValidateInsertionData", ex);
            }
        }
        #endregion

        protected void btnshowHist_Click1(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popupHist();", true);
            //grid_Bind();
            fillFinyr();
        }

        protected void txtAgtTypeVal_TextChanged(object sender, EventArgs e)
        {
            ValidateInsertionData();
        }

        protected void ddlUChnnl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUSubCls1.Items.Clear();
            ddlUUnitType1.SelectedIndex = 0;
            ddlUMBasedOn1.SelectedIndex = 0;
            string userid = Session["UserID"].ToString();
            objCommonU.GetUserChnclsChannel(ddlUSubCls1, ddlUChnnl1.SelectedValue, 0, userid.ToString());
            ddlUSubCls1.Items.Insert(0, new ListItem("Select", ""));
            ddlUnitLoc1.SelectedIndex = 0;
        }

        protected void ddlUMBasedOn1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUUnitType1.Enabled = true;
            ddlUUnitType1.Items.Clear();
            ddlUUnitType1.Items.Insert(0, new ListItem("Select", ""));
            ddlUnitLoc1.SelectedIndex = 0;
            if (ddlUMBasedOn1.SelectedValue == "1")
            {
                GetUnitLevel1();
            }
            else if (ddlUMBasedOn1.SelectedValue == "0")
            {
                GetUnitRank1();
            }
        }

        protected void GetUnitLevel1()
        {
            try
            {
                ddlUUnitType1.Items.Clear();
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl1.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls1.SelectedValue);
                htParam.Add("@flag", 3);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                htParam.Add("@UntLvl", txtAgentLvl.Text.Trim());
                FillDropDown(ddlUUnitType1, "Prc_GetUnitDesc", htParam, "INSCCommonConnectionString", "", "UnitDesc01", "UnitType");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetUnitLevel1", ex);
            }
        }

        protected void GetUnitRank1()
        {
            try
            {
                ddlUUnitType1.Items.Clear();
                htParam.Clear();
                htParam.Add("@BizSrc", ddlUChnnl1.SelectedValue);
                htParam.Add("@Chncls", ddlUSubCls1.SelectedValue);
                htParam.Add("@flag", 4);
                htParam.Add("@UntRnk", ddlUnitRank.SelectedValue);
                FillDropDown(ddlUUnitType1, "Prc_GetUnitDesc", htParam, "INSCCommonConnectionString", "", "UnitRank", "UnitRank");
            }
            catch (Exception ex)
            {
                LogException("ISYS-CHMS", "AGTLevel.aspx", "GetUnitRank", ex);

            }
        }

        public void AddlUntMngr()
        {
            InsAndUpdatAddlUntMngr(htable);
            if (Flag == "E")
            {
                InsertData("Prc_Upt_ChnMemAddlUntMngrDtlSU", htable, "INSCCommonConnectionString");
            }
            if (Flag == "N")
            {
                InsertData("Prc_Ins_ChnMemAddlUntMngrDtlSU", htable, "INSCCommonConnectionString");
            }
        }

        public void InsAndUpdatAddlUntMngr(Hashtable htable)
        {
            htable.Clear();
            if (Request.QueryString["flag"] == "N")
            {
                htable.Add("@Flag", "N");
            }
            else
            {
                htable.Add("@Flag", "E");
            }
            htable.Add("@BizSrc", channel);
            htable.Add("@ChnCls", ddlChnnlClass.SelectedValue.ToString().Trim());
            htable.Add("@MemType", AgtType.ToString().Trim());
            htable.Add("@Channel", ddlUChnnl1.SelectedValue);
            htable.Add("@SubChannel", ddlUSubCls1.SelectedValue);
            htable.Add("@BasedOnType", ddlUMBasedOn1.SelectedValue);
            htable.Add("@MemOrLevelType", ddlUUnitType1.SelectedValue.ToString());
            htable.Add("@UnitLocation", ddlUnitLoc1.SelectedValue);
            if (Request.QueryString["flag"] == "E")
            {
                htable.Add("@UpdateBy", Convert.ToString(Session["UserName"]).Trim());
                htable.Add("@UpdateDtim", "");
            }
            else
            {
                htable.Add("@CreateBy", Convert.ToString(Session["UserName"]).Trim());
                htable.Add("@CreateDtim", "");
            }
        }

        public void GetAddlUntMngr()
        {
            Hashtable htable = new Hashtable();
            DataSet dsResult = new DataSet();
            htable.Add("@BizSrc", Request.QueryString["SalesChnl"].ToString());
            htable.Add("@ChnCls", Request.QueryString["SubClass"].ToString());
            htable.Add("@MemType", Request.QueryString["AgtType"].ToString().Trim());
            dsResult = objDAL.GetDataSetForPrc("Prc_Get_ChnMemAddlUntMngrDtlSU", htable);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlUChnnl1.SelectedValue = dsResult.Tables[0].Rows[0]["Channel"].ToString().Trim();
                objCommonU.GetUserChnclsChannel(ddlUSubCls1, ddlUChnnl1.SelectedValue, 0, Session["UserId"].ToString());
                ddlUSubCls1.SelectedValue = dsResult.Tables[0].Rows[0]["SubChannel"].ToString().Trim();
                ddlUMBasedOn1.SelectedValue = dsResult.Tables[0].Rows[0]["BasedOnType"].ToString().Trim();
                if (ddlUMBasedOn1.SelectedValue == "1")
                {
                    GetUnitLevel1();
                }
                else if (ddlUMBasedOn1.SelectedValue == "0")
                {
                    GetUnitRank1();
                }
                ddlUUnitType1.SelectedValue = dsResult.Tables[0].Rows[0]["MemOrLevelType"].ToString().Trim();
                ddlUnitLoc1.SelectedValue = dsResult.Tables[0].Rows[0]["UnitLocation"].ToString().Trim();
            }
        }
    }
}


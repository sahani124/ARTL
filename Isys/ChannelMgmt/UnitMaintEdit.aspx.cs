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
using System.Drawing;
using INSCL.DAL;
using System.Data.SqlClient;
using INSCL.App_Code;
using System.Threading;
using System.Globalization;
using Insc.Common.Multilingual;
using System.Xml;
using Insc.MQ.Life.CSCr;
using Insc.MQ.Life.CSMod;
using DataAccessClassDAL;

namespace INSCL
{
    public partial class UnitMaintEdit : BaseClass
    {
        #region Declarations
        SqlDataReader dtRead;
        Hashtable htable = new Hashtable();
        CommonFunc oCommon = new CommonFunc();
        //Change of int  to decimal untLvl due to Addition of State in Tied
        Decimal untLvl;
        XmlDocument doc = new XmlDocument();
        DataSet dsResult;
        private multilingualManager olng, olng2;
        private string strUserLang;
        int intCode;
        string ErrMsg, AuditType, strXML = "", MgrCreateRul = "", strRptUnitCode = "";

        string PositionReq = string.Empty;//Added by usha  for position  on 26.02.2109
        DataAccessClass objDAL = new DataAccessClass();
        DataAccessClass dataAccess = new DataAccessClass();
        INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
        clsUnitMaint objclsUM = new clsUnitMaint();
        clsAgent agentObject = new clsAgent();
        string strMgrCode = "", strAgentType = "", strUnitRank = "", strNewAgnType = "";
        //Added by rachana on 12-07-2013 for MQ code start
        string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
        //Added by rachana on 12-07-2013 for MQ code end
        //Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content start
        DataSet dsUnit;
        DataSet dsUnitType;
        Hashtable htUnitType = new Hashtable();
        ErrLog objErr = new ErrLog();
        string saploc;
        string MemType;
        //Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content end
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
            olng = new multilingualManager("DefaultConn", "UnitMaintEdit.aspx", strUserLang);
            olng2 = new multilingualManager("DefaultConn", "AGTLevel.aspx", strUserLang);
            Session["CarrierCode"] = '2';
            SqlDataReader dtRead;
            string strChnCrtRul = "";


            #region NotIsPostBack
            if (!IsPostBack)
            {
                InitializeControl();
                ddlChnnlSubClass.Focus();
                rdlYesNo.SelectedIndex = 0;
                if (Request.QueryString["ChannelCode"] == "XX")
                {
                    lblLocCode.Visible = true;
                    btnGetDefault.Visible = true;
                    txtSALocCode.Visible = true;
                    lblCmpUntCode.Visible = false;
                    txtCompanyUnitCode.Visible = false;
                }
                else
                {
                    lblLocCode.Visible = false;
                    btnGetDefault.Visible = false;
                    txtSALocCode.Visible = false;
                    lblCmpUntCode.Visible = true;
                    txtCompanyUnitCode.Visible = true;

                    //Added by rachana start 
                    lblCSCCodeLA.Visible = true;
                    lblCSCCodeLA.Text = "Cease Date";
                    //Added by rachana end 
                }
                string strChannelCode = Request.QueryString["ChannelCode"];
                string strUnitTypeCode = Request.QueryString["UnitTypeCode"];
                string CarrierCode = Session["CarrierCode"].ToString();
                //Change of int  to decimal due to Addition of State in Tied
                untLvl = Convert.ToDecimal(objclsUM.GetUnitLevel(strUnitTypeCode, CarrierCode, strChannelCode));
                txtUntDesc1.Text = Request.QueryString["UName"];
                string strCount = Request.QueryString["strCount"];
                //if (Request.QueryString["strCount"] == "1.0")
                //{
                //    ddlReportingUnit.Items.Insert(0, "HQ - HQ");
                //}
                //else if (Request.QueryString["SubCls"] == "AGAM" && Request.QueryString["UnitTypeCode"] == "ST")
                //{
                //    objclsUM.GetRptUnitSO(ddlReportingUnit, Session["LanguageCode"].ToString(), strCount, Request.QueryString["ChannelCode"], Request.QueryString["SubCls"]);
                //}
                //else
                //{
                //    objclsUM.GetRptUnit(ddlReportingUnit, Session["LanguageCode"].ToString(), strCount, Request.QueryString["ChannelCode"], Request.QueryString["SubCls"]);
                //}
                //if (ddlReportingUnit.Items.Count < 1)
                //{
                //    ddlReportingUnit.Items.Insert(0, new ListItem("Select", ""));
                //}
                //if (Request.QueryString["RptUntCode"].Trim() != "")
                //{
                //    ddlReportingUnit.SelectedValue = Request.QueryString["RptUntCode"];
                //    ddlReportingUnit.Enabled = false;
                //}
                //Added by rachana on 03-07-2013 for SELECT ChnCls, ChnClsDesc01 start
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());

                dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubclsforunitmaint", htable);
                //Added by rachana on 03-07-2013 for SELECT ChnCls, ChnClsDesc01 end
                if (dtRead.HasRows)
                {
                    ddlChnnlSubClass.DataSource = dtRead;
                    ddlChnnlSubClass.DataTextField = "ChnlDesc";
                    ddlChnnlSubClass.DataValueField = "ChnCls";
                    ddlChnnlSubClass.DataBind();
                }
                dtRead = null;
                ddlChnnlSubClass.Items.Insert(0, new ListItem("Select", ""));
                if (ddlChnnlSubClass.Items.Count > 1)
                {
                    ddlChnnlSubClass.SelectedValue = Request.QueryString["SubCls"];
                }
                //oCommon.getRadio(rdlYesNo, "cboyesno", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 0);
                oCommon.getRadio(rdlYesNo, "cboyesno", Session["UserLangNum"].ToString(), "", 0);


                oCommon.getDropDown(ddlUnitStat, "unitstatus", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                if (ddlUnitStat.Items.Count > 0)
                {
                    ddlUnitStat.SelectedValue = "IF";
                }

                ddlUnitStat.Items.Insert(0, new ListItem("Select", ""));
                try
                {
                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                    htable.Add("@ChnCls", Request.QueryString["SubCls"]);
                    //Added by Kalyani on 18-12-2013 to pass flag 1 when bizsrc is xx start
                    if (Request.QueryString["ChannelCode"] == "XX")
                    {
                        htable.Add("@Flag", "O");
                    }
                    else
                    {
                        htable.Add("@Flag", "C");
                    }
                    //Added by Kalyani on 18-12-2013 to pass flag 1 when bizsrc is xx end
                    dsResult = new DataSet();
                    dsResult = objDAL.GetDataSetForPrc("prc_UnitSearch", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            objCommonU.FillDropDown(ddlUnitType, dsResult.Tables[0], "UnitType", "UnitDesc01");
                        }
                    }

                    dsResult = null;

                    htable.Clear();
                    htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                    htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
                    htable.Add("@ChnnlSubCls", Request.QueryString["SubCls"]);

                    dsResult = new DataSet();
                    dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_SALocCode", htable);
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            hdnSALocCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["SALocCode"]).Trim();
                        }
                        else
                        {
                            hdnSALocCode.Value = "";
                        }
                    }
                    dsResult = null;
                    htable.Clear();

                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Visible = true;
                    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                    string sRet = oInfo.Name;
                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    String LogClassName = method.ReflectedType.Name;
                    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                }

                if (Request.QueryString["F"] != null)
                {
                    try
                    {
                        if (Request.QueryString["F"].ToString() == "N") // NEW
                        {
                            btnUpdate.Text = "<i class='glyphicon glyphicon-floppy-disk' style='color:White'></i> Save";
                            lblSalesChannel.Text = Request.QueryString["ChannelName"].ToString();
                            ddlUnitType.SelectedValue = Request.QueryString["UnitTypeCode"].ToString();
                            //Added by rachana on 03-07-2013 for Selecting ChnCreateRul start
                            htable.Clear();
                            htable.Add("@ChnCls", "");
                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            htable.Add("@flag", "3");
                            dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                            //Added by rachana on 03-07-2013 for Selecting ChnCreateRul end

                            if (dtRead.Read())
                            {
                                strChnCrtRul = dtRead[0].ToString();
                            }
                            dtRead.Close();
                            if (Request.QueryString["ChannelCode"].ToString() == "AG" || Request.QueryString["ChannelCode"].ToString() == "CN" || Request.QueryString["ChannelCode"].ToString() == "LP" || Request.QueryString["ChannelCode"].ToString() == "PR")//Add by Darshik for CN / PR 
                            {
                                //added by rachana on 03-07-2013 for Selecting UnitRank replacement
                                htable.Clear();
                                htable.Add("@Chncls", Request.QueryString["SubCls"].ToString());
                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                dtRead = objDAL.Common_exec_reader_prc("Prc_GetunitRankforunitmaint", htable);
                                //Added by rachana on 03-07-2013 for Selecting UnitRank end

                                if (dtRead.Read())
                                {
                                    //Change of int  to decimal  due to Addition of State in Tied
                                    if (dtRead[0].ToString() == "5.0")
                                    {
                                        txtSMCount.Visible = true;
                                        lblSMCount.Visible = true;
                                        spSMCount.Visible = true;
                                    }
                                }
                            }

                            //Added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                            GetLinkedMasterUnit();
                            //Added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                            string strMgrCrtRul = "";
                            //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                            htable.Clear();

                            htable.Add("@BizSrc", Request.QueryString["SubCls"].ToString());
                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                            //Added by rachana on 03-07-2013 for Select MgrCreateRul end

                            if (dtRead.Read())
                            {
                                strMgrCrtRul = dtRead[0].ToString();
                            }
                            dtRead.Close();
                            if (strMgrCrtRul.ToString().Trim() == "0")
                            {
                                lblPCCode.Visible = true;
                                txtPCCode.Visible = true;
                            }
                            txtUnitCode.Visible = true;
                            //rfvUCode.Visible = true;
                            lblUnitCode.Visible = false;
                            ddlUnitType.Enabled = true;
                            span1.Visible = true;
                            //span2.Visible = true;


                            if (ddlUnitType.SelectedValue.ToString() == "SS" || ddlUnitType.SelectedValue.ToString() == "SU")
                            {
                                rdlYesNo.SelectedValue = "Y";
                                rdlYesNo.Enabled = false;
                                GetCmpUnitCode();
                            }
                        }
                        else // For Update 
                        {
                            txtUnitCode.Visible = false;
                            //rfvUCode.Visible = false;
                            lblUnitCode.Visible = true;
                            //span2.Visible = false;
                            ddlChnnlSubClass.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblmsg.Text = ex.Message;
                        lblmsg.Visible = true;
                        lblmsg.ForeColor = Color.Red;
                        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                        string sRet = oInfo.Name;
                        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                        String LogClassName = method.ReflectedType.Name;
                        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    }
                    PopulateState(ddlState);
                    //  tblUnitRptType.Visible = false;
                }
                else
                {
                    rdlYesNo.Enabled = false;
                    PopulateState(ddlState);
                    lblSalesChannel.Text = Request.QueryString["ChannelName"].ToString();
                    ddlChnnlSubClass.Enabled = false;
                    lblUnitCode.Visible = true;
                    lblUnitCode.Text = Request.QueryString["UnitCode"].ToString();
                    //rfvUCode.Visible = false;

                    //Added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                    GetLinkedMasterUnit();
                    //Added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content end
                    GetUnitData();
                    ddlUnitType.Enabled = false;
                }

                dsResult = null;

                FillHiddenValues();
                if (Session["UserGrp"].ToString() == ConfigurationManager.AppSettings["BlockGroupName"].ToString())
                {
                    btnUpdate.Enabled = false;
                }



                getunitcode();
                fillRptMgrDtls();
                //ddlChnnlSubClass.Focus();
                ScriptManager.GetCurrent(this.Page).SetFocus(ddlChnnlSubClass);

              
            }
            #endregion
           
            rdlYesNo.Items[0].Attributes.Add("onClick", "javascript: funResetUnitMgrInfo();");
            rdlYesNo.Items[1].Attributes.Add("onClick", "javascript: funResetUnitMgrInfo();");
            btnGetDefault.Attributes.Add("onClick", "javascript: return RetrieveSALocCode();");
            ClientScript.RegisterStartupScript(GetType(), "ResetUnitMgrInfo", "<Script Language=\"JavaScript\">funResetUnitMgrInfo();</Script>");
            btnCmsUntCode.Attributes.Add("onClick", "javascript: return funOpenPopWinForUntCode('CmsunitcodePopup.aspx', document.getElementById('" + txtCompanyUnitCode.ClientID + "').value,'" + txtCompanyUnitCode.ClientID + "','" + hdnCmsDesc.ClientID + "' , '1');");
            btnUpdate.Attributes.Add("onClick", "javascript: return Validations();");

            #region Popup button code
            btnStateSrch.Attributes.Add("onclick", "funcShowPopup('statedemo','btnStateSrch');return false;");
            btnRptUntCode.Attributes.Add("onclick", "funcShowPopup('rptunt');return false;");
            btnRptUnitCodeMgr1.Attributes.Add("onclick", "funcShowPopup('rptunt1');return false;");

            //added by meena 6_10_18
            if (ViewState["sapcode"] != "" && ViewState["sapcode"] != null)
            {
                txtBranchCode.Text = ViewState["sapcode"].ToString();
            }

            #endregion

            BindDataGrid();
        }
        #endregion

        #region GetUnitData
        public void GetUnitData()
        {
            try
            {
                string strChnCrtRul = "";
                dsResult = new DataSet();
                dsResult.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htable.Add("@LanguageCode", Convert.ToString(Session["LanguageCode"]));
                htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                htable.Add("@UnitLvl", Request.QueryString["ULevel"]);
                htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
                htable.Add("@ChnnlSubCls", Request.QueryString["SubCls"]);
                dsResult = objDAL.GetDataSetForPrc("prc_EnqUnitMaintenance", htable);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        ddlUnitStat.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitStatus"]);
                        //ddlReportingUnit.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["RptUnitCode"]);
                        //ddlReportingUnit.Enabled = false;
                        if (dsResult.Tables[0].Rows[0]["IsSlsUnit"].ToString() != "")// added by rachana on 05-07-2013 for solving DBNull error
                        {
                            if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["IsSlsUnit"]) == false)
                            {
                                rdlYesNo.SelectedValue = "N";
                            }
                            else
                            {
                                rdlYesNo.SelectedValue = "Y";
                            }
                        }
                        // added by rachana on 05-07-2013 for solving DBNull error end

                        txtUntDesc1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc01"]);
                        txtUntDesc2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc02"]);
                        txtUntDesc3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc03"]);
                        txtCompanyUnitCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]);
                        txtCity.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["City"]);
                        txtOTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                        //txtAddress1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr1"]);
                        //txtAddress2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr2"]);
                        //txtAddress3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr3"]);
                        txtFax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                        //txtPOstCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PostCode"]);
                        txtEMail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                        ddlChnnlSubClass.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                        ddlUnitType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitType"]);
                        txtUnitMGRCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitMgrCode"]);
                        txtSALocCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AccLocCode"]);
                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                        DdlUnitName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["LinkUnitCode_Name"]);
                        DdlAgntName.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["LinkStaffCode"]);
                        //txtBranchCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SapLocation"]);//Added by usha on 24.09.018
                        //ViewState["sapcode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["SapLocation"]);//AddedControl byte meena
                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                        //Added by swapnesh on 12/02/2014 to fetch unit details start
                        txtInsRefCode.Text = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                        txtAddrP1.Text = dsResult.Tables[0].Rows[0]["Adr1"].ToString();
                        txtAddrP2.Text = dsResult.Tables[0].Rows[0]["Adr2"].ToString();
                        txtAddrP3.Text = dsResult.Tables[0].Rows[0]["Adr3"].ToString();
                        txtVillage.Text = dsResult.Tables[0].Rows[0]["Village"].ToString();
                        txtcityp.Text = dsResult.Tables[0].Rows[0]["City"].ToString();
                        ddlState.SelectedValue = dsResult.Tables[0].Rows[0]["StateCode"].ToString();
                        txtDistP.Text = dsResult.Tables[0].Rows[0]["District"].ToString();
                        txtarea.Text = dsResult.Tables[0].Rows[0]["Area"].ToString();
                        txtPinP.Text = dsResult.Tables[0].Rows[0]["PostCode"].ToString();
                        txtLatitude.Text = dsResult.Tables[0].Rows[0]["Latitude"].ToString();
                        txtLongitude.Text = dsResult.Tables[0].Rows[0]["Longitude"].ToString();

                        #region Fetch Reporting manager details
                        fillRptMgrDtlsEdit();
                        #endregion

                        //Added by swapnesh on 12/02/2014 to fetch unit details end

                        //Added by rachana on 02-07-2013 Selecting ChnCreateRul start
                        htable.Clear();
                        htable.Add("@ChnCls", "");
                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@flag", "3");
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                        //Added by rachana on 03-07-2013 Selecting ChnCreateRul end

                        if (dtRead.Read())
                        {
                            strChnCrtRul = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        if (Request.QueryString["ChannelCode"].ToString() == "AG" || Request.QueryString["ChannelCode"].ToString() == "CN" || Request.QueryString["ChannelCode"].ToString() == "LP" || Request.QueryString["ChannelCode"].ToString() == "PR") // Add By Darshik For CN / PR
                        {
                            //Added by rachana on 03-07-2013 for Selecting UnitRank replacement
                            htable.Clear();

                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            htable.Add("@ChnCls", Request.QueryString["SubCls"].ToString());
                            htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("Prc_GetunitRankforunitmaint", htable);
                            //Added by rachana on 03-07-2013 for Selecting UnitRank end

                            if (dtRead.Read())
                            {
                                //change to int32 to todecimal due to state in tied
                                if ((dtRead[0].ToString()) == "5.0")
                                {
                                    txtSMCount.Visible = true;
                                    lblSMCount.Visible = true;
                                    spSMCount.Visible = true;
                                }
                            }
                        }
                        if (txtSMCount.Visible == true)
                        {
                            txtSMCount.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SMCount"]);
                        }
                        string strMgrRul = "";
                        //Added by rachana on 03-07-2013 for Select MgrCreateRul start
                        htable.Clear();
                        htable.Add("@ChnCls", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@BizSrc", Request.QueryString["SubCls"].ToString());
                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                        //Added by rachana on 03-07-2013 for Select MgrCreateRul end


                        if (dtRead.Read())
                        {
                            strMgrRul = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        if (strMgrRul.ToString().Trim() == "0")
                        {
                            lblPCCode.Visible = true;
                            txtPCCode.Visible = true;
                        }
                        if (txtPCCode.Visible == true)
                        {
                            txtPCCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RegistrationNo"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.Visible = true;
                lblmsg.ForeColor = Color.Red;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
        }
        #endregion

        #region getunitcode
        public void getunitcode()
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsunt = new DataSet();
                dsunt.Clear();
                htParam.Clear();
                dsunt = objDAL.GetDataSetForPrc("prc_GetMaxUnitCode", htParam);
                txtUnitCode.Text = dsunt.Tables[0].Rows[0]["CtrNo"].ToString().Trim();
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

        #region InitializeControl
        private void InitializeControl()
        {
            // added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content start
            trMasterLink.Visible = false;
            LblBizsrc.Visible = false;
            LblSlschannel.Visible = false;
            LblSubclass.Visible = false;
            LblChannelSubclass.Visible = false;
            LblUntcodeLink.Visible = false;
            LblUnitType.Visible = false;
            LblUnitName.Visible = false;
            DdlUnitName.Visible = false;

            trStaffLink.Visible = false;
            lbluntSalesChnl.Visible = false;
            lbluntSalesChnlDesc.Visible = false;
            lbluntSubChnl.Visible = false;
            lbluntSubChnlDesc.Visible = false;
            lblAgntType.Visible = false;
            LblAgentType.Visible = false;
            LblAgentName.Visible = false;
            DdlAgntName.Visible = false;
            //added by Kalyani on 20-11-13 for Link to master unit checkbox and Link to staff checkbox content end
            lblSalesChnl.Text = olng.GetItemDesc("lblSalesChnl.Text").ToString().Trim();
            lblChnnlSubClass.Text = olng.GetItemDesc("lblChnnlSubClass.Text").ToString().Trim();
            //lblRptUnit.Text = olng.GetItemDesc("lblRptUnit.Text");
            lblUntType.Text = olng.GetItemDesc("lblUntType.Text");
            lblUntCode.Text = olng.GetItemDesc("lblUntCode.Text");
            lblUnitStatus.Text = olng.GetItemDesc("lblUnitStatus.Text");
            lblSalesUnt.Text = olng.GetItemDesc("lblSalesUnt.Text");
            lblUntMgrCode.Text = olng.GetItemDesc("lblUntMgrCode.Text");
            lblUntDesc1.Text = olng.GetItemDesc("lblUntDesc1.Text");
            lblRemark.Text = olng.GetItemDesc("lblRemark.Text");
            lblUntDesc2.Text = olng.GetItemDesc("lblUntDesc2.Text");
            lblCmpUntCode.Text = olng.GetItemDesc("lblCmpUntCode.Text");
            lblLocCode.Text = olng.GetItemDesc("lblLocCode.Text");
            lblUntDesc3.Text = olng.GetItemDesc("lblUntDesc3.Text");
            lblCity.Text = olng.GetItemDesc("lblCity.Text");
            lblOffTel.Text = olng.GetItemDesc("lblOffTel.Text");
            lblAddress.Text = olng.GetItemDesc("lblAddress.Text");
            lblFax.Text = olng.GetItemDesc("lblFax.Text");
            lblPostCode.Text = olng.GetItemDesc("lblPostCode.Text");
            lblEmail.Text = olng.GetItemDesc("lblEmail.Text");

            #region reporting manager details
            lblPrReptDtls.Text = (olng2.GetItemDesc("lblPrReptDtls.Text"));
            lblddlreportingtype.Text = (olng2.GetItemDesc("lblddlreportingtype.Text"));
            lblPrichannel.Text = (olng2.GetItemDesc("lblchannel.Text"));
            lblPrisubchannel.Text = (olng2.GetItemDesc("lblsubchannel.Text"));
            lblPribasedon.Text = (olng2.GetItemDesc("lblbasedon.Text"));
            lblPrilevelagttype.Text = (olng2.GetItemDesc("lbllevelagttype.Text"));
            lbladditionalreporting.Text = (olng2.GetItemDesc("lbladditionalreporting.Text"));
            lblAddlRDtls.Text = (olng2.GetItemDesc("lblAddlRDtls.Text"));
            lblAddlMRptTyp.Text = (olng2.GetItemDesc("lblAddlMRptTyp.Text"));
            lblAddlMChnl.Text = (olng2.GetItemDesc("lblAddlMChnl.Text"));
            lblAddlMSubCls.Text = (olng2.GetItemDesc("lblAddlMSubCls.Text"));
            lblAddlMBsdOn.Text = (olng2.GetItemDesc("lblAddlMBsdOn.Text"));
            lblAMLvlAgtTyp.Text = (olng2.GetItemDesc("lblAMLvlAgtTyp.Text"));
            lbladditionalmangr1.Text = (olng2.GetItemDesc("lbladditionalmangr1.Text"));
            lbladditionalmangr2.Text = (olng2.GetItemDesc("lbladditionalmangr2.Text"));
            lblRptRule.Text = (olng2.GetItemDesc("lblRptRule.Text"));
            #endregion
        }
        #endregion

        #region FUNCTION FillHiddenValues
        protected void FillHiddenValues()
        {
            hdnID220.Value = "Please Enter Unit Code.";
            hdnID230.Value = "Please enter Unit Local Name.";
            hdnID240.Value = "Please enter Unit Name.";
            hdnID250.Value = "Please enter Unit Manager Code.";
            hdnID260.Value = "Please enter valid Unit Manager Code.";
            hdnID270.Value = "Please enter PostCode with positive numeric value.";
            hdnID280.Value = "Please enter valid Email Address.";
            hdnID290.Value = "Please enter Location Code (Sun System Analysis Code).";
            hdnID320.Value = "Please select Reporting Unit";
            hdnID330.Value = "Please select the Sales Unit.";
            hdnID350.Value = "Please enter Company Unit Code.";
            hdnID360.Value = "Sales Unit must set to 'Yes' for unit level 7.";
            hdnID370.Value = "Invalid Office Telephone No.";
            hdnID380.Value = "Invalid Fax No.";
        }
        #endregion

        #region btnUpdate
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            SqlDataReader dtRead;
            Hashtable htable = new Hashtable();
            ArrayList arrResult = new ArrayList();

            string strChannelCode = Request.QueryString["ChannelCode"];
            string CarrierCode = Session["CarrierCode"].ToString();
            string UnitCode = "", strUntCode = "";

            clsChannelSetup channelsetup = new clsChannelSetup();
            try
            {
                if (Request.QueryString["flag"] == "add")
                {
                    //Added on 04-07-2013 for Selecting UnitCode start
                    htable.Clear();
                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@UnitCode", txtUnitCode.Text);
                    htable.Add("@flag", "COD");
                    dtRead = objDAL.Common_exec_reader_prc("prc_GetDataonUnitCode", htable);
                    //Added on 04-07-2013 for Selecting UnitCode end

                    if (dtRead.Read())
                    {
                        strUntCode = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    if (strUntCode == "")
                    {
                        string ChnCreateRul = "";
                        //Added by rachana on 03-07-2013 Selecting ChnCreateRul start
                        htable.Clear();

                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        htable.Add("@flag", "2");
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                        //Added by rachana on 03-07-2013 Selecting ChnCreateRul end

                        if (dtRead.Read())
                        {
                            ChnCreateRul = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        //added chncls For agency subclass
                        //Added by rachana on 03-07-2013 for Select ChnCls start
                        htable.Clear();

                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        htable.Add("@flag", "4");
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                        //Added by rachana on 03-07-2013 for Select ChnCls end

                        if (dtRead.Read())
                        {
                            ViewState["ChnCls"] = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        if (ChnCreateRul.ToString().Trim() == "2" || ChnCreateRul.ToString().Trim() == "4")
                        {
                            //Added on 04-07-2013 for Selecting UnitCode start
                            htable.Clear();
                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            htable.Add("@UnitCode", txtUnitCode.Text);
                            htable.Add("@flag", "COD");
                            dtRead = objDAL.Common_exec_reader_prc("prc_GetDataonUnitCode", htable);
                            //Added on 04-07-2013 for Selecting UnitCode end

                            if (dtRead.Read())
                            {
                                strUntCode = dtRead[0].ToString();
                            }
                            dtRead.Close();
                            if (strUntCode == "")
                            {
                                string MgrCreateRul = "";
                                //Added by rachana on 03-07-2013 for Select MgrCreateRul start
                                htable.Clear();
                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                                //Added by rachana on 03-07-2013 for Select MgrCreateRul end

                                if (dtRead.Read())
                                {
                                    MgrCreateRul = dtRead[0].ToString();
                                }
                                dtRead.Close();

                                if (MgrCreateRul == "2" || MgrCreateRul == "4")
                                {
                                    #region Corporate Client Crt BO Calling Venkat 10/01/2009

                                    int intStatusCode = 0;
                                    Insc.MQ.Life.CrpCltCr.MQCrpCltCr oCrpCltCr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCr();
                                    Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr oCrpCltMgr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCrMgr();

                                    char[] splitterNew = { '/' };
                                    string[] strDtNew = DateTime.Now.ToString("dd/MM/yyyy").Split(splitterNew);
                                    string[] strArrParamNew = new string[32];

                                    strArrParamNew[0] = "Dummy " + txtUntDesc1.Text;

                                    strArrParamNew[1] = "0";	//@PaidUpcapital                                        

                                    strArrParamNew[2] = "RLIC HO";
                                    strArrParamNew[3] = "RLIC HO";
                                    strArrParamNew[4] = "RLIC HO";
                                    strArrParamNew[5] = "Maharashtra";
                                    strArrParamNew[6] = "000000";
                                    strArrParamNew[7] = "";
                                    strArrParamNew[8] = "";
                                    strArrParamNew[9] = "IND";
                                    strArrParamNew[10] = "IND";
                                    strArrParamNew[11] = "I";        //@DirectMailIndicator
                                    strArrParamNew[12] = "";      //@EconomyActivity
                                    strArrParamNew[13] = "";          //@ForTheAttentionof
                                    strArrParamNew[14] = "";      //@FacsimileNo
                                    strArrParamNew[15] = "E";      //@Languag
                                    strArrParamNew[16] = "";       //@LongGivenName
                                    strArrParamNew[17] = "Y";      //@MailingIndicator
                                    strArrParamNew[18] = "";       //@SocialsecurityNo
                                    strArrParamNew[19] = "10";     //@ServicingBranch
                                    strArrParamNew[20] = Convert.ToString(strDtNew[2]);   //@StartDateYear
                                    strArrParamNew[21] = Convert.ToString(strDtNew[1]);     //@StartDateMonth
                                    strArrParamNew[22] = Convert.ToString(strDtNew[0]);     //@StartDate
                                    strArrParamNew[23] = "0";   //@StaffNumber
                                    strArrParamNew[24] = "";       //@StatusCode
                                    strArrParamNew[25] = "";       //@TelegramNo
                                    strArrParamNew[26] = "";       //@TelexNo
                                    strArrParamNew[27] = "N";     //@VIPIndicator
                                    strArrParamNew[28] = "";       //@InternetAddress
                                    strArrParamNew[29] = "";  //@TaxIdNo
                                    strArrParamNew[30] = "";       //@SpecialIndicator
                                    strArrParamNew[31] = Convert.ToString(Session["CarrierCode"]);

                                    //Added by swapnesh on 15/5/2013 for setting value of intStatusCode start
                                    //Changed by rachana on 12-07-2013 to enable MQ code start
                                    if (strCallType == "1")
                                    {
                                        intStatusCode = oCrpCltMgr.FetchClientCreationDetailsFromLA(strArrParamNew, Convert.ToString(Session["CarrierCode"]), ref oCrpCltCr, ref strErrMsg);
                                    }
                                    else
                                    {
                                        intStatusCode = 0;
                                    }
                                    //Changed by rachana on 12-07-2013 to enable MQ code end
                                    //Added by swapnesh on 15/5/2013 for setting value of intStatusCode end

                                    if (oCrpCltCr.dtCrpClt != null)
                                    {
                                        if (oCrpCltCr.dtCrpClt.Rows.Count > 0)
                                        {
                                            lblmsg.Text = "Duplicate Corporate Client Records Found.";
                                            lblmsg.Visible = true;
                                            btnUpdate.Enabled = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (intStatusCode == 0)
                                        {
                                            //ViewState["strClientCode"] = oCrpCltCr.strCLTCRNUM;
                                            //Added by rachana 0n 02-07-2013 for getting Client code by DB start
                                            dtRead = objDAL.exec_reader_without_param_prc("Prc_GetClientcodeforunitmaint");
                                            if (dtRead.Read())
                                            {
                                                ViewState["strClientCode"] = dtRead[0].ToString();

                                            }
                                            dtRead.Close();

                                            //Added by rachana 0n 02-07-2013 for getting Client code by DB end
                                        }//End if (intStatusCode == 0)
                                        else
                                        {
                                            lblmsg.Text = "Error Updating Record In Backend- " + strErrMsg;
                                            lblmsg.Visible = true;
                                        }
                                    }
                                    #endregion

                                    if (Request.QueryString["ChannelCode"] == "AG")
                                    {
                                        //Added by rachana on 02-07-2013 for getting ctrno from Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "AG");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for getting ctrno from Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Read();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint  start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    if (Request.QueryString["ChannelCode"] == "CD")
                                    {
                                        //Added by rachana on 02-07-2013 for for getting ctrno from Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "CD");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for for getting ctrno from Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    if (Request.QueryString["ChannelCode"] == "EM")
                                    {
                                        //Added by rachana on 02-07-2013 for selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "EM");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for selecting ctrno end
                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    //added For new channel Online business
                                    if (Request.QueryString["ChannelCode"] == "OL")
                                    {
                                        //Added by rachana on 02-07-2013 for selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "OL");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for selecting ctrno end

                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    //end added For new channel Online business
                                    //added For new channel Carrier Distribution 
                                    if (Request.QueryString["ChannelCode"] == "LP")
                                    {
                                        //Added by rachana on 02-07-2013 for selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "LP");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for selecting ctrno end
                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start                                                //dtRead = dataAccess.Common_exec_reader("Select CtrNo from dbo.Ctr Where CtrID ='tmpAgentCode'");
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    //end added For new channel Carrier Distribution 
                                    //added For new channel Carrier Distribution 
                                    if (Request.QueryString["ChannelCode"] == "CN")
                                    {
                                        //Added by rachana on 02-07-2013 for selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "CN");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for selecting ctrno end

                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end

                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    //end added For new channel Carrier Distribution 
                                    //added For new channel Premier Distribution 
                                    if (Request.QueryString["ChannelCode"] == "PR")
                                    {
                                        //Added by rachana on 02-07-2013 for selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "PR");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for selecting ctrno end
                                        if (dtRead.Read())
                                        {
                                            ViewState["CSCAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();
                                        htable.Add("@flag", "tm");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint end
                                        if (dtRead.Read())
                                        {
                                            ViewState["SMAgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                    }
                                    //end added For new channel Premier Distribution 

                                    string[] strArrParam = new string[6];
                                    if (Request.QueryString["ChannelCode"] == "AG")
                                    {
                                        strArrParam[0] = '0' + ViewState["CSCAgentCode"].ToString();
                                    }
                                    else if (Request.QueryString["ChannelCode"] == "CD")
                                    {
                                        strArrParam[0] = 'F' + ViewState["CSCAgentCode"].ToString();
                                    }
                                    else if (Request.QueryString["ChannelCode"] == "EM")
                                    {
                                        strArrParam[0] = "Z" + ViewState["CSCAgentCode"].ToString();
                                    }
                                    //added For new channel Online business
                                    else if (Request.QueryString["ChannelCode"] == "OL")
                                    {
                                        strArrParam[0] = "L" + ViewState["CSCAgentCode"].ToString();
                                    }
                                    //end added For new channel Online business
                                    //added For new channel carrier distribution 
                                    else if (Request.QueryString["ChannelCode"] == "LP")
                                    {
                                        strArrParam[0] = "P" + ViewState["CSCAgentCode"].ToString();
                                    }
                                    //end added For new channel carrier distribution 
                                    //added For new channel carrier distribution 
                                    else if (Request.QueryString["ChannelCode"] == "CN")
                                    {
                                        strArrParam[0] = "C" + ViewState["CSCAgentCode"].ToString();
                                    }
                                    //end added For new channel carrier distribution 
                                    //added For new channel Premier distribution 
                                    else if (Request.QueryString["ChannelCode"] == "PR")
                                    {
                                        strArrParam[0] = "I" + ViewState["CSCAgentCode"].ToString();
                                    }
                                    //end added For new channel Premier distribution 
                                    strArrParam[1] = ViewState["strClientCode"].ToString();
                                    if (Request.QueryString["ChannelCode"] == "AG" || Request.QueryString["ChannelCode"] == "CN" || Request.QueryString["ChannelCode"] == "LP" || Request.QueryString["ChannelCode"] == "PR")
                                    {
                                        strArrParam[2] = "1000";
                                    }
                                    if (Request.QueryString["ChannelCode"] == "CD")
                                    {
                                        strArrParam[2] = "1200";
                                    }
                                    strArrParam[3] = "77777777";
                                    strArrParam[4] = "Dummy " + txtUntDesc1.Text;
                                    strArrParam[5] = Convert.ToString(Session["CarrierCode"]);

                                    MQCSCr objCSCr = new MQCSCr();
                                    MQCSCrMgr objCSCrMgr = new MQCSCrMgr();

                                    //Added by swapnesh on 15/5/2013 for setting value of intCode start
                                    //changed by rachana 0n 12-07-2013 to enable MQ code start
                                    if (strCallType == "1")
                                    {
                                        intCode = objCSCrMgr.FetchCSCreationDetailsFromLA(strArrParam, Session["CarrierCode"].ToString(), ref objCSCr, ref strErrMsg);
                                    }
                                    else
                                    {
                                        intCode = 0;
                                    }
                                    //changed by rachana 0n 12-07-2013 to enable MQ code end
                                    //Added by swapnesh on 15/5/2013 for setting value of intCode end

                                    if (intCode == 0)
                                    {
                                        ViewState["strAgentCode"] = objCSCr.strSUCODE;
                                        //added by rachana on 02-07-2013 for getting agentcode start
                                        dtRead = objDAL.exec_reader_without_param_prc("Prc_GetAgentcodeforSM");
                                        if (dtRead.Read())
                                        {
                                            ViewState["strAgentCode"] = dtRead[0].ToString();
                                        }
                                        //added by rachana on 02-07-2013 for getting agentcode end
                                    }
                                }
                                else
                                {
                                    intCode = 0;
                                }

                                if (intCode == 0)
                                {
                                    if (Request.QueryString["flag"] == "add")
                                    {
                                        //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                                        htable.Clear();
                                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                                        //Added by rachana on 03-07-2013 Selecting MgrCreateRul end

                                        if (dtRead.Read())
                                        {
                                            MgrCreateRul = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //if (MgrCreateRul == "1")
                                        //{
                                        //    //added For Dummy RS Creation
                                        //    if (ddlChnnlSubClass.SelectedValue == "AGAM" && ddlUnitType.SelectedValue == "SO")
                                        //    {
                                        //        //Added on 04-07-2013 for Select MgrCode,MgrType start
                                        //        htable.Clear();
                                        //        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //        htable.Add("@ChnCls", "");
                                        //        //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                                        //        htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        //        htable.Add("@LBLUnitCode", "");
                                        //        htable.Add("@LegalName", "");
                                        //        htable.Add("@flag", "SELECTQURY");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //        //Added by rachana on 05-07-2013 for Select MgrCode,MgrType end
                                        //    }
                                        //    else
                                        //    //end
                                        //    {
                                        //        //Added on 04-07-2013 for Select MgrCode,MgrType start
                                        //        htable.Clear();
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //        //htable.Add("@UnitCode",ddlReportingUnit.SelectedValue);
                                        //        htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        //        htable.Add("@LBLUnitCode", "");
                                        //        htable.Add("@LegalName", "");
                                        //        htable.Add("@flag", "SELECTQURY");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //        //Added on 04-07-2013 for Select MgrCode,MgrType end

                                        //    }
                                        //    if (dtRead.Read())
                                        //    {
                                        //        strMgrCode = dtRead[0].ToString();
                                        //        strAgentType = dtRead[1].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //    decimal intUnitRank = 0, NewUnitRank = 0;
                                        //    //Added by rachana on 04-07-2013 Selecting UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@CarrierCode", "");
                                        //    htable.Add("@AgentType", strAgentType);
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting UnitRank end
                                        //    if (dtRead.Read())
                                        //    {
                                        //        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //        intUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitRank", intUnitRank);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank end                                               


                                        //    if (dtRead.Read())
                                        //    {
                                        //        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //        NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    //added agentlevel 

                                        //    //Added by rachana on 04-07-2013 for Select AgentType  start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitCode", "");
                                        //    htable.Add("@UnitRank", NewUnitRank);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                        //    //Added by rachana on 04-07-2013 for Select AgentType  end



                                        //    if (dtRead.Read())
                                        //    {
                                        //        strNewAgnType = dtRead[0].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    if (Request.QueryString["ChannelCode"].ToString() == "CD")
                                        //    {
                                        //        if (txtUnitCode.Text.StartsWith("RT"))
                                        //        {
                                        //            strNewAgnType = "TM";
                                        //        }
                                        //    }
                                        //    if (strNewAgnType.Trim() != "")
                                        //    {
                                        //        //Added by rachana on 02-07-2013 for Selecting CtrNo start
                                        //        htable.Clear();
                                        //        htable.Add("@flag", "FE");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //        //Added by rachana on 02-07-2013 for Selecting CtrNo end

                                        //        if (dtRead.Read())
                                        //        {
                                        //            ViewState["AgentCode"] = dtRead[0].ToString();
                                        //        }
                                        //        dtRead.Close();

                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@AgentStatus ", "IF");
                                        //        htable.Add("@CustomerId", "90021917");
                                        //        htable.Add("@Exclusive ", "Y");
                                        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@AgentType", strNewAgnType);
                                        //        htable.Add("@AgentClass", "");
                                        //        htable.Add("@PayMethod", "CQ");
                                        //        htable.Add("@Currency ", "INR");
                                        //        htable.Add("@CommCls", "0002");
                                        //        htable.Add("@PayFreq ", "12");
                                        //        htable.Add("@AccPayCode", "");
                                        //        htable.Add("@MinAmt", 0);
                                        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        //        htable.Add("@BEBranchCode", "10");
                                        //        htable.Add("@RecruitAgntCode", "");
                                        //        htable.Add("@BEAreaCode ", "10");
                                        //        htable.Add("@ImmLeader ", "");
                                        //        htable.Add("@BESMCode ", "");
                                        //        htable.Add("@UnitCode ", "");
                                        //        htable.Add("@DateTerminated", System.DBNull.Value);
                                        //        htable.Add("@BlackListStatus", "");
                                        //        htable.Add("@EmployeeCode", "77777777");
                                        //        htable.Add("@MgrCode", strMgrCode);
                                        //        htable.Add("@BizLicsNo", "");
                                        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        //        htable.Add("@DeductTax", "");
                                        //        htable.Add("@TaxCode", "");
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_DummyInsertMgr", htable);
                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@MgrType", strNewAgnType);
                                        //        htable.Add("@DirectMgrType", strAgentType);
                                        //        htable.Add("@DirectMgrCode", strMgrCode);
                                        //        htable.Add("@EMPCode", "77777777");
                                        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_DummyInsertMgr", htable);
                                        //        htable.Clear();
                                        //    }

                                        //}
                                        //else if (MgrCreateRul == "2")
                                        //{
                                        //    //Added by rachana on 05-07-2013 for Selecting CtrNo start

                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                                        //    htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        //    htable.Add("@flag", "rpt");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                                        //    //Added by rachana on 05-07-2013 for Selecting CtrNo end

                                        //    if (dtRead.Read())
                                        //    {
                                        //        strRptUnitCode = dtRead[0].ToString();
                                        //    }
                                        //    dtRead.Close();

                                        //    //Added by rachana on 04-07-2013 for Selecting MgrCode,MgrType start
                                        //    htable.Clear();
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@UnitCode", strRptUnitCode);
                                        //    htable.Add("@LBLUnitCode", "");
                                        //    htable.Add("@LegalName", "");
                                        //    htable.Add("@flag", "SELECTQURY");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting MgrCode,MgrType end

                                        //    if (dtRead.Read())
                                        //    {
                                        //        strMgrCode = dtRead[0].ToString();
                                        //        strAgentType = dtRead[1].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //    decimal intUntRank = 0, NewUntRank = 0;

                                        //    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@CarrierCode", "");
                                        //    htable.Add("@AgentType", strAgentType);
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting UnitRank end


                                        //    if (dtRead.Read())
                                        //    {
                                        //        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //        intUntRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    //Added by rachana on 05-07-2013 for Selecting Top 1 UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitRank", intUntRank);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank end

                                        //    if (dtRead.Read())
                                        //    {
                                        //        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        //        NewUntRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    //added agentlevel 

                                        //    //Added by rachana on 04-07-2013 for Selecting AgentType start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitCode", "");
                                        //    htable.Add("@UnitRank", NewUntRank);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                        //    //Added by rachana on 04-07-2013 for Selecting AgentType end

                                        //    if (dtRead.Read())
                                        //    {
                                        //        strNewAgnType = dtRead[0].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    if (strNewAgnType.Trim() != "")
                                        //    {
                                        //        //Added by rachana on 02-07-2013 for Selecting ctrno start
                                        //        htable.Clear();
                                        //        htable.Add("@flag", "FE");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //        //Added by rachana on 02-07-2013 for Selecting ctrno end
                                        //        if (dtRead.Read())
                                        //        {
                                        //            ViewState["AgentCode"] = dtRead[0].ToString();
                                        //        }
                                        //        dtRead.Close();
                                        //        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        //        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@AgentStatus ", "IF");
                                        //        htable.Add("@CustomerId", "90021917");
                                        //        htable.Add("@Exclusive ", "Y");
                                        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@AgentType", strNewAgnType);
                                        //        htable.Add("@AgentClass", "");
                                        //        htable.Add("@PayMethod", "CQ");
                                        //        htable.Add("@Currency ", "INR");
                                        //        htable.Add("@CommCls", "0002");
                                        //        htable.Add("@PayFreq ", "12");
                                        //        htable.Add("@AccPayCode", "");
                                        //        htable.Add("@MinAmt", 0);
                                        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        //        htable.Add("@BEBranchCode", "10");
                                        //        htable.Add("@RecruitAgntCode", "");
                                        //        htable.Add("@BEAreaCode ", "10");
                                        //        htable.Add("@ImmLeader ", "");
                                        //        htable.Add("@BESMCode ", "");
                                        //        htable.Add("@UnitCode ", "");
                                        //        htable.Add("@DateTerminated", System.DBNull.Value);
                                        //        htable.Add("@BlackListStatus", "");
                                        //        htable.Add("@EmployeeCode", "77777777");
                                        //        htable.Add("@MgrCode", strMgrCode);
                                        //        htable.Add("@BizLicsNo", "");
                                        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        //        htable.Add("@DeductTax", "");
                                        //        htable.Add("@TaxCode", "");
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@MgrType", strNewAgnType);
                                        //        htable.Add("@DirectMgrType", strAgentType);
                                        //        htable.Add("@DirectMgrCode", strMgrCode);
                                        //        htable.Add("@EMPCode", "77777777");
                                        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        //        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                        //        htable.Clear();

                                        //        string strNewBizSrc = "", strNewChnCls = "", strNewAgnType1 = "", strNewAgnType2 = "";

                                        //        //Added by rachana on 05-07-2013 for select agentcode start
                                        //        htable.Clear();
                                        //        htable.Add("@AgentCode", ViewState["AgentCode"].ToString());
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgentMvmtHstData", htable);
                                        //        //Added by rachana on 05-07-2013 for select agentcode end
                                        //        if (dtRead.Read())
                                        //        {
                                        //            strNewBizSrc = dtRead[0].ToString();
                                        //            strNewChnCls = dtRead[1].ToString();
                                        //            strNewAgnType1 = dtRead[2].ToString();
                                        //        }
                                        //        dtRead.Close();
                                        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        //        decimal intNewUnitRank = 0, intUnitRank1 = 0;
                                        //        //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", "");
                                        //        htable.Add("@AgentType", strNewAgnType1);
                                        //        htable.Add("@BizSrc", strNewBizSrc);
                                        //        htable.Add("@ChnCls", strNewChnCls);
                                        //        htable.Add("@flag", "1");
                                        //        dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //        //Added by rachana on 04-07-2013 for Selecting UnitRank end



                                        //        if (dtRead.Read())
                                        //        {
                                        //            //Change of int  to decimal untLvl due to Addition of State in Tied
                                        //            intNewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //        }
                                        //        dtRead.Close();
                                        //        //Added by rachana on 04-07-2013 Select Top 2 UnitRank 
                                        //        htable.Clear();
                                        //        htable.Add("@BizSrc", strNewBizSrc);
                                        //        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        //        htable.Add("@UnitRank", intNewUnitRank);
                                        //        htable.Add("@flag", "2");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //        //Added by rachana on 04-07-2013 Select Top 2 UnitRank end

                                        //        while (dtRead.Read())
                                        //        {
                                        //            //Change of int  to decimal untLvl due to Addition of State in Tied
                                        //            intUnitRank1 = Decimal.Parse(dtRead[0].ToString());
                                        //        }
                                        //        dtRead.Close();

                                        //        if (strNewBizSrc.Trim().ToString() == "AG" || strNewBizSrc.Trim().ToString() == "CN" || strNewBizSrc.Trim().ToString() == "LP" || strNewBizSrc.Trim().ToString() == "PR")//Add Darshik for CN / PR 
                                        //        {
                                        //            strNewAgnType2 = "SM";
                                        //        }
                                        //        else if (strNewBizSrc.Trim().ToString() == "CD")
                                        //        {
                                        //            strNewAgnType2 = "F5";
                                        //        }
                                        //        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@AgentCode ", ViewState["SMAgentCode"].ToString());
                                        //        htable.Add("@AgentStatus ", "IF");
                                        //        htable.Add("@CustomerId", ViewState["strClientCode"].ToString());
                                        //        htable.Add("@Exclusive ", "Y");
                                        //        htable.Add("@AgentName ", "Dummy " + txtUntDesc1.Text);
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        //        htable.Add("@AgentType", strNewAgnType2);
                                        //        htable.Add("@AgentClass", "");
                                        //        htable.Add("@PayMethod", "CQ");
                                        //        htable.Add("@Currency ", "INR");
                                        //        htable.Add("@CommCls", "0002");
                                        //        htable.Add("@PayFreq ", "12");
                                        //        htable.Add("@AccPayCode", "");
                                        //        htable.Add("@MinAmt", 0);
                                        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        //        htable.Add("@BEBranchCode", "10");
                                        //        htable.Add("@RecruitAgntCode", "");
                                        //        htable.Add("@BEAreaCode ", "10");
                                        //        htable.Add("@ImmLeader ", "");
                                        //        htable.Add("@BESMCode ", "");
                                        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        //        htable.Add("@DateTerminated", System.DBNull.Value);
                                        //        htable.Add("@BlackListStatus", "");
                                        //        htable.Add("@EmployeeCode", "77777777");
                                        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@BizLicsNo", "");
                                        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        //        htable.Add("@DeductTax", "");
                                        //        htable.Add("@TaxCode", "");
                                        //        //Commented by rachana 0n 02-07-2013 start
                                        //        htable.Add("@CSCCode", ViewState["strAgentCode"].ToString());
                                        //        //Commented by rachana 0n 02-07-2013 end
                                        //        //htable.Add("@CSCCode", hdnAgentcode.Value); 
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertSM", htable);
                                        //        htable.Clear();
                                        //    }
                                        //}
                                        //else if (MgrCreateRul == "4")
                                        //{
                                        //    Added by rachana on 04-07-2013 for Select MgrCode,MgrType start
                                        //    htable.Clear();
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@UnitCode",ddlReportingUnit.SelectedValue);
                                        //    htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        //    htable.Add("@LBLUnitCode", "");
                                        //    htable.Add("@LegalName", "");
                                        //    htable.Add("@flag", "SELECTQURY");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //    Added on 04-07-2013 for Select MgrCode,MgrType end

                                        //    if (dtRead.Read())
                                        //    {
                                        //        strMgrCode = dtRead[0].ToString();
                                        //        strAgentType = dtRead[1].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    Change of int  to decimal untLvl due to Addition of State in Tied
                                        //    decimal intUnitRank = 0, NewUnitRank = 0;

                                        //    Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@CarrierCode", "");
                                        //    htable.Add("@AgentType", strAgentType);
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //    Added by rachana on 04-07-2013 for Selecting UnitRank end


                                        //    if (dtRead.Read())
                                        //    {
                                        //        Change of int  to decimal untLvl due to Addition of State in Tied
                                        //        intUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    Added by rachana on 05-07-2013 for Select Top 1 UnitRank start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitRank", intUnitRank);
                                        //    htable.Add("@flag", "1");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //    Added by rachana on 04-07-2013 for Select Top 1 UnitRank end 

                                        //    if (dtRead.Read())
                                        //    {
                                        //        Change of int  to decimal untLvl due to Addition of State in Tied
                                        //        NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //    }
                                        //    dtRead.Close();
                                        //    Added by rachana on 05-07-2013 for Select AgentTyp start
                                        //    htable.Clear();
                                        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //    htable.Add("@UnitCode", "");
                                        //    htable.Add("@UnitRank", NewUnitRank);
                                        //    htable.Add("@flag", "2");
                                        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                        //    Added by rachana on 05-07-2013 for Select AgentTyp end


                                        //    if (dtRead.Read())
                                        //    {
                                        //        strNewAgnType = dtRead[0].ToString();
                                        //    }
                                        //    dtRead.Close();
                                        //    if (strNewAgnType.Trim() != "")
                                        //    {
                                        //        Added by rachana on 02-07-2013 for Select CtrNo start
                                        //        htable.Clear();
                                        //        htable.Add("@flag", "FE");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //        Added by rachana on 02-07-2013 for Select CtrNo end

                                        //        if (dtRead.Read())
                                        //        {
                                        //            ViewState["AgentCode"] = dtRead[0].ToString();
                                        //        }
                                        //        dtRead.Close();

                                        //        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@AgentStatus ", "IF");
                                        //        htable.Add("@CustomerId", "90021917");
                                        //        htable.Add("@Exclusive ", "Y");
                                        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@AgentType", strNewAgnType);
                                        //        htable.Add("@AgentClass", "");
                                        //        htable.Add("@PayMethod", "CQ");
                                        //        htable.Add("@Currency ", "INR");
                                        //        htable.Add("@CommCls", "0002");
                                        //        htable.Add("@PayFreq ", "12");
                                        //        htable.Add("@AccPayCode", "");
                                        //        htable.Add("@MinAmt", 0);
                                        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        //        htable.Add("@BEBranchCode", "10");
                                        //        htable.Add("@RecruitAgntCode", "");
                                        //        htable.Add("@BEAreaCode ", "10");
                                        //        htable.Add("@ImmLeader ", "");
                                        //        htable.Add("@BESMCode ", "");
                                        //        htable.Add("@UnitCode ", "");
                                        //        htable.Add("@DateTerminated", System.DBNull.Value);
                                        //        htable.Add("@BlackListStatus", "");
                                        //        htable.Add("@EmployeeCode", "77777777");
                                        //        htable.Add("@MgrCode", strMgrCode);
                                        //        htable.Add("@BizLicsNo", "");
                                        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        //        htable.Add("@DeductTax", "");
                                        //        htable.Add("@TaxCode", "");
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@MgrType", strNewAgnType);
                                        //        htable.Add("@DirectMgrType", strAgentType);
                                        //        htable.Add("@DirectMgrCode", strMgrCode);
                                        //        htable.Add("@EMPCode", "77777777");
                                        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        //        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                        //        htable.Clear();

                                        //        string strNewBizSrc = "", strNewChnCls = "", strNewAgnType1 = "", strNewAgnType2 = "";
                                        //        Added by rachana on 04-07-2013 for all records start
                                        //        htable.Clear();
                                        //        htable.Add("@AgentCode", ViewState["AgentCode"].ToString());
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgentMvmtHstData", htable);
                                        //        Added by rachana on 04-07-2013 for all records start

                                        //        if (dtRead.Read())
                                        //        {
                                        //            strNewBizSrc = dtRead[0].ToString();
                                        //            strNewChnCls = dtRead[1].ToString();
                                        //            strNewAgnType1 = dtRead[2].ToString();
                                        //        }
                                        //        dtRead.Close();
                                        //        Change of int  to decimal untLvl due to Addition of State in Tied
                                        //        decimal intNewUnitRank = 0, intUnitRank1 = 0;
                                        //        Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        //        htable.Clear();
                                        //        htable.Add("@CarrierCode", "");
                                        //        htable.Add("@AgentType", strNewAgnType1);
                                        //        htable.Add("@BizSrc", strNewBizSrc);
                                        //        htable.Add("@ChnCls", strNewChnCls);
                                        //        htable.Add("@flag", "1");
                                        //        dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //        Added by rachana on 04-07-2013 for Selecting UnitRank end


                                        //        if (dtRead.Read())
                                        //        {
                                        //            Change of int  to decimal untLvl due to Addition of State in Tied
                                        //            intNewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        //        }
                                        //        dtRead.Close();
                                        //        Added by rachana on 04-07-2013 for Select CtrNo start
                                        //        htable.Clear();
                                        //        htable.Add("@BizSrc", strNewBizSrc);
                                        //        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        //        htable.Add("@UnitRank", intNewUnitRank);
                                        //        htable.Add("@flag", "3");
                                        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //        Added by rachana on 04-07-2013 for Select CtrNo end
                                        //        if (dtRead.Read())
                                        //        {
                                        //            Change of int  to decimal untLvl due to Addition of State in Tied
                                        //            intUnitRank1 = Decimal.Parse(dtRead[0].ToString());
                                        //        }
                                        //        dtRead.Close();
                                        //        if (strNewBizSrc.Trim().ToString() == "AG" || strNewBizSrc.Trim().ToString() == "CN" || strNewBizSrc.Trim().ToString() == "LP" || strNewBizSrc.Trim().ToString() == "PR") //Add By Darshik for CN / PR
                                        //        {
                                        //            strNewAgnType2 = "SM";
                                        //        }
                                        //        else if (strNewBizSrc.Trim().ToString() == "CD")
                                        //        {
                                        //            strNewAgnType2 = "F5";
                                        //        }

                                        //        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        //        htable.Add("@AgentCode ", ViewState["SMAgentCode"].ToString());
                                        //        htable.Add("@AgentStatus ", "IF");
                                        //        htable.Add("@CustomerId", ViewState["strClientCode"].ToString());
                                        //        htable.Add("@Exclusive ", "Y");
                                        //        htable.Add("@AgentName ", "Dummy " + txtUntDesc1.Text);
                                        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        //        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        //        htable.Add("@AgentType", strNewAgnType2);
                                        //        htable.Add("@AgentClass", "");
                                        //        htable.Add("@PayMethod", "CQ");
                                        //        htable.Add("@Currency ", "INR");
                                        //        htable.Add("@CommCls", "0002");
                                        //        htable.Add("@PayFreq ", "12");
                                        //        htable.Add("@AccPayCode", "");
                                        //        htable.Add("@MinAmt", 0);
                                        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        //        htable.Add("@BEBranchCode", "10");
                                        //        htable.Add("@RecruitAgntCode", "");
                                        //        htable.Add("@BEAreaCode ", "10");
                                        //        htable.Add("@ImmLeader ", "");
                                        //        htable.Add("@BESMCode ", "");
                                        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        //        htable.Add("@DateTerminated", System.DBNull.Value);
                                        //        htable.Add("@BlackListStatus", "");
                                        //        htable.Add("@EmployeeCode", "77777777");
                                        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        //        htable.Add("@BizLicsNo", "");
                                        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        //        htable.Add("@DeductTax", "");
                                        //        htable.Add("@TaxCode", "");
                                        //        htable.Add("@CSCCode", ViewState["strAgentCode"].ToString());
                                        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertSM", htable);
                                        //        htable.Clear();
                                        //    }

                                        //}





                                        if (txtUnitCode.Visible == true)
                                        {
                                            UnitCode = txtUnitCode.Text;
                                        }
                                        else
                                        {
                                            UnitCode = lblUnitCode.Text;
                                        }

                                        string SalesUnit;
                                        if (rdlYesNo.SelectedValue == "Y")
                                        {
                                            SalesUnit = "True";
                                        }
                                        else
                                        {
                                            SalesUnit = "False";
                                        }


                                        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                        //htable.Add("@RptUnitCode", ddlReportingUnit.SelectedValue);
                                        //htable.Add("@RptUnitCode", txtUnitCode.Text);
                                        //Change of int  to decimal untLvl due to Addition of State in Tied

                                        htable.Add("@UnitLevel", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                                        htable.Add("@UnitCode", UnitCode);
                                        htable.Add("@UnitDescTha", "");
                                        htable.Add("@UnitDescEng", txtUntDesc1.Text);
                                        htable.Add("@GeoRegionChs", "");
                                        htable.Add("@GeoRegionEng", "");
                                        htable.Add("@UnitMgrCode", txtUnitMGRCode.Text);
                                        htable.Add("@UnitStatus", ddlUnitStat.SelectedValue);
                                        htable.Add("@UnitType", ddlUnitType.SelectedValue);

                                        htable.Add("@WorkTel", txtOTel.Text);
                                        htable.Add("@WorkFax", txtFax.Text);
                                        htable.Add("@Email", txtEMail.Text);
                                        htable.Add("@Remark", txtRemark.Text);
                                        htable.Add("@cboBizsrc", Request.QueryString["ChannelCode"]);
                                        htable.Add("@oldBizsrc", Request.QueryString["ChannelCode"]);
                                        htable.Add("@UserId", "");
                                        htable.Add("@UserName", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@GeoRegion", "");
                                        htable.Add("@Action", Request.QueryString["flag"]);
                                        htable.Add("@IsSlsUnit", SalesUnit);

                                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                        htable.Add("@UnitName", DdlUnitName.SelectedValue);
                                        htable.Add("@AgentName", DdlAgntName.SelectedValue);
                                        htable.Add("@LinkUnitChannel", LblSlschannel.Text); //Added by Kalyani on 11-12-13 
                                        htable.Add("@LinkUnitChncls", LblChannelSubclass.Text); //Added by Kalyani on 11-12-13 
                                        htable.Add("@LinkStaffChannel", lbluntSalesChnlDesc.Text);//Added by Kalyani on 11-12-13 
                                        htable.Add("@LinkStaffChncls", lbluntSubChnlDesc.Text);//Added by Kalyani on 11-12-13 
                                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end


                                        if (txtSALocCode.Visible == true)
                                        {
                                            htable.Add("@SALocCode", txtSALocCode.Text);
                                        }
                                        else
                                        {
                                            htable.Add("@SALocCode", "");
                                        }
                                        if (txtCompanyUnitCode.Visible == true)
                                        {
                                            htable.Add("@CmpUnitCode", txtCompanyUnitCode.Text);
                                        }
                                        else
                                        {
                                            htable.Add("@CmpUnitCode", "");
                                        }
                                        htable.Add("@UnitDesc01", txtUntDesc1.Text);
                                        htable.Add("@UnitDesc02", txtUntDesc2.Text);
                                        htable.Add("@UnitDesc03", txtUntDesc3.Text);
                                        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        htable.Add("@UnitRank", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        if (txtSMCount.Visible == true)
                                        {
                                            htable.Add("@SMCount", txtSMCount.Text);
                                        }
                                        else
                                        {
                                            htable.Add("@SMCount", System.DBNull.Value);
                                        }
                                        if (txtPCCode.Visible == true)
                                        {
                                            htable.Add("@RegistrationNo", txtPCCode.Text);
                                        }
                                        else
                                        {
                                            htable.Add("@RegistrationNo", System.DBNull.Value);
                                        }

                                        //Added by swapnesh on 10/02/2014 to insert new details of unit start
                                        htable.Add("@InsRefCode", txtInsRefCode.Text.Trim());

                                        #region Address
                                        htable.Add("@AddressLine1", txtAddrP1.Text);
                                        htable.Add("@AddressLine2", txtAddrP2.Text);
                                        htable.Add("@AddressLine3", txtAddrP3.Text);
                                        htable.Add("@Village", txtVillage.Text.Trim());
                                        htable.Add("@City", txtcityp.Text);
                                        htable.Add("@State", ddlState.SelectedValue);
                                        htable.Add("@Dist", txtDistP.Text.Trim());
                                        htable.Add("@Area", txtarea.Text.Trim());
                                        htable.Add("@PostCode", txtPinP.Text);
                                        htable.Add("@Country", txtCountryCodeP.Text.Trim());
                                        #endregion

                                        #region Location
                                        htable.Add("@Latitude", txtLatitude.Text.Trim());
                                        htable.Add("@Longitude", txtLongitude.Text.Trim());
                                        #endregion

                                        #region Reporting Manager
                                        if (tblUnitRptType.Visible != false)
                                        {
                                            #region Primary Reporting
                                            htable.Add("@PriRptTyp", ddlreportingtype.SelectedValue);
                                            htable.Add("@PriBasedOn", ddlbasedon.SelectedValue);
                                            htable.Add("@PriChnl", ddlchannel.SelectedValue);
                                            htable.Add("@PriSubChnl", ddlsubchannel.SelectedValue);
                                            htable.Add("@PriUntTyp", ddllevelagttype.SelectedValue);
                                            htable.Add("@RptUnitCode", hdnRptUntCode.Value);
                                            #endregion

                                            if (tblMgr1.Visible != false)
                                            {
                                                htable.Add("@MgrRptTyp1", ddlam1reportingtype.SelectedValue);
                                                htable.Add("@MgrBasedOn1", ddlam1basedon.SelectedValue);
                                                htable.Add("@MgrChnl1", ddlam1channel.SelectedValue);
                                                htable.Add("@MgrSubChnl1", ddlam1subchannel.SelectedValue);
                                                htable.Add("@MgrUntTyp1", ddlam1levelagttype.SelectedValue);
                                                htable.Add("@MgrUnitCode1", hdnRptUntCodeMgr1.Value);
                                            }
                                        }
                                        #endregion

                                        //Additional Detail start 22-02-2022
                                        
                                        //htable.Add("@Addl2ReptRule", "");
                                        //htable.Add("@Addl2ReptTyp", ddlam2reportingtype.SelectedValue);
                                        //htable.Add("@Addl2BsdOn", ddlam2basedon.SelectedValue);
                                        //htable.Add("@Addl2Channel", ddlam2channel.SelectedValue);
                                        //htable.Add("@Addl2SubChannel", ddlam2subchannel.SelectedValue);
                                        //htable.Add("@Addl2LvlAgtTyp", ddlam2levelagttype.SelectedValue);


                                        //Additional Detail end 22-02-2022

                                        ArrayList arrLst = new ArrayList();
                                        if (Request.QueryString["flag"] == "add")
                                        {
                                            arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                                            arrLst.Add(new prjXml.Collection("UnitCode", txtUnitCode.Text));
                                            arrLst.Add(new prjXml.Collection("BizSrc", lblSalesChannel.Text));
                                            arrLst.Add(new prjXml.Collection("ChnCls", ddlChnnlSubClass.SelectedValue));
                                            arrLst.Add(new prjXml.Collection("SalesUnit", SalesUnit));
                                            arrLst.Add(new prjXml.Collection("UnitCode", UnitCode));
                                            arrLst.Add(new prjXml.Collection("UnitDescEng", txtUntDesc1.Text));
                                            arrLst.Add(new prjXml.Collection("UnitMgrCode", txtUnitMGRCode.Text));
                                            arrLst.Add(new prjXml.Collection("UnitStatus", ddlUnitStat.SelectedValue));
                                            arrLst.Add(new prjXml.Collection("UnitType", ddlUnitType.SelectedValue));
                                            arrLst.Add(new prjXml.Collection("AddressLine1", txtAddress1.Text));
                                            arrLst.Add(new prjXml.Collection("AddressLine2", txtAddress2.Text));
                                            arrLst.Add(new prjXml.Collection("AddressLine3", txtAddress3.Text));
                                            arrLst.Add(new prjXml.Collection("PostCode", txtPOstCode.Text));
                                            arrLst.Add(new prjXml.Collection("City", txtCity.Text));
                                            arrLst.Add(new prjXml.Collection("WorkTel", txtOTel.Text));
                                            arrLst.Add(new prjXml.Collection("WorkFax", txtFax.Text));
                                            arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));
                                            arrLst.Add(new prjXml.Collection("Remark", txtRemark.Text));
                                            arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));
                                            //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                            arrLst.Add(new prjXml.Collection("UnitName", DdlUnitName.SelectedValue));
                                            arrLst.Add(new prjXml.Collection("AgentName", DdlAgntName.SelectedValue));
                                            arrLst.Add(new prjXml.Collection("LinkUnitChannel", LblSlschannel.Text));//Added by Kalyani on 11-12-13 
                                            arrLst.Add(new prjXml.Collection("LinkUnitChncls", LblChannelSubclass.Text));//Added by Kalyani on 11-12-13 
                                            arrLst.Add(new prjXml.Collection("LinkStaffChannel", lbluntSalesChnlDesc.Text));//Added by Kalyani on 11-12-13
                                            arrLst.Add(new prjXml.Collection("LinkStaffChncls", lbluntSubChnlDesc.Text));//Added by Kalyani on 11-12-13
                                            // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end
                                        }

                                        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                                        XmlDocument xDoc = new XmlDocument();
                                        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                                        strXML = xDoc.OuterXml;

                                        arrLst.Clear();
                                        arrResult = channelsetup.UnitMaintUpdate(htable, "prc_AgyAdmin_UpdUnitMaintWithOUTParam");
                                        htable.Clear();
                                        if (arrResult.Count > 0)
                                        {
                                            if (arrResult[0].ToString() != "F")
                                            {
                                                if (arrResult.Count > 0)
                                                {
                                                    if (arrResult[0].ToString().Equals("0"))
                                                    {
                                                        //Added by swapnesh on 28/5/2013 for showing message box start
                                                        // lbl3.Visible = true;
                                                        //lblmsg.Text = "Admin Unit Maintenance done successfully";
                                                        //lbl3.Text = "Admin Unit Maintenance done successfully";
                                                        //lbl4.Text = "Unit Code : " + txtUnitCode.Text;
                                                        //lbl5.Text = "Unit Description : " + txtUntDesc1.Text;
                                                        lbl_popup.Text = "Admin Unit Maintenance done successfully" + "</br></br> Unit Code :  " + txtUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                                                        // mdlpopup.Show();
                                                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                                        //Added by swapnesh on 28/5/2013 for showing message box end
                                                        lblmsg.ForeColor = Color.Red;
                                                        lblmsg.Visible = true;
                                                        btnUpdate.Enabled = false;
                                                        if (ViewState["strAgentCode"] != null)
                                                        {
                                                            lblCSCCodeLA.Visible = true;
                                                            lblCSCCode.Visible = true;
                                                            lblCSCCode.Text = ViewState["strAgentCode"].ToString();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        switch (arrResult[0].ToString())
                                                        {
                                                            case "-1": lblmsg.Text = "Unit Code Not Exist";
                                                                break;
                                                            case "-2": lblmsg.Text = "Unit Code Already Exist";
                                                                break;
                                                            case "-3": lblmsg.Text = "System Error! Unit Client Code cannot generated";
                                                                break;
                                                            case "-4": lblmsg.Text = "Please enter valid Unit Manager Code";
                                                                break;
                                                            case "-5": lblmsg.Text = "Unit Manager Agent Type must be Unit Manager and above";
                                                                break;
                                                            case "-6": lblmsg.Text = "Unit Manager Agent Type must be Senior Agency Manager and above";
                                                                break;
                                                            case "-7": lblmsg.Text = "Senior Agency Manager is not allow manage more than 1 unit";
                                                                break;
                                                            case "-8": lblmsg.Text = "Please enter valid Company Unit Code";
                                                                break;
                                                            default: lblmsg.Text = "System Error";
                                                                break;
                                                        }
                                                        lblmsg.ForeColor = Color.Red;
                                                        lblmsg.Visible = true;
                                                        ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblmsg.Text + "');</script>", false);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lblmsg.Text = arrResult[1].ToString();
                                                lblmsg.ForeColor = Color.Red;
                                                lblmsg.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            lblmsg.Text = "Error Updating Agent Details.";
                                            lblmsg.ForeColor = Color.Red;
                                            lblmsg.Visible = true;
                                        }

                                        //Added by swapnesh on 15/5/2013 to change lblmsg text start
                                        lblmsg.Text = "Admin Unit Maintenance done successfully";
                                        //Added by swapnesh on 15/5/2013 to change lblmsg text end

                                        lblmsg.ForeColor = Color.Red;
                                        lblmsg.Visible = true;
                                        btnUpdate.Enabled = false;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = strErrMsg;
                                    ViewState["ErrorMsg"] = strErrMsg;
                                    btnUpdate.Enabled = false;
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Unit Code Already Exist";
                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Visible = true;
                            }

                        }
                        else
                        {
                            string MgrCreateRul = "";
                            //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                            htable.Clear();
                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                            //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

                            if (dtRead.Read())
                            {
                                MgrCreateRul = dtRead[0].ToString();
                            }
                            dtRead.Close();
                            if (Request.QueryString["flag"] == "add")
                            {
                                //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                                htable.Clear();
                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                                //Added by rachana on 03-07-2013 Selecting MgrCreateRul end

                                if (dtRead.Read())
                                {
                                    MgrCreateRul = dtRead[0].ToString();
                                }
                                dtRead.Close();
                                if (MgrCreateRul == "1")
                                {
                                    //added For Dummy RS Creation
                                    if (ddlChnnlSubClass.SelectedValue == "AGAM" && ddlUnitType.SelectedValue == "SO")
                                    {
                                        //Added on 04-07-2013 for Select MgrCode,MgrType start
                                        htable.Clear();
                                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        htable.Add("@ChnCls", "");
                                        //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                                        htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        htable.Add("@LBLUnitCode", "");
                                        htable.Add("@LegalName", "");
                                        htable.Add("@flag", "SELECTQURY");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //Added by rachana on 05-07-2013 for Select MgrCode,MgrType end
                                    }
                                    else
                                    //end
                                    {
                                        //Added on 04-07-2013 for Select MgrCode,MgrType start
                                        htable.Clear();
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        //htable.Add("@UnitCode",ddlReportingUnit.SelectedValue);
                                        htable.Add("@UnitCode", hdnRptUntCode.Value);
                                        htable.Add("@LBLUnitCode", "");
                                        htable.Add("@LegalName", "");
                                        htable.Add("@flag", "SELECTQURY");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                        //Added on 04-07-2013 for Select MgrCode,MgrType end

                                    }
                                    if (dtRead.Read())
                                    {
                                        strMgrCode = dtRead[0].ToString();
                                        strAgentType = dtRead[1].ToString();
                                    }
                                    dtRead.Close();
                                    //Change of int  to decimal unitrank due to Addition of State in Tied
                                    decimal intUnitRank = 0, NewUnitRank = 0;
                                    //Added by rachana on 04-07-2013 Selecting UnitRank start
                                    htable.Clear();
                                    htable.Add("@CarrierCode", "");
                                    htable.Add("@AgentType", strAgentType);
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                    //Added by rachana on 04-07-2013 for Selecting UnitRank end
                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        intUnitRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitRank", intUnitRank);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank end                                               


                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //added agentlevel 

                                    //Added by rachana on 04-07-2013 for Select AgentType  start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitCode", "");
                                    htable.Add("@UnitRank", NewUnitRank);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                    //Added by rachana on 04-07-2013 for Select AgentType  end



                                    if (dtRead.Read())
                                    {
                                        strNewAgnType = dtRead[0].ToString();
                                    }
                                    dtRead.Close();
                                    if (Request.QueryString["ChannelCode"].ToString() == "CD")
                                    {
                                        if (txtUnitCode.Text.StartsWith("RT"))
                                        {
                                            strNewAgnType = "TM";
                                        }
                                    }
                                    if (strNewAgnType.Trim() != "")
                                    {
                                        //Added by rachana on 02-07-2013 for Selecting CtrNo start
                                        htable.Clear();
                                        htable.Add("@flag", "FE");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for Selecting CtrNo end

                                        if (dtRead.Read())
                                        {
                                            ViewState["AgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();

                                        htable.Clear();
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        htable.Add("@AgentStatus ", "IF");
                                        htable.Add("@CustomerId", "90021917");
                                        htable.Add("@Exclusive ", "Y");
                                        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@AgentType", strNewAgnType);
                                        htable.Add("@AgentClass", "");
                                        htable.Add("@PayMethod", "CQ");
                                        htable.Add("@Currency ", "INR");
                                        htable.Add("@CommCls", "0002");
                                        htable.Add("@PayFreq ", "12");
                                        htable.Add("@AccPayCode", "");
                                        htable.Add("@MinAmt", 0);
                                        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        htable.Add("@BEBranchCode", "10");
                                        htable.Add("@RecruitAgntCode", "");
                                        htable.Add("@BEAreaCode ", "10");
                                        htable.Add("@ImmLeader ", "");
                                        htable.Add("@BESMCode ", "");
                                        htable.Add("@UnitCode ", "");
                                        htable.Add("@DateTerminated", System.DBNull.Value);
                                        htable.Add("@BlackListStatus", "");
                                        htable.Add("@EmployeeCode", "77777777");
                                        htable.Add("@MgrCode", strMgrCode);
                                        htable.Add("@BizLicsNo", "");
                                        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        htable.Add("@DeductTax", "");
                                        htable.Add("@TaxCode", "");
                                        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                                        htable.Clear();
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        htable.Add("@MgrType", strNewAgnType);
                                        htable.Add("@DirectMgrType", strAgentType);
                                        htable.Add("@DirectMgrCode", strMgrCode);
                                        htable.Add("@EMPCode", "77777777");
                                        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                        htable.Clear();
                                    }

                                }
                                else if (MgrCreateRul == "2")
                                {
                                    //Added by rachana on 05-07-2013 for Selecting CtrNo start

                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                                    htable.Add("@UnitCode", hdnRptUntCode.Value);
                                    htable.Add("@flag", "rpt");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                                    //Added by rachana on 05-07-2013 for Selecting CtrNo end

                                    if (dtRead.Read())
                                    {
                                        strRptUnitCode = dtRead[0].ToString();
                                    }
                                    dtRead.Close();

                                    //Added by rachana on 04-07-2013 for Selecting MgrCode,MgrType start
                                    htable.Clear();
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@UnitCode", strRptUnitCode);
                                    htable.Add("@LBLUnitCode", "");
                                    htable.Add("@LegalName", "");
                                    htable.Add("@flag", "SELECTQURY");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                    //Added by rachana on 04-07-2013 for Selecting MgrCode,MgrType end

                                    if (dtRead.Read())
                                    {
                                        strMgrCode = dtRead[0].ToString();
                                        strAgentType = dtRead[1].ToString();
                                    }
                                    dtRead.Close();
                                    //Change of int  to decimal unitrank due to Addition of State in Tied
                                    decimal intUntRank = 0, NewUntRank = 0;

                                    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                    htable.Clear();
                                    htable.Add("@CarrierCode", "");
                                    htable.Add("@AgentType", strAgentType);
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                    //Added by rachana on 04-07-2013 for Selecting UnitRank end


                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        intUntRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //Added by rachana on 05-07-2013 for Selecting Top 1 UnitRank start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitRank", intUntRank);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                    //Added by rachana on 04-07-2013 for Selecting Top 1 UnitRank end

                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal unitrank due to Addition of State in Tied
                                        NewUntRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //added agentlevel 

                                    //Added by rachana on 04-07-2013 for Selecting AgentType start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitCode", "");
                                    htable.Add("@UnitRank", NewUntRank);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                    //Added by rachana on 04-07-2013 for Selecting AgentType end

                                    if (dtRead.Read())
                                    {
                                        strNewAgnType = dtRead[0].ToString();
                                    }
                                    dtRead.Close();
                                    if (strNewAgnType.Trim() != "")
                                    {
                                        //Added by rachana on 02-07-2013 for Selecting ctrno start
                                        htable.Clear();
                                        htable.Add("@flag", "FE");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for Selecting ctrno end
                                        if (dtRead.Read())
                                        {
                                            ViewState["AgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 02-07-2013 for updating ctrno by using same proc Prc_GetCtrNoforunitmaint start
                                        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        htable.Add("@AgentStatus ", "IF");
                                        htable.Add("@CustomerId", "90021917");
                                        htable.Add("@Exclusive ", "Y");
                                        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@AgentType", strNewAgnType);
                                        htable.Add("@AgentClass", "");
                                        htable.Add("@PayMethod", "CQ");
                                        htable.Add("@Currency ", "INR");
                                        htable.Add("@CommCls", "0002");
                                        htable.Add("@PayFreq ", "12");
                                        htable.Add("@AccPayCode", "");
                                        htable.Add("@MinAmt", 0);
                                        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        htable.Add("@BEBranchCode", "10");
                                        htable.Add("@RecruitAgntCode", "");
                                        htable.Add("@BEAreaCode ", "10");
                                        htable.Add("@ImmLeader ", "");
                                        htable.Add("@BESMCode ", "");
                                        htable.Add("@UnitCode ", "");
                                        htable.Add("@DateTerminated", System.DBNull.Value);
                                        htable.Add("@BlackListStatus", "");
                                        htable.Add("@EmployeeCode", "77777777");
                                        htable.Add("@MgrCode", strMgrCode);
                                        htable.Add("@BizLicsNo", "");
                                        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        htable.Add("@DeductTax", "");
                                        htable.Add("@TaxCode", "");
                                        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                                        htable.Clear();
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        htable.Add("@MgrType", strNewAgnType);
                                        htable.Add("@DirectMgrType", strAgentType);
                                        htable.Add("@DirectMgrCode", strMgrCode);
                                        htable.Add("@EMPCode", "77777777");
                                        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                        htable.Clear();

                                        string strNewBizSrc = "", strNewChnCls = "", strNewAgnType1 = "", strNewAgnType2 = "";

                                        //Added by rachana on 05-07-2013 for select agentcode start
                                        htable.Clear();
                                        htable.Add("@AgentCode", ViewState["AgentCode"].ToString());
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgentMvmtHstData", htable);
                                        //Added by rachana on 05-07-2013 for select agentcode end
                                        if (dtRead.Read())
                                        {
                                            strNewBizSrc = dtRead[0].ToString();
                                            strNewChnCls = dtRead[1].ToString();
                                            strNewAgnType1 = dtRead[2].ToString();
                                        }
                                        dtRead.Close();
                                        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        decimal intNewUnitRank = 0, intUnitRank1 = 0;
                                        //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        htable.Clear();
                                        htable.Add("@CarrierCode", "");
                                        htable.Add("@AgentType", strNewAgnType1);
                                        htable.Add("@BizSrc", strNewBizSrc);
                                        htable.Add("@ChnCls", strNewChnCls);
                                        htable.Add("@flag", "1");
                                        dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //Added by rachana on 04-07-2013 for Selecting UnitRank end



                                        if (dtRead.Read())
                                        {
                                            //Change of int  to decimal untLvl due to Addition of State in Tied
                                            intNewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 04-07-2013 Select Top 2 UnitRank 
                                        htable.Clear();
                                        htable.Add("@BizSrc", strNewBizSrc);
                                        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        htable.Add("@UnitRank", intNewUnitRank);
                                        htable.Add("@flag", "2");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //Added by rachana on 04-07-2013 Select Top 2 UnitRank end

                                        while (dtRead.Read())
                                        {
                                            //Change of int  to decimal untLvl due to Addition of State in Tied
                                            intUnitRank1 = Decimal.Parse(dtRead[0].ToString());
                                        }
                                        dtRead.Close();

                                        if (strNewBizSrc.Trim().ToString() == "AG" || strNewBizSrc.Trim().ToString() == "CN" || strNewBizSrc.Trim().ToString() == "LP" || strNewBizSrc.Trim().ToString() == "PR")//Add Darshik for CN / PR 
                                        {
                                            strNewAgnType2 = "SM";
                                        }
                                        else if (strNewBizSrc.Trim().ToString() == "CD")
                                        {
                                            strNewAgnType2 = "F5";
                                        }
                                        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@AgentCode ", ViewState["SMAgentCode"].ToString());
                                        htable.Add("@AgentStatus ", "IF");
                                        htable.Add("@CustomerId", ViewState["strClientCode"].ToString());
                                        htable.Add("@Exclusive ", "Y");
                                        htable.Add("@AgentName ", "Dummy " + txtUntDesc1.Text);
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        htable.Add("@AgentType", strNewAgnType2);
                                        htable.Add("@AgentClass", "");
                                        htable.Add("@PayMethod", "CQ");
                                        htable.Add("@Currency ", "INR");
                                        htable.Add("@CommCls", "0002");
                                        htable.Add("@PayFreq ", "12");
                                        htable.Add("@AccPayCode", "");
                                        htable.Add("@MinAmt", 0);
                                        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        htable.Add("@BEBranchCode", "10");
                                        htable.Add("@RecruitAgntCode", "");
                                        htable.Add("@BEAreaCode ", "10");
                                        htable.Add("@ImmLeader ", "");
                                        htable.Add("@BESMCode ", "");
                                        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        htable.Add("@DateTerminated", System.DBNull.Value);
                                        htable.Add("@BlackListStatus", "");
                                        htable.Add("@EmployeeCode", "77777777");
                                        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        htable.Add("@BizLicsNo", "");
                                        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        htable.Add("@DeductTax", "");
                                        htable.Add("@TaxCode", "");
                                        //Commented by rachana 0n 02-07-2013 start
                                        htable.Add("@CSCCode", ViewState["strAgentCode"].ToString());
                                        //Commented by rachana 0n 02-07-2013 end
                                        //htable.Add("@CSCCode", hdnAgentcode.Value); 
                                        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertSM", htable);
                                        htable.Clear();
                                    }
                                }
                                else if (MgrCreateRul == "4")
                                {
                                    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType start
                                    htable.Clear();
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    //htable.Add("@UnitCode",ddlReportingUnit.SelectedValue);
                                    htable.Add("@UnitCode", hdnRptUntCode.Value);
                                    htable.Add("@LBLUnitCode", "");
                                    htable.Add("@LegalName", "");
                                    htable.Add("@flag", "SELECTQURY");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                    //Added on 04-07-2013 for Select MgrCode,MgrType end

                                    if (dtRead.Read())
                                    {
                                        strMgrCode = dtRead[0].ToString();
                                        strAgentType = dtRead[1].ToString();
                                    }
                                    dtRead.Close();
                                    //Change of int  to decimal untLvl due to Addition of State in Tied
                                    decimal intUnitRank = 0, NewUnitRank = 0;

                                    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                    htable.Clear();
                                    htable.Add("@CarrierCode", "");
                                    htable.Add("@AgentType", strAgentType);
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                    //Added by rachana on 04-07-2013 for Selecting UnitRank end


                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        intUnitRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //Added by rachana on 05-07-2013 for Select Top 1 UnitRank start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitRank", intUnitRank);
                                    htable.Add("@flag", "1");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank end 

                                    if (dtRead.Read())
                                    {
                                        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                    }
                                    dtRead.Close();
                                    //Added by rachana on 05-07-2013 for Select AgentTyp start
                                    htable.Clear();
                                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                    htable.Add("@UnitCode", "");
                                    htable.Add("@UnitRank", NewUnitRank);
                                    htable.Add("@flag", "2");
                                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                                    //Added by rachana on 05-07-2013 for Select AgentTyp end


                                    if (dtRead.Read())
                                    {
                                        strNewAgnType = dtRead[0].ToString();
                                    }
                                    dtRead.Close();
                                    if (strNewAgnType.Trim() != "")
                                    {
                                        //Added by rachana on 02-07-2013 for Select CtrNo start
                                        htable.Clear();
                                        htable.Add("@flag", "FE");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                                        //Added by rachana on 02-07-2013 for Select CtrNo end

                                        if (dtRead.Read())
                                        {
                                            ViewState["AgentCode"] = dtRead[0].ToString();
                                        }
                                        dtRead.Close();

                                        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                        htable.Add("@AgentStatus ", "IF");
                                        htable.Add("@CustomerId", "90021917");
                                        htable.Add("@Exclusive ", "Y");
                                        htable.Add("@AgentName ", txtUntDesc1.Text);
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@AgentType", strNewAgnType);
                                        htable.Add("@AgentClass", "");
                                        htable.Add("@PayMethod", "CQ");
                                        htable.Add("@Currency ", "INR");
                                        htable.Add("@CommCls", "0002");
                                        htable.Add("@PayFreq ", "12");
                                        htable.Add("@AccPayCode", "");
                                        htable.Add("@MinAmt", 0);
                                        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        htable.Add("@BEBranchCode", "10");
                                        htable.Add("@RecruitAgntCode", "");
                                        htable.Add("@BEAreaCode ", "10");
                                        htable.Add("@ImmLeader ", "");
                                        htable.Add("@BESMCode ", "");
                                        htable.Add("@UnitCode ", "");
                                        htable.Add("@DateTerminated", System.DBNull.Value);
                                        htable.Add("@BlackListStatus", "");
                                        htable.Add("@EmployeeCode", "77777777");
                                        htable.Add("@MgrCode", strMgrCode);
                                        htable.Add("@BizLicsNo", "");
                                        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        htable.Add("@DeductTax", "");
                                        htable.Add("@TaxCode", "");
                                        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                                        htable.Clear();
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        htable.Add("@MgrType", strNewAgnType);
                                        htable.Add("@DirectMgrType", strAgentType);
                                        htable.Add("@DirectMgrCode", strMgrCode);
                                        htable.Add("@EMPCode", "77777777");
                                        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                        htable.Clear();

                                        string strNewBizSrc = "", strNewChnCls = "", strNewAgnType1 = "", strNewAgnType2 = "";
                                        //Added by rachana on 04-07-2013 for all records start
                                        htable.Clear();
                                        htable.Add("@AgentCode", ViewState["AgentCode"].ToString());
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgentMvmtHstData", htable);
                                        //Added by rachana on 04-07-2013 for all records start

                                        if (dtRead.Read())
                                        {
                                            strNewBizSrc = dtRead[0].ToString();
                                            strNewChnCls = dtRead[1].ToString();
                                            strNewAgnType1 = dtRead[2].ToString();
                                        }
                                        dtRead.Close();
                                        //Change of int  to decimal untLvl due to Addition of State in Tied
                                        decimal intNewUnitRank = 0, intUnitRank1 = 0;
                                        //Added by rachana on 04-07-2013 for Selecting UnitRank start
                                        htable.Clear();
                                        htable.Add("@CarrierCode", "");
                                        htable.Add("@AgentType", strNewAgnType1);
                                        htable.Add("@BizSrc", strNewBizSrc);
                                        htable.Add("@ChnCls", strNewChnCls);
                                        htable.Add("@flag", "1");
                                        dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                                        //Added by rachana on 04-07-2013 for Selecting UnitRank end


                                        if (dtRead.Read())
                                        {
                                            //Change of int  to decimal untLvl due to Addition of State in Tied
                                            intNewUnitRank = Decimal.Parse(dtRead[0].ToString());
                                        }
                                        dtRead.Close();
                                        //Added by rachana on 04-07-2013 for Select CtrNo start
                                        htable.Clear();
                                        htable.Add("@BizSrc", strNewBizSrc);
                                        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        htable.Add("@UnitRank", intNewUnitRank);
                                        htable.Add("@flag", "3");
                                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                                        //Added by rachana on 04-07-2013 for Select CtrNo end
                                        if (dtRead.Read())
                                        {
                                            //Change of int  to decimal untLvl due to Addition of State in Tied
                                            intUnitRank1 = Decimal.Parse(dtRead[0].ToString());
                                        }
                                        dtRead.Close();
                                        if (strNewBizSrc.Trim().ToString() == "AG" || strNewBizSrc.Trim().ToString() == "CN" || strNewBizSrc.Trim().ToString() == "LP" || strNewBizSrc.Trim().ToString() == "PR") //Add By Darshik for CN / PR
                                        {
                                            strNewAgnType2 = "SM";
                                        }
                                        else if (strNewBizSrc.Trim().ToString() == "CD")
                                        {
                                            strNewAgnType2 = "F5";
                                        }

                                        htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                        htable.Add("@AgentCode ", ViewState["SMAgentCode"].ToString());
                                        htable.Add("@AgentStatus ", "IF");
                                        htable.Add("@CustomerId", ViewState["strClientCode"].ToString());
                                        htable.Add("@Exclusive ", "Y");
                                        htable.Add("@AgentName ", "Dummy " + txtUntDesc1.Text);
                                        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                        htable.Add("@ChnCls", ViewState["ChnCls"].ToString());
                                        htable.Add("@AgentType", strNewAgnType2);
                                        htable.Add("@AgentClass", "");
                                        htable.Add("@PayMethod", "CQ");
                                        htable.Add("@Currency ", "INR");
                                        htable.Add("@CommCls", "0002");
                                        htable.Add("@PayFreq ", "12");
                                        htable.Add("@AccPayCode", "");
                                        htable.Add("@MinAmt", 0);
                                        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                        htable.Add("@RecruitDate ", System.DBNull.Value);
                                        htable.Add("@BEBranchCode", "10");
                                        htable.Add("@RecruitAgntCode", "");
                                        htable.Add("@BEAreaCode ", "10");
                                        htable.Add("@ImmLeader ", "");
                                        htable.Add("@BESMCode ", "");
                                        htable.Add("@UnitCode ", txtUnitCode.Text);
                                        htable.Add("@DateTerminated", System.DBNull.Value);
                                        htable.Add("@BlackListStatus", "");
                                        htable.Add("@EmployeeCode", "77777777");
                                        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                        htable.Add("@BizLicsNo", "");
                                        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                        htable.Add("@DeductTax", "");
                                        htable.Add("@TaxCode", "");
                                        htable.Add("@CSCCode", ViewState["strAgentCode"].ToString());
                                        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertSM", htable);
                                        htable.Clear();
                                    }

                                }





                                if (txtUnitCode.Visible == true)
                                {
                                    UnitCode = txtUnitCode.Text;
                                }
                                else
                                {
                                    UnitCode = lblUnitCode.Text;
                                }

                                string SalesUnit;
                                if (rdlYesNo.SelectedValue == "Y")
                                {
                                    SalesUnit = "True";
                                }
                                else
                                {
                                    SalesUnit = "False";
                                }


                                htable.Clear();//Added by rachana on 02-07-2013 to clear hashtable
                                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                //htable.Add("@RptUnitCode", ddlReportingUnit.SelectedValue);
                                //htable.Add("@RptUnitCode", txtUnitCode.Text);
                                //Change of int  to decimal untLvl due to Addition of State in Tied

                                htable.Add("@UnitLevel", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                                htable.Add("@UnitCode", UnitCode);
                                htable.Add("@UnitDescTha", "");
                                htable.Add("@UnitDescEng", txtUntDesc1.Text);
                                htable.Add("@GeoRegionChs", "");
                                htable.Add("@GeoRegionEng", "");
                                htable.Add("@UnitMgrCode", txtUnitMGRCode.Text);
                                htable.Add("@UnitStatus", ddlUnitStat.SelectedValue);
                                htable.Add("@UnitType", ddlUnitType.SelectedValue);

                                htable.Add("@WorkTel", txtOTel.Text);
                                htable.Add("@WorkFax", txtFax.Text);
                                htable.Add("@Email", txtEMail.Text);
                                htable.Add("@Remark", txtRemark.Text);
                                htable.Add("@cboBizsrc", Request.QueryString["ChannelCode"]);
                                htable.Add("@oldBizsrc", Request.QueryString["ChannelCode"]);
                                htable.Add("@UserId", "");
                                htable.Add("@UserName", Convert.ToString(Session["UserId"].ToString()));
                                htable.Add("@GeoRegion", "");
                                htable.Add("@Action", Request.QueryString["flag"]);
                                htable.Add("@IsSlsUnit", SalesUnit);

                                //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                htable.Add("@UnitName", DdlUnitName.SelectedValue);
                                htable.Add("@AgentName", DdlAgntName.SelectedValue);
                                htable.Add("@LinkUnitChannel", LblSlschannel.Text); //Added by Kalyani on 11-12-13 
                                htable.Add("@LinkUnitChncls", LblChannelSubclass.Text); //Added by Kalyani on 11-12-13 
                                htable.Add("@LinkStaffChannel", lbluntSalesChnlDesc.Text);//Added by Kalyani on 11-12-13 
                                htable.Add("@LinkStaffChncls", lbluntSubChnlDesc.Text);//Added by Kalyani on 11-12-13 
                                                                                       //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end


                                if (txtSALocCode.Visible == true)
                                {
                                    htable.Add("@SALocCode", txtSALocCode.Text);
                                }
                                else
                                {
                                    htable.Add("@SALocCode", "");
                                }
                                if (txtCompanyUnitCode.Visible == true)
                                {
                                    htable.Add("@CmpUnitCode", txtCompanyUnitCode.Text);
                                }
                                else
                                {
                                    htable.Add("@CmpUnitCode", "");
                                }
                                htable.Add("@UnitDesc01", txtUntDesc1.Text);
                                htable.Add("@UnitDesc02", txtUntDesc2.Text);
                                htable.Add("@UnitDesc03", txtUntDesc3.Text);
                                //Change of int  to decimal untLvl due to Addition of State in Tied
                                htable.Add("@UnitRank", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                if (txtSMCount.Visible == true)
                                {
                                    htable.Add("@SMCount", txtSMCount.Text);
                                }
                                else
                                {
                                    htable.Add("@SMCount", System.DBNull.Value);
                                }
                                if (txtPCCode.Visible == true)
                                {
                                    htable.Add("@RegistrationNo", txtPCCode.Text);
                                }
                                else
                                {
                                    htable.Add("@RegistrationNo", System.DBNull.Value);
                                }

                                //Added by swapnesh on 10/02/2014 to insert new details of unit start
                                htable.Add("@InsRefCode", txtInsRefCode.Text.Trim());

                                #region Address
                                htable.Add("@AddressLine1", txtAddrP1.Text);
                                htable.Add("@AddressLine2", txtAddrP2.Text);
                                htable.Add("@AddressLine3", txtAddrP3.Text);
                                htable.Add("@Village", txtVillage.Text.Trim());
                                htable.Add("@City", txtcityp.Text);
                                htable.Add("@State", ddlState.SelectedValue);
                                htable.Add("@Dist", txtDistP.Text.Trim());
                                htable.Add("@Area", txtarea.Text.Trim());
                                htable.Add("@PostCode", txtPinP.Text);
                                htable.Add("@Country", txtCountryCodeP.Text.Trim());
                                #endregion

                                #region Location
                                htable.Add("@Latitude", txtLatitude.Text.Trim());
                                htable.Add("@Longitude", txtLongitude.Text.Trim());
                                #endregion

                                #region Reporting Manager
                                if (tblUnitRptType.Visible != false)
                                {
                                    #region Primary Reporting
                                    htable.Add("@PriRptTyp", ddlreportingtype.SelectedValue);
                                    htable.Add("@PriBasedOn", ddlbasedon.SelectedValue);
                                    htable.Add("@PriChnl", ddlchannel.SelectedValue);
                                    htable.Add("@PriSubChnl", ddlsubchannel.SelectedValue);
                                    htable.Add("@PriUntTyp", ddllevelagttype.SelectedValue);
                                    htable.Add("@RptUnitCode", hdnRptUntCode.Value);
                                    #endregion

                                    if (tblMgr1.Visible != false)
                                    {
                                        htable.Add("@MgrRptTyp1", ddlam1reportingtype.SelectedValue);
                                        htable.Add("@MgrBasedOn1", ddlam1basedon.SelectedValue);
                                        htable.Add("@MgrChnl1", ddlam1channel.SelectedValue);
                                        htable.Add("@MgrSubChnl1", ddlam1subchannel.SelectedValue);
                                        htable.Add("@MgrUntTyp1", ddlam1levelagttype.SelectedValue);
                                        htable.Add("@MgrUnitCode1", hdnRptUntCodeMgr1.Value);
                                    }
                                }
                                #endregion
                                //Added by swapnesh on 10/02/2014 to insert new details of unit end

                                ArrayList arrLst = new ArrayList();
                                if (Request.QueryString["flag"] == "add")
                                {
                                    arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitCode", txtUnitCode.Text));
                                    arrLst.Add(new prjXml.Collection("BizSrc", lblSalesChannel.Text));
                                    arrLst.Add(new prjXml.Collection("ChnCls", ddlChnnlSubClass.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("SalesUnit", SalesUnit));
                                    arrLst.Add(new prjXml.Collection("UnitCode", UnitCode));
                                    arrLst.Add(new prjXml.Collection("UnitDescEng", txtUntDesc1.Text));
                                    arrLst.Add(new prjXml.Collection("UnitMgrCode", txtUnitMGRCode.Text));
                                    arrLst.Add(new prjXml.Collection("UnitStatus", ddlUnitStat.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("UnitType", ddlUnitType.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("AddressLine1", txtAddress1.Text));
                                    arrLst.Add(new prjXml.Collection("AddressLine2", txtAddress2.Text));
                                    arrLst.Add(new prjXml.Collection("AddressLine3", txtAddress3.Text));
                                    arrLst.Add(new prjXml.Collection("PostCode", txtPOstCode.Text));
                                    arrLst.Add(new prjXml.Collection("City", txtCity.Text));
                                    arrLst.Add(new prjXml.Collection("WorkTel", txtOTel.Text));
                                    arrLst.Add(new prjXml.Collection("WorkFax", txtFax.Text));
                                    arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));
                                    arrLst.Add(new prjXml.Collection("Remark", txtRemark.Text));
                                    arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));
                                    //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                    arrLst.Add(new prjXml.Collection("UnitName", DdlUnitName.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("AgentName", DdlAgntName.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("LinkUnitChannel", LblSlschannel.Text));//Added by Kalyani on 11-12-13 
                                    arrLst.Add(new prjXml.Collection("LinkUnitChncls", LblChannelSubclass.Text));//Added by Kalyani on 11-12-13 
                                    arrLst.Add(new prjXml.Collection("LinkStaffChannel", lbluntSalesChnlDesc.Text));//Added by Kalyani on 11-12-13
                                    arrLst.Add(new prjXml.Collection("LinkStaffChncls", lbluntSubChnlDesc.Text));//Added by Kalyani on 11-12-13
                                                                                                                 // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end
                                }

                                prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                                XmlDocument xDoc = new XmlDocument();
                                xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                                strXML = xDoc.OuterXml;

                                arrLst.Clear();
                                arrResult = channelsetup.UnitMaintUpdate(htable, "prc_AgyAdmin_UpdUnitMaintWithOUTParam");
                                htable.Clear();
                                if (arrResult.Count > 0)
                                {
                                    if (arrResult[0].ToString() != "F")
                                    {
                                        if (arrResult.Count > 0)
                                        {
                                            if (arrResult[0].ToString().Equals("0"))
                                            {
                                                //Added by swapnesh on 28/5/2013 for showing message box start
                                                // lbl3.Visible = true;
                                                //lblmsg.Text = "Admin Unit Maintenance done successfully";
                                                //lbl3.Text = "Admin Unit Maintenance done successfully";
                                                //lbl4.Text = "Unit Code : " + txtUnitCode.Text;
                                                //lbl5.Text = "Unit Description : " + txtUntDesc1.Text;
                                                lbl_popup.Text = "Admin Unit Maintenance done successfully" + "</br></br> Unit Code :  " + txtUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                                                // mdlpopup.Show();
                                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                                //Added by swapnesh on 28/5/2013 for showing message box end
                                                lblmsg.ForeColor = Color.Red;
                                                lblmsg.Visible = true;
                                                btnUpdate.Enabled = false;
                                                if (ViewState["strAgentCode"] != null)
                                                {
                                                    lblCSCCodeLA.Visible = true;
                                                    lblCSCCode.Visible = true;
                                                    lblCSCCode.Text = ViewState["strAgentCode"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                switch (arrResult[0].ToString())
                                                {
                                                    case "-1":
                                                        lblmsg.Text = "Unit Code Not Exist";
                                                        break;
                                                    case "-2":
                                                        lblmsg.Text = "Unit Code Already Exist";
                                                        break;
                                                    case "-3":
                                                        lblmsg.Text = "System Error! Unit Client Code cannot generated";
                                                        break;
                                                    case "-4":
                                                        lblmsg.Text = "Please enter valid Unit Manager Code";
                                                        break;
                                                    case "-5":
                                                        lblmsg.Text = "Unit Manager Agent Type must be Unit Manager and above";
                                                        break;
                                                    case "-6":
                                                        lblmsg.Text = "Unit Manager Agent Type must be Senior Agency Manager and above";
                                                        break;
                                                    case "-7":
                                                        lblmsg.Text = "Senior Agency Manager is not allow manage more than 1 unit";
                                                        break;
                                                    case "-8":
                                                        lblmsg.Text = "Please enter valid Company Unit Code";
                                                        break;
                                                    default:
                                                        lblmsg.Text = "System Error";
                                                        break;
                                                }
                                                lblmsg.ForeColor = Color.Red;
                                                lblmsg.Visible = true;
                                                ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblmsg.Text + "');</script>", false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblmsg.Text = arrResult[1].ToString();
                                        lblmsg.ForeColor = Color.Red;
                                        lblmsg.Visible = true;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Error Updating Agent Details.";
                                    lblmsg.ForeColor = Color.Red;
                                    lblmsg.Visible = true;
                                }

                                //Added by swapnesh on 15/5/2013 to change lblmsg text start
                                lblmsg.Text = "Admin Unit Maintenance done successfully";
                                //Added by swapnesh on 15/5/2013 to change lblmsg text end

                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Visible = true;
                                btnUpdate.Enabled = false;
                            }

                            //    if (Request.QueryString["flag"] == "add")
                            //    {
                            //        //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                            //        htable.Clear();
                            //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            //        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                            //        //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

                            //        if (dtRead.Read())
                            //        {
                            //            //Comented by usha on
                            //            MgrCreateRul = dtRead[0].ToString();

                            //            //PositionReq = dtRead[0].ToString();
                            //            //strAgentType = dtRead[1].ToString();
                            //        }
                            //        dtRead.Close();

                            //        //Comented  by usha  on 26.02.2019
                            //        //if (MgrCreateRul == "1")
                            //       // {

                            //        if (PositionReq == "True")
                            //        { 
                            //            //htable.Clear();
                            //            //htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //            //htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //            ////htable.Add("@UnitCode",ddlReportingUnit.SelectedValue);
                            //            //htable.Add("@UnitCode", hdnRptUntCode.Value);
                            //            //htable.Add("@LBLUnitCode", "");
                            //            //htable.Add("@LegalName", "");
                            //            //htable.Add("@flag", "SELECTQURY");
                            //            //dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                            //            ////Added by rachana on 04-07-2013 for Select CtrNo end

                            //            //if (dtRead.Read())
                            //            //{
                            //            //    strMgrCode = dtRead[0].ToString();
                            //            //    strAgentType = dtRead[1].ToString();
                            //            //}
                            //            //dtRead.Close();
                            //            //Change of int  to decimal untLvl due to Addition of State in Tied
                            //            decimal intUnitRank = 0, NewUnitRank = 0;

                            //            //Added by rachana on 04-07-2013 for Selecting UnitRank start
                            //            htable.Clear();
                            //            htable.Add("@CarrierCode", "2");
                            //            htable.Add("@AgentType", strAgentType);
                            //            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //            htable.Add("@flag", "1");
                            //            dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                            //            //Added by rachana on 04-07-2013 for Selecting UnitRank end


                            //            if (dtRead.Read())
                            //            {
                            //                //Change of int  to decimal untLvl due to Addition of State in Tied
                            //                intUnitRank = Decimal.Parse(dtRead[0].ToString());
                            //            }
                            //            dtRead.Close();
                            //            #region comented by usha  26.02.2019
                            //            //Added by rachana on 05-07-2013 for Select CtrNo start
                            //            //htable.Clear();
                            //            //htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //            //htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //            //htable.Add("@UnitRank", intUnitRank);
                            //            //htable.Add("@flag", "1");
                            //            //dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                            //            ////Added by rachana on 04-07-2013 for Select CtrNo end


                            //            //if (dtRead.Read())
                            //            //{
                            //            //    //Change of int  to decimal untLvl due to Addition of State in Tied
                            //            //    NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                            //            //}
                            //            //dtRead.Close();
                            //            ////Added by rachana on 05-07-2013 for Select AgentType start
                            //            //htable.Clear();
                            //            //htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //            //htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //            //htable.Add("@UnitCode", "");
                            //            //htable.Add("@UnitRank", intUnitRank);
                            //            //htable.Add("@flag", "2");
                            //            //dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                            //            ////Added by rachana on 05-07-2013 for Select AgentType end


                            //            //if (dtRead.Read())
                            //            //{
                            //            //    strNewAgnType = dtRead[0].ToString();
                            //            //}

                            //            #endregion 
                            //            //Comented by usha 
                            //            dtRead.Close();
                            //            if (strAgentType.Trim() != "")
                            //            {

                            //                //htable.Clear();
                            //                //htable.Add("@flag", "PositionCode");
                            //                //dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                            //                ////Added by rachana on 02-07-2013 for Select ctrno end
                            //                //if (dtRead.Read())
                            //                //{
                            //                //    ViewState["AgentCode"] = dtRead[0].ToString();
                            //                //}
                            //                dtRead.Close();
                            //                htable.Clear();//Added by Rachana on 05-07-2013
                            //                htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //              //  htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                            //                htable.Add("@AgentStatus ", "IF");
                            //                htable.Add("@CustomerId", "90021917");
                            //                htable.Add("@Exclusive ", "Y");
                            //                htable.Add("@AgentName ", txtUntDesc1.Text);
                            //                htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //                htable.Add("@AgentType", strAgentType);
                            //                htable.Add("@AgentClass", "");
                            //                htable.Add("@PayMethod", "CQ");
                            //                htable.Add("@Currency ", "INR");
                            //                htable.Add("@CommCls", "0002");
                            //                htable.Add("@PayFreq ", "12");
                            //                htable.Add("@AccPayCode", "");
                            //                htable.Add("@MinAmt", 0);
                            //                htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                            //                htable.Add("@RecruitDate ", System.DBNull.Value);
                            //                htable.Add("@BEBranchCode", "10");
                            //                htable.Add("@RecruitAgntCode", "");
                            //                htable.Add("@BEAreaCode ", "10");
                            //                htable.Add("@ImmLeader ", "");
                            //                htable.Add("@BESMCode ", "");
                            //                htable.Add("@UnitCode ", txtUnitCode.Text);
                            //                htable.Add("@DateTerminated", System.DBNull.Value);
                            //                htable.Add("@BlackListStatus", "");
                            //                htable.Add("@EmployeeCode", "77777777");
                            //                htable.Add("@MgrCode", strMgrCode);
                            //                htable.Add("@BizLicsNo", "");
                            //                htable.Add("@BizLicsExpDate", System.DBNull.Value);
                            //                htable.Add("@DeductTax", "");
                            //                htable.Add("@TaxCode", "");
                            //                dataAccess.execute_sprc("prc_AgyAdmin_DummyInsertMgr", htable);
                            //                //htable.Clear();
                            //                //htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //                //htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //                //htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //                //htable.Add("@UnitCode ", txtUnitCode.Text);
                            //                //htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                            //                //htable.Add("@MgrType", strNewAgnType);
                            //                //htable.Add("@DirectMgrType", strAgentType);
                            //                //htable.Add("@DirectMgrCode", strMgrCode);
                            //                //htable.Add("@EMPCode", "77777777");
                            //                //htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                            //                //dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                            //                //htable.Clear();
                            //            }

                            //      //  }
                            //       // else 

                            //        //    if (MgrCreateRul == "2")
                            //        //{
                            //        //    //Added by rachana on 05-07-2013 for Select RptUnitCode start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                            //        //    htable.Add("@UnitCode", hdnRptUntCode.Value);
                            //        //    htable.Add("@flag", "rpt");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                            //        //    //Added by rachana on 05-07-2013 for Select RptUnitCode end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strRptUnitCode = dtRead[0].ToString();
                            //        //    }
                            //        //    dtRead.Close();

                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType strat
                            //        //    htable.Clear();
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@UnitCode", strRptUnitCode);
                            //        //    htable.Add("@LBLUnitCode", "");
                            //        //    htable.Add("@LegalName", "");
                            //        //    htable.Add("@flag", "SELECTQURY");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strMgrCode = dtRead[0].ToString();
                            //        //        strAgentType = dtRead[1].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //    decimal intUntRank = 0, NewUntRank = 0;
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                            //        //    htable.Clear();
                            //        //    htable.Add("@CarrierCode", "");
                            //        //    htable.Add("@AgentType", strAgentType);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        intUntRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank start
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitRank", intUntRank);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank end
                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        NewUntRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType from ChnAgnSu start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitCode", "");
                            //        //    htable.Add("@UnitRank", NewUntRank);
                            //        //    htable.Add("@flag", "2");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType from ChnAgnSu end


                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strNewAgnType = dtRead[0].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    if (strNewAgnType.Trim() != "")
                            //        //    {
                            //        //        //Added by rachana on 02-07-2013 for select ctrno start
                            //        //        htable.Clear();
                            //        //        htable.Add("@flag", "FE");
                            //        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                            //        //        //Added by rachana on 02-07-2013 for select ctrnoend

                            //        //        if (dtRead.Read())
                            //        //        {
                            //        //            ViewState["AgentCode"] = dtRead[0].ToString();
                            //        //        }
                            //        //        dtRead.Close();
                            //        //        htable.Clear();//Added by rachana on 05-07-2013 to clear hash table
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@AgentStatus ", "IF");
                            //        //        htable.Add("@CustomerId", "90021917");
                            //        //        htable.Add("@Exclusive ", "Y");
                            //        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@AgentType", strNewAgnType);
                            //        //        htable.Add("@AgentClass", "");
                            //        //        htable.Add("@PayMethod", "CQ");
                            //        //        htable.Add("@Currency ", "INR");
                            //        //        htable.Add("@CommCls", "0002");
                            //        //        htable.Add("@PayFreq ", "12");
                            //        //        htable.Add("@AccPayCode", "");
                            //        //        htable.Add("@MinAmt", 0);
                            //        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                            //        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                            //        //        htable.Add("@BEBranchCode", "10");
                            //        //        htable.Add("@RecruitAgntCode", "");
                            //        //        htable.Add("@BEAreaCode ", "10");
                            //        //        htable.Add("@ImmLeader ", "");
                            //        //        htable.Add("@BESMCode ", "");
                            //        //        htable.Add("@UnitCode ", "");
                            //        //        htable.Add("@DateTerminated", System.DBNull.Value);
                            //        //        htable.Add("@BlackListStatus", "");
                            //        //        htable.Add("@EmployeeCode", "77777777");
                            //        //        htable.Add("@MgrCode", strMgrCode);
                            //        //        htable.Add("@BizLicsNo", "");
                            //        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                            //        //        htable.Add("@DeductTax", "");
                            //        //        htable.Add("@TaxCode", "");
                            //        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                            //        //        htable.Clear();
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                            //        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@MgrType", strNewAgnType);
                            //        //        htable.Add("@DirectMgrType", strAgentType);
                            //        //        htable.Add("@DirectMgrCode", strMgrCode);
                            //        //        htable.Add("@EMPCode", "77777777");
                            //        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                            //        //        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                            //        //        htable.Clear();

                            //        //    }
                            //        //    #region "TD MT Creation"
                            //        //    if (Request.QueryString["ChannelCode"].ToString() == "TD")
                            //        //    {
                            //        //        if (strNewAgnType.Trim().ToString() == "TM")
                            //        //        {
                            //        //            //Added by rachana on 02-07-2013 for selet ctrno start
                            //        //            //dtRead = dataAccess.Common_exec_reader("Select CtrNo from dbo.Ctr Where CtrID ='FEAgentCode'");
                            //        //            htable.Clear();
                            //        //            htable.Add("@flag", "FE");
                            //        //            dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                            //        //            //Added by rachana on 02-07-2013 for select ctrno end
                            //        //            if (dtRead.Read())
                            //        //            {
                            //        //                ViewState["MTAgentCode"] = dtRead[0].ToString();
                            //        //            }
                            //        //            dtRead.Close();
                            //        //            htable.Clear();
                            //        //            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //            htable.Add("@AgentCode ", ViewState["MTAgentCode"].ToString());
                            //        //            htable.Add("@AgentStatus ", "IF");
                            //        //            htable.Add("@CustomerId", "90021917");
                            //        //            htable.Add("@Exclusive ", "Y");
                            //        //            htable.Add("@AgentName ", txtUntDesc1.Text);
                            //        //            htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //            htable.Add("@AgentType", "MT");
                            //        //            htable.Add("@AgentClass", "");
                            //        //            htable.Add("@PayMethod", "CQ");
                            //        //            htable.Add("@Currency ", "INR");
                            //        //            htable.Add("@CommCls", "0002");
                            //        //            htable.Add("@PayFreq ", "12");
                            //        //            htable.Add("@AccPayCode", "");
                            //        //            htable.Add("@MinAmt", 0);
                            //        //            htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                            //        //            htable.Add("@RecruitDate ", System.DBNull.Value);
                            //        //            htable.Add("@BEBranchCode", "10");
                            //        //            htable.Add("@RecruitAgntCode", "");
                            //        //            htable.Add("@BEAreaCode ", "10");
                            //        //            htable.Add("@ImmLeader ", "");
                            //        //            htable.Add("@BESMCode ", "");
                            //        //            htable.Add("@UnitCode ", "");
                            //        //            htable.Add("@DateTerminated", System.DBNull.Value);
                            //        //            htable.Add("@BlackListStatus", "");
                            //        //            htable.Add("@EmployeeCode", "77777777");
                            //        //            htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                            //        //            htable.Add("@BizLicsNo", "");
                            //        //            htable.Add("@BizLicsExpDate", System.DBNull.Value);
                            //        //            htable.Add("@DeductTax", "");
                            //        //            htable.Add("@TaxCode", "");
                            //        //            dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                            //        //            htable.Clear();
                            //        //            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //            htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //            htable.Add("@UnitCode ", txtUnitCode.Text);
                            //        //            htable.Add("@MgrCode", ViewState["MTAgentCode"].ToString());
                            //        //            htable.Add("@MgrType", "MT");
                            //        //            htable.Add("@DirectMgrType", "TM");
                            //        //            htable.Add("@DirectMgrCode", ViewState["AgentCode"].ToString());
                            //        //            htable.Add("@EMPCode", "77777777");
                            //        //            htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                            //        //            dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                            //        //            htable.Clear();
                            //        //        }
                            //        //    }
                            //        //    #endregion
                            //        //}
                            //        //else if (MgrCreateRul == "4")
                            //        //{
                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType start
                            //        //    htable.Clear();
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                            //        //    htable.Add("@UnitCode", hdnRptUntCode.Value);
                            //        //    htable.Add("@LBLUnitCode", "");
                            //        //    htable.Add("@LegalName", "");
                            //        //    htable.Add("@flag", "SELECTQURY");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType end


                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strMgrCode = dtRead[0].ToString();
                            //        //        strAgentType = dtRead[1].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //    intUnitRank = 0;
                            //        //    NewUnitRank = 0;
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                            //        //    htable.Clear();
                            //        //    htable.Add("@CarrierCode", "");
                            //        //    htable.Add("@AgentType", strAgentType);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank end


                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        intUnitRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 05-07-2013 for Select Top 1 UnitRank start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitRank", intUnitRank);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        NewUnitRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitCode", "");
                            //        //    htable.Add("@UnitRank", NewUnitRank);
                            //        //    htable.Add("@flag", "2");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strNewAgnType = dtRead[0].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    if (strNewAgnType.Trim() != "")
                            //        //    {
                            //        //        //Added by rachana on 02-07-2013 for Select CtrNo start
                            //        //        htable.Clear();
                            //        //        htable.Add("@flag", "FE");
                            //        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                            //        //        //Added by rachana on 02-07-2013 for Select CtrNoend

                            //        //        if (dtRead.Read())
                            //        //        {
                            //        //            ViewState["AgentCode"] = dtRead[0].ToString();
                            //        //        }
                            //        //        dtRead.Close();
                            //        //        htable.Clear();
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@AgentStatus ", "IF");
                            //        //        htable.Add("@CustomerId", "90021917");
                            //        //        htable.Add("@Exclusive ", "Y");
                            //        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@AgentType", strNewAgnType);
                            //        //        htable.Add("@AgentClass", "");
                            //        //        htable.Add("@PayMethod", "CQ");
                            //        //        htable.Add("@Currency ", "INR");
                            //        //        htable.Add("@CommCls", "0002");
                            //        //        htable.Add("@PayFreq ", "12");
                            //        //        htable.Add("@AccPayCode", "");
                            //        //        htable.Add("@MinAmt", 0);
                            //        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                            //        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                            //        //        htable.Add("@BEBranchCode", "10");
                            //        //        htable.Add("@RecruitAgntCode", "");
                            //        //        htable.Add("@BEAreaCode ", "10");
                            //        //        htable.Add("@ImmLeader ", "");
                            //        //        htable.Add("@BESMCode ", "");
                            //        //        htable.Add("@UnitCode ", "");
                            //        //        htable.Add("@DateTerminated", System.DBNull.Value);
                            //        //        htable.Add("@BlackListStatus", "");
                            //        //        htable.Add("@EmployeeCode", "77777777");
                            //        //        htable.Add("@MgrCode", strMgrCode);
                            //        //        htable.Add("@BizLicsNo", "");
                            //        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                            //        //        htable.Add("@DeductTax", "");
                            //        //        htable.Add("@TaxCode", "");
                            //        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                            //        //        htable.Clear();
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                            //        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@MgrType", strNewAgnType);
                            //        //        htable.Add("@DirectMgrType", strAgentType);
                            //        //        htable.Add("@DirectMgrCode", strMgrCode);
                            //        //        htable.Add("@EMPCode", "77777777");
                            //        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                            //        //        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                            //        //        htable.Clear();
                            //        //    }

                            //        //}
                            //        //else if (MgrCreateRul == "6")
                            //        //{
                            //        //    //Added by rachana on 05-07-2013 for Select RptUnitCode start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                            //        //    htable.Add("@UnitCode", hdnRptUntCode.Value);
                            //        //    htable.Add("@flag", "rpt");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                            //        //    //Added by rachana on 05-07-2013 for Select RptUnitCodeend

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strRptUnitCode = dtRead[0].ToString();
                            //        //    }
                            //        //    dtRead.Close();

                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType start
                            //        //    htable.Clear();
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@UnitCode", strRptUnitCode);
                            //        //    htable.Add("@LBLUnitCode", "");
                            //        //    htable.Add("@LegalName", "");
                            //        //    htable.Add("@flag", "SELECTQURY");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select MgrCode,MgrType end


                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strMgrCode = dtRead[0].ToString();
                            //        //        strAgentType = dtRead[1].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //    decimal intUntRank = 0, NewUntRank = 0;
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank start
                            //        //    htable.Clear();
                            //        //    htable.Add("@CarrierCode", "");
                            //        //    htable.Add("@AgentType", strAgentType);
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htable);
                            //        //    //Added by rachana on 04-07-2013 for Selecting UnitRank end


                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        intUntRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank start
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitRank", intUntRank);
                            //        //    htable.Add("@flag", "1");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetTopUnitranksforUnitmaint", htable);
                            //        //    //Added by rachana on 04-07-2013 for Select Top 1 UnitRank end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        //Change of int  to decimal untLvl due to Addition of State in Tied
                            //        //        NewUntRank = Decimal.Parse(dtRead[0].ToString());
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType start
                            //        //    htable.Clear();
                            //        //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            //        //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //    htable.Add("@UnitCode", "");
                            //        //    htable.Add("@UnitRank", NewUntRank);
                            //        //    htable.Add("@flag", "2");
                            //        //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                            //        //    //Added by rachana on 05-07-2013 for Select AgentType end

                            //        //    if (dtRead.Read())
                            //        //    {
                            //        //        strNewAgnType = dtRead[0].ToString();
                            //        //    }
                            //        //    dtRead.Close();
                            //        //    if (strNewAgnType.Trim() != "")
                            //        //    {
                            //        //        //Added by rachana on 02-07-2013 for select ctrno start
                            //        //        htable.Clear();
                            //        //        htable.Add("@flag", "FE");
                            //        //        dtRead = objDAL.Common_exec_reader_prc("Prc_GetCtrNoforunitmaint", htable);
                            //        //        //Added by rachana on 02-07-2013 for select ctrno end
                            //        //        if (dtRead.Read())
                            //        //        {
                            //        //            ViewState["AgentCode"] = dtRead[0].ToString();
                            //        //        }
                            //        //        dtRead.Close();
                            //        //        htable.Clear();
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@AgentStatus ", "IF");
                            //        //        htable.Add("@CustomerId", "90021917");
                            //        //        htable.Add("@Exclusive ", "Y");
                            //        //        htable.Add("@AgentName ", txtUntDesc1.Text);
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@AgentType", strNewAgnType);
                            //        //        htable.Add("@AgentClass", "");
                            //        //        htable.Add("@PayMethod", "CQ");
                            //        //        htable.Add("@Currency ", "INR");
                            //        //        htable.Add("@CommCls", "0002");
                            //        //        htable.Add("@PayFreq ", "12");
                            //        //        htable.Add("@AccPayCode", "");
                            //        //        htable.Add("@MinAmt", 0);
                            //        //        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                            //        //        htable.Add("@RecruitDate ", System.DBNull.Value);
                            //        //        htable.Add("@BEBranchCode", "10");
                            //        //        htable.Add("@RecruitAgntCode", "");
                            //        //        htable.Add("@BEAreaCode ", "10");
                            //        //        htable.Add("@ImmLeader ", "");
                            //        //        htable.Add("@BESMCode ", "");
                            //        //        htable.Add("@UnitCode ", "");
                            //        //        htable.Add("@DateTerminated", System.DBNull.Value);
                            //        //        htable.Add("@BlackListStatus", "");
                            //        //        htable.Add("@EmployeeCode", "77777777");
                            //        //        htable.Add("@MgrCode", strMgrCode);
                            //        //        htable.Add("@BizLicsNo", "");
                            //        //        htable.Add("@BizLicsExpDate", System.DBNull.Value);
                            //        //        htable.Add("@DeductTax", "");
                            //        //        htable.Add("@TaxCode", "");
                            //        //        dataAccess.execute_sprc("prc_AgyAdmin_AgtInsertMgr", htable);
                            //        //        htable.Clear();
                            //        //        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            //        //        htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                            //        //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        //        htable.Add("@UnitCode ", txtUnitCode.Text);
                            //        //        htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                            //        //        htable.Add("@MgrType", strNewAgnType);
                            //        //        htable.Add("@DirectMgrType", strAgentType);
                            //        //        htable.Add("@DirectMgrCode", strMgrCode);
                            //        //        htable.Add("@EMPCode", "77777777");
                            //        //        htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                            //        //        dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                            //        //        htable.Clear();

                            //        //    }

                            //        //}

                            //        if (txtUnitCode.Visible == true)
                            //        {
                            //            UnitCode = txtUnitCode.Text;
                            //        }
                            //        else
                            //        {
                            //            UnitCode = lblUnitCode.Text;
                            //        }

                            //        string SalesUnit;
                            //        if (rdlYesNo.SelectedValue == "Y")
                            //        {
                            //            SalesUnit = "True";
                            //        }
                            //        else
                            //        {
                            //            SalesUnit = "False";
                            //        }

                            //        htable.Clear();//Added by rachana on 03-07-2013 to clear hashtable
                            //        htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                            //        //htable.Add("@RptUnitCode", ddlReportingUnit.SelectedValue);
                            //        htable.Add("@UnitLevel", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                            //        htable.Add("@UnitCode", UnitCode);
                            //        htable.Add("@UnitDescTha", "");
                            //        htable.Add("@UnitDescEng", txtUntDesc1.Text);
                            //        htable.Add("@GeoRegionChs", "");
                            //        htable.Add("@GeoRegionEng", "");
                            //        htable.Add("@UnitMgrCode", txtUnitMGRCode.Text);
                            //        htable.Add("@UnitStatus", ddlUnitStat.SelectedValue);
                            //        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            //        htable.Add("@WorkTel", txtOTel.Text);
                            //        htable.Add("@WorkFax", txtFax.Text);
                            //        htable.Add("@Email", txtEMail.Text);
                            //        htable.Add("@Remark", txtRemark.Text);
                            //        htable.Add("@cboBizsrc", Request.QueryString["ChannelCode"]);
                            //        htable.Add("@oldBizsrc", Request.QueryString["ChannelCode"]);
                            //        htable.Add("@UserId", "");
                            //        htable.Add("@UserName", Convert.ToString(Session["UserId"].ToString()));
                            //        htable.Add("@GeoRegion", "");
                            //        htable.Add("@Action", Request.QueryString["flag"]);
                            //        htable.Add("@IsSlsUnit", SalesUnit);

                            //        // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                            //        htable.Add("@UnitName", DdlUnitName.SelectedValue);
                            //        htable.Add("@AgentName", DdlAgntName.SelectedValue);
                            //        htable.Add("@LinkUnitChannel", LblSlschannel.Text); //Added by Kalyani on 11-12-13 
                            //        htable.Add("@LinkUnitChncls", LblChannelSubclass.Text); //Added by Kalyani on 11-12-13 
                            //        htable.Add("@LinkStaffChannel", lbluntSalesChnlDesc.Text);//Added by Kalyani on 11-12-13 
                            //        htable.Add("@LinkStaffChncls", lbluntSubChnlDesc.Text);//Added by Kalyani on 11-12-13 
                            //        htable.Add("@SapUnit", ViewState["sapcode"].ToString());//Session["unitcode"]);//Added by usha on 20.09.2018
                            //        // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                            //        if (txtSALocCode.Visible == true)
                            //        {
                            //            htable.Add("@SALocCode", txtSALocCode.Text);
                            //        }
                            //        else
                            //        {
                            //            htable.Add("@SALocCode", "");
                            //        }
                            //        if (txtCompanyUnitCode.Visible == true)
                            //        {
                            //            htable.Add("@CmpUnitCode", txtCompanyUnitCode.Text);
                            //        }
                            //        else
                            //        {
                            //            htable.Add("@CmpUnitCode", "");
                            //        }
                            //        htable.Add("@UnitDesc01", txtUntDesc1.Text);
                            //        htable.Add("@UnitDesc02", txtUntDesc2.Text);
                            //        htable.Add("@UnitDesc03", txtUntDesc3.Text);
                            //        //change of int16 to decimal due to state in tied
                            //        htable.Add("@UnitRank", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                            //        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            //        if (txtSMCount.Visible == true)
                            //        {
                            //            htable.Add("@SMCount", txtSMCount.Text);
                            //        }
                            //        else
                            //        {
                            //            htable.Add("@SMCount", System.DBNull.Value);
                            //        }
                            //        if (txtPCCode.Visible == true)
                            //        {
                            //            htable.Add("@RegistrationNo", txtPCCode.Text);
                            //        }
                            //        else
                            //        {
                            //            htable.Add("@RegistrationNo", System.DBNull.Value);
                            //        }

                            //        //Added by swapnesh on 10/02/2014 to insert new details of unit start
                            //        htable.Add("@InsRefCode", txtInsRefCode.Text.Trim());

                            //        #region Address
                            //        htable.Add("@AddressLine1", txtAddrP1.Text);
                            //        htable.Add("@AddressLine2", txtAddrP2.Text);
                            //        htable.Add("@AddressLine3", txtAddrP3.Text);
                            //        htable.Add("@Village", txtVillage.Text.Trim());
                            //        htable.Add("@City", txtcityp.Text);
                            //        htable.Add("@State", ddlState.SelectedValue);
                            //        htable.Add("@Dist", txtDistP.Text.Trim());
                            //        htable.Add("@Area", txtarea.Text.Trim());
                            //        htable.Add("@PostCode", txtPinP.Text);
                            //        htable.Add("@Country", txtCountryCodeP.Text.Trim());
                            //        #endregion

                            //        #region Location
                            //        htable.Add("@Latitude", txtLatitude.Text.Trim());
                            //        htable.Add("@Longitude", txtLongitude.Text.Trim());
                            //        #endregion

                            //        #region Reporting Manager
                            //        if (tblUnitRptType.Visible != false)
                            //        {
                            //            #region Primary Reporting
                            //            htable.Add("@PriRptTyp", ddlreportingtype.SelectedValue);
                            //            htable.Add("@PriBasedOn", ddlbasedon.SelectedValue);
                            //            htable.Add("@PriChnl", ddlchannel.SelectedValue);
                            //            htable.Add("@PriSubChnl", ddlsubchannel.SelectedValue);
                            //            htable.Add("@PriUntTyp", ddllevelagttype.SelectedValue);
                            //            htable.Add("@RptUnitCode", hdnRptUntCode.Value);
                            //            #endregion

                            //            //if (tblMgr1.Visible != false)
                            //            //{
                            //                htable.Add("@MgrRptTyp1", ddlam1reportingtype.SelectedValue);
                            //                htable.Add("@MgrBasedOn1", ddlam1basedon.SelectedValue);
                            //                htable.Add("@MgrChnl1", ddlam1channel.SelectedValue);
                            //                htable.Add("@MgrSubChnl1", ddlam1subchannel.SelectedValue);
                            //                htable.Add("@MgrUntTyp1", ddlam1levelagttype.SelectedValue);
                            //                htable.Add("@MgrUnitCode1", hdnRptUntCodeMgr1.Value);
                            //            //}
                            //        }
                            //        #endregion
                            //        //Added by swapnesh on 10/02/2014 to insert new details of unit end

                            //        ArrayList arrLst = new ArrayList();
                            //        if (Request.QueryString["flag"] == "add")
                            //        {
                            //            arrLst.Add(new prjXml.Collection("CCode", Session["CarrierCode"].ToString()));
                            //            arrLst.Add(new prjXml.Collection("UnitCode", txtUnitCode.Text));
                            //            arrLst.Add(new prjXml.Collection("BizSrc", lblSalesChannel.Text));
                            //            arrLst.Add(new prjXml.Collection("ChnCls", ddlChnnlSubClass.SelectedValue));
                            //            arrLst.Add(new prjXml.Collection("SalesUnit", SalesUnit));
                            //            arrLst.Add(new prjXml.Collection("UnitCode", UnitCode));
                            //            arrLst.Add(new prjXml.Collection("UnitDescEng", txtUntDesc1.Text));
                            //            arrLst.Add(new prjXml.Collection("UnitMgrCode", txtUnitMGRCode.Text));
                            //            arrLst.Add(new prjXml.Collection("UnitStatus", ddlUnitStat.SelectedValue));
                            //            arrLst.Add(new prjXml.Collection("UnitType", ddlUnitType.SelectedValue));
                            //            arrLst.Add(new prjXml.Collection("AddressLine1", txtAddress1.Text));
                            //            arrLst.Add(new prjXml.Collection("AddressLine2", txtAddress2.Text));
                            //            arrLst.Add(new prjXml.Collection("AddressLine3", txtAddress3.Text));
                            //            arrLst.Add(new prjXml.Collection("PostCode", txtPOstCode.Text));
                            //            arrLst.Add(new prjXml.Collection("City", txtCity.Text));
                            //            arrLst.Add(new prjXml.Collection("WorkTel", txtOTel.Text));
                            //            arrLst.Add(new prjXml.Collection("WorkFax", txtFax.Text));
                            //            arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));
                            //            arrLst.Add(new prjXml.Collection("Remark", txtRemark.Text));
                            //            arrLst.Add(new prjXml.Collection("Email", txtEMail.Text));

                            //            // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                            //            arrLst.Add(new prjXml.Collection("UnitName", DdlUnitName.SelectedValue));
                            //            arrLst.Add(new prjXml.Collection("AgentName", DdlAgntName.SelectedValue));
                            //            arrLst.Add(new prjXml.Collection("LinkUnitChannel", LblSlschannel.Text));//Added by Kalyani on 11-12-13 
                            //            arrLst.Add(new prjXml.Collection("LinkUnitChncls", LblChannelSubclass.Text));//Added by Kalyani on 11-12-13 
                            //            arrLst.Add(new prjXml.Collection("LinkStaffChannel", lbluntSalesChnlDesc.Text));//Added by Kalyani on 11-12-13
                            //            arrLst.Add(new prjXml.Collection("LinkStaffChncls", lbluntSubChnlDesc.Text));//Added by Kalyani on 11-12-13
                            //            //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                            //        }

                            //        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                            //        XmlDocument xDoc = new XmlDocument();
                            //        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                            //        strXML = xDoc.OuterXml;

                            //        arrLst.Clear();
                            //        arrResult = channelsetup.UnitMaintUpdate(htable, "prc_AgyAdmin_UpdUnitMaintWithOUTParam");
                            //        htable.Clear();
                            //        if (arrResult.Count > 0)
                            //        {
                            //            if (arrResult[0].ToString() != "F")
                            //            {
                            //                if (arrResult.Count > 0)
                            //                {
                            //                    if (arrResult[0].ToString().Equals("0"))
                            //                    {

                            //                        //Added by swapnesh on 28/5/2013 for showing message box start
                            //                        //lblmsg.Text = "Unit Maintenance done successfully";
                            //                        //lbl3.Text = "Unit Maintenance done successfully";
                            //                        //lbl4.Text = "Unit Code : " + txtUnitCode.Text;
                            //                        //lbl5.Text = "Unit Description : " + txtUntDesc1.Text;
                            //                        //mdlpopup.Show();
                            //                        lbl_popup.Text = "Unit Maintenance done successfully" + "</br></br> Unit Code :  " + txtUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                            //                        // mdlpopup.Show();
                            //                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                            //                        //Added by swapnesh on 28/5/2013 for showing message box end
                            //                        lblmsg.ForeColor = Color.Red;
                            //                        lblmsg.Visible = true;
                            //                        btnUpdate.Enabled = false;
                            //                    }
                            //                    else
                            //                    {
                            //                        switch (arrResult[0].ToString())
                            //                        {
                            //                            case "-1": lblmsg.Text = "Unit Code Not Exist";
                            //                                break;
                            //                            case "-2": lblmsg.Text = "Unit Code Already Exist";
                            //                                break;
                            //                            case "-3": lblmsg.Text = "System Error! Unit Client Code cannot generated";
                            //                                break;
                            //                            case "-4": lblmsg.Text = "Please enter valid Unit Manager Code";
                            //                                break;
                            //                            case "-5": lblmsg.Text = "Unit Manager Agent Type must be Unit Manager and above";
                            //                                break;
                            //                            case "-6": lblmsg.Text = "Unit Manager Agent Type must be Senior Agency Manager and above";
                            //                                break;
                            //                            case "-7": lblmsg.Text = "Senior Agency Manager is not allow manage more than 1 unit";
                            //                                break;
                            //                            case "-8": lblmsg.Text = "Please enter valid Company Unit Code";
                            //                                break;
                            //                            default: lblmsg.Text = "System Error";
                            //                                break;
                            //                        }
                            //                        lblmsg.ForeColor = Color.Red;
                            //                        lblmsg.Visible = true;
                            //                    }
                            //                }
                            //            }
                            //            else
                            //            {
                            //                lblmsg.Text = arrResult[1].ToString();
                            //                lblmsg.ForeColor = Color.Red;
                            //                lblmsg.Visible = true;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            lblmsg.Text = "Error Updating Agent Details.";
                            //            lblmsg.ForeColor = Color.Red;
                            //            lblmsg.Visible = true;
                            //        }

                            //        //Added by swapnesh on 28/5/2013 for changed lblmsg text start
                            //        lbl_popup.Text = "Unit Created done successfully" + "</br></br> Unit Code :  " + txtUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                            //        //Added by swapnesh on 28/5/2013 for changed lblmsg text end

                            //        lblmsg.ForeColor = Color.Red;
                            //        lblmsg.Visible = true;
                            //        btnUpdate.Enabled = false;
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Unit Code Already Exist";
                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Visible = true;
                    }

                }
                else if (Request.QueryString["flag"] == "update")
                {
                    string ChnCreateRul = "";
                    //Added by rachana on 03-07-2013 Selecting ChnCreateRul start
                    htable.Clear();
                    htable.Add("@ChnCls", "");
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@flag", "3");
                    dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                    //Added by rachana on 03-07-2013 Selecting ChnCreateRulSelecting ChnCreateRul end

                    if (dtRead.Read())
                    {
                        ChnCreateRul = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    //Added by rachana on 03-07-2013 for Select ChnCls start
                    htable.Clear();
                    htable.Add("@ChnCls", "");
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@flag", "4");
                    dtRead = objDAL.Common_exec_reader_prc("prc_GetChannelSubCls", htable);
                    //Added by rachana on 03-07-2013 for Select ChnCls end        
                    if (dtRead.Read())
                    {
                        ViewState["UpdChnCls"] = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    if (ChnCreateRul.ToString().Trim() == "2" || ChnCreateRul.ToString().Trim() == "4")
                    {
                        string MgrCreateRul = "";
                        //Added by rachana on 03-07-2013 for Selecting MgrCreateRul start
                        htable.Clear();
                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                        //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

                        if (dtRead.Read())
                        {
                            MgrCreateRul = dtRead[0].ToString();
                        }
                        dtRead.Close();
                        if (MgrCreateRul == "2" || MgrCreateRul == "4")
                        {
                            string strCSCCode = "", strGCN = "";
                            string[] strArrParamNew = new string[6];
                            //Added by rachana on 05-07-2013 for Select CSCCode,GCN  start
                            htable.Clear();
                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            htable.Add("@UnitCode", lblUnitCode.Text);
                            htable.Add("@UnitRank", "");
                            htable.Add("@flag", "3");
                            dtRead = objDAL.Common_exec_reader_prc("Prc_GetAgnTypeCSCcodeforUnitMaint", htable);
                            //Added by rachana on 05-07-2013 for Select CSCCode,GCN  end


                            if (dtRead.Read())
                            {
                                strCSCCode = dtRead[0].ToString();
                                strGCN = dtRead[1].ToString();
                            }
                            dtRead.Close();

                            #region "UpdateBO"

                            int intStatusCode = 0;
                            Insc.MQ.Life.CrpCltCr.MQCrpCltCr oCrpCltCr = new Insc.MQ.Life.CrpCltCr.MQCrpCltCr();
                            Insc.MQ.Life.CrpCltMod.MQCrpCltMod oCrpCltMod = new Insc.MQ.Life.CrpCltMod.MQCrpCltMod();
                            Insc.MQ.Life.CrpCltMod.MQCrpCltModMgr oCrpCltModMgr = new Insc.MQ.Life.CrpCltMod.MQCrpCltModMgr();

                            char[] splitterNew = { '/' };
                            string[] strDt = DateTime.Now.ToString("dd/MM/yyyy").Split(splitterNew);
                            string[] strArrParam = new string[34];

                            strArrParam[0] = strGCN.ToString().Trim(); //ClientCode                                   
                            strArrParam[1] = ""; //@ClientSecureID
                            strArrParam[2] = "0";
                            strArrParam[3] = "RLIC HO";
                            strArrParam[4] = "RLIC HO";
                            strArrParam[5] = "RLIC HO";
                            strArrParam[6] = "Maharashtra";
                            strArrParam[7] = "000000";
                            strArrParam[8] = "0";
                            strArrParam[9] = "0";
                            strArrParam[10] = "IND";
                            strArrParam[11] = "IND";
                            strArrParam[12] = "I";  //@DirectMailIndicator
                            strArrParam[13] = "";   //@EconomyActivity
                            strArrParam[14] = "";    ////@ForTheAttentionof
                            strArrParam[15] = "";      //@FacsimileNo
                            strArrParam[16] = "E";      //@Languag
                            strArrParam[17] = "";       //@LongGivenName
                            strArrParam[18] = "Y";      //@MailingIndicator
                            strArrParam[19] = "";       //@SocialsecurityNo
                            strArrParam[20] = "10";     //@ServicingBranch
                            strArrParam[21] = Convert.ToString(strDt[2]);   //@StartDateYear
                            strArrParam[22] = Convert.ToString(strDt[1]);     //@StartDateMonth
                            strArrParam[23] = Convert.ToString(strDt[0]);     //@StartDate
                            strArrParam[24] = "0";   //@StaffNumber
                            strArrParam[25] = "";       //@StatusCode
                            strArrParam[26] = "";       //@TelegramNo
                            strArrParam[27] = "";       //@TelexNo
                            strArrParam[28] = "N";     //@VIPIndicator
                            strArrParam[29] = "";       //@InternetAddress
                            strArrParam[30] = "";  //@TaxIdNo
                            strArrParam[31] = "";       //@SpecialIndicator
                            strArrParam[32] = "Dummy " + txtUntDesc1.Text;       //@LongGivenName
                            strArrParam[33] = Convert.ToString(Session["CarrierCode"]);

                            //Added by swapnesh on 15/5/2013 for setting value of intStatusCode start
                            //changed by rachana on 12-07-2013 to enable MQ code start    
                            if (strCallType == "1")
                            {
                                intStatusCode = oCrpCltModMgr.FetchClientCreationDetailsFromLA(strArrParam, Convert.ToString(Session["CarrierCode"]), ref oCrpCltMod, ref strErrMsg);
                            }
                            else
                            {
                                intStatusCode = 0;
                            }
                            //changed by rachana on 12-07-2013 to enable MQ code end
                            //Added by swapnesh on 15/5/2013 for setting value of intStatusCode end

                            #endregion

                            strArrParamNew[0] = strCSCCode;
                            strArrParamNew[1] = strGCN;
                            strArrParamNew[2] = "";
                            strArrParamNew[3] = "77777777";
                            strArrParamNew[4] = "Dummy " + txtUntDesc1.Text;
                            strArrParamNew[5] = Convert.ToString(Session["CarrierCode"]);

                            MQCSMod objCSMd = new MQCSMod();
                            MQCSModMgr objCSMdMgr = new MQCSModMgr();

                            //Added by swapnesh on 15/5/2013 for setting value of intStatusCode start
                            //Changed by rachana on 12-07-2013 to enable MQ code start  
                            if (strCallType == "1")
                            {
                                intCode = objCSMdMgr.FetchCSUpdateDetailsFromLA(strArrParamNew, Session["CarrierCode"].ToString(), ref objCSMd, ref strErrMsg);
                            }
                            else
                            {
                                intCode = 0;
                            }
                            //Changed by rachana on 12-07-2013 to enable MQ code end
                            //Added by swapnesh on 15/5/2013 for setting value of intStatusCode end

                            if (intCode == 0)
                            {
                                ViewState["strCSCCode"] = objCSMd.strCSCCODE;
                            }
                        }
                        else
                        {
                            intCode = 0;
                        }
                        if (intCode == 0)
                        {
                            if (txtUnitCode.Visible == true)
                            {
                                UnitCode = txtUnitCode.Text;
                            }
                            else
                            {
                                UnitCode = lblUnitCode.Text;
                            }

                            string SalesUnit;
                            if (rdlYesNo.SelectedValue == "Y")
                            {
                                SalesUnit = "True";
                            }
                            else
                            {
                                SalesUnit = "False";
                            }

                            htable.Clear();//Added by rachana on 03-07-2013
                            htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                            //htable.Add("@RptUnitCode", ddlReportingUnit.SelectedValue);
                            htable.Add("@UnitLevel", Convert.ToInt16(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                            htable.Add("@UnitCode", UnitCode);
                            htable.Add("@UnitDescTha", "");
                            htable.Add("@UnitDescEng", txtUntDesc1.Text);
                            htable.Add("@GeoRegionChs", "");
                            htable.Add("@GeoRegionEng", "");
                            htable.Add("@UnitMgrCode", txtUnitMGRCode.Text);
                            htable.Add("@UnitStatus", ddlUnitStat.SelectedValue);
                            htable.Add("@UnitType", ddlUnitType.SelectedValue);
                            htable.Add("@WorkTel", txtOTel.Text);
                            htable.Add("@WorkFax", txtFax.Text);
                            htable.Add("@Email", txtEMail.Text);
                            htable.Add("@Remark", txtRemark.Text);
                            htable.Add("@cboBizsrc", Request.QueryString["ChannelCode"]);
                            htable.Add("@oldBizsrc", Request.QueryString["ChannelCode"]);
                            htable.Add("@UserId", "");
                            htable.Add("@UserName", Convert.ToString(Session["UserId"].ToString()));
                            htable.Add("@GeoRegion", "");
                            htable.Add("@Action", Request.QueryString["flag"]);
                            htable.Add("@IsSlsUnit", SalesUnit);

                            //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                            htable.Add("@UnitName", DdlUnitName.SelectedValue);
                            htable.Add("@AgentName", DdlAgntName.SelectedValue);
                            htable.Add("@LinkUnitChannel", LblSlschannel.Text); //Added by Kalyani on 11-12-13 
                            htable.Add("@LinkUnitChncls", LblChannelSubclass.Text); //Added by Kalyani on 11-12-13 
                            htable.Add("@LinkStaffChannel", lbluntSalesChnlDesc.Text);//Added by Kalyani on 11-12-13 
                            htable.Add("@LinkStaffChncls", lbluntSubChnlDesc.Text);//Added by Kalyani on 11-12-13 
                            // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end


                            if (txtSALocCode.Visible == true)
                            {
                                htable.Add("@SALocCode", txtSALocCode.Text);
                            }
                            else
                            {
                                htable.Add("@SALocCode", "");
                            }
                            if (txtCompanyUnitCode.Visible == true)
                            {
                                htable.Add("@CmpUnitCode", txtCompanyUnitCode.Text);
                            }
                            else
                            {
                                htable.Add("@CmpUnitCode", "");
                            }
                            htable.Add("@UnitDesc01", txtUntDesc1.Text);
                            htable.Add("@UnitDesc02", txtUntDesc2.Text);
                            htable.Add("@UnitDesc03", txtUntDesc3.Text);
                            //Change of int  to decimal untLvl due to Addition of State in Tied
                            htable.Add("@UnitRank", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            if (txtSMCount.Visible == true)
                            {
                                htable.Add("@SMCount", txtSMCount.Text);
                            }
                            else
                            {
                                htable.Add("@SMCount", System.DBNull.Value);
                            }
                            if (txtPCCode.Visible == true)
                            {
                                htable.Add("@RegistrationNo", txtPCCode.Text);
                            }
                            else
                            {
                                htable.Add("@RegistrationNo", System.DBNull.Value);
                            }
                            ArrayList arrLst = new ArrayList();

                            //Added by swapnesh on 10/02/2014 to insert new details of unit start
                            htable.Add("@InsRefCode", txtInsRefCode.Text.Trim());

                            #region Address
                            htable.Add("@AddressLine1", txtAddrP1.Text);
                            htable.Add("@AddressLine2", txtAddrP2.Text);
                            htable.Add("@AddressLine3", txtAddrP3.Text);
                            htable.Add("@Village", txtVillage.Text.Trim());
                            htable.Add("@City", txtcityp.Text);
                            htable.Add("@State", ddlState.SelectedValue);
                            htable.Add("@Dist", txtDistP.Text.Trim());
                            htable.Add("@Area", txtarea.Text.Trim());
                            htable.Add("@PostCode", txtPinP.Text);
                            htable.Add("@Country", txtCountryCodeP.Text.Trim());
                            #endregion

                            #region Location
                            htable.Add("@Latitude", txtLatitude.Text.Trim());
                            htable.Add("@Longitude", txtLongitude.Text.Trim());
                            #endregion

                            #region Reporting Manager
                            if (tblUnitRptType.Visible != false)
                            {
                                #region Primary Reporting
                                htable.Add("@PriRptTyp", ddlreportingtype.SelectedValue);
                                htable.Add("@PriBasedOn", ddlbasedon.SelectedValue);
                                htable.Add("@PriChnl", ddlchannel.SelectedValue);
                                htable.Add("@PriSubChnl", ddlsubchannel.SelectedValue);
                                htable.Add("@PriUntTyp", ddllevelagttype.SelectedValue);
                                htable.Add("@RptUnitCode", hdnRptUntCode.Value);
                                #endregion

                                if (tblMgr1.Visible != false)
                                {
                                    htable.Add("@MgrRptTyp1", ddlam1reportingtype.SelectedValue);
                                    htable.Add("@MgrBasedOn1", ddlam1basedon.SelectedValue);
                                    htable.Add("@MgrChnl1", ddlam1channel.SelectedValue);
                                    htable.Add("@MgrSubChnl1", ddlam1subchannel.SelectedValue);
                                    htable.Add("@MgrUntTyp1", ddlam1levelagttype.SelectedValue);
                                    htable.Add("@MgrUnitCode1", hdnRptUntCodeMgr1.Value);
                                }
                            }
                            #endregion
                            //Added by swapnesh on 10/02/2014 to insert new details of unit end

                            if (Request.QueryString["flag"] == "update")
                            {
                                //Added by rachana on 03-07-2013 for getting all records on the basis of unitcode end
                                Hashtable hunit = new Hashtable();
                                hunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                hunit.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                hunit.Add("@UnitCode", lblUnitCode.Text);
                                hunit.Add("@Flag", "ALL");//Added by rachana 0n 04-07-2013 for changed proc prc_GetDataonUnitCode
                                dtRead = objDAL.Common_exec_reader_prc("prc_GetDataonUnitCode", hunit);
                                //Added by rachana on 03-07-2013 for for getting all records on the basis of unitcode end
                                if (dtRead.Read())
                                {
                                    arrLst.Add(new prjXml.Collection("CCode", dtRead["CarrierCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("BizSrc", dtRead["BizSrc"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitCode", dtRead["UnitCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitDesc01", dtRead["UnitDesc01"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitType", dtRead["UnitType"].ToString()));
                                    arrLst.Add(new prjXml.Collection("ChnCls", dtRead["ChnCls"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitStatus", dtRead["UnitStatus"].ToString()));
                                    arrLst.Add(new prjXml.Collection("UnitRank", dtRead["UnitRank"].ToString()));
                                    arrLst.Add(new prjXml.Collection("IsSlsUnt", dtRead["IsSlsUnit"].ToString()));
                                    arrLst.Add(new prjXml.Collection("IsSvcCntr", dtRead["IsSvcCntr"].ToString()));
                                    arrLst.Add(new prjXml.Collection("RptUnitCode", dtRead["RptUnitCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("CmsUnitCode", dtRead["CmsUnitCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("Adr1", dtRead["Adr1"].ToString()));
                                    arrLst.Add(new prjXml.Collection("Adr2", dtRead["Adr2"].ToString()));
                                    arrLst.Add(new prjXml.Collection("Adr3", dtRead["Adr3"].ToString()));
                                    arrLst.Add(new prjXml.Collection("City", dtRead["City"].ToString()));
                                    arrLst.Add(new prjXml.Collection("PostCode", dtRead["PostCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("StateCode", dtRead["StateCode"].ToString()));
                                    arrLst.Add(new prjXml.Collection("WorkTel", dtRead["WorkTel"].ToString()));
                                    arrLst.Add(new prjXml.Collection("WorkFax", dtRead["WorkFax"].ToString()));

                                    // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                    arrLst.Add(new prjXml.Collection("UnitName", DdlUnitName.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("AgentName", DdlAgntName.SelectedValue));
                                    arrLst.Add(new prjXml.Collection("LinkUnitChannel", LblSlschannel.Text));//Added by Kalyani on 11-12-13 
                                    arrLst.Add(new prjXml.Collection("LinkUnitChncls", LblChannelSubclass.Text));//Added by Kalyani on 11-12-13 
                                    arrLst.Add(new prjXml.Collection("LinkStaffChannel", lbluntSalesChnlDesc.Text));//Added by Kalyani on 11-12-13
                                    arrLst.Add(new prjXml.Collection("LinkStaffChncls", lbluntSubChnlDesc.Text));//Added by Kalyani on 11-12-13
                                    // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                                }
                                dtRead.Close();
                            }
                            prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                            XmlDocument xDoc = new XmlDocument();
                            xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                            strXML = xDoc.OuterXml;

                            arrLst.Clear();
                            arrResult = channelsetup.UnitMaintUpdate(htable, "prc_AgyAdmin_UpdUnitMaintWithOUTParam");
                            htable.Clear();
                            if (arrResult.Count > 0)
                            {
                                if (arrResult[0].ToString() != "F")
                                {
                                    if (arrResult.Count > 0)
                                    {
                                        if (arrResult[0].ToString().Equals("0"))
                                        {
                                            //Added by rachana on 03-07-2013 for Selecting MgrCreateRul start
                                            htable.Clear();
                                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                                            htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                            dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                                            //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end
                                            if (dtRead.Read())
                                            {
                                                MgrCreateRul = dtRead[0].ToString();
                                            }
                                            dtRead.Close();
                                            if (MgrCreateRul == "1")
                                            {
                                                string strAgnCode1 = "";
                                                //Added by rachana on 05-07-2013 for Select MgrCode start
                                                htable.Clear();
                                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                                htable.Add("@UnitCode", lblUnitCode.Text);
                                                htable.Add("@LBLUnitCode", "");
                                                htable.Add("@LegalName", txtUntDesc1.Text);
                                                htable.Add("@flag", "SELUPDQRYa");
                                                dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                                //Added by rachana on 05-07-2013 for Select MgrCode end

                                                if (dtRead.Read())
                                                {
                                                    strAgnCode1 = dtRead[0].ToString();
                                                }
                                                dtRead.Close();
                                            }
                                            else if (MgrCreateRul == "2")
                                            {
                                                string strAgnCode1 = "";
                                                //Added by rachana on 05-07-2013 for Select MgrCode  start
                                                htable.Clear();
                                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                                htable.Add("@UnitCode", lblUnitCode.Text);
                                                htable.Add("@LBLUnitCode", lblUnitCode.Text);
                                                htable.Add("@LegalName", txtUntDesc1.Text);
                                                htable.Add("@flag", "SELUPDQRYb");
                                                dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                                //Added by rachana on 05-07-2013 for Select MgrCode end

                                                if (dtRead.Read())
                                                {
                                                    strAgnCode1 = dtRead[0].ToString();
                                                }
                                                dtRead.Close();
                                            }
                                            else if (MgrCreateRul == "4")
                                            {
                                                string strAgnCode1 = "";
                                                //Added by rachana on 05-07-2013 for Select MgrCode start
                                                htable.Clear();
                                                htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                                htable.Add("@UnitCode", lblUnitCode.Text);
                                                htable.Add("@LBLUnitCode", lblUnitCode.Text);
                                                htable.Add("@LegalName", txtUntDesc1.Text);
                                                htable.Add("@flag", "SELUPDQRYb");
                                                dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                                //Added by rachana on 05-07-2013 for Select MgrCode end
                                                if (dtRead.Read())
                                                {
                                                    strAgnCode1 = dtRead[0].ToString();
                                                }
                                                dtRead.Close();
                                            }
                                            //Added by swapnesh on 28/5/2013 for showing message box start
                                            //lbl3.Visible = true;
                                            //lblmsg.Text = "Admin Unit Maintenance done successfully";
                                            //lbl3.Text = "Admin Unit Maintenance done successfully";
                                            //lbl4.Text = "Unit Code : " + lblUnitCode.Text;
                                            //lbl5.Text = "Unit Description : " + txtUntDesc1.Text;
                                            //mdlpopup.Show();
                                            lbl_popup.Text = "Admin Unit Maintenance done successfully" + "</br></br> Unit Code :  " + lblUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                                            // mdlpopup.Show();
                                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                            //Added by swapnesh on 28/5/2013 for showing message box end
                                            lblmsg.ForeColor = Color.Red;
                                            lblmsg.Visible = true;
                                            btnUpdate.Enabled = false;
                                            if (ViewState["strCSCCode"] != null)
                                            {
                                                lblCSCCodeLA.Visible = true;
                                                lblCSCCode.Visible = true;
                                                lblCSCCode.Text = ViewState["strCSCCode"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            switch (arrResult[0].ToString())
                                            {
                                                case "-1": lblmsg.Text = "Unit Code Not Exist";
                                                    break;
                                                case "-2": lblmsg.Text = "Unit Code Already Exist";
                                                    break;
                                                case "-3": lblmsg.Text = "System Error! Unit Client Code cannot generated";
                                                    break;
                                                case "-4": lblmsg.Text = "Please enter valid Unit Manager Code";
                                                    break;
                                                case "-5": lblmsg.Text = "Unit Manager Agent Type must be Unit Manager and above";
                                                    break;
                                                case "-6": lblmsg.Text = "Unit Manager Agent Type must be Senior Agency Manager and above";
                                                    break;
                                                case "-7": lblmsg.Text = "Senior Agency Manager is not allow manage more than 1 unit";
                                                    break;
                                                case "-8": lblmsg.Text = "Please enter valid Company Unit Code";
                                                    break;
                                                default: lblmsg.Text = "System Error";
                                                    break;
                                            }
                                            lblmsg.ForeColor = Color.Red;
                                            lblmsg.Visible = true;
                                        }
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = arrResult[1].ToString();
                                    lblmsg.ForeColor = Color.Red;
                                    lblmsg.Visible = true;
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Error Updating Agent Details.";
                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Visible = true;
                            }
                        }
                        else
                        {
                            lblmsg.Text = strErrMsg;
                            ViewState["ErrorMsg"] = strErrMsg;
                            btnUpdate.Enabled = false;
                        }
                    }
                    else
                    {
                        string MgrCreateRul = "";
                        //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                        htable.Clear();
                        htable.Add("@ChnCls", Request.QueryString["ChannelCode"].ToString());
                        htable.Add("@BizSrc", Request.QueryString["SubCls"].ToString());
                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                        //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

                        if (dtRead.Read())
                        {
                            MgrCreateRul = dtRead[0].ToString();
                        }
                        dtRead.Close();


                        if (txtUnitCode.Visible == true)
                        {
                            UnitCode = txtUnitCode.Text;
                        }
                        else
                        {
                            UnitCode = lblUnitCode.Text;
                        }

                        string SalesUnit;
                        if (rdlYesNo.SelectedValue == "Y")
                        {
                            SalesUnit = "True";
                        }
                        else
                        {
                            SalesUnit = "False";
                        }

                        htable.Clear(); //Added by rachana 03-07-2013
                        htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                        //htable.Add("@RptUnitCode", ddlReportingUnit.SelectedValue);
                        //Change of int  to decimal  due to Addition of State in Tied
                        htable.Add("@UnitLevel", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                        htable.Add("@UnitCode", UnitCode);
                        htable.Add("@UnitDescTha", "");
                        htable.Add("@UnitDescEng", txtUntDesc1.Text);
                        htable.Add("@GeoRegionChs", "");
                        htable.Add("@GeoRegionEng", "");
                        htable.Add("@UnitMgrCode", txtUnitMGRCode.Text);
                        htable.Add("@UnitStatus", ddlUnitStat.SelectedValue);
                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                        htable.Add("@WorkTel", txtOTel.Text);
                        htable.Add("@WorkFax", txtFax.Text);
                        htable.Add("@Email", txtEMail.Text);
                        htable.Add("@Remark", txtRemark.Text);
                        htable.Add("@cboBizsrc", Request.QueryString["ChannelCode"]);
                        htable.Add("@oldBizsrc", Request.QueryString["ChannelCode"]);
                        htable.Add("@UserId", "");
                        htable.Add("@UserName", Convert.ToString(Session["UserId"].ToString()));
                        htable.Add("@GeoRegion", "");
                        htable.Add("@Action", Request.QueryString["flag"]);
                        htable.Add("@IsSlsUnit", SalesUnit);

                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                        htable.Add("@UnitName", DdlUnitName.SelectedValue);
                        htable.Add("@AgentName", DdlAgntName.SelectedValue);
                        htable.Add("@LinkUnitChannel", LblSlschannel.Text); //Added by Kalyani on 11-12-13 
                        htable.Add("@LinkUnitChncls", LblChannelSubclass.Text); //Added by Kalyani on 11-12-13 
                        htable.Add("@LinkStaffChannel", lbluntSalesChnlDesc.Text);//Added by Kalyani on 11-12-13 
                        htable.Add("@LinkStaffChncls", lbluntSubChnlDesc.Text);//Added by Kalyani on 11-12-13 
                        //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                        if (txtSALocCode.Visible == true)
                        {
                            htable.Add("@SALocCode", txtSALocCode.Text);
                        }
                        else
                        {
                            htable.Add("@SALocCode", "");
                        }
                        if (txtCompanyUnitCode.Visible == true)
                        {
                            htable.Add("@CmpUnitCode", txtCompanyUnitCode.Text);
                        }
                        else
                        {
                            htable.Add("@CmpUnitCode", "");
                        }
                        htable.Add("@UnitDesc01", txtUntDesc1.Text);
                        htable.Add("@UnitDesc02", txtUntDesc2.Text);
                        htable.Add("@UnitDesc03", txtUntDesc3.Text);
                        //Change of int  to decimal untLvl due to Addition of State in Tied
                        htable.Add("@UnitRank", Convert.ToDecimal(objclsUM.GetUnitLevel(Request.QueryString["UnitTypeCode"], CarrierCode, strChannelCode)));
                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                        htable.Add("@SapUnit",ViewState["sapcode"].ToString());// Session["unitcode"]);//Added by usha on 20.09.2018
                        if (txtSMCount.Visible == true)
                        {
                            htable.Add("@SMCount", txtSMCount.Text);
                        }
                        else
                        {
                            htable.Add("@SMCount", System.DBNull.Value);
                        }
                        if (txtPCCode.Visible == true)
                        {
                            htable.Add("@RegistrationNo", txtPCCode.Text);
                        }
                        else
                        {
                            htable.Add("@RegistrationNo", System.DBNull.Value);
                        }

                        //Added by swapnesh on 10/02/2014 to insert new details of unit start
                        htable.Add("@InsRefCode", txtInsRefCode.Text.Trim());

                        #region Address
                        htable.Add("@AddressLine1", txtAddrP1.Text);
                        htable.Add("@AddressLine2", txtAddrP2.Text);
                        htable.Add("@AddressLine3", txtAddrP3.Text);
                        htable.Add("@Village", txtVillage.Text.Trim());
                        htable.Add("@City", txtcityp.Text);
                        htable.Add("@State", ddlState.SelectedValue);
                        htable.Add("@Dist", txtDistP.Text.Trim());
                        htable.Add("@Area", txtarea.Text.Trim());
                        htable.Add("@PostCode", txtPinP.Text);
                        htable.Add("@Country", txtCountryCodeP.Text.Trim());
                        #endregion

                        #region Location
                        htable.Add("@Latitude", txtLatitude.Text.Trim());
                        htable.Add("@Longitude", txtLongitude.Text.Trim());
                        #endregion

                        #region Reporting Manager
                        if (tblUnitRptType.Visible != false)
                        {
                            #region Primary Reporting
                            htable.Add("@PriRptTyp", ddlreportingtype.SelectedValue);
                            htable.Add("@PriBasedOn", ddlbasedon.SelectedValue);
                            htable.Add("@PriChnl", ddlchannel.SelectedValue);
                            htable.Add("@PriSubChnl", ddlsubchannel.SelectedValue);
                            htable.Add("@PriUntTyp", ddllevelagttype.SelectedValue);
                            htable.Add("@RptUnitCode", hdnRptUntCode.Value);
                            #endregion

                            if (tblMgr1.Visible != false)
                            {
                                htable.Add("@MgrRptTyp1", ddlam1reportingtype.SelectedValue);
                                htable.Add("@MgrBasedOn1", ddlam1basedon.SelectedValue);
                                htable.Add("@MgrChnl1", ddlam1channel.SelectedValue);
                                htable.Add("@MgrSubChnl1", ddlam1subchannel.SelectedValue);
                                htable.Add("@MgrUntTyp1", ddlam1levelagttype.SelectedValue);
                                htable.Add("@MgrUnitCode1", hdnRptUntCodeMgr1.Value);
                            }
                        }
                        #endregion
                        //Added by swapnesh on 10/02/2014 to insert new details of unit end

                        ArrayList arrLst = new ArrayList();
                        if (Request.QueryString["flag"] == "update")
                        {
                            //Added by rachana on 03-07-2013 for all records end
                            Hashtable hunit = new Hashtable();

                            hunit.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                            hunit.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                            hunit.Add("@UnitCode", lblUnitCode.Text);
                            hunit.Add("@Flag", "ALL");//Added by rachana 0n 04-07-2013 for changed proc prc_GetDataonUnitCode
                            dtRead = objDAL.Common_exec_reader_prc("prc_GetDataonUnitCode", hunit);
                            //Added by rachana on 03-07-2013 for sll records end

                            if (dtRead.Read())
                            {
                                arrLst.Add(new prjXml.Collection("CCode", dtRead["CarrierCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("BizSrc", dtRead["BizSrc"].ToString()));
                                arrLst.Add(new prjXml.Collection("UnitCode", dtRead["UnitCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("UnitDesc01", dtRead["UnitDesc01"].ToString()));
                                arrLst.Add(new prjXml.Collection("UnitType", dtRead["UnitType"].ToString()));
                                arrLst.Add(new prjXml.Collection("ChnCls", dtRead["ChnCls"].ToString()));
                                arrLst.Add(new prjXml.Collection("UnitStatus", dtRead["UnitStatus"].ToString()));
                                arrLst.Add(new prjXml.Collection("UnitRank", dtRead["UnitRank"].ToString()));
                                arrLst.Add(new prjXml.Collection("IsSlsUnt", dtRead["IsSlsUnit"].ToString()));
                                arrLst.Add(new prjXml.Collection("IsSvcCntr", dtRead["IsSvcCntr"].ToString()));
                                arrLst.Add(new prjXml.Collection("RptUnitCode", dtRead["RptUnitCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("CmsUnitCode", dtRead["CmsUnitCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("Adr1", dtRead["Adr1"].ToString()));
                                arrLst.Add(new prjXml.Collection("Adr2", dtRead["Adr2"].ToString()));
                                arrLst.Add(new prjXml.Collection("Adr3", dtRead["Adr3"].ToString()));
                                arrLst.Add(new prjXml.Collection("City", dtRead["City"].ToString()));
                                arrLst.Add(new prjXml.Collection("PostCode", dtRead["PostCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("StateCode", dtRead["StateCode"].ToString()));
                                arrLst.Add(new prjXml.Collection("WorkTel", dtRead["WorkTel"].ToString()));
                                arrLst.Add(new prjXml.Collection("WorkFax", dtRead["WorkFax"].ToString()));

                                // Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content start
                                arrLst.Add(new prjXml.Collection("UnitName", DdlUnitName.SelectedValue));
                                arrLst.Add(new prjXml.Collection("AgentName", DdlAgntName.SelectedValue));
                                arrLst.Add(new prjXml.Collection("LinkUnitChannel", LblSlschannel.Text));//Added by Kalyani on 11-12-13 
                                arrLst.Add(new prjXml.Collection("LinkUnitChncls", LblChannelSubclass.Text));//Added by Kalyani on 11-12-13 
                                arrLst.Add(new prjXml.Collection("LinkStaffChannel", lbluntSalesChnlDesc.Text));//Added by Kalyani on 11-12-13
                                arrLst.Add(new prjXml.Collection("LinkStaffChncls", lbluntSubChnlDesc.Text));//Added by Kalyani on 11-12-13
                                //Added by Kalyani on 21-11-13 for Link to master unit checkbox and Link to staff checkbox content end

                            }
                            dtRead.Close();
                        }
                        prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                        XmlDocument xDoc = new XmlDocument();
                        xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                        strXML = xDoc.OuterXml;

                        arrLst.Clear();
                        arrResult = channelsetup.UnitMaintUpdate(htable, "prc_AgyAdmin_UpdUnitMaintWithOUTParam");
                        htable.Clear();
                        if (arrResult.Count > 0)
                        {
                            if (arrResult[0].ToString() != "F")
                            {
                                if (arrResult.Count > 0)
                                {
                                    if (arrResult[0].ToString().Equals("0"))
                                    {
                                        //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
                                        htable.Clear();
                                        htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                        htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                        htable.Add("@UnitType", ddlUnitType.SelectedValue);
                                        dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
                                        //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

                                        if (dtRead.Read())
                                        {
                                            //Comented by usha on
                                            //MgrCreateRul = dtRead[0].ToString();

                                            PositionReq = dtRead[0].ToString();
                                            strAgentType = dtRead[1].ToString();
                                        }
                                        dtRead.Close();

                                        //Comented  by usha  on 26.02.2019
                                        //if (MgrCreateRul == "1")
                                        // {

                                        if (PositionReq == "True")
                                        {

                                            dtRead.Close();
                                            htable.Clear();//Added by Rachana on 05-07-2013
                                            htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                           // htable.Add("@AgentCode ", ViewState["AgentCode"].ToString());
                                            htable.Add("@AgentStatus ", "IF");
                                            htable.Add("@CustomerId", "90021917");
                                            htable.Add("@Exclusive ", "Y");
                                            htable.Add("@AgentName ", txtUntDesc1.Text);
                                            htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            htable.Add("@AgentType", strAgentType);
                                            htable.Add("@AgentClass", "");
                                            htable.Add("@PayMethod", "CQ");
                                            htable.Add("@Currency ", "INR");
                                            htable.Add("@CommCls", "0002");
                                            htable.Add("@PayFreq ", "12");
                                            htable.Add("@AccPayCode", "");
                                            htable.Add("@MinAmt", 0);
                                            htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
                                            htable.Add("@RecruitDate ", System.DBNull.Value);
                                            htable.Add("@BEBranchCode", "10");
                                            htable.Add("@RecruitAgntCode", "");
                                            htable.Add("@BEAreaCode ", "10");
                                            htable.Add("@ImmLeader ", "");
                                            htable.Add("@BESMCode ", "");
                                            htable.Add("@UnitCode ", lblUnitCode.Text);
                                            htable.Add("@DateTerminated", System.DBNull.Value);
                                            htable.Add("@BlackListStatus", "");
                                            htable.Add("@EmployeeCode", "77777777");
                                            htable.Add("@MgrCode", strMgrCode);
                                            htable.Add("@BizLicsNo", "");
                                            htable.Add("@BizLicsExpDate", System.DBNull.Value);
                                            htable.Add("@DeductTax", "");
                                            htable.Add("@TaxCode", "");
                                            dataAccess.execute_sprc("prc_AgyAdmin_DummyInsertMgr", htable);

                                            //htable.Clear();
                                            //htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                            //htable.Add("@BizSrc ", Request.QueryString["ChannelCode"]);
                                            //htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            //htable.Add("@UnitCode ", txtUnitCode.Text);
                                            //htable.Add("@MgrCode", ViewState["AgentCode"].ToString());
                                            //htable.Add("@MgrType", strNewAgnType);
                                            //htable.Add("@DirectMgrType", strAgentType);
                                            //htable.Add("@DirectMgrCode", strMgrCode);
                                            //htable.Add("@EMPCode", "77777777");
                                            //htable.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                            //dataAccess.execute_sprc("Prc_AgyAdmin_InsertUntMgr", htable);
                                            //htable.Clear();
                                            //if (MgrCreateRul == "1")
                                            //{
                                            //    string strAgnCode1 = "";
                                            //    //Added by rachana on 05-07-2013 for Select MgrCode  start
                                            //    htable.Clear();
                                            //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                            //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            //    htable.Add("@UnitCode", lblUnitCode.Text);
                                            //    htable.Add("@LBLUnitCode", "");
                                            //    htable.Add("@LegalName", txtUntDesc1.Text);
                                            //    htable.Add("@flag", "SELUPDQRYa");
                                            //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                            //    //Added by rachana on 05-07-2013 for Select MgrCode  end

                                            //    if (dtRead.Read())
                                            //    {
                                            //        strAgnCode1 = dtRead[0].ToString();
                                            //    }
                                            //    dtRead.Close();
                                            //}
                                            //else if (MgrCreateRul == "2")
                                            //{
                                            //    string strAgnCode1 = "";
                                            //    //Added by rachana on 05-07-2013 for Select MgrCod start
                                            //    htable.Clear();
                                            //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                            //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            //    htable.Add("@UnitCode", lblUnitCode.Text);
                                            //    htable.Add("@LBLUnitCode", "");
                                            //    htable.Add("@LegalName", txtUntDesc1.Text);
                                            //    htable.Add("@flag", "SELUPDQRYa");
                                            //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                            //    //Added by rachana on 05-07-2013 for Select MgrCod end

                                            //    if (dtRead.Read())
                                            //    {
                                            //        strAgnCode1 = dtRead[0].ToString();
                                            //    }
                                            //    dtRead.Close();
                                            //}
                                            //else if (MgrCreateRul == "4")
                                            //{
                                            //    string strAgnCode1 = "";
                                            //    //Added by rachana on 05-07-2013 for select mgrcode start
                                            //    htable.Clear();
                                            //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                            //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            //    htable.Add("@UnitCode", lblUnitCode.Text);
                                            //    htable.Add("@LBLUnitCode", "");
                                            //    htable.Add("@LegalName", txtUntDesc1.Text);
                                            //    htable.Add("@flag", "SELUPDQRYa");
                                            //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                            //    //Added by rachana on 05-07-2013 for mgrcode selection end

                                            //    if (dtRead.Read())
                                            //    {
                                            //        strAgnCode1 = dtRead[0].ToString();
                                            //    }
                                            //    dtRead.Close();
                                            //}
                                            //else if (MgrCreateRul == "6")
                                            //{
                                            //    string strAgnCode1 = "";
                                            //    //Added by rachana on 05-07-2013 for Select MgrCode start
                                            //    htable.Clear();
                                            //    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                                            //    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                                            //    htable.Add("@UnitCode", lblUnitCode.Text);
                                            //    htable.Add("@LBLUnitCode", "");
                                            //    htable.Add("@LegalName", txtUntDesc1.Text);
                                            //    htable.Add("@flag", "SELUPDQRYa");
                                            //    dtRead = objDAL.Common_exec_reader_prc("Prc_GetUntMgrUpdateAgn", htable);
                                            //    //Added by rachana on 05-07-2013 for Select MgrCode end

                                            //    if (dtRead.Read())
                                            //    {
                                            //        strAgnCode1 = dtRead[0].ToString();
                                            //    }
                                            //    dtRead.Close();
                                            //}
                                            ////Added by swapnesh on 28/5/2013 for showing message box start
                                            //lbl3.Visible = true;
                                            //lblmsg.Text = "Unit Maintenance done successfully";
                                            //lbl3.Text = "Unit Maintenance done successfully";
                                            //lbl4.Text = "Unit Code : " + lblUnitCode.Text;
                                            //lbl5.Text = "Unit Description : " + txtUntDesc1.Text;
                                            //mdlpopup.Show();
                                            lbl_popup.Text = "Unit Maintenance done successfully" + "</br></br> Unit Code :  " + lblUnitCode.Text.Trim() + "</br></br> Unit Description : " + txtUntDesc1.Text;
                                            // mdlpopup.Show();
                                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                            //Added by swapnesh on 28/5/2013 for showing message box end
                                            lblmsg.ForeColor = Color.Red;
                                            lblmsg.Visible = true;
                                            btnUpdate.Enabled = false;

                                        }
                                    }
                                    else
                                    {
                                        switch (arrResult[0].ToString())
                                        {
                                            case "-1": lblmsg.Text = "Unit Code Not Exist";
                                                break;
                                            case "-2": lblmsg.Text = "Unit Code Already Exist";
                                                break;
                                            case "-3": lblmsg.Text = "System Error! Unit Client Code cannot generated";
                                                break;
                                            case "-4": lblmsg.Text = "Please enter valid Unit Manager Code";
                                                break;
                                            case "-5": lblmsg.Text = "Unit Manager Agent Type must be Unit Manager and above";
                                                break;
                                            case "-6": lblmsg.Text = "Unit Manager Agent Type must be Senior Agency Manager and above";
                                                break;
                                            case "-7": lblmsg.Text = "Senior Agency Manager is not allow manage more than 1 unit";
                                                break;
                                            case "-8": lblmsg.Text = "Please enter valid Company Unit Code";
                                                break;
                                            default: lblmsg.Text = "System Error";
                                                break;
                                        }
                                        lblmsg.ForeColor = Color.Red;
                                        lblmsg.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                lblmsg.Text = arrResult[1].ToString();
                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Visible = true;
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Error Updating Agent Details.";
                            lblmsg.ForeColor = Color.Red;
                            lblmsg.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ex.Message);
                var script = string.Format("alert({0});", message);
                ClientScript.RegisterStartupScript(Page.GetType(), "", script, true);
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            if (Request.QueryString["TPBizSrc"] == null)
            {
                //Added by swapnesh on 28/5/2013 for changed lblmsg text start
                if (lblmsg.Text == "Admin Unit Maintenance done successfully")
                //Added by swapnesh on 28/5/2013 for changed lblmsg text end
                {
                    ErrMsg = "S";
                }
                else
                {
                    ErrMsg = "E";
                }
            }
            else
            {
                //Added by swapnesh on 28/5/2013 for changed lblmsg text start
                if (lblmsg.Text == "Unit Maintenance done successfully")
                //Added by swapnesh on 28/5/2013 for changed lblmsg text end
                {
                    ErrMsg = "S";
                }
                else
                {
                    ErrMsg = "E";
                }
            }
            if (Request.QueryString["flag"] == "add")
            {
                AuditType = "IN";
            }
            else
            {
                AuditType = "UP";
            }
            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "SQ", ErrCode = "", ErrDsc = lblmsg.Text, ErrDtl = "";
            channelsetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + Request.QueryString["ChannelCode"] + UnitCode + ddlChnnlSubClass.SelectedValue, "Unt", "Update,clsChannelSetup.cs", "prc_AgyAdmin_UpdUnitMaintWithOUTParam", Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
            hdnCreateRule.Value = "";

        }
        #endregion

        #region BUTTON btnCancel Click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TPBizSrc"] == null)
            {
                Response.Redirect("UnitMaint.aspx?ChannelCode=" + Request.QueryString["ChannelCode"] + "&ULevel=" + Request.QueryString["ULevel"] + "&UnitCode=" + Request.QueryString["UnitCode"] + "&fgPage=C" + "&RptUntCode=" + Request.QueryString["RptUntCode"] + "&SubCls=" + Request.QueryString["SubCls"]);
            }
            else
            {
                Response.Redirect("UnitMaint.aspx?BizSrc=" + Request.QueryString["ChannelCode"] + "&ChannelCode=" + Request.QueryString["ChannelCode"] + "&ULevel=" + Request.QueryString["ULevel"] + "&UnitCode=" + Request.QueryString["UnitCode"] + "&fgPage=C" + "&RptUntCode=" + Request.QueryString["RptUntCode"] + "&SubCls=" + Request.QueryString["SubCls"] + "&ChnCls=" + Request.QueryString["TPChnCls"]);
            }
        }
        #endregion

        #region ddlChnnlSubClass SelectedIndexChanged
        protected void ddlChnnlSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                dsResult = new DataSet();
                dsResult = objDAL.GetDataSetForPrc("prc_UnitSearch", htable);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        objCommonU.FillDropDown(ddlUnitType, dsResult.Tables[0], "UnitType", "UnitDesc01");
                    }
                    else
                    {
                        ddlUnitType.Items.Clear();
                        ddlUnitType.Items.Insert(0, new ListItem("Select", ""));
                    }
                }
                else
                {
                    ddlUnitType.Items.Clear();
                    ddlUnitType.Items.Insert(0, new ListItem("Select", ""));
                }
                ddlChnnlSubClass.Focus();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
                lblmsg.Visible = true;
                lblmsg.ForeColor = Color.Red;
                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                string sRet = oInfo.Name;
                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                String LogClassName = method.ReflectedType.Name;
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            }
            ddlChnnlSubClass.Focus();
        }
        #endregion

        #region RADIOBUTTON rdlYesNo SelectedIndexChanged
        protected void rdlYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetCmpUnitCode();
            rdlYesNo.Focus();

        }
        #endregion

        #region ddlReportingUnit_SelectedIndexChanged
        protected void ddlReportingUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCmpUnitCode();
        }
        #endregion

        #region FUNCTION GetCmpUnitCode
        private void GetCmpUnitCode()
        {
            SqlDataReader dtRead;
            string strMgrCreaterule = "";
            //Added by rachana on 28-07-2013 for Selecting MgrCreateRul start
            htable.Clear();
            htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
            htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
            htable.Add("@UnitType", ddlUnitType.SelectedValue);
            dtRead = objDAL.Common_exec_reader_prc("prc_GetMgrCreateRulforUnitmaint", htable);
            //Added by rachana on 03-07-2013 for Selecting MgrCreateRul end

            if (dtRead.Read())
            {
                strMgrCreaterule = dtRead[0].ToString();
            }
            dtRead.Close();
            if (rdlYesNo.SelectedValue == "Y")
            {
                if (strMgrCreaterule == "2")
                {
                    //Added by rachana on 05-07-2013 for Select CmsUnitCode start
                    htable.Clear();
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                    htable.Add("@UnitCode", hdnRptUntCode.Value);
                    htable.Add("@flag", "cms");
                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                    //Added by rachana on 05-07-2013 for Select CmsUnitCode end

                    if (dtRead.Read())
                    {
                        txtCompanyUnitCode.Enabled = true;
                        txtCompanyUnitCode.Text = dtRead[0].ToString();
                    }
                    dtRead.Close();
                }
                else if (strMgrCreaterule == "6")
                {
                    //Added by rachana on 05-07-2013 for Select CmsUnitCode start
                    htable.Clear();
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                    htable.Add("@UnitCode", hdnRptUntCode.Value);
                    htable.Add("@flag", "cms");
                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                    //Added by rachana on 05-07-2013 for Select CmsUnitCode end

                    if (dtRead.Read())
                    {
                        txtCompanyUnitCode.Enabled = true;
                        txtCompanyUnitCode.Text = dtRead[0].ToString();
                    }
                    dtRead.Close();
                }
                else if (strMgrCreaterule == "4")
                {
                    //Added by rachana on 05-07-2013 for Selecting CmsUnitCode start
                    htable.Clear();
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                    htable.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                    //htable.Add("@UnitCode", ddlReportingUnit.SelectedValue);
                    htable.Add("@UnitCode", hdnRptUntCode.Value);
                    htable.Add("@flag", "cms");
                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetCMSUnitCodeRptUnitcode", htable);
                    //Added by rachana on 05-07-2013 for Selecting CmsUnitCode end

                    if (dtRead.Read())
                    {
                        txtCompanyUnitCode.Enabled = true;
                        txtCompanyUnitCode.Text = dtRead[0].ToString();
                    }
                    dtRead.Close();
                }
                else if (strMgrCreaterule == "0")
                {
                    txtCompanyUnitCode.Text = "";
                    txtCompanyUnitCode.Enabled = false;

                }
                else if (strMgrCreaterule == "1")
                {
                    txtCompanyUnitCode.Text = "";
                    txtCompanyUnitCode.Enabled = false;
                }
                else if (strMgrCreaterule == "3")
                {
                    btnCmsUntCode.Visible = true;
                    txtCompanyUnitCode.Enabled = true;
                    //btnCmsUntCode.Focus();
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Please Select Company UnitCode Button');", true);


                }
            }
            else if (rdlYesNo.SelectedValue == "N")
            {
                txtCompanyUnitCode.Text = "";
                txtCompanyUnitCode.Enabled = false;
            }
        }
        #endregion

        #region for Link to master unit checkbox and Link to staff checkbox content
        protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLinkedMasterUnit();
            fillRptMgrDtls();
            ddlUnitType.Focus();
        }

        public void GetLinkedMasterUnit()
        {
            DataSet dsflag;
            Hashtable hflag = new Hashtable();
            hflag.Add("@Bizsrc", lblSalesChannel.Text);
            hflag.Add("@Chncls", ddlChnnlSubClass.SelectedValue.ToString());
            //get unit type from dropdown for NEW unit creation 
            if (Request.QueryString["F"] != null)
            {
                if (Request.QueryString["F"].ToString() == "N")
                {
                    hflag.Add("@UnitType", ddlUnitType.SelectedValue.ToString());

                }
            }
            //get unit type from grid for EDIT unit creation 
            else
            {
                htUnitType.Clear();
                dsUnitType = null;
                htUnitType.Add("@UnitCode", Request.QueryString["UnitCode"].ToString());
                dsUnitType = objDAL.GetDataSetForPrc("Prc_GetUnitTypeValue", htUnitType);
                if (dsUnitType.Tables[0].Rows.Count > 0)
                {
                    hflag.Add("@UnitType", dsUnitType.Tables[0].Rows[0]["unittype"].ToString());
                }
            }

            //Procedure to retrieve check and uncheck value of LnkMstUnit and LnkStaffFlag 
            dsflag = objDAL.GetDataSetForPrc("Prc_GetFlagforUNTData", hflag);
            if (dsflag.Tables.Count > 0)
            {
                if (dsflag.Tables[0].Rows.Count > 0)
                {
                    // Link to master unit checkbox is checked
                    if ((dsflag.Tables[0].Rows[0]["LnkMstUnit"].ToString() == "True") && (dsflag.Tables[0].Rows[0]["LnkStaffFlag"].ToString() == "False"))
                    {
                        htable.Clear();
                        //get unit type from dropdown for NEW unit creation 
                        if (Request.QueryString["F"] != null)
                        {
                            if (Request.QueryString["F"].ToString() == "N")
                            {

                                htable.Add("@UnitType", ddlUnitType.SelectedValue.ToString());

                            }
                        }
                        //get unit type from grid for EDIT unit creation 
                        else
                        {
                            htUnitType.Clear();
                            dsUnitType.Clear();
                            htUnitType.Add("@UnitCode", Request.QueryString["UnitCode"].ToString());
                            dsUnitType = objDAL.GetDataSetForPrc("Prc_GetUnitTypeValue", htUnitType);
                            htable.Add("@UnitType", dsUnitType.Tables[0].Rows[0]["unittype"].ToString());
                        }
                        htable.Add("@bizsrc", lblSalesChannel.Text);
                        htable.Add("@chncls", ddlChnnlSubClass.SelectedValue.ToString());
                        htable.Add("@flag", "2");
                        //Procedure to get Link to master unit and Link to staff data
                        dsResult = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows[0]["LnkMstUnit"].ToString() == "True")
                                {
                                    trMasterLink.Visible = true;
                                    LblBizsrc.Visible = true;
                                    LblSlschannel.Visible = true;
                                    LblSubclass.Visible = true;
                                    LblChannelSubclass.Visible = true;
                                    LblUntcodeLink.Visible = true;
                                    LblUnitType.Visible = true;

                                    trStaffLink.Visible = false;
                                    lbluntSalesChnl.Visible = false;
                                    lbluntSalesChnlDesc.Visible = false;
                                    lbluntSubChnl.Visible = false;
                                    lbluntSubChnlDesc.Visible = false;
                                    lblAgntType.Visible = false;
                                    LblAgentType.Visible = false;

                                    LblSlschannel.Text = dsResult.Tables[0].Rows[0]["BizSrcLinkDecs"].ToString().Trim();
                                    LblChannelSubclass.Text = dsResult.Tables[0].Rows[0]["ChnclsLinkDesc"].ToString().Trim();
                                    LblUnitType.Text = dsResult.Tables[0].Rows[0]["UnitRankDesc01"].ToString().Trim();
                                    LblUnitName.Visible = true;
                                    DdlUnitName.Visible = true;
                                    LblAgentName.Visible = false;
                                    DdlAgntName.Visible = false;
                                    DdlUnitName.Items.Insert(0, new ListItem("Select", ""));

                                    htable.Clear();
                                    htable.Add("@flag", "1");
                                    htable.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrcLink"].ToString().Trim());
                                    htable.Add("@chncls", dsResult.Tables[0].Rows[0]["ChnClsLink"].ToString().Trim());
                                    htable.Add("@UnitType", dsResult.Tables[0].Rows[0]["UnitRank"].ToString().Trim());

                                    DataSet dsUnit;
                                    //Procedure with flag 1 to fill UnitName dropdown
                                    dsUnit = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                                    if (dsUnit.Tables.Count > 0)
                                    {
                                        if (dsUnit.Tables[0].Rows.Count > 0)
                                        {
                                            objCommonU.FillDropDown(DdlUnitName, dsUnit.Tables[0], "UNitcode", "UnitLegalName");
                                            DdlUnitName.Items.Insert(0, new ListItem("Select", ""));

                                        }
                                    }
                                }
                            }
                        }
                    }

                   // Link to staff checkbox is checked
                    else if ((dsflag.Tables[0].Rows[0]["LnkMstUnit"].ToString() == "False") && (dsflag.Tables[0].Rows[0]["LnkStaffFlag"].ToString() == "True"))
                    {
                        htable.Clear();
                        //get unit type from dropdown for NEW unit creation
                        if (Request.QueryString["F"] != null)
                        {
                            if (Request.QueryString["F"].ToString() == "N")
                            {

                                htable.Add("@UnitType", ddlUnitType.SelectedValue.ToString());

                            }
                        }
                        //get unit type from grid for EDIT unit creation 
                        else
                        {
                            htUnitType.Clear();
                            dsUnitType.Clear();
                            htUnitType.Add("@UnitCode", Request.QueryString["UnitCode"].ToString());
                            dsUnitType = objDAL.GetDataSetForPrc("Prc_GetUnitTypeValue", htUnitType);
                            htable.Add("@UnitType", dsUnitType.Tables[0].Rows[0]["unittype"].ToString());
                        }
                        htable.Add("@bizsrc", lblSalesChannel.Text);
                        htable.Add("@chncls", ddlChnnlSubClass.SelectedValue.ToString());
                        htable.Add("@flag", "4");
                        //Procedure to get Link to master unit and Link to staff data
                        dsResult = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows[0]["LnkStaffFlag"].ToString() == "True")
                                {
                                    trStaffLink.Visible = true;
                                    lbluntSalesChnl.Visible = true;
                                    lbluntSalesChnlDesc.Visible = true;
                                    lbluntSubChnl.Visible = true;
                                    lbluntSubChnlDesc.Visible = true;
                                    lblAgntType.Visible = true;
                                    LblAgentType.Visible = true;

                                    trMasterLink.Visible = false;
                                    LblBizsrc.Visible = false;
                                    LblSlschannel.Visible = false;
                                    LblSubclass.Visible = false;
                                    LblChannelSubclass.Visible = false;
                                    LblUntcodeLink.Visible = false;
                                    LblUnitType.Visible = false;


                                    lbluntSalesChnlDesc.Text = dsResult.Tables[0].Rows[0]["BizSrcStaffDesc"].ToString().Trim();
                                    lbluntSubChnlDesc.Text = dsResult.Tables[0].Rows[0]["ChnclsStaffDesc"].ToString().Trim();
                                    LblAgentType.Text = dsResult.Tables[0].Rows[0]["AgentTypeStaffDesc"].ToString().Trim();
                                    LblAgentName.Visible = true;
                                    DdlAgntName.Visible = true;
                                    LblUnitName.Visible = false;
                                    DdlUnitName.Visible = false;
                                    DdlAgntName.Items.Insert(0, new ListItem("Select", ""));

                                    htable.Clear();
                                    htable.Add("@flag", "3");
                                    htable.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrcStaff"].ToString().Trim());
                                    htable.Add("@chncls", dsResult.Tables[0].Rows[0]["ChnClsStaff"].ToString().Trim());
                                    htable.Add("@AgentType", dsResult.Tables[0].Rows[0]["AgentTypeStaff"].ToString().Trim());
                                    //Procedure to fill Agent Name dropdown
                                    dsUnit = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                                    if (dsUnit.Tables.Count > 0)
                                    {
                                        if (dsUnit.Tables[0].Rows.Count > 0)
                                        {
                                            objCommonU.FillDropDown(DdlAgntName, dsUnit.Tables[0], "AgentTypeDesc01", "AgentType");
                                            DdlAgntName.Items.Insert(0, new ListItem("Select", ""));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Link to master unit checkbox  and Link to staff checkbox are checked
                    else if ((dsflag.Tables[0].Rows[0]["LnkMstUnit"].ToString() == "True") && (dsflag.Tables[0].Rows[0]["LnkStaffFlag"].ToString() == "True"))
                    {
                        htable.Clear();
                        //get unit type from dropdown for NEW unit creation
                        if (Request.QueryString["F"] != null)
                        {
                            if (Request.QueryString["F"].ToString() == "N")
                            {

                                htable.Add("@UnitType", ddlUnitType.SelectedValue.ToString());

                            }
                        }
                        //get unit type from grid for EDIT unit creation 
                        else
                        {
                            htUnitType.Clear();
                            dsUnitType.Clear();
                            htUnitType.Add("@UnitCode", Request.QueryString["UnitCode"].ToString());
                            dsUnitType = objDAL.GetDataSetForPrc("Prc_GetUnitTypeValue", htUnitType);
                            htable.Add("@UnitType", dsUnitType.Tables[0].Rows[0]["unittype"].ToString());
                        }

                        htable.Add("@bizsrc", lblSalesChannel.Text);
                        htable.Add("@chncls", ddlChnnlSubClass.SelectedValue.ToString());
                        htable.Add("@flag", "5");
                        //Procedure to get Link to master unit and Link to staff data
                        dsResult = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                trStaffLink.Visible = true;
                                lbluntSalesChnl.Visible = true;
                                lbluntSalesChnlDesc.Visible = true;
                                lbluntSubChnl.Visible = true;
                                lbluntSubChnlDesc.Visible = true;
                                lblAgntType.Visible = true;
                                LblAgentType.Visible = true;

                                trMasterLink.Visible = true;
                                LblBizsrc.Visible = true;
                                LblSlschannel.Visible = true;
                                LblSubclass.Visible = true;
                                LblChannelSubclass.Visible = true;
                                LblUntcodeLink.Visible = true;
                                LblUnitType.Visible = true;

                                LblUnitName.Visible = true;
                                DdlUnitName.Visible = true;
                                DdlUnitName.Items.Insert(0, new ListItem("Select", ""));

                                LblAgentName.Visible = true;
                                DdlAgntName.Visible = true;
                                DdlAgntName.Items.Insert(0, new ListItem("Select", ""));

                                LblSlschannel.Text = dsResult.Tables[0].Rows[0]["BizSrcLinkDecs"].ToString().Trim();
                                LblChannelSubclass.Text = dsResult.Tables[0].Rows[0]["ChnclsLinkDesc"].ToString().Trim();
                                LblUnitType.Text = dsResult.Tables[0].Rows[0]["UnitRankDesc01"].ToString().Trim();

                                lbluntSalesChnlDesc.Text = dsResult.Tables[0].Rows[0]["BizSrcStaffDesc"].ToString().Trim();
                                lbluntSubChnlDesc.Text = dsResult.Tables[0].Rows[0]["ChnclsStaffDesc"].ToString().Trim();
                                LblAgentType.Text = dsResult.Tables[0].Rows[0]["AgentTypeStaffDesc"].ToString().Trim();

                                //For DdlUnitCode dropdown of Link to master unit checkbox
                                htable.Clear();
                                htable.Add("@flag", "1");
                                htable.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrcLink"].ToString().Trim());
                                htable.Add("@chncls", dsResult.Tables[0].Rows[0]["ChnClsLink"].ToString().Trim());
                                htable.Add("@UnitType", dsResult.Tables[0].Rows[0]["UnitRank"].ToString().Trim());
                                DataSet dsUnit;
                                //Procedure with flag 1 to fill Unit Name dropdown
                                dsUnit = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                                if (dsUnit.Tables.Count > 0)
                                {
                                    if (dsUnit.Tables[0].Rows.Count > 0)
                                    {
                                        objCommonU.FillDropDown(DdlUnitName, dsUnit.Tables[0], "UNitcode", "UnitLegalName");
                                        DdlUnitName.Items.Insert(0, new ListItem("Select", ""));
                                    }
                                }
                                //For DdlAgntType dropdown of Link to staff checkbox
                                htable.Clear();
                                htable.Add("@flag", "3");
                                htable.Add("@BizSrc", dsResult.Tables[0].Rows[0]["BizSrcStaff"].ToString().Trim());
                                htable.Add("@chncls", dsResult.Tables[0].Rows[0]["ChnClsStaff"].ToString().Trim());
                                htable.Add("@AgentType", dsResult.Tables[0].Rows[0]["AgentTypeStaff"].ToString().Trim());
                                //Procedure with flag 3 to fill Agent Name dropdown
                                dsUnit = objDAL.GetDataSetForPrc("Prc_GetLinkedUNTData", htable);
                                if (dsUnit.Tables.Count > 0)
                                {
                                    if (dsUnit.Tables[0].Rows.Count > 0)
                                    {
                                        objCommonU.FillDropDown(DdlAgntName, dsUnit.Tables[0], "AgentTypeDesc01", "AgentType");
                                        DdlAgntName.Items.Insert(0, new ListItem("Select", ""));


                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    LblBizsrc.Visible = false;
                    LblSlschannel.Visible = false;
                    LblSubclass.Visible = false;
                    LblChannelSubclass.Visible = false;
                    LblUntcodeLink.Visible = false;
                    LblUnitType.Visible = false;
                    LblUnitName.Visible = false;
                    DdlUnitName.Visible = false;
                    lbluntSalesChnl.Visible = false;
                    lbluntSalesChnlDesc.Visible = false;
                    lbluntSubChnl.Visible = false;
                    lbluntSubChnlDesc.Visible = false;
                    lblAgntType.Visible = false;
                    LblAgentType.Visible = false;
                    LblAgentName.Visible = false;
                    DdlAgntName.Visible = false;

                }

            }
            else
            {
                LblBizsrc.Visible = false;
                LblSlschannel.Visible = false;
                LblSubclass.Visible = false;
                LblChannelSubclass.Visible = false;
                LblUntcodeLink.Visible = false;
                LblUnitType.Visible = false;
                LblUnitName.Visible = false;
                DdlUnitName.Visible = false;
                lbluntSalesChnl.Visible = false;
                lbluntSalesChnlDesc.Visible = false;
                lbluntSubChnl.Visible = false;
                lbluntSubChnlDesc.Visible = false;
                lblAgntType.Visible = false;
                LblAgentType.Visible = false;
                LblAgentName.Visible = false;
                DdlAgntName.Visible = false;
            }

        }
        #endregion

        #region fillRptMgrDtls
        public void fillRptMgrDtls()
        {
            try
            {
                #region FILLDROPDOWN

                oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                oCommon.getDropDown(ddlRuleTypePrmry, "untruletype", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlRuleTypePrmry.Items.Insert(0, new ListItem("Select", ""));

                //added by meena 26_9_18
                oCommon.getDropDown(ddlRuleTypeAddl1, "untruletype", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlRuleTypeAddl1.Items.Insert(0, new ListItem("Select", ""));
                //added by meena 26_9_18

                GetPrimRpt();
                #endregion

                Hashtable htmgr = new Hashtable();
                DataSet dsmgr = new DataSet();
                htmgr.Clear();
                htmgr.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                htmgr.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                htmgr.Add("@RptAgtTyp", ddlUnitType.SelectedValue);
                htmgr.Add("@flag", "A");
                dsmgr = objDAL.GetDataSetForPrc("prc_GetUnitMgrDtls", htmgr);
                if (dsmgr.Tables.Count > 0)
                {
                    if (dsmgr.Tables[0].Rows.Count > 0)
                    {
                        ddlRuleTypePrmry.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryRuleTyp"].ToString();
                        ddlRuleTypeAddl1.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1RuleTyp"].ToString();//added by meena 26_9_2018

                        fillreportingtype();

                        ddlreportingtype.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        ddlam1reportingtype.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1ReptTyp"].ToString();

                        if (ddlreportingtype.SelectedValue != "")
                        {
                            tblUnitRptType.Visible = true;
                        }
                        else
                        {
                            //  tblUnitRptType.Visible = false;
                        }

                        //if (ddlam1reportingtype.SelectedValue != "")
                        //{
                        //    //tblUnitRptTypeAddl.Visible = true;
                        //    div4.Style.Add("display", "block");
                        //}
                        //else
                        //{
                        //    //tblUnitRptTypeAddl.Visible = false;
                        //    div4.Style.Add("display", "none");
                        //}

                        fillbasedon();
                        ddlbasedon.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryBsdOn"].ToString();
                        ddlam1basedon.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1BsdOn"].ToString();

                        ddlchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        ddlam1channel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1Channel"].ToString();

                        getsubchannel();
                        getrptsubchannel(ddlam1subchannel, ddlam1channel.SelectedValue);
                        ddlsubchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                        ddlam1subchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1SubChannel"].ToString();

                        if (ddlRuleTypePrmry.SelectedValue == "SCDSP" || ddlRuleTypePrmry.SelectedValue == "SCDSS" || ddlRuleTypePrmry.SelectedValue == "DCDSP" || ddlRuleTypePrmry.SelectedValue == "DCDSS")
                        {
                            funrptsubchnl(ddlchannel.SelectedValue, ddlRuleTypePrmry, ddlsubchannel);
                        }
                        else
                        {
                            // getrptsubchannel(ddlsubchannel, ddlchannel.SelectedValue);
                            ddlsubchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                        }

                        if (ddlRuleTypeAddl1.SelectedValue == "SCDSP" || ddlRuleTypeAddl1.SelectedValue == "SCDSS" || ddlRuleTypeAddl1.SelectedValue == "DCDSP" || ddlRuleTypeAddl1.SelectedValue == "DCDSS")
                        {
                            funrptsubchnl(ddlam1channel.SelectedValue, ddlRuleTypeAddl1, ddlam1subchannel);
                            ddlam1subchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1SubChannel"].ToString();
                        }
                        else
                        {
                            // getrptsubchannel(ddlam1subchannel, ddlam1channel.SelectedValue);
                            ddlam1subchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1SubChannel"].ToString();
                        }

                        hdnPrmStp.Value = dsmgr.Tables[0].Rows[0]["PrmyRptStp"].ToString();
                        hdnAdlStp.Value = dsmgr.Tables[0].Rows[0]["AdlRptStp"].ToString();

                        if (hdnPrmStp.Value == "E" && ddlbasedon.SelectedValue == "1")
                        {
                            ddllevelagttype.Enabled = false;
                        }
                        else
                        {
                            ddllevelagttype.Enabled = true;
                        }

                        if (hdnAdlStp.Value == "E" && ddlam1basedon.SelectedValue == "1")
                        {
                            ddlam1levelagttype.Enabled = false;
                        }
                        else
                        {
                            ddlam1levelagttype.Enabled = true;
                        }

                        hdnPrmType.Value = dsmgr.Tables[0].Rows[0]["PrimaryLvlAgtTyp"].ToString();
                        hdnAdlType.Value = dsmgr.Tables[0].Rows[0]["Addl1LvlAgtTyp"].ToString();
                        //GetLvlAgttype(ddllevelagttype, ddlbasedon.SelectedValue);
                        //GetLvlAgttype(ddlam1levelagttype, ddlam1basedon.SelectedValue);
                        GetLvlAgttype(ddllevelagttype, ddlbasedon.SelectedValue, hdnPrmStp.Value, hdnPrmType.Value);
                        GetLvlAgttype(ddlam1levelagttype, ddlam1basedon.SelectedValue, hdnAdlStp.Value, hdnAdlType.Value);

                        ddllevelagttype.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryLvlAgtTyp"].ToString();
                        ddlam1levelagttype.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1LvlAgtTyp"].ToString();

                        hdnPrimMand.Value = dsmgr.Tables[0].Rows[0]["IsPrimMand"].ToString();
                        hdnAddl1Mand.Value = dsmgr.Tables[0].Rows[0]["IsAddl1Mand"].ToString();
                        hdnAddl2Mand.Value = dsmgr.Tables[0].Rows[0]["IsAddl2Mand"].ToString();
                        if (dsmgr.Tables[0].Rows[0]["IsPrimMand"].ToString() == "True")
                        {
                            // txtRptUntCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        }
                        if (dsmgr.Tables[0].Rows[0]["IsAddl1Mand"].ToString() == "True")
                        {
                            txtRptUnitCodeMgr1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        }
                        //if (dsmgr.Tables[0].Rows[0]["IsAddl2Mand"].ToString() == "True")
                        //{
                        //    txtRptMgr2.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        //}
                        //if (dsmgr.Tables[0].Rows[0]["IsAddl3Mand"].ToString() == "True")
                        //{
                        //    txtRptMgr3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        //}
                        ddlReportingRule.SelectedValue = dsmgr.Tables[0].Rows[0]["AddlRelRule"].ToString();
                        var MgrCnt = dsmgr.Tables[0].Rows[0]["AddlRelRule"].ToString();
                        if (MgrCnt == "1")//changed from 0 to 1 by meena 26_9_28
                        {
                            lbladditionalrptdesc.Text = "Multiple-1";
                            tblMgr1.Visible = true;
                        }
                        else
                        {
                            tblMgr1.Visible = false;
                            lbladditionalrptdesc.Text = "No record(s) found";
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
        }
        #endregion


        #region funrptsubchnl
        protected void funrptsubchnl(string BizSrc, DropDownList ddlrule, DropDownList ddlsub)
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
                dtRead = objDAL.Common_exec_reader_prc("Prc_GetSubClsRuleTyp", htparam);
                if (dtRead.HasRows)
                {
                    ddlsub.DataSource = dtRead;
                    ddlsub.DataTextField = "ChnClsDesc01";
                    ddlsub.DataValueField = "ChnCls";
                    ddlsub.DataBind();
                }
                ddlsub.Items.Insert(0, new ListItem("Select", ""));
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
        #region fillRptMgrDtlsEdit
        public void fillRptMgrDtlsEdit()
        {
            try
            {
                #region FILLDROPDOWN
                oCommon.getDropDown(ddlReportingRule, "MgrReptRule", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                GetPrimRpt();
                #endregion

                Hashtable htmgr = new Hashtable();
                DataSet dsmgr = new DataSet();
                htmgr.Clear();
                htmgr.Add("@BizSrc", Request.QueryString["ChannelCode"].ToString());
                htmgr.Add("@ChnCls", ddlChnnlSubClass.SelectedValue);
                htmgr.Add("@RptAgtTyp", ddlUnitType.SelectedValue);
                htmgr.Add("@UnitCode", lblUnitCode.Text.Trim());
                htmgr.Add("@flag", "E");
                dsmgr = objDAL.GetDataSetForPrc("prc_GetUnitMgrDtls", htmgr);
                if (dsmgr.Tables.Count > 0)
                {
                    if (dsmgr.Tables[0].Rows.Count > 0)
                    {
                        fillreportingtype();

                        ddlreportingtype.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        ddlam1reportingtype.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1ReptTyp"].ToString();

                        fillbasedon();
                        ddlbasedon.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryBsdOn"].ToString();
                        ddlam1basedon.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1BsdOn"].ToString();

                        ddlchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        ddlam1channel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1Channel"].ToString();

                        getsubchannel();
                        getrptsubchannel(ddlam1subchannel, ddlam1channel.SelectedValue);
                        ddlsubchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                        ddlam1subchannel.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1SubChannel"].ToString();

                        hdnPrmStp.Value = dsmgr.Tables[0].Rows[0]["PrmyRptStp"].ToString();
                        hdnAdlStp.Value = dsmgr.Tables[0].Rows[0]["AdlRptStp"].ToString();

                        hdnPrmType.Value = dsmgr.Tables[0].Rows[0]["PrimaryLvlAgtTyp"].ToString();
                        hdnAdlType.Value = dsmgr.Tables[0].Rows[0]["UnitRnkType"].ToString();

                        ddlRuleTypePrmry.SelectedValue = dsmgr.Tables[0].Rows[0]["PrimaryRuleTyp"].ToString();
                        ddlRuleTypeAddl1.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1RuleTyp"].ToString();

                        GetLvlAgttype(ddllevelagttype, ddlbasedon.SelectedValue, hdnPrmStp.Value, hdnPrmType.Value);
                        GetLvlAgttype(ddlam1levelagttype, ddlam1basedon.SelectedValue, hdnAdlStp.Value, hdnAdlType.Value);

                        ddllevelagttype.Enabled = false;
                        ddlam1levelagttype.Enabled = false;

                        //GetLvlAgttype(ddllevelagttype, ddlbasedon.SelectedValue);
                        //GetLvlAgttype(ddlam1levelagttype, ddlam1basedon.SelectedValue);

                        ddllevelagttype.SelectedValue = dsmgr.Tables[0].Rows[0]["RptUnitType"].ToString();
                        ddlam1levelagttype.SelectedValue = dsmgr.Tables[0].Rows[0]["Addl1LvlAgtTyp"].ToString();

                        //ddlReportingRule.SelectedValue = dsmgr.Tables[0].Rows[0]["AddlRelRule"].ToString();

                        var IsRptUnitReq = dsmgr.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        if (IsRptUnitReq != null)
                        {
                            if (IsRptUnitReq.ToString() != "")
                            {
                                tblUnitRptType.Visible = true;
                                lblRptUntCode.Text = dsmgr.Tables[0].Rows[0]["RptUnitCode"].ToString();
                                hdnRptUntCode.Value = dsmgr.Tables[0].Rows[0]["RptUnitCode"].ToString();
                                txtRptUntCode.Text = dsmgr.Tables[0].Rows[0]["UnitDesc"].ToString();

                                var IsMgr1 = dsmgr.Tables[0].Rows[0]["Addl1ReptTyp"].ToString();
                                if (IsMgr1 != null)
                                {
                                    if (IsMgr1.ToString() != "")
                                    {
                                        tblMgr1.Visible = true;
                                        lblRptUntCodeMgr1.Text = dsmgr.Tables[0].Rows[0]["Addl1RptUntCode"].ToString();
                                        hdnRptUntCodeMgr1.Value = dsmgr.Tables[0].Rows[0]["Addl1RptUntCode"].ToString();
                                        txtRptUnitCodeMgr1.Text = dsmgr.Tables[0].Rows[0]["UnitDesc1"].ToString();
                                    }
                                    else
                                    {
                                        tblMgr1.Visible = false;
                                    }
                                }
                                else
                                {
                                    tblMgr1.Visible = false;
                                }
                            }
                            else
                            {
                                tblUnitRptType.Visible = false;
                            }
                        }
                        else
                        {
                            // tblUnitRptType.Visible = false;
                        }

                        var MgrCnt = dsmgr.Tables[0].Rows[0]["AddlRelRule"].ToString();
                        if (MgrCnt == "1")//changed from 0 to 1 by meena 26_9_28
                        {
                            lbladditionalrptdesc.Text = "Multiple-1";
                            tblMgr1.Visible = true;
                        }
                        else
                        {
                            tblMgr1.Visible = false;
                            lbladditionalrptdesc.Text = "No record(s) found";
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
        }
        #endregion

        #region fillreportingtype
        public void fillreportingtype()
        {
            oCommon.getDropDown(ddlreportingtype, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlam1reportingtype, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            ddlreportingtype.Items.Insert(0, new ListItem("Select", ""));
            ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region fillbasedon
        public void fillbasedon()
        {
            oCommon.getDropDown(ddlbasedon, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            oCommon.getDropDown(ddlam1basedon, "UntTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            ddlbasedon.Items.Insert(0, new ListItem("Select", ""));
            ddlam1basedon.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region PopulateState
        private void PopulateState(DropDownList ddlst)
        {
            string strSql = string.Empty;
            SqlDataReader dtRead;
            DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            dtRead = objDAL.exec_reader_prc_inscdirect("Prc_GetddlState", ht);
            if (dtRead.HasRows)
            {
                ddlst.DataSource = dtRead;
                ddlst.DataTextField = "StateName";
                ddlst.DataValueField = "StateID";
                ddlst.DataBind();
            }
            dsResult = null;
            dtRead = null;
            strSql = null;
            //ddlst.Items.Insert(0, "Select");
            ddlst.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region ddlreportingtype_SelectedIndexChanged
        protected void ddlreportingtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetChannel(ddlchannel);

            string userID = Session["UserID"].ToString();
            ddlchannel.Items.Clear();
            if (ddlreportingtype.SelectedValue == "CF")
            {
                GetChannel(ddlchannel, 1, Request.QueryString["ChannelCode"].ToString().Trim());
                ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                //GetRepoType(ddlam1reportingtype);
                //ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));
            }
            else if (ddlreportingtype.SelectedValue == "CU" || ddlreportingtype.SelectedValue == "HW" || ddlreportingtype.SelectedValue == "CP")
            {
                ddlchannel.Items.Clear();
              //  GetChannel(ddlchannel, 2, "");
               GetChannel(ddlchannel, 2, Request.QueryString["ChannelCode"].ToString().Trim());//Added by usha on 14.09.2018
              
                ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                //GetRepoType(ddlam1reportingtype);
                //ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));

            }
            else if (ddlreportingtype.SelectedValue == "")
            {
                ddlchannel.Items.Clear();
                ddlchannel.Items.Insert(0, new ListItem("Select", ""));
                //ddlam1reportingtype.Items.Clear();
                //ddlam1reportingtype.Items.Insert(0, new ListItem("Select", ""));

                ddlReportingRule.SelectedIndex = 0;
            }
            ddlsubchannel.Items.Clear();
            ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
            ddlbasedon.SelectedIndex = 0;
            ddllevelagttype.Items.Clear();
            ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
            ddlreportingtype.Focus();
        }
        #endregion

        #region GetChannel Method
        public void GetChannel(DropDownList ddl, int flag, string BizSrc)
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
        #endregion

        #region GetRepoType Method
        //added by akshay method to get the reporting types
        protected void GetRepoType(DropDownList ddl)
        {
            SqlDataReader drRead;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@LookupCode", "RptType");
            htParam.Add("@ParamValue", ddlreportingtype.SelectedValue);
            drRead = objDAL.exec_reader_prc_inscdirect("Prc_GetRepoType", htParam);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc01";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
        }
        #endregion

        #region FillDropDownMethod
        //added by akshay to fill the dropdowns with text and values
        public void FillDropDown(System.Web.UI.WebControls.DropDownList drpList, DataTable dtTable, string strValue, string strText)
        {
            drpList.Items.Clear();
            drpList.DataSource = dtTable;
            drpList.DataValueField = dtTable.Columns[strValue].ToString();
            drpList.DataTextField = dtTable.Columns[strText].ToString();
            drpList.DataBind();
        }
        #endregion

        #region ddlchannel_SelectedIndexChanged
        protected void ddlchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getsubchannel();
            ddlchannel.Focus();
        }
        #endregion

        #region getsubchannel
        //added by akshay for getting sub channel
        public void getsubchannel()
        {
            ddlsubchannel.Items.Clear();
            string userid = Session["UserID"].ToString();
            objCommonU.GetUserChnclsChannel(ddlsubchannel, ddlchannel.SelectedValue, 0, userid.ToString());
            ddlsubchannel.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region getrptsubchannel
        public void getrptsubchannel(DropDownList ddlsubchnl, string ddlchnl)
        {
            ddlsubchnl.Items.Clear();
            string userid = Session["UserID"].ToString();
            objCommonU.GetUserChnclsChannel(ddlsubchnl, ddlchnl, 0, userid.ToString());
            ddlsubchnl.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region GetLvlAgttype
        public void GetLvlAgttype(DropDownList ddl, string ddlbsd, string stp, string unttyp)
        {
            ddl.Items.Clear();
            dsResult = new DataSet();
            dsResult.Clear();
            htable.Clear();
            htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
            htable.Add("@ChnCls", Request.QueryString["SubCls"]);
            htable.Add("@UntType", ddlUnitType.SelectedValue);
            htable.Add("@BsdOn", ddlbsd);
            htable.Add("@RptStp", stp.ToString().Trim());
            htable.Add("@UntRnkTyp", unttyp.ToString().Trim());
            dsResult = objDAL.GetDataSetForPrc("prc_GetRptUntType", htable);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    objCommonU.FillDropDown(ddl, dsResult.Tables[0], "UnitType", "UnitDesc01");
                }
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region ddlsubchannel_SelectedIndexChanged
        protected void ddlsubchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlbasedon.SelectedIndex = 0;
            ddllevelagttype.Items.Clear();
            ddllevelagttype.Items.Insert(0, new ListItem("Select", ""));
            ddlbasedon.Focus();
        }
        #endregion

        #region ddlbasedon_SelectedIndexChanged
        protected void ddlbasedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlbasedon.SelectedValue == "1")
            {
                GetUnitLevel(ddllevelagttype);
            }
            else if (ddlbasedon.SelectedValue == "0")
            {
                GetUnitRank(ddllevelagttype);
            }
        }
        #endregion

        #region GetUnitLevel
        protected void GetUnitLevel(DropDownList ddl)
        {
            ddl.Items.Clear();
            SqlDataReader dtddlRead;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@BizSrc", ddlchannel.SelectedValue);
            htParam.Add("@Chncls", ddlsubchannel.SelectedValue);
            htParam.Add("@flag", 1);
            htParam.Add("@UntTyp", ddlUnitType.SelectedValue);
            dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetRptUnitDesc", htParam);
            if (dtddlRead.HasRows)
            {
                ddl.DataSource = dtddlRead;
                ddl.DataTextField = "UnitDesc01";
                ddl.DataValueField = "UnitType";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region GetUnitRank
        protected void GetUnitRank(DropDownList ddl)
        {
            ddl.Items.Clear();
            SqlDataReader dtddlRead;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@BizSrc", ddlchannel.SelectedValue);
            htParam.Add("@Chncls", ddlsubchannel.SelectedValue);
            htParam.Add("@flag", 2);
            htParam.Add("@UntTyp", ddlUnitType.SelectedValue);
            dtddlRead = objDAL.Common_exec_reader_prc_common("Prc_GetRptUnitDesc", htParam);
            if (dtddlRead.HasRows)
            {
                ddl.DataSource = dtddlRead;
                ddl.DataTextField = "UnitRank";
                ddl.DataValueField = "UnitRank";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region GetPrimRpt Method
        //method for filling primary reporting details DDLs
        protected void GetPrimRpt()
        {
            string userID = Session["UserID"].ToString();

            GetChannel(ddlchannel, 2, "");
           GetChannel(ddlam1channel, 2, "");
        }
        #endregion



        #region ddlam1channel_SelectedIndexChanged
        protected void ddlam1channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getam1subchannel();
            ddlam1channel.Focus();
        }
        #endregion

        #region getam1subchannel Method
        //added by akshay for getting sub channel for addl manager 1
        public void getam1subchannel()
        {
            ddlam1subchannel.Items.Clear();
            ddlam1basedon.SelectedIndex = 0;
            ddlam1levelagttype.Items.Clear();
            ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
            string userid = Session["UserID"].ToString();
            objCommonU.GetUserChnclsChannel(ddlam1subchannel, ddlam1channel.SelectedValue, 0, userid.ToString());
            ddlam1subchannel.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region ddlam1subchannel_SelectedIndexChanged
        protected void ddlam1subchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlam1subchannel.SelectedValue == "Select")
            {
                ddlam1basedon.SelectedIndex = 0;
                ddlam1levelagttype.Items.Clear();
                ddlam1levelagttype.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        #endregion

        #region ddlam2channel_SelectedIndexChanged
        protected void ddlam2channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getam2subchannel();
            ddlam2channel.Focus();
        }
        #endregion

        #region getam2subchannel Method
        //added by akshay for getting sub channel for addl manager 2
        public void getam2subchannel()
        {
            ddlam2subchannel.Items.Clear();
            ddlam2basedon.SelectedIndex = 0;
            ddlam2levelagttype.Items.Clear();
            ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
            string userid = Session["UserID"].ToString();
            objCommonU.GetUserChnclsChannel(ddlam2subchannel, ddlam2channel.SelectedValue, 0, userid.ToString());
            ddlam2subchannel.Items.Insert(0, new ListItem("Select", ""));
        }
        #endregion

        #region ddlam2subchannel_SelectedIndexChanged
        protected void ddlam2subchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlam2channel.SelectedValue == "")
            {
                ddlam2basedon.SelectedIndex = 0;
                ddlam2levelagttype.Items.Clear();
                ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        #endregion

        #region ddlam2basedon_SelectedIndexChanged
        protected void ddlam2basedon_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLevelAgentTypeAM2();
            ddlam2basedon.Focus();
        }
        #endregion

        #region getLevelAgentTypeAM2 Method
        //added by akshay for getting level types and agent types for addl manager 2
        public void getLevelAgentTypeAM2()
        {
            ddlam2levelagttype.Items.Clear();
            ddlam2levelagttype.Items.Insert(0, new ListItem("Select", ""));
            string userID = Session["UserID"].ToString();

        }

        #endregion

        protected void Btnpincode_Click(object sender, EventArgs e)
        {
            var dt = (DataTable)Session["Address"];
            txtDistP.Text = dt.Rows[0]["District"].ToString();
            txtcityp.Text = dt.Rows[0]["City"].ToString();
            txtarea.Text = dt.Rows[0]["Area"].ToString();
            txtPinP.Text = dt.Rows[0]["Pincode"].ToString();
        }

        public decimal GetUnitRank(string UnitType, string CarrierCode, string BizSrc)
        {

            //added by asrar on 10/07/2013 to get UnitLevel start 
            string strSql = string.Empty;
            htable.Clear();
            htable.Add("@UnitType", UnitType);
            htable.Add("@CarrierCode", CarrierCode);
            htable.Add("@BizSrc", BizSrc);
            decimal uRnk = 0;
            uRnk = dataAccess.exec_commandDec_Prc("Prc_GetUnitRnkchnUntSU", htable);
            return uRnk;

        }


        //Added by usha on 20.09.2018  for SAP location 
        protected void btnmemgrid_Click(object sender, EventArgs e)
        {


            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmsg", "openSAPBranchList( );", true);
           
        }

        protected void btnunitgrid_Click(object sender, EventArgs e)
        {
            var dt = (DataTable)Session["unt"];
            txtBranchCode.Text = dt.Rows[0]["PA2_Code"].ToString();
            Session["unitcode"] = txtBranchCode.Text;
            ViewState["sapcode"] = Session["unitcode"].ToString();

            btnRptMgr.Focus();

        }

        //Added by rajkapoor 
        protected void BindDataGrid()
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();

            //Request.QueryString["UnitCode"].ToString();
            htParam.Add("@UnitCode", Request.QueryString["UnitCode"].ToString());
            dsResult = objDAL.GetDataSetForPrc("Prc_GetChannelEnlbmnt", htParam);
            grdChnEnblmnt.DataSource = dsResult.Tables[0];
            grdChnEnblmnt.DataBind();

        }
        //Added by rajkapoor 
    }

}
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
using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.MQ.Life.AgnCr;
using Insc.MQ.Life.AgnMd;
using Insc.MQ.Life.CSCr;
using Insc.MQ.Life.CSMod;
using Insc.MQ.Life.AgnInwMd;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;
using DataDynamics.ActiveReports.Export.Pdf;
using DataDynamics.ActiveReports.Export.Xls;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.Viewer;
using System.Threading;
using Insc.Common.Multilingual;
using INSCL.DAL;
using System.Xml;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DataAccessClassDAL;
using System.Web.Script.Serialization;

public partial class SAPLicDetails : BaseClass
{
    #region Declaration
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    //DataAccessLayer objDAL = new DataAccessLayer();
    DataAccessClass objDAL = new DataAccessClass();
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    clsChannelSetup objChnSetup = new clsChannelSetup();
    string ErrMsg, AuditType;
    SqlDataReader dtRead;
    SqlDataReader dtRead1;
    SqlDataReader dataread;
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    public int image_height;
    public int image_width;
    public int max_height;
    public int max_width;
    public byte[] data;
    public byte[] imgres;
    private string strFileName = string.Empty;

    private const string c_strBlank = "-- Select --";

    string str_BizSrc = "", str_CarrierCode = "", str_AgentType = "", str_AgnCode = "", str_ChnClass = "";
    int intCode;
    string StrFlag = "";
    string strRemark = "";
    XmlDocument doc = new XmlDocument();
    string strAgntStatus = "", strXML = "";
    private multilingualManager olng;
    private string strUserLang;
    string strErrMsg = "";

    private DataAccessClass dataAccess = new DataAccessClass();
    private DataAccessClass objRecruit = new DataAccessClass();
    private clsAgent agentObject = new clsAgent();

    string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
    Hashtable htnew = new Hashtable();

    ErrLog objErr = new ErrLog();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        #region Initialize label values
        //olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
        if (HttpContext.Current.Session["UserLangNum"] != "")
        {
            strUserLang = Convert.ToString(HttpContext.Current.Session["UserLangNum"]).Trim();
        }
        if (Request.QueryString["Ctgry"] != null)
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
            {
                olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", strUserLang);
            }
            else
            {
                olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
            }
        }
        #endregion
        btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");
        if (!IsPostBack)
        {
            InitializeControl();
            
            if (Request.QueryString["ID"].ToUpper().ToString().Trim() == "SAP")
            {
                //trSapCode.Visible = true;
                divsapdtls.Visible = true;
                //SetFocus(txtSAPcode);
                txtSAPcode.Focus();
                ///divlicdtls.Visible = false;
            }
            else
                if (Request.QueryString["ID"].ToUpper().ToString().Trim() == "LIC")
                {
                    divlicdtls.Visible = true;
                    //divsapdtls.Visible = false;
                }
            if (Request.QueryString["Type"].ToString().Trim() == "E")
            {
                if (Request.QueryString["AgnCd"] != null)
                {
                    ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();
                }
                subPopulateGender();
                subPopulateAgnTitle();
                CnctType(true);
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                oCommonU.GetAgentType(ddlAgntType, "All", "");

                //Img.Visible = false;
                //DataSet dsImg = BindGrid();
                //GridImage.DataSource = dsImg;
                //GridImage.DataBind();

                FillRequiredDataForPage1();
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        lnkPage1.ImageUrl = "~/theme/iflow/employee.gif";
                    }
                }
                else
                {
                    lnkPage1.ImageUrl = "~/theme/iflow/Agent.gif";
                }
            }
        }
        FillReportingMngrDtls();
    }

    private void InitializeControl()
    {
        lblPersonalPart.Text = olng.GetItemDesc("lblPersonalPart.Text");
        lvlVw1AgntCode.Text = olng.GetItemDesc("lvlVw1AgntCode.Text");
        lblVw1AgntStatus.Text = olng.GetItemDesc("lblVw1AgntStatus.Text");
        lblClCode.Text = olng.GetItemDesc("lblClCode.Text");
        lblExclusive.Text = olng.GetItemDesc("lblExclusive.Text");
        lblPanNo.Text = olng.GetItemDesc("lblPanNo.Text");
        lblAgntName.Text = olng.GetItemDesc("lblAgntName.Text");
        lblBusinessSrc.Text = olng.GetItemDesc("lblBusinessSrc.Text");
        lblCntDetails.Text = olng.GetItemDesc("lblCntDetails.Text");
        lblChnCls.Text = olng.GetItemDesc("lblChnCls.Text");
        lblLicNo.Text = olng.GetItemDesc("lblLicNo.Text");
        lblVw1AgntType.Text = olng.GetItemDesc("lblVw1AgntType.Text");
        lblLicEexpDate.Text = olng.GetItemDesc("lblLicEexpDate.Text");
        lblAgntClass.Text = olng.GetItemDesc("lblAgntClass.Text");
        //Label1.Text = olng.GetItemDesc("Label1.Text");
        lblCode.Text = olng.GetItemDesc("lblCode.Text");
        lblSAPcode.Text = olng.GetItemDesc("lblSAPCode.Text");
        lblchnltype.Text = olng.GetItemDesc("lblchnltype.Text");
        lblchannel.Text = olng.GetItemDesc("lblchannel.Text");
        lblsubchannel.Text = olng.GetItemDesc("lblsubchannel.Text");
        lbllevelagttype.Text = olng.GetItemDesc("lbllevelagttype.Text");
    }

    protected void FillRequiredDataForPage1()
    {

        dsResult = new DataSet();
        //htParam.Clear();
        //htParam = new Hashtable();

        oCommon.getDropDown(ddlAgntStatus, "AgtSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        //oCommon.getDropDown(ddlAgntClass, "AAgtClass", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommonU.GetSalesChannel(ddlSlsChannel, "", 0);
        ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));


        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        try
        {
            ////dsResult = dataAccess.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_getagtForSAP", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["ChnlType"].ToString().Trim() == "True")
                    {
                        rdbChnlTyp.SelectedValue = "1";
                    }
                    else
                    {
                        rdbChnlTyp.SelectedValue = "0";
                    }
                    oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rdbChnlTyp.SelectedValue);
                    ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));


                    txtAgtCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentCode"]);
                    txtCusmId.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]);
                    txtCltCode.Enabled = false;
                    txtCltCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]);
                    ddlGender.SelectedValue = dsResult.Tables[0].Rows[0]["Gender"].ToString().Trim();
                    txtPanNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PANNo"]);
                    cboagnTitle.SelectedValue = dsResult.Tables[0].Rows[0]["AgnTitle"].ToString().Trim();
                    txtSAPcode.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString().Trim();

                    if (dsResult.Tables[0].Rows[0]["AgentStatus"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgentStatus"]).Trim() != "")
                        {
                            ddlAgntStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentStatus"]).Trim();
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                        {
                            ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                        }
                    }
                    ddlChnCls.Items.Clear();
                    SqlDataReader dtRead;
                    //Added by Pranjali on 01-07-2013 for Channel sub class dropdown start
                    Hashtable htparam = new Hashtable();
                    htparam.Clear();
                    htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
                    dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
                    //Added by Pranjali on 01-07-2013 for Channel sub class dropdown end
                    //dtRead = dataAccess.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSlsChannel.SelectedValue + "'");
                    if (dtRead.HasRows)
                    {
                        ddlChnCls.DataSource = dtRead;
                        ddlChnCls.DataTextField = "ChnlDesc";
                        ddlChnCls.DataValueField = "ChnCls";
                        ddlChnCls.DataBind();
                    }
                    dtRead = null;
                    ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                    if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                        {
                            foreach (ListItem lstItem in ddlChnCls.Items)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() == lstItem.Value)
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                                    break;
                                }
                            }
                        }
                    }

                    string LastPromotionDate = "";
                    //Added by Pranjali on 02-07-2013 for getting last promotion date start
                    htparam = new Hashtable();
                    htparam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString());
                    dtRead = dataAccess.Common_exec_reader_prc("Prc_GetLstPromoDte", htparam);
                    //Added by Pranjali on 02-07-2013 for getting last promotion date end
                    //dtRead = dataAccess.Common_exec_reader("select LastPromoDt From Agn Where agentcode='" + Request.QueryString["AgnCd"].ToString() + "'");
                    if (dtRead.Read())
                    {
                        LastPromotionDate = dtRead[0].ToString();
                    }
                    dtRead.Close();


                    dtRead.Close();
                    if (dsResult.Tables[0].Rows[0]["AgtClass"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgtClass"]).Trim() != "")
                        {
                            ddlAgntClass.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["AgtClass"]).Trim();
                        }
                    }
                    txtAgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);


                }
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details start 
                FillReportingMngrDtls();
                //ddlRptMgr.SelectedValue = dsResult.Tables[0].Rows[0]["AddMgrcode"].ToString().Trim();
                //commented by akshay on 24/01/14
                //ddam1lMgr.SelectedValue = dsResult.Tables[0].Rows[0]["AddMgrcode1"].ToString().Trim();
                //ddam2lMgr.SelectedValue = dsResult.Tables[0].Rows[0]["AddMgrcode2"].ToString().Trim();
                //ddam3lMgr.SelectedValue = dsResult.Tables[0].Rows[0]["AddMgrcode3"].ToString().Trim();
                //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details end
            }

        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
        }
        dsResult.Clear();
        dsResult = null;
        htParam.Clear();
        htParam = null;
       
    }
    protected void FillReportingMngrDtls()
    {
        try
        {
            //rachana 30-11-2013 start
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            htParam.Add("@AgentType", ddlAgntType.SelectedValue);
            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
            htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
            dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

            //Assign values to labels
            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    FillReportingMngrddl();
                    FillReportingMngrchnl();
                    FillReportingMngrsubchnl();
                    FillReportingMngrAgttype();

                    ddlprimrepo.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                    //lblreportingtype.Text = dsRpt.Tables[0].Rows[0]["PrimaryRpTyp"].ToString();
                    ddlchanneldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                    //lblchanneldesc.Text = dsRpt.Tables[0].Rows[0]["PrimaryChnl"].ToString();
                    ddlbasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString();
                    ddlsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                    ddllvlagt.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryAgentOrLevelType"].ToString();
                    //lbllevelagttypedesc.Text = dsRpt.Tables[0].Rows[0]["AgentTypes"].ToString();

                    ddlam1rptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlReportingType1"].ToString();
                    ddlam2rptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlReportingType2"].ToString();
                    ddlam3rptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlReportingType3"].ToString();

                    ddlam1basedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlBasedOnType1"].ToString();
                    ddlam2basedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlBasedOnType2"].ToString();
                    ddlam3basedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlBasedOnType3"].ToString();

                    ddlam1chnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlChannel1"].ToString();
                    ddlam2chnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlChannel2"].ToString();
                    ddlam3chnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlChannel3"].ToString();



                    //ddlam1subchnldesc.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AddlSubChnl1"].ToString();
                    //ddlam2subchnldesc.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AddlSubChnl2"].ToString();
                    //ddlam3subchnldesc.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AddlSubChnl3"].ToString();

                    ddlam1subchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlSubChannel1"].ToString();
                    ddlam2subchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlSubChannel2"].ToString();
                    ddlam3subchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlSubChannel3"].ToString();


                    //ddllvlagttype1.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AgentLevel1"].ToString();
                    //ddllvlagttype2.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AgentLevel2"].ToString();
                    //ddllvlagttype3.SelectedItem.Text = dsRpt.Tables[0].Rows[0]["AgentLevel3"].ToString();

                    ddllvlagttype1.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlAgentOrLevelType1"].ToString();
                    ddllvlagttype2.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlAgentOrLevelType2"].ToString();
                    ddllvlagttype3.SelectedValue = dsRpt.Tables[0].Rows[0]["AddlAgentOrLevelType3"].ToString();

                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                    //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable start
                    //ddladditionalreportingrule.Items.Add(strAddreportingRule);// = strAddreportingRule;
                    //ddladditionalreportingrule.SelectedValue = dsResult.Tables[0].Rows[0]["AddlReportingRule"].ToString();
                    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                    {
                        lblRptMngrErr.Visible = false;
                        lblRptMngrErr.Text = "";
                        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "0")
                        {
                            lbladditionalreportingrule.Text = "Multiple-1";
                        }
                        else
                            if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "1")
                            {
                                lbladditionalreportingrule.Text = "Multiple-2";
                            }
                            else
                                if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "2")
                                {
                                    lbladditionalreportingrule.Text = "Multiple-3";
                                }
                        GetManagers();
                        GetAddlManagers();
                    }
                    else
                    {
                        lblRptMngrErr.Visible = true;
                        lblRptMngrErr.Text = "No Record(s) Exists";
                        lbladditionalreportingrule.Text = "";
                        GetManagers();
                    }
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
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
    protected void GetManagers()
    {
        hdnagttyp.Value = ddllvlagt.SelectedValue;
        hdnchn.Value = ddlSlsChannel.SelectedValue;
        hdnsubchn.Value = ddlChnCls.SelectedValue;

        btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + hdnprimgr.Value.Trim() + "');return false;");
        Hashtable htParam = new Hashtable();
        DataSet dsmgr = new DataSet();
        dsmgr.Clear();
        htParam.Clear();
        htParam.Add("@AgentType", ddllvlagt.SelectedValue.ToString().Trim());
        htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
        htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
        dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforManager", htParam);
        if (dsmgr.Tables.Count > 0)
        {
            if (dsmgr.Tables[0].Rows.Count > 0)
            {
                //ddlRptMgr.DataSource = dsmgr;
                //ddlRptMgr.DataTextField = "LegalName";
                //ddlRptMgr.DataValueField = "AgentCode";
                //ddlRptMgr.DataBind();

                txtRptMgr.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                hdnRptMgr.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                lblrptmgr.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();

            }
        }
    }

    protected void GetAddlManagers()
    {
        try
        {
            rptmgr1();
            rptmgr2();
            rptmgr3();
            //btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + hdnprimgr.Value.Trim() + "');return false;");
            Hashtable htParam = new Hashtable();
            DataSet dsmgr = new DataSet();
            dsmgr.Clear();
            htParam.Clear();
            htParam.Add("@AgentType", ddllvlagt.SelectedValue.ToString().Trim());
            htParam.Add("@BizSrc", hdnchn.Value.Trim());
            htParam.Add("@ChnCls", hdnsubchn.Value.Trim());
            dsmgr = objDAL.GetDataSetForPrc("Prc_GetDataforManager", htParam);
            if (dsmgr.Tables.Count > 0)
            {
                if (dsmgr.Tables[0].Rows.Count > 0)
                {
                    //ddam1lMgr.DataSource = dsmgr;
                    //ddam1lMgr.DataTextField = "LegalName";
                    //ddam1lMgr.DataValueField = "AgentCode";
                    //ddam1lMgr.DataBind();

                    txtRptMgr1.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                    hdnRptMgr1.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    lblrptmgr1.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();

                    //ddam2lMgr.DataSource = dsmgr;
                    //ddam2lMgr.DataTextField = "LegalName";
                    //ddam2lMgr.DataValueField = "AgentCode";
                    //ddam2lMgr.DataBind();

                    txtRptMgr2.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                    hdnRptMgr2.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    lblrptmgr2.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();

                    //ddam3lMgr.DataSource = dsmgr;
                    //ddam3lMgr.DataTextField = "LegalName";
                    //ddam3lMgr.DataValueField = "AgentCode";
                    //ddam3lMgr.DataBind();

                    txtRptMgr3.Text = dsmgr.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                    hdnRptMgr3.Value = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    lblrptmgr3.Text = dsmgr.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
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

    private void subPopulateGender()
    {
        try
        {
            oCommon.getDropDown(ddlGender, "NBGender", 1, "", 1, c_strBlank);
            ddlGender.Items.Remove(ddlGender.Items.FindByValue("C"));
            ddlGender.Items.Remove(ddlGender.Items.FindByValue("U"));
            //subGenerateGenderValidation();
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

    private void subPopulateAgnTitle()
    {
        try
        {

            cboagnTitle.Items.Clear();
            dscbotitle.SelectCommand = "Prc_GetCndTitle";
            cboagnTitle.DataBind();


            cboagnTitle.Items.Insert(0, new ListItem("--", ""));
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

    private void CnctType(Boolean blnNew)
    {
        try
        {
            ListItem[] items = new ListItem[1];
            string LngCode = HttpContext.Current.Session["UserLangNum"].ToString();
            ddlCnctType.Items.Clear();
            // Added by Pranjali on 28-06-2013 for Candidate Address Type
            //if (blnNew)
            //{
            dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper() + "'";  // Added by Pranjali on 28-06-2013 for Candidate Address Type of B1 and P1
            // Added by Pranjali on 28-06-2013 for Candidate Address Type end
            // }
            // else
            //{
            //  dsCnctType.SelectCommand = "Prc_GetCnctAddressType '" + blnNew.ToString().ToUpper()+ "'";// Added by Pranjali on 28-06-2013 for all Candidate Address Type-- Business and Residential 
            //}
            ddlCnctType.DataBind();
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

    protected void FillReportingMngrddl()
    {
        oCommon.getDropDown(ddlam1rptdesc, "Rpttype", 1, "", 1, c_strBlank);
        oCommon.getDropDown(ddlam2rptdesc, "Rpttype", 1, "", 1, c_strBlank);
        oCommon.getDropDown(ddlam3rptdesc, "Rpttype", 1, "", 1, c_strBlank);
        oCommon.getDropDown(ddlprimrepo, "Rpttype", 1, "", 1, c_strBlank);

        oCommon.getDropDown(ddlam1basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlam2basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlam3basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlbasedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

        //ddlam1rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlam2rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlam3rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlprimrepo.Items.Insert(0, new ListItem("-- Select --", ""));

        ddlam1basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlam2basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlam3basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlbasedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
    }

    protected void funchnlpopup(DropDownList ddl)
    {
        ddl.Items.Clear();
        SqlDataReader dtRead;
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
        if (dtRead.HasRows)
        {
            ddl.DataSource = dtRead;
            ddl.DataTextField = "ChannelDesc01";
            ddl.DataValueField = "BizSrc";
            ddl.DataBind();
        }
        dtRead = null;
        ddl.Items.Insert(0, new ListItem("-- Select --", ""));
    }

    protected void FillReportingMngrchnl()
    {
        funchnlpopup(ddlam1chnldesc);
        funchnlpopup(ddlam2chnldesc);
        funchnlpopup(ddlam3chnldesc);
        funchnlpopup(ddlchanneldesc);
    }

    protected void funsubchnlpopup(DropDownList ddl, string txt)
    {
        ddl.Items.Clear();
        SqlDataReader dtRead;
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@chnl", txt.Trim());
        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlmgrsubchnnl", htparam);
        if (dtRead.HasRows)
        {
            ddl.DataSource = dtRead;
            ddl.DataTextField = "ChnClsDesc01";
            ddl.DataValueField = "ChnCls";
            ddl.DataBind();
        }
        dtRead = null;
        ddl.Items.Insert(0, new ListItem("-- Select --", ""));
    }

    protected void FillReportingMngrsubchnl()
    {
        funsubchnlpopup(ddlam1subchnldesc, ddlam1chnldesc.SelectedItem.Text);
        funsubchnlpopup(ddlam2subchnldesc, ddlam1chnldesc.SelectedItem.Text);
        funsubchnlpopup(ddlam3subchnldesc, ddlam1chnldesc.SelectedItem.Text);
        funsubchnlpopup(ddlsubchnldesc, ddlchanneldesc.SelectedItem.Text);
    }

    protected void funagttyppopup(DropDownList ddl, string txtchn, string txtsubchn)
    {
        ddl.Items.Clear();
        SqlDataReader dtRead;
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@chnl", txtchn.Trim());
        htparam.Add("@subchnl", txtsubchn.Trim());
        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlmgragttyp", htparam);
        if (dtRead.HasRows)
        {
            ddl.DataSource = dtRead;
            ddl.DataTextField = "AgentTypeDesc01";
            ddl.DataValueField = "AgentType";
            ddl.DataBind();
        }
        dtRead = null;
        ddl.Items.Insert(0, new ListItem("-- Select --", ""));
    }

    protected void FillReportingMngrAgttype()
    {
        funagttyppopup(ddllvlagttype1, ddlam1chnldesc.SelectedItem.Text, ddlam1subchnldesc.SelectedItem.Text);
        funagttyppopup(ddllvlagttype2, ddlam1chnldesc.SelectedItem.Text, ddlam1subchnldesc.SelectedItem.Text);
        funagttyppopup(ddllvlagttype3, ddlam1chnldesc.SelectedItem.Text, ddlam1subchnldesc.SelectedItem.Text);
        funagttyppopup(ddllvlagt, ddlchanneldesc.SelectedItem.Text, ddlsubchnldesc.SelectedItem.Text);
    }
    protected void ddlam1rptdesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private DataSet BindGrid()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();

            Hashtable httable = new Hashtable();
            if (Request.QueryString["AgnCd"].ToString() != null)
            {
                httable.Add("@AgtCode", Request.QueryString["AgnCd"].ToString().Trim());
            }

            dsResult.Clear();
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_GetImageForAgents", httable);
            //GridImage.DataSource = dsResult;
            //GridImage.DataBind();

        }
        catch (Exception ex)
        {
            var message = new JavaScriptSerializer().Serialize(ex.Message);
            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, true);


        }
        finally
        {
            //con.Close();
        }
        return dsResult;
    }

    protected void rptmgr1()
    {
        //FillReportingMngrchnl();
        //FillReportingMngrsubchnl();
        //FillReportingMngrAgttype();

        hdnchn.Value = ddlam1chnldesc.SelectedValue;
        hdnsubchn.Value = ddlam1subchnldesc.SelectedValue;
        hdnagttyp.Value = ddllvlagttype1.SelectedValue;
        hdnprimgr.Value = txtRptMgr1.Text;

        btnRptMgr1.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr1','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + hdnprimgr.Value.Trim() + "');return false;");
    }
    protected void rptmgr2()
    {
        hdnchn.Value = ddlam2chnldesc.SelectedValue;
        hdnsubchn.Value = ddlam2subchnldesc.SelectedValue;
        hdnagttyp.Value = ddllvlagttype2.SelectedValue;
        hdnprimgr.Value = txtRptMgr2.Text;

        btnRptMgr2.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr2','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + hdnprimgr.Value.Trim() + "');return false;");
    }
    protected void rptmgr3()
    {
        hdnchn.Value = ddlam3chnldesc.SelectedValue;
        hdnsubchn.Value = ddlam3subchnldesc.SelectedValue;
        hdnagttyp.Value = ddllvlagttype3.SelectedValue;
        hdnprimgr.Value = txtRptMgr3.Text;

        btnRptMgr3.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr3','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + hdnprimgr.Value.Trim() + "');return false;");
    }

    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSlsChannel.Enabled = true;

        if (rdbChnlTyp.SelectedValue == "0")
        {
            oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "0");
            ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        else
        {
            oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), "1");
            ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlAgntType.Items.Clear();
        ddlAgntType.DataSource = null;
        ddlAgntType.DataBind();
        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
        tblReportingMngrDtls.Visible = false;
        rdbChnlTyp.Focus();
    }
    protected void ddlam1chnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSlsChannel.SelectedValue == "")
        {
            oCommonU.GetAgentType(ddlAgntType, "ALL", "");
        }
        else
        {
            //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString());
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "0");
                }
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "2");
                }
            }
            else
            {
                oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "1");
            }
        }
        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
        if (ddlChnCls.SelectedIndex == 0)
        {
            ddlAgntType.Items.Clear();
            ddlAgntType.DataSource = null;
            ddlAgntType.DataBind();
            ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            tblReportingMngrDtls.Visible = false;
        }
        //added by akshay on 22/01/14 start
        tblReportingMngrDtls.Visible = false;
        //tblPCltDtls.Visible = false;
        ddlChnCls.Focus();
        //added by akshay on 22/01/14 end
    }
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSlsChannel.SelectedValue == "")
        {
            oCommonU.GetAgentType(ddlAgntType, "ALL", "");
        }
        else
        {
            //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString());
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "0");
                }
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "2");
                }
            }
            else
            {
                oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "1");
            }
        }
        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
        if (ddlChnCls.SelectedIndex == 0)
        {
            ddlAgntType.Items.Clear();
            ddlAgntType.DataSource = null;
            ddlAgntType.DataBind();
            ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            tblReportingMngrDtls.Visible = false;
        }
        //added by akshay on 22/01/14 start
        tblReportingMngrDtls.Visible = false;
        //tblPCltDtls.Visible = false;
        ddlChnCls.Focus();
        //added by akshay on 22/01/14 end
    }
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tblReportingMngrDtls.Visible = true;
            //change of int strUnitRank  to decimal strUnitRank due to state in tied
            decimal strUnitRank = 0;
            SqlDataReader dtRead;
            //SqlDataReader dtRead1;
            //Added by Pranjali on 01-07-2013 for fetching data from chnAgnSu Start
            Hashtable htparam = new Hashtable();
            htparam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
            htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
            htparam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
            htparam.Add("@flag", 1);
            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", htparam);
            //Added by Pranjali on 01-07-2013 for fetching data from chnAgnSu end
            //dtRead = dataAccess.exec_reader("Select AgentCreateRul, ORLdrCreateRul, UntRule, AppRule ,CSCPrefix ,CmpBONType,unitrank From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChannel.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                //change of Convert.ToInt32 to Convert.ToDecimal due to state in tied
                strUnitRank = Convert.ToDecimal(dtRead["UnitRank"].ToString());
                hdnCreateRule.Value = dtRead["AgentCreateRul"].ToString();
                hdnEMPCode.Value = dtRead["CmpBONType"].ToString();
                ///added by akshay on 22/01/14 for checking the emp code required start
            }
            //Added by swapnesh on 10/12/2013 to fill Reporting/Manager Details start 
            FillReportingMngrDtls();

            ddlAgntType.Focus();
            //ddlRptMgr.Focus();
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
    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlChnCls.Items.Clear();
        SqlDataReader dtRead;
        //Added by Pranjali on 02-07-2013 for Channel sub class dropdown start
        Hashtable htparam = new Hashtable();
        htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
        dtRead = dataAccess.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
        //Added by Pranjali on 02-07-2013 for Channel sub class dropdown end
        //dtRead = dataAccess.exec_reader("SELECT ChnCls, ChnClsDesc01 AS ChnlDesc FROM ChnClsSU WHERE CarrierCode = '" + Convert.ToInt32(Session["CarrierCode"].ToString()) + "' AND BizSrc='" + ddlSlsChannel.SelectedValue + "'");
        if (dtRead.HasRows)
        {
            ddlChnCls.DataSource = dtRead;
            ddlChnCls.DataTextField = "ChnlDesc";
            ddlChnCls.DataValueField = "ChnCls";
            ddlChnCls.DataBind();
        }
        dtRead = null;
        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlChnCls.Enabled = true;
        if (ddlSlsChannel.SelectedIndex == 0)
        {
            oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
            ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
            ddlAgntType.Items.Clear();
            ddlAgntType.DataSource = null;
            ddlAgntType.DataBind();
            ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            tblReportingMngrDtls.Visible = false;
        }
        ddlSlsChannel.Focus();
    }
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dsResult.Clear();
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@AgtCode", txtAgtCode.Text);
            htParam.Add("@flag", Request.QueryString["ID"].ToUpper().ToString().Trim());

            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        if (Request.QueryString["ID"].ToUpper().ToString().Trim() == "SAP")
                        {
                            if (txtSAPcode.Text != "")
                            {
                                htParam.Add("@SAPcode", txtSAPcode.Text.Trim());
                            }
                            else
                            {
                                htParam.Add("@SAPcode", DBNull.Value);
                            }
                        }

                    }
                }
            }
            //else if (Request.QueryString["ID"] != null)
            //{
            //    if (Request.QueryString["ID"].ToUpper().ToString().Trim() == "LIC")
            //    {
            //        htParam.Add("@LicenseNo", txtBizLicNo.Text);
            //        if (txtBizLicEndDt.Text.Trim() != "")
            //        {
            //            htParam.Add("@LicenseExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
            //        }
            //        else
            //        {
            //            htParam.Add("@LicenseExpDate", System.DBNull.Value);
            //        }
            //        htParam.Add("@OldLicNo", txtBizLicNo.Text);
            //        if (txtBizLicEndDt.Text.Trim() != "")
            //        {
            //            htParam.Add("@OldLicStartDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
            //        }
            //        else
            //        {
            //            htParam.Add("@OldLicStartDate", System.DBNull.Value);
            //        }
            //        if (txtBizLicEndDt.Text.Trim() != "")
            //        {
            //            htParam.Add("@OldLicExpDate", DateTime.Parse(txtBizLicEndDt.Text).ToString("yyyyMMdd"));
            //        }
            //        else
            //        {
            //            htParam.Add("@OldLicExpDate", System.DBNull.Value);
            //        }
            //    }
            //}
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_UpdateSAPLicDetails", htParam);
            htParam.Clear();
            dsResult.Clear();
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                {
                    lbl3.Text = "Employee Updated successfully.";
                    lblMessage.Text = "Employee Updated successfully.";
                    lbl4.Text = "Employee Name:-" + txtAgntName.Text;
                    lbl5.Text = "Employee Code:-" + txtAgtCode.Text;
                }
                else
                {
                    lbl3.Text = "Agent Updated successfully.";
                    lblMessage.Text = "Agent Updated successfully.";
                    lbl4.Text = "Agent Name:-" + txtAgntName.Text;
                    lbl5.Text = "Agent Code:-" + txtAgtCode.Text;
                }
                mdlpopup.Show();
                btnUpdate.Enabled = false;
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                lblMessage.Text = "Error Updating Record!";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                btnUpdate.Enabled = false;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ctgry"] != null)
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" && Request.QueryString["Type"].ToString() == "E")
            {
                //Response.Redirect("~/Application/ISys/ChannelMgmt/AGTSearch.aspx?Type=Emp");
                Response.Redirect("..\\ChannelMgmt\\AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
            }
            //if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven" && Request.QueryString["Type"].ToString() == "N")
            //{
            //    Response.Redirect("~/Application/ISys/ChannelMgmt/AGTSearch.aspx?Type=Ven");
            //}
        }
        else
        {
            //Response.Redirect("~/Application/ISys/ChannelMgmt/AGTSearch.aspx?Type=Agn");
            Response.Redirect("..\\ChannelMgmt\\AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
        }
        
    }
}
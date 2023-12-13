using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
using System.Threading;
using System.Text;
using Insc.Common.Multilingual;
using INSCL.DAL;
using System.Xml;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DataAccessClassDAL;
using System.Web.Script.Serialization;

public partial class Application_INSC_ChannelMgmt_AGTTransfer : BaseClass
{

    #region Global Declaration
    ErrLog objErr = new ErrLog();
    DataAccessClass objDAC = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    private multilingualManager m_olng;
    private multilingualManager m_olng2;
    ///clsAgent Agnet = new clsAgent();
    clsAgent objCls = new clsAgent();
    SqlDataReader dtRead;
    DataSet dsResult = new DataSet();
    private const string c_strBlank = "-- Select --";
    private string m_strUserLang, m_strMgrCode, m_strUnitCode, m_strDirectAgtCode, m_strAgentStatus, m_strAgentTypeAddl;
    string strBizSrc = String.Empty;
    string strBizSrcDesc = String.Empty;
    string strChnCls = String.Empty;
    string strAgentType = String.Empty;
    string cms=String.Empty;
    string unt = String.Empty;
    //Added by rachana 10-07-2013
    string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        { Response.Redirect("~/ErrorSession.aspx"); }

        //Agent Code


        //Declare some auxillary variables
        m_strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
        if (Request.QueryString["Ctgry"] != null)
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "E")
            {   
                m_olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", m_strUserLang);
            }
            if (Request.QueryString["Ctgry"].ToString().Trim() == "A")
            {
                m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
            }
        }
        else
        {
            m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
        }
        Session["CarrierCode"] = '2';
        
        
        //Initialize Agent Category
        lblAgntClassVal.Visible = true;
      //  lblAgntClassVal.Enabled = true;
        lblAgntClassVal.Text = "STAFF";
        //End

        #region IsPostBack
        if (!IsPostBack)
        {
            Session["unt"] = null;
            Session["mem"] = null;
            fillAgtDtls();
          //  MultiViewCrnt.ActiveViewIndex = 0;
            //lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
            lnkHierarchy.CssClass = "btn-subtab btn btn-default";
            hdnTab.Value = "1";
            divPrimry.Attributes.Add("style", "display:none");
            divAdditional.Attributes.Add("style", "display:none");
            divDownlines.Attributes.Add("style", "display:none");
          // MVNewDtls.ActiveViewIndex = 0;
            lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

            //Name Labels
            InitializeControl();
            Session["CHECKED_ITEMS"] = null;

            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "TrmTrf")
                {
                    if (Request.QueryString["AgtCode"] != null)
                    {
                        ViewState["vwsAgntCode"] = Request.QueryString["AgtCode"].ToString().Trim();
                    }
                    else if (Request.QueryString["AgnCd"] != null)
                    {
                        ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();
                    }
                }
            }
            if (Request.QueryString["Ctgry"] != null)
            {
                btnUnitCode.Attributes.Add("OnClientClick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','','Emp');return false;");
            }
            else
            {
                btnUnitCode.Attributes.Add("OnClientClick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','','Agent');return false;");
            }
            if (Request.QueryString["AgnCd"] != null)
            {
                ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();
            }

            #region Initialize Values
            oCommon.getDropDown(ddlTransferReason, "trfReason", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            
            FillddlTransferType();
            

            lblEffectiveDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");

            ddlTransferReason.Items.Insert(0, new ListItem("--Select--", ""));
            ddlTransferType.Items.Insert(0, new ListItem("--Select--", ""));

            ddlSlsChannel.Items.Insert(0, new ListItem("--Select--", ""));
            ddlChnCls.Items.Insert(0, new ListItem("--Select--", ""));
            ddlAgntType.Items.Insert(0, new ListItem("--Select--", ""));

            ddlamrptdesc.Items.Insert(0, new ListItem("--Select--", ""));
            ddlambasedondesc.Items.Insert(0, new ListItem("--Select--", ""));
            ddlamchnldesc.Items.Insert(0, new ListItem("--Select--", ""));
            ddlamsubchnldesc.Items.Insert(0, new ListItem("--Select--", ""));
            ddllvlagttype.Items.Insert(0, new ListItem("--Select--", ""));
            #endregion

            
            //Hide/Show Lables
            manipulateInputControls();

            //Fill Data
            fillAllLabels();

            //Bind the grid to show the Child Father downlines for a agent.
            BindGridRelation("CF", gv_TrfDownlines, lblDownlineErrorMsg);
            BindGridRelation("CF", gv_NewDownlines, lblDwlnErrmsg);
            BindGridDownlines("CF",gv_Dwnls,lbldwnlsmsg);
            if (Request.QueryString["chrt"] != null)
            {
                if (Request.QueryString["chrt"].ToString().Trim() != "")
                {
                    ddlTransferType.SelectedValue = "I";
                    ddlTransferType_SelectedIndexChanged(sender, e);
                }
            }

            #region showing details of members for approve/reject transfer
            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToString() == "Trf")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString() == "A")
                        {
                            btnApprove.Visible = true;
                            btnReject.Visible = true;
                            btnUpdate.Visible = false;
                            GetTrfCrntDtls();
                            GetTrfDetails();
                            ddlTransferType_SelectedIndexChanged(sender, e);
                            tr2.Visible = false;
                            tr3.Visible = false;
                            DisableCtrls();
                            Img.Visible = false;
                            DataSet dsImg = BindGrid();
                            GridImage.DataSource = dsImg;
                            GridImage.DataBind();
                            ///ddlTransferType_SelectedIndexChanged(sender, e);
                            tblNewDts.Visible = true;
                            ddlTransferReason.Enabled = false;
                            ddlTransferType.Enabled = false;
                            txtRemark.Enabled = false;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
    }

    private void FillddlTransferType()
    {
        htParam.Clear();
        dsResult = null;
        htParam.Add("@LookUpCode","trfType");
        htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
        htParam.Add("@ChnCls", hdnChncls.Value.Trim());
        htParam.Add("@MemType", hdnagttyp.Value);
        htParam.Add("@MvmtType","T");

        dsResult = objDAC.GetDataSetForPrc_inscdirect("Prc_GetDdlTransferType", htParam);
        ddlTransferType.DataSource = dsResult;
        ddlTransferType.DataTextField = "ParamDesc";
        ddlTransferType.DataValueField = "ParamValue";
        ddlTransferType.DataBind();

    }
    #endregion

    #region InitializeControl
    protected void InitializeControl()
    {
        //Section AgentInfo-Contains Hierarchy and Additional Manager
        lblPersonalPart.Text = m_olng.GetItemDesc("lblPersonalPart.Text");
        lvlVw1AgntCode.Text = m_olng.GetItemDesc("lvlVw1AgntCode.Text");
        lblVw1AgntStatus.Text = m_olng.GetItemDesc("lblVw1AgntStatus.Text");
        lblClCode.Text = m_olng.GetItemDesc("lblClCode.Text");
        lblExclusive.Text = m_olng.GetItemDesc("lblExclusive.Text");
        lblAgntName.Text = m_olng.GetItemDesc("lblAgntName.Text");
        lblBusinessSrc.Text = m_olng.GetItemDesc("lblBusinessSrc.Text");
        lblCntDetails.Text = m_olng.GetItemDesc("lblCntDetails.Text");
        lblChnCls.Text = m_olng.GetItemDesc("lblChnCls.Text");
        lblVw1AgntType.Text = m_olng.GetItemDesc("lblVw1AgntType.Text");
        lblAgntClass.Text = m_olng.GetItemDesc("lblAgntClass.Text");
        //Personal Client Details
        lblCode.Text = m_olng.GetItemDesc("lblCode.Text");
        lblchnltype.Text = m_olng.GetItemDesc("lblchnltype.Text");
        lblchannel.Text = m_olng.GetItemDesc("lblchannel.Text");
        lblsubchannel.Text = m_olng.GetItemDesc("lblsubchannel.Text");
        lbllevelagttype.Text = m_olng.GetItemDesc("lbllevelagttype.Text");
        lblUntCde.Text = m_olng.GetItemDesc("lblUntCde.Text");
        Label26.Text = m_olng.GetItemDesc("lblUntCde.Text");
    }
    #endregion

    #region BindGridRelationMethod
    protected void BindGridRelation(string strtype, GridView gv, Label errmsg)
    {
        try
        {
            trDownlines.Visible = false;

            DataSet dsGrid = new DataSet();
            Hashtable httable = new Hashtable();
            dsGrid.Clear();
            httable.Clear();
            httable.Add("@AgtCode", lblAgtCodeVal.Text);
            httable.Add("@RptType", strtype.ToString().Trim());

            dsGrid = objDAC.GetDataSetForPrcCLP("Prc_GetRelationForAgtCode", httable);
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
                {
                    trDownlines.Visible = true;
                    gv.Visible = true;
                    gv.DataSource = dsGrid;
                    gv.DataBind();
                    ViewState["dsGrid"] = dsGrid;

                    errmsg.Visible = false;
                    errmsg.Visible = false;
                }
                else
                {
                    gv.Visible = false;
                    gv.Visible = false;
                    //gv_TrfDownlines.DataBind();
                    trDownlines.Visible = true;
                    errmsg.Visible = true;
                    errmsg.Visible = true;
                }
            }
            else
            {
                gv.Visible = false;
                gv.Visible = false;
                //gv_TrfDownlines.DataBind();
                trDownlines.Visible = true;
                errmsg.Visible = true;
                errmsg.Visible = true;
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
            //con.Close();
        }
    }
    #endregion

    #region CF and CU click Events
    protected void lnkbtnCF_Click(object sender, EventArgs e)
    {
        BindGridRelation("CF",gv_TrfDownlines,lblDownlineErrorMsg);
        if(hdnTab.Value == "3")
        //if (MultiViewCrnt.ActiveViewIndex == 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        }
    }
    protected void lnkbtnCU_Click(object sender, EventArgs e)
    {
        BindGridRelation("CU", gv_TrfDownlines, lblDownlineErrorMsg);
       // if (MultiViewCrnt.ActiveViewIndex == 2)
        if (hdnTab.Value == "3")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        }
    }
    #endregion

    #region Supplementary Functions

    protected void setMovementLogEntry()
    {
        try
        {
            //Reinitialize and Fill Parameters
            htParam.Clear();
            htParam.Add("@MovementType", "Member Transfer");
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htParam.Add("@AgentType", lblAgntTypeVal.Text);
            htParam.Add("@UserId", Session["UserID"].ToString());
            htParam.Add("@StatusFlag", "RQ");
            htParam.Add("@CreatedBy", Session["UserID"].ToString());
            /*CreatedDatetime is AutoFilled*/
            //   htParam.Add("@UpdatedBy", System.DBNullValue);
            //   htParam.Add("@UpdatedDateTime", System.DBNullValue);

            //Execute Query
            objDAC.exec_comm_command("prc_SetMovementLogEntry", htParam);
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

    protected void manipulateInputControls()
    {
        rdbChnlTyp.Enabled = false;

        //lblCusmIdVal.Enabled = true;
        //lblAgtCodeVal.Enabled = true;
        //lblAgntNameVal.Enabled = true;
        //lblagnTitleVal.Enabled = true;
        //lblAgntStatusVal.Enabled = true;

    }

    protected void FillRequiredDataForPage1()
    {
        dsResult = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString().Trim());
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        try
        {
            dsResult = objDAC.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["ChnlType"].ToString().Trim() == "True")
                    {
                        rdbChnlTyp.Text = "1";
                    }
                    else
                    {
                        rdbChnlTyp.Text = "0";
                    }

                    DataSet dsResultTemp = new DataSet();

                    lblSlsChannelVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblchanneldescVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblAgtCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]);
                    lblCusmIdVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]);
                    lblCltCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]).ToUpper();
                    lblGenderVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]).ToUpper();
                    strBizSrc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    strChnCls = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);///added by akshay on 25/03/14
                    strBizSrcDesc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblagnTitleVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgnTitle"]);
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                   // lblRptMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MgrName"]);
                    hdnRptMgr.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["MgrCode"]);
                    //lblam1lMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AddlMgrName1"]);
                    hdnRptMgr1.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1MgrCode"]);
                    //lblam2lMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AddlMgrName2"]);
                    hdnRptMgr2.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2MgrCode"]);
                    //lblam3lMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AddlMgrName3"]);
                    hdnRptMgr3.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl3MgrCode"]);
                    cms = dsResult.Tables[0].Rows[0]["UntCms"].ToString().Trim();
                    unt = dsResult.Tables[0].Rows[0]["Unt"].ToString().Trim();
                   // lblUntCode.Text = unt + "(" + cms + ")";
                    hdnUnitCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]);
                    lblUntAddr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["untadr"]);
                    hdnsapcode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]);
                    hdnNwUntcd.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]);


                    //added by mrunal to show current details of unitcode
                    DataSet ds = new DataSet();
                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@MemCode", dsResult.Tables[0].Rows[0]["MemCode"]);
                    ds = objDAC.GetDataSetForPrcCLP("Prc_GetUntCodes", htParam);
                    gvolduntlst.DataSource = ds.Tables[0];
                    gvolduntlst.DataBind();

                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@MemCode", dsResult.Tables[0].Rows[0]["MemCode"]);
                    ds = objDAC.GetDataSetForPrcCLP("Prc_GetRptMemCodes", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvoldprimary.DataSource = ds.Tables[0];
                        gvoldprimary.DataBind();                     
                    }

                    for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
                    {

                        GridView gvoldAddlMgr = gv_RptMngr_Crnt.Rows[i].FindControl("gvoldAddlMgr") as GridView;

                        htParam.Clear();
                        ds.Clear();
                        htParam.Add("@MemCode", dsResult.Tables[0].Rows[0]["MemCode"]);
                        htParam.Add("@RelOrder", i + 1);
                        ds = objDAC.GetDataSetForPrcCLP("Prc_GetAddlRptMemCodes", htParam);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            gvoldAddlMgr.DataSource = ds.Tables[0];
                            gvoldAddlMgr.DataBind();
                            Session["addlmem"] = ds;
                        }
                    }

                    //end

                    if (dsResult.Tables[0].Rows[0]["MemStatus"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemStatus"]).Trim() != "")
                        {
                            m_strAgentStatus = Convert.ToString(dsResult.Tables[0].Rows[0]["MemStatus"]).Trim();
                            lblAgntStatusVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgtStatusDesc"]).Trim().ToUpper();
                        }
                    }

                    #region Add: Parag @ 27022014 - Internal Database declarations
                    //Declaration for some Inside Data fecthing
                    SqlDataReader dtRead;
                    Hashtable htparam = new Hashtable();
                    DataSet dsResulttemp = new DataSet();
                    #endregion

                    if (dsResult.Tables[0].Rows[0]["MemType"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim() != "")
                        {
                            //To allow change in agenttype
                            if (m_strAgentStatus == "IF")
                            {

                                string strAgntType = String.Empty;
                                dtRead = null;
                                strAgntType = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim();
                                //Added by Pranjali on 02-07-2013 for getting unitrank from chnAgnSu start
                                htparam.Clear();
                                htparam.Add("@AgentType", strAgntType);
                                htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                htparam.Add("@BizSrc", strBizSrc);
                                htparam.Add("@ChnCls", strChnCls);
                                htparam.Add("@flag", 20);
                                dtRead = objDAC.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htparam);
                            }
                            lblAgntTypeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentTypeDesc"]).Trim();
                        }
                    }
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    FillReportingMngrDtls();
                }
            }
            Img.Visible = false;
            DataSet dsImg = BindGrid();
            GridImage.DataSource = dsImg;
            GridImage.DataBind();
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

            Hashtable htParam = new Hashtable();
            Hashtable htParam2 = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            htParam.Add("@AgentCode", lblAgtCodeVal.Text);
            htParam.Add("@AgentType", strAgentType);
            htParam.Add("@BizSrc", strBizSrc);
            htParam.Add("@ChnCls", strChnCls);
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforRptmgr", htParam);

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    lblprimrepoVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryReportingTypeDes"].ToString();
                    lblbasedondescVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnTypeDes"].ToString();
                    lblsubchnldescVal.Text = dsRpt.Tables[0].Rows[0]["PrimarySubChannelDes"].ToString();
                    lbllvlagtVal.Text = dsRpt.Tables[0].Rows[0]["RelMemTypeDes"].ToString();
                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();


                    // if (MultiViewCrnt.ActiveViewIndex == 2)
                    if (hdnTab.Value == "3")
                    {
                        ///ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
                        ////funShowCrntMgr(lbladditionalreportingrule.Text.Trim(), tblmgr1, tblmgr2, tblmgr3, tblReportingMngrDtls, lblam1rptdescVal.Text, lblam2rptdescVal.Text, lblam3rptdescVal.Text);
                    }
                }
                else
                {
                    //if (MultiViewCrnt.ActiveViewIndex == 2)
                    if (hdnTab.Value == "3")
                    {
                        ////ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                        ///funShowCrntMgr("empty", tblmgr1, tblmgr2, tblmgr3, tblReportingMngrDtls, lblam1rptdescVal.Text, lblam2rptdescVal.Text, lblam3rptdescVal.Text);
                    }
                }
            }
            else
            {
                // if (MultiViewCrnt.ActiveViewIndex == 2)
                if (hdnTab.Value == "3")
                {
                    ////ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                    ////funShowCrntMgr("empty", tblmgr1, tblmgr2, tblmgr3, tblReportingMngrDtls, lblam1rptdescVal.Text, lblam2rptdescVal.Text, lblam3rptdescVal.Text);
                }
            }
            #region Mandatory Managers
            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    hdnPriMandatory.Value = dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString();

                    if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                    {
                        /////txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        spnrpt.Visible = true;
                    }
                    else
                    {
                        spnrpt.Visible = false;
                    }

                }
            }
            #endregion

            fillAddlRptMngrDtls();
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
    private DataSet BindGrid()
    {
        try
        {
            Hashtable httable = new Hashtable();
            httable.Add("@AgtCode", ViewState["vwsAgntCode"].ToString());
            dsResult.Clear();
            dsResult = objDAC.GetDataSetForPrcCLP("Prc_GetImageForAgents", httable);
        }
        catch (Exception ex)
        {
            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ex.Message);
            var script = string.Format("alert({0});", message);
            ClientScript.RegisterStartupScript(Page.GetType(), "", script, true);
        }
        return dsResult;
    }

    protected void fillAllLabels()
    {
        DataSet tempds = new DataSet();
        htParam.Clear();

        try
        {
            //Sales Channel DropDown
            htParam.Clear();
            htParam.Add("@carriercode", "2");
            htParam.Add("@UserId", Session["UserID"].ToString());
            htParam.Add("@strIncMasterCmp", 0);
            htParam.Add("@Flag", 1);

            DataSet DS = new DataSet();
            Hashtable HT = new Hashtable();
            HT.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            DS = objDAC.GetDataSetForPrc("prc_GetChnlTypeByAgentCode", HT);
            int valChnType = Convert.ToInt16(DS.Tables[0].Rows[0]["chnltype"]);
            HT.Clear();
            DS.Clear();

            if (valChnType == 1)
                htParam.Add("@chnltyp", "1");
            if (valChnType == 0)
                htParam.Add("@chnltyp", "0");

            tempds = objDAC.GetDataSetForPrc("Prc_GetUserSalesChannel", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                lblSlsChannelVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
                lblchanneldescVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
                strBizSrc = Convert.ToString(tempds.Tables[0].Rows[0]["BizSrc"]);
                tempds.Clear();
            }
            //End

            //Channel Class Dropdown
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@BizSrc", strBizSrc);
            tempds = objDAC.GetDataSetForPrc("Prc_ddlchnnlsubcls", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                lblChnClsVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChnlDesc"]);
                strChnCls = Convert.ToString(tempds.Tables[0].Rows[0]["ChnCls"]);
                tempds.Clear();
            }
            //End

            //Agent  Class Dropdown
            /*Agent class preselected to same values in all cases to STAFF*/
            //End

            //Agent Type DropDown
            //htParam.Clear();
            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htParam.Add("@BizSrc", strBizSrc);
            //tempds = objDAC.GetDataSetForPrc("Prc_getAgentTypeWithCode", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblAgntTypeVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["MemTypeDesc01"]);
            //    strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["MemType"]);
                
            //}
            //End

            //An extra function to obtain the agent type on agent code
            htParam.Clear();
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htParam.Add("@Flag", 4);
            tempds = objDAC.GetDataSetForPrc("prc_GetAgnCodeandAgnName", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["MemType"]);
                hdnAgntType.Value = strAgentType.ToString().Trim();
                ViewState["code"] = strAgentType.ToString().Trim();
            }
            //End

            FillRequiredDataForPage1();
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

    #region btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Transfer();

       TransferAppRej("A");
        //if (chkMemRole() == "E")
        //{
        //    ChkUnitCode("E");
        //}
        //else
        //{
        //    if (chkMemRole() == "A")
        //    {
        //        ChkUnitCode("A");
        //    }
        //}
        
    }
    #endregion

    #region ChkUnitCode
    protected void ChkUnitCode(string ctrgy)
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Clear();
        ht.Add("@MgrCode", hdnNRptMgr.Value.Trim());
        ht.Add("@UnitCode", hdnNwUntcd.Value.Trim());
        ht.Add("@flag", ctrgy.ToString().Trim());
        ds = objDAC.GetDataSetForPrc("Prc_MatchMgrUnitCode", ht);
        string unt = string.Empty;
        try
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    unt = ds.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select a Valid Unit Code');</script>", false);
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

    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString() == "A")
            {
                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"].ToString() == "Trf")
                    {
                        Response.Redirect("MemMvmtAppr.aspx", false);
                    }
                }
            }
            else if (Request.QueryString["flag"].ToString() == "TrmTrf")
            {
                Response.Redirect("AGTTermination.aspx", false);
            }
        }
        else if (Request.QueryString["Ctgry"] != null)
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" && Request.QueryString["Type"].ToString() == "E")
            {
                Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
            }
        }
        else
        {
            Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
        }
    }
    #endregion

    #region gv_TrfDownlines_PageIndexChanging
    protected void gv_TrfDownlines_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_TrfDownlines.PageIndex = e.NewPageIndex;
            dv.Sort = gv_TrfDownlines.Attributes["SortExpression"];

            if (gv_TrfDownlines.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_TrfDownlines.DataSource = dv;
            gv_TrfDownlines.DataBind();
            ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
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

    #region gv_TrfDownlines_Sorting
    protected void gv_TrfDownlines_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
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

    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = gv_TrfDownlines.PageIndex + 1;
        string pageind = "Page " + intPageIndex.ToString() + " of " + gv_TrfDownlines.PageCount;
    }
    #endregion

    #region lnkCrntHier_Click
    protected void lnkCrntHier_Click(object sender, ImageClickEventArgs e)
    {
       // MultiViewCrnt.ActiveViewIndex = 0;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;
        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion

    #region lnkCrntPrimMgr_Click
    protected void lnkCrntPrimMgr_Click(object sender, ImageClickEventArgs e)
    {
       // MultiViewCrnt.ActiveViewIndex = 1;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion

    #region lnkCrntAddlMgr_Click
    protected void lnkCrntAddlMgr_Click(object sender, ImageClickEventArgs e)
    {
      //  MultiViewCrnt.ActiveViewIndex = 2;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        ///ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion

    #region lnkCrntDlines_Click
    protected void lnkCrntDlines_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 3;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";

        BindGridRelation("CF", gv_TrfDownlines, lblDownlineErrorMsg);
        BindGridDownlines("CF", gv_Dwnls, lbldwnlsmsg);
    }
    #endregion

    #region lnkCrntHierNew_Click
    protected void lnkCrntHierNew_Click(object sender, ImageClickEventArgs e)
    {
      // MVNewDtls.ActiveViewIndex = 0;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
      //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion 

    #region lnkCrntPrimMgrNew_Click
    protected void lnkCrntPrimMgrNew_Click(object sender, ImageClickEventArgs e)
    {
       //MVNewDtls.ActiveViewIndex = 1;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";
      //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        //lblNwUntcd.Text = hdnNwUntcd.Value.Trim();
        //hdnNRptMgr.Value = lblNwRptMgr.Text;
        
    }
    #endregion 

    #region lnkCrntAddlMgrNew_Click
    protected void lnkCrntAddlMgrNew_Click(object sender, ImageClickEventArgs e)
    {
      //  MVNewDtls.ActiveViewIndex = 2;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        ////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
     //   lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        //hdnRptMgr1.Value = lblrptmgr1.Text;
        //hdnRptMgr2.Value = lblrptmgr2.Text;
        //hdnRptMgr3.Value = lblrptmgr3.Text;
        
    }
    #endregion

    #region lnkCrntDlinesNew_Click
    protected void lnkCrntDlinesNew_Click(object sender, ImageClickEventArgs e)
    {
     // MVNewDtls.ActiveViewIndex = 3;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
      //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";

        BindGridRelation("CF",gv_NewDownlines,lblDwlnErrmsg);
    }
    #endregion

    #region ddlSlsChannel_SelectedIndexChanged
    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSubChannels();
    }
    #endregion

    #region ddlChnCls_SelectedIndexChanged
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAgentTypes();
    }
    #endregion 

    #region ddlAgntType_SelectedIndexChanged
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillMgrDetails(ddlAgntType.SelectedValue.ToString());
    }
    #endregion

    #region ddlam1chnldesc_SelectedIndexChanged
    protected void ddlam1chnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlam1subchnldesc_SelectedIndexChanged
    protected void ddlam1subchnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlam2chnldesc_SelectedIndexChanged
    protected void ddlam2chnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlam2subchnldesc_SelectedIndexChanged
    protected void ddlam2subchnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlam3chnldesc_SelectedIndexChanged
    protected void ddlam3chnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlam3subchnldesc_SelectedIndexChanged
    protected void ddlam3subchnldesc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ddlTransferType_SelectedIndexChanged
    protected void ddlTransferType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////tblNewDts.Visible = true;
        if (ddlTransferType.SelectedValue == "I" || ddlTransferType.SelectedValue == "G" || ddlTransferType.SelectedValue == "C")
        {
            //tblNewDts.Visible = true;
            //tr2.Visible = false;
            //tr3.Visible = false;
            //trdwnl.Visible = false;
            tblNewDts.Attributes.Add("style", "display:block");
            Hierarchy_Click(this,EventArgs.Empty);
            gv.DataSource = null;
            gv.DataBind();
            gvUntLst.DataSource = null;
            gvUntLst.DataBind();
            divprimnew.Attributes.Add("style", "display:none");
            PrimaryDemo.Attributes.Add("style", "display:none");
            divdwnldtls.Attributes.Add("style", "display:none");
            tr2.Attributes.Add("style", "display:none");
            tr3.Attributes.Add("style", "display:none");
            trdwnl.Attributes.Add("style", "display:none");
            GetTrfCrntDtls();
        }
        else if (ddlTransferType.SelectedValue == "D")
        {
            tblNewDts.Visible = true;
            GetTrfCrntDtls();
            tblNewDts.Attributes.Add("style", "display:block");
            Hierarchy_Click(this, EventArgs.Empty);
            gv.DataSource = null;
            gv.DataBind();
            gvUntLst.DataSource = null;
            gvUntLst.DataBind();
            divprimnew.Attributes.Add("style", "display:none");
            PrimaryDemo.Attributes.Add("style", "display:none");
            divdwnldtls.Attributes.Add("style", "display:none");
           // tr3.Visible = true;
            tr3.Attributes.Add("style", "display:block");
            //tr2.Visible = false;
            tr2.Attributes.Add("style", "display:none");
            //trdwnl.Visible = true;
            trdwnl.Attributes.Add("style", "display:block");
         
            FillDwnlMem(lblAgtCodeVal.ToString().Trim(), ddldwnlMem);
        }
        else 
        {
            tblNewDts.Visible = false;
        }
        //if (ddlTransferType.SelectedValue == "C")
        //{
        //    rblChnlType.Enabled = true;
        //    ddlSlsChannel.Enabled = true;
        //    ddlChnCls.Enabled = true;
        //    ddlAgntType.Enabled = true;
        //}
    }
    #endregion

    #region rblChnlType_SelectedIndexChanged
    protected void rblChnlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSlsChannel.Enabled = true;

        try
        {
            if (rblChnlType.SelectedValue == "0")
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
            ////rdbChnlTyp.Focus();
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

    #region GetSubChannels
    protected void GetSubChannels()
    {
        try
        {
            ddlChnCls.Items.Clear();
            SqlDataReader dtRead;
            //Added by Pranjali on 02-07-2013 for Channel sub class dropdown start
            Hashtable htparam = new Hashtable();
            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue.Trim());
            dtRead = objDAC.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
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
            ///ddlChnCls.Enabled = true;
            if (ddlSlsChannel.SelectedIndex == 0)
            {
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlAgntType.Items.Clear();
                ddlAgntType.DataSource = null;
                ddlAgntType.DataBind();
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                tblReportingMngrDtls.Visible = false;
                tblUnitCodeDetails.Visible = false;
            }
            ///ddlSlsChannel.Focus();
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

        #region Clear Primary Manager Details
        txtRptMgr.Text = "";
        hdnNRptMgr.Value = null;
        lblNwRptMgr.Text = "";
        txtNewUntCode.Text = "";
        lblNwUntcd.Text = "";
        hdnNewUntAdr.Value = null;
        ///hdnUntCode.Value = null;
        #endregion
    }
    #endregion

    #region GetAgentTypes
    protected void GetAgentTypes()
    {
        try
        {
            if (ddlSlsChannel.SelectedValue == "")
            {
                oCommonU.GetAgentType(ddlAgntType, "ALL", "");
            }
            else
            {
                //oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString());
                if (chkMemRole() == "E")
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), Request.QueryString["Ctgry"].ToString().Trim());
                }
                else
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "A");
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
                tblUnitCodeDetails.Visible = false;
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

        #region Clear Primary Manager Details
        txtRptMgr.Text = "";
        hdnNRptMgr.Value = null;
        lblNwRptMgr.Text = "";
        txtNewUntCode.Text = "";
        lblNwUntcd.Text = "";
        hdnNewUntAdr.Value = null;
        ///hdnUntCode.Value = null;
        #endregion

        
    }
    #endregion

    #region FillMgrDetails
    /// <summary>
    /// method to get reporting manager details
    /// </summary>
    protected void FillMgrDetails(string agtyp)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();

            htParam.Add("@AgentType", agtyp.ToString().Trim());
            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
            htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);


            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToString() == "Trf")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString() == "A")
                        {
                            htParam.Clear();
                            htParam.Add("@AgentCode", ViewState["vwsAgntCode"]);
                            dsRpt.Clear();
                            dsRpt = objDAC.GetDataSetForPrc("Prc_GetNewDtlsForTrf", htParam);
                            //txtRptMgr.Text = dsRpt.Tables[0].Rows[0]["Mgr"].ToString().Trim() + "(" + dsRpt.Tables[0].Rows[0]["EmpCode"].ToString().Trim() + ")";
                            //hdnNRptMgr.Value = dsRpt.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                            //lblNwRptMgr.Text = dsRpt.Tables[0].Rows[0]["MemCode"].ToString().Trim();

                        }
                    }
                }
            }

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    FillReportingMngrddl();

                    ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();

                    string PrmyRptType = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                    hdnRptSetup.Value = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                    ddlambasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString().Trim();
                    
                    FillReportingMngrchnl();
                    ddlamchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString().Trim();

                    FillReportingMngrsubchnl();
                    ddlamsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString().Trim();
                    FillReportingMngrAgttype();
                    ddllvlagttype.Enabled = true;
                    #region fetch member type

                    if (Request.QueryString["Type"] != null)
                    {
                       
                        if (PrmyRptType == "E" && ddlambasedondesc.SelectedValue == "1")
                        {
                            ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                            hdnPriMemTyp.Value = ddllvlagttype.SelectedValue.Trim();
                            ddllvlagttype.Enabled = false;
                        }
                        else if (PrmyRptType == "E" && ddlambasedondesc.SelectedValue == "0")
                        {
                            //ddllvlagttype.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim(),
                            //    ddlamchnldesc.SelectedValue.ToString().Trim(), ddlamsubchnldesc.SelectedValue.ToString().Trim());
                            hdnMemType.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                            hdnPriMemTyp.Value = ddllvlagttype.SelectedValue.Trim();
                        }
                        else
                        {
                            hdnMemType.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                            ddllvlagttype.Enabled = true;
                        }
                    }
                    #endregion
                    hdnchn.Value = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                    hdnsubchn.Value = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();
                    DataSet dschrt = new DataSet();
                    Hashtable htchrt = new Hashtable();
                    dschrt.Clear();
                    if (Request.QueryString["chrt"] != null)
                    {
                        if (Request.QueryString["chrt"].ToString().Trim() != "")
                        {
                            htchrt.Clear();
                            htchrt.Add("@AgentCode", Request.QueryString["chrt"].ToString().Trim());
                            htchrt.Add("@CarrierCode", Session["CarrierCode"].ToString().Trim());
                            htchrt.Add("@LanguageCode", Session["LanguageCode"].ToString().Trim());
                            dschrt = objDAC.GetDataSetForPrcCLP("prc_AgyAdmin_getAgtDt1", htchrt);
                            if (dschrt.Tables.Count > 0)
                            {
                                if (dschrt.Tables[0].Rows.Count > 0)
                                {
                                    ddlamchnldesc.SelectedValue = dschrt.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                                    ddlamsubchnldesc.SelectedValue = dschrt.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                                    oCommonU.GetAgentTypeForSlsChnnlCTSearch(ddllvlagttype, ddlamchnldesc.SelectedValue, ddllvlagttype.SelectedValue, ddlamsubchnldesc.SelectedValue, Session["UserID"].ToString(), chkMemRole());
                                    ddllvlagttype.SelectedValue = dschrt.Tables[0].Rows[0]["MemType"].ToString().Trim();
                                    hdnchn.Value = dschrt.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                                    hdnsubchn.Value = dschrt.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                                    hdnMemType.Value = dschrt.Tables[0].Rows[0]["MemType"].ToString().Trim();
                                    hdnPriMemTyp.Value = dschrt.Tables[0].Rows[0]["MemType"].ToString().Trim();
                                    hdnName.Value = dschrt.Tables[0].Rows[0]["LegalName"].ToString().Trim();
                                    hdnUntCode.Value = dschrt.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                                }
                            }
                        }
                    }

                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();
                    ViewState["code"] = agtyp.ToString().Trim();

                }
            }
           fillNewAddlRptMngrDtls(agtyp.ToString().Trim()); //commented by mrunal on 20.02.18
            #region Mandatory Managers
            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    hdnPriMandatory.Value = dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString();

                    if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                    {
                        /////txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        spnrpt.Visible = true;
                    }
                    else
                    {
                        spnrpt.Visible = false;
                    }
                    
                }
            }
            #endregion
           // FillUntRptDtls();// chnage by mrunal on 20.02.18
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

    #region FillReportingMngrddl
    protected void FillReportingMngrddl()
    {
        try
        {
            oCommon.getDropDown(ddlamrptdesc, "Rpttype", 1, "", 1, c_strBlank);
            //oCommon.getDropDown(ddlam1rptdesc, "Rpttype", 1, "", 1, c_strBlank);
            //oCommon.getDropDown(ddlam2rptdesc, "Rpttype", 1, "", 1, c_strBlank);
            //oCommon.getDropDown(ddlam3rptdesc, "Rpttype", 1, "", 1, c_strBlank);

            //ddlamrptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam1rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam2rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam3rptdesc.Items.Insert(0, new ListItem("-- Select --", ""));

            oCommon.getDropDown(ddlambasedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            //oCommon.getDropDown(ddlam1basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            //oCommon.getDropDown(ddlam2basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            //oCommon.getDropDown(ddlam3basedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            ddlambasedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam1basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam2basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
            //ddlam3basedondesc.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region FillReportingMngrchnl
    protected void FillReportingMngrchnl()
    {
        try
        {
            funchnlpopup(ddlamchnldesc);
            //funchnlpopup(ddlam1chnldesc);
            //funchnlpopup(ddlam2chnldesc);
            //funchnlpopup(ddlam3chnldesc);
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

    #region funchnlpopup
    protected void funchnlpopup(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dtRead = objDAC.Common_exec_reader_prc("Prc_ddlmgrchnnl", htparam);
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

    #region FillReportingMngrsubchnl
    protected void FillReportingMngrsubchnl()
    {
        try
        {
            funsubchnlpopup(ddlamsubchnldesc, ddlamchnldesc.SelectedItem.Text);
            //funsubchnlpopup(ddlam1subchnldesc, ddlam1chnldesc.SelectedItem.Text);
            //funsubchnlpopup(ddlam2subchnldesc, ddlam1chnldesc.SelectedItem.Text);
            //funsubchnlpopup(ddlam3subchnldesc, ddlam1chnldesc.SelectedItem.Text);
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
            dtRead = objDAC.Common_exec_reader_prc("Prc_ddlmgrsubchnnl", htparam);
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



    #region FillReportingMngrAgttype
    protected void FillReportingMngrAgttype()
    {
        try
        {
            //funagttyppopup(ddllvlagttype, ddlamchnldesc.SelectedValue.Trim(), ddlamsubchnldesc.SelectedValue.Trim(), ddlambasedondesc.SelectedValue.Trim());
            funagttyppopup(ddllvlagttype, "", "0");
            //funagttyppopup(ddllvlagttype1, ddlam1chnldesc.SelectedValue.Trim(), ddlam1subchnldesc.SelectedValue.Trim(), ddlam1basedondesc.SelectedValue.Trim());
            //funagttyppopup(ddllvlagttype2, ddlam2chnldesc.SelectedValue.Trim(), ddlam2subchnldesc.SelectedValue.Trim(), ddlam2basedondesc.SelectedValue.Trim());
            //funagttyppopup(ddllvlagttype3, ddlam3chnldesc.SelectedValue.Trim(), ddlam3subchnldesc.SelectedValue.Trim(), ddlam3basedondesc.SelectedValue.Trim());
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

    #region funagttyppopup
    protected void funagttyppopup(DropDownList ddl, string txtchn, string txtsubchn,string txtbsdon)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@chnl", txtchn.Trim());
            htparam.Add("@subchnl", txtsubchn.Trim());
            htparam.Add("@BsdOn", txtbsdon.ToString().Trim());
             dtRead = objDAC.Common_exec_reader_prc("Prc_ddlmgragttyp", htparam);//[Prc_GetRptAgtTyp_AgtInfo]
            //dtRead = objDAC.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region GetManagers
    protected void GetManagers()
    {
        try
        {
            if (chkMemRole() == "E")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + ddllvlagttype.SelectedValue + "','Emp','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
            }
            else if (chkMemRole() == "A")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + ddllvlagttype.SelectedValue + "','Agent','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
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

   

    #region funShowCrntMgr
    ///method to show reporting manager sections of current details and new details tab
    public void funShowCrntMgr(string str, HtmlTable tblmg1, HtmlTable tblmg2, HtmlTable tblmg3, HtmlTable tblrpt, string lbl1, string lbl2, string lbl3)
    {
        try
        {
            if (str == "")
            {
                tblmg1.Visible = false;
                tblmg2.Visible = false;
                tblmg3.Visible = false;
            }
            if (str == "Multiple-1")
            {
                tblmg1.Visible = true;
                tblmg2.Visible = false;
                tblmg3.Visible = false;
            }
            if (str == "Multiple-2")
            {
                tblmg1.Visible = false;
                tblmg2.Visible = true;
                tblmg3.Visible = false;
            }
            if (str == "empty")
            {
                tblrpt.Visible = false;
            }
            if (lbl1 == "")
            {
                tblmg1.Visible = false;
            }
            if (lbl2 == "")
            {
                tblmg2.Visible = false;
            }
            if (lbl3 == "")
            {
                tblmg3.Visible = false;
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

    #region GetTrfCrntDtls method
    ///method to get details of all members
    protected void GetTrfCrntDtls()
    {
        Hashtable htParam = new Hashtable();
        dsResult = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString().Trim());
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        try
        {
            dsResult = objDAC.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["ChnlType"].ToString().Trim() == "True")
                    {
                        rblChnlType.Text = "1";
                    }
                    else
                    {
                        rblChnlType.Text = "0";
                    }
                }

                oCommonU.GetSalesChannel(ddlSlsChannel, "", 0, Session["UserID"].ToString(), rblChnlType.Text.Trim());
                ddlSlsChannel.Items.Insert(0, new ListItem("-- Select --", ""));
                if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                    {
                        ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                    }
                }
                GetSubChannels();
                ////ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
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
                GetAgentTypes();
                /////ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlAgntType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim();

                cms = dsResult.Tables[0].Rows[0]["UntCms"].ToString().Trim();
                unt = dsResult.Tables[0].Rows[0]["Unt"].ToString().Trim();
                /////txtNewUntCode.Text = unt + "(" + cms + ")";
                lblNwUntcd.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]);

                FillMgrDetails(ddlAgntType.SelectedValue.ToString().Trim());
                
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

    #region chkUnt_CheckedChanged
    protected void chkUnt_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUnt.Checked == true)
        {
            txtNewUntCode.Enabled = true;
            btnUnitCode.Enabled = true;
            txtNewUntCode.Text = "";
            txtNewUntCode.Enabled = false;
            lblNwUntcd.Text = "";
            hdnNwUntcd.Value = null;
            txtRptMgr.Text = "";
            //txtRptMgr1.Text = "";
            //txtRptMgr2.Text = "";
            //txtRptMgr3.Text = "";
        }
        else
        {
            //if (txtNewUntCode.Text == "")
            //{
            //    chkUnt.Checked = true;
            //    ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('Please Select Unit Code');</script>", false);
            //}
            //else
            //{
            //    txtNewUntCode.Enabled = false;
            //    btnUnitCode.Enabled = false;
            //}
        }
    }
    #endregion

    #region TranferReq Method
     //<summary>
     //method to send transfer request for an Individual/Group transfer type
     //</summary>
    public void TranferReq()
    {
        //clsChannelSetup objChnSetup = new clsChannelSetup();
        dsResult = new DataSet();
        ArrayList arrResult = new ArrayList();
        Hashtable htable = new Hashtable();

        htable.Clear();
        arrResult.Clear();
        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htable.Add("@TrfReason", ddlTransferReason.SelectedValue);
        htable.Add("@TrfType", ddlTransferType.SelectedValue);
        htable.Add("@Remark", txtRemark.Text);
        htable.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));
        htable.Add("@EMPCode", hdnsapcode.Value);
        htable.Add("@MovementType", "TRF");
        htable.Add("@StatusFlag", "PN");
        htable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));
        htable.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));
        ////htable.Add("@EffDate", DateTime.Parse(lblEffectiveDate.Text).ToString("yyyyMMdd"));
        htable.Add("@AgentCode ", lblAgtCodeVal.Text);
        htable.Add("@UnitCode", hdnUnitCode.Value);
        if (hdnUnitCode.Value == lblNwUntcd.Text)
        {
            htable.Add("@NewUntCode", lblNwUntcd.Text);
        }
        else
        {
            htable.Add("@NewUntCode", hdnNwUntcd.Value);
        }
        if (Request.QueryString["MvmtMode"] != null)
        {
            if (Request.QueryString["MvmtMode"].ToString().Trim() != "")
            {
                htable.Add("@MvmtLvl", Request.QueryString["MvmtMode"].ToString().Trim());
            }
        }

        //htable.Add("@PrimaryReportingType", ddlamrptdesc.SelectedValue.ToString().Trim());
        //htable.Add("@PrimaryBizSrc", ddlamchnldesc.SelectedValue.ToString().Trim());
        //htable.Add("@PrimaryChnSubCls", ddlamsubchnldesc.SelectedValue.ToString().Trim());
        //htable.Add("@PrimaryMgrType", ddllvlagttype.SelectedValue.ToString().Trim());
        //htable.Add("@PrimaryMgrCode", hdnNRptMgr.Value.Trim());

        #region Addition Manager PArt
        //if (gv_RptMngr_new.Rows.Count.ToString() == "1")
        //{
        //    DropDownList ddlAdlRptTyp1 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlRptTyp") as DropDownList;
        //    DropDownList ddlAdlChn1 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlChn") as DropDownList;
        //    DropDownList ddlAdlSChn1 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlSChn") as DropDownList;
        //    DropDownList ddlAdlAgtTyp1 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlAgtTyp") as DropDownList;
        //    HiddenField hdnAddlRptMgr1 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;

        //    htable.Add("@AddlReportingType1", ddlAdlRptTyp1.SelectedValue.ToString().Trim());
        //    htable.Add("@Addl1BizSrc", ddlAdlChn1.SelectedValue.ToString().Trim());
        //    htable.Add("@Addl1ChnSubCls", ddlAdlSChn1.SelectedValue.ToString().Trim());
        //    htable.Add("@Addl1MgrType", ddlAdlAgtTyp1.SelectedValue.ToString().Trim());
        //    htable.Add("@Addl1MgrCode", hdnAddlRptMgr1.Value.ToString().Trim());
        //}
        //else
        //    if (gv_RptMngr_new.Rows.Count.ToString() == "2")
        //    {
        //        DropDownList ddlAdlRptTyp2 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlRptTyp") as DropDownList;
        //        DropDownList ddlAdlChn2 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlChn") as DropDownList;
        //        DropDownList ddlAdlSChn2 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlSChn") as DropDownList;
        //        DropDownList ddlAdlAgtTyp2 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlAgtTyp") as DropDownList;
        //        HiddenField hdnAddlRptMgr2 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;

        //        DropDownList ddlAdlRptTyp3 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlRptTyp") as DropDownList;
        //        DropDownList ddlAdlChn3 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlChn") as DropDownList;
        //        DropDownList ddlAdlSChn3 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlSChn") as DropDownList;
        //        DropDownList ddlAdlAgtTyp3 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlAgtTyp") as DropDownList;
        //        HiddenField hdnAddlRptMgr3 = gv_RptMngr_new.Rows[1].FindControl("hdnAddlRptMgr") as HiddenField;

        //        htable.Add("@AddlReportingType1", ddlAdlRptTyp2.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl1BizSrc", ddlAdlChn2.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl1ChnSubCls", ddlAdlSChn2.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl1MgrType", ddlAdlAgtTyp2.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl1MgrCode", hdnAddlRptMgr2.Value.ToString().Trim());

        //        htable.Add("@AddlReportingType2", ddlAdlRptTyp3.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl2BizSrc", ddlAdlChn3.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl2ChnSubCls", ddlAdlSChn3.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl2MgrType", ddlAdlAgtTyp3.SelectedValue.ToString().Trim());
        //        htable.Add("@Addl2MgrCode", hdnAddlRptMgr3.Value.Trim());
        //    }
        //    else
        //        if (gv_RptMngr_new.Rows.Count.ToString() == "3")
        //        {
        //            DropDownList ddlAdlRptTyp4 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlRptTyp") as DropDownList;
        //            DropDownList ddlAdlChn4 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlChn") as DropDownList;
        //            DropDownList ddlAdlSChn4 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlSChn") as DropDownList;
        //            DropDownList ddlAdlAgtTyp4 = gv_RptMngr_new.Rows[0].FindControl("ddlAdlAgtTyp") as DropDownList;
        //            HiddenField hdnAddlRptMgr4 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;

        //            DropDownList ddlAdlRptTyp5 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlRptTyp") as DropDownList;
        //            DropDownList ddlAdlChn5 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlChn") as DropDownList;
        //            DropDownList ddlAdlSChn5 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlSChn") as DropDownList;
        //            DropDownList ddlAdlAgtTyp5 = gv_RptMngr_new.Rows[1].FindControl("ddlAdlAgtTyp") as DropDownList;
        //            HiddenField hdnAddlRptMgr5 = gv_RptMngr_new.Rows[1].FindControl("hdnAddlRptMgr") as HiddenField;

        //            DropDownList ddlAdlRptTyp6 = gv_RptMngr_new.Rows[2].FindControl("ddlAdlRptTyp") as DropDownList;
        //            DropDownList ddlAdlChn6 = gv_RptMngr_new.Rows[2].FindControl("ddlAdlChn") as DropDownList;
        //            DropDownList ddlAdlSChn6 = gv_RptMngr_new.Rows[2].FindControl("ddlAdlSChn") as DropDownList;
        //            DropDownList ddlAdlAgtTyp6 = gv_RptMngr_new.Rows[2].FindControl("ddlAdlAgtTyp") as DropDownList;
        //            HiddenField hdnAddlRptMgr6 = gv_RptMngr_new.Rows[2].FindControl("hdnAddlRptMgr") as HiddenField;

        //            htable.Add("@AddlReportingType1", ddlAdlRptTyp4.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl1BizSrc", ddlAdlChn4.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl1ChnSubCls", ddlAdlSChn4.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl1MgrType", ddlAdlAgtTyp4.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl1MgrCode", hdnAddlRptMgr4.Value.ToString().Trim());

        //            htable.Add("@AddlReportingType2", ddlAdlRptTyp5.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl2BizSrc", ddlAdlChn5.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl2ChnSubCls", ddlAdlSChn5.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl2MgrType", ddlAdlAgtTyp5.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl2MgrCode", hdnAddlRptMgr5.Value.Trim());

        //            htable.Add("@AddlReportingType3", ddlAdlRptTyp6.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl3BizSrc", ddlAdlChn6.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl3ChnSubCls", ddlAdlSChn6.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl3MgrType", ddlAdlAgtTyp6.SelectedValue.ToString().Trim());
        //            htable.Add("@Addl3MgrCode", hdnAddlRptMgr6.Value.Trim());
        //        }
        #endregion

        arrResult = objCls.TransferAgentDetails(htable, "Prc_MemberTranfer");
        if (arrResult.Count > 0)
        {
            if (arrResult[0].ToString() != "F")
            {
                if (arrResult.Count > 0)
                {
                    if (arrResult[1].ToString().Equals("0"))
                    {
                        #region Transfer Main table entry for Old Details

                        InsTrfDtlsOld(0);

                        //for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
                        //{
                        //    Label lblNo = gv_RptMngr_Crnt.Rows[i].FindControl("lblNo") as Label;
                        //    InsTrfDtlsOld(Convert.ToInt32(lblNo.Text.Trim()));
                        //}
                        #endregion

                        #region Transfer Main table entry for New Details
                        string flagp = "P";

                        for (int i = 0; gv.Rows.Count > i; i++)
                        {
                            Label MemCode = (Label)gv.Rows[i].FindControl("lblMemCode");
                            hdnNRptMgr.Value = MemCode.Text;
                            lblNwRptMgr.Text = MemCode.Text;
                            InsTrfDtls(0, ddlamrptdesc.SelectedValue, ddlamchnldesc.SelectedValue, ddlamsubchnldesc.SelectedValue, ddllvlagttype.SelectedValue, hdnNRptMgr.Value, flagp);

                        }
                       
                        for (int i = 0; gv_RptMngr_new.Rows.Count > i; i++)
                        {
                            flagp = string.Empty;
                            Label lblNo = gv_RptMngr_new.Rows[i].FindControl("lblNo") as Label;
                            DropDownList ddlAdlRptTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                            DropDownList ddlAdlChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                            DropDownList ddlAdlSChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                            DropDownList ddlAdlAgtTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
                            HiddenField hdnAddlRptMgr = gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;

                            InsTrfDtls(Convert.ToInt32(lblNo.Text.Trim()), ddlAdlRptTyp.SelectedValue, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlAdlAgtTyp.SelectedValue, hdnAddlRptMgr.Value, flagp);
                        }




                        #endregion
                        htParam.Clear();
                        dsResult.Clear();
                        htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
                        htParam.Add("@TrfType", ddlTransferType.SelectedValue.Trim());
                        dsResult = objDAC.GetDataSetForPrc("Prc_UpdMemCOde", htParam);

                        //if (Request.QueryString["MvmtRule"] != null)
                        //{
                        //    if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                        //    {
                        //        htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
                        //        htParam.Add("@UserID", Session["UserID"].ToString().Trim());
                        //        htParam.Add("@AgentType", Request.QueryString["MvmtRule"].ToString().Trim());
                        //        htParam.Add("@MvmtTyp", "TRF");
                        //        htParam.Add("@Flag", "2");
                        //        dsResult = objDAC.GetDataSetForPrc("PrcMemberTypDtls", htParam);
                        //        if (dsResult.Tables.Count > 0)
                        //        {
                        //            if (dsResult.Tables.Count > 0)
                        //            {
                        //                lblMessage.Text = "Transfer request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                        //                lbl3.Text = "Transfer request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                        //            }
                        //        }
                        //    }
                        //}
                        //lbl4.Text = lvlVw1AgntCode.Text + " : " + lblAgtCodeVal.Text;
                        //lbl5.Text = lblAgntName.Text + " : " + lblAgntNameVal.Text;
                        lbl3.Text = "Transfer request approved successfully" + "</br> Agent Code:" + lblAgtCodeVal.Text + "</br> Agent Name :" + lblAgntNameVal.Text;
                        mdlpopup.Show();
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        switch (arrResult[1].ToString())
                        {
                            case "-1": lblMessage.Text = "Downlines should be moved before transfer of Member.";
                                break;
                            case "-2": lblMessage.Text = "This Member Type cannot be Transfered.";
                                break;
                            case "-3": lblMessage.Text = "Group Transfer not allowed for this Member Type.";
                                break;
                            default: lblMessage.Text = "System Error";
                                break;
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblMessage.Text + "');</script>", false);
                    }
                }
            }
            else
            {
                lblMessage.Text = arrResult[1].ToString();
                btnUpdate.Enabled = false;
            }
        }
        else
        {
            lblMessage.Text = "Error Updating Agent Transfer Details.";
            btnUpdate.Enabled = false;
        }

        lblMessage.Visible = true;
        lblMessage.ForeColor = System.Drawing.Color.Red;

    #endregion

    }

    #region Transfer Method
    /// <summary>
    /// method to perform transfer based on transfer types
    /// </summary>
    protected void Transfer()
    {
        try
        {
            if (ddlTransferType.SelectedValue == "I" || ddlTransferType.SelectedValue=="C")
            {
                /////InsRptMngrTransfer();
                TranferReq();
            }
            else if (ddlTransferType.SelectedValue == "G")
            {
                TranferReq();
            }
            else if (ddlTransferType.SelectedValue == "D")
            {
                //TranferReq();
                DwnlnTransfer();
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

    #region DwnlnTransfer
    /// <summary>
    /// method to send transfer request for Downlines transfer type
    /// </summary>
    public void DwnlnTransfer()
    {
        string MvmtCode = GetMvmtCode().ToString().Trim();
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        List<string> lstMemcode = new List<string>();
        ArrayList userdetails = new ArrayList();
        ////DataSet ds = ViewState["dsGrid"] as DataSet;
        userdetails = (ArrayList)Session["CHKITEMS"];
        //commenetd by mrunal on 17.02.18
        //Session["CHKITEMS"] = null;
        //Session["CHECKED_ITEMS"] = null;
        //end

        #region dwnls
       
        for (int intDataCount = 0; intDataCount <= userdetails.Count - 1; intDataCount++)
        {
            htparam.Clear();
            htparam.Add("@AgentCode", userdetails[intDataCount]);
            htparam.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));
            htparam.Add("@AgtCode", lblAgtCodeVal.Text.Trim());
            htparam.Add("@TrfType", ddlTransferType.SelectedValue);
            htparam.Add("@TrfReason", ddlTransferReason.SelectedValue.Trim());
            htparam.Add("@Remark", txtRemark.Text);
            ///htparam.Add("@UnitCode", hdnUnitCode.Value);
            htparam.Add("@MvmtCode", MvmtCode.ToString().Trim());
            if (hdnUnitCode.Value == lblNwUntcd.Text)
            {
                htparam.Add("@NewUntCode", lblNwUntcd.Text);
            }
            else
            {
                htparam.Add("@NewUntCode", hdnNwUntcd.Value);
            }

            htparam.Add("@PrimaryMgrCode", hdnNRptMgr.Value.Trim());

            #region Addition Manager PArt
            if (gv_RptMngr_new.Rows.Count.ToString() == "1")
            {
                HiddenField hdnAddlRptMgr1 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;
                htparam.Add("@Addl1MgrCode", hdnAddlRptMgr1.Value.ToString().Trim());
            }
            else
                if (gv_RptMngr_new.Rows.Count.ToString() == "2")
                {
                    HiddenField hdnAddlRptMgr2 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;
                    HiddenField hdnAddlRptMgr3 = gv_RptMngr_new.Rows[1].FindControl("hdnAddlRptMgr") as HiddenField;
                    htparam.Add("@Addl1MgrCode", hdnAddlRptMgr2.Value.ToString().Trim());
                    htparam.Add("@Addl2MgrCode", hdnAddlRptMgr3.Value.Trim());
                }
                else
                    if (gv_RptMngr_new.Rows.Count.ToString() == "3")
                    {
                        HiddenField hdnAddlRptMgr4 = gv_RptMngr_new.Rows[0].FindControl("hdnAddlRptMgr") as HiddenField;
                        HiddenField hdnAddlRptMgr5 = gv_RptMngr_new.Rows[1].FindControl("hdnAddlRptMgr") as HiddenField;
                        HiddenField hdnAddlRptMgr6 = gv_RptMngr_new.Rows[2].FindControl("hdnAddlRptMgr") as HiddenField;
                        htparam.Add("@Addl1MgrCode", hdnAddlRptMgr4.Value.ToString().Trim());
                        htparam.Add("@Addl2MgrCode", hdnAddlRptMgr5.Value.Trim());
                        htparam.Add("@Addl3MgrCode", hdnAddlRptMgr6.Value.Trim());
                    }
            #endregion 
            
            dsResult = objDAC.GetDataSetForPrcCLP("Prc_Trf_Downlines", htparam);

            //lblMessage.Text = "Transfer request has been sent for approval successfully.";
            /////lbl3.Text = "Transfer request send for approval successfully" + "</br></br> Agent Code:" + lblAgtCodeVal.Text + "</br></br> Agent Name :" + lblAgntNameVal.Text;

            //lbl3.Text = "Transfer request send for approval successfully";
            //lbl4.Text = "Agent Code : " + lblAgtCodeVal.Text;
            //lbl5.Text = "Agent Name : " + lblAgntNameVal.Text;
            //mdlpopup.Show();
            //btnUpdate.Enabled = false;
            #region Transfer Main table entry for Old Details

            InsTrfDtlsOld(0);

            #endregion

            #region Transfer Main table entry for New Details
            string flagp = "P";
            InsTrfDtls(0, ddlamrptdesc.SelectedValue, ddlamchnldesc.SelectedValue, ddlamsubchnldesc.SelectedValue, ddllvlagttype.SelectedValue, hdnNRptMgr.Value, flagp);

            for (int i = 0; gv_RptMngr_new.Rows.Count > i; i++)
            {
                flagp = string.Empty;
                Label lblNo = gv_RptMngr_new.Rows[i].FindControl("lblNo") as Label;
                DropDownList ddlAdlRptTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                DropDownList ddlAdlChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                DropDownList ddlAdlSChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                DropDownList ddlAdlAgtTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
                HiddenField hdnAddlRptMgr = gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;

                InsTrfDtls(Convert.ToInt32(lblNo.Text.Trim()), ddlAdlRptTyp.SelectedValue, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlAdlAgtTyp.SelectedValue, hdnAddlRptMgr.Value, flagp);
            }




            #endregion

            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@MemCode", userdetails[intDataCount]);
            htParam.Add("@TrfType", ddlTransferType.SelectedValue.Trim());
            dsResult = objDAC.GetDataSetForPrc("Prc_UpdMemCOde", htParam);

            lbl3.Text = "Transfer request approved successfully" + "</br> Agent Code:" + userdetails[intDataCount] + "</br> Agent Name :" + lblAgntNameVal.Text;
            mdlpopup.Show();
            btnUpdate.Enabled = false;
        }
        #endregion
    }
    #endregion 

    #region GetMvmtCode Method
    /// <summary>
    /// method to get the momvement code for downline transfer
    /// </summary>
    /// <returns></returns>
    protected string GetMvmtCode()
    {
        Hashtable htMCode = new Hashtable();
        DataSet dsMCode = new DataSet();
        htMCode.Clear();
        htMCode.Add("@counterId", "TrfRefNo");
        dsMCode = objDAC.GetDataSetForPrcDBConn("Prc_GetMaxMvmtCode", htMCode, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

        string MvmtCd = dsMCode.Tables[0].Rows[0]["CounterNo"].ToString().Trim();

        return MvmtCd;

    }
    #endregion

    #region btnApprove_Click
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        TransferAppRej("A");
    }
    #endregion

    #region btnReject_Click
    protected void btnReject_Click(object sender, EventArgs e)
    {
        TransferAppRej("R");
    }
    #endregion 

    #region GetTrfDetails Method
    //method to fetch the details of transfered members
    protected void GetTrfDetails()
    {
        Hashtable htTrf = new Hashtable();
        DataSet dsTrf = new DataSet();
        ViewState["vwsAgntCode"] = lblAgtCodeVal.Text.Trim();

        try
        {
            htTrf.Clear();

            htTrf.Add("@AgentCode", ViewState["vwsAgntCode"]);
            dsTrf = objDAC.GetDataSetForPrcDBConn("Prc_GetNewDtlsForTrf", htTrf, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

            if (dsTrf.Tables.Count > 0)
            {
                if (dsTrf.Tables[0].Rows.Count > 0)
                {
                    ddlTransferReason.SelectedValue = dsTrf.Tables[0].Rows[0]["TrfReason"].ToString().Trim();
                    if (dsTrf.Tables[0].Rows[0]["TrfType"].ToString().Trim() == "D")
                    {
                        oCommon.getDropDown(ddlTransferType, "trfType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                    }
                    ddlTransferType.SelectedValue = dsTrf.Tables[0].Rows[0]["TrfType"].ToString().Trim();
                    lblEffectiveDate.Text = dsTrf.Tables[0].Rows[0]["EffDate"].ToString().Trim();
                    txtRemark.Text = dsTrf.Tables[0].Rows[0]["Remarks"].ToString().Trim();
                    txtNewUntCode.Text = dsTrf.Tables[0].Rows[0]["UnitDesc"].ToString().Trim();
                    lblNwUntcd.Text = dsTrf.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    lblUntAddr.Text = dsTrf.Tables[0].Rows[0]["UnitAdr"].ToString().Trim();
                }
                else
                {
                    dsTrf = null;
                    dsTrf.Clear();
                }
            }
            else
            {
                dsTrf = null;
                dsTrf.Clear();
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

    #region DisableCtrls Method
    protected void DisableCtrls()
    {
        rblChnlType.Enabled = false;
        ddlSlsChannel.Enabled = false;
        ddlChnCls.Enabled = false;
        ddlAgntType.Enabled = false;

        ddlamrptdesc.Enabled = false;
        ddlamchnldesc.Enabled = false;
        ddlamsubchnldesc.Enabled = false;
        //ddllvlagttype.Enabled = false;

        //ddlam1rptdesc.Enabled = false;
        //ddlam1chnldesc.Enabled = false;
        //ddlam1subchnldesc.Enabled = false;
        //ddlam1basedondesc.Enabled = false;
        //ddllvlagttype1.Enabled = false;

        //ddlam2rptdesc.Enabled = false;
        //ddlam3chnldesc.Enabled = false;
        //ddlam2subchnldesc.Enabled = false;
        //ddlam2basedondesc.Enabled = false;
        //ddllvlagttype2.Enabled = false;

        //ddlam3rptdesc.Enabled = false;
        //ddlam3chnldesc.Enabled = false;
        //ddlam3subchnldesc.Enabled = false;
        //ddlam3basedondesc.Enabled = false;
        //ddllvlagttype3.Enabled = false;

        txtNewUntCode.Enabled = false;
        txtRptMgr.Enabled = false;
        //txtRptMgr1.Enabled = false;
        //txtRptMgr2.Enabled = false;
        //txtRptMgr3.Enabled = false;

        btnRptMgr.Enabled = false;
        //btnRptMgr1.Enabled = false;
        //btnRptMgr2.Enabled = false;
        //btnRptMgr3.Enabled = false;

        btnUnitCode.Enabled = false;
        chkUnt.Enabled = false;
    }
    #endregion 

    #region TransferAppRej Method
    ////method to approve/reject Transfer request
    protected void TransferAppRej(string flag)
    {
        Hashtable htParam = new Hashtable();
        dsResult = new DataSet();
        ArrayList arrResult = new ArrayList();
        ViewState["vwsAgntCode"] = lblAgtCodeVal.Text.Trim();
        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"].ToString() == "Trf")
            {
                //if (Request.QueryString["flag"] != null)
                //{
                //    if (Request.QueryString["flag"].ToString() == "A")
                //    {

                        htParam.Clear();
                        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString().Trim());
                        htParam.Add("@Bizsrc", ddlSlsChannel.SelectedValue.Trim());
                        htParam.Add("@ChnCls", ddlChnCls.SelectedValue.Trim());
                        htParam.Add("@Agenttype", ddlAgntType.SelectedValue.Trim());
                        htParam.Add("@NewUntCode", lblNwUntcd.Text.Trim());
                        htParam.Add("@TrfStat", flag.ToString().Trim());
                        htParam.Add("@CreateBy", Session["UserID"].ToString());
                        htParam.Add("@TrfReason", ddlTransferReason.SelectedValue.Trim());
                        htParam.Add("@PrimaryMgrCode", lblNwRptMgr.Text);
                        htParam.Add("@PrimaryMgrType", ddllvlagttype.SelectedValue.Trim());
                        if (Request.QueryString["MvmtRule"] != null)
                        {
                            if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                            {
                                htParam.Add("@MvmtLvl", Request.QueryString["MvmtRule"].ToString().Trim());
                            }
                        }

                        try
                        {
                            dsResult = objDAC.GetDataSetForPrcCLP("PrcTransferAppRej", htParam);
                            if (flag == "A")
                            {
                                if (Request.QueryString["MvmtRule"] != null)
                                {
                                    if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                                    {
                                        htParam.Clear();
                                        htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
                                        htParam.Add("@UserID", Session["UserID"].ToString().Trim());
                                        htParam.Add("@MvmtTyp", "TRF");
                                        htParam.Add("@AgentType", Request.QueryString["MvmtRule"].ToString().Trim());
                                        htParam.Add("@Flag", "2");
                                        dsResult = objDAC.GetDataSetForPrc("PrcMemberTypDtls", htParam);
                                        if (dsResult.Tables.Count > 0)
                                        {
                                            if (dsResult.Tables.Count > 0)
                                            {
                                                lblMessage.Text = "Transfer request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                                                lbl3.Text = "Transfer request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                                            }
                                        }
                                    }
                                }
                                lbl4.Text = lvlVw1AgntCode.Text + " : " + lblAgtCodeVal.Text;
                                lbl5.Text = lblAgntName.Text + " : " + lblAgntNameVal.Text;

                                //lbl3.Text = "Transfer Request Approved Succesfully";
                                //lbl4.Text = "Agent Code : " + lblAgtCodeVal.Text;
                                //lbl5.Text = "Agent Name : " + lblAgntNameVal.Text;
                                mdlpopup.Show();
                                btnApprove.Enabled = false;
                                btnReject.Enabled = false;
                            }
                            else
                            {
                                if (flag == "R")
                                {
                                    lbl3.Text = "Transfer Request Rejected Succesfully";
                                    lbl4.Text = lvlVw1AgntCode.Text + " : " + lblAgtCodeVal.Text;
                                    lbl5.Text = lblAgntName.Text + " : " + lblAgntNameVal.Text;
                                    mdlpopup.Show();
                                    btnApprove.Enabled = false;
                                    btnReject.Enabled = false;
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

                //    }
                //}
            }
        }
    }
    #endregion

    #region lnkbtnNewCF_Click
    protected void lnkbtnNewCF_Click(object sender, EventArgs e)
    {
        BindGridRelation("CF", gv_NewDownlines, lblDwlnErrmsg);
        //if (MVNewDtls.ActiveViewIndex == 2)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        //}
    }
    #endregion

    #region lnkbtnNewCU_Click
    protected void lnkbtnNewCU_Click(object sender, EventArgs e)
    {
        BindGridRelation("CU", gv_NewDownlines, lblDwlnErrmsg);
        //if (MVNewDtls.ActiveViewIndex == 2)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        //}
    }
    #endregion

    #region chkDwnls_CheckedChanged
    protected void chkDwnls_CheckedChanged(object sender, EventArgs e)
    {
        ArrayList chkItems = new ArrayList();
        int index = -1;
        for (int intRowCount = 0; intRowCount <= gv_Dwnls.Rows.Count - 1; intRowCount++)
        {
            Label Memcode = (Label)gv_Dwnls.Rows[intRowCount].Cells[1].FindControl("lblMemCode");
            Label MemType = (Label)gv_Dwnls.Rows[intRowCount].Cells[6].FindControl("lblMemTyp");
            CheckBox Chk = (CheckBox)gv_Dwnls.Rows[intRowCount].Cells[0].FindControl("chkDwnls");
            index = Convert.ToInt32(Memcode.Text.ToString().Trim());
            if (Session["CHKITEMS"] != null)
                chkItems = (ArrayList)Session["CHKITEMS"];
            if (Chk.Checked == true)
            {
                string agttyp = MemType.Text.ToString().Trim();
                GetRptForDwnls(Memcode.Text.ToString().Trim());
                GetMemTypes(ddlSlsChannel.SelectedValue.ToString().Trim(), ddlChnCls.SelectedValue.ToString().Trim(), ddlAgntType);
                ddlAgntType.SelectedValue = agttyp.ToString().Trim();
                hdnAgntType.Value = ddlAgntType.SelectedValue.ToString().Trim();
                FillMgrDetails(agttyp.ToString().Trim());

                if (!chkItems.Contains(index))
                    chkItems.Add(index);
            }
            else
            {
                chkItems.Remove(index);
                if (chkItems == null || chkItems.Count == 0)
                {
                    strAgentType = ddlAgntType.SelectedValue.ToString().Trim();
                    FillMgrDetails(strAgentType);
                }
            }
            if (chkItems != null && chkItems.Count > 0)
                Session["CHKITEMS"] = chkItems;
        }
    }
    #endregion 

    #region DwnlsAppRej
    protected void DwnlsAppRej(string str)
    {
        Hashtable htParam = new Hashtable();
        dsResult = new DataSet();
        ArrayList arrResult = new ArrayList();

        htParam.Add("@AgentCode",lblAgtCodeVal.Text.Trim());
        htParam.Add("@NewUntCode", lblNwUntcd.Text.Trim());
        htParam.Add("@TrfType", ddlTransferType.SelectedValue);
        htParam.Add("@TrfStat", str.ToString().Trim());
        htParam.Add("@PrimaryMgrCode", hdnRptMgr.Value.Trim());
        htParam.Add("@CreateBy", Session["UserID"].ToString());
        htParam.Add("@TrfReason",ddlTransferReason.SelectedValue.ToString().Trim());
        try
        {
            dsResult = objDAC.GetDataSetForPrcDBConn("Prc_DwnlsAppRej", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (str == "A")
            {
                lbl3.Text = "Transfer Request Approved Succesfully";
                lbl4.Text = "Member Code : " + lblAgtCodeVal.Text;
                lbl5.Text = "Member Name : " + lblAgntNameVal.Text;
                mdlpopup.Show();
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            else
            {
                if (str == "R")
                {
                    lbl3.Text = "Transfer Request Rejected Succesfully";
                    lbl4.Text = "Member Code : " + lblAgtCodeVal.Text;
                    lbl5.Text = "Member Name : " + lblAgntNameVal.Text;
                    mdlpopup.Show();
                    btnApprove.Enabled = false;
                    btnReject.Enabled = false;
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

    #region lnkbtnDwnCF_Click
    protected void lnkbtnDwnCF_Click(object sender, EventArgs e)
    {
        BindGridDownlines("CF", gv_Dwnls, lbldwnlsmsg);
    }
    #endregion

    #region lnkbtnDwnCU_Click
    protected void lnkbtnDwnCU_Click(object sender, EventArgs e)
    {
        BindGridDownlines("CU", gv_Dwnls, lbldwnlsmsg);
    }
    #endregion

    #region ShowPageInformationgv_Dwnls
    private void ShowPageInformationgv_Dwnls()
    {
        int intPageIndex = gv_Dwnls.PageIndex + 1;
        string pageind = "Page " + intPageIndex.ToString() + " of " + gv_Dwnls.PageCount;
    }
    #endregion

    #region ShowPageInformationgv_NewDownlines
    private void ShowPageInformationgv_NewDownlines()
    {
        int intPageIndex = gv_NewDownlines.PageIndex + 1;
        string pageind = "Page " + intPageIndex.ToString() + " of " + gv_NewDownlines.PageCount;
    }
    #endregion

    #region gv_Dwnls_PageIndexChanging1
    protected void gv_Dwnls_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            SaveCheckedValues();
            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_Dwnls.PageIndex = e.NewPageIndex;
            dv.Sort = gv_Dwnls.Attributes["SortExpression"];

            if (gv_Dwnls.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_Dwnls.DataSource = dv;
            gv_Dwnls.DataBind();
            ShowPageInformationgv_Dwnls();
            PopulateCheckedValues();
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

    #region gv_NewDownlines_PageIndexChanging
    protected void gv_NewDownlines_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_NewDownlines.PageIndex = e.NewPageIndex;
            dv.Sort = gv_NewDownlines.Attributes["SortExpression"];

            if (gv_NewDownlines.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_NewDownlines.DataSource = dv;
            gv_NewDownlines.DataBind();
            ShowPageInformationgv_NewDownlines();
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

    #region gv_Dwnls_Sorting
    protected void gv_Dwnls_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
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

    #region gv_NewDownlines_Sorting
    protected void gv_NewDownlines_Sorting(object sender, GridViewSortEventArgs e)
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

            DataSet ds = ViewState["dsGrid"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
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

    #region btnRptMgr_Click1
    protected void btnRptMgr_Click1(object sender, EventArgs e)
    {
        GetManagers();
    }
    #endregion

    #region GetRptForDwnls
    protected void GetRptForDwnls(string stragtcode)
    {
        DataSet tempds = new DataSet();
        htParam.Clear();

        try
        {
            htParam.Clear();
            htParam.Add("@AgentCode", stragtcode.ToString().Trim());
            htParam.Add("@Flag", 4);
            tempds = objDAC.GetDataSetForPrc("prc_GetAgnCodeandAgnName", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["MemType"]);
                /////hdnAgentType.Value = strAgentType.ToString().Trim();
                ViewState["code"] = null;
                ViewState["code"] = strAgentType.ToString().Trim();
                Page.ClientScript.RegisterHiddenField("vCode", ViewState["code"].ToString().Trim());
                ////hdnAgntType.Text = strAgentType.ToString().Trim();
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

    #region btnUnitCode_Click
    protected void btnUnitCode_Click(object sender, EventArgs e)
    {       
        if (ViewState["code"] != null)
        {
            hdnunitchn.Value = ddlSlsChannel.SelectedValue.ToString().Trim();
            hdnunitsubchn.Value = ddlChnCls.SelectedValue.ToString().Trim();
            if (chkMemRole() == "E")
            {
               
               //  ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>fununtpopup('rptmgr','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + ddllvlagttype.SelectedValue + "','Emp','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "');</script>", false);

                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>fununtpopup('untcode','" + hdnunitchn.Value.Trim() + "','" + hdnunitsubchn.Value.Trim() + "','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ViewState["code"] + "','Emp','');</script>", false);
            }
            else if (chkMemRole() == "A")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>fununtpopup('untcode','" + hdnunitchn.Value.Trim() + "','" + hdnunitsubchn.Value.Trim() + "','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ViewState["code"] + "','Agent','');</script>", false);
            }
        }
        //txtRptMgr1.Text = "";
        //txtRptMgr2.Text = "";
        //txtRptMgr3.Text = "";

        //lblrptmgr1.Text = "";
        //lblrptmgr2.Text = "";
        //lblrptmgr3.Text = "";

        hdnRptMgr1.Value = null;
        hdnRptMgr2.Value = null;
        hdnRptMgr3.Value = null;
    }
    #endregion

    #region SaveCheckedValues
    private void SaveCheckedValues()
    {
        ArrayList userdetails = new ArrayList();
        int index = -1;
        //GridViewRow gridViewRow = (GridViewRow)(((Control)sender).NamingContainer);
        foreach (GridViewRow gvrow in gv_Dwnls.Rows)
        {
            //index = (int)GrdSearch.DataKeys[gvrow.RowIndex].Value;
            Label lblDataKeyNames = (Label)gvrow.FindControl("lblMemCode") as Label;
            index = Convert.ToInt32(lblDataKeyNames.Text.ToString().Trim());
            bool result = ((CheckBox)gvrow.FindControl("chkDwnls")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                userdetails = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!userdetails.Contains(index))
                    userdetails.Add(index);
            }
            else
                userdetails.Remove(index);
        }
        if (userdetails != null && userdetails.Count > 0)
            Session["CHECKED_ITEMS"] = userdetails;
    }
    #endregion

    #region PopulateCheckedValues
    private void PopulateCheckedValues()
    {
        ArrayList userdetails = (ArrayList)Session["CHECKED_ITEMS"];
        if (userdetails != null && userdetails.Count > 0)
        {
            foreach (GridViewRow gvrow in gv_Dwnls.Rows)
            {
                //int index = (int)GrdSearch.DataKeys[gvrow.RowIndex].Value;
                Label lblDataKeyNames = (Label)gvrow.FindControl("lblMemCode") as Label;
                int index = Convert.ToInt32(lblDataKeyNames.Text.ToString().Trim());
                if (userdetails.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkDwnls");
                   // CheckBox myHrdCheckBox = (CheckBox)gvrow.FindControl("chkSelectAll");
                   // myHrdCheckBox.Checked = true;
                    myCheckBox.Checked = true;
                   
                }
            }
        }
    }
    #endregion

    #region chkSelectAll_CheckedChanged
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)gv_Dwnls.HeaderRow.FindControl("chkSelectAll");
        foreach (GridViewRow row in gv_Dwnls.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkDwnls");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
                chkDwnls_CheckedChanged(sender, e);
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }
    #endregion

    #region txtNewUntCode_TextChanged
    protected void txtNewUntCode_TextChanged(object sender, EventArgs e)
    {
        //txtRptMgr1.Text = "";
        //txtRptMgr2.Text = "";
        //txtRptMgr3.Text = "";

        //lblrptmgr1.Text = "";
        //lblrptmgr2.Text = "";
        //lblrptmgr3.Text = "";

        hdnRptMgr1.Value = null;
        hdnRptMgr2.Value = null;
        hdnRptMgr3.Value = null;
    }
    #endregion

    #region chkMemRole
    /// <summary>
    /// method to check member role of member types
    /// </summary>
    /// <returns></returns>
    protected string chkMemRole()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        string role = string.Empty;

        ht.Clear();
        try
        {
            ht.Add("@AgentType", ViewState["code"].ToString().Trim());
            ht.Add("@Flag", "1");
            ds = objDAC.GetDataSetForPrc("PrcMemberTypDtls", ht);
            if (ds.Tables[0].Rows.Count > 0)
            {
                role = ds.Tables[0].Rows[0]["MemberRole"].ToString().Trim();
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
            return null;
        }
        return role;
    }
    #endregion

    #region btnRptMgr1_Click
    protected void btnRptMgr1_Click(object sender, EventArgs e)
    {
        if (chkMemRole() == "E")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr1','" + ddlam1chnldesc.SelectedValue + "','" + ddlam1subchnldesc.SelectedValue + "','" + ddllvlagttype1.SelectedValue + "','Emp','" + ddlam1basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
        else if (chkMemRole() == "A")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr1','" + ddlam1chnldesc.SelectedValue + "','" + ddlam1subchnldesc.SelectedValue + "','" + ddllvlagttype1.SelectedValue + "','Agent','" + ddlam1basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
    }
    #endregion

    #region btnRptMgr2_Click
    protected void btnRptMgr2_Click(object sender, EventArgs e)
    {
        if (chkMemRole() == "E")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr2','" + ddlam2chnldesc.SelectedValue + "','" + ddlam2subchnldesc.SelectedValue + "','" + ddllvlagttype2.SelectedValue + "','Emp','" + ddlam2basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
        else if (chkMemRole() == "A")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr2','" + ddlam2chnldesc.SelectedValue + "','" + ddlam2subchnldesc.SelectedValue + "','" + ddllvlagttype2.SelectedValue + "','Agent','" + ddlam2basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
    }
    #endregion

    #region btnRptMgr3_Click
    protected void btnRptMgr3_Click(object sender, EventArgs e)
    {
        if (chkMemRole() == "E")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr3','" + ddlam3chnldesc.SelectedValue + "','" + ddlam3subchnldesc.SelectedValue + "','" + ddllvlagttype3.SelectedValue + "','Emp','" + ddlam3basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
        else if (chkMemRole() == "A")
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>funcMgrShowPopup('rptmgr3','" + ddlam3chnldesc.SelectedValue + "','" + ddlam3subchnldesc.SelectedValue + "','" + ddllvlagttype3.SelectedValue + "','Agent','" + ddlam3basedondesc.SelectedValue.ToString().Trim() + "');</script>", false);
        }
    }
    #endregion

    protected void gv_Dwnls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox ChkBoxHeader = (CheckBox)gv_Dwnls.HeaderRow.FindControl("chkSelectAll");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkDwnls") as CheckBox;
            ////ChkBoxHeader.Attributes.Add("onclick", "funCheckUnCheck(id)");
            ////chkSelect.Attributes.Add("onclick", "funCheckUnCheck(id)");
            if (ChkBoxHeader.Checked == true)
            {
                chkSelect.Checked = true;
                chkDwnls_CheckedChanged(sender, e);
                ///PopulateCheckedValues();
            }
            else
            {
                chkSelect.Checked = false;
            }

        }
    }

    #region fillAddlRptMngrDtls
    public void fillAddlRptMngrDtls()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
            htParam.Add("@ChnCls", hdnChncls.Value.Trim());
            htParam.Add("@AgentType", hdnagttyp.Value.Trim());
           // htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls", htParam);  //Prc_GetCrntAddlMngrgrdDtls_PrmDmt

            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                gv_RptMngr_Crnt.DataSource = dsRpt.Tables[0];
                gv_RptMngr_Crnt.DataBind();
                bindCrntAddlMngrGridData(dsRpt);
                for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
                {

                    GridView gvoldAddlMgr = gv_RptMngr_Crnt.Rows[i].FindControl("gvoldAddlMgr") as GridView;
                    DataSet ds = new DataSet();
                    htParam.Clear();
                    ds.Clear();
                    htParam.Add("@MemCode", dsResult.Tables[0].Rows[0]["MemCode"]);
                    htParam.Add("@RelOrder", i + 1);
                    ds = objDAC.GetDataSetForPrcCLP("Prc_GetAddlRptMemCodes", htParam);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        gvoldAddlMgr.DataSource = ds.Tables[0];
                        gvoldAddlMgr.DataBind();
                        Session["addlmem"] = ds;
                    }
                }
            }
            else
            {
                gv_RptMngr_Crnt.DataSource = null;
                gv_RptMngr_Crnt.DataBind();
                lblRptMngrErr.Visible = true;
                lblRptMngrErr.Text = "No Records Exists";
                lbladditionalreportingrule.Visible = false;
                lbladditionalreportingrule.Text = "";
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

    private void bindCrntAddlMngrGridData(DataSet dsRpt)
    {
        try
        {
            //gv_RptMngr_Crnt_Crnt.HeaderRow.Visible = false;
            //for (int i = 0; gv_RptMngr_Crnt_Crnt.Rows.Count > i; i++)
            //{

            //    Label lblCrntAdlRptTyp = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrntAdlRptTyp");
            //    lblCrntAdlRptTyp.Text = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

            //    Label lblCrtAdlBsdOn = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrtAdlBsdOn");
            //    lblCrtAdlBsdOn.Text = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

            //    Label lblCrntAdlChn = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrntAdlChn");
            //    lblCrntAdlChn.Text = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

            //    Label lblCrntAdlSChn = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrntAdlSChn");
            //    lblCrntAdlSChn.Text = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

            //    Label lblCrntAdlAgtTyp = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrntAdlAgtTyp");
            //    lblCrntAdlAgtTyp.Text = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString();

            //    Label lblCrntRptMngr = (Label)gv_RptMngr_Crnt_Crnt.Rows[i].FindControl("lblCrntRptMngr");
            //    lblCrntRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();

            //    if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
            //    {
            //        lblRptMngrErr.Visible = false;
            //        lblRptMngrErr.Text = "";
            //        lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
            //        lbladditionalreportingrule.Visible = true;
            //    }
            //    else
            //    {
            //        lblRptMngrErr.Visible = true;
            //        lblRptMngrErr.Text = "No Records Exists";
            //        lbladditionalreportingrule.Visible = false;
            //        lbladditionalreportingrule.Text = "";
            //    }

            //}



            gv_RptMngr_Crnt.HeaderRow.Visible = false;
            for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
            {
                DropDownList ddlAdlRptTyp = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAdlRptTyp");
                ddlAdlRptTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

                DropDownList ddlAdlBsdOn = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAdlBsdOn");
                ddlAdlBsdOn.SelectedValue = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

                DropDownList ddlAdlChn = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAdlChn");
                ddlAdlChn.SelectedValue = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

                DropDownList ddlAdlSChn = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAdlSChn");
                ddlAdlSChn.SelectedValue = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

                HiddenField hdnAdMemType = (HiddenField)gv_RptMngr_Crnt.Rows[i].FindControl("hdnAdMemType");

                HiddenField hdnAddlStp = (HiddenField)gv_RptMngr_Crnt.Rows[i].FindControl("hdnAddlStp");
                hdnAddlStp.Value = dsRpt.Tables[0].Rows[i]["AddlStp"].ToString();
                DropDownList ddlRelModel = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlRelModel");

                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAdlAgtTyp");
                ddlAdlAgtTyp.Enabled = true;
                if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
                {
                    lblRptMngrErr.Visible = false;
                    lblRptMngrErr.Text = "";
                    lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
                    funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
                    lbladditionalreportingrule.Visible = true;
                }
                else
                {
                    lblRptMngrErr.Visible = true;
                    lblRptMngrErr.Text = "No Records Exists";
                    lbladditionalreportingrule.Text = "";
                }

                if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "1")
                {
                    ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                    ddlAdlAgtTyp.Enabled = false;
                }
                else if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "0")
                {
                    //ddlAdlAgtTyp.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim(), 
                    //ddlAdlChn.SelectedValue.ToString().Trim(), ddlAdlSChn.SelectedValue.ToString().Trim());

                    hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                }
                else
                {
                    hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();///////for inclusive only
                }
                if (ddlAdlAgtTyp.SelectedValue != null)
                {
                    if (ddlAdlAgtTyp.SelectedValue != "RF")
                    {
                        HtmlTableRow trVenType = (HtmlTableRow)gv_RptMngr_Crnt.Rows[i].FindControl("trVenType");
                        //trVenType.Visible = false;
                    }
                }


                TextBox txtRptMngr = (TextBox)gv_RptMngr_Crnt.Rows[i].FindControl("txtRptMngr");
                Label lblmndtry = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblmndtry");
                HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr_Crnt.Rows[i].FindControl("hdnRptMgrMandatory");
                hdnRptMgrMandatory.Value = dsRpt.Tables[0].Rows[i]["IsMandatory"].ToString();
                LinkButton lnkViewMDtls = (LinkButton)gv_RptMngr_Crnt.Rows[i].FindControl("lnkViewMDtls");
                Button btnRptAdMgr = (Button)gv_RptMngr_Crnt.Rows[i].FindControl("lnkRptMngr");

                if (hdnRptMgrMandatory.Value == "True")
                {
                    txtRptMngr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                    lblmndtry.Visible = true;
                }
                /////setAgtType(hdnAddlStp.Value.Trim(), ddlAdlAgtTyp);
                ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                //ddlAdlAgtTyp.SelectedItem.Text = "Sales Manager"; //commented by mrunal
                if (Request.QueryString["Type"].ToString().Trim() == "E")//changed by mrunal
                {

                    //commented by mrunal on 17.02.18
                    //if (dsRpt.Tables[0].Rows[i]["ReportingType"].ToString().Trim() != null)
                    //{
                    //    if (dsRpt.Tables[0].Rows[i]["MemTypDsc"].ToString().Trim() == "RF")
                    //    {
                    //        lnkViewMDtls.Visible = true;
                    //        lnkViewMDtls.Attributes.Add("onclick", "funcShowPopup('VendorIRC','');return false;");
                    //        pnlMdl.Width = 800;
                    //        ifrmMdlPopup.Attributes.Add("width", "100%");
                    //    }
                    //}
                    DropDownList ddlAddlventype = (DropDownList)gv_RptMngr_Crnt.Rows[i].FindControl("ddlAddlventype");
                    ddlAddlventype.SelectedValue = "EVS";// dsRpt.Tables[0].Rows[i]["VenType"].ToString();
                    Session["AdlVentyp"] = ddlAddlventype.SelectedValue;
                    ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                    //end


                    //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString();
                    //Label lblRptMngr = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblRptMngr");
                    //lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
                    //Session["vencode"] = lblRptMngr.Text.Trim();
                    //Session["venname"] = txtRptMngr.Text.Trim();
                    //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString() + "(" + dsRpt.Tables[0].Rows[i]["RptSapCode"].ToString() + ")";

                    ddlRelModel.SelectedValue = "FRN";//dsRpt.Tables[0].Rows[i]["RelModel"].ToString();

                    ddlAddlventype.Enabled = false;///080714
                    ddlRelModel.Enabled = false;
                    ddlAdlAgtTyp.Enabled = false;
                    txtRptMngr.Enabled = false;
                    btnRptAdMgr.Enabled = false;
                    ddlAdlBsdOn.Enabled = false;
                    ddlAdlSChn.Enabled = false;
                    ddlAdlRptTyp.Enabled = false;
                    ddlAdlChn.Enabled = false;
                    ddlAdlAgtTyp.Enabled = false;
                    lbladditionalreportingrule.Enabled = false;
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

    #region ddlAddlventype_SelectedIndexChanged
    protected void ddlAddlventype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
            DropDownList ddlAddlventype = (DropDownList)grd.FindControl("ddlAddlventype");
            DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
            DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
            DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
            DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
            DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
            TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
            HtmlButton lnkRptMngr = (HtmlButton)grd.FindControl("lnkRptMngr");

            if (ddlAddlventype.SelectedValue == "DV")
            {
                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                ddlAdlAgtTyp.Enabled = false;
                txtRptMngr.Enabled = false;

                //lnkRptMngr.Enabled = true;
                lnkRptMngr.Attributes.Add("disabled", "disabled");
            }
            else if (ddlAddlventype.SelectedValue == "EVS")
            {
                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                ddlAdlAgtTyp.Enabled = false;
                txtRptMngr.Enabled = true;
                //lnkRptMngr.Enabled = true;
                lnkRptMngr.Attributes.Remove("disabled");

                ////080714
                ddlAdlChn.SelectedValue = ddlSlsChannel.SelectedValue;
                Hashtable htParam = new Hashtable();
                DataSet dsVend = new DataSet();
                htParam.Clear();
                dsVend.Clear();
                htParam.Add("@CarrierCode", "2");
                htParam.Add("@BizSrc", ddlAdlChn.SelectedValue.ToString().Trim());
                htParam.Add("@MemType", ddlAdlAgtTyp.SelectedValue.ToString().Trim());
                dsVend = objDAC.GetDataSetForPrcCLP("Prc_GetVendorClass", htParam);
                if (dsVend != null)
                {
                    if (dsVend.Tables[0].Rows.Count > 0)
                    {
                        ddlAdlSChn.SelectedValue = dsVend.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                    }
                }

            }
            else if (ddlAddlventype.SelectedValue == "EVD")
            {
                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = true;
                ddlAdlChn.Enabled = true;
                ddlAdlSChn.Enabled = true;
                ddlAdlAgtTyp.Enabled = false;
                txtRptMngr.Enabled = true;
                //lnkRptMngr.Enabled = true;
                lnkRptMngr.Attributes.Remove("disabled");

            }

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RHIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    #region fillNewAddlRptMngrDtls
    public void fillNewAddlRptMngrDtls(string agadltyp)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            if (Request.QueryString["flag"] == null)
            {
                htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
                htParam.Add("@ChnCls", hdnChncls.Value.Trim());
                htParam.Add("@AgentType", agadltyp.ToString().Trim());
                dsRpt = objDAC.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls", htParam);
            }
            else
            {
                htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
                htParam.Add("@ChnCls", hdnChncls.Value.Trim());
                htParam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                htParam.Add("@MgrCode", lblAgtCodeVal.Text.Trim());
                dsRpt = objDAC.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls_Trf_Approve", htParam);
                //lnkCrntAddlMgrNew.Enabled = false;
            }
            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                hdnRelOrder.Value = dsRpt.Tables[0].Rows[0]["RelOrder"].ToString();
                ViewState["AddlStp"] = dsRpt.Tables[0].Rows[0]["AddlStp"].ToString();
                //hdnAddlStp.Value = dsRpt.Tables[0].Rows[0]["AddlStp"].ToString();
                gv_RptMngr_new.DataSource = dsRpt.Tables[0];
                gv_RptMngr_new.DataBind(); // commented by mrunal 20.01.18
                bindNewAddlMngrGridData(dsRpt);
                if (Request.QueryString["flag"] != null)
                {
                    for (int i = 0; i < gv_RptMngr_new.Rows.Count; i++)
                    {
                        Button lnkRptMngr = (Button)gv_RptMngr_new.Rows[i].FindControl("lnkRptMngr");
                        TextBox txtRptMngr = (TextBox)gv_RptMngr_new.Rows[i].FindControl("txtRptMngr");
                        lnkRptMngr.Enabled = false;
                        txtRptMngr.Enabled = false;
                        //chkisprimry

                    }
                }
            }
            else
            {
                gv_RptMngr_Crnt.DataSource = null;
                gv_RptMngr_Crnt.DataBind();
                lblRptRulErr.Visible = true;
                lblRptRulErr.Text = "No Records Exists";
                lbladditionalreportingrule.Text = "";
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

    private void bindNewAddlMngrGridData(DataSet dsRpt)
    {
        try
        {
            gv_RptMngr_new.HeaderRow.Visible = false;
            for (int i = 0; gv_RptMngr_new.Rows.Count > i; i++)
            {

                DropDownList ddlAdlRptTyp = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp");
                ddlAdlRptTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString().Trim();

                DropDownList ddlAdlBsdOn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlBsdOn");
                ddlAdlBsdOn.SelectedValue = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString().Trim();

                DropDownList ddlAdlChn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn");
                ddlAdlChn.SelectedValue = dsRpt.Tables[0].Rows[i]["Channel"].ToString().Trim();

                HiddenField hdnAddlStp = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAddlStp");
                hdnAddlStp.Value = dsRpt.Tables[0].Rows[i]["AddlStp"].ToString().Trim();
                Button lnkRptMngr = (Button)gv_RptMngr_new.Rows[i].FindControl("lnkRptMngr");

                DropDownList ddlAdlSChn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn");
                ddlAdlSChn.SelectedValue = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString().Trim();
                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp");

                HiddenField hdnAdMemType = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAdMemType");

                TextBox txtRptMngr = (TextBox)gv_RptMngr_new.Rows[i].FindControl("txtRptMngr");
                Label lblmndtry = (Label)gv_RptMngr_new.Rows[i].FindControl("lblmndtry");
                HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnRptMgrMandatory");
                if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
                {
                    lblRptRulErr.Visible = false;
                    lblRptRulErr.Text = "";
                    lblNwaddtnlreptrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
                    funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
                    lblNwaddtnlreptrule.Visible = true;
                }
                else
                {
                    lblRptRulErr.Visible = true;
                    lblRptRulErr.Text = "No Records Exists";
                    lbladditionalreportingrule.Text = "";
                }
                #region fetch member type

                if (Request.QueryString["Type"] != null)
                {
                    if (hdnAddlStp.Value.Trim().ToString() == "E" && ddlAdlBsdOn.SelectedValue == "1")
                    {
                        funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
                        ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString();
                        ddlAdlAgtTyp.Enabled = false;
                        //ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                    }
                    else
                    {
                        hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                        ddlAdlAgtTyp.Enabled = true;
                    }
                }
                if (ddlAdlAgtTyp.SelectedValue == "RF")
                {
                    lnkRptMngr.Enabled = false;
                    txtRptMngr.Enabled = false;
                }
                #endregion

                hdnRptMgrMandatory.Value = dsRpt.Tables[0].Rows[i]["IsMandatory"].ToString();

                if (hdnRptMgrMandatory.Value == "True")
                {
                    txtRptMngr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                    lblmndtry.Visible = true;
                }

                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "A")
                    {
                        txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString().Trim() + "(" + dsRpt.Tables[0].Rows[i]["RptSapCode"].ToString().Trim() + ")";
                        Label lblRptMngr = (Label)gv_RptMngr_new.Rows[i].FindControl("lblRptMngr");
                        lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString().Trim();
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

    #region gv_RptMngr_Crnt_RowDataBound
    protected void gv_RptMngr_Crnt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Mngrno = (Label)e.Row.FindControl("lblNo");
                DropDownList ddlventype = (DropDownList)e.Row.FindControl("ddlventype");
                DropDownList ddlRelModel = (DropDownList)e.Row.FindControl("ddlRelModel");
                DropDownList ddlAdlRptTyp = (DropDownList)e.Row.FindControl("ddlAdlRptTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)e.Row.FindControl("ddlAdlBsdOn");

                DropDownList ddlAdlChn = (DropDownList)e.Row.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)e.Row.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)e.Row.FindControl("ddlAdlAgtTyp");

                oCommon.getDropDown(ddlventype, "ventype", 1, "", 1, c_strBlank);
                oCommon.getDropDown(ddlRelModel, "AgVenMapTyp", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlBsdOn.Items.Insert(0, new ListItem("--Select--", ""));


                funchnlpopup(ddlAdlChn);
                funsubchnlpopup(ddlAdlSChn, ddlAdlChn.SelectedValue.Trim());
                funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, Mngrno.Text);
                oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptTyp.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlSChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("--Select--", ""));


                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                ddlAdlAgtTyp.Enabled = false;

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

    #region gv_RptMngr_new_RowDataBound
    protected void gv_RptMngr_new_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Mngrno = (Label)e.Row.FindControl("lblNo");
                CheckBox chkisprimry = (CheckBox)e.Row.FindControl("chkisprimry");
                DropDownList ddlventype = (DropDownList)e.Row.FindControl("ddlventype");
                DropDownList ddlRelModel = (DropDownList)e.Row.FindControl("ddlRelModel");
                DropDownList ddlAdlRptTyp = (DropDownList)e.Row.FindControl("ddlAdlRptTyp");
                DropDownList ddlAdlBsdOn = (DropDownList)e.Row.FindControl("ddlAdlBsdOn");

                DropDownList ddlAdlChn = (DropDownList)e.Row.FindControl("ddlAdlChn");
                DropDownList ddlAdlSChn = (DropDownList)e.Row.FindControl("ddlAdlSChn");
                DropDownList ddlAdlAgtTyp = (DropDownList)e.Row.FindControl("ddlAdlAgtTyp");

                oCommon.getDropDown(ddlventype, "ventype", 1, "", 1, c_strBlank);
                oCommon.getDropDown(ddlRelModel, "AgVenMapTyp", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
                oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlBsdOn.Items.Insert(0, new ListItem("--Select--", ""));


                funchnlpopup(ddlAdlChn);
                funsubchnlpopup(ddlAdlSChn, ddlAdlChn.SelectedValue.Trim());
                funnewagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, Mngrno.Text);
                oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptTyp.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlSChn.Items.Insert(0, new ListItem("--Select--", ""));
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("--Select--", ""));
                ddlventype.Enabled = false;
                ddlRelModel.Enabled = false;
                ddlAdlRptTyp.Enabled = false;
                ddlAdlBsdOn.Enabled = false;
                ddlAdlChn.Enabled = false;
                ddlAdlSChn.Enabled = false;
                if (ViewState["AddlStp"].ToString() == "I")
                {
                    ddlAdlAgtTyp.Enabled = true;
                }
                else
                {
                    ddlAdlAgtTyp.Enabled = false;
                }
                chkisprimry.Enabled = false;

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

    #region funnewagttyppopup
    protected void funnewagttyppopup(DropDownList ddl, string BasedOn, string order)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@BizSrc", hdnBizsrc.Value);
            htparam.Add("@ChnCls", hdnChncls.Value);
            htparam.Add("@MemType", ddlAgntType.SelectedValue);
            htparam.Add("@RelOrder", hdnRelOrder.Value.ToString().Trim());
            dtRead = objDAC.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region funagttyppopup
    protected void funagttyppopup(DropDownList ddl, string BasedOn, string order)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
            htparam.Add("@ChnCls", ddlChnCls.SelectedValue);
            htparam.Add("@MemType", ddlAgntType.SelectedValue);
            htparam.Add("@RelOrder", order);
            dtRead = objDAC.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
            if (dtRead.HasRows)
            {
                ddl.DataSource = dtRead;
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
            dtRead = null;
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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
    #region fillAgtDtls
    public void fillAgtDtls()
    {
        try
        {
            Hashtable htagt = new Hashtable();
            DataSet dsagt = new DataSet();
            dsagt.Clear();
            htagt.Clear();
            htagt.Add("@Agtcode", Request.QueryString["AgnCd"].ToString().Trim());
            dsagt = objDAC.GetDataSetForPrc("prc_GetAgtPrmteDmteDtls", htagt);

            if (dsagt.Tables.Count > 0 && dsagt.Tables[0].Rows.Count > 0)
            {

                hdnBizsrc.Value = dsagt.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                hdnChncls.Value = dsagt.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                hdnagttyp.Value = dsagt.Tables[0].Rows[0]["MemType"].ToString().Trim();
                ViewState["Bizsrc"] = dsagt.Tables[0].Rows[0]["BizSrc"].ToString().Trim();
                ViewState["ChnCls"] = dsagt.Tables[0].Rows[0]["ChnCls"].ToString().Trim();
                ViewState["AgtType"] = dsagt.Tables[0].Rows[0]["MemType"].ToString().Trim();
            }
            else
            {
                hdnBizsrc.Value = null;
                hdnChncls.Value = null;
                hdnagttyp.Value = null;
                ViewState["Bizsrc"] = null;
                ViewState["ChnCls"] = null;
                ViewState["AgtType"] = null;
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
    #region lnkRptMngr_Click
    protected void lnkRptMngr_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
        Button lnkRptMngr = (Button)grd.FindControl("lnkRptMngr");
        DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
        DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
        DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
        DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
        DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
        TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
        string strRowID = ((System.Web.UI.Control)(grd)).ClientID.ToString();

        if (Request.QueryString["Ctgry"] != null)
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + hdnagttyp.Value + "','" + ddlAdlAgtTyp.SelectedValue + "','Emp','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + hdnagttyp.Value + "','" + ddlAdlAgtTyp.SelectedValue + "','Agent','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);//chnages by mrunal on 16.02.18
            }

            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + hdnagttyp.Value + "','" + ddlAdlAgtTyp.SelectedValue + "','','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
        }

    }
    #endregion
    protected string RetMemType(string Urnk, string bizsrc, string chncls)
    {
        Hashtable htunt = new Hashtable();
        DataSet dsunt = new DataSet();
        string member = String.Empty;
        htunt.Clear();
        htunt.Add("@BizSrc", bizsrc.ToString().Trim());
        htunt.Add("@ChnCls", chncls.ToString().Trim());
        htunt.Add("@UnitRank", Urnk.ToString().Trim());
        dsunt = objDAC.GetDataSetForPrcCLP("PrcGetMemUnitRnk", htunt);
        if (dsunt != null)
        {
            if (dsunt.Tables[0].Rows.Count > 0)
            {
                member = dsunt.Tables[0].Rows[0]["MemType"].ToString().Trim();
            }
        }
        else
        {
            dsunt = null;
            member = String.Empty;
        }
        return member;
    }
    protected void ddllvlagttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        /////GetManagers();
        txtRptMgr.Text = "";
        hdnNRptMgr.Value = null;
        lblNwRptMgr.Text = "";
    }
    protected void ddlAdlAgtTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((DropDownList)sender).NamingContainer as GridViewRow;
        TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
        HiddenField hdnAddlRptMgr = grd.FindControl("hdnAddlRptMgr") as HiddenField;
        Label lblRptMngr = (Label)grd.FindControl("lblRptMngr");

        txtRptMngr.Text = "";
        hdnAddlRptMgr.Value = null;
        lblRptMngr.Text = "";
    }
    protected void ddldwnlMem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldwnlMem.SelectedValue != "")
        {
            BindGridDownlines("CF", gv_Dwnls, lbldwnlsmsg);
            //tr2.Visible = true;
            tr2.Attributes.Add("style","display:block");
           // tr3.Visible = true;
           // tr3.Attributes.Add("style", "display:block");
        }
        else
        {
            tr2.Visible = false;
            tr3.Visible = false;
        }
    }

    #region BindGridDownlines
    protected void BindGridDownlines(string strtype, GridView gv, Label errmsg)
    {
        try
        {
            trDownlines.Visible = false;

            DataSet dsGrid = new DataSet();
            Hashtable httable = new Hashtable();
            dsGrid.Clear();
            httable.Clear();
            httable.Add("@AgtCode", lblAgtCodeVal.Text);
            httable.Add("@RptType", strtype.ToString().Trim());
            httable.Add("@MemType", ddldwnlMem.SelectedValue.Trim());

            dsGrid = objDAC.GetDataSetForPrcCLP("Prc_GetRelationForMemType", httable);
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
                {
                    trDownlines.Visible = true;
                    trDownlines.Attributes.Add("style","display:block");
                    gv.Visible = true;
                    gv.Attributes.Add("style", "display:block");
                    gv.DataSource = dsGrid;
                    gv.DataBind();
                    ViewState["dsGrid"] = dsGrid;

                    errmsg.Visible = false;
                    errmsg.Visible = false;
                }
                else
                {
                    gv.Visible = false;
                    gv.Visible = false;
                    //gv_TrfDownlines.DataBind();
                    trDownlines.Visible = true;
                    errmsg.Visible = true;
                    errmsg.Visible = true;
                }
            }
            else
            {
                gv.Visible = false;
                gv.Visible = false;
                //gv_TrfDownlines.DataBind();
                trDownlines.Visible = true;
                errmsg.Visible = true;
                errmsg.Visible = true;
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
            //con.Close();
        }
    }
    #endregion

    #region FillDwnlMem
    protected void FillDwnlMem(string code, DropDownList ddl)
    {
        Hashtable htParam = new Hashtable();
        DataSet dstyp = new DataSet();
        htParam.Add("@AgtCode", lblAgtCodeVal.Text);
        htParam.Add("@MemType", ddlAgntType.SelectedValue.Trim());

        dstyp = objDAC.GetDataSetForPrcCLP("Prc_GetRelationForMemType", htParam);
        if (dstyp.Tables.Count > 0)
        {
            if (dstyp.Tables[1].Rows.Count > 0)
            {
                ddl.DataSource = dstyp.Tables[1];
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
        }
        ddl.Items.Insert(0, new ListItem("--Select--", ""));
    }
    #endregion

    protected void GetMemTypes(string bizsrc, string chncls, DropDownList ddl)
    {
        Hashtable ht = new Hashtable();
        DataSet dsType = new DataSet();
        ht.Add("@BizSrc", bizsrc.ToString().Trim());
        ht.Add("@selectedchannel", chncls.ToString().Trim());
        dsType = objDAC.GetDataSetForPrcCLP("Prc_GetAgtType", ht);
        if (dsType.Tables.Count > 0)
        {
            if (dsType.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsType.Tables[0];
                ddl.DataTextField = "MemTypeDesc01";
                ddl.DataValueField = "MemType";
                ddl.DataBind();
            }
        }
        ddl.Items.Insert(0, new ListItem("--Select--", ""));

    }

    #region InsTrfDtls
    public void InsTrfDtls(int relorder, string reltyp, string RelBizsrc, string RelChnCls, string RelAgenttype, string RelAgentcode,string flagP)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();
            if (ddlTransferType.SelectedValue == "D")
            {
                ArrayList userdetails = new ArrayList();
                userdetails = (ArrayList)Session["CHKITEMS"];
                for (int intDataCount = 0; intDataCount <= userdetails.Count - 1; intDataCount++)
                {

                    if (flagP == "P")
                    {
                        for (int i = 0; i < gvUntLst.Rows.Count; i++)
                        {
                            Label lblUntCode = (Label)gvUntLst.Rows[i].FindControl("lblUntCode");
                            for (int j = 0; j < gv.Rows.Count; j++)
                            {
                                Label lblMemCode = (Label)gv.Rows[i].FindControl("lblMemCode");
                                Label lblName = (Label)gv.Rows[i].FindControl("lblName");
                                htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                htprm.Add("@AgentCode ", userdetails[intDataCount]);
                                htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                                htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                                htprm.Add("@Remark", txtRemark.Text);
                                htprm.Add("@UnitCode", hdnUnitCode.Value);
                                htprm.Add("@NewUntCode", lblUntCode.Text);
                                htprm.Add("@StatusFlag", "PN");
                                htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                                htprm.Add("@MgrRptType", reltyp);
                                htprm.Add("@MgrBizSrc", RelBizsrc.ToString().Trim());
                                htprm.Add("@MgrChnSubCls", RelChnCls.ToString().Trim());
                                htprm.Add("@MgrType", RelAgenttype.ToString().Trim());
                                htprm.Add("@MgrCode", lblMemCode.Text.Trim());
                                htprm.Add("@RelStatus", "New");
                                htprm.Add("@RelOrder", relorder);
                                dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gvUntLst.Rows.Count; i++)
                        {
                            Label lblUntCode = (Label)gvUntLst.Rows[i].FindControl("lblUntCode");
                            GridView gvAddlMgr = gv_RptMngr_new.Rows[i].FindControl("gvAddlMgr") as GridView;
                            for (int j = 0; j < gvAddlMgr.Rows.Count; j++)
                            {
                                Label lblMemCode = (Label)gvAddlMgr.Rows[i].FindControl("lblMemCode");
                                Label lblName = (Label)gvAddlMgr.Rows[i].FindControl("lblName");
                                Label lblRelAgttype = (Label)gvAddlMgr.Rows[i].FindControl("MemType");
                                htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                htprm.Add("@AgentCode ", userdetails[intDataCount]);
                                htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                                htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                                htprm.Add("@Remark", txtRemark.Text);
                                htprm.Add("@UnitCode", hdnUnitCode.Value);
                                htprm.Add("@NewUntCode", lblUntCode.Text);
                                htprm.Add("@StatusFlag", "PN");
                                htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                                htprm.Add("@MgrRptType", reltyp);
                                htprm.Add("@MgrBizSrc", RelBizsrc.ToString().Trim());
                                htprm.Add("@MgrChnSubCls", RelChnCls.ToString().Trim());
                                htprm.Add("@MgrType", "");//lblRelAgttype.Text.Trim());
                                htprm.Add("@MgrCode", lblMemCode.Text.Trim());
                                htprm.Add("@RelStatus", "New");
                                htprm.Add("@RelOrder", relorder);
                                dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
                            }
                        }
                    }
                }
            }
            else
            {
                if (flagP == "P")
                {
                    for (int i = 0; i < gvUntLst.Rows.Count; i++)
                    {
                        Label lblUntCode = (Label)gvUntLst.Rows[i].FindControl("lblUntCode");
                        for (int j = 0; j < gv.Rows.Count; j++)
                        {
                            Label lblMemCode = (Label)gv.Rows[i].FindControl("lblMemCode");
                            Label lblName = (Label)gv.Rows[i].FindControl("lblName");
                            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
                            htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                            htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                            htprm.Add("@Remark", txtRemark.Text);
                            htprm.Add("@UnitCode", hdnUnitCode.Value);
                            htprm.Add("@NewUntCode", lblUntCode.Text);
                            htprm.Add("@StatusFlag", "PN");
                            htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                            htprm.Add("@MgrRptType", reltyp);
                            htprm.Add("@MgrBizSrc", RelBizsrc.ToString().Trim());
                            htprm.Add("@MgrChnSubCls", RelChnCls.ToString().Trim());
                            htprm.Add("@MgrType", RelAgenttype.ToString().Trim());
                            htprm.Add("@MgrCode", lblMemCode.Text.Trim());
                            htprm.Add("@RelStatus", "New");
                            htprm.Add("@RelOrder", relorder);
                            dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gvUntLst.Rows.Count; i++)
                    {
                        Label lblUntCode = (Label)gvUntLst.Rows[i].FindControl("lblUntCode");
                        GridView gvAddlMgr = gv_RptMngr_new.Rows[i].FindControl("gvAddlMgr") as GridView;
                        for (int j = 0; j < gvAddlMgr.Rows.Count; j++)
                        {
                            Label lblMemCode = (Label)gvAddlMgr.Rows[i].FindControl("lblMemCode");
                            Label lblName = (Label)gvAddlMgr.Rows[i].FindControl("lblName");
                            Label lblRelAgttype = (Label)gvAddlMgr.Rows[i].FindControl("MemType");
                            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                            htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
                            htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                            htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                            htprm.Add("@Remark", txtRemark.Text);
                            htprm.Add("@UnitCode", hdnUnitCode.Value);
                            htprm.Add("@NewUntCode", lblUntCode.Text);
                            htprm.Add("@StatusFlag", "PN");
                            htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                            htprm.Add("@MgrRptType", reltyp);
                            htprm.Add("@MgrBizSrc", RelBizsrc.ToString().Trim());
                            htprm.Add("@MgrChnSubCls", RelChnCls.ToString().Trim());
                            htprm.Add("@MgrType", "");//lblRelAgttype.Text.Trim());
                            htprm.Add("@MgrCode", lblMemCode.Text.Trim());
                            htprm.Add("@RelStatus", "New");
                            htprm.Add("@RelOrder", relorder);
                            dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
                        }
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


    #region InsTrfDtlsOld
    public void InsTrfDtlsOld(int relorder)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();
            if (ddlTransferType.SelectedValue == "D")
            {
                ArrayList userdetails = new ArrayList();
                userdetails = (ArrayList)Session["CHKITEMS"];
                for (int intDataCount = 0; intDataCount <= userdetails.Count - 1; intDataCount++)
                {
                    htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                    htprm.Add("@AgentCode ", userdetails[intDataCount]);
                    htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                    htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                    htprm.Add("@Remark", txtRemark.Text);
                    htprm.Add("@UnitCode", hdnUnitCode.Value);
                    if (hdnUnitCode.Value == lblNwUntcd.Text)
                    {
                        htprm.Add("@NewUntCode", lblNwUntcd.Text);
                    }
                    else
                    {
                        htprm.Add("@NewUntCode", hdnNwUntcd.Value);
                    }
                    htprm.Add("@StatusFlag", "PN");
                    htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                    htprm.Add("@MgrRptType", ddlamrptdesc.SelectedValue.ToString().Trim());
                    htprm.Add("@MgrBizSrc", ddlamchnldesc.SelectedValue.ToString().Trim());
                    htprm.Add("@MgrChnSubCls", ddlamsubchnldesc.SelectedValue.ToString().Trim());
                    htprm.Add("@MgrType", ddllvlagttype.SelectedValue.ToString().Trim());
                    htprm.Add("@MgrCode", hdnNRptMgr.Value.Trim());
                    htprm.Add("@RelStatus", "Old");
                    htprm.Add("@RelOrder", relorder);
                    dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
                }
            }
            else
            {
                htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
                htprm.Add("@TrfReason", ddlTransferReason.SelectedValue);
                htprm.Add("@TrfType", ddlTransferType.SelectedValue);
                htprm.Add("@Remark", txtRemark.Text);
                htprm.Add("@UnitCode", hdnUnitCode.Value);
                if (hdnUnitCode.Value == lblNwUntcd.Text)
                {
                    htprm.Add("@NewUntCode", lblNwUntcd.Text);
                }
                else
                {
                    htprm.Add("@NewUntCode", hdnNwUntcd.Value);
                }
                htprm.Add("@StatusFlag", "PN");
                htprm.Add("@CreatedBy", Convert.ToString(Session["UserId"].ToString()));

                htprm.Add("@MgrRptType", ddlamrptdesc.SelectedValue.ToString().Trim());
                htprm.Add("@MgrBizSrc", ddlamchnldesc.SelectedValue.ToString().Trim());
                htprm.Add("@MgrChnSubCls", ddlamsubchnldesc.SelectedValue.ToString().Trim());
                htprm.Add("@MgrType", ddllvlagttype.SelectedValue.ToString().Trim());
                htprm.Add("@MgrCode", hdnNRptMgr.Value.Trim());
                htprm.Add("@RelStatus", "Old");
                htprm.Add("@RelOrder", relorder);
                dsprm = objDAC.GetDataSetForPrc("Prc_RptMngrTransfer", htprm);
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

    //added by amruta for chms upgrade on 30/6/16 start
    #region Tab lnkHierarchy_Clicr Click EVENT
    protected void lnkHierarchy_Click(object sender, EventArgs e)
    {
        divHirarchy.Attributes.Add("style", "display:block");
        divPrimry.Attributes.Add("style", "display:none");
        divAdditional.Attributes.Add("style", "display:none");
       divDownlines.Attributes.Add("style", "display:none"); 
        hdnTab.Value = "1";
        lnkHierarchy.CssClass = "btn-subtab btn btn-default";
        lnkprimary.CssClass = "btn btn-default";
        lnkadditional.CssClass = "btn btn-default";
        lnkDownlines.CssClass = "btn btn-default";
    }
    #endregion

    #region Tab lnkprimaryl_Click Click EVENT
    protected void lnkprimaryl_Click(object sender, EventArgs e)
    {
        divHirarchy.Attributes.Add("style", "display:none");
        divPrimry.Attributes.Add("style", "display:block");
        divAdditional.Attributes.Add("style", "display:none");
        divDownlines.Attributes.Add("style", "display:none");
        hdnTab.Value = "2";
        lnkHierarchy.CssClass = "btn btn-default";
        lnkprimary.CssClass = "btn-subtab btn btn-default";
        lnkadditional.CssClass = "btn btn-default";
        lnkDownlines.CssClass = "btn btn-default";
    }
    #endregion

    #region Tab lnkadditional_Click Click EVENT
    protected void lnkadditional_Click(object sender, EventArgs e)
    {
        divHirarchy.Attributes.Add("style", "display:none");
        divPrimry.Attributes.Add("style", "display:none");
        divAdditional.Attributes.Add("style", "display:block");
        divDownlines.Attributes.Add("style", "display:none");
        hdnTab.Value = "3";
        lnkHierarchy.CssClass = "btn btn-default";
        lnkprimary.CssClass = "btn btn-default";
        lnkadditional.CssClass = "btn-subtab btn btn-default";
        lnkDownlines.CssClass = "btn btn-default";
    }
    #endregion

    #region Tab lnkDownlines_Click Click EVENT
    protected void lnkDownlines_Click(object sender, EventArgs e)
    {
        divHirarchy.Attributes.Add("style", "display:none");
        divPrimry.Attributes.Add("style", "display:none");
        divAdditional.Attributes.Add("style", "display:none");
        divDownlines.Attributes.Add("style", "display:block");
        hdnTab.Value = "4";
        lnkHierarchy.CssClass = "btn btn-default";
        lnkprimary.CssClass = "btn btn-default";
        lnkadditional.CssClass = "btn btn-default";
        lnkDownlines.CssClass = "btn-subtab btn btn-default";
    }
    #endregion
    //added by amruta for chms upgrade on 30/6/16 end




    #region Hierarchy_Click
    protected void Hierarchy_Click(object sender, EventArgs e)
    {
        // MVNewDtls.ActiveViewIndex = 0;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        tblNewDts.Attributes.Add("style", "display:block");
        divHierNew.Attributes.Add("style", "display:block");
        divprimnew.Attributes.Add("style", "display:none");
        PrimaryDemo.Attributes.Add("style", "display:none");
        divdwnldtls.Attributes.Add("style", "display:none");
        //tr2.Attributes.Add("style", "display:none");
        //tr3.Attributes.Add("style", "display:none");
        //trdwnl.Attributes.Add("style", "display:none");
       // GetTrfCrntDtls();

        Hierarchy.CssClass = "btn-subtab btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn btn-default";
    }
    #endregion

    #region Primary_Click
    protected void Primary_Click(object sender,EventArgs e)
    {
        //MVNewDtls.ActiveViewIndex = 1;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";
        //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        tblNewDts.Attributes.Add("style", "display:block");
        divHierNew.Attributes.Add("style", "display:none");
        divprimnew.Attributes.Add("style", "display:block");
        PrimaryDemo.Attributes.Add("style", "display:none");
        //commented by mrunal on 17.02.18 for downlines transfer
        divdwnldtls.Attributes.Add("style", "display:none");
        //tr2.Attributes.Add("style", "display:none");
        if (ddlTransferType.SelectedValue != "D")
        {
            tr3.Attributes.Add("style", "display:none");
        }
        //trdwnl.Attributes.Add("style", "display:none");
        //end
        if (ddlTransferType.SelectedValue != "C")
        {
          //  GetTrfCrntDtls();
        }

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn-subtab btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn btn-default";

        //lblNwUntcd.Text = hdnNwUntcd.Value.Trim();
        //hdnNRptMgr.Value = lblNwRptMgr.Text;

    }
    #endregion

    #region Additional_Click
    protected void Additional_Click(object sender, EventArgs e)
    {
        //  MVNewDtls.ActiveViewIndex = 2;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        ////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        //   lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        tblNewDts.Attributes.Add("style", "display:block");
        divHierNew.Attributes.Add("style", "display:none");
        divprimnew.Attributes.Add("style", "display:none");
        PrimaryDemo.Attributes.Add("style", "display:block");
        divdwnldtls.Attributes.Add("style", "display:none");
        //tr2.Attributes.Add("style", "display:none");
        if (ddlTransferType.SelectedValue != "D")
        {
            tr3.Attributes.Add("style", "display:none");
        }
        //trdwnl.Attributes.Add("style", "display:none");
        //GetTrfCrntDtls();

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn-subtab btn btn-default";
        Downlines.CssClass = "btn btn-default";

    }
    #endregion

    #region Downlines_Click
    protected void Downlines_Click(object sender, EventArgs e)
    {
        // MVNewDtls.ActiveViewIndex = 3;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        //lnkCrntAddlMgrNew.BackColor = Color.Transparent;
        lnkCrntDlinesNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        //  lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlinesNew.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";

        tblNewDts.Attributes.Add("style", "display:block");
        divHierNew.Attributes.Add("style", "display:none");
        divprimnew.Attributes.Add("style", "display:none");
        PrimaryDemo.Attributes.Add("style", "display:none");
        divdwnldtls.Attributes.Add("style", "display:block");
        
        if (ddlTransferType.SelectedValue != "D")
        {
            tr2.Attributes.Add("style", "display:none");
            tr3.Attributes.Add("style", "display:none");
        }
        trdwnl.Attributes.Add("style", "display:none");
       // GetTrfCrntDtls();

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn-subtab btn btn-default";

        BindGridRelation("CF", gv_NewDownlines, lblDwlnErrmsg);


    }
    #endregion

    protected void btnmemgrid_Click(object sender, EventArgs e)
    {
        if (Session["mem"] != null)
        {
            gv.DataSource = Session["mem"];
            gv.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gv.Rows.Count - 1; intRowCount++)
            {
                Label MemCode = (Label)gv.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
                Label MemType = (Label)gv.Rows[intRowCount].Cells[0].FindControl("lblMemType");
                str = str + MemCode.Text;
                str += (intRowCount < gv.Rows.Count - 1) ? "," : string.Empty;
                ddllvlagttype.SelectedItem.Text = MemType.Text.Trim();
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "E")
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ddlAgntType.SelectedValue.Trim() + "','Emp','" + str + "');return false;");
                }
                else if (Request.QueryString["Ctgry"].ToString().Trim() == "A")
                {
                   // btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ddlAgntType.SelectedValue.Trim() + "','Agent','" + str + "');return false;");
                  //  ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>fununtpopup('untcode','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ViewState["code"] + "','Agent','');</script>", false);
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + hdnchn.Value.Trim() + "','" + hdnsubchn.Value.Trim() + "','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ViewState["code"] + "','Agent','';return false;");
                }
            }
        }
    }


    //Added by mrunal on 16.02.18
    #region btnRptmemgrid_Click
    protected void btnRptmemgrid_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
        GridView gvAddlMgr = (GridView)grd.FindControl("gvAddlMgr");
        if (Session["addlmem"] != null)
        {
            gvAddlMgr.DataSource = Session["addlmem"];
            gvAddlMgr.DataBind();
        }


    }
    #endregion

    protected void btnunitgrid_Click(object sender, EventArgs e)
    {
        if (Session["unt"] != null)
        {
            gvUntLst.DataSource = Session["unt"];
            gvUntLst.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvUntLst.Rows.Count - 1; intRowCount++)
            {
                Label UntCode = (Label)gvUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                str = str + UntCode.Text;
                str += (intRowCount < gvUntLst.Rows.Count - 1) ? "," : string.Empty;

                hdnNwUntcd.Value = UntCode.Text.Trim();
                lblNwUntcd.Text = UntCode.Text.Trim();
            }
          
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "E")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString().Trim() + "','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

                }
                else if (Request.QueryString["Ctgry"].ToString().Trim() == "A")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlamchnldesc.SelectedValue.Trim() + "','" + ddlamsubchnldesc.SelectedValue.Trim() + "','" + ddllvlagttype.SelectedValue + "','','" + ddlambasedondesc.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

                }
            }
        }
    }

    protected void FillUntRptDtls()
    {
        DataSet ds = new DataSet();
        Hashtable ht = new Hashtable();
        ht.Clear();
        ds.Clear();
        ht.Add("@MemCode", lblAgtCodeVal.Text);
        ds = objDAC.GetDataSetForPrcCLP("Prc_GetUntCodes", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (Session["unt"] != null)
            {
                gvUntLst.DataSource = ds.Tables[0];
                gvUntLst.DataBind();
                Session["unt"] = ds;
            }
        }
        if (Request.QueryString["chrt"] != null)
        {
            gv.DataSource = FillDataTable(Request.QueryString["chrt"].ToString().Trim(), hdnName.Value.Trim(), ddllvlagttype.SelectedItem.Text.Trim(), hdnUntCode.Value.Trim());
            gv.DataBind();
            Session["mem"] = ds;
        }
        else
        {
            ht.Clear();
            ds.Clear();
            ht.Add("@MemCode", lblAgtCodeVal.Text);
            ht.Add("@MvmtType", "TRF");
            ht.Add("@Flag", "A");
            ds = objDAC.GetDataSetForPrcCLP("Prc_GetRptMemCodes", ht);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (Session["mem"] != null)
                {
                    gv.DataSource = ds.Tables[0];
                    gv.DataBind();
                    Session["mem"] = ds;
                }
            }
        }
    }

    protected DataTable FillDataTable(string memcode,string name,string memtype,string unitcode)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("MemCode");
        dt.Columns.Add("Name");
        dt.Columns.Add("MemType");
        dt.Columns.Add("UnitCode");

        DataRow dr = dt.NewRow();
        dr["MemCode"] = memcode.Trim();
        dr["Name"] = name.Trim();
        dr["MemType"] = memtype.Trim();
        dr["UnitCode"] = unitcode.Trim();
        dt.Rows.Add(dr);
        return dt;
    }

   
}
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using DataAccessClassDAL;
using DataDynamics.ActiveReports.Document;
using Insc.Common.Multilingual;
using INSCL.DAL;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class Application_INSC_ChannelMgmt_AGTTermination : BaseClass
{

    #region Global Declarations
    ErrLog objErr = new ErrLog();
    DataAccessClass objDAC = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    CommonFunc oCommon = new CommonFunc();
    private multilingualManager m_olng;
    private multilingualManager m_olng2;
    clsAgent Agnet = new clsAgent();
    clsAgent objCls = new clsAgent();
    SqlDataReader dtRead;
    DataSet dsResult = new DataSet();
    private const string c_strBlank = "Select";
    private string m_strUserLang, m_strMgrCode, m_strUnitCode, m_strDirectAgtCode, m_strAgentStatus, m_strAgentTypeAddl;
    string strBizSrc = String.Empty;
    string strBizSrcDesc = String.Empty;
    string strChnCls = String.Empty;
    string strAgentType = String.Empty;
    string mvmtcode = String.Empty;
    string cms = String.Empty;//added by akshay on 25/03/14 for unit code section
    string unt = String.Empty;//added by akshay on 25/03/14 for unit code section
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        { Response.Redirect("~/ErrorSession.aspx"); }

        //Agent Code
        ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();

        //Declare some auxillary variables
        m_strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
        if (Request.QueryString["Ctgry"] != null)///added by akshay on 25/03/14
        {
            if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
            {
                m_olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", m_strUserLang);
            }
        }
        else
        {
            m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
        }
        Session["CarrierCode"] = '2';
        
        //Initialize Agent Category
        lblAgntClassVal.Visible = true;
        //lblAgntClassVal.Enabled = true;
        lblAgntClassVal.Text = "STAFF";
        ddlTermReason.Focus();
        //End
        
        if (!IsPostBack)
        {

            #region Initialize Values
            oCommon.getDropDown(ddlTermReason, "trmReason", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlTermReason.Items.Insert(0, new ListItem("Select", ""));
            lblEffectiveDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            btnTerminate.Attributes.Add("onClick", "javascript: return funValidate();");
       
           // MultiViewCrnt.ActiveViewIndex = 0;
            lnkHierarchy.CssClass = "btn-subtab btn btn-default";
            hdnTab.Value = "1";
            divprirepHdr.Attributes.Add("style", "display:none");
            divMngrDtlsHdr.Attributes.Add("style", "display:none");
            divCrntDownLinesHdr.Attributes.Add("style", "display:none");
            lnkCrntHier.BackColor = Color.Transparent;
            lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
            #endregion

           //Name Labels
            InitializeControl();
            
            //Hide/Show Lables
            manipulateInputControls();
            
            //Fill Data
            fillAllLabels();

            //Bind the grid to show the Child Father downlines for a agent.
            BindGridRelation("CF");

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToString() == "TR")
                {
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString() == "A")
                        {
                            btnApprove.Visible = true;
                            btnReject.Visible = true;
                            btnTerminate.Visible = false;

                            GetTermDetails();
                            ddlTermReason.Enabled = false;
                            txtRemark.Enabled = false;

                        }
                    }
                }
            }
        }
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
     }
    #endregion

    #region Supplementary Functions

    protected void manipulateInputControls()
    {
        rdbChnlTyp.Enabled = false;

        //lblCusmIdVal.Enabled = true;
        //lblAgtCodeVal.Enabled = true;
        //lblAgntNameVal.Enabled = true;
        ////lblagnTitleVal.Enabled = true;
        //lblAgntStatusVal.Enabled = true;

    }

    protected void FillRequiredDataForPage1()
    {
        dsResult = new DataSet();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", Convert.ToString(Request.QueryString["AgnCd"].ToString().Trim()));
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
                    strChnCls = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);///addede by akshay on 25/03/14
                    strBizSrcDesc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);

                    lblagnTitleVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgnTitle"]);
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblRptMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MgrName"]);

                    hdnprimcode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["MgrCode"]);
                    hdnaddl1code.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1MgrCode"]);
                    hdnaddl2code.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2MgrCode"]);
                    hdnaddl3code.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl3MgrCode"]);

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
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim() == "LG" || Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim() == "VL")
                                {
                                    //Added by Pranjali on 02-07-2013 for getting agent Type in 'LG' AND 'VL' on Channel sub class dropdownlist start
                                    htparam.Clear();
                                    htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                    htparam.Add("@BizSrc", strBizSrc);
                                    htparam.Add("@ChnCls", strChnCls);
                                    dsResulttemp = objDAC.GetDataSetForPrc("Prc_GetAgnTypedesc", htparam);
                                    if (dsResulttemp.Tables.Count > 0 && dsResulttemp.Tables[0].Rows.Count > 0)
                                    {
                                        lblAgntTypeVal.Text = Convert.ToString(dsResulttemp.Tables[0].Rows[0]["AgnDesc"]);
                                    }
                                    dsResulttemp.Clear();
                                    dtRead = null;
                                }
                                //To allow change in all agenttype
                                else
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
                                    //Added by Pranjali on 02-07-2013 for getting unitrank from chnAgnSu end

                                    if (dtRead.Read())
                                    {
                                        if (Convert.ToDecimal(dtRead["UnitRank"].ToString()) <= 7)
                                        {
                                            DataSet dsAgentType;
                                            htparam = new Hashtable();
                                            htparam.Clear();
                                            htparam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                                            htparam.Add("@BizSrc", strBizSrc);
                                            htparam.Add("@ChnCls", strChnCls);
                                            dsAgentType = objDAC.GetDataSetForPrc("Prc_GetAgnTypedesc", htparam);

                                            if (dsAgentType.Tables.Count > 0 && dsAgentType.Tables[0].Rows.Count > 0)
                                            {
                                                lblAgntTypeVal.Text = Convert.ToString(dsAgentType.Tables[0].Rows[0]["AgnDesc"]);
                                            }
                                            dsAgentType = null;
                                        }
                                    }
                                }
                                //end of To allow change in all agenttype
                            }
                            lblAgntTypeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentTypeDesc"]).Trim();
                            hdnagttyp.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]).Trim();
                        }
                    }

                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    //added by akshay on 25/03/14 for unit code details section
                   // cms = dsResult.Tables[0].Rows[0]["UntCms"].ToString().Trim(); //comented by usha on 17.02.2018
                    cms = dsResult.Tables[0].Rows[0]["Unt"].ToString().Trim();
                    unt = dsResult.Tables[0].Rows[0]["Unt"].ToString().Trim();
                    lblUCode.Text = unt + "(" + cms + ")";
                    lblUnitDesc.Text = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    lblUntAddr.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["untadr"]);
                    //added by akshay on 25/03/14 for unit code details section
                    hdnUntCode.Value = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    FillReportingMngrDtls();
                    FillUnits();
                    FillPrimMgr();
                    FillAddlMgr();

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
    protected void FillUnits()
    {
        DataSet ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@MemCode", lblAgtCodeVal.Text);
        htParam.Add("@MvmtType", "");
        ds = objDAL.GetDataSetForPrcCLP("Prc_GetUntCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvUntLst.DataSource = ds.Tables[0];
            gvUntLst.DataBind();
            Session["unt"] = ds;
        }
    }

    protected void FillPrimMgr()
    {
        DataSet ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@MemCode", lblAgtCodeVal.Text);
        htParam.Add("@MvmtType", "");
        htParam.Add("@Flag", "");
        ds = objDAL.GetDataSetForPrcCLP("Prc_GetRptMemCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds.Tables[0];
            gv.DataBind();
            Session["mem"] = ds;
        }
    }

    protected void FillAddlMgr()
    {
        DataSet ds = new DataSet();
        htParam.Clear();
        for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
        {

            GridView gvAddlMgr = gv_RptMngr.Rows[i].FindControl("gvAddlMgr") as GridView;

            htParam.Clear();
            ds.Clear();
            htParam.Add("@MemCode", lblAgtCodeVal.Text);
            htParam.Add("@RelOrder", i + 1);
            htParam.Add("@MvmtType", "");
            ds = objDAL.GetDataSetForPrcCLP("Prc_GetAddlRptMemCodes", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddlMgr.DataSource = ds.Tables[0];
                gvAddlMgr.DataBind();
                Session["addlmem"] = ds;
            }
        }
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
            htParam.Add("@AgentType", strAgentType);
            htParam.Add("@BizSrc", strBizSrc);
            htParam.Add("@ChnCls", strChnCls);
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    lblprimrepoVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryRpTyp"].ToString();
                    lblbasedondescVal.Text = dsRpt.Tables[0].Rows[0]["BasedOn"].ToString();
                    lblsubchnldescVal.Text = dsRpt.Tables[0].Rows[0]["PrimarySubChnl"].ToString();
                    lbllvlagtVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryAgtOrLevelType"].ToString();
                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();
                    hdnPrimType.Value = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                    hdnPriagttyp.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString();
                    
                    
                    //if (MultiViewCrnt.ActiveViewIndex == 2)
                    if (hdnTab.Value == "3")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
                    }
                }
                else
                {
                   // if (MultiViewCrnt.ActiveViewIndex == 2)
                    if (hdnTab.Value == "3")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                    }
                }
            }
            else
            {
               // if (MultiViewCrnt.ActiveViewIndex == 2)
                if (hdnTab.Value == "3")
                {
                    ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                }
            }
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
           // int valChnType = Convert.ToInt16(DS.Tables[0].Rows[0]["chnltype"]);


            lblchanneldescVal.Text = Convert.ToString(DS.Tables[0].Rows[0]["chnl"]);
            strBizSrc = Convert.ToString(DS.Tables[0].Rows[0]["BizSrc"]);
            lblChnClsVal.Text = Convert.ToString(DS.Tables[0].Rows[0]["subchnl"]);
            strChnCls = Convert.ToString(DS.Tables[0].Rows[0]["chncls"]);
         
            HT.Clear();
            DS.Clear();
            //Comented by usha on 17.02.2018
            //if (valChnType == 1)
            //    htParam.Add("@chnltyp", "1");
            //if (valChnType == 0)
            //    htParam.Add("@chnltyp", "0");

            //tempds = objDAC.GetDataSetForPrc("Prc_GetUserSalesChannel", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblSlsChannelVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
            //    lblchanneldescVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
            //    strBizSrc = Convert.ToString(tempds.Tables[0].Rows[0]["BizSrc"]);
            //    tempds.Clear();
            //}
            ////End

            ////Channel Class Dropdown
            //htParam.Clear();
            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htParam.Add("@BizSrc", strBizSrc);
            //tempds = objDAC.GetDataSetForPrc("Prc_ddlchnnlsubcls", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblChnClsVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChnlDesc"]);
            //    strChnCls = Convert.ToString(tempds.Tables[0].Rows[0]["ChnCls"]);
            //    tempds.Clear();
            //}
            //Comented by usha on 17.02.2018
            //End

            //An extra function to obtain the agent type on agent code
            htParam.Clear();
            htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
            htParam.Add("@Flag", 4);
            tempds = objDAC.GetDataSetForPrc("prc_GetAgnCodeandAgnName", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["MemType"]);
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

    #region btnCancel_Click Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        if (Request.QueryString["Ctgry"] != null)
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

    #region btnTerminate_Click Event
    protected void btnTerminate_Click(object sender, EventArgs e)
    {
        SetTerminateReq();
    }
    #endregion

    #region BindGridRelationMethod
    ////method to show downlines of a particular agent
    protected void BindGridRelation(string strtype)
    {
        try
        {
            ///trDownlines.Visible = false;
            
            DataSet dsGrid = new DataSet();
            Hashtable httable = new Hashtable();
            dsGrid.Clear();
            httable.Clear();
            httable.Add("@AgtCode", lblAgtCodeVal.Text);
            httable.Add("@RptType", strtype.ToString().Trim());

            dsGrid = objDAC.GetDataSetForPrcCLP("Prc_GetRelationForAgtCode", httable);
            ViewState["dsGrid"] = dsGrid;
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
                {
                    gv_TrfDownlines.AllowSorting = true;
                    trDownlines.Visible = true;
                    gv_TrfDownlines.DataSource = dsGrid;
                    gv_TrfDownlines.DataBind();
                    lblDownlineErrorMsg.Visible = false; 
                   // btnTrf.Visible = true;//comented by usha on 17.02.2018
                    btnTrf.Visible = false;
                }
                else
                {
                    gv_TrfDownlines.AllowSorting = false;
                    gv_TrfDownlines.DataSource = null;
                    gv_TrfDownlines.DataBind();
                    //trDownlines.Visible = false;
                    //lblDownlineErrorMsg.Visible = true;  
                    ShowNoResultFound(dsGrid.Tables[0], gv_TrfDownlines);
                }
            }
            else
            {
                gv_TrfDownlines.AllowSorting = false;
                gv_TrfDownlines.DataSource = null;
                gv_TrfDownlines.DataBind();
                ///trDownlines.Visible = false;
               // lblDownlineErrorMsg.Visible = true;
                ShowNoResultFound(dsGrid.Tables[0], gv_TrfDownlines);
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
    /////click events to show primary and additional downline details of agents
    #region lnkbtnCF_Click Event
    protected void lnkbtnCF_Click(object sender, EventArgs e)
    {
        BindGridRelation("CF");
        if (hdnTab.Value == "3")
       // if (MultiViewCrnt.ActiveViewIndex == 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        }
    }
    #endregion

    #region lnkbtnCU_Click Event
    protected void lnkbtnCU_Click(object sender, EventArgs e)
    {
        BindGridRelation("CU");
        if (hdnTab.Value == "3")
       // if (MultiViewCrnt.ActiveViewIndex == 2)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        }
    }
    #endregion

    #endregion

    #region btnTrf_Click Event
    ////click event to redirect agent details to transfer page
    protected void btnTrf_Click(object sender, EventArgs e)
    {
        string agtcode = lblAgtCodeVal.Text;
        string ctrgy = Request.QueryString["Ctgry"].ToString().Trim();
        Response.Redirect("..\\ChannelMgmt\\AGTTransfer.aspx?flag=TrmTrf&Type=N&Ctgry=" + ctrgy.ToString() + "&AgtCode=" + agtcode.ToString().Trim(), false);
    }
    #endregion

    #region gv_TrfDownlines_PageIndexChanging Event
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

    #region gv_TrfDownlines_Sorting Event
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
    /// <summary>
    /// This method displays paging information in the appropriate label
    /// </summary>
    private void ShowPageInformation()
    {
        int intPageIndex = gv_TrfDownlines.PageIndex + 1;
        string pageind = "Page " + intPageIndex.ToString() + " of " + gv_TrfDownlines.PageCount;
    }
    #endregion

    #region lnkCrntPrimMgr_Click Event
    ////click event to show primary manager tab
    protected void lnkCrntPrimMgr_Click(object sender, ImageClickEventArgs e)
    {
       // MultiViewCrnt.ActiveViewIndex = 1;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;
        
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion

    #region lnkCrntAddlMgr_Click Event
    ////click event to show additional manager tab
    protected void lnkCrntAddlMgr_Click(object sender, ImageClickEventArgs e)
    {
       // MultiViewCrnt.ActiveViewIndex = 2;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        ////ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";
    }
    #endregion

    #region lnkCrntDlines_Click
    ////click event to show Downlines tab
    protected void lnkCrntDlines_Click(object sender, ImageClickEventArgs e)
    {
       // MultiViewCrnt.ActiveViewIndex = 3;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region lnkCrntHier_Click Event
    ////click event to show Hierarchy Details tab
    protected void lnkCrntHier_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 0;

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

    protected void SetTerminateReq()
    {
        Hashtable htmvmtlg = new Hashtable();
        DataSet dsMvmt = new DataSet();
        ArrayList arrResult = new ArrayList();
        ViewState["vwsAgntCode"] = lblAgtCodeVal.Text.Trim();

        //Reinitialize and Fill Parameters
      
            htmvmtlg.Clear();
            htmvmtlg.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htmvmtlg.Add("@MovementType", "TR");
            htmvmtlg.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htmvmtlg.Add("@AgentType", hdnagttyp.Value.ToString().Trim());
            htmvmtlg.Add("@UserId", Session["UserID"].ToString());
            htmvmtlg.Add("@StatusFlag", "PN");
            htmvmtlg.Add("@CreatedBy", Session["UserID"].ToString());
            htmvmtlg.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));
            htmvmtlg.Add("@UnitCode", "");
            htmvmtlg.Add("@EffDate", DateTime.Parse(lblEffectiveDate.Text).ToString("yyyyMMdd"));
            htmvmtlg.Add("@Remark", txtRemark.Text);
            htmvmtlg.Add("@CeaseReason", ddlTermReason.SelectedValue.ToString());

            try
            {
                arrResult = objCls.TerminationAgentDetails(htmvmtlg, "Prc_MemberTerm");

                if (arrResult.Count > 0)
                {
                    if (arrResult[0].ToString() != "F")
                    {
                        if (arrResult.Count > 0)
                        {
                            if (arrResult[0].ToString().Equals("0"))
                            {
                                //lbl3.Text = "Termination Request Sent For Approval";
                                //lbl4.Text = "Member Code : " + lblAgtCodeVal.Text;
                                //lbl5.Text = "Member Name : " + lblAgntNameVal.Text;
                                //mdlpopup.Show();
                                htParam.Clear();
                                dsResult.Clear();

                                if (Request.QueryString["MvmtRule"] != null)
                                {
                                    if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                                    {
                                        htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
                                        htParam.Add("@UserID", Session["UserID"].ToString().Trim());
                                        htParam.Add("@AgentType", Request.QueryString["MvmtRule"].ToString().Trim());
                                        htParam.Add("@MvmtTyp", "TR");
                                        htParam.Add("@Flag", "2");
                                        dsResult = objDAC.GetDataSetForPrc("PrcMemberTypDtls", htParam);
                                        if (dsResult.Tables.Count > 0)
                                        {
                                            if (dsResult.Tables.Count > 0)
                                            {
                                                //lblMessage.Text = "Termination Request  is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                                                //lbl3.Text = "Termination Request  is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();

                                                //lbl4.Text = lvlVw1AgntCode.Text + " : " + lblAgtCodeVal.Text;
                                                //lbl5.Text = lblAgntName.Text + " : " + lblAgntNameVal.Text;
                                                lbl3.Text = "Termination done successfully";   //AddedControl by usha  16.02.2018
                                                lnkCancel.Visible = false; 
                                                mdlpopup.Show();

                                                //lbl_popup.Text = "Termination Request is<br /><br />" + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim()+"<br/><br/>Member Code : " + lblAgtCodeVal.Text + "<br /><br />Member Name : " + lblAgntNameVal.Text;
                                                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                                btnTerminate.Enabled = false;
                                              
                                            }
                                        }
                                    }
                                }
                                lbl3.Text = "Termination done successfully";   //AddedControl by usha  16.02.2018
                                lnkCancel.Visible = false;
                                mdlpopup.Show();
                                btnTerminate.Enabled = false;
                               
                            }
                            else
                            {
                                switch (arrResult[0].ToString())
                                {
                                    case "-1": lblMessage.Text = "";
                                        break;
                                    case "-2": lblMessage.Text = "Member already pending for termination. ";
                                        break;
                                    case "-6": lblMessage.Text = "There are downlines under this member(unit manager). Termination is not possible ";
                                        break;
                                    case "-3": lblMessage.Text = "There are downlines under this member. Termination is not possible  ";
                                        break;
                                    case "-4": lblMessage.Text = "There are more than one units under this manager. Termination is not possible.";
                                        hdnmsg.Value = "0";
                                        break;
                                    case "-5": lblMessage.Text = "'" + lblAgntTypeVal.Text + "'" + " cannot be terminated";////added by akshay on 03/03/14 to display message if agent type cannot be terminated
                                        break;
                                    default: lblMessage.Text = "System Error";
                                        break;
                                }
                                //////////////ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblMessage.Text + "');</script>", false);
                                lbl3.Text = lblMessage.Text;
                                btnok.Visible = true;  //added by usha 
                                lnkCancel.Visible = false;
                                btnTerminate.Enabled = false;
                                mdlpopup.Show();
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Text = arrResult[1].ToString();
                    }
                }
                else
                {
                    lblMessage.Text = "Error Updating Agent Termination Details!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblMessage.Text + "');</script>", false);
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

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        TermAppRej("A");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        TermAppRej("R");
    }

    protected void GetTermDetails()
    {
        Hashtable htTerm = new Hashtable();
        DataSet dsTerm = new DataSet();
        ViewState["vwsAgntCode"] = lblAgtCodeVal.Text.Trim();

        try
        {
            htTerm.Add("@AgtCode", ViewState["vwsAgntCode"].ToString());
            dsTerm = objDAC.GetDataSetForPrcDBConn("Prc_GetTermDtls", htTerm, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            htTerm.Clear();
            if (dsTerm.Tables.Count > 0)
            {
                if (dsTerm.Tables[0].Rows.Count > 0)
                {
                    ddlTermReason.SelectedValue = dsTerm.Tables[0].Rows[0]["TermRes"].ToString().Trim();
                    lblEffectiveDate.Text = dsTerm.Tables[0].Rows[0]["EffDate"].ToString().Trim();
                    txtRemark.Text = dsTerm.Tables[0].Rows[0]["Remarks"].ToString().Trim();
                }
            }
            else
            {
                dsTerm = null;
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

    protected void TermAppRej(string flag)
    {
        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"].ToString() == "TR")
            {
                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString() == "A")
                    {
                        #region commented part
                        DataSet dsresult = new DataSet();
                        ArrayList arrResult = new ArrayList();
                        ViewState["vwsAgntCode"] = lblAgtCodeVal.Text.Trim();
                        Hashtable htable = new Hashtable();

                        htable.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                        htable.Add("@AgentCode ", ViewState["vwsAgntCode"].ToString());
                        htable.Add("@CeaseReason", ddlTermReason.SelectedValue.ToString());
                        htable.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));
                        htable.Add("@TermFlag", flag.ToString());

                        if (Request.QueryString["MvmtRule"] != null)
                        {
                            if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                            {
                                htable.Add("@MvmtLvl", Request.QueryString["MvmtRule"].ToString().Trim());
                            }
                        }
                        try
                        {
                            dsresult = objDAC.GetDataSetForPrcCLP("prc_MemTerm_AppRej", htable);
                            if (flag == "A")
                            {
                                //lbl3.Text = "Termination Approved Succesfully";
                                //lbl4.Text = "Agent Code : " + lblAgtCodeVal.Text;
                                //lbl5.Text = "Agent Name : " + lblAgntNameVal.Text;
                                //mdlpopup.Show();
                                if (Request.QueryString["MvmtRule"] != null)
                                {
                                    if (Request.QueryString["MvmtRule"].ToString().Trim() != "")
                                    {
                                        htParam.Clear();
                                        htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
                                        htParam.Add("@UserID", Session["UserID"].ToString().Trim());
                                        htParam.Add("@MvmtTyp", "TR");
                                        htParam.Add("@AgentType", Request.QueryString["MvmtRule"].ToString().Trim());
                                        htParam.Add("@Flag", "2");
                                        dsResult = objDAC.GetDataSetForPrc("PrcMemberTypDtls", htParam);
                                        if (dsResult.Tables.Count > 0)
                                        {
                                            if (dsResult.Tables.Count > 0)
                                            {
                                                lblMessage.Text = "Termination request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
                                                lbl3.Text = "Termination request is " + dsResult.Tables[0].Rows[0]["SystemStatus"].ToString().Trim();
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


                                //lbl_popup.Text = "Termination Approved Succesfully<br /><br />Agent Code : " + lblAgtCodeVal.Text + "<br /><br />Agent Name : " + lblAgntNameVal.Text;
                                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                btnApprove.Enabled = false;
                                btnReject.Enabled = false;
                                //Mail(lblAgtCodeVal.Text.ToString().Trim());
                            }
                            else
                            {
                                if (flag == "R")
                                {
                                    //lbl3.Text = "Termination Rejected Succesfully";
                                    //lbl4.Text = "Agent Code : " + lblAgtCodeVal.Text;
                                    //lbl5.Text = "Agent Name : " + lblAgntNameVal.Text;
                                    //mdlpopup.Show();
                                    lbl_popup.Text = "Termination Rejected Succesfully<br /><br />Agent Code : " + lblAgtCodeVal.Text + "<br /><br />Agent Name : " + lblAgntNameVal.Text;
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                                    btnApprove.Enabled = false;
                                    btnReject.Enabled = false;
                                }
                            }
                            
                            //else
                            //{
                            //    lblMessage.Text = "Error Updating Agent Termination Details!";
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "startupScript", "<script language='JavaScript'>alert('" + lblMessage.Text + "');</script>", false);
                            //}

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
                        #endregion
                    }
                }
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
            htParam.Add("@AgentType", strAgentType);
            htParam.Add("@BizSrc", strBizSrc);
            htParam.Add("@ChnCls", strChnCls);
            htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetCrntAddlMngrgrdDtls_PrmDmt", htParam);

            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                gv_RptMngr.DataSource = dsRpt.Tables[0];
                gv_RptMngr.DataBind();
                bindCrntAddlMngrGridData(dsRpt);
            }
            else
            {
                gv_RptMngr.DataSource = null;
                gv_RptMngr.DataBind();
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
            gv_RptMngr.HeaderRow.Visible = false;
            for (int i = 0; gv_RptMngr.Rows.Count > i; i++)
            {

                Label lblCrntAdlRptTyp = (Label)gv_RptMngr.Rows[i].FindControl("lblAdlRptType");
                lblCrntAdlRptTyp.Text = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

                Label lblCrtAdlBsdOn = (Label)gv_RptMngr.Rows[i].FindControl("lblAdlBsdOn");
                lblCrtAdlBsdOn.Text = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

                Label lblCrntAdlChn = (Label)gv_RptMngr.Rows[i].FindControl("lblAdlChnl");
                lblCrntAdlChn.Text = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

                Label lblCrntAdlSChn = (Label)gv_RptMngr.Rows[i].FindControl("lblAdlSChnl");
                lblCrntAdlSChn.Text = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

                Label lblCrntAdlAgtTyp = (Label)gv_RptMngr.Rows[i].FindControl("lblAdlMemType");
                lblCrntAdlAgtTyp.Text = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString();

                Label lblCrntRptMngr = (Label)gv_RptMngr.Rows[i].FindControl("lblRptMngr");
                lblCrntRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();

                if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
                {
                    lblRptMngrErr.Visible = false;
                    lblRptMngrErr.Text = "";
                    lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
                    lbladditionalreportingrule.Visible = true;
                }
                else
                {
                    lblRptMngrErr.Visible = true;
                    lblRptMngrErr.Text = "No Records Exists";
                    lbladditionalreportingrule.Text = "";
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

    #region gv_RptMngr_RowDataBound
    protected void gv_RptMngr_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label ddlventype = (Label)e.Row.FindControl("ddlventype");
            Label ddlRelModel = (Label)e.Row.FindControl("ddlRelModel");
            Label ddlAdlRptTyp = (Label)e.Row.FindControl("ddlAdlRptTyp");
            Label ddlAdlBsdOn = (Label)e.Row.FindControl("ddlAdlBsdOn");
            Label ddlAdlChn = (Label)e.Row.FindControl("ddlAdlChn");
            Label ddlAdlSChn = (Label)e.Row.FindControl("ddlAdlSChn");
            Label ddlAdlAgtTyp = (Label)e.Row.FindControl("ddlAdlAgtTyp");

        }
    }
    #endregion

    #region lnkRptMngr_Click
    protected void lnkRptMngr_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkRptMngr = (LinkButton)grd.FindControl("lnkRptMngr");
        DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
        DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
        DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
        DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
        DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
        TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
        string strRowID = ((System.Web.UI.Control)(grd)).ClientID.ToString();

        if (Request.QueryString["Ctgry"] != null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
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
            ddl.Items.Insert(0, new ListItem("Select", ""));
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
            ddl.Items.Insert(0, new ListItem("Select", ""));
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
            htparam.Add("@BizSrc", lblSlsChannelVal.Text);
            htparam.Add("@ChnCls", lblChnClsVal.Text);
            htparam.Add("@MemType", lblAgntTypeVal.Text);
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
            ddl.Items.Insert(0, new ListItem("Select", ""));
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

    private void Mail(string MemCode)
    {

        //MAIL Communication integration
        string strUserID = Session["UserID"].ToString();
        Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        ds.Clear();
        htData.Add("@AppFlag", "CHMS");
        htData.Add("@Param1", "MVMT");
        htData.Add("@Param2", "MEMTRM");
        htData.Add("@Param3", "EMPTRM");
        ds = objDAC.GetDataSetForMailPrc("Prc_GetMailParams_CHMS", htData);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                    //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    objmailcomm.SendNoticationMailSMS("CHMS", "MVMT", "MEMTRM", "EMPTRM", "", "", NotifyTo, MemCode.ToString().Trim(), HttpContext.Current.Session["UserID"].ToString());
                }
            }
        }
        //MAIL
    }

    //added by amruta for chms upgrade on 30/6/16 start
    #region Tab lnkHierarchy_Clicr Click EVENT
    protected void lnkHierarchy_Click(object sender, EventArgs e)
    {
        divHirarchyDtlsHdr.Attributes.Add("style", "display:block");
        divprirepHdr.Attributes.Add("style", "display:none");
        divMngrDtlsHdr.Attributes.Add("style", "display:none");
        divCrntDownLinesHdr.Attributes.Add("style", "display:none");
        divuntcodeHdr.Visible = false;
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
        divHirarchyDtlsHdr.Attributes.Add("style", "display:none");
        divprirepHdr.Attributes.Add("style", "display:block");
        divMngrDtlsHdr.Attributes.Add("style", "display:none");
        divCrntDownLinesHdr.Attributes.Add("style", "display:none");
        divuntcodeHdr.Visible = true;
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
        divHirarchyDtlsHdr.Attributes.Add("style", "display:none");
        divprirepHdr.Attributes.Add("style", "display:none");
        divMngrDtlsHdr.Attributes.Add("style", "display:block");
        divCrntDownLinesHdr.Attributes.Add("style", "display:none");
        divuntcodeHdr.Visible = false;
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
        divHirarchyDtlsHdr.Attributes.Add("style", "display:none");
        divprirepHdr.Attributes.Add("style", "display:none");
        divMngrDtlsHdr.Attributes.Add("style", "display:none");
        divCrntDownLinesHdr.Attributes.Add("style", "display:block");
        divuntcodeHdr.Visible = false;
        hdnTab.Value = "4";
        lnkHierarchy.CssClass = "btn btn-default";
        lnkprimary.CssClass = "btn btn-default";
        lnkadditional.CssClass = "btn btn-default";
        lnkDownlines.CssClass = "btn-subtab btn btn-default";
    }
    #endregion
    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv_TrfDownlines.DataSource = source;
        gv_TrfDownlines.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv_TrfDownlines.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv_TrfDownlines.Rows[0].Cells[columnsCount - 1].Text = "";
        gv_TrfDownlines.Rows[0].Cells[columnsCount - 2].Text = "";
        gv_TrfDownlines.Rows[0].Cells[0].Text = "No Downlines Found";
        source.Rows.Clear();
    }
    //added by amruta for chms upgrade on 30/6/16 end
    protected void btnok_Click(object sender, EventArgs e)
    {
        //Comented by usha on 16.02.2018
        //htParam.Clear();
        //htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
        //if (lblMessage.Text == "There are downlines under this member(unit manager). Click OK to transfer the downlines to position.")
        //{
        //    htParam.Add("@flag", "2");
        //}
        //else
        //{
        //    htParam.Add("@flag", "1");
        //}
        //for (int intRowCount = 0; intRowCount <= gv_TrfDownlines.Rows.Count - 1; intRowCount++)
        //{
        //    Label Memcode = (Label)gv_TrfDownlines.Rows[intRowCount].Cells[1].FindControl("lblMemCode");
        //    htParam.Add("@MemCodeTrm", Memcode.Text.Trim());
        //    dsResult = objDAC.GetDataSetForPrc("Prc_MoveMember", htParam);
        //}
        //btnTerminate.Enabled = false;
        //lbl3.Text = "Termination done successfully";
        //btnok.Visible = false;
        //mdlpopup.Show();
        //Comented by usha on 16.02.2018
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        mdlpopup.Hide();
    }
}
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using System.Data;
using INSCL.DAL;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Application_INSC_ChannelMgmt_MemberReinstate : BaseClass
{
    ///<summary>
    ///Created by Parag @ 18022014- Handle All Agent Reinstatement Requests.
    /// </summary>

    #region Global Declarations
    ErrLog objErr = new ErrLog();
    DataAccessClass objDAC = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    private multilingualManager m_olng;
    private multilingualManager m_olng2;
    clsAgent Agnet = new clsAgent();
    SqlDataReader dtRead;
    DataSet dsResult = new DataSet();
    private const string c_strBlank = "-- Select --";
    private string m_strUserLang, m_strMgrCode, m_strUnitCode, m_strDirectAgtCode, m_strAgentStatus, m_strAgentTypeAddl;
    string strBizSrc, strBizSrcDesc, strChnCls, strAgentType;
    string strAddl1MgrCode, strAddl2MgrCode, strAddl3MgrCode, strPositionStatus, strMgrCurrentUnit;
    private int m_counter = -1;
    private string strFlag = string.Empty;
    private string strMvmtCode = string.Empty;
    private Boolean IsUntCodeCalled = false;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        Hierarchy.CssClass = "btn-subtab btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";

        HierarchyDtl.Style.Add("display", "block");
        PrimaryDtl.Style.Add("display", "none");
        AdditionalDtl.Style.Add("display", "none");



        //HierarchyDemo.Style.Add("display", "block");
        //AdditionalDemo.Style.Add("display", "none");
        //PrimaryDemo.Style.Add("display", "none");

        //HierarchyNew.CssClass = "btn-subtab btn btn-default";
        //PrimaryNew.CssClass = "btn btn-default";
        //AdditionalNew.CssClass = "btn btn-default";



        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        { Response.Redirect("~/ErrorSession.aspx"); }
        if (Request.QueryString["flag"] != null)
        {
            strFlag = Request.QueryString["flag"].ToString().Trim();
            strMvmtCode = Request.QueryString["MvmtCd"].ToString().Trim();
        }

        m_strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        m_olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", m_strUserLang);
        if (Request.QueryString["Ctgry"] != null)
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

        ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();
        m_strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        m_olng2 = new multilingualManager("DefaultConn", "MemberReinstate.aspx", m_strUserLang);
        Session["CarrierCode"] = '2';
        Session["m_counter"] = String.Empty;

        lblNewUntAddr.Text = hdnNewUntAddr.Value;
        //Preselect the First Section

        //Agent Category
        lblAgntClassVal.Visible = true;
        lblAgntClassVal.Enabled = true;
        lblAgntClassVal.Text = "STAFF";

        //End
        if (!IsPostBack)
        {

            HierarchyDemo.Style.Add("display", "block");
            AdditionalDemo.Style.Add("display", "none");
            PrimaryDemo.Style.Add("display", "none");

            HierarchyNew.CssClass = "btn-subtab btn btn-default";
            PrimaryNew.CssClass = "btn btn-default";
            AdditionalNew.CssClass = "btn btn-default";

            //MultiViewCrnt.ActiveViewIndex = 0;
            lnkCrntHier.BackColor = Color.Transparent;
            lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
            lblrptmgr.Text = hdnPrmyRptMgr.Value;

            //Preselect the first Section
            //MVNewDtls.ActiveViewIndex = 0;
            lnkCrntHierNew.BackColor = Color.Transparent;
            lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

            InitializeControl();
            fillAgtDtls();
            FillRequiredDataForPage1();
            setManagerDetails();

            FillNewHierarchyDetails();

            ddlAgntClass.Enabled = false;
            ddlAgntType.Enabled = false;

            ddlambasedondesc.Enabled = false;
            ddlamchnldesc.Enabled = false;
            ddlamrptdesc.Enabled = false;
            ddlamsubchnldesc.Enabled = false;
            ddlChnCls.Enabled = false;
            ///ddllvlagttype.Enabled = false;
            ddlSlsChannel.Enabled = false;

            if (strFlag == "A")
            {
                GetDataFromTransaction();
                GetDataForRemark();

                btnReinstate.Visible = false;
                //btnApprove.Visible = true;
                // btnReject.Visible = true;
                txtHierarchy.Enabled = false;
                txtUnitCode.Enabled = false;
                txtNewUnitDesc.Enabled = false;
                txtRptMgr.Enabled = false;
                txtRemarks.Disabled = true;
                ddllvlagttype.Enabled = false;

            }
            else
            {
                ChkMandMgr(true);
            }
        }
        if (lbladditionalreportingrule.Text.Trim() != "")
        {
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                {
                    funShowCrntMgr("empty");
                }
                else
                {
                    funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                }
            }
            else
            {
                funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
            }
        }
        Hashtable htParam = new Hashtable();
        DataSet dsRpt = new DataSet();
        htParam.Clear();
        dsRpt.Clear();
        htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
        dsRpt = objDAC.GetDataSetForPrc("Prc_getAgnDtls", htParam);
        if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
        {
            strBizSrc = Convert.ToString(dsRpt.Tables[0].Rows[0]["BizSrc"]);
            strChnCls = Convert.ToString(dsRpt.Tables[0].Rows[0]["ChnCls"]);
            strAgentType = Convert.ToString(dsRpt.Tables[0].Rows[0]["MemType"]);
        }

        htParam.Clear();
        dsRpt.Clear();
        htParam.Add("@AgentType", strAgentType);
        htParam.Add("@BizSrc", strBizSrc);
        htParam.Add("@ChnCls", strChnCls);
        dsRpt = objDAC.GetDataSetForPrc("prc_GetMovementStatus", htParam);
        if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
        {
            int Status = Convert.ToInt16(dsRpt.Tables[0].Rows[0]["IsMvmtReInst"]);
            if (Status == 0)
            {
                lbl3.Text = "Reinstatement Denied!";
                lbl3.Font.Bold = true;
                lbl4.Text = "This Member Cannot Be Reinstated! Please refer to its Member type setup for more information...";
                lbl3.Font.Bold = true;
                lbl5.Text = String.Empty;
                lbl5.Font.Bold = false;

                //Display Box
                mdlpopup.Show();
                btnReinstate.Enabled = false;
            }
        }
        //btnReinstate.Attributes.Add("onClick", "javascript: return funValidate();");
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
                hdnAgntTyp.Value = dsagt.Tables[0].Rows[0]["MemType"].ToString().Trim();
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
        //Section Reinsatement
        lblReinstatementDateTtl.Text = m_olng2.GetItemDesc("lblReinstatementDateTtl");
        lblReinstatementSectionTitle.Text = m_olng2.GetItemDesc("lblReinstatementSectionTitle");
        lblMemberReinstateReason.Text = m_olng2.GetItemDesc("lblMemberReinstateReason");
        lblRemarks.Text = m_olng2.GetItemDesc("lblRemarks");
    }
    #endregion

    #region btnReinstate_Click
    protected void btnReinstate_Click(object sender, EventArgs e)
    {
        string tempUnitCode = String.Empty;
        setManagerDetails();
        try
        {
            //Validate the ReinstateReason field
            if (ddlMemberReinstateReason.SelectedIndex == 0 && txtRemarks.Value.Length != 0)
            {
                lbl3.Text = "Could not proceed for Reinstatement.";
                lbl3.Font.Bold = false;
                lbl4.Text = "Select the Reason to Reinstate!";
                lbl3.Font.Bold = false;
                lbl5.Text = String.Empty;
                lbl5.Font.Bold = false;

                //Display Box
                mdlpopup.Show();
                ddlMemberReinstateReason.Focus();
            }
            else if (txtRemarks.Value.Length == 0 && ddlMemberReinstateReason.SelectedIndex > 0)
            {
                lbl3.Text = "Could not proceed for Reinstatement.";
                lbl3.Font.Bold = false;
                lbl4.Text = "Describe the reason for Reinstatement!";
                lbl3.Font.Bold = false;
                lbl5.Text = String.Empty;
                lbl5.Font.Bold = false;

                //Display Box
                mdlpopup.Show();
                txtRemarks.Focus();
            }
            else if (ddlMemberReinstateReason.SelectedIndex == 0 && txtRemarks.Value.Length == 0)
            {
                lbl3.Text = "Could not proceed for Reinstatement.";
                lbl3.Font.Bold = false;
                lbl4.Text = "Mandatory Fields needed to be filled before Movement.";
                lbl3.Font.Bold = false;
                lbl5.Text = String.Empty;
                lbl5.Font.Bold = false;

                //Display Box
                mdlpopup.Show();
            }
            //Update the Agent's Status as PeNding
            else
            {
                ////ChkMandMgr(false);
                if (hdnPriMandatory.Value.ToString() == "True")
                {
                    if (txtRptMgr.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Primary Manager');</script>", false);
                        return;
                    }
                }

                //Get the remarks - Can be Blank
                String strlblRemark = Convert.ToString(txtRemarks.Value);

                htParam.Clear();
                //Data from Reinstate Tab
                htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
                htParam.Add("@AgentCode", lblAgtCodeVal.Text);
                htParam.Add("@AgentType", ddlAgntType.SelectedValue.ToString().Trim());
                htParam.Add("@ReInstateReason", ddlMemberReinstateReason.SelectedValue.ToString());
                htParam.Add("@UpdateBy", Session["UserID"].ToString().Trim());
                htParam.Add("@Remark", strlblRemark.Trim());

                //Primary Manager Code
                if (m_strMgrCode == String.Empty || m_strMgrCode == null)
                { htParam.Add("@PrimaryMgrCode", Convert.ToString(System.DBNull.Value)); }
                else
                {
                    
                  //  htParam.Add("@PrimaryMgrCode", hdnPrmyRptMgr.Value);
                    htParam.Add("@PrimaryMgrCode", txtRptMgr.Text);
                
                }

                //UnitCode
                htParam.Add("@OldUnitCode", lblUntDr.Text.Trim());
                htParam.Add("@UnitCode", lblNewUnitCode.Text.Trim());

                //Other Parameters
                if (m_strDirectAgtCode == String.Empty || m_strDirectAgtCode == null)
                { htParam.Add("@Directagncode", Convert.ToString(System.DBNull.Value)); }
                else
                { htParam.Add("@Directagncode", m_strDirectAgtCode); }
                htParam.Add("@Flag", 1);
                htParam.Add("@RelOrder", m_counter);

                //To name the entry
                htParam.Add("@CreatedBy", Session["UserID"].ToString());

                //Execute!
                dsResult = objDAC.GetDataSetForPrcCLP("[Prc_MemberReInstate]", htParam);

                if (dsResult.Tables[1].Rows.Count > 0)
                {
                    if (dsResult.Tables[1].Rows[0]["MessageText"].ToString() != null)
                    {
                        string strMessage = dsResult.Tables[1].Rows[0]["MessageText"].ToString().Trim();
                        //string strName = dsResult.Tables[0].Rows[0]["CounterNo"].ToString().Trim();
                        InsReinsDtlsOld(0);

                        for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
                        {
                            Label lblNo = gv_RptMngr_Crnt.Rows[i].FindControl("lblNo") as Label;
                            InsReinsDtlsOld(Convert.ToInt32(lblNo.Text.Trim()));
                        }

                      //  InsReinsDtls(0, ddlamrptdesc.SelectedValue, ddlamchnldesc.SelectedValue, ddlamsubchnldesc.SelectedValue, ddllvlagttype.SelectedValue, hdnPrmyRptMgr.Value);

                        InsReinsDtls(0, ddlamrptdesc.SelectedValue, ddlamchnldesc.SelectedValue, ddlamsubchnldesc.SelectedValue, ddllvlagttype.SelectedValue, txtRptMgr.Text);
                       
                      for (int i = 0; gv_RptMngr_new.Rows.Count > i; i++)
                        {
                            Label lblNo = gv_RptMngr_new.Rows[i].FindControl("lblNo") as Label;
                            DropDownList ddlAdlRptTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                            DropDownList ddlAdlChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                            DropDownList ddlAdlSChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                            DropDownList ddlAdlAgtTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
                            HiddenField hdnAddlRptMgr = gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;

                            InsReinsDtls(Convert.ToInt32(lblNo.Text.Trim()), ddlAdlRptTyp.SelectedValue, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlAdlAgtTyp.SelectedValue, hdnAddlRptMgr.Value);
                        }

                         

                        mdlpopup.Show();
                        btnCancel.Focus();
                        lbl3.Text = strMessage;
                        lbl3.Font.Bold = false;
                        lbl4.Text = "Agent Name = " + lblAgntNameVal.Text;
                        lbl3.Font.Bold = false;
                        lbl5.Text = "Agent Code = " + lblAgtCodeVal.Text;
                        lbl5.Font.Bold = false;
                        disableFieldsAfterMovement();
                        //Show modal Popup
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        // mdlpopup.Show();
                        btnReinstate.Enabled = false;
                    }
                }
                else if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["MessageText"].ToString() != null)
                    {
                        string strMessage = dsResult.Tables[0].Rows[0]["MessageText"].ToString().Trim();
                        mdlpopup.Show();
                        btnCancel.Focus();
                        lbl3.Text = strMessage;
                        lbl3.Font.Bold = false;
                        lbl4.Text = String.Empty;
                        lbl3.Font.Bold = false;
                        lbl5.Text = String.Empty;
                        lbl5.Font.Bold = false;
                        disableFieldsAfterMovement();
                        //Show modal Popup
                        mdlpopup.Show();
                        btnReinstate.Enabled = false;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //Failure in Forwarding Request - prepare the prompt
            lbl3.Text = "The reinstatement request has failed!";
            lbl3.Font.Bold = false;
            lbl4.Text = "Retry again.";
            lbl3.Font.Bold = false;
            lbl5.Text = String.Empty;
            lbl5.Font.Bold = false;

            //Show modal Popup
            mdlpopup.Show();
            btnCancel.Focus();

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    #endregion

    #region InsReinsDtlsOld
    public void InsReinsDtlsOld(int relorder)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();
            String strlblRemark = Convert.ToString(txtRemarks.Value);
            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htprm.Add("@AgentType", ddlAgntType.SelectedValue.ToString().Trim());
            htprm.Add("@AgentCode", lblAgtCodeVal.Text);
            htprm.Add("@CreatedBy", Session["UserID"].ToString().Trim());
            htprm.Add("@ReInstateReason", ddlMemberReinstateReason.SelectedValue.ToString());
            htprm.Add("@Remark", strlblRemark.Trim());
            htprm.Add("@relorder", relorder);
            dsprm = objDAC.GetDataSetForPrc("Prc_Reins_InsAgtOldRptMgrDtls", htprm);
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

    #region InsReinsDtls
    public void InsReinsDtls(int relorder, string reltyp, string RelBizsrc, string RelChnCls, string RelAgenttype, string RelAgentcode)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();
            String strlblRemark = Convert.ToString(txtRemarks.Value);
            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htprm.Add("@BizSrc ", hdnBizsrc.Value);
            htprm.Add("@ChnSubCls", hdnChncls.Value);
            htprm.Add("@AgentType", hdnAgntTyp.Value);
            htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
            //htprm.Add("@UnitCode ", hdnUntCode.Value);
            htprm.Add("@UnitCode ", lblNewUnitCode.Text);
            
            htprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            htprm.Add("@relorder", relorder);
            htprm.Add("@reltyp", reltyp);
            htprm.Add("@RelBizsrc", RelBizsrc);
            htprm.Add("@RelChnCls", RelChnCls);
            htprm.Add("@RelAgenttype", RelAgenttype);
            htprm.Add("@RelAgentcode", RelAgentcode);
            htprm.Add("@ReInstateReason", ddlMemberReinstateReason.SelectedValue.ToString());
            htprm.Add("@Remark", strlblRemark.Trim());
            dsprm = objDAC.GetDataSetForPrc("Prc_Reins_InsAgtNewRptMgrDtls", htprm);
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
        if (strFlag != "A")
        {
            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp" && Request.QueryString["Type"].ToString() == "E")
                    Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString());
            }
            else
            { Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + Request.QueryString["Type"].ToString()); }
        }
        else
        {
            if (Request.QueryString["Type"].ToString() == "E")
                Response.Redirect("MemMvmtappr.aspx?Role=Emp");
            else
                Response.Redirect("MemMvmtappr.aspx?Role=Agt");
        }

    }
    #endregion

    #region FillRequiredDataForPage1
    protected void FillRequiredDataForPage1()
    {
        lblReinstatementDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
        oCommon.getDropDown(ddlMemberReinstateReason, "RIReason", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        ddlMemberReinstateReason.Items.Insert(0, new ListItem("-- Select --", ""));

        dsResult = new DataSet();
        htParam.Clear();
        htParam.Add("@AgentCode", Convert.ToString(Request.QueryString["AgnCd"].ToString().Trim()));
        try
        {
            dsResult = objDAC.GetDataSetForPrcCLP("Prc_GetAgentWholeDtls", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["ChannelType"].ToString().Trim() == "O")
                    {
                        rdbChnlTyp.Text = "0";
                    }
                    else
                    {
                        rdbChnlTyp.Text = "1";
                    }

                    DataSet dsResultTemp = new DataSet();
                    lblUntDr.Text = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
                    txtUnitCode.Text = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString().Trim() + " " + "(" + dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString().Trim() + ")";
                    //lblUntcd.Text =   dsResult.Tables[0].Rows[0]["UntCms"].ToString().Trim();
                    lblUntAddr.Text = dsResult.Tables[0].Rows[0]["UnitAdr"].ToString().Trim();
                    lblSlsChannelVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblChnClsVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnClsDesc"]);
                    lblchanneldescVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblAgtCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]);
                    lblCusmIdVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]);
                    lblCltCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]).ToUpper();
                    lblGenderVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]).ToUpper();
                    strBizSrc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    strChnCls = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                    strBizSrcDesc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblRptMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PrmyAgtName"]);
                    hdnRptMgr.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["PrmyAgtCode"]);
                    ViewState["strOldPrmyMgrCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["PrmyAgtCode"]);
                    ViewState["strOldAddl1MgrCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1AgtCode"]);
                    ViewState["strOldAddl2MgrCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2AgtCode"]);
                    ViewState["strOldAddl3MgrCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl3AgtCode"]);
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblAgntTypeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentTypeDesc"]);
                    strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
                    m_strAgentStatus = Convert.ToString(dsResult.Tables[0].Rows[0]["MemStatus"]).Trim();
                    lblAgntStatusVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgtStatusDesc"]).Trim().ToUpper();
                    Session["strPriRptMgrType"] = dsResult.Tables[0].Rows[0]["PrmyAgtType"].ToString().Trim();
                    Session["strAddlRptType1"] = dsResult.Tables[0].Rows[0]["Addl1AgtType"].ToString().Trim();
                    Session["strAddlRptType2"] = dsResult.Tables[0].Rows[0]["Addl2AgtType"].ToString().Trim();
                    Session["strAddlRptType3"] = dsResult.Tables[0].Rows[0]["Addl3AgtType"].ToString().Trim();
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    FillReportingMngrDtls();

                    Img.Visible = false;
                    DataSet dsImg = BindGrid();
                    GridImage.DataSource = dsImg;
                    GridImage.DataBind();
                }
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
    #endregion

    #region FillReportingMngrDtls
    protected void FillReportingMngrDtls()
    {
        try
        {
            fillAddlRptMngrDtls();

            Hashtable htParam = new Hashtable();
            Hashtable htParam2 = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            htParam.Add("@AgentType", strAgentType);
            htParam.Add("@BizSrc", strBizSrc);
            htParam.Add("@ChnCls", strChnCls);
            htParam.Add("@MgrCode", hdnRptMgr.Value.ToString());
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    lblprimrepoVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryRpTyp"].ToString();
                    lblbasedondescVal.Text = dsRpt.Tables[0].Rows[0]["BasedOn"].ToString();
                    lblsubchnldescVal.Text = dsRpt.Tables[0].Rows[0]["PrimarySubChnl"].ToString();
                    lbllvlagtVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryAgtOrLevelType"].ToString();
                    Session["strPriRptMgrType"] = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString();//----This gets the Manager AgentType 


                    funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    //ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);


                    Session["strPrimaryReportingType"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["PrimaryReportingType"]);
                    Session["strPrimaryChannel"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["PrimaryChannel"]);
                    Session["strPrimarySubChannel"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["PrimarySubChannel"]);
                    Session["strPositionStatus"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["MgrStatus"]);
                    Session["strMgrCurrentUnit"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["MgrCurrentUnitCode"]);

                    Session["strPrimBasedOn"] = Convert.ToString(dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"]);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
                }
            }
            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "javascript", "<script type='text/javascript'>AssigText('empty');</script>", false);
            }

            string tmpType = Convert.ToString(Request.QueryString["Type"]);
            //btnEditUnitCode.Attributes.Add("OnClick", "javascript:return fununtpopup('untcode','" + tmpType + "','Agent','" + strBizSrc + "','" + strChnCls + "','" + strAgentType + "');");
            if (Request.QueryString["Role"] != null && Request.QueryString["Role"].ToString().Trim() == "E")
            {
                btnUnitCode.Attributes.Add("OnClick", "javascript:return fununtpopup('untcode','" + tmpType + "','Emp','" + strBizSrc + "','" + strChnCls + "','" + strAgentType + "');");
            }
            else
            {
                btnUnitCode.Attributes.Add("OnClick", "javascript:return fununtpopup('untcode','" + tmpType + "','Agent','" + strBizSrc + "','" + strChnCls + "','" + strAgentType + "');");
            }
            ChkMandMgr(false);
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

    #region BindGrid
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
    #endregion

    #region setManagerDetails
    protected void setManagerDetails()
    {

        DataSet ds = new DataSet();
        Hashtable htbl = new Hashtable();
        //This function attaches the Popup Manager to open function to the buttons referenced below.

        //Set the Primary Manager
        btnRptMgr.Enabled = true;
        //Set the Attributes of the remaining additional managers

        try
        {
            //Set the Values of the NEW Primary and the additional managers
            if (txtRptMgr.Text != String.Empty)
            {
                m_counter = 0;
                m_strMgrCode = lblRepMgr.Text.ToString();
            }
            Session["m_counter"] = m_counter;
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

    #region lnkCrntPrimMgr_Click
    protected void lnkCrntPrimMgr_Click(object sender, ImageClickEventArgs e)
    {
        // MultiViewCrnt.ActiveViewIndex = 1;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region lnkCrntAddlMgr_Click
    protected void lnkCrntAddlMgr_Click(object sender, ImageClickEventArgs e)
    {
        //  MultiViewCrnt.ActiveViewIndex = 2;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";

    }
    #endregion

    #region lnkCrntHier_Click
    protected void lnkCrntHier_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 0;

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";

    }
    #endregion

    //--New Details
    #region lnkCrntHierNew_Click
    protected void lnkCrntHierNew_Click(object sender, ImageClickEventArgs e)
    {
        //MVNewDtls.ActiveViewIndex = 0;
        lblNewUnitCode.Text = hdnUntCode.Value;
        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        lnkCrntAddlMgrNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";

    }
    #endregion

    #region lnkCrntPrimMgrNew_Click
    protected void lnkCrntPrimMgrNew_Click(object sender, ImageClickEventArgs e)
    {
        //  MVNewDtls.ActiveViewIndex = 1;
        lblNewUnitCode.Text = hdnUntCode.Value;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        lnkCrntAddlMgrNew.BackColor = Color.Transparent;

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region lnkCrntAddlMgrNew_Click
    protected void lnkCrntAddlMgrNew_Click(object sender, ImageClickEventArgs e)
    {
        //MVNewDtls.ActiveViewIndex = 2;
        lblNewUnitCode.Text = hdnUntCode.Value;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        lnkCrntAddlMgrNew.BackColor = Color.Transparent;

        lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
    }
    #endregion

    #region funShowCrntMgr
    public void funShowCrntMgr(string str)
    {
        try
        {

            if (str == "empty")
            {
                //tblReportingMngrDtls.Visible = false;
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
        FillMgrDetails();
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
            htparam.Add("@CarrierCode", 2);
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
            ddlChnCls.Enabled = true;
            if (ddlSlsChannel.SelectedIndex == 0)
            {
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChannel.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlAgntType.Items.Clear();
                ddlAgntType.DataSource = null;
                ddlAgntType.DataBind();
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                //tblReportingMngrDtls.Visible = false;
                //tblUnitCodeDetails.Visible = false;
            }
            ddlSlsChannel.Focus();
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
        //txtRptMgr.Text = "";
        //hdnRptMgr.Value = "";
        //lblrptmgr.Text = "";
        //txtNewUntCode.Text = "";
        //lblNwUntcd.Text = "";
        //hdnNewUntAdr.Value = "";
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
                if (Request.QueryString["Ctgry"] != null)
                {
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Emp")
                    {
                        oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "E");
                    }
                    if (Request.QueryString["Ctgry"].ToString().Trim() == "Ven")
                    {
                        oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, Session["UserID"].ToString(), "V");
                    }
                }
                else
                {
                    oCommonU.GetAgentTypeForSlsChnnl(ddlAgntType, ddlSlsChannel.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue);
                }
            }
            ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
            if (ddlChnCls.SelectedIndex == 0)
            {
                ddlAgntType.Items.Clear();
                ddlAgntType.DataSource = null;
                ddlAgntType.DataBind();
                ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
                //tblReportingMngrDtls.Visible = false;
                //tblUnitCodeDetails.Visible = false;
            }
            ddlChnCls.Focus();
            ddlAgntType.Enabled = true;
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
        //txtRptMgr.Text = "";
        //hdnRptMgr.Value = "";
        //lblrptmgr.Text = "";
        //txtNewUntCode.Text = "";
        //lblNwUntcd.Text = "";
        //hdnNewUntAdr.Value = "";
        ///hdnUntCode.Value = null;
        #endregion


    }
    #endregion

    #region FillMgrDetails
    protected void FillMgrDetails()
    {
        try
        {
            fillNewAddlRptMngrDtls();

            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            //if (Request.QueryString["Type"] != "E")
            //{

            htParam.Add("@AgentType", ddlAgntType.SelectedValue);
            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
            htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);
            //}
            //Assign values to labels

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    FillReportingMngrddl();

                    string PrmyRptType = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                    ddllvlagttype.Enabled = true;
                    ///setAgtType(PrmyRptType, ddllvlagttype);
                    ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                    //modified by akshay on 140214 start
                    ddlamrptdesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();

                    ddlambasedondesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString();

                    FillReportingMngrchnl();

                    ddlamchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();

                    FillReportingMngrsubchnl();

                    ddlamsubchnldesc.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                    FillReportingMngrAgttype();
                    hdnRptSetup.Value = PrmyRptType.Trim();
                    ////ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString();
                    if (Request.QueryString["Type"] != null)
                    {
                        if (PrmyRptType == "E" && ddlambasedondesc.SelectedValue == "1")
                        {
                            ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                            hdnPriMemTyp.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
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
                        }
                    }

                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();
                    ////lblNwaddtnlreptrule.Text = strAddreportingRule;

                    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                    {
                        lblRptMngrErr.Visible = false;
                        lblRptMngrErr.Text = "";

                        lblNwaddtnlreptrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();
                        GetManagers();
                        //GetAddlManagers();

                    }
                    else
                    {
                        lblRptRulErr.Visible = true;
                        lblRptRulErr.Text = "No Record(s) Exists";
                        lbladditionalreportingrule.Text = "";
                        GetManagers();
                    }
                    ///ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
                    //funShowCrntMgr(lblNwaddtnlreptrule.Text, tblAddlM1, tblAddlM2, tblAddlM3, tblNewRptDtls, ddlam1rptdesc.SelectedValue.ToString(), ddlam2rptdesc.SelectedValue.ToString(), ddlam3rptdesc.SelectedValue.ToString());
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
                        //txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                        ///lbpri.Visible = true;
                    }
                }
            }
            #endregion
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

            oCommon.getDropDown(ddlambasedondesc, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            ddlambasedondesc.Items.Insert(0, new ListItem("-- Select --", ""));

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
            funagttyppopup(ddllvlagttype, ddlambasedondesc.SelectedValue.ToString().Trim(), "0");

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

    //#region funagttyppopup
    //protected void funagttyppopup(DropDownList ddl, string txtchn, string txtsubchn, string txtbsdon)
    //{
    //    try
    //    {
    //        ddl.Items.Clear();
    //        SqlDataReader dtRead;
    //        Hashtable htparam = new Hashtable();
    //        htparam.Clear();
    //        htparam.Add("@chnl", txtchn.Trim());
    //        htparam.Add("@subchnl", txtsubchn.Trim());
    //        htparam.Add("@BsdOn", txtbsdon.Trim());
    //        dtRead = objDAC.Common_exec_reader_prc("Prc_ddlmgragttyp", htparam);
    //        if (dtRead.HasRows)
    //        {
    //            ddl.DataSource = dtRead;
    //            ddl.DataTextField = "MemTypeDesc01";
    //            ddl.DataValueField = "MemType";
    //            ddl.DataBind();
    //        }
    //        dtRead = null;
    //        ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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
    //#endregion

    #region GetManagers
    protected void GetManagers()
    {
        try
        {
            string strBizsrcmgr = ddlamchnldesc.SelectedValue.ToString();
            string strchnclsmgr = ddlamsubchnldesc.SelectedValue.ToString();
            string strbsdon = ddlambasedondesc.SelectedValue.ToString();
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].ToString().Trim() == "E")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + strBizsrcmgr.Trim() + "','" + strchnclsmgr.Trim() + "','" + hdnAgntTyp.Value.Trim() + "','" + ddllvlagttype.SelectedValue.Trim().ToString() + "','Emp','" + strbsdon.Trim() + "'");
                }
                else
                    if (Request.QueryString["Type"].ToString().Trim() == "A")
                    {
                        btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + strBizsrcmgr.Trim() + "','" + strchnclsmgr.Trim() + "','" + hdnAgntTyp.Value.Trim() + "','" + ddllvlagttype.SelectedValue.Trim().ToString() + "','','" + strbsdon.Trim() + "'");
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

    #region funShowCrntMgr
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
                tblmg2.Visible = false;
                tblmg3.Visible = false;
            }
            if (str == "Multiple-2")
            {
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

    #region btnRptMgr_Click
    protected void btnRptMgr_Click(object sender, EventArgs e)
    {
        //txtRptMgr.Text = String.Empty;
        string strBizsrcmgr = ddlamchnldesc.SelectedValue.ToString();
        string strchnclsmgr = ddlamsubchnldesc.SelectedValue.ToString();
        string strbsdon = ddlambasedondesc.SelectedValue.ToString();
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString().Trim() == "E")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "funcMgrShowPopup('rptmgr','" + strBizsrcmgr.Trim() + "','" + strchnclsmgr.Trim() + "','" + hdnAgntTyp.Value.Trim() + "','" + ddllvlagttype.SelectedValue.Trim().ToString() + "','Emp','" + strbsdon.Trim() + "')", true);
            }
            else
                if (Request.QueryString["Type"].ToString().Trim() == "A")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "funcMgrShowPopup('rptmgr','" + strBizsrcmgr.Trim() + "','" + strchnclsmgr.Trim() + "','" + hdnAgntTyp.Value.Trim() + "','" + ddllvlagttype.SelectedValue.Trim().ToString() + "','','" + strbsdon.Trim() + "')", true);
                }
        }

    }
    #endregion

    #region FillNewHierarchyDetails
    private void FillNewHierarchyDetails()
    {
        rblChnlType.SelectedValue = rdbChnlTyp.SelectedValue.ToString();
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
        ddlSlsChannel.SelectedValue = strBizSrc;
        GetSubChannels();

        ddlChnCls.SelectedValue = strChnCls;
        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));
        GetAgentTypes();
        ddlAgntType.SelectedValue = strAgentType.Trim();
        FillMgrDetails();
    }
    #endregion

    #region btnApprove_Click
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"]);
        htParam.Add("@MvmtCode", strMvmtCode);
        htParam.Add("@RelStatus", "New");
        htParam.Add("@CreateBy", Session["UserID"].ToString().Trim());
        dsResult = objDAC.GetDataSetForPrcCLP("Prc_InsRInsDataForAProval", htParam);
        lbl3.Text = "The reinstatement request has been Approved successfully.";
        lbl3.Font.Bold = true;
        lbl4.Text = "Employee Code:" + ViewState["vwsAgntCode"].ToString();
        lbl3.Font.Bold = false;
        lbl5.Text = "Channel:" + lblchanneldescVal.Text.Trim() + "<br/>Sub Class:" + lblsubchnldescVal.Text.Trim();
        lbl5.Font.Bold = false;

        //Show modal Popup
        mdlpopup.Show();
        //  btnApprove.Enabled = false;
        // btnReject.Enabled = false;
    }
    #endregion

    #region GetDataFromTransaction
    private void GetDataFromTransaction()
    {
        Hashtable htParam = new Hashtable();
        htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
        htParam.Add("@MvmtCode", strMvmtCode);
        htParam.Add("@RelStatus", "New");

        dsResult = null;
        dsResult = objDAC.GetDataSetForPrcCLP("Prc_GetRInDataForApproval", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            txtRptMgr.Text = dsResult.Tables[0].Rows[0]["PrmyAgentName"].ToString().Trim();
            lblrptmgr.Text = dsResult.Tables[0].Rows[0]["PrmyAgentCode"].ToString().Trim();
            hdnPrmyRptMgr.Value = dsResult.Tables[0].Rows[0]["PrmyAgentCode"].ToString().Trim();
            lblNewUnitCode.Text = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
            txtNewUnitDesc.Text = dsResult.Tables[0].Rows[0]["UnitName"].ToString().Trim();
            lblNewUntAddr.Text = dsResult.Tables[0].Rows[0]["UnitAddr"].ToString().Trim();
            hdnUntCode.Value = dsResult.Tables[0].Rows[0]["UnitCode"].ToString().Trim();
            txtNewUnitDesc.Enabled = false;
            txtRptMgr.Enabled = false;

        }
    }
    #endregion

    #region GetDataForRemark
    private void GetDataForRemark()
    {
        Hashtable htParam = new Hashtable();
        htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
        htParam.Add("@MvmtCode", strMvmtCode);
        htParam.Add("@RelStatus", "");

        dsResult = null;
        dsResult = objDAC.GetDataSetForPrcCLP("Prc_GetRInDataForApproval", htParam);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            oCommon.getDropDown(ddlMemberReinstateReason, "RIReason", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlMemberReinstateReason.Items.Insert(0, new ListItem("-- Select --", ""));

            ddlMemberReinstateReason.SelectedValue = dsResult.Tables[0].Rows[0]["ReinstateReason"].ToString().Trim();
            lblReinstatementDate.Text = dsResult.Tables[0].Rows[0]["EffDate"].ToString().Trim();
            txtRemarks.InnerText = dsResult.Tables[0].Rows[0]["Remark"].ToString().Trim();
            ddlMemberReinstateReason.Enabled = false;
        }
    }
    #endregion

    #region btnReject_Click
    protected void btnReject_Click(object sender, EventArgs e)
    {
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"]);
        htParam.Add("@MvmtCode", strMvmtCode);
        htParam.Add("@CreateBy", Session["UserID"].ToString().Trim());
        dsResult = objDAC.GetDataSetForPrcCLP("Prc_InsRInsDataForReject", htParam);
        lbl3.Text = "The reinstatement request has been Rejected successfully.";
        lbl3.Font.Bold = true;
        lbl4.Text = "Employee Code:" + ViewState["vwsAgntCode"].ToString();
        lbl3.Font.Bold = false;
        lbl5.Text = "Channel:" + lblchanneldescVal.Text.Trim() + "<br/>Sub Class:" + lblsubchnldescVal.Text.Trim();
        lbl5.Font.Bold = false;

        //Show modal Popup
        mdlpopup.Show();
        //  btnApprove.Enabled = false;
        // btnReject.Enabled = false;
    }
    #endregion

    #region Update for Control Disabled after movement
    protected void disableFieldsAfterMovement()
    {
        //Function to disable fields and buttons after movement success
        ddlMemberReinstateReason.Enabled = false;
        txtRemarks.Disabled = true;
        rblChnlType.Enabled = false;
        btnUnitCode.Enabled = false;
        btnRptMgr.Enabled = false;

    }
    #endregion

    #region ChkMandMgr
    protected void ChkMandMgr(Boolean bolToggle)
    {
        if (Request.QueryString["Type"] != null)
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsRpt = new DataSet();
                htParam.Clear();
                dsRpt.Clear();
                if (Request.QueryString["Type"] != "E")
                {
                    htParam.Add("@AgentType", ddlAgntType.SelectedValue);
                    htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                    htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                    dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);
                }
                else
                {
                    htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
                    htParam.Add("@AgentType", hdnAgntTyp.Value);
                    htParam.Add("@BizSrc", hdnBizsrc.Value);
                    htParam.Add("@ChnCls", hdnChncls.Value);
                    dsRpt = objDAC.GetDataSetForPrc("Prc_GetDataforRptmgr", htParam);
                }
                if (dsRpt.Tables.Count > 0)
                {
                    if (dsRpt.Tables[0].Rows.Count > 0)
                    {
                        hdnPriMandatory.Value = dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString();

                        if (bolToggle == true)
                        {
                            //----------------------------------------------------------------------------
                            if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                            {
                                //txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                                Session["PrimMgrMnd"] = "yes";
                            }
                            else
                            {
                                Session["PrimMgrMnd"] = "no";
                            }

                            //------------------------------------------------------------------------------
                        }

                        //if (bolToggle != true)
                        //{
                        //    if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                        //    {
                        //        if (txtRptMgr.Text == String.Empty)
                        //        {
                        //            StringBuilder sb1 = new StringBuilder();
                        //            sb1.Append("funValidate();");
                        //            ScriptManager.RegisterStartupScript(this, GetType(), "javascript1", sb1.ToString(), true);
                        //        }
                        //    }
                        //    if (dsRpt.Tables[0].Rows[0]["IsAddl1Mand"].ToString() == "True")
                        //    {
                        //        if (txtRptMgr1.Text == String.Empty)
                        //        {
                        //            StringBuilder sb1 = new StringBuilder();
                        //            sb1.Append("funValidate();");
                        //            ScriptManager.RegisterStartupScript(this, GetType(), "javascript2", sb1.ToString(), true);
                        //            // ddlLicTyp_SelectedIndexChanged(this, EventArgs.Empty);
                        //        }
                        //    }
                        //    if (dsRpt.Tables[0].Rows[0]["IsAddl2Mand"].ToString() == "True")
                        //    {
                        //        if (txtRptMgr2.Text == String.Empty)
                        //        {
                        //            StringBuilder sb1 = new StringBuilder();
                        //            sb1.Append("funValidate();");
                        //            ScriptManager.RegisterStartupScript(this, GetType(), "javascript3", sb1.ToString(), true);
                        //        }
                        //    }
                        //    if (dsRpt.Tables[0].Rows[0]["IsAddl3Mand"].ToString() == "True")
                        //    {
                        //        if (txtRptMgr3.Text == String.Empty)
                        //        {
                        //            StringBuilder sb1 = new StringBuilder();
                        //            sb1.Append("funValidate();");
                        //            ScriptManager.RegisterStartupScript(this, GetType(), "javascript4", sb1.ToString(), true);
                        //        }
                        //    }
                        //}
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
    }
    #endregion

    #region Update for ManagerChange Effect on related Managers and UNTCODE Change Effect
    protected void txtRptMgr_TextChanged(object sender, EventArgs e)
    {
        lblrptmgr.Text = String.Empty;
        hdnRptMgr.Value = null;
    }

    protected void txtNewUnitDesc_TextChanged(object sender, EventArgs e)
    {
        hdnUntCode.Value = null;
        lblNewUnitCode.Text = string.Empty;
        hdnNewUntAddr.Value = null;
        lblNewUntAddr.Text = "";
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
            htParam.Add("@AgentType", hdnAgntTyp.Value.Trim());
            htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
            dsRpt = objDAC.GetDataSetForPrc("Prc_GetCrntAddlMngrgrdDtls_PrmDmt", htParam);

            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                gv_RptMngr_Crnt.DataSource = dsRpt.Tables[0];
                gv_RptMngr_Crnt.DataBind();
                bindCrntAddlMngrGridData(dsRpt);
            }
            else
            {
                gv_RptMngr_Crnt.DataSource = null;
                gv_RptMngr_Crnt.DataBind();
                lbladditionalreportingrule.Text = "No Records Exists";
                lbladditionalreportingrule.ForeColor = Color.Red;
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
            gv_RptMngr_Crnt.HeaderRow.Visible = false;
            for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
            {

                Label lblCrntAdlRptTyp = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrntAdlRptTyp");
                lblCrntAdlRptTyp.Text = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

                Label lblCrtAdlBsdOn = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrtAdlBsdOn");
                lblCrtAdlBsdOn.Text = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

                Label lblCrntAdlChn = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrntAdlChn");
                lblCrntAdlChn.Text = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

                Label lblCrntAdlSChn = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrntAdlSChn");
                lblCrntAdlSChn.Text = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

                Label lblCrntAdlAgtTyp = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrntAdlAgtTyp");
                lblCrntAdlAgtTyp.Text = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString();

                Label lblCrntRptMngr = (Label)gv_RptMngr_Crnt.Rows[i].FindControl("lblCrntRptMngr");
                lblCrntRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();

                string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                if (dsRpt.Tables[0].Rows[0]["RelOrder"].ToString().Trim() != "")
                {
                    lblRptMngrErr.Visible = false;
                    lblRptMngrErr.Text = "";
                    lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();
                    lbladditionalreportingrule.Visible = true;
                }
                else
                {
                    lblRptMngrErr.Visible = true;
                    lblRptMngrErr.Text = "No Record(s) Exists";
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

    #region fillNewAddlRptMngrDtls
    public void fillNewAddlRptMngrDtls()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            if (Request.QueryString["flag"] == null)
            {
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                htParam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                dsRpt = objDAC.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls", htParam);
            }
            else
            {
                htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
                htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
                htParam.Add("@AgentType", ddlAgntType.SelectedValue.Trim());
                htParam.Add("@MgrCode", lblAgtCodeVal.Text.Trim());
                dsRpt = objDAC.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls_Reins_Approve", htParam);
            }
            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                gv_RptMngr_new.DataSource = dsRpt.Tables[0];
                gv_RptMngr_new.DataBind();
                bindNewAddlMngrGridData(dsRpt);
            }
            else
            {
                gv_RptMngr_Crnt.DataSource = null;
                gv_RptMngr_Crnt.DataBind();
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
                ddlAdlRptTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["ReportingType"].ToString();

                DropDownList ddlAdlBsdOn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlBsdOn");
                ddlAdlBsdOn.SelectedValue = dsRpt.Tables[0].Rows[i]["BasedOnType"].ToString();

                DropDownList ddlAdlChn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn");
                ddlAdlChn.SelectedValue = dsRpt.Tables[0].Rows[i]["Channel"].ToString();

                DropDownList ddlAdlSChn = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn");
                ddlAdlSChn.SelectedValue = dsRpt.Tables[0].Rows[i]["SubChannel"].ToString();

                HiddenField hdnAddlStp = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAddlStp");
                hdnAddlStp.Value = dsRpt.Tables[0].Rows[i]["AddlStp"].ToString();

                HiddenField hdnAdMemType = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAdMemType");
                Button lnkRptMngr = (Button)gv_RptMngr_new.Rows[i].FindControl("lnkRptMngr");
                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp");
                ddlAdlAgtTyp.Enabled = true;

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
                    lblNwaddtnlreptrule.Text = "";
                }

                if (hdnAddlStp.Value == "E" && ddlAdlBsdOn.SelectedValue == "1")
                {
                    ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                    ddlAdlAgtTyp.Enabled = false;
                }
                else
                {
                    hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString().Trim();
                    ddlAdlAgtTyp.Enabled = true;
                }

                TextBox txtRptMngr = (TextBox)gv_RptMngr_new.Rows[i].FindControl("txtRptMngr");
                Label lblmndtry = (Label)gv_RptMngr_new.Rows[i].FindControl("lblmndtry");
                HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnRptMgrMandatory");
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
                        txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString();
                        Label lblRptMngr = (Label)gv_RptMngr_new.Rows[i].FindControl("lblRptMngr");
                        HiddenField hdnAddlRptMgr = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr");
                        hdnAddlRptMgr.Value = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
                        lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
                        txtRptMngr.Enabled = false;
                        lnkRptMngr.Enabled = false;
                        ddlAdlAgtTyp.Enabled = false;
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

        if (Request.QueryString["Role"] != null)
        {
            if (Request.QueryString["Role"].ToString().Trim() == "E")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + hdnAgntTyp.Value + "','" + ddlAdlAgtTyp.SelectedValue + "','Emp','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
            }
            else
                if (Request.QueryString["Role"].ToString().Trim() == "A")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + hdnAgntTyp.Value + "','" + ddlAdlAgtTyp.SelectedValue + "','','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "');", true);
                }
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
    protected void ddllvlagttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetManagers();
        txtRptMgr.Text = "";
        lblrptmgr.Text = "";
        hdnRptMgr.Value = null;
    }
    protected void txtRptMngr_TextChanged(object sender, EventArgs e)
    {
        //GridViewRow grd = ((TextBox)sender).NamingContainer as GridViewRow;
        //TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
        //HiddenField hdnAddlRptMgr = grd.FindControl("hdnAddlRptMgr") as HiddenField;
        //Label lblRptMngr = (Label)grd.FindControl("lblRptMngr");

        //txtRptMngr.Text = "";
        //hdnAddlRptMgr.Value = null;
        //lblRptMngr.Text = "";

    }

    #region Hierarchy_Click
    protected void Hierarchy_Click(object sender, EventArgs e)
    {
        ////MultiViewCrnt.ActiveViewIndex = 0;

        HierarchyDtl.Style.Add("display", "block");
        PrimaryDtl.Style.Add("display", "none");
        AdditionalDtl.Style.Add("display", "none");

        Hierarchy.CssClass = "btn-subtab btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";

    }
    #endregion

    #region Primary_Click
    protected void Primary_Click(object sender, EventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 1;
        HierarchyDtl.Style.Add("display", "none");
        PrimaryDtl.Style.Add("display", "block");
        AdditionalDtl.Style.Add("display", "none");


        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn-subtab btn btn-default";
        Additional.CssClass = "btn btn-default";
        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region Additional_Click
    protected void Additional_Click(object sender, EventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 2;

        HierarchyDtl.Style.Add("display", "none");
        PrimaryDtl.Style.Add("display", "none");
        AdditionalDtl.Style.Add("display", "block");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn-subtab btn btn-default";

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        //ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>AssigText('" + lbladditionalreportingrule.Text.Trim() + "');</script>", false);
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";

    }
    #endregion

    #region HierarchyNew_Click
    protected void HierarchyNew_Click(object sender, EventArgs e)
    {
        //MVNewDtls.ActiveViewIndex = 0;
        HierarchyDemo.Style.Add("display", "block");
        AdditionalDemo.Style.Add("display", "none");
        PrimaryDemo.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn-subtab btn btn-default";
        PrimaryNew.CssClass = "btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";

        lblNewUnitCode.Text = hdnUntCode.Value;
        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        lnkCrntAddlMgrNew.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";

        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";

    }
    #endregion

    #region PrimaryNew_Click
    protected void PrimaryNew_Click(object sender, EventArgs e)
    {
        //MultiViewCrnt.ActiveViewIndex = 1;
        PrimaryDemo.Style.Add("display", "block");
        HierarchyDemo.Style.Add("display", "none");
        AdditionalDemo.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn-subtab btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region AdditionalNew_Click
    protected void AdditionalNew_Click(object sender, EventArgs e)
    {
        //MVNewDtls.ActiveViewIndex = 2;
        AdditionalDemo.Style.Add("display", "block");
        HierarchyDemo.Style.Add("display", "none");
        PrimaryDemo.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn btn-default";
        AdditionalNew.CssClass = "btn-subtab btn btn-default";

        lblNewUnitCode.Text = hdnUntCode.Value;
        lnkCrntPrimMgrNew.BackColor = Color.Transparent;
        lnkCrntAddlMgrNew.BackColor = Color.Transparent;

        lnkCrntAddlMgrNew.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgrNew.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
    }
    #endregion

    #region btnunitgrid_Click
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
                lblNewUnitCode.Text = UntCode.Text;
                hdnUntCode.Value = UntCode.Text;
            }



        }
    }
    protected void btnmemgrid_Click(object sender, EventArgs e)
    {
        if (Session["mem"] != null)
        {
            gv.DataSource = Session["mem"];
            gv.DataBind();
           // gv_RptMngr_new.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gv.Rows.Count - 1; intRowCount++)
            {
                Label MemCode = (Label)gv.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
                Label MemType = (Label)gv.Rows[intRowCount].Cells[0].FindControl("lblMemType");
                str = str + MemCode.Text;
                str += (intRowCount < gv.Rows.Count - 1) ? "," : string.Empty;
                ddllvlagttype.SelectedItem.Text = MemType.Text.Trim();
                txtRptMgr.Text = MemCode.Text;
                hdnPrmyRptMgr.Value = MemCode.Text;
           

            }

            if (Request.QueryString["Ctgry"] != null)
            {
                if (Request.QueryString["Ctgry"].ToString().Trim() == "E")
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ddlAgntType.SelectedValue.Trim() + "','Emp','" + str + "');return false;");
                }
                else if (Request.QueryString["Ctgry"].ToString().Trim() == "A")
                {
                    btnUnitCode.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','" + ddlAgntType.SelectedValue.Trim() + "','Agent','" + str + "');return false;");
                }
            }
        }
    }
    #endregion
}

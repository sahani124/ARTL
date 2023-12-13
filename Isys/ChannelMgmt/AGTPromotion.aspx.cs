#region DECLARATION
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
using INSCL.App_Code;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using Insc.Common.Multilingual;
using INSCL.DAL;
using DataAccessClassDAL;
using System.Web.Script.Serialization;
using System.Xml;
using CLTMGR;
using System.Drawing;
#endregion

public partial class Application_INSC_ChannelMgmt_AGTPromotion : BaseClass
{
    #region DECLARATION
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    SqlDataReader dtRead;
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    DataAccessClass objDAC = new DataAccessClass();
    private const string c_strBlank = "-- Select --";
    private multilingualManager olng, olng_m;
    private string strUserLang;
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    string strXML = "";
    string strBizSrc = String.Empty, strBizSrcDesc = String.Empty, strChnCls = String.Empty, strAgentType = String.Empty;
    string ErrMsg, AuditType;
    private string m_strUserLang, m_strMgrCode, m_strUnitCode, m_strDirectAgtCode, m_strAgentStatus, m_strAgentTypeAddl;
    enum PrmDemType { Promotion, Demotion }

    SqlConnection objSQLConForTran = new SqlConnection();
    SqlTransaction objSQLTran = null;
    private clsAgent agtObject = new clsAgent();
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    #endregion

    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        HierarchyDiv.Style.Add("display", "block");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "none");

        Hierarchy.CssClass = "btn-subtab btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn btn-default";

        PrimDwd.CssClass = "btn-subtab btn btn-default";
        AddDwd.CssClass = "btn btn-default";



        divHirarchyDtlsNewHdr.Style.Add("display", "block");
        divprirptHdr.Style.Add("display", "none");
        divNewMngrDtlsHdr.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn-subtab btn btn-default";
        PrimaryNew.CssClass = "btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";

        #region Initialise values
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        if (HttpContext.Current.Session["UserLangNum"] != "")
        {
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        }
        olng_m = new multilingualManager("DefaultConn", "AGTTransfer.aspx", strUserLang);
        if (Request.QueryString["Role"] != null && Request.QueryString["Role"].ToString().Trim() == "E")
        {
            olng = new multilingualManager("DefaultConn", "EMPInfo.aspx", strUserLang);
        }
        else
        {
            olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);
        }
        Session["CarrierCode"] = "2";
        #endregion

        #region IsPostBack
        if (!IsPostBack)
        {
            InitializeControl();

            if (Request.QueryString["AgnCd"] != null)
            {
                ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString();
            }

            if (Request.QueryString["Role"] != null)
            {
                ViewState["Role"] = Request.QueryString["Role"].ToString();
            }
            fillAgtDtls();
            fillAllLabels();
            FillRequiredDataForPage1();

            BindGridRelation(lnkbtnCF.Text);

            #region Old Page Load
            ddl_NewAgnType.Items.Insert(0, new ListItem("-- Select --", ""));
            if (Session["AgntList"] != null)
            {
                Session["AgntList"] = null;
            }
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@AgentType ", strAgentType);
            htparam.Add("@BizSrc ", strBizSrc);
            htparam.Add("@ChnCls", strChnCls);
            htparam.Add("@flag", 13);
            dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htparam);
            if (dtRead.Read())
            {
                hdUnitRank.Value = dtRead["UnitRank"].ToString();
            }
            dtRead.Close();

            txtEffectdt.Text = System.DateTime.Today.ToString("dd/MM/yyyy");

            hdnPageParam.Value = Request.QueryString["ID"].ToString().Trim();
            if (Request.QueryString["ID"].ToString() == "PU")
            {
                // trAgPromotion.Visible = false;
                //trNwAgntType.Visible = false;
                // trPromoType.Visible = false;
                Hashtable htParam = new Hashtable();
                htParam.Clear();
                htParam.Add("@AgnCd", Request.QueryString["AgnCd"]);
                dsResult = objDAL.GetDataSetForPrc("Prc_FillAgnPromoDt", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows[0]["EffDate"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["EffDate"]).Trim() != "")
                            {
                                txtEffectdt.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EffDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["Remark"] != "")
                        {
                            txtRemark.Text = dsResult.Tables[0].Rows[0]["Remark"].ToString();
                        }
                        hdnTrfRefNo.Value = dsResult.Tables[0].Rows[0]["TrfRefNo"].ToString();

                    }
                }

            }
            #endregion

            // MultiViewCrnt.ActiveViewIndex = 0;
            lnkCrntHier.BackColor = Color.Transparent;
            lnkCrntPrimMgr.BackColor = Color.Transparent;
            lnkCrntAddlMgr.BackColor = Color.Transparent;
            lnkCrntDlines.BackColor = Color.Transparent;


            lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
            lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
            lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
            lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

            //MultiViewNew.ActiveViewIndex = 0;
            lnkCrntHierNew.BackColor = Color.Transparent;
            lnkNewPrimMgr.BackColor = Color.Transparent;
            lnkNewAddlMgr.BackColor = Color.Transparent;

            lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
            lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
            lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";

            //tblRptMgrDtlsNew.Visible = false;
            tblRptMgrDtlsNew.Style.Add("display", "none");
           // filldataonapprove();

            //  trNwUntCode.Visible = false;
            if (Request.QueryString["flag"] != null && Request.QueryString["flag"].ToString().Trim() == "A")
            {
                filldataonapprove();
            }

            ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
            ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
            ddlAgntType.Items.Insert(0, new ListItem("Select", ""));

            ViewState["BackUrl"] = Request.UrlReferrer.AbsoluteUri;
        }
        #endregion

        #region Add Attributes
        btnUpdate.Attributes.Add("onClick", "Javascript:return validation();");
        //btnCancel.Attributes.Add("onClick", "javascript:history.go(-1); return false;");
        string str = string.Empty;
        for (int intRowCount = 0; intRowCount <= gvNew.Rows.Count - 1; intRowCount++)
        {
            Label MemCode = (Label)gvNew.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
            str = str + MemCode.Text;
            str += (intRowCount < gvNew.Rows.Count - 1) ? "," : string.Empty;
        }
        btnRptUnitSearch.Attributes.Add("onClick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','" + strAgentType + "','" + ddlPrimagttype.SelectedValue + "','" + str + "');return false;");
        //txtNewUntCode.Attributes.Add("readonly", "readonly");
        #endregion
    }
    #endregion

    #region filldataonapprove
    public void filldataonapprove()
    {
        try
        {
            #region Disable fields
            btnUpdate.Visible = false;
            btnApprove.Visible = true;
            btnReject.Visible = true;
            ddlAgPro.Enabled = false;
            ddl_NewAgnType.Enabled = false;
            txtEffectdt.Enabled = false;
            txtRemark.Enabled = false;
            //ddlPrimagttype.Enabled = false;
            ddlPrimbasedon.Enabled = false;
            ddlPrimchannel.Enabled = false;
            ddlPrimsubchannel.Enabled = false;
            //ddlPrimagttype.Enabled = false;
            txtRptMgr.Enabled = false;
            btnRptMgr.Enabled = false;
            txtNewUntCode.Enabled = false;
            btnRptUnitSearch.Enabled = false;
            #endregion

            htParam = new Hashtable();
            dsResult = new DataSet();
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            dsResult = objDAL.GetDataSetForPrc("Prc_pd_GetDtls_approve", htParam);
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                ddlAgPro.SelectedValue = dsResult.Tables[0].Rows[0]["MvmtType"].ToString();

                #region Fill New AgtType
                Hashtable ht = new Hashtable();
                DataSet ds_getAgnType = new DataSet();
                ddl_NewAgnType.Items.Clear();

                ht.Add("@AgentCode", lblAgtCodeVal.Text);
                ht.Add("@PRType", ddlAgPro.SelectedItem.Text.Trim());
                if (Request.QueryString["Role"] != null)
                {
                    ht.Add("@Type", ViewState["Role"].ToString());
                }
                else
                {
                    ht.Add("@Type", Request.QueryString["flag"].ToString());
                }
                ds_getAgnType = objDAL.GetDataSetForPrc("prc_pd_GetAgentForPD", ht);
                if (ds_getAgnType.Tables.Count > 0)
                {
                    if (ds_getAgnType.Tables[0].Rows.Count > 0)
                    {
                        ddl_NewAgnType.DataSource = ds_getAgnType;
                        ddl_NewAgnType.DataValueField = ds_getAgnType.Tables[0].Columns[0].ToString().Trim();
                        ddl_NewAgnType.DataTextField = ds_getAgnType.Tables[0].Columns[1].ToString().Trim();
                        ddl_NewAgnType.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Asst. Branch Manager cannot be demoted to Sales Manager.');", true);
                        ddl_NewAgnType.DataSource = null;
                        ddl_NewAgnType.DataBind();
                    }
                }
                #endregion

                ddl_NewAgnType.SelectedValue = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
                txtEffectdt.Text = dsResult.Tables[0].Rows[0]["EffDate"].ToString();
                txtRemark.Text = dsResult.Tables[0].Rows[0]["Remark"].ToString();
                DataTable dt = new DataTable();
                dt = dsResult.Tables[0].DefaultView.ToTable(true, "UnitCode", "UnitDesc01", "UnitTypDesc", "Adr1");
                gvNewUntLst.DataSource = dt;
                gvNewUntLst.DataBind();
                gvNewUntLst.Columns[4].Visible = false;
                // txtNewUntCode.Text = dsResult.Tables[0].Rows[0]["NewUntCodedsc"].ToString();
                // lblUnitDesc.Text = dsResult.Tables[0].Rows[0]["NewUntCode"].ToString();
                //hdnUntCode.Value = dsResult.Tables[0].Rows[0]["NewUntCode"].ToString().Trim();
                FillNewRptMgrDtls();
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
    private void InitializeControl()
    {

        lblEffDt.Text = "Effective Date";
        lblRemark.Text = "Remarks";
        lblNewAgentType.Text = "New Agent Type";
        lblNewUntCode.Text = "New Unit Code";
        lblAgPromotion.Text = "Agent Promotion";
        Label1.Text = olng_m.GetItemDesc("Label1");
        Label2.Text = olng_m.GetItemDesc("Label2");

        lblPersonalPart.Text = olng.GetItemDesc("lblPersonalPart.Text");
        lvlVw1AgntCode.Text = olng.GetItemDesc("lvlVw1AgntCode.Text");
        lblVw1AgntStatus.Text = olng.GetItemDesc("lblVw1AgntStatus.Text");
        lblClCode.Text = olng.GetItemDesc("lblClCode.Text");
        lblExclusive.Text = olng.GetItemDesc("lblExclusive.Text");
        lblAgntName.Text = olng.GetItemDesc("lblAgntName.Text");
        lblBusinessSrc.Text = olng.GetItemDesc("lblBusinessSrc.Text");
        lblCntDetails.Text = olng.GetItemDesc("lblCntDetails.Text");
        lblChnCls.Text = olng.GetItemDesc("lblChnCls.Text");
        lblVw1AgntType.Text = olng.GetItemDesc("lblVw1AgntType.Text");
        lblAgntClass.Text = olng.GetItemDesc("lblAgntClass.Text");
        //Personal Client Details
        lblCode.Text = olng.GetItemDesc("lblCode.Text");
        lblchnltype.Text = olng.GetItemDesc("lblchnltype.Text");
        lblchannel.Text = olng.GetItemDesc("lblchannel.Text");
        lblsubchannel.Text = olng.GetItemDesc("lblsubchannel.Text");
        lbllevelagttype.Text = olng.GetItemDesc("lbllevelagttype.Text");
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
            dsagt = objDAL.GetDataSetForPrc("prc_GetAgtPrmteDmteDtls", htagt);

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

    #region fillAllLabels
    protected void fillAllLabels()
    {
        try
        {

            //DataSet DS = new DataSet();
            //Hashtable HT = new Hashtable();
            //HT.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            //DS = objDAL.GetDataSetForPrc("prc_GetChnlTypeByAgentCode", HT);
            //int valChnType = Convert.ToInt16(DS.Tables[0].Rows[0]["chnltype"]);
            //HT.Clear();
            //DS.Clear();

            //if (valChnType == 1)
            //    htParam.Add("@chnltyp", "1");
            //if (valChnType == 0)
            //    htParam.Add("@chnltyp", "0");

            //tempds = objDAL.GetDataSetForPrc("Prc_GetUserSalesChannel", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblSlsChannelVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
            //    //lblchanneldescVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChannelDesc01"]);
            //    strBizSrc = Convert.ToString(tempds.Tables[0].Rows[0]["BizSrc"]);
            //    tempds.Clear();

            //    //Store the Values in Sessions
            //    Session["BizSrc"] = strBizSrc;
            //    Session["AgentCode"] = Request.QueryString["AgnCd"].ToString().Trim();
            //}

            //htParam.Clear();
            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htParam.Add("@BizSrc", strBizSrc);
            //tempds = objDAL.GetDataSetForPrc("Prc_ddlchnnlsubcls", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblChnClsVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["ChnlDesc"]);
            //    strChnCls = Convert.ToString(tempds.Tables[0].Rows[0]["ChnCls"]);
            //    Session["ChnSubClass"] = strChnCls;
            //    tempds.Clear();
            //}

            //htParam.Clear();
            //htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //htParam.Add("@BizSrc", strBizSrc);
            //tempds = objDAL.GetDataSetForPrc("Prc_getAgentTypeWithCode", htParam);
            //if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            //{
            //    lblAgntTypeVal.Text = Convert.ToString(tempds.Tables[0].Rows[0]["AgentTypeDesc01"]);
            //    strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["AgentType"]);
            //}

            //FillRequiredDataForPage1();
            DataSet tempds = new DataSet();
            htParam.Clear();
            htParam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString().Trim());
            htParam.Add("@Flag", 4);
            tempds = objDAL.GetDataSetForPrc("prc_GetAgnCodeandAgnName", htParam);
            if (tempds.Tables.Count > 0 && tempds.Tables[0].Rows.Count > 0)
            {
                strAgentType = Convert.ToString(tempds.Tables[0].Rows[0]["MemType"]);
                txtCrntUntCode.Text = tempds.Tables[0].Rows[0]["UnitLegalName"].ToString();
                lblCrntUnitDesc.Text = tempds.Tables[0].Rows[0]["UnitCode"].ToString();
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

    #region FillRequiredDataForPage1
    protected void FillRequiredDataForPage1()
    {
        dsResult = new DataSet();
        htParam = new Hashtable();
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", Convert.ToString(Request.QueryString["AgnCd"].ToString().Trim()));
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        try
        {
            dsResult = objDAL.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt1", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);

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
                    lblChnClsVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnClsDesc"]);
                    lblAgntTypeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentTypeDesc"]);
                    lblAgtCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]);
                    lblCusmIdVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]);
                    lblCltCodeVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ClientCode"]).ToUpper();
                    lblGenderVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]).ToUpper();
                    strBizSrc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    strBizSrcDesc = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrcDesc"]);
                    lblagnTitleVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgnTitle"]);
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblRptMgrVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MgrName"]);

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

                    string LastPromotionDate = "";
                    htparam = new Hashtable();
                    htparam.Add("@AgentCode", Request.QueryString["AgnCd"].ToString());
                    dtRead = objDAL.Common_exec_reader_prc("Prc_GetLstPromoDte", htparam);
                    if (dtRead.Read())
                    {
                        LastPromotionDate = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    lblAgntNameVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    Img.Visible = false;
                    DataSet dsImg = BindGrid();
                    GridImage.DataSource = dsImg;
                    GridImage.DataBind();
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString() == "A")
                        {
                            FillRptMngrDtlsforApprove();
                        }
                    }
                    else
                    {
                        FillReportingMngrDtls();
                    }
                    FillUnits();
                    FillPrimMgr();
                    FillAddlMgr();
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
        for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
        {
            GridView gvAddlMgr = gv_RptMngr_Crnt.Rows[i].FindControl("gvAddlMgr") as GridView;

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
            htParam.Add("@AgentType", hdnagttyp.Value);
            htParam.Add("@BizSrc", hdnBizsrc.Value);
            htParam.Add("@ChnCls", hdnChncls.Value);
            dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    ViewState["PrmRptType"] = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                    lblprimrepoVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryRpTyp"].ToString();
                    lblbasedondescVal.Text = dsRpt.Tables[0].Rows[0]["BasedOn"].ToString();
                    lblsubchnldescVal.Text = dsRpt.Tables[0].Rows[0]["PrimarySubChnl"].ToString();
                    lbllvlagtVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryAgtOrLevelType"].ToString();
                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                    {
                        lblRptMngrErr.Visible = false;
                        lblRptMngrErr.Text = "";
                        //if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "0")
                        //{
                        //    lbladditionalreportingrule.Text = "Multiple-1";
                        //}
                        //else
                        //    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "1")
                        //    {
                        //        lbladditionalreportingrule.Text = "Multiple-2";
                        //    }
                        //    else
                        //        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "2")
                        //        {
                        //            lbladditionalreportingrule.Text = "Multiple-3";
                        //        }

                        lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();

                    }
                    else
                    {
                        lblRptMngrErr.Visible = true;
                        lblRptMngrErr.Text = "No Record(s) Exists";
                        lbladditionalreportingrule.Text = "";
                    }
                    //if (MultiViewCrnt.ActiveViewIndex == 1)
                    //{
                    //    //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    //}
                }
                else
                {
                    //if (MultiViewCrnt.ActiveViewIndex == 1)
                    //{
                    //    //funShowCrntMgr("empty");
                    //}
                }
            }
            else
            {
                //if (MultiViewCrnt.ActiveViewIndex == 1)
                //{
                //    //funShowCrntMgr("empty");
                //}
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

    #region FillRptMngrDtlsforApprove
    protected void FillRptMngrDtlsforApprove()
    {
        try
        {
            fillAddlRptMngrDtls();

            Hashtable htParam = new Hashtable();
            Hashtable htParam2 = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"]);
            dsRpt = objDAL.GetDataSetForPrc("Prc_pd_GetCrntRptMgrDtls_approve", htParam);

            if (dsRpt.Tables.Count > 0)
            {
                if (dsRpt.Tables[0].Rows.Count > 0)
                {
                    ViewState["PrmRptType"] = dsRpt.Tables[0].Rows[0]["RelType"].ToString();
                    lblprimrepoVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryRpTyp"].ToString();
                    lblbasedondescVal.Text = dsRpt.Tables[0].Rows[0]["BasedOn"].ToString();
                    lblsubchnldescVal.Text = dsRpt.Tables[0].Rows[0]["PrimarySubChnl"].ToString();
                    lbllvlagtVal.Text = dsRpt.Tables[0].Rows[0]["PrimaryAgtOrLevelType"].ToString();
                    string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                    {
                        //lblRptMngrErr.Visible = false;
                        //lblRptMngrErr.Text = "";
                        //if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "0")
                        //{
                        //    lbladditionalreportingrule.Text = "Multiple-1";
                        //}
                        //else
                        //    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "1")
                        //    {
                        //        lbladditionalreportingrule.Text = "Multiple-2";
                        //    }
                        //    else
                        //        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "2")
                        //        {
                        //            lbladditionalreportingrule.Text = "Multiple-3";
                        //        }

                        lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();

                    }
                    else
                    {
                        lblRptMngrErr.Visible = true;
                        lblRptMngrErr.Text = "No Record(s) Exists";
                        lbladditionalreportingrule.Text = "";
                    }
                    //if (MultiViewCrnt.ActiveViewIndex == 1)
                    //{
                    //    //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
                    //}
                }
                else
                {
                    //if (MultiViewCrnt.ActiveViewIndex == 1)
                    //{
                    //    //funShowCrntMgr("empty");
                    //}
                }
            }
            else
            {
                //if (MultiViewCrnt.ActiveViewIndex == 1)
                //{
                //    //funShowCrntMgr("empty");
                //}
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
    protected void funagttyppopup(DropDownList ddl, string txtchn, string txtsubchn, string txtbsdon)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtRead;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@chnl", txtchn.Trim());
            htparam.Add("@subchnl", txtsubchn.Trim());
            htparam.Add("@BsdOn", txtbsdon.Trim());
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlmgragttyp", htparam);
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

    #region BindGrid()
    ///added by akshay on 14/01/2014 to show profile image start
    private DataSet BindGrid()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();

            Hashtable httable = new Hashtable();
            httable.Add("@AgtCode", lblAgtCodeVal.Text);

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
        return dsResult;
    }
    #endregion

    #region ddlPromoType_SelectedIndexChanged
    protected void ddlPromoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPromoType.SelectedItem.Text.Trim() == "Exception Promotion")
            {
                //trKPIParam.Visible = true;
            }
            else
            {
                //trKPIParam.Visible = false;
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

    #region ddlAgPro_SelectedIndexChanged
    protected void ddlAgPro_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnUntCode.Value = null;
            //hdnUntCode.Value = "";
            hdnRptMgr.Value = null;
            hideNewDtls();
            //tblRptMgrDtlsNew.Visible = false;
            tblRptMgrDtlsNew.Style.Add("display", "none");
            //  trNwUntCode.Visible = false;
            if (ddlAgPro.SelectedIndex == 0)
            {
                ddl_NewAgnType.SelectedIndex = 0;
                return;
            }

            #region Check Promotion-Demotion flag
            int PrmStatus = -1, DmtStatus = -1;
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            dsResult.Clear();
            htparam.Add("@AgentType", hdnagttyp.Value);
            htparam.Add("@BizSrc", hdnBizsrc.Value);
            htparam.Add("@ChnCls", hdnChncls.Value);
            dsResult = objDAL.GetDataSetForPrc("prc_GetMovementStatus", htparam);
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                if (dsResult.Tables[0].Rows[0]["IsMvmtPromo"].ToString() != "" || dsResult.Tables[0].Rows[0]["IsMvmtDemo"].ToString() != "")
                {
                    PrmStatus = Convert.ToInt16(dsResult.Tables[0].Rows[0]["IsMvmtPromo"]);
                    DmtStatus = Convert.ToInt16(dsResult.Tables[0].Rows[0]["IsMvmtDemo"]);
                }
            }

            if (ddlAgPro.SelectedIndex == 1)
            {
                if (PrmStatus != null)
                {
                    if (PrmStatus == 0)
                    {
                        //lblMessage.Text = "Member with this Member Type Cannot Be Promoted.Please refer Member Type Setup.";
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member with this Member Type Cannot Be Promoted.Please refer Member Type Setup.');", true);
                        ddlAgPro.SelectedIndex = 0;
                        ddlAgPro.Focus();
                        return;
                    }
                }
            }

            if (ddlAgPro.SelectedIndex == 2)
            {
                if (DmtStatus != null)
                {
                    if (DmtStatus == 0)
                    {
                        //lblMessage.Text = "Member with this Member Type Cannot Be Demoted.Please refer Member Type Setup.";
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member with this Member Type Cannot Be Demoted.Please refer Member Type Setup.');", true);
                        ddlAgPro.SelectedIndex = 0;
                        ddlAgPro.Focus();
                        return;
                    }
                }
            }

            #endregion

            htparam.Clear();
            htparam.Add("@AgentType ", strAgentType);
            htparam.Add("@BizSrc ", strBizSrc);
            htparam.Add("@ChnCls", lblChnCls.Text.ToString().Trim());
            htparam.Add("@flag", 8);
            dtRead = objDAL.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", htparam);

            if (dtRead.Read())
            {
                if (dtRead["UntRule"].ToString().Trim() == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Advisors can not be Promoted or Demoted');", true);
                    ddl_NewAgnType.Items.Clear();
                    ddl_NewAgnType.Items.Insert(0, new ListItem("-- Select --", ""));
                    ddlAgPro.SelectedIndex = 0;
                    return;
                }

                else if ((dtRead["UnitRank"].ToString().Trim() == "7.0" || dtRead["AgentCreateRul"].ToString().Trim() == "BM") && ddlAgPro.SelectedItem.Text == "Demotion")
                {
                    if (dtRead["ORLdrCreateRul"].ToString().Trim() == "1" || dtRead["ORLdrCreateRul"].ToString().Trim() == "2")
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Sales Manager cannot be demoted to Advisor.');", true);
                        ddl_NewAgnType.Items.Clear();
                        ddl_NewAgnType.Items.Insert(0, new ListItem("-- Select --", ""));
                        ddlAgPro.SelectedIndex = 0;
                        return;
                    }
                }

            }
            dtRead.Close();

            Hashtable ht = new Hashtable();
            DataSet ds_getAgnType = new DataSet();
            ddl_NewAgnType.Items.Clear();

            ht.Add("@AgentCode", lblAgtCodeVal.Text);
            ht.Add("@PRType", ddlAgPro.SelectedItem.Text);
            ht.Add("@Type", ViewState["Role"].ToString());
            ds_getAgnType = objDAL.GetDataSetForPrc("prc_pd_GetAgentForPD", ht);
            if (ds_getAgnType.Tables.Count > 0)
            {
                if (ds_getAgnType.Tables[0].Rows.Count > 0)
                {
                    ddl_NewAgnType.DataSource = ds_getAgnType;
                    ddl_NewAgnType.DataValueField = ds_getAgnType.Tables[0].Columns[0].ToString().Trim();
                    ddl_NewAgnType.DataTextField = ds_getAgnType.Tables[0].Columns[1].ToString().Trim();
                    ddl_NewAgnType.DataBind();
                }
                else
                {
                    if (ddlAgPro.SelectedValue == "PRM")
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member cannot be Promoted.');", true);
                    }
                    if (ddlAgPro.SelectedValue == "DEM")
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member cannot be Demoted.');", true);
                    }
                    ddl_NewAgnType.DataSource = null;
                    ddl_NewAgnType.DataBind();
                }
            }
            else
            {
                if (ddlAgPro.SelectedValue == "PRM")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member cannot be Promoted.');", true);
                }
                if (ddlAgPro.SelectedValue == "DEM")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Member cannot be Demoted.');", true);
                }
                ddl_NewAgnType.DataSource = null;
                ddl_NewAgnType.DataBind();
            }
            ddl_NewAgnType.Items.Insert(0, new ListItem("-- Select --", ""));

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

    #region ddl_NewAgnType_SelectedIndexChanged
    protected void ddl_NewAgnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnRptMgr.Value = "";
            hdnUntCode.Value = "";
            hideNewDtls();
            if (ddl_NewAgnType.SelectedIndex != 0)
            {
                FillNewRptMgrDtls();
                ChkMandMgr();
                //tblNewUntCode.Visible = true;
            }
            else
            {

                //tblRptMgrDtlsNew.Visible = false;
                tblRptMgrDtlsNew.Style.Add("display", "none");
                //  trNwUntCode.Visible = false;
                //tblNewUntCode.Visible = false;
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

    #region lnkbtnCF_Click
    protected void lnkbtnCF_Click(object sender, EventArgs e)
    {
        PrimDwd.CssClass = "btn-subtab btn btn-default";
        AddDwd.CssClass = "btn btn-default";

        PrimaryDiv.Style.Add("display", "none");
        HierarchyDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "block");

        BindGridRelation(lnkbtnCF.Text);

    }
    #endregion

    #region lnkbtnCU_Click
    protected void lnkbtnCU_Click(object sender, EventArgs e)
    {
        PrimDwd.CssClass = "btn btn-default";
        AddDwd.CssClass = "btn-subtab btn btn-default";

        PrimaryDiv.Style.Add("display", "none");
        HierarchyDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "block");

        BindGridRelation(lnkbtnCU.Text);
        //if (MultiViewCrnt.ActiveViewIndex == 1)
        //{
        //    //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
        //}
    }
    #endregion

    #region BindGridRelation
    protected void BindGridRelation(string strtype)
    {
        try
        {
            DataSet dsGrid = new DataSet();
            Hashtable httable = new Hashtable();
            dsGrid.Clear();
            httable.Clear();
            httable.Add("@AgtCode", lblAgtCodeVal.Text);
            httable.Add("@RptType", "CF");

            dsGrid = objDAL.GetDataSetForPrcCLP("Prc_GetRelationForAgtCode", httable);
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count > 0)
                {
                    gv_TrfDownlines.DataSource = dsGrid;
                    ViewState["gv"] = dsGrid;
                    gv_TrfDownlines.DataBind();
                }
                else
                {
                    gv_TrfDownlines.DataSource = null;
                    gv_TrfDownlines.DataBind();
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                gv_TrfDownlines.DataSource = null;
                gv_TrfDownlines.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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

    #region gv_TrfDownlines_PageIndexChanging
    protected void gv_TrfDownlines_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = ViewState["gv"] as DataSet;
            DataView dv = new DataView(ds.Tables[0]);
            gv_TrfDownlines.PageIndex = e.NewPageIndex;
            dv.Sort = gv_TrfDownlines.Attributes["SortExpression"];

            if (gv_TrfDownlines.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_TrfDownlines.DataSource = dv;
            gv_TrfDownlines.DataBind();
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

            DataSet ds = ViewState["gv"] as DataSet;
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

    #region lnkCrntHier_Click
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
        //MultiViewCrnt.ActiveViewIndex = 2;
        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
        //funShowNewMgr(lblNewaddlrptrule.Text.Trim());
    }
    #endregion

    #region lnkCrntDlines_Click
    protected void lnkCrntDlines_Click(object sender, ImageClickEventArgs e)
    {
        // MultiViewCrnt.ActiveViewIndex = 3;
        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";
    }
    #endregion

    #region lnkCrntHierNew_Click
    protected void lnkCrntHierNew_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 0;

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region lnkNewPrimMgr_Click
    protected void lnkNewPrimMgr_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 1;
        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region lnkNewAddlMgr_Click
    protected void lnkNewAddlMgr_Click(object sender, ImageClickEventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 2;
        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
        //funShowNewMgr(lblNewaddlrptrule.Text.Trim());
    }
    #endregion

    #region FillNewRptMgrDtls
    protected void FillNewRptMgrDtls()
    {
        if (Request.QueryString["Type"] != null)
        {
            try
            {
                Hashtable htParam = new Hashtable();
                DataSet dsRpt = new DataSet();
                htParam.Clear();
                dsRpt.Clear();
                if (Request.QueryString["flag"] != null && Request.QueryString["flag"].ToString() == "A")
                {
                    htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
                    htParam.Add("@AgentType", ddl_NewAgnType.SelectedValue);
                    htParam.Add("@BizSrc", hdnBizsrc.Value);
                    htParam.Add("@ChnCls", hdnChncls.Value);
                    dsRpt = objDAL.GetDataSetForPrc("Prc_pd_GetNewRptMngrDtl_Approve", htParam);

                    //Added by mrunal to bind primary manager details to grid

                    gvNew.DataSource = dsRpt.Tables[0];
                    gvNew.DataBind();
                    //Session["mem"] = dsRpt;
                    gvNew.Columns[4].Visible = false;
                    //------------------------end--------------------------------

                }
                else
                {
                    htParam.Clear();
                    htParam.Add("@AgentType", ddl_NewAgnType.SelectedValue);
                    htParam.Add("@BizSrc", hdnBizsrc.Value);
                    htParam.Add("@ChnCls", hdnChncls.Value);
                    dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);
                }
                //Assign values to labels
                #region fetch values
                if (dsRpt.Tables.Count > 0)
                {
                    if (dsRpt.Tables[0].Rows.Count > 0)
                    {
                        FillReportingMngrddl();

                        ddlPrimRptTyp.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString();
                        string PrmyRptType = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                        hdnRptSetup.Value = dsRpt.Tables[0].Rows[0]["PrmyRptType"].ToString();
                        if (dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == "" || dsRpt.Tables[0].Rows[0]["PrimaryReportingType"].ToString() == null)
                        {
                            //tblRptMgrDtlsNew.Visible = false;
                            tblRptMgrDtlsNew.Style.Add("display", "none");
                            //  trNwUntCode.Visible = false;
                        }
                        else
                        {
                            //tblRptMgrDtlsNew.Visible = true;
                            tblRptMgrDtlsNew.Style.Add("display", "block");
                            // trNwUntCode.Visible = true;
                        }


                        rblChnlType.SelectedValue = rdbChnlTyp.SelectedValue;

                        ddlPrimbasedon.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryBasedOnType"].ToString();

                        FillReportingMngrchnl();

                        ddlSlsChannel.SelectedValue = hdnBizsrc.Value;
                        ddlPrimchannel.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();

                        FillReportingMngrsubchnl();

                        ddlChnCls.SelectedValue = hdnChncls.Value;
                        ddlPrimsubchannel.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                        FillReportingMngrAgttype();
                        #region fetch member type

                        if (Request.QueryString["Type"] != null)
                        {

                            if (PrmyRptType == "E" && ddlPrimbasedon.SelectedValue == "1")
                            {
                                ddlPrimagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                                //ddlPrimagttype.Enabled = true;
                               // ddlPrimagttype.Enabled = false;
                            }
                            else if (PrmyRptType == "E" && ddlPrimbasedon.SelectedValue == "0")
                            {
                                ddlPrimagttype.SelectedValue = RetMemType(dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim(),
                                    ddlPrimchannel.SelectedValue.ToString().Trim(), ddlPrimsubchannel.SelectedValue.ToString().Trim());
                            }
                            else
                            {
                                hdnPrimStp.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                                hdnRptStp.Value = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                                //ddlPrimagttype.Enabled = true;
                               // ddlPrimagttype.Enabled = false;
                            }
                        }
                        #endregion
                        // ddlAgntType.SelectedValue = ddl_NewAgnType.SelectedValue;
                        //ddlPrimagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString();
                        //hdnPrimAgtType.Value = ddlPrimagttype.SelectedValue;

                        hdnchn.Value = dsRpt.Tables[0].Rows[0]["PrimaryChannel"].ToString();
                        hdnsubchn.Value = dsRpt.Tables[0].Rows[0]["PrimarySubChannel"].ToString();

                        string strAddreportingRule = dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString();

                        //Commented by swapnesh on 9/12/2013 for changing dropdownlist additionalrule to lable start
                        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() != "")
                        {
                            //////////////lblNewRptMngrErr.Visible = false;
                            //////////////lblNewRptMngrErr.Text = "";
                            ////////////////if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "0")
                            ////////////////{
                            ////////////////    lblNewaddlrptrule.Text = "Multiple-1";
                            ////////////////}
                            ////////////////else
                            ////////////////    if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "1")
                            ////////////////    {
                            ////////////////        lblNewaddlrptrule.Text = "Multiple-2";
                            ////////////////    }
                            ////////////////    else
                            ////////////////        if (dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim() == "2")
                            ////////////////        {
                            ////////////////            lblNewaddlrptrule.Text = "Multiple-3";
                            ////////////////        }

                            //////////////lblNewaddlrptrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[0]["AddlReportingRule"].ToString().Trim();



                        }
                        else
                        {
                            lblNewRptMngrErr.Visible = true;
                            lblNewRptMngrErr.Text = "No Record(s) Exists";
                            lblNewaddlrptrule.Text = "";
                        }
                        if (Request.QueryString["flag"] != null && Request.QueryString["flag"].ToString() == "A")
                        {
                            if (dsRpt.Tables[0].Rows[0]["Name"] != null)
                            {
                                //txtRptMgr.Text = dsRpt.Tables[0].Rows[0]["Mgr"].ToString().Trim();
                                //hdnPrimRptMgrcode.Value = dsRpt.Tables[0].Rows[0]["Mgrcode"].ToString().Trim();
                                //lblrptmgr.Text = dsRpt.Tables[0].Rows[0]["Mgrcode"].ToString().Trim();
                            }
                        }
                        GetManagers();
                        // tblRptMgrDtlsNew.Visible = true;
                        tblRptMgrDtlsNew.Style.Add("display", "block");
                        // trNwUntCode.Visible = true;
                        //funShowNewMgr(lblNewaddlrptrule.Text.Trim());
                        fillNewAddlRptMngrDtls();
                    }
                    else
                    {
                        //funShowNewMgr("empty");
                    }
                }
                else
                {
                    //funShowNewMgr("empty");
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
    }
    #endregion

    #region FillReportingMngrddl
    protected void FillReportingMngrddl()
    {
        try
        {
            oCommon.getDropDown(ddlPrimRptTyp, "Rpttype", 1, "", 1, c_strBlank);

            oCommon.getDropDown(ddlPrimbasedon, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

            ddlPrimbasedon.Items.Insert(0, new ListItem("-- Select --", ""));
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
            funchnlpopup(ddlSlsChannel);
            funchnlpopup(ddlPrimchannel);
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
            funsubchnlpopup(ddlChnCls, ddlSlsChannel.SelectedItem.Text);
            funsubchnlpopup(ddlPrimsubchannel, ddlPrimchannel.SelectedItem.Text);
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
            //funagttyppopup(ddlAgntType, ddlSlsChannel.SelectedItem.Text, ddlChnCls.SelectedItem.Text);
            //funagttyppopup(ddlPrimagttype, ddlPrimchannel.SelectedItem.Text, ddlPrimsubchannel.SelectedItem.Text);
            funagttyppopup(ddlAgntType, ddlSlsChannel.SelectedValue.ToString().Trim(), ddlChnCls.SelectedValue.ToString().Trim(), "");
            ddlAgntType.SelectedValue = ddl_NewAgnType.SelectedValue;
            funnewagttyppopup(ddlPrimagttype, "", "0");
            //funagttyppopup(ddlPrimagttype, ddlPrimchannel.SelectedValue.ToString().Trim(), ddlPrimsubchannel.SelectedValue.ToString().Trim(), ddlPrimbasedon.SelectedValue.ToString().Trim());
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
            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvNewUntLst.Rows.Count - 1; intRowCount++)
            {
                Label UntCode = (Label)gvNewUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                str = str + UntCode.Text;
                str += (intRowCount < gvNewUntLst.Rows.Count - 1) ? "," : string.Empty;
                hdnUntCode.Value = str;
            }
            if (Request.QueryString["Role"] != null)
            {
                if (Request.QueryString["Role"].ToString().Trim() == "E")
                {
                    btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + hdnBizsrc.Value.Trim() + "','" + hdnChncls.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + ddlPrimagttype.SelectedValue + "','Emp','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");
                }
                else
                    if (Request.QueryString["Role"].ToString().Trim() == "A")
                    {
                        btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + hdnBizsrc.Value.Trim() + "','" + hdnChncls.Value.Trim() + "','" + hdnagttyp.Value.Trim() + "','" + ddlPrimagttype.SelectedValue + "','','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");
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

    #region btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList arrResult = new ArrayList();
            clsChannelSetup objChnSetup = new clsChannelSetup();
            if (txtEffectdt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Effective Date');</script>", false);
                lblMessage.Text = "Please Enter Effective Date";
                lblMessage.Visible = true;
                txtEffectdt.Focus();
                return;
            }

            Hashtable htparam = new Hashtable();
            try
            {
                if (Request.QueryString["ID"].ToString() == "PU")
                {
                    Hashtable ht = new Hashtable();
                    ht.Clear();
                    ht.Add("@RefNo", hdnTrfRefNo.Value);
                    ht.Add("@AgnCd", lblAgtCodeVal.Text);
                    ht.Add("@EffDt", Convert.ToDateTime(txtEffectdt.Text.ToString().Trim()));
                    ht.Add("@Remark", txtRemark.Text.Trim());
                    ht.Add("@UpdateBy", Convert.ToString(Session["UserId"].ToString()));
                    objDAL.execute_sprc("Prc_UpdAgnPromoDt", ht);
                    ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('Promotion Date has been Updated sucessfully ');", true);
                    lblMessage.Text = "Promotion Date has been Updated sucessfully";
                    lblMessage.Visible = true;
                    btnUpdate.Enabled = false;
                    ArrayList arrLst = new ArrayList();
                    arrLst.Add(new prjXml.Collection("RefNo", hdnTrfRefNo.Value));
                    arrLst.Add(new prjXml.Collection("AgnCd", lblAgtCodeVal.Text));
                    arrLst.Add(new prjXml.Collection("EffDt", txtEffectdt.Text));
                    arrLst.Add(new prjXml.Collection("Remark", txtRemark.Text.Trim()));
                    arrLst.Add(new prjXml.Collection("UpdateBy", Convert.ToString(Session["UserId"].ToString())));
                    prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                    strXML = xDoc.OuterXml;
                    arrLst.Clear();

                }
                else
                {
                    DataSet ds = new DataSet();
                    //
                    dsResult.Clear();
                    htparam.Clear();
                    htparam.Add("@AgentCode", lblAgtCodeVal.Text.ToString());
                    htparam.Add("@CarrierCode", Session["CarrierCode"].ToString());
                    htparam.Add("@MgrCode", "");
                    htparam.Add("@flag", 2);
                    dtRead = objDAL.Common_exec_reader_prc("prc_getAgentMgrCodeAndCreateRul", htparam);
                    //dsResult = objDAL.GetDataSetForPrcCLP("prc_getAgentMgrCodeAndCreateRul", htparam);
                    string strAgntStatus = "";
                    if (dtRead.Read())
                    //if (dsResult.Tables.Count>0)
                    {
                        strAgntStatus = dtRead[0].ToString();
                    }
                    dtRead.Close();

                    string strPrmAgntStatus = "";
                    string strAgtTypeCheck = "";
                    int cnt = 0;
                    for (int j = 0; gvNew.Rows.Count > j; j++)
                    {
                        Label MemCode = (Label)gvNew.Rows[j].FindControl("lblMemCode");
                        htparam.Clear();
                        htparam.Add("@AgentCode", MemCode.Text);
                        htparam.Add("@CarrierCode", Session["CarrierCode"].ToString());
                        htparam.Add("@MgrCode", "");
                        htparam.Add("@flag", 2);
                        dtRead = objDAL.Common_exec_reader_prc("prc_getAgentMgrCodeAndCreateRul", htparam);

                        if (dtRead.Read())
                        {
                            if (dtRead[0].ToString() == "IF")
                            {
                                cnt++;
                            }

                        }

                        if (cnt == j + 1)
                        {
                            strPrmAgntStatus = "IF";
                        }
                        dtRead.Close();
                    }

                    cnt = 0;

                    for (int j = 0; gvNew.Rows.Count > j; j++)
                    {
                        Label MemCode = (Label)gvNew.Rows[j].FindControl("lblMemCode");
                        hdnPrimRptMgrcode.Value = MemCode.Text;
                        htparam.Clear();
                        htparam.Add("@AgentCode", MemCode.Text);
                        htparam.Add("@CarrierCode", Session["CarrierCode"].ToString());
                        htparam.Add("@AgentType", ddlPrimagttype.SelectedValue.ToString().Trim());
                        htparam.Add("@Flag", 2);
                        dtRead = objDAL.Common_exec_reader_prc("Prc_GetDetailvAgent", htparam);

                        if (dtRead.Read())
                        {

                            //strAgtTypeCheck = dtRead[0].ToString();
                            if (dtRead[0].ToString() == "1")
                            {
                                cnt++;
                            }

                        }

                        if (cnt == j + 1)
                        {
                            strAgtTypeCheck = "1";
                        }
                        dtRead.Close();
                    }
                    //if (Session["PrimMgrMnd"].ToString() == "yes")
                    //{
                    //    if (txtRptMgr.Text == "")
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Select Primary Manager');</script>", false);
                    //        return;
                    //    }
                    //}

                    #region Main Update Part
                    if (strPrmAgntStatus == "IF" && strAgntStatus == "IF")
                    {
                        if (strAgtTypeCheck == "1")
                        {
                            try
                            {
                                objSQLConForTran = objDAL.GetSQLConnection_Common();

                                if (objSQLConForTran.State != ConnectionState.Open)
                                {
                                    objSQLConForTran.Open();
                                }
                                objSQLTran = objSQLConForTran.BeginTransaction();

                                Hashtable ht3 = new Hashtable();
                                ht3.Add("@AgentCode", lblAgtCodeVal.Text);
                                ht3.Add("@EffectiveDate", Convert.ToDateTime(txtEffectdt.Text.ToString().Trim()));
                                ht3.Add("@AgentType", hdnagttyp.Value);
                                ht3.Add("@DirectAgtCode", "");
                                ht3.Add("@PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim());
                                ht3.Add("@Remark", txtRemark.Text);
                                ht3.Add("@RptAgtType", ddlPrimagttype.SelectedValue.ToString().Trim());
                                ht3.Add("@RptAgtCode", hdnPrimRptMgrcode.Value);
                                ht3.Add("@NewUntCode", hdnUntCode.Value);
                                ht3.Add("@ChnCls", hdnChncls.Value);
                                ht3.Add("@Bizsrc", hdnBizsrc.Value);
                                ht3.Add("@PrmDemType", ddlAgPro.SelectedItem.Text.Trim());
                                ht3.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
                                ht3.Add("@PromoType", ddlPromoType.SelectedItem.Text.Trim());
                                if (ddlPromoType.SelectedItem.Text.Trim() == "Exception Promotion")
                                {
                                    ht3.Add("@KPI", ddlKPIParam.SelectedItem.Text.Trim());
                                }
                                else
                                {
                                    ht3.Add("@KPI", "");
                                }
                                //ArrayList arrLst = new ArrayList();
                                //arrLst.Add(new prjXml.Collection("AgentCode", lblAgtCodeVal.Text));
                                //arrLst.Add(new prjXml.Collection("EffectiveDate", txtEffectdt.Text));
                                //arrLst.Add(new prjXml.Collection("AgentType", hdnagttyp.Value));
                                //arrLst.Add(new prjXml.Collection("DirectAgtCode", ""));
                                //arrLst.Add(new prjXml.Collection("PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim()));
                                //arrLst.Add(new prjXml.Collection("Remark", txtRemark.Text));
                                //arrLst.Add(new prjXml.Collection("RptAgtType", ddlPrimagttype.SelectedValue.ToString().Trim()));
                                //arrLst.Add(new prjXml.Collection("RptAgtCode", hdnPrimRptMgrcode.Value));
                                //arrLst.Add(new prjXml.Collection("NewUntCode", hdnUntCode.Value));
                                //arrLst.Add(new prjXml.Collection("ChnCls", hdnChncls.Value));
                                //arrLst.Add(new prjXml.Collection("Bizsrc", hdnBizsrc.Value));
                                //arrLst.Add(new prjXml.Collection("PrmDemType", ddlAgPro.SelectedItem.Text.Trim()));
                                //arrLst.Add(new prjXml.Collection("CreateBy", Convert.ToString(Session["UserId"].ToString())));
                                //arrLst.Add(new prjXml.Collection("PromoType", ddlPromoType.SelectedItem.Text.Trim()));
                                //if (ddlPromoType.SelectedItem.Text.Trim() == "Exception Promotion")
                                //{
                                //    arrLst.Add(new prjXml.Collection("KPI", ddlKPIParam.SelectedItem.Text.Trim()));
                                //}
                                //prjXml.XmlGenerator objGetXml = new prjXml.XmlGenerator();
                                //XmlDocument xDoc = new XmlDocument();
                                //xDoc = objGetXml.CreateXmlAttribute(arrLst, arrLst.Count);
                                //strXML = xDoc.OuterXml;
                                //arrLst.Clear();
                                //objDAL.execute_sprc("Prc_pd_InsertAgtData", ht3);

                                arrResult = agtObject.InsertPrmtDmtDetails(ht3, "Prc_pd_InsertAgtData");

                                if (arrResult.Count > 0)
                                {
                                    if (arrResult[0].ToString().Equals("0"))
                                    {
                                        #region Promotion-Demotion Main table entry for Old Details

                                        InsPrmtDmtDtlsOld(0);

                                        for (int i = 0; gv_RptMngr_Crnt.Rows.Count > i; i++)
                                        {
                                            Label lblNo = gv_RptMngr_Crnt.Rows[i].FindControl("lblNo") as Label;
                                            InsPrmtDmtDtlsOld(Convert.ToInt32(lblNo.Text.Trim()));
                                        }
                                        #endregion

                                        #region Promotion-Demotion Main table entry for New Details
                                        for (int i = 0; gvNewUntLst.Rows.Count > i; i++)
                                        {
                                            Label lblUntCode = (Label)gvNewUntLst.Rows[i].FindControl("lblUntCode");
                                            hdnUntCode.Value = lblUntCode.Text;
                                            for (int j = 0; gvNew.Rows.Count > j; j++)
                                            {
                                                Label MemCode = (Label)gvNew.Rows[j].FindControl("lblMemCode");
                                                InsPrmtDmtDtls(0, ddlPrimRptTyp.SelectedValue, ddlPrimchannel.SelectedValue, ddlPrimsubchannel.SelectedValue, ddlPrimagttype.SelectedValue, lblUntCode.Text, MemCode.Text);
                                            }
                                        }
                                        for (int i = 0; gvNewUntLst.Rows.Count > i; i++)
                                        {
                                            Label lblUntCode = (Label)gvNewUntLst.Rows[i].FindControl("lblUntCode");
                                            hdnUntCode.Value = lblUntCode.Text;
                                            for (int k = 0; gv_RptMngr_new.Rows.Count > k; k++)
                                            {
                                                GridView gvNewAddlMgr = gv_RptMngr_new.Rows[k].FindControl("gvNewAddlMgr") as GridView;

                                                for (int ig = 0; gvNewAddlMgr.Rows.Count > ig; ig++)
                                                {
                                                    Label RptMemCode = (Label)gvNewAddlMgr.Rows[ig].FindControl("lblMemCode");
                                                    Label lblNo = gv_RptMngr_new.Rows[i].FindControl("lblNo") as Label;
                                                    DropDownList ddlAdlRptTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
                                                    DropDownList ddlAdlChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn") as DropDownList;
                                                    DropDownList ddlAdlSChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
                                                    DropDownList ddlAdlAgtTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
                                                    HiddenField hdnAddlRptMgr = gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;

                                                    InsPrmtDmtDtls(Convert.ToInt32(lblNo.Text.Trim()), ddlAdlRptTyp.SelectedValue, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlAdlAgtTyp.SelectedValue, lblUntCode.Text, RptMemCode.Text);
                                                }
                                            }
                                        }
                                        #endregion

                                        if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Promotion))
                                        {
                                            lbl3.Text = "Promotion Request Sent sucessfully" + "</br></br> Agent Code: " + lblAgtCodeVal.Text + "</br></br> Agent Type: " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedValue;
                                            mdlpopup.Show();
                                            lblMessage.Text = "Promotion request Sent sucessfully";
                                            lblMessage.Visible = true;
                                        }
                                        else if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Demotion))
                                        {
                                            lbl3.Text = "Demotion Request Sent sucessfully" + "</br></br> Agent Code: " + lblAgtCodeVal.Text + "</br></br> Agent Type: " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedValue;
                                            mdlpopup.Show();
                                            lblMessage.Text = "Demotion Request Sent sucessfully";
                                            lblMessage.Visible = true;
                                        }
                                        btnUpdate.Enabled = false;
                                        objSQLTran.Commit();
                                    }

                                    else
                                    {
                                        switch (arrResult[0].ToString())
                                        {
                                            case "-1": lblMessage.Text = "Downlines should be transfered before promotion/demotion";
                                                break;
                                            case "-2": lblMessage.Text = "Promotion/Demotion request has been already sent.";
                                                break;
                                        }
                                        lblMessage.Visible = true;
                                        objSQLTran.Rollback();
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                objSQLTran.Rollback();
                                string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                                System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                                string sRet = oInfo.Name;
                                System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                                String LogClassName = method.ReflectedType.Name;
                                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Reporting AgentType and Reporting AgentCode do not match.";
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Error Updating Agent Details- Agent Status Not IF In Frontend";
                        lblMessage.Visible = true;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
            string procname = "";
            string strAgntCode = "";
            strAgntCode = lblAgtCodeVal.Text;

            if (lblMessage.Text == "Promotion request has been sent sucessfully" || lblMessage.Text == "Demotion request has been sent sucessfully" || lblMessage.Text == "Promotion Date has been Updated sucessfully")
            {
                ErrMsg = "S";
            }
            else
            {
                ErrMsg = "E";
            }
            if (Request.QueryString["ID"] == "PR")
            {
                AuditType = "IN";
                procname = "Prc_pd_InsertAgtData";
            }
            else
            {
                AuditType = "UP";
                procname = "Prc_UpdAgnPromoDt";
            }

            //Added by ashitosh for promotion/demotion approval directly 

          btnApprove_Click(this, EventArgs.Empty);

            string SeqNo = "1", ErrNo = "1", ErrType = "1", ErrSrc = "", ErrCode = "", ErrDsc = lblMessage.Text, ErrDtl = "";
            ErrSrc = "SQ";
            objChnSetup.iAuditLog(ErrMsg, AuditType, Session["CarrierCode"].ToString() + strAgntCode, "AGTPromotion", "Promotion,DataAccessLayer.cs", procname, Convert.ToString(Session["UserId"].ToString()), System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString(), SeqNo, "", strXML, ErrNo, ErrType, ErrSrc, ErrCode, ErrDsc, ErrDtl);
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

    #region btnApprove_Click
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            #region Insert reporting manager
            InsRptPrmtDmtDtls(0, ddlPrimRptTyp.SelectedValue, ddlPrimchannel.SelectedValue, ddlPrimsubchannel.SelectedValue, ddlPrimagttype.SelectedValue, hdnPrimRptMgrcode.Value);
            //for (int i = 0; gv_RptMngr_new.Rows.Count > i; i++)
            //{
            //    Label lblNo = gv_RptMngr_new.Rows[i].FindControl("lblNo") as Label;
            //    DropDownList ddlAdlRptTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlRptTyp") as DropDownList;
            //    DropDownList ddlAdlChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlChn") as DropDownList;
            //    DropDownList ddlAdlSChn = gv_RptMngr_new.Rows[i].FindControl("ddlAdlSChn") as DropDownList;
            //    DropDownList ddlAdlAgtTyp = gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp") as DropDownList;
            //    HiddenField hdnAddlRptMgr = gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr") as HiddenField;
            //    HiddenField hdnRptMgrMandatory = gv_RptMngr_new.Rows[i].FindControl("hdnRptMgrMandatory") as HiddenField;
            //    InsRptPrmtDmtDtls(Convert.ToInt16(lblNo.Text), ddlAdlRptTyp.SelectedValue, ddlAdlChn.SelectedValue, ddlAdlSChn.SelectedValue, ddlAdlAgtTyp.SelectedValue, hdnAddlRptMgr.Value);
            //}
            #endregion

            Hashtable ht3 = new Hashtable();
            DataSet ds = new DataSet();
            ht3.Clear();
            ds.Clear();
            ht3.Add("@AgentCode", lblAgtCodeVal.Text);
            ht3.Add("@EffectiveDate", Convert.ToDateTime(txtEffectdt.Text.ToString().Trim()));
            ht3.Add("@AgentType", hdnagttyp.Value);
            ht3.Add("@DirectAgtCode", "");
            ht3.Add("@PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim());
            ht3.Add("@Remark", txtRemark.Text);
            ht3.Add("@RptAgtType", ddlPrimagttype.SelectedValue.ToString().Trim());
            ht3.Add("@RptAgtCode", hdnPrimRptMgrcode.Value);
            ht3.Add("@NewUntCode", hdnUntCode.Value);
            ht3.Add("@ChnCls", hdnChncls.Value);
            ht3.Add("@Bizsrc", hdnBizsrc.Value);
            ht3.Add("@PrmDemType", ddlAgPro.SelectedItem.Text.Trim());
            ht3.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            ht3.Add("@PromoType", ddlPromoType.SelectedItem.Text.Trim());
            if (ddlPromoType.SelectedItem.Text.Trim() == "Exception Promotion")
            {
                ht3.Add("@KPI", ddlKPIParam.SelectedItem.Text.Trim());
            }
            else
            {
                ht3.Add("@KPI", "");
            }
            ds = objDAL.GetDataSetForPrc("Prc_pd_ApproveAgtData", ht3);
            if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Promotion))
            {
                lbl3.Text = "Promotion Request Approved sucessfully" + "</br></br> Agent Code: " + lblAgtCodeVal.Text + "</br></br> Agent Type: " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedItem.Text;
                mdlpopup.Show();
                lblMessage.Text = "Promotion request Approved sucessfully";
                lblMessage.Visible = true;
                PRM_Mail(lblAgtCodeVal.Text.ToString().Trim());
            }
            else if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Demotion))
            {
                lbl3.Text = "Demotion Request Approved sucessfully" + "</br></br> Agent Code: " + lblAgtCodeVal.Text + "</br></br> Agent Type: " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedItem.Text;
                mdlpopup.Show();
                lblMessage.Text = "Demotion Request Approved sucessfully";
                lblMessage.Visible = true;
                DEM_Mail(lblAgtCodeVal.Text.ToString().Trim());
            }
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
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

    #region btnReject_Click
    protected void btnReject_Click(object sender, EventArgs e)
    {
        Hashtable htrej = new Hashtable();
        DataSet dsrej = new DataSet();
        htrej.Clear();
        dsrej.Clear();
        htrej.Add("@AgentCode", lblAgtCodeVal.Text);
        htrej.Add("@PrmDemType", ddlAgPro.SelectedValue);
        htrej.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
        dsrej = objDAL.GetDataSetForPrc("Prc_pd_RejectAgtData", htrej);
        if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Promotion))
        {
            lbl3.Text = "Promotion Request Rejected sucessfully" + "</br></br> Agent Code " + lblAgtCodeVal.Text + "</br></br> Agent Type " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedValue;
            mdlpopup.Show();
            lblMessage.Text = "Promotion request Rejected sucessfully";
            lblMessage.Visible = true;
        }
        else if (ddlAgPro.SelectedItem.Text.Trim() == Convert.ToString(PrmDemType.Demotion))
        {
            lbl3.Text = "Demotion Request Rejected sucessfully" + "</br></br> Agent Code " + lblAgtCodeVal.Text + "</br></br> Agent Type " + strAgentType + "-" + lblAgntTypeVal.Text + "</br></br> New Agent Type: " + ddl_NewAgnType.SelectedValue;
            mdlpopup.Show();
            lblMessage.Text = "Demotion Request Rejected sucessfully";
            lblMessage.Visible = true;
        }
        btnApprove.Enabled = false;
        btnReject.Enabled = false;
    }
    #endregion

    #region InsRptPrmtDmtDtls
    public void InsRptPrmtDmtDtls(int relorder, string reltyp, string RelBizsrc, string RelChnCls, string RelAgenttype, string RelAgentcode)
    {
        try
        {
            Hashtable htmgrprm = new Hashtable();
            DataSet dsrptmgr = new DataSet();
            htmgrprm.Clear();
            dsrptmgr.Clear();

            htmgrprm.Add("@AgentCode ", lblAgtCodeVal.Text);
            htmgrprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htmgrprm.Add("@BizSrc ", hdnBizsrc.Value);
            htmgrprm.Add("@ChnSubCls", hdnChncls.Value);
            htmgrprm.Add("@AgentType", hdnagttyp.Value);
            htmgrprm.Add("@PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim());

            htmgrprm.Add("@relorder", relorder);
            htmgrprm.Add("@reltyp", reltyp);
            htmgrprm.Add("@RelBizsrc", RelBizsrc);
            htmgrprm.Add("@RelChnCls", RelChnCls);
            htmgrprm.Add("@RelAgenttype", RelAgenttype);
            htmgrprm.Add("@RelAgentcode", RelAgentcode);
            htmgrprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            dsrptmgr = objDAL.GetDataSetForPrc("Prc_AgyAdmin_InsAgtPrmtDmtRptMgrDtls", htmgrprm);
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

    #region InsPrmtDmtDtlsOld
    public void InsPrmtDmtDtlsOld(int relorder)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();

            htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
            htprm.Add("@EffectiveDate", Convert.ToDateTime(txtEffectdt.Text.ToString().Trim()));
            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htprm.Add("@BizSrc ", hdnBizsrc.Value);
            htprm.Add("@ChnSubCls", hdnChncls.Value);
            htprm.Add("@AgentType", hdnagttyp.Value);
            htprm.Add("@DirectAgtCode", "");
            htprm.Add("@PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim());
            htprm.Add("@Remark", txtRemark.Text);
            htprm.Add("@RptAgtType", ddlPrimagttype.SelectedValue.ToString().Trim());
            htprm.Add("@RptAgtCode", hdnPrimRptMgrcode.Value);
            htprm.Add("@NewUntCode", hdnUntCode.Value);
            htprm.Add("@PrmDemType", ddlAgPro.SelectedItem.Text.Trim());
            htprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            htprm.Add("@PromoType", ddlPromoType.SelectedItem.Text.Trim());

            htprm.Add("@relorder", relorder);
            dsprm = objDAL.GetDataSetForPrc("Prc_pd_InsAgtPrmtDmtOldRptMgrDtls", htprm);
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

    #region InsPrmtDmtDtls
    public void InsPrmtDmtDtls(int relorder, string reltyp, string RelBizsrc, string RelChnCls, string RelAgenttype, string NewUntCode, string RelAgentcode)
    {
        try
        {
            Hashtable htprm = new Hashtable();
            DataSet dsprm = new DataSet();
            htprm.Clear();
            dsprm.Clear();

            htprm.Add("@AgentCode ", lblAgtCodeVal.Text);
            htprm.Add("@EffectiveDate", Convert.ToDateTime(txtEffectdt.Text.ToString().Trim()));
            htprm.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htprm.Add("@BizSrc ", hdnBizsrc.Value);
            htprm.Add("@ChnSubCls", hdnChncls.Value);
            htprm.Add("@AgentType", hdnagttyp.Value);
            htprm.Add("@DirectAgtCode", "");
            htprm.Add("@PrmAgtType", ddl_NewAgnType.SelectedValue.ToString().Trim());
            htprm.Add("@Remark", txtRemark.Text);
            htprm.Add("@RptAgtType", ddlPrimagttype.SelectedValue.ToString().Trim());
            htprm.Add("@RptAgtCode", RelAgentcode);
            htprm.Add("@NewUntCode", NewUntCode);
            htprm.Add("@PrmDemType", ddlAgPro.SelectedItem.Text.Trim());
            htprm.Add("@CreateBy", Convert.ToString(Session["UserId"].ToString()));
            htprm.Add("@PromoType", ddlPromoType.SelectedItem.Text.Trim());

            htprm.Add("@relorder", relorder);
            htprm.Add("@reltyp", reltyp);
            htprm.Add("@RelBizsrc", RelBizsrc);
            htprm.Add("@RelChnCls", RelChnCls);
            htprm.Add("@RelAgenttype", RelAgenttype);
            htprm.Add("@RelAgentcode", RelAgentcode);
            dsprm = objDAL.GetDataSetForPrc("Prc_pd_InsAgtPrmtDmtRptMgrDtls", htprm);
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
        if (Request.QueryString["flag"] != null && Request.QueryString["flag"].ToString() == "A")
        {
            Response.Redirect("MemMvmtAppr.aspx", true);
        }
        else
        {
            //Response.Redirect(ViewState["BackUrl"].ToString());
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
        ///FillMgrDetails();
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
            dtRead = objDAL.Common_exec_reader_prc("Prc_ddlchnnlsubcls", htparam);
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
                // tblReportingMngrDtls.Visible = false;
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
        txtNewUntCode.Text = "";
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
                // tblReportingMngrDtls.Visible = false;
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
        txtNewUntCode.Text = "";
        #endregion
    }
    #endregion

    #region ChkMandMgr
    protected void ChkMandMgr()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            DataSet dsRpt = new DataSet();
            htParam.Clear();
            dsRpt.Clear();

            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue);
            htParam.Add("@ChnCls", ddlChnCls.SelectedValue);
            htParam.Add("@AgentType", ddlAgntType.SelectedValue);
            dsRpt = objDAL.GetDataSetForPrc("Prc_GetDataforAgencyChnl", htParam);

            if (dsRpt.Tables.Count > 0 && dsRpt.Tables[0].Rows.Count > 0)
            {
                if (dsRpt.Tables[0].Rows[0]["IsPriMand"].ToString() == "True")
                {
                    //txtRptMgr.Attributes.Add("BackColor", "#FFFFB2");
                    //txtRptMgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                    Session["PrimMgrMnd"] = "yes";
                }
                else
                {
                    Session["PrimMgrMnd"] = "no";
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

    #region hideNewDtls
    public void hideNewDtls()
    {
        //tblRptMgrDtlsNew.Visible = false;
        // tblRptMgrDtlsNew.Style.Add("display", "none");

        txtRptMgr.Text = "";
        lblPrimRptMgrcode.Text = "";
        hdnPrimRptMgrcode.Value = null;

        txtNewUntCode.Text = "";
        lblUnitDesc.Text = "";
        hdnUntCode.Value = null;

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
            htParam.Add("@AgentType", hdnagttyp.Value.Trim());
            htParam.Add("@MemCode", lblAgtCodeVal.Text.Trim());
            dsRpt = objDAL.GetDataSetForPrc("Prc_GetCrntAddlMngrgrdDtls_PrmDmt", htParam);

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
                htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
                htParam.Add("@ChnCls", hdnChncls.Value.Trim());
                htParam.Add("@AgentType", ddl_NewAgnType.SelectedValue.Trim());
                dsRpt = objDAL.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls", htParam);
            }
            else
            {
                htParam.Add("@BizSrc", hdnBizsrc.Value.Trim());
                htParam.Add("@ChnCls", hdnChncls.Value.Trim());
                htParam.Add("@AgentType", ddl_NewAgnType.SelectedValue.Trim());
                htParam.Add("@MgrCode", lblAgtCodeVal.Text.Trim());
                dsRpt = objDAL.GetDataSetForPrc("Prc_GetAddlMngrgrdDtls_pd_Approve", htParam);
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

                GridView gvNewAddlMgr = gv_RptMngr_new.Rows[i].FindControl("gvNewAddlMgr") as GridView;

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

                DropDownList ddlAdlAgtTyp = (DropDownList)gv_RptMngr_new.Rows[i].FindControl("ddlAdlAgtTyp");
                HiddenField hdnAdMemType = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAdMemType");
                //ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemOrLevelType"].ToString();
                #region fetch member type

                if (Request.QueryString["Type"] != null)
                {
                    if (hdnAddlStp.Value.Trim().ToString() == "E" && ddlAdlBsdOn.SelectedValue == "1")
                    {
                        if (Request.QueryString["flag"] == null)
                        {

                            ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[0].Rows[i]["MemType"].ToString();
                            ddlAdlAgtTyp.Enabled = true;
                            //ddllvlagttype.SelectedValue = dsRpt.Tables[0].Rows[0]["PrimaryMemOrLevelType"].ToString().Trim();
                        }
                        else
                        {
                            ddlAdlAgtTyp.SelectedValue = dsRpt.Tables[1].Rows[i]["MemType"].ToString();
                            ddlAdlAgtTyp.Enabled = true;
                        }
                    }
                    else
                    {
                        if (Request.QueryString["flag"] == null)
                        {
                            hdnAdMemType.Value = dsRpt.Tables[0].Rows[i]["MemType"].ToString().Trim();
                            ddlAdlAgtTyp.Enabled = true;
                        }
                        else
                        {
                            hdnAdMemType.Value = dsRpt.Tables[1].Rows[i]["MemType"].ToString().Trim();
                            ddlAdlAgtTyp.Enabled = true;
                        }
                    }
                }
                #endregion

                // sandeep


                if (dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim() != null)
                {
                    lblRptMngrErr.Visible = false;
                    lblRptMngrErr.Text = "";
                    lbladditionalreportingrule.Text = "Multiple-" + dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim();
                    funnewagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, dsRpt.Tables[0].Rows[i]["RelOrder"].ToString().Trim());
                    lbladditionalreportingrule.Visible = true;
                }
                else
                {
                    lblRptMngrErr.Visible = true;
                    lblRptMngrErr.Text = "No Records Exists";
                    lbladditionalreportingrule.Text = "";
                }

                //sandeep
                TextBox txtRptMngr = (TextBox)gv_RptMngr_new.Rows[i].FindControl("txtRptMngr");
                Label lblmndtry = (Label)gv_RptMngr_new.Rows[i].FindControl("lblmndtry");
                HiddenField hdnRptMgrMandatory = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnRptMgrMandatory");
                hdnRptMgrMandatory.Value = dsRpt.Tables[0].Rows[i]["IsMandatory"].ToString();

                if (hdnRptMgrMandatory.Value == "1")
                {
                    txtRptMngr.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFB2");
                    lblmndtry.Visible = true;
                }

                if (Request.QueryString["flag"] != null)
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "A")
                    {
                        //txtRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgr"].ToString();
                        Label lblRptMngr = (Label)gv_RptMngr_new.Rows[i].FindControl("lblRptMngr");
                        HiddenField hdnAddlRptMgr = (HiddenField)gv_RptMngr_new.Rows[i].FindControl("hdnAddlRptMgr");
                        //hdnAddlRptMgr.Value = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();
                        //lblRptMngr.Text = dsRpt.Tables[0].Rows[i]["RptMgrCode"].ToString();

                        gvNewAddlMgr.DataSource = dsRpt.Tables[1];
                        gvNewAddlMgr.DataBind();
                        gvNewAddlMgr.Columns[4].Visible = false;
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
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkRptMngr = (LinkButton)grd.FindControl("lnkRptMngr");
        DropDownList ddlAdlRptTyp = (DropDownList)grd.FindControl("ddlAdlRptTyp");
        DropDownList ddlAdlBsdOn = (DropDownList)grd.FindControl("ddlAdlBsdOn");
        DropDownList ddlAdlChn = (DropDownList)grd.FindControl("ddlAdlChn");
        DropDownList ddlAdlSChn = (DropDownList)grd.FindControl("ddlAdlSChn");
        DropDownList ddlAdlAgtTyp = (DropDownList)grd.FindControl("ddlAdlAgtTyp");
        TextBox txtRptMngr = (TextBox)grd.FindControl("txtRptMngr");
        string strRowID = ((System.Web.UI.Control)(grd)).ClientID.ToString();
        string rowid = grd.RowIndex.ToString().Trim();

        string str = string.Empty;
        for (int intRowCount = 0; intRowCount <= gvNewUntLst.Rows.Count - 1; intRowCount++)
        {
            Label UntCode = (Label)gvNewUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
            str = str + UntCode.Text;
            str += (intRowCount < gvNewUntLst.Rows.Count - 1) ? "," : string.Empty;
        }

        if (str != "")
        {
            if (Request.QueryString["Ctgry"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "','" + str + "','" + rowid + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcgridMgrShowPopup('rptmgr','" + ddlAdlChn.SelectedValue + "','" + ddlAdlSChn.SelectedValue + "','" + ddlAdlAgtTyp.SelectedValue + "','','" + ddlAdlBsdOn.SelectedValue + "','" + strRowID + "','" + str + "','" + rowid + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Fill Unit Code Details.');</script>", false);
            return;
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
            htparam.Add("@BizSrc", hdnBizsrc.Value);
            htparam.Add("@ChnCls", hdnChncls.Value);
            htparam.Add("@MemType", hdnagttyp.Value);
            htparam.Add("@RelOrder", order);
            dtRead = objDAL.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
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
            htparam.Add("@MemType", ddl_NewAgnType.SelectedValue);
            htparam.Add("@RelOrder", order);
            dtRead = objDAL.Common_exec_reader_prc("Prc_GetRptAgtTyp_AgtInfo", htparam);
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
                //DropDownList ddlAdlRptTyp = (DropDownList)e.Row.FindControl("ddlAdlRptTyp");
                //DropDownList ddlAdlBsdOn = (DropDownList)e.Row.FindControl("ddlAdlBsdOn");

                //DropDownList ddlAdlChn = (DropDownList)e.Row.FindControl("ddlAdlChn");
                //DropDownList ddlAdlSChn = (DropDownList)e.Row.FindControl("ddlAdlSChn");
                //DropDownList ddlAdlAgtTyp = (DropDownList)e.Row.FindControl("ddlAdlAgtTyp");

                oCommon.getDropDown(ddlventype, "ventype", 1, "", 1, c_strBlank);
                oCommon.getDropDown(ddlRelModel, "AgVenMapTyp", HttpContext.Current.Session["UserLangNum"].ToString(), "", 1);
                //oCommon.getDropDown(ddlAdlBsdOn, "LvlAgtTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                //ddlAdlBsdOn.Items.Insert(0, new ListItem("--Select--", ""));


                //funchnlpopup(ddlAdlChn);
                //funsubchnlpopup(ddlAdlSChn, ddlAdlChn.SelectedValue.Trim());
                //funagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, Mngrno.Text);
                //oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                //ddlAdlRptTyp.Items.Insert(0, new ListItem("--Select--", ""));
                //ddlAdlChn.Items.Insert(0, new ListItem("--Select--", ""));
                //ddlAdlSChn.Items.Insert(0, new ListItem("--Select--", ""));
                //ddlAdlAgtTyp.Items.Insert(0, new ListItem("--Select--", ""));

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
                ddlAdlBsdOn.Items.Insert(0, new ListItem("Select", ""));


                funchnlpopup(ddlAdlChn);
                funsubchnlpopup(ddlAdlSChn, ddlAdlChn.SelectedValue.Trim());
                funnewagttyppopup(ddlAdlAgtTyp, ddlAdlBsdOn.SelectedValue, Mngrno.Text);
                oCommon.getDropDown(ddlAdlRptTyp, "RptType", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
                ddlAdlRptTyp.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlSChn.Items.Insert(0, new ListItem("Select", ""));
                ddlAdlAgtTyp.Items.Insert(0, new ListItem("Select", ""));

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
    protected string RetMemType(string Urnk, string bizsrc, string chncls)
    {
        Hashtable htunt = new Hashtable();
        DataSet dsunt = new DataSet();
        string member = String.Empty;
        htunt.Clear();
        htunt.Add("@BizSrc", bizsrc.ToString().Trim());
        htunt.Add("@ChnCls", chncls.ToString().Trim());
        htunt.Add("@UnitRank", Urnk.ToString().Trim());
        dsunt = objDAL.GetDataSetForPrcCLP("PrcGetMemUnitRnk", htunt);
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

    protected void ddlPrimagttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetManagers();
    }

    private void PRM_Mail(string MemCode)
    {

        //MAIL Communication integration
        string strUserID = Session["UserID"].ToString();
        Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        ds.Clear();
        htData.Add("@AppFlag", "CHMS");
        htData.Add("@Param1", "MVMT");
        htData.Add("@Param2", "MEMPRM");
        htData.Add("@Param3", "EMPPRM");
        ds = objDAC.GetDataSetForMailPrc("Prc_GetMailParams_CHMS", htData);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                    //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    objmailcomm.SendNoticationMailSMS("CHMS", "MVMT", "MEMPRM", "EMPPRM", "", "", NotifyTo, MemCode.ToString().Trim(), HttpContext.Current.Session["UserID"].ToString());
                }
            }
        }
        //MAIL
    }

    private void DEM_Mail(string MemCode)
    {

        //MAIL Communication integration
        string strUserID = Session["UserID"].ToString();
        Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        ds.Clear();
        htData.Add("@AppFlag", "CHMS");
        htData.Add("@Param1", "MVMT");
        htData.Add("@Param2", "MEMDEM");
        htData.Add("@Param3", "EMPDEM");
        ds = objDAC.GetDataSetForMailPrc("Prc_GetMailParams_CHMS", htData);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                    //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    objmailcomm.SendNoticationMailSMS("CHMS", "MVMT", "MEMDEM", "EMPDEM", "", "", NotifyTo, MemCode.ToString().Trim(), HttpContext.Current.Session["UserID"].ToString());
                }
            }
        }
        //MAIL
    }

    #region btnunitgrid_Click
    protected void btnunitgrid_Click(object sender, EventArgs e)
    {
        //changed session[unt1] to session[unt]
        if (Session["unt"] != null)
        {
            gvNewUntLst.DataSource = Session["unt"];
            gvNewUntLst.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvNewUntLst.Rows.Count - 1; intRowCount++)
            {
                Label UntCode = (Label)gvNewUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                str = str + UntCode.Text;
                str += (intRowCount < gvNewUntLst.Rows.Count - 1) ? "," : string.Empty;
                hdnUntCode.Value = str;
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlPrimchannel.SelectedValue.Trim() + "','" + ddlPrimsubchannel.SelectedValue.Trim() + "','" + ddlAgntType.SelectedValue.ToString().Trim() + "','" + ddlPrimagttype.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

            }
            else
            {
                btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlPrimchannel.SelectedValue.Trim() + "','" + ddlPrimsubchannel.SelectedValue.Trim() + "','" + ddlAgntType.SelectedValue.ToString().Trim() + "','" + ddlPrimagttype.SelectedValue + "','','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

            }

        }
    }
    #endregion

    #region btnmemgrid_Click
    protected void btnmemgrid_Click(object sender, EventArgs e)
    {
        //changed Session["mem1"] to Session["mem"]
        if (Session["mem"] != null)
        {
            gvNew.DataSource = Session["mem"];
            gvNew.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvNew.Rows.Count - 1; intRowCount++)
            {
                Label MemCode = (Label)gvNew.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
                str = str + MemCode.Text;
                str += (intRowCount < gvNew.Rows.Count - 1) ? "," : string.Empty;
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                btnRptUnitSearch.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Emp','','" + str + "');return false;");
            }
            else
            {
                btnRptUnitSearch.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Agent','','" + str + "');return false;");
            }
        }

        divHirarchyDtlsNewHdr.Style.Add("display", "none");
        divprirptHdr.Style.Add("display", "block");
        divNewMngrDtlsHdr.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn-subtab btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";
    }
    #endregion

    #region btnRptmemgrid_Click
    protected void btnRptmemgrid_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((Button)sender).NamingContainer as GridViewRow;
        GridView gvNewAddlMgr = (GridView)grd.FindControl("gvNewAddlMgr");
        if (Session["addlmem1"] != null)
        {
            gvNewAddlMgr.DataSource = Session["addlmem1"];
            gvNewAddlMgr.DataBind();
        }


    }
    #endregion


    protected void gvNewUntLst_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["unt1"];
        if (dt.Rows.Count >= 0)
        {
            dt.Rows.RemoveAt(Convert.ToInt32(e.RowIndex));
            Session["unt1"] = dt;
            gvNewUntLst.DataSource = dt;
            gvNewUntLst.DataBind();

            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvNewUntLst.Rows.Count - 1; intRowCount++)
            {
                Label UntCode = (Label)gvNewUntLst.Rows[intRowCount].Cells[0].FindControl("lblUntCode");
                str = str + UntCode.Text;
                str += (intRowCount < gvNewUntLst.Rows.Count - 1) ? "," : string.Empty;
                hdnUntCode.Value = str;
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlPrimchannel.SelectedValue.Trim() + "','" + ddlPrimsubchannel.SelectedValue.Trim() + "','" + ddlAgntType.SelectedValue.ToString().Trim() + "','" + ddlPrimagttype.SelectedValue + "','" + Request.QueryString["Ctgry"].ToString() + "','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

            }
            else
            {
                btnRptMgr.Attributes.Add("onclick", "funcMgrShowPopup('rptmgr','" + ddlPrimchannel.SelectedValue.Trim() + "','" + ddlPrimsubchannel.SelectedValue.Trim() + "','" + ddlAgntType.SelectedValue.ToString().Trim() + "','" + ddlPrimagttype.SelectedValue + "','','" + ddlPrimbasedon.SelectedValue.ToString().Trim() + "','" + str + "');return false;");

            }
        }
    }
    protected void gvNew_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["mem1"];
        if (dt.Rows.Count >= 0)
        {
            dt.Rows.RemoveAt(Convert.ToInt32(e.RowIndex));
            Session["mem1"] = dt;
            gvNew.DataSource = dt;
            gvNew.DataBind();
            string str = string.Empty;
            for (int intRowCount = 0; intRowCount <= gvNew.Rows.Count - 1; intRowCount++)
            {
                Label MemCode = (Label)gvNew.Rows[intRowCount].Cells[0].FindControl("lblMemCode");
                str = str + MemCode.Text;
                str += (intRowCount < gvNew.Rows.Count - 1) ? "," : string.Empty;
            }

            if (Request.QueryString["Ctgry"] != null)
            {
                btnRptUnitSearch.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Emp','','" + str + "');return false;");
            }
            else
            {
                btnRptUnitSearch.Attributes.Add("onclick", "fununtpopup('untcode','" + Convert.ToString(Request.QueryString["Type"]) + "','Agent','','" + str + "');return false;");
            }

        }

        divHirarchyDtlsNewHdr.Style.Add("display", "none");
        divprirptHdr.Style.Add("display", "block");
        divNewMngrDtlsHdr.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn-subtab btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";
    }
    protected void gvNewAddlMgr_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow grd = ((GridView)sender).NamingContainer as GridViewRow;
        GridView gvNewAddlMgr = (GridView)grd.FindControl("gvNewAddlMgr");
        DataTable dt = (DataTable)Session["addlmem1"];
        if (dt.Rows.Count >= 0)
        {
            dt.Rows.RemoveAt(Convert.ToInt32(e.RowIndex));
            Session["addlmem1"] = dt;
            gvNewAddlMgr.DataSource = dt;
            gvNewAddlMgr.DataBind();
        }
    }

    #region Hierarchy_Click
    protected void Hierarchy_Click(object sender, EventArgs e)
    {


        HierarchyDiv.Style.Add("display", "block");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "none");

        Hierarchy.CssClass = "btn-subtab btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn btn-default";

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

    #region Primary_Click
    protected void Primary_Click(object sender, EventArgs e)
    {
        HierarchyDiv.Style.Add("display", "none");
        PrimaryDiv.Style.Add("display", "block");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "none");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn-subtab btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn btn-default";

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

    #region Additional_Click
    protected void Additional_Click(object sender, EventArgs e)
    {
        HierarchyDiv.Style.Add("display", "none");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "block");
        DownlineDiv.Style.Add("display", "none");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn-subtab btn btn-default";
        Downlines.CssClass = "btn btn-default";

        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines2.png";

        //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
        //funShowNewMgr(lblNewaddlrptrule.Text.Trim());
    }
    #endregion

    #region Downlines_Click
    protected void Downlines_Click(object sender, EventArgs e)
    {

        HierarchyDiv.Style.Add("display", "none");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "block");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn-subtab btn btn-default";


        lnkCrntHier.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;
        lnkCrntDlines.BackColor = Color.Transparent;

        lnkCrntHier.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
        lnkCrntDlines.ImageUrl = "~/theme/iflow/tabs/Downlines1.png";
    }
    #endregion

    #region PrimDwd_Click
    protected void PrimDwd_Click(object sender, EventArgs e)
    {

        PrimDwd.CssClass = "btn-subtab btn btn-default";
        AddDwd.CssClass = "btn btn-default";

        HierarchyDiv.Style.Add("display", "none");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "block");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn-subtab btn btn-default";

        DownDemo.Style.Add("display", "block");
        BindGridRelation(lnkbtnCF.Text);

    }
    #endregion

    #region AddDwds_Click
    protected void AddDwd_Click(object sender, EventArgs e)
    {
        PrimDwd.CssClass = "btn btn-default";
        AddDwd.CssClass = " btn-subtab btn btn-default";

        HierarchyDiv.Style.Add("display", "none");
        PrimaryDiv.Style.Add("display", "none");
        AdditionalDiv.Style.Add("display", "none");
        DownlineDiv.Style.Add("display", "block");

        Hierarchy.CssClass = "btn btn-default";
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Downlines.CssClass = "btn-subtab btn btn-default";

        DownDemo.Style.Add("display", "block");
        BindGridRelation(lnkbtnCU.Text);

    }
    #endregion

    #region HierarchyNew_Click
    protected void HierarchyNew_Click(object sender, EventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 0;

        divHirarchyDtlsNewHdr.Style.Add("display", "block");
        divprirptHdr.Style.Add("display", "none");
        divNewMngrDtlsHdr.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn-subtab btn btn-default";
        PrimaryNew.CssClass = "btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";

        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls1.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region PrimaryNew_Click
    protected void PrimaryNew_Click(object sender, EventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 1;

        divHirarchyDtlsNewHdr.Style.Add("display", "none");
        divprirptHdr.Style.Add("display", "block");
        divNewMngrDtlsHdr.Style.Add("display", "none");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn-subtab btn btn-default";
        AdditionalNew.CssClass = "btn btn-default";


        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr1.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr2.png";
    }
    #endregion

    #region AdditionalNew_Click
    protected void AdditionalNew_Click(object sender, EventArgs e)
    {
        //MultiViewNew.ActiveViewIndex = 2;

        divHirarchyDtlsNewHdr.Style.Add("display", "none");
        divprirptHdr.Style.Add("display", "none");
        divNewMngrDtlsHdr.Style.Add("display", "block");

        HierarchyNew.CssClass = "btn btn-default";
        PrimaryNew.CssClass = "btn btn-default";
        AdditionalNew.CssClass = "btn-subtab btn btn-default";


        lnkCrntHierNew.BackColor = Color.Transparent;
        lnkNewPrimMgr.BackColor = Color.Transparent;
        lnkNewAddlMgr.BackColor = Color.Transparent;

        lnkCrntHierNew.ImageUrl = "~/theme/iflow/tabs/HierarchyDtls2.png";
        lnkNewPrimMgr.ImageUrl = "~/theme/iflow/tabs/PrmyMgr2.png";
        lnkNewAddlMgr.ImageUrl = "~/theme/iflow/tabs/AddlMgr1.png";
        //funShowCrntMgr(lbladditionalreportingrule.Text.Trim());
        //funShowNewMgr(lblNewaddlrptrule.Text.Trim());
    }
    #endregion
}
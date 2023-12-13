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
using System.Text;
using Insc.Common.Data;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using MQSMQMgr;
using System.Data.SqlClient;
using INSCL;
using INSCL.DAL;
using INSCL.App_Code;
using Insc.MQ.Life.AgnCr;
using Insc.Common.Multilingual;
using Insc.MQ.Life.AgnInwMd;
using Insc.MQ.Life.AgnInwCr;
using System.Text.RegularExpressions;
using DataAccessClassDAL;
using System.Globalization;
using AadharNo;
using KMI.FRMWRK.DAL;



public partial class Application_INSC_Recruit_frmCND_Personal : BaseClass
{
    #region Declare Veriables
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
    string inscdireconn = System.Configuration.ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ToString();
    private Provider oDP = new Insc.Common.Data.Provider();
    const string cSessionQryState = "ClientDetail";
    protected CommonFunc oCommon = new CommonFunc();
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    public const string CONN_INSCCOMMON = "INSCCommonConnectionString";
    Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
    public multilingualManager olng;
    private const string c_strLogPath = "/Log";
    private const string c_strBlank = "Select";
    Hashtable htParam = new Hashtable();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    private clsCndReg clsCndReg = new clsCndReg();
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility(); 
    string strAgentType = string.Empty;
    DataSet dsResult = new DataSet();
    ErrLog objErr = new ErrLog();//Added by rachana on 17-02-2013 for error log
    SqlDataReader dragnt;//Added by rachana
    //added by pranjali on 02-04-2014 start
    DataSet dsSMrecruitcode = new DataSet();
    string MemberCode;
    string MemberType = string.Empty;
    string BizSrc;
    string ChnCls;
    string UserType;
    //added by pranjali on 02-04-2014 end
    int StrMsg;
    Aadhar objAadhar = new Aadhar();
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    Hashtable htPan = new Hashtable();
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    string strUser = string.Empty;
    #endregion

   
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            strUser = HttpContext.Current.Session["UserID"].ToString();
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
           // GetRecruitSalesChannel(ddlSlsChannel, "", 0);
            Session["CarrierCode"] = '2';

            if (!IsPostBack)
            {
               
                olng = new multilingualManager("DefaultConn", "frmCND_Personal.aspx", Session["UserLangNum"].ToString());
                txtNationalCode.Text = "IND";
                txtNationalDesc.Text = "INDIAN";
                subPopulateTitle();
                InitializeControl();
                PopulateCategory();
                subPopulateGender();
                subPopulateMaritalStatus();
                PopulatePrimProof();
                FillHiddenValues();
                PopulateContactPreferred();
                txtpfRegDate.Text = DateTime.Now.ToString(INSCL.App_Code.CommonUtility.DATE_FORMAT);
                
               // txtDOB.Attributes.Add("onchange", "dtYear();");
                ddlAgnTypes.Items.Insert(0, new ListItem("Select", ""));
                ddlAgntType.Items.Insert(0, new ListItem("Select", ""));
                ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
                ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
                //To Get the Recruiter Code during page load in the SM Code Field
                //added by pranjali on 28-03-2014 start
                dsSMrecruitcode.Clear();
                dsSMrecruitcode = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
                MemberCode = dsSMrecruitcode.Tables[0].Rows[0]["MemberCode"].ToString();
                MemberType = dsSMrecruitcode.Tables[0].Rows[0]["MemberType"].ToString();
                BizSrc = dsSMrecruitcode.Tables[0].Rows[0]["BizSrc"].ToString();
                ChnCls = dsSMrecruitcode.Tables[0].Rows[0]["ChnCls"].ToString();
                UserType = dsSMrecruitcode.Tables[0].Rows[0]["UserType"].ToString();
                FillddlAddRptMgrCode();
                //pranjali

                if (UserType == "I")
                {
                    htParam.Clear();
                    htParam.Add("@MemberCode", MemberCode);
                    htParam.Add("@MemberType", MemberType);
                    htParam.Add("@BizSrc", BizSrc);
                    htParam.Add("@ChnCls", ChnCls);
                    dsResult.Clear();
                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetRecruiterDtls", htParam);
                    //added by pranjali on 28-03-2014 end
                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
			                ViewState["RecrtCode"] = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();
                            hdnRecrtCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();//added by shreela on 22/08/2014
                            //txtpfSMCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();//commented by shreela on 22/08/2014
                            txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]).Trim();
                            ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                            //Added by rachana to save CandAgentType start
                            hdnBizsrc1.Value = ddlSlsChannel.SelectedValue;
                            hdnChnCls.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                            FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                            //Added by rachana to save CandAgentType end
                            txtSMName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemTypeDesc01"]).Trim();
                            //Added by pranjali on 27-12-2013 start
                            hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                            string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                            string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                            ViewState["cmsunitcode"] = cmsunitcode;
                            //if (txtpfAppNo.Text != "" || (!MemberType.ToUpper().Equals("EP") && !MemberType.ToUpper().Equals("LP")))
                                txtBranchCode.Text = branch + " " + "(" + cmsunitcode + ")";
                            //Added by pranjali on 27-12-2013 end
                            txtSMName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                            GetRecruitSalesChannel(ddlSlsChannel, BizSrc, 0, ChnCls);
                          //  FillddlChannelSubClass((Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()));

                            //added by amruta on 5.1.16
                            if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                            {
                                  // GetRecruitSalesChannel(ddlSlsChannel, "", 0);

                                  // txtUntCode.Text = cmsunitcode.ToString().Trim();
                                ddlSlsChannel.Enabled = true;
                                //ddlSlsChannel.SelectedIndex = 0;
                               // ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
                               // GetRecruitSalesChannel(ddlSlsChannel, "", 0);
                             FillddlChannelSubClass((Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()));
                             ddlSlsChannel.SelectedIndex = 0;
                     
                                  // FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                            }
                            else
                            {
                             
                               // FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                ddlSlsChannel.SelectedValue = ddlSlsChannel.SelectedValue.ToString().Trim();
                               // txtUntCode.Text = cmsunitcode.ToString().Trim();
                                ddlSlsChannel.Enabled = false;
                                FillddlChannelSubClass((Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()));
                                ViewState["cndChnCls"] = ddlChnCls.SelectedValue;
                                //txtChnCls1.Text = ddlChnCls.SelectedItem.ToString();
                            }

                            //FillddlChannelSubClass((Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()));
                            //txtChnCls1.Text = ddlChnCls.SelectedItem.ToString();
                            strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
                            PopulateAgentTypes();
                           // FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                           // ddlSlsChannel.SelectedIndex = 0;
                            txtEmpCode.Enabled = true;
                            Button1.Enabled = true;
                        }
                    }
                }
                //Added by Pranjali on 07-12-2013 for fetching the Recruiters Information during page load end
                ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
               // ddlSlsChannel1.Items.Insert(0, new ListItem("Select", ""));
                ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
                //added by amruta on 7.1.16
                if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                {
                    ddlSlsChannel.SelectedIndex = 0;
                    ddlChnCls.SelectedIndex = 0;
                }
                //added by amruta on 7.1.16
            }

            //txtDOB.Attributes.Add("onblur",  "javascript: return onDOB_blur();");
            btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");
            //myBtn.Attributes.Add("onClick", "javascript: return popup();");
            Button1.Attributes.Add("onClick", "javascript: return funValidateEmpCode();");
            btnVerifyPAN.Attributes.Add("onclick", "javascript: return ValidationPAN();");//Added By pranjali on 20-12-2013 for Pan verification validation
            //ddlSlsChannel.Items.Insert(0, new ListItem("Select", ""));
            //ddlSlsChannel1.Items.Insert(0, new ListItem("Select", ""));
            //ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
            txtDOB.Attributes.Add("readonly", "readonly");

            txtDOB.Attributes.Add("style", "background-color: white");
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
        try
        {
            btnUpdate.Text = olng.GetItemDesc("btnSave");
            lblCategory.Text = olng.GetItemDesc("lblCategory");
            lblpfPersonal.Text = olng.GetItemDesc("lblpfPersonal");
            lblpfAppNo.Text = olng.GetItemDesc("lblpfAppNo");
            lblpfRegDate.Text = olng.GetItemDesc("lblpfRegDate");
            lblpfGivenName.Text = olng.GetItemDesc("lblpfGivenName");
            lblpfSurname.Text = olng.GetItemDesc("lblpfSurname");
            lblpfFatherName.Text = olng.GetItemDesc("lblpfFatherName");
            lblpfGender.Text = olng.GetItemDesc("lblpfGender");
            lblpfDOB.Text = olng.GetItemDesc("lblpfDOB");
            lblpfmaritalstatus.Text = olng.GetItemDesc("lblpfmaritalstatus");
            lblpfNationality.Text = olng.GetItemDesc("lblpfNationality");
            btnCancel.Text = olng.GetItemDesc("btnCancel");
            //Added by Pranjali on 05-12-2013 for displaying label fields through table start
            lblpan.Text = olng.GetItemDesc("lblpan");
            lblProfession.Text = olng.GetItemDesc("lblOccupation");
            lblpfrecinfotitle.Text = olng.GetItemDesc("lblpfrecinfotitle");
            //lblpfcndChnltitle.Text = olng.GetItemDesc("lblpfcndChnltitle");
            lblSpeclNotes.Text = olng.GetItemDesc("lblSpeclNotes");
         //  lblpfSMCode.Text = olng.GetItemDesc("lblpfSMCode");//commented by shreela on 22/08/2014
           // btnVerifySMCode.Text = olng.GetItemDesc("btnVerifySMCode");//commented by shreela on 22/08/2014
            lblpfSlsChannel.Text = olng.GetItemDesc("lblpfSlsChannel");
            //lblpfSlsChannel1.Text = olng.GetItemDesc("lblpfSlsChannel");
            lblpfChnCls.Text = olng.GetItemDesc("lblpfChnCls");
            //lblpfChnCls1.Text = olng.GetItemDesc("lblpfChnCls");
            lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
            lblpfSMName.Text = olng.GetItemDesc("lblpfSMName");
            lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
            lblCndAgtType.Text = "Candidate Type";//olng.GetItemDesc("lblCndAgtType");
            //Added by Pranjali on 05-12-2013 for displaying label fields through table end
            //Contact Details added by rachana start
            lblEmail2.Text = olng.GetItemDesc("lblEmail2");
            lblpfemail.Text = olng.GetItemDesc("lblpfemail");
            lblMobile2.Text = olng.GetItemDesc("lblMobile2");
            lblpfmobtel.Text = olng.GetItemDesc("lblpfmobtel");
            lblpfofftel.Text = olng.GetItemDesc("lblpfofftel");
            lblpfhometel.Text = olng.GetItemDesc("lblpfhometel");
            lblpfconpreferred.Text = olng.GetItemDesc("lblpfconpreferred");
            //Contact Details added by rachana end
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

    #region PopulateCategory
    private void PopulateCategory()
    {
        try
        {
            //To get category type in the dropdown from IsysLookupParam 
            oCommon.getDropDown(ddlCategory, "CndCat", 1, "", 1);
            ddlCategory.Items.Insert(0, "Select");
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

    //#region fill candidate type
    //private void FillCndAgntType(string strbiz, string strChn)
    //{
    //    try
    //    {
    //        htParam.Clear();
    //        DataSet dsagnt = new DataSet();
    //        htParam.Add("@BizSrc", strbiz);
    //        htParam.Add("@Chncls", strChn);

    //        //dragnt = dataAccessRecruit.exec_reader_prc_rec("Prc_GetAgntTypeforCnd", htParam);
    //        dragnt = dataAccessRecruit.exec_reader_prc_rec("Prc_GetAgntTypeforCnd", htParam);
    //        //dsagnt = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_RecruitInfoSearch", htParam);

    //        dragnt.Read();
    //        if (dragnt.HasRows)
    //        {
    //        //if(dsResult.Tables.Count>0)
    //        //{
    //            ddlCndAgtType.DataSource = dragnt;
    //            ddlCndAgtType.DataTextField = "MemTypeDesc01";
    //            ddlCndAgtType.DataValueField = "MemType";
    //            ddlCndAgtType.DataBind();
    //            //ddlCndAgtType.SelectedValue = "IS";


    //        }
    //        dragnt = null;
    //    }
    //    catch (Exception ex)
    //    {

    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
    //    }
    //}
    //#endregion


    #region fill candidate type
    private void FillCndAgntType(string strbiz, string strChn)
    {
        try
        {
            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@BizSrc", strbiz);
            htParam.Add("@Chncls", strChn);
         
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetCndAgnType", htParam);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ViewState["AgtType"] = Convert.ToString(dsresult.Tables[0].Rows[0]["MemType"]).Trim();
                ddlCndAgtType.DataSource = dsresult;
                ddlCndAgtType.DataTextField = "MemTypeDesc01";
                ddlCndAgtType.DataValueField = "MemType";
                ddlCndAgtType.DataBind();
                string ProsReg = Request.QueryString["Type"].ToString();
                if (ProsReg == "P")
                {
                    ddlCndAgtType.SelectedValue = "PA";
                }
                else
                {
                    ddlCndAgtType.SelectedValue = "SC";
                }
                dsresult = null;

            }
            else
            {
                if (strbiz != "XX")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Agent Type')", true);
                    //return; commented by daksh for POSP
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
        }
    }
    #endregion

    #region subPopulateTitle
    private void subPopulateTitle()
    {
        try
        {
            //To get Title for the name in the dropdown during prospect registration
            dscbotitle.SelectCommand = "Prc_GetTitle_IsysLookupParam";
            cboTitle.DataBind();
            cboTitle.Items.Insert(0, new ListItem("Select", ""));
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

    #region subPopulateGender
    private void subPopulateGender()
    {
        try
        {
            //To get the Gender type in the dropdown from IsysLookupParam 
            oCommon.getDropDown(cboGender, "NBGender", 1, "", 1, c_strBlank);
            cboGender.Items.Remove(cboGender.Items.FindByValue("C"));
            cboGender.Items.Remove(cboGender.Items.FindByValue("U"));
            subGenerateGenderValidation();
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
    //Added by pranjali to fill primary profession dropdown start
    #region subPopulateMaritalStatus
    private void subPopulateMaritalStatus()
    {
        try
        {
            //To get the Gender type in the dropdown from IsysLookupParam 
            oCommon.getDropDown(cboMaritalStatus, "NBMary", 1, "", 1, c_strBlank);
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

    #region PopulatePrimProof
    private void PopulatePrimProof()
    {
        try
        {
            oCommon.getDropDown(ddlPrimProf, "PrimProof", 1, "", 1);
            ddlPrimProf.Items.Insert(0, "Select");
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
    //Added by pranjali to fill primary profession dropdown end

    #region subGenerateGenderValidation
    private void subGenerateGenderValidation()
    {
        try
        {
            DataTable dtGenderTitle = oDP.ReadData("INSCDirectConnectionString", "prc_GenderTitle_sel").Tables[0];

            foreach (DataRow row in dtGenderTitle.Rows)
            {
                hdnGenderTitle1.Value += row[0].ToString() + ",";
                hdnGenderTitle2.Value += row[1].ToString() + ",";
            }

            hdnGenderTitle1.Value = hdnGenderTitle1.Value.Trim(',');
            hdnGenderTitle2.Value = hdnGenderTitle2.Value.Trim(',');
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

    #region FillHiddenValues
    protected void FillHiddenValues()
    {
        try
        {
            //Displaying the Error message for validation
            olng = new multilingualManager("DefaultConn", "frmCND_Personal.aspx", Session["UserLangNum"].ToString());
            hdnID280.Value = olng.GetItemDesc("hdnID2801");
            hdnID470.Value = olng.GetItemDesc("hdnID4701");
            hdnID290.Value = olng.GetItemDesc("hdnID2901");
            hdnID320.Value = olng.GetItemDesc("hdnID3201");
            hdnID450.Value = olng.GetItemDesc("hdnID4501");
            hdnID440.Value = olng.GetItemDesc("hdnID4401");
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
    //added by pranjali on 28-03-2014 start
    #region GetRecruiterDetails
    public DataSet GetRecruiterDetail(string RecruiterCode)
    {
        DataSet dsResult = new DataSet();
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@RecruiterCode", RecruiterCode);
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetRecruiterCodeDtls", htparam);
        return dsResult;
    }
    #endregion
    //added by pranjali on 28-03-2014 end

    //added by pranjali on 28-03-2014 start
    #region GetEmployeeCodeDetails
    public DataSet GetEmployeeDetail(string EmployeeCode)
    {
        DataSet dsResult = new DataSet();
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        htparam.Add("@EmpCode", EmployeeCode);
        //dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetEmployeeCodeDtls", htparam);
        dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetEmpCodeDtls", htparam);
        return dsResult;
    }
    #endregion
    //added by pranjali on 28-03-2014 end



    #region BUTTON 'Verify Click' DEFINITION
    //commented by shreela on 22/08/2014 start
    //protected void btnVerifySMCode_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //Added by Pranjali on 07-12-2013 to verify recruiters code start
    //        bool IsFound = false;
    //        lblErrCSC.Text = "";
    //        ddlAgntType.Items.Clear();
    //        ddlChnCls.Items.Clear();
    //        ddlAgnTypes.Items.Clear();
    //        ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
    //        ddlAgntType.Items.Insert(0, new ListItem("Select", ""));
    //        ddlAgnTypes.Items.Insert(0, new ListItem("Select", ""));
    //        ddlSlsChannel.SelectedIndex = 0;
    //        txtEmpCode.Text = "";
    //        txtBranchCode.Text = "";
    //        txtSMName.Text = "";
    //        dsSMrecruitcode.Clear();
    //        dsSMrecruitcode = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
    //        MemberCode = dsSMrecruitcode.Tables[0].Rows[0]["MemberCode"].ToString();
    //        MemberType = dsSMrecruitcode.Tables[0].Rows[0]["MemberType"].ToString();
    //        BizSrc = dsSMrecruitcode.Tables[0].Rows[0]["BizSrc"].ToString();
    //        ChnCls = dsSMrecruitcode.Tables[0].Rows[0]["ChnCls"].ToString();
    //        UserType = dsSMrecruitcode.Tables[0].Rows[0]["UserType"].ToString();
    //        string UnitCode = dsSMrecruitcode.Tables[0].Rows[0]["UnitCode"].ToString();//pranjali on 05-04-2014
    //        if (UserType == "I")
    //        {
    //            Hashtable htalw = new Hashtable();
    //            DataSet dsallwrecruit = new DataSet();
    //            htalw.Add("@MemberCode", MemberCode);
    //            htalw.Add("@MemberType", MemberType);
    //            dsallwrecruit = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAllowRecruitDtl", htalw);
    //            if ((dsallwrecruit.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "1") || (dsallwrecruit.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "True"))
    //            {
    //                if (MemberCode == txtpfSMCode.Text)
    //                {

    //                }
    //                else
    //                {
    //                    lblErrCSC.Visible = true;
    //                    lblErrCSC.ForeColor = System.Drawing.Color.Red;
    //                    lblErrCSC.Text = "The recruiter is not allowed to recruit";
    //                    StrMsg = 1;
    //                    return;
    //                }
    //            }
    //            DataSet dsRecruiterCode = new DataSet();
    //            dsRecruiterCode = GetRecruiterDetail(txtpfSMCode.Text.Trim());
    //            if (dsRecruiterCode.Tables.Count > 0)
    //            {
    //                if (dsRecruiterCode.Tables[0].Rows.Count > 0)
    //                {
    //                    string strRecruiterCode = dsRecruiterCode.Tables[0].Rows[0]["MemberCode"].ToString();
    //                    string strRecruiterType = dsRecruiterCode.Tables[0].Rows[0]["MemberType"].ToString();
    //                    string strRecruiterBizSrc = dsRecruiterCode.Tables[0].Rows[0]["BizSrc"].ToString();
    //                    string strRecruiterChnCls = dsRecruiterCode.Tables[0].Rows[0]["ChnCls"].ToString();

    //                    htParam.Clear();
    //                    htParam.Add("@MemberCode", MemberCode);
    //                    htParam.Add("@RecruiterCode", strRecruiterCode);
    //                    htParam.Add("@RecruiterType", strRecruiterType);
    //                    htParam.Add("@RecruiterBizSrc", strRecruiterBizSrc);
    //                    htParam.Add("@RecruiterChnCls", strRecruiterChnCls);
    //                    dsResult.Clear();
    //                    //Verify SM Code
    //                    dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetVerifyRecruiterDtls", htParam);
    //                    //added by pranjali on 28-03-2014 end
    //                }
    //                else
    //                {
    //                    lblErrCSC.Visible = true;
    //                    lblErrCSC.ForeColor = System.Drawing.Color.Red;
    //                    lblErrCSC.Text = "The recruiter is not allowed to recruit";//"No Match Found";
    //                    StrMsg = 1;
    //                }
    //            }
                
    //        }
    //        else if (UserType == "E")
    //        {
    //            DataSet dsRecruiterCode = new DataSet();
    //            dsRecruiterCode = GetRecruiterDetail(txtpfSMCode.Text.Trim());
    //            string strRecruiterCode = dsRecruiterCode.Tables[0].Rows[0]["MemberCode"].ToString();
    //            string strRecruiterType = dsRecruiterCode.Tables[0].Rows[0]["MemberType"].ToString();
    //            string strRecruiterBizSrc = dsRecruiterCode.Tables[0].Rows[0]["BizSrc"].ToString();
    //            string strRecruiterChnCls = dsRecruiterCode.Tables[0].Rows[0]["ChnCls"].ToString();
    //            string strRecruiterUnitCode = dsRecruiterCode.Tables[0].Rows[0]["UnitCode"].ToString();
    //            htParam.Clear();
    //            htParam.Add("@RecruiterCode", strRecruiterCode);
    //            htParam.Add("@RecruiterType", strRecruiterType);
    //            htParam.Add("@RecruiterBizSrc", strRecruiterBizSrc);
    //            htParam.Add("@UnitCode", UnitCode);
    //            htParam.Add("@RecruiterChnCls", strRecruiterChnCls);
    //            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetRecruiterDtlsForExtrnl", htParam);
    //        }
    //            if (dsResult.Tables.Count > 0)
    //            {
    //                if (dsResult.Tables[0].Rows.Count > 0)
    //                {
    //                    IsFound = true;

    //                    txtpfSMCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();
    //                    txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]).Trim();
    //                    //Added by pranjali on 27-12-2013 start
    //                    hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
    //                    string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitLegalName"]).Trim();
    //                    string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
    //                    txtBranchCode.Text = branch + " " + "(" + cmsunitcode + ")";
    //                    //Added by pranjali on 27-12-2013 end
    //                    txtSMName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
    //                    hdnBizSrc.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
    //                    //Set the Sales Channel 
    //                    if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
    //                    {
    //                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
    //                        {
    //                            GetRecruitSalesChannel(ddlSlsChannel, "", 0);
    //                            if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
    //                            {
    //                                ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
    //                                FillddlChannelSubClass(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());

    //                            }
    //                        }
    //                    }

    //                    //Set the Channel sub Class
    //                    if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
    //                    {
    //                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
    //                        {
    //                            if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
    //                            {
    //                                ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
    //                            }
    //                        }
    //                    }

    //                    strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
    //                    PopulateAgentTypes();
    //                    FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());//01
    //                    txtEmpCode.Enabled = false;
    //                    Button1.Enabled = false;
    //                }
    //            }
    //        dsResult = null;
    //        SqlDataReader drResult;
    //        Hashtable httable = new Hashtable();
    //        if (IsFound == false)
    //        {
    //            lblErrCSC.Visible = true;
    //            lblErrCSC.ForeColor = System.Drawing.Color.Red;
    //            lblErrCSC.Text = "The recruiter is not allowed to recruit";//"No Match Found";
    //            StrMsg = 1;
    //        }
    //        else
    //        {
    //                lblErrCSC.Visible = true;
    //                lblErrCSC.ForeColor = System.Drawing.Color.Green;
    //                lblErrCSC.Text = "Recruiter Code verified.";
    //                txtEmpCode.Enabled = false;
    //                lblEmpMsg.Visible = false;
    //                Button1.Enabled = false;
    //                ddlAgnTypes.Focus();
    //                StrMsg = 0;
    //        }
    //        //Added by Pranjali on 07-12-2013 to verify recruiters code end
    //    }
    //    catch (Exception ex)
    //    {
            
    //         string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}
    //commented by shreela on 22/08/2014 end
    #endregion

    #region METHOD 'AgentTypes' DEFINITION
    //Added by Pranjali on 07-12-2013 to Fill the Recruiter agent type dropdown start
    private void PopulateAgentTypes()
    {
        try
        {
            ddlAgnTypes.Items.Clear();
            DSAgnTypes.SelectCommand = "Prc_GetAgentTypeforCndReg '" + ddlSlsChannel.SelectedValue + "','" + ddlChnCls.SelectedValue + "','" + strAgentType + "'";
            ddlAgnTypes.DataBind();
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
    //Added by Pranjali on 07-12-2013 to Fill the Recruiter agent type dropdown end
    #endregion

    #region METHOD 'GetSalesChannel' DEFINITION
    //Added by Pranjali on 07-12-2013 to Fill Channel dropdown start
    private void GetRecruitSalesChannel(DropDownList ddl, string strBizSrc, int strIncMasterCmp, string Chncls)
    {
        try
        {
            ddlChnCls.Items.Clear();
            ddlAgntType.Items.Clear();
            string strSql = string.Empty;
            DataSet dsResult = new DataSet();
            int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
            htParam.Clear();
            htParam.Add("@CarrierCode", CarrierCode);
            htParam.Add("@Chncls", Chncls);
            htParam.Add("@Bizsrc", strBizSrc);
           // htParam.Add("@cmsunitcode", cmsunitcode);
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", htParam, CONN_Recruit);
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_getrecruitslschannel", htParam);
          
            //dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", htParam, CONN_Recruit);
            if (dsResult.Tables.Count > 0)
            {
                oCommonUtility.FillDropDown(ddl, dsResult.Tables[0], "BizSrc", "ChannelDesc01");
                if (strBizSrc.Trim() != "")
                {
                    ddl.SelectedValue = strBizSrc.Trim();
                }
            }
            //ddlSlsChannel.SelectedIndex = 0;//       //commented by amruta on 7.1.16
            dsResult = null;
            strSql = null;
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
    //Added by Pranjali on 07-12-2013 to Fill Channel dropdown end
    #endregion

    #region METHOD 'FillddlChannelClass' DEFINITION
    //Added by Pranjali on 07-12-2013 to Fill Sub Class dropdown start
    private void FillddlChannelSubClass(string sddlSlsChannel)
    {
        try
        {
            ddlAgntType.Items.Clear();
            ddlChnCls.Items.Clear();
            SqlDataReader dtRead;
            htParam.Clear();
            int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
            htParam.Add("@CarrierCode", CarrierCode);
            htParam.Add("@BizSrc", sddlSlsChannel);
            //dtRead = dataAccess.exec_reader_prc_conn("Prc_Getddlslschannel", htParam, CONN_Recruit);
            dtRead = dataAccessRecruit.exec_reader_prc_conn("Prc_Getddlslschannel", htParam, CONN_Recruit);
            if (dtRead.HasRows)
            {
                ddlChnCls.DataSource = dtRead;
                ddlChnCls.DataTextField = "ChnlDesc";
                ddlChnCls.DataValueField = "ChnCls";
                ddlChnCls.DataBind();
            }
            dtRead = null;
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
    //Added by Pranjali on 07-12-2013 to Fill Sub Class dropdown end
    #endregion

    private void PopulateContactPreferred()
    {
        try
        {
            oCommon.getDropDown(ddlDstbnMethod, "DstbnMtd", 1, "", 1);
            ddlDstbnMethod.Items.Insert(0, "Select");
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
   
    #region btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");              
        btnVerifyEmpCode_Click(this, EventArgs.Empty);//shreela
        //btnVerifySMCode_Click(this, EventArgs.Empty);
       //  txtBranchCode.Text=Session["unitcode"].ToString() ;
        if (StrMsg == 1)
        {
            lblEmpMsg.Visible = true;
            lblEmpMsg.ForeColor = System.Drawing.Color.Red;
            lblEmpMsg.Text = "The recruiter is not allowed to recruit";//"No Match Found";
            ProgressBarModalPopupExtender.Hide();
            return;
        }
        //Added by pranjali on 10-04-2014 for pan validation start
        //btnVerifyPAN_Click(this, EventArgs.Empty);
        if (hdnPan.Value != "1")
        {
            lblPANMsg.Text = "";
            lblMessage.Text = "Please Validate PAN No.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Validate PAN No.')", true);
            ProgressBarModalPopupExtender.Hide();
            return;
        }
        if (hdnPanValue.Value != txtpan.Text)
        {
            lblPANMsg.Text = "";
            ProgressBarModalPopupExtender.Hide();
            lblMessage.Text = "Please validate PAN No.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please validate PAN No.')", true);
            return;
        }
        //Added by pranjali on 10-04-2014 for pan validation  end
        DateTime DOBdate;
        DateTime CntDate;
        bool bIsValidDate;
        ArrayList arrResult = new ArrayList();
        string sessionuser = string.Empty;

        if (HttpContext.Current.Session["UserID"] != null)
        {
            sessionuser = HttpContext.Current.Session["UserID"].ToString();
        }
        bIsValidDate = IsValidDate(txtDOB.Text.Trim(), txtDOB.Text.Trim());

        if (!(bIsValidDate))
        {
            return;
        }
        else
        {
            DOBdate = DateTime.Parse(txtDOB.Text.Trim());
            CntDate = DateTime.Parse(DateTime.Now.ToString(CommonUtility.DATE_FORMAT));

            if (checkDOB(DOBdate, CntDate) == 0)
            {
                ProgressBarModalPopupExtender.Hide();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Minimum Entry Age should be 18 years.')", true);
                return;    
            }
            try
            {
                 
                //GetRecruitSalesChannel(ddlSlsChannel, "", 0); //Added by pranjali on 07-12-2013 to fill the channel dropdown
                //FillddlChannelSubClass(ddlSlsChannel.SelectedValue);//Added by pranjali on 07-12-2013 to fill the Sub class dropdown
                htParam.Clear();
                htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
                htParam.Add("@CndCat", ddlCategory.SelectedValue.Trim());
                if (txtpfRegDate.Text.Trim() != "")
                {
                    htParam.Add("@EntryDate", DateTime.Parse(txtpfRegDate.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@EntryDate ", System.DBNull.Value);
                }
                htParam.Add("@Title", cboTitle.SelectedValue.ToString());
                htParam.Add("@GivenName", txtpfGivenName.Text.Trim());
                htParam.Add("@Surname", txtpfSurname.Text.Trim());
                htParam.Add("@FatherName", txtFatherName.Text.Trim());
                htParam.Add("@Gender", cboGender.SelectedValue.Trim());
                if (txtDOB.Text.Trim() != "")
                {
                    htParam.Add("@BirthRegDate", DateTime.Parse(txtDOB.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@BirthRegDate ", System.DBNull.Value);
                }
                htParam.Add("@MaritalStat", cboMaritalStatus.SelectedValue.Trim());
                htParam.Add("@Nationality", txtNationalCode.Text.Trim());
                //Added by pranjali on 07-12-2013 to insert recruit information fields start
                htParam.Add("@EmpCode", txtEmpCode.Text.Trim());
                htParam.Add("@SmCode", hdnRecrtCode.Value);
		        //htParam.Add("@SmCode", ViewState["RecrtCode"].ToString().Trim());
                //htParam.Add("@SmCode", txtpfSMCode.Text.Trim());
               //added by amruta on 7.1.16
                if (ddlSlsChannel.SelectedIndex==12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter candiadte channel')", true);
                    ProgressBarModalPopupExtender.Hide();
                    ddlSlsChannel.Focus();
                    return;
                    
                }
                //added by amruta on 7.1.16
                htParam.Add("@SlsChannel", ddlSlsChannel.SelectedValue);
                //htParam.Add("@ChnCls", ddlChnCls.SelectedValue);

                htParam.Add("@ChnCls", ViewState["cndChnCls"].ToString().Trim());//       //added by amruta on 6.1.16
                htParam.Add("@AgnTypes", ddlAgnTypes.SelectedValue.Trim());//AgtType
                htParam.Add("@BranchCode", ViewState["cmsunitcode"]);//Added by pranjali on 31-12-2013// added by amruta on 8.1.16
                htParam.Add("@SmName", txtSMName.Text.Trim());
                htParam.Add("@Pan", txtpan.Text.Trim()); //added by pranjali on 21-12-2013 for inserting pan details
                htParam.Add("@UpdateBy", sessionuser);//added by pranjali on 21-12-2013 for inserting sessionuser details
                htParam.Add("@Profession", ddlPrimProf.SelectedValue.ToString().Trim());//added by pranjali on 21-12-2013 for inserting profession details
                htParam.Add("@CndAgntType", ddlCndAgtType.SelectedValue);// ViewState["AgtType"].ToString().Trim());//Added by rachana for saving AgentType
                if (ddlAddRptMgrCode.SelectedValue != "--Select--")
                {
                    htParam.Add("@AddMgrCode", ddlAddRptMgrCode.SelectedValue.ToString());
                }
                else
                {
                    htParam.Add("@AddMgrCode", System.DBNull.Value);
                }
              
                //Contact details added by Rachana on 13082014 start
                htParam.Add("@HomeTel", txthometel.Text.Trim());
                htParam.Add("@WorkTel", txtWorkTel.Text.Trim());
                htParam.Add("@MobileCode", txtmobcode.Text.Trim());
                htParam.Add("@MobileTel", txtMobileTel.Text.Trim());
                htParam.Add("@Email", txtemail.Text.Trim().ToLower());
                htParam.Add("@MobileCode2", txtmobcode2.Text.Trim());
                htParam.Add("@Mobile2", txtMobile2.Text.Trim());
                htParam.Add("@Email2", txtEmail2.Text.Trim());
               // htParam.Add("@AdharNo", txtaadhr.Text.Trim());//added by amruta on 22/9/16

                if (this.ddlDstbnMethod.SelectedValue.Trim() != "Select")
                {
                    htParam.Add("@DstbnMethod", this.ddlDstbnMethod.SelectedValue.Trim());
                }
                else
                {
                    htParam.Add("@DstbnMethod", System.DBNull.Value);
                }
                //var dt = (DataTable)Session["unt"];
               
                //string strUnitCode = Convert.ToString(dt.Rows[0]["UnitCode"]);
                //htParam.Add("@RecUntCode", strUnitCode);
                
                //Contact details added by Rachana on 13082014 end
                //Added by pranjali on 07-12-2013 to insert recruit information fields end
                //Inserts the data into cnd for Prospect Registration
                   arrResult = clsCndReg.InsertAgentDetails_prospect(htParam, "Prc_InsProspectDetails");
                   if (arrResult[0].ToString() == "0")
                   {
                       // btnUpdate.Attributes.Add("onClick", "javascript: return funPopUp();");

                       txtpfAppNo.Text = arrResult[1].ToString();//Added by pranjali on 05-12-2013 for displaying the Application No in the text field
                       lbl_popup.Text = "Prospect registered successfully." + "</br></br>Application No: " + txtpfAppNo.Text + "</br> Prospect Name: " + cboTitle.SelectedValue + " " + txtpfGivenName.Text + " " + txtpfSurname.Text;

                       //mdlpopup.X = 40;
                       //mdlpopup.Y = 210;

                       //mdlpopup.Show();

                       hdnSave.Value = "Prospect registered successfully.";
                       lblMessage.Text = hdnSave.Value;
                       lblMessage.Visible = true;
                       tr_message.Visible = true;
                       txtBranchCode.Text = (string)Session["unitcode"];//Session["BranchCode"];
                       btnUpdate.Enabled = false;
                     //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$(#mymodal).modal('show');</script>", false);
                       //return;
                       ClientScript.RegisterStartupScript(this.GetType(),"alert","popup();",true);

                       ObjTask.UpdateCndTask(txtpfAppNo.Text);//To create task in CRM  in 18.12.2017
                   }


                    //btnUpdate.Enabled = false; //Added by pranjali on 25-11-2013 for save button diasable after insertion
                }
                catch (Exception ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = ex.Message;
                    tr_message.Visible = true;

                    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    int LNNo = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber();
                    string LineNo = Convert.ToString(LNNo);
                        
                    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);

                    string sRet = oInfo.Name;
                    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    String LogClassName = method.ReflectedType.Name;

                    objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                }
        }
    }
    #endregion
    private void MailResponse(string AppNo)
    {

        //MAIL Communication integration
        string strUserID = Session["UserID"].ToString();
        Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        ds.Clear();
        htData.Add("@Param1", "PROS");
        htData.Add("@Param2", "F");
        htData.Add("@Param3", "10");
        htData.Add("@Param4", "NR");
        ds = dataAccessRecruit.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                    //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    objmailcomm.SendNoticationMailSMS("ARTL", "PROS", "F", "10", "NR", "", NotifyTo, txtpfAppNo.Text, HttpContext.Current.Session["UserID"].ToString());
                }
            }
        }
        //MAIL
    }
    #region btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../../Default3.aspx"); 
    }
    #endregion

    #region IsValidDate
    protected bool IsValidDate(string Date1, string Date2)
    {
        DateTime dtDate1;
        DateTime dtDate2;
        bool isDate = true;
        try
        {
            dtDate1 = DateTime.Parse(Date1);
            dtDate2 = DateTime.Parse(Date2);
        }
        catch (Exception ex)
        {
            lblMessage.Text = hdnIsDateValid.Value;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
            isDate = false;
            tr_message.Visible = true;

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return isDate;
    }
    #endregion

    #region checkDOB
    public int checkDOB(DateTime DOBdate, DateTime cnddate)
    {
        //Validation for date of birth
        DateTime CDate = cnddate.AddYears(-18);
        if (CDate > DOBdate)
            return 1;
        else
            return 0;
    }
    #endregion
    //Added by pranjali on 10-04-2014 for pan validation start
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {
        try
        {
            bool isFound = false;
            DataSet dsRes = new DataSet();
            lblPANMsg.Text = "";
            hdnPan.Value = "0";
            htParam.Clear();
            htParam.Add("@PAN", txtpan.Text.Trim());
            dsRes = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetChkPANExist", htParam);

            for (int i = 0; i < dsRes.Tables.Count; i++)
            {
                if (dsRes.Tables[i].Rows.Count > 0)
                {
                     
                    if (dsRes.Tables[0].Rows.Count > 0)
                    {

                     if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "180" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "C")// added by usha for 
                             {
                                    isFound = true;
                             }
                        }
                             //ended  by usha 
		    if (dsRes.Tables.Count > 1)
                    {	
		       if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")//Added by rachana to show empcode in duplicate PAN
                       {
                        hdnCndCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][3]).Trim();
                       }
		    }
                    else
                    {
	                    hdnCndCode.Value = Convert.ToString(dsRes.Tables[i].Rows[0][0]).Trim();
		    }
                }
            }
            if (isFound == true)
            {
                if (dsRes.Tables[0].Rows.Count > 0 || dsRes.Tables[1].Rows.Count > 0)
                 {
                   if (dsRes.Tables[0].Rows[0]["CndStatus"].ToString() != "" || dsRes.Tables[0].Rows[0]["Cand_Type"].ToString() != "")// added by usha for composite 
                     {


                    if (Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim() != "")
                    {
                        hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>Agent Broker Code :- " + hdnAgentBrokerCode.Value;
                    }
                    else if (Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim() != "")
                    {
                        hdnUrn.Value = Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>URN NO :- " + hdnUrn.Value;
                    }
                    else
                    {
                        lblPANMsg.Text = "Duplicate Match Found For <br/>ApplicationNo :- " + hdnCndCode.Value;
                    }
                    lblPANMsg.ForeColor = Color.Red;
                    hdnPan.Value = "0";
                    htPan.Add("@DupAppNo", Convert.ToString(dsRes.Tables[0].Rows[0][0]).Trim());
                    if (dsRes.Tables[0].Rows[0][5].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[0].Rows[0][5]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[0].Rows[0][2].ToString().Trim() != "")
                    {
                        htPan.Add("@DupURNNo", Convert.ToString(dsRes.Tables[0].Rows[0][2]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupURNNo", System.DBNull.Value);
                    }
                    if (dsRes.Tables[0].Rows[0][7].ToString().Trim() != "")
                    {
                        htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[0].Rows[0][7]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupSAPCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[0].Rows[0][6].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[0].Rows[0][6]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgentCode", System.DBNull.Value);
                    }
                }
              }
            }
                else if (dsRes.Tables.Count>1 && dsRes.Tables[1].Rows.Count > 0) 
                {
                    if (Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim() != "")
                    {
                        hdnEmpCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>Employee Code :- " + hdnEmpCode.Value;
                    }
                    else if (Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim() != "")
                    {
                        hdnAgentBrokerCode.Value = Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim();
                        lblPANMsg.Text = "Duplicate Match Found For <br/>Agent Broker Code :- " + hdnAgentBrokerCode.Value;
                    }
                    else
                    {
                        lblPANMsg.Text = "Duplicate Match Found For <br/>AgentCode :- " + hdnCndCode.Value;
                    }

                    lblPANMsg.ForeColor = Color.Red;
                    hdnPan.Value = "0";
                    htPan.Clear();
                    //htPan.Add("@DupAppNo", Convert.ToString(dsRes.Tables[0].Rows[0][0]).Trim());
                    if (dsRes.Tables[1].Rows[0][2].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgntBrkrCode", Convert.ToString(dsRes.Tables[1].Rows[0][2]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgntBrkrCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[1].Rows[0][0].ToString().Trim() != "")
                    {
                        htPan.Add("@DupAgentCode", Convert.ToString(dsRes.Tables[1].Rows[0][0]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupAgentCode", System.DBNull.Value);
                    }
                    if (dsRes.Tables[1].Rows[0][3].ToString().Trim() != "")
                    {
                        htPan.Add("@DupSAPCode", Convert.ToString(dsRes.Tables[1].Rows[0][3]).Trim());
                    }
                    else
                    {
                        htPan.Add("@DupSAPCode", System.DBNull.Value);
                    }
                
                htPan.Add("@DupPAN", txtpan.Text.Trim());
                htPan.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                int x = dataAccessRecruit.execute_sprcrecruit("Prc_InsDupPANDtls", htPan);
            }
              
            else
            {
                lblPANMsg.Text = "PAN NO. Verified";
                lblPANMsg.ForeColor = Color.Green;
                hdnPan.Value = "1";
                hdnPanValue.Value = txtpan.Text;
            }

            btnVerifyPAN.Focus();
          
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

    //Added by pranjali on 10-04-2014 for pan validation end
    #region BUTTON 'Verify EmpCode Click' DEFINITION
    protected void btnVerifyEmpCode_Click(object sender, EventArgs e)
    {
        try
        {
            Session["BranchCode"] = txtBranchCode.Text;
            bool IsFound = false;
            //lblErrCSC.Text = "";
            //ddlAgntType.Items.Clear();
            //ddlChnCls.Items.Clear();
            //ddlAgnTypes.Items.Clear();
           // ddlCndAgtType.Items.Clear();//added by shreela on 22/08/2014
           // ddlChnCls.Items.Insert(0, new ListItem("Select", ""));
            //ddlAgntType.Items.Insert(0, new ListItem("Select", ""));
            //ddlAgnTypes.Items.Insert(0, new ListItem("Select", ""));
           // ddlCndAgtType.Items.Insert(0, new ListItem("Select", ""));//added by shreela on 22/08/2014
           // ddlSlsChannel.SelectedIndex = 0;
        //Meena
            //txtBranchCode.Text = "";
           // txtSMName.Text = "";
            //Meena
            //added by pranjali on 01-04-2014 start
            DataSet dscode = new DataSet();
            dscode = oCommonUtility.GetUserDtls(Session["UserID"].ToString().Trim());
            string strMemberCode = dscode.Tables[0].Rows[0]["MemberCode"].ToString();
            string strMemberType = dscode.Tables[0].Rows[0]["MemberType"].ToString();
            string strBizSrc = dscode.Tables[0].Rows[0]["BizSrc"].ToString();
            string strChnCls = dscode.Tables[0].Rows[0]["ChnCls"].ToString();
            //pranjali 30-04-2014
            string UserTypeEmp = dscode.Tables[0].Rows[0]["UserType"].ToString();
            string UnitCodeEmp = dscode.Tables[0].Rows[0]["UnitCode"].ToString();//pranjali on 05-04-2014
            if (UserTypeEmp == "I")
            {
                Hashtable htalwEmp = new Hashtable();
                DataSet dsallwrecruitEmp = new DataSet();
                htalwEmp.Add("@MemberCode", strMemberCode);
                htalwEmp.Add("@MemberType", strMemberType);
                dsallwrecruitEmp = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAllowRecruitDtl", htalwEmp);
                if ((dsallwrecruitEmp.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "1") || (dsallwrecruitEmp.Tables[0].Rows[0]["AlwRecruitMem"].ToString() == "True"))
                {
                    if (dsallwrecruitEmp.Tables[0].Rows[0]["EmpCode"].ToString() == txtEmpCode.Text)
                    {

                    }
                    else
                    {
                        lblEmpMsg.Visible = true;
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                        lblEmpMsg.Text = "Employee is not allowed to recruit";
                        return;
                    }
                }
                //pranjali
                DataSet dsRecruiterCode = new DataSet();
                dsRecruiterCode = GetEmployeeDetail(txtEmpCode.Text.Trim());
                if (dsRecruiterCode.Tables.Count > 0)
                {
                    if (dsRecruiterCode.Tables[0].Rows.Count > 0)
                    {
                        string strEmpCode = dsRecruiterCode.Tables[0].Rows[0]["EmpCode"].ToString();
                        string strRecruiterCode = dsRecruiterCode.Tables[0].Rows[0]["MemberCode"].ToString();
                        string strRecruiterType = dsRecruiterCode.Tables[0].Rows[0]["MemberType"].ToString();
                        string strRecruiterBizSrc = dsRecruiterCode.Tables[0].Rows[0]["BizSrc"].ToString();
                        string strRecruiterChnCls = dsRecruiterCode.Tables[0].Rows[0]["ChnCls"].ToString();

                        htParam.Clear();
                        htParam.Add("@MemberCode", strMemberCode);
                        htParam.Add("@RecruiterCode", strRecruiterCode);
                        htParam.Add("@EmpCode", strEmpCode);
                        htParam.Add("@RecruiterType", strRecruiterType);
                        htParam.Add("@RecruiterBizSrc", strRecruiterBizSrc);
                        htParam.Add("@RecruiterChnCls", strRecruiterChnCls);
                       // dsResult.Clear();
                        dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetVerifyEmpDtls", htParam);

                    }
                    else
                    {
                        lblEmpMsg.Visible = true;
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                        lblEmpMsg.Text = "Employee is not allowed to recruit";//"No Match Found";
                        StrMsg = 1;
                    }
                }
            }
            else if (UserTypeEmp == "E")
            {
                DataSet dsEmpCode = new DataSet();
                dsEmpCode = GetEmployeeDetail(txtEmpCode.Text.Trim());
                string strrecruiterCode1 = dsEmpCode.Tables[0].Rows[0]["MemberCode"].ToString();
                string strEmpCode1 = dsEmpCode.Tables[0].Rows[0]["EmpCode"].ToString();
                string strEmpType1 = dsEmpCode.Tables[0].Rows[0]["MemberType"].ToString();
                string strEmpBizSrc1 = dsEmpCode.Tables[0].Rows[0]["BizSrc"].ToString();
                string strEmpChnCls1 = dsEmpCode.Tables[0].Rows[0]["ChnCls"].ToString();
                string strEmpUnitCode1 = dsEmpCode.Tables[0].Rows[0]["UnitCode"].ToString();
                htParam.Clear();
                htParam.Add("@RecruiterCode", strrecruiterCode1);
                htParam.Add("@RecruiterType", strEmpType1);
                htParam.Add("@RecruiterBizSrc", strEmpBizSrc1);
                htParam.Add("@RecruiterChnCls", strEmpChnCls1);
                htParam.Add("@UnitCode", UnitCodeEmp);
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetRecruiterDtlsForExtrnl", htParam);
            }
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    IsFound = true;

                    txtEmpCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpCode"]).Trim();
                    //txtpfSMCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemCode"]).Trim();//commented by shreela on 22/08/2014
                    //Added by pranjali on 27-12-2013 start
                    hdnBranchCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitCode"]).Trim();
                    string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                    string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                    MemberType = dsResult.Tables[0].Rows[0]["MemType"].ToString();
                    if (txtpfAppNo.Text != "" || (!MemberType.ToUpper().Equals("EP") && !MemberType.ToUpper().Equals("LP")))
                        txtBranchCode.Text = branch + " " + "(" + cmsunitcode + ")";
                    //Added by pranjali on 27-12-2013 end
                    txtSMName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                    hdnBizSrc.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                    //Set the Sales Channel 
                    if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                        {
                            //GetRecruitSalesChannel(ddlSlsChannel, "", 0);
                            if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                            {
                                //added by amruta on 6.1.16
                                if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                                {
                                    ddlSlsChannel.SelectedItem.Text = ddlSlsChannel.SelectedItem.Text;
                                }
                                else
                                {
                                   // GetRecruitSalesChannel(ddlSlsChannel, BizSrc, 0, ChnCls);

                                     GetRecruitSalesChannel(ddlSlsChannel, Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), 0, Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                                    ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                    FillddlChannelSubClass(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                }
                                //added by amruta on 7.1.16
                            }
                        }
                    }

                    //Set the Channel sub Class
                    if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                        {
                            if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                            {
                                //added by amruta on 7.1.16
                                if (dsResult.Tables[0].Rows[0]["ChnCls"].ToString().Trim() == "XXXX")
                                {
                                    ddlChnCls.SelectedItem.Text = ddlChnCls.SelectedItem.Text;
                                }
                                else
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                                }
                                //added by amruta on 7.1.16
                            }
                        }
                    }

                    strAgentType = dsResult.Tables[0].Rows[0]["MemType"].ToString().Trim();
                    if (dsResult.Tables[0].Rows[0]["BizSrc"].ToString().Trim() == "XX")
                    {
                        // PopulateAgentTypes();


                         FillCndAgntType(ddlSlsChannel.SelectedValue, ddlChnCls.SelectedValue);//01
                    }
                    else
                    {
                        PopulateAgentTypes();
                       // FillCndAgntType(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());//01
               

                        FillCndAgntType(ddlSlsChannel.SelectedValue,ddlChnCls.SelectedValue);//01
                    }
                   
                    //txtpfSMCode.Enabled = false;//commented by shreela 22/08/2014
                    //btnVerifySMCode.Enabled = false;//commented by shreela 22/08/2014
                }
            }

            

            
            dsResult = null;
            SqlDataReader drResult;
            Hashtable httable = new Hashtable();
            if (IsFound == false)
            {
                lblEmpMsg.Visible = true;
                lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                lblEmpMsg.Text = "Employee is not allowed to recruit";//"No Match Found";
            }
            else
            {
                    lblEmpMsg.Visible = true;
                    lblEmpMsg.ForeColor = System.Drawing.Color.Green;
                    lblEmpMsg.Text = "Employee Code verified.";
                    //btnVerifySMCode.Enabled = false;//commented by shreela on 22/08/2014
                    //txtpfSMCode.Enabled = false;//commented by shreela on 22/08 2014
                    ddlAgnTypes.Focus();
            }
            Button1.Focus();
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
    //added by amruta on 5.1.16 for candidate channel info start
    #region 'ddlSlsChannel_SelectedIndexChanged'
    protected void ddlSlsChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string bizsrc=ddlSlsChannel.SelectedValue.ToString().Trim();

        try
        {
          
            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@BizSrc", bizsrc);
            htParam.Add("@carrierCode", "2");
            htParam.Add("@flag", "3");
            if (bizsrc != "XX")
            {
                dsresult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_ddlchnnlsubcls", htParam, "INSCCommonConnectionString");
                if (dsresult.Tables[0].Rows.Count > 0)
                {

                    ddlChnCls.SelectedItem.Text = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnlDesc"]).Trim();
                    ViewState["cndChnCls"] = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim();
                    FillddlChannelSubClass(bizsrc);
                    ddlChnCls.SelectedValue = Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim();
                }
                FillCndAgntType(bizsrc, Convert.ToString(dsresult.Tables[0].Rows[0]["ChnCls"]).Trim());
            }
            else
            {
                ddlChnCls.SelectedItem.Text = "Select";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Candidate Channel in Hierarchy Name')", true);
                ProgressBarModalPopupExtender.Hide();
                ddlSlsChannel.Focus();
                return;
            } 
        }
        catch (Exception ex)
        {

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
        }
    }
    #endregion
    //added by amruta on 5.1.16 for candidate channel info end

    #region verify aadhar no
    //added by amruta on 23.9.16 for aadhar no verification start
    protected void btnVerifyaadhar_Click(object sender, EventArgs e)
    {
        string a= txtaadhr.Text;
        bool b=AadharNo.Aadhar.Check(a);
        if (b==true)
        {
            lblAadharMsg.Text = "Aadhar No. is verified.";
            lblAadharMsg.ForeColor = Color.Green;
        }
       
        else
	   {
            lblAadharMsg.Text = "Aadhar No. is not valid.";
            lblAadharMsg.ForeColor = Color.Red;
	   }

    }
    //added by amruta on 23.9.16  for aadhar no verification end
    #endregion

    protected void btnmemgrid_Click(object sender, EventArgs e)
    {
        var htbl = new Hashtable();
        htbl.Add("@EmpCode", strUser);
        var ds = dataAccessRecruit.GetDataSetForPrcDBConn("prc_GetMember", htbl, "INSCCommonConnectionString");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmsg", "openBranchList('" + ds.Tables[0].Rows[0]["BizSrc"].ToString() + "','" + ds.Tables[0].Rows[0]["ChnCls"].ToString() + "','" + ds.Tables[0].Rows[0]["AgentType"].ToString() + "','" + ds.Tables[0].Rows[0]["MgrCode"].ToString() + "','" + ds.Tables[0].Rows[0]["Type"].ToString() + "','" + ds.Tables[0].Rows[0]["IsAgt"].ToString() + "','" + ds.Tables[0].Rows[0]["agttype"].ToString() + "');", true);
        }
    }

    protected void btnunitgrid_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)Session["unt"];
        txtBranchCode.Text = dt.Rows[0]["UnitDesc01"].ToString() + " (" + dt.Rows[0]["UnitCode"].ToString() + ") ";
        Session["unitcode"]=txtBranchCode.Text;
        btnRptMgr.Focus();

    }
    #region 'FillddlAddRptMgrCode'
    private void FillddlAddRptMgrCode()
    {
        try
        {
            ddlAddRptMgrCode.Items.Clear();

            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@MemberCode", MemberCode);
            htParam.Add("@MemberType", MemberType);

            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAddRptMgrCodeDtls", htParam);
            LblRptMgrCode.Text = Convert.ToString(dsresult.Tables[0].Rows[0]["col"]).Trim();
            if (MemberType == "FP")
            {
                LblRptMgrCode.Text = LblRptMgrCode.Text + "<span style=' color:#ff0000'>*</span>";
            }
            if (dsresult.Tables[1].Rows.Count > 0)
            {

                ddlAddRptMgrCode.DataSource = dsresult.Tables[1];
                ddlAddRptMgrCode.DataTextField = "Desc01";
                ddlAddRptMgrCode.DataValueField = "value";
                ddlAddRptMgrCode.DataBind();
                ddlAddRptMgrCode.Items.Insert(0, new ListItem("--Select--", ""));

                //if (dsresult.Tables[1].Rows.Count == 1)
                //{ 
                //// ddlAddRptMgrCode.SelectedValue=dsresult.Tables[1].Rows[0]["value"].ToString().Trim();
                //// ddlAddRptMgrCode.Enabled=false;
                //}
                dsresult = null;

            }
            else
            {
                ddlAddRptMgrCode.Items.Insert(0, new ListItem("--Select--", ""));
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

    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dsresult = new DataSet();
            htParam.Clear();
            htParam.Add("@BizSrc", ddlSlsChannel.SelectedValue.ToString().Trim());
            htParam.Add("@Chncls", ddlChnCls.SelectedValue.ToString().Trim());

            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetCndAgnType", htParam);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ViewState["AgtType"] = Convert.ToString(dsresult.Tables[0].Rows[0]["MemType"]).Trim();
                ddlCndAgtType.DataSource = dsresult;
                ddlCndAgtType.DataTextField = "MemTypeDesc01";
                ddlCndAgtType.DataValueField = "MemType";
                ddlCndAgtType.DataBind();
                string ProsReg = Request.QueryString["Type"].ToString();

                dsresult = null;

            }

        }
        catch (Exception ex)
        {

            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
        }

    }
}
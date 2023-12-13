//Modifier Name :  Ajay Yadav 
//Started date  :  10-11-2022
//Modified      :   UI
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
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using INSCL.App_Code;
using INSCL.DAL;
using CLTMGR;
using DataAccessClassDAL;
using System.Drawing;

public partial class Application_ISys_ChannelMgmt_FranchiesSerach : BaseClass
{
    #region Global declaration
    string strFlagmenu = string.Empty;
    DataAccessClass objDAL = new DataAccessClass();
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private const string Conn_Direct = "DefaultConn";
    private multilingualManager olng;
    DataView dvResult = new DataView();
    Hashtable htParam = new Hashtable();
    string strUnitCode = string.Empty;
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsmulti = new DataSet();
    DataSet ds_UnitType = new DataSet();
    Hashtable htmulti = new Hashtable();
    string user = string.Empty;
    string usertype = string.Empty;
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    ErrLog objErr = new ErrLog();
    DataSet dsCfruser = new DataSet(); //added by pranjali on 02-04-2014
    string Code;//added by pranjali on 15042014
    String ModuleID = string.Empty;//Added by usha on 25.06.2021
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "AdvTrn50HrsSearch.aspx", Session["UserLangNum"].ToString());
            //  ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            if (!IsPostBack)
            {
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds1);
              //  ddlProcessType1();
                InitializeControl();
                GetAgentandUserDtls();
                //Added by usha for noc (userrolcode) on 1.07.2015
                GetAgentandUserDtls_lic();

                ViewState["Value"] = Request.QueryString["Pg"].ToString().Trim();//added by shreela on 15/07/2014 

                #region NEW REQUEST
                if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "NW")
                {
                    trnote.Visible = true;
                    divcolor.Visible = false;
                    Code = Request.QueryString["Code"].ToString().Trim();//added by pranjali on 15042014
                    trtitle.Visible = false;
                    divBrnuser.Visible = false;
                    trDgViewDtl.Visible = true;
                    trSearchDetails.Visible = true;
                   // trgridsponsorship.Visible = false;
                    trbtnexport.Visible = false;
                    btnExport.Visible = false;
                    ddlreqstatus.SelectedItem.Text = "New Request";
                    ddlreqstatus.Enabled = false;
                    lblRequestDate.Visible = false;
                    txtReqDate.Visible = false;
                    btnCalendar.Visible = false;
                    lblTitle.Text = "Document Upload Search";
                    trtitle.Text = "Document Upload Search Result";
                    trregstrtndt.Visible = true;
                    TrForSpon.Visible = true;


                }//Added by usha  for noc 
                #endregion
                else if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "NOC")
                {
                    Code = Request.QueryString["Code"].ToString().Trim();
                    trtitle.Visible = false;
                    divBrnuser.Visible = false;
                    trDgViewDtl.Visible = true;
                    trSearchDetails.Visible = true;
                   // trgridsponsorship.Visible = false;
                    trbtnexport.Visible = false;
                    btnExport.Visible = false;
                    ddlreqstatus.Visible = false;
                    lblReqStatus.Visible = false;
                    ddlreqstatus.Enabled = false;
                    lblRequestDate.Visible = false;
                    txtReqDate.Visible = false;
                    btnCalendar.Visible = false;
                    lblTitle.Text = "NOC Request Search";
                    trregstrtndt.Visible = true;
                    trReq.Visible = false;
                    trtraning.Visible = false;
                    trReq.Visible = false;
                    trURN.Visible = true;
                    trCodedlicdetails.Visible = true;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = true;
                    dgView.Columns[6].HeaderText = "Reporting SM Name";
                    dgView.Columns[11].Visible = true;
                    dgView.Columns[12].Visible = true;
                    dgView.Columns[7].Visible = false;
                    dgView.Columns[8].Visible = false;


                }
                #endregion


                #region added by usha for Noc BM CFR search page on 20.07.5015
                else if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "NOCApp")
                {
                    Code = Request.QueryString["Code"].ToString().Trim();
                    trtitle.Visible = false;
                    divBrnuser.Visible = false;
                    trDgViewDtl.Visible = true;
                    trSearchDetails.Visible = true;
                   // trgridsponsorship.Visible = false;
                    trbtnexport.Visible = false;
                    btnExport.Visible = false;
                    ddlreqstatus.Visible = false;
                    lblReqStatus.Visible = false;
                    ddlreqstatus.Enabled = false;
                    lblRequestDate.Visible = false;
                    txtReqDate.Visible = false;
                    trCodedlicdetails.Visible = true;
                    btnCalendar.Visible = false;
                    lblTitle.Text = "NOC  Apporval Search";
                    trregstrtndt.Visible = true;

                }
                #endregion

                #region SPONSORSHIP QC
                else if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "QC")
                {
                    Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                    //divDgViewDtl.Visible = true;
                    //divSearchDetails.Visible = true;
                    trtitle.Visible = false;//pranjali
                    divBrnuser.Visible = false;
                   // trDgViewDtl.Visible = true;//Usha
                    trSearchDetails.Visible = true;//pranjali
                   // trgridsponsorship.Visible = false;//USHA
                    trbtnexport.Visible = false;
                    ddlreqstatus.SelectedItem.Text = "Requested";
                    ddlreqstatus.Enabled = false;
                    lblTitle.Text = "Sponsorship QC Search";
                    btnCalendar.Visible = false;
                    lblRequestDate.Visible = false;
                    txtReqDate.Visible = false;
                    trregstrtndt.Visible = true;
                    txtCFRcolr.Visible = true;
                    lblCFR.Visible = true;
                    txtQCColr.Visible = true;
                    lblQC.Visible = true;

                }
                #endregion


                #region NOC QC
                else if (ViewState["userrollcode"].ToString() == "LICTEAM")
                {
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Lic")
                    {

                        Code = Request.QueryString["Code"].ToString();
                        //divDgViewDtl.Visible = true;
                        //divSearchDetails.Visible = true;
                        divBrnuser.Visible = true;
                        lblTitle.Text = "View CFR Details";
                        trtraning.Visible = false;
                        tdreq.Visible = false;
                        tdreqsta.Visible = false;
                        trDgViewDtl.Visible = false;
                        trSearchDetails.Visible = false;
                        trSearchDetails.Visible = true;
                        TrForSpon.Visible = true;
                        lblProcessType.Visible = true;
                        ddlProcessType.Visible = true;
                        ddlreqstatus.Visible = false;
                        lblReqStatus.Visible = false;
                        lblPan.Visible = false;
                        txtPan.Visible = false;

                        trShw.Visible = false;

                        //BindInbox();
                        BindInbox();
                        BindResponded();
                        //divBrnuser.Visible = false;
                    }
                    //Added by Nikhil Pathari on 27-04-2015 for NOC QC start
                    #region NOC QC Process
                    else if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["status"].ToString() == "QCNoc")
                    {
                        Code = Request.QueryString["Code"].ToString();
                        trtitle.Visible = false;
                        divBrnuser.Visible = false;
                        trDgViewDtl.Visible = true;
                        trSearchDetails.Visible = true;
                       // trgridsponsorship.Visible = false;
                        trbtnexport.Visible = false;
                        ddlreqstatus.Visible = false;
                        lblReqStatus.Visible = false;
                        ddlreqstatus.SelectedItem.Text = "Requested";
                        ddlreqstatus.Enabled = false;
                        trReq.Visible = false;
                        lblTitle.Text = "NOC QC Request";
                        btnCalendar.Visible = false;
                        lblRequestDate.Visible = false;
                        txtReqDate.Visible = false;
                        trregstrtndt.Visible = true;
                        txtCFRcolr.Visible = true;
                        lblCFR.Visible = true;
                        txtQCColr.Visible = true;
                        lblQC.Visible = true;
                        trtraning.Visible = false;
                        trReq.Visible = false;
                        trURN.Visible = true;
                        trCodedlicdetails.Visible = true;
                        dgView.Columns[3].Visible = false;
                        dgView.Columns[4].Visible = false;
                        dgView.Columns[5].Visible = true;
                        dgView.Columns[6].HeaderText = "Reporting SM Name";
                        dgView.Columns[11].Visible = true;
                        dgView.Columns[12].Visible = true;
                        dgView.Columns[7].Visible = false;
                        dgView.Columns[8].Visible = false;
                    }
                    #endregion


                    //Added by Nikhil Pathari on 29-07-2015 for NOC QC end
                    //Added by rahul on 25-04-2015 for Retrieval QC start
                    #region Retrieval QC Process
                    else if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["status"].ToString() == "QCRET")
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "onload", "<script language='javascript'>alert('abcd');</script>", false);                                    
                        Code = Request.QueryString["Code"].ToString();
                        trtitle.Visible = false;
                        divBrnuser.Visible = false;
                        trDgViewDtl.Visible = true;
                        trSearchDetails.Visible = true;
                       // trgridsponsorship.Visible = false;
                        trbtnexport.Visible = false;
                        ddlreqstatus.SelectedItem.Text = "Requested";
                        ddlreqstatus.Enabled = false;
                        lblTitle.Text = "Retrieval QC Request";
                        btnCalendar.Visible = false;
                        lblRequestDate.Visible = false;
                        txtReqDate.Visible = false;
                        trregstrtndt.Visible = true;
                        txtCFRcolr.Visible = true;
                        lblCFR.Visible = true;
                        txtQCColr.Visible = true;
                        lblQC.Visible = true;
                    }
                    #endregion

                }
                #endregion

                //#region VIEW CFR FOR LICENSED USER  // 
                //Added by usha for  SI user on 16.01.2016
                // else if (ViewState["MemberType"].ToString().Trim() != "SM") || ViewState["MemberType"].ToString().Trim() != "SI")
                //  else if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                //added by usha  31.03.2022
                else if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
                  (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                {
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                    {
                        //  if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR") //Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                        // {
                        Code = Request.QueryString["Code"].ToString();
                        divBrnuser.Visible = true;
                        lblTitle.Text = "View CFR Details";
                        trtraning.Visible = false;
                        ddlreqstatus.Visible = false;
                        lblReqStatus.Visible = false;
                        ddlreqstatus.SelectedItem.Text = "Requested";
                        ddlreqstatus.Enabled = false;
                        trReq.Visible = false;
                        tdreq.Visible = false;
                        tdreqsta.Visible = false;
                        trDgViewDtl.Visible = false;
                        trSearchDetails.Visible = false;
                        trSearchDetails.Visible = true;
                        TrForSpon.Visible = false;
                        trShw.Visible = false;
                        BindInbox();
                        trtraning.Visible = false;
                        trReq.Visible = false;

                        dgView.Columns[3].Visible = false;
                        dgView.Columns[4].Visible = false;
                        dgView.Columns[5].Visible = true;
                        dgView.Columns[6].HeaderText = "Reporting SM Name";
                        dgView.Columns[11].Visible = true;
                        dgView.Columns[12].Visible = true;
                        dgView.Columns[7].Visible = false;
                        dgView.Columns[8].Visible = false;
                    }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "onload", "<script language='javascript'>alert('1234');</script>", false);                                    
                }
                //#endregion




                #region VIEW CFR FOR BRANCHED USER
                else
                {

                    //if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["status"].ToString() == "NOC")
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "NOC")
                    {
                        Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                        divBrnuser.Visible = true;
                        lblTitle.Text = "View CFR Details";
                        trtraning.Visible = false;
                        tdreq.Visible = false;
                        tdreqsta.Visible = false;
                        trDgViewDtl.Visible = false;
                        trSearchDetails.Visible = false;
                        trSearchDetails.Visible = true;
                        TrForSpon.Visible = false;
                        trShw.Visible = false;
                        BindInbox();
                    }
                    else
                    {
                        Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                        //added by pranjali for disabling CFR tab for branch user start
                        LnkCFR_Inbox.Visible = false;
                        LnkCFR_Respond.Visible = false;
                        LnkCFR_Close.Visible = false;
                        LnkCFR_CFR.Visible = false;
                        divBrnuser.Visible = true;

                        //added by pranjali for disabling CFR tab for branch user end
                        lblTitle.Text = "View CFR Details";
                        trtraning.Visible = false;
                        tdreq.Visible = false;
                        tdreqsta.Visible = false;
                        trDgViewDtl.Visible = false;
                        trSearchDetails.Visible = false;
                        trSearchDetails.Visible = true;
                        TrForSpon.Visible = true;
                        lblProcessType.Visible = true;
                        ddlProcessType.Visible = true;
                        ddlreqstatus.Visible = false;
                        lblReqStatus.Visible = false;
                        lblPan.Visible = false;

                        txtPan.Visible = false;
                        trShw.Visible = false;
                        BindInbox();
                        BindResponded();
                    }
                }
                #endregion
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds);//Added by rachana on 24122013  


            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            //objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //#endregion
    #region InitializeControl()
    private void InitializeControl()
    {
        try
        {
            lblTitle.Text = "Personal Details";//olng.GetItemDesc("lblTitle");
            //lblAgentCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgentCode"));
            lblFranCode.Text = "Code";
            lblFranSapCode.Text = "SAP Code"; /*olng.GetItemDesc("lblFranSapCode");*/
            lblFranName.Text = "Franchise Name"; /*olng.GetItemDesc("lblFranName");*///Added by rachana on 24122013 for Search procedure
            lblRequestDate.Text = olng.GetItemDesc("lblRequestDate");
            lblGivenName.Text = "Name";// olng.GetItemDesc("lblGivenName");
            lblBranchName.Text = olng.GetItemDesc("lblBranchName");//Added by rachana on 24122013 for Search procedure
            lblShwRecords.Text = olng.GetItemDesc("lblShwRecords");
            lblReqStatus.Text = "(dd/mm/yyyy)"; //olng.GetItemDesc("lblReqStatus");
            lblSurName.Text = olng.GetItemDesc("lblSurName");//Added by pranjali on 26022014
            //lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text")); //added by pranjali on 20-03-2014
            //lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));//added by pranjali on 20-03-2014
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));//added by Shreela on 10042014

            if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "QC")
            {
                lblDTRegFrom.Text = "Request Date From";
                lblDTRegTO.Text = "Request Date To";
            }
            else
            {
                lblDTRegFrom.Text = "Registration Date From";/*(olng.GetItemDesc("lblDTRegFrom.Text"));*/ //added by pranjali on 20-03-2014
                lblDTRegTO.Text = "Registration Date To"; /*(olng.GetItemDesc("lblDTRegTO.Text"));//added by pranjali on 20-03-2014*/
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
    #region GetAgentandUserDtls
    private void GetAgentandUserDtls()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["unitrank"] = dsAgent.Tables[0].Rows[0]["UnitCode"].ToString();
                    ViewState["unitcode"] = dsAgent.Tables[0].Rows[0]["UnitRank"].ToString();

                    ViewState["MemberCode"] = dsAgent.Tables[0].Rows[0]["MemberCode"].ToString();
                    ViewState["MemberType"] = dsAgent.Tables[0].Rows[0]["MemberType"].ToString();
                    ViewState["BizSrc"] = dsAgent.Tables[0].Rows[0]["BizSrc"].ToString();
                    ViewState["ChnCls"] = dsAgent.Tables[0].Rows[0]["ChnCls"].ToString();
                    ViewState["UserType"] = dsAgent.Tables[0].Rows[0]["UserType"].ToString();
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

    private void GetAgentandUserDtls_lic()
    {
        try
        {
            DataSet dsAgent = new DataSet();
            dsAgent = oCommonUtility.GetUserDtls_lic(HttpContext.Current.Session["UserID"].ToString().Trim());

            if (dsAgent.Tables.Count > 0)
            {
                if (dsAgent.Tables[0].Rows.Count > 0)
                {
                    ViewState["userrollcode"] = dsAgent.Tables[0].Rows[0]["UserRoleCode"].ToString();

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
    #region btnSearch Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            hdnMenuName.Value =Request.Form[hdnMenuName.UniqueID];
            TabName.Value = Request.Form[TabName.UniqueID];
            ////start sanoj 24052022
            //if (Request.QueryString["Type"].Trim() == "viewDocs")
            //{
            //    DocGridBind();
            //    return;

            //}
            ////ended sanoj 24052022



            //For admin/sysadmin user user
            if (Request.QueryString["pg"].ToString() == "50hrs")
            {
                hdnCndNo.Value = txtFranCode.Text.Trim();
                hdnCndName.Value = txtName.Text.Trim();
                //hdnApplicationNo.Value = txtAppNo.Text.Trim();
                hdnRecruiterCode.Value = txtRecruiterName.Text.Trim();//Changed by rachana on 24122013 as appno not required     
                hdnTrnReqDt.Value = txtReqDate.Text.ToString().Trim();
                if (txtPan.Text.ToString().Trim() != "")
                {
                    if (txtPan.Text.Length < 5)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Minimum 5 characters required for PAN No')", true);
                        return;
                    }
                }
                BindDataGrid();
                //btnExport.Visible = true;
            }

            //For branched user
            else
            {
                if (hdnMenuName.Value == "1" || hdnMenuName.Value == "0")
                {
                    strFlagmenu = "1";
                    txtResponded.Text = "1";
                    
                    txtprevious1.Text = "1";
                    BindInbox();
                    BindResponded1();
                    inbox.Attributes.Add("class", "active");
                    responded.Attributes.Add("class", "");

                }
                if (hdnMenuName.Value == "2")
                {
                    strFlagmenu = "2";
                    txtResponded.Text = "1";
                    
                    txtprevious1.Text = "1";
                    
                    BindInbox();
                    BindResponded();
                    responded.Attributes.Add("class", "active");
                    inbox.Attributes.Add("class", "");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "showSelectedTab();", true);

                    //BindResponded();
                    //BindInbox1();


                }
            }
            //if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Lic")
            //{
            //    divBrnuser.Visible = true;
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
    }
    #endregion
    #region BindDataGrid()
    void BindDataGrid()
    {
        try
        {
            #region HO user
            dgView.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue.Trim());

            //Binds the data to grid of candidates came after approval with cndstatus='40' for 50 Hrs Training Request 
            DataTable dtResult_HrsTrn = new DataTable();
            dtResult_HrsTrn = GetDataTableForHrsTrn();

            if (dtResult_HrsTrn != null)
            {
                if (dtResult_HrsTrn.Rows.Count > 0)
                {
                    if (Request.QueryString["Status"].ToString().Trim() == "NOC")
                    {
                        lblprospectsearch.Text = "NOC Request Search";
                        txtQCColr.Visible = false;
                        lblQC.Visible = false;
                    }
                    else if (Request.QueryString["Status"].ToString().Trim() == "NOCApp")
                    {
                        lblprospectsearch.Text = "NOC Approval Search";
                        txtCFRcolr.Visible = true;
                        lblCFR.Visible = true;

                    }
                    else if (Request.QueryString["Status"].ToString().Trim() == "QCNoc")
                    {
                        lblprospectsearch.Text = "NOC QC Result";
                        dgView.Columns[8].Visible = true;
                        dgView.Columns[8].HeaderText = "Actionable Date";
                    }
                    //divDgViewDtl.Visible = true;
                    trDgViewDtl.Visible = true;//pranjali
                    trtitle.Visible = true;//pranjali
                  //  trgridsponsorship.Visible = true;
                    trDgViewDtl.Visible = true;//Added by usha on 27_04_2023
                    lblMessage.Visible = false;
                    dgView.DataSource = dtResult_HrsTrn;
                    dgView.DataBind();
                    //ShowPageInformation();
                    trnote.Visible = true;
                    ViewState["grid"] = dtResult_HrsTrn;
                    if (dgView.PageCount > Convert.ToInt32(txtprevious1.Text))
                    {
                        btnnext1.Enabled = true;
                    }
                    else
                    {
                        btnnext1.Enabled = false;
                    }
                    QCPage.Visible = true;
                   // trInboxMsg.Visible = false;
                }
                else
                {
                    //divDgViewDtl.Visible = false;
                    trDgViewDtl.Visible = false;//pranjali
                    trtitle.Visible = false;//pranjali
                    dgView.DataSource = null;
                    dgView.DataBind();
                    trRecord.Visible = true;
                   lblMessage.Text = "0 Record Found";
                      lblMessage.Visible = true;
                }
            }
            else
            {
                //divDgViewDtl.Visible = false;
                trDgViewDtl.Visible = false;//pranjali
                trtitle.Visible = false;//pranjali
                dgView.DataSource = null;
                dgView.DataBind();
                trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
    #region GetDataTableForHrsTrn()
    protected DataTable GetDataTableForHrsTrn()
    {
        DataSet ds_50HrsSearch = new DataSet();
        DataTable dt_50HrsSearch = new DataTable();
        try
        {
            //Searches the candidates with cndstatus='40' for 50 Hrs Training Request
            dt_50HrsSearch = null;
            htParam.Clear();
            htParam.Add("@Memcode", TxtMemCode.Text.Trim());//Added by usha on 31.05.2022
            htParam.Add("@EmpCode", txtFranCode.Text.Trim());

            htParam.Add("@CndName", txtName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim()); //added by pranjali on 26022014 for surname 
            htParam.Add("@PAN", TxtPanNo.Text.Trim());//added by shreela on 10042014
            if (txtReqDate.Text.Trim() != "")
            {
                htParam.Add("@ReqDate", DateTime.Parse(txtReqDate.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@ReqDate", System.DBNull.Value);
            }
            //comented  by usha on 31.05.2022 for search procedure start   
            //if (txtAppNo.Text.ToString().Trim() != "")
            //{
            //    htParam.Add("@Memcode", txtAppNo.Text.ToString().Trim());
            //}
            //else
            //{
            //    htParam.Add("@Memcode", System.DBNull.Value);
            //}
            if (ddlreqstatus.SelectedItem.Text.Trim() != "--Select--")
            {
                htParam.Add("@ReqStatus", ddlreqstatus.SelectedItem.Text.ToString().Trim());
            }
            else if (Request.QueryString["status"].ToString() == "QCNoc")
            {
                htParam.Add("@ReqStatus", System.DBNull.Value);
            }
            else
            {
                htParam.Add("@ReqStatus", System.DBNull.Value);
            }

            if (txtRecruiterName.Text.ToString().Trim() != "")
            {
                htParam.Add("@RecruiterName", txtRecruiterName.Text.ToString().Trim());
            }
            else
            {
                htParam.Add("@RecruiterName", System.DBNull.Value);
            }
            //added by pranjali on 20-03-2014 start
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }
            //added by pranjali on 20-03-2014 end
            if (txtBranchName.Text.ToString().Trim() != "")
            {
                htParam.Add("@BranchName", txtBranchName.Text.ToString().Trim());
            }
            else
            {
                htParam.Add("@BranchName", System.DBNull.Value);
            }
            if (ddlProcessType.SelectedValue != "")
            {
                if (ddlProcessType.SelectedValue == "Retrival")
                {
                    htParam.Add("@ProcessType", "RW");
                    htParam.Add("@CandType", System.DBNull.Value);
                }
                else if (ddlProcessType.SelectedValue == "Reexam")
                {
                    htParam.Add("@ProcessType", "RE");
                    htParam.Add("@CandType", System.DBNull.Value);
                }
                else if (ddlProcessType.SelectedValue == "Fresh")
                {
                    htParam.Add("@ProcessType", "NR");
                    htParam.Add("@CandType", "F");
                }
                else if (ddlProcessType.SelectedValue == "Transfer")
                {
                    htParam.Add("@ProcessType", "NR");
                    htParam.Add("@CandType", "T");
                }
                else if (ddlProcessType.SelectedValue == "Composite")
                {
                    htParam.Add("@ProcessType", "NR");
                    htParam.Add("@CandType", "C");
                }
                else if (ddlProcessType.SelectedValue == "NOC")
                {
                    htParam.Add("@ProcessType", "NC");
                    htParam.Add("@CandType", System.DBNull.Value);
                }
                //added by usha for Noc BM search page on 11.07.5015 
                else if (ddlProcessType.SelectedValue == "NOCApp")
                {
                    htParam.Add("@ProcessType", "NC");
                    htParam.Add("@CandType", System.DBNull.Value);
                }
                else if (ddlProcessType.SelectedValue == "POSP(Fresh)")
                {
                    htParam.Add("@ProcessType", "NR");
                    htParam.Add("@CandType", "P");
                }
            }
            else
            {
                htParam.Add("@ProcessType", System.DBNull.Value);
                htParam.Add("@CandType", System.DBNull.Value);
            }
            if (ddlreqstatus.SelectedItem.Text == "New Request")
            {
                //For Internal UserType
                if (ViewState["UserType"].ToString() == "I")
                {
                    htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("PRC_GET_MEMBER_DOCUPLD_SRCH", htParam);
                    // ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetSponsorshipReqCand", htParam);
                }
                //For External UserType
                else if (ViewState["UserType"].ToString() == "E")
                {
                    ds_50HrsSearch.Clear();
                    //ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetSponsorshipAndQCCandidates", htParam);
                    //Added By Ajay
                    //ds_50HrsSearch = objDAL.GetDataSetForPrcCLP("PRC_GET_MEMBER_DOCUPLD_SRCH", htParam);
                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("PRC_GET_MEMBER_DOCUPLD_SRCH", htParam);
                }
            }
            else
            {
                //Added by Rahul on 25-04-2015 for Retrieval QC Search start
                if (Request.QueryString["Status"].ToString().Trim() == "QCRET")
                {
                    htParam.Add("@BranchCode", string.Empty);
                    htParam.Add("@querystatus", Request.QueryString["Status"].ToString().Trim());
                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRetrievalQCCandidate", htParam);
                }
                else if (Request.QueryString["Status"].ToString().Trim() == "NOC")
                {
                    //lblRequestDate.Text = "NOC Request";
                    htParam.Add("@BranchCode", string.Empty);
                    htParam.Add("@AgentBrokerCode", txtAgntBroker.Text.ToString().Trim());
                    htParam.Add("@AgentSapCode", txtSapCode.Text.ToString().Trim());
                    htParam.Add("@URN", txtURN.Text.ToString().Trim());
                    htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                    htParam.Add("@querystatus", Request.QueryString["Status"].ToString().Trim());
                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNOCCandidate", htParam);
                }
                //Add3d by usha for noc approval 
                else if (Request.QueryString["Status"].ToString().Trim() == "NOCApp")
                {
                    lblprospectsearch.Text = "NOC Request Search";
                    htParam.Add("@BranchCode", Session["UserID"].ToString().Trim());
                    htParam.Add("@AgentBrokerCode", txtAgntBroker.Text.ToString().Trim());
                    htParam.Add("@AgentSapCode", txtSapCode.Text.ToString().Trim());
                    htParam.Add("@URN", txtURN.Text.ToString().Trim());
                    htParam.Add("@querystatus", Request.QueryString["Status"].ToString().Trim());
                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNOCAppCandidate", htParam);

                }
                else

                {
                    if (Request.QueryString["status"].ToString() == "QCNoc")

                    {
                        htParam.Add("@BranchCode", string.Empty);
                        htParam.Add("@AgentBrokerCode", txtAgntBroker.Text.ToString().Trim());
                        htParam.Add("@AgentSapCode", txtSapCode.Text.ToString().Trim());
                        htParam.Add("@URN", txtURN.Text.ToString().Trim());
                        htParam.Add("@Flag", "1");
                    }

                    ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFPSponsorshipAndQCCandidates", htParam);
                }
                //ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetSponsorshipAndQCCandidates", htParam);
                //Added by Rahul on 25-04-2015 for Retrieval QC Search end
            }
            //ds_50HrsSearch = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetSponsorshipAndQCCandidates", htParam);

            if (ds_50HrsSearch != null)
            {
                if (ds_50HrsSearch.Tables.Count > 0)
                {
                    if (ds_50HrsSearch.Tables[0].Rows.Count > 0)
                    {
                        dt_50HrsSearch = ds_50HrsSearch.Tables[0];
                    }
                    else
                    {
                        dt_50HrsSearch = null;
                    }
                }
                else
                {
                    dt_50HrsSearch = null;
                }
            }
            else
            {
                dt_50HrsSearch = null;
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
        return dt_50HrsSearch;
    }
    #endregion
    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdvTrn50HrsSearch.aspx");
        //added by pranjali on 27-11-2013 start
        txtFranCode.Text = "";
        txtAppNo.Text = ""; //added by pranjali on 10-03-2014
        txtRecruiterName.Text = "";
        txtReqDate.Text = "";
        txtDTRegFrom.Text = "";
        txtDTRegTo.Text = "";
        ddlProcessType.SelectedIndex = 0;
        txtName.Text = "";
        txtPan.Text = "";
        txtBranchName.Text = ""; //added by pranjali on 10-03-2014
        txtSurname.Text = ""; //added by pranjali on 10-03-2014
        trDgViewDtl.Visible = false;
        txtURN.Text = "";
        txtSapCode.Text = "";
        txtAgntBroker.Text = "";
        TxtPanNo.Text = "";
        TxtMemCode.Text = "";
        //divDgViewDtl.Visible = false;
        //added by pranjali on 27-11-2013 end
    }
    #endregion
    #region Set Excel File
    protected void SetExcelFile()
    {
        string attachment = "attachment; filename=Sheet1.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/Microsoft Excel 97- Excel 2008 & 5.0/95 Workbook";
    }
    #endregion
    #region
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsHrsTrn = new DataSet();
            htParam.Clear();
            if (hdnCndNo.Value.ToString().Trim() != "")
            {
                htParam.Add("@CndNo", hdnCndNo.Value.ToString().Trim());
            }
            else
            {
                htParam.Add("@CndNo", System.DBNull.Value);
            }

            htParam.Add("@BranchCode", string.Empty);
            if (hdnCndName.Value.ToString().Trim() != "")
            {
                htParam.Add("@AdvName", hdnCndName.Value.ToString().Trim());
            }
            else
            {
                htParam.Add("@AdvName", System.DBNull.Value);
            }

            if (hdnTrnReqDt.Value.ToString().Trim() != "")
            {
                htParam.Add("@ReqDate", hdnTrnReqDt.Value);
            }
            else
            {
                htParam.Add("@ReqDate", System.DBNull.Value);
            }
            //Changed by rachana on 24122013 for search procedure start
            //if (hdnApplicationNo.Value.ToString().Trim() != "")
            //{
            //    htParam.Add("@AppNo", hdnApplicationNo.Value.ToString().Trim());
            //}
            if (hdnRecruiterCode.Value.ToString().Trim() != "")
            {
                htParam.Add("@AppNo", hdnRecruiterCode.Value.ToString().Trim());
            }
            //Changed by rachana on 24122013 for search procedure end
            else
            {
                htParam.Add("@AppNo", System.DBNull.Value);
            }

            dsHrsTrn = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvTrnHrsDtl_Ver1", htParam);

            if (dsHrsTrn.Tables.Count > 0)
            {
                if (dsHrsTrn.Tables[0].Rows.Count > 0)
                {
                    SetExcelFile();
                    string strData;
                    string strHtml = "Request Date" + "\t" + "NoOfHrs" + "\t" + "Application No" + "\t" + "CndNo" + "\t" + "Advisor Name"
                                    + "\t" + "TrnMode" + "\t" + "Training Institute" + "\t" + "ATI Location" + "\t" + "AccrdNo" + "\t" + "WR No" + "\t"
                                    + "WR Amount" + "\t" + "URN No" + "\t" + "Exam Mode" + "\t"
                                    + "Exam Body" + "\t" + "Exam Language" + "\t" + "Exam Centre" + "\t" + "PAN" + "\t" + "Waiver" + "\n";

                    for (int i = 0; i < dsHrsTrn.Tables[0].Rows.Count; i++)
                    {
                        strData = dsHrsTrn.Tables[0].Rows[i]["Request Date"].ToString()
                            + "\t" + dsHrsTrn.Tables[0].Rows[i]["NoOfHrs"].ToString()
                            + "\t" + dsHrsTrn.Tables[0].Rows[i]["Application No"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["CndNo"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Advisor Name"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["TrnMode"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Training Institute"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["ATI Location"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["AccrdNo"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["WR No"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["WR Amount"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["URN No"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Exam Mode"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Exam Body"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Exam Language"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Exam Centre"].ToString()
                        //+ "\t" + dsHrsTrn.Tables[0].Rows[i]["PAN"].ToString()
                        + "\t" + dsHrsTrn.Tables[0].Rows[i]["Waiver"].ToString();

                        strHtml = strHtml + strData + "\n";
                    }
                    byte[] byteData = System.Text.Encoding.ASCII.GetBytes(strHtml.ToString());
                    char[] charData = System.Text.Encoding.ASCII.GetChars(byteData);

                    Response.Write(charData, 0, charData.Length);
                    Response.End();
                    lblMessage.Text = "File Download Successfully ";
                    dsHrsTrn = null;
                }
                else
                {
                    RegisterStartupScript("startupScript", "<script language=JavaScript>alert('New request still not raised');</script>");//Alert text changed by rachana on 31122013
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
    #region dgView PageIndexChanging
    protected void dgView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForHrsTrn();
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

    #region GridInbox PageIndexChanging
    protected void GridInbox_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForInbox();
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
            //ShowPageInformation();
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
    protected DataTable GetDataTableForInbox()
    {
        try
        {
            //dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForCFR_user", htmulti);
            //added by pranjali on 02-04-2014 start
            dsmulti.Clear();
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemAdvDetailsForCFR", htmulti);
            }
            else if (UserType == "E")
            {
                //htmulti.Clear();
                //htmulti.Add("@MemCode", "");
                //htmulti.Add("@EmpCode", "");
                //htmulti.Add("@MemName", "");
                ////htmulti.Add("@MemberCode", MemberCode);
                ////htmulti.Add("@MemberType", MemberType);
                //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemAdvDetailsForCFRForExtrnl", htmulti);
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@Flag", "");
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemAdvDetailsForCFRForExtrnl", htmulti);
            }
            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridInbox.DataSource = dsmulti;
                    GridInbox.DataBind();
                }
                else
                {
                    GridInbox.DataSource = null;
                    GridInbox.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridInbox.DataSource = null;
                GridInbox.DataBind();
                trRecord.Visible = true;
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
        return dsmulti.Tables[0];
    }

    #region GridResponded PageIndexChanging
    protected void GridResponded_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForRespond();
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
            //ShowPageInformation();
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
    protected DataTable GetDataTableForRespond()
    {
        try
        {
            dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRespondedCFR_user", htmulti);
            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                //Added by usha for BM CFR 
                // if (ViewState["MemberType"].ToString().Trim() != "SM")
                //added by usha on 16.01.016
                //added by usha on 22.0.2022
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
           (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                // if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    // if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Brn") && MemberType.ToString().Trim() != "SM")
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                    {

                        //if (ddlProcessType.SelectedValue == "NOC")
                        //{
                        //    htmulti.Add("@processtype", "NC");
                        htmulti.Add("@Flag", "1");
                        dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                        //}
                        //Prc_GetAdvDetailsForCFR
                        //else
                        //{
                        //    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                    }
                }
                else
                {
                    //    htmulti.Add("@MemberCode", MemberCode);
                    //    htmulti.Add("@MemberType", MemberType);
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRespondedCFR", htmulti);
                }
            }
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@Flag", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFRForExtrnl", htmulti);
            }
            //if (UserType == "I")
            //{
            //    htmulti.Clear();
            //    htmulti.Add("@CndNo", "");
            //    htmulti.Add("@AppNo", "");
            //    htmulti.Add("@CndName", "");
            //    htmulti.Add("@MemberCode", MemberCode);
            //    htmulti.Add("@MemberType", MemberType);
            //    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRespondedCFR", htmulti);
            //}
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFRForExtrnl", htmulti);
            }

            //added by pranjali on 02-04-2014 end
            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    GridResponded.DataSource = dsmulti;
                    GridResponded.DataBind();
                }
                else
                {
                    GridResponded.DataSource = null;
                    GridResponded.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridResponded.DataSource = null;
                GridResponded.DataBind();
                trRecord.Visible = true;
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
        return dsmulti.Tables[0];
    }

    #region GridClosed PageIndexChanging
    protected void GridClosed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForClosed();
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
            //ShowPageInformation();
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

    protected DataTable GetDataTableForClosed()
    {
        try
        {
            dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Closed_user", htmulti);

            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Closed", htmulti);
            }
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_MemClosedForExtrnl", htmulti);
            }
            //added by pranjali on 02-04-2014 end

            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    GridClosed.DataSource = dsmulti;
                    GridClosed.DataBind();
                }
                else
                {
                    GridClosed.DataSource = null;
                    GridClosed.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridClosed.DataSource = null;
                GridClosed.DataBind();
                trRecord.Visible = true;
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
        return dsmulti.Tables[0];
    }

    //Added by pranjali on 25022014 for CFR TAB pagination start
    #region GridCFR PageIndexChanging
    protected void GridCFR_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableForAllCFR();
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
            //ShowPageInformation();
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
    protected DataTable GetDataTableForAllCFR()
    {
        dsmulti.Clear();
        //htmulti.Clear();
        //htmulti.Add("@CndNo", "");
        //htmulti.Add("@AppNo", "");
        //htmulti.Add("@CndName", "");
        //htmulti.Add("@UserId", Session["UserID"].ToString());
        //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetails", htmulti);
        //added by pranjali on 02-04-2014 start
        dsCfruser.Clear();
        dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
        string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
        string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
        string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
        string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
        string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
        if (UserType == "I")
        {
            htmulti.Clear();
            htmulti.Add("@MemCode", "");
            htmulti.Add("@EmpCode", "");
            htmulti.Add("@MemName", "");
            htmulti.Add("@MemberCode", MemberCode);
            htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetails", htmulti);
        }
        else if (UserType == "E")
        {
            htmulti.Clear();
            htmulti.Add("@MemCode", "");
            htmulti.Add("@EmpCode", "");
            htmulti.Add("@MemName", "");
            //htmulti.Add("@MemberCode", MemberCode);
            //htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetailsForExtrnl", htmulti);
        }
        //added by pranjali on 02-04-2014 end
        if (dsmulti != null)
        {
            if (dsmulti.Tables.Count > 0)
            {
                GridCFR.DataSource = dsmulti;
                GridCFR.DataBind();
            }
        }
        return dsmulti.Tables[0];
    }
    //Added by pranjali on 25022014 for CFR TAB pagination start

    #region dgView RowCommand
    protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Code = Request.QueryString["Code"].ToString();//added by pranjali on 15042014
        //After click on following command name which page to redirect
        //Added by rachana on 29-07-2013 for Quality check 29-07-2013 start

        if (e.CommandName == "QltyChkClick")
        {
            //Added by rachana on 29-07-2013 to show new window start

            //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=Qc&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=" + Code.Trim() + "&Type=Qc&mdlpopup=','RACHANA','width=1000,height=670,resizable=0,left=190,scrollbars=1');"; //added by pranjali on 15042014

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

            //Added by Rahul on 25-04-2015 for retrieval process start
            if (Request.QueryString["Status"].ToString() == "QCRET")
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                string status = Request.QueryString["Status"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenRET('" + e.CommandArgument.ToString().Trim() + "','" + status.Trim() + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
            }
            else if (Request.QueryString["Status"].ToString() == "QCNoc")
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                string status = Request.QueryString["Status"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOC('" + e.CommandArgument.ToString().Trim() + "','" + status.Trim() + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
            }
            else
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopen('" + e.CommandArgument.ToString().Trim() + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopen('" + e.CommandArgument.ToString().Trim() + "','" + Code.Trim() + "');", true);
            //Added by Rahul on 25-04-2015 for retrieval process end

            //Added by rachana on 29-07-2013 to show new window end          
        }
        if (e.CommandName == "EditReqClick")
        {
            Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=Edit&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=" + Code.Trim() + "&ModuleID=" + ModuleID + "&Type=E&mdlpopup=");//added by pranjali on 15042014
        }


        if (e.CommandName == "ReqClick")
        {
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string MemCode = e.CommandArgument.ToString().Trim();
            //added by sanoj 27052022
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label lblEntityType = (Label)row.FindControl("lblConstCode");
            //ended by sanoj 27052022
            //htParam.Add("@CndNo", cndno);
            //dsValidSM = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkValidSM", htParam);
            //if (dsValidSM.Tables[0].Rows.Count > 0)
            //{
            //Url changed by ajay 20042023 
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup=" + "&Pg=" + Request.QueryString["Pg"].ToString().Trim() + "&Status=" + Request.QueryString["Status"].ToString().Trim() + "&ModuleID=" + ModuleID); //added by pranjali on 15042014 Status

            //ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
            //Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014


            //}
            //else
            //{
            //    Hashtable htagncode = new Hashtable();
            //    DataSet dsAgnCode = new DataSet();
            //    htagncode.Add("@CndNo", cndno);
            //    dsAgnCode = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkAgnCode", htagncode);
            //    if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
            //        return;
            //    }
            //    else
            //    {
            //        string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
            //        Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
            //    }
            // }
        }
        if (e.CommandName == "NOCClick")
        {
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string cndno = e.CommandArgument.ToString().Trim();
            htParam.Add("@CndNo", cndno);
            dsValidSM = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkValidSM", htParam);
            if (dsValidSM.Tables[0].Rows.Count > 0)
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021

                Response.Redirect("NOC.aspx?TrnRequest=Submit&CndNo=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup=");

            }
            else
            {
                Hashtable htagncode = new Hashtable();
                DataSet dsAgnCode = new DataSet();
                htagncode.Add("@CndNo", cndno);
                dsAgnCode = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkAgnCode", htagncode);
                if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                    return;
                }
                else
                {
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
        }

        if (e.CommandName == "NOCAppClick")
        {
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string cndno = e.CommandArgument.ToString().Trim();
            htParam.Add("@CndNo", cndno);
            dsValidSM = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkValidSM", htParam);
            if (dsValidSM.Tables[0].Rows.Count > 0)
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021

                Response.Redirect("NOCApproval.aspx?TrnRequest=Submit&CndNo=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014

            }
            else
            {
                Hashtable htagncode = new Hashtable();
                DataSet dsAgnCode = new DataSet();
                htagncode.Add("@CndNo", cndno);
                dsAgnCode = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkAgnCode", htagncode);
                if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                    return;
                }
                else
                {
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
        }

        //Added   by usa
        if (e.CommandName == "NOCAppClick")
        {
            DataSet dsValidSM = new DataSet();
            Hashtable htParam = new Hashtable();
            string cndno = e.CommandArgument.ToString().Trim();
            htParam.Add("@CndNo", cndno);
            dsValidSM = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkValidSM", htParam);
            if (dsValidSM.Tables[0].Rows.Count > 0)
            {
                ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                //Added by rachana on 29-07-2013 for Quality check 29-07-2013 end
                //Added by rachana on 29-07-2013 to show new window start
                Response.Redirect("NOCApproval.aspx?TrnRequest=Submit&CndNo=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&Type=N&mdlpopup="); //added by pranjali on 15042014
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&AgentCode=" + e.CommandArgument.ToString().Trim() + "&Type=N');", true);
                //Added by rachana on 29-07-2013 to show new window end
            }
            else
            {
                Hashtable htagncode = new Hashtable();
                DataSet dsAgnCode = new DataSet();
                htagncode.Add("@CndNo", cndno);
                dsAgnCode = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ChkAgnCode", htagncode);
                if (dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SM is either not active or has change the branch.Please allocate another SM')", true);
                    return;
                }
                else
                {
                    string agtcode = dsAgnCode.Tables[0].Rows[0]["AgentCode"].ToString().Trim();
                    Response.Redirect("~\\Application\\ISys\\ChannelMgmt\\AGTTransfer.aspx?Type=E&ID=Trf&AgnCd=" + agtcode.ToString(), false);
                }
            }
        }


    }
    #endregion
    #region dgView RowDataBound
    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Added by rachana on 29-07-2013 for setting command name at rowdatabund 29-07-2013 start

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkcmd = new LinkButton();
            Label lblCFRFlag = (Label)e.Row.FindControl("lblCFRFlag");
            lnkcmd = (LinkButton)e.Row.FindControl("lblRequest");
            lblCFRFlag = (Label)e.Row.FindControl("lblCFRFlag");
            if (Request.QueryString["Status"].ToString().Trim() == "QCRET")
            {
                if (lnkcmd.Text == "[Quality check]")
                {
                    lnkcmd.CommandName = "QltyChkClick";
                    if (lblCFRFlag.Text == "Raised")
                    {
                        //e.Row.BackColor = Color.Orange;
                        e.Row.Cells[0].ForeColor = Color.Orange;
                    }
                    Label lblRenwlQCFlag = (Label)e.Row.FindControl("lblRenwlQCFlag");
                    if (lblRenwlQCFlag.Text == "Y" && lblCFRFlag.Text != "Raised")
                    {
                        //e.Row.BackColor = Color.LightGreen;
                        e.Row.Cells[0].ForeColor = Color.LightGreen;
                    }
                }
            }
            else if (Request.QueryString["Status"].ToString().Trim() == "QCNoc")
            {
                if (lnkcmd.Text == "[Quality check]")
                {
                    lnkcmd.CommandName = "QltyChkClick";
                    if (lblCFRFlag.Text == "Raised")
                    {
                        e.Row.Cells[0].ForeColor = Color.Orange;
                    }
                    //Added by Nikhil on 30.11.15
                    //Label lblRenwlQCFlag = (Label)e.Row.FindControl("lblRenwlQCFlag");
                    //if (lblRenwlQCFlag.Text == "Y" && lblCFRFlag.Text != "Raised")
                    //{
                    //    e.Row.BackColor = Color.LightGreen;
                    //}
                    //Ended by Nikhil on 30.11.15
                }
            }
            else if (Request.QueryString["Status"].ToString().Trim() == "QC")
            {
                if (lnkcmd.Text == "[Quality check]")
                {
                    lnkcmd.CommandName = "QltyChkClick";
                    if (lblCFRFlag.Text == "Raised")
                    {
                        e.Row.Cells[0].ForeColor = Color.Orange;
                    }
                    Label lblRenwlQCFlag = (Label)e.Row.FindControl("lblRenwlQCFlag");
                    //comented by usha on 29.1.2021
                    //if (lblRenwlQCFlag.Text == "Y" && lblCFRFlag.Text != "Raised")
                    //{
                    //    e.Row.BackColor = Color.LightGreen;
                    //}
                }
            }

            else if (Request.QueryString["Status"].ToString().Trim() == "NOC")
            {
                lnkcmd.Text = "NOC Request";
                lnkcmd.CommandName = "NOCClick";
            }
            //Added bu usha for noc approval on 11.07.2015 
            else if (Request.QueryString["Status"].ToString().Trim() == "NOCApp")
            {
                lnkcmd.Text = "NOC Approval";
                lnkcmd.CommandName = "NOCAppClick";
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.Cells[0].ForeColor = Color.Orange;
                }
            }
            else
            {
                lnkcmd.CommandName = "ReqClick";
            }
            //if (lblCFRFlag.Text == "Raised")
            //{
            //    e.Row.BackColor = Color.Orange;
            //}
            //Label lblRenwlQCFlag = (Label)e.Row.FindControl("lblRenwlQCFlag");
            //if (lblRenwlQCFlag.Text == "Y")
            //{
            //    e.Row.BackColor = Color.LightGreen;
            //}
            lnkcmd.Attributes.Add("onclick", "LdWaitGrid(100000);");
        }
        //Added by rachana on 29-07-2013 for setting command name at rowdatabund 29-07-2013 end
    }
    #endregion
    #region dgView Sorting Event
    protected void dgView_Sorting(object sender, GridViewSortEventArgs e)
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
            DataTable dt = GetDataTableForHrsTrn();

            DataView dv = new DataView(dt);
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
    #region dgView Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgView.PageIndex + 1;
       // lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgView.PageCount;
    }
    #endregion
    #region Performance QC
    protected void
        lnkInbox_Click(object sender, EventArgs e)
    {
        BindInbox();
        MultiView1.ActiveViewIndex = 0;
        dsmulti = null;
        divBrnuser.Visible = true;
        //divResponded.Visible = false;
        //divInox.Visible = true;
        //lblInbox.Attributes.Add("style", "color: #00cccc; margin-left: 11px;");
        //lblResponded.Attributes.Add("style", "color: #9c9c9a;  margin-left: 11px;");
        LinkButton1.Visible = false;
        LinkButton2.Visible = true;
    }
    protected void lnkResponded_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton2.Visible = false;
            LinkButton1.Visible = true;
            divBrnuser.Visible = true;
            //divResponded.Visible = true;
            //divInox.Visible = false;
            //lblInbox.Attributes.Add("style", "color: #9c9c9a; margin-left: 11px;");
            //lblResponded.Attributes.Add("style", "color: #00cccc;  margin-left: 11px;"); 
            // MultiView1.ActiveViewIndex = 0;
            GridInbox.Visible = false;
            GridResponded.Visible = true;
            GridInbox.Visible = false;
            dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRespondedCFR_bracheduser", htmulti);
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetRespondedCFR_user", htmulti);

            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();

            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                //Added by usha for BM CFR 
                // if (ViewState["MemberType"].ToString().Trim() != "SM")
                //added by usha on 16.01.016
                //added by usha on 22.0.2022
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
           (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                //  if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    // if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Brn") && MemberType.ToString().Trim() != "SM")
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                    {

                        //if (ddlProcessType.SelectedValue == "NOC")
                        //{
                        //    htmulti.Add("@processtype", "NC");
                        htmulti.Add("@Flag", "1");
                        dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                        //}
                        //Prc_GetAdvDetailsForCFR
                        //else
                        //{
                        //    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                    }
                }
                else
                {
                    //    htmulti.Add("@MemberCode", MemberCode);
                    //    htmulti.Add("@MemberType", MemberType);
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFR", htmulti);
                }
            }
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@Flag", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFRForExtrnl", htmulti);
            }
            //added by pranjali on 02-04-2014 end

            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    GridResponded.DataSource = dsmulti;
                    GridResponded.DataBind();
                }
                else
                {
                    GridResponded.DataSource = null;
                    GridResponded.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridResponded.DataSource = null;
                GridResponded.DataBind();
                trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
            }
            MultiView1.ActiveViewIndex = 1;
            dsmulti = null;
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

    protected void BindResponded()
    {
        dsmulti.Clear();
        dsCfruser.Clear();
        dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
        string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
        string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
        string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
        string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
        string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();

        if (UserType == "I")
        {
            htmulti.Clear();
            htmulti.Add("@MemberCode", MemberCode);
            htmulti.Add("@MemberType", MemberType);
            htmulti.Add("@MemCode", "");
            htmulti.Add("@EmpCode", "");
            htmulti.Add("@MemName", "");
            //added by sanoj 
            htmulti.Add("@Surname", txtSurname.Text.Trim());
            htmulti.Add("@PAN", TxtPanNo.Text.Trim());
            if (txtDTRegFrom.Text.Trim() != "")
            {
                htmulti.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htmulti.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htmulti.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htmulti.Add("@CreateToDtim ", System.DBNull.Value);
            }
            //enned by sanoj for search parameter 12062023

            if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
       (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
            {
                if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                {
                    htmulti.Add("@Flag", "1");
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                }
            }
            else
            {
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFR", htmulti);
            }
        }
        else if (UserType == "E")
        {
            htmulti.Clear();
           htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
            htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
            htmulti.Add("@MemName", txtName.Text);
            //htmulti.Add("@MemCode", "");
            //htmulti.Add("@EmpCode", "");
            //htmulti.Add("@MemName", "");
            htmulti.Add("@Flag", "");
            dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFRForExtrnl", htmulti);
        }
        if (dsmulti != null)
        {
            if (dsmulti.Tables.Count > 0)
            {
                GridResponded.DataSource = dsmulti;
                GridResponded.DataBind();
            }
            else
            {
                GridResponded.DataSource = null;
                GridResponded.DataBind();
                trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
            }
        }
        else
        {
            GridResponded.DataSource = null;
            GridResponded.DataBind();
            trRecord.Visible = true;
            lblMessage.Text = "0 Record Found";
            lblMessage.Visible = true;
        }
        MultiView1.ActiveViewIndex = 1;
        dsmulti = null;
    }

    protected void LinkClosed_Click(object sender, EventArgs e)
    {
        try
        {
            //Added by  usha on 15.04.2020
            if (txtFranCode.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter EmployeeCode number')", true);
                return;
            }
            GridInbox.Visible = false;
            GridResponded.Visible = false;
            GridClosed.Visible = true;
            dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            ////dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Closed_bracheduser", htmulti);
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Closed_user", htmulti);

            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                //comented by  usha on 15.04.2002
                //htmulti.Add("@CndNo", "");
                //htmulti.Add("@AppNo", "");
                //htmulti.Add("@CndName", "");
                //added by  usha on 15.04.2002
                htmulti.Add("@MemCode", txtAppNo.Text);
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
                //added by usha 
                // if (ViewState["MemberType"].ToString().Trim() != "SM")
                //added by usha on 16.01.016
                //added by usha on 22.0.2022
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
           (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                // if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                    {

                        if (ddlProcessType.SelectedValue == "NOC")
                        {
                            htmulti.Add("@processtype", "NC");

                            dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ClosedCFRFroNOC", htmulti);
                        }


                        else
                        {
                            dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_ClosedCFRFroNOC", htmulti);
                        }
                    }
                }
                else
                {
                    htmulti.Add("@MemberCode", MemberCode);
                    htmulti.Add("@MemberType", MemberType);
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_Closed", htmulti);
                }
            }//ended by usha 
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", txtAppNo.Text);
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
                htmulti.Add("@Flag", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_MemClosedForExtrnl", htmulti);
            }
            //added by pranjali on 02-04-2014 end

            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    GridClosed.DataSource = dsmulti;
                    GridClosed.DataBind();
                }
                else
                {
                    GridClosed.DataSource = null;
                    GridClosed.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridClosed.DataSource = null;
                GridClosed.DataBind();
                trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
            }
            MultiView1.ActiveViewIndex = 2;
            dsmulti = null;
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
    //Added by pranjali on 25022014 on click of CFR TAB start
    protected void LinkCFRs_Click(object sender, EventArgs e)
    {
        try
        {
            GridInbox.Visible = false;
            GridResponded.Visible = false;
            GridClosed.Visible = false;
            GridCFR.Visible = true;
            dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetails", htmulti);

            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetailsForNOC", htmulti);
            }
            else if (UserType == "E")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", "");
                htmulti.Add("@EmpCode", "");
                htmulti.Add("@MemName", "");
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCFRDetailsForExtrnl", htmulti);
            }
            //added by pranjali on 02-04-2014 end

            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    GridCFR.DataSource = dsmulti;
                    GridCFR.DataBind();
                }
                else
                {
                    GridCFR.DataSource = null;
                    GridCFR.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridCFR.DataSource = null;
                GridCFR.DataBind();
                trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
            }
            MultiView1.ActiveViewIndex = 3;
            dsmulti = null;
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
    //Added by pranjali on 25022014 on click of CFR TAB end

    private void GetRenewalDtls()
    {
        Hashtable htRe = new Hashtable();
        DataSet dsRe = new DataSet();
        htRe.Add("@CndNo", ViewState["CndNo"]);
        dsRe = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetCndLicnsDtls", htRe);
        //viewstate for inserting fees details
        ViewState["RenewalFlag"] = dsRe.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
        ViewState["RnwlQCFlag"] = dsRe.Tables[0].Rows[0]["RnwlQCFlag"].ToString().Trim();
        ViewState["IsUpld"] = dsRe.Tables[0].Rows[0]["IsUpld"].ToString().Trim();
    }
    protected void GridInbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
        //added by rachana on 13022013 for open inbox with edit and view cfr part start   
        if (e.CommandName == "ViewCFR")
        {

            //Added by usha for BM 
            // if (ViewState["MemberType"].ToString().Trim() != "SM" && ViewState["userrollcode"].ToString() != "LICTEAM")
            //added by usha on 16.01.016

            if (ViewState["userrollcode"].ToString().Trim() != "SMUSER" && ViewState["userrollcode"].ToString() != "LICTEAM")

            {

                if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                {


                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblCndno = (Label)row.FindControl("lblCndNo");
                    ViewState["CndNo"] = lblCndno.Text;
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','IN');", true);





                }

                //Ended by usha 

            }

            //added by usha for inbox details 
            else if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Lic")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                Label lblProcessType = (Label)row.FindControl("lblProcessType");

                DataSet dsMulti = new DataSet();
                Hashtable htParam2 = new Hashtable();
                htParam2.Add("@MemCode", lblCndno.Text);
                dsMulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UserMemRoleCode", htParam2);
                ViewState["userrolcode"] = dsMulti.Tables[0].Rows[0]["UserRoleCode"].ToString().Trim();
                ViewState["CndNo"] = lblCndno.Text;
                ViewState["ProcessType"] = lblProcessType.Text;

                if (ddlProcessType.SelectedValue == "NOC" || ViewState["ProcessType"].ToString() == "NOC")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRNOCres1('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
                }
                else
                {

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
                    //Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&EntityType=" + lblEntityType.Text.ToString().Trim() + "&Type=ViewDoc&mdlpopup="); //added by pranjali on 15042014
                    Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&MemCode=" + lblCndno.Text + "&Code=" + Code + "&Type=Qc&user=Lic&mdlpopup=MdlPopRaiseSub");
                }
            }
            else
            {

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                Label lblProcessType = (Label)row.FindControl("lblProcessType");
                Label hdnmemtype = (Label)row.FindControl("hdnmemtype");//added by ajay 05 june 2023

                DataSet dsMulti = new DataSet();
                Hashtable htParam2 = new Hashtable();
                htParam2.Add("@MemCode", lblCndno.Text);
                dsMulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UserMemRoleCode", htParam2);
                string strFlag = dsMulti.Tables[0].Rows[0]["Flag"].ToString().Trim();
                if (strFlag == "1")
                {
                    ViewState["userrolcode"] = dsMulti.Tables[0].Rows[0]["UserRoleCode"].ToString().Trim();
                }
                else
                {
                    ViewState["userrolcode"] = "";
                }
                ViewState["CndNo"] = lblCndno.Text;
                ViewState["ProcessType"] = lblProcessType.Text;

                // GetRenewalDtls();


                //Added by nikhil for 6 team
                if (ddlProcessType.SelectedValue == "NOC" || ViewState["ProcessType"].ToString() == "NOC")
                {
                    if (ViewState["userrolcode"].ToString() == "COVERNOTES" || ViewState["userrolcode"].ToString() == "POSKey" || ViewState["userrolcode"].ToString() == "RECEIVABLE"
                         || ViewState["userrolcode"].ToString() == "CmmRcvable" || ViewState["userrolcode"].ToString() == "ChqBounce" || ViewState["userrolcode"].ToString() == "ACCOUNT"
                   || ViewState["userrolcode"].ToString() == "LICTEAM" || ViewState["userrolcode"].ToString() == "")
                    {
                        if (ViewState["userrolcode"].ToString() == "COVERNOTES" || ViewState["userrolcode"].ToString() == "POSKey" || ViewState["userrolcode"].ToString() == "RECEIVABLE"
                          || ViewState["userrolcode"].ToString() == "CmmRcvable" || ViewState["userrolcode"].ToString() == "ChqBounce" || ViewState["userrolcode"].ToString() == "ACCOUNT"
                            )
                        {
                            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCTeamCFR1('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','IN');", true);

                        }



                        else if (ViewState["userrolcode"].ToString() == "LICTEAM" && Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Brn")
                        {

                            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRNOCresSM('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);

                            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRNOCresSM('" + lblCndno.Text + "','" + Code.Trim() +"');", true);
                        }
                        else
                        {
                            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','IN');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','IN');", true);

                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() +  "','IN');", true);
                        }

                    }
                }

                //else if (ViewState["IsUpld"].ToString() == "U" && ViewState["RenewalFlag"].ToString() == "Y")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRBrn('" + lblCndno.Text + "','" + "TccDwnld,Spon" + "');", true);
                //}
                else
                {
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                    
                    Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&MemCode=" + lblCndno.Text + "&Code=" + Code.Trim() + "&ModuleID=" + ModuleID.Trim() + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub" + "&memtype" + hdnmemtype.Text);//added by ajay 05 june 2023
                }
            }
        }
        //added by rachana on 13022013 for open inbox with edit and view cfr part end
    }
    protected void GridInbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCndName = (Label)e.Row.FindControl("lblCndName");
                Label lblCandcode = (Label)e.Row.FindControl("lblCndNo");
                Label lblFranSapCode = (Label)e.Row.FindControl("lblFranSapCode");

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
    protected void GridResponded_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //hdnAppNo.Value = "";//Commented by rachana on 24122013
                hdnName.Value = "";
                hdnCandCode.Value = "";
                Label lblCndName = (Label)e.Row.FindControl("lblCndName");
                Label lblCandcode = (Label)e.Row.FindControl("lblCndNo");
                Label lblFranSapCode = (Label)e.Row.FindControl("lblFranSapCode");
                //hdnAppNo.Value = lblFranSapCode.Text;//Commented by rachana on 24122013

                Label lblCndno = (Label)e.Row.FindControl("lblCndNo");
                LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");
                lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCndno.Text + "','Responded','" + usertype + "','user=Brn');return false;");


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
    protected void GridClosed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hdnAppNo.Value = "";//Commented by rachana on 24122013
            hdnName.Value = "";
            hdnCandCode.Value = "";
            Label lblCndName = (Label)e.Row.FindControl("lblCndName");
            Label lblCandcode = (Label)e.Row.FindControl("lblCndNo");
            Label lblFranSapCode = (Label)e.Row.FindControl("lblFranSapCode");
            //hdnAppNo.Value = lblFranSapCode.Text; //Commented by rachana on 24122013
            hdnName.Value = lblCndName.Text;
            hdnCandCode.Value = lblCandcode.Text;
            string user = Session["UserID"].ToString();
            LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");
            lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCandcode.Text + "','Closed','" + user + "');return false;");
        }
    }

    //Added by pranjali on 25022014 for GridCFR start
    protected void GridCFR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hdnAppNo.Value = "";//Commented by rachana on 24122013
            hdnName.Value = "";
            hdnCandCode.Value = "";
            Label lblCndName = (Label)e.Row.FindControl("lblCndName");
            Label lblCandcode = (Label)e.Row.FindControl("lblCndNo");
            Label lblFranSapCode = (Label)e.Row.FindControl("lblFranSapCode");
            //hdnAppNo.Value = lblFranSapCode.Text; //Commented by rachana on 24122013
            hdnName.Value = lblCndName.Text;
            hdnCandCode.Value = lblCandcode.Text;
            string user = Session["UserID"].ToString();
            LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");
            lnkviewcfr.Attributes.Add("onclick", "funcShowPopupCFR('CFRDetail','" + lblCandcode.Text + "','CFRDetail','user=Lic');return false;");
        }
    }
    //Added by pranjali on 25022014 for GridCFR start

    protected void BindInbox()
    {
        try
        {
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            string EmpCode = dsCfruser.Tables[0].Rows[0]["EmpCode"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
               
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                //added by sanoj for search parameter 12062023
                htmulti.Add("@Surname", txtSurname.Text.Trim());
                htmulti.Add("@PAN", TxtPanNo.Text.Trim());
                if (txtDTRegFrom.Text.Trim() != "")
                {
                    htmulti.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htmulti.Add("@CreateFrmDtim ", System.DBNull.Value);
                }
                if (txtDTRegTo.Text.Trim() != "")
                {
                    htmulti.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString("yyyyMMdd"));
                }
                else
                {
                    htmulti.Add("@CreateToDtim ", System.DBNull.Value);
                }
                //enned by sanoj for search parameter 12062023



                //Added bu usha for bm approval 
                //if (ViewState["MemberType"].ToString().Trim() != "SM")
                //added by usha on 16.01.016
                //added by usha on 22.0.2022
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
           (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                //  if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                {
                    htmulti.Add("@Flag", "2");
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                }
                else
                {

                    //if (ddlProcessType.SelectedValue != "")
                    //{
                    //    if (ddlProcessType.SelectedValue == "Retrival")
                    //    {
                    //        htmulti.Add("@ProcessType", "RW");
                    //        htmulti.Add("@CandType", System.DBNull.Value);
                    //    }
                    //    else if (ddlProcessType.SelectedValue == "Reexam")
                    //    {
                    //        htmulti.Add("@ProcessType", "RE");
                    //        htmulti.Add("@CandType", System.DBNull.Value);
                    //    }
                    //    else if (ddlProcessType.SelectedValue == "Fresh")
                    //    {
                    //        htmulti.Add("@ProcessType", "NR");
                    //        htmulti.Add("@CandType", "F");
                    //    }
                    //    else if (ddlProcessType.SelectedValue == "Transfer")
                    //    {
                    //        htmulti.Add("@ProcessType", "NR");
                    //        htmulti.Add("@CandType", "T");
                    //    }
                    //    else if (ddlProcessType.SelectedValue == "Composite")
                    //    {
                    //        htmulti.Add("@ProcessType", "NR");
                    //        htmulti.Add("@CandType", "C");
                    //    }
                    //    else if (ddlProcessType.SelectedValue == "NOC")
                    //    {
                    //        htmulti.Add("@ProcessType", "NC");
                    //        htmulti.Add("@CandType", System.DBNull.Value);
                    //    }
                    //    //Added by usha on 07.05.2020
                    //    else if (ddlProcessType.SelectedValue == "POSP(Fresh)")
                    //    {
                    //        htParam.Add("@ProcessType", "NR");
                    //        htParam.Add("@CandType", "P");
                    //    }
                    //}
                    htmulti.Add("@Flag", "");
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemAdvDetailsForCFR", htmulti);
                }
            }
            else if (UserType == "E")
            {

                htmulti.Clear();
                htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
                //htmulti.Add("@MemCode", "");
                //htmulti.Add("@EmpCode", "");
                //htmulti.Add("@MemName", "");
                htmulti.Add("@Flag", "");
                //htmulti.Add("@MemberCode", EmpCode);
                //htmulti.Add("@MemberType", MemberType);
                //htmulti.Add("@UserId", Session["UserID"].ToString());
                // dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForCFR_bracheduser", htmulti); //commented by pranjali
                //dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForCFR_user", htmulti);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemAdvDetailsForCFRForExtrnl", htmulti);

            }
            //added by pranjali on 28-03-2014 end
            if (dsmulti != null)
            {
                if (dsmulti.Tables.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridInbox.DataSource = dsmulti;
                    GridInbox.DataBind();
                    //Added by usha 21_04_2024
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridInbox.PageCount > Convert.ToInt32(txtprevious1.Text))
                    {
                        btnnext1.Enabled = true;
                    }
                    else
                    {
                        btnnext1.Enabled = false;
                    }
                    InboxPage.Visible = true;
                    trInboxMsg.Visible = false;
                }
                else
                {
                    GridInbox.DataSource = null;
                    GridInbox.DataBind();
                    trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridInbox.DataSource = null;
                GridInbox.DataBind();
                trRecord.Visible = true;
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
    //Added by rachana on 24122013 for showing records in page selected in ddlShwRecrds start
    protected void ddlShwRecrds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds.SelectedValue != null || ddlShwRecrds.SelectedValue != "")
        {
            BindDataGrid();
        }
    }
    //Added by rachana on 24122013 for showing records in page selected in ddlShwRecrds end
    //added by rachana on 13022013 for open inbox with edit and view cfr part start  
    protected void GridResponded_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Code = Request.QueryString["Code"].ToString();//added by pranjali on 15042014
        if (e.CommandName == "ViewCFR")
        {

            if (ViewState["userrollcode"].ToString().Trim() != "SMUSER" && ViewState["userrollcode"].ToString() != "LICTEAM")
            // if (ViewState["MemberType"].ToString().Trim() != "SM" && ViewState["userrollcode"].ToString() != "LICTEAM")
            {
                if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblCndno = (Label)row.FindControl("lblCndNo");
                    ViewState["CndNo"] = lblCndno.Text;
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','Res');", true);

                }
            }
            else if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Lic")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                Label lblProcessType = (Label)row.FindControl("lblProcessType");
                //ViewState["CndNo"] = lblCndno.Text;
                // ViewState["ProcessType"] = lblProcessType.Text;
                DataSet dsMulti = new DataSet();
                Hashtable htParam2 = new Hashtable();
                htParam2.Add("@MemCode", lblCndno.Text);
                dsMulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UserMemRoleCode", htParam2);

                ViewState["userrolcode"] = dsMulti.Tables[0].Rows[0]["UserRoleCode"].ToString().Trim();
                ViewState["CndNo"] = lblCndno.Text;
                ViewState["ProcessType"] = lblProcessType.Text;
                //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond&CndNo=" + lblCndno.Text + "&Code=" + Code.Trim() + "&Type=QcRes&user=Lic&mdlpopup=','LicensingRespond','width=900,height=670,resizable=0,left=190,scrollbars=1');";
                if (ddlProcessType.SelectedValue == "NOC" || ViewState["ProcessType"].ToString() == "NOC")
                {
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRNOCres('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
                }
                else
                {
                    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRres('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);
                    Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond&MemCode=" + lblCndno.Text + " &ModuleID=" + ModuleID + " &Code=" + Code + "&Type=QcRes&user=Lic&mdlpopup=MdlPopRaiseSub");
                }
            }
            else
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                LinkButton lnkviewcfr = (LinkButton)row.FindControl("lblcfr");
                Label lblProcessType = (Label)row.FindControl("lblProcessType");

                DataSet dsMulti = new DataSet();
                Hashtable htParam2 = new Hashtable();
                htParam2.Add("@MemCode", lblCndno.Text);
                dsMulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_UserMemRoleCode", htParam2);
                ViewState["userrolcode"] = dsMulti.Tables[0].Rows[0]["UserRoleCode"].ToString().Trim();
                string strFlag = dsMulti.Tables[0].Rows[0]["Flag"].ToString().Trim();
                if (strFlag == "1")
                {
                    ViewState["userrolcode"] = dsMulti.Tables[0].Rows[0]["UserRoleCode"].ToString().Trim();
                }
                else
                {
                    ViewState["userrolcode"] = "";
                }
                ViewState["CndNo"] = lblCndno.Text;
                ViewState["ProcessType"] = lblProcessType.Text;

                if (ddlProcessType.SelectedValue == "NOC" || ViewState["ProcessType"].ToString() == "NOC")
                {
                    if (ViewState["userrolcode"].ToString() == "COVERNOTES" || ViewState["userrolcode"].ToString() == "POSKey" || ViewState["userrolcode"].ToString() == "RECEIVABLE"
                   || ViewState["userrolcode"].ToString() == "" || ViewState["userrolcode"].ToString() == "LICTEAM" || ViewState["userrolcode"].ToString() == "CmmRcvable" || ViewState["userrolcode"].ToString() == "ChqBounce" || ViewState["userrolcode"].ToString() == "ACCOUNT")
                    {
                        if (ViewState["userrolcode"].ToString() == "COVERNOTES" || ViewState["userrolcode"].ToString() == "POSKey" || ViewState["userrolcode"].ToString() == "RECEIVABLE"
                        || ViewState["userrolcode"].ToString() == "CmmRcvable" || ViewState["userrolcode"].ToString() == "ChqBounce" || ViewState["userrolcode"].ToString() == "ACCOUNT")
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCTeamCFR1('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','Res');", true);
                        }
                        else if (ViewState["userrolcode"].ToString() == "LICTEAM")
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRNOCresFSM('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "');", true);

                        }


                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenNOCAppCFR('" + lblCndno.Text + "','" + Code.Trim() + "','" + ModuleID.Trim() + "','Res');", true);
                        }

                    }
                }
                else
                {
                    lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCndno.Text + "','" + ModuleID.Trim() + "','Responded','" + usertype + "','user=Brn');return false;");
                }
            }
        }

    }
    //added by rachana on 13022013 for open inbox with edit and view cfr part end

    //added by shreela on 14/07/2014 start
    protected void btnReFresh_Click(object sender, EventArgs e)
    {
        if (ViewState["Value"].ToString().Trim() == "50hrs")
        {
            BindDataGrid();
        }
        else if (GridResponded.Visible == true)
        {
            GetDataTableForRespond();
        }
        else if (GridInbox.Visible == true)
        {
            GetDataTableForInbox();
        }
    }

    //private void ddlProcessType1()
    //{
    //    try
    //    {

    //        //added by nikhil on 9.6.15
    //        Hashtable htParam = new Hashtable();
    //        DataSet dsComp = new DataSet();

    //        htParam.Add("@Flag", "1");
    //        dsComp = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetNewProcessType", htParam);


    //        if (dsComp.Tables[0].Rows.Count > 0)
    //        {
    //            ddlProcessType.DataSource = dsComp;
    //            ddlProcessType.DataTextField = "Name";
    //            ddlProcessType.DataValueField = "Name";
    //            ddlProcessType.DataBind();
    //            ddlProcessType.Items.Insert(0, "--Select--");
    //        }

    //        //ended by nikhil on 9.6.15
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
    //added by sanoj 24052022
    //public DataSet DocGridBind()
    //{
    //    DataSet dsResult = new DataSet();
    //    htParam.Clear();
    //    htParam.Add("@EmpCode", txtFranCode.Text.Trim());
    //    htParam.Add("@CndName", txtName.Text.Trim());
    //    htParam.Add("@Surname", txtSurname.Text.Trim()); //added by pranjali on 26022014 for surname 
    //    htParam.Add("@PAN", TxtPanNo.Text.Trim());//added by shreela on 10042014
    //    if (txtReqDate.Text.Trim() != "")
    //    {
    //        htParam.Add("@ReqDate", DateTime.Parse(txtReqDate.Text.Trim()).ToString("dd/MM/yyyy"));
    //    }
    //    else
    //    {
    //        htParam.Add("@ReqDate", System.DBNull.Value);
    //    }
    //    if (txtAppNo.Text.ToString().Trim() != "")
    //    {
    //        htParam.Add("@Memcode", txtAppNo.Text.ToString().Trim());
    //    }
    //    else
    //    {
    //        htParam.Add("@Memcode", System.DBNull.Value);
    //    }
    //    if (ddlreqstatus.SelectedItem.Text.Trim() != "--Select--")
    //    {
    //        htParam.Add("@ReqStatus", ddlreqstatus.SelectedItem.Text.ToString().Trim());
    //    }
    //    else if (Request.QueryString["status"].ToString() == "QCNoc")
    //    {
    //        htParam.Add("@ReqStatus", System.DBNull.Value);
    //    }
    //    else
    //    {
    //        htParam.Add("@ReqStatus", System.DBNull.Value);
    //    }

    //    if (txtRecruiterName.Text.ToString().Trim() != "")
    //    {
    //        htParam.Add("@RecruiterName", txtRecruiterName.Text.ToString().Trim());
    //    }
    //    else
    //    {
    //        htParam.Add("@RecruiterName", System.DBNull.Value);
    //    }

    //    if (txtDTRegFrom.Text.Trim() != "")
    //    {
    //        htParam.Add("@CreateFrmDtim", txtDTRegFrom.Text.Trim());
    //    }
    //    else
    //    {
    //        htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
    //    }
    //    if (txtDTRegTo.Text.Trim() != "")
    //    {
    //        htParam.Add("@CreateToDtim", txtDTRegTo.Text.Trim());
    //    }
    //    else
    //    {
    //        htParam.Add("@CreateToDtim ", System.DBNull.Value);
    //    }

    //    if (txtBranchName.Text.ToString().Trim() != "")
    //    {
    //        htParam.Add("@BranchName", txtBranchName.Text.ToString().Trim());
    //    }
    //    else
    //    {
    //        htParam.Add("@BranchName", System.DBNull.Value);
    //    }
    //    if (ddlProcessType.SelectedValue != "")
    //    {
    //        if (ddlProcessType.SelectedValue == "Retrival")
    //        {
    //            htParam.Add("@ProcessType", "RW");
    //            htParam.Add("@CandType", System.DBNull.Value);
    //        }
    //        else if (ddlProcessType.SelectedValue == "Reexam")
    //        {
    //            htParam.Add("@ProcessType", "RE");
    //            htParam.Add("@CandType", System.DBNull.Value);
    //        }
    //        else if (ddlProcessType.SelectedValue == "Fresh")
    //        {
    //            htParam.Add("@ProcessType", "NR");
    //            htParam.Add("@CandType", "F");
    //        }
    //        else if (ddlProcessType.SelectedValue == "Transfer")
    //        {
    //            htParam.Add("@ProcessType", "NR");
    //            htParam.Add("@CandType", "T");
    //        }
    //        else if (ddlProcessType.SelectedValue == "Composite")
    //        {
    //            htParam.Add("@ProcessType", "NR");
    //            htParam.Add("@CandType", "C");
    //        }
    //        else if (ddlProcessType.SelectedValue == "NOC")
    //        {
    //            htParam.Add("@ProcessType", "NC");
    //            htParam.Add("@CandType", System.DBNull.Value);
    //        }
    //        //added by usha for Noc BM search page on 11.07.5015 
    //        else if (ddlProcessType.SelectedValue == "NOCApp")
    //        {
    //            htParam.Add("@ProcessType", "NC");
    //            htParam.Add("@CandType", System.DBNull.Value);
    //        }
    //        else if (ddlProcessType.SelectedValue == "POSP(Fresh)")
    //        {
    //            htParam.Add("@ProcessType", "NR");
    //            htParam.Add("@CandType", "P");
    //        }

    //    }
    //            htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
    //            htParam.Add("@MemberType", ViewState["MemberType"].ToString());
    //            dsResult = dataAccessRecruit.GetDataSetForPrcCLP("PRC_GET_MEMBER_DOCUPLD_SRCH_ViewDocs", htParam);
    //    //dsResult = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetFPSponsorshipAndQCCandidates", htParam); //GetDataSetForPrcRecruit
    //    if (dsResult.Tables[0].Rows.Count > 0)
    //    {
    //        gvDocs.DataSource = dsResult.Tables[0];
    //        gvDocs.DataBind();
    //        trtitle.Visible = true;
    //    }
    //    ShowPageInformation1();
    //    return dsResult;

    //}
    //#region dgView Show Page Information for GridView
    //public void ShowPageInformation1()
    //{
    //    int intPageIndex = gvDocs.PageIndex + 1;
    //    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + gvDocs.PageCount;
    //}
    //#endregion

    //protected void gvDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        //For Pagination of Search Grid
    //        DataSet ds = DocGridBind();
    //        DataTable dt = ds.Tables[0];
    //        DataView dv = new DataView(dt);
    //        GridView dgSource = (GridView)sender;
    //        gvDocs.PageIndex = e.NewPageIndex;
    //        dv.Sort = dgSource.Attributes["SortExpression"];
    //        if (dgSource.Attributes["SortASC"] == "No")
    //        {
    //            dv.Sort += " DESC";
    //        }
    //        gvDocs.DataSource = dv;
    //        gvDocs.DataBind();
    //        ShowPageInformation1();
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

    //protected void gvDocs_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "viewClick")
    //    {
    //        DataSet dscount = new DataSet();

    //        string cndno = e.CommandArgument.ToString().Trim();
    //        string strresult = string.Empty;
    //        string strnm = string.Empty;
    //        GridViewRow row1 = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
    //        Label lblname = (Label)row1.FindControl("lblLegalName");
    //        strnm = lblname.Text.ToString().Trim();
    //        strresult = "Documents Not Available of " + strnm;
    //        Hashtable htParam = new Hashtable();
    //        htParam.Add("@MemCode", cndno);//30027336 @CndNo
    //        //dscount = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetMemDocType", htParam);
    //        dscount = dataAccessRecruit.GetDataSetForPrcCLP("prc_GetMemDocType", htParam);
    //        if (dscount != null)
    //        {
    //            if (dscount.Tables.Count > 0)
    //            {
    //                if (dscount.Tables[0].Rows.Count > 0)
    //                {
    //                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDoc('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenDocs('" + e.CommandArgument.ToString().Trim() + "','N','mdlpopup');", true);

    //                }
    //                else
    //                {
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);

    //                    return;
    //                }
    //            }
    //            else
    //            {
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('" + strresult + "');", true);
    //            return;
    //        }
    //    }

    //    //if (e.CommandName == "viewClick")
    //    //{
    //    //    DataSet dsValidSM = new DataSet();
    //    //    Hashtable htParam = new Hashtable();
    //    //    string MemCode = e.CommandArgument.ToString().Trim();
    //    //    Code="Spon";
    //    //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
    //    //    Label lblEntityType = (Label)row.FindControl("lblentityType");
    //    //    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();//    ViewDoc
    //    //    Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&EntityType=" + lblEntityType.Text.ToString().Trim() + "&Type=ViewDoc&mdlpopup="); //added by pranjali on 15042014
    //    //}
    //    //if (e.CommandName == "viewClick")
    //    //{
    //    //    DataSet dsValidSM = new DataSet();
    //    //    Hashtable htParam = new Hashtable();
    //    //    string MemCode = e.CommandArgument.ToString().Trim();
    //    //    Code="Spon";
    //    //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
    //    //    Label lblEntityType = (Label)row.FindControl("lblentityType");
    //    //    ModuleID = Request.QueryString["ModuleID"].ToString().Trim();//    ViewDoc
    //    //    Response.Redirect("FPAdvTrnHrsReqSubmit.aspx?TrnRequest=Submit&MemCode=" + e.CommandArgument.ToString().Trim() + "&ModuleID=" + ModuleID + "&Code=" + Code.Trim() + "&EntityType=" + lblEntityType.Text.ToString().Trim() + "&Type=ViewDoc&mdlpopup="); //added by pranjali on 15042014
    //    //}
    //}
    ////added by sanoj 24052022
    ///
    protected void btnNextdiv1_Click(object sender, EventArgs e)
    {

    }

    protected void btnpreviousMenu_Click(object sender, EventArgs e)
    {
        hdnMenuName.Value = Request.Form[hdnMenuName.UniqueID];
        if (hdnMenuName.Value == "1" || hdnMenuName.Value == "0")
        {
            strFlagmenu = "1";
            int pageIndex = GridInbox.PageIndex;
            GridInbox.PageIndex = pageIndex - 1;
            if (strFlagmenu == "1")
            {
                BindInbox();
            }
            else
            {
                BindInbox1();
            }

            txtprevious1.Text = Convert.ToString(Convert.ToInt32(txtprevious1.Text) - 1);
            if (txtprevious1.Text == "1")
            {
                btnprevious1.Enabled = false;
            }
            else
            {
                btnprevious1.Enabled = true;
            }
            btnnext1.Enabled = true;
        }
        if (hdnMenuName.Value == "2")
        {
            strFlagmenu = "2";
            int pageIndex = GridResponded.PageIndex;
            GridResponded.PageIndex = pageIndex - 1;
            if (strFlagmenu == "2")
            {
                BindResponded();
            }
            else
            {
                BindResponded1();
            }
            txtResponded.Text = Convert.ToString(Convert.ToInt32(txtResponded.Text) - 1);
            if (txtResponded.Text == "1")
            {
                btnprevious2.Enabled = false;
            }
            else
            {
                btnprevious2.Enabled = true;
            }
            btnnext2.Enabled = true;
        }
    }
    protected void BindInbox1()
    {
        try
        {
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            string EmpCode = dsCfruser.Tables[0].Rows[0]["EmpCode"].ToString();
            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@CndNo", "");
                htmulti.Add("@AppNo", "");
                htmulti.Add("@CndName", "");
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
                   (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                {
                    htmulti.Add("@Flag", "2");
                    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                }
                else
                {

                    htmulti.Add("@Flag", "");
                    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFR", htmulti);
                }
            }
            else if (UserType == "E")
            {

                htmulti.Clear();
                //changes by ajay 20042023 start 
                htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
                //changes by ajay 20042023 start 
                //htmulti.Add("@CndNo", "");
                //htmulti.Add("@AppNo", "");
                //htmulti.Add("@CndName", "");
                htmulti.Add("@Flag", "");
                dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFRForExtrnl", htmulti);

            }
            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridInbox.DataSource = dsmulti;
                    GridInbox.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridInbox.PageCount > Convert.ToInt32(txtprevious1.Text))
                    {
                        btnnext1.Enabled = true;
                    }
                    else
                    {
                        btnnext1.Enabled = false;
                    }
                    InboxPage.Visible = true;
                    trInboxMsg.Visible = false;

                }
                else
                {
                    GridInbox.DataSource = null;
                    GridInbox.DataBind();
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                    InboxPage.Visible = false;
                    trInboxMsg.Visible = true;
                }
            }
            else
            {
                GridInbox.DataSource = null;
                GridInbox.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
                InboxPage.Visible = false;
                trInboxMsg.Visible = true;
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
    protected void BindResponded1()
    {
        try
        {

            //dsmulti.Clear();
            //htmulti.Clear();
            //htmulti.Add("@CndNo", "");
            //htmulti.Add("@AppNo", "");
            //htmulti.Add("@CndName", "");
            //htmulti.Add("@UserId", Session["UserID"].ToString());
            //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFR_bracheduser", htmulti);
            //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFR_user", htmulti);

            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();

            if (UserType == "I")
            {
                htmulti.Clear();
                htmulti.Add("@MemberCode", MemberCode);
                htmulti.Add("@MemberType", MemberType);
               htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
               htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
               htmulti.Add("@MemName", txtName.Text);

                
                //htmulti.Add("@CndNo", "");
                //htmulti.Add("@AppNo", "");
                //htmulti.Add("@CndName", "");
                //Added by usha for BM CFR 
                // if (ViewState["MemberType"].ToString().Trim() != "SM")
                //added by usha on 16.01.016

                //if (ViewState["userrollcode"].ToString().Trim() != "SMUSER")
                if ((ViewState["userrollcode"].ToString().Trim() != "SMUSER") ||
                 (ViewState["userrollcode"].ToString().Trim() == "SMUSER" && Request.QueryString["userrollcode"].ToString() == "RptMgr"))
                {
                    // if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["User"].ToString() == "Brn") && MemberType.ToString().Trim() != "SM")
                    if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                    {

                        //if (ddlProcessType.SelectedValue == "NOC")
                        //{
                        //    htmulti.Add("@processtype", "NC");
                        htmulti.Add("@Flag", "1");
                        dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                        //}
                        //Prc_GetAdvDetailsForCFR
                        //else
                        //{
                        //    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForNOCCFRForExtrnl", htmulti);
                    }
                }
                else
                {
                    //    htmulti.Add("@MemberCode", MemberCode);
                    //    htmulti.Add("@MemberType", MemberType);
                    dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFR", htmulti);
                }
            }
            else if (UserType == "E")
            {
                htmulti.Clear();
                //htmulti.Add("@CndNo", "");
                //htmulti.Add("@AppNo", "");
                //htmulti.Add("@CndName", "");
                htmulti.Add("@Flag", "");
                htmulti.Add("@MemCode", TxtMemCode.Text);/*txtAppNo.Text);*///ajay yadav 18042023
                htmulti.Add("@EmpCode", txtFranCode.Text.Trim());
                htmulti.Add("@MemName", txtName.Text);
                //htmulti.Add("@MemberCode", MemberCode);
                //htmulti.Add("@MemberType", MemberType);
                dsmulti = dataAccessRecruit.GetDataSetForPrcCLP("Prc_GetMemRespondedCFRForExtrnl", htmulti);
            }
            //added by pranjali on 02-04-2014 end

            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    GridResponded.DataSource = dsmulti;
                    GridResponded.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridResponded.PageCount > Convert.ToInt32(txtResponded.Text))
                    {
                        btnnext2.Enabled = true;
                    }
                    else
                    {
                        btnnext2.Enabled = false;
                    }
                    ResPage.Visible = true;
                    divRes.Visible = false;
                }
                else
                {
                    GridResponded.DataSource = null;
                    GridResponded.DataBind();
                    // trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                    ResPage.Visible = false;
                    divRes.Visible = true;
                }
            }
            else
            {
                GridResponded.DataSource = null;
                GridResponded.DataBind();
                // trRecord.Visible = true;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
                ResPage.Visible = false;
                divRes.Visible = true;
            }

            dsmulti = null;
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
    protected void btnnextMenu_Click(object sender, EventArgs e)
    {

        hdnMenuName.Value = Request.Form[hdnMenuName.UniqueID];
        if (hdnMenuName.Value == "1" || hdnMenuName.Value == "0")
        {
            int pageIndex = GridInbox.PageIndex;
            GridInbox.PageIndex = pageIndex + 1;
            strFlagmenu = "1";
            if (strFlagmenu == "1")
            {
                BindInbox();
            }
            else
            {
                BindInbox1();
            }
            txtprevious1.Text = Convert.ToString(Convert.ToInt32(txtprevious1.Text) + 1);
            btnprevious1.Enabled = true;
            int page = GridInbox.PageCount;
            if (txtprevious1.Text == Convert.ToString(GridInbox.PageCount))
            {
                btnnext1.Enabled = false;
            }
        }
        if (hdnMenuName.Value == "2")
        {
            strFlagmenu = "2";
            int pageIndex = GridResponded.PageIndex;
            GridResponded.PageIndex = pageIndex + 1;
            if (strFlagmenu == "2")
            {
                BindResponded();
            }
            else
            {
                BindResponded1();
            }

            txtResponded.Text = Convert.ToString(Convert.ToInt32(txtResponded.Text) + 1);
            btnprevious2.Enabled = true;
            int page = GridResponded.PageCount;
            if (txtResponded.Text == Convert.ToString(GridResponded.PageCount))
            {
                btnnext2.Enabled = false;
            }
        }
    }
    //Added by usha on 20_04_2023
    protected void btnnext_Click(object sender, EventArgs e)
    {
        int pageIndex = dgView.PageIndex;
        dgView.PageIndex = pageIndex + 1;
        BindDataGrid();
        txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
        btnprevious.Enabled = true;
        int page = dgView.PageCount;
        if (txtPage.Text == Convert.ToString(dgView.PageCount))
        {
            btnnext.Enabled = false;
        }

    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        int pageIndex = dgView.PageIndex;
        dgView.PageIndex = pageIndex - 1;
        BindDataGrid();
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
}

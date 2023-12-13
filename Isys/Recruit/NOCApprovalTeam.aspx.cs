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
using System.Text;
public partial class Application_ISys_Recruit_NOCApprovalTeam : BaseClass
{
    #region Global declaration
    string strFlagmenu = string.Empty;
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    StringBuilder Approve = new StringBuilder();
    StringBuilder Reject = new StringBuilder();
    StringBuilder CFRRaise = new StringBuilder();
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
    //StringBuilder Approve = new StringBuilder();
    //StringBuilder Reject = new StringBuilder();
    string ApprovedCnd = string.Empty;
    string RejectdCnd = string.Empty;
    string CFRRaiseCnd = string.Empty;
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
            if (this.IsPostBack)
            {
                TabName.Value = Request.Form[TabName.UniqueID];
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "AdvTrn50HrsSearch.aspx", Session["UserLangNum"].ToString());
            if (!IsPostBack)
            {
                ddlProcessType1();
                InitializeControl();
                GetAgentandUserDtls();
                ViewState["Value"] = Request.QueryString["Pg"].ToString().Trim();//added by shreela on 15/07/2014 

                #region NEW REQUEST
                if (Request.QueryString["Pg"].ToString() == "Approval" && Request.QueryString["Status"].ToString() == "NOCApp")
                {
                    Code = Request.QueryString["Code"].ToString().Trim();//added by pranjali on 15042014
                    trtitle.Visible = false;
                    divBrnuser.Visible = false;
                    trSearchDetails.Visible = true;
                    trDgDetails.Visible = false;
                    trbtnexport.Visible = false;
                    btnExport.Visible = false;
                    lblRequestDate.Visible = false;
                    txtReqDate.Visible = false;
                    // btnCalendar.Visible = false;
                    btnSubmit.Visible = false;
                    btnCancel.Visible = false;
                    //trURN.Visible = true;
                    //trCodedlicdetails.Visible = true;
                    lblTitle.Text = "NOC Approval Request Search";
                    //trregstrtndt.Visible = true;
                    trbtnexport.Visible = false;
                    trtitle.Visible = false;
                    btnReject.Visible = false;
                   //div5.Visible = false;

                    //  trmessage.Attributes.Add("style", "display:none"); ;


                }
                #endregion
                #region VIEW CFR FOR CoverNotes USER
                else if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "CVR" || Request.QueryString["Status"].ToString() == "RCV" ||
                Request.QueryString["Status"].ToString() == "CHQBUNCE" || Request.QueryString["Status"].ToString() == "CMMRCV" || Request.QueryString["Status"].ToString() == "ACC" ||
                Request.QueryString["Status"].ToString() == "POSKEY")
                {
                    Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                    divBrnuser.Visible = true;
                    lblTitle.Text = "View CFR Details";
                    trHideRows.Visible = false;
                    //lblsecondrowhide.Visible = false;
                    hiderecname.Visible = false;
                    hidebrname.Visible = false;
                    lblrecnamehide.Visible = false;
                    lblbrnamehide.Visible = false;
                    trDgViewDtl.Visible = false;
                    trSearchDetails.Visible = false;
                    trSearchDetails.Visible = true;
                    trDgViewDtl.Visible = false; //added by usha
                    BindInbox();
                    BindResponded();
                    BindClosed();
                    BindCFR();
                    trmessage.Visible = false;
                    //BindInbox();
                }
                #endregion
                #region VIEW CFR FOR CoverNotes Branched USER
                else if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR")
                {
                    Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                    divBrnuser.Visible = true;
                    lblTitle.Text = "View CFR Details";
                    trHideRows.Visible = false;
                    //lblsecondrowhide.Visible = false;
                    hiderecname.Visible = false;
                    hidebrname.Visible = false;
                    lblrecnamehide.Visible = false;
                    lblbrnamehide.Visible = false;
                    lblrecnamehide.Visible = false;
                    trDgViewDtl.Visible = false;
                    trSearchDetails.Visible = false;
                    trSearchDetails.Visible = true;
                    trButton.Visible = false; //added by usha for bootstrap
                    trDgViewDtl.Visible = false; //added by usha for bootstrap
                    trDgDetails.Visible = false;
                    trtitle.Visible = false;
                    //trnote.Visible = false;
                    BindInbox();
                    BindResponded();
                    BindCFR();
                    BindClosed();
                }
                #endregion

                #region VIEW CFR FOR BRANCHED USER
                else
                {
                    Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                    divBrnuser.Visible = true;
                    lblTitle.Text = "View CFR Details";
                    trHideRows.Visible = false;
                    //lblsecondrowhide.Visible = false;
                    hiderecname.Visible = false;
                    hidebrname.Visible = false;
                    lblrecnamehide.Visible = false;
                    lblbrnamehide.Visible = false;
                    trDgViewDtl.Visible = false;
                    trSearchDetails.Visible = false;
                    trSearchDetails.Visible = true;
                    //trnote.Visible = false;
                    BindInbox();
                    BindResponded();
                    BindCFR();
                    BindClosed();
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
    #region InitializeControl()
    private void InitializeControl()
    {
        try
        {
            lblTitle.Text = olng.GetItemDesc("lblTitle");
            //lblAgentCode.Text = ObjDec.GetDecData(olng.GetItemDesc("lblAgentCode"));
            lblCandidateCode.Text = "Candidate ID";
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            lblRecruiterName.Text = olng.GetItemDesc("lblRecruiterName");//Added by rachana on 24122013 for Search procedure
            lblRequestDate.Text = olng.GetItemDesc("lblRequestDate");
            lblGivenName.Text = olng.GetItemDesc("lblGivenName");
            lblBranchName.Text = olng.GetItemDesc("lblBranchName");//Added by rachana on 24122013 for Search procedure
            lblShwRecords.Text = olng.GetItemDesc("lblShwRecords");
            // lblReqStatus.Text = olng.GetItemDesc("lblReqStatus");
            lblSurName.Text = olng.GetItemDesc("lblSurName");//Added by pranjali on 26022014
            //lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text")); //added by pranjali on 20-03-2014
            //lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));//added by pranjali on 20-03-2014
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));//added by Shreela on 10042014

            if (Request.QueryString["Pg"].ToString() == "Approval" && Request.QueryString["Status"].ToString() == "NOCApp")
            {
                lblDTRegFrom.Text = "Request Date From";
                lblDTRegTO.Text = "Request Date To";
            }
            else
            {
                lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text")); //added by pranjali on 20-03-2014
                lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));//added by pranjali on 20-03-2014
            }

            if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "QC")
            {
                lblDTRegFrom.Text = "Request Date From (dd/mm/yyyy)";
                lblDTRegTO.Text = "Request Date To (dd/mm/yyyy)";
            }
            else
            {
              //  lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text")); //added by pranjali on 20-03-2014
               // lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));//added by pranjali on 20-03-2014
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
    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            //BindGridControl(dgSource);
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

    #region DATAGRID 'dgDetails' SORT EVENT
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            //BindGridControl(dgSource);
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

    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        DataSet dsResult = new DataSet();
        try
        {

            htParam.Clear();
            htParam.Clear();
            htParam.Add("@CndNo", txtCndNo.Text.Trim());
            htParam.Add("@BranchCode", string.Empty);
            htParam.Add("@CndName", txtName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim()); //added by pranjali on 26022014 for surname 
            htParam.Add("@PAN", txtPan.Text.Trim());
            //Added by usha  on 28.09.215
            htParam.Add("@AgentBrokerCode", txtAgntBroker.Text.ToString().Trim());
            htParam.Add("@AgentSapCode", txtSapCode.Text.ToString().Trim());
            htParam.Add("@URN", txtURN.Text.ToString().Trim());
            if (txtReqDate.Text.Trim() != "")
            {
                htParam.Add("@ReqDate", DateTime.Parse(txtReqDate.Text.Trim()).ToString("dd/MM/yyyy"));
            }
            else
            {
                htParam.Add("@ReqDate", System.DBNull.Value);
            }
            //changed by rachana on 24122013 for search procedure start  ddlreqstatus
            if (txtAppNo.Text.ToString().Trim() != "")
            {
                htParam.Add("@Appno", txtAppNo.Text.ToString().Trim());
            }
            else
            {
                htParam.Add("@Appno", System.DBNull.Value);
            }
            //if (ddlreqstatus.SelectedItem.Text.Trim() != "--Select--")
            //{
            //    htParam.Add("@ReqStatus", ddlreqstatus.SelectedItem.Text.ToString().Trim());
            //}
            //else
            //{
            //    htParam.Add("@ReqStatus", System.DBNull.Value);
            //}

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
                htParam.Add("@CreateFrmDtim", txtDTRegFrom.Text.Trim());
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", txtDTRegTo.Text.Trim());
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
                else if (ddlProcessType.SelectedValue == "NOCApp")
                {
                    htParam.Add("@ProcessType", "NC");
                    htParam.Add("@CandType", System.DBNull.Value);
                }
            }
            else
            {
                htParam.Add("@ProcessType", System.DBNull.Value);
                htParam.Add("@CandType", System.DBNull.Value);
            }

            GetAgentandUserDtls_lic();
            if (Request.QueryString["type"].Trim() == "covernote")
            {
                htParam.Add("@Flag", "1");
            }
            else if (Request.QueryString["type"].Trim() == "Receivable")
            {
                htParam.Add("@Flag", "2");
            }

            else if (Request.QueryString["type"].Trim() == "ChqBounce")
            {
                htParam.Add("@Flag", "3");
            }
            else if (Request.QueryString["type"].Trim() == "CmmRcvable")
            {
                htParam.Add("@Flag", "4");
            }
            else if (Request.QueryString["type"].Trim() == "Account")
            {
                htParam.Add("@Flag", "5");
            }
            else if (Request.QueryString["type"].Trim() == "POSKey")
            {
                htParam.Add("@Flag", "6");
            }

            if (Request.QueryString["Status"].ToString().Trim() == "NOCApp")
            {
                //lblRequestDate.Text = "NOC Request";
                htParam.Add("@Type", Request.QueryString["type"].ToString().Trim());
                htParam.Add("@querystatus", Request.QueryString["Status"].ToString().Trim());
                dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NOCAppTeamCandidate", htParam);
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

    #region BindDataGrid()
    void BindDataGrid()
    {
        try
        {
            #region HO user
            if (ddlShwRecrds.SelectedValue == "Select")// .ToString().Trim()

            {

            }
            else
            {
                dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue.Trim());
            }
            //Binds the data to grid of candidates came after approval with cndstatus='40' for 50 Hrs Training Request 
            DataTable dtResult_HrsTrn = new DataTable();
            dtResult_HrsTrn = GetDataTable();

            if (dtResult_HrsTrn != null)
            {
                if (dtResult_HrsTrn.Rows.Count > 0)
                {
                    //divDgViewDtl.Visible = true;
                    txtCFRcolr.Visible = true;
                    lblCFR.Visible = true;

                    trDgViewDtl.Visible = true;//pranjali
                    trtitle.Visible = true;//pranjali
                    trDgDetails.Visible = true;
                    lblMessage.Visible = false;
                    //dgView.Columns[9].Visible = false;
                    dgDetails.DataSource = dtResult_HrsTrn;
                    dgDetails.DataBind();
                    if (Convert.ToString(dgDetails.PageCount) == "1")
                    {
                        btnnext.Enabled = false;
                    }
                    //ShowPageInformation();
                   // trnote.Visible = true;
                }
                else
                {
                    //divDgViewDtl.Visible = false;
                    trDgViewDtl.Visible = false;//pranjali
                    trtitle.Visible = false;//pranjali
                    // dgView.Columns[9].Visible = false;
                    btnReject.Visible = false;
                    btnSubmit.Visible = false;
                    btnCancel.Visible = false;
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                    div5.Attributes.Add("style", "display:none");


                }
            }
            else
            {
                //divDgViewDtl.Visible = false;
                //dgView.Columns[9].Visible = false;
                trDgViewDtl.Visible = false;//pranjali
                trtitle.Visible = false;//pranjali
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
                div5.Attributes.Add("style", "display:none");

            }

            #endregion
            BindGridControl(dgDetails);
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
    //protected void btnok_Click(object sender, EventArgs e)
    //{
    //    //  BindDataGrid();
    //}
    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in dgDetails.Rows)
            {
                RadioButtonList rdbCFR1 = (RadioButtonList)row.FindControl("rdbCFR");
                rdbCFR1.Items[0].Selected = false;
                rdbCFR1.Items[1].Selected = false;
                RadioButtonList rdbCFR = (RadioButtonList)row.FindControl("rdbCFR");
                string strRdb = rdbCFR.SelectedValue.ToString();
                // rdbCFR.Checked = false;


                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                string sremarks = remarks.Text.Trim();
                //rdbCFR1.sele=false;
                CheckBox ChkRej = (CheckBox)row.FindControl("chkRejApp");
                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                Label lblappno = (Label)row.FindControl("lblappno");
                DataSet dsRej = new DataSet();
                DataSet dsApp = new DataSet();
                Hashtable htParam1 = new Hashtable();
                htParam1.Add("@CndNo", lbapprove.Text.Trim());
                dsApp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRaise", htParam1);
                string strFlag3 = dsApp.Tables[0].Rows[0]["Flag"].ToString();
                //if (strFlag3 == "1")
                //{
                if (ChkRej.Checked == true && strRdb == "")
                {
                    ChkRej.Enabled = false;
                    rdbCFR.Enabled = false;

                    // htParam1.Add("@CndNo", lbapprove.Text.Trim());
                    htParam1.Add("@Reject", "1");
                    htParam1.Add("@AppNo", lblappno.Text.Trim());
                    htParam1.Add("@CreateBy", Session["UserID"].ToString());
                    htParam1.Add("@Remarks", sremarks);
                    dsRej = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCTeamApp", htParam1);
                    dsRej.Clear();
                    Reject.Append(lbapprove.Text.Trim());
                    Reject.Append(",");
                    RejectdCnd = Reject.ToString();
                    if (RejectdCnd != "")
                    {
                        RejectdCnd = RejectdCnd.Substring(0, RejectdCnd.Length - 1);
                        //added by shreela on 09/06/2014 start
                        String[] strArr = RejectdCnd.Split(',');
                        int count = 0;
                        for (int i = 0; i < strArr.Length; i++)
                        {
                            count++;
                        }
                        RejectdCnd = Convert.ToString(count);
                        //added by shreela on 09/06/2014 end
                    }
                    else
                    {
                        //RejectdCnd = "-";
                        RejectdCnd = "0";
                    }
                    lblmsg.Text = "NOC Rejected successfully";
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Visible = false;
                    //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                    //alert.InnerHtml = "";
                    //MailResponse(PrID);
                    lbl3.Visible = true;
                    lbl4.Visible = false; ;
                    lbl2.Visible = true;
                    lbl3.Text = "NOC Rejected successfully.";

                    lbl2.Text = "Rejected NOC :" + " " + RejectdCnd.ToString();//added by shreela on 09/06/2014 
                                                                               //mdlpopup.Show();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                    BindDataGrid();
                    txtSurname.Text = "";

                    txtDTRegFrom.Text = "";
                    txtDTRegTo.Text = "";

                    ProgressBarModalPopupExtender.Hide();
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox')", true);
                    // return;
                }
                //  }
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have raise CFR')", true);
                //   // return;
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
    #region BindGridControl Method
    private void BindGridControl(GridView objDatagrid)
    {
        try
        {
            GridViewRow[] ApprovalArray = new GridViewRow[objDatagrid.Rows.Count];
            objDatagrid.Rows.CopyTo(ApprovalArray, 0);
            //string PrID;
            foreach (GridViewRow row in ApprovalArray)
            {
                RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                //PrID = lbapprove.Text.ToString();
                //HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                //HtmlInputButton btnvari = (HtmlInputButton)row.FindControl("btnVarify");
                //HtmlInputHidden hdnPM = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                //hdnPM.Attributes.Add("ID", "hdnPmtMode" + PrID);
                //hdnVar.Attributes.Add("ID", "hdntxtVarify" + PrID);
                //btnvari.Attributes.Add("ID", "btnVarify" + PrID);
                ////Commented by kalyani on 25-11-13 for hidding visibility of bank verify option start         
                ////Rbapp.Attributes.Add("onClick", "javascript:CheckVarify('" + hdnVar.ClientID + "','" + btnvari.ClientID + "');");
                ////Commented by kalyani on 25-11-13 for hidding visibility of bank verify option end         
                //if (hdnPM.Value.ToString().Trim() == "DC")
                //{
                //    btnvari.Attributes.Add("onclick", "javascript: return funOpenPopWinForBankVariy('CndBankVarify.aspx','" + PrID + "','" + hdnVar.ClientID + "','" + btnvari.ClientID + "')");
                //}
                //else
                //{
                //    btnvari.Disabled = true;
                //    hdnVar.Value = "Done";
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



    #region Button 'Cancel Click Event'
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnReject.Visible = false;
        trbtnexport.Visible = false;
        trtitle.Visible = false;
        btnCancel.Visible = false;
        btnSubmit.Visible = false;
        trDgDetails.Visible = false;
        //Label2.Visible = false;
    }
    #endregion
    #region rbdcfr_SelectedIndexChanged

    protected void rdbCFR_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow grd = ((RadioButtonList)sender).NamingContainer as GridViewRow;
        RadioButtonList rdbCFR1 = (RadioButtonList)grd.FindControl("rdbCFR");
        TextBox remark = (TextBox)grd.FindControl("txtRemarks");
        if (rdbCFR1.SelectedItem.Value == "1")
        {
            remark.Text = "Candidate NOC Approved";
        }
        else
        {
            remark.Text = "";
        }

    }
    protected void chkRejApp_CheckedChanged(object sender, EventArgs e)
    {

        GridViewRow grd = ((CheckBox)sender).NamingContainer as GridViewRow;
        CheckBox ChkSub = (CheckBox)grd.FindControl("chkRejApp");
        //    if (ChkSub.Checked == true)

        //{
        //    //    if (Rbconf.Checked == true)
        //    //    {
        //    remarks.Text = "Candidate Approved";

        //}
        //else
        //{
        //    Rbapp.Checked = false;
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Confirm Interview')", true);
        //    return;
        //}
        //  }

    }
    #endregion

    //#region rbrno_CheckedChanged
    ////method to show candidate reject message in the textbox on checking the radio button
    //protected void rbrno_CheckedChanged(object sender, EventArgs e)
    //{
    //    GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
    //   // RadioButton Rbno = (RadioButton)grd.FindControl("rbrno");
    //    // RadioButton Rbconf = (RadioButton)grd.FindControl("rbrconfirm");
    //   // TextBox remarks = (TextBox)grd.FindControl("txtRemarks");

    //    //if (Rbrej.Checked == true)
    //    //{
    //    //    //if (Rbconf.Checked == true)
    //    //    //{
    //    //    remarks.Text = "Candidate Rejected";
    //    //    //}
    //    //    //else
    //    //    //{
    //    //    //    Rbrej.Checked = false;
    //    //    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Confirm Interview')", true);
    //    //    //    return;
    //    //    //}
    //    //}
    //}
    //#endregion
    #region btnSearch Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            div5.Attributes.Add("style", "margin-left: 70px; overflow:auto;display:block;");
            hdnMenuName.Value = Request.Form[hdnMenuName.UniqueID];
            TabName.Value = Request.Form[TabName.UniqueID];
            //For admin/sysadmin user user
            if (Request.QueryString["pg"].ToString() == "Approval")
            {
                // btnReject.Visible = true;
                btnSubmit.Visible = true;
                btnCancel.Visible = true;
                hdnCndNo.Value = txtCndNo.Text.Trim();
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
                    txtClosed.Text = "1";
                    txtCFR.Text = "1";
                    txtprevious1.Text = "1";
                    BindInbox();
                    BindResponded1();
                    BindClosed1();
                    BindCFR1();

                }
                if (hdnMenuName.Value == "2")
                {
                    strFlagmenu = "2";
                    txtResponded.Text = "1";
                    txtClosed.Text = "1";
                    txtCFR.Text = "1";
                    txtprevious1.Text = "1";
                    BindResponded();
                    BindInbox1();
                    BindClosed1();
                    BindCFR1();

                }
                if (hdnMenuName.Value == "3")
                {
                    strFlagmenu = "3";
                    txtResponded.Text = "1";
                    txtClosed.Text = "1";
                    txtCFR.Text = "1";
                    txtprevious1.Text = "1";
                    BindClosed();
                    BindResponded1();
                    BindInbox1();
                    //BindClosed1();
                    BindCFR1();

                }
                if (hdnMenuName.Value == "4")
                {
                    strFlagmenu = "4";
                    txtResponded.Text = "1";
                    txtClosed.Text = "1";
                    txtCFR.Text = "1";
                    txtprevious1.Text = "1";
                    BindCFR();
                    BindResponded1();
                    BindInbox1();
                    BindClosed1();

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

    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdvTrn50HrsSearch.aspx");
        //added by pranjali on 27-11-2013 start
        txtCndNo.Text = "";
        txtAppNo.Text = ""; //added by pranjali on 10-03-2014
        txtRecruiterName.Text = "";
        txtReqDate.Text = "";
        txtName.Text = "";
        txtBranchName.Text = ""; //added by pranjali on 10-03-2014
        txtSurname.Text = ""; //added by pranjali on 10-03-2014
        trDgViewDtl.Visible = false;
        btnSubmit.Visible = false;
        btnCancel.Visible = false;
        txtURN.Text = "";
        txtSapCode.Text = "";
        txtAgntBroker.Text = "";
        ddlProcessType.Text = "Select";
        txtPan.Text = "";
        txtDTRegFrom.Text = "";
        txtDTRegTo.Text = "";
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

            dsHrsTrn = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvTrnHrsDtl_Ver1", htParam);

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
            //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFR_user", htmulti);
            //added by pranjali on 02-04-2014 start
            dsmulti.Clear();
            //dsCfruser.Clear();
            //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            //if (UserType == "I")
            //{
            //    htmulti.Clear();
            //    htmulti.Add("@CndNo", "");
            //    htmulti.Add("@AppNo", "");
            //    htmulti.Add("@CndName", "");
            //    htmulti.Add("@MemberCode", MemberCode);
            //    htmulti.Add("@MemberType", MemberType);
            //    htmulti.Add("@Flag", "1");
            //    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFR", htmulti);
            //}
            //else if (UserType == "E")
            //{
            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            htmulti.Add("@Flag", "1");
            //htmulti.Add("@MemberCode", MemberCode);
            //htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFRForExtrnl", htmulti);
            //}
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
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridInbox.DataSource = null;
                GridInbox.DataBind();
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
            //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFR_user", htmulti);
            //added by pranjali on 02-04-2014 start
            dsCfruser.Clear();
            //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            //if (UserType == "I")
            //{
            //    htmulti.Clear();
            //    htmulti.Add("@CndNo", "");
            //    htmulti.Add("@AppNo", "");
            //    htmulti.Add("@CndName", "");
            //    htmulti.Add("@MemberCode", MemberCode);
            //    htmulti.Add("@MemberType", MemberType);
            //    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFR", htmulti);
            //}
            //else if (UserType == "E")
            //{
            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFRForExtrnl", htmulti);
            // }

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
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridResponded.DataSource = null;
                GridResponded.DataBind();
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
            //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Closed_user", htmulti);

            //added by pranjali on 02-04-2014 start
            //dsCfruser.Clear();
            //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
            //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
            //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
            //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
            //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
            //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
            //if (UserType == "I")
            //{
            //    htmulti.Clear();
            //    htmulti.Add("@CndNo", "");
            //    htmulti.Add("@AppNo", "");
            //    htmulti.Add("@CndName", "");
            //    htmulti.Add("@MemberCode", MemberCode);
            //    htmulti.Add("@MemberType", MemberType);
            //    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Closed", htmulti);
            //}
            //else if (UserType == "E")
            //{
            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            //htmulti.Add("@MemberCode", MemberCode);
            //htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ClosedForExtrnl", htmulti);
            // }
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
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridClosed.DataSource = null;
                GridClosed.DataBind();
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
        //dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRDetails", htmulti);
        //added by pranjali on 02-04-2014 start
        //dsCfruser.Clear();
        //dsCfruser = oCommonUtility.GetUserDtls(Session["UserID"].ToString());
        //string MemberCode = dsCfruser.Tables[0].Rows[0]["MemberCode"].ToString();
        //string MemberType = dsCfruser.Tables[0].Rows[0]["MemberType"].ToString();
        //string BizSrc = dsCfruser.Tables[0].Rows[0]["BizSrc"].ToString();
        //string ChnCls = dsCfruser.Tables[0].Rows[0]["ChnCls"].ToString();
        //string UserType = dsCfruser.Tables[0].Rows[0]["UserType"].ToString();
        //if (UserType == "I")
        //{
        //    htmulti.Clear();
        //    htmulti.Add("@CndNo", "");
        //    htmulti.Add("@AppNo", "");
        //    htmulti.Add("@CndName", "");
        //    htmulti.Add("@MemberCode", MemberCode);
        //    htmulti.Add("@MemberType", MemberType);
        //    dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRDetails", htmulti);
        //}
        //else if (UserType == "E")
        //{
        htmulti.Clear();
        htmulti.Add("@CndNo", "");
        htmulti.Add("@AppNo", "");
        htmulti.Add("@CndName", "");
        //htmulti.Add("@MemberCode", MemberCode);
        //htmulti.Add("@MemberType", MemberType);
        dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRDetailsForExtrnl", htmulti);
        // }
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

    #region Performance QC

    protected void BindResponded()
    {
        try
        {

            //  dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", txtCndNo.Text.ToString().Trim());
            htmulti.Add("@AppNo", txtAppNo.Text.ToString().Trim());
            htmulti.Add("@CndName", txtName.Text.ToString().Trim());
            htmulti.Add("@Surname", txtSurname.Text.ToString().Trim());
            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());

            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFRForExtrnl", htmulti);

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
                    //trRecord.Visible = true;
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

            dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());

            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRespondedCFRForExtrnl", htmulti);

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
                    //trRecord.Visible = true;
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
    protected void BindClosed()
    {
        try
        {

            //dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", txtCndNo.Text.ToString().Trim());
            htmulti.Add("@AppNo", txtAppNo.Text.ToString().Trim());
            htmulti.Add("@CndName", txtName.Text.ToString().Trim());
            htmulti.Add("@Surname", txtSurname.Text.ToString().Trim());

            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ClosedForExtrnl", htmulti);


            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    GridClosed.DataSource = dsmulti;
                    GridClosed.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridClosed.PageCount > Convert.ToInt32(txtClosed.Text))
                    {
                        btnNextClosed.Enabled = true;
                    }
                    else
                    {
                        btnNextClosed.Enabled = false;
                    }
                    divclose.Visible = false;
                    ClosedPage.Visible = true;
                }
                else
                {
                    GridClosed.DataSource = null;
                    GridClosed.DataBind();
                    // trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                    divclose.Visible = true;
                    ClosedPage.Visible = false;
                }
            }
            else
            {
                GridClosed.DataSource = null;
                GridClosed.DataBind();
                //  trRecord.Visible = true;
                divclose.Visible = true;
                ClosedPage.Visible = false;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
    protected void BindClosed1()
    {
        try
        {

            dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");

            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ClosedForExtrnl", htmulti);

            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    GridClosed.DataSource = dsmulti;
                    GridClosed.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridClosed.PageCount > Convert.ToInt32(txtClosed.Text))
                    {
                        btnNextClosed.Enabled = true;
                    }
                    else
                    {
                        btnNextClosed.Enabled = false;
                    }
                    divclose.Visible = false;
                    ClosedPage.Visible = true;
                }
                else
                {
                    GridClosed.DataSource = null;
                    GridClosed.DataBind();
                    // trRecord.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                    divclose.Visible = true;
                    ClosedPage.Visible = false;
                }
            }
            else
            {
                GridClosed.DataSource = null;
                GridClosed.DataBind();
                //  trRecord.Visible = true;
                divclose.Visible = true;
                ClosedPage.Visible = false;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
    //Added by pranjali on 25022014 on click of CFR TAB start
    protected void BindCFR()
    {
        try
        {

            dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", txtCndNo.Text.ToString().Trim());
            htmulti.Add("@AppNo", txtAppNo.Text.ToString().Trim());
            htmulti.Add("@CndName", txtName.Text.ToString().Trim());
            htmulti.Add("@Surname", txtSurname.Text.ToString().Trim());
            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());
            //htmulti.Add("@MemberCode", MemberCode);
            //htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRDetailsForExtrnl", htmulti);


            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    GridCFR.DataSource = dsmulti;
                    GridCFR.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridCFR.PageCount > Convert.ToInt32(txtCFR.Text))
                    {
                        btnNextCFR.Enabled = true;
                    }
                    else
                    {
                        btnNextCFR.Enabled = false;
                    }
                    divCFRS.Visible = false;
                    CFRPage.Visible = true;
                }
                else
                {
                    GridCFR.DataSource = null;
                    GridCFR.DataBind();
                    divCFRS.Visible = true;
                    CFRPage.Visible = false;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridCFR.DataSource = null;
                GridCFR.DataBind();
                divCFRS.Visible = true;
                CFRPage.Visible = false;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
        }
    }
    protected void BindCFR1()
    {
        try
        {

            dsmulti.Clear();

            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            htmulti.Add("@Flag", "1");
            htmulti.Add("@UserId", Session["UserID"].ToString());
            //htmulti.Add("@MemberCode", MemberCode);
            //htmulti.Add("@MemberType", MemberType);
            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCFRDetailsForExtrnl", htmulti);

            if (dsmulti != null)
            {
                if (dsmulti.Tables[0].Rows.Count > 0)
                {
                    GridCFR.DataSource = dsmulti;
                    GridCFR.DataBind();
                    ViewState["grid"] = dsmulti.Tables[0];
                    if (GridCFR.PageCount > Convert.ToInt32(txtCFR.Text))
                    {
                        btnNextCFR.Enabled = true;
                    }
                    else
                    {
                        btnNextCFR.Enabled = false;
                    }
                    divCFRS.Visible = false;
                    CFRPage.Visible = true;
                }
                else
                {
                    GridCFR.DataSource = null;
                    GridCFR.DataBind();
                    divCFRS.Visible = true;
                    CFRPage.Visible = false;
                    lblMessage.Text = "0 Record Found";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                GridCFR.DataSource = null;
                GridCFR.DataBind();
                divCFRS.Visible = true;
                CFRPage.Visible = false;
                lblMessage.Text = "0 Record Found";
                lblMessage.Visible = true;
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
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserId"].ToString().Trim());
        }
    }
    //Added by pranjali on 25022014 on click of CFR TAB end
    private void GetRenewalDtls()
    {
        Hashtable htRe = new Hashtable();
        DataSet dsRe = new DataSet();
        htRe.Add("@CndNo", ViewState["CndNo"]);
        dsRe = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htRe);
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

            if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR" || Request.QueryString["Status"].ToString() == "CVR" || Request.QueryString["Status"].ToString() == "RCV" ||
                Request.QueryString["Status"].ToString() == "CHQBUNCE" || Request.QueryString["Status"].ToString() == "CMMRCV" || Request.QueryString["Status"].ToString() == "ACC" ||
                Request.QueryString["Status"].ToString() == "POSKEY")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + lblCndno.Text + "&Code=" + Code.Trim() + "&Type=Qc&user=Lic','LicensingRespond','width=900,height=670,resizable=0,left=190,scrollbars=1');";

                //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + lblCndno.Text + "&Code=" + Code.Trim() + "&Type=Qc&user=Lic&mdlpopup=','LicensingRespond','width=1150,height=670,resizable=0,left=160,scrollbars=1');";
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                //  MdlPopRaiseSub.Show();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFR('" + lblCndno.Text + "','" + Code.Trim() + "','IN');", true);//added by shreela on 15/07/2014
                Response.Redirect("NOCApproval.aspx?TrnRequest=CFRCVR&CndNo=" + lblCndno.Text + "&Code=" + Code + "&Cfr=IN&Type=CFR&Status=CVR&mdlpopup=MdlPopRaiseSub");
            }
            else
            {

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                ViewState["CndNo"] = lblCndno.Text;
                GetRenewalDtls();
                if (ViewState["IsUpld"].ToString() == "U" && ViewState["RenewalFlag"].ToString() == "Y")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRBrn('" + lblCndno.Text + "','" + "TccDwnld,Spon" + "');", true);
                    Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + lblCndno.Text + "&Code=TccDwnld,Spon&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub");
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRBrn('" + lblCndno.Text + "','" + Code.Trim() + "');", true);
                    Response.Redirect("AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + lblCndno.Text + "&Code=" + Code.Trim() + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub");

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
                Label lblappno = (Label)e.Row.FindControl("lblAppNo");

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
    protected void GridClosed_RowCommand(object sender, GridViewCommandEventArgs e)

    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
                                                           //added by rachana on 13022013 for open inbox with edit and view cfr part start   
            if (e.CommandName == "ViewCFR")
            {

                if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR" || Request.QueryString["Status"].ToString() == "CVR" || Request.QueryString["Status"].ToString() == "RCV" ||
                    Request.QueryString["Status"].ToString() == "CHQBUNCE" || Request.QueryString["Status"].ToString() == "CMMRCV" || Request.QueryString["Status"].ToString() == "ACC" ||
                    Request.QueryString["Status"].ToString() == "POSKEY")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblCndno = (Label)row.FindControl("lblCndNo");
                    string user = Session["UserID"].ToString();

                    MdlPopRaiseSub.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcShowPopup('CFR','" + lblCndno.Text + "','Closed','" + user + "');", true);//added by shreela on 15/07/2014

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
    protected void
        GridClosed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hdnAppNo.Value = "";//Commented by rachana on 24122013
            hdnName.Value = "";
            hdnCandCode.Value = "";
            Label lblCndName = (Label)e.Row.FindControl("lblCndName");
            Label lblCandcode = (Label)e.Row.FindControl("lblCndNo");
            Label lblappno = (Label)e.Row.FindControl("lblAppNo");
            //hdnAppNo.Value = lblappno.Text; //Commented by rachana on 24122013
            hdnName.Value = lblCndName.Text;
            hdnCandCode.Value = lblCandcode.Text;
            string user = Session["UserID"].ToString();
            LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");

            //lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCandcode.Text + "','Closed','" + user + "');return false;");
        }
        // MdlPopRaiseCFR1.Show();
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
                Label lblappno = (Label)e.Row.FindControl("lblAppNo");
                //hdnAppNo.Value = lblappno.Text;//Commented by rachana on 24122013

                Label lblCndno = (Label)e.Row.FindControl("lblCndNo");
                LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");
                //lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCndno.Text + "','Responded','" + usertype + "','user=Brn');return false;");


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
            Label lblappno = (Label)e.Row.FindControl("lblAppNo");
            //hdnAppNo.Value = lblappno.Text; //Commented by rachana on 24122013
            hdnName.Value = lblCndName.Text;
            hdnCandCode.Value = lblCandcode.Text;
            string user = Session["UserID"].ToString();
            LinkButton lnkviewcfr = (LinkButton)e.Row.FindControl("lblcfr");

            // lnkviewcfr.Attributes.Add("onclick", "funcShowPopupCFR('CFRDetail','" + lblCandcode.Text + "','CFRDetail','" + user.ToString() + "');return false;");
        }
        // MdlPopRaiseCFR1.Show();
    }
    protected void GridCFR_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            Code = Request.QueryString["Code"].ToString(); //added by pranjali on 15042014
            //added by rachana on 13022013 for open inbox with edit and view cfr part start   
            if (e.CommandName == "ViewCFR")
            {

                if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["Status"].ToString() == "NOCCFR" || Request.QueryString["Status"].ToString() == "CVR" || Request.QueryString["Status"].ToString() == "RCV" ||
                    Request.QueryString["Status"].ToString() == "CHQBUNCE" || Request.QueryString["Status"].ToString() == "CMMRCV" || Request.QueryString["Status"].ToString() == "ACC" ||
                    Request.QueryString["Status"].ToString() == "POSKEY")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    Label lblCndno = (Label)row.FindControl("lblCndNo");
                    string user = Session["UserID"].ToString();

                    MdlPopRaiseSub.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcShowPopupCFR('CFRDetail','" + lblCndno.Text + "','CFRDetail','" + user + "');", true);//added by shreela on 15/07/2014

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
    //Added by pranjali on 25022014 for GridCFR start

    protected void BindInbox()
    {
        try
        {

            htmulti.Clear();
            htmulti.Add("@CndNo", txtCndNo.Text.ToString().Trim());
            htmulti.Add("@AppNo", txtAppNo.Text.ToString().Trim());
            htmulti.Add("@CndName", txtName.Text.ToString().Trim());
            htmulti.Add("@Surname", txtSurname.Text.ToString().Trim());

            htmulti.Add("@Flag", "1");

            htmulti.Add("@UserId", Session["UserID"].ToString());

            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFRForExtrnl", htmulti);

            //  }
            //added by pranjali on 28-03-2014 end
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
                    // trRecord.Visible = true;
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
                // trRecord.Visible = true;
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
    protected void BindInbox1()
    {
        try
        {

            htmulti.Clear();
            htmulti.Add("@CndNo", "");
            htmulti.Add("@AppNo", "");
            htmulti.Add("@CndName", "");
            htmulti.Add("@Flag", "1");

            htmulti.Add("@UserId", Session["UserID"].ToString());

            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAdvDetailsForCFRForExtrnl", htmulti);

            //  }
            //added by pranjali on 28-03-2014 end
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
                    // trRecord.Visible = true;
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
                // trRecord.Visible = true;
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

    #endregion
    //Added by rachana on 24122013 for showing records in page selected in ddlShwRecrds start
    protected void ddlShwRecrds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds.SelectedValue != null || ddlShwRecrds.SelectedValue != "")
        {
            GetDataTable();
        }
    }

    #region Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion
    #region GridView RowCommand
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if (e.CommandName == "click")
        // {

        //string cndno = e.CommandArgument.ToString();
        //Changed by rachana on 27112013 to redirect and fill all data of candidate start
        //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E");
        //Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit&Flag=App");
        //Changed by rachana on 27112013 to redirect and fill all data of candidate end
        //}

    }
    #endregion

    #region OnRowDataBound Method
    //Method to show for larger text in grid as substring
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        //Added by Ibrahim on 29/05/2013 for larger text in grid as substring Start
        string str = ".....";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //Label lblbizsrc = (Label)e.Row.FindControl("lblbizsrc");
            Label lblNamePronoun = (Label)e.Row.FindControl("lblNamePronoun");
            Label lbSurname = (Label)e.Row.FindControl("lbSurname");
            //Label lblChnCls = (Label)e.Row.FindControl("lblChnCls");
            //Label lblAgentType = (Label)e.Row.FindControl("lblAgentType");
            Label lblCndStatus = (Label)e.Row.FindControl("lblCndStatus");
            Label lblCFRFlag = (Label)e.Row.FindControl("lblCFRFlag");

            LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
            //lbCndNo.Enabled = false;
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" start
            if (lblNamePronoun.Text != null && lblNamePronoun.Text != "")
            {
                if (lblNamePronoun.Text.Length > 20)
                {
                    lblNamePronoun.Text = lblNamePronoun.Text.Substring(0, 18) + str;
                }
            }
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" End

            //lblChnCls.Text = lblChnCls.Text.Substring(0, 10) + str;
            //lblAgentType.Text = lblAgentType.Text.Substring(0, 10) + str;
            //lblCndStatus.Text = lblCndStatus.Text.Substring(0, 26) + str;
            if (lblCndStatus.Text != null && lblCndStatus.Text != "")
            {
                if (lblCndStatus.Text.Length > 30)
                {
                    lblCndStatus.Text = lblCndStatus.Text.Substring(0, 30) + str;
                }
            }
            //Added by Ibrahim on 29/05/2013 for larger text in grid as substring End 

            if (Request.QueryString["type"].Trim() == "covernote")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }
            else if (Request.QueryString["type"].Trim() == "Receivable")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }

            else if (Request.QueryString["type"].Trim() == "ChqBounce")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }
            else if (Request.QueryString["type"].Trim() == "CmmRcvable")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }
            else if (Request.QueryString["type"].Trim() == "Account")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }
            else if (Request.QueryString["type"].Trim() == "POSKey")
            {
                if (lblCFRFlag.Text == "Raised")
                {
                    e.Row.BackColor = Color.Orange;
                }
            }

        }
    }


    #endregion

    //Added by rachana on 24122013 for showing records in page selected in ddlShwRecrds end
    //added by rachana on 13022013 for open inbox with edit and view cfr part start  
    protected void GridResponded_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Code = Request.QueryString["Code"].ToString();//added by pranjali on 15042014
        if (e.CommandName == "ViewCFR")
        {
            //if (Session["UserType"].ToString() == "HO")
            if (Request.QueryString["Pg"].ToString() == "viewcfr" && Request.QueryString["status"].ToString() == "NOCCFR")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                //string strWindow = "window.open('AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRespond&CndNo=" + lblCndno.Text + "&Code=" + Code.Trim() + "&Type=QcRes&user=Lic&mdlpopup=','LicensingRespond','width=900,height=670,resizable=0,left=190,scrollbars=1');";

                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
                // MdlPopRaiseSub.Show();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcopenCFRres('" + lblCndno.Text + "','" + Code.Trim() + "','Res','" + Session["UserID"].ToString() + "');", true);//added by shreela on 15/07/2014
                Response.Redirect("NOCApproval.aspx?TrnRequest=CFRRespond1&CndNo=" + lblCndno.Text + "&Code=" + Code + "&Cfr=Res&UserId=" + Session["UserID"].ToString() + "&Type=Res&status=NOCCFR&mdlpopup=MdlPopRaiseSub");
            }
            else
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                Label lblCndno = (Label)row.FindControl("lblCndNo");
                LinkButton lnkviewcfr = (LinkButton)row.FindControl("lblcfr");
                lnkviewcfr.Attributes.Add("onclick", "funcShowPopup('CFR','" + lblCndno.Text + "','Responded','" + usertype + "','user=Brn');return false;");
            }
        }

    }
    //added by rachana on 13022013 for open inbox with edit and view cfr part end

    //added by shreela on 14/07/2014 start
    protected void btnReFresh_Click(object sender, EventArgs e)
    {
        if (ViewState["Value"].ToString().Trim() == "50hrs")
        {
            GetDataTable();
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
    //added by shreela on 14/07/2014
    private void ddlProcessType1()
    {
        try
        {

            //added by nikhil on 9.6.15
            Hashtable htParam = new Hashtable();
            DataSet dsComp = new DataSet();
            //oCommon.getDropDown(ddlNameIns, "ComptCompName", 1, "", 1);
            //ddlNameIns.Items.Insert(0, "--Select--")
            //if (Request.QueryString["Pg"].ToString() == "50hrs" && Request.QueryString["Status"].ToString() == "NOC")
            //{

            //    dsComp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNewProcessType");
            //}
            //else
            //{
            htParam.Add("@Flag", "1");
            dsComp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetNewProcessType", htParam);
            // }

            if (dsComp.Tables[0].Rows.Count > 0)
            {
                ddlProcessType.DataSource = dsComp;
                ddlProcessType.DataTextField = "Name";
                ddlProcessType.DataValueField = "Name";
                ddlProcessType.DataBind();
                ddlProcessType.Items.Insert(0, "Select");
            }

            //ended by nikhil on 9.6.15
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            int count1 = 0;
            int count = 0;
            String strAPPFlag = string.Empty;
            string sremarks;

            foreach (GridViewRow row in dgDetails.Rows)
            {
                RadioButtonList rdbCFR = (RadioButtonList)row.FindControl("rdbCFR");
                string strRdb = rdbCFR.SelectedValue.ToString();
                DataSet dsFlag1 = new DataSet();
                // rdbCFR.SelectedIndex = 0;

                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                Label lblappno = (Label)row.FindControl("lblappno");
                CheckBox ChkRej = (CheckBox)row.FindControl("chkRejApp");
                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                sremarks = remarks.Text.Trim();
                Hashtable htRemDoc = new Hashtable();
                DataSet dsRemDoc = new DataSet();
                htRemDoc.Add("@UserType", Request.QueryString["type"].ToString().Trim());
                dsRemDoc = dataAccessRecruit.GetDataSetForPrcRecruit("prc_GetRemarkDoccode", htRemDoc);
                ViewState["RemarkId"] = dsRemDoc.Tables[0].Rows[0]["RemarkId"].ToString().Trim();
                ViewState["Doccode"] = dsRemDoc.Tables[0].Rows[0]["DocCode"].ToString().Trim();
                Hashtable htParam = new Hashtable();
                DataSet dsFlag = new DataSet();
                if (ChkRej.Checked == true)
                {

                    if (strRdb == "0")
                    {


                        Hashtable htparam1 = new Hashtable();
                        DataSet dsapprovechk = new DataSet();
                        htparam1.Add("@CndNo", lbapprove.Text.Trim());
                        htparam1.Add("@Flag", "2");
                        htparam1.Add("@UserId", Request.QueryString["type"].ToString().Trim());
                        dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam1);

                        if (dsapprovechk.Tables.Count > 0)
                        {
                            if (dsapprovechk.Tables[0].Rows.Count > 0)
                            {
                                int i;
                                for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                                {
                                    string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                                    string CFRClosed = dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();

                                    if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1"))
                                    {
                                        ChkRej.Checked = false;
                                        rdbCFR.Items[0].Selected = false;
                                        rdbCFR.Items[1].Selected = false;
                                        remarks.Text = "";
                                        ProgressBarModalPopupExtender.Hide();
                                        string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have Already  raised CFR ')", true);
                                        return;
                                    }
                                }
                            }
                        }
                        htParam.Add("@UserId", Session["UserID"].ToString());
                        htParam.Add("@DocCode", ViewState["Doccode"].ToString());
                        htParam.Add("@RemarkId", ViewState["RemarkId"].ToString());
                        htParam.Add("@UserType1", Request.QueryString["type".ToString().Trim()]);
                        htParam.Add("@Flag", "R");
                        dsFlag = dataAccessRecruit.GetDataSetForPrcRecruit("prc_getcfr", htParam);
                        string strFlag = dsFlag.Tables[0].Rows[0]["Flag"].ToString();
                        if (strFlag == "0")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not authorized to raise cfr')", true);
                            return;
                        }
                        else
                        {

                            if (sremarks == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter remark for raising CFR')", true);
                                return;
                            }
                            else
                            {
                                strAPPFlag = "2";
                                RadioButtonList rdbCFR1 = (RadioButtonList)row.FindControl("rdbCFR");
                                rdbCFR1.Items[0].Selected = false;
                                rdbCFR1.Items[1].Selected = false;
                                Hashtable htParam1 = new Hashtable();


                                htParam1.Add("@CndNo", lbapprove.Text.Trim());
                                htParam1.Add("@DocCode", ViewState["Doccode"].ToString());
                                htParam1.Add("@AppNo", lblappno.Text.Trim());
                                htParam1.Add("@CreateBy", Session["UserID"].ToString());
                                // htParam.Add("@Role", Request.QueryString["Type"].ToString().Trim());
                                htParam1.Add("@Flag", "1");
                                htParam1.Add("@Remark", sremarks);
                                //htParam1.Add("@Remark", sremarks);
                                htParam1.Add("@UserType", Request.QueryString["type"].ToString().Trim());
                                dsFlag1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsCfrRemarkNOCTeam", htParam1);
                                //Approve.Append(lbapprove.Text.Trim());
                                //Approve.Append(",");
                                //ApprovedCnd = Approve.ToString();
                                //if (ApprovedCnd != "")
                                //{
                                //    ApprovedCnd = ApprovedCnd.Substring(0, ApprovedCnd.Length - 1);
                                //    //added by shreela on 09/06/2014 start
                                //    String[] strArr = ApprovedCnd.Split(',');
                                //    int count = 0;
                                //    for (int i = 0; i < strArr.Length; i++)
                                //    {
                                //        count++;
                                //    }
                                //    ApprovedCnd = Convert.ToString(count);
                                //    CFRRaiseCnd = "0";
                                //    //added by shreela on 09/06/2014 end
                                //}
                                //else
                                //{
                                //    //ApprovedCnd = "-";
                                //    ApprovedCnd = "0";
                                //}
                                CFRRaise.Append(lbapprove.Text.Trim());
                                CFRRaise.Append(",");

                            }
                        }



                    }
                    else if (strRdb == "1")
                    {

                        Hashtable htparam = new Hashtable();
                        DataSet dsapprovechk = new DataSet();
                        htparam.Add("@CndNo", lbapprove.Text.Trim());
                        htparam.Add("@Flag", "3");
                        htparam.Add("@RemarkId", ViewState["RemarkId"].ToString());

                        htparam.Add("@UserId", Request.QueryString["type"].ToString().Trim());
                        dsapprovechk = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_ChkCFRDocCFRRemark", htparam);

                        if (dsapprovechk.Tables.Count > 0)
                        {
                            if (dsapprovechk.Tables[0].Rows.Count > 0)
                            {
                                int i;
                                for (i = 0; i < dsapprovechk.Tables[0].Rows.Count; i++)
                                {
                                    string CFRRaised = dsapprovechk.Tables[0].Rows[i]["CFRRaised"].ToString().Trim();
                                    string CFRClosed = dsapprovechk.Tables[0].Rows[i]["CFRClosed"].ToString().Trim();

                                    if ((CFRRaised == "1" && CFRClosed == "") || (CFRRaised == "" && CFRClosed == "1"))
                                    {
                                        // RadioButtonList rdbCFR1 = (RadioButtonList)row.FindControl("rdbCFR");
                                        ChkRej.Checked = false;
                                        rdbCFR.Items[0].Selected = false;
                                        rdbCFR.Items[1].Selected = false;
                                        remarks.Text = "";
                                        ProgressBarModalPopupExtender.Hide();
                                        string CFRFor = dsapprovechk.Tables[0].Rows[i]["CFRFor"].ToString().Trim();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CFR still raised for " + CFRFor + " Please Close the CFR first ')", true);
                                        return;
                                    }
                                }
                            }
                        }


                        ////added by pranjali for validation on approve button to ristrict approval bfore closing of 
                        DataSet dsApp = new DataSet();
                        Hashtable htParam2 = new Hashtable();
                        htParam2.Add("@CndNo", lbapprove.Text.Trim());
                        htParam2.Add("@UserType", Request.QueryString["type"].ToString().Trim());
                        dsApp = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRaise", htParam2);
                        string strFlag3 = dsApp.Tables[0].Rows[0]["Flag"].ToString();
                        string strUserId = dsApp.Tables[0].Rows[0]["UserType"].ToString();
                        if (strFlag3 == "1" || strFlag3 == "2")
                        {

                            strAPPFlag = "1";
                            // htParam.Add("@CndNo", lbapprove.Text.Trim());
                            RadioButtonList rdbCFR1 = (RadioButtonList)row.FindControl("rdbCFR");
                            rdbCFR1.Items[0].Enabled = false;
                            rdbCFR1.Items[1].Enabled = false;
                            ChkRej.Enabled = false;

                            if (strUserId == "covernote")
                            {
                                htParam.Add("@Flag", "1");
                            }
                            else if (strUserId == "Receivable")
                            {
                                htParam.Add("@Flag", "2");
                            }
                            else if (strUserId == "ChqBounce")
                            {
                                htParam.Add("@Flag", "3");
                            }
                            else if (strUserId == "CmmRcvable")
                            {
                                htParam.Add("@Flag", "4");
                            }
                            else if (strUserId == "Account")
                            {
                                htParam.Add("@Flag", "5");
                            }
                            //else
                            //{

                            //}

                            htParam.Add("@CndNo", lbapprove.Text.Trim());
                            htParam.Add("@AppNo", lblappno.Text.Trim());
                            htParam.Add("@CreateBy", Session["UserID"].ToString());
                            htParam.Add("@Role", Request.QueryString["type"].ToString().Trim());
                            htParam.Add("@Approve", "1");
                            htParam.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                            dsFlag1 = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_InsNOCTeamApp", htParam);
                            Approve.Append(lbapprove.Text.Trim());
                            Approve.Append(",");





                        }
                        else
                        {
                            RadioButtonList rdbCFR1 = (RadioButtonList)row.FindControl("rdbCFR");
                            rdbCFR1.Items[0].Selected = false;
                            rdbCFR1.Items[1].Selected = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have raise cfr')" + CFRRaiseCnd, true);
                            return;
                        }


                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Yes or No')", true);
                    }
                }
                //  else if(ChkRej.Checked == false &&  rdbCFR.Items[0].Selected == true || rdbCFR.Items[1].Selected == true) 

                //  {
                //      ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select checkbox for particular candidate')", true);
                //  }
                //else
                //  {

                //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select checkbox for particular candidate')", true);

                //  }

                if (strRdb == "1")
                {
                    dsFlag1.Clear();
                }

                //}


            }
            if (strAPPFlag == "1")
            {
                ApprovedCnd = Approve.ToString();
                if (ApprovedCnd != "")
                {
                    strAPPFlag = "1";
                    ApprovedCnd = ApprovedCnd.Substring(0, ApprovedCnd.Length - 1);
                    //added by shreela on 09/06/2014 start
                    String[] strArr = ApprovedCnd.Split(',');

                    for (int i = 0; i < strArr.Length; i++)
                    {
                        count1++;
                    }
                    ApprovedCnd = Convert.ToString(count1);

                    //added by shreela on 09/06/2014 end
                }
                else
                {
                    //ApprovedCnd = "-";
                    ApprovedCnd = "0";
                }

                //lblmsg.Text = "NOC Approved successfully";
                //lblmsg.ForeColor = Color.Red;
                //lblmsg.Visible = false;
                //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                //alert.InnerHtml = "";
                //MailResponse(PrID);


                Label2.Visible = true;
                Label6.Visible = true;
                lbl4.Visible = false;
               // Label2.Text = "NOC approved successfully.";
               // Label6.Text = "Total Approved NOC :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 

                lblus.Text = " NOC Approved Successfully<br/>" + "Total Approved NOC :"+" "+ ApprovedCnd.ToString();
                string Message = " NOC Approved Successfully<br/><br/>" + "Total Approved NOC :" + " " + ApprovedCnd.ToString();

                //  mdlpopup.Show();
                //   ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup1();", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "popup1('"+Message+"')", true);

                BindDataGrid();
                txtSurname.Text = "";

                txtDTRegFrom.Text = "";
                txtDTRegTo.Text = "";

                //ProgressBarModalPopupExtender.Hide();
            }
            else if (strAPPFlag == "2")
            {
                CFRRaiseCnd = CFRRaise.ToString();
                if (CFRRaiseCnd != "")
                {
                    CFRRaiseCnd = CFRRaiseCnd.Substring(0, CFRRaiseCnd.Length - 1);
                    //added by shreela on 09/06/2014 start
                    String[] strArr = CFRRaiseCnd.Split(',');
                    //int count = 0;
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        count++;
                    }
                    CFRRaiseCnd = Convert.ToString(count);
                    //added by shreela on 09/06/2014 end
                }
                else
                {
                    //RejectdCnd = "-";
                    CFRRaiseCnd = "0";
                }
                lblmsg.Text = "Candidate CFRRaised successfully";
                lblmsg.ForeColor = Color.Red;
                lblmsg.Visible = false;
                //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                lbl3.Visible = true;
                lbl2.Visible = true;
                // mdlpopup.Show();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "popup()", true);

                BindDataGrid();
                //lbl3.Text = "Candidate CFRRaised successfully.";
               // lbl2.Text = "CFRRaise Candidates :" + " " + CFRRaiseCnd.ToString();//added by shreela on 09/06/2014 

                lbl2.Text = "Candidate CFRRaised successfully<br/>" + "CFRRaise Candidates :" + " " + CFRRaiseCnd.ToString();
                string Message1 = " Candidate CFRRaised successfully<br/><br/>" + "CFRRaise Candidates :" + " " + CFRRaiseCnd.ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "popup2('" + Message1 + "')", true);



                txtSurname.Text = "";
                //txtCandCode.Text = "";
                txtDTRegFrom.Text = "";
                txtDTRegTo.Text = "";
                // txtGivenName.Text = "";
                ProgressBarModalPopupExtender.Hide();
            }
            if (count == 0 && count1 == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Checkbox for Particular Candidate')", true);
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


    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
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

    protected void btnnext_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex + 1;
            BindDataGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = dgDetails.PageCount;
            if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = dgDetails.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
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
    protected void btnprevious1_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridInbox.PageIndex;
            GridInbox.PageIndex = pageIndex - 1;
            BindInbox();
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

    protected void btnnext1_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = GridInbox.PageIndex;
            GridInbox.PageIndex = pageIndex + 1;
            BindInbox();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = GridInbox.PageCount;
            if (txtPage.Text == Convert.ToString(GridInbox.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = GridInbox.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridInbox.PageCount;
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

    protected void btnprevious2_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = GridResponded.PageIndex;
            GridResponded.PageIndex = pageIndex - 1;
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

    protected void btnnext2_Click(object sender, EventArgs e)
    {


        try
        {
            int pageIndex = GridResponded.PageIndex;
            GridResponded.PageIndex = pageIndex + 1;
            BindDataGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            int page = GridResponded.PageCount;
            if (txtPage.Text == Convert.ToString(GridResponded.PageCount))
            {
                btnnext.Enabled = false;
            }
            else
            {
                int intPageIndex = GridResponded.PageIndex + 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + GridResponded.PageCount;
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
        if (hdnMenuName.Value == "3")
        {
            strFlagmenu = "3";
            int pageIndex = GridClosed.PageIndex;
            GridClosed.PageIndex = pageIndex - 1;
            if (strFlagmenu == "3")
            {
                BindClosed();
            }
            else
            {
                BindClosed1();
            }
            txtClosed.Text = Convert.ToString(Convert.ToInt32(txtClosed.Text) - 1);
            if (txtClosed.Text == "1")
            {
                btnPreClosed.Enabled = false;
            }
            else
            {
                btnPreClosed.Enabled = true;
            }
            btnNextClosed.Enabled = true;
        }
        if (hdnMenuName.Value == "4")
        {
            strFlagmenu = "4";
            int pageIndex = GridCFR.PageIndex;
            GridCFR.PageIndex = pageIndex - 1;
            if (strFlagmenu == "4")
            {
                BindCFR();
            }
            else
            {
                BindCFR1();
            }
            txtCFR.Text = Convert.ToString(Convert.ToInt32(txtCFR.Text) - 1);
            if (txtCFR.Text == "1")
            {
                btnPreCFR.Enabled = false;
            }
            else
            {
                btnPreCFR.Enabled = true;
            }
            btnNextCFR.Enabled = true;
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
        if (hdnMenuName.Value == "3")
        {
            strFlagmenu = "3";
            int pageIndex = GridClosed.PageIndex;
            GridClosed.PageIndex = pageIndex + 1;
            if (strFlagmenu == "3")
            {
                BindClosed();
            }
            else
            {
                BindClosed1();
            }

            txtClosed.Text = Convert.ToString(Convert.ToInt32(txtClosed.Text) + 1);
            btnPreClosed.Enabled = true;
            int page = GridClosed.PageCount;
            if (txtClosed.Text == Convert.ToString(GridClosed.PageCount))
            {
                btnNextClosed.Enabled = false;
            }
        }
        if (hdnMenuName.Value == "4")
        {
            strFlagmenu = "4";
            int pageIndex = GridCFR.PageIndex;
            GridCFR.PageIndex = pageIndex + 1;
            if (strFlagmenu == "4")
            {
                BindCFR();
            }
            else
            {
                BindCFR1();
            }


            txtCFR.Text = Convert.ToString(Convert.ToInt32(txtCFR.Text) + 1);
            btnPreCFR.Enabled = true;
            int page = GridCFR.PageCount;
            if (txtCFR.Text == Convert.ToString(GridCFR.PageCount))
            {
                btnNextCFR.Enabled = false;
            }
        }
    }

}

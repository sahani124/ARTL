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
using INSCL.DAL;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using System.Drawing;
using System.Text;
using CLTMGR;
using DataAccessClassDAL;

public partial class Application_Isys_Recruit_POSPApproval : BaseClass
{

    #region Page Declaration
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    public const string CONN_Recruit = "INSCCommonConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessclass = new DataAccessClass();
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    Hashtable htParams = new Hashtable();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    StringBuilder Approve = new StringBuilder();
    StringBuilder Reject = new StringBuilder();
    ErrLog objErr = new ErrLog();
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    string ApprovedCnd = string.Empty;
    string RejectdCnd = string.Empty;
    String ModuleID = string.Empty;//Added by usha on 25.06.2021
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "CndApproval.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021 ModuleID=11348
            if (!IsPostBack)
            {
                InitializeControl();
                // SetTodaysDateToCompareValidators();
                //GetCandidateDtls();
                //commented by kalyani on 23-12-2013 as not required start
                //GetRecruitSalesChannel(ddlSlsChannel, "", 0);
                //ddlSlsChannel.Items.Insert(0, new ListItem("All", "All"));
                //ddlChnCls.Items.Insert(0, new ListItem("All", "All"));
                //ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
                //commented by kalyani on 23-12-2013 as not required end
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds1);
                chkrcvd.Visible = false;//Added by Nikhil on 8.6.15
                lblconfirm.Visible = false;//Added by Nikhil on 8.6.15
                trDgDetails.Visible = false;
                trDetails.Visible = false;
                trButton.Visible = false;

                // Added by amruta on 1.9.15 start
                // tblLbl.Visible = false;
                trnote.Visible = false;
                // tr4.Visible = false;

                // Added by amruta on 1.9.15 end
                GetAgentandUserDtls();
                GetAgentandUserDtls_lic();//Added by rachana for getting unit rank, unit code

                //if (Request.QueryString["PG"].ToString().Trim() != "NOCApproval")//Added by usha  on 27.12.2018
                //{

                //    //Comented by usha  as for RM user can approve NOC   on 27.12.2018
                //    //if (ViewState["userrollcode"].ToString() != "SALESTEAM" && ViewState["userrollcode"].ToString() != "LICTEAM")
                //    //{
                //    btnSubmit.Attributes.Add("onclick", "Javascript:return ValidationConfirm();");//Added by Nikhil on 08062015
                //    //}
                //}
                //else
                //{
                   // trCodedlicdetails.Visible = true;
              //  }

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
                    //ViewState[UserId"] = dsAgent.Tables[0].Rows[0]["UserId"].ToString();
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

    //protected void SetTodaysDateToCompareValidators()
    //{
    //    string defaultDateFormat = "DD-MM-YYYY";
    //    string today = DateTime.Today.ToString(defaultDateFormat);
    //    //cvIsActiveDateNotInFuture.ValueToCompare = today;
    //    cvIsActiveDateNotInFuture.ValueToCompare = DateTime.Now.ToShortDateString();
    //    cvIsActiveDateNotInFuturefrom.ValueToCompare = DateTime.Now.ToShortDateString();
    //}

    #region InitializeControl
    private void InitializeControl()
    {
        try
        {
            //lblApplicationNo.Text = olng.GetItemDesc("lblApplicationNo.Text");//added by pranjali on 20-03-2014 
            lbltitle.Text = "Member Approval";
            //lblCandID.Text = olng.GetItemDesc("lblCandID.Text");
            lblBranchName.Text = "Branch Name";
            lblFranName.Text = "Name";// olng.GetItemDesc("lblGivenName.Text");
            lblSurName.Text = olng.GetItemDesc("lblSurName.Text");
            lblDTRegFrom.Text = "Registration Date From";//olng.GetItemDesc("lblDTRegFrom.Text");
            lblDTRegTO.Text = "Registration Date To";
            lblShwRecords1.Text = olng.GetItemDesc("lblShwRecords.Text");
            lblMessage.Text = olng.GetItemDesc("lblMessage.Text");
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));//added by Shreela on 10042014
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

    //    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    //protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = GetDataTable();
    //        DataView dv = new DataView(dt);
    //        GridView dgSource = (GridView)sender;

    //        dgSource.PageIndex = e.NewPageIndex;
    //        dv.Sort = dgSource.Attributes["SortExpression"];

    //        if (dgSource.Attributes["SortASC"] == "No")
    //        {
    //            dv.Sort += " DESC";
    //        }

    //        dgSource.DataSource = dv;
    //        dgSource.DataBind();
    //        BindGridControl(dgSource);
    //        ShowPageInformation();
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
            BindGridControl(dgSource);
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
        try
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CndNo", "");//txtCandCode.Text.Trim()
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());//added by shreela on 10042014
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

            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            //added by nikhil
            if (ViewState["MemberType"].ToString() == "BM")
            {

                htParam.Add("@Page", "CndApr");
            }
            else
            {
                htParam.Add("@Page", "CndSaleApr");
            }
            if (ViewState["UserType"].ToString() == "I")
            {
                //For Internal UserType
                htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            }
            //For External UserType
            else if (ViewState["UserType"].ToString() == "E")
            {
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApprovalForExtrnl", htParam);
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

    #region Button 'Search Click Event'
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtPan.Text.ToString().Trim() != "")
        {
            if (txtPan.Text.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Minimum 5 characters required for PAN No')", true);
                pnl.Visible = false;
                return;
            }
        }
        BindDataGrid();
        //if (chkrcvd.Checked == false)
        //{
        //    btnSubmit.Attributes.Add("onclick", "Javascript:return ValidationConfirm();");

        //}


        //chkrcvd.Visible = false; ;

    }
    #endregion

    #region Bind Data to GridView
    protected void BindDataGrid()
    {
        try
        {
            pnl.Visible = true;
            dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds1.SelectedValue);
            
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@EmpCode", txtFrenchCode.Text.Trim());
            //<% --added by ajay start 1 - 21 - 2021-- %>
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@BranchName", txtBranchName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());
            htParam.Add("@FPMemCode", txtMemberCode.Text.Trim());

            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", DateTime.Parse(txtDTRegFrom.Text.Trim()).ToString(("yyyyMMdd")));
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", DateTime.Parse(txtDTRegTo.Text.Trim()).ToString(("yyyyMMdd")));
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            //if (ViewState["UserType"].ToString() == "I")
            //{
            htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
            htParam.Add("@MemberType", ViewState["MemberType"].ToString());
            dsResult = dataAccessclass.GetDataSetForPrcCLP("prc_GetMemberForPennyDropApproval", htParam);
            //}
            //For External UserType
            //if (ViewState["UserType"].ToString() == "E")
            //{
            //    dsResult.Clear();
            //    dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_GetMemberForEnquiry", htParam);
            //}
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 9)
                    {
                        btnnext.Enabled = true;
                    }
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    ShowPageInformation();
                    trDetails.Visible = true;
                    trDgDetails.Visible = true;
                    trButton.Visible = true;
                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = true;
                    trlbl.Visible = false;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    trnote.Visible = true;
                    if (ViewState["userrollcode"].ToString() == "SALESTEAM" || ViewState["userrollcode"].ToString() == "LICTEAM")
                    {
                        dgDetails.Columns[9].Visible = true;
                        chkrcvd.Visible = false;//Added by Nikhil on 08062015
                        lblconfirm.Visible = false;
                        dgDetails.Columns[5].Visible = true;
                        dgDetails.Columns[6].Visible = true;
                        dgDetails.Columns[7].Visible = true;
                        dgDetails.Columns[9].Visible = true;
                        dgDetails.Columns[10].Visible = true;
                        dgDetails.Columns[14].Visible = true;
                        dgDetails.Columns[15].Visible = true;
                        dgDetails.HeaderRow.Cells[8].Text = "Submission Date";
                        dgDetails.HeaderRow.Cells[4].Text = "Reporting SM Name";

                    }
                    else
                    {
                        dgDetails.Columns[13].Visible = true;
                        chkrcvd.Visible = true;//Added by Nikhil on 08062015
                        lblconfirm.Visible = true;
                    }
                    trnote.Visible = true;
                    tr4.Visible = true;

                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    trButton.Visible = false;
                    trlbl.Visible = true;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    chkrcvd.Visible = false; //Added by Nikhil on 08062015
                    btnSubmit.Enabled = false;
                    btnCancel.Enabled = true;
                    trnote.Visible = false;
                    lblconfirm.Visible = false;
                }
            }
            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblPageInfo.Text = "";
                trDetails.Visible = false;
                trDgDetails.Visible = false;
                trButton.Visible = false;
                trlbl.Visible = true;
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                btnSubmit.Enabled = false;
                btnCancel.Enabled = true;
                trnote.Visible = false;
            }

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

    #region BindGridControl Method
    private void BindGridControl(GridView objDatagrid)
    {
        try
        {
            GridViewRow[] ApprovalArray = new GridViewRow[objDatagrid.Rows.Count];
            objDatagrid.Rows.CopyTo(ApprovalArray, 0);
            string PrID;
            foreach (GridViewRow row in ApprovalArray)
            {
                RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                PrID = lbapprove.Text.ToString();
                HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                HtmlInputButton btnvari = (HtmlInputButton)row.FindControl("btnVarify");
                HtmlInputHidden hdnPM = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                hdnPM.Attributes.Add("ID", "hdnPmtMode" + PrID);
                hdnVar.Attributes.Add("ID", "hdntxtVarify" + PrID);
                btnvari.Attributes.Add("ID", "btnVarify" + PrID);
                //Commented by kalyani on 25-11-13 for hidding visibility of bank verify option start         
                //Rbapp.Attributes.Add("onClick", "javascript:CheckVarify('" + hdnVar.ClientID + "','" + btnvari.ClientID + "');");
                //Commented by kalyani on 25-11-13 for hidding visibility of bank verify option end         
                if (hdnPM.Value.ToString().Trim() == "DC")
                {
                    btnvari.Attributes.Add("onclick", "javascript: return funOpenPopWinForBankVariy('CndBankVarify.aspx','" + PrID + "','" + hdnVar.ClientID + "','" + btnvari.ClientID + "')");
                }
                else
                {
                    btnvari.Disabled = true;
                    hdnVar.Value = "Done";
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

    #region Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion

    #region Button 'Clear Click Event'
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("PennyDrop.aspx?ModuleID=" + ModuleID);
    }
    #endregion

    private void MailResponse(string AppNo)
    {
        //TO GET CANDIDATE TYPE
        Hashtable httable = new Hashtable();
        DataSet dscandtype = new DataSet();
        httable.Add("@CndNo", AppNo);
        dscandtype = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", httable);
        string strCndType = dscandtype.Tables[0].Rows[0]["CandType"].ToString();

        //MAIL Communication integration
        string strUserID = Session["UserID"].ToString();
        Hashtable htData = new Hashtable();
        DataSet ds = new DataSet();
        ds.Clear();
        htData.Add("@Param1", "CND");
        htData.Add("@Param2", strCndType);
        htData.Add("@Param3", ViewState["App_Prospect"]);
        htData.Add("@Param4", "NR");
        ds = dataAccessclass.GetDataSetForMailPrc("Prc_GetMailParams_ARTL", htData);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var NotifyTo = ds.Tables[0].Rows[i]["NotificationTo"].ToString();
                    //objmail.SendNoticationMailSMS("ARTL", "CND", ViewState["CndType"].ToString(), ViewState["CndStatus"].ToString(), System.DBNull.Value, System.DBNull.Value, NotifyTo, ViewState["AppNo"].ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                    objmailcomm.SendNoticationMailSMS("ARTL", "CND", strCndType, ViewState["App_Prospect"].ToString().Trim(), "NR", "", NotifyTo, ViewState["AppNo"].ToString().Trim(), HttpContext.Current.Session["UserID"].ToString());
                }
            }
        }
        //MAIL
    }

    private void GetCandidateDtls(string CndNo)////added by amruta on 24.8.15 start
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", CndNo);//Request.QueryString["CndNo"].ToString().Trim()
        dsDtls = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
        //added by amruta on 24.8.15 start
        ViewState["AutoWavierFlag"] = dsDtls.Tables[0].Rows[0]["AutoWavierflag"].ToString();
        //added by amruta on 24.8.15 end
    }

    #region Button 'Submit Click Event'
    //To add approved and rejected candidate record to cnd table
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {

            //Ended by Nikhil on 08062015

            int BranchCount = dgDetails.Rows.Count;
            if (BranchCount > 0)
            {
                using (SqlConnection objCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CONN_Recruit].ToString()))
                {
                    SqlCommand objCom = new SqlCommand();
                    objCom.Connection = objCon;
                    objCom.CommandType = CommandType.StoredProcedure;

                    objCom.CommandText = "prc_UpdatePennyDropApproval"; //prc_UpdatePOSPCandidateapproval
                    SqlTransaction tn; 
                    objCon.Open();
                    //tn = objCon.BeginTransaction();
                    //objCom.Transaction = tn;


                    try
                    {
                        
                        string strAppRej_Flag = string.Empty;//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate App/Rej 
                        string strAppRej_FlagDesc = string.Empty;
                        string PrID = "0";
                        string sremarks;
                        Hashtable htable = new Hashtable();
                        Hashtable htParams = new Hashtable();
                        GridViewRow[] ApprovalArray = new GridViewRow[dgDetails.Rows.Count];
                        dgDetails.Rows.CopyTo(ApprovalArray, 0);
                        foreach (GridViewRow row in ApprovalArray)
                        {
                            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
                            RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                            RadioButton Rbrej = (RadioButton)row.FindControl("rbrreject");
                            LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                            Label lblappno = (Label)row.FindControl("lblappno");
                          
                            sremarks = txtRemarks.Text.Trim();
                            if (Rbapp.Checked == true)
                            {
                                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                sremarks = remarks.Text.Trim();
                                htable.Add("@MemCode", lbapprove.Text.ToString().Trim());
                                htable.Add("@PDSuccess", "0");
                                //htable.Add("@CndStatus", App_Prospect);

                                htable.Add("@Remarks", sremarks);
                                
                                htable.Add("@UpdateBy", Session["UserID"].ToString());
                               

                                objCom.Parameters.Clear();
                                foreach (DictionaryEntry dist in htable)
                                {
                                    objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                }

                                int ret = objCom.ExecuteNonQuery();
                                Approve.Append(lbapprove.Text.Trim());
                                Approve.Append(",");
                                htable.Clear();
                                
                                //MailResponse(PrID);//mail communication

                            }

                            if (Rbrej.Checked == true)
                            {
                                if (sremarks == "")
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter remark for Reject NOC Candidate')", true);
                                    return;
                                }

                                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                sremarks = remarks.Text.Trim();
                                htable.Add("@MemCode", lbapprove.Text.ToString().Trim());
                                htable.Add("@PDSuccess", "1");
                                //htable.Add("@CndStatus", App_Prospect);

                                htable.Add("@Remarks", sremarks);

                                htable.Add("@UpdateBy", Session["UserID"].ToString());


                                objCom.Parameters.Clear();
                                foreach (DictionaryEntry dist in htable)
                                {
                                    objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                }

                                int ret = objCom.ExecuteNonQuery();
                                Reject.Append(lbapprove.Text.Trim());
                                Reject.Append(",");
                                htable.Clear();


                            }

                        }

                        //Added by Kalyani on 25-11-2013 for Candidate approved/rejected messagebox start 
                        ApprovedCnd = Approve.ToString();
                        if (ApprovedCnd != "")
                        {
                            ApprovedCnd = ApprovedCnd.Substring(0, ApprovedCnd.Length - 1);
                            //added by shreela on 09/06/2014 start
                            String[] strArr = ApprovedCnd.Split(',');
                            int count = 0;
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                count++;
                            }
                            ApprovedCnd = Convert.ToString(count);
                            //added by shreela on 09/06/2014 end
                        }
                        else
                        {
                            //ApprovedCnd = "-";
                            ApprovedCnd = "0";
                        }
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
                        if (ViewState["userrollcode"].ToString() == "SALESTEAM")
                        {
                            lblmsg.Text = "Candidate NOC approved/rejected successfully";
                            lblmsg.ForeColor = Color.Red;
                            // div2.Visible = false;
                            //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                            //alert.InnerHtml = "";
                            //MailResponse(PrID);
                            lbl13.Text = "Candidate NOC approved/rejected successfully";
                            lbl12.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                            //lbl14.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();
                        }
                        else
                        {

                            lblmsg.Text = "Candidate approved/rejected successfully";
                            lblmsg.ForeColor = Color.Red;
                            //div2.Visible = false;
                            //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                            //alert.InnerHtml = "";
                            //MailResponse(PrID);
                            if (ApprovedCnd.ToString() != "0" && RejectdCnd.ToString() !="0")
                            {
                                if (ApprovedCnd.ToString() == "1" && RejectdCnd.ToString() == "1")
                                {
                                    lbl12.Text = "Total Approved Candidate :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                    lbl13.Text = "Total Rejected Candidate :" + " " + RejectdCnd.ToString();
                                    lbl14.Text = "Candidate approved/rejected successfully";
                                }
                                else if (ApprovedCnd.ToString() != "1" && RejectdCnd.ToString() != "1")
                                {
                                    lbl12.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                    lbl13.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();
                                    lbl14.Text = "Candidates approved/rejected successfully";
                                }
                            }

                            else if(ApprovedCnd.ToString() != "0")
                            {
                                if (ApprovedCnd.ToString() == "1")
                                {
                                    lbl12.Text = "Total Approved Candidate :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                    lbl13.Text = "Candidate approved successfully";
                                }
                                else
                                {
                                    lbl12.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                    lbl13.Text = "Candidates approved successfully";
                                }
                            }
                             
                            else
                            {
                                if (RejectdCnd.ToString() == "1")
                                {
                                    lbl12.Text = "Total Rejected Candidate :" + " " + RejectdCnd.ToString();
                                    lbl13.Text = "Candidate rejected successfully";
                                }
                                else
                                {
                                    lbl12.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();
                                    lbl13.Text = "Candidates rejected successfully";
                                }

                            }

                        }//added by shreela on 09/06/2014 
                        //lbl14.Visible = false;
                        mdlpopup.Show();
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                        //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format End 
                        //txtAppNo.Text = "";////Commented by kalyani on 24-12-2013 as not required 
                        txtSurname.Text = "";
                        //txtCandCode.Text = "";
                        txtDTRegFrom.Text = "";
                        txtDTRegTo.Text = "";
                        txtGivenName.Text = "";
                        ProgressBarModalPopupExtender.Hide();//to hide progressbar after submit



                        //Added by Kalyani on 25-11-2013 for Candidate approved/rejected messagebox end 
                        //tn.Commit();
                        BindDataGrid();
                        chkrcvd.Checked = false;//Added by Nikhil on 08062015
                    }
                    catch (Exception ex)
                    {
                        //tn.Rollback();
                        div2.Visible = true;
                        lblmsg.Text = ex.Message;
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

    #region Button 'Cancel Click Event'
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PennyDrop.aspx?ModuleID=" + ModuleID);
    }
    #endregion

    #region GridView RowCommand
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "click")
        {

            string cndno = e.CommandArgument.ToString();

            Response.Redirect("CndReg.aspx?CndNo=" + cndno + "&Type=E&ProspectId=" + cndno + "&ACT=Edit&Flag=App");
            //Changed by rachana on 27112013 to redirect and fill all data of candidate end
        }
        else if (e.CommandName == "NOCclick")
        {
            string cndno = e.CommandArgument.ToString().Trim();
            MdlPopRaiseSub.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "funcNOCDtls('" + cndno + "');", true);

        }



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

            LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
            lbCndNo.Enabled = false;
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" start
            //if (lblNamePronoun.Text != null && lblNamePronoun.Text != "")
            //{
            //    if (lblNamePronoun.Text.Length > 20)
            //    {
            //        lblNamePronoun.Text = lblNamePronoun.Text.Substring(0, 18) + str;
            //    }
            //}//comemnted by sanoj 01062023sss
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" End
            //if (lblSurname.Text != null && lblSurname.Text != "")
            //{
            //    if (lblSurname.Text.Length > 20)
            //    {
            //        lbSurname.Text = lbSurname.Text.Substring(0, 18) + str;
            //    }
            //} //comemnted by sanoj 01062023sss
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
        }
    }
    #endregion

    #region rbrapprove_CheckedChanged
    //method to show candidate approve message in the textbox on checking the radio button
    protected void rbrapprove_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
        RadioButton Rbapp = (RadioButton)grd.FindControl("rbrapprove");
        TextBox remarks = (TextBox)grd.FindControl("txtRemarks");
        //RadioButton Rbrej = (RadioButton)grd.FindControl("rbrreject");
        if (Rbapp.Checked == true)
        {
            
                remarks.Text = "Candidate Approved";
            

        }

    }
    #endregion

    #region rbrreject_CheckedChanged
    //method to show candidate reject message in the textbox on checking the radio button
    protected void rbrreject_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
        RadioButton Rbrej = (RadioButton)grd.FindControl("rbrreject");
        TextBox remarks = (TextBox)grd.FindControl("txtRemarks");

        if (Rbrej.Checked == true)
        {
             
                remarks.Text = "Candidate Rejected";
            


        }
    }
    #endregion



    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {


            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
            //BindDataGrid();
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

        //{
        //    int intPageIndex = dgDetails.PageIndex + 1;
        //    lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
        //}

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

    protected void ddlShwRecrds1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds1.SelectedValue != null)
        {
            BindDataGrid();
        }
    }
}
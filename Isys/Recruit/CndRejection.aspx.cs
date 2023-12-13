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


public partial class Application_ISys_Recruit_CndRejection : BaseClass
{

    #region Page Declaration
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    private DataAccessClass dataAccessclass = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    StringBuilder Approve = new StringBuilder();
    StringBuilder Reject = new StringBuilder();
    ErrLog objErr = new ErrLog();
    IsysMailComm.IsysMailComm objmailcomm = new IsysMailComm.IsysMailComm();
    string ApprovedCnd = string.Empty;
    string RejectdCnd = string.Empty;
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
            olng = new multilingualManager("DefaultConn", "CndRejection.aspx", Session["UserLangNum"].ToString());
            InitializeControl();

            if (!IsPostBack)
            {
                InitializeControl();
                txtPage.Text = "1";
               // SetTodaysDateToCompareValidators();
                oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds);
                trDgDetails.Visible = false;
                trDetails.Visible = false;
                trButton.Visible = false;
                GetAgentandUserDtls();
            }

            //txtDTRegFrom.Attributes.Add("readonly", "readonly");
            //txtDTRegTo.Attributes.Add("readonly", "readonly");
            //commit by pallavi on 15122022
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

    //protected void SetTodaysDateToCompareValidators()
    //{
    //    string defaultDateFormat = "DD-MM-YYYY";
    //    string today = DateTime.Today.ToString(defaultDateFormat);
    //    cvIsActiveDateNotInFuture.ValueToCompare = DateTime.Now.ToShortDateString();
    //    cvIsActiveDateNotInFuturefrom.ValueToCompare = DateTime.Now.ToShortDateString();
    //}

    #region InitializeControl
    private void InitializeControl()
    {
        try
        {
            lblPageInfo.Text = "Candidate Search Results";
            lblApplicationNo.Text = olng.GetItemDesc("lblApplicationNo.Text");
            lbltitle.Text = olng.GetItemDesc("lbltitle.Text");
            lblCandID.Text = olng.GetItemDesc("lblCandID.Text");
            lblGivenName.Text = olng.GetItemDesc("lblGivenName.Text");
            lblSurname.Text = olng.GetItemDesc("lblSurName.Text");
            //lblDTRegFrom.Text = olng.GetItemDesc("lblDTRegFrom.Text");
            //lblDTRegTO.Text = olng.GetItemDesc("lblDTRegTO.Text");
            lblDTRegFrom.Text = "Registration Date From";
            lblDTRegTO.Text = "Registration Date To";
            lblShwRecords.Text = olng.GetItemDesc("lblShwRecords.Text");
            lblMessage.Text = olng.GetItemDesc("lblMessage.Text");
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));
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

    //#region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
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
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@Appno", txtAppNo.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());
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
            htParam.Add("@Page", "CndRej");
            //if (ViewState["UserType"].ToString() == "I")
            //{
            //    //For Internal UserType
            //    htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
            //    htParam.Add("@MemberType", ViewState["MemberType"].ToString());
            //    dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            //}
            ////For External UserType
            //else if (ViewState["UserType"].ToString() == "E")
            //{
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_EnqCandListForRejection", htParam);
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
    }
    #endregion

    #region Bind Data to GridView
    protected void BindDataGrid()
    {
        try
        {
            pnl.Visible = true;
            dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue);
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@Appno", txtAppNo.Text.Trim());
            htParam.Add("@GivenName", txtGivenName.Text.Trim());
            htParam.Add("@Surname", txtSurname.Text.Trim());
            htParam.Add("@PAN", txtPan.Text.Trim());
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
            htParam.Add("@Page", "CndRej");
            dsResult.Clear();
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_EnqCandListForRejection", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                   // ShowPageInformation();
                   
                    trDetails.Visible = true;
                    trDgDetails.Visible = true;
                    trButton.Visible = true;
                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = true;
                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    trnote.Visible = true;
                    trnote1.Visible = true;
                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    trButton.Visible = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";
                    btnSubmit.Enabled = false;
                    btnCancel.Enabled = true;
                    trnote.Visible = false;
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
                lblMessage.Visible = true;
                lblMessage.Text = "0 Record Found";
                btnSubmit.Enabled = false;
                btnCancel.Enabled = true;
                trnote.Visible = false;
            }
            //BindGridControl(dgDetails);
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
                //RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                PrID = lbapprove.Text.ToString();
                HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                HtmlInputButton btnvari = (HtmlInputButton)row.FindControl("btnVarify");
                HtmlInputHidden hdnPM = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                hdnPM.Attributes.Add("ID", "hdnPmtMode" + PrID);
                hdnVar.Attributes.Add("ID", "hdntxtVarify" + PrID);
                btnvari.Attributes.Add("ID", "btnVarify" + PrID);
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
        // txtPage.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;t
        txtPage.Text = intPageIndex.ToString();
    }
    #endregion

    #region Button 'Clear Click Event'
    protected void btnClear_Click(object sender, EventArgs e)
    {

        //String ModuleID = string.Empty;
        String ModuleID = Request.QueryString["ModuleID"].ToString().Trim();

        Response.Redirect("CndRejection.aspx?ModuleID=" + ModuleID);


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

    private void GetCandidateDtls()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsDtls = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandidateDetails", htDtls);
        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
    }

    #region Button 'Submit Click Event'
    //To add approved and rejected candidate record to cnd table
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int BranchCount = dgDetails.Rows.Count;
            if (BranchCount > 0)
            {
                using (SqlConnection objCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CONN_Recruit].ToString()))
                {
                    SqlCommand objCom = new SqlCommand();
                    objCom.Connection = objCon;
                    objCom.CommandType = CommandType.StoredProcedure;
                    objCom.CommandText = "Prc_UpdateCandRejection";
                    //SqlTransaction tn;
                    objCon.Open();
                    try
                    {
                        string App_Prospect = "";
                        string strAppRej_Flag = string.Empty;
                        string strAppRej_FlagDesc = string.Empty;
                        string PrID = "0";
                        string sremarks;
                        Hashtable htable = new Hashtable();
                        GridViewRow[] ApprovalArray = new GridViewRow[dgDetails.Rows.Count];
                        dgDetails.Rows.CopyTo(ApprovalArray, 0);
                        foreach (GridViewRow row in ApprovalArray)
                        {
                            sremarks = "";
                            //RadioButton Rbapp = (RadioButton)row.FindControl("rbrapprove");
                            CheckBox Rbrej = (CheckBox)row.FindControl("rbrreject");
                            LinkButton lbapprove = (LinkButton)row.FindControl("lbCndNo");
                            Label lblappno = (Label)row.FindControl("lblappno");
                            HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                            PrID = lbapprove.Text.ToString();
                            HtmlInputHidden hdnPmt = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                            hdnPmt.Attributes.Add("ID", "hdnPmtMode" + PrID);
                            GridViewRow gvRow = (GridViewRow)hdnPmt.NamingContainer;
                            LinkButton lkbtn = (LinkButton)gvRow.FindControl("lbCndNo");
                            string str = "";
                            
                            if (Rbrej.Checked == true)
                            {
                                App_Prospect = "180";
                                strAppRej_Flag = "1";
                                strAppRej_FlagDesc = "Candidate Rejection";
                                TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                sremarks = remarks.Text.Trim();
                                htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                htable.Add("@CndNo", PrID.Trim());
                                htable.Add("@ApplicationNo", lblappno.Text.Trim());
                                htable.Add("@CndStatus", App_Prospect);
                                htable.Add("@CndAppRej_Flag", strAppRej_Flag);
                                htable.Add("@Reason", strAppRej_FlagDesc);
                                htable.Add("@Remarks", sremarks);
                                htable.Add("@UpdateBy", Session["UserID"].ToString());
                                htable.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                                objCom.Parameters.Clear();
                                foreach (DictionaryEntry dist in htable)
                                {
                                    objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                }

                                int ret = objCom.ExecuteNonQuery();
                                Reject.Append(lbapprove.Text.Trim());
                                Reject.Append(",");
                                htable.Clear();
                                ViewState["App_Prospect"] = App_Prospect;
                                ViewState["AppNo"] = lblappno.Text;
                            }
                        }

                        //ApprovedCnd = Approve.ToString();
                        //if (ApprovedCnd != "")
                        //{
                        //    ApprovedCnd = ApprovedCnd.Substring(0, ApprovedCnd.Length - 1);
                        //    String[] strArr = ApprovedCnd.Split(',');
                        //    int count = 0;
                        //    for (int i = 0; i < strArr.Length; i++)
                        //    {
                        //        count++;
                        //    }
                        //    ApprovedCnd = Convert.ToString(count);
                        //}
                        //else
                        //{
                        //    ApprovedCnd = "0";
                        //}
                        RejectdCnd = Reject.ToString();
                        if (RejectdCnd != "")
                        {
                            RejectdCnd = RejectdCnd.Substring(0, RejectdCnd.Length - 1);
                            String[] strArr = RejectdCnd.Split(',');
                            int count = 0;
                            for (int i = 0; i < strArr.Length; i++)
                            {
                                count++;
                            }
                            RejectdCnd = Convert.ToString(count);
                        }
                        else
                        {
                            //RejectdCnd = "-";
                            RejectdCnd = "0";
                        }
                        lblmsg.Text = "Candidate Rejection done successfully";
                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Visible = false;
                        lbl3.Text = "Candidate Rejection done successfully.";
                        lbl4.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();//added by shreela on 09/06/2014 
                     
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                         ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                         mdlpopup.Show();


                        txtSurname.Text = "";
                        txtCandCode.Text = "";
                        txtDTRegFrom.Text = "";
                        txtDTRegTo.Text = "";
                        txtGivenName.Text = "";
                        ProgressBarModalPopupExtender.Hide();//to hide progressbar after submit
                        BindDataGrid();
                    }
                    catch (Exception ex)
                    {
                        //tn.Rollback();
                        lblmsg.Visible = true;
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
        string ModuleId = Request.QueryString["ModuleID"].ToString().Trim();
        Response.Redirect("CndRejection.aspx?ModuleId="+ModuleId);
    }
    #endregion

    protected void ddlShwRecrds_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Request.QueryString["Type"].ToString().Trim() != "ReExam")
        //{
        //    if (ddlShwRecrds.SelectedValue != null || ddlShwRecrds.SelectedValue != "")
        //    {
        //        BindDataGrid();
        //    }
        //}
    }

    #region OnRowDataBound Method
    //Method to show for larger text in grid as substring
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string str = ".....";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNamePronoun = (Label)e.Row.FindControl("lblNamePronoun");
            Label lbSurname = (Label)e.Row.FindControl("lbSurname");
            Label lblCndStatus = (Label)e.Row.FindControl("lblCndStatus");

            LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
            lbCndNo.Enabled = false;
            if (lblNamePronoun.Text != null && lblNamePronoun.Text != "")
            {
                if (lblNamePronoun.Text.Length > 20)
                {
                    lblNamePronoun.Text = lblNamePronoun.Text.Substring(0, 18) + str;
                }
            }
            if (lblSurname.Text != null && lblSurname.Text != "")
            {
                if (lblSurname.Text.Length > 20)
                {
                    lbSurname.Text = lbSurname.Text.Substring(0, 18) + str;
                }
            }
            if (lblCndStatus.Text != null && lblCndStatus.Text != "")
            {
                if (lblCndStatus.Text.Length > 30)
                {
                    lblCndStatus.Text = lblCndStatus.Text.Substring(0, 30) + str;
                }
            }
        }
    }
    #endregion

    #region rbrapprove_CheckedChanged
    //method to show candidate approve message in the textbox on checking the radio button
    //protected void rbrapprove_CheckedChanged(object sender, EventArgs e)
    //{
    //    GridViewRow grd = ((RadioButton)sender).NamingContainer as GridViewRow;
    //    RadioButton Rbapp = (RadioButton)grd.FindControl("rbrapprove");
    //    TextBox remarks = (TextBox)grd.FindControl("txtRemarks");
    //    //RadioButton Rbrej = (RadioButton)grd.FindControl("rbrreject");
    //    if (Rbapp.Checked == true)
    //    {
    //        remarks.Text = "Candidate Approved";
    //    }

    //}
    #endregion

    #region rbrreject_CheckedChanged
    //method to show candidate reject message in the textbox on checking the radio button
    protected void rbrreject_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow grd = ((CheckBox)sender).NamingContainer as GridViewRow;
        CheckBox Rbrej = (CheckBox)grd.FindControl("rbrreject");
        TextBox remarks = (TextBox)grd.FindControl("txtRemarks");

        if (Rbrej.Checked == true)
        {
            remarks.Text = "Candidate Rejected";
        }
        else
        {
            remarks.Text = "";
        }
    }
    #endregion


    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
            BindDataGrid();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) -1);
           // btnprevious.Enabled = true;
            int page = dgDetails.PageCount;
            //if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                int intPageIndex = dgDetails.PageIndex - 1;
                lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
            }
        }
        //{
        //    int pageIndex = dgDetails.PageIndex;
        //    dgDetails.PageIndex = pageIndex - 1;
        //    BindDataGrid();
        //    //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
        //    if (txtPage.Text == "1")
        //    {
        //        btnprevious.Enabled = false;
        //    }
        //    else
        //    {
        //        btnprevious.Enabled = true;
        //    }
        //    btnnext.Enabled = true;
        //}
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

    //protected void dgDetails_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}

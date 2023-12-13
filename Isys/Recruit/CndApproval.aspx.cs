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
    
    
    public partial class Application_Recruit_PrsptSearch : BaseClass
    {

        #region Page Declaration
    private multilingualManager olng;
    private const string Conn_Direct = "DefaultConn";
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessclass = new DataAccessClass();
    //private DataAccessLayer dataAccess = new DataAccessLayer();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    Hashtable htParams = new Hashtable();
        
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
            olng = new multilingualManager("DefaultConn", "CndApproval.aspx", Session["UserLangNum"].ToString());
            InitializeControl();

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
                // oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds);
                FillNoOfRecDropDown(ddlShwRecrds); //added by pallavi on 01042023 
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
                if (ViewState["userrollcode"].ToString() != "SALESTEAM")
                {
                    btnSubmit.Attributes.Add("onclick", "Javascript:return ValidationConfirm();");//Added by Nikhil on 08062015
                }
             

                else
                {
                   // trCodedlicdetails.Visible = true;

                }

                if (Request.QueryString["Type"].ToString().Trim() == "Recp")
                {

                    lbltitle.Text = " Candidate Receipt Search";
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
    //added by pallavi on 01042023 start
    #region METHOD TO FILL NO OF RECORDS DROPDOWN
    public void FillNoOfRecDropDown(System.Web.UI.WebControls.DropDownList drpList)
    {
        drpList.Items.Insert(0, new ListItem("Select", "Select"));
        drpList.Items.Insert(1, new ListItem("10", "10"));
        drpList.Items.Insert(2, new ListItem("25", "25"));
        drpList.Items.Insert(3, new ListItem("40", "40"));
    }
    #endregion
    //added by pallavi on 01042023 start
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
            //txtDTRegFrom.Attributes.Add("readonly", "readonly");
            //txtDTRegTo.Attributes.Add("readonly", "readonly");
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
            lblApplicationNo.Text = olng.GetItemDesc("lblApplicationNo.Text");//added by pranjali on 20-03-2014 
            lbltitle.Text = olng.GetItemDesc("lbltitle.Text");
            lblCandID.Text = olng.GetItemDesc("lblCandID.Text");
            lblGivenName.Text = olng.GetItemDesc("lblGivenName.Text");
            lblSurname.Text = olng.GetItemDesc("lblSurName.Text");
            //lblDTRegFrom.Text = olng.GetItemDesc("lblDTRegFrom.Text");
            //lblDTRegTO.Text = olng.GetItemDesc("lblDTRegTO.Text");
            lblShwRecords.Text = olng.GetItemDesc("lblShwRecords.Text");
            lblMessage.Text = olng.GetItemDesc("lblMessage.Text");
            lblPan.Text = (olng.GetItemDesc("lblPan.Text"));//added by Shreela on 10042014


            if (Request.QueryString["Pg"].ToString() == "NOCApproval" )
            {
                lblDTRegFrom.Text = "Request Date From";
                lblDTRegTO.Text = "Request Date To";
            }
            else
            {
                lblDTRegFrom.Text = "Request Date From";
                lblDTRegTO.Text = "Request Date To";
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
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
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
                //pnl.Visible = false;
                //return;
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
           // pnl.Visible = true;
            if (ddlShwRecrds.SelectedValue == "Select")// .ToString().Trim()

            {

            }
            else
            {
                dgDetails.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue);
            }
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
            htParam.Add("@Appno", txtAppNo.Text.Trim());//added by pranjali on 20-03-2014 
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
            //htParam.Add("@UserType", Session["UnitRank"].ToString().Trim());
            //htParam.Add("@UserAuthCode", Session["UnitCode"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            //Added by usha 



            if (Request.QueryString["PG"].ToString().Trim() == "NOCApproval")//Added by usha  on 27.12.2018
            {

                //Comented by usha  as for RM user can approve NOC   on 27.12.2018
                //if (ViewState["userrollcode"].ToString() == "SALESTEAM" || ViewState["userrollcode"].ToString() == "LICTEAM")
                //{

                htParam.Add("@AgentBrokerCode", txtAgntBroker.Text.ToString().Trim());
                htParam.Add("@AgentSapCode", txtSapCode.Text.ToString().Trim());
                htParam.Add("@Page", "CndSaleApr");
                htParam.Add("@Flag", "1");
                htParam.Add("@chncls", ViewState["ChnCls"].ToString().Trim());// Added by usha  for sales team access provide to respactive market on 26.12.2018
                htParam.Add("@UserID", Session["UserID"].ToString()); // Added by usha  for sales team access provide to respactive market on 05.04.2022
                htParam.Add("@AgtType", Request.QueryString["AgtType"].ToString().Trim());//added by usha 26122022
            }
            else if (Request.QueryString["PG"].ToString().Trim() == "CndChnlApproval")//Added by sanoj  on 08092023
            {
                htParam.Add("@Page", "CndChnlApr");
            }
            else
            {
                htParam.Add("@Page", "CndApr");

            }
            //Added by sanoj  on 08/09/2023
            if (Request.QueryString["PG"].ToString().Trim()== "CndChnlApproval")
            {
                htParam.Add("@MemberCode", ViewState["MemberCode"].ToString());
                htParam.Add("@MemberType", ViewState["MemberType"].ToString());
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_CandListForChnlApproval", htParam);
            }
            //Endde by sanoj  on 08/09/2023
            else if (Request.QueryString["PG"].ToString().Trim() != "NOCApproval")//Added by usha  on 27.12.2018
            {
                if (ViewState["UserType"].ToString() == "I")
                {
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

            else
            {
                
                dsResult.Clear();
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApprovalForExtrnl", htParam);
            }
            //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            //dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CandAdmin_EnqCandListForApproval", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
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
                    if (Request.QueryString["PG"].ToString().Trim() == "NOCApproval")//Added by usha  on 27.12.2018
                    {

                        //Comented by usha  as for RM user can approve NOC   on 27.12.2018
                        //if (ViewState["userrollcode"].ToString() == "SALESTEAM" || ViewState["userrollcode"].ToString() == "LICTEAM")
                        //{
                        dgDetails.Columns[9].Visible = true;
                        chkrcvd.Visible = false;//Added by Nikhil on 08062015
                        lblconfirm.Visible = false;
                        dgDetails.Columns[5].Visible = true;
                        dgDetails.Columns[6].Visible = true;
                        dgDetails.Columns[7].Visible = true;
                        dgDetails.Columns[9].Visible = true;
                        dgDetails.HeaderRow.Cells[8].Text = "Submission Date";
                        dgDetails.HeaderRow.Cells[4].Text = "Reporting SM Name";

                    }
                    else
                    {
                        dgDetails.Columns[17].Visible = false;
                        chkrcvd.Visible = true;//Added by Nikhil on 08062015
                        lblconfirm.Visible = true;
                    }
                    trnote.Visible = true;
                   // tr4.Visible = true;

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
    private void BindGridControl( GridView objDatagrid)
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
        //txtSapCode.Text = "";
        //txtAgntBroker.Text = "";
        //if (Request.QueryString["PG"].ToString().Trim() == "NOCApproval")
        //{
        //    Response.Redirect("CndApproval.aspx?Pg=NOCApproval" + "ModuleID=" + Request.QueryString["ModuleID"].ToString().Trim());

        //} //Added by Pallavi  on 22.02.2023

        //Response.Redirect("CndApproval.aspx?Type=BMSalesApp");

		Server.Transfer(Request.Url.AbsolutePath);  //Added by Abuzar  on 04.05.2023
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
            //Added by Nikhil on 08062015           
           if (ViewState["userrollcode"].ToString() != "SALESTEAM" &&  chkrcvd.Checked == false)
            {
                ProgressBarModalPopupExtender.Hide();

                ////return;
            }
            else
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
                        //objCom.Parameters.AddWithValue("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                        objCom.CommandText = "prc_UpdateCandidateapproval";// "prc_UpdateCandidateapproval";
                        SqlTransaction tn;
                        objCon.Open();
                        //tn = objCon.BeginTransaction();
                        //objCom.Transaction = tn;


                        try
                        {
                            string App_Prospect = "";
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
                                HtmlInputHidden hdnVar = (HtmlInputHidden)row.FindControl("hdntxtVarify");
                                PrID = lbapprove.Text.ToString();
                                HtmlInputHidden hdnPmt = (HtmlInputHidden)row.FindControl("hdnPmtMode");
                                hdnPmt.Attributes.Add("ID", "hdnPmtMode" + PrID);
                                GridViewRow gvRow = (GridViewRow)hdnPmt.NamingContainer;

                                //Added By Ibrahim on 8-05-2013 text find the control in gridview  linkbutton
                                LinkButton lkbtn = (LinkButton)gvRow.FindControl("lbCndNo");
                                //string str = gvRow.Cells[10].Text;
                                string str = "";
                                sremarks = txtRemarks.Text.Trim();
                                if (Rbapp.Checked == true && hdnVar.Value == "Done")
                                {
                                    if (ViewState["userrollcode"].ToString() == "SALESTEAM")
                                    {
                                        App_Prospect = "50";
                                    }
                                    else
                                    {
                                                                           //added by amruta on 24.8.15 start
                                    GetCandidateDtls(lbapprove.Text);
                                    
                                    if ( ViewState["AutoWavierFlag"].ToString()=="Y")
                                    {
                                         App_Prospect = "50";
                                    }
                                    else
                                    {
                                        if (ViewState["CandType"].ToString() == "T" || ViewState["CandType"].ToString() == "G")
                                        {
                                            App_Prospect = "50";
                                        }
                                        else
                                        {
                                            App_Prospect = "50";//"40";
                                        }

                                    }
                                    //added by amruta on 24.8.15 end
                                    }
                                    strAppRej_Flag = "0";
                                    strAppRej_FlagDesc = "BM Approval";
                                    TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                    sremarks = remarks.Text.Trim();
                                    htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                    //Added by Swapnesh on 15/5/2013 for trimming value of parameter start
                                    htable.Add("@CndNo", PrID.Trim());
                                    //Added by Swapnesh on 15/5/2013 for trimming value of parameter end
                                    htable.Add("@CndStatus", App_Prospect);
                                    htable.Add("@CndAppRej_Flag", strAppRej_Flag);//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate App
                                    htable.Add("@Reason", strAppRej_FlagDesc);
                                    htable.Add("@confirm", "Yes");//Addded by Nikhil on 08.06.2015
                                    htable.Add("@Remarks", sremarks);
                                    htable.Add("@Stage", "PA1");
                                    htable.Add("@UpdateBy", Session["UserID"].ToString());
                                    htable.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
                                    objCom.Parameters.Clear();
                                    foreach (DictionaryEntry dist in htable)
                                    {
                                        objCom.Parameters.AddWithValue((string)dist.Key, dist.Value);
                                    }

                                    int ret = objCom.ExecuteNonQuery();
                                    Approve.Append(lbapprove.Text.Trim());
                                    Approve.Append(",");
                                    htable.Clear();
                                    ViewState["App_Prospect"] = App_Prospect;
                                    ViewState["AppNo"] = lblappno.Text;
                                    //MailResponse(PrID);//mail communication

                                }
                                else
                                {
                                    if (Rbapp.Checked == false && Rbrej.Checked == false && hdnVar.Value.Trim() == "NotDone")
                                    {
                                        alert.InnerHtml = "<script language =javascript> alert('Please approve atleast one candidate')</script>";
                                    }
                                    else if (str == "DC" && hdnVar.Value.Trim() == "NotDone")
                                    {
                                        alert.InnerHtml = "<script language =javascript> alert('Please verify bank details and then Proceed with Client and Agent Creation')</script>";
                                    }
                                }

                                if (Rbrej.Checked == true)
                                {
                                    //App_Prospect = "20";// Candidiate Rejected
                                    //strAppRej_Flag = "1";
                                    if (ViewState["userrollcode"].ToString() == "SALESTEAM")
                                    {


                                      // added by usha 
                                        if (sremarks == "")
                                        {
                                            ProgressBarModalPopupExtender.Hide();
                                            //alert.InnerHtml = "<script language =javascript> alert('Please approve atleast one candidate')</script>";
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter remark for Reject NOC Candidate')", true);
                                            return;
                                        }
                                    }
                                  if (ViewState["userrollcode"].ToString() == "SALESTEAM")
                                    {



                                        App_Prospect = "170";// Candidiate Rejected
                                        strAppRej_FlagDesc = "NOC Rejection";
                                    }
                                    else {
                                        App_Prospect = "180";// Candidiate Rejected
                                        strAppRej_FlagDesc = "BM Rejection";

                                    }
                                    
                                    strAppRej_Flag = "1";
                                    //strAppRej_FlagDesc = "BM Rejection";

                                  //  TextBox remarks = (TextBox)row.FindControl("txtRemarks");
                                    //sremarks = remarks.Text.Trim();
                                    htable.Add("@CarrierCode", Session["CarrierCode"].ToString());
                                    htable.Add("@CndNo", PrID.Trim());
                                    htable.Add("@CndStatus", App_Prospect);
                                    htable.Add("@CndAppRej_Flag", strAppRej_Flag);//Added by rachana on 27-11-2013 to insert CndAppRej_Flag in Cnd table for candidate Rej
                                    htable.Add("@Reason", strAppRej_FlagDesc);
                                    htable.Add("@confirm", "Yes");//Addded by Nikhil on 08.06.2015
                                    htable.Add("@Remarks", sremarks);
                                    htable.Add("@Stage", "PA1");
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
                                    //MailResponse(PrID);

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
                               div2.Visible = false;
                                //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                                //alert.InnerHtml = "";
                                //MailResponse(PrID);
                                //lbl3.Text = "Candidate NOC approved/rejected successfully";
                                //lbl2.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                //lbl4.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();

                                lblus.Text = "Candidate approved/rejected successfully<br/><br/>" + "Total Approved Candidates: " + " " + ApprovedCnd.ToString() + "<br/>Total Rejected Candidates:" + " " + RejectdCnd.ToString();
                            }
                            else
                            {

                                lblmsg.Text = "Candidate approved/rejected successfully";
                                lblmsg.ForeColor = Color.Red;
                               div2.Visible = false;
                                //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format start
                                //alert.InnerHtml = "";
                                //MailResponse(PrID);
                                //lbl3.Text = "Candidate approved/rejected successfully";
                                //lbl2.Text = "Total Approved Candidates :" + " " + ApprovedCnd.ToString();//added by shreela on 09/06/2014 
                                //lbl4.Text = "Total Rejected Candidates :" + " " + RejectdCnd.ToString();

                                lblus.Text = "Candidate approved/rejected successfully<br/><br/>" + "Total Approved Candidates: " + " " + ApprovedCnd.ToString() + "<br/>Total Rejected Candidates:" + " " + RejectdCnd.ToString();
                            }//added by shreela on 09/06/2014 
                           // mdlpopup.Show();
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup1();", true);
                            //Added By Ibrahim on 08/05/2013 to dispaly message in pop up format End 
                            //txtAppNo.Text = "";////Commented by kalyani on 24-12-2013 as not required 
                            txtSurname.Text = "";
                            txtCandCode.Text = "";
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
                           //div2.Visible = true;
                            //lblmsg.Text = ex.Message;
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

        #region Button 'Cancel Click Event'
    protected void btnCancel_Click(object sender, EventArgs e)
    {
      //Response.Redirect("CndApproval.aspx");
      // string ModuleID= Request.QueryString["ModuleID"].ToString().Trim();

        Response.Redirect("CndApproval.aspx?Pg=NOCApproval" + "&ModuleID=" + Request.QueryString["ModuleID"].ToString().Trim() );
        //added by pallavi on 22022023

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
        else if (e.CommandName == "Receiptclick")
        {
            string cndno = e.CommandArgument.ToString().Trim();

            Response.Redirect("Receiptmodule.aspx?CndNo=" + cndno + "&Type=Recp");
           // Response.Redirect("CropImage.aspx?CndNo= " + lblCndNoValue.Text + "");

        }
        //Receiptclick
      

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
            if (lblNamePronoun.Text != null && lblNamePronoun.Text != "")
            {
                if (lblNamePronoun.Text.Length > 20)
                {
                    lblNamePronoun.Text = lblNamePronoun.Text.Substring(0, 18) + str;
                }
            }
            //Added by Rachana on 13/05/2013 for solving error "index and length must refer to a location within the string" End
            if (lblSurname.Text != null && lblSurname.Text != "")
            {
                if (lblSurname.Text.Length > 20)
                {
                    lbSurname.Text = lbSurname.Text.Substring(0, 18) + str;
                }
            }
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
            //Added by Sanoj sahani 08092023
            if (Request.QueryString["PG"].ToString().Trim() != "CndChnlApproval")
            {
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[17].Visible = false;
                dgDetails.HeaderRow.Cells[10].Visible = false;
                dgDetails.HeaderRow.Cells[11].Visible = false;
                dgDetails.HeaderRow.Cells[12].Visible = false;
                dgDetails.HeaderRow.Cells[13].Visible = false;
            }
            //Endded by Sanoj sahani 08092023

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
            if (ViewState["userrollcode"].ToString() == "SALESTEAM")
            {
                remarks.Text = "Candidate NOC Approved";
            }
            else
            {
                remarks.Text = "Candidate Approved";
            }

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
                if (ViewState["userrollcode"].ToString() == "SALESTEAM")
                {
                    remarks.Text = " ";
                }
                else
                {
                    remarks.Text = "Candidate Rejected";
                }
               
               
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


    protected void btnok1_Click(object sender, EventArgs e)
    {
        //added by sanoj 11092023
        if (Request.QueryString["PG"].ToString().Trim() == "CndChnlApproval")
        {
            Response.Redirect("CndApproval.aspx?Pg=CndChnlApproval" + "&ModuleID=" + Request.QueryString["ModuleID"].ToString().Trim());
        }
        //Endded by sanoj 11092023
        else
        {
            Response.Redirect("CndApproval.aspx?Pg=NOCApproval" + "&ModuleID=" + Request.QueryString["ModuleID"].ToString().Trim());
        }

    }
}

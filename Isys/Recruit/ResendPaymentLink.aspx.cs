using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Insc.Common.Multilingual;
using CLTMGR;
using DataAccessClassDAL;
using System.Text;
using System.Drawing;
using MCPG.ASP.net.ENC;
using PGBitLyURL;
using System.Net.Mail;
using System.Net;

public partial class Application_Isys_Recruit_ResendPaymentLink : BaseClass
{
    #region declaration
    private multilingualManager olng;
    Hashtable htParam = new Hashtable();
    Hashtable htParamToken = new Hashtable();

    ErrLog objErr = new ErrLog();
    RCFEncryption Encript = new RCFEncryption();
    public const string CONN_Recruit = "INSCRecruitConnectionString";
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    DataSet dsResult = new DataSet();
    DataSet dsToken = new DataSet();
    Hashtable htable = new Hashtable();
    string PGURL = System.Configuration.ConfigurationManager.AppSettings["PGURL"].ToString();

    string Tokenno, Token;
    string URL;
    string bitlyURL;
    string Isresendflag;
    string JSonString = "";
    string AppLink = "", WebLink = "";
    string strUser = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "CndEnq.aspx", Session["UserLangNum"].ToString());
            InitializeControl();
            GetAgentandUserDtls();
            oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds);
            lbltitle.Text = "Candidate Resend Payment Link Search";
            Label1.Text = "Candidate Resend Payment Link  Search Results";
            if (!IsPostBack)
            {


            }
            txtDTRegFrom.Attributes.Add("readonly", "readonly");
            txtDTRegTo.Attributes.Add("readonly", "readonly");
            txtDTRegFrom.Attributes.Add("style", "background-color: white");
            txtDTRegTo.Attributes.Add("style", "background-color: white");

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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResendPaymentLink.aspx");

    }

    #region IntializeControl
    private void InitializeControl()
    {
        try
        {

            lblCandidateCode.Text = (olng.GetItemDesc("lblCandidateCode.Text"));
            lblApplicationNo.Text = (olng.GetItemDesc("lblApplicationNo.Text"));
            lblGivenName.Text = (olng.GetItemDesc("lblGivenName.Text"));
            lblSurName.Text = (olng.GetItemDesc("lblSurName.Text"));
            lblDTRegFrom.Text = (olng.GetItemDesc("lblDTRegFrom.Text"));
            lblDTRegTO.Text = (olng.GetItemDesc("lblDTRegTO.Text"));
            lblShwRecords.Text = (olng.GetItemDesc("lblShwRecords.Text"));
            lblMessage.Text = (olng.GetItemDesc("lblMessage.Text"));
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
    #region  PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            DataTable dt = BindDataGrid();
            DataView dv = new DataView(dt);
            GridView dgSource = (GridView)sender;

            dgDetails.PageIndex = e.NewPageIndex;
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgDetails.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgDetails.DataSource = dv;
            dgDetails.DataBind();
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
    protected DataTable BindDataGrid()
    {
        try
        {
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@LangCode", Session["UserLangNum"].ToString().Trim());
            htParam.Add("@UserType", ViewState["unitrank"].ToString().Trim());
            htParam.Add("@UserAuthCode", ViewState["unitcode"].ToString().Trim());
            htParam.Add("@Page", "CndRsndPytmLnk");
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));


            htParam.Add("@AppNo", txtApplicatoNo.Text.Trim());
            htParam.Add("@CndNo", txtCandCode.Text.Trim());
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

            dsResult.Clear();
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_CndListForResendPaymentLink", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    dgDetails.DataSource = dsResult.Tables[0];
                    dgDetails.DataBind();
                    //ShowPageInformation();

                    trDetails.Visible = true;
                    trDgDetails.Visible = true;

                    lblMessage.Visible = false;
                    lblMessage.Text = "";
                    //trnote.Visible = true;
                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    //lblPageInfo.Text = "";
                    trDetails.Visible = false;
                    trDgDetails.Visible = false;

                    lblMessage.Visible = true;
                    lblMessage.Text = "0 Record Found";

                    // trnote.Visible = false;
                }
            }

            if (dgDetails.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
                txtPage.Text = "1";
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
        }
        return dsResult.Tables[0];
    }
    #endregion
    #region Button 'Search Click Event'
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDTRegFrom.Text.ToString().Trim() != "" && txtDTRegTo.Text.ToString().Trim() != "")
            {
                if (Convert.ToDateTime(txtDTRegTo.Text) < Convert.ToDateTime(txtDTRegFrom.Text))
                {

                    lblMessage.Visible = true;
                    lblMessage.Text = "Registration Date From should be less than Registration Date To";
                    trDetails.Visible = false;
                    dgDetails.Visible = false;
                    return;
                }
            }
            if (txtPan.Text.ToString().Trim() != "")
            {
                if (txtPan.Text.Length < 5)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Minimum 5 characters required for PAN No')", true);
                    return;
                }
            }

            lbltitle.Text = "Candidate Resend Payment Link Search";
            Label1.Text = "Candidate Resend Payment Link  Search Results";


            BindDataGrid();


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


    #region GridView RowCommand
    protected void dgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            string cndno = e.CommandArgument.ToString().Trim();
            string Fees;
            string Appno;

            if (e.CommandName == "click")
            {
                // string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + cndno + "','width=1000,height=800');";


                //string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + cndno + "');";
                string strWindow = "window.open('CndView.aspx?Type=Pros&Act=NoEdit&CndNo=" + cndno + "','ViewCandDetails','width=910px,height=600px,resizable=0,left=190,scrollbars=1');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);
            }
            else if (e.CommandName == "Resendlink")
            {
                DataSet dsFees = new DataSet();
                DataSet ds = new DataSet();
                ds.Clear();
                htParam.Clear();

                htParam.Add("@Cndno", cndno);
                ds = dataAccess.GetDataSetForPrcRecruit("Prc_GetPytmlinkStatusForResendlink", htParam);
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (ds.Tables[1].Rows[0]["payInitiated"].ToString().Trim() == "Y" && ds.Tables[1].Rows[0]["payreconsield"].ToString().Trim() == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please wait as your fees payment confirmation is pending.')", true);
                            ProgressBarModalPopupExtender.Hide();
                            return;
                        }
                        else
                        {

                            Fees = Encript.Encrypt(ds.Tables[0].Rows[0]["TotalFees"].ToString().Trim());
                            Appno = Encript.Encrypt(cndno);


                            if (ds.Tables[1].Rows.Count != 0)
                            {
                                if (ds.Tables[1].Rows[0]["Status"].ToString().Trim() == "Active")
                                {
                                    Token = ds.Tables[0].Rows[0]["TokenNo"].ToString().Trim();

                                    URL = Encript.Encrypt(ds.Tables[0].Rows[0]["paymentURL"].ToString().Trim());
                                    bitlyURL = Encript.Encrypt(ds.Tables[0].Rows[0]["bitlyURL"].ToString().Trim());
                                    Isresendflag = "";
                                }
                                else
                                {

                                    htParamToken.Clear();
                                    htParamToken.Add("@CndNo", cndno);
                                    htParamToken.Add("@Appno", cndno);
                                    htParamToken.Add("@TotalFees", ds.Tables[0].Rows[0]["TotalFees"].ToString().Trim());
                                    htParamToken.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                                    Isresendflag = "Y";
                                    dsToken.Clear();

                                    dsToken = dataAccess.GetDataSetForPrcRecruit("Prc_GenerateTokenNo", htParamToken);
                                    Token = dsToken.Tables[0].Rows[0]["TokenNo"].ToString().Trim();
                                    Tokenno = Encript.Encrypt(dsToken.Tables[0].Rows[0]["TokenNo"].ToString().Trim());
                                    // URL = "https://220.226.201.244/PG1/dataFrom.aspx?Tokenno=" + System.Web.HttpUtility.UrlEncode(Tokenno) + "&Fees=" + System.Web.HttpUtility.UrlEncode(Fees) + "&Appno=" + System.Web.HttpUtility.UrlEncode(Appno);
                                    URL = PGURL + System.Web.HttpUtility.UrlEncode(Tokenno) + "&Fees=" + System.Web.HttpUtility.UrlEncode(Fees) + "&Appno=" + System.Web.HttpUtility.UrlEncode(Appno);

                                    PGBitLyURL.BitlyURLClient a = new BitlyURLClient();
                                    bitlyURL = a.GetShortURL(URL, "ProposalNo", "12345", ds.Tables[0].Rows[0]["MobileTel"].ToString().Trim());

                                }
                            }
                        }
                    }
                }


                htParam.Clear();
                htParam.Add("@TokenNo", Token);
                htParam.Add("@Appno", ds.Tables[0].Rows[0]["AppNo"].ToString());
                htParam.Add("@URL", URL.ToString());
                htParam.Add("@BitlyURL", bitlyURL.ToString());
                htParam.Add("@ActiveFlag", ds.Tables[1].Rows[0]["Status"].ToString().Trim());
                htParam.Add("@IsResend", Isresendflag);
                htParam.Add("@MailTempFlag", "ReSend");//added by ashishp
                                                       // htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
                dsFees.Clear();
                dsFees = dataAccess.GetDataSetForPrcRecruit("Prc_UpdCndTokenPaymentLink", htParam);


                hdnUpdate.Value = "Fees payment link send successfully";
                lbl.Text = hdnUpdate.Value + "</br><br/>Candidate Name: " + ds.Tables[0].Rows[0]["AppNo"].ToString() + "<br/>Token No: " + Token +
                                        "<br/><br/>Note:- Kindly Do Payment on Given Token No";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
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
    #region 'ddlShwRecrds_SelectedIndexChanged'
    protected void ddlShwRecrds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShwRecrds.SelectedValue != null || ddlShwRecrds.SelectedValue != "")
        {
            BindDataGrid();
        }
    }
    #endregion
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbCndNo = (LinkButton)e.Row.FindControl("lbCndNo");
                lbCndNo.Enabled = false;
                LinkButton lbProsID = (LinkButton)e.Row.FindControl("lbProsID");
                lbProsID.Enabled = false;
                LinkButton lnkview = (LinkButton)e.Row.FindControl("lnkCndNo_view");
                Label lblCndStatus = (Label)e.Row.FindControl("lblCndStatus");
                LinkButton lnkbtnOtplnk = (LinkButton)e.Row.FindControl("lnkbtnOtplnk");
                LinkButton lnkResendLink = (LinkButton)e.Row.FindControl("lnkResendLink");

                if (lblCndStatus.Text != null)
                {
                    if (lblCndStatus.Text.Trim() == "Pending for OTP Verification")
                    {
                        lnkbtnOtplnk.Enabled = true;
                        lnkResendLink.Enabled = false;
                    }
                    else
                    {
                        lnkbtnOtplnk.Enabled = false;
                        lnkResendLink.Enabled = true;
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



    protected void lnkbtnOtplnk_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbProsID = (LinkButton)row.FindControl("lbProsID");
        ShareLink("10028898");
        
    }
            

    protected void lnkResendLink_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lbProsID = (LinkButton)row.FindControl("lbProsID");

        htParam.Add("@AppNo", lbProsID.Text.Trim());
        dsResult = dataAccess.GetDataSetForPrcDBConn("Prc_OnboradingPaymentForARTL", htParam, "INSCCOMMONConnectionChmsTemp");
        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                if(dsResult.Tables[0].Rows[0]["ResponseCode"].ToString().Trim() == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment link send successfully.')", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment link not send.')", true);
                    return;
                }
                
            }
        }

    }

    public string ShareLink(string strAppNo)
    {
        try
        {

            string Email = string.Empty;
            string MobileNo = string.Empty;
            string OTP = string.Empty;
            dsResult.Clear();
            htParam.Clear();
            htParam.Add("@AppNo", strAppNo);
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_GetEmlMobForCndt", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    Email = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                }
            }
            DataSet objDaset = new DataSet();
           Hashtable  htable = new Hashtable();
            htable.Add("@AppNo", strAppNo);
            objDaset = dataAccess.GetDataSetForPrcDBConn("Prc_GetDetailsForURL", htable, "INSCRecruitConnectionString");
            if (objDaset.Tables.Count > 0 && objDaset.Tables[0].Rows.Count > 0)
            {
                MailMessage mm = new MailMessage("lpi_india@krishmark.com", Email);
                mm.Subject = "Validate OTP";
                mm.Body = string.Format("Hi {0},<br /><br />Please complete your registration by entering the OTP {1}.<br />Please do not reply to this email<br /><br />Thank You.",
                    "Candidate", objDaset.Tables[0].Rows[0]["webLink"].ToString().Trim());
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "lpi_india@krishmark.com";
                NetworkCred.Password = "kmi@1234$";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Web link and app link send successfully.')", true);
            }
        }
        catch (Exception e)
        {
            JSonString = "{\"Table\": [ {\"ResponseCode\": \"2\",\"ErrorDescription\":\"" + e.Message.ToString() + "\"}]}";
        }

        return JSonString;
    }
}
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
using INSCL;
using INSCL.DAL;
using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.MQ.Life.AgnCr;
using Insc.Common.Multilingual;
using Insc.MQ.Life.AgnInwMd;
using Insc.MQ.Life.AgnInwCr;
using System.Text.RegularExpressions;
using DataAccessClassDAL;

public partial class Application_INSC_Recruit_FrmPreffExmDtls : BaseClass
{
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    private DataAccessClass dataAccess = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    private multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
                {
                    Response.Redirect("~/ErrorSession.aspx");
                }


                olng = new multilingualManager("DefaultConn", "FrmPreffExmDtls.aspx", Session["UserLangNum"].ToString());
                Session["CarrierCode"] = '2';
                InitializeControl();
                viewData(Request.QueryString["CndNo"].ToString().Trim());
                PopulateExamMode();//added by pranjali on 10-04-2014 for binding exam mode
                PopulatePreExmLanguages(); //added by pranjali on 10-04-2014 for exam languages
                PopulateExmBodyName(); //added by pranjali on 10-04-2014 for binding exambody name
                PopulateExmCentre();//added by pranjali on 10-04-2014 for binding examcentre
            }
            btnSubmit.Attributes.Add("onClick", "javascript: return funValidate();");
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

    private void InitializeControl()
    {
        try
        {
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            lblCndName.Text = olng.GetItemDesc("lblCndName");
            lblSMName.Text = olng.GetItemDesc("lblSMName");
            lblBranch.Text = olng.GetItemDesc("lblBranch");
            lblPAN.Text = olng.GetItemDesc("lblPAN");
            lblMobileNo.Text = olng.GetItemDesc("lblMobileNo");
            lblEmail.Text = olng.GetItemDesc("lblEmail");
            lblTrnInstitute.Text = olng.GetItemDesc("lblTrnInstitute");
            lblTrnLoc.Text = olng.GetItemDesc("lblTrnLoc");
            lblTrnMode.Text = olng.GetItemDesc("lblTrnMode");
            lblExmDt.Text = olng.GetItemDesc("lblExmDt");
            lblExammode.Text = olng.GetItemDesc("lblExammode"); //added by pranjali on 11-04-2014
            lblExmBody.Text = olng.GetItemDesc("lblExmBody"); //added by pranjali on 11-04-2014
            lblpreexamlng.Text = olng.GetItemDesc("lblpreexamlng"); //added by pranjali on 11-04-2014
            lblCentre.Text = olng.GetItemDesc("lblCentre"); //added by pranjali on 11-04-2014
            lblExammode1.Text = olng.GetItemDesc("lblExammode1"); //added by pranjali on 11-04-2014
            lblExmBody1.Text = olng.GetItemDesc("lblExmBody1"); //added by pranjali on 11-04-2014
            lblpreexamlng1.Text = olng.GetItemDesc("lblpreexamlng1"); //added by pranjali on 11-04-2014
            lblCentre1.Text = olng.GetItemDesc("lblCentre1"); //added by pranjali on 11-04-2014
            LblExam.Text = olng.GetItemDesc("LblExam"); //added by pranjali on 11-04-2014
            lblprefexmschdl.Text = olng.GetItemDesc("lblprefexmschdl"); //added by pranjali on 11-04-2014
            lblTitle.Text = olng.GetItemDesc("lblprefexmschdl"); //added by pranjali on 11-04-2014
            lblTrnDtl.Text = olng.GetItemDesc("lblprefexmschdl"); //added by pranjali on 11-04-2014
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
    //added by pranjali on 10-04-2014 for exam mode start
    #region Exam Mode
    private void PopulateExamMode()
    {
        try
        {

            oCommon.getDropDown(ddlExam, "ExmMode", 1, "", 1);
            ddlExam.Items.Insert(0, "--Select--");
            //ddlTrnLoc.Items.Insert(0, "--Select--");
            //ddlTrnInstitute.Items.Insert(0, "--Select--");
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
    //added by pranjali on 10-04-2014 for exam mode end

    //added by pranjali on 10-04-2014 for ExmLanguages start
    #region PopulatePreExmLanguages()
    private void PopulatePreExmLanguages()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccess.GetDataSetForPrc1("Prc_GetExmLang");
            ddlpreeamlng.DataSource = dsresult;
            ddlpreeamlng.DataTextField = "Language";
            ddlpreeamlng.DataValueField = "Language";
            ddlpreeamlng.DataBind();
            ddlpreeamlng.Items.Insert(0, "--Select--");
            dsresult = null;
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
    //added by pranjali on 10-04-2014 for ExmLanguages end

    //added by pranjali on 10-04-2014 for ExmBodyName start
    #region PopulateExmBodyName()
    private void PopulateExmBodyName()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccess.GetDataSetForPrc1("Prc_GetExmBody");
            ddlExmBody.DataSource = dsresult;
            ddlExmBody.DataTextField = "ExmBody";
            ddlExmBody.DataValueField = "ExmBody";
            ddlExmBody.DataBind();
            ddlExmBody.Items.Insert(0, "--Select--");
            dsresult = null;
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
    //added by pranjali on 10-04-2014 for ExmBodyName end

    //added by pranjali on 10-04-2014 for Exmcentre start
    #region PopulateExmCentre()
    private void PopulateExmCentre()
    {
        try
        {
            DataSet dsresult = new DataSet();
            dsresult = dataAccess.GetDataSetForPrc1("Prc_GetExmCenter");
            ddlExmCentre.DataSource = dsresult;
            ddlExmCentre.DataTextField = "ExmCenter";
            ddlExmCentre.DataValueField = "ExmCenter";
            ddlExmCentre.DataBind();
            ddlExmCentre.Items.Insert(0, "--Select--");
            dsresult = null;
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
    //added by pranjali on 10-04-2014 for Exmcentre end
    protected void viewData(string strCndNo)
    {
        htParam.Clear();
        htParam.Add("@CndNo", strCndNo);
        try
        {
            dsResult = dataAccess.GetDataSetForPrcRecruit("Prc_GetPreffExmDtls", htParam);
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString().Trim();
                        lblAppNoValue.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString().Trim();
                        lblCndNameValue.Text = dsResult.Tables[0].Rows[0]["CndName"].ToString().Trim();
                        lblSMNameValue.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString().Trim();
                        string branch = Convert.ToString(dsResult.Tables[0].Rows[0]["Branch"]).Trim();
                        string cmsunitcode = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]).Trim();
                        lblBranchValue.Text = branch + " " + "(" + cmsunitcode + ")";
                        lblPANValue.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString().Trim();
                        lblMobileValue.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString().Trim();
                        lblEmailValue.Text = dsResult.Tables[0].Rows[0]["Email"].ToString().Trim();
                        lblTrnInstituteValue.Text = dsResult.Tables[0].Rows[0]["TrnInstDesc01"].ToString().Trim();
                        lblTrnLocValue.Text = dsResult.Tables[0].Rows[0]["TrnLocDesc"].ToString().Trim();
                        lblTrnModeValue.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString().Trim();
                        lblExmDtValue.Text = dsResult.Tables[0].Rows[0]["ExmDate"].ToString().Trim();//added by pranjali on 12-03-2014
                        //added by pranjali on 11-04-2014 start
                        ddlExam.SelectedValue = dsResult.Tables[0].Rows[0]["ExmMode"].ToString().Trim();
                        ddlExam.Enabled = false;
                        ddlExmBody.SelectedValue = dsResult.Tables[0].Rows[0]["ExmBody"].ToString().Trim();
                        ddlExmBody.Enabled = false;
                        ddlpreeamlng.SelectedValue = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString().Trim();
                        ddlpreeamlng.Enabled = false;
                        ddlExmCentre.SelectedValue = dsResult.Tables[0].Rows[0]["ExmCentre"].ToString().Trim();
                        ddlExmCentre.Enabled = false;
                        //added by pranjali on 11-04-2014 end
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string sessionuser = string.Empty;
            if (HttpContext.Current.Session["UserID"] != null)
            {
                sessionuser = HttpContext.Current.Session["UserID"].ToString();
            }
            int x = 0;
            //htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@AppNo", lblAppNoValue.Text);
            if (txtExmdt1.Text.Trim() != "")
            {
                htParam.Add("@PreffExmDt1", DateTime.Parse(txtExmdt1.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@PreffExmDt1 ", System.DBNull.Value);
            }
            if (txtExmdt2.Text.Trim() != "")
            {
                htParam.Add("@PreffExmDt2", DateTime.Parse(txtExmdt2.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@PreffExmDt2 ", System.DBNull.Value);
            }
            htParam.Add("@ExmDtApprvr", sessionuser);
            //added by pranjali on 11-04-2014 start
            htParam.Add("@ExamMode", ddlExam.SelectedValue.ToString().Trim());
            htParam.Add("@ExmBody", ddlExmBody.SelectedValue.ToString().Trim());
            htParam.Add("@ExmLang", ddlpreeamlng.SelectedValue.ToString().Trim());
            htParam.Add("@ExmCentre", ddlExmCentre.SelectedValue.ToString().Trim());
            //added by pranjali on 11-04-2014 end
            x = dataAccess.execute_sprcrecruit("Prc_UpdPreffExmDtls", htParam);
            btnSubmit.Enabled = false;
            lbl_popup.Text = "Preffered Date updated successfully." + "</br></br>Application No: " + lblAppNoValue.Text + "</br> Candidate Name: " + lblCndNameValue.Text;
            mdlpopup.Show();
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

    }
}
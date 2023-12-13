#region Namespace
using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using INSCL.DAL;
using System.Text;
using System.Web.UI.HtmlControls;
#endregion

public partial class Application_ISys_ChannelMgmt_AgtInfoEducation : BaseClass
{
    #region Declaration
    CommonFunc oCommon = new CommonFunc();
    INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    DataAccessClass objDAL = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    ErrLog objErr = new ErrLog();
    private string strUserLang;
    private multilingualManager olng;
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
            if (HttpContext.Current.Session["UserLangNum"] != "")
            {
                strUserLang = Convert.ToString(HttpContext.Current.Session["UserLangNum"]).Trim();
            }
            olng = new multilingualManager("DefaultConn", "AGTInfo.aspx", strUserLang);

            if (!IsPostBack)
            {
                ViewState["vwsAgntCode"] = Request.QueryString["AgnCd"].ToString().Trim();
                //lnkPage2.Enabled = false;
                lnkEducation.CssClass = "btn-subtab btn btn-default";
                InitializeControl();
                FillRequiredDtls();


                btnUpdate.Attributes.Add("onClick", "javascript: return funValidate()");
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
        try
        {
            lblVw2AgntInfo.Text = olng.GetItemDesc("lblVw2AgntInfo.Text");
            lblVw2AgntCodeDisp.Text = olng.GetItemDesc("lblVw2AgntCodeDisp.Text");
            lblVw2AgntTypeDisp.Text = olng.GetItemDesc("lblVw2AgntTypeDisp.Text");
            lblVw2AgntNameDisp.Text = olng.GetItemDesc("lblVw2AgntNameDisp.Text");
            lblVw2AgntGenderDisp.Text = olng.GetItemDesc("lblVw2AgntGenderDisp.Text");
            lblHighAcadQual.Text = olng.GetItemDesc("lblHighAcadQual.Text");
            lblEduBack.Text = olng.GetItemDesc("lblEduBack.Text");
            lblInstName.Text = olng.GetItemDesc("lblInstName.Text");
            lblGradDate.Text = olng.GetItemDesc("lblGradDate.Text");
            lblMajor.Text = olng.GetItemDesc("lblMajor.Text");
            lblFamilyBack.Text = olng.GetItemDesc("lblFamilyBack.Text");
            lblSpouseName.Text = olng.GetItemDesc("lblSpouseName.Text");
            lblFamilyCnt.Text = olng.GetItemDesc("lblFamilyCnt.Text");
            lblEmployerName.Text = olng.GetItemDesc("lblEmployerName.Text");
            lblNoOfChild.Text = olng.GetItemDesc("lblNoOfChild.Text");
            lblDesignation.Text = olng.GetItemDesc("lblDesignation.Text");
            
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

    #region METHOD 'FillRequiredDtls()' DEFINITION
    protected void FillRequiredDtls()
    {
        dsResult = new DataSet();
        htParam = new Hashtable();
        oCommon.getDropDown(ddlAcadQual, "NBEduQua", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        ddlAcadQual.Items.Insert(0, new ListItem("Select", ""));
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
        try
        {
            dsResult = objDAL.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt2", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblVw2AgntCode.Text = Convert.ToString(ViewState["vwsAgntCode"]);
                    lblchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    lblsubchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                    lblVw2AgntType.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]);
                    lblVw2AgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblVw2AgntGender.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]);
                    if (dsResult.Tables[0].Rows[0]["EducationLevel"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EducationLevel"].ToString() != "")
                        {
                            ddlAcadQual.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["EducationLevel"]);
                        }
                    }
                    txtInstName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GradCollege"]);
                    if (dsResult.Tables[0].Rows[0]["GradDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["GradDate"].ToString() != "")
                        {
                            txtGradDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["GradDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }
                    txtMajor.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CourseMajor"]);
                    txtSpouseName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SpouseName"]);
                    txtFamilyCnt.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["FamilyMember"]);
                    txtEmployerName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SpouseComp"]);
                    txtNoOfChild.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NumOfChild"]);
                    txtDesignation.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SpouseOccp"]);
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
        dsResult.Clear();
        dsResult = null;
        htParam.Clear();
        htParam = null;
    }
    #endregion

    #region LINKBUTTON 'lnkPage1' ONCLICK EVENT
    protected void lnkPage1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region LINKBUTTON 'lnkPage2' ONCLICK EVENT
    protected void lnkPage2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region LINKBUTTON 'lnkPage3' ONCLICK EVENT
    protected void lnkPage3_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region LINKBUTTON 'lnkPage4' ONCLICK EVENT
    protected void lnkPage4_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region LINKBUTTON 'lnkPage5' ONCLICK EVENT
    protected void lnkPage5_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            htParam.Clear();
            dsResult.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@MemCode", lblVw2AgntCode.Text);
            htParam.Add("@EducationLevel", ddlAcadQual.SelectedValue);
            htParam.Add("@GradCollege", txtInstName.Text);
            htParam.Add("@GradDate", txtGradDate.Text);
            htParam.Add("@CourseMajor", txtMajor.Text);
            htParam.Add("@SpouseName", txtSpouseName.Text);
            htParam.Add("@FamilyMember", txtFamilyCnt.Text);
            htParam.Add("@SpouseComp", txtEmployerName.Text);
            htParam.Add("@NumOfChild", txtNoOfChild.Text);
            htParam.Add("@SpouseOccp", txtDesignation.Text);
            htParam.Add("@FamilySrcInc", "");
            htParam.Add("@UserName", Session["UserId"].ToString());
            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_updAgtDt_Edu", htParam);

            lbl3.Text = "Educational Info updated sucessfully" + "</br></br> Agent Code " + lblVw2AgntCode.Text + "</br></br> Member Type " + lblVw2AgntType.Text;
           // mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            lblMessage.Text = "Educational Info updated sucessfully";
           // lblMessage.Visible = true;
            btnUpdate.Enabled = false;
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

    //added by amruta for CHMS upgrade on 27/6/16 start
    #region Tab Employee Click EVENT
    protected void lnkEmployee_Click(object sender, EventArgs e)
    {
        try
        {

            lnkEmployee.CssClass = "btn-subtab btn btn-default";
            lnkEducation.CssClass = "btn btn-default";
            lnkEmpHist.CssClass = "btn btn-default";
            lnkDisp.CssClass = "btn btn-default";
            lnkpaymnt.CssClass = "btn btn-default";
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
            
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

    #region Tab Education Click EVENT
    protected void lnkEducation_Click(object sender, EventArgs e)
    {
       
        try
        {
            lnkEmployee.CssClass = "btn btn-default";
            lnkEducation.CssClass = "btn-subtab btn btn-default";
            lnkEmpHist.CssClass = "btn btn-default";
            lnkDisp.CssClass = "btn btn-default";
            lnkpaymnt.CssClass = "btn btn-default";
      

            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region Tab Employee History Click EVENT
    protected void lnkEmpHist_Click(object sender, EventArgs e)
    {
        
        try
        {
            lnkEmployee.CssClass = "btn btn-default";
            lnkEducation.CssClass = "btn btn-default";
            lnkEmpHist.CssClass = "btn-subtab btn btn-default";
            lnkDisp.CssClass = "btn btn-default";
            lnkpaymnt.CssClass = "btn btn-default";
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region Tab Displinary Info Click EVENT
    protected void lnkDisp_Click(object sender, EventArgs e)
    {

        try
        {

            lnkEmployee.CssClass = "btn btn-default";
            lnkEducation.CssClass = "btn btn-default";
            lnkEmpHist.CssClass = "btn btn-default";
            lnkDisp.CssClass = "btn-subtab btn btn-default";
            lnkpaymnt.CssClass = "btn btn-default";
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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

    #region Tab Payment Info Click EVENT
    protected void lnkpaymnt_Click(object sender, EventArgs e)
    {

        try
        {

            lnkEmployee.CssClass = "btn btn-default";
            lnkEducation.CssClass = "btn btn-default";
            lnkEmpHist.CssClass = "btn btn-default";
            lnkDisp.CssClass = "btn btn-default";
            lnkpaymnt.CssClass = "btn-subtab btn btn-default";
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw2AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
    //added by amruta for CHMS upgrade on 27/6/16 end

}
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

public partial class Application_ISys_ChannelMgmt_AgtInfoDispInfo : BaseClass
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
                ViewState["vwsAgntCode"] = Request.QueryString["MemCode"].ToString().Trim();
                lnkPage2.Enabled = false;
                lnkDisp.CssClass = "btn-subtab btn btn-default";
                InitializeControl();
                FillRequiredDtls();
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

            //Page 4-Displinary Info
            lblVw4AgntInfo.Text = olng.GetItemDesc("lblVw4AgntInfo.Text");
            lblVw4AgntCodeDisp.Text = olng.GetItemDesc("lblVw4AgntCodeDisp.Text");
            lblVw4AgntTypeDisp.Text = olng.GetItemDesc("lblVw4AgntTypeDisp.Text");
            lblVw4AgntNameDisp.Text = olng.GetItemDesc("lblVw4AgntNameDisp.Text");
            lblVw4AgntGenderDisp.Text = olng.GetItemDesc("lblVw4AgntGenderDisp.Text");
            lblDiscInfo.Text = olng.GetItemDesc("lblDiscInfo.Text");
            lblCriminalInfo.Text = olng.GetItemDesc("lblCriminalInfo.Text");
            lblPenalByInscRegul.Text = olng.GetItemDesc("lblPenalByInscRegul.Text");
            lblMiscNotes.Text = olng.GetItemDesc("lblMiscNotes.Text");
            
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
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        oCommon.getRadio(rdEverPenalized, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
        oCommon.getRadio(rdCriminalRecord, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
        rdEverPenalized.SelectedValue = "N";
        rdCriminalRecord.SelectedValue = "N";
        try
        {
            dsResult = objDAL.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt4", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblVw4AgntCode.Text = Convert.ToString(ViewState["vwsAgntCode"]);
                    lblchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    lblsubchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                    lblVw4AgntType.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]);
                    lblVw4AgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblVw4AgntGender.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]);
                    if (dsResult.Tables[0].Rows[0]["EverPenalized"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EverPenalized"].ToString().Trim() != "")
                        {
                            rdEverPenalized.SelectedValue = dsResult.Tables[0].Rows[0]["EverPenalized"].ToString();
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["CriminalRecord"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["CriminalRecord"].ToString().Trim() != "")
                        {
                            rdCriminalRecord.SelectedValue = dsResult.Tables[0].Rows[0]["CriminalRecord"].ToString();
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["EthicalRemark"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EthicalRemark"].ToString().Trim() != "")
                        {
                            txtEthRemark.Text = dsResult.Tables[0].Rows[0]["EthicalRemark"].ToString();
                            ChkEthFlag.Checked = true;
                            ChkEthFlag.Enabled = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["ShowCauseRemark"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["ShowCauseRemark"].ToString().Trim() != "")
                        {
                            txtShwCauseLtr.Text = dsResult.Tables[0].Rows[0]["ShowCauseRemark"].ToString();
                            chkShwCauseLtr.Checked = true;
                            chkShwCauseLtr.Enabled = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["CautionRemark"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["CautionRemark"].ToString().Trim() != "")
                        {
                            txtCautionLtr.Text = dsResult.Tables[0].Rows[0]["CautionRemark"].ToString();
                            chkCautionLtr.Checked = true;
                            chkCautionLtr.Enabled = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["WarningRemark"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["WarningRemark"].ToString().Trim() != "")
                        {
                            txtWarningLtr.Text = dsResult.Tables[0].Rows[0]["WarningRemark"].ToString();
                            chkWarningLtr.Checked = true;
                            chkWarningLtr.Enabled = true;
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["TerminationRemark"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["TerminationRemark"].ToString().Trim() != "")
                        {
                            txtTerminationLtr.Text = dsResult.Tables[0].Rows[0]["TerminationRemark"].ToString();
                            chkTerminationLtr.Checked = true;
                            chkTerminationLtr.Enabled = true;
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            dsResult = null;
            htParam.Add("@CarrierCode", Session["CarrierCode"].ToString().Trim());
            htParam.Add("@MemCode", lblVw4AgntCode.Text);
            htParam.Add("@EthicalRemark", txtEthRemark.Text.ToString().Trim());
            htParam.Add("@CautionRemark", txtCautionLtr.Text.ToString().Trim());
            htParam.Add("@WarningRemark", txtWarningLtr.Text.ToString().Trim());
            htParam.Add("@TerminationRemark", txtTerminationLtr.Text.ToString().Trim());
            htParam.Add("@ShowCauseRemark", txtShwCauseLtr.Text.ToString().Trim());
            htParam.Add("@CreateBy", Session["UserId"].ToString());
            if (rdEverPenalized.SelectedValue == "Y")
            {
                htParam.Add("@EverPenalized", 1);
            }
            else
            {
                htParam.Add("@EverPenalized", 0);
            }

            if (rdCriminalRecord.SelectedValue == "Y")
            {
                htParam.Add("@CriminalRecord", 1);
            }
            else
            {
                htParam.Add("@CriminalRecord", 0);
            }
            dsResult = objDAL.GetDataSetForPrcCLP("Prc_InsMemDispInfoDtls", htParam);

            lbl3.Text = "Disciplinary Info updated sucessfully" + "</br></br> Agent Code " + lblVw4AgntCode.Text + "</br></br> Member Type " + lblVw4AgntType.Text;
           // mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            lblMessage.Text = "Disciplinary Info updated sucessfully";
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

    #region ChkEthFlag_CheckedChanged
    protected void ChkEthFlag_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkEthFlag.Checked == true)
        {
            txtEthRemark.Enabled = true;

        }
        else
        {
            txtEthRemark.Enabled = false;
        }
    }
    #endregion

    #region chkShwCauseLtr_CheckedChanged
    protected void chkShwCauseLtr_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShwCauseLtr.Checked == true)
        {
            txtShwCauseLtr.Enabled = true;
        }
        else
        {
            txtShwCauseLtr.Enabled = false;
        }
    }
    #endregion

    #region chkCautionLtr_CheckedChanged
    protected void chkCautionLtr_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCautionLtr.Checked == true)
        {
            txtCautionLtr.Enabled = true;
        }
        else
        {
            txtCautionLtr.Enabled = false;
        }
    }
    #endregion

    #region chkWarningLtr_CheckedChanged
    protected void chkWarningLtr_CheckedChanged(object sender, EventArgs e)
    {

        if (chkWarningLtr.Checked == true)
        {
            txtWarningLtr.Enabled = true;
        }
        else
        {
            txtWarningLtr.Enabled = false;
        }
    }
    #endregion

    #region chkTerminationLtr_CheckedChanged
    protected void chkTerminationLtr_CheckedChanged(object sender, EventArgs e)
    {

        if (chkTerminationLtr.Checked == true)
        {
            txtTerminationLtr.Enabled = true;
        }
        else
        {
            txtTerminationLtr.Enabled = false;
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw4AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
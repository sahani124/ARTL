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

public partial class Application_ISys_ChannelMgmt_AgtInfoPaymentInfo : BaseClass
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
                //lnkPage5.Enabled = false;
                lnkpaymnt.CssClass = "btn-subtab btn btn-default";
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
            //Page 5- Payment Info
            lblVw5AgntInfo.Text = olng.GetItemDesc("lblVw5AgntInfo.Text");
            lblVw5AgntCodeDisp.Text = olng.GetItemDesc("lblVw5AgntCodeDisp.Text");
            lblVw5AgntTypeDisp.Text = olng.GetItemDesc("lblVw5AgntTypeDisp.Text");
            lblVw5AgntNameDisp.Text = olng.GetItemDesc("lblVw5AgntNameDisp.Text");
            lblVw5AgntGenderDisp.Text = olng.GetItemDesc("lblVw5AgntGenderDisp.Text");
            lblPayInfoSetup.Text = olng.GetItemDesc("lblPayInfoSetup.Text");
            lblPayWithHold.Text = olng.GetItemDesc("lblPayWithHold.Text");
            lblPayeeCatg.Text = olng.GetItemDesc("lblPayeeCatg.Text");
            lblTaxAppln.Text = olng.GetItemDesc("lblTaxAppln.Text");
            lblTaxExempEnt.Text = olng.GetItemDesc("lblTaxExempEnt.Text");
            lblTaxExempCertId.Text = olng.GetItemDesc("lblTaxExempCertId.Text");
            lblTaxExmpRate.Text = olng.GetItemDesc("lblTaxExmpRate.Text");
            lblTaxExmpDate.Text = olng.GetItemDesc("lblTaxExmpDate.Text");
            lblTaxExmpExpDate.Text = olng.GetItemDesc("lblTaxExmpExpDate.Text");
            lblPersonalVAT.Text = olng.GetItemDesc("lblPersonalVAT.Text");
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
        
        oCommon.getRadio(rdAgtPymtWithhold, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
        oCommon.getRadio(rdTaxExmp, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
        oCommon.getRadio(rdVAT, "cboyesno", Session["UserLangNum"].ToString(), "", 0);
        oCommon.getDropDown(ddlPayeeCatg, "PayeeTyp", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        rdAgtPymtWithhold.SelectedValue = "N";
        rdTaxExmp.SelectedValue = "N";
        rdVAT.SelectedValue = "N";

        ddlPayeeCatg.Items.Insert(0, new ListItem("-- Select --", ""));
        try
        {
            htParam.Clear();
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            dsResult = objDAL.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt5", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblVw5AgntCode.Text = Convert.ToString(ViewState["vwsAgntCode"]);
                    lblchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    lblsubchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                    lblVw5AgntType.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]);
                    lblVw5AgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]);
                    lblVw5AgntGender.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]);
                    if (dsResult.Tables[0].Rows[0]["MemPymtWithhold"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MemPymtWithhold"]).Trim() != "")
                        {
                            rdAgtPymtWithhold.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MemPymtWithhold"]).Trim();
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["PayeeType"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["PayeeType"]).Trim() != "")
                        {
                            ddlPayeeCatg.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PayeeType"]).Trim();
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["TaxExmp"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["TaxExmp"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["TaxExmp"]) == "1")
                            {
                                rdTaxExmp.SelectedValue = "Y";
                            }
                            else
                            {
                                rdTaxExmp.SelectedValue = "N";
                            }
                        }
                    }
                    txtTaxExmpCertId.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TaxExmpCertNo"]).Trim();
                    txtTaxExmpRate.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["TaxExmpRate"]).Trim();
                    if (dsResult.Tables[0].Rows[0]["InVAT"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["InVAT"]).Trim() != "")
                        {
                            rdVAT.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["InVAT"]).Trim();
                        }
                    }
                }
            }
            if (rdTaxExmp.SelectedValue == "Y")
            {
                txtTaxExmpCertId.ReadOnly = false;
                txtTaxExmpRate.ReadOnly = false;
            }
            else
            {
                txtTaxExmpCertId.ReadOnly = true;
                txtTaxExmpRate.ReadOnly = true;
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            htParam.Add("@agentCode", lblVw5AgntCode.Text);
            htParam.Add("@AgtPymtWithhold", rdAgtPymtWithhold.SelectedValue);
            htParam.Add("@PayeeType", ddlPayeeCatg.SelectedValue);
            if (rdTaxExmp.SelectedValue == "Y")
            {
                htParam.Add("@TaxExmp", 1);
            }
            else
            {
                htParam.Add("@TaxExmp", 0);
            }
            htParam.Add("@TaxExmpCertNo", txtTaxExmpCertId.Text);
            if (txtTaxExmpRate.Text.Trim() != "")
            {
                htParam.Add("@TaxExmpRate", Convert.ToInt32(txtTaxExmpRate.Text.Replace("0.00", "0")));
            }
            else
            {
                htParam.Add("@TaxExmpRate", 0);
            }
            htParam.Add("@InVAT", rdVAT.SelectedValue);
            htParam.Add("@UserName", Session["UserId"].ToString());
            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_updAgtDt_Paymnt", htParam);

            lbl3.Text = "Payment Info updated sucessfully" + "</br></br> Agent Code " + lblVw5AgntCode.Text + "</br></br> Member Type " + lblVw5AgntType.Text;
          //  mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            lblMessage.Text = "Payment Info updated sucessfully";
          //  lblMessage.Visible = true;
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw5AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
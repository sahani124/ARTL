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

public partial class Application_ISys_ChannelMgmt_AgtInfoEmpHst : BaseClass
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
               // lnkPage3.Enabled = false;
                lnkEmpHist.CssClass = "btn-subtab btn btn-default";
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
            //Page 3-Employement History
            lblVw3AgntCodeDisp.Text = olng.GetItemDesc("lblVw3AgntCodeDisp.Text");
            lblVw3AgntTypeDisp.Text = olng.GetItemDesc("lblVw3AgntTypeDisp.Text");
            lblVw3AgntNameDisp.Text = olng.GetItemDesc("lblVw3AgntNameDisp.Text");
            lblVw3AgntGenderDisp.Text = olng.GetItemDesc("lblVw3AgntGenderDisp.Text");
            lblVw3AgntInfo.Text = olng.GetItemDesc("lblVw3AgntInfo.Text");
            lblEmpHistory.Text = olng.GetItemDesc("lblEmpHistory.Text");
            lblPrevEmp1.Text = olng.GetItemDesc("lblPrevEmp1.Text");
            lblForInsSlsBack1.Text = olng.GetItemDesc("lblForInsSlsBack1.Text");
            lblDurOfService1.Text = olng.GetItemDesc("lblDurOfService1.Text");
            lblVw3From1.Text = olng.GetItemDesc("lblVw3From1.Text");
            lblVw3To1.Text = olng.GetItemDesc("lblVw3To1.Text");
            lblAgntLvlAchieve1.Text = olng.GetItemDesc("lblAgntLvlAchieve1.Text");
            lblEmpStatus1.Text = olng.GetItemDesc("lblEmpStatus1.Text");
            lblWorkIndustry1.Text = olng.GetItemDesc("lblWorkIndustry1.Text");
            lblPrevAgntCode1.Text = olng.GetItemDesc("lblPrevAgntCode1.Text");
            lblEmpLvl1.Text = olng.GetItemDesc("lblEmpLvl1.Text");
            lblQualID1.Text = olng.GetItemDesc("lblQualID1.Text");
            lblLastIncome1.Text = olng.GetItemDesc("lblLastIncome1.Text");
            lblPrevEmp2.Text = olng.GetItemDesc("lblPrevEmp2.Text");
            lblForInsSlsBack2.Text = olng.GetItemDesc("lblForInsSlsBack2.Text");
            lblDurOfService2.Text = olng.GetItemDesc("lblDurOfService2.Text");
            lblVw3From2.Text = olng.GetItemDesc("lblVw3From2.Text");
            lblVw3To2.Text = olng.GetItemDesc("lblVw3To2.Text");
            lblAgntLvlAchieve2.Text = olng.GetItemDesc("lblAgntLvlAchieve2.Text");
            lblEmpStatus2.Text = olng.GetItemDesc("lblEmpStatus2.Text");
            lblWorkIndustry2.Text = olng.GetItemDesc("lblWorkIndustry2.Text");
            lblPrevAgntCode2.Text = olng.GetItemDesc("lblPrevAgntCode2.Text");
            lblEmpLvl2.Text = olng.GetItemDesc("lblEmpLvl2.Text");
            lblQualID2.Text = olng.GetItemDesc("lblQualID2.Text");
            lblLastIncome2.Text = olng.GetItemDesc("lblLastIncome2.Text");
            lblPrevEmp3.Text = olng.GetItemDesc("lblPrevEmp3.Text");
            lblForInsSlsBack3.Text = olng.GetItemDesc("lblForInsSlsBack3.Text");
            lblDurOfService3.Text = olng.GetItemDesc("lblDurOfService3.Text");
            lblVw3From3.Text = olng.GetItemDesc("lblVw3From3.Text");
            lblVw3To3.Text = olng.GetItemDesc("lblVw3To3.Text");
            lblAgntLvlAchieve3.Text = olng.GetItemDesc("lblAgntLvlAchieve3.Text");
            lblEmpStatus3.Text = olng.GetItemDesc("lblEmpStatus3.Text");
            lblWorkIndustry3.Text = olng.GetItemDesc("lblWorkIndustry3.Text");
            lblPrevAgntCode3.Text = olng.GetItemDesc("lblPrevAgntCode3.Text");
            lblEmpLvl3.Text = olng.GetItemDesc("lblEmpLvl3.Text");
            lblQualID3.Text = olng.GetItemDesc("lblQualID3.Text");
            lblLastIncome3.Text = olng.GetItemDesc("lblLastIncome3.Text");
            
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

        oCommon.getDropDown(ddlAgntLvlAchieve1, "AAgEmpLvl", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlAgntLvlAchieve2, "AAgEmpLvl", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlAgntLvlAchieve3, "AAgEmpLvl", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

        oCommon.getDropDown(ddlEmpStatus1, "AAgEmpSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlEmpStatus2, "AAgEmpSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlEmpStatus3, "AAgEmpSts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

        oCommon.getDropDown(ddlWorkIndustry1, "AAgWork", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlWorkIndustry2, "AAgWork", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlWorkIndustry3, "AAgWork", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

        oCommon.getDropDown(ddlEmpLvl1, "AAgEmPos", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlEmpLvl2, "AAgEmPos", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
        oCommon.getDropDown(ddlEmpLvl3, "AAgEmPos", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

        ddlEmpLvl1.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEmpLvl2.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEmpLvl3.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEmpStatus1.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEmpStatus2.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlEmpStatus3.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlWorkIndustry1.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlWorkIndustry2.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlWorkIndustry3.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlAgntLvlAchieve1.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlAgntLvlAchieve2.Items.Insert(0, new ListItem("-- Select --", ""));
        ddlAgntLvlAchieve3.Items.Insert(0, new ListItem("-- Select --", ""));

        ddlVw3FromMnth1.Items.Clear();
        ddlVw3FromMnth2.Items.Clear();
        ddlVw3FromMnth3.Items.Clear();
        ddlVw3ToMnth1.Items.Clear();
        ddlVw3ToMnth2.Items.Clear();
        ddlVw3ToMnth3.Items.Clear();

        for (int i = 0; i < 12; i++)
        {
            ddlVw3FromMnth1.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            ddlVw3ToMnth1.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            ddlVw3FromMnth2.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            ddlVw3ToMnth2.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            ddlVw3FromMnth3.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            ddlVw3ToMnth3.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
        }

        ddlVw3FromMnth1.Items.Insert(0, new ListItem("", ""));
        ddlVw3ToMnth1.Items.Insert(0, new ListItem("", ""));
        ddlVw3FromMnth2.Items.Insert(0, new ListItem("", ""));
        ddlVw3ToMnth2.Items.Insert(0, new ListItem("", ""));
        ddlVw3FromMnth3.Items.Insert(0, new ListItem("", ""));
        ddlVw3ToMnth3.Items.Insert(0, new ListItem("", ""));

        try
        {
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            htParam.Add("@AgentCode", ViewState["vwsAgntCode"].ToString());
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            dsResult = objDAL.GetDataSetForPrcDBConn("prc_AgyAdmin_getAgtDt3", htParam, INSCL.App_Code.CommonUtility.CONN_LIFE_DATA);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    lblVw3AgntCode.Text = Convert.ToString(ViewState["vwsAgntCode"]);
                    lblchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]);
                    lblsubchnlval.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                    lblVw3AgntType.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MemType"]);
                    lblVw3AgntName.Text = oCommonU.ReadStr1(Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]));
                    lblVw3AgntGender.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GenderDesc"]);
                }
                if (dsResult.Tables[1] != null)
                {
                    if (dsResult.Tables[1].Rows.Count > 0)
                    {
                        int intRecCnt = dsResult.Tables[1].Rows.Count;
                        if (intRecCnt == 1 || intRecCnt == 2 || intRecCnt == 3)
                        {
                            //Employer 1
                            txtPrevEmpName1.Text = oCommonU.ReadStr1(Convert.ToString(dsResult.Tables[1].Rows[0]["CompName"]));
                            txtPrevAgntCode1.Text = Convert.ToString(dsResult.Tables[1].Rows[0]["PrevAgentCode"]);
                            txtQualID1.Text = Convert.ToString(dsResult.Tables[1].Rows[0]["QualifiedID"]);
                            if (Convert.ToString(dsResult.Tables[1].Rows[0]["MnthIncome"]).Trim() != "")
                            {
                                txtLastIncome1.Text = Decimal.Parse(Convert.ToString(dsResult.Tables[1].Rows[0]["MnthIncome"])).ToString("0.00");
                            }
                            if (dsResult.Tables[1].Rows[0]["MemLevel"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["MemLevel"].ToString().Trim() != "")
                                {
                                    ddlAgntLvlAchieve1.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[0]["MemLevel"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[0]["EmployStatus"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["EmployStatus"].ToString().Trim() != "")
                                {
                                    ddlEmpStatus1.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[0]["EmployStatus"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[0]["WorkNature"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["WorkNature"].ToString().Trim() != "")
                                {
                                    ddlWorkIndustry1.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[0]["WorkNature"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[0]["WorkClass"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["WorkClass"].ToString().Trim() != "")
                                {
                                    ddlEmpLvl1.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[0]["WorkClass"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[0]["BeginDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["BeginDate"].ToString().Trim() != "")
                                {
                                    ddlVw3FromMnth1.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[0]["BeginDate"])).Month.ToString();
                                    txtVw3FromYear1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[0]["BeginDate"])).Year.ToString();
                                }
                            }
                            if (dsResult.Tables[1].Rows[0]["EndDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[0]["EndDate"].ToString().Trim() != "")
                                {
                                    ddlVw3ToMnth1.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[0]["EndDate"])).Month.ToString();
                                    txtVw3ToYear1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[0]["EndDate"])).Year.ToString();
                                }
                            }
                        }
                        if (intRecCnt == 2 || intRecCnt == 3)
                        {
                            //Employer 2
                            txtPrevEmpName2.Text = oCommonU.ReadStr1(Convert.ToString(dsResult.Tables[1].Rows[1]["CompName"]));
                            txtPrevAgntCode2.Text = Convert.ToString(dsResult.Tables[1].Rows[1]["PrevAgentCode"]);
                            txtQualID2.Text = Convert.ToString(dsResult.Tables[1].Rows[1]["QualifiedID"]);
                            if (Convert.ToString(dsResult.Tables[1].Rows[1]["MnthIncome"]).Trim() != "")
                            {
                                txtLastIncome2.Text = Decimal.Parse(Convert.ToString(dsResult.Tables[1].Rows[1]["MnthIncome"])).ToString("0.00");
                            }
                            if (dsResult.Tables[1].Rows[1]["MemLevel"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["MemLevel"].ToString().Trim() != "")
                                {
                                    ddlAgntLvlAchieve2.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[1]["MemLevel"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[1]["EmployStatus"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["EmployStatus"].ToString().Trim() != "")
                                {
                                    ddlEmpStatus2.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[1]["EmployStatus"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[1]["WorkNature"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["WorkNature"].ToString().Trim() != "")
                                {
                                    ddlWorkIndustry2.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[1]["WorkNature"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[1]["WorkClass"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["WorkClass"].ToString().Trim() != "")
                                {
                                    ddlEmpLvl2.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[1]["WorkClass"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[1]["BeginDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["BeginDate"].ToString().Trim() != "")
                                {
                                    ddlVw3FromMnth2.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[1]["BeginDate"])).Month.ToString();
                                    txtVw3FromYear2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[1]["BeginDate"])).Year.ToString();
                                }
                            }
                            if (dsResult.Tables[1].Rows[1]["EndDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[1]["EndDate"].ToString().Trim() != "")
                                {
                                    ddlVw3ToMnth2.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[1]["EndDate"])).Month.ToString();
                                    txtVw3ToYear2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[1]["EndDate"])).Year.ToString();
                                }
                            }
                        }
                        if (intRecCnt == 3)
                        {
                            //Employer 3
                            txtPrevEmpName3.Text = oCommonU.ReadStr1(Convert.ToString(dsResult.Tables[1].Rows[2]["CompName"]));
                            txtPrevAgntCode3.Text = Convert.ToString(dsResult.Tables[1].Rows[2]["PrevAgentCode"]);
                            txtQualID3.Text = Convert.ToString(dsResult.Tables[1].Rows[2]["QualifiedID"]);
                            if (Convert.ToString(dsResult.Tables[1].Rows[2]["MnthIncome"]).Trim() != "")
                            {
                                txtLastIncome3.Text = Decimal.Parse(Convert.ToString(dsResult.Tables[1].Rows[2]["MnthIncome"])).ToString("0.00");
                            }
                            if (dsResult.Tables[1].Rows[2]["MemLevel"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["MemLevel"].ToString().Trim() != "")
                                {
                                    ddlAgntLvlAchieve3.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[2]["MemLevel"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[2]["EmployStatus"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["EmployStatus"].ToString().Trim() != "")
                                {
                                    ddlEmpStatus3.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[2]["EmployStatus"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[2]["WorkNature"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["WorkNature"].ToString().Trim() != "")
                                {
                                    ddlWorkIndustry3.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[2]["WorkNature"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[2]["WorkClass"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["WorkClass"].ToString().Trim() != "")
                                {
                                    ddlEmpLvl3.SelectedValue = Convert.ToString(dsResult.Tables[1].Rows[2]["WorkClass"]);
                                }
                            }
                            if (dsResult.Tables[1].Rows[2]["BeginDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["BeginDate"].ToString().Trim() != "")
                                {
                                    ddlVw3FromMnth3.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[2]["BeginDate"])).Month.ToString();
                                    txtVw3FromYear3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[2]["BeginDate"])).Year.ToString();
                                }
                            }
                            if (dsResult.Tables[1].Rows[2]["EndDate"] != null)
                            {
                                if (dsResult.Tables[1].Rows[2]["EndDate"].ToString().Trim() != "")
                                {
                                    ddlVw3ToMnth3.SelectedValue = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[2]["EndDate"])).Month.ToString();
                                    txtVw3ToYear3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[1].Rows[2]["EndDate"])).Year.ToString();
                                }
                            }
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            htParam.Add("@agentCode", lblVw3AgntCode.Text);

            #region Employee1
            htParam.Add("@CompName1", txtPrevEmpName1.Text);
            if (ddlVw3FromMnth1.SelectedValue != "" && txtVw3FromYear1.Text.Trim() != "")
            {
                htParam.Add("@BeginDate1", ddlVw3FromMnth1.SelectedValue + "/1/" + txtVw3FromYear1.Text.Trim());
            }
            else
            {
                htParam.Add("@BeginDate1", "");
            }
            htParam.Add("@AgentLevel1", ddlAgntLvlAchieve1.SelectedValue);
            if (ddlVw3ToMnth1.SelectedValue != "" && txtVw3ToYear1.Text.Trim() != "")
            {
                htParam.Add("@EndDate1", ddlVw3ToMnth1.SelectedValue + "/1/" + txtVw3ToYear1.Text);
            }
            else
            {
                htParam.Add("@EndDate1", "");
            }
            htParam.Add("@AgentStatus1", ddlEmpStatus1.SelectedValue);
            htParam.Add("@WorkNature1", ddlWorkIndustry1.SelectedValue);
            htParam.Add("@PrevAgentCode1", txtPrevAgntCode1.Text);
            htParam.Add("@WorkClass1", ddlEmpLvl1.SelectedValue);
            htParam.Add("@QualifiedID1", txtQualID1.Text);
            htParam.Add("@MthIncome1", txtLastIncome1.Text);
            #endregion

            #region Employee2
            htParam.Add("@CompName2", txtPrevEmpName2.Text);
            if (ddlVw3FromMnth2.SelectedValue != "" && txtVw3FromYear2.Text.Trim() != "")
            {
                htParam.Add("@BeginDate2", ddlVw3FromMnth2.SelectedValue + "/1/" + txtVw3FromYear2.Text);
            }
            else
            {
                htParam.Add("@BeginDate2", "");
            }
            htParam.Add("@AgentLevel2", ddlAgntLvlAchieve2.SelectedValue);
            if (ddlVw3ToMnth2.SelectedValue != "" && txtVw3ToYear2.Text.Trim() != "")
            {
                htParam.Add("@EndDate2", ddlVw3ToMnth2.SelectedValue + "/1/" + txtVw3ToYear2.Text);
            }
            else
            {
                htParam.Add("@EndDate2", "");
            }
            htParam.Add("@AgentStatus2", ddlEmpStatus2.SelectedValue);
            htParam.Add("@WorkNature2", ddlWorkIndustry2.SelectedValue);
            htParam.Add("@PrevAgentCode2", txtPrevAgntCode2.Text);
            htParam.Add("@WorkClass2", ddlEmpLvl2.SelectedValue);
            htParam.Add("@QualifiedID2", txtQualID2.Text);
            htParam.Add("@MthIncome2", txtLastIncome2.Text);
            #endregion

            #region Employee3
            htParam.Add("@CompName3", txtPrevEmpName3.Text);
            if (ddlVw3FromMnth3.SelectedValue != "" && txtVw3FromYear3.Text.Trim() != "")
            {
                htParam.Add("@BeginDate3", ddlVw3FromMnth3.SelectedValue + "/1/" + txtVw3FromYear3.Text);
            }
            else
            {
                htParam.Add("@BeginDate3", "");
            }
            htParam.Add("@AgentLevel3", ddlAgntLvlAchieve3.SelectedValue);
            if (ddlVw3ToMnth3.SelectedValue != "" && txtVw3ToYear3.Text.Trim() != "")
            {
                htParam.Add("@EndDate3", ddlVw3ToMnth3.SelectedValue + "/1/" + txtVw3ToYear3.Text);
            }
            else
            {
                htParam.Add("@EndDate3", "");
            }
            htParam.Add("@AgentStatus3", ddlEmpStatus3.SelectedValue);
            htParam.Add("@WorkNature3", ddlWorkIndustry3.SelectedValue);
            htParam.Add("@PrevAgentCode3", txtPrevAgntCode3.Text);
            htParam.Add("@WorkClass3", ddlEmpLvl3.SelectedValue);
            htParam.Add("@QualifiedID3", txtQualID3.Text);
            htParam.Add("@MthIncome3", txtLastIncome3.Text);
            #endregion

            dsResult = objDAL.GetDataSetForPrc("prc_AgyAdmin_updAgtDt_EmpHst", htParam);

            lbl3.Text = "Employment History updated sucessfully" + "</br></br> Agent Code " + lblVw3AgntCode.Text + "</br></br> Member Type " + lblVw3AgntType.Text;
          //  mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            lblMessage.Text = "Employment History updated sucessfully";
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
            Response.Redirect("AGTInfo.aspx?AgnCd=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoEducation.aspx?AgnCd=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());

           
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
            Response.Redirect("AgtInfoEmpHst.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoDispInfo.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
            Response.Redirect("AgtInfoPaymentInfo.aspx?MemCode=" + lblVw3AgntCode.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Ctgry=" + Request.QueryString["Ctgry"].ToString().Trim() + "&ID=" + Request.QueryString["ID"].ToString());
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
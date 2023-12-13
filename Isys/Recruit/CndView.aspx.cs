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
//using INSCL.App_Code;
using System.Data.SqlClient;
using Insc.MQ.Life.AgnCr;
using Insc.Common.Multilingual;
using Insc.MQ.Life.AgnInwMd;
using Insc.MQ.Life.AgnInwCr;
using System.Text.RegularExpressions;
using DataAccessClassDAL;
using Newtonsoft.Json;

public partial class Application_ISys_Recruit_CndView : BaseClass
{
    public multilingualManager olng;
    ErrLog objErr = new ErrLog();
    string strCnd;

    Hashtable htParams = new Hashtable();
    DataSet dsResult;
    private DataAccessClass dataAccessclass = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    string strRec = System.Configuration.ConfigurationManager.ConnectionStrings["INSCRecruitConnectionString"].ToString();
    string strDirect = System.Configuration.ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ToString();
    string UserTypeEmp="";
    //Added by Prathamesh 17-6-15
    string strProspectID = string.Empty;
    protected CommonFunc oCommon = new CommonFunc();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    DataSet dsPanResult = new DataSet();
    AadharVault AadharVault = new AadharVault();//Added by AshishP 07-04-2018 AadharEncrypt
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();



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
                DataSet dscode = new DataSet();
                dscode = oCommonUtility.GetUserDtls(Session["UserID"].ToString().Trim());
                UserTypeEmp = dscode.Tables[0].Rows[0]["UserType"].ToString();
                if (UserTypeEmp == "E")
                {
                    divpanel5.Visible = true;
                    nombnkdtls.Visible = true;
                    Bankdtls();
                }
                
                Session["CarrierCode"] = '2';
                olng = new multilingualManager("DefaultConn", "CndView.aspx", Session["UserLangNum"].ToString());
                strCnd = Request.QueryString["CndNo"].ToString();
                //Request.QueryString["Page"].ToString(); Page
                EnableDisableIsSpecific();
                InitializeControl();
                PopulateCndPersonalDtls();
                GetPOSPPANException();//image 31 july 2023
                PopulateDispatchDtls();//added bu sanoj 22062023
                if (Request.QueryString["Type"].ToString() != "Pros")
                {
                    GetPersonalInformation();
                    GetRenewalDtls();
                    GetReExamDtls();
                    PopulateTrainigDtls();
                    PopulateExmDtls();

                }
                if (Request.QueryString["Type"].ToString() != "Pros")
                {
                    //added by Nikhil for composite on 8.6.15 start
                    Hashtable htParams = new Hashtable();
                    // Dataset dsResult = new Dataset();
                    htParams.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
                    dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", htParams);
                    String strCndType = dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim();
                    if (strCndType == "T" || strCndType == "C" || strCndType == "G")
                    {
                        if (strCndType == "T")
                        {
                            tblcomposite.Visible = false;
                        }
                        else if (strCndType == "C")
                        {
                            tbltrnsDtls.Visible = false;
                        }

                        else
                        {
                            tblcomposite.Visible = true;//
                            tbltrnsDtls.Visible = false;
                        }
                        tr5.Visible = false;
                        tr6.Visible = false;

                        divCompositeDetails.Visible = true;//added by pranjali on 13-03-2014
                        tr2.Visible = false;
                        tr3.Visible = false;
                        trAckrow.Visible = false;
                        //trNoteTr.Visible = true;
                        // (BindCompositeGridRequest.QueryString["CndNo"].ToString());
                    }
                }
                PopulateNOCDtls();
                PopulateCndPersonalDtls();
                InitializeControl();
                 BindCandidateMvmt();
                // cndstatus();
                //btnCancel.Visible = true;

                btnstate1search.Attributes.Add("onclick", "funcShowPopup('statedemo');return false;");
                btnPAstate1search.Attributes.Add("onclick", "funcShowPopup('statedemo1');return false;");

                //chkEdit.Attributes.Add("onclick", "('statedemo');return false;");
                btnCancel.Style.Add("display", "block");
            }
            //commented by pranjali on 03-04-2014 
            //btnCancel.Attributes.Add("onclick", "doCancel('" + Request.QueryString["mdlViewCnd"].ToString() + "');");
            DataSet BindGrid = BindGridCnd();
            if (BindGrid.Tables[0].Rows.Count > 0)
            {
                GridCndImage.Visible = true;
                Img.Visible = false;
                GridCndImage.DataSource = BindGridCnd();
                GridCndImage.DataBind();
            }

            //Added Profiling function by Prathamesh 17-6-15
            GetProfilingDtls();
            PopulateAgentType();
            YearsInInsurance();
            YearsInReliance();
            VechicleManufacturer();
            VechicleType();
            //ddlAvgMonthlyIncm.Enabled = false;
            AverageMonthlyIncome();
            ComptCompyMonthlyVolum();
            ComptCompyMonthlyVolum2();
            BusinessMonthlyVol();
            CompetitorCompanyName2();
            CompetitorCompanyName1();
            TotalBusiness();

            GetRCAPcompany();
            GetFromOthersSpecify1();
            GetNoofyearsinInsurance();
            GetDealerTypeOfVehicleDeal();
            GetCompanyName();
            GetComapnynNameIfYes();
            GetFromOthersSpecify2();
            GetNoOfYearsWithReliance();
            GetDealerVehicleManufacturerdealing();
            GetAvgMonthlyVolumeinLacs();
            GetCompany1name();
            GetCompany2name();
            GetMonthlyVolumeInLacsCompany1();
            GetMonthlyVolumeInLacsCompany2();
            GetMonthlyVolumeInLacsRGI();
            GetTotalBuisnessMotor();
            GetTotalBuisnessHealth();
            GetTotalBuisnessComercialLine();
            GetBusinessWithRGIMotor();
            GetBusinessWithRGIHealth();
            GetBusinessWithRGIComercialLine();
            PopulateNOCDtls();//added by Nikhil 
            
            if (lblcndidDesc.Text == "")
            {
                LinkPage6.Visible = false;
                LinkPage7.Visible = false;
                LinkPage8.Visible = false;
                btnCancel.Visible = true;
            }
            BindCompositeGrid(Request.QueryString["CndNo"].ToString());
            GetStatus();

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



    //This Function added by Prathamesh 17-6-15
    #region ddlagntype_SelectedIndexChanged
    protected void ddlagntype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlagntype.SelectedIndex == 0)
        {
            ddlAvgMonthlyIncm.Items.Clear();
            ddlAvgMonthlyIncm.Items.Insert(0, "--Select--");
            ddlAvgMonthlyIncm.Enabled = false;
        }
        else
        {
            ddlAvgMonthlyIncm.Enabled = true;
        }
        if (ddlagntype.SelectedValue == "2")
        {
            oCommon.getDropDown(ddlTypeOfVehicle, "Vec_Typ", 1, "", 1);
            VechicleManufacturer();
            ddlTypeOfVehicle.Items.Insert(0, "--Select--");
            txtDlrCompName.Enabled = true;
            txtDlrOth.Enabled = true;
            ddlTypeOfVehicle.Enabled = true;
            ddlVechManuf.Enabled = true;
        }
        else
        {
            ddlTypeOfVehicle.Items.Clear();
            ddlVechManuf.Items.Clear();
            ddlTypeOfVehicle.Items.Insert(0, "--Select--");
            ddlVechManuf.Items.Insert(0, "--Select--");
            txtDlrCompName.Text = "";
            txtDlrCompName.Enabled = false;
            txtDlrOth.Text = "";
            txtDlrOth.Enabled = false;
            ddlTypeOfVehicle.Enabled = false;
            ddlVechManuf.Enabled = false;
        }
        if (ddlagntype.SelectedIndex != 0)
        {
            AverageMonthlyIncome();
        }
        else
        {
            //ddlAvgMonthlyIncm.Items.Insert(0, "--Select--");
        }
        if (ddlagntype.SelectedValue == "5")
        {
            txtOthers.Enabled = true;
        }
        else
        {
            txtOthers.Text = "";
            txtOthers.Enabled = false;

        }
    }
    #endregion

    //This Function added by Prathamesh 17-6-15
    #region ddlIsWrkng_SelectedIndexChanged
    protected void ddlIsWrkng_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsWrkng.SelectedValue == "Y")
        {
            oCommon.getDropDown(ddlcompName, "CompyName", 1, "", 1);
            ddlcompName.Items.Insert(0, "--Select--");
            ddlcompName.Enabled = true;
        }
        else
        {
            ddlcompName.Items.Clear();
            ddlcompName.Items.Insert(0, "--Select--");
            ddlcompName.Enabled = false;
        }
    }
    #endregion


    //All Profiling function added by Prathamesh 17-6-15
    #region PopulateAgentType()
    private void PopulateAgentType()
    {

        try
        {


            DataSet dsresult = new DataSet();
            dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetddlAgnTyp");
            ddlagntype.DataSource = dsresult;
            ddlagntype.DataTextField = "AgnTypName";
            ddlagntype.DataValueField = "AgnTypCode";
            ddlagntype.DataBind();
            ddlagntype.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region YearsInInsurance()
    //To display list of caste category from IsysLookupParam table
    private void YearsInInsurance()
    {

        try
        {
            oCommon.getDropDown(ddlNoOfYrsIns, "YEARS", 1, "", 1);
            ddlNoOfYrsIns.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region YearsInReliance()
    //To display list of caste category from IsysLookupParam table
    private void YearsInReliance()
    {
        try
        {
            oCommon.getDropDown(ddlNoOfYrs, "YEARS", 1, "", 1);
            ddlNoOfYrs.Items.Insert(0, "--Select--");
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
    //Added by Prathamesh 8-6-15 end
    #endregion

    //All Profiling function added by Prathamesh 17-6-15
    #region VechicleManufacturer()
    private void VechicleManufacturer()
    {
        try
        {
            if (ddlagntype.SelectedValue == "2")
            {
                DataSet dsresult = new DataSet();
                dsresult = dataAccessRecruit.GetDataSetForPrc1("Prc_GetddlVchlManf");
                ddlVechManuf.Items.Clear();
                ddlVechManuf.DataSource = dsresult;
                ddlVechManuf.DataTextField = "Make_Name";
                ddlVechManuf.DataValueField = "Make_ID_PK";
                ddlVechManuf.DataBind();
                ddlVechManuf.Items.Insert(0, "--Select--");
                dsresult = null;
            }
            else
            {
                ddlVechManuf.Enabled = false;
                ddlVechManuf.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region VechicleType()
    //To display list of caste category from IsysLookupParam table
    private void VechicleType()
    {
        try
        {
            if (ddlagntype.SelectedValue == "2")
            {
                oCommon.getDropDown(ddlTypeOfVehicle, "Vec_Typ", 1, "", 1);
            }
            //Added by Rahul on 20-4-2015 to disable ddlTypeOfVechile on Page_load start
            else
            {
                ddlTypeOfVehicle.Enabled = false;
            }
            //Added by Rahul on 20-4-2015 to disable ddlTypeOfVechile on Page_load end
            ddlTypeOfVehicle.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region AverageMonthlyIncome()
    private void AverageMonthlyIncome()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", ddlagntype.SelectedValue.Trim());
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlAvgMonthlyIncm.DataSource = dsresult;
                ddlAvgMonthlyIncm.DataTextField = "MnthVolVal";
                ddlAvgMonthlyIncm.DataValueField = "MnthVolCode";
                ddlAvgMonthlyIncm.DataBind();
            }
            else
            {
                ddlAvgMonthlyIncm.DataSource = null;
            }
            ddlAvgMonthlyIncm.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region Competitor Company volume()
    private void ComptCompyMonthlyVolum()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "ComptCmpny");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlMnthVol1.DataSource = dsresult;
                ddlMnthVol1.DataTextField = "MnthVolVal";
                ddlMnthVol1.DataValueField = "MnthVolCode";
                ddlMnthVol1.DataBind();
            }
            else
            {
                ddlMnthVol1.DataSource = null;
            }
            ddlMnthVol1.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region Competitor Company volume 2()
    private void ComptCompyMonthlyVolum2()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "ComptCmpny");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlMnthVol2.DataSource = dsresult;
                ddlMnthVol2.DataTextField = "MnthVolVal";
                ddlMnthVol2.DataValueField = "MnthVolCode";
                ddlMnthVol2.DataBind();
            }
            else
            {
                ddlMnthVol2.DataSource = null;
            }
            ddlMnthVol2.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region Business Monthly volume()
    private void BusinessMonthlyVol()
    {
        try
        {
            DataSet dsresult = new DataSet();
            Hashtable htavgmnth = new Hashtable();
            htavgmnth.Add("@AgnTypCode", "BusiVol");
            dsresult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAvgMonthVolum", htavgmnth);
            if (dsresult.Tables[0].Rows.Count > 0)
            {
                ddlRGIMnthVol.DataSource = dsresult;
                ddlRGIMnthVol.DataTextField = "MnthVolVal";
                ddlRGIMnthVol.DataValueField = "MnthVolCode";
                ddlRGIMnthVol.DataBind();
            }
            else
            {
                ddlRGIMnthVol.DataSource = null;
            }
            ddlRGIMnthVol.Items.Insert(0, "--Select--");
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
    #endregion ddlRGIMnthVol

    //All Profiling function added by Prathamesh 17-6-15
    #region CompetitorCompanyName1()
    //To display list of caste category from IsysLookupParam table
    private void CompetitorCompanyName1()
    {
        try
        {
            oCommon.getDropDown(ddlComp1Name, "ComptCompName", 1, "", 1);
            ddlComp1Name.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region CompetitorCompanyName2()
    //To display list of caste category from IsysLookupParam table
    private void CompetitorCompanyName2()
    {
        try
        {
            oCommon.getDropDown(ddlComp2Name, "ComptCompName", 1, "", 1);
            ddlComp2Name.Items.Insert(0, "--Select--");
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

    //All Profiling function added by Prathamesh 17-6-15
    #region TotalBusiness()
    private void TotalBusiness()
    {
        try
        {
            oCommon.getDropDown(ddlTotBsnMtr, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlTotBsnHlth, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnMtr, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnHlth, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlTotBsnComm, "Tot_Busi", 1, "", 1);
            oCommon.getDropDown(ddlRGIBsnComm, "Tot_Busi", 1, "", 1);
            ddlTotBsnHlth.Items.Insert(0, "--Select--");
            ddlTotBsnMtr.Items.Insert(0, "--Select--");
            ddlRGIBsnMtr.Items.Insert(0, "--Select--");
            ddlRGIBsnHlth.Items.Insert(0, "--Select--");
            ddlTotBsnComm.Items.Insert(0, "--Select--");
            ddlRGIBsnComm.Items.Insert(0, "--Select--");
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




    // Added By Prathamesh 17-6-15 for Profiling 
    #region Language checkbox visibility
    //Added by kalyani on 3-1-2014 to make visible languages checkbox on dropdown selection start
    protected void ddllanknow1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread1.Visible = true;
        lblqfwrite1.Visible = true;
        lblqfspeak1.Visible = true;
        //tdlanknow1.Attributes.Add("Style", "visibility:visible");
        cbpread.Visible = true;
        cbpwrite.Visible = true;
        cbpspeak.Visible = true;
    }
    protected void ddllanknow2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread1.Visible = true;
        lblqfwrite1.Visible = true;
        lblqfspeak1.Visible = true;
        cbpread2.Visible = true;
        cbpwrite2.Visible = true;
        cbpspeak2.Visible = true;
    }
    protected void ddllanknow3_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread2.Visible = true;
        lblqfwrite2.Visible = true;
        lblqfspeak2.Visible = true;
        cbpread3.Visible = true;
        cbpwrite3.Visible = true;
        cbpspeak3.Visible = true;
    }
    protected void ddllanknow4_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblqfread2.Visible = true;
        lblqfwrite2.Visible = true;
        lblqfspeak2.Visible = true;
        cbpread4.Visible = true;
        cbpwrite4.Visible = true;
        cbpspeak4.Visible = true;
    }
    //Added by kalyani on 3-1-2014 to make visible languages checkbox on dropdown selection end
    #endregion



    //This Function added by Prathamesh 17-6-15
    protected void rbotherexp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbotherexp.SelectedValue == "N")
        {
            SetEnabledfalseOtherexp();
        }
        else
        {
            SetEnabledOtherexp();
        }
    }


    //This Function added by Prathamesh 17-6-15
    protected void SetEnabledfalseOtherexp()
    {
        txtemprecordname1.Enabled = false;
        txtemprecordname1.Text = "";
        txtotherexpfrom1.Text = "";
        txtotherexpTo1.Text = "";
        txtotherexpfrom1.Enabled = false;
        txtotherexpTo1.Enabled = false;
        txtemprecordjobnature1.Text = "";
        txtemprecordfield1.Text = "";
        txtemprecordjobnature1.Enabled = false;
        txtemprecordfield1.Enabled = false;

        txtemprecordname2.Enabled = false;
        txtemprecordname2.Text = "";
        txtotherexpfrom2.Text = "";
        txtotherexpTo2.Text = "";
        txtotherexpfrom2.Enabled = false;
        txtotherexpTo2.Enabled = false;
        txtemprecordjobnature2.Text = "";
        txtemprecordfield2.Text = "";
        txtemprecordjobnature2.Enabled = false;
        txtemprecordfield2.Enabled = false;

        txtemprecordname3.Enabled = false;
        txtemprecordname3.Text = "";
        txtotherexpfrom3.Text = "";
        txtotherexpTo3.Text = "";
        txtotherexpfrom3.Enabled = false;
        txtotherexpTo3.Enabled = false;
        txtemprecordjobnature3.Text = "";
        txtemprecordfield3.Text = "";
        txtemprecordjobnature3.Enabled = false;
        txtemprecordfield3.Enabled = false;

    }


    //This Function added by Prathamesh 17-6-15
    # region METHOD "FillRequiredDataForCndBizPlan"

    protected void FillRequiredDataForCndBizPlan()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();

        htParam.Add("@CndNo", lblcndidDesc.Text.Trim());
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            //Added by Rachana for interview page 22/05/2013 start
            //Commented by rachana as interview module not required start
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd_interview5", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCnd_interview5", htParam );
            //if (dsResult.Tables[0].Rows.Count > 0)
            //{
            //    txtInterviewerName.Text = dsResult.Tables[0].Rows[0]["InterviewerName"].ToString();
            //    txtInterviewerComment.Text = dsResult.Tables[0].Rows[0]["InterviewerComment"].ToString();
            //    txtDTRegFrom.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["DateofInt"])).ToString(CommonUtility.DATE_FORMAT);
            //}
            //Commented by rachana as interview module not required end
            //Added by Rachana for interview page 22/05/2013 end
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "1")
                    {
                        txtbusinessplannooflives11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]);// Convert.ToString(dsResult.Tables[0].Rows[0]["NoofLives"]).Trim();
                        txtbusinessplansumassured11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]); //Convert.ToString(dsResult.Tables[0].Rows[0]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium11.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[0]["FYP"]).Trim();
                    }

                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "2")
                    {
                        txtbusinessplannooflives21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["NoofLives"]).Trim();
                        txtbusinessplannsumassured21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium21.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["FYP"]).Trim();
                    }

                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "3")
                    {
                        txtbusinessplannooflives31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["NoofLives"]).Trim();
                        txtbusinessplannsumassured31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["SumAssured"]);// Convert.ToString(dsResult.Tables[0].Rows[2]["SumAssured"]).Trim();
                        txtbusinessplannfirstyearpremium31.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["FYP"]).Trim();
                    }
                }
                txtrelativeworkdesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWorkDesc"]).Trim();
                txtpastachievement.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PastAchievement"]).Trim();

                if (Convert.ToString(dsResult.Tables[0].Rows[0]["IsFullTime"]) != null)
                {
                    if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["IsFullTime"]) == false)
                    {
                        rbtimework.SelectedValue = "0";
                    }
                    else
                        rbtimework.SelectedValue = "1";
                }


                if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]) != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]).Trim() != "")
                    {
                        rbrelatedemp.SelectedValue = dsResult.Tables[0].Rows[0]["RelativeAtWork"].ToString();
                    }

                }
                //Added by Rachana on 21/05/2013 for interview page start
                //Commented by rachana as interview module not required start
                //if (Request.QueryString["Type"] != null)
                //{
                //    if (Request.QueryString["Type"].ToString().Trim() == "IV")
                //    {

                //        txtInterviewerName.Text = dsResult.Tables[0].Rows[0]["InterviewerName"].ToString();
                //        txtInterviewerComment.Text = dsResult.Tables[0].Rows[0]["InterviewerComment"].ToString();
                //        //Added By Ibrahim Start , to substring time from date time on May 24, 2013 Start
                //        txtDTRegFrom.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["DateofInt"])).ToString(CommonUtility.DATE_FORMAT).Substring(0, 10);
                //        //txtDTRegFrom.Text = dsResult.Tables[0].Rows[0]["DateofInt"].ToString();
                //        //Added By Ibrahim Start , to substring time from date time on May 24, 2013 End
                //    }
                //}
                //Commented by rachana as interview module not required start
                //Added by Rachana on 21/05/2013 for interview page end
            }
        }

        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;

        }
        dsResult.Clear();
        dsResult = null;
        htParam.Clear();
        htParam = null;


    }

    #endregion


    //This Function added by Prathamesh 17-6-15
    #region METHOD 'GetPersonalInformation()' DEFINITION
    protected void GetPersonalInformation()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));

        try
        {
            //Changed by rachana on 25-11-2013 for candidate details at the time of candidate enquiry and approval cndno link start
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnddetails", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCnddetails", htParam );
            //Changed by rachana on 25-11-2013 for candidate details at the time of candidate enquiry and approval cndno link end

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                lblpfregdateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);//changes textbox to label by Prathamesh 17-6-15
                lblqcndno.Text = lblcndidDesc.Text.Trim();
                lblqregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblqgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblqsurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblqappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblecndno.Text = lblcndidDesc.Text.Trim();
                lbleregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblegivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblesurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lbleappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblpcndno.Text = lblcndidDesc.Text.Trim();
                lblpregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblpgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblpSurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblpappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();

                lblbcndno.Text = lblcndidDesc.Text.Trim();
                lblbregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                lblbgivenname.Text = dsResult.Tables[0].Rows[0]["givenname"].ToString();
                lblbSurname.Text = dsResult.Tables[0].Rows[0]["surname"].ToString();
                lblbappno.Text = dsResult.Tables[0].Rows[0]["ProspectID"].ToString();
                hdnCndNo.Value = lblcndidDesc.Text;

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;

        }

    }
    #endregion


    //This Function added by Prathamesh 17-6-15
    # region Method "FillRequiredDataForCndQualification"
    protected void FillRequiredDataForCndQualification()
    {

        DataSet dsResult = new DataSet();


        Hashtable htParam = new Hashtable();

        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page start
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            //htParam.Add("@CndNo", strProspectID);
            htParam.Add("@CndNo", hdnCndNo.Value);
        }
        else
        {
            htParam.Add("@CndNo", lblcndidDesc.Text.Trim());
        }
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page end
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd2", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCnd2", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]).Trim() != "")
                        {
                            string[] sLang = Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]).Trim().Split(new char[] { '-' });
                            FillLanguage(ddllanknow1, cbpread, cbpwrite, cbpspeak, sLang[1].ToString());
                            FillLanguage(ddllanknow2, cbpread2, cbpwrite2, cbpspeak2, sLang[2].ToString());
                            FillLanguage(ddllanknow3, cbpread3, cbpwrite3, cbpspeak3, sLang[3].ToString());
                            FillLanguage(ddllanknow4, cbpread4, cbpwrite4, cbpspeak4, sLang[4].ToString());

                        }

                    }

                    //...gaurav..15/10/2012

                    //if (Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]) != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]).Trim() != "")
                    //    {
                    //        cboQualCode.SelectedValue= Convert.ToString(dsResult.Tables[0].Rows[0]["QualCode"]).Trim();
                    //    }

                    //}
                    //...gaurav..15/10/12
                    //Added by pranjali on 10-03-2014 for filling the highest qualification start
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim() != "")
                        {
                            cboQualCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim();
                            cboQualCode.Enabled = false;
                        }

                    }
                    //Added by pranjali on 10-03-2014 for filling the highest qualification end

                    txtinsurancequalification.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["InsQualDesc"]).Trim();
                    txtOccupationCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OccpnCode"]).Trim();
                    txtOccupationDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Occupdesc"]).Trim();
                    txtempaddress.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["EmpAddress"]).Trim();
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["CreditCard"]).Trim() == "Y")
                            {
                                cbCreCard.Checked = true;
                            }
                            else
                            {
                                cbCreCard.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["GeneralInsurance"]).Trim() == "Y")
                            {
                                cbGenIns.Checked = true;
                            }
                            else
                            {
                                cbGenIns.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["MutualFund"]).Trim() == "Y")
                            {
                                cbMutFund.Checked = true;
                            }
                            else
                            {
                                cbMutFund.Checked = false;

                            }
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]).Trim() != "")
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["LifeInsurance"]).Trim() == "Y")
                            {
                                cbLifeIns.Checked = true;
                            }
                            else
                            {
                                cbLifeIns.Checked = false;

                            }
                        }

                    }

                    txtOtherProduct.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["otherproducts"]).Trim();

                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;

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


    //This Function added by Prathamesh 17-6-15
    # region METHOD "FillRequiredDataForCndPsnlhistory"
    protected void FillRequiredDataForCndPsnlhistory()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            //Added by swapnesh for inserting Disciplinary info data on 20_5_2013 start

            if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
            {
                htParam.Add("@CndNo", strProspectID);
            }
            else
            {
                htParam.Add("@CndNo", lblcndidDesc.Text.Trim());
            }

            //Added by swapnesh for inserting Disciplinary info data on 20_5_2013 end
            htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
            //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd4", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCnd4", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]).Trim() != "")
                        {
                            rbQstn01.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn01"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]).Trim() != "")
                        {
                            rbQstn02.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn02"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]).Trim() != "")
                        {
                            rbQstn03.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn03"].ToString();
                        }

                    }
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]) != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]).Trim() != "")
                        {
                            rbQstn04.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn04"].ToString();
                        }

                    }
                    txtRef1Name.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName01"]).Trim();
                    txtRef2Name.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName02"]).Trim();

                    for (int a = 0; a < dsResult.Tables[0].Rows.Count; a++)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C1")
                        {
                            txtRef1Add1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
                            txtRef1Add2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
                            txtRef1Add3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
                            txtRef1Pin.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
                            txtStateCodeR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateCode"]).Trim();
                            txtCountryCodeR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CntryCode"]).Trim();
                            txtStateDescR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc"]).Trim();
                            txtCountryDescR1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc"]).Trim();

                        }

                        if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C2")
                        {
                            txtRef2Add1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
                            txtRef2Add2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
                            txtRef2Add3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
                            txtRef2Pin.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
                            txtStateCodeR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateCode"]).Trim();
                            txtCountryCodeR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CntryCode"]).Trim();
                            txtStateDescR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc2"]).Trim();
                            txtCountryDescR2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc2"]).Trim();
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

    //This Function added by Prathamesh 17-6-15
    # region METHOD "FillRequiredDataForCndEmpHistory"

    protected void FillRequiredDataForCndEmpHistory()
    {
        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        //Added by swapnesh for inserting Emp history data on 20_5_2013 start

        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page start
        if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        {
            htParam.Add("@CndNo", strProspectID);
        }
        else
        {
            htParam.Add("@CndNo", lblcndidDesc.Text.Trim());
        }
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page end


        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        try
        {
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCnds03", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString() == "Y")
                    {
                        rbinsagency.SelectedValue = "Y";
                        txtInsCompName.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["LcnNo"]);
                        txtInsAgencyCode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAgentCode"]);
                        txtTerminationReason.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        if (dsResult.Tables[0].Rows[i]["IsInsExp"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString().Trim() != "")
                            {
                                rbinsagency.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["IsInsExp"]);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["LcnIssDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["LcnIssDate"].ToString().Trim() != "")
                            {
                                txtdateofissue.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["LcnExpDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["LcnExpDate"].ToString().Trim() != "")
                            {
                                txtvaliddate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["CseDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["CseDate"].ToString().Trim() != "")
                            {
                                txtterminatedate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["CseDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        SetEnabledtrue();
                    }

                    else
                    {

                        SetEnabledfalse();
                    }
                }

            }
            else
            {
                rbinsagency.SelectedValue = "N";
                SetEnabledfalse();
            }


            dsResult.Dispose();
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("[prc_CndAdmin_getCnds3]", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 1)
                    {
                        txtPrevEmpName1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome1.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 2)
                    {
                        txtPrevEmpName2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome2.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }


                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 3)
                    {
                        txtPrevEmpName3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome3.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["AnnIncome"]);
                        txtreasforleave3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 4)
                    {
                        txtPrevEmpName4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome4.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]); //Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl4.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }


                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 5)
                    {
                        txtPrevEmpName5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome5.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);// Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl5.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                    if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 6)
                    {
                        txtPrevEmpName6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
                        txtLastIncome6.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[i]["AnnIncome"]);// Convert.ToString(dsResult.Tables[0].Rows[i]["AnnIncome"]);
                        txtreasforleave6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
                        txtaddofemp6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAdr"]);

                        if (dsResult.Tables[0].Rows[i]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["StartDate"].ToString().Trim() != "")
                            {
                                txtfrom6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[i]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["EndDate"].ToString().Trim() != "")
                            {
                                txtto6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }

                        if (dsResult.Tables[0].Rows[i]["PositionHeld"] != null)
                        {
                            if (dsResult.Tables[0].Rows[i]["PositionHeld"].ToString().Trim() != "")
                            {
                                txtEmpLvl6.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PositionHeld"]);
                            }
                        }
                    }

                }

            }
            dsResult.Dispose();
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("[prc_CndAdmin_getCnd3]", htParam);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                rbotherexp.SelectedValue = "Y";
                for (int j = 0; j < dsResult.Tables[0].Rows.Count; j++)
                {

                    txtemprecordname1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CompName"]);
                    txtemprecordjobnature1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTypeDesc"]);
                    txtemprecordfield1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkField"]);

                    if (dsResult.Tables[0].Rows[0]["StartDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["StartDate"].ToString().Trim() != "")
                        {
                            txtotherexpfrom1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }
                    if (dsResult.Tables[0].Rows[0]["EndDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EndDate"].ToString().Trim() != "")
                        {
                            txtotherexpTo1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }

                    if (j == 1)
                    {
                        txtemprecordname2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["CompName"]);
                        txtemprecordjobnature2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["WorkTypeDesc"]);
                        txtemprecordfield2.Text = Convert.ToString(dsResult.Tables[0].Rows[1]["WorkField"]);

                        if (dsResult.Tables[0].Rows[1]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[1]["StartDate"].ToString().Trim() != "")
                            {
                                txtotherexpfrom2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[1]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[1]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[1]["EndDate"].ToString().Trim() != "")
                            {
                                txtotherexpTo2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[1]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                    }

                    if (j == 2)
                    {
                        txtemprecordname3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["CompName"]);
                        txtemprecordjobnature3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["WorkTypeDesc"]);
                        txtemprecordfield3.Text = Convert.ToString(dsResult.Tables[0].Rows[2]["WorkField"]);

                        if (dsResult.Tables[0].Rows[2]["StartDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[2]["StartDate"].ToString().Trim() != "")
                            {
                                txtotherexpfrom3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[2]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                        if (dsResult.Tables[0].Rows[2]["EndDate"] != null)
                        {
                            if (dsResult.Tables[0].Rows[2]["EndDate"].ToString().Trim() != "")
                            {
                                txtotherexpTo3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[2]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                        }
                    }
                }
            }
            else
            {
                rbotherexp.SelectedValue = "N";
                SetEnabledfalseOtherexp();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;

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

    //This Function added by Prathamesh 17-6-15
    # region METHOD "FillLanguage Checking"
    public void FillLanguage(DropDownList ddl, CheckBox cb1, CheckBox cb2, CheckBox cb3, string slanguage)
    {
        string[] sSplit = slanguage.Split(new char[] { '|' });
        ddl.SelectedValue = sSplit[1].ToString();
        if (sSplit[2].ToString() == "Y")
        {
            cb1.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb1.Visible = true;
            lblqfread1.Visible = true;
            lblqfread2.Visible = true;
        }
        else
        {
            cb1.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb1.Visible = true;
            lblqfread1.Visible = true;
            lblqfread2.Visible = true;
        }
        if (sSplit[3].ToString() == "Y")
        {
            cb2.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb2.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfwrite2.Visible = true;
        }
        else
        {
            cb2.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb2.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfwrite2.Visible = true;
        }
        if (sSplit[4].ToString() == "Y")
        {
            cb3.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb3.Visible = true;
            lblqfspeak1.Visible = true;
            lblqfspeak2.Visible = true;
        }
        else
        {
            cb3.Checked = false;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb3.Visible = true;
            lblqfspeak1.Visible = true;
            lblqfspeak2.Visible = true;
        }

    }
    #endregion


    //This Function added by Prathamesh 17-6-15
    protected void SetEnabledOtherexp()
    {
        txtemprecordname1.Enabled = true;

        txtotherexpfrom1.Enabled = true;
        txtotherexpTo1.Enabled = true;

        txtemprecordjobnature1.Enabled = true;
        txtemprecordfield1.Enabled = true;

        txtemprecordname2.Enabled = true;

        txtotherexpfrom2.Enabled = true;
        txtotherexpTo2.Enabled = true;

        txtemprecordjobnature2.Enabled = true;
        txtemprecordfield2.Enabled = true;

        txtemprecordname3.Enabled = true;

        txtotherexpfrom3.Enabled = true;
        txtotherexpTo3.Enabled = true;

        txtemprecordjobnature3.Enabled = true;
        txtemprecordfield3.Enabled = true;

    }

    //This Function added by Prathamesh 17-6-15
    #region METHOD 'rdagnexp_SelectedIndexChanged' DEFINITION
    protected void rdagnexp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbinsagency.SelectedValue == "N")
        {
            SetEnabledfalse();
        }
        else
        {
            SetEnabledtrue();
        }
    }

    #endregion


    //This Function added by Prathamesh 17-6-15
    #region METHOD 'FillHiddenValues()' DEFINITION
    protected void FillHiddenValues()
    {
        olng = new multilingualManager("DefaultConn", "CndReg.aspx", Session["UserLangNum"].ToString());
        if (MultiView1.ActiveViewIndex == 0)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2601");
            hdnID270.Value = olng.GetItemDesc("hdnID2701");
            hdnID280.Value = olng.GetItemDesc("hdnID2801");
            hdnID290.Value = olng.GetItemDesc("hdnID2901");
            hdnID300.Value = olng.GetItemDesc("hdnID3001");
            hdnID310.Value = olng.GetItemDesc("hdnID3101");
            hdnID320.Value = olng.GetItemDesc("hdnID3201");
            hdnID330.Value = olng.GetItemDesc("hdnID3301");
            hdnID340.Value = olng.GetItemDesc("hdnID3401");
            hdnID350.Value = olng.GetItemDesc("hdnID3501");
            hdnID360.Value = olng.GetItemDesc("hdnID3601");
            hdnID370.Value = olng.GetItemDesc("hdnID3701");
            hdnID380.Value = olng.GetItemDesc("hdnID3801");
            hdnID390.Value = olng.GetItemDesc("hdnID3901");
            hdnID400.Value = olng.GetItemDesc("hdnID4001");
            hdnID410.Value = olng.GetItemDesc("hdnID4101");
            hdnID420.Value = olng.GetItemDesc("hdnID4201");
            hdnID430.Value = olng.GetItemDesc("hdnID4301");
            hdnID440.Value = olng.GetItemDesc("hdnID4401");
            hdnID450.Value = olng.GetItemDesc("hdnID4501");
            hdnID460.Value = olng.GetItemDesc("hdnID4601");
            hdnID470.Value = olng.GetItemDesc("hdnID4701");
            hdnID480.Value = olng.GetItemDesc("hdnID4801");
            hdnID490.Value = olng.GetItemDesc("hdnID4901");
            hdnID500.Value = olng.GetItemDesc("hdnID5001");
            hdnID510.Value = olng.GetItemDesc("hdnID5101");
            hdnID520.Value = olng.GetItemDesc("hdnID5201");
            hdnID530.Value = olng.GetItemDesc("hdnID5301");
            hdnID540.Value = olng.GetItemDesc("hdnID5401");
            hdnID550.Value = olng.GetItemDesc("hdnID5501");
            hdnID560.Value = olng.GetItemDesc("hdnID5601");
            hdnID570.Value = olng.GetItemDesc("hdnID5701");
            hdnID580.Value = olng.GetItemDesc("hdnID5801");
            hdnID590.Value = olng.GetItemDesc("hdnID5901");
            hdnID600.Value = olng.GetItemDesc("hdnID6001");
            hdnID610.Value = olng.GetItemDesc("hdnID6101");
            hdnID620.Value = olng.GetItemDesc("hdnID6201");
            hdnID630.Value = olng.GetItemDesc("hdnID6301");
            hdnID640.Value = olng.GetItemDesc("hdnID6401");
            hdnID650.Value = olng.GetItemDesc("hdnID6501");
            hdnID660.Value = olng.GetItemDesc("hdnID6601");
            hdnID670.Value = olng.GetItemDesc("hdnID6701");

        }
        else if (MultiView1.ActiveViewIndex == 1)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2602");
            hdnID270.Value = olng.GetItemDesc("hdnID2702");
            hdnID280.Value = olng.GetItemDesc("hdnID2802");
            hdnID290.Value = olng.GetItemDesc("hdnID2902");

            //Open Newly added on 21-01-08
            hdnID300.Value = olng.GetItemDesc("hdnID3002");
            //End Newly added on 21-01-08

        }
        else if (MultiView1.ActiveViewIndex == 2)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2603");
            hdnID270.Value = olng.GetItemDesc("hdnID2703");
            hdnID280.Value = olng.GetItemDesc("hdnID2803");
            hdnID290.Value = olng.GetItemDesc("hdnID2903");
            hdnID300.Value = olng.GetItemDesc("hdnID3003");
            hdnID310.Value = olng.GetItemDesc("hdnID3103");
            hdnID320.Value = olng.GetItemDesc("hdnID3203");
            hdnID330.Value = olng.GetItemDesc("hdnID3303");
            hdnID340.Value = olng.GetItemDesc("hdnID3403");
            hdnID350.Value = olng.GetItemDesc("hdnID3503");
            hdnID360.Value = olng.GetItemDesc("hdnID3603");
            hdnID370.Value = olng.GetItemDesc("hdnID3703");
            hdnID380.Value = olng.GetItemDesc("hdnID5103");
            hdnID390.Value = olng.GetItemDesc("hdnID3903");
            hdnID400.Value = olng.GetItemDesc("hdnID4003");
            hdnID410.Value = olng.GetItemDesc("hdnID4103");
            hdnID420.Value = olng.GetItemDesc("hdnID4203");
            hdnID430.Value = olng.GetItemDesc("hdnID4303");
            hdnID440.Value = olng.GetItemDesc("hdnID4403");
            hdnID450.Value = olng.GetItemDesc("hdnID4503");
            hdnID460.Value = olng.GetItemDesc("hdnID4603");
            hdnID470.Value = olng.GetItemDesc("hdnID4703");
            hdnID480.Value = olng.GetItemDesc("hdnID4803");

        }
        else if (MultiView1.ActiveViewIndex == 3)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2604");
            hdnID270.Value = olng.GetItemDesc("hdnID2704");
            hdnID280.Value = olng.GetItemDesc("hdnID2804");
            hdnID290.Value = olng.GetItemDesc("hdnID2904");
            hdnID300.Value = olng.GetItemDesc("hdnID3004");
            hdnID310.Value = olng.GetItemDesc("hdnID3104");
            hdnID320.Value = olng.GetItemDesc("hdnID3204");
            hdnID330.Value = olng.GetItemDesc("hdnID3304");


        }
        else if (MultiView1.ActiveViewIndex == 4)
        {
            hdnID260.Value = olng.GetItemDesc("hdnID2605");
            hdnID270.Value = olng.GetItemDesc("hdnID2705");
            hdnID280.Value = olng.GetItemDesc("hdnID2805");
            hdnID290.Value = olng.GetItemDesc("hdnID2905");
            hdnID300.Value = olng.GetItemDesc("hdnID3005");
            hdnID310.Value = olng.GetItemDesc("hdnID3105");

        }
    }
    #endregion


    #region METHOD "InitializeControl()"
    private void InitializeControl()
    {
        try
        {





            //is Specific person 
            lblIsSPFlag.Text = olng.GetItemDesc("lblIsSPFlag");
            lblCACode.Text = olng.GetItemDesc("lblCACode");
            lblCAName.Text = olng.GetItemDesc("lblCAName");


            //Personal Tab
            lblcategory.Text = olng.GetItemDesc("lblcategory");
            lblpfPersonal.Text = olng.GetItemDesc("lblpfPersonal");
            lblpfcndid.Text = olng.GetItemDesc("lblpfcndid");
            lblpfappno.Text = olng.GetItemDesc("lblpfappno");
            lblpfregdate.Text = olng.GetItemDesc("lblpfregdate");
            lblpfgivenName.Text = olng.GetItemDesc("lblpfgivenName");
            lblpfSurName.Text = olng.GetItemDesc("lblpfSurName");
            lblpffathername.Text = olng.GetItemDesc("lblpffathername");
            lblpfGender.Text = olng.GetItemDesc("lblpfGender");
            lblpfdob.Text = olng.GetItemDesc("lblpfdob");
            lblICdate.Text = olng.GetItemDesc("lblICdate");
            lblCndUrn.Text = olng.GetItemDesc("lblCndUrn");
            //added to viewstate
            ViewState["lblCndUrn"] = lblCndUrn.Text;
            //comment by Prathamesh 17-6-15
            //lblCndUrnv2.Text = olng.GetItemDesc("lblCndUrn");
            //lblCndUrnV3.Text = olng.GetItemDesc("lblCndUrn");
            //lblCndUrnV4.Text = olng.GetItemDesc("lblCndUrn");
            //lblCndUrnV5.Text = olng.GetItemDesc("lblCndUrn");

            lblpfmaritalstatus.Text = olng.GetItemDesc("lblpfmaritalstatus");
            lblpfNationality.Text = olng.GetItemDesc("lblpfNationality");
            lblpfpan.Text = olng.GetItemDesc("lblpfpan");
            //lblpfcompaymode.Text = olng.GetItemDesc("lblpfcompaymode");//Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field
            lblOldLcnexpDate.Text = olng.GetItemDesc("lblOldLcnexpDate.Text");
            lblComplicnseExpDt.Text = olng.GetItemDesc("lblComplicnseExpDt");
            lblpfrecinfotitle.Text = olng.GetItemDesc("lblpfrecinfotitle");
            //Recruiting
            lblpfsalchannel.Text = olng.GetItemDesc("lblpfsalchannel");
            lblpfchasubclass.Text = olng.GetItemDesc("lblpfchasubclass");
            lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
            lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
            lblpfsmname.Text = olng.GetItemDesc("lblpfsmname");
            //lblpfbesmcode.Text = olng.GetItemDesc("lblpfbesmcode");

            //Reporting
            //lblpfberptcode.Text = olng.GetItemDesc("lblpfbesmcode"); 
            //lblpfsalchannelrpt.Text = olng.GetItemDesc("lblpfsalchannel"); 
            //lblpfagetyperpt.Text = olng.GetItemDesc("lblpfagetype"); 
            //lblpfsmnamerpt.Text = olng.GetItemDesc("lblpfsmname");
            ////lblsapcoderpt
            //lblpfchasubclassrpt.Text = olng.GetItemDesc("lblpfchasubclass");
            //lblpfimmleaderrpt.Text = olng.GetItemDesc("lblpfimmleader");
            //lblCandAgntTyperpt

            lblNOCAck.Text = olng.GetItemDesc("lblNOCAck");
            lblPanachayat.Text = olng.GetItemDesc("lblPanachayat");
            lblPhotoSign.Text = olng.GetItemDesc("lblPhotoSign");
            lblYrPass.Text = olng.GetItemDesc("lblYrPass");
            lblBasicRNo.Text = olng.GetItemDesc("lblBasicRNo");
            lblBoardName.Text = olng.GetItemDesc("lblBoardName");
            lblBasicQual.Text = olng.GetItemDesc("lblBasicQual");
            lblCandAgntTyperpt.Text = olng.GetItemDesc("lblCandAgntTyperpt");
            lblpfsmnamerpt.Text = olng.GetItemDesc("lblpfsmnamerpt");
            lblpfimmleaderrpt.Text = olng.GetItemDesc("lblpfimmleaderrpt");
            lblpfagetyperpt.Text = olng.GetItemDesc("lblpfagetyperpt");
            lblpfchasubclassrpt.Text = olng.GetItemDesc("lblpfchasubclassrpt");
            lblpfsalchannelrpt.Text = olng.GetItemDesc("lblpfsalchannelrpt");
            lblpfberptcode.Text = olng.GetItemDesc("lblpfberptcode");


            lblpfpresentadd.Text = "Address Details";
            lblpfaddresstype.Text = olng.GetItemDesc("lblpfaddresstype");
            lblpfAddrP1.Text = olng.GetItemDesc("lblpfAddrP1");
            //lblVillage.Text = olng.GetItemDesc("lblVillage"); //Added by Prathamesh 16-9-15 
            lblpfStateP.Text = olng.GetItemDesc("lblpfStateP");
            lblpfPinP.Text = olng.GetItemDesc("lblpfPinP");
            lblpfCountryP.Text = olng.GetItemDesc("lblpfCountryP");
            lblpfPrmAddTitle.Text = olng.GetItemDesc("lblpfPrmAddTitle");
            //lblpfprmAdd.Text = olng.GetItemDesc("lblpfprmAdd");
            lblpfprmstatecode.Text = olng.GetItemDesc("lblpfprmstatecode");
            lblpfprmpostcode.Text = olng.GetItemDesc("lblpfprmpostcode");
            lblpfprmcountry.Text = olng.GetItemDesc("lblpfprmcountry");
            lblpfconpreferred.Text = olng.GetItemDesc("lblpfconpreferred");
            lblpfhometel.Text = olng.GetItemDesc("lblpfhometel");
            lblpfofftel.Text = olng.GetItemDesc("lblpfofftel");

            lblpfprodoctitle.Text = olng.GetItemDesc("lblpfprodoctitle");

            lblpfeduproof.Text = olng.GetItemDesc("lblpfeduproof");
            lblpfphoto.Text = olng.GetItemDesc("lblpfphoto");
            lblpfmarksheet.Text = olng.GetItemDesc("lblpfmarksheet");
            lblpfcertificate.Text = olng.GetItemDesc("lblpfcertificate");

            lblAckrcv.Text = olng.GetItemDesc("lblAckrcv.Text");

            LblProfQual.Text = olng.GetItemDesc("LblProfQual");//added by meena as requested by RHIC
            LblInsQual.Text = olng.GetItemDesc("LblInsQual");//added by meena as requested by RHIC


            lblCandAgntType.Text = "Agent Type";//olng.GetItemDesc("lblCandAgntType");
            chkCompAgnt.Text = olng.GetItemDesc("chkCompAgnt");//added by shreela 
            //Qualification
            lblqfpersonalinformation.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lblqfcndnotitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lblqfappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lblqfregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lblqfgivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lblqfsurname.Text = olng.GetItemDesc("lblqfsurname");

            //Personal details to viewstate 
            ViewState["lblqfpersonalinformation"] = lblqfpersonalinformation.Text;
            ViewState["lblqfcndnotitle"] = lblqfcndnotitle.Text;
            ViewState["lblqfappnotitle"] = lblqfappnotitle.Text;
            ViewState["lblqfregdatetitle"] = lblqfregdatetitle.Text;
            ViewState["lblqfgivennametitle"] = lblqfgivennametitle.Text;
            ViewState["lblqfsurname"] = lblqfsurname.Text;
            lblqfknolanguagestitle.Text = olng.GetItemDesc("lblqfknolanguagestitle");
            lblqflanguagesKnown1.Text = olng.GetItemDesc("lblqflanguagesKnown1");
            lblqflanguage1.Text = olng.GetItemDesc("lblqflanguage1");
            lblqfread1.Text = olng.GetItemDesc("lblqfread1");
            lblqfwrite1.Text = olng.GetItemDesc("lblqfwrite1");
            lblqfspeak1.Text = olng.GetItemDesc("lblqfspeak1");

            //lblqflanguagesKnown3.Text = olng.GetItemDesc("lblqflanguagesKnown1");//comment by Prathamesh 17-6-15
            lblqflanguage2.Text = olng.GetItemDesc("lblqflanguage1");
            lblqfread2.Text = olng.GetItemDesc("lblqfread1");
            lblqfwrite2.Text = olng.GetItemDesc("lblqfwrite1");
            lblqfspeak2.Text = olng.GetItemDesc("lblqfspeak1");

            lbqfloccqualification.Text = olng.GetItemDesc("lbqfloccqualification");
            lblqfHigestQul.Text = olng.GetItemDesc("lblqfHigestQul");
            lblqfinsqualification.Text = olng.GetItemDesc("lblqfinsqualification");
            lblqfoccupation.Text = olng.GetItemDesc("lblqfoccupation");
            lblqfempaddress.Text = olng.GetItemDesc("lblqfempaddress");
            lblqfdoyouhave.Text = olng.GetItemDesc("lblqfdoyouhave");
            lblqffromreliance.Text = olng.GetItemDesc("lblqffromreliance");
            lblqffromothers.Text = olng.GetItemDesc("lblqffromothers");
            cbMutFund.Text = olng.GetItemDesc("cbMutFund");
            cbLifeIns.Text = olng.GetItemDesc("cbLifeIns");
            cbGenIns.Text = olng.GetItemDesc("cbGenIns");
            cbCreCard.Text = olng.GetItemDesc("cbCreCard");

            ////Employement History

            lblehtpersonalinformation.Text = olng.GetItemDesc("lblehtpersonalinformation");
            lblehcndnotitle.Text = olng.GetItemDesc("lblehcndnotitle");
            lblehappnotitle.Text = olng.GetItemDesc("lblehappnotitle");
            lblehregdatetitle.Text = olng.GetItemDesc("lblehregdatetitle");
            lblehgivennametitle.Text = olng.GetItemDesc("lblehgivennametitle");
            lblehsurnametitle.Text = olng.GetItemDesc("lblehsurnametitle");
            lblehEmpHistory.Text = olng.GetItemDesc("lblehEmpHistory");
            lblehbeginning.Text = olng.GetItemDesc("lblehbeginning");
            lblehfrom.Text = olng.GetItemDesc("lblehfrom");
            lblehto.Text = olng.GetItemDesc("lblehto");
            lblehname.Text = olng.GetItemDesc("lblehname");
            lblehaddofemp.Text = olng.GetItemDesc("lblehaddofemp");
            lbllehastposition.Text = olng.GetItemDesc("lbllehastposition");
            lblehannincome.Text = olng.GetItemDesc("lblehannincome");
            lblehresforleave.Text = olng.GetItemDesc("lblehresforleave");
            lblehexperience.Text = olng.GetItemDesc("lblehexperience");
            lblehhaveyou.Text = olng.GetItemDesc("lblehhaveyou");
            lblehcompanyname.Text = olng.GetItemDesc("lblehcompanyname");
            lblehcnfrom.Text = olng.GetItemDesc("lblehcnfrom");
            lblehcnto.Text = olng.GetItemDesc("lblehcnto");
            lblehcnjobnature.Text = olng.GetItemDesc("lblehcnjobnature");
            lblehcnfield.Text = olng.GetItemDesc("lblehcnfield");
            lblehdetofinsagcy.Text = olng.GetItemDesc("lblehdetofinsagcy");
            lblehgerlifeinscompy.Text = olng.GetItemDesc("lblehgerlifeinscompy");
            lblehnameofcomp.Text = olng.GetItemDesc("lblehnameofcomp");
            lblehlicno.Text = olng.GetItemDesc("lblehlicno");
            lblehdateofissue.Text = olng.GetItemDesc("lblehdateofissue");
            lblehvaliddate.Text = olng.GetItemDesc("lblehvaliddate");
            lblehagencycode.Text = olng.GetItemDesc("lblehagencycode");
            lblehterminationdate.Text = olng.GetItemDesc("lblehterminationdate");
            lblehterreason.Text = olng.GetItemDesc("lblehterreason");

            ////Discipilnary Info Tab
            lblpersonalinformation.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lbldicndidtitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lbldiappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lbldiregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lbldigivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lbldisurnametitle.Text = olng.GetItemDesc("lblqfsurname");
            lbldidisinformation.Text = olng.GetItemDesc("lbldidisinformation");
            lbldihybconvicted.Text = olng.GetItemDesc("lbldihybconvicted");
            lbldihybsubject.Text = olng.GetItemDesc("lbldihybsubject");
            lbldihybjudgement.Text = olng.GetItemDesc("lbldihybjudgement");
            lbldihybinsolv.Text = olng.GetItemDesc("lbldihybinsolv");
            lbldireference.Text = olng.GetItemDesc("lbldireference");
            lblditrefname1.Text = olng.GetItemDesc("lblditrefname1");
            lbldiref1address.Text = olng.GetItemDesc("lbldiref1address");
            lbldiRef1state.Text = olng.GetItemDesc("lbldiRef1state");
            lbldiRef1Pincode.Text = olng.GetItemDesc("lbldiRef1Pincode");
            lbldiRef1country.Text = olng.GetItemDesc("lbldiRef1country");
            lbldiRefname2.Text = olng.GetItemDesc("lbldiRefname2");
            lbldiRef2Add.Text = olng.GetItemDesc("lbldiRef2Add");
            lbldiRef2State.Text = olng.GetItemDesc("lbldiRef2State");
            lbldiRef2Pincode.Text = olng.GetItemDesc("lbldiRef2Pincode");
            lbldiRef2Country.Text = olng.GetItemDesc("lbldiRef2Country");
            lblbppersinftitle.Text = olng.GetItemDesc("lblbppersinftitle");
            lblbpEmpHistory1.Text = olng.GetItemDesc("lblbpEmpHistory1");

            ////Biz Plan Tab
            lblbppersinftitle.Text = olng.GetItemDesc("lblqfpersonalinformation");
            lblbpcndnotitle.Text = olng.GetItemDesc("lblqfcndnotitle");
            lblbpappnotitle.Text = olng.GetItemDesc("lblqfappnotitle");
            lblbpregdatetitle.Text = olng.GetItemDesc("lblqfregdatetitle");
            lblbpgivennametitle.Text = olng.GetItemDesc("lblqfgivennametitle");
            lblbpsurnametitle.Text = olng.GetItemDesc("lblqfsurname");
            lblbptyear.Text = olng.GetItemDesc("lblbptyear");
            //lbltnooflives.Text = olng.GetItemDesc("lbltnooflives");
            lbltsumassured.Text = olng.GetItemDesc("lbltsumassured");
            lbltfirstyearpremium.Text = olng.GetItemDesc("lbltfirstyearpremium");
            lblbpyear1.Text = olng.GetItemDesc("lblbpyear1");
            lblbpyear2.Text = olng.GetItemDesc("lblbpyear2");
            lblbpyear3.Text = olng.GetItemDesc("lblbpyear3");
            lblbpwillingtowork.Text = olng.GetItemDesc("lblbpwillingtowork");
            lblbpanyotherinformation.Text = olng.GetItemDesc("lblbpanyotherinformation");
            ////...gaurav..11/10/12
            //Exam Details Section
            //lblSystemDt.Text = olng.GetItemDesc("lblSystemDt");
            //lblCreatDt.Text = olng.GetItemDesc("lblCreatDt");
            //lblpreffDt1.Text = olng.GetItemDesc("lblpreffDt1");
            //lblpreffDt2.Text = olng.GetItemDesc("lblpreffDt2");
            //lblexmdetails.Text = olng.GetItemDesc("lblexmdetails");

            //Additional exam details
            //lblExmStrtTime.Text = olng.GetItemDesc("lblExmStrtTime"); // Exam Start Time
            //lblExmVenue.Text = olng.GetItemDesc("lblExmVenue"); //   Exam Venue
            //lblExmResult.Text = olng.GetItemDesc("lblExmResult"); //   Exam Result
            //lblExmAssStat.Text = olng.GetItemDesc("lblExmAssStat"); //   Is Exam completed
            //lblExmBody.Text = olng.GetItemDesc("lblExmBody"); //   Exam Body
            //lblRemarks.Text = olng.GetItemDesc("lblRemarks"); //   Remarks
            //lblRollNo.Text = olng.GetItemDesc("lblRollNo"); //   Roll No
            //lblExmMark.Text = olng.GetItemDesc("lblExmMark"); //   Exam Start Time
            //lblExmMode.Text = olng.GetItemDesc("lblExmMode"); //   Exam Venue
            //lblExmCenter.Text = olng.GetItemDesc("lblExmCenter"); //   Exam Venue
            //lblRecruiterName.Text = olng.GetItemDesc("lblRecruiterName"); //   Recruiter Name
            //lblSAPCode.Text = olng.GetItemDesc("lblSAPCode"); //   SAP Code
            ViewState["lblexmdetails"] = olng.GetItemDesc("lblexmdetails");
            ViewState["lblSystemDt"] = olng.GetItemDesc("lblSystemDt");
            ViewState["lblCreatDt"] = olng.GetItemDesc("lblCreatDt");
            ViewState["lblpreffDt1"] = olng.GetItemDesc("lblpreffDt1");
            ViewState["lblpreffDt2"] = olng.GetItemDesc("lblpreffDt2");
            ViewState["lblpreffDt2"] = olng.GetItemDesc("lblpreffDt2");
            ViewState["lblExmLang"] = olng.GetItemDesc("lblExmLang");

            ViewState["lblExmStrtTime"] = olng.GetItemDesc("lblExmStrtTime"); // Exam Start Time
            ViewState["lblExmVenue"] = olng.GetItemDesc("lblExmVenue"); //   Exam Venue
            ViewState["lblExmResult"] = olng.GetItemDesc("lblExmResult"); //   Exam Result
            ViewState["lblExmAssStat"] = olng.GetItemDesc("lblExmAssStat"); //   Is Exam completed
            ViewState["lblExmBody"] = olng.GetItemDesc("lblExmBody"); //   Exam Body
            ViewState["lblRemarks"] = olng.GetItemDesc("lblRemarks"); //   Remarks
            ViewState["lblRollNo"] = olng.GetItemDesc("lblRollNo"); //   Roll No
            ViewState["lblExmMark"] = olng.GetItemDesc("lblExmMark"); //   Exam Start Time
            ViewState["lblExmMode"] = olng.GetItemDesc("lblExmMode"); //   Exam Venue
            ViewState["lblExmCenter"] = olng.GetItemDesc("lblExmCenter"); //   Exam Venue
            ViewState["lblRecruiterName"] = olng.GetItemDesc("lblRecruiterName"); //   Recruiter Name
            ViewState["lblSAPCode"] = olng.GetItemDesc("lblSAPCode"); //   SAP Code
            ViewState["lblToken"] = olng.GetItemDesc("lblToken");//Token no
            ViewState["lblFees"] = olng.GetItemDesc("lblFees");//total fees


            //training Details Section
            ViewState["lblTrndetails"] = olng.GetItemDesc("lblTrndetails");
            ViewState["lblTrnDtl"] = olng.GetItemDesc("lblTrnDtl");
            ViewState["lblTrnMode"] = olng.GetItemDesc("lblTrnMode");
            ViewState["lblTrnLoc"] = olng.GetItemDesc("lblTrnLoc");
            ViewState["lblTrnInstitute"] = olng.GetItemDesc("lblTrnInstitute");
            ViewState["lblAccrdtn"] = olng.GetItemDesc("lblAccrdtn");
            ViewState["lblHrnTrn"] = olng.GetItemDesc("lblHrnTrn");
            ViewState["lblTrnstrtDate"] = olng.GetItemDesc("lblTrnstrtDate");
            ViewState["lblTrnEndDate"] = olng.GetItemDesc("lblTrnEndDate");
            ////Added By Asrar on 26-06-2013 for converting Inline query into procedure to get Channel Desc on the bases of User Lang start
            ////string strQuery = "Select ChannelDesc0" + Convert.ToInt32(Session["UserLangNum"].ToString()) + " From chnsu Where Bizsrc='XX'";
            //SqlDataReader dtRead;
            ////dtRead = dataAccess.exec_reader(strQuery, CONN_INSCCOMMON);
            Hashtable httable = new Hashtable();
            SqlDataReader dtRead;
            httable.Clear();
            httable.Add("@UserLang", Convert.ToInt32(Session["UserLangNum"].ToString()));
            //dtRead = dataAccessRecruit.Common_exec_reader_prc("prc_GetChannelDesc", httable);
            dtRead = dataAccessclass.Common_exec_reader_prc("prc_GetChannelDesc", httable);
            //Added By Asrar on 26-06-2013 for converting Inline query into procedure  bases of User Lang end

            if (dtRead.HasRows)
            {
                dtRead.Read();
                lblbpareyourelated.Text = "Are you related to any employee of " + dtRead[0].ToString() + "?";
            }

            ////...gaurav..11/10/12
            lblbpifyes.Text = (olng.GetItemDesc("lblbpifyes").Replace("','", ","));

            //btnUpdate.Text = olng.GetItemDesc("btnUpdate");
            //btnCancel.Text = olng.GetItemDesc("btnCancel");
            //hdnIsDateValid.Value = olng.GetItemDesc("hdnIsDateValid");
            //hdnDOB.Value = olng.GetItemDesc("hdnDOB");
            //hdnSave.Value = olng.GetItemDesc("hdnSave");
            //hdnUpdate.Value = olng.GetItemDesc("hdnUpdate");
            //hdnAppno.Value = olng.GetItemDesc("hdnAppno");

            //Candidate movement labels  
            lblCndmvmt.Text = olng.GetItemDesc("lblCndmvmt");

            //Address Edit Labels
            lblPAdd2.Text = olng.GetItemDesc("lblPAdd2");
            lblPAdd3.Text = olng.GetItemDesc("lblPAdd3");
            lblPVillage.Text = olng.GetItemDesc("lblPVillage");
            lblstatecodeedit.Text = olng.GetItemDesc("lblstatecodeedit");
            lblPDistrict.Text = olng.GetItemDesc("lblPDistrict");
            lblParea1.Text = olng.GetItemDesc("lblParea1");
            lblPpostcode.Text = olng.GetItemDesc("lblPpostcode");
            lblPrmcountry.Text = olng.GetItemDesc("lblPrmcountry");
            lblPcity.Text = olng.GetItemDesc("lblPrmcountry");
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
    //added by Nikhil for composite on 8.6.15 start
    private void BindCompositeGrid(string strCndNo)
    {
        Hashtable htParams = new Hashtable();
        // Dataset dsResult = new Dataset();
        htParams.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", htParams);
        string strCndType = dsResult.Tables[0].Rows[0]["CandType"].ToString().Trim();
		strCndType = strCndType.Replace(" ","");
        Hashtable htCompGrd = new Hashtable();
        DataSet dsCompGrd = new DataSet();
        htCompGrd.Add("@CndNo", strCndNo.Trim());
        if (strCndType == "C" || strCndType == "T")
        {
            dsCompGrd = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCompDtls", htCompGrd);


            if (dsCompGrd != null)
            {
                if (dsCompGrd.Tables.Count > 0 && dsCompGrd.Tables[0].Rows.Count > 0)
                {
                    if (strCndType == "C")
                    {
						tbltrnsDtls.Attributes.Add("style", "display:none");
						gvComposite.DataSource = dsCompGrd.Tables[0];
                        gvComposite.DataBind();
                    }

                    else if (strCndType == "T")
                    {
                        gvTrnsfr.DataSource = dsCompGrd.Tables[0];
                        gvTrnsfr.DataBind();
                        trNoteTr.Visible = false;//added by meena 27/3/18
                    }

                }
            }
        }
        else if (strCndType == "G")
        {
            dsCompGrd = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetTagsDtls", htCompGrd);
            if (dsCompGrd != null)
            {
                if (dsCompGrd.Tables.Count > 0 && dsCompGrd.Tables[0].Rows.Count > 0)
                {
                    grdTag.DataSource = dsCompGrd.Tables[0];
                    grdTag.DataBind();
                    tbltagDtls.Visible = true;
                }
            }
        }
    }

    private void BindCandidateMvmt()
    {
        Hashtable htCndmvmt = new Hashtable();
        htCndmvmt.Add("@CndNo", Request.QueryString["CndNo"].ToString());
        DataSet dsCndMvmt = new DataSet();
        dsCndMvmt = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandidateMvmt", htCndmvmt);

        if (dsCndMvmt.Tables.Count > 0)
        {
            if (dsCndMvmt.Tables[0].Rows.Count > 0)
            {
                dgCndMvmt.DataSource = dsCndMvmt.Tables[0];
                dgCndMvmt.DataBind();
            }
            else
            {
                cndmvmt.Visible = false;
                divCndMvmt.Visible = false;
            }
        }

    }
    #region BindGridCnd()
    private DataSet BindGridCnd()
    {
        try
        {
            dsResult.Clear();
            htParam.Clear();
            Hashtable httable = new Hashtable();
            httable.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            httable.Add("@DocType", "Photo");
            dsResult = dataAccessclass.GetDataSetForPrc("Prc_GetImageForCnd", httable);
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
        return dsResult;
    }
    #endregion
    #region PopulateState
    private void PopulateState()
    {
        try
        {
            string strSql = string.Empty;
            //SqlDataReader dtRead;
            DataSet DsState1 = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            //dtRead = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");
            DsState1 = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetddlState");

            //dtRead.Read();
            //if (dtRead.HasRows)
            //{
            if (DsState1.Tables.Count > 0)
            {
                if (DsState1.Tables[0].Rows.Count > 0)
                {
                    ddlstate1.DataSource = DsState1;
                    ddlstate1.DataTextField = "StateName";
                    ddlstate1.DataValueField = "StateID";
                    ddlstate1.DataBind();
                    ddlstate1.Items.Insert(0, "--Select--");
                }
            }
            //}
            //dsResult = null;
            //dtRead = null;
            DsState1 = null;
            strSql = null;
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

    #region PopulatePermState
    private void PopulatePermState()
    {
        try
        {
            string strSql = string.Empty;
            //SqlDataReader dtRead;
            DataSet DsPAState1 = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            //dtRead = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");
            DsPAState1 = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetddlState");

            //dtRead.Read();
            //if (dtRead.HasRows)
            //{
            if (DsPAState1.Tables.Count > 0)
            {
                if (DsPAState1.Tables[0].Rows.Count > 0)
                {
                    ddlstatePA.DataSource = DsPAState1;
                    ddlstatePA.DataTextField = "StateName";
                    ddlstatePA.DataValueField = "StateID";
                    ddlstatePA.DataBind();
                    ddlstatePA.Items.Insert(0, "--Select--");
                }
            }
            //}
            // dsResult = null;
            //dtRead = null;
            DsPAState1 = null;
            strSql = null;
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

    private void EnableDisableIsSpecific()
    {
        DataSet dsIsSpPrsn = new DataSet();
        dsIsSpPrsn = dataAccessclass.GetDataSetForPrc_DIRECT("Prc_GetIsSpecPeriConfig");
        ViewState["IsSpPrsnValue"] = dsIsSpPrsn.Tables[0].Rows[0]["Value"].ToString().Trim();

    }

    #region set ReExamFlag,ExamType,RenewalFlag,Count
    private void GetRenewalDtls()
    {
        Hashtable htRe = new Hashtable();
        DataSet dsRe = new DataSet();
        htRe.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsRe = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCndLicnsDtls", htRe);
        //viewstate for inserting fees details
        ViewState["RenewalFlag"] = dsRe.Tables[0].Rows[0]["RenewalFlag"].ToString().Trim();
    }

    private void GetReExamDtls()
    {
        Hashtable htReExam = new Hashtable();
        DataSet dsReExam = new DataSet();
        htReExam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsReExam = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCndReExmDtls", htReExam);
        //viewstate for inserting fees details
        ViewState["ReExmType"] = dsReExam.Tables[0].Rows[0]["ReExmType"].ToString().Trim();
        ViewState["ReExamFlag"] = dsReExam.Tables[0].Rows[0]["ReExamFlag"].ToString().Trim();
    }
    #endregion
    private void PopulateCndPersonalDtls()
    {
        try
        {
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
            htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            if (Request.QueryString["Type"].ToString() == "Pros")
            {
                #region Prospect Bind
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_GetProspectView", htParam);
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        //personal Information
                        lblcndidDesc.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
                        lblcategoryDesc.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
                        lblpfappnoDesc.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
                        lblpfregdateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //added by pranjali on 02-04-2014 start
                        string title = dsResult.Tables[0].Rows[0]["Title"].ToString();
                        string name = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
                        lblpfgivenNameDesc.Text = title + " " + name;
                        //added by pranjali on 02-04-2014 end
                        //lblpfgivenNameDesc.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
                        lblpfSurNameDesc.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();
                        lblpffathernameDesc.Text = dsResult.Tables[0].Rows[0]["FatherName"].ToString();
                        lblpfGenderDesc.Text = dsResult.Tables[0].Rows[0]["Gender"].ToString();
                        lblpfdobDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //lblICdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["Date"])).ToString(CommonUtility.DATE_FORMAT);
                        //lblpfpobDesc.Text=dsResult.Tables[0].Rows[0][""].ToString();
                        lblpfmaritalstatusDesc.Text = dsResult.Tables[0].Rows[0]["MaritalStat"].ToString();
                        lblpfNationalityDesc.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString();
                        lblpfpanDesc.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString();
                        //Category and profession
                        //lblCasteCatDesc.Text = dsResult.Tables[0].Rows[0]["CasteCat"].ToString();
                        lblPrimProfDesc.Text = dsResult.Tables[0].Rows[0]["PrimaryProf"].ToString();
						if (dsResult.Tables[0].Rows[0]["CndAnniversaryDt"].ToString() != "")
						{
							TxtAnnivsrdte.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CndAnniversaryDt"])).ToString(CommonUtility.DATE_FORMAT);
						}
						lnkPage2.Visible = false;

                        //comment by Pathamesh 17-6-15
                        //lnkPage3.Visible = false; LinkPage5.Visible = false; LinkPage4.Visible = false;
                        //LinkPage5.Visible = false; LinkPage6.Visible = false; LinkPage7.Visible = false;
                        tblNomineeDetails.Visible = false; btnCancel.Visible = false;

                        ////Contact info
                        lblpfconpreferredDesc.Text = dsResult.Tables[0].Rows[0]["Contact"].ToString();
                        lblpfhometelDesc.Text = dsResult.Tables[0].Rows[0]["HomeTel"].ToString();
                        lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() != "" ? lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() : lblpfofftelDesc.Text = "";
                        lblpfmobtelDesc1.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString();
                        lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() != "" ? lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() : lblpfmobtelDesc2.Text = "";
                        if (lblpfmobtelDesc2.Text == "")
                        {
                            lblpfmobtelDesc2.Text = "";
                            lblmobcode1.Text = "91";
                            //  lblmobcode1.Visible = false;

                        }
                        if (lblpfmobtelDesc1.Text == "")
                        {
                            lblpfmobtelDesc1.Text = "";
                            lblMobCode.Text = "";
                        }
                        lblEmail1Desc.Text = dsResult.Tables[0].Rows[0]["Email"].ToString();
                        lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() != "" ? lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() : lblEmail2Desc.Text = "";
                        // hdnStausValue.Value = dsResult.Tables[0].Rows[0]["CndStatus"].ToString();
                        //Recruiter details
                        //lblpfbesmcodeDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtCode"].ToString();
                        string strSMCode = dsResult.Tables[0].Rows[0]["RecruitAgtCode"].ToString();
                        ///lblSAPCodeDesc.Text=
                        lblSAPCodeDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                        lblpfsalchannelDesc.Text = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString();
                        lblpfchasubclassDesc.Text = dsResult.Tables[0].Rows[0]["SubCls"].ToString();
                        lblpfagetypeDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();
                        string strUnitLegalName = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString();
                        string strcmsunit = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();

                        lblpfimmleaderDesc.Text = strUnitLegalName + "(" + strcmsunit + ")";
                        lblpfsmnameDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                        lblCandAgntTypeDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                        //added by meena 4_5_18 start
                        if (Request.QueryString["Type"].ToString() == "Pros")
                        {
                            string strUnitLegalName1 = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString();
                            string strcmsunit1 = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                            lblpfberptcodeDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                            lblpfsalchannelrptDesc.Text = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString();
                            lblpfchasubclassrptDesc.Text = dsResult.Tables[0].Rows[0]["SubCls"].ToString();
                            lblpfimmleaderrptDesc.Text = strUnitLegalName1 + "(" + strcmsunit1 + ")";
                            lblpfsmnamerptDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                            //lblCandAgntTyperptDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();
                            //lblpfagetyperptDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                            lblCandAgntTyperptDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                            lblpfagetyperptDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();
                        }
                        txtaadhr.Text = dsResult.Tables[0].Rows[0]["RelParamDesc"].ToString();
                        txtcndtype.Text = dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Trim();
                        if (txtcndtype.Text == "Fresh Details")
                        {
                            tbltrnsDtls.Attributes.Add("style", "display:none");
                            tblcomposite.Attributes.Add("style", "display:none");
                        }
                        else if (txtcndtype.Text == "Composite Details")
                        {
                            tblcomposite.Attributes.Add("style", "display:block");
                        }
                        else if (txtcndtype.Text == "Transfer Details")
                        {
                            tbltrnsDtls.Attributes.Add("style", "display:block");
                        }
                        

                        if (dsResult.Tables[0].Rows[0]["LcnNo"].ToString() != "")
                        {
                            Hashtable htRpt = new Hashtable();
                            DataSet Dsrpt = new DataSet();
                            string strDirectAgtCode = string.Empty;
                            strDirectAgtCode = dsResult.Tables[0].Rows[0]["DirectAgtCode"].ToString();
                            htRpt.Add("@Memcode", strDirectAgtCode);//lblpfbesmcodeDesc.Text.Trim());
                            Dsrpt = dataAccessclass.GetDataSetForPrcRecruit("Prc_ReportingDetails", htRpt);

                            if (Dsrpt.Tables[0].Rows.Count > 0)
                            {
                                if (Dsrpt.Tables[0].Rows.Count > 0)
                                {
                                    // Prc_ReportingDetails
                                    //Reporting details
                                    string strUnitLegalName1 = Dsrpt.Tables[0].Rows[0]["UnitLegalName"].ToString();
                                    string strcmsunit1 = Dsrpt.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                                    lblpfberptcodeDesc.Text = Dsrpt.Tables[0].Rows[0]["RelMemCode"].ToString();
                                    lblpfsalchannelrptDesc.Text = Dsrpt.Tables[0].Rows[0]["Class"].ToString();
                                    lblpfchasubclassrptDesc.Text = Dsrpt.Tables[0].Rows[0]["subclass"].ToString();
                                    lblpfimmleaderrptDesc.Text = strUnitLegalName1 + "(" + strcmsunit1 + ")";
                                    lblpfsmnamerptDesc.Text = Dsrpt.Tables[0].Rows[0]["LegalName"].ToString();
                                    lblCandAgntTyperptDesc.Text = Dsrpt.Tables[0].Rows[0]["MemTypeDesc01"].ToString();
                                    lblpfagetyperptDesc.Text = Dsrpt.Tables[0].Rows[0]["rectype"].ToString();
                                }
                            }
                            // }
                            else
                            {
                                string strUnitLegalName1 = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString();
                                string strcmsunit1 = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                                lblpfberptcodeDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                                lblpfsalchannelrptDesc.Text = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString();
                                lblpfchasubclassrptDesc.Text = dsResult.Tables[0].Rows[0]["SubCls"].ToString();
                                lblpfimmleaderrptDesc.Text = strUnitLegalName1 + "(" + strcmsunit1 + ")";
                                lblpfsmnamerptDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                                lblCandAgntTyperptDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                                lblpfagetyperptDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();

                            }
                        }
                        //Contact info
                        lblpfconpreferredDesc.Text = dsResult.Tables[0].Rows[0]["Contact"].ToString();
                        lblpfhometelDesc.Text = dsResult.Tables[0].Rows[0]["HomeTel"].ToString();
                        lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() != "" ? lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() : lblpfofftelDesc.Text = "";
                        lblpfmobtelDesc1.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString();
                        lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() != "" ? lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() : lblpfmobtelDesc2.Text = "";
                        if (lblpfmobtelDesc2.Text == "")
                        {
                            lblpfmobtelDesc2.Text = "";
                            lblmobcode1.Text = "91";
                            // lblmobcode1.Visible = false;
                        }
                        if (lblpfmobtelDesc1.Text == "")
                        {
                            lblpfmobtelDesc1.Text = "";
                            lblMobCode.Text = "";
                        }
                        lblEmail1Desc.Text = dsResult.Tables[0].Rows[0]["Email"].ToString();
                        lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() != "" ? lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() : lblEmail2Desc.Text = "";

                        //tblRecruitDetails.Visible = false;
                        tblPresentadd.Visible = false;
                        tblPerAdd.Visible = false;

                        tblProofofDocument.Visible = false;
                        divProofofDocument.Attributes.Add("Style", "display:none");
                        tblNomineeDetails.Attributes.Add("Style", "display:none");
                        divNomineeDetails.Attributes.Add("Style", "display:none");

                        tblPresentadd.Visible = false;
                        divPresentAddress.Attributes.Add("Style", "display:none");
                        divPermanentAddress.Attributes.Add("Style", "display:none");
                        divPermanentAddress.Visible = false;

                        divProofofDocument.Attributes.Add("Style", "display:none");
                        divPerAddressEdit.Attributes.Add("Style", "display:none");//.Visible = false;
                        divPermanentAddress.Attributes.Add("Style", "display:none");//.Visible = true;
                        tbltrnsDtls.Attributes.Add("Style", "display:none");
                        divTrnsferDetails.Attributes.Add("Style", "display:none");
                        tbltagDtls.Attributes.Add("Style", "display:none");
                        divTagDetails.Attributes.Add("Style", "display:none");
                        tblcomposite.Visible = true;//usha
                        divCompositeDetails.Attributes.Add("Style", "display:none");
                        tblLicDtls.Visible = false;
                        divLicenseDtls.Attributes.Add("Style", "display:none");

                        btnSave.Visible = false;
                    }
                }
                #endregion
            }
            else
            {
                #region Candidate details bind
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCndView", htParam);


                //
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {

                        if (Request.QueryString["Type"].ToString() == "Other" && Request.QueryString["Act"].ToString() == "NoEdit")
                        {
                            chkEdit.Enabled = false;
                            chkPerEdit.Enabled = false;
                            btnSave.Visible = false;
                        }
                        else
                        {
                            chkEdit.Enabled = true;
                            chkPerEdit.Enabled = true;

                        }
                        //Specified Person 
                        if (ViewState["IsSpPrsnValue"].ToString() == "N")
                        {
                            tblrdb.Attributes.Add("Style", "Display:none");
                            tblIsSpecific.Attributes.Add("Style", "Display:none");
                        }
                        else
                        {
                            if (dsResult.Tables[0].Rows[0]["isSPFlag"].ToString().Trim() == "Y")
                            {
                                tblIsSpecific.Attributes.Add("Style", "Display:block");

                                rbtIsSP.SelectedValue = dsResult.Tables[0].Rows[0]["isSPFlag"].ToString().Trim();
                                rbtIsSP.Enabled = false;

                                lblCACodeDesc.Text = dsResult.Tables[0].Rows[0]["CACode"].ToString().Trim();
                                lblCANameDesc.Text = dsResult.Tables[0].Rows[0]["CAName"].ToString().Trim();

                            }
                            else
                            {
                                tblIsSpecific.Attributes.Add("Style", "Display:none");
                                rbtIsSP.SelectedValue = dsResult.Tables[0].Rows[0]["isSPFlag"].ToString().Trim();
                                rbtIsSP.Enabled = false;
                            }
                        }

                        //personal Information
                        lblcndidDesc.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
                        lblcategoryDesc.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
                        lblpfappnoDesc.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
                        lblpfregdateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //added by pranjali on 02-04-2014 start
                        string title = dsResult.Tables[0].Rows[0]["Title"].ToString();
                        string name = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
                        lblpfgivenNameDesc.Text = title + " " + name;
                        //added by pranjali on 02-04-2014 end
                        //lblpfgivenNameDesc.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
                        lblpfSurNameDesc.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();

                        //personal info to viewstate
                        ViewState["lblcndidDesc"] = lblcndidDesc.Text;
                        ViewState["lblpfappnoDesc"] = lblpfappnoDesc.Text;
                        ViewState["lblpfregdateDesc"] = lblpfregdateDesc.Text;
                        ViewState["lblpfgivenNameDesc"] = lblpfgivenNameDesc.Text;
                        ViewState["lblpfSurNameDesc"] = lblpfSurNameDesc.Text;
                        txtaadhr.Text = dsResult.Tables[0].Rows[0]["RelParamDesc"].ToString();
                        lblpffathernameDesc.Text = dsResult.Tables[0].Rows[0]["FatherName"].ToString();
                        lblpfGenderDesc.Text = dsResult.Tables[0].Rows[0]["Gender"].ToString();
                        lblpfdobDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                        //lblICdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["Date"])).ToString(CommonUtility.DATE_FORMAT);
                        //lblpfpobDesc.Text=dsResult.Tables[0].Rows[0][""].ToString();
                        lblpfmaritalstatusDesc.Text = dsResult.Tables[0].Rows[0]["MaritalStat"].ToString();
						if (dsResult.Tables[0].Rows[0]["CndAnniversaryDt"].ToString() != "")
						{
							TxtAnnivsrdte.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CndAnniversaryDt"])).ToString(CommonUtility.DATE_FORMAT);
						}
						lblpfNationalityDesc.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString();
                        lblpfpanDesc.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString();
                        //txtaadhr.Text = dsResult.Tables[0].Rows[0]["ParamDesc"].ToString();
                        //txtcndtype.Text = dsResult.Tables[0].Rows[0]["Cand_type"].ToString();
                        if (dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Replace(" ","") == "F" || dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Replace(" ", "") == "P")
                        {
							if (dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Replace(" ", "") == "F")
							{
								txtcndtype.Text = "Fresh";
							}
							else
							{
								txtcndtype.Text = "POSP";
							}
							tbltrnsDtls.Attributes.Add("style", "display:none");
                            tblcomposite.Attributes.Add("style", "display:none");
                        }
                        else if (dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Replace(" ", "") == "C")
                        {
							txtcndtype.Text = "Composite";
							tblcomposite.Attributes.Add("style", "display:block");
                            tbltrnsDtls.Attributes.Add("style", "display:none");
                        }
                        else if (dsResult.Tables[0].Rows[0]["Cand_type"].ToString().Replace(" ", "") == "T")
                        {
							txtcndtype.Text = "Transfer";
							tbltrnsDtls.Attributes.Add("style", "display:block");
                            tblcomposite.Attributes.Add("style", "display:none");
                        }
                        //added by sanoj 21082023
                        if (dsResult.Tables[0].Rows[0]["WaiverType"].ToString().Trim()!=null && dsResult.Tables[0].Rows[0]["WaiverType"].ToString().Trim() != "")
                        {
                            divWaiverType.Visible = true;
                            txtWaiverType.Text = dsResult.Tables[0].Rows[0]["WaiverType"].ToString().Trim();
                        }
                        //added by sanoj 21082023
                        //    txtaadhr.Text = dsResult.Tables[0].Rows[0]["AadharNo"].ToString();commented by Ashish P 07-04-2018

                        //Added by AshishP 07-04-2018 DecryptAadhar
                        //if (dsResult.Tables[0].Rows[0]["AadharNo"].ToString() != "")
                        //{
                        //    string strAadharReponse = AadharVault.DecryptAadhar(dsResult.Tables[0].Rows[0]["AadharNo"].ToString());
                        //    AadharVault.AadharResponse AadharResponse = new AadharVault.AadharResponse();
                        //    AadharVault.AadharResponse deserializedAadharResponse = JsonConvert.DeserializeObject<AadharVault.AadharResponse>(strAadharReponse);

                        //    if (deserializedAadharResponse.Errorcode == "" && deserializedAadharResponse.Response != "")
                        //    {

                        //        txtaadhr.Text = AadharVault.AadharNumberMask(deserializedAadharResponse.Response.ToString());


                        //    }

                        //}
                        //Added by AshishP 07-04-2018 DecryptAadhar


                        //if (dsResult.Tables[0].Rows[0]["AutoWavierflag"].ToString() != "")
                        //{
                        //    ChkFeesWavier.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkFeesWavier.Checked = false;
                        //} coommented by DAKSH FOR POSP CND VIEW
                        if (dsResult.Tables[0].Rows[0]["LcnNo"].ToString() != "")
                        {
                            lblLicNoValue.Text = dsResult.Tables[0].Rows[0]["LcnNo"].ToString().Trim();
                            ViewState["AgentBrokerCode"] = dsResult.Tables[0].Rows[0]["Agent_Broker_Code"].ToString().Trim();//Added by sanoj  on 22062023  for Dispatch Details 

                        }
                        else
                        {
                            lblLicNoValue.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString() != "")
                        {
                            lblLicExpDtValue.Text = dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim();
                        }
                        else
                        {
                            lblLicExpDtValue.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["URN"].ToString().ToString().Trim() != "" && dsResult.Tables[0].Rows[0]["URN"].ToString().Trim() != null)
                        {
                            lblCndUrnDesc.Visible = true;
                            lblCndUrnDesc.Text = dsResult.Tables[0].Rows[0]["URN"].ToString();
                            ViewState["lblCndUrnDesc"] = dsResult.Tables[0].Rows[0]["URN"].ToString();
                        }
                        else
                        {
                            lblCndUrn.Visible = true;
                            lblCndUrnDesc.Visible = true;
                            ViewState["lblCndUrnDesc"] = "";
                        }
                        //Transfer and comosite Details
                        if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "0")
                        {
                            cbTrfrFlag.Checked = false;
                        }
                        else if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "2")
                        {
                            cbTrfrFlag.Checked = false;
                            cbTagLcn.Checked = true;
                        }
                        else
                        {
                            cbTrfrFlag.Checked = true;
                        }
                        if (cbTrfrFlag.Checked == true)
                        {
                            tbltrnsDtls.Visible = true;
                            divTrnsferDetails.Attributes.Add("Style", "display:block;padding:0px");

                            lbloldLcnNoDesc.Text = dsResult.Tables[0].Rows[0]["OldTccLcnNo"].ToString();
                            if (dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"].ToString() != "")
                            {
                                lblOldLcnexpDateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                            }
                            else
                            {
                                lblOldLcnexpDateDesc.Text = "";
                            }
                            //lblpfpobDesc.Text=dsResult.Tables[0].Rows[0][""].ToString();
                            lblPrevInsurerNameDesc.Text = dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"].ToString();
                            if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() != "0" || dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() != "False")
                            {
                                RbtNoc.SelectedIndex = 0;
                            }
                            else
                            {
                                RbtNoc.SelectedIndex = 1;
                            }
                            // if (dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() != "0" || dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() != "F")
                            if (RbtNoc.SelectedIndex == 0)
                            {
                                //lblAckrcvDesc.Text = "No";
                                trAckrow.Visible = false;
                            }
                            else
                            {
                                if (dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() == "1" || dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() == "F")
                                {
                                    lblAckrcvDesc.Text = "Yes";
                                }
                            }
                        }
                        else if (cbTagLcn.Checked == true)
                        {
                            tbltagDtls.Visible = true;
                            tbltagDtls.Attributes.Add("Style", "display:block;margin:0px");
                            divTagDetails.Attributes.Add("Style", "display:block;padding:0px");
                        }
                        else
                        {
                            tbltrnsDtls.Visible = false;
                            divTrnsferDetails.Attributes.Add("Style", "visibility:hidden");
                        }
                        //Composite Details

                        if (dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString() == "0" || dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString() == "False")
                        {
                            cbTccCompLcn.Checked = false;
                        }
                        else
                        {
                            cbTccCompLcn.Checked = true;

                        }
                        if (cbTccCompLcn.Checked == true)
                        {

                            tblcomposite.Visible = true;
                            
                            divCompositeDetails.Attributes.Add("Style", "display:block;padding:0px");
                            //divCompositeDetails.Attributes.Add("Style", "visibility:hidden");
                            lblCompLicNoDesc.Text = dsResult.Tables[0].Rows[0]["CompLicNo"].ToString() != "" ? lblCompLicNoDesc.Text = dsResult.Tables[0].Rows[0]["CompLicNo"].ToString() : lblCompLicNoDesc.Text = "";
                            //lblComplicnseExpDtDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString())).ToString(CommonUtility.DATE_FORMAT) != "" ? lblComplicnseExpDtDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString())).ToString(CommonUtility.DATE_FORMAT) : lblComplicnseExpDtDesc.Text = "";
                            lblComplicnseExpDtDesc.Text = dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString() != "" ? lblComplicnseExpDtDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["CompLicExpDt"].ToString())).ToString(CommonUtility.DATE_FORMAT) : lblComplicnseExpDtDesc.Text = "";
                            lblCompInsurerNameDesc.Text = dsResult.Tables[0].Rows[0]["CompInsrName"].ToString() != "" ? lblCompInsurerNameDesc.Text = dsResult.Tables[0].Rows[0]["CompInsrName"].ToString() : lblCompInsurerNameDesc.Text = "";
                        }
                        else
                        {
                            tblcomposite.Visible = true;//usha
							divCompositeDetails.Attributes.Add("Style", "display:block;padding:0px");
                           // divCompositeDetails.Attributes.Add("Style", "visibility:hidden");
                        }

                        //added by shreela start
                        if (dsResult.Tables[0].Rows[0]["IsPriorAgt"].ToString().Trim() == "1")
                        {
                            chkCompAgnt.Checked = true;
                        }
                        else
                        {
                            chkCompAgnt.Checked = false;
                        }
                        //added by shreela end


                        //Category and profession
                        lblCasteCatDesc.Text = dsResult.Tables[0].Rows[0]["CasteCat"].ToString();
                        lblPrimProfDesc.Text = dsResult.Tables[0].Rows[0]["PrimaryProf"].ToString();

                        //Nominee Details
                        if (dsResult.Tables[0].Rows[0]["NomineeName"].ToString() != "")
                        {
                            lblNomineeDesc.Text = dsResult.Tables[0].Rows[0]["NomineeName"].ToString();
                        }
                        else
                        {
                            lblNomineeDesc.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["NomineeEmailID"].ToString() != "")
                        {
                            txtNomneeEmail.Text = dsResult.Tables[0].Rows[0]["NomineeEmailID"].ToString();
                        }
                        else
                        {
                            txtNomneeEmail.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["NomineeMobileTel"].ToString() != "")
                        {
                            txtNominMob.Text = dsResult.Tables[0].Rows[0]["NomineeMobileTel"].ToString();
                        }
                        else
                        {
                            txtNominMob.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["NomineePAN"].ToString() != "")
                        {
                            txtNomnPan.Text = dsResult.Tables[0].Rows[0]["NomineePAN"].ToString();
                        }
                        else
                        {
                            txtNomnPan.Text = "";
                        }
                        if (dsResult.Tables[0].Rows[0]["NomineAdvRel"].ToString() != "")
                        {
                            lblReltoAdvDesc.Text = dsResult.Tables[0].Rows[0]["RelParamDesc"].ToString();
                        }
                        if (dsResult.Tables[0].Rows[0]["NomineAge"].ToString() != "")
                        {
                            lblAgeDesc.Text = dsResult.Tables[0].Rows[0]["NomineAge"].ToString();
                        }

                        //Recruiter details
                        //lblpfbesmcodeDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtCode"].ToString();
                        string strSMCode1 = dsResult.Tables[0].Rows[0]["DirectAgtCode"].ToString();
                        ///lblSAPCodeDesc.Text=
                        lblSAPCodeDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                        txtmarktype.Text = dsResult.Tables[0].Rows[0]["Market_Type"].ToString();//added by ajay yadav
                        txtrpmarkt.Text = dsResult.Tables[0].Rows[0]["Market_Type"].ToString();//added by ajay yadav
                        lblpfsalchannelDesc.Text = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString();
                        lblpfchasubclassDesc.Text = dsResult.Tables[0].Rows[0]["SubCls"].ToString();
                        lblpfagetypeDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();
                        string strUnitLegalName = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString();
                        // string strcmsunit = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                        string strcmsunit = dsResult.Tables[0].Rows[0]["UnitCode"].ToString();

                        lblpfimmleaderDesc.Text = strUnitLegalName + "(" + strcmsunit + ")";
                        lblpfsmnameDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                        lblCandAgntTypeDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                        txtaddrptmgrcode.Text = dsResult.Tables[0].Rows[0]["addlrptmgrcode"].ToString();//pan validation start 07_08_2023 start
                        if ((dsResult.Tables[0].Rows[0]["LcnNo"].ToString() != "" && dsResult.Tables[0].Rows[0]["LcnNo"].ToString() != "APPLIED FOR") && dsResult.Tables[0].Rows[0]["DirectAgtCode"].ToString() != "")
                        {
                            Hashtable htRpt = new Hashtable();
                            DataSet Dsrpt = new DataSet();
                            htRpt.Add("@Memcode", strSMCode1);//lblpfbesmcodeDesc.Text.Trim());
                            Dsrpt = dataAccessclass.GetDataSetForPrcRecruit("Prc_ReportingDetails", htRpt);

                            if (Dsrpt.Tables[0].Rows.Count > 0)
                            {
                                if (Dsrpt.Tables[0].Rows.Count > 0)
                                {
                                    // Prc_ReportingDetails
                                    //Reporting details
                                    string strUnitLegalName1 = Dsrpt.Tables[0].Rows[0]["UnitLegalName"].ToString();
                                    string strcmsunit1 = Dsrpt.Tables[0].Rows[0]["CmsUnitCode"].ToString();
                                    lblpfberptcodeDesc.Text = Dsrpt.Tables[0].Rows[0]["RelMemCode"].ToString();
                                    lblpfsalchannelrptDesc.Text = Dsrpt.Tables[0].Rows[0]["Class"].ToString();
                                    lblpfchasubclassrptDesc.Text = Dsrpt.Tables[0].Rows[0]["subclass"].ToString();
                                    lblpfimmleaderrptDesc.Text = strUnitLegalName1 + "(" + strcmsunit1 + ")";
                                    lblpfsmnamerptDesc.Text = Dsrpt.Tables[0].Rows[0]["LegalName"].ToString();
                                    lblCandAgntTyperptDesc.Text = Dsrpt.Tables[0].Rows[0]["MemTypeDesc01"].ToString();
                                    lblpfagetyperptDesc.Text = Dsrpt.Tables[0].Rows[0]["rectype"].ToString();
                                }
                            }
                        }//commented by meena
                        else
                        {

                            string strUnitLegalName1 = dsResult.Tables[0].Rows[0]["UnitLegalName"].ToString();
                          //  string strcmsunit1 = dsResult.Tables[0].Rows[0]["CmsUnitCode"].ToString();//commented by meena
                            string strcmsunit1 = dsResult.Tables[0].Rows[0]["UnitCode"].ToString();//added by meena
                            lblpfberptcodeDesc.Text = dsResult.Tables[0].Rows[0]["EmpCode"].ToString();
                            lblpfsalchannelrptDesc.Text = dsResult.Tables[0].Rows[0]["Bizsrc"].ToString();
                            lblpfchasubclassrptDesc.Text = dsResult.Tables[0].Rows[0]["SubCls"].ToString();
                            lblpfimmleaderrptDesc.Text = strUnitLegalName1 + "(" + strcmsunit1 + ")";
                            lblpfsmnamerptDesc.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                            //lblCandAgntTyperptDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();
                            //lblpfagetyperptDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                            lblCandAgntTyperptDesc.Text = dsResult.Tables[0].Rows[0]["AgenCandTtype"].ToString();
                            lblpfagetyperptDesc.Text = dsResult.Tables[0].Rows[0]["Agenttype"].ToString();

                        }
                  //  }//addd by meena
                        //added by pranjali on 02-04-2014 for proper mapping of address start
                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                        {

                            if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "P1" || dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "B1")
                            {
                                //Business and Resedential Address
                                lblpfaddresstypeDesc.Text = "Residential";
                                c.Text = dsResult.Tables[0].Rows[i]["StateName"].ToString();
                                lblpfAddrP1Desc.Text = dsResult.Tables[0].Rows[i]["Adr1"].ToString();
                                lbldistDesc.Text = dsResult.Tables[0].Rows[i]["District"].ToString();
                                lblpfAddrP2Desc.Text = dsResult.Tables[0].Rows[i]["Adr2"].ToString();
                                lblCityDesc.Text = dsResult.Tables[0].Rows[i]["city"].ToString();
                                lblpfAddrP3Desc.Text = dsResult.Tables[0].Rows[i]["Adr3"].ToString();
                                lblareaDesc.Text = dsResult.Tables[0].Rows[i]["Area"].ToString();
                                if (dsResult.Tables[0].Rows[i]["Village"].ToString() != "")
                                {
                                    lblVillageDesc.Text = dsResult.Tables[0].Rows[i]["Village"].ToString();
                                }
                                lblpfPinPDesc.Text = dsResult.Tables[0].Rows[i]["PostCode"].ToString();
                                lblpfCountryPDesc.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();
                                //added by pranjali on 02-04-2014 start
                                if (dsResult.Tables[0].Rows[i]["PermAdrInd"].ToString() == "N")
                                {
                                    ChkPA.Checked = false;
                                }
                                else
                                {
                                    ChkPA.Checked = true;
                                }
                                //added by pranjali on 02-04-2014 end
                            }

                            //permonant address
                            if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "M1")
                            {
                                //ChkPA.Checked = true;
                                lblpfprmAddDesc.Text = dsResult.Tables[0].Rows[i]["Adr1"].ToString();
                                lblpfprmstatecodeDesc.Text = dsResult.Tables[0].Rows[i]["StateName"].ToString();
                                ViewState["StateID"] = dsResult.Tables[0].Rows[i]["StateID"].ToString();
                                lblpermDistrictDesc.Text = dsResult.Tables[0].Rows[i]["District"].ToString();
                                lblPermAdd2.Text = dsResult.Tables[0].Rows[i]["Adr2"].ToString();
                                lblcity1Desc.Text = dsResult.Tables[0].Rows[i]["city"].ToString();
                                Label30Desc.Text = dsResult.Tables[0].Rows[i]["Adr3"].ToString();
                                lblarea1Desc.Text = dsResult.Tables[0].Rows[i]["Area"].ToString();
                                lblpermVillageDesc.Text = dsResult.Tables[0].Rows[i]["Village"].ToString();
                                lblpfprmpostcodeDesc.Text = dsResult.Tables[0].Rows[i]["PostCode"].ToString();
                                lblpfprmcountryDesc.Text = dsResult.Tables[0].Rows[i]["CountryDescPm"].ToString();
                                //added by pranjali on 02-04-2014 start
                                if (dsResult.Tables[0].Rows[i]["PermAdrInd"].ToString() == "N")
                                {
                                    ChkPA.Checked = false;
                                }
                                else
                                {
                                    ChkPA.Checked = true;
                                }
                                //added by pranjali on 02-04-2014 end
                            }
                        }
                        //added by pranjali on 02-04-2014 for proper mapping of address end
                        //Contact info
                        lblpfconpreferredDesc.Text = dsResult.Tables[0].Rows[0]["Contact"].ToString();
                        lblpfhometelDesc.Text = dsResult.Tables[0].Rows[0]["HomeTel"].ToString();
                        lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() != "" ? lblpfofftelDesc.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() : lblpfofftelDesc.Text = "";
                        lblpfmobtelDesc1.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString();
                        lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() != "" ? lblpfmobtelDesc2.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() : lblpfmobtelDesc2.Text = "";
                        if (lblpfmobtelDesc2.Text == "")
                        {
                            lblpfmobtelDesc2.Text = "";
                            lblmobcode1.Text = "91";
                            // lblmobcode1.Visible = false;
                        }
                        if (lblpfmobtelDesc1.Text == "")
                        {
                            lblpfmobtelDesc1.Text = "";
                            lblMobCode.Text = "";
                        }
                        lblEmail1Desc.Text = dsResult.Tables[0].Rows[0]["Email"].ToString();
                        lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() != "" ? lblEmail2Desc.Text = dsResult.Tables[0].Rows[0]["Email2"].ToString() : lblEmail2Desc.Text = "";

                        //Education Details
                        lblBasicQualDesc.Text = dsResult.Tables[0].Rows[0]["BasicQual"].ToString();
                        lblBoardNameDesc.Text = dsResult.Tables[0].Rows[0]["BasicBoardName"].ToString();
                        lblBasicRNoDesc.Text = dsResult.Tables[0].Rows[0]["BasicRollNo"].ToString();
                        lblYrPassDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BasicYrPass"])).ToString(CommonUtility.DATE_FORMAT);
                        lblpfeduproofDesc.Text = dsResult.Tables[0].Rows[0]["Qualific"].ToString();
                        ///
                        //All document section 
                        chkPhotoSign.Checked = dsResult.Tables[0].Rows[0]["HasPhoto"].ToString() == "Y" ? chkPhotoSign.Checked = true : chkPhotoSign.Checked = false;
                        cbmarksheet.Checked = dsResult.Tables[0].Rows[0]["HasMarkSheet"].ToString() == "Y" ? cbmarksheet.Checked = true : cbmarksheet.Checked = false;
                        cbcertificate.Checked = dsResult.Tables[0].Rows[0]["HasCertificate"].ToString() == "Y" ? cbcertificate.Checked = true : cbcertificate.Checked = false;
                        cbPanachayat.Checked = dsResult.Tables[0].Rows[0]["PanchayatFlag"].ToString() == "Y" ? cbPanachayat.Checked = true : cbPanachayat.Checked = false;
                        chkNOCAck.Checked = dsResult.Tables[0].Rows[0]["NocAckFlag"].ToString() == "Y" ? chkNOCAck.Checked = true : chkNOCAck.Checked = false;


                    }
                }
                #endregion
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

    //private void PopulateCndQualificationDtls()
    //{
    //    try
    //    {
    //        htParam.Clear();
    //        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //        htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
    //        //dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView", htParam, "INSCRecruitConnectionString");
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView1", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables.Count > 0)
    //        {
    //            if (dsResult.Tables[0].Rows.Count > 0)
    //            {


    //                lblqcndnoDesc.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
    //                //lblqfcategoryDesc.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
    //                lblqappnoDesc.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
    //                lblqregdateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                lblqgivennameDesc.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
    //                lblqsurnameDesc.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();
    //                if (dsResult.Tables[0].Rows[0]["URN"].ToString().ToString().Trim() != "" && dsResult.Tables[0].Rows[0]["URN"].ToString().Trim() != null)
    //                {
    //                    lblCndUrnv2Desc.Visible = true;
    //                    lblCndUrnv2Desc.Text = dsResult.Tables[0].Rows[0]["URN"].ToString();
    //                }
    //                else
    //                {
    //                    lblCndUrnv2.Visible = false;
    //                    lblCndUrnv2Desc.Visible = false;
    //                }
    //                //lblqflanguagesKnown1Desc.Text = dsResult.Tables[0].Rows[0][""].ToString();
    //                //cbpread   prc_CndAdmin_getCndView1
    //                //cbpwrite
    //                //cbpspeak
    //                //lblqflanguagesKnown2Desc.Text = dsResult.Tables[0].Rows[0][""].ToString();
    //                //cbpread2
    //                //cbpwrite2
    //                //cbpspeak2
    //                //lblqflanguagesKnown3Desc.Text = dsResult.Tables[0].Rows[0][""].ToString();
    //                //cbpread3
    //                //cbpwrite3
    //                //cbpspeak3
    //                //lblqflanguagesKnown4Desc.Text = dsResult.Tables[0].Rows[0][""].ToString();
    //                //cbpread4
    //                //cbpwrite4
    //                //cbpspeak4
    //                if (dsResult.Tables[0].Rows[0]["KnownLng"].ToString() != "")
    //                {
    //                    string[] sLang = Convert.ToString(dsResult.Tables[0].Rows[0]["KnownLng"]).Trim().Split(new char[] { '-' });
    //                    FillLanguage(lblqflanguagesKnown1Desc, cbpread, cbpwrite, cbpspeak, sLang[1].ToString());
    //                    FillLanguage(lblqflanguagesKnown2Desc, cbpread2, cbpwrite2, cbpspeak2, sLang[2].ToString());
    //                    FillLanguage(lblqflanguagesKnown3Desc, cbpread3, cbpwrite3, cbpspeak3, sLang[3].ToString());
    //                    FillLanguage(lblqflanguagesKnown4Desc, cbpread4, cbpwrite4, cbpspeak4, sLang[4].ToString());
    //                    //commented by pranjali on 03-04-2014 start
    //                    //if (lblqflanguagesKnown3Desc.Text == "")
    //                    //{
    //                    //    trlng2.Visible = false;
    //                    //}
    //                    //commented by pranjali on 03-04-2014 end
    //                }


    //               lblqfHigestQulDesc.Text = dsResult.Tables[0].Rows[0]["Qualific"].ToString() != "" ? lblqfHigestQulDesc.Text = dsResult.Tables[0].Rows[0]["Qualific"].ToString() : lblqfHigestQulDesc.Text = "";

    //                lblqfinsqualificationDesc.Text = dsResult.Tables[0].Rows[0]["InsQualDesc"].ToString() != "" ? lblqfinsqualificationDesc.Text = dsResult.Tables[0].Rows[0]["InsQualDesc"].ToString() : lblqfinsqualificationDesc.Text = "";//insurance Description
    //                lblOccupationDesc.Text = dsResult.Tables[0].Rows[0]["Occupation"].ToString() != "" ? lblOccupationDesc.Text = dsResult.Tables[0].Rows[0]["Occupation"].ToString() : lblOccupationDesc.Text = "";
    //                lblqfempaddressDesc.Text = dsResult.Tables[0].Rows[0]["EmpAddress"].ToString() != "" ? lblqfempaddressDesc.Text = dsResult.Tables[0].Rows[0]["EmpAddress"].ToString() : lblqfempaddressDesc.Text = "";

    //                cbMutFund.Checked = dsResult.Tables[0].Rows[0]["MutualFund"].ToString() != "" ? cbMutFund.Checked = true : cbMutFund.Checked = false;

    //                cbLifeIns.Checked = dsResult.Tables[0].Rows[0]["LifeInsurance"].ToString() != "" ? cbLifeIns.Checked = true : cbLifeIns.Checked = false;
    //                cbGenIns.Checked = dsResult.Tables[0].Rows[0]["GeneralInsurance"].ToString() != "" ? cbGenIns.Checked = true : cbGenIns.Checked = false;
    //                cbCreCard.Checked = dsResult.Tables[0].Rows[0]["CreditCard"].ToString() != "" ? cbCreCard.Checked = true : cbCreCard.Checked = false;
    //                lblqffromothersDesc.Text = dsResult.Tables[0].Rows[0]["OtherProducts"].ToString() != "" ? lblqffromothersDesc.Text = dsResult.Tables[0].Rows[0]["OtherProducts"].ToString() : lblqffromothersDesc.Text = ""; ;
    //            }
    //        }
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

    # region METHOD "FillLanguage Checking"
    public void FillLanguage(Label label, CheckBox cb1, CheckBox cb2, CheckBox cb3, string slanguage)
    {
        string[] sSplit = slanguage.Split(new char[] { '|' });
        //label.Text = sSplit[1].ToString();

        Hashtable htLng = new Hashtable();
        DataSet dslng = new DataSet();
        htLng.Add("@LngCode", sSplit[1].ToString());
        dslng = dataAccessclass.GetDataSetForPrc_inscdirect("prc_GetLngDesc", htLng);
        //added by pranjali on 03-04-2014 start
        if (dslng.Tables[0].Rows.Count > 0)
        {
            label.Text = dslng.Tables[0].Rows[0]["Lang"].ToString();
        }
        //added by pranjali on 03-04-2014 end
        //label.Text = dslng.Tables[0].Rows[0]["Lang"].ToString();

        if (sSplit[2].ToString() == "Y")
        {
            cb1.Checked = true;

            cb1.Visible = true;
            lblqfread1.Visible = true;
            lblqfread2.Visible = true;
        }
        else
        {
            cb1.Checked = false;

            cb1.Visible = false;
            //commented by pranjali on 03-04-2014 start
            //lblqfread1.Visible = false;
            //lblqfread2.Visible = false;
            //commented by pranjali on 03-04-2014 end
        }
        if (sSplit[3].ToString() == "Y")
        {
            cb2.Checked = true;

            cb2.Visible = true;
            lblqfwrite1.Visible = true;
            lblqfwrite2.Visible = true;
        }
        else
        {
            cb2.Checked = false;

            cb2.Visible = false;
            //commented by pranjali on 03-04-2014 start
            //lblqfwrite1.Visible = false;
            //lblqfwrite2.Visible = false;
            //commented by pranjali on 03-04-2014 end
        }
        if (sSplit[4].ToString() == "Y")
        {
            cb3.Checked = true;
            //Added by kalyani on 8-1-2014 to make language checkbox visible
            cb3.Visible = true;
            lblqfspeak1.Visible = true;
            lblqfspeak2.Visible = true;
        }
        else
        {
            cb3.Checked = false;

            cb3.Visible = false;
            //commented by pranjali on 03-04-2014 start
            //lblqfspeak1.Visible = false;
            //lblqfspeak2.Visible = false;
            //commented by pranjali on 03-04-2014 end
        }

    }
    #endregion


    //comment by Prathamesh 16-6-15
    //added by pranjali on 03-04-2014 start
    //private void PopulateCndEmpHistDtls()
    //{
    //    try
    //    {
    //        htParam.Clear();
    //        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //        htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
    //        //dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView", htParam, "INSCRecruitConnectionString");
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView2", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables.Count > 0)
    //        {
    //            if (dsResult.Tables[0].Rows.Count > 0)
    //            {
    //                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
    //                {
    //                    lblecndno.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
    //                    //lblehcategory.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
    //                    lbleappno.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
    //                    lbleregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                    lblegivenname.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
    //                    lblesurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();
    //                    if (dsResult.Tables[0].Rows[0]["URN"].ToString().ToString().Trim() != "" && dsResult.Tables[0].Rows[0]["URN"].ToString().Trim() != null)
    //                    {
    //                        lblCndUrnV3Desc.Visible = true;
    //                        lblCndUrnV3Desc.Text = dsResult.Tables[0].Rows[0]["URN"].ToString();
    //                    }
    //                    else
    //                    {
    //                        lblCndUrnV3.Visible = false;
    //                        lblCndUrnV3Desc.Visible = false;
    //                    }
    //                    if ((dsResult.Tables[0].Rows[i]["EmpSeqNo"].ToString() != ""))
    //                    {
    //                        if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 1)
    //                        {
    //                            lblDtStrtPrevEmp1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblDtEndPrevEmp1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblPrevEmpName1.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                            lbladdofempDesc1.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                            lblEmpPositionDesc1.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                            lblLastIncomeDesc1.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                            lblreasforleave1.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        }
    //                        if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 2)
    //                        {
    //                            lblDtStrtPrevEmp2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblDtEndPrevEmp2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblPrevEmpName2.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                            lbladdofempDesc2.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                            lblEmpPositionDesc2.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                            lblLastIncomeDesc2.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                            lblreasforleave2.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        }
    //                        if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 3)
    //                        {
    //                            lblDtStrtPrevEmp3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblDtEndPrevEmp3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblPrevEmpName3.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                            lbladdofempDesc3.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                            lblEmpPositionDesc3.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                            lblLastIncomeDesc3.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                            lblreasforleave3.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        }
    //                        if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 4)
    //                        {
    //                            lblDtStrtPrevEmp4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblDtEndPrevEmp4.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblPrevEmpName4.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                            lbladdofempDesc4.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                            lblEmpPositionDesc4.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                            lblLastIncomeDesc4.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                            lblreasforleave4.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        }
    //                        if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 5)
    //                        {
    //                            lblDtStrtPrevEmp5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblDtEndPrevEmp5.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            lblPrevEmpName5.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                            lbladdofempDesc5.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                            lblEmpPositionDesc5.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                            lblLastIncomeDesc5.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                            lblreasforleave5.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        }
    //                        //if (Convert.ToInt32(dsResult.Tables[0].Rows[i]["EmpSeqNo"]) == 6)
    //                        //{
    //                        //    lblDtStrtPrevEmp6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        //    lblDtEndPrevEmp6.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        //    lblPrevEmpName6.Text = dsResult.Tables[0].Rows[i]["CompName"].ToString();
    //                        //    lbladdofempDesc6.Text = dsResult.Tables[0].Rows[i]["CompAdr"].ToString();
    //                        //    lblEmpPositionDesc6.Text = dsResult.Tables[0].Rows[i]["PositionHeld"].ToString();
    //                        //    lblLastIncomeDesc6.Text = dsResult.Tables[0].Rows[i]["AnnIncome"].ToString();
    //                        //    lblreasforleave6.Text = dsResult.Tables[0].Rows[i]["CseReasonDesc"].ToString();
    //                        //}
    //                    }
    //                }
    //            }

    //            else
    //            {
    //                rbinsagency.SelectedIndex = 1;
    //                rbotherexp.SelectedIndex = 1;
    //                // TrIA1.Visible = false; TrIA2.Visible = false; TrIA3.Visible = false; TrIA4.Visible = false;
    //            }
    //        }
    //        dsResult.Dispose();
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd3", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables[0].Rows.Count > 0)
    //        {
    //            rbotherexp.SelectedValue = "Y";
    //            for (int j = 0; j < dsResult.Tables[0].Rows.Count; j++)
    //            {

    //                lblEmpRecordName1.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["CompName"]);
    //                lblJobNature1.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkTypeDesc"]);
    //                lblJobField1.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkField"]);

    //                if (dsResult.Tables[0].Rows[j]["StartDate"] != null)
    //                {
    //                    if (dsResult.Tables[0].Rows[j]["StartDate"].ToString().Trim() != "")
    //                    {
    //                        lblEmpFromDt1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                    }
    //                }
    //                if (dsResult.Tables[0].Rows[j]["EndDate"] != null)
    //                {
    //                    if (dsResult.Tables[0].Rows[j]["EndDate"].ToString().Trim() != "")
    //                    {
    //                        lblEmpToDt1.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                    }
    //                }

    //                if (j == 1)
    //                {
    //                    lblEmpRecordName2.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["CompName"]);
    //                    lblJobNature2.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkTypeDesc"]);
    //                    lblJobField2.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkField"]);

    //                    if (dsResult.Tables[0].Rows[j]["StartDate"] != null)
    //                    {
    //                        if (dsResult.Tables[0].Rows[j]["StartDate"].ToString().Trim() != "")
    //                        {
    //                            lblEmpFromDt2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        }
    //                    }
    //                    if (dsResult.Tables[0].Rows[j]["EndDate"] != null)
    //                    {
    //                        if (dsResult.Tables[0].Rows[j]["EndDate"].ToString().Trim() != "")
    //                        {
    //                            lblEmpToDt2.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        }
    //                    }
    //                }

    //                if (j == 2)
    //                {
    //                    lblEmpRecordName3.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["CompName"]);
    //                    lblJobNature3.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkTypeDesc"]);
    //                    lblJobField3.Text = Convert.ToString(dsResult.Tables[0].Rows[j]["WorkField"]);

    //                    if (dsResult.Tables[0].Rows[j]["StartDate"] != null)
    //                    {
    //                        if (dsResult.Tables[0].Rows[j]["StartDate"].ToString().Trim() != "")
    //                        {
    //                            lblEmpFromDt3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["StartDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        }
    //                    }
    //                    if (dsResult.Tables[0].Rows[j]["EndDate"] != null)
    //                    {
    //                        if (dsResult.Tables[0].Rows[j]["EndDate"].ToString().Trim() != "")
    //                        {
    //                            lblEmpToDt3.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[j]["EndDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            rbinsagency.SelectedIndex = 1;
    //            rbotherexp.SelectedIndex = 1;
    //            // TrIA1.Visible = false; TrIA2.Visible = false; TrIA3.Visible = false; TrIA4.Visible = false;
    //        }

    //        dsResult.Dispose();
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCnds03", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables[0].Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
    //            {
    //                if (dsResult.Tables[0].Rows[i]["IsInsExp"] != null)
    //                {
    //                    if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString() == "Y")
    //                    {
    //                        rbinsagency.SelectedValue = "Y";
    //                        lblehnameofcompDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompName"]);
    //                        lblehlicnoDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["LcnNo"]);
    //                        lblehagencycodeDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CompAgentCode"]);
    //                        lblehterreasonDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CseReasonDesc"]);
    //                        if (dsResult.Tables[0].Rows[i]["IsInsExp"] != null)
    //                        {
    //                            if (dsResult.Tables[0].Rows[i]["IsInsExp"].ToString().Trim() != "")
    //                            {
    //                                rbinsagency.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["IsInsExp"]);
    //                            }
    //                        }
    //                        if (dsResult.Tables[0].Rows[i]["LcnIssDate"] != null)
    //                        {
    //                            if (dsResult.Tables[0].Rows[i]["LcnIssDate"].ToString().Trim() != "")
    //                            {
    //                                lblehdateofissueDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnIssDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            }
    //                        }
    //                        if (dsResult.Tables[0].Rows[i]["LcnExpDate"] != null)
    //                        {
    //                            if (dsResult.Tables[0].Rows[i]["LcnExpDate"].ToString().Trim() != "")
    //                            {
    //                                lblehvaliddateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["LcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            }
    //                        }
    //                        if (dsResult.Tables[0].Rows[i]["CseDate"] != null)
    //                        {
    //                            if (dsResult.Tables[0].Rows[i]["CseDate"].ToString().Trim() != "")
    //                            {
    //                                lblehterminationdateDesc.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[i]["CseDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                            }
    //                        }
    //                        SetEnabledtrue();
    //                    }
    //                    else
    //                    {
    //                        rbinsagency.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["IsInsExp"]);
    //                    }
    //                }
    //                else
    //                {

    //                    SetEnabledfalse();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            rbinsagency.SelectedValue = "N";
    //        }
    //    }

    //    //}
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
    //added by pranjali on 03-04-2014 end






    //comment by Prathamesh 16-6-15 
    //private void PopulateCndDiciplinaryInfoDtls()
    //{
    //    try
    //    {
    //        htParam.Clear();
    //        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //        htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView4", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables.Count > 0)
    //        {
    //            if (dsResult.Tables[0].Rows.Count > 0)
    //            {

    //                lblpcndno.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
    //                //lbldicategory.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
    //                lblpappno.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
    //                lblpregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                lblpgivenname.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
    //                lblpSurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();
    //                if (dsResult.Tables[0].Rows[0]["URN"].ToString().ToString().Trim() != "" && dsResult.Tables[0].Rows[0]["URN"].ToString().Trim() != null)
    //                {
    //                    lblCndUrnV4Desc.Visible = true;
    //                    lblCndUrnV4Desc.Text = dsResult.Tables[0].Rows[0]["URN"].ToString();
    //                }
    //                else
    //                {
    //                    lblCndUrnV4.Visible = false;
    //                    lblCndUrnV4Desc.Visible = false;
    //                }
    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]) != null)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn01"]).Trim() != "")
    //                    {
    //                        rbQstn01.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn01"].ToString();
    //                    }

    //                }
    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]) != null)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn02"]).Trim() != "")
    //                    {
    //                        rbQstn02.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn02"].ToString();
    //                    }

    //                }
    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]) != null)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn03"]).Trim() != "")
    //                    {
    //                        rbQstn03.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn03"].ToString();
    //                    }

    //                }
    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]) != null)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Qstn04"]).Trim() != "")
    //                    {
    //                        rbQstn04.SelectedValue = dsResult.Tables[0].Rows[0]["Qstn04"].ToString();
    //                    }

    //                }
    //                lblditrefname1Desc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName01"]).Trim();
    //                lbldiRefname2Desc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RefName02"]).Trim();

    //                for (int a = 0; a < dsResult.Tables[0].Rows.Count; a++)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C1")
    //                    {
    //                        lbldiref1addressDesc1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
    //                        lbldiref1addressDesc2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
    //                        lbldiref1addressDesc3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
    //                        lbldiRef1PincodeDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
    //                        //lbldiRef1stateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateName"]).Trim();
    //                        //lbldiRef1countryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc"]).Trim();
    //                        //added by pranjali on 03-04-2014 start
    //                        lbldiRef1stateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc"]).Trim();
    //                        lbldiRef1countryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc"]).Trim();
    //                        //added by pranjali on 03-04-2014 end
    //                    }

    //                    if (Convert.ToString(dsResult.Tables[0].Rows[a]["CnctType"]) == "C2")
    //                    {
    //                        lbldiRef2AddDesc1.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr1"]).Trim();
    //                        lbldiRef2AddDesc2.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr2"]).Trim();
    //                        lbldiRef2AddDesc3.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["Adr3"]).Trim();
    //                        lbldiRef2PincodeDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["PostCode"]).Trim();
    //                        //lbldiRef2StateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateName"]).Trim();
    //                        //lbldiRef2CountryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc2"]).Trim();
    //                        //added by pranjali on 03-04-2014 start
    //                        lbldiRef2StateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["StateDesc"]).Trim();
    //                        lbldiRef2CountryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[a]["CountryDesc"]).Trim();
    //                        //added by pranjali on 03-04-2014 end

    //                    }
    //                }


    //            }
    //        }
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

    //private void PopulateCndBizPlanDtls()
    //{

    //    try
    //    {
    //        htParam.Clear();
    //        htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //        htParam.Add("@CarrierCode", Session["CarrierCode"].ToString());
    //        //dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView", htParam, "INSCRecruitConnectionString");
    //        dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView5", htParam, "INSCRecruitConnectionString");
    //        if (dsResult.Tables.Count > 0)
    //        {
    //            if (dsResult.Tables[0].Rows.Count > 0)
    //            {
    //                lblbcndno.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
    //                //lblbpcategory.Text = dsResult.Tables[0].Rows[0]["CndCat"].ToString();
    //                lblbappno.Text = dsResult.Tables[0].Rows[0]["AppNo"].ToString();
    //                lblbregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["EntryDate"])).ToString(CommonUtility.DATE_FORMAT);
    //                lblbgivenname.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
    //                lblbSurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString();
    //                if (dsResult.Tables[0].Rows[0]["URN"].ToString().ToString().Trim() != "" && dsResult.Tables[0].Rows[0]["URN"].ToString().Trim() != null)
    //                {
    //                    lblCndUrnV5Desc.Visible = true;
    //                    lblCndUrnV5Desc.Text = dsResult.Tables[0].Rows[0]["URN"].ToString();
    //                }
    //                else
    //                {
    //                    lblCndUrnV5.Visible = false;
    //                    lblCndUrnV5Desc.Visible = false;
    //                }

    //                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
    //                {
    //                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "1")
    //                    {
    //                        lblbpyear1Desc1.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[0]["NoofLives"]);
    //                        lblbpyear1Desc2.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[0]["SumAssured"]);
    //                        lblbpyear1Desc3.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[0]["FYP"]);
    //                    }

    //                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "2")
    //                    {
    //                        lblbpyear2Desc1.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[1]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["NoofLives"]).Trim();
    //                        lblbpyear2Desc2.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[1]["SumAssured"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["SumAssured"]).Trim();
    //                        lblbpyear2Desc3.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[1]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[1]["FYP"]).Trim();
    //                    }

    //                    if (dsResult.Tables[0].Rows[i]["year"].ToString() == "3")
    //                    {
    //                        lblbpyear3Desc1.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[2]["NoofLives"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["NoofLives"]).Trim();
    //                        lblbpyear3Desc2.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[2]["SumAssured"]);// Convert.ToString(dsResult.Tables[0].Rows[2]["SumAssured"]).Trim();
    //                        lblbpyear3Desc3.Text = String.Format("{0:##}", dsResult.Tables[0].Rows[2]["FYP"]); //Convert.ToString(dsResult.Tables[0].Rows[2]["FYP"]).Trim();
    //                    }
    //                }
    //                lblbpifyesDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWorkDesc"]).Trim();
    //                lblbpanyotherinformationDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PastAchievement"]).Trim();

    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["IsFullTime"]) != null)
    //                {
    //                    if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["IsFullTime"]) == false)
    //                    {
    //                        rbtimework.SelectedValue = "0";
    //                    }
    //                    else
    //                        rbtimework.SelectedValue = "1";
    //                }


    //                if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]) != null)
    //                {
    //                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["RelativeAtWork"]).Trim() != "")
    //                    {
    //                        rbrelatedemp.SelectedValue = dsResult.Tables[0].Rows[0]["RelativeAtWork"].ToString();
    //                    }

    //                }

    //            }
    //        }
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




    private void PopulateTrainigDtls()
    {

        try
        {
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htParam.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htParam.Add("@Flag", "RE");
            }
            else
            {
                htParam.Add("@Flag", "NR");
            }
            dsResult = dataAccessclass.GetDataSetForPrcRecruit("prc_CndAdmin_getCndView6", htParam);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    #region Training Details
                    //if (IsPostBack)
                    //{
                    lblqfpersonalinformation1.Text = ViewState["lblqfpersonalinformation"].ToString();
                    lblqfcndnotitle1.Text = ViewState["lblqfcndnotitle"].ToString();
                    lblcndidDesc1.Text = ViewState["lblcndidDesc"].ToString();
                    lblCndUrn2.Text = ViewState["lblCndUrn"].ToString();
                    lblCndUrnDesc1.Text = ViewState["lblCndUrnDesc"].ToString();
                    lblqfappnotitle1.Text = ViewState["lblqfappnotitle"].ToString();
                    lblpfappnoDesc1.Text = ViewState["lblpfappnoDesc"].ToString();
                    lblqfregdatetitle1.Text = ViewState["lblqfregdatetitle"].ToString();
                    lblpfregdateDesc1.Text = ViewState["lblpfregdateDesc"].ToString();

                    lblqfgivennametitle1.Text = ViewState["lblqfgivennametitle"].ToString();
                    lblpfgivenNameDesc1.Text = ViewState["lblpfgivenNameDesc"].ToString();
                    lblqfsurname1.Text = ViewState["lblqfsurname"].ToString();
                    lblpfSurNameDesc1.Text = ViewState["lblpfSurNameDesc"].ToString();
                    lblTrndetails1.Text = ViewState["lblTrndetails"].ToString();
                    lblTrnMode1.Text = ViewState["lblTrnMode"].ToString();
                    TrnMode1.Text = dsResult.Tables[0].Rows[0]["TrnMode"].ToString();// ViewState["TrnMode"].ToString();
                    lblTrnLoc1.Text = ViewState["lblTrnLoc"].ToString();
                    TrnLocDesc1.Text = dsResult.Tables[0].Rows[0]["TrnLocDesc"].ToString();// ViewState["TrnLocDesc"].ToString();
                    lblTrnInstitute1.Text = ViewState["lblTrnInstitute"].ToString();
                    TrnInstitute2.Text = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString();// ViewState["TrnInstitute"].ToString();
                    lblAccrdtn1.Text = ViewState["lblAccrdtn"].ToString();
                    AccrdNo1.Text = dsResult.Tables[0].Rows[0]["AccrdNo"].ToString();//ViewState["AccrdNo"].ToString();
                    lblTrnstrtDate1.Text = ViewState["lblTrnstrtDate"].ToString();

                    TrnStartDate1.Text = dsResult.Tables[0].Rows[0]["TrnStartDate"].ToString();// ViewState["TrnStartDate"].ToString();
                    lblTrnEndDate1.Text = ViewState["lblTrnEndDate"].ToString();
                    TrnEndDate1.Text = dsResult.Tables[0].Rows[0]["TrnEndDate"].ToString();// ViewState["TrnEndDate"].ToString();
                    lblHrnTrn1.Text = ViewState["lblHrnTrn"].ToString();
                    HrsTrn1.Text = dsResult.Tables[0].Rows[0]["HrsTrn"].ToString();//ViewState["HrsTrn"].ToString();
                    
                    string str = string.Empty;
                    str = "<table id='trntbl' class='tableIsys' width='100%'>";

                    if (dsResult.Tables.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows.Count > 0)
                        {


                            for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                            {
                                str += "<tr>";
                                str += "<td colspan='4' class='formcontent'><b>" + ViewState["lblTrndetails"].ToString();
                                str += "</b></td>";
                                str += "</tr>";
                                str += "<tr>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblTrnMode"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnMode"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblTrnLoc"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnLocDesc"].ToString();
                                str += "</td>";
                                str += "</tr>";
                                str += "<tr>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblTrnInstitute"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnInstitute"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblAccrdtn"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["AccrdNo"].ToString();
                                str += "</td>";
                                str += "</tr>";

                                str += "<tr>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblTrnstrtDate"].ToString().ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnStartDate"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblTrnEndDate"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnEndDate"].ToString();
                                str += "</td >";
                                str += "</tr>";

                                str += "<tr>";
                                str += "<td class='formcontent' align='left'>" + ViewState["lblHrnTrn"].ToString();
                                str += "</td>";
                                str += "<td class='formcontent' align='left' colspan='3'>" + dsResult.Tables[0].Rows[i]["HrsTrn"].ToString();
                                str += "</td>";

                                str += "</tr>";

                            }
                            str += "</table>";

                            //   divTrnDtls.InnerHtml = strpersoanlDtls + Environment.NewLine + str;

                        }
                        else
                        {
                            LinkPage6.Visible = false;

                        }
                    }
                    // }
                    #endregion
                }
                else
                {
                    LinkPage6.Visible = false;
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
    //added by nikhil for noc information
    private void PopulateNOCDtls()
    {

        try
        {
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());
            //dsResult = dataAccessclass.GetDataSetForPrcDBConn("[prc_CndAdmin_getCndNOCView]", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("[prc_CndAdmin_getCndNOCView]", htParam );
          
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                LinkPage8.Visible = true;
                lblCndNoValue.Text = dsResult.Tables[0].Rows[0]["CndNo"].ToString();
                lblCndNameValue.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString();
                lblagencycodeValue.Text = dsResult.Tables[0].Rows[0]["Agent_Broker_Code"].ToString();
                lbldateissuevalue.Text = dsResult.Tables[0].Rows[0]["IssueDate"].ToString();
                lblsnlve.Text = dsResult.Tables[0].Rows[0]["Leave_Type"].ToString();
                lbldoar.Text = dsResult.Tables[0].Rows[0]["AcceptDate"].ToString();
                lbldate.Text = dsResult.Tables[0].Rows[0]["submitDate"].ToString();
                txtReInsurer.Text = dsResult.Tables[0].Rows[0]["RemarkforInsurer"].ToString();
                txtreasonleave.Text = dsResult.Tables[0].Rows[0]["RemarksForLeave"].ToString();
                tbNOC.Visible = true;
                if (txtReInsurer.Text == "")
                {
                    trInsurer.Attributes.Add("style", "display:none");
                }

            }
            else
            {
                LinkPage8.Visible = false;
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
    private void PopulateExmDtls()
    {

        try
        {
            htParam.Clear();
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString());

            if (ViewState["RenewalFlag"].ToString() == "Y")//Renewal QC
            {
                htParam.Add("@Flag", "RW");
            }
            else if (ViewState["ReExmType"].ToString() == "V" || ViewState["ReExmType"].ToString() == "I")
            {
                htParam.Add("@Flag", "RE");
            }
            else
            {
                htParam.Add("@Flag", "NR");
            }



          //  dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_getCndView7", htParam, "INSCRecruitConnectionString");
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("prc_CndAdmin_getCndView7", htParam);
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    #region Exam Details
                    // lblqfpersonalinformation2.Text= ViewState["lblqfpersonalinformation"].ToString();
                    lblqfcndnotitle2.Text = ViewState["lblqfcndnotitle"].ToString();
                    lblcndidDesc2.Text = ViewState["lblcndidDesc"].ToString();
                    lblCndUrn2.Text = ViewState["lblCndUrn"].ToString();
                    lblCndUrnDesc2.Text = ViewState["lblCndUrnDesc"].ToString();
                    lblqfappnotitle2.Text = ViewState["lblqfappnotitle"].ToString();
                    lblpfappnoDesc2.Text = ViewState["lblpfappnoDesc"].ToString();
                    lblqfregdatetitle2.Text = ViewState["lblqfregdatetitle"].ToString();
                    lblqfpersonalinformation2.Text = ViewState["lblqfpersonalinformation"].ToString();
                    lblqfcndnotitle2.Text = ViewState["lblqfcndnotitle"].ToString();
                    lblcndidDesc2.Text = ViewState["lblcndidDesc"].ToString();
                    lblCndUrn2.Text = ViewState["lblCndUrn"].ToString(); ;
                    lblCndUrnDesc2.Text = ViewState["lblCndUrnDesc"].ToString();
                    lblqfappnotitle2.Text = ViewState["lblqfappnotitle"].ToString();
                    lblpfappnoDesc2.Text = ViewState["lblpfappnoDesc"].ToString();
                    lblqfregdatetitle2.Text = ViewState["lblpfappnoDesc"].ToString();
                    lblpfregdateDesc2.Text = ViewState["lblpfregdateDesc"].ToString();
                    lblqfgivennametitle2.Text = ViewState["lblqfgivennametitle"].ToString();

                    lblpfgivenNameDesc2.Text = ViewState["lblpfgivenNameDesc"].ToString();

                    lblqfsurname.Text = ViewState["lblqfsurname"].ToString();

                    lblpfSurNameDesc2.Text = ViewState["lblpfSurNameDesc"].ToString();



                    lblexmdetails.Text = ViewState["lblexmdetails"].ToString();

                    lblSystemDt1.Text = ViewState["lblSystemDt"].ToString();
                    SystemExmDt1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["SystemExmDt"].ToString()).Trim();
                    lblCreatDt1.Text = ViewState["lblCreatDt"].ToString();
                    CreateDtim1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CreateDtim"].ToString()).Trim();
                    lblpreffDt11.Text = ViewState["lblpreffDt1"].ToString();
                    PreffExmDt11.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PreffExmDt1"].ToString()).Trim();
                    lblSAPCode1.Text = ViewState["lblSAPCode"].ToString();
                    Agent_SAPCODE1.Text = dsResult.Tables[0].Rows[0]["Agent_SAPCODE"].ToString();
                    lblpreffDt2.Text = ViewState["lblpreffDt2"].ToString();
                    PreffExmDt2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PreffExmDt2"].ToString()).Trim();
                    lblExmLang1.Text = ViewState["lblExmLang"].ToString();

                    ExamLanguage1.Text = dsResult.Tables[0].Rows[0]["ExamLanguage"].ToString();



                    lblExmStrtTime1.Text = ViewState["lblExmStrtTime"].ToString();

                    ExmStartTime1.Text = dsResult.Tables[0].Rows[0]["ExmStartTime"].ToString();

                    lblExmVenue1.Text = ViewState["lblExmVenue"].ToString();

                    TrnInstitute1.Text = dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString();



                    lblExmResult1.Text = ViewState["lblExmResult"].ToString();

                    ExmResult1.Text = dsResult.Tables[0].Rows[0]["ExmResult"].ToString();

                    lblExmAssStat1.Text = ViewState["lblExmAssStat"].ToString();

                    ExmAssStatus1.Text = dsResult.Tables[0].Rows[0]["ExmAssStatus"].ToString();



                    lblRemarks1.Text = ViewState["lblRemarks"].ToString();

                    Remarks.Text = dsResult.Tables[0].Rows[0]["Remarks"].ToString();

                    lblRollNo1.Text = ViewState["lblRollNo"].ToString();

                    RollNumber1.Text = dsResult.Tables[0].Rows[0]["RollNumber"].ToString();



                    lblExmMark1.Text = ViewState["lblExmMark"].ToString();

                    ExmMarks1.Text = dsResult.Tables[0].Rows[0]["ExmMarks"].ToString();

                    lblExmMode1.Text = ViewState["lblExmMode"].ToString();

                    ExmMode1.Text = dsResult.Tables[0].Rows[0]["ExmMode"].ToString();



                    lblExmCenter1.Text = ViewState["lblExmCenter"].ToString();

                    //  TrnInstitute1.Text=        dsResult.Tables[0].Rows[0]["TrnInstitute"].ToString();

                    lblRecruiterName1.Text = ViewState["lblRecruiterName"].ToString();

                    RecruitAgtName1.Text = dsResult.Tables[0].Rows[0]["RecruitAgtName"].ToString();
                    lblToken1.Text = ViewState["lblToken"].ToString();
                    FeesTokenNo1.Text = dsResult.Tables[0].Rows[0]["FeesTokenNo"].ToString();
                    lblFees1.Text = ViewState["lblFees"].ToString();
                    TotalFees1.Text = dsResult.Tables[0].Rows[0]["TotalFees"].ToString();

                    //if (IsPostBack)
                    //{
                    //string strpersoanlDtls1 = string.Empty;
                    //strpersoanlDtls1 = "<table id='trntblper' class='tableIsys' width='100%'>";
                    //strpersoanlDtls1 += "<tr>";
                    //strpersoanlDtls1 += "<td colspan='4' class='formcontent'><b>" + ViewState["lblqfpersonalinformation"];
                    //strpersoanlDtls1 += "</b></td>";
                    //strpersoanlDtls1 += "</tr>";
                    //strpersoanlDtls1 += "<tr>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblqfcndnotitle"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblcndidDesc"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblCndUrn"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //if (ViewState["lblCndUrnDesc"].ToString() != "")
                    //{
                    //    strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblCndUrnDesc"].ToString();
                    //    strpersoanlDtls1 += "</td>";
                    //}
                    //else
                    //{
                    //    strpersoanlDtls1 += "<td class='formcontent' align='left'>";
                    //    strpersoanlDtls1 += "</td>";
                    //}

                    //strpersoanlDtls1 += "</tr>";
                    //strpersoanlDtls1 += "<tr>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblqfappnotitle"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblpfappnoDesc"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblqfregdatetitle"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblpfregdateDesc"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "</tr>";
                    //strpersoanlDtls1 += "<tr>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblqfgivennametitle"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblpfgivenNameDesc"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblqfsurname"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "<td class='formcontent' align='left'>" + ViewState["lblpfSurNameDesc"].ToString();
                    //strpersoanlDtls1 += "</td>";
                    //strpersoanlDtls1 += "</tr>";

                    //strpersoanlDtls1 += "</table>";

                    //string strexm = string.Empty;
                    //strexm = "<table id='exmtbl' class='tableIsys' width='100%'>";

                    //if (dsResult.Tables.Count > 0)
                    //{
                    //    if (dsResult.Tables[0].Rows.Count > 0)
                    //    {

                    //        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                    //        {

                    //            strexm += "<tr>";
                    //            strexm += "<td colspan='4' class='formcontent'><b>" + ViewState["lblexmdetails"].ToString();
                    //            strexm += "</b></td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblSystemDt"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + Convert.ToString(dsResult.Tables[0].Rows[i]["SystemExmDt"].ToString()).Trim();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblCreatDt"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + Convert.ToString(dsResult.Tables[0].Rows[i]["CreateDtim"].ToString()).Trim();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";

                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblpreffDt1"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + Convert.ToString(dsResult.Tables[0].Rows[i]["PreffExmDt1"].ToString()).Trim();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblSAPCode"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["Agent_SAPCODE"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";

                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblpreffDt2"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + Convert.ToString(dsResult.Tables[0].Rows[i]["PreffExmDt2"].ToString()).Trim();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmLang"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExamLanguage"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmStrtTime"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExmStartTime"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmVenue"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnInstitute"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmResult"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExmResult"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmAssStat"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExmAssStatus"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblRemarks"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["Remarks"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblRollNo"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["RollNumber"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmMark"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExmMarks"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmMode"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["ExmMode"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblExmCenter"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TrnInstitute"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblRecruiterName"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["RecruitAgtName"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";
                    //            strexm += "<tr>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblToken"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["FeesTokenNo"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + ViewState["lblFees"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "<td class='formcontent' align='left'>" + dsResult.Tables[0].Rows[i]["TotalFees"].ToString();
                    //            strexm += "</td>";
                    //            strexm += "</tr>";


                    //        }
                    //        strexm += "</table>";
                    //        divExamDtls.InnerHtml = strpersoanlDtls1 + Environment.NewLine + strexm;
                }
                else
                {
                    LinkPage7.Visible = false;

                    //GridExam1.DataSource = null;
                    //GridExam1.DataBind();

                    //GridExam2.DataSource = null;
                    //GridExam2.DataBind();
                }
            }
            //  }
                    #endregion
            // }
            else
            {
                LinkPage7.Visible = false;
            }
            // }

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

    protected void lnkPage1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            btnCancel.Style.Add("display", "block");
            MultiView1.ActiveViewIndex = 0;
            //InitializeControl();
            lnkPage1.BackColor = Color.LightYellow;
            lnkPage2.BackColor = Color.Transparent;

            //comment by Pathamesh 17-6-15
            //lnkPage3.BackColor = Color.Transparent;
            //LinkPage5.BackColor = Color.Transparent;
            //LinkPage4.BackColor = Color.Transparent;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 1.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";
            LinkPage8.ImageUrl = "~/theme/iflow/tabs/NOC2.png";
            //comment by Pathamesh 17-6-15
            //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
            //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
            //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
            if (LinkPage6.Visible == true)
            {
                LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";

            }
            if (LinkPage7.Visible == true)
            {
                LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
            }
            //FillRequiredDataForCndPersonal();
            FillHiddenValues();
            PopulateCndPersonalDtls();

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


    //This Button added for Profiling by Prathamesh 17-6-15
    protected void lnkPage2_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            //olng added by Prathamesh 17-6-15
            // olng = new multilingualManager("DefaultConn", "CndView.aspx?&CndNo" + lblcndidDesc.Text + "", Session["UserLangNum"].ToString());
            btnCancel.Style.Add("display", "block");
            MultiView1.ActiveViewIndex = 1;
            lnkPage1.BackColor = Color.Transparent;
            lnkPage2.BackColor = Color.LightYellow;
            //.Visible = false;
            //comment by Pathamesh 17-6-15
            //lnkPage3.BackColor = Color.Transparent;
            //LinkPage5.BackColor = Color.Transparent;
            //LinkPage4.BackColor = Color.Transparent;
            lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
            lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling1.png";

            //comment by Pathamesh 17-6-15
            //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
            //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
            //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
            if (LinkPage6.Visible == true)
            {
                LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";

            }
            if (LinkPage7.Visible == true)
            {
                LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
            }

            //commment by Prathamesh 17-6-15
            //PopulateCndQualificationDtls();
            LinkPage8.ImageUrl = "~/theme/iflow/tabs/NOC2.png";

            //This Function added by Prathamesh 17-6-15
            GetPersonalInformation();
            FillRequiredDataForCndQualification();
            FillRequiredDataForCndEmpHistory();
            FillRequiredDataForCndPsnlhistory();
            FillRequiredDataForCndBizPlan();
            //FillHiddenValues();

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


    //comment by Pathamesh 17-6-15 Imagebutton
    //protected void lnkPage3_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        MultiView1.ActiveViewIndex = 2;
    //        lnkPage1.BackColor = Color.Transparent;
    //        lnkPage2.BackColor = Color.Transparent;
    //        lnkPage3.BackColor = Color.LightYellow;
    //        LinkPage5.BackColor = Color.Transparent;
    //        LinkPage4.BackColor = Color.Transparent;
    //        lblMessage.Text = "";
    //        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //        lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //        lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst1.png";
    //        LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
    //        LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
    //        if (LinkPage6.Visible == true)
    //        {
    //            LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";

    //        }
    //        if (LinkPage7.Visible == true)
    //        {
    //            LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
    //        }

    //        //comment by Prathamesh 16-6-15
    //        //PopulateCndEmpHistDtls();
    //        btnCancel.Visible = false;
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
    //protected void LinkPage4_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        MultiView1.ActiveViewIndex = 3;
    //        lnkPage1.BackColor = Color.Transparent;
    //        lnkPage2.BackColor = Color.Transparent;
    //        lnkPage3.BackColor = Color.Transparent;
    //        LinkPage4.BackColor = Color.LightYellow;
    //        LinkPage5.BackColor = Color.Transparent;
    //        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //        lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //        lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
    //        LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp1.png";
    //        LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
    //        if (LinkPage6.Visible == true)
    //        {
    //            LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";

    //        }
    //        if (LinkPage7.Visible == true)
    //        {
    //            LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
    //        }

    //        //Added by Prathamesh 16-6-15
    //        //PopulateCndDiciplinaryInfoDtls();
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
    //protected void LinkPage5_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {

    //        MultiView1.ActiveViewIndex = 4;
    //        lnkPage1.BackColor = Color.Transparent;
    //        lnkPage2.BackColor = Color.Transparent;
    //        lnkPage3.BackColor = Color.Transparent;
    //        LinkPage4.BackColor = Color.Transparent;
    //        LinkPage5.BackColor = Color.LightYellow;
    //        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
    //        lnkPage2.ImageUrl = "~/theme/iflow/tabs/Qual 2.png";
    //        lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
    //        LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
    //        LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 1.png";
    //        if (LinkPage6.Visible == true)
    //        {
    //            LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";

    //        }
    //        if (LinkPage7.Visible == true)
    //        {
    //            LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
    //        }

    //        //comment by Prathamesh 16-6-15
    //        //PopulateCndBizPlanDtls();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw;
    //    }
    //}

    protected void LinkPage6_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        lnkPage1.BackColor = Color.Transparent;
        lnkPage2.BackColor = Color.Transparent;

        //comment by Pathamesh 17-6-15
        //lnkPage3.BackColor = Color.Transparent;
        //LinkPage4.BackColor = Color.Transparent;
        //LinkPage5.BackColor = Color.Transparent;
        LinkPage6.BackColor = Color.Yellow;
        LinkPage7.BackColor = Color.Transparent;
        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";

        //comment by Pathamesh 17-6-15
        //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
        //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
        //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
        LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 1.png";
        LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
        LinkPage8.ImageUrl = "~/theme/iflow/tabs/NOC2.png";
        PopulateTrainigDtls();
        btnCancel.Visible = false;
    }
    protected void LinkPage7_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        lnkPage1.BackColor = Color.Transparent;
        lnkPage2.BackColor = Color.Transparent;

        //comment by Pathamesh 17-6-15
        //lnkPage3.BackColor = Color.Transparent;
        //LinkPage4.BackColor = Color.Transparent;
        //LinkPage5.BackColor = Color.Transparent;
        LinkPage6.BackColor = Color.Transparent;
        LinkPage7.BackColor = Color.Yellow;
        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";

        //comment by Pathamesh 17-6-15
        //lnkPage3.ImageUrl = "~/theme/iflow/tabs/EmpHst2.png";
        //LinkPage4.ImageUrl = "~/theme/iflow/tabs/Disp2.png";
        //LinkPage5.ImageUrl = "~/theme/iflow/tabs/Buss 2.png";
        LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";
        LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 1.png";
        LinkPage8.ImageUrl = "~/theme/iflow/tabs/NOC2.png";
        PopulateExmDtls();
        btnCancel.Visible = false;
    }
    protected void LinkPage8_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        lnkPage1.BackColor = Color.Transparent;
        lnkPage2.BackColor = Color.Transparent;

        LinkPage6.BackColor = Color.Transparent;
        LinkPage7.BackColor = Color.Transparent;
        LinkPage8.BackColor = Color.Yellow;
        lnkPage1.ImageUrl = "~/theme/iflow/tabs/Personal 2.png";
        lnkPage2.ImageUrl = "~/theme/iflow/tabs/profiling2.png";


        LinkPage6.ImageUrl = "~/theme/iflow/tabs/Train 2.png";
        LinkPage7.ImageUrl = "~/theme/iflow/tabs/Exam 2.png";
        LinkPage8.ImageUrl = "~/theme/iflow/tabs/NOC1.png";
        //  tbNC.Visible = true;
        // tbcndNOC.Visible = true;
        PopulateNOCDtls();
        //BindCandidateNOCMvmt();
        btnCancel.Visible = false;
    }
    protected void SetEnabledtrue()
    {
        //txtInsCompName.Enabled = true;
        //txtTerminationReason.Enabled = true;
        //txtInsAgencyCode.Enabled = true;
        //txtLcnNo.Enabled = true;


    }

    protected void SetEnabledfalse()
    {
        //txtInsCompName.Enabled = false;
        //txtTerminationReason.Enabled = false;
        //txtInsAgencyCode.Enabled = false;
        //txtLcnNo.Enabled = false;

        ////txtdateofissue.ClearText = "";
        //txtvaliddate.Text = "";
        ////txtterminatedate.ClearText = "";
        //txtInsCompName.Text = "";
        //txtTerminationReason.Text = "";
        //txtInsAgencyCode.Text = "";
        //txtLcnNo.Text = "";
    }

    protected void dgCndMvmt_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void dgCndMvmt_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    //Added by nikhil
    //protected void grdNOCStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}
    //protected void grdNOCStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = GetDataTableNOC();
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
    //        //BindGridControl(dgSource);
    //        //ShowPageInformation();
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
    //Ended by Nikhil
    private DataTable GetDataTable()
    {
        Hashtable htCndmvmt = new Hashtable();
        htCndmvmt.Add("@CndNo", Request.QueryString["CndNo"].ToString());

        DataSet dsCndMvmt = new DataSet();
        dsCndMvmt = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandidateMvmt", htCndmvmt);

        return dsCndMvmt.Tables[0];

    }
    //private DataTable GetDataTableNOC()
    //{
    //    Hashtable htCndmvmt = new Hashtable();
    //    htCndmvmt.Add("@CndNo", Request.QueryString["CndNo"].ToString());
    //    htCndmvmt.Add("@Flag", "1");
    //    DataSet dsCndMvmt = new DataSet();
    //    dsCndMvmt = dataAccessclass.GetDataSetForPrcDBConn("Prc_GetCandidateMvmt", htCndmvmt, "INSCRecruitConnectionString");

    //    return dsCndMvmt.Tables[0];

    //}
    protected void chkEdit_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEdit.Checked == true)
        {
            try
            {
                //divPermonantAddressEdit.Visible = true;
                //divPresentAddress.Visible = false;
                divPermonantAddressEdit.Attributes.Add("Style", "display:block");
                divPermonantAddressEdit.Visible = true;
                divPresentAddress.Attributes.Add("Style", "display:none");
                divPresentAddress.Visible = false;
                PopulateState();
                txtPermCountryCode.Text = "IND";

                txtPermCountryDesc.Text = "INDIAN";


                //Business and Resedential Address
                //lblpfaddresstypeDesc.Text = dsResult.Tables[0].Rows[0]["cnct"].ToString();
                //c.Text = dsResult.Tables[0].Rows[0]["StateName"].ToString();
                //lblpfAddrP1Desc.Text = dsResult.Tables[0].Rows[0]["Adr1"].ToString();
                //lbldistDesc.Text = dsResult.Tables[0].Rows[0]["District"].ToString();
                //lblpfAddrP2Desc.Text = dsResult.Tables[0].Rows[0]["Adr2"].ToString();
                //lblCityDesc.Text = dsResult.Tables[0].Rows[0]["city"].ToString();
                //lblpfAddrP3Desc.Text = dsResult.Tables[0].Rows[0]["Adr3"].ToString();
                //lblareaDesc.Text = dsResult.Tables[0].Rows[0]["Area"].ToString();
                //if (dsResult.Tables[0].Rows[0]["Village"].ToString() != "")
                //{
                //    lblVillageDesc.Text = dsResult.Tables[0].Rows[0]["Village"].ToString();
                //}
                //lblpfPinPDesc.Text = dsResult.Tables[0].Rows[0]["PinCode"].ToString();
                //lblpfCountryPDesc.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();

                //Bind Address to Edit field 
                lbladdtypeDesc.Text = lblpfaddresstypeDesc.Text;//dsResult.Tables[0].Rows[0]["cnct"].ToString();
                ddlstate1.SelectedItem.Text = c.Text;//dsResult.Tables[0].Rows[0]["StateName"].ToString();
                ddlstate1.SelectedItem.Value = ViewState["StateID"].ToString();
                txtPAddline1.Text = lblpfAddrP1Desc.Text;//dsResult.Tables[0].Rows[0]["Adr1"].ToString();
                txtPDistrict.Text = lbldistDesc.Text;//dsResult.Tables[0].Rows[0]["District"].ToString();
                txtPAdd2.Text = lblpfAddrP2Desc.Text;//dsResult.Tables[0].Rows[0]["Adr2"].ToString();
                txtPcity1.Text = lblCityDesc.Text;//dsResult.Tables[0].Rows[0]["city"].ToString();
                txtPAdd3.Text = lblpfAddrP3Desc.Text;//dsResult.Tables[0].Rows[0]["Adr3"].ToString();
                txtParea1.Text = lblareaDesc.Text;//dsResult.Tables[0].Rows[0]["Area"].ToString();
                //if (dsResult.Tables[0].Rows[0]["Village"].ToString() != "")
                //{
                txtpermvillage.Text = lblVillageDesc.Text;//dsResult.Tables[0].Rows[0]["Village"].ToString();
                //}
                txtPermPostcode.Text = lblpfPinPDesc.Text;//dsResult.Tables[0].Rows[0]["PinCode"].ToString();
                //lblpfCountryPDesc.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();
                //btnSave.Visible = true;

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
        else
        {
            //divPermonantAddressEdit.Attributes.Add("Style", "dispaly:none");
            //divPresentAddress.Attributes.Add("Style", "dispaly:block");
            //divPermonantAddressEdit.Visible = false;
            //divPresentAddress.Visible = true;

            divPermonantAddressEdit.Attributes.Add("Style", "display:none");
            divPermonantAddressEdit.Visible = false;
            divPresentAddress.Attributes.Add("Style", "display:block");
            divPresentAddress.Visible = true;
            btnSave.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htaddress = new Hashtable();

            htaddress.Add("@CndNo", lblcndidDesc.Text);
            htaddress.Add("@AppNo", lblpfappnoDesc.Text);

            if ((ChkPA.Checked) && divPermonantAddressEdit.Visible == true)//ChkPAEdit
            {
                if (lblpfaddresstypeDesc.Text == "Business 1")
                {
                    htaddress.Add("@CnctType", "B1");
                }
                else
                {
                    htaddress.Add("@CnctType", "P1");
                }
                htaddress.Add("@Adr1", txtPAddline1.Text);
                htaddress.Add("@Adr2", txtPAdd2.Text);
                htaddress.Add("@Adr3", txtPAdd3.Text);
                htaddress.Add("@City", txtPcity1.Text);
                htaddress.Add("@StateCode", ddlstate1.SelectedValue);
                htaddress.Add("@PostCode", txtPermPostcode.Text);
                htaddress.Add("@CntryCode", txtPermCountryCode.Text);
                htaddress.Add("@Area", txtParea1.Text);
                htaddress.Add("@District", txtPDistrict.Text);

                htaddress.Add("@PerCnctType", "M1");
                htaddress.Add("@PermAdr1", txtPAddline1.Text);
                htaddress.Add("@PermAdr2", txtPAdd2.Text);
                htaddress.Add("@PermAdr3", txtPAdd3.Text);

                htaddress.Add("@PermStateCode", ddlstate1.SelectedValue);

                htaddress.Add("@PermPostCode", txtPermPostcode.Text);
                htaddress.Add("@PermCntryCode", txtPermCountryCode.Text);
                htaddress.Add("@PermCity", txtPcity1.Text);
                htaddress.Add("@PermArea", txtParea1.Text);
                htaddress.Add("@PermDistrict", txtPDistrict.Text);
                htaddress.Add("@UpdateBy", Session["UserID"]);
            }
            else
            {
                if (divPermonantAddressEdit.Visible == true)
                //if (divPermonantAddressEdit.Style.ToString().Equals("block"))            
                {
                    if (lblpfaddresstypeDesc.Text == "Business 1")
                    {
                        htaddress.Add("@CnctType", "B1");
                    }
                    else
                    {
                        htaddress.Add("@CnctType", "P1");
                    }
                    htaddress.Add("@Adr1", txtPAddline1.Text);
                    htaddress.Add("@Adr2", txtPAdd2.Text);
                    htaddress.Add("@Adr3", txtPAdd3.Text);
                    htaddress.Add("@City", txtPcity1.Text);
                    htaddress.Add("@StateCode", ddlstate1.SelectedValue);
                    htaddress.Add("@PostCode", txtPermPostcode.Text);
                    htaddress.Add("@CntryCode", txtPermCountryCode.Text);
                    htaddress.Add("@Area", txtParea1.Text);
                    htaddress.Add("@District", txtPDistrict.Text);
                }
                else
                {
                    htaddress.Add("@CnctType", System.DBNull.Value);
                    htaddress.Add("@Adr1", System.DBNull.Value);
                    htaddress.Add("@Adr2", System.DBNull.Value);
                    htaddress.Add("@Adr3", System.DBNull.Value);
                    htaddress.Add("@City", System.DBNull.Value);
                    htaddress.Add("@StateCode", System.DBNull.Value);
                    htaddress.Add("@PostCode", System.DBNull.Value);
                    htaddress.Add("@CntryCode", System.DBNull.Value);
                    htaddress.Add("@Area", System.DBNull.Value);
                    htaddress.Add("@District", System.DBNull.Value);
                }
                if (divPerAddressEdit.Visible == true)
                {
                    htaddress.Add("@PerCnctType", "M1");
                    htaddress.Add("@PermAdr1", txtPAAddline1.Text);
                    htaddress.Add("@PermAdr2", txtPAAdd2.Text);
                    htaddress.Add("@PermAdr3", txtPAAdd3.Text);

                    htaddress.Add("@PermStateCode", ddlstatePA.SelectedValue);

                    htaddress.Add("@PermPostCode", txtPAPostcode.Text);
                    htaddress.Add("@PermCntryCode", txtPACounCode.Text);
                    htaddress.Add("@PermCity", txtPAcity1.Text);
                    htaddress.Add("@PermArea", txtPAarea1.Text);
                    htaddress.Add("@PermDistrict", txtPADistrict.Text);

                }
                else
                {
                    htaddress.Add("@PerCnctType", System.DBNull.Value);
                    htaddress.Add("@PermAdr1", System.DBNull.Value);
                    htaddress.Add("@PermAdr2", System.DBNull.Value);
                    htaddress.Add("@PermAdr3", System.DBNull.Value);

                    htaddress.Add("@PermStateCode", System.DBNull.Value);

                    htaddress.Add("@PermPostCode", System.DBNull.Value);
                    htaddress.Add("@PermCntryCode", System.DBNull.Value);
                    htaddress.Add("@PermCity", System.DBNull.Value);
                    htaddress.Add("@PermArea", System.DBNull.Value);
                    htaddress.Add("@PermDistrict", System.DBNull.Value);

                }
                htaddress.Add("@UpdateBy", Session["UserID"]);
            }
            //int x;
            //x = dataAccessclass.execute_sprcrecruit("prc_UpdCndAddress", htaddress);
            string strvalue = dataAccessclass.execute_sprc_with_output("prc_UpdCndAddress", htaddress, "@strOut");

            if (strvalue == "1")
            {
                //lbl.Text = "Address updated successfully.";
                //mdlpopup.Show();
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
    protected void chkPerEdit_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPerEdit.Checked == true)
        {

            divPerAddressEdit.Attributes.Add("Style", "display:block");
            divPerAddressEdit.Visible = true;
            divPermanentAddress.Attributes.Add("Style", "display:none");
            divPermanentAddress.Visible = true;
            PopulatePermState();
            txtPACounCode.Text = "IND";

            txtPACounCodeDesc.Text = "INDIAN";

            //permonant address
            //ChkPA.Checked = true;
            //lblpfprmAddDesc.Text = dsResult.Tables[0].Rows[0]["Adr1"].ToString();
            //lblpfprmstatecodeDesc.Text = dsResult.Tables[0].Rows[0]["StateName"].ToString();
            //lblpermDistrictDesc.Text = dsResult.Tables[0].Rows[0]["District"].ToString();
            //lblPermAdd2.Text = dsResult.Tables[0].Rows[0]["Adr2"].ToString();
            //lblcity1Desc.Text = dsResult.Tables[0].Rows[0]["city"].ToString();
            //Label30Desc.Text = dsResult.Tables[0].Rows[0]["Adr3"].ToString();
            //lblarea1Desc.Text = dsResult.Tables[0].Rows[0]["Area"].ToString();
            //lblpermVillageDesc.Text = dsResult.Tables[0].Rows[0]["Village"].ToString();
            //lblpfprmpostcodeDesc.Text = dsResult.Tables[0].Rows[0]["PinCode"].ToString();
            //lblpfprmcountryDesc.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();

            //Bind Address to Edit field 
            //lblPAaddtypeDesc.Text = lblpfaddresstypeDesc.Text;
            lblpfPrmAddTitleEdit.Text = lblpfPrmAddTitle.Text;
            if (ChkPA.Checked)
            {
                ChkPAEdit.Checked = true;
            }
            else
            {
                ChkPAEdit.Checked = false;
            }
            ddlstatePA.SelectedItem.Text = lblpfprmstatecodeDesc.Text;//dsResult.Tables[0].Rows[0]["StateName"].ToString();
            ddlstatePA.SelectedItem.Value = ViewState["StateID"].ToString();
            txtPAAddline1.Text = lblpfprmAddDesc.Text;//dsResult.Tables[0].Rows[0]["Adr1"].ToString();
            txtPADistrict.Text = lbldistDesc.Text;//dsResult.Tables[0].Rows[0]["District"].ToString();
            txtPAAdd2.Text = lblPermAdd2.Text;//dsResult.Tables[0].Rows[0]["Adr2"].ToString();
            txtPAcity1.Text = lblcity1Desc.Text;//dsResult.Tables[0].Rows[0]["city"].ToString();
            txtPAAdd3.Text = Label30Desc.Text;//dsResult.Tables[0].Rows[0]["Adr3"].ToString();
            txtPAarea1.Text = lblarea1Desc.Text;//dsResult.Tables[0].Rows[0]["Area"].ToString();
            //if (dsResult.Tables[0].Rows[0]["Village"].ToString() != "")
            //{
            txtPAvillage.Text = lblpermVillageDesc.Text;//dsResult.Tables[0].Rows[0]["Village"].ToString();
            //}
            txtPAPostcode.Text = lblpfprmpostcodeDesc.Text;//dsResult.Tables[0].Rows[0]["PinCode"].ToString();
            //lblpfCountryPDesc.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();
            //btnSave.Visible = true;

        }
        else
        {
            //divPermonantAddressEdit.Attributes.Add("Style", "dispaly:none");
            //divPresentAddress.Attributes.Add("Style", "dispaly:block");
            //divPerAddressEdit.Visible = false;
            //divPermanentAddress.Visible = true;
            //divPerAddressEdit.Attributes.Add("Style", "display:none");
            //divPermanentAddress.Attributes.Add("Style", "display:none");
            divPerAddressEdit.Attributes.Add("Style", "display:none");
            divPerAddressEdit.Visible = false;
            btnSave.Visible = false;
        }
    }


    //Added By Prathamesh for Profiling data bind to the modification page 17-6-15 start
    protected void GetProfilingDtls()
    {
        PopulateAgentType();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for AgentType ddl 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlagntype.SelectedValue = ds.Tables[0].Rows[0]["AgntType"].ToString().Trim();

            //store the value of dropdown selected value in label 
            lblAgntTypePF.Text = ddlagntype.SelectedItem.ToString().Trim();



        }
    }

    protected void GetRCAPcompany()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for RCAP company
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlIsWrkng.SelectedValue = ds.Tables[0].Rows[0]["IsWrkngInOthrRelnce"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblIsWrkngPF.Text = ddlIsWrkng.SelectedItem.ToString().Trim();
        }
    }

    protected void GetNoofyearsinInsurance()
    {
        YearsInInsurance();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added No of Years in insurance 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNoOfYrsIns.SelectedValue = ds.Tables[0].Rows[0]["YrsInInsrnce"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblNoOfYrsInsurancePF.Text = ddlNoOfYrsIns.SelectedItem.ToString().Trim();

        }
    }

    protected void GetDealerTypeOfVehicleDeal()
    {
        VechicleType();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        ////Added for If Dealer, type of vehicle dealing in
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeOfVehicle.SelectedValue = ds.Tables[0].Rows[0]["VhclType"].ToString().Trim();

            if (ddlTypeOfVehicle.SelectedIndex != 0)
            {
                //store the value of dropdown selected value in label
                lblTypeOfVehiclePF.Text = ddlTypeOfVehicle.SelectedItem.ToString().Trim();
            }

        }
    }

    protected void GetCompanyName()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Company Name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtDlrCompName.Text = ds.Tables[0].Rows[0]["DlrCompName"].ToString().Trim();

            //store the value of textbox in label
            lblDlrCompNamePF.Text = txtDlrCompName.Text.ToString().Trim();

        }
    }

    protected void GetComapnynNameIfYes()
    {
        oCommon.getDropDown(ddlcompName, "CompyName", 1, "", 1);
        ddlcompName.Items.Insert(0, "--Select--");
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Company Name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["CompName"].ToString().Trim() == "")
            {
                lblcompNamePF.Text = "";
            }
            else
            {
                ddlcompName.SelectedValue = ds.Tables[0].Rows[0]["CompName"].ToString().Trim();

                //store the value of textbox in label
                lblcompNamePF.Text = ddlcompName.SelectedItem.ToString().Trim();
            }
        }

    }

    protected void GetFromOthersSpecify1()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for From Others Specify2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtOthers.Text = ds.Tables[0].Rows[0]["OthrAgnType"].ToString().Trim();

            //store the value of textbox value in label
            lblOthersPF.Text = txtOthers.Text.ToString().Trim();
        }
    }

    protected void GetNoOfYearsWithReliance()
    {
        YearsInReliance();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for No. of years with reliance 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNoOfYrs.SelectedValue = ds.Tables[0].Rows[0]["YrsInRelnce"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblNoOfYearsPF.Text = ddlNoOfYrs.SelectedItem.ToString().Trim();
        }

    }

    protected void GetDealerVehicleManufacturerdealing()
    {
        VechicleManufacturer();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Dealer Vehicle Manufacturer dealing 
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlVechManuf.SelectedValue = ds.Tables[0].Rows[0]["VhclManf"].ToString().Trim();


            if (ddlVechManuf.SelectedIndex != 0)
            {
                //store the value of dropdown selected value in label
                lblVchlManfPF.Text = ddlVechManuf.SelectedItem.ToString().Trim();
            }


        }
    }

    protected void GetFromOthersSpecify2()
    {
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for From Others Specify2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtDlrOth.Text = ds.Tables[0].Rows[0]["DlrOthrCompName"].ToString().Trim();

            //store the value of textbox value in label
            lblDlrOthPF.Text = txtDlrOth.Text.ToString().Trim();
        }
    }

    protected void GetAvgMonthlyVolumeinLacs()
    {
        AverageMonthlyIncome();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Avg Monthly Volume in Lacs
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAvgMonthlyIncm.SelectedValue = ds.Tables[0].Rows[0]["AvgMnthVol"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblAvgVolInLacsPF.Text = ddlAvgMonthlyIncm.SelectedItem.ToString().Trim();
        }
    }

    protected void GetCompany1name()
    {
        CompetitorCompanyName1();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Get Company1 name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlComp1Name.SelectedValue = ds.Tables[0].Rows[0]["Comp1Name"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblComp1NamePF.Text = ddlComp1Name.SelectedItem.ToString().Trim();

        }
    }

    protected void GetCompany2name()
    {
        CompetitorCompanyName2();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Get Company2  name
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlComp2Name.SelectedValue = ds.Tables[0].Rows[0]["Comp2Name"].ToString().Trim();

            if (ddlComp2Name.SelectedIndex != 0)
            {
                //store the value of dropdown selected value in label
                lblComp2NamePF.Text = ddlComp2Name.SelectedItem.ToString().Trim();
            }


        }
    }

    protected void GetMonthlyVolumeInLacsCompany1()
    {
        ComptCompyMonthlyVolum();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Monthly Volume In Lacs Company1
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMnthVol1.SelectedValue = ds.Tables[0].Rows[0]["MnthVolFrComp1"].ToString().Trim();


            //store the value of dropdown selected value in label
            lblMnthVol1PF.Text = ddlMnthVol1.SelectedItem.ToString().Trim();

        }
    }

    protected void GetMonthlyVolumeInLacsCompany2()
    {
        ComptCompyMonthlyVolum2();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);


        //Added for Monthly Volume In Lacs Company2
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlMnthVol2.SelectedValue = ds.Tables[0].Rows[0]["MnthVolFrComp2"].ToString().Trim();

            if (ddlMnthVol2.SelectedIndex != 0)
            {
                //store the value of dropdown selected value in label
                lblMnthVol2PF.Text = ddlMnthVol2.SelectedItem.ToString().Trim();

            }


        }
    }

    protected void GetMonthlyVolumeInLacsRGI()
    {
        BusinessMonthlyVol();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIMnthVol.SelectedValue = ds.Tables[0].Rows[0]["RGIMnthVol"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblRGIMnthVolPF.Text = ddlRGIMnthVol.SelectedItem.ToString().Trim();

        }

    }

    protected void GetTotalBuisnessMotor()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnMtr.SelectedValue = ds.Tables[0].Rows[0]["TotBsnMtr"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblTotBsnMtrPF.Text = ddlTotBsnMtr.SelectedItem.ToString().Trim();
        }
    }

    protected void GetTotalBuisnessHealth()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnHlth.SelectedValue = ds.Tables[0].Rows[0]["TotBsnHlth"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblTotBsnHlthPF.Text = ddlTotBsnHlth.SelectedItem.ToString().Trim();

        }
    }

    protected void GetTotalBuisnessComercialLine()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTotBsnComm.SelectedValue = ds.Tables[0].Rows[0]["TotBsnCmrclLine"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblTotBsnCommPF.Text = ddlTotBsnComm.SelectedItem.ToString().Trim();

        }
    }

    protected void GetBusinessWithRGIMotor()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Monthly Volume In Lacs RGI
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnMtr.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnMtr"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblRGIBsnMtrPF.Text = ddlRGIBsnMtr.SelectedItem.ToString().Trim();
        }
    }

    protected void GetBusinessWithRGIHealth()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Business With RGI Health
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnHlth.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnHlth"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblRGIBsnHlthPF.Text = ddlRGIBsnHlth.SelectedItem.ToString().Trim();

        }
    }
    protected void GetStatus()
    {
        dsResult.Clear();

        Hashtable htParams = new Hashtable();
        htParams.Clear();
        // Dataset dsResult = new Dataset();
        htParams.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetCandType", htParams);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            hdnStausValue.Value = dsResult.Tables[0].Rows[0]["CndStatus"].ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "Hidetab(" + hdnStausValue.Value + ");", true);
        }
    }
    protected void GetBusinessWithRGIComercialLine()
    {
        TotalBusiness();
        Hashtable ht = new Hashtable();
        DataSet ds = new DataSet();
        ht.Add("@CndNo", lblcndidDesc.Text.ToString().Trim());
        ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetCndProfilingDtls", ht);

        //Added for Business With RGI Health
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRGIBsnComm.SelectedValue = ds.Tables[0].Rows[0]["RGIBsnCmrclLine"].ToString().Trim();

            //store the value of dropdown selected value in label
            lblRGIBsnCommPF.Text = ddlRGIBsnComm.SelectedItem.ToString().Trim();

        }
    }

    //Added By Prathamesh for Profiling data bind to the modification page 17-6-15 end


    protected void Bankdtls()
    {
        DataSet DsC = new DataSet();
        Hashtable htC = new Hashtable();
        htC.Add("@AppNo", Request.QueryString["CndNo"].ToString());
        DsC = dataAccessclass.GetDataSetForPrcDBConn("Prc_Get_TblBankDtlsC", htC, "INSCRecruitConnectionString");
        if (DsC.Tables[0].Rows.Count > 0)
        {
            if (DsC.Tables[0].Rows[0]["Bdfor"].ToString().Trim() == "C")
            {
                txtbnkhldname.Text = Convert.ToString(DsC.Tables[0].Rows[0]["AcHolderName"]);
                txtbnkacno.Text = Convert.ToString(DsC.Tables[0].Rows[0]["AccNo"]);
                txtbnkname.Text = DsC.Tables[0].Rows[0]["BankName"].ToString().ToUpper();
                txtbrnchname.Text = Convert.ToString(DsC.Tables[0].Rows[0]["BranchName"]);
                ddlactype.Text = DsC.Tables[0].Rows[0]["ACType"].ToString();
                txtifsccode.Text = Convert.ToString(DsC.Tables[0].Rows[0]["IFSC Code"]);
                txtmicrcode.Text = Convert.ToString(DsC.Tables[0].Rows[0]["MICR Code"]);
            }
        }

        DataSet DsN = new DataSet();
        Hashtable htN = new Hashtable();
        htN.Add("@AppNo", Request.QueryString["CndNo"].ToString());
        DsN = dataAccessclass.GetDataSetForPrcDBConn("Prc_Get_TblBankDtlsN", htN, "INSCRecruitConnectionString");
        if (DsN.Tables[0].Rows.Count > 0)
        {
            if (DsN.Tables[0].Rows[0]["Bdfor"].ToString().Trim() == "N")
            {
                if (DsN.Tables[0].Rows[0]["AcHolderName"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["AcHolderName"].ToString().Trim() != "")
                    {
                        ddlnmbnkhldname.Text = DsN.Tables[0].Rows[0]["AcHolderName"].ToString();
                    }
                }
                else
                {
                    ddlnmbnkhldname.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["AccNo"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["AccNo"].ToString().Trim() != "")
                    {
                        txtnmbnkacno.Text = DsN.Tables[0].Rows[0]["AccNo"].ToString();
                    }
                }
                else
                {
                    txtnmbnkacno.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["BankName"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["BankName"].ToString().Trim() != "")
                    {
                        ddlnmBnkname.Text = DsN.Tables[0].Rows[0]["BankName"].ToString().ToUpper();
                    }
                }
                else
                {
                    ddlnmBnkname.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["ACType"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["ACType"].ToString().Trim() != "")
                    {
                        ddlnmddlactype.Text = DsN.Tables[0].Rows[0]["ACType"].ToString();
                    }
                }
                else
                {
                    ddlnmddlactype.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["BranchName"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["BranchName"].ToString().Trim() != "")
                    {
                        ddlnmBrnchname.Text = DsN.Tables[0].Rows[0]["BranchName"].ToString();
                    }
                }
                else
                {
                    ddlnmBrnchname.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["IFSC Code"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["IFSC Code"].ToString().Trim() != "")
                    {
                        ddlnmifscode.Text = DsN.Tables[0].Rows[0]["IFSC Code"].ToString();
                    }
                }
                else
                {
                    ddlnmifscode.Text = "";
                }
                if (DsN.Tables[0].Rows[0]["MICR Code"] != null)
                {
                    if (DsN.Tables[0].Rows[0]["MICR Code"].ToString().Trim() != "")
                    {
                        txtnmmicr.Text = DsN.Tables[0].Rows[0]["MICR Code"].ToString();
                    }
                }
                else
                {
                    txtnmmicr.Text = "";
                }
            }
        }
    }
    //added by sanoj 22062023
    private void PopulateDispatchDtls()
    {
        try
        {
            // agencyCode = "18A39574";
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@AgentCode", ViewState["AgentBrokerCode"].ToString().Trim());
            ds = dataAccessclass.GetDataSetForPrcRecruits("Prc_GetDispatchDtlsTX", htParam);
            lblRefNoValue.Text = ds.Tables[0].Rows[0]["RefNumber"].ToString().Trim();
            lblRefNameValue.Text = ds.Tables[0].Rows[0]["RefName"].ToString().Trim();
            lblCoverValue.Text = ds.Tables[0].Rows[0]["CoverNote"].ToString().Trim();
            lblDocNoValue.Text = ds.Tables[0].Rows[0]["DocNo"].ToString().Trim();
            lblReqTypeValue.Text = ds.Tables[0].Rows[0]["RequestType"].ToString().Trim();
            lblDocTypeValue.Text = ds.Tables[0].Rows[0]["TypeOfDocumnet"].ToString().Trim();
            lblDispDateValue.Text = ds.Tables[0].Rows[0]["Dispatch_Date"].ToString().Trim();
            lblDispByValue.Text = ds.Tables[0].Rows[0]["DispatchBy"].ToString().Trim();
            lblCourierValue.Text = ds.Tables[0].Rows[0]["CourierAWBno"].ToString().Trim();
            lblDeliveryValue.Text = ds.Tables[0].Rows[0]["DeliveryStatus"].ToString().Trim();
            lblReceivedByValue.Text = ds.Tables[0].Rows[0]["RecievedBy"].ToString().Trim();
            lblRTOValue.Text = ds.Tables[0].Rows[0]["Delivery_RTO"].ToString().Trim();
            lblRTOReasonValue.Text = ds.Tables[0].Rows[0]["RTOReason"].ToString().Trim();
            lblUpdDatevalue.Text = ds.Tables[0].Rows[0]["UpdatedDate"].ToString().Trim();
            lblFileBarCodevalue.Text = ds.Tables[0].Rows[0]["FIleBarCode"].ToString().Trim();
            lblBoxbarCodevalue.Text = ds.Tables[0].Rows[0]["BoxbarCode"].ToString().Trim();
            lblArchivalDtvalue.Text = ds.Tables[0].Rows[0]["ArchivalDate"].ToString().Trim();
            lbldispatchModevalue.Text = ds.Tables[0].Rows[0]["DispatchMode"].ToString().Trim();
            lbldispatchDtvalue.Text = ds.Tables[0].Rows[0]["DispatchDate"].ToString().Trim();
            lblPolicyDispvalue.Text = ds.Tables[0].Rows[0]["PolicyDispatch"].ToString().Trim();
            lblInsAddrvalue.Text = ds.Tables[0].Rows[0]["InsuredAddr"].ToString().Trim();
            lblCourierNamevalue.Text = ds.Tables[0].Rows[0]["CourierName"].ToString().Trim();
            lblremarkvalue.Text = ds.Tables[0].Rows[0]["Remark"].ToString().Trim();
            //  lblInsDtvalue.Text = ds.Tables[0].Rows[0]["InsertDate"].ToString().Trim();

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
    //Endded by sanoj 22062023

    //image 31 july 2023 start

    protected void GetPOSPPANException()
    {
        htParam.Clear();
        dsResult.Clear();
        htParams.Add("@Appno", lblpfappnoDesc.Text);
        dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_Get_POSPPANException", htParams);
        if(dsResult.Tables.Count>0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                infodiv.Visible = true;
            }
            else
            {
                infodiv.Visible = false;
            }
        }
        else
        {
            infodiv.Visible = false;
        }
    }
    //image 31 july 2023 end
}
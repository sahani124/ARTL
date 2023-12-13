using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;
using System.Data;
using System.Collections;
using Insc.Common.Multilingual;
using System.Data.SqlClient;
using CLTMGR;
using System.Text.RegularExpressions;
using INSCL;
using INSCL.DAL;
using System.Text;
using System.Data;
using System.Xml;
//using AadharOTP;
using System.IO;

public partial class Application_ISys_Recruit_AgentProfilling : BaseClass
{

    #region Declare Veriables
    CreateCRMCndTask ObjTask = new CreateCRMCndTask();
    public multilingualManager olng;
    ErrLog objErr = new ErrLog();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    protected CommonFunc oCommon = new CommonFunc();
    private const string c_strBlank = "Select";
    // private DataAccessClass dataAccess = new DataAccessClass();
    DataSet dsResult = new DataSet();
    Hashtable htParam = new Hashtable();
    //AadharService objVal = new AadharService();
    String StrUserdetails = String.Empty;
    String StrOTP = String.Empty;
    String OTP = String.Empty;
    String Aadhar = String.Empty;
    XmlDocument xmlOutPut = new XmlDocument();
    XmlDocument oRequistXML;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");//
            }
            Session["CarrierCode"] = '2';

            hdnUserId.Value = Session["UserID"].ToString().Trim();
            olng = new multilingualManager("DefaultConn", "AgentProfilling.aspx", Session["UserLangNum"].ToString());
            #region "!IsPostBack"
            if (!IsPostBack)
            {
                lblCndNoValue.Text = Request.QueryString["CndNo"].ToString().Trim();
                InitializeControl();
                //PopulateAadharVerifyType();
                subPopulateTitle();//ActualPrsnBusns
                FillAgentProfile(DdlActulPrsnBsns, "ActualPrsnBusns");// ActualPrsnBusns
                DdlActulPrsnBsns.SelectedValue = "C";
                FillAgentProfile(DdlResCity, "AgntTotalYr");// Agent RESIDING  city in year
                FillAgentProfile(DdlOccuption, "AgntOccuption");//Occuption
                FillAgentProfile(DdlMthertong, "AgntMthrTong");//Mother Tongue
                FillAgentProfile(DdlFBUsagesFreq, "AgntFB");//Fb Usages
                FillAgentProfile(DdlothrSocialGrp, "AgntOthrsocialGrp");//Other Social group
                FillAgentProfile(DdlTypeofAgnt, "AgntType");// Agent Type

                FillAgentProfile(DdlWrkExpGI, "AgntTotalYr");//Total GI  
                FillAgentProfile(DdlNameOfGIProduct, "AgntGIProduct");//Name of GI product 
                FillAgentProfile(DdlWrkExpLI, "AgntTotalYr");//Total LI
                FillAgentProfile(DdlWrkExp, "AgntTotalYr"); //Agent Total work Exp in year 

                FillAgentProfile(DdlAnualBusns, "AgntIncm");//Total anual  Income
                //  FillAgentProfile(DdlmtrBusns, "AgntFmlyIncm");//Total Motor  Income
                FillAgentProfile(DdlNosofContact, "AgntNoOfContact");///Total Travel  Income
                //FillAgentProfile(DdltrvlBusns, "AgntIncm"); //Total Travel  Income
                //FillAgentProfile(DdlhealthBusns, "AgntIncm"); //Total health  Income
                FillAgentProfile(DdlAnulFmlyIncom, "AgntIncm");//Total family Income

                //FillAgentProfile(DdlCLBusns, "AgntIncm");//Agent Total CL Business  
                //FillAgentProfile(DdlTotalBusns, "AgntIncm");//Agent Total  Business 
                //FillAgentProfile(DdlAnualBusns, "AgntIncm");  // Anual Busns
                //FillAgentProfile(DdlmtrBusns, "AgntIncm");  //AgntMotorContibton
                subPopulateGender();//Populate gender

                PopulateMaritalStatus();//Marital status
                FillAgentProfile(ddlBasicQual, "AgntEduQual");  //Education
                FillAgentProfile(ddlProfQual, "AgntProfsnlQual");  //professional qualification
                FillAgentProfile(DdlInsQual, "AgntInslQual");  //Insurance  qualification

                FillAgentProfile(DdlSocialGrp, "AgntsocialGrp");//Agent Social Group
                FillAgentProfile(ListFinanceServiceName, "AgntFinanceSvrce");
                GetCandidateDtls();
                GetComapnynNameIfYes();
            }
            //  btnSave.Attributes.Add("onClick", "javascript: return funValidate();");
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);

            #endregion
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

    #region METHOD "InitializeControl()"
    private void InitializeControl()
    {
        try
        {
            lblAppNo.Text = olng.GetItemDesc("lblAppNo");
            lblCndNo.Text = olng.GetItemDesc("lblCndNo");//LblActulPrsnBusns
            //LblActulPrsnBusns.Text = olng.GetItemDesc("LblActulPrsnBusns");
            LblActulPrsnBusns.Text = "Profile Name";
            LblMtrName.Text = olng.GetItemDesc("LblMtrName");
            LblMtrAadharNo.Text = olng.GetItemDesc("LblMtrAadharNo");
            LblAadharVerfy.Text = olng.GetItemDesc("LblAadharVerfy");
            LblAadharOTP.Text = olng.GetItemDesc("LblAadharOTP");
            LblResCity.Text = "Residing in current city since [years] ";
            LblGender.Text = olng.GetItemDesc("LblGender");
            LblDOB.Text = olng.GetItemDesc("LblDOB");
            LblMobile.Text = olng.GetItemDesc("LblMobile");
            LblWhatsaap.Text = olng.GetItemDesc("LblWhatsaap");
            Lblpfhometel.Text = olng.GetItemDesc("Lblpfhometel");
            LblLandline.Text = olng.GetItemDesc("LblLandline");
            LblEmail.Text = olng.GetItemDesc("LblEmail");
            Lblmaritalstatus.Text = "Marital Status";
            LblAniversaryDt.Text = olng.GetItemDesc("LblAniversaryDt");
            LblNosOfDependent.Text = olng.GetItemDesc("LblNosOfDependent");
            LblSpouseName.Text = olng.GetItemDesc("LblSpouseName");
            LblSpouseDOB.Text = olng.GetItemDesc("LblSpouseDOB");
            LblSpouseWrking.Text = olng.GetItemDesc("LblSpouseWrking");
            LblOrgname.Text = olng.GetItemDesc("LblOrgname");
            LblchildName1.Text = olng.GetItemDesc("LblchildName1");
            LblchildDob.Text = olng.GetItemDesc("LblchildDob");
            LblchildName2.Text = olng.GetItemDesc("LblchildName2");
            Lblchild2Dob.Text = olng.GetItemDesc("Lblchild2Dob");
            LblBasicQual.Text = olng.GetItemDesc("LblBasicQual");
            LblProfQual.Text = olng.GetItemDesc("LblProfQual");
            LblInsQual.Text = olng.GetItemDesc("LblInsQual");
            LblOccuption.Text = olng.GetItemDesc("LblOccuption");
            LblSocialGrp.Text = olng.GetItemDesc("LblSocialGrp");
            LblFBUsagesFreq.Text = olng.GetItemDesc("LblFBUsagesFreq");
            LblothrSocialGrp.Text = olng.GetItemDesc("LblothrSocialGrp");
            //LblOtherinsAsso.Text = olng.GetItemDesc("LblOtherinsAsso");commented by ajay for label rename
            LblOtherinsAsso.Text = "Is (S)he associated with any industry other than insurance";
            LblNameOtherinsAsso.Text = olng.GetItemDesc("LblNameOtherinsAsso");
            //Lblfourwhler.Text = olng.GetItemDesc("Lblfourwhler");commented by ajay for label rename
            Lblfourwhler.Text = "Has 4 wheeler";

            LblfourwhlerMake.Text = olng.GetItemDesc("LblfourwhlerMake");
            Lblfourwhlermodel.Text = olng.GetItemDesc("Lblfourwhlermodel");
            LblTwowhler.Text = olng.GetItemDesc("LblTwowhler");

            LblOwnhouse.Text = olng.GetItemDesc("LblOwnhouse");
            //LblcridtCard.Text = olng.GetItemDesc("LblcridtCard");commented by ajay for label rename
            LblcridtCard.Text = "Is (S)he having Credit Card of any Bank";
            LblNosofConcate.Text = olng.GetItemDesc("LblNosofConcate");
            LblVeg.Text = olng.GetItemDesc("LblVeg");
            Lblpassport.Text = olng.GetItemDesc("Lblpassport");
            Lblhobby.Text = olng.GetItemDesc("Lblhobby");
            LblMthertong.Text = "Mother Tongue";
            LblTypeofAgnt.Text = olng.GetItemDesc("LblTypeofAgnt");
            LblWrkExp.Text = "Total Work Experience (In Years)";
            LblWrkExpGI.Text = olng.GetItemDesc("LblWrkExpGI");
            LblNameOfWrkExpGI.Text = olng.GetItemDesc("LblNameOfWrkExpGI");
            LblWrkExpLI.Text = olng.GetItemDesc("LblWrkExpLI");
            //LblFinanceService.Text = olng.GetItemDesc("LblFinanceService");commented by ajay for label rename
            LblFinanceService.Text = "Is (S)he deal in other  financial Service";
            LblFinanceServiceName.Text = olng.GetItemDesc("LblFinanceServiceName");
            LblOthrRcl.Text = olng.GetItemDesc("LblOthrRcl");
            LblOthrRclName.Text = "Name of other Insurance Company";
            Lblproimaryincom.Text = olng.GetItemDesc("Lblproimaryincom");
            LblAnulFmlyIncom.Text = olng.GetItemDesc("LblAnulFmlyIncom");
            LblAnualBusns.Text = olng.GetItemDesc("LblAnualBusns");
            LblmtrBusns.Text = "Motor Contribution (In %)";
            LbltrvlBusns.Text = "Travel Contribution (In %) ";
            LblhealthBusns.Text = "Health Contribution (In %) ";
            LblCLBusns.Text = "CL Contribution (In %)";
            LblTotalBusns.Text = olng.GetItemDesc("LblTotalBusns");
            LblOthrGI.Text = olng.GetItemDesc("LblOthrGI");
            LblStaldaloneGI.Text = "Name of Company associated with (Name of all GI companies in existence including standalone General Cos)) ";
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

    private void FillAgentProfile(DropDownList DropDownname, String AgnTypCode)
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();
            htparam.Clear();
            htparam.Add("@AgnTypCode", AgnTypCode.ToString());
            dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAgentMasterValue", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                DropDownname.DataSource = dsResult;
                DropDownname.DataTextField = "AgntDesc01";
                DropDownname.DataValueField = "value";
                DropDownname.DataBind();
                DropDownname.Items.Insert(0, "Select");
                //DropDownname.Items.Add(new ListItem("Select", "0", true));
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Branch not available on master')", true);
            return;
        }




    }
    private void subPopulateGender()
    {
        try
        {
            oCommon.getDropDown(DdlGender, "NBGender", 1, "", 1, c_strBlank);
            DdlGender.Items.Remove(DdlGender.Items.FindByValue("C"));
            DdlGender.Items.Remove(DdlGender.Items.FindByValue("U"));

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

    private void PopulateMaritalStatus()
    {
        try
        {
            oCommon.getDropDown(cboMaritalStatus, "MarrySts", 1, "", 1);
            cboMaritalStatus.Items.Insert(0, "Select");
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







    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int DdlmtrBusn = Convert.ToInt32(DdlmtrBusns.Text);
        int DdltrvlBusn = Convert.ToInt32(DdltrvlBusns.Text);
        int DdlhealthBusn = Convert.ToInt32(DdlhealthBusns.Text);
        int DdlCLBusn = Convert.ToInt32(DdlCLBusns.Text);
        int sum = DdlmtrBusn + DdltrvlBusn + DdlhealthBusn + DdlCLBusn;

        DdlTotalBusns.Text = sum.ToString();

        if (DdlTotalBusns.Text.ToString() != "100")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Total Contribution-Valiadation-Total should be 100%')", true);
            ProgressBarModalPopupExtender.Hide();

            return;

        }
        htParam.Clear();

        //htParam.Add("@DateAppoinment", TxtDOB.Text);

        //   dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_NOCAppointmentDateVal", htParam);

        //   if (TxtDOB.Text != "")
        //   {

        //       if (dsResult != null)
        //       {
        //           if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
        //           {
        //               string strIsValid = dsResult.Tables[0].Rows[0]["Flag"].ToString().Trim();

        //               if (strIsValid == "Invalid")
        //               {
        //                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot select future date in Date Of birth')", true);
        //                   return;
        //               }
        //           }
        //       }
        //   }
        btnSave.Attributes.Add("onClick", "javascript: return funValidate();");
        try
        {
            if (ConfirmOtherinsAsso.SelectedValue == "Y")
            {
                if (TxtNameOtherinsAsso.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter name of other associated industry')", true);
                    ProgressBarModalPopupExtender.Hide();
                    TxtNameOtherinsAsso.Focus();

                    return;

                }
            }

            if (ConfirmOthrRcl.SelectedValue == "Y")
            {

                if (ddlcompName.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select name of other reliance capital company')", true);
                    ProgressBarModalPopupExtender.Hide();
                    ConfirmOthrRcl.Focus();
                    return;

                }
            }

            if (ConfirmSpouseWrking.SelectedValue == "Y")
            {
                if (TxtSpouseOrgname.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter spouse name of organization')", true);
                    ProgressBarModalPopupExtender.Hide();
                    TxtSpouseOrgname.Focus();
                    return;

                }
            }


            if (Confirmfourwhler.SelectedValue == "Y")
            {
                if (TxtfourwhlerMake.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter make of 4 wheeler')", true);
                    ProgressBarModalPopupExtender.Hide();
                    TxtfourwhlerMake.Focus();

                    return;

                }
                if (Txtfourwhlermodel.Text == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter model of 4 wheeler')", true);
                    ProgressBarModalPopupExtender.Hide();
                    TxtNameOtherinsAsso.Focus();

                    return;

                }

            }
            if (ConfirmFinanceService.SelectedValue == "Y")
            {
                if (ListFinanceServiceName.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select name of other reliance  financial service')", true);
                    ProgressBarModalPopupExtender.Hide();
                    ConfirmOthrRcl.Focus();
                    return;

                }

            }
            if (ConfirmOthrGI.SelectedValue == "Y")
            {
                if (TxtStaldaloneGI.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select name of company associated with (nmae of all GI companies in existence including standalone health Cos))')", true);
                    ProgressBarModalPopupExtender.Hide();
                    ConfirmOthrRcl.Focus();
                    return;

                }

            }


            dsResult.Clear();
            htParam.Clear();

            htParam.Add("@CarrierCode", "2");
            htParam.Add("@AppNo", lblAppNoValue.Text);
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
            htParam.Add("@ActualPrsnBusns", DdlActulPrsnBsns.SelectedValue.ToString());
            htParam.Add("@Title", cboTitle.SelectedValue.ToString());
            htParam.Add("@Name", TxtMtrName.Text.Trim());
            htParam.Add("@AadharNo", TxtMtrAadharNo.Text.Trim());
            htParam.Add("@CityYr", DdlResCity.SelectedValue.Trim());
            htParam.Add("@Gender ", DdlGender.SelectedValue.Trim());
            htParam.Add("@BirthRegDate ", DateTime.Parse(TxtDOB.Text.Trim()).ToString("yyyyMMdd"));
            htParam.Add("@MaritalStatus", cboMaritalStatus.SelectedValue.Trim());

            if (TxtAniversaryDt.Text.Trim() != "")
            {
                htParam.Add("@MarriageDate", DateTime.Parse(TxtAniversaryDt.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@MarriageDate ", System.DBNull.Value);
            }

            htParam.Add("@NosOfDepend", DdlNosOfDependent.SelectedValue.Trim());

            if (TxtSpouseName.Text.Trim() != "")
            {

                htParam.Add("@Spousename", TxtSpouseName.Text.Trim());
            }
            else
            {
                htParam.Add("@Spousename ", System.DBNull.Value);
            }

            if (TxtSpouseDOB.Text.Trim() != "")
            {
                htParam.Add("@SpouseDOB", DateTime.Parse(TxtSpouseDOB.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@SpouseDOB ", System.DBNull.Value);
            }

            htParam.Add("@SpouseWrkng", ConfirmSpouseWrking.SelectedValue);
            htParam.Add("@SpouseWrkngOrgName", TxtSpouseOrgname.Text.Trim());

            htParam.Add("@child1Name", TxtchildName1.Text.Trim());
            if (Txtchild1Dob.Text.Trim() != "")
            {
                htParam.Add("@child1DOB", DateTime.Parse(Txtchild1Dob.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@child1DOB ", System.DBNull.Value);
            }

            htParam.Add("@child2Name", TxtchildName2.Text.Trim());
            if (Txtchild2Dob.Text.Trim() != "")
            {
                htParam.Add("@child2DOB", DateTime.Parse(Txtchild2Dob.Text.Trim()).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@child2DOB ", System.DBNull.Value);
            }

            htParam.Add("@Occupation", DdlOccuption.SelectedValue.Trim());
            htParam.Add("@SocialGrpName", DdlSocialGrp.SelectedValue.Trim());
            htParam.Add("@FBUsages", DdlFBUsagesFreq.SelectedValue.Trim());
            htParam.Add("@OtherSocialGrpName", DdlothrSocialGrp.SelectedValue.Trim());
            htParam.Add("@AssociatIndustry", ConfirmOtherinsAsso.SelectedValue);
            htParam.Add("@NameAssociatIndustry", TxtNameOtherinsAsso.Text.Trim());
            htParam.Add("@FourWheeler ", Confirmfourwhler.SelectedValue);
            htParam.Add("@MakeFourWheeler", TxtfourwhlerMake.Text.Trim());
            htParam.Add("@ModelFourWheeler", Txtfourwhlermodel.Text.Trim());
            htParam.Add("@TwoWheeler", ConfirmTwowhler.SelectedValue);
            htParam.Add("@OwnHouse ", ConfirmOwnhouse.SelectedValue);
            htParam.Add("@CreditCard", ConfirmCridtCard.SelectedValue);
            htParam.Add("@VegNonveg", TxtConfirmFood.Text.Trim());
            htParam.Add("@PassportNo", Txtpassport.Text.Trim());
            htParam.Add("@Hobby", Txthobby.Text.Trim());
            htParam.Add("@Mothertoung ", DdlMthertong.SelectedValue.Trim());
            htParam.Add("@AgntType", DdlTypeofAgnt.SelectedValue.Trim());
            htParam.Add("@TotlWorkExp", DdlWrkExp.SelectedValue.Trim());
            htParam.Add("@TotlWorkExpGI", DdlWrkExpGI.SelectedValue.Trim());
            htParam.Add("@NameGIProduct", DdlNameOfGIProduct.SelectedValue.Trim());
            htParam.Add("@TotlWorkExpLI", DdlWrkExpLI.SelectedValue.Trim());
            htParam.Add("@IsDealOthfinServcs", ConfirmFinanceService.SelectedValue);

            if (ListFinanceServiceName.SelectedValue != "Select")
            {

                htParam.Add("@NameOthfinServcs", ListFinanceServiceName.SelectedValue.Trim());
            }
            else
            {
                htParam.Add("@NameOthfinServcs ", System.DBNull.Value);
            }

            htParam.Add("@IsDealRCLCmpny", ConfirmOthrGI.SelectedValue);

            if (DdlInsQual.SelectedValue != "Select")
            {

                htParam.Add("@NameRCLCmpny", ddlcompName.SelectedValue.Trim());
            }
            else
            {
                htParam.Add("@NameRCLCmpny ", System.DBNull.Value);
            }

            htParam.Add("@IsInsPrimarySource", Confirmproimaryincom.SelectedValue);
            htParam.Add("@AnualFmlyIncm", DdlAnulFmlyIncom.SelectedValue.Trim());
            htParam.Add("@AnualBusnsIncm", DdlAnualBusns.SelectedValue.Trim());
            htParam.Add("@MotorContrbuton", DdlmtrBusns.Text.Trim());
            htParam.Add("@TravelContrbuton", DdltrvlBusns.Text.Trim());
            htParam.Add("@HealthContrbuton", DdlhealthBusns.Text.Trim());
            htParam.Add("@CLContrbuton", DdlCLBusns.Text.Trim());
            htParam.Add("@TotalContrbuton", DdlTotalBusns.Text.Trim());
            htParam.Add("@MobileNo ", TxtMobile.Text.Trim());
            htParam.Add("@AlterMobileNo", TxtWhatsaap.Text.Trim());
            htParam.Add("@STDMobile2", TxtSTD.Text.Trim());
            htParam.Add("@HomeTel", TextLandline.Text.Trim());
            htParam.Add("@Email ", TxtEmail.Text.Trim());
            htParam.Add("@NosOfCnct", DdlNosofContact.SelectedValue);
            htParam.Add("@EduQual", ddlBasicQual.SelectedValue);
            htParam.Add("@ProfQual", ddlProfQual.SelectedValue);


            if (DdlInsQual.SelectedValue != "Select")
            {
                htParam.Add("@InsQual", DdlInsQual.SelectedValue);
            }
            else
            {
                htParam.Add("@InsQual ", System.DBNull.Value);
            }
            htParam.Add("@CreateBy", hdnUserId.Value);
            int x = 0;
            x = dataAccessRecruit.execute_sprcrecruit("prc_InsAgentProfile", htParam);
            //commented by ashiotsh

            Label3.Text = "Agent Profile data save successfully <br/>" + "Candidate No: " + lblCndNoValue.Text + "<br/>Application No: " + lblAppNoValue.Text + "<br/>Agent Name: " + TxtMtrName.Text;

            //commented by ashiotsh end
            // mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true); //by meena
            ProgressBarModalPopupExtender.Hide();
            btnSave.Enabled = false;
            ObjTask.UpdateCndTask(lblAppNoValue.Text);//To create task in CRM  in 18.12.2017

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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/ISys/Recruit/CndEnq.aspx?Type=AgentProfile");


    }

    private void GetCandidateDtls()
    {
        Hashtable htDtls = new Hashtable();
        DataSet dsDtls = new DataSet();
        htDtls.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        dsDtls = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetAgentDetails", htDtls);

        ViewState["CandType"] = dsDtls.Tables[0].Rows[0]["Cand_Type"].ToString();
        ViewState["ProcessType"] = dsDtls.Tables[0].Rows[0]["ProcessType"].ToString();
        ViewState["CandStatus"] = dsDtls.Tables[0].Rows[0]["CndStatus"].ToString();
        ViewState["IsPriorAgt"] = dsDtls.Tables[0].Rows[0]["IsPriorAgt"].ToString();
        lblAppNoValue.Text = dsDtls.Tables[0].Rows[0]["AppNo"].ToString();
        TxtMtrAadharNo.Text = dsDtls.Tables[0].Rows[0]["AadharNo"].ToString();
        TxtCndName.Text = dsDtls.Tables[0].Rows[0]["GivenName"].ToString();
        cboMaritalStatus.SelectedValue = dsDtls.Tables[0].Rows[0]["MaritalStat"].ToString();
        //Commented by ashitosh for adhar 

        //if (dsDtls.Tables[0].Rows[0]["TypeofAadharVerify"].ToString() != "")
        //{

        //    DdlAadharVerfy.SelectedItem.Text = dsDtls.Tables[0].Rows[0]["TypeofAadharVerify"].ToString();//
        //}

        //if (DdlAadharVerfy.SelectedValue == "Select")
        //{

        //    ConfirmAadhar.Visible = true;
        //    AadharVerify.Visible = true;
        //}
        //else
        //{
        //    AadharVerify.Visible = false;
        //    ConfirmAadhar.Visible = false;


        //}

        //Commented by ashitosh for adhar end

        if (DdlActulPrsnBsns.SelectedValue == "C")
        {
            cboTitle.Text = dsDtls.Tables[0].Rows[0]["Title"].ToString();
            TxtMtrName.Text = dsDtls.Tables[0].Rows[0]["GivenName"].ToString();
            TxtMtrAadharNo.Text = dsDtls.Tables[0].Rows[0]["AadharNo"].ToString();
            TxtDOB.Text = DateTime.Parse(Convert.ToString(dsDtls.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
            DdlGender.SelectedValue = Convert.ToString(dsDtls.Tables[0].Rows[0]["Gender"]);
            TxtMobile.Text = dsDtls.Tables[0].Rows[0]["MobileTel"].ToString();
            TxtEmail.Text = dsDtls.Tables[0].Rows[0]["Email"].ToString();
            cboMaritalStatus.SelectedValue = dsDtls.Tables[0].Rows[0]["MaritalStat"].ToString();
        }

    }

    private void subPopulateTitle()
    {
        try
        {
            //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language start			

            cboTitle.Items.Clear();
            dscbotitle.SelectCommand = "Prc_GetCndTitle";
            // cboTitle.DataSource = dscbotitle;

            //Added By Prathamesh 22-6-15
            cboTitle.DataTextField = "ParamDesc";
            cboTitle.DataValueField = "ParamValue";
            cboTitle.DataBind();
            //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language End		

            cboTitle.Items.Insert(0, new ListItem("--", ""));
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
    //protected void ConfirmAadharVerification_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ConfirmAadhar.SelectedValue == "Y")
    //    {

    //        LblAadharVerfy.Visible = true;
    //        DdlAadharVerfy.Visible = true;
    //    }
    //    else
    //    {
    //        LblAadharVerfy.Visible = false;
    //        DdlAadharVerfy.Visible = false;
    //        //PopulateAadharVerifyType();
    //        UpdateOTP.Visible = false;
    //        LblAadharOTP.Visible = false;
    //    }


    //}
    #region Commented by ashitosh because of adhar
    //protected void DDlAadharVerfy_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DdlAadharVerfy.SelectedValue == "OTP")
    //    {
    //        LblAadharOTP.Visible = true;
    //        UpdateOTP.Visible = true;
    //        Aadhar = TxtMtrAadharNo.Text.Trim();


    //        if (TxtMtrAadharNo.Text.Trim() == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter aadhaar number')", true);
    //            return;
    //        }
    //        else
    //        {
    //            //  string output = objVal.OTP("866863744854");
    //            StrOTP = objVal.OTP(Aadhar);   //Note  To Call Aadhar OTP Service OF Relianc

    //            if (StrOTP != "Success")
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' " + StrOTP + " ')", true);
    //                return;

    //            }
    //        }
    //    }

    //    else
    //    {

    //        LblAadharOTP.Visible = false;
    //        UpdateOTP.Visible = false;
    //    }
    //}
    //protected void btnVerifyOTP_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        Aadhar = TxtMtrAadharNo.Text.Trim();
    //        OTP = TxtAadharOTP.Text.Trim();
    //        if (OTP == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter OTP')", true);
    //            return;

    //        }
    //        // StrUserdetails = objVal.GetCustomerDetails("646140", "866863744854");
    //        StrUserdetails = objVal.GetCustomerDetails(OTP, Aadhar);   //Note  To Get  Customer Details   Service

    //        oRequistXML = CreateRequestMsg(StrUserdetails);
    //        String output = oRequistXML.InnerXml;

    //        // String output = "<Aadhar><AADHAAR_NO>933486124967</AADHAAR_NO><ADDRESSLINE_1>S/O Mahadeo Chakole,Near Wanjari Kirana Stores</ADDRESSLINE_1><ADDRESSLINE_2>Shastri Waard,</ADDRESSLINE_2><ADDRESSLINE_3>P.O: Bhandara</ADDRESSLINE_3><FULL_NAME>Rupesh Mahadeo Chakole</FULL_NAME><SALUTE>Mr</SALUTE><FIRST_NAME>Rupesh</FIRST_NAME><MIDDLE_NAME>Mahadeo</MIDDLE_NAME><LAST_NAME>Chakole</LAST_NAME><DOB>29-09-1990</DOB><PHONE>9890861721</PHONE><GENDER>M</GENDER><EMAIL>rupeshchakole5@gmail.com</EMAIL><STATE>Maharashtra</STATE><DISTRICT>Bhandara</DISTRICT><CITY>Ganeshpur</CITY><PINCODE>441904</PINCODE><MOM_CITYCODE>227513</MOM_CITYCODE><MOM_CITYNAME>BHANDARA</MOM_CITYNAME><MOM_DISTRICTCODE>309</MOM_DISTRICTCODE><MOM_DISTRICTNAME>BHANDARA</MOM_DISTRICTNAME><MOM_STATECODE>21</MOM_STATECODE><MOM_STATENAME>MAHARASHTRA</MOM_STATENAME><AADHAAR_NO_TXN_ID>UKC:853264</AADHAAR_NO_TXN_ID><STATUS>Success</STATUS><CODE></CODE><ERROR_DESCR></ERROR_DESCR></Aadhar>";
    //        DataSet dsIns = new DataSet();
    //        Hashtable ht = new Hashtable();

    //        dsIns = ConvertXMLToDataSet(output);
    //        Session["ds"] = dsIns;
    //        DataSet DS = new DataSet();
    //        DS = (DataSet)Session["ds"];
    //        if (dsIns.Tables[0].Rows[0]["STATUS"].ToString() == "Success")
    //        {

    //            TxtMtrName.Text = (DS.Tables[0].Rows[0]["FIRST_NAME"].ToString() + " " + DS.Tables[0].Rows[0]["MIDDLE_NAME"].ToString());
    //            TxtDOB.Text = DateTime.Parse(Convert.ToString(DS.Tables[0].Rows[0]["DOB"])).ToString(CommonUtility.DATE_FORMAT);//dsIns.Tables[0].Rows[0]["DOB"].ToString();
    //            TxtEmail.Text = DS.Tables[0].Rows[0]["EMAIL"].ToString();
    //            TxtMobile.Text = DS.Tables[0].Rows[0]["PHONE"].ToString();


    //            DdlGender.SelectedValue = Convert.ToString(DS.Tables[0].Rows[0]["GENDER"]);
    //            LblAaharotp.Visible = true;
    //            BtnOTP.Enabled = false;


    //        }
    //        else
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' " + DS.Tables[0].Rows[0]["ERROR_DESCR"].ToString() + " ')", true);
    //            return;
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

    //private void PopulateAadharVerifyType()
    //{
    //    try
    //    {
    //        DataSet dsResult = new DataSet();
    //        Hashtable htparam = new Hashtable();
    //        htparam.Clear();
    //        htparam.Add("@flag", 1);

    //        dsResult = dataAccessRecruit.GetDataSetForPrcRecruits("Prc_GetAadharVerifyValue", htparam);

    //        if (dsResult.Tables[0].Rows.Count > 0)
    //        {
    //            DdlAadharVerfy.DataSource = dsResult;
    //            DdlAadharVerfy.DataTextField = "ParamDesc01";
    //            DdlAadharVerfy.DataValueField = "ParamValue";
    //            DdlAadharVerfy.DataBind();
    //            DdlAadharVerfy.Items.Insert(0, "Select");
    //            // DdlAadharVerfy.Items.Remove(dsResult.Tables[0].Rows[0].[""]);
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
    //        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Branch not available on master')", true);
    //        return;
    //    }




    //}
    #endregion
    public DataSet ConvertXMLToDataSet(string xmlData)
    {
        StringReader stream = null;
        XmlTextReader reader = null;
        try
        {
            DataSet xmlDS = new DataSet();
            stream = new StringReader(xmlData);
            // Load the XmlTextReader from the stream
            reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);
            return xmlDS;
        }
        catch
        {
            return null;
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }
    #region Final Request XML

    private XmlDocument CreateRequestMsg(string StrUserdetails)
    {
        XmlDocument reqXML = new XmlDocument();
        StringBuilder sbrRequest = new StringBuilder();

        sbrRequest.AppendLine("<?xml version=\"1.0\" encoding=\"UTF\"?>");
        sbrRequest.AppendLine("<AadharData>");

        sbrRequest.AppendLine(StrUserdetails);
        sbrRequest.AppendLine("</AadharData>");

        reqXML.LoadXml(sbrRequest.ToString());


        reqXML.LoadXml(sbrRequest.ToString());

        return reqXML;
    }


    #endregion
    protected void DdlActulPrsnBsns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlActulPrsnBsns.SelectedValue == "C")
        {

            GetCandidateDtls();
        }
        else
        {
            cboTitle.SelectedIndex = 0;
            TxtMtrName.Text = "";
            DdlGender.SelectedIndex = 0;
            TxtDOB.Text = "";
            TxtMobile.Text = "";
            TxtEmail.Text = "";


        }

    }
    protected void GetComapnynNameIfYes()
    {
        oCommon.getDropDown(ddlcompName, "CompyName", 1, "", 1);
        ddlcompName.Items.Insert(0, "Select");


    }

    protected void ConfirmOthrRcl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConfirmOthrRcl.SelectedValue == "Y")
        {

            ddlcompName.Enabled = true;

        }
        else
        {
            ddlcompName.Enabled = false;
        }


    }

    protected void ConfirmSpouseWrking_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConfirmSpouseWrking.SelectedValue == "Y")
        {
            TxtSpouseOrgname.Enabled = true;

        }
        else
        {
            TxtSpouseOrgname.Enabled = false;
        }


    }
    protected void ddlBasicQual_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Confirmfourwhler_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Confirmfourwhler.SelectedValue == "Y")
        {
            TxtfourwhlerMake.Enabled = true;
            Txtfourwhlermodel.Enabled = true;
        }
        else
        {
            TxtfourwhlerMake.Enabled = false;
            Txtfourwhlermodel.Enabled = false;
        }



    }

    protected void ConfirmOtherinsAsso_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConfirmOtherinsAsso.SelectedValue == "Y")
        {
            TxtNameOtherinsAsso.Enabled = true;
        }
        else
        {
            TxtNameOtherinsAsso.Enabled = false;
        }


    }


    protected void cboMaritalStatus_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboMaritalStatus.SelectedValue == "S")
        {
            TxtAniversaryDt.Enabled = false;
            TxtSpouseDOB.Enabled = false;
            TxtSpouseName.Enabled = false;
            ConfirmSpouseWrking.Enabled = false;

            TxtchildName1.Enabled = false;
            TxtchildName2.Enabled = false;
            Txtchild1Dob.Enabled = false;
            Txtchild2Dob.Enabled = false;


        }
        else
        {
            TxtAniversaryDt.Enabled = true;
            TxtSpouseDOB.Enabled = true;
            TxtSpouseName.Enabled = true;
            ConfirmSpouseWrking.Enabled = true;

            TxtchildName1.Enabled = true;
            TxtchildName2.Enabled = true;
            Txtchild1Dob.Enabled = true;
            Txtchild2Dob.Enabled = true;


        }

    }
}
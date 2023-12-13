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

public partial class Application_INSC_Recruit_CndLicDetails : BaseClass
{

    #region Declare Variables
    string sConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["INSCCommonConnectionString"].ToString();
    string inscdireconn = System.Configuration.ConfigurationManager.ConnectionStrings["INSCDirectConnectionString"].ToString();
    private Provider oDP = new Insc.Common.Data.Provider();

    const string cSessionQryState = "ClientDetail";
    protected CommonFunc oCommon = new CommonFunc();

    public const string CONN_Recruit = "INSCRecruitConnectionString";
    public const string CONN_INSCCOMMON = "INSCCommonConnectionString";

    Insc.MQ.Common.Client.MQClientMgr oMQCltMgr = new Insc.MQ.Common.Client.MQClientMgr();
    public multilingualManager olng;

    private const string c_strLogPath = "/Log";
    private const string c_strBlank = "-- Select --";
    Hashtable htParam = new Hashtable();
    Hashtable httable = new Hashtable();//Added by Asrar
    // private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessclass = new DataAccessClass();
    private clsCndReg clsCndReg = new clsCndReg();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    bool IsFoundRefBy = false;
    string strpanno = "";
    DataSet dsResult1 = new DataSet();
    DataSet dsResult = new DataSet();
    string strAgentType = string.Empty;
    bool IsFound = false;
    ErrLog objErr = new ErrLog();
    //07...26092012...Miti
    //public PANValidation objpan = new PANValidation();


    SqlDataReader drResult;
    string strProspectID = string.Empty;//Added by rachana on 25-11-2013 to save candidate id from QS to string
    DataSet dsPanResult = new DataSet();

    #endregion

    #region IntializeControl
    private void InitializeControl()
    {
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

        lblpfmaritalstatus.Text = olng.GetItemDesc("lblpfmaritalstatus");
        lblpfNationality.Text = olng.GetItemDesc("lblpfNationality");
        lblpfpan.Text = olng.GetItemDesc("lblpfpan");
        //lblpfcompaymode.Text = olng.GetItemDesc("lblpfcompaymode");//Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field

        lblpfrecinfotitle.Text = olng.GetItemDesc("lblpfrecinfotitle");
        lblpfsalchannel.Text = olng.GetItemDesc("lblpfsalchannel");
        lblpfchasubclass.Text = olng.GetItemDesc("lblpfchasubclass");
        lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
        //lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
        //lblpfsmname.Text = olng.GetItemDesc("lblpfsmname");
        lblpfbesmcode.Text = olng.GetItemDesc("lblpfbesmcode");
        lblpfrecagent.Text = olng.GetItemDesc("lblpfrecagent");
        lblpfrecagtname.Text = olng.GetItemDesc("lblpfrecagtname");

        btnUpdate.Text = olng.GetItemDesc("btnUpdate");
        btnCancel.Text = olng.GetItemDesc("btnCancel");

    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }
        //strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();

        olng = new multilingualManager("DefaultConn", "CndReg.aspx", Session["UserLangNum"].ToString());
        Session["CarrierCode"] = '2';
        SqlDataReader dtRead;
        btnUpdate.Attributes.Add("onClick", "javascript: return funValidate();");
        if (!IsPostBack)
        {
            InitializeControl();
            subPopulateTitle();
            subPopulateGender();
            PopulateMaritalStatus();
            PopulateCategory();
            PopulateCasteCat();
            txtNationalDesc.Text = "INDIA";
            GetRecruitSalesChannel(ddlSlsChannel, "", 0);
            PopulateRecruiterCode();
            //ddlcategory.SelectedIndex = 1;
            //PopulateProofIDDoc();       //Added by : Mahen,on 30th jan 09

            //PopulateAgentTypes();
           
            //PopulateExamMode();
            
            //PopulateBasicQual();
            //CnctType(true);
            
            //Added by kalyani on 30-12-2013 to remove user control start 
            
            //PopulatePrimProof();
            //PopulateContactPreferred();
            //PopulateQualCode();
            //PopulateChecbox();

            if (Request.QueryString["licflag"] == "LIC" && Request.QueryString["Type"] == "E" && Request.QueryString["CndNo"] != null)
            {
                FillRequiredDataForCndPersonal();
            }
        }
    }
    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnVerifyPAN_Click(object sender, EventArgs e)
    {

    }
    protected void RbtNoc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnVerifyCSC_Click(object sender, EventArgs e)
    {

    }
    protected void btnVerifyRefEmpBy_Click(object sender, EventArgs e)
    {

    }
    protected void btnVerifyRefBy_Click(object sender, EventArgs e)
    {

    }
    private void subPopulateTitle()
    {

        //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language start			

        cboTitle.Items.Clear();
        dscbotitle.SelectCommand = "Prc_GetCndTitle";
        cboTitle.DataBind();
        //Added By Asrar on 28-06-2013 for converting Inline query into procedure Exam Language End		

        cboTitle.Items.Insert(0, new ListItem("--", ""));
    }
    private void subPopulateGender()
    {
        oCommon.getDropDown(cboGender, "NBGender", 1, "", 1, c_strBlank);
        cboGender.Items.Remove(cboGender.Items.FindByValue("C"));
        cboGender.Items.Remove(cboGender.Items.FindByValue("U"));
        subGenerateGenderValidation();
    }
   
    private void subGenerateGenderValidation()
    {
        DataTable dtGenderTitle = oDP.ReadData("INSCDirectConnectionString", "prc_GenderTitle_sel").Tables[0];

        foreach (DataRow row in dtGenderTitle.Rows)
        {
            hdnGenderTitle1.Value += row[0].ToString() + ",";
            hdnGenderTitle2.Value += row[1].ToString() + ",";
        }

        hdnGenderTitle1.Value = hdnGenderTitle1.Value.Trim(',');
        hdnGenderTitle2.Value = hdnGenderTitle2.Value.Trim(',');
    }

    private void PopulateCategory()
    {

        oCommon.getDropDown(ddlcategory, "CndCat", 1, "", 1);
        ddlcategory.Items.Insert(0, "--Select--");
    }
    private void PopulateMaritalStatus()
    {
        oCommon.getDropDown(cboMaritalStatus, "MarrySts", 1, "", 1);
        cboMaritalStatus.Items.Insert(0, "--Select--");
    }

    private void PopulatePrimProof()
    {
        oCommon.getDropDown(ddlPrimProf, "PrimProof", 1, "", 1);
        ddlPrimProf.Items.Insert(0, "--Select--");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dsResult.Clear();
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            string status = "150";
            htParam.Add("@CndNo", txtcndid.Text);
            htParam.Add("@flag", Request.QueryString["licflag"].ToUpper().ToString().Trim());
            if (Request.QueryString["licflag"].ToUpper().ToString().Trim() == "LIC")
            {
                htParam.Add("@LicenseNo", txtOldTccLcnNo.Text);
                if (txtDate.Text.Trim() != "")
                {
                    htParam.Add("@LicenseExpDate", DateTime.Parse(txtDate.Text).ToString("yyyyMMdd"));
                }
                else
                {
                    htParam.Add("@LicenseExpDate", System.DBNull.Value);
                }
                htParam.Add("@CndStatus", status.ToString().Trim());
            }

            dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_UpdateLicDtlsForCand", htParam);
            htParam.Clear();
            dsResult.Clear();

            //lbl.Text = hdnSave.Value + "</br></br>Candidate ID: " + txtcndid.Text + "</br>Candidate name:" + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "</br>Recruiter code: " 
            //    + txtSmCode.Text + "</br>" + "<br/><br/>";

            

            mdlpopup.Show();
            if (Request.QueryString["licflag"] != null)
            {
                if (Request.QueryString["licflag"].ToUpper().ToString().Trim() == "LIC")
                {
                    lbl.Text = hdnSave.Value + "</br></br>Candidate ID: " + txtcndid.Text + "</br>Candidate name:" + cboTitle.SelectedValue + " " + txtGivenName.Text + " " + txtname.Text + "<br/><br/>License Details Updated Successfully";
                }
                
                mdlpopup.Show();
                btnCrtNewAgt.Visible = true;
                btnUpdate.Enabled = false;
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                lblMessage.Text = "Error Updating Record!";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
                btnUpdate.Enabled = false;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Application/ISys/Recruit/CndEnq.aspx?Type=" + Request.QueryString["licflag"].ToString());
    }

    private void PopulateCasteCat()
    {
        oCommon.getDropDown(ddlCasteCat, "CasteCat", 1, "", 1);
        ddlCasteCat.Items.Insert(0, "--Select--");
    }
    # region METHOD "FillRequiredDataForCndPersonal"
    protected void FillRequiredDataForCndPersonal()
    {

        DataSet dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        string cndno = Request.QueryString["CndNo"].ToString().Trim();
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page start
        //if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null)
        if (Request.QueryString["licflag"] == "LIC" && Request.QueryString["Type"] == "E" && Request.QueryString["CndNo"] != null)
        {
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        }
        //Added by rachana on 25-11-2013 to fill prospect details into candiadte reg page end
        //Added by kalyani on 30-12-2013 to display pan on edit registration functionality start
        //dsPanResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetPAN", htParam);
        htParam.Add("@flag", "1");
        dsPanResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetPAN", htParam);
        if (dsPanResult.Tables[0].Rows.Count > 0)
        {
            txtCurrentID.Text = dsPanResult.Tables[0].Rows[0]["PAN"].ToString();
        }
        //Added by kalyani on 30-12-2013 to display pan on edit registration functionality end
        htParam.Clear();
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        if (Request.QueryString["licflag"] == "LIC" && Request.QueryString["Type"] == "E" && Request.QueryString["CndNo"] != null)
        {
            htParam.Add("@CndNo", Request.QueryString["CndNo"].ToString().Trim());
        }

        try
        {

            
            DataSet ds = new DataSet();
            Hashtable htnominee = new Hashtable();

            if (Request.QueryString["CndNo"] != null && Request.QueryString["Type"] == "E")
            {
                htnominee.Clear();
                htnominee.Add("@CndNo", txtcndid.Text.Trim());
                htnominee.Add("@ProspectID", "");
                htnominee.Add("@Flag", "1");
            }
            else
            {
                htnominee.Clear();
                htnominee.Add("@CndNo", "");
                htnominee.Add("@ProspectID", strProspectID);
                htnominee.Add("@Flag", "2");
            }

            //ds = dataAccessRecruit.GetDataSetForPrcDBConn("Prc_GetCanDetails", htnominee, "INSCRecruitConnectionString");
            ds = dataAccessclass.GetDataSetForPrcDBConn("Prc_GetCanDetails", htnominee, "INSCRecruitConnectionString");
            

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["prreg"] = ds.Tables[0].Rows[0]["NomineeName"].ToString();
            }

            if (Request.QueryString["ACT"] != null)
            {

                if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] == null)
                {
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_Cnd_Edit_getCndByProspectID", htParam, "INSCRecruitConnectionString");
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_Cnd_Edit_getCndByProspectID", htParam, "INSCRecruitConnectionString");

                }
                else if (Request.QueryString["ACT"] == "PR" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                {
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_Edit_getCnd1", htParam, "INSCRecruitConnectionString");
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("prc_CndAdmin_Edit_getCnd1", htParam, "INSCRecruitConnectionString");
                }

                else
                {
                    //dsResult = dataAccessRecruit.GetDataSetForPrcDBConn("prc_CndAdmin_getCnd1", htParam, "INSCRecruitConnectionString");
                    dsResult = dataAccessclass.GetDataSetForPrcDBConn("Prc_prc_CndAdmin_getCndForLicense", htParam, "INSCRecruitConnectionString");
                }
            }
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    txtcndid.Text = cndno;

                    //------------------Change made to avoid agent updation after status 130-16/07/2008-----------
                    if (dsResult.Tables[0].Rows[0]["CndStatus"] != null)
                    {
                        //if (Convert.ToInt32(dsResult.Tables[0].Rows[0]["CndStatus"]) >= 130)
                        //{
                        //    //btnUpdate.Enabled = false;
                        //}
                        //else
                        //{
                        //    btnUpdate.Enabled = true;
                        //}
                        if (Convert.ToInt32(dsResult.Tables[0].Rows[0]["CndStatus"]) >= 110)
                        {
                            //Commented by kalyani on 21-12-2013 as Individual account info is not required start
                            //txtBankCode.Enabled = false;
                            //txtBankBranchCode.Enabled = false;
                            //txtBankNtfeCode.Enabled = false;
                            //txtBankName.Enabled = false;
                            //txtBankBranchName.Enabled = false;
                            //btnVerifyNEFT.Enabled = false;
                            //ddlPaymentMode.Enabled = false;//Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field
                            //txtBankAccntNo.Enabled = false;
                            //txtBankAccHoldName.Enabled = false;
                            //Commented by kalyani on 21-12-2013 as Individual account info is not required end
                        }
                    }
                    //------------------Change End Here to avoid agent updation after status 130--16/07/2008-----------
                    if (dsResult.Tables[0].Rows[0]["CndCat"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]).Trim() != "")
                        {
                            if (ddlcategory.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"])) != null)
                            {
                                ddlcategory.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CndCat"]);
                            }
                        }
                    }

                    //if (dsResult.Tables[0].Rows[0]["CndCat"].ToString() == "U")
                    //{
                    //    ddlBasicQual.SelectedValue = "HSC";
                    //    ddlBasicQual.Enabled = false;
                    //}

                    if (dsResult.Tables[0].Rows[0]["Title"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]).Trim() != "")
                        {
                            cboTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                        }
                    }

                    if (dsResult.Tables[0].Rows[0]["EntryDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["EntryDate"].ToString().Trim() != "")
                        {
                            txtregdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["entrydate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }
                    else
                    {
                        txtregdate.Text = "";
                    }
                    //IF condition added by Rachana for candidate reg edit mode
                    //if (Session["prreg"] != null)
                    //{

                    //    txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                    //    // txtNationalDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["NationalityDesc"]);
                    //    if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                    //    {
                    //        txtStateDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["StateDesc"]);

                    //        txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CountryDesc"]);
                    //    }
                    //}
                    //IF End Rachana

                    //added by rachana 22/05/2013 app no
                    txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);
                    txtapplicationno.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ProspectID"]);
                    txtGivenName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["GivenName"]);
                    txtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Surname"]);
                    txtFathername.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["FatherName"]);

                    if (dsResult.Tables[0].Rows[0]["Gender"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]).Trim() != "")
                        {
                            if (cboGender.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"])) != null)
                            {
                                cboGender.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Gender"]);
                            }
                        }
                    }


                    if (dsResult.Tables[0].Rows[0]["BirthRegDate"] != null)
                    {
                        if (dsResult.Tables[0].Rows[0]["BirthRegDate"].ToString().Trim() != "")
                        {
                            txtDOB.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                        }
                    }
                    else
                    {
                        txtDOB.Text = "";
                    }

                    if (dsResult.Tables[0].Rows[0]["MaritalStat"] != null)
                    {
                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim() != "")
                        {
                            cboMaritalStatus.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MaritalStat"]).Trim();
                        }
                    }



                    //if (dsResult.Tables[0].Rows[0]["PrefExmLng"] != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PrefExmLng"]).Trim() != "")
                    //    {
                    //        if (ddlpreeamlng.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["PrefExmLng"])) != null)
                    //        {
                    //            ddlpreeamlng.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PrefExmLng"]);
                    //        }
                    //    }
                    //}

                    //Added by: Mahen,on 21jan09 01:50 PM  start
                    //if (dsResult.Tables[0].Rows[0]["Exam"].ToString() != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim() != "")
                    //    {
                    //        if (ddlExam.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim()) != null)
                    //        {
                    //            ddlExam.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Exam"]).Trim();
                    //        }
                    //    }
                    //}
                    //---------------End-----------

                    txtNationalCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Nationality"]);

                    if (Session["prreg"] != null)//IF added by Rachana 22-05-2013 to fill prospect details on candidate reg page
                    {

                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                        {

                            if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                            {
                                //if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "B1" || dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "P1")
                                //{
                                //if (dsResult.Tables[0].Rows[i]["CnctType"] != null)
                                //{
                                //    if (Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]).Trim() != "")
                                //    {
                                //        ddlCnctType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]);
                                //    }
                                //}

                                //txtAddrP1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                                //txtAddrP2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                                //txtAddrP3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);
                                //txtStateCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                                //txtStateDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateDesc"]);
                                //txtPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                //txtCountryCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                                //txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDesc"]);
                                //ChkPA.Focus();

                                //}
                                //if (dsResult.Tables[0].Rows[0]["PermAdrInd"] != null)
                                //{
                                //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PermAdrInd"]).Trim() != "")
                                //    {
                                //        if (dsResult.Tables[0].Rows[0]["PermAdrInd"].ToString() == "Y")
                                //        {
                                //ChkPA.Checked = true;
                                ////miti...disabled address

                                //txtPermAdd1.Enabled = false;
                                //txtPermAdd2.Enabled = false;
                                //txtPermAdd3.Enabled = false;
                                //txtpermvillage.Enabled = false;
                                //txtPermPostcode.Enabled = false;
                                //txtPermStateDesc.Enabled = false;
                                //txtpermDistrict.Enabled = false;
                                //txtPermStateCode.Enabled = false;
                                //txtPermCountryCode.Enabled = false;
                                //txtPermCountryDesc.Enabled = false;
                                //}

                                //miti...disabled address
                                //        else
                                //        {
                                //            //ChkPA.Checked = false;
                                //        }
                                //    }
                                //}

                                //if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "M1")
                                //{
                                //    txtPermAdd1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                                //    txtPermAdd2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                                //    txtPermAdd3.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);
                                //    txtpermvillage.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Village"]);//Added by kalyani on 31-12-2013 for permanent village field
                                //    txtPermStateCode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                                //    txtpermDistrict.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["District"]);//Added by kalyani on 31-12-2013 for permanent district field
                                //    txtPermStateDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["StateDescPm"]);
                                //    txtPermPostcode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                                //    txtPermCountryCode.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                                //    txtPermCountryDesc.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDescPm"]);
                                //}
                            }
                        }

                    }//end iF by Rachana 22-05-2013 to fill prospect details on candidate reg page



                    //txthometel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HomeTel"]);
                    //txtWorkTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                    //txtMobileTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MobileTel"]);
                    //txtMobile2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Mobile2"]);//added by kalyani on 31-12-2013 for mobile2 entry
                    //txtemail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                    //txtEmail2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email2"]);//added by kalyani on 31-12-2013 for email2 entry
                    //txtfax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                    //txtdidtel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DidTel"]);
                    //txtpager.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["pager"]);
                    //txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                    //hdnDist.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                    oCommon.getDropDown(ddlPrimProf, "PrimProof", 1, "", 1);
                    ddlPrimProf.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryProf"]).Trim();
                    //txtVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Village"]);

                    //if (dsResult.Tables[0].Rows[0]["DistrbMethod"] != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["DistrbMethod"]).Trim() != "")
                    //    {

                    //        ddlDstbnMethod.SelectedValue = dsResult.Tables[0].Rows[0]["DistrbMethod"].ToString();
                    //    }
                    //}
                    //Commented by kalyani on 21-12-2013 as Commission payment mode is not required start
                    //txtBankAccntNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtAcntNum"]);
                    //txtBankAccHoldName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtAcntName"]);

                    //txtBankCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtName"]);
                    //txtBankBranchCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtBranchName"]);
                    //txtBankNtfeCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtNEFTCode"]);
                    //txtBankName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtNameDesc"]);
                    //txtBankBranchName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtBranchNameDesc"]);

                    //if (dsResult.Tables[0].Rows[0]["MchtName"] != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MchtName"]).Trim() != "")
                    //    {
                    //        if (ddlBankCode.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["MchtName"])) != null)
                    //        {
                    //            ddlBankCode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtName"]);
                    //        }
                    //    }
                    //}

                    //if (dsResult.Tables[0].Rows[0]["MchtBranchName"] != null)
                    //{
                    //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["MchtBranchName"]).Trim() != "")
                    //    {
                    //        if (ddlBankBranch.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["MchtBranchName"])) != null)
                    //        {
                    //            ddlBankBranch.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["MchtBranchName"]);
                    //        }
                    //    }
                    //}
                    //Commented by kalyani on 21-12-2013 as Commission payment mode is not required end 
                    //IF added by Rachana 22-05-2013 to fill candidate details on candidate reg page
                    

                        if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                        {
                            txtCurrentID.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Pan"]);
                            //04...07/09/2012...Miti
                            hdnpanedit.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["Pan"]);
                            //04...07/09/2012...Miti
                        }
                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {
                                if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"])) != null)
                                {
                                    ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                    FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                    //ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                }
                            }
                        }

                        
                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"])) != null)
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]);
                                    FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]));
                                }
                            }
                        }
                        if (dsResult.Tables[0].Rows[0]["AgentType"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim() != "")
                            {

                                if (ddlAgntType.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"])) != null)
                                {
                                    ddlAgntType.Visible = true;
                                    ddlAgnTypes.Visible = false;
                                    ddlAgntType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim();
                                    ddlAgntType.Enabled = false;
                                }
                                //if (Convert.ToString(dsResult.Tables[0].Rows[0]["AgentType"]).Trim() != "AG")
                                //{
                                //    ddlAgntType.Enabled = false;
                                //}
                                //else
                                //{
                                //    ddlAgntType.Enabled = true;
                                //}
                            }
                        


                        //Added if condition by rachana on 26-11-2013 for prospect details start
                        if (Request.QueryString["ACT"] == "Edit" && Request.QueryString["Type"] == "E" && Request.QueryString["ProspectId"] != null && Request.QueryString["CndNo"] != null)
                        {
                            //txtImmLeader.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitcodeIL"]);
                            //Added by kalyani on 31-12-2013 to display BranchName and CmsUnitCode for branch code start
                            //if (dsResult.Tables[0].Rows[0]["UnitcodeIL"] != null)
                            //{
                            //    Hashtable htcode = new Hashtable();
                            //    DataSet dsBranchCode = new DataSet();
                            //    htcode.Add("@UNitcode", Convert.ToString(dsResult.Tables[0].Rows[0]["UnitcodeIL"]).Trim());
                            //    htcode.Add("@BizSrc", Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                            //    htcode.Add("@Chncls", Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                            //    //dsBranchCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                            //    dsBranchCode = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                            //    string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                            //    string cmsunitcode = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["CmsUnitCode"]).Trim();

                            //    txtImmLeader.Text = branch + "(" + cmsunitcode + ")";
                            //}
                            //Added by kalyani on 31-12-2013 to display BranchName and CmsUnitCode for branch code end
                            //txtSmCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CSCCodeIL"]);
                            txtSmCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DirectAgtCode"]);
                            //txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalNameIL"]);
                            //txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalNameRC"]);



                            //if (dsResult.Tables[0].Rows[0]["ProofAgeDoc"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAgeDoc"]).Trim() != "")
                            //    {
                            //        if (ddlProofAge.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAgeDoc"])) != null)
                            //        {
                            //            ddlProofAge.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAgeDoc"]).Trim();
                            //        }
                            //    }
                            //}


                            //if (dsResult.Tables[0].Rows[0]["ProofAddrDoc"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAddrDoc"]).Trim() != "")
                            //    {
                            //        if (ddlProofAddr.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAddrDoc"])) != null)
                            //        {
                            //            ddlProofAddr.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofAddrDoc"]);
                            //        }
                            //    }
                            //}

                            //if (dsResult.Tables[0].Rows[0]["ProofIDDoc"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim() != "")
                            //    {

                            //        ddleducationproof.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofIDDoc"]).Trim();
                            //        //Response.Write(ddleducationproof.SelectedValue.ToString().Trim());
                            //        //Response.End();
                            //    }
                            //}

                            //Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field start
                            //if (dsResult.Tables[0].Rows[0]["PmtMode"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PmtMode"]).Trim() != "")
                            //    {
                            //        if (ddlPaymentMode.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["PmtMode"])) != null)
                            //        {
                            //            ddlPaymentMode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PmtMode"]);
                            //        }
                            //    }
                            //}
                            //Commented by Kalyani on 20-12-2013 as Commission payment mode no is not a required field end

                            //if (dsResult.Tables[0].Rows[0]["HasPhoto"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasPhoto"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasPhoto"]).Trim() == "Y")
                            //            cbphoto.Checked = true;
                            //        else
                            //            cbphoto.Checked = false;
                            //    }
                            //}

                            //if (dsResult.Tables[0].Rows[0]["HasMarkSheet"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasMarkSheet"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasMarkSheet"]).Trim() == "Y")
                            //            cbmarksheet.Checked = true;
                            //        else
                            //            cbmarksheet.Checked = false;
                            //    }
                            //}

                            //if (dsResult.Tables[0].Rows[0]["HasCertificate"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasCertificate"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["HasCertificate"]).Trim() == "Y")
                            //            cbcertificate.Checked = true;
                            //        else
                            //            cbcertificate.Checked = false;
                            //    }
                            //}
                            //01
                            //if (dsResult.Tables[0].Rows[0]["PanchayatFlag"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PanchayatFlag"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["PanchayatFlag"]).Trim() == "Y")
                            //        {
                            //            trPanchayat.Visible = true;
                            //            cbPanachayat.Checked = true;
                            //        }
                            //        else
                            //        {
                            //            if (ddlBasicQual.SelectedValue == "SSC" && ddlcategory.SelectedValue == "P")
                            //            {
                            //                trPanchayat.Visible = true;
                            //            }

                            //            cbPanachayat.Checked = false;
                            //        }
                            //    }
                            //}
                            //if (dsResult.Tables[0].Rows[0]["NocAckFlag"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["NocAckFlag"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["NocAckFlag"]).Trim() == "Y")
                            //        {
                            //            trNOCAck.Visible = true;
                            //            chkNOCAck.Checked = true;
                            //        }
                            //        else
                            //        {
                            //            if (cbTrfrFlag.Checked == true && RbtNoc.SelectedValue == "1")
                            //            {
                            //                trNOCAck.Visible = true;
                            //            }
                            //            chkNOCAck.Checked = false;
                            //        }
                            //    }
                            //}
                            //01

                            //Start Added on 27-02-08

                            //if (dsResult.Tables[0].Rows[0]["ChqDate"] != null)
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["ChqDate"].ToString().Trim() != "")
                            //    {
                            //        txtchqdate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["ChqDate"])).ToString(CommonUtility.DATE_FORMAT);
                            //    }
                            //}
                            //else
                            //{
                            //    txtchqdate.Text = "";
                            //}
                            //txtchqdd.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChqNo"]);

                            //now below amt is Cash amt instead of Cheque amt.
                            //txtchqamt.Text = String.Format("{0:#.##}", dsResult.Tables[0].Rows[0]["ChqAmt"]);
                            //txtremarks.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ProofRemarks"]);

                            //Added on 29th Sept 08 , added new field (CashReceipt) in DB
                            //commented by Ank 13.01.2011
                            //if (dsResult.Tables[0].Rows[0]["CashReceipt"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["CashReceipt"]).Trim() != "")
                            //    {
                            //        if (Convert.ToString(dsResult.Tables[0].Rows[0]["CashReceipt"]).Trim() == "1")
                            //            chkCashReceipt.Checked = true;
                            //        else
                            //            chkCashReceipt.Checked = false;
                            //    }
                            //}



                            //if (dsResult.Tables[0].Rows[0]["CFR"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["CFR"]).Trim() != "")
                            //    {
                            //        if (dsResult.Tables[0].Rows[0]["CFR"].ToString() == "Y")
                            //            cbcfr.Checked = true;
                            //        else
                            //            cbcfr.Checked = false;
                            //    }
                            //}

                            //End Added on 27-02-08


                            if (dsResult.Tables[0].Rows[0]["NOCFlag"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["NOCFlag"]).Trim() != "")
                                {

                                    // 01...06/09/2012...Miti
                                    //if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() == "1")
                                    //    cbNOCFlag.Checked = true;
                                    //else
                                    //    cbNOCFlag.Checked = false;

                                    if (dsResult.Tables[0].Rows[0]["NOCFlag"].ToString() == "1")
                                        RbtNoc.SelectedIndex = 0;
                                    else
                                        RbtNoc.SelectedIndex = 1;
                                    // 01...06/09/2012...Miti


                                }
                            }
                            if (dsResult.Tables[0].Rows[0]["LcnNo"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["LcnNo"]).Trim() != "")
                                {
                                    ///txtOldTccLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnno"]).Trim();
                                    
                                    txtOldTccLcnNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LcnNo"]).Trim();
                                    
                                }
                            }

                            if (dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim() != "")
                                {
                                    txtTccPrevInsurerName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccPrevInsrName"]).Trim();
                                }
                            }

                            if (dsResult.Tables[0].Rows[0]["LcnExpDate"] != null)
                            {
                                if (dsResult.Tables[0].Rows[0]["LcnExpDate"].ToString().Trim() != "")
                                {
                                    //txtOldTccLcnExpDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                    ///txtDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["OldTccLcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);

                                    txtDate.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["LcnExpDate"])).ToString(CommonUtility.DATE_FORMAT);
                                }
                            }
                            else
                            {
                                txtDate.Text = "";//txtOldTccLcnExpDate
                            }

                            //if (dsResult.Tables[0].Rows[0]["TrnsfrFlag"].ToString() == "1")
                            //{

                            //    //miti...enabled controls on edit
                            //    txtOldTccLcnNo.Enabled = true;
                            //    lbloldLcnNo.Enabled = true;
                            //    txtTccPrevInsurerName.Enabled = true;
                            //    lblPrevInsurerName.Enabled = true;
                            //    lblNOCFlag.Enabled = true;
                            //    RbtNoc.Enabled = true;
                            //    cbTrfrFlag.Checked = true;
                            //    lblOldLcnexpDate.Enabled = true;
                            //    //miti...enabled controls on edit
                            //    txtOldTccLcnNo.Focus();
                            //}

                            //else
                            //{
                            //    cbTrfrFlag.Checked = false;
                            //    txtReferredBy.Focus();
                            //}





                            //Response.Write("Comp LCN" + dsResult.Tables[0].Rows[0]["TccCompLcn"]);
                            //Response.End();
                            //if (dsResult.Tables[0].Rows[0]["TccCompLcn"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["TccCompLcn"]).Trim() != "")
                            //    {
                            //        if (dsResult.Tables[0].Rows[0]["TccCompLcn"].ToString().Trim() == "True")
                            //            cbTccCompLcn.Checked = true;
                            //        else
                            //            cbTccCompLcn.Checked = false;
                            //    }
                            //}

                            //txtUnitName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc01"]).Trim();
                            //txtUnitCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["LUnitCode"]).Trim();

                            //txtExmCentre.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["HwsUnitDesc01"]).Trim();
                            //hdnExmCentreCode.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["ECCode"]).Trim();

                            //Added on : 2009-11-10, Adding New Field
                            //txtYFrmNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["YFrmNo"]).Trim(); //Commented  by kalyani on 27-12-2013 as column removed from cnd table

                            //Added on : 2009-12-15, Adding New Field
                            //if (dsResult.Tables[0].Rows[0]["PhotoSignFlag"] != null)
                            //{
                            //    //if (Convert.ToString(dsResult.Tables[0].Rows[0]["PhotoSignFlag"]).Trim() == "1")
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["PhotoSignFlag"]).Trim() == "Y")
                            //    {
                            //        chkPhotoSign.Checked = true;
                            //    }
                            //    else
                            //    {
                            //        chkPhotoSign.Checked = false;
                            //    }
                            //}
                            //txtPrimProf.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimProf"]).Trim();//Commented by Kalyani on 20-12-2013 as textbox of primary profession is change to dropdown
                            ddlPrimProf.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryProf"]).Trim();//Added by kalyani on 20-12-2013 as textbox of primary profession is change to dropdown
                            if (dsResult.Tables[0].Rows[0]["CasteCat"] != null)
                            {
                                if (Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]).Trim() != "")
                                {
                                    if (ddlCasteCat.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"])) != null)
                                    {
                                        ddlCasteCat.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]);
                                    }
                                }
                            }
                            //if (dsResult.Tables[0].Rows[0]["ExmBody"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody"]).Trim() != "")
                            //    {
                            //        if (ddlExmBody.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody"])) != null)
                            //        {
                            //            ddlExmBody.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ExmBody"]);
                            //        }
                            //    }
                            //}
                            //if (dsResult.Tables[0].Rows[0]["TrnMode"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"]).Trim() != "")
                            //    {
                            //        if (ddlTrnMode.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"])) != null)
                            //        {
                            //            ddlTrnMode.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnMode"]);
                            //        }
                            //    }
                            //}
                            //if (dsResult.Tables[0].Rows[0]["TrnLoc"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]).Trim() != "")
                            //    {
                            //        if (ddlTrnLoc.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"])) != null)
                            //        {
                            //            ddlTrnLoc.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["TrnLoc"]);
                            //        }
                            //    }
                            //}

                            //if (dsResult.Tables[0].Rows[0]["BasicQual"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]).Trim() != "")
                            //    {
                            //        if (ddlBasicQual.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"])) != null)
                            //        {
                            //            ddlBasicQual.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicQual"]);
                            //        }
                            //    }
                            //}
                            //txtBoardName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicBoardName"]).Trim();
                            //txtBasicRNo.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicRollNo"]).Trim();
                            ////txtYrPass.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["BasicYrPass"]).Trim();

                            //if (dsResult.Tables[0].Rows[0]["BasicYrPass"] != null)
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["BasicYrPass"].ToString().Trim() != "")
                            //    {
                            //        txtYrPass.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BasicYrPass"])).ToString(CommonUtility.DATE_FORMAT);
                            //    }
                            //}
                            //else
                            //{
                            //    txtYrPass.Text = "";
                            //}

                            //if (dsResult.Tables[0].Rows[0]["DrMailID"] != null)
                            //{
                            //    if (Convert.ToString(dsResult.Tables[0].Rows[0]["DrMailID"]).Trim() != "")
                            //    {
                            //        if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["DrMailID"]) == true)
                            //            cbdirectmail.Checked = true;
                            //        else
                            //            cbdirectmail.Checked = false;
                            //    }
                            //}
                            //added by ank on 03.08.2011 for Nominee Details
                            //if (dsResult.Tables[0].Rows[0]["NomineeName"] != null)
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["NomineeName"].ToString().Trim() != "")
                            //    {
                            //        txtNominee.Text = dsResult.Tables[0].Rows[0]["NomineeName"].ToString();
                            //    }
                            //}
                            //else
                            //{
                            //    txtNominee.Text = "";
                            //}
                            //if (dsResult.Tables[0].Rows[0]["NomineAdvRel"] != null)
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["NomineAdvRel"].ToString().Trim() != "")
                            //    {
                            //        //03...07/09/2012...Miti
                            //        Ddlrelation.SelectedValue = dsResult.Tables[0].Rows[0]["NomineAdvRel"].ToString();
                            //        //03...07/09/2012...Miti
                            //    }
                            //}
                            //else
                            //{
                            //    //03...07/09/2012...Miti
                            //    Ddlrelation.SelectedValue = "";
                            //    //03...07/09/2012...Miti
                            //}
                            //if (dsResult.Tables[0].Rows[0]["NomineAge"] != null)
                            //{
                            //    if (dsResult.Tables[0].Rows[0]["NomineAge"].ToString().Trim() != "")
                            //    {
                            //        txtNomineeAge.Text = dsResult.Tables[0].Rows[0]["NomineAge"].ToString();
                            //    }
                            //}
                            //else
                            //{
                            //    txtNomineeAge.Text = "";
                            //}
                        }//Added if condition by rachana on 26-11-2013 for prospect details end
                        txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]);

                    }//end IF 
                }
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
        //txtcndid.Text = null;

            }
    #endregion

    #region METHOD 'FillddlSlsChannel' DEFINITION
    private void FillddlSlsChannel(string sddlSlsChannel)
    {
        ddlAgntType.Items.Clear();
        ddlChnCls.Items.Clear();
        SqlDataReader dtRead;

        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel with Carrier code and BizSrc start
        httable.Clear();
        int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
        httable.Add("@CarrierCode", CarrierCode);
        httable.Add("@BizSrc", sddlSlsChannel);
        dtRead = dataAccessclass.exec_reader_prc_conn("Prc_Getddlslschannel", httable, CONN_Recruit);
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel with Carrier code and BizSrc End

        if (dtRead.HasRows)
        {
            ddlChnCls.DataSource = dtRead;
            ddlChnCls.DataTextField = "ChnlDesc";
            ddlChnCls.DataValueField = "ChnCls";
            ddlChnCls.DataBind();
        }
        dtRead = null;
        ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));

    }
    #endregion

    private void FillddlChnCls(string sddlSlsChannel, string sddlChnCls)
    {
        ddlAgntType.Items.Clear();
        SqlDataReader dtRead;
        httable.Clear();
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start
        int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
        httable.Add("@CarrierCode", CarrierCode);
        httable.Add("@BizSrc", sddlSlsChannel);
        httable.Add("@ChnCls", sddlChnCls);

        dtRead = dataAccessclass.exec_reader_prc_conn("Prc_getchannelcls", httable, CONN_Recruit);
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start

        if (dtRead.HasRows)
        {
            ddlAgntType.DataSource = dtRead;
            ddlAgntType.DataTextField = "AgentTypeDesc";
            ddlAgntType.DataValueField = "AgentType";
            ddlAgntType.DataBind();
        }
        dtRead = null;
        ddlAgntType.Items.Insert(0, new ListItem("-- Select --", ""));
    }
    #region METHOD 'GetSalesChannel' DEFINITION
    private void GetRecruitSalesChannel(DropDownList ddl, string strBizSrc, int strIncMasterCmp)
    {

        ddlChnCls.Items.Clear();
        ddlAgntType.Items.Clear();

        string strSql = string.Empty;
        DataSet dsResult = new DataSet();
        //strSql = "SELECT DISTINCT BizSrc, ChannelDesc01 FROM dbo.RecruitChn where CarrierCode = '" + Session["CarrierCode"].ToString() + "'";
        //dsResult = dataAccess.GetDataSetWithoutParam(strSql, CONN_Recruit);

        //Added By Asrar on 27-06-2013 for converting Inline query into procedure Get Sales Channel start
        int CarrierCode = Convert.ToInt32(Session["CarrierCode"].ToString());
        httable.Clear();
        httable.Add("@CarrierCode", CarrierCode);
        dsResult = dataAccessclass.GetDataSetForPrcDBConn("Prc_getrecruitslschannel", httable, CONN_Recruit);
        //Added By Asrar on 27-06-2013 for converting Inline query into procedure  Get Sales Channel End

        if (dsResult.Tables.Count > 0)
        {
            oCommonUtility.FillDropDown(ddl, dsResult.Tables[0], "BizSrc", "ChannelDesc01");
            if (strBizSrc.Trim() != "")
            {
                ddl.SelectedValue = strBizSrc.Trim();
            }
        }
        dsResult = null;
        strSql = null;


    }
    #endregion

    protected void PopulateRecruiterCode()
    {
        try
        {
            if (Request.QueryString["Type"].ToString() == "N" || Request.QueryString["ACT"].ToString() == "Edit")
            {

                htParam.Clear();
                htParam.Add("@CarrierCode", Session["CarrierCode"].ToString().Trim());
                htParam.Add("@UserId", Session["UserID"].ToString());
                DataSet dsResult = new DataSet();
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_RecruitInfoSearchBySMCode", htParam);
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_RecruitInfoSearchBySMCode", htParam);

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        IsFound = true;

                        txtSmCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentCode"]).Trim();

                        //txtImmLeader.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["/"]).Trim();
                        //txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();
                        txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["AgentCode"]).Trim();
                        txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LegalName"]).Trim();

                        hdnBizSrc.Value = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();

                        //Set the Sales Channel
                        if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                            {
                                if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                                {
                                    ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                                    FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                                }
                            }
                        }

                        //Set the Channel sub Class
                        if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                        {
                            if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                            {
                                if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                                {
                                    ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                                    //FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                                }
                            }
                        }
                        //Added by rachana on 05-12-2013 to populate Agent type when recuiter code verified start
                        //Set Agent Type
                        strAgentType = dsResult.Tables[0].Rows[0]["AgentType"].ToString();
                        if (strAgentType == "SM")
                        {
                            PopulateAgentTypes();
                        }
                        //Added by rachana on 05-12-2013 to populate Agent type when recuiter code verified end
                    }
                }
            }
            else
            {
                htParam.Clear();
                htParam.Add("@ProspectId", Request.QueryString["ProspectId"].ToString().Trim());
                DataSet dsResult = new DataSet();
                //dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetRecruitDetails", htParam);
                dsResult = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetRecruitDetails", htParam);

                txtSmCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]).Trim();
                //Added by kalyani on 31-12-2013 to display BranchName and CmsUnitCode for branch code start
                if (dsResult.Tables[0].Rows[0]["RecruitUnitCode"] != null)
                {
                    Hashtable htcode = new Hashtable();
                    DataSet dsBranchCode = new DataSet();
                    htcode.Add("@UNitcode", Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).Trim());
                    htcode.Add("@BizSrc", Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                    htcode.Add("@Chncls", Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                    //dsBranchCode = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                    dsBranchCode = dataAccessclass.GetDataSetForPrcRecruit("Prc_GetBranchName", htcode);
                    string branch = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["UnitLegalName"]).Trim();
                    string cmsunitcode = Convert.ToString(dsBranchCode.Tables[0].Rows[0]["CmsUnitCode"]).Trim();

                    //txtImmLeader.Text = branch + "(" + cmsunitcode + ")";
                }
                //Added by kalyani on 31-12-2013 to display BranchName and CmsUnitCode for branch code end
                //txtImmLeader.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitUnitCode"]).Trim();
                //txtDirectAgtName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]).Trim();
                txtrecagent.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtCode"]).Trim();
                txtrecagtname.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RecruitAgtName"]).Trim();

                //Set the Sales Channel
                if (dsResult.Tables[0].Rows[0]["BizSrc"] != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim() != "")
                    {
                        if (ddlSlsChannel.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim()) != null)
                        {
                            ddlSlsChannel.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim();
                            FillddlSlsChannel(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim());
                        }
                    }
                }

                //Set the Channel sub Class
                if (dsResult.Tables[0].Rows[0]["ChnCls"] != null)
                {
                    if (Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim() != "")
                    {
                        if (ddlChnCls.Items.FindByValue(Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim()) != null)
                        {
                            ddlChnCls.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim();
                            //FillddlChnCls(Convert.ToString(dsResult.Tables[0].Rows[0]["BizSrc"]).Trim(), Convert.ToString(dsResult.Tables[0].Rows[0]["ChnCls"]).Trim());
                        }
                    }
                }
                //Added by rachana on 05-12-2013 to populate Agent type when recuiter code verified start
                //Set Agent Type
                strAgentType = dsResult.Tables[0].Rows[0]["AgentType"].ToString();
                if (strAgentType == "SM")
                {
                    PopulateAgentTypes();
                }
                //Added by rachana on 05-12-2013 to populate Agent type when recuiter code verified end
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

    private void PopulateAgentTypes()
    {
        //Added By Asrar on 26-06-2013 for converting Inline query into procedure Agent Type start
        ddlAgnTypes.Items.Clear();

        //DSAgnTypes.SelectCommand = "Prc_GetAgentType";
        DSAgnTypes.SelectCommand = "Prc_GetAgentTypeforCndReg '" + ddlSlsChannel.SelectedValue + "','" + ddlChnCls.SelectedValue + "','" + strAgentType + "'";
        ddlAgnTypes.DataBind();

        //ddlAgnTypes.Items.Insert(0, "--Select--");

        //ddlAgnTypes.Items.Insert(0, "--Select--");
        //Added By Asrar on 26-06-2013 for converting Inline query into procedure  Agent Type End
    }
    protected void btnCrtNewAgt_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\ChannelMgmt\\AGTInfo.aspx?lic=LicCnd&Type=N&CndNo=" + txtcndid.Text, false);
    }
}
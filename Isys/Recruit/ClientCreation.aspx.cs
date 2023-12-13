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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using Insc.MQ.Life.AgnMd;
using INSCL.App_Code;
using INSCL.DAL;
using Insc.Common.Multilingual;
using System.IO;
using System.Text.RegularExpressions;

using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using DataAccessClassDAL;



public partial class Application_Isys_Recruit_ClientCreation : BaseClass
{
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    DataSet dsdocType = new DataSet();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    string str;
    string doctype;
    private const string c_strBlank = "Select";
    string strDocName = string.Empty;
    private string strFileName1 = string.Empty;
    private DataAccessClass dataAccessclass = new DataAccessClass();
    DataSet ds_image = new DataSet();
    string strPhotoExt = string.Empty;
    string strSignExt = string.Empty;
    string strPath = System.Configuration.ConfigurationManager.AppSettings["UploadImgPath"].ToString();
    private string strFileName = string.Empty;
    string cndno = string.Empty;
    string candtype = string.Empty;
    public multilingualManager olng;
    protected CommonFunc oCommon = new CommonFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
       cndno = Request.QueryString["CndNo"].ToString().Trim();
      //  cndno = "30026801";

        if (cndno == null)
        {
            Response.Redirect("~/CndEnq.aspx");
        }

        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            txtNationalDesc.Text = "INDIAN";
            txtCountryDescP.Text = "INDIAN";
            ddlternetid.Items.Insert(0, "Select");
            ddllspind.Items.Insert(0, "Select");
            ddlRule.Items.Insert(0, "Backend Client");
            ddlSOE.Items.Insert(0, "Select");
            PopulateCasteCat();
            cboGender.Attributes.Add("style", "display: visible");
            subPopulateGender();
            subPopulateTitle();
            PopulateMaritalStatus();
            PopulateBasicQual();
            PopulateState();
            PopulateState1();
            PopulateContactPreferred();
          //  FillData(cndno);
           

         FillData(Request.QueryString["CndNo"].ToString().Trim());

        }

    }
    #region InitializeControl
    private void InitializeControl()
    {
        try
        {
           // btnUpdate.Text = olng.GetItemDesc("btnSaveGly");
            //lblCategory.Text = olng.GetItemDesc("lblCategory");
            lblpfPersonal.Text = olng.GetItemDesc("lblpfPersonal");
            //lblpfAppNo.Text = olng.GetItemDesc("lblpfAppNo");
           // lblpfRegDate.Text = olng.GetItemDesc("lblpfRegDate");
            lblpfGivenName.Text = olng.GetItemDesc("lblpfGivenName");
            lblpfSurname.Text = olng.GetItemDesc("lblpfSurname");
            lblpfFatherName.Text = olng.GetItemDesc("lblpfFatherName");
            lblpfGender.Text = olng.GetItemDesc("lblpfGender");
            lblpfDOB.Text = olng.GetItemDesc("lblpfDOB");
           
            lblpfNationality.Text = olng.GetItemDesc("lblpfNationality");
           // btnCancel.Text = olng.GetItemDesc("btnCancelGly");
            //Added by Pranjali on 05-12-2013 for displaying label fields through table start
            lblpan.Text = olng.GetItemDesc("lblpan");
            //lblProfession.Text = olng.GetItemDesc("lblOccupation");
            //lblpfrecinfotitle.Text = olng.GetItemDesc("lblpfrecinfotitle");
            //lblpfcndChnltitle.Text = olng.GetItemDesc("lblpfcndChnltitle");
          //  lblSpeclNotes.Text = olng.GetItemDesc("lblSpeclNotes");
           
           
            //lblpfimmleader.Text = olng.GetItemDesc("lblpfimmleader");
            //lblpfSMName.Text = olng.GetItemDesc("lblpfSMName");
            //lblpfagetype.Text = olng.GetItemDesc("lblpfagetype");
            //lblCndAgtType.Text = olng.GetItemDesc("lblCndAgtType");
            
            lblEmail2.Text = olng.GetItemDesc("lblEmail2");
            lblpfemail.Text = olng.GetItemDesc("lblpfemail");
            lblMobile2.Text = olng.GetItemDesc("lblMobile2");
            //lblpfmobtel.Text = olng.GetItemDesc("lblpfmobtel");
            lblpfofftel.Text = olng.GetItemDesc("lblpfofftel");
            lblpfhometel.Text = olng.GetItemDesc("lblpfhometel");
            //lblpfconpreferred.Text = olng.GetItemDesc("lblpfconpreferred");
            //Contact Details added by rachana end
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
    private void PopulateContactPreferred()
    {
        try
        {
            oCommon.getDropDown(ddlDstbnMethod, "DstbnMtd", 1, "", 1);
            //ddlDstbnMethod.Items.Insert(0, "Select");
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
    private void subPopulateGender()
    {
        try
        {
            oCommon.getDropDown(cboGender, "NBGender", 1, "", 1);
            cboGender.Items.Remove(cboGender.Items.FindByValue("C"));
            cboGender.Items.Remove(cboGender.Items.FindByValue("U"));
           // subGenerateGenderValidation();
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
    private void PopulateMaritalStatus()
    {
        try
        {
            oCommon.getDropDown(ddlmaritalstatusDesc, "MarrySts", 1, "", 1);
           // ddlmaritalstatusDesc.Items.Insert(0, "Select");
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
    private void PopulateCasteCat()
    {
        try
        {
            oCommon.getDropDown(ddlCat, "CasteCat", 1, "", 1);
            //ddlCat.Items.Insert(0, "Select");
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
    private void PopulateBasicQual()
    {
        try
        {
            oCommon.getDropDown(ddlHighQual, "BasicQual", 1, "", 1);
           // ddlHighQual.Items.Insert(0, "Select");
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
    #region PopulateState
    private void PopulateState()
    {
        try
        {
            string strSql = string.Empty;
            SqlDataReader dtRead;
            DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            dtRead = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");

            dtRead.Read();
            if (dtRead.HasRows)
            {
                ddlState.DataSource = dtRead;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select");
            }
            dsResult = null;
            dtRead = null;
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
    private void PopulateState1()
    {
        try
        {
            string strSql = string.Empty;
            SqlDataReader dtRead1;
            DataSet dsResult = new DataSet();
            Hashtable ht = new Hashtable();
            ht.Clear();
            dtRead1 = dataAccessclass.exec_reader_prc_inscdirect("Prc_GetddlState");

            if (dtRead1.HasRows)
            {
                ddlstateper.DataSource = dtRead1;
                ddlstateper.DataTextField = "StateName";
                ddlstateper.DataValueField = "StateID";
                ddlstateper.DataBind();
                ddlstateper.Items.Insert(0, "Select");
            }
            dsResult = null;
            dtRead1 = null;
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
     protected void FillData(string strCndNo)
    {

         try
         {
        htParam.Clear();
        htParam.Add("@CndNo", cndno);
        htParam.Add("@CarrierCode", 2);

        dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("prc_CndAdmin_getCndView", htParam);


        if (dsResult != null)
        {
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                   // cboTitle.SelectedValue = dsResult.Tables[0].Rows[0]["Title"].ToString().Trim();
                    cboTitle.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["Title"]);
                    txtpfGivenName.Text = dsResult.Tables[0].Rows[0]["GivenName"].ToString().Trim();
                    txtpfSurname.Text = dsResult.Tables[0].Rows[0]["Surname"].ToString().Trim();
                    txtDOB.Text = DateTime.Parse(Convert.ToString(dsResult.Tables[0].Rows[0]["BirthRegDate"])).ToString(CommonUtility.DATE_FORMAT);
                    txtFatherName.Text = dsResult.Tables[0].Rows[0]["FatherName"].ToString();
                    txtpan.Text = dsResult.Tables[0].Rows[0]["PAN"].ToString();
                    cboGender.SelectedValue = dsResult.Tables[0].Rows[0]["Gender"].ToString();
                    ddlmaritalstatusDesc.SelectedValue = dsResult.Tables[0].Rows[0]["MaritalStat"].ToString();
                    txtNationalCode.Text = dsResult.Tables[0].Rows[0]["Nationality"].ToString();

                   
                ddlCat.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[0]["CasteCat"]);


                ddlHighQual.SelectedValue = dsResult.Tables[0].Rows[0]["Qualific"].ToString();//PrimaryProf
                    txtoccupation1.Text  =dsResult.Tables[0].Rows[0]["PrimaryProf"].ToString();//PrimaryProf
                    txtemail.Text = dsResult.Tables[0].Rows[0]["Email"].ToString();
                 


                    //contact preffered 


                   
                 ddlDstbnMethod.SelectedValue=  dsResult.Tables[0].Rows[0]["Contact"].ToString();
                 ddlprivacy.SelectedValue = dsResult.Tables[0].Rows[0]["Contact"].ToString();
                 txthometel.Text = dsResult.Tables[0].Rows[0]["HomeTel"].ToString();
                 txtWorkTel.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() != "" ? txtWorkTel.Text = dsResult.Tables[0].Rows[0]["WorkTel"].ToString() : txtWorkTel.Text = "";
                 didtel.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() != "" ? didtel.Text = dsResult.Tables[0].Rows[0]["Mobile2"].ToString() : didtel.Text = "";
                 txtMobile2.Text = dsResult.Tables[0].Rows[0]["MobileTel"].ToString();



                    //Addresss


                 for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                 {

                      if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "B1" || dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "P1")
                         {
                             //if (dsResult.Tables[0].Rows[i]["CnctType"] != null)
                             //{
                                 //if (Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]).Trim() != "")
                                 //{
                                 //    ddlCnctType.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["CnctType"]);
                                 //}
                            // }

                           


                             txtAddrP1.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                             txtDistric.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                             txtStateCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);
                             

                             ddlState.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);
                            
                            
                           
                             
                             txtPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                             txtCountryCodeP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                             txtCountryDescP.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDesc"]);

                            

                         }
                         if (dsResult.Tables[0].Rows[0]["PermAdrInd"] != null)
                         {
                             if (Convert.ToString(dsResult.Tables[0].Rows[0]["PermAdrInd"]).Trim() != "")
                             {
                                 if (dsResult.Tables[0].Rows[0]["PermAdrInd"].ToString() == "Y")
                                 {

                                     //persent address 
                                     //txtper.Text = dsResult.Tables[0].Rows[0]["Adr1"].ToString();
                                     //txtaddrper2.Text = dsResult.Tables[0].Rows[0]["Adr2"].ToString();
                                     //ddlstateper.SelectedValue = dsResult.Tables[0].Rows[0]["StateID"].ToString();
                                     //txtdist2.Text = dsResult.Tables[0].Rows[0]["District"].ToString();
                                     //   txtpinper.Text = dsResult.Tables[0].Rows[0]["PostCode"].ToString();
                                     //txtcountryper.Text = dsResult.Tables[0].Rows[0]["CountryDescPm"].ToString();

                                     ChkPA.Checked = true;

                                     txtper.Enabled = false;
                                     txtaddrper2.Enabled = false;
                                     ddlstateper.Enabled = false;
                                     txtdist2.Enabled = false;
                                     txtcountryper.Enabled = false;
                                     
                                    
                                 }

                                
                                 else
                                 {
                                     ChkPA.Checked = false;
                                 }
                             }
                         }

                         if (dsResult.Tables[0].Rows[i]["CnctType"].ToString() == "M1")
                         {
                             txtper.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr1"]);
                             txtaddrper2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr2"]);
                             txtdist2.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["Adr3"]);


                             ddlstateper.SelectedValue = Convert.ToString(dsResult.Tables[0].Rows[i]["StateCode"]);




                             txtpinper.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["PostCode"]);
                             txtcountryper.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CntryCode"]);
                             txtcntryper.Text = Convert.ToString(dsResult.Tables[0].Rows[i]["CountryDesc"]);

                            
                             
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
                }
     protected void btnUpdate_Click(object sender, EventArgs e)
     {
         try
         {
             htParam.Clear();
            // dsResult.Clear();
             htParam.Add("@cndno", cndno);
             dsResult = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_Updclientcode", htParam);
            // lbl3.Text = "Client code created sucessfully";
             lbl3.Text = "Client code created sucessfully" + "</br></br>Customer ID: " + cndno + "</br>Customer Name:" + cboTitle.SelectedValue + " " + txtpfGivenName.Text + "<br/>Note :- Please proceed to  agent code creation";
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
             txtcstmrid.Text = cndno;
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
    
}
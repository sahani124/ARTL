using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Insc.Common.Multilingual;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using DataAccessClassDAL;
using INSCL.DAL;
using Insc.MQ.Life.CSMod;
using System.Drawing;

public partial class Application_ISys_ChannelMgmt_PopUnitDetails : BaseClass
{
    #region Declarations
    SqlDataReader dtRead;
    Hashtable htable = new Hashtable();
    CommonFunc oCommon = new CommonFunc();
    Decimal untLvl;
    XmlDocument doc = new XmlDocument();
    DataSet dsResult;
    private multilingualManager olng, olng2, olng3;
    private string strUserLang;
    int intCode;
    string ErrMsg, AuditType, strXML = "", MgrCreateRul = "", strRptUnitCode = "";
    DataAccessClass objDAL = new DataAccessClass();
    DataAccessClass dataAccess = new DataAccessClass();
    INSCL.App_Code.CommonUtility objCommonU = new INSCL.App_Code.CommonUtility();
    clsUnitMaint objclsUM = new clsUnitMaint();
    clsAgent agentObject = new clsAgent();
    string strMgrCode = "", strAgentType = "", strUnitRank = "", strNewAgnType = "";
    string strCallType = System.Configuration.ConfigurationManager.AppSettings["callLA"].ToString();
    DataSet dsUnit;
    DataSet dsUnitType;
    Hashtable htUnitType = new Hashtable();
    ErrLog objErr = new ErrLog();
    MQCSMod objCSMd = new MQCSMod();
  static Boolean blnFlag ;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        div_UnitContact.Attributes.Add("style", "display:block");
        //btnUnitContactDtlscollapse.Value = "+";
        
        lbl_DateVal.Text = System.DateTime.Now.Date.ToString("dd/MM/yy");

        strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();
        olng = new multilingualManager("DefaultConn", "UnitMaintEdit.aspx", strUserLang);
        olng2 = new multilingualManager("DefaultConn", "AGTLevel.aspx", strUserLang);
        olng3 = new multilingualManager("DefaultConn", "PopUnitDetails.aspx", strUserLang);
        Session["CarrierCode"] = '2';

        btnCease.Attributes.Add("onClick", "javascript: return funValidate()");

        if (!IsPostBack)
        {
         
            InitializeControl();
            fillDetailLabels();
           // fillUnitsAgents();
            oCommon.getDropDown(ddlCeaseReason, "UntCse", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);
            ddlCeaseReason.Items.Insert(0,"Select");

            ////MultiViewCrnt.ActiveViewIndex = 0;
            lnkCrntAgentDetails.BackColor = Color.Transparent;
            lnkCrntPrimMgr.BackColor = Color.Transparent;
            lnkCrntAddlMgr.BackColor = Color.Transparent;

            lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng_hover.png";
            lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails.png";
            lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng.png";
            lblValUnitCode.Text = Convert.ToString(Request.QueryString["UnitCode"]);
            divmember.Attributes.Add("style", "display:none");
            divadditional.Attributes.Add("style", "display:none");
            Primary.CssClass = "btn-subtab btn btn-default";
            
            btnCease.Attributes.Add("onClick", "javascript: return funValidate()");


          
        }

        btnCease.Attributes.Add("onClick", "javascript: return funValidate()");
    }
    #endregion

    #region METHOD Initialize Control
    protected void InitializeControl()
    {
        #region HIDE SHOW
        //trMasterLink.Visible = false;
        LblBizsrc.Visible = false;
        LblSlschannel.Visible = false;
        LblSubclass.Visible = false;
        LblChannelSubclass.Visible = false;
        LblUntcodeLink.Visible = false;
        LblUnitType.Visible = false;
        LblUnitName1.Visible = false;

        //trStaffLink.Visible = false;
        lbluntSalesChnl.Visible = false;
        lbluntSalesChnlDesc.Visible = false;
        lbluntSubChnl.Visible = false;
        lbluntSubChnlDesc.Visible = false;
        lblAgntType.Visible = false;
        LblAgentType.Visible = false;
        LblAgentName.Visible = false;
        #endregion

        #region Basic Labels
        lblUntCode.Text = olng.GetItemDesc("lblUntCode.Text");
        lblUnitStatus.Text = olng.GetItemDesc("lblUnitStatus.Text");
        lblSalesUnt.Text = olng.GetItemDesc("lblSalesUnt.Text");
        lblUntMgrCode.Text = olng.GetItemDesc("lblUntMgrCode.Text");
        lblUntDesc1.Text = olng.GetItemDesc("lblUntDesc1.Text");
        lblUntDesc2.Text = olng.GetItemDesc("lblUntDesc2.Text");
        lblCmpUntCode.Text = olng.GetItemDesc("lblCmpUntCode.Text");
   //     lblLocCode.Text = olng.GetItemDesc("lblLocCode.Text");
        lblUntDesc3.Text = olng.GetItemDesc("lblUntDesc3.Text");
        lblCity.Text = olng.GetItemDesc("lblCity.Text");
        lblOffTel.Text = olng.GetItemDesc("lblOffTel.Text");
        lblAddress.Text = olng.GetItemDesc("lblAddress.Text");
        lblFax.Text = olng.GetItemDesc("lblFax.Text");
        lblPostCode.Text = olng.GetItemDesc("lblPostCode.Text");
        lblEmail.Text = olng.GetItemDesc("lblEmail.Text");
        #endregion

        #region New Lables
        lblAgentsTitle.Text = olng3.GetItemDesc("lblAgentsTitle");
        lblUntType.Text = olng3.GetItemDesc("lblUntType");
        lbl_CeaseDate.Text = olng3.GetItemDesc("lbl_CeaseDate");
        lbl_CeaseRemark.Text = olng3.GetItemDesc("lbl_CeaseRemark");
        lbl_CeaseReason.Text = olng3.GetItemDesc("lbl_CeaseReason");
        lblarea.Text = olng3.GetItemDesc("lblarea");
        lblUnitCeaseTitle.Text = olng3.GetItemDesc("lblUnitCeaseTitle");
        lblUntCnctI.Text = olng3.GetItemDesc("lblUntCnctI");
        lblLocn.Text = olng3.GetItemDesc("lblLocn");
        lblDistP.Text = olng3.GetItemDesc("lblDistP");
        lblChnnlSubClass.Text = olng3.GetItemDesc("lblChnnlSubClass");
        lblSalesChnl.Text = olng3.GetItemDesc("lblSalesChnl");
        lblrptunitcode.Text = olng3.GetItemDesc("lblrptunitcode");
        lblRptUnitCodeMgr1.Text = olng3.GetItemDesc("lblrptunitcode");
        lblrefcode.Text = olng3.GetItemDesc("lblrefcode");
        lblVillage.Text = olng3.GetItemDesc("lblVillage");
        lblcityp.Text = olng3.GetItemDesc("lblcityp");
        lblpfAddrP1.Text = olng3.GetItemDesc("lblpfAddrP1");
        lblpfAddrP2.Text = olng3.GetItemDesc("lblpfAddrP1")+"2";
        lblpfAddrP3.Text = olng3.GetItemDesc("lblpfAddrP1")+"3";
        lblpfStateP.Text = olng3.GetItemDesc("lblpfStateP");
        lblpfPinP.Text = olng3.GetItemDesc("lblpfPinP");
        lblpfCountryP.Text = olng3.GetItemDesc("lblpfCountryP");
        LblBizsrc.Text = olng3.GetItemDesc("LblBizsrc");
        lbluntSalesChnl.Text = olng3.GetItemDesc("LblBizsrc");
        LblSubclass.Text = olng3.GetItemDesc("LblSubclass");
        lbluntSubChnl.Text = olng3.GetItemDesc("LblSubclass");
        lblAgntType.Text = olng3.GetItemDesc("lblAgntType");
        LblAgentName.Text = olng3.GetItemDesc("LblAgentName");
        LblUntcodeLink.Text = olng3.GetItemDesc("LblUntcodeLink");
        lblUnitName.Text = olng3.GetItemDesc("LblUnitName");
        lblLatitude.Text = olng3.GetItemDesc("lblLatitude");
        lblLongitude.Text = olng3.GetItemDesc("lblLongitude");
        lblAddlMRptTyp2.Text = olng3.GetItemDesc("lblAddlMRptTyp2");
        lblAddlMChnl2.Text = olng3.GetItemDesc("lblAddlMChnl2");
        lblAMLvlAgtTyp2.Text = olng3.GetItemDesc("lblAMLvlAgtTyp2");
#endregion

        #region reporting manager details
        lblPrReptDtls.Text = (olng2.GetItemDesc("lblPrReptDtls.Text"));
        lblddlreportingtype.Text = (olng2.GetItemDesc("lblddlreportingtype.Text"));
        lblPrichannel.Text = (olng2.GetItemDesc("lblchannel.Text"));
        lblPrisubchannel.Text = (olng2.GetItemDesc("lblsubchannel.Text"));
        lblAddlMSubCls2.Text = (olng2.GetItemDesc("lblsubchannel.Text"));
        lblPribasedon.Text = (olng2.GetItemDesc("lblbasedon.Text"));
        lblAddlMBsdOn2.Text = (olng2.GetItemDesc("lblbasedon.Text"));
        lblPrilevelagttype.Text = (olng2.GetItemDesc("lbllevelagttype.Text"));
        lbladditionalreporting.Text = (olng2.GetItemDesc("lbladditionalreporting.Text"));
        lblAddlRDtls.Text = (olng2.GetItemDesc("lblAddlRDtls.Text"));
        lblAddlMRptTyp.Text = (olng2.GetItemDesc("lblAddlMRptTyp.Text"));
        lblAddlMChnl.Text = (olng2.GetItemDesc("lblAddlMChnl.Text"));
        lblAddlMSubCls.Text = (olng2.GetItemDesc("lblAddlMSubCls.Text"));
        lblAddlMBsdOn.Text = (olng2.GetItemDesc("lblAddlMBsdOn.Text"));
        lblAMLvlAgtTyp.Text = (olng2.GetItemDesc("lblAMLvlAgtTyp.Text"));
        lbladditionalmangr1.Text = (olng2.GetItemDesc("lbladditionalmangr1.Text"));
        lbladditionalmangr2.Text = (olng2.GetItemDesc("lbladditionalmangr2.Text"));
        lblRptRule.Text = (olng2.GetItemDesc("lblRptRule.Text"));
        #endregion
    }
    #endregion

    #region METHOD Fill All Detail Labels
    protected void fillDetailLabels()
    {
                string strChnCrtRul = String.Empty;
                dsResult = new DataSet();
                dsResult.Clear();
                htable.Clear();
                htable.Add("@CarrierCode", Convert.ToString(Session["CarrierCode"]));
                htable.Add("@LanguageCode", Convert.ToString(Session["LanguageCode"]));
                htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
                htable.Add("@ChnnlSubCls", Request.QueryString["SubCls"]);
                dsResult = objDAL.GetDataSetForPrc("prc_EnqUnitMaintenance", htable);
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsResult.Tables[0].Rows[0]["IsSlsUnit"].ToString() != "")
                        {
                            if (Convert.ToBoolean(dsResult.Tables[0].Rows[0]["IsSlsUnit"]) == false)
                            {
                                rdlYesNo.SelectedValue = "N";
                            }
                            else
                            {
                                rdlYesNo.SelectedValue = "Y";
                            }
                        }
                        lblValRptUntCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["RptUnitDESC"]);
                        lblValUnitName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc"]);
                        lblValUnitStat.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitStatusDesc"]).ToUpper();
                        Session["UnitStatus"]  = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitStatus"]).ToUpper();
                        lblSalesChannel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChannelDesc_Bizsrc"]);
                        lblValUntDesc1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc01"]);
                        lblValUntDesc2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc02"]);
                        lblValUntDesc3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitDesc03"]);
                        lblValCompanyUnitCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]);
                        lblValCity.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["City"]);
                        lblValOTel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkTel"]);
                        lblValAddress1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr1"]);
                        lblValAddress2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr2"]);
                        lblValAddress3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr3"]);
                        lblValFax.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["WorkFax"]);
                        lblValPOstCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PostCode"]);
                        lblValEMail.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Email"]);
                        lblValChnSubclass.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["ChannelDesc"]);
                        lblValUnitType.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitTypeDesc"]);
                        lblValUnitMGRCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["UnitMgrCode"]);
                      //  lblVal.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LinkUnitCode_Name"]);
                        lblValAgntName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["LinkStaffCode"]);
                        lblValInsRefCode.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["CmsUnitCode"]);
                        lblValAddrP1.Text =  Convert.ToString(dsResult.Tables[0].Rows[0]["Adr1"]).Replace("~","");
                        lblValAddrP2.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr2"]).Replace("~", "");
                        lblValAddrP3.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Adr3"]).Replace("~", "");
                        lblValVillage.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Village"]);
                        lblValcityp.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["City"]);

                        if (Convert.ToString(dsResult.Tables[0].Rows[0]["StateCode"]) == "0")
                            lblValState.Text = String.Empty;
                        else
                            lblValState.Text = setStateName(Convert.ToString(dsResult.Tables[0].Rows[0]["StateCode"])).ToUpper();

                        lblValDistP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["District"]);
                        lblValarea.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Area"]);
                        lblValPinP.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PostCode"]);
                        lblValLatitude.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Latitude"]);
                        lblValLongitude.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Longitude"]);

                        lblVallevelagttype.Text = GetLvlAgttypeDesc(Convert.ToString(dsResult.Tables[0].Rows[0]["RptUnitCode"]));
                        lblValam1levelagttype.Text = GetLvlAgttypeDesc(Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1RptUntCode"]));

                        lblValRptUnitCodeMgr1.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1RptUntCodeDESC"]);
                        lblValbasedon.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryBsdOnDESC"]);
                        lblValam1basedon.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1BsdOnDESC"]);
                        lblValam2basedon.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2BsdOnDESC"]);

                        lblValreportingtype.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryReportingTypeDESC"]);
                        lblValam1reportingtype.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1ReportingTypeDESC"]);

                        lblValchannel.Text  = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimaryChannelDESC"]);
                        lblValsubchannel.Text  = Convert.ToString(dsResult.Tables[0].Rows[0]["PrimarySubChannelDESC"]);

                        lblValam1channel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1ChannelDESC"]);
                        lblValam1subchannel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl1SubChannelDESC"]);

                        lblValam2channel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2ChannelDESC"]);
                        lblValam2subchannel.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["Addl2SubChannelDESC"]);

                        var MgrCnt = dsResult.Tables[0].Rows[0]["AddlRelRule"].ToString();
                        if (MgrCnt == "0")
                        {
                            lbladditionalrptdesc.Text = "Multiple - 1";
                            //tblMgr1.Visible = true;
                        }
                        else
                        {
                           // tblMgr1.Visible = false;
                            lbladditionalrptdesc.Text = "No record(s) found.";
                        }
                    
                        if (lblValRptUnitCodeMgr1.Text == String.Empty ) //Handles the event when the Additional Manager is Not applicable or assigned
                        {
                            lnkCrntAddlMgr.Enabled = false;
                        }
                    }  
               }
    #endregion

    #region BUTTON btnCancel Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["UnitStatus"] = null;
        
        if (Request.QueryString["TPBizSrc"] == null)
        {
            Response.Redirect("UnitCeasure.aspx?ChannelCode=" + Request.QueryString["ChannelCode"] + "&ULevel=" + Request.QueryString["ULevel"] + "&UnitCode=" + Request.QueryString["UnitCode"] + "&fgPage=C" + "&RptUntCode=" + Request.QueryString["RptUntCode"] + "&SubCls=" + Request.QueryString["SubCls"]);
        }
        else
        {
            Response.Redirect("UnitCeasure.aspx?BizSrc=" + Request.QueryString["ChannelCode"] + "&ChannelCode=" + Request.QueryString["ChannelCode"] + "&ULevel=" + Request.QueryString["ULevel"] + "&UnitCode=" + Request.QueryString["UnitCode"] + "&fgPage=C" + "&RptUntCode=" + Request.QueryString["RptUntCode"] + "&SubCls=" + Request.QueryString["SubCls"] + "&ChnCls=" + Request.QueryString["TPChnCls"]);
        }
    }
    #endregion 

    #region BUTTON Cease Click
    protected void btnCease_Click(object sender, EventArgs e)
    {
        if (ddlCeaseReason.SelectedItem.Text != "Select" || txtRemark.Text != String.Empty)
        {
            if (Session["UnitStatus"].ToString() == "IF")
            {
                try
                {
                    //Validate
                    htable.Clear();
                    htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
                    htable.Add("@ChnCls", Request.QueryString["SubCls"]);
                    htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
                    htable.Add("@CeaseReason", ddlCeaseReason.SelectedValue.ToString());
                    htable.Add("@Remarks", txtRemark.Text);
                    htable.Add("@UpdatedBy", Session["UserId"].ToString());

                    if (blnFlag == false)//Agents are not present
                    { htable.Add("@Flag", 0); }
                    else                            //Agents are present
                    { htable.Add("@Flag", 1); }

                    int errStatus = objDAL.execute_sprc("prc_CeaseUnit", htable);

                    switch (errStatus)
                    {
                        case -1:
                            //Cannot Cease Unit as Manager is active 
                            //lbl3.Text = "Could not cease this unit!";
                            //lbl3.Font.Bold = true;
                            //lbl4.Text = "Cannot cease unit as its members are active.";
                            //lbl5.Text = String.Empty;
                            lbl_popup.Text = "Could not cease this unit!<br /><br />" + "Cannot cease unit as its members are active.";
                          //  mdlpopup.Show();
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                            btnCancel.Text = "Close";
                            btnCease.Enabled = false;
                            break;
                        
                        case 1:
                            //Success
                            //lbl3.Text = "Success!";
                            //lbl3.Font.Bold = true;
                            //lbl4.Text = "Unit ceased successfully";
                            //lbl5.Text = String.Empty;
                            lbl_popup.Text = "Success!<br /><br />" + "Unit ceased successfully.";
                           // mdlpopup.Show();
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
                            //Help the user to close the popup window
                            btnCancel.Text = "Close";
                            btnCease.Enabled = false;
                            break;
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
            else
            {
                //Cannot Cease Unit as it is already ceased 
                //lbl3.Text = "Could not cease this unit!";
                //lbl3.Font.Bold = true;
                //lbl4.Text = "This unit is already Ceased.";
                //lbl5.Text = String.Empty;
                lbl_popup.Text = "Could not cease this unit!<br /><br />" + "This unit is already Ceased.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
               // mdlpopup.Show();
                btnCancel.Text = "Close";
                btnCease.Enabled = false;
            } 
        }
        else
        {
            if (ddlCeaseReason.SelectedIndex == 0)
            {
                //Validation Error 
                //lbl3.Text = "Cannot Cease Unit!";
                //lbl3.Font.Bold = true;
                //lbl4.Text = "Cannot cease unit as the mandatory cease reason is not chosen.";
                //lbl5.Text = String.Empty;
                lbl_popup.Text = "Cannot Cease Unit!<br /><br />" + "Cannot cease unit as the mandatory cease reason is not chosen.";
               // ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
            }
            else if(txtRemark.Text == String.Empty)
            {
                //Validation Error 
                //lbl3.Text = "Cannot Cease Unit!";
                //lbl3.Font.Bold = true;
                //lbl4.Text = "Cannot cease unit as the mandatory cease remark is not entered.";
                //lbl5.Text = String.Empty;
                lbl_popup.Text = "Cannot Cease Unit!<br /><br />" + "Cannot cease unit as the mandatory cease remark is not entered.";
            }
            else
            {
                //Validation Error 
                //lbl3.Text = "Cannot Cease Unit!";
                //lbl3.Font.Bold = true;
                //lbl4.Text = "Cannot cease unit as both the mandatory cease reason and remarks are left blank!";
                //lbl5.Text = String.Empty;
                lbl_popup.Text = "Cannot Cease Unit!<br /><br />" + "Cannot cease unit as both the mandatory cease reason and remarks are left blank!";
            }
            //mdlpopup.Show();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "popup();", true);
        }
        btnCease.Focus();
    }
    #endregion

    #region METHOD Get State Name
    protected string setStateName(string strCode)
    {
        String Name = String.Empty;
        DataSet DS = new DataSet();
        Hashtable HT = new Hashtable();
        DS.Clear();
        HT.Clear();
        HT.Add("@StateID",strCode);
        DS = objDAL.GetDataSetForPrc_inscdirect("prc_GetStatebyCode",HT);
        if(DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0) 
        {
        Name = Convert.ToString(DS.Tables[0].Rows[0]["StateName"]);
        }
        else
    	{
         Name = String.Empty;
	    }
        DS.Clear();
        HT.Clear();
        return Name;
    }
    #endregion

    #region Tab Primary Manager Click EVENT
    protected void lnkCrntPrimMgr_Click(object sender, ImageClickEventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
       // btnUnitContactDtlscollapse.Value = "+";

        //MultiViewCrnt.ActiveViewIndex = 0;

        lnkCrntAgentDetails.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng_hover.png";
        lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng.png";
    }
    #endregion
    
    #region Tab Addl Manager Click EVENT
    protected void lnkCrntAddlMgr_Click(object sender, ImageClickEventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
       // btnUnitContactDtlscollapse.Value = "+";

      //  MultiViewCrnt.ActiveViewIndex = 1;

        lnkCrntAgentDetails.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng_hover.png";
        lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails.png";
        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng.png";
    }
    #endregion

    #region Tab Member Details Click EVENT
    protected void lnkCrntAgentDetails_Click(object sender, EventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
       // btnUnitContactDtlscollapse.Value = "+";
      
        //MultiViewCrnt.ActiveViewIndex = 2;

        lnkCrntAgentDetails.BackColor = Color.Transparent;
        lnkCrntPrimMgr.BackColor = Color.Transparent;
        lnkCrntAddlMgr.BackColor = Color.Transparent;

        lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng.png";
        lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails_hover.png";
        lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng.png";    
    }
    #endregion

    #region METHOD fill Member Details Gridview
    protected void fillUnitsAgents()
    {
        try
        {
            dsResult = new DataSet();
            dsResult.Clear();
            htable.Clear();
            htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
            htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
            htable.Add("@ChnCls", Request.QueryString["SubCls"]);
            dsResult = objDAL.GetDataSetForPrc("prc_GetUnitManagerAgentStatus", htable);
            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {//Members are present
                blnFlag = true;
                gv_AgentDtls.DataSource = dsResult;
                ViewState["gv"] = dsResult.Tables[0];
                gv_AgentDtls.DataBind();
                lblAgentDetailMsg.Visible = false;
                divPage.Visible = true;
                #region Commented code 
                ////Cannot Cease Unit as Manager is active 
                //lbl3.Text = "Unit has Members!";
                //lbl3.Font.Bold = true;
                //lbl4.Text = "You cannot cease unit as its members are active.";
                //lbl5.Text = String.Empty;

                //mdlpopup.Show();
                //btnCancel.Text = "Close";
                //btnCease.Enabled = false;
                #endregion
            }
            else
            {//Members are absent
                blnFlag = false;
                lblAgentDetailMsg.Visible = true;
                
                #region Commented Code
                //btnCease.Enabled = true;
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
    #endregion

    #region GridView EVENTS and its methods
    protected void gv_AgentDtls_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;

            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable ds = ViewState["gv"] as DataTable;
            DataView dv = new DataView(ds);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();

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

    protected void gv_AgentDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataTable dt = GetDataTable();
            DataView dv = new DataView(dt);
            GridView gv_AgentDtls = (GridView)sender;

            gv_AgentDtls.PageIndex = e.NewPageIndex;
            dv.Sort = gv_AgentDtls.Attributes["SortExpression"];

            if (gv_AgentDtls.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            gv_AgentDtls.DataSource = dv;
            gv_AgentDtls.DataBind();
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
    
    protected DataTable GetDataTable()
{
        dsResult = new DataSet();
        dsResult.Clear();
        htable.Clear();
        htable.Add("@BizSrc", Request.QueryString["ChannelCode"]);
        htable.Add("@UnitCode", Request.QueryString["UnitCode"]);
        htable.Add("@ChnCls", Request.QueryString["SubCls"]);
        dsResult = objDAL.GetDataSetForPrc("prc_GetUnitManagerAgentStatus", htable);
        if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
        {
            gv_AgentDtls.DataSource = dsResult;
            gv_AgentDtls.DataBind();
        }
          return dsResult.Tables[0];
  }
    #endregion

    #region METHOD Relation Type Description
    protected String GetLvlAgttypeDesc(string rptUnitCode)
    {
        String strDesc = String.Empty;
        DataSet DT= new DataSet();
        Hashtable HT = new Hashtable();

        if (rptUnitCode != String.Empty)
        {
            DT.Clear();
            HT.Clear();
            HT.Add("@BizSrc", Request.QueryString["ChannelCode"]);
            HT.Add("@ChnCls", Request.QueryString["SubCls"]);
            HT.Add("@RptUnitCode",rptUnitCode );
            DT = objDAL.GetDataSetForPrc("prc_GetRptUntTypeDescription", HT);
            if (DT.Tables.Count > 0 && DT.Tables[0].Rows.Count > 0)
            {
                strDesc = Convert.ToString(DT.Tables[0].Rows[0]["UnitDesc01"]);
            }
            DT.Clear();
            HT.Clear(); 
        }

        return strDesc;
    }
    #endregion



    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex - 1;
            //dgDetails.DataSource = (DataTable)Session["grid"];
            //dgDetails.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            //if (txtPage.Text == "1")
            //{
            //    btnprevious.Enabled = false;
            //}
            //else
            //{
            //    btnprevious.Enabled = true;
            //}
            //btnnext.Enabled = true;


            int pageIndex = gv_AgentDtls.PageIndex;
            gv_AgentDtls.PageIndex = pageIndex - 1;
            GetDataTable();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv_AgentDtls.PageCount))
            {
                btnprevious.Enabled = false;
            }
            int page = gv_AgentDtls.PageCount;
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
            //int pageIndex = dgDetails.PageIndex;
            //dgDetails.PageIndex = pageIndex + 1;
            //// dgCntst.DataSource = (DataTable)Session["grid"];
            //// dgCntst.DataBind();
            //txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            //btnprevious.Enabled = true;
            //if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            //{
            //    btnnext.Enabled = false;
            //}

            //int page = dgDetails.PageCount;

            int pageIndex = gv_AgentDtls.PageIndex;
            gv_AgentDtls.PageIndex = pageIndex + 1;
            GetDataTable();
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gv_AgentDtls.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gv_AgentDtls.PageCount;
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

    #region Tab Primary Manager Click EVENT
    protected void Primary_Click(object sender,EventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
        divmember.Attributes.Add("style", "display:none");
        divadditional.Attributes.Add("style", "display:none");
        divprimary.Attributes.Add("style", "display:block");
        Primary.CssClass = "btn-subtab btn btn-default";
        Additional.CssClass = "btn btn-default";
        Member.CssClass = "btn btn-default";
        // btnUnitContactDtlscollapse.Value = "+";

        ////MultiViewCrnt.ActiveViewIndex = 0;

        //lnkCrntAgentDetails.BackColor = Color.Transparent;
        //lnkCrntPrimMgr.BackColor = Color.Transparent;
        //lnkCrntAddlMgr.BackColor = Color.Transparent;

        //lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng_hover.png";
        //lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails.png";
        //lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng.png";
    }
    #endregion

    #region Tab Addl Manager Click EVENT
    protected void Additional_Click(object sender, EventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
        divadditional.Attributes.Add("style", "display:block");
        divprimary.Attributes.Add("style", "display:none");
        divmember.Attributes.Add("style", "display:none");
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = " btn-subtab btn btn-default";
        Member.CssClass = "btn btn-default";
        // btnUnitContactDtlscollapse.Value = "+";

        //MultiViewCrnt.ActiveViewIndex = 1;

        //lnkCrntAgentDetails.BackColor = Color.Transparent;
        //lnkCrntPrimMgr.BackColor = Color.Transparent;
        //lnkCrntAddlMgr.BackColor = Color.Transparent;

        //lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng_hover.png";
        //lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails.png";
        //lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng.png";
    }
    #endregion

    #region Tab Member Details Click EVENT
    protected void Member_Click(object sender, EventArgs e)
    {
        div_UnitContact.Attributes.Add("style", "display:none");
        divmember.Attributes.Add("style", "display:block");
        divadditional.Attributes.Add("style", "display:none");
        divprimary.Attributes.Add("style", "display:none");
        Primary.CssClass = "btn btn-default";
        Additional.CssClass = "btn btn-default";
        Member.CssClass = "btn-subtab btn btn-default";
        divPage.Visible = false;
        // btnUnitContactDtlscollapse.Value = "+";

        //MultiViewCrnt.ActiveViewIndex = 2;

        //lnkCrntAgentDetails.BackColor = Color.Transparent;
        //lnkCrntPrimMgr.BackColor = Color.Transparent;
        //lnkCrntAddlMgr.BackColor = Color.Transparent;

        //lnkCrntPrimMgr.ImageUrl = "~/theme/iflow/PrimRptng.png";
        //lnkCrntAgentDetails.ImageUrl = "~/theme/iflow/MemberDetails_hover.png";
        //lnkCrntAddlMgr.ImageUrl = "~/theme/iflow/AddlRptng.png";
    }
    #endregion

}
  
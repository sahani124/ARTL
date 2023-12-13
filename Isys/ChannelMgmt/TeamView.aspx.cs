using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using Telerik.Web.UI;






public partial class Application_ISys_ChannelMgmt_TeamView : BaseClass
{

    #region DECLARE VARIABLES
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    string Flag1;
    private multilingualManager olng;
    private string strUserLang;
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    Hashtable httable = new Hashtable();
    ErrLog objErr = new ErrLog();
    private bool isDrillDown = false;

    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    #endregion




    #region PAGE_LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            strUserLang = HttpContext.Current.Session["UserLangNum"].ToString();

            olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
            Session["CarrierCode"] = '2';
            SqlDataReader dtRead;
            ddlAgntStatus.Enabled = false;
            ddlPosition.Enabled = false;
            if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
            {
                ddlUnits.Enabled = true; ;
            }
            else
            {
                ddlUnits.Enabled = false;
            }

            Panel3.Visible = false;
            iFrame2.Visible = false;
            Div2.Visible = false;
            // ddlAgntType_SelectedIndexChanged(this, EventArgs.Empty);


            //                btnAdvCollapse.Attributes.Add("onclick", "ShowReqDtl('ctl00_ContentPlaceHolder1_divAgtAdvSearch','ctl00_ContentPlaceHolder1_btnAdvCollapse')");
            //if (txtSapCode.Text != "")
            //{
            //    divAgtBasicSearch.Attributes.Add("style", "display:block");
            //    //btnBasicCollapse.Value = "-";
            //}
            
            if (!IsPostBack)
            {
                //divAgtBasicSearch.Visible = false;
                //btnBasicCollapse.Value = "+";

                EnableDisableButton();
                string UserId = Session["UserID"].ToString();

                if (Session["LanguageCode"] == null)
                {
                    Session["LanguageCode"] = "eng";
                }
                InitializeControl();
                oCommon.getDropDown(ddlAgntStatus, "agtsts", Convert.ToInt32(Session["UserLangNum"].ToString()), "", 1);

                if (Request["Type"] != null)
                {
                    if (Request["Type"].ToString() == "N")
                    {
                        ViewState["vwsType"] = "N";
                    }
                    else
                    {
                        ViewState["vwsType"] = "" + "E";

                    }
                }
                else
                {
                    ViewState["vwsType"] = "E";
                }
                //trDetails.Visible = false;
                trDgDetails.Visible = false;

                //Added by Prathamesh on 9-12-15 start



                //httable.Add("@RptMgrSapCode", txtMgrSapCode.Text);
                //dsResult = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", httable);


                //ddlSlsChnnl.SelectedValue = dsResult.Tables[0].Rows[0][0].ToString();
                //ddlChnCls.SelectedValue = dsResult.Tables[0].Rows[0][1].ToString();
                //ddlAgntType.SelectedValue = dsResult.Tables[0].Rows[0][2].ToString();

                //ddlSlsChnnl.DataTextField=dsResult.Tables[0].Columns["Bizsrc"].ToString();
                //ddlSlsChnnl.DataValueField = dsResult.Tables[0].Columns["Bizsrc"].ToString();

                //ddlSlsChnnl.DataSource = dsResult.Tables[0];
                //ddlSlsChnnl.DataBind();




                //dtddlRead = dataAccess.Common_exec_reader_prc_common("Prc_GetUnitTypeForAgtSearch", htParam);
                //if (dtddlRead.HasRows)
                //{
                //    ddl.DataSource = dtddlRead;////ddlUnitType
                //    ddl.DataTextField = "UnitDesc";
                //    ddl.DataValueField = "UnitType";
                //    ddl.DataBind();
                //}
                //ddl.Items.Insert(0, new ListItem("-- Select --", ""));



                ddlAgntStatus.Items.Insert(0, new ListItem("All", "All"));
                //ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
                ddlChnCls.Items.Insert(0, new ListItem("All", "All"));





                //Added by Prathamesh on 9-12-15 end

                txtPAN.Attributes.Add("onblur", "Javascript:return ValidationPAN();");
                if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
                {
                    ddlUnits.Enabled = true;
                    if (ViewState["vwsType"].ToString() == "N")
                    {
                        oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "");
                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                    else
                    {
                        oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, UserId.ToString(), "");
                        ddlSlsChnnl.Enabled = true;
                        ddlSlsChnnl.Visible = true;
                    }
                }

                ddlSlsChnnl.Items.Insert(0, new ListItem("All", "All"));
                //oCommonU.FillNoOfRecDropDown(ddlShwRecrds);
                ddlShwRecrds.Items.Insert(0, new ListItem("50", ""));
                ddlShwRecrds.Enabled = false;
               // trCDAHierarchy.Visible = false;
                CDACheck.Checked = false;
                //}









                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"].ToString().ToUpper().Trim() == "IN")
                    {
                        ddlAgntStatus.SelectedValue = "IF";
                        ddlPosition.SelectedIndex = 2;
                    }
                }

                lblSourceName.Visible = false;
                //Added by Rachana on 14/05/2013 for showing popup on Page_load start
                btnUnitCode.Attributes.Add("onclick", "funcShowPopup('unitcode');return false;");
                //Added by Rachana on 14/05/2013 for showing popup on Page_load end
                CDACheck.Attributes.Add("onClick", "Javascript: return CheckAgtTypeForCDA();");
                //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist start
                oCommonU.GetRptType(ddlRptTyp);
                iFrame2.Attributes.Add("src", "../../Hierarchy/EmpHierarchy.aspx?Type=POP&AgtCode=" + txtImmLeaderCode.Text + " &Flag=P");




                //Added By Prathamesh 10-12-15 start
                if (HttpContext.Current.Session["UserId"].ToString() != "systemadmin")
                {
                    //ddlAgntStatus.SelectedValue = "IF";
                    //ddlAgntStatus.Enabled = false;
                    //ddlPosition.SelectedValue = "2";
                    //ddlPosition.Enabled = false;

                    txtMgrSapCode.Enabled = false;
                    txtAgntCode.Enabled = false;

                    string ID = HttpContext.Current.Session["UserId"].ToString();

                    txtMgrSapCode.Text = ID;

                    txtMgrSapCode.Enabled = false;

                    //Added this function for multiple channels employee
                    //DataSet dsChn = GetChannel(ddlSlsChnnl, 1);
                    //if (dsChn.Tables[0].Rows.Count > 1)
                    //{
                    //    MultiChannel();
                    //}
                    //else 
                    //{
                    //    Flag1 = "2";
                    //}

                    MultiChannel();
                    httable.Clear();
                    if (Flag1 != "1")
                    {
                    
                        httable.Add("@flag", 1);
                        httable.Add("@RptMgrSapcode", txtMgrSapCode.Text);
                        dsResult = dataAccess.GetDataSetForPrc("prc_TeamView_EnqMgrList", httable);
                        string strChncls = dsResult.Tables[0].Rows[0]["chncls"].ToString();
                        strChncls = strChncls.Substring(2);
                        //ddlRptTyp.Items.Remove(ddlRptTyp.Items[2]);
                        //if (strChncls == "LM" || strChncls == "XX")
                        //{
                        //    ddlRptTyp.Items.Remove(ddlRptTyp.Items[1]);

                        //}



                        txtImmLeaderCode.Text = dsResult.Tables[0].Rows[0][0].ToString();
                        txtImmLeaderCode.Enabled = false;

                        
                    }

                   

                    
                    else
                    {

                      
                        txtAgntCode.Enabled = true;
                        txtMgrSapCode.Enabled = true;
                        txtImmLeaderCode.Enabled = false;

                      

                    }
                }

                //Added By Prathamesh 10-12-15 end

                //if (ddlRptTyp.Items.Count != 1)
                //{

                if (ddlRptTyp.Items.Count > 1)
                {
                    ddlRptTyp.Items.Insert(0, new ListItem("All", "All"));
                }

                else
                {

                    DataSet dsChn = GetChannel(ddlSlsChnnl, 1);



                    if (dsChn.Tables[0].Rows.Count > 0)
                    {
                        if (dsChn.Tables[0].Rows[0]["Bizsrc"].ToString() == "XX")
                        {

                            rdbChnlTyp.SelectedValue = "0";
                            rdbChnlTyp.Items.FindByValue("1").Enabled = false;
                            rdbChnlTyp.Items.FindByValue("0").Enabled = true;
                            oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");


                            if (ddlChnCls.Items.Count > 1)
                            {
                                //ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));
                            }

                            if (ddlSlsChnnl.Items.Count > 1)
                            {
                                ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--", "All"));

                            }

                            else
                            {
                                if (ddlRptTyp.SelectedIndex == 1)
                                {
                                    DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
                                }

                                else
                                {
                                    DataSet dsChncls = GetSubChannel(ddlChnCls, 4);
                                }


                                // ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));

                            }

                            DataSet dsEmpType = new DataSet();
                            dsEmpType = GetEmpType(ddlAgntType, 5);
                            DataSet ds1 = GetRptUnitType1(ddlUnits, 9);
                            DataSet ds = GetRptUnitType(ddlUnitType, 8);

                            Hashtable htParam = new Hashtable();

                            DataSet dsUnit = new DataSet();



                            htParam.Clear();

                            //htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
                            /////htParam.Add("@RptType", ddlRptTyp.SelectedValue);
                            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
                            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                            htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
                            htParam.Add("flag", 11);

                            dsUnit = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

                            //ddlUnitType.DataSource = dsUnit;
                            //ddlUnitType.DataTextField = "UnitDesc01";
                            //ddlUnitType.DataValueField = "Unittype";
                            //ddlUnitType.DataBind();
                            
                            
                            //if (ddlUnitType.Items.Count > 1)
                            //{
                            //    ddlUnitType.Items.Insert(0, new ListItem("All", ""));
                            //}


                            //ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

                        }
                        else
                        {
                            rdbChnlTyp.SelectedValue = "1";
                            rdbChnlTyp.Items.FindByValue("0").Enabled = false;
                            rdbChnlTyp.Items.FindByValue("1").Enabled = true;
                            oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");


                            if (ddlChnCls.Items.Count > 1)
                            {
                                //ddlChnCls.Items.Insert(0, new ListItem("--Select--","All"));
                            }

                            if (ddlSlsChnnl.Items.Count > 1)
                            {
                                ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--","All"));

                            }

                            else
                            {

                                DataSet dsChncls = GetSubChannel(ddlChnCls, 3);


                                //ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));

                            }


                            DataSet dsEmpType = new DataSet();
                            dsEmpType = GetEmpType(ddlAgntType, 5);
                            DataSet ds1 = GetRptUnitType1(ddlUnits, 9);
                            DataSet ds = GetRptUnitType(ddlUnitType, 8);

                            Hashtable htParam = new Hashtable();

                            DataSet dsUnit = new DataSet();



                            htParam.Clear();

                            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
                            ///htParam.Add("@RptType", ddlRptTyp.SelectedValue);
                            //htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
                            //htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                            if (ddlSlsChnnl.SelectedValue != "All")
                            {
                                htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
                            }

                            if (ddlChnCls.SelectedValue != "All")
                            {
                                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                            }
                           
                            if (ddlChnCls.SelectedValue != "All")
                            {
                                htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
                            }
                            //htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
                            htParam.Add("flag", 11);

                            dsUnit = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

                            //ddlUnitType.DataSource = dsUnit;
                            //ddlUnitType.DataTextField = "UnitDesc01";
                            //ddlUnitType.DataValueField = "Unittype";
                            //ddlUnitType.DataBind();

                            //if (ddlUnitType.Items.Count > 1)
                            //{
                            //    ddlUnitType.Items.Insert(0, new ListItem("All", ""));
                            //}



                            //ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

                        }

                    }

                }
            }

            iFrame2.Attributes.Add("src", "../../Hierarchy/EmpHierarchy.aspx?Type=POP&AgtCode=" + txtImmLeaderCode.Text + " &Flag=P");


            //}
            //Added by swapnesh on 17/12/2013 to fill reporting type dropdownlist end
            //Added by swapnesh on 12/12/2013 to add functionality of tabs start
            lnkTab1.BackColor = System.Drawing.Color.LightYellow;
            lnkTab2.BackColor = System.Drawing.Color.Transparent;
            lnkTab3.BackColor = System.Drawing.Color.Transparent;
            lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee1.png";
            lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
            lnkTab3.ImageUrl = "~/theme/iflow/tabs/Other2.png";
            olng = new multilingualManager("DefaultConn", "AGTSearchTab2.aspx", strUserLang);
            InitializeControl();
            hdnAgentRole.Value = "E";

            //Added By Prathamesh 10-12-15 start
            if (Request.QueryString["Role"] != null)
            {
                if (Request.QueryString["Role"].ToString() == "agt")
                {
                    lnkTab1.BackColor = System.Drawing.Color.Transparent;
                    lnkTab2.BackColor = System.Drawing.Color.LightYellow;
                    lnkTab3.BackColor = System.Drawing.Color.Transparent;
                    lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent1.png";
                    lnkTab3.ImageUrl = "~/theme/iflow/tabs/Other2.png";
                    olng = new multilingualManager("DefaultConn", "AGTSearch.aspx", strUserLang);
                    InitializeControl();
                    hdnAgentRole.Value = "A";
                }
            }

            if (Request.QueryString["Role"] != null)
            {
                if (Request.QueryString["Role"].ToString() == "vendor")
                {
                    lnkTab1.BackColor = System.Drawing.Color.Transparent;
                    lnkTab2.BackColor = System.Drawing.Color.Transparent;
                    lnkTab3.BackColor = System.Drawing.Color.LightYellow;
                    lnkTab1.ImageUrl = "~/theme/iflow/tabs/Employee2.png";
                    lnkTab2.ImageUrl = "~/theme/iflow/tabs/Agent2.png";
                    lnkTab3.ImageUrl = "~/theme/iflow/tabs/Other1.png";
                    olng = new multilingualManager("DefaultConn", "AGTSearchTab3.aspx", strUserLang);
                    InitializeControl();
                    hdnAgentRole.Value = "V";
                }
            }
            //Added by swapnesh on 12/12/2013 to add functionality of tabs end


            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "IN")
                {
                   // trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Member Info-Edit";

                    if (Request.QueryString["Type"].ToString() == "I")
                    {
                        lnkTab1.Visible = false;
                        lnkTab3.Visible = false;
                    }
                    if (Request.QueryString["Type"].ToString() == "M")
                    {
                        lnkTab1.Visible = false;
                        lnkTab3.Visible = false;
                    }


                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "RIN")//--Change: Parag @ 20022014
                {
                    ddlAgntStatus.SelectedValue = "TR";
                    ddlAgntStatus.Enabled = false;
                    ddlUnits.Enabled = false;
                    lnkTab3.Visible = false;
                   // trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Reinstatement";
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "PR")
                {
                   // trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "Agent Promotion Request";
                    lnkTab3.Visible = false;
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    ddlUnits.Enabled = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                }
                ///added by akshay on 27/01/14 start
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRF")
                {
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    ddlUnits.Enabled = false;
                    //lnkTab3.Enabled = false;
                    lnkTab3.Visible = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                    lblSourceName.Text = "Member Tranfer Request";
                }
                //Added By SANDEEP GARG on 10/12/2013 START
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IRC")
                {
                   // trHead.Visible = true;
                    lblSourceName.Visible = true;
                    lblSourceName.Text = "View Agent For IRC";
                }
                //Added By SANDEEP GARG on 10/12/2013 END
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRM")
                {
                    //lnkTab3.Enabled = false;
                    lnkTab3.Visible = false;
                    ///ddlAgntStatus.SelectedIndex = 1;
                    ddlAgntStatus.SelectedValue = "IF";
                    ddlAgntStatus.Enabled = false;
                    ddlUnits.Enabled = false;
                    ddlPosition.SelectedValue = "2";
                    ddlPosition.Enabled = false;
                    lblSourceName.Text = "Member Termination Request";
                }
                else
                {
                   // trHead.Visible = false;
                    lblSourceName.Visible = false;
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


    //Added by Prathamesh 9-12-15 start 

    private DataSet GetChannel(DropDownList ddlSlsChnnl, int flag)
    {
        //ddlSlsChnnl.Items.Clear();
        DataSet ds;
        Hashtable htParam = new Hashtable();
        htParam.Clear();
        htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
        htParam.Add("@flag", flag);
        htParam.Add("@RptType", ddlRptTyp.SelectedValue);
        ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);



        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlSlsChnnl.DataSource = ds;
        //    ddlSlsChnnl.DataTextField = "Channel";
        //    ddlSlsChnnl.DataValueField = "Bizsrc";
        //    ddlSlsChnnl.DataBind();
        //    //ddlSlsChnnl.Items.Insert(0, "--Select--");
        //}


        return ds;

    }

    private DataSet GetEmpType(DropDownList ddlAgntType, int flag2)
    {
        ddlAgntType.Items.Clear();
        DataSet ds;
        Hashtable htParam = new Hashtable();
        htParam.Clear();

        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
            htParam.Add("@flag", flag2);
            if (ddlRptTyp.SelectedValue == "All")
            {
                htParam.Add("@RptType", "CF");
            }
            else
            {
                htParam.Add("@RptType", ddlRptTyp.SelectedValue);
            }

            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }

        else
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
            htParam.Add("@flag", flag2);
            htParam.Add("@RptType", ddlRptTyp.SelectedValue);
            //htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            //htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            if (ddlSlsChnnl.SelectedValue != "All")
            {
                htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            }

            if(ddlChnCls.SelectedValue != "All")
            {
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }

            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAgntType.DataSource = ds;////ddlUnitType
            ddlAgntType.DataTextField = "MemberTypedesc";
            ddlAgntType.DataValueField = "Memtype";
            ddlAgntType.DataBind();
        }


        if (ddlAgntType.Items.Count > 1)
        {
            ddlAgntType.Items.Insert(0, new ListItem("All", ""));
        }

        return ds;
    }

    private DataSet GetSubChannel(DropDownList ddlChnCls, int flag1)
     {
        ddlChnCls.Items.Clear();
        DataSet ds;
        Hashtable htParam = new Hashtable();
        htParam.Clear();
        htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
        htParam.Add("@flag", flag1);
        htParam.Add("@RptType", ddlRptTyp.SelectedValue);
        if (ddlSlsChnnl.SelectedValue != "All")
        {
            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
        }

       
        ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

        //htParam.Add("@BizSrc", ddlSlsChnnl.SelectedValue);
        //htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        //dtddlRead = dataAccess.Common_exec_reader_prc_common("Prc_GetUnitTypeForAgtSearch", htParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlChnCls.DataSource = ds;////ddlUnitType
            ddlChnCls.DataTextField = "SubClass";
            ddlChnCls.DataValueField = "Chncls";
            ddlChnCls.DataBind();
          
        }

        if (ddlChnCls.Items.Count > 1)
        {
            ddlChnCls.Items.Insert(0, new ListItem("--Select--", ""));
        }
      
        return ds;
        //ddlChnCls.Items.Insert(0, new ListItem("-- Select --", ""));

    }

    private DataSet GetRptUnitType(DropDownList ddlUnitType, int flag3)
    {
        ddlUnitType.Items.Clear();
        DataSet ds;
        Hashtable htParam = new Hashtable();
        htParam.Clear();

        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);

            if (ddlRptTyp.SelectedValue == "All")
            {
                htParam.Add("@RptType", "CF");
            }
            else
            {
                htParam.Add("@RptType", ddlRptTyp.SelectedValue);
            }

            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            htParam.Add("@EmpType", ddlAgntType.SelectedValue);
            htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
            htParam.Add("@flag", 7);
            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }

        else
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
            htParam.Add("@RptType", ddlRptTyp.SelectedValue);
           // htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
           // htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            if (ddlSlsChnnl.SelectedValue != "All")
            {
                htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            }

            if (ddlChnCls.SelectedValue != "All")
            {
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }

            //if (ddlAgntType.SelectedValue != "All")
            //{
            //    htParam.Add("@EmpType", ddlAgntType.SelectedValue);
            //}

            if (ddlUnits.SelectedValue != "All")
            {
                htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
            }

            //htParam.Add("@EmpType", ddlAgntType.SelectedValue);
            //htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
            htParam.Add("@flag", flag3);

            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlUnitType.DataSource = ds;
            ddlUnitType.DataTextField = "UnitTypedesc";
            ddlUnitType.DataValueField = "UnitType";
            ddlUnitType.DataBind();
        }

        if (ddlUnitType.Items.Count > 1)
        {
            ddlUnitType.Items.Insert(0, new ListItem("All", ""));
        }
        return ds;
    }

    private DataSet GetRptUnitType1(DropDownList ddlUnits, int flag4)
    {
        ddlUnits.Items.Clear();
        DataSet ds = new DataSet();

        Hashtable htParam = new Hashtable();
        htParam.Clear();


        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);

            if (ddlRptTyp.SelectedValue == "All")
            {
                htParam.Add("@RptType", "CF");
            }

            else
            {
                htParam.Add("@RptType", ddlRptTyp.SelectedValue);
            }

            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            htParam.Add("@flag", flag4);

            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }

        else
        {
            htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
            htParam.Add("@RptType", ddlRptTyp.SelectedValue);
           // htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
           // htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            if (ddlSlsChnnl.SelectedValue != "All")
            {
                htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            }

            if (ddlChnCls.SelectedValue != "All")
            {
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }

            htParam.Add("@flag", flag4);

            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlUnits.DataSource = ds;
            ddlUnits.DataValueField = "RptUnitType";


            ddlUnits.DataTextField = "RptUnitTypedesc";

            ddlUnits.DataBind();
        }

        if (ddlUnits.Items.Count > 1)
        {
            ddlUnits.Items.Insert(0, new ListItem("All", "All"));
        }

        return ds;
    }

    //Added by Prathamesh 9-12-15 end 

    #region BUTTON 'btnSearch' ONCLICK EVENT
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
               DataSet dsChn = GetChannel(ddlSlsChnnl, 1);

               if (dsChn.Tables[0].Rows.Count > 1)
               {
                   MultiChannel();
               }
         
           //tbDetails.Visible = true;
            //trDetails.Visible = false;
            lblAgtSrchRes.Visible = true;
            Panel3.Visible = false;
            iFrame2.Visible = false;




            //ddlAgntType_SelectedIndexChanged(this, EventArgs.Empty);
            //Added By Prathamesh 
            if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
            {
                if (ddlRptTyp.SelectedIndex != 0)
                {
                    if (txtImmLeaderCode.Text == null || txtMgrSapCode.Text == null)
                    {
                        lblMessage.Text = "Please Enter Reporting Manager code or Reporting Manager Sap code";
                    }
                }
            }
            DataSet dsUserType = new DataSet();

            Hashtable htParam1 = new Hashtable();
            //htParam1.Add("@RptMgrSapcode", Convert.ToString(Session["UserId"].ToString()));
            htParam1.Add("@RptMgrSapcode", txtMgrSapCode.Text);
            htParam1.Add("@Memcode", txtImmLeaderCode.Text);
            htParam1.Add("@flag", 1);
            dsUserType = dataAccess.GetDataSetForPrc("prc_TeamViewRH", htParam1);


            if (dsUserType.Tables[0].Rows[0]["MemType"].ToString() == "RH")
            {

                //Added by Prathamesh on 13-1-16 start

                DataSet ds = new DataSet();

                Hashtable htParam = new Hashtable();
                htParam.Clear();

                htParam.Clear();
                htParam.Add("@RptMgrSapcode", txtMgrSapCode.Text);
                htParam.Add("@Memcode", txtImmLeaderCode.Text);
                htParam.Add("@flag", 1);
                ds = dataAccess.GetDataSetForPrc("prc_TeamViewRH", htParam);

                if (ds.Tables[0].Rows.Count > 0)
                {
                   //tbDetails.Visible = true;
                    lnkTab5.Visible = true;
                    string Memtype = ds.ToString();

                    htParam.Clear();

                    htParam.Add("@RptMgrSapcode", txtMgrSapCode.Text);
                    htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
                    htParam.Add("@Chncls", ddlChnCls.SelectedValue);
                    htParam.Add("@MemType", ddlAgntType.SelectedValue);
                    htParam.Add("@flag", 1);

                    ds = dataAccess.GetDataSetForPrc("Prc_TeamView", htParam);

                    dgDetails.DataSource = ds;

                    dgDetails.DataBind();


                }
            }


            //Added by Prathamesh on 13-1-16 end 
            SqlDataReader dtRead;
            if (Request.QueryString["ID"].ToUpper().Trim() == "RT" || Request.QueryString["ID"].ToUpper().Trim() == "TR")
            {
                if (txtAgntCode.Text != "")
                {
                    string strAgnCodeAgnType = "";
                    string strAgnCodeAgnBizsrc = "";
                    string strAgnCodeAgnChnCls = "";
                    //1


                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentType,Bizsrc start
                    httable.Clear();
                    httable.Add("@AgentCode", txtAgntCode.Text.ToString().Trim());
                    httable.Add("@DirectAgtCode", "");
                    httable.Add("@flag", 2);
                    dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnDetails", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentType,Bizsrc End

                    // dtRead = dataAccess.exec_reader("Select AgentType,Bizsrc,Chncls From Agn where AgentCode ='" + txtAgntCode.Text.ToString().Trim() + "'");
                    if (dtRead.Read())
                    {
                        strAgnCodeAgnType = dtRead[0].ToString();
                        strAgnCodeAgnBizsrc = dtRead[1].ToString();
                        strAgnCodeAgnChnCls = dtRead[2].ToString();
                    }
                    dtRead.Close();
                    //2

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentCreateRulstart
                    httable.Clear();
                    httable.Add("@AgentType", strAgnCodeAgnType);
                    httable.Add("@BizSrc", strAgnCodeAgnBizsrc);
                    httable.Add("@ChnCls", strAgnCodeAgnChnCls);
                    httable.Add("@flag", 3);
                    dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get agent AgentCreateRul End


                    // dtRead = dataAccess.exec_reader("Select AgentCreateRul From chnAgnSu where AgentType='" + strAgnCodeAgnType + "' AND BizSrc='" + strAgnCodeAgnBizsrc + "' AND ChnCls='" + strAgnCodeAgnChnCls + "'");
                    if (dtRead.Read())
                    {
                        ViewState["AgentCreateRul"] = dtRead[0].ToString();
                    }
                    dtRead.Close();
                    //3


                    //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul start
                    httable.Clear();
                    httable.Add("@ChnCls", strAgnCodeAgnType);
                    httable.Add("@BizSrc", strAgnCodeAgnBizsrc);
                    httable.Add("@flag", 2);
                    dtRead = dataAccess.Common_exec_reader_prc("prc_GetChannelSubCls", httable);

                    //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul End

                    //  dtRead = dataAccess.exec_reader("Select ChnCreateRul From chnClsSu where BizSrc='" + strAgnCodeAgnBizsrc + "' AND ChnCls='" + strAgnCodeAgnChnCls + "'");
                    if (dtRead.Read())
                    {
                        ViewState["ChnCreateRul"] = dtRead[0].ToString();
                    }
                    dtRead.Close();
                }
            }
            else
            {
                //4

                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent search start
                httable.Clear();


                httable.Add("@CarrierCode", "");
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString().Trim());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
                httable.Add("@flag", 5);


                dtRead = dataAccess.exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);
                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent search End
                // dtRead = dataAccess.exec_reader("Select AgentCreateRul From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    ViewState["AgentCreateRul"] = dtRead[0].ToString();
                }
            }

            BindDataGrid();
            if (txtAgntCode.Text == "")
            {
                //if (ddlAgntStatus.SelectedValue == "IP")////modified by akshay on 25/03/14 changed != to == to set visibility of Agent status column in grid view
                //{
                //    dgDetails.Columns[12].Visible = false;
                //}
                //else
                //{
                //    dgDetails.Columns[12].Visible = true;
                //}
            }
            else
            {
                //5

                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent AgentStatus start
                httable.Clear();
                httable.Add("@AgentCode", txtAgntCode.Text);
                httable.Add("@DirectAgtCode", "");
                httable.Add("@flag", 3);

                dtRead = dataAccess.exec_reader_prc("prc_GetAgnDetails", httable);
                //added by Asrar Ansari on 02-07-2013 modified inline query into procedure for agent AgentStatus End

                //  dtRead = dataAccess.exec_reader("Select AgentStatus From Agn where AgentCode='" + txtAgntCode.Text + "'");
                if (dtRead.Read())
                {
                    //if (dtRead[0].ToString().Trim() != "IP")
                    //{
                    //    dgDetails.Columns[13].Visible = false;
                    //}
                    //else
                    //{
                    //    dgDetails.Columns[13].Visible = true;
                    //}
                }
            }
            //if (ViewState["AgentCreateRul"].ToString() == "RF" || ViewState["AgentCreateRul"].ToString() == "BA")
            //{
            //    dgDetails.Columns[10].Visible = false;
            //    dgDetails.Columns[14].Visible = true;
            //}
            //else
            //{
            //    dgDetails.Columns[10].Visible = true;
            //    dgDetails.Columns[14].Visible = false;
            //}

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
        //lblAgntCode.Text = (olng.GetItemDesc("lblAgntCode.Text"));
        lblAgntName.Text = (olng.GetItemDesc("lblAgntName.Text"));
        lblIDNo.Text = (olng.GetItemDesc("lblIDNo.Text"));
        lblAgntStatus.Text = (olng.GetItemDesc("lblAgntStatus.Text"));
        lblSlsChnnl.Text = (olng.GetItemDesc("lblSlsChnnl.Text"));
        lblChnCls.Text = (olng.GetItemDesc("lblChnCls.Text"));
        lblAgntType.Text = (olng.GetItemDesc("lblAgntType.Text"));
        lblImmLeaderCode.Text = (olng.GetItemDesc("lblImmLeaderCode.Text"));
        lblUnitCode.Text = (olng.GetItemDesc("lblUnitCode.Text"));
        lblDTJoinFrom.Text = (olng.GetItemDesc("lblDTJoinFrom.Text")) + " " + "(dd/mm/yyyy)";
        lblDTJoinTo.Text = (olng.GetItemDesc("lblDTJoinTo.Text")) + " " + "(dd/mm/yyyy)";
        lblCSCCode.Text = (olng.GetItemDesc("lblCSCCode.Text"));
        lblShwRecords.Text = (olng.GetItemDesc("lblShwRecords.Text"));
        lblRefAdv.Text = (olng.GetItemDesc("lblRefAdv"));
        lblClientCode.Text = (olng.GetItemDesc("lblClientCode"));
        lblSapCode.Text = (olng.GetItemDesc("lblSapCode"));
        lblchbox.Text = (olng.GetItemDesc("lblchbox"));
        lblFranchisee.Text = (olng.GetItemDesc("lblFranchisee"));
        lblLicenseNo.Text = (olng.GetItemDesc("lblLicenseNo"));
        lblCDALinkg.Text = (olng.GetItemDesc("lblCDALinkg"));
        ////added by akshay on 17/02/2014 to fetch label names from database
        lblUnTyp.Text = (olng.GetItemDesc("lblUnTyp"));
        lblRptUntTyp.Text = (olng.GetItemDesc("lblRptUntTyp"));
        //Added by swapnesh on 13/12/2013 to fetch lables value from database start
        lblPosition.Text = (olng.GetItemDesc("lblPosition"));
        lblchnltype.Text = (olng.GetItemDesc("lblchnltype"));
        //dgDetails.Columns[1].HeaderText = (olng.GetItemDesc("lblgvagntcode.Text"));
        // dgDetails.Columns[4].HeaderText = (olng.GetItemDesc("lblgvAgntName.Text"));

        //dgDetails.Columns[11].HeaderText = (olng.GetItemDesc("lblgvAgntType.Text"));
        //dgDetails.Columns[12].HeaderText = (olng.GetItemDesc("lblgvAgntStatus.Text"));
        //Added by swapnesh on 13/12/2013 to fetch lables value from database end

    }
    #endregion


    #region EnableDisableButton
    private void EnableDisableButton()
    {
        dsResult = null;

        strDesc01 = "Enable Vendor";
        strModule = "CHMS";
        dsResult = oCommonU.GetConfigSettings(strDesc01, strModule);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            strValue = dsResult.Tables[0].Rows[0]["Value"].ToString().Trim();

        }
        if (strValue == "YES")
        {
            lnkTab3.Visible = false;
        }
        else if (strValue == "NO")
        {
            lnkTab3.Visible = false;
        }

    }
    #endregion

    #region BUTTON 'btnClear' ONCLCIK EVENT
    protected void btnClear_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            //Response.Redirect("AGTSearch.aspx?ID=" + Request.QueryString["ID"].ToString() + "&Type=" + ViewState["vwsType"].ToString());
            txtAgntCode.Text = "";
            txtAgntName.Text = "";
            ddlRptTyp.SelectedIndex = 0;
            txtSapCode.Text = "";
            ddlSlsChnnl.SelectedIndex = 0;
            ddlChnCls.SelectedIndex = 0;
            ddlAgntType.SelectedValue = null;
            ddlUnitType.SelectedValue = null;
            txtLicNo.Text = "";
            ddlPosition.SelectedIndex = 2;
            txtPAN.Text = "";
            ddlAgntStatus.SelectedIndex = 1;
            txtUnitCode.Text = "";
            ddlShwRecrds.SelectedIndex = 0;
            ddlUnits.SelectedValue = null;
            //dgDetails.Visible = false;
            lblAgtSrchRes.Visible = false;
            //lblPageInfo.Visible = false;
            //tbDetails.Visible = false;sz
            //trDetails.Visible = false;

        }

        else
        {
            txtAgntCode.Text = "";
            txtAgntName.Text = "";
            ddlRptTyp.SelectedIndex = 0;
            txtSapCode.Text = "";
            ddlSlsChnnl.SelectedIndex = 0;
            ddlChnCls.SelectedIndex = 0;
            ddlAgntType.SelectedValue = null;
            ddlUnitType.SelectedValue = null;
            txtLicNo.Text = "";
            ddlPosition.SelectedIndex = 2;
            txtPAN.Text = "";
            ddlAgntStatus.SelectedIndex = 1;
            txtUnitCode.Text = "";
            ddlShwRecrds.SelectedIndex = 0;
            ddlUnits.SelectedValue = null;
            //dgDetails.Visible = false;
            lblAgtSrchRes.Visible = false;
            //tbDetails.Visible = false;
            //trDetails.Visible = false;


            //ddlAgntStatus.SelectedValue = "IF";
            //ddlAgntStatus.Enabled = false;
            //ddlPosition.SelectedValue = "2";
            //ddlPosition.Enabled = false;


        }





    }
    #endregion

    #region ddlAgntType SelectedIndexChanged Event
    protected void ddlAgntType_SelectedIndexChanged(object sender, EventArgs e)
    {
        divAgtBasicSearch.Visible = true;
        //btnBasicCollapse.Value = "-";

        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {

        }


        //Added by Prathamesh 19-1-16 start

        DataSet dsUserType = new DataSet();

        Hashtable htParam1 = new Hashtable();
        //htParam1.Add("@RptMgrSapcode", Convert.ToString(Session["UserId"].ToString()));
        htParam1.Add("@RptMgrSapcode", txtMgrSapCode.Text);
        htParam1.Add("@Memcode", txtImmLeaderCode.Text);
        htParam1.Add("@flag", 1);

        dsUserType = dataAccess.GetDataSetForPrc("prc_TeamViewRH", htParam1);


        //if (dsUserType.Tables[0].Rows[0]["MemType"].ToString() == "RH")
        //{
        DataSet dsChn = GetChannel(ddlSlsChnnl, 1);



        //    if (dsChn.Tables[0].Rows.Count > 0)
        //    {
        //        if (dsChn.Tables[0].Rows[0]["Bizsrc"].ToString() == "XX")


        //        {





        if (ddlAgntType.SelectedIndex == 1)
        {
            //DataSet ds = new DataSet();
            dsUserType.Clear();
            htParam1.Clear();
            //Hashtable htparam = new Hashtable();
            //htparam.Clear();
            //htparam.Add("@MemCode", "@Bizsrc", "@EmpType");
            htParam1.Add("@MemCode", txtImmLeaderCode.Text);
            htParam1.Add("@bizsrc", dsChn.Tables[0].Rows[0]["Bizsrc"].ToString());
            htParam1.Add("@EmpType", ddlAgntType.SelectedValue);
            htParam1.Add("@flag", 12);

            dsUserType = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam1);
            //dsUserType = GetRptUnitType(ddlUnitType, 8);
            if (dsUserType.Tables.Count > 0)
            {
                ddlUnitType.DataSource = dsUserType;
                ddlUnitType.DataTextField = "Unitdesc";
                ddlUnitType.DataValueField = "Unitype";
                ddlUnitType.DataBind();
            }

            if (ddlUnitType.Items.Count != 1)
            {
                ddlUnitType.Items.Insert(0, new ListItem("All", "All"));
            }
        }

        else if (ddlAgntType.SelectedIndex == 2)
        {
            //DataSet ds = new DataSet();
            dsUserType.Clear();
            htParam1.Clear();
            //Hashtable htparam = new Hashtable();
            //htparam.Clear();
            //htparam.Add("@MemCode", "@Bizsrc", "@EmpType");
            htParam1.Add("@MemCode", txtImmLeaderCode.Text);
            htParam1.Add("@bizsrc", dsChn.Tables[0].Rows[0]["Bizsrc"].ToString());
            htParam1.Add("@EmpType", ddlAgntType.SelectedValue);
            htParam1.Add("@flag", 12);

            dsUserType = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam1);
            //dsUserType = GetRptUnitType(ddlUnitType, 8);
            if (dsUserType.Tables.Count > 0)
            {
                ddlUnitType.DataSource = dsUserType;
                ddlUnitType.DataTextField = "Unitdesc";
                ddlUnitType.DataValueField = "Unitype";
                ddlUnitType.DataBind();
            }

            if (ddlUnitType.Items.Count != 1)
            {
                ddlUnitType.Items.Insert(0, new ListItem("All", "All"));
            }
        }


        else if (ddlAgntType.SelectedIndex == 3)
        {
            //DataSet ds = new DataSet();
            dsUserType.Clear();
            htParam1.Clear();
            //Hashtable htparam = new Hashtable();
            //htparam.Clear();
            //htparam.Add("@MemCode", "@Bizsrc", "@EmpType");
            htParam1.Add("@MemCode", txtImmLeaderCode.Text);
            htParam1.Add("@bizsrc", dsChn.Tables[0].Rows[0]["Bizsrc"].ToString());
            htParam1.Add("@EmpType", ddlAgntType.SelectedValue);
            htParam1.Add("@flag", 12);

            dsUserType = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam1);
            //dsUserType = GetRptUnitType(ddlUnitType, 8);
            if (dsUserType.Tables.Count > 0)
            {
                ddlUnitType.DataSource = dsUserType;
                ddlUnitType.DataTextField = "Unitdesc";
                ddlUnitType.DataValueField = "Unitype";
                ddlUnitType.DataBind();
            }

            if (ddlUnitType.Items.Count != 1)
            {
                ddlUnitType.Items.Insert(0, new ListItem("All", "All"));
            }
        }







        SqlDataReader dtRead;
        if (Request.QueryString["ID"].ToUpper().Trim() == "TR")
        {

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AppRule ,AgentCreateRul,UntRule  Start
            httable.Clear();
            httable.Add("@CarrierCode", "");
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 12);

            dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AppRule ,AgentCreateRul,UntRule  End


            // dtRead = dataAccess.exec_reader("Select AppRule ,AgentCreateRul,UntRule From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["AppRule"] = dtRead[0].ToString();
                ViewState["AgentCreateRul"] = dtRead[1].ToString();

                if (ViewState["AppRule"].ToString() == "1")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }
                else
                {
                    ChkFranchisee.Visible = false;
                    lblFranchisee.Visible = false;
                }
                if (Convert.ToString(dtRead["UntRule"]) == "3")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }


                if (ddlSlsChnnl.SelectedValue == "AD" && ddlAgntType.SelectedValue == "ST")
                {
                    ChkFranchisee.Visible = true;
                    lblFranchisee.Visible = true;
                }

            }
            dtRead.Close();
            //16


            //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul start
            httable.Clear();
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@flag", 2);
            dtRead = dataAccess.Common_exec_reader_prc("prc_GetChannelSubCls", httable);

            //added by asrar on 03/07/2013 to convert inline query to proc to get ChnCreateRul End



            //  dtRead = dataAccess.exec_reader("Select ChnCreateRul From chnClsSu where BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["ChnCreateRul"] = dtRead[0].ToString();
            }
            dtRead.Close();
        }
        else if (Request.QueryString["ID"].ToUpper().Trim() == "SP")
        {
            //17

            //added by asrar on 03/07/2013 to convert inline query to proc to get agent AppRule start
            httable.Clear();
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 8);
            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

            //added by asrar on 03/07/2013 to convert inline query to proc to get agent AppRule End


            //dtRead = dataAccess.exec_reader("Select AppRule From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {
                ViewState["AppRule"] = dtRead[0].ToString();
            }
            dtRead.Close();
            if (ViewState["AppRule"].ToString() != "1")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "MyScript", "alert('CDA s only allowed for suspension.');", true);
            }
        }
        else if (Request.QueryString["ID"].ToUpper().Trim() == "AH")
        {
            if (ddlSlsChnnl.SelectedValue == "AG")
            {
                //18

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule,AgentCreateRul,UntRule start
                httable.Clear();
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 9);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule,AgentCreateRul,UntRule End


                // dtRead = dataAccess.exec_reader("Select AppRule,AgentCreateRul,UntRule From chnAgnSu where AgentType ='"+ddlAgntType.SelectedValue  +"' and AgentType in ('DM','SB','AP','PP','SP') AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    if (dtRead.HasRows)
                    {
                        if (Convert.ToString(dtRead[0]).Trim() == "0")
                        {
                           //  trCDAHierarchy.Visible = true;
                        }
                        else
                        {
                           // trCDAHierarchy.Visible = false;
                        }
                    }
                }
                else
                {
                   // trCDAHierarchy.Visible = false;
                }
                dtRead.Close();

            }
            else if (ddlSlsChnnl.SelectedValue == "CD")
            {
                //19

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule start
                httable.Clear();
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 8);
                dtRead = dataAccess.Common_exec_reader_prc("Prc_GetData_chnAgnSu", httable);

                //added by asrar on 03/07/2013 to convert inline query to proc to get  AppRule End

                //  dtRead = dataAccess.exec_reader("Select AppRule From chnAgnSu where AgentType ='"+ddlAgntType.SelectedValue  +"' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {
                    if (dtRead.HasRows)
                    {
                        if (Convert.ToString(dtRead[0]).Trim() == "1")
                        {
                           //  trCDAHierarchy.Visible = true;
                        }
                        else
                        {
                           // trCDAHierarchy.Visible = false;
                            CDACheck.Checked = false;
                        }
                    }
                }

            }

        }

    }
    #endregion




    #region DROPDOWN 'ddlChnCls' SELECTEDINDEXCHANGED EVENT
    protected void ddlChnCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        divAgtBasicSearch.Visible = true;
        //btnBasicCollapse.Value = "-";
        DataSet dsChn = GetChannel(ddlSlsChnnl, 1);

        if (dsChn.Tables[0].Rows.Count > 1)
        {
            MultiChannel();
        }

        txtImmLeaderCode.Text = dsResult.Tables[0].Rows[0][0].ToString();

        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            Get_UsersAgenttype();

            //ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

            GetUnitType(ddlUnitType);
            GetUnitType(ddlUnits);
            ddlChnCls.Focus();
            ////added by akshay on 17/02/14 to fill UnitType Dropdown and reporting unit type end
        }

        //Added by Prathamesh 9-12-15 start
        //else
        //{
        DataSet dsEmpType = new DataSet();

        if (ddlRptTyp.SelectedIndex == 1)
        {
            dsEmpType = GetEmpType(ddlAgntType, 5);

            DataSet ds = GetRptUnitType(ddlUnitType, 8);
            DataSet ds1 = GetRptUnitType1(ddlUnits, 9);
        }

        else
        {
            dsEmpType = GetEmpType(ddlAgntType, 6);
            DataSet ds = GetRptUnitType(ddlUnitType, 8);
            DataSet ds1 = GetRptUnitType1(ddlUnits, 9);

        }

        //ddlAgntType.Items.Insert(0, new ListItem("All", "All"));

        //ddlUnitType.Items.Insert(0, new ListItem(" ", "All"));


        // ddlUnits.Items.Insert(0, new ListItem("--Select--", "All"));



        //}



    }
    #endregion

    #region DROPDOWNLIST ddlRptTyp_SelectedIndexChanged
    //Added by Prathamesh 9-12-15 start
    protected void ddlRptTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSlsChnnl.ClearSelection();
        ddlChnCls.ClearSelection();
        ddlAgntType.ClearSelection();
        ddlUnitType.ClearSelection();
        ddlUnits.ClearSelection();

        if (HttpContext.Current.Session["UserId"].ToString() != "systemadmin")
        {


            if (ddlRptTyp.SelectedIndex == 0 && ddlRptTyp.SelectedIndex == 1 && ddlRptTyp.SelectedIndex == 2 && ddlRptTyp.SelectedIndex == 3)
            {
                txtImmLeaderCode.Enabled = false;
                //txtImmLeaderCode.Text = "";
                txtMgrSapCode.Enabled = false;
                txtMgrSapCode.Text = "";
            }

            if (ddlRptTyp.SelectedIndex == 1)
            {
                DataSet dsChn = GetChannel(ddlSlsChnnl, 1);



                if (dsChn.Tables[0].Rows.Count > 0)
                {
                    if (dsChn.Tables[0].Rows[0]["Bizsrc"].ToString() == "XX")
                    {

                        rdbChnlTyp.SelectedValue = "0";
                        rdbChnlTyp.Items.FindByValue("1").Enabled = false;
                        rdbChnlTyp.Items.FindByValue("0").Enabled = true;
                        oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");

                        //ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));

                        ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--", "All"));


                        ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

                    }
                    else
                    {
                        rdbChnlTyp.SelectedValue = "1";
                        rdbChnlTyp.Items.FindByValue("0").Enabled = false;
                        rdbChnlTyp.Items.FindByValue("1").Enabled = true;
                        oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");

                        ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));

                        ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--", "All"));

                        ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

                    }

                }
            }

            else
            {
                DataSet dsChn = GetChannel(ddlSlsChnnl, 2);

                //DataSet dsEmpType = GetEmpType(ddlAgntType,0);

                if (dsChn.Tables[0].Rows.Count > 0)
                {
                    if (dsChn.Tables[0].Rows[0]["Bizsrc"].ToString() == "XX")
                    {

                        rdbChnlTyp.SelectedValue = "0";
                        rdbChnlTyp.Items.FindByValue("1").Enabled = false;
                        rdbChnlTyp.Items.FindByValue("0").Enabled = false;
                        oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");
                        ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));
                        ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--", "All"));
                        ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));
                    }
                    else
                    {
                        rdbChnlTyp.SelectedValue = "1";
                        rdbChnlTyp.Items.FindByValue("0").Enabled = false;
                        rdbChnlTyp.Items.FindByValue("1").Enabled = true;
                        oCommonU.FillDropDown(ddlSlsChnnl, dsChn.Tables[0], "Bizsrc", "Channel");
                        ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));
                        ddlSlsChnnl.Items.Insert(0, new ListItem("--Select--", "All"));
                        ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));
                    }

                }

            }





        }
        else
        {
            txtImmLeaderCode.Enabled = true;
            txtMgrSapCode.Enabled = true;


        }
        ddlRptTyp.Focus();


    }
    //Added by Prathamesh 9-12-15 end
    #endregion

    #region Get_UsersAgenttype()
    public void Get_UsersAgenttype()
    {
        try
        {
            string UserId = Session["UserID"].ToString();

            if (ddlSlsChnnl.SelectedValue == "")
            {
                oCommonU.GetAgentType(ddlAgntType, "--Select--", "");
            }
            else
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "AH" || Request.QueryString["ID"].ToUpper().Trim() == "VW")
                {
                    oCommonU.GetAgentTypeForSlsChnnlCTSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);
                }
                else
                {
                    oCommonU.GetAgentTypeforSearch(ddlAgntType, ddlSlsChnnl.SelectedValue, ddlAgntType.SelectedValue, ddlChnCls.SelectedValue, UserId, hdnAgentRole.Value);
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

    #region GetUnitType
    protected void GetUnitType(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            SqlDataReader dtddlRead;
            Hashtable htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@BizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            dtddlRead = dataAccess.Common_exec_reader_prc_common("Prc_GetUnitTypeForAgtSearch", htParam);
            if (dtddlRead.HasRows)
            {
                ddl.DataSource = dtddlRead;////ddlUnitType
                ddl.DataTextField = "UnitDesc";
                ddl.DataValueField = "UnitType";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("-- Select --", ""));
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

    #region DROPDOWN 'ddlSlsChnnl' SELECTEDINDEXCHANGED EVENT
    protected void ddlSlsChnnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        divAgtBasicSearch.Visible = true;
        //btnBasicCollapse.Value = "-";

           DataSet dsChn = GetChannel(ddlSlsChnnl, 1);

           if (dsChn.Tables[0].Rows.Count > 1)
           {
               MultiChannel();
           }
        //  txtImmLeaderCode.Text = dsResult.Tables[0].Rows[0][0].ToString();

        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            string UserId = Session["UserID"].ToString();
            oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, UserId.ToString());
            ddlChnCls.Items.Insert(0, new ListItem("All", "All"));


           // trCDAHierarchy.Visible = false;
            CDACheck.Checked = false;
            ddlSlsChnnl.Focus();
        }

        else
        {
            if (ddlRptTyp.SelectedIndex == 1)
            {
                DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
            }

            else
            {
                DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
            }


            //ddlChnCls.Items.Insert(0, new ListItem("--Select--", "All"));

        }

    }
    #endregion

    protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlUnitType.Items.Clear();


        if (ddlUnitType.SelectedIndex != 0)
        {

            Hashtable htParam = new Hashtable();

            DataSet ds = new DataSet();



            htParam.Clear();

            //htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
            //htParam.Add("@RptType", ddlRptTyp.SelectedValue);
            htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            htParam.Add("@UnitType", ddlUnitType.SelectedValue);

            htParam.Add("flag", 10);

            ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

            ddlUnits.DataSource = ds;
            ddlUnits.DataTextField = "UnitDesc01";
            ddlUnits.DataValueField = "Unittype";
            ddlUnits.DataBind();


        }
    }

    //protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Hashtable htParam = new Hashtable();

    //    DataSet ds = new DataSet();



    //    htParam.Clear();

    //    //htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
    //    //htParam.Add("@RptType", ddlRptTyp.SelectedValue);
    //    htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
    //    htParam.Add("@Chncls", ddlChnCls.SelectedValue);
    //    htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
    //    htParam.Add("flag", 11);

    //    ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

    //    ddlUnitType.DataSource = ds;
    //    ddlUnitType.DataValueField = "";
    //    ddlUnitType.DataTextField = "UnitType";
    //    ddlUnitType.DataBind();
    //}

    //Added By Prathamesh 14-12-15 start

    protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
    {


        // ddlUnits.Items.Clear();

        if (ddlUnits.SelectedIndex >= 0)
        {
            ddlUnitType.Items.Clear();
        }


        Hashtable htParam = new Hashtable();

        DataSet ds = new DataSet();



        htParam.Clear();

        //htParam.Add("@RptMgrSapCode", txtMgrSapCode.Text);
        /////htParam.Add("@RptType", ddlRptTyp.SelectedValue);
        htParam.Add("@bizsrc", ddlSlsChnnl.SelectedValue);
        htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        htParam.Add("@RptUnitType", ddlUnits.SelectedValue);
        htParam.Add("flag", 11);

        ds = dataAccess.GetDataSetForPrc("prc_TeamView_RptMgrSapCode", htParam);

        ddlUnitType.DataSource = ds;
        ddlUnitType.DataTextField = "UnitDesc01";
        ddlUnitType.DataValueField = "Unittype";
        ddlUnitType.DataBind();
        ddlUnitType.Items.Insert(0, new ListItem("--Select--", ""));
    }
    //Added By Prathamesh 14-12-15 end

    #region DATAGRID 'dgDetails' PAGEINDEXCHANGING EVENT
    protected void dgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        ShowPageInformation();
    }
    #endregion

    #region DATAGRID 'dgDetails' ROWDATABOUND EVENT
    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";
            SqlDataReader dtRead;


            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type Start
            httable.Clear();
            httable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));

            dtRead = dataAccess.Common_exec_reader_prc("Prc_GetUserType", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get User type End
            if (dtRead.Read())
            {
                strUsrType = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strUsrType == "0")
            {
                strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
            else
            {
                //10
                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode Start
                httable.Clear();
                httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());

                dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

                //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode End
                if (dtRead.Read())
                {
                    strIntAgentCode = dtRead[0].ToString();
                }
                dtRead.Close();
                if (strIntAgentCode.Trim().ToString() == "")
                {
                    strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
                }
            }

            Label lblEMPCode = (Label)e.Row.FindControl("label1");
            //Label lblMgrEMPCode = (Label)e.Row.FindControl("MgrEMPCode");

            Label lblAgentStatus = (Label)e.Row.FindControl("AgentStatus");

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToUpper().Trim() == "RIN")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        //Change: Parag @ 20022014- Alteration of Reinstatement QueryString ID from RE to RIN
                        e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"MemberReinstate.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&Role=" + hdnAgentRole.Value.Trim() + "\">" + e.Row.Cells[1].Text + "</a>";
                    }
                }
                else if (Request.QueryString["ID"].ToUpper().Trim() == "IN")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton lnkRequest = new LinkButton();
                        lnkRequest = (LinkButton)e.Row.FindControl("lnk");
                        lnkRequest.Attributes.Add("onclick", "funcShowPopupBAS('" + e.Row.Cells[1].Text + "');return false;");
                    }
                    if (lblAgentStatus.Text.Trim() != "IP")
                    {
                        if (Request.QueryString["Type"].ToString() == "I")
                        {

                            string strChnCls = ddlChnCls.SelectedItem.Text.ToString();
                            string strChannel = ddlSlsChnnl.SelectedItem.Text.ToString();
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\" href=\"AgentVendorMap.aspx?AgentCode=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&AgentName=" + e.Row.Cells[3].Text + "&slsChannel=" + strChannel + "&ChnCls=" + strChnCls + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                        else if (Request.QueryString["Type"].ToString() == "M")
                        {


                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AgtVenMapping.aspx?AgentCode=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }

                        else
                        {
                            if (hdnAgentRole != null)
                            {
                                if (hdnAgentRole.Value == "E")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else if (hdnAgentRole.Value == "V")
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Ven" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                                else
                                {
                                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[7].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                                }
                            }
                            else
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTInfo.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                        }
                    }
                }

                //added by akshay on 23/01/14 start
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRF")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (hdnAgentRole != null)
                        {
                            if (hdnAgentRole.Value == "E")
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                            else if (hdnAgentRole.Value == "V")
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Ven" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                            else
                            {
                                e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                            }
                        }
                        else
                        {
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTransfer.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[4].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                    }
                }

                //added by akshay on 23/01/14 end

                //added by akshay on 19/02/14 start
                else if (Request.QueryString["ID"].ToUpper().Trim() == "TRM")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        if (hdnAgentRole.Value == "E")
                        {
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&Ctgry=Emp" + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                        else
                        {
                            e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                        }
                    }
                    else
                    {
                        e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTTermination.aspx?AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "&UnitCode=" + e.Row.Cells[5].Text + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                    }
                }

                //added by akshay on 27/01/14 end
                else if (Request.QueryString["ID"].ToUpper().Trim() == "PR")
                {
                    e.Row.Cells[1].Text = "<i class=\"fa fa-male\"></i>&nbsp;<a style=\"color:green;\"  href=\"AGTPromotion.aspx?Role=" + hdnAgentRole.Value + "&AgnCd=" + e.Row.Cells[1].Text + "&Type=" + ViewState["vwsType"].ToString() + "&ID=" + Request.QueryString["ID"].ToString() + "\"><i class=\"fa fa-edit\" style=\"color:blue;\"></i>" + e.Row.Cells[1].Text + "</a>";
                }
            }
        }
    }
    #endregion


    #region DATAGRID 'dgDetails' SORT EVENT
    protected void dgDetails_Sorting(object sender, GridViewSortEventArgs e)
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

        DataTable dt = GetDataTable();
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
        ShowPageInformation();
    }
    #endregion


    #region Link lnkTab1_Click
    protected void lnkTab1_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "E";
        Response.Redirect("TeamView.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
    }
    #endregion

    #region Link lnkTab1_Click
    protected void lnkTab2_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "A";
        Response.Redirect("TeamView.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=agt");
    }
    #endregion

    #region Link lnkTab1_Click
    protected void lnkTab3_Click(object sender, ImageClickEventArgs e)
    {
        hdnAgentRole.Value = "V";
        Response.Redirect("TeamView.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "&Role=vendor");
    }
    #endregion


    #region METHOD 'ShowPageInformation'
    private void ShowPageInformation()
    {
        int intPageIndex = dgDetails.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgDetails.PageCount;
    }
    #endregion


    #region rdbChnlTyp_SelectedIndexChanged
    protected void rdbChnlTyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
        {
            if (rdbChnlTyp.SelectedValue == "0")
            {
                oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "0");
                //ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, Session["UserID"].ToString());
                Get_UsersAgenttype();

                //ddlAgntType.Items.Insert(0, new ListItem("--Select--", "All"));

                GetUnitType(ddlUnitType);
                GetUnitType(ddlUnits);

            }
            else
            {
                oCommonU.GetSalesChannel(ddlSlsChnnl, "", 0, Session["UserID"].ToString(), "1");
                ddlSlsChnnl.Items.Insert(0, new ListItem("All", ""));
                oCommonU.GetUserChnclsChannel(ddlChnCls, ddlSlsChnnl.SelectedValue, 0, Session["UserID"].ToString());
                ddlChnCls.Items.Insert(0, new ListItem("All", "All"));

                //Added by Prathamesh  17-3-16 start

                Get_UsersAgenttype();
                GetUnitType(ddlUnitType);
                GetUnitType(ddlUnits);

                //Added by Prathamesh  17-3-16 end
            }


            //ddlAgntType.Items.Clear();
            //ddlAgntType.DataSource = null;
            //ddlAgntType.DataBind();

            ddlAgntType.Items.Insert(0, new ListItem("All", "All"));
            rdbChnlTyp.Focus();
        }
    }
    #endregion

    #region BIND DATAGRID 'dgDetails' METHOD
    protected void BindDataGrid()
    {
        try
        {
            if (txtDTJoinFrom.Text != "" && txtDTJoinTo.Text == "")
            {
                if (Convert.ToDateTime(txtDTJoinFrom.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be future date');</script>", false);
                    return;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Date Joined To');</script>", false);
                return;
            }
            if (txtDTJoinTo.Text != "" && txtDTJoinFrom.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Please Enter Date Joined From');</script>", false);
                return;
                if (Convert.ToDateTime(txtDTJoinTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined To cannot be future date');</script>", false);
                    return;
                }
            }
            if (txtDTJoinTo.Text != "" && txtDTJoinFrom.Text != "")
            {
                if (Convert.ToDateTime(txtDTJoinFrom.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be future date');</script>", false);
                    return;
                }
                else if (Convert.ToDateTime(txtDTJoinTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined To cannot be future date');</script>", false);
                    return;
                }
                else
                {
                    DateTime dtFrom = DateTime.Parse(txtDTJoinFrom.Text);
                    DateTime dtTo = DateTime.Parse(txtDTJoinTo.Text);
                    if (dtFrom.CompareTo(dtTo) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "<script type='text/javascript'>alert('Date Joined From cannot be greater than Date Joined To');</script>", false);
                        return;
                    }

                }
            }

            string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";
            SqlDataReader dtRead;
            //6

            //Added by asrar on 02/07/2013 converted inline query into proc to get User Type Start
            httable.Clear();
            httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
            dtRead = dataAccess.exec_reader_prc_inscdirect("prc_GetUserType", httable);

            //Added by asrar on 02/07/2013 converted inline query into proc to get User Type End



            //dtRead = dataAccess.Common_exec_reader("Select UserType from InscDirect..iUser Where UserId= '" + Convert.ToString(Session["UserId"].ToString()) + "'");
            if (dtRead.Read())
            {
                strUsrType = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strUsrType == "0")
            {
                strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
            else
            {
                //7

                //Added by asrar on 02/07/2013 converted inline query into proc to Agent Code Start
                httable.Clear();
                httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

                //Added by asrar on 02/07/2013 converted inline query into proc to get Agent Code End


                //dtRead = dataAccess.Common_exec_reader("Select AgentCode from Agn Where EmpCode= '" + Convert.ToString(Session["UserId"].ToString()) + "' AND BizSrc='"+ ddlSlsChnnl.SelectedValue + "' AND AgentStatus='IF'");

                if (dtRead.Read())
                {
                    strIntAgentCode = dtRead[0].ToString();
                }
                dtRead.Close();
                if (strIntAgentCode.Trim().ToString() == "")
                {
                    strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
                }
            }
            dgDetails.PageSize = 50;//Convert.ToInt32(ddlShwRecrds.SelectedValue);
            dsResult = new DataSet();
            Hashtable htParam = new Hashtable();
            string strAgnCreateRul = "";

            decimal strUnitRank = 0;
            htParam.Add("@CarrierCode", "2");
            htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
            htParam.Add("@Type", ViewState["vwsType"].ToString());
            htParam.Add("@AgentCode", txtAgntCode.Text);
            htParam.Add("@DirectGrpLeader", "");
            htParam.Add("@Surname", "");
            htParam.Add("@Givenname", "");
            htParam.Add("@CurrentId", txtPAN.Text);
            htParam.Add("@AgentStatus", ddlAgntStatus.SelectedValue);
            htParam.Add("@AgentType", ddlAgntType.SelectedValue);
            htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text.Trim());
            htParam.Add("@MgrSapCode", txtMgrSapCode.Text.Trim());
            htParam.Add("@UnitCode", txtUnitCode.Text);
            if (txtDTJoinFrom.Text.Trim() != "")
            {
                htParam.Add("@RecruitDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@RecruitDate ", System.DBNull.Value);
            }
            if (txtDTJoinTo.Text.Trim() != "")
            {
                htParam.Add("@CreateDtim", DateTime.Parse(txtDTJoinTo.Text).ToString("yyyyMMdd"));
            }
            else
            {
                htParam.Add("@CreateDtim ", System.DBNull.Value);
            }
            if (ViewState["vwsType"].ToString() == "N")
            {
                htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }
            else if (ViewState["vwsType"].ToString() == "E")
            {
                htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
                htParam.Add("@Chncls", ddlChnCls.SelectedValue);
            }
            htParam.Add("@AgentName", txtAgntName.Text);
            htParam.Add("@CSCCode", txtCSCCode.Text);
            htParam.Add("@EMPCode", txtSapCode.Text);
            htParam.Add("@LinkRefAdv", txtLinkRef.Text);
            htParam.Add("@GCN", txtGCN.Text);
            htParam.Add("@LicNo", txtLicNo.Text);
            if (Request.QueryString["ID"].ToUpper().Trim() != null)
            {
                htParam.Add("@ID", Request.QueryString["ID"].ToUpper().Trim());
            }
            //Added by swapnesh on 11/12/2013 to add search parameter for reporting type start

            if (ddlRptTyp.SelectedValue != "ALL")
            {
                //rdbRptTyp.SelectedValue = "2";
                htParam.Add("@RptTyp", ddlRptTyp.SelectedValue);
            }
            else
            {
                htParam.Add("@RptTyp", "");
            }
            htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
            //if (rdbPosn.SelectedValue == "0")
            //{
            //    htParam.Add("@posn", "yes");
            //}
            //else
            //{
            //    htParam.Add("@posn", "no");
            //}
            if (ddlPosition.SelectedValue == "0")
            {
                htParam.Add("@posn", DBNull.Value);
            }
            else if (ddlPosition.SelectedValue == "1")
            {
                htParam.Add("@posn", "yes");
            }
            else
            {
                htParam.Add("@posn", "no");
            }
            htParam.Add("@AgentRole", hdnAgentRole.Value.Trim());
            //Added by swapnesh on 11/12/2013 to add search parameter for reporting type end

            if (strUsrType == "0")
            {
                htParam.Add("@UserId", Session["UserID"].ToString());
            }
            else if (strIntAgentCode.Trim().ToString() != "")
            {
                htParam.Add("@UserId", strIntAgentCode.Trim().ToString());
            }


            if (strAgnCreateRul.Trim() == "")
            {
                //8
                //Added by asrar on 02/07/2013 converted inline query into proc to Agent Code Start
                httable.Clear();
                httable.Add("@CarrierCode", "");
                httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
                httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
                httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
                httable.Add("@flag", 3);
                dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

                //Added by asrar on 02/07/2013 converted inline query into proc to get Agent Code End

                // dtRead = dataAccess.exec_reader("Select UnitRank,AgentCreateRul From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
                if (dtRead.Read())
                {

                    strUnitRank = Convert.ToDecimal(dtRead[0].ToString());
                    strAgnCreateRul = dtRead[1].ToString();
                }
                dtRead.Close();
            }

            httable.Clear();
            if (ddlPosition.SelectedValue == "0")
            {
                httable.Add("@posn", DBNull.Value);
            }
            else if (ddlPosition.SelectedValue == "1")
            {
                httable.Add("@posn", "yes");
            }
            else
            {
                httable.Add("@posn", "no");
            }

            httable.Add("@MemCode", txtAgntCode.Text.ToString().Trim());
            httable.Add("@Givenname", txtAgntName.Text.ToString().Trim());
            httable.Add("@Reltype", ddlRptTyp.SelectedValue.ToString().Trim());
            //httable.Add("@rptunittype", ddlUnits.SelectedValue.ToString().Trim());
            httable.Add("@unittype", ddlUnitType.SelectedValue.ToString().Trim());
            httable.Add("@RptMgrcode", txtImmLeaderCode.Text.ToString().Trim());
            httable.Add("@RptMgrSapcode", txtMgrSapCode.Text.ToString().Trim());
            httable.Add("@MemSapcode", txtSapCode.Text.ToString().Trim());


            httable.Add("@pan", txtPAN.Text.ToString().Trim());
            httable.Add("@bizSrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
            httable.Add("@MemStatus", ddlAgntStatus.SelectedValue.ToString().Trim());
            //httable.Add("@EmpType", ddlAgntType.SelectedValue.ToString().Trim());
            httable.Add("@LicNo", txtLicNo.Text.ToString().Trim());
            //httable.Add("@DtFrom", txtDTJoinFrom.Text.ToString().Trim());
            //httable.Add("@DtTo", txtDTJoinTo.Text.ToString().Trim());
            httable.Add("@MemRole", hdnAgentRole.Value.ToString().Trim());
            //httable.Add("@posn ", ddlPosition.SelectedValue.ToString().Trim());
            httable.Add("@Unitcode", txtUnitCode.Text.ToString().Trim());
            httable.Add("@EmpType", ddlAgntType.SelectedValue.ToString().Trim());
            //httable.Add("@flag", 1);
            //ddlUnitType @unittype

            //httable.Add("@flag", 2);

            dsResult.Clear();
            dsResult = dataAccess.GetDataSetForPrc("Prc_TeamView_new", httable);



            //if (HttpContext.Current.Session["UserId"].ToString() == "systemadmin")
            //{
            //    if (txtMgrSapCode.Text != "" || txtImmLeaderCode.Text != "" && ddlSlsChnnl.SelectedItem.Text == "ALL" && 
            //        ddlChnCls.SelectedItem.Text == "ALL" && ddlAgntType.SelectedItem.Text == "All" && txtSapCode.Text=="")
            //    {
            //        Hashtable htparam = new Hashtable();

            //        htparam.Add("@AgentCode", txtImmLeaderCode.Text);
            //        htparam.Add("@Empcode", txtMgrSapCode.Text);
            //        htparam.Add("@Flag", "");
            //        dsResult = dataAccess.GetDataSetForPrc("Prc_GetDataForHierarchy_Teamview", htparam);
            //    }
            //    else
            //    {
            //        dsResult = dataAccess.GetDataSetForPrc("prc_TeamView", httable);
            //    }
            //}

            //else if (ddlUnitType.SelectedItem.Text == "All" && ddlAgntType.SelectedItem.Text == "All" && txtUnitCode.Text == "" && txtPAN.Text == "" && txtLicNo.Text=="" && txtAgntName.Text=="") 
            //{
            //    Hashtable htparam = new Hashtable();

            //    htparam.Add("@AgentCode", txtImmLeaderCode.Text);
            //    htparam.Add("@Empcode", txtMgrSapCode.Text);
            //    htparam.Add("@Flag", "");
            //    dsResult = dataAccess.GetDataSetForPrc("Prc_GetDataForHierarchy_Teamview", htparam);
            //}
            ////else if(txtUnitCode.Text != "" )
            ////{
            ////    Hashtable htparam = new Hashtable();

            ////    htparam.Add("@AgentCode", txtImmLeaderCode.Text);
            ////    htparam.Add("@Empcode", txtMgrSapCode.Text);
            ////    htparam.Add("@Flag", "");
            ////    dsResult = dataAccess.GetDataSetForPrc("Prc_GetDataForHierarchy_Teamview", htparam);
            ////}
            ////else if(txtPAN.Text != "")
            ////{
            ////    Hashtable htparam = new Hashtable();

            ////    htparam.Add("@AgentCode", txtImmLeaderCode.Text);
            ////    htparam.Add("@Empcode", txtMgrSapCode.Text);
            ////    htparam.Add("@Flag", "");
            ////    dsResult = dataAccess.GetDataSetForPrc("Prc_GetDataForHierarchy_Teamview", htparam);
            ////}
            ////else if (ddlAgntType.SelectedItem.Text == "All" && ddlUnitType.SelectedItem.Text == "All")
            ////{
            ////    Hashtable htparam = new Hashtable();

            ////    htparam.Add("@AgentCode", txtImmLeaderCode.Text);
            ////    htparam.Add("@Empcode", txtMgrSapCode.Text);
            ////    htparam.Add("@Flag", "");
            ////    dsResult = dataAccess.GetDataSetForPrc("Prc_GetDataForHierarchy_Teamview", htparam);
            ////}
            //else
            //{
            //    dsResult = dataAccess.GetDataSetForPrc("prc_TeamView", httable);
            //}

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    Div2.Visible = true;
                    dgDetails.DataSource = dsResult;
                    //Added by swapnesh on 13/12/2013 to set headertext of gridview columns end
                    dgDetails.DataBind();
                    ShowPageInformation();
                   // trDetails.Visible = true;
                    trDgDetails.Visible = true;
                    lblMessage.Visible = false;
                    lnkTab4.Visible = true;
                    lnkTab5.Visible = true;
                    dgDetails.Visible = true;

                    lblMessage.Text = "";
                    if (Request.QueryString["ID"].ToUpper().Trim() == "SP")
                    {
                        if (ViewState["AppRule"].ToString() != "1")
                        {
                            lblMessage.Text = "Agent suspension allowed for CDA Franchisee only.";
                            lblMessage.Visible = true;
                        }
                    }

                }
                else
                {
                    dgDetails.DataSource = null;
                    dgDetails.DataBind();
                    lblPageInfo.Text = "";
                    //trDetails.Visible = false;
                    trDgDetails.Visible = false;
                    lblMessage.Visible = true;
                    lnkTab5.Visible = false;
                    lnkTab4.Visible = false;
                    lblAgtSrchRes.Visible = false;
                    //trDetails.Visible = false;
                    lblMessage.Text = "0 RECORD FOUND.";

                }
            }

            else
            {
                dgDetails.DataSource = null;
                dgDetails.DataBind();
                lblAgtSrchRes.Visible = false;
                lblPageInfo.Text = "";
                //trDetails.Visible = false;
                trDgDetails.Visible = false;
                lblMessage.Visible = true;
                lnkTab4.Visible = false;
                lnkTab5.Visible = false;
                //trDetails.Visible = false;
                lblMessage.Text = "0 RECORD FOUND.";

            }
            dsResult = null;
            htParam.Clear();
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


    #region METHOD 'GetDataTable()' DEFINITION
    protected DataTable GetDataTable()
    {
        SqlDataReader dtRead;
        string strAgnCreateRule = "";
        string strUsrType = "", strExtAgentCode = "", strIntAgentCode = "", strEmpAgentCode = "";

        decimal strUntRnk = 0;
        dsResult = new DataSet();
        Hashtable htParam = new Hashtable();
        //11

        //added by asrar on 03/07/2013 to convert inline query into proc to get UserType start
        httable.Clear();
        httable.Add("@UserId", Convert.ToString(Session["UserId"].ToString()));

        dtRead = dataAccess.Common_exec_reader_prc("Prc_GetUserType", httable);

        //added by asrar on 03/07/2013 to convert inline query into proc to get UserType End

        //  dtRead = dataAccess.Common_exec_reader("Select UserType from InscDirect..iUser Where UserId= '" + Convert.ToString(Session["UserId"].ToString()) + "'");
        if (dtRead.Read())
        {
            strUsrType = dtRead[0].ToString();
        }
        dtRead.Close();
        if (strUsrType == "0")
        {
            strExtAgentCode = Convert.ToString(Session["UserId"].ToString());
        }
        else
        {

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode Start
            httable.Clear();
            httable.Add("@UserID", Convert.ToString(Session["UserId"].ToString()));
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());

            dtRead = dataAccess.Common_exec_reader_prc("prc_GetAgnCode", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCode End


            // dtRead = dataAccess.Common_exec_reader("Select AgentCode from Agn Where EmpCode= '" + Convert.ToString(Session["UserId"].ToString()) + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND AgentStatus='IF'");
            //12
            if (dtRead.Read())
            {
                strIntAgentCode = dtRead[0].ToString();
            }
            dtRead.Close();
            if (strIntAgentCode.Trim().ToString() == "")
            {
                strEmpAgentCode = Convert.ToString(Session["UserId"].ToString());
            }
        }
        htParam.Add("@CarrierCode", Convert.ToInt32(Session["CarrierCode"].ToString()));
        htParam.Add("@LanguageCode", Session["LanguageCode"].ToString());
        htParam.Add("@Type", ViewState["vwsType"].ToString());
        htParam.Add("@AgentCode", txtAgntCode.Text);
        htParam.Add("@DirectGrpLeader", "");
        htParam.Add("@Surname", "");
        htParam.Add("@Givenname", "");
        htParam.Add("@CurrentId", txtPAN.Text);
        htParam.Add("@AgentStatus", ddlAgntStatus.SelectedValue);
        htParam.Add("@AgentType", ddlAgntType.SelectedValue);
        htParam.Add("@DirectAgtCode", txtImmLeaderCode.Text.Trim());
        htParam.Add("@MgrSapCode", txtMgrSapCode.Text.Trim());
        htParam.Add("@UnitCode", txtUnitCode.Text);
        if (txtDTJoinFrom.Text.Trim() != "")
        {
            htParam.Add("@RecruitDate", DateTime.Parse(txtDTJoinFrom.Text).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@RecruitDate ", System.DBNull.Value);
        }
        if (txtDTJoinTo.Text.Trim() != "")
        {
            htParam.Add("@CreateDtim", DateTime.Parse(txtDTJoinTo.Text).ToString("yyyyMMdd"));
        }
        else
        {
            htParam.Add("@CreateDtim ", System.DBNull.Value);
        }
        if (ViewState["vwsType"].ToString() == "N")
        {
            htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        }
        else if (ViewState["vwsType"].ToString() == "E")
        {
            htParam.Add("@bizSrc", ddlSlsChnnl.SelectedValue);
            htParam.Add("@Chncls", ddlChnCls.SelectedValue);
        }
        htParam.Add("@AgentName", txtAgntName.Text);
        htParam.Add("@CSCCode", txtCSCCode.Text);
        htParam.Add("@EMPCode", txtSapCode.Text);
        htParam.Add("@LinkRefAdv", txtLinkRef.Text);
        htParam.Add("@GCN", txtGCN.Text);
        htParam.Add("@LicNo", txtLicNo.Text);
        //Added by swapnesh on 11/12/2013 to add search parameter for reporting type start

        if (ddlRptTyp.SelectedValue != "ALL")
        {
            //rdbRptTyp.SelectedValue = "2";
            htParam.Add("@RptTyp", ddlRptTyp.SelectedValue);
        }
        else
        {
            htParam.Add("@RptTyp", "");
        }
        htParam.Add("@ChnlTyp", rdbChnlTyp.SelectedValue);
        //if (rdbPosn.SelectedValue == "0")
        //{
        //    htParam.Add("@posn", "yes");
        //}
        //else
        //{
        //    htParam.Add("@posn", "no");
        //}
        if (ddlPosition.SelectedValue == "0")
        {
            htParam.Add("@posn", DBNull.Value);
        }
        else if (ddlPosition.SelectedValue == "1")
        {
            htParam.Add("@posn", "yes");
        }
        else
        {
            htParam.Add("@posn", "no");
        }
        htParam.Add("@AgentRole", hdnAgentRole.Value.Trim());
        //Added by swapnesh on 11/12/2013 to add search parameter for reporting type end
        if (strUsrType == "0")
        {
            htParam.Add("@UserId", Session["UserID"].ToString());
        }
        else if (strIntAgentCode.Trim().ToString() != "")
        {
            htParam.Add("@UserId", strIntAgentCode.Trim().ToString());
        }
        if (strAgnCreateRule.Trim() == "")
        {
            //13


            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCreateRul,UnitRank Start
            httable.Clear();
            httable.Add("@CarrierCode", "");
            httable.Add("@AgentType", ddlAgntType.SelectedValue.ToString());
            httable.Add("@BizSrc", ddlSlsChnnl.SelectedValue.ToString());
            httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString());
            httable.Add("@flag", 3);

            dtRead = dataAccess.Common_exec_reader_prc("prc_getUnitRankAgentCreateRul", httable);

            //Added by asrar on 03/07/2013 to convert inline query into proc to get AgentCreateRul,UnitRank End


            //dtRead = dataAccess.exec_reader("Select AgentCreateRul,UnitRank From chnAgnSu where AgentType='" + ddlAgntType.SelectedValue + "' AND BizSrc='" + ddlSlsChnnl.SelectedValue + "' AND ChnCls='" + ddlChnCls.SelectedValue + "'");
            if (dtRead.Read())
            {


                strUntRnk = Convert.ToDecimal(dtRead[0].ToString());
                strAgnCreateRule = dtRead[1].ToString();
            }
            dtRead.Close();
        }


        //if (ddlAgntType.SelectedValue == "EC" || ddlAgntType.SelectedValue == "ES")
        //{


        //    if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //    }
        //    else
        //    {
        //        if (strIntAgentCode.Trim().ToString() != "")
        //        {
        //            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //        }
        //        else if (strEmpAgentCode.Trim().ToString() != "")
        //        {
        //            dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
        //        }

        //    }
        //}
        //else
        //{
        //if (strUntRnk < 7)
        //{

        //        if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
        //    }
        //    else
        //        {
        //            if (strIntAgentCode.Trim().ToString() != "")
        //            {
        //                dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList_User", htParam);
        //            }
        //            else if (strEmpAgentCode.Trim().ToString() != "")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
        //    }

        //}

        //    }
        //else
        //{

        //        if (strUsrType == "0")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //    }
        //    else
        //        {
        //            if (strIntAgentCode.Trim().ToString() != "")
        //            {
        //                dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList_User", htParam);
        //            }
        //            else if (strEmpAgentCode.Trim().ToString() != "")
        //    {
        //        dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqAgentList", htParam);
        //            }

        //        }
        //    }
        //}


        //dsResult = dataAccess.GetDataSetForPrc("prc_AgyAdmin_EnqMgrList", htParam);
        //return dsResult.Tables[0];





        //Added By Prathamesh 2-12-15
        httable.Clear();

        //httable.Add("@AgentCode ", txtAgntCode.Text.ToString().Trim());
        //httable.Add("@Givenname", txtAgntName.Text.ToString().Trim());
        //httable.Add("@Reltype", ddlRptTyp.SelectedValue.ToString().Trim());
        //httable.Add("@RptUnittype", ddlUnits.SelectedValue.ToString().Trim());
        //httable.Add("@RptMgrcode", txtImmLeaderCode.Text.ToString().Trim());
        //httable.Add("@RptMgrSapcode", txtMgrSapCode.Text.ToString().Trim());
        //httable.Add("@MemSapcode", txtSapCode.Text.ToString().Trim());


        //httable.Add("@Pan", txtPAN.Text.ToString().Trim());
        //httable.Add("@Channel", ddlSlsChnnl.SelectedValue.ToString().Trim());
        //httable.Add("@SubChannel", ddlChnCls.SelectedValue.ToString().Trim());
        //httable.Add("@Memstatus", ddlAgntStatus.SelectedValue.ToString().Trim());
        //httable.Add("@EmpType", ddlAgntType.SelectedValue.ToString().Trim());
        //httable.Add("@licNo", txtLicNo.Text.ToString().Trim());
        //httable.Add("@DtFrom", txtDTJoinFrom.Text.ToString().Trim());
        //httable.Add("@DtTo", txtDTJoinTo.Text.ToString().Trim());


        httable.Add("@MemCode", txtAgntCode.Text.ToString().Trim());
        httable.Add("@Givenname", txtAgntName.Text.ToString().Trim());
        httable.Add("@Reltype", ddlRptTyp.SelectedValue.ToString().Trim());
        httable.Add("@rptunittype", ddlUnits.SelectedValue.ToString().Trim());
        httable.Add("@unittype", ddlUnitType.SelectedValue.ToString().Trim());
        httable.Add("@RptMgrcode", txtImmLeaderCode.Text.ToString().Trim());
        httable.Add("@RptMgrSapcode", txtMgrSapCode.Text.ToString().Trim());
        httable.Add("@MemSapcode", txtSapCode.Text.ToString().Trim());


        httable.Add("@pan", txtPAN.Text.ToString().Trim());
        httable.Add("@bizSrc", ddlSlsChnnl.SelectedValue.ToString().Trim());
        httable.Add("@ChnCls", ddlChnCls.SelectedValue.ToString().Trim());
        httable.Add("@MemStatus", ddlAgntStatus.SelectedValue.ToString().Trim());
        httable.Add("@LicNo", txtLicNo.Text.ToString().Trim());
        httable.Add("@MemRole", hdnAgentRole.Value.ToString().Trim());
        httable.Add("@posn", ddlPosition.SelectedValue.ToString().Trim());
        httable.Add("@Unitcode", txtUnitCode.Text.ToString().Trim());
        httable.Add("@EmpType", ddlAgntType.SelectedValue.ToString().Trim());
        httable.Add("@flag", 1);


        dsResult = dataAccess.GetDataSetForPrc("prc_TeamView", httable);
        return dsResult.Tables[0];
    }
    #endregion



    protected void lnkTab4_Click(object sender, ImageClickEventArgs e)
    {
        Panel3.Visible = true;
        iFrame2.Visible = true;
        lnkTab4.ImageUrl = "~/theme/iflow/tabs/Organization Chat.png";
        lnkTab5.ImageUrl = "~/theme/iflow/tabs/grid1.png";
        trDgDetails.Visible = false;
    }

    //private static void BindToDataSet(RadOrgChart orgChart, string strEmpCode, string Flag)
    //{
    //    DataAccessClass dtAccess = new DataAccessClass();

    //    DataSet dsResult = new DataSet();
    //    Hashtable htParam = new Hashtable();
    //    htParam.Add("@AgentCode", strEmpCode);
    //    htParam.Add("@Flag", Flag);
    //    dsResult = dtAccess.GetDataSetForPrcCLP("Prc_GetDataForHierarchy_T", htParam);


    //    orgChart.DataTextField = "Name";
    //    orgChart.DataFieldID = "ID";
    //    orgChart.DataTextField = "Parentid";
    //    orgChart.DataImageUrlField = "Photo";
    //    orgChart.DataSource = dsResult;
    //    orgChart.DataBind();
    //}


    protected void RadOrgChart1_DrillDown1(object sender, OrgChartDrillDownEventArguments e)
    {
        isDrillDown = true;
        // BindToDataSet(RadOrgChart1, e.SourceNode.ID.ToString());
    }

    protected void hdnAgentRole_ValueChanged(object sender, EventArgs e)
    {

    }

    protected void lnkTab5_Click(object sender, ImageClickEventArgs e)
    {
        lnkTab4.ImageUrl = "~/theme/iflow/tabs/org2.png";
        lnkTab5.ImageUrl = "~/theme/iflow/tabs/grid2.png";
       //tbDetails.Visible = true;
       // trDetails.Visible = true;
        lblAgtSrchRes.Visible = true;
        trDgDetails.Visible = true;

        BindDataGrid();
    }

    protected void MultiChannel()
    {
        if (ddlRptTyp.SelectedValue == "CF")
        {
            //DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
            DataSet dsChn = GetChannel(ddlSlsChnnl, 1);
            DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
           DataSet dsEmpType = GetEmpType(ddlAgntType, 5);
           DataSet ds1 = GetRptUnitType1(ddlUnits, 9);
           DataSet ds = GetRptUnitType(ddlUnitType, 8);
           httable.Clear();
            if (ddlSlsChnnl.SelectedValue == "All")
            {
                // txtImmLeaderCode.Text = "";
                //}
                //else
                //{

                var table = dsChn.Tables[0];
                if (table.Rows.Count > 0)
                {
                    httable.Add("@flag", 1);
                    httable.Add("@RptMgrSapcode", txtMgrSapCode.Text);
                    //httable.Add("@Channel", ddlSlsChnnl.SelectedItem.Text);
                    dsResult = dataAccess.GetDataSetForPrc("prc_TeamView_EnqMgrList", httable);
                    string strChncls = dsResult.Tables[0].Rows[0]["chncls"].ToString();
                    strChncls = strChncls.Substring(2);
                    ddlRptTyp.Items.Remove(ddlRptTyp.Items[2]);
                    if (strChncls == "LM" || strChncls == "XX")
                    {
                        ddlRptTyp.Items.Remove(ddlRptTyp.Items[1]);

                    }

                    if (dsChn.Tables[0].Rows.Count > 1)
                    {
                        Flag1 = "1";
                    }

                    else
                    {
                        Flag1 = "2";
                    }
                        
                       
                 
                }

                


            }

           

            else
            {
                //DataSet dsChncls = GetSubChannel(ddlChnCls, 3);
                httable.Add("@flag", 11);
                httable.Add("@RptMgrSapcode", txtMgrSapCode.Text);
                httable.Add("@Channel", ddlSlsChnnl.SelectedValue);
                httable.Add("@SubChannel", ddlChnCls.SelectedValue);

                //httable.Add("@RptMgrcode", txtImmLeaderCode.Text);
                dsResult = dataAccess.GetDataSetForPrc("prc_TeamView_EnqMgrList", httable);
                
                
                string strChncls = dsResult.Tables[0].Rows[0]["chncls"].ToString();
                strChncls = strChncls.Substring(2);
               
                
                // ddlRptTyp.Items.Remove(ddlRptTyp.Items[2]);
                //if (strChncls == "LM" || strChncls == "XX")
                //{
                //    ddlRptTyp.Items.Remove(ddlRptTyp.Items[1]);

                //}

                txtImmLeaderCode.Text = dsResult.Tables[0].Rows[0][0].ToString();
                txtImmLeaderCode.Enabled = false;

            }

        }
    }


    #region Link lnkTab1_Click
    protected void Employee_Click(object sender, EventArgs e)
    {
        hdnAgentRole.Value = "E";
        Response.Redirect("TeamView.aspx?ID=" + Request.QueryString["ID"].ToString().Trim() + "&Type=" + Request.QueryString["Type"].ToString().Trim() + "");
    }
    #endregion
}





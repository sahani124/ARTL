using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_CmpSetup : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strCompCode = null;
    //string sUserId = null;
    string sUserId = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        Page.Form.DefaultButton = btnok.UniqueID;
        btnok.Focus();

        string sUserId = HttpContext.Current.Session["UserID"].ToString();

        if (txtCompDesc1.Text != null)
        {
            divC.Visible = true;
        }
        else
        {
            divC.Visible = false;
        }

        if (Request.QueryString["CmpCode"] != null)
        {
            if (Request.QueryString["CmpCode"].ToString().Trim() != "")
            {

                BindCnstGrid(Request.QueryString["CmpCode"].ToString().Trim());
            }
        }

        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (HttpContext.Current.Session["UserID"].ToString() != null)
        {
            sUserId = HttpContext.Current.Session["UserID"].ToString();
        }

        //For Validation For Status......................

        if (!IsPostBack)
        {
            
                // added by Amit on 31 jan 2019
                divCompuRule.Attributes.Add("style", "display:none");
                divCompuRule1.Attributes.Add("style", "display:none");
                // Ended by Amit on 31 jan 2019

            if (Request.QueryString["Mode"] != null)
            {
                if (Request.QueryString["Mode"].ToString().Trim() == "V")
                {
                    chkQual.Enabled = false;
                    ////txtRemark.Text = "";
                    btOK.Enabled = false;
                    btnSave.Enabled = false;
                    //btnAddCntst.Enabled = false;
                    btOK.Enabled = true;
                    btnSaveCntst.Enabled = false;
                       // btncycle.Enabled = false;
                    //btOK.Enabled = false;
                    btncmp.Enabled = false;
                    // chkQual.Enabled = false;
                    
                }
                else if (Request.QueryString["Mode"].ToString().Trim() == "R")
                {
                    btOK.Enabled = false;
                    //btnSave.Enabled = false;
                   // //btnAddCntst.Enabled = false;
                    btOK.Enabled = true;
                    btnSaveCntst.Enabled = false;
                       // btncycle.Enabled = false;
                    //btOK.Enabled = false;
                    btncmp.Enabled = false;
                    // chkQual.Enabled = false;
                    
                }
                else if (Request.QueryString["Mode"].ToString().Trim() == "C")
                {
                   // //btnAddCntst.Enabled = true;
                }
            }
            //chkQual.Enabled = false;
               // btncycle.Visible = false;
            if (Request.QueryString["flag"] != null)
            {
            if (Request.QueryString["flag"].ToString().Trim() != "N")
            {
                BindCnstGrid(lblCompCode.Text.ToString());
            }
            }

            
            if (txtCompDesc1.Text != null)
            {
                divC.Visible = true;
            }
            else
            {
                divC.Visible = false;
            }
            ddlStatusR.SelectedIndex = 0;
            ddlStatusR.Enabled = false;
            txtRemark.Enabled = false;
            FillDropDowns(ddlAccCyc, "8", "", "");
            FillDropDowns(ddlAccYear, "9", "", "");


  if (Request.QueryString["CmpTyp"].ToString() == "CON")
            {

             
                txtEffDtTo.Enabled = true;
                txtEffDtFrm.Enabled = true;


            }
			
            if (Request.QueryString["CmpTyp"].ToString() == "COM")
            {
                    lblCompDesc2.Text = "Compensation Description";
                    ddlAccYear.Items.RemoveAt(2); 
                // added by amit marathe on 30 nov 2018
                    divExtended.Attributes.Add("style", "display:none");
                    divExtended1.Attributes.Add("style", "display:none");
                    divcbSingelCycle.Attributes.Add("style", "display:none"); //added by amit

                    // added by amit on 28 feb 2019
                    FillDropDowns(ddlAccrCyc, "8", "", "");
                    FillDropDowns(ddlAccCyc, "8", "", "");
                    //ddlAccCyc.Items.Insert(0, new ListItem("Select", ""));
                    ddlAccrCyc.Items.Insert(0, new ListItem("Select", ""));
                    FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
                    ddlRwdRlsCyc.Items.Insert(0, new ListItem("Select", ""));
                    FillRwdRlsCyc(ddlRewardComputation, "22", "");
                    ddlRewardComputation.Items.Insert(0, new ListItem("Select", ""));
                   // added by amit on 28 feb 2019
                // ended by amit marathe on 30 nov 2018
            }
                // Added by amit marathe on 30 jan 2019
                if (Request.QueryString["CmpTyp"].ToString() == "INC" || Request.QueryString["CmpTyp"].ToString() == "BS" || Request.QueryString["CmpTyp"].ToString() == "APR")
                {
                    lblCompDesc2.Text = "Compensation Description";
                    divcbSingelCycle.Attributes.Add("style", "display:none");
                    // added by amit on 28 feb 2019
                    FillDropDowns(ddlAccrCyc, "8", "", "");
                    FillDropDowns(ddlAccCyc, "8", "", "");
                    //ddlAccCyc.Items.Insert(0, new ListItem("Select", ""));
                    ddlAccrCyc.Items.Insert(0, new ListItem("Select", ""));
                    FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
                    ddlRwdRlsCyc.Items.Insert(0, new ListItem("Select", ""));
                    FillRwdRlsCyc(ddlRewardComputation, "22", "");
                    ddlRewardComputation.Items.Insert(0, new ListItem("Select", ""));
                    // Ended by amit on 28 feb 2019
                }
                if (Request.QueryString["CmpTyp"].ToString() == "CON")
                {
                    // added by amit on 28 feb 2019
                    //ddlAccCyc.Items.Insert(0, new ListItem("Select", ""));
                    ddlAccrCyc.Items.Insert(0, new ListItem("Select", ""));
                    FillDropDowns(ddlAccCyc, "8", "", "");
                    ddlAccCyc.SelectedIndex = 7;
                    ddlAccCyc.Enabled = false;
                    FillDropDowns(ddlAccrCyc, "8", "", "");
                    //ddlAccrCyc.SelectedIndex = 7;
                    rdSingleCycle.Checked = true;
                    ddlAccrCyc.SelectedValue = "1008";
                    ddlAccrCyc.Enabled = false;
                    FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
                    ddlRwdRlsCyc.Items.Insert(0, new ListItem("Select", ""));
                    ddlRwdRlsCyc.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
                    FillRwdRlsCyc(ddlRewardComputation, "22", "");
                    ddlRewardComputation.Items.Insert(0, new ListItem("Select", ""));
                    ddlRewardComputation.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
                    divExtended.Attributes.Add("style", "display:none");
                    divExtended1.Attributes.Add("style", "display:none");
                    SetTdiv.Attributes.Add("style", "display:none");
                    SetTdiv1.Attributes.Add("style", "display:none");
                    //ended by amit 
                    
                    lblCompDesc2.Text = "Is Single Cycle";
                    divCompDesc2.Attributes.Add("style", "display:none");
                    divEffDtFrm.Attributes.Add("style", "display:none");
                    divVerEffFrm.Attributes.Add("style", "display:none");
                   
                }
                // Ended by amit marathe on 30 jan 2019
            if (Request.QueryString["CmpTyp"] != null)
            {
                FillDropDowns(ddlCompType, "24", "", Request.QueryString["CmpTyp"].ToString().Trim());
                   
                }


            FillDropDowns(ddlStatus, "11", "", "");

            FillDropDowns(ddlAccrCyc, "8", "", "");


            FillDropDowns(ddlCmptnRule, "33", "", "P");

                //ddlAccCyc.Items.Insert(0, new ListItem("Select", ""));
                ddlAccYear.Items.Insert(0, new ListItem("Select", ""));
                ddlCompType.Items.Insert(0, new ListItem("Select", ""));
                ddlStatus.Items.Insert(0, new ListItem("Select", ""));
                ddlBusiYear.Items.Insert(0, new ListItem("Select", ""));
                ddlAccrCyc.Items.Insert(0, new ListItem("Select", ""));
                ddlRwdRlsCyc.Items.Insert(0, new ListItem("Select", ""));
                // ddlStatus.Items.Insert(0, new ListItem("Select", ""));  commented by amit 
                ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
                ddlCmptnRule.Items.Insert(0, new ListItem("Select", ""));
                ddlRewardComputation.Items.Insert(0, new ListItem("Select", ""));
                ddlCompType.SelectedIndex = 1;
                ddlCompType.Enabled = false;
                if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "N")
                {
                    txtVer.Text = "1.00";
                    FillDropDowns(ddlStatus, "12", "", "");
                    //Bhau ddlStatus.Items.Insert(0, new ListItem("Select", ""));
                    ////btnAddCntst.Enabled = false;
                    ddlStatus.Enabled = false;
                    GetMaxCmpCode();
                    BindAuditGrid(txtCompCode.Text.ToString().Trim());
                }
                else if (Request.QueryString["flag"].ToString().Trim() == "E")
                {
                    FillCmpDetails();
                    BindAuditGrid(txtCompCode.Text.ToString().Trim());
                    FillDropDowns(ddlStatusR);
                        //btnAddCntst.Enabled = true;

                    //if (!(sUserId == "cmpreview" || sUserId == "cmpchecker"))
                    //{
                    //    //btnAddCntst.Enabled = true;
                    //}
                    ddlStatus.Enabled = false;
                    //CalendarExtender1.Enabled = false;
                    //CalendarExtender2.Enabled = false;
                    //CalendarExtender3.Enabled = false;
                    //CalendarExtender4.Enabled = false;
                    if (ddlAccCyc.SelectedIndex == 2)
                    {
                           // btncycle.Visible = true;
                    }
                    else
                    {
                           // btncycle.Visible = false;
                    }
                    //if (ddlStatus.SelectedValue == "1006")
                    //{
                    //    chkQual.Enabled = false;
                    //}

                    // ddlStatus.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            if (Request.QueryString["CmpCode"] != null)
            {
                BindCnstGrid(Request.QueryString["CmpCode"].ToString().Trim());
                BindAuditGrid(txtCompCode.Text.ToString().Trim());
                FillDropDowns(ddlStatusR);
            }
            else
            {
                BindCnstGrid("");
            }
            //if (Request.QueryString["mode"] != null)
            //{
            //    if (Request.QueryString["mode"].ToString() == "V" && Request.QueryString["mode"].ToString() == "R")
            //    {
            //        tbladdcmpst.Visible = false;
            //        tbladdcntst.Visible = false;
            //        Table2.Visible = false;
            //        divC.Visible = false;
            //        FillCmp();
            //        divcmphdrcollapse.Visible = false;
            //        divcmphdrview.Visible = true;
            //    }
            //}
            if (ddlStatus.SelectedValue == "1002")
            {
                lblcheck.Text = "Completed review click ok to submit for revision or approve.";
            }

            if (ddlStatus.SelectedValue == "1005")
            {
                lblcheck.Text = "Completed review click ok to submit for final approve.";
            }

            //Added By Bhaurao.....Additional
            ////if (sUserId == "cmpreview")
            if (Request.QueryString["Mode"] != null)
            {
                if (Request.QueryString["Mode"].ToString().Trim() == "R")
                {
                    tbladdcmpst.Visible = false;
                    tbladdcntst.Visible = false;
                    divC.Visible = false;
                    FillCmp();
                    divcmphdrcollapse.Visible = false;
                    divcmphdrview.Visible = true;

                    #region flag type1
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString().Trim() == "Btch" || Request.QueryString["flag"].ToString().Trim() == "Stmt")
                        {
                            tbladdcmpst.Visible = false;
                            tbladdcntst.Visible = false;
                            divC.Visible = false;
                            FillCmp();
                            divcmphdrcollapse.Visible = false;
                            divcmphdrview.Visible = true;
                            if (dgSubCntst.Rows.Count > 0)
                            {
                                if (dgSubCntst.Rows[0].Cells[0].Text != "No contestants have been defined")
                                {
                                    foreach (GridViewRow gvRowCnt in dgSubCntst.Rows)
                                    {
                                        LinkButton lnkSubCnstCode = (LinkButton)gvRowCnt.FindControl("lnkSubCnstCode");
                                        lnkSubCnstCode.Enabled = false;
                                    }
                                }
                            }
                            dgCntst.Columns[7].Visible = false;
                            dgCntst.Columns[8].Visible = false;
                            dgSubCntst.Columns[6].Visible = false;
                            CtrlEnblDsbl();
                        }
                        else
                        {
                            dgCntst.Columns[7].Visible = true;
                            dgCntst.Columns[8].Visible = true;
                            dgSubCntst.Columns[6].Visible = true;
                        }
                    }
                    else
                    {
                        dgCntst.Columns[7].Visible = true;
                        dgCntst.Columns[8].Visible = true;
                        dgSubCntst.Columns[6].Visible = true;
                    }
                    #endregion
                }
                else if (Request.QueryString["Mode"].ToString().Trim() == "C")
                {
                    #region flag type 2
                    if (Request.QueryString["flag"] != null)
                    {
                        if (Request.QueryString["flag"].ToString().Trim() == "Btch" || Request.QueryString["flag"].ToString().Trim() == "Stmt")
                        {
                            tbladdcmpst.Visible = false;
                            tbladdcntst.Visible = false;
                            divC.Visible = false;

                            FillCmp();
                            divcmphdrcollapse.Visible = false;
                            divcmphdrview.Visible = true;
                            if (dgSubCntst.Rows.Count > 0)
                            {
                                if (dgSubCntst.Rows[0].Cells[0].Text != "No contestants have been defined")
                                {
                                    foreach (GridViewRow gvRowCnt in dgSubCntst.Rows)
                                    {
                                        LinkButton lnkSubCnstCode = (LinkButton)gvRowCnt.FindControl("lnkSubCnstCode");
                                        lnkSubCnstCode.Enabled = false;
                                    }
                                }
                            }
                            dgCntst.Columns[7].Visible = false;
                            dgCntst.Columns[8].Visible = false;
                            dgSubCntst.Columns[6].Visible = false;
                        }
                        else
                        {
                            dgCntst.Columns[7].Visible = true;
                            dgCntst.Columns[8].Visible = true;
                            dgSubCntst.Columns[6].Visible = true;
                        }
                    }
                    else
                    {
                        dgCntst.Columns[7].Visible = true;
                        dgCntst.Columns[8].Visible = true;
                        dgSubCntst.Columns[6].Visible = true;
                    }
                    #endregion
                }
            }

           
            
            CtrlEnblDsbl();

            if (ddlStatus.SelectedIndex == 5)
            {
                foreach (GridViewRow gvRow1 in dgCntst.Rows)
                {
                    LinkButton lnkMem = (LinkButton)gvRow1.FindControl("lnkAddMembers");
                    lnkMem.OnClientClick = "return false";
                }
            }
            
        }


        ddlExtendedDate.Items.Insert(0, new ListItem("Select", ""));
        //uncomment by Prathamesh on 28_02_2018 start
        BindCnstGrid(txtCompCode.Text.ToString().Trim());
        //uncomment by Prathamesh on 28_02_2018 start
        btnAddCntst.Attributes.Add("onclick", "funPopUp('" + txtCompCode.Text.ToString().Trim() + "','" + txtCompDesc1.Text.ToString().Trim() + "','1','2');return false;");
        ButtonDisplay();
            // GetEnblDsblCtrlsts("", "CmpSetup", "Page_Load");  //**commented on 23 may 20
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {


        CheckDateRange();

    }

    private void CheckDateRange()
    {
        htParam.Clear();
        ds.Clear();

        htParam.Add("@BUSI_CODE", ddlBusiYear.SelectedValue.ToString().Trim());
        htParam.Add("@Date", txtEffDtFrm.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("PRC_CHECK_DATE_IN_RANGE", htParam);

        string flag = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = ds.Tables[0].Rows[0]["Flag"].ToString();



            }

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "FuncheckDateWithiBusinessYear('" + flag + "');", true);
    }


    protected void ButtonDisplay()
    {
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            // }  //**commented on 23 may 20
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_CMPN_STATUS", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["status"].ToString() == "1006")
                {
                    btnAddCntst.Visible = false;
                    btnSave.Visible = false;

                }
            }
        }
    
    }


    #region FillCmp
    protected void FillCmp()
    {
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblCompCodeVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
            lblCompDesc1Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
            lblCompDesc2Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
            lblAccCycVal.Text = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString().Trim();
            lblAccYrVal.Text = ds.Tables[0].Rows[0]["ACC_YEAR"].ToString().Trim();
            lblCompTypVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString().Trim();
            lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
            lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
            lblAccrCycleValue.Text = ds.Tables[0].Rows[0]["ACCURAL_CYCLE_DESC"].ToString().Trim();
            lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE_DESC"].ToString().Trim();
            lblBusYr.Text = ds.Tables[0].Rows[0]["BUSI_DESC"].ToString().Trim();
            lblVersion.Text = ds.Tables[0].Rows[0]["VERSION"].ToString().Trim();
            lblVerDtFrmVal.Text = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
            lblVerDtToVal.Text = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();
            lblStatVal.Text = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
            string trgrule = ds.Tables[0].Rows[0]["SET_TRG_RULE"].ToString().Trim();
            if (trgrule == "1001")
            {
                lblSetTrgRulVal.Text = "Set full period target and split by cycle";
            }
            else if (trgrule == "1002")
            {
                lblSetTrgRulVal.Text = "Set target by cycle";
            }

        }
    }
    #endregion

    public void CtrlEnblDsbl()
    {
        try
        {
        var status = string.Empty;
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CmpCode", Request.QueryString["CmpCode"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpStatus", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                status = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
            }
            else
            {
                status = ddlStatus.SelectedValue.ToString().Trim();
            }
        }
        if (Request.QueryString["Mode"] != null)
        {
            if (Request.QueryString["Mode"].ToString().Trim() == "C")
            {

                if (HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpchecker" || HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpmaker")
                {

                    if (status == "1001" || status == "1002" || status == "1003" || status == "1004" || status == "1006" || status=="")
                    {
                        //btnSave.Enabled = false;
                        //btncycle.Enabled = false;
                        //btnAddCntst.Enabled = false;
                        dgCntst.Columns[7].Visible = false;
                        dgCntst.Columns[8].Visible = false;
                        dgSubCntst.Columns[6].Visible = false;
                        chkQual.Enabled = true;
                        btOK.Enabled = false;

                    }

                    else 
                    {
                        //commented on 02/apr/2018
                        txtCompDesc1.Enabled = false;
                        txtCompDesc2.Enabled = false;
                        ddlAccCyc.Enabled = false;
                        ddlCompType.Enabled = false;
                        ddlAccrCyc.Enabled = false;
                        ddlRwdRlsCyc.Enabled = false;
                        txtVer.Enabled = false;
                        ddlCmptnRule.Enabled = false;
                        ddlAccYear.Enabled = false;
                        ddlBusiYear.Enabled = false;
                        txtEffDtFrm.Enabled = false;
                       // txtEffDtTo.Enabled = false;
                        txtVerEffFrm.Enabled = false;
                        txtVerEffTo.Enabled = false;
                        ddlStatus.Enabled = false;
                        //lnkAddMemberSubCntst.Enabled = false;


                        btnSave.Enabled = false;
                           // btncycle.Enabled = false;
                        //btnAddCntst.Enabled = false;
                        dgCntst.Columns[7].Visible = false;
                        dgCntst.Columns[8].Visible = false;
                        dgSubCntst.Columns[6].Visible = false;
                        chkQual.Enabled = false;
                        btOK.Enabled = false;
                        //end
                    }
                        if (HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpmaker" && status == "1001")
                        {
                            //btnAddCntst.Enabled = true;
                        }
                        if (HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpmaker" && status == "1006")
                        {
                            btnSave.Enabled = false;
                        }


                }
            }
            else if (Request.QueryString["Mode"].ToString().Trim() == "R")
            {
                btnSave.Enabled = false;
                   // btncycle.Enabled = false;
                //btnAddCntst.Enabled = false;
                dgCntst.Columns[7].Visible = false;
                dgCntst.Columns[8].Visible = false;
                dgSubCntst.Columns[6].Visible = false;
                divC.Visible = true;

                if (status == "1001" || status == "1003" || status == "1006")
                {
                    chkQual.Enabled = false;
                    btOK.Enabled = false;
                }
                else
                {
                    chkQual.Enabled = true;
                    btOK.Enabled = false;
                }
            }
        }

        //if ((status == "1002") || (status == "1004") || (status == "1005"))
        //{
        //    chkQual.Enabled = true;
        //    if (chkQual.Checked == true)
        //    {
        //        btOK.Enabled = true;
        //    }
        //    else
        //    {

        //        ddlStatusR.SelectedIndex = 0;
        //        txtRemark.Text = "";
        //        btOK.Enabled = false;
        //    }
        //}
        ////else
        ////{
        ////    chkQual.Enabled = false;
        ////}

        //if ((ddlStatus.SelectedValue == "1005"))
        //{
        //    chkQual.Enabled = false;
        //    btOK.Enabled = false;
        //}

        //if ((status == "1001") || (status == "1003") || (status == "1005"))
        //{
        //    chkQual.Enabled = true;

        //    if (chkQual.Checked == true)
        //    {
        //        ddlStatusR.Enabled = true;
        //        txtRemark.Enabled = true;
        //        btOK.Enabled = true;
        //    }
        //    else
        //    {
        //        ddlStatusR.Enabled = false;
        //        txtRemark.Enabled = false;
        //        btOK.Enabled = false;
        //    }
        //}
        //else if (status == "1002")
        //{
        //    btnSave.Enabled = false;
        //    //btnAddCntst.Enabled = false;
        //    btnCnclCmp.Enabled = false;
        //    btnok.Enabled = false;
        //    chkQual.Enabled = false;
        //    dgCntst.Columns[7].Visible = false;
        //    dgCntst.Columns[8].Visible = false;
        //    dgSubCntst.Columns[6].Visible = false;
        //}
        //else
        //{
        //    chkQual.Enabled = false;
        //}

        //if (status == "1001" || status == "1003")
        //{

        //}
        //else
        //{
        //    btnSave.Enabled = false;
        //    btnCnclCmp.Enabled = false;
        //    //btnAddCntst.Enabled = false;
        //    btnSaveCntst.Enabled = false;
        //    btnok.Enabled = false;
        //    dgCntst.Columns[6].Visible = false;
        //}
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "CtrlEnblDsbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        CmpCreate();
        mdlpopup.Show();
        lbl3.Text = "Compensation Code Saved Successfully";
        lbl4.Text = "Compensation Code:  " + txtCompCode.Text.ToString().Trim();
        lbl5.Text = "Compensation Description:  " + txtCompDesc1.Text.ToString().Trim();

        btnSave.Enabled = false;
        if (!(sUserId == "cmpreview" || sUserId == "cmpchecker"))
        {
            //btnAddCntst.Enabled = true;
        }
        dgCntst.DataBind();

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "popup();", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCnclCmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompStpSrch.aspx?Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim());
    }

    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg)
    {
        try
        {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        ht.Add("@TYPFLG", typflg.ToString().Trim());
 	ht.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
            if (ddl == ddlAccCyc)
            {
                ddl.Items.Insert(0, new ListItem("Select", ""));
                ddl.SelectedIndex = 0;
            }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillCmpDetails()
    {
        try
        {
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_CmpTypSearch", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCompCode.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
            txtCompDesc1.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
            txtCompDesc2.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
            ddlAccCyc.SelectedValue = ds.Tables[0].Rows[0]["ACCCYCLE"].ToString().Trim();
            ddlAccYear.SelectedValue = ds.Tables[0].Rows[0]["ACCYEAR"].ToString().Trim();
            FillDropDowns(ddlBusiYear, "15", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()), "");
            ddlBusiYear.Items.Insert(0, new ListItem("Select", ""));
            ddlCompType.SelectedValue = ds.Tables[0].Rows[0]["CMPNSTNTYPE"].ToString().Trim();
            ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["STAT"].ToString().Trim();
            // ddlStatus.Enabled = false;
            txtEffDtFrm.Text = ds.Tables[0].Rows[0]["EFF_FROM"].ToString().Trim();
            txtEffDtTo.Text = ds.Tables[0].Rows[0]["EFF_TO"].ToString().Trim();
            ddlBusiYear.SelectedValue = ds.Tables[0].Rows[0]["FIN_YEAR"].ToString().Trim();
            txtVer.Text = ds.Tables[0].Rows[0]["VERSION"].ToString().Trim();
            txtVerEffFrm.Text = ds.Tables[0].Rows[0]["VER_EFF_FROM"].ToString().Trim();
            txtVerEffTo.Text = ds.Tables[0].Rows[0]["VER_EFF_TO"].ToString().Trim();
            rblSetTrgRul.SelectedValue = ds.Tables[0].Rows[0]["SET_TRG_RULE"].ToString().Trim();
            ddlAccrCyc.SelectedValue = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE"].ToString().Trim();
            FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
                FillRwdRlsCyc(ddlRewardComputation, "22", "");
            ddlRwdRlsCyc.SelectedValue = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE"].ToString().Trim();
            ddlCmptnRule.SelectedValue = ds.Tables[0].Rows[0]["SET_CMPTN_RULE"].ToString().Trim();
                ddlRewardComputation.SelectedValue = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE"].ToString().Trim();
            txtEffDtFrm.Enabled = false;
           // txtEffDtTo.Enabled = false;
            txtVerEffFrm.Enabled = false;
            txtVerEffTo.Enabled = false;
            ddlBusiYear.Enabled = false;
            ddlAccYear.Enabled = false;
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "FillCmpDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void CmpCreate()
    {
        try
        {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CompCode", txtCompCode.Text.ToString().Trim());
        htParam.Add("@CompDesc1", txtCompDesc1.Text.ToString().Trim());
        htParam.Add("@CompDesc2", txtCompDesc2.Text.ToString().Trim());
        htParam.Add("@AccCyc", ddlAccCyc.SelectedValue.ToString().Trim());
        htParam.Add("@AccYr", ddlAccYear.SelectedValue.ToString().Trim());
        htParam.Add("@BusiYr", ddlBusiYear.SelectedValue.ToString().Trim());
        htParam.Add("@CompType", ddlCompType.SelectedValue.ToString().Trim());
        htParam.Add("@Status", ddlStatus.SelectedValue.ToString().Trim());
        htParam.Add("@Version", txtVer.Text.ToString().Trim());
        htParam.Add("@IsExtendedDate",ddlExtendedDate.SelectedValue.ToString().Trim());//added by amit 
            //ADDED by amit 0n 31 jan 2019
            
           
            if (Request.QueryString["CmpTyp"].ToString() == "CON")
            {
                        if(rdSingleCycle.Checked==true)
                         {
                              htParam.Add("@IsSingleCycle", "Y");
                            }
            
                         if (rdSingleCycle1.Checked== true)
                         {
                             htParam.Add("@IsSingleCycle", "N");
                            }    
                
                if (txtEffDtFrm.Text == "")
                     {
                           htParam.Add("@EffDtFrm", System.DBNull.Value);
                     }
                    else
                    { 
                            htParam.Add("@EffDtFrm",Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
                    }
              }
                 else
                     {
                      if (txtEffDtFrm.Text == "")
                     {
                      htParam.Add("@EffDtFrm", System.DBNull.Value);
                     }
                else
                {
                     htParam.Add("@EffDtFrm", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
                     htParam.Add("@IsSingleCycle", "");

        }
            }
            if (Request.QueryString["CmpTyp"].ToString() == "CON")
            {
        if (txtEffDtTo.Text == "")
                {
                    htParam.Add("@EffDtTo", System.DBNull.Value);
                    }
                 else
                {
                    htParam.Add("@EffDtTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));
                }
                }
             else
                 {
                    if (txtEffDtTo.Text == "")
                    {
                        htParam.Add("@EffDtTo", System.DBNull.Value);
                    }   
                else
                {
            htParam.Add("@EffDtTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));
        }
            }
            if (Request.QueryString["CmpTyp"].ToString() == "CON")
            {
        if (txtVerEffFrm.Text == "")
        {
            htParam.Add("@VerEffFrm", System.DBNull.Value);
        }
        else
        {
                    htParam.Add("@VerEffFrm", Convert.ToDateTime(txtVerEffFrm.Text.ToString().Trim()));
                }
            }
            else
            {
                if (txtVerEffFrm.Text == "")
                {
                    htParam.Add("@VerEffFrm", System.DBNull.Value);
                }
                else
                {
            htParam.Add("@VerEffFrm", Convert.ToDateTime(txtVerEffFrm.Text.ToString().Trim()));
        }
            }

            if (Request.QueryString["CmpTyp"].ToString() == "CON")
            {
                 if (txtVerEffTo.Text == "")
                 {
                        htParam.Add("@VerEffTo", System.DBNull.Value);
                     }
        else
        {
                    htParam.Add("@VerEffTo", Convert.ToDateTime(txtVerEffTo.Text.ToString().Trim()));
                }
            }
            else
            {
                if (txtVerEffTo.Text == "")
                {
                    htParam.Add("@VerEffTo", System.DBNull.Value);
                }
                else
                {
            htParam.Add("@VerEffTo", Convert.ToDateTime(txtVerEffTo.Text.ToString().Trim()));
        }
            }
            //ended by amit 0n 31 jan 2019
        htParam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
        if (Request.QueryString["flag"] != null)
        {
            htParam.Add("@Flag", Request.QueryString["flag"].ToString().Trim());
        }
        htParam.Add("@SetTrgRul", rblSetTrgRul.SelectedValue.ToString().Trim());
        htParam.Add("@CmptnRul", ddlCmptnRule.SelectedValue.ToString().Trim());
        htParam.Add("@AccrCyc", ddlAccrCyc.SelectedValue.ToString().Trim());
        htParam.Add("@RwdRelCyc", ddlRwdRlsCyc.SelectedValue.ToString().Trim());
            htParam.Add("@RWD_CMP_CYCLE", ddlRewardComputation.SelectedValue.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpType", htParam);

        BindCnstGrid(txtCompCode.Text.ToString().Trim());
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "CmpCreate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetMaxCmpCode()
    {
        try
        {
        ds.Clear();
        htParam.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCompCode", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCompCode.Text = ds.Tables[0].Rows[0]["MaxCmpCode"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "GetMaxCmpCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
        string msg = string.Empty;
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)row.FindControl("lnkCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CMPNSTNCODE", lblCmpDsc.Value.ToString().Trim());
        htParam.Add("@CNTSTNCODE", lnkCnstCode.Text.ToString().Trim());
        htParam.Add("@FLAG", "2");
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
            if (msg == "NO DELETE")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contestant. Dependent contestant is assigned to this contestant');", true);
            }
        }
        BindCnstGrid(txtCompCode.Text.ToString().Trim());
        //DataTable dt = (DataTable)Session["grid"];
        //dt.Rows[rowIndex].Delete();
        //dt.AcceptChanges();
        //if (dt.Rows.Count > 0)
        //{
        //    dgCntst.DataSource = dt;
        //    dgCntst.DataBind();
        //}
        //else
        //{
        //    ShowNoResultFound(dt, dgCntst);
        //}

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindCnstGrid(string cmpcode)
    {
        try
        {
        ds.Clear();
        htParam.Clear();
        if (cmpcode != "")
        {
            htParam.Add("@CmpCode", cmpcode.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewState["parentmemmcode"] = ds.Tables[0].Rows[0]["CNTSTNT_CODE"].ToString();
                dgCntst.DataSource = ds.Tables[0];
                dgCntst.DataBind();
                ViewState["griddgCntst"] = ds.Tables[0];


                ////btnAddCntst.Enabled = true;
                //btnSaveCntst.Enabled = true;
                if (dgCntst.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
            }
            else
            {
                htParam.Clear();
                ds = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
                ShowNoResultFound1(ds.Tables[0], dgCntst);
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
                txtPage.Text = "1";
                ///////btnAddCntst.Enabled = false;
                btnSaveCntst.Enabled = false;

            }
        }
        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
            ShowNoResultFound1(ds.Tables[0], dgCntst);
            btnprevious.Enabled = false;
            btnnext.Enabled = false;
            txtPage.Text = "1";
            //btnAddCntst.Enabled = false;
            btnSaveCntst.Enabled = false;
        }
        Session["grid"] = ds.Tables[0];
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "BindCnstGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        try
        {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[columnsCount - 3].Text = "";
        gv.Rows[0].Cells[columnsCount - 4].Text = "";
        gv.Rows[0].Cells[columnsCount - 5].Text = "";
        gv.Rows[0].Cells[columnsCount - 6].Text = "";
        gv.Rows[0].Cells[columnsCount - 7].Text = "";
        //gv.Rows[0].Cells[columnsCount - 8].Text = "";
        gv.Rows[0].Cells[0].Text = "No contestants have been defined";

        source.Rows.Clear();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    private void ShowNoResultFound1(DataTable source, GridView gv)
    {
        try
        {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;

        gv.Rows[0].Cells[0].Text = "";
        gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[1].Text = "No contestants have been defined";
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[2].Text = "";
        gv.Rows[0].Cells[3].Text = "";
        gv.Rows[0].Cells[4].Text = "";
        gv.Rows[0].Cells[5].Text = "";
        gv.Rows[0].Cells[6].Text = "";
        gv.Rows[0].Cells[7].Text = "";
        source.Rows.Clear();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btncmp_Click(object sender, EventArgs e)
    {
        try
        {
        BindCnstGrid(txtCompCode.Text.ToString().Trim());

        //uncomment by Prathamesh on 28_02_2018 start 
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtresult = new DataTable();
        if (Session["CMP"] != null)
        {
            //dt = (DataTable)Session["CMP"];
            dtresult = (DataTable)Session["grid"];
            //dtresult.Merge(dt, true, MissingSchemaAction.Ignore);
            dgCntst.DataSource = null;
            dgCntst.DataBind();
            dgCntst.DataSource = dtresult;
            dgCntst.DataBind();
            Session["grid"] = dtresult;
        }
        //uncomment by Prathamesh on 28_02_2018 start

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btncmp_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSaveCntst_Click(object sender, EventArgs e)
    {
        ////CntstCreate();
    }

    protected void dgCntst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDel = (LinkButton)e.Row.FindControl("lnkDelete");
            LinkButton lnkVwStmt = (LinkButton)e.Row.FindControl("lnkVwStmt");
            LinkButton lnkAddSbCntst = (LinkButton)e.Row.FindControl("lnkAddSbCntst");
            LinkButton lnkCnstCode = (LinkButton)e.Row.FindControl("lnkCnstCode");
            HiddenField hdnPCnstCode = (HiddenField)e.Row.FindControl("hdnPCnstCode");
            BindSubCnstGrid(lnkCnstCode.Text.ToString().Trim());
            lnkDel.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete contestant code for " + lnkCnstCode.Text.ToString().Trim() + "?')");
            //if (Request.QueryString["flag"] != null)
            //{
            //    if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
            //    {
            //        dgCntst.Columns[7].Visible = false;
            //        dgCntst.Columns[8].Visible = false;
            //    }
            //    else if (Request.QueryString["flag"].ToString().Trim() == "Btch")
            //    {
            //        dgCntst.Columns[7].Visible = false;
            //        dgCntst.Columns[8].Visible = false;
            //    }
            //    else
            //    {
            //        dgCntst.Columns[7].Visible = true;
            //        dgCntst.Columns[8].Visible = true;
            //    }
            //}
            //else
            //{
            //    dgCntst.Columns[7].Visible = true;
            //    dgCntst.Columns[8].Visible = true;
            //}


            
        }

        if (ddlStatus.SelectedIndex == 5)
        {
            foreach (GridViewRow gvRow1 in dgCntst.Rows)
            {
                LinkButton lnkMem = (LinkButton)gvRow1.FindControl("lnkAddMembers");
                lnkMem.OnClientClick = "return false";
            }
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "dgCntst_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgCntst_Sorting(object sender, GridViewSortEventArgs e)
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

        BindCnstGrid(txtCompCode.Text.ToString().Trim());
        DataTable dt = (DataTable)ViewState["griddgCntst"];
        DataView dv = new DataView(dt);
        dv.Sort = dgSource.Attributes["SortExpression"];

        if (dgSource.Attributes["SortASC"] == "No")
        {
            dv.Sort += " DESC";
        }

        dgSource.PageIndex = 0;
        dgSource.DataSource = dv;
        dgSource.DataBind();
        if (dgSource.PageCount >= Convert.ToInt32(txtPage.Text))
        {
            btnprevious.Enabled = false;
            txtPage.Text = "1";
            btnnext.Enabled = false;
        }
        else
        {
            btnnext.Enabled = true;
        }
        /////ShowPageInformation();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "dgCntst_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex + 1;
            // dgCntst.DataSource = (DataTable)Session["grid"];
            // dgCntst.DataBind();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgCntst.PageCount))
            {
                btnnext.Enabled = false;
            }

            int page = dgCntst.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCntst.PageIndex;
            dgCntst.PageIndex = pageIndex - 1;
            dgCntst.DataSource = (DataTable)Session["grid"];
            dgCntst.DataBind();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlAccYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        FillDropDowns(ddlBusiYear, "15", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()), "");
        ddlBusiYear.Items.Insert(0, new ListItem("Select", ""));
        ddlAccYear.Focus();
       
            //added by amit on 27 nov
            if(ddlAccYear.SelectedValue.ToString().Trim()=="1003")
            {
                FillExtended(ddlExtendedDate);
	ddlExtendedDate.SelectedValue="N";
                ddlExtendedDate.Enabled = true;
	

    }
            else
            {
                ddlExtendedDate.Enabled = false;
                ddlExtendedDate.Items.Clear();
                ddlExtendedDate.Items.Insert(0, new ListItem("Select", ""));
            }

            //ended by amit on 27 nov
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlAccYear_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected string GetYearType(string val)
    {
        string yrtyp = string.Empty;
        try
        {
           
        DataSet dstype = new DataSet();
        Hashtable httype = new Hashtable();
        dstype.Clear();
        httype.Add("@ACC_YEAR_CODE", val.ToString().Trim());
        dstype = objDal.GetDataSetForPrc_SAIM("Prc_GetYearType", httype);
        if (dstype.Tables.Count > 0 && dstype.Tables[0].Rows.Count > 0)
        {
            yrtyp = dstype.Tables[0].Rows[0]["YEAR_TYPE"].ToString().Trim();
        }
           
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "GetYearType", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return yrtyp;
    }
    protected void ddlBusiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        GetDates("V", GetYearType(ddlAccYear.SelectedValue.ToString().Trim()), ddlBusiYear.SelectedValue.ToString().Trim());
        ddlBusiYear.Focus();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlBusiYear_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GetDates(string flag, string yrtyp, string busicode)
    {
        try
        {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@FLAG", flag.ToString().Trim());
        htParam.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        htParam.Add("@BUSI_CODE", busicode.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_BusiYrStp", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtEffDtFrm.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtEffDtTo.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
            txtVerEffFrm.Text = ds.Tables[0].Rows[0]["START_DATE"].ToString().Trim();
            txtVerEffTo.Text = ds.Tables[0].Rows[0]["END_DATE"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //ADDED BY KALYANI FOR DIVC
    protected void btOK_Click(object sender, EventArgs e)
    {
        try
        {
        //REMARK ENTRY
            if (ddlStatusR.SelectedValue=="")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Status')", true);
                return;

            }
            else
            {
                //Added non std validation by prity on 18 june 2019
                //DataSet DsNonStd = new DataSet();
                //Hashtable HtNonStd = new Hashtable();
                //HtNonStd.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
                //DsNonStd = objDal.GetDataSetForPrc_SAIM("Prc_exec_NS_validation_Status", HtNonStd);

                ////if (DsNonStd.Tables.Count > 0 && DsNonStd.Tables[0].Rows.Count > 0)
                ////{
                //if (DsNonStd.Tables[0].Rows[0]["RESULT"].ToString() == "Y")
                //{
                //    //string AlertMsg = DsNonStd.Tables[0].Rows[0]["MSG"].ToString().Trim();

                //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + AlertMsg + "' )", true);

                //    //return;


                //}
                //end of  non std validation 
                //else
                //{

                    //REMARK ENTRY
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CompRemark", txtRemark.Text.ToString().Trim());
        htParam.Add("@CompStat", ddlStatusR.SelectedValue.ToString().Trim());
        htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCompRemark", htParam);


        //AUDIT ENTRY
        ds.Clear();
        htParam.Clear();
        htParam.Add("@ActionFlag", "CH");
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        htParam.Add("@Remark", txtRemark.Text.ToString().Trim());
        htParam.Add("@Status", ddlStatusR.SelectedValue.ToString().Trim());
        htParam.Add("@Version", txtVer.Text.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsertCMPNSTN_AuditTrail", htParam);

        /////Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);
        Response.Redirect("CmpSetup.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
        txtRemark.Text = "";
               // }
            }
        //ds.Clear();
        //htParam.Clear();
        //htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        //htParam.Add("@CompStat", ddlStatus.SelectedValue.ToString().Trim());
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCmpStatus", htParam);
        //Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "GetDates", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void chkQual_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
        if (sUserId == "cmpreview" || sUserId == "cmpchecker")
        {
            if (ddlStatusR.SelectedItem.Text == "REVISION REQUIRED" || ddlStatusR.SelectedValue == "APPROVED")
            {     // btnok.Enabled = true;

                chkQual.Enabled = true;

                if (chkQual.Enabled == true)
                    btnok.Enabled = true;
                else
                    btnok.Enabled = false;

                ddlStatusR.Enabled = true;
                txtRemark.Enabled = true;
            }
        }


        if (chkQual.Enabled == true)
        {
            if (chkQual.Checked == true)
            {
                ddlStatusR.Enabled = true;
                txtRemark.Enabled = true;
                btOK.Enabled = true;
            }
            else
            {
                ddlStatusR.Enabled = false;
                ddlStatusR.SelectedIndex = 0;
                txtRemark.Enabled = false;
                txtRemark.Text = "";
                btnok.Enabled = false;

            }
        }
        else
        {
            ddlStatusR.Enabled = false;
            txtRemark.Enabled = false;
        }

        //if (chkQual.Checked == true)
        //{

        //    btOK.Enabled = true;
        //    ddlStatusR.Enabled = true;
        //    txtRemark.Enabled = true;
        //    BindCnstGrid(txtCompCode.Text.ToString());
        //    ddlStatusR.SelectedIndex = 0;
        //    //BindStatus();
        //    //// ddlStatusR.Items.Clear();
        //    // ddlStatusR.Items.Insert(0, new ListItem("Select", ""));



        //}
        //if (chkQual.Checked == false)
        //{
        //    ddlStatusR.SelectedIndex = 0;
        //    ddlStatusR.Enabled = false;
        //    txtRemark.Text = "";
        //    txtRemark.Enabled = false;
        //    //ddlStatusR.Items.Insert(0, new ListItem("Select", ""));

        //    //added By bhaurao
        //}
        //if ((ddlStatus.SelectedValue == "UNDER REVIEW") && (ddlStatus.SelectedValue == "REVISED -UNDER REVIEW"))
        //{
        //    if (sUserId == "cmpreview")
        //    {
        //        chkQual.Enabled = true;
        //    }
        //    else
        //        chkQual.Enabled = false;


        //    if (chkQual.Checked == true)
        //    {


        //        btOK.Enabled = true;
        //        ddlStatusR.Enabled = true;
        //        txtRemark.Enabled = true;
        //        //BindCnstGrid(txtCompCode.Text.ToString());
        //        //BindStatus();
        //        //// ddlStatusR.Items.Clear();
        //        // ddlStatusR.Items.Insert(0, new ListItem("Select", ""));

        //    }
        //    else
        //    {
        //        //BindStatus();
        //        ddlStatusR.SelectedIndex = 0;
        //        ddlStatusR.Enabled = false;
        //        txtRemark.Text = "";
        //        txtRemark.Enabled = false;
        //        //ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
        //    }
        //}
        //chkQual.Enabled = false;
        //chkQual.Checked = false;
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "chkQual_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void FillDropDowns(DropDownList ddl)
    {
        try
        {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ///Ashish
        ht.Add("@CODE", ddlStatus.SelectedValue.ToString().Trim());

        if (HttpContext.Current.Session["UserID"].ToString() == "CMPAUTHORIZER")
        {
            ht.Add("@UserId", HttpContext.Current.Session["UserID"].ToString());
        }
        else
        {
            ht.Add("@UserId", "");
        }

        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetDESC01", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "NextStatus";
            ddl.DataValueField = "Code";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", ""));

        }
        drRead.Close();
        ddl.SelectedIndex = 0;

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //protected void btSubmit_Click1(object sender, EventArgs e)
    //{

    //}

    protected void BindStatus()
    {
        try
        {
        ds.Clear();

        ds = objDal.GetDataSetForPrc_SAIM("[Prc_BindStatus_DropDown_CHK]", htParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStatusR.DataSource = ds.Tables[0];
            ddlStatusR.DataTextField = "DESC01";
            ddlStatusR.DataValueField = "CODE";
            ddlStatusR.DataBind();
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));

        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "BindStatus", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindAuditGrid(string strCompcode1)
    {
        try
        {
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", strCompcode1);
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAuditData", htParam);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdAudit.DataSource = ds.Tables[0];
                gdAudit.DataBind();
                if (gdAudit.PageCount > 1)
                {
                    btnprevaudit.Enabled = true;
                }
                else
                {
                    btnnextaudit.Enabled = false;
                }
            }
            else
            {
                divAudit.Visible = false;
                btnprevaudit.Enabled = false;
                btnnextaudit.Enabled = false;
                txtPage.Text = "1";
            }
        }
        else
        {
            divAudit.Visible = false;
            btnprevious.Enabled = false;
            btnnext.Enabled = false;
            txtPage.Text = "1";
        }
        ViewState["grAudit"] = ds.Tables[0];
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "BindAuditGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Added by Ashish Start 16JUl15
    protected void EnableControls()
    {
        try
        {
        lblhdr.Enabled = true;
        lblCompCode.Enabled = true;
        txtCompCode.Enabled = true;
        txtCompDesc1.Enabled = true;
        txtCompDesc2.Enabled = true;
        ddlAccCyc.Enabled = true;
        ddlAccYear.Enabled = true;
        ddlCompType.Enabled = true;
        ddlAccrCyc.Enabled = true;
        ddlRwdRlsCyc.Enabled = true;
        ddlBusiYear.Enabled = true;
        txtVer.Enabled = true;
        txtEffDtFrm.Enabled = true;
        //CalendarExtender2.Enabled = true;
            txtEffDtTo.Enabled = true;
        //CalendarExtender1.Enabled = true;
        txtVerEffFrm.Enabled = true;
        //CalendarExtender3.Enabled = true;
        txtVerEffTo.Enabled = true;
        //CalendarExtender4.Enabled = true;
        ddlStatus.Enabled = true;
        rblSetTrgRul.Enabled = true;
        btnSave.Enabled = true;
        btnCnclCmp.Enabled = true;
        dgCntst.Enabled = true;
        btnprevious.Enabled = true;
        txtPage.Enabled = true;
        btnnext.Enabled = true;
        if (!(sUserId == "cmpreview" || sUserId == "cmpchecker"))
        {
            //btnAddCntst.Enabled = true;
        }
        btnSaveCntst.Enabled = true;
        btncmp.Enabled = true;
        chkQual.Enabled = true;
        btOK.Enabled = true;
        ddlStatusR.Enabled = true;
        txtRemark.Enabled = true;
        // btSubmit.Enabled = true;
        gdAudit.Enabled = true;
        btnprevaudit.Enabled = false;
        txtPageAudit.Enabled = false;
        btnprevaudit.Enabled = false;
        btnok.Enabled = true;

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "EnableControls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void DisableControls()
    {
        try
        {
        lblhdr.Enabled = false;
        lblCompCode.Enabled = false;
        txtCompCode.Enabled = false;
        txtCompDesc1.Enabled = false;
        txtCompDesc2.Enabled = false;
        ddlAccCyc.Enabled = false;
        ddlAccYear.Enabled = false;
        ddlCompType.Enabled = false;
        ddlAccrCyc.Enabled = false;
        ddlRwdRlsCyc.Enabled = false;
        ddlBusiYear.Enabled = false;
        txtVer.Enabled = false;
        txtEffDtFrm.Enabled = false;
        //CalendarExtender2.Enabled = false;
      //  txtEffDtTo.Enabled = false;
        //CalendarExtender1.Enabled = false;
        txtVerEffFrm.Enabled = false;
        //CalendarExtender3.Enabled = false;
        txtVerEffTo.Enabled = false;
        //CalendarExtender4.Enabled = false;
        ddlStatus.Enabled = false;
        rblSetTrgRul.Enabled = false;
        btnSave.Enabled = false;
        btnCnclCmp.Enabled = false;
        dgCntst.Enabled = false;
        btnprevious.Enabled = false;
        txtPage.Enabled = false;
        btnnext.Enabled = false;
        //btnAddCntst.Enabled = false;
        btnSaveCntst.Enabled = false;
        btncmp.Enabled = false;
        chkQual.Enabled = false;
        //btOK.Enabled = false;
        ddlStatusR.Enabled = false;
        txtRemark.Enabled = false;
        // btSubmit.Enabled = false;
        gdAudit.Enabled = false;
        btnprevaudit.Enabled = false;
        txtPageAudit.Enabled = false;
        btnprevaudit.Enabled = false;
        btnok.Enabled = false;

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "DisableControls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //Added by Ashish End 16JUl15

    protected void btnnextaudit_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gdAudit.PageIndex;
            gdAudit.PageIndex = pageIndex + 1;
            gdAudit.DataSource = (DataTable)Session["grid"];
            gdAudit.DataBind();
            txtPageAudit.Text = Convert.ToString(Convert.ToInt32(txtPageAudit.Text) + 1);
            btnprevaudit.Enabled = true;
            if (txtPageAudit.Text == Convert.ToString(gdAudit.PageCount))
            {
                btnnextaudit.Enabled = false;
            }

            int page = gdAudit.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btnnextaudit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevaudit_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gdAudit.PageIndex;
            gdAudit.PageIndex = pageIndex - 1;
            gdAudit.DataSource = (DataTable)Session["grid"];
            gdAudit.DataBind();
            txtPageAudit.Text = Convert.ToString(Convert.ToInt32(txtPageAudit.Text) - 1);
            if (txtPageAudit.Text == "1")
            {
                btnprevaudit.Enabled = false;
            }
            else
            {
                btnprevaudit.Enabled = true;
            }
            btnnextaudit.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btnprevaudit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void gdAudit_Sorting(object sender, GridViewSortEventArgs e)
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
        BindAuditGrid(txtCompCode.Text.ToString().Trim());
        DataTable dt = (DataTable)ViewState["grAudit"];
        DataView dv = new DataView(dt);
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
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "gdAudit_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkCnstCode_Click(object sender, EventArgs e)
    {
       
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)row.FindControl("lnkCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
        if (Request.QueryString["flag"] != null)
        {
            if (Request.QueryString["flag"].ToString().Trim() == "Stmt")
            {
                Response.Redirect("ViewStmtDetails.aspx?CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
            }
            else if (Request.QueryString["flag"].ToString().Trim() == "Btch")
            {
                Response.Redirect("CntstStp.aspx?CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim());
            }
            else
            {
                Response.Redirect("CntstStp.aspx?CmpCode=" + txtCompCode.Text.ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim());
            }
        }
        else
        {
            Response.Redirect("CntstStp.aspx?CmpCode=" + txtCompCode.Text.ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim());
        }
    }
      
    
    protected void ddlAccCyc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (GetCycleDetails("IS_STANDARD", "23") == "0")
            //{
            //    btncycle.Visible = true;
            //}
            //else
            //{
            //    btncycle.Visible = false;
            //}
        FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");//////added by akshay
            FillRwdRlsCyc(ddlRewardComputation, "22", "");
            ddlRwdRlsCyc.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
            ddlRewardComputation.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
        ddlAccCyc.Focus();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlAccCyc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlCompType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCompType.Focus();
    }
    protected void ddlAccrCyc_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAccrCyc.Focus();
    }
    protected void ddlRwdRlsCyc_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRwdRlsCyc.Focus();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        //added By bhaurao
        if ((ddlStatus.SelectedValue == "1002") && (ddlStatus.SelectedValue == "1004"))
        {
            if (sUserId == "cmpreview")
            {
                if (ddlStatusR.SelectedValue == "1003" || ddlStatusR.SelectedValue == "1005") { btnok.Enabled = true; }
                chkQual.Enabled = true;
                btOK.Enabled = true;
            }
            else
            {
                chkQual.Enabled = true;
            }
            if (chkQual.Checked == true)
            {
                btOK.Enabled = true;
                ddlStatusR.Enabled = true;
                txtRemark.Enabled = true;
                //BindCnstGrid(txtCompCode.Text.ToString());
                //BindStatus();
                //// ddlStatusR.Items.Clear();
                // ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                //BindStatus();
                ddlStatusR.SelectedIndex = 0;
                ddlStatusR.Enabled = false;
                txtRemark.Text = "";
                txtRemark.Enabled = false;
                //ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        chkQual.Checked = false;
        chkQual.Enabled = false;
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlStatus_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void StatusDropdownlist()
    {
        try
        {
        ddlStatusR.Items.Clear();
        if (ddlStatus.SelectedIndex == 1)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            ddlStatusR.Items.Insert(1, new ListItem("UNDER REVIEW", ""));
        }
        else if (ddlStatus.SelectedIndex == 2)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            ddlStatusR.Items.Insert(1, new ListItem("REVISION REQUIRED", ""));
            ddlStatusR.Items.Insert(1, new ListItem("APPROVED", ""));
        }
        else if (ddlStatus.SelectedIndex == 3)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            ddlStatusR.Items.Insert(1, new ListItem("REVISED -UNDER REVIEW", ""));
        }
        else if (ddlStatus.SelectedIndex == 4)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            ddlStatusR.Items.Insert(1, new ListItem("REVISION REQUIRED", ""));
            ddlStatusR.Items.Insert(1, new ListItem("APPROVED", ""));

        }
        else if (ddlStatus.SelectedIndex == 5)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
            ddlStatusR.Items.Insert(1, new ListItem("FINAL", ""));
        }
        else if (ddlStatus.SelectedIndex == 6)
        {
            ddlStatusR.Items.Insert(0, new ListItem("Select", ""));
        }
        else { ddlStatusR.Items.Insert(0, new ListItem("Select", "")); }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "StatusDropdownlist", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnCnclCntst_Click(object sender, EventArgs e)
    {
        BindCnstGrid(txtCompCode.Text.ToString());//not perment..
    }
    protected void btnAddRegistro_Click(object sender, EventArgs e)
    {
        mdlView.Hide();
    }
    protected void btnAddCntst_Click(object sender, EventArgs e)
    {
        BindCnstGrid(lblCompCode.Text.ToString());
    }

    protected void txtEffDtFrm_TextChanged(object sender, EventArgs e)
    {
        try
        {
        DateTime date;
        if (ddlRwdRlsCyc.SelectedValue == "1001")
        {
            txtEffDtTo.Text = txtEffDtFrm.Text.ToString().Trim();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1002")////DAILY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddDays(15);
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1003")////MONTHLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            int d = DateTime.DaysInMonth(date.Year, date.Month);
            int dt = d - (date.Day);
            date = date.AddDays(dt);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1004")////WEEKLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddDays(7);
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1005")////BI-MONTHLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddMonths(2);
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1006")////QUATERLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddMonths(3);
            date = date.AddDays(-1);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1007")////HALFYEARLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddMonths(6);
            date = date.AddDays(-1);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else if (ddlRwdRlsCyc.SelectedValue == "1008")////ANNUALLY
        {
            date = Convert.ToDateTime(txtEffDtFrm.Text);
            date = date.AddMonths(12);
            date = date.AddDays(-1);
            txtEffDtTo.Text = date.ToShortDateString();
        }
        else
        {
            txtEffDtTo.Text = txtEffDtFrm.Text.ToString().Trim();
        }
        txtVerEffFrm.Text = txtEffDtFrm.Text.ToString().Trim();
        txtVerEffTo.Text = txtEffDtTo.Text.ToString().Trim();
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "txtEffDtFrm_TextChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void txtEffDtTo_TextChanged(object sender, EventArgs e)
    {
        txtVerEffTo.Text = txtEffDtTo.Text.ToString().Trim();
    }

    protected void FillRwdRlsCyc(DropDownList ddl, string val, string yrtyp)
    {
        try
        {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        ht.Add("@CODE", ddlAccCyc.SelectedValue.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("Select", ""));
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "FillRwdRlsCyc", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btncycle_Click(object sender, EventArgs e)
    {
        try
        {
        //////Response.Redirect("Date_Cycle_Defination.aspx");
        /////btncycle.Attributes.Add("onclick", "funPopUpCycle('" + txtCompCode.Text.ToString().Trim() + "');return false;");
        if (ddlAccYear.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Accumulation Year')", true);
            return;
        }
        if (ddlBusiYear.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Business Year')", true);
            return;
        }
            //if (ddlAccYear.SelectedValue != "" && ddlBusiYear.SelectedValue != "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpCycle('" + txtCompCode.Text.ToString().Trim() + "','" + ddlAccCyc.SelectedValue.ToString().Trim() + "','" + GetCycleDetails("CYCLE_TYPE", "23") + "','" + GetYearType(ddlAccYear.SelectedValue.ToString().Trim()) + "','" + txtEffDtFrm.Text.Trim() + "','" + txtEffDtTo.Text.Trim() + "');", true);
            //}
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "btncycle_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected string GetCycleDetails(string val, string flag)
    {
        string cyctype = string.Empty;
        try
        {

        ds.Clear();
        htParam.Clear();
        htParam.Add("@Flag", flag.ToString().Trim());
        htParam.Add("@CODE", ddlAccCyc.SelectedValue.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_FillMstVals", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            cyctype = ds.Tables[0].Rows[0][val.ToString().Trim()].ToString().Trim();
        }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "GetCycleDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        } return cyctype;
    }

    protected void BindSubCnstGrid(string cntstcode)
    {
        try
        {
        DataSet dscnct = new DataSet();
        dscnct.Clear();
        htParam.Clear();
        if (cntstcode != "")
        {

            htParam.Add("@PCntstCode", cntstcode.ToString().Trim());
            htParam.Add("@CmpCode", txtCompCode.Text.ToString().Trim());

            dscnct = objDal.GetDataSetForPrc_SAIM("Prc_GetSubCntstDtls", htParam);
            if (dscnct.Tables.Count > 0 && dscnct.Tables[0].Rows.Count > 0)
            {
                Hashtable ht = new Hashtable();
                ht.Add("@ParentCntCode", cntstcode.ToString().Trim());
                ht.Add("@D_CNTSTNT_CODE", "");
                DataSet dsMem = objDal.GetDataSetForPrc_SAIM("prc_GetParentMemCode", ht);
                if (dsMem.Tables.Count > 0 && dsMem.Tables[0].Rows.Count > 0)
                {
                    dgSubemp.DataSource = dsMem;
                    dgSubemp.DataBind();
                    ViewState["Memcode"] = dsMem.Tables[0].Rows[0][1].ToString();
                }

                if (dscnct.Tables.Count > 0 && dscnct.Tables[0].Rows.Count > 0)
                {
                    dgSubCntst.DataSource = dscnct;
                    dgSubCntst.DataBind();
                    ViewState["grdSubCntst"] = dscnct.Tables[0];
                    ViewState["Depcode"] = dscnct.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    ShowNoResultFound(dscnct.Tables[0], dgSubCntst);
                }
            }
            else
            {
                ShowNoResultFound(dscnct.Tables[0], dgSubCntst);
            }
        }
        else
        {
            dscnct = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
            ShowNoResultFound(dscnct.Tables[0], dgSubCntst);
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "BindSubCnstGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkAddSbCntst_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)gvRow.FindControl("lnkCnstCode");
        HiddenField hdnSlsChnl = (HiddenField)gvRow.FindControl("hdnSlsChnl");
        HiddenField hdnSubCls = (HiddenField)gvRow.FindControl("hdnSubCls");
        HiddenField hdnMemType = (HiddenField)gvRow.FindControl("hdnMemType");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpSub('" + txtCompCode.Text.ToString().Trim() + "','"
            + txtCompDesc1.Text.ToString().Trim() + "','" + lnkCnstCode.Text.ToString().Trim() + "','2','" + hdnSlsChnl.Value.ToString().Trim()
            + "','" + hdnSubCls.Value.ToString().Trim() + "','" + hdnMemType.Value.ToString().Trim() + "');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkAddSbCntst_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lnkAddMembers_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)gvRow.FindControl("lnkCnstCode");
        HiddenField hdnSlsChnl = (HiddenField)gvRow.FindControl("hdnSlsChnl");
        HiddenField hdnSubCls = (HiddenField)gvRow.FindControl("hdnSubCls");
        HiddenField hdnMemType = (HiddenField)gvRow.FindControl("hdnMemType");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpMemtype('" + txtCompCode.Text.ToString().Trim() + "','"
            + txtCompDesc1.Text.ToString().Trim() + "','" + lnkCnstCode.Text.ToString().Trim() + "','1','" + hdnSlsChnl.Value.ToString().Trim()
            + "','" + hdnSubCls.Value.ToString().Trim() + "','" + hdnMemType.Value.ToString().Trim() + "');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkAddMembers_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

  //Added by Prity on 4/07/18
    protected void lnkSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkCnstCode = (LinkButton)gvRow.FindControl("lnkCnstCode");
            HiddenField hdnSlsChnl = (HiddenField)gvRow.FindControl("hdnSlsChnl");
            HiddenField hdnSubCls = (HiddenField)gvRow.FindControl("hdnSubCls");
            HiddenField hdnMemType = (HiddenField)gvRow.FindControl("hdnMemType");


            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            //GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            //HiddenField hdnRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");

            //HiddenField HiddenRulecode = (HiddenField)grd.FindControl("HiddenRulecode");
            //HiddenField HiddenCycleCode = (HiddenField)grd.FindControl("HiddenCycleCode");
            //HiddenField HiddenKpiCode = (HiddenField)grd.FindControl("HiddenKpiCode");
            //HiddenField hdnCatgCode = (HiddenField)grd.FindControl("hdnCatgCode");
            //HiddenField hdnCode = (HiddenField)grd.FindControl("hdnCode");
            //HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            //HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");

            //if (hdnKpiOrg.Value == "1002")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
            //    return;
            //}
            //else if (hdnKpiOrg.Value == "1003")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
            //    return;
            //}




            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", ddlBusiYear.SelectedValue);
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lnkCnstCode.Text.ToString());
            htparam.Add("@KPI_CODE", "");
            htparam.Add("@RULE_CODE", "");
            htparam.Add("@RULE_SET_KEY", "");
            htparam.Add("@CATG_CODE", "");
            htparam.Add("@CODE", "");
            htparam.Add("@CYCLE_CODE", "");
            htparam.Add("@VER_EFF_FROM", txtVerEffFrm.Text.ToString());
            htparam.Add("@VER_EFF_TO", txtVerEffTo.Text.ToString());
            htparam.Add("@CREATED_BY", "");
            htparam.Add("@KpiFlag", "");


            ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTN_target", htparam, "SAIMConnectionString");

            string mapcode = "";
            if (ds.Tables.Count > 0)
            {

                mapcode = ds.Tables[0].Rows[0]["MapCode"].ToString();

            }
            string drvdkpi = string.Empty;
            if (Request.QueryString["DRVDKPI"] != null)
            {
                if (Request.QueryString["DRVDKPI"].ToString().Trim() != "")
                {
                    drvdkpi = Request.QueryString["DRVDKPI"].ToString().Trim();
                }
            }

            string flagMode = "rsCntStp";

            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpSetRule('" + txtCompCode.Text.ToString().Trim() + "','"
            //    + txtCompDesc1.Text.ToString().Trim() + "','" + lnkCnstCode.Text.ToString().Trim() + "','1','" + hdnSlsChnl.Value.ToString().Trim()
            //    + "','" + hdnSubCls.Value.ToString().Trim() + "','" + hdnMemType.Value.ToString().Trim() + "');", true);

            Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFCntPageStdDef.aspx?flagMode=" + flagMode + "&mapcode=" + mapcode + "&CMPNSTN_CODE=" + txtCompCode.Text.ToString().Trim() + "&cmpdesc=" + txtCompDesc1.Text.ToString().Trim()
            + "&CNTST_CODE=" + lnkCnstCode.Text.ToString().Trim() + "&flag=" + "1" + "&bizsrc=" + hdnSlsChnl.Value.ToString().Trim() + "&chncls=" + hdnSubCls.Value.ToString().Trim() + "&memtype=" + hdnMemType.Value.ToString().Trim() + "O", false);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Ended by Prity on 4/07/18
    //New Added 30_11_2017
    protected void lnkAddMemberSubCntst_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkCnstCode = (LinkButton)gvRow.FindControl("lnkSubCnstCode");
        HiddenField hdnSlsChnl = (HiddenField)gvRow.FindControl("hdnSlsChnl");
        HiddenField hdnSubCls = (HiddenField)gvRow.FindControl("hdnSubCls");
        HiddenField hdnMemType = (HiddenField)gvRow.FindControl("hdnMemType");
        string hdnDepcode = ViewState["Depcode"].ToString();
        string hdnMemCode = ViewState["Memcode"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpMemtypeNew('" + txtCompCode.Text.ToString().Trim() + "','"
            + txtCompDesc1.Text.ToString().Trim() + "','" + ViewState["parentmemmcode"] + "'," + '1' + ",'" + hdnSlsChnl.Value.ToString().Trim()
            + "','" + hdnSubCls.Value.ToString().Trim() + "','" + hdnMemType.Value.ToString().Trim() + "','" + hdnDepcode + "','" + hdnMemCode + "');", true);
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkAddMemberSubCntst_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkSubCntstDel_Click(object sender, EventArgs e)
    {
        try
        {
        string msg = string.Empty;
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkSubCnstCode = (LinkButton)row.FindControl("lnkSubCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
        int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CMPNSTNCODE", lblCmpDsc.Value.ToString().Trim());
        htParam.Add("@CNTSTNCODE", lnkSubCnstCode.Text.ToString().Trim());
        htParam.Add("@FLAG", "2");
        htParam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpnstn", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
            if (msg == "NO DELETE")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contestant.KPI is assigned to this contestant');", true);
            }
        }
        BindCnstGrid(txtCompCode.Text.ToString().Trim());
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkSubCntstDel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkSubCnstCode_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton lnkSubCnstCode = (LinkButton)row.FindControl("lnkSubCnstCode");
        HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
        Response.Redirect("CntstStp.aspx?CmpCode=" + lblCmpDsc.Value.ToString().Trim() + "&CntstCode=" + lnkSubCnstCode.Text.ToString().Trim()
            + "&flg=Sb" + "&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim());
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkSubCnstCode_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlStatusR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if ((ddlStatus.SelectedValue == "UNDER REVIEW") && (ddlStatus.SelectedValue == "REVISED -UNDER REVIEW"))
        {
            if (sUserId == "cmpreview")
            {
                if (ddlStatusR.SelectedValue == "REVISION REQUIRED" || ddlStatusR.SelectedValue == "APPROVED") { btnok.Enabled = true; }
                chkQual.Enabled = true;
                btOK.Enabled = true;
            }
        }

        // || ddlStatusR.SelectedValue == "APPROVED") { btnok.Enabled = true; }

    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlStatusR_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    ////  add New Code02_12_2017
    protected void dgSubCntst_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDel = (LinkButton)e.Row.FindControl("lnkDelete");
            LinkButton lnkVwStmt = (LinkButton)e.Row.FindControl("lnkVwStmt");
            LinkButton lnkAddSbCntst = (LinkButton)e.Row.FindControl("lnkAddSbCntst");
            LinkButton lnksubCnstCode = (LinkButton)e.Row.FindControl("lnkSubCnstCode");



            BinddgSubCntstMembers(lnksubCnstCode.Text.ToString().Trim());
        }
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "dgSubCntst_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BinddgSubCntstMembers(string cntstcode)
    {
        try
        {
        DataSet dsMem = new DataSet();
        dsMem.Clear();
        htParam.Clear();
        if (ViewState["grdSubCntst"] != "" && ViewState["grdSubCntst"] != null)
        {

            htParam.Add("@ParentCntCode", ViewState["parentmemmcode"].ToString());
            htParam.Add("@D_CNTSTNT_CODE", cntstcode.ToString().Trim());
            dsMem = objDal.GetDataSetForPrc_SAIM("prc_GetParentMemCode", htParam);
            dgSubCntstMembers.DataSource = dsMem;
            dgSubCntstMembers.DataBind();

            if (dsMem.Tables.Count > 0 && dsMem.Tables[0].Rows.Count > 0)
            {
                dgSubCntstMembers.DataSource = dsMem;
                dgSubCntstMembers.DataBind();
                // ViewState["grdSubCntst"] = dscnct.Tables[0];
            }
            else
            {
                ShowNoResultFound(dsMem.Tables[0], dgSubCntstMembers);
            }
        }

        //else
        //{
        //    dsMem = objDal.GetDataSetForPrc_SAIM("GetEmptyData", htParam);
        //    ShowNoResultFound(dsMem.Tables[0], dgSubCntst);
        //}
    }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "BinddgSubCntstMembers", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }

    //added BY  PRITY on 4 SEPT 2018
    public void GetEnblDsblCtrlsts(string strCMPNSTN_CODE, string strPAGE_ID, string strFlag)
    {
        try
        {
            Hashtable htParam = new Hashtable();
            string CTRL_ID;

            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", strCMPNSTN_CODE.ToString());
            htParam.Add("@USER_ID", HttpContext.Current.Session["UserID"].ToString());
            htParam.Add("@PAGE_ID", strPAGE_ID.ToString());
            htParam.Add("@FLAG", strFlag);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetEnblDsbl_sts", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();
                    LinkButton lnkbtn = UPD1.FindControl(CTRL_ID) as LinkButton;
                    lnkbtn.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());

                }

            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "GetEnblDsblCtrlsts", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //End

    //Added by amit on 27 nov
    protected void FillExtended(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", "IsExtended");
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetLookValDESC", ht);
           
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("Select", ""));
            
         
            drRead.Close();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "FillExtended", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void ddlExtendedDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlExtendedDate.SelectedValue.ToString().Trim() == "Y")
            {
                txtEffDtTo.Enabled = true;
            }
            else
            {
                txtEffDtTo.Enabled = false;
            }
            drRead.Close();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "ddlExtendedDate_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    //Ended  by amit on 27 nov 2018

    
    //Added By Amit Marathe on 30 Jan 2019
    protected void rdSingleCycle_CheckedChanged(object sender, EventArgs e)
    {

        if (rdSingleCycle.Checked)
        {
           
            ddlAccCyc.Enabled = false;
            ddlAccrCyc.Enabled = false;
            FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
            FillRwdRlsCyc(ddlRewardComputation, "22", "");
            ddlRwdRlsCyc.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
            ddlRewardComputation.SelectedValue = ddlAccCyc.SelectedValue.ToString().Trim();
        }
        else
        {
            ddlAccCyc.Enabled = true;
            ddlAccrCyc.Enabled = true;
        }
    }


    //Ended By Amit Marathe on 30 Jan 2019
    //Added by Abuzar Siddiqui on 14/07/2020 starts
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkCnstCode = (LinkButton)gvRow.FindControl("lnkCnstCode");
            HiddenField hdnSlsChnl = (HiddenField)gvRow.FindControl("hdnSlsChnl");
            HiddenField hdnSubCls = (HiddenField)gvRow.FindControl("hdnSubCls");
            HiddenField hdnMemType = (HiddenField)gvRow.FindControl("hdnMemType");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpEdit('" + txtCompCode.Text.ToString().Trim() + "','" + txtCompDesc1.Text.ToString().Trim() + "','" + lnkCnstCode.Text.ToString().Trim() + "','ED');", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CmpSetup", "lnkEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    //Added by Abuzar Siddiqui on 14/07/2020 Ends
}
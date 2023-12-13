using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_CntstStp_INC : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string sUserId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            sUserId = HttpContext.Current.Session["UserID"].ToString();

            if (sUserId == "cmpchecker" || sUserId == "CMPCHECKER" || sUserId == "CMPAUTHORISER" || sUserId == "cmpauthoriser")
            {
                lnkindctrcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','R','fgAdd');return false;");
                lnkVwCmtRwd.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','R','fgView');return false;");
                lnktrgtcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R','fgAdd');return false;");
                lnkVwCmtRTrg.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R','fgView');return false;");
                lnkrwdrulecmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R','fgAdd');return false;");
                lnkVwCmtRwRul.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R','fgView');return false;");
            }

            GetEnblDsblCtrlsts("", "CntstStp", "Page_Load");

            BINDdgTrgMEM();
            BINDdgRwdMEM();

            if (!IsPostBack)
            {

                
                btnSaveFn.Enabled = false;
                FillCmp();
                FillMem();
                BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
                BindQualTrg(hdnFlag.Value.ToString().Trim());
                ////BindQualRul();
                BindRwdTrg();
                BindRwdRul("P");
               
                txtpgrwdtrg.Text = "1";
                //lblNote.Text = "Note:Reward Computation Rule:- Accumulation Cycle or Reward Release Cycle";

                //Added By Amit Marathe On 13 Oct 2018
                ddlRuleSet.Items.Insert(0, new ListItem("-- SELECT --"));
                ddlCycleCode.Items.Insert(0, new ListItem("-- SELECT --"));
                ddlCatgCode.Items.Insert(0, new ListItem("-- SELECT --"));
                FillDropDoun(ddlRuleSet, Request.QueryString["CmpCode"].ToString().Trim(), Request.QueryString["CntstCode"].ToString().Trim());
                //Ended By Amit Marathe On 13 Oct 2018

                //Added By Amit Marathe On 15 Oct 2018
                ddlRSetK_Rwd.Items.Insert(0, new ListItem("-- SELECT --"));
                ddlCyCod_Rwd.Items.Insert(0, new ListItem("-- SELECT --"));
                ddlCatgCod_Rwd.Items.Insert(0, new ListItem("-- SELECT --"));
                FillDropDoun(ddlRSetK_Rwd, Request.QueryString["CmpCode"].ToString().Trim(), Request.QueryString["CntstCode"].ToString().Trim());
                //Ended By Amit Marathe On 15 Oct 2018

                //CtrlEnblDsbl();

                //

                if (Request.QueryString["Page"] != null)
                {
                    if (Request.QueryString["Page"].ToString() == "A")
                    {
                        divKPI.Visible = false;
                        divKPIT.Visible = false;
                        divcmphdr.Attributes.Add("style", "display:none");
                        divcntst.Attributes.Add("style", "display:none");
                        tblrwdrul.Visible = false;
                        DivAddStandNonDef.Visible = false;
                        DivAddStandNonDef.Visible = true;
                        LNKRWD.Attributes.Add("onclick", "funPopUpRwdRulNSTD('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + Request.QueryString["MEMBERCODE"].ToString() + "','" + Request.QueryString["Page"].ToString() + "');return false;");
                        divchkRwd.Visible = false;
                        divAudit.Visible = false;
                        Table1.Visible = false;


                        // Addded by ajay sawant


                        DataSet dsVISIBLE = new DataSet();
                        Hashtable htVISIBLE = new Hashtable();


                        htVISIBLE.Clear();
                        dsVISIBLE.Clear();
                        htVISIBLE.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
                        htVISIBLE.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                        // htVISIBLE.Add("@RULE_SET_KEY", Request.QueryString["RSetKey"].ToString().Trim());
                        htVISIBLE.Add("@MEM_CODE", Request.QueryString["MEMBERCODE"].ToString());
                        htVISIBLE.Add("@CreatedBy ", HttpContext.Current.Session["UserID"].ToString().Trim());

                        dsVISIBLE = objDal.GetDataSetForPrc_SAIM("Prc_SET_VISIBILITY", htVISIBLE);

                        if (dsVISIBLE.Tables.Count > 0)
                        {
                            if (dsVISIBLE.Tables[0].Rows[0]["IS_VISIBLE"].ToString().Trim() == "Y")
                            {

                                LinkButton2.Visible = true;
                            }
                            else
                            {

                                LinkButton2.Visible = false;
                            }

                        }

                    }


                }


                if (Request.QueryString["CmpCode"] != null)
                {
                    BindAuditGrid(Request.QueryString["CmpCode"].ToString().Trim());
                    BindRevHistGrid(Request.QueryString["CmpCode"].ToString().Trim());
                }
                if (Request.QueryString["flg"] != null)
                {
                    if (Request.QueryString["flg"].ToString().Trim() == "Sb")
                    {
                        chkRwd.Enabled = false;
                        divRwd.Style.Add("display", "none");

                    }
                }


                if (Request.QueryString["CmpTyp"] != null)
                {
                    if (Request.QueryString["CmpTyp"].ToString().Trim() == "GOA")
                    {
                        chkRwd.Enabled = false;
                        divRwd.Style.Add("display", "none");
                        divRwdcollapse.Style.Add("display", "none");
                        divchkRwd.Style.Add("display", "none");
                    }
                }


                if (sUserId == "cmpmaker" || sUserId == "CMPMAKER")
                {
                    if (hdnstatusval.Value == "1001" || hdnstatusval.Value == "1003" || hdnstatusval.Value == "1006")
                    {
                        btnBlkRwTrg.Visible = true;
                        //lnkQualIndctrCmnt.Enabled = true;
                        lnkQualIndctrCmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','Q');return false;");
                        // lnkQualTrgtCmnt.Enabled = true;
                        lnkQualTrgtCmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','Q');return false;");
                        // lnkindctrcmnt.Enabled = true;
                        if (hdnstatusval.Value != "1005")
                        {
                            lnkindctrcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','R','fgAdd');return false;");
                            lnkVwCmtRwd.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','R','fgView');return false;");

                        }
                        //  lnktrgtcmnt.Enabled = true;
                        lnktrgtcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R','fgAdd');return false;");
                        lnkVwCmtRTrg.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R','fgView');return false;");
                        //  lnkrwdrulecmnt.Enabled = true;
                        lnkrwdrulecmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R','fgAdd');return false;");
                        lnkVwCmtRwRul.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + Request.QueryString["CntstCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R','fgView');return false;");
                  //      btnEdit.Attributes.Add("onclick", "funPopUpTrgBtnEdit('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
                  //+ "','R','" + Request.QueryString["CategoryCode"].ToString() + "', '" + Request.QueryString["Cycle"].ToString() + "', '" + Request.QueryString["RuleCode"].ToString() + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','"
                  //+ Request.QueryString["Memcode"].ToString() + "','" + Request.QueryString["Flag"].ToString() + "','IncEnquiry');return false;");


                    }
                    else
                    {
                        lnkQualIndctrCmnt.Enabled = false;
                        lnkQualTrgtCmnt.Enabled = false;
                        lnkindctrcmnt.Enabled = false;
                        lnktrgtcmnt.Enabled = false;
                        lnkrwdrulecmnt.Enabled = false;
                    }
                }
                if (sUserId == "cmpreview" || sUserId == "CMPREVIEW")
                {
                    if ((hdnstatusval.Value == "1002") || (hdnstatusval.Value == "1004"))
                    {

                        ////lnkQualIndctrCmnt.Enabled = true;
                        //lnkQualIndctrCmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','Q');return false;");
                        //lnkQualTrgtCmnt.Enabled = true;
                        //lnkindctrcmnt.Enabled = true;
                        //lnktrgtcmnt.Enabled = true;
                        //lnkrwdrulecmnt.Enabled = true;
                        //lnkQualIndctrCmnt.Enabled = true;
                        lnkQualIndctrCmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','Q');return false;");
                        // lnkQualTrgtCmnt.Enabled = true;
                        lnkQualTrgtCmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','Q');return false;");
                        // lnkindctrcmnt.Enabled = true;
                        if (hdnstatusval.Value != "1005")
                        {
                            lnkindctrcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdIndctr','R');return false;");
                        }
                        //  lnktrgtcmnt.Enabled = true;
                        lnktrgtcmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R');return false;");
                        lnkVwCmtRTrg.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdTrgt','R');return false;");
                        //  lnkrwdrulecmnt.Enabled = true;
                        lnkrwdrulecmnt.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R');return false;");
                        lnkVwCmtRwRul.Attributes.Add("onclick", "funAddlCmnt('" + hdnstatus.Value + "','" + Request.QueryString["CmpCode"].ToString().Trim() + "','" + lblVersion.Text + "','CntstRwdRule','R');return false;");
                    }
                    else
                    {
                        lnkQualIndctrCmnt.Enabled = false;
                        lnkQualTrgtCmnt.Enabled = false;
                        //  lnkindctrcmnt.Enabled = false;
                        lnktrgtcmnt.Enabled = false;
                        lnkrwdrulecmnt.Enabled = false;
                    }
                }
            }
            else
            {
                BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
                BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
                BindQualTrg(hdnFlag.Value.ToString().Trim());
                ////BindQualRul();
                BindRwdTrg();
                BindRwdRul("P");
            }
            if (hdnstatusval.Value != "1005")
            {
                if (btnAddQual.Enabled == true)
                {
                    btnAddQual.Attributes.Add("onclick", "funPopUp('divqual','Q');return false;");
                }
            }

            if (hdnstatusval.Value != "1005")
            {
                if (btnAddRwd.Enabled == true)
                {
                    btnAddRwd.Attributes.Add("onclick", "funPopUp('divRwd','R');return false;");
                }
            }
            chkQual.Attributes.Add("onclick", "ShowReqDiv('divqual','Img2','#Img2','chkQual','div12');");
            chkRwd.Attributes.Add("onclick", "ShowReqDiv('divRwd','Img3','#Img3','chkRwd','divchkRwd');");

            btnDwnQTrg.Attributes.Add("onclick", "funblkTrg();return false;");

            btnQualIndctrMst.Attributes.Add("onclick", "funAddmaster('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','CntstRwdIndctr','Q');return false;");
            btnQualTrgtMst.Attributes.Add("onclick", "funAddmaster('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','CntstRwdTrgt','Q');return false;");
            btnBlkRwTrg.Attributes.Add("onclick", "funBulkUpload('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "');return false;");

            btnAddIndctrMst.Attributes.Add("onclick", "funAddmaster('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','CntstRwdIndctr','R');return false;");
            btnAddTrgtMst.Attributes.Add("onclick", "funAddmaster('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','CntstRwdTrgt','R');return false;");
            btnAddRwdRuleMst.Attributes.Add("onclick", "funAddmaster('" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','CntstRwdRule','R');return false;");

            btnAddCategory.Attributes.Add("onclick", "funAddmaster2('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','CntstRwdTrgt','R');return false;");
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster2('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdTrgt','" + rultyp.ToString().Trim() + "');", true);


            btnAddCategory.Attributes.Add("onclick", "funAddmaster2('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','CntstRwdTrgt','R');return false;");

            lnkAddRuleMst.Attributes.Add("onclick", "funAddmaster3('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','CntstRwdIndctr','R');return false;");

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster3('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdIndctr','" + rultyp.ToString().Trim() + "');", true);

            if (hdnstatusval.Value != "1005")
            {
                if (btnAddRwdRul.Enabled == true)
                {
                    btnAddRwdRul.Attributes.Add("onclick", "funPopUpRwdRul('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");

                    btnAddRewardType.Attributes.Add("onclick", "funAddmaster1('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','CntstRwdRule','R');return false;");

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRule','" + rultyp.ToString().Trim() + "');", true);

                }
            }

            lnkKeyDfn.Attributes.Add("onclick", "funPopUpRulSet('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
            if (Request.QueryString["RSetKey"] != null)
            {
                if (Request.QueryString["RSetKey"].ToString() != null)
                {
                    btnAddQual.Enabled = false;
                    btnAddQualTrg.Enabled = false;
                    btnAddRwd.Enabled = false;
                    btnAddRwdTrg.Enabled = false;
                    btnAddRwdRul.Enabled = false;
                    btnAddRwdRul.Enabled = false;
                    lnkKeyDfn.Enabled = false;
                    btnBlkKPIQual.Enabled = false;
                    btnBlkKPIRwd.Enabled = false;
                    btnBlkQualTrg.Enabled = false;
                    btnBlkRwd.Enabled = false;
                    btnBlkRwTrg.Enabled = false;
                    btnDwnQTrg.Enabled = false;
                    lnkQualIndctrCmnt.Enabled = false;
                    lnkQualTrgtCmnt.Enabled = false;
                    lnkrwdrulecmnt.Enabled = false;
                    lnktrgtcmnt.Enabled = false;
                    lnkVwCmtQKPI.Enabled = false;
                    lnkVwCmtQTrg.Enabled = false;
                    lnkVwCmtRTrg.Enabled = false;
                    lnkVwCmtRwd.Enabled = false;
                    lnkVwCmtRwRul.Enabled = false;




                }
            }

            CtrlEnblDsbl();
            GetEnblDsblCtrlsts(Request.QueryString["CmpCode"].ToString().Trim(), "CntstStp", "CntstCode");

            if (!IsPostBack)
            {

                EnableDisableEN();
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnKPI_CODE = (HiddenField)grd.FindControl("hdnKPI_CODE");
        // Label lblRuleCode = (Label)grd.FindControl("lblRuleCode");
        //  Label lblMemcode = (Label)grd.FindControl("lblMemcode");
        // Label lblCategoryCode = (Label)grd.FindControl("lblCategoryCode");

        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "openInWindow('" + CmpCode + "','" + CntstCode + "','" + MEMBERCODE + "');", true);

        string lnkbtn = "lnkView";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewData('" + Request.QueryString["RuleSetKey"].ToString() + "','" + hdnKPI_CODE.Value.ToString() + "','" + Request.QueryString["Memcode"].ToString() + "','" + Request.QueryString["Cycle"].ToString().Trim() + "','" + lnkbtn + "','O');", true);


    }

    protected void lnkView2_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnKPI_CODE = (HiddenField)grd.FindControl("hdnKPI_CODE");
        // Label lblRuleCode = (Label)grd.FindControl("lblRuleCode");
        //  Label lblMemcode = (Label)grd.FindControl("lblMemcode");
        // Label lblCategoryCode = (Label)grd.FindControl("lblCategoryCode");

        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "openInWindow('" + CmpCode + "','" + CntstCode + "','" + MEMBERCODE + "');", true);

        string lnkbtn = "lnkView";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewData('" + Request.QueryString["RuleSetKey"].ToString() + "','" + hdnKPI_CODE.Value.ToString() + "','" + Request.QueryString["Memcode"].ToString() + "','" + Request.QueryString["Cycle"].ToString().Trim() + "','" + lnkbtn + "','R');", true);


    }


    protected void lnkRevised_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

        HiddenField hdnKPI_CODE = (HiddenField)grd.FindControl("hdnKPI_CODE");
        // Label lblRuleCode = (Label)grd.FindControl("lblRuleCode");
        //  Label lblMemcode = (Label)grd.FindControl("lblMemcode");
        // Label lblCategoryCode = (Label)grd.FindControl("lblCategoryCode");



        string lnkbtn = "lnkRevised";
        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "openInWindow('" + CmpCode + "','" + CntstCode + "','" + MEMBERCODE + "');", true);

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewData('" + Request.QueryString["RuleSetKey"].ToString() + "','" + hdnKPI_CODE.Value.ToString() + "','" + Request.QueryString["Memcode"].ToString() + "','" + Request.QueryString["Cycle"].ToString().Trim() + "','" + lnkbtn + "');", true);


    }


    protected void BindGrid(string BRKPRULE_CODE, GridView gv)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@BRKPRULE_CODE", BRKPRULE_CODE.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_get_Mst_Cntstnt_KPI_Rwrd_Var_Rul", htParam);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds;
                    gv.DataBind();
                }
                else
                {

                    gv.DataSource = null;
                    gv.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    public void CtrlEnblDsbl()
    {
        try
        {
            if (Request.QueryString["CntstCode"] != null)
            {
                var status = string.Empty;
                htParam.Clear();
                ds.Clear();
                htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstStatus", htParam);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    status = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
                    hdnstatus.Value = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
                }

                //if (status == "1001" || status == "1003")
                //{

                //}


                if (HttpContext.Current.Session["UserID"].ToString().Trim() == "cmpchecker")
                {

                    if (hdnstatusval.Value == "1005")
                    {
                        //Added by Prathamesh on 09-03-2018 start
                        lnkAddRuleMst.Enabled = false;
                        lnkindctrcmnt.Enabled = true;
                        btnAddCategory.Enabled = false;
                        btnAddRewardType.Enabled = false;
                        btnBlkRwTrg.Enabled = false;
                        LinkButton1.Enabled = false;
                        lnktrgtcmnt.Enabled = true;
                        btnAddRewardType.Enabled = false;
                        btnBlkRwd.Enabled = false;
                        btnDwdFormat1.Enabled = false;
                        lnkrwdrulecmnt.Enabled = true;
                        //Added by Prathamesh on 09-03-2018 end

                        btnAddQual.Enabled = false;
                        btnSaveQual.Enabled = false;
                        btnAddQualTrg.Enabled = false;
                        btnSaveQualTrg.Enabled = false;
                        btnAddRwd.Enabled = false;
                        btnSaveRwd.Enabled = false;
                        btnAddRwdTrg.Enabled = false;
                        btnSaveRwdTrg.Enabled = false;
                        btnAddRwdRul.Enabled = false;
                        btnSaveRwdRul.Enabled = false;
                        ////btnQualIndctrCmnt.Enabled = false;
                        lnkQualIndctrCmnt.Enabled = false;
                        btnQualTrgtMst.Enabled = false;
                        //////btnQualTrgtCmnt.Enabled = false;
                        lnkQualTrgtCmnt.Enabled = false;
                        btnQualIndctrMst.Enabled = false;
                        /////btnindctrcmnt.Enabled = false;

                        // lnkindctrcmnt.Enabled = false;

                        ////btntrgtcmnt.Enabled = false;

                        //lnktrgtcmnt.Enabled = false;
                        btnAddTrgtMst.Enabled = false;
                        btnAddIndctrMst.Enabled = false;
                        btnAddRwdRuleMst.Enabled = false;
                        //lnkrwdrulecmnt.Enabled = false;
                        ////btnrwdrulecmnt.Enabled = false;

                        /////qualification start
                        dgQual.Columns[11].Visible = false;
                        dgQual.Columns[12].Visible = false;
                        dgQual.Columns[13].Visible = false;

                       // //dgQualTrg.Columns[13].Visible = false;
                        //dgQualTrg.Columns[14].Visible = false;
                        //// dgQualTrg.Columns[15].Visible = false;
                        /////qualification end

                        /////reward start
                        dgReward.Columns[11].Visible = false;
                        dgReward.Columns[12].Visible = false;
                        dgReward.Columns[13].Visible = false;

                      //   //dgRwdTrg.Columns[13].Visible = false;
                         dgRwdTrg.Columns[14].Visible = false;
                        // dgRwdTrg.Columns[15].Visible = false;

                        dgRwdRul.Columns[12].Visible = false;

                        //Commented by arjun
                        //  dgRwdRul.Columns[14].Visible = false;
                    }
                    else
                    {
                        lnkQualTrgtCmnt.Enabled = true;
                        btnAddQual.Enabled = true;
                        lnkQualIndctrCmnt.Enabled = true;
                        btnAddQualTrg.Enabled = true;
                        btnAddRwdRul.Enabled = true;
                        lnktrgtcmnt.Enabled = true;
                        lnkindctrcmnt.Enabled = true;
                        lnkrwdrulecmnt.Enabled = true;
                        btnAddRwdRul.Enabled = true;
                        btnAddRwdTrg.Enabled = true;
                        //btnAddQual.Enabled = false;
                        btnSaveQual.Enabled = false;
                        // btnAddQualTrg.Enabled = false;
                        btnSaveQualTrg.Enabled = false;
                        btnAddRwd.Enabled = true;
                        btnSaveRwd.Enabled = false;
                        btnAddRwdTrg.Enabled = true;
                        btnSaveRwdTrg.Enabled = false;

                        btnSaveRwdRul.Enabled = false;
                        ////btnQualIndctrCmnt.Enabled = false;
                        //lnkQualIndctrCmnt.Enabled = false;
                        btnQualTrgtMst.Enabled = false;
                        //////btnQualTrgtCmnt.Enabled = false;
                        //lnkQualTrgtCmnt.Enabled = false;
                        btnQualIndctrMst.Enabled = false;
                        /////btnindctrcmnt.Enabled = false;

                        // lnkindctrcmnt.Enabled = false;

                        ////btntrgtcmnt.Enabled = false;

                        //lnktrgtcmnt.Enabled = false;
                        btnAddTrgtMst.Enabled = false;
                        btnAddIndctrMst.Enabled = false;
                        btnAddRwdRuleMst.Enabled = false;
                        //lnkrwdrulecmnt.Enabled = false;
                        ////btnrwdrulecmnt.Enabled = false;

                        /////qualification start
                        dgQual.Columns[11].Visible = false;
                        dgQual.Columns[12].Visible = false;
                        dgQual.Columns[13].Visible = false;

                        //dgQualTrg.Columns[13].Visible = false;
                        //dgQualTrg.Columns[14].Visible = false;
                        // // dgQualTrg.Columns[15].Visible = false;
                        /////qualification end

                        /////reward start
                        dgReward.Columns[11].Visible = false;
                        dgReward.Columns[12].Visible = false;
                        dgReward.Columns[13].Visible = false;

                         //dgRwdTrg.Columns[13].Visible = false;
                         dgRwdTrg.Columns[14].Visible = false;
                        // dgRwdTrg.Columns[15].Visible = false;

                        dgRwdRul.Columns[12].Visible = false;
                        //commented by arjun.
                        // dgRwdRul.Columns[14].Visible = false;
                    }
                }
                else
                {
                    ////Added by Prathamesh on 09-03-2018 start
                    //lnkAddRuleMst.Enabled = true;
                    //lnkindctrcmnt.Enabled = true;
                    //btnAddCategory.Enabled = true;
                    //btnAddRewardType.Enabled = true;
                    //btnBlkRwTrg.Enabled = true;
                    //LinkButton1.Enabled = true;
                    //lnktrgtcmnt.Enabled = true;
                    //btnAddRewardType.Enabled = true;
                    //btnBlkRwd.Enabled = true;
                    //btnDwdFormat1.Enabled = true;
                    //lnkrwdrulecmnt.Enabled = true;
                    ////Added by Prathamesh on 09-03-2018 end


                    if (hdnstatusval.Value == "1005")
                    {
                        //Added by Prathamesh on 09-03-2018 start
                        lnkrwdrulecmnt.Enabled = false;
                        lnktrgtcmnt.Enabled = false;
                        lnkindctrcmnt.Enabled = false;
                        btnBlkQualTrg.Enabled = false;
                        btnDwnQTrg.Enabled = false;
                        btnAddRwdRul.Enabled = false;
                        btnAddRwdTrg.Enabled = false;
                        btnAddRwd.Enabled = false;
                        lnkAddRuleMst.Enabled = false;
                        //lnkindctrcmnt.Enabled = true;
                        btnAddCategory.Enabled = false;
                        btnAddRewardType.Enabled = false;
                        btnBlkRwTrg.Enabled = false;
                        LinkButton1.Enabled = false;
                        //lnktrgtcmnt.Enabled = true;
                        btnAddRewardType.Enabled = false;
                        btnBlkRwd.Enabled = false;
                        btnDwdFormat1.Enabled = false;
                        //lnkrwdrulecmnt.Enabled = true;
                        //Added by Prathamesh on 09-03-2018 end

                        btnAddQual.Enabled = false;
                        btnSaveQual.Enabled = false;
                        btnAddQualTrg.Enabled = false;
                        btnSaveQualTrg.Enabled = false;
                        btnAddRwd.Enabled = false;
                        btnSaveRwd.Enabled = false;
                        btnAddRwdTrg.Enabled = false;
                        btnSaveRwdTrg.Enabled = false;
                        btnAddRwdRul.Enabled = false;
                        btnSaveRwdRul.Enabled = false;
                        ////btnQualIndctrCmnt.Enabled = false;
                        lnkQualIndctrCmnt.Enabled = false;
                        btnQualTrgtMst.Enabled = false;
                        //////btnQualTrgtCmnt.Enabled = false;
                        lnkQualTrgtCmnt.Enabled = false;
                        btnQualIndctrMst.Enabled = false;
                        /////btnindctrcmnt.Enabled = false;

                        // lnkindctrcmnt.Enabled = false;

                        ////btntrgtcmnt.Enabled = false;

                        //lnktrgtcmnt.Enabled = false;
                        btnAddTrgtMst.Enabled = false;
                        btnAddIndctrMst.Enabled = false;
                        btnAddRwdRuleMst.Enabled = false;
                        //lnkrwdrulecmnt.Enabled = false;
                        ////btnrwdrulecmnt.Enabled = false;

                        /////qualification start
                        dgQual.Columns[11].Visible = false;
                        dgQual.Columns[12].Visible = false;
                        dgQual.Columns[13].Visible = false;

                        //dgQualTrg.Columns[13].Visible = false;
                        //dgQualTrg.Columns[14].Visible = false;
                       // // dgQualTrg.Columns[15].Visible = false;
                        /////qualification end

                        /////reward start
                        dgReward.Columns[11].Visible = false;
                        dgReward.Columns[12].Visible = false;
                        dgReward.Columns[13].Visible = false;

                         //dgRwdTrg.Columns[13].Visible = false;
                         dgRwdTrg.Columns[14].Visible = false;
                        // dgRwdTrg.Columns[15].Visible = false;

                        dgRwdRul.Columns[12].Visible = false;
                        //commented by arjun
                        // dgRwdRul.Columns[14].Visible = false;

                    }
                    else
                    {
                        lnkQualTrgtCmnt.Enabled = true;
                        btnAddQual.Enabled = true;
                        lnkQualIndctrCmnt.Enabled = true;
                        btnAddQualTrg.Enabled = true;
                        btnAddRwdRul.Enabled = true;
                        lnktrgtcmnt.Enabled = true;
                        lnkindctrcmnt.Enabled = true;
                        lnkrwdrulecmnt.Enabled = true;
                        btnAddRwdRul.Enabled = true;
                        btnAddRwdTrg.Enabled = true;
                        //btnAddQual.Enabled = false;
                        btnSaveQual.Enabled = false;
                        // btnAddQualTrg.Enabled = false;
                        btnSaveQualTrg.Enabled = false;
                        btnAddRwd.Enabled = true;
                        btnSaveRwd.Enabled = false;
                        btnAddRwdTrg.Enabled = true;
                        btnSaveRwdTrg.Enabled = false;

                        btnSaveRwdRul.Enabled = false;
                        ////btnQualIndctrCmnt.Enabled = false;
                        //lnkQualIndctrCmnt.Enabled = false;
                        btnQualTrgtMst.Enabled = false;
                        //////btnQualTrgtCmnt.Enabled = false;
                        //lnkQualTrgtCmnt.Enabled = false;
                        btnQualIndctrMst.Enabled = false;
                        /////btnindctrcmnt.Enabled = false;

                        // lnkindctrcmnt.Enabled = false;

                        ////btntrgtcmnt.Enabled = false;

                        //lnktrgtcmnt.Enabled = false;
                        btnAddTrgtMst.Enabled = false;
                        btnAddIndctrMst.Enabled = false;
                        btnAddRwdRuleMst.Enabled = false;
                        //lnkrwdrulecmnt.Enabled = false;
                        ////btnrwdrulecmnt.Enabled = false;

                        /////qualification start
                        dgQual.Columns[11].Visible = false;
                        dgQual.Columns[12].Visible = false;
                        dgQual.Columns[13].Visible = false;

                        //dgQualTrg.Columns[13].Visible = false;
                        //dgQualTrg.Columns[14].Visible = false;
                        // dgQualTrg.Columns[15].Visible = false;
                        /////qualification end

                        /////reward start
                        dgReward.Columns[11].Visible = false;
                        dgReward.Columns[12].Visible = false;
                        dgReward.Columns[13].Visible = false;

                         //dgRwdTrg.Columns[13].Visible = false;
                         dgRwdTrg.Columns[14].Visible = false;
                        // dgRwdTrg.Columns[15].Visible = false;

                        dgRwdRul.Columns[12].Visible = false;
                        //commented by arjun
                        //dgRwdRul.Columns[14].Visible = false;
                    }
                    /////reward end
                }


                if (Request.QueryString["CmpTyp"].ToString().Trim() == "COM")
                {
                    //new add
                    divqualcollapse.Visible = false;
                }
                else
                { divqualcollapse.Visible = true; }


                htParam.Clear();
                ds.Clear();
                htParam.Add("@UserId", HttpContext.Current.Session["UserID"].ToString().Trim());
                htParam.Add("@status", hdnstatus.Value);
                ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCntstpChangeDtls", htParam);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["AddCmnt"].ToString().Trim() == "Y")
                    {
                        //btnindctrcmnt.Visible = true;
                        //btntrgtcmnt.Visible = true;
                        //btnrwdrulecmnt.Visible = true;

                        lnkindctrcmnt.Visible = true;
                        if (!(sUserId == "cmpreview" || sUserId == "cmpchecker"))
                        {
                            lnktrgtcmnt.Visible = true;
                        }
                        lnkrwdrulecmnt.Visible = true;
                    }
                    else
                    {
                        //btnindctrcmnt.Visible = false;
                        //btntrgtcmnt.Visible = false;
                        //btnrwdrulecmnt.Visible = false;

                        lnkindctrcmnt.Visible = true;
                        lnktrgtcmnt.Visible = false;
                        lnkrwdrulecmnt.Visible = false;
                    }
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "CtrlEnblDsbl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillMem()
    {
        try
        {
            Hashtable htmem = new Hashtable();
            DataSet dsMem = new DataSet();

            htmem.Clear();
            dsMem.Clear();

            if (Request.QueryString["Memcode"] != null)
            {
                htmem.Add("@MemCode", Request.QueryString["Memcode"].ToString().Trim());
           
            }
            dsMem = objDal.GetDataSetForPrc_SAIM("prc_memDtls", htmem);

            if (dsMem.Tables.Count > 0 && dsMem.Tables[0].Rows.Count > 0)
            {
                txtMemberCode.Text = dsMem.Tables[0].Rows[0]["MemCode"].ToString().Trim();
                txtmemberName.Text = dsMem.Tables[0].Rows[0]["LegalName"].ToString().Trim();
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "FillMem", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void EnableRevisedControl()
    {

        lnkindctrcmnt.Visible = true;
        lnkVwCmtRwd.Visible = true;
        btnDwnTrg.Visible = true;
        lnktrgtcmnt.Visible = true;
        lnkVwCmtRTrg.Visible = true;
        btnEdit.Visible = true;

        LnkEditRwrd.Visible = true;
        lnkrwdrulecmnt.Visible = true;
        lnkVwCmtRwRul.Visible = true;
        lnkDownloadReward.Visible = true;
        LnkEditRwrd.Visible = true;
        LinkButton3.Visible = true;
        LinkButton4.Visible = true;


        dgTrgMEM.Columns[6].Visible = true;
        dgTrgMEM.Columns[7].Visible = true;
        dgRwdRul.Columns[17].Visible = true;
        dgRwdRul.Columns[18].Visible = true;

        dgRwdTrg.Columns[13].Visible = true;

        dgRwdTrg.Columns[15].Visible = true;

    }

    protected void EnableDisableEN()
    {

        if (Request.QueryString["Flag2"].ToString().Trim() == "EN")
        {


            trgOR.Visible = false;
            achOR.Visible = false;
            RWDOR.Visible = false;
            RWDACHOR.Visible = false;          

            LinkButton4.Visible = false;
          
        }

        lnkindctrcmnt.Visible = false;
        lnkVwCmtRwd.Visible = false;
        btnDwnTrg.Visible = false;
        lnktrgtcmnt.Visible = false;
        lnkVwCmtRTrg.Visible = false;
        btnEdit.Visible = false;

        LnkEditRwrd.Visible = false;
        lnkrwdrulecmnt.Visible = false;
        lnkVwCmtRwRul.Visible = false;
        lnkDownloadReward.Visible = false;
        LnkEditRwrd.Visible = false;

        LinkButton3.Visible = false;


        dgTrgMEM.Columns[6].Visible = false;
        dgTrgMEM.Columns[7].Visible = false;
        dgRwdRul.Columns[17].Visible = false;
        dgRwdRul.Columns[18].Visible = false;

        dgRwdTrg.Columns[13].Visible = false;

        dgRwdTrg.Columns[15].Visible = false;

    }

    protected void FillCmp()
    {
        try
        {
            if (Request.QueryString["CmpCode"] != null)
            {
                htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
            }
            if (Request.QueryString["CntstCode"] != null)
            {
                htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
            }
            ds = objDal.GetDataSetForPrc_SAIM("Prc_FillCmpCntstDtls", htParam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                lblCntstCdVal.Text = ds.Tables[0].Rows[0]["CNTSTNT_CODE"].ToString().Trim();
                lblCompCodeVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_CODE"].ToString().Trim();
                lblCompDesc1Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC01"].ToString().Trim();
                lblCompDesc2Val.Text = ds.Tables[0].Rows[0]["CMPNSTN_DESC02"].ToString().Trim();
                lblAccCycVal.Text = ds.Tables[0].Rows[0]["ACC_CYCLE_DESC"].ToString().Trim();
                lblAccYrVal.Text = ds.Tables[0].Rows[0]["ACC_YEAR_DESC"].ToString().Trim();
                lblCompTypVal.Text = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString().Trim();
                lblEffDtFrmVal.Text = ds.Tables[0].Rows[0]["EFF_FROM_CMP"].ToString().Trim();
                lblEffDtToVal.Text = ds.Tables[0].Rows[0]["EFF_TO_CMP"].ToString().Trim();
                lblSlsChnlVal.Text = ds.Tables[0].Rows[0]["CHN_DESC"].ToString().Trim();
                lblSbClsVal.Text = ds.Tables[0].Rows[0]["CHNCLS_DESC"].ToString().Trim();
                lblMemTypVal.Text = ds.Tables[0].Rows[0]["MEMTYPE_DESC"].ToString().Trim();
                lblEffFrmValCnt.Text = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
                lblEffToValCnt.Text = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
                lblFinYrVal.Text = ds.Tables[0].Rows[0]["FIN_YEAR_CMP"].ToString().Trim();
                lblVerVal.Text = ds.Tables[0].Rows[0]["VER_NO_CNT"].ToString().Trim();
                hdnChn.Value = ds.Tables[0].Rows[0]["CHN"].ToString().Trim();
                hdnSbChn.Value = ds.Tables[0].Rows[0]["CHNCLS"].ToString().Trim();
                hdnMemType.Value = ds.Tables[0].Rows[0]["MEMTYPE"].ToString().Trim();
                lblAccCycleValue.Text = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE_DESC"].ToString().Trim();
                lblReleaseCycleValue.Text = ds.Tables[0].Rows[0]["REWARD_ACC_CYCLE_DESC"].ToString().Trim();
                lblBusYr.Text = ds.Tables[0].Rows[0]["BUSI_YEAR"].ToString().Trim();
                lblVersion.Text = ds.Tables[0].Rows[0]["VER_NO"].ToString().Trim();
                hdnVersnFrm1.Value = ds.Tables[0].Rows[0]["EFF_FROM_CNT"].ToString().Trim();
                hdnVrsnTo1.Value = ds.Tables[0].Rows[0]["EFF_TO_CNT"].ToString().Trim();
                hdnstatusval.Value = ds.Tables[0].Rows[0]["STATUS"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "FillCmp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            gv.Rows[0].Cells[0].Text = "No rules have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQual.PageIndex;
            dgQual.PageIndex = pageIndex - 1;
            BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage_dgQual.Text = Convert.ToString(Convert.ToInt32(txtPage_dgQual.Text) - 1);
            if (txtPage_dgQual.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }


        //try
        //{
        //    int pageIndex = dgQual.PageIndex;
        //    dgQual.PageIndex = pageIndex - 1;
        //    BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
        //    txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
        //    if (txtPage.Text == "1")
        //    {
        //        btnprevious.Enabled = false;
        //    }
        //    else
        //    {
        //        btnprevious.Enabled = true;
        //    }
        //    btnnext.Enabled = true;
        //    //btnprevious.Enabled = true;
        //}
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQual.PageIndex;
            dgQual.PageIndex = pageIndex + 1;
            BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage_dgQual.Text = Convert.ToString(Convert.ToInt32(txtPage_dgQual.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage_dgQual.Text == Convert.ToString(dgQual.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgQual.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    //added by ajay sawant
    protected void lnkDownloadReward_Click(object sender, EventArgs e)
    {
        try
        {
            // lnkDownloadReward.Visible = false;
            //loading.Visible = true;
            Hashtable htRewrdDwn = new Hashtable();
            DataSet dsRewardDwn = new DataSet();
            DataTable dtRewardDwn = new DataTable();

            htRewrdDwn.Clear();
            dsRewardDwn.Clear();
            dtRewardDwn.Clear();
            htRewrdDwn.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
            htRewrdDwn.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htRewrdDwn.Add("@RULE_TYPE", "R");

            dsRewardDwn = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_Excel_test", htRewrdDwn);

            // dsRewardDwn = GetRewardDtls("P");

            dtRewardDwn = dsRewardDwn.Tables[0];
            if (dsRewardDwn.Tables.Count > 0 && dsRewardDwn.Tables[0].Rows.Count > 0)
            {

                ExportCSV(dtRewardDwn, "RewardDetails");//Added by prity


            }


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDownloadReward_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnDwnTrg_Click(object sender, EventArgs e)
    {
        try
        {
            // lnkDownloadReward.Visible = false;
            //loading.Visible = true;
            Hashtable htTrgDwn = new Hashtable();
            DataSet dsTrgDwn = new DataSet();
            DataTable dtTrgDwn = new DataTable();

            htTrgDwn.Clear();
            dsTrgDwn.Clear();
            dtTrgDwn.Clear();
            htTrgDwn.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htTrgDwn.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());

            htTrgDwn.Add("@RULE_TYPE", "R");
            //  htTrgDwn.Add("@RULE_SET_KEY", Request.QueryString["RSetKey"].ToString().Trim());
            htTrgDwn.Add("@FLAG", "5");
            dsTrgDwn = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htTrgDwn);



            // dsTrgDwn = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_Excel_test", htTrgDwn);

            // dsRewardDwn = GetRewardDtls("P");

            dtTrgDwn = dsTrgDwn.Tables[0];
            if (dsTrgDwn.Tables.Count > 0 && dsTrgDwn.Tables[0].Rows.Count > 0)
            {

                ExportCSV(dtTrgDwn, "TargetDetails");//Added by prity


            }


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnDwnTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public int ExportCSV(DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
            // lnkDownloadReward.Visible = true;
            //loading.Visible = false;
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return Rest;


    }
    //Ended by prity


    protected void dgQual_sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["dgQual"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtPage_dgQual.Text))
            {
                btnprevious.Enabled = false;
                txtPage_dgQual.Text = "1";
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgQual_sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //For Reward
    protected void dgReward_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["dgReward"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtPageRwd.Text))
            {
                btnprevrwd.Enabled = false;
                txtPageRwd.Text = "1";
                btnnextrwd.Enabled = true;
            }
            else
            {
                btnnextrwd.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgReward_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindGrid(GridView gv, Button btnP, Button btnN, CheckBox chk, HtmlGenericControl div, string rultyp, HtmlGenericControl divchk)
    {

        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@RuleType", rultyp.ToString().Trim());
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            
           htParam.Add("@RulStKey", Request.QueryString["RuleSetkey"].ToString().Trim());
                
            
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI_test", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();

                if (gv == dgReward)
                {
                    ViewState["dgReward"] = ds.Tables[0];
                }
                if (gv == dgQual)
                {
                    ViewState["dgQual"] = ds.Tables[0];
                }
                //<Bhau added>
                gv.Columns[11].Visible = true;
                gv.Columns[12].Visible = true;
                gv.Columns[13].Visible = true;
                /////hdnKPICnt.Value = ds.Tables[0].Rows.Count.ToString().Trim();
                div.Style.Add("display", "block");
                divchk.Style.Add("display", "block");
                chk.Checked = true;
                if (gv.PageCount > 1)
                {
                    btnN.Enabled = true;
                }
                else
                {
                    btnN.Enabled = false;
                    btnP.Enabled = false;
                }
            }
            else
            {
                ShowNoResultFound(ds.Tables[0], gv);
                gv.Columns[11].Visible = false;
                gv.Columns[12].Visible = false;
                gv.Columns[13].Visible = false;

                if (chkRwd.Checked == true)
                {

                    divRwd.Style.Add("display", "block");
                }
                else
                {
                    chk.Checked = false;
                    div.Style.Add("display", "none");
                }
                divchk.Style.Add("display", "block");

                btnSaveFn.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnSaveQual_Click(object sender, EventArgs e)
    {

    }
    //Added By bhaurao...
    protected void btnqual_Click(object sender, EventArgs e)
    {
        try
        {
            // BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
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
    protected void btnnextrwd_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgReward.PageIndex;
            dgReward.PageIndex = pageIndex + 1;
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            txtPageRwd.Text = Convert.ToString(Convert.ToInt32(txtPageRwd.Text) + 1);
            btnprevrwd.Enabled = true;
            if (txtPageRwd.Text == Convert.ToString(dgReward.PageCount))
            {
                btnnextrwd.Enabled = false;
            }
            int page = dgReward.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnextrwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevrwd_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgReward.PageIndex;
            dgReward.PageIndex = pageIndex - 1;
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            txtPageRwd.Text = Convert.ToString(Convert.ToInt32(txtPageRwd.Text) - 1);
            if (txtPageRwd.Text == "1")
            {
                btnprevrwd.Enabled = false;
            }
            else
            {
                btnprevrwd.Enabled = true;
            }
            btnnextrwd.Enabled = true;
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprevrwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnUpdRWD_Click(object sender, EventArgs e)
    {
        try
        {
            var rulecode = hdnRulSetKy.Value;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["grid"];
            DataRow[] rows = dt.Select("RULE_CODE =" + rulecode);
            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    row["KPI_CODE"] = hdnKPICd.Value.ToString().Trim();
                    row["KPI_DESC"] = hdnKPIDsc.Value.ToString().Trim();
                    row["ACC_MODE"] = hdnAccMd.Value.ToString().Trim();
                    row["ACC_MODE_DESC"] = hdnAccMdDsc.Value.ToString().Trim();
                    row["VER_FRM"] = hdnVerFrm.Value.ToString().Trim();
                    row["VER_TO"] = hdnVerTo.Value.ToString().Trim();
                    row["CARRY_FWD"] = hdnCRYFWDQ.Value.ToString().Trim();
                    row["RWD_CMP_RULE"] = hdnRwdCmpRulQ.Value.ToString().Trim();
                    row["UNIT_TYPE"] = hdnUnitTypeQ.Value.ToString().Trim();
                    row["UNIT_TYPEDsc"] = hdnUnitTypeDscQ.Value.ToString().Trim();
                    row["MAX_LIMIT"] = hdnMaxLmtQ.Value.ToString().Trim();
                    dt.AcceptChanges();
                    row.SetModified();
                }
                dgReward.DataSource = dt;
                dgReward.DataBind();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnUpdRWD_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnrwd_Click(object sender, EventArgs e)
    {
        try
        {
            ////divRwd.Style.Add("display", "block");
            int str = 0;
            string maxrulecode = String.Empty;
            string maxrulsetcd = String.Empty;
            DataTable dtR = new DataTable();
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            //dgReward.DataSource = dtR;
            //dgReward.DataBind();
            //Session["grid"] = dtR;

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnrwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void dgQualTrg_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)Session["QualTrg"];
            //ViewState["gridqualtrg"];
            //ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtpagetrg.Text))
            {
                btnprevkpitrg.Enabled = false;
                txtpagetrg.Text = "1";
                btnnextkpitrg.Enabled = true;
            }
            else
            {
                btnnextkpitrg.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgQualTrg_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void btnprevkpitrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex - 1;
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) - 1);
            if (txtpagetrg.Text == "1")
            {
                btnprevkpitrg.Enabled = false;
            }
            else
            {
                btnprevkpitrg.Enabled = true;
            }
            btnnextkpitrg.Enabled = true;
            //btnprevious.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprevkpitrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextkpitrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgQualTrg.PageIndex;
            dgQualTrg.PageIndex = pageIndex + 1;
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) + 1);
            btnprevkpitrg.Enabled = true;
            if (txtpagetrg.Text == Convert.ToString(dgQualTrg.PageCount))
            {
                btnnextkpitrg.Enabled = false;
            }
            int page = dgQualTrg.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnextkpitrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        try
        {

            string cmpnstcd = string.Empty, cntstcd = string.Empty, rultyp = string.Empty;
            if (Request.QueryString["cmpcode"] != null)
            {
                if (Request.QueryString["cmpcode"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpcode"].ToString().Trim();
                }
            }
            if (Request.QueryString["CntstCode"] != null)
            {
                if (Request.QueryString["CntstCode"].ToString().Trim() != null)
                {
                    cntstcd = Request.QueryString["CntstCode"].ToString().Trim();
                }
            }

            //if (Request.QueryString["ruletype"] == "R")
            //{
            rultyp = "R";
            // }
            mdlVw.Show();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + maxsort.ToString().Trim() + "','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + maxcatgcd.ToString().Trim() + "','gridTrg');", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster2('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdTrgt','" + rultyp.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnAddCategory_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void lnkAddRuleMst_Click(object sender, EventArgs e)
    {
        try
        {
            string cmpnstcd = string.Empty, cntstcd = string.Empty, rultyp = string.Empty;

            if (Request.QueryString["cmpcode"] != null)
            {
                if (Request.QueryString["cmpcode"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpcode"].ToString().Trim();
                }
            }
            if (Request.QueryString["CntstCode"] != null)
            {
                if (Request.QueryString["CntstCode"].ToString().Trim() != null)
                {
                    cntstcd = Request.QueryString["CntstCode"].ToString().Trim();
                }
            }

            //if (Request.QueryString["ruletype"] != null)
            //{
            //    rultyp = Request.QueryString["ruletype"].ToString().Trim();
            //}
            rultyp = "R";
            mdlVw2.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster3('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdIndctr','" + rultyp.ToString().Trim() + "');", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdIndctr','" + value.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkAddRuleMst_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnAddRewardType_Click(object sender, EventArgs e)
    {
        try
        {
            string cmpnstcd = string.Empty, cntstcd = string.Empty, rultyp = string.Empty;
            if (Request.QueryString["cmpcode"] != null)
            {
                if (Request.QueryString["cmpcode"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpcode"].ToString().Trim();
                }
            }
            if (Request.QueryString["CntstCode"] != null)
            {
                if (Request.QueryString["CntstCode"].ToString().Trim() != null)
                {
                    cntstcd = Request.QueryString["CntstCode"].ToString().Trim();
                }
            }

            //if (Request.QueryString["ruletype"] != null)
            //{
            //    rultyp = Request.QueryString["ruletype"].ToString().Trim();
            //}


            rultyp = "R";
            mdlVw1.Show();


            // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdTrgt','" + rultyp.ToString().Trim() + "');", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster1('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdRule','" + rultyp.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnAddRewardType_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnAddQualTrg_Click(object sender, EventArgs e)
    {
        try
        {
            //////Session["gridTrg"] = null;
            string maxcatgcd = String.Empty;
            string maxsort = String.Empty;
            DataTable dtV = new DataTable();
            if (Session["QualTrg"] != null)
            {
                dtV = Session["QualTrg"] as DataTable;
                if (dtV.Rows.Count > 0)
                {
                    maxcatgcd = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["CATEGORY"].ToString())).ToString().Trim();
                    maxsort = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["SORT"].ToString())).ToString().Trim();
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + maxsort.ToString().Trim() + "','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','Q','" + maxcatgcd.ToString().Trim() + "','QualTrg');", true);
            //////ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','Q','" + ctgqualcd.ToString().Trim() + "','QualTrg');", true);
            ////btnAddRwdTrg.Attributes.Add("onclick", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
            /////Session["gridTrg"] = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnAddQualTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSaveQualTrg_Click(object sender, EventArgs e)
    {
        //////SaveTrg("QualTrg", "Q");
    }
    protected void btnqualtrg_Click(object sender, EventArgs e)
    {
        BindQualTrg(hdnFlag.Value.ToString().Trim());
    }
    protected void btnnextrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdTrg.PageIndex;
            dgRwdTrg.PageIndex = pageIndex + 1;
            BindRwdTrg();

            btnprevrwdtrg.Enabled = true;
            if (txtpgrwdtrg.Text == Convert.ToString(dgRwdTrg.PageCount))
            {
                btnnextrwdtrg.Enabled = false;
            }
            else
            {
                txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) + 1);
            }

            int page = dgRwdTrg.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnextrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevrwdtrg_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdTrg.PageIndex;
            dgRwdTrg.PageIndex = pageIndex - 1;
            BindRwdTrg();
            txtpgrwdtrg.Text = Convert.ToString(Convert.ToInt32(txtpgrwdtrg.Text) - 1);
            if (txtpgrwdtrg.Text == "1")
            {
                btnprevrwdtrg.Enabled = false;
            }
            else
            {
                btnprevrwdtrg.Enabled = true;
            }
            btnnextrwdtrg.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprevrwdtrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnrwdtrg_Click(object sender, EventArgs e)
    {
        //if (Session["gridTrg"] != null)
        //{
        //    dgRwdTrg.DataSource = Session["gridTrg"];
        //    dgRwdTrg.DataBind();
        //}
        BindRwdTrg();
    }
    //protected void btnSaveRwdTrg_Click(object sender, EventArgs e)
    //{
    //    //////SaveTrg("gridTrg", "R");
    //}

    protected string GetMaxCode(string flag)
    {
        string code = String.Empty;
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            code = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
        }
        return code.ToString().Trim();
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lblRulCode = (LinkButton)row.FindControl("lblRulCode");
            Label lblKPICode = (Label)row.FindControl("lblKPICode");
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            string msg;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@RuleCode", lblRulCode.Text.ToString().Trim());
            htParam.Add("@KPICode", lblKPICode.Text.ToString().Trim());
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "Q");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpCntKPI", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete the KPI');", true);
                }
            }
            ds.Clear();
            htParam.Clear();
            // BindGrid(dgQual, btnprevious, btnnext, chkQual, divqual, "Q", div12);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkDelRwd_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lblRulCode = (LinkButton)row.FindControl("lblRulCode");
            Label lblKPICode = (Label)row.FindControl("lblKPICode");
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            string msg;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@RuleCode", lblRulCode.Text.ToString().Trim());
            htParam.Add("@KPICode", lblKPICode.Text.ToString().Trim());
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "R");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelCmpCntKPI", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete the KPI');", true);
                }
            }
            ds.Clear();
            htParam.Clear();
            BindGrid(dgReward, btnprevrwd, btnnextrwd, chkRwd, divRwd, "R", divchkRwd);
            /////Session["gridTrg"] = dt;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDelRwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void dgRwdTrg_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["dgRwdTrg"];
            //ViewState["gridqualtrg"];
            //ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtpgrwdtrg.Text))
            {
                btnprevrwdtrg.Enabled = false;
                txtpgrwdtrg.Text = "1";
                btnnextrwdtrg.Enabled = true;
            }
            else
            {
                btnnextrwdtrg.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgRwdTrg_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BINDdgRwdMEM()
    {
        try
        {
            DataSet dsRwdMem = new DataSet();
            Hashtable htRwdMem = new Hashtable();
            htRwdMem.Clear();
            dsRwdMem.Clear();





            htRwdMem.Add("@CategoryCode", Request.QueryString["CategoryCode"].ToString().Trim());

            htRwdMem.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htRwdMem.Add("@ACC_CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htRwdMem.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());


            dsRwdMem = objDal.GetDataSetForPrc_SAIM("Prc_getMemberReward", htRwdMem);
            if (dsRwdMem.Tables.Count > 0 && dsRwdMem.Tables[0].Rows.Count > 0)
            {

                gvRwdAch.DataSource = dsRwdMem;
                gvRwdAch.DataBind();
            }
            BINDdgRwdMEMRevised();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BINDdgRwdMEM", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BINDdgRwdMEMRevised()
    {
        try
        {
            DataSet dsRwdMem = new DataSet();
            Hashtable htRwdMem = new Hashtable();
            htRwdMem.Clear();
            dsRwdMem.Clear();





            htRwdMem.Add("@CategoryCode", Request.QueryString["CategoryCode"].ToString().Trim());

            htRwdMem.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htRwdMem.Add("@ACC_CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htRwdMem.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());


            dsRwdMem = objDal.GetDataSetForPrc_SAIM("Prc_getMemberReward_revised", htRwdMem);
            if (dsRwdMem.Tables.Count > 0 && dsRwdMem.Tables[0].Rows.Count > 0)
            {

                GridView1.DataSource = dsRwdMem;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        { 
        //{
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BINDdgRwdMEMRevised", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void BINDdgTrgMEM()
    {
        try
        {
           DataSet dsMem = new DataSet();
           Hashtable htMem = new Hashtable();
           htMem.Clear();
           dsMem.Clear();





           htMem.Add("@CategoryCode", Request.QueryString["CategoryCode"].ToString().Trim());

            htMem.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htMem.Add("@ACC_CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htMem.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());


            dsMem = objDal.GetDataSetForPrc_SAIM("Prc_getMemberAchivement", htMem);
            if (dsMem.Tables.Count > 0 && dsMem.Tables[0].Rows.Count > 0)
            {

                dgTrgMEM.DataSource = dsMem;
                dgTrgMEM.DataBind();
            }

            BINDdgTrgMEMRevised();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BINDdgTrgMEM", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BINDdgTrgMEMRevised()
    {
        try
        {
            DataSet dsMem = new DataSet();
            Hashtable htMem = new Hashtable();
            htMem.Clear();
            dsMem.Clear();





            htMem.Add("@CategoryCode", Request.QueryString["CategoryCode"].ToString().Trim());

            htMem.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htMem.Add("@ACC_CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htMem.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());


            dsMem = objDal.GetDataSetForPrc_SAIM("Prc_getMemberAchivement_revised", htMem);
            if (dsMem.Tables.Count > 0 && dsMem.Tables[0].Rows.Count > 0)
            {

                GrdACHRevised.DataSource = dsMem;
                GrdACHRevised.DataBind();
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BINDdgTrgMEMRevised", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindRwdTrg()
    {
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            
            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htParam.Add("@CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htParam.Add("@MEMBER_CYCLE", Request.QueryString["RuleCode"].ToString().Trim());
        
            htParam.Add("@FLAG", "5");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
                //08_12_2017
                //dgRwdTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgRwdTrg.DataSource = ds;
                dgRwdTrg.DataBind();
                ViewState["dgRwdTrg"] = ds.Tables[0];

                if (dgRwdTrg.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
                {
                    btnnextrwdtrg.Enabled = true;
                }
                else
                {
                    btnnextrwdtrg.Enabled = false;
                }

                dgRwdTrg.Columns[13].Visible = true;
                //dgRwdTrg.Columns[14].Visible = true;
                //dgRwdTrg.Columns[15].Visible = true;
            }
            else
            {
                ShowNoRecQualTrg(ds.Tables[0], dgRwdTrg);
                btnSaveFn.Enabled = false;
                //dgRwdTrg.Columns[13].Visible = false;dgTrgMEM
                // dgRwdTrg.Columns[14].Visible = false;
                //// dgRwdTrg.Columns[15].Visible = false;

                txtpgrwdtrg.Text = "1";
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;
            }
            Session["gridTrg"] = ds.Tables[0];
            Session["gridTrg1"] = ds.Tables[1];
            Session["TblRowCount"] = 0;
            ViewState["TblRowCount1"] = 0;
            ////Session["grid"] = ds.Tables[0];


            BindRwdRevTrg();

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindRwdTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void BindRwdRevTrg()
    {
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());

            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

            htParam.Add("@CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htParam.Add("@MEMBER_CYCLE", Request.QueryString["RuleCode"].ToString().Trim());
            htParam.Add("@MEMBER_CODE", Request.QueryString["Memcode"].ToString().Trim());

          //  htParam.Add("@FLAG", "8");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls_Revised", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
                //08_12_2017
                //dgRwdTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                trgReviseGrd.DataSource = ds;
                trgReviseGrd.DataBind();
              //  ViewState["dgRwdTrg"] = ds.Tables[0];

                if (trgReviseGrd.PageCount > Convert.ToInt32(txtpgrwdtrg.Text))
                {
                    btnnextrwdtrg.Enabled = true;
                }
                else
                {
                    btnnextrwdtrg.Enabled = false;
                }

                trgReviseGrd.Columns[13].Visible = true;
                //dgRwdTrg.Columns[14].Visible = true;
                //dgRwdTrg.Columns[15].Visible = true;
            }
            else
            {
                ShowNoRecQualTrg(ds.Tables[0], trgReviseGrd);
                btnSaveFn.Enabled = false;
                //dgRwdTrg.Columns[13].Visible = false;
                // dgRwdTrg.Columns[14].Visible = false;
                //// dgRwdTrg.Columns[15].Visible = false;

                txtpgrwdtrg.Text = "1";
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;
            }
            //Session["gridTrg"] = ds.Tables[0];
            //Session["gridTrg1"] = ds.Tables[1];
            //Session["TblRowCount"] = 0;
            //ViewState["TblRowCount1"] = 0;
            ////Session["grid"] = ds.Tables[0];
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindRwdRevTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindQualTrg(string flag)
    {
        #region commentbindgrid
        //#region bindgrid
        //ds = new DataSet();
        //htParam.Clear();
        //ds.Clear();
        //htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
        //htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        //htParam.Add("@RULE_TYPE", "Q");
        //htParam.Add("@FLAG", "5");
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    if (hdnFlag.Value != null)
        //    {
        //        if (hdnFlag.Value == "S")
        //        {
        //            dgQualTrg.DataSource = ds.Tables[0];
        //            dgQualTrg.DataBind();
        //            Session["QualTrg"] = ds.Tables[0];
        //            dgQualTrg.Columns[13].Visible = true;
        //            dgQualTrg.Columns[14].Visible = true;
        //            dgQualTrg.Columns[15].Visible = true;
        //        }
        //        else
        //        {
        //            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //            {
        //                dgQualTrg.DataSource = ds;
        //                dgQualTrg.DataBind();
        //                Session["QualTrg"] = ds.Tables[0];
        //                dgQualTrg.Columns[13].Visible = true;
        //                dgQualTrg.Columns[14].Visible = true;
        //                dgQualTrg.Columns[15].Visible = true;
        //            }
        //            else
        //            {
        //                ShowNoRecQualTrg(ds.Tables[0], dgQualTrg);
        //                Session["QualTrg"] = ds.Tables[0];
        //                btnSaveFn.Enabled = false;
        //                //Added By Bhaurao
        //                //dgQualTrg.Columns[13].Visible = false;
        //                //dgQualTrg.Columns[14].Visible = false;
        //                // dgQualTrg.Columns[15].Visible = false;
        //            }
        //            //Added By Bhaurao
        //            //dgQualTrg.Columns[11].Visible = false;
        //            //dgQualTrg.Columns[12].Visible = false;
        //            //dgQualTrg.Columns[13].Visible = false;
        //        }
        //    }
        //}
        //else
        //{
        //    ShowNoRecQualTrg(ds.Tables[0], dgQualTrg);
        //    Session["QualTrg"] = ds.Tables[0];
        //    btnSaveFn.Enabled = false;

        //    //Added By Bhaurao
        //    dgQualTrg.Columns[11].Visible = false;
        //    dgQualTrg.Columns[12].Visible = false;
        //    //dgQualTrg.Columns[13].Visible = false;
        //}
        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
        //    if (hdnCatgCnt.Value != "0")
        //    {
        //        /////dgQualTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
        //    }
        //}
        //if (dgQualTrg.PageCount > 1)
        //{
        //    btnnextkpitrg.Enabled = true;
        //}
        //else
        //{
        //    btnnextkpitrg.Enabled = false;
        //}
        //Session["QualTrg1"] = ds.Tables[1];
        //#endregion
        #endregion
        #region bindgrid
        try
        {
            ds = new DataSet();
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@RULE_TYPE", "Q");
            if (Request.QueryString["RSetKey"] != null)
            {
                if (Request.QueryString["RSetKey"].ToString().Trim() != "")
                {
                    htParam.Add("@RULE_SET_KEY", Request.QueryString["RSetKey"].ToString().Trim());
                }
            }
            htParam.Add("@FLAG", "5");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsTMP_TARGET", htParam);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    hdnCatgCnt.Value = ds.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
                    if (hdnCatgCnt.Value != "0")
                    {
                        dgQualTrg.PageSize = Convert.ToInt32(hdnCatgCnt.Value.ToString().Trim());
                    }
                }
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgQualTrg.DataSource = ds;
                dgQualTrg.DataBind();
                ViewState["gridqualtrg"] = ds.Tables[0];
                Session["QualTrg"] = ds.Tables[0];
                dgQualTrg.Columns[13].Visible = true;
                dgQualTrg.Columns[14].Visible = true;
                dgQualTrg.Columns[15].Visible = true;

                if (dgQualTrg.PageCount > Convert.ToInt32(txtpagetrg.Text))
                {
                    btnnextkpitrg.Enabled = true;
                }
                else
                {
                    btnnextkpitrg.Enabled = false;
                }
            }
            else
            {
                ShowNoRecQualTrg(ds.Tables[0], dgQualTrg);
                Session["QualTrg"] = ds.Tables[0];
                btnSaveFn.Enabled = false;
                //Added By Bhaurao
           //     //dgQualTrg.Columns[13].Visible = false;
                //dgQualTrg.Columns[14].Visible = false;
                // dgQualTrg.Columns[15].Visible = false;


                txtpagetrg.Text = "1";
                btnprevkpitrg.Enabled = false;
                btnnextkpitrg.Enabled = false;
            }

            //if (dgQualTrg.PageCount == 0)
            //{
            //    btnnextkpitrg.Enabled = false;
            //    btnprevkpitrg.Enabled = false;
            //    txtpagetrg.Text = "1";

            //}
            //if (dgQualTrg.PageCount > Convert.ToInt32(txtpagetrg.Text))
            //{
            //    btnnextkpitrg.Enabled = true;
            //}
            //else
            //{
            //    btnnextkpitrg.Enabled = false;
            //}



            Session["QualTrg1"] = ds.Tables[1];


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "bindgrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        #endregion
    }

    private void ShowNoRecQualTrg(DataTable source, GridView gv)
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
            gv.Rows[0].Cells[0].Text = "No targets have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "ShowNoRecQualTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAddRwdTrg_Click(object sender, EventArgs e)
    {
        try
        {
            //////Session["gridTrg"] = null;
            string maxcatgcd = String.Empty;
            string maxsort = String.Empty;
            DataTable dtV = new DataTable();
            if (Session["gridTrg"] != null)
            {
                dtV = Session["gridTrg"] as DataTable;
                if (dtV.Rows.Count > 0)
                {
                    maxcatgcd = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["CATEGORY"].ToString())).ToString().Trim();
                    maxsort = (Convert.ToInt32(dtV.Rows[dtV.Rows.Count - 1]["SORT"].ToString())).ToString().Trim();
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrg('" + maxsort.ToString().Trim() + "','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + maxcatgcd.ToString().Trim() + "','gridTrg');", true);
            ////btnAddRwdTrg.Attributes.Add("onclick", "funPopUpTrg('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R');return false;");
            /////Session["gridTrg"] = null;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnAddRwdTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void lnkDelRwdTrg_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
            Label lblCatgCode = (Label)row.FindControl("lblCatgCode");
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            string msg;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CODE", hdnCode.Value.ToString().Trim());
            htParam.Add("@CATG_CODE", lblCatgCode.Text.ToString().Trim());
            htParam.Add("@RULE_TYPE", "R");
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelTrgDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete the KPI Target');", true);
                }
            }

            BindRwdTrg();

            int pageIndex = dgRwdTrg.PageIndex;
            int pageIndex1 = dgRwdTrg.PageCount;

            if (pageIndex == 1)
            {
                //txtpgrwdtrg.Text = "2";
                txtpgrwdtrg.Text = pageIndex1.ToString();
                btnprevrwdtrg.Enabled = true;
                btnnextrwdtrg.Enabled = true;

            }
            else
            {
                txtpgrwdtrg.Text = pageIndex1.ToString();
                //txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) - 1);
                //  btnprevkpitrg.Enabled = true;
                // btnnextkpitrg.Enabled = true;

            }
            if (pageIndex == 0)
            {
                //txtpgrwdtrg.Text = "1";
                txtpgrwdtrg.Text = pageIndex1.ToString();
                btnprevrwdtrg.Enabled = false;
                btnnextrwdtrg.Enabled = false;

            }

            BindRwdTrg();
            htParam.Clear();
            ds.Clear();
            //DataTable dt = (DataTable)Session["gridTrg"];
            //dt.Rows[rowIndex].Delete();
            //dt.AcceptChanges();
            //if (dt.Rows.Count > 0)
            //{
            //    dgRwdTrg.DataSource = dt;
            //    dgRwdTrg.DataBind();
            //}
            //else
            //{
            //    ShowNoResultFound(dt, dgRwdTrg);
            //}
            //Session["gridTrg"] = dt;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDelRwdTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgRwdTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
                LinkButton lnkDelRwdTrg = (LinkButton)e.Row.FindControl("lnkDelRwdTrg");
                LinkButton lnkKPITrgtSetRule = (LinkButton)e.Row.FindControl("lnkKPITrgtSetRule");
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEditRwdTrg.Enabled = false;
                        lnkDelRwdTrg.Enabled = false;
                        lnkKPITrgtSetRule.Enabled = false;
                    }
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgRwdTrg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevrwdrul_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdRul.PageIndex;
            dgRwdRul.PageIndex = pageIndex - 1;
            BindRwdRul("N");
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) - 1);
            if (txtPageRwdRul.Text == "1")
            {
                btnprevrwdrul.Enabled = false;
            }
            else
            {
                btnprevrwdrul.Enabled = true;
            }
            btnnextrwdrul.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprevrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnextrwdrul_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgRwdRul.PageIndex;

            dgRwdRul.PageIndex = pageIndex + 1;
            BindRwdRul("N");
            txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) + 1);
            btnprevrwdrul.Enabled = true;
            if (txtPageRwdRul.Text == Convert.ToString(dgRwdRul.PageCount))
            {
                btnnextrwdrul.Enabled = false;
            }

            int page = dgRwdRul.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnextrwdrul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnAddRwdRul_Click(object sender, EventArgs e)
    {


    }

    protected void btnAddRwdRul2_Click(object sender, EventArgs e)
    {


        //   DataSet ds = new DataSet();

        //   Hashtable htParam = new Hashtable();
        //   htParam.Add("@CMPNSTN_CODE",Request.QueryString["CmpCode"].ToString());
        //   htParam.Add("@CNTSTNT_CODE",  Request.QueryString["CntstCode"].ToString());
        ////   htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());

        //   ds = objDal.GetDataSetForPrc_SAIM("PrcIns_Mst_Cntstnt_KPI_Rwrd_Rul_NStdComm", htParam);




    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();

            Hashtable htParam = new Hashtable();
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString());
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString());
            htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());
            //   htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());

            //  ds = objDal.GetDataSetForPrc_SAIM("PrcIns_Mst_Cntstnt_KPI_Rwrd_Rul_NStdComm", htParam);

            //if (ds.Tables.Count > 0)
            //{
            //    ds.Tables[0].Rows[0]["status"].ToString();

            //    if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please complete all cycle setup');", true);

            //    }
            //    else
            //    {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Set up done successfully');", true);
            BindRwdRul("N");
            //    }

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Set up done successfully');", true);
            //    BindRwdRul("N");
            //}
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "LinkButton2_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void lnkDelRwdRul_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblRwdRulCode = (Label)row.FindControl("lblRwdRulCode");
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@RWRD_RUL_CODE", lblRwdRulCode.Text.ToString().Trim());
            htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRulDtls", htParam);


            BindRwdRul("N");
            ds.Clear();
            htParam.Clear();
            //int pageIndex = dgQualTrg.PageIndex;
            //int pageIndex1 = dgQualTrg.PageCount;

            //if (pageIndex == 1)
            //{
            //    txtpagetrg.Text = "2";
            //    txtpagetrg.Text = pageIndex1.ToString();
            //    btnprevkpitrg.Enabled = true;
            //    btnnextkpitrg.Enabled = true;

            //}
            //else
            //{
            //    //txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) - 1);
            //  //  btnprevkpitrg.Enabled = true;
            //   // btnnextkpitrg.Enabled = true;


            //}
            //if (pageIndex == 0)
            //{
            //    txtpagetrg.Text = "1";           
            //    txtpagetrg.Text = pageIndex1.ToString();
            //    btnprevkpitrg.Enabled = false;
            //    btnnextkpitrg.Enabled = false;

            //}
            //    BindQualTrg(hdnFlag.Value.ToString().Trim());
            //    ds.Clear();
            //    htParam.Clear();
            //}


            int pageIndex = dgRwdRul.PageIndex;
            int pageIndex1 = dgRwdRul.PageCount;

            if (pageIndex == 1)
            {
                txtPageRwdRul.Text = "2";
                txtPageRwdRul.Text = pageIndex1.ToString();
                btnprevrwdrul.Enabled = true;
                btnnextrwdrul.Enabled = true;

            }
            else
            {

                txtPageRwdRul.Text = pageIndex1.ToString();
                //txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) - 1);
                //btnprevrwdrul.Enabled = true;
                //btnnextrwdrul.Enabled = true;

            }
            if (pageIndex == 0)
            {
                txtPageRwdRul.Text = "1";
                txtPageRwdRul.Text = pageIndex1.ToString();
                btnprevrwdrul.Enabled = false;
                btnnextrwdrul.Enabled = false;

            }

            BindRwdRul("N");
            //DataTable dt = (DataTable)Session["RwdRul"];
            //dt.Rows[rowIndex].Delete();
            //dt.AcceptChanges();
            //if (dt.Rows.Count > 0)
            //{
            //    dgRwdRul.DataSource = dt;
            //    dgRwdRul.DataBind();
            //}
            //else
            //{
            //    ShowNoResultFound(dt, dgRwdRul);ShowNoResultFound(dt, dgRwdRul);
            //}
            //Session["RwdRul"] = dt;
        }
        catch (Exception ex)
        {
            ////string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            ////System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            ////string sRet = oInfo.Name;
            ////System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            ////String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDelRwdRul_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void BindRwdRul(string flag)
    {
        try
        {

            DataSet dsReward = new DataSet();

            dsReward = GetRewardDtls(flag);
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                hdnRwrdCnt.Value = dsReward.Tables[1].Rows[dgRwdRul.PageIndex]["CATG_CNT"].ToString().Trim();
                // dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
            }
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                ViewState["dgRwdRul"] = dsReward.Tables[0];
                dgRwdRul.DataSource = dsReward;
                dgRwdRul.DataBind();
                /////ViewState["dgRwdRul"]= ds.Tables[0];

                btnSaveFn.Enabled = true;
                if (dgRwdRul.PageCount > Convert.ToInt32(txtPageRwdRul.Text.Trim()))
                {
                    btnnextrwdrul.Enabled = true;
                }
                else
                {
                    btnnextrwdrul.Enabled = false;
                }

            }
            else
            {
                dgRwdRul.AllowSorting = false;
                ShowNoRecRwdRul(dsReward.Tables[0], dgRwdRul);
                btnSaveFn.Enabled = false;
            }
            Session["RwdRul"] = dsReward.Tables[0];
            ////Session["RwdRul1"] = ds.Tables[1];
            Session["TblRwrdRowCount"] = 0;
            ViewState["TblRwrdRowCount"] = 0;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindRwdRul", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private DataSet GetRewardDtls(string flag)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@RULE_TYPE", "R");
        
       htParam.Add("@RULE_SET_CODE", Request.QueryString["RuleSetkey"].ToString().Trim());

       htParam.Add("@CATG_CODE2", Request.QueryString["CategoryCode"].ToString().Trim());
       htParam.Add("@ACC_CYCLE", Request.QueryString["Cycle"].ToString().Trim());

        
        if (Request.QueryString["Page"] != null)
        {
            htParam.Add("@Page", Request.QueryString["Page"].ToString().Trim());
            htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());
        }


        if (Request.QueryString["Page"] != null && flag == "N")
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }

        else if (Request.QueryString["Page"] != null && flag == "P")
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }

        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
        }

        return ds;
    }

    //protected void BindQualRul()
    //{
    //    ds = new DataSet();
    //    htParam.Clear();
    //    ds.Clear();
    //    htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
    //    htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
    //    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        hdnQualCnt.Value = ds.Tables[1].Rows[0]["COUNT"].ToString().Trim();
    //        //hdnRwrdCnt.Value = "6";
    //        dgQualRul.PageSize = Convert.ToInt32(hdnQualCnt.Value.ToString().Trim());
    //        dgQualRul.DataSource = ds;
    //        dgQualRul.DataBind();
    //        if (dgQualRul.PageCount > 1)
    //        {
    //            btnnextqualrul.Enabled = true;
    //        }
    //        else
    //        {
    //            btnnextqualrul.Enabled = false;
    //        }
    //    }
    //    else
    //    {
    //        ShowNoRecRwdRul(ds.Tables[0], dgQualRul);
    //    }
    //    Session["QualRul"] = ds.Tables[0];
    //    Session["QualRul1"] = ds.Tables[1];
    //    ///Session["TblRwrdRowCount"] = 0;
    //    ///ViewState["TblRwrdRowCount"] = 0;
    //}


    protected void dgRwdRul_Sorting(object sender, GridViewSortEventArgs e)
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
            BindRwdRul("N");
            DataTable dt = (DataTable)ViewState["dgRwdRul"];

            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                //dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                if (dgSource.PageCount >= Convert.ToInt32(txtPageRwdRul.Text))
                {
                    btnprevrwdrul.Enabled = false;
                    txtPageRwdRul.Text = "1";
                    btnnextrwdrul.Enabled = true;
                }
                else
                {
                    btnnextrwdrul.Enabled = false;
                }
            }
            else
            {
                DataSet ds = null;
                ShowNoRecRwdRul(ds.Tables[0], dgRwdRul);
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgRwdRul_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private void ShowNoRecRwdRul(DataTable source, GridView gv)
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
            gv.Rows[0].Cells[0].Text = "No rules have been defined";
            source.Rows.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "ShowNoRecRwdRul", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnrwdrul_Click(object sender, EventArgs e)
    {


        BindRwdRul("N");
        //DataTable dt = new DataTable();
        //if (Session["RwdRul"] != null)
        //{
        //    dt = Session["RwdRul"] as DataTable;
        //    dgRwdRul.DataSource = dt;
        //    dgRwdRul.DataBind();
        //    DataSet dsRul = new DataSet();
        //    Hashtable htRul = new Hashtable();
        //    htRul.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        //    htRul.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        //    dsRul = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdTrgDtls", htRul);
        //    if (dsRul.Tables.Count > 0 && dsRul.Tables[0].Rows.Count > 0)
        //    {
        //        hdnRwrdCnt.Value = dsRul.Tables[1].Rows[0]["CATG_CNT"].ToString().Trim();
        //        dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
        //    }
        //    if (dt.Rows.Count > Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim()))
        //    {
        //        btnnextrwdrul.Enabled = true;
        //    }
        //    else
        //    {
        //        btnnextrwdrul.Enabled = false;
        //    }

        //}
        //int a22;
        //DataTable dtRwrdRul = new DataTable();
        //dtRwrdRul = Session["RwdRul"] as DataTable;
        //DataTable dtRwrdRul1 = new DataTable();
        //dtRwrdRul1 = Session["RwdRul1"] as DataTable;
        //DataTable dtRwrdbind = new DataTable();
        //dtRwrdbind = dtRwrdRul.Clone();
        //txtPageRwdRul.Text = "0";
        //if (Session["RwdRul"] != null)
        //{
        //    //dgRwdTrg.DataSource = Session["gridTrg"];
        //    //dgRwdTrg.DataBind();
        //    Session["TblRwrdRowCount"] = 0;
        //    ViewState["TblRwrdRowCount1"] = 0;

        //    int a = Convert.ToInt32(Session["TblRwrdRowCount"]);
        //    string cycle = dtRwrdRul1.Rows[a][1].ToString();
        //    int count = Convert.ToInt32(dtRwrdRul1.Rows[a][0]);
        //    foreach (DataRow dr in dtRwrdRul.Rows)
        //    {
        //        if (dr["CYCLE"].ToString().Trim() == cycle.Trim())
        //        {
        //            DataRow drNew = dtRwrdbind.NewRow();
        //            drNew.ItemArray = dr.ItemArray;
        //            dtRwrdbind.Rows.Add(drNew);
        //            a22 = dtRwrdbind.Rows.Count;
        //            ViewState["RwrdCount"] = a22;
        //        }
        //    }
        //    if (Session["RwdRul"] != null)
        //    {
        //        dgRwdRul.PageSize = Convert.ToInt32(ViewState["RwrdCount"]);
        //        Session["dtRwrdbind"] = dtRwrdbind;
        //        dgRwdRul.DataSource = Session["dtRwrdbind"];
        //        dgRwdRul.DataBind();
        //    }
        //    txtPageRwdRul.Text = Convert.ToString(Convert.ToInt32(txtPageRwdRul.Text) + 1);
        //    if (txtPageRwdRul.Text == "1")
        //    {
        //        btnprevrwdrul.Enabled = false;
        //    }
        //    else
        //    {
        //        btnprevrwdrul.Enabled = true;
        //    }
        //    if (Convert.ToInt32(txtPageRwdRul.Text) < dtRwrdRul1.Rows.Count)
        //    {
        //        btnnextrwdrul.Enabled = true;
        //    }
        //    else
        //    {
        //        btnnextrwdrul.Enabled = false;
        //    }
        //}
    }
    protected void btnSaveRwdRul_Click(object sender, EventArgs e)
    {

    }

    protected void dgRwdRul_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                if (Session["RwdRul"] != null)
                {
                    ////dt = Session["RwdRul"] as DataTable;
                    dt = ViewState["dgRwdRul"] as DataTable;
                    Label lblBsdKpi = (Label)e.Row.FindControl("lblBsdKpi");
                    Label lblBrkRul = (Label)e.Row.FindControl("lblBrkRul");
                    GridView dgCntst = (GridView)e.Row.FindControl("dgCntst");

                    BindGrid(lblBrkRul.Text.ToString(), dgCntst);

                    Label lblRATE = (Label)e.Row.FindControl("lblRATE");
                    HiddenField hdnType = (HiddenField)e.Row.FindControl("hdnKPICode");//////UnitType
                    Label lblValue = (Label)e.Row.FindControl("lblValue");
                    LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnkValue");
                    //added by arjun for the uat bug fixing
                    LinkButton lnkEditRwdRul = (LinkButton)e.Row.FindControl("lnkEditRwdRul");
                    LinkButton lnkDelRwdRul = (LinkButton)e.Row.FindControl("lnkDelRwdRul");



                    Label lblMEMBERCODE = (Label)e.Row.FindControl("lblMEMBERCODE");
                    //END

                    if (dt.Rows.Count > 0)
                    //added by arjun for the uat bug fixing
                    {
                        if (lblMEMBERCODE.Text != "" && Request.QueryString["Page"] == null)
                        {

                            lnkEditRwdRul.Visible = false;
                            lnkDelRwdRul.Visible = false;
                        }
                        //END
                        //added by ajay sawant

                        //if (lblBsdKpi.Text != null)
                        //{
                        //    if (lblBsdKpi.Text == "")
                        //    {
                        //        e.Row.Cells[7].Text = "NA";
                        //        e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //    if (lblBsdKpi.Text == "--SELECT--")
                        //    {
                        //        e.Row.Cells[7].Text = "NA";
                        //        e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (lblBrkRul.Text != null)
                        //{
                        //    if (lblBrkRul.Text == "")
                        //    {
                        //        e.Row.Cells[10].Text = "NA";
                        //        e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (lblRATE.Text != null)
                        //{
                        //    if (lblRATE.Text == "")
                        //    {
                        //        e.Row.Cells[11].Text = "NA";
                        //        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}
                        //if (hdnType.Value == "F")
                        //{
                        //    lnkValue.Visible = true;
                        //    lblValue.Visible = false;
                        //}
                        //else
                        //{
                        //    lnkValue.Visible = false;
                        //    lblValue.Visible = true;
                        //}

                        // ended by ajay
                    }
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgRwdRul_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }





    protected void lnkKPITrgtSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField hdnRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");

            HiddenField HiddenRulecode = (HiddenField)grd.FindControl("HiddenRulecode");
            HiddenField HiddenCycleCode = (HiddenField)grd.FindControl("HiddenCycleCode");
            HiddenField HiddenKpiCode = (HiddenField)grd.FindControl("HiddenKpiCode");
            HiddenField hdnCatgCode = (HiddenField)grd.FindControl("hdnCatgCode");
            HiddenField hdnCode = (HiddenField)grd.FindControl("hdnCode");
            HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");

            if (hdnKpiOrg.Value == "1002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
                return;
            }
            else if (hdnKpiOrg.Value == "1003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
                return;
            }




            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", HiddenKpiCode.Value.ToString());
            htparam.Add("@RULE_CODE", HiddenRulecode.Value.ToString());
            htparam.Add("@RULE_SET_KEY", hdnRulStKy.Value.ToString());

            htparam.Add("@CATG_CODE", hdnCatgCode.Value.ToString().Trim());
            htparam.Add("@CODE", hdnCode.Value.ToString().Trim());

            htparam.Add("@CYCLE_CODE", HiddenCycleCode.Value.ToString());


            htparam.Add("@VER_EFF_FROM", "");

            htparam.Add("@VER_EFF_TO", "");

            htparam.Add("@CREATED_BY", "");
            htparam.Add("@KpiFlag", "1");


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

            string flag = string.Empty;
            if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
            {
                flag = "kpi";
            }
            else
            {
                flag = "rsKPITrg";
            }

            //Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=" + flag.Trim() + "&mapcode=" + mapcode
            //    + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "&KPI_CODE=" + HiddenKpiCode.Value.ToString().Trim()
            //    + "&DRVDKPI=" + drvdkpi.ToString().Trim(), true);

            string lnkbtn = "lnkKPITrgtSetRule";

            if (Request.QueryString["Flag2"] != null)
            {
                if (Request.QueryString["Flag2"].ToString().Trim() == "EX")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + HiddenCycleCode.Value + "','" + lnkbtn + "','O');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + "" + "','" + lnkbtn + "','O');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + "" + "','" + lnkbtn + "','O');", true);
            }


            //  Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPg2_StdDef.html", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkKPITrgtSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkKPITrgtSetRule2_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField hdnRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");

            HiddenField HiddenRulecode = (HiddenField)grd.FindControl("HiddenRulecode");
            HiddenField HiddenCycleCode = (HiddenField)grd.FindControl("HiddenCycleCode");
            HiddenField HiddenKpiCode = (HiddenField)grd.FindControl("HiddenKpiCode");
            HiddenField hdnCatgCode = (HiddenField)grd.FindControl("hdnCatgCode");
            HiddenField hdnCode = (HiddenField)grd.FindControl("hdnCodeREV");
            HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");

            if (hdnKpiOrg.Value == "1002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
                return;
            }
            else if (hdnKpiOrg.Value == "1003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
                return;
            }




            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", HiddenKpiCode.Value.ToString());
            htparam.Add("@RULE_CODE", HiddenRulecode.Value.ToString());
            htparam.Add("@RULE_SET_KEY", hdnRulStKy.Value.ToString());

            htparam.Add("@CATG_CODE", hdnCatgCode.Value.ToString().Trim());
            htparam.Add("@CODE", hdnCode.Value.ToString().Trim());

            htparam.Add("@CYCLE_CODE", HiddenCycleCode.Value.ToString());


            htparam.Add("@VER_EFF_FROM", "");

            htparam.Add("@VER_EFF_TO", "");

            htparam.Add("@CREATED_BY", "");
            htparam.Add("@KpiFlag", "1");


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

            string flag = string.Empty;
            if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
            {
                flag = "kpi";
            }
            else
            {
                flag = "rsKPITrg";
            }

            //Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=" + flag.Trim() + "&mapcode=" + mapcode
            //    + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "&KPI_CODE=" + HiddenKpiCode.Value.ToString().Trim()
            //    + "&DRVDKPI=" + drvdkpi.ToString().Trim(), true);

            string lnkbtn = "lnkKPITrgtSetRule";

            if (Request.QueryString["Flag2"] != null)
            {
                if (Request.QueryString["Flag2"].ToString().Trim() == "EX")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + HiddenCycleCode.Value + "','" + lnkbtn + "','R');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + "" + "','" + lnkbtn + "','R');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funViewStddef('" + "INC" + "','" + flag.Trim() + "','" + mapcode + "','" + Request.QueryString["RuleSetKey"].ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString().Trim() + "','" + lblCompCodeVal.Text + "','" + lblCntstCdVal.Text + "','" + HiddenKpiCode.Value.ToString().Trim() + "','" + drvdkpi.ToString().Trim() + "','" + "" + "','" + lnkbtn + "','R');", true);
            }


            //  Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPg2_StdDef.html", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkKPITrgtSetRule2_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkKPISetRule_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField lblRulCode = (HiddenField)grd.FindControl("hdnRulCode");
            HiddenField lblRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");
            HiddenField lblKPICode = (HiddenField)grd.FindControl("hdnKPICode");
            HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");
            if (hdnKpiOrg.Value == "1002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
                return;
            }
            else if (hdnKpiOrg.Value == "1003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
                return;
            }


            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", lblKPICode.Value.ToString());
            htparam.Add("@RULE_CODE", lblRulCode.Value.ToString());
            htparam.Add("@RULE_SET_KEY", lblRulStKy.Value.ToString());

            htparam.Add("@CATG_CODE", "");
            htparam.Add("@CODE", "");

            htparam.Add("@CYCLE_CODE", "");


            htparam.Add("@VER_EFF_FROM", "");

            htparam.Add("@VER_EFF_TO", "");

            htparam.Add("@CREATED_BY", "");




            ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTN", htparam, "SAIMConnectionString");

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

            string flag = string.Empty;
            if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
            {
                flag = "kpi";
            }
            else
            {
                flag = "rsKPI";
            }

            Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=" + flag.Trim() + "&mapcode=" + mapcode
                + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "&KPI_CODE=" + lblKPICode.Value.ToString().Trim()
                + "&DRVDKPI=" + drvdkpi.ToString().Trim(), true);
            /////Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?&flag=in&mapcode=" + mapcode + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "", true);




        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkKPISetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkDelQualTrg_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
            Label lblCatgCode = (Label)row.FindControl("lblCatgCode");
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            string msg;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CODE", hdnCode.Value.ToString().Trim());
            htParam.Add("@CATG_CODE", lblCatgCode.Text.ToString().Trim());
            htParam.Add("@RULE_TYPE", "Q");
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelTrgDtls", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msg == "NO DELETE")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete the KPI Target');", true);
                }
            }
            BindQualTrg(hdnFlag.Value.ToString().Trim());


            int pageIndex = dgQualTrg.PageIndex;
            int pageIndex1 = dgQualTrg.PageCount;

            if (pageIndex == 1)
            {
                txtpagetrg.Text = "2";
                txtpagetrg.Text = pageIndex1.ToString();
                btnprevkpitrg.Enabled = true;
                btnnextkpitrg.Enabled = true;

            }
            else
            {
                txtpagetrg.Text = pageIndex1.ToString();
                //txtpagetrg.Text = Convert.ToString(Convert.ToInt32(txtpagetrg.Text) - 1);
                //  btnprevkpitrg.Enabled = true;
                // btnnextkpitrg.Enabled = true;


            }
            if (pageIndex == 0)
            {
                txtpagetrg.Text = "1";
                txtpagetrg.Text = pageIndex1.ToString();
                btnprevkpitrg.Enabled = false;
                btnnextkpitrg.Enabled = false;

            }
            BindQualTrg(hdnFlag.Value.ToString().Trim());
            ds.Clear();
            htParam.Clear();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkDelQualTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void SaveTrg(string ID, string rultyp)
    {
        try
        {
            #region SAVE KPI TARGETS
            DataTable dtRwd = new DataTable();
            dtRwd = Session[ID] as DataTable;
            ds = new DataSet();
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
            /////htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_DelRwdTrgDtls", htParam);

            List<string> lstRulSetKey = new List<string>();
            List<string> lstCatgCode = new List<string>();
            List<string> lstCatgDesc = new List<string>();
            List<string> lstRuleCode = new List<string>();
            List<string> lstKPICode = new List<string>();
            List<string> lstTrgFrm = new List<string>();
            List<string> lstTrgTo = new List<string>();
            List<string> lstBusiCo = new List<string>();
            List<string> lstCycle = new List<string>();
            List<string> lstCycleCode = new List<string>();
            List<string> lstCode = new List<string>();
            List<string> lstEffDtFrm = new List<string>();
            List<string> lstEffDtTo = new List<string>();
            List<string> lstSbCtgry = new List<string>();
            List<string> lstPExcl = new List<string>();
            List<string> lstSExcl = new List<string>();
            List<string> lstSort = new List<string>();

            for (int intRowCount = 0; intRowCount <= dtRwd.Rows.Count - 1; intRowCount++)
            {
                HiddenField hdnRulStKy = new HiddenField();
                HiddenField hdnCode = new HiddenField();
                HiddenField hdnCatgCode = new HiddenField();
                HiddenField hdnCycle = new HiddenField();
                HiddenField hdnCycleCode = new HiddenField();
                HiddenField hdnCatDsc = new HiddenField();
                HiddenField hdnKPICode = new HiddenField();
                HiddenField hdnTrgFrm = new HiddenField();
                HiddenField hdnTrgTo = new HiddenField();
                HiddenField hdnBusiCode = new HiddenField();
                HiddenField hdnEffDtFrm = new HiddenField();
                HiddenField hdnEffDtTo = new HiddenField();
                HiddenField hdnSbCtgry = new HiddenField();
                HiddenField hdnPExcl = new HiddenField();
                HiddenField hdnSExcl = new HiddenField();
                HiddenField hdnSort = new HiddenField();

                hdnRulStKy.Value = dtRwd.Rows[intRowCount]["RULE_SET_KEY"].ToString().Trim();
                lstRulSetKey.Add(hdnRulStKy.Value.ToString().Trim());
                hdnCode.Value = dtRwd.Rows[intRowCount]["CODE"].ToString().Trim();
                lstCode.Add(hdnCode.Value.ToString().Trim());
                hdnCatgCode.Value = dtRwd.Rows[intRowCount]["CATEGORY"].ToString().Trim();
                lstCatgCode.Add(hdnCatgCode.Value.ToString().Trim());
                hdnCycle.Value = dtRwd.Rows[intRowCount]["CYCLE"].ToString().Trim();
                lstCycle.Add(hdnCycle.Value.ToString().Trim());
                hdnCycleCode.Value = dtRwd.Rows[intRowCount]["CYCLE_CODE"].ToString().Trim();
                lstCycleCode.Add(hdnCycleCode.Value.ToString().Trim());
                hdnCatDsc.Value = dtRwd.Rows[intRowCount]["CATG_DESC"].ToString().Trim();
                lstCatgDesc.Add(hdnCatDsc.Value.ToString().Trim());
                hdnKPICode.Value = dtRwd.Rows[intRowCount]["KPI_CODE"].ToString().Trim();
                lstKPICode.Add(hdnKPICode.Value.ToString().Trim());
                hdnTrgFrm.Value = dtRwd.Rows[intRowCount]["TRG_FRM"].ToString().Trim();
                lstTrgFrm.Add(hdnTrgFrm.Value.ToString().Trim());
                hdnTrgTo.Value = dtRwd.Rows[intRowCount]["TRG_TO"].ToString().Trim();
                lstTrgTo.Add(hdnTrgTo.Value.ToString().Trim());
                hdnEffDtFrm.Value = dtRwd.Rows[intRowCount]["EFFDT_FROM"].ToString().Trim();
                lstEffDtFrm.Add(hdnEffDtFrm.Value.ToString().Trim());
                hdnEffDtTo.Value = dtRwd.Rows[intRowCount]["EFFDT_TO"].ToString().Trim();
                lstEffDtTo.Add(hdnEffDtTo.Value.ToString().Trim());
                hdnBusiCode.Value = dtRwd.Rows[intRowCount]["BUSI_CODE"].ToString().Trim();
                lstBusiCo.Add(hdnBusiCode.Value.ToString().Trim());
                hdnSbCtgry.Value = dtRwd.Rows[intRowCount]["CATSET"].ToString().Trim();
                lstSbCtgry.Add(hdnSbCtgry.Value.ToString().Trim());
                hdnPExcl.Value = dtRwd.Rows[intRowCount]["P_EXCL"].ToString().Trim();
                lstPExcl.Add(hdnPExcl.Value.ToString().Trim());
                hdnSExcl.Value = dtRwd.Rows[intRowCount]["S_EXCL"].ToString().Trim();
                lstSExcl.Add(hdnSExcl.Value.ToString().Trim());
                hdnSort.Value = dtRwd.Rows[intRowCount]["SORT"].ToString().Trim();
                lstSort.Add(hdnSort.Value.ToString().Trim());
            }

            for (int intDataCount = 0; intDataCount <= lstRulSetKey.Count - 1; intDataCount++)
            {
                htParam.Clear();
                ds.Clear();
                htParam.Add("@CODE", lstCode[intDataCount]);
                htParam.Add("@CATG_CODE", lstCatgCode[intDataCount]);
                htParam.Add("@CYCLE", lstCycleCode[intDataCount]);
                htParam.Add("@RULE_SET_KEY", lstRulSetKey[intDataCount]);
                htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
                htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
                htParam.Add("@CATG_DESC01", lstCatgDesc[intDataCount]);
                htParam.Add("@CATG_DESC02", lstCatgDesc[intDataCount]);
                htParam.Add("@CATG_DESC03", lstCatgDesc[intDataCount]);
                htParam.Add("@EFF_FROM", lstEffDtFrm[intDataCount]);
                htParam.Add("@EFF_TO", lstEffDtTo[intDataCount]);
                htParam.Add("@FIN_YEAR", lstBusiCo[intDataCount]);
                htParam.Add("@VER_NO", lblVerVal.Text.ToString().Trim());
                htParam.Add("@VER_EFF_FROM", Convert.ToDateTime(lblEffDtFrmVal.Text.ToString().Trim()));
                htParam.Add("@VER_EFF_TO", Convert.ToDateTime(lblEffDtToVal.Text.ToString().Trim()));
                htParam.Add("@KPI_TRGT_FROM", lstTrgFrm[intDataCount]);
                htParam.Add("@KPI_TRGT_TO", lstTrgTo[intDataCount]);
                htParam.Add("@KPI_CODE", lstKPICode[intDataCount]);
                htParam.Add("@CATSET", lstSbCtgry[intDataCount]);
                htParam.Add("@P_EXCL", lstPExcl[intDataCount]);
                htParam.Add("@S_EXCL", lstSExcl[intDataCount]);
                htParam.Add("@SORT", lstSort[intDataCount]);
                htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                ////htParam.Add("@RULE_TYPE", rultyp.ToString().Trim());
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRwdTrgDtls", htParam);
            }
            hdnCatgCnt.Value = lstCatgCode.Count.ToString().Trim();
            mdlpopup.Show();
            lbl3.Text = "KPI Targets saved successfully for rewards";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();
            btnSaveRwdTrg.Enabled = true;
            #endregion
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "SaveTrg", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgQualTrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkEditQualTrg = (LinkButton)e.Row.FindControl("lnkEditQualTrg");
                LinkButton lnkDelQualTrg = (LinkButton)e.Row.FindControl("lnkDelQualTrg");
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEditQualTrg.Enabled = false;
                        lnkDelQualTrg.Enabled = false;
                    }
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgQualTrg_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnqualrul_Click(object sender, EventArgs e)
    {

    }

    protected void lnkQSetRule_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField lblRulCode = (HiddenField)grd.FindControl("hdnRulCode");
            HiddenField lblRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");
            HiddenField lblKPICode = (HiddenField)grd.FindControl("hdnKPICode");
            HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");

            if (hdnKpiOrg.Value == "1002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
                return;
            }
            else if (hdnKpiOrg.Value == "1003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
                return;
            }

            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", lblKPICode.Value.ToString());
            htparam.Add("@RULE_CODE", lblRulCode.Value.ToString());
            htparam.Add("@RULE_SET_KEY", lblRulStKy.Value.ToString());
            htparam.Add("@CATG_CODE", "");
            htparam.Add("@CODE", "");
            htparam.Add("@CYCLE_CODE", "");
            htparam.Add("@VER_EFF_FROM", "");
            htparam.Add("@VER_EFF_TO", "");
            htparam.Add("@CREATED_BY", "");

            ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTN", htparam, "SAIMConnectionString");
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
            string flag = string.Empty;
            if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
            {
                flag = "kpi";
            }
            else
            {
                flag = "rsKPI";
            }
            Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=" + flag.Trim() + "&mapcode=" + mapcode + "&CMPNSTN_CODE="
                + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "&KPI_CODE=" + lblKPICode.Value.Trim()
                + "&DRVDKPI=" + drvdkpi.ToString().Trim(), true);
            // 
            //htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            //htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkQSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkRwdSetRule_Click(object sender, EventArgs e)
    {

        try
        {
            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();
            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", "");
            htparam.Add("@RULE_CODE", "");
            htparam.Add("@RULE_SET_KEY", "");
            htparam.Add("@CATG_CODE", "");
            htparam.Add("@CODE", "");
            htparam.Add("@CYCLE_CODE", "");
            htparam.Add("@VER_EFF_FROM", "");
            htparam.Add("@VER_EFF_TO", "");
            htparam.Add("@CREATED_BY", "");
            ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTN", htparam, "SAIMConnectionString");
            string mapcode = "";
            if (ds.Tables.Count > 0)
            {
                mapcode = ds.Tables[0].Rows[0]["MapCode"].ToString();
            }
            // 
            //htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            //htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=inta&mapcode=" + mapcode + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "", true);

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkRwdSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {

         
        DataSet dsTemp = new DataSet();


        Hashtable htTemp = new Hashtable();
        dsTemp.Clear();
        htTemp.Clear();

        htTemp.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
        htTemp.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());

        htTemp.Add("@RULE_SET_KEY", Request.QueryString["RuleSetkey"].ToString().Trim());

        htTemp.Add("@CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
        htTemp.Add("@MEMBER_CYCLE", Request.QueryString["RuleCode"].ToString().Trim());
        htTemp.Add("@MEMBER_CODE", Request.QueryString["Memcode"].ToString().Trim());

        htTemp.Add("@flag", "1");

        dsTemp = objDal.GetDataSetForPrc_SAIM("Prc_InsTmp_TRGT", htTemp);
        if (dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
        {
            
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Data Copied Successfully ');", true);
                return;
        }


        BindRwdRevTrg();

    }


     

    protected void lnkValue_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpFrml();", true);
    }
    protected void dgReward_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblCode = (LinkButton)e.Row.FindControl("lblRulCode");
                LinkButton lnkEditRwd = (LinkButton)e.Row.FindControl("lnkEditRwd");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                LinkButton lnkKPISetRule = (LinkButton)e.Row.FindControl("lnkKPISetRule");




                Label lblRulSetKey = (Label)e.Row.FindControl("lblRulStKy");
                hdnRulSetKy.Value = lblRulSetKey.Text.ToString().Trim();
                ////lnkEditRwd.Attributes.Add("onclick", "funEditPopUp('divRwd','R','" + lblCode.Text + "','grid');return false;");
                HiddenField hdnKpiOrg = (HiddenField)e.Row.FindControl("hdnKpiOrg");
                if (hdnKpiOrg.Value == "1002")
                {
                    lblCode.Enabled = true;
                }
                else
                {
                    lblCode.Enabled = false;
                }
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEditRwd.Enabled = false;
                        lnkDelete.Enabled = false;
                        lnkKPISetRule.Enabled = false;
                    }
                }
                lnkEditRwd.Attributes.Add("onclick", "funEditPopUp('divRwd','R','" + lblCode.Text + "','grid');return false;");


                //lnkEditRwd.Attributes.Add("onclick", "funPopUp('divRwd','"++"','R');return false;");
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgReward_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkEditRwdTrg_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
            Label lblCatgCode = (Label)row.FindControl("lblCatgCode");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
                + "','R','" + lblCatgCode.Text.ToString().Trim() + "','gridTrg', '" + hdnCode.Value.ToString().Trim() + "');", true);

            //Response.Redirect("QualTrgStp.aspx?code=" + hdnCode.Value.ToString().Trim() + "&compcode=" + lblCompCodeVal.Text.ToString().Trim()
            //    + "&cntstcd=" + lblCntstCdVal.Text.ToString().Trim()
            //    + "&rultyp='R'");
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

    protected void lnkEditRwdRul_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnRwdCode = (HiddenField)row.FindControl("hdnRwdCode");
            Label lblRwdRulCode = (Label)row.FindControl("lblRwdRulCode");
            // HiddenField hdnCYCLE1 = (HiddenField)row.FindControl("hdnCYCLE1");
            mdlVwRwdRul.Show();
            if (Request.QueryString["Page"] != null)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpRwdRulEditNSTD('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + lblRwdRulCode.Text.ToString().Trim() + "','" + Request.QueryString["MEMBERCODE"].ToString() + "','" + Request.QueryString["Page"].ToString() + "');", true);//,'" + hdnCYCLE1.Value.ToString().Trim() + "'
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpRwdRulEdit('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + lblRwdRulCode.Text.ToString().Trim() + "');", true);//,'" + hdnCYCLE1.Value.ToString().Trim() + "'
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkEditRwdTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkEditRwdRulMdl_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnRwdCode = (HiddenField)row.FindControl("hdnRwdCode");
            Label lblRwdRulCode = (Label)row.FindControl("lblRwdRulCode");
            // HiddenField hdnCYCLE1 = (HiddenField)row.FindControl("hdnCYCLE1");
            mdlVwRwdRul.Show();
            if (Request.QueryString["Page"] != null)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpRwdRulEditNSTDMDL('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + lblRwdRulCode.Text.ToString().Trim() + "','" + Request.QueryString["MEMBERCODE"].ToString() + "','" + Request.QueryString["Page"].ToString() + "','MdlEdit');", true);//,'" + hdnCYCLE1.Value.ToString().Trim() + "'
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpRwdRulEditMdl('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim() + "','R','" + lblRwdRulCode.Text.ToString().Trim() + "','MdlEdit');", true);//,'" + hdnCYCLE1.Value.ToString().Trim() + "'
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkEditRwdRulMdl_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BindRevHistGrid(string strCompcode1)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", strCompcode1);
            htParam.Add("@UserId", HttpContext.Current.Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRevHistData", htParam);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvRevHist.DataSource = ds.Tables[0];
                    gvRevHist.DataBind();
                    ViewState["gridviewRevHistGrid"] = ds.Tables[0];

                    divRevHist.Visible = true;

                    if (gvRevHist.PageCount > 1)
                    {
                        btnnxtgvRevHist.Enabled = true;
                    }
                    else
                    {
                        btnnxtgvRevHist.Enabled = false;
                        btnprvgvRevHist.Enabled = false;
                    }
                }
                else
                {
                    divRevHist.Visible = false;
                }
            }
            else
            {
                divRevHist.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindRevHistGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void gvRevHist_Sorting(object sender, GridViewSortEventArgs e)
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

            DataTable dt = (DataTable)ViewState["gridviewRevHistGrid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtbtnprvgvRevHist.Text))
            {
                btnprvgvRevHist.Enabled = false;
                txtbtnprvgvRevHist.Text = "1";
                btnnxtgvRevHist.Enabled = true;
            }
            else
            {
                btnnxtgvRevHist.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "gvRevHist_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //New Added Function

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
                    ViewState["gridviewgdAudit"] = ds.Tables[0];
                    //  BindAuditGrid();



                    divAudit.Visible = true;
                    if (gdAudit.PageCount > 1)
                    {
                        Button2.Enabled = true;
                    }
                    else
                    {
                        Button2.Enabled = false;
                        Button1.Enabled = false;
                    }


                    if (Request.QueryString["Page"] != null)
                    {
                        if (Request.QueryString["Page"].ToString() == "A")
                        { divAudit.Visible = false; }
                    }
                }
                else
                {
                    divAudit.Visible = false;
                }
            }
            //else
            //{
            //    divAudit.Visible = false;
            //}
            else
            {

                gdAudit.DataSource = null;
                gdAudit.DataBind();
                TextBox1.Text = "1";
                Button1.Enabled = false;
                Button2.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindAuditGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
            BindAuditGrid(lblCompCodeVal.Text);
            DataTable dt = (DataTable)ViewState["gridviewgdAudit"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(TextBox1.Text))
            {
                Button1.Enabled = false;
                TextBox1.Text = "1";
                Button2.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "gdAudit_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void btnUpdRevGrd_Click(object sender, EventArgs e)
    {
        BindRevHistGrid(Request.QueryString["CmpCode"].ToString().Trim());
    }

    protected void dgQual_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblRulCode = (LinkButton)e.Row.FindControl("lblRulCode");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                LinkButton lnkQSetRule = (LinkButton)e.Row.FindControl("lnkQSetRule");
                Label lblRulStKy = (Label)e.Row.FindControl("lblRulStKy");
                hdnRulSetKyQ.Value = lblRulStKy.Text.ToString().Trim();
                HiddenField hdnKpiOrg = (HiddenField)e.Row.FindControl("hdnKpiOrg");
                if (hdnKpiOrg.Value == "1002")
                {
                    lblRulCode.Enabled = true;
                }
                else
                {
                    lblRulCode.Enabled = false;
                }
                if (Request.QueryString["RSetKey"] != null)
                {
                    if (Request.QueryString["RSetKey"].ToString() != null)
                    {
                        lnkEdit.Enabled = false;
                        lnkDelete.Enabled = false;
                        lnkQSetRule.Enabled = false;
                    }
                }
                lnkEdit.Attributes.Add("onclick", "funEditPopUp('divQual','Q','" + lblRulCode.Text.ToString().Trim() + "','grid');return false;");
                //lnkEditRwd.Attributes.Add("onclick", "funPopUp('divRwd','R');return false;");
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "dgQual_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void lnkEditRwdTrgRev_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnCode = (HiddenField)row.FindControl("hdnCodeREV");
            HiddenField hdnRulStKy = (HiddenField)row.FindControl("hdnRulStKy");

             Label lblCatgCode = (Label)row.FindControl("lblCatgCode");

            String FlagEnquiry="IncEnquiry";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
                  + "','R','" + lblCatgCode.Text.ToString().Trim() + "','QualTrg', '" + hdnCode.Value.ToString().Trim() + "','" + FlagEnquiry + "');", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
            //    + "','Q','" + lblCatgCode.Text.ToString().Trim() + "','QualTrg', '" + hdnCode.Value.ToString().Trim() + "','" + hdnRulStKy.Value.ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString() + "'," + FlagEnquiry + "');", true);



            //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
            //    + "','R','" + lblCatgCode.Text.ToString().Trim() + "','gridTrg', '" + hdnCode.Value.ToString().Trim() + "'," + hdnRulStKy.Value.ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString() + "','"
            //    + Request.QueryString["RuleCode"].ToString() + "','" + Request.QueryString["Cycle"].ToString() + "'," + FlagEnquiry + "');", true);



        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkEditRwdTrgRev_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkEditQualTrg_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField hdnCode = (HiddenField)row.FindControl("hdnCode");
            HiddenField hdnRulStKy = (HiddenField)row.FindControl("hdnRulStKy");

            Label lblCatgCode = (Label)row.FindControl("lblCatgCode");

            String FlagEnquiry="IncEnquiry";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpTrgEdit('','" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.ToString().Trim()
                + "','Q','" + lblCatgCode.Text.ToString().Trim() + "','QualTrg', '" + hdnCode.Value.ToString().Trim() + "','" + hdnRulStKy.Value.ToString().Trim() + "','" + Request.QueryString["Memcode"].ToString() + "'," + FlagEnquiry + "');", true);

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkEditQualTrg_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void lnkQtrgSetRule_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable htparam = new Hashtable();

            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

            HiddenField hdnRulStKy = (HiddenField)grd.FindControl("hdnRulStKy");

            HiddenField HiddenRulecode = (HiddenField)grd.FindControl("HiddenRulecode");
            HiddenField HiddenCycleCode = (HiddenField)grd.FindControl("HiddenCycleCode");
            HiddenField HiddenKpiCode = (HiddenField)grd.FindControl("HiddenKpiCode");

            HiddenField hdnCatgCode = (HiddenField)grd.FindControl("hdnCatgCode");
            HiddenField hdnCode = (HiddenField)grd.FindControl("hdnCode");
            HiddenField hdnKpiOrg = (HiddenField)grd.FindControl("hdnKpiOrg");
            HiddenField hdnCatg = (HiddenField)grd.FindControl("hdnCatg");

            if (hdnKpiOrg.Value == "1002")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Derived KPI')", true);
                return;
            }
            else if (hdnKpiOrg.Value == "1003")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('Setting Standard Definition Rule is not allowed for Hybrid KPI')", true);
                return;
            }

            htparam.Add("@ROOT_BUSI_CODE", "");
            htparam.Add("@BUSI_CODE", "");
            htparam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString());
            htparam.Add("@CNTST_CODE", lblCntstCdVal.Text.ToString());
            htparam.Add("@KPI_CODE", HiddenKpiCode.Value.ToString());
            htparam.Add("@RULE_CODE", HiddenRulecode.Value.ToString());
            htparam.Add("@RULE_SET_KEY", hdnRulStKy.Value.ToString());

            htparam.Add("@CATG_CODE", hdnCatgCode.Value.Trim());
            htparam.Add("@CODE", hdnCode.Value.Trim());

            htparam.Add("@CYCLE_CODE", HiddenCycleCode.Value.ToString());


            htparam.Add("@VER_EFF_FROM", "");

            htparam.Add("@VER_EFF_TO", "");

            htparam.Add("@CREATED_BY", "");
            htparam.Add("@KpiFlag", "1");


            ds = objDal.GetDataSetForPrcDBConn("Prc_InsertMST_STDDEFNTN_target", htparam, "SAIMConnectionString");

            string mapcode = "";
            if (ds.Tables.Count > 0)
            {
                mapcode = ds.Tables[0].Rows[0]["MapCode"].ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert(" + mapcode + ")", true);

            string drvdkpi = string.Empty;
            if (Request.QueryString["DRVDKPI"] != null)
            {
                if (Request.QueryString["DRVDKPI"].ToString().Trim() != "")
                {
                    drvdkpi = Request.QueryString["DRVDKPI"].ToString().Trim();
                }
            }

            string flag = string.Empty;
            if (hdnKpiOrg.Value == "1001" && hdnCatg.Value == "1006")
            {
                flag = "kpi";
            }
            else
            {
                flag = "rsKPITrg";
            }

            Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?CmpTyp=" + Request.QueryString["CmpTyp"].ToString() + "&flag=" + flag.Trim() + "&mapcode=" + mapcode
                + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "&KPI_CODE=" + HiddenKpiCode.Value.ToString().Trim()
                + "&DRVDKPI=" + drvdkpi.ToString().Trim(), true);
            /////Response.Redirect("~\\Application\\ISys\\Saim\\RuleSetPages\\FFContestPageStdDef.aspx?&flag=inta&mapcode=" + mapcode + "&CMPNSTN_CODE=" + lblCompCodeVal.Text + "&CNTST_CODE=" + lblCntstCdVal.Text + "", true);

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lnkQtrgSetRule_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnSaveFn_Click(object sender, EventArgs e)
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdACTV_STATUS", htParam);
            mdlpopup.Show();
            lbl3.Text = "Contestant Details saved successfully";
            lbl4.Text = "Compensation Code:" + lblCompCodeVal.Text.ToString().Trim();
            lbl5.Text = "Compensation Description:" + lblCompDesc1Val.Text.ToString().Trim();

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnSaveFn_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnCnclFn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CmpSetup.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        EnableRevisedControl();

    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {

       // btnLoad.Visible = true;
       lblStatus.Attributes.Add("display", "block");

        imgStatus.Visible = true;
        imgStatus.ImageUrl = "../../../images/spinner.gif";
        Hashtable htRunKpi = new Hashtable();
        DataSet dsRunKpi = new DataSet();


        Hashtable htKPITotal = new Hashtable();
        DataSet dsKPITotal = new DataSet();

        htKPITotal.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString().Trim());
        htKPITotal.Add("@Cycle", Request.QueryString["Cycle"].ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("PrcGetAllKPI", htKPITotal);


        //Cycle


        string strACCR_CYCLE = string.Empty;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {


            htRunKpi.Clear();

            htRunKpi.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString().Trim());
             htRunKpi.Add("@KPI_CODE", ds.Tables[0].Rows[i]["KPI_CODE"].ToString());
            htRunKpi.Add("@ACC_CYCLE_CODE", Request.QueryString["Cycle"].ToString().Trim());
            htRunKpi.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString().Trim());
            dsRunKpi = objDal.GetDataSetForPrc_SAIM("PrcInsertOrginalNBPValue", htRunKpi);


   


            htRunKpi.Clear();
            htRunKpi.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htRunKpi.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
            htRunKpi.Add("@ACCR_CYCLE", ds.Tables[0].Rows[i]["ACCR_CYCLE"].ToString());
            htRunKpi.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString().Trim());
            htRunKpi.Add("@KPI_CODE", ds.Tables[0].Rows[i]["KPI_CODE"].ToString());
            htRunKpi.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            dsRunKpi = objDal.GetDataSetForPrc_SAIM("Prc_Process_ALL_KPI", htRunKpi);


           

            

            strACCR_CYCLE = ds.Tables[0].Rows[i]["ACCR_CYCLE"].ToString();
        }



        Hashtable htCom = new Hashtable();
        DataSet dsCom = new DataSet();
        htCom.Clear();
        dsCom.Clear();



        htCom.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());

        htCom.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htCom.Add("@RULE_SET_KEY ", Request.QueryString["RuleSetKey"].ToString().Trim());
        htCom.Add("@ACCR_CYCLE ", strACCR_CYCLE);
        htCom.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
        dsCom = objDal.GetDataSetForPrc_SAIM("PRC_PROCESS_CATEGORY", htCom);


        
        htCom.Clear();
        dsCom.Clear();

        htCom.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());

        htCom.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htCom.Add("@RULE_SET_KEY ", Request.QueryString["RuleSetKey"].ToString().Trim());
        htCom.Add("@ACCR_CYCLE ", strACCR_CYCLE);
        htCom.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());


        dsCom = objDal.GetDataSetForPrc_SAIM("Prc_InscmpTRGRWD", htCom);
      // btnLoad.Style.Add("display", "none");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Reward Computed Successfully')", true);


        Response.Redirect("CntstStp_INC.aspx?CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&RuleCode=" + Request.QueryString["RuleCode"].ToString().Trim()
                     + "&Flag=" + Request.QueryString["Flag"].ToString().Trim() + "&Memcode=" + Request.QueryString["Memcode"].ToString().Trim() + "&CntstCode="
        + Request.QueryString["CntstCode"].ToString().Trim() + "&RuleSetKey=" + Request.QueryString["RuleSetKey"].ToString().Trim() + "&CategoryCode=" + Request.QueryString["CategoryCode"].ToString().Trim() + "&Cycle=" + Request.QueryString["Cycle"].ToString().Trim(), true);
            

    }
    protected void btnprvgvRevHist_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvRevHist.PageIndex;
            gvRevHist.PageIndex = pageIndex - 1;
            BindRevHistGrid(lblCompCodeVal.Text.ToString());
            txtbtnprvgvRevHist.Text = Convert.ToString(Convert.ToInt32(txtbtnprvgvRevHist.Text) - 1);
            if (txtbtnprvgvRevHist.Text == "1")
            {
                btnprevrwd.Enabled = false;
            }
            else
            {
                btnnxtgvRevHist.Enabled = true;
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnprvgvRevHist_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnxtgvRevHist_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvRevHist.PageIndex;
            gvRevHist.PageIndex = pageIndex + 1;
            BindRevHistGrid(lblCompCodeVal.Text.ToString());
            txtbtnprvgvRevHist.Text = Convert.ToString(Convert.ToInt32(txtbtnprvgvRevHist.Text) + 1);
            btnprvgvRevHist.Enabled = true;
            int page = gvRevHist.PageCount;
            if (txtbtnprvgvRevHist.Text == Convert.ToString(gvRevHist.PageCount))
            {
                btnnxtgvRevHist.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnnxtgvRevHist_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gdAudit.PageIndex;
            gdAudit.PageIndex = pageIndex - 1;
            BindAuditGrid(lblCompCodeVal.Text.ToString());
            //BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            TextBox1.Text = Convert.ToString(Convert.ToInt32(TextBox1.Text) - 1);
            if (TextBox1.Text == "1")
            {
                Button1.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
            }
            Button2.Enabled = true;
        }

        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "Button1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //Added by bhaurao
    protected void Button2_Click(object sender, EventArgs e)
    {

        button2_next();

    }

    private void button2_next()
    {
        try
        {
            int pageIndex = gdAudit.PageIndex;
            gdAudit.PageIndex = pageIndex + 1;
            BindAuditGrid(lblCompCodeVal.Text.ToString());
            TextBox1.Text = Convert.ToString(Convert.ToInt32(TextBox1.Text) + 1);
            Button1.Enabled = true;
            int page = gdAudit.PageCount;
            if (TextBox1.Text == Convert.ToString(gdAudit.PageCount))
            {
                Button2.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "button2_next", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnBlkQualDwnld_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htExcel = new Hashtable();
            DataSet dsExcel = new DataSet();
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            dsExcel.Clear();
            htExcel.Clear();
            string filename = lblCompDesc1Val.Text + "_Targets.xls";
            htExcel.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
            htExcel.Add("@CNTSTN_CODE", lblCntstCdVal.Text.ToString().Trim());
            htExcel.Add("@RULE_TYPE", "Q");
            dsExcel = objDal.GetDataSetForPrc_SAIM("Prc_GetTrgDtlsDwnld", htExcel);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dsExcel.Tables[0];
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            string renderedGridView = tw.ToString();

            if (dsExcel.Tables[0].Rows.Count > 0)
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
                ////HttpContext.Current.ApplicationInstance.CompleteRequest();
                dsExcel = null;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "btnBlkQualDwnld_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lblRulCode_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lblRulCode = (LinkButton)row.FindControl("lblRulCode");
            Label lblKPICode = (Label)row.FindControl("lblKPICode");
            string dpd_rskey = string.Empty;
            string dpd_cntstcd = string.Empty;
            ds = new DataSet();
            ds.Clear();
            htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "Q");
            htParam.Add("@RuleCode", lblRulCode.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dpd_rskey = ds.Tables[0].Rows[0]["SUBRSK"].ToString().Trim();
                dpd_cntstcd = ds.Tables[0].Rows[0]["SUBCNTST"].ToString().Trim();
                Response.Redirect("CntstStp.aspx?CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + dpd_cntstcd.ToString().Trim() + "&RSetKey=" + dpd_rskey.ToString().Trim()
                    + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                    + "&DRVDKPI=" + lblKPICode.Text.ToString().Trim(), true);
            }
        }
        catch (Exception ex)
        { 
        //{
        //    string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
        //    string sRet = oInfo.Name;
        //    System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
        //    String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lblRulCode_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void lblRulCdRwd_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lblRulCode = (LinkButton)row.FindControl("lblRulCode");
            Label lblKPICode = (Label)row.FindControl("lblKPICode");
            string dpd_rskey = string.Empty;
            string dpd_cntstcd = string.Empty;
            ds = new DataSet();
            ds.Clear();
            htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CmpCode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@CntstCode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "R");
            htParam.Add("@RuleCode", lblRulCode.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dpd_rskey = ds.Tables[0].Rows[0]["SUBRSK"].ToString().Trim();
                dpd_cntstcd = ds.Tables[0].Rows[0]["SUBCNTST"].ToString().Trim();
                Response.Redirect("CntstStp.aspx?CmpCode=" + lblCompCodeVal.Text.ToString().Trim() + "&CntstCode=" + dpd_cntstcd.ToString().Trim() + "&RSetKey=" + dpd_rskey.ToString().Trim()
                    + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim()
                    + "&DRVDKPI=" + lblKPICode.Text.ToString().Trim(), true);
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "lblRulCdRwd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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
                    if (ds.Tables[0].Rows[i]["CTRL_TYPE"].ToString() == "LinkButton")
                    {
                        CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();
                        // LinkButton lnkbtn = UpdatePanel11.FindControl(CTRL_ID) as LinkButton;
                        LinkButton lnkbtn = Panel3.FindControl(CTRL_ID) as LinkButton;
                        lnkbtn.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());
                    }
                    //                if (ds.Tables[0].Rows[i]["CTRL_TYPE"].ToString() == "button")
                    //                {
                    //                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();
                    //                    Button btn = FindControl(CTRL_ID) as Button;
                    //                    btn.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());
                    //                }
                    //                if (ds.Tables[0].Rows[i]["CTRL_TYPE"].ToString() == "checkbox")
                    //                {
                    //                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();

                    //                    CheckBox chk = FindControl(CTRL_ID) as CheckBox;
                    //                    chk.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());
                    //                }
                    //                if (ds.Tables[0].Rows[i]["CTRL_TYPE"].ToString() == "div")
                    //                {
                    //                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();

                    //                    System.Web.UI.HtmlControls.HtmlGenericControl NewDiv = FindControl(CTRL_ID) as
                    //System.Web.UI.HtmlControls.HtmlGenericControl;

                    //                 HtmlGenericControl Dv = FindControl(CTRL_ID) as HtmlGenericControl;
                    //                    Dv.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());

                    //                }
                    //                if (ds.Tables[0].Rows[i]["CTRL_TYPE"].ToString() == "table")
                    //                {
                    //                    CTRL_ID = ds.Tables[0].Rows[i]["CTRL_ID"].ToString();
                    //                    HtmlGenericControl table = FindControl(CTRL_ID) as HtmlGenericControl;
                    //                    table.Visible = Convert.ToBoolean(ds.Tables[0].Rows[i]["IS_VISIBLE"].ToString());

                    //                }

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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "GetEnblDsblCtrlsts", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void GridMdlEditRwrd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                if (Session["RwdRul"] != null)
                {
                    ////dt = Session["RwdRul"] as DataTable;
                    dt = ViewState["dgRwdRul"] as DataTable;
                    Label lblBsdKpi = (Label)e.Row.FindControl("lblBsdKpi");
                    Label lblBrkRul = (Label)e.Row.FindControl("lblBrkRul");
                    GridView dgCntst = (GridView)e.Row.FindControl("dgCntst");

                    BindGrid(lblBrkRul.Text.ToString(), dgCntst);

                    Label lblRATE = (Label)e.Row.FindControl("lblRATE");
                    HiddenField hdnType = (HiddenField)e.Row.FindControl("hdnKPICode");//////UnitType
                    Label lblValue = (Label)e.Row.FindControl("lblValue");
                    LinkButton lnkValue = (LinkButton)e.Row.FindControl("lnkValue");
                    //added by arjun for the uat bug fixing
                    LinkButton lnkEditRwdRul = (LinkButton)e.Row.FindControl("lnkEditRwdRul");
                    LinkButton lnkDelRwdRul = (LinkButton)e.Row.FindControl("lnkDelRwdRul");



                    Label lblMEMBERCODE = (Label)e.Row.FindControl("lblMEMBERCODE");
                    //END

                    if (dt.Rows.Count > 0)
                    //added by arjun for the uat bug fixing
                    {
                        if (lblMEMBERCODE.Text != "" && Request.QueryString["Page"] == null)
                        {

                            lnkEditRwdRul.Visible = false;
                            lnkDelRwdRul.Visible = false;
                        }
                        //END


                        if (lblBsdKpi.Text != null)
                        {
                            if (lblBsdKpi.Text == "")
                            {
                                e.Row.Cells[7].Text = "NA";
                                e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                            }
                            if (lblBsdKpi.Text == "--SELECT--")
                            {
                                e.Row.Cells[7].Text = "NA";
                                e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (lblBrkRul.Text != null)
                        {
                            if (lblBrkRul.Text == "")
                            {
                                e.Row.Cells[10].Text = "NA";
                                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (lblRATE.Text != null)
                        {
                            if (lblRATE.Text == "")
                            {
                                e.Row.Cells[11].Text = "NA";
                                e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (hdnType.Value == "F")
                        {
                            lnkValue.Visible = true;
                            lblValue.Visible = false;
                        }
                        else
                        {
                            lnkValue.Visible = false;
                            lblValue.Visible = true;
                        }
                    }
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "GridMdlEditRwrd_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void chkQual_CheckedChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (sUserId == "cmpreview" || sUserId == "cmpchecker")
    //        {
    //            if (ddlStatusR.SelectedItem.Text == "REVISION REQUIRED" || ddlStatusR.SelectedValue == "APPROVED")
    //            {     // btnok.Enabled = true;

    //                chkQual.Enabled = true;

    //                if (chkQual.Enabled == true)
    //                    btnok.Enabled = true;
    //                else
    //                    btnok.Enabled = false;

    //                ddlStatusR.Enabled = true;
    //                txtRemark.Enabled = true;
    //            }
    //        }


    //        if (chkQual.Enabled == true)
    //        {
    //            if (chkQual.Checked == true)
    //            {
    //                ddlStatusR.Enabled = true;
    //                txtRemark.Enabled = true;
    //                btOK.Enabled = true;
    //            }
    //            else
    //            {
    //                ddlStatusR.Enabled = false;
    //                ddlStatusR.SelectedIndex = 0;
    //                txtRemark.Enabled = false;
    //                txtRemark.Text = "";
    //                btnok.Enabled = false;

    //            }
    //        }
    //        else
    //        {
    //            ddlStatusR.Enabled = false;
    //            txtRemark.Enabled = false;
    //        }

            
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    //protected void ddlStatusR_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //    //    if ((ddlStatus.SelectedValue == "UNDER REVIEW") && (ddlStatus.SelectedValue == "REVISED -UNDER REVIEW"))
    //    //    {
    //    //        if (sUserId == "cmpreview")
    //    //        {
    //    //            if (ddlStatusR.SelectedValue == "REVISION REQUIRED" || ddlStatusR.SelectedValue == "APPROVED") { btnok.Enabled = true; }
    //    //            chkQual.Enabled = true;
    //    //            btOK.Enabled = true;
    //    //        }
    //    //    }

          

    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}

    //protected void btOK_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //REMARK ENTRY
    //        ds.Clear();
    //        htParam.Clear();
    //        htParam.Add("@CompRemark", txtRemark.Text.ToString().Trim());
    //        htParam.Add("@CompStat", ddlStatusR.SelectedValue.ToString().Trim());
    //        htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
    //        ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCompRemark", htParam);


    //        //AUDIT ENTRY
    //        ds.Clear();
    //        htParam.Clear();
    //        htParam.Add("@ActionFlag", "CH");
    //        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
    //        htParam.Add("@UserId", Session["UserID"].ToString().Trim());
    //        htParam.Add("@Remark", txtRemark.Text.ToString().Trim());
    //        htParam.Add("@Status", ddlStatusR.SelectedValue.ToString().Trim());
    //        htParam.Add("@Version", txtVer.Text.ToString().Trim());
    //        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsertCMPNSTN_AuditTrail", htParam);

    //        /////Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);
    //        Response.Redirect("CmpSetup.aspx?flag=E&Mode=" + Request.QueryString["Mode"].ToString().Trim() + "&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''&Cmptyp=" + Request.QueryString["CmpTyp"].ToString().Trim(), true);
    //        txtRemark.Text = "";

    //        //ds.Clear();
    //        //htParam.Clear();
    //        //htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
    //        //htParam.Add("@CompStat", ddlStatus.SelectedValue.ToString().Trim());
    //        //ds = objDal.GetDataSetForPrc_SAIM("Prc_UpdCmpStatus", htParam);
    //        //Response.Redirect("CmpSetup.aspx?flag=E&CmpCode=" + Request.QueryString["CmpCode"].ToString().Trim() + "&CntstCode=''", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //        System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //        string sRet = oInfo.Name;
    //        System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //        String LogClassName = method.ReflectedType.Name;
    //        objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //    }
    //}


    protected void GridMdlEditRwrd_Sorting(object sender, GridViewSortEventArgs e)
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
            BindRwdRul("N");
            DataTable dt = (DataTable)ViewState["dgRwdRul"];

            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = dgSource.Attributes["SortExpression"];

                if (dgSource.Attributes["SortASC"] == "No")
                {
                    dv.Sort += " DESC";
                }

                //dgSource.PageIndex = 0;
                dgSource.DataSource = dv;
                dgSource.DataBind();
                if (dgSource.PageCount >= Convert.ToInt32(txtPageRwdRul.Text))
                {
                    btnprevrwdrul.Enabled = false;
                    txtPageRwdRul.Text = "1";
                    btnnextrwdrul.Enabled = true;
                }
                else
                {
                    btnnextrwdrul.Enabled = false;
                }
            }
            else
            {
                DataSet ds = null;
                ShowNoRecRwdRul(ds.Tables[0], dgRwdRul);
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
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "GridMdlEditRwrd_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void BindEditRwdRul(string flag)
    {
        try
        {

            DataSet dsReward = new DataSet();

            dsReward = GetEditRewardDtls(flag);
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                hdnRwrdCnt.Value = dsReward.Tables[1].Rows[GridMdlEditRwrd.PageIndex]["CATG_CNT"].ToString().Trim();
                // dgRwdRul.PageSize = Convert.ToInt32(hdnRwrdCnt.Value.ToString().Trim());
            }
            if (dsReward.Tables.Count > 0 && dsReward.Tables[0].Rows.Count > 0)
            {
                ViewState["dgRwdRul"] = dsReward.Tables[0];
                GridMdlEditRwrd.DataSource = dsReward;
                GridMdlEditRwrd.DataBind();
                /////ViewState["dgRwdRul"]= ds.Tables[0];

                btnSaveFn.Enabled = true;
                if (GridMdlEditRwrd.PageCount > Convert.ToInt32(TexeditRwd.Text.Trim()))
                {
                    btnnextrwdrulEdit.Enabled = true;
                }
                else
                {
                    btnnextrwdrulEdit.Enabled = false;
                }

            }
            else
            {
                GridMdlEditRwrd.AllowSorting = false;
                ShowNoRecRwdRul(dsReward.Tables[0], GridMdlEditRwrd);
                btnSaveFn.Enabled = false;
            }
            Session["RwdRul"] = dsReward.Tables[0];
            ////Session["RwdRul1"] = ds.Tables[1];
            Session["TblRwrdRowCount"] = 0;
            ViewState["TblRwrdRowCount"] = 0;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "BindEditRwdRul", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    private DataSet GetEditRewardDtls(string flag)
    {
        ds = new DataSet();
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.ToString().Trim());
        htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.ToString().Trim());
        htParam.Add("@RULE_TYPE", "R");
        if (Request.QueryString["Page"] != null)
        {
            htParam.Add("@Page", Request.QueryString["Page"].ToString().Trim());
            htParam.Add("@MEMBERCODE", Request.QueryString["MEMBERCODE"].ToString());
        }


        if (Request.QueryString["Page"] != null && flag == "Edit")
        {
            htParam.Add("@ACC_CYCLE", ddlCycle.SelectedValue.ToString().Trim());
            htParam.Add("@RULE_SET_CODE", ddlRulesetkey.SelectedValue.ToString().Trim());

            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }

        else if (Request.QueryString["Page"] != null && flag == "P")
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls_temp_Ver1", htParam);
        }
        else if (flag == "Edit")
        {
            htParam.Add("@ACC_CYCLE", ddlCycle.SelectedValue.ToString().Trim());
            htParam.Add("@RULE_SET_CODE", ddlRulesetkey.SelectedValue.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
        }
        else
        {
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRwdRulDtls", htParam);
        }

        return ds;
    }

    protected void ddlRulesetkey_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDropDowns(ddlCycle, "C", "Prc_GetEditAccCycleData");
    }
    protected void btnSearch_click(object sender, EventArgs e)
    {
        GridMdlEditRwrd.DataSource = null;
        GridMdlEditRwrd.DataBind();
        BindEditRwdRul("Edit");
    }
    protected void btnEditCancel_click(object sender, EventArgs e)
    {
        myModal.Style.Add("display", "none");
    }

    protected void LnkEditRwrd_Click(object sender, EventArgs e)
    {
        try
        {

            myModal.Style.Add("display", "block");
            ddlRulesetkey.Items.Clear();
            ddlCycle.Items.Clear();
            ddlCycle.Items.Insert(0, new ListItem("-- SELECT --", ""));
            GridMdlEditRwrd.DataSource = null;
            GridMdlEditRwrd.DataBind();
            FillDropDowns(ddlRulesetkey, "1", "Prc_GetRWDRuleMstDtls");


        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "GetEditRewardDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillDropDowns(DropDownList ddl, string Flag, string ProcName)
    {
        try
        {
            ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataBind();
            htParam.Clear();
            htParam.Add("@flag", Flag.ToString().Trim());
            htParam.Add("@cntstcode", lblCntstCdVal.Text.ToString().Trim());
            htParam.Add("@cmpcode", lblCompCodeVal.Text.ToString().Trim());
            htParam.Add("@RuleType", "R");
            if (ddlRulesetkey.SelectedIndex > 0)
            {
                htParam.Add("@rulesetcd", ddlRulesetkey.SelectedValue.ToString());
            }

            ds = objDal.GetDataSetForPrc_SAIM(ProcName, htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = ds.Tables[0].Columns[4].ToString().Trim();
                ddl.DataValueField = ds.Tables[0].Columns[3].ToString().Trim();
                ddl.DataBind();
            }

            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "CntstStp_INC", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    //Ended BY  PRITY on 4 SEPT 2018

    //Added By Amit Marathe On 13 OCT 2018
    protected void FillDropDoun(DropDownList ddl, string CMPNSTN_CODE, string CNTSTNT_CODE)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@CMPNSTN_CODE", CMPNSTN_CODE.ToString());
        ht.Add("@CNTSTNT_CODE", CNTSTNT_CODE.ToString());
        //ht.Add("@flag", flag.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetRuleSetKey", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "RuleSetDesc";
            ddl.DataValueField = "RuleSetCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();

    }
    protected void FillCycleCode(DropDownList ddl, string ruleSetKey)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@cmpcode", Request.QueryString["CmpCode"].ToString().Trim());
        ht.Add("@cntstcode", Request.QueryString["CntstCode"].ToString().Trim());
        ht.Add("@rulesetcd", ruleSetKey.ToString());

        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetEditAccCycleData_test", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "BUSI_DESC";
            ddl.DataValueField = "ACC_CYCLE";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        drRead.Close();
    }

    protected void FillCatgCode(DropDownList ddl, string ruleSetKey)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@CmstnCode", Request.QueryString["CmpCode"].ToString().Trim());
        ht.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        ht.Add("@RulSetCode", ruleSetKey.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetRwdCatgCode", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "CategoryDesc";
            ddl.DataValueField = "CategoryCode";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        drRead.Close();
    }

    protected void ddlRuleSet_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillCycleCode(ddlCycleCode, ddlRuleSet.SelectedValue.ToString());
        FillCatgCode(ddlCatgCode, ddlRuleSet.SelectedValue.ToString());

    }

    protected void btnSearch_KPIT_Click(object sender, EventArgs e)
    {
        BindRwdTrg();
    }
    protected void btnClear_KPIT_Click(object sender, EventArgs e)
    {

        ddlRuleSet.SelectedValue = "";
        ddlCycleCode.SelectedValue = "";
        ddlCatgCode.SelectedValue = "";
        BindRwdTrg();
    }
    //Ended By Amit Marathe On 13 OCT 2018

    //Added By Amit Marathe On 15 OCT 2018
    protected void ddlRSetK_Rwd_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCycleCode(ddlCyCod_Rwd, ddlRSetK_Rwd.SelectedValue.ToString());
        FillCatgCode(ddlCatgCod_Rwd, ddlRSetK_Rwd.SelectedValue.ToString());
    }
    protected void btnClear_Rwd_Click(object sender, EventArgs e)
    {

        ddlRSetK_Rwd.SelectedValue = "";
        ddlCyCod_Rwd.SelectedValue = "";
        ddlCatgCod_Rwd.SelectedValue = "";
        BindRwdRul("P");

    }

    protected void btnSearch_Rwd_Click(object sender, EventArgs e)
    {
        BindRwdRul("P");
    }

    //Ended By Amit Marathe On 13 OCT 2018
}

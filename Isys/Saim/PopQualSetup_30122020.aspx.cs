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
public partial class Application_ISys_Saim_PopQualSetup : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp, chnl, schnl = string.Empty;
    string value = String.Empty;
    string strACC_YEAR = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            if (!IsPostBack)
            {
                InitializeControl();
                if (Request.QueryString["cmpnstcd"] != null)
                {
                    if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
                    {
                        cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
                    }
                }
                if (Request.QueryString["cntstcd"] != null)
                {
                    if (Request.QueryString["cntstcd"].ToString().Trim() != null)
                    {
                        cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
                    }
                }
                if (Request.QueryString["chnl"] != null)
                {
                    if (Request.QueryString["chnl"].ToString().Trim() != null)
                    {
                        chnl = Request.QueryString["chnl"].ToString().Trim();
                    }
                }
                if (Request.QueryString["schnl"] != null)
                {
                    if (Request.QueryString["schnl"].ToString().Trim() != null)
                    {
                        schnl = Request.QueryString["schnl"].ToString().Trim();
                    }
                }

                if (Request.QueryString["rultyp"] != null)
                {
                    value = Request.QueryString["rultyp"].ToString().Trim();
                }
                ddlKPICode.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlUnitType.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ////FillCmp
                
                
                ddlParntCntstCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlParntRulSetKy.Items.Insert(0, new ListItem("-- SELECT --", ""));
                
                
                FillddlKPI(ddlKPICode, "Prc_KPISearch", "KPI_DESC_01", "KPI_CODE", "3", FillCmp().Trim(), chnl.ToString().Trim(), schnl.ToString().Trim());
                FillddlKPI(ddlUnitType, "Prc_FillMstVals", "DESC01", "CODE", "1", "", "", "");

                FillDropDowns(ddlAccMode, "13", "","","");

              //  FillDropDowns(ddlCmptnRule, "47", "", "P",);


                FillDropDown(ddlRuleClass, "41");

                ddlAccMode.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlSlsChnl.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlSubCls.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlContestant.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlSubCnt.Items.Insert(0, new ListItem("-- SELECT --", ""));
                
                ddlCmptnRule.Items.Insert(0, new ListItem("-- SELECT --", ""));
                FillParentCmpnstnCode(ddlParntCmpCode, "Prc_FillParentCmpnstnCode");
             //   FillParentCnstntCode(ddlParntCntstCode, "Prc_FillParentCnstntCode");

                FillCntst(cntstcd.ToString().Trim(), ddlSlsChnl, cmpnstcd.ToString().Trim(), "", "CHN", "BizSrc");
                if (Request.QueryString["rulsetky"] != null && Request.QueryString["rulsetky"] != "")
                {
                    txtRuleSetKey.Text = Request.QueryString["rulsetky"].ToString().Trim();
                }
                else
                {
                    txtRuleSetKey.Text = GetMaxCode("4");
                }
                GetRuleSetKeyDtls(ddlRSKDesc);
                //ddlRSKDesc_SelectedIndexChanged();
                txtRuleSetKey.Text = "";
                CreateRuleSetKey();
              //  CheckIsComplexLinked();
                if (Request.QueryString["code"] != null)
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    FillddlKPI(ddlKPICode, "Prc_KPISearch", "KPI_DESC_01", "KPI_CODE", "4", "", "", "");
                    GetPageDtls();
                }
                else
                {
                    txtVrEffFrm.Text = Request.QueryString["frmdt"].ToString().Trim();
                    txtVrEffTo.Text = Request.QueryString["todt"].ToString().Trim();
                }
                Session["sbCnt"] = null;
            }
            btnSave.Attributes.Add("onclick", "javascript:return validate();");
            btnUpdate.Attributes.Add("onclick", "javascript:return validate();");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void GetRuleSetKeyDtls(DropDownList ddl)
    {
        try
        {
            Hashtable htRsk = new Hashtable();
            DataSet dsRsk = new DataSet();
            htRsk.Clear();
            dsRsk.Clear();
            htRsk.Add("@cmpcode", cmpnstcd.Trim());
            htRsk.Add("@cntstcode", cntstcd.Trim());
            htRsk.Add("@flag", "1");
            htRsk.Add("@RuleType", value);
            dsRsk = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleMstDtls", htRsk);
            if (dsRsk.Tables.Count > 0 && dsRsk.Tables[0].Rows.Count > 0)
            {
                ddl.Items.Clear();

                ddl.DataSource = dsRsk;
                ddl.DataTextField = dsRsk.Tables[0].Columns[4].ToString().Trim();
                ddl.DataValueField = dsRsk.Tables[0].Columns[3].ToString().Trim();
                ddl.DataBind();
                ////ddlRSKDesc
                ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
                ddl.Visible = true;
                txtRSKDesc.Visible = false;
            }
            else
            {
                ddl.Visible = false;
                txtRSKDesc.Visible = true;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "GetRuleSetKeyDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void GetPageDtls()
    {
       
        try
        {
            ds = new DataSet();
            ds.Clear();
            htParam = new Hashtable();
            htParam.Clear();
            if (Request.QueryString["cmpnstcd"] != null)
            {
                htParam.Add("@CmpCode", Request.QueryString["cmpnstcd"].ToString().Trim());
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                htParam.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
            }
            if (Request.QueryString["rultyp"] != null)
            {
                htParam.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
            }
            if (Request.QueryString["code"] != null)
            {
                htParam.Add("@RulStKey", Request.QueryString["code"].ToString().Trim());
            }

            if (Request.QueryString["kpicode"] != null)
            {
                htParam.Add("@KPICode", Request.QueryString["kpiCode"].ToString().Trim());
            }
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI_Edit", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                
                ddlRSKDesc.Visible = true;
                ddlRSKDesc.SelectedValue = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                txtRuleSetKey.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
                ddlKPICode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString().Trim();
                ddlAccMode.SelectedValue = ds.Tables[0].Rows[0]["ACC_MODE"].ToString().Trim();
                txtVrEffFrm.Text = ds.Tables[0].Rows[0]["VER_FRM"].ToString().Trim();
                txtVrEffTo.Text = ds.Tables[0].Rows[0]["VER_TO"].ToString().Trim();
                rblCRYFWD.SelectedValue = ds.Tables[0].Rows[0]["CRY_FWD"].ToString().Trim();
                ddlRwdCmpRul.SelectedValue = ds.Tables[0].Rows[0]["RWDCMPRULE"].ToString().Trim();
                ddlUnitType.SelectedValue = ds.Tables[0].Rows[0]["UNIT_TYPE"].ToString().Trim();
                txtMaxLmt.Text = ds.Tables[0].Rows[0]["MAX_LIMIT"].ToString().Trim();
                string chkdefn = ds.Tables[0].Rows[0]["IS_STDDFN"].ToString().Trim();
                ddlComptype.SelectedValue=ds.Tables[0].Rows[0]["CMPTTN_FLAG"].ToString();
                ddlIsCumulative.SelectedValue = ds.Tables[0].Rows[0]["IS_CUMULATIVE"].ToString();
			
		        FillDropDowns(ddlCmptnRule, "45", "", "P",ddlKPICode.SelectedValue);
                ddlCmptnRule.SelectedValue= ds.Tables[0].Rows[0]["SET_CMPTN_RULE"].ToString();

            
                //KPI_TRG_RUL_CLASS 
                ddlRuleClass.SelectedValue = ds.Tables[0].Rows[0]["KPI_TRG_RUL_CLASS"].ToString();
                ddlDfnTrg.SelectedValue = ds.Tables[0].Rows[0]["PER_TRG_FLAG"].ToString();
                if (ddlDfnTrg.SelectedValue.ToString().Trim() == "Y")
                {

                    btnTrg.Visible = true;
                }
                else
                {
                    btnTrg.Visible = false;

                }
                FillParentKPI(ddlKPI_Code, ddlRSKDesc.SelectedValue);
                ddlKPI_Code.SelectedValue = ds.Tables[0].Rows[0]["PARENT_RULE_SET_KPI"].ToString();
               
                CheckIsComplexLinked();
                
                if (chkdefn == "1")
                {
                    chkStdRwd.Checked = true;
                }
                else if (chkdefn == "0")
                {
                    chkStdRwd.Checked = false;
                }

                if (rblCRYFWD.SelectedValue == "N")
                {
                    txtMaxLmt.Enabled = false;
                }
                else
                {
                    txtMaxLmt.Enabled = true;
                }
                GetKpiOrigin();
                if (hdnKPIOrigin.Value == "1002")
                {
                    divBsKPIhdr.Visible = false;
                    FillSubGrid(dgSubCntst);
                    //ddlSlsChnl.SelectedValue = ds.Tables[0].Rows[0]["SUB_CHN"].ToString().Trim();
                    //FillCntst(Request.QueryString["cntstcd"].ToString().Trim(), ddlSubCls, Request.QueryString["cmpnstcd"].ToString().Trim(), "", "CHNCLS", "ChnClsVal");
                    //ddlSubCls.SelectedValue = ds.Tables[0].Rows[0]["SUB_CHNCLS"].ToString().Trim();
                    //FillCntst(Request.QueryString["cntstcd"].ToString().Trim(), ddlContestant, Request.QueryString["cmpnstcd"].ToString().Trim(), "", "MEMTYPE", "CNTSTNT_CODE");
                    //ddlContestant.SelectedValue = ds.Tables[0].Rows[0]["SUBCNTST"].ToString().Trim();
                    //GetRuleSetKeyDtls(ddlSubCnt);
                    //ddlSubCnt.SelectedValue = ds.Tables[0].Rows[0]["SUBRSK"].ToString().Trim();
                    /////FillSubGrid(Request.QueryString["cntstcd"].ToString().Trim(),dgSubCntst,Request.QueryString["cmpnstcd"].ToString().Trim(),"");
                }
                else
                {
                    divBsKPIhdr.Visible = false;
                }
                ddlRSKDesc.Enabled = false;
                ddlKPICode.Enabled = true;
                txtVrEffFrm.Enabled = false;
                txtVrEffTo.Enabled = false;
                chkStdRwd.Enabled = false;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "GetPageDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void BindDpndGrid()
    {
        try
        {
            DataSet dsdpnd = new DataSet();
            Hashtable htdpnd = new Hashtable();
            dsdpnd.Clear();
            htdpnd.Clear();
            if (Request.QueryString["cmpnstcd"] != null)
            {
                htdpnd.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                htdpnd.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
            }

            htdpnd.Add("@RULE_SET_KEY", txtRuleSetKey.Text.ToString().Trim());

            htdpnd.Add("@KPI_CODE", ddlKPICode.SelectedValue.ToString().Trim());
            dsdpnd = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI_DPNDT", htdpnd);
            if (dsdpnd.Tables.Count > 0 && dsdpnd.Tables[0].Rows.Count > 0)
            {
                dgdpnd.DataSource = dsdpnd;
                dgdpnd.DataBind();
            }
            else
            {
               // ShowNoResultFound(dsdpnd.Tables[0], grd);
            }
          //  Session["sbCnt"] = dsSub.Tables[0];
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "BindDpndGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {


        ds.Clear();
        htParam.Clear();
        string msgs;
        

        htParam.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());



        //  htParam.Add("@RULE_CODE", maxrulecode.ToString().Trim());
        htParam.Add("@RULE_SET_KEY", txtRuleSetKey.Text.ToString().Trim());
        htParam.Add("@KPI_CODE", ddlKPICode.SelectedValue.ToString().Trim());



        if (hdnComLinked.Value == "S")
        {
            if (ddlParntCmpCode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Compensation Code');", true);
                return;
            }
            if (ddlParntCntstCode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Contestant Code');", true);
                return;
            }

            if (ddlParntRulSetKy.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Rule Set Code');", true);
                return;
            }

        }



        if (txtVrEffFrm.Text != "")
        {
            htParam.Add("@EFF_FROM", Convert.ToDateTime(txtVrEffFrm.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@EFF_FROM", System.DBNull.Value);
        }
        if (txtVrEffTo.Text != "")
        {
            htParam.Add("@EFF_TO", Convert.ToDateTime(txtVrEffTo.Text.ToString().Trim()));
        }
        else
        {
            htParam.Add("@EFF_TO", System.DBNull.Value);
        }



        htParam.Add("@PRNT_CMPNSTN_CODE", ddlParntCmpCode.SelectedValue.ToString().Trim());
        htParam.Add("@PRNT_CNTSTNT_CODE", ddlParntCntstCode.SelectedValue.ToString().Trim());
        htParam.Add("@PRNT_RULE_SET_KEY", ddlParntRulSetKy.SelectedValue.ToString().Trim());

        htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());


        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpCntstKPI_DPNDT", htParam);


        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            msgs = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
            if (msgs == "FAIL")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Reward  description alredy exist');", true);
                //  ddlAccMode.SelectedIndex = 0;
                // rblCRYFWD.SelectedValue = "";
                //txtMaxLmt.Text = "";

                return;
            }
            else
            {
                
                 BindDpndGrid();
            }
        }

    }


private string  GetSTRACCYEAR()
    {
        DataSet dsCmpCode = new DataSet();
        dsCmpCode.Clear();


        string strACC_YEAR = "";
        Hashtable HTCmpCode = new Hashtable();
        HTCmpCode.Clear();


        HTCmpCode.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString());

        dsCmpCode = objDal.GetDataSetForPrc_SAIM("Prc_CHECKAccYear", HTCmpCode);



        if (dsCmpCode.Tables.Count > 0)
        {
            if (dsCmpCode.Tables[0].Rows.Count > 0)
            {

                strACC_YEAR = dsCmpCode.Tables[0].Rows[0]["ACC_YEAR"].ToString();

            }


        }

        return strACC_YEAR;
    }




    public void MaxCode()
    {
        try
        {
            DataSet dsMax = new DataSet();
            Hashtable htMax = new Hashtable();
            htMax.Clear();
            dsMax.Clear();
            htMax.Add("@cmpcode", Request.QueryString["cmpnstcd"].ToString().Trim());
            htMax.Add("@cntstcode", Request.QueryString["cntstcd"].ToString().Trim());

            htMax.Add("@flag", "1");
            dsMax = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodesForMaster", htMax);
            if (dsMax.Tables.Count > 0 && dsMax.Tables[0].Rows.Count > 0)
            {
                txtRuleSetKey.Text = dsMax.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
            }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "MaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }




    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            if (Request.QueryString["rultyp"] != null)
            {
                value = Request.QueryString["rultyp"].ToString().Trim();
            }

            var CRYFWD = string.Empty;
            var RwdCmpRul = string.Empty;
            var UnitType = string.Empty;
            var UnitTypeDsc = string.Empty;
            var MaxLmt = "0.00";

            if (rblCRYFWD.SelectedValue != "")
            {
                CRYFWD = rblCRYFWD.SelectedItem.Text.ToString().Trim();
            }
            if (ddlRwdCmpRul.SelectedValue != "")
            {
                RwdCmpRul = ddlRwdCmpRul.SelectedItem.Text.ToString().Trim();
            }
            if (ddlUnitType.SelectedValue != "")
            {
                UnitType = ddlUnitType.SelectedValue.ToString().Trim();
                UnitTypeDsc = ddlUnitType.SelectedItem.Text.ToString().Trim();
            }
            if (txtMaxLmt.Text != "")
            {
                MaxLmt = txtMaxLmt.Text.ToString().Trim();
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "doUpdOk('" + ddlKPICode.SelectedValue.ToString().Trim()
            //    + "','" + ddlKPICode.SelectedItem.Text.ToString().Trim() + "','" + ddlAccMode.SelectedValue.ToString().Trim()
            //    + "','" + txtVrEffFrm.Text.ToString().Trim() + "','" + txtVrEffTo.Text.ToString().Trim()
            //    + "','" + ddlAccMode.SelectedItem.Text.ToString().Trim() + "','" + txtRuleSetKey.Text.ToString().Trim()
            //    + "','" + CRYFWD + "','" + RwdCmpRul + "','" + UnitType + "','" + UnitTypeDsc
            //    + "','" + MaxLmt + "','" + value.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "btnUpdate_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

     protected void CheckIsWeighted()
    {
        try
        {
           DataSet chkW = new DataSet();
            chkW.Clear();
            htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE",Request.QueryString["cntstcd"].ToString().Trim());
            htParam.Add("@RuleSetCode", txtRuleSetKey.Text.Trim());
            chkW = objDal.GetDataSetForPrc_SAIM("Prc_GetRuleMethodFlag", htParam);
            if (chkW.Tables.Count > 0 && chkW.Tables[0].Rows.Count > 0)
            {
              
                if((chkW.Tables[0].Rows[0]["RULE_METHOD"].ToString() == "W"))
                {
                   // rblCRYFWD.SelectedIndex = 1;
                    //txtMaxLmt.Text = "0.00";
                    //txtMaxLmt.Enabled = false;
                   // rblCRYFWD.Enabled = false;
                }
                else 
                {
                    //rblCRYFWD.Enabled = true;
                   //rblCRYFWD.SelectedIndex = -1;
                   
                }

            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "CheckIsWeighted", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string value = String.Empty;
            int str = 0;
            string maxrulecode = String.Empty;
            string maxrulsetcd = String.Empty;
            DataTable dtR = new DataTable();


            var CRYFWD = string.Empty;
            var RwdCmpRul = string.Empty;
            var UnitType = string.Empty;
            var UnitTypeDsc = string.Empty;
            var MaxLmt = "0.00";
            if (Request.QueryString["cmpnstcd"] != null)
            {
                if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
                }
            }
            if (Request.QueryString["cntstcd"] != null)
            {
                if (Request.QueryString["cntstcd"].ToString().Trim() != null)
                {
                    cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
                }
            }
            if (Request.QueryString["rultyp"] != null)
            {
                value = Request.QueryString["rultyp"].ToString().Trim();
            }

            if (rblCRYFWD.SelectedValue != "")
            {
                CRYFWD = rblCRYFWD.SelectedItem.Text.ToString().Trim();
            }
            if (ddlRwdCmpRul.SelectedValue != "")
            {
                RwdCmpRul = ddlRwdCmpRul.SelectedItem.Text.ToString().Trim();
            }
            if (ddlUnitType.SelectedValue != "")
            {
                UnitType = ddlUnitType.SelectedValue.ToString().Trim();
                UnitTypeDsc = ddlUnitType.SelectedItem.Text.ToString().Trim();
            }
            if (txtMaxLmt.Text != "")
            {
                MaxLmt = txtMaxLmt.Text.ToString().Trim();
            }
            //if (Session["grid"] != null)
            //{
            //    dtR = (DataTable)Session["grid"];
            //    if (dtR.Rows.Count > 0)
            //    {
            //        maxrulecode = (Convert.ToInt32(dtR.Rows[dtR.Rows.Count - 1]["RULE_CODE"].ToString()) + 1).ToString().Trim();
            //        maxrulsetcd = dtR.Rows[dtR.Rows.Count - 1]["RULE_SET_KEY"].ToString().Trim();
            //    }
            //    else
            //    {
            //        maxrulecode = GetMaxCode("1");
            //        maxrulsetcd = hdnRulSetKy.Value.ToString().Trim();
            //    }
            //}
            //else
            //{
            //    maxrulecode = GetMaxCode("1");
            //    maxrulsetcd = hdnRulSetKy.Value.ToString().Trim();
            //}
            if (Request.QueryString["code"] != null)
            {
                maxrulecode = Request.QueryString["code"].ToString().Trim();
            }
            else
            {
                maxrulecode = GetMaxCode("1");
            }

            if (rblCRYFWD.SelectedValue == "Y" && Convert.ToDecimal(txtMaxLmt.Text) <= 0.00M)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Max Limit should be greater than 0.00');", true);
                return;
            }

            #region savekpi
            ds.Clear();
            htParam.Clear();
            string msgs;
            htParam.Add("@CMPNSTN_CODE", cmpnstcd.ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
            htParam.Add("@RULE_CODE", maxrulecode.ToString().Trim());
            htParam.Add("@RULE_SET_KEY", txtRuleSetKey.Text.ToString().Trim());
            htParam.Add("@KPI_CODE", ddlKPICode.SelectedValue.ToString().Trim());
            htParam.Add("@RULE_TYPE", value.ToString().Trim());
            htParam.Add("@ACC_MODE", ddlAccMode.SelectedValue.ToString().Trim());
            htParam.Add("@CRYFWD", rblCRYFWD.SelectedValue.ToString().Trim());
            htParam.Add("@RwdCmpRul", ddlRwdCmpRul.SelectedValue.ToString().Trim());
            htParam.Add("@UnitType", ddlUnitType.SelectedValue.ToString().Trim());
            htParam.Add("@ParentKPICode", ddlKPI_Code.SelectedValue.ToString().Trim());
            htParam.Add("@KPI_TRG_RUL_CLASS", ddlRuleClass.SelectedValue.ToString().Trim());
            htParam.Add("@IS_CUMULATIVE", ddlIsCumulative.SelectedValue.ToString().Trim());

            htParam.Add("@SET_CMPTN_RULE", ddlCmptnRule.SelectedValue.ToString().Trim());


            if (ddlCmptnRule.SelectedIndex ==0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Computtaion  Rule');", true);
                return;
            }
            if (ddlRuleClass.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select KPI  Rule Class');", true);
                return;
            }

            if (hdnComLinked.Value=="S")
            {
                if (ddlParntCmpCode.SelectedIndex==0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Compensation Code');", true);
                    return;
                }
                if (ddlParntCntstCode.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Contestant Code');", true);
                    return;
                }

                if (ddlParntRulSetKy.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "alert('Please Select Parent Rule Set Code');", true);
                    return;
                }

                htParam.Add("@PARNT_CMPNSTN_CODE", "");
                htParam.Add("@PARNT_CNTST_CODE", "");
                htParam.Add("@PARNT_RUL_SET_KEY","");

            }
            
            if (txtMaxLmt.Text != "")
            {
                htParam.Add("@MaxLmt", txtMaxLmt.Text.ToString().Trim());
            }
            else
            {
                htParam.Add("@MaxLmt", "0.00");
            }

            if (txtVrEffFrm.Text != "")
            {
                htParam.Add("@EFF_FROM", Convert.ToDateTime(txtVrEffFrm.Text.ToString().Trim()));
            }
            else
            {
                htParam.Add("@EFF_FROM", System.DBNull.Value);
            }
            if (txtVrEffTo.Text != "")
            {
                htParam.Add("@EFF_TO", Convert.ToDateTime(txtVrEffTo.Text.ToString().Trim()));
            }
            else
            {
                htParam.Add("@EFF_TO", System.DBNull.Value);
            }
            if (chkStdRwd.Checked == true)
            {
                htParam.Add("@CHKKPIFLAG", "1");
            }
            else
            {
                htParam.Add("@CHKKPIFLAG", "0");

            }

            if (ddlComptype.SelectedValue.ToString() != "0")
            {
            htParam.Add("@CMPTTN_FLAG", ddlComptype.SelectedValue.ToString());
            }

            htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            htParam.Add("@PER_TRG_FLAG", ddlDfnTrg.SelectedValue.ToString().Trim());
            //htParam.Add("@Flag","2003");

            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpCntstKPI", htParam);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                msgs = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msgs == "FAIL")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('KPI description alredy exist For this rule set key');", true);
                    ddlAccMode.SelectedIndex = 0;
                    rblCRYFWD.SelectedValue = "";
                    txtMaxLmt.Text = "";

                    return;
                }
            }



            if (hdnKPIOrigin.Value == "1002")
            {
                DataTable dtCnt = new DataTable();
                dtCnt = (DataTable)Session["sbCnt"];
                if (dtCnt.Rows.Count > 0)
                {
                    List<string> lstChn = new List<string>();
                    List<string> lstSubCls = new List<string>();
                    List<string> lstCnt = new List<string>();
                    List<string> lstRsk = new List<string>();

                    for (int intRowCount = 0; intRowCount <= dtCnt.Rows.Count - 1; intRowCount++)
                    {
                        lstChn.Add(dtCnt.Rows[intRowCount]["SUB_CHN"].ToString().Trim());
                        lstSubCls.Add(dtCnt.Rows[intRowCount]["SUB_CHNCLS"].ToString().Trim());
                        lstCnt.Add(dtCnt.Rows[intRowCount]["SUBCNTST"].ToString().Trim());
                        lstRsk.Add(dtCnt.Rows[intRowCount]["SUBRSK"].ToString().Trim());
                    }
                    for (int intDataCount = 0; intDataCount <= lstChn.Count - 1; intDataCount++)
                    {
                        htParam.Clear();
                        ds.Clear();
                        htParam.Add("@CMPNSTN_CODE", cmpnstcd.ToString().Trim());
                        htParam.Add("@CNTSTNT_CODE", cntstcd.ToString().Trim());
                        htParam.Add("@RULE_CODE", maxrulecode.ToString().Trim());
                        htParam.Add("@RULE_SET_KEY", txtRuleSetKey.Text.ToString().Trim());
                        htParam.Add("@KPI_CODE", ddlKPICode.SelectedValue.ToString().Trim());
                        htParam.Add("@RULE_TYPE", value.ToString().Trim());
                        htParam.Add("@CHN", lstChn[intDataCount]);
                        htParam.Add("@CHNCLS", lstSubCls[intDataCount]);
                        htParam.Add("@DRVDCNTST", lstCnt[intDataCount]);
                        htParam.Add("@DRVDRSK", lstRsk[intDataCount]);
                        htParam.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
                        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCmpCntstMapKPI", htParam);
                    }
                }
            }

            string msg;
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", cmpnstcd.Trim());
            htParam.Add("@CNTSTNT_CODE", cntstcd.Trim());
            htParam.Add("@RULE_CODE", txtRuleSetKey.Text.Trim());
            if (ddlRSKDesc.Visible == true)
            {
                htParam.Add("@RuleCodeDesc", ddlRSKDesc.SelectedItem.Text.Trim());
            }
            else
            {
                htParam.Add("@RuleCodeDesc", txtRSKDesc.Text.Trim());
            }
            htParam.Add("@RULE_TYPE", value.ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
          //  ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRuleSetCodeMst", htParam);  commented by ajay sawant ,sugggeted by arjun aroskar

            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    msg = ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
            //    if (msg =="FAIL")
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('KPI description alredy exist For This rule set key');", true);

            //        return;
            //    }
            //}

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('" + value.ToString().Trim() + "');", true);
            #endregion

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "doOk('" + ddlKPICode.SelectedValue.ToString().Trim() 
            //    + "','" + ddlKPICode.SelectedItem.Text.ToString().Trim() + "','" + ddlAccMode.SelectedValue.ToString().Trim() 
            //    + "','" + txtVrEffFrm.Text.ToString().Trim() + "','" + txtVrEffTo.Text.ToString().Trim() 
            //    + "','" + ddlAccMode.SelectedItem.Text.ToString().Trim() + "','" + txtRuleSetKey.Text.ToString().Trim()
            //    + "','" + CRYFWD + "','" + RwdCmpRul + "','" + UnitType + "','" + UnitTypeDsc
            //    + "','" + MaxLmt + "','" + value.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {

    }

    //added by ajay sawant

    protected void  btnTrg_Click(object sender, EventArgs e)
    {
        
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddVarMaster('" + Request.QueryString["cmpnstcd"].ToString().Trim() + "','" + Request.QueryString["cntstcd"].ToString().Trim() + "','" + txtRuleSetKey.Text.ToString().Trim() + "','" + ddlKPICode.SelectedValue.ToString().Trim() + "','" + ddlRuleClass.SelectedValue.ToString().Trim() + "');", true);

       
    }

    protected void FillDdl(DropDownList ddl, string ProcName)
    {
        try
        {
            
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CompCode", ddlParntCmpCode.SelectedValue.ToString());
            ht.Add("@CntstCode", ddlParntCntstCode.SelectedValue.ToString());
            ht.Add("@RuleCode", txtRuleSetKey.Text.ToString());
            ht.Add("@RULE_METHOD", "");
            drRead = objDal.Common_exec_reader_prc_SAIM(ProcName, ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "RULE_SET_KEY_DESC";
                ddl.DataValueField = "RULE_SET_KEY";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillDdl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void CreateRuleSetKey()
    {
        try
        {
            htParam.Clear();
            ds.Clear();
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
            htParam.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
           // htParam.Add("@RULE_CODE", "");
            //htParam.Add("@RuleCodeDesc", "");
            htParam.Add("@RULE_TYPE","R");
            htParam.Add("@UserId", HttpContext.Current.Session["UserID"].ToString().Trim());
        
            //ADDED BY AJAY SAWANT
            htParam.Add("@RuleMethod","N");
            htParam.Add("@ACCRUAL_ACC_CYCLE", "1008");
            htParam.Add("@ACC_CYCLE", "1008");
            htParam.Add("@RWRD_REL_CYCLE ", "1008");
            htParam.Add("@RWD_CMP_CYCLE ", "1008");

            htParam.Add("@TRG_CATG_RUL_CLASS", "S");//RWD_RUL_CLASS
            htParam.Add("@RWD_RUL_CLASS", "S");


            htParam.Add("@RUL_SET_CMPLXTY", "");

         


            strACC_YEAR = GetSTRACCYEAR();
            if (strACC_YEAR == "1003")
         	 {
  		htParam.Add("@MEM_ACH_ACC_CYCLE", "A");
            	htParam.Add("@MEM_RWD_CMP_CYCLE", "A");
            	htParam.Add("@MEM_RWD_REL_CYCLE", "A");
                          
            }
		else
		{
		htParam.Add("@MEM_ACH_ACC_CYCLE", "");
            	htParam.Add("@MEM_RWD_CMP_CYCLE", "");
            	htParam.Add("@MEM_RWD_REL_CYCLE", "");
                           

		}
              htParam.Add("@PARENT_RULESECODE","" ); //@PARENT_RULESETDesc

             

              htParam.Add("@PARENT_CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
              htParam.Add("@PARENT_CNTST_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
                
              htParam.Add("@ACH_TABLE","");


              ds = objDal.GetDataSetForPrc_SAIM("Prc_CreateRuleSetCodeMst", htParam);

              if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
              {

                  txtRuleSetKey.Text = ds.Tables[0].Rows[0]["RuleSetCode"].ToString().Trim();
                  txtRSKDesc.Text = ds.Tables[0].Rows[0]["RuleSetDesc"].ToString().Trim();
              }


        }

        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "CreateRuleSetKey", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }


    protected void ddlParntCntstCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDdl(ddlParntRulSetKy, "Prc_FillParentRuleSetKey");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlParntCntstCode_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void ddlParntCmpCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillParentCnstntCode(ddlParntCntstCode, "Prc_FillParentCnstntCode");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlParntCmpCode_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void CheckIsComplexLinked()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@RuleSetCode", txtRuleSetKey.Text.ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_IsComplexLinked", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                
                if(ds.Tables[0].Rows[0]["MSG"].ToString()=="S")
                {
                    Divdpndhead.Visible = true;
                    divdpnd.Visible = true;
                    divParentCntst.Visible=true;
                    lblparentCode.Visible=true;
                    ddlParntCmpCode.Visible=true;

                    hdnComLinked.Value = "S";

                    BindDpndGrid();
                }
                else
                {
                    Divdpndhead.Visible = false;
                    divdpnd.Visible = false;
                    divParentCntst.Visible=false;
                    lblparentCode.Visible=false;
                    ddlParntCmpCode.Visible=false;
                    hdnComLinked.Value = "F";

                }
            }


            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                ddlParntCmpCode.SelectedValue = ds.Tables[1].Rows[0]["PARENT_CMPNSTN_CODE"].ToString();
                ddlParntCmpCode_SelectedIndexChanged(null,null);
                ddlParntCntstCode.SelectedValue = ds.Tables[1].Rows[0]["PARENT_CNTST_CODE"].ToString();
                ddlParntCntstCode_SelectedIndexChanged(null,null);
                ddlParntRulSetKy.SelectedValue = ds.Tables[1].Rows[0]["PARENT_RULESECODE"].ToString();
            }

        }

        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "CheckIsComplexLinked", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }



    }



    protected void FillParentCmpnstnCode(DropDownList ddl, string ProcName)
    {
        try
        {

            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM(ProcName, ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "CMPNSTN_CODE_DESC";
                ddl.DataValueField = "CMPNSTN_CODE";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillParentCmpnstnCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void FillParentCnstntCode(DropDownList ddl, string ProcName)
    {
        try
        {
            
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CMPNSTN_CODE", ddlParntCmpCode.SelectedValue.ToString());
            ht.Add("@CNTSTNT_CODE", Request.QueryString["cntstcd"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM(ProcName, ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "CNTSTNT_CODE";
                ddl.DataValueField = "CNTSTNT_CODE";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillParentCnstntCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }



    protected void FillParentKPI(DropDownList ddl, string val)
    {
        try
        {
            // divparentkpi.Visible = true;
            ddl.Items.Clear();
            //ds.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CompCode", Request.QueryString["cmpnstcd"].ToString().Trim());


            ht.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());

            ht.Add("@RuleSetKey", val.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillKPIDESC", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "KPI_DESC_01";
                ddl.DataValueField = "KPI_CODE";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillParentKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void FillddlKPI(DropDownList ddl, string proc, string text, string value, string flag, string memrole, string chnl, string schnl)
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            htParam.Add("@Flag", flag.Trim());
            if (memrole != "")
            {
                htParam.Add("@MemRole", memrole.Trim());
                htParam.Add("@CHN", chnl.Trim());
                htParam.Add("@SCHN", schnl.Trim());
            }
            ddl.Items.Clear();
            drRead = objDal.Common_exec_reader_prc_SAIM(proc.ToString().Trim(), htParam);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = text.ToString().Trim();
                ddl.DataValueField = value.ToString().Trim();
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillddlKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void chkRulSetKy_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
        if (chkRulSetKy.Checked == true)
        {
            txtRuleSetKey.Text = (Convert.ToInt32(txtRuleSetKey.Text) + 1).ToString().Trim();
        }
        else
        {
            txtRuleSetKey.Text = txtRuleSetKey.Text.ToString().Trim();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "chkRulSetKy_CheckedChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void FillDropDown(DropDownList ddl, string val)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@CMPNSTN_CODE", Request.QueryString["cmpnstcd"].ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "DESC01";
                ddl.DataValueField = "CODE";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillDropDown", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg, string kpiCode)
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
	ht.Add("@KPI_CODE", kpiCode.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
	}
	
        drRead.Close();
      ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
	
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    }
    protected void lnkRuleSetKy_Click(object sender, EventArgs e)
    {
        try
        {
            //if (chkRulSetKy.Checked == true)
            //{
            htParam.Clear();
            htParam.Add("@flag", "4");
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodes", htParam);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ////txtRuleSetKey.Text = (Convert.ToInt32(txtRuleSetKey.Text) + 1).ToString().Trim();
                txtRuleSetKey.Text = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
            }
            else
            {
                txtRuleSetKey.Text = "";
            }

            //}
            //else
            //{
            //    txtRuleSetKey.Text = txtRuleSetKey.Text.ToString().Trim();
            //}
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "lnkRuleSetKy_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //protected void lnkKeyDfn_Click(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["cmpnstcd"] != null)
    //    {
    //        if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
    //        {
    //            cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
    //        }
    //    }
    //    if (Request.QueryString["cntstcd"] != null)
    //    {
    //        if (Request.QueryString["cntstcd"].ToString().Trim() != null)
    //        {
    //            cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
    //        }
    //    }
    //    if (Request.QueryString["rultyp"] != null)
    //    {
    //        rultyp = Request.QueryString["rultyp"].ToString().Trim();
    //    }

    //    ///////lnkKeyDfn.Attributes.Add("onclick", "funPopUpRwdRul('" + cmpnstcd + "','" + cmpnstcd + "','" + rultyp + "');return false;");
    //    mdlVw.Show();
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funPopUpRwdRul('" + cmpnstcd + "','" + cntstcd + "','" + rultyp + "');", true);
        
    //}

    protected void InitializeControl()
    {
        try
        {
        if (Request.QueryString["rultyp"] != null)
        {
            if (Request.QueryString["rultyp"] == "Q")
            {
                lblhdr.Text = "Select KPI for qualification rule";
            }
            else if (Request.QueryString["rultyp"] == "R")
            {
                lblhdr.Text = "Select KPI for reward rule";
            }
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "InitializeControl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected string GetMaxCode(string flag)
    {
        string code = String.Empty;
        ds.Clear();
        try
        {
        
        htParam.Clear();
        htParam.Add("@flag", flag.ToString().Trim());
        htParam.Add("@cmpcode", cmpnstcd.ToString().Trim());
        htParam.Add("@cntstcode", cntstcd.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetMaxCodes", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            code = ds.Tables[0].Rows[0]["MaxCode"].ToString().Trim();
        }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "GetMaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
        return code.ToString().Trim();
    }

    protected void rblCRYFWD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (rblCRYFWD.SelectedValue == "N")
        {
           // txtMaxLmt.Text = "0.00";
            txtMaxLmt.Enabled = false;
        }
        else
        {
            //txtMaxLmt.Text = "0.00";
            txtMaxLmt.Enabled = true;
        }
        if ((ddlUnitType.SelectedIndex == 1) || (ddlUnitType.SelectedIndex == 3))
        {
            txtMaxLmt.Text = "0.00";
        }
        else
        {
            txtMaxLmt.Text = "00";
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "rblCRYFWD_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    }
    protected void ddlKPICode_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
        GetKpiOrigin();
	
	

	FillDropDowns(ddlCmptnRule, "45", "", "P",ddlKPICode.SelectedValue.ToString());
        if (hdnKPIOrigin.Value == "1002")
        {
            divBsKPIhdr.Visible = false;
            FillSubGrid(dgSubCntst);
            chkStdRwd.Enabled = false;
        }
        else if (hdnKPIOrigin.Value == "1003")
        {
            divBsKPIhdr.Visible = false;
            chkStdRwd.Enabled = false;
        }
        else
        {
            divBsKPIhdr.Visible = false;
            chkStdRwd.Enabled = true;
        }
       // rblCRYFWD.ClearSelection();
       // txtMaxLmt.Text = "";
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlKPICode_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    }
    protected void ddlRSKDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (ddlRSKDesc.SelectedValue == "")
        {
            txtRuleSetKey.Text = "";
        }
        else
        {
            txtRuleSetKey.Text = ddlRSKDesc.SelectedValue;
        }
        FillParentKPI(ddlKPI_Code, ddlRSKDesc.SelectedValue);
        CheckIsWeighted();
        CheckIsComplexLinked();
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlRSKDesc_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    }

    protected string ChkKPICode(string compcode, string cntstcode, string kpicode, string rskey)
    {
        string isExists = string.Empty;
        try
        {
        htParam.Clear();
        ds.Clear();
        
        htParam.Add("@KPI_CODE", ddlKPICode.SelectedValue.Trim());
        htParam.Add("@CMPNSTN_CODE", compcode.Trim());
        htParam.Add("@CNTSTN_CODE", cntstcode.Trim());
        htParam.Add("@RULE_SET_KEY", rskey.Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_ChkKPIExists", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            isExists = ds.Tables[0].Rows[0]["ISEXISTS"].ToString().Trim();
        }
       
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ChkKPICode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
        return isExists.ToString().Trim();
    }


    protected void txtMaxLmt_TextChanged(object sender, EventArgs e)
    {
        //if ((ddlUnitType.SelectedIndex == 1) || (ddlUnitType.SelectedIndex == 3))
        //{
        //    txtMaxLmt.Text = "0.00";
        //}
        //else
        //{
        //    txtMaxLmt.Text = "00";
        //}
        if (!(ddlUnitType.SelectedValue == "1001") || (ddlUnitType.SelectedValue == "1003"))
        {
            int val=0;
            
            try
            {
                 val = Convert.ToInt32(txtMaxLmt.Text);
                 
            }
            catch
            {
                //txtMaxLmt.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Only Integer Number');", true);
                return;

            }
        }
        //else
        //{
        //    if (txtMaxLmt.Text.Trim() != "")
        //    {
        //        try
        //        {
        //            int i = Convert.ToInt32(txtMaxLmt.Text.Trim());
        //        }
        //        catch
        //        {
        //            //txtMaxLmt.Text = "";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Only Integer Number in Max Limit');", true);
        //            return;

        //        }
        //    }
        //}
    }

    protected void btnMaster_Click(object sender, EventArgs e)
    {
        try
        {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        if (Request.QueryString["rultyp"] != null)
        {
            value = Request.QueryString["rultyp"].ToString().Trim();
        }
        mdlVw.Show();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "funAddmaster('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','CntstRwdIndctr','" + value.ToString().Trim() + "');", true);
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "btnMaster_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    }
            
    }
        


    protected void btnKPI_Click(object sender, EventArgs e)
    {
        try
        {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        if (Request.QueryString["rultyp"] != null)
        {
            value = Request.QueryString["rultyp"].ToString().Trim();
        }
        GetRuleSetKeyDtls(ddlRSKDesc);
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "btnKPI_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void FillCntst(string pcntstcd, DropDownList ddl, string cmpcode, string cntstcd, string text, string value)
    {
        try
        {
        DataSet dsCntst = new DataSet();
        Hashtable htCntst = new Hashtable();
        dsCntst.Clear();
        htCntst.Clear();
        ddl.Items.Clear();
        htCntst.Add("@PCntstCode", pcntstcd.ToString().Trim());
        htCntst.Add("@CntstCode", cntstcd.ToString().Trim());
        htCntst.Add("@CmpCode", cmpcode.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetSubCntstDtls", htCntst);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = text.ToString().Trim();
            ddl.DataValueField = value.ToString().Trim();
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillCntst", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    }
            
    }


    //added by ajay sawant

    protected void ddlDfnTrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDfnTrg.SelectedValue.ToString().Trim() == "Y")
            {

                btnTrg.Visible = true;
            }
            else
            {
                btnTrg.Visible = false;

            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlDfnTrg_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }




    protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlUnitType.SelectedValue.ToString().Trim() == "1003")
            {
                ddlDfnTrg.Visible = true;
            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlUnitType_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void ddlContestant_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (ddlContestant.SelectedValue != "")
        {
            if (Request.QueryString["cmpnstcd"] != null)
            {
                if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
                {
                    cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
                }
            }
            if (Request.QueryString["rultyp"] != null)
            {
                value = Request.QueryString["rultyp"].ToString().Trim();
            }
            cntstcd = ddlContestant.SelectedValue.ToString().Trim();
            GetRuleSetKeyDtls(ddlSubCnt);
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlContestant_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void ddlSlsChnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        if (Request.QueryString["rultyp"] != null)
        {
            value = Request.QueryString["rultyp"].ToString().Trim();
        }

        FillCntst(cntstcd.ToString().Trim(), ddlSubCls, cmpnstcd.ToString().Trim(), "", "CHNCLS", "ChnClsVal");
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlSlsChnl_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void ddlSubCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        if (Request.QueryString["rultyp"] != null)
        {
            value = Request.QueryString["rultyp"].ToString().Trim();
        }
        FillCntst(cntstcd.ToString().Trim(), ddlContestant, cmpnstcd.ToString().Trim(), "", "MEMTYPE", "CNTSTNT_CODE");
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ddlSubCls_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void GetKpiOrigin()
    {
        try
        {
        Hashtable htOrg = new Hashtable();
        DataSet dsOrg = new DataSet();
        htOrg.Clear();
        dsOrg.Clear();
        htOrg.Add("@KPICode", ddlKPICode.SelectedValue.Trim());
        htOrg.Add("@Flag", "1");
        dsOrg = objDal.GetDataSetForPrc_SAIM("Prc_KPISearch", htOrg);
        if (dsOrg.Tables.Count > 0 && dsOrg.Tables[0].Rows.Count > 0)
        {
            ddlUnitType.SelectedValue = dsOrg.Tables[0].Rows[0]["KPI_TYPE"].ToString().Trim();
            hdnKPIOrigin.Value = dsOrg.Tables[0].Rows[0]["KPI_ORIGIN"].ToString().Trim();
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "GetKpiOrigin", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void FillSubGrid(GridView grd)
    {
        try
        {
        DataSet dsSub = new DataSet();
        Hashtable htSub = new Hashtable();
        dsSub.Clear();
        htSub.Clear();
        if (Request.QueryString["cmpnstcd"] != null)
        {
            htSub.Add("@CmpCode", Request.QueryString["cmpnstcd"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htSub.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        }
        if (Request.QueryString["rultyp"] != null)
        {
            htSub.Add("@RuleType", Request.QueryString["rultyp"].ToString().Trim());
        }
        htSub.Add("@KPICode", ddlKPICode.SelectedValue.ToString().Trim());
        dsSub = objDal.GetDataSetForPrc_SAIM("Prc_GetCmpCntstKPI", htSub);
        if (dsSub.Tables.Count > 0 && dsSub.Tables[0].Rows.Count > 0)
        {
            grd.DataSource = dsSub;
            grd.DataBind();
        }
        else
        {
            ShowNoResultFound(dsSub.Tables[0], grd);
        }
        Session["sbCnt"] = dsSub.Tables[0];
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillSubGrid", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }




    protected void btnAddSub_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popSub", "funPopSubCnt('" + Request.QueryString["cmpnstcd"].ToString().Trim() + "','"
            + Request.QueryString["cntstcd"].ToString().Trim() + "','" + Request.QueryString["rultyp"].ToString().Trim() + "')", true);
        mdlVw.Show();
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
        gv.Rows[0].Cells[0].Text = "No mapping have been defined";
        source.Rows.Clear();
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void btnSbCnt_Click(object sender, EventArgs e)
    {
        try
        {
        DataTable dtSbCnt = new DataTable();
        dtSbCnt = (DataTable)Session["sbCnt"];
        if (dgSubCntst.Rows.Count > 0)
        {
            dgSubCntst.DataSource = dtSbCnt;
            dgSubCntst.DataBind();
        }
        
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "btnSbCnt_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void txtRSKDesc_TextChanged(object sender, EventArgs e)
    {
        txtRSKDesc.Text = "";
    }

    protected string FillCmp()
    {
        string memrole = string.Empty;
        try
        {
        htParam.Clear();
        ds.Clear();
      
        if (Request.QueryString["cmpnstcd"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["cmpnstcd"].ToString().Trim());
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["cntstcd"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_FillCmpCntstDtls", htParam);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            memrole = ds.Tables[0].Rows[0]["MEMROLE"].ToString().Trim();
        }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopQualSetup", "FillCmp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
            
    

        return memrole.Trim();
    }

    protected void ddlIsCumulative_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsCumulative.SelectedItem.ToString() == "YES")
        {
            btnMemCycle.Visible = true;
}
        else
        {
            btnMemCycle.Visible = false;
        }
    }

    protected void btnMemCycle_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["cmpnstcd"] != null)
        {
            if (Request.QueryString["cmpnstcd"].ToString().Trim() != null)
            {
                cmpnstcd = Request.QueryString["cmpnstcd"].ToString().Trim();
            }
        }
        if (Request.QueryString["cntstcd"] != null)
        {
            if (Request.QueryString["cntstcd"].ToString().Trim() != null)
            {
                cntstcd = Request.QueryString["cntstcd"].ToString().Trim();
            }
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "OpenPopupWindow('" + cmpnstcd.ToString().Trim() + "','" + cntstcd.ToString().Trim() + "','" + txtRuleSetKey.Text.ToString().Trim() + "','" + ddlKPICode.SelectedValue.ToString().Trim() + "');", true);
        
    }

}
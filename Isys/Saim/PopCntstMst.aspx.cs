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

public partial class Application_ISys_Saim_PopCntstMst : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp;
    string value = String.Empty;
    string WScore, ddlAccYear, txtEffDtFrm, txtEffDtTo, BUSI_YEAR;

    string strACC_YEAR = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        if (!IsPostBack)
        {


            //FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
            GetPageDtls();
            ShowRulStKy();
                ButtonDisplay();
           // FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");
            if (gvAddMst.PageCount > 1)
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
                strACC_YEAR = GetSTRACCYEAR();
                if (strACC_YEAR == "1003")
                {
                    spnMEM_ACH_ACC_CYCLE.Visible = true;
                    spnMEM_RWD_CMP_CYCLE.Visible = true;
                    spnMEM_RWD_REL_CYCLE.Visible = true;
                }
                if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")//Add rule set popup
                {
                    DivMember.Visible = true;
                    fillddlMemhierusdate();
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void fillddlMemhierusdate()
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", "55");
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
            if (drRead.HasRows)
            {
                ddlMemhierusdate.DataSource = drRead;
                ddlMemhierusdate.DataTextField = "DESC01";
                ddlMemhierusdate.DataValueField = "CODE";
                ddlMemhierusdate.DataBind();
            }
            drRead.Close();
            ddlMemhierusdate.Items.Insert(0, new ListItem("--SELECT--", ""));
            ddlMemhierusdate.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            // string sRet = oInfo.Name;
            // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "fillddlMemhierusdate", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //added by ajay sawant
    //protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg)
    //{
    //    try
    //    {
    //        ddl.Items.Clear();
    //        Hashtable ht = new Hashtable();
    //        ht.Add("@Flag", val.ToString().Trim());
    //        if (yrtyp != "")
    //        {
    //            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
    //        }
    //        ht.Add("@TYPFLG", typflg.ToString().Trim());
    //        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddl.DataSource = drRead;
    //            ddl.DataTextField = "DESC01";
    //            ddl.DataValueField = "CODE";
    //            ddl.DataBind();
    //        }
    //        drRead.Close();
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


    protected void ButtonDisplay()
    {
        htParam.Clear();
        ds.Clear();
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_CMPN_STATUS", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["status"].ToString() == "1006")
            {
                //btnAddCntst.Visible = false;
                btnSave.Visible = false;

                gvAddMst.Columns[15].Visible = false;
                gvAddMst.Columns[16].Visible = false;


            }
        }
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
            ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillRwdRlsCyc", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

   
     protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
     protected void FillKPI(DropDownList ddl,string val)
     {
         try
         {
            // divparentkpi.Visible = true;
             ddl.Items.Clear();
             Hashtable ht = new Hashtable();
             ht.Add("@CompCode",lblCompCodeVal.Text.ToString());
             ht.Add("@CntstCode", lblCntstCdVal.Text.ToString());

             ht.Add("@RuleSetKey", val.ToString().Trim());
             drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillKPIDESC", ht);
             if (drRead.HasRows)
             {
                 ddl.DataSource = drRead;
                 ddl.DataTextField = "KPI_DESC";
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillKPI", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
         }
     }

    
     protected void FillDdl(DropDownList ddl,string ProcName)
     {
         try
         {
             
             ddl.Items.Clear();
             Hashtable ht = new Hashtable();
            ht.Add("@CompCode", ddlPcmpCode.SelectedValue.ToString());
            ht.Add("@CntstCode", ddlPCntCode.SelectedValue.ToString());
             ht.Add("@RuleCode", txtRuleSetKey.Text.ToString());
             ht.Add("@RULE_METHOD", ddlRuleMethod.SelectedValue.ToString());
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillDdl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
         }
     }


    protected void rblIsparent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cycleM0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(cycleM0.SelectedValue=="Y")
        {
            
            Label14.Visible = true;
            if (ddlMEM_ACH_ACC_CYCLE.SelectedValue=="M")
            {
                rdoseparate.Visible = true;
                Label14.Visible = true;
            }
            else
            {
                rdoseparate.Visible = false;
                Label14.Visible = false;
            }
          
        }
		
		else
		{
			 rdoseparate.Visible = false;
                Label14.Visible = false;
		
		}
		
    }


    protected void rdoseparate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoseparate.SelectedValue == "N")
        {
            lblnote.Visible = true;
            Label15.Visible = true;
        }
        else
        {
            lblnote.Visible = false;
            Label15.Visible = false;
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "GetCycleDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        } return cyctype;
    }

    protected void ddlAccCyc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GetCycleDetails("IS_STANDARD", "23") == "0")
            {
                btncycle.Visible = true;
            }
            else
            {
                btncycle.Visible = false;
            }


        FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
        ddlRwdRlsCyc.SelectedValue = ddlAccCyc.SelectedValue.ToString();
        FillRwdRlsCyc(ddlRewardComputation, "22", "");

        ddlRewardComputation.SelectedValue = ddlAccCyc.SelectedValue.ToString();
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htPara = new Hashtable();
            DataSet dsPara = new DataSet();

           
          string strSuccess = string.Empty;
          string strFail = string.Empty;



          int strCheckSelectLead = 0, strDrpDwnlead=0;

          foreach (GridViewRow rowItem in gvDsgnTsk.Rows)
          {
              CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");
              DropDownList DrpDwn = (DropDownList)rowItem.FindControl("ddlAchGv");
                


                if (chBx.Checked == true)
              {
                  strCheckSelectLead = strCheckSelectLead + 1;

                    if (DrpDwn.SelectedValue.ToString()=="")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select source table.');</script>", false);


                        return;
                    }
                        

                  //if(DrpDwn.SelectedIndex!=0)
                  //{
                  //    strDrpDwnlead = strDrpDwnlead + 1;                      
                  //}
                  
              }
          }


          if (strCheckSelectLead <= 0)
          {
              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select action.');</script>", false);


              return;
  
          }

          else
          {
              //if (TextareaRemark.Value=="")
              //{
              //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter remark');", true);

              //    return;
              //}

             // ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRuleSetCodeMst", htParam);
              foreach (GridViewRow rowItem in gvDsgnTsk.Rows)
              {
                  CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");

                  htPara.Clear();
                  dsPara.Clear();
        
                  if (chBx.Checked == true)
                  {
                     // HiddenField hdnRWD_RUL_CODE = (HiddenField)rowItem.FindControl("hdnRWD_RUL_CODE");

                      DropDownList DrpDwn1 = (DropDownList)rowItem.FindControl("ddlAchGv");
                        //   
                        TextBox txtval = (TextBox)rowItem.FindControl("txtVal");
                        Label lblRuleCode = (Label)rowItem.FindControl("lblRuleSetCode");

                        //if(ddlRulComplexity.SelectedValue.ToString()=="CL")
                        //{
                        //    if (txtval.Text == "")
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please add mapping value.');</script>", false);


                        //        return;
                        //    }
                        //    else
                        //    {
                        //        htPara.Add("@KPI_CODE", "1000000301");
                        //    }

                        //}
                        //if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
                        //{
                        //    htPara.Add("@KPI_CODE", "1000000501");
                        //}

                        //      htPara.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
                        //htPara.Add("@CNTSTNT_CODE", Request.QueryString["CntstCode"].ToString().Trim());

                        HiddenField cmpnstncode = (HiddenField)rowItem.FindControl("HiddenField1");
                        HiddenField cntstntcode = (HiddenField)rowItem.FindControl("HiddenField2");

                        htPara.Add("@CMPNSTN_CODE", cmpnstncode.Value);
                        htPara.Add("@CNTSTNT_CODE", cntstntcode.Value);
                        htPara.Add("@TASK_ID",txtRuleSetKey.Text.ToString());
                      htPara.Add("@RULSET_CODE", lblRuleCode.Text.ToString());
                      
                      htPara.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
                      htPara.Add("@UPDATED_BY", Session["UserID"].ToString().Trim());
                      htPara.Add("@SRC_TBL", DrpDwn1.SelectedValue.ToString());
                        //htPara.Add("@Rwrd_val", txtval.Text .ToString()); commented by Abuzar on 08-07-2020


                        dsPara = objDal.GetDataSetForPrc_SAIM("Prc_InsCUSTOM_TASK", htPara);
                     // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Rule Set Code Added!!');</script>", false);


                  }
                  else
                  {
                      //strFail = "N";
                  }
              }
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Ruleset mapping saved successfully')", true);
              //txtRuleSetKeyDsc.Text = "";
              //ddlMEM_ACH_ACC_CYCLE.SelectedIndex = 0;
              //ddlMEM_RWD_CMP_CYCLE.SelectedIndex = 0;
              //ddlMEM_RWD_REL_CYCLE.SelectedIndex = 0;

          }

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btnAdd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btncycle_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsAcc = new DataSet();
            Hashtable htAcc = new Hashtable();
            dsAcc.Clear();
            htAcc.Clear();
            htAcc.Add("@cmpcode", lblCompCodeVal.Text);

            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAccAccrRewardDtls", htAcc);
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlAccYear = ds.Tables[0].Rows[0]["ACC_YEAR"].ToString();
                    txtEffDtFrm = ds.Tables[0].Rows[0]["EFF_FROM"].ToString();
                    txtEffDtTo = ds.Tables[0].Rows[0]["EFF_TO"].ToString();
                    BUSI_YEAR = ds.Tables[0].Rows[0]["BUSI_YEAR"].ToString();

                    

                }

            }


            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle();", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "showPopUp", "funPopUpCycle('" + lblCompCodeVal.Text.ToString().Trim() + "','" + ddlAccCyc.SelectedValue.ToString().Trim() + "','" + GetCycleDetails("CYCLE_TYPE", "23") + "','" + ddlAccYear + "','" + txtEffDtFrm.Trim() + "','" + txtEffDtTo + "','" + txtRuleSetKey.Text.ToString() + "','" + lblCntstCdVal.Text.ToString() + "','" + BUSI_YEAR + "');", true);
           
            
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btncycle_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        ht.Add("@TYPFLG", typflg.ToString().Trim());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
        ddl.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    
       
    protected void CheckIsWeighted()
    {
        try
        {
            DataSet chkW = new DataSet();
            chkW.Clear();
            hdnIsValid.Value = "";
            htParam = new Hashtable();
            htParam.Clear();
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
            htParam.Add("@RuleSetCode", txtRulSetDsc.Text.Trim());
            chkW = objDal.GetDataSetForPrc_SAIM("Prc_GetRuleMethodFlag", htParam);
            if (chkW.Tables.Count > 0 && chkW.Tables[0].Rows.Count > 0)
            {

                if ((chkW.Tables[0].Rows[0]["RULE_METHOD"].ToString() == "W"))
                {
                    if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
                    {
                        divScore.Visible = true;
                        hdnIsValid.Value = "W";
                    }
                    //WScore="Yes;
                }
                else
                {
                    // rblCRYFWD.SelectedIndex = 0;
                    divScore.Visible = false;

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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "CheckIsWeighted", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    //Added by ajay sawant
    public void MaxCode(string val)
    {
        try
        {
            DataSet dsMax = new DataSet();
            Hashtable htMax = new Hashtable();
            htMax.Clear();
            dsMax.Clear();
            htMax.Add("@cmpcode", lblCompCodeVal.Text.Trim());
            htMax.Add("@cntstcode", lblCntstCdVal.Text.Trim());

            htMax.Add("@flag", val);
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "MaxCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void GetPageDtls()
    {
        try
        {
        lblCompCodeVal.Text = Request.QueryString["CmpCode"].ToString().Trim();
        lblCntstCdVal.Text = Request.QueryString["CntstCode"].ToString().Trim();
        htParam.Clear();
        ds.Clear();
        string cmptype = "";
        htParam.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        htParam.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            
            htParam.Add("@flag", "1");
            lnkrwddsc.Visible = false;
            divrul.Visible = false;
            divRuleMethod.Visible = true;
                divRuleType.Visible = true;

                FillDropDowns(ddlRuleMethod, "39");
            FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");
                FillParentCmpnstnCode(ddlPcmpCode, "Prc_FillParentCmpnstnCode");
                ddlPcmpCode.SelectedValue = lblCompCodeVal.Text;
                FillParentCnstntCode(ddlPCntCode, "Prc_FillParentCnstntCode");
                FillAchievementTable(ddlAch, "Prc_FillAchievementTable");
                FillDropDowns(ddlOperator, "40");
                FillDropDowns(ddlRuleType, "41");
                FillDropDowns(ddlRuleClass, "41");

                FillDropDowns(ddlRulComplexity,"43");
                FillDropDowns(ddlAccCyc, "8", "", "");
                FillDropDowns(ddlAccrCyc, "8", "", "");
                ddlPCntCode.SelectedValue = lblCntstCdVal.Text;
            ddlParentRule_SelectedIndexChanged(null, null);
            //ddlKPI_Code.SelectedIndex = 0;
            divAccumulation.Visible = true;
            divReward.Visible = true;
                divParent.Visible = true; // <%--Added by prity on 23 aug 2018--%>
                DivAchtable.Visible = true;
            DataSet dsAcc = new DataSet();
            Hashtable htAcc = new Hashtable();
            dsAcc.Clear();
            htAcc.Clear();
            htAcc.Add("@cmpcode", lblCompCodeVal.Text);

            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetAccAccrRewardDtls",htAcc);
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlAccrCyc.SelectedValue = ds.Tables[0].Rows[0]["ACCRUAL_ACC_CYCLE"].ToString();
                    ddlAccCyc.SelectedValue = ds.Tables[0].Rows[0]["ACC_CYCLE"].ToString();
                    
                    ddlRwdRlsCyc.SelectedValue = ds.Tables[0].Rows[0]["RWRD_REL_CYCLE"].ToString();
                    ddlRewardComputation.SelectedValue = ds.Tables[0].Rows[0]["RWD_CMP_CYCLE"].ToString();
                    ddlAccYear=ds.Tables[0].Rows[0]["ACC_YEAR"].ToString();
                    txtEffDtFrm=ds.Tables[0].Rows[0]["EFF_FROM"].ToString();
                    txtEffDtTo = ds.Tables[0].Rows[0]["EFF_TO"].ToString();
                    cmptype = ds.Tables[0].Rows[0]["CMPNSTN_TYPE"].ToString();

                    ddlAccCyc_SelectedIndexChanged(null, null);

                }
               
            }
              


            if (cmptype == "1001")
            {
                lblParent.Visible = false;
                ddlParentRule.Visible = false;
                    divParent.Visible = false;
                    DivAchtable.Visible = false;
                }
                else
                {
                    lblParent.Visible = true;
                    ddlParentRule.Visible = true;
                    divParent.Visible = true;
                    DivAchtable.Visible = true;
            }

            
            strACC_YEAR = GetSTRACCYEAR();
            if (strACC_YEAR == "1003")
            {
                divMemCycleData.Visible = true;
                divMemCycleData2.Visible = true;
                MoCycle.Visible = true;
                
        }


            if (ddlPcmpCode.SelectedIndex!=0  && ddlPCntCode.SelectedIndex!=0 && ddlParentRule.SelectedIndex!=0)
            {
                lblRulCmpx.Visible = true;
                ddlRulComplexity.Visible = true;
            }
         
            
            MaxCode("1");

        }
        else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        {
           
            htParam.Add("@flag", "2");
            lblrlSetKy.Text = "Category Code";
            lblRuleSetKeyDesc.Text = "Category Description";
            txtRuleSetKeyDsc.Attributes.Add("placeholder", "Category Description");
            lnkrwddsc.Visible = false;
                divParent.Visible = false; // <%--Added by prity on 23 aug 2018--%>
                DivAchtable.Visible = false;
          strACC_YEAR=  GetSTRACCYEAR();

          btnBlkCatgUpd.Visible = true;
           // divCat2.Visible = true;
            if(strACC_YEAR=="1003")
            {
            divCat1.Visible = true;
            ShowMembecycle();
            FillDropDowns(DropDownList1, "9", "", "");
            DropDownList1.SelectedValue = "1003";
            DropDownList1.Items.Insert(0, new ListItem("Select", ""));
            DropDownList1.Enabled = false;

               
            
          }
            MaxCode("2");
        }
        else
        {
            
            htParam.Add("@flag", "3");
            lblrlSetKy.Text = "Reward Code";
            lblRuleSetKeyDesc.Text = "Reward Description";
            txtRuleSetKeyDsc.Attributes.Add("placeholder", "Reward Description");
            divKPILinkage.Visible = true;
            FillDropDowns(ddlKPILinkage, "42"); 
          //  txtKPILinkage.Visible = true;
            lnkrwddsc.Visible = false;
            divScore.Visible = false;
                divParent.Visible = false; // <%--Added by prity on 23 aug 2018--%>
                DivAchtable.Visible = false;
            MaxCode("3");
        }

            
        
      
        htParam.Clear();
        ds.Clear();
        htParam.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        htParam.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        htParam.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            htParam.Add("@flag", "1");
            FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");
           // ddlParentRule_SelectedIndexChanged(null, null);
           // ddlKPI_Code.SelectedIndex = 0;
        }
        else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        {
            htParam.Add("@flag", "2");
        }
        else
        {
            htParam.Add("@flag", "3");
        }
        htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            gvAddMst.DataSource = ds;
            gvAddMst.DataBind();
            divAuditTrail.Visible = true;

            if (gvAddMst.PageCount > Convert.ToInt32(txtpage.Text))
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }

            if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
            {//rule set key
                gvAddMst.Columns[0].Visible = false;
                gvAddMst.Columns[1].Visible = false;
                gvAddMst.Columns[2].Visible = true;
                gvAddMst.Columns[3].Visible = false;
                gvAddMst.Columns[4].Visible = true;
                gvAddMst.Columns[5].Visible = true;
                gvAddMst.Columns[6].Visible = true;
                gvAddMst.Columns[7].Visible = true;
                gvAddMst.Columns[8].Visible = true;
                gvAddMst.Columns[9].Visible = true;
                gvAddMst.Columns[10].Visible = false;
                gvAddMst.Columns[11].Visible = false;
                gvAddMst.Columns[12].Visible = false;
                gvAddMst.Columns[13].Visible = false;
                gvAddMst.Columns[14].Visible = false;
                    gvAddMst.Columns[15].Visible = false;
                    gvAddMst.Columns[16].Visible = false;

                    gvAddMst.Columns[18].Visible = false;
                    gvAddMst.Columns[17].Visible = false;
                divrul.Style.Add("display", "none");
            }
            else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
            {//add category
                gvAddMst.Columns[0].Visible = false;
                gvAddMst.Columns[1].Visible = false;
                gvAddMst.Columns[2].Visible = false;
                gvAddMst.Columns[3].Visible = false;
                gvAddMst.Columns[4].Visible = true;
                 gvAddMst.Columns[5].Visible = false;
                 gvAddMst.Columns[6].Visible = false;
                gvAddMst.Columns[7].Visible = false;//rule method
                gvAddMst.Columns[8].Visible = false;
                gvAddMst.Columns[9].Visible = false;
                gvAddMst.Columns[10].Visible = true;
                gvAddMst.Columns[11].Visible = true;
                gvAddMst.Columns[13].Visible = false;
                gvAddMst.Columns[12].Visible = false;
                gvAddMst.Columns[14].Visible = false;
                gvAddMst.Columns[15].Visible = true;
                gvAddMst.Columns[16].Visible = true;
                gvAddMst.Columns[17].Visible = true;
                gvAddMst.Columns[18].Visible = false;
                gvAddMst.Columns[19].Visible = false;
                divrul.Style.Add("display", "block");
            }
            else
            {//reward
                gvAddMst.Columns[1].Visible = false;
                gvAddMst.Columns[0].Visible = true;
                gvAddMst.Columns[2].Visible = false;
                gvAddMst.Columns[3].Visible = false;
                gvAddMst.Columns[4].Visible = false;
                gvAddMst.Columns[5].Visible = false;
                gvAddMst.Columns[6].Visible = false;
                gvAddMst.Columns[7].Visible = false;
                gvAddMst.Columns[8].Visible = false;
                gvAddMst.Columns[9].Visible = false;
                gvAddMst.Columns[10].Visible = false;
                gvAddMst.Columns[11].Visible = false;
                gvAddMst.Columns[12].Visible = true;
                gvAddMst.Columns[13].Visible = true;
               gvAddMst.Columns[14].Visible = false;
                gvAddMst.Columns[15].Visible = false;
                gvAddMst.Columns[16].Visible = false;
               gvAddMst.Columns[17].Visible = false;
               gvAddMst.Columns[18].Visible = true;
               gvAddMst.Columns[19].Visible = false;
               // gvAddMst.Columns[14].Visible = false;
                divrul.Style.Add("display", "none");
            }
            
        }
        else
        {
            divAuditTrail.Visible = false;
            txtpage.Text = "1";
            btnpre.Enabled = false;
            btnnext.Enabled = false;
        }
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "GetPageDtls", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    //protected void FillDropDowns(DropDownList ddl, string val, string yrtyp, string typflg)
    //{
    //    try
    //    {
    //        ddl.Items.Clear();
    //        Hashtable ht = new Hashtable();
    //        ht.Add("@Flag", val.ToString().Trim());
    //        if (yrtyp != "")
    //        {
    //            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
    //        }
    //        ht.Add("@TYPFLG", typflg.ToString().Trim());
    //        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
    //        if (drRead.HasRows)
    //        {
    //            ddl.DataSource = drRead;
    //            ddl.DataTextField = "DESC01";
    //            ddl.DataValueField = "CODE";
    //            ddl.DataBind();
    //        }
    //        drRead.Close();
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

    private string  GetSTRACCYEAR()
    {
        DataSet dsCmpCode = new DataSet();
        dsCmpCode.Clear();


        string strACC_YEAR = "";
        Hashtable HTCmpCode = new Hashtable();
        HTCmpCode.Clear();


        HTCmpCode.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString());

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


    protected void btnBlkCatgUpd_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlRuleSetKy.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Key')", true);
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "funPopupDataSynchHybrid('" + lblCompCodeVal.Text.ToString().Trim() + "','" + lblCntstCdVal.Text.Trim() + "','"
            + txtRulSetDsc.Text.ToString().Trim() + "','"+txtRuleSetKey.Text.ToString().Trim()+"');", true);

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btnBlkCatgUpd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        if (txtRuleSetKeyDsc.Text == "")
        {
            if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdRule")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the Reward description')", true);
                return;
            }
            else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the Category description')", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the Rule Set Key description')", true);
                return;
            }

        }
        

        #region savereward
        ds.Clear();
        htParam.Clear();
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")//Add rule set popup
        {
            if(ddlRuleMethod.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Method')", true);
                return;
            }

            //if (ddlRulComplexity.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Complexity')", true);
            //    return;
            //}
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
            htParam.Add("@RULE_CODE", txtRuleSetKey.Text.Trim());
            htParam.Add("@RuleCodeDesc", txtRuleSetKeyDsc.Text.Trim());
            htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        //ADDED BY AJAY SAWANT
            htParam.Add("@RuleMethod",ddlRuleMethod.SelectedValue.ToString());
            htParam.Add("@ACCRUAL_ACC_CYCLE", ddlAccrCyc.SelectedValue.ToString());
            htParam.Add("@ACC_CYCLE", ddlAccCyc.SelectedValue.ToString());
            htParam.Add("@RWRD_REL_CYCLE ", ddlRwdRlsCyc.SelectedValue.ToString());
            htParam.Add("@RWD_CMP_CYCLE ", ddlRewardComputation.SelectedValue.ToString());

            htParam.Add("@TRG_CATG_RUL_CLASS", ddlRuleType.SelectedValue.ToString());
            htParam.Add("@RWD_RUL_CLASS", ddlRuleClass.SelectedValue.ToString());
            htParam.Add("@RUL_SET_CMPLXTY", ddlRulComplexity.SelectedValue.ToString());

            strACC_YEAR = GetSTRACCYEAR();
            if (strACC_YEAR == "1003")
          {
                if (ddlMEM_ACH_ACC_CYCLE.SelectedValue.ToString()=="")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Member Achievement Accumulation Cycle ')", true);
                    return;
                }
                if (ddlMEM_RWD_CMP_CYCLE.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Member Reward Computation Cycle')", true);
                    return;
                }
                if (ddlMEM_RWD_REL_CYCLE.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Member Reward Release Cycle ')", true);
                    return;
                }

               
                htParam.Add("@IS_RUL_STR_FRM_MO", cycleM0.SelectedValue.ToString());
                htParam.Add("@IS_MO_MRG_IN_M1", rdoseparate.SelectedValue.ToString());

                htParam.Add("@MEM_ACH_ACC_CYCLE", ddlMEM_ACH_ACC_CYCLE.SelectedValue.ToString());
                htParam.Add("@MEM_RWD_CMP_CYCLE", ddlMEM_RWD_CMP_CYCLE.SelectedValue.ToString());
                htParam.Add("@MEM_RWD_REL_CYCLE", ddlMEM_RWD_REL_CYCLE.SelectedValue.ToString());
            }


			 if (ddlRuleType.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Target Member Rule Class ')", true);
                    return;
                }
				
				if (ddlRuleClass.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Reward  Member Rule Class ')", true);
                    return;
                }
            if (ddlParentRule.SelectedIndex!=0)
          {
             
              htParam.Add("@PARENT_RULESECODE",ddlParentRule.SelectedValue.ToString() ); //@PARENT_RULESETDesc

              string[] PARENT = ddlParentRule.SelectedItem.ToString().Split('-');
              string PARENT_RULESECODE = PARENT[0];
              string PARENT_RULESETDesc = PARENT[1];
              htParam.Add("@PARENT_RULESETDesc", PARENT_RULESETDesc);
           //   htParam.Add("@PARENT_RULESECODE", PARENT_RULESECODE);
          }
          else
          {
              htParam.Add("@PARENT_RULESECODE", "");   

          }
          
                htParam.Add("@PARENT_CMPNSTN_CODE", ddlPcmpCode.SelectedValue.ToString());
                htParam.Add("@PARENT_CNTST_CODE", ddlPCntCode.SelectedValue.ToString());
                if (ddlAch.SelectedIndex != 0)
                {
                    htParam.Add("@ACH_TABLE", ddlAch.SelectedValue.ToString());
                }



                if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
                {

                    htParam.Add("@OPERATOR", ddlOperator.SelectedValue.ToString());
                }

                else
                {
                    htParam.Add("@OPERATOR", "");
                }
                if (ddlMemhierusdate.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Hierarchy Use date')", true);
                    return;
                }
                else
                {
                    htParam.Add("@MEM_HST_FLG", ddlMemhierusdate.SelectedValue.ToString().Trim());
                }
                ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRuleSetCodeMst", htParam);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved successfully')", true);
                    ddlRuleMethod.SelectedIndex = 0;
                    txtRuleSetKeyDsc.Text = "";
                    ddlMEM_RWD_REL_CYCLE.SelectedIndex = 0;
                    ddlMEM_ACH_ACC_CYCLE.SelectedIndex = 0;
                    ddlMEM_RWD_CMP_CYCLE.SelectedIndex = 0;
                    cycleM0.SelectedIndex = -1;
                    rdoseparate.SelectedIndex = -1;

                  
                   
                
                GetPageDtls();

        }
        else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")//add category pop up
        {
            if (txtScorefrom.Text == "" && hdnIsValid.Value=="W")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Weighted Score From ')", true);
                return;
            }


            if (txtScoreTo.Text == "" && hdnIsValid.Value=="W")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Weighted Score To ')", true);
                return;
            }
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
            htParam.Add("@RulSetKy", txtRulSetDsc.Text.Trim());
            htParam.Add("@Catg_CODE", txtRuleSetKey.Text.Trim());
            htParam.Add("@CatgCodeDesc", txtRuleSetKeyDsc.Text.Trim());
            htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            htParam.Add("@WScore_From", txtScorefrom.Text.Trim());
            htParam.Add("@WScore_To", txtScoreTo.Text.Trim());

            strACC_YEAR = GetSTRACCYEAR();
            if (strACC_YEAR == "1003")
            {
                    if(ddlParentCategory.SelectedIndex==0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Cycle ')", true);
                        return;
                    }
                htParam.Add("@RULE_CODE", ddlParentCategory.SelectedValue.ToString().Trim());
                htParam.Add("@Accu_year", DropDownList1.SelectedValue.ToString().Trim());

            }

            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsCatgryCodeMst", htParam);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved successfully')", true);
                txtRuleSetKeyDsc.Text = "";
                GetPageDtls();
               
        }
        else
        {
            htParam.Add("@CMPNSTN_CODE", lblCompCodeVal.Text.Trim());
            htParam.Add("@CNTSTNT_CODE", lblCntstCdVal.Text.Trim());
            htParam.Add("@RWD_CODE", txtRuleSetKey.Text.Trim());
            htParam.Add("@RWDCodeDesc", txtRuleSetKeyDsc.Text.Trim());
            htParam.Add("@RULE_TYPE", Request.QueryString["ruletype"].ToString().Trim());
            htParam.Add("@UserId", Session["UserID"].ToString().Trim());
            htParam.Add("@LNKD_DRVD_KPI_CODE", ddlKPILinkage.SelectedValue.ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_InsRWDCodeMst", htParam);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data Saved successfully')", true);
                txtRuleSetKeyDsc.Text = "";
                GetPageDtls();
            
        }

        //htParam.Clear();
        //ds.Clear();
        //htParam.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        //htParam.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        //htParam.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        //if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //{
        //    htParam.Add("@flag", "1");
        //}
        //else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //{
        //    htParam.Add("@flag", "2");
        //}
        //else
        //{
        //    htParam.Add("@flag", "3");
        //}
        //htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        //ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htParam);
        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    gvAddMst.DataSource = ds;
        //    gvAddMst.DataBind();
        //    divAuditTrail.Visible = true;
        //    if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        //    {
        //        gvAddMst.Columns[2].Visible = false;
        //        gvAddMst.Columns[3].Visible = true;
        //        gvAddMst.Columns[4].Visible = false;
        //        gvAddMst.Columns[5].Visible = false;
        //        gvAddMst.Columns[6].Visible = false;
        //        gvAddMst.Columns[7].Visible = false;
        //        gvAddMst.Columns[8].Visible = false;
        //        gvAddMst.Columns[8].Visible = false;
        //        gvAddMst.Columns[10].Visible = false;
        //        gvAddMst.Columns[11].Visible = false;

        //    }
        //    else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        //    {
        //        gvAddMst.Columns[2].Visible = false;
        //        gvAddMst.Columns[3].Visible = false;
        //        gvAddMst.Columns[4].Visible = true;
        //        gvAddMst.Columns[5].Visible = false;
        //        gvAddMst.Columns[6].Visible = false;
        //        gvAddMst.Columns[7].Visible = true;
        //        gvAddMst.Columns[8].Visible = false;
        //        gvAddMst.Columns[9].Visible = false;
        //    }
        //    else
        //    {
        //        gvAddMst.Columns[2].Visible = false;
        //        gvAddMst.Columns[3].Visible = false;
        //        gvAddMst.Columns[4].Visible = false;
        //        gvAddMst.Columns[5].Visible = false;
        //        gvAddMst.Columns[6].Visible = false;
        //        gvAddMst.Columns[7].Visible = false;
        //        gvAddMst.Columns[8].Visible = true;
        //        gvAddMst.Columns[9].Visible = true;
        //    }

        //}
        //else
        //{
        //    divAuditTrail.Visible = false;
        //}

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "doCancel('" + value.ToString().Trim() + "');", true);
        #endregion
            
           
        txtScorefrom.Text = "";
        txtScoreTo.Text = "";
           
         

           
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btnSave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
        GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
        Label lnkCompCode = (Label)row.FindControl("lnkCompCode");
        Label lblCntstCode = (Label)row.FindControl("lblCntstCode");
        Label lblRuleSetCode = (Label)row.FindControl("lblRuleSetCode");
        Label lblRuleSetDesc = (Label)row.FindControl("lblRuleSetDesc");
        Label lblCategoryCode = (Label)row.FindControl("lblCategoryCode");
        Label lblCategoryDesc = (Label)row.FindControl("lblCategoryDesc");
        Label lblRWRDCode = (Label)row.FindControl("lblRWRDCode");
        Label lblRWRDDesc = (Label)row.FindControl("lblRWRDDesc");
        HiddenField lblRuleMethod = (HiddenField)row.FindControl("hdnRuleMethod");
        Label lblWScoreFrom = (Label)row.FindControl("lblWScoreFrom");
        Label lblWScoreTo = (Label)row.FindControl("lblWScoreTo");
        HiddenField hdnRULE_CODE = (HiddenField)row.FindControl("hdnRULE_CODE");
        Label lblPRulSetCode = (Label)row.FindControl("lblPRulSetCode");
        Label lblPRuleSetDesc = (Label)row.FindControl("lblPRuleSetDesc");
            HiddenField hdnPARENT_KPICODE = (HiddenField)row.FindControl("hdnPARENT_KPICODE");//

            HiddenField hdnPARENT_CMPNSTN_CODE = (HiddenField)row.FindControl("hdnPARENT_CMPNSTN_CODE");
            HiddenField hdnPARENT_CNTST_CODE = (HiddenField)row.FindControl("hdnPARENT_CNTST_CODE");

        HiddenField hdnMEM_ACH_ACC_CYCLE = (HiddenField)row.FindControl("hdnMEM_ACH_ACC_CYCLE");
        HiddenField hdnMEM_RWD_CMP_CYCLE = (HiddenField)row.FindControl("hdnMEM_RWD_CMP_CYCLE");
        HiddenField hdnMEM_RWD_REL_CYCLE = (HiddenField)row.FindControl("hdnMEM_RWD_REL_CYCLE");

        HiddenField hdnACCRUAL_ACC_CYCLE = (HiddenField)row.FindControl("hdnACCRUAL_ACC_CYCLE");
        HiddenField hdnRWD_CMP_CYCLE = (HiddenField)row.FindControl("hdnRWD_CMP_CYCLE");
        HiddenField hdnRWRD_REL_CYCLE = (HiddenField)row.FindControl("hdnRWRD_REL_CYCLE");
        HiddenField hdnACC_CYCLE = (HiddenField)row.FindControl("hdnACC_CYCLE");
            HiddenField hdnOperator = (HiddenField)row.FindControl("hdnOperator");
            HiddenField hdnAchTbl = (HiddenField)row.FindControl("hdnAchTbl");

            Label lblLNKD_DRVD_KPI_DESC = (Label)row.FindControl("lblLNKD_DRVD_KPI_DESC");
            HiddenField hdnLNKD_DRVD_KPI_CODE = (HiddenField)row.FindControl("hdnLNKD_DRVD_KPI_CODE");

            //Label lblRUL_SET_CMPLXTY_DESC = (Label)row.FindControl("lblRUL_SET_CMPLXTY_DESC");
            HiddenField hdnRUL_SET_CMPLXTY = (HiddenField)row.FindControl("hdnRUL_SET_CMPLXTY");

            HiddenField hdnTRG_CATG_RUL_CLASS = (HiddenField)row.FindControl("hdnTRG_CATG_RUL_CLASS");
            HiddenField hdnRWD_RUL_CLASS = (HiddenField)row.FindControl("hdnRWD_RUL_CLASS");


            HiddenField hdnIS_STR_RUL_FRM_FLAG = (HiddenField)row.FindControl("hdnIS_STR_RUL_FRM_FLAG");
            HiddenField hdnIS_STR_RUL_FRM = (HiddenField)row.FindControl("hdnIS_STR_RUL_FRM");

            Label lblMemhstflg = (Label)row.FindControl("lblMemhstflg");

            string parentRule = lblPRulSetCode.Text.ToString() + "-" +lblPRuleSetDesc.Text.ToString();

        lblCompCodeVal.Text = lnkCompCode.Text;
        lblCntstCdVal.Text = lblCntstCode.Text;

        txtScorefrom.Text = lblWScoreFrom.Text;
        txtScoreTo.Text = lblWScoreTo.Text;

        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            txtRuleSetKey.Text = lblRuleSetCode.Text;
            txtRuleSetKeyDsc.Text = lblRuleSetDesc.Text;
           
               
   
               
                FillParentCmpnstnCode(ddlPcmpCode, "Prc_FillParentCmpnstnCode");
                ddlPcmpCode.SelectedValue = hdnPARENT_CMPNSTN_CODE.Value;
                FillParentCnstntCode(ddlPCntCode, "Prc_FillParentCnstntCode");
                ddlPCntCode.SelectedValue = hdnPARENT_CNTST_CODE.Value;

               FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");
           
            ddlParentRule.SelectedValue = lblPRulSetCode.Text.ToString();
            //ddlParentRule_SelectedIndexChanged(sender,e);
                
            FillKPI(ddlKPI_Code, lblPRulSetCode.Text.ToString());
            ddlKPI_Code.SelectedValue = hdnPARENT_KPICODE.Value;
            FillDropDowns(ddlAccrCyc, "8", "", "");
            FillDropDowns(ddlAccCyc, "8", "", "");
                FillDropDowns(ddlOperator, "40");
                FillAchievementTable(ddlAch, "Prc_FillAchievementTable");
           
           
                ddlRuleMethod.SelectedValue = lblRuleMethod.Value;
                ddlAch.SelectedValue = hdnAchTbl.Value;
               

              FillDropDowns(ddlRuleType, "41");
                ddlRuleType.SelectedValue = hdnTRG_CATG_RUL_CLASS.Value;

                ddlRuleClass.SelectedValue = hdnRWD_RUL_CLASS.Value;

              

                FillDropDowns(ddlRulComplexity, "43");

                ddlRulComplexity.SelectedValue = hdnRUL_SET_CMPLXTY.Value;


                if (ddlPcmpCode.SelectedIndex != 0 && ddlPCntCode.SelectedIndex != 0 && ddlParentRule.SelectedIndex != 0)
                {
                    lblRulCmpx.Visible = true;
                    ddlRulComplexity.Visible = true;
                }
                else
                {
                    lblRulCmpx.Visible = false;
                    ddlRulComplexity.Visible = false;
                }
                if (lblRuleMethod.Value == "O")
                {
                    ddlOperator.SelectedValue = hdnOperator.Value;
                    ddlPCntCode.SelectedIndex = 0;
                    ddlPcmpCode.SelectedIndex = 0;
                    divOperator.Visible = true;
                    divDsgnTsk.Visible = true;
                    // gvDsgnTsk.Visible = true;
                    divDsgnTskHdng.Visible = true;
                    //DesignGridBind(); commented by Abuzar on 16042021
                    //ddlRuleMethod_SelectedIndexChanged(null,null);
                    DesignGridBindedit();
                }
                else
                {
                   
                    divOperator.Visible = false;
                    divDsgnTsk.Visible = false;
                    //gvDsgnTsk.Visible = false;
                    divDsgnTskHdng.Visible = false;   

                    
                }

            ddlMEM_RWD_CMP_CYCLE.SelectedValue = hdnMEM_RWD_CMP_CYCLE.Value;
            ddlMEM_ACH_ACC_CYCLE.SelectedValue = hdnMEM_ACH_ACC_CYCLE.Value;
            ddlMEM_RWD_REL_CYCLE.SelectedValue = hdnMEM_RWD_REL_CYCLE.Value;

          if (MoCycle.Visible == true)
            {
                cycleM0.SelectedValue = hdnIS_STR_RUL_FRM_FLAG.Value;

                cycleM0_SelectedIndexChanged(null, null);

                if (hdnIS_STR_RUL_FRM_FLAG.Value == "Y")
                {
                    rdoseparate.SelectedValue = hdnIS_STR_RUL_FRM.Value;

                    rdoseparate_SelectedIndexChanged(null, null);
                }
               
            
            }

           
            ddlAccCyc.SelectedValue = hdnACC_CYCLE.Value;
                if (hdnACC_CYCLE.Value == "1009")
                {
                    btncycle.Visible = true;
                }
                else
                {
                    btncycle.Visible = false;
                }
            ddlAccrCyc.SelectedValue = hdnACCRUAL_ACC_CYCLE.Value;


            FillRwdRlsCyc(ddlRwdRlsCyc, "22", "");
            FillRwdRlsCyc(ddlRewardComputation, "22", "");
            ddlRwdRlsCyc.SelectedValue = hdnRWRD_REL_CYCLE.Value;
            ddlRewardComputation.SelectedValue = hdnRWD_CMP_CYCLE.Value;

            ddlMemhierusdate.SelectedValue = lblMemhstflg.Text;

        }
        else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
        {
            txtRuleSetKey.Text = lblCategoryCode.Text;
            txtRuleSetKeyDsc.Text = lblCategoryDesc.Text;
            ddlParentCategory.SelectedValue = hdnRULE_CODE.Value;

        }
        else
        {
            FillDropDowns(ddlKPILinkage, "42");
            txtRuleSetKey.Text = lblRWRDCode.Text;
            txtRuleSetKeyDsc.Text = lblRWRDDesc.Text;
            ddlKPILinkage.SelectedValue = hdnLNKD_DRVD_KPI_CODE.Value;
          
        }

    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "lnkEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //Bhaurao Added
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
        string msg;
       GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
       //var rulesetkey = gvAddMst.DataKeys[row.RowIndex].Value.ToString();
        Label lblRuleSetCode = (Label)row.FindControl("lblRuleSetCode");
        Label lblCategoryCode = (Label)row.FindControl("lblCategoryCode");
        Label lblRWRDCode = (Label)row.FindControl("lblRWRDCode");
        
        
       
       htParam.Add("@cmp_code", lblCompCodeVal.Text.Trim());
       htParam.Add("@cntst_code", lblCntstCdVal.Text.Trim());
       htParam.Add("@ruleType", Request.QueryString["ruletype"].ToString().Trim());
       if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
       {
           htParam.Add("@RuleSetCode", lblRuleSetCode.Text.Trim());
           htParam.Add("@flag", 1);
          
       }
       else if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdTrgt")
       {
           htParam.Add("@catg_code", lblCategoryCode.Text.Trim());
           htParam.Add("@flag", 2);
          
       }
       else
       {
          
           htParam.Add("@catg_code", lblCategoryCode.Text.Trim());
           htParam.Add("@rwrd_code", lblRWRDCode.Text.Trim());
           htParam.Add("@flag", 3);
          
       }
       ds = objDal.DelDataSetForPrc_SAIM("Prc_DelRuleSetCodeMst", htParam);
       if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
       {
           msg = ds.Tables[0].Rows[0]["Result"].ToString().Trim();
           if (msg == "NO DELETE")
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot Delete the Rule Set Key');", true);
           }
       }
       GetPageDtls();
       
        int pageIndex = gvAddMst.PageIndex;
       if (pageIndex == 1)
       {
           txtpage.Text = "2";
           btnpre.Enabled = true;
           btnnext.Enabled = true;

       }
       else
       {
           txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
           btnpre.Enabled = true;
           btnnext.Enabled = true;

       }
       if (pageIndex == 0)
       {
           txtpage.Text = "1";
           btnpre.Enabled = false;
           btnnext.Enabled = false;

       }

       GetPageDtls();
        //gvAddMst.DataSource = ds.Tables[];
        //gvAddMst.DataBind();
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "lnkDelete_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {

            // int pageIndex = gvAddMst.PageIndex;
            // gvAddMst.PageIndex = pageIndex + 1;
            //// BindRevHistGrid(lblCompCodeVal.Text.ToString());

            // txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) + 1);
            // btnpre.Enabled = true;
            // GetPageDtls();
            // int page = gvAddMst.PageCount;
            // if (txtpage.Text == Convert.ToString(gvAddMst.PageCount))
            // {
            //     btnnext.Enabled = false;
            //     btnpre.Enabled = false;
            // }
            // else
            // {
            //     btnnext.Enabled = true;
            //     btnpre.Enabled = true;
            // }

            int pageIndex = gvAddMst.PageIndex;
            gvAddMst.PageIndex = pageIndex + 1;
            GetPageDtls();
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) + 1);
            btnpre.Enabled = true;
            if (txtpage.Text == Convert.ToString(gvAddMst.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gvAddMst.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnpre_Click(object sender, EventArgs e)
    {
        try
        {
            //int pageIndex = gvAddMst.PageIndex;
            //gvAddMst.PageIndex = pageIndex - 1;

            ////BindRevHistGrid(lblCompCodeVal.Text.ToString());
            //txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
            //if (txtpage.Text == "1")
            //{
            //    btnpre.Enabled = false;
            //}
            //else
            //{
            //    btnnext.Enabled = true;
            //}
            //btnnext.Enabled = true;
            int pageIndex = gvAddMst.PageIndex;
            gvAddMst.PageIndex = pageIndex - 1;
            GetPageDtls();
            //  BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            //BindRevHistGrid(lblCompCodeVal.Text.ToString());
            txtpage.Text = Convert.ToString(Convert.ToInt32(txtpage.Text) - 1);
            if (txtpage.Text == "1")
            {
                btnpre.Enabled = false;
            }
            else
            {
                btnpre.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "btnpre_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    //protected void ShowMembecycle()
    //{
    //  DataSet  dsNEWCat = new DataSet();
    //  dsNEWCat.Clear();

    //  Hashtable HTCat = new Hashtable();
    //  HTCat.Clear();


    //  HTCat.Add("@LookupCode", "MemCycle");

    //  dsNEWCat = objDal.GetDataSetForPrc_SAIM("Prc_GetLookUpValue", HTCat);
    //    if (dsNEWCat.Tables.Count > 0 && dsNEWCat.Tables[0].Rows.Count > 0)
    //    {
    //        ddlParentCategory.DataSource = dsNEWCat;
    //        ddlParentCategory.DataTextField = "ParamDesc1";
    //        ddlParentCategory.DataValueField = "ParamValue";
    //        ddlParentCategory.DataBind();
    //    }
    //    ddlParentCategory.Items.Insert(0, new ListItem("Select", ""));

    //}

    protected void ShowMembecycle()
    {
      DataSet  dsNEWCat = new DataSet();
      dsNEWCat.Clear();

      Hashtable HTCat = new Hashtable();
      HTCat.Clear();


        HTCat.Add("@CmpstnCode", lblCompCodeVal.Text.Trim());
        HTCat.Add("@CntstCode", lblCntstCdVal.Text.Trim());
        HTCat.Add("@RuleSetCode", ddlRuleSetKy.SelectedValue.ToString().Trim());



        dsNEWCat = objDal.GetDataSetForPrc_SAIM("Prc_GetMemberAccCycle", HTCat);
        if (dsNEWCat.Tables.Count > 0 && dsNEWCat.Tables[0].Rows.Count > 0)
        {
            ddlParentCategory.DataSource = dsNEWCat;
            ddlParentCategory.DataTextField = "BUSI_DESC";
            ddlParentCategory.DataValueField = "BUSI_CODE";
            ddlParentCategory.DataBind();
        }
        ddlParentCategory.Items.Insert(0, new ListItem("Select", ""));

    }


    #region ShowRulStKy
    protected void ShowRulStKy()
    {
        try
        {
        ds = new DataSet();
        ds.Clear();
        htParam.Clear();
        htParam.Add("@flag", "6");
        if (Request.QueryString["CmpCode"] != null)
        {
            htParam.Add("@CompCode", Request.QueryString["CmpCode"].ToString().Trim());
        }
        if (Request.QueryString["CntstCode"] != null)
        {
            htParam.Add("@CntstCode", Request.QueryString["CntstCode"].ToString().Trim());
        }
        if (Request.QueryString["ruletype"] != null)
        {
            htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        }
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetValues", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRuleSetKy.DataSource = ds;
            ddlRuleSetKy.DataTextField = "RULE_SET_KEY_DESC";
            ddlRuleSetKy.DataValueField = "RULE_SET_KEY";
            ddlRuleSetKy.DataBind();
        }
        ddlRuleSetKy.Items.Insert(0, new ListItem("Select", ""));
    }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ShowRulStKy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    #endregion

    protected void ddlRuleSetKy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        txtRulSetDsc.Text = ddlRuleSetKy.SelectedValue.ToString();
        txtRulSetDsc.Enabled = false;
        GetPageDtls();
        CheckIsWeighted();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlRuleSetKy_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    
    }

    //added by ajay sawant
    protected void ddlParentRule_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //divparentkpi.Visible = true;
            FillKPI(ddlKPI_Code, ddlParentRule.SelectedValue.ToString());

            if (ddlPcmpCode.SelectedIndex != 0 && ddlPCntCode.SelectedIndex != 0 && ddlParentRule.SelectedIndex != 0)
            {
                lblRulCmpx.Visible = true;
                ddlRulComplexity.Visible = true;
            }
            else
            {
                lblRulCmpx.Visible = false;
                ddlRulComplexity.Visible = false;
            }
           // ddlParentRule.Items.Insert(0, new ListItem("Select", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlParentRule_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

    protected void ddlRulComplexity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            //if (ddlRulComplexity.SelectedValue.ToString() == "CL")
            //{
            //    DesignGridBind();
            //    divDsgnTskHdng.Visible = true;
            //    divDsgnTsk.Visible = true;
            //    lnkAddMP.Visible = true;
            //    btnSave.Visible = false;
            //}
            //else
            //{
                
            //    divDsgnTskHdng.Visible = false ;
            //    divDsgnTsk.Visible = false ;
            //    lnkAddMP.Visible = false;
            //    btnSave.Visible = true ;
            //}
            // ddlParentRule.Items.Insert(0, new ListItem("Select", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlRulComplexity_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void gvDsgnTsk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            //    LinkButton lnkEditRwdTrg = (LinkButton)e.Row.FindControl("lnkEditRwdTrg");
            //    LinkButton lnkDelRwdTrg = (LinkButton)e.Row.FindControl("lnkDelRwdTrg");
            //    LinkButton lnkKPITrgtSetRule = (LinkButton)e.Row.FindControl("lnkKPITrgtSetRule");

                 DropDownList DropDownList1 = (e.Row.FindControl("ddlAchGv") as DropDownList);
                // FillAchievementTable(DropDownList1, "");


                 DropDownList1.Items.Clear();
                 Hashtable ht = new Hashtable();
                 DataSet dsP = new DataSet();
                 dsP.Clear();
                 ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());

                 dsP = objDal.GetDataSetForPrc_SAIM("Prc_FillAchievementTable", ht);

                 if (dsP.Tables.Count > 0 && dsP.Tables[0].Rows.Count > 0)
                 {


                     DropDownList1.DataSource = dsP;
                     DropDownList1.DataTextField = "ACH_Desc";
                     DropDownList1.DataValueField = "ACH_Code";
                     DropDownList1.DataBind();
                 }

                 DropDownList1.Items.Insert(0, new ListItem("-- SELECT --", ""));



            }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "gvDsgnTsk_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void DesignGridBind()
    {
        Hashtable htDt = new Hashtable();
        DataSet dsDt = new DataSet();
        htDt.Clear();
        dsDt.Clear();
        htDt.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        htDt.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        htDt.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            htDt.Add("@flag", "1");
            //FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");

            // ddlKPI_Code.SelectedIndex = 0;/
        }

        htDt.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        dsDt = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htDt);
        if (dsDt.Tables.Count > 0 && dsDt.Tables[0].Rows.Count > 0)
        {


            gvDsgnTsk.DataSource = dsDt;
            gvDsgnTsk.DataBind();
            //            divAuditTrail.Visible = true;

        }

        gvDsgnTsk.Columns[0].Visible = true;
        gvDsgnTsk.Columns[1].Visible = false;
        gvDsgnTsk.Columns[2].Visible = false;
        gvDsgnTsk.Columns[4].Visible = false;
        gvDsgnTsk.Columns[7].Visible = false;
        gvDsgnTsk.Columns[8].Visible = true;
        gvDsgnTsk.Columns[9].Visible = false;
        gvDsgnTsk.Columns[10].Visible = false;
        gvDsgnTsk.Columns[11].Visible = false;
        gvDsgnTsk.Columns[12].Visible = false;
        gvDsgnTsk.Columns[13].Visible = false;
        gvDsgnTsk.Columns[14].Visible = false;
        gvDsgnTsk.Columns[15].Visible = false;

        if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else if (ddlRulComplexity.SelectedValue.ToString().Trim() == "CL")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else
        { gvDsgnTsk.Columns[17].Visible = false; }





    }
    protected void  ddlRuleMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
            {
                ddlPcmpCode.SelectedIndex = 0;
                ddlPcmpCode.Enabled = false;

                ddlPCntCode.SelectedIndex = 0;
                ddlPCntCode.Enabled = false;

                ddlParentRule.SelectedIndex = 0;
                ddlParentRule.Enabled = false;

                divDsgnTskHdng.Visible = true;
                divDsgnTsk.Visible = true;
               btnSave.Visible = false;
                lnkAddMP.Visible = true;
                divOperator.Visible = true;
              // btnAdd.Visible = true;

                FillAchievementTable(ddlAch, "Prc_FillAchievementTable");
                //DesignGridBind(); commented by Abuzar on 16042021

                //Added by Abuzar on 16042021
                DesignGridBindselectindexchange();



            }
            else
            {
                lnkAddMP.Visible = false;
                ddlPcmpCode.Enabled = true;
                divOperator.Visible = false;

                //    ddlPCntCode.SelectedIndex = 0;
                ddlPCntCode.Enabled = true;

                //  ddlParentRule.SelectedIndex = 0
                ddlParentRule.Enabled = true;
                divDsgnTskHdng.Visible = false;
                divDsgnTsk.Visible = false;
                btnSave.Visible = true;
                btnAdd.Visible = false;
            }

           
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlRuleMethod_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }

//Added by Abuzar on 16042021 starts
    public void DesignGridBindselectindexchange()
    {
        Hashtable htDt = new Hashtable();
        DataSet dsDt = new DataSet();
        htDt.Clear();
        dsDt.Clear();
        htDt.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        htDt.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        htDt.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            htDt.Add("@flag", "4");
            //FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");

            // ddlKPI_Code.SelectedIndex = 0;/
        }

        htDt.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        dsDt = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htDt);
        if (dsDt.Tables.Count > 0 && dsDt.Tables[0].Rows.Count > 0)
        {


            gvDsgnTsk.DataSource = dsDt;
            gvDsgnTsk.DataBind();
            //            divAuditTrail.Visible = true;

        }

        gvDsgnTsk.Columns[0].Visible = true;
        gvDsgnTsk.Columns[1].Visible = false;
        gvDsgnTsk.Columns[2].Visible = false;
        gvDsgnTsk.Columns[4].Visible = false;
        gvDsgnTsk.Columns[7].Visible = false;
        gvDsgnTsk.Columns[8].Visible = true;
        gvDsgnTsk.Columns[9].Visible = false;
        gvDsgnTsk.Columns[10].Visible = false;
        gvDsgnTsk.Columns[11].Visible = false;
        gvDsgnTsk.Columns[12].Visible = false;
        gvDsgnTsk.Columns[13].Visible = false;
        gvDsgnTsk.Columns[14].Visible = false;
        gvDsgnTsk.Columns[15].Visible = false;

        if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else if (ddlRulComplexity.SelectedValue.ToString().Trim() == "CL")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else
        { gvDsgnTsk.Columns[17].Visible = false; }





    }
    public void DesignGridBindedit()
    {
        Hashtable htDt = new Hashtable();
        DataSet dsDt = new DataSet();
        htDt.Clear();
        dsDt.Clear();
        htDt.Add("@cmpcode", lblCompCodeVal.Text.Trim());
        htDt.Add("@cntstcode", lblCntstCdVal.Text.Trim());
        htDt.Add("@rulesetcd", txtRulSetDsc.Text.Trim());
        if (Request.QueryString["flag"].ToString().Trim() == "CntstRwdIndctr")
        {
            htDt.Add("@flag", "5");
            //FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");

            // ddlKPI_Code.SelectedIndex = 0;/
        }

        htDt.Add("@RuleType", Request.QueryString["ruletype"].ToString().Trim());
        dsDt = objDal.GetDataSetForPrc_SAIM("Prc_GetRWDRuleGrdDtls", htDt);
        if (dsDt.Tables.Count > 0 && dsDt.Tables[0].Rows.Count > 0)
        {


            gvDsgnTsk.DataSource = dsDt;
            gvDsgnTsk.DataBind();
            //            divAuditTrail.Visible = true;

        }

        gvDsgnTsk.Columns[0].Visible = true;
        gvDsgnTsk.Columns[1].Visible = false;
        gvDsgnTsk.Columns[2].Visible = false;
        gvDsgnTsk.Columns[4].Visible = false;
        gvDsgnTsk.Columns[7].Visible = false;
        gvDsgnTsk.Columns[8].Visible = true;
        gvDsgnTsk.Columns[9].Visible = false;
        gvDsgnTsk.Columns[10].Visible = false;
        gvDsgnTsk.Columns[11].Visible = false;
        gvDsgnTsk.Columns[12].Visible = false;
        gvDsgnTsk.Columns[13].Visible = false;
        gvDsgnTsk.Columns[14].Visible = false;
        gvDsgnTsk.Columns[15].Visible = false;

        if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else if (ddlRulComplexity.SelectedValue.ToString().Trim() == "CL")
        { gvDsgnTsk.Columns[17].Visible = false; }
        else
        { gvDsgnTsk.Columns[17].Visible = false; }





    }
    //Added by Abuzar on 16042021 ends

    //<%--Added by prity on 23 aug 2018--%>
    protected void FillParentCmpnstnCode(DropDownList ddl, string ProcName)
    {
        try
        {

            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillParentCmpnstnCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillParentCnstntCode(DropDownList ddl, string ProcName)
    {
        try
        {

            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@CMPNSTN_CODE", ddlPcmpCode.SelectedValue.ToString());
            ht.Add("@CNTSTNT_CODE", Request.QueryString["CmpCode"].ToString().Trim());
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
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillParentCnstntCode", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void FillAchievementTable(DropDownList ddl, string ProcName)
    {
        try
        {

            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            DataSet dsP = new DataSet();
            dsP.Clear();
            ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());

            dsP = objDal.GetDataSetForPrc_SAIM(ProcName, ht);

            if (dsP.Tables.Count > 0 && dsP.Tables[0].Rows.Count > 0)
            {

         
                ddl.DataSource = dsP;
                ddl.DataTextField = "ACH_Desc";
                ddl.DataValueField = "ACH_Code";
                ddl.DataBind();
            }
          
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "FillAchievementTable", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlPcmpCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillParentCnstntCode(ddlPCntCode, "Prc_FillParentCnstntCode");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlPcmpCode_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }


    protected void lnkAddPC_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtInput1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the possible combination')", true);
                return;
            }
            if (txtInput2.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter the output value')", true);
                return;
            }
            PCInsUpd("INS");
            PCInsUpd("SRCH");

           

            /////***

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "lnkAddPC_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkAddMP_Click(object sender, EventArgs e)
    {
        try
        {


            if (ddlRuleMethod.SelectedValue.ToString().Trim() == "O")
            {
                if (ddlOperator.SelectedValue.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select operator')", true);
                    return;
                }

                else
                {
                    //lnkAddPC_Click(sender,e);

                    btnAdd_Click(sender, e);
                    btnSave.Visible = true;
                }

            }
            else {
                btnAdd_Click(sender, e);
                btnSave.Visible = true;
            }

            /////***

        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "lnkAddMP_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void PCInsUpd(String val)
    {
        try
        {
            Hashtable htPc = new Hashtable();
            DataSet dsPc = new DataSet();

            htPc.Clear();
            dsPc.Clear();

            htPc.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
            htPc.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
            htPc.Add("@RULE_SET_KEY", txtRuleSetKey.Text.ToString());
            htPc.Add("@VALUE1", txtInput1.Text.ToString().Trim());
            htPc.Add("@VALUE2", txtInput2.Text.ToString().Trim());
            htPc.Add("@CREATED_BY", Session["UserID"].ToString().Trim());
            htPc.Add("@FLAG", val.ToString());

            dsPc = objDal.GetDataSetForPrc_SAIM("Prc_INS_OPRATNL_MAPPER", htPc);
            if (dsPc.Tables.Count > 0 && dsPc.Tables[0].Rows.Count > 0)
            {

                if (val == "SRCH")
                {
                    gvPrmtCmbn.DataSource = dsPc;
                    gvPrmtCmbn.DataBind();

                }
            }
            txtInput1.Text="";
            txtInput2.Text = "";
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "PCInsUpd", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
	
    protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
           if(ddlOperator.SelectedValue.ToString().Trim()=="PC")
           {
               divPCHeading.Visible = true;
               divPC.Visible = true;
               divPrmtCmbn.Visible = true;
               lnkAddPC.Visible = true;
               divIOPC.Visible = true;
               PCInsUpd("INS");
               PCInsUpd("SRCH");
			   divDsgnTskHdng.Visible=false;
              
           }
           else
           {
               lnkAddPC.Visible = true;
               divPCHeading.Visible = false;
               divPrmtCmbn.Visible = false;
               divIOPC.Visible = false;
           }
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlOperator_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void ddlPcntCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDdl(ddlParentRule, "Prc_FillParentRuleSetKey");
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopCntstMst", "ddlPcntCode_SelectedIndexChanged", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    //  <%--ended by prity on 23 aug 2018--%>

}
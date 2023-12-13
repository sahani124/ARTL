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
public partial class Application_Isys_Saim_NonStdCommApproval : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
     Hashtable ht = new Hashtable();
    SqlDataReader drRead;
    String PageSize = string.Empty;

    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            string sUserId = HttpContext.Current.Session["UserID"].ToString();

            if (sUserId == "cmpreview" || sUserId == "cmpchecker")
            {
               // btnSearch.Enabled = true;
            }
            if (!IsPostBack)
            {
                InitialControl();
                if (dgRwdRul.PageCount > 1)
                {
                    divPagination.Visible = true;
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
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
            objErr.LogErr("ISYS-SAIM","NonStdCommApproval", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void InitialControl()
    {
        
       
        ddlCmpCode.Items.Insert(0, new ListItem("-- SELECT --", ""));

        ddlCntCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlMemberCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlSubChannel.Items.Insert(0, new ListItem("-- SELECT --", ""));
        ddlRuleSetCode.Items.Insert(0, new ListItem("-- SELECT --", ""));

        FillDropDowns(ddlChannel, "1");
        ddlChannel.SelectedIndex=2;

       FillDropDowns(ddlSubChannel, "2");
       //ddlSubChannel.SelectedIndex = 1;

    }

    protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlSubChannel, "2");
    }

    protected void ddlSubChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlCmpCode, "3");
    }

    protected void ddlCmpCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlCntCode, "4");
    }

    protected void ddlCntCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlRuleSetCode, "5");

        
    }

    protected void ddlRuleSetCode_SelectedIndexChanged(object sender, EventArgs e)
    {
       // FillDropDowns(ddlMemberCode, "6");
        if(ddlRuleSetCode.SelectedIndex!=0)
        {
           // BindGrid(StdRateGrid, "2");
        }
        
        
    }
    protected void ddlCommType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDowns(ddlMemberCode, "6");
        if (ddlCommType.SelectedValue == "1")
        {
            spnMemCode.Visible = false;
            BindGrid(StdRateGrid, "2");
            DivResultHeading.Visible = false;
            divGridView.Visible = false;
           // divMemberWiseSearch.Visible = false;
            divRemark.Visible = false;
            lnkStdRate.Visible = false;
        
         
        }
        else 
        { 
            spnMemCode.Visible = true;
            lnkStdRate.Visible = true;
        }
    }
    protected void lnkStdRate_click(object sender, EventArgs e)
    {

        if (ddlCmpCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Compensation Code');", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contestant. Dependent contestant is assigned to this contestant');", true);
            return;
        }
        if (ddlCntCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Contestant Code');", true);
            return;
        }
        


        if (ddlSubChannel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Sub Channel Code');", true);
            return;
        }
       
        if (ddlRuleSetCode.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Code');", true);
            return;
        }
        if (ddlChannel.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Channel Code');", true);
            return;
        }

       
    }
    protected void BindGrid(GridView gv,String val)
    {
        ds = new DataSet();
        htParam = new Hashtable();
        htParam.Clear();
        ds.Clear();


        htParam.Add("@BizSrc", ddlChannel.SelectedValue.ToString());
        htParam.Add("@ChnCls", ddlSubChannel.SelectedValue.ToString());
        htParam.Add("@CMPNSTN_CODE", ddlCmpCode.SelectedValue.ToString().Trim());
        htParam.Add("@CNTSTNT_CODE", ddlCntCode.SelectedValue.ToString().Trim());
        htParam.Add("@RuleSetCode", ddlRuleSetCode.SelectedValue.ToString().Trim());
        if (ddlMemberCode.SelectedIndex > 0)
        {
            htParam.Add("@MEMBERCODE", ddlMemberCode.SelectedValue.ToString().Trim());
        }
        htParam.Add("@flag",val.ToString().Trim());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetNonStdComApprvl", htParam);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (val=="1")
            {
                DivResultHeading.Visible = true;
                divGridView.Visible = true;
                div1.Visible = true;
                divRemarkHeading.Visible = true;
                divRemark.Visible = true;
                gv.DataSource = ds;
                gv.DataBind();
                divPagination.Visible = true;
            }
           
            else
            {
                DivResultHeading.Visible = true;
                divGridView.Visible = true;
                div1.Visible = true;
                divRemarkHeading.Visible = true;
                divRemark.Visible = true;
                gv.DataSource = ds;
                gv.DataBind();
                divPagination.Visible = true;
            }
           
        }
        else
        {
            DivResultHeading.Visible = true;
            divGridView.Visible = true;
            divRemarkHeading.Visible = false;
            divRemark.Visible = false;
            ShowNoResultFound(ds.Tables[0], dgRwdRul);
            divPagination.Visible = false;
        }
    }


      protected void btnSearch_click(object sender, EventArgs e)
    {

    
          if(ddlCmpCode.SelectedIndex==0)
          {
              ScriptManager.RegisterStartupScript(this,this.GetType(), "popup", "alert('Please Select Compensation Code');",true);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Cannot delete the contestant. Dependent contestant is assigned to this contestant');", true);
              return;
          }
           if(ddlCntCode.SelectedIndex==0)
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Contestant Code');", true);
              return;
          }

         
          
          if(ddlSubChannel.SelectedIndex==0)
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Sub Channel Code');", true);
              return;
          }
           if(ddlMemberCode.SelectedIndex==0 && ddlCommType.SelectedValue=="2")
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Member Code');", true);
              return;
          }
           if (ddlCommType.SelectedValue == "0")
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Commission Type');", true);
               return;
           }
        if(ddlRuleSetCode.SelectedIndex==0)
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Rule Set Code');", true);
              return;
          }
        if (ddlChannel.SelectedIndex == 0)
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Channel Code');", true);
              return;
          }

          if(ddlMemberCode.SelectedIndex==0 && ddlCommType.SelectedValue=="1")
          {
              BindGrid(dgRwdRul, "2");
          }
          else
          {
              BindGrid(dgRwdRul, "1");
          }
       


   

     
  }

      protected void btnCancel_Click(object sender, EventArgs e)
      {
        //  Response.Redirect(this.ResolveClientUrl("~/Recruit/SEADTest.aspx"));
          ddlChannel.SelectedIndex = 1;
          ddlSubChannel.SelectedIndex = 0;
          ddlCmpCode.SelectedIndex = 0;
          ddlCntCode.SelectedIndex = 0;
          ddlRuleSetCode.SelectedIndex =0;
          ddlMemberCode.SelectedIndex = 0;
          ddlCommType.SelectedIndex = 0;
          DivResultHeading.Visible = false;
          divGridView.Visible = false;
          divPagination.Visible = false;
          divRemarkHeading.Visible = false;
          divRemark.Visible = false;
         

      }

      protected void chkall_CheckedChanged(object sender, EventArgs e)
      {
          GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
          CheckBox chkall = (CheckBox)row.FindControl("chkall");
          if (chkall.Checked == true)
          {
              foreach (GridViewRow rowItem in dgRwdRul.Rows)
              {
                  CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");

                  chBx.Checked = true;
                
                 
              }
          }
          if (chkall.Checked == false)
          {
              foreach (GridViewRow rowItem in dgRwdRul.Rows)
              {
                  CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");

                  chBx.Checked = false;


              }
          }
         
      }


      protected void btnAccepted_click(object sender, EventArgs e)
      {
          DataSet dsAcc = new DataSet();
          Hashtable htAcc = new Hashtable();
        
          string strSuccess = string.Empty;
          string strFail = string.Empty;



          int strCheckSelectLead = 0;

          foreach (GridViewRow rowItem in dgRwdRul.Rows)
          {
              CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


              if (chBx.Checked == true)
              {
                  strCheckSelectLead = strCheckSelectLead + 1;
              }
          }


          if (strCheckSelectLead <= 0)
          {
              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select reward rule code.');</script>", false);

          }

          else
          {
              if (TextareaRemark.Value=="")
              {
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter remark');", true);
                 
                  return;
              }

              foreach (GridViewRow rowItem in dgRwdRul.Rows)
              {
                  CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


                  if (chBx.Checked == true)
                  {
                      HiddenField hdnRWD_RUL_CODE = (HiddenField)rowItem.FindControl("hdnRWD_RUL_CODE");
                      htAcc.Clear();
                      dsAcc.Clear();
                      htAcc.Add("@RWD_RUL_CODE", hdnRWD_RUL_CODE.Value.ToString());
                      htAcc.Add("@ACTV_STATUS", "C");
                      htAcc.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString());
                      dsAcc = objDal.GetDataSetForPrc_SAIM("Prc_UpdStdComApprvl", htAcc);
                      ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Reward rule marked as accepted!!');</script>", false);
                      if (ddlMemberCode.SelectedIndex == 0 && ddlCommType.SelectedValue == "1")
                      {
                          BindGrid(dgRwdRul, "2");
                      }
                      else
                      {
                          BindGrid(dgRwdRul, "1");
                      }

                      TextareaRemark.Value = "";
                  }
                  else
                  {
                      //strFail = "N";
                  }
              }
             

          }
      }

      protected void btnRejected_click(object sender, EventArgs e)
      {
          DataSet dsAcc = new DataSet();
          Hashtable htAcc = new Hashtable();

          string strSuccess = string.Empty;
          string strFail = string.Empty;

          int strCheckSelectLead = 0;

          foreach (GridViewRow rowItem in dgRwdRul.Rows)
          {
              CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


              if (chBx.Checked == true)
              {
                  strCheckSelectLead = strCheckSelectLead + 1;
              }
          }


          if (strCheckSelectLead <= 0)
          {
              ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select reward rule code.');</script>", false);

          }
          else
          {
              if (TextareaRemark.Value == "")
              {
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please enter remark');", true);

                  return;
              }
              foreach (GridViewRow rowItem in dgRwdRul.Rows)
              {
                  CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


                  if (chBx.Checked == true)
                  {
                      strCheckSelectLead = strCheckSelectLead + 1;
                      HiddenField hdnRWD_RUL_CODE = (HiddenField)rowItem.FindControl("hdnRWD_RUL_CODE");
                      htAcc.Clear();
                      dsAcc.Clear();
                      htAcc.Add("@RWD_RUL_CODE", hdnRWD_RUL_CODE.Value.ToString());
                      htAcc.Add("@ACTV_STATUS", "R");
                      htAcc.Add("@CREATEDBY", HttpContext.Current.Session["UserID"].ToString());
                      dsAcc = objDal.GetDataSetForPrc_SAIM("Prc_UpdStdComApprvl", htAcc);
                      ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Reward rule marked as rejected!!');</script>", false);
                      if (ddlMemberCode.SelectedIndex == 0 && ddlCommType.SelectedValue == "1")
                      {
                          BindGrid(dgRwdRul, "2");
                      }
                      else
                      {
                          BindGrid(dgRwdRul, "1");
                      }

                      TextareaRemark.Value = "";
                  }


              }
             

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

              gv.Rows[0].Cells[0].Text = "";
              gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;
              gv.Rows[0].Cells[1].Text = "No reward have been defined";
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
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM","NonStdCommApproval", "ShowNoResultFound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
          }
      }

    protected void FillDropDowns(DropDownList ddl, string val)
    {
        try
        {
            ddl.Items.Clear();
             ht = new Hashtable();
                    ht.Clear();
            ht.Add("@Flag", val.ToString().Trim());
            ht.Add("@BizSrc",ddlChannel.SelectedValue.ToString());
            ht.Add("@ChnCls", ddlSubChannel.SelectedValue.ToString());
            ht.Add("@CMPNSTN_CODE", ddlCmpCode.SelectedValue.ToString().Trim());
            ht.Add("@CNTSTNT_CODE",ddlCntCode.SelectedValue.ToString().Trim());
            ht.Add("@RuleSetCode", ddlRuleSetCode.SelectedValue.ToString().Trim());
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillNonStdComApprDetails", ht);
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
            objErr.LogErr("ISYS-SAIM","NonStdCommApproval", "FillDropDowns", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
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

            int pageIndex = dgRwdRul.PageIndex;
            dgRwdRul.PageIndex = pageIndex + 1;
            //GetPageDtls();
            // BindGrid(txtCompCode.Text.Trim(), txtCompDesc1.Text.ToString().Trim(), ddlCompType.SelectedValue.ToString().Trim(), ddlStatus.SelectedValue.ToString().Trim());
            //BindGrid(dgCmp, btnprevious, btnnext, chkQual, divqual, "Q", div12);
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgRwdRul.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgRwdRul.PageCount;
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM","NonStdCommApproval", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

}
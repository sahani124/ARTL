using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CLTMGR;
using DataAccessClassDAL;
using Insc.Common.Multilingual;
using Telerik.Web.UI;


public partial class Application_ISys_Recruit_ViewInsuranceCompany : BaseClass
{
    #region Global declaration
    string strInsId=string.Empty;
     string strEdit = string.Empty;
       
    private const string CONN_Recruit = "INSCRecruitConnectionString";
    //private DataAccessLayerRecruit dataAccessRecruit = new DataAccessLayerRecruit();
    private DataAccessClass dataAccessRecruit = new DataAccessClass();
    private const string Conn_Direct = "DefaultConn";
    private multilingualManager olng;
    DataView dvResult = new DataView();
    Hashtable htParam = new Hashtable();
    string strUnitCode = string.Empty;
    EncodeDecode ObjDec = new EncodeDecode();
    DataSet dsmulti = new DataSet();
    DataSet ds_UnitType = new DataSet();
    Hashtable htmulti = new Hashtable();
    string user = string.Empty;
    string usertype = string.Empty;
    //private CommonUtility oCommonUtility = new CommonUtility();
    private INSCL.App_Code.CommonUtility oCommonUtility = new INSCL.App_Code.CommonUtility();
    ErrLog objErr = new ErrLog();
    DataSet dsCfruser = new DataSet(); //added by pranjali on 02-04-2014
    string Code;//added by pranjali on 15042014
 

  
    CommonFunc oCommon = new CommonFunc();
    DataSet dsResult;
    string Flag1;
   
    private string strUserLang;
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    private DataAccessClass dataAccess = new DataAccessClass();
    //EncodeDecode ObjDec = new EncodeDecode();
    Hashtable httable = new Hashtable();
    
    private bool isDrillDown = false;
    string Userid;

    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
 
       #endregion

    protected void 
        Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }
            Session["CarrierCode"] = '2';
            olng = new multilingualManager("DefaultConn", "ViewInsuranceCompany.aspx", Session["UserLangNum"].ToString());
       // gvComp.RowCommand +=new GridViewCommandEventHandler(gvComp_RowCommand);


            if (!IsPostBack)
            {
                pnl.Visible = false;
                 oCommonUtility.FillNoOfRecDropDown(ddlShwRecrds);
              
               
                if (Session["UserId"] != null)
                {
                    Userid = HttpContext.Current.Session["UserId"].ToString();
                }


                if (Request.QueryString["Type"].ToString().Trim() == "CompApp")
                {
                    trCompApp1.Visible = true;
                    trCompApp2.Visible = true;
                    trCompApp3.Visible = true;
                    trCompApp4.Visible = true;
                   
                    //trCompDtls.Visible = true;
                    //trRecord.Visible = true;
                    lblTitle.Text = "Composite Approval Search";
                   
                }



               
                else if (Request.QueryString["Type"].ToString().Trim() == "ViewInsurance")
                {
                    trInsuranceid1.Visible = true;
                    trInsuranceid2.Visible = true;
                    trInsuranceid3.Visible = true;
                    TrRegBranch.Visible = true;
                   
                    ddlStatus.SelectedValue = "2";
                    ddlStatus.Enabled = false;

                    GetInsuranceType(ddlInsuranceType);
                    GetInsuranceName(ddlInsuranceName);
                    GetRegionName(DdlRegnSrch);
                 //   trtitle.Visible = false;

                }
              
            }

            if (Session["UserId"] != null)
            {
                Userid = HttpContext.Current.Session["UserId"].ToString();
            }
            
        }
        
        catch (Exception ex)
        {
            
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            
            if (HttpContext.Current.Session["UserID"].ToString().Trim() == null || HttpContext.Current.Session["UserID"].ToString().Trim() == "")
                Response.Redirect("~/ErrorSession.aspx");
            else
                objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }


     
        

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        GetInsuranceType(ddlInsurerType);
        GetInsuranceName(ddlInsurerName);
       GetBranchName("");
       GetRegionName(DdlRgion);
       pnl.Visible = true;
       ViewState["StrED"] = string.Empty;
       ddlBranchName.SelectedValue = "Select";
       txtInsurerEmail.Text = "";
       mdlpopup.Show();
       ddlInsurerType.Enabled = true;
       ddlBranchName.Enabled = true;
        DdlRgion.Enabled = true;
        ddlInsurerName.Enabled = true;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
     
            BindDataGrid();
 
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

        DdlBrnhSrch.SelectedValue = "Select";
        txtEmail.Text = "";
        ddlInsuranceType.SelectedValue = "Select";
        ddlInsuranceName.SelectedValue = "Select";
        DdlRegnSrch.SelectedValue = "Select";
    }


    #region Bind Data to GridView
    protected void BindDataGrid()
    {
        try
        {

            //dgView.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue.Trim());
           // dgView.PageSize = Convert.ToInt32(ddlShwRecrds.SelectedValue);
            //Binds the data to grid of candidates came after approval with cndstatus='40' for 50 Hrs Training Request 
           
            DataTable ds = new DataTable();
            ds = GetDataTableFormail();

            if (ds != null)
            {
                if (ds.Rows.Count > 0)
                {
                    if (Request.QueryString["Type"].ToString().Trim() == "ViewInsurance" || Request.QueryString["Type"].ToString().Trim() == "CompApp")
                    {

                        if (Request.QueryString["Type"].ToString().Trim() == "ViewInsurance")
                        {
                            dgView.DataSource = ds;
                            //dgView.DataSource = dsmulti;
                            dgView.DataBind();
                            tdCnf.Visible = true;
                            trtitle.Visible = true;
                            trgridinsurance.Visible = true;
                           
                            lblMessage.Text = "";
                        }
                       

                        else if (Request.QueryString["Type"].ToString().Trim() == "CompApp")
                        {
                            trCompDtls.Visible = true;


                            gvComp.DataSource = ds;

                            gvComp.DataBind();
                            lblprospectsearch.Text = "Composite Approval Search Results";
                            tdCnf.Visible = true;
                            trtitle.Visible = true;
                            trgridinsurance.Visible = true;

                             //  lblMessage.Visible = false;
                            lblMessage.Text = "";

                        }

                        else
                        {
                            //gvComp.DataSource = null;
                            //gvComp.DataBind();
                            lblPageInfo.Text = "";

                            trRecord.Visible = true;
                            lblMessage.Visible = true;
                            lblMessage.Text = "0 Record Found";
                           
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
               


            }
            else {
               trRecord.Visible = true;
               lblMessage.Visible = true;
               
               lblMessage.Text = "0 Record Found";
               trgridinsurance.Visible = false;
               trtitle.Visible = false;
                           
              
              //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('0 recrod found')", true);
               // return;
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


    #region Bind Data to GridView
    //protected void BindDataGrid1()
    //{
    //     try
    //    {

           
    //        dsmulti.Clear();
    //        htParam.Clear();
            
    //        if(txtCndNo.Text =="")
    //        {
    //              htParam.Add("@CndNo", txtCndNo.Text);
    //        }

    //        if(txtAppNo.Text =="")
    //        {
    //            htParam.Add("@AppNo",txtAppNo.Text);
    //        }

    //       if(txtCndName.Text =="")
    //        {
    //            htParam.Add("@GivenName", txtCndName.Text);
    //        }
          
    //       if(txtPan.Text =="")
    //       {
    //            htParam.Add("@Pan", txtPan.Text.Trim());
    //       }
           
    //       if(txtRegDateTo.Text =="")
    //       {
    //             htParam.Add("@RegDateTo", txtRegDateTo.Text.Trim());
    //       }

               
    //       if(txtRegDateFrom.Text =="")
    //       {
    //           htParam.Add("@RegDateTo", txtRegDateFrom.Text.Trim());
    //       }

    //        dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetInsuranedetails", htParam);

    //        if (dsmulti.Tables.Count > 0)
    //        {
    //            if (dsmulti.Tables[0].Rows.Count > 0)
    //            {
    //                dgView.DataSource = dsmulti.Tables[0];
    //                dgView.DataSource = dsmulti;
    //                dgView.DataBind();
    //                ShowPageInformation();
    //                trgridinsurance.Visible = true;
    //                dgView.Visible = true;
    //                 //  lblMessage.Visible = false;
    //                lblMessage.Text = "";

    //            }

    //            else
    //            {
    //                dgView.DataSource = null;
    //                dgView.DataBind();
    //                lblPageInfo.Text = "";
    //                trgridinsurance.Visible = false;
                    
    //                trRecord.Visible = true;
    //                lblMessage.Visible = true;
    //                lblMessage.Text = "0 Record Found";

                 
    //            }
    //        }
    //        else
    //        {
    //            dgView.DataSource = null;
    //            dgView.DataBind();
    //            lblPageInfo.Text = "";
              
    //            lblMessage.Visible = true;
    //            lblMessage.Text = "0 Record Found";
               
    //        }

    //}

    //     catch (Exception ex)
    //     {
    //         string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
    //         System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
    //         string sRet = oInfo.Name;
    //         System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
    //         String LogClassName = method.ReflectedType.Name;
    //         objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
    //     }
    //}
    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (ViewState["StrED"].ToString() == "E")
        {
            GetData(hdnId.Value, 7);
        }

        else
        {
            if (ddlInsuranceType.SelectedValue != "Select" && txtInsurerEmail.Text != string.Empty && ddlInsurerName.SelectedValue != "Select" && ddlBranchName.SelectedValue != string.Empty && DdlRgion.SelectedValue !="Select")
            {
                GetData("", 2);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please ')", true);
            //    return;
            }
            else
            {
                mdlpopup.Show();
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please ')", true);
                //   return;
            }
            //else
            //{
               
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please ')", true);
            //    return;
            //}
        }
        
       
    }

    protected void btnCancel__Click(object sender, EventArgs e)
    {
        txtAppNo.Text = "";
        txtCndNo.Text = "";
        txtDTRegFrom.Text = "";
        txtDTRegTo.Text = "";
        txtPan.Text = "";
        txtCndName.Text = "";

    }

     #region ddlInsuranceType_SelectedIndexChanged
    
    protected void ddlInsuranceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlinsurancenameData(ddlInsuranceName, ddlInsuranceType);
        
    }
    
     #endregion

   

   
    #region ddlInsuranceName_SelectedIndexChanged
    protected void ddlShwRecrds_SelectedIndexChanged(object sender, EventArgs e)
    { 
         
        if (ddlShwRecrds.SelectedValue != null || ddlShwRecrds.SelectedValue != "")
        {
            BindDataGrid();
        }
    
    }
             #endregion

   
    #region dgView_RowCommand
    protected void dgView_RowCommand(object sender, GridViewCommandEventArgs e)
    {




        if (e.CommandName == "DelClick")
        {
            htmulti.Clear();

            string DelClick = e.CommandArgument.ToString().Trim();
            string InsId = e.CommandArgument.ToString().Trim();

            htmulti.Add("@UserId", Session["UserID"].ToString().Trim());
            htmulti.Add("@flag", 3);
            htmulti.Add("@InsId", InsId);

            dsmulti = dataAccessRecruit.GetDataSetForPrcRecruit("prc_InsuranceType", htmulti);


            lblMessage.Visible = true;
            //lblSub.Visible = true;
            lblMessage.Text = "Insurance Deleted Successfully";
            //lblSub.Text = "Insurance Deleted";

            //  mdlpopupSub.Show();
            // tdPopUp.Visible = true;
            //lblMessage.Visible = true;
            // }
            BindDataGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insurance Deleted')", true);
            return;

        }



        if (e.CommandName == "EditClick")
        {
            try
            {
                // btnAdd_Click(this,new EventArgs());
                strEdit = "E";
                ViewState["StrED"] = strEdit;
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string Editclick = e.CommandArgument.ToString().Trim();
                string lblInsId = e.CommandArgument.ToString().Trim();
                Label branch =(Label)row.FindControl("Branch");
               
                ViewState["Branch"]=branch.Text ;
                String brch = ViewState["Branch"].ToString();

              //  string branch= dgView.Rows[index].Cells[5].Text; 
                DataSet dsResult = new DataSet();
                Hashtable htparam = new Hashtable();
                //hdnId.Value = lblInsId.Text;


                GetInsuranceType(ddlInsurerType);
                GetBranchName(brch);
                GetRegionName(DdlRgion);
                GetInsuranceName(ddlInsurerName);

                htparam.Clear();
                htparam.Add("@InsId", lblInsId);
                htparam.Add("@flag", 6);

                dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

                if (dsResult.Tables[0].Rows.Count > 0)
                {

                    ddlInsurerType.Text = dsResult.Tables[0].Rows[0]["category"].ToString().Trim();
                    ddlBranchName.Text = dsResult.Tables[0].Rows[0]["Branch"].ToString();

                    txtInsurerEmail.Text = dsResult.Tables[0].Rows[0]["EmailId"].ToString();

                    DdlRgion.Text = dsResult.Tables[0].Rows[0]["Region"].ToString();
                    ddlInsurerName.Text = dsResult.Tables[0].Rows[0]["Name"].ToString();

                    hdnId.Value = lblInsId;
                }

                ddlInsurerType.Enabled = false;
                ddlInsurerName.Enabled = false;
                ddlBranchName.Enabled = false;
                DdlRgion.Enabled = false;
                txtInsurerEmail.Enabled = true;
                pnl.Visible = true;
                mdlpopup.Show();


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
    }

    
       
    
    #endregion


    #region dgView_Sorting
    protected void dgView_Sorting(object sender, GridViewSortEventArgs e)
    { }
    #endregion

    #region dgView RowDataBound
    protected void dgView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = new LinkButton();
            LinkButton lnkEdit = new LinkButton();
            Label lblInsid = (Label)e.Row.FindControl("InsId");
            // strInsId = lblInsid.Text;
            lnkDelete = (LinkButton)e.Row.FindControl("lblDelete");
            lnkEdit = (LinkButton)e.Row.FindControl("lblEdit");

           // lnkEdit.Attributes.Add("onclick", "LdWaitGrid(100000);");
        }

      

    }

    #endregion

    #region dgView Show Page Information for GridView
    private void ShowPageInformation()
    {
        int intPageIndex = dgView.PageIndex + 1;
        lblPageInfo.Text = "Page " + intPageIndex.ToString() + " of " + dgView.PageCount;
    }
    #endregion
  
    protected void ddlInsurerType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInsurerType.SelectedIndex != 0)
        {
            FillddlinsurancenameData(ddlInsurerName, ddlInsurerType);
            txtInsurerEmail.Enabled = true;
            ddlInsurerName.Enabled = true;
            ddlBranchName.Enabled = true;
            DdlRgion.Enabled = true;
        }

        else
        {
            FillddlinsurancenameData(ddlInsurerName, ddlInsurerType);
         
            txtInsurerEmail.Enabled = true;
            ddlInsurerName.Enabled = true;
            ddlBranchName.Enabled = true;
            DdlRgion.Enabled = true;

           

          

        }
        mdlpopup.Show();
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }


    protected void ddlInsurerName_SelectedIndexChanged(object sender, EventArgs e)
    { }



//private void GetInsuranceType()
//{
//    DataSet dsResult=new DataSet();
//    Hashtable htparam = new Hashtable();

//    htparam.Clear();
//    htparam.Add("@flag",1);
   
//    dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

//    if (dsResult.Tables[0].Rows.Count > 0)
//    {
//        ddlInsurerType.DataSource = dsResult;////ddlUnitType
//        ddlInsurerType.DataTextField = "category";
//        ddlInsurerType.DataValueField = "category";
//        ddlInsurerType.DataBind();
//        ddlInsurerType.Items.Insert(0, "--Select--");
//        txtInsurerEmail.Enabled = true;
//        ddlInsurerName.Enabled = true;
//        ddlBranchName.Enabled = true;
//        DdlRgion.Enabled = true;
//        ddlInsurerType.Enabled = true;
//        txtInsurerEmail.Text = string.Empty;
        
//    }

  
  
    
//}



    private void GetInsuranceType(DropDownList ddlInsType)
{
    DataSet dsResult = new DataSet();
    Hashtable htparam = new Hashtable();

    htparam.Clear();
    htparam.Add("@flag", 1);
    dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

    if (dsResult.Tables[0].Rows.Count > 0)
    {
        ddlInsType.DataSource = dsResult;////ddlUnitType
        ddlInsType.DataTextField = "category";
        ddlInsType.DataValueField = "category";
        ddlInsType.DataBind();
        ddlInsType.Items.Insert(0, "Select");
    }

  
    }

private void GetInsuranceName( DropDownList DdlInsurerName)
{

    DataSet dsResult = new DataSet();
    Hashtable htparam = new Hashtable();

    htparam.Clear();
    htparam.Add("@flag", 4);
    dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

    if (dsResult.Tables[0].Rows.Count > 0)
    {
        DdlInsurerName.DataSource = dsResult;////ddlUnitType
        DdlInsurerName.DataTextField = "Name";
        DdlInsurerName.DataValueField = "Name";
        DdlInsurerName.DataBind();
        DdlInsurerName.Items.Insert(0, "Select");
       

    }
}

    
    #region dgView PageIndexChanging
    protected void dgView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    { 
    
     try
        {
            //For Pagination of Search Grid
            DataTable dt = GetDataTableFormail();
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
       
 

    protected void GetData(string InsId,int flag)
    {
        Hashtable htparam = new Hashtable();
        
        htparam.Clear();
        htparam.Add("@InsId", InsId);
        htparam.Add("@Category", ddlInsurerType.SelectedItem.Text);
        htparam.Add("@CompName", ddlInsurerName.Text);
        htparam.Add("@Email", txtInsurerEmail.Text);
        htparam.Add("@UserId", Userid);
        htparam.Add("@Branch", ddlBranchName.SelectedItem.Text);
        htparam.Add("@Region", DdlRgion.SelectedItem.Text);

        htparam.Add("@flag", flag);
        dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);
        lblMessage.Text = "Email Id Changed Successfully";
        BindDataGrid();
        pnlSub.Visible = true;
        mdlpopupSub.Show();


    }

    #region dgView PageIndexChanging
    protected void gvComp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            //For Pagination of Search Grid
          //  DataTable dt = GetDataTable();
           DataTable dt= GetDataTableFormail();
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

    #region dgView_RowCommand
    protected void gvComp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Code = Request.QueryString["Type"].ToString();
        if (e.CommandName == "CompDtls")
        {
          String   ModuleID = Request.QueryString["ModuleID"].ToString().Trim();////Added by usha on 25.06.2021
             
            Response.Redirect("CompositeApproval.aspx?TrnRequest=Submit&CndNo=" + e.CommandArgument.ToString().Trim() + "&Code=" + Code.Trim()+ "&ModuleID=" + ModuleID + "&Type=N&mdlpopup=");
        }
       
    }





    #endregion



    #region dgView RowDataBound
    protected void gvComp_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lblCompoDtls = new LinkButton();
           // LinkButton lnkEdit = new LinkButton();
            Label lblInsid = (Label)e.Row.FindControl("InsId");
            // strInsId = lblInsid.Text;
            lblCompoDtls = (LinkButton)e.Row.FindControl("lblCompoDtls");
            //lnkEdit = (LinkButton)e.Row.FindControl("lblEdit");

           // lnkEdit.Attributes.Add("onclick", "LdWaitGrid(100000);");
        }

    }

    #endregion

    #region GetDataTableForHrsTrn()
    protected DataTable GetDataTableFormail()
    {
       DataSet dsmail = new DataSet();
       DataTable dtmail = new DataTable();
        try
        {
            //Searches the candidates with cndstatus='40' for 50 Hrs Training Request
            //dsmulti = null;
            htParam.Clear();
            htParam.Add("@CndNo", txtCndNo.Text.Trim());

            htParam.Add("@CndName", txtCndName.Text.Trim());
           
            htParam.Add("@PAN", txtPan.Text.Trim());
            htParam.Add("@RecruiterName", System.DBNull.Value);
            htParam.Add("@BranchName", System.DBNull.Value);
           
            if (txtAppNo.Text.ToString().Trim() != "")
            {
                htParam.Add("@Appno", txtAppNo.Text.ToString().Trim());
            }
            else
            {
                htParam.Add("@Appno", System.DBNull.Value);
            }



            if (txtDTRegFrom.Text.Trim() != "")
            {
                htParam.Add("@CreateFrmDtim", txtDTRegFrom.Text.Trim());
            }
            else
            {
                htParam.Add("@CreateFrmDtim ", System.DBNull.Value);
            }
            if (txtDTRegTo.Text.Trim() != "")
            {
                htParam.Add("@CreateToDtim", txtDTRegTo.Text.Trim());
            }
            else
            {
                htParam.Add("@CreateToDtim ", System.DBNull.Value);
            }

            if (Request.QueryString["Type"].ToString().Trim() == "CompApp")
            {
                dsmail = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetCompositeMailCCandidatesSearch", htParam);

            }
           
          
            else  if (Request.QueryString["Type"].ToString().Trim() == "ViewInsurance")
            {
                htParam.Clear(); 
               // htParam.Add("@InsId", txtInsuranceId.Text.Trim());
                if (ddlInsuranceType.SelectedIndex != 0)
                {
                    htParam.Add("@InsType", ddlInsuranceType.SelectedValue.Trim());
                }

                if (ddlInsuranceName.SelectedIndex != 0)
                {
                    htParam.Add("@Insname", ddlInsuranceName.SelectedValue);
                }

                if (DdlRegnSrch.SelectedIndex != 0)
                {
                    htParam.Add("@RegionSrch", DdlRegnSrch.SelectedValue);
                }
                if (DdlBrnhSrch.SelectedIndex != 0)
                {
                    htParam.Add("@DdlBrnchSrch", DdlBrnhSrch.SelectedValue);
                }

                if (txtEmail.Text.ToString() != "")
                {
                htParam.Add("@Email", txtEmail.Text.Trim());
                }

                dsmail = dataAccessRecruit.GetDataSetForPrcRecruit("Prc_GetInsuranedetails", htParam);
            }




            if (dsmail != null)
            {
                if (dsmail.Tables.Count > 0)
                {
                    if (dsmail.Tables[0].Rows.Count > 0)
                    {
                        dtmail = dsmail.Tables[0];
                    }
                    else
                    {
                        dtmail = null;
                    }
                }
                else
                {
                    dtmail = null;
                }
            }
            //else
            //{
            //    dtmail = null;
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
        return dtmail;
    }
    #endregion


    protected void lblCndView_Click(object sender, EventArgs e)
    {


       // string strWindow = "window.open('CndView.aspx?Type=Other&Act=NoEdit&CndNo=" + lblCndNoValue.Text + "','ViewCandDetails','width=790px,height=600px,resizable=0,left=190,scrollbars=1');";
        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", strWindow, true);

    }

    protected void DdlRgion_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            try
            {

                DataSet dsResult = new DataSet();
                Hashtable htparam = new Hashtable();

                htparam.Clear();
                htparam.Add("@flag", 8);
                htparam.Add("@Region", DdlRgion.SelectedValue);
                dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ddlBranchName.DataSource = dsResult;////ddlUnitType
                    ddlBranchName.DataTextField = "UnitLegalName";
                    ddlBranchName.DataValueField = "UnitLegalName";
                    ddlBranchName.DataBind();
                    ddlBranchName.Items.Insert(0, "Select");
                    mdlpopup.Show();
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
    
    
    }
    protected void DdlRegnSrch_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            try
            {

                DataSet dsResult = new DataSet();
                Hashtable htparam = new Hashtable();

                htparam.Clear();
                htparam.Add("@flag", 8);
                htparam.Add("@Region", DdlRegnSrch.SelectedValue);
                dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    DdlBrnhSrch.DataSource = dsResult;////ddlUnitType
                    DdlBrnhSrch.DataTextField = "UnitLegalName";
                    DdlBrnhSrch.DataValueField = "UnitLegalName";
                    DdlBrnhSrch.DataBind();
                    DdlBrnhSrch.Items.Insert(0, "Select");
                    mdlpopup.Show();
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


    }
    protected void GetBranchName(String branch)
    {
        try
        {

            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
             htparam.Add("@flag",8 );
             htparam.Add("@Region",branch);
            
             dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlBranchName.DataSource = dsResult;////ddlUnitType
                ddlBranchName.DataTextField = "UnitLegalName";
                ddlBranchName.DataValueField = "UnitLegalName";
                ddlBranchName.DataBind();
                ddlBranchName.Items.Insert(0, "Select");
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
    protected void GetRegionName(DropDownList ddlRegion)
         

    {
        try
        {

            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            htparam.Add("@flag", 9);
            dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlRegion.DataSource = dsResult;////ddlUnitType
                ddlRegion.DataTextField = "UnitLegalName";
                ddlRegion.DataValueField = "UnitLegalName";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, "Select");
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

    protected void FillddlinsurancenameData(DropDownList ddlname, DropDownList ddlInsType)
    {
        try
        {
            DataSet dsResult = new DataSet();
            Hashtable htparam = new Hashtable();

            htparam.Clear();
            htparam.Add("@Category", ddlInsType.Text);
            htparam.Add("@flag", 5);
            dsResult = dataAccess.GetDataSetForPrcRecruits("prc_InsuranceType", htparam);

            if (dsResult.Tables[0].Rows.Count > 0)
            {
                ddlname.DataSource = dsResult;////ddlUnitType
                ddlname.DataTextField = "Name";
                ddlname.DataValueField = "Name";
                ddlname.DataBind();
                ddlname.Items.Insert(0, "Select");
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
}




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

public partial class Application_Isys_Saim_Cmp_ViewData : BaseClass
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

        if (!IsPostBack)
        {

            if (Request.QueryString["lnkbtn"] == "lnkView")
            {
                BindGridPolicy();
            }
            else
            {
                BindGridRevisedPolicy();
            }
        }
    }

    protected void BindGridPolicy()
    {
        try
        {
            htParam.Clear();

            ds.Clear();

            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
            htParam.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString());
            htParam.Add("@ACC_CYCLE_CODE ", Request.QueryString["CycleCode"].ToString());
            htParam.Add("@KPI_CODE ", Request.QueryString["kpiCode"].ToString());
            htParam.Add("@Flag", Request.QueryString["flag"].ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_getMemberPolicyData", htParam);

            divPart.Visible = true;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {


                if (Request.QueryString["kpiCode"].ToString() == "1000000101" || Request.QueryString["kpiCode"].ToString() == "1000001401")
                {
                    gvPolicy.Visible = true;
                gvPolicy.DataSource = ds;
                gvPolicy.DataBind();

                }

                if (Request.QueryString["kpiCode"].ToString() == "1000001501")
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }

                
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
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "BindGridPolicy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void BindGridRevisedPolicy()
    {
        try
        {
            htParam.Clear();

            ds.Clear();

            htParam.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
            htParam.Add("@MEM_CODE", Request.QueryString["Memcode"].ToString());
            htParam.Add("@ACC_CYCLE_CODE ", Request.QueryString["CycleCode"].ToString());
            htParam.Add("@KPI_CODE ", Request.QueryString["kpiCode"].ToString());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_getMemberPolicyData_ADD", htParam);

            divRevised.Visible = true;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                gvRevPolicy.DataSource = ds.Tables[0];
                gvRevPolicy.DataBind();

                GrdParPolicy.DataSource = ds.Tables[1];
                GrdParPolicy.DataBind();
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
            objErr.LogErr("ISYS-SAIM", "Cmp_ViewData", "BindGridRevisedPolicy", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
 

    protected void btnAddPolicy_click(object sender, EventArgs e)
    {
        DataSet dsAcc = new DataSet();
        Hashtable htAcc = new Hashtable();

        string strSuccess = string.Empty;
        string strFail = string.Empty;



        int strCheckSelectLead = 0;

        foreach (GridViewRow rowItem in gvRevPolicy.Rows)
        {
            CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


            if (chBx.Checked == true)
            {
                strCheckSelectLead = strCheckSelectLead + 1;
            }
        }


        if (strCheckSelectLead <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Please select at least one policy !');</script>", false);

        }

        else
        {

            foreach (GridViewRow rowItem in gvRevPolicy.Rows)
            {
                CheckBox chBx = (CheckBox)rowItem.FindControl("chkOne");


                if (chBx.Checked == true)
                {
                    Label lblRevpolicyNo = (Label)rowItem.FindControl("lblRevpolicyNo");


                    HiddenField HdnPremiumRegisterID = (HiddenField)rowItem.FindControl("HdnPremiumRegisterID");
                    

                    htAcc.Clear();
                    dsAcc.Clear();


                    htAcc.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString());
                    htAcc.Add("@ACC_CYCLE", Request.QueryString["CycleCode"].ToString());
                    htAcc.Add("@PremiumRegisterID", HdnPremiumRegisterID.Value.ToString());

                    dsAcc = objDal.GetDataSetForPrc_SAIM("Prc_UpdRevisedPolicy", htAcc);

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>alert('Data save successfully !');</script>", false);

                   
                }
                else
                {
                    //strFail = "N";
                }


            }


        }


     
       
            BindGridRevisedPolicy();
        
    }

}
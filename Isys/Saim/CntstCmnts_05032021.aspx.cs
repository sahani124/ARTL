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

public partial class Application_ISys_Saim_CntstCmnts : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strCompCode = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString() == "fgAdd")
                {
                    FillDDL(ddlStatusR,"1");
                    FillDDL(ddlRuleSetKey, "2");
                    GetPageDtls();
                }
           
                if (Request.QueryString["flag"].ToString() == "fgView")
                {
                    divC.Visible = false;
                    divok.Visible = false;

                    GetPageDtls();
                   // ShowDDL();
                   // btOK.Visible = false;
                }
            }
          
        }
    }

    public void GetPageDtls()
    {
        htParam.Clear();
        ds.Clear();
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
       
        htParam.Add("@subcmntid", Request.QueryString["cmnttype"].ToString());
        htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetRevSegmentDtls", htParam);
        if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
        {
            gvRevHist.DataSource = ds.Tables[0];
            gvRevHist.DataBind();

            if (gvRevHist.PageCount > 1)
            {
                Button4.Enabled = true;
            }

            else
            {
                Button3.Enabled = false;
                Button4.Enabled = false;
                
            }
            
        }
        else
        {
            if (Request.QueryString["flag"].ToString() == "fgView")
            {
                //div1.Visible = false;
                //divAuditTrail.Visible = false;
                //divRevHist.Visible = false;
               //
                //return;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('No record exists'),doCancel()", true);
               return;
           
            }
            else
            {
                divRevHist.Visible = false;
                divAuditTrail.Visible = false;
                //div11.Visible = false;
                Button3.Enabled = false;
                Button4.Enabled = false;
            }
        }
        //if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        //{
        //    txtRemark.Text = ds.Tables[1].Rows[0]["Remark"].ToString().Trim();
        //}
    }

    //protected void chkQual_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkQual.Checked == true)
    //    {
    //        btOK.Enabled = true;
    //        ddlStatusR.Enabled = true;
    //        txtRemark.Enabled = true;
    //    }
    //    if (chkQual.Checked == false)
    //    {
    //        ddlStatusR.Enabled = false;
    //        txtRemark.Enabled = false;


    //    }
    //}
    
    protected void FillDDL(DropDownList ddl,String val)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        ht.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        ht.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
      //  ht.Add("@subcmntid",Request.QueryString["cmnttype"].ToString());

        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetReason", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "ParamDesc1";
            ddl.DataValueField = "ParamValue";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();
    }

    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
    }


    protected void FillDropDowns(DropDownList ddl)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ///Ashish
        ht.Add("@CODE", Request.QueryString["status"].ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetDESC01", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "NextStatus";
            ddl.DataValueField = "Code";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();
    }

    protected void ShowDDL()
    {
        ds.Clear();
        htParam.Clear();
        ds = objDal.GetDataSetForPrc_SAIM("Prc_GetViewData", htParam);
        txtRemark.Text = ds.Tables[0].Rows[0]["ParamDesc1"].ToString();
        ddlStatusR.SelectedValue = ds.Tables[0].Rows[0]["Remark"].ToString();


    }

    protected void btOK_Click(object sender, EventArgs e)
    {

        if (ddlRuleSetKey.SelectedIndex==0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select rule set key');", true);
            return;

        }
        if(ddlStatusR.SelectedIndex==0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select reason');", true);
            return;
        }
        if (txtRemark.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select approval remark');", true);
            return;
        }
        //AUDIT ENTRY
        ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", Request.QueryString["CmpCode"].ToString().Trim());
        htParam.Add("@CNTSTN_CODE", Request.QueryString["CntstCode"].ToString().Trim());
        htParam.Add("@UserId", Session["UserID"].ToString().Trim());
        htParam.Add("@Remark", txtRemark.Text.ToString().Trim());
       // htParam.Add("@Status", Request.QueryString["status"].ToString().Trim());    
        htParam.Add("@RULE_SET_KEY", ddlRuleSetKey.SelectedValue.ToString().Trim());
        htParam.Add("@Status", ddlStatusR.SelectedValue.ToString().Trim());
        htParam.Add("@Version", Request.QueryString["version"].ToString());
        htParam.Add("@subcmntid", Request.QueryString["cmnttype"].ToString());
        htParam.Add("@RuleType", Request.QueryString["ruletype"].ToString());
        ds = objDal.GetDataSetForPrc_SAIM("Prc_InsertCMPNSTN_RevHistDtls", htParam);

      
    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Data save succssfully');", true);
    ddlRuleSetKey.SelectedIndex = 0;
    txtRemark.Text = "";
    ddlStatusR.SelectedIndex = 0;
    GetPageDtls();

    }

}
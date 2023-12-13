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

public partial class Application_Isys_Saim_RuleSetPages_VPSC_EKYCDef : BaseClass
{
    DataAccessClass obDAL = new DataAccessClass();
    Hashtable htparam = new Hashtable();
    DataSet ds = new DataSet();
    SqlDataReader drRead;
    DataAccessClass objDal = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EditVPSC();
        }
    }

    private void EditVPSC()
    {
        Hashtable ht = new Hashtable();
        ds.Clear();
        ht.Clear();

        if (Request.QueryString["RuleId"] != null)
        {
            try
            {
                int strRule = Convert.ToInt16(Request.QueryString["RuleId"]);
                ht.Add("@RuleId", Request.QueryString["RuleId"].ToString());
            }
            catch (Exception ex)
            {
                ht.Add("@RuleId", "0");
            }
        }
        else
        {
            ht.Add("@RecId", "0");
        }

        //  PrcGetMST_DateRelatedDef

        ds = objDal.GetDataSetForPrc_SAIM("Prc_EditVPSCEKYC_WithRecId", ht);// Changed by Abuzar on 14/10/2020


        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlISVPSC.SelectedValue = ds.Tables[0].Rows[0]["ISVPSC"].ToString();
                ddlISEKYC.SelectedValue = ds.Tables[0].Rows[0]["ISEKYC"].ToString();
                TextWeightage.Text = ds.Tables[0].Rows[0]["WEIGHTAGE"].ToString();
                //TxtWeg.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        //Policy term To
        //if (TextPolicyTermFrom.Text.Contains(".") == true)
        //{
        //    if (Convert.ToDecimal(TextPolicyTermFrom.Text) > Convert.ToDecimal(TextPolicyTermTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Policy Term From should be less thanPolicy Term To');", true);
        //        return;
        //    }
        //}
        //else if (TextPolicyTermFrom.Text.Contains(".") == false)
        //{
        //    if (Convert.ToInt32(TextPolicyTermFrom.Text) > Convert.ToInt32(TextPolicyTermTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Policy Term From should be less than Policy Term To');", true);
        //        return;
        //    }
        //}

        ////TextPayTermFrom
        //if (ddlfreguency.SelectedValue != "F5")
        //{
        //    if (TextPayTermFrom.Text.Contains(".") == true)
        //    {
        //        if (Convert.ToDecimal(TextPayTermFrom.Text) > Convert.ToDecimal(TextPayTermTo.Text))
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
        //            return;
        //        }
        //    }

        //    //else if (TextPolicyTermFrom.Text.Contains(".") == false)
        //    //{
        //    //    if (Convert.ToInt32(TextPayTermFrom.Text) > Convert.ToInt32(TextPayTermTo.Text))
        //    //    {
        //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
        //    //        return;
        //    //    }
        //    //}
        //}

        ////TextPremiumFrom
        //if (TextPremiumFrom.Text.Contains(".") == true)
        //{
        //    if (Convert.ToDecimal(TextPremiumFrom.Text) > Convert.ToDecimal(TextPremiumTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Premium From Should greater than Pay Premium To');", true);
        //        return;
        //    }
        //}
        //else if (TextPremiumFrom.Text.Contains(".") == false)
        //{
        //    if (Convert.ToInt32(TextPremiumFrom.Text) > Convert.ToInt32(TextPremiumTo.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Premium From Should greater than Pay Premium To');", true);
        //        return;
        //    }
        //}
        //if (rblSplit.Items[0].Selected == false && rblSplit.Items[1].Selected == false && rblSplit.Items[2].Selected == false)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please select Consider');", true);
        //    return;
        //}
        //---------------End Validation For from and To----------------------

        htparam.Clear();
        ds.Clear();
        htparam.Add("@ISVPSC", ddlISVPSC.SelectedValue.Trim());
        htparam.Add("@ISEKYC", ddlISEKYC.SelectedValue.Trim());

        //htparam.Add("@ProdFreq", ddlfreguency.SelectedValue.ToString().Trim());
        //htparam.Add("@PolFrm", TextPolicyTermFrom.Text.ToString().Trim());
        //htparam.Add("@PolTo", TextPolicyTermTo.Text.ToString().Trim());
        //htparam.Add("@PayFrm", TextPayTermFrom.Text.ToString().Trim());
        //htparam.Add("@PayTo", TextPayTermTo.Text.ToString().Trim());
        //htparam.Add("@PremFrm", TextPremiumFrom.Text.ToString().Trim());
        //htparam.Add("@PremTo", TextPremiumTo.Text.ToString().Trim());
        //htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());

        // ds = obDAL.GetDataSetForPrcDBConn("Prc_ValidateProdStdDefn", htparam, "SAIMConnectionString");
        //if (ds.Tables.Count > 0)
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows[0]["RETURNVALUE"].ToString().Trim() == "1")
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "alert('This rule is already been setup for the product code')", true);
        //            return;
        //        }
        //    }
        //}
        
        int strRule;
        string map = Request.QueryString["mapcode"].ToString();
        htparam.Clear();
        if (Request.QueryString["RuleId"] != null && Request.QueryString["RuleId"].ToString() != "undefined")
        {
            try
            {
                if (Request.QueryString["RuleId"] != "")
                {
                    strRule = Convert.ToInt16(Request.QueryString["RuleId"]);
                    htparam.Add("@RecId", Request.QueryString["RuleId"].ToString().Trim());
                }
                else
                {
                    htparam.Add("@RecId", "");
                }
            }
            catch (Exception ex)
            {
                htparam.Add("@RecId", "");

            }
        }
        else
        {
            htparam.Add("@RecId", "");
        }
        //,,,,,,,,,,,)

        // MapCode


        htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString());
        htparam.Add("@ISVPSC", ddlISVPSC.SelectedValue.ToString());
        htparam.Add("@ISEKYC", ddlISEKYC.SelectedValue.ToString());
        //htparam.Add("@ProductCode", ddlProduct.SelectedValue.ToString());
        //htparam.Add("@ProductName", TextProductName.Text);
        //htparam.Add("@PlanCode", TextPlanCode.Text);
        //htparam.Add("@Frequency", ddlfreguency.SelectedValue.ToString());
        //htparam.Add("@PolicyTermFrom", TextPolicyTermFrom.Text);
        //htparam.Add("@PolicyTermTo", TextPolicyTermTo.Text);
        //htparam.Add("@PayTermFrom", TextPayTermFrom.Text);
        //htparam.Add("@PayTermTo", TextPayTermTo.Text);
        //htparam.Add("@PremiumFrom", TextPremiumFrom.Text);//@PremiumFrom,@PremiumTo
        //htparam.Add("@PremiumTo", TextPremiumTo.Text);
        //htparam.Add("@PremiumType", ddlPremiumType.SelectedValue.ToString());
        //htparam.Add("@PayMode", ddlPayMode.SelectedValue.ToString());
        //htparam.Add("@Consider", rblSplit.SelectedValue.ToString());
        htparam.Add("@Weightage", TextWeightage.Text);
        //htparam.Add("@PrdClass", ddlPrdClsCode.SelectedValue.ToString().Trim());
        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        obDAL.GetDataSetForPrc_SAIM("Prc_ISVPSC_EKYCDef_SaveData", htparam); // Changed by Abuzar on 14/10/2020

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
    }
}
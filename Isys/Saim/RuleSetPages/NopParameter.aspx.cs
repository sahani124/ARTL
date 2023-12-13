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
public partial class Application_ISys_Saim_RuleSetPages_NopParameter : BaseClass
{
    DataAccessClass obDAL = new DataAccessClass();
    Hashtable htparam = new Hashtable();
    DataSet ds = new DataSet();
    SqlDataReader drRead;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //ddlPrdClsCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
            //FillDropDowns(ddlPrdClsCode, "34");
            //BindFreqType();

            if (Request.QueryString["RuleId"] != null)
            {
                htparam.Clear();
                ds.Clear();

                try
                {

                    int strRule = Convert.ToInt16(Request.QueryString["RuleId"]);
                    if (Request.QueryString["RuleId"] != null)
                    {
                        htparam.Add("@RecId", Request.QueryString["RuleId"].ToString());
                    }
                    else
                    {
                        htparam.Add("@RecId", "0");
                    }
                }
                catch (Exception ex)
                {
                    htparam.Add("@RecId", "0");

                }
            }
            else
            {
                htparam.Add("@RecId", "0");
            }

            //  PrcGetMST_DateRelatedDef

            ds = obDAL.GetDataSetForPrcDBConn("PrcGetMST_NopParameterDef", htparam, "SAIMConnectionString");


            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextPremiumFrom.Text = ds.Tables[0].Rows[0]["PREMIUM_FRM"].ToString();

                    TextPremiumTo.Text = ds.Tables[0].Rows[0]["PREMIUM_TO"].ToString();

                    TxtRemark.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();

                }
            }
            //        ddlProduct.SelectedItem.Text = ds.Tables[0].Rows[0]["ProductCode"].ToString().Trim();
            //        ddlProduct.Enabled = false;
            //        TextProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();

            //        TextPlanCode.Text = ds.Tables[0].Rows[0]["PlanCode"].ToString();

            //        ddlfreguency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString();

            //        TextPolicyTermFrom.Text = ds.Tables[0].Rows[0]["PolicyTermFrom"].ToString();

            //        TextPolicyTermTo.Text = ds.Tables[0].Rows[0]["PolicyTermTo"].ToString();

            //        TextPayTermFrom.Text = ds.Tables[0].Rows[0]["PayTermFrom"].ToString();

            //        TextPayTermTo.Text = ds.Tables[0].Rows[0]["PayTermTo"].ToString();

            //        TextPremiumFrom.Text = ds.Tables[0].Rows[0]["PremiumFrom"].ToString();

            //        TextPremiumTo.Text = ds.Tables[0].Rows[0]["PremiumTo"].ToString();

            //        ddlPremiumType.SelectedValue = ds.Tables[0].Rows[0]["PremiumType"].ToString();

            //        ddlPayMode.SelectedValue = ds.Tables[0].Rows[0]["PayMode"].ToString();

            //        //   rblSplit.SelectedValue = ds.Tables[0].Rows[0]["Consider"].ToString();

            //        rblSplit.SelectedValue = ds.Tables[0].Rows[0]["Consider"].ToString();
            //        ddlPrdClsCode.SelectedValue = ds.Tables[0].Rows[0]["ProdClass"].ToString();
            //        TextWeightage.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();
                   
            //    }
            //}
        }
    }

    //public void BindFreqType()
    //{
    //    Hashtable ht = new Hashtable();
    //    if (Request.QueryString["mapcode"] != null)
    //    {
    //        if (Request.QueryString["mapcode"].ToString().Trim() != "")
    //        {
    //            ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
    //        }
    //    }
    //    ht.Add("@Flag", "1");
    //    ds = obDAL.GetDataSetForPrc_SAIM("Prc_DDLFrqBind", ht);
    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
    //        ddlfreguency.DataSource = ds;
    //        ddlfreguency.DataTextField = "desc02";
    //        ddlfreguency.DataValueField = "code";
    //        ddlfreguency.DataBind();
    //    }
    //    ddlfreguency.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));

    //    ddlPayMode.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
    //    ddlPremiumType.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
    //}

    //public void BinddDlProduct()
    //{
    //    Hashtable ht = new Hashtable();
    //    ht.Clear();
    //    ddlProduct.Items.Clear();
    //    ht.Add("@Productvalue", ddlPrdClsCode.SelectedValue.ToString().Trim());
    //    ds = obDAL.GetDataSetForPrc_SAIM("prc_GetProductVar", ht);

    //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
    //        ddlProduct.DataSource = ds;
    //        ddlProduct.DataTextField = "ProductName";
    //        ddlProduct.DataValueField = "ProductValue";
    //        ddlProduct.DataBind();
    //    }
    //    ddlProduct.Items.Insert(0, new ListItem("ALL", "ALL"));
    //}

    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        //TextPremiumFrom
        if (TextPremiumFrom.Text.Contains(".") == true)
        {
            if (Convert.ToDecimal(TextPremiumFrom.Text) > Convert.ToDecimal(TextPremiumTo.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Premium From should not greater than Premium To');", true);
                return;
            }
        }
   
        int strRule;
        string map = Request.QueryString["mapcode"].ToString();
        htparam.Clear();
        if (Request.QueryString["RuleId"] != null)
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
        htparam.Add("@PremiumFrom", TextPremiumFrom.Text);//@PremiumFrom,@PremiumTo
        htparam.Add("@PremiumTo", TextPremiumTo.Text);
        htparam.Add("@Remark", TxtRemark.Text);
        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        obDAL.GetDataSetForPrcDBConn("Prc_Ins_NOP_PRMTER_DEF", htparam, "SAIMConnectionString");

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
    }

    protected void rblSplit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSplit.SelectedValue.ToString() == "EX")
        {
            TextWeightage.Text = "00";
            TextWeightage.Enabled = false;

        }
        else
        {

            TextWeightage.Text = "";
            TextWeightage.Enabled = true;

        }
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex == 0)
        {
            TextProductName.Text = "";
            TextPlanCode.Text = "";
        }
        Hashtable ht = new Hashtable();
        ht.Add("@ProdCode", ddlProduct.SelectedValue.ToString());
        ds = obDAL.GetDataSetForPrc_SAIM("GetProdDesc", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            TextProductName.Text = ds.Tables[0].Rows[0][0].ToString();
            TextPlanCode.Text = "ALL";
        }
        //ddlProduct.Items.Insert(0, new ListItem("-----SELECT-----", ""));
    }

    //protected void TextPolicyTermTo_TextChanged(object sender, EventArgs e)
    //{
    //   int txtptf=Convert.ToInt32(TextPolicyTermFrom.Text);
    //   int txtptt=Convert.ToInt32(TextPolicyTermTo.Text);

    //   if (txtptf > txtptt)
    //    {

    //    }
    //}
    protected void ddlfreguency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfreguency.SelectedValue == "F5")
        {
            TextPayTermFrom.Enabled = false;
            TextPayTermTo.Enabled = false;
            lblPayTermFrom.Visible = false;
            lblPayTermTo.Visible = false;
        }
        else
        {
            TextPayTermFrom.Enabled = true;
            TextPayTermTo.Enabled = true;
            lblPayTermFrom.Visible = true;
            lblPayTermTo.Visible = true;
        }

    }
    protected void ddlPrdClsCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BinddDlProduct();
        Hashtable ht = new Hashtable();
        ht.Add("@ProdCode", ddlProduct.SelectedItem.ToString());
        ds = obDAL.GetDataSetForPrc_SAIM("GetProdDesc", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            TextProductName.Text = ds.Tables[0].Rows[0][0].ToString();
            TextPlanCode.Text = ds.Tables[0].Rows[0][1].ToString();
        }
    }
    protected void FillDropDowns(DropDownList ddl, string val)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        drRead = obDAL.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
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
}
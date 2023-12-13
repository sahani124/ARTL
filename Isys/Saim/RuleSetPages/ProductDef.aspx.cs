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
public partial class Application_ISys_Saim_RuleSetPages_ProductDef : BaseClass
{
    DataAccessClass obDAL = new DataAccessClass();
    Hashtable htparam = new Hashtable();
    DataSet ds = new DataSet();
    SqlDataReader drRead;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlPrdClsCode.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlProduct.Items.Insert(0, new ListItem("-- SELECT --", ""));
            FillDropDowns(ddlPrdClsCode, "34");
            BindFreqType();
            
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

                   // objErr.LogErr("ISYS-SAIM", "ProductDef", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

                }
            }
            else
            {
                htparam.Add("@RecId", "0");
            }

            //  PrcGetMST_DateRelatedDef

            ds = obDAL.GetDataSetForPrcDBConn("EditProdData_recId", htparam, "SAIMConnectionString");


            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlProduct.SelectedItem.Text = ds.Tables[0].Rows[0]["ProductCode"].ToString().Trim();
                    ddlProduct.Enabled = false;
                    TextProductName.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();

                    TextPlanCode.Text = ds.Tables[0].Rows[0]["PlanCode"].ToString();

                    ddlfreguency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString();

                    TextPolicyTermFrom.Text = ds.Tables[0].Rows[0]["PolicyTermFrom"].ToString();

                    TextPolicyTermTo.Text = ds.Tables[0].Rows[0]["PolicyTermTo"].ToString();

                    TextPayTermFrom.Text = ds.Tables[0].Rows[0]["PayTermFrom"].ToString();

                    TextPayTermTo.Text = ds.Tables[0].Rows[0]["PayTermTo"].ToString();

                    TextPremiumFrom.Text = ds.Tables[0].Rows[0]["PremiumFrom"].ToString();

                    TextPremiumTo.Text = ds.Tables[0].Rows[0]["PremiumTo"].ToString();

                    ddlPremiumType.SelectedValue = ds.Tables[0].Rows[0]["PremiumType"].ToString();

                    ddlPayMode.SelectedValue = ds.Tables[0].Rows[0]["PayMode"].ToString();

                    txtEffDtFrm.Text = ds.Tables[0].Rows[0]["DateEffectiveFrom"].ToString();
                    txtEffDtTo.Text = ds.Tables[0].Rows[0]["DateEffectiveTo"].ToString();
                    //   rblSplit.SelectedValue = ds.Tables[0].Rows[0]["Consider"].ToString();

                    rblSplit.SelectedValue = ds.Tables[0].Rows[0]["Consider"].ToString();
                    ddlPrdClsCode.SelectedValue = ds.Tables[0].Rows[0]["ProdClass"].ToString();
                    TextWeightage.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();
                    //,,,,
                    //,,,,,,,,,
                    //ddltype.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
                    //rblSplit.SelectedValue = ds.Tables[0].Rows[0]["considerval"].ToString();
                    //TxtWeg.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();

                    // ddlfreguency

                    //  rblSplit
                    //TxtWeg
                    //ddltype
                }
            }
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {

        Hashtable ht = new Hashtable();
        ds.Clear();
        ht.Clear();
        ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
        ht.Add("@Prodcode", ddlProduct.SelectedValue.ToString().Trim());
        ht.Add("@DateEffectiveFrom", txtEffDtFrm.Text.ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_getNextDate", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["valid"].ToString().Trim() == "No")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date Is Not Valid');", true);
                return;

            }

        }



    }


    protected void txtEffDtFrm_TextChanged(object sender, EventArgs e)
    {
        //Label1.Text = Server.HtmlEncode(TextBox1.Text);



        Hashtable ht = new Hashtable();
        ds.Clear();
        ht.Clear();
        ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
        ht.Add("@Prodcode", ddlProduct.SelectedValue.ToString().Trim());
       //ht.Add("@DateEffectiveFrom", txtEffDtFrm.Text.ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_getNextDate", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

           
                txtEffDtFrm.Text = ds.Tables[0].Rows[0]["DateEffectiveFrom"].ToString().Trim();
               
              


        }



    }

    public void BindFreqType()
    {
        Hashtable ht = new Hashtable();
        if (Request.QueryString["mapcode"] != null)
        {
            if (Request.QueryString["mapcode"].ToString().Trim() != "")
            {
                ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
            }
        }
        ht.Add("@Flag", "1");
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_DDLFrqBind", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlfreguency.DataSource = ds;
            ddlfreguency.DataTextField = "desc02";
            ddlfreguency.DataValueField = "code";
            ddlfreguency.DataBind();
        }
        ddlfreguency.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));

        ddlPayMode.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
        ddlPremiumType.Items.Insert(0, new ListItem("     -- SELECT --     ", ""));
    }

    public void BinddDlProduct()
    {
        Hashtable ht = new Hashtable();
        ht.Clear();
        ddlProduct.Items.Clear();
        ht.Add("@Productvalue", ddlPrdClsCode.SelectedValue.ToString().Trim());
        ht.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("prc_GetProductVar", ht);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlProduct.DataSource = ds;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductValue";
            ddlProduct.DataBind();
        }
        ddlProduct.Items.Insert(0, new ListItem("ALL", "ALL"));
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

        //TextPayTermFrom
        //if (ddlfreguency.SelectedValue != "F5")
        //{
        //    if (TextPayTermFrom.Text.Contains(".") == true)
        //    {
        //        if (Convert.ToDecimal(TextPayTermFrom.Text) > Convert.ToDecimal(TextPayTermTo.Text))
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
            //        return;
            //    }
            //}

        //    //else if (TextPolicyTermFrom.Text.Contains(".") == false)
        //    //{
        //    //    if (Convert.ToInt32(TextPayTermFrom.Text) > Convert.ToInt32(TextPayTermTo.Text))
        //    //    {
        //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Pay Term From Should greater than Pay Term To');", true);
        //    //        return;
        //    //    }
        //    //}
        //}

        //TextPremiumFrom
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
	htparam.Add("@ProdClass", ddlPrdClsCode.SelectedValue.Trim());
        htparam.Add("@ProdCode", ddlProduct.SelectedValue.Trim());
        htparam.Add("@ProdFreq", ddlfreguency.SelectedValue.ToString().Trim());
        htparam.Add("@PolFrm", TextPolicyTermFrom.Text.ToString().Trim());
        htparam.Add("@PolTo", TextPolicyTermTo.Text.ToString().Trim());
        htparam.Add("@PayFrm", TextPayTermFrom.Text.ToString().Trim());
        htparam.Add("@PayTo", TextPayTermTo.Text.ToString().Trim());
        htparam.Add("@PremFrm", TextPremiumFrom.Text.ToString().Trim());
        htparam.Add("@PremTo", TextPremiumTo.Text.ToString().Trim());
        htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());

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

                //objErr.LogErr("ISYS-SAIM", "ProductDef", "btnsave_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

            }
        }
        else
        {
            htparam.Add("@RecId", "");
        }
        //,,,,,,,,,,,)

        // MapCode

        
        htparam.Add("@MapCode", Request.QueryString["mapcode"].ToString());
        htparam.Add("@ProductCode", ddlProduct.SelectedValue.ToString());
        htparam.Add("@ProductName", ddlProduct.SelectedItem.ToString());
        htparam.Add("@PlanCode", TextPlanCode.Text);
        htparam.Add("@Frequency", ddlfreguency.SelectedValue.ToString());
        htparam.Add("@PolicyTermFrom", TextPolicyTermFrom.Text);
        htparam.Add("@PolicyTermTo", TextPolicyTermTo.Text);
        htparam.Add("@PayTermFrom", TextPayTermFrom.Text);
        htparam.Add("@PayTermTo", TextPayTermTo.Text);
        htparam.Add("@PremiumFrom", TextPremiumFrom.Text);//@PremiumFrom,@PremiumTo
        htparam.Add("@PremiumTo", TextPremiumTo.Text);
        htparam.Add("@PremiumType", ddlPremiumType.SelectedValue.ToString());
        htparam.Add("@PayMode", ddlPayMode.SelectedValue.ToString());
        htparam.Add("@Consider", rblSplit.SelectedValue.ToString());
        htparam.Add("@Weightage", TextWeightage.Text);
        htparam.Add("@PrdClass", ddlPrdClsCode.SelectedValue.ToString().Trim());

 
         htparam.Add("@DateEffectiveFrom", DateTime.ParseExact(txtEffDtFrm.Text.ToString().Trim(), "dd/MM/yyyy", null));

        
         htparam.Add("@DateEffectiveTo", DateTime.ParseExact(txtEffDtTo.Text.ToString().Trim(), "dd/MM/yyyy", null));
     //   htparam.Add("@DateEffectiveTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));

  

       // htparam.Add("@DateEffectiveFrom", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
       // htparam.Add("@DateEffectiveTo", Convert.ToDateTime(txtEffDtTo.Text.ToString().Trim()));

        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        obDAL.GetDataSetForPrcDBConn("Prc_ProductDef_SaveData", htparam, "SAIMConnectionString");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);

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




        Hashtable htdte = new Hashtable();
        ds.Clear();
        htdte.Clear();
        htdte.Add("@MapCode", Request.QueryString["mapcode"].ToString().Trim());
        htdte.Add("@Prodcode", ddlProduct.SelectedValue.ToString().Trim());
        htdte.Add("@RULE_SET_KEY", Request.QueryString["RuleSetKey"].ToString().Trim());
        htdte.Add("@KPI_CODE", Request.QueryString["KpiCode"].ToString().Trim());

        //ht.Add("@DateEffectiveFrom", txtEffDtFrm.Text.ToString().Trim());
        ds = obDAL.GetDataSetForPrc_SAIM("Prc_getNextDate", htdte);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {


            txtEffDtFrm.Text = ds.Tables[0].Rows[0]["DateEffectiveFrom"].ToString().Trim();




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
        BinddDlProduct();
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
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

public partial class Application_ISys_Saim_RuleSetPages_PremiumFreeqDef : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFreqType();
            BindType();


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

            ds = objDal.GetDataSetForPrc_SAIM("Prc_EditPremiumFreq_WithRecId", ht);//Changed by Abuzar on 14/10/2020


            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlfreguency.SelectedValue = ds.Tables[0].Rows[0]["FrequencyType"].ToString();

                    ddltype.SelectedValue = ds.Tables[0].Rows[0]["Type"].ToString();
                    rblSplit.SelectedValue = ds.Tables[0].Rows[0]["considerval"].ToString();
                    TxtWeg.Text = ds.Tables[0].Rows[0]["Weightage"].ToString();
                }
            }

        }

    }
    //protected void btnCncl_Click(object sender, EventArgs e)
    //{
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doOk('007','S');", true);
    //}

    public void BindFreqType()
    {
        Hashtable ht = new Hashtable();


        ds = objDal.GetDataSetForPrc_SAIM("Prc_DDLFrqBind", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddlfreguency.DataSource = ds;
            ddlfreguency.DataTextField = "desc02";
            ddlfreguency.DataValueField = "code";
            ddlfreguency.DataBind();
        }


        ddlfreguency.Items.Insert(0, new ListItem("--SELECT--", ""));
    }

    public void BindType()
    {
        Hashtable ht = new Hashtable();


        ds = objDal.GetDataSetForPrc_SAIM("Prc_DDLTypeBind", ht);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ////txtRulSetKy.Text = ds.Tables[0].Rows[0]["RULE_SET_KEY"].ToString().Trim();
            ddltype.DataSource = ds;
            ddltype.DataTextField = "desc01";
            ddltype.DataValueField = "code";
            ddltype.DataBind();
        }

        ddltype.SelectedValue = "1003";
        ddltype.Items.Insert(0, new ListItem("--SELECT--", ""));
        
       
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable htparam = new Hashtable();
        htparam.Clear();
        //FrequencyType,Consider,Type,Weightage,CompensationCode

       // @RecId
        if (rblSplit.Items[0].Selected == false && rblSplit.Items[1].Selected == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select Consider');", true);
            return;
        }
        if (Request.QueryString["RuleId"] != null)
        {


            try
            {

                int strRule = Convert.ToInt16(Request.QueryString["RuleId"]);

                htparam.Add("@RecId", Request.QueryString["RuleId"].ToString());
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


        htparam.Add("@Mapcode", Request.QueryString["mapcode"].ToString());
        htparam.Add("@FrequencyType", ddlfreguency.SelectedValue.ToString());
        htparam.Add("@Consider", rblSplit.SelectedValue.ToString());
        htparam.Add("@Type", ddltype.SelectedValue.ToString());
        htparam.Add("@Weightage", TxtWeg.Text);
        htparam.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        objDal.GetDataSetForPrc_SAIM("Prc_PremiumFreqDef_SaveData", htparam);//Changed by Abuzar on 14/10/2020
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "doCancel();", true);//doOk('007','S')

    }
    protected void rblSplit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSplit.SelectedValue.ToString() == "EX")
        {
            TxtWeg.Text = "0";
            TxtWeg.Enabled = false;
            ddltype.SelectedValue = "1003";
            ddltype.Enabled = false;
        }
        else
        {

            TxtWeg.Text = "";
            TxtWeg.Enabled = true;
            ddltype.SelectedIndex = 0;
            ddltype.Enabled = true;
        }

        rblSplit.Focus();

    }

   
}



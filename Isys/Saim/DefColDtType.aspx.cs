using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DataAccessClassDAL;
using System.Globalization;

public partial class Application_Isys_Saim_DefColDtType : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    Hashtable htparam = new Hashtable();
    DataSet dsfill = new DataSet();
    string kpicode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CallVal"] != "")
            {
                TextBoxCol.Text = Request.QueryString["CallVal"].ToString(); ;
            }
            Bindddl(ddlDT);
        }

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {

        if (ddlDT.SelectedItem.Text == "SELECT")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Data Type');", true);
            return;


        }
        else
        {

            hndCode.Value = "CONVERT(" + ddlDT.SelectedItem.Text;
        }
        //SELECT CONVERT(datetime, '2017-08-25');
        //CONVERT(data_type(length), expression, style)
        //convert(decimal(18,2),prem_amt)
        if (txtLen.Text != "")
        {

            if ((ddlDT.SelectedValue.ToString() == "106" || ddlDT.SelectedValue.ToString() == "108"))
            {
                if (txtScale.Text == "")
                {

                    hndCode.Value = hndCode.Value + "(" + txtLen.Text.ToString() + "),";
                }

                else
                {
                    hndCode.Value = hndCode.Value + "(" + txtLen.Text.ToString() + "," + txtScale.Text.ToString() + "),";

                }
            }
            else
            { hndCode.Value = hndCode.Value + "),"; }
          
        }

        else
        {
            hndCode.Value = hndCode.Value + ",";
        }


        

        //CONVERT(data_type(length), expression, style)
        if (TextBoxCol.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Column Name');", true);
            return;
        }

        else
        {
            hndCode.Value = hndCode.Value + TextBoxCol.Text.ToString();
        }

        if (TextBoxStyle.Text != "")
        {
            hndCode.Value = hndCode.Value + "," + TextBoxStyle.Text.ToString() + ")";
        }

        else
        {
            hndCode.Value = hndCode.Value + ")";
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Selected value is');", true);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", string.Format("alert('Selected value is :  {0}.');", hndCode.Value), true);

        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doSelect('" + Request.QueryString["FlagType"].ToString().Trim() + "','" + hndCode.Value.TrimStart(',') + "')", true);

        //'" + Request.QueryString["CallType"].ToString().Trim() + "',
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        TextBoxStyle.Text = "";
        txtLen.Text = "";
        TextBoxStyle.Text = "";
        Bindddl(ddlDT);
    }
    public void Bindddl(DropDownList ddl)
    {
        try
        {
            ds.Clear();
            ds = objDal.GetDataSetForPrc_SAIM("PRC_BASE_SRC_TBL_COL_DAT_TYP");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0];
                ddl.DataTextField = "DATA_TYP";
                ddl.DataValueField = "DATA_TYP_ID";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "DefColDtType", "Bindddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doSelect('','')", true);
    }

    protected void ddlDT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDT.SelectedValue.ToString() == "106" || ddlDT.SelectedValue.ToString() == "108")
        {
            txtScale.Enabled = true;

        }
    }
}
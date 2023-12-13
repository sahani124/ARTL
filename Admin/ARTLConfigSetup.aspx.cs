using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using DataAccessClassDAL;
//using INSCL.DAL;

public partial class Application_Admin_ARTLConfigSetup : BaseClass 
{
    //DataAccessLayerEPS on = new DataAccessLayerEPS();
    DataAccessClass objDAL = new DataAccessClass();
    //DataAccessLayerEPS objDAL = new DataAccessLayerEPS();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            BindGridView();
        }
    }

    public void BindGridView()
    {
        dsResult = objDAL.GetDataSetForPrc_DIRECT("Prc_GetArtlConfigDtl");
        
        gvARTLSetup.DataSource = dsResult;
        gvARTLSetup.DataBind();
        
    }
    protected void gvARTLSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dsResult1 = new DataSet();
        Hashtable htTable = new Hashtable();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            //  {
            var ddList = (DropDownList)e.Row.FindControl("ddlValue");
            //bind dropdownlist
             var txtDesc = (Label)e.Row.FindControl("lblDesc");

             if (txtDesc.Text == "Application No. in the system is" || txtDesc.Text == "Primary Reporting if Unit Rank is 1.0 in the system is")
             {

                 htTable.Add("@LookUpCode", "ConfigSU");
                 dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
                 htTable.Clear();
             }
             //bind dropdownlist
             else
             {
                 htTable.Add("@LookUpCode", "EnableMod");
                 dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
             }
                htTable.Clear();
            ddList.DataSource = dsResult1.Tables[0];
            ddList.DataTextField = "ParamDesc01";
            ddList.DataValueField = "ParamValue";
            ddList.DataBind();

            int i =  gvARTLSetup.Rows.Count;
            ddlValue.SelectedValue = dsResult.Tables[0].Rows[i]["Value"].ToString();
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvARTLSetup.Rows.Count > 0)
            {
                List<string> lst = new List<string>();
                List<string> lst1 = new List<string>();
                for (int rowcnt = 0; rowcnt <= gvARTLSetup.Rows.Count - 1; rowcnt++)
                {
                    Label lbl = (Label)gvARTLSetup.Rows[rowcnt].Cells[1].FindControl("lblDesc");
                    lst.Add(lbl.Text);
                    DropDownList ddList1 = (DropDownList)gvARTLSetup.Rows[rowcnt].Cells[2].FindControl("ddlValue");
                    lst1.Add(ddList1.SelectedValue.ToString());
                }
                for (int datacnt = 0; datacnt <= lst.Count - 1; datacnt++)
                {
                    htParam.Clear();
                    htParam.Add("@Desc", lst[datacnt]);
                    htParam.Add("@Value", lst1[datacnt]);
                    htParam.Add("@ModuleName", "ARTL");
                    htParam.Add("@UserID", Session["UserID"].ToString());
                    dsResult = null;
                    dsResult = objDAL.GetDataSetForPrc_inscdirect("Prc_UpdDataForConfigSU", htParam);
                    lblMsg.Text = "Data update successfuly";
                    lblMsg.Visible = true;
                    btnSave.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Do Data to update";
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
            lblMsg.Visible = true;

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       Server.Transfer("~/Application/ISys/SAIM/SEADTest.aspx");
       // Response.Redirect("~/Application/Admin/SearchUser.aspx");
    }
}
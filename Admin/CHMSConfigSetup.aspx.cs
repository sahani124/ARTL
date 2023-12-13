using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using DataAccessClassDAL;

public partial class Application_Admin_CHMSConfigSetup : BaseClass
{
    DataAccessClass objDAL = new DataAccessClass();
    //DataAccessLayerEPS objDAL = new DataAccessLayerEPS();
    Hashtable htParam = new Hashtable();
    DataSet dsResult = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
            // BindGridViewTest();
        }
    }

    private void BindGridView()
    {
        dsResult = objDAL.GetDataSetForPrc_DIRECT("Prc_GetCHMSConfigDtl");

        if (dsResult.Tables.Count > 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                gvCHMSSetup.DataSource = dsResult.Tables[0];
                gvCHMSSetup.DataBind();
            }
            else
            {
                gvCHMSSetup.AllowPaging = false;
                ShowNoResultFound(dsResult.Tables[0], gvCHMSSetup);
            }
        }
        else
        {
            gvCHMSSetup.AllowPaging = false;
            ShowNoResultFound(dsResult.Tables[0], gvCHMSSetup);  
        }
    }

    protected void gvCHMSSetup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dsResult1 = new DataSet();
        Hashtable htTable = new Hashtable();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ddList = (DropDownList)e.Row.FindControl("ddlValue");
            var txtDesc = (Label)e.Row.FindControl("lblDesc");

            if (txtDesc.Text == "Enable Modification of Channel Maintenance" || txtDesc.Text == "Enable Vendor")
            {

                htTable.Add("@LookUpCode", "EnableMod");
                dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
                htTable.Clear();
            }
            //bind dropdownlist
            else if (txtDesc.Text == "No. of Companies")
            {

                htTable.Add("@LookUpCode", "CountOfCompanies");
                dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
                htTable.Clear();

            }
            else if (txtDesc.Text == "No. of Channels")
            {

                htTable.Add("@LookUpCode", "CountOfChannels");
                dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
                htTable.Clear();

            }
            else
            {

                htTable.Add("@LookUpCode", "ConfigSU");
                dsResult1 = objDAL.GetDataSetForPrc_inscdirect("Prc_GetddlValue", htTable);
                htTable.Clear();
            }
            ddList.DataSource = dsResult1.Tables[0];
            ddList.DataTextField = "ParamDesc01";
            ddList.DataValueField = "ParamValue";
            ddList.DataBind();

            int i = gvCHMSSetup.Rows.Count;
            ddlValue.SelectedValue = dsResult.Tables[0].Rows[i]["Value"].ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvCHMSSetup.Rows.Count > 0)
            {
                List<string> lst = new List<string>();
                List<string> lst1 = new List<string>();
                for (int rowcnt = 0; rowcnt <= gvCHMSSetup.Rows.Count - 1; rowcnt++)
                {
                    Label lbl = (Label)gvCHMSSetup.Rows[rowcnt].Cells[1].FindControl("lblDesc");
                    lst.Add(lbl.Text);
                    DropDownList ddList1 = (DropDownList)gvCHMSSetup.Rows[rowcnt].Cells[2].FindControl("ddlValue");
                    lst1.Add(ddList1.SelectedValue.ToString());
                }
                for (int datacnt = 0; datacnt <= lst.Count - 1; datacnt++)
                {
                    if (lst[datacnt] == "Enable Vendor")
                    {
                        if (lst1[datacnt] == "YES")
                        {
                            EnableVendor();
                        }
                        else if (lst1[datacnt] == "NO")
                        {
                            DisableVendor();
                        }
                    }



                    htParam.Clear();
                    htParam.Add("@Desc", lst[datacnt]);

                    htParam.Add("@Value", lst1[datacnt]);
                    htParam.Add("@ModuleName", "CHMS");
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

    private void DisableVendor()
    {
        dsResult = objDAL.GetDataSetForPrc_DIRECT("Prc_DisableVendor");
    }

    private void EnableVendor()
    {
        dsResult = objDAL.GetDataSetForPrc_DIRECT("Prc_EnableVendor");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Application/ISys/SAIM/SEADTest.aspx");
    }

    private void ShowNoResultFound(DataTable source, GridView gv)
    {
        source.Rows.Add(source.NewRow());
        gv.DataSource = source;
        gv.DataBind();
        int columnsCount = gv.Columns.Count;
        int rowsCount = gv.Rows.Count;
        gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gv.Rows[0].Cells[columnsCount - 1].Text = "";
        gv.Rows[0].Cells[columnsCount - 2].Text = "";
        gv.Rows[0].Cells[0].Text = "No record found";
        source.Rows.Clear();
    }
}
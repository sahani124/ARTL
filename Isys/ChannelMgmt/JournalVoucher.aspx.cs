using DataAccessClassDAL;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Isys_ChannelMgmt_JournalVoucher : BaseClass
{
    DataAccessClass objDAL = new DataAccessClass();
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            BindGridView();
            
        }

    }
     protected void BindGridView()
    {
        try
        {
            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Search_Hdr_Jornal");
            gvJournal.DataSource = ds;
            gvJournal.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvJournal.DataSource = ds;
                gvJournal.DataBind();
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvJournal.DataSource = ds;
                gvJournal.DataBind();
                ViewState["grid"] = ds.Tables[0];

                ////txtPage.Text = dgDetails.PageCount.ToString();
                if (gvJournal.PageCount > Convert.ToInt32(txtPage.Text))
                {
                    gvJournal.Enabled = true;
                }
                else
                {
                    btnCompnext.Enabled = false;
                }
            }
            else
            {
                ShowNoResultFound1(ds.Tables[0], gvJournal);
                txtPage.Text = "1";
                btnCompprevious.Enabled = false;
                btnCompnext.Enabled = false;
            }

        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "BindGridView()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }

    }
    private void ShowNoResultFound1(DataTable source, GridView gv)    {        try        {            source.Rows.Add(source.NewRow());            gv.DataSource = source;            gv.DataBind();            int columnsCount = gv.Columns.Count;            int rowsCount = gv.Rows.Count;            gv.Rows[0].Cells[columnsCount - 1].Text = "";            gv.Rows[0].Cells[0].Text = "";            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;            gv.Rows[0].Cells[1].Text = "No Record Found";            source.Rows.Clear();        }        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "ShowNoResultFound1()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }    }
    protected void btnCompprevious_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gvJournal.PageIndex;
            gvJournal.PageIndex = pageIndex - 1;
            // RefreshComGrid();
            BindGridView();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnCompnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvJournal.PageCount))
            {
                btnCompprevious.Enabled = false;
            }
            int page = gvJournal.PageCount;
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "btnCompprevious_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }

    protected void btnCompnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = gvJournal.PageIndex;
            gvJournal.PageIndex = pageIndex + 1;
            //  RefreshComGrid();
            BindGridView();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnCompprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvJournal.PageCount))
            {
                btnCompnext.Enabled = false;
            }
            int page = gvJournal.PageCount;

        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "btnCompnext_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            string JournalVoucher = txtJournalVoucher.Text.Trim();



            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            gvJournal.DataSource = null;

            htParam1.Add("@JV_No", JournalVoucher);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Search_Hdr_Jornal", htParam1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvJournal.DataSource = ds;
                gvJournal.DataBind();
            }
            else
            {
                gvJournal.DataSource = ds;
                gvJournal.DataBind();
            }
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "btnSearch_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable htParam1 = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            htParam1.Add("@counterId", "JVNO");
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_GetCTRNO", htParam1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtJounalVoucherNo.Text = ds.Tables[0].Rows[0]["CTRNO"].ToString().Trim();
            }
            txtDate.Text = DateTime.Now.ToString("dd MMM yyyy");
            txtRefDocNo.Text = "";
            txtNarration.Value = "";
            lnkBtnSave.Enabled = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "popupHist();", true);
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "lnkAddNew_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtJournalVoucher.Text = "";
    }

    

    protected void btnCompprevious1_Click(object sender, EventArgs e)
    {

    }

    protected void btnCompnext1_Click(object sender, EventArgs e)
    {

    }

    protected void ddlTransType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlTransType.SelectedValue == "DR")
                FillDropDownAccountType("DR_JV");
            if (ddlTransType.SelectedValue == "CR")
                FillDropDownAccountType("CR_JV");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "popupHist();", true);
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "ddlTransType_SelectedIndexChanged()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }

    protected void FillDropDownAccountType(string Flag)
    {
        try
        {
            Hashtable htParam1 = new Hashtable();
            DataSet dsdataset = new DataSet();
            htParam1.Add("@Flag", Flag.ToString().Trim());
            dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_GetAccountList", htParam1);

            if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
            {
                ddlAccountName.DataSource = dsdataset;
                ddlAccountName.DataValueField = "LDGR_ACC_CODE";
                ddlAccountName.DataTextField = "LDGR_ACC_NAME";
                ddlAccountName.DataBind();
                ddlAccountName.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "FillDropDownAccountType()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }




    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable htParam1 = new Hashtable();
            DataSet dsdataset = new DataSet();

            string JournalVoucherJSON = Request.Form["JournalVoucherJSON"];
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JournalVoucherJSON);
            //Validation both Credit and Debit should match
            decimal Debit = 0;
            decimal Credit = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Debit"].ToString() != "")
                        Debit = Debit + Convert.ToDecimal(dt.Rows[i]["Debit"]);
                    if (dt.Rows[i]["Credit"].ToString() != "")
                        Credit = Credit + Convert.ToDecimal(dt.Rows[i]["Credit"]);
                }
            }
            if (Debit != Credit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Debit and Credit Amount should be same');popupHist();", true);
                return;
            }

            //Validation both Credit and Debit should match




            if (dt.Rows.Count > 0)
            {
                //Insert HDR Table 

                htParam1.Clear();
                htParam1.Add("@PVNO", txtJounalVoucherNo.Text.ToString().Trim());
                htParam1.Add("@Date", txtDate.Text.ToString().Trim());
                htParam1.Add("@Narration", txtNarration.Value.ToString().Trim());
                htParam1.Add("@REF_DOC_NO", txtRefDocNo.Text.ToString().Trim());
                htParam1.Add("@Flag", "HDR");
                dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_InsertJournalVoucher", htParam1);

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    ds.Clear();
                    htParam1.Clear();
                    htParam1.Add("@PVNO", txtJounalVoucherNo.Text.ToString().Trim());
                    htParam1.Add("@TransType", dt.Rows[i]["TransactionType"].ToString());
                    htParam1.Add("@AccountName", dt.Rows[i]["AccountName"].ToString());
                    htParam1.Add("@Debit", dt.Rows[i]["Debit"].ToString());
                    htParam1.Add("@Credit", dt.Rows[i]["Credit"].ToString());
                    htParam1.Add("@Flag", "TXN");
                    htParam1.Add("@UserId", Session["UserID"].ToString().Trim());
                    ds = objDAL.GetDataSetForPrc_SAIM("Prc_InsertJournalVoucher", htParam1);
                }
            }
            if (dsdataset.Tables[0].Rows[0]["Exists"].ToString() == "True" && ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "alert('Record Saved Successfully');popupHist();", true);
                lnkBtnSave.Enabled = false;
            }


        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "lnkBtnSave_Click()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }

    }

    protected void gvJournal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvJournal.EditIndex = e.NewEditIndex;
        this.BindGridView();
    }

    protected void gvJournal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Hashtable htobj = new Hashtable();
            DataSet ds = new DataSet();
            GridViewRow row = gvJournal.Rows[e.RowIndex];
            string JV_NO = ((Label)row.FindControl("lblJournalVoNo")).Text.ToString();
            htobj.Clear();
            ds.Clear();
            htobj.Add("@JV_NO", Convert.ToInt32(JV_NO));
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_Delet_Journal_Voucher", htobj);
            if (ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Deleted Successfully');", true);

            }
            BindGridView();
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "gvJournal_RowDeleting()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }

    protected void gvJournal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvJournal.EditIndex = -1;
        this.BindGridView();
    }

    protected void gvJournal_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Hashtable htParam1 = new Hashtable();
        DataSet objds = new DataSet();
        htParam1.Clear();
        objds.Clear();

        GridViewRow row = gvJournal.Rows[e.RowIndex];
        string JV_NO = ((Label)row.FindControl("lblJournalVoNoEdit")).Text.ToString();
        string txtNurration = ((TextBox)row.FindControl("txtNarrationEdit")).Text.ToString();
        string txtRefDocNo = ((TextBox)row.FindControl("txtRefDocNoEdit")).Text.ToString();


        if (txtNurration != null && txtNurration.Trim() != "")
        {
            htParam1.Add("@NARRATION", txtNurration);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Nurration');", true);
            return;
        }
        if (txtRefDocNo != null && txtRefDocNo.Trim() != "")
        {
            htParam1.Add("@REF_DOC_NO", txtRefDocNo);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Reference Doc No')", true);
            return;
        }
        htParam1.Add("@JV_NO", JV_NO);
        htParam1.Add("@Flag", "HDR");
        objds = objDAL.GetDataSetForPrc_SAIM("Prc_Update_Journal_Voucher", htParam1);
        gvJournal.EditIndex = -1;
        BindGridView();
        if (objds.Tables[0].Rows[0]["Exists"].ToString() == "Data updated")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Updated Successfully');", true);
        }

    }
    protected void FillTxnGrid(string Flag)
    {
        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        htParam1.Clear();
        htParam1.Add("@JV_NO", Convert.ToInt32(Flag));
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_GET_TXN_DETAILS", htParam1);
        gvTxnDetails.DataSource = ds;
        gvTxnDetails.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);
    }
    protected void gvJournal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvJournal.Rows[rowIndex];
                string JV_NO = (row.FindControl("lblJournalVoNo") as Label).Text;
                FillTxnGrid(JV_NO);
            }
        }
        catch (Exception ex)        {

            objErr.LogErr("ISYS-SAIM", "JournalVoucher.aspx.cs", "gvJournal_RowCommand()", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }
    }

    protected void gvTxnDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTxnDetails.EditIndex = e.NewEditIndex;
        Label PV_NO = gvTxnDetails.Rows[e.NewEditIndex].FindControl("lblJournalVoucherNo") as Label;
        FillTxnGrid(PV_NO.Text.ToString());
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);

    }

    protected void gvTxnDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTxnDetails.EditIndex = -1;
        Label PV_NO = gvTxnDetails.Rows[e.RowIndex].FindControl("lblJournalVoucherNoEdit") as Label;
        FillTxnGrid(PV_NO.Text.ToString());
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);

    }

    protected void gvTxnDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Hashtable htParam1 = new Hashtable();
        DataSet objds = new DataSet();
        htParam1.Clear();
        objds.Clear();

        GridViewRow row = gvTxnDetails.Rows[e.RowIndex];
        string TxnType = ((Label)row.FindControl("lblTxnTypeEdit")).Text.ToString();
        string JV_NO = ((Label)row.FindControl("lblJournalVoucherNoEdit")).Text.ToString();
        string JournalTxnNo = ((Label)row.FindControl("lblJournalTxnNoEdit")).Text.ToString();
        string AccountName = ((DropDownList)row.FindControl("ddlAccountNameEdit")).SelectedItem.Text.ToString();
        string DebitAmount = ((TextBox)row.FindControl("txtDebitAmountEdit")).Text.ToString();
        string CreditAmount = ((TextBox)row.FindControl("txtCreditAmountEdit")).Text.ToString();
        htParam1.Add("@JV_TXN_NO", JournalTxnNo);
        htParam1.Add("@ACCOUNT_NAME", AccountName);
        htParam1.Add("@DEBIT_AMT", DebitAmount);
        htParam1.Add("@CREDIT_AMT", CreditAmount);
        if (TxnType == "Credit")
        {
            htParam1.Add("@Flag", "CRT");
        }
        if (TxnType == "Debit")
        {
            htParam1.Add("@Flag", "DBT");
        }

         objds = objDAL.GetDataSetForPrc_SAIM("Prc_Update_Journal_Voucher", htParam1);
        if (TxnType.ToString() == "Credit")
        {          
            Hashtable htParm = new Hashtable();
            DataSet ds = new DataSet();
            htParam1.Clear();
            htParam1.Add("@JV_NO", JV_NO);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_GET_TXN_DETAILS", htParam1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for(int i=0; i <= ds.Tables[0].Rows.Count-1; i++)
                {
                   if(ds.Tables[0].Rows[i]["TXN_TYPE"].ToString() == "Debit")
                    {
                        string JV_TXN_NO = ds.Tables[0].Rows[i]["JV_TXN_NO"].ToString();
                        DataSet ds1 = new DataSet();
                        Hashtable ht1 = new Hashtable();
                        ht1.Add("@JV_TXN_NO", JV_TXN_NO);
                        ht1.Add("@DEBIT_AMT", CreditAmount);
                        ht1.Add("@Flag", "DBT");
                        ds1 = objDAL.GetDataSetForPrc_SAIM("Prc_Update_Amount", ht1);
                    }
                }
            }
           

        }
        else
        {
            Hashtable htParm = new Hashtable();
            DataSet ds = new DataSet();
            ds.Clear();
            htParm.Clear();
            htParm.Add("@JV_NO", JV_NO);
            ds = objDAL.GetDataSetForPrc_SAIM("Prc_GET_TXN_DETAILS", htParm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (ds.Tables[0].Rows[i]["TXN_TYPE"].ToString() == "Credit")
                    {
                        string JV_TXN_NO = ds.Tables[0].Rows[i]["JV_TXN_NO"].ToString();
                        DataSet ds1 = new DataSet();
                        Hashtable ht1 = new Hashtable();
                        ht1.Add("@JV_TXN_NO", JV_TXN_NO);
                        ht1.Add("@CREDIT_AMT", DebitAmount);
                        ht1.Add("@Flag", "CRT");
                        ds1 = objDAL.GetDataSetForPrc_SAIM("Prc_Update_Amount", ht1);
                    }
                }
            }


        }
        gvTxnDetails.EditIndex = -1;
        FillTxnGrid(JV_NO.ToString());
        if (objds.Tables[0].Rows[0]["Exists"].ToString() == "Data updated")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Updated Successfully');OpenElement();", true);
        }

    }

    protected void gvTxnDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == gvTxnDetails.EditIndex)
        {

            string TxnType = ((e.Row.FindControl("lblTxnTypeEdit") as Label).Text).ToString();
            string AcountName = ((e.Row.FindControl("lblAccountNameEdit") as Label).Text).ToString();

            DropDownList ddlAccountName = (DropDownList)e.Row.FindControl("ddlAccountNameEdit");
            Hashtable htParam1 = new Hashtable();
            DataSet dsdataset = new DataSet();
            if (TxnType.ToString().Trim() == "Debit")
            {
                htParam1.Add("@Flag", "DR_JV");
                
                TextBox CREDIT=(e.Row.FindControl("txtCreditAmountEdit") as TextBox);
                CREDIT.Enabled = false;

                
            }
            if (TxnType.ToString().Trim() == "Credit")
            {
                htParam1.Add("@Flag", "CR_JV");//lblDebitAmountEdit
                TextBox Debit = (e.Row.FindControl("txtDebitAmountEdit") as TextBox);
                Debit.Enabled = false;
            
               
            }

            dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_GetAccountList", htParam1);

            if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
            {
                ddlAccountName.DataSource = dsdataset;
                ddlAccountName.DataValueField = "LDGR_ACC_CODE";
                ddlAccountName.DataTextField = "LDGR_ACC_NAME";
                ddlAccountName.DataBind();
                ddlAccountName.Items.Insert(0, new ListItem("Select", ""));
            }
           ddlAccountName.Items.FindByText(AcountName).Selected = true;
           
        }

    }
}
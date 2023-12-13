using CLTMGR;
using DataAccessClassDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Xml;

public partial class Application_Isys_ChannelMgmt_GeneralLedgerAccounts : BaseClass
{
    SqlDataReader dtRead;
    string saleschannel;
    string ErrMsg;
    string AuditType;
    string Flag;
    DataSet dsResult = new DataSet();
    string strDesc01 = string.Empty;
    string strModule = string.Empty;
    string strValue = string.Empty;
    Hashtable htable = new Hashtable();
    XmlDocument doc = new XmlDocument();
    //  private multilingualManager olng;
    private string strUserLang;
    DataAccessClass objDAL = new DataAccessClass();
    EncodeDecode ObjDec = new EncodeDecode();
    ErrLog objErr = new ErrLog();
    INSCL.App_Code.CommonUtility oCommon = new INSCL.App_Code.CommonUtility();
    string ChnTyp = string.Empty;
    string Insuranctype = string.Empty;
    string Comp = string.Empty;
    string YrIncorporation = string.Empty;
    string LcnNo = string.Empty;
    string RegOfficeAddr = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGroupName();
            BindGridView();
            fillDropDownGrpName();
        }
    }
    protected void BindGridView()
    {
        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        htParam1.Clear();
        htParam1.Add("@Flag", "SelectAll");
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_GetLDGRDetails", htParam1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            dgDetails.DataSource = ds;
            dgDetails.DataBind();
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dgDetails.DataSource = ds;
            dgDetails.DataBind();
            ViewState["grid"] = ds.Tables[0];

            ////txtPage.Text = dgDetails.PageCount.ToString();
            if (dgDetails.PageCount > Convert.ToInt32(txtPage.Text))
            {
                btnCompnext.Enabled = true;
            }
            else
            {
                btnCompnext.Enabled = false;
            }
        }
        else
        {
            ShowNoResultFound1(ds.Tables[0], dgDetails);
            txtPage.Text = "1";
            btnCompprevious.Enabled = false;
            btnCompnext.Enabled = false;
        }
    }
    private void ShowNoResultFound1(DataTable source, GridView gv)    {        try        {            source.Rows.Add(source.NewRow());            gv.DataSource = source;            gv.DataBind();            int columnsCount = gv.Columns.Count;            int rowsCount = gv.Rows.Count;            gv.Rows[0].Cells[columnsCount - 1].Text = "";            gv.Rows[0].Cells[0].Text = "";            gv.Rows[0].Cells[1].ForeColor = System.Drawing.Color.Red;            gv.Rows[0].Cells[1].Text = "No compensations have been defined";            source.Rows.Clear();        }        catch (Exception ex)        {
         
            objErr.LogErr("ISYS-SAIM", "CompStpSrch", "ShowNoResultFound1", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());        }    }
    protected void fillDropDownGrpName()
    {
        Hashtable htParam1 = new Hashtable();
        DataSet dsdataset = new DataSet();

        dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_FilldrpGroupName", htParam1);

        if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
        {
            ddlGRPCODE.DataSource = dsdataset;
            ddlGRPCODE.DataValueField = "GRP_CODE";
            ddlGRPCODE.DataTextField = "GRP_NAME1";
            ddlGRPCODE.DataBind();
            ddlGRPCODE.Items.Insert(0, new ListItem("Select", ""));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string grpcode = String.Empty;
        string isActive = String.Empty;
        string LedgerAccCode = txtLDGRACCCODE.Text.Trim();
        if (ddlGRPCODE.SelectedIndex != 0)
        {
            grpcode = ddlGRPCODE.SelectedValue;
        }
        if (ddlIsactive.SelectedIndex != 0)
        {
            isActive = ddlIsactive.SelectedValue;
        }


        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        htParam1.Clear();
        dgDetails.DataSource = null;
        htParam1.Add("@LedAccCode", LedgerAccCode);
        htParam1.Add("@GrpCode", grpcode);
        htParam1.Add("@IsActive", isActive);
        htParam1.Add("@Flag", "Select");
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_GetLDGRDetails", htParam1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgDetails.DataSource = ds;
            dgDetails.DataBind();
        }
        else
        {
            dgDetails.DataSource = ds;
            dgDetails.DataBind();
        }
    }

    protected void dgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Hashtable htobj = new Hashtable();
        DataSet ds = new DataSet();
        GridViewRow row = dgDetails.Rows[e.RowIndex];
        string LedgerAccCode = ((Label)row.FindControl("lblLedgeraccount")).Text.ToString();
        htobj.Clear();
        ds.Clear();
        htobj.Add("@LedAccCode", LedgerAccCode);
        htobj.Add("@Flag", "Delete");
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_GetLDGRDetails", htobj);
        //if (ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
        //{
         ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Deleted Succesfully');", true);

        //}
        BindGridView();
    }

    protected void dgDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Hashtable htParam1 = new Hashtable();
        DataSet objds = new DataSet();
        htParam1.Clear();
        objds.Clear();

        GridViewRow row = dgDetails.Rows[e.RowIndex];
        string lblEditLederAccount = ((Label)row.FindControl("lblEditLedgeraccount")).Text.ToString();
        string txtEditaccname = ((TextBox)row.FindControl("txtEditaccname")).Text.ToString();
        string ddlEditGrpCode = ((DropDownList)row.FindControl("ddlEditGrpCode")).Text.ToString();
        string faGlcode = ((TextBox)row.FindControl("txtFaGlcodeEdit")).Text.ToString();
        string ddlEditIsActive = ((DropDownList)row.FindControl("ddlEditIsActive")).Text.ToString();

        string UpdatedBy = HttpContext.Current.Session["UserID"].ToString().Trim();
        htParam1.Add("@UpdatedBy", UpdatedBy);
       

        if (txtEditaccname != null && txtEditaccname.Trim() != "")
        {
            htParam1.Add("@LDGR_ACC_NAME", txtEditaccname);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Account Name');", true);
            return;
        }
        if (ddlEditGrpCode != null && ddlEditGrpCode.Trim() != "")
        {
            htParam1.Add("@GRP_CODE", ddlEditGrpCode);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Select Group Name');", true);
            return;
        }
        if (ddlEditIsActive != null && ddlEditIsActive.Trim() != "")
        {
            htParam1.Add("@IsActive", ddlEditIsActive);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Select Status');", true);
            return;
        }
        if (faGlcode != null && faGlcode.Trim() != "")
        {
            htParam1.Add("@FA_GL_CODE", faGlcode);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter FA GL Code');", true);
            return;
        }
        htParam1.Add("@LDGR_ACC_CODE", lblEditLederAccount);
        htParam1.Add("@Action", "UPT");
        objds = objDAL.GetDataSetForPrc_SAIM("Prc_Ins_Mst_Ledger_Acnt", htParam1);
        dgDetails.EditIndex = -1;
        BindGridView();
        if (objds.Tables[0].Rows[0]["Exists"].ToString() == "Data updated")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Updated Successfully');", true);
        }
    }

    protected void dgDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgDetails.EditIndex = e.NewEditIndex;
        this.BindGridView();
        //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "OpenElement();", true);

    }

    protected void dgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == dgDetails.EditIndex)
            {
                TextBox TxtEditAccName = (TextBox)e.Row.FindControl("txtEditaccname");
                TxtEditAccName.Text = ((e.Row.FindControl("lblEditaccname") as Label).Text).ToString();

                DropDownList ddlEditGrpCode = (DropDownList)e.Row.FindControl("ddlEditGrpCode");
                DataSet objds = new DataSet();
                Hashtable htParam1 = new Hashtable();
                objds.Clear();
                htParam1.Clear();

                objds = objDAL.GetDataSetForPrc_SAIM("Prc_FilldrpGroupName", htParam1);
                ddlEditGrpCode.DataSource = objds;
                ddlEditGrpCode.DataTextField = "GRP_NAME1";
                ddlEditGrpCode.DataValueField = "GRP_CODE";
                ddlEditGrpCode.DataBind();
                ddlEditGrpCode.Items.Insert(0, new ListItem("Select", ""));

                string strgrpcode = ((e.Row.FindControl("lbleditgrpcode") as Label).Text).ToString();

                ddlEditGrpCode.SelectedValue = strgrpcode.Substring(0,5);

                DropDownList drpdwnEditIsActive = (DropDownList)e.Row.FindControl("ddlEditIsActive");
                if ((e.Row.FindControl("lblEditIsactivee") as Label).Text.ToString() != string.Empty)
                    drpdwnEditIsActive.Items.FindByText((e.Row.FindControl("lblEditIsactivee") as Label).Text).Selected = true;
             
                else
                    drpdwnEditIsActive.Items.FindByText((e.Row.FindControl("lblEditIsactivee") as Label).Text).Selected = true;
            
            }
        }
        catch (Exception ex)
        {

        }


        //fillDropDownGrpName();
    }

    protected void dgDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dgDetails.EditIndex = -1;
        this.BindGridView();
    }

    protected void FillGroupName()
    {

        Hashtable htParam1 = new Hashtable();
        DataSet dsdataset = new DataSet();

        dsdataset = objDAL.GetDataSetForPrc_SAIM("Prc_Fill_GrpName", htParam1);

        if (dsdataset.Tables.Count > 0 && dsdataset.Tables[0].Rows.Count > 0)
        {

            ddlGrpName.DataSource = dsdataset;
            ddlGrpName.DataValueField = "PramValue";
            ddlGrpName.DataTextField = "PramDesc";
            ddlGrpName.DataBind();
        }
        ddlGrpName.Items.Insert(0, "Select(Group Name)");

    }

    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        txtLegAcntCode.Text = "";
        txtLegAcntName.Text = "";
        ddlGrpName.SelectedIndex = 0;
        txtFaglCode.Text = "";
       
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "popupHist();", true);
    }

    protected void lnkBtnSave_Click(object sender, EventArgs e)
    {
        Hashtable htParam1 = new Hashtable();
        DataSet ds = new DataSet();
        string LedgerAcntCode = txtLegAcntCode.Text.ToString();
        string LegAcntName = txtLegAcntName.Text.ToString();

        string GroupCode = ddlGrpName.SelectedValue.ToString();
        string GroupName = ddlGrpName.SelectedItem.ToString();
        string Faglcode = txtFaglCode.Text.ToString();
        htParam1.Clear();
        string CreatedBy = HttpContext.Current.Session["UserID"].ToString().Trim();

        if (LegAcntName != null && LegAcntName.Trim() != "")
        {
            htParam1.Add("@LDGR_ACC_NAME", LegAcntName);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter Account Name');popupHist();", true);
            return;
        }
        if (ddlGrpName.SelectedValue.ToString() != null && ddlGrpName.SelectedValue.ToString() != "")
        {
            htParam1.Add("@GRP_CODE", GroupCode);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Select Group Name');popupHist();", true);
            return;
        }
        htParam1.Add("@CreatedBy", CreatedBy);
        if (Faglcode != null && Faglcode != "")
        {
            htParam1.Add("@FA_GL_CODE", Faglcode);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Please Enter FA GL Code');popupHist();", true);
            return;
        }
       
        
        htParam1.Add("@COUNTERFLAG", GroupCode.Substring(0, 1));

        htParam1.Add("@Action", "INS");
        ds = objDAL.GetDataSetForPrc_SAIM("Prc_Ins_Mst_Ledger_Acnt", htParam1);
        if (ds.Tables[0].Rows[0]["Exists"].ToString() == "True")
        {
            txtLegAcntCode.Text = ds.Tables[0].Rows[0]["LDGR_ACC_CODE"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Record Saved successfully');popupHist();", true);
        }

    }
    protected void btnCompprevious_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex - 1;
            // RefreshComGrid();
            BindGridView();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            btnCompnext.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            {
                btnCompprevious.Enabled = false;
            }
            int page = dgDetails.PageCount;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnCompnext_Click(object sender, EventArgs e)
    {
        try
        {

            int pageIndex = dgDetails.PageIndex;
            dgDetails.PageIndex = pageIndex + 1;
            //  RefreshComGrid();
            BindGridView();

            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnCompprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgDetails.PageCount))
            {
                btnCompnext.Enabled = false;
            }
            int page = dgDetails.PageCount;

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-RGIC", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkBtnClear_Click(object sender, EventArgs e)
    {
        txtLegAcntCode.Text = "";
        txtLegAcntName.Text = "";
        ddlGrpName.SelectedIndex = 0;
        txtFaglCode.Text = "";
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "popupHist();", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtLDGRACCCODE.Text = "";
        ddlGRPCODE.SelectedIndex = 0;
        ddlIsactive.SelectedIndex = 0;
    }
}
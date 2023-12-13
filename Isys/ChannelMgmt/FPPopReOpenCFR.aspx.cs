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

public partial class Application_ISys_ChannelMgmt_FPPopReOpenCFR : BaseClass
{
    private DataAccessClass DataAccessClass = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        tblMain.Visible = true;
        string RemarkId = Request.QueryString["RemarkId"].ToString().Trim();
        string Remarks = Request.QueryString["Remarks"].ToString().Trim();
        String ModuleID = Request.QueryString["ModuleID"].ToString().Trim();
        //txtDescValue.Text = Remarks;
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Hashtable httable = new Hashtable();
        string RemarkId = Request.QueryString["RemarkId"].ToString().Trim();
        httable.Add("@RemarkId", Convert.ToInt32(RemarkId));
        httable.Add("@CreatedBy", Session["UserID"].ToString().Trim());
        httable.Add("@CFRRemark", txtDescValue.Text.Trim());
        httable.Add("@ModuleID", Request.QueryString["ModuleID"].ToString().Trim());
        int x = DataAccessClass.execute_sprcMemrecruit("Prc_InsMemCFRReOpen", httable);
        ScriptManager.RegisterStartupScript(this, GetType(), "javascript", "alert('CFR Reopened Successfully')", true);//added by sanoj 115062023
    }
}
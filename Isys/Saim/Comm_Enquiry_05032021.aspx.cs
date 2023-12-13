using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DataAccessClassDAL;
using System.IO;
using System.Net;

public partial class Application_Isys_Saim_Comm_Enquiry : BaseClass
{
    DataSet Ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string strCompCode = null;
    string filename = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            string sUserId = HttpContext.Current.Session["UserID"].ToString();

            if (sUserId == "cmpreview" || sUserId == "cmpchecker")
            {
               // btnAddNew.Enabled = false;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["Flag"] != null)
                {
                    if (Request.QueryString["Flag"].ToString()=="COM")
                    {
                        txtPage.Text = "1";
                        lblhdr.Text = "Commisson Enquiry";
                        //UpdatePanel4.Visible = false;
                        dgCmpStEq.Visible = false;
                        LinkButton1.Visible = false;
                        lblCmpSrch.Text ="Commisson Enquiry Results";
                        FillDropDoun(ddlCompCode,"COM");
                      
                    }
                    if (Request.QueryString["Flag"].ToString() == "INC")
                    {
                        txtPage.Text = "1";
                        lblhdr.Text = "Incentive Enquiry";
                        //UpdatePanel4.Visible = false;
                        dgCmpStEq.Visible = false;
                        LinkButton1.Visible = false;
                        lblCmpSrch.Text = "Incentive Enquiry Results";
                        FillDropDoun(ddlCompCode, "INC");
                       
                    }
                    if (Request.QueryString["Flag"].ToString() == "CON")
                    {
                        txtPage.Text = "1";
                        lblhdr.Text = "Contest Enquiry Criteria";
                        //UpdatePanel4.Visible = false;
                        dgCmpStEq.Visible = false;
                        LinkButton1.Visible = false;
                        lblCmpSrch.Text = "Contest Enquiry Results";
                        FillDropDoun(ddlCompCode, "CON");
                      
                    }
                }
              
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }


    }
    protected void FillDropDoun(DropDownList ddl,string flag)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", flag.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetCmpCode", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "CMPNSTN_DESC01";
            ddl.DataValueField = "CMPNSTN_CODE";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            dgCmpStEq.Visible = true;
            LinkButton1.Visible = true;
            EnblDsblAct();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "btnSearch_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
     }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        try
        {

            ddlCompCode.SelectedValue = "";
            ddlContCode.SelectedValue = "";
            ddlRSetKey.SelectedValue = "";
           
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "btnCancel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlCompCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlContCode.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@CODE", ddlCompCode.SelectedValue.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetCntsentCode", ht);
        if (drRead.HasRows)
        {
            ddlContCode.DataSource = drRead;
            ddlContCode.DataValueField ="CNTSTNT_CODE"; 

ddlContCode.DataTextField = "MemTypeDesc01";
           
            ddlContCode.DataBind();
            ddlContCode.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();



    }



    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;

       
           HiddenField hdnBusiCode = (HiddenField)grd.FindControl("hdnBusiCode");
           Label lblRuleCode = (Label)grd.FindControl("lblRuleCode");
           Label lblMemcode = (Label)grd.FindControl("lblMemcode");
           HiddenField hdnCatgCode = (HiddenField)grd.FindControl("hdnCatgCode");

         //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "openInWindow('" + CmpCode + "','" + CntstCode + "','" + MEMBERCODE + "');", true);

           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowPopup", "funAddmaster2('" + ddlCompCode.SelectedValue.ToString().Trim() + "','" +
              ddlContCode.SelectedValue.ToString().Trim() + "','" +
              Request.QueryString["Flag"].ToString().Trim() + "','" + ddlRSetKey.SelectedValue.ToString().Trim() + "','" + hdnBusiCode.Value.ToString() + "','" + lblRuleCode.Text + "','" + lblMemcode.Text + "','" + hdnCatgCode.Value.ToString() + "','" + Request.QueryString["Flag2"].ToString().Trim() + "');", true);



           //GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
           //LinkButton lnkCnstCode = (LinkButton)row.FindControl("lnkCnstCode");
           //HiddenField lblCmpDsc = (HiddenField)row.FindControl("lblCmpDsc");
           //Response.Redirect("CntstStp_INC.aspx?CmpCode=" + txtCompCode.Text.ToString().Trim() + "&CntstCode=" + lnkCnstCode.Text.ToString().Trim() + "&CmpTyp=" + Request.QueryString["CmpTyp"].ToString().Trim() + "&Mode=" + Request.QueryString["Mode"].ToString().Trim());


    }

    protected void ddlContCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlRSetKey.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@CMPNSTN_CODE", ddlCompCode.SelectedValue.ToString());
        ht.Add("@CNTSTNT_CODE", ddlContCode.SelectedValue.ToString());
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetRuleSetKey", ht);
        if (drRead.HasRows)
        {
            ddlRSetKey.DataSource = drRead;
            ddlRSetKey.DataTextField = "RuleSetDesc";
            ddlRSetKey.DataValueField = "RuleSetCode";
            ddlRSetKey.DataBind();
            ddlRSetKey.Items.Insert(0, new ListItem("-- SELECT --", ""));

        }
        drRead.Close();
    }
    protected DataSet BindData(string CmpnstnCode, string CNTSTNCODE, string RULESETKEY,  string flag)
    {

        Ds.Clear();
        htParam.Clear();
        htParam.Add("@CMPNSTN_CODE", CmpnstnCode.ToString().Trim());
        htParam.Add("@CNTSTN_CODE", CNTSTNCODE.ToString().Trim());
        htParam.Add("@RULE_SET_KEY", RULESETKEY.ToString().Trim());
        htParam.Add("@Flag", flag.ToString().Trim());
        htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
        Ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCommStaEnquiry", htParam);
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
          
            dgCmpStEq.DataSource = Ds;
            dgCmpStEq.DataBind();
            if (dgCmpStEq.PageCount > Convert.ToInt32(txtPage.Text))
            {
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
        }
        return Ds;
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmpStEq.PageIndex;
            dgCmpStEq.PageIndex = pageIndex + 1;
          
            EnblDsblAct();
            
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(dgCmpStEq.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = dgCmpStEq.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = dgCmpStEq.PageIndex;
            dgCmpStEq.PageIndex = pageIndex - 1;
          
             EnblDsblAct();
          
          
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) - 1);
            if (txtPage.Text == "1")
            {
                btnprevious.Enabled = false;
            }
            else
            {
                btnprevious.Enabled = true;
            }
            btnnext.Enabled = true;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    protected void EnblDsblAct()
    {
        try
        {
            if (Request.QueryString["flag"] != null)
            {
                if (Request.QueryString["flag"].ToString().Trim() == "COM")
                {
                   Ds=BindData(ddlCompCode.SelectedValue.ToString(), ddlContCode.SelectedValue.ToString().Trim(), ddlRSetKey.SelectedValue.ToString().Trim(),Request.QueryString["flag"].ToString().Trim());  
                 if(Ds.Tables.Count>0)
                    {
                        if(Ds.Tables[0].Rows.Count>0)
                        {
                           
                          
                        }
                    }
                }
                if (Request.QueryString["flag"].ToString().Trim() == "INC")
                {
                   Ds=BindData(ddlCompCode.SelectedValue.ToString(), ddlContCode.SelectedValue.ToString().Trim(), ddlRSetKey.SelectedValue.ToString().Trim(), Request.QueryString["flag"].ToString().Trim());
                   if(Ds.Tables.Count>0)
                    {
                        if(Ds.Tables[0].Rows.Count>0)
                        {
                            dgCmpStEq.Columns[2].Visible = false;
                            dgCmpStEq.Columns[4].Visible = false;
                        }
                        else
                        {
                           
                        }
                    }
                }
            } 
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "EnblDsblAct", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            Hashtable htVerify = new Hashtable();

            DataTable dtResult = new DataTable();
            htVerify.Clear();
            Ds.Clear();
            filename = "";

            htParam.Add("@CMPNSTN_CODE", ddlCompCode.SelectedValue.ToString());
            htParam.Add("@CNTSTN_CODE", ddlContCode.SelectedItem.ToString().Trim());
            htParam.Add("@RULE_SET_KEY", ddlRSetKey.SelectedValue.ToString().Trim());
            htParam.Add("@Flag", Request.QueryString["flag"].ToString().Trim());
            htParam.Add("@UserID", HttpContext.Current.Session["UserID"].ToString().Trim());
            htParam.Add("@ExportFlag", "E");
            Ds = objDal.GetDataSetForPrc_SAIM("Prc_GetCommStaEnquiry", htParam);
            dtResult = Ds.Tables[0];
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Verified  Successfully')", true);

                    if (Request.QueryString["flag"].ToString() == "COM")
                    {
                        ExportCSV(dtResult, "Commission");
                    }

                    if (Request.QueryString["flag"].ToString() == "INC")
                    {
                        ExportCSV(dtResult, "Incentive");
                    }

                    if (Request.QueryString["flag"].ToString() == "CON")
                    {
                        ExportCSV(dtResult, "COM");
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ok", "alert('Data Not Existed')", true);

                }

            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "LinkButton1_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public int ExportCSV (DataTable data, string fileName)
    {
        int Rest = 0;
        try
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".csv");

            //rite column header names
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i > 0)
                {
                    context.Response.Write(",");
                }
                context.Response.Write(data.Columns[i].ColumnName);
            }
            context.Response.Write(Environment.NewLine);
            //Write data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        //row[i] = row[i].ToString().Replace(",", "");
                        context.Response.Write(",");

                        if (row[i].ToString() == "2252719")
                        {

                            string str = "12042468";
                        }
                    }
                    string strWrite = row[i].ToString();
                    strWrite = strWrite.Replace("<br>", "");
                    strWrite = strWrite.Replace("<br/>", "");
                    strWrite = strWrite.Replace("\n", "");
                    strWrite = strWrite.Replace("\t", "");
                    strWrite = strWrite.Replace("\r", "");
                    strWrite = strWrite.Replace(",", "");
                    strWrite = strWrite.Replace("\"", "");


                    context.Response.Write(strWrite);
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            objErr.LogErr("ISYS-SAIM", "Comm_Enquiry", "ExportCSV", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());

        }
        return Rest;

     
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

}







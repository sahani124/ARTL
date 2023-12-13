using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessClassDAL;

public partial class Application_ISys_Saim_PopStdPrdctDef : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
        {
            Response.Redirect("~/ErrorSession.aspx");
        }

        if (!IsPostBack)
        {
            FillDdlLOBName();
            FillDropDowns(ddlFreq, "8", "");
            ddlFreq.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
    }
    protected void FillDropDowns(DropDownList ddl, string val, string yrtyp)
    {
        ddl.Items.Clear();
        Hashtable ht = new Hashtable();
        ht.Add("@Flag", val.ToString().Trim());
        if (yrtyp != "")
        {
            ht.Add("@YEAR_TYPE", yrtyp.ToString().Trim());
        }
        drRead = objDal.Common_exec_reader_prc_SAIM("Prc_FillMstVals", ht);
        if (drRead.HasRows)
        {
            ddl.DataSource = drRead;
            ddl.DataTextField = "DESC01";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        drRead.Close();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "validate", "doOk('" + ddlLOBName.SelectedValue.ToString().Trim() + "','" + ddlLOBName.SelectedItem.Text.ToString().Trim() + "','" + ddlPrdctName.SelectedValue.ToString().Trim() + "','" + ddlPrdctName.SelectedItem.Text.ToString().Trim() + "','" + ddlFreq.SelectedValue.ToString().Trim() + "','" + ddlFreq.SelectedItem.Text.ToString().Trim() + "','" + rbtConsider.SelectedValue.ToString().Trim() + "','" + rbtConsider.SelectedItem.Text.ToString().Trim() + "','" + rblType.SelectedValue.ToString().Trim() + "','" + rblType.SelectedItem.Text.ToString().Trim() + "','" + txtWgth.Text.ToString().Trim() + "');", true);
    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {

    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void ddlLOBName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsPrdct = new DataSet();
        Hashtable htPrdct = new Hashtable();
        htPrdct.Add("@LobCode", ddlLOBName.SelectedValue);
        dsPrdct = objDal.GetDataSetForPrc_SAIM("Prc_GetPrdctDtls", htPrdct);

        if (dsPrdct.Tables.Count > 0)
        {
            ddlPrdctName.DataSource = dsPrdct;
            ddlPrdctName.DataTextField = "ProdDesc";
            ddlPrdctName.DataValueField = "ProdCode";
        }
        ddlPrdctName.DataBind();
        ddlPrdctName.Items.Insert(0, new ListItem("-- SELECT --", ""));
        
    }
    protected void FillDdlLOBName()
    {
        try
        {
            DataSet dsLOB = new DataSet();
            dsLOB = objDal.GetDataSetForPrc_SAIM("Prc_GetLOBDtls");

            if (dsLOB.Tables.Count > 0)
            {
                ddlLOBName.DataSource = dsLOB;
                ddlLOBName.DataTextField = "LOBDesc";
                ddlLOBName.DataValueField = "LOBCode";
            }
            ddlLOBName.DataBind();
            ddlLOBName.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlPrdctName.Items.Insert(0, new ListItem("-- SELECT --", ""));
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopStdPrdtDef", "FillDdlLOBName", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void FillDdlProductName()
    {
        try
        {
            DataSet dsPrdct = new DataSet();
            Hashtable htPrdct = new Hashtable();
            htPrdct.Add("@LobCode", ddlLOBName.SelectedValue);
            dsPrdct = objDal.GetDataSetForPrc_SAIM("Prc_GetPrdctDtls", htPrdct);

            if (dsPrdct.Tables.Count > 0)
            {
                ddlPrdctName.DataSource = dsPrdct;
                ddlPrdctName.DataTextField = "ProdDesc";
                ddlPrdctName.DataValueField = "ProdCode";
            }
            ddlPrdctName.Items.Insert(0, new ListItem("-- SELECT --", ""));
            ddlPrdctName.DataBind();
        }
        catch (Exception ex)
        {
           // string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
           // string sRet = oInfo.Name;
           // System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
           // String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "PopStdPrdtDef", "FillDdlProductName", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlPrdctName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet dsPrdct = new DataSet();
        //Hashtable htPrdct = new Hashtable();
        //htPrdct.Add("@LobCode", ddlLOBName.SelectedValue);
        //dsPrdct = objDal.GetDataSetForPrc_SAIM("Prc_GetPrdctDtls", htPrdct);

        //if (dsPrdct.Tables.Count > 0)
        //{
        //    ddlPrdctName.DataSource = dsPrdct;
        //    ddlPrdctName.DataTextField = "ProdDesc";
        //    ddlPrdctName.DataValueField = "ProdCode";
        //}
        //ddlPrdctName.Items.Insert(0, new ListItem("-- Select --", ""));
        //ddlPrdctName.DataBind();
    }
}
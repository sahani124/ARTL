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
public partial class Application_ISys_Saim_Popdatedefsetup : BaseClass
{
    DataSet ds = new DataSet();
    DataAccessClass objDal = new DataAccessClass();
    private INSCL.App_Code.CommonUtility oCommonU = new INSCL.App_Code.CommonUtility();
    CommonFunc oCommon = new CommonFunc();
    Hashtable htParam = new Hashtable();
    SqlDataReader drRead;
    ErrLog objErr = new ErrLog();
    string cmpnstcd, cntstcd, rultyp, chnl, schnl = string.Empty;
    string value = String.Empty;
    string strACC_YEAR = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserLangNum"] == null || Session["CarrierCode"] == null || Session["LanguageCode"] == null)
            {
                Response.Redirect("~/ErrorSession.aspx");
            }

            if (!IsPostBack)
            {
                Fillddlkpicode();
                ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
                Getdatedefdg("");
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    public void Fillddlkpicode()
    {
        try
        {
            Hashtable htRsk = new Hashtable();
            DataSet dsRsk = new DataSet();
            htRsk.Clear();
            dsRsk.Clear();
            htRsk.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString().Trim());
            dsRsk = objDal.GetDataSetForPrc_SAIM("Prc_GETKPICODEFRMRULSETKEY", htRsk);
            if (dsRsk.Tables.Count > 0 && dsRsk.Tables[0].Rows.Count > 0)
            {
                ddlkpicode.DataSource = dsRsk.Tables[0];
                ddlkpicode.DataTextField = "ParamDesc1";
                ddlkpicode.DataValueField = "ParamValue";
                ddlkpicode.DataBind();
            }
            ddlkpicode.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void ddlkpicode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Filldatetpeddl();
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }

    }
    public void Filldatetpeddl()
    {
        try
        {
            ddlDatetyp.Items.Clear();
            Hashtable htRsk = new Hashtable();
            DataSet dsRsk = new DataSet();
            htRsk.Clear();
            dsRsk.Clear();
            htRsk.Add("@KPI_CODE", ddlkpicode.SelectedValue.ToString().Trim());
            dsRsk = objDal.GetDataSetForPrc_SAIM("Prc_GETDATTYPFRMKPICDE", htRsk);
            if (dsRsk.Tables.Count > 0 && dsRsk.Tables[0].Rows.Count > 0)
            {
                ddlDatetyp.DataSource = dsRsk.Tables[0];
                ddlDatetyp.DataTextField = "ParamDesc1";
                ddlDatetyp.DataValueField = "ParamValue";
                ddlDatetyp.DataBind();
            }
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void ddlDatetyp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                lblEffDtTo_1.Visible = false;
                TxtEffTo.Text = "";
                TxtEffTo.Enabled = false;
            }
            else
            {
                lblEffDtTo_1.Visible = true;
                TxtEffTo.Text = "";
                TxtEffTo.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            if (ddlkpicode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI Code');", true);
                return;

            }
            else
            {
                ht.Add("@KPI_CODE", ddlkpicode.SelectedValue.ToString().Trim());
            }
            if (ddlDatetyp.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Date type');", true);
                return;

            }
            else
            {
                ht.Add("@DateType", ddlDatetyp.SelectedValue.ToString().Trim());
            }
            if (String.IsNullOrEmpty(TxtEffFrom.Text.Trim().ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective From');", true);
                return;

            }
            else
            {
                ht.Add("@DateEffectiveFrom", Convert.ToDateTime(TxtEffFrom.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            //if (String.IsNullOrEmpty(TxtEffTo.Text.Trim().ToString()))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective To');", true);
            //    return;

            //}
            //else
            //{
            //    ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            //}
            if (ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            else
            {
                if (String.IsNullOrEmpty(TxtEffTo.Text.Trim().ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective To');", true);
                    return;

                }
                else
                {
                    ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
                }
            }

            ht.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ht.Add("@FLAG", "2004");
            ht.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString().Trim());
            ht.Add("@CYCLE_CODE", Request.QueryString["CYCLE_CODE"].ToString().Trim());
            {
                ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_STDDEFNTN_2004", ht);
            }
            string msg = string.Empty;
            msg = ds.Tables[0].Rows[0]["MESSAGE"].ToString().Trim();
            if (msg == "FAILED")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date definition already exits');", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date definition added Successfully');", true);
            }
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
            if (ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                TxtEffTo.Enabled = true;
                lblEffDtTo_1.Visible = true;
            }
            Getdatedefdg("");
            ddlkpicode.SelectedIndex = 0;
            TxtEffFrom.Text = "";
            TxtEffTo.Text = "";
            ddlDatetyp.Items.Clear();
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
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
        gv.Rows[0].Cells[0].Text = "No tables have been defined";

        //source.Rows.Clear();
    }

    public void Getdatedefdg(string KPI_CODE)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@KPI_CODE", KPI_CODE.ToString().Trim());
            ht.Add("@FLAG", "2004");
            ht.Add("@RULE_SET_KEY", Request.QueryString["RULE_SET_KEY"].ToString().Trim());
            ht.Add("@CYCLE_CODE", Request.QueryString["CYCLE_CODE"].ToString().Trim());
            ht.Add("@CREATED_BY", HttpContext.Current.Session["UserID"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MST_STDDEFNTN_2004", ht);
            dgDateDef.DataSource = ds;
            dgDateDef.DataBind();
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, dgDateDef);
                }
            }


        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            Getdatedefdg(ddlkpicode.SelectedValue.ToString().Trim());
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void dgDateDefDelete_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblmapcod = (Label)row.FindControl("lblmapcod");
            Label Label1 = (Label)row.FindControl("Label1");
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@MAP_CODE", lblmapcod.Text.ToString().Trim());
            ht.Add("@DAT_TYP", Label1.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_DEL_MST_DATE_REL_DEF", ht);

            Getdatedefdg("");
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void dgDateDefedit_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpdate.Attributes.Add("style", "display:inline-block;");
            btnSave.Attributes.Add("style", "display:none;");
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblmapcod = (Label)row.FindControl("lblmapcod");
            Label Label1 = (Label)row.FindControl("Label1");
            Label lblDateType = (Label)row.FindControl("lblDateType");
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            ht.Add("@MAP_CODE", lblmapcod.Text.ToString().Trim());
            ht.Add("@DAT_TYP", Label1.Text.ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_FILL_MST_DATE_REL_DEF", ht);
            Session["MAP_CODE"] = lblmapcod.Text.ToString().Trim();
            Session["CODE"] = Label1.Text.ToString().Trim();
            ddlDatetyp.DataSource = ds.Tables[1];
            ddlDatetyp.DataTextField = "ParamDesc1";
            ddlDatetyp.DataValueField = "ParamValue";
            ddlDatetyp.DataBind();
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
            ddlDatetyp.SelectedValue = ds.Tables[0].Rows[0]["DateType"].ToString();
            ddlkpicode.SelectedValue = ds.Tables[0].Rows[0]["KPI_CODE"].ToString();
            TxtEffFrom.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateEffectiveFrom"]).ToString("dd/MM/yyyy");
            //TxtEffTo.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateEffectiveTo"]).ToString("dd/MM/yyyy");
            if (lblDateType.Text.ToString()=="MEMBER HISTORY DATE" || lblDateType.Text.ToString()=="INCOME STATUS AS ON DATE")
            {
                lblEffDtTo_1.Visible = false;
                TxtEffTo.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateEffectiveTo"]).ToString("dd/MM/yyyy");
                TxtEffTo.Enabled = false;
            }
            else
            {
                lblEffDtTo_1.Visible = true;
                TxtEffTo.Enabled = true;
                TxtEffTo.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateEffectiveTo"]).ToString("dd/MM/yyyy");
            }
            ddlDatetyp.Enabled = false;
            ddlkpicode.Enabled = false;
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable ht = new Hashtable();
            ds.Clear();
            ht.Clear();
            if (ddlkpicode.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select KPI Code');", true);
                return;

            }
            else
            {
                ht.Add("@KPI_CODE", ddlkpicode.SelectedValue.ToString().Trim());
            }
            if (ddlDatetyp.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Date type');", true);
                return;

            }
            else
            {
                ht.Add("@DateType", ddlDatetyp.SelectedValue.ToString().Trim());
            }
            if (String.IsNullOrEmpty(TxtEffFrom.Text.Trim().ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective From');", true);
                return;

            }
            else
            {
                ht.Add("@DateEffectiveFrom", Convert.ToDateTime(TxtEffFrom.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            //if (String.IsNullOrEmpty(TxtEffTo.Text.Trim().ToString()))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective To');", true);
            //    return;

            //}
            //else
            //{
            //    ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            //}
            if (ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
            }
            else
            {
                if (String.IsNullOrEmpty(TxtEffTo.Text.Trim().ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Enter Effective To');", true);
                    return;

                }
                else
                {
                    ht.Add("@DateEffectiveTo", Convert.ToDateTime(TxtEffTo.Text.Trim()).ToString("MM/dd/yyyy"));
                }
            }


            ht.Add("@MAP_CODE", Session["MAP_CODE"].ToString().Trim());
            ht.Add("@DAT_TYP", Session["CODE"].ToString().Trim());
            ds = objDal.GetDataSetForPrc_SAIM("PRC_UPD_MST_DATE_REL_DEF", ht);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Date type Updated Successfully');", true);
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
            if (ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                TxtEffTo.Enabled = true;
                lblEffDtTo_1.Visible = true;
            }
            Getdatedefdg("");
            ddlkpicode.SelectedIndex = 0;
            TxtEffFrom.Text = "";
            TxtEffTo.Text = "";
            ddlDatetyp.Items.Clear();
            ddlDatetyp.Items.Insert(0, new ListItem("SELECT", ""));
            btnUpdate.Attributes.Add("style", "display:none;");
            btnSave.Attributes.Add("style", "display:inline-block;");
            ddlDatetyp.Enabled = true;
            ddlkpicode.Enabled = true;

        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void TxtEffFrom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlDatetyp.SelectedItem.Text.ToString().Contains("MEMBER HISTORY DATE") || ddlDatetyp.SelectedItem.Text.ToString().Contains("INCOME STATUS AS ON DATE"))
            {
                TxtEffTo.Text = TxtEffFrom.Text;
            }
        }
        catch (Exception ex)
        {
            string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            string sRet = oInfo.Name;
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", sRet, method.Name.ToString(), ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

}
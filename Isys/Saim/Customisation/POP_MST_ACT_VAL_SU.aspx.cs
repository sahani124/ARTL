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
using System.Globalization;


public partial class Application_Isys_Saim_Customisation_POP_MST_ACT_VAL_SU : BaseClass
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
    string KPICode = string.Empty;
    string ACT_TYP = string.Empty;
    string BSD_ON_TBL_TYP = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["KPICode"].ToString().Trim() != "" && Request.QueryString["ACT_TYP"].ToString().Trim() != "" && Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim() != "")
            {
                KPICode = Request.QueryString["KPICode"].ToString().Trim();
                ACT_TYP = Request.QueryString["ACT_TYP"].ToString().Trim();
                BSD_ON_TBL_TYP = Request.QueryString["BSD_ON_TBL_TYP"].ToString().Trim();

                lblactbind.Text = ACT_TYP.ToString();
                txtEffDtFrm.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEffDtFrm.Enabled = false;

                BindMappedCode(KPICode);
                FillFacttyp();
                FillStatus();
                ddlAuthFlg.Enabled = false;
                ddlAuthFlg.SelectedValue = "1";
                FillTable(ddlBaseTbl, BSD_ON_TBL_TYP, KPICode);
                FillTable(ddlmstr,"M","");

                ddlCol.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlmstrcol.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddlmstcoldesc.Items.Insert(0, new ListItem("-- SELECT --", ""));
                ddllookupcd.Items.Insert(0, new ListItem("-- SELECT --", ""));

               // ddllookupcd.Attributes.Add("readonly","readonly");
               
            }
        }
    }
    protected void BindMappedCode(string KPICode)
         {
             try
             {
                 ds.Clear();
                 htParam.Clear();
                 htParam.Add("@KPI_CODE", KPICode.ToString());
                 ds = objDal.GetDataSetForPrc_SAIM("PRC_GET_MAPPED_CD_VAL_FACT", htParam);

                 if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 {
                     lblmappedcddesc.Text = ds.Tables[0].Rows[0]["MAPPED_CODE"].ToString().Trim();
                 }
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

    protected void FillFacttyp()
    {

        try
        {
            ds.Clear();
            htParam.Clear();
            Hashtable HTS = new Hashtable();
            HTS.Clear();
            ddlFR.Items.Clear();
            HTS.Add("@FLAG", "FCT");
            HTS.Add("@KPI_CODE", "");
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", HTS);
            if (drRead.HasRows)
            {
                ddlFR.DataSource = drRead;
                ddlFR.DataTextField = "FCTR_DESC";
                ddlFR.DataValueField = "FCTR_TYP_CODE";
                ddlFR.DataBind();
            }
            drRead.Close();
            ddlFR.Items.Insert(0, new ListItem("-- SELECT --", ""));
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
    protected void FillStatus()
    {
        try
        {
            ds.Clear();
            htParam.Clear();
            Hashtable HTS = new Hashtable();
            HTS.Clear();
            ddlAuthFlg.Items.Clear();
            HTS.Add("@FLAG", "");
            HTS.Add("@KPI_CODE","");
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", HTS);
            if (drRead.HasRows)
            {
                ddlAuthFlg.DataSource = drRead;
                ddlAuthFlg.DataTextField = "ParamDesc1";
                ddlAuthFlg.DataValueField = "ParamValue";
                ddlAuthFlg.DataBind();
            }
            drRead.Close();
            ddlAuthFlg.Items.Insert(0, new ListItem("-- SELECT --", ""));
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

    protected void FillTable(DropDownList ddl, string BSD_ON_TBL_TYP, string KPICode)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@Flag", BSD_ON_TBL_TYP.ToString());
            HTwc.Add("@KPI_CODE", KPICode.ToString());
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_FCTR_TYP", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc1";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
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

    protected void FillBase_Src_Colms(DropDownList ddl, string TBL_NAME, string FLAG)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@TBL_NAME", TBL_NAME);
            HTwc.Add("@FLAG", FLAG);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_COL_NAMES_FOR_VAL_FCT", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
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

    protected void FillBase_LookUpCode(DropDownList ddl, string FLAG)
    {
        try
        {
            Hashtable HTwc = new Hashtable();
            HTwc.Clear();
            ddl.Items.Clear();
            HTwc.Add("@TBL_NAME", "");
            HTwc.Add("@FLAG", FLAG);
            drRead = objDal.Common_exec_reader_prc_SAIM("PRC_GET_COL_NAMES_FOR_VAL_FCT", HTwc);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "COL_DESC";
                ddl.DataValueField = "COL_NAM";
                ddl.DataBind();
            }
            drRead.Close();
            ddl.Items.Insert(0, new ListItem("-- SELECT --", ""));
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


    protected void ddlBaseTbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBase_Src_Colms(ddlCol, ddlBaseTbl.SelectedValue.ToString(),"BS");
    }
    protected void ddlmstr_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBase_Src_Colms(ddlmstrcol, ddlmstr.SelectedValue.ToString(), "MS");
        FillBase_Src_Colms(ddlmstcoldesc, ddlmstr.SelectedValue.ToString(), "MS");

        if (ddlmstr.SelectedValue == "LookUpSU")
        {
            //splblook.Attributes.Add("style", "display:inline-block;");
            splblook.Visible = true;
            ddllookupcd.Enabled = true;
            ddlmstrcol.SelectedValue = "ParamValue";
            ddlmstcoldesc.SelectedValue = "ParamDesc1";
            ddlmstrcol.Enabled = false;
            ddlmstcoldesc.Enabled = false;
            FillBase_LookUpCode(ddllookupcd, "L");
         
        }
        else
        {
            //lbllookpcd.Visible = false;
            splblook.Visible = false;
            ddllookupcd.Enabled = false;
            ddllookupcd.SelectedIndex = 0;
            ddlmstrcol.SelectedValue = "";
            ddlmstcoldesc.SelectedValue = "";
            ddlmstrcol.Enabled = true;
            ddlmstcoldesc.Enabled = true;
           // ddllookupcd.Attributes.Add("readonly", "readonly");
        }

    }
    protected void btndataprepclr_Click(object sender, EventArgs e)
    {
        ddlmstcoldesc.SelectedIndex = 0;
        ddlmstrcol.SelectedIndex = 0;
        ddlCol.SelectedIndex = 0;
        ddlBaseTbl.SelectedIndex = 0;
        ddlmstr.SelectedIndex = 0;
        ddllookupcd.SelectedIndex = 0;
        ddlFR.SelectedIndex=0;
        txtValCode.Text = "";
        txtValDesc.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds.Clear();
            Hashtable ht = new Hashtable();
            ht.Clear();
            string msgs = string.Empty;

            ht.Add("@MAP_CODE",lblmappedcddesc.Text);
            ht.Add("@VAL_CODE",txtValCode.Text.ToUpper());
            ht.Add("@VAL_DESC",txtValDesc.Text);
            ht.Add("@IS_FX_RG_FLAG", ddlFR.SelectedValue.ToString());
            ht.Add("@BASE_DATA_TBL_NAME",ddlBaseTbl.SelectedValue.ToString());
            ht.Add("@BASE_DATA_TBL_COL_NAME",ddlCol.SelectedValue.ToString());
            ht.Add("@STATUS",ddlAuthFlg.SelectedValue.ToString());
            ht.Add("@EFF_DTIM", Convert.ToDateTime(txtEffDtFrm.Text.ToString().Trim()));
            ht.Add("@CREATEDBY", Session["UserID"].ToString().Trim());
            ht.Add("@IS_SCOPE", Request.QueryString["ACT_TYP"].ToString().Trim());
            if (ddlFR.SelectedValue == "1" && ddlmstr.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Master Table Name');", true);
                return;
            }
            else
            {
                ht.Add("@MASTER_NAME",ddlmstr.SelectedValue.ToString());
            }
            if (ddlFR.SelectedValue == "1" && ddlmstrcol.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Master Column Code');", true);
                return;
            }
            else
            {
                ht.Add("@MASTER_COL_NAME", ddlmstrcol.SelectedValue.ToString());
            }
            if (ddlFR.SelectedValue == "1" && ddlmstcoldesc.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select Master Column Description');", true);
                return;
            }
            else
            {
                ht.Add("@MASTER_COL_DESC", ddlmstcoldesc.SelectedValue.ToString());
            }
            if (ddlmstr.SelectedValue == "LookUpSU" && ddllookupcd.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please Select LookUpCode Value');", true);
                return;
                
            }
            else
            {
                ht.Add("@LookupCode", ddllookupcd.SelectedValue.ToString());
            }

            Ds = objDal.GetDataSetForPrc_SAIM("PRC_INS_MST_ACT_VAL_SU", ht);
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                msgs = Ds.Tables[0].Rows[0]["MSG"].ToString().Trim();
                if (msgs == "FAILED")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record Already exists..!');", true);
                    // return;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Saved Successfully...!')", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doCancel();", true);
                }

            }
            

            btndataprepclr_Click(EventArgs.Empty, EventArgs.Empty);
            ddllookupcd.Enabled = false;
            splblook.Visible = false;
        
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
    protected void ddlmstcoldesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //if (ddlmstcoldesc.SelectedValue == "LookupCode")
        //{
            
        //    spnlook.Visible = true;
        //    ddllookupcd.Enabled = true;
        //    FillBase_LookUpCode(ddllookupcd, "L");
        //  }
        //else
        //{
        //    //lbllookpcd.Visible = false;
        //    spnlook.Visible = false;
        //    ddllookupcd.Enabled = false;
        //    ddllookupcd.Attributes.Add("readonly", "readonly");
        //}
    }
    protected void ddlFR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFR.SelectedValue=="2")
        {
            ddlmstcoldesc.Enabled = false;
            ddlmstr.Enabled = false;
                ddlmstrcol.Enabled=false;
                ddlmstcoldesc.SelectedIndex = 0;
                ddlmstr.SelectedIndex = 0;
                ddlmstrcol.SelectedIndex = 0;
        }
        else
        {
            ddlmstcoldesc.Enabled = true;
            ddlmstr.Enabled = true;
            ddlmstrcol.Enabled = true;
        }
    }
    protected void btnCnclCmp_Click(object sender, EventArgs e)
    {
       // ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "doSelect('mdlpopup','')", true);
    }
}
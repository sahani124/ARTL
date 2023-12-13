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
using System.Web.Services;
using Newtonsoft.Json;

public partial class Application_Isys_Saim_Customisation_MstActCatgSU : BaseClass
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
                try
                {

                   //txtvaluefactors.Text = "";
                    BindListBox();
                    Fillddl(ddlrating, "ActRating");
                    Fillddl(ddlstatus, "AuthFlg");
                    Fillddl(ddlactbehtyp, "BehTyp");
                    ddlactbehtyp.SelectedIndex = 2;
                    bindSchemeKey("Schkey");
                    bindgvcatgStp();
                    if (Request.QueryString["ActNo"].ToString().Trim() != "")
                    {
                        txtrulNo.Text = Request.QueryString["ActNo"].ToString().Trim();
                        getExecutionOrder(Request.QueryString["ActNo"].ToString().Trim());
                    }

                    //Added Functionality By Pratik
                    disable_Control(Convert.ToString(Request.QueryString["role"]),sender);
                    //txtvaluefactors.Text = "test";
                }
                catch (Exception ex)
                {
                    //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                    //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
                    //string sRet = oInfo.Name;
                    //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                    //String LogClassName = method.ReflectedType.Name;
                    objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
                }
            }
            txtEffDFrom.Attributes.Add("readonly", "readonly");
            txtEffDTo.Attributes.Add("readonly", "readonly");
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "Page_Load", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void BindListBox()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@ValCode", 1);
            htparam.Add("@ActNo", Request.QueryString["ActNo"].ToString().Trim());
            htparam.Add("@ACT_TYPE", Request.QueryString["ACT_TYPE"].ToString().Trim());
            
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetValuefactorData", htparam); //Proc Created by Daksh in SAIM DB
            lstfixfactors.DataSource = dsfill.Tables[0];
            lstfixfactors.DataTextField = "ParamDesc01";
            lstfixfactors.DataValueField = "ParamValue";
            lstfixfactors.DataBind();

            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@ValCode", 2);
            htparam.Add("@ActNo", Request.QueryString["ActNo"].ToString().Trim());
            htparam.Add("@ACT_TYPE", Request.QueryString["ACT_TYPE"].ToString().Trim());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetValuefactorData", htparam); //Proc Created by Daksh in SAIM DB
            lstrangeFactors.DataSource = dsfill.Tables[0];
            lstrangeFactors.DataTextField = "ParamDesc01";
            lstrangeFactors.DataValueField = "ParamValue";
            lstrangeFactors.DataBind();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "BindListBox", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void Fillddl(DropDownList ddl, string LookupCode)
    {
        try
        {
            ddl.Items.Clear();
            Hashtable ht = new Hashtable();
            ht.Add("@LookupCode", LookupCode);
            drRead = objDal.Common_exec_reader_prc_SAIM("Prc_GetBindddlVal", ht);
            if (drRead.HasRows)
            {
                ddl.DataSource = drRead;
                ddl.DataTextField = "ParamDesc01";
                ddl.DataValueField = "ParamValue";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "Fillddl", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public void bindSchemeKey(string key)
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@key", key);
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetSchemeKey", htparam); //Proc Created by Daksh in SAIM DB
            txtschmKey.Text = dsfill.Tables[0].Rows[0]["Value"].ToString().Trim();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "bindSchemeKey", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }


    }

    public void bindgvcatgStp()
    {
        try
        {
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@ACT_NO", Request.QueryString["ActNo"].ToString().Trim());
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_GetActCatgStp", htparam); //Proc Created by Daksh in SAIM DB
            if (dsfill.Tables.Count > 0)
            {
                gvcatgStp.DataSource = dsfill;
                gvcatgStp.DataBind();
                ViewState["grid"] = dsfill.Tables[0];
                if (gvcatgStp.PageCount > 1)
                {
                    btnnext.Enabled = true;
                }
                else
                {
                    btnnext.Enabled = false;
                }
            }

            else
            {
                //ds = null;
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "bindgvcatgStp", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvcatgStp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    Label lblActSchNo = (Label)e.Row.FindControl("lblActSchNo");
                    Label lblActNo = (Label)e.Row.FindControl("lblActNo");
                    LinkButton lnkActSchKey = (LinkButton)e.Row.FindControl("lnkActSchKey");
                    LinkButton lnkMPLView = (LinkButton)e.Row.FindControl("lnkMPLView");
                    Label lbltxtareaRngFactor = (Label)e.Row.FindControl("lbltxtareaRngFactor");
                    

                    DataSet ds = new DataSet();
                    Hashtable htparam = new Hashtable();
                    int count;
                    htparam.Clear();
                    ds.Clear();
                    htparam.Add("@ACT_NO", lblActNo.Text);
                    htparam.Add("@ACT_SCH_NO", lblActSchNo.Text);
                    htparam.Add("@ACT_SCHM_KEY", lnkActSchKey.Text);
                    ds = objDal.GetDataSetForPrc_SAIM("Prc_GetSchmCount", htparam);
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit") as LinkButton;
                    if(lbltxtareaRngFactor.Text == "")
                    {
                        lnkActSchKey.Enabled = false;
                    }
                    else
                    {
                        lnkActSchKey.Enabled = true;
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["tblCount"]) > 0)
                    {
                        lnkEdit.Visible = false;
                    }
                    else
                    {
                        lnkEdit.Visible = true;
                    }
                    if( Convert.ToString(Request.QueryString["role"])  == "admin")
                    {
                        lnkActSchKey.Enabled = false;
                    
                    }
                    if(Request.QueryString["ACT_TYPE"].ToString()=="1001")
                    {
                        lnkMPLView.Enabled = true;


                    }



                }
               // Added BY Pratik
               // ((LinkButton)e.Row.FindControl("lnkActSchKey")).Enabled = (Convert.ToString(Request.QueryString["role"]) != "admin");
            }
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "gvcatgStp_RowDataBound", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void gvcatgStp_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            GridView dgSource = (GridView)sender;
            string strSort = string.Empty;
            string strASC = string.Empty;
            if (dgSource.Attributes["SortExpression"] != null)
            {
                strSort = dgSource.Attributes["SortExpression"].ToString();
            }
            if (dgSource.Attributes["SortASC"] != null)
            {
                strASC = dgSource.Attributes["SortASC"].ToString();
            }

            dgSource.Attributes["SortExpression"] = e.SortExpression;
            dgSource.Attributes["SortASC"] = "Yes";

            if (e.SortExpression == strSort)
            {
                if (strASC == "Yes")
                {
                    dgSource.Attributes["SortASC"] = "No";
                }
                else
                {
                    dgSource.Attributes["SortASC"] = "Yes";
                }
            }

            DataTable dt = (DataTable)ViewState["grid"];
            DataView dv = new DataView(dt);
            dv.Sort = dgSource.Attributes["SortExpression"];

            if (dgSource.Attributes["SortASC"] == "No")
            {
                dv.Sort += " DESC";
            }

            dgSource.PageIndex = 0;
            dgSource.DataSource = dv;
            dgSource.DataBind();
            if (dgSource.PageCount >= Convert.ToInt32(txtPage.Text))
            {
                btnprevious.Enabled = false;
                txtPage.Text = "1";
                btnnext.Enabled = true;
            }
            else
            {
                btnnext.Enabled = false;
            }
            /////ShowPageInformation();
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "gvcatgStp_Sorting", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    protected void btnprevious_Click(object sender, EventArgs e)
    {

        try
        {
            int pageIndex = gvcatgStp.PageIndex;
            gvcatgStp.PageIndex = pageIndex - 1;
            bindgvcatgStp();
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
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "btnprevious_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = gvcatgStp.PageIndex;
            gvcatgStp.PageIndex = pageIndex + 1;
            bindgvcatgStp();
            txtPage.Text = Convert.ToString(Convert.ToInt32(txtPage.Text) + 1);
            btnprevious.Enabled = true;
            if (txtPage.Text == Convert.ToString(gvcatgStp.PageCount))
            {
                btnnext.Enabled = false;
            }
            int page = gvcatgStp.PageCount;
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "btnnext_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    public class actionSetupDtls
    {
        public string ActNo { get; set; }
        public string Rating { get; set; }
        public string Fixfactors { get; set; }
        public string Rangefactors { get; set; }
        public string Valuefactors { get; set; }
        public string Actschkey { get; set; }
        public string EffDateFrom { get; set; }
        public string EffDateTo { get; set; }
        public string Excordr { get; set; }
        public string ActVer { get; set; }
        public string ActBehTyp { get; set; }
        public string ActSchNo { get; set; }
        public string Status { get; set; }
    }

    [WebMethod]
    public static string actionSetupDetails(List<actionSetupDtls> data)
    {
        try
        {
            Hashtable htparam = new Hashtable();
            DataSet dsfill = new DataSet();
            DataTable dt = new DataTable();
            htparam.Clear();
            dsfill.Clear();
            DataAccessClass objDal = new DataAccessClass();
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@ACT_NO", data[0].ActNo.Trim());//data[0].ActNo.Trim()
            htparam.Add("@Rating", data[0].Rating);
            htparam.Add("@FIX_FCTR", data[0].Fixfactors.Trim());
            htparam.Add("@RNG_FCTR", data[0].Rangefactors.Trim());
            htparam.Add("@VAL_FCTR", data[0].Valuefactors.Trim());
            htparam.Add("@ACT_SCHM_KEY", data[0].Actschkey.Trim());
            htparam.Add("@EFF_DTIM", data[0].EffDateFrom.Trim());
            htparam.Add("@CSE_DTIM", data[0].EffDateTo.Trim());
            htparam.Add("@EXCTN_ORDR", data[0].Excordr.Trim());
            htparam.Add("@ACT_VER", data[0].ActVer.Trim());
            htparam.Add("@ACT_BEH_TYPE", data[0].ActBehTyp.Trim());
            htparam.Add("@ACT_SCHM_NO", data[0].ActSchNo.Trim());
            htparam.Add("@STATUS", data[0].Status.Trim());
            htparam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@Flag", "SAV");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_Ins_Upd_MST_ACT_CATG_SU", htparam);
            //dsfill = objDal.GetDataSetForPrc_SAIM("Prc_Ins_MST_ACT_CATG_SU", htparam);
            if (dsfill.Tables[0].Rows[0]["Status"].ToString().Trim() == "0")
            {
                //Application_Isys_Saim_Customisation_IRulrtgnSuAdd bind = new Application_Isys_Saim_Customisation_IRulrtgnSuAdd();
                //bind.bindgvcatgStp();
                return dsfill.Tables[0].Rows[0]["Status"].ToString().Trim();
            }
            else
            {
                return "1";
            }

        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "actionSetupDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return "1";
        }
    }


    [WebMethod]
    public static string actionSetupUpdateDetails(List<actionSetupDtls> data)
    {
        try
        {
            Hashtable htparam = new Hashtable();
            DataSet dsfill = new DataSet();
            DataTable dt = new DataTable();
            htparam.Clear();
            dsfill.Clear();
            DataAccessClass objDal = new DataAccessClass();
            htparam.Clear();
            dsfill.Clear();
            htparam.Add("@ACT_NO", data[0].ActNo.Trim());//data[0].ActNo.Trim()
            htparam.Add("@Rating", data[0].Rating);
            htparam.Add("@FIX_FCTR", data[0].Fixfactors.Trim());
            htparam.Add("@RNG_FCTR", data[0].Rangefactors.Trim());
            htparam.Add("@VAL_FCTR", data[0].Valuefactors.Trim());
            htparam.Add("@ACT_SCHM_KEY", data[0].Actschkey.Trim());
            htparam.Add("@EFF_DTIM", data[0].EffDateFrom.Trim());
            htparam.Add("@CSE_DTIM", data[0].EffDateTo.Trim());
            htparam.Add("@EXCTN_ORDR", data[0].Excordr.Trim());
            htparam.Add("@ACT_VER", data[0].ActVer.Trim());
            htparam.Add("@ACT_BEH_TYPE", data[0].ActBehTyp.Trim());
            htparam.Add("@ACT_SCHM_NO", data[0].ActSchNo.Trim());
            htparam.Add("@STATUS", data[0].Status.Trim());
            htparam.Add("@CreatedBy", HttpContext.Current.Session["UserID"].ToString().Trim());
            htparam.Add("@Flag", "UPD");
            dsfill = objDal.GetDataSetForPrc_SAIM("Prc_Ins_Upd_MST_ACT_CATG_SU", htparam);
            if (dsfill.Tables[0].Rows[0]["Status"].ToString().Trim() == "0")
            {
                //Application_Isys_Saim_Customisation_IRulrtgnSuAdd bind = new Application_Isys_Saim_Customisation_IRulrtgnSuAdd();
                //bind.bindgvcatgStp();
                return dsfill.Tables[0].Rows[0]["Status"].ToString().Trim();
            }
            else
            {
                return "1";
            }

        }
        catch (Exception ex)
        {
            ErrLog objErr = new ErrLog();
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "actionSetupUpdateDetails", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
            return "1";
        }
    }

    //protected void lnkSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        htparam.Clear();
    //        dsfill.Clear();
    //        htparam.Add("@ActNo", txtrulNo.Text.Trim());
    //        htparam.Add("@Rating", ddlrating.SelectedValue);
    //        htparam.Add("@Fixfactors", "lstcode");
    //        htparam.Add("@Rangefactors", "lstcode");
    //        htparam.Add("@Valuefactors", "lstcode");
    //        htparam.Add("@Actschkey", "lstcode");
    //        htparam.Add("@EffDateFrom", "lstcode");
    //        htparam.Add("@Excordr", "lstcode");
    //        htparam.Add("@ActVer", "lstcode");
    //        htparam.Add("@ActBehTyp", "lstcode");
    //        htparam.Add("@ActSchNo", "lstcode");
    //        htparam.Add("@Status", "lstcode");
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}


    protected void lnkBlkUpd_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "lnkBlkUpd_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkActSchKey_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkActSchKey = (LinkButton)grd.FindControl("lnkActSchKey");
            string actno = Request.QueryString["ActNo"].ToString().Trim();
            string kpicode = Request.QueryString["KPIcode"].ToString().Trim();
            string mapcode = Request.QueryString["mapcode"].ToString().Trim();
            string role = Request.QueryString["role"].ToString().Trim();
            string ACT_TYPE = Request.QueryString["ACT_TYPE"].ToString().Trim();
            string page = ACT_TYPE == "1001" ? "MstActCatgSchm.aspx" : "HTML/MST_MPL_SU.html";
            Response.Redirect(page + "?SchKey=" + lnkActSchKey.Text.ToString().Trim() + "&ActNO=" + actno + "&kpicode=" + kpicode + "&mapcode=" + mapcode + "&role=" + role + "&ACT_TYPE=" + ACT_TYPE, true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "lnkActSchKey_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string actno = Request.QueryString["ActNo"].ToString().Trim();
            string ACT_TYPE = Request.QueryString["ACT_TYPE"].ToString().Trim();
            string kpicode = Request.QueryString["KPIcode"].ToString().Trim();
            string mapcode = Request.QueryString["mapcode"].ToString().Trim();
            string role = Convert.ToString(Request.QueryString["role"]);
            Response.Redirect("MSTACTSU.aspx?ActNO=" + actno + "&kpicode=" + kpicode + "&mapcode=" + mapcode + "&role=" + role + "&ACT_TYPE=" + ACT_TYPE);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "lnkCancel_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void getExecutionOrder(string ActNo)
    {
        try
        {
            DataSet ds = new DataSet();
            Hashtable htable = new Hashtable();
            ds.Clear();
            htable.Clear();
            htable.Add("@Act_No", ActNo);
            ds = objDal.GetDataSetForPrc_SAIM("Prc_Get_ExcOrdrCatgSU", htable);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtExecOrder.Text = ds.Tables[0].Rows[0]["EXCTN_ORDR"].ToString();
            }

        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "getExecutionOrder", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {

        try
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            LinkButton lnkActSchKey = row.FindControl("lnkActSchKey") as LinkButton;
            Label lblActNo = row.FindControl("lblActNo") as Label;

            Label lbltxtareafixfactor = row.FindControl("lbltxtareafixfactor") as Label;
            Label lbltxtareaRngFactor = row.FindControl("lbltxtareaRngFactor") as Label;
            Label lbltxtareavalFactor = row.FindControl("lbltxtareavalFactor") as Label;
            Label lblActBehTyp = row.FindControl("lblActBehTyp") as Label;
            Label lblEffdate = row.FindControl("lblEffdate") as Label;
            Label lblCSEdate = row.FindControl("lblCSEdate") as Label;
            Label lblExcOrder = row.FindControl("lblExcOrder") as Label;
            Label lblstatus = row.FindControl("lblstatus") as Label;
            Label lblActSchNo = row.FindControl("lblActSchNo") as Label;

            txtrulNo.Text = lblActNo.Text.Trim();
            txtactver.Text = "1.00";

            ds.Clear();
            htparam.Clear();
            htparam.Add("@ACT_NO", lblActNo.Text.Trim());
            htparam.Add("@ACT_SCHM_KEY", lnkActSchKey.Text.Trim());
            ds = objDal.GetDataSetForPrc_SAIM("Prc_GetSelValFactors", htparam);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                foreach (ListItem lst in lstfixfactors.Items)
                {
                    if (ds.Tables[0].Rows[i]["FixFctr"].ToString() == lst.Value)
                    {
                        lst.Selected = true;
                    }
                }
            }

            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                foreach (ListItem lst in lstrangeFactors.Items)
                {
                    if (ds.Tables[1].Rows[i]["RngFctr"].ToString() == lst.Value)
                    {
                        lst.Selected = true;
                    }
                }
            }
            txtareaFixfactor.Text = lbltxtareafixfactor.Text.Trim();
            txtareaRangefactor.Text = lbltxtareaRngFactor.Text.Trim();
            txtvaluefactors.Text = lbltxtareavalFactor.Text.Trim();

            txtEffDFrom.Text = Convert.ToDateTime(lblEffdate.Text.Trim()).ToString("dd/MM/yyyy");
            if (lblCSEdate.Text.Trim() != "")
            {
                txtEffDTo.Text = Convert.ToDateTime(lblCSEdate.Text.Trim()).ToString("dd/MM/yyyy");
            }
            else
            {
                txtEffDTo.Text = "";
            }
            ddlactbehtyp.SelectedValue = lblActBehTyp.Text.Trim();
            txtExecOrder.Text = lblExcOrder.Text.Trim();
            ddlstatus.SelectedValue = lblstatus.Text.Trim();
            txtschmKey.Text = lnkActSchKey.Text.Trim();
            txtactschno.Text = lblActSchNo.Text.Trim();
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "bindList()", true);
            btnUpdate.Attributes.Add("style", "display:inline-block;");
            btnSave.Attributes.Add("style", "display:none;");
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "scrollToTop()", true);
        }
        catch (Exception ex)
        {
            //string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(currentFile);
            //string sRet = oInfo.Name;
            //System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            //String LogClassName = method.ReflectedType.Name;
            objErr.LogErr("ISYS-SAIM", "MstActCatgSU", "lnkEdit_Click", ex.Message.ToString(), HttpContext.Current.Session["UserID"].ToString().Trim());
        }
    }


    //Added Functionality By Pratik
    public void disable_Control(string role, object sender)
    {
        div1.Visible = (role == "admin");
        gvcatgStp.Columns[7].Visible = (role == "admin");

        //GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
        //LinkButton lnkActSchKey = (LinkButton)grd.FindControl("lnkActSchKey");
        //if (role == "admin")
        //{
        //    lnkActSchKey.Enabled = false;
        //}

    }

    protected void lnkMPLView_Click(object sender, EventArgs e)
    {
        try
        {
            string RANGE = string.Empty;
            GridViewRow grd = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lnkActSchKey = (LinkButton)grd.FindControl("lnkActSchKey");
            Label lbltxtareaRngFactor = (Label)grd.FindControl("lbltxtareaRngFactor");

            string actno = Request.QueryString["ActNo"].ToString().Trim();
            string kpicode = Request.QueryString["KPIcode"].ToString().Trim();
            string mapcode = Request.QueryString["mapcode"].ToString().Trim();
            string role = Request.QueryString["role"].ToString().Trim();
            string ACT_TYPE = Request.QueryString["ACT_TYPE"].ToString().Trim();
            if(lbltxtareaRngFactor.Text == "")
            {
                RANGE = "Y";
            }
            else
            {
                RANGE = "N";
            }
            string page = ACT_TYPE == "1001" ? "MstActCatgSchm.aspx" : "HTML/MST_MPL_SU_P2.html";
            Response.Redirect(page + "?SchKey=" + lnkActSchKey.Text.ToString().Trim() + "&ActNO=" + actno + "&kpicode=" + kpicode + "&mapcode=" + mapcode + "&role=" + role + "&ACT_TYPE=" + ACT_TYPE + "&RANGE=" + RANGE, true);
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